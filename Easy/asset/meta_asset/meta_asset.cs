
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;
//Pino: using dettbeneinventariabile; diventato inutile
using System.Windows.Forms;
using funzioni_configurazione;
//Pino: using beneinventariabile; diventato inutile
//Pino: using beneinv_trasferimento; diventato inutile

namespace meta_asset//meta_beneinventariabile//
{
	/// <summary>
	/// Summary description for Meta_beneinventariabile
	/// </summary>
	public class Meta_asset : Meta_easydata
	{
		public Meta_asset(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "asset") {

			EditTypes.Add("default");
			EditTypes.Add("dettaglio");
			EditTypes.Add("accessorio");
			EditTypes.Add("trasferimento");
            EditTypes.Add("cambioinventario");
			ListingTypes.Add("default");
			ListingTypes.Add("dettaglio");
			ListingTypes.Add("accessorio");
			ListingTypes.Add("scaricobeni");
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) 
		{
			switch(ListingType.ToLower()) {
				case "default":
					return base.SelectOne(ListingType, filter, "assetview", Exclude);
				case "dettaglio":
					return base.SelectOne(ListingType, filter, "asset", Exclude);
				case "accessorio":
					return base.SelectOne(ListingType, filter, "asset", Exclude);
				case "scaricobeni":
					return base.SelectOne(ListingType, filter, "asset", Exclude);
			}
			return null;
		}		

		public override System.Data.DataRow Get_New_Row(System.Data.DataRow ParentRow, System.Data.DataTable T) {
            int flag = CfgFn.GetNoNullInt32(ParentRow["flag"]);
            bool ispieceacquire = ((flag & 4) != 0);
			if (!ispieceacquire){
				RowChange.MarkAsAutoincrement(T.Columns["idasset"], null, null, 6);
				RowChange.ClearAutoIncrement(T.Columns["idpiece"]);
				RowChange.ClearSelector(T,"idasset");
				SetDefault(T,"idpiece",1);
			}
			else {
				RowChange.MarkAsAutoincrement(T.Columns["idpiece"], null, null, 6);
				RowChange.ClearAutoIncrement(T.Columns["idasset"]);
				RowChange.SetSelector(T,"idasset");
			}
			DataRow R = base.Get_New_Row(ParentRow, T);
            if (ispieceacquire) {
				if (R["idpiece"].ToString()=="1")
					R["idpiece"]=2;
			}
			return R;
		}

		protected override System.Windows.Forms.Form GetForm(string EditType) {
			if (EditType == "dettaglio")
			{
				Name = "Cespiti";
				return MetaData.GetFormByDllName("asset_dettaglio");//PinoRana
			}
			if (EditType == "accessorio") {
				Name = "Accessorio di cespite";
				return MetaData.GetFormByDllName("asset_dettaglio");//PinoRana
			}
			if (EditType == "default") {
				DefaultListType="default";
				this.CanCancel=false;
				this.CanInsert=false;
				this.CanInsertCopy=false;
				Name = "Cespiti";
				return MetaData.GetFormByDllName("asset_default");//PinoRana
			}
			if (EditType=="trasferimento")
			{
				Name = "Traferimento Cespiti";
				this.CanCancel=false;
				this.CanInsert=false;
				this.CanInsertCopy=false;
				this.CanSave=false;
				this.SearchEnabled=false;
				return MetaData.GetFormByDllName("asset_trasferimento");//PinoRana
			}
            if (EditType == "cambioinventario") {
                Name = "Cambio Inventario";
                this.CanCancel = false;
                this.CanInsert = false;
                this.CanInsertCopy = false;
                this.CanSave = false;
                this.SearchEnabled = false;
                return MetaData.GetFormByDllName("asset_cambioinventario");
            }
			return null;
		}

		private int CalcolaNumeroRigaDettaglio(DataRow row) {
			DataTable t = row.Table;
			int count = 0;
			foreach (DataRow r in t.Select(null,"ninventory asc")) {
				if (r.RowState==DataRowState.Deleted) continue;
				++count;
				if (r == row) return count;
			}
			return count;
		}

