using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppClient.Models
{
	public class ChatRoom
	{
		public string _roomName { get; set; }
		public string _roomID { get; set; }

        public ChatRoom(string roomName,string roomId)
        {
            _roomID = roomId;
            _roomName = roomName;
        }
    }
}
