
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Collections;
using System.Drawing;
using System.Linq;
using metadatalibrary;
using movimentofunctions;
using ep_functions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funzioni_configurazione;//funzioni_configurazione

namespace paydisposition_default {
	public partial class WizCreaPagamenti :System.Windows.Forms.Form {
		MetaData Meta;
		DataAccess Conn;
		string CustomTitle;
		private System.Windows.Forms.Label labMSG;
		private System.Windows.Forms.Label label18;
		public DSFinancial DS;
		public bool SavedData;
		int fasespesacont;
		int faseivaspesa;
		int esercizio;
		CQueryHelper QHC;
		QueryHelper QHS;
		DataRow[] RowGridSelected;
		DataRow ParentExpense;
		public WizCreaPagamenti(DataRow[] RowSelected,MetaData Meta, DataAccess Conn, DSFinancial DS1) {
			InitializeComponent();
			this.RowGridSelected = RowSelected;
			this.Meta = Meta;
			this.Conn = Conn;
			this.DS = DS1;

			QHS = Conn.GetQueryHelper();
			QHC = new CQueryHelper();

			esercizio = Conn.GetEsercizio();
			QHS = Conn.GetQueryHelper();
			cmbFaseSpesa.DataSource = DS.expensephase;
			txtEsercizioMovimento.Text = Meta.GetSys("esercizio").ToString();
			string maxPhaseName =  "maxexpensephase";
			int fasemax = getIntSys(maxPhaseName);
			int nPenultimaFase=  fasemax -1 ;
			string filtroSpesa = QHC.CmpEq("nphase", nPenultimaFase);
			this.Conn.RUN_SELECT_INTO_TABLE(DS.expensephase, null, filtroSpesa, null, false);
			string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			this.Conn.RUN_SELECT_INTO_TABLE(DS.config, null,filteresercizio, null, false);

			MetaData MDisp = Meta.Dispatcher.Get("paydispositiondetail");
			MDisp.DescribeColumns(DS.paydispositiondetail, "detail");
			decimal importo = 0;
			if (RowGridSelected.Length > 0) {
				foreach (DataRow R in RowGridSelected) { 
					DS.paydispositiondetail.ImportRow(R);
					importo += CfgFn.GetNoNullDecimal(R["amount"]);
				}
				//DS.paydispositiondetail.AcceptChanges();
				gridDetail.DataSource = DS.paydispositiondetail;
				//DataSource.Tables.Add(DS.paydispositiondetail);
				//FormatDataGrid(gridDetail, DS.paydispositiondetail);
				HelpForm.SetDataGrid(gridDetail, DS.paydispositiondetail);
				txtImporto.Text = importo.ToString("C");
			} 
			;
			this.Conn.RUN_SELECT_INTO_TABLE(DS.paymethod, null, null, null, false);
			tabController.HideTabsMode =
			Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}

		 

		private void FormatDataGrid(DataGrid dgr, DataTable tResult) {
			HelpForm.SetGridStyle(dgr, tResult);
			metadatalibrary.formatgrids fg = new formatgrids(dgr);
			fg.AutosizeColumnWidth();
		}


