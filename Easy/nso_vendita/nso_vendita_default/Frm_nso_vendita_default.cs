
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
using System.Data;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Xml;
using System.Collections;
using System.Xml.Xsl;
using System.IO;

namespace nso_vendita_default {
    public partial class Frm_nso_vendita_default : MetaDataForm {
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        MetaData Meta;

        public DataSet D;
        public const string ns_cbc = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
        public const string ns_cac = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
        public const string ns_ord = "urn:oasis:names:specification:ubl:schema:xsd:Order-2";

        // OV => Ordine di Vendita
        
        public Frm_nso_vendita_default() {
            InitializeComponent();
            saveFileDialog1.SupportMultiDottedExtensions = true;
            HelpForm.SetDenyNull(DS.nso_vendita.Columns["ec_sent"], true);
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
            Meta.additional_search_condition = QHS.CmpLe("year(adate)", esercizio);
            GetData.CacheTable(DS.uniconfig, null, null, false);

            Meta.CanInsert = false;
            bool noRestriction = false;

            bool IsAdmin = false;
            if (Meta.GetSys("IsSystemAdmin") != null)
                IsAdmin = IsAdmin || ((bool)Meta.GetSys("IsSystemAdmin"));
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
            } else {
                if (fe_ipa_rifamm != null && fe_ipa_rifamm.ToString().ToUpper() == "'S'") {
                    Meta.DefaultListType = "iparifamm";
                    CurrListType = "iparifamm";
                }
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
            btnImporta.Enabled = false;
            btnRifiuta.Enabled = false;
            btnAccetta.Enabled = false;
            btnToProtocol.Enabled = false;
        }


        void MetaData_messageBroadcaster(object sender, object e) {
            if (e.ToString() == "AggiornareCampiOV") {
                if (DS.nso_vendita.Rows.Count == 0)
                    return;
                DataRow Curr = DS.nso_vendita.Rows[0];
                Meta.FreshForm();
            }
        }

        void EnableDisableDatiOrdine(bool enable) {
            txtIdOrdine.ReadOnly = !enable;
            txtDataEmissioneOrdine.ReadOnly = !enable;
            txtIdEmittenteOrdine.ReadOnly = !enable;

            txtDataScadenzaOrdine.ReadOnly = !enable;
            txtOrderTotal.ReadOnly = !enable;
            txtOrderTaxTotal.ReadOnly = !enable;

            txtCliente.ReadOnly = !enable;
            txtClienteId.ReadOnly = !enable;
            txtClienteTaxId.ReadOnly = !enable;

            txtDataRicezioneSdI.ReadOnly = !enable;
            txtNumProtocolloEntrata.ReadOnly = !enable;
            txtProtocolDate.ReadOnly = !enable;

            txtCodiceIpa.ReadOnly = !enable;
            txtIpa.ReadOnly = !enable;
            txtRifAmm.ReadOnly = !canChangeRifAmm;

            txtDescrizione.ReadOnly = !enable;
        }

        public bool AbilitaDisabilitaSalvaAllegati() {
            if (Meta.IsEmpty)
                return false;
            //if (!Meta.GetFormData(false))
            //    return false;
            DataRow Curr = DS.nso_vendita.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                return false;
            }

            XmlDocument xml = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            xml.LoadXml(Curr["xml"].ToString());

            XmlNodeList attachmentList = xml.GetElementsByTagName("cac:AdditionalDocumentReference");

            if ((attachmentList == null) || (attachmentList.Count == 0)) {
                return false;
            }

            return true;
        }

