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
using System.Data;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
//Pino: using buonoscaricoinventario; diventato inutile
//Pino: using buonoscaricoinv_gen_auto; diventato inutile
using funzioni_configurazione;//funzioni_configurazione

namespace meta_assetunload { //meta_buonoscaricoinventario//
	/// <summary>
	/// Summary description for Meta_buonoscaricoinventario.
	/// </summary>
	public class Meta_assetunload : Meta_easydata {
		public Meta_assetunload(DataAccess Conn, MetaDataDispatcher Dispatcher) :
			base(Conn, Dispatcher, "assetunload") {
			EditTypes.Add("default");
			EditTypes.Add("storico");
			ListingTypes.Add("default");
			DefaultListType = "default";
			EditTypes.Add("generazioneautomatica");
		}

		protected override Form GetForm(string FormName) {
			if (FormName == "default") {
				Name = "Buono di scarico";
				DefaultListType = "default";
				return MetaData.GetFormByDllName("assetunload_default"); //PinoRana
			}

			if (FormName == "storico") {
				Name = "Buono di scarico";
				DefaultListType = "default";
				return MetaData.GetFormByDllName("assetunload_storico");
			}

			if (FormName == "generauto") {
				Name = "Generazione automatica buoni di scarico";
				DefaultListType = "default";
				return MetaData.GetFormByDllName("assetunload_generauto"); //PinoRana
			}

			return null;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable ToMerge) {
			if (ListingType == "default")
				return base.SelectOne(ListingType, filter, "assetunloadview", ToMerge);
			return base.SelectOne(ListingType, filter, searchtable, ToMerge);
		}

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults(PrimaryTable);
			SetDefault(PrimaryTable, "yassetunload", GetSys("esercizio"));
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			// Bisogna innanzitutto chiamare IsValid della classe base
			if (!base.IsValid(R, out errmess, out errfield)) return false;

			if (CfgFn.GetNoNullInt32(R["idassetunloadkind"]) == 0) {
				errmess = "E' necessario specificare il tipo di buono di scarico.";
				errfield = "idassetloadkind";
				return false;
			}

			if ((R["adate"]) == DBNull.Value) {
				errmess = "E' necessario specificare una data contabile.";
				errfield = "adate";
				return false;
			}

			DataRow currAssetsetup = R.Table.DataSet.Tables["config"].Rows[0];
			if (currAssetsetup == null) return false;
			byte assetload_flag = (byte) currAssetsetup["assetload_flag"];
			if ((assetload_flag & 2) == 2) {
				if ((R["idmot"]) == DBNull.Value) {
					errmess = "E' necessario specificare una causale.";
					errfield = "idmot";
					return false;
				}
			}

