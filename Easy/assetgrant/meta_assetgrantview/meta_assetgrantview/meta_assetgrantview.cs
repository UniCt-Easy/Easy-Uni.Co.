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
using metaeasylibrary;
using metadatalibrary;

using System.Windows.Forms;

namespace meta_assetgrantview
{
    public class Meta_assetgrantview : Meta_easydata {

        public Meta_assetgrantview(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "assetgrantview") {
            Name = "Contributi";

            ListingTypes.Add("default");
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);

            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "ygrant", "Anno", nPos++);
                DescribeAColumn(T, "inventory", "Inventario", nPos++);
                DescribeAColumn(T, "ninventory", "Numero Inventario", nPos++);
                DescribeAColumn(T, "idpiece", "Numero parte", nPos++);
                // DescribeAColumn(T, "idgrant", "Numero contributo", nPos++);

                DescribeAColumn(T, "codeinv", "Cod. Class. Inv.", nPos++);
                DescribeAColumn(T, "inventorytree", "Class. Inv.", nPos++);
                //DescribeAColumn(T, "idpiece", "N.parte", nPos++);
                DescribeAColumn(T, "cost", "Costo iniziale cespite", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data del Documento", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "codemotive", "Cod. Causale",  nPos++);
                DescribeAColumn(T, "motive", "Causale", nPos++);
                DescribeAColumn(T, "codeunderwriting", "Cod.Finanziamento", nPos++);
                DescribeAColumn(T, "underwriting", "Finanziamento", nPos++);
                DescribeAColumn(T, "assetacquiretotal", "Costo iniziale cespite collegato", nPos++);
                
            }
        }


    }
}