        public void MetaData_AfterFill() {
            gboxStato.Enabled = false;
            EnableDisableDatiOrdine(false);
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
            txtEmailAvvisoRicezione.ReadOnly = true;

            /*Disabilito il bottone "Rifiuta" se la data corrente è maggiore della decorrenza dei termini*/
            DataRow dr = DS.nso_vendita.Rows[0];
            object data_ricezione = dr["data_ricezione"];

            if (data_ricezione != DBNull.Value) {
                DateTime dataRicezione = (DateTime)data_ricezione; //Convert.ToDateTime(protocolDate);
                DateTime decorrenzaTermini = new DateTime(); ;
                object orderDataScadenza = dr["order_data_scadenza"];
                if (orderDataScadenza != DBNull.Value) {
                    decorrenzaTermini = (DateTime)orderDataScadenza;
                    DateTime endDay = decorrenzaTermini.AddHours(23).AddMinutes(59).AddSeconds(59);
                    if (DateTime.Now.CompareTo(endDay) >= 0) {
                        btnRifiuta.Visible = false;
                    }
                }
              
            }

            // ==========================================================================================
            //                                      SICUREZZA
            // ==========================================================================================
            object accetta_ov = Conn.GetUsr("accetta_ov");
            object rifiuta_ov = Conn.GetUsr("rifiuta_ov");
            object creaincontabilita_ov = Conn.GetUsr("creaincontabilita_ov");

            if (Meta.EditMode) {
                DataRow Curr = DS.nso_vendita.Rows[0];
                int stato = CfgFn.GetNoNullInt32(Curr["idnso_status"]);
                object idflowchart = Conn.GetSys("idflowchart");

                string filterEstimate = QHS.CmpEq("idnso_vendita", Curr["idnso_vendita"]);
                int countEstimante = Conn.RUN_SELECT_COUNT("estimate", filterEstimate, true);

                // ==========================================================================================
                //                                      ACCETTA
                // ==========================================================================================
                btnAccetta.Enabled = false;
                // La posso ACCETTARE se: Ricevuta e la lunghezza dell'ipa è 6
                if (stato == 1 && (Curr["codice_ipa"].ToString().Length == 6)) {                                     
                    //Nessuna restrizione oppure è abilitato alla funzione accetta_fe 
                    if ((idflowchart == null || idflowchart == DBNull.Value) || (accetta_ov != null && accetta_ov.ToString().ToUpper() == "'S'")) {
                        btnAccetta.Enabled = true;
                    }
                }

                // ==========================================================================================
                //                                      IMPORTA
                // ==========================================================================================
                btnImporta.Enabled = false;
                // La posso IMPORTARE se: Accettata, o Decorsi i termini, o non l'ho già importata, e devo AVER SALVATO
                if (((stato == 2) || (stato == 4) || (Curr["codice_ipa"].ToString().Length != 6)) && (countEstimante == 0)) {
                    //Nessuna restrizione oppure è abilitato alla funzione creaincontabilita_ov
                    if ((idflowchart == null || idflowchart == DBNull.Value) || (creaincontabilita_ov != null && creaincontabilita_ov.ToString().ToUpper() == "'S'")) {
                        btnImporta.Enabled = true;
                    }
                }

                // ==========================================================================================
                //                                      RIFIUTO
                // ==========================================================================================
                btnRifiuta.Enabled = false;
                txtRifiuto.ReadOnly = true;
                // La posso RIFIUTARE se:   Ricevuto e la lunghezza dell'ipa è 6
                if (stato == 1 && (Curr["codice_ipa"].ToString().Length == 6)) {
                    //Nessuna restrizione oppure è abilitato alla funzione Rifiuta_fe
                    if ((idflowchart == null || idflowchart == DBNull.Value) || (rifiuta_ov != null && rifiuta_ov.ToString().ToUpper() == "'S'")) {
                        btnRifiuta.Enabled = true;
                        txtRifiuto.ReadOnly = false;
                    }
                }

                btnToProtocol.Enabled = false;
                txtProtocolDate.ReadOnly = true;
                txtDataRicezioneSdI.ReadOnly = true;
                if (stato == 5) {
                    btnToProtocol.Enabled = true;
                    txtProtocolDate.ReadOnly = false;
                    txtDataRicezioneSdI.ReadOnly = false;
                }
            }

            MostraBottoniXMLMessaggi();
        }

        public void MostraBottoniXMLMessaggi() {
            if (Meta.IsEmpty) return;

            // mt (metadato)
            // ec (esito committente)
            // se (scarto esito)
            // dt (decorrenza termini)
            if (DS.nso_vendita.Rows.Count == 0) {
                return;
            }

            DataRow Curr = DS.nso_vendita.Rows[0];
            if (Curr.RowState == DataRowState.Deleted) return;
            
            btnXMLMT.Visible = Curr["mt"] != DBNull.Value;
            btnXMLRESP.Visible = Curr["ec"] != DBNull.Value;
 
        }

        public void MetaData_BeforePost() {
            if (DS.nso_vendita.Rows.Count == 0) {
                return;
            }

            DataRow curr = DS.nso_vendita.Rows[0];
            if (curr.RowState == DataRowState.Deleted) return;
            object protocol = curr["arrivalprotocolnum", DataRowVersion.Current];
            int idsdi_oldstatus = CfgFn.GetNoNullInt32(curr["idnso_status", DataRowVersion.Original]);
            int idsdi_currstatus = CfgFn.GetNoNullInt32(curr["idnso_status", DataRowVersion.Current]);
            if ((protocol != DBNull.Value) && (idsdi_oldstatus == 5) && (idsdi_currstatus != 2) &&
                (idsdi_currstatus != 3))
                curr["idnso_status"] = 1; // lo pongo in attesa

        }

