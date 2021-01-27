
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
using System.Windows.Forms;
using metaeasylibrary;
//Pino: using caricobeneinventario; diventato inutile
using metadatalibrary;
using System.Data;
using funzioni_configurazione;


namespace meta_assetacquire//meta_caricobeneinventario//
{
	/// <summary>
	/// meta classe per Carico bene inventario.
	/// </summary>
	public class Meta_assetacquire : Meta_easydata
	{
		public Meta_assetacquire(DataAccess Conn, MetaDataDispatcher Dispatcher):
			base(Conn, Dispatcher, "assetacquire") {

			EditTypes.Add("default");
            EditTypes.Add("importa");
            EditTypes.Add("esporta");
            EditTypes.Add("massive");
            ListingTypes.Add("default");
            ListingTypes.Add("carichifattura");
            Name = "Carico dei cespiti da bolla/fattura";
		}

		protected override Form GetForm(string EditType) {
			if (EditType == "default") {
				DefaultListType = "default";
                Name = "Carico dei cespiti da bolla/fattura";
				return MetaData.GetFormByDllName("assetacquire_default");
			}
            if (EditType == "esporta") {
                Name = "Esportazione dati patrimoniali";
                DefaultListType = "default";
                return GetFormByDllName("assetacquire_export");
            }
            if (EditType == "importa") {
                Name = "Importazione dati patrimoniali";
                DefaultListType = "default";
                return GetFormByDllName("assetacquire_import");
            }
            if (EditType == "massive") {
                Name = "Carico cespiti rapido";
                DefaultListType = "default";
                return GetFormByDllName("assetacquire_massive");
            }

			return null;
		}
		
		public override System.Data.DataRow Get_New_Row(System.Data.DataRow ParentRow, System.Data.DataTable T) {
			RowChange.MarkAsAutoincrement(T.Columns["nassetacquire"], null, null, 0);
            RowChange.setMinimumTempValue(T.Columns["nassetacquire"], 99999000);
			DataRow R = base.Get_New_Row(ParentRow, T);
            //int N = CfgFn.GetNoNullInt32(R["nassetacquire"]);
            //if (N==1) R["nassetacquire"]=-990000;
			return R;
		}

		public override DataRow SelectOne(string ListingType, string filter, string searchtable, DataTable Exclude) {
			return base.SelectOne(ListingType, filter, "assetacquireview", Exclude);
		}		

		public override void DescribeColumns(DataTable T, string ListingType) {
			base.DescribeColumns(T, ListingType);

			if (ListingType=="default") {
				foreach (DataColumn C in T.Columns)
					DescribeAColumn(T, C.ColumnName, "");
				int nPos = 1;
				DescribeAColumn(T, "nassetacquire", "Num. carico",nPos++);
				DescribeAColumn(T, "idmankind", "Tipo Contr. Passivo",nPos++);
				DescribeAColumn(T, "yman", "Eserc.  Contr. Passivo",nPos++);
				DescribeAColumn(T, "nman", "Num.  Contr. Passivo",nPos++);
				DescribeAColumn(T, "rownum", "Num. Riga",nPos++);
				DescribeAColumn(T, "registry", "Cedente",nPos++);
				DescribeAColumn(T, "assetloadmotive", "Causale",nPos++);
				DescribeAColumn(T, "codeinv", "Codice class.",nPos++);
				DescribeAColumn(T, "description", "Descrizione",nPos++);
				DescribeAColumn(T, "assetloadkind", "Tipo buono",nPos++);
				DescribeAColumn(T, "yassetload", "Eserc. buono",nPos++);
				DescribeAColumn(T, "nassetload", "Num. buono",nPos++);
				DescribeAColumn(T, "number", "Q.tà",nPos++);
				DescribeAColumn(T, "taxable", "Imponibile",nPos++);
				DescribeAColumn(T, "taxrate", "Aliquota IVA",nPos++);
				DescribeAColumn(T, "discount", "Sconto",nPos++);
				DescribeAColumn(T, "startnumber", "Num. iniziale",nPos++);
				DescribeAColumn(T, "adate", "Data cont.",nPos++);
				HelpForm.SetFormatForColumn(T.Columns["discount"],"p");
				HelpForm.SetFormatForColumn(T.Columns["taxrate"],"p");
			}
            if (ListingType == "carichifattura") {
                foreach (DataColumn C in T.Columns)
                    DescribeAColumn(T, C.ColumnName, "");
                int nPos = 1;
                DescribeAColumn(T, "nassetacquire", "Num. carico", nPos++);
                DescribeAColumn(T, "description", "Descrizione", nPos++);
                DescribeAColumn(T, "number", "Q.tà", nPos++);
                DescribeAColumn(T, "taxable", "Imponibile", nPos++);
                DescribeAColumn(T, "taxrate", "Aliquota IVA", nPos++);
                DescribeAColumn(T, "discount", "Sconto", nPos++);
                DescribeAColumn(T, "startnumber", "Num. iniziale", nPos++);
                DescribeAColumn(T, "adate", "Data cont.", nPos++);
                HelpForm.SetFormatForColumn(T.Columns["discount"], "p");
                HelpForm.SetFormatForColumn(T.Columns["taxrate"], "p");
                DescribeAColumn(T, "invrownum", "Gruppo dettaglio fattura", nPos++);
            }
            

        }

