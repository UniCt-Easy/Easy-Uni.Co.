
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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using System.Text;
using System.Globalization;
using q= metadatalibrary.MetaExpression;

namespace no_table_import_anagrafiche_csa {
    /// <summary>
    /// Summary description for no_table_import_anagrafiche_csa.
    /// </summary>
    public class FrmNoTable_import_anagrafiche_csa : MetaDataForm {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        private System.Windows.Forms.Button btnAnnulla;
        public vistaForm DS;
        DataSet D = new vistaAnagrafica();
        DataAccess Conn;
        private GroupBox grpConferma;
        private Label label3;
        private Button btnImporta;
        DataTable TanagraficheError = new DataTable("TanagraficheError");
        DataTable Tavviso = new DataTable("Tavviso");
        object id_indirizzo_default;
        object id_indirizzo_domfisc;
        string intestazione = "";
        MetaData MetaRegistry;
        MetaData MetaRegistryAddress;
        MetaData MetaRegistryPay;
        MetaData MetaRegistryLegalStatus;
        MetaData MetaRegistryTaxableStatus;
        MetaData MetaRegistryDocenti;
        MetaData MetaRegistryAamministrativi;

        DataTable Residence;
        Hashtable Hres;

        DataTable Currency;
        Hashtable Hcur;

