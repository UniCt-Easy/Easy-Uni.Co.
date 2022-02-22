
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Data;
using metadatalibrary;
using metaeasylibrary;

namespace meta_registryspecialcategory770view {
    public class Meta_registryspecialcategory770view : Meta_easydata {
        public Meta_registryspecialcategory770view(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "registryspecialcategory770view") {
            ListingTypes.Add("default");
            Name = "Categorie particolari";
        }

        public override string GetStaticFilter(string ListingType) {
            string filter;
            if (ListingType == "default") {
                    filter = "(ayear='"+GetSys("esercizio").ToString()+"')";
                return filter;
            }
            return base.GetStaticFilter(ListingType);
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "registry", "Anagrafica", nPos++);
                DescribeAColumn(T, "idspecialcategory770", "#", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "idspecialcategory770", "Codice Categoria particolare", nPos++);
                DescribeAColumn(T, "specialcategory770", "Categoria particolare", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
        }
    }
}

    
