
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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


namespace ServizioRendicontazione.Models
{
    public partial class rendicontaltrokind
    {
        public int idrendicontaltrokind { get; set; }
        public string active { get; set; }
        public DateTime Ct { get; set; }
        public string Cu { get; set; }
        public string description { get; set; }
        public DateTime Lt { get; set; }
        public string Lu { get; set; }
        public int sortcode { get; set; }
        public string title { get; set; }
    }

	public class RendicontaltroKindTitle
	{
		public int idkind { get; set; }
		public string title { get; set; }
	}
}
