
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetupDB {
	class Program {
		static void Main(string[] args)
		{
			var sourceDirectory = "";
			var connectionString = "";

			DirectoryInfo source = new DirectoryInfo(sourceDirectory);
			// Copy each file into the new directory.
			foreach (FileInfo fi in source.GetFiles())
			{
				var fullPath = Path.Combine(fi.FullName, fi.Name);
				var enc = GetEncoding(fullPath);
				string text = File.ReadAllText(fullPath, enc);
				using (var connection = new SqlConnection(connectionString))
				{
					connection.Open();
					SqlCommand cmd = new SqlCommand(text, connection);
					try
					{
						cmd.ExecuteNonQuery();
					}
					catch (SqlException e)
					{
						Console.WriteLine(fi.Name + " : " + e.Message);
					}
				}
			}
		}

		public static Encoding GetEncoding(string filename)
		{

			// Read the BOM
			var bom = new byte[4];
			using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				file.Read(bom, 0, 4);

				// Analyze the BOM

				//UTF-8with and without BOM
				if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf)
					return Encoding.UTF8;
				else
				{
					BinaryReader r = new BinaryReader(file, System.Text.Encoding.Default);
					int i;
					int.TryParse(file.Length.ToString(), out i);
					byte[] ss = r.ReadBytes(i);
					if (IsUTF8Bytes(ss))
						return Encoding.UTF8;
				}
			}

			if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
			if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
			if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
			if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;

			////testing if is ANSI or UTF-8 without BOM
			//if (bom[0] == 0x28 && bom[1] == 0x66 && bom[2] == 0x75)
			//	enc = Encoding.UTF8;
			//if (bom[0] == 0x2f && bom[1] == 0x2a && bom[2] == 0x2a)
			//	enc = Encoding.UTF8;

			return Encoding.Default; //ANSI without BOM;
		}

		private static bool IsUTF8Bytes(byte[] data)
		{
			int charByteCounter = 1;
			byte curByte;
			for (int i = 0; i < data.Length; i++)
			{
				curByte = data[i];
				if (charByteCounter == 1)
				{
					if (curByte >= 0x80)
					{
						while (((curByte <<= 1) & 0x80) != 0)
						{
							charByteCounter++;
						}

						if (charByteCounter == 1 || charByteCounter > 6)
						{
							return false;
						}
					}
				}
				else
				{
					if ((curByte & 0xC0) != 0x80)
					{
						return false;
					}
					charByteCounter--;
				}
			}
			if (charByteCounter > 1)
			{
				throw new Exception("Error byte format");
			}
			return true;
		}
	}
}
