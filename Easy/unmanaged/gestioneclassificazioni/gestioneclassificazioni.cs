
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
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using funzioni_configurazione;
using q = metadatalibrary.MetaExpression;

namespace gestioneclassificazioni
{


	public class GBoxManage {
		GroupBox gbox;

		Control []ControlsToClear;
		Control []ControlsToEnableDisable;
		string []fieldstoclear;

		MetaData Meta;
		DataTable Movimento;
		DataTable Imputazione;
		DataTable Fase;
		public int faseattivazione;
		public bool disattiva;

		public bool  AttualmenteAttivo {
			get{
				return abilita;
			}

		}


		bool abilita;
		bool mostra;

        static decimal GetNoNullDecimal(object O) {
            if (O == null) return 0;
            if (O == DBNull.Value) return 0;
            try {
                return Convert.ToDecimal(O);
            }
            catch {
                return 0;
            }
        }

		static int GetNoNullInt32(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
			try {
				return Convert.ToInt32(O);
			}
			catch {
				return 0;
			}
		}
		public GBoxManage(MetaData Meta, 
			GroupBox gbox,
			Control []ControlsToClear, 
			Control []ControlsToEnableDisable, 
			string []fieldstoclear, 
			int faseattivazione,
			string tablename,
			string filterfun) {
			this.Meta=Meta;
			this.gbox=gbox;

			if (Meta.PrimaryDataTable.TableName=="expense"){
				Movimento=Meta.DS.Tables["expense"];
				Imputazione = Meta.DS.Tables["expenseyear"];
				Fase= Meta.DS.Tables["expensephase"];
			}
			else {
				Movimento=Meta.DS.Tables["income"];
				Imputazione = Meta.DS.Tables["incomeyear"];
				Fase= Meta.DS.Tables["incomephase"];
			}
			this.faseattivazione = faseattivazione;

			int Nrighe = Meta.Conn.RUN_SELECT_COUNT(tablename,filterfun,true);
			if (Nrighe==0) disattiva=true;
			else disattiva=false;
			
			if (ControlsToEnableDisable!=null)
				this.ControlsToEnableDisable= ControlsToEnableDisable;
			else
				this.ControlsToEnableDisable= ControlsToClear;
			this.ControlsToClear = ControlsToClear;
			this.fieldstoclear= fieldstoclear;

		}


		public GBoxManage(MetaData Meta, 
			GroupBox gbox,
			Control []ControlsToClear, 
			Control []ControlsToEnableDisable, 
			string []fieldstoclear, 
			string flagfield,
			string tablename,
			string filterfun) {
			this.Meta=Meta;
			this.gbox=gbox;

			if (Meta.PrimaryDataTable.TableName=="expense"){
				Movimento=Meta.DS.Tables["expense"];
				Imputazione = Meta.DS.Tables["expenseyear"];
				Fase= Meta.DS.Tables["expensephase"];
			}
			else {
				Movimento=Meta.DS.Tables["income"];
				Imputazione = Meta.DS.Tables["incomeyear"];
				Fase= Meta.DS.Tables["incomephase"];
			}
			DataRow[] MyDRfase;
			MyDRfase  = Fase.Select("("+flagfield+"='S')","nphase");			
			if (MyDRfase.Length > 0)
				faseattivazione = (GetNoNullInt32(MyDRfase[0]["nphase"]));
			else faseattivazione = 0;

			if ((tablename.ToLower()=="registry")||(tablename.ToLower()=="fin")){
				disattiva=false;
			}
			else {
				int Nrighe = Meta.Conn.RUN_SELECT_COUNT(tablename,filterfun,true);;
				if (Nrighe==0) disattiva=true;
							else disattiva=false;
			}
	
			
			if (ControlsToEnableDisable!=null)
				this.ControlsToEnableDisable= ControlsToEnableDisable;
			else
				this.ControlsToEnableDisable= ControlsToClear;
			this.ControlsToClear = ControlsToClear;
			this.fieldstoclear= fieldstoclear;

		}

		void ClearControl(Control C){	
			if (C==null) return;
			System.Type C_Type = C.GetType();			
			if (typeof(Label).IsAssignableFrom(C_Type)) return;

			if (typeof(ComboBox).IsAssignableFrom(C_Type)){
				((ComboBox) C).SelectedIndex=-1;				
				return;
			}

			if (typeof(TextBox).IsAssignableFrom(C_Type)){
				((TextBox) C).Text="";
				return;
			}
			if (typeof(CheckBox).IsAssignableFrom(C_Type)){
				((CheckBox) C).ThreeState=true;
				((CheckBox) C).CheckState= CheckState.Indeterminate;
				return;
			}
			if (typeof(RadioButton).IsAssignableFrom(C_Type)){
				((RadioButton)C).Checked=false;
				return;
			}
		}
		void EnableDisable(Control C, bool enable){	
			if (C==null) return;
			System.Type C_Type = C.GetType();			
	
			if (typeof(TextBox).IsAssignableFrom(C_Type)){
				((TextBox) C).ReadOnly= !enable;
				return;
			}
			C.Enabled= enable;
		}
	
		public void AbilitaDisabilita(int fase){
			AbilitaDisabilita(fase,fase);
		}
        public static bool hasChanges(DataTable t) {
            if (t == null) return false;
            foreach (DataRow R in t.Rows) {
                if (R.RowState == DataRowState.Unchanged) continue;
                if (R.RowState != DataRowState.Modified) return true;
                if (PostData.CheckForFalseUpdate(R)) {
                    R.AcceptChanges();
                    continue;
                }
                return true;
            }
            return false;
        }
        public void AbilitaDisabilita(int faseinizio, int fasefine){

			bool attivato = (faseattivazione>0);
			if (Meta.IsEmpty){
				mostra = attivato && (fasefine >= faseattivazione);
				abilita = mostra;
				//=attivato && (faseinizio<=faseattivazione)&&(faseattivazione<=fasefine);
			}
			else {
				abilita = attivato && (faseinizio<=faseattivazione)
					&&(faseattivazione<=fasefine);
				mostra = attivato && (fasefine >= faseattivazione);
			}
            try {
                if (Meta.DS.Tables.Contains("underwritingappropriation")) {                      
                    if (hasChanges(Meta.DS.Tables["underwritingappropriation"])) abilita = false;
                } 
            }
            catch { };

			if ((!mostra) && (Meta.InsertMode)){
				foreach (string idfield in fieldstoclear){
					if (Imputazione.Columns.Contains(idfield)){
						DataRow CurrImp = Imputazione.Rows[0];
						CurrImp[idfield]=DBNull.Value;
					}
					else {
						DataRow CurrMov = Movimento.Rows[0];
						CurrMov[idfield]=DBNull.Value;
					}
				}
				foreach(Control C in ControlsToClear) ClearControl(C);
			}
            AbilitaDisabilita(abilita);			
			if (gbox!=null) gbox.Visible= mostra && (!disattiva);
		}

        public void AbilitaDisabilita(bool abilita) {
            foreach (Control CC in ControlsToEnableDisable) EnableDisable(CC, abilita);
        }

		public object GetIDPerFase(int codicefase){
			if (codicefase<faseattivazione) return DBNull.Value;
			string idfield= fieldstoclear[0];
			if (Imputazione.Columns.Contains(idfield)){
				DataRow CurrImp = Imputazione.Rows[0];
				return CurrImp[idfield];
			}
			else {
				DataRow CurrMov = Movimento.Rows[0];
				return CurrMov[idfield];
			}
		}

	}


	public class GestioneClassificazioni {
		MetaData Meta;
		DataSet DS;
		DataTable TipoClassMovimenti;
		DataTable ImpClass;
		DataTable Movimento;
		DataTable ImputazioneMovimento;
		DataTable ClassMovimenti;
		DataTable VarMovimento;
        CQueryHelper QHC;
        QueryHelper QHS;
		DataGrid DGridClassificazioni;
		DataGrid DGridDettagliClassificazioni;
		string idmovimento;
		string codicefase;

		bool TipoClassAvailableEvalued;

		GBoxManage ManageBilAnnuale;
		GBoxManage ManageUPB;
		GBoxManage ManageCreditore;

		Button btnEditClass;
		Button btnInsertClass;
		Button btnDelClass;

		DataTable TipoClassAllowed;
		DataTable ClassMovimentiAllowed;
		bool monofase = false;


		public GestioneClassificazioni(MetaData Meta,
			DataGrid DGridClassificazioni,
			DataGrid DGridDettagliClassificazioni,
			GBoxManage ManageBilAnnuale,
			GBoxManage ManageUPB,
			GBoxManage ManageCreditore,
			Button btnEditClass,
			Button btnInsertClass,
			Button btnDelClass
			){
			this.Meta=Meta;
			this.DS= Meta.DS;
			this.DGridClassificazioni= DGridClassificazioni;
			this.DGridDettagliClassificazioni= DGridDettagliClassificazioni;
			this.btnDelClass= btnDelClass;
			this.btnEditClass=btnEditClass;
			this.btnInsertClass=btnInsertClass;

			this.ManageBilAnnuale= ManageBilAnnuale;
			this.ManageUPB=ManageUPB;
			this.ManageCreditore=ManageCreditore;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			TipoClassAllowed = null;
			ClassMovimentiAllowed = null;
			TipoClassAvailableEvalued=false;
			monofase = Meta.Conn.RUN_SELECT_COUNT("expensephase", null, true) == 1 ? true : false;

			if (Meta.PrimaryDataTable.TableName=="expense"){
				Movimento=Meta.DS.Tables["expense"];
				ImputazioneMovimento = Meta.DS.Tables["expenseyear"];
				VarMovimento = Meta.DS.Tables["expensevar"];
				ImpClass= Meta.DS.Tables["expensesorted"];
				idmovimento="idexp";
				codicefase = "nphaseexpense";
			}
		    if ((Meta.PrimaryDataTable.TableName == "income")|| (Meta.PrimaryDataTable.TableName == "no_table")) {
				Movimento=Meta.DS.Tables["income"];
				ImputazioneMovimento = Meta.DS.Tables["incomeyear"];
				ImpClass= Meta.DS.Tables["incomesorted"];
				VarMovimento = Meta.DS.Tables["incomevar"];
				idmovimento="idinc";
				codicefase = "nphaseincome";
			}
		    if (Meta.PrimaryDataTable.TableName == "pettycashoperation") {
		        Movimento = Meta.DS.Tables["pettycashoperation"];
                ImputazioneMovimento = Meta.DS.Tables["pettycashoperation"];
		        VarMovimento =null;
		        ImpClass = Meta.DS.Tables["pettycashoperationsorted"];
		        idmovimento = "idexp";
		        codicefase = "nphaseexpense";
		    }

            TipoClassMovimenti =Meta.DS.Tables["sortingkind"];
			ClassMovimenti=Meta.DS.Tables["sorting"];
		}

		/// <summary>
		/// Azzera i tipoclass / classmovimenti available calcolati
		/// </summary>
		public void Clear(){
			TipoClassAllowed=null;
			ClassMovimentiAllowed=null;
			TipoClassAvailableEvalued=false;
		}

		/// <summary>
		/// redraws grid
		/// </summary>
		/// <param name="importoperclassificazione"></param>
		public void RefillDettagliClassificazioni(decimal importoperclassificazione){
			if (Meta.IsEmpty) return;
			//int handle =metaprofiler.StartTimer("RefillDettagliClass");
			ImpClass.ExtendedProperties["TotaleImporto"]= importoperclassificazione;
			GetData.CalculateTable(ImpClass);
			//DGridDettagliClassificazioni.SuspendLayout();
			DGridDettagliClassificazioni.TableStyles.Clear();
			HelpForm.SetGridStyle(DGridDettagliClassificazioni, ImpClass);
			//DGridDettagliClassificazioni.ResumeLayout();
			//metaprofiler.StopTimer(handle);
			//handle =metaprofiler.StartTimer("RefillDettagliClass2");
			if (DGridDettagliClassificazioni.DataSource==null) return;
			formatgrids format = new formatgrids(DGridDettagliClassificazioni);
			format.AutosizeColumnWidth();	
			HelpForm.SetDataGrid(DGridDettagliClassificazioni, ImpClass);
			//metaprofiler.StopTimer(handle);
		}

		public void RicalcolaTipoClassificazioni(int faseinizio, int fasemovfine, bool forced){
			if ((!forced) && TipoClassAvailableEvalued) return;
			TipoClassAvailableEvalued=true;

			//Cancella le classmovimenti fuori range
			foreach (DataRow ClassMovRow in ClassMovimenti.Select()){
				if (ClassMovRow.RowState== DataRowState.Deleted) continue;
				DataRow []TipoClassFound = TipoClassMovimenti.Select(
					QHC.CmpEq("idsorkind", ClassMovRow["idsorkind"]));
				if (TipoClassFound.Length==0) {
					ClassMovRow.Delete();
					try {
						ClassMovRow.AcceptChanges();
					}
					catch{};
					continue;
				}
				int currfase = GetNoNullInt32(TipoClassFound[0][codicefase]);
				if ((currfase>=faseinizio) && (currfase<=fasemovfine)) continue;
				ClassMovRow.Delete();
				ClassMovRow.AcceptChanges();
			}
			//ClassMovimenti.Clear();
			GetData.ReCache(TipoClassMovimenti);
            string filtercl = "";

			if (faseinizio<fasemovfine) {
				filtercl=QHS.Between(codicefase, faseinizio, fasemovfine);
			}
			else {
				filtercl=QHS.CmpEq(codicefase, faseinizio);
			}
            filtercl = QHS.AppAnd(filtercl, QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio")));
			Meta.myGetData.DO_GET_TABLE(TipoClassMovimenti.TableName,filtercl);
			//Cancella i tipoclassmovimenti fuori range
			foreach (DataRow TipoClassMovRow in TipoClassMovimenti.Select()){
				if (TipoClassMovRow.RowState== DataRowState.Deleted) continue;
				int currfase = GetNoNullInt32(TipoClassMovRow[codicefase]);
				if ((currfase>=faseinizio) && (currfase<=fasemovfine)) continue;
				TipoClassMovRow.Delete();
				TipoClassMovRow.AcceptChanges();
			}

			//			//read again TipoClassMovimenti only if it was cached
			//			if (GetData.IsCached(TipoClassMovimenti)){
			//				GetData.ReCache(TipoClassMovimenti);
			//				Meta.myGetData.ReadCached();
			//			}


			//			GetData.UnCacheTable(TipoClassMovimenti);
			//			GetData.AllowClear(TipoClassMovimenti);
			//			Meta.GetFormData(true);
			//			Meta.FreshForm(true);
			//			GetData.DenyClear(TipoClassMovimenti);
			//			GetData.LockRead(TipoClassMovimenti);
			CalcTipoClassAllowed(faseinizio, fasemovfine);			
		}

		/// <summary>
		/// Calc tipoclassallowed calling:
		///  - sp_root_tipoclasses_spesa(spesadata)
		///  - sp_filtered_tipoclasses_spesa(spesadata, impclassspesarow) for each existent impclasspesa 
		/// </summary>
		public void CalcTipoClassAllowed(int faseinizio, int fasemovfine) {

			int OldIndex = DGridClassificazioni.CurrentRowIndex;
			DataRow CurrMov = Movimento.Rows[0];
			DataRow CurrImputazioneMovimento = ImputazioneMovimento.Rows[0];
			
			TipoClassAllowed=null;
			DataSet OutDS=null;

			object IDForSP = DBNull.Value;
			if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];
			decimal curramount = GetCurrImporto(CurrImputazioneMovimento);

			string sp_root_tipo = "compute_root_sortingkind_"+Movimento.TableName;
			for (int i= faseinizio; i<=fasemovfine; i++){
				//Calls sp_root_tipoclasses_spesa to get roots classes available
				OutDS=	Meta.Conn.CallSP(sp_root_tipo,
					new object[8] {Meta.GetSys("esercizio"),
									   IDForSP,
									   ManageCreditore.GetIDPerFase(i),
									   ManageUPB.GetIDPerFase(i),
									   i,
									   ManageBilAnnuale.GetIDPerFase(i),
									   CurrMov["idman"],
									   curramount
								   });			
			
				if(OutDS == null) continue;
				if (OutDS.Tables.Count==0) continue;
                if (TipoClassAllowed == null) {
                    TipoClassAllowed = OutDS.Tables[0];
                }
                else {
                    TipoClassAllowed.Clear();
                    QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                }
               
			}
		
			//			DS.classmovimenti.Clear();
			//			DS.tipoclassmovimenti.Clear();
			//			QueryCreator.MergeDataTable(DS.tipoclassmovimenti, OutDS.Tables[0]);
			//			DS.tipoclassmovimenti.AcceptChanges();
			
			foreach(DataRow CurrImpClass in ImpClass.Rows) {			
				if (CurrImpClass.RowState==DataRowState.Deleted) continue;
                DataRow CurrClass = CurrImpClass.GetParentRow(
                    "sorting" + Movimento.TableName + "sorted");
                if (CurrClass == null) continue;
                
                string filter = QHC.CmpEq("idsorkind", CurrClass["idsorkind"]);
                DataRow[] CurrTipoClassS = TipoClassMovimenti.Select(filter);
                DataRow CurrTipoClass = null;
                if (CurrTipoClassS.Length > 0) CurrTipoClass = CurrTipoClassS[0];

                if (CurrTipoClass==null) continue;
				int currfaseImpclass = GetNoNullInt32(
					CurrTipoClass["nphase"+Movimento.TableName]);
				try {
					OutDS=	Meta.Conn.CallSP(
						"compute_filtered_sortingkind_"+Movimento.TableName,
						new object[32]{Meta.GetSys("esercizio"),
										  IDForSP,
										  ManageCreditore.GetIDPerFase(currfaseImpclass),
										  ManageUPB.GetIDPerFase(currfaseImpclass),
										  currfaseImpclass, //CurrSpesa["codicefase"],
										  ManageBilAnnuale.GetIDPerFase(currfaseImpclass),
										  CurrMov["idman"],
										  CurrImputazioneMovimento["amount"],
										  CurrTipoClass["idsorkind"],
										  CurrImpClass["idsor"],
										  CurrImpClass["idsubclass"],
										  CurrImpClass["amount"],
										  CurrImpClass["description"],
										  CurrImpClass["flagnodate"],
										  CurrImpClass["tobecontinued"],
										  CurrImpClass["start"],
										  CurrImpClass["stop"],
										  CurrImpClass["valuen1"],
										  CurrImpClass["valuen2"],
										  CurrImpClass["valuen3"],
										  CurrImpClass["valuen4"],
										  CurrImpClass["valuen5"],
										  CurrImpClass["values1"],
										  CurrImpClass["values2"],
										  CurrImpClass["values3"],
										  CurrImpClass["values4"],
										  CurrImpClass["values5"],
										  CurrImpClass["valuev1"],
										  CurrImpClass["valuev2"],
										  CurrImpClass["valuev3"],
										  CurrImpClass["valuev4"],
										  CurrImpClass["valuev5"]
									  });
				}
				catch (Exception E) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
				}
				if ((OutDS!=null)&&(OutDS.Tables.Count>0)) {
                    if (TipoClassAllowed == null) {
                        TipoClassAllowed = OutDS.Tables[0];
                    }
                    else {
                        QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                    }
				}
			}
            if (TipoClassAllowed == null) {
                TipoClassAllowed = TipoClassMovimenti;
            }
            else {
                QueryCreator.MergeDataTable(TipoClassAllowed, TipoClassMovimenti);
            }
            //QueryCreator.MergeDataTable(TipoClassAllowed, TipoClassMovimenti);

