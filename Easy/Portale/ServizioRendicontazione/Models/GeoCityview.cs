
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

namespace EasyCommerce.Models
{
    public partial class GeoCityview
    {
        [Column("idcity")]
        public int Idcity { get; set; }
        [Column("title")]
        [StringLength(65)]
        [Unicode(false)]
        public string Title { get; set; }
        [Column("oldcity")]
        public int? Oldcity { get; set; }
        [Column("newcity")]
        public int? Newcity { get; set; }
        [Column("start", TypeName = "date")]
        public DateTime? Start { get; set; }
        [Column("stop", TypeName = "date")]
        public DateTime? Stop { get; set; }
        [Column("idcountry")]
        public int? Idcountry { get; set; }
        [Column("provincecode")]
        [StringLength(2)]
        [Unicode(false)]
        public string Provincecode { get; set; }
        [Column("country")]
        [StringLength(50)]
        [Unicode(false)]
        public string Country { get; set; }
        [Column("oldcountry")]
        public int? Oldcountry { get; set; }
        [Column("newcountry")]
        public int? Newcountry { get; set; }
        [Column("countrydatestart", TypeName = "date")]
        public DateTime? Countrydatestart { get; set; }
        [Column("countrydatestop", TypeName = "date")]
        public DateTime? Countrydatestop { get; set; }
        [Column("idregion")]
        public int? Idregion { get; set; }
        [Column("region")]
        [StringLength(50)]
        [Unicode(false)]
        public string Region { get; set; }
        [Column("regiondatestart", TypeName = "date")]
        public DateTime? Regiondatestart { get; set; }
        [Column("regiondatestop", TypeName = "date")]
        public DateTime? Regiondatestop { get; set; }
        [Column("oldregion")]
        public int? Oldregion { get; set; }
        [Column("newregion")]
        public int? Newregion { get; set; }
        [Column("idnation")]
        public int? Idnation { get; set; }
        [Column("idcontinent")]
        public int? Idcontinent { get; set; }
        [Column("nation")]
        [StringLength(65)]
        [Unicode(false)]
        public string Nation { get; set; }
        [Column("nationdatestart", TypeName = "date")]
        public DateTime? Nationdatestart { get; set; }
        [Column("nationdatestop", TypeName = "date")]
        public DateTime? Nationdatestop { get; set; }
        [Column("oldnation")]
        public int? Oldnation { get; set; }
        [Column("newnation")]
        public int? Newnation { get; set; }
    }
}
