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

using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;

namespace meta_consipcategory
{
    /// <summary>
    /// Summary description for Meta_casualcontractyear.
    /// </summary>
    public class Meta_consipcategory : Meta_easydata
    {
        public Meta_consipcategory(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "consipcategory")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }

        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Categorie Merceologiche CONSIP";
                return MetaData.GetFormByDllName("consipcategory_default");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");
                DescribeAColumn(T, "idconsipcategory", "Codice");
                DescribeAColumn(T, "description", "Descrizione");
                DescribeAColumn(T, "active", "Attivo");
            }
        }

        public override void SetDefaults(DataTable PrimaryTable){
            SetDefault(PrimaryTable, "active", "S");
           
            base.SetDefaults(PrimaryTable);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T){
            RowChange.MarkAsAutoincrement(T.Columns["idconsipcategory"], null,null, 7);
            return base.Get_New_Row(ParentRow, T);
        }
    }
}