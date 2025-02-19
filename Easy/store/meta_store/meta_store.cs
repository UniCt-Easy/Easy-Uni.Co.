
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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


using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Windows.Forms;

namespace meta_store {

    public class Meta_store : Meta_easydata {

        public Meta_store(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "store") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Magazzino";
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Elenco Magazzini";
                DefaultListType = "default";
                ActAsList();
                SearchEnabled = false;
                return GetFormByDllName("store_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "active", "S");
            SetDefault(PrimaryTable, "virtual", "N");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idstore"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);

            if (listtype == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);

                int nPos = 1;
                DescribeAColumn(T, "idstore", "Codice", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "deliveryaddress", "Indirizzo", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
                DescribeAColumn(T, "virtual", "Virtuale", nPos++);
            }
        }

    }

}

