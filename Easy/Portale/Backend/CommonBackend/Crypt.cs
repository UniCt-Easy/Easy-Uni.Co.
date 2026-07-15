/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.
This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.
You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Backend
{
	public static class Crypt
	{
		// ==========================================
		//          CRYPT / DECRYPT FUNCTIONS
		// ==========================================
		public static byte[] CryptString(string key)
		{
			if (key == null) return null;
			byte[] A = Encoding.Default.GetBytes(key);

			var MS = new MemoryStream(1000);
			var CryptoS = new CryptoStream(MS,
				new TripleDESCryptoServiceProvider().CreateEncryptor(
				new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
				new byte[] { 61, 12, 99, 78, 149, 123, 147, 48, 81, 20, 238, 57, 125, 38, 13, 4 }
				), CryptoStreamMode.Write);
			CryptoS.Write(A, 0, A.Length);
			CryptoS.FlushFinalBlock();
			byte[] B = MS.ToArray();
			return B;
		}

		public static string DecryptString(byte[] B)
		{
			if (B == null) return null;
			var MS = new MemoryStream();
			var CryptoS = new CryptoStream(MS,
				new TripleDESCryptoServiceProvider().CreateDecryptor(
				new byte[] { 75, 12, 0, 215, 93, 89, 45, 11, 171, 96, 4, 64, 13, 158, 36, 190 },
				new byte[] { 61, 12, 99, 78, 149, 123, 147, 48, 81, 20, 238, 57, 125, 38, 13, 4 }
				), CryptoStreamMode.Write);
			CryptoS.Write(B, 0, B.Length);
			CryptoS.FlushFinalBlock();
			string key = Encoding.Default.GetString(MS.ToArray()).TrimEnd();
			return key;
		}

		public static string ByteArrayToString(Byte[] buf)
		{
			var ff = new StringBuilder();
			ff.Append("0x");
			var temp = new StringBuilder();
			for (var i = 0; i < buf.Length; i++)
			{
				temp.Append(ByteTohex(buf[i]));
				if (temp.Length > 1024)
				{
					ff.Append(temp.ToString());
					temp = new StringBuilder();
				}
			}
			ff.Append(temp);
			return ff.ToString();
		}

		public static Byte[] StringToByteArray(string S)
		{
			var i = 2;
			var len = S.Length;
			if (i >= len)
				return new byte[0];
			var buf = new byte[(len - i) / 2];
			var index = 0;
			while (i <= len - 2)
			{
				var xx = S.Substring(i, 2);
				buf[index++] = HexToByte(xx);
				i += 2;
			}
			return buf;
		}

		private static string ByteTohex(Byte B)
		{
			return IntToHexDigit(B >> 4) + IntToHexDigit(B & 0x0F);
		}

		private static Byte HexToByte(string S)
		{
			return Convert.ToByte(Convert.ToByte((CharToByte(S[0]) << 4)) + CharToByte(S[1]));
		}

		private static Byte CharToByte(char C)
		{
			C = Char.ToUpper(C);
			switch (C)
			{
				case '0': return 0;
				case '1': return 1;
				case '2': return 2;
				case '3': return 3;
				case '4': return 4;
				case '5': return 5;
				case '6': return 6;
				case '7': return 7;
				case '8': return 8;
				case '9': return 9;
				case 'A': return 10;
				case 'B': return 11;
				case 'C': return 12;
				case 'D': return 13;
				case 'E': return 14;
				case 'F': return 15;
			}
			return 0;
		}

		private static string IntToHexDigit(int x)
		{
			switch (x)
			{
				case 0: return "0";
				case 1: return "1";
				case 2: return "2";
				case 3: return "3";
				case 4: return "4";
				case 5: return "5";
				case 6: return "6";
				case 7: return "7";
				case 8: return "8";
				case 9: return "9";
				case 10: return "A";
				case 11: return "B";
				case 12: return "C";
				case 13: return "D";
				case 14: return "E";
				case 15: return "F";
			}
			return "x";
		}
	}
}