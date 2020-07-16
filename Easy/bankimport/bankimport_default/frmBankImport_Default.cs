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
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using bankdispositionsetup_importnew;
using System.Collections;
using System.ServiceModel.Description;
using ep_functions;
using q = metadatalibrary.MetaExpression;

namespace bankimport_default {
    public partial class frmBankImport_Default :Form {
        MetaData Meta;

        public frmBankImport_Default() {
            InitializeComponent();
        }

        //DataAccess Conn;
        QueryHelper QHS;

        CQueryHelper QHC;
        //ImportazioneEsitiBancari import=null;

        DataTable Tbankimportbill;
        DataTable Tbanktransaction;
        DataTable Tbilltransaction;
        MetaData metaDMB, metaImpBill, metaBillTrans;

        /// <summary>
        /// Lunghezza sul db del campo beneficiario (registry di bill)
        /// </summary>
        int lenBeneficiario;

        /// <summary>
        /// Lunghezza sul db del campo causale (motive di bill)
        /// </summary>
        int lenCausale;

        private EP_Manager epm;
        private IFormController controller;
        private IMetaModel model;
        private ISecurity security;
        private IDataAccess conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            //Conn = MetaData.GetConnection(this);

            QHC = new CQueryHelper();
            controller = this.getInstance<IFormController>();
            model = MetaFactory.factory.getSingleton<IMetaModel>();
            security = this.getInstance<ISecurity>();
            conn = this.getInstance<IDataAccess>();
            QHS = conn.GetQueryHelper();

            lenBeneficiario =
                (int)conn.readValue("columntypes", q.eq("tablename", "bill") & q.eq("field", "registry"), "col_len");
            lenCausale = (int)conn.readValue("columntypes", q.eq("tablename", "bill") & q.eq("field", "motive"), "col_len");

            metaDMB = MetaData.GetMetaData(this, "banktransaction");
            Tbanktransaction = DS.Tables["banktransaction"];
            metaDMB.SetDefaults(Tbanktransaction);

            metaBillTrans = MetaData.GetMetaData(this, "billtransaction");
            Tbilltransaction = DS.Tables["billtransaction"];
            metaBillTrans.SetDefaults(Tbilltransaction);

            metaImpBill = MetaData.GetMetaData(this, "bankimportbill");
            Tbankimportbill = DS.Tables["bankimportbill"];
            metaImpBill.SetDefaults(Tbankimportbill);
            model.MarkTableAsNotEntityChild(DS.bankimport, Tbankimportbill);

            model.setStaticFilter(DS.bankimport, Meta.QHS.CmpEq("ayear", security.GetEsercizio()));
            epm = new EP_Manager(Meta, null, null, null, null, btnGeneraEP, btnVisualizzaEP, labEP, null, "bankimport");
            AbilitaDisabilitaSiopePlus();
        }

        private bool siopePlusAbilitato = false;
        private bool siopePlusWebServiceAbilitato = false;

        public void AbilitaDisabilitaSiopePlus() {
            DataTable opisiopeplus_config = conn.readTable("opisiopeplus_config", q.eq("code", "opi_siopeplus"));
            if (opisiopeplus_config == null || opisiopeplus_config.Rows.Count == 0) {
                btnImportManualeSiope.Enabled = false;
                btnImportaDaSiope.Enabled = false;
                txtDataFineSiope.ReadOnly = true;
                txtDataInizioSiope.ReadOnly = true;
                return;
            }

            DataRow R = opisiopeplus_config.Rows[0];
            string usewebservice = R["usewebservice"].ToString().ToUpperInvariant();
            string usesiopeplus = R["usesiopeplus"].ToString().ToUpperInvariant();
            btnImportaDaSiope.Enabled =  (usewebservice == "S");
            txtDataFineSiope.ReadOnly = (usewebservice == "N");
            txtDataInizioSiope.ReadOnly = (usewebservice == "N");
            btnImportManualeSiope.Enabled = (usesiopeplus == "S");
            siopePlusWebServiceAbilitato = (usewebservice == "S");
            siopePlusAbilitato = (usesiopeplus == "S");
        }



