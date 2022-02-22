
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
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace meta_sdi_rifamm {
    public class Meta_sdi_rifamm : Meta_easydata {
        public Meta_sdi_rifamm(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "sdi_rifamm") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            Name = "Riferimento amministrazione";
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Riferimento amministrazione";
                return GetFormByDllName("sdi_rifamm_default");
            }
            return null;
        }
        public override string GetFilterForSearch(DataTable T) {
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "idsdi_rifamm", "Codice", nPos++);
                DescribeAColumn(T, "nomeufficioricevente", "Ufficio ricevente", nPos++);
                DescribeAColumn(T, "nomeufficio", "Ufficio", nPos++);
                DescribeAColumn(T, "codiceufficio", "Cod.Ufficio", nPos++);
                DescribeAColumn(T, "voceindice", "Voce Indice", nPos++); 
                DescribeAColumn(T, "diritto", "Diritto", nPos++); 
                DescribeAColumn(T, "nomepersona", "Nome persona", nPos++);
               }
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
        }

    }
}
