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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_dbdepartment {
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class Meta_dbdepartment : Meta_easydata {
		public Meta_dbdepartment(DataAccess Conn, MetaDataDispatcher Dispatcher) 
			: base(Conn, Dispatcher, "dbdepartment") 
		{	
			EditTypes.Add("config");
			Name = "Configurazione Dipartimenti";
		}
		
		protected override Form GetForm(string FormName){
			switch (FormName) {
				case "config": 
					ActAsList();
					return GetFormByDllName("dbdepartment_config");
			}
			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (R["!password"] is DBNull) {
				errmess = "Inserire la password";
				errfield = null;
				return false;
			}
			return base.IsValid (R, out errmess, out errfield);
		}
	}
}
