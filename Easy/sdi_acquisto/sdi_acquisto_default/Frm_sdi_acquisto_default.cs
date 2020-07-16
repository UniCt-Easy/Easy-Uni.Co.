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
using metaeasylibrary;
using funzioni_configurazione;
using System.Xml;
using System.Collections;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Threading;

namespace sdi_acquisto_default {
    public partial class Frm_sdi_acquisto_default : Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        MetaData Meta;

        public DataSet D;

        public Frm_sdi_acquisto_default() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.sdi_acquisto.Columns["ec_sent"], true);
            HelpForm.SetDenyNull(DS.sdi_acquisto.Columns["notcreacontabilita"], true);
        }

        protected override void Dispose(bool disposing) {
            MetaData.messageBroadcaster -= MetaData_messageBroadcaster;
            if (disposing && (components != null)) {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        bool canChangeRifAmm = false;

        string CurrListType = "default";

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            int esercizio = Conn.GetEsercizio();
            Meta.additional_search_condition = QHS.CmpLe("year(protocoldate)", esercizio);
			GetData.CacheTable(DS.uniconfig,null,null,false);

            Meta.CanInsert = false;
            bool noRestriction = false;

            bool IsAdmin = false;
            if (Meta.GetSys("IsSystemAdmin") != null)
                IsAdmin = IsAdmin || ((bool) Meta.GetSys("IsSystemAdmin"));
            object idflowchart = Conn.GetSys("idflowchart");
            //doManage = false; //solo per test TOGLIERE POI
            if (idflowchart == null || idflowchart == DBNull.Value)
                noRestriction = true; //Nessuna restrizione

            //Determina il Listingtype in base alla sicurezza
            Meta.DefaultListType = "ipa";
            CurrListType = "ipa";
            object fe_ipa_rifamm = Conn.GetUsr("fe_ipa_rifamm");
            object fe_ipa = Conn.GetUsr("fe_ipa");
            object fe_all = Conn.GetUsr("fe_all");
            //Imposta l'elenco è più ampio.
            if ((fe_all != null && fe_all.ToString().ToUpper() == "'S'") ||
                (fe_ipa != null && fe_ipa.ToString().ToUpper() == "'S'")) {
                Meta.DefaultListType = "ipa";
                CurrListType = "ipa";
            }
            else {
                if (fe_ipa_rifamm != null && fe_ipa_rifamm.ToString().ToUpper() == "'S'") {
                    Meta.DefaultListType = "iparifamm";
                    CurrListType = "iparifamm";
                }
            }

            if (CurrListType == "iparifamm") {
                chkEsisteFattura.Tag = "x?sdi_acquistoiparifammview.existsinvoice:S:N";
            }
            else {
                chkEsisteFattura.Tag = "x?sdi_acquistoipaview.existsinvoice:S:N";
            }

            object chRifAmm = Conn.GetUsr("cambia_rifamm");
            if (chRifAmm != null && chRifAmm.ToString().ToUpper() == "'S'") {
                canChangeRifAmm = true;
            }

            if (noRestriction) {
                canChangeRifAmm = true;
            }


            Meta.CanCancel = false;
            MetaData.messageBroadcaster += MetaData_messageBroadcaster;
            grpImportazioni.Enabled = true;
            btnImporta.Enabled = false;
            btnRifiuta.Enabled = false;
            btnAccetta.Enabled = false;
            btnToProtocol.Enabled = false;
        }


        void MetaData_messageBroadcaster(object sender, object e) {
            if (e.ToString() == "AggiornareCampiFE") {
                if (DS.sdi_acquisto.Rows.Count == 0)
                    return;
                DataRow Curr = DS.sdi_acquisto.Rows[0];
                //Curr["idsdi_status"] = 2; //Accettata
                Meta.FreshForm();
            }
        }

        void EnableDisableDatiFattura(bool enable) {
            txtRifAmm.ReadOnly = !canChangeRifAmm;
            txtNumeroFE.ReadOnly = !enable;
            txtDataContabile.ReadOnly = !enable;
            txtFornitoreFE.ReadOnly = !enable;
            txtDataRicezioneFE.ReadOnly = !enable;
            txtProtocolloEntrataRU.ReadOnly = !enable;
            txtIpa.ReadOnly = !enable;
            txtDescrizione.ReadOnly = !enable;
            txtTotaleFE.ReadOnly = !enable;

        }

        public bool AbilitaDisabilitaSalvaAllegati() {
            if (Meta.IsEmpty)
                return false;
            //if (!Meta.GetFormData(false))
            //    return false;
            DataRow Curr = DS.sdi_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                return false;
                ;
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;
            XmlNodeList Allegati = document.SelectNodes("//FatturaElettronicaBody/Allegati");
            if ((Allegati == null) || (Allegati.Count == 0)) {
                return false;
            }

            return true;
        }

        public void MetaData_AfterFill() {
            AbilitaDisabilitaBottoneCorreggi();
            //grpImportazioni.Enabled = false;
            gboxStato.Enabled = false;
            EnableDisableDatiFattura(false);
            btnGeneraFile.Enabled = true;
            btnSalvaAllegati.Enabled = AbilitaDisabilitaSalvaAllegati();
            grpMessaggi.Enabled = false;
            txtNomeFile.Enabled = false;
            txtNomeFilecompresso.Enabled = false;
            txtIdentificativoSdI.Enabled = false;
            txtTipoDocumento.Enabled = false;
            txtDataAccettata.ReadOnly = true;
            txtDataRifiutata.ReadOnly = true;
            txtUserAccettata.ReadOnly = true;
            txtUserRifiutata.ReadOnly = true;

            chkEsisteFattura.Enabled = false;
            object accetta_fe = Conn.GetUsr("accetta_fe");
            object rifiuta_fe = Conn.GetUsr("rifiuta_fe");
            object creaincontabilita_fe = Conn.GetUsr("creaincontabilita_fe");
            if (Meta.EditMode) {
                DataRow Curr = DS.sdi_acquisto.Rows[0];
                int stato = CfgFn.GetNoNullInt32(Curr["idsdi_status"]);
                string filterInvoice = QHS.CmpEq("idsdi_acquisto", Curr["idsdi_acquisto"]);
                int countInvoice = Conn.RUN_SELECT_COUNT("invoice", filterInvoice, true);
                if (countInvoice == 0) {
                    chkEsisteFattura.CheckState = CheckState.Unchecked;
                }
                else {
                    chkEsisteFattura.CheckState = CheckState.Checked;
                }

                // La posso ACCETTARE se : in Attesa e la lunghezza dell'ipa non è 6
                btnAccetta.Enabled = false;
                if (stato == 1 && (Curr["codice_ipa"].ToString().Length==6)) {
                    object idflowchart = Conn.GetSys("idflowchart");
                    if ((idflowchart == null ||
                         idflowchart == DBNull.Value) //Nessuna restrizione oppure è abilitato alla funzione accetta_fe 
                        || (accetta_fe != null && accetta_fe.ToString().ToUpper() == "'S'")) {
                        btnAccetta.Enabled = true;
                    }
                    else {
                        //In base alla config. della sicurezza non è abilitato ad eseguire l'operazione 
                        btnAccetta.Enabled = false;
                    }
                }
                else {
                    btnAccetta.Enabled = false;
                } //fine if per Accettarla

                btnImporta.Enabled = false;
				// La posso IMPORTARE se : Accettata oppure Decorsi i termini oppuure  la lunghezza dell'ipa non è 6 e non l'ho già importata, e devo AVER SALVATO
				if (((stato == 2) || (stato == 4)||(Curr["codice_ipa"].ToString().Length != 6)) && (countInvoice == 0) ) {
                    object idflowchart = Conn.GetSys("idflowchart");
                    if ((idflowchart == null ||
                         idflowchart == DBNull.Value
                        ) //Nessuna restrizione oppure è abilitato alla funzione creaincontabilita_fe
                        || (creaincontabilita_fe != null && creaincontabilita_fe.ToString().ToUpper() == "'S'")) {
                        btnImporta.Enabled = (Curr["notcreacontabilita"].ToString() == "N"); //true;
                    }
                    else {
                        //In base alla config. della sicurezza non è abilitato ad eseguire l'importazione
                        btnImporta.Enabled = false;
                    }
                }
                else {
                    btnImporta.Enabled = false;
                } //fine if per importaròa

                btnRifiuta.Enabled = false;
                txtRifiuto.ReadOnly = true;
                // La posso RIFIUTARE se : in Attesa e non è stato ricevuto il decorsi termini (a scanso di equivoci)
                //  e la lunghezza dell'ipa  è 6
                if (stato == 1 && Curr["dt"] == DBNull.Value && (Curr["codice_ipa"].ToString().Length==6)) {
                    object idflowchart = Conn.GetSys("idflowchart");
                    if ((idflowchart == null ||
                         idflowchart == DBNull.Value) //Nessuna restrizione oppure è abilitato alla funzione Rifiuta_fe 
                        || (rifiuta_fe != null && rifiuta_fe.ToString().ToUpper() == "'S'")) {
                        btnRifiuta.Enabled = true;
                        txtRifiuto.ReadOnly = false;
                    }
                    else {
                        //In base alla config. della sicurezza non è abilitato ad eseguire l'operazione 
                        btnRifiuta.Enabled = false;
                        txtRifiuto.ReadOnly = true;
                    }
                }
                else {
                    btnRifiuta.Enabled = false;
                    txtRifiuto.ReadOnly = true;
                } //fine if per Rifiutarla

                btnToProtocol.Enabled = false;
                txtDataRicezioneFE.ReadOnly = true;
                if (stato == 5 || stato == 6) {
                    btnToProtocol.Enabled = true;
                    txtDataRicezioneFE.ReadOnly = false;
                }
                else {
                    btnToProtocol.Enabled = false;
                    txtDataRicezioneFE.ReadOnly = true;
                }

                AbilitaDisabilitaFattdacreareincontabilita(stato, countInvoice, false);
            }

            AbilitaDisabilitaBtnImportazioni();
            MostraBottoniXMLMessaggi();
        }

        public void MostraBottoniXMLMessaggi() {
            if (Meta.IsEmpty) return;

            // mt (metadato)
            // ec (esito committente)
            // se (scarto esito)
            // dt (decorrenza termini)
            if (DS.sdi_acquisto.Rows.Count == 0) {
                return;
            }

            DataRow Curr = DS.sdi_acquisto.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) return;
            btnXMLDT.Visible = Curr["dt"] != DBNull.Value;
            btnXMLMT.Visible = Curr["mt"] != DBNull.Value;
            btnXMLEC.Visible = Curr["ec"] != DBNull.Value;
            btnXMLSE.Visible = Curr["se"] != DBNull.Value;
        }

        public void MetaData_BeforePost() {
            if (DS.sdi_acquisto.Rows.Count == 0) {
                return;
            }

            DataRow curr = DS.sdi_acquisto.Rows[0];
            if (curr.RowState == DataRowState.Deleted) return;
            object protocol = curr["arrivalprotocolnum", DataRowVersion.Current];
            int idsdi_oldstatus = CfgFn.GetNoNullInt32(curr["idsdi_status", DataRowVersion.Original]);
            int idsdi_currstatus = CfgFn.GetNoNullInt32(curr["idsdi_status", DataRowVersion.Current]);
            if ((protocol != DBNull.Value) && (idsdi_oldstatus == 5) && (idsdi_currstatus != 2) &&
                (idsdi_currstatus != 3))
                curr["idsdi_status"] = 1; // lo pongo in attesa

        }

        public void AbilitaDisabilitaFattdacreareincontabilita(int stato, int countInvoice, bool onlysecutiry) {

            if (!onlysecutiry && countInvoice > 0) {
                SubEntity_chkNoncreareincontabilita.Enabled = false;
                SubEntity_txtFattDanoncreareincontabilita.Enabled = false;
                return;
            }

            if (!onlysecutiry && stato != 2 && stato != 4 && stato != 3) {
                SubEntity_chkNoncreareincontabilita.Enabled = false;
                SubEntity_txtFattDanoncreareincontabilita.Enabled = false;
                return;
            }

            object notcreacontabilita = Conn.GetUsr("notcreacontabilita");
            bool function_enabled = ((notcreacontabilita != null && notcreacontabilita.ToString().ToUpper() == "'S'"));
            bool noRestriction = false;
            object idflowchart = Conn.GetSys("idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) {
                noRestriction = true;
            }

            SubEntity_chkNoncreareincontabilita.Enabled = function_enabled || noRestriction;
            SubEntity_txtFattDanoncreareincontabilita.Enabled = function_enabled || noRestriction;
        }

        public void AbilitaDisabilitaBtnImportazioni() {
            if (!Meta.IsEmpty) {
                btnImporta_ipa_rif.Enabled = false;
                btnImporta_ipa.Enabled = false;
                btnImporta_all.Enabled = false;
                return;
            }

            object idflowchart = Conn.GetSys("idflowchart");
            if (idflowchart == null || idflowchart == DBNull.Value) {
                //Nessuna restrizione
                btnImporta_ipa_rif.Enabled = true;
                btnImporta_ipa.Enabled = true;
                btnImporta_all.Enabled = true;
                return;
            }

            object fe_ipa_rifamm = Conn.GetUsr("fe_ipa_rifamm");
            object fe_ipa = Conn.GetUsr("fe_ipa");
            object fe_all = Conn.GetUsr("fe_all");
            if (fe_ipa_rifamm != null && fe_ipa_rifamm.ToString().ToUpper() == "'S'") {
                btnImporta_ipa_rif.Enabled = true;
            }
            else {
                btnImporta_ipa_rif.Enabled = false;
            }

            if (fe_ipa != null && fe_ipa.ToString().ToUpper() == "'S'") {
                btnImporta_ipa.Enabled = true;
            }
            else {
                btnImporta_ipa.Enabled = false;
            }

            if (fe_all != null && fe_all.ToString().ToUpper() == "'S'") {
                btnImporta_all.Enabled = true;
            }
            else {
                btnImporta_all.Enabled = false;
            }
        }

        public void MetaData_AfterClear() {
            grpImportazioni.Enabled = true;
            btnGeneraFile.Enabled = false;
            btnSalvaAllegati.Enabled = false;
            btnImporta.Enabled = false;
            btnRifiuta.Enabled = false;
            btnAccetta.Enabled = false;
            btnToProtocol.Enabled = false;
            gboxStato.Enabled = true;

            EnableDisableDatiFattura(true);
            txtRifiuto.ReadOnly = false;
            txtRifiuto.Text = "";
            grpMessaggi.Enabled = true;
            txtNomeFile.Enabled = true;
            txtNomeFilecompresso.Enabled = true;
            txtIdentificativoSdI.Enabled = true;
            txtTipoDocumento.Enabled = true;
            chkEsisteFattura.Enabled = true;
            AbilitaDisabilitaBtnImportazioni();
            txtRifAmm.ReadOnly = false;
            btnXMLDT.Visible = true;
            btnXMLMT.Visible = true;
            btnXMLEC.Visible = true;
            btnXMLSE.Visible = true;
            chkEsisteFattura.CheckState = CheckState.Indeterminate;
            AbilitaDisabilitaBottoneCorreggi();
            txtDataAccettata.ReadOnly = false;
            txtDataRifiutata.ReadOnly = false;
            txtUserAccettata.ReadOnly = false;
            txtUserRifiutata.ReadOnly = false;
            AbilitaDisabilitaFattdacreareincontabilita(0, 0, true);
            //AvvisoMostrato = false;
        }

        private DataRow SelezionaTipoDocumento(string filterTipodoc) {
            filterTipodoc =
                QHC.AppAnd(filterTipodoc, QHC.CmpEq("active", "S"),
                    QHC.BitClear("flag", 0)); //(flag & 1) == 0 : prende solo quelle di acquisto
            DataTable MyInvoicekind = Conn.RUN_SELECT("invoicekind", "*", null, filterTipodoc, null, false);
            Conn.DeleteAllUnselectable(MyInvoicekind);
            int countInvKind = MyInvoicekind.Select(filterTipodoc).Length;
            if (countInvKind == 1) {
                DataRow rInvoicekind = MyInvoicekind.Select(filterTipodoc)[0];
                return rInvoicekind;
            }

            //Ne trova più di una, quindi delega la scelta all'utente
            if (countInvKind > 1) {
                string VistaScelta = "invoicekind";
                MetaData MInvoicekind = MetaData.GetMetaData(this, VistaScelta);
                MInvoicekind.FilterLocked = true;
                MInvoicekind.DS = DS;
                //MessageBox.Show("Sono stati trovati diversi tipi Documento IVA idonei. Selezionare quello più appropriato.");
                DataRow MyDR = MInvoicekind.SelectOne("default", filterTipodoc, null, null);
                if (MyDR != null) {
                    return MyDR;
                }
            }

            return null;
        }

        private object IndividuaAnagrafica(string IdFiscaleIVA, string Denominazione) {
            string filterAnagrDenominazione = "";
            object idreg = DBNull.Value;
            string filterAnagrafica = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.CmpEq("p_iva", IdFiscaleIVA));
            DataTable tAnag = Conn.RUN_SELECT("registry", "*", null, filterAnagrafica, null, false);
            int countReg = tAnag.Rows.Count;
            //La trova con la p.iva
            if (countReg == 1) {
                DataRow rRegistry = tAnag.Rows[0];
                idreg = rRegistry["idreg"];
                return idreg;
            }

            //Ne ha trovate più di una con quella p.iva
            if (countReg > 1) {
                string VistaScelta = "registrymainview";
                MetaData MRegistry = MetaData.GetMetaData(this, VistaScelta);
                MRegistry.FilterLocked = true;
                MRegistry.DS = DS;
                DataRow MyDR = MRegistry.SelectOne("default", filterAnagrafica, null, null);
                if (MyDR != null) {
                    idreg = MyDR["idreg"];
                    return idreg;
                }
            }

            //Non ne ha trovate con quella p.iva, e prova con la denominazione
            filterAnagrDenominazione = QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.Like("title", "%" + Denominazione));
            tAnag = Conn.RUN_SELECT("registry", "*", null, filterAnagrDenominazione, null, false);
            countReg = tAnag.Rows.Count;
            //Ne trova un con quella denominazione
            if (countReg == 1) {
                DataRow rRegistry = tAnag.Rows[0];
                idreg = rRegistry["idreg"];
                return idreg;
            }

            //Ne ha trovate più di una con quella denominazione
            if (countReg > 1) {
                string VistaScelta = "registrymainview";
                MetaData MRegistry = MetaData.GetMetaData(this, VistaScelta);
                MRegistry.FilterLocked = true;
                MRegistry.DS = DS;
                DataRow MyDR = MRegistry.SelectOne("default", filterAnagrDenominazione, null, null);
                if (MyDR != null) {
                    idreg = MyDR["idreg"];
                    return idreg;
                }
            }

            return idreg;
        }

        private object IndividuaTipoDocumento(string codiceIPA, string riferimentoAmministrazione, bool variation) {
            object idinvkind = DBNull.Value;
            string
                filterTipodocSql =
                    QHS.CmpEq("active",
                        "S"); //, QHS.BitClear("flag", 0));//(flag & 1) == 0 : prende solo quelle di acquisto
            if (variation) {
                filterTipodocSql = QHS.AppAnd(filterTipodocSql,
                    QHS.DoPar(QHS.AppOr(QHS.BitSet("flag", 2),
                        QHS.BitSet("flag", 0)))); //(flag & 4) <> 0: prende solo le variazioni
            }
            else {
                filterTipodocSql =
                    QHS.AppAnd(filterTipodocSql, QHS.BitClear("flag", 2),
                        QHS.BitClear("flag", 0)); //(flag & 4) = 0: prende solo le fatture, no variazioni
            }



            //Filtra le righe invoicekind aventi: invoicekind.ipa_fe uguale a quello del file OR invoicekind.ipa_fe is null, e solo quelli utilizzabili per la FE.
            filterTipodocSql = QHS.AppAnd(filterTipodocSql, QHS.CmpEq("enable_fe", "S"),
                QHS.DoPar(QHC.AppOr(QHS.CmpEq("ipa_fe", codiceIPA), QHS.IsNull("ipa_fe"))));

            // Filtra per Rif.Amm. se il ListingType è IpaRifamm e il campo è valorizzato nel tracciato
            if ((CurrListType == "iparifamm") && (riferimentoAmministrazione != "")) {
                filterTipodocSql = QHC.AppAnd(filterTipodocSql,
                    QHS.DoPar(QHS.AppOr(QHS.CmpEq("riferimento_Amministrazione", riferimentoAmministrazione),
                        QHS.IsNull("riferimento_Amministrazione"))));
            }

            DataTable MyInvoicekind = Conn.RUN_SELECT("invoicekind", "*", null, filterTipodocSql, null, false);
            Conn.DeleteAllUnselectable(MyInvoicekind);
            int countInvKind = MyInvoicekind.Select().Length;
            if (countInvKind == 1) {
                DataRow rInvoicekind = MyInvoicekind.Select()[0];
                idinvkind = rInvoicekind["idinvkind"];
                return idinvkind;
            }

            //Ne trova più di una, quindi delega la scelta all'utente
            if (countInvKind > 1) {
                string VistaScelta = "invoicekind";
                MetaData MInvoicekind = MetaData.GetMetaData(this, VistaScelta);
                MInvoicekind.FilterLocked = true;
                MInvoicekind.DS = DS;
                MessageBox.Show(this,
                    "Sono stati trovati diversi tipi Documento IVA idonei. Selezionare quello più appropriato.",
                    "Avviso");
                DataRow MyDR = MInvoicekind.SelectOne("default", filterTipodocSql, null, null);
                if (MyDR != null) {
                    idinvkind = MyDR["idinvkind"];
                    return idinvkind;
                }
            }

            return idinvkind;
        }


        static string getXmlText(XmlNode x, string xpath) {
            try {
                XmlNode n = x.SelectSingleNode(xpath);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch {
            }

            return null;
        }

        private void ElaboraFileFattura() {
            if (Meta.IsEmpty)
                return;
            if (!Meta.GetFormData(false)) return;
			if (DS.sdi_acquisto.Rows.Count == 0) return;
            DataRow Curr = DS.sdi_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file da importare\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());

            object idreg = DBNull.Value;
            object idinvkind = DBNull.Value;

            string idPaese = getXmlText(document,
                "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/IdFiscaleIVA/IdPaese");
            string idCodice = getXmlText(document,
                "//FatturaElettronicaHeader/CedentePrestatore/DatiAnagrafici/IdFiscaleIVA/IdCodice");
            string idFiscaleIva = "";
            if (idPaese == "IT") {
                //La partita IVA italiana è composta da 11 caratteri numerici. In registry abbiamo solo gli 11 numeri, per cui dobbiamo confrontare la p.iva solo con i numeri
                //Se invece fosse estera, avremmo anche la sigla della nazione.  
                idFiscaleIva = idCodice;
            }
            else {
                idFiscaleIva = idPaese + idCodice;
            }

            // Individua l'ANAGRAFICA
            string Denominazione = Curr["title"].ToString();
            idreg = IndividuaAnagrafica(idFiscaleIva, Denominazione);
            if (CfgFn.GetNoNullInt32(idreg) == 0) {
                string messaggio;
                messaggio = $"Non è stata trovata alcuna anagrafica con Partita IVA: {idFiscaleIva} o denominazione : {Denominazione}.";
                MessageBox.Show(this, messaggio, "Avviso");
                //Apre un form per consentire all'utente la scelta dell'Anagrafica
                FrmAskAnagrafica F = new FrmAskAnagrafica(Meta, Meta.Dispatcher);
                if (F.ShowDialog(this) != DialogResult.OK)
                    return;
                idreg = F.idreg;
            }

            // Tipo Documento
            string TipoDocumentoTD = getXmlText(document,
                "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/TipoDocumento");
            bool variation = false;
            //Da richiesta di Cinzia del 19/06/2015, ore 9:32
            /*
             * la nota di debito infatti no è altro che l'integrazione di una fattura precedentemente emessa e non è una nota di credito
                [09:32:06] Cinzia Vino: Dal punto di vista materiale, la nota di debito presenta la struttura tipica della fattura, in particolare deve essere numerata seguendo 
             * la progressività delle fatture emesse, deve indicare la data di emissione, il numero di fattura a cui si riferisce e tutti i dati previsti
             * in materia di emissione delle fatture dall’art.21 DPR633/72. Tale documento deve inoltre essere rilevato nel registro delle fatture emesse.
             *          */
            if ((TipoDocumentoTD == "TD04")) { //||(TipoDocumentoTD == "TD05")
                variation = true;
            }

            //Individua il TIPO DOCUMENTO
            string codiceIPA = Curr["codice_ipa"].ToString();
            string riferimentoAmministrazione = Curr["riferimento_amministrazione"].ToString();

            idinvkind = IndividuaTipoDocumento(codiceIPA, riferimentoAmministrazione, variation);
            if (CfgFn.GetNoNullInt32(idinvkind) == 0) {
                string messaggio;
                messaggio = $"Non è stato individuato univocamente un Tipo documento. L'IPA della F.E. è: {codiceIPA}.";
                MessageBox.Show(this, messaggio, "Avviso");
                //Fa scegliere all'utente un Tipo documento tra quelli senza ipa
                string filterIdinvkind = QHS.IsNull("ipa_fe");
                filterIdinvkind = QHC.AppAnd(filterIdinvkind,
                    QHC.AppAnd(QHC.CmpEq("active", "S"),
                        QHC.BitClear("flag", 0))); //(flag & 1) == 0 : prende solo quelle di acquisto
                if (variation) {
                    filterIdinvkind =
                        QHC.AppAnd(filterIdinvkind, QHC.BitSet("flag", 2)); //(flag & 4) <> 0: prende solo le variazioni
                }
                else {
                    filterIdinvkind =
                        QHC.AppAnd(filterIdinvkind,
                            QHC.BitClear("flag", 2)); //(flag & 4) = 0: prende solo le fatture, no variazioni
                }

                filterIdinvkind =
                    QHC.AppAnd(filterIdinvkind, QHC.CmpEq("enable_fe", "S")); //solo i tipi utilizzabili nella FE

                DataRow rInvoicekind = SelezionaTipoDocumento(filterIdinvkind);
                if (rInvoicekind != null) {
                    idinvkind = rInvoicekind["idinvkind"];
                }
                else {
                    return;
                }
            }

            bool parcella = false;
            if (TipoDocumentoTD == "TD06") {
                parcella = true;
            }

            Meta.SaveFormData();
            if (Meta.DS.HasChanges()) {
                MessageBox.Show("Errore nel salvataggio", "Errore");
                return;
            }

            MetaData MetaInvoice = MetaData.GetMetaData(this, "invoice");
            MetaInvoice.SetUsr("sdi_acquisto", "S");
            MetaInvoice.SetUsr("broadcastEnabledInvoice", true);
            MetaInvoice.Edit(Meta?.linkedForm?.ParentForm, "default", false);
            if (MetaInvoice==null || MetaInvoice.destroyed) return;
            MetaInvoice.dontClose = true;
            D = MetaInvoice?.ds;
            if (D == null) {
                MessageBox.Show(@"Non sono riuscito a caricare il form delle fatture", @"Errore");
                return;
            }

            DataTable Invoice = D.Tables["invoice"];
            DataTable InvoiceDetail = D.Tables["invoicedetail"];

            MetaInvoice.SetDefaults(Invoice);

            MetaData MetaInvoiceDetail = MetaData.GetMetaData(this, "invoicedetail");
            MetaInvoiceDetail.SetDefaults(InvoiceDetail);

            if (MetaInvoice==null || MetaInvoice.destroyed) return;
            //ToMeta.PrimaryDataTable. è la tabella principale del form creato
            Hashtable saveddefaults = new Hashtable();
            foreach (DataColumn C in MetaInvoice.PrimaryDataTable.Columns) {
                saveddefaults[C.ColumnName] = C.DefaultValue;
            }



            MetaData.SetDefault(Invoice, "idinvkind", idinvkind);

            MetaData.SetDefault(InvoiceDetail, "idinvkind", idinvkind);
            MetaData.SetDefault(Invoice, "idreg", idreg);

            if (codiceIPA != null) MetaData.SetDefault(Invoice, "ipa_acq", codiceIPA);
            if (riferimentoAmministrazione != null)
                MetaData.SetDefault(Invoice, "rifamm_acq", riferimentoAmministrazione);

            string Numero = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Numero");
            object NumeroObj = Numero;
            if (NumeroObj != null) MetaData.SetDefault(Invoice, "doc", NumeroObj);

            string sData = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Data");
            DateTime dData = XmlConvert.ToDateTime(sData, XmlDateTimeSerializationMode.Unspecified);
            if (dData != null) MetaData.SetDefault(Invoice, "docdate", dData);

            string Causale = getXmlText(document,
                "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Causale");
            if (Causale != null) {
                if (Causale.Length > 150) {
                    MetaData.SetDefault(Invoice, "description", Causale.Substring(0, 150));
                }
                else {
                    MetaData.SetDefault(Invoice, "description", Causale);
                }
            }

            string CondizioniPagamento = getXmlText(document, "//FatturaElettronicaBody/DatiPagamento");
            if (CondizioniPagamento != null) {
                MetaData.SetDefault(Invoice, "idfepaymethodcondition", CondizioniPagamento);
            }

            string ModalitaPagamento = getXmlText(document,
                "//FatturaElettronicaBody/DatiPagamento/DettaglioPagamento/ModalitaPagamento");
            if (ModalitaPagamento != null) {
                MetaData.SetDefault(Invoice, "idfepaymethod", ModalitaPagamento);
            }

            MetaData.SetDefault(Invoice, "idsdi_acquisto", Curr["idsdi_acquisto"]);

            object Myprotocoldate = Curr["protocoldate"];
            if (Myprotocoldate == DBNull.Value) {
                MessageBox.Show("La fattura non ha la data di protocollo", "Avviso");
                return;
            }

            DateTime DTprotocoldate = Convert.ToDateTime(Myprotocoldate).Date;
            MetaData.SetDefault(Invoice, "protocoldate", DTprotocoldate);
            MetaData.SetDefault(Invoice, "arrivalprotocolnum", Curr["arrivalprotocolnum"]);

            string Valuta = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/Divisa");
            if (Valuta == "ITA") Valuta = "EUR";
            decimal Cambio = 0;
            object idcurrency = null;
            if (Valuta != "EUR") {
                //Se la valuta è diversa da Euro/Lira Italiana, chiede il tasso di cambio
                while (CfgFn.GetNoNullDecimal(Cambio) == 0) {
                    FrmAskCambio FC = new FrmAskCambio(1);
                    if (FC.ShowDialog(this) != DialogResult.OK) {
                        Cambio = 1;
                    }
                    else {
                        Cambio = CfgFn.GetNoNullDecimal(FC.Cambio);
                    }

                }
            }

            DataTable tCurrency =
                Conn.RUN_SELECT("currency", "*", null, QHS.CmpEq("codecurrency", Valuta), null, false);
            if (tCurrency == null) {
                string messaggio;
                messaggio = $"Non è stato trovata la Valuta :{Valuta}. La valuta verrà impostata come Euro.";
                MessageBox.Show(this, messaggio, @"Avviso");
                MetaData.SetDefault(Invoice, "idcurrency",
                    Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency"));
            }
            else {
                if (tCurrency.Rows.Count > 0) {
                    DataRow rCurrency = tCurrency.Rows[0];
                    idcurrency = rCurrency["idcurrency"];
                    MetaData.SetDefault(Invoice, "idcurrency", CfgFn.GetNoNullInt32(idcurrency));
                }
            }

            MetaData.SetDefault(Invoice, "exchangerate", Cambio);
            MetaInvoice.DoMainCommand("maininsert");
            MetaInvoice.SetUsr("sdi_acquisto", null);
            if (parcella) {
                MetaData.sendBroadcast(this, "apriFormImportaFattureElettronicheParcella");
            }
            else {
                MetaData.sendBroadcast(this, "apriFormImportaFattureElettroniche");
            }

            // Ripristina i vecchi defaults
            foreach (DataColumn CC in MetaInvoice.PrimaryDataTable.Columns) {
                CC.DefaultValue = saveddefaults[CC.ColumnName];
            }

            MetaInvoice.dontClose = false;
        }


        private void btnImporta_ipa_rif_Click(object sender, EventArgs e) {
            string listtype = "iparifamm";
            //Fatture da accettare/Rifiutare = stato in attesa
            //Fatture da importare = stato Accettata oppure Decorsi i termini e non l'ho già importata
            string FirstSearchFilter = QHC.DoPar(QHS.AppOr(
                QHC.CmpEq("idsdi_status", 1), // in attesa
                QHC.CmpEq("idsdi_status", 2), //accettate
                QHC.CmpEq("idsdi_status", 4), //Decorsi i termini 
                QHC.CmpEq("idsdi_status", 5), //Da protocollare(causa problemi col servizio)
                QHC.CmpEq("idsdi_status", 6) //Da protocollare(inserita via web)
            ));
            FirstSearchFilter = QHC.AppAnd(FirstSearchFilter, QHC.IsNull("idinvkind")); //e non l'ho importata
            FirstSearchFilter =
                QHC.AppAnd(FirstSearchFilter,
                    QHC.CmpEq("notcreacontabilita",
                        "N")); //E' una fattura per cui è consentita la Creazione in contabilità
            MetaData.DoMainCommand(this,
                "maindosearch" + "." + listtype + "." + FirstSearchFilter); // sdi_acquistoiparifammview
        }

        private void btnImporta_ipa_Click(object sender, EventArgs e) {
            string listtype = "ipa";
            //Fatture da accettare/Rifiutare = stato in attesa
            //Fatture da importare = stato Accettata oppure Decorsi i termini e non l'ho già importata
            string FirstSearchFilter = QHC.DoPar(QHS.AppOr(
                QHC.CmpEq("idsdi_status", 1), // in attesa
                QHC.CmpEq("idsdi_status", 2), //accettate
                QHC.CmpEq("idsdi_status", 4), //Decorsi i termini 
                QHC.CmpEq("idsdi_status", 5), //Da protocollare(causa problemi col servizio)
                QHC.CmpEq("idsdi_status", 6) //Da protocollare(inserita via web)
            ));
            FirstSearchFilter = QHC.AppAnd(FirstSearchFilter, QHC.IsNull("idinvkind")); //e non l'ho importata
            FirstSearchFilter =
                QHC.AppAnd(FirstSearchFilter, QHC.IsNotNull("ipa_fe")); //solo quelle con ipa_fe not null
            FirstSearchFilter =
                QHC.AppAnd(FirstSearchFilter,
                    QHC.CmpEq("notcreacontabilita",
                        "N")); //E' una fattura per cui è consentita la Creazione in contabilità
            MetaData.DoMainCommand(this,
                "maindosearch" + "." + listtype + "." + FirstSearchFilter); //sdi_acquistoipaview 
        }

        private void btnImporta_all_Click(object sender, EventArgs e) {
            string listtype = "ipa";
            //Fatture da accettare/Rifiutare = stato in attesa
            //Fatture da importare = stato Accettata oppure Decorsi i termini e non l'ho già importata
            string FirstSearchFilter = QHC.DoPar(QHS.AppOr(
                QHC.CmpEq("idsdi_status", 1), // in attesa
                QHC.CmpEq("idsdi_status", 2), //accettate
                QHC.CmpEq("idsdi_status", 4), //Decorsi i termini 
                QHC.CmpEq("idsdi_status", 5), //Da protocollare(causa problemi col servizio)
                QHC.CmpEq("idsdi_status", 6) //Da protocollare(inserita via web)
            ));
            FirstSearchFilter = QHC.AppAnd(FirstSearchFilter, QHC.IsNull("idinvkind")); //e non l'ho importata
            FirstSearchFilter =
                QHC.AppAnd(FirstSearchFilter,
                    QHC.CmpEq("notcreacontabilita",
                        "N")); //E' una fattura per cui è consentita la Creazione in contabilità
            MetaData.DoMainCommand(this,
                "maindosearch" + "." + listtype + "." + FirstSearchFilter); //sdi_acquistoipaview
        }

        private void btnImporta_Click(object sender, EventArgs e) {
            ElaboraFileFattura();
        }

        private void btnVisualizza_Click(object sender, EventArgs e) {
            if (DS.sdi_acquisto.Rows.Count == 0) {
                return;
            }

            if (!Meta.GetFormData(false))
                return;

            Button btnVisualizza = (Button) sender;

            // Visualizza file xml
            //Stream transformedData = new MemoryStream();
            string tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(DS.sdi_acquisto.Rows[0]["xml"].ToString());
            string versione = doc.DocumentElement.Attributes["versione"].Value;
            string xsl = "";
            if (btnVisualizza.Name == "btnVisualizzaSempl") xsl = "fatturapa_v1.2Semplificata.xslt";
            else
                xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : "fatturapa_v1.2.xslt";
            if (DS.sdi_acquisto.Rows[0]["xml"] == DBNull.Value) return;

            try {
                XslCompiledTransform xsltransform = new XslCompiledTransform();
                xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);

                xsltransform.Transform(doc, null, xw);
                xw.Flush();
                xw.Close();
            }
            catch (Exception E) {
                MessageBox.Show("Errore aprendo la fattura selezionata", "Errore");
                DataRow Curr = DS.sdi_acquisto.Rows[0];
                string errmsg = "Frm_sdi_acquisto_default: Errore su " + xsl + ", Fattura : " + Curr["idsdi_acquisto"];
                Meta.LogError(errmsg, E);
            }


            try {
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ee) {
                QueryCreator.ShowException("Errore nella visualizzazione del file", ee);
            }

        }


        private void VisualizzaXMLMessaggi(string tipomessaggio) {
            // mt (metadato)
            // ec (esito committente)
            // se (scarto esito)
            // dt (decorrenza termini)
            if (DS.sdi_acquisto.Rows.Count == 0) {
                return;
            }

            if (!Meta.GetFormData(false))
                return;
            // Visualizza file xml
            string tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";
            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();


            if (DS.sdi_acquisto.Rows[0][tipomessaggio] == DBNull.Value)
                return;
            try {
                doc.LoadXml(DS.sdi_acquisto.Rows[0][tipomessaggio].ToString());
            }
            catch {
                return;
            }

            XslCompiledTransform xsltransform = new XslCompiledTransform();
            string filexls = "";
            if (tipomessaggio == "AT")
                filexls = tipomessaggio.ToUpper() + "_v1.1.xslt";
            else
                filexls = tipomessaggio.ToUpper() + "_v1.0.xslt";
            xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + filexls);

            xsltransform.Transform(doc, null, xw);

            xw.Flush();
            xw.Close();
            try {
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ee) {
                QueryCreator.ShowException("Errore nella visualizzazione del file", ee);
            }
        }

        //bool AvvisoMostrato = false;
        private void btnRifiuta_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataRow Curr = DS.sdi_acquisto.Rows[0];
            //if ((!AvvisoMostrato) && (txtRifiuto.Text.ToString()=="")) {
            //    MessageBox.Show(this, "E' possibile indicare la motivazione del Rifiuto nell'apposito campo.", "Avviso");
            //    AvvisoMostrato = true;
            //}
            if (MessageBox.Show("Si è deciso di Rifiutare la Fattura Elettronica. Procedo col rifiuto?", "Avviso",
                    MessageBoxButtons.OKCancel) != DialogResult.OK) {
                return;
            }
            else {
                if (txtRifiuto.Text.ToString() == "") {
                    MessageBox.Show(this, "Indicare la motivazione del Rifiuto nell'apposito campo.", "Avviso");
                    return;
                }
                else {

                    Curr["idsdi_status"] = 3; // Rifiutata
                    Curr["data_rifiutata"] = DateTime.Now;
                    Curr["utente_rifiutata"] = Conn.externalUser;
                    txtRifiuto.ReadOnly = true;
                    Meta.FreshForm();
                    Meta.SaveFormData();
                }
            }

        }

        private void btnAccetta_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            if (MessageBox.Show(this, "Si è deciso di Accettare la Fattura Elettronica. Procedo con l'Accettazione?",
                    "Avviso",
                    MessageBoxButtons.OKCancel) != DialogResult.OK) {
                return;
            }

            // Verifica condizione importo totale calcolato
            DataRow Curr = DS.sdi_acquisto.Rows[0];

            decimal total = CfgFn.GetNoNullDecimal(Curr["total"]);
            decimal total_easy = CfgFn.GetNoNullDecimal(Curr["total_easy"]);
            if (Curr["total"] != DBNull.Value && Curr["total_easy"] != DBNull.Value) {
                if (total != total_easy) {
                    if (MessageBox.Show(this,
                            "L'importo totale calcolato sui Dati di Riepilogo è di € " + total_easy.ToString("c") +
                            " SI INTENDE PROCEDERE COMUNQUE?", "Avviso",
                            MessageBoxButtons.OKCancel) != DialogResult.OK) {
                        return;
                    }
                }
            }

            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());

            XmlNodeList datiRiep = document.SelectNodes("//FatturaElettronicaBody/DatiBeniServizi/DatiRiepilogo");
            bool noEsig = false;
            if (datiRiep != null) {
                foreach (XmlNode Dettaglio in datiRiep) {
                    decimal imposta = XmlConvert.ToDecimal(getXmlText(Dettaglio, "Imposta"));
                    if (imposta == 0) continue;
                    string esig = getXmlText(Dettaglio, "EsigibilitaIVA");
                    if (esig == null || esig.ToUpper() != "S") {
                        noEsig = true;
                    }
                }
            }

            if (noEsig) {
                if (MessageBox.Show(this,
                        "Attenzione! Il fornitore ha indicato un tipo di esigibilità IVA diverso da \"Split payment\".\n" +
                        "Sei comunque certo di voler accettare la fattura?", "Avviso", MessageBoxButtons.OKCancel) !=
                    DialogResult.OK) {
                    return;
                }
            }

            Curr["idsdi_status"] = 2; // Accettata
            Curr["data_accettata"] = DateTime.Now;
            Curr["utente_accettata"] = Conn.externalUser;
            Meta.FreshForm();
            Meta.SaveFormData();

        }


        public  object getProtocolloFatturaAcquisto(DataRow r) {

	        if (DS.uniconfig.Rows[0]["webprotaddress"] == DBNull.Value) return DBNull.Value;
	        if (r["signedxml"] == DBNull.Value) {
		        QueryCreator.ShowError(this,"Riga non compatibile con la ricezione automatica del protocollo","Errore");
		        return DBNull.Value;
	        }
	        XmlDocument document = new XmlDocument();
	        document.LoadXml(r["xml"].ToString());

	        try {
		        var ws = new webReference.webProt();
		        ws.Url = DS.uniconfig.Rows[0]["webprotaddress"].ToString();
		        string xmlDocument = Convert.ToBase64String(Encoding.UTF8.GetBytes(document.OuterXml));
		        var res = ws.ottieniProtocolloFatturaAcquisto(r["filename"].ToString(),
			        DateTime.Now.Date, xmlDocument,
			        r["signedxml"].ToString(),
			        CfgFn.GetNoNullInt64(r["identificativo_sdi"]),
			        CfgFn.GetNoNullInt32(r["position"]),
			        CfgFn.GetNoNullInt32(r["idsdi_acquisto"]));
								
		        if (res.Error == null) {
			        return res.nProt;
		        }
		        QueryCreator.ShowError(this,"Errore nella ricezione del protocollo",res.Error);

	        } catch (Exception e) {
		        QueryCreator.ShowException(this,"Errore nelll'ottenimento del protocollo",e);
	        }
			
	        return DBNull.Value;
        }


        private void btnToProtocol_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(false)) return;
            DataRow curr = DS.sdi_acquisto.Rows[0];
            object arrivalProtocol = DBNull.Value;
            object oldprotocol = curr["arrivalprotocolnum", DataRowVersion.Original];
            if (oldprotocol != DBNull.Value) return;
            if (DS.uniconfig.Rows[0]["webprotaddress"] != DBNull.Value) {
	            arrivalProtocol = getProtocolloFatturaAcquisto(curr);
            }

            if (arrivalProtocol==DBNull.Value) {
				FrmAskProtocollo FP = new FrmAskProtocollo(0);
				if (FP.ShowDialog(this) == DialogResult.OK) {
					arrivalProtocol = FP.Protocollo;
				}
			}
			

			if (arrivalProtocol==null || arrivalProtocol == DBNull.Value || arrivalProtocol.ToString() == "") {
                return;
            }

            if (arrivalProtocol != DBNull.Value && arrivalProtocol.ToString() != "") {
                curr["arrivalprotocolnum"] = arrivalProtocol;
                if (curr["protocoldate"] == DBNull.Value) {
	                curr["protocoldate"] = DateTime.Now.Date;
                }
                else {
	                if (MessageBox.Show("Aggiorno la data di ricezione ?", "Conferma", MessageBoxButtons.OKCancel) ==
	                    DialogResult.OK) {
		                curr["protocoldate"] = DateTime.Now.Date;
	                }
                }
                
                if (curr["idsdi_status", DataRowVersion.Original].ToString() == "6") {
                    curr["idsdi_status"] = 2;
                }
                else {
                    curr["idsdi_status"] = 1;
                }

                if (curr["dt"] != DBNull.Value) {
                    curr["idsdi_status"] = 4;
                }

            }

            //else {
            //    curr["idsdi_status"] = curr["idsdi_status", DataRowVersion.Original];
            //    curr["arrivalprotocolnum"] = DBNull.Value;
            //}
            
			Meta.SaveFormData();

        }

        private void btnGeneraFile_Click(object sender, EventArgs e) {
            if (DS.sdi_acquisto.Rows.Count == 0) {
                return;
            }

            XmlDocument doc = new XmlDocument();
            if (DS.sdi_acquisto.Rows[0]["xml"] == DBNull.Value)
                return;

            try {
                doc.LoadXml(DS.sdi_acquisto.Rows[0]["xml"].ToString());
            }
            catch (Exception E) {
                MessageBox.Show("Errore aprendo la fattura selezionata", "Errore");
                DataRow Curr = DS.sdi_acquisto.Rows[0];
                string errmsg = "Frm_sdi_acquisto_default: Errore su fatturapa_v1.2.xslt, Fattura : " +
                                Curr["idsdi_acquisto"];
                Meta.LogError(errmsg, E);
            }


            if (doc == null)
                return;

            string fname = DS.sdi_acquisto.Rows[0]["filename"].ToString();

            string fNameNoExtension = fname.Split('.')[0];
            string extension = ".xml"; //   fname.Substring(fNameNoExtension.Length);


            saveFileDialog1.FileName =
                fNameNoExtension + "_" + DS.sdi_acquisto.Rows[0]["position"].ToString() + extension;
            DialogResult dialogResult = saveFileDialog1.ShowDialog(this);

            if (dialogResult == DialogResult.Cancel)
                return;
            fname = saveFileDialog1.FileName;

            try {
                XmlWriterSettings xs = new XmlWriterSettings();
                xs.Indent = true;
                xs.CloseOutput = true;
                xs.Encoding = Encoding.UTF8;
                XmlWriter xW = XmlWriter.Create(fname, xs);
                doc.WriteTo(xW);
                xW.Flush();
                xW.Close();
                MessageBox.Show("Salvataggio del file " + fname + " effettuato");
            }
            catch (System.IO.IOException e1) {
                MessageBox.Show(e1.Message, "Errore nel salvataggio del file " + fname);
            }
        }

        string CartellaAllegati = "";

        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                CartellaAllegati = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSalvaAllegati_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            if (!Meta.GetFormData(false))
                return;
            DataRow Curr = DS.sdi_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;
            XmlNodeList Allegati = document.SelectNodes("//FatturaElettronicaBody/Allegati");
            if (Allegati == null) {
                MessageBox.Show(this, "Non sono presenti Allegati.");
                return;
            }

            faiScegliereCartella();
            foreach (XmlNode Dettaglio in Allegati) {
                string NomeAttachment = Dettaglio["NomeAttachment"].InnerText;
                string Attachment = Dettaglio["Attachment"].InnerText;
                byte[] ByteArray = Convert.FromBase64String(Attachment);
                string FilePath = Path.Combine(CartellaAllegati, NomeAttachment);
                try {
                    ScriviFile(FilePath, ByteArray, 0);
                    //System.Diagnostics.Process.Start(FilePath);
                }
                catch (Exception E) {
                    QueryCreator.ShowException(E);
                }
            }

        }

        void ScriviFile(string sw, byte[] documento, int offset) {
            // Legge il documento e lo scrive nel file
            if (Meta.IsEmpty)
                return;
            if (!Meta.GetFormData(true))
                return;
            FileStream FS = new FileStream(sw, FileMode.Create, FileAccess.Write);
            int n = documento.Length - offset;
            if (n == 0)
                return;
            try {
                FS.Write(documento, offset, n);
                FS.Flush();
                FS.Close();
            }
            catch {
            }
        }

        int GetOffsetForData(Byte[] B) {
            int i = 0;
            while (i < B.Length && B[i] != 0)
                i++;
            return i + 1;
        }

        string GetFileName(Byte[] B) {
            int len = 0;
            for (int i = 0; i < B.Length; i++) {
                len++;
                if (B[i] == 0)
                    break;
            }

            byte[] b = new byte[len - 1];
            for (int i = 0; i < len - 1; i++) {
                b[i] = B[i];
            }

            return Encoding.Default.GetString(b);
        }

        private void btnXMLMetaDati_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("mt");
        }

        private void btnXMLNEC_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("ec");
        }

        private void btnXMLSEC_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("se");
        }

        private void btnXMLDC_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("dt");
        }

        void AbilitaDisabilitaBottoneCorreggi() {
            btnCorreggiTotaleFattura.Visible = false;
            if (Meta.IsEmpty) {
                return;
            }

            DataRow r = DS.sdi_acquisto.Rows[0];
            decimal tot = CfgFn.GetNoNullDecimal(r["total"]);
            if (r["xml"] == DBNull.Value) {
                return;
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(r["xml"].ToString());
            string sImportoTotale = getXmlText(document,
                "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/ImportoTotaleDocumento");
            if (sImportoTotale == null || sImportoTotale == "")
                return;
            decimal importoTotale = XmlConvert.ToDecimal(sImportoTotale);
            if (importoTotale == tot) {
                return;
            }

            btnCorreggiTotaleFattura.Visible = true;
        }

        private void btnCorreggiTotaleFattura_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            DataRow r = DS.sdi_acquisto.Rows[0];
            decimal tot = CfgFn.GetNoNullDecimal(r["total"]);
            if (r["xml"] == DBNull.Value) {
                return;
            }

            XmlDocument document = new XmlDocument();
            document.LoadXml(r["xml"].ToString());
            string sImportoTotale = getXmlText(document,
                "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/ImportoTotaleDocumento");
            decimal importoTotale = XmlConvert.ToDecimal(sImportoTotale);
            r["total"] = importoTotale;
            Meta.FreshForm(true);
            Meta.SaveFormData();
        }


    }
}
