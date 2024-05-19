using ChatAppServer.Models;
using ChatAppServer.Utility;
using System.Net;
using System.Net.Sockets;

namespace ChatAppServer
{
	public class Server
	{
		static List<Client> _users;
		static List<ChatRoom> _rooms;
		static TcpListener _listener;
		static void Main(string[] args)
		{
			_users = new List<Client>();
			_rooms = new List<ChatRoom>();
			_listener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7891);
			_listener.Start();
            Console.WriteLine("Server is up and running");
            while (true)
			{
				var client = new Client(_listener.AcceptTcpClient());
				_users.Add(client);

				sendClientToUser(client,client.UID.ToString());
				broadCastRoomCreation();
			}

		}

		public static void sendClientToUser(Client client,string userID)
		{
			var messagePacket = new PacketBuilder();
			messagePacket.writeOpCode(0);
			messagePacket.writeMessage(userID);
			client.clientSocket.Client.Send(messagePacket.getPacketBytes());
			
		}

		public static void createNewRoom(string roomName,Client host)
		{
			ChatRoom newChatRoom = new ChatRoom(3,roomName,host);
			_rooms.Add(newChatRoom);
			broadCastRoomCreation();
		}

		public static void broadCastRoomCreation()
		{
			foreach (var user in _users)
			{
				foreach (var room in _rooms)
				{
					var broadCastPacket = new PacketBuilder();
					broadCastPacket.writeOpCode(3);
					broadCastPacket.writeMessage(room._roomName);
					broadCastPacket.writeMessage(room.roomID.ToString());
					broadCastPacket.writeMessage(room._roomKey.ToString());
					user.clientSocket.Client.Send(broadCastPacket.getPacketBytes());
				}
			}
		}

		public static void broadCastRoomDeletaion(ChatRoom room)
		{
			foreach (var user in _users)
			{
				
					var broadCastPacket = new PacketBuilder();
					broadCastPacket.writeOpCode(4);
					broadCastPacket.writeMessage(room._roomName);
					broadCastPacket.writeMessage(room.roomID.ToString());
					user.clientSocket.Client.Send(broadCastPacket.getPacketBytes());
				
			}
		}



		static void broadCastUserJoindRoom(ChatRoom room)
		{
			
			if(room == null) { return; }

			foreach (var user in room.connectedClients)
			{
                
                foreach (var usr in room.connectedClients)
				{
					try
					{

						var broadCastPacket = new PacketBuilder();
						broadCastPacket.writeOpCode(1);
						broadCastPacket.writeMessage(usr.userName);
						broadCastPacket.writeMessage(usr.UID.ToString());
						user.clientSocket.Client.Send(broadCastPacket.getPacketBytes());
					}
					catch
					{
						continue;
					}
				}
				
			}
		}

		public static void broadCastMessage(string roomID,string userName,string encryptedMessage)
		{
			var room = _rooms.Where(x => x.roomID.ToString() == roomID).FirstOrDefault();
            if (room == null)
            {
                Console.WriteLine("error");
				return;
            }
			string message = Encrypter.decryptMessage(encryptedMessage, room._roomKey);
			string hardCodedString = $"[{userName}]: ";
			string finalMessage = $"{Encrypter.encryptMessage(hardCodedString, room._roomKey)}{encryptedMessage}";

            foreach (var user in room.connectedClients)
			{
				var msgPacket = new PacketBuilder();
				msgPacket.writeOpCode(5);
				msgPacket.writeMessage(finalMessage);
				user.clientSocket.Client.Send(msgPacket.getPacketBytes());
				
			}
			Console.WriteLine($"{DateTime.Now}: [{userName}] sent: \"{message}\" To Room :{room._roomName} Encrypted Message: {encryptedMessage}");
		}
		public static void broadCastDisconnect(string uid)
		{
			var disconnectedUser = _users.Where(x => x.UID.ToString() == uid).FirstOrDefault();
			_users.Remove(disconnectedUser);
			ChatRoom foundRoom = null;
			foreach(var room in _rooms)
			{
				foreach(var user in room.connectedClients)
				{
					if(user.UID.ToString() == uid)
					{
						foundRoom = room;
						room.connectedClients.Remove(user);
						Console.WriteLine($"{DateTime.Now}: [{user.userName}] has disconnected from room {room._roomName}.");
						if(foundRoom.connectedClients.Count <= 0)
						{
							_rooms.Remove(room);
							broadCastRoomDeletaion(room);
							Console.WriteLine($"{DateTime.Now}: Room: [{foundRoom._roomName}] was deleted because all users disconnected.");
						}
						break;
					}
				}

				if(foundRoom != null )
				{
					break;
				}
			}

			if (foundRoom != null)
			{

				foreach (var user in foundRoom.connectedClients)
				{
					var broadCastPacket = new PacketBuilder();
					broadCastPacket.writeOpCode(10);
					broadCastPacket.writeMessage(uid);
					user.clientSocket.Client.Send(broadCastPacket.getPacketBytes());

				}
			}

            
        }

		public static void addUserToRoom(string userID, string roomID)
		{
            
            Client selectedUser = null;
			foreach(var user in _users)
			{
				if (user.UID.ToString() == userID)
				{
					selectedUser = user;
					
					break;
				}
			}
			if(selectedUser != null)
			{
                
                foreach (var room in _rooms)
				{
                   
                    if (room.roomID.ToString() == roomID)
					{
						  
                        room.connectedClients.Add(selectedUser);
						Console.WriteLine($"{DateTime.Now}: [{selectedUser.userName}] has connected to Room: {room._roomName}");
						Thread.Sleep(1000);
						broadCastUserJoindRoom(room);
						break;
					}
				}
			}

		}
	}
}
