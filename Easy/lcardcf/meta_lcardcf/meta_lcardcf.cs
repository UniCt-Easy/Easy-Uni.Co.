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
using System.Collections.Generic;
using System.Text;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;
using funzioni_configurazione;

namespace meta_lcardcf {
    public class Meta_lcardcf : Meta_easydata {
        public Meta_lcardcf(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "lcardcf") {
            EditTypes.Add("single");
            ListingTypes.Add("lista");
            Name = "Utente card";
        }

        protected override Form GetForm(string FormName){
            if (FormName == "single"){
                Name = "CF";
                DefaultListType = "lista";
                return GetFormByDllName("lcardcf_single");
            }
            return null;
        }

        public override void CalculateFields(DataRow R, string list_type) {
            if (list_type == "lista") {
                if (!R.Table.DataSet.Tables.Contains("virtualuser")) return;
                DataTable VU = R.Table.DataSet.Tables["virtualuser"];
                DataRow[] f = VU.Select(QHC.CmpEq("cf", R["cf"]));
                if (f.Length > 0) {
                    R["!surname"] = f[0]["surname"];
                    R["!forename"] = f[0]["forename"];
                }
            }
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;

                DescribeAColumn(T, "!forename", "Nome", nPos++);
                DescribeAColumn(T, "!surname", "Cognome", nPos++);
                DescribeAColumn(T, "cf", "C.F.", nPos++);
                ComputeRowsAs(T, "lista");
            }
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            string cf = R["cf"].ToString().Trim();
            if (cf == "") {
                errmess = "Inserire il codice fiscale";
                errfield = "cf";
                return false;
            }
            CalcolaCodiceFiscale.CheckCF(cf, out errmess);
            if (errmess != "") {
                errfield = "cf";
                return false;
            }
            errmess = null;
            return true;
        }


    }
}
