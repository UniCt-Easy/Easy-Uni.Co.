/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using movimentofunctions;
using ep_functions;
using System.Collections;
using System.Collections.Generic;

namespace csa_import_inail_maxphase {
	
	public partial class frmcsa_import_inail_maxphase :Form {
		MetaData Meta;
		DataAccess Conn;
		CQueryHelper QHC = new CQueryHelper();
		QueryHelper QHS;
		EntityDispatcher Dispatcher;
		System.EventHandler[] AllList = new System.EventHandler[100];
		int esercizio;
		private DataTable OutTable;
		private DataTable SP_Result;
		public csa_import_inail_maxphase.dsFinancial dsFinancial;
		private System.Data.DataTable mData = new System.Data.DataTable();
		private System.Data.DataTable csa_bill_global = new System.Data.DataTable();
		public frmcsa_import_inail_maxphase() {
			InitializeComponent();
			tabController.HideTabsMode =
			   Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
		}
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Dispatcher = Meta.Dispatcher as EntityDispatcher;
			Conn = Meta.Conn;
			esercizio = Conn.GetEsercizio();
			QHS = Conn.GetQueryHelper();
			//bool isAdmin = (bool)Meta.GetSys("IsSystemAdmin");
			DataAccess.SetTableForReading(DS.bill_versamenti, "bill");
			DataAccess.SetTableForReading(DS.bill_ripartizione, "bill");

			string billfilter = QHS.AppAnd(QHS.NullOrEq("active", "S"), QHS.CmpEq("billkind", 'D'),
			   QHS.CmpEq("ybill", Meta.GetSys("esercizio")));
			GetData.SetStaticFilter(DS.bill_versamenti, billfilter);
			GetData.SetStaticFilter(DS.bill_netti, billfilter);
			GetData.SetStaticFilter(DS.bill_ripartizione, billfilter);
			btnInputSospesi.ContextMenu = CMenu;
			InitializeAllList();

		}
		private void InitializeAllList() {
			// 25) Movimenti padre con disponibile insufficiente
			AllList[0] = this.btn25_Click;
			// 26) Upb Bilancio con disponibile insufficiente
			AllList[1] = this.btn26_Click;
		}

		private void btn25_Click(object sender, EventArgs e) {
			//25) Movimenti padre con disponibile insufficiente
			//SELECT COUNT(*) FROM csa_importver_deferred_parentview where parentayear = @ayear AND available<0 ) > 0
			string filter = QHS.AppAnd(QHS.CmpEq("parentayear", esercizio-1),QHS.CmpLt("available",0));

			//kind,parentidinc, parentidexp,ymov, nmov, nphase,phase, parentayear, 
			//parentavailable,parentayear_new, parentavailable_new, tot_amount, available
			string sqlCmd = " SELECT kind as 'Tipo'," +
							" phase as 'Fase', " +
							" ymov as 'Eserc. Mov.', " +
							" nmov as 'Numero Movimento', " +
							" parentayear_new as 'Eserc. Creazione Pagamenti', " +
							" tot_amount as 'Tot. Pagamenti', " +
							" available as 'Nuovo Importo disp.', " +
							" idcsa_incomesetup as 'Conf. Incassi'" +
							" FROM csa_importver_deferred_parentview " +
							" WHERE  " + filter;


			DataTable T = Conn.SQLRunner(sqlCmd);

			if (T != null) {
				VisualizzaDati(sender, e, T);
			}
		}

		private void VisualizzaDati(object sender, EventArgs e, DataTable T) {
			Excel_Click(sender, e, T);

		}

		private void VisualizzaDati2(object sender, EventArgs e, DataTable T, string dataTable, string view,
			string listType, string filter, string filterView) {
			Excel_Click(sender, e, T);
		}

		private void Excel_Click(object sender, EventArgs e, DataTable T) {
			if (T.Rows.Count == 0) {
				MessageBox.Show("Nessun elemento trovato");
				return;
			}
			exportclass.DataTableToExcel(T, true);
		}

