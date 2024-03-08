
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
using metaeasylibrary;
using metadatalibrary;
using System.Collections;
using System.Windows.Forms;

namespace meta_assetgrant {
    public class Meta_assetgrant :Meta_easydata {

        public Meta_assetgrant(DataAccess Conn, MetaDataDispatcher Dispatcher) :
            base(Conn, Dispatcher, "assetgrant") {

            Name = "Contributi in conto impianti associati al cespite";
            EditTypes.Add("single");
            ListingTypes.Add("single");
            ListingTypes.Add("default");
            ListingTypes.Add("collegati");
        }

        public static void SetAutoIncrementProperties(DataTable T, DataAccess Conn) {
            RowChange.MarkAsAutoincrement(T.Columns["idgrant"], null, null, 0);             
            RowChange.SetMySelector(T.Columns["idasset"], "idgrant", 0);                    // con idasset selettore per idgrant incrementale
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.SetSelector(T, "idasset");
            RowChange.SetSelector(T, "idpiece", 0);
            RowChange.MarkAsAutoincrement(T.Columns["idgrant"], null, null, 7);
            return base.Get_New_Row(ParentRow, T);
        }

        /// <summary>
        /// Apre la form singola
        /// </summary>
        /// <param name="FormName"></param>
        /// <returns></returns>
        protected override Form GetForm(string FormName) {

            if (FormName == "single") {
                Name = "Contributi in conto impianti associati al cespite";
                return MetaData.GetFormByDllName("assetgrant_single");
            }
            if (FormName == "default") {
                Name= "Finanziamento su cespite";
                return MetaData.GetFormByDllName("assetgrant_default");
            }
            

            return null;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "assetgrantview", ToMerge);

            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);

            SetDefault(PrimaryTable, "ygrant", GetSys("esercizio"));
            SetDefault(PrimaryTable, "flag_entryprofitreservedone", "N");
           
        }


        public override void DescribeColumns(DataTable T, string listtype) {
            base.DescribeColumns(T, listtype);

            if (listtype == "single") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;

                DescribeAColumn(T, "ygrant", "Anno", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!inventario", "Inventario", "assetview_grant.inventory", nPos++);
                DescribeAColumn(T, "!ninventario", "N.inventario", "assetview_grant.ninventory", nPos++);
                DescribeAColumn(T, "idasset", "Numero cespite", nPos++);
                DescribeAColumn(T, "idpiece", "Numero parte", nPos++);
                DescribeAColumn(T, "!codeinv", "Cod. Class. Inv.", "assetview_grant.codeinv", nPos++);
                DescribeAColumn(T, "!inventorytree", "Class. Inv.", "assetview_grant.inventorytree", nPos++);
                DescribeAColumn(T, "!inventoryagency", "Ente inventariale", "assetview_grant.inventoryagency", nPos++);
                DescribeAColumn(T, "idgrant", "Numero contributo", nPos++);
                DescribeAColumn(T, "flag_financesource", "Tipo finanziamento", nPos++);
                DescribeAColumn(T, "description", "Descrizione contributo", nPos++);
                //DescribeAColumn(T, "doc", "Documento", nPos++);
                //DescribeAColumn(T, "docdate", "Data del Documento", nPos++);
                //DescribeAColumn(T, "description", "Descrizione", nPos++);

                //DescribeAColumn(T, "idasset", ".#", nPos++);
                //DescribeAColumn(T, "!codemotive", "Cod.Causale Ricavo", "accmotive.codemotive", nPos++);
                //DescribeAColumn(T, "!titlemotive", "Causale Ricavo", "accmotive.title", nPos++);
                //DescribeAColumn(T, "!codeunderwriting", "Cod.Finanziamento", "underwriting.codeunderwriting", nPos++);
                //DescribeAColumn(T, "!titleunderwriting", "Finanziamento", "underwriting.title", nPos++);

            }

            if (listtype == "collegati") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int nPos = 1;
                DescribeAColumn(T, "!ninventario", "N.inventario", "assetview_grant.ninventory", nPos++);
                DescribeAColumn(T, "idpiece", "Numero parte", nPos++);
                DescribeAColumn(T, "!inventario", "Inventario", "assetview_grant.inventory", nPos++);
                DescribeAColumn(T, "!codeinv", "Codice class.", "assetview_grant.codeinv", nPos++);
                DescribeAColumn(T, "amount", "Importo", nPos++);
                DescribeAColumn(T, "!cost", "Valore cespite", "assetview_grant.cost",nPos++);

                DescribeAColumn(T, "description", "Descrizione", nPos++);

                DescribeAColumn(T, "idgrant", ".idgrant", nPos++);
                DescribeAColumn(T, "!codemotive", "Cod.Causale Ricavo", "accmotive.codemotive", nPos++);
                DescribeAColumn(T, "!titlemotive", "Causale Ricavo", "accmotive.title", nPos++);
                DescribeAColumn(T, "!codeunderwriting", "Cod.Finanziamento", "underwriting.codeunderwriting", nPos++);
                DescribeAColumn(T, "!titleunderwriting", "Finanziamento.", "underwriting.title", nPos++);
                DescribeAColumn(T, "ygrant", "Anno", nPos++);
                DescribeAColumn(T, "doc", "Documento", nPos++);
                DescribeAColumn(T, "docdate", "Data del Documento", nPos++);
                DescribeAColumn(T, "idgrantload", "Chiave Applicazione Risconti", nPos++);
                DescribeAColumn(T, "!yepacc", "Anno accertamento", "epacc_grantdetail.yepacc", nPos++);
                DescribeAColumn(T, "!nepacc", "N.accertamento", "epacc_grantdetail.nepacc", nPos++);
                DescribeAColumn(T, "!inventorytree", "Classificazione", "assetview_grant.inventorytree", nPos++);
                DescribeAColumn(T, "!inventoryagency", "Ente inventariale", "assetview_grant.inventoryagency", nPos++);

                FilterRows(T);
            }
        }


        public override bool FilterRow(DataRow R, string list_type) {
            if (list_type == "collegati") {
                if (R["idgrantload"] == DBNull.Value) return false;
                //if((R["flag_financesource"].ToString()=="U") && (R["flag_entryprofitreservedone"].ToString()=="S")) return false;
                return true;
            }
            return true;
        }



        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            if (edit_type == "single") {
                if (R["amount"] == DBNull.Value) {
                    errmess = "E' necessario specificare l'importo";
                    errfield = "amount";
                    return false;
                }
                if (R["ygrant"] == DBNull.Value) {
                    errmess = "E' necessario specificare l'anno";
                    errfield = "ygrant";
                    return false;
                }
                if (R["flag_financesource"] == DBNull.Value) {
                    errmess = "E' necessario specificare il Tipo Finanziamento";
                    errfield = "flag_financesource";
                    return false;
                }
            }
            return true;
        }



            //protected override Form GetForm(string FormName) {

            //    if (FormName == "default") {
            //        Name = "Risconti applicati";
            //        DefaultListType = "default";
            //        return GetFormByDllName("asset_dettaglio");
            //    }

            //    return null;
            //}

        }

}
