/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_dbaccess {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_dbaccess : Meta_easydata {
		public Meta_dbaccess(DataAccess Conn, MetaDataDispatcher Dispatcher) 
			: base(Conn, Dispatcher, "dbaccess") 
		{	
//			ListingTypes.Add("default");
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (R["alfa"] is DBNull) {
				errmess = "Inserire la password del dipartimento";
				errfield = null;
				return false;
			}
			return base.IsValid (R, out errmess, out errfield);
		}
	}
}
