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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;


namespace meta_dalia_position
{
    
    public class Meta_dalia_position : Meta_easydata {
        public Meta_dalia_position(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "dalia_position") {
            ListingTypes.Add("default");
            Name = "Qualifica Dalia";
        }
       


        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "codedaliaposition", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
            }
           
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["iddaliaposition"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);

            return R;
        }
    }
}
