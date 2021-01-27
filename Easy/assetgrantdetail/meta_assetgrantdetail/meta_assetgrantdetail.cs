
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using System.Collections;
using System.Windows.Forms;

namespace meta_assetgrantdetail
{
    public class Meta_assetgrantdetail :Meta_easydata {
        public Meta_assetgrantdetail(DataAccess Conn, MetaDataDispatcher Dispatcher):
            base(Conn, Dispatcher, "assetgrantdetail") {
            Name = "Risconti applicati";
            EditTypes.Add("detail");
            ListingTypes.Add("detail");

            EditTypes.Add("default");
            ListingTypes.Add("default");
            ListingTypes.Add("collegati");
        }


        public static void SetAutoIncrementProperties(DataTable T, DataAccess Conn) {
            RowChange.SetMySelector(T.Columns["iddetail"], "idasset", 0);
            RowChange.SetMySelector(T.Columns["iddetail"], "idpiece", 0);
            RowChange.SetMySelector(T.Columns["iddetail"], "idgrant", 0);
            RowChange.MarkAsAutoincrement(T.Columns["iddetail"], null, null, 6);
        }


        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            SetAutoIncrementProperties(T, Conn);
            RowChange.setMinimumTempValue(T.Columns["iddetail"], 999900000);
            DataRow R = base.Get_New_Row(ParentRow, T);
            return R;
        }

        protected override Form GetForm(string FormName) {

            if (FormName == "detail") {
                Name = "Risconti applicati";
                return GetFormByDllName("assetgrantdetail_single");
            }

            if (FormName == "default") {
                Name = "Risconti applicati";
                return GetFormByDllName("assetgrantdetail_default");
            }


            return null;
        }


        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);

            SetDefault(PrimaryTable, "ydetail", GetSys("esercizio"));
        }


        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "assetgrantdetailview", ToMerge);

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }



        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);
           
            if (listtype == "detail") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "!Assetgrant", "Descrizione contributo", "assetgrant.description",nPos++);
                DescribeAColumn(T, "ydetail", "Anno risconto", nPos++);
                DescribeAColumn(T, "amount", "Importo risconto", nPos++);
            }

            if (listtype == "collegati") {
                if (listtype == "collegati") {
                    foreach (DataColumn C in T.Columns)
                        DescribeAColumn(T, C.ColumnName, "", -1);
                    int nPos = 1;
                    DescribeAColumn(T, "!ninventario", "N.inventario", "assetview_grantdetail.ninventory", nPos++);
                    DescribeAColumn(T, "idpiece", "Numero parte", nPos++);
                    DescribeAColumn(T, "!inventario", "Inventario", "assetview_grantdetail.inventory", nPos++);
                    DescribeAColumn(T, "!codeinv", "Codice class.", "assetview_grantdetail.codeinv", nPos++);
                    DescribeAColumn(T, "amount", "Importo", nPos++);
                    DescribeAColumn(T, "!cost", "Valore cespite", "assetview_grantdetail.cost",nPos++);
                    DescribeAColumn(T, "description", "Descrizione", nPos++);

                    DescribeAColumn(T, "idgrant", ".idgrant", nPos++);
                  

                    DescribeAColumn(T, "ygrant", "Anno", nPos++);
                    DescribeAColumn(T, "doc", "Documento", nPos++);
                    DescribeAColumn(T, "docdate", "Data del Documento", nPos++);
                    DescribeAColumn(T, "idgrantload", "Chiave Applicazione Risconti", nPos++);
                    DescribeAColumn(T, "!yepacc", "Anno accertamento", "epacc_grantdetail.yepacc", nPos++);
                    DescribeAColumn(T, "!nepacc", "N.accertamento", "epacc_grantdetail.nepacc", nPos++);

                    DescribeAColumn(T, "!inventorytree", "Classificazione", "assetview_grantdetail.inventorytree", nPos++);
                    DescribeAColumn(T, "!inventoryagency", "Ente inventariale", "assetview_grantdetail.inventoryagency", nPos++);
                    //DescribeAColumn(T, "!grantdescription", "Descrizione contributo","assetgrantdetailview.grantdescription", nPos++);


                    FilterRows(T);
                }
            }
        }


        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "collegati") {
                if (R["idgrantload"] == DBNull.Value) return false;
                return true;
            }
            return true;
        }


        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (edit_type == "detail") {
                if (R["amount"] == DBNull.Value) {
                    errmess = "E' necessario specificare l'importo";
                    errfield = "amount";
                    return false;
                }
                if (R["ydetail"] == DBNull.Value) {
                    errmess = "E' necessario specificare l'anno";
                    errfield = "ydetail";
                    return false;
                }
            }
            return true;
        }



    }
}
