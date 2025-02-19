
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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

	//[Table("Emisti_Rec_02", Schema = "dbo")]
	public class Emisti_Rec_02 {

		public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Data Emissione")]
        public DateTime DataEmissione { get; set; }

        //[Display(Name = "Codice Assegno")]
        public int CodiceAssegno { get; set; }

        //[Display(Name = "Sottocodice Assegno")]
        //[StringLength(3)]
        public string SottocodiceAssegno { get; set; }

        //[Display(Name = "Importo Lordo Tabellare")]
        public int ImportoLordoTabellare { get; set; }

        //[Display(Name = "Importo Lordo Rata")]
        public int ImportoLordoRata { get; set; }

        //[Display(Name = "Importo Riduzione Part-Time")]
        public int ImportoRiduzionePT { get; set; }

        //[Display(Name = "Importo Riduzione Trattamento Economico")]
        public int ImportoRiduzioneTE { get; set; }

        //[Display(Name = "Importo Ritenuta Previdenziale")]
        public int ImportoRitPrev { get; set; }

        //[Display(Name = "Data Scadenza Assegno")]
        //[StringLength(7)]
        public string DataScadAssegno { get; set; }

        //[Display(Name = "Flag Imponibile Fiscale")]
        //[StringLength(1)]
        public string FlagImponFiscale { get; set; }
	}
}
