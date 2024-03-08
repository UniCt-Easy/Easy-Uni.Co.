
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


namespace meta_taxrateregionbracket
{
    public class Meta_taxrateregionbracket : Meta_easydata
    {
        public Meta_taxrateregionbracket(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :base(Conn, Dispatcher, "taxrateregionbracket")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                Name = "Scaglioni Imposta Regionale";
                return MetaData.GetFormByDllName("taxrateregionbracket_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "");
            DescribeAColumn(T, "nbracket", "Scaglione");
            DescribeAColumn(T, "rate", "Aliquota");
            DescribeAColumn(T, "minamount", "Importo minimo");
            DescribeAColumn(T, "maxamount", "Importo massimo");
            HelpForm.SetFormatForColumn(T.Columns["rate"], "p");
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (R["minamount"] != DBNull.Value && R["maxamount"] != DBNull.Value)
            {
                decimal minAmount = (decimal)R["minamount"];
                decimal maxAmount = (decimal)R["maxamount"];
                if (minAmount > maxAmount)
                {
                    errfield = "maxamount";
                    errmess = "Attenzione! L'importo massimo dello scaglione deve sempre essere maggiore di quello minimo";
                    return false;
                }
            }
            return true;
        }
        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "taxcode");
            RowChange.SetSelector(T, "idregion");
            RowChange.SetSelector(T, "idtaxrateregionstart");
            RowChange.MarkAsAutoincrement(T.Columns["nbracket"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

    }
}
