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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace meta_inventoryview//meta_inventario//
{
    /// <summary>
    /// Summary description for inventario.
    /// </summary>
    public class Meta_inventoryview : Meta_easydata {
        public Meta_inventoryview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "inventoryview") {
            ListingTypes.Add("default");
        }
        private string[] mykey = new string[] { "idinventory" };
        public override string[] primaryKey() {
            return mykey;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idinventory", ".#", nPos++);
                DescribeAColumn(T, "codeinventory", "Codice", nPos++);
                DescribeAColumn(T, "description", "Denominazione", nPos++);
                DescribeAColumn(T, "inventoryagency", "Ente", nPos++);
                DescribeAColumn(T, "inventorykind", "Tipo",  nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
            }
        }

       
    }
}