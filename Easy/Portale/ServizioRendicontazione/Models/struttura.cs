
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
    public partial class struttura
    {
        public int idstruttura { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string codice { get; set; }
        [StringLength(10)]
        public string codiceipa { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Ct { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Cu { get; set; }
        [StringLength(200)]
        [Unicode(false)]
        public string email { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string fax { get; set; }
        public int? idaoo { get; set; }
        public int? idreg { get; set; }
        public int idsede { get; set; }
        public int idstrutturakind { get; set; }
        [StringLength(36)]
        [Unicode(false)]
        public string idupb { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Lt { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Lu { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string telefono { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string title { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string title_en { get; set; }
        public int? idreg_resp { get; set; }
        public int? paridstruttura { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? pesoindicatori { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? pesoobiettivi { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? pesoprogaltreuo { get; set; }
        [Column(TypeName = "decimal(19, 2)")]
        public decimal? pesoproguo { get; set; }
        public int? idreg_appr { get; set; }
        public int? idreg_valut { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string active { get; set; }
    }
}
