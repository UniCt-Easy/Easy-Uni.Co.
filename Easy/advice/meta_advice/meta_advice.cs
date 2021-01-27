
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_advice {
    public class Meta_advice : Meta_easydata {
        public Meta_advice(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "advice") {
            Name = "Comunicazioni";
            EditTypes.Add("default");
            DefaultListType = "default";
        }
        protected override Form GetForm(string FormName) {
            switch (FormName) {
                case "default":
                    ActAsList();
                    return GetFormByDllName("advice_default");
            }
            return null;
        }
        public override void DescribeColumns(System.Data.DataTable T, string ListingType) {
            base.DescribeColumns(T);
            foreach (DataColumn c in T.Columns) DescribeAColumn(T, c.ColumnName, "");
            int nPos = 1;
            DescribeAColumn(T, "codeadvice", "Codice",nPos++);
            DescribeAColumn(T, "adate", "Del", nPos++);
            DescribeAColumn(T, "title", "Titolo", nPos++);
        }

        public override bool IsValid (DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["codeadvice"] == DBNull.Value) {
                errmess = "Il campo \"Codice Comunicazione\" è obbligatorio";
                errfield = "codeadvice";
                return false;
            }

            return true;
        }

        public override void SetDefaults (DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);

            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
        }
    }
}
