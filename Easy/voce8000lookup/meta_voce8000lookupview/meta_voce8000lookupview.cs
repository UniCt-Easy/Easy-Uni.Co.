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
using metaeasylibrary;
using metadatalibrary;
using System.Data;

namespace meta_voce8000lookupview 
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_voce8000lookupview  : Meta_easydata {
        public Meta_voce8000lookupview (DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "voce8000lookupview ") {
            Name = "Associazione voce 8000 - Imposta";
            ListingTypes.Add("default");
        }

        //public override string GetStaticFilter(string ListingType) {
        //    string filteresercizio;
        //    if (ListingType == "default") {
        //        filteresercizio = "(ayear='" + GetSys("esercizio").ToString() + "')";
        //        return filteresercizio;
        //    }
        //    return base.GetStaticFilter(ListingType);
        //}


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "servicekind", "Tipo compenso", nPos++);
                DescribeAColumn(T, "conto", "Applicazione", nPos++);
                DescribeAColumn(T, "voce", "Cod.voce 8000", nPos++);
                DescribeAColumn(T, "voce8000", "Voce 8000", nPos++);
                DescribeAColumn(T, "voceimponibile", "Cod. voce Imponibile", nPos++);
                DescribeAColumn(T, "voce8000imponibile", "Voce Imponibile", nPos++);
                DescribeAColumn(T, "vocequotaesente", "Cod. Voce Quota Esente", nPos++);
                DescribeAColumn(T, "voce8000quotaesente", "Voce Quota Esente", nPos++);
                DescribeAColumn(T, "tax", "Imposta", nPos++);
                DescribeAColumn(T, "taxref", "Cod.Imposta", nPos++);

            }
        }

    }
}


