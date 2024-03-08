
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

namespace meta_taxratebracket
{
    public class Meta_taxratebracket : Meta_easydata
    {
        public Meta_taxratebracket(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :base(Conn, Dispatcher, "taxratebracket")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
        }
        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")
            {
                Name = "Scaglioni Imposta";
                return MetaData.GetFormByDllName("taxratebracket_default");
            }
            return null;
        }
        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            foreach (DataColumn C in T.Columns)
                DescribeAColumn(T, C.ColumnName, "");
            //DescribeAColumn(T, "taxcode", "Cod. ritenuta");
            //DescribeAColumn(T, "!start", "Data inizio", "taxratestart.start");
            //DescribeAColumn(T, "nbracket", "Numero scaglione");
            DescribeAColumn(T, "minamount", "Importo minimo");
            DescribeAColumn(T, "maxamount", "Importo massimo");
            DescribeAColumn(T, "adminrate", "Aliquota ammin.");
            DescribeAColumn(T, "employrate", "Aliquota percip.");
            DescribeAColumn(T, "adminnumerator", "Num.Amm.");
            DescribeAColumn(T, "admindenominator", "Den.Amm.");
            DescribeAColumn(T, "employnumerator", "Num.Perc.");
            DescribeAColumn(T, "employdenominator", "Den.perc.");
            HelpForm.SetFormatForColumn(T.Columns["adminrate"], "p");
            HelpForm.SetFormatForColumn(T.Columns["employrate"], "p");
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield)
        {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            /*if (R["nbracket"].ToString() == "0")
            {
                errfield = null;
                errmess = "Non è possibile definire più volte uno scaglione\n" +
                    "sulla stessa data inizio aliquota.";
                return false;
            }*/
            decimal minamount = CfgFn.GetNoNullDecimal(R["minamount"]);
            decimal maxamount = CfgFn.GetNoNullDecimal(R["maxamount"]);
            decimal adminnumerator = CfgFn.GetNoNullDecimal(R["adminnumerator"]);
            decimal admindenominator = CfgFn.GetNoNullDecimal(R["admindenominator"]);
            decimal employnumerator = CfgFn.GetNoNullDecimal(R["employnumerator"]);
            decimal employdenominator = CfgFn.GetNoNullDecimal(R["employdenominator"]);
            if (minamount < 0) {
                errfield = "minamount";
                errmess = "Attenzione! L'importo minimo dello scaglione deve essere maggiore di 0";
                return false;
            }
            if (maxamount < minamount)
            {
                errfield = "maxamount";
                errmess = "Attenzione! L'importo massimo dello scaglione deve sempre essere maggiore di quello minimo";
                return false;
            }
            if (admindenominator < 0) {
                errfield = "admindenominator";
                errmess = "Attenzione! Il denominatore deve essere maggiore di 0";
                return false;
            }
            if (employdenominator < 0) {
                errfield = "employdenominator";
                errmess = "Attenzione! Il denominatore deve essere maggiore di 0";
                return false;
            }
            if ((adminnumerator<0) || (adminnumerator > admindenominator)) {
                errfield = "adminnumerator";
                errmess = "Attenzione! Il numeratore deve essere maggiore di 0 e minore o uguale al denominatore";
                return false;
            }
            if ((employnumerator<0) || (employnumerator > employdenominator)) {
                errfield = "employnumerator";
                errmess = "Attenzione! Il numeratore deve essere maggiore di 0 e minore o uguale al denominatore";
                return false;
            }
            return true;
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "taxcode");
            RowChange.SetSelector(T, "idtaxratestart");
            RowChange.MarkAsAutoincrement(T.Columns["nbracket"], null,
                null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

    }
}
