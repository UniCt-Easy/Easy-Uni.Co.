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

ï»¿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using metadatalibrary;
using metaeasylibrary;

namespace meta_uniqueregister//meta_uniqueregister//
{
    /// <summary>
    /// Summary description for Meta_uniqueregister.
    /// </summary>
    public class Meta_uniqueregister : Meta_easydata {

        public Meta_uniqueregister(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "uniqueregister") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }


        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["iduniqueregister"], null, null, 6);
            return base.Get_New_Row(ParentRow, T);
        }



    }
}