        public void MetaData_AfterClear() {
            btnGeneraFile.Enabled = false;
            btnSalvaAllegati.Enabled = false;
            btnImporta.Enabled = false;
            btnRifiuta.Enabled = false;
            btnAccetta.Enabled = false;
            btnToProtocol.Enabled = false;
            gboxStato.Enabled = true;
            btnRifiuta.Visible = true;

            EnableDisableDatiOrdine(true);
            txtRifiuto.ReadOnly = false;
            txtRifiuto.Text = "";
            grpMessaggi.Enabled = true;
            txtNomeFile.Enabled = true;
            txtNomeFilecompresso.Enabled = true;
            txtIdentificativoSdI.Enabled = true;
            txtTipoDocumento.Enabled = true;
            txtRifAmm.ReadOnly = false;
 
            btnXMLMT.Visible = true;
            btnXMLRESP.Visible = true;
  
            txtDataAccettata.ReadOnly = false;
            txtDataRifiutata.ReadOnly = false;
            txtUserAccettata.ReadOnly = false;
            txtUserRifiutata.ReadOnly = false;
        }

        private object SelezionaEstimateKind() {
            object idinvkind = DBNull.Value;
            string filterTipodoc = QHS.CmpEq("multireg", "N");
            MetaData MEstimatekind = MetaData.GetMetaData(this, "estimatekind");
            MEstimatekind.FilterLocked = true;
            MEstimatekind.DS = DS;
            DataRow MyDR = MEstimatekind.SelectOne("default", filterTipodoc, null, null);
            if (MyDR != null) {
                idinvkind = MyDR["idestimkind"];
            }

            return idinvkind;
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

        public static string getXmlText(XmlNode x, string xpath) {
            // x: <Order>
            // xpath: cac:SellerSupplierParty/cac:Party/cac:Contact/cbc:Name


            try {
                int levelFound = 0;

                string[] paths = xpath.Split('/');
                foreach (string path in paths) {
                    string[] parts = path.Split(':');
                    string part = parts.Length == 1 ? parts[0] : parts[1];
                    // part = SellerSupplierParty

                    // ChildNodes: <CustomizationID>, <ProfileID>, ..., <ns3:SellerSupplierParty>
                    foreach (XmlNode c in x.ChildNodes) {
                        string[] names = c.Name.Split(':');
                        string name = names.Length == 1 ? names[0] : names[1];
                        // c.Name: ns3:SellerSupplierParty
                        // Name: SellerSupplierParty

                        if (name == part) {
                            x = c;
                            levelFound++;
                            break;
                        }
                    }
                }

                if (levelFound == paths.Length) return x.InnerText;
            }
            catch { }

            return "";
        }

        static string getXmlAttribute(XmlNode x, string xpath, string attrib, XmlNamespaceManager ns = null) {
            try {
                XmlNode n = x.SelectSingleNode(xpath, ns);
                if (n != null) {
                    return n.Attributes["filename"].Value;
                }
            } catch {
            }

            return null;
        }

        private void ElaboraFileOrdine() {
            if (Meta.IsEmpty)
                return;

            if (!Meta.GetFormData(false))
                return;

            if (DS.nso_vendita.Rows.Count == 0)
                return;

            DataRow Curr = DS.nso_vendita.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                show(this, "Non vi è alcun file da importare\nErrore");
                return;
            }

            XmlDocument xml = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("cbc", ns_cbc);
            nsmgr.AddNamespace("cac", ns_cac);
            nsmgr.AddNamespace("ord", ns_ord);

            xml.LoadXml(Curr["xml"].ToString());

            object idreg = DBNull.Value;

            //XmlNode document = xml.GetElementsByTagName("Order")[0];
            XmlNode document = xml.GetElementsByTagName("Order", ns_ord)[0];

            string idPaese = getXmlText(document, "cac:BuyerCustomerParty/cac:Party/cac:PartyLegalEntity/cac:RegistrationAddress/cac:Country/cbc:IdentificationCode");
            string idCodice = getXmlText(document, "cac:BuyerCustomerParty/cac:Party/cac:PartyTaxScheme/cbc:CompanyID");
            string idFiscaleIva = "";
            if (idPaese == "IT") {
                //La partita IVA italiana è composta da 11 caratteri numerici. In registry abbiamo solo gli 11 numeri, per cui dobbiamo confrontare la p.iva solo con i numeri
                //Se invece fosse estera, avremmo anche la sigla della nazione.  
                idFiscaleIva = idCodice;
            } else {
                idFiscaleIva = (idPaese ?? "") + idCodice;
            }

            // ================================================================================================
            // Individua Anagrafica
            // ================================================================================================
            string Denominazione = Curr["buyer_name"].ToString();
            string idFiscaleIvaSearch = idFiscaleIva.StartsWith("IT") ? idFiscaleIva.Substring(2) : idFiscaleIva;
            idreg = IndividuaAnagrafica(idFiscaleIvaSearch, Denominazione);
            if (CfgFn.GetNoNullInt32(idreg) == 0) {
                string messaggio;
                messaggio = $"Non è stata trovata alcuna anagrafica con Partita IVA: {idFiscaleIva} o denominazione : {Denominazione}.";
                show(this, messaggio, "Avviso");
                //Apre un form per consentire all'utente la scelta dell'Anagrafica
                FrmAskAnagrafica F = new FrmAskAnagrafica(Meta, Meta.Dispatcher);
                createForm(F, this);
                if (F.ShowDialog(this) != DialogResult.OK)
                    return;
                idreg = F.idreg;
            }

            // ================================================================================================
            // Check Meta
            // ================================================================================================
            Meta.SaveFormData();
            if (Meta.DS.HasChanges()) {
                show("Errore nel salvataggio", "Errore");
                return;
            }

            // ================================================================================================
            // Estimate
            // ================================================================================================
            MetaData MetaEstimate = MetaData.GetMetaData(this, "estimate");

            MetaEstimate.SetUsr("nso_vendita", "S");
            MetaEstimate.SetUsr("broadcastEnabledEstimate", true);
            MetaEstimate.Edit(Meta?.linkedForm?.ParentForm, "default", false);
            if (MetaEstimate == null || MetaEstimate.destroyed) return;
            MetaEstimate.closeDisabled = true;
            D = MetaEstimate?.ds;
            if (D == null) {
                show(@"Non sono riuscito a caricare il form del contratto attivo", @"Errore");
                return;
            }

            DataTable Estimate = D.Tables["estimate"];
            DataTable EstimateDetail = D.Tables["estimatedetail"];
            
            MetaEstimate.SetDefaults(Estimate);

            MetaData MetaEstimateDetail = MetaData.GetMetaData(this, "estimatedetail");
            MetaEstimateDetail.SetDefaults(EstimateDetail);

            if (MetaEstimate == null || MetaEstimate.destroyed) return;
            //ToMeta.PrimaryDataTable. è la tabella principale del form creato
            Hashtable saveddefaults = new Hashtable();
            foreach (DataColumn C in MetaEstimate.PrimaryDataTable.Columns) {
                saveddefaults[C.ColumnName] = C.DefaultValue;
            }

            // Estimate.active
            MetaData.SetDefault(Estimate, "active", "S");

            // Estimate.idestimkind
            object idestimkind = SelezionaEstimateKind();
            MetaData.SetDefault(Estimate, "idestimkind", idestimkind);

          
            // Estimate.exchangerate
            MetaData.SetDefault(Estimate, "exchangerate", 1);

            // Estimate.idreg
            MetaData.SetDefault(Estimate, "idreg", idreg);

            // Estimate.officiallyprinted
            MetaData.SetDefault(Estimate, "officiallyprinted", "N");

            // EstimateDetail.idivakind
            int idnsovendita = CfgFn.GetNoNullInt32(Curr["idnso_vendita"]);
            MetaData.SetDefault(Estimate, "idnso_vendita", idnsovendita);

            // Estimate.currency
            object idcurrency = null;
            string CurrencyCode = getXmlText(document, "cbc:DocumentCurrencyCode");
            DataTable tCurrency = Conn.RUN_SELECT("currency", "*", null, QHS.CmpEq("codecurrency", CurrencyCode), null, false);
            if (tCurrency == null) {
                string messaggio;
                messaggio = $"Non è stato trovata la Valuta :{CurrencyCode}. La valuta verrà impostata come Euro.";
                show(this, messaggio, @"Avviso");
                MetaData.SetDefault(Estimate, "idcurrency", Conn.DO_READ_VALUE("currency", QHS.CmpEq("codecurrency", "EUR"), "idcurrency"));
            } else {
                if (tCurrency.Rows.Count > 0) {
                    DataRow rCurrency = tCurrency.Rows[0];
                    idcurrency = rCurrency["idcurrency"];
                    MetaData.SetDefault(Estimate, "idcurrency", CfgFn.GetNoNullInt32(idcurrency));
                }
            }

            // Estimate.officiallyprinted
            MetaData.SetDefault(Estimate, "flagintracom", "N");

            // CIG
            string OriginDocRef = Curr["codice_identificativo_gara"].ToString();
            if (OriginDocRef.Length == 10) {
                // Estimate.cigcode
                MetaData.SetDefault(Estimate, "cigcode", OriginDocRef);
            } else if (OriginDocRef.Length == 4) {
                // Estimate.cigcode
                MetaData.SetDefault(Estimate, "idnocigmotive", OriginDocRef);
            }

