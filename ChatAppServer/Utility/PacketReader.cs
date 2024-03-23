using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Utility
{
	public class PacketReader : BinaryReader
	{
		private NetworkStream _ns;
		public PacketReader(NetworkStream ns) : base(ns)
		{
			_ns = ns;
		}

		public string readMessage()
		{
			byte[] buffer;
			var length = ReadInt32();
			buffer = new byte[length];
			_ns.Read(buffer, 0, length);

			var message = Encoding.ASCII.GetString(buffer);

			return message;
		}
	}
}
