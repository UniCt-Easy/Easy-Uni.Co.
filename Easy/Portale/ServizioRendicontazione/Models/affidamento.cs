
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
    public partial class affidamento
    {
        public int idaffidamento { get; set; }
        public int idcanale { get; set; }
        public int idattivform { get; set; }
        public int iddidprogporzanno { get; set; }
        public int iddidproganno { get; set; }
        public int iddidprogori { get; set; }
        public int iddidprogcurr { get; set; }
        public int iddidprog { get; set; }
        public int idcorsostudio { get; set; }
        [StringLength(9)]
        [Unicode(false)]
        public string aa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Ct { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Cu { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string freqobbl { get; set; }
        public int? frequenzaminima { get; set; }
        public int? frequenzaminimadebito { get; set; }
        [Required]
        [StringLength(1)]
        [Unicode(false)]
        public string gratuito { get; set; }
        public int idaffidamentokind { get; set; }
        public int? iderogazkind { get; set; }
        public int? idreg_docenti { get; set; }
        public int idsede { get; set; }
        public string json { get; set; }
        public string jsonancestor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Lt { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Lu { get; set; }
        public string orariric { get; set; }
        public string orariric_en { get; set; }
        public int? paridaffidamento { get; set; }
        public string prog { get; set; }
        public string prog_en { get; set; }
        [Required]
        [StringLength(1)]
        [Unicode(false)]
        public string riferimento { get; set; }
        [Column(TypeName = "date")]
        public DateTime? start { get; set; }
        [Column(TypeName = "date")]
        public DateTime? stop { get; set; }
        public string testi { get; set; }
        public string testi_en { get; set; }
        public string title { get; set; }
        [StringLength(512)]
        [Unicode(false)]
        public string urlcorso { get; set; }
    }
}
