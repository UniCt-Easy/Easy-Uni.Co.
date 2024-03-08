
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
    public partial class corsostudio
    {
        public int idcorsostudio { get; set; }
        [StringLength(1)]
        [Unicode(false)]
        public string almalaureasurvey { get; set; }
        public int? annoistituz { get; set; }
        public int? basevoto { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string codice { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string codicemiur { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string codicemiurlungo { get; set; }
        public int? crediti { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Ct { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Cu { get; set; }
        public int? durata { get; set; }
        public int idcorsostudiokind { get; set; }
        public int? idcorsostudiolivello { get; set; }
        public int? idcorsostudionorma { get; set; }
        public int? idduratakind { get; set; }
        public int? idstruttura { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Lt { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Lu { get; set; }
        public string obbform { get; set; }
        public string sboccocc { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string title { get; set; }
        [StringLength(1024)]
        [Unicode(false)]
        public string title_en { get; set; }
    }
}
