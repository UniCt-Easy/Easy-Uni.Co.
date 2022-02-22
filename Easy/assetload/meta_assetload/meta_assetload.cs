
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
//Pino: using buonocaricoinventario; diventato inutile
//Pino: using buonocaricoinv_gen_auto; diventato inutile
using funzioni_configurazione;//funzioni_configurazione

namespace meta_assetload//meta_buonocaricoinventario//
{
    /// <summary>
    /// Summary description for buonocaricoinventario.
    /// </summary>
    public class Meta_assetload : Meta_easydata {
        public Meta_assetload(DataAccess Conn, MetaDataDispatcher Dispatcher)
            :
            base(Conn, Dispatcher, "assetload") {
            EditTypes.Add("default");
            EditTypes.Add("storico");
            ListingTypes.Add("default");
            EditTypes.Add("generazioneautomatica");
        }

        protected override Form GetForm(string FormName) {
            if (FormName == "default") {
                Name = "Buono di carico";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("assetload_default");
            }
            if (FormName == "storico") {
                Name = "Buono di carico";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("assetload_storico");
            }
            if (FormName == "generazioneautomatica") {
                Name = "Generazione automatica";
                DefaultListType = "default";
                return MetaData.GetFormByDllName("assetload_generazioneautomatica");
            }
            return null;
        }

        public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
            if (ListingType == "default")
                return base.SelectOne(ListingType, filter, "assetloadview", ToMerge);
            return base.SelectOne(ListingType, filter, searchtable, ToMerge);
        }

        public override void SetDefaults(DataTable PrimaryTable) {
            base.SetDefaults(PrimaryTable);
            SetDefault(PrimaryTable, "yassetload", GetSys("esercizio"));
            SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
            SetDefault(PrimaryTable, "ratificationdate", GetSys("datacontabile")); 
        }


        protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            //if ((C.ColumnName=="idassetloadkind") || (C.ColumnName == "yassetload")||(C.ColumnName == "nassetload"))return;
            if (C.ColumnName == "transmitted") return;
            base.InsertCopyColumn(C, Source, Dest);
        }

        public override bool IsValid(DataRow R, out string errmess, out string errfield) {
            // Bisogna innanzitutto chiamare IsValid della classe base
            if (!base.IsValid(R, out errmess, out errfield)) return false;
            
            if (CfgFn.GetNoNullInt32(R["idassetloadkind"]) == 0) {
                errmess = "E' necessario specificare il tipo di buono di carico.";
                errfield = "idassetloadkind";
                return false;
            }

            if ((R["adate"]) == DBNull.Value) {
                errmess = "E' necessario specificare una data contabile.";
                errfield = "adate";
                return false;
            }

            DataRow currConfAsset = R.Table.DataSet.Tables["config"].Rows[0];
            if (currConfAsset == null) return false;
            byte assetload_flag = (byte)currConfAsset["assetload_flag"];
            if ((assetload_flag & 2) == 2) {
                if ((R["idmot"]) == DBNull.Value) {
                    errmess = "E' necessario specificare una causale.";
                    errfield = "idmot";
                    return false;
                }
            }

            if ((assetload_flag & 1) == 1) {
                if ((R["idreg"]) == DBNull.Value) {
                    if (!showClientMsg("Non è stato specificato il cedente. Proseguo lo stesso?", "Avviso", MessageBoxButtons.YesNo) ) {
                        errmess = "E' necessario specificare il cedente.";
                        errfield = "idreg";
                        return false;
                    }
                }
            }

            return true;
        }


        private static int GetMax(string sql_carico, string sql_scarico, DataAccess Conn) {
            int max_carico = 0;
            int max_scarico = 0;
            int max_carico_scarico = 0;

            DataTable T1 = Conn.SQLRunner(sql_carico, true);
            if (T1 == null || T1.Rows.Count == 0)
                max_carico = 1;
            else
                max_carico = Convert.ToInt32(T1.Rows[0][0]);
            max_carico_scarico = max_carico;

            DataTable T2 = Conn.SQLRunner(sql_scarico, true);
            if (T2 == null || T2.Rows.Count == 0)
                max_scarico = 1;
            else
                max_scarico = Convert.ToInt32(T2.Rows[0][0]);
            if (max_scarico > max_carico_scarico) max_carico_scarico = max_scarico;

            return max_carico_scarico;
        }

        /// <summary>
        /// Metodo per la numerazione personalizzata
        /// </summary>
        /// <returns></returns>
        private static object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
            object esercizio = R["yassetload"];
            QueryHelper QHS;
            QHS = Conn.GetQueryHelper();
            string filter_patri = QHS.CmpEq("ayear", esercizio);
            //ricavo configurazione patrimonio
            DataTable t = Conn.RUN_SELECT("config", "*", null, filter_patri, null, false);
            if (t == null || t.Rows.Count == 0) return null;
            string tiponumerazione = t.Rows[0]["asset_flagnumbering"].ToString().ToUpper();
            string flagreset = t.Rows[0]["asset_flagrestart"].ToString().ToUpper();

            string filter_esercbuonocarico = QHS.CmpEq("b.yassetload", esercizio);
            string filter_codicetipobuonocarico = QHS.CmpEq("b.idassetloadkind", R["idassetloadkind"]);

            string filter_esercbuonoscarico = QHS.CmpEq("b.yassetunload", esercizio);

            string sql_select1, sql_select2;
            string sql_from1, sql_from2;
            string sql_where1, sql_where2;
            string sql1 = "", sql2 = "";

            //ricavo configurazione del codice tipo buono
            DataRow Rtipobuono = R.GetParentRow("assetloadkindassetload");
            //ricavo info inventario
            string filter_inventario = QHS.CmpEq("idinventory", Rtipobuono["idinventory"]);
            DataTable Tinv = Conn.RUN_SELECT("inventory", "*", null, filter_inventario, null, false);

            switch (tiponumerazione.ToUpper()) {
                case "U":
                    //numerazione unica

                    if (flagreset == "N") {
                        filter_esercbuonocarico = "";
                        filter_esercbuonoscarico = "";
                    }

                    sql_select1 = "SELECT ISNULL(MAX(b.nassetload),0) + 1 ";
                    sql_from1 = "FROM assetload b ";
                    if (filter_esercbuonocarico != "")
                        sql_where1 = "WHERE " + filter_esercbuonocarico;
                    else
                        sql_where1 = "";
                    sql1 = sql_select1 + sql_from1 + sql_where1;

                    sql_select2 = "SELECT ISNULL(MAX(b.nassetunload),0) + 1 ";
                    sql_from2 = "FROM assetunload b ";

                    if (filter_esercbuonoscarico != "")
                        sql_where2 = "WHERE " + filter_esercbuonoscarico;
                    else
                        sql_where2 = "";
                    sql2 = sql_select2 + sql_from2 + sql_where2;
                    return GetMax(sql1, sql2, Conn);

                case "T":
                    //per tipo inventario

                    if (flagreset == "N") {
                        filter_esercbuonocarico = "";
                        filter_esercbuonoscarico = "";
                    }


                    string filter_tipoinventario = QHS.CmpEq("i.idinventorykind", Tinv.Rows[0]["idinventorykind"]);
                    sql_select1 = "SELECT ISNULL(MAX(b.nassetload),0) + 1 ";
                    sql_from1 = "FROM assetload b INNER JOIN assetloadkind t on b.idassetloadkind=t.idassetloadkind " +
                        "INNER JOIN inventory i ON t.idinventory=i.idinventory " +
                        "INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";
                    sql_where1 = "WHERE " + GetData.MergeFilters(filter_esercbuonocarico, filter_tipoinventario);
                    sql1 = sql_select1 + sql_from1 + sql_where1;


                    sql_select2 = "SELECT ISNULL(MAX(b.nassetunload),0) + 1 ";
                    sql_from2 = "FROM assetunload b INNER JOIN assetunloadkind t on b.idassetunloadkind=t.idassetunloadkind " +
                        "INNER JOIN inventory i ON t.idinventory=i.idinventory " +
                        "INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";

                    sql_where2 = "WHERE " + GetData.MergeFilters(filter_esercbuonoscarico, filter_tipoinventario);
                    sql2 = sql_select2 + sql_from2 + sql_where2;
                    return GetMax(sql1, sql2, Conn);

                case "E":
                    //per ente inventariale

                    if (flagreset == "N") {
                        filter_esercbuonocarico = "";
                        filter_esercbuonoscarico = "";
                    }


                    string filter_ente = QHS.CmpEq("i.idinventoryagency", Tinv.Rows[0]["idinventoryagency"]);
                    sql_select1 = "SELECT ISNULL(MAX(b.nassetload),0) + 1 ";
                    sql_from1 = "FROM assetload b INNER JOIN assetloadkind t on b.idassetloadkind=t.idassetloadkind " +
                        "INNER JOIN inventory i ON t.idinventory=i.idinventory " +
                        "INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";
                    sql_where1 = "WHERE " + GetData.MergeFilters(filter_esercbuonocarico, filter_ente);
                    sql1 = sql_select1 + sql_from1 + sql_where1;

                    sql_select2 = "SELECT ISNULL(MAX(b.nassetunload),0) + 1 ";
                    sql_from2 = "FROM assetunload b INNER JOIN assetunloadkind t on b.idassetunloadkind=t.idassetunloadkind " +
                        "INNER JOIN inventory i ON t.idinventory=i.idinventory " +
                        "INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";
                    sql_where2 = "WHERE " + GetData.MergeFilters(filter_esercbuonoscarico, filter_ente);
                    sql2 = sql_select2 + sql_from2 + sql_where2;
                    return GetMax(sql1, sql2, Conn);

                case "K":
                    //per ente inventariale suddiviso per buono carico e buono scarico

                    if (flagreset == "N") {
                        filter_esercbuonocarico = "";
                    }

                    filter_ente = QHS.CmpEq("i.idinventoryagency", Tinv.Rows[0]["idinventoryagency"]);
                    sql_select1 = "SELECT ISNULL(MAX(b.nassetload),0) + 1 ";
                    sql_from1 = "FROM assetload b INNER JOIN assetloadkind t on b.idassetloadkind=t.idassetloadkind " +
                        "INNER JOIN inventory i ON t.idinventory=i.idinventory " +
                        "INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";
                    sql_where1 = "WHERE " + GetData.MergeFilters(filter_esercbuonocarico, filter_ente);
                    sql1 = sql_select1 + sql_from1 + sql_where1;
                    DataTable tLoad = Conn.SQLRunner(sql1, true);
                    if (tLoad == null || tLoad.Rows.Count == 0) {
                        return 0;
                    }
                    return tLoad.Rows[0][0];

                case "B":
                default:
                    //per tipo buono

                    bool numassoluta = CfgFn.DecodeToBool(Rtipobuono["flag"], 1);

                    int value_if_null = 0;
                    int numiniziale = CfgFn.GetNoNullInt32(Rtipobuono["startnumber"]);
                    value_if_null = numiniziale - 1;
                    if (value_if_null < 0) value_if_null = 0;
                    sql_select1 = "SELECT ISNULL(MAX(b.nassetload)," + value_if_null.ToString() + ") + 1 ";
                    sql_from1 = "FROM assetload b ";
                    sql_where1 = "WHERE " + filter_codicetipobuonocarico;
                    if (!numassoluta) sql_where1 += " AND " + filter_esercbuonocarico;
                    sql1 = sql_select1 + sql_from1 + sql_where1;
                    DataTable T1 = Conn.SQLRunner(sql1, true);
                    if (T1 == null || T1.Rows.Count == 0) {
                        if (!numassoluta) return value_if_null + 1;
                        return 1;
                    }
                    return T1.Rows[0][0];
                //default:
                //    QueryCreator.MarkEvent("meta_assetload.CalcID(): tiponumerazione non definita");
                //    return null;
            }
        }

        public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
            RowChange.MarkAsAutoincrement(T.Columns["idassetload"], null, null, 7);
            RowChange.MarkAsAutoincrement(T.Columns["nassetload"], null, null, 7);
            RowChange.MarkAsCustomAutoincrement(T.Columns["nassetload"], new RowChange.CustomCalcAutoID(CalcID));
            DataRow R = base.Get_New_Row(ParentRow, T);
            int N = MetaData.MaxFromColumn(T, "idassetload");
            if (N < 9999000)
                R["idassetload"] = 9999001;
            else
                R["idassetload"] = N + 1;

            R["nassetload"] = -9999;
            return R;
        }
    }
}
