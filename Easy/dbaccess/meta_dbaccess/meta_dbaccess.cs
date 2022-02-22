
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


using funzioni_configurazione;
using metadatalibrary;
using metaeasylibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace meta_dbaccess {
	public class Meta_dbaccess : Meta_easydata {
		public Meta_dbaccess(DataAccess Conn, MetaDataDispatcher Dispatcher) 
			: base(Conn, Dispatcher, "dbaccess") 
		{
			ListingTypes.Add("default");
			EditTypes.Add("default");
		}

		//public override bool IsValid(DataRow R, out string errmess, out string errfield) {
		//	if (R["alfa"] is DBNull) {
		//		errmess = "Inserire la password del dipartimento";
		//		errfield = null;
		//		return false;
		//	}
		//	return base.IsValid (R, out errmess, out errfield);
		//}
		protected override Form GetForm(string FormName)
		{
			if (FormName == "default")
			{
				DefaultListType = "default";
				Name = "Login";
				return GetFormByDllName("dbaccess_default");
			}
			return null;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield)
		{
			if (!base.IsValid(R, out errmess, out errfield)) return false;
			// null
			if (R["pwdmaxage"] == DBNull.Value)
			{
				errmess = "E' necessario indicare una validità";
				errfield = "pwdmaxage";
				return false;
			}
			if (R["pwdwarning"] == DBNull.Value)
			{
				errmess = "E' necessario indicare un preavviso";
				errfield = "pwdwarning";
				return false;
			}
			// negativi
			if (R["pwdmaxage"] == DBNull.Value)
			{
				errmess = "La validità non può essere negativa";
				errfield = "pwdmaxage";
				return false;
			}
			if (R["pwdwarning"] == DBNull.Value)
			{
				errmess = "Il preavviso non può essere negativo";
				errfield = "pwdwarning";
				return false;
			}
			// misc
			if (CfgFn.GetNoNullInt32(R["pwdwarning"]) > CfgFn.GetNoNullInt32(R["pwdmaxage"]))
            {
				errmess = "Il preavviso deve essere inferiore alla validità";
				errfield = "pwdwarning";
				return false;
			}

			return true;
		}

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);

			Dictionary<string, string> captions = new Dictionary<string, string>();

			captions.Add("alpha1", "");
			captions.Add("iddbdepartment", "");
			captions.Add("pwdlastmod", "Ultima Modifica");
			captions.Add("pwdmaxage", "Validità");
			captions.Add("pwdwarning", "Preavviso");

			captions._forEach(caption => {
				DescribeAColumn(T, caption.Key, caption.Value);
			});
        }
    }
}
