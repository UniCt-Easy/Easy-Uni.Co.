
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


using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ServizioRendicontazione.Models
{
    public partial class didprog
    {
        public int iddidprog { get; set; }
        public int idcorsostudio { get; set; }
        [StringLength(9)]
        public string aa { get; set; }
        public int? annosolare { get; set; }
        public string attribdebiti { get; set; }
        public int? ciclo { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string codice { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string codicemiur { get; set; }
        [Column(TypeName = "date")]
        public DateTime? dataconsmaxiscr { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string freqobbl { get; set; }
        public int? idareadidattica { get; set; }
        public int? idconvenzione { get; set; }
        public int? iddidprognumchiusokind { get; set; }
        public int? iddidprogsuddannokind { get; set; }
        public int? iderogazkind { get; set; }
        public int? idgraduatoria { get; set; }
        public int? idnation_lang { get; set; }
        public int? idnation_lang2 { get; set; }
        public int? idnation_langvis { get; set; }
        public int? idreg_docenti { get; set; }
        public int? idsede { get; set; }
        public int? idsessione { get; set; }
        public int? idtitolokind { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string immatoltreauth { get; set; }
        public string modaccesso { get; set; }
        public string modaccesso_en { get; set; }
        public string obbformativi { get; set; }
        public string obbformativi_en { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string preimmatoltreauth { get; set; }
        public string progesamamm { get; set; }
        public string prospoccupaz { get; set; }
        public string provafinaledesc { get; set; }
        public string regolamentotax { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string regolamentotaxurl { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? startiscrizioni { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? stopiscrizioni { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string title { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string title_en { get; set; }
        public int? utenzasost { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string website { get; set; }
    }
}
