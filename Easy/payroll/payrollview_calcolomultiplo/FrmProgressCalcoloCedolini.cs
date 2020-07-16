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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using calcolocedolino;//calcolocedolino
using ep_functions;
using funzioni_configurazione;
using metaeasylibrary;
using System.Collections.Generic;

namespace payrollview_calcolomultiplo//cedolino_calcolomultiplo//
{
	/// <summary>
	/// Summary description for FrmProgressCalcoloCedolini.
	/// </summary>
	public class FrmProgressCalcoloCedolini : System.Windows.Forms.Form
	{
		//enum operazione {Si, SiTutti, No, NoTutti};
		public bool occorreAggiornare;
		private bool interrompi, primaVolta = true;
		private MetaData Meta; 
		private ArrayList cedolini;
		private ArrayList contratti;
		private string filtroContratti;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button btnInterrompi;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtCedoliniCalcolati;
		private System.Windows.Forms.TextBox txtErrori;
		private System.Windows.Forms.Label lblEsaminati;
		private System.Windows.Forms.Label lblCalcolati;
		private System.Windows.Forms.Label lblScartati;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        CQueryHelper QHC;
        QueryHelper QHS;
		public FrmProgressCalcoloCedolini(MetaData Meta, ArrayList cedolini, ArrayList contratti, string filtroContratti)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.Meta = Meta;
			this.cedolini = cedolini;
			this.contratti = contratti;
			this.filtroContratti = filtroContratti;
            QHC = new CQueryHelper();
            QHS = this.Meta.Conn.GetQueryHelper();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			interrompi = true;
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.btnInterrompi = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.lblScartati = new System.Windows.Forms.Label();
			this.lblCalcolati = new System.Windows.Forms.Label();
			this.lblEsaminati = new System.Windows.Forms.Label();
			this.txtCedoliniCalcolati = new System.Windows.Forms.TextBox();
			this.txtErrori = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(16, 152);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(668, 23);
			this.progressBar1.TabIndex = 0;
			// 
			// btnInterrompi
			// 
			this.btnInterrompi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnInterrompi.Location = new System.Drawing.Point(328, 184);
			this.btnInterrompi.Name = "btnInterrompi";
			this.btnInterrompi.TabIndex = 1;
			this.btnInterrompi.Text = "Interrompi";
			this.btnInterrompi.Click += new System.EventHandler(this.btnInterrompi_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.lblScartati);
			this.groupBox1.Controls.Add(this.lblCalcolati);
			this.groupBox1.Controls.Add(this.lblEsaminati);
			this.groupBox1.Location = new System.Drawing.Point(16, 32);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(120, 100);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			// 
			// lblScartati
			// 
			this.lblScartati.Location = new System.Drawing.Point(8, 72);
			this.lblScartati.Name = "lblScartati";
			this.lblScartati.Size = new System.Drawing.Size(110, 23);
			this.lblScartati.TabIndex = 2;
			this.lblScartati.Text = "Scartati:";
			// 
			// lblCalcolati
			// 
			this.lblCalcolati.Location = new System.Drawing.Point(8, 48);
			this.lblCalcolati.Name = "lblCalcolati";
			this.lblCalcolati.Size = new System.Drawing.Size(110, 23);
			this.lblCalcolati.TabIndex = 1;
			this.lblCalcolati.Text = "Calcolati:";
			// 
			// lblEsaminati
			// 
			this.lblEsaminati.Location = new System.Drawing.Point(8, 24);
			this.lblEsaminati.Name = "lblEsaminati";
			this.lblEsaminati.Size = new System.Drawing.Size(110, 23);
			this.lblEsaminati.TabIndex = 0;
			this.lblEsaminati.Text = "Esaminati:";
			// 
			// txtCedoliniCalcolati
			// 
			this.txtCedoliniCalcolati.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.txtCedoliniCalcolati.Location = new System.Drawing.Point(144, 24);
			this.txtCedoliniCalcolati.Multiline = true;
			this.txtCedoliniCalcolati.Name = "txtCedoliniCalcolati";
			this.txtCedoliniCalcolati.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCedoliniCalcolati.Size = new System.Drawing.Size(168, 120);
			this.txtCedoliniCalcolati.TabIndex = 4;
			this.txtCedoliniCalcolati.Text = "";
			// 
			// txtErrori
			// 
			this.txtErrori.AcceptsReturn = true;
			this.txtErrori.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrori.Location = new System.Drawing.Point(320, 24);
			this.txtErrori.Multiline = true;
			this.txtErrori.Name = "txtErrori";
			this.txtErrori.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtErrori.Size = new System.Drawing.Size(368, 120);
			this.txtErrori.TabIndex = 5;
			this.txtErrori.Text = "";
			this.txtErrori.WordWrap = false;
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(8, 214);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(200, 8);
			this.label1.Name = "label1";
			this.label1.TabIndex = 7;
			this.label1.Text = "Calcolati";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(408, 8);
			this.label2.Name = "label2";
			this.label2.TabIndex = 8;
			this.label2.Text = "Scartati";
			// 
			// FrmProgressCalcoloCedolini
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 214);
			this.Controls.Add(this.txtCedoliniCalcolati);
			this.Controls.Add(this.txtErrori);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnInterrompi);
			this.Controls.Add(this.progressBar1);
			this.Name = "FrmProgressCalcoloCedolini";
			this.Text = "Statistiche Cedolini";
			this.Activated += new System.EventHandler(this.FrmProgressCalcoloCedolini_Activated);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		
		private void FrmProgressCalcoloCedolini_Activated(object sender, System.EventArgs e)
		{
			if (!primaVolta) return;
			primaVolta = false;
			ArrayList cedoliniDaCalcolare = new ArrayList();
			int scartati = 0;
			progressBar1.Maximum = cedolini.Count;

			lblEsaminati.Text = "Esaminati: "+progressBar1.Value+" / "+progressBar1.Maximum;
			lblCalcolati.Text = "Calcolati: "+0;
			lblScartati.Text = "Scartati: "+scartati;

			string orderby = "fiscalyear, npayroll, flagbalance";
			DataTable tempCed = Meta.Conn.RUN_SELECT("payroll",
				"idcon, idpayroll, " + orderby, orderby, 
				QHS.AppAnd(QHS.CmpEq("flagcomputed", 'N'), QHS.FieldInList("idcon", filtroContratti)), null, true);

			tempCed.Columns.Add("flagselezionato");
			tempCed.Columns.Add("flagultimocedolino");
			foreach (int idCedolino in cedolini) 
			{
                DataRow[] rCedSel = tempCed.Select(QHC.CmpEq("idpayroll", idCedolino));
				rCedSel[0]["flagselezionato"] = "S";
			}
			occorreAggiornare = false;
			ArrayList cedoliniDiConguaglioDaCalcolare = new ArrayList();
			foreach (string idContratto in contratti) 
			{
				string filtroContratto = QHS.CmpEq("idcon", idContratto);
				string filtroImpContratto = QHS.AppAnd(filtroContratto, QHS.CmpEq("ayear", Meta.GetSys("esercizio")));
				DataTable ImpContratto = Meta.Conn.RUN_SELECT("parasubcontractyear",
					"*",null, filtroImpContratto, null, true);
				int count = 0;
				string precedenti = null;
				DataRow[] rCed = tempCed.Select(filtroContratto, orderby);
				for (int i=0; i<rCed.Length; i++) 
				{

					if (rCed[i]["flagselezionato"] is DBNull) 
					{
						if (count == 0) 
						{
							precedenti = rCed[i]["idpayroll"].ToString();
						} 
						else 
						{
							precedenti += ", " + rCed[i]["idpayroll"];
						}
						count ++;
					} 
					else 
					{
						bool erroreSuQuestoCedolino = false;
						if (ImpContratto.Rows.Count==0){
							txtErrori.Text += "n∞ " + rCed[i]["idpayroll"] + "  (contratto non ancora trasferito dall'esercizio fiscale precedente";
							txtErrori.Text += ")\r\n";
							erroreSuQuestoCedolino = true;
						}
						if (count != 0) 
						{
							txtErrori.Text += "n∞ " + rCed[i]["idpayroll"] + "  (prima calcolare ";
							txtErrori.Text += (count == 1) ? "il cedolino n∞ " : "i cedolini n∞ ";
							txtErrori.Text += precedenti + ")\r\n";
							erroreSuQuestoCedolino = true;
						} 
						else 
						{
							string fCedCong = "idcon='"+rCed[i]["idcon"]
								+ "' and fiscalyear="+rCed[i]["fiscalyear"]
								+ " and npayroll="+rCed[i]["npayroll"]
								+ " and flagbalance='S'";
							DataRow[] rCedCong = tempCed.Select(fCedCong);
							if (rCedCong.Length>0) 
							{
								rCed[i]["flagultimocedolino"] = "S";
								cedoliniDiConguaglioDaCalcolare.Add((int)rCedCong[0]["idpayroll"]);
//								if (rCedCong[0]["flagselezionato"] is DBNull) 
//								{
//									count = 1;
//									txtErrori.Text += "n∞ " + rCed[i]["idpayroll"] 
//										+ "  (calcolare insieme al cedolino di conguaglio n∞ "
//										+ rCedCong[0]["idpayroll"] +")\r\n";
//									erroreSuQuestoCedolino = true;
//								}
							}
						}
						if (!erroreSuQuestoCedolino) {
							cedoliniDaCalcolare.Add(rCed[i]["idpayroll"]);
						} else 
						{
							scartati ++;
							lblScartati.Text = "Scartati: "+scartati;
							progressBar1.Value ++;
						}
						lblEsaminati.Text = "Esaminati: "+progressBar1.Value+" / "+progressBar1.Maximum;
						Application.DoEvents();
					}

					if (interrompi) 
					{
						btnInterrompi.Text = "Chiudi";
						return;
					}
				}
			}

			IEnumerator en = cedoliniDaCalcolare.GetEnumerator();
			string cedoliniRataCalcolati = "";
			if (en.MoveNext()) {
				string filtroCedoliniDaCalcolare = "(idpayroll in ("+en.Current;
				while (en.MoveNext()) {
					filtroCedoliniDaCalcolare += ", "+en.Current;
				}
				
				foreach(int cedolinoConguaglio in cedoliniDiConguaglioDaCalcolare) {
					filtroCedoliniDaCalcolare += "," + cedolinoConguaglio;
				}
				filtroCedoliniDaCalcolare += "))";

				int calcolati = 0;
				CalcoliCococo coc = new CalcoliCococo(Meta.Dispatcher, Meta.Conn, filtroCedoliniDaCalcolare);
				foreach (int idCedolino in cedoliniDaCalcolare) {
					DataRow rCedolino = tempCed.Select(QHC.CmpEq("idpayroll", idCedolino))[0];
					bool ultimoCedolino = (rCedolino["flagultimocedolino"] != DBNull.Value);
					string errore = null;
					if (ultimoCedolino) {
						int idCedolinoConguaglio = ottieniIdCedolinoConguaglio(rCedolino, tempCed);
						errore = coc.calcolaCedolino(idCedolino, false, "N");
						if (errore != null) {
							MessageBox.Show(this,"Errore nel calcolo del cedolino n∞ "+idCedolino+".\n" + errore);
						}
						else {
							errore = coc.calcolaCedolino(idCedolinoConguaglio, false, "F");
							if (errore != null) {
								MessageBox.Show(this,"Errore nel calcolo del cedolino n∞ "+idCedolinoConguaglio+".\n" + errore);
							}
							else {						
								errore = coc.aggiungiRitenuteNonFiscaliCedolinoConguaglio(idCedolinoConguaglio, false);
								if (errore != null) {
									MessageBox.Show(this,"Errore nel calcolo del cedolino n∞ "+idCedolinoConguaglio+".\n" + errore);
								}
								else {
									errore = coc.aggiungiRitenuteFiscaliUltimoCedolinoRata(idCedolino, idCedolinoConguaglio, false);
									if (errore != null) {
										MessageBox.Show(this,"Errore nel calcolo del cedolino n∞ "+idCedolino+".\n" + errore);
									}
									else {
										errore = coc.aggiornaDatiCedolinoConguaglio(idCedolinoConguaglio, false);
										if (errore != null) {
											MessageBox.Show(this, "Errore nel calcolo del cedolino n∞ " + idCedolinoConguaglio+".\n" + errore);
										}
									}
								}
							}
						}
					}
					else {
						errore = coc.calcolaCedolino(idCedolino, false, "T");
					}
					if (errore == null) {
						calcolati ++;
						occorreAggiornare = true;
						lblCalcolati.Text = "Calcolati: " + calcolati;
						if (txtCedoliniCalcolati.Text == "") {
							txtCedoliniCalcolati.Text = idCedolino.ToString();
							cedoliniRataCalcolati = "'" + idCedolino + "'";
						} 
						else {
							txtCedoliniCalcolati.Text += ", " + idCedolino;
							cedoliniRataCalcolati += ", '" +idCedolino + "'";
						}
					}
					else {
						txtErrori.Text += "n∞ " + idCedolino + "  (" + errore + ")\r\n";
					} 
					progressBar1.Value ++;
					lblEsaminati.Text = "Esaminati: "+progressBar1.Value+" / "+progressBar1.Maximum;
					Application.DoEvents();
					if (interrompi) {
						btnInterrompi.Text = "Chiudi";
						return;
					}
				}
				string errMess = coc.salvaSulDB();
				if (errMess == null) {
                    GeneraImpegniEScritture(cedoliniRataCalcolati);                    
				}


			}
			btnInterrompi.Text = "OK";
		}

		public void GeneraScritture(string elencoCedolini){
			if (elencoCedolini == "") return;
            DataAccess Conn = Meta.Conn;
            int esercizio = Conn.GetEsercizio();

			DataTable tCedolino = DataAccess.CreateTableByName(Meta.Conn, "payroll", "*");
			DataTable tContratto = DataAccess.CreateTableByName(Meta.Conn, "parasubcontract", "*");
			DataTable tCedolinoRitenuta = DataAccess.CreateTableByName(Meta.Conn, "payrolltax", "*");
			DataTable tTipoRitenuta = DataAccess.CreateTableByName(Meta.Conn, "tax", "*");
			string filtroCedolini = QHS.FieldInList("idpayroll", elencoCedolini);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tTipoRitenuta, null, null, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCedolino, null, filtroCedolini, null, true);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCedolinoRitenuta, null, filtroCedolini, null, true);
			string elencoContratti = QHS.FieldInList("idcon", QueryCreator.ColumnValues(tCedolino,null,"idcon",true));
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tContratto, null, elencoContratti, null, true);
            string flagEpExp = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetEsercizio()), "flagepexp").ToString().ToUpper();


            // L'anagrafica usata per la parte verso ente Ë quella della cfg. ritenute, eventualmente spacchettata 
            //  ove ci sia la ripartizione percentuale (in questo caso sarebbe opportuno usare la liq. diretta)
            //Invece l'anagrafica per la parte "conto ente" Ë quella della cfg. delle partite di giro
            object idregauto = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "idregauto");

            TaxEntryHelper TEH = new TaxEntryHelper(Conn);

			foreach(DataRow CurrCedolino in tCedolino.Rows) {
				DataRow CurrContratto = tContratto.Select(QHC.CmpEq("idcon", CurrCedolino["idcon"]))[0];
			
				object idreg = CurrContratto["idreg"];
				object idupb = CurrContratto["idupb"];

				EP_functions EP = new EP_functions(Meta.Dispatcher);
				if (!EP.attivo) return;
				EP.GetEntryForDocument(CurrCedolino);

                object descr = "Contratto n." + CurrContratto["ncon"].ToString() + " del " +
                             CurrContratto["ycon"].ToString() + " - " +
                 "Cedolino n. " + CurrCedolino["fiscalyear"] + "/" + CurrCedolino["npayroll"];
                object doc = "Contr. " + CurrContratto["ncon"].ToString() + "/" +
                    CurrContratto["ycon"].ToString() +
                    " Cedolino " + CurrCedolino["npayroll"] + "/" + CurrCedolino["fiscalyear"];


                DataRow mainEntry= EP.SetEntry(descr, Meta.GetSys("datacontabile"),
					doc,Meta.GetSys("datacontabile"),EP_functions.GetIdForDocument(CurrCedolino));
			
				EP.ClearDetails(mainEntry);
				object idaccmot_main= CurrContratto["idaccmotive"];
				if (idaccmot_main==DBNull.Value){
					MessageBox.Show("Non Ë stata impostata la causale per la prestazione.");
					return;
				}
			
				string idepcontext="PRESTAZ";
                object idacc_registry = EP.GetSupplierAccountForRegistry(
                    CurrContratto["idaccmotivedebit"], CurrContratto["idreg"]);

                if (idacc_registry == null || idacc_registry == DBNull.Value) {
					MessageBox.Show("Non Ë stato configurato il conto di debito/credito opportuno");
					return;
				}

				decimal totale = CfgFn.GetNoNullDecimal(CurrCedolino["feegross"]);


                string idrelated = BudgetFunction.GetIdForDocument(CurrCedolino);
                object idepexp = Conn.DO_READ_VALUE("epexp", QHS.AppAnd(QHS.CmpEq("idrelated", idrelated), QHS.CmpEq("nphase", 2)), "idepexp");
                if ((idepexp == null || idepexp == DBNull.Value) && flagEpExp == "S" && esercizio > 2015) {
                    MessageBox.Show("Errore", "Non Ë stato trovato alcun impegno di budget per il contratto");
                    return;
                }




                decimal contributiNonConfigurati = 0;

                //Per tutti i CONTRIBUTI:
                //Se Ë configurato il conto di debito 
                //	effettua la scrittura COSTO->debito conto ente  (idaccmotive_cost -> idaccmotive_debit)
                // altrimenti
                //  effettua la scrittura COSTO->debito verso ente   (idaccmotive_cost -> idaccmotive_pay)

                foreach (DataRow Rit in tCedolinoRitenuta.Rows){
					decimal amount = CfgFn.GetNoNullDecimal(Rit["admintax"]);
					if (amount==0) continue;

					string filtroRit = QHC.CmpEq("taxcode", Rit["taxcode"]);
					DataRow TipoRit = tTipoRitenuta.Select(filtroRit)[0];
					if (TipoRit==null) continue;
				
					//Se la causale di costo non Ë configurata, prende la causale principale
					object idaccmotive_cost= idaccmot_main;
					if (TipoRit["idaccmotive_cost"]!=DBNull.Value) idaccmotive_cost=TipoRit["idaccmotive_cost"];
                    if (idaccmotive_cost == idaccmot_main) {
                        idaccmotive_cost = DBNull.Value;
                    }

                    object idaccmotive_touse=DBNull.Value;
                    bool debitoCONTOerario = false;
                    if (TipoRit["idaccmotive_debit"] != DBNull.Value) {
                        idaccmotive_touse = TipoRit["idaccmotive_debit"];//debito CONTO erario
                        debitoCONTOerario = true;
                    }
                    else {
                        idaccmotive_touse = TipoRit["idaccmotive_pay"];//debito VERSO erario
                    }

					if (idaccmotive_touse==DBNull.Value){
						MessageBox.Show("Il contributo "+TipoRit["description"].ToString()+
							" non Ë correttamente configurato per l'E/P");
						return; //Errore fatale!
					}

                    if (idaccmotive_cost == DBNull.Value) {
                        contributiNonConfigurati += amount;
                    }
                    else {
                        string idrelatedContrib = BudgetFunction.GetIdForDocument(Rit);
                        object idepexpContrib = Conn.DO_READ_VALUE("epexp", QHS.AppAnd(QHS.CmpEq("idrelated", idrelatedContrib), QHS.CmpEq("nphase", 2)), "idepexp");
                        if ((idepexpContrib == null || idepexpContrib == DBNull.Value) && flagEpExp == "S" && esercizio > 2015) {
                            MessageBox.Show("Errore", "Non Ë stato trovato alcun impegno di budget per il contributo" + Rit["taxcode"].ToString());
                            return;
                        }
                        DataRow[] ContiContribCosto = EP.GetAccMotiveDetails(idaccmotive_cost.ToString());
                        foreach (DataRow CP in ContiContribCosto) {
                            EP.EffettuaScritturaImpegnoBudget(idepcontext, amount,
                                                      CP["idacc"],
                                                      idreg, idupb,
                                                      CurrCedolino["start"], CurrCedolino["stop"],
                                                      CurrCedolino, idaccmotive_cost, idepexpContrib, null, idrelatedContrib);                            
                        }
                    }
                    //Fa la scrittura sul conto di debito conto/verso erario usando la tabella anagrafiche della cfg ritenute
                    DataRow[] ContiContribFinanz = EP.GetAccMotiveDetails(idaccmotive_touse.ToString());
                    if (debitoCONTOerario) {
                        foreach (DataRow CP in ContiContribFinanz) {
                            EP.EffettuaScrittura(idepcontext, amount,
                                CP["idacc"],
                                idregauto, idupb,  //era Curr["idreg"]
                                CurrCedolino["start"], CurrCedolino["stop"],
                                CurrCedolino, idaccmotive_touse);
                        }

                    }
                    else {
                        DataTable Regs = TEH.GetIdRegFor(Rit["taxcode"], DBNull.Value, DBNull.Value);
                        if (Regs==null || Regs.Rows.Count == 0) {
                            MessageBox.Show("Anagrafica per il versamento non trovata per la ritenuta di tipo " + Rit["taxref"].ToString(), "Errore"); 
                        }
                        else {
                            foreach (DataRow Registry in Regs.Rows) {
                                decimal amount_to_consider = amount * CfgFn.GetNoNullDecimal(Registry["quota"]);
                                int idreg_to_consider = CfgFn.GetNoNullInt32(Registry["idreg"]);
                                foreach (DataRow CP in ContiContribFinanz) {
                                    EP.EffettuaScrittura(idepcontext, amount_to_consider,
                                        CP["idacc"],
                                        idreg_to_consider, idupb,  //era Curr["idreg"]
                                        CurrCedolino["start"], CurrCedolino["stop"],
                                        CurrCedolino, idaccmotive_touse);
                                }
                            }

                        }
                    }				
				}

                //Effettua la scrittura sulla causale principale
                DataRow[] ContiPrinc = EP.GetAccMotiveDetails(idaccmot_main);
                foreach (DataRow CP in ContiPrinc) {                    
                    EP.EffettuaScritturaImpegnoBudget(idepcontext, totale + contributiNonConfigurati,
                                CP["idacc"],idreg, idupb,
                                CurrCedolino["start"], CurrCedolino["stop"],
                                CurrCedolino, idaccmot_main, idepexp, null, idrelated);
                }
                

                //Effettua la scrittura sul conto di debito vs fornitore
                EP.EffettuaScrittura(idepcontext, totale,
                    idacc_registry,
                    idreg, idupb, CurrCedolino["start"], CurrCedolino["stop"],
                    CurrCedolino, idaccmot_main);

                EP.RemoveEmptyDetails();
			
				MetaData MetaEntry = Meta.Dispatcher.Get("entry");
				PostData Post= MetaEntry.Get_PostData();

				Post.InitClass(EP.D,Meta.Conn);
				if (Post.DO_POST()){
					EditEntry(CurrCedolino);
                }
                else {
                    EP.viewDetails(Meta);
                }
			}
		}

		private void GeneraImpegniEScritture(string elencoCedolini) {
			if (elencoCedolini == "") return;
            DataSet Temp = new DataSet();
			DataTable tCedolino = DataAccess.CreateTableByName(Meta.Conn, "payroll", "*");
			DataTable tContratto = DataAccess.CreateTableByName(Meta.Conn, "parasubcontract", "*");
            Temp.Tables.Add(tCedolino);
            Temp.Tables.Add(tContratto);
			string filtroCedolini = QHS.FieldInList("idpayroll", elencoCedolini);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tCedolino, null, filtroCedolini, null, true);
			string elencoContratti = QHS.FieldInList("idcon", QueryCreator.ColumnValues(tCedolino,null,"idcon",true));
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, tContratto, null, elencoContratti, null, true);
			
			bool calcolaTutto = false;
            DataAccess Conn = Meta.Conn;
            int esercizio = Conn.GetEsercizio();

            MetaData metaParasubMain = Meta.Dispatcher.Get("parasubcontract");
            metaParasubMain.DS = Temp;
            EP_Manager mainManager= new EP_Manager(metaParasubMain, null, null, null, null, null, null, null, null, "payroll");
            foreach (DataRow CurrCedolino in tCedolino.Rows) {
                if (!calcolaTutto) {
                    int idCedolino = CfgFn.GetNoNullInt32(CurrCedolino["idpayroll"]);
                    AskOperation ao = new AskOperation(idCedolino);
                    DialogResult dr = ao.ShowDialog();
                    if (dr != DialogResult.OK) continue;
                    switch (ao.operazioneScelta) {
                        case AskOperation.operazione.Si: {
                                break;
                            }
                        case AskOperation.operazione.SiTutti: {
                                calcolaTutto = true;
                                break;
                            }
                        case AskOperation.operazione.No: {
                                continue;
                            }
                        case AskOperation.operazione.NoTutti: {
                                return;
                            }
                    }
                }

                Meta_EasyDispatcher d = null;
                Easy_DataAccess newConn = null;
                MetaData metaParasub = null;
                int annostop = esercizio;
                bool erroriep = false;
                if (CurrCedolino["stop"] != DBNull.Value && (((DateTime)CurrCedolino["stop"]).Year < esercizio)) {
                    annostop = ((DateTime)CurrCedolino["stop"]).Year;
                }
                DataRow CurrContratto = tContratto.Select(QHC.CmpEq("idcon", CurrCedolino["idcon"]))[0];

			    string descrizione =
                    "Contratto n." + CurrContratto["ncon"].ToString() + " del " +
                                CurrContratto["ycon"].ToString() + " - " +
                    "Cedolino n. " + CurrCedolino["npayroll"] + "/" + CurrCedolino["fiscalyear"];


                
                EP_Manager epManagerCedolino = mainManager;
                if (annostop < esercizio & (mainManager.UsaImpegniDiBudget || mainManager.UsaScritture)) {
                    //Genera impegni e scritture nell'anno di competenza del cedolino
                    newConn = ottieniConnessioneNuovoEsercizio(Conn, annostop);
                    if (newConn == null) {
                        MessageBox.Show("Ci sono problemi nell'accedere all'anno " + annostop + ", non saranno generati impegni di budget o scritture", "Errore");
                        erroriep = true;
                    }
                    else {
                        d = new Meta_EasyDispatcher(newConn);
                        metaParasub = d.Get("parasubcontract");
                        metaParasub.DS = Meta.DS;
                        metaParasub.linkedForm = this;
                        epManagerCedolino = new EP_Manager(metaParasub, null, null, null, null, null, null, null, null, "payroll");
                    }
                }
                
                if ((erroriep == false) && epManagerCedolino.abilitaScritture(CurrCedolino)) {
                    epManagerCedolino.setForcedCurrentRow(CurrCedolino);
                    epManagerCedolino.afterPost();
                }

                if (newConn != null) {
                    newConn.Destroy();
                    metaParasub.Destroy();
                    epManagerCedolino.Dispose();
                }
            }
		}
   

        object GetIDMAN(object idupb) {
            if (idupb == DBNull.Value)
                return DBNull.Value;
            return Meta.Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", idupb), "idman");
        }

        public bool DatiValidi(DataAccess Conn, int esercizio) {
            DataTable EsercizioTable =
                Conn.RUN_SELECT("accountingyear", "*", null, QHS.CmpEq("ayear", esercizio), null, true);

            if (EsercizioTable.Rows.Count == 0) {
                MessageBox.Show("L'esercizio " + esercizio + " non Ë stato creato.");
                return false;
            }
            return true;
        }

        bool CambioDataConsentita(DataAccess DA, DateTime newDate) {
            object idcustomuser = DA.GetSys("idcustomuser");
            object ayear = newDate.Year;
            if (idcustomuser == DBNull.Value) return true;
            QueryHelper QHS = DA.GetQueryHelper();
            string filterall = QHS.CmpEq("idcustomuser", idcustomuser);
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterall, false) == 0) return true; //fuori dall'organigramma
            string filteranno = QHS.Like("idflowchart", ayear.ToString().Substring(2) + "%");
            string filterdate = QHS.AppAnd(filterall,
                filteranno,
                QHS.NullOrLe("start", newDate), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filterdate, false) == 0) return false;
            object oggi = DA.DO_SYS_CMD("select getdate()");
            string filternow = QHS.AppAnd(filterall, filteranno,
                        QHS.NullOrLe("start", oggi), QHS.NullOrGe("stop", newDate));
            if (DA.RUN_SELECT_COUNT("flowchartuser", filternow, false) == 0) return false;
            return true;
        }

        Easy_DataAccess ottieniConnessioneNuovoEsercizio(DataAccess Conn, int newEsercizio) {
            if (!DatiValidi(Conn, newEsercizio)) return null;

            DateTime newDate = new DateTime(newEsercizio, 12, 31);
            if (!CambioDataConsentita(Conn, newDate)) {
                MessageBox.Show("L'utente non ha diritto ad agire nell'esercizio " + newEsercizio, "Errore");
                return null;
            }
            Easy_DataAccess newConn = (Easy_DataAccess)Conn.Duplicate();
            newConn.SetSys("esercizio", newEsercizio);
            newConn.SetSys("datacontabile", newDate);


            newConn.RecalcUserEnvironment(Conn.GetSys("idflowchart"), Conn.GetSys("ndetail"));
            newConn.ReadAllGroupOperations();

            return newConn;
        }

        void EditEntry(DataRow rCedolino){
			if (rCedolino == null) return;
			EP_functions EP= new EP_functions(Meta.Dispatcher);
			EP.EditRelatedEntry(Meta,rCedolino);										  
		}

		private int ottieniIdCedolinoConguaglio(DataRow rCedolino, DataTable tCedolino) {
			string filtroConguaglio = QueryCreator.WHERE_COLNAME_CLAUSE(rCedolino,
				new string [] {"npayroll","fiscalyear","idcon"},DataRowVersion.Current,false);
			filtroConguaglio = GetData.MergeFilters(filtroConguaglio,QHC.CmpEq("flagbalance", 'S'));
			DataRow [] rCedolinoConguaglio = tCedolino.Select(filtroConguaglio);
			if (rCedolinoConguaglio.Length == 0) return -1;
			return (int)rCedolinoConguaglio[0]["idpayroll"];
		}

		private void btnInterrompi_Click(object sender, System.EventArgs e)
		{
			switch (btnInterrompi.Text) 
			{
				case "Interrompi": 
				{
					interrompi = true;	
					Console.WriteLine("INTERROTTO");
					break;
				}
				case "Chiudi": 
				{
					Console.WriteLine("CHIUSO");
					DialogResult = DialogResult.OK;
					break;
				}
				case "OK":
				{
					Console.WriteLine("OK");
					DialogResult = DialogResult.OK;
					break;
				}
			}
		}
	}
}
