using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Utility
{
	public class PacketBuilder
	{
		MemoryStream _ms;
		public PacketBuilder()
		{
			_ms = new MemoryStream();
		}

		public void writeOpCode(byte opCode)
		{
			_ms.WriteByte(opCode);
		}

		public void writeMessage(string msg)
		{
			var msgLength = msg.Length;
			_ms.Write(BitConverter.GetBytes(msgLength));
			_ms.Write(Encoding.ASCII.GetBytes(msg));
		}

		public byte[] getPacketBytes()
		{
			return _ms.ToArray();
		}
	}
}

