
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
    public partial class didprogporzanno
    {
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
        public int? iddidprogporzannokind { get; set; }
        public int? indice { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Lt { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Lu { get; set; }
        [Column(TypeName = "date")]
        public DateTime? start { get; set; }
        [Column(TypeName = "date")]
        public DateTime? stop { get; set; }
        [StringLength(2048)]
        [Unicode(false)]
        public string title { get; set; }
    }
}
