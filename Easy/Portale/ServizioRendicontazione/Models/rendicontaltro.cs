
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
    public partial class rendicontaltro
    {
        public int idrendicontaltro { get; set; }
        public string aa { get; set; }
        public int idreg_docenti { get; set; }
        public DateTime Ct { get; set; }
        public string Cu { get; set; }
        public DateTime data { get; set; }
        public int idrendicontaltrokind { get; set; }
        public DateTime Lt { get; set; }
        public string Lu { get; set; }
        public decimal ore { get; set; }
    }

	public record RendicontAltroMin
    {
		public DateTime data { get; set; }
		public int idkind { get; set; }
		public decimal ore { get; set; }
		public int idreg_docenti { get; set; }
    }

    public class RendicontAltroMinComparer : IEqualityComparer<RendicontAltroMin>
    {
        public bool Equals(RendicontAltroMin x, RendicontAltroMin y)
        {
            return x.idreg_docenti == y.idreg_docenti && x.data == y.data && x.ore == y.ore;
        }

        public int GetHashCode(RendicontAltroMin obj)
        {
            return HashCode.Combine(obj.idreg_docenti, obj.data, obj.ore);
        }
    }
}
