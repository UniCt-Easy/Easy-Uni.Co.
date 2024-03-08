
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_taxratestart
{
    public class Meta_taxratestart : Meta_easydata
    {
        public Meta_taxratestart(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "taxratestart")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                DefaultListType = "default";
                Name = "Struttura Imposta";
                return MetaData.GetFormByDllName("taxratestart_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "");
            DescribeAColumn(T, "taxcode", "Cod. Imposta");
            DescribeAColumn(T, "start", "Data decorrenza");
            DescribeAColumn(T, "enforcement", "Tipo applicazione");
            DescribeAColumn(T, "taxablenumerator", "Num.Impon.");
            DescribeAColumn(T, "taxabledenominator", "Den.Impon.");
        }

        public override DataRow SelectOne (string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "taxratestartview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "taxcode");
            RowChange.MarkAsAutoincrement(T.Columns["idtaxratestart"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            decimal taxablenumerator = CfgFn.GetNoNullDecimal(R["taxablenumerator"]);
            decimal taxabledenominator = CfgFn.GetNoNullDecimal(R["taxabledenominator"]);
            if (taxabledenominator <= 0) {
                errfield = "taxabledenominator";
                errmess = "Attenzione! Il denominatore deve essere maggiore di 0";
                return false;
            }
            if ((taxablenumerator <= 0) || (taxablenumerator > taxabledenominator)) {
                errfield = "taxablenumerator";
                errmess = "Attenzione! Il numeratore deve essere maggiore di 0 e minore o uguale al denominatore";
                return false;
            }
            return true;
        }
    }
}
