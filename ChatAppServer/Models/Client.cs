using ChatAppServer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Models
{
	public class Client
	{
		public string userName { get; set; }
		public Guid UID { get; set; }
		public TcpClient clientSocket { get; set; }
		private PacketReader _packetReader { get; set; }
		public Client(TcpClient client)
		{
			clientSocket = client;
			UID = Guid.NewGuid();
            
            _packetReader = new PacketReader(clientSocket.GetStream());

			var opCode = _packetReader.ReadByte();
			userName = _packetReader.readMessage();
			
			Console.WriteLine($"{DateTime.Now} : A Client has connected to the server with the username: {userName}");
			Task.Run(() => process());
		}
		void process()
		{
			while (true)
			{
				try
				{
					var opCode = _packetReader.ReadByte();
					switch (opCode)
					{
						case 5:
							var message = _packetReader.readMessage();
							var roomid = _packetReader.readMessage();
							
							Server.broadCastMessage(roomid,userName,message);
							break;

						case 2:
							var roomID = _packetReader.readMessage();
							var userID = _packetReader.readMessage();
                            Server.addUserToRoom(userID, roomID);
                            break;

						case 3:
							var roomName = _packetReader.readMessage();
							Server.createNewRoom(roomName,this);

							break;
					}
				}
				catch
				{
					//Console.WriteLine($"[{UID}]: Disconnected.");
					Server.broadCastDisconnect(UID.ToString());
					clientSocket.Close();
					break;
				}
			}
		}


		
	}
}
