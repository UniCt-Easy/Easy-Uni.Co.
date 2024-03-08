
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
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace ServizioPa.Models {

	//[Table("Emisti_Rec_07", Schema = "dbo")]
	public class Emisti_Rec_07 {

		public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Data Emissione")]
        public DateTime DataEmissione { get; set; }

        //[Display(Name = "Codice Assegno")]
        public int CodiceAssegno { get; set; }

        //[Display(Name = "Codice Arretrato")]
        //[StringLength(3)]
        public string CodiceArretrato { get; set; }

        //[Display(Name = "Data Lotto")]
        public DateTime DataLotto { get; set; }

        //[Display(Name = "Numero Lotto")]
        public int NumLotto { get; set; }

        //[Display(Name = "Anno Riferimento")]
        public int AnnoRiferimento { get; set; }

        //[Display(Name = "Codice Ritenuta")]
        //[StringLength(3)]
        public string CodRitPrevAss { get; set; }

        public int Imponibile { get; set; }

        //[Display(Name = "Importo Ritenuta Lavoratore")]
        public int ImportoRitLavoratore { get; set; }

        //[Display(Name = "Importo Ritenuta Datore")]
        public int ImportoRitDatore { get; set; }
	}
}