            foreach (DataRow CurrKind in TipoClassAllowed.Select(
                QHC.AppOr(QHC.CmpLt(codicefase,faseinizio),QHC.CmpGt(codicefase,fasemovfine))
                )) {
                CurrKind.Delete();
            }
            TipoClassAllowed.AcceptChanges();

            HelpForm.SetDataGrid(DGridClassificazioni, TipoClassAllowed);
            if (TipoClassAllowed.Rows.Count >= OldIndex && OldIndex>=0) {
				DGridClassificazioni.CurrentRowIndex=OldIndex;
			}
			else{
                if (TipoClassAllowed.Rows.Count > 0)
					DGridClassificazioni.CurrentRowIndex=0;
			}

		}


		/// <summary>
		/// Returns true if current selected tipoclass is allowed to be inserted.
		/// Take accounts of:
		///  tipoclassmovimenti.flagmultipla and existence of related impclassspesa rows
		///  tipoclassallowed given by stored procs root_tipoclasses and filtered_tipoclasses
		/// </summary>
		public bool ImpClassMovInsertAllowed(int faseinizio, int fasefine) {
			if (Meta.IsEmpty) return false;
			CalcTipoClassAllowed(faseinizio, fasefine);

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
			if (!res) return false;
			if (CurrTipoClass==null) return false;

			string filter= QHC.CmpEq("idsorkind", CurrTipoClass["idsorkind"]);
			if ((TipoClassAllowed==null)||(TipoClassAllowed.Select(filter).Length==0)) return false;
			
			/*if ((CurrTipoClass["flagmultiple"].ToString().ToLower()=="s")||
				(ClassMovimenti.Select(filter).Length==0)) {
				return true;
			}*/
			return true;
		}

		static void MarkEvent(string e){			
			string msg = QueryCreator.unquotedstrvalue(DateTime.Now,true)+"\r";
			Debug.Write(e+" at ",msg);
			//Debug.Flush();
		}

		public void SelectTipoClassMovimenti(){		
            //MarkEvent("SelectTipoClassMovimenti START");
			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
            //MarkEvent("Current Row was got...");
			if (!res) {
                //MarkEvent("SelectTipoClassMovimenti STOP0");
				return;
			}
			if (CurrTipoClass!=null) {
                HelpForm.SetLastSelected(CurrTipoClass.Table,CurrTipoClass);
			    string f = QHC.CmpEq("!idsorkind", CurrTipoClass["idsorkind"]);
			    ImpClass.ExtendedProperties["CustomParentRelation"] = f;
                //if (DGridDettagliClassificazioni.DataSource==null)
                Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
                //MarkEvent("SelectTipoClassMovimenti STOP1");
				return;
			}
			if (T.Rows.Count==0) {
                //MarkEvent("SelectTipoClassMovimenti STOP2");
				return;
			}
		    if (DGridDettagliClassificazioni.VisibleRowCount > 0) {
                DGridDettagliClassificazioni.CurrentRowIndex = 0;
            }			
			Meta.myHelpForm.ControlChanged(DGridClassificazioni, null);
			res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out CurrTipoClass);
			//			ManageTipoClassMovimentiRowChanged(ImportoPerClassificazione, 
			//										CurrTipoClass);
            //MarkEvent("SelectTipoClassMovimenti STOP-");
		}

		public void EnterTabClassificazioni(int faseinizio, int fasefine){
			if (Meta.IsEmpty) return;
			RicalcolaTipoClassificazioni(faseinizio, fasefine, false);
			//DGridDettagliClassificazioni.DataSource=null;
			CalcolaTotaliClassificazioni();
			SelectTipoClassMovimenti();

		}

		public void CalcolaTotaliClassificazioni(){
			foreach (DataRow TR in TipoClassMovimenti.Rows) {
				decimal importo=0;
				string filter= QHC.CmpEq("idsorkind", TR["idsorkind"]);
				string expression= TR["totalexpression"].ToString();
				if (expression=="")expression="SUM(amount)";
                string filterMovSor = QHC.FieldIn("idsor", ClassMovimenti.Select(filter));
				object importoo = null;
				try {
                    importoo = ImpClass.Compute(expression, filterMovSor);
				}
				catch {
				}
				importo = GetNoNullDecimal(importoo);
				//				DataRow [] classified = ImpClass.Select(filter);
				//				foreach (DataRow IMP in classified) {
				//					if (IMP.RowState== DataRowState.Deleted)continue;
				//					if (IMP["importo"]!=DBNull.Value) {
				//						importo+= Convert.ToDecimal(IMP["importo"]);
				//					}
				//				}
				TR["!importo"]=importo;
				TR.AcceptChanges();
			}

		}

		public void ManageTipoClassMovimentiRowChanged(decimal ImportoPerClassificazione,
			DataRow Curr) {
			if (Curr==null) {
				btnEditClass.Enabled=false;
				btnInsertClass.Enabled=false;
				btnDelClass.Enabled=false;
				return;
			}
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;
			
			//CalcImpClassMovDefaults(ImportoPerClassificazione);

			CalcImpClassMovHeaders(ImportoPerClassificazione);			
		}


		/// <summary>
		/// Calcola i valori di default e impostazioni di autoincremento 
		///  per il codicetipoclass corrente.
		///  Da chiamare prima di effettuare un insert o un edit
		/// </summary>
		/// <param name="ImportoPerClassificazione"></param>
		public void CalcImpClassMovDefaults(decimal ImportoPerClassificazione) {
			DataTable T;
			DataRow Curr;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, 
				out T, out Curr);
			if (Curr==null)return;

            //ImpClass.Columns["idsorkind"].DefaultValue= Curr["idsorkind"];

//			if (Curr["flagsubmovimento"].ToString().ToLower()=="c") {
//				DisabilitaSubMovimenti();
//				MetaData.SetDefault(ImpClass,"submovimento","1");
//			}
//			else {
				AbilitaSubMovimenti();
