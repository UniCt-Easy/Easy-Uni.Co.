
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using metadatalibrary;
using metaeasylibrary;
using System.Windows.Forms;

namespace meta_attachmentkind
{
    /// <summary>
    /// Summary description for tipooperazioneiva.
    /// </summary>
    public class Meta_attachmentkind :Meta_easydata {
        public Meta_attachmentkind(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "attachmentkind") {
            EditTypes.Add("default");
            ListingTypes.Add("default");

        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Elenco Tipi Documenti allegati";
                DefaultListType = "default";
                return GetFormByDllName("attachmentkind_default");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idattachmentkind", ".#", nPos++);
                DescribeAColumn(T, "title", "Descrizione", nPos++);
                DescribeAColumn(T, "active", "Attivo", nPos++);
            }
        }
        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            MetaData.SetDefault(PrimaryTable, "active", "S");
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idattachmentkind"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idattachmentkind");
            if (N < 9999000)
                R["idattachmentkind"] = 9999001;
            else
                R["idattachmentkind"] = N + 1;

            return R;
        }
    }
}

