/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_registrycf {
    public class Meta_registrycf : Meta_easydata {
        public Meta_registrycf(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "registrycf") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("unione");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Storicizzazione Codice Fiscale";
                DefaultListType = "default";
                return GetFormByDllName("registrycf_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "stop", Conn.GetSys("datacontabile"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistrycf"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            // Se il codice fiscale è un aziendale non ci sono controlli da fare sulla validità dello stesso
            if (R["cf"].ToString().Length == 11) {
                return true;
            }
            CalcolaCodiceFiscale.CheckCF(R["cf"].ToString(), out errmess);
            if (errmess != "") {
                errfield = "cf";
                return false;
            }

            return true;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "cf", "Codice Fiscale", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
            }
            if (ListingType == "unione") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "!kk", ".aaaa", nPos++);
                DescribeAColumn(T, "idreg", "#", nPos++);
                DescribeAColumn(T, "cf", "Codice Fiscale", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "lt", "Data ultima mod.", nPos++);
            }



        }
    }
}
