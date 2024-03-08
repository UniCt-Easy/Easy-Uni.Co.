
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
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;
//using System.Threading.Tasks;

namespace ServizioPa.Models
{
    //[Table("Emisti_Rec_03", Schema = "dbo")]
    public class Emisti_Rec_03
    {
        public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Data Emissione")]
        public DateTime DataEmissione { get; set; }

        //[Display(Name = "Codice Assegno")]
        public int CodiceAssegno { get; set; }

        //[Display(Name = "Codice Ritenuta Prev Ass")]
        //[StringLength(3)]
        public string CodRitPrevAss { get; set; }

        //[Display(Name = "Aliquota Lavoratore")]
        //[Column("aliquotalavoratore", TypeName = "decimal(5, 3)")]
        public decimal AliquotaLavoratore { get; set; }

        //[Display(Name = "Percentuale Applicazione")]
        //[Column("percentualeapplicazione", TypeName = "decimal(4, 1)")]
        public decimal PercentualeApplicazione { get; set; }

        public int Imponibile { get; set; }

        //[Display(Name = "Importo Ritenuta")]
        public int ImportoRitenuta { get; set; }

        //[Display(Name = "Aliquota Datore")]
        //[Column("aliquotadatore", TypeName = "decimal(5, 3)")]
        public decimal AliquotaDatore { get; set; }

        //[Display(Name = "Importo Datore")]
        public int ImportoDatore { get; set; }
    }
}
