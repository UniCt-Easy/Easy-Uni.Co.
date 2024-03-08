
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using System.ComponentModel.DataAnnotations;

namespace ServizioTimbratura
{
    public class Lavoratore
    {
        public string matricola { get; set; }
        public int idreg { get; set; }
        public DateTime giorno { get; set; }
        public int minuti { get; set; }
        public string convalida { get; set; }
    }

    public class utente
    {
        public string idreg { get; set; }
        public string matricola { get; set; }
    }

    public class InserisciTimbraturePrm
	{
		[Required]
		public string dateFrom { get; set; }
		[Required]
		public string dateTo { get; set; }
		[Required]
		public string matricola { get; set; }
	}
}
