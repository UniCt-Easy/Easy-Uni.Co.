
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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ServizioTimbratura
{
	public class Costi
	{
		public DateTime start { get; set; }
		public string matricole { get; set; }
	}

	public class InserisciCostoOrarioPrm
	{
		[Required]
		public string dataElab { get; set; }
		public string dataStop { get; set; }
		[Required]
		public string matricola { get; set; }
	}

	public class LavoratoreCostoOrario
	{
		public int matricola { get; set; }
		public int idreg { get; set; }
		public DateTime giornoValidita { get; set; }
		public DateTime? giornoStop { get; set; }
		public decimal? costoOrario { get; set; }
		public decimal? oneri { get; set; }
		public decimal? irap { get; set; }
		public decimal? costoOrarioTotale { get; set; }
	}

	public class resultCostoOrario
	{
		public List<LavoratoreCostoOrario> lavoratori { get; set; }
		public string mailBody { get; set; }
		public string newDataElab { get; set; } = "";
		public string newMatricola { get; set; } = "";
		public string esitoMsg { get; set; }
	}
}