            // Estimate.doc
            MetaData.SetDefault(Estimate, "doc", Curr["order_id"]);

            // Estimate.docdate, contiene il campo issuedate, copiato in DS.nso_vendita.Rows[0]["adate"]
            // MetaData.SetDefault(Estimate, "docdate", DS.nso_vendita.Rows[0]["adate"]);

            // Estimate.docdate : viene valorizzata con nso_vendita.adate che contiene "IssueDate",
            // qualora dovesse essere null (ma non dovrebbe mai accadere perchè è la data Emissione),
            // valorizzeremo con la data contabile.

            if (Curr["adate"] != DBNull.Value) {
                MetaData.SetDefault(Estimate, "docdate", Curr["adate"]);  
            }
            else {
                MetaData.SetDefault(Estimate, "docdate", Meta.GetSys("datacontabile"));
            }

            // Estimate.description
            MetaData.SetDefault(Estimate, "description", Curr["description"]);

            // =====================================================
            // DELIVERY LOCATION
            // Name + Address (StreetName + CityName + PostalZone + CountrySubentity + Country\IdentificationCode)
            // =====================================================
            string DeliveryLocation = getXmlText(document, "cac:Delivery/cac:DeliveryLocation/cbc:Name") + "\r\n" +
                                      getXmlText(document, "cac:Delivery/cac:DeliveryLocation/cac:Address/cbc:StreetName") + "\r\n" +
                                      getXmlText(document, "cac:Delivery/cac:DeliveryLocation/cac:Address/cbc:PostalZone") + " - " +
                                      getXmlText(document, "cac:Delivery/cac:DeliveryLocation/cac:Address/cbc:CityName") + " (" +
                                      getXmlText(document, "cac:Delivery/cac:DeliveryLocation/cac:Address/cbc:CountrySubentity") + ") " +
                                      getXmlText(document, "cac:Delivery/cac:DeliveryLocation/cac:Address/cac:Country/cbc:IdentificationCode");
            // Estimate.deliveryaddress
            MetaData.SetDefault(Estimate, "deliveryaddress", DeliveryLocation);


            MetaData.SetDefault(EstimateDetail, "toinvoice", "S");

            // EstimateDetail.idreg
            MetaData.SetDefault(EstimateDetail, "idreg", idreg);

            // EstimateDetail.epkind
            MetaData.SetDefault(EstimateDetail, "epkind", "N");

            // EstimateDetail.flag
            MetaData.SetDefault(EstimateDetail, "flag", 0);


            // ================================================================================================
            //                                      APRI FORM
            // ================================================================================================
            MetaEstimate.DoMainCommand("maininsert");
            MetaEstimate.SetUsr("nso_vendita", null);
            MetaData.sendBroadcast(this, "apriFormImportaOrdine");
            
            // Ripristina i vecchi defaults
            foreach (DataColumn CC in MetaEstimate.PrimaryDataTable.Columns) {
                CC.DefaultValue = saveddefaults[CC.ColumnName];
            }
            if (MetaEstimate != null) MetaEstimate.dontClose = false;
        }

        private void btnImporta_Click(object sender, EventArgs e) {
            ElaboraFileOrdine();
        }

        private void btnVisualizza_Click(object sender, EventArgs e) {
            if (DS.nso_vendita.Rows.Count == 0) {
                return;
            }

            if (!Meta.GetFormData(false))
                return;

            Button btnVisualizza = (Button)sender;

            if (DS.nso_vendita.Rows[0]["xml"] == DBNull.Value) return;

            string xsl = "NSO-Stylesheet-Ver_5_0.xslt";
            string xlst = AppDomain.CurrentDomain.BaseDirectory + xsl;
            //string xml = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".xml";
            //string html = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".html";
            string xml = Path.ChangeExtension(Path.GetTempFileName(), "xml");
            string html = Path.ChangeExtension(Path.GetTempFileName(), "html");

            try
            {
                // Scrive il file Xml
                File.WriteAllText(xml, DS.nso_vendita.Rows[0]["xml"].ToString());

                // Xlst Compiler
                XslCompiledTransform xslct = new XslCompiledTransform();

                // Carica il template
                xslct.Load(xlst);

                // Trasforma Xml in Html usando il template
                xslct.Transform(xml, html);
            }
            catch (Exception E)
            {
                show("Errore aprendo l'ordine selezionato", "Errore");
                DataRow Curr = DS.nso_vendita.Rows[0];
                string errmsg = "Frm_nso_vendita_default: Errore su " + xsl + ", Ordine : " + Curr["idnso_vendita"];
                Meta.LogError(errmsg, E);
            }

            try
            {
                // Lancia l'html
                runProcess(html, true);

                // Elimina il file xml che non serve più
                File.Delete(xml);
            }
            catch (Exception ee)
            {
                QueryCreator.ShowException("Errore nella visualizzazione del file", ee);
            }
        }


