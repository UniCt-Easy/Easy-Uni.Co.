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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;//funzioni_configurazione
using ep_functions;
using manage_var;
using q = metadatalibrary.MetaExpression;

namespace estimate_default {
    /// <summary>
    /// </summary>
    public class Frm_estimate_default : System.Windows.Forms.Form {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercContratto;
        private System.Windows.Forms.TextBox txtNumContratto;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox TxtTermConsegna;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIndirizzoConsegna;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRiferminento;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtScadenza;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbTipoScadenza;
        private System.Windows.Forms.Button btnInserisci;
        private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtImponibile;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.TextBox txtTotale;
        private System.Windows.Forms.Button btnSituazione;
        MetaData Meta;
        private System.Windows.Forms.DataGrid detailgrid;
        DataRow Current;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cmbTipoContratto;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtDataContabile;
        DataAccess Conn;
        public estimate_default.vistaForm DS;
        private System.Windows.Forms.TabPage Principale;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Classificazioni;
        private System.Windows.Forms.DataGrid dgrClassificazioni;
        private System.Windows.Forms.Button btnIndElimina;
        private System.Windows.Forms.Button btnIndModifica;
        private System.Windows.Forms.Button btnIndInserisci;
        private System.Windows.Forms.Button btnDividiDettaglio;
        private TabPage tabEP;
        private Button btnGeneraEP;
        private Button btnVisualizzaEP;
        private Label labEP;
        private Button btnUnisciDettagli;
        private Label label5;
        private Label labAltroEsercizio;
        private Button btnSostituisciDettaglio;
        private GroupBox groupBox11;
        private TextBox textBox4;
        private TextBox txtCodiceCausaleCrg;
        private Button button7;
        private GroupBox gBoxCausaleCredito;
        private TextBox textBox1;
        private TextBox txtCodiceCausaleDeb;
        private Button button6;
        private Label label43;
        private TextBox textBox3;
        private GroupBox gboxtipofattura;
        private RadioButton rdbextracom;
        private RadioButton rdbintracom;
        private RadioButton rdbitalia;
        private TabPage tabAttributi;
        private GroupBox gboxFinanziamento;
        private TextBox txtFinanziamento;
        private Button btnFinanziamento;
        private TabPage tabDettagli;
        private GroupBox gboxCliente;
        public TextBox txtCliente;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private GroupBox gboxValuta;
        public TextBox txtValuta;
        private Button button2;
        private TextBox txtCambio;
        private Label label6;
        public GroupBox gboxclass05;
        public TextBox txtCodice05;
        public Button btnCodice05;
        private TextBox txtDenom05;
        public GroupBox gboxclass04;
        public TextBox txtCodice04;
        public Button btnCodice04;
        private TextBox txtDenom04;
        public GroupBox gboxclass03;
        public TextBox txtCodice03;
        public Button btnCodice03;
        private TextBox txtDenom03;
        public GroupBox gboxclass02;
        public TextBox txtCodice02;
        public Button btnCodice02;
        private TextBox txtDenom02;
        public GroupBox gboxclass01;
        public TextBox txtCodice01;
        public Button btnCodice01;
        private TextBox txtDenom01;
        private Button btnInserisciCopia;
        private Label label22;
        private TextBox textBox7;
        private Button btnRipartizione;
        private Button btnVisualizzaPreimpegni;
        private Button btnGeneraPreimpegni;
        private Button btnGeneraEpExp;
        private Button btnVisualizzaEpExp;
        private Label lblcig;
        private TextBox txtcig;
        private TabPage tabAllegati;
        private DataGrid dataGrid1;
        private Button btnDelAtt;
        private Button btnEditAtt;
        private Button btnInsAtt;


        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frm_estimate_default() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.estimate.Columns["active"], true);
            DataAccess.SetTableForReading(DS.upb_detail, "upb");


            DS.estimatesorting.ExtendedProperties["ViewTable"] = DS.estimatesortingview;
            DS.sortingview.ExtendedProperties["ViewTable"] = DS.estimatesortingview;
            DS.estimatesortingview.ExtendedProperties["RealTable"] = DS.estimatesorting;

            foreach (DataColumn C in DS.estimatesorting.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.estimatesortingview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "estimatesorting." + C.ColumnName;
            }

            DS.estimatesortingview.Columns["sortingkind"].ExtendedProperties["ViewSource"] = "sortingview.sortingkind";
            DS.estimatesortingview.Columns["sortcode"].ExtendedProperties["ViewSource"] = "sortingview.sortcode";
            DS.estimatesortingview.Columns["sorting"].ExtendedProperties["ViewSource"] = "sortingview.description";

            DS.estimatedetail.ExtendedProperties["ViewTable"] = DS.estimatedetailview;
            DS.registry.ExtendedProperties["ViewTable"] = DS.estimatedetailview;
            DS.ivakind.ExtendedProperties["ViewTable"] = DS.estimatedetailview;
            DS.upb_detail.ExtendedProperties["ViewTable"] = DS.estimatedetailview;
            DS.estimatedetailview.ExtendedProperties["RealTable"] = DS.estimatedetail;

            foreach (DataColumn C in DS.estimatedetail.Columns) {
                if (C.ColumnName.StartsWith("!")) continue;
                DS.estimatedetailview.Columns[C.ColumnName].ExtendedProperties["ViewSource"] = "estimatedetail." + C.ColumnName;
            }