//			}
			DataRow CurrMov = Movimento.Rows[0];
			DataRow CurrImputazioneMOv = ImputazioneMovimento.Rows[0];
            string f = QHC.CmpEq("idsorkind", Curr["idsorkind"]);
            
			decimal importoclassificato= GetNoNullDecimal( ImpClass.Compute("SUM(amount)",
				QHC.FieldIn("idsor", ClassMovimenti.Select(f))));
			
			decimal importototale  = ImportoPerClassificazione;
			decimal importoresiduo = importototale-importoclassificato;
			/*
			  if (Curr["!importo"]!=DBNull.Value) 
				importoresiduo -= Convert.ToDecimal(Curr["!importo"]);
			*/
			if (Curr["totalexpression"].ToString()=="")
				ImpClass.Columns["amount"].DefaultValue = importoresiduo;
			else 
				ImpClass.Columns["amount"].DefaultValue = 0;

			ImpClass.ExtendedProperties["importoresiduo"]= importoresiduo;
			ImpClass.ExtendedProperties["importototale"]= importototale;
			btnEditClass.Enabled=true;
			btnInsertClass.Enabled=true;
			btnDelClass.Enabled=true;
		}


		void DisabilitaSubMovimenti() {
			RowChange.ClearAutoIncrement(ImpClass.Columns["idsubclass"]);
		}
		void AbilitaSubMovimenti() {
			RowChange.MarkAsAutoincrement(
				ImpClass.Columns["idsubclass"], 
				null,
				null,
				7,
				false);
            if (ImpClass.Columns.Contains("idpettycash")) {
                RowChange.SetSelector(ImpClass, "idpettycash");
                RowChange.SetSelector(ImpClass, "yoperation");
                RowChange.SetSelector(ImpClass, "noperation");
            }
            if (ImpClass.Columns.Contains(idmovimento)) {
                RowChange.SetSelector(ImpClass, idmovimento);
            }
			RowChange.SetSelector(ImpClass, "idsor");
		}


		/// <summary>
		/// Calcs column names of impclassspesa grid and freshes grid
		/// </summary>
		void CalcImpClassMovHeaders(decimal importoperclassificazione) {
			DataTable T;
			DataRow Curr;
            //MarkEvent("CalcImpClassMovHeaders START");

			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out Curr);
			if (Curr==null)return;

			for (int i=1; i<=5; i++) {
				ImpClass.Columns["valuen"+i.ToString()].Caption=
					Curr["labeln"+i.ToString()].ToString();
				ImpClass.Columns["values"+i.ToString()].Caption=
					Curr["labels"+i.ToString()].ToString();				
				ImpClass.Columns["valuev"+i.ToString()].Caption=
					Curr["labelv"+i.ToString()].ToString();				

			}

			RefillDettagliClassificazioni(importoperclassificazione);
            //MarkEvent("CalcImpClassMovHeaders STOP");
		}


        public static DataTable CalcTipoClassAllowed(DataAccess Conn, DataTable Movimento, DataTable ImputazioneMovimento,
                            DataRow CurrImpClass, DataTable TipoClassMovimenti) {

            if (CurrImpClass.RowState == DataRowState.Deleted) return null;

            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Conn.GetQueryHelper();

            object idsorkind = Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", CurrImpClass["idsor"]), "idsorkind");
            string filter = QHS.CmpEq("idsorkind", idsorkind);
            DataRow[] CurrTipoClassS = TipoClassMovimenti.Select(filter);
            DataRow CurrTipoClass = null;
            if (CurrTipoClassS.Length > 0) CurrTipoClass = CurrTipoClassS[0];

            if (CurrTipoClass == null) return null;


            DataTable ImpClass = CurrImpClass.Table;
            string idmovimento;
            if (Movimento.TableName == "expense") {
                //VarMovimento = Meta.DS.Tables["expensevar"];
                idmovimento = "idexp";
            }
            else {
                //VarMovimento = Meta.DS.Tables["incomevar"];
                idmovimento = "idinc";
            }


            string filteridexp = QHC.CmpEq(idmovimento, CurrImpClass[idmovimento]);
            DataRow CurrMov = Movimento.Select(filteridexp)[0];
            DataRow CurrImputazioneMov = ImputazioneMovimento.Select(filteridexp)[0];
            decimal curramount = GetNoNullDecimal(CurrImputazioneMov["amount"]);
            int currfase = GetNoNullInt32(CurrMov["nphase"]); ;
            object IDForSP = DBNull.Value;
            if (CurrImputazioneMov.RowState != DataRowState.Added) IDForSP = CurrMov[idmovimento];


            DataTable TipoClassAllowed = null;
            DataSet OutDS = null;


            string sp_root_tipo = "compute_root_sortingkind_" + Movimento.TableName;

            //Calls sp_root_tipoclasses_spesa to get roots classes available
            OutDS = Conn.CallSP(sp_root_tipo,
                new object[8] {Conn.GetSys("esercizio"),
									   IDForSP,
									   CurrMov["idreg"],
									   CurrImputazioneMov["idupb"],
									   CurrMov["nphase"],
									   CurrImputazioneMov["idfin"],
									   CurrMov["idman"],
									   curramount
								   });

            if (OutDS != null && OutDS.Tables.Count > 0) {
                if (TipoClassAllowed == null) {
                    TipoClassAllowed = OutDS.Tables[0];
                }
                else {
                    TipoClassAllowed.Clear();
                    QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                }

            }

            //			DS.classmovimenti.Clear();
            //			DS.tipoclassmovimenti.Clear();
            //			QueryCreator.MergeDataTable(DS.tipoclassmovimenti, OutDS.Tables[0]);
            //			DS.tipoclassmovimenti.AcceptChanges();

            //foreach (DataRow CurrImpClass in ImpClass.Select(filteridexp)) {
            //    if (CurrImpClass.RowState == DataRowState.Deleted) continue;
            try {
                OutDS = Conn.CallSP(
                    "compute_filtered_sortingkind_" + Movimento.TableName,
                    new object[32]{Conn.GetSys("esercizio"),
										  IDForSP,
										  CurrMov["idreg"],
										  CurrImputazioneMov["idupb"],
										  currfase,
										  CurrImputazioneMov["idfin"],
										  CurrMov["idman"],
										  CurrImputazioneMov["amount"],
										  CurrTipoClass["idsorkind"],
										  CurrImpClass["idsor"],
										  CurrImpClass["idsubclass"],
										  CurrImpClass["amount"],
										  CurrImpClass["description"],
										  CurrImpClass["flagnodate"],
										  CurrImpClass["tobecontinued"],
										  CurrImpClass["start"],
										  CurrImpClass["stop"],
										  CurrImpClass["valuen1"],
										  CurrImpClass["valuen2"],
										  CurrImpClass["valuen3"],
										  CurrImpClass["valuen4"],
										  CurrImpClass["valuen5"],
										  CurrImpClass["values1"],
										  CurrImpClass["values2"],
										  CurrImpClass["values3"],
										  CurrImpClass["values4"],
										  CurrImpClass["values5"],
										  CurrImpClass["valuev1"],
										  CurrImpClass["valuev2"],
										  CurrImpClass["valuev3"],
										  CurrImpClass["valuev4"],
										  CurrImpClass["valuev5"]
									  });
            }
            catch (Exception E) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
            }
            if ((OutDS != null) && (OutDS.Tables.Count > 0)) {
                if (TipoClassAllowed == null) {
                    TipoClassAllowed = OutDS.Tables[0];
                }
                else {
                    QueryCreator.MergeDataTable(TipoClassAllowed, OutDS.Tables[0]);
                }
            }

            QueryCreator.MergeDataTable(TipoClassAllowed, TipoClassMovimenti);
            //foreach (DataRow CurrKind in TipoClassAllowed.Select(
            //    QHC.AppOr(QHC.CmpLt(codicefase, faseinizio), QHC.CmpGt(codicefase, fasemovfine))
            //    )) {
            //    CurrKind.Delete();
            //}
            TipoClassAllowed.AcceptChanges();
            return TipoClassAllowed;

        }


        public static void CalcAutoClasses(MetaData Meta,  DataTable Movimento, DataTable ImputazioneMovimento,
                                DataRow CurrImpClass, DataRow CurrTipoClass) {
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
            DataTable ImpClass = CurrImpClass.Table;
            string idmovimento;
            string codicefase;
            if (Movimento.TableName == "expense") {
                //VarMovimento = Meta.DS.Tables["expensevar"];
                idmovimento = "idexp";
                codicefase = "nphaseexpense";
            }
            else {
                //VarMovimento = Meta.DS.Tables["incomevar"];
                idmovimento = "idinc";
                codicefase = "nphaseincome";
            }


            string filteridexp = QHC.CmpEq(idmovimento, CurrImpClass[idmovimento]);
            DataRow CurrMov = Movimento.Select(filteridexp)[0];
            DataRow CurrImputazioneMov = ImputazioneMovimento.Select(filteridexp)[0];
            decimal curramount = GetNoNullDecimal(CurrImputazioneMov["amount"]);
            int currfase =   GetNoNullInt32(CurrTipoClass[codicefase]); 
            object IDForSP = DBNull.Value;
            if (CurrImputazioneMov.RowState!= DataRowState.Added) IDForSP = CurrMov[idmovimento];
            DataSet OutDS;
            try {
                OutDS = Meta.Conn.CallSP("create_autoclasses_" + Movimento.TableName,
                    new object[]{	  
									Meta.GetSys("esercizio"),
									IDForSP,
									CurrMov["idreg"],
						            CurrImputazioneMov["idupb"],			
									currfase,
									CurrImputazioneMov["idfin"],
									CurrMov["idman"],
									curramount,
                                    //CurrImpClass["idsorkind"],
									CurrImpClass["idsor"],
									CurrImpClass["idsubclass"],
									CurrImpClass["amount"],
									CurrImpClass["description"],
									CurrImpClass["flagnodate"],
									CurrImpClass["tobecontinued"],
									CurrImpClass["start"],
									CurrImpClass["stop"],
									CurrImpClass["valuen1"],
									CurrImpClass["valuen2"],
									CurrImpClass["valuen3"],
									CurrImpClass["valuen4"],
									CurrImpClass["valuen5"],
									CurrImpClass["values1"],
									CurrImpClass["values2"],
									CurrImpClass["values3"],
									CurrImpClass["values4"],
									CurrImpClass["values5"],
									CurrImpClass["valuev1"],
									CurrImpClass["valuev2"],
									CurrImpClass["valuev3"],
									CurrImpClass["valuev4"],
									CurrImpClass["valuev5"]
								});
            }
            catch (Exception E) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
                return;
            }
            if ((OutDS == null) || (OutDS.Tables.Count == 0)) return; //no autoclass

            //AbilitaSubMovimenti();
            RowChange.MarkAsAutoincrement(   ImpClass.Columns["idsubclass"],    null,    null,    7,    false);
            RowChange.SetSelector(ImpClass, idmovimento);
            RowChange.SetSelector(ImpClass, "idsor");


            string filtercl=  QHS.AppAnd(QHS.CmpEq(codicefase, currfase), QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                            QHS.NullOrGe("stop", Meta.GetSys("esercizio")));
            DataTable TipoClassMovimenti = Meta.Conn.RUN_SELECT("sortingkind","*",null,filtercl,null,true);


            DataTable TipoClassAllowed = CalcTipoClassAllowed(Meta.Conn, Movimento, ImputazioneMovimento,
                            CurrImpClass, TipoClassMovimenti);

            DataTable AutoClasses = OutDS.Tables[0];
            //for every row in OutDS.Tables[0]:
            // - add row to impclassspesa
            // - evaluates temporary AutoIncrement fields
            foreach (DataRow AutoClass in AutoClasses.Rows) {
                object idSorKind = AutoClass["idsorkind"];

                if (TipoClassAllowed.Select(QHC.CmpEq("idsorkind", idSorKind)).Length == 0) continue;
                DataRow MyDR = ImpClass.NewRow();
                foreach (DataColumn DC in ImpClass.Columns) {
                    if (DC.ColumnName.StartsWith("!")) continue;
                    if (!ImpClass.Columns.Contains(DC.ColumnName)) continue;
                    MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
                }
                ///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
                if (MyDR[idmovimento] == DBNull.Value)
                    MyDR[idmovimento] = CurrMov[idmovimento];
                RowChange.CalcTemporaryID(MyDR);
                ImpClass.Rows.Add(MyDR);
                if (Movimento.TableName == "expense")
                    CalcFlag(MyDR, AutoClass["idsorkind"]);
                else
                    CalcFlag(MyDR, AutoClass["idsorkind"]);
            }
        }


		/// <summary>
		/// Calcola le classificazioni automatiche
		/// </summary>
		/// <param name="CurrImpClass"></param>
		void CalcAutoClasses(DataRow CurrImpClass, DataRow CurrTipoClass) {

			DataRow CurrMov = Movimento.Rows[0];
			DataRow CurrImputazioneMov = ImputazioneMovimento.Rows[0];
			decimal curramount= GetCurrImporto(CurrImputazioneMov);
			
			int currfase = GetNoNullInt32(CurrTipoClass[codicefase]);;

			object IDForSP = DBNull.Value;
			if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];

			DataSet OutDS;
			try {
				OutDS=	Meta.Conn.CallSP("create_autoclasses_"+Movimento.TableName,
					new object[]{	  
									Meta.GetSys("esercizio"),
									IDForSP,
									ManageCreditore.GetIDPerFase(currfase),
									ManageUPB.GetIDPerFase(currfase),
									currfase,
									ManageBilAnnuale.GetIDPerFase(currfase),
									CurrMov["idman"],
									curramount,
                                    //CurrImpClass["idsorkind"],
									CurrImpClass["idsor"],
									CurrImpClass["idsubclass"],
									CurrImpClass["amount"],
									CurrImpClass["description"],
									CurrImpClass["flagnodate"],
									CurrImpClass["tobecontinued"],
									CurrImpClass["start"],
									CurrImpClass["stop"],
									CurrImpClass["valuen1"],
									CurrImpClass["valuen2"],
									CurrImpClass["valuen3"],
									CurrImpClass["valuen4"],
									CurrImpClass["valuen5"],
									CurrImpClass["values1"],
									CurrImpClass["values2"],
									CurrImpClass["values3"],
									CurrImpClass["values4"],
									CurrImpClass["values5"],
									CurrImpClass["valuev1"],
									CurrImpClass["valuev2"],
									CurrImpClass["valuev3"],
									CurrImpClass["valuev4"],
									CurrImpClass["valuev5"]
								});
			}
			catch (Exception E) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
				return;
			}
			if ((OutDS==null)||(OutDS.Tables.Count==0)) return; //no autoclass

			AbilitaSubMovimenti();

			if (TipoClassAllowed == null) {//Risolvo presumo eccezione task 15589 error log n.559559 e altri
				string filtercl=  QHS.AppAnd(QHS.CmpEq(codicefase, currfase), QHS.NullOrLe("start", Meta.GetSys("esercizio")),
					QHS.NullOrGe("stop", Meta.GetSys("esercizio")));
				DataTable TipoClassMovimenti = Meta.Conn.RUN_SELECT("sortingkind","*",null,filtercl,null,true);


				TipoClassAllowed = CalcTipoClassAllowed(Meta.Conn, Movimento, ImputazioneMovimento,
					CurrImpClass, TipoClassMovimenti);
			}

			DataTable AutoClasses = OutDS.Tables[0];
			//for every row in OutDS.Tables[0]:
			// - add row to impclassspesa
			// - evaluates temporary AutoIncrement fields
			foreach (DataRow AutoClass in AutoClasses.Rows) {
                object idSorKind = AutoClass["idsorkind"];
               
                if (TipoClassAllowed.Select(QHC.CmpEq("idsorkind", idSorKind)).Length == 0) continue;
				DataRow MyDR =  ImpClass.NewRow();
				foreach(DataColumn DC in ImpClass.Columns) {
					if (DC.ColumnName.StartsWith("!")) continue;
                    if (!ImpClass.Columns.Contains(DC.ColumnName)) continue;
					MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
				}
				///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
				if (MyDR[idmovimento]==DBNull.Value) 
					MyDR[idmovimento]= CurrMov[idmovimento];
				RowChange.CalcTemporaryID(MyDR);
				ImpClass.Rows.Add(MyDR);		
				if (Movimento.TableName=="expense")
					CalcFlag(MyDR, AutoClass["idsorkind"]);
				else
                    CalcFlag(MyDR, AutoClass["idsorkind"]);
			}
		}

		decimal GetCurrImporto(DataRow CurrImputazioneMov){
			string idmov= CurrImputazioneMov[idmovimento].ToString();
			decimal importo= GetNoNullDecimal(CurrImputazioneMov["amount"]);
			if (VarMovimento==null)return importo;
			string filter="("+idmovimento+"="+QueryCreator.quotedstrvalue(idmov,false)+")";
			DataRow []var= VarMovimento.Select(filter);
			foreach (DataRow  R in var)
				importo+= GetNoNullDecimal(R["amount"]);
			return importo;
		}

        public bool DettagliConUnicaClass(DataTable dettCPassivo) {
            //bool uguali = true;
            Hashtable ht = new Hashtable();
            foreach (DataRow rDett in dettCPassivo.Select(QHS.IsNotNull("idsor_siope"))) {
                int idsor_siope = GetNoNullInt32(rDett["idsor_siope"]);
                if (ht.ContainsKey(idsor_siope)) {
                    ht[idsor_siope] = GetNoNullInt32(ht[idsor_siope]) + 1;
                }
                else {
                    ht[idsor_siope] = 1;
                }
            }
            if (ht.Count > 1) {
                return false;
            }
            else {
                return true;
            }
        }
        public void AggiungiClassDa_PettyCashInv(DataRow rPettycashoperation, DataTable dettFatt) {
            Hashtable htAmountClass = new Hashtable();
            foreach (DataRow rDett in dettFatt.Select(QHC.IsNotNull("idsor_siope"))) {
                int idsor_siope = GetNoNullInt32(rDett["idsor_siope"]);
                double rowtotal = GetNoNullDouble(rDett["rowtotal"]);
                decimal rowtotalDec = Convert.ToDecimal(rowtotal);
                AggiornaImporti(htAmountClass, idsor_siope, rowtotalDec);
            }
            AggiungiClassRow(htAmountClass,  rPettycashoperation);//R di pettycash
        }
        /// <summary>
        /// Metodo che classifica le Operazioni della piccola spesa e i mov. di Apertura/Chiusura
        /// </summary>
        /// <param name="Rop"></param>
        /// <param name="Rconfig"></param>
        /// <param name="idmov"></param>
        public void AggiungiClassDa_PettyCashOp(DataRow Rop, DataRow Rconfig, object idmov) {
			if(Rop == null) {
				return;
			}
            Hashtable htAmountClass = new Hashtable();
            byte flag = (byte)Rop["flag"];
            bool isSpesa = (flag & 8) != 0;
            bool isApertura = (flag & 1) != 0;
            bool isReintegro = (flag & 2) != 0;
            bool isChiusura = (flag & 4) != 0;
            // Apertura
            if (isApertura && Rconfig != null) {
                decimal amount = GetNoNullDecimal(Rconfig["amount"]);
                int idsor_siope = GetNoNullInt32(Rconfig["idsor_siopeexp"]);
                AggiornaImporti(htAmountClass, idsor_siope, amount);
                AggiungiClass(htAmountClass, idmov);//R di pettycash
            }
            // chiusura
            if (isChiusura && Rconfig != null) {
	            DataSet d = Rop.Table.DataSet;
	            decimal amount = CfgFn.GetNoNullDecimal( d.Tables["incomeyear"].Select(QHC.CmpEq("idinc", idmov))[0]["amount"] );
                int idsor_siope = GetNoNullInt32(Rconfig["idsor_siopeinc"]);
                AggiornaImporti(htAmountClass, idsor_siope, amount);
                AggiungiClass(htAmountClass, idmov);//R di pettycash
            }
            if (isSpesa) {
                //Sta classificando le piccole spese. Poi in fase di reintegro, copia le class. delle operazioni sui pagamenti generati dal reintegro
                if (Rop["idsor_siope"] != null) {
                    int idsor_siope = GetNoNullInt32(Rop["idsor_siope"]);
                    decimal amount = GetNoNullDecimal(Rop["amount"]);
                    AggiornaImporti(htAmountClass, idsor_siope, amount);
                    AggiungiClassRow(htAmountClass,  Rop);//R di pettycash
                    return;
                }
            }
        }
        public void AggiungiClassDa_PettyCashCompenso(DataRow rPettycashoperation, DataTable tCompenso) {
            DataRow rCompenso = tCompenso.Rows[0];
            int idsor_siope = GetNoNullInt32(rCompenso["idsor_siope"]);
            decimal curramount = GetNoNullDecimal(rPettycashoperation["amount"]);
            Hashtable htAmountClass = new Hashtable();
            AggiornaImporti(htAmountClass, idsor_siope, curramount);
            AggiungiClassRow(htAmountClass,   rPettycashoperation);
        }
        // - add row to impclassspesa
        //Hashtable htAmountClassInv = new Hashtable();
        /// <summary>
        /// ClassificaTramiteClassDocumento
        /// </summary>
        /// <param name="DS_toclassify">E' il DS da classificare, in cui sono presenti le tabelle Expensesorted/Incomesorted. 
        ///                                     In entrata e spesa è il DS principale, mentre nei wizard è il DS di GestioneAutomatismi.
        /// </param>
        /// <param name="DSsource">E' il DS in cui sono presenti i documenti contabilizzati, che nei wizard è diverso da DS_toclassify. </param>

        public void ClassificaTramiteClassDocumento(DataSet DS_toclassify, DataSet DSsource) {
            if (Meta.PrimaryDataTable.TableName == "expense"){
                Movimento = DS_toclassify.Tables["expense"];
                ImputazioneMovimento = DS_toclassify.Tables["expenseyear"];
                VarMovimento = DS_toclassify.Tables["expensevar"];
                MetaData mExpSorted = Meta.Dispatcher.Get("expensesorted");
                ImpClass = DS_toclassify.Tables["expensesorted"];
                mExpSorted.SetDefaults(ImpClass);
                idmovimento = "idexp";
                codicefase = "nphaseexpense";
            }
            if ((Meta.PrimaryDataTable.TableName == "income") || (Meta.PrimaryDataTable.TableName == "no_table")) {
                Movimento = DS_toclassify.Tables["income"];
                ImputazioneMovimento = DS_toclassify.Tables["incomeyear"];
                MetaData mincSorted = Meta.Dispatcher.Get("incomesorted");
                ImpClass = DS_toclassify.Tables["incomesorted"];
                mincSorted.SetDefaults(ImpClass);
                VarMovimento = DS_toclassify.Tables["incomevar"];
                idmovimento = "idinc";
                codicefase = "nphaseincome";
                }

            if ((Meta.PrimaryDataTable.TableName == "pettycashoperation") && DSsource==null) {
                //Sta classificando l'operazione di piccola spesa
                Movimento = DS_toclassify.Tables["pettycashoperation"];                
                ImputazioneMovimento = DS_toclassify.Tables["pettycashoperation"];
                MetaData petSorted = Meta.Dispatcher.Get("pettycashoperationsorted");
                ImpClass = DS_toclassify.Tables["pettycashoperationsorted"];
                petSorted.SetDefaults(ImpClass);
                codicefase = "nphaseexpense";
            }
            bool isApertura = false;
            bool isChiusura = false;
            //Classifica i movimenti finanziari entrata/spesa, generati dalla Apertura/Chiusura del fondo economale
            if ((Meta.PrimaryDataTable.TableName == "pettycashoperation") && DSsource != null) {
                DataRow rPettycashoperation = DSsource.Tables["pettycashoperation"].Rows[0];
                byte flag = (byte)rPettycashoperation["flag"];
                isApertura = (flag & 1) != 0;
                isChiusura = (flag & 4) != 0;
                if (DSsource != null && isApertura) {
                    Movimento = DS_toclassify.Tables["expense"];
                    ImputazioneMovimento = DS_toclassify.Tables["expenseyear"];
                    MetaData expSorted = Meta.Dispatcher.Get("expensesorted");
                    ImpClass = DS_toclassify.Tables["expensesorted"];
                    expSorted.SetDefaults(ImpClass);
                    idmovimento = "idexp";
                }
                if (DSsource != null && isChiusura) {
                    Movimento = DS_toclassify.Tables["income"];
                    ImputazioneMovimento = DS_toclassify.Tables["incomeyear"];
                    MetaData incSorted = Meta.Dispatcher.Get("incomesorted");
                    ImpClass = DS_toclassify.Tables["incomesorted"];
                    incSorted.SetDefaults(ImpClass);
                    idmovimento = "idinc";
                }
            }
        
            TipoClassMovimenti = DS_toclassify.Tables["sortingkind"];
            ClassMovimenti = DS_toclassify.Tables["sorting"];
            AbilitaSubMovimenti();
            bool insertMode = false;
            if (Meta.PrimaryDataTable.TableName == "pettycashoperation") {
                DataRow CurrMov = Movimento.Rows[0];
                object Curr_idexpidinc;
                DataRow CurrImputazioneMov = ImputazioneMovimento.Rows[0];

                if (DS_toclassify != null && DS_toclassify.Tables.Contains("pettycashoperation") && DS_toclassify.Tables["pettycashoperation"].Select(QHC.IsNotNull("idsor_siope")).Length> 0) {
                    //Classifica le operazioni delle piccole spese
                    DataRow rPettycashoperation = DS_toclassify.Tables["pettycashoperation"].Rows[0];
                    AggiungiClassDa_PettyCashOp(rPettycashoperation, null, null);
                    return;
                }
                if (DSsource != null && isApertura) {
                    //Movimento di apertura
                    DataRow rPettycashoperation = DSsource.Tables["pettycashoperation"].Rows[0];
                    DataRow[] Conf = DSsource.Tables["pettycashsetup"].Select(QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")), QHC.CmpEq("idpettycash", rPettycashoperation["idpettycash"])));
                    DataRow Rexpensemax = Movimento.Select(QHC.CmpEq("nphase", GetNoNullInt32(Meta.GetSys("maxexpensephase"))))[0];
                    Curr_idexpidinc = Rexpensemax[idmovimento];
                    AggiungiClassDa_PettyCashOp(rPettycashoperation, Conf[0], Curr_idexpidinc);
                    return;
                }
                if (DSsource != null && isChiusura) {
                    //Movimento di chiusura
                    DataRow rPettycashoperation = DSsource.Tables["pettycashoperation"].Rows[0];
                    DataRow[] Conf = DSsource.Tables["pettycashsetup"].Select(QHC.AppAnd(QHC.CmpEq("ayear", Meta.GetSys("esercizio")), QHC.CmpEq("idpettycash", rPettycashoperation["idpettycash"])));
                    
                    foreach (DataRow Rincomemax in Movimento.Select(QHC.CmpEq("nphase",
	                    GetNoNullInt32(Meta.GetSys("maxincomephase"))))) {
	                    Curr_idexpidinc = Rincomemax[idmovimento];
	                    AggiungiClassDa_PettyCashOp(rPettycashoperation, Conf[0], Curr_idexpidinc);
                    }
                    
                    return;
                }
                //Cerca contabilizzazioni di Fatture col Fondo Economale
                if (DS_toclassify != null && DS_toclassify.Tables.Contains("invoice") && DS_toclassify.Tables["invoice"].Rows.Count> 0) {
                    DataRow rInv = DS_toclassify.Tables["invoice"].Rows[0];
                    string filter = QHS.AppAnd(QHS.CmpEq("idinvkind", rInv["idinvkind"]), QHS.CmpEq("yinv", rInv["yinv"]), QHS.CmpEq("ninv", rInv["ninv"]));
                    DataTable dettFatt = Meta.Conn.RUN_SELECT("invoicedetailview", "rowtotal, idsor_siope", null, filter, null, false);
                    DataRow rPettycashoperation = DS_toclassify.Tables["pettycashoperation"].Rows[0];
                    AggiungiClassDa_PettyCashInv(rPettycashoperation, dettFatt);
                    return;
                }
                //Cerca contabilizzazioni Missioni col Fondo Economale
                if (DS_toclassify != null && DS_toclassify.Tables.Contains("iditineration") && DS_toclassify.Tables["iditineration"].Rows.Count > 0) {
                    DataTable tMissione = DS_toclassify.Tables["iditineration"];
                    DataRow rPettycashoperation = DS_toclassify.Tables["pettycashoperation"].Rows[0];
                    AggiungiClassDa_PettyCashCompenso(rPettycashoperation, tMissione);
                    return;
                }
                //Cerca contabilizzazioni Occasionali col Fondo Economale
                if (DS_toclassify != null && DS_toclassify.Tables.Contains("casualcontract") && DS_toclassify.Tables["casualcontract"].Rows.Count > 0) {
                    DataTable tCasualcontract = DS_toclassify.Tables["casualcontract"];
                    DataRow rPettycashoperation = DS_toclassify.Tables["pettycashoperation"].Rows[0];
                    AggiungiClassDa_PettyCashCompenso(rPettycashoperation, tCasualcontract);
                    return;
                }
                //Cerca contabilizzazioni Professionali col Fondo Economale
                if (DS_toclassify != null && DS_toclassify.Tables.Contains("profservice") && DS_toclassify.Tables["profservice"].Rows.Count > 0) {
                    DataTable tProfessionale = DS_toclassify.Tables["profservice"];
                    DataRow rPettycashoperation = DS_toclassify.Tables["pettycashoperation"].Rows[0];
                    AggiungiClassDa_PettyCashCompenso(rPettycashoperation, tProfessionale);
                    return;
                }
                return;
            }
            //Questo metodo viene chiamato da Spesa SOLO in ultima fase, o se l'ultima fase è compresa
            if (Meta.PrimaryDataTable.TableName == "expense") {
                // int fasespesamax = GetNoNullInt32(Meta.GetSys("maxexpensephase"));
                //foreach (DataRow CurrMov in Movimento.Select(QHC.CmpEq("nphase", fasespesamax))) {
                foreach (DataRow CurrMov in Movimento.Select()) {
                    Hashtable htAmountClassInv=new Hashtable();
                    object Curr_idexpidinc = CurrMov["idexp"];
                    bool nonLeggereDaDb = false;
                    object parid = CurrMov["parentidexp"];
                    while (parid != DBNull.Value) {
                        DataRow[] parent = Movimento.Select(QHC.CmpEq("idexp", parid));
                        if (parent.Length > 0) {
                            if (parent[0].RowState == DataRowState.Added) {
                                parid = parent[0]["parentidexp"];
                                continue;
                            }

                            break;
                        }
                        break;
                    }

                    object idExpFaseImpegno = DBNull.Value;
                    if (parid != DBNull.Value) {
                        idExpFaseImpegno = Meta.Conn.DO_READ_VALUE("expenselink", QHS.AppAnd(
                            QHS.CmpEq("idchild", parid),
                            QHS.CmpEq("nlevel", Meta.Conn.GetSys("itinerationphase"))), "idparent");
                    }

                    if (idExpFaseImpegno == DBNull.Value || idExpFaseImpegno==null) {
                        nonLeggereDaDb = true;
                    }

                    DataRow CurrImputazioneMov = ImputazioneMovimento.Select(QHC.CmpEq(idmovimento, Curr_idexpidinc))[0];
                    decimal curramount = GetCurrImporto(CurrImputazioneMov);

                    //Verifica la presenza di Contabilizzazioni dett. Fattura
                    if ((DS_toclassify.Tables.Contains("expenseinvoice") &&
                         (DS_toclassify.Tables["expenseinvoice"].Rows.Count > 0))
                        ||
                        (DSsource != null && DSsource.Tables.Contains("expenseinvoice") &&
                         (DSsource.Tables["expenseinvoice"].Rows.Count > 0))) {
                        DataRow rExpenseinvoice = null;
                        if (DS_toclassify.Tables.Contains("expenseinvoice") &&
                            DS_toclassify.Tables["expenseinvoice"].Rows.Count > 0) {
                            rExpenseinvoice = DS_toclassify.Tables["expenseinvoice"].Rows[0];
                        }
                        if (DSsource != null && DSsource.Tables.Contains("expenseinvoice") &&
                            DSsource.Tables["expenseinvoice"].Rows.Count > 0) {
                            rExpenseinvoice = DSsource.Tables["expenseinvoice"].Rows[0];
                        }

                        int movkind = GetNoNullInt32(rExpenseinvoice["movkind"]);
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("invoicedetail") &&
                            (DS_toclassify.Tables["invoicedetail"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetail", "invoicedetail", movkind,DS_toclassify,"idexp");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                        if (DS_toclassify.Tables.Contains("invoicedetailview") &&
                            (DS_toclassify.Tables["invoicedetailview"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv,Curr_idexpidinc, "invoicedetailview", "invoicedetailview",
                                movkind, DS_toclassify, "idexp");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }

                        if (DS_toclassify.Tables.Contains("invoicedetail_taxable") &&
                            (DS_toclassify.Tables.Contains("invoicedetail_iva"))) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv,Curr_idexpidinc, "invoicedetail_taxable",
                                "invoicedetail_iva", movkind, DS_toclassify, "idexp");
                            //Aggiunge la classificazione della NC
                            if (DS_toclassify.Tables.Contains("invoicedetail_taxable_nc") &&
                                (DS_toclassify.Tables.Contains("invoicedetail_iva_nc"))) {
                                AggiungiClassDa_DettaglioFattura(htAmountClassInv,Curr_idexpidinc, "invoicedetail_taxable_nc",
                                    "invoicedetail_iva_nc", movkind, DS_toclassify, "idexp");
                            }
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }

                        //Siamo nel wizard, e la fattura è presente in DSsource
                        if (DSsource != null && DSsource.Tables.Contains("invoicedetail") &&
                            (DSsource.Tables["invoicedetail"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv,Curr_idexpidinc, "invoicedetail", "invoicedetail", movkind,
                                DSsource, "idexp");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }

                        if (DSsource != null && DSsource.Tables.Contains("invoicedetailview") &&
                            (DSsource.Tables["invoicedetailview"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv,Curr_idexpidinc, "invoicedetailview", "invoicedetailview",
                                movkind, DSsource, "idexp");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                        if (DSsource != null && DSsource.Tables.Contains("invoicedetail_taxable") &&
                            (DSsource.Tables.Contains("invoicedetail_iva"))) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv,Curr_idexpidinc, "invoicedetail_taxable",
                                "invoicedetail_iva", movkind, DSsource, "idexp");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                    }
                    else {
                        //Verifica la presenza di Contabilizzazioni dett. Contratto Passivo
                        if (DS_toclassify.Tables.Contains("expensemandate") &&
                            DS_toclassify.Tables["expensemandate"].Rows.Count > 0) {
                            //Siamo in _procedura, legge dal DS
                            DataRow rExpensemandate = DS_toclassify.Tables["expensemandate"].Rows[0];
                            int movkind = GetNoNullInt32(rExpensemandate["movkind"]);
                            if (DS_toclassify.Tables.Contains("mandatedetailview") &&
                                DS_toclassify.Tables["mandatedetailview"].Rows.Count > 0) {
                                AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetailview", "mandatedetailview",
                                    null, movkind, DS_toclassify, curramount);
                                continue;
                            }
                            if (DS_toclassify.Tables.Contains("mandatedetail_taxable") &&
                                DS_toclassify.Tables.Contains("mandatedetail_iva")) {
                                AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetail_taxable", "mandatedetail_iva",
                                    null, movkind, DS_toclassify, curramount);
                                continue;
                            }
                        }
                        else {
                            //Stiamo creando un Pagamento usando un Impegno che contabilizza un CP
                            if (!nonLeggereDaDb && idExpFaseImpegno !=DBNull.Value) {
                                DataTable dettCPassivo = Meta.Conn.RUN_SELECT("mandatedetailview",
                                    "idexp_iva, idexp_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope, mankind, nman, yman",
                                    null,
                                    QHS.AppAnd(
                                        QHS.AppOr(QHS.CmpEq("idexp_taxable", idExpFaseImpegno),
                                            QHS.CmpEq("idexp_iva", idExpFaseImpegno)), QHS.IsNull("stop")), null,
                                    false);
                                if (dettCPassivo != null && dettCPassivo.Rows.Count > 0) {
                                    object rowtotal = Meta.Conn.DO_READ_VALUE("mandatedetailview",
                                        QHS.AppAnd(QHS.CmpEq("idexp_taxable", idExpFaseImpegno), QHS.IsNull("stop")),
                                        "sum(rowtotal)");
                                    decimal rowtotalDec = GetNoNullDecimal(rowtotal);
                                    if (rowtotalDec == curramount) {
                                        AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, null, null, dettCPassivo, 1,
                                            DS_toclassify, curramount);
                                        continue;
                                    }

                                    if ((rowtotalDec != curramount)) { //&& DettagliConUnicaClass(dettCPassivo) 11973
                                        AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, null, null, dettCPassivo, 1,
                                            DS_toclassify, curramount);
                                        continue;
                                    }
                                }
                            }
							else {
								if ((monofase && DS_toclassify.Tables.Contains("mandatedetail") &&
										DS_toclassify.Tables["mandatedetail"].Rows.Count > 0)
										||
										(monofase && DSsource != null && DSsource.Tables.Contains("mandatedetail") &&
										(DSsource.Tables["mandatedetail"].Rows.Count > 0))) {
									DataRow rExpenseMandate = null;

									if (DS_toclassify.Tables.Contains("mandatedetail") &&
											DS_toclassify.Tables["mandatedetail"].Rows.Count > 0) {
										rExpenseMandate = DS_toclassify.Tables["expensemandate"].Rows[0];
									}
									if (DSsource != null && DSsource.Tables.Contains("mandatedetail") &&
										DSsource.Tables["mandatedetail"].Rows.Count > 0) {
										rExpenseMandate = DSsource.Tables["expensemandate"].Rows[0];
									}
									int movkindS = GetNoNullInt32(rExpenseMandate["movkind"]);
									//Siamo nel mono fase e dobbiamo risalire al Contratto Attivo/Passivo dalla tabella mandatedetail
									/*-----------------*/
									if (DS_toclassify.Tables.Contains("mandatedetailview") &&
									(DS_toclassify.Tables["mandatedetailview"].Rows.Count > 0)) {
										string filterdettCA = "";
										foreach (DataRow RR in DS_toclassify.Tables["mandatedetailview"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("mandatedetailview", "idexp_iva, idexp_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetailview", "mandatedetailview", dettCA, movkindS, DS_toclassify, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									if (DS_toclassify.Tables.Contains("mandatedetail_taxable") &&
										(DS_toclassify.Tables.Contains("mandatedetail_iva"))) {
										string filterdettCA = "";
										foreach (DataRow RR in DS_toclassify.Tables["mandatedetail_taxable"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										foreach (DataRow RR in DS_toclassify.Tables["mandatedetail_iva"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("mandatedetailview", "idexp_iva, idexp_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetail_taxable", "mandatedetail_iva", dettCA, movkindS, DS_toclassify, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									if (DSsource != null && DSsource.Tables.Contains("mandatedetail") &&
										(DSsource.Tables["mandatedetail"].Rows.Count > 0)) {
										string filterdettCA = "";
										foreach (DataRow RR in DSsource.Tables["mandatedetail"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("mandatedetailview", "idexp_iva, idexp_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetail", "mandatedetail", dettCA, movkindS, DSsource, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}

									if (DSsource != null && DSsource.Tables.Contains("mandatedetailview") &&
										(DSsource.Tables["mandatedetailview"].Rows.Count > 0)) {
										string filterdettCA = "";
										foreach (DataRow RR in DSsource.Tables["mandatedetailview"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("mandatedetailview", "idexp_iva, idexp_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetailview", "mandatedetailview", dettCA, movkindS, DSsource, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									if (DSsource != null && DSsource.Tables.Contains("mandatedetail_taxable") &&
										(DSsource.Tables.Contains("mandatedetail_iva"))) {
										string filterdettCA = "";
										foreach (DataRow RR in DSsource.Tables["mandatedetail_taxable"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										foreach (DataRow RR in DSsource.Tables["mandatedetail_iva"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("mandatedetailview", "idexp_iva, idexp_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "mandatedetail_taxable", "mandatedetail_iva", dettCA, movkindS, DSsource, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									/*----------------*/
								}
							}
						}
                    }
                    //Verifica la presenza di Contabilizzazioni di Compensi Occasionali
                    if (DS_toclassify.Tables.Contains("expensecasualcontract") &&
                        DS_toclassify.Tables["expensecasualcontract"].Rows.Count > 0) {
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("casualcontract") &&
                            DS_toclassify.Tables["casualcontract"].Rows.Count > 0) {
                            AggiungiClassDa_Compenso(Curr_idexpidinc, curramount,
                                DS_toclassify.Tables["casualcontract"], DS_toclassify);
                            continue;
                        }
                    }
                    else {
                        //Stiamo creando un Pagamento usando un Impegno che contabilizza un Comp.Occasionale, legge dal DB
                        if (!nonLeggereDaDb  && idExpFaseImpegno !=DBNull.Value) {
                            DataTable contOccasionale = Meta.Conn.RUN_SELECT("expensecasualcontractview",
                                "ycon,ncon, idexp ", null, QHS.CmpEq("idexp", idExpFaseImpegno), null, false);
                            if (contOccasionale != null && contOccasionale.Rows.Count > 0) {
                                DataRow rExpCon = contOccasionale.Rows[0];
                                object ycon = rExpCon["ycon"];
                                object ncon = rExpCon["ncon"];
                                DataTable tOccasionale = Meta.Conn.RUN_SELECT("casualcontract", "idsor_siope", null,
                                    QHS.AppAnd(QHS.CmpEq("ycon", ycon), QHS.CmpEq("ncon", ncon)), null, false);
                                if (tOccasionale != null && tOccasionale.Rows.Count > 0) {
                                    AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, tOccasionale, DS_toclassify);
                                    continue;
                                }
                            }
                        }
                    }

                    //Verifica la presenza di Contabilizzazioni di Missioni
                    if (DS_toclassify.Tables.Contains("expenseitineration") &&
                        DS_toclassify.Tables["expenseitineration"].Rows.Count > 0) {
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("itineration") &&
                            DS_toclassify.Tables["itineration"].Rows.Count > 0) {
                            AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, DS_toclassify.Tables["itineration"],
                                DS_toclassify);
                            continue;
                        }
                    }
                    else {
                       if (!nonLeggereDaDb && idExpFaseImpegno != DBNull.Value) {
                            //Stiamo creando un Pagamento usando un Impegno che contabilizza una Missione, legge dal DB
                            DataTable contMissione = Meta.Conn.RUN_SELECT("expenseitinerationview",
                                "iditineration, idexp",
                                null, QHS.CmpEq("idexp", idExpFaseImpegno), null, false);
                            if (contMissione != null && contMissione.Rows.Count > 0) {
                                DataRow rExpCon = contMissione.Rows[0];
                                object iditineration = rExpCon["iditineration"];
                                DataTable tMissione = Meta.Conn.RUN_SELECT("itineration", "idsor_siope", null,
                                    QHS.CmpEq("iditineration", iditineration), null, false);
                                if (tMissione != null && tMissione.Rows.Count > 0) {
                                    AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, tMissione, DS_toclassify);
                                    continue;
                                }
                            }

                        }
                    }

                    //Verifica la presenza di Contabilizzazioni di Compensi Professionali
                    if (DS_toclassify.Tables.Contains("expenseprofservice") &&
                        DS_toclassify.Tables["expenseprofservice"].Rows.Count > 0) {
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("profservice") &&
                            DS_toclassify.Tables["profservice"].Rows.Count > 0) {
                            AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, DS_toclassify.Tables["profservice"],
                                DS_toclassify);
                            continue;
                        }
                    }
                    else {
                        if (!nonLeggereDaDb && idExpFaseImpegno != DBNull.Value) {
                            //Stiamo creando un Pagamento usando un Impegno che contabilizza un Comp.Professionale, legge dal DB
                            DataTable contProfessionale = Meta.Conn.RUN_SELECT("expenseprofserviceview",
                                "ycon,ncon, idexp",
                                null, QHS.CmpEq("idexp", idExpFaseImpegno), null, false);
                            if (contProfessionale != null && contProfessionale.Rows.Count > 0) {
                                DataRow rExpCon = contProfessionale.Rows[0];
                                object ycon = rExpCon["ycon"];
                                object ncon = rExpCon["ncon"];
                                DataTable tProfessionale = Meta.Conn.RUN_SELECT("profservice", "idsor_siope", null,
                                    QHS.AppAnd(QHS.CmpEq("ycon", ycon), QHS.CmpEq("ncon", ncon)), null, false);
                                if (tProfessionale != null && tProfessionale.Rows.Count > 0) {
                                    AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, tProfessionale,
                                        DS_toclassify);
                                    continue;
                                }
                            }
                        }
                    }
                    //Verifica la presenza di Contabilizzazioni di Compensi Dipendenti
                    if (DS_toclassify.Tables.Contains("expensewageaddition") &&
                        DS_toclassify.Tables["expensewageaddition"].Rows.Count > 0) {
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("wageaddition") &&
                            DS_toclassify.Tables["wageaddition"].Rows.Count > 0) {
                            AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, DS_toclassify.Tables["wageaddition"],
                                DS_toclassify);
                            continue;
                        }
                    }
                    else {
                        if (!nonLeggereDaDb && idExpFaseImpegno != DBNull.Value) {
                            //Stiamo creando un Pagamento usando un Impegno che contabilizza un Comp.Dipendente, legge dal DB
                            DataTable contDipendente = Meta.Conn.RUN_SELECT("expensewageadditionview",
                                "ycon,ncon, idexp",
                                null, QHS.CmpEq("idexp", idExpFaseImpegno), null, false);
                            if (contDipendente != null && contDipendente.Rows.Count > 0) {
                                DataRow rExpCon = contDipendente.Rows[0];
                                object ycon = rExpCon["ycon"];
                                object ncon = rExpCon["ncon"];
                                DataTable tDipendente = Meta.Conn.RUN_SELECT("wageaddition", "idsor_siope", null,
                                    QHS.AppAnd(QHS.CmpEq("ycon", ycon), QHS.CmpEq("ncon", ncon)), null, false);
                                if (tDipendente != null && tDipendente.Rows.Count > 0) {
                                    AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, tDipendente, DS_toclassify);
                                    continue;
                                }
                            }
                        }
                    }
                    //Verifica la presenza di Contabilizzazioni di Cedolino
                    if (DS_toclassify.Tables.Contains("expensepayroll") &&
                        DS_toclassify.Tables["expensepayroll"].Rows.Count > 0) {
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("payroll") &&
                            DS_toclassify.Tables["payroll"].Rows.Count > 0) {
                            DataRow rCedolino = DS_toclassify.Tables["payroll"].Rows[0];
                            object idcon = rCedolino["idcon"];
                            DataTable tCococo = Meta.Conn.RUN_SELECT("parasubcontract", "idsor_siope", null,
                                QHS.CmpEq("idcon", idcon), null, false);
                            AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, tCococo, DS_toclassify);
                            continue;
                        }
                    }
                    else {
                        if (!nonLeggereDaDb && idExpFaseImpegno != DBNull.Value) {
                            //Stiamo creando un Pagamento usando un Impegno che contabilizza una Cedolino, legge dal DB
                            DataTable contCedolino = Meta.Conn.RUN_SELECT("expensepayrollview", "idpayroll, idexp",
                                null,
                                QHS.CmpEq("idexp", idExpFaseImpegno), null, false);
                            if (contCedolino != null && contCedolino.Rows.Count > 0) {
                                DataRow rExpCon = contCedolino.Rows[0];
                                object idpayroll = rExpCon["idpayroll"];
                                object idcon =
                                    Meta.Conn.DO_READ_VALUE("payroll", QHS.CmpEq("idpayroll", idpayroll), "idcon");
                                DataTable tCococo = Meta.Conn.RUN_SELECT("parasubcontract", "idsor_siope", null,
                                    QHS.CmpEq("idcon", idcon), null, false);
                                if (tCococo != null && tCococo.Rows.Count > 0) {
                                    AggiungiClassDa_Compenso(Curr_idexpidinc, curramount, tCococo, DS_toclassify);
                                    continue;
                                }
                            }
                        }
                    }
                }// fine : foreach (DataRow CurrMov in Movimento.Select()) 
            }// chiusura : if (Meta.PrimaryDataTable.TableName == "expense") 

            if ((Meta.PrimaryDataTable.TableName == "income") ||(Meta.PrimaryDataTable.TableName=="no_table")){

                foreach (DataRow CurrMov in Movimento.Select()) {
                    Hashtable htAmountClassInv= new Hashtable();
                    object Curr_idexpidinc = CurrMov["idinc"];
                    bool nonLeggereDaDb = false;
                    object parid = CurrMov["parentidinc"];
                    while (parid != DBNull.Value) {
                        DataRow[] parent = Movimento.Select(QHC.CmpEq("idinc", parid));
                        if (parent.Length > 0) {
                            if (parent[0].RowState == DataRowState.Added) {
                                parid = parent[0]["parentidinc"];
                                continue;
                            }
                            break;
                        }
                        break;
                    }

                    object idIncFaseAccertamento = DBNull.Value;
                    if (parid != DBNull.Value) {
                       idIncFaseAccertamento =// insertMode? DBNull.Value:
                            Meta.Conn.DO_READ_VALUE("incomelink",
                                QHS.AppAnd(QHS.CmpEq("idchild", parid),
                                    QHS.CmpEq("nlevel", Meta.Conn.GetSys("incomephase"))), "idparent");
                    }

                    if (idIncFaseAccertamento == null || idIncFaseAccertamento == DBNull.Value) {
                        nonLeggereDaDb = true;
                    }
                    
                    DataRow CurrImputazioneMov = ImputazioneMovimento.Select(QHC.CmpEq(idmovimento, Curr_idexpidinc))[0];
                    decimal curramount = GetCurrImporto(CurrImputazioneMov);

                    //Verifica la presenza di Contabilizzazioni dett. Fattura Vendita
                    if ((DS_toclassify.Tables.Contains("incomeinvoice") &&
                         (DS_toclassify.Tables["incomeinvoice"].Rows.Count > 0))
                        ||
                        (DSsource != null && DSsource.Tables.Contains("incomeinvoice") &&
                         (DSsource.Tables["incomeinvoice"].Rows.Count > 0))) {
                        DataRow rincomeinvoice = null;

                        if (DS_toclassify.Tables.Contains("incomeinvoice") &&
                            DS_toclassify.Tables["incomeinvoice"].Rows.Count > 0) {
                            rincomeinvoice = DS_toclassify.Tables["incomeinvoice"].Rows[0];
                        }
                        if (DSsource != null && DSsource.Tables.Contains("incomeinvoice") &&
                            DSsource.Tables["incomeinvoice"].Rows.Count > 0) {
                            rincomeinvoice = DSsource.Tables["incomeinvoice"].Rows[0];
                        }
                        int movkind = GetNoNullInt32(rincomeinvoice["movkind"]);
                        //Siamo in _procedura, legge dal DS
                        if (DS_toclassify.Tables.Contains("invoicedetail") &&
                            (DS_toclassify.Tables["invoicedetail"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetail", "invoicedetail", movkind,
                                DS_toclassify,"idinc");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                        if (DS_toclassify.Tables.Contains("invoicedetailview") &&
                            (DS_toclassify.Tables["invoicedetailview"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetailview", "invoicedetailview",
                                movkind, DS_toclassify, "idinc");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                        if (DS_toclassify.Tables.Contains("invoicedetail_taxable") &&
                            (DS_toclassify.Tables.Contains("invoicedetail_iva"))) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetail_taxable",
                                "invoicedetail_iva", movkind, DS_toclassify, "idinc");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                        if (DSsource != null && DSsource.Tables.Contains("invoicedetail") &&
                            (DSsource.Tables["invoicedetail"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetail", "invoicedetail", movkind,
                                DSsource, "idinc");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }

                        if (DSsource != null && DSsource.Tables.Contains("invoicedetailview") &&
                            (DSsource.Tables["invoicedetailview"].Rows.Count > 0)) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetailview", "invoicedetailview",
                                movkind, DSsource, "idinc");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                        if (DSsource != null && DSsource.Tables.Contains("invoicedetail_taxable") &&
                            (DSsource.Tables.Contains("invoicedetail_iva"))) {
                            AggiungiClassDa_DettaglioFattura(htAmountClassInv, Curr_idexpidinc, "invoicedetail_taxable",
                                "invoicedetail_iva", movkind, DSsource, "idinc");
                            AggiungiClass(htAmountClassInv, Curr_idexpidinc);
                            continue;
                        }
                    }
                    else {
                    

                        if ((Meta.PrimaryDataTable.TableName == "income") && DS_toclassify.Tables.Contains("incomeestimate") &&
                            DS_toclassify.Tables["incomeestimate"].Rows.Count > 0 ) {
                            //Siamo in _procedura, legge dal DS
                            DataRow rIncomeEstimate = DS_toclassify.Tables["incomeestimate"].Rows[0];
                            int movkindE = GetNoNullInt32(rIncomeEstimate["movkind"]);
                            if (DS_toclassify.Tables.Contains("estimatedetailview") &&
                                DS_toclassify.Tables["estimatedetailview"].Rows.Count > 0) {
                                AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "estimatedetailview", "estimatedetailview",
                                    null, movkindE, DS_toclassify,curramount);
                                continue;
                            }
                            if (DS_toclassify.Tables.Contains("estimatedetail_taxable") &&
                                DS_toclassify.Tables.Contains("estimatedetail_iva")) {
                                AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "estimatedetail_taxable",
                                    "estimatedetail_iva", null, movkindE, DS_toclassify, curramount);
                                continue;
                            }
                        }
                        else {
                            //Stiamo creando un Pagamento usando un Impegno che contabilizza un CP
                            if (!nonLeggereDaDb && idIncFaseAccertamento!=DBNull.Value) {
                                DataTable dettCAttivo = Meta.Conn.RUN_SELECT("estimatedetailview",
                                    "idinc_iva, idinc_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null,
                                    QHS.AppAnd(
                                        QHS.AppOr(QHS.CmpEq("idinc_taxable", idIncFaseAccertamento),
                                            QHS.CmpEq("idinc_iva", idIncFaseAccertamento)), QHS.IsNull("stop")), null,
                                    false);
                                if (dettCAttivo != null && dettCAttivo.Rows.Count > 0) {
                                    object rowtotal = Meta.Conn.DO_READ_VALUE("estimatedetailview",
                                        QHS.AppAnd(QHS.CmpEq("idinc_taxable", idIncFaseAccertamento),
                                            QHS.IsNull("stop")),
                                        "sum(rowtotal)");
                                    decimal rowtotalDec = GetNoNullDecimal(rowtotal);
                                    if (rowtotalDec == curramount) {
                                        AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, null, null, dettCAttivo, 1,
                                            DS_toclassify, curramount);
                                        continue;
                                    }

                                    if ((rowtotalDec != curramount)) { //&& DettagliConUnicaClass(dettCAttivo)
                                        AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, null, null, dettCAttivo, 1,
                                            DS_toclassify, curramount);
                                        continue;
                                    }
                                }
                            }
							else {
								if((monofase && DS_toclassify.Tables.Contains("estimatedetail") &&
										DS_toclassify.Tables["estimatedetail"].Rows.Count > 0) 
										||
										(monofase && DSsource != null && DSsource.Tables.Contains("estimatedetail") &&
										(DSsource.Tables["estimatedetail"].Rows.Count > 0))){
									DataRow rIncomeEstimate = null;

									if (DS_toclassify.Tables.Contains("incomeestimate") &&
											DS_toclassify.Tables["incomeestimate"].Rows.Count > 0) {
										rIncomeEstimate = DS_toclassify.Tables["incomeestimate"].Rows[0];
									}
									if (DSsource != null && DSsource.Tables.Contains("incomeestimate") &&
										DSsource.Tables["incomeestimate"].Rows.Count > 0) {
										rIncomeEstimate = DSsource.Tables["incomeestimate"].Rows[0];
									}
									int movkindE = GetNoNullInt32(rIncomeEstimate["movkind"]);
									//Siamo nel mono fase e dobbiamo risalire al Contratto Attivo/Passivo dalla tabella estimatedetail
									/*-------------------------------------------------------------*/
									if (DS_toclassify.Tables.Contains("estimatedetailview") &&
										(DS_toclassify.Tables["estimatedetailview"].Rows.Count > 0)) {
										string filterdettCA = "";
										foreach (DataRow RR in DS_toclassify.Tables["estimatedetailview"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("estimatedetailview", "idinc_iva, idinc_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA( Curr_idexpidinc, "estimatedetailview", "estimatedetailview", dettCA, movkindE, DS_toclassify, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									if (DS_toclassify.Tables.Contains("estimatedetail_taxable") &&
										(DS_toclassify.Tables.Contains("estimatedetail_iva"))) {
										string filterdettCA = "";
										foreach (DataRow RR in DS_toclassify.Tables["estimatedetail_taxable"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										foreach (DataRow RR in DS_toclassify.Tables["estimatedetail_iva"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("estimatedetailview", "idinc_iva, idinc_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA( Curr_idexpidinc, "estimatedetail_taxable","estimatedetail_iva", dettCA, movkindE, DS_toclassify, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									if (DSsource != null && DSsource.Tables.Contains("estimatedetail") &&
										(DSsource.Tables["estimatedetail"].Rows.Count > 0)) {
										string filterdettCA = "";
										foreach (DataRow RR in DSsource.Tables["estimatedetail"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("estimatedetailview", "idinc_iva, idinc_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "estimatedetail", "estimatedetail", dettCA, movkindE, DSsource, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}

									if (DSsource != null && DSsource.Tables.Contains("estimatedetailview") &&
										(DSsource.Tables["estimatedetailview"].Rows.Count > 0)) {
										string filterdettCA = "";
										foreach (DataRow RR in DSsource.Tables["estimatedetailview"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("estimatedetailview", "idinc_iva, idinc_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "estimatedetailview", "estimatedetailview", dettCA, movkindE, DSsource, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									if (DSsource != null && DSsource.Tables.Contains("estimatedetail_taxable") &&
										(DSsource.Tables.Contains("estimatedetail_iva"))) {
										string filterdettCA = "";
										foreach (DataRow RR in DSsource.Tables["estimatedetail_taxable"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										foreach (DataRow RR in DSsource.Tables["estimatedetail_iva"].Select()) {
											filterdettCA = QHS.AppOr(filterdettCA, QHS.CmpKey(RR));
										}
										DataTable dettCA = Meta.Conn.RUN_SELECT("estimatedetailview", "idinc_iva, idinc_taxable, taxable_euro, iva_euro, rowtotal, idsor_siope", null, filterdettCA, null, false);
										AggiungiClassDa_DettaglioCPCA(Curr_idexpidinc, "estimatedetail_taxable", "estimatedetail_iva", dettCA, movkindE, DSsource, curramount);
										//AggiungiClass(htAmountClassInv, Curr_idexpidinc);
										continue;
									}
									/*-------------------------------------------------------------*/
								}
							}
                        }
                    }
                }// fine : foreach (DataRow CurrMov in Movimento.Select())
			
            }// chiusura: if (Meta.PrimaryDataTable.TableName == "income")
        }

		
		private Dictionary<string, DataRow> UpbUsed = new Dictionary<string, DataRow>();

		/// <summary>
		/// Rifinisce le righe della tabella ImpClass per adeguare gli importi in base all'upb
		/// </summary>
		/// <param name="DS_toclassify"></param>
		/// <remarks>siopeClassUsed deve essere pre-riempita con le class.siope usate</remarks>
		public void completaClassificazioniSiope(DataTable impClass, DataSet DS_toclassify) {
			if (impClass == null) {
				Meta.LogError($"impClass nullo nella chiamata a completaClassificazioniSiope, metaName = {Meta.Name}",null);
				return;
			}

			if (DS_toclassify == null) {
				Meta.LogError($"DS_toclassify nullo nella chiamata a completaClassificazioniSiope, metaName = {Meta.Name}",null);
				return;
			}

			//Prendiamo le righe che stanno in ImpClass il cui "idsor" è incluso in siopeClassUsed, dictionary degli idsor Siope 
			string tableName = impClass.TableName;
			if (tableName == "incomesorted") return; // Disabilitiamo la gestione DATI ARCONET per la SIOPE Entrate

			string idMovField = (tableName == "incomesorted") ? "idinc" : "idexp";

			string ImpMovYear = (tableName == "incomesorted") ? "incomeyear" : "expenseyear";
			var IdMov_IdUpb = new Dictionary<int, string>();
			if (impClass.Rows.Count == 0) return;
			foreach (DataRow impRow in impClass.Rows) {
                //Nel dictionary mettiamo solo gli idmov associati a classificazioni siope 
				if (impRow.RowState == DataRowState.Deleted) continue;
				int idsor = CfgFn.GetNoNullInt32(impRow["idsor"]);
				int idmov = CfgFn.GetNoNullInt32(impRow[idMovField]);
				if ((siopeClassUsed.ContainsKey(idsor)) && (!IdMov_IdUpb.ContainsKey(idmov))) IdMov_IdUpb.Add(idmov, "");
			}

			if (!DS_toclassify.Tables.Contains(ImpMovYear)) {
				Meta.LogError($"DS_toclassify non contiene tabella {ImpMovYear}] nella chiamata a completaClassificazioniSiope, metaName = {Meta.Name}",null);
				return;
			}


            var listaUpbMancanti = new HashSet<string>();
			foreach (DataRow row in DS_toclassify.Tables[ImpMovYear].Rows) {
                //cerca le righe mancanti nel dictionary rispetto a quelle usate col siope
				string idupb = row["idupb"].ToString();
				int idmov = CfgFn.GetNoNullInt32(row[idMovField]);
				if (IdMov_IdUpb.ContainsKey(idmov)) IdMov_IdUpb[idmov] = idupb;
                if (!UpbUsed.ContainsKey(idupb)) {
                    UpbUsed[idupb] = null;
                    listaUpbMancanti.Add(idupb);
                }
			}

            if (listaUpbMancanti.Count > 0) {
                DataTable T = callSp(Meta.Conn, listaUpbMancanti.ToList());
                if (T != null && T.Columns.Contains("codeupb")) {
                    foreach (DataRow row in T.Rows) {
                        string idupb = row["idupb"].ToString();
                        UpbUsed[idupb] = row;
                    }
                }
            }

            //Prendiamo le righe di expense/incomesorted e usando l'idupb che abbiamo memorizzato in dic1 e la riga del dic2 e con quello facciamo l'integrazione dei dati
            foreach (DataRow impClassRow in impClass.Rows) {
                if (impClassRow.RowState == DataRowState.Deleted) continue;
                int idsor = CfgFn.GetNoNullInt32(impClassRow["idsor"]);
                int idmov = CfgFn.GetNoNullInt32(impClassRow[idMovField]);
                if ((siopeClassUsed.ContainsKey(idsor)) &&
                    ((tableName == "expensesorted") || (tableName == "incomesorted") ||
                     (tableName == "pettycashsorted"))) {

                    if (IdMov_IdUpb.ContainsKey(idmov)) {
                        string idupb = IdMov_IdUpb[idmov];
                        if (UpbUsed.ContainsKey(idupb)) {
                            DataRow rUpb = UpbUsed[idupb];
                            if (rUpb == null) continue;
                            impClassRow["values1"] = rUpb["uesiopecode"];
                            impClassRow["values2"] = rUpb["cofogmpcode"];
                        }
                    }
                }
            }

			//caso ExpenseSorted/IncomeSorted
			//Per ognuna di queste righe aggiungiamo il relativo idexp/idinc ad un dictionary int-string (che sarebbe l'idupb) con valore stringa vuota come "value" (dic1)

			//per ogni riga di expenseyear/incomeyear vediamo : se l'idexp/inc è incluso nel dictionary di sopra (dic1), valorizziamo il "value" da stringa vuota a quello giusto

			//Ci costruiamo un dictionary<string,bool> di upb "utilizzati" partendo da un dict. vuoto e poi aggiungendo tutti quelli usati come value in dic1

			//A questo punto abbiamo tutti gli idupb distinti usati e questi li diamo in pasto ad una sp che ci dia i valori desiderati - > otteniamo una tabella con chiave idupb
			//ci costruiamo con questa tabella un dictionari string-datarow  dove string è l'idupb e datarow è la riga della tabella  (dic2)

			//Prendiamo le righe di expense/incomesorted e usando l'idupb che abbiamo memorizzato in dic1 e la riga del dic2 e con quello facciamo l'integrazione dei dati

		}
		string getHash(int[] listaCampi) {
			if ((listaCampi != null) && (listaCampi.Length > 0)) return string.Join("§", (from field in listaCampi select field.ToString()).ToArray());
			return null;
		}

		Dictionary <string, string> IdOpFs_IdUpb = new Dictionary <string, string>();
		public void completaClassificazioniSiopeFondoPs(DataSet DS_toclassify) {
			//Prendiamo le righe che stanno in ImpClass il cui "idsor" è incluso in siopeClassUsed, dictionary degli idsor Siope 
			string tableName = ImpClass.TableName;

			if (ImpClass.Rows.Count == 0) return;
			foreach (DataRow impRow in DS_toclassify.Tables["pettycashoperationsorted"].Rows) {
				if ((impRow.RowState == DataRowState.Detached) || (impRow.RowState == DataRowState.Deleted)) continue;
				int idsor = CfgFn.GetNoNullInt32(impRow["idsor"]);
				int idpettycash = CfgFn.GetNoNullInt32(impRow["idpettycash"]);
				int yoperation = CfgFn.GetNoNullInt32(impRow["yoperation"]);
				int noperation = CfgFn.GetNoNullInt32(impRow["noperation"]);
				string key = getHash(new[] { idpettycash, yoperation, noperation});
				if ((siopeClassUsed.ContainsKey(idsor)) && (!IdOpFs_IdUpb.ContainsKey(key))) IdOpFs_IdUpb.Add(key, "");

			}

			var listaUpbMancanti = new List<string>();

			// Imputazione normale
			foreach (DataRow row in DS_toclassify.Tables["pettycashoperation"].Rows) {
				int idpettycash = CfgFn.GetNoNullInt32(row["idpettycash"]);
				int yoperation = CfgFn.GetNoNullInt32(row["yoperation"]);
				int noperation = CfgFn.GetNoNullInt32(row["noperation"]);
				object idExpReintegro = row["idexp"];
				object idUpbObj = DBNull.Value;
				if (idExpReintegro != DBNull.Value) {
					string filter =QHC.AppAnd(QHC.CmpEq("idexp",idExpReintegro),QHC.CmpEq("ayear",Meta.GetSys("esercizio")));
					DataRow[] Righe = DS_toclassify.Tables["expenseview"].Select(filter);
					if (Righe.Length > 0) idUpbObj = Righe[0]["idupb"];
				}
				else { 
					idUpbObj = row["idupb"];
				}
				if (idUpbObj == DBNull.Value) continue;
				string idupb = idUpbObj.ToString();

				string key = getHash(new[] { idpettycash, yoperation, noperation});
				if (IdOpFs_IdUpb.ContainsKey(key)) IdOpFs_IdUpb[key] = idupb;
				if (!UpbUsed.ContainsKey(idupb)) {
					UpbUsed[idupb] = null;
					listaUpbMancanti.Add(idupb);
				}
				}
			if (listaUpbMancanti.Count > 0) {
				DataTable T = callSp(Meta.Conn,  new List<string>(this.UpbUsed.Keys)) ;
				if (T != null && T.Columns.Contains("codeupb")) {
					foreach (DataRow row in T.Rows) {
						string idupb = row["idupb"].ToString();
						UpbUsed[idupb] = row;
					}
				}
			}
			//Prendiamo le righe di expense/incomesorted e usando l'idupb che abbiamo memorizzato in dic1 e la riga del dic2 e con quello facciamo l'integrazione dei dati
			foreach (DataRow impClassRow in ImpClass.Rows) {
				if (impClassRow.RowState == DataRowState.Deleted) continue;
				string idupb= "";
				DataRow rUpb = null;
				int idsor = CfgFn.GetNoNullInt32(impClassRow["idsor"]);
				if ((siopeClassUsed.ContainsKey(idsor))) {
					int idpettycash = CfgFn.GetNoNullInt32(impClassRow["idpettycash"]);
					int yoperation = CfgFn.GetNoNullInt32(impClassRow["yoperation"]);
					int noperation = CfgFn.GetNoNullInt32(impClassRow["noperation"]);
					string key = getHash(new[] { idpettycash, yoperation, noperation});
					if (IdOpFs_IdUpb.ContainsKey(key)) {
						idupb = IdOpFs_IdUpb[key];
						if (UpbUsed.ContainsKey(idupb)) {
							rUpb = UpbUsed[idupb];
                            if (rUpb == null) continue;
							impClassRow["values1"] = rUpb["uesiopecode"];
							impClassRow["values2"] = rUpb["cofogmpcode"];
						}
					}
				}
			}
			//Meta.FreshForm(true);
			//caso ExpenseSorted/IncomeSorted
			//Per ognuna di queste righe aggiungiamo il relativo idexp/idinc ad un dictionary int-string (che sarebbe l'idupb) con valore stringa vuota come "value" (dic1)

			//per ogni riga di expenseyear/incomeyear vediamo : se l'idexp/inc è incluso nel dictionary di sopra (dic1), valorizziamo il "value" da stringa vuota a quello giusto

			//Ci costruiamo un dictionary<string,bool> di upb "utilizzati" partendo da un dict. vuoto e poi aggiungendo tutti quelli usati come value in dic1

			//A questo punto abbiamo tutti gli idupb distinti usati e questi li diamo in pasto ad una sp che ci dia i valori desiderati - > otteniamo una tabella con chiave idupb
			//ci costruiamo con questa tabella un dictionari string-datarow  dove string è l'idupb e datarow è la riga della tabella  (dic2)

			//Prendiamo le righe di expense/incomesorted e usando l'idupb che abbiamo memorizzato in dic1 e la riga del dic2 e con quello facciamo l'integrazione dei dati

		}
		static DataTable callSp(DataAccess Conn, List<string> idUpbList) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("DECLARE @lista AS string_list;");
			int currblockLen = 0;
			foreach (string id in idUpbList) {
				if (currblockLen == 0) {
					sb.Append($"insert into @lista values ('{id}')");
				} else {
					sb.Append($",('{id}')");
				}

				currblockLen++;
				if (currblockLen == 20) {
					sb.AppendLine(";");
					currblockLen = 0;
				}
			}
			if (currblockLen > 0) sb.AppendLine(";");
			sb.AppendLine($"exec  get_upb_info @lista");
			return Conn.SQLRunner(sb.ToString());
		}
		public void AggiungiClassDa_Compenso(object Curr_idexpidinc, decimal curramount, DataTable tCompenso, DataSet DS_toclassify) {
            DataRow rDett = tCompenso.Rows[0];
            int idsor_siope = GetNoNullInt32(rDett["idsor_siope"]);
            Hashtable htAmountClass = new Hashtable();
            AggiornaImporti(htAmountClass, idsor_siope, curramount);
            AggiungiClass(htAmountClass, Curr_idexpidinc);
        }

        public void AggiornaImporti(Hashtable ht, int idsor_siope, decimal amount) {
            if (ht.ContainsKey(idsor_siope)) {
                ht[idsor_siope] = GetNoNullDecimal(ht[idsor_siope]) + amount;
            }
            else {
                ht[idsor_siope] = amount; 
            }
        }
		public bool ContabSoloIVA_CA(DataTable dettCACP) {
			//Dobbiamo capire il tipo contabilizzazione dell'Accertamento. Per cui ci basta un dettaglio a caso.
			//Agisce solo per i CA
			if (dettCACP.ToString().SqlLike("mandate%"))
				return false;
			DataRow R = dettCACP.Rows[0];

			if (R["idinc_iva"]!=DBNull.Value 
					&& (R["idinc_taxable"]==DBNull.Value || CfgFn.GetNoNullInt32(R["idinc_iva"]) != CfgFn.GetNoNullInt32(R["idinc_taxable"]))) {
				return true;

			}
			return false;
		}
        public void AggiungiClassDa_DettaglioCPCA(
            object Curr_idexpidinc, 
            string mandatedetail_taxable, 
            string mandatedetail_iva, 
            DataTable dettCPassivo, 
            int movkind, 
            DataSet DS_toclassify,
            decimal currAmount) {
			object idsor_siopeivavendita = DBNull.Value;
			DataTable Tconfig = Meta.Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, true);
			if (Tconfig.Rows.Count > 0) {
				idsor_siopeivavendita = Tconfig.Rows[0]["idsor_siopeivavendita"];
			}
			//Fa la somma dei dettagli per idsor_siope 
			Hashtable htAmountClass = new Hashtable();
            decimal importoClassificato = 0;
			//Ha letto dal DB.
			//Se si stratta di un incaso di CA che è stato contabilizzato per la sola IVA, e il siope della config. è valorizzato, 
			//allora deve usare il siope della config., diversamente deve mantenere il comportamento attuale, ossia leggere il siope dal dettaglio CA
			if ((dettCPassivo != null) && (!ContabSoloIVA_CA(dettCPassivo) || CfgFn.GetNoNullInt32(idsor_siopeivavendita)==0)) {
				//MetaFactory.factory.getSingleton<IMessageShower>().Show("TEST 1");
				
				double totaledettaglicontabilizzati = 0;
                foreach (DataRow rDett in dettCPassivo.Select(QHC.IsNotNull("idsor_siope"))) {
                    totaledettaglicontabilizzati = totaledettaglicontabilizzati + GetNoNullDouble(rDett["rowtotal"]);
                }
                decimal totaledettaglicontabilizzatiDec = Convert.ToDecimal(totaledettaglicontabilizzati);
                int countDett = dettCPassivo.Select(QHC.IsNotNull("idsor_siope")).Length;
                foreach (DataRow rDett in dettCPassivo.Select(QHC.IsNotNull("idsor_siope"))) {
                    countDett--;
                    int idsor_siope = GetNoNullInt32(rDett["idsor_siope"]);
                    decimal rowtotal = GetNoNullDecimal (rDett["rowtotal"]);
                    if (Convert.ToDecimal(totaledettaglicontabilizzati) == currAmount) {
                        //Se l'importo del pagamento è esattamente uguale a quello dell'impegno che contabilizza i dettagli, legge l'importo del dettaglio
                        AggiornaImporti(htAmountClass, idsor_siope, rowtotal);
                    }
                    else {
                        //altrimenti riproporziona il pagato al singolo dettaglio  
                        if (countDett == 0) {
                            //se è l'ultimo, calcola l'importo per differenza, per rimediare ad eventuali errori di arrotondamento
                            decimal rowtotalnew = currAmount - importoClassificato;
                            AggiornaImporti(htAmountClass, idsor_siope, rowtotalnew);
                        }
                        else {
                            decimal rowtotalnew = Convert.ToDecimal(rowtotal * currAmount / totaledettaglicontabilizzatiDec);
                            importoClassificato = importoClassificato + RoundValuta(rowtotalnew);
                            AggiornaImporti(htAmountClass, idsor_siope, rowtotalnew);
                        }
                    }
                }
                if (htAmountClass.Keys.Count == 1) {
                    object idsiope = null;
                    foreach (object idsorSiope in htAmountClass.Keys)idsiope=idsorSiope;
                    htAmountClass[idsiope] = currAmount;
                }
                AggiungiClass(htAmountClass, Curr_idexpidinc);
                return;
            }
			//Se si stratta di un incaso di CA che è stato contabilizzato per la sola IVA, e il siope della config. è valorizzato
			if ((dettCPassivo != null) && ContabSoloIVA_CA(dettCPassivo) && (CfgFn.GetNoNullInt32(idsor_siopeivavendita) != 0) ) {
				//MetaFactory.factory.getSingleton<IMessageShower>().Show("TEST 2");
				double totaledettaglicontabilizzati = 0;
				foreach (DataRow rDett in dettCPassivo.Select()) {
					totaledettaglicontabilizzati = totaledettaglicontabilizzati + GetNoNullDouble(rDett["rowtotal"]);
				}
				decimal totaledettaglicontabilizzatiDec = Convert.ToDecimal(totaledettaglicontabilizzati);
				int countDett = dettCPassivo.Select().Length;
				foreach (DataRow rDett in dettCPassivo.Select()) {
					countDett--;
					int idsor_siope = CfgFn.GetNoNullInt32(idsor_siopeivavendita);
					decimal rowtotal = GetNoNullDecimal(rDett["rowtotal"]);
					if (Convert.ToDecimal(totaledettaglicontabilizzati) == currAmount) {
						//Se l'importo del pagamento è esattamente uguale a quello dell'impegno che contabilizza i dettagli, legge l'importo del dettaglio
						AggiornaImporti(htAmountClass, idsor_siope, rowtotal);
					}
					else {
						//altrimenti riproporziona il pagato al singolo dettaglio  
						if (countDett == 0) {
							//se è l'ultimo, calcola l'importo per differenza, per rimediare ad eventuali errori di arrotondamento
							decimal rowtotalnew = currAmount - importoClassificato;
							AggiornaImporti(htAmountClass, idsor_siope, rowtotalnew);
						}
						else {
							decimal rowtotalnew = Convert.ToDecimal(rowtotal * currAmount / totaledettaglicontabilizzatiDec);
							importoClassificato = importoClassificato + RoundValuta(rowtotalnew);
							AggiornaImporti(htAmountClass, idsor_siope, rowtotalnew);
						}
					}
				}
				if (htAmountClass.Keys.Count == 1) {
					object idsiope = null;
					foreach (object idsorSiope in htAmountClass.Keys) idsiope = idsorSiope;
					htAmountClass[idsiope] = currAmount;
				}
				AggiungiClass(htAmountClass, Curr_idexpidinc);
				return;
			}
			if ((mandatedetail_taxable != null) && (mandatedetail_iva != null)){
				//MetaFactory.factory.getSingleton<IMessageShower>().Show("movkind: "+ movkind.ToString());
				//Siamo in _procedura, sta leggendo dal DS
				if (movkind == 1) {   //totale
                    foreach (DataRow rDettFattura in Meta.DS.Tables[mandatedetail_taxable].Select(QHC.IsNotNull("idsor_siope"))) {
                        int idsor_siope = GetNoNullInt32(rDettFattura["idsor_siope"]);
                        double imponibile = GetNoNullDouble(rDettFattura["taxable_euro"]);
                        double iva = GetNoNullDouble(rDettFattura["iva_euro"]);
                        decimal imponibileDec = Convert.ToDecimal(imponibile);
                        decimal ivaDec = Convert.ToDecimal(iva);
                        AggiornaImporti(htAmountClass, idsor_siope, imponibileDec + ivaDec);
                    }
                }
				
                if (movkind == 2) {   //solo iva
                    foreach (DataRow rDettFattura in Meta.DS.Tables[mandatedetail_iva].Select(/*QHC.IsNotNull("idsor_siope")*/)) {
						int idsor_siope = GetNoNullInt32(idsor_siopeivavendita);
						//Per i CA, se contab. solo IVA, prevale il siope della configurazione.
						if ((mandatedetail_iva.ToString().SqlLike("estimate%") && (idsor_siope == 0))
							|| mandatedetail_iva.ToString().SqlLike("mandate%")) {
							idsor_siope = GetNoNullInt32(rDettFattura["idsor_siope"]);
						}
						if (idsor_siope == 0) continue;

                        double iva = GetNoNullDouble(rDettFattura["iva_euro"]);
                        decimal ivaDec = Convert.ToDecimal(iva);
                        AggiornaImporti(htAmountClass, idsor_siope, ivaDec);
                    }
                }
                if (movkind == 3) {    //imponibile
                    foreach (DataRow rDettFattura in Meta.DS.Tables[mandatedetail_taxable].Select(QHC.IsNotNull("idsor_siope"))) {
                        int idsor_siope = GetNoNullInt32(rDettFattura["idsor_siope"]);
                        double imponibile = GetNoNullDouble(rDettFattura["taxable_euro"]);
                        decimal imponibileDec = Convert.ToDecimal(imponibile);
                        AggiornaImporti(htAmountClass, idsor_siope, imponibileDec);
                    }
                }
                if (htAmountClass.Keys.Count == 1) {
                    object idsiope = null;
                    foreach (object idsorSiope in htAmountClass.Keys) idsiope = idsorSiope;
                    htAmountClass[idsiope] = currAmount;
                }
                
                AggiungiClass(htAmountClass, Curr_idexpidinc);
            }

        }

        public void markIdsorAsSiope(object idsor) {
            if (idsor == null) return;
            if (idsor == DBNull.Value) return;
            siopeClassUsed[CfgFn.GetNoNullInt32(idsor)] = true;
        }

        private bool prefilledIncome = false;
        private bool prefilledExpense = false;

        public void prefillSiopeSorting(bool entrate) {
            if (prefilledIncome && entrate) return;
            if (prefilledExpense && (entrate == false)) return;
            if (entrate) {
                prefilledIncome = true;
            }
            else {
                prefilledExpense = true;
            }

            object codesorkind = entrate
                ? Meta.Conn.Security.GetSys("codesorkind_siopeentrate")
                : Meta.Conn.Security.GetSys("codesorkind_siopespese");
            object idsorkind = Meta.Conn.readValue("sortingkind", q.eq("codesorkind", codesorkind), "idsorkind");
            var tSorting = Meta.Conn.readFromTable("sorting", q.eq("idsorkind", idsorkind));
            foreach (DataRow r in tSorting.Rows) {
                siopeClassUsed[CfgFn.GetNoNullInt32(r["idsor"])] = true;
            }
        }

        private Dictionary<int, bool> siopeClassUsed = new Dictionary<int, bool>();


        /// <summary>
        /// Aggiunge imputazione classificazione
        /// </summary>
        /// <param name="htAmountClass">hashtable con le class. e importi</param> 
        /// <param name="idmov">idexp del movimento, valorizzato per il finanziario</param>
        public void AggiungiClass(Hashtable htAmountClass, object idmov) {
		        foreach (DictionaryEntry item in htAmountClass) {
			        if (item.Key == DBNull.Value) continue;
			        DataRow MyDR = ImpClass.NewRow();
			        MyDR["amount"] = item.Value;
			        MyDR["idsor"] = item.Key;
			        siopeClassUsed[GetNoNullInt32(item.Key)] = true;
			        MyDR["ayear"] = Meta.GetSys("esercizio");
			        MyDR["tobecontinued"] = "N";
			        MyDR["flagnodate"] = "S";
			        MyDR[idmovimento] = idmov;
			        RowChange.CalcTemporaryID(MyDR);
			        DataRow Found = FindOriginal(ImpClass, MyDR);
			        if (Found == null)
				        ImpClass.Rows.Add(MyDR);
			        else
				        MyDR = Found;
		        }
        }

        /// <summary>
        /// Aggiunge imputazione classificazione
        /// </summary>
        /// <param name="htAmountClass">hashtable con le class. e importi</param> 
        /// <param name="rPettycashoperation">Piccola spesa</param>
        public void AggiungiClassRow(Hashtable htAmountClass,  DataRow rPettycashoperation) {
            
                foreach (DictionaryEntry item in htAmountClass) {
                    if (item.Key == DBNull.Value) continue;
                    DataRow MyDR = ImpClass.NewRow();
                    MyDR["amount"] = item.Value;
                    MyDR["idsor"] = item.Key;
					MyDR["tobecontinued"] = "N";
                    MyDR["flagnodate"] = "S";
                    MyDR["yoperation"] = rPettycashoperation["yoperation"];
                    MyDR["noperation"] = rPettycashoperation["noperation"];
                    MyDR["idpettycash"] = rPettycashoperation["idpettycash"];
                    RowChange.CalcTemporaryID(MyDR);
                    DataRow Found = FindOriginal(ImpClass, MyDR);
                    if (Found == null)
                        ImpClass.Rows.Add(MyDR);
                    else
                        MyDR = Found;
                }
            
        }
	    static decimal RoundValuta(decimal valuta) {
	        if (valuta == Decimal.Truncate(valuta)) return valuta;
	        decimal truncated = Decimal.Truncate(valuta * 1000);
	        if (truncated > 0) {
	            if ((truncated % 10) >= 5) truncated += 5;
	        }
	        else {
	            if (((-truncated) % 10) >= 5) truncated -= 5;
	        }
	        truncated = truncated / 10;
	        truncated = Decimal.Truncate(truncated);
	        return truncated / 100;
	        //			SqlDecimal SQLV = new SqlDecimal(valuta);
	        //			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
	    }

	    static double RoundValuta(double valuta) {
	        return Convert.ToDouble(
	            RoundValuta(Convert.ToDecimal(valuta)));
	        //			SqlDecimal SQLV = new SqlDecimal(valuta);
	        //			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).ToDouble();
	    }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Curr_idexpidinc"></param>
        /// <param name="invoicedetail_taxable"></param>
        /// <param name="invoicedetail_iva"></param>
        /// <param name="movkind"></param>Tipo di contabilizzazione
        /// <param name="DSsource"></param> DS in cui sono presenti i documenti contabilizzati, è sempre quello principale.
        /// Nei 3 form di spesa, e nei 3 form di entrata è sufficiente usare DS_toclassify
        /// Nei wizard, invece,  troviamo il DS principale in cui sono presenti i doc oggetto della contabilizzazione

        public void AggiungiClassDa_DettaglioFattura(Hashtable htAmountClassInv, object Curr_idexpidinc, string invoicedetail_taxable, string invoicedetail_iva, int movkind, DataSet DSsource
            ,string idmovimento) {
			object idsor_siopeivavendita = DBNull.Value;
			DataTable Tconfig = Meta.Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, true);
			if (Tconfig.Rows.Count > 0) {
				idsor_siopeivavendita = Tconfig.Rows[0]["idsor_siopeivavendita"];
			}
			decimal segno = 1;
            //Se il metodo viene chiamato perchè c'è una contabilizzazione di NC, allora dobbiamo considerare l'importo negativo
            if(invoicedetail_taxable.ToString().Contains("_nc")|| invoicedetail_iva.ToString().Contains("_nc"))  {
                segno = -1;
            }
            if (movkind == 1) {   //totale

               if ((DSsource != null)&&(DSsource.Tables.Contains(invoicedetail_taxable))&&(DSsource.Tables[invoicedetail_taxable].Rows.Count > 0)) {
                DataRow Rinv = DSsource.Tables[invoicedetail_taxable].Rows[0];
                object exchangerate = Meta.Conn.DO_READ_VALUE("invoice",
                     QHS.AppAnd(QHS.CmpEq("idinvkind", Rinv["idinvkind"]), QHS.CmpEq("yinv", Rinv["yinv"]), QHS.CmpEq("ninv", Rinv["ninv"])) , "exchangerate");
                double tassocambio = GetNoNullDouble(exchangerate);
                if (tassocambio == 0) tassocambio = 1;
                foreach (DataRow rDettFattura in DSsource.Tables[invoicedetail_taxable].Select(
                        QHC.AppAnd(QHC.CmpEq(idmovimento+"_taxable",Curr_idexpidinc), QHC.IsNotNull("idsor_siope")))) {
                    int idsorSiope = GetNoNullInt32(rDettFattura["idsor_siope"]);
                    if (idsorSiope == 0) continue;
                    //double imponibile = GetNoNullDouble(rDettFattura["taxable_euro"]);
                    //double iva = GetNoNullDouble(rDettFattura["iva_euro"]);
                    double imponibile = GetNoNullDouble(rDettFattura["taxable"]);
                    double quantitaConfezioni = GetNoNullDouble(rDettFattura["npackage"]);
                    double sconto = GetNoNullDouble(rDettFattura["discount"]);                   
                    double imponibileEUR = RoundValuta(imponibile * quantitaConfezioni * tassocambio  * (1 - sconto));
                    double ivaEUR = GetNoNullDouble(rDettFattura["tax"]);

                    decimal imponibileDec = Convert.ToDecimal(imponibileEUR);
                    decimal ivaDec = Convert.ToDecimal(ivaEUR);
                    AggiornaImporti(htAmountClassInv, idsorSiope, segno*(imponibileDec + ivaDec));
                }
                }
            }
            if (movkind == 2) {   //solo iva

                if ((DSsource != null) && (DSsource.Tables.Contains(invoicedetail_iva)) && (DSsource.Tables[invoicedetail_iva].Rows.Count > 0)) {
                    DataRow Rinv = DSsource.Tables[invoicedetail_iva].Rows[0];
                    object exchangerate = Meta.Conn.DO_READ_VALUE("invoice",
                         QHS.AppAnd(QHS.CmpEq("idinvkind", Rinv["idinvkind"]), QHS.CmpEq("yinv", Rinv["yinv"]), QHS.CmpEq("ninv", Rinv["ninv"])), "exchangerate");
                    double tassocambio = GetNoNullDouble(exchangerate);
                    if (tassocambio == 0) tassocambio = 1;
                    foreach (DataRow rDettFattura in DSsource.Tables[invoicedetail_iva].Select(
                        QHC.AppAnd(QHC.CmpEq(idmovimento + "_iva", Curr_idexpidinc)))) {
                        int idsorSiope = GetNoNullInt32(idsor_siopeivavendita); 
						//Se contab. solo IVA, prevale il siope della configurazione.
						if (idsorSiope == 0) {
							idsorSiope = GetNoNullInt32(rDettFattura["idsor_siope"]);
						}
						if (idsorSiope == 0) continue;

						double ivaEUR = GetNoNullDouble(rDettFattura["tax"]);
						decimal ivaDec = Convert.ToDecimal(ivaEUR);
						AggiornaImporti(htAmountClassInv, idsorSiope, segno * (ivaDec));
						
                    }
                }
            }
            if (movkind == 3) {    //imponibile
                if ((DSsource != null) && (DSsource.Tables.Contains(invoicedetail_taxable)) && (DSsource.Tables[invoicedetail_taxable].Rows.Count > 0)) {
                    DataRow Rinv = DSsource.Tables[invoicedetail_taxable].Rows[0];
                    object exchangerate = Meta.Conn.DO_READ_VALUE("invoice",
                         QHS.AppAnd(QHS.CmpEq("idinvkind", Rinv["idinvkind"]), QHS.CmpEq("yinv", Rinv["yinv"]), QHS.CmpEq("ninv", Rinv["ninv"])), "exchangerate");
                    double tassocambio = GetNoNullDouble(exchangerate);
                    if (tassocambio == 0) tassocambio = 1;
                    foreach (DataRow rDettFattura in DSsource.Tables[invoicedetail_taxable].Select(
                        QHC.AppAnd(QHC.CmpEq(idmovimento + "_taxable", Curr_idexpidinc), QHC.IsNotNull("idsor_siope")))) {
                        int idsorSiope = GetNoNullInt32(rDettFattura["idsor_siope"]);
                        if (idsorSiope == 0) continue;
                        //double imponibile = GetNoNullDouble(rDettFattura["taxable_euro"]);
                        double imponibile = GetNoNullDouble(rDettFattura["taxable"]);
                        double quantitaConfezioni = GetNoNullDouble(rDettFattura["npackage"]);
                        double sconto = GetNoNullDouble(rDettFattura["discount"]);
                        double imponibileEur = RoundValuta((imponibile * quantitaConfezioni * tassocambio * (1 - sconto)));
                        decimal imponibileDec = Convert.ToDecimal(imponibileEur);
                        AggiornaImporti(htAmountClassInv, idsorSiope, segno * (imponibileDec));
                    }
                }
            }

            //AggiungiClass(htAmountClassInv, Curr_idexpidinc, null);
        }
        public void btnGeneraClass_Click(int faseinizio, int fasefine) {

			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			if(ImpClass.Select().Length>0){
				if(MetaFactory.factory.getSingleton<IMessageShower>().Show("Cancello le classificazioni esistenti?",
					"Conferma",MessageBoxButtons.OKCancel)==DialogResult.OK){
					foreach (DataRow R in ImpClass.Select()){
						R.Delete();
					}
				}
			}
            //Calcola ove necessario tipoclassAllowed e compagnia
		    RicalcolaTipoClassificazioni(faseinizio, fasefine, false);

            DataRow CurrMov = Movimento.Rows[0];
			DataRow CurrImputazioneMov = ImputazioneMovimento.Rows[0];

			object IDForSP = DBNull.Value;
			if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];
			decimal curramount = GetCurrImporto(CurrImputazioneMov);

			DataSet OutDS;
			try {
				OutDS=	Meta.Conn.CallSP("sort_auto_single"+Movimento.TableName,
					new object[]{	  
									Meta.GetSys("esercizio"),
									IDForSP,
									CurrMov["idreg"],
									CurrImputazioneMov["idupb"],
									faseinizio,
									fasefine,
									CurrImputazioneMov["idfin"],
									CurrMov["idman"],
									curramount,
                                    CurrMov["parentid"+Movimento.TableName.Substring(0,3)]
								});
			}
			catch (Exception E) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
				return;
			}
			if ((OutDS==null) ||(OutDS.Tables.Count==0)) return; //no autoclass

			AbilitaSubMovimenti();
			DataTable AutoClasses = OutDS.Tables[0];

            Hashtable NewGenerated = new Hashtable();
            Hashtable AlreadyPresent = new Hashtable();
            foreach (DataRow R_ap in ImpClass.Select()){
                object idsor_ap= R_ap["idsor"];
                //object idsorkind_ap=null;
                if (ClassMovimenti.Select(QHC.CmpEq("idsor",idsor_ap)).Length==0){
                    idsor_ap= Meta.Conn.DO_READ_VALUE("sorting",QHS.CmpEq("idsor",idsor_ap),"idsorkind");
                }
                else {
                    idsor_ap=ClassMovimenti.Select(QHC.CmpEq("idsor",idsor_ap))[0]["idsorkind"];
                }
                if (idsor_ap==null)continue;
                AlreadyPresent[idsor_ap]=1;
            }

			//for every row in OutDS.Tables[0]:
			// - add row to impclassspesa
			// - evaluates temporary AutoIncrement fields
			foreach (DataRow AutoClass in AutoClasses.Rows) {
				DataRow MyDR =  ImpClass.NewRow();
				foreach(DataColumn DC in ImpClass.Columns) {
					if (DC.ColumnName.StartsWith("!")) continue;
                    if (!ImpClass.Columns.Contains(DC.ColumnName)) continue;
					MyDR[DC.ColumnName] = AutoClass[DC.ColumnName];
				}
				///TODO: Aggiungere la riga seguente a tutti gli altri form con classificazioni
				if (MyDR[idmovimento]==DBNull.Value) 
					MyDR[idmovimento]= CurrMov[idmovimento];
				RowChange.CalcTemporaryID(MyDR);
				if (Movimento.TableName=="expense")
                    CalcFlag(MyDR, AutoClass["idsorkind"]);
				else
                    CalcFlag(MyDR, AutoClass["idsorkind"]);
				DataRow Found= FindOriginal(ImpClass, MyDR);
				if (Found==null)
					ImpClass.Rows.Add(MyDR);		
				else
					MyDR=Found;

                object currcodtipoclass = AutoClass["idsorkind"];
			    if (currcodtipoclass == null) continue;
                NewGenerated[currcodtipoclass]= 1;
			}

            //Rimangono da applicare le class. indirette su quelle create
            //NewGenerated: class. appena create
            //Alreadypresent: class. che già c'erano (non dovrebbero contenere le NewGenerated all'inizio)
            bool tocheck = true;
            while (tocheck) {
                tocheck=false;
                //Vede se ha creato qualcosa, se ha creato qualcosa deve generare le class. indirette
                foreach (object idsorkind_toexamine in NewGenerated.Keys) {
                    if (idsorkind_toexamine==null)continue;
                    if (AlreadyPresent[idsorkind_toexamine] != null) continue;
                    AlreadyPresent[idsorkind_toexamine] = 1; //non la considera più in futuro

                    //Prende tutte le class. di questo tipo 
                    foreach (DataRow R_new in ImpClass.Select()) {
                        object idsor_new = R_new["idsor"];
                        object idsorkind_new = null;
                        if (ClassMovimenti.Select(QHC.CmpEq("idsor", idsor_new)).Length == 0) {
                            idsorkind_new = Meta.Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", idsor_new), "idsorkind");
                        }
                        else {
                            idsorkind_new = ClassMovimenti.Select(QHC.CmpEq("idsor", idsor_new))[0]["idsorkind"];
                        }
                        if (idsorkind_new == null) continue;
                        if (idsorkind_new.ToString() != idsorkind_toexamine.ToString()) continue;
                        if (TipoClassAllowed != null) {
                            if (TipoClassAllowed.Select(QHC.CmpEq("idsorkind", idsorkind_new)).Length == 0) continue;
                        }
                        DataRow RSorKind= TipoClassMovimenti.Select(QHC.CmpEq("idsorkind",idsorkind_new))[0];
                        CalcAutoClasses(R_new, RSorKind);
                    }


                }
                //Azzera l'array NewGenerated
                NewGenerated = new Hashtable();

                //Cerca le nuove classificazioni
                foreach (DataRow R_new in ImpClass.Select()) {
                    object idsorSearch = R_new["idsor"];
                    object idsorkindSearch = null;
                    if (ClassMovimenti.Select(QHC.CmpEq("idsor", idsorSearch)).Length == 0) {
                        idsorkindSearch = Meta.Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", idsorSearch), "idsorkind");
                    }
                    else {
                        idsorkindSearch = ClassMovimenti.Select(QHC.CmpEq("idsor", idsorSearch))[0]["idsorkind"];
                    }
                    if (idsorkindSearch==null)continue;
                    if (AlreadyPresent[idsorkindSearch] != null) continue;
                    if (NewGenerated[idsorkindSearch] == null) {
                        tocheck = true;
                        NewGenerated[idsorkindSearch] = 1;
                    }
                }
            }
            
            
            Meta.FreshForm(true);
		}

		DataRow FindOriginal(DataTable ImpClass, DataRow R){
            string filter = "";
            if (ImpClass.Columns.Contains(idmovimento)) {
                filter = QHC.CmpMulti(R, idmovimento, "idsor");
            }
            if (ImpClass.Columns.Contains("idpettycash")) {
                filter = QHC.CmpMulti(R, "yoperation", "noperation", "idpettycash", "idsor");
            }
           
            siopeClassUsed[GetNoNullInt32(R["idsor"])] = true;

			DataRow []Found=ImpClass.Select(filter,"idsubclass asc", DataViewRowState.Deleted);
			if (Found.Length==0)return null;
			DataRow RR = Found[0];
			RR.RejectChanges();
			foreach(DataColumn C in ImpClass.Columns) {
				if (QueryCreator.IsPrimaryKey(ImpClass,C.ColumnName))continue;
				RR[C.ColumnName]=R[C.ColumnName];
			}
			return RR;
		}

		/// <summary>
		/// Sets impclass spesa defaults and submovimenti capability depending on selected tipoclass
		/// </summary>

		public void btnInsertClass_Click(int faseinizio, int fasefine,	decimal importoperclassificazione) {
			if (Meta.IsEmpty) return;

			Meta.GetFormData(true);

			if (!ImpClassMovInsertAllowed(faseinizio,fasefine)) {
				btnInsertClass.Enabled=false;
				return;
			}

			CalcImpClassMovDefaults(importoperclassificazione); 
			CalcTipoClassAllowed(faseinizio,fasefine); //mancava, non so perchè, me ne sono accorto col task 15589

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;

			CalcAvailableIDClassesFor(CurrTipoClass["idsorkind"]);
			ImpClass.ExtendedProperties[MetaData.ExtraParams]= ClassMovimentiAllowed;
			ImpClass.ExtendedProperties["importoresiduo"]= Convert.ToDecimal(0);

			DataRow Added = MetaData.Insert_Grid(DGridDettagliClassificazioni, "default");
			if (Added==null) return;
            if (Added.RowState == DataRowState.Detached) return;

			//Evaluates AutoClasses
			CalcAutoClasses(Added,CurrTipoClass); 

			//CalcImpClassMovDefaults(importoperclassificazione); 
			Meta.FreshForm(true);
		}

		/// <summary>
		/// Calcola la tabella ClassMovimentiAllowed, ossia gli idclasses disponibili per il
		///  tipoclassificazione specificato.
		///  Calls
		///   sp_root_idclasses_spesa  and sp_filtered_idclasses_spesa for each root got
		/// </summary>
		/// <param name="codicetipoclass"></param>
		void CalcAvailableIDClassesFor(object codicetipoclass) {
			DataRow CurrMov = Movimento.Rows[0];
			DataRow CurrImputazioneMov = ImputazioneMovimento.Rows[0];

			//If codicetipoclass not allowed, leave empty ClassMovimentiAllowed 
			DataRow []CurrTipoClasses = TipoClassAllowed.Select(QHC.CmpEq("idsorkind", codicetipoclass));
			if (CurrTipoClasses.Length==0) return;
			
			int currfase = GetNoNullInt32(CurrTipoClasses[0][codicefase]);
			
            //ClassMovimentiAllowed = ClassMovimenti.Clone();
            //ClassMovimentiAllowed.Clear();
            ClassMovimentiAllowed = Meta.Conn.CreateTableByName(ClassMovimenti.TableName, "*");


			object IDForSP = DBNull.Value;
			if (!Meta.InsertMode) IDForSP= CurrMov[idmovimento];
			decimal curramount = GetCurrImporto(CurrImputazioneMov);

			//Calls sp_root_tipoclasses_spesa to get roots classes available
			DataSet OutDS=	Meta.Conn.CallSP("compute_root_idsor_"+Movimento.TableName,
				new object[9] {  
								   codicetipoclass,
								   Meta.GetSys("esercizio"),
								   IDForSP,
								   ManageCreditore.GetIDPerFase(currfase),
								   ManageUPB.GetIDPerFase(currfase),
								   currfase,
								   ManageBilAnnuale.GetIDPerFase(currfase),
								   CurrMov["idman"],
								   curramount
							   });			
			if ((OutDS!=null)&&(OutDS.Tables.Count>0)) {
				QueryCreator.MergeDataTable(ClassMovimentiAllowed, OutDS.Tables[0]);
			}

			foreach(DataRow CurrImpClass in ImpClass.Rows) {	
				if (CurrImpClass.RowState==DataRowState.Deleted) continue;
                DataRow CurrClass = CurrImpClass.GetParentRow("sorting" + Movimento.TableName + "sorted");
                if (CurrClass == null) continue;
                string flt = QHC.CmpEq("idsorkind", CurrClass["idsorkind"]);
                DataRow []CurrTipoClassS = TipoClassMovimenti.Select(flt);

                DataRow CurrTipoClass = null;
                if (CurrTipoClassS.Length > 0) CurrTipoClass = CurrTipoClassS[0];
				if (CurrTipoClass==null) continue;
				int currfaseImpclass = GetNoNullInt32(
					CurrTipoClass[codicefase]);
				if (currfase!= currfaseImpclass) continue;
				try {
					OutDS=	Meta.Conn.CallSP("compute_filtered_idsor_"+Movimento.TableName,
						new object[33]{	  
										  codicetipoclass,
										  Meta.GetSys("esercizio"),
										  IDForSP, // CurrSpesa["idspesa"],
										  ManageCreditore.GetIDPerFase(currfase),
										  ManageUPB.GetIDPerFase(currfase),
										  currfase,
										  ManageBilAnnuale.GetIDPerFase(currfase),
										  CurrMov["idman"],
										  curramount,										  
										  CurrTipoClass["idsorkind"],
										  CurrImpClass["idsor"],
										  CurrImpClass["idsubclass"],
										  CurrImpClass["amount"],
										  CurrImpClass["description"],
										  CurrImpClass["flagnodate"],
										  CurrImpClass["tobecontinued"],
										  CurrImpClass["start"],
										  CurrImpClass["stop"],
										  CurrImpClass["valuen1"],
										  CurrImpClass["valuen2"],
										  CurrImpClass["valuen3"],
										  CurrImpClass["valuen4"],
										  CurrImpClass["valuen5"],
										  CurrImpClass["values1"],
										  CurrImpClass["values2"],
										  CurrImpClass["values3"],
										  CurrImpClass["values4"],
										  CurrImpClass["values5"],
										  CurrImpClass["valuev1"],
										  CurrImpClass["valuev2"],
										  CurrImpClass["valuev3"],
										  CurrImpClass["valuev4"],
										  CurrImpClass["valuev5"],
					});
				}
				catch (Exception E) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
				}
				if ((OutDS!=null)&&(OutDS.Tables.Count>0)) {
					if (ClassMovimentiAllowed==null) ClassMovimentiAllowed= OutDS.Tables[0];
					else QueryCreator.MergeDataTable(ClassMovimentiAllowed, OutDS.Tables[0]);
				}
			}
		}

        public static void CalcAvailableIDClassesFor(DataTable ImpClassTarget, MetaData Meta,
                    string codicetipoclass, DataRow Spesaview, string tablename) {
            CalcAvailableIDClassesFor(ImpClassTarget, Meta,
            (object)codicetipoclass, Spesaview, tablename);
        }

		public static void CalcAvailableIDClassesFor(DataTable ImpClassTarget, MetaData Meta, 
			object codicetipoclass,DataRow Spesaview,string tablename) {
			//DataRow CurrMov = Movimento.Rows[0];
			//DataRow CurrImputazioneMov = ImputazioneMovimento.Rows[0];

			//If codicetipoclass not allowed, leave empty ClassMovimentiAllowed 
			
			int currfase = GetNoNullInt32( Spesaview["nphase"]);
			
			DataTable ClassMovimentiAllowed = Meta.Conn.CreateTableByName("sorting","*");

			object IDForSP = Spesaview["id"+tablename.Substring(0,3)];

			//Calls sp_root_tipoclasses_spesa to get roots classes available
			DataSet OutDS=	Meta.Conn.CallSP("compute_root_idsor_"+tablename,
				new object[9] {  
								   codicetipoclass,
								   Meta.GetSys("esercizio"),
								   IDForSP,
								   Spesaview["idreg"],
								   Spesaview["idupb"],
								   //Spesaview["idres"],
								   //Spesaview["idpar"],
								   Spesaview["nphase"],
								   Spesaview["idfin"],
								   //Spesaview["idcen"],
								   Spesaview["idman"],
								   Spesaview["curramount"]
							   });			
			if ((OutDS!=null)&&(OutDS.Tables.Count>0)) {
				QueryCreator.MergeDataTable(ClassMovimentiAllowed, OutDS.Tables[0]);
			}

			DataTable ImpClass= Meta.Conn.RUN_SELECT(tablename+"sorted","*",null,
				"(id"+tablename.Substring(0,3)+" = "+QueryCreator.quotedstrvalue(IDForSP,true)+")and"+
				"(ayear='"+Meta.GetSys("esercizio").ToString()+"')",null,true) ;
            DataTable tSorting = Meta.Conn.CreateTableByName("sorting", "idsorkind, idsor");
            CQueryHelper QHC = new CQueryHelper();
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
			foreach(DataRow CurrImpClass in ImpClass.Rows) {
                string fC = QHC.CmpEq("idsor", CurrImpClass["idsor"]);
                string fSQL = QHS.CmpEq("idsor", CurrImpClass["idsor"]);
                object idsorkind = null;
                if (tSorting.Select(fC).Length == 0) {
                    Meta.Conn.RUN_SELECT_INTO_TABLE(tSorting, null, fSQL, null, true);
                    if (tSorting.Select(fC).Length > 0) {
                        idsorkind = tSorting.Select(fC)[0]["idsorkind"];
                    }
                }
                else {
                    idsorkind = tSorting.Select(fC)[0]["idsorkind"];
                }
                
                
				try {
					OutDS=	Meta.Conn.CallSP("compute_filtered_idsor_"+tablename,
						new object[33]{	  
										  codicetipoclass,
										  Meta.GetSys("esercizio"),
										  IDForSP, 
										  Spesaview["idreg"],
										  Spesaview["idupb"],
										  Spesaview["nphase"],
										  Spesaview["idfin"],
										  Spesaview["idman"],
										  Spesaview["curramount"],										  
										  idsorkind,
										  CurrImpClass["idsor"],
										  CurrImpClass["idsubclass"],
										  CurrImpClass["amount"],
										  CurrImpClass["description"],
										  CurrImpClass["flagnodate"],
										  CurrImpClass["tobecontinued"],
										  CurrImpClass["start"],
										  CurrImpClass["stop"],
										  CurrImpClass["valuen1"],
										  CurrImpClass["valuen2"],
										  CurrImpClass["valuen3"],
										  CurrImpClass["valuen4"],
										  CurrImpClass["valuen5"],
										  CurrImpClass["values1"],
										  CurrImpClass["values2"],
										  CurrImpClass["values3"],
										  CurrImpClass["values4"],
										  CurrImpClass["values5"],
										  CurrImpClass["valuev1"],
										  CurrImpClass["valuev2"],
										  CurrImpClass["valuev3"],
										  CurrImpClass["valuev4"],
										  CurrImpClass["valuev5"]
									  });
				}
				catch (Exception E) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(E.Message);
				}
				if ((OutDS!=null)&&(OutDS.Tables.Count>0)) {
					if (ClassMovimentiAllowed==null) ClassMovimentiAllowed= OutDS.Tables[0];
					else QueryCreator.MergeDataTable(ClassMovimentiAllowed, OutDS.Tables[0]);
				}
			}
			ImpClassTarget.ExtendedProperties[MetaData.ExtraParams]= ClassMovimentiAllowed;
		}


		DataRow [] ImpClassChilds(DataRow R) {
            string filterparent = QHC.AppAnd(QHC.CmpEq("paridsor", R["idsor"]),
                QHC.CmpEq("paridsubclass", R["idsubclass"]));
			return ImpClass.Select(filterparent);
		}

	
		public void btnDelClass_Click(decimal importoperclassificazione) {
			if (Meta.IsEmpty) return;

			Meta.GetFormData(true);

			DataTable SourceTable;
			DataRow CurrDR;
            
			bool res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, 
				out SourceTable, out CurrDR);
			if (!res) return ;
			if (CurrDR==null) return;

			if (ImpClassChilds(CurrDR).Length>0) {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"Cancello la classificazione selezionata e le relative subordinate?",
					"Richiesta di conferma", 
					MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
			}
			else {
				if (MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"Cancello la classificazione selezionata?",
					"Richiesta di conferma", 
					MessageBoxButtons.YesNo)!=DialogResult.Yes) return;
			}


			DeleteImpClassMov(CurrDR);
			
			HelpForm.SetLastSelected(SourceTable,null);
			Meta.myHelpForm.SetDataRowRelated(DGridClassificazioni.FindForm(), SourceTable, null);
			Meta.myHelpForm.ControlChanged(DGridClassificazioni,null);
			Meta.FreshForm();
			//CalcImpClassMovDefaults(importoperclassificazione); 
		}

		/// <summary>
		/// Deletes impclassspesa with all sub-autoclasses
		/// </summary>
		/// <param name="R"></param>
		void DeleteImpClassMov(DataRow R) {
			DataRow [] Childs =  ImpClassChilds(R);
			foreach (DataRow Child in Childs) {
				DeleteImpClassMov(Child);
			}
			R.Delete();
		}


		public void btnEditClass_Click(int faseinizio,int fasefine,decimal importoperclassificazione) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);

			CalcImpClassMovDefaults(importoperclassificazione);
			CalcTipoClassAllowed(faseinizio,fasefine);

			DataTable T;
			DataRow CurrTipoClass;
			bool res = Meta.myHelpForm.GetCurrentRow(DGridClassificazioni, out T, out CurrTipoClass);
			if (!res) return;
			if (CurrTipoClass==null) return;
			DataTable SourceTable;
			DataRow CurrDR;            
			res = Meta.myHelpForm.GetCurrentRow(DGridDettagliClassificazioni, out SourceTable, out CurrDR);
			if (!res) return ;
			if (CurrDR==null) return;

			if (ImpClassChilds(CurrDR).Length>0) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(
					"La classificazione selezionata non può essere modificata poiché ci sono classificazioni "
					+" subordinate ad essa. Per cambiarne i dati sarà necessario rimuoverla."
					,
					"Avviso", 
					MessageBoxButtons.OK);
				return;
			}

			CalcAvailableIDClassesFor(CurrTipoClass["idsorkind"]);
			ImpClass.ExtendedProperties[MetaData.ExtraParams]= ClassMovimentiAllowed;
			DataRow Modified = 	MetaData.Edit_Grid(DGridDettagliClassificazioni, "default");
			if (Modified==null) return;
            if (Modified.RowState == DataRowState.Detached) return;
            
            bool RowChanged= false;
            if (Modified.RowState == DataRowState.Modified) {
                foreach (DataColumn c in Modified.Table.Columns) {
                    if (c.ColumnName.StartsWith("!")) continue;
                    if (Modified[c].Equals(Modified[c, DataRowVersion.Original])) continue;
                    RowChanged = true;
					break;
                }
            }
            if (RowChanged) {
            //Evaluates AutoClasses
            CalcAutoClasses(Modified,CurrTipoClass); 
			}
			//CalcImpClassMovDefaults(importoperclassificazione); 
			
			Meta.FreshForm(true);
		}

		public static void CalcFlag(DataRow R, object idsorkind){
            CQueryHelper QH = new CQueryHelper();
			DataSet DS = R.Table.DataSet;
			if (DS.Tables["sortingkind"]==null) return ;
            string filtercodice = QH.CmpEq("idsorkind", idsorkind);
			DataRow [] tipoclass= DS.Tables["sortingkind"].Select(filtercodice);
			if (tipoclass.Length==0) return ; //??

            string filteridcodice = QH.CmpMulti(R, "idsor");
			DataRow [] classmov= DS.Tables["sorting"].Select(filteridcodice);
			if (classmov.Length==0) return ; //??

			DataRow CurrTipo= tipoclass[0];
			DataRow CurrClass= classmov[0];

			//Evaluates flagincompleto and checks forced columns to be not null
			bool flagincompleto=false;
			foreach (char C in new char[3] {'n','s','v'}){
				for (int i=1;i<=5;i++){
					string suffix = C.ToString()+i.ToString();
					if ((CurrTipo["forced"+suffix].ToString().ToLower()=="s")&&
						(R["value"+C.ToString()+i.ToString()]==DBNull.Value)){
						flagincompleto=true;
					}
				}
			}
			if ((CurrClass["flagnodate"].ToString().ToLower()=="n") &&
				(R["flagnodate"].ToString().ToLower()=="n") ){
				if (R["start"].ToString().Equals(""))	flagincompleto=true;
				if (R["stop"].ToString().Equals("")) 	flagincompleto=true;

			}

			if ((flagincompleto)&&(R["tobecontinued"].ToString().ToLower()=="")){
				R["tobecontinued"]="S";
			}


		}

		public static int GetNoNullInt32(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
			try {
				return Convert.ToInt32(O);
			}
			catch {
				return 0;
			}
		}
		public static decimal GetNoNullDecimal(object O){
			if (O==null) return 0;
			if (O == DBNull.Value) return 0;
			try {
				return Convert.ToDecimal(O);
			}
			catch {
				return 0;
			}
		}

        public static double GetNoNullDouble(object O) {
            if (O == null) return 0;
            if (O == DBNull.Value) return 0;
            try {
                return Convert.ToDouble(O);
            }
            catch {
                return 0;
            }
        }

        public static void CalcFlag(DataAccess Conn, DataRow R, object idsorkind){
			DataSet DS = R.Table.DataSet;
            CQueryHelper QH = new CQueryHelper();
			if (DS.Tables["sortingkind"]==null) return ;
			//string filtercodice= QH.CmpEq("idsorkind", R["idsorkind"]);
            string filtercodice = QH.CmpEq("idsorkind", idsorkind);
			DataRow [] tipoclass= DS.Tables["sortingkind"].Select(filtercodice);
			if (tipoclass.Length==0) return ; //??
            //string filteridcodice = QH.CmpMulti(R, "idsorkind", "idsor");
            string filteridcodice = QH.CmpMulti(R, "idsor");
			DataRow [] classmov;
			if (DS.Tables["sorting"]==null) {
				DataTable ClassMovimenti = Conn.RUN_SELECT("sorting",null,null,filtercodice,null,null,true);
				classmov= ClassMovimenti.Select(filteridcodice);
			}
			else {
				DataTable ClassMovimenti = DS.Tables["sorting"];
				classmov= ClassMovimenti.Select(filteridcodice);
                //if (classmov.Length == 0) {
                //    DataAccess.RUN_SELECT_INTO_TABLE(Conn, ClassMovimenti, null, filtercodice, null, true);
                //    classmov= ClassMovimenti.Select(filteridcodice);
                //}
			}
			if (classmov.Length==0) return ; //??

			DataRow CurrTipo= tipoclass[0];
			DataRow CurrClass= classmov[0];

			//Evaluates flagincompleto and checks forced columns to be not null
			bool flagincompleto=false;
			foreach (char C in new char[3] {'N','S','V'}){
				for (int i=1;i<=5;i++){
					string suffix = C.ToString()+i.ToString();
					if ((CurrTipo["forced"+suffix].ToString().ToLower()=="s")&&
						(R["value"+C.ToString()+i.ToString()]==DBNull.Value)){
						flagincompleto=true;
					}
				}
			}
			if ((CurrClass["flagnodate"].ToString().ToLower()=="n") &&
				(R["flagnodate"].ToString().ToLower()=="n") ){
				if (R["start"].ToString().Equals(""))	flagincompleto=true;
				if (R["stop"].ToString().Equals("")) 	flagincompleto=true;

			}

			if ((flagincompleto)&&(R["tobecontinued"].ToString().ToLower()=="")){
				R["tobecontinued"]="S";
			}


		}
	}


}
