
using ChatAppServer.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Models
{
	public class ChatRoom
	{
        public string _roomName { get; set; }
		public Guid roomID { get; set; }

        private int _maxClients { get; set; }

        public List<Client> connectedClients { get; set; }

        private Client _host;

        public int _roomKey;

        public ChatRoom(int maxClients,string roomName,Client host)
        {
            _maxClients = maxClients;
            _roomName = roomName;
            roomID = Guid.NewGuid();
            _host = host;
			_roomKey = Encrypter.generateKey();
			connectedClients = new List<Client>();
			Console.WriteLine($"{DateTime.Now}: [{_host.userName}] has created Room: {roomName} with key {_roomKey}");
        }
    }
}