		public override void SetDefaults(DataTable PrimaryTable) {
			base.SetDefaults (PrimaryTable);
			SetDefault(PrimaryTable, "adate", GetSys("datacontabile"));
			SetDefault(PrimaryTable, "flag", 1);
			SetDefault(PrimaryTable, "number", 0);
			SetDefault(PrimaryTable, "abatable", 0);
		}
		
		protected override void InsertCopyColumn(DataColumn C, DataRow Source, DataRow Dest) {
            //if (C.ColumnName == "idassetload")  return;
            //if (C.ColumnName == "transmitted") return;
            //if (C.ColumnName == "number") return;
            //   base.InsertCopyColumn(C, Source, Dest);
            string[] dontcopy = new string[]{"idassetload","transmitted","number",
                                                "idinvkind","yinv","ninv","invrownum",
                                                "idmankind","yman","nman","rownum"};
            foreach (string field in dontcopy) {
                if (C.ColumnName.ToLower() == field) {
                    return;
                }
            }
            base.InsertCopyColumn(C, Source, Dest);
        }

		public override bool IsValid(DataRow R, out string errmess, out string errfield) {
			if (!base.IsValid(R,out errmess,out errfield))return false;

			if (CfgFn.GetNoNullInt32(R["idinventory"])<=0) {
				errmess= "E' necessario specificare l'inventario";
                errfield = "idinventory";
                return false;
			}

            if (CfgFn.GetNoNullInt32(R["idinv"]) <= 0) {
                errmess = "E' necessario specificare la classificazione inventariale";
                errfield = "inventorytreeview.codeinv";
                return false;
            }

            if (CfgFn.GetNoNullInt32(R["idmot"]) <= 0) {
                errmess = "E' necessario specificare la causale di carico";
                errfield = "assetacquire.idmot";
                return false;
            }

//			if (R["ispieceacquire"].ToString().ToUpper()=="N"){
//				if ((CfgFn.GetNoNullInt32(R["number"])!=0)&&(R["startnumber"]==DBNull.Value)						){
//					errmess = "Selezionare il n. di inventario iniziale";
//					errfield = "startnumber";
//					return false;
//				}
//			}
//			else {
//			}

            //if ((R["loadkind"].ToString() == "R") &&
            //    ((R["idassetloadkind"] != DBNull.Value) || 
            //    (R["yassetload"] != DBNull.Value) ||
            //    (R["nassetload"] != DBNull.Value)))
            //{
            //    if (R["idassetloadkind"] == DBNull.Value)
            //    {
            //        errmess = "Selezionare il tipo del Buono di Carico";
            //        errfield = "idassetloadkind";
            //        return false;
            //    }
            //    if (R["yassetload"] == DBNull.Value)
            //    {
            //        errmess = "Inserire l'esercizio del Buono di Carico";
            //        errfield = "yassetload";
            //        return false;
            //    }
            //    if (R["nassetload"] == DBNull.Value)
            //    {
            //        errmess = "Inserire il numero del Buono di Carico";
            //        errfield = "nassetload";
            //        return false;
            //    }
            //}

			if (CfgFn.GetNoNullInt32(R["number"]) <= 0)
			{
				errmess = "E' necessario specificare una quantità maggiore di zero";
				errfield = "number";
				return false;
			}
			if (CfgFn.GetNoNullDecimal(R["taxable"]) < 0) {
				errmess = "Non è possibile specificare un Imponibile negativo";
				errfield = "taxable";
				return false;
			}
			if (CfgFn.GetNoNullDecimal(R["discount"]) < 0) {
				errmess = "Non è possibile specificare una Percentuale di Sconto negativa";
				errfield = "discount";
				return false;
			}
			if (CfgFn.GetNoNullDecimal(R["taxrate"]) < 0) {
				errmess = "Non è possibile specificare un'Aliquota IVA negativa";
				errfield = "taxrate";
				return false;
			}
			//controllo su tutte le righe figlie in beneinventaribile abbiano
			//il num. inventario valorizzato
            int flag = CfgFn.GetNoNullInt32(R["flag"]);
            bool ispieceacquire = ((flag & 4) != 0);
            if ((edit_type == "default" || edit_type=="massive") && !ispieceacquire) {
				DataRow[] beneInv = R.GetChildRows("assetacquireasset");
				foreach (DataRow r in beneInv) {
					if ((r["ninventory"]==DBNull.Value)||
						(r["ninventory"].ToString()=="0")) {
						errmess= "E' necessario specificare il numero inventario (diverso da 0) dei cespiti inventariabili";
						errfield=null;
						return false;
					}
				}
			}
            if (ispieceacquire) {
				if (R.Table.DataSet.Tables["asset"].Select("idasset<0").Length>0){
					errmess="E' necessario specificare il n. di inventario di ogni accessorio.";
					errfield="startnumber";
					return false;
				}
			}
			// Se nella configurazione ho deciso di limitare ad un solo cessionario sono 
			// obbligato a sceglierlo.
			DataRow currAssetsetup = R.Table.DataSet.Tables["config"].Rows[0];
			if (currAssetsetup == null) return false;
            byte assetload_flag = (byte)currAssetsetup["assetload_flag"];
            if ((assetload_flag&1)==1)
			{
				if((R["idreg"])==DBNull.Value) 
				{
					errmess="E' necessario specificare il cedente.";
					errfield="idreg";
					return false;
				}
			}
			return true;
		}

	}
}