			if ((assetload_flag & 1) == 1) {
				if ((R["idreg"]) == DBNull.Value) {
					if (!showClientMsg("Non Ë stato specificato il cessionario. Proseguo lo stesso?",
						"Avviso", MessageBoxButtons.YesNo)) {
						errmess = "E' necessario specificare il cessionario.";
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
			object esercizio = R["yassetunload"];
			QueryHelper QHS = Conn.GetQueryHelper();
			string filter_patri = QHS.CmpEq("ayear", esercizio);
			//ricavo configurazione patrimonio
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter_patri, null, false);
			if (t == null || t.Rows.Count == 0) return null;
			string tiponumerazione = t.Rows[0]["asset_flagnumbering"].ToString();
			string flagreset = t.Rows[0]["asset_flagrestart"].ToString().ToUpper();

			string filter_esercbuonoscarico = QHS.CmpEq("b.yassetunload", esercizio);
			string filter_esercbuonocarico = QHS.CmpEq("b.yassetload", esercizio);

			string filter_codicetipobuonoscarico = QHS.CmpEq("b.idassetunloadkind", R["idassetunloadkind"]);
			string sql_select1, sql_select2;
			string sql_from1, sql_from2;
			string sql_where1, sql_where2;
			string sql1 = "", sql2 = "";

			//ricavo configurazione del codice tipo buono
			DataRow Rtipobuono = R.GetParentRow("assetunloadkindviewassetunload");
			if (Rtipobuono == null) {
				Rtipobuono = R.GetParentRow("assetunloadkindassetunload");
			}

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

					string filter_tipoinventario = "(i.idinventorykind=" +
					                               QueryCreator.quotedstrvalue(Tinv.Rows[0]["idinventorykind"], true) +
					                               ")";
					sql_select1 = "SELECT ISNULL(MAX(b.nassetload),0) + 1 ";
					sql_from1 = "FROM assetload b INNER JOIN assetloadkind t on b.idassetloadkind=t.idassetloadkind " +
					            "INNER JOIN inventory i ON t.idinventory=i.idinventory " +
					            "INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";
					sql_where1 = "WHERE " + GetData.MergeFilters(filter_esercbuonocarico, filter_tipoinventario);
					sql1 = sql_select1 + sql_from1 + sql_where1;


					sql_select2 = "SELECT ISNULL(MAX(b.nassetunload),0) + 1 ";
					sql_from2 =
						"FROM assetunload b INNER JOIN assetunloadkind t on b.idassetunloadkind=t.idassetunloadkind " +
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
					sql_where1 = "WHERE " + QHS.AppAnd(filter_esercbuonocarico, filter_ente);
					sql1 = sql_select1 + sql_from1 + sql_where1;

					sql_select2 = "SELECT ISNULL(MAX(b.nassetunload),0) + 1 ";
					sql_from2 =
						"FROM assetunload b INNER JOIN assetunloadkind t on b.idassetunloadkind=t.idassetunloadkind " +
						"INNER JOIN inventory i ON t.idinventory=i.idinventory " +
						"INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";

					sql_where2 = "WHERE " + GetData.MergeFilters(filter_esercbuonoscarico, filter_ente);
					sql2 = sql_select2 + sql_from2 + sql_where2;
					return GetMax(sql1, sql2, Conn);

				case "K":
					//per ente inventariale suddiviso per buono carico e buono scarico

					if (flagreset == "N") {
						filter_esercbuonoscarico = "";
					}

					filter_ente = QHS.CmpEq("i.idinventoryagency", Tinv.Rows[0]["idinventoryagency"]);
					sql_select2 = "SELECT ISNULL(MAX(b.nassetunload),0) + 1 ";
					sql_from2 =
						"FROM assetunload b INNER JOIN assetunloadkind t on b.idassetunloadkind=t.idassetunloadkind " +
						"INNER JOIN inventory i ON t.idinventory=i.idinventory " +
						"INNER JOIN inventorykind ti ON i.idinventorykind=ti.idinventorykind ";

					sql_where2 = "WHERE " + GetData.MergeFilters(filter_esercbuonoscarico, filter_ente);
					sql2 = sql_select2 + sql_from2 + sql_where2;

					DataTable tUnload = Conn.SQLRunner(sql2, true);
					if (tUnload == null || tUnload.Rows.Count == 0) {
						return 0;
					}

					return tUnload.Rows[0][0];

				case "B":
				default:
					//per tipo buono

					//ricavo configurazione del codice tipo buono
					//DataRow Rtipo=R.GetParentRow("assetunloadkindviewassetunload");
					bool numassoluta = false;
					if (Rtipobuono.Table.TableName == "assetunloadkindview") {
						numassoluta = (Rtipobuono["flaglinear"].ToString().ToUpper() == "S");
					}
					else {
						//assetunloadkind
						int skind = CfgFn.GetNoNullInt32(Rtipobuono["flag"]);
						numassoluta = ((skind & 1) != 0); //flaglinear (bit 0), ove 0 = N ; 1 = S.
					}

					int value_if_null = 0;
					int numiniziale = CfgFn.GetNoNullInt32(Rtipobuono["startnumber"]);
					value_if_null = numiniziale - 1;
					if (value_if_null < 0) value_if_null = 0;
					sql_select1 = "SELECT ISNULL(MAX(b.nassetunload)," + value_if_null.ToString() + ") + 1 ";
					sql_from1 = "FROM assetunload b ";
					sql_where1 = "WHERE " + filter_codicetipobuonoscarico;
					if (!numassoluta) sql_where1 += " AND " + filter_esercbuonoscarico;
					sql1 = sql_select1 + sql_from1 + sql_where1;
					DataTable T1 = Conn.SQLRunner(sql1, true);
					if (T1 == null || T1.Rows.Count == 0) {
						if (!numassoluta) return value_if_null + 1;
						return 1;
					}

					return T1.Rows[0][0];

			}
		}

		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
			//if ((C.ColumnName=="idassetloadkind") || (C.ColumnName == "yassetload")||(C.ColumnName == "nassetload"))return;
			if (C.ColumnName == "transmitted") return;
			base.InsertCopyColumn(C, Source, Dest);
		}

		public override DataRow Get_New_Row(DataRow ParentRow, DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["idassetunload"], null, null, 7);
			RowChange.MarkAsAutoincrement(T.Columns["nassetunload"], null, null, 7);
			RowChange.MarkAsCustomAutoincrement(T.Columns["nassetunload"], new RowChange.CustomCalcAutoID(CalcID));
			DataRow R = base.Get_New_Row(ParentRow, T);
			int N = MetaData.MaxFromColumn(T, "idassetunload");
			if (N < 9999000)
				R["idassetunload"] = 9999001;
			else
				R["idassetunload"] = N + 1;
			int NN = MetaData.MaxFromColumn(T, "nassetunload");
			if (NN < 9999000)
				R["nassetunload"] = 9999001;
			else
				R["nassetunload"] = NN + 1;
			return R;
		}

	}
}

