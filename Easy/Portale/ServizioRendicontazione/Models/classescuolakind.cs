
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

namespace ServizioRendicontazione.Models
{
    public partial class classescuolakind
    {
        [StringLength(50)]
        public string idclassescuolakind { get; set; }
        public int idcorsostudiokind { get; set; }
        public int? idcorsostudiolivello { get; set; }
        [Required]
        [StringLength(1024)]
        public string title { get; set; }
    }
}
