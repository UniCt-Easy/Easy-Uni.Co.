/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace meta_stock
{
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class Meta_stock : Meta_easydata
    {
        public Meta_stock(DataAccess Conn, MetaDataDispatcher Dispatcher)
            : base(Conn, Dispatcher, "stock"){
            EditTypes.Add("default");
            ListingTypes.Add("default");
            EditTypes.Add("ddt_in");
            ListingTypes.Add("ddt_in");
        }

        protected override Form GetForm(string FormName){
            DefaultListType = "default";
            if (FormName == "default"){
                Name = "Merce in Magazzino";
                return MetaData.GetFormByDllName("stock_default");
            }
            if (FormName == "ddt_in"){
                Name = "Merce associata alla bolla";
                return MetaData.GetFormByDllName("stock_ddt_in");
            }
            return null;
        }

        public override void SetDefaults(DataTable PrimaryTable){
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "flagto_unload", "N");
            SetDefault(PrimaryTable, "adate", Conn.GetDataContabile());
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T)
        {
            RowChange.MarkAsAutoincrement(T.Columns["idstock"], null, null, 0);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        public override void DescribeColumns(DataTable T, string listtype){
            base.DescribeColumns(T, listtype);
            if (listtype == "ddt_in"){
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                HelpForm.SetFormatForColumn(T.Columns["number"], "n");
                DescribeAColumn(T, "number", "Q.t‡", nPos++);
                DescribeAColumn(T, "!unitacarico", "U.t‡ di misura", "listview.unit", nPos++);
                DescribeAColumn(T, "!list", "Articolo", "listview.description", nPos++);
                //DescribeAColumn(T, "amount", "Costo totale", nPos++);
                DescribeAColumn(T, "expiry", "Scadenza", nPos++);
                DescribeAColumn(T, "!codiceinterno", "Cod.listino", "listview.intcode", nPos++);
            }



        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude){
            return base.SelectOne(ListingType, filter, "stockview", Exclude);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield){
            if (!base.IsValid(R, out errmess, out errfield)) return false;

            if (CfgFn.GetNoNullInt32( R["idstore"])== 0){
                errmess = "Il campo 'Magazzino' Ë obbligatorio";
                errfield = "idstore";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idlist"]) == 0){
                errmess = "Il campo 'Listino' Ë obbligatorio";
                errfield = "idlist";
                return false;
            }
            if (CfgFn.GetNoNullInt32(R["idstoreload_motive"]) == 0) {
                errmess = "Il campo 'Causale di carico' Ë obbligatorio";
                errfield = "idstoreload_motive";
                return false;
            }


            if (CfgFn.GetNoNullDecimal( R["number"]) == 0){
                errmess = "La quantit‡ deve essere maggiore di zero";
                errfield = "number";
                return false;
            }

            //if (CfgFn.GetNoNullDecimal(R["amount"]) == 0){
            //    errmess = "Il Costo deve essere maggiore di zero";
            //    errfield = "amount";
            //    return false;
            //}

            return true;
        }

    }
}