            DS.estimatedetailview.Columns["codeupb"].ExtendedProperties["ViewSource"] = "upb_detail.codeupb";
            DS.estimatedetailview.Columns["ivakind"].ExtendedProperties["ViewSource"] = "ivakind.description";
            DS.estimatedetailview.Columns["registry"].ExtendedProperties["ViewSource"] = "registry.title";


        }


        void impostaSicurezza(DataRow TipoContratto) {
            if (!Meta.InsertMode) return;
            if (TipoContratto == null) return;
            Meta.GetFormData(true);
            DataRow curr = DS.estimate.Rows[0];
            bool someChange = false;
            for (int i = 1; i <= 5; i++) {
                string field = "idsor0" + i;
                int idsor0x = CfgFn.GetNoNullInt32(Meta.GetSys(field));
                if (idsor0x == 0) idsor0x = CfgFn.GetNoNullInt32(TipoContratto[field]);
                int currIdsor = CfgFn.GetNoNullInt32(curr[field]);
                if (currIdsor == idsor0x) continue;
                if (currIdsor != 0) {
                    someChange = true;
                }
                curr[field] = idsor0x;
            }
            if (someChange) {
                //MessageBox.Show("Gli attributi di sicurezza sono stati adeguati al nuovo tipo di contratto selezionato", "Avviso");
                Meta.FreshForm(true);
            }
        }


        public void MetaData_AfterGetFormData() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.estimate.Rows[0];
            if (Meta.InsertMode) {
                foreach (DataRow Child in DS.estimatedetail.Select()) {
                    Child["yestim"] = Curr["yestim"];
                    Child["nestim"] = Curr["nestim"];
                    Child["idestimkind"] = Curr["idestimkind"];
                }
            }


            DataRow[] contrattoParent = DS.estimatekind.Select(QHC.CmpEq("idestimkind", Curr["idestimkind"]));
            if (contrattoParent.Length > 0) {
                DataRow TipoContratto = contrattoParent[0];
                if (TipoContratto["multireg"].ToString().ToUpper() == "N") {
                    foreach (DataRow Child in DS.estimatedetail.Select()) {
                        Child["idreg"] = Curr["idreg"];
                    }
                }
                else {
                    Curr["idreg"] = DBNull.Value;
                }
            }

            ImpostaTxtValuta();

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
        CQueryHelper QHC;
        QueryHelper QHS;
        private EP_Manager EPM;


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            GetData.CacheTable(DS.config, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, false);
            HelpForm.SetFormatForColumn(DS.estimatedetail.Columns["number"], "N");
            HelpForm.SetDenyNull(DS.estimate.Columns["flagintracom"], true);
            string filterEpOperationCred = QHS.CmpEq("idepoperation", "fatven_cred");
            //filterEpOperation calcolato, ora lo integriamo  integrando il filtro per dep/amm
            filterEpOperationCred = AddAccMotiveFilter.AddAmmDepFilter(filterEpOperationCred, Meta.Conn);
            GetData.SetStaticFilter(DS.accmotiveapplied_credit, filterEpOperationCred);
            GetData.SetStaticFilter(DS.accmotiveapplied_crg, filterEpOperationCred);
            DataAccess.SetTableForReading(DS.accmotiveapplied_crg, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_credit, "accmotiveapplied");
            DS.accmotiveapplied_credit.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;
            DS.accmotiveapplied_crg.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCred;

            GetData.SetStaticFilter(DS.expirationkind, QHS.CmpNe("kind", "A"));

            string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.sortingview, filtereserc);

            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                    btnGeneraEP, btnVisualizzaEP, labEP, labAltroEsercizio, "estimate");


            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null,
              null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)) {
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this, 1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value) {
                    tabControl1.TabPages.Remove(tabAttributi);
                }
            }

        }


        bool changedCol(DataRow r, string col) {
            if (r.RowState == DataRowState.Added || r.RowState == DataRowState.Deleted) return true;
            return r[col, DataRowVersion.Current].ToString() != r[col, DataRowVersion.Original].ToString();
        }

        bool someChangedCol(DataRow r, params string[] col) {
            foreach (string c in col) {
                if (changedCol(r, c)) return true;
            }
            return false;
        }
        bool unchangedCol(DataRow r, params string[] col) {
            return !someChangedCol(r, col);
        }

        public void MetaData_AfterActivation() {

            Conn = Meta.Conn;
        }




        bool ImportoVariato(DataRow R) {
            return someChangedCol(R, "taxable", "tax", "number", "discount");
        }


        public void MetaData_BeforePost() {



            if (DS.estimate.Rows.Count == 0) return;



            if (Meta.InsertMode) {
                string curridestimkind = DS.estimate.Rows[0]["idestimkind"].ToString();
                DataRow row_estimatekind = null;
                if (curridestimkind != "") {
                    row_estimatekind = DS.estimatekind.Select(QHC.CmpEq("idestimkind", curridestimkind))[0];
                }
                string flagmultireg_selected = (row_estimatekind == null ? "" : row_estimatekind["multireg"].ToString());
                //if (flagmultireg_selected == "N") {
                //    foreach (DataRow rDett in DS.estimatedetail.Rows) {
                //        rDett["idreg"] = DBNull.Value;
                //    }
                //}

            }
            EPM.beforePost();

            if (DS.estimate.Rows[0].RowState == DataRowState.Deleted) {
                return;
                //idrelated = EP_functions.GetIdForDocument(DS.estimate.Rows[0]);
                //fromDelete = true;
            }
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            // Variazioni sulle contabilizzazioni dei dettagli annullati nell'anno corrente
            DS.incomevar.Clear();
            DS.incomesorted.Clear();

			foreach (DataRow rDettaglio in DS.estimatedetail.Rows) {
				if ((rDettaglio.RowState != DataRowState.Modified)
					&& (rDettaglio.RowState != DataRowState.Added)) continue;


				if ((rDettaglio["idinc_taxable"] == DBNull.Value) &&
					(rDettaglio["idinc_iva"] == DBNull.Value))
					continue;

				if (rDettaglio.RowState == DataRowState.Modified) {
					int yearOriginalStart = rDettaglio["start", DataRowVersion.Original] == DBNull.Value
						? 0
						: ((DateTime)rDettaglio["start", DataRowVersion.Original]).Year;
					int yearCurrentStart = rDettaglio["start"] == DBNull.Value
						? 0
						: ((DateTime)rDettaglio["start"]).Year;
					int yearOriginalStop = rDettaglio["stop", DataRowVersion.Original] == DBNull.Value
						? 0
						: ((DateTime)rDettaglio["stop", DataRowVersion.Original]).Year;
					int yearCurrentStop = rDettaglio["stop"] == DBNull.Value ? 0 : ((DateTime)rDettaglio["stop"]).Year;
					bool todo = true;
					if (todo && yearOriginalStop == 0 && yearCurrentStop > 0 && yearCurrentStop == esercizio) {
						//stiamo annullando un dettaglio contabilizzato. La sostituzione di norma non segue questo metodo
						// ossia Ë una azione manuale dell'utente
						generaVariazione("-", rDettaglio);
						todo = false;
					}
					if (todo && yearOriginalStop > 0 && yearCurrentStop == 0 && yearOriginalStop == esercizio) {
						//stiamo togliendo la data stop, con una azione che annulla quella precedente. La sostituzione di norma
						// non segue questo metodo
						generaVariazione("+", rDettaglio);
						todo = false;
					}

					if (todo &&
					   ((yearOriginalStart == 0 && yearCurrentStart > 0) ||
						(yearOriginalStart > 0 && yearCurrentStart > 0 && ImportoVariato(rDettaglio)
						)
					   )

					   && yearCurrentStart == esercizio) {
						//Questo Ë un dettaglio che gi‡ era contabilizzato, e che stiamo modificando. Nelle righe aggiunte
						// vi sar‡ una riga con i valori uguali a quelli originali di questo dettaglio, e data stop valorizzata
						generaVariazione("+", rDettaglio);
						todo = false;
						//>>l'operazione "manuale" di mettere una data inizio ad un dettaglio contabilizzato va impedita di norma, fisicamente
					}
				} else {
					//Se il dettaglio Ë in stato di inserimento, crea una variazione su esso
					int yearCurrentStop = rDettaglio["stop"] == DBNull.Value ? 0 : ((DateTime)rDettaglio["stop"]).Year;

					if (yearCurrentStop != 0 && yearCurrentStop == esercizio) {
						generaVariazione("-", rDettaglio);
						continue;
					}
				}

				if (rDettaglio.RowState == DataRowState.Added) {
					int yearCurrentStart = rDettaglio["start"] == DBNull.Value ? 0 : ((DateTime) rDettaglio["start"]).Year;
					int yearCurrentStop = rDettaglio["stop"] == DBNull.Value ? 0 : ((DateTime) rDettaglio["stop"]).Year;

					if (yearCurrentStop == 0 && yearCurrentStart > 0 && yearCurrentStart == esercizio) {
						{
							//Questo Ë un dettaglio creato con il rimpiazzo, Ë nuovo e acquisisce l'idexp del dettaglio annullato
							generaVariazione("+", rDettaglio);
						}
					}
				}
			}
            foreach (DataRow NewVar in DS.incomevar.Select()) {
                if (CfgFn.GetNoNullDecimal(NewVar["amount"]) == 0) NewVar.Delete();
            }

            if (DS.incomevar.Select().Length > 0) {
                if (MessageBox.Show("E' stata modificata la data di annullamento di alcuni dettagli contabilizzati. " +
                                    "Si desidera creare delle variazioni sui " +
                                    "corrispondenti movimenti di entrata?",
                    "Conferma", MessageBoxButtons.OKCancel) == DialogResult.Cancel) {
                    DS.incomevar.Clear();
                    return;
                }
            }

            string filter = QHS.AppAnd(QHS.FieldIn("idinc", DS.incomevar.Select()),
                        QHS.CmpEq("ayear", Meta.GetSys("esercizio")));

            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.incomesorted,
                null, filter, null, true);

            if (DS.incomevar.Rows.Count > 0) {
                Form mv = new FrmManage_Var(DS, Meta.Conn, Meta.Dispatcher, "I");
                DialogResult dr = mv.ShowDialog();
                if (dr != DialogResult.OK) {
                    DS.incomevar.Clear();
                    DS.incomesorted.Clear();
                }
            }
        }

        private void generaVariazione(string segno, DataRow rDettaglio) {
            DataRowVersion toConsider = DataRowVersion.Current;
            if (rDettaglio.RowState == DataRowState.Deleted) {
                toConsider = DataRowVersion.Original;
            }

            decimal sign = (segno == "+") ? 1 : -1;

            // vedo se esiste una variazione su quell'idexp_taxable, se non c'Ë la crea
            if (rDettaglio["idinc_taxable", toConsider] != DBNull.Value) {
                string filterVar = QHC.AppAnd(QHC.CmpEq("adate", Meta.GetSys("datacontabile")), QHC.CmpEq("idinc",
                    rDettaglio["idinc_taxable", toConsider]));
                DataRow[] ArrVarEsistente = DS.incomevar.Select(filterVar);
                DataRow CurrVar;
                //Vede se esiste gi‡ la variazione
                if (ArrVarEsistente.Length > 0) {
                    CurrVar = ArrVarEsistente[0];
                }
                else {
                    MetaData MetaVar = Meta.Dispatcher.Get("incomevar");
                    MetaVar.SetDefaults(DS.incomevar);
                    CurrVar = MetaVar.Get_New_Row(null, DS.incomevar);
                    CurrVar["idinc"] = rDettaglio["idinc_taxable", toConsider];
                    string what = (segno == "+") ? "Ripristino" : "Annullamento o sostituzione o cancellazione ";
                    CurrVar["description"] = what + " dett. contratto attivo " +
                                             rDettaglio["idestimkind", toConsider].ToString() + "/" +
                                             rDettaglio["yestim", toConsider].ToString() + "/" +
                                             rDettaglio["nestim", toConsider].ToString();
                }
                DataRow Contratto = DS.estimate.Rows[0];
                decimal tassocambio = CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
                if (tassocambio == 0) tassocambio = 1;
                decimal R_imponibile = CfgFn.GetNoNullDecimal(rDettaglio["taxable", toConsider]);
                decimal R_quantita = CfgFn.GetNoNullDecimal(rDettaglio["number", toConsider]);
                decimal R_sconto = CfgFn.Round(CfgFn.GetNoNullDecimal(rDettaglio["discount", toConsider]), 6);
                decimal taxable_euro = CfgFn.RoundValuta((R_imponibile * R_quantita * (1 - R_sconto)) * tassocambio);

                CurrVar["amount"] = CfgFn.GetNoNullDecimal(CurrVar["amount"]) + taxable_euro * sign;
            }
            //vedo se esiste una variazione su quell'idexp_iva, se non c'Ë la crea
            if (rDettaglio["idinc_iva", toConsider] != DBNull.Value) {
                string filterVar = QHC.AppAnd(QHC.CmpEq("adate", Meta.GetSys("datacontabile")),
                    QHC.CmpEq("idinc", rDettaglio["idinc_iva", toConsider]));
                DataRow[] ArrVarEsistente = DS.incomevar.Select(filterVar);
                DataRow CurrVar;
                //Vede se esiste gi‡ la variazione
                if (ArrVarEsistente.Length > 0) {
                    CurrVar = ArrVarEsistente[0];
                }
                else {
                    MetaData MetaVar = Meta.Dispatcher.Get("incomevar");
                    MetaVar.SetDefaults(DS.incomevar);
                    CurrVar = MetaVar.Get_New_Row(null, DS.incomevar);
                    CurrVar["idinc"] = rDettaglio["idinc_iva", toConsider];
                    string what = (segno == "+") ? "Ripristino" : "Annullamento o sostituzione o cancellazione ";
                    CurrVar["description"] = what + " dett. contratto attivo " +
                                             rDettaglio["idestimkind", toConsider].ToString() + "/" +
                                             rDettaglio["yestim", toConsider].ToString() + "/" +
                                             rDettaglio["nestim", toConsider].ToString();
                }
                DataRow Contratto = DS.estimate.Rows[0];
                decimal tassocambio = CfgFn.GetNoNullDecimal(Contratto["exchangerate"]);
                if (tassocambio == 0) tassocambio = 1;
                decimal R_imposta = CfgFn.GetNoNullDecimal(rDettaglio["tax", toConsider]);
                //iva_euro = CfgFn.RoundValuta(R_imposta * tassocambio);
                decimal iva_euro = CfgFn.RoundValuta(R_imposta); //consideriamo l'iva gi‡ in euro

                CurrVar["amount"] = CfgFn.GetNoNullDecimal(CurrVar["amount"]) + iva_euro * sign;

            }


        }

        public void MetaData_AfterPost() {

            EPM.afterPost();

        }



        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnSituazione = new System.Windows.Forms.Button();
            this.cmbTipoScadenza = new System.Windows.Forms.ComboBox();
            this.DS = new estimate_default.vistaForm();
            this.label11 = new System.Windows.Forms.Label();
            this.txtScadenza = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtRiferminento = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIndirizzoConsegna = new System.Windows.Forms.TextBox();
            this.TxtTermConsegna = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
            this.txtNumContratto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercContratto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotale = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.txtImponibile = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.detailgrid = new System.Windows.Forms.DataGrid();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Principale = new System.Windows.Forms.TabPage();
            this.lblcig = new System.Windows.Forms.Label();
            this.txtcig = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.gboxValuta = new System.Windows.Forms.GroupBox();
            this.txtValuta = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtCambio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxCliente = new System.Windows.Forms.GroupBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.gboxtipofattura = new System.Windows.Forms.GroupBox();
            this.rdbextracom = new System.Windows.Forms.RadioButton();
            this.rdbintracom = new System.Windows.Forms.RadioButton();
            this.rdbitalia = new System.Windows.Forms.RadioButton();
            this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
            this.txtFinanziamento = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tabDettagli = new System.Windows.Forms.TabPage();
            this.btnRipartizione = new System.Windows.Forms.Button();
            this.btnInserisciCopia = new System.Windows.Forms.Button();
            this.btnSostituisciDettaglio = new System.Windows.Forms.Button();
            this.btnUnisciDettagli = new System.Windows.Forms.Button();
            this.btnDividiDettaglio = new System.Windows.Forms.Button();
            this.Classificazioni = new System.Windows.Forms.TabPage();
            this.dgrClassificazioni = new System.Windows.Forms.DataGrid();
            this.btnIndElimina = new System.Windows.Forms.Button();
            this.btnIndModifica = new System.Windows.Forms.Button();
            this.btnIndInserisci = new System.Windows.Forms.Button();
            this.tabAllegati = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnDelAtt = new System.Windows.Forms.Button();
            this.btnEditAtt = new System.Windows.Forms.Button();
            this.btnInsAtt = new System.Windows.Forms.Button();
            this.tabAttributi = new System.Windows.Forms.TabPage();
            this.gboxclass05 = new System.Windows.Forms.GroupBox();
            this.txtCodice05 = new System.Windows.Forms.TextBox();
            this.btnCodice05 = new System.Windows.Forms.Button();
            this.txtDenom05 = new System.Windows.Forms.TextBox();
            this.gboxclass04 = new System.Windows.Forms.GroupBox();
            this.txtCodice04 = new System.Windows.Forms.TextBox();
            this.btnCodice04 = new System.Windows.Forms.Button();
            this.txtDenom04 = new System.Windows.Forms.TextBox();
            this.gboxclass03 = new System.Windows.Forms.GroupBox();
            this.txtCodice03 = new System.Windows.Forms.TextBox();
            this.btnCodice03 = new System.Windows.Forms.Button();
            this.txtDenom03 = new System.Windows.Forms.TextBox();
            this.gboxclass02 = new System.Windows.Forms.GroupBox();
            this.txtCodice02 = new System.Windows.Forms.TextBox();
            this.btnCodice02 = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxclass01 = new System.Windows.Forms.GroupBox();
            this.txtCodice01 = new System.Windows.Forms.TextBox();
            this.btnCodice01 = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.btnVisualizzaPreimpegni = new System.Windows.Forms.Button();
            this.btnGeneraPreimpegni = new System.Windows.Forms.Button();
            this.btnGeneraEpExp = new System.Windows.Forms.Button();
            this.btnVisualizzaEpExp = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleCrg = new System.Windows.Forms.TextBox();
            this.button7 = new System.Windows.Forms.Button();
            this.gBoxCausaleCredito = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleDeb = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.labAltroEsercizio = new System.Windows.Forms.Label();
            this.btnGeneraEP = new System.Windows.Forms.Button();
            this.btnVisualizzaEP = new System.Windows.Forms.Button();
            this.labEP = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Principale.SuspendLayout();
            this.gboxValuta.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.gboxCliente.SuspendLayout();
            this.gboxtipofattura.SuspendLayout();
            this.gboxFinanziamento.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            this.Classificazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).BeginInit();
            this.tabAllegati.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.gBoxCausaleCredito.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSituazione
            // 
            this.btnSituazione.Location = new System.Drawing.Point(344, 78);
            this.btnSituazione.Name = "btnSituazione";
            this.btnSituazione.Size = new System.Drawing.Size(72, 23);
            this.btnSituazione.TabIndex = 10;
            this.btnSituazione.TabStop = false;
            this.btnSituazione.Text = "Situazione";
            this.btnSituazione.Visible = false;
            this.btnSituazione.Click += new System.EventHandler(this.btnSituazione_Click);
            // 
            // cmbTipoScadenza
            // 
            this.cmbTipoScadenza.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoScadenza.DataSource = this.DS.expirationkind;
            this.cmbTipoScadenza.DisplayMember = "description";
            this.cmbTipoScadenza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoScadenza.Location = new System.Drawing.Point(51, 14);
            this.cmbTipoScadenza.Name = "cmbTipoScadenza";
            this.cmbTipoScadenza.Size = new System.Drawing.Size(250, 21);
            this.cmbTipoScadenza.TabIndex = 9;
            this.cmbTipoScadenza.Tag = "estimate.idexpirationkind?estimateview.idexpirationkind";
            this.cmbTipoScadenza.ValueMember = "idexpirationkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(11, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 22;
            this.label11.Text = "Tipo";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtScadenza
            // 
            this.txtScadenza.Location = new System.Drawing.Point(405, 14);
            this.txtScadenza.Name = "txtScadenza";
            this.txtScadenza.Size = new System.Drawing.Size(88, 20);
            this.txtScadenza.TabIndex = 10;
            this.txtScadenza.Tag = "estimate.paymentexpiring?estimateview.paymentexpiring";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(320, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 20;
            this.label12.Text = "Scadenza:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(424, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Riferimento:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRiferminento
            // 
            this.txtRiferminento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRiferminento.Location = new System.Drawing.Point(424, 16);
            this.txtRiferminento.Multiline = true;
            this.txtRiferminento.Name = "txtRiferminento";
            this.txtRiferminento.Size = new System.Drawing.Size(532, 56);
            this.txtRiferminento.TabIndex = 1;
            this.txtRiferminento.Tag = "estimate.registryreference?estimateview.registryreference";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Indirizzo";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtIndirizzoConsegna
            // 
            this.txtIndirizzoConsegna.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIndirizzoConsegna.Location = new System.Drawing.Point(11, 38);
            this.txtIndirizzoConsegna.Multiline = true;
            this.txtIndirizzoConsegna.Name = "txtIndirizzoConsegna";
            this.txtIndirizzoConsegna.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIndirizzoConsegna.Size = new System.Drawing.Size(482, 51);
            this.txtIndirizzoConsegna.TabIndex = 14;
            this.txtIndirizzoConsegna.Tag = "estimate.deliveryaddress";
            // 
            // TxtTermConsegna
            // 
            this.TxtTermConsegna.Location = new System.Drawing.Point(198, 11);
            this.TxtTermConsegna.Name = "TxtTermConsegna";
            this.TxtTermConsegna.Size = new System.Drawing.Size(139, 20);
            this.TxtTermConsegna.TabIndex = 13;
            this.TxtTermConsegna.Tag = "estimate.deliveryexpiration";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(148, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 14;
            this.label8.Text = "Termine:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 120);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(424, 64);
            this.txtDescrizione.TabIndex = 8;
            this.txtDescrizione.Tag = "estimate.description";
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(338, 17);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(80, 20);
            this.txtDataDoc.TabIndex = 5;
            this.txtDataDoc.Tag = "estimate.docdate";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(300, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDocumento
            // 
            this.txtDocumento.Location = new System.Drawing.Point(72, 16);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.Size = new System.Drawing.Size(160, 20);
            this.txtDocumento.TabIndex = 4;
            this.txtDocumento.Tag = "estimate.doc";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Documento";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.cmbTipoContratto);
            this.groupBox1.Controls.Add(this.txtNumContratto);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtEsercContratto);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 72);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contratto Attivo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 24);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "Choose.estimatekind.default";
            this.button1.Text = "Tipo";
            // 
            // cmbTipoContratto
            // 
            this.cmbTipoContratto.DataSource = this.DS.estimatekind;
            this.cmbTipoContratto.DisplayMember = "description";
            this.cmbTipoContratto.Location = new System.Drawing.Point(80, 16);
            this.cmbTipoContratto.Name = "cmbTipoContratto";
            this.cmbTipoContratto.Size = new System.Drawing.Size(320, 21);
            this.cmbTipoContratto.TabIndex = 1;
            this.cmbTipoContratto.Tag = "estimate.idestimkind";
            this.cmbTipoContratto.ValueMember = "idestimkind";
            // 
            // txtNumContratto
            // 
            this.txtNumContratto.Location = new System.Drawing.Point(216, 48);
            this.txtNumContratto.Name = "txtNumContratto";
            this.txtNumContratto.Size = new System.Drawing.Size(56, 20);
            this.txtNumContratto.TabIndex = 3;
            this.txtNumContratto.Tag = "estimate.nestim";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(152, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercContratto
            // 
            this.txtEsercContratto.Location = new System.Drawing.Point(80, 48);
            this.txtEsercContratto.Name = "txtEsercContratto";
            this.txtEsercContratto.Size = new System.Drawing.Size(56, 20);
            this.txtEsercContratto.TabIndex = 2;
            this.txtEsercContratto.Tag = "estimate.yestim.year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotale
            // 
            this.txtTotale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotale.Location = new System.Drawing.Point(824, 298);
            this.txtTotale.Name = "txtTotale";
            this.txtTotale.ReadOnly = true;
            this.txtTotale.Size = new System.Drawing.Size(112, 20);
            this.txtTotale.TabIndex = 33;
            this.txtTotale.TabStop = false;
            this.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIva
            // 
            this.txtIva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIva.Location = new System.Drawing.Point(688, 298);
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(88, 20);
            this.txtIva.TabIndex = 32;
            this.txtIva.TabStop = false;
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImponibile
            // 
            this.txtImponibile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImponibile.Location = new System.Drawing.Point(536, 298);
            this.txtImponibile.Name = "txtImponibile";
            this.txtImponibile.ReadOnly = true;
            this.txtImponibile.Size = new System.Drawing.Size(112, 20);
            this.txtImponibile.TabIndex = 31;
            this.txtImponibile.TabStop = false;
            this.txtImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Location = new System.Drawing.Point(776, 298);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(40, 16);
            this.label16.TabIndex = 30;
            this.label16.Text = "Totale:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Location = new System.Drawing.Point(648, 298);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(32, 16);
            this.label17.TabIndex = 29;
            this.label17.Text = "IVA:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.Location = new System.Drawing.Point(464, 298);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(64, 16);
            this.label18.TabIndex = 28;
            this.label18.Text = "Imponibile:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(4, 90);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 23);
            this.btnElimina.TabIndex = 18;
            this.btnElimina.TabStop = false;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(4, 58);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 23);
            this.btnModifica.TabIndex = 17;
            this.btnModifica.TabStop = false;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(4, 26);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 23);
            this.btnInserisci.TabIndex = 16;
            this.btnInserisci.TabStop = false;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // detailgrid
            // 
            this.detailgrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.detailgrid.CaptionVisible = false;
            this.detailgrid.DataMember = "";
            this.detailgrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.detailgrid.Location = new System.Drawing.Point(82, 15);
            this.detailgrid.Name = "detailgrid";
            this.detailgrid.Size = new System.Drawing.Size(854, 277);
            this.detailgrid.TabIndex = 14;
            this.detailgrid.Tag = "estimatedetail.lista.single";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtIndirizzoConsegna);
            this.groupBox3.Controls.Add(this.TxtTermConsegna);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Location = new System.Drawing.Point(447, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(505, 95);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Trasporto";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.txtDocumento);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.txtDataDoc);
            this.groupBox4.Location = new System.Drawing.Point(8, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(424, 48);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Documento collegato";
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.txtScadenza);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.cmbTipoScadenza);
            this.groupBox5.Location = new System.Drawing.Point(447, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(505, 48);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Scadenza";
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(8, 77);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(244, 24);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Tag = "estimate.active:S:N";
            this.checkBox1.Text = "Utilizzabile per la contabilizzazione";
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(442, 287);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 16);
            this.label15.TabIndex = 36;
            this.label15.Text = "Data Contabile:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(536, 283);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(87, 20);
            this.txtDataContabile.TabIndex = 13;
            this.txtDataContabile.Tag = "estimate.adate?estimateview.adate";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.Principale);
            this.tabControl1.Controls.Add(this.tabDettagli);
            this.tabControl1.Controls.Add(this.Classificazioni);
            this.tabControl1.Controls.Add(this.tabAllegati);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Location = new System.Drawing.Point(8, 107);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(961, 356);
            this.tabControl1.TabIndex = 3;
            // 
            // Principale
            // 
            this.Principale.Controls.Add(this.lblcig);
            this.Principale.Controls.Add(this.txtcig);
            this.Principale.Controls.Add(this.label22);
            this.Principale.Controls.Add(this.textBox7);
            this.Principale.Controls.Add(this.gboxValuta);
            this.Principale.Controls.Add(this.gboxResponsabile);
            this.Principale.Controls.Add(this.gboxCliente);
            this.Principale.Controls.Add(this.gboxtipofattura);
            this.Principale.Controls.Add(this.gboxFinanziamento);
            this.Principale.Controls.Add(this.label5);
            this.Principale.Controls.Add(this.label15);
            this.Principale.Controls.Add(this.txtDataContabile);
            this.Principale.Controls.Add(this.groupBox4);
            this.Principale.Controls.Add(this.groupBox5);
            this.Principale.Controls.Add(this.groupBox3);
            this.Principale.Controls.Add(this.txtDescrizione);
            this.Principale.Location = new System.Drawing.Point(4, 22);
            this.Principale.Name = "Principale";
            this.Principale.Size = new System.Drawing.Size(953, 330);
            this.Principale.TabIndex = 0;
            this.Principale.Text = "Principale";
            this.Principale.UseVisualStyleBackColor = true;
            // 
            // lblcig
            // 
            this.lblcig.Location = new System.Drawing.Point(658, 281);
            this.lblcig.Name = "lblcig";
            this.lblcig.Size = new System.Drawing.Size(173, 23);
            this.lblcig.TabIndex = 65;
            this.lblcig.Tag = "";
            this.lblcig.Text = "Codice Identificativo di Gara(CIG)";
            this.lblcig.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtcig
            // 
            this.txtcig.Location = new System.Drawing.Point(846, 281);
            this.txtcig.Name = "txtcig";
            this.txtcig.Size = new System.Drawing.Size(94, 20);
            this.txtcig.TabIndex = 64;
            this.txtcig.Tag = "estimate.cigcode";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(16, 283);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(192, 23);
            this.label22.TabIndex = 63;
            this.label22.Tag = "mandate.external_reference";
            this.label22.Text = "Codice proveniente da importazione";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(220, 283);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(207, 20);
            this.textBox7.TabIndex = 62;
            this.textBox7.Tag = "estimate.external_reference";
            // 
            // gboxValuta
            // 
            this.gboxValuta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxValuta.Controls.Add(this.txtValuta);
            this.gboxValuta.Controls.Add(this.button2);
            this.gboxValuta.Controls.Add(this.txtCambio);
            this.gboxValuta.Controls.Add(this.label6);
            this.gboxValuta.Location = new System.Drawing.Point(447, 62);
            this.gboxValuta.Name = "gboxValuta";
            this.gboxValuta.Size = new System.Drawing.Size(505, 48);
            this.gboxValuta.TabIndex = 7;
            this.gboxValuta.TabStop = false;
            this.gboxValuta.Tag = "AutoChoose.txtValuta.default";
            // 
            // txtValuta
            // 
            this.txtValuta.Location = new System.Drawing.Point(89, 14);
            this.txtValuta.Name = "txtValuta";
            this.txtValuta.Size = new System.Drawing.Size(197, 20);
            this.txtValuta.TabIndex = 1;
            this.txtValuta.Tag = "currency.description?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 13);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 31;
            this.button2.TabStop = false;
            this.button2.Tag = "choose.currency.default";
            this.button2.Text = "Valuta";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // txtCambio
            // 
            this.txtCambio.Location = new System.Drawing.Point(390, 14);
            this.txtCambio.Name = "txtCambio";
            this.txtCambio.Size = new System.Drawing.Size(103, 20);
            this.txtCambio.TabIndex = 2;
            this.txtCambio.Tag = "estimate.exchangerate.fixed.5...1";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(292, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 16);
            this.label6.TabIndex = 30;
            this.label6.Text = "Tasso di cambio:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(8, 235);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(427, 40);
            this.gboxResponsabile.TabIndex = 11;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(5, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(416, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // gboxCliente
            // 
            this.gboxCliente.Controls.Add(this.txtCliente);
            this.gboxCliente.Location = new System.Drawing.Point(8, 62);
            this.gboxCliente.Name = "gboxCliente";
            this.gboxCliente.Size = new System.Drawing.Size(426, 40);
            this.gboxCliente.TabIndex = 6;
            this.gboxCliente.TabStop = false;
            this.gboxCliente.Tag = "AutoChoose.txtCliente.default.(active=\'S\')";
            this.gboxCliente.Text = "Cliente";
            // 
            // txtCliente
            // 
            this.txtCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCliente.Location = new System.Drawing.Point(6, 16);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(414, 20);
            this.txtCliente.TabIndex = 6;
            this.txtCliente.Tag = "registrymainview.title?mandateview.registry";
            // 
            // gboxtipofattura
            // 
            this.gboxtipofattura.Controls.Add(this.rdbextracom);
            this.gboxtipofattura.Controls.Add(this.rdbintracom);
            this.gboxtipofattura.Controls.Add(this.rdbitalia);
            this.gboxtipofattura.Location = new System.Drawing.Point(450, 235);
            this.gboxtipofattura.Name = "gboxtipofattura";
            this.gboxtipofattura.Size = new System.Drawing.Size(498, 40);
            this.gboxtipofattura.TabIndex = 12;
            this.gboxtipofattura.TabStop = false;
            this.gboxtipofattura.Text = "Tipo Contratto";
            // 
            // rdbextracom
            // 
            this.rdbextracom.AutoSize = true;
            this.rdbextracom.Location = new System.Drawing.Point(148, 15);
            this.rdbextracom.Name = "rdbextracom";
            this.rdbextracom.Size = new System.Drawing.Size(113, 17);
            this.rdbextracom.TabIndex = 25;
            this.rdbextracom.TabStop = true;
            this.rdbextracom.Tag = "estimate.flagintracom:X";
            this.rdbextracom.Text = "Contratto Extra-UE";
            this.rdbextracom.UseVisualStyleBackColor = true;
            // 
            // rdbintracom
            // 
            this.rdbintracom.AutoSize = true;
            this.rdbintracom.Location = new System.Drawing.Point(6, 15);
            this.rdbintracom.Name = "rdbintracom";
            this.rdbintracom.Size = new System.Drawing.Size(115, 17);
            this.rdbintracom.TabIndex = 24;
            this.rdbintracom.TabStop = true;
            this.rdbintracom.Tag = "estimate.flagintracom:S";
            this.rdbintracom.Text = "Contratto Intracom.";
            this.rdbintracom.UseVisualStyleBackColor = true;
            // 
            // rdbitalia
            // 
            this.rdbitalia.AutoSize = true;
            this.rdbitalia.Location = new System.Drawing.Point(320, 14);
            this.rdbitalia.Name = "rdbitalia";
            this.rdbitalia.Size = new System.Drawing.Size(104, 17);
            this.rdbitalia.TabIndex = 23;
            this.rdbitalia.TabStop = true;
            this.rdbitalia.Tag = "estimate.flagintracom:N";
            this.rdbitalia.Text = "Contratto in Italia";
            this.rdbitalia.UseVisualStyleBackColor = true;
            // 
            // gboxFinanziamento
            // 
            this.gboxFinanziamento.Controls.Add(this.txtFinanziamento);
            this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
            this.gboxFinanziamento.Location = new System.Drawing.Point(11, 190);
            this.gboxFinanziamento.Name = "gboxFinanziamento";
            this.gboxFinanziamento.Size = new System.Drawing.Size(424, 39);
            this.gboxFinanziamento.TabIndex = 10;
            this.gboxFinanziamento.TabStop = false;
            this.gboxFinanziamento.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
            // 
            // txtFinanziamento
            // 
            this.txtFinanziamento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinanziamento.Location = new System.Drawing.Point(112, 11);
            this.txtFinanziamento.Multiline = true;
            this.txtFinanziamento.Name = "txtFinanziamento";
            this.txtFinanziamento.Size = new System.Drawing.Size(304, 22);
            this.txtFinanziamento.TabIndex = 2;
            this.txtFinanziamento.TabStop = false;
            this.txtFinanziamento.Tag = "underwriting.title?estimateview.underwriting";
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 9);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 0;
            this.btnFinanziamento.Tag = "choose.underwriting.default";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Descrizione:";
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.btnRipartizione);
            this.tabDettagli.Controls.Add(this.btnInserisciCopia);
            this.tabDettagli.Controls.Add(this.label18);
            this.tabDettagli.Controls.Add(this.btnSostituisciDettaglio);
            this.tabDettagli.Controls.Add(this.txtIva);
            this.tabDettagli.Controls.Add(this.txtTotale);
            this.tabDettagli.Controls.Add(this.txtImponibile);
            this.tabDettagli.Controls.Add(this.btnUnisciDettagli);
            this.tabDettagli.Controls.Add(this.detailgrid);
            this.tabDettagli.Controls.Add(this.label16);
            this.tabDettagli.Controls.Add(this.btnDividiDettaglio);
            this.tabDettagli.Controls.Add(this.btnInserisci);
            this.tabDettagli.Controls.Add(this.label17);
            this.tabDettagli.Controls.Add(this.btnModifica);
            this.tabDettagli.Controls.Add(this.btnElimina);
            this.tabDettagli.Location = new System.Drawing.Point(4, 22);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Size = new System.Drawing.Size(953, 330);
            this.tabDettagli.TabIndex = 4;
            this.tabDettagli.Text = "Dettagli";
            this.tabDettagli.UseVisualStyleBackColor = true;
            // 
            // btnRipartizione
            // 
            this.btnRipartizione.Location = new System.Drawing.Point(3, 255);
            this.btnRipartizione.Name = "btnRipartizione";
            this.btnRipartizione.Size = new System.Drawing.Size(72, 23);
            this.btnRipartizione.TabIndex = 44;
            this.btnRipartizione.Text = "Ripartizione";
            this.btnRipartizione.Click += new System.EventHandler(this.btnRipartizione_Click);
            // 
            // btnInserisciCopia
            // 
            this.btnInserisciCopia.Location = new System.Drawing.Point(3, 118);
            this.btnInserisciCopia.Name = "btnInserisciCopia";
            this.btnInserisciCopia.Size = new System.Drawing.Size(73, 40);
            this.btnInserisciCopia.TabIndex = 43;
            this.btnInserisciCopia.Text = "Inserisci Copia";
            this.btnInserisciCopia.UseVisualStyleBackColor = true;
            this.btnInserisciCopia.Click += new System.EventHandler(this.btnInserisciCopia_Click);
            // 
            // btnSostituisciDettaglio
            // 
            this.btnSostituisciDettaglio.Location = new System.Drawing.Point(4, 226);
            this.btnSostituisciDettaglio.Name = "btnSostituisciDettaglio";
            this.btnSostituisciDettaglio.Size = new System.Drawing.Size(72, 23);
            this.btnSostituisciDettaglio.TabIndex = 42;
            this.btnSostituisciDettaglio.Text = "Sostituisci";
            this.btnSostituisciDettaglio.Click += new System.EventHandler(this.btnSostituisciDettaglio_Click);
            // 
            // btnUnisciDettagli
            // 
            this.btnUnisciDettagli.Location = new System.Drawing.Point(4, 196);
            this.btnUnisciDettagli.Name = "btnUnisciDettagli";
            this.btnUnisciDettagli.Size = new System.Drawing.Size(72, 24);
            this.btnUnisciDettagli.TabIndex = 38;
            this.btnUnisciDettagli.Text = "Unisci";
            this.btnUnisciDettagli.Click += new System.EventHandler(this.btnUnisciDettagli_Click);
            // 
            // btnDividiDettaglio
            // 
            this.btnDividiDettaglio.Location = new System.Drawing.Point(4, 166);
            this.btnDividiDettaglio.Name = "btnDividiDettaglio";
            this.btnDividiDettaglio.Size = new System.Drawing.Size(72, 24);
            this.btnDividiDettaglio.TabIndex = 37;
            this.btnDividiDettaglio.Text = "Dividi";
            this.btnDividiDettaglio.Click += new System.EventHandler(this.btnDividiDettaglio_Click);
            // 
            // Classificazioni
            // 
            this.Classificazioni.Controls.Add(this.dgrClassificazioni);
            this.Classificazioni.Controls.Add(this.btnIndElimina);
            this.Classificazioni.Controls.Add(this.btnIndModifica);
            this.Classificazioni.Controls.Add(this.btnIndInserisci);
            this.Classificazioni.Location = new System.Drawing.Point(4, 22);
            this.Classificazioni.Name = "Classificazioni";
            this.Classificazioni.Size = new System.Drawing.Size(953, 330);
            this.Classificazioni.TabIndex = 1;
            this.Classificazioni.Text = "Classificazioni";
            this.Classificazioni.UseVisualStyleBackColor = true;
            // 
            // dgrClassificazioni
            // 
            this.dgrClassificazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrClassificazioni.DataMember = "";
            this.dgrClassificazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrClassificazioni.Location = new System.Drawing.Point(24, 46);
            this.dgrClassificazioni.Name = "dgrClassificazioni";
            this.dgrClassificazioni.ReadOnly = true;
            this.dgrClassificazioni.Size = new System.Drawing.Size(905, 266);
            this.dgrClassificazioni.TabIndex = 19;
            this.dgrClassificazioni.Tag = "estimatesorting.default.default";
            // 
            // btnIndElimina
            // 
            this.btnIndElimina.Location = new System.Drawing.Point(184, 16);
            this.btnIndElimina.Name = "btnIndElimina";
            this.btnIndElimina.Size = new System.Drawing.Size(68, 24);
            this.btnIndElimina.TabIndex = 18;
            this.btnIndElimina.Tag = "delete";
            this.btnIndElimina.Text = "Elimina";
            // 
            // btnIndModifica
            // 
            this.btnIndModifica.Location = new System.Drawing.Point(104, 16);
            this.btnIndModifica.Name = "btnIndModifica";
            this.btnIndModifica.Size = new System.Drawing.Size(69, 24);
            this.btnIndModifica.TabIndex = 17;
            this.btnIndModifica.Tag = "edit.default";
            this.btnIndModifica.Text = "Modifica...";
            // 
            // btnIndInserisci
            // 
            this.btnIndInserisci.Location = new System.Drawing.Point(24, 16);
            this.btnIndInserisci.Name = "btnIndInserisci";
            this.btnIndInserisci.Size = new System.Drawing.Size(68, 24);
            this.btnIndInserisci.TabIndex = 16;
            this.btnIndInserisci.Tag = "insert.default";
            this.btnIndInserisci.Text = "Inserisci...";
            // 
            // tabAllegati
            // 
            this.tabAllegati.Controls.Add(this.dataGrid1);
            this.tabAllegati.Controls.Add(this.btnDelAtt);
            this.tabAllegati.Controls.Add(this.btnEditAtt);
            this.tabAllegati.Controls.Add(this.btnInsAtt);
            this.tabAllegati.Location = new System.Drawing.Point(4, 22);
            this.tabAllegati.Name = "tabAllegati";
            this.tabAllegati.Padding = new System.Windows.Forms.Padding(3);
            this.tabAllegati.Size = new System.Drawing.Size(953, 330);
            this.tabAllegati.TabIndex = 5;
            this.tabAllegati.Text = "Allegati";
            this.tabAllegati.UseVisualStyleBackColor = true;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(15, 52);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(929, 258);
            this.dataGrid1.TabIndex = 23;
            this.dataGrid1.Tag = "estimateattachment.lista.default";
            // 
            // btnDelAtt
            // 
            this.btnDelAtt.Location = new System.Drawing.Point(175, 22);
            this.btnDelAtt.Name = "btnDelAtt";
            this.btnDelAtt.Size = new System.Drawing.Size(68, 24);
            this.btnDelAtt.TabIndex = 22;
            this.btnDelAtt.Tag = "delete";
            this.btnDelAtt.Text = "Elimina";
            // 
            // btnEditAtt
            // 
            this.btnEditAtt.Location = new System.Drawing.Point(95, 22);
            this.btnEditAtt.Name = "btnEditAtt";
            this.btnEditAtt.Size = new System.Drawing.Size(69, 24);
            this.btnEditAtt.TabIndex = 21;
            this.btnEditAtt.Tag = "edit.default";
            this.btnEditAtt.Text = "Modifica...";
            // 
            // btnInsAtt
            // 
            this.btnInsAtt.Location = new System.Drawing.Point(15, 22);
            this.btnInsAtt.Name = "btnInsAtt";
            this.btnInsAtt.Size = new System.Drawing.Size(68, 24);
            this.btnInsAtt.TabIndex = 20;
            this.btnInsAtt.Tag = "insert.default";
            this.btnInsAtt.Text = "Inserisci...";
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributi.Size = new System.Drawing.Size(953, 330);
            this.tabAttributi.TabIndex = 3;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(480, 76);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(467, 64);
            this.gboxclass05.TabIndex = 28;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 38);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(219, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 16);
            this.btnCodice05.Name = "btnCodice05";
            this.btnCodice05.Size = new System.Drawing.Size(88, 23);
            this.btnCodice05.TabIndex = 4;
            this.btnCodice05.Tag = "manage.sorting05.tree";
            this.btnCodice05.Text = "Codice";
            this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom05
            // 
            this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom05.Location = new System.Drawing.Point(234, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(225, 52);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(480, 6);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(467, 64);
            this.gboxclass04.TabIndex = 27;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(9, 38);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(219, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(8, 16);
            this.btnCodice04.Name = "btnCodice04";
            this.btnCodice04.Size = new System.Drawing.Size(88, 23);
            this.btnCodice04.TabIndex = 4;
            this.btnCodice04.Tag = "manage.sorting04.tree";
            this.btnCodice04.Text = "Codice";
            this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom04
            // 
            this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom04.Location = new System.Drawing.Point(234, 12);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(225, 46);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(6, 146);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(465, 64);
            this.gboxclass03.TabIndex = 25;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 38);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(219, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(8, 16);
            this.btnCodice03.Name = "btnCodice03";
            this.btnCodice03.Size = new System.Drawing.Size(88, 23);
            this.btnCodice03.TabIndex = 4;
            this.btnCodice03.Tag = "manage.sorting03.tree";
            this.btnCodice03.Text = "Codice";
            this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom03
            // 
            this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom03.Location = new System.Drawing.Point(233, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(224, 52);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(6, 76);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(465, 64);
            this.gboxclass02.TabIndex = 26;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(8, 38);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(219, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 16);
            this.btnCodice02.Name = "btnCodice02";
            this.btnCodice02.Size = new System.Drawing.Size(88, 23);
            this.btnCodice02.TabIndex = 4;
            this.btnCodice02.Tag = "manage.sorting02.tree";
            this.btnCodice02.Text = "Codice";
            this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(233, 8);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(224, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(6, 6);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(465, 64);
            this.gboxclass01.TabIndex = 24;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(7, 40);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(220, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(8, 16);
            this.btnCodice01.Name = "btnCodice01";
            this.btnCodice01.Size = new System.Drawing.Size(88, 23);
            this.btnCodice01.TabIndex = 4;
            this.btnCodice01.Tag = "manage.sorting01.tree";
            this.btnCodice01.Text = "Codice";
            this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(233, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(224, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.btnVisualizzaPreimpegni);
            this.tabEP.Controls.Add(this.btnGeneraPreimpegni);
            this.tabEP.Controls.Add(this.btnGeneraEpExp);
            this.tabEP.Controls.Add(this.btnVisualizzaEpExp);
            this.tabEP.Controls.Add(this.label43);
            this.tabEP.Controls.Add(this.textBox3);
            this.tabEP.Controls.Add(this.groupBox11);
            this.tabEP.Controls.Add(this.gBoxCausaleCredito);
            this.tabEP.Controls.Add(this.labAltroEsercizio);
            this.tabEP.Controls.Add(this.btnGeneraEP);
            this.tabEP.Controls.Add(this.btnVisualizzaEP);
            this.tabEP.Controls.Add(this.labEP);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(953, 330);
            this.tabEP.TabIndex = 2;
            this.tabEP.Text = "EP";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // btnVisualizzaPreimpegni
            // 
            this.btnVisualizzaPreimpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizzaPreimpegni.Location = new System.Drawing.Point(523, 41);
            this.btnVisualizzaPreimpegni.Name = "btnVisualizzaPreimpegni";
            this.btnVisualizzaPreimpegni.Size = new System.Drawing.Size(306, 23);
            this.btnVisualizzaPreimpegni.TabIndex = 46;
            this.btnVisualizzaPreimpegni.TabStop = false;
            this.btnVisualizzaPreimpegni.Text = "Visualizza Preimpegni di Budget";
            // 
            // btnGeneraPreimpegni
            // 
            this.btnGeneraPreimpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraPreimpegni.Location = new System.Drawing.Point(523, 12);
            this.btnGeneraPreimpegni.Name = "btnGeneraPreimpegni";
            this.btnGeneraPreimpegni.Size = new System.Drawing.Size(306, 23);
            this.btnGeneraPreimpegni.TabIndex = 45;
            this.btnGeneraPreimpegni.TabStop = false;
            this.btnGeneraPreimpegni.Text = "Genera Preimpegni di Budget";
            // 
            // btnGeneraEpExp
            // 
            this.btnGeneraEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraEpExp.Location = new System.Drawing.Point(268, 12);
            this.btnGeneraEpExp.Name = "btnGeneraEpExp";
            this.btnGeneraEpExp.Size = new System.Drawing.Size(203, 23);
            this.btnGeneraEpExp.TabIndex = 43;
            this.btnGeneraEpExp.TabStop = false;
            this.btnGeneraEpExp.Text = "Genera Impegni di Budget";
            // 
            // btnVisualizzaEpExp
            // 
            this.btnVisualizzaEpExp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVisualizzaEpExp.Location = new System.Drawing.Point(268, 41);
            this.btnVisualizzaEpExp.Name = "btnVisualizzaEpExp";
            this.btnVisualizzaEpExp.Size = new System.Drawing.Size(203, 23);
            this.btnVisualizzaEpExp.TabIndex = 44;
            this.btnVisualizzaEpExp.TabStop = false;
            this.btnVisualizzaEpExp.Text = "Visualizza Impegni di Budget";
            // 
            // label43
            // 
            this.label43.Location = new System.Drawing.Point(385, 135);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(265, 16);
            this.label43.TabIndex = 18;
            this.label43.Text = "Data correzione causale di credito";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(388, 157);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(134, 20);
            this.textBox3.TabIndex = 2;
            this.textBox3.Tag = "estimate.idaccmotivecredit_datacrg?estimateview.idaccmotivecredit_datacrg";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.textBox4);
            this.groupBox11.Controls.Add(this.txtCodiceCausaleCrg);
            this.groupBox11.Controls.Add(this.button7);
            this.groupBox11.Location = new System.Drawing.Point(388, 181);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(378, 80);
            this.groupBox11.TabIndex = 16;
            this.groupBox11.TabStop = false;
            this.groupBox11.Tag = "AutoManage.txtCodiceCausaleCrg.tree.(in_use = \'S\')";
            this.groupBox11.Text = "Causale di credito aggiornata";
            this.groupBox11.UseCompatibleTextRendering = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(172, 12);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(200, 56);
            this.textBox4.TabIndex = 2;
            this.textBox4.TabStop = false;
            this.textBox4.Tag = "accmotiveapplied_crg.motive";
            // 
            // txtCodiceCausaleCrg
            // 
            this.txtCodiceCausaleCrg.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceCausaleCrg.Name = "txtCodiceCausaleCrg";
            this.txtCodiceCausaleCrg.Size = new System.Drawing.Size(158, 20);
            this.txtCodiceCausaleCrg.TabIndex = 3;
            this.txtCodiceCausaleCrg.Tag = "accmotiveapplied_crg.codemotive?estimateview.codemotivedebit_crg";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(8, 16);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(104, 23);
            this.button7.TabIndex = 0;
            this.button7.TabStop = false;
            this.button7.Tag = "manage.accmotiveapplied_crg.tree";
            this.button7.Text = "Causale";
            // 
            // gBoxCausaleCredito
            // 
            this.gBoxCausaleCredito.Controls.Add(this.textBox1);
            this.gBoxCausaleCredito.Controls.Add(this.txtCodiceCausaleDeb);
            this.gBoxCausaleCredito.Controls.Add(this.button6);
            this.gBoxCausaleCredito.Location = new System.Drawing.Point(15, 181);
            this.gBoxCausaleCredito.Name = "gBoxCausaleCredito";
            this.gBoxCausaleCredito.Size = new System.Drawing.Size(367, 80);
            this.gBoxCausaleCredito.TabIndex = 14;
            this.gBoxCausaleCredito.TabStop = false;
            this.gBoxCausaleCredito.Tag = "AutoManage.txtCodiceCausaleDeb.tree.(in_use = \'S\')";
            this.gBoxCausaleCredito.Text = "Causale di credito";
            this.gBoxCausaleCredito.UseCompatibleTextRendering = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(161, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(200, 56);
            this.textBox1.TabIndex = 2;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "accmotiveapplied_credit.motive";
            // 
            // txtCodiceCausaleDeb
            // 
            this.txtCodiceCausaleDeb.Location = new System.Drawing.Point(10, 48);
            this.txtCodiceCausaleDeb.Name = "txtCodiceCausaleDeb";
            this.txtCodiceCausaleDeb.Size = new System.Drawing.Size(145, 20);
            this.txtCodiceCausaleDeb.TabIndex = 1;
            this.txtCodiceCausaleDeb.Tag = "accmotiveapplied_credit.codemotive?estimateview.codemotivecredit";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(8, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(104, 23);
            this.button6.TabIndex = 0;
            this.button6.TabStop = false;
            this.button6.Tag = "manage.accmotiveapplied_credit.tree";
            this.button6.Text = "Causale";
            // 
            // labAltroEsercizio
            // 
            this.labAltroEsercizio.AutoSize = true;
            this.labAltroEsercizio.Location = new System.Drawing.Point(12, 102);
            this.labAltroEsercizio.Name = "labAltroEsercizio";
            this.labAltroEsercizio.Size = new System.Drawing.Size(324, 13);
            this.labAltroEsercizio.TabIndex = 5;
            this.labAltroEsercizio.Text = "Il contratto non contiene scritture di competenza di questo esercizio";
            // 
            // btnGeneraEP
            // 
            this.btnGeneraEP.Location = new System.Drawing.Point(25, 41);
            this.btnGeneraEP.Name = "btnGeneraEP";
            this.btnGeneraEP.Size = new System.Drawing.Size(224, 23);
            this.btnGeneraEP.TabIndex = 3;
            this.btnGeneraEP.Text = "Genera le scritture in partita doppia";
            this.btnGeneraEP.UseVisualStyleBackColor = true;
            // 
            // btnVisualizzaEP
            // 
            this.btnVisualizzaEP.Location = new System.Drawing.Point(25, 12);
            this.btnVisualizzaEP.Name = "btnVisualizzaEP";
            this.btnVisualizzaEP.Size = new System.Drawing.Size(224, 23);
            this.btnVisualizzaEP.TabIndex = 2;
            this.btnVisualizzaEP.Text = "Visualizza le scritture in partita doppia";
            this.btnVisualizzaEP.UseVisualStyleBackColor = true;
            // 
            // labEP
            // 
            this.labEP.AutoSize = true;
            this.labEP.Location = new System.Drawing.Point(12, 80);
            this.labEP.Name = "labEP";
            this.labEP.Size = new System.Drawing.Size(237, 13);
            this.labEP.TabIndex = 0;
            this.labEP.Text = "Le scritture in partita doppia sono state generate.";
            // 
            // Frm_estimate_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(972, 475);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtRiferminento);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSituazione);
            this.Name = "Frm_estimate_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.detailgrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Principale.ResumeLayout(false);
            this.Principale.PerformLayout();
            this.gboxValuta.ResumeLayout(false);
            this.gboxValuta.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.gboxCliente.ResumeLayout(false);
            this.gboxCliente.PerformLayout();
            this.gboxtipofattura.ResumeLayout(false);
            this.gboxtipofattura.PerformLayout();
            this.gboxFinanziamento.ResumeLayout(false);
            this.gboxFinanziamento.PerformLayout();
            this.tabDettagli.ResumeLayout(false);
            this.tabDettagli.PerformLayout();
            this.Classificazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrClassificazioni)).EndInit();
            this.tabAllegati.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabAttributi.ResumeLayout(false);
            this.gboxclass05.ResumeLayout(false);
            this.gboxclass05.PerformLayout();
            this.gboxclass04.ResumeLayout(false);
            this.gboxclass04.PerformLayout();
            this.gboxclass03.ResumeLayout(false);
            this.gboxclass03.PerformLayout();
            this.gboxclass02.ResumeLayout(false);
            this.gboxclass02.PerformLayout();
            this.gboxclass01.ResumeLayout(false);
            this.gboxclass01.PerformLayout();
            this.tabEP.ResumeLayout(false);
            this.tabEP.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.gBoxCausaleCredito.ResumeLayout(false);
            this.gBoxCausaleCredito.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Metodo che annulla / ripristina tutti i dettagli fratelli di un dettaglio annullato / ripristinato.
        /// Per fratello si intende un dettaglio appartenente allo stesso gruppo, nel caso di split.
        /// </summary>
        private void allineaFratelli() {
            int sysYear = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            bool viewMessage = true;
            if (DS.estimatedetail.Select().Length == 0) return;
            foreach (DataRow rDetail in DS.estimatedetail.Select()) {
                if (rDetail.RowState != DataRowState.Modified) continue;

                DateTime originalDate = (rDetail["stop", DataRowVersion.Original] == DBNull.Value)
                    ? QueryCreator.EmptyDate() : (DateTime)rDetail["stop", DataRowVersion.Original];

                DateTime currentDate = (rDetail["stop", DataRowVersion.Current] == DBNull.Value)
                    ? QueryCreator.EmptyDate() : (DateTime)rDetail["stop", DataRowVersion.Current];

                int yearOriginalSTOP = originalDate.Year;
                int yearCurrentSTOP = currentDate.Year;

                if (yearOriginalSTOP == yearCurrentSTOP) continue;
                if ((rDetail["stop", DataRowVersion.Original] == DBNull.Value) &&
                    (rDetail["stop", DataRowVersion.Current] != DBNull.Value)) {
                    string filtroBrother = QHC.MCmp(rDetail,
                        new string[] { "idestimkind", "yestim", "nestim", "idgroup" });

                    foreach (DataRow rBrother in DS.estimatedetail.Select(filtroBrother)) {
                        object brtDate = rBrother["stop"];
                        if ((brtDate == null) || (brtDate == DBNull.Value)) {
                            if (viewMessage) {
                                MessageBox.Show(this, "E' stata impostata la data di annullamento di un dettaglio suddiviso," +
                                    "tutti gli altri dettagli che compongono il dettaglio originale verranno annullati",
                                    "Avviso", MessageBoxButtons.OK);
                                viewMessage = false;
                            }
                            rBrother["stop"] = currentDate;
                        }

                    }
                }
                if ((rDetail["stop", DataRowVersion.Original] != DBNull.Value) &&
                    (rDetail["stop", DataRowVersion.Current] == DBNull.Value)) {
                    string filtroBrother = QHC.MCmp(rDetail,
                        new string[] { "idestimkind", "yestim", "nestim", "idgroup" });

                    foreach (DataRow rBrother in DS.estimatedetail.Select(filtroBrother)) {
                        object brtDate = rBrother["stop"];
                        if ((brtDate != null) && (brtDate != DBNull.Value)) {
                            if (viewMessage) {
                                MessageBox.Show(this, "E' stata rimossa la data di annullamento di un dettaglio suddiviso," +
                                    "tutti gli altri dettagli che compongono il dettaglio originale verranno ripristinati",
                                    "Avviso", MessageBoxButtons.OK);
                                viewMessage = false;
                            }
                            rBrother["stop"] = DBNull.Value;
                        }

                    }
                }
            }
        }
        private void PropagaModificheAiFratelli(DataRow rEstimatedetailMod) {
            if (rEstimatedetailMod["stop"] != DBNull.Value) return;
            object RowNum = rEstimatedetailMod["rownum"];
            object idGroup = rEstimatedetailMod["idgroup"];
            // Elenco dei campi modificabili prima di questa modifica, e quindi da non propagare.
            // Tutti gli altri, invece, prima erano ReadOnly, invece ora sono editabili
            // e verranno propagati da noi sui fratelli.
            List<string> campi_da_non_copiare = new List<string>(
                new string[] {
                    "idestimkind", "yestim", "nestim", "rownum", "idgroup",
                    "amount", "taxable", "tax", "unabatable",
                    "idupb", "cupcode", "cigcode", "idsor1", "idsor2", "idsor3","idcostpartition",
                    "idinc_taxable", "idinc_iva" ,"idupb_iva","idepacc"
                });

            string filtroBrother = QHC.AppAnd(QHC.CmpNe("rownum", RowNum), QHC.CmpEq("idgroup", idGroup));
            foreach (DataRow rBrother in DS.estimatedetail.Select(filtroBrother)) {
                if (rBrother["stop"] != DBNull.Value) continue;
                double currnpackage = CfgFn.GetNoNullDouble(rBrother["number"]);
                double newnpackage = CfgFn.GetNoNullDouble(rEstimatedetailMod["number"]);
                double curridivakind = CfgFn.GetNoNullDouble(rBrother["idivakind"]);
                double newnidivakind = CfgFn.GetNoNullDouble(rEstimatedetailMod["idivakind"]);

                foreach (DataColumn C in DS.estimatedetail.Columns) {
                    if (campi_da_non_copiare.Contains(C.ColumnName))
                        continue;
                    rBrother[C.ColumnName] = rEstimatedetailMod[C.ColumnName];
                }
                //Solo se cambia la q.t‡, info che prima non era editabile, dobbiamo modificare l'iva, perchË cambia la base imponibile su cui applicare l'aliquota iva
                if ((currnpackage != newnpackage) || (curridivakind != newnidivakind)) {
                    rBrother["tax"] = CalcolaIvaIvaindetraibile(rBrother, newnpackage, "tax");
                }

            }
            GetData GD = new GetData();
            GD.InitClass(DS, Conn, "estimatedetail");
            GD.GetTemporaryValues(DS.estimatedetail);
        }

        private double CalcolaIvaIvaindetraibile(DataRow rBrotherSplitted, double newnpackage, string fieldname) {
            DataRow Curr = DS.estimate.Rows[0];
            double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(Curr["exchangerate"]));
            double aliquota =
                CfgFn.GetNoNullDouble(Meta.Conn.DO_READ_VALUE("ivakind",
                                                              QHS.CmpEq("idivakind", rBrotherSplitted["idivakind"]),
                                                              "rate"));
            double imponibile = CfgFn.GetNoNullDouble(rBrotherSplitted["taxable"]);
            double quantitaConfezioni = newnpackage;
            double sconto = CfgFn.GetNoNullDouble(rBrotherSplitted["discount"]);
            double imponibiletot = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto)));
            double imponibiletotEUR = CfgFn.RoundValuta((imponibile * quantitaConfezioni * (1 - sconto)*tassocambio));
            double ivaEUR = CfgFn.RoundValuta(imponibiletotEUR * aliquota);
            if (fieldname == "tax") {
                return ivaEUR;
            }
            return 0;
        }

        public void MetaData_BeforeFill() {
            if (DS.estimatedetail.ExtendedProperties["RigaModificata"] != null) {
                DataRow rEstimatedetailMod = DS.estimatedetail.ExtendedProperties["RigaModificata"] as DataRow;
                object NumRigaModificata = rEstimatedetailMod["rownum"];
                object idgroupbRigaModificata = rEstimatedetailMod["idgroup"];
                if (Meta.InsertMode || Meta.EditMode) {
                    PropagaModificheAiFratelli(rEstimatedetailMod);
                }
                DS.estimatedetail.ExtendedProperties["RigaModificata"] = null;
            }
        }
        public void MetaData_AfterFill() {
            if (EPM.esistonoScrittureCollegate()) Meta.CanCancel = false;
            EPM.mostraEtichette();
            Current = DS.estimate.Rows[0];
            CheckCig();
            if (txtcig.Text != "") {
                MetaData.SetDefault(DS.estimatedetail, "cigcode", txtcig.Text);
            }
            CalcolaImporto();
            ImpostaTxtValuta();
            txtEsercContratto.ReadOnly = true;
            if (Meta.InsertMode) {
                btnSituazione.Enabled = false;
            }
            else {
                btnSituazione.Enabled = true;
                // Metodo che annulla tutti i fratelli di un dettaglio ove lo stesso sia splittato.
                // Lo richiamo solo in EditMode, in InsertMode non ha davvero senso
                allineaFratelli();
            }

            DataRow rEstimKind = HelpForm.GetLastSelected(DS.estimatekind);

            object curridestimkind = (rEstimKind != null) ? rEstimKind["idestimkind"] : null;

            DataRow row_estimatekind = null;
            if (curridestimkind != null && curridestimkind.ToString() != "") {
                row_estimatekind = DS.estimatekind.Select(QHC.CmpEq("idestimkind", curridestimkind))[0];
            }

            if ((Meta.InsertMode) || (Meta.EditMode)) {
                if (DS.estimatedetail.Rows.Count == 0) {
                    object idupb_selected = (row_estimatekind == null ? DBNull.Value : row_estimatekind["idupb"]);
                    MetaData.SetDefault(DS.estimatedetail, "idupb", idupb_selected);
                }
                else {
                    int maxdetail = CfgFn.GetNoNullInt32(DS.estimatedetail.Compute("max(rownum)", null));
                    if (maxdetail > 0) {
                        DataRow row_estimatedetail = DS.estimatedetail.Select(QHC.CmpEq("rownum", maxdetail))[0];
                        if (row_estimatedetail != null && row_estimatedetail.RowState == DataRowState.Added) {
                            object idupb_selected = row_estimatedetail["idupb"];
                            MetaData.SetDefault(DS.estimatedetail, "idupb", idupb_selected);

                            object idSor1 = (row_estimatedetail["idsor1"] != DBNull.Value)
                                ? row_estimatedetail["idsor1"] : null;
                            if (idSor1 != null) {
                                MetaData.SetDefault(DS.estimatedetail, "idsor1", idSor1);
                            }

                            object idSor2 = (row_estimatedetail["idsor2"] != DBNull.Value)
                                ? row_estimatedetail["idsor2"] : null;
                            if (idSor2 != null) {
                                MetaData.SetDefault(DS.estimatedetail, "idsor2", idSor2);
                            }

                            object idSor3 = (row_estimatedetail["idsor3"] != DBNull.Value)
                                ? row_estimatedetail["idsor3"] : null;
                            if (idSor3 != null) {
                                MetaData.SetDefault(DS.estimatedetail, "idsor3", idSor3);
                            }
                        }
                    }

                }


                if (Meta.EditMode) {
                    EnableDisableRegistry();
                }

                string flagmultireg_selected = (row_estimatekind == null ? "" : row_estimatekind["multireg"].ToString());
                gboxCliente.Visible = flagmultireg_selected != "S";



                if (Meta.FirstFillForThisRow && Meta.InsertMode && cmbTipoContratto.SelectedIndex > 0) {
                    if (row_estimatekind != null) {
                        SetNumContratto(row_estimatekind);
                    }
                }

                if (Meta.InsertMode) {
                    if (cmbTipoContratto.SelectedIndex > 0) {

                        string tiponumerazione = "S";
                        if (row_estimatekind != null)
                            tiponumerazione = row_estimatekind["flag_autodocnumbering"].ToString().ToUpper();
                        if (tiponumerazione == "S") {
                            txtNumContratto.ReadOnly = true;
                            txtNumContratto.PasswordChar = ' ';
                        }
                        else {
                            txtNumContratto.ReadOnly = false;
                            txtNumContratto.PasswordChar = Convert.ToChar(0);
                        }
                    }
                    else {
                        txtNumContratto.ReadOnly = false;
                        txtNumContratto.PasswordChar = ' ';
                    }
                }
            }
        }

        void EnableDisableRegistry() {
            string idestimkind = Current["idestimkind"].ToString();
            string yestim = Current["yestim"].ToString();
            string nestim = Current["nestim"].ToString();
            string filter_invoice = QHC.AppAnd(QHC.CmpEq("idestimkind", Current["idestimkind"]),
                QHC.CmpEq("yestim", yestim), QHC.CmpEq("nestim", nestim));
            int LinkedDet = DS.invoicedetail.Select(filter_invoice).Length;
            if (LinkedDet == 0)
                txtCliente.ReadOnly = false;
            else
                txtCliente.ReadOnly = true;
        }

        void SetNumContratto(DataRow R) {
            string tiponumerazione = R["flag_autodocnumbering"].ToString();
            DataRow Curr = DS.estimate.Rows[0];
            if (tiponumerazione == "S") {
                RowChange.MarkAsAutoincrement(DS.estimate.Columns["nestim"], null, null, 6);
                MetaData.SetDefault(DS.estimate, "nestim", -10);
                txtNumContratto.ReadOnly = true;
                txtNumContratto.Text = "";
                int N = MetaData.MaxFromColumn(DS.estimate, "nestim");
                if (N < 99990000)
                    N = 99990000;
                else
                    N = N + 1;
                Curr["nestim"] = N;
                txtNumContratto.Text = N.ToString();
                txtNumContratto.PasswordChar = ' ';
                foreach (DataRow Dett in DS.estimatedetail.Rows) {
                    Dett["nestim"] = N;
                }
            }
            else {
                DataColumn C = DS.estimate.Columns["nestim"];
                RowChange.ClearAutoIncrement(C);
                RowChange.ClearCustomAutoIncrement(C);
                int nmax = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("estimate",
                    QHS.AppAnd(QHS.CmpEq("yestim", Meta.GetSys("esercizio")),
                    QHS.CmpEq("idestimkind", R["idestimkind"])), "MAX(nestim)")) + 1;
                MetaData.SetDefault(DS.estimate, "nestim", nmax);
                Curr["nestim"] = nmax;
                txtNumContratto.Text = nmax.ToString();
                txtNumContratto.ReadOnly = false;
                txtNumContratto.PasswordChar = Convert.ToChar(0);
                foreach (DataRow Dett in DS.estimatedetail.Rows) {
                    Dett["nestim"] = nmax;
                }
            }
        }

        private decimal RoundDecimal6(decimal valuta) {
            decimal truncated = Decimal.Truncate(valuta * 10000000);
            if (truncated > 0) {
                if ((truncated % 10) >= 5) truncated += 5;
            }
            else {
                if (((-truncated) % 10) >= 5) truncated -= 5;
            }
            truncated = truncated / 10;
            truncated = Decimal.Truncate(truncated);
            return truncated / 1000000;
        }

        private void CalcolaImporto() {
            decimal imponibile = 0;
            decimal imposta = 0;
            decimal totale = 0;
            decimal tassocambio = 1;
            try {
                tassocambio = Decimal.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
            }
            tassocambio = RoundDecimal6(tassocambio);
            int prevgroup = -1;
            decimal totimponibile_currgroup = 0;
            decimal lastexpr = 0;
            foreach (DataRow R in DS.estimatedetail.Select(null, "idgroup")) {
                //if (R.RowState== DataRowState.Deleted) continue;
                if (R["stop"] != DBNull.Value) continue;
                int currgroup = CfgFn.GetNoNullInt32(R["idgroup"]);
                if (currgroup != prevgroup) {
                    imponibile += lastexpr;
                    totimponibile_currgroup = 0;
                    prevgroup = currgroup;
                }
                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantita = CfgFn.GetNoNullDecimal(R["number"]);
                decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
                imposta += CfgFn.RoundValuta(R_imposta * tassocambio);
                totimponibile_currgroup += R_imponibile;
                lastexpr = CfgFn.RoundValuta((totimponibile_currgroup * R_quantita * (1 - R_sconto)) * tassocambio);
            }
            imponibile += lastexpr;
            totale = imponibile + imposta;
            decimal imponibileEUR = CfgFn.RoundValuta(imponibile);
            decimal impostaEUR = CfgFn.RoundValuta(imposta);
            decimal totaleEUR = CfgFn.RoundValuta(totale);
            txtImponibile.Text = HelpForm.StringValue(imponibileEUR, "x.y.fixed.5...1");
            txtIva.Text = HelpForm.StringValue(impostaEUR, "x.y.fixed.2...1");
            txtTotale.Text = HelpForm.StringValue(totaleEUR, "x.y.fixed.2...1");
        }

        public void MetaData_AfterClear() {
            Meta.CanCancel = true;
            txtCambio.ReadOnly = false;
            txtEsercContratto.Text = Meta.GetSys("esercizio").ToString();
            MetaData.SetDefault(DS.estimatedetail, "cigcode", DBNull.Value);
            MetaData.SetDefault(DS.estimatedetail, "idivakind", DBNull.Value);
            MetaData.SetDefault(DS.estimatedetail, "taxrate", DBNull.Value);
            txtEsercContratto.ReadOnly = false;
            txtCliente.ReadOnly = false;
            gboxCliente.Visible = true;
            btnSituazione.Enabled = false;
            EPM.mostraEtichette();
            DataColumn C = DS.estimate.Columns["nestim"];
            RowChange.ClearAutoIncrement(C);
            RowChange.ClearCustomAutoIncrement(C);
            txtNumContratto.ReadOnly = false;
            txtNumContratto.PasswordChar = Convert.ToChar(0);
            txtcig.ReadOnly = false;
        }

        //Imposta Txt in base a valore in riga corrente
        void ImpostaTxtValuta() {
            if (Meta.IsEmpty) return;
            object codicevaluta = DS.estimate.Rows[0]["idcurrency"];
            if (codicevaluta == DBNull.Value) {
                ImpostaTxtValuta(null);
            }
            else {
                if (DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta)).Length == 0) {
                    QueryCreator.ShowError(this, "Il cliente Ë associato ad una valuta non valida.", null);
                }
                else {
                    DataRow CurrValuta = DS.currency.Select(QHC.CmpEq("idcurrency", codicevaluta))[0];
                    ImpostaTxtValuta(CurrValuta);
                }
            }
        }

        void SetChildParameter(DataRow ValutaRow) {
            if (Meta.IsEmpty) return;
            if (ValutaRow == null) {
                DS.estimatedetail.ExtendedProperties[MetaData.ExtraParams] = null;
                return;
            }
            Hashtable Params = new Hashtable();
            Params["nomevaluta"] = ValutaRow["description"];
            Params["codicevaluta"] = ValutaRow["idcurrency"];
            try {
                Params["cambio"] = Double.Parse(txtCambio.Text,
                    System.Globalization.NumberStyles.Number);
            }
            catch {
                Params["cambio"] = 0;
            }

            object curr_idman = Current["idman"];
            if (curr_idman != DBNull.Value)
                Params["codiceresponsabile"] = curr_idman;
            else
                Params["codiceresponsabile"] = DBNull.Value;

            DS.estimatedetail.ExtendedProperties[MetaData.ExtraParams] = Params;

        }

        void SetValuta(object idcurrency) {
            if (idcurrency == DBNull.Value) {
                Meta.myHelpForm.ClearControls(gboxValuta.Controls);
                if (Meta.IsEmpty) return;
                DS.estimate.Rows[0]["idcurrency"] = DBNull.Value;
                return;
            }

            if (DS.currency.Select(QHC.CmpEq("idcurrency", idcurrency)).Length == 0) {
                DS.currency.Clear();
                Conn.RUN_SELECT_INTO_TABLE(DS.currency, null, QHS.CmpEq("idcurrency", idcurrency), null, false);
            }
            if (DS.currency.Select(QHC.CmpEq("idcurrency", idcurrency)).Length == 0) return; //Errore nei dati
            Meta.myHelpForm.FillSpecificRowControls(gboxValuta.Controls, DS.currency, DS.currency.Rows[0]);
            if (Meta.IsEmpty) return;
            DS.estimate.Rows[0]["idcurrency"] = DS.currency.Rows[0]["idcurrency"];
        }


        void ImpostaTxtValuta(DataRow ValutaRow) {
            if (ValutaRow == null) {
                txtCambio.ReadOnly = false;
                SetValuta(DBNull.Value);
                SetChildParameter(null);
                return;
            }

            if (
                (ValutaRow["codecurrency"].ToString().ToUpper() == "EUR")
                ) {
                double tasso = 1;
                txtCambio.Text = HelpForm.StringValue(tasso, txtCambio.Tag.ToString()); //tasso.ToString("n");
            }
            else {
                txtCambio.ReadOnly = false;
            }
            txtCambio.ReadOnly = false;
            SetValuta(ValutaRow["idcurrency"]);
            SetChildParameter(ValutaRow);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone) return;

            if (T.TableName == "currency") {
                ImpostaTxtValuta(R);
                return;
            }
            if (T.TableName == "estimatekind") {
                if (Meta.InsertMode) {
                    impostaSicurezza(R);
                    object idupb_selected = (R == null ? DBNull.Value : R["idupb"]);
                    MetaData.SetDefault(DS.estimatedetail, "idupb", idupb_selected);
                    //aggiorno il codice tipo contratto. dei dettagli
                    object codicetipodoc = (R == null ? DBNull.Value : R["idestimkind"]);
                    DataRow Curr = DS.estimate.Rows[0];
                    Curr["idestimkind"] = codicetipodoc;
                    foreach (DataRow Dett in DS.estimatedetail.Rows) {
                        if (!Dett["idestimkind"].Equals(codicetipodoc))
                            Dett["idestimkind"] = codicetipodoc;
                    }
                    if (R != null) {
                        SetNumContratto(R);
                    }


                    object idivakind_forced = (R == null ? "" : R["idivakind_forced"]);
                    MetaData.SetDefault(DS.estimatedetail, "idivakind", idivakind_forced);

                    if (idivakind_forced != DBNull.Value) {

                        DataTable tivakind = Conn.RUN_SELECT("ivakind", "*", null,
                                                               QHC.CmpEq("idivakind", idivakind_forced), null, null, true);

                        if (tivakind.Rows.Count > 0) {
                            DataRow RIvaKind = tivakind.Rows[0];
                            object taxrate_forced = RIvaKind["rate"];

                            MetaData.SetDefault(DS.estimatedetail, "taxrate", taxrate_forced);

                        }
                    }
                    else {
                        MetaData.SetDefault(DS.estimatedetail, "idivakind", DBNull.Value);
                        MetaData.SetDefault(DS.estimatedetail, "taxrate", DBNull.Value);
                    }
                }

            }

            if (T.TableName == "estimatekind") {
                if (!Meta.DrawStateIsDone) return;
                if (R == null) return;

                if (R["multireg"] == DBNull.Value) return;
                string multiReg = R["multireg"].ToString();
                if (multiReg == "S") {
                    if (DS.estimate.Rows.Count > 0) {
                        DataRow CurrRow = DS.estimate.Rows[0];
                        Meta.SetAutoField(DBNull.Value, txtCliente);
                    }
                    gboxCliente.Visible = false;
                }
                else {
                    gboxCliente.Visible = true;
                }

                if (Meta.IsEmpty) return;

                if (R["idupb"] == DBNull.Value) return;
                object idman = Conn.DO_READ_VALUE("upb", QHS.CmpEq("idupb", R["idupb"]), "idman");
                if (idman != null && idman != DBNull.Value) {
                    object getman = Meta.GetAutoField(txtResponsabile);
                    if (getman != DBNull.Value) {
                        if (getman.ToString() != idman.ToString())
                            MessageBox.Show("Il responsabile del Contratto Ë stato reimpostato come da U.P.B.");
                    }
                    Meta.SetAutoField(idman, txtResponsabile);
                }
                if (R != null) {
                    if (R["linktoinvoice"].ToString() == "S") {
                        MetaData.SetDefault(DS.estimatedetail, "epkind", "F");
                    }
                    else {
                        MetaData.SetDefault(DS.estimatedetail, "epkind", "N");
                    }

                }
                return;
            }

            if (T.TableName == "registrymainview") {
                ImpostaCredDeb(R);

                if (R!=null && !Meta.IsEmpty) {
                    DataRow Curr = DS.estimate.Rows[0];
                    Curr["idaccmotivecredit"] = R["idaccmotivecredit"];
                    DS.accmotiveapplied_credit.Clear();
                    Conn.RUN_SELECT_INTO_TABLE(DS.accmotiveapplied_credit,null,
                        (q.eq("idaccmotive", Curr["idaccmotivecredit"]) & q.eq("idepoperation", "fatven_cred")).toSql(QHS),null,false);
                    Meta.helpForm.FillControls(gBoxCausaleCredito.Controls);
                }


            }

            return;
        }
        object GetResponsabile() {
            return Meta.GetAutoField(txtResponsabile);
        }

        void SetResponsabile(object idman) {
            Meta.SetAutoField(idman, txtResponsabile);
        }



        void ImpostaCredDeb(DataRow R) {
            if (R == null) return;
            if (Meta.IsEmpty) return;

            DataRow DefModPag = CfgFn.ModalitaPagamentoDefault(Meta.Conn, R["idreg"]);
            object idcurrency = Meta.Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency");
            if (DefModPag != null) {
                txtScadenza.Text = DefModPag["paymentexpiring"].ToString();
                HelpForm.SetComboBoxValue(cmbTipoScadenza, DefModPag["idexpirationkind"]);
                DS.estimate.Rows[0]["idcurrency"] = (DefModPag["idcurrency"] != DBNull.Value)
                        ? DefModPag["idcurrency"] : idcurrency;
                ImpostaTxtValuta();
            }

        }


        private void btnSituazione_Click(object sender, System.EventArgs e) {
            /*DataAccess Conn = Meta.Conn;
			int esercContratto;
			int numContratto;
			string idestimkind;
			try{
				esercContratto=Convert.ToInt16(DS.Tables["estimate"].Rows[0]["yestim"]);
				numContratto=Convert.ToInt16(DS.Tables["estimate"].Rows[0]["nestim"]);
				idestimkind=(DS.Tables["estimate"].Rows[0]["idestimkind"]).ToString();
			}
			catch{
				return;
			}
			DataSet Out = Conn.CallSP("show_estimate",
				new Object[5] {Meta.GetSys("datacontabile"),
								  idestimkind,
								  esercContratto,
								  numContratto,
								  Meta.GetSys("esercizio")
							  }
				);
			if (Out==null) return;
			Out.Tables[0].TableName="Situazione Contratto";

			frmSituazioneViewer frm = new frmSituazioneViewer(Out);
			frm.Show();*/

        }

        private void btnElimina_Click(object sender, System.EventArgs e) {


        }

        private void txtCambio_TextChanged(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            if (Meta.DrawStateIsDone) CalcolaImporto();
        }

        private DataRow GetGridSelectedRows(DataGrid G) {
            DataSet DSV = (DataSet)G.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try {
                DV = (DataRowView)G.BindingContext[DSV, TV.TableName].Current;
            }
            catch {
                DV = null;
            }
            if (DV == null) return null;

            DataRow R = DV.Row;
            return R;
        }

        private void btnDividiDettaglio_Click(object sender, System.EventArgs e) {
            if (DS.estimate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(detailgrid);
            if (RigaSelezionata == null) return;
            if (RigaSelezionata["stop"] != DBNull.Value) {
                MessageBox.Show("Dettaglio annullato", "Avviso");
                return;
            }
            if ((RigaSelezionata["idinc_taxable"] != DBNull.Value) && (RigaSelezionata["idinc_iva"] != DBNull.Value)) {
                MessageBox.Show("Dettaglio contabilizzato", "Avviso");
                return;
            }
            DataRow Preventivo = DS.estimate.Rows[0];
            decimal totaleImponibile = CfgFn.GetNoNullDecimal(RigaSelezionata["taxable"]);
            decimal totaleIva = CfgFn.GetNoNullDecimal(RigaSelezionata["tax"]);
            frmAskInfo F = new frmAskInfo(RigaSelezionata, Meta, Meta.Dispatcher);
            if (F.ShowDialog(this) != DialogResult.OK) return;
            DataTable Info = F.Info;
            F.Destroy();
            string filter = QHC.AppOr(QHC.CmpNe("taxable", 0), QHC.CmpNe("tax", 0));
            DataRow[] RigheSplittate = Info.Select(filter);
            if (RigheSplittate.Length > 0) {
                RigaSelezionata["idupb"] = RigheSplittate[0]["idupb"];
                RigaSelezionata["taxable"] = RigheSplittate[0]["taxable"];
                RigaSelezionata["tax"] = RigheSplittate[0]["tax"];
                // Ciclo per la creazione di nuovi dettagli
                Meta.GetFormData(false);
                MetaData metaDT = MetaData.GetMetaData(this, "estimatedetail");
                metaDT.SetDefaults(DS.estimatedetail);
                if (RigheSplittate.Length > 1) {
                    for (int i = 1; i <= (RigheSplittate.Length - 1); i++) {
                        DataRow rInfo = RigheSplittate[i];
                        DataRow rDT = metaDT.Get_New_Row(Preventivo, DS.estimatedetail);
                        rDT["idgroup"] = RigaSelezionata["idgroup"];
                        rDT["taxable"] = rInfo["taxable"];
                        rDT["tax"] = rInfo["tax"];
                        rDT["idupb"] = rInfo["idupb"];
                        rDT["idupb_iva"] = RigaSelezionata["idupb_iva"];
                        rDT["idlist"] = RigaSelezionata["idlist"];
                        rDT["idreg"] = RigaSelezionata["idreg"];
                        rDT["number"] = CfgFn.GetNoNullDecimal(RigaSelezionata["number"]); ;
                        rDT["detaildescription"] = RigaSelezionata["detaildescription"].ToString();
                        rDT["start"] = RigaSelezionata["start"];
                        rDT["epkind"] = RigaSelezionata["epkind"];
                        rDT["stop"] = RigaSelezionata["stop"];
                        rDT["idinc_taxable"] = RigaSelezionata["idinc_taxable"];
                        rDT["idinc_iva"] = RigaSelezionata["idinc_iva"];
                        rDT["idivakind"] = RigaSelezionata["idivakind"];
                        rDT["annotations"] = RigaSelezionata["annotations"];
                        rDT["discount"] = RigaSelezionata["discount"];
                        rDT["taxrate"] = RigaSelezionata["taxrate"];
                        rDT["idaccmotive"] = RigaSelezionata["idaccmotive"];
                        rDT["idsor1"] = RigaSelezionata["idsor1"];
                        rDT["idsor2"] = RigaSelezionata["idsor2"];
                        rDT["idsor3"] = RigaSelezionata["idsor3"];
                        rDT["competencystart"] = RigaSelezionata["competencystart"];
                        rDT["competencystop"] = RigaSelezionata["competencystop"];
                        rDT["cigcode"] = RigaSelezionata["cigcode"];
                        //rDT["idepacc"] = RigaSelezionata["idepacc"];
                        rDT["idsor_siope"] = RigaSelezionata["idsor_siope"];
                    }
                }
                Meta.FreshForm();
            }

        }




        object[] ValoriDiversi(DataRow[] Rows, string field) {
            object[] DIV = new object[Rows.Length];
            int N = 0;
            foreach (DataRow R in Rows) {
                object currval = R[field];
                int j = 0;
                for (j = 0; j < N; j++) {
                    if (DIV[j].Equals(currval)) {
                        break;
                    }
                }
                if (j == N) {
                    DIV[N++] = currval;
                }
            }
            object[] result = new object[N];
            for (int i = 0; i < N; i++) result[i] = DIV[i];
            return result;
        }

        private void btnUnisciDettagli_Click(object sender, EventArgs e) {
            if (DS.estimate.Rows.Count == 0) return;
            DataRow RigaSelezionata = GetGridSelectedRows(detailgrid);
            if (RigaSelezionata == null) return;
            string filtergroup = QHC.CmpEq("idgroup", RigaSelezionata["idgroup"]);
            DataRow[] Selected = DS.estimatedetail.Select(filtergroup, "rownum");
            decimal detailsGroup = Selected.Length;

            if (detailsGroup > 1) {
                decimal taxable = 0;
                decimal tax = 0;

                object[] upb = ValoriDiversi(Selected, "idupb");
                object[] idinc_taxable = ValoriDiversi(Selected, "idinc_taxable");
                object[] idinc_iva = ValoriDiversi(Selected, "idinc_iva");
                object idupb = DBNull.Value;
                if (upb.Length == 1) {
                    idupb = upb[0];
                }
                // Ciclo per verificare se Ë possibile riunire i dettagli splittati
                foreach (DataRow DR in Selected) {

                    decimal ninvoiced = CfgFn.GetNoNullDecimal(DR["ninvoiced"]);
                    if (ninvoiced > 0) {
                        MessageBox.Show("Alcuni dettagli dello stesso gruppo sono collegati a fattura. Non Ë possibile annullare la suddivisione.", "Avviso");
                        return;
                    }
                    if ((idinc_taxable.Length > 1) || (idinc_iva.Length > 1)) {
                        MessageBox.Show("Alcuni dettagli dello stesso gruppo sono contabilizzati. Non Ë possibile annullare la suddivisione.", "Avviso");
                        return;
                    }
                    //Ricalcolo imponibile unitario, iva e iva indetraibile come somma dei dettagli splittati
                    taxable += CfgFn.GetNoNullDecimal(DR["taxable"]);
                    tax += CfgFn.GetNoNullDecimal(DR["tax"]);
                }
                // Cancello i dettagli del contratto attivo, ad eccezione del primo del gruppo
                DataRow Original = Selected[0];
                int rownum = CfgFn.GetNoNullInt32(Original["rownum"]);
                string filterToDel = QHS.CmpGt("rownum", Original["rownum"]);
                filterToDel = GetData.MergeFilters(filtergroup, filterToDel);
                DataRow[] RowToDel = DS.estimatedetail.Select(filterToDel);
                foreach (DataRow DR in RowToDel) {
                    DR.Delete();
                }
                Original["idupb"] = idupb;
                Original["taxable"] = taxable;
                Original["tax"] = tax;
                Meta.FreshForm();
            }
        }

        class RowPair {
            public DataRow addedRow;
            public DataRow modifiedRow;
            public RowPair(DataRow oldRow, DataRow newRow) {
                addedRow = oldRow.RowState == DataRowState.Added ? oldRow : newRow;
                modifiedRow = oldRow.RowState == DataRowState.Modified ? oldRow : newRow;
                if (addedRow == null || modifiedRow == null) {
                    throw new Exception("Erroneo uso della classe RowPair");
                }
            }
            public void SwapValues() {
                DataTable T = modifiedRow.Table;
                foreach (DataColumn c in T.Columns) {
                    string field = c.ColumnName;
                    if (QueryCreator.IsPrimaryKey(T, field)) continue; //non scambia la chiave
                    if (field == "idgroup") continue;
                    if (field == "idepexp") continue;
                    if (field == "idepacc") continue;
                    object O = modifiedRow[field];
                    modifiedRow[field] = addedRow[field];
                    addedRow[field] = O;
                }
            }
        }
        private void btnSostituisciDettaglio_Click(object sender, EventArgs e) {
            if (DS.estimate.Rows.Count == 0) return;
            Meta.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                MessageBox.Show(this, "Prima di sostituire il dettaglio bisogna salvare!");
                return;
            }

            DataRow rContratto = DS.estimate.Rows[0];

            // Passo 1. - Scelta del dettaglio da sostituire
            WizSostituisciDettaglio wiz = new WizSostituisciDettaglio(rContratto, Meta.Conn,
                Meta.Dispatcher);

            DialogResult dr = wiz.ShowDialog();
            if (dr != DialogResult.OK) {
                MessageBox.Show(this, "Operazione annullata!");
                return;
            }

            // Passo 2. - Annullamento di tutti i fratelli del dettaglio annullato
            DataRow rDettaglioAnnullato = wiz.rOldDettaglio;
            string filter = QHC.MCmp(rDettaglioAnnullato, new string[] { "idestimkind", "yestim", "nestim", "idgroup" });

            object dataAnnullamento = HelpForm.GetObjectFromString(typeof(DateTime), wiz.txtStop.Text, "x.y");
            foreach (DataRow rDetail in DS.estimatedetail.Select(filter)) {
                rDetail["stop"] = dataAnnullamento;
                if (rDetail["stop"].ToString() != "") { rDetail["toinvoice"] = "N"; } //TASK 10671 
            }

            var Coppie = new List<RowPair>();
            // Passo 3. - Creazione nuovo dettaglio gi‡ splittato
            int idGroup = creaDettagliSplittati(rContratto, wiz, Coppie);

            // Passo 4. - Raffinamento dello split (usando il form dello split gi‡ esistente)
            DataRow[] listaDettagliSplittati = DS.estimatedetail.Select(QHC.CmpEq("idgroup", idGroup), "rownum");
            if ((listaDettagliSplittati.Length > 1) && (listaDettagliSplittati.Length <= 10)) {
                var frm = new frmAskInfo(listaDettagliSplittati, Meta, Meta.Dispatcher);
                var dr2 = frm.ShowDialog();
                if (dr2 != DialogResult.OK) {
                    MessageBox.Show(this, "Operazione di split annullata");
                    return;
                }
                else {
                    DataTable Info = frm.Info;
                    for (int i = 0; i < Info.Rows.Count; i++) {
                        listaDettagliSplittati[i]["taxable"] = Info.Rows[i]["taxable"];
                        listaDettagliSplittati[i]["tax"] = Info.Rows[i]["tax"];
                    }
                }
            }
            foreach (RowPair rp in Coppie) {
                rp.SwapValues();
                if (CfgFn.GetNoNullDecimal(rp.addedRow["taxable"]) == 0 &&
                    CfgFn.GetNoNullDecimal(rp.addedRow["tax"]) == 0) {
                    rp.addedRow.Delete();
                }
            }
            Meta.FreshForm();
        }

        private int creaDettagliSplittati(DataRow rContratto, WizSostituisciDettaglio wiz, List<RowPair> coppie) {
            var rDettaglioAnnullato = wiz.rOldDettaglio;
            string filter = QHC.MCmp(rDettaglioAnnullato, new string[] { "idestimkind", "yestim", "nestim", "idgroup" });

            object dataInizio = HelpForm.GetObjectFromString(typeof(DateTime), wiz.txtStart.Text, "x.y");
            string descrDettaglio = wiz.txtNewDescrizione.Text;
            object idIvaKind = (wiz.cmbNewTipoIva.SelectedValue == null)
                ? DBNull.Value : wiz.cmbNewTipoIva.SelectedValue;
            object aliquotaIVA = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewAliquota.Text,
                "x.y.fixed.4..%.100");
            object sconto = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewSconto.Text,
                "x.y.fixed.4..%.100");
            object quantita = HelpForm.GetObjectFromString(typeof(double), wiz.txtNewQuantita.Text,
                "x.y");

            double ivaNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewIvaValuta.Text, "x.y"));
            double importoNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewImportoUnitario.Text, "x.y"));
            double imponibileNew = CfgFn.GetNoNullDouble(HelpForm.GetObjectFromString(typeof(double),
                wiz.txtNewImponibileValuta.Text, "x.y"));

            bool ultimoCiclo = false;
            int lastLoop = DS.estimatedetail.Select(filter).Length;
            int currLoop = 1;

            double progIva = 0;
            double progImponibile = 0;

            int idGroup = 1 + CfgFn.GetNoNullInt32(DS.estimatedetail.Compute("MAX(idgroup)", null));
            double totImponibileDettagli = CfgFn.GetNoNullDouble(
                DS.estimatedetail.Compute("SUM(taxable)", filter));

            MetaData MetaDetail = MetaData.GetMetaData(this, "estimatedetail");

            foreach (DataRow rDetail in DS.estimatedetail.Select(filter)) {
                if (currLoop == lastLoop) ultimoCiclo = true;
                MetaDetail.SetDefaults(DS.estimatedetail);
                DataRow rNew = MetaDetail.Get_New_Row(rContratto, DS.estimatedetail);
                rNew["idgroup"] = idGroup;
                string[] listField = new string[] {"annotations", "competencystart", "competencystop","epkind",
                    "idupb", "ninvoiced", "idaccmotive", "idreg", "idinc_taxable", "idinc_iva","cigcode", "toinvoice",  
                    "idsor1", "idsor2", "idsor3", "idaccmotiveannulment","idepacc","idupb_iva","idlist","idsor_siope"};

                foreach (string colName in listField) {
                    rNew[colName] = rDetail[colName];
                }
                rNew["detaildescription"] = descrDettaglio;
                rNew["start"] = dataInizio;
                rNew["idivakind"] = idIvaKind;
                rNew["taxrate"] = aliquotaIVA;
                rNew["discount"] = sconto;
                rNew["number"] = quantita;

                double ivaSplitted = 0;
                double imponibileSplitted = 0;

                double ivaDettaglio = CfgFn.GetNoNullDouble(rDetail["tax"]);
                double imponibileDettaglio = CfgFn.GetNoNullDouble(rDetail["taxable"]);

                if (ultimoCiclo) {
                    // Tappo
                    ivaSplitted = ivaNew - progIva;
                    imponibileSplitted = importoNew - progImponibile;
                }
                else {
                    // Proporzione
                    double prop = imponibileDettaglio / totImponibileDettagli;
                    ivaSplitted = ivaNew * prop;
                    imponibileSplitted = importoNew * prop;

                    progIva += CfgFn.Round(ivaSplitted, 2);
                    progImponibile += CfgFn.Round(imponibileSplitted, 5);
                }

                rNew["tax"] = CfgFn.Round(ivaSplitted, 2);
                rNew["taxable"] = CfgFn.Round(imponibileSplitted, 5);
                coppie.Add(new RowPair(rDetail, rNew));
                currLoop++;
            }

            return idGroup;
        }

        private void btnInserisciCopia_Click(object sender, EventArgs e) {
            if (DS.estimate.Rows.Count == 0) return;
            DataRow RC = GetGridSelectedRows(detailgrid);
            if (RC == null) return;


            DataRow ContrattoAttivo = DS.estimate.Rows[0];

            Meta.GetFormData(false);
            MetaData metaDT = MetaData.GetMetaData(this, "estimatedetail");
            metaDT.SetDefaults(DS.estimatedetail);
            DataRow rDT = metaDT.Get_New_Row(ContrattoAttivo, DS.estimatedetail);

            foreach (string field in new string[] {
                "detaildescription", "number", "idivakind", "taxrate", "tax", "taxable", "discount", "idupb", "idupb_iva","idlist",
                "toinvoice", "idsor1", "idsor2", "idsor3","competencystart", "competencystop","cigcode",
                "idaccmotive","idaccmotiveannulment", "idreg", "epkind"
            }) {
                rDT[field] = RC[field];
            }

            DataRow OR;
            if (Meta.EditDataRow(rDT, "single", out OR)) {
                Meta.FreshForm(true);
            }
        }

        private void btnRipartizione_Click(object sender, EventArgs e) {
            if (DS.estimate.Rows.Count == 0) return;
            DataRow RC = GetGridSelectedRows(detailgrid);
            if (RC == null) return;

            object idrevenuepartition = RC["idrevenuepartition"];

            if (idrevenuepartition != DBNull.Value) {
                MetaData ToMeta = Meta.Dispatcher.Get("revenuepartition");
                string checkfilter = QHS.CmpEq("idrevenuepartition", idrevenuepartition);
                ToMeta.ContextFilter = checkfilter;
                Form F = null;
                if (Meta.linkedForm != null) F = Meta.linkedForm.ParentForm;
                bool result = ToMeta.Edit(F, "default", false);

                string listtype = ToMeta.DefaultListType;
                DataRow R = ToMeta.SelectOne(listtype, checkfilter, null, null);
                if (R != null) ToMeta.SelectRow(R, listtype);
            }
            else {
                idrevenuepartition = EP_functions.importRevenuePartitionDetail(Meta);
                if (idrevenuepartition == null) return;
                RC["idrevenuepartition"] = idrevenuepartition;

            }

        }

        object getMinCig() {
            object mincig = DBNull.Value;
            foreach (DataRow r in DS.estimatedetail.Select(QHC.IsNotNull("cigcode"))) {
                if (mincig == DBNull.Value) {
                    mincig = r["cigcode"];
                    continue;
                }
                if (mincig.ToString().CompareTo(r["cigcode"].ToString()) > 0) {
                    mincig = r["cigcode"];
                }
            }
            return mincig;
        }
        void CheckCig() {
            if (DS.estimatedetail.Select(QHC.IsNotNull("cigcode")).Length == 0) {
                txtcig.ReadOnly = false;
                return;
            }
            if (DS.estimatedetail.Select().Length == 0) {
                txtcig.ReadOnly = false;
                return;
            }
            Current = DS.estimate.Rows[0];
            object maincig = Current["cigcode"];
            if (maincig != DBNull.Value && DS.estimatedetail.Select(QHC.CmpEq("cigcode", maincig)).Length > 0) {
                txtcig.ReadOnly = true;
                return;
            }
            Current["cigcode"] = getMinCig();
            txtcig.Text = Current["cigcode"].ToString();
            txtcig.ReadOnly = true;


        }
    }
}