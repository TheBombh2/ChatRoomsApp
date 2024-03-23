using ChatAppClient.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatAppClient.Views
{
	public partial class HUB : Form
	{
		private Server _server;
		private string userName;
		private List<ChatRoom> _rooms;
		private User _user;

		private bool hostCreated = false;
		public HUB()
		{
			_server = new Server();
			_server.newRoomCreated += newRoomCreated;
			_server.connectedEvent += userConnected;
			_server.roomDeleted += removeRoom;
			_rooms = new List<ChatRoom>();
			InitializeComponent();
		}

		private void connectToServerBTN_Click(object sender, EventArgs e)
		{
			try
			{
				userName = userNameTB.Text.Trim();
				if (!string.IsNullOrEmpty(userName))
				{
					_server.connectToServer(userName);
					connectToServerBTN.Enabled = false;
					userNameTB.ReadOnly = true;
					createRoomBTN.Enabled = true;
					connectToRoomBTN.Enabled = true;
				}
				else
				{
					_showErrorMessaageBox("Please specify a display name");
				}
			}
			catch
			{

			}
		}




		private void createRoomBTN_Click(object sender, EventArgs e)
		{
			string roomName = newRoomTB.Text.Trim();
			if (!string.IsNullOrEmpty(roomName))
			{
				if(_rooms.Any(x => x._roomName == roomName))
				{
					MessageBox.Show("Please specify a unique name for your room", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				
				_server.sendRoomNameToServer(roomName);
				hostCreated = true;
            }
			
		}

		void _showErrorMessaageBox(string message)
		{
			MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void newRoomCreated()
		{
			string roomName = _server.packetReader.readMessage();
			string roomId = _server.packetReader.readMessage();
			if (!_rooms.Any(x => x._roomID == roomId))
			{
				ChatRoom newChatRoom = new(roomName, roomId);
				_rooms.Add(newChatRoom);
				Invoke(() =>
				{
					roomsLB.Items.Add(roomName);

					if (hostCreated)
					{
						roomsLB.Focus();
						roomsLB.SelectedIndex = roomsLB.Items.IndexOf(roomName);
						connectToRoomBTN.PerformClick();
					}
				});
			}
		}

		private void removeRoom()
		{
			string roomName = _server.packetReader.readMessage();
			string roomId = _server.packetReader.readMessage();
			ChatRoom room = _rooms.Where(x => x._roomID == roomId).FirstOrDefault();
			if(room != null)
			{
				_rooms.Remove(room);
				Invoke(() => { roomsLB.Items.Remove(roomName); });
			}
		}

		private void connectToRoomBTN_Click(object sender, EventArgs e)
		{
			if (roomsLB.SelectedIndex == -1)
			{
				return;
			}

			string roomName = roomsLB.Items[roomsLB.SelectedIndex] as string;
			foreach(ChatRoom room in _rooms)
			{
				if(room._roomName == roomName)
				{
					ChatRoomView newChatRoom = new ChatRoomView(_server, room,userName);
					_server.connectToRoom(room,_user.UID);
					this.Hide();
					newChatRoom.Show();
					break;
				}
			}
		}

		private void userConnected()
		{
			var user = new User
			{
				userName = userName,
				UID = _server.packetReader.readMessage(),
			};

			_user = user;

		}
	}
}