		private int CalcolaNumeroRigaScaricoBeni(DataRow row) {
			DataTable t = row.Table;
			int count = 0;
			foreach (DataRow r in t.Rows) {
				if (r.RowState==DataRowState.Deleted ||
					r["nassetunload"]==DBNull.Value) continue;
				++count;
				if (r == row) return count;
			}
			return count;
		}
        void CalcolaUbicazioneResponsabile(System.Data.DataRow R) {
            //Mette in !location la riga di assetlocation con data null
            DataTable AssetLocation = R.Table.DataSet.Tables["assetlocation"];
            DataTable Location = R.Table.DataSet.Tables["location"];
            DataRow []RAL= AssetLocation.Select(QHC.AppAnd(QHC.CmpEq("idasset",R["idasset"]),
                                    QHC.IsNull("start")));
            if (RAL.Length > 0) {
                object idlocation = RAL[0]["idlocation"];
                DataRow[] RLoc = Location.Select(QHC.CmpEq("idlocation", idlocation));
                if (RLoc.Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(Location, null, QHS.CmpEq("idlocation", idlocation), null, false);
                    RLoc = Location.Select(QHC.CmpEq("idlocation", idlocation));
                }

                if (RLoc.Length > 0) {
                    R["!location"] = RLoc[0]["description"];
                }
                else {
                    R["!location"] = "";
                }
            }
            else {
                R["!location"] = "";
            }


            //Mette in !manager la riga di assetmanager con data null
            DataTable AssetManager = R.Table.DataSet.Tables["assetmanager"];
            DataTable Manager = R.Table.DataSet.Tables["manager"];
            DataRow[] RAM = AssetManager.Select(QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]),
                                    QHC.IsNull("start")));            
            if (RAM.Length > 0) {
                object idmanager = RAM[0]["idman"];
                DataRow[] RMan = Manager.Select(QHC.CmpEq("idman", idmanager));
                if (RMan.Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(Manager, null, QHS.CmpEq("idman", idmanager), null, false);
                    RMan = Manager.Select(QHC.CmpEq("idman", idmanager));
                }
                if (RMan.Length > 0) {
                    R["!manager"] = RMan[0]["title"];
                }
                else {
                    R["!manager"] = "";
                }
            }
            else {
                R["!manager"] = "";
            }

            //Mette in !submanager la riga di assetsubmanager con data null
            DataTable AssetSubManager = R.Table.DataSet.Tables["assetsubmanager"];
            DataTable SubManager = R.Table.DataSet.Tables["submanager"];
            DataRow[] RAsubM = AssetSubManager.Select(QHC.AppAnd(QHC.CmpEq("idasset", R["idasset"]),
                                    QHC.IsNull("start")));
            if (RAsubM.Length > 0) {
                object idmanager = RAsubM[0]["idmanager"];
                DataRow[] RAsubMan = SubManager.Select(QHC.CmpEq("idman", idmanager));
                if (RAsubMan.Length == 0) {
                    Conn.RUN_SELECT_INTO_TABLE(SubManager, null, QHS.CmpEq("idman", idmanager), null, false);
                    RAsubMan = SubManager.Select(QHC.CmpEq("idman", idmanager));
                }
                if (RAsubMan.Length > 0) {
                    R["!submanager"] = RAsubMan[0]["title"];
                }
                else {
                    R["!submanager"] = "";
                }
            }
            else {
                R["!submanager"] = "";
            }
        }
		public override void CalculateFields(System.Data.DataRow R, string listtype) {
			if (listtype == "dettaglio") {
				R["!numeroriga"] = CalcolaNumeroRigaDettaglio(R);
                CalcolaUbicazioneResponsabile(R);
			}
			if (listtype == "accessorio") {
				R["!numeroriga"] = CalcolaNumeroRigaDettaglio(R);
			}
			if (listtype == "scaricobeni") {
				R["!numeroriga"] = CalcolaNumeroRigaScaricoBeni(R);
			}
		}

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType=="dettaglio") {
                int pos = 1;
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "",-1);
				QueryCreator.SetExpression(T.Columns["!assetdescription"],null);				
				
				//DescribeAColumn(T, "!numeroriga", "Numero");
				DescribeAColumn(T, "!ninventory", "Inventario",pos++);
				QueryCreator.SetExpression(T.Columns["!ninventory"],null);
                DescribeAColumn(T, "lifestart", "Data Acq. Cespite", pos++);
				DescribeAColumn(T, "!location", "Ubicazione",pos++);
                DescribeAColumn(T, "!manager", "Responsabile", pos++);
                DescribeAColumn(T, "!submanager", "Subconsegnatario", pos++);
				DescribeAColumn(T, "rfid", "rfid", pos++);
				HelpForm.SetAlignForColumn(T.Columns["!ninventory"],"R");
				ComputeRowsAs(T, ListingType);
			}
			if (ListingType=="accessorio") {
				foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "", -1);
                int pos = 1;
				//DescribeAColumn(T, "!numeroriga", "#");
                DescribeAColumn(T, "!ninventory", "Num. Inv.", "assetview1.ninventory", pos++);
				//DescribeAColumn(T, "!ninventory", "Num. Inv.");
                DescribeAColumn(T, "!assetdescription", "Cespite principale", "assetview1.description", pos++);
                QueryCreator.SetExpression(T.Columns["!location"], null);
                QueryCreator.SetExpression(T.Columns["!manager"], null);
                DescribeAColumn(T, "lifestart", "Data Acq. Cespite", pos++);

				HelpForm.SetAlignForColumn(T.Columns["!ninventory"],"R");
				ComputeRowsAs(T, ListingType);
			}

			if (ListingType=="scaricobeni") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");

				//DescribeAColumn(T, "!numeroriga", "Numero");
				DescribeAColumn(T, "!idinventory", "Tipo invent.", "assetload.idinventory");
				DescribeAColumn(T, "ninventory", "Numero inv.");
				DescribeAColumn(T, "!description", "Descrizione", "assetload.description");
				ComputeRowsAs(T,ListingType);
				FilterRows(T);
			}
		}

		public override bool FilterRow(DataRow R, string list_type) {
			if (list_type=="scaricobeni") {
				if (R["nassetunload"]!=DBNull.Value) 
					return true;
				return false;
			}
			return true;
		}

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R,out errmess,out errfield))return false;
			if (edit_type=="dettaglio"){
				if (R["ninventory"]==DBNull.Value){
					errmess= "E' necessario specificare il numero inventario";
					errfield="ninventory";
					return false;
				}
			}
            int nInventory = CfgFn.GetNoNullInt32(R["ninventory"]);
            int idPiece = CfgFn.GetNoNullInt32(R["idpiece"]);

            if ((nInventory==0)&&(idPiece==1)) {
                errmess = "E' necessario specificare il numero di inventario";
                errfield = "ninventory";
                return false;
            }
            //if ((nInventory > 0) && (idPiece > 1)) {
            //    errmess = "Per un accessorio non bisogna specificare il numero d'inventario";
            //    errfield="ninventory";
            //    return false;
            //}
            if (R["lifestart"] == DBNull.Value)
                {
                    errmess = "Bisogna specificare la data inzio esistenza cespite";
                    errfield = "lifestart";
                    return false;
                }
			return true;
		}
		 
        public override void SetDefaults(DataTable T) {
            base.SetDefaults(T);
            SetDefault(T, "flag", 1);
        }
	}
}
