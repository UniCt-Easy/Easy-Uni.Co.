
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
    //[Table("Emisti_Rec_04", Schema = "dbo")]
    public class Emisti_Rec_04
    {
        public int Id_importo { get; set; }

        public int Progressivo { get; set; }

        //[StringLength(7)]
        public string Rata { get; set; }

        //[Display(Name = "Data Emissione")]
        public DateTime DataEmissione { get; set; }

        //[Display(Name = "Codice Ritenuta")]
        //[StringLength(3)]
        public string CodiceRitenuta { get; set; }

        //[Display(Name = "Tipo Ritenuta")]
        //[StringLength(1)]
        public string TipoRitenuta { get; set; }
        
        //[Display(Name = "Flag Riduz Impon")]
        //[StringLength(1)]
        public string FlagRiduzImpon { get; set; }

        //[Display(Name = "Progressivo Debito")]
        //[StringLength(4)]
        public int ProgressivoDebito { get; set; }

        //[Display(Name = "Importo Ritenuta")]
        //[StringLength(10)]
        public int ImportoRitenuta { get; set; }

        //[Display(Name = "Importo Ritenuta Netto")]
        public int ImportoRitNetto { get; set; }

        //[Display(Name = "Codice Ritenuta Onere Mensile")]
        //[StringLength(3)]
        public string CodRitOnereMens { get; set; }

        //[Display(Name = "Importo Onere Mensile")]
        public int ImportoOnereMens { get; set; }

        //[Display(Name = "Codice Ritenuta Una Tantum")]
        //[StringLength(3)]
        public string CodRit1Tantum { get; set; }

        //[Display(Name = "Importo Ritenuta Una Tantum")]
        public int ImportoRit1Tantum { get; set; }

        //[Display(Name = "Codice Contratto")]
        //[StringLength(20)]
        public string CodContratto { get; set; }

    }
}