		void DisplayTabs(int newTab) {
			tabController.SelectedIndex = newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible = (newTab > 0);
			if (newTab == tabController.TabPages.Count - 1)
				btnNext.Text = "Crea Movimenti.";
			else
				btnNext.Text = "Next >";
			Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
		}
		void StandardChangeTab(int step) {
			int oldTab= tabController.SelectedIndex;
			int newTab= oldTab+step;
			if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
			if (!CustomChangeTab(oldTab, newTab)) return;
			if (newTab == tabController.TabPages.Count) {
				DialogResult = DialogResult.OK;
				Close();
				return;
			}
			DisplayTabs(newTab);
		}
		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}


		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		private void btnSelectMov_Click(object sender, System.EventArgs e) {
			string MyFilter;

			if (((Control)sender).Name == "txtNumeroMovimento")
				MyFilter = GetFasePrecFilter(true);
			else
				MyFilter = GetFasePrecFilter(false);

			MetaData MFase = Meta.Dispatcher.Get("expense");
			MFase.FilterLocked = true;
			MFase.DS = DS;

			DataRow MyDR = MFase.SelectOne("default",MyFilter,null,null);
			if (MyDR == null) return;			 

			//txtCredDeb.Text = MyDR["denominazione"].ToString();		
			HelpForm.SetComboBoxValue(cmbFaseSpesa, MyDR["nphase"]);
			txtEsercizioMovimento.Text = MyDR["ymov"].ToString();
			txtNumeroMovimento.Text = MyDR["nmov"].ToString();

			txtCredDeb.Text = MyDR["registry"].ToString();
			txtDescrizione.Text = MyDR["description"].ToString();
			SubEntity_txtImportoMovimento.Text = CfgFn.GetNoNullDecimal(MyDR["amount"]).ToString("c");
			txtDataCont.Text = ((DateTime)MyDR["adate"]).ToShortDateString();
			txtCodiceBilancio.Text = MyDR["codefin"].ToString();
			txtDenominazioneBilancio.Text = MyDR["finance"].ToString();
			txtUPB.Text = MyDR["codeupb"].ToString();
			txtDescrUPB.Text = MyDR["upb"].ToString();
			txtResponsabile.Text = MyDR["manager"].ToString();

			txtImportoCorrente.Text = CfgFn.GetNoNullDecimal(MyDR["curramount"]).ToString("c");
			txtImportoDisponibile.Text = CfgFn.GetNoNullDecimal(MyDR["available"]).ToString("c");
		 
		}

		void Clear() {
			txtNumeroMovimento.Text = "";
			txtCredDeb.Text = "";
			txtDescrizione.Text = "";
			SubEntity_txtImportoMovimento.Text = "";
			txtDataCont.Text = "";
			txtCodiceBilancio.Text = "";
			txtDenominazioneBilancio.Text = "";
			txtUPB.Text = "";
			txtDescrUPB.Text = "";
			txtResponsabile.Text = "";
			txtImportoCorrente.Text = "";
			txtImportoDisponibile.Text = "";
		}


		private void txtNumeroMovimento_Leave(object sender, System.EventArgs e) {
			if (txtNumeroMovimento.Text.Trim() == "") {
				Clear();
				return;
			}
			btnSelectMov_Click(sender, e);
		}


		bool CustomChangeTab(int oldTab, int newTab) {
			if (oldTab == 0) {
				return true; // 0->1: nothing to do
			}
			if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
			if ((oldTab == 1) && (newTab == 2)) { SavedData = GetMovimentoSelezionato(); return SavedData; }
			return true;
		}

