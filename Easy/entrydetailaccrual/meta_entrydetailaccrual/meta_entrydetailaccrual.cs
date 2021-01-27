
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;



namespace meta_entrydetailaccrual
{//meta_dettvarbilancio//
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_entrydetailaccrual : Meta_easydata {
        public Meta_entrydetailaccrual(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "entrydetailaccrual") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Rateo dettaglio scrittura";
                return MetaData.GetFormByDllName("entrydetailaccrual_default");
            }
            return null;
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["amount"] == DBNull.Value) {
                errmess = "Attenzione! L'importo non può essere nullo.";
                errfield = "amount";
                return false;
            }

            //if (CfgFn.GetNoNullDecimal(R["amount"]) < 0) {
            //    errmess = "L'importo non può essere negativo";
            //    errfield = "amount";
            //    return false;
            //}

            if (R["yentrylinked"] == DBNull.Value) {
                errmess = "Collegare un dettaglio scrittura di tipo Rateo";
                errfield = "yentrylinked";
                return false;
            }

            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "yentry");
            RowChange.SetSelector(T, "nentry");
            RowChange.SetSelector(T, "ndetail");
            RowChange.MarkAsAutoincrement(T.Columns["idaccrual"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "yentrylinked", "Eserc.", nPos++);
                DescribeAColumn(T, "nentrylinked", "Num.", nPos++);
                DescribeAColumn(T, "ndetaillinked", "Dett.", nPos++);

            }
        }


    }
}
