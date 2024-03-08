
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
    public partial class sede
    {
        public int idsede { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string address { get; set; }
        [StringLength(400)]
        [Unicode(false)]
        public string annotations { get; set; }
        [StringLength(20)]
        [Unicode(false)]
        public string cap { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Ct { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Cu { get; set; }
        public int? idcity { get; set; }
        public int? idnation { get; set; }
        public int? idreg { get; set; }
        public int? idsedemiur { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime Lt { get; set; }
        [Required]
        [StringLength(64)]
        [Unicode(false)]
        public string Lu { get; set; }
        [StringLength(1024)]
        public string title { get; set; }
    }
}