        private void VisualizzaXMLMessaggi(string tipomessaggio)
        {
            try
            {
                // mt (metadato)
                // ec (esito committente)
                if (DS.nso_vendita.Rows.Count == 0)
                {
                    return;
                }

                if (!Meta.GetFormData(false))
                    return;
                // Visualizza file xml
                //string tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";
                string tempFileName = Path.ChangeExtension(Path.GetTempFileName(), "htm");
                XmlWriter xw = XmlWriter.Create(tempFileName);
                XmlDocument doc = new XmlDocument();
                XmlAttribute attr;


				if (DS.nso_vendita.Rows[0][tipomessaggio] == DBNull.Value)
                    return;

                string xml = DS.nso_vendita.Rows[0][tipomessaggio].ToString();

                doc.LoadXml(xml);

                foreach (XmlNode item in doc.ChildNodes)
                {
                    if (item.Name == "Order" || item.Name == "OrderResponse" || item.Name == "StandardBusinessDocument")
					{
						attr = doc.CreateAttribute("xmlns:n1");
						attr.Value = "urn:oasis:names:specification:ubl:schema:xsd:Order-2";
						item.Attributes.Append(attr);

						attr = doc.CreateAttribute("xmlns:n2");
						attr.Value = "urn:oasis:names:specification:ubl:schema:xsd:OrderResponse-2";
						item.Attributes.Append(attr);

						attr = doc.CreateAttribute("xmlns:n3");
						attr.Value = "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader";
						item.Attributes.Append(attr);

						attr = doc.CreateAttribute("xmlns:cac");
						attr.Value = "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2";
						item.Attributes.Append(attr);

						attr = doc.CreateAttribute("xmlns:cbc");
						attr.Value = "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2";
						item.Attributes.Append(attr);

						adjustNodes(item);

                        xml = doc.OuterXml;
                        xml = xml.Replace(" xmlns:cac=\"urn:oasis:names:specification:ubl:schema:xsd:OrderResponse-2\"", "")
                            .Replace(" xmlns:cbc=\"urn:oasis:names:specification:ubl:schema:xsd:OrderResponse-2\"", "");

						doc.LoadXml(xml);                        
					}
				}


                XslCompiledTransform xsltransform = new XslCompiledTransform();
                string filexls = "";

                string xsl = "NSO-Stylesheet-Ver_5_0.xslt";
                string xlst = AppDomain.CurrentDomain.BaseDirectory + xsl;

                xsltransform.Load(xlst);

                xsltransform.Transform(doc, null, xw);

                xw.Flush();
                xw.Close();

                runProcess(tempFileName, true);
            }
            catch (Exception ee)
            {
                QueryCreator.ShowException("Errore nella visualizzazione del file", ee);
            }
        }

        private void adjustNodes(XmlNode n)
        {
            foreach (XmlNode node in n.ChildNodes)
            {
                if (!(node.Name == "Order" || node.Name == "OrderResponse" || node.Name == "StandardBusinessDocument"))
                {
                    if (node.NodeType == XmlNodeType.Element)
                    {
                        node.Prefix = (node.FirstChild.NodeType == XmlNodeType.Text ? "cbc" : "cac");
                        XmlElement x = (XmlElement)node;
                        x.RemoveAllAttributes();
                        adjustNodes(node);
                    }
                }
			}
		}

        //bool AvvisoMostrato = false;
        private void btnRifiuta_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;

            Meta.GetFormData(true);
            DataRow Curr = DS.nso_vendita.Rows[0];

            object protocolDate = Curr["data_ricezione"];
            object orderDataScadenza = Curr["order_data_scadenza"];

            if (protocolDate != DBNull.Value) {
                DateTime dataRicezione = (DateTime)protocolDate; //Convert.ToDateTime(protocolDate);
                DateTime decorrenzaTermini;
                if (orderDataScadenza != DBNull.Value) {
                    decorrenzaTermini = (DateTime)orderDataScadenza;
                } else {
                    decorrenzaTermini = dataRicezione.AddDays(15);
                }
                DateTime endDay = decorrenzaTermini.AddHours(23).AddMinutes(59).AddSeconds(59);

                if (DateTime.Now.CompareTo(decorrenzaTermini) > 0 && DateTime.Now.CompareTo(endDay) < 0) {
                    show(this, "Si è in procinto della decorrenza dei termini. Il rifiuto sarà accettato solo se il servizio NSO è attivo", "Avviso");
                }
            }

