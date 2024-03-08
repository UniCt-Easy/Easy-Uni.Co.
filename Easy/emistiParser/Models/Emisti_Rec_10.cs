
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

	//[Table("Emisti_Rec_10", Schema = "dbo")]
	public class Emisti_Rec_10 {

		public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Emissione")]
        public int Emissione { get; set; }

        //[Display(Name = "Imponibile Ritenuta Acconto")]
        public int ImponibileRitenutaAcconto { get; set; }

        //[Display(Name = "Imponibile Ritenuta Acconto Con Iva")]
        public int ImponibileRitenutaAccontoIva { get; set; }

        //[Display(Name = "Importo Ritenuta Acconto")]
        public int ImportoRitenutaAcconto { get; set; }

        //[Display(Name = "Importo Contributo Integrativo Categoria")]
        public int ImpContrIntegrCat { get; set; }

        //[Display(Name = "Importo Contributo Integrativo Inps")]
        public int ImpContrIntegrInps { get; set; }

        //[Display(Name = "Importo Iva")]
        public int ImportoIva { get; set; }

        //[Display(Name = "Percentuale Contributo Integrativo Categoria")]
        //[Column("perccontrintegrcat", TypeName = "decimal(4, 2)")]
        ////[StringLength(5)]
        public decimal PercContrIntegrCat { get; set; }

        //[Display(Name = "Percentuale Contributo Integrativo Inps")]
        //[Column("perccontrintegrinps", TypeName = "decimal(4, 2)")]
        ////[StringLength(5)]
        public decimal PercContrIntegrInps { get; set; }
	}
}
