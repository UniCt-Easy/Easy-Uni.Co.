
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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

namespace meta_mandatekindattachmentkind
{
    /// <summary>
    /// Summary description for tiporegistroiva.
    /// </summary>
    public class Meta_mandatekindattachmentkind :Meta_easydata {
        public Meta_mandatekindattachmentkind(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "mandatekindattachmentkind") {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Tipo documento allegato ";
                return MetaData.GetFormByDllName("mandatekindattachmentkind_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable T) {
            if (T.Columns.Contains("mandatory"))
                MetaData.SetDefault(T, "mandatory", "S");
            base.SetDefaults(T);
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);

            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "idattachmentkind", "Codice tipo documento", nPos++);
                DescribeAColumn(T, "!attachmentkinddesc", "Tipo documento allegato", "attachmentkind.title", nPos++);
                DescribeAColumn(T, "mandatory", "Obbligatorio", nPos++); 
            }
        }

    }
}
