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

ï»¿using System;
using System.Data;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace meta_expensebill {
    /// <summary>
    /// MetaData for spesa
    /// </summary>
    public class Meta_expensebill : Meta_easydata {
        public Meta_expensebill(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "expensebill") {
            Name = "Bolletta";
            EditTypes.Add("default");
            ListingTypes.Add("list");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                DefaultListType = "default";
                return MetaData.GetFormByDllName("expensebill_default");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "ybill", GetSys("esercizio"));
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            return base.Get_New_Row(ParentRow, T);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield))
                return false;
            if ((R["amount"] == DBNull.Value) ||(CfgFn.GetNoNullDecimal(R["amount"])== 0)) {
                errmess = "E' necessario specificare l' importo";
                errfield = "amount";
                return false;
            }

            return true;
        }
        public override void DescribeColumns(DataTable T, string ListingType) {
            base.DescribeColumns(T, ListingType);
            if (ListingType == "list") {
                foreach (DataColumn C in T.Columns) {
                    DescribeAColumn(T, C.ColumnName, "", -1);
                }
                int nPos = 1;
                DescribeAColumn(T, "nbill", "Num.Bolletta", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!anagrafica", "Anagrafica", "bill1.registry", nPos++);
                DescribeAColumn(T, "!data", "Data contabile", "bill1.adate", nPos++);
                DescribeAColumn(T, "!causale", "Causale", "bill1.motive", nPos++);
            }

        }

    }
}