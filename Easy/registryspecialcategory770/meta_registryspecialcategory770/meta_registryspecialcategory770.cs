
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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using System.Text.RegularExpressions;

namespace meta_registryspecialcategory770{

    public class Meta_registryspecialcategory770 : Meta_easydata {
        public Meta_registryspecialcategory770(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "registryspecialcategory770") {
            EditTypes.Add("default");
            EditTypes.Add("detail");
            ListingTypes.Add("default");
            Name = "Categorie particolari";
        }
        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                Name = "Categorie particolari";
                return MetaData.GetFormByDllName("registryspecialcategory770_default");
            }
            if (FormName == "detail") {
                Name = "Categorie particolari";
                DefaultListType = "detail";
                return MetaData.GetFormByDllName("registryspecialcategory770_detail");
            }
            return null;

        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            int esercizio = Convert.ToInt32(GetSys("esercizio"));
            SetDefault(PrimaryTable, "ayear", esercizio);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            
            RowChange.SetSelector(T, "idreg");
            RowChange.MarkAsAutoincrement(T.Columns["idregistryspecialcategory770"], null, null, 0);
            return base.Get_New_Row(ParentRow, T);

       }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default") {
                return base.SelectOne(ListingType, filter, "registryspecialcategory770view", ToMerge);
            }

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;

            return true;
        }


        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "idspecialcategory770", "Codice Categoria particolare", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
            if (ListingType == "detail") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "idspecialcategory770", "#", nPos++);
                DescribeAColumn(T, "ayear", "Esercizio", nPos++);
                DescribeAColumn(T, "idspecialcategory770", "Codice Categoria particolare", nPos++);
                DescribeAColumn(T, "!specialcategory770", "Categoria particolare", "specialcategory770.description", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
            }
        }


    }


}

