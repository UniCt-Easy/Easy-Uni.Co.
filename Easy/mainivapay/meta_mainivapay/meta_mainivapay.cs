
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

namespace meta_mainivapay{
    /// <summary>
    /// </summary>
    public class Meta_mainivapay : Meta_easydata
    {
        public Meta_mainivapay(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "mainivapay")
        {
            EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("wizard_calcolo_consolida");
            Name = "Liquidazione IVA Consolidata";
        }

        protected override Form GetForm(string FormName)
        {
            if (FormName == "default")  {
                // Form DA FARE
                Name = "Liquidazione periodica Consolidata";
                DefaultListType = "default";
                this.CanInsert = false;
                this.CanInsertCopy = false;

                return GetFormByDllName("mainivapay_default");
            }
            if (FormName == "wizard_calcolo_consolida")
            {
                Name = "Calcola liquidazione corrente";
                return GetFormByDllName("mainivapay_wizard_calcolo_consolida");
            }
            return null;
        }

        public override void DescribeColumns(DataTable T, string ListingType)
        {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "default")
            {
                foreach (DataColumn C in T.Columns) DescribeAColumn(T, C.ColumnName, "");

                DescribeAColumn(T, "ymainivapay", "Esercizio");
                DescribeAColumn(T, "nmainivapay", "Numero");
                DescribeAColumn(T, "paymentkind", "Tipo");
                DescribeAColumn(T, "nmonth", "Mese");
                DescribeAColumn(T, "referenceyear", "Eserc.di riferimento");
                DescribeAColumn(T, "creditamount", "Importo credito");
                DescribeAColumn(T, "debitamount", "Importo debito");
                DescribeAColumn(T, "refundamount", "Importo rimborso");
                DescribeAColumn(T, "paymentamount", "Importo versamento");
                DescribeAColumn(T, "prorata", "% detraibilità");
                DescribeAColumn(T, "mixed", "% promiscuità");
                DescribeAColumn(T, "paymentdetails", "Estremi versamento");
                DescribeAColumn(T, "datemainivapay", "Data liquidazione");
                DescribeAColumn(T, "assesmentdate", "Data regolamento");
                HelpForm.SetFormatForColumn(T.Columns["prorata"], "p");
                HelpForm.SetFormatForColumn(T.Columns["mixed"], "p");
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.SetSelector(T, "ymainivapay");
            RowChange.MarkAsAutoincrement(T.Columns["nmainivapay"], null, null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        public override void SetDefaults(DataTable PrimaryTable)
        {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ymainivapay", Conn.GetEsercizio());
            SetDefault(PrimaryTable, "datemainivapay", Conn.GetDataContabile());
        }
    }
}
