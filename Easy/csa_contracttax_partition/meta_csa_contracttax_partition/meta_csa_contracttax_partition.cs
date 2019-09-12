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
using System.Windows.Forms;
using System.Data;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace meta_csa_contracttax_partition
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_csa_contracttax_partition : Meta_easydata
    {
        public Meta_csa_contracttax_partition(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "csa_contracttax_partition")
        {
            EditTypes.Add("elenco");
            EditTypes.Add("detail");
            ListingTypes.Add("elenco");
            ListingTypes.Add("detail");
        }

        protected override Form GetForm(string FormName)
        {
            if (FormName == "elenco")
            {
                DefaultListType = "elenco"; 
                Name = "Dettaglio Ripartizione Contributi Regola specifica";
                return MetaData.GetFormByDllName("csa_contracttax_partition_elenco");
            }
            if (FormName == "detail")
            {
                Name = "Dettaglio";
                return MetaData.GetFormByDllName("csa_contracttax_partition_detail");
            }
            return null;
        }
        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (CfgFn.GetNoNullDecimal(R["quota"]) == 0) {
                errmess = "Non è stata valorizzata la quota";
                errfield = "quota";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idfin"]) == 0) {
                errmess = "Non è stato valorizzato il capitolo";
                errfield = "idfin";
                return false;
            }
            if (R["idupb"] == DBNull.Value) {
                errmess = "Non è stato valorizzato l'UPB";
                errfield = "idupb";
                return false;
            }
            return true;
        }

        override public DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "ayear");
            RowChange.SetSelector(T, "idcsa_contract");
            RowChange.SetSelector(T, "idcsa_contracttax");
            RowChange.MarkAsAutoincrement(T.Columns["ndetail"], null, null, 6);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;

        }


        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns)
                {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "ndetail", "#Riga", nPos++);
                DescribeAColumn(T, "quota", "Quota", nPos++);
                DescribeAColumn(T, "!phasemovfin", "Fase Mov. Fin.", "expenseview3.phase", nPos++);
                DescribeAColumn(T, "!ymov", "Eserc. Mov. Fin.", "expenseview3.ymov", nPos++);
                DescribeAColumn(T, "!nmov", "Num. Mov. Fin.", "expenseview3.nmov", nPos++);
                DescribeAColumn(T, "!phaseimpbudg", "Fase Imp. Budg.", "epexpview3.phase", nPos++);
                DescribeAColumn(T, "!yepexp", "Eserc. Imp.Budget", "epexpview3.yepexp", nPos++);
                DescribeAColumn(T, "!nepexp", "Num. Imp. Budget", "epexpview3.nepexp", nPos++);
                DescribeAColumn(T, "!codefin", "Cod. Bilancio", "fin2.codefin", nPos++);
                DescribeAColumn(T, "!codeupb", "Cod. UPB", "upb2.codeupb", nPos++);
                DescribeAColumn(T, "!codeacc", "Cod. Conto EP", "account2.codeacc", nPos++);
                DescribeAColumn(T, "!sortcode", "Cod. SIOPE Spesa", "sorting1.sortcode", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["quota"],"p4");
            }
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude)
        {
            if (ListingType == "elenco")
                return base.SelectOne(ListingType, filter, "csa_contracttax_partitionview", Exclude);
            else
                return base.SelectOne(ListingType, filter, "csa_contracttax_partition", Exclude);
        }

    }
}

