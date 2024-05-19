using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAppServer.Utility
{
	public class Encrypter
	{
		public static string encryptMessage(string message, int key)
		{
			string finalString = "";
			foreach (var character in message)
			{

				int characterASCii = (int)character;
				//32 is the lowest ascii number which is for a space and 94 is number in range of all asciis that will be encryted
				char encryptedCharacer = (char)((characterASCii - 32 + (key % 94) + 94) % 94 + 32);
				finalString += encryptedCharacer;
				//Console.WriteLine($"{characterASCii} - {character} - {encryptedCharacer}");
			}

			return finalString;
		}

		public static string decryptMessage(string message, int key)
		{
			string finalString = "";
			foreach (var character in message)
			{
				int characterASCii = (int)character;
				char encryptedCharacer = (char)((characterASCii - 32 - (key % 94) + 94) % 94 + 32);
				finalString += encryptedCharacer;
			}

			return finalString;
		}

		public static int generateKey()
		{
			return new Random().Next(int.MaxValue);
		}
	}
}
