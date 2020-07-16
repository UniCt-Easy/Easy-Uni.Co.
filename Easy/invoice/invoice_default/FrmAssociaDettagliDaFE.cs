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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using AskInfo;
using System.Xml;
using funzioni_configurazione;
using System.Text;

namespace invoice_default {
	/// <summary>
    /// Summary description for FrmAssociaDettagliDaFE.
	/// </summary>
    public class FrmAssociaDettagliDaFE : System.Windows.Forms.Form {
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnAnnulla;
		DataAccess Conn;
        MetaData Meta;
        DataSet DS;
        DataTable dettagli_fe = new DataTable();
        DataTable fatture_madri = new DataTable();
        public DataTable Tassociazioni = new DataTable();
        public DataTable Tallegati = new DataTable();
        public DataRow[] AssociazioniRows = null;
        string filterregistry;
        string filterflagmixed;
        object idcurrency;
        object flagactivity;
        bool HasDDT;
        DataTable InvoiceDetail;
        DataTable MandateDetail;
        public DataRow[] CP_SelectedRows = null;
        public DataRow[] CP_SelectedRowsbk;
        public DataRow[] FE_SelectedRows = null;
        
        public DataRow[] FE_SelectedRowsbk;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        CQueryHelper QHC;
        QueryHelper QHS;
        private DataGrid dgrDettagliCP;
        private DataGrid dgrDettagliFE;
        private Label lblTitoloGridCP;
        private Label lblValuta;
        private Label lblValutaCP;
        private Button btnImportaSenzaAssociazione;
        private Button btnImportaTuttaFESenzaAssociazione;
        private Label label4;
        private Label label5;
        private Button btnIgnoraeInserisci;
        private Button btnEseguiAssociazione;

        public FrmAssociaDettagliDaFE(MetaData Meta, object idsdi_acquisto, object idcurrency, object flagactivity, string filterregistry, string filterflagmixed, bool HasDDT, DataTable InvoiceDetail) {
			InitializeComponent();
            this.Meta = Meta;
            this.Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            this.DS = Meta.DS;
            this.flagactivity = flagactivity;
            this.filterregistry = filterregistry;
            this.filterflagmixed = filterflagmixed;
            this.idcurrency = idcurrency;
            this.InvoiceDetail = InvoiceDetail;
            this.HasDDT = HasDDT;
            CreaStrutturaDettagli_fe();
            CreaStrutturaTassociazioni();
            CreaStrutturaFattureMadri();
            CreaStrutturaTallegati();
            RiempiDataGridDettagliFE(idsdi_acquisto);
            RiempiGridDettagliCP(idsdi_acquisto);
            RiempiDataTableFattureMadri(idsdi_acquisto);
            RecupareAllegati(idsdi_acquisto);
		}

        void CreaStrutturaTassociazioni() {
            Tassociazioni.TableName = "Tassociazioni";
            Tassociazioni.Columns.Add("id", typeof(string));         Tassociazioni.Columns["id"].Caption = ".";
            Tassociazioni.Columns.Add("NumeroLinea", typeof(string));Tassociazioni.Columns["NumeroLinea"].Caption = "NumeroLinea";
            Tassociazioni.Columns.Add("idmankind", typeof(string)); Tassociazioni.Columns["idmankind"].Caption = ".";
            Tassociazioni.Columns.Add("yman", typeof(int));         Tassociazioni.Columns["yman"].Caption = ".";
            Tassociazioni.Columns.Add("nman", typeof(int));         Tassociazioni.Columns["nman"].Caption = ".";
            //Tassociazioni.Columns.Add("manrownum", typeof(int));    Tassociazioni.Columns["manrownum"].Caption = ".";
            Tassociazioni.Columns.Add("rownum", typeof(int));       Tassociazioni.Columns["rownum"].Caption = ".";//Ë quello della riga ordine
            
            Tassociazioni.Columns.Add("idgroup", typeof(int));      Tassociazioni.Columns["idgroup"].Caption = ".";
            Tassociazioni.Columns.Add("idivakind", typeof(int));    Tassociazioni.Columns["idivakind"].Caption = "TipoIVA";
            Tassociazioni.Columns.Add("taxrate", typeof(double));   Tassociazioni.Columns["taxrate"].Caption = "AliquotaIVA";
            Tassociazioni.Columns.Add("cigcode", typeof(string));   Tassociazioni.Columns["cigcode"].Caption = "Codice CIG";

            Tassociazioni.Columns.Add("residual", typeof(decimal));            //Tassociazioni.Columns["residual"].Caption = "
            Tassociazioni.Columns.Add("detaildescription", typeof(string));    // Tassociazioni.Columns["detaildescription"].Caption = "
            Tassociazioni.Columns.Add("taxable", typeof(decimal));             // Tassociazioni.Columns["taxable"].Caption = "
            Tassociazioni.Columns.Add("tax", typeof(decimal));                  //Tassociazioni.Columns["tax"].Caption = "
            Tassociazioni.Columns.Add("discount", typeof(decimal));             //Tassociazioni.Columns["discount"].Caption = "
            Tassociazioni.Columns.Add("idupb", typeof(string));                 //Tassociazioni.Columns["idupb"].Caption = "
            Tassociazioni.Columns.Add("idupb_iva", typeof(string));                 //Tassociazioni.Columns["idupb"].Caption = "
            Tassociazioni.Columns.Add("idsor1", typeof(int));                   //Tassociazioni.Columns["idsor1"].Caption = "
            Tassociazioni.Columns.Add("idsor2", typeof(int));                  // Tassociazioni.Columns["idsor2"].Caption = "
            Tassociazioni.Columns.Add("idsor3", typeof(int));                  // Tassociazioni.Columns["idsor3"].Caption = "
            Tassociazioni.Columns.Add("idcostpartition", typeof(int));         // Tassociazioni.Columns["idcostpartition"].Caption = "
            Tassociazioni.Columns.Add("competencystart", typeof(DateTime));     //Tassociazioni.Columns["competencystart"].Caption = "
            Tassociazioni.Columns.Add("competencystop", typeof(DateTime));     // Tassociazioni.Columns["competencystop"].Caption = "
            Tassociazioni.Columns.Add("idaccmotive", typeof(string));           //Tassociazioni.Columns["idaccmotive"].Caption = "
            Tassociazioni.Columns.Add("va3type", typeof(string));               //Tassociazioni.Columns["va3type"].Caption = "
            Tassociazioni.Columns.Add("idlist", typeof(int));                   //Tassociazioni.Columns["idlist"].Caption = "
            Tassociazioni.Columns.Add("idunit", typeof(int));                   //Tassociazioni.Columns["idunit"].Caption = "
            Tassociazioni.Columns.Add("idpackage", typeof(int));               // Tassociazioni.Columns["idpackage"].Caption = "
            Tassociazioni.Columns.Add("unitsforpackage", typeof(int));          //Tassociazioni.Columns["unitsforpackage"].Caption = "
            Tassociazioni.Columns.Add("expensekind", typeof(string));           //Tassociazioni.Columns["expensekind"].Caption = "
            Tassociazioni.Columns.Add("number", typeof(decimal));               //Tassociazioni.Columns["number"].Caption = "
            Tassociazioni.Columns.Add("npackage", typeof(decimal));             //Tassociazioni.Columns["npackage"].Caption = "
            Tassociazioni.Columns.Add("assetkind", typeof(string));             //Tassociazioni.Columns["assetkind"].Caption = "
            Tassociazioni.Columns.Add("unabatable", typeof(decimal));           //Tassociazioni.Columns["unabatable"].Caption = "
            Tassociazioni.Columns.Add("idinvkind_main", typeof(int));
            Tassociazioni.Columns.Add("yinv_main", typeof(int));
            Tassociazioni.Columns.Add("ninv_main", typeof(int));
            Tassociazioni.Columns.Add("idepexp", typeof(int));
            Tassociazioni.Columns.Add("idsor_siope", typeof(int));                   //Tassociazioni.Columns["idsor1"].Caption = "

            
            Tassociazioni.Columns.Add("cupcode", typeof(string)); Tassociazioni.Columns["cupcode"].Caption = "Codice CUP";
            Tassociazioni.Columns.Add("requested_doc", typeof(int)); Tassociazioni.Columns["requested_doc"].Caption = ".";
        }

