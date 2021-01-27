
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
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_sisest_profilo
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_sisest_profilo :Meta_easydata {
        public Meta_sisest_profilo(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sisest_profilo") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "default") {
                Name = "Profilo SISEST";
                return GetFormByDllName("sisest_profilo_default");
            }
            return null;
        }
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "active", "S");
            SetDefault(T, "annoaccademico", GetSys("esercizio").ToString());
            SetDefault(T, "ayear", Conn.GetSys("esercizio"));
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idprofilo", "#", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "codiceprofilo", "Cod.Profilo", nPos++);
                DescribeAColumn(T, "annoaccademico", "Anno Accademico", nPos++);
                DescribeAColumn(T, "descrizione", "Descrizione", nPos++);
                //DescribeAColumn(T, "importo_rata", "Importo rata", nPos++);
                DescribeAColumn(T, "importo_bollo", "Importo bollo", nPos++);
                DescribeAColumn(T, "importo_regionale", "Importo regionale", nPos++);
                //DescribeAColumn(T, "importo_bollettino", "Importo bollettino", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);

            }
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
                return base.SelectOne(ListingType, filter, "sisest_profilo", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idprofilo"], null, null, 7);
            RowChange.setMinimumTempValue(T.Columns["idprofilo"], 9999000);
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }
    }
}