        void calcolaLastImport() {

            object ultimaEsitazioneDB = conn.readValue("banktransaction", q.eq("yban", security.GetEsercizio()), "max(transactiondate)");
            //Meta.Conn.DO_READ_VALUE("banktransaction","(yban = '" + security.GetEsercizio()+ "')", "max(transactiondate)");
            if (ultimaEsitazioneDB == DBNull.Value) {
                ultimaEsitazioneDB = conn.readValue("banktransaction", q.eq("yban", security.GetEsercizio() - 1), "max(transactiondate)");
                //Meta.Conn.DO_READ_VALUE("banktransaction","(yban = '" + (CfgFn.GetNoNullInt32(security.GetEsercizio()) - 1) + "' )", "max(transactiondate)");
            }

            if (ultimaEsitazioneDB is DateTime) {
                txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
            }
        }


        public void MetaData_AfterClear() {
            epm.mostraEtichette();
            ClearGrids();
            txtFile.Text = "";
            gboxBanca.Enabled = true;
            btnApriFile.Visible = false;
            lblUltimoIncasso.Visible = true;
            lblUltimoPagamento.Visible = true;
            lblUltimoSospesoEntrata.Visible = true;
            lblUltimoSospesoUscita.Visible = true;
            txtUltimoIncasso.Visible = true;
            txtUltimoPagamento.Visible = true;
            txtUltimoSospesoEntrata.Visible = true;
            txtUltimoSospesoUscita.Visible = true;
            txtDataInizioSiope.Text = "";
            txtDataFineSiope.Text = "";
            btnImportManualeSiope.Enabled = false;
            btnImportaDaSiope.Enabled = siopePlusWebServiceAbilitato;
            txtidentificativo_flusso_bt.ReadOnly = false;

        }

        /*
        public RigaDocumento(int y, int ndoc, decimal amount, DateTime data_operazione, object data_valuta,
                        string anagrafica, string causale, object nbolletta,int progressivo)
        
        public Provvisorio(int annobolletta, int numbolletta, decimal amount, string causale, string anagrafica,
                    DateTime dataoperazione, object numeroconto)
        */

        public DatiImportati RicavaDatiImportatiDaDataSet() {
            DataRow curr = DS.bankimport.Rows[0];
            object idbankimport = curr["idbankimport"];
            DatiImportati I = new DatiImportati(conn.Security.GetEsercizio());
            DataTable btranview = conn.readTable("banktransactionview", q.eq("idbankimport", idbankimport), order_by: "npay asc,npro asc,registry asc");
            foreach (DataRow r in btranview.Rows) {
                bool mandato = (r["kind"].ToString() == "D");
                decimal amount = CfgFn.GetNoNullDecimal(r["amount"]);
                object opdate = r["transactiondate"];
                object valdate = r["valuedate"];
                string reg = r["registry"].ToString();
                string motive = r["motive"].ToString();
                object nbill = r["nbill"];
                if (mandato) {
                    int ydoc = CfgFn.GetNoNullInt32(r["ypay"]);
                    int ndoc = CfgFn.GetNoNullInt32(r["npay"]);
                    int nprog = CfgFn.GetNoNullInt32(r["idpay"]);
                    I.Mandati.Add(new RigaMandato(ydoc, ndoc, amount, opdate, valdate, reg, motive, nbill, nprog));
                }
                else {
                    int ydoc = CfgFn.GetNoNullInt32(r["ypro"]);
                    int ndoc = CfgFn.GetNoNullInt32(r["npro"]);
                    int nprog = CfgFn.GetNoNullInt32(r["idpro"]);
                    I.Reversali.Add(new RigaReversale(ydoc, ndoc, amount, opdate, valdate, reg, motive, nbill, nprog));
                }
            }

            foreach (DataRow b in DS.bankimportbill.Rows) {
                bool spesa = (b["billkind"].ToString() == "D");
                int ybill = CfgFn.GetNoNullInt32(b["ybill"]);
                int nbill = CfgFn.GetNoNullInt32(b["nbill"]);
                decimal amount = CfgFn.GetNoNullDecimal(b["amount"]);
                string reg = b["registry"].ToString();
                string motive = b["motive"].ToString();
                object opdate = b["adate"];
                object sottoconto = ricavaSottoConto(b["idtreasurer"]);
                if (spesa) {
                    I.BolletteSpesa.Add(new ProvvisorioSpesa(ybill, nbill, amount, motive, reg, opdate, sottoconto));
                }
                else {
                    I.BolletteEntrata.Add(new ProvvisorioEntrata(ybill, nbill, amount, motive, reg, opdate,
                        sottoconto));
                }
            }

            foreach (DataRow b in DS.billtransaction.Rows) {
                bool spesa = (b["kind"].ToString() == "D");
                int ybill = CfgFn.GetNoNullInt32(b["ybilltran"]);
                int nbill = CfgFn.GetNoNullInt32(b["nbill"]);
                decimal amount = CfgFn.GetNoNullDecimal(b["amount"]);
                object opdate = b["adate"];
                if (spesa) {
                    I.EsitiBolletteSpesa.Add(new EsitoProvvisorio(ybill, nbill, amount, opdate));
                }
                else {
                    I.EsitiBolletteEntrata.Add(new EsitoProvvisorio(ybill, nbill, amount, opdate));
                }
            }

            return I;
        }