        void CreaStrutturaDettagli_fe() {
            dettagli_fe.TableName = "dettagli_fe";
            dettagli_fe.Columns.Add("id", typeof(string));                  dettagli_fe.Columns["id"].Caption = ".";

            dettagli_fe.Columns.Add("NumeroLinea", typeof(string));         dettagli_fe.Columns["NumeroLinea"].Caption = "NumeroLinea";
            dettagli_fe.Columns.Add("Descrizione", typeof(string));         dettagli_fe.Columns["Descrizione"].Caption = "Descrizione";
            dettagli_fe.Columns.Add("Quantita", typeof(decimal));           dettagli_fe.Columns["Quantita"].Caption = "Q.t‡";
            dettagli_fe.Columns.Add("PrezzoUnitario", typeof(decimal));     dettagli_fe.Columns["PrezzoUnitario"].Caption = "PrezzoUnitario";
            dettagli_fe.Columns.Add("PrezzoTotale", typeof(decimal));       dettagli_fe.Columns["PrezzoTotale"].Caption = "PrezzoTotale";
            dettagli_fe.Columns.Add("AliquotaIVA", typeof(decimal));        dettagli_fe.Columns["AliquotaIVA"].Caption = "AliquotaIVA";
            dettagli_fe.Columns.Add("Natura", typeof(string));              dettagli_fe.Columns["Natura"].Caption = "Natura";
            dettagli_fe.Columns.Add("CodiceCIG", typeof(string));           dettagli_fe.Columns["CodiceCIG"].Caption = "Codice CIG";

            dettagli_fe.Columns.Add("ImportoIVA", typeof(decimal));         dettagli_fe.Columns["ImportoIVA"].Caption = "Importo IVA";
            dettagli_fe.Columns.Add("ImportoSconto", typeof(decimal));      dettagli_fe.Columns["ImportoSconto"].Caption = "Importo Sconto";
            dettagli_fe.Columns.Add("PercentualeSconto", typeof(decimal));  dettagli_fe.Columns["PercentualeSconto"].Caption = "Percentuale Sconto";
            dettagli_fe.Columns.Add("unitsforpackage", typeof(decimal));    dettagli_fe.Columns["unitsforpackage"].Caption = ".";
            dettagli_fe.Columns.Add("riferimentoNumeroLinea", typeof (int)); dettagli_fe.Columns["riferimentoNumeroLinea"].Caption = ".";
            dettagli_fe.Columns.Add("IdDocumento", typeof(string)); dettagli_fe.Columns["IdDocumento"].Caption = "Documento";

            dettagli_fe.Columns.Add("cupcode", typeof(string));
            dettagli_fe.Columns["cupcode"].Caption = "cup";
        }

        void CreaStrutturaFattureMadri() {
            fatture_madri.TableName = "fatture_madri";

            fatture_madri.Columns.Add("doc", typeof(string));               fatture_madri.Columns["doc"].Caption = "doc";
            fatture_madri.Columns.Add("idinvkind", typeof(int));       fatture_madri.Columns["idinvkind"].Caption = "idinvkind";
            fatture_madri.Columns.Add("yinv", typeof(int));            fatture_madri.Columns["yinv"].Caption = "yinv";
            fatture_madri.Columns.Add("ninv", typeof(int));            fatture_madri.Columns["ninv"].Caption = "ninv";
        }