		private void FillImputazioneMovimento(DataRow ImpMov, DataRow Auto) {
			string[] fields_to_copy = new string[] {
				"idfin", "idupb", "codefin"
			};
			foreach (string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (ImpMov.Table.Columns[field] == null) continue;
				ImpMov[field] = Auto[field];
			}
			ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(Auto["amount"]));
		}
		void ClearTablesMovFin() {
			DS.expense.Clear();
			DS.expenseyear.Clear();
			DS.expenselast.Clear();
			DS.expensesorted.Clear();
			return;
		}
		bool GetMovimentoSelezionato() {
			ClearTablesMovFin();
			if (txtNumeroMovimento.Text.Trim() == "") {
				MetaFactory.factory.getSingleton<IMessageShower>().Show("Selezionare un movimento per procedere");
				DisplayTabs(1);
				return false;
			}
			string filter= GetFasePrecFilter(true);
			MetaData MFase = Meta.Dispatcher.Get("expense");
			MFase.FilterLocked = true;
			MFase.DS = DS.Copy();

			DataRow MyDR = MFase.SelectOne("default",filter,null,null);
			if (MyDR == null) return false;

			filter = QHS.CmpEq("idexp", MyDR["idexp"]);
			
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expense, null, filter, null, true);
			AddVociCollegate(MyDR);
			ParentExpense = MyDR;
			generaMovPrincipali(ParentExpense);
			return doSave();
			
		}

	 

		string GetFasePrecFilter(bool FiltraNumMovimento) {
			string MyFilter ="";
			if (cmbFaseSpesa.SelectedValue != null && cmbFaseSpesa.SelectedIndex >= 0) {
				object codicefase = cmbFaseSpesa.SelectedValue;
				MyFilter = QHS.CmpEq("nphase", codicefase);
			}
			MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

			if (txtEsercizioMovimento.Text.Trim() != "")
				MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("ymov", txtEsercizioMovimento.Text.Trim()));

			if ((FiltraNumMovimento) && (txtNumeroMovimento.Text.Trim() != ""))
				MyFilter = QHS.AppAnd(MyFilter, QHS.CmpEq("nmov", txtNumeroMovimento.Text.Trim()));

			return MyFilter;
		}
 

		void AddVoceBilancio(object ID) {
			if (ID == DBNull.Value) return;
			if (DS.fin.Select(QHC.CmpEq("idfin", ID)).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.fin, null, QHS.CmpEq("idfin", ID), null, true);
		}

		void AddVoceUPB(object ID) {
			if (ID == DBNull.Value) return;
			if (DS.upb.Select(QHC.CmpEq("idupb", ID)).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.upb, null, QHS.CmpEq("idupb", ID), null, true);
		}

		void AddVoceFaseSpesa(object codice) {
			if (codice == DBNull.Value) return;
			if (DS.expensephase.Select(QHC.CmpEq("nphase", codice)).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expensephase, null, QHS.CmpEq("nphase", codice), null, true);

		}

		void AddImputazioneSpesa(object codice) {
			if (codice == DBNull.Value) return;
			if (DS.expenseyear.Select(QHC.AppAnd(QHC.CmpEq("idexp", codice), QHC.CmpEq("ayear", esercizio))).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.expenseyear, null, QHS.CmpEq("idexp", codice), null, true);
		}

		void AddVoceCreditore(object codice) {
			if (codice == DBNull.Value) return;
			if (DS.registry.Select(QHC.CmpEq("idreg", codice)).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.registry, null, QHS.CmpEq("idreg", codice), null, true);
		}

		void AddVoceResponsabile(object codice) {
			if (codice == DBNull.Value) return;
			if (DS.manager.Select(QHC.CmpEq("idman", codice)).Length > 0) return;
			DataAccess.RUN_SELECT_INTO_TABLE(Conn, DS.manager, null, QHS.CmpEq("idman", codice), null, true);
		}

		void AddVociCollegate(DataRow Row) {
			AddImputazioneSpesa(Row["idexp"]);
			AddVoceFaseSpesa(Row["nphase"]);
		 
			AddVoceCreditore(Row["idreg"]);
			AddVoceResponsabile(Row["idman"]);
			DataRow Imputazione=null;
 
			DataRow [] Imputazioni = Row.GetChildRows("expenseexpenseyear");
			if (Imputazioni.Length > 0) Imputazione = Imputazioni[0];
			 
			if (Imputazione != null) {
				AddVoceBilancio(Imputazione["idfin"]);
				AddVoceUPB(Imputazione["idupb"]);
			}
		}
		private int getIntSys(string nome) {
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s == 0) return 99;
			return s;
		}

		private void fillMovimento(DataRow E_S, DataRow Auto) {
			//, string idmovimento)
			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"] = esercizio;
			E_S["adate"] = DataCont;
			E_S["description"] = "Disposizione a favore di " + Auto["forename"] + " " + Auto["surname"];
			E_S["doc"] = "Disp. " + Auto["idpaydisposition"] + "/" + esercizio.ToString() + " - "+ Auto["iddetail"];
			//string[] fields_to_copy = new string[] {"motive"};
			//foreach (string field in fields_to_copy) {
			//	if (Auto.Table.Columns[field] == null) continue;
			//	if (E_S.Table.Columns.Contains(field)) E_S[field] = Auto[field];
			//}
			E_S.EndEdit();
		}
		private void fillImputazioneMovimento(  DataRow R, DataRow ImpMov, DataRow RDisp) {
			string tableName = "expenseyear";
			ImpMov["idfin"] = R["idfin"];
			ImpMov["idupb"] = R["idupb"];
			ImpMov["amount"] = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(RDisp["amount"]));
		}
		Dictionary<string, DataRow> __myModPagam = new Dictionary<string, DataRow>();
		Dictionary<string, DataRow> __PayMethod = new Dictionary<string, DataRow>();
		private void fillLastMovimento( DataRow R, DataRow NewLastMov,object idreg, object idacc) {
			string idMovField =  "idexp" ;
			string filterMov =  QHS.CmpEq(idMovField,R[idMovField]);
			string tableName =  "expenselast" ;
 
			string accountFieldName = "idaccdebit";

			#region riempimento mod. pagamento
			//aggiungere le informazioni della modalità di pagamento
			object idpaymethod = check_tipomodpagamento(DS.paymethod, R);
			NewLastMov["idpaymethod"] = idpaymethod;//ModPagam["idpaymethod"]; 
			NewLastMov["iban"] = R["iban"];
			NewLastMov["cin"] = R["cin"];
			NewLastMov["idbank"] = R["abi"];
			NewLastMov["idcab"] = R["cab"];
			NewLastMov["cc"] = R["cc"];
 
			DataRow RPayM = null;
			string key = idpaymethod.ToString();
			if (__PayMethod.ContainsKey(key)) {
				RPayM = __PayMethod[key];
			} else {
				DataRow[] pmethods = DS.paymethod.Select(QHC.CmpEq("idpaymethod",idpaymethod ));
				if (pmethods.Length > 0)
				__PayMethod[key] = pmethods[0];
				RPayM = __PayMethod[key];
				//}

				//DataTable TPaymethod = Conn.RUN_SELECT("paymethod", "*", null, filterpaymethod, null, true);
			
					if (RPayM!=null) {
						object paymethod_allowdeputy =RPayM["allowdeputy"];
						object paymethod_flag = RPayM["flag"];
						NewLastMov["paymethod_allowdeputy"] = paymethod_allowdeputy;
						NewLastMov["paymethod_flag"] = paymethod_flag;
					}
					#endregion
				}


			object idchargehandling= DBNull.Value;
			int datiModPagam = 0;
			// Valorizzazione trattamento delle spese
			 
			datiModPagam = CfgFn.GetNoNullInt32(R["flag"]);
			int flag = CfgFn.GetNoNullInt32(NewLastMov["flag"]);
			int flag_exemption = (CfgFn.GetNoNullInt32(NewLastMov["flag"]) & 0xF7) |
												((datiModPagam & 1) << 3);
			NewLastMov["flag"] = flag_exemption;
			NewLastMov["idchargehandling"] = R["idchargehandling"];
			
			if ((idacc != null)&&(idacc != DBNull.Value)) {
				NewLastMov[accountFieldName] = idacc;
			} else {
				NewLastMov[accountFieldName] = DBNull.Value;
			}
			if (NewLastMov["paymethod_flag"] == DBNull.Value) NewLastMov["paymethod_flag"] = 0;
		}

		Hashtable hashTipoModPagamento = null;
		 object  check_tipomodpagamento(DataTable PayMethod, DataRow PD) {
			if (hashTipoModPagamento == null) {
				hashTipoModPagamento = new Hashtable();
				foreach (DataRow RH in PayMethod.Rows) {
					// Prendo solo un esemplare per ciascun valore di abi_label
					if (!hashTipoModPagamento.Contains(RH["abi_label"]))
						hashTipoModPagamento[RH["abi_label"]] = RH;
				}
			}
			string abi_label = "CASSA";

			if (PD["iban"] != DBNull.Value) {
				abi_label = "SEPACREDITTRANSFER";
			} else {
				if (CfgFn.GetNoNullInt32(PD["paymethodcode"]) == 2) {
					abi_label = "CASSA";
				}
				if (CfgFn.GetNoNullInt32(PD["paymethodcode"]) == 3) {
					abi_label = "ASSEGNOCIRCOLARE";
				}
				if (CfgFn.GetNoNullInt32(PD["paymethodcode"]) == 4) {
					abi_label = "ASSEGNOCIRCOLARE";
				}
				if (CfgFn.GetNoNullInt32(PD["paymethodcode"]) == 5) {
					abi_label = "ASSEGNOBANCARIOEPOSTALE";
				}
			}
			DataRow RID = hashTipoModPagamento[abi_label] as DataRow;
			if (RID != null) {
				return RID["idpaymethod"];
			} 
			else return DBNull.Value;
		}


		Dictionary<int, string> __regTitles = new Dictionary<int, string>();

		string GetTitleForIdReg(object idreg) {
			if (idreg == DBNull.Value)
				return "";
			int n = Convert.ToInt32(idreg);
			if (__regTitles.ContainsKey(n))
				return __regTitles[n];
			object title = Meta.Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg),"title");
			if (title == null) {
				title = "[anagrafica di codice " + idreg + "]";
			}
			__regTitles[n] = title.ToString();
			return title.ToString();
		}



		private bool doSave() {
			int faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, DS,
				faseMax, faseMax, "expense", true);
			ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
			//ga.GeneraClassificazioniIndirette(ga.DSP, true);


			bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) {
				MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
					"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
				return false;
			} else {
				res = ga.doPost(Meta.Dispatcher);
				if (res) {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Salvataggio dei movimenti finanziari avvenuto con successo");
					return true;
				} else {
					MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
						"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
					return false;
				}
			}

		}


		private object getNewContoEP(object ID) {
			if (ID == DBNull.Value) return ID;
			// inserire la parte di valorizzazione del conto EP
			return ID; // per ora
		}

		private bool generaMovPrincipali(DataRow Parent) {

			string tMain =  "expense";
			string tMainYear =   "expenseyear";
			string tMainLast =  "expenselast";
			string tMainSorted =  "expensesorted";
 
			MetaData MetaM = Meta.Dispatcher.Get(tMain);
			MetaM.SetDefaults(DS.Tables[tMain]);

			MetaData MetaL = Meta.Dispatcher.Get(tMainLast);
			MetaL.SetDefaults(DS.Tables[tMainLast]);

			MetaData MetaImputazioneMov = Meta.Dispatcher.Get(tMainYear);
			MetaImputazioneMov.SetDefaults(DS.Tables[tMainYear]);

			string maxPhaseName =  "maxexpensephase";
			int fasemax = getIntSys(maxPhaseName);

			int nPenultimaFase=  fasemax -1 ;

			string regPhaseName =  "expenseregphase";
			int faseCreditoreDebitore = getIntSys(regPhaseName);

			string finPhaseName = "expensefinphase";
			int faseBilancio = getIntSys(finPhaseName);

			string idMovField =  "idexp";
			string idParMovField =  "parentidexp";

			string idAcc =  "idaccdebit";

			DataTable Mov = DS.Tables[tMain];
			DataTable ImpMov = DS.Tables[tMainYear];
 
			RowChange.SetOptimized(Mov, true);
			RowChange.ClearMaxCache(Mov);
			RowChange.SetOptimized(ImpMov, true);
			RowChange.ClearMaxCache(ImpMov);
			object idacc = DBNull.Value;
			EP_functions EP = new EP_functions(Meta.Dispatcher);
			if (EP.attivo)  idacc = EP.GetSupplierAccountForRegistry(null,  Parent["idreg"]);

			for (int ii = 0; ii < RowGridSelected.Length; ii++) {
				DataRow R = RowGridSelected[ii];
				DataRow ParentR = Parent;
				object parentidmov = ParentR[idMovField];
				// Genera solo l'ultima fase
				int faseCorrente = fasemax;
				Mov.Columns["nphase"].DefaultValue = faseCorrente;
				DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
				NewMovRow[idParMovField] = parentidmov;

				fillMovimento(NewMovRow, R);
				NewMovRow["idreg"] = ParentR["idreg"];
				//R["idexp"] = NewMovRow[idMovField];
				NewMovRow["nphase"] = faseCorrente;
				 
				DataRow NewLastRow = MetaL.Get_New_Row(NewMovRow, DS.Tables[tMainLast]);
				fillLastMovimento(R, NewLastRow, NewMovRow["idreg"], idacc);

				DataRow NewImpMov = ImpMov.NewRow();

				fillImputazioneMovimento(ParentR, NewImpMov,R);
				NewImpMov[idMovField] = NewMovRow[idMovField];
				NewImpMov["ayear"] = esercizio;
				ImpMov.Rows.Add(NewImpMov);

				DataRow[] RDet = DS.paydispositiondetail.Select(QHC.CmpEq("iddetail",R["iddetail"]));
				if (RDet.Length > 0) RDet[0]["idexp"] = NewMovRow[idMovField];
			}

			return true;
		}

		 




		private void txtEsercizioFasePrecedente_Leave(object sender, System.EventArgs e) {
			if (!Meta.DrawStateIsDone) return;
			FormattaDataDelTexBox(txtEsercizioMovimento);
			txtNumeroMovimento.Text = "";
			Clear();

		}

		private void FormattaDataDelTexBox(TextBox TB) {
			if (!TB.Modified) return;
			HelpForm.FormatLikeYear(TB);
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}
	}
}
