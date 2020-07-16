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

﻿using System;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_ct_asscreddetailview {
    /// <summary>
    /// Summary description for ct_asscreddetailview.
    /// </summary>
    public class Meta_ct_asscreddetailview : Meta_easydata {
        public Meta_ct_asscreddetailview(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "ct_asscreddetailview ") {
            ListingTypes.Add("default");
            Name = "Assegnazione Crediti suille voci di Spesa";
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
	            DescribeAColumn(T, "finincomecode","Codice Bilancio Entrata", nPos++);
	            DescribeAColumn(T, "finincometitle","Bilancio Entrata", nPos++);
	            DescribeAColumn(T, "finexpensecode","Codice Bilancio Spesa", nPos++);
	            DescribeAColumn(T, "finexpensetitle","Bilancio Spesa", nPos++);
	            DescribeAColumn(T, "sortcode","Codice Class.", nPos++);
                DescribeAColumn(T, "sorting", "classificazione.", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"], "p");
                ComputeRowsAs(T, listtype);
            }
        }

        public override string GetStaticFilter(string ListingType) {
            string filteresercizio;
            if (ListingType == "lista") {
                filteresercizio = "(yfinincome='" + GetSys("esercizio").ToString() + "')";
                return filteresercizio;
            }
            return base.GetStaticFilter(ListingType);
        }
    }
}

