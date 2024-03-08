
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

	//[Table("Emisti_Rec_08", Schema = "dbo")]
	public class Emisti_Rec_08 {

		public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Data Emissione")]
        public DateTime DataEmissione { get; set; }

        //[Display(Name = "Id Elenco")]
        //[Column("idelenco", TypeName = "bigint")]
        public Int64 IdElenco { get; set; }

        //[Display(Name = "Codice Ente")]
        public int CodEnte { get; set; }

        //[Display(Name = "Capitolo Bilancio Stato")]
        public int CapBilStato { get; set; }

        //[Display(Name = "Numero Piano Gestionale")]
        public int NumPG { get; set; }

        //[Display(Name = "Tipo Tassazione")]
        //[StringLength(2)]
        public string TipoTass { get; set; }

        //[Display(Name = "Anno Riferimento")]
        public int AnnoRiferimento { get; set; }

        //[StringLength(4)]
        public string Compenso { get; set; }

        //[StringLength(4)]
        public string Sottocompenso { get; set; }

        //[Display(Name = "Tipologia Compenso")]
        public int TipolCompenso { get; set; }

        public int Importo { get; set; }

        //[Display(Name = "Inizio Competenza")]
        public int Inizio_comp { get; set; }

        //[Display(Name = "Fine Competenza")]
        public int Fine_comp { get; set; }

        public int Quantita { get; set; }

        //[Display(Name = "Importo Unitario")]
        public int Imp_unitario { get; set; }

        //[Display(Name = "Importo Ritenute")]
        public int ImportoRitenute { get; set; }

        //[Display(Name = "Ufficio Responsabile Comunicante")]
        //[StringLength(3)]
        public string UfficioResponsabileComunicante { get; set; }

        //[Display(Name = "Ufficio Servizio Comunicante")]
        //[StringLength(4)]
        public string UfficioServizioComunicante { get; set; }
	}
}
