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
using System.Collections.Generic;
using System.Text;
using System.Data;
using metadatalibrary;

namespace funzioni_configurazione {
    public class DataTools {
        public static bool MergeRows(DataAccess Conn, DataTable t, string sql) {
            DataTable Data = Conn.SQLRunner(sql, false);
            if (Data.Rows.Count == 0) return true;
            Data.AcceptChanges();

            Data.Namespace = t.Namespace;
            QueryCreator.CheckKey(t, ref Data);
            QueryCreator.MergeDataTable(t, Data);

            return true;
        }

        public static string aliasColumns(DataTable t, string alias) {
            string colList = "";
            foreach (DataColumn c in t.Columns) {
                if (colList != "") colList += ",";
                colList += alias + "." + c.ColumnName;
            }
            return colList;
        }
    }
}