        public void MetaData_BeforePost() {
            epm.beforePost();
            if (DS.bankimport.Rows.Count == 0) {
                DS.banktransaction.Clear();
                return;
            }

            if (DS.bankimport.Rows[0].RowState == DataRowState.Deleted) {
                foreach (DataRow R in DS.banktransaction.Select()) {
                    R.Delete();
                }

                foreach (DataRow R in DS.billtransaction.Select()) {
                    R.Delete();
                }
            }
        }

        public void ValorizzaDateSiope() {
            DateTime DC = security.GetDataContabile();
            DateTime Mese = new DateTime(DC.Year, DC.Month, 1);

            txtDataInizioSiope.Text = Mese.ToShortDateString();
            HelpForm.ExtLeaveDateTimeTextBox(txtDataInizioSiope, null);
            txtDataFineSiope.Text = DC.ToShortDateString();
            HelpForm.ExtLeaveDateTimeTextBox(txtDataFineSiope, null);

        }

        public void MetaData_AfterPost() {
            epm.afterPost();
        }

        public void MetaData_AfterFill() {
            btnImportaDaSiope.Enabled = false;
            if (controller.firstFillForThisRow) {
                btnImportManualeSiope.Enabled = false;
            }

            epm.mostraEtichette();
            if (controller.firstFillForThisRow && controller.InsertMode) {
                calcolaLastImport();
                btnApriFile.Visible = true;
                ValorizzaDateSiope();
                btnImportManualeSiope.Enabled = siopePlusAbilitato;
            }


            if (controller.firstFillForThisRow && controller.EditMode ) {
                DisplayGridImportazione(RicavaDatiImportatiDaDataSet());
            }

            if (controller.firstFillForThisRow && (controller.InsertMode || controller.EditMode)) {
                DateTime empyDate = new DateTime(1900, 1, 1);
                DataRow Curr = DS.bankimport.Rows[0];

                if (Curr["lastbillexpense"] != DBNull.Value) {
                    DateTime lastbillexpense = (DateTime)Curr["lastbillexpense"];
                    if (lastbillexpense == empyDate) {
                        lblUltimoSospesoUscita.Visible = false;
                        txtUltimoSospesoUscita.Visible = false;
                    }
                }

                if (Curr["lastbillincome"] != DBNull.Value) {
                    DateTime lastbillincome = (DateTime)Curr["lastbillincome"];
                    if (lastbillincome == empyDate) {
                        lblUltimoSospesoEntrata.Visible = false;
                        txtUltimoSospesoEntrata.Visible = false;
                    }
                }

                if (Curr["lastpayment"] != DBNull.Value) {
                    DateTime lastpayment = (DateTime)Curr["lastpayment"];
                    if (lastpayment == empyDate) {
                        lblUltimoPagamento.Visible = false;
                        txtUltimoPagamento.Visible = false;
                    }
                }

                if (Curr["lastproceeds"] != DBNull.Value) {
                    DateTime lastproceeds = (DateTime)Curr["lastproceeds"];
                    if (lastproceeds == empyDate) {
                        lblUltimoIncasso.Visible = false;
                        txtUltimoIncasso.Visible = false;
                    }
                }

            }

            gboxBanca.Enabled = DS.bankimportbill.Rows.Count == 0 && DS.banktransaction.Rows.Count == 0;

            txtidentificativo_flusso_bt.ReadOnly = true;
        }

        void ClearGrids() {
            dgridBolletteEntrata.DataBindings.Clear();
            dgridBolletteSpesa.DataBindings.Clear();
            dgridMandati.DataBindings.Clear();
            dgridReversali.DataBindings.Clear();
            gridEsitiEntrata.DataBindings.Clear();
            gridEsitiUscita.DataBindings.Clear();

            dgridMandati.DataSource = null;
            dgridMandati.TableStyles.Clear();
            dgridReversali.DataSource = null;
            dgridReversali.TableStyles.Clear();
            dgridBolletteEntrata.DataSource = null;
            dgridBolletteEntrata.TableStyles.Clear();
            dgridBolletteSpesa.DataSource = null;
            dgridBolletteSpesa.TableStyles.Clear();
            gridEsitiEntrata.DataSource = null;
            gridEsitiEntrata.TableStyles.Clear();
            gridEsitiUscita.DataSource = null;
            gridEsitiUscita.TableStyles.Clear();
        }

        void DisplayGridImportazione(DatiImportati M) {
            if (M == null) return;

            DataSet D = new DataSet();
            DataTable TMandati = RigaMandato.CreaTableForDisplay();
            M.GetTabellaMandati(TMandati);
            D.Tables.Add(TMandati);
            dgridMandati.DataSource = null;
            dgridMandati.TableStyles.Clear();
            HelpForm.SetDataGrid(dgridMandati, TMandati);

            DataTable TReversali = RigaReversale.CreaTableForDisplay();
            M.GetTabellaReversali(TReversali);
            D.Tables.Add(TReversali);
            dgridReversali.DataSource = null;
            dgridReversali.TableStyles.Clear();
            HelpForm.SetDataGrid(dgridReversali, TReversali);

            DataTable TBolletteEntrata = Provvisorio.CreateTableForDisplay();
            TBolletteEntrata.TableName = "bollette_entrata";
            M.GetTabellaBolletteEntrata(TBolletteEntrata);
            D.Tables.Add(TBolletteEntrata);
            dgridBolletteEntrata.DataSource = null;
            dgridBolletteEntrata.TableStyles.Clear();
            HelpForm.SetDataGrid(dgridBolletteEntrata, TBolletteEntrata);

            DataTable TBolletteSpesa = Provvisorio.CreateTableForDisplay();
            TBolletteSpesa.TableName = "bollette_spesa";
            M.GetTabellaBolletteSpesa(TBolletteSpesa);
            D.Tables.Add(TBolletteSpesa);
            dgridBolletteSpesa.DataSource = null;
            dgridBolletteSpesa.TableStyles.Clear();
            HelpForm.SetDataGrid(dgridBolletteSpesa, TBolletteSpesa);

            DataTable TEsitiEntrata = EsitoProvvisorio.CreateTableForDisplay();
            TEsitiEntrata.TableName = "esiti_entrata";
            M.GetTabellaEsitiBolletteEntrata(TEsitiEntrata);
            D.Tables.Add(TEsitiEntrata);
            gridEsitiEntrata.DataSource = null;
            gridEsitiEntrata.TableStyles.Clear();
            HelpForm.SetDataGrid(gridEsitiEntrata, TEsitiEntrata);

            DataTable TEsitiSpesa = EsitoProvvisorio.CreateTableForDisplay();
            TEsitiSpesa.TableName = "esiti_spesa";
            M.GetTabellaEsitiBolletteSpesa(TEsitiSpesa);
            D.Tables.Add(TEsitiSpesa);
            gridEsitiUscita.DataSource = null;
            gridEsitiUscita.TableStyles.Clear();
            HelpForm.SetDataGrid(gridEsitiUscita, TEsitiSpesa);

        }

        private void btnApriFile_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            openFileDialog1.FileName = txtFile.Text;
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) {
                return;
            }

            string fname = openFileDialog1.FileName;
            txtFile.Text = fname;
            btnApriFile.Enabled = false;
            Cursor = Cursors.WaitCursor;

            DatiImportati I = ImportazioneEsitiBancari.ImportFile(conn as DataAccess, fname, txtBanca.Text);

            if (I != null) {
                if (controller.isClosing) return;
                if (!I.DatiValidi) {
                    QueryCreator.ShowError(this, "Poiché i dati importati non sono validi, non sarà possibile salvare.",
                        I.error);
                    Meta.CanSave = false;
                }
                else {
                    Meta.CanSave = true;
                }
                DataRow Curr = DS.bankimport.Rows[0];
                travasaInDataSet(I, Curr);


                model.MarkTableAsNotEntityChild(DS.bankimport, DS.banktransaction);
                model.MarkTableAsNotEntityChild(DS.bankimport, DS.billtransaction);
                Meta.FreshForm();
                DisplayGridImportazione(I);                
            }

            btnApriFile.Enabled = true;
            labelOperazione.Text = null;
            progressBar.Value = 0;
            Application.DoEvents();
            Cursor = null;

        }






        /// <summary>
        /// Metodo che fa partire la procedura di esitazione automatica.
        /// </summary>
        /// <returns></returns>
        public bool travasaInDataSet(DatiImportati M, DataRow Curr) {


            TravasaPartitePendenti(M, Curr);
            TravasaEsitiPartitePendenti(M, Curr);

            copiaMandati(M, Curr);
            copiaReversali(M, Curr);

            CalcolaRigaBankImport(M, Curr /*DS.bankimport.Rows[0]*/);

            return true;
        }



        /// <summary>
        /// Crea le operazioni sulle bollette in base al file importato dalla banca
        /// La riga in bill è cercata in base a ybill=ESERC, nbill=NUMQUI e billkind= D/C a seconda del tipo di bolletta (P/I)
        /// Quando la bolletta è creata, in essa sono valorizzati anche i campi 
        ///   motive(CAUSALE)   registry(ANABE)   adate(DTPAG) idtreasurer e active='S'
        /// </summary>
        /// <param name="multibill">Se true ammette bolletta aperta più volte</param>
        /// <returns></returns>
        private bool TravasaPartitePendenti(DatiImportati M, DataRow Curr) {
            // Si selezionano le partite pendenti mediante il filtro seguente.

            labelOperazione.Text = "Elaborazione Partite pendenti";
            progressBar.Maximum = M.BolletteEntrata.Count + M.BolletteSpesa.Count;
            progressBar.Value = 0;
            int esercizio = CfgFn.GetNoNullInt32(security.GetEsercizio());

            foreach (ProvvisorioEntrata PE in M.BolletteEntrata) {
                progressBar.Value++;
                Application.DoEvents();
                if (PE.y != esercizio) continue;
                copiaPartitaPendente("C", PE, Curr);
                //Application.DoEvents();
            }

            foreach (ProvvisorioSpesa PS in M.BolletteSpesa) {
                progressBar.Value++;
                Application.DoEvents();
                if (PS.y != esercizio) continue;
                copiaPartitaPendente("D", PS, Curr);
                //Application.DoEvents();
            }

            return true;
        }

        private bool TravasaEsitiPartitePendenti(DatiImportati M, DataRow Curr) {
            // Si selezionano le partite pendenti mediante il filtro seguente.

            labelOperazione.Text = "Elaborazione Esiti Partite pendenti";
            progressBar.Maximum = M.EsitiBolletteEntrata.Count + M.EsitiBolletteSpesa.Count;
            progressBar.Value = 0;
            int esercizio = CfgFn.GetNoNullInt32(security.GetEsercizio());

            foreach (EsitoProvvisorio PE in M.EsitiBolletteEntrata) {
                progressBar.Value++;
                Application.DoEvents();
                if (PE.y != esercizio) continue;
                copiaEsitoPartitaPendente("C", PE, Curr);
                //Application.DoEvents();
            }

            foreach (EsitoProvvisorio PS in M.EsitiBolletteSpesa) {
                progressBar.Value++;
                Application.DoEvents();
                if (PS.y != esercizio) continue;
                copiaEsitoPartitaPendente("D", PS, Curr);
                //Application.DoEvents();
            }

            return true;
        }

        /// <summary>
        /// Crea una riga in bankimportbill
        /// </summary>
        /// <param name="billkind"></param>
        /// <param name="P"></param>
        void copiaPartitaPendente(string billkind, Provvisorio P, DataRow Curr) {
            //DataRow Curr = DS.bankimport.Rows[0];
            metaImpBill.SetDefaults(Tbankimportbill);
            DataRow pp = metaImpBill.Get_New_Row(Curr, Tbankimportbill);
            pp["billkind"] = billkind;
            pp["ybill"] = P.y;
            pp["nbill"] =
                P.nbill; //per ora lo valorizziamo, un domani non lo faremo più e lo farà il trigger eventualm.
            pp["banknum"] = P.nbill; //n. bolletta "banca"
            pp["idbank"] = Curr["idbank"];
            pp["amount"] = P.amount;
            string beneficiario = P.registry;
            if (beneficiario.Length > lenBeneficiario) {
                beneficiario = beneficiario.Substring(0, lenBeneficiario);
            }

            pp["registry"] = beneficiario;
            string causale = P.causale;
            if (causale.Length > lenCausale) {
                causale = causale.Substring(0, lenCausale);
            }

            pp["motive"] = causale;
            pp["idtreasurer"] = ricavaCodiceCassiere(P.numeroconto);
            pp["adate"] = P.data;

        }


        /// <summary>
        /// Crea una riga in billtransaction
        /// </summary>
        /// <param name="billkind"></param>
        /// <param name="P"></param>
        void copiaEsitoPartitaPendente(string billkind, EsitoProvvisorio P, DataRow Curr) {
            // DataRow Curr = DS.bankimport.Rows[0];
            metaBillTrans.SetDefaults(Tbilltransaction);
            DataRow pp = metaBillTrans.Get_New_Row(Curr, Tbilltransaction);
            pp["kind"] = billkind;
            pp["ybilltran"] = P.y;
            pp["nbill"] =
                P.nbill; //per ora lo valorizziamo, un domani non lo faremo più e lo farà il trigger eventualm.
            pp["amount"] = P.amount;
            pp["adate"] = P.data;
        }

        public static string truncate(string S, int len) {
            if (S == null) return S;
            if (S.Length < len) return S;
            return S.Substring(0, len);
        }

        /// <summary>
        /// Crea una riga in BANKTRANSACTION associandolo al movimento dato con i dati di RigaDoc, e con l'importo dato
        /// </summary>
        /// <param name="rOperazione"></param>
        /// <param name="rRigaBanca"></param>
        /// <param name="importo">Importo da utilizzare per l'esito - PERCHE?</param>
        /// <param name="tipoDoc">C (a credito ) o D (a debito)</param>
        /// <param name="rMov"></param>
        private void copiaEsitazione(RigaDocumento RigaDoc, decimal importo, string tipoDocC_D, DataRow Curr) {
            //string idmov_field = (tipoDocC_D == "D") ? "idexp" : "idinc";
            string kdoc_field = (tipoDocC_D == "D") ? "kpay" : "kpro";
            string iddoc_field = (tipoDocC_D == "D") ? "idpay" : "idpro";
            //DataRow Curr = DS.bankimport.Rows[0];
            metaDMB.SetDefaults(Tbanktransaction);
            DataRow rBankTrans = metaDMB.Get_New_Row(Curr, DS.Tables["banktransaction"]);
            rBankTrans["bankreference"] = RigaDoc.nbill;
            rBankTrans["nbill"] = RigaDoc.nbill;
            rBankTrans["transactiondate"] = RigaDoc.transactiondate;
            rBankTrans["valuedate"] = RigaDoc.valuedate;
            rBankTrans["amount"] = importo;

            string causale = RigaDoc.causale;
            if (causale.Length > lenCausale) {
                causale = causale.Substring(0, lenCausale);
            }

            rBankTrans["motive"] = causale;
            //rBankTrans[idmov_field] = RigaDoc.idmov;
            rBankTrans[kdoc_field] = RigaDoc.kdoc;
            rBankTrans[iddoc_field] = RigaDoc.progressivo;
            rBankTrans["kind"] = tipoDocC_D;
        }

        Hashtable DescrizioniCassieri = new Hashtable();

        private object ricavaDescrizioneCassiere(object sottoconto) {
            string s = sottoconto.ToString().Trim();
            if (s == "") return DBNull.Value;
            if (s == "0") return DBNull.Value;
            if (DescrizioniCassieri.Contains(s)) {
                return DescrizioniCassieri[s];
            }

            var cndWhere = q.eq("trasmcode", sottoconto) & q.bitClear("flag", 0) & q.eq("active", "S");
            int nTreasurer = conn.count("treasurer", cndWhere);
            object treasurer = conn.readValue("treasurer", cndWhere, "description");
            if ((nTreasurer > 1) || (treasurer == null)) treasurer = DBNull.Value;
            DescrizioniCassieri[s] = treasurer;
            return treasurer;
        }

        Hashtable sottoConti = new Hashtable();

        private object ricavaSottoConto(object idtreasurer) {
            if (idtreasurer == DBNull.Value) return DBNull.Value;
            if (sottoConti.Contains(idtreasurer)) return sottoConti[idtreasurer];

            object trasmcode = conn.readValue("treasurer", q.eq("idtreasurer", idtreasurer), "trasmcode");
            if (trasmcode == null) trasmcode = DBNull.Value;
            sottoConti[idtreasurer] = trasmcode;
            return trasmcode;
        }


        Hashtable CodiciCassieri = new Hashtable();

        private object ricavaCodiceCassiere(object sottoconto) {
            string s = sottoconto.ToString().Trim();
            if (s == "") return DBNull.Value;
            if (s == "0") return DBNull.Value;
            if (CodiciCassieri.Contains(s)) {
                return CodiciCassieri[s];
            }

            var cndWhere = q.eq("trasmcode", sottoconto) & q.bitClear("flag", 0) & q.eq("active", "S");
            //QHS.AppAnd(QHS.CmpEq("trasmcode", sottoconto), QHS.BitClear("flag", 0),QHS.CmpEq("active", "S"));
            int nTreasurer = conn.count("treasurer", cndWhere);
            object idtreasurer = conn.readValue("treasurer", cndWhere, "idtreasurer");

            if ((nTreasurer > 1) || (idtreasurer == null)) idtreasurer = DBNull.Value;
            CodiciCassieri[s] = idtreasurer;
            return idtreasurer;
        }

        private void copiaMandati(DatiImportati M, DataRow Curr) {
            // Sezione dichiarativa - Si valorizzano le variabili in base al tipo di esitazione
            // se è sui mandati o sulle reversali
            labelOperazione.Text = "Esitazione mandati";
            int esercizio = CfgFn.GetNoNullInt32(security.GetEsercizio());

            progressBar.Maximum = M.Mandati.Count;
            progressBar.Value = 0;
            foreach (RigaMandato r in M.Mandati) {
                progressBar.Value++;
                Application.DoEvents();
                if (r.y != esercizio) continue;
                copiaEsitazione(r, r.amount, "D", Curr);
            }
        }

        private void btnImportaDaSiope_Click(object sender, EventArgs e) {
            if (!controller.IsEmpty) return;

            object dataInizio = HelpForm.GetObjectFromString(typeof(DateTime), txtDataInizioSiope.Text,txtDataInizioSiope.Tag.ToString());
            if (dataInizio == null || dataInizio==DBNull.Value) return;
            var inizio= (DateTime)dataInizio;

            object dataFine = HelpForm.GetObjectFromString(typeof(DateTime), txtDataFineSiope.Text, txtDataFineSiope.Tag.ToString());
            if (dataFine == null || dataFine==DBNull.Value) return;
            DateTime fine = (DateTime)dataFine;

            var All_I = ImportazioneEsitiBancari.ImportFileSiopePlus(conn as DataAccess, /*txtBanca.Text,*/ inizio, fine);

            model.MarkTableAsNotEntityChild(DS.bankimport, DS.banktransaction);
            model.MarkTableAsNotEntityChild(DS.bankimport, DS.billtransaction);
            foreach (var E in All_I) {
                controller.Clear();
                controller.DoMainCommand("maininsert");
                var Curr = DS.bankimport.Rows[0];
                travasaInDataSet(E, Curr);
                if (controller.isClosing) return;
                if (!E.DatiValidi) {
                    QueryCreator.ShowError(this,
                        "Poiché i dati importati non sono validi, non sarà possibile salvare una delle pagine del giornale.",
                        E.error);
                    controller.DontWarnOnInsertCancel = true;
                    controller.Clear();
                    continue;
                }

                controller.FreshForm(false,false);
                DisplayGridImportazione(E);
                btnApriFile.Visible = false;
                controller.DoMainCommand("mainsave");
            }
            btnApriFile.Enabled = true;
            labelOperazione.Text = null;
            progressBar.Value = 0;
            Application.DoEvents();
            Cursor = null;
        }

        private DataRow PredisponiNuovaImportazione() {
            Meta.SetDefaults(DS.bankimport);
            DataRow NewBankimport = Meta.Get_New_Row(null, DS.bankimport);
            return NewBankimport;
        }
      

        private void btnImportManualeSiope_Click(object sender, EventArgs e) {
            if (controller.IsEmpty) return;
            if (controller.EditMode) return;
            openFileDialog1.FileName = txtFile.Text;
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr != DialogResult.OK) {
                return;
            }

            string fname = openFileDialog1.FileName;
            txtFile.Text = fname;
            btnApriFile.Enabled = false;
            Cursor = Cursors.WaitCursor;

            DatiImportati I = ImportazioneEsitiBancari.ImportFileManualeSiopePlus(conn as DataAccess, fname);

            if (I != null) {
                DataRow Curr = DS.bankimport.Rows[0];
                travasaInDataSet(I, Curr);
                btnImportManualeSiope.Enabled = false;
                if (controller.isClosing) return;
                if (!I.DatiValidi) {
                    QueryCreator.ShowError(this,"Poiché i dati importati non sono validi, non sarà possibile salvare.",I.error);
                    Meta.CanSave = false;
                }
                else {
                    Meta.CanSave = true;
                }

                model.MarkTableAsNotEntityChild(DS.bankimport, DS.banktransaction);
                model.MarkTableAsNotEntityChild(DS.bankimport, DS.billtransaction);
                Meta.FreshForm();
                DisplayGridImportazione(I);
                btnApriFile.Visible = false;
            }

            btnApriFile.Enabled = true;
            labelOperazione.Text = null;
            progressBar.Value = 0;
            Application.DoEvents();
            Cursor = null;

        }

        private void txtDataInizioSiope_TextChanged(object sender, EventArgs e) {

        }

        private void copiaReversali(DatiImportati M, DataRow Curr) {
            // Sezione dichiarativa - Si valorizzano le variabili in base al tipo di esitazione
            // se è sui mandati o sulle reversali
            labelOperazione.Text = "Esitazione reversali";
            int esercizio = CfgFn.GetNoNullInt32(security.GetEsercizio());
            progressBar.Maximum = M.Reversali.Count;
            progressBar.Value = 0;
            foreach (RigaReversale r in M.Reversali) {
                progressBar.Value++;
                Application.DoEvents();
                if (r.y != esercizio) continue;
                copiaEsitazione(r, r.amount, "C", Curr);
            }
        }

        void CalcolaRigaBankImport(DatiImportati m, DataRow rr) {
            DateTime empyDate = new DateTime(1900, 1, 1);
            DateTime lastpayment = empyDate;
            DateTime lastproceeds = empyDate;
            DateTime lastbillincome = empyDate;
            DateTime lastbillexpense = empyDate;
            decimal totalpayment = 0;
            decimal totalproceeds = 0;
            decimal totalbillincome_plus = 0;
            decimal totalbillincome_minus = 0;
            decimal totalbillexpense_plus = 0;
            decimal totalbillexpense_minus = 0;

            foreach (RigaMandato r in m.Mandati) {
                totalpayment += r.amount;
                if (r.transactiondate == DBNull.Value) continue;
                if (lastpayment < (DateTime) r.transactiondate) lastpayment = (DateTime) r.transactiondate;
            }

            foreach (RigaReversale r in m.Reversali) {
                totalproceeds += r.amount;
                if (r.transactiondate == DBNull.Value) continue;
                if (lastproceeds < (DateTime) r.transactiondate) lastproceeds = (DateTime) r.transactiondate;
            }

            foreach (ProvvisorioEntrata r in m.BolletteEntrata) {
                totalbillincome_plus += r.amount > 0 ? r.amount : 0;
                totalbillincome_minus += r.amount < 0 ? -r.amount : 0;
                if (r.data == DBNull.Value) continue;
                if (lastbillincome < (DateTime) r.data) lastbillincome = (DateTime) r.data;
            }

            foreach (ProvvisorioSpesa r in m.BolletteSpesa) {
                totalbillexpense_plus += r.amount > 0 ? r.amount : 0;
                totalbillexpense_minus += r.amount < 0 ? -r.amount : 0;
                if (r.data == DBNull.Value) continue;
                if (lastbillexpense < (DateTime) r.data) lastbillexpense = (DateTime) r.data;
            }


            rr["lastpayment"] = lastpayment;
            rr["lastproceeds"] = lastproceeds;
            rr["lastbillincome"] = lastbillincome;
            rr["lastbillexpense"] = lastbillexpense;
            rr["totalpayment"] = totalpayment;
            rr["totalproceeds"] = totalproceeds;
            rr["totalbillincome_plus"] = totalbillincome_plus;
            rr["totalbillincome_minus"] = totalbillincome_minus;
            rr["totalbillexpense_plus"] = totalbillexpense_plus;
            rr["totalbillexpense_minus"] = totalbillexpense_minus;
            rr["identificativo_flusso_bt"] = m.identificativo_flusso_BT;
            if ((m.idbank != "") && (rr["idbank"].ToString() != m.idbank)) {
                rr["idbank"] = m.idbank;
                txtBanca.Text = rr["idbank"].ToString();
                //txtDescrBanca


            }

        }




    }
}
