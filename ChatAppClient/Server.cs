using ChatAppClient.Models;
using ChatAppServer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppClient
{
	public class Server
	{
		TcpClient _client;
		public PacketReader packetReader;

		public event Action connectedEvent;
		public event Action joinedEvent;
		public event Action messageRecievedEvent;
		public event Action userDisconnectedEvent;
		public event Action newRoomCreated;
		public event Action roomDeleted;

		public bool connectedToRoom = false;
		public Server()
		{
			_client = new TcpClient();
		}

		public void connectToServer(string userName)
		{
			if (!_client.Connected)
			{
				_client.Connect("127.0.0.1", 7891);
				packetReader = new PacketReader(_client.GetStream());

				if (!string.IsNullOrEmpty(userName))
				{
					var connectPacket = new PacketBuilder();
					connectPacket.writeOpCode(0);
					connectPacket.writeMessage(userName);
					_client.Client.Send(connectPacket.getPacketBytes());
				}

				readPackets();


			}
		}


		private void readPackets()
		{
			Task.Run(() => {
				while (true)
				{
					try
					{
						var opCode = packetReader.ReadByte();
						switch (opCode)
						{
							case 0:
								connectedEvent?.Invoke();
								break;
							case 1:
								joinedEvent?.Invoke();
								break;
							case 3:
								newRoomCreated?.Invoke();
								break;
							case 4:
								roomDeleted?.Invoke();
								break;
							case 5:
								messageRecievedEvent?.Invoke();
								break;
							case 10:
								userDisconnectedEvent?.Invoke();
								break;
							default:
								Console.WriteLine("Error");
								break;
						}
					}
					catch
					{
						MessageBox.Show("Server Closed","",MessageBoxButtons.OK,MessageBoxIcon.Information);
						Environment.Exit(0);	
					}
				}
			});
		}


		public void connectToRoom(ChatRoom room,string userID)
		{
			var messagePacket = new PacketBuilder();
			messagePacket.writeOpCode(2);
			messagePacket.writeMessage(room._roomID);
			messagePacket.writeMessage(userID);
			_client.Client.Send(messagePacket.getPacketBytes());
		}
		public void sendMessageToServer(string message,string roomID)
		{
			var messagePacket = new PacketBuilder();
			messagePacket.writeOpCode(5);
			messagePacket.writeMessage(message);
			messagePacket.writeMessage(roomID);
			_client.Client.Send(messagePacket.getPacketBytes());
		}

		public void sendRoomNameToServer(string roomName)
		{
			var messagePacket = new PacketBuilder();
			messagePacket.writeOpCode(3);
			messagePacket.writeMessage(roomName);
			_client.Client.Send(messagePacket.getPacketBytes());
		}
	}
}