        DataTable Position;
        Hashtable HPosition;
        private ProgressBar progressBar1;
        private Label label16;
        private TextBox txt_matricola_a;
        private TextBox txt_matricola_da;
        private Label label5;
        private Label label6;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmNoTable_import_anagrafiche_csa() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(FrmNoTable_import_anagrafiche_csa));
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.DS = new no_table_import_anagrafiche_csa.vistaForm();
            this.grpConferma = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnImporta = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_matricola_a = new System.Windows.Forms.TextBox();
            this.txt_matricola_da = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.grpConferma.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(450, 322);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 6;
            this.btnAnnulla.Text = "Chiudi";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // grpConferma
            // 
            this.grpConferma.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConferma.Controls.Add(this.label3);
            this.grpConferma.Location = new System.Drawing.Point(12, 8);
            this.grpConferma.Name = "grpConferma";
            this.grpConferma.Size = new System.Drawing.Size(518, 219);
            this.grpConferma.TabIndex = 10;
            this.grpConferma.TabStop = false;
            this.grpConferma.Text = "Operazioni sull\'anagrafica";
            // 
            // label3
            // 
            this.label3.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                       | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(6, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(506, 186);
            this.label3.TabIndex = 73;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // btnImporta
            // 
            this.btnImporta.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImporta.Location = new System.Drawing.Point(377, 241);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(150, 37);
            this.btnImporta.TabIndex = 76;
            this.btnImporta.TabStop = false;
            this.btnImporta.Text = "Importa le anagrafiche";
            this.btnImporta.Click += new System.EventHandler(this.btnImporta_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    (((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                      | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(12, 284);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(518, 23);
            this.progressBar1.TabIndex = 77;
            // 
            // label16
            // 
            this.label16.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label16.Location = new System.Drawing.Point(10, 252);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(58, 20);
            this.label16.TabIndex = 82;
            this.label16.Text = "Matricola:";
            // 
            // txt_matricola_a
            // 
            this.txt_matricola_a.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_matricola_a.Location = new System.Drawing.Point(240, 251);
            this.txt_matricola_a.Name = "txt_matricola_a";
            this.txt_matricola_a.Size = new System.Drawing.Size(102, 20);
            this.txt_matricola_a.TabIndex = 80;
            // 
            // txt_matricola_da
            // 
            this.txt_matricola_da.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txt_matricola_da.Location = new System.Drawing.Point(109, 250);
            this.txt_matricola_da.Name = "txt_matricola_da";
            this.txt_matricola_da.Size = new System.Drawing.Size(97, 20);
            this.txt_matricola_da.TabIndex = 78;
            // 
            // label5
            // 
            this.label5.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.Location = new System.Drawing.Point(198, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 16);
            this.label5.TabIndex = 81;
            this.label5.Text = "a:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Anchor =
                ((System.Windows.Forms.AnchorStyles)
                    ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.Location = new System.Drawing.Point(66, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 16);
            this.label6.TabIndex = 79;
            this.label6.Text = "Da:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmNoTable_import_anagrafiche_csa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(538, 350);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_matricola_a);
            this.Controls.Add(this.txt_matricola_da);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnImporta);
            this.Controls.Add(this.grpConferma);
            this.Controls.Add(this.btnAnnulla);
            this.MinimumSize = new System.Drawing.Size(522, 360);
            this.Name = "FrmNoTable_import_anagrafiche_csa";
            this.Text = "Importa Anagrafiche da CSA";
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.grpConferma.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.SearchEnabled = false;

            Tavviso.Columns.Add("cf");
            Tavviso.Columns.Add("nominativo");
            //Tavviso.Columns.Add("dettaglio");

            TanagraficheError.Columns.Add("cf");
            TanagraficheError.Columns.Add("nominativo");

            id_indirizzo_default = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");
            id_indirizzo_domfisc = Conn.DO_READ_VALUE("address", QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");

            MetaRegistry = Meta.Dispatcher.Get("registry");
            MetaRegistry.SetDefaults(D.Tables["registry"]);

            MetaRegistryAddress = Meta.Dispatcher.Get("registryaddress");
            MetaRegistryAddress.SetDefaults(D.Tables["registryaddress"]);

            MetaRegistryPay = Meta.Dispatcher.Get("registrypaymethod");
            MetaRegistryPay.SetDefaults(D.Tables["registrypaymethod"]);

            MetaRegistryLegalStatus = Meta.Dispatcher.Get("registrylegalstatus");
            MetaRegistryLegalStatus.SetDefaults(D.Tables["registrylegalstatus"]);

            MetaRegistryDocenti = Meta.Dispatcher.Get("registry_docenti");
            MetaRegistryDocenti.SetDefaults(D.Tables["registry_docenti"]);

            MetaRegistryAamministrativi = Meta.Dispatcher.Get("registry_amministrativi");
            MetaRegistryAamministrativi.SetDefaults(D.Tables["registry_amministrativi"]);

            MetaRegistryTaxableStatus = Meta.Dispatcher.Get("registrytaxablestatus");
            MetaRegistryTaxableStatus.SetDefaults(D.Tables["registrytaxablestatus"]);

            Residence = Conn.RUN_SELECT("residence", "*", null, null, null, false);
            Hres = new Hashtable();
            foreach (DataRow RR in Residence.Select()) Hres[RR["coderesidence"]] = RR["idresidence"];

            Currency = Conn.RUN_SELECT("currency", "*", null, null, null, false);
            Hcur = new Hashtable();
            foreach (DataRow RCC in Currency.Select())
                Hcur[RCC["codecurrency"]] = RCC["idcurrency"].ToString().ToUpper();

            Position = Conn.RUN_SELECT("position", "*", null, null, null, false);
            HPosition = new Hashtable();
            foreach (DataRow RPOS in Position.Select()) HPosition[RPOS["codeposition"]] = RPOS["idposition"];
        }

        private void btnImporta_Click(object sender, EventArgs e) {
            object LinkedServerName = Conn.DO_READ_VALUE("linkedserveraccess", null, "linkedservername");
            object DBServerName = Conn.DO_READ_VALUE("linkedserveraccess", null, "dbservername");
            if ((LinkedServerName == null) && (DBServerName == null)) {
                show(this,
                    "Non è stato trovato né il nome del LinkedServer né il nome del DB da cui leggere le Anagrafiche.",
                    "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            progressBar1.Value = 0;
            if (!ImportaAnagrafiche(LinkedServerName, DBServerName))
                show("Operazione non eseguita.");
            else
                show("Operazione eseguita.", "");
        }

        private bool isNumeric(string str, out int valore) {
            valore = 0;
            try {
                valore = Convert.ToInt32(str);
                return true;
            }
            catch  {
                return false;
            }
        }

        private bool ImportaAnagrafiche(object linkedServerName, object DBServerName) {
            string errMess;
            btnImporta.Enabled = false;

            string matricola_da = txt_matricola_da.Text.Trim();
            string matricola_a = txt_matricola_a.Text.Trim();

            int imatricola_da = 0;
            int imatricola_a = 0;

            if ((matricola_da != "") && (isNumeric(matricola_da, out imatricola_da))) {
                imatricola_da = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), matricola_da, "x.y"));

            }
            if ((matricola_a != "") && (isNumeric(matricola_a, out imatricola_a))) {
                imatricola_a = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), matricola_a, "x.y"));
            }


            // Importo SOLO i dati Anagrafici
            DataSet DSOut = Meta.Conn.CallSP("import_anagrafiche_csa",
                new object[] {linkedServerName, DBServerName, imatricola_da, imatricola_a}, 1000, out errMess);
            if (errMess != null) {
                show(this, "Errore nella chiamata della procedura che importa le Anagrafiche " +
                                      "\r\rContattare il servizio assistenza"
                                      + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                return false;
            }

            if ((DSOut == null) || (DSOut.Tables.Count == 0)) {
                show(this, "Non ci sono anagrafiche da importare.", "Informazione", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            DataTable Out = DSOut.Tables[0];
            if (Out.Rows.Count == 0) {
                show(this, "Non ci sono anagrafiche da importare.", "Informazione", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            // Importo SOLO i dati relativi a inquadramento - Mod pagamento
            DataSet DSOutPos = Meta.Conn.CallSP("import_inquadranagrafiche_csa",
                new object[] {linkedServerName, DBServerName, imatricola_da, imatricola_a}, 10000, out errMess);
            if (errMess != null) {
                show(this,
                    "Errore nella chiamata della procedura che importa gli inquadramenti delle Anagrafiche " +
                    "\r\rContattare il servizio assistenza"
                    + "\r\rDettaglio dell'errore :\r\r" + errMess, "Errore");
                return false;
            }

            DataTable OutPos = null;

            if ((DSOutPos == null) || (DSOutPos.Tables.Count == 0)) {
                show(this, "Non ci sono inquadramenti delle anagrafiche da importare.", "Informazione",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return false;
            }
            else {
                OutPos = DSOutPos.Tables[0];
            }
            //if (OutPos.Rows.Count == 0){
            //    show(this, "Non ci sono inquadramenti delle anagrafiche da importare.", "Informazione", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            string filterAnagrafica = "";
            string filterAnagraficaDS = "";
            
            int counterr = 0, countavviso = 0, countrow_forsave = 0;
            bool updated = false;
            bool avviso = false;
            decimal redditoannuo = 0;
            object datavalidita = DBNull.Value;
            D.Tables["registrypaymethod"].Clear();
            D.Tables["registryaddress"].Clear();
            D.Tables["registry"].Clear();
            D.Tables["registrytaxablestatus"].Clear();
            D.Tables["registrylegalstatus"].Clear();
            D.Tables["registry_docenti"].Clear();
            D.Tables["registry_amministrativi"].Clear();
            TanagraficheError.Clear();
            Tavviso.Clear();
            Dictionary<string, DataRow> regs = new Dictionary<string, DataRow>();
            progressBar1.Maximum = Out.Rows.Count;
            foreach (DataRow rCSA in Out.Select()) {
                string filterMatricola =  QHC.CmpEq("matricola", rCSA["matricola"]);
                progressBar1.Value++;
                avviso = false;
                filterAnagrafica = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("cf", rCSA["cf"]));
                bool inMemory = regs.ContainsKey(rCSA["cf"].ToString().ToUpper());
                int countReg = Conn.RUN_SELECT_COUNT("registry", filterAnagrafica, true);
				if (countReg == 1 | inMemory) {  // Solo se la riga è unica
					QueryCreator.MarkEvent("Considero matricola " + rCSA["matricola"]);

					updated = false;
					DataRow rRegistry;
					if (inMemory) {
						rRegistry = regs[rCSA["cf"].ToString().ToUpper()];
					}
					else {
						DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registry"], null, filterAnagrafica, null, true);
						filterAnagraficaDS = QHC.AppAnd(QHC.CmpEq("active", "S"), QHC.CmpEq("cf", rCSA["cf"]));
						rRegistry = D.Tables["registry"].Select(filterAnagraficaDS)[0];
						regs[rCSA["cf"].ToString().ToUpper()] = rRegistry;
					}
					updated = AggiornaAnagrafica(rCSA, rRegistry) | updated;
					updated = AggiornaIndirizzoRes(rCSA, rRegistry) | updated;

					updated = AggiornaIndirizzoDom(rCSA, rRegistry) | updated;
					redditoannuo = 0;
					// Solo se ci sono inquadramenti da importare, esegue questo segmento di codice
					if (OutPos != null) {
						QueryCreator.MarkEvent("Esamino pos. giuridiche matricola " + rCSA["matricola"]);
						foreach (DataRow rCSADati in OutPos.Select(QHC.AppAnd(filterMatricola, QHC.CmpEq("rowkind", "I")))) {
							updated = (AggiornaPosGiuridica(rCSADati, rRegistry)) | updated;

							if (CfgFn.GetNoNullDecimal(rCSADati["imponpresunto"]) > redditoannuo) {
								redditoannuo = CfgFn.GetNoNullDecimal(rCSADati["imponpresunto"]);
								datavalidita = rCSADati["in_vigore_giur"];
							}
							if (rCSADati["avviso"].ToString() == "S") {
								avviso = true;
							}
							updated = (AggiornaRedditoPresunto(rCSADati, rRegistry, redditoannuo, datavalidita)) ||
									  updated;
						}

						QueryCreator.MarkEvent("Esamino Mod. Pagamento " + rCSA["matricola"]);
						foreach (DataRow rDati in OutPos.Select(QHC.AppAnd(filterMatricola, QHC.CmpEq("rowkind", "P")))) {
							QueryCreator.MarkEvent("Mod. Pagamento rowkind è " + rCSA["matricola"]);
							updated = AggiornaModPagamento(rDati, rRegistry) | updated;
						}

					}

					if (!updated) {
						rRegistry.Delete();
						rRegistry.AcceptChanges();
					}
					else {
						countrow_forsave++;
					}
				}
				if (countReg > 1) {
                    //ci sono + righe attive con quel CF. Scarta l'anagrafica.
                    counterr++;

                    DataRow Rerr = TanagraficheError.NewRow();
                    Rerr["cf"] = rCSA["cf"];
                    Rerr["nominativo"] = rCSA["denominazione"];
                    TanagraficheError.Rows.Add(Rerr);
                }
                if (countReg == 0) {
                    //se il count è 0: deve inserire la nuova riga in registry
                    if ((OutPos != null) && (OutPos.Rows.Count > 0)) {
                        DataRow[] CSADati = OutPos.Select(filterMatricola);
                        DataRow r =CreaAnagrafica(rCSA, CSADati);
                        regs[rCSA["cf"].ToString().ToUpper()] = r;
                    }
                    else {
                        DataRow r = CreaAnagrafica(rCSA, null);
                        regs[rCSA["cf"].ToString().ToUpper()] = r;
                    }
                    countrow_forsave++;
                }

                if (avviso) {
                    //l'anagrafica in oggetto ha 2 mod. di pagamento 
                    countavviso++;

                    DataRow Ravv = Tavviso.NewRow();
                    Ravv["cf"] = rCSA["cf"];
                    Ravv["nominativo"] = rCSA["denominazione"];
                    Tavviso.Rows.Add(Ravv);
                }
                if (countrow_forsave == 100) {
                    
                    // Elabora un blocco di 100 righe
                    if (!SaveTrance(D, Tavviso, TanagraficheError, countavviso, counterr)) {
                        regs.Clear();
                        return false;
                    }
                    regs.Clear();
                    countavviso = 0;
                    counterr = 0;
                    countrow_forsave = 0;
                }

            } // Fine ciclo sulle Anagrafiche.
            show(this, "Salva quelle residue", "Informazione", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            // Salva le righe residue
            if (!SaveTrance(D, Tavviso, TanagraficheError, countavviso, counterr)) {
                return false;
            }
            // Qui deve sistemare il campo Active e lo fa tramite la sp che agisce sulle matricole oggetto di questa elaborazione
            string disattivariga = "S";
             Meta.Conn.CallSP("compute_inquadranagrafiche_csa",
                 new object[] { matricola_da, matricola_a, disattivariga }, 10000, out errMess);

            return true;
        }


        private bool SaveTrance(DataSet D, DataTable Tavviso, DataTable TanagraficheError, int countavviso, int counterr) {
            if (countavviso > 0) {
                show(this, "Avviso vale S. Siamo in SaveTrance", "Informazione", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Tavviso.Columns["cf"].Caption = "CF";
                Tavviso.Columns["nominativo"].Caption = "Nominativo";
                DataSet DSAvviso = new DataSet();
                DSAvviso.Tables.Add(Tavviso);
                intestazione = "Le seguenti anagrafiche avendo più modalità di pagamento, per selezionare la più aggiornata"
                               + " è stato usato un criterio di ordinamento sui vari campi disponibili.";
                FrmDettaglioRisultati X = new FrmDettaglioRisultati(DSAvviso.Tables["Tavviso"], intestazione);
                X.Text = "Anagrafiche";
                createForm(X, this);
                X.ShowDialog(this);
                DSAvviso.Tables.Remove(Tavviso);
            }
            if (counterr > 0) {
                TanagraficheError.Columns["cf"].Caption = "CF";
                TanagraficheError.Columns["nominativo"].Caption = "Nominativo";
                DataSet DSError = new DataSet();
                DSError.Tables.Add(TanagraficheError);
                intestazione = " Per le seguenti anagrafiche non sarà eseguita alcuna operazione perchè non si è potuto identificare univocamente la persona,"
                               + " inquanto esisto due anagrafiche con lo stesso CF.";
                FrmDettaglioRisultati X = new FrmDettaglioRisultati(DSError.Tables["TanagraficheError"], intestazione);
                X.Text = "Anagrafiche scartate";
                createForm(X, this);
                X.ShowDialog(this);
                DSError.Tables.Remove(TanagraficheError);

                // Se vi sono stati errori, prima di salvare, chiede se importare o meno le anagrafiche. Se "no" azzera tutto, altrimenti Salva..
                DialogResult RES = show("Si desidera procedere all'importazione?", "Informazione",
                    MessageBoxButtons.OKCancel);
                if (RES == DialogResult.OK) {
                    // Procede col salvataggio
                    if (!SaveData(D, false)) return false;
                }
                else {
                    //Azzera tutto.
                    D.Tables["registrypaymethod"].Clear();
                    D.Tables["registryaddress"].Clear();
                    D.Tables["registry"].Clear();
                    D.Tables["registrytaxablestatus"].Clear();
                    D.Tables["registrylegalstatus"].Clear();
                    D.Tables["registry_docenti"].Clear();
                    D.Tables["registry_amministrativi"].Clear();
                    TanagraficheError.Clear();
                    return false;
                }
            }
            else {
                // Non ci sono anagrafiche scartate, procede direttamente col salvataggio.
                if (!SaveData(D, false)) return false;
            }

            D.Tables["registrypaymethod"].Clear();
            D.Tables["registryaddress"].Clear();
            D.Tables["registry"].Clear();
            D.Tables["registrytaxablestatus"].Clear();
            D.Tables["registrylegalstatus"].Clear();
            D.Tables["registry_docenti"].Clear();
            D.Tables["registry_amministrativi"].Clear();
            TanagraficheError.Clear();
            Tavviso.Clear();
            return true;
        }

        bool CopiaCampo(DataRow Rd, string fd, object O) {
            if (Rd[fd].ToString() != O.ToString()) {
                Rd[fd] = O;
                return true;
            }
            return false;
        }


        bool AggiornaAnagrafica(DataRow rCSA, DataRow reg) {
            bool updated = false;

            updated = CopiaCampo(reg, "residence", Hres[rCSA["tiporesidenza"]]) | updated;
            updated = CopiaCampo(reg, "title", rCSA["denominazione"]) | updated;
            updated = CopiaCampo(reg, "surname", rCSA["cognome"]) | updated;
            updated = CopiaCampo(reg, "forename", rCSA["nome"]) | updated;
            updated = CopiaCampo(reg, "foreigncf", rCSA["cf_ext"]) | updated;
            if (rCSA["p_iva"] != DBNull.Value) updated = CopiaCampo(reg, "p_iva", rCSA["p_iva"]) | updated;
            updated = CopiaCampo(reg, "extmatricula", rCSA["matricola"]) | updated;
            updated = CopiaCampo(reg, "authorization_free", rCSA["esenteeq"]) | updated;

            return updated;
        }


        private DataRow CreaAnagrafica(DataRow rCSA, DataRow[] CSADati) {

            DataRow Reg = MetaRegistry.Get_New_Row(null, D.Tables["registry"]);
            //RowChange.ClearAutoIncrement(D.Tables["registry"].Columns["idreg"]);

            //Reg["idreg"] = rCSA("codice");
            int N = CfgFn.GetNoNullInt32(Reg["idreg"]);
            if (N < 1000000) {
                N = 1000000;
                Reg["idreg"] = N;
            }

            Reg["idregistryclass"] = rCSA["tipologia"];
            Reg["residence"] = Hres[rCSA["tiporesidenza"]];
            Reg["title"] = rCSA["denominazione"];
            Reg["surname"] = rCSA["cognome"];
            Reg["forename"] = rCSA["nome"];
            Reg["gender"] = rCSA["sesso"];
            Reg["p_iva"] = rCSA["p_iva"];
            Reg["cf"] = rCSA["cf"];
            Reg["foreigncf"] = rCSA["cf_ext"];
            Reg["birthdate"] = rCSA["datanasc"];
            Reg["location"] = rCSA["localitanasc"];
            Reg["extmatricula"] = rCSA["matricola"];
            //Reg["annotation"] = rCSA["note"];
            Reg["flagbankitaliaproceeds"] = "N";
            Reg["ct"] = DateTime.Now;
            Reg["lt"] = DateTime.Now;
            Reg["cu"] = "importazioneCSA";
            Reg["lu"] = "importazioneCSA";

            object idcity = DBNull.Value;
            object idnation = DBNull.Value;
            object cat = rCSA["catastalenasc"];
            bool flagforeign = false;
            GetCatastale(rCSA["cf"].ToString(), cat, out idcity, out idnation, out flagforeign);
            Reg["idcity"] = idcity;
            Reg["idnation"] = idnation;
            Reg["authorization_free"] = rCSA["esenteeq"];
            Reg["multi_cf"] = rCSA["cfduplicato"];
            Reg["active"] = rCSA["attiva"];

            //indirizzo predefinito/residenza
            object data_ind1 = rCSA["dataind_res"];
            if (data_ind1 != DBNull.Value) {
                DataRow RI1 = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
                RI1["idreg"] = Reg["idreg"];
                RI1["start"] = data_ind1;
                RI1["idaddresskind"] = id_indirizzo_default;
                RI1["address"] = rCSA["indirizzo_res"];
                RI1["cap"] = rCSA["cap_res"];
                RI1["officename"] = rCSA["ufficio_res"];
                RI1["cu"] = "importcsa";
                object idcity_res = DBNull.Value;
                object idnation_res = DBNull.Value;
                object cat_res = rCSA["catastale_res"];
                bool flagforeign_res = false;
                GetCatastale(rCSA["cf"].ToString(), cat_res, out idcity_res, out idnation_res, out flagforeign_res);
                RI1["idcity"] = idcity_res;
                RI1["idnation"] = idnation_res;
                if (flagforeign_res) {
                    RI1["flagforeign"] = "S";
                }
                else {
                    RI1["flagforeign"] = "N";
                }
                RI1["location"] = rCSA["localita_res"];
                RI1["active"] = "S";
                RI1["ct"] = DateTime.Now;
                RI1["lt"] = DateTime.Now;
                RI1["cu"] = "importazioneCSA";
                RI1["lu"] = "importazioneCSA";
            }

            //domicilio fiscale ove diverso dal predefinito
            object data_ind2 = rCSA["dataind_dom"];
            if (data_ind2 != DBNull.Value) {
                DataRow RI2 = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
                RI2["idreg"] = Reg["idreg"];
                RI2["start"] = data_ind2;
                RI2["idaddresskind"] = id_indirizzo_domfisc;
                RI2["address"] = rCSA["indirizzo_dom"];
                RI2["cap"] = rCSA["cap_dom"];
                RI2["officename"] = rCSA["ufficio_dom"];
                RI2["cu"] = "importcsa";
                object idcity_dom = DBNull.Value;
                object idnation_dom = DBNull.Value;
                object cat_dom = rCSA["catastale_dom"];
                bool flagforeign_dom = false;
                GetCatastale(rCSA["cf"].ToString(), cat_dom, out idcity_dom, out idnation_dom, out flagforeign_dom);
                RI2["idcity"] = idcity_dom;
                RI2["idnation"] = idnation_dom;
                if (flagforeign_dom) {
                    RI2["flagforeign"] = "S";
                }
                else {
                    RI2["flagforeign"] = "N";
                }
                RI2["location"] = rCSA["localita_dom"];
                RI2["active"] = "S";
                RI2["annotations"] = "creazione nuovo dom";
                RI2["ct"] = DateTime.Now;
                RI2["lt"] = DateTime.Now;
                RI2["cu"] = "importazioneCSA";
                RI2["lu"] = "importazioneCSA";
            }

            // Ora esegue l'inserimento dei dati provenienti dalla seconda sp, ossia relativi all'inquadramento.
            if (CSADati == null || CSADati.Length == 0) return Reg;
            DataRow rCSA_Pagamento = null;
            foreach (DataRow R in CSADati) {
                if (R["rowkind"].ToString() != "P") // deve esaminare e quindi Creare solo le righe del Pagamento
                    continue;
                else {
                    rCSA_Pagamento = R;
                    break;
                }
            }
            if (rCSA_Pagamento != null) {
                object idpaymethod = rCSA_Pagamento["idpaymethod"];
                object idchargehandling = rCSA_Pagamento["idchargehandling"];
                object flag = rCSA_Pagamento["flag"];
                if (idpaymethod != DBNull.Value) {
                    DataRow RP = MetaRegistryPay.Get_New_Row(Reg, D.Tables["registrypaymethod"]);
                    RP["idreg"] = Reg["idreg"];
                    RP["idpaymethod"] = idpaymethod;
                    RP["idchargehandling"] = idchargehandling;
                    // bit 0, flag esenzione spese bancarie
                    if ((CfgFn.GetNoNullInt32(flag) & 1) != 0)
                    RP["flag"] = 1;
                    RP["regmodcode"] = rCSA_Pagamento["nomemod"];
                    RP["idbank"] = rCSA_Pagamento["abi"];
                    RP["idcab"] = rCSA_Pagamento["cab"];
                    RP["cin"] = rCSA_Pagamento["cin"];
                    RP["cc"] = rCSA_Pagamento["cc"];
                    RP["active"] = "S";
                    RP["flagstandard"] = "S";
                    RP["iddeputy"] = rCSA_Pagamento["delegato"];
                    object codecurrency = rCSA_Pagamento["valuta"];
                    if (codecurrency == DBNull.Value)
                        codecurrency = "EUR";
                    RP["idcurrency"] = Hcur[codecurrency.ToString().ToUpper()];
                    RP["idexpirationkind"] = rCSA_Pagamento["tiposcadenza"];
                    RP["paymentexpiring"] = rCSA_Pagamento["ggscadenza"];
                    RP["iban"] = rCSA_Pagamento["iban"];
                    RP["ct"] = DateTime.Now;
                    RP["lt"] = DateTime.Now;
                    RP["cu"] = "importazioneCSA";
                    RP["lu"] = "importazioneCSA";
                }

            }
            // inserimento inquadramento
            //object codeposition = rCSA["codicequalifica"];
            //object idposition = HPosition[codeposition.ToString().ToUpper()];

            //object idposition = rCSA["codicequalifica"];
            //if ((idposition != DBNull.Value) && (idposition != null)){
            //    DataRow RLS = MetaRegistryLegalStatus.Get_New_Row(Reg, D.Tables["registrylegalstatus"]);
            //    RLS["idreg"] = Reg["idreg"];
            //    RLS["active"] = "S";
            //    RLS["idposition"] = idposition;
            //    RLS["start"] = rCSA["in_vigore_giur"];
            //    RLS["incomeclassvalidity"] = rCSA["datadecorrenza"];
            //    RLS["incomeclass"] = rCSA["classestipendiale"];
            //}

            // inserimento reddito annuo presunto
            //object supposedincome = rCSA["imponpresunto"];
            //if (supposedincome != DBNull.Value) {
            //    DataRow RTS = MetaRegistryTaxableStatus.Get_New_Row(Reg, D.Tables["registrytaxablestatus"]);
            //    RTS["idreg"] = Reg["idreg"];
            //    RTS["active"] = "S";
            //    RTS["start"] = rCSA["in_vigore_giur"];
            //    RTS["supposedincome"] = supposedincome;
            //}

            // inserimento Inquadramento e  Reddito Annuo Presunto
            decimal redditoannuo = 0;
            object datavalidita = DBNull.Value;

            foreach (DataRow R in CSADati) {
                if (R["rowkind"].ToString() != "I") // deve esaminare e quindi Creare solo le righe dell'inquadramento
                    continue;
                // RIVEDERE se idposition è null lo mette a null, se è valorizzato lo mette valorizzato
                object idposition = R["codicequalifica"];
                object idinquadramento = R["codiceinquadramento"];
                
                object livello = R["livello"];
                //if ((idposition != DBNull.Value) && (idposition != null)){
                DataRow RLS = MetaRegistryLegalStatus.Get_New_Row(Reg, D.Tables["registrylegalstatus"]);
                RLS["idreg"] = Reg["idreg"];
                RLS["active"] = "S";
                RLS["flagdefault"] = "N";
                RLS["idposition"] = idposition;
                RLS["idinquadramento"] = idinquadramento;
                RLS["livello"] = livello;
                RLS["start"] = R["in_vigore_giur"];
                if (R.Table.Columns.Contains("iddaliaposition")) {
                    RLS["iddaliaposition"] = R["iddaliaposition"];
                }
                RLS["incomeclassvalidity"] = R["datadecorrenza"];
                RLS["incomeclass"] = R["classestipendiale"];
                RLS["csa_compartment"] = R["comparto"];
                RLS["csa_class"] = R["inquadramento"];
                RLS["csa_role"] = R["ruolo"];
                RLS["ct"] = DateTime.Now;
                RLS["lt"] = DateTime.Now;
                RLS["cu"] = "importazioneCSA";
                RLS["lu"] = "importazioneCSA";
                if (CfgFn.GetNoNullDecimal(R["imponpresunto"]) > redditoannuo) {
                    redditoannuo = CfgFn.GetNoNullDecimal(R["imponpresunto"]);
                    datavalidita = R["in_vigore_giur"];
                }

            }
          
            if (redditoannuo != 0) {
                DataRow RTS = MetaRegistryTaxableStatus.Get_New_Row(Reg, D.Tables["registrytaxablestatus"]);
                RTS["idreg"] = Reg["idreg"];
                RTS["active"] = "S";
                RTS["start"] = datavalidita;
                RTS["supposedincome"] = redditoannuo;
                RTS["ct"] = DateTime.Now;
                RTS["lt"] = DateTime.Now;
                RTS["cu"] = "importazioneCSA";
                RTS["lu"] = "importazioneCSA";
            }
            return Reg;
        }

        int NoNullInt(object o) {
            if (o == DBNull.Value) return 0;
            return Convert.ToInt32(o);
        }

        bool SaveData(DataSet D, bool displayMsg) {
            int hSaveData = metaprofiler.StartTimer("Importazione - SaveData ");
            PostData P = new PostData_Migrazione();
            P.InitClass(D, Conn);
            bool res = P.DO_POST();
            if (displayMsg) {
                if (res) show("Dati salvati correttamente");
                else show("Dati non salvati.");
            }
            metaprofiler.StopTimer(hSaveData);
            Application.DoEvents();
            return res;
        }

        //private object SetCatastale(object cap_csa)
        //{
        //    object CodiceCatastale = null;
        //    string query = " SELECT value FROM geo_city_agency  " +
        //       " JOIN geo_cap " +
        //       " ON geo_cap.idcity = geo_city_agency.idcity " +
        //       " WHERE geo_city_agency.idagency = 1 AND geo_city_agency.idcode = 1 and "+
        //       "cap = " + cap_csa;

        //    DataTable T = Conn.SQLRunner(query);
        //    if ((T != null) && (T.Rows.Count > 0)) {
        //        CodiceCatastale = T.Rows[0]["value"];
        //    }
        //    return CodiceCatastale;
        //}
        void GetCatastale(string codiceanag, object codice, out object idcity, out object idnation,
            out bool flagforeign) {
            idcity = DBNull.Value;
            idnation = DBNull.Value;
            if ((codice != DBNull.Value) && (codice != null)) {
                idcity = Conn.DO_READ_VALUE("geo_city_agencyview",
                    QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
                        QHS.CmpEq("value", codice)
                        ), "idcity", null);
                if (idcity == null) {
                    idcity = DBNull.Value;
                    idnation = Conn.DO_READ_VALUE("geo_nation_agencyview",
                        QHS.AppAnd(QHS.CmpEq("codename", "fiscale"),
                            QHS.CmpEq("value", codice),
                            QHS.IsNull("stop")
                            ), "idnation", null);
                    if (idnation == null) {
                        idnation = DBNull.Value;
                        show("Codice catastale :" + codice.ToString() +
                                        " non trovato per l'anagrafica avente CF = " + codiceanag, "Errore");
                    }
                }
            }
            flagforeign = (idnation != DBNull.Value ? true : false);
        }

        private bool AggiornaIndirizzoRes(DataRow rCSA, DataRow Reg) {
            if (rCSA["dataind_res"] == DBNull.Value) return false;

            object idReg = Reg["idreg"];
            string filter = QHS.AppAnd(
                QHS.CmpEq("idreg", idReg),
                //QHS.CmpEq("start", rCSA["dataind_res"]), //la data la impostiamo noi nella sp quindi non ha senso valorizzarla.
                QHS.CmpEq("idaddresskind", id_indirizzo_default),
                QHS.CmpEq("address", rCSA["indirizzo_res"])
                );

            object idcity_res = DBNull.Value;
            object idnation_res = DBNull.Value;
            object cat_res = rCSA["catastale_res"];
            bool flagforeign = false;
            GetCatastale(rCSA["cf"].ToString(), cat_res, out idcity_res, out idnation_res, out flagforeign);
            // se il cap vale 99999 va escluso dal filtro sia il CAP che la nazione perchè straniero

            if (flagforeign) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("flagforeign", "S"), QHS.CmpEq("idnation", idnation_res));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("cap", rCSA["cap_res"]), QHS.CmpEq("idcity", idcity_res),
                    QHS.CmpEq("flagforeign", "N"));
            }

            int N = Conn.RUN_SELECT_COUNT("registryaddress", filter, true);
            if (N > 0)
                return false; // C'è già un indirizzo con questi dati.
            else {
                // fa il COUNT solo con i campi chiave
                string filterkey = QHS.AppAnd(QHS.CmpEq("idreg", idReg),
                    QHS.CmpEq("idaddresskind", id_indirizzo_default),
                    QHS.CmpEq("start", rCSA["dataind_res"]));
                int nKey = Conn.RUN_SELECT_COUNT("registryaddress", filterkey, true);
                DataRow R;
                if (nKey > 0) {
                    // Aggiorna solo i campi NON chiave
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registryaddress"], null, filterkey, null, true);
                    string filterkeyDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("start", rCSA["dataind_res"]),
                        QHC.CmpEq("idaddresskind", id_indirizzo_default));

                    DataRow[] rFound = D.Tables["registryaddress"].Select(filterkeyDS);
                    R = rFound[0];
                }
                else {
                    // Prima di creare questo nuovo indirizzo, controlla che gli indirizzi esistenti
                    // siano indirizzi precedenti a quello di CSA, cioè il nuovo per essere creato deve essere successivo a quello esistente.
                    string filterPrevious = QHS.AppAnd(QHS.CmpEq("idreg", idReg),
                        QHS.CmpEq("idaddresskind", id_indirizzo_default),
                        QHS.CmpLe("start", rCSA["dataind_res"]));
                    string filterOnlyAddress = QHS.AppAnd(QHS.CmpEq("idreg", idReg),
                        QHS.CmpEq("idaddresskind", id_indirizzo_default));

                    int nPrevious = Conn.RUN_SELECT_COUNT("registryaddress", filterPrevious, true);
                    int nOnlyAddress = Conn.RUN_SELECT_COUNT("registryaddress", filterOnlyAddress, true);
                    if (nOnlyAddress > 0 && nPrevious == 0) {
                        return false;
                            // Se vi sono indirizzi ma NON sono precedenti a quello di CSA, sono successivi ad esso, allora NON la fa insert.
                        // altrimenti fa la INSERT perchè o non ci sono indirizzi oppure ci sono ma antecedenti a quello di CSA 
                    }
                    else {
                        // Inserisce un nuovo indirizzo, perchè nel DB non esiste uno con quei campi chiave.
                        R = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
                        R["idreg"] = Reg["idreg"];
                        R["start"] = rCSA["dataind_res"];
                        R["idaddresskind"] = id_indirizzo_default;

                        // Imposta la data di stop dell'eventuale indirizzo esistente. Prende quello con lo stesso "idreg", "idaddresskind" e diverso "start", con "stop" null.
                        DataRow Rexisted;
                        DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registryaddress"], null,
                            QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("idaddresskind", id_indirizzo_default),
                                QHS.CmpNe("start", rCSA["dataind_res"]), QHS.IsNull("stop")), null, true);

                        string filterkeyDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg),
                            QHC.CmpEq("idaddresskind", id_indirizzo_default),
                            QHC.CmpNe("start", rCSA["dataind_res"]), QHC.IsNull("stop"));

                        DataRow[] rFoundExist = D.Tables["registryaddress"].Select(filterkeyDS);
                        if (rFoundExist.Length > 0) {
                            Rexisted = rFoundExist[0];
                            DateTime stop = (DateTime) rCSA["dataind_res"];
                            Rexisted["stop"] = stop.AddDays(-1);
                            Rexisted["lt"] = DateTime.Now;
                            Rexisted["lu"] = "UPimportazioneCSA";
                        }
                    }
                }
                //Valorizza i campi NON chiave 
                R["address"] = rCSA["indirizzo_res"];
                R["cap"] = rCSA["cap_res"];
                R["officename"] = rCSA["ufficio_res"];
                R["idcity"] = idcity_res;
                R["idnation"] = idnation_res;
                R["flagforeign"] = (flagforeign ? "S" : "N");
                R["location"] = rCSA["localita_res"];
                R["active"] = "S";
                R["lt"] = DateTime.Now;
                R["lu"] = "UPimportazioneCSA";
                return true;
            }
        }

        private bool AggiornaIndirizzoDom(DataRow rCSA, DataRow Reg) {
            // L'estrazione del domicilio fiscale è stata rimossa dalla sp.
            if (rCSA["indirizzo_dom"] == DBNull.Value) return false;

            object idReg = Reg["idreg"];
            string filter = QHS.AppAnd(
                QHS.CmpEq("idreg", idReg),
                QHS.CmpEq("idaddresskind", id_indirizzo_domfisc), QHS.CmpEq("address", rCSA["indirizzo_dom"]));

            object idcity_dom = DBNull.Value;
            object idnation_dom = DBNull.Value;
            object cat_dom = rCSA["catastale_dom"];
            bool flagforeign = false;
            GetCatastale(rCSA["cf"].ToString(), cat_dom, out idcity_dom, out idnation_dom, out flagforeign);

            string filterRES_DS = "";
            string filterRES_db = "";
            if (flagforeign) {
                // Indirizzo estero
                filter = QHS.AppAnd(filter, QHS.CmpEq("flagforeign", "S"), QHS.CmpEq("idnation", idnation_dom));

                filterRES_DS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("idaddresskind", id_indirizzo_default),
                    QHC.CmpEq("address", rCSA["indirizzo_dom"]), QHC.CmpEq("flagforeign", "S"),
                    QHC.CmpEq("idnation", idnation_dom));

                filterRES_db = QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("idaddresskind", id_indirizzo_default),
                    QHS.CmpEq("address", rCSA["indirizzo_dom"]), QHS.CmpEq("flagforeign", "S"),
                    QHS.CmpEq("idnation", idnation_dom));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("cap", rCSA["cap_dom"]), QHS.CmpEq("idcity", idcity_dom),
                    QHS.CmpEq("flagforeign", "N"));

                filterRES_DS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("idaddresskind", id_indirizzo_default),
                    QHC.CmpEq("address", rCSA["indirizzo_dom"]), QHC.CmpEq("cap", rCSA["cap_dom"]),
                    QHC.CmpEq("idcity", idcity_dom), QHC.CmpEq("flagforeign", "N"));

                filterRES_db = QHS.AppAnd(QHC.CmpEq("idreg", idReg), QHS.CmpEq("idaddresskind", id_indirizzo_default),
                    QHS.CmpEq("address", rCSA["indirizzo_dom"]), QHS.CmpEq("cap", rCSA["cap_dom"]),
                    QHS.CmpEq("idcity", idcity_dom), QHS.CmpEq("flagforeign", "N"));
            }

            int N = Conn.RUN_SELECT_COUNT("registryaddress", filter, true);

            // Dopo aver "aggiornato" l'indirizzo predefinito, controllo la presenza di un domicilio fiscale (senza considerare la data)
            if (N > 0)
                return false; // C'è già un indirizzo con questi dati.
            else {
                //Controlla se in memoria esiste un indirizzo predefinito con le info del dom.ficale(senza considerare la data)
                // Se esiste e il DataRowState è Added valorizzo la data con dataind_dom della sp,rimane predefinito e restituisce true perchè abbiamo aggiornato l'anagrafica
                DataRow[] rRegistryAddressRES = D.Tables["registryaddress"].Select(filterRES_DS);
                if ((rRegistryAddressRES.Length == 1) && (rRegistryAddressRES[0].RowState == DataRowState.Added)) {
                    rRegistryAddressRES[0]["start"] = rCSA["dataind_dom"];
                    return true;
                }
                // Controlla che, nel db, esista un indirizzo predefinito con queste info (senza considerare la data), se lo trovo non fa nulla!!!
                int RES_db = Conn.RUN_SELECT_COUNT("registryaddress", filterRES_db, true);
                if (RES_db > 0) return false;

                // fa il COUNT solo con i campi chiave
                string filterkey = QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("start", rCSA["dataind_dom"]),
                    QHS.CmpEq("idaddresskind", id_indirizzo_domfisc));

                DataRow R;
                int nKey = Conn.RUN_SELECT_COUNT("registryaddress", filterkey, true);
                if (nKey > 0) {
                    // Aggiorna solo i campi NON chiave
                    DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registryaddress"], null, filterkey, null, true);
                    string filterkeyDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("start", rCSA["dataind_dom"]),
                        QHC.CmpEq("idaddresskind", id_indirizzo_domfisc));

                    DataRow[] rFound = D.Tables["registryaddress"].Select(filterkeyDS);
                    R = rFound[0];
                }
                else {
                    // Inserisce un nuovo indirizzo, perchè nel DB non ne esiste uno con quei campi chiave.
                    R = MetaRegistryAddress.Get_New_Row(Reg, D.Tables["registryaddress"]);
                    R["idreg"] = Reg["idreg"];
                    R["start"] = rCSA["dataind_dom"];
                    R["idaddresskind"] = id_indirizzo_domfisc;
                }
                R["address"] = rCSA["indirizzo_dom"];
                R["cap"] = rCSA["cap_dom"]; // sarebbe opportuno metterlo solo se diverso da 99999
                R["officename"] = rCSA["ufficio_dom"];
                R["idcity"] = idcity_dom;
                R["idnation"] = idnation_dom;
                R["flagforeign"] = (flagforeign ? "S" : "N");
                R["location"] = rCSA["localita_dom"];
                R["active"] = "S";
                R["annotations"] = "aggiornamento dom";
                R["lt"] = DateTime.Now;
                R["lu"] = "UPimportazioneCSA";
                return true;
            }
        }

        private bool AggiornaModPagamento(DataRow rCSA, DataRow Reg) {
            object idpaymethod = rCSA["idpaymethod"];

            object idchargehandling = rCSA["idchargehandling"];
            object flag = rCSA["flag"];

            if (idpaymethod == DBNull.Value) {
                QueryCreator.MarkEvent("idpaymethod nullo ");
                return false;
            }

            object idReg = Reg["idreg"];
            ////Legge le coordinate bancarie dalla mod. di pag. predefinita
            //DataRow DefPagam = CfgFn.ModalitaPagamentoDefault(Meta.Conn, idReg);
            //if (DefPagam == null) return false;

            object codecurrency = rCSA["valuta"];
            if (codecurrency == DBNull.Value) codecurrency = "EUR";
            object idcurrency = Hcur[codecurrency.ToString().ToUpper()];

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("idpaymethod", idpaymethod),
                QHS.CmpEq("cin", rCSA["cin"]), QHS.CmpEq("idbank", rCSA["abi"]), QHS.CmpEq("idcab", rCSA["cab"]),
                QHS.CmpEq("cc", rCSA["cc"]), QHS.CmpEq("idcurrency", idcurrency),
                QHS.CmpEq("idchargehandling", idchargehandling));

            if (rCSA["iban"] == DBNull.Value) {
                filter = QHS.AppAnd(filter, QHS.IsNull("iban"));
            }
            else {
                filter = QHS.AppAnd(filter, QHS.CmpEq("iban", rCSA["iban"]));
            }

            int N = Conn.RUN_SELECT_COUNT("registrypaymethod", filter, true);
            if (N > 0) {
                //la modalità esiste già identica
                QueryCreator.MarkEvent("Mod. pagamento già presente "+filter);
                return false;
            }

            // fa il COUNT solo con i campi chiave, essendo idregistrypaymethod un semplice incrementale usa idpaymethod, per il quale
            //c'è anche un indice nella tabella.
            string filterkey = QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("idpaymethod", idpaymethod));
            QueryCreator.MarkEvent("Cerco mod. pag "+filter);
            int nKey = Conn.RUN_SELECT_COUNT("registrypaymethod", filterkey, true);
            DataRow R;
            if (nKey > 0) {
                QueryCreator.MarkEvent("Aggiorno mod. pag "+filter);
                // Aggiorna solo i campi NON chiave
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registrypaymethod"], null, filterkey, null, true);
                string filterkeyDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("idpaymethod", idpaymethod));
                DataRow[] rFound = D.Tables["registrypaymethod"].Select(filterkeyDS);
                R = rFound[0];
            }
            else {
                QueryCreator.MarkEvent("Creo mod. pag "+filter);
                // Inserisce una nuova mod. di pagamento, perchè nel DB non ne esiste uno con quei campi chiave.
                R = MetaRegistryPay.Get_New_Row(Reg, D.Tables["registrypaymethod"]);
                R["idreg"] = Reg["idreg"];
                R["idpaymethod"] = idpaymethod;
            }

            R["regmodcode"] = rCSA["nomemod"];
            R["idchargehandling"] = idchargehandling;
            // bit 0, flag esenzione spese bancarie
            if ((CfgFn.GetNoNullInt32(flag) & 1) != 0) R["flag"] = 1;
            R["idbank"] = rCSA["abi"];
            R["idcab"] = rCSA["cab"];
            R["cin"] = rCSA["cin"];
            R["cc"] = rCSA["cc"];
            R["iban"] = rCSA["iban"];
            R["active"] = "S";
            //R["flagstandard"] = "S";
            R["iddeputy"] = rCSA["delegato"];
            R["idcurrency"] = idcurrency;
            R["idexpirationkind"] = rCSA["tiposcadenza"];
            R["paymentexpiring"] = rCSA["ggscadenza"];
            R["lt"] = DateTime.Now;
            R["lu"] = "UPimportazioneCSA";
            return true;

        }

        private bool AggiornaPosGiuridica(DataRow rCSADati, DataRow Reg) {
            object idposition = rCSADati["codicequalifica"]; // Sono i codici in Easy
            object idinquadramento = rCSADati["codiceinquadramento"];// Sono i codici in Easy
            // Stiamo contemplando anche il caso di idposition NULL
            //if (idposition == DBNull.Value) return false;
            object inquadramento = rCSADati["inquadramento"];// è il valore che arriva dalla view di CSA
            string filterinq = "";
            string filterinqC = "";
            if ((inquadramento != DBNull.Value) && (inquadramento != null)) {
                filterinq = QHS.CmpEq("csa_class", rCSADati["inquadramento"]);
                filterinqC = QHC.CmpEq("csa_class", rCSADati["inquadramento"]);
            }
            object idReg = Reg["idreg"];
            
            string filterkey = QHS.AppAnd(QHS.CmpEq("idreg", idReg), filterinq,
                QHS.CmpEq("csa_compartment", rCSADati["comparto"]), QHS.CmpEq("csa_role", rCSADati["ruolo"]),
                QHS.CmpEq("start", rCSADati["in_vigore_giur"]), QHS.CmpEq("incomeclass", rCSADati["classestipendiale"]));
           
            string filterkeyC = QHC.AppAnd(QHC.CmpEq("idreg", idReg), filterinqC,
                 QHC.CmpEq("csa_compartment", rCSADati["comparto"]), QHC.CmpEq("csa_role", rCSADati["ruolo"]),
                 QHC.CmpEq("start", rCSADati["in_vigore_giur"]), QHC.CmpEq("incomeclass", rCSADati["classestipendiale"]));
            int rKey = Conn.RUN_SELECT_COUNT("registrylegalstatus", filterkey, true);
            DataRow R=null;
            if (rKey > 0) {
                // Aggiornerà solo i campi NON chiave, in realtà sta controllando i campi principali.
                DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registrylegalstatus"], null, filterkey, null, true);
                DataRow[] rFound = D.Tables["registrylegalstatus"].Select(filterkeyC);
                R = rFound[0];
            }
            else {
	            bool foundprec = false;
	            if (rCSADati["in_vigore_giur"] != DBNull.Value) {
		            DateTime oldStart = (DateTime) rCSADati["in_vigore_giur"];
		            oldStart = oldStart.AddDays(-1);
		            //Cerca l'inquadramento che finisce nel giorno precedente
		            string filterkeyOld = QHS.AppAnd(QHS.CmpEq("idreg", idReg),
    		            QHS.CmpEq("csa_compartment", rCSADati["comparto"]), QHS.CmpEq("csa_role", rCSADati["ruolo"]), filterinq,
                        QHS.CmpEq("stop",oldStart), 
			            QHS.CmpEq("incomeclass", rCSADati["classestipendiale"]));
		            DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registrylegalstatus"],"start desc", filterkeyOld, "1", true);
		            DataRow[] rFound = D.Tables["registrylegalstatus"].Select(
			            QHC.AppAnd(QHC.CmpEq("idreg", idReg),
				            QHC.CmpEq("csa_compartment", rCSADati["comparto"]), filterinqC,
                            QHC.CmpEq("csa_role", rCSADati["ruolo"]),
				            QHC.CmpEq("stop",oldStart), 
				            QHC.CmpEq("incomeclass", rCSADati["classestipendiale"])));
		            if (rFound.Length > 0) {
			            R = rFound[0];
			            foundprec = true;
		            }
	            }
	            if (!foundprec) {
		            // Inserisce un nuovo inquadramento, perchè nel DB non ne esiste uno con quei campi.
		            R = MetaRegistryLegalStatus.Get_New_Row(Reg, D.Tables["registrylegalstatus"]);
		            R["idreg"] = idReg;
		            R["start"] = rCSADati["in_vigore_giur"];
                    R["flagdefault"] = "N";
                    R["livello"] = rCSADati["livello"];
                }
            }

          
            R["stop"] = rCSADati["termine"];
            R["active"] = "S";
            R["idposition"] = idposition;
            R["incomeclassvalidity"] = rCSADati["datadecorrenza"];
            R["incomeclass"] = rCSADati["classestipendiale"];
            R["csa_compartment"] = rCSADati["comparto"];
            R["csa_role"] = rCSADati["ruolo"];
            R["csa_class"] = rCSADati["inquadramento"];
            R["lt"] = DateTime.Now;
            R["lu"] = "UPimportazioneCSA";
            return true;
        }

        private bool AggiornaRedditoPresunto(DataRow rCSA, DataRow Reg, decimal supposedincome, object start) {
            // inserimento reddito annuo presunto
            if (supposedincome == 0) return false;
            DataRow R = null;
            object idReg = Reg["idreg"];
            // Controlla che nel DB ci sia una riga con quei dati identica, se c'è esce.
            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("start", start));//,QHS.CmpEq("active","S"), QHS.CmpEq("supposedincome", supposedincome));
            int N = Conn.RUN_SELECT_COUNT("registrytaxablestatus", filter, true);
            if (N > 0) return false;

            DateTime dPrec = (DateTime) start;
            dPrec = dPrec.AddDays(-1);

            bool toCreate = false;
            // controlla se la riga del DB ha importo  >. Se lo è esce.
            string filterkey = QHS.CmpEq("idreg", idReg);
            DataTable ReddPres = Meta.Conn.RUN_SELECT("registrytaxablestatus", "idreg, start,supposedincome ","start DESC",
					QHS.AppAnd(QHS.CmpEq("active","S"),filterkey), "1", false);

            if (ReddPres.Select(QHC.CmpEq("start", start)).Length == 1) {
                //Esiste un reddito con uguale start
	            decimal redditoPrecedente = CfgFn.GetNoNullDecimal(ReddPres.Rows[0]["supposedincome"]);
	            if (redditoPrecedente == supposedincome) return false; //Non c'è bisogno di aggiornarlo

                DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registrytaxablestatus"], "start DESC",
								QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("start", start)), "1", false);
                string filterkeyDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("start", start));
                DataRow[] rFound = D.Tables["registrytaxablestatus"].Select(filterkeyDS);
                if (rFound.Length > 0) {
	                var RR = rFound[0];
	                RR["active"] = "N";
                }
            }
            else {
	            var precRedd = ReddPres.Select(QHC.CmpLe("start", start), "start desc");
	            if (precRedd.Length > 1) {
		            object startFound = precRedd[0]["start"];
		            //Esiste un reddito precedente attivo
		            decimal redditoPrecedente = CfgFn.GetNoNullDecimal(precRedd[0]["supposedincome"]);
		            if (redditoPrecedente == supposedincome) return false; //Non c'è bisogno di aggiornarlo

                    //Crea il nuovo e rende il precedente non attivo
		            DataAccess.RUN_SELECT_INTO_TABLE(Conn, D.Tables["registrytaxablestatus"], "start DESC",
			            QHS.AppAnd(QHS.CmpEq("idreg", idReg), QHS.CmpEq("start",startFound )), "1", false);
		            string filterkeyDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("start", startFound));
		            DataRow[] rFound = D.Tables["registrytaxablestatus"].Select(filterkeyDS);
		            if (rFound.Length > 0) {
			            var RR = rFound[0];
			            RR["active"] = "N";
		            }
	            }
            }

            if (R == null) {
                // Inserisce una nuova riga, perchè nel DB non ne esiste uno con quei campi chiave.
                // Controlla che non esista già in memoria:
                string filterDS = QHC.AppAnd(QHC.CmpEq("idreg", idReg), QHC.CmpEq("start", start));
                DataRow[] rDSFound = D.Tables["registrytaxablestatus"].Select(filterDS);
                if (rDSFound.Length > 0) return false;//non effettua l'aggiornamento

                R = MetaRegistryTaxableStatus.Get_New_Row(Reg, D.Tables["registrytaxablestatus"]);
                R["idreg"] = Reg["idreg"];
            }

            R["start"] = start;
            R["supposedincome"] = supposedincome;
            R["active"] = "S";
            R["lt"] = DateTime.Now;
            R["lu"] = "UPimportazioneCSA";
            return true;

        }

        private void btnAnnulla_Click(object sender, EventArgs e) {
            Dispose();
        }

    }

    class PostData_Migrazione : PostData {
        override public string GetOptimisticClause(DataRow R) {
            if (R.Table.PrimaryKey != null) {
                if ((R.Table.Columns["lu"] != null) &&
                    (R.Table.Columns["lt"] != null) &&
                    R.Table.PrimaryKey.Length > 0) {
                    int keylen = R.Table.PrimaryKey.Length;
                    DataColumn[] Cs = new DataColumn[keylen + 2];
                    for (int i = 0; i < keylen; i++) Cs[i] = R.Table.PrimaryKey[i];
                    Cs[keylen] = R.Table.Columns["lu"];
                    Cs[keylen + 1] = R.Table.Columns["lt"];
                    return QueryCreator.WHERE_REL_CLAUSE(R, Cs, Cs, DataRowVersion.Original, true);
                }
            }
            return base.GetOptimisticClause(R);
        }
    }
}