		private void btn26_Click(object sender, EventArgs e) {
			//26) Coppie Bilancio - UPB con previsione disponibile insufficiente 
			string errMess;
			DataSet ds = Conn.CallSP("exp_csa_deferred_fin_upb_available",
				new object[] {esercizio-1}, 600, out errMess);
			if (errMess != null) {
				MessageBox.Show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
			}

			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				VisualizzaDati(sender, e, tResult);
			}
		}
		public void MetaData_AfterClear() {
			DisplayTabs(tabController.SelectedIndex);
			dgrVerificheFin.DataSource = null;
		}

		private void btnCancel_Click(object sender, System.EventArgs e) {
			DS.AcceptChanges();
			Close();
		}


		/// <summary>
		/// Displays tab n. NewTab and updates buttons
		/// </summary>
		/// <param name="newTab"></param>
		void DisplayTabs(int newTab) {
			tabController.SelectedIndex = newTab;
			//Evaluates Buttons Appearance
			btnBack.Visible = (newTab > 0);
			if (newTab == tabController.TabPages.Count - 1) {
				// btnBack.Visible = false;
				btnNext.Visible = true;
				btnNext.Text = "Fine";
			} else
				btnNext.Text = "Avanti >";
			Text = " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
		}

		void ResetWizard() {
			dsFinancial.Clear();
			DS.Clear();
			dgrVersamentiAnnuali.DataSource = null;
			dgrSospesi.DataSource = null;
			mData.Clear();
		}
		void StandardChangeTab(int step) {
			int oldTab = tabController.SelectedIndex;
			int newTab = oldTab + step;
			if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
			if (!CustomChangeTab(oldTab, newTab)) return;

			if (newTab == tabController.TabPages.Count) {
				if (MessageBox.Show(this, "Si desidera eseguire ancora la procedura?",
					"Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					ResetWizard();
					newTab = 0;
				} else {
					DialogResult = DialogResult.OK;
					Close();
					return;
				}
			}
			DisplayTabs(newTab);
		}
		private void btnBack_Click(object sender, System.EventArgs e) {
			StandardChangeTab(-1);
		}


		private void btnNext_Click(object sender, System.EventArgs e) {
			StandardChangeTab(+1);
		}

		bool CustomChangeTab(int oldTab, int newTab) {
			if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
			if (/*(oldTab == 0) && */(newTab == 1)) return getElencoVociCSA();
			return true;
		}

		private void FormatDataGrid(DataGrid dgr, DataTable tResult) {

			if (dgr.Name == "dgrVerificheFin") {
				foreach (DataColumn C in tResult.Columns) {
					tResult.Columns[C.ColumnName].Caption = "";
				}
				tResult.Columns["errorcode"].Caption = "#";
				tResult.Columns["errordescr"].Caption = "Descrizione";
				tResult.Columns["blockingerror"].Caption = "Bloccante";

				tResult.Columns["errorcode"].ExtendedProperties["ListColPos"] = 0;
				tResult.Columns["errordescr"].ExtendedProperties["ListColPos"] = 1;
				tResult.Columns["blockingerror"].ExtendedProperties["ListColPos"] = 2;
			}

			HelpForm.SetGridStyle(dgr, tResult);
			metadatalibrary.formatgrids fg = new formatgrids(dgr);
			fg.AutosizeColumnWidth();
		}

		private bool getElencoVociCSA() {
			DataSet DataSource = new DataSet();

			string filter =  QHS.CmpEq("ayear", getIntSys("esercizio") -1);

			DataTable Variazioni = Meta.Conn.RUN_SELECT("csa_importver_varresidualview", "*", null, filter, null, false);

			if ((Variazioni == null) || (Variazioni.Rows.Count == 0)) {
				MessageBox.Show(this, "Non ci sono variazioni da elaborare");
				//return false;
			}


			DataSource.Tables.Add(Variazioni);
			// Visualizzazione del grid

			foreach (DataColumn C in Variazioni.Columns) {
				C.Caption = "";
			}
			Variazioni.Columns["idinc"].Caption = ".idinc";
			Variazioni.Columns["idexp"].Caption = ".idexp";
			Variazioni.Columns["parentidinc"].Caption = ".parentidinc";
			Variazioni.Columns["parentidexp"].Caption = ".parentidexp";
			Variazioni.Columns["idfin"].Caption = ".idfin";
			Variazioni.Columns["idupb"].Caption = ".idupb";
			Variazioni.Columns["idman"].Caption = ".idman";
			Variazioni.Columns["idreg"].Caption = ".idreg";

			Variazioni.Columns["Kind"].Caption = "E/S";
			Variazioni.Columns["nphase"].Caption = "Fase";
			Variazioni.Columns["nmov"].Caption = "Num. Mov.";
			Variazioni.Columns["ymov"].Caption = "Eserc. Mov.";
			Variazioni.Columns["registry"].Caption = "Creditore";
			Variazioni.Columns["amount"].Caption = "Importo";
			Variazioni.Columns["description"].Caption = "Descrizione";

			//	kind, idinc, idexp,parentidinc, parentidexp,ymov, nmov, nphase,  ayear, idfin, idupb, idman, amount,idreg,registry, description
			FormatDataGrid(dgrVersamentiAnnuali, Variazioni);
			HelpForm.SetDataGrid(dgrVersamentiAnnuali, Variazioni);

			if (Variazioni.Rows.Count > 0) {
				for (int i = 0; i < Variazioni.Rows.Count; i++) {
					dgrVersamentiAnnuali.Select(i); // seleziona tutto
				}
			}
			Meta.FreshForm();
			return true;
		}
		private int getIntSys(string nome) {
			int s = CfgFn.GetNoNullInt32(Meta.GetSys(nome));
			if (s == 0) return 99;
			return s;
		}

		Hashtable lookupIdExp = new Hashtable();
		private object getNewIdExp(object oldIdExp) {
			if (oldIdExp == DBNull.Value) return oldIdExp;
			if (lookupIdExp.ContainsKey(oldIdExp)) return lookupIdExp[oldIdExp];
			return DBNull.Value;
		}



		Hashtable lookupIdInc = new Hashtable();
		private object getNewIdInc(object oldIdInc) {
			if (oldIdInc == DBNull.Value) return oldIdInc;
			if (lookupIdInc.ContainsKey(oldIdInc)) return lookupIdInc[oldIdInc];
			return DBNull.Value;
		}

		Hashtable lookupFin = new Hashtable();

		private object getNewVoceBilancio(object ID) {
			if (ID == DBNull.Value) return ID;
			if (lookupFin.ContainsKey(ID)) return lookupFin[ID];
			// ottengo il newID nell'esercizio corrente 

			object newID = Conn.DO_READ_VALUE("finlookup",QHS.CmpEq("oldidfin", ID), "newidfin");
			if (newID != null) lookupFin[ID] = newID;
			return lookupFin[ID];
		}


		Hashtable lookupAccount = new Hashtable();

		private object getNewContoEP(object ID) {
			if (ID == DBNull.Value) return ID;
			if (lookupAccount.ContainsKey(ID)) return lookupAccount[ID];
			// ottengo il newID nell'esercizio corrente 

			object newID = Conn.DO_READ_VALUE("accountlookup",QHS.CmpEq("oldidacc", ID), "newidacc");
			if (newID != null) lookupAccount[ID] = newID;
			return lookupAccount[ID];
		}

		Dictionary<object, bool> _agency_does_not_use_nbill = new Dictionary<object, bool>();
		bool agency_does_not_use_nbill(object idcsa_agency) {
			if ((idcsa_agency == DBNull.Value) || (idcsa_agency == null)) return true;
			if (_agency_does_not_use_nbill.ContainsKey(idcsa_agency)) {
				return _agency_does_not_use_nbill[idcsa_agency];
			} else {
				int flag = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("csa_agency", QHS.CmpEq("idcsa_agency", idcsa_agency), "(ISNULL(csa_agency.flag, 0)&2)"));
				_agency_does_not_use_nbill[idcsa_agency] = flag != 0;
				return _agency_does_not_use_nbill[idcsa_agency];
			}
		}

		private bool doSave() {
			int faseMax = CfgFn.GetNoNullInt32(Meta.GetSys("maxexpensephase"));

			GestioneAutomatismi ga = new GestioneAutomatismi(this, Meta.Conn, Meta.Dispatcher, dsFinancial,
				faseMax, faseMax, "expense", true);
			ga.GeneraClassificazioniAutomatiche(ga.DSP, true);
			ga.GeneraClassificazioniIndirette(ga.DSP, true);


			bool res = ga.GeneraAutomatismiAfterPost(true);
			if (!res) {
				MessageBox.Show(this,
					"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
				return false;
			} else {
				res = ga.doPost(Meta.Dispatcher);
				if (res) {
					MessageBox.Show(this, "Salvataggio dei movimenti finanziari avvenuto con successo");
					return true;
				} else {
					MessageBox.Show(this,
						"Si è verificato un errore o si è deciso di non salvare! L'operazione sarà terminata");
					return false;
				}
			}

		}
		/// <summary>
		/// Riempie i campi della riga E_S, in base alla riga di automatismo Auto
		/// </summary>
		/// <param name="E_S">riga da riempire</param>
		/// <param name="Auto">riga di automatismo</param>
		private void fillMovimento(DataRow E_S, DataRow Auto) {
			//, string idmovimento)
			int esercizio = Convert.ToInt32(Meta.GetSys("esercizio"));
			DateTime DataCont = Convert.ToDateTime(Meta.GetSys("datacontabile"));
			E_S.BeginEdit();
			E_S["ymov"] = esercizio;
			E_S["adate"] = DataCont;

			string[] fields_to_copy = new string[] { "idman", "idreg", "description" };
			foreach (string field in fields_to_copy) {
				if (Auto.Table.Columns[field] == null) continue;
				if (E_S.Table.Columns.Contains(field)) E_S[field] = Auto[field];
			}
			E_S.EndEdit();
		}

        

        Dictionary<int, Dictionary<int, decimal>> listaSospesi = new Dictionary<int, Dictionary<int, decimal>>();
		private void ValorizzaSospeso(DataTable T) {
			object nBill = getSospeso();
            //if (nBill == null || nBill == DBNull.Value || CfgFn.GetNoNullInt32(nBill) == 0) return;
			DataTable csaBill =  csa_bill_global;
			listaSospesi = getElencoSospesi(csaBill);
			// Valorizzo i sospesi sulle righe

			if (!T.Columns.Contains("nbill"))
				T.Columns.Add("nbill", typeof(Int32));
            foreach (DataRow r in SP_Result.Rows) {
                if (r["kind"].ToString() != "Spesa") continue;
                if (CfgFn.GetNoNullDecimal(r["netto"]) != 0) {
                    // Per alcuni enti versamento non si deve specificare il sospeso sui movimenti di tipo 4, Versamento Contributi e Ritenute
                    object idcsa_agency = _spesaEnte[r["idexp"]];
                    if (agency_does_not_use_nbill(idcsa_agency)) {
                        r["nbill"] = DBNull.Value;
                    }
                    else {
                        int idreg = CfgFn.GetNoNullInt32(r["idreg"]); 
                        r["nbill"] = nBill;
                        
                    }
                }
                else {
                    r["nbill"] = DBNull.Value; // Entrate o eventuali movimenti a netto 0
                }
                    
            }
        }

	 

		private void fillImportMov(string IoE, DataTable TMain, DataTable TPartition) {
			string tableNameMain = (IoE == "E") ? "csa_import_expense": "csa_import_income";
			string tableName = (IoE == "E") ? "csa_importver_partition_expense": "csa_importver_partition_income";
			string fieldName = (IoE == "E") ? "idexp": "idinc";
			MetaData MetaPartition = Meta.Dispatcher.Get(tableNameMain);
			MetaPartition.SetDefaults(dsFinancial.Tables[tableNameMain]);

			MetaData MetaPartitionVer = Meta.Dispatcher.Get(tableName);
			MetaPartitionVer.SetDefaults(dsFinancial.Tables[tableName]);

            if ((TMain != null) && (TMain.Rows.Count > 0)) {
                var movLinked = new Dictionary<string, bool>();
                foreach (DataRow RRipart in TMain.Rows) {
                    object idmov=(IoE == "E") ? getNewIdExp(RRipart[fieldName]) : getNewIdInc(RRipart[fieldName]);
                    if (idmov == DBNull.Value) continue;
                    string hash = $"{RRipart["idcsa_import"]}*{RRipart["movkind"]}*{idmov}";
                    if (movLinked.ContainsKey(hash)) continue;
                    movLinked[hash] = true;
                    DataRow ImportMovRow = MetaPartition.Get_New_Row(null, dsFinancial.Tables[tableNameMain]);
                    ImportMovRow["idcsa_import"] = RRipart["idcsa_import"];
                    ImportMovRow["movkind"] = RRipart["movkind"];
                    ImportMovRow[fieldName] = idmov;
                    

                    ImportMovRow["cu"] = "import";
                    ImportMovRow["ct"] = DateTime.Now;
                    ImportMovRow["lu"] = "import";
                    ImportMovRow["lt"] = DateTime.Now;
                }
            }

            if ((TPartition != null) && (TPartition.Rows.Count > 0)) {
                var movLinked = new Dictionary<string, bool>();
                foreach (DataRow RRipart in TPartition.Rows) {

                    object idmov = (IoE == "E") ? getNewIdExp(RRipart[fieldName]) : getNewIdInc(RRipart[fieldName]);
                    if (idmov == DBNull.Value) continue;

                    string hash = $"{RRipart["idcsa_import"]}*{RRipart["movkind"]}*{idmov}";
                    if (dsFinancial.Tables[tableName].Columns.Contains("ndetail")) {
                        hash += "*" + RRipart["ndetail"];
                    }

                    if (dsFinancial.Tables[tableName].Columns.Contains("idver")) {
                        hash += "*" + RRipart["idver"];
                    }

                    if (movLinked.ContainsKey(hash)) continue;
                    movLinked[hash] = true;
                    DataRow ImportMovRow = MetaPartitionVer.Get_New_Row(null, dsFinancial.Tables[tableName]);

                    ImportMovRow["idcsa_import"] = RRipart["idcsa_import"];
                    ImportMovRow["movkind"] = RRipart["movkind"];
                    ImportMovRow[fieldName] = idmov;
                    ImportMovRow["cu"] = "import";
                    ImportMovRow["ct"] = DateTime.Now;
                    ImportMovRow["lu"] = "import";
                    ImportMovRow["lt"] = DateTime.Now;

                    if (ImportMovRow.Table.Columns.Contains("ndetail")) {
                        ImportMovRow["ndetail"] = RRipart["ndetail"];
                    }

                    if (ImportMovRow.Table.Columns.Contains("idver")) {
                        ImportMovRow["idver"] = RRipart["idver"];
                    }

                    if (ImportMovRow.Table.Columns.Contains("amount")) {
                        ImportMovRow["amount"] = RRipart["originalamount"];
                    }
                }
            }
        }

		// Dictionary associazione tra idspesa originale e ente 
		Dictionary<object, object> _spesaEnte = new Dictionary<object, object>();

		private void getEnteVersamento(DataTable TPartition) {
			if ((TPartition != null) && (TPartition.Rows.Count > 0))
				foreach (DataRow RRipart in TPartition.Rows) {
					string filter = "";
					object idcsa_agency = DBNull.Value;
					if (RRipart["kind"].ToString() != "Spesa") continue;  // considero solo i movimenti finanziari di spesa
					idcsa_agency = RRipart ["idcsa_agency"];
					_spesaEnte[RRipart["idexp"]] = idcsa_agency;
				}
		}

	 
		private void fillMovSortedFaseMAX(string IoE, DataTable OriginalSorting) {
			fillMovSorted(IoE, OriginalSorting, "idsor");
		}

		
		Hashtable hSospesi = null;
		object getSospeso() {
			int nbill = 0;
			if (txtNumBollettaVersamenti.Text.Trim() != "") nbill = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int),
				txtNumBollettaVersamenti.Text, HelpForm.GetStandardTag(txtNumBollettaVersamenti.Tag)));
			if (nbill != 0) return nbill;
			return DBNull.Value;
		}
		Dictionary<int, Dictionary<int, decimal>> getElencoSospesi(DataTable t) {
			var l = new Dictionary<int, Dictionary<int, decimal>>();
			foreach (DataRow r in t.Rows) {
				//campi nbill, idreg, amount
				int nBill = (int)r["nbill"];
				int idreg = (int)r["idreg"];
				decimal amount = (decimal)r["amount"];
				if (!l.ContainsKey(idreg)) {
					l[idreg] = new Dictionary<int, decimal>();
				}

				var listaSospesi = l[idreg];
				if (!listaSospesi.ContainsKey(nBill)) {
					//MessageBox.Show("listaSospesi " + idreg.ToString() + nBill.ToString());
					listaSospesi[nBill] = 0;
				}

				listaSospesi[nBill] += amount;
			}
			//MessageBox.Show("sospesi " + l.Count.ToString());
			return l;
		}

		Dictionary<int, decimal> getSospesiPerAnagrafica(int idReg, Dictionary<int, Dictionary<int, decimal>> sospesi, decimal amountToCover) {
			var l = new Dictionary<int, decimal>();

			if (!sospesi.ContainsKey(idReg)) return l;
			var listaSospesi = sospesi[idReg];
			foreach (var nbill in listaSospesi.Keys.ToArray()) {
				//MessageBox.Show("sospeso " + nbill.ToString() + idReg.ToString());
				decimal residuo = listaSospesi[nbill];
				if (residuo == 0) continue; //superflua ma toglierla appare controintuitivo
				decimal amount = (residuo > amountToCover) ? amountToCover : residuo;//minimo tra i due
				residuo -= amount;
				amountToCover -= amount;
				listaSospesi[nbill] = residuo;
				l[nbill] = amount;
				if (amountToCover == 0) break;
			}

			return l;
		}

		private void fillMovSorted(string IoE, DataTable OriginalSorting, string field_for_idsor) {
			string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
			string idMovField = (IoE == "I") ? "idinc" : "idexp";
			string kind = (IoE == "I") ? "Entrata" : "Spesa";

			MetaData MetaSortedMov = Meta.Dispatcher.Get(tMainSorted);
			MetaSortedMov.SetDefaults(dsFinancial.Tables[tMainSorted]);
			int esercizio = getIntSys("esercizio");

			foreach (DataRow RSor in OriginalSorting.Rows) {
				if (RSor[field_for_idsor] == DBNull.Value) continue;
				object newIdMov = (kind == "Spesa")? getNewIdExp(RSor[idMovField]):getNewIdInc(RSor[idMovField]);
				if (newIdMov == DBNull.Value) continue;
				dsFinancial.Tables[tMainSorted].Columns["idsor"].DefaultValue = RSor[field_for_idsor];
				DataRow SortedMovRow = MetaSortedMov.Get_New_Row(null, dsFinancial.Tables[tMainSorted]);
				SortedMovRow["idsor"] = RSor[field_for_idsor];
				SortedMovRow["amount"] = RSor["originalamount"];
				SortedMovRow[idMovField] = newIdMov;
				for (int N = 1; N <= 5; N++) {
					foreach (char C in new char[] {'n', 'v', 's'}) {
						string fieldName = "value"+C + N.ToString();
						SortedMovRow[fieldName] = RSor[fieldName];
					}
				}

				SortedMovRow["ayear"] = esercizio;
				SortedMovRow["cu"] = "import";
				SortedMovRow["ct"] = DateTime.Now;
				SortedMovRow["lu"] = "import";
				SortedMovRow["lt"] = DateTime.Now;
			}
		}

		private void fillLastMovimento(string IoE, DataRow R, DataRow NewLastMov) {
			string idMovField = (IoE == "E") ? "idexp": "idinc";
			string filterMov =  QHS.CmpEq(idMovField,R[idMovField]);
			string tableName = (IoE == "E") ? "expenselast": "incomelast";
			string tMainBill = (IoE == "I") ? "incomebill" : "expensebill";
			string accountFieldName = (IoE == "I") ? "idacccredit": "idaccdebit";
			MetaData MetaMBill = Meta.Dispatcher.Get(tMainBill);
			MetaMBill.SetDefaults(dsFinancial.Tables[tMainBill]);
		
			string tableBillName="";

			if (IoE == "E") {
				accountFieldName = "idaccdebit";
                bool regolarizzazioneEffettuata = false;
				// Se il movimento è a regolarizzazione mette la bolletta
				// Verifico l'esistenza di sospesi multipli
				decimal amount = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
				// Singolo sospeso
				var bill = getSospesiPerAnagrafica(CfgFn.GetNoNullInt32( R["idreg"]), listaSospesi, amount);
				if ((bill.Keys.Count == 1) && (CfgFn.GetNoNullDecimal(R["netto"]) != 0)) {
					var Bill = bill.First();
					NewLastMov["nbill"] = Bill.Key;
					regolarizzazioneEffettuata = true;
				}
				// Ripartizione 
				if ((bill.Keys.Count > 1) && (CfgFn.GetNoNullDecimal(R["netto"]) != 0)) {
					foreach (int nBill in bill.Keys) {
                        if (amount == 0) continue;
                        if (bill[nBill] == 0) continue;
						var newBill = MetaMBill.Get_New_Row(NewLastMov, dsFinancial.Tables[tMainBill]);
						newBill["nbill"] = nBill;
						newBill["ybill"] = esercizio;
                        if (amount >= bill[nBill]) {
                            //svuota questo sospeso
                            newBill["amount"] = bill[nBill];
                            amount -= bill[nBill];
                            bill[nBill] = 0;
                        }
                        else {
                            //prende dal sospeso la parte che serve
                            newBill["amount"] = amount;
                            bill[nBill] -= amount;
                            amount = 0;
                        }
                    }
					regolarizzazioneEffettuata = true;
				}

				if ((bill.Keys.Count == 0) && (R["nbill"] != DBNull.Value)  && (CfgFn.GetNoNullDecimal(R["netto"]) != 0)) {
					NewLastMov["nbill"] = R["nbill"];
					NewLastMov["flag"] = CfgFn.GetNoNullInt32(NewLastMov["flag"]) | 1;
					regolarizzazioneEffettuata = true;
				}
				if (regolarizzazioneEffettuata) { 
					// Imposto un trattamento spese predefinito per il CSA
					// in caso di regolarizzazione
					object idchargehandling = DBNull.Value;
					idchargehandling = get_idchargehandling_CSA();
					NewLastMov["idchargehandling"] = idchargehandling;
					NewLastMov["flag"] = CfgFn.GetNoNullInt32(NewLastMov["flag"]) | 1;
				}
				else {
					// Se non è a regolrizzazione, copia la modalità di pagamento dalla riga vecchia
					string[] fields_to_copy = new string[] {
						"cc", "cin", "flag","iban","idbank","idcab","iddeputy","idregistrypaymethod",
						"paymentdescr","refexternaldoc","idpaymethod","biccode","extracode","paymethod_allowdeputy",
						"paymethod_flag","idchargehandling"};

					
					foreach (string field in fields_to_copy) {
						if (R.Table.Columns[field] == null) continue;
						NewLastMov[field] = R[field];
					}
				}
			}
			else {
					string[] fields_to_copy = new string[] {
					"flag", "nbill"};
					accountFieldName = "idacccredit";
					foreach (string field in fields_to_copy) {
						if (R.Table.Columns[field] == null) continue;
					NewLastMov[field] = R[field];
					}
			}
			
			object app = getNewContoEP(R[accountFieldName]);

			if (app != null) {
				NewLastMov[accountFieldName] = app;
			} else {
				NewLastMov[accountFieldName] = DBNull.Value;
			}
		}


		private void updateIdPayment() {
			foreach (DataRow RIncome in dsFinancial.Tables["income"].Rows) {
				if (RIncome["idpayment"] == DBNull.Value) continue;
				if (NewIdPayment.ContainsKey((int)RIncome["idpayment"]))
					RIncome["idpayment"] = NewIdPayment[(int)RIncome["idpayment"]];
			}
		}

		object __myFlagEsenteSpese_CSA = null;

		private object get_FlagEsenteSpese_CSA() {
			// flag di gestione dell'esenzione da spese, per chi non usa Circ. ABI 26, come Unicredit
			//if (Meta.IsEmpty) return DBNull.Value;
			if (__myFlagEsenteSpese_CSA != null)
				return __myFlagEsenteSpese_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myFlagEsenteSpese_CSA = rConfig["csa_flag"];
			return rConfig["csa_flag"];
		}

		object __myidchargehandliing_CSA = null;

		private object get_idchargehandling_CSA() {
			// flag di gestione del tipo trattamento spese CSA, obbligatorio per circolare ABI 36
			//if (Meta.IsEmpty) return DBNull.Value;
			if (__myidchargehandliing_CSA != null)
				return __myidchargehandliing_CSA;
			object esercizio = Meta.GetSys("esercizio");
			string filter = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
			DataTable t = Conn.RUN_SELECT("config", "*", null, filter, null, null, true);
			if (t == null) return DBNull.Value;
			if (t.Rows.Count == 0) return DBNull.Value;
			DataRow rConfig = t.Rows[0];
			__myidchargehandliing_CSA = rConfig["csa_idchargehandling"];
			return __myidchargehandliing_CSA;
		}
		private void fillImputazioneMovimento(string IoE, DataRow R,DataRow ImpMov) {
			string tableName = (IoE == "E") ? "expenseyear": "incomeyear";
			object idfin = getNewVoceBilancio(R["idfin"]);  
			ImpMov["idfin"] = idfin;
			ImpMov["idupb"] = R["idupb"];
            ImpMov["amount"] = -CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(R["amount"]));
        }

		/// <summary>
		/// Aggiunge i finanziamenti alla riga NewMovRow, corrispondente alla riga  raggruppata di spesa (di fase max) di indice index
		/// Aggiunge un finanziamento (eventualmente accorpandoli) per ogni riga non raggruppata associata al movimento in fase di creazione
		/// Se nessuna riga associata a quella corrente ha dei finanzimenti, viene utilizzato il metodo CercaFinanziamento_SolaCassa
		/// </summary>
		/// <param name="index">indice della riga di spesa raggruppata</param>
		/// <param name="NewMovRow">riga di spesa in fase di creazione</param>

		/// <summary>
		/// Aggiunge le righe collegate di bilancio, upb e creditore ai fini del salvataggio
		/// </summary>
		/// <param name="SP_Row"></param>









		/// <summary>
		/// Genera i movimenti di entrata e di spesa a partire dalle tabelle raggruppate
		/// </summary>
		/// <param name="IoE"></param>
		/// <returns></returns>
		Dictionary<int, int> NewIdPayment = new Dictionary<int, int>();
		private bool generaMovPrincipali(string IoE) {
          
            string tMain = (IoE == "I") ? "income" : "expense";
			string tMainVar = (IoE == "I") ? "incomevar" : "expensevar";
			string tMainYear = (IoE == "I") ? "incomeyear" : "expenseyear";
            string tMainLast = (IoE == "I") ? "incomelast" : "expenselast";
            string tMainBill = (IoE == "I") ? "incomebill" : "expensebill";
            string tMainSorted = (IoE == "I") ? "incomesorted" : "expensesorted";
            string tImportMain = (IoE == "I") ? "csa_import_income" : "csa_import_expense";
            string tImportMainVerPlus = (IoE == "I") ? "csa_importver_partition_income" : "csa_importver_partition_expense";
            string tImportMainRiepPlus = (IoE == "I") ? "csa_importriep_partition_income" : "csa_importriep_partition_expense";

			
            MetaData MetaM = Meta.Dispatcher.Get(tMain);
            MetaM.SetDefaults(dsFinancial.Tables[tMain]);

            MetaData MetaL = Meta.Dispatcher.Get(tMainLast);
            MetaL.SetDefaults(dsFinancial.Tables[tMainLast]);


            MetaData MetaMBill = Meta.Dispatcher.Get(tMainBill);
            MetaMBill.SetDefaults(dsFinancial.Tables[tMainBill]);

            MetaData MetaImputazioneMov = Meta.Dispatcher.Get(tMainYear);
            MetaImputazioneMov.SetDefaults(dsFinancial.Tables[tMainYear]);

            string maxPhaseName = (IoE == "I") ? "maxincomephase" : "maxexpensephase";
            int fasemax = getIntSys(maxPhaseName);

			int nPenultimaFase=  fasemax -1 ;

			string regPhaseName = (IoE == "I") ? "incomeregphase" : "expenseregphase";
            int faseCreditoreDebitore = getIntSys(regPhaseName);

            string finPhaseName = (IoE == "I") ? "incomefinphase" : "expensefinphase";
            int faseBilancio = getIntSys(finPhaseName);

            string idMovField = (IoE == "I") ? "idinc" : "idexp";
            string idParMovField = (IoE == "I") ? "parentidinc" : "parentidexp";

            string idAcc = (IoE == "I") ? "idacccredit" : "idaccdebit";

			Hashtable lookupIdMov = (IoE == "I") ? lookupIdInc: lookupIdExp;
			int esercizio = getIntSys("esercizio");

            DataTable Mov = dsFinancial.Tables[tMain];
            DataTable ImpMov = dsFinancial.Tables[tMainYear];
            DataTable ImportMov = dsFinancial.Tables[tImportMain];
            DataTable ImportMovRiepPlus = dsFinancial.Tables[tImportMainRiepPlus];
            DataTable ImportMovVerPlus = dsFinancial.Tables[tImportMainVerPlus];
			DataTable ImportMovVar = dsFinancial.Tables[tMainVar];
 
			RowChange.SetOptimized(Mov, true);
            RowChange.ClearMaxCache(Mov);
            RowChange.SetOptimized(ImpMov, true);
            RowChange.ClearMaxCache(ImpMov);
            RowChange.SetOptimized(ImportMov, true);
            RowChange.ClearMaxCache(ImportMov);
            RowChange.SetOptimized(ImportMovRiepPlus, true);
            RowChange.ClearMaxCache(ImportMovRiepPlus);
            RowChange.SetOptimized(ImportMovVerPlus, true);
            RowChange.ClearMaxCache(ImportMovVerPlus);

            DataTable AllPaymethod = Conn.RUN_SELECT("paymethod", "*", null, null, null, true);

			// Automatismi di entrata o spesa
			string kind = (IoE == "I") ? "Entrata" : "Spesa";
			string filterAutoYear =  QHS.AppAnd( QHS.CmpEq("kind", kind),QHS.CmpEq("ayear",esercizio-1));
			string filterAutoS =   QHS.CmpEq("kind", kind);
			string filterEsercizioPrecS = QHS.CmpEq("ayear", esercizio - 1);
			string filterOriginal = QHS.AppAnd(filterAutoS,filterEsercizioPrecS);
			List<DataRow> Auto = new List<DataRow>();


			SP_Result = DataAccess.RUN_SELECT(Meta.Conn, "csa_importver_varresidualview", "*", null, filterAutoYear, null, true);
			SP_Result.Columns.Add("idmovimento", typeof(int));
			SP_Result.Columns.Add("netto", typeof(decimal));
			if (IoE == "I") {
				foreach (DataRow r in SP_Result.Rows) {
					r["netto"] = 0;
				}
			}
			else {
				var RigheSpesaPerIdExp = new Dictionary<int, DataRow>();
				foreach (DataRow r in SP_Result.Rows) {
					r["netto"] = -CfgFn.GetNoNullDecimal(r["amount"]);
					RigheSpesaPerIdExp[CfgFn.GetNoNullInt32(r["idexp"])] = r;
				}
				var incomeResult = DataAccess.RUN_SELECT(Meta.Conn, "csa_importver_varresidualview", "*", null,   
							QHS.AppAnd( QHS.CmpEq("kind", "Entrata"),QHS.CmpEq("ayear",esercizio-1)), null, true);
				foreach (DataRow r in incomeResult.Rows) {
					int idexp = CfgFn.GetNoNullInt32(r["idpayment"]);
					if (idexp == 0) continue;
					DataRow RExp;
					if (!RigheSpesaPerIdExp.TryGetValue(idexp, out RExp)) continue;
					RExp["netto"] = CfgFn.GetNoNullDecimal(RExp["netto"]) +
					                // l'importo è negativo perchè quello della variazione di azzeramento
					                CfgFn.GetNoNullDecimal(r["amount"]);
				}
			}
			DataTable OriginalImpPartition  = DataAccess.RUN_SELECT(Meta.Conn, "csa_import_originalpartitionview","*", null, filterOriginal, null, true);
			DataTable OriginalVerPartition = DataAccess.RUN_SELECT(Meta.Conn, "csa_importver_originalpartitionview","*", null, filterOriginal, null, true);
			DataTable OriginalSorting = DataAccess.RUN_SELECT(Meta.Conn, "csa_originalsortingview","*", null, filterOriginal, null, true);
			getEnteVersamento(OriginalVerPartition);
			
			ValorizzaSospeso(SP_Result);
			for (int ii = 0; ii < SP_Result.Rows.Count; ii++) {
				DataRow R = SP_Result.Rows[ii];
				if (R["kind"].ToString() != kind) continue;
				Auto.Add(R);
				DataRow ParentR = null;
				object parentidmov = R[idParMovField];
				// Genera solo l'ultima fase
				int faseCorrente = fasemax;
				Mov.Columns["nphase"].DefaultValue = faseCorrente;
				DataRow NewMovRow = MetaM.Get_New_Row(ParentR, Mov);
				//Imposta il movimento parent tramite il livsupid. Il movimento parent è del movimento finanziario che stiamo ri-creando
				NewMovRow[idParMovField] = parentidmov;

				fillMovimento(NewMovRow, R);
				R["idmovimento"] = NewMovRow[idMovField];
				NewMovRow["nphase"] = faseCorrente;
				NewMovRow["autokind"] = 31;
				
			
				if (kind == "Spesa") {
					int newIdExp = (int) NewMovRow["idexp"];
					NewIdPayment[(int)R["idexp"]] = newIdExp;
				}

				if (R["idpayment"] != DBNull.Value) {
					int oldIdPayment = CfgFn.GetNoNullInt32(R["idpayment"]);
					
					NewMovRow["idpayment"] = NewIdPayment[oldIdPayment];
					// Devo propagare ala modifica alle fasi precedenti se ci sono
                    DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,dsFinancial.Tables[tMain],null, 
                            //non rilegge le ultime fasi in memoria, perchè di quelle NON va aggiornato l'idpayment, visto che non sono residue e sono incassi 
                            QHS.AppAnd( QHS.CmpEq("idpayment", R["idpayment"]), QHS.CmpLt("nphase",fasemax))
                            ,null,true);
				}

				// Valorizzo una tabella di lookup con la corrispondenza tra nuova e vecchia chiave
				lookupIdMov[R[idMovField]] = NewMovRow[idMovField];

				if (kind == "Spesa") {
					MetaData.SetDefault(dsFinancial.Tables[tMainLast],"paymethod_flag",0);//Altrimenti rimane null
				}

				DataRow NewLastRow = MetaL.Get_New_Row(NewMovRow, dsFinancial.Tables[tMainLast]);
                if (CfgFn.GetNoNullDecimal(R["netto"]) != 0) {
                    fillLastMovimento(IoE, R, NewLastRow);
                }
                
                DataRow NewImpMov = ImpMov.NewRow();

				fillImputazioneMovimento(IoE, R, NewImpMov);
				NewImpMov[idMovField] = NewMovRow[idMovField];
				NewImpMov["ayear"] = esercizio;

				ImpMov.Rows.Add(NewImpMov);
            }

			fillMovSortedFaseMAX(IoE, OriginalSorting); // ricrea  le classificazioni 
			fillImportMov(IoE, OriginalImpPartition, OriginalVerPartition); // ricrea le ripartizioni 
			updateIdPayment();

			return true;
        }



       
     
        /// <param name="kind">L lordi V versamenti</param>
        private void btnGeneraMovFin_Click(object sender, System.EventArgs e, string kind) {
            //Meta.GetFormData(true);
            string fEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if (MessageBox.Show(
                    " Attenzione: é necessario verificare preventivamente le singole importazioni dell'anno "+ "\r\n" +
                    " per rilevare e correggere possibili errori nell'individuazione di Anagrafiche, Contratti, Enti. " + "\r\n" +
                    " Premere OK per continuare lo stesso, in caso si sia già provveduto, oppure " + "\r\n" + 
                    " premere ANNULLA per interrompere l'elaborazione.", "Avviso", MessageBoxButtons.OKCancel)==DialogResult.Cancel) return;

            dsFinancial.Clear();
            dsFinancial.AcceptChanges();
            RowChange.SetOptimized(dsFinancial.expensesorted, true);
            RowChange.ClearMaxCache(dsFinancial.expensesorted);
            RowChange.SetOptimized(dsFinancial.incomesorted, true);
            RowChange.ClearMaxCache(dsFinancial.incomesorted);
            RowChange.SetOptimized(dsFinancial.underwritingappropriation, true);
            RowChange.ClearMaxCache(dsFinancial.underwritingappropriation);
            RowChange.SetOptimized(dsFinancial.underwritingpayment, true);
            RowChange.ClearMaxCache(dsFinancial.underwritingpayment);
			RowChange.ClearMaxCache(dsFinancial.underwritingpayment);
			if (dsFinancial.config.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.config,
					null, fEsercizio, null, true);
			}

			if (dsFinancial.sortingkind.Rows.Count == 0) {
				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, dsFinancial.sortingkind,
					null, null, null, true);
			}

			NewIdPayment.Clear();

			// Verificare l'esistenza di movimenti finanziari precedentemente generati
			if (!generaMovPrincipali("E")) {
				MessageBox.Show(this, "Errore nella generazione dei movimenti finanziari di spesa");
                dsFinancial.Clear();
                dsFinancial.AcceptChanges();
                return;
            }

			if (!generaMovPrincipali("I")) {
				MessageBox.Show(this, "Errore nella generazione dei movimenti finanziari di spesa");
                dsFinancial.Clear();
                dsFinancial.AcceptChanges();
                return;
            }
                    

            if (doSave()) {
                labelRisultato.Text = "Dati salvati con successo";
            }
            else labelRisultato.Text = "I Dati non sono stati salvati";
            //progressBarImport.Visible = false;
            dsFinancial.Clear();
            dsFinancial.AcceptChanges();
               
    }

		bool executing = false;

		private void btnVersamenti_Click(object sender, EventArgs e) {
			if (executing) return;
			if (!VerificaIndividuazione()) {
				MessageBox.Show(this, "Errori bloccanti nella chiamata della procedura di verifica:", "Errore");
				return;
			}
            btnVersamenti.Visible = false;
            executing = true;
            tabController.SelectedTab = tabRisultati;
			//sia entrate che spese
			string message="";
			 
            btnGeneraMovFin_Click(sender, e, "V");
           
            btnVersamenti.Visible = true;
            executing = false; // Consente di rieseguire la procedura
        }

		private void btnBollettaVersamenti_Click(object sender, EventArgs e) {
			string filteresercizio = QHS.CmpEq("ybill", Meta.GetSys("esercizio"));
			int annosuccessivo = Convert.ToInt32(Meta.GetSys("esercizio")) + 1;
			string filteresercizionew = QHS.CmpEq("ybill", annosuccessivo);

			string filter = (QHS.DoPar(QHS.AppOr(filteresercizio, filteresercizionew)));

			filter = QHS.AppAnd(filter, QHS.CmpEq("billkind", "D"));

			string VistaScelta = "billview";

			MetaData meta_bill = Meta.Dispatcher.Get(VistaScelta);
			meta_bill.FilterLocked = true;
			meta_bill.DS = DS;
			DataRow myDr = meta_bill.SelectOne("default", filter, null, null);
			if (myDr != null) {
				DS.bill_versamenti.Clear();
				Meta.Conn.RUN_SELECT_INTO_TABLE(DS.bill_versamenti, null,
					QHS.AppAnd(QHS.CmpEq("ybill", myDr["ybill"]),
							   QHS.CmpEq("nbill", myDr["nbill"]),
								QHS.CmpEq("billkind", "D")),
					null, true);
				txtEsercBollettaVersamenti.Text = myDr["ybill"].ToString();
				txtNumBollettaVersamenti.Text = myDr["nbill"].ToString();
				HelpForm.FormatLikeYear(txtEsercBollettaVersamenti);
			}
		}

		#region importazione bollette
		private void ImpostaColonneTracciatoDettagli(DataTable mData) {
			mData.Columns.Clear();
			mData.Columns.Add("denominazione_anagrafica", typeof(string));
			mData.Columns.Add("n_sospeso", typeof(int));
			mData.Columns.Add("importo", typeof(decimal));
		}

		public string getTracciato(string[] tracciato) {
			string res = "";
			int pos = 0;
			foreach (string t in tracciato) {
				string[] ss = t.Split(';');
				string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
							   ss[3].PadLeft(4) +
							   " Tipo: " + ss[2].PadLeft(15);
				if (ss[2].ToLower() == "codificato") {
					field += " Codifica:" + ss[4];
				}
				field += " Descrizione: " + ss[1];
				field += "\r\n";
				pos += CfgFn.GetNoNullInt32(ss[3]);
				res += field;
			}
			return res;
		}

		public DataTable getTableTracciato(string[] tracciato) {
			int pos = 0;
			DataTable T = new DataTable("t");
			T.Columns.Add("nome", typeof(string));
			T.Columns.Add("posizione", typeof(int));
			T.Columns.Add("lunghezza", typeof(string));
			T.Columns.Add("tipo", typeof(string));
			T.Columns.Add("codifica", typeof(string));
			T.Columns.Add("Descrizione", typeof(string));

			foreach (string t in tracciato) {
				DataRow r = T.NewRow();
				string[] ss = t.Split(';');
				r["nome"] = ss[0];
				r["posizione"] = pos;
				r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
				r["tipo"] = ss[2];
				if (ss.Length == 5) r["codifica"] = ss[4];
				r["Descrizione"] = ss[1];
				pos += CfgFn.GetNoNullInt32(ss[3]);
				T.Rows.Add(r);
			}
			return T;
		}

		private void MenuEnterPwd_Click(object sender, EventArgs e) {
            if (sender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(sender.GetType()))) return;
            object mysender = ((MenuItem)sender).Parent.GetContextMenu().SourceControl;
            string tracciato = "";
            DataTable TableTracciato = null;

            tracciato = getTracciato(tracciato_sospeso);
            TableTracciato = getTableTracciato(tracciato_sospeso);
            FrmShowTracciato FT = new FrmShowTracciato(tracciato, TableTracciato, "struttura");
            FT.ShowDialog();
        }

        string[] tracciato_sospeso =
		  new string[]{
							"DENOMINAZIONE_ANAGRAFICA;Anagrafica;Stringa;150",
							"N_SOSPESO;Numero sospeso(nbill);Intero;8",
							"IMPORTO;Importo;Numero;22"
	   };
		Dictionary<object, int> __myNBill = new Dictionary<object, int>();

		private bool checkSospeso(object n_sospeso) {
			if ((n_sospeso == null) || (n_sospeso == DBNull.Value)) return false;
			string key = n_sospeso.ToString();
			if (__myNBill.ContainsKey(key))
				return true;

			string filtro = QHS.AppAnd(QHS.CmpEq("nbill", n_sospeso), QHS.CmpEq("ybill",Meta.GetSys("esercizio")), QHS.CmpEq("billkind", "D"));
			DataTable Bill = Conn.RUN_SELECT("bill", "*", null, filtro, null, true);
			if (Bill.Rows.Count == 0) return false;
			DataRow DefRow = Bill.Rows[0];
			__myNBill[key] = CfgFn.GetNoNullInt32(DefRow["nbill"]);
			return true;
		}


		Dictionary<string, int> __myidReg = new Dictionary<string, int>();

		private object getAnagrafica(object denominazione_anagrafica) {
			if ((denominazione_anagrafica == null) || (denominazione_anagrafica == DBNull.Value)) return null;
			string key = denominazione_anagrafica.ToString();
			if (__myidReg.ContainsKey(key))
				return __myidReg[key];
			string filtro = QHS.AppAnd(QHS.CmpEq("title", denominazione_anagrafica), QHS.NullOrEq("active", "S"));

			DataTable Registry = Conn.RUN_SELECT("registry", "*", null, filtro, null, true);
			if (Registry.Rows.Count == 0) return null;
			DataRow DefRow = Registry.Rows[0];
			__myidReg[key] = CfgFn.GetNoNullInt32(DefRow["idreg"]);
			return __myidReg[key];
		}
		private void fillSospesi() {
			if (!VerificaFileSospesi(mData)) return;
			csa_bill_global.Clear();
			DataTable csa_bill  = mData.Clone();
			csa_bill.Columns.Add("idreg", typeof(int));
			csa_bill.Columns.Remove("importo");
			csa_bill.Columns.Remove("N_SOSPESO");
			csa_bill.Columns.Add("amount", typeof(Decimal));
			csa_bill.Columns.Add("nbill", typeof(int));
			csa_bill.Columns.Add("motive", typeof(string));
			csa_bill.Columns.Add("datasospeso", typeof(DateTime));

			csa_bill.Columns["DENOMINAZIONE_ANAGRAFICA"].Caption = "Anagrafica";
			csa_bill.Columns["nbill"].Caption = "N. Sospeso";
			csa_bill.Columns["amount"].Caption = "Importo";
			csa_bill.Columns["motive"].Caption = "Causale";
			csa_bill.Columns["datasospeso"].Caption = "Data Sospeso";
			csa_bill.Columns["idreg"].Caption = ".#idreg";

			foreach (DataRow rFile in mData.Rows) {

				if (CfgFn.GetNoNullDecimal(rFile["importo"]) != 0) {
					var rSospeso = csa_bill.NewRow();
					rSospeso["DENOMINAZIONE_ANAGRAFICA"] = rFile["DENOMINAZIONE_ANAGRAFICA"];
					rSospeso["idreg"] = getAnagrafica(rFile["DENOMINAZIONE_ANAGRAFICA"]);
					rSospeso["nbill"] = rFile["N_SOSPESO"];
					rSospeso["amount"] = CfgFn.GetNoNullDecimal(rFile["IMPORTO"]);
					rSospeso["motive"] = getMotiveForNbill(rFile["N_SOSPESO"]);
					rSospeso["datasospeso"] = getDateForNbill(rFile["N_SOSPESO"]);
					csa_bill.Rows.Add(rSospeso);
				}
			}
			DataSet dsSospesi = new DataSet();
			dsSospesi.Tables.Add(csa_bill);
			csa_bill.TableName = "csa_bill";
			dgrSospesi.DataBindings.Clear();
			dgrSospesi.DataSource = null;
			dgrSospesi.TableStyles.Clear();
			HelpForm.SetDataGrid(dgrSospesi, csa_bill);
			formatgrids fg = new formatgrids(dgrSospesi);
			fg.AutosizeColumnWidth();
			csa_bill_global = csa_bill;
		}

		private bool VerificaFileSospesi(DataTable mData) {
			bool ok = true;
			DataSet Out = new DataSet();
			DataTable T = new DataTable();
			T.Columns.Add("errors", typeof(System.String), "");
			for (int i = 0; i < tracciato_sospeso.Length; i++) {
				string fmt = tracciato_sospeso[i];
				bool datiValidi = getField(fmt, T, mData);
				if (!datiValidi) ok = false;
			}

			Out.Tables.Add(T);

			if (!ok) {
				FrmViewError View = new FrmViewError(Out);
				View.Show();
			}

			return ok;
		}


		bool getField(string tracciato_field, DataTable T, DataTable mData) {


			bool ok = true;
			string[] ff = tracciato_field.Split(';');
			string fieldname = ff[0].ToLower();

			int len = Convert.ToInt32(ff[3]);
			string ftype = ff[2].ToLower().Trim(); //(intero/numero/stringa/codificato/data)
			int rownum = 0;
			foreach (DataRow riga in mData.Select()) {
				string val = riga[fieldname].ToString().Trim();
				rownum++;
				switch (fieldname) {

					case "importo":

						if (CfgFn.GetNoNullDecimal(val) <= 0) {
							string err = "Valore non previsto per il campo " + fieldname + " di tipo " + ftype + " e di valore " +
							val.Trim() + " alla riga " + rownum + ": inserire un importo maggiore di zero";
							DataRow row = T.NewRow();
							row["errors"] = err;
							T.Rows.Add(row);
							ok = false;
						}
						break;
					case "denominazione_anagrafica":
						if ((getAnagrafica(val) == DBNull.Value) || (getAnagrafica(val) == null)) {
							string err = "Anagrafica non trovata nella decodifica del campo " + fieldname +
											" di tipo " + ftype + " e di valore " +
							val.Trim() + " alla riga " + rownum;
							DataRow row = T.NewRow();
							row["errors"] = err;
							T.Rows.Add(row);
							ok = false;
						}
						break;
					case "n_sospeso":
						if (checkSospeso(val) == false) {
							string err = "Sospeso di uscita non valido nella decodifica del campo " + fieldname +
											" di tipo " + ftype + " e di valore " +
							val.Trim() + " alla riga " + rownum;
							DataRow row = T.NewRow();
							row["errors"] = err;
							T.Rows.Add(row);
							ok = false;
						}
						break;
				}
			}
			return ok;
		}


		Dictionary<int, string> __billMotive = new Dictionary<int, string>();

		string getMotiveForNbill(object nbill) {
			if (nbill == DBNull.Value)
				return "";
			int n = Convert.ToInt32(nbill);
			if (__billMotive.ContainsKey(n))
				return __billMotive[n];
			object motive = Conn.DO_READ_VALUE("bill", QHS.AppAnd( QHS.CmpEq("nbill", nbill), QHS.CmpEq("billkind", "D"), QHS.CmpEq("ybill", Meta.GetSys ("esercizio"))), "motive");
			if (motive == null) {
				motive = "[sospeso numero " + nbill + "]";
			}
			__billMotive[n] = motive.ToString();
			return motive.ToString();
		}


		Dictionary<int, string> __billDate = new Dictionary<int, string>();

		object getDateForNbill(object nbill) {
			if (nbill == DBNull.Value)
				return "";
			int n = Convert.ToInt32(nbill);
			if (__billDate.ContainsKey(n))
				return __billDate[n];
			object date = Conn.DO_READ_VALUE("bill", QHS.AppAnd(QHS.CmpEq("nbill", nbill), QHS.CmpEq("billkind", "D"), QHS.CmpEq("ybill", Meta.GetSys("esercizio"))), "adate");
			if (date == null) {
				date = "[data sospeso numero " + nbill + "]";
			}
			__billDate[n] = date.ToString();
			return date;
		}

		private bool interrogaFileExcel(string task) {
			mData.Clear();
			try {
				string fileName = openInputFileDlg.FileName;
				//ConnectionString = ExcelImport.ExcelConnString(fileName);
				ImpostaColonne(task);
				ReadCurrentSheet(fileName);
			} catch (Exception ex) {
				MessageBox.Show(this, "Errore nell'apertura del file! Processo Terminato\n" + ex.Message);
				return false;
			}

			return true;
		}

		/// <summary>
		/// legge i dati dal foglio di Excel a mData
		/// </summary>
		private void ReadCurrentSheet(string fileName) {
			try {
				lblTask.Text = "Apertura del file...Attendere";

				if (fileName.EndsWith("xls") || fileName.EndsWith("xlsx")) {
					// con header
					ExcelImport x = new ExcelImport();
					//ConnectionString = ExcelImport.ExcelConnString(fileName);
					x.ImportTable(fileName, mData, true, 2);
				}
				lblTask.Text = "";
			} catch (Exception ex) {
				MessageBox.Show(this, ex.Message);
			}
		}



		private void ImpostaColonne(string kind) {

			mData.Columns.Clear();
			switch (kind) {
				case "S": {
						mData.Columns.Add("DENOMINAZIONE_ANAGRAFICA", typeof(string));
						mData.Columns.Add("N_SOSPESO", typeof(int));
						mData.Columns.Add("IMPORTO", typeof(decimal));
						break;
					}
			}
		}

		#endregion

		private void btnInputSospesi_Click(object sender, EventArgs e) {
			DialogResult dr = openInputFileDlg.ShowDialog();
			if (dr != DialogResult.OK) {
				MessageBox.Show("Non è stato scelto alcun file");
				return;
			}

			string fileName = openInputFileDlg.FileName;

			if (!interrogaFileExcel("S")) {
				return;
			}
			fillSospesi();

		}

		private void btnDelSospesi_Click(object sender, EventArgs e) {
			dgrSospesi.DataBindings.Clear();
			dgrSospesi.DataSource = null;
			dgrSospesi.TableStyles.Clear();
		}

		private bool VerificaIndividuazione() {
			 
			string sp_name = "check_csa_available_deferred";
			 
			DataGrid dgr = dgrVerificheFin;

			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string errMess;

			DataSet ds = Conn.CallSP(sp_name,
				new object[] {esercizio -1}, 600, out errMess);
			if (errMess != null) {
				MessageBox.Show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
				return false;
			}
			DataTable tResult = ds.Tables[0];
			if (tResult.Rows.Count != 0) {
				// Visualizzazione del grid

				dgr.DataBindings.Clear();
				dgr.DataSource = null;
				dgr.TableStyles.Clear();
				HelpForm.SetDataGrid(dgr, tResult);
				FormatDataGrid(dgr, tResult);

				if (tResult.Select(QHC.CmpEq("blockingerror", "S")).Length > 0)
					return false;
				else {
					return true;
				}
			} else return true;
		}
		private void btnVerifica_Click(object sender, EventArgs e) {
			if (!VerificaIndividuazione()) MessageBox.Show(this, "Errori bloccanti nella chiamata della procedura di verifica:" ,"Errore"); 
			else MessageBox.Show(this, "La procedura di verifica non ha restituito errori:", "Avviso");
		}

		private void dgrVerifiche_DoubleClick(object sender, EventArgs e) {
			DataGrid dataGrid = (DataGrid)sender;
			DataRow RigheSelezionata = GetGridSelectedRows(dataGrid);
			string kind_of_errors = "FIN";
			 
			if (RigheSelezionata == null)
				return;

			if (CfgFn.GetNoNullInt32(RigheSelezionata["errorcode"]) > 0)
				VisualizzaElenchi(CfgFn.GetNoNullInt32(RigheSelezionata["errorcode"]));
		}

		private void VisualizzaElenchi(int errorcode) {
			if (Meta.IsEmpty) return;
			if (errorcode <= 0) return;
			if (errorcode > AllList.Length) {
				MessageBox.Show(
					"Aggiornare il programma, la DLL di importazione CSA non è allineata con i check del db.",
					"Errore");
				return;
			}
			AllList[errorcode - 1](null, null);
			 
		}

		private DataRow GetGridSelectedRows(DataGrid G) {
			DataSet DSV = (DataSet) G.DataSource;
			if (DSV == null) return null;
			DataTable TV = DSV.Tables[G.DataMember];
			if (TV == null) return null;

			if (TV.Rows.Count == 0) return null;
			DataRowView DV = null;
			try {
				DV = (DataRowView)G.BindingContext[DSV, TV.TableName].Current;
			} catch {
				DV = null;
			}
			if (DV == null) return null;

			DataRow R = DV.Row;
			return R;
		}
	}

}