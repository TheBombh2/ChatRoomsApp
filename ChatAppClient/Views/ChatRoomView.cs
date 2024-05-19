using ChatAppClient;
using ChatAppClient.Models;
using ChatAppClient.Utility;
using System.Collections.ObjectModel;

namespace ChatAppClient.Views
{
	public partial class ChatRoomView : Form
	{
		public List<User> Users { get; set; }

		public ChatRoom _room { get; set; }

		public string userName { get; set; }
		public string message { get; set; }

		private Server _server;

		private bool controlsTurnedOn = false;

		public ChatRoomView(Server server, ChatRoom room, string userName)
		{
			InitializeComponent();
			Users = new List<User>();
			_server = server;
			_room = room;
			this.Text = _room._roomName;
			userNameLBL.Text = userName;

			_server.messageRecievedEvent += messageRecieved;
			_server.userDisconnectedEvent += removeUser;
			_server.joinedEvent += userJoinedRoom;



		}



		private void messageRecieved()
		{
			var encryptedMessage = _server.packetReader.readMessage();
			var message = Encrypter.decryptMessage(encryptedMessage,_room._roomKey);
			Invoke(() =>
			{
				chatMsgsTB.AppendText(message);
				chatMsgsTB.AppendText(Environment.NewLine);
			});
		}


		private void removeUser()
		{
			var uid = _server.packetReader.readMessage();
			var user = Users.Where(x => x.UID == uid).FirstOrDefault();
			if (user != null)
			{

				Invoke(() => { connectedUsersLB.Items.Remove(user.userName); });

				Users.Remove(user);

				chatMsgsTB.AppendText($"[{user.userName}] has disconnected from chat.");
				chatMsgsTB.AppendText(Environment.NewLine);
				
			}
		}
		private void userJoinedRoom()
		{
			var user = new User
			{
				userName = _server.packetReader.readMessage(),
				UID = _server.packetReader.readMessage(),
			};

			
			if (!Users.Any(x => x.UID == user.UID))
			{
				Invoke(() => { connectedUsersLB.Items.Add(user.userName); });
			}

			Users.Add(user);

			turnOnControls();


		}

		private void sendMSGBTN_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(messageTB.Text))
			{
				_server.sendMessageToServer(messageTB.Text, _room._roomID,_room._roomKey);
				messageTB.Clear();
			}
		}

		private void turnOnControls()
		{
			if (!controlsTurnedOn)
			{
				Invoke(() =>
				{
					sendMSGBTN.Enabled = true;
					messageTB.Enabled = true;
					controlsTurnedOn = true;
				});
			}
		}

		private void ChatRoomView_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		} 
	}
}