        static string getXmlText(XmlDocument x, string xpath) {
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

        void RiempiDataTableFattureMadri(object idsdi_acquisto) {
            DataTable SDI_acquisto;
            SDI_acquisto = Conn.RUN_SELECT("sdi_acquisto", "*", null, QHS.CmpEq("idsdi_acquisto", idsdi_acquisto), null, false);

            DataRow Curr = SDI_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi Ë alcun file da importare\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;
            List<string> listaDoc = new List<string>();
            XmlNodeList DatiFattureCollegate = document.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiFattureCollegate");
            foreach (XmlNode Fatt in DatiFattureCollegate) {
                string IdDocumento = Fatt["IdDocumento"].InnerText.Trim();
                if (listaDoc.Contains(IdDocumento)) continue;
                listaDoc.Add(IdDocumento);

                DataRow R = fatture_madri.NewRow();                
                R["doc"] = IdDocumento;
                DataTable Invoice = Conn.RUN_SELECT("invoice", "*", null, QHS.CmpEq("doc", IdDocumento), null, false);
                if (Invoice.Rows.Count > 0) {
                    DataRow rInvoice = Invoice.Rows[0];
                    object idinvkind = rInvoice["idinvkind"];
                    R["idinvkind"] = idinvkind;
                    object yinv = rInvoice["yinv"];
                    R["yinv"] = yinv;
                    object ninv = rInvoice["ninv"];
                    R["ninv"] = ninv;
                }
                fatture_madri.Rows.Add(R);
            }
            fatture_madri.AcceptChanges();

            DataSet D = new DataSet();
            D.Tables.Add(fatture_madri);
        }

        void CreaStrutturaTallegati() {
            Tallegati.TableName = "Tallegati";

            Tallegati.Columns.Add("attachment", typeof(byte[]));
            Tallegati.Columns.Add("filename", typeof(string));            
        }

        void RecupareAllegati(object idsdi_acquisto) {
            DataTable SDI_acquisto;
            SDI_acquisto = Conn.RUN_SELECT("sdi_acquisto", "*", null, QHS.CmpEq("idsdi_acquisto", idsdi_acquisto), null, false);

            DataRow Curr = SDI_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi Ë alcun file da importare\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;

            XmlNodeList Allegati = document.SelectNodes("//FatturaElettronicaBody/Allegati");
            if (Allegati == null)
                return;

            DataRow R = null;
            foreach (XmlNode Dettaglio in Allegati) {
                R = Tallegati.NewRow();
                string NomeAttachment = Dettaglio["NomeAttachment"].InnerText;
                R["filename"] = NomeAttachment;
                string Attachment = Dettaglio["Attachment"].InnerText;
                byte[] bytes = Convert.FromBase64String(Attachment);
                R["attachment"] = bytes;
                Tallegati.Rows.Add(R);
            }
            Tallegati.AcceptChanges();
        }



        void RiempiDataGridDettagliFE(object idsdi_acquisto) {
            DataTable SDI_acquisto;
            SDI_acquisto = Conn.RUN_SELECT("sdi_acquisto", "*", null, QHS.CmpEq("idsdi_acquisto", idsdi_acquisto), null, false);
            bool messageShown = false;
            DataRow Curr = SDI_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi Ë alcun file da importare\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;

            // Tipo Documento
            string TipoDocumentoTD = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/TipoDocumento");
            //bool variation = false;
            //if ((TipoDocumentoTD == "TD04")) { //|| (TipoDocumentoTD == "TD05")
            //    variation = true;
            //}

            string CodiceCIG = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiOrdineAcquisto/CodiceCIG");
            string RiferimentoNumeroLinea = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiOrdineAcquisto/RiferimentoNumeroLinea");

            if (CodiceCIG == null) {
                CodiceCIG = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiContratto/CodiceCIG");
                RiferimentoNumeroLinea = getXmlText(document, "//FatturaElettronicaBody/DatiContratto/DatiConvenzione/RiferimentoNumeroLinea");
            }
            if (CodiceCIG == null) {
                CodiceCIG = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiConvenzione/CodiceCIG");
                RiferimentoNumeroLinea = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiConvenzione/RiferimentoNumeroLinea");
            }
            if (CodiceCIG == null)
                MessageBox.Show("I dettagli fattura sono privi di Codice CIG, in quanto non presente nel tracciato compilato dal fornitore. Inserire il Codice CIG a mano sui dettagli della fattura");

            Dictionary<int, string> lookupDocumento = new Dictionary<int, string>();
            XmlNodeList DatiFattureCollegate = document.SelectNodes("//FatturaElettronicaBody/DatiGenerali/DatiFattureCollegate");
            foreach (XmlNode Fatt in DatiFattureCollegate) {
                string IdDocumento = Fatt["IdDocumento"].InnerText.Trim();
                int rifLinea = CfgFn.GetNoNullInt32(Fatt["RiferimentoNumeroLinea"]);
                lookupDocumento[rifLinea] = IdDocumento;
            }

            int indice = 0;
            XmlNodeList DettaglioLinee = document.SelectNodes("//FatturaElettronicaBody/DatiBeniServizi/DettaglioLinee");
            foreach (XmlNode Dettaglio in DettaglioLinee) {
                indice += 1;
                DataRow R = dettagli_fe.NewRow();
                string NumeroLinea = Dettaglio["NumeroLinea"].InnerText;
                R["id"] = indice;
                int numeroLinea = CfgFn.GetNoNullInt32(NumeroLinea);
                if (lookupDocumento.ContainsKey(numeroLinea)) {
                    R["IdDocumento"] = lookupDocumento[numeroLinea];
                }
                else {
                    if (lookupDocumento.ContainsKey(0)) {
                        R["IdDocumento"] = lookupDocumento[0];
                    }
                }

                R["NumeroLinea"] = NumeroLinea;
                string Descrizione = Dettaglio["Descrizione"].InnerText;
                R["Descrizione"] = Descrizione;
                decimal Quantita = 1;

                decimal PrezzoUnitario = XmlConvert.ToDecimal(Dettaglio["PrezzoUnitario"].InnerText);
                //PrezzoUnitario = Math.Abs(PrezzoUnitario);
                R["PrezzoUnitario"] = PrezzoUnitario;
                decimal PrezzoTotale = 0;
                //if (ConsideraImportiFE(document, variation)) {
                PrezzoTotale = XmlConvert.ToDecimal(Dettaglio["PrezzoTotale"].InnerText);
                //PrezzoTotale = Math.Abs(PrezzoTotale);
                //if (variation)
                //    PrezzoTotale = -PrezzoTotale; // Nota di credito
                R["PrezzoTotale"] = PrezzoTotale;
                //}
                //else {
                //}

                if ((PrezzoUnitario == 0) && (PrezzoTotale == 0))
                    continue;//Se gli importi sono 0, il dettaglio non va ne importato in Easy, ne mostrato nel grid. Task 7113.
                if (Dettaglio["Quantita"] != null) {
                    Quantita = XmlConvert.ToDecimal(Dettaglio["Quantita"].InnerText);
                    Quantita = Decimal.Round(Quantita, 2);
                    if ((Quantita==0) && (PrezzoTotale != 0)){
                        Quantita = 1;//se totale <> 0 e quantit‡ = 0=>  Correggiamo la q.t‡ con 1 e importiamo il dettaglio. Task 7113.
                    }
                }
                else {
                    if (PrezzoUnitario != 0 && PrezzoTotale != 0) {
                        Quantita = Decimal.Round(PrezzoTotale / PrezzoUnitario, 2);
                        if (!messageShown) {
                            messageShown = true;
                            MessageBox.Show("Per almeno un dettaglio Ë stato calcolata la quantit‡ con la formula inversa PrezzoTotale/PrezzoUnitario", "Avviso");
                        }
                    }
                }
                R["Quantita"] = Quantita;


                double AliquotaIVA_Double = XmlConvert.ToDouble(Dettaglio["AliquotaIVA"].InnerText);
                AliquotaIVA_Double = AliquotaIVA_Double / 100;
                decimal AliquotaIVA = CfgFn.GetNoNullDecimal(AliquotaIVA_Double);
                R["AliquotaIVA"] = AliquotaIVA_Double;
                decimal IVA = Decimal.Round(PrezzoTotale * AliquotaIVA, 2);
                R["ImportoIVA"] = IVA;
                if (Dettaglio["Natura"] != null) {
                    string Natura = Dettaglio["Natura"].InnerText.ToString();// Da leggere solo se esiste
                    R["Natura"] = Natura;
                }
                if ((RiferimentoNumeroLinea != null) &&
                    (CodiceCIG != null) &&
                    (RiferimentoNumeroLinea == NumeroLinea)) {
                    R["CodiceCIG"] = CodiceCIG;
                }
                else
                    if ((RiferimentoNumeroLinea == null) && (CodiceCIG != null)) {
                        R["CodiceCIG"] = CodiceCIG;
                    }
                // Determina lo SCONTO
                decimal totaleSconto = 0;
                XmlNodeList ElencoSconti = Dettaglio.SelectNodes("ScontoMaggiorazione");
                foreach (XmlElement Sconto in ElencoSconti) {
                    string contenuto = Sconto.InnerText;
                    string tipo = Sconto.SelectNodes("Tipo")[0].InnerText.ToUpper();
                    decimal segno = (tipo == "SC") ? +1 : -1;
                    XmlNodeList Imp = Sconto.SelectNodes("Importo");
                    if ((Imp != null) && (Imp.Count > 0)) {
                        decimal xx = XmlConvert.ToDecimal(Imp[0].InnerText);
                        xx = Math.Abs(xx);
                        totaleSconto += segno * xx;
                        continue;
                    }
                    XmlNodeList Perc = Sconto.SelectNodes("Percentuale");
                    if (Perc != null && Perc.Count > 0) {
                        decimal pp = XmlConvert.ToDecimal(Perc[0].InnerText);
                        totaleSconto += segno * Decimal.Round(pp * PrezzoUnitario * Quantita / 100, 5);
                        continue;
                    }
                }
                //      importo sconto:prezzo totale = percentuale scont :100 => Percentuale sconto = importo sconto*100/prezzo totale
                R["ImportoSconto"] = Decimal.Round(totaleSconto, 2);
                decimal PercentualeSconto = 0;
                if (totaleSconto != 0 && CfgFn.RoundValuta(PrezzoUnitario * Quantita) != 0) {
                    PercentualeSconto = Decimal.Round(totaleSconto, 2) / CfgFn.RoundValuta((PrezzoUnitario * Quantita));// *100
                }
                R["PercentualeSconto"] = Decimal.Round(PercentualeSconto, 3); //Arrotondamento al terzo digit 

                // Modifica introdotta ma poi annullata.
                // // Determina l' IVA 
                // decimal PrezzoTotale = 0;
                // if (ConsideraImportiFE(document, variation)) {
                //     PrezzoTotale = XmlConvert.ToDecimal(Dettaglio["PrezzoTotale"].InnerText);
                //     if (variation)
                //         PrezzoTotale = -PrezzoTotale; // Nota di credito
                //}
                // else {
                //     PrezzoTotale = Decimal.Round(PrezzoUnitario * Quantita * (1-PercentualeSconto), 2);
                // }
                // R["PrezzoTotale"] = PrezzoTotale;
                // double AliquotaIVA_Double = XmlConvert.ToDouble(Dettaglio["AliquotaIVA"].InnerText);
                // AliquotaIVA_Double = AliquotaIVA_Double / 100;
                // decimal AliquotaIVA = CfgFn.GetNoNullDecimal(AliquotaIVA_Double);
                // R["AliquotaIVA"] = AliquotaIVA_Double;
                // decimal IVA = Decimal.Round(PrezzoTotale * AliquotaIVA, 2);
                // R["ImportoIVA"] = IVA;

                dettagli_fe.Rows.Add(R);
            }

            dettagli_fe.AcceptChanges();
            DataSet D = new DataSet();
            D.Tables.Add(dettagli_fe);
            HelpForm.SetDataGrid(dgrDettagliFE, dettagli_fe);
            dgrDettagliFE.TableStyles.Clear();

            HelpForm.SetFormatForColumn(dettagli_fe.Columns["AliquotaIVA"], "p");
            HelpForm.SetFormatForColumn(dettagli_fe.Columns["PercentualeSconto"], "p");
            HelpForm.SetFormatForColumn(dettagli_fe.Columns["Quantita"], "n");
            HelpForm.SetGridStyle(dgrDettagliFE, dettagli_fe);

            formatgrids format = new formatgrids(dgrDettagliFE);
            format.AutosizeColumnWidth();

            //Se la FE ha solo un dettaglio, lo seleziona in automatico
            if (dettagli_fe.Rows.Count == 1) {
                SelezionaTuttoDgrFE();
            }
            //SelezionaTutto();

        }

        //private decimal decodificaImporto(string valoreletto) {// sostituisce '.' con  ','
        //    if (valoreletto == null)
        //        return 0;

        //    string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
        //    decimal amount = Decimal.Parse(valoreletto.Replace(".", dec));
        //    return amount;
        //}

        //static decimal noNullDecimal(object o) {
        //    if (o == null || o == DBNull.Value)
        //        return 0;
        //    try {
        //        return Convert.ToDecimal(o);
        //    }
        //    catch {
        //        return 0;
        //    }
        //}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.label1 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.dgrDettagliCP = new System.Windows.Forms.DataGrid();
            this.dgrDettagliFE = new System.Windows.Forms.DataGrid();
            this.lblTitoloGridCP = new System.Windows.Forms.Label();
            this.btnEseguiAssociazione = new System.Windows.Forms.Button();
            this.lblValuta = new System.Windows.Forms.Label();
            this.lblValutaCP = new System.Windows.Forms.Label();
            this.btnImportaSenzaAssociazione = new System.Windows.Forms.Button();
            this.btnImportaTuttaFESenzaAssociazione = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnIgnoraeInserisci = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliCP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFE)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Dettagli Fattura contenuti nella Fattura Elettronica";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(557, 625);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.TabStop = false;
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(651, 625);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 8;
            this.btnAnnulla.TabStop = false;
            this.btnAnnulla.Text = "Annulla";
            // 
            // dgrDettagliCP
            // 
            this.dgrDettagliCP.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrDettagliCP.DataMember = "";
            this.dgrDettagliCP.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrDettagliCP.Location = new System.Drawing.Point(10, 298);
            this.dgrDettagliCP.Name = "dgrDettagliCP";
            this.dgrDettagliCP.Size = new System.Drawing.Size(716, 228);
            this.dgrDettagliCP.TabIndex = 2;
            this.dgrDettagliCP.Tag = "";
            this.dgrDettagliCP.Paint += new System.Windows.Forms.PaintEventHandler(this.dgrDettagliCP_Paint);
            this.dgrDettagliCP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgrDettagliCP_KeyUp);
            this.dgrDettagliCP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrDettagliCP_MouseUp);
            // 
            // dgrDettagliFE
            // 
            this.dgrDettagliFE.AllowNavigation = false;
            this.dgrDettagliFE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrDettagliFE.DataMember = "";
            this.dgrDettagliFE.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrDettagliFE.Location = new System.Drawing.Point(10, 76);
            this.dgrDettagliFE.Name = "dgrDettagliFE";
            this.dgrDettagliFE.Size = new System.Drawing.Size(716, 166);
            this.dgrDettagliFE.TabIndex = 1;
            this.dgrDettagliFE.Tag = "";
            this.dgrDettagliFE.Paint += new System.Windows.Forms.PaintEventHandler(this.dgrDettagliFE_Paint);
            this.dgrDettagliFE.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgrDettagliFE_KeyUp);
            this.dgrDettagliFE.MouseUp += new System.Windows.Forms.MouseEventHandler(this.dgrDettagliFE_MouseUp);
            // 
            // lblTitoloGridCP
            // 
            this.lblTitoloGridCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitoloGridCP.Location = new System.Drawing.Point(9, 281);
            this.lblTitoloGridCP.Name = "lblTitoloGridCP";
            this.lblTitoloGridCP.Size = new System.Drawing.Size(512, 14);
            this.lblTitoloGridCP.TabIndex = 18;
            this.lblTitoloGridCP.Text = "Dettagli Contratti Passivi";
            // 
            // btnEseguiAssociazione
            // 
            this.btnEseguiAssociazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEseguiAssociazione.Location = new System.Drawing.Point(31, 532);
            this.btnEseguiAssociazione.Name = "btnEseguiAssociazione";
            this.btnEseguiAssociazione.Size = new System.Drawing.Size(122, 36);
            this.btnEseguiAssociazione.TabIndex = 3;
            this.btnEseguiAssociazione.TabStop = false;
            this.btnEseguiAssociazione.Text = "Esegui Associazione col Contratto Passivo";
            this.btnEseguiAssociazione.Click += new System.EventHandler(this.btnEseguiAssociazione_Click);
            // 
            // lblValuta
            // 
            this.lblValuta.AutoSize = true;
            this.lblValuta.Location = new System.Drawing.Point(318, 254);
            this.lblValuta.Name = "lblValuta";
            this.lblValuta.Size = new System.Drawing.Size(217, 13);
            this.lblValuta.TabIndex = 36;
            this.lblValuta.Text = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
            // 
            // lblValutaCP
            // 
            this.lblValutaCP.Location = new System.Drawing.Point(12, 253);
            this.lblValutaCP.Name = "lblValutaCP";
            this.lblValutaCP.Size = new System.Drawing.Size(315, 16);
            this.lblValutaCP.TabIndex = 35;
            this.lblValutaCP.Text = "Attenzione: i dettagli si riferiscono a contratti passivi in valuta:";
            // 
            // btnImportaSenzaAssociazione
            // 
            this.btnImportaSenzaAssociazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportaSenzaAssociazione.Location = new System.Drawing.Point(220, 587);
            this.btnImportaSenzaAssociazione.Name = "btnImportaSenzaAssociazione";
            this.btnImportaSenzaAssociazione.Size = new System.Drawing.Size(197, 36);
            this.btnImportaSenzaAssociazione.TabIndex = 6;
            this.btnImportaSenzaAssociazione.TabStop = false;
            this.btnImportaSenzaAssociazione.Text = "Importa il dettaglio FE, senza associarlo al Contratto Passivo";
            this.btnImportaSenzaAssociazione.Visible = false;
            this.btnImportaSenzaAssociazione.Click += new System.EventHandler(this.btnImportaSenzaAssociazione_Click);
            // 
            // btnImportaTuttaFESenzaAssociazione
            // 
            this.btnImportaTuttaFESenzaAssociazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnImportaTuttaFESenzaAssociazione.Location = new System.Drawing.Point(489, 532);
            this.btnImportaTuttaFESenzaAssociazione.Name = "btnImportaTuttaFESenzaAssociazione";
            this.btnImportaTuttaFESenzaAssociazione.Size = new System.Drawing.Size(228, 36);
            this.btnImportaTuttaFESenzaAssociazione.TabIndex = 5;
            this.btnImportaTuttaFESenzaAssociazione.TabStop = false;
            this.btnImportaTuttaFESenzaAssociazione.Text = "Importa TUTTI i dettagli della FE, senza associarli al Contratto Passivo";
            this.btnImportaTuttaFESenzaAssociazione.Click += new System.EventHandler(this.btnImportaTuttaFESenzaAssociazione_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(547, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Per ogni dettaglio Fattura Elettronica, scegliere a quale dettaglio Contratto Pas" +
    "sivo dovr‡ essere associato, oppure,";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(334, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "importare la Fattura Elettronica senza effettuare alcuna associazione. ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnIgnoraeInserisci
            // 
            this.btnIgnoraeInserisci.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIgnoraeInserisci.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnIgnoraeInserisci.Location = new System.Drawing.Point(220, 532);
            this.btnIgnoraeInserisci.Name = "btnIgnoraeInserisci";
            this.btnIgnoraeInserisci.Size = new System.Drawing.Size(197, 36);
            this.btnIgnoraeInserisci.TabIndex = 4;
            this.btnIgnoraeInserisci.TabStop = false;
            this.btnIgnoraeInserisci.Text = "Ignora e Inserisci manualmente";
            this.btnIgnoraeInserisci.Click += new System.EventHandler(this.btnIgnoraeInserisci_Click);
            // 
            // FrmAssociaDettagliDaFE
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(738, 656);
            this.Controls.Add(this.btnIgnoraeInserisci);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnImportaTuttaFESenzaAssociazione);
            this.Controls.Add(this.btnImportaSenzaAssociazione);
            this.Controls.Add(this.lblValuta);
            this.Controls.Add(this.lblValutaCP);
            this.Controls.Add(this.btnEseguiAssociazione);
            this.Controls.Add(this.lblTitoloGridCP);
            this.Controls.Add(this.dgrDettagliCP);
            this.Controls.Add(this.dgrDettagliFE);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label1);
            this.Name = "FrmAssociaDettagliDaFE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Associazione dettagli Fattura Elettronica con dettagli Contratto Passivo";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmAssociaDettagliDaFE_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAssociaDettagliDaFE_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliCP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDettagliFE)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion





        private void FrmAssociaDettagliDaFE_Closing(object sender, System.ComponentModel.CancelEventArgs e) {

		}

        private void btnAssociaCon_Click(object sender, EventArgs e) {
            //RiempiGridDettagliCP();
        }

        void RiempiGridDettagliCP(object idsdi_acquisto) {
            DataTable SDI_acquisto;
            SDI_acquisto = Conn.RUN_SELECT("sdi_acquisto", "*", null, QHS.CmpEq("idsdi_acquisto", idsdi_acquisto), null, false);

            DataRow Curr = SDI_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value)
            {
                string messaggio;
                messaggio = "Non vi Ë alcun file da importare\nErrore";
                MessageBox.Show(this, messaggio);
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;

            // Tipo Documento
            string TipoDocumentoTD = getXmlText(document, "//FatturaElettronicaBody/DatiGenerali/DatiGeneraliDocumento/TipoDocumento");
            bool variation = false;
            if ((TipoDocumentoTD == "TD04")) //|| (TipoDocumentoTD == "TD05")
            {
                variation = true;
            }
            if (variation) return;
            string filtercurrency = QHS.CmpEq("idcurrency", idcurrency);
            filtercurrency = QHS.DoPar(QHS.AppOr(filtercurrency, QHS.IsNull("idcurrency")));
            string filter = QHS.AppAnd(filterregistry, filterflagmixed);
            filter = QHS.AppAnd(filter, filtercurrency);
            filter = QHS.AppAnd(filter, QHS.CmpNe("toinvoice", 'N'), QHS.CmpEq("linktoinvoice", 'S'));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idmandatestatus", 5)); // stato approvato
            filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0)); // residuo maggiore di zero
            object currency = Conn.DO_READ_VALUE("currency", filtercurrency, "description");
            if (currency != null) {
                lblValuta.Text = currency.ToString().ToUpper();
            }
            //DataTable MandateDetail;
            if (HasDDT) {
                MandateDetail = Conn.RUN_SELECT("mandatedetailstockedtoinvoice", "*",
                            "idmankind ASC,yman DESC,nman DESC,rownum ASC, idgroup ASC",
                                filter, null, false);
            }
            else {
                MandateDetail = Conn.RUN_SELECT("mandatedetailnoddttoinvoice", "*",
                            "idmankind ASC,yman DESC,nman DESC,rownum ASC, idgroup ASC",
                                filter, null, false);
            }

            Conn.DeleteAllUnselectable(MandateDetail);

            if (MandateDetail.Rows.Count != 0) {
                MandateDetail.PrimaryKey = new DataColumn[]{MandateDetail.Columns["idmankind"],
															  MandateDetail.Columns["yman"],
															  MandateDetail.Columns["nman"],
															  MandateDetail.Columns["rownum"]};
                //Ora ha messo in MandateDetail tutto ciÚ che da DB risulta 'da fatturare'.

                //Effettua ora una serie di allineamenti sul DataTable per renderlo pi˘ coerente con quello
                // che c'Ë nel DataSet del form padre.

                //Per ogni riga del DataSet in stato di INSERT/UPDATE effettua una sottrazione ed eventualmente
                // un delete su MandateDetail se la riga corrispondente risulta essere esaurita.
                //foreach (DataRow R in InvoiceDetail.Select()) {
                //    if (R.RowState != DataRowState.Added)
                //        continue;
                //    if (R["idmankind"] == DBNull.Value)
                //        continue; //Non Ë una riga collegata a dettagli ordine
                //    string filtermand = QHC.CmpMulti(R, "idmankind", "yman", "nman");
                //    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", R["manrownum"]));

                //    DataRow[] RM = MandateDetail.Select(filtermand);
                //    if ((RM == null) || (RM.Length == 0))
                //        continue;
                //    DataRow Detail = RM[0];
                //    decimal oldnumber = 0;
                //    decimal newnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Current]);
                //    decimal oldresidual = CfgFn.GetNoNullDecimal(Detail["residual"]);
                //    decimal newresidual = oldresidual - newnumber + oldnumber;
                //    Detail["residual"] = newresidual;
                //}

                //foreach (DataRow R in InvoiceDetail.Select()) {
                //    if (R.RowState != DataRowState.Modified)
                //        continue;
                //    string filtermand = QHC.CmpMulti(R, "idmankind", "yman", "nman");
                //    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", R["manrownum"]));
                //    DataRow[] RM = MandateDetail.Select(filtermand);
                //    if ((RM == null) || (RM.Length == 0))
                //        continue;
                //    DataRow Detail = RM[0];
                //    decimal oldnumber;
                //    if (R["idmankind", DataRowVersion.Original] == DBNull.Value)
                //        oldnumber = 0;
                //    else
                //        oldnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Original]);

                //    decimal newnumber;
                //    if (R["idmankind", DataRowVersion.Current] == DBNull.Value)
                //        newnumber = 0;
                //    else
                //        newnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Current]);


                //    decimal oldresidual = CfgFn.GetNoNullDecimal(Detail["residual"]);
                //    decimal newresidual = oldresidual - newnumber + oldnumber;
                //    Detail["residual"] = newresidual;
                //}

                //foreach (DataRow R in InvoiceDetail.Rows) {
                //    if (R.RowState != DataRowState.Deleted)
                //        continue;
                //    if (R["idmankind", DataRowVersion.Original] == DBNull.Value)
                //        continue;

                //    string filtermand = QHC.CmpMulti(R, "idmankind", "yman", "nman");
                //    filtermand = QHC.AppAnd(filtermand, QHC.CmpEq("rownum", R["manrownum", DataRowVersion.Original]));

                //    DataRow[] RM = MandateDetail.Select(filtermand);
                //    if ((RM == null) || (RM.Length == 0))
                //        continue;
                //    DataRow Detail = RM[0];
                //    decimal oldnumber = CfgFn.GetNoNullDecimal(R["number", DataRowVersion.Original]);
                //    decimal newnumber = 0;
                //    decimal oldresidual = CfgFn.GetNoNullDecimal(Detail["residual"]);
                //    decimal newresidual = oldresidual - newnumber + oldnumber;
                //    Detail["residual"] = newresidual;
                //}

                //foreach (DataRow R in MandateDetail.Select()) {
                //    decimal residual = CfgFn.GetNoNullDecimal(R["residual"]);
                //    if (residual == 0)
                //        R.Delete();
                //}

                MandateDetail.AcceptChanges();
                if (MandateDetail.Select().Length > 0) {
                    MetaData MAP;
                    if (HasDDT) {
                        MAP = Meta.Dispatcher.Get("mandatedetailstockedtoinvoice");
                    }
                    else {
                        MAP = Meta.Dispatcher.Get("mandatedetailnoddttoinvoice");
                    }
                    MAP.DescribeColumns(MandateDetail, "default");
                    DataSet D = new DataSet();
                    D.Tables.Add(MandateDetail);
                    HelpForm.SetDataGrid(dgrDettagliCP, MandateDetail);
                    dgrDettagliCP.TableStyles.Clear();
                    HelpForm.SetGridStyle(dgrDettagliCP, MandateDetail);
                    formatgrids format = new formatgrids(dgrDettagliCP);
                    format.AutosizeColumnWidth();
                    //SelezionaTutto();
                }
            }
            else {
                btnEseguiAssociazione.Enabled = false;
            }
        }

        private DataRow IndividuaFatturaMadre(DataRow r) {
            if (fatture_madri.Rows.Count == 0)
                return null;

            if (fatture_madri.Rows.Count == 1) {
                DataRow R = fatture_madri.Rows[0];
                return R;
            }
            if (r["IdDocumento"] == DBNull.Value) return null;
            string VistaScelta = "invoiceview";
            MetaData MIinvoiceview = Meta.Dispatcher.Get(VistaScelta);
            MIinvoiceview.FilterLocked = true;
            MIinvoiceview.DS = DS;
 
            MessageBox.Show("Selezionare la Fattura madre da associare al dettaglio di descrizione "+r["Descrizione"] +
                        " e imponibile "+CfgFn.GetNoNullDecimal(r["PrezzoUnitario"]).ToString("c"), "Avviso",MessageBoxButtons.OK);
            DataRow MyDR = null;
            string filter = QHS.CmpEq("doc", r["IdDocumento"]);            
            while (MyDR == null) {
                MyDR = MIinvoiceview.SelectOne("default", filter, null, null);
                if (MyDR != null) {
                    return MyDR;
                }
                MessageBox.Show($@"E' necessario selezionare una fattura madre(idDocument:{r["IdDocumento"]}) da associare al dettaglio",
                    @"Avviso", 
                    MessageBoxButtons.OK);
                if (filter != null) {
                    filter = null;
                    MessageBox.Show(
                        @"Non avendo selezionato nulla la ricerca della fattura non sar‡ fatta per documento ma tra tutte.",
                        @"Avviso",
                        MessageBoxButtons.OK);
                }
                //else {
                //    return null;
                //}
            }
            return null;
        }

        private object IndividuaAliquota(DataRow FE_Selected) {
            string filterAttivita = null;
            if (flagactivity != null) {
                int intflagactivity = CfgFn.GetNoNullInt32(flagactivity);
                if (intflagactivity == 1)
                    filterAttivita = QHS.BitSet("flag", 0);
                if (intflagactivity == 2)
                    filterAttivita = QHS.BitSet("flag", 1);
                if (intflagactivity == 3)
                    filterAttivita = QHS.BitSet("flag", 2);
            }
            object idivakind = DBNull.Value;
            //decimal AliquotaIVA = CfgFn.GetNoNullDecimal(FE_Selected["AliquotaIVA"]);
            double AliquotaIVA = CfgFn.GetNoNullDouble(FE_Selected["AliquotaIVA"]);
            if (CfgFn.GetNoNullDouble(AliquotaIVA) > 0) {
                DataTable Tivakind = Conn.RUN_SELECT("ivakind", "*", "unabatabilitypercentage ASC", QHS.AppAnd(QHS.CmpEq("rate", AliquotaIVA), QHS.CmpEq("active", "S"), filterAttivita), null, true);
                if ((Tivakind == null) || (Tivakind.Rows.Count == 0)) {
                    MessageBox.Show("Non Ë stata trovata un'aliquota per l'iva al " +
                                    AliquotaIVA.ToString("n") + "%");
                }
                if (Tivakind.Rows.Count == 1) {
                    DataRow Rivakind = Tivakind.Rows[0];
                    idivakind = Rivakind["idivakind"];
                }
                if (Tivakind.Rows.Count > 1) {
                    string VistaScelta = "ivakind";
                    MetaData MIvakind = Meta.Dispatcher.Get(VistaScelta);
                    MIvakind.FilterLocked = true;
                    MIvakind.DS = DS;
                    double AliquotaIVA_Perc = CfgFn.GetNoNullDouble(AliquotaIVA)*100;
                    MessageBox.Show("Sono stati trovati diversi tipi IVA con aliquota al " +
                                    AliquotaIVA_Perc.ToString("n") + "%. Selezionare quello pi˘ appropriato.");
                    DataRow MyDR = null;
                    while (MyDR == null) {
                        MyDR = MIvakind.SelectOne("default", QHS.AppAnd(QHS.CmpEq("rate", AliquotaIVA), QHS.CmpEq("active", "S"), filterAttivita), null, null);
                        if (MyDR != null) {
                            idivakind = MyDR["idivakind"];
                        }
                    }
                }
            }
            else {
                // Se l'aliquota Ë 0, in base alla Natura, fa scegliere la corretta Aliquota 0.00 %
                //string Natura = FE_Selected["Natura"].ToString(); col task 6713 Ë stato rimosso il filtro sulla natura
                DataTable Tivakind = Conn.RUN_SELECT("ivakind", "*", "unabatabilitypercentage ASC", QHS.AppAnd(QHS.CmpEq("rate", 0), QHS.CmpEq("active", "S"), filterAttivita), null, true);
                if ((Tivakind == null) || (Tivakind.Rows.Count == 0)) {
                    MessageBox.Show("Non Ë stata trovata alcuna aliquota 0.00 % attiva, coerente con l'attivit‡ del Tipo documento.");
                }
                if (Tivakind.Rows.Count == 1) {
                    DataRow Rivakind = Tivakind.Rows[0];
                    idivakind = Rivakind["idivakind"];
                }
                if (Tivakind.Rows.Count > 1) {
                    string VistaScelta = "ivakind";
                    MetaData MIvakind = Meta.Dispatcher.Get(VistaScelta);
                    MIvakind.FilterLocked = true;
                    MIvakind.DS = DS;
                    DataRow MyDR = null;
                    while (MyDR == null) {
                        MyDR = MIvakind.SelectOne("default", QHC.AppAnd(QHC.CmpEq("rate", 0), QHC.CmpEq("active", "S"), filterAttivita), null, null);
                        if (MyDR != null) {
                            idivakind = MyDR["idivakind"];
                        }
                    }
                }
            }
            return idivakind;
        }

        void DeSelezionaTutto(DataGrid DG ) {
            object dataSource = DG.DataSource;
            if (dataSource == null)
                return;

            CurrencyManager cm = (CurrencyManager)
                DG.BindingContext[dataSource, DG.DataMember];

            DataView view = cm.List as DataView;
            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    DG.UnSelect(i);
                }
            }
        }

        private void btnEseguiAssociazione_Click(object sender, EventArgs e) {
            CP_SelectedRows = GetGridSelectedRows(dgrDettagliCP);
            if ((CP_SelectedRows == null) || (CP_SelectedRows.Length == 0)) {
                MessageBox.Show("Non Ë stato selezionato alcun dettaglio Contratto Passivo.");
                return;
            }

            FE_SelectedRows = GetGridSelectedRows(dgrDettagliFE);
            if ((FE_SelectedRows == null) || (FE_SelectedRows.Length == 0)) {
                MessageBox.Show("Non Ë stato selezionato alcun dettaglio della Fattura Elettronica.");
                return;
            }

            // Se la q.t‡ del dettaglio CP Ë minore della q.t‡ dettaglio FE, deseleziona l'associazione
            decimal quantitaFE = CfgFn.GetNoNullDecimal(FE_SelectedRows[0]["quantita"]);    //FE_SelectedRows[0]: C'Ë solo un dettaglio FE selezionato
            decimal quantitaCP = CfgFn.GetNoNullDecimal(CP_SelectedRows[0]["number"]);    //Se sono stati selezionati pi˘ dettagli CP, vuol dire che sono fratelli di split, 
                                                                                                 // ed hanno la stessa q.t‡. Quindi basta prenderne uno.
            if (quantitaCP < quantitaFE) {
                //Deseleziona tutto ed esce
                MessageBox.Show("Q.t‡ Fattura Elettronica pari a " + quantitaFE.ToString()+ ". Q.t‡ dettaglio Contratto Passivo pari a " + quantitaCP.ToString()+".");
                DeSelezionaTutto(dgrDettagliCP);
                DeSelezionaTutto(dgrDettagliFE);
                CP_SelectedRows = null;
                FE_SelectedRows = null;
                return;
            }

            //Scrive le associazioni in Tassociazioni
            DataRow R=null;
            DataRow FE_Selected = FE_SelectedRows[0];//C'Ë solo un dettaglio FE selezionato

                foreach (DataRow rCP in CP_SelectedRows) {
                    R = Tassociazioni.NewRow();
                    R["idmankind"] = rCP["idmankind"];
                    R["yman"] = rCP["yman"];
                    R["nman"] = rCP["nman"];
                    R["rownum"] = rCP["rownum"];
                    R["idgroup"] = rCP["idgroup"];
                    R["id"] = FE_Selected["id"];

                    //Cerca di individuare l'aliquota corretta
                    //object idivakind = IndividuaAliquota(FE_Selected);

                    R["idivakind"] = rCP["idivakind"];
                    R["taxrate"] = rCP["taxrate"];//FE_Selected["AliquotaIVA"];
                    R["residual"] = FE_Selected["Quantita"];//rCP["residual"];
                    R["detaildescription"] = rCP["detaildescription"];
                    R["taxable"] = rCP["taxable"];
                    //se la q.t‡ della FE Ë diversa da quella del CP, per esempio ho ordinato 10 e mi sta arrivando 2, deve calcolare l'iva come:q.t‡ FE * imponibile CP * sconto CP
                    if (quantitaFE == quantitaCP) {
                        R["tax"] = rCP["tax"];
                        R["unabatable"] = rCP["unabatable"];
                    }
                    else {
                        decimal imponibile = CfgFn.GetNoNullDecimal(rCP["taxable"]);
                        decimal aliquota = CfgFn.GetNoNullDecimal(rCP["taxrate"]);
                        decimal sconto = CfgFn.GetNoNullDecimal(rCP["discount"]);
                        decimal imponibileTotale = (imponibile * quantitaFE * (1 - sconto));
                        decimal iva = Decimal.Round(imponibileTotale * aliquota,2);
                        R["tax"] = iva;
                        string filterIvakind = QHS.CmpEq("idivakind", rCP["idivakind"]);
                        decimal percindeduc = 0;
                        DataTable Tivakind = Conn.RUN_SELECT("ivakind", "unabatabilitypercentage", null, filterIvakind, null,false);
                        if ((Tivakind!=null) && (Tivakind.Rows.Count>0)) {
                            DataRow Rivakind = Tivakind.Rows[0];
                            percindeduc = CfgFn.GetNoNullDecimal(Rivakind["unabatabilitypercentage"]);
                            R["unabatable"] = Decimal.Round(iva * percindeduc, 2);
                        }
                    }
                    if (R.Table.Columns.Contains("cigcode") && rCP.Table.Columns.Contains("cigcode")) {
                        R["cigcode"] = rCP["cigcode"];

                    }
                    if (R.Table.Columns.Contains("cupcode") && rCP.Table.Columns.Contains("cupcode")) {
                        R["cupcode"] = rCP["cupcode"];

                    }
             
                    R["discount"] = rCP["discount"];
                    R["idupb"] = rCP["idupb"];
                    R["idupb_iva"] = rCP["idupb_iva"];
                    R["idsor1"] = rCP["idsor1"];
                    R["idsor2"] = rCP["idsor2"];
                    R["idsor3"] = rCP["idsor3"];
                    R["idcostpartition"] = rCP["idcostpartition"];
                    R["competencystart"] = rCP["competencystart"];
                    R["competencystop"] = rCP["competencystop"];
                    R["idaccmotive"] = rCP["idaccmotive"];
                    R["va3type"] = rCP["va3type"];
                    R["idlist"] = rCP["idlist"];
                    R["idunit"] = rCP["idunit"];
                    R["idpackage"] = rCP["idpackage"];
                    R["unitsforpackage"] = rCP["unitsforpackage"];
                    R["expensekind"] = rCP["expensekind"];
                    R["number"] = FE_Selected["Quantita"];
                    R["npackage"] = rCP["npackage"];
                    R["idepexp"] = rCP["idepexp"];
                    R["assetkind"] = rCP["assetkind"];
                    R["idsor_siope"] = rCP["idsor_siope"];
                    R["requested_doc"] = rCP["requested_doc"];
                // Inserisce le info della fattura madre, se trattasi di Nota di variazione
                DataRow Rmadre = IndividuaFatturaMadre(FE_Selected);
                    if (Rmadre != null) {
                        R["idinvkind_main"] = Rmadre["idinvkind"];
                        R["yinv_main"] = Rmadre["yinv"];
                        R["ninv_main"] = Rmadre["ninv"];
                    }
                    Tassociazioni.Rows.Add(R);
                }//fine foreach

            Tassociazioni.AcceptChanges();
            // Cancella le righe gi‡ selezionate dai datagrid
            FE_Selected.Delete();
            
            dettagli_fe.AcceptChanges();

            foreach (DataRow RR in CP_SelectedRows) {
                string filterDettCP = QHC.AppAnd(QHC.CmpEq("idmankind", RR["idmankind"]), QHC.CmpEq("yman", RR["yman"]),
                    QHC.CmpEq("nman", RR["nman"]), QHC.CmpEq("rownum", RR["rownum"]), QHC.CmpEq("idgroup", RR["idgroup"]));
                foreach (DataRow rCP in MandateDetail.Select(filterDettCP)){
                    rCP.Delete();
                    }
            }
            MandateDetail.AcceptChanges();

            CP_SelectedRows = null;
            FE_SelectedRows = null;
        }

        private bool alreadyselected(DataRow curr_rowgrid, DataRow[] RrowSelected) {
            foreach (DataRow R in RrowSelected)
                if (R == curr_rowgrid)
                    return true;
            return false;

        }
        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.AppAnd(QHC.CmpEq("idmankind", G[index, 0]),
                            QHC.CmpEq("yman", G[index, 2]),
                            QHC.CmpEq("nman", G[index, 3]),
                            QHC.CmpEq("rownum", G[index, 4]));

            DataRow[] selectresult = MyTable.Select(filter);
            if (selectresult.Length == 0)
                return null;
            return selectresult[0];
        }

        DataRow GetGridRowFE(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.CmpEq("id", G[index, 0]);

            DataRow[] selectresult = MyTable.Select(filter);
            if (selectresult.Length == 0)
                return null;
            return selectresult[0];
        }

        void SelectGridRowsIdemGroup(DataRow R, DataGrid G, bool select) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            for (int i = 0; i < MyTable.Rows.Count; i++) {
                if (G[i, 0].ToString() == R["idmankind"].ToString()
                    && G[i, 2].ToString() == R["yman"].ToString()
                    && G[i, 3].ToString() == R["nman"].ToString()
                    && G[i, 4].ToString() != R["rownum"].ToString()
                    && G[i, 5].ToString() == R["idgroup"].ToString()) {
                    if (select)
                        G.Select(i);
                    if (!select)
                        G.UnSelect(i);
                }
            }
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null)
                return null;
            if (G.DataSource == null)
                return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    if (MyTable.TableName.Contains("mandatedetail")) {
                        Res[count++] = GetGridRow(G, i);
                    }
                    else {
                        Res[count++] = GetGridRowFE(G, i);
                    }
                }
            }
            return Res;
        }

        bool InsidePaintCP = false;
        private void dgrDettagliCP_Paint(object sender, PaintEventArgs e) {
            if (dgrDettagliCP.DataMember == null || dgrDettagliCP.DataMember == "")
                return;
            if (InsidePaintCP)
                return;
            InsidePaintCP = true;
            int i;

            string TableName = dgrDettagliCP.DataMember.ToString();
            DataSet MyDS = (DataSet)dgrDettagliCP.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            int numrighetemp = MyTable.Rows.Count;
            DataRow gridrow = null;

            // Contiene le righe selezionate RowSelectedbk, lo fa solo una volta
            if (CP_SelectedRowsbk == null)
                CP_SelectedRowsbk = new DataRow[numrighetemp];

            for (i = 0; i < numrighetemp; i++) {
                if (dgrDettagliCP.IsSelected(i)) {
                    gridrow = GetGridRow(dgrDettagliCP, i);
                    if (alreadyselected(gridrow, CP_SelectedRowsbk))
                        continue;
                    SelectGridRowsIdemGroup(gridrow, dgrDettagliCP, true);
                }
                if (!(dgrDettagliCP.IsSelected(i))) {
                    gridrow = GetGridRow(dgrDettagliCP, i);
                    if (!(alreadyselected(gridrow, CP_SelectedRowsbk)))
                        continue;
                    //deve de-selezionare ciÚ che era selezionato
                    SelectGridRowsIdemGroup(gridrow, dgrDettagliCP, false);
                }
            }

            CP_SelectedRowsbk = GetGridSelectedRows(dgrDettagliCP);
            InsidePaintCP = false;

            if ((CP_SelectedRowsbk != null) && (CP_SelectedRowsbk.Length > 0)) {
                btnEseguiAssociazione.Enabled = true;
                btnImportaSenzaAssociazione.Enabled = false;
                btnImportaTuttaFESenzaAssociazione.Enabled = false;
            }
            else {
                btnEseguiAssociazione.Enabled = false;
                btnImportaSenzaAssociazione.Enabled = true;
                btnImportaTuttaFESenzaAssociazione.Enabled = true;
            }

        }

        bool InsidePaintFE = false;
        private void dgrDettagliFE_Paint(object sender, PaintEventArgs e) {
            if (dgrDettagliFE.DataMember == null || dgrDettagliFE.DataMember == "")
                return;
            if (InsidePaintFE)
                return;
            InsidePaintFE = true;
         

            string TableName = dgrDettagliFE.DataMember.ToString();
            DataSet MyDS = (DataSet)dgrDettagliFE.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            int numrighetemp = MyTable.Rows.Count;
            //DataRow gridrow = null;

            // Contiene le righe selezionate FE_RowSelectedbk, lo fa solo una volta
            if (FE_SelectedRowsbk == null)
                FE_SelectedRowsbk = new DataRow[numrighetemp];

            //for (i = 0; i < numrighetemp; i++) {
            //    if (dgrDettagliFE.IsSelected(i)) {
            //        gridrow = GetGridRowFE(dgrDettagliFE, i);
            //        if (alreadyselected(gridrow, FE_SelectedRowsbk))
            //            continue;
            //        //SelectGridRowsIdemGroup(gridrow, dgrDettagliFE, true);
            //    }
            //    //if (!(dgrDettagliFE.IsSelected(i))) {
            //    //    gridrow = GetGridRowFE(dgrDettagliFE, i);
            //    //    if (!(alreadyselected(gridrow, FE_SelectedRowsbk)))
            //    //        continue;
            //    //    //deve de-selezionare ciÚ che era selezionato
            //    //    //SelectGridRowsIdemGroup(gridrow, dgrDettagliFE, false);
            //    //}
            //}

            FE_SelectedRowsbk = GetGridSelectedRows(dgrDettagliFE);
            InsidePaintFE = false;

            if ((dettagli_fe==null)|| (dettagli_fe.Rows.Count == 0)) {
                btnOk.Enabled = true;
            }
            else {
                btnOk.Enabled = false;
            }

        }

        private void btnImportaSenzaAssociazione_Click(object sender, EventArgs e) {
            FE_SelectedRows = GetGridSelectedRows(dgrDettagliFE);
            if ((FE_SelectedRows == null) || (FE_SelectedRows.Length == 0)) {
                MessageBox.Show("Non Ë stato selezionato alcun dettaglio della Fattura Elettronica.");
                return;
            }
            //Scrive le associazioni in Tassociazioni
            DataRow R = null;
            double AliquotaIVA = 0; 
            double AliquotaIVAOld = -1; 
            object idivakind = DBNull.Value; 
            foreach (DataRow rFE in FE_SelectedRows) {
                R = Tassociazioni.NewRow();
                R["id"] = rFE["id"];
                R["NumeroLinea"] = rFE["NumeroLinea"];

                AliquotaIVA = CfgFn.GetNoNullDouble(rFE["AliquotaIVA"]);

                if ((AliquotaIVA != AliquotaIVAOld) || (idivakind == DBNull.Value)) {
                    //Cerca di individuare l'aliquota corretta
                    idivakind = IndividuaAliquota(rFE);
                }
                AliquotaIVAOld = AliquotaIVA; 


                R["idivakind"] = idivakind;
                R["taxrate"] = rFE["AliquotaIVA"];
                if (rFE["Descrizione"].ToString().Length > 150) {
                    R["detaildescription"] = rFE["Descrizione"].ToString().Substring(0, 150);
                }
                else {
                    R["detaildescription"] = rFE["Descrizione"];
                }
                R["taxable"] = rFE["PrezzoUnitario"];
                R["tax"] = rFE["ImportoIVA"];
                //Calcola iva indetraibili
                decimal iva = CfgFn.GetNoNullDecimal(rFE["ImportoIVA"]);
                string filterIvakind = QHS.CmpEq("idivakind", idivakind);
                decimal percindeduc = 0;
                DataTable Tivakind = Conn.RUN_SELECT("ivakind", "unabatabilitypercentage", null, filterIvakind, null, false);
                if ((Tivakind != null) && (Tivakind.Rows.Count > 0)) {
                    DataRow Rivakind = Tivakind.Rows[0];
                    percindeduc = CfgFn.GetNoNullDecimal(Rivakind["unabatabilitypercentage"]);
                    R["unabatable"] = Decimal.Round(iva * percindeduc, 2);
                }
                if (CfgFn.GetNoNullDecimal(rFE["PercentualeSconto"]) != 0) { //task 6845
                    R["discount"] = rFE["PercentualeSconto"];
                }
                else {
                    R["discount"] = DBNull.Value;
                }
                R["number"] = rFE["Quantita"];
                R["npackage"] = rFE["Quantita"];
                R["unitsforpackage"] = rFE["unitsforpackage"];
                R["residual"] = rFE["Quantita"];//number
                // Inserisce le info della fattura madre, se trattasi di Nota di variazione
                DataRow Rmadre = IndividuaFatturaMadre(rFE);
              
                if (Rmadre != null) {
                    R["idinvkind_main"] = Rmadre["idinvkind"];
                    R["yinv_main"] = Rmadre["yinv"];
                    R["ninv_main"] = Rmadre["ninv"];
                }
                if (R.Table.Columns.Contains("cigcode") && rFE.Table.Columns.Contains("CodiceCIG")) {
                    R["cigcode"] = rFE["CodiceCIG"];

                }
                if (R.Table.Columns.Contains("cupcode") && rFE.Table.Columns.Contains("cupcode")) {
                    R["cupcode"] = rFE["cupcode"];

                }             
                Tassociazioni.Rows.Add(R);
            }
            Tassociazioni.AcceptChanges();

            // Cancella le righe gi‡ selezionate dai datagrid
            foreach (DataRow RR in FE_SelectedRows) {
                //string filterDettFE = QHC.CmpEq("NumeroLinea", RR["NumeroLinea"]);
                //foreach (DataRow rFE in dettagli_fe.Select(filterDettFE)) {
                //    rFE.Delete();
                //}
                RR.Delete();
            }
            dettagli_fe.AcceptChanges();


            FE_SelectedRows = null;
        }

        private void dgrDettagliFE_MouseUp(object sender, MouseEventArgs e) {
            //Impedisce la multiselezione col mouse
            HelpForm.HelpForm_MouseUp(sender, e);
        }

        private void dgrDettagliCP_MouseUp(object sender, MouseEventArgs e) {
            //Impedisce la multiselezione col mouse
            HelpForm.HelpForm_MouseUp(sender, e);
        }

        private void dgrDettagliFE_KeyUp(object sender, KeyEventArgs e) {
            //Impedisce la multiselezione da tastiera
            HelpForm.HelpForm_KeyUp(sender, e);
        }

        private void dgrDettagliCP_KeyUp(object sender, KeyEventArgs e) {
            //Impedisce la multiselezione da tastiera
            HelpForm.HelpForm_KeyUp(sender, e);
        }

        void SelezionaTuttoDgrFE() {
            object dataSource = dgrDettagliFE.DataSource;
            if (dataSource == null)
                return;

            CurrencyManager cm = (CurrencyManager)
                dgrDettagliFE.BindingContext[dataSource, dgrDettagliFE.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    dgrDettagliFE.Select(i);
                }
            }
        }

        private void btnImportaTuttaFESenzaAssociazione_Click(object sender, EventArgs e) {
            SelezionaTuttoDgrFE();
            btnImportaSenzaAssociazione_Click(sender, e);
        }

        private void FrmAssociaDettagliDaFE_FormClosing(object sender, FormClosingEventArgs e) {
            if (e.Cancel == true) return;
            if (sceltaManualeIgnora) return;
            if (this.DialogResult != DialogResult.OK) return;
            if (Tassociazioni == null || Tassociazioni.Rows.Count == 0) {
                MessageBox.Show("Non Ë stata creata alcuna associazione.", "Avviso");
                e.Cancel = true;
            }
        }
        bool sceltaManualeIgnora = false;
        private void btnIgnoraeInserisci_Click(object sender, EventArgs e) {
            sceltaManualeIgnora = true;
        }
    }
}
