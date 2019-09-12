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
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace meta_flowchartuser {
    public class Meta_flowchartuser : Meta_easydata {
        public Meta_flowchartuser(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "flowchartuser") {
            EditTypes.Add("single");
            ListingTypes.Add("lista");
            ListingTypes.Add("default");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            //RowChange.SetSelector(T, "idflowchart");
            RowChange.SetSelector(T, "idcustomuser");
            RowChange.setMinimumTempValue(T.Columns["ndetail"], 999000);
            RowChange.MarkAsAutoincrement(T.Columns["ndetail"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }

        protected override System.Windows.Forms.Form GetForm(string EditType) {
            if (EditType == "single") {
                DefaultListType = "lista";
                Name = "Associazione Utente - Organigramma";
                return GetFormByDllName("flowchartuser_single");
            }
            if (EditType == "default") {
                DefaultListType = "default";
                Name = "Associazione Utente - Organigramma";
                return GetFormByDllName("flowchartuser_default");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "lista") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "idcustomuser", "ID Utente", nPos++);
                DescribeAColumn(T, "!username", "Utente", "customuser.username", nPos++);
                DescribeAColumn(T, "title", "Ruolo", nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "flagdefault", "Nodo di default", nPos++);
                if (Conn.GetSys("idsortingkind01") != DBNull.Value) {
                    DescribeAColumn(T, "!sorting01", Conn.GetSys("titlesortingkind01").ToString(), "sorting01.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind02") != DBNull.Value) {
                    DescribeAColumn(T, "!sorting02", Conn.GetSys("titlesortingkind02").ToString(), "sorting02.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind03") != DBNull.Value) {
                    DescribeAColumn(T, "!sorting03", Conn.GetSys("titlesortingkind03").ToString(), "sorting03.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind04") != DBNull.Value) {
                    DescribeAColumn(T, "!sorting04", Conn.GetSys("titlesortingkind04").ToString(), "sorting04.sortcode", nPos++);
                }
                if (Conn.GetSys("idsortingkind05") != DBNull.Value) {
                    DescribeAColumn(T, "!sorting05", Conn.GetSys("titlesortingkind05").ToString(), "sorting05.sortcode", nPos++);
                }
            }
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }

                int nPos = 1;
                DescribeAColumn(T, "idcustomuser", "ID Utente", nPos++);
                DescribeAColumn(T, "title", "Ruolo",nPos++);
                DescribeAColumn(T, "start", "Data Inizio", nPos++);
                DescribeAColumn(T, "stop", "Data Fine", nPos++);
                DescribeAColumn(T, "flagdefault", "Nodo di default", nPos++);
            }
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "flowchartuserview", ToMerge);
            }
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["start"] == DBNull.Value) {
                errmess = "Bisogna specificare la data di inizio";
                errfield = "start";
                return false;
            }
            return true;
        }
    }
}