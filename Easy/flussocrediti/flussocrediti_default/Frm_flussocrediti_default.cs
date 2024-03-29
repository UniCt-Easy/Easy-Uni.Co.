
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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


using funzioni_configurazione;
using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using pagoPaService;

namespace flussocrediti_default {
    public partial class Frm_flussocrediti_default : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        private DataAccess MyConn;
        char[] buffer = new char[2000];
        
        CQueryHelper QHC;
        QueryHelper QHS;
        
        public Frm_flussocrediti_default() {
            InitializeComponent();
            saveFileDialog1.DefaultExt = "xml";
        }

        string partner;
        string[] partnerConfig;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            MyConn = MetaData.GetConnection(this);
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
            DataAccess.SetTableForReading(DS.flussocreditidetail_ca, "flussocreditidetail");
            DataAccess.SetTableForReading(DS.flussocreditidetail_fatt, "flussocreditidetail");
            DataAccess.SetTableForReading(DS.flussocreditidetail_unlinked, "flussocreditidetail");
            QueryCreator.SetTableForPosting(DS.flussocreditidetail_ca, "flussocreditidetail");
            QueryCreator.SetTableForPosting(DS.flussocreditidetail_fatt, "flussocreditidetail");
            QueryCreator.SetTableForPosting(DS.flussocreditidetail_unlinked, "flussocreditidetail");


            GetData.SetStaticFilter(DS.flussocreditidetail_ca, QHS.IsNotNull("nestim"));
            GetData.SetStaticFilter(DS.flussocreditidetail_fatt, QHS.IsNotNull("ninv"));
            GetData.SetStaticFilter(DS.flussocreditidetail_unlinked, QHS.AppAnd(QHS.IsNull("ninv"), QHS.IsNull("nestim")));

            GetData.CacheTable(DS.estimatekind2, QHS.CmpEq("linktoinvoice", "N"), "description", true);
            GetData.CacheTable(DS.invoicekind1, QHS.BitSet("flag", 0), "description", true);
            DataAccess.SetTableForReading(DS.estimatekind1, "estimatekind");
            DataAccess.SetTableForReading(DS.estimatekind2, "estimatekind");
            DataAccess.SetTableForReading(DS.invoicekind1, "invoicekind");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null, null, "1", true);
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
                    TabControll.TabPages.Remove(tabAttributi);
                }
            }

            var tPartnerConfig = Conn.RUN_SELECT("partner_config", "*", null, null, "1", false);
            if (tPartnerConfig.Rows.Count > 0) {
                var r = tPartnerConfig.Rows[0];
             
                partner = r["code"] as string;

                switch (partner) {
                case "bsondrio": grpPartner.Text = @"Banca di Sondrio"; break;
                case "cineca": grpPartner.Text = @"Cineca"; break;
                case "intesasp": grpPartner.Text = @"Intesa San Paolo"; break;
                case "unicredit": grpPartner.Text = @"Unicredit"; break;
                    case "ubibanca": grpPartner.Text = @"UbiBanca"; break;
                }

                if (!DBNull.Value.Equals(r["config"])) {
                    partnerConfig = r["config"].ToString().Split('|');
                }
            }
            else {
                grpPartner.Visible = false;
            }
            btnAnnullaInvio.Visible = System.Diagnostics.Debugger.IsAttached;
        }

        public void MetaData_AfterFill() {
            buttonInsertCA.Enabled = true;
            btnEsportaFlussoCrediti.Enabled = true;
            Enabledisable_Transmitted();
            cmbTipoContrattoAttivo.Enabled = Meta.InsertMode;
            cmbTipoDoc.Enabled = Meta.InsertMode;
            if (Meta.FirstFillForThisRow) {
                txtAnnoContratto.Text = Conn.GetEsercizio().ToString();
                txtAnnoDocumento.Text = Conn.GetEsercizio().ToString();
            }
        }
        

        public void MetaData_AfterClear() {
            buttonInsertCA.Enabled = false;
            btnEsportaFlussoCrediti.Enabled = false;
            chkIstransmitted.Enabled = true;
 
            cmbTipoContrattoAttivo.Enabled = true;
            cmbTipoDoc.Enabled = true;
            cmbTipoContrattoAttivo.SelectedIndex = -1;
            cmbTipoDoc.SelectedIndex = -1;
            //txtPercorso.Text = "";
            txtAnnoContratto.Text = "";
            txtAnnoDocumento.Text = ""; 
        }

        public void Enabledisable_Transmitted() {
            DataRow Curr = DS.flussocrediti.Rows[0];
            if (Curr["istransmitted"].ToString() == "S") {
                chkIstransmitted.Enabled = false;
                buttonInsertCA.Enabled = false;
                buttonEditCA.Enabled = false;
                buttonDeteleCA.Enabled = false;
                buttonInsertFatt.Enabled = false;
                buttonEditFatt.Enabled = false;
                buttonDeleteFatt.Enabled = false;
                btnEsportaFlussoCrediti.Enabled = false;
                btnAddCredito.Enabled = false;
                btnDelCredito.Enabled = false;
                btnModCredito.Enabled = false;

                btnAggiungiContratti.Enabled = false;
                btnAggiungiFatture.Enabled = false;
            }
            else {
                chkIstransmitted.Enabled = true;
                buttonInsertCA.Enabled = true;
                buttonEditCA.Enabled = true;
                buttonDeteleCA.Enabled = true;
                buttonInsertFatt.Enabled = true;
                buttonEditFatt.Enabled = true;
                buttonDeleteFatt.Enabled = true;
                btnEsportaFlussoCrediti.Enabled = true;
                btnAddCredito.Enabled = true;
                btnDelCredito.Enabled = true;
                btnModCredito.Enabled = true;

                btnAggiungiContratti.Enabled = true;
                btnAggiungiFatture.Enabled = true;
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone)
                return;
            if ((T.TableName == "estimatedetail") && R != null && Meta.DrawStateIsDone) {
                LinkFlussocreditidetail(R, "estimatedetail");
                return;
            }
            if (T.TableName == "invoicedetail" && R != null && Meta.DrawStateIsDone) {
                LinkFlussocreditidetail(R, "invoicedetail");
                return;
            }
        }

        private string scriptUpdateEstimateDetails = "";
        private string scriptUpdateInvoiceDetails = "";

        public void MetaData_AfterPost() {
            if (DS.flussocrediti.Rows.Count == 0) return;//insert cancel?
            DataRow dr = DS.flussocrediti.Rows[0];
            if (dr.RowState == DataRowState.Deleted) return;
            var idflusso = dr["idflusso"];

            //Per i dett. flusso cancellati
            if (scriptUpdateEstimateDetails != "") {
                Meta.Conn.SQLRunner(scriptUpdateEstimateDetails);
            }

            // Valorizza il numero bollettino (iduniqueformcode) nei dettagli dei contratti attivi.
            scriptUpdateEstimateDetails = string.Format(@"UPDATE ED
                SET ED.iduniqueformcode = FCD.iduniqueformcode
                FROM estimatedetail ED
                JOIN flussocreditidetail FCD ON
                    ED.idestimkind = FCD.idestimkind AND
                    ED.yestim = FCD.yestim AND
                    ED.nestim = FCD.nestim AND
                    ED.rownum = FCD.rownum
                WHERE FCD.iduniqueformcode IS NOT NULL AND FCD.idflusso = {0}", idflusso);

            Meta.Conn.SQLRunner(scriptUpdateEstimateDetails);
            scriptUpdateEstimateDetails = "";

            //Per i dett.flusso cancellati
            if (scriptUpdateInvoiceDetails != "") {
                Meta.Conn.SQLRunner(scriptUpdateInvoiceDetails);
            }

            // Valorizza il numero di bollettino (iduniqueformcode) nei dettagli delle fatture.
            scriptUpdateInvoiceDetails = string.Format(@"UPDATE ID
                SET ID.iduniqueformcode = FCD.iduniqueformcode
                FROM invoicedetail ID
                JOIN flussocreditidetail FCD ON
	                ID.idinvkind = FCD.idinvkind AND
	                ID.yinv = FCD.yinv AND
	                ID.ninv = FCD.ninv AND
	                ID.rownum = FCD.invrownum
                WHERE FCD.iduniqueformcode IS NOT NULL AND FCD.idflusso = {0}", idflusso);

            Meta.Conn.SQLRunner(scriptUpdateInvoiceDetails);
            scriptUpdateInvoiceDetails = ""; 
        }

        public void MetaData_BeforePost() {
            PostData.RemoveFalseUpdates(DS);
            string filter = "";

            StringBuilder builder = new StringBuilder();

            // Per i dettagli flusso cancellati, azzera il numero bollettino (iduniqueformcode)
            // nei dettagli dei contratti attivi.
            foreach (DataRow R in DS.flussocreditidetail_ca.Rows) {
                if (R.RowState == DataRowState.Deleted) {
                    filter = QHS.AppAnd(
                        QHS.CmpEq("idestimkind", R["idestimkind", DataRowVersion.Original]),
                        QHS.CmpEq("yestim", R["yestim", DataRowVersion.Original]),
                        QHS.CmpEq("nestim", R["nestim", DataRowVersion.Original]),
                        QHS.CmpEq("rownum", R["rownum", DataRowVersion.Original])
                    );

                    builder.AppendLine(string.Format(@"UPDATE estimatedetail
                        SET iduniqueformcode = null
                        WHERE ({0});", filter));
                }
            }

            scriptUpdateEstimateDetails = builder.ToString();

            builder = new StringBuilder();

            // Per i dettagli flusso cancellati, azzera il numero bollettino (iduniqueformcode)
            // nei dettagli delle fatture.
            foreach (DataRow r in DS.flussocreditidetail_fatt.Rows) {
                if (r.RowState == DataRowState.Deleted) {
                    filter = QHS.AppAnd(
                        QHS.CmpEq("idinvkind", r["idinvkind", DataRowVersion.Original]),
                        QHS.CmpEq("yinv", r["yinv", DataRowVersion.Original]),
                        QHS.CmpEq("ninv", r["ninv", DataRowVersion.Original]),
                        QHS.CmpEq("rownum", r["invrownum", DataRowVersion.Original])
                    );

                    builder.AppendLine($@"UPDATE invoicedetail
                        SET iduniqueformcode = NULL
                        WHERE ({filter});");
                }
            }

            scriptUpdateInvoiceDetails = builder.ToString();
        }

     


        void LinkFlussocreditidetail(DataRow RigaSelezionata, string kind) {
            if (RigaSelezionata == null) return;
            // Ciclo per la creazione dei dettagli
            DataRow rFlusso = DS.flussocrediti.Rows[0];
            MetaData metaDt = MetaData.GetMetaData(this, "flussocreditidetail");

            metaDt.ComputeRowsAs(DS.flussocreditidetail_fatt, "posting");
            metaDt.ComputeRowsAs(DS.flussocreditidetail_ca, "posting");

            if (kind == "invoicedetail") {
	            string filterInv = QHC.MCmp(RigaSelezionata, "idinvkind", "yinv", "ninv");
	            string filterInvSql = QHS.MCmp(RigaSelezionata, "idinvkind", "yinv", "ninv");
	            object scadenza = CalcolaDataScadenza(filterInv, "I");
	            if (scadenza == DBNull.Value || scadenza==null) {
		            show(
			            $"La riga avente descrizione {RigaSelezionata["detaildescription"]} non ha scadenza e non pu� essere inviata.",
			            "Errore");
		            return;
	            }

                object flagsplit = Conn.DO_READ_VALUE("invoice",
                    QHS.AppAnd(QHS.CmpEq("idinvkind", RigaSelezionata["idinvkind"]),
                        QHS.CmpEq("yinv", RigaSelezionata["yinv"]),
                        QHS.CmpEq("ninv", RigaSelezionata["ninv"])
                    ), "flag_enable_split_payment", null);
                metaDt.SetDefaults(DS.flussocreditidetail_fatt);
                DataRow rNew = metaDt.Get_New_Row(rFlusso, DS.flussocreditidetail_fatt);
                foreach (string colname in new string[] { "idinvkind", "yinv", "ninv" ,"idfinmotive", "idfinmotive_iva","idupb", "idupb_iva", "idivakind", "idlist", "number"}) {
                    rNew[colname] = RigaSelezionata[colname];
                }
                rNew["invrownum"] = RigaSelezionata["rownum"];
                rNew["idaccmotiverevenue"] = RigaSelezionata["idaccmotive"];

               
                object idreg = Conn.DO_READ_VALUE("invoice", filterInv, "idreg");
                rNew["expirationdate"] = scadenza;
                rNew["description"] = RigaSelezionata["detaildescription"];
                decimal taxable_euro = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("invoicedetailview",
                    QHS.CmpKey(RigaSelezionata), "taxable_euro"));
                decimal importo = taxable_euro; //CfgFn.GetNoNullDecimal(RigaSelezionata["taxable_euro"])
                rNew["importoversamento"] = importo;

                if (flagsplit.ToString().ToUpper() != "S") {
                    decimal iva_euro = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("invoicedetailview",
                        QHS.CmpKey(RigaSelezionata), "iva_euro"));
                    //importo += iva_euro; //CfgFn.GetNoNullDecimal(RigaSelezionata["iva_euro"]); //era iva_euro, ma tale colonna non esiste
                    rNew["tax"] = iva_euro;
                }

                if (RigaSelezionata["idtassonomia"] != DBNull.Value) {
	                rNew["codicetassonomia"] = Conn.DO_READ_VALUE("tassonomia_pagopa",
		                QHS.CmpEq("idtassonomia", RigaSelezionata["idtassonomia"]), "causale");
                }

                rNew["idreg"] = idreg;
                rNew["cf"] = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", idreg), "cf");
                rNew["competencystart"] = RigaSelezionata["competencystart"];
                rNew["competencystop"] = RigaSelezionata["competencystop"];
                rNew["idfinmotive"] = RigaSelezionata["idfinmotive"];
                rNew["idfinmotive_iva"] = RigaSelezionata["idfinmotive_iva"];
                rNew["idaccmotivecredit"] = Conn.DO_READ_VALUE("invoice", filterInvSql, "idaccmotivedebit");
            }

            if (kind == "estimatedetail") {
                metaDt.SetDefaults(DS.flussocreditidetail_ca);
                
                string filterEstim = QHC.MCmp(RigaSelezionata, "idestimkind", "yestim", "nestim");
                string filterEstimSql = QHS.MCmp(RigaSelezionata, "idestimkind", "yestim", "nestim");
                object scadenza = RigaSelezionata["proceedsexpiring"];
                if (scadenza == DBNull.Value) {
	                scadenza = CalcolaDataScadenza(filterEstimSql, "E");
                }
                if (scadenza == DBNull.Value ) {
	                show(
		                $"La riga avente descrizione {RigaSelezionata["detaildescription"]} non ha scadenza e non pu� essere inviata.",
		                "Errore");
	                return;
                }
                DataRow rNew = metaDt.Get_New_Row(rFlusso, DS.flussocreditidetail_ca);
                foreach (string colname in new[] { "idestimkind", "yestim", "nestim", "rownum", "idfinmotive", "idfinmotive_iva", "idupb", "idivakind", "idlist", "number"}) {
                    rNew[colname] = RigaSelezionata[colname];
                }
                rNew["expirationdate"] = scadenza;

                rNew["description"] = RigaSelezionata["detaildescription"];
                decimal taxable_euro = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("estimatedetailview", QHS.CmpKey(RigaSelezionata), "taxable_euro"));
                rNew["importoversamento"] = taxable_euro; //RigaSelezionata["taxable_euro"];

                if (RigaSelezionata["idtassonomia"] != DBNull.Value) {
	                rNew["codicetassonomia"] = Conn.DO_READ_VALUE("tassonomia_pagopa",
		                QHS.CmpEq("idtassonomia", RigaSelezionata["idtassonomia"]), "causale");
                }

                rNew["idreg"] = RigaSelezionata["idreg"];
                rNew["cf"] = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", RigaSelezionata["idreg"]), "cf");
                rNew["competencystart"] = RigaSelezionata["competencystart"];
                rNew["competencystop"] = RigaSelezionata["competencystop"];
                rNew["idaccmotiverevenue"] = RigaSelezionata["idaccmotive"];
                rNew["idfinmotive"] = RigaSelezionata["idfinmotive"];
                rNew["idfinmotive_iva"] = RigaSelezionata["idfinmotive_iva"];
                rNew["idaccmotivecredit"] = Conn.DO_READ_VALUE("estimate", filterEstimSql, "idaccmotivecredit");


            }

            Meta.FreshForm();
        }

        private DateTime noNullDate(object o, DateTime defaultDate) {
            if (o == null || o == DBNull.Value)
                return defaultDate;
            try {
                return Convert.ToDateTime(o);
            }
            catch {
                return defaultDate;
            }
        }

        /// <summary>
        /// Calcola la data scadenza di un tipo documento
        /// </summary>
        /// <param name="filterkey">filtro per reperire il documento</param>
        /// <param name="kind">I per invoice E per estimate</param>
        /// <returns></returns>
        private object CalcolaDataScadenza(string filterkey, string kind) {
            if (Meta.IsEmpty) return DBNull.Value;
            DataTable T;
            if (kind == "I") {
                T = Meta.Conn.RUN_SELECT("invoice", "*", null, filterkey, null, true);
            }
            else {
                T = Meta.Conn.RUN_SELECT("estimate", "*", null, filterkey, null, true);
            }
            DataRow R = T.Rows[0];
            object TipoScadenza = R["idexpirationkind"];
            if (TipoScadenza == null) return DBNull.Value;
            DateTime emptyDate = DateTime.Now;

            int ngiorni = CfgFn.GetNoNullInt32(R["paymentexpiring"]);
            DateTime dataRegistrazione = noNullDate(R["adate"], emptyDate);
            DateTime dataDocumento = noNullDate(R["docdate"], emptyDate);
            DateTime dataRicezione = emptyDate;
            if (kind == "I") {
                dataRicezione = noNullDate(R["protocoldate"], emptyDate);
            }
            DateTime dataScadenza = DateTime.MinValue;
            //  1	Data contabile = data registrazione
            //  2	Data documento
            //  3	Fine mese data documento
            //  4	Fine mese data contabile
            //  5	Pagamento Immediato
            //  6   Data ricezione
            if (dataRegistrazione != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(ngiorni) > 0) {
                    dataScadenza = dataRegistrazione.AddDays(ngiorni);
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(ngiorni) == 0) {
                    dataScadenza = dataRegistrazione;
                }
            }
            if (dataDocumento != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(ngiorni) > 0 &&
                    dataDocumento != DateTime.MinValue) {
                    dataScadenza = dataDocumento.AddDays(ngiorni);
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(ngiorni) == 0) {
                    dataScadenza = dataDocumento;
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 3) {
                    int intMese = dataDocumento.Month;
                    int intAnno = dataDocumento.Year;
                    int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
                    DateTime FineMeseDataDocumento = new DateTime(intAnno, intMese, intGiorno);
                    FineMeseDataDocumento = FineMeseDataDocumento.AddDays(ngiorni);
                    dataScadenza = FineMeseDataDocumento;
                }
            }
            if (dataRegistrazione != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 4) {
                    int intMese = dataRegistrazione.Month;
                    int intAnno = dataRegistrazione.Year;
                    int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
                    DateTime FineMeseDataContabile = new DateTime(intAnno, intMese, intGiorno);
                    FineMeseDataContabile = FineMeseDataContabile.AddDays(ngiorni);
                    dataScadenza = FineMeseDataContabile;
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 5) {
                    dataScadenza = dataRegistrazione;
                }
            }

            if (dataRicezione != emptyDate) {
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 6 && CfgFn.GetNoNullInt32(ngiorni) > 0) {
                    dataScadenza = dataRicezione.AddDays(ngiorni);
                }
                if (CfgFn.GetNoNullInt32(TipoScadenza) == 6 && CfgFn.GetNoNullInt32(ngiorni) == 0) {
                    dataScadenza = dataRicezione;
                }
            }

            if (dataScadenza == DateTime.MinValue) return DBNull.Value;

            return dataScadenza;
        }



       
        string GetFilterForLinking_Estim(QueryHelper QH) {
            string filter = "";
            filter = QHS.AppAnd(QHS.IsNull("iduniqueformcode"), QHS.IsNull("idflussocrediti"));
            if (txtAnnoContratto.Text != "") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("yestim",
                    HelpForm.GetObjectFromString(typeof(int), txtAnnoContratto.Text, "x.y.year")));
            }
            if (cmbTipoContrattoAttivo.SelectedIndex > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idestimkind", cmbTipoContrattoAttivo.SelectedValue));
            }
            else {
                //Solo Contratti attivi non collegabili a fattura
                DataTable estimatekind = Meta.Conn.RUN_SELECT("estimatekind", "idestimkind", null, QHS.CmpEq("linktoinvoice", "N"), null, true);
                string lista = QHS.DistinctVal(estimatekind.Select(), "idestimkind");
                filter = QHS.AppAnd(filter, QHS.FieldInList("idestimkind", lista));

            }
                filter = QHS.AppAnd(filter, QHS.NullOrEq("flagbankitaliaproceeds","N"), QHS.IsNotNull("idfinmotive"));
            return filter;
        }

        string GetFilterForLinking_Invoice(QueryHelper QH) {
            string filter = "";
            filter = QHS.AppAnd(QHS.IsNull("iduniqueformcode"), QHS.IsNull("idflussocrediti"));
            if (txtAnnoDocumento.Text != "") {
                filter = QHS.AppAnd(filter, QHS.CmpEq("yinv",
                    HelpForm.GetObjectFromString(typeof(int), txtAnnoDocumento.Text, "x.y.year")));
            }

            if (cmbTipoDoc.SelectedIndex > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("idinvkind", cmbTipoDoc.SelectedValue));
            }
            else {
                // Solo fatture di vendita
                filter = QHS.AppAnd(filter, QHS.CmpEq("flagbuysell", "V"));
            }
            filter = QHS.AppAnd(filter, QHS.NullOrEq("flagbankitaliaproceeds","N"), QHS.IsNotNull("idfinmotive"));
            return filter;
        }

        private void buttonInsert_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);

            string MyFilter = GetFilterForLinking_Estim(QHS);
            string filterestimate = "";
            int rowsCount = 0;
            foreach (DataRow R in DS.flussocreditidetail_ca.Select()) {
                rowsCount++;
                if (R.RowState != DataRowState.Added) continue;
                if (R["idestimkind"] == DBNull.Value) continue; //Non � una riga collegata a dettagli contratto attivo, non dovrebbe accadere
                if (rowsCount == 1)
                  filterestimate = QHS.DoPar(QHS.CmpMulti(R, "idestimkind", "yestim", "nestim", "rownum"));
                else
                    filterestimate = QHS.AppOr(filterestimate, QHS.DoPar(QHC.CmpMulti(R, "idestimkind", "yestim", "nestim", "rownum")));
            }
            if (rowsCount >0) MyFilter = QHS.AppAnd(MyFilter, QHS.Not(filterestimate));
            string command = "choose.estimatedetail.flussocrediti." + MyFilter;

            MetaData.Choose(this, command);
        }

        private void buttonEdit_Click(object sender, EventArgs e) {
            //if (Meta.IsEmpty)
            //    return;
            //Meta.GetFormData(true);
            //string MyFilter = GetFilterForLinking(QHC);
            //string MyFilterSQL = GetFilterForLinking(QHS);
            //Meta.MultipleLinkUnlinkRows("Composizione File Flusso Crediti",
            //    "Dettagli Contratti Attivi inclusi nel modello selezionato",
            //    "Dettagli Contratti Attivi non inclusi in alcun modello",
            //    DS.estimatedetailview, MyFilter, MyFilterSQL, "default");
        }

        private void buttonDetele_Click(object sender, EventArgs e) {
            //if (Meta.IsEmpty)
            //    return;
            //Meta.GetFormData(true);
            //MetaData.Unlink_Grid(gridDettagli);
        }

        private string FaiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                return folderBrowserDialog1.SelectedPath;
            }
            return null;
        }

        private string dataString(DateTime data) {
            string day;
            if (data.Day <= 9) {
                day = '0' + data.Day.ToString();
            }
            else {
                day = data.Day.ToString();
            }
            string month;
            if (data.Month <= 9) {
                month = '0' + data.Month.ToString();
            }
            else {
                month = data.Month.ToString();
            }
            string valore;
            valore = day + month + data.Year.ToString();
            return valore;
        }
      

        public string MyDataTableToTxt(DataTable DT, bool Header) {
            string crlf = "\r\n";
            StringBuilder SB = new StringBuilder();
            string riga = "";
            foreach (DataRow r in DT.Rows) {
                riga = r["out_str"].ToString();
                SB.Append(riga);
                SB.Append(crlf);
            }
            return SB.ToString();
        }

        private DataRow GetFormData() {
            Meta.GetFormData(true);
            if (DS.flussocrediti.Rows.Count == 0) {
                return null;
            }

            if (DS.flussocrediti.Rows.Count == 0) {
                show(this, "Non ci sono Contratti o Fatture!");
                return null;
            }

            if (!Meta.GetFormData(false))
                return null;

            PostData.RemoveFalseUpdates(DS);

            DataRow Curr = DS.flussocrediti.Rows[0];
            if (Curr["datacreazioneflusso"] == DBNull.Value) {
                Curr["datacreazioneflusso"] = Meta.GetSys("datacontabile");
                txtDataCreazioneflusso.Text = HelpForm.StringValue(Meta.GetSys("datacontabile"), txtDataCreazioneflusso.Tag.ToString());
            }

            if (DS.HasChanges()) {
                show(this, "Per eseguire l'operazione occorre prima SALVARE.");
                return null;
            }
            
            return Curr;
        }

        private DataSet CreaDSperInvioCrediti() {
            DataSet newDS = new DataSet();
            DataTable tFlussocrediti = Conn.CreateTableByName("flussocrediti", "*");
            DataTable tFlussocreditidetail = Conn.CreateTableByName("flussocreditidetail", "*");
            foreach (var r in DS.flussocrediti.Select()) {
                tFlussocrediti.ImportRow(r);
            }

            int maxIdDetailFound = 0;
            foreach (var r in DS.flussocreditidetail_ca.Select()) {
                tFlussocreditidetail.ImportRow(r);
                if (CfgFn.GetNoNullInt32(r["iddetail"]) > maxIdDetailFound) {
                    maxIdDetailFound = CfgFn.GetNoNullInt32(r["iddetail"]);
                }
            }
            foreach (var r in DS.flussocreditidetail_fatt.Select()) {
                if (CfgFn.GetNoNullInt32(r["iddetail"]) <= maxIdDetailFound) {
                    r["iddetail"]=maxIdDetailFound+1;
                    maxIdDetailFound += 1;
                }
                tFlussocreditidetail.ImportRow(r);
                if (CfgFn.GetNoNullInt32(r["iddetail"]) > maxIdDetailFound) {
                    maxIdDetailFound = CfgFn.GetNoNullInt32(r["iddetail"]);
                }
            }
            foreach (var r in DS.flussocreditidetail_unlinked.Select()) {
                if (CfgFn.GetNoNullInt32(r["iddetail"]) <= maxIdDetailFound) {
                    r["iddetail"]=maxIdDetailFound+1;
                    maxIdDetailFound += 1;
                }
                tFlussocreditidetail.ImportRow(r);
                if (CfgFn.GetNoNullInt32(r["iddetail"]) > maxIdDetailFound) {
                    maxIdDetailFound = CfgFn.GetNoNullInt32(r["iddetail"]);
                }
            }
            tFlussocrediti.AcceptChanges();
            tFlussocreditidetail.AcceptChanges();

            newDS.Tables.Add(tFlussocrediti);
            newDS.Tables.Add(tFlussocreditidetail);
            newDS.Relations.Add("flussocrediti_flussocreditidetail", tFlussocrediti.Columns["idflusso"], tFlussocreditidetail.Columns["idflusso"], false);

            return newDS;

        }

        private void AllineaTassonomia() {
			// ====================================================================================================================
			//                                              CA => nestim is not null
			// ====================================================================================================================
			string idflusso = DS.flussocrediti.Rows[0]["idflusso"].ToString();

			DataTable Righe_ca = Conn.SQLRunner($@"SELECT top 1 codicetassonomia
	                                                            FROM flussocreditidetail a
	                                                            WHERE idflusso = {idflusso}
	                                                            ORDER BY importoversamento DESC,
	                                                            (
		                                                            SELECT COUNT(idflusso)
		                                                            FROM flussocreditidetail b
		                                                            WHERE b.idflusso = {idflusso}
                                                                        and nestim is not null
                                                                        and b.codicetassonomia = a.codicetassonomia
		                                                            GROUP BY b.codicetassonomia
	                                                            ) DESC,
	                                                            iddetail");

			if (Righe_ca.Rows.Count > 0) {
                object codiceTassonomiaPreval = Righe_ca.Rows[0]["codicetassonomia"];
                foreach (var r in DS.flussocreditidetail_ca.Select()) {
                    r["codicetassonomia"] = codiceTassonomiaPreval;
                }
            }


			// ====================================================================================================================
			//                                              FATT => ninv is not null 
			// ====================================================================================================================
			DataTable Righe_fatt = Conn.SQLRunner($@"SELECT top 1 codicetassonomia
	                                                            FROM flussocreditidetail a
	                                                            WHERE idflusso = {idflusso}
	                                                            ORDER BY importoversamento DESC,
	                                                            (
		                                                            SELECT COUNT(idflusso)
		                                                            FROM flussocreditidetail b
		                                                            WHERE b.idflusso = {idflusso}
                                                                        and ninv is not null
                                                                        and b.codicetassonomia = a.codicetassonomia
		                                                            GROUP BY b.codicetassonomia
	                                                            ) DESC,
	                                                            iddetail");

			if (Righe_fatt.Rows.Count > 0) {
                object codiceTassonomiaPreval = Righe_fatt.Rows[0]["codicetassonomia"];
                foreach (var r in DS.flussocreditidetail_fatt.Select()) {
                    r["codicetassonomia"] = codiceTassonomiaPreval;
                }
            }


			// ====================================================================================================================
		    //                                  UNLINKED => ninv is not null and nestim is not null
			// ====================================================================================================================
			DataTable Righe_unlinked = Conn.SQLRunner($@"SELECT top 1 codicetassonomia
	                                                    FROM flussocreditidetail a
	                                                    WHERE idflusso = {idflusso}
	                                                    ORDER BY importoversamento DESC,
	                                                    (
		                                                    SELECT COUNT(idflusso)
		                                                    FROM flussocreditidetail b
		                                                    WHERE b.idflusso = {idflusso}
                                                                and ninv is not null and nestim is not null
                                                                and b.codicetassonomia = a.codicetassonomia
		                                                    GROUP BY b.codicetassonomia
	                                                    ) DESC,
	                                                    iddetail");
         
            if (Righe_unlinked.Rows.Count > 0) {
                object codiceTassonomiaPreval = Righe_unlinked.Rows[0]["codicetassonomia"];
                foreach (var r in DS.flussocreditidetail_unlinked.Select()) {
                    r["codicetassonomia"] = codiceTassonomiaPreval;
                }
            }

            Meta.FreshForm();
        }

        private void AggiornaDSdiOrigine(DataSet newDS) {
            DataTable tFlussocrediti_new = newDS.Tables["flussocrediti"];
            DS.flussocrediti.Clear();
            foreach (var r in tFlussocrediti_new.Select()){
                DS.flussocrediti.ImportRow(r);
            }

            DS.flussocrediti.AcceptChanges();

            DS.flussocreditidetail_ca.Clear();
            DS.flussocreditidetail_fatt.Clear();
            DS.flussocreditidetail_unlinked.Clear();
            foreach (DataRow R in newDS.Tables["flussocreditidetail"].Select()) {
                if (R["nestim"] != DBNull.Value) {
                    DS.flussocreditidetail_ca.ImportRow(R);
                    continue;
                }
                if (R["ninv"] != DBNull.Value) {
                    DS.flussocreditidetail_fatt.ImportRow(R);
                    continue;
                }
                DS.flussocreditidetail_unlinked.ImportRow(R);
            }
            DS.flussocreditidetail_ca.AcceptChanges();
            DS.flussocreditidetail_fatt.AcceptChanges();
            DS.flussocreditidetail_unlinked.AcceptChanges();
        }


        /// <summary>
        /// Esporta la tabella flusso crediti in un file o inviandola al partner tecnologico
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEsportaFlussoCrediti_Click(object sender, EventArgs e) {            
            if (GetFormData() == null) return;

            btnEsportaFlussoCrediti.Enabled = false;
            AllineaTassonomia();
            DataSet newDs = CreaDSperInvioCrediti();

            var listaErrori = PagoPaService.InviaCrediti(Conn, newDs);

            if (listaErrori != null && listaErrori.Count > 0) {
                FrmErrori.MostraErrori(this, listaErrori);
                Meta.FreshForm(true);
                btnEsportaFlussoCrediti.Enabled = true;
                return;
            }
            //Se l'invio � andato a buon fine aggiorna il DS originale
            AggiornaDSdiOrigine(newDs);
            listaErrori = new List<string>();

            
            //Reperimento degli avvisi di pagamento dal partner tecnologico
            Dictionary<string, AvvisoPagamento> cert = new Dictionary<string, AvvisoPagamento>();
            foreach (var r in DS.flussocreditidetail_ca) {
                if (r.iuv == null) continue;
                if (cert.ContainsKey(r.iuv)) continue;
                string result;
                cert[r.iuv] = PagoPaService.ottieniAvvisoPagamento(Conn, r.iuv,  out result);
                if (result != null) listaErrori.Add(result);
            }
            foreach (var r in DS.flussocreditidetail_fatt) {
                if (r.iuv == null) continue;
                if (cert.ContainsKey(r.iuv)) continue;
                string result;
                cert[r.iuv] = PagoPaService.ottieniAvvisoPagamento(Conn, r.iuv,  out result);
                if (result != null) listaErrori.Add(result);
            }
            foreach (var r in DS.flussocreditidetail_unlinked) {
                if (r.iuv == null) continue;
                if (cert.ContainsKey(r.iuv)) continue;
                string result;
                cert[r.iuv] = PagoPaService.ottieniAvvisoPagamento(Conn, r.iuv,  out result);
                if (result != null) listaErrori.Add(result);
            }

            DataTable config = Conn.RUN_SELECT("configsmtp", "*", null, null, null, false);
            if (config.Rows.Count == 0) {
                show("Il form Gestione Notifiche non contiene campi valorizzati");
                return;
            }

            string cc = config.Rows[0]["email_cc"].ToString();
            //if (cc.Trim() == "") {
            //    show("Non � stato configurato un indirizzo email in copia conoscenza");
            //    return;
            //}

            //Invio delle mail dei certificati
            foreach (var avviso in cert.Keys) {
                var avvPag = cert[avviso];
                if (avvPag == null) continue;
                if (string.IsNullOrEmpty(avvPag.email)) {
                    listaErrori.Add("Il debitore " + avvPag.debitore + " non ha fornito l'email");
                    continue;
                }
                //Curr["attachment"] = avvPag.pdf;
                //Curr["filename"] = "avvisoPagoPA_" + avvPag.iuv + ".pdf";
                var error = PagoPaService.InviaAvvisoPagamento(avvPag.ente, avvPag.debitore, avvPag.email, avvPag.pdf,cc,
                    Conn);
                if (error != null) listaErrori.Add(error);
            }
            if (listaErrori.Count > 0) {
                FrmErrori.MostraErrori(this, listaErrori);
            }
            else {
                show(this, "Flusso correttamente inviato", "Avviso");
            }



        }

        string maxLen(string s, int len) {
            if (s == null) return null;
            if (s.Length < len) return s;
            return s.Substring(0, len);
        }
   
        /// <summary>
        /// Invia i crediti al webservice di govpay. Lasciamo generare a govpay lo IUV. Non gestiamo al momento l'invio della mail
        ///  al percipiente.
        /// </summary>

        private void buttonInsertFatt_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);

            string MyFilter = GetFilterForLinking_Invoice(QHS);

            string filterinvoice = "";  
            int rowsCount = 0;
            foreach (DataRow R in DS.flussocreditidetail_fatt.Select()) {
                rowsCount++;
                if (R.RowState != DataRowState.Added) continue;
                if (R["idinvkind"] == DBNull.Value) continue; //Non � una riga collegata a dettagli fattura, non dovrebbe accadere
                if (rowsCount == 1)
                    filterinvoice = QHS.DoPar(QHS.AppAnd(QHS.CmpMulti(R, "idinvkind", "yinv", "ninv"),QHS.CmpEq("rownum", R["invrownum"])));
                else
                    filterinvoice = QHS.AppOr(filterinvoice, QHS.DoPar(QHS.AppAnd(QHS.CmpMulti(R, "idinvkind", "yinv", "ninv"), QHS.CmpEq("rownum", R["invrownum"]))));
            }
            if (rowsCount > 0) MyFilter = QHS.AppAnd(MyFilter, QHS.Not(filterinvoice));


            string command = "choose.invoicedetail.flussocrediti." + MyFilter;

            MetaData.Choose(this, command);
        }

        private void btnAggiungiContratti_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);
            DataTable T = DS.flussocreditidetail_ca;
            DataRow R = DS.flussocrediti.Rows[0];

            FrmWizardScegliDettagliContratto F = new FrmWizardScegliDettagliContratto(Meta, T);
            createForm(F, this);
            if (F.ShowDialog(this) != DialogResult.OK)
                return;
            DataRow[] Selected = F.SelectedRows;
            if (Selected == null)
                return;
            if (Selected.Length == 0)
                return;
            MetaData FD = MetaData.GetMetaData(this, "flussocreditidetail");
            

            FD.ComputeRowsAs(DS.flussocreditidetail_fatt, "posting");
            FD.ComputeRowsAs(DS.flussocreditidetail_ca, "posting");

            FD.SetDefaults(DS.flussocrediti);
            foreach (DataRow Curr in Selected) {
                DataRow FlussoDet = FD.Get_New_Row(R, DS.flussocreditidetail_ca);
                foreach (string colname in
                    new string[] {
                        "idestimkind", "yestim", "nestim", "rownum"
                    }) {
                    FlussoDet[colname] = Curr[colname];
                }
                decimal taxable_euro = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("estimatedetailview", QHS.CmpKey(Curr), "taxable_euro"));
                //double importoversamento = CfgFn.GetNoNullDouble(Curr["taxable_euro"]);
                FlussoDet["importoversamento"] = taxable_euro;
                FlussoDet["!estimkind"] = Curr["estimkind"];
                FlussoDet["description"] = Curr["detaildescription"];
                FlussoDet["idreg"] = Curr["idreg_main"];
                FlussoDet["cf"] = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", Curr["idreg_main"]), "cf");
                FlussoDet["codicetassonomia"] = Curr["codicetassonomia"];
                string filterEstimSql = QHS.MCmp(Curr, "idestimkind", "yestim", "nestim");
                object scadenza = Curr["proceedsexpiring"];
                if (scadenza == DBNull.Value) {
	                scadenza = CalcolaDataScadenza(filterEstimSql, "E");
                }
                FlussoDet["expirationdate"] =   scadenza;
            }
            Meta.myGetData.GetTemporaryValues(DS.flussocreditidetail_ca);
            Meta.FreshForm();
        }

        private void btnAggiungiFatture_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataTable T = DS.flussocreditidetail_fatt;
            DataRow R = DS.flussocrediti.Rows[0];

            FrmWizardScegliDettagliFattura F = new FrmWizardScegliDettagliFattura(Meta, T);
            createForm(F, this);
            if (F.ShowDialog(this) != DialogResult.OK)
                return;
            DataRow[] Selected = F.SelectedRows;
            if (Selected == null)
                return;
            if (Selected.Length == 0)
                return;
            MetaData FD = MetaData.GetMetaData(this, "flussocreditidetail");
            FD.ComputeRowsAs(DS.flussocreditidetail_fatt, "posting");
            FD.ComputeRowsAs(DS.flussocreditidetail_ca, "posting");

            FD.SetDefaults(DS.flussocrediti);
            foreach (DataRow Curr in Selected) {
                object flagsplit = Conn.DO_READ_VALUE("invoice",
                    QHS.AppAnd(QHS.CmpEq("idinvkind", Curr["idinvkind"]),
                        QHS.CmpEq("yinv", Curr["yinv"]),
                        QHS.CmpEq("ninv", Curr["ninv"])
                    ), "flag_enable_split_payment", null);

                DataRow FlussoDet = FD.Get_New_Row(R, DS.flussocreditidetail_fatt);
                foreach (string colname in
                    new string[] {
                        "idinvkind", "yinv", "ninv"}) {
                    FlussoDet[colname] = Curr[colname];
                }

                decimal taxable_euro = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("invoicedetailview", QHS.CmpKey(Curr), "taxable_euro"));

                //double importoversamento = taxable_euro; //CfgFn.GetNoNullDouble(Curr["taxable_euro"]); //era taxable
                FlussoDet["importoversamento"] = taxable_euro;

                if (flagsplit.ToString().ToUpper() != "S") {
                    decimal iva_euro = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("invoicedetailview",
                        QHS.CmpKey(Curr), "iva_euro"));
                    //importo += iva_euro; //CfgFn.GetNoNullDecimal(RigaSelezionata["iva_euro"]); //era iva_euro, ma tale colonna non esiste
                    FlussoDet["tax"] = iva_euro;
                }

                
                FlussoDet["!invkind"] = Curr["invoicekind"];
                FlussoDet["invrownum"] = Curr["rownum"];
                FlussoDet["description"] = Curr["detaildescription"];
                FlussoDet["idreg"] = Curr["idreg"];
                FlussoDet["codicetassonomia"] = Curr["codicetassonomia"];
                FlussoDet["cf"] = Conn.DO_READ_VALUE("registry", QHS.CmpEq("idreg", Curr["idreg"]), "cf");
                string filter_inv = QHC.MCmp(Curr, "idinvkind", "yinv", "ninv");
                FlussoDet["expirationdate"] = CalcolaDataScadenza(filter_inv, "I");
            }
            Meta.myGetData.GetTemporaryValues(DS.flussocreditidetail_fatt);
            Meta.FreshForm();
        }

        private void Frm_flussocrediti_default_Load(object sender, EventArgs e) {

        }

        private void btnAnnullaInvio_Click(object sender, EventArgs e) {
            //Solo per scopi di debug, non � da attivare in produzione
            Meta.GetFormData(true);
            DS.flussocrediti._forEach(r => r.istransmitted = "N");
            int idunivoco =   CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("flussocreditidetail",null, "MAX(idunivoco)"));
            Conn.BeginTransaction(IsolationLevel.ReadCommitted);
                    foreach (var r in DS.flussocreditidetail_ca) {
                        idunivoco++;
                        if (!AnnullaRigaFlussoCreditiDetail(Conn, r, idunivoco)) { 
                        Conn.RollBack();
                        return;
                }
            }
            foreach (var r in DS.flussocreditidetail_fatt) {
                idunivoco++;
                if (!AnnullaRigaFlussoCreditiDetail(Conn, r, idunivoco)) {
                        Conn.RollBack();
                        return;
                    }
            }
            foreach (var r in DS.flussocreditidetail_unlinked) {
                idunivoco++;
                if (!AnnullaRigaFlussoCreditiDetail(Conn, r, idunivoco)) {
                            Conn.RollBack();
                            return;
                        }
            }
 
            Conn.Commit();
            Meta.FreshForm(false);
      }
        
    private bool AnnullaRigaFlussoCreditiDetail(DataAccess Conn, DataRow row, int idunivoco) {
        string[] columns = new string[] { "iuv", "qrcodevalue", "qrcodeimage",
                                "barcodevalue", "barcodeimage", "codiceavviso","idunivoco" };
        string valore = QHS.quote(DBNull.Value);
        string[] values = new string[] { valore, valore, valore, valore, valore, valore, idunivoco.ToString() };
        string condition = " idflusso = '" + row["idflusso"].ToString() + "'  " +
                            " AND iddetail = '" + row["iddetail"].ToString() + "'";
            
        if (Conn.DO_UPDATE("flussocreditidetail", condition, columns, values, columns.Length) == null)
            return true;
        return false;
    }
}
}