            if (show("Si è deciso di Rifiutare l'Ordine di Vendita. Procedo col rifiuto?", "Avviso", MessageBoxButtons.OKCancel) != DialogResult.OK) {
                return;
            } else {
                if (txtRifiuto.Text.ToString() == "") {
                    show(this, "Indicare la motivazione del Rifiuto nell'apposito campo.", "Avviso");
                    return;
                } else {

                    Curr["idnso_status"] = 3; // Rifiutata
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
            if (show(this, "Si è deciso di Accettare l'Ordine di Vendita. Procedo con l'Accettazione?", "Avviso", MessageBoxButtons.OKCancel) != DialogResult.OK) {
                return;
            }

            if (DS.nso_vendita.Rows.Count == 0) return;
            // Verifica condizione importo totale calcolato
            DataRow Curr = DS.nso_vendita.Rows[0];

            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file\nErrore";
                show(this, messaggio);
                return;
            }

            XmlDocument document = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
            nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");

            document.LoadXml(Curr["xml"].ToString());

            decimal total = CfgFn.GetNoNullDecimal(Curr["total"]);

            decimal orderLineSum = 0;

            XmlNode x = document.GetElementsByTagName("Order")[0];

            // Per ogni linea di Ordine
            XmlNodeList xOrderLine = document.GetElementsByTagName("cac:OrderLine");
            foreach (XmlNode oneBody in xOrderLine) {
                string sLine = getXmlText(oneBody, "cac:LineItem/cbc:LineExtensionAmount");
                decimal orderLine = XmlConvert.ToDecimal(sLine);
                orderLineSum += orderLine;
            }

            if (total != orderLineSum) {
                if (show(this,
                        "L'importo dell'ordine è di € " + total.ToString("c") + " mentre la " +
                        "somma delle linee dell'ordine è di € " + orderLineSum.ToString("c") + ". " +
                        "SI INTENDE PROCEDERE COMUNQUE?", "Avviso",
                        MessageBoxButtons.OKCancel) != DialogResult.OK) {
                    return;
                }
            }

            Curr["idnso_status"] = 2; // Accettata
            Curr["data_accettata"] = DateTime.Now;
            Curr["utente_accettata"] = Conn.externalUser;
            Meta.FreshForm();
            Meta.SaveFormData();

        }
        /*
            XmlDocument document = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(document.NameTable);
            nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");

            document.LoadXml(Curr["xml"].ToString());

            XmlNodeList xOrderLine = document.GetElementsByTagName("cac:OrderLine");
            foreach (XmlNode oneBody in xOrderLine) {
                string sLine = getXmlText(oneBody, "cac:LineItem/cbc:LineExtensionAmount", nsmgr);
            }
        */

        // =====================================================================================
        // Per il momento il protocollo lo si mette manualmente
        // =====================================================================================
        //public object getProtocolloOrdineVendita(DataRow r) {

        //    if (DS.uniconfig.Rows[0]["webprotaddress"] == DBNull.Value) return DBNull.Value;
        //    if (r["signedxml"] == DBNull.Value) {
        //        QueryCreator.ShowError(this, "Riga non compatibile con la ricezione automatica del protocollo", "Errore");
        //        return DBNull.Value;
        //    }
        //    XmlDocument document = new XmlDocument();
        //    document.LoadXml(r["xml"].ToString());

        //    try {
        //        var ws = new webReference.webProt();
        //        ws.Url = DS.uniconfig.Rows[0]["webprotaddress"].ToString();
        //        string xmlDocument = Convert.ToBase64String(Encoding.UTF8.GetBytes(document.OuterXml));
        //        var res = ws.ottieniProtocolloFatturaAcquisto(r["filename"].ToString(),
        //            DateTime.Now.Date, xmlDocument,
        //            r["signedxml"].ToString(),
        //            CfgFn.GetNoNullInt64(r["identificativo_nso"]),
        //            CfgFn.GetNoNullInt32(r["position"]),
        //            CfgFn.GetNoNullInt32(r["idnso_vendita"]));

        //        if (res.Error == null) {
        //            return res.nProt;
        //        }
        //        QueryCreator.ShowError(this, "Errore nella ricezione del protocollo", res.Error);

        //    } catch (Exception e) {
        //        QueryCreator.ShowException(this, "Errore nelll'ottenimento del protocollo", e);
        //    }

        //    return DBNull.Value;
        //}


