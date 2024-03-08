
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
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyPagamenti {
    public struct cartitem {
        public int idlist;
        public int idstore;
        public int quantity;
        public decimal price;
        public int idstock;
        public string idupb;
        public string idestimkind;
        public int paymentexpiring;
        public int idivakind;
		public string annotations;
		public decimal iva;

        public string idinvkind;
        public string competencystart;
        public string competencystop;
        public string idupb_iva;
        public int idshowcase;
        public int idsor1;
        public int idsor2;
        public int idsor3;
    }
}
