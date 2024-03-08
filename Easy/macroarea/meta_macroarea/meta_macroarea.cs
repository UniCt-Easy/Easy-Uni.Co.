
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using metadatalibrary;
using System.Windows.Forms;

namespace meta_macroarea{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_macroarea : Meta_easydata{
        public Meta_macroarea(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "macroarea"){
            EditTypes.Add("lista");
            ListingTypes.Add("lista");
            Name = "Macroarea Rimborso forfettario";
        }
        protected override Form GetForm(string FormName){
            if (FormName == "lista"){
                ActAsList();
                return MetaData.GetFormByDllName("macroarea_lista");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string listtype){
            base.DescribeColumns(T, listtype);

            if (listtype == "lista"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idmacroarea", ".#", nPos++);
                DescribeAColumn(T, "codemacroarea", "Macroarea", nPos++);
                DescribeAColumn(T, "amount_1", "Classe 1", nPos++);
                DescribeAColumn(T, "amount_2", "Classe 2", nPos++);
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idmacroarea"], null, null, 7);
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idmacroarea");
            if (N < 9999000)
                R["idmacroarea"] = 9999001;
            else
                R["idmacroarea"] = N + 1;

            return R;
        }
    }
}