        private void btnToProtocol_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(false)) return;
            DataRow curr = DS.nso_vendita.Rows[0];
            object arrivalProtocol = DBNull.Value;
            object oldprotocol = curr["arrivalprotocolnum", DataRowVersion.Original];
            if (oldprotocol != DBNull.Value) return;

            // =====================================================================================
            // Per il momento il protocollo lo si mette manualmente
            // =====================================================================================
            //if (DS.uniconfig.Rows[0]["webprotaddress"] != DBNull.Value) {
            //    arrivalProtocol = getProtocolloOrdineVendita(curr);
            //}

            if (arrivalProtocol == DBNull.Value) {
                FrmAskProtocollo FP = new FrmAskProtocollo(0);
                createForm(FP, this);
                if (FP.ShowDialog(this) == DialogResult.OK) {
                    arrivalProtocol = FP.Protocollo;
                }
            }


            if (arrivalProtocol == null || arrivalProtocol == DBNull.Value || arrivalProtocol.ToString() == "") {
                return;
            }

            if (arrivalProtocol != DBNull.Value && arrivalProtocol.ToString() != "") {
                curr["arrivalprotocolnum"] = arrivalProtocol;
                if (curr["protocoldate"] == DBNull.Value) {
                    curr["protocoldate"] = DateTime.Now.Date;
                } else {
                    if (show("Aggiorno la data di ricezione ?", "Conferma", MessageBoxButtons.OKCancel) ==
                        DialogResult.OK) {
                        curr["protocoldate"] = DateTime.Now.Date;
                    }
                }

                if (curr["idnso_status", DataRowVersion.Original].ToString() == "6") {
                    curr["idnso_status"] = 2;
                } else {
                    curr["idnso_status"] = 1;
                }

                if (curr["dt"] != DBNull.Value) {
                    curr["idnso_status"] = 4;
                }

            }

            //else {
            //    curr["idnso_status"] = curr["idnso_status", DataRowVersion.Original];
            //    curr["arrivalprotocolnum"] = DBNull.Value;
            //}

            Meta.SaveFormData();

        }

        private void btnGeneraFile_Click(object sender, EventArgs e) {
            if (DS.nso_vendita.Rows.Count == 0) {
                return;
            }

            XmlDocument doc = new XmlDocument();
            if (DS.nso_vendita.Rows[0]["xml"] == DBNull.Value)
                return;

            try {
                doc.LoadXml(DS.nso_vendita.Rows[0]["xml"].ToString());
            } catch (Exception E) {
                show("Errore aprendo l'ordine selezionato", "Errore");
                DataRow Curr = DS.nso_vendita.Rows[0];
                string errmsg = "Frm_nso_vendita_default: Errore su xslt, Ordine : " +
                                Curr["idnso_vendita"];
                Meta.LogError(errmsg, E);
            }


            if (doc == null)
                return;

            string fname = DS.nso_vendita.Rows[0]["filename"].ToString();

            string fNameNoExtension = fname.Split('.')[0];
            string extension = ".xml"; //   fname.Substring(fNameNoExtension.Length);


            saveFileDialog1.FileName =
                fNameNoExtension + "_" + DS.nso_vendita.Rows[0]["position"].ToString() + extension;
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
                show("Salvataggio del file " + fname + " effettuato");
            } catch (System.IO.IOException e1) {
                show(e1.Message, "Errore nel salvataggio del file " + fname);
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
            DataRow Curr = DS.nso_vendita.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file\nErrore";
                show(this, messaggio);
                return;
            }

            XmlDocument xml = new XmlDocument();
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("cbc", ns_cbc);
            nsmgr.AddNamespace("cac", ns_cac);
            nsmgr.AddNamespace("ord", ns_ord);

            xml.LoadXml(Curr["xml"].ToString());

            XmlNodeList attachmentList = xml.GetElementsByTagName("cac:AdditionalDocumentReference");
            if (attachmentList == null) {
                show(this, "Non sono presenti Allegati.");
                return;
            }

            faiScegliereCartella();
            foreach (XmlNode attachment in attachmentList) {
                string NomeAttachment = getXmlAttribute(attachment, "cac:Attachment/cbc:EmbeddedDocumentBinaryObject", "filename", nsmgr);
                string AttachmentBinary = getXmlText(attachment, "cac:Attachment/cbc:EmbeddedDocumentBinaryObject");
                if (!string.IsNullOrEmpty(NomeAttachment) && !string.IsNullOrEmpty(AttachmentBinary)) {
                    string FilePath = Path.Combine(CartellaAllegati, NomeAttachment);
                    try {
                        byte[] ByteArray = Convert.FromBase64String(AttachmentBinary);
                        ScriviFile(FilePath, ByteArray, 0);
                    }
                    catch (Exception E) {
                        QueryCreator.ShowException(E);
                    }
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
            } catch {
            }
        }

        private void btnXMLMetaDati_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("mt");
        }

        private void btnXMLNEC_Click(object sender, EventArgs e) {
            VisualizzaXMLMessaggi("ec");
        }
 
    }
}
