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
using System.Xml;
using System.Xml.Schema;
using System.Xml.Xsl;
using System.IO;
using System.Security;
using System.Globalization;

namespace electronicinvoice_default {
    public partial class Frm_electronicinvoice_default : Form {
        MetaData Meta;
        QueryHelper QHS;
        CQueryHelper QHC;
        DataAccess Conn;
        private XmlTextWriter writer;
        private XmlTextWriter writersdi;
        public Frm_electronicinvoice_default() {
            InitializeComponent();
            QueryCreator.SetTableForPosting(DS.invoiceview, "invoice");

        }

        int esercizio;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            Conn = Meta.Conn;
            //GetData.SetStaticFilter(DS.electronicinvoice, QHS.CmpEq("yelectronicinvoice", Meta.GetSys("esercizio")));
            string filterOnlyPA = QHC.IsNotNull("ipa_fe");
            //GetData.SetStaticFilter(DS.registry, filterOnlyPA);
            QueryCreator.SetFilterForInsert(DS.treasurer,QHS.AppAnd(QHS.CmpEq("active","S"), QHS.IsNotNull("departmentname_fe")));
            QueryCreator.SetFilterForSearch(DS.treasurer, QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.IsNotNull("departmentname_fe")));
            QueryCreator.SetInsertFilter(DS.treasurer, QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.IsNotNull("departmentname_fe")));
            QueryCreator.SetSearchFilter(DS.treasurer, QHS.AppAnd(QHS.CmpEq("active", "S"), QHS.IsNotNull("departmentname_fe")));
            GetData.CacheTable(DS.license);

            esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filterEsercizio, null, false);
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

                int flag = CfgFn.GetNoNullInt32(r["flag"]);
                usaFTP = (flag & 2) != 0;
            }
            if (usaFTP) {
                btnGenera.Visible = false;
                txtPercorso.Visible = false;
            }
            else {
                btnInviaSdI.Visible = false;
            }


        }
        bool usaFTP = false;

        public void MetaData_AfterClear() {
            txtEsercizio.ReadOnly = false;
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
//            txtDenominazione.Text = "";
            txtCodiceFiscale.Text = "";
            txtPIva.Text = "";
            btnVisualizza.Enabled = false;
            //webBrowser1.DocumentText = "";
            txtPercorso.Text = "";            
            AbilitaDisabilitaControlli();
            grpRifAmmMittenteVendita.Enabled = true;
            grpIPAMittenteVendita.Enabled = true;
            txtNomeFile.Text = "";
            Meta.myHelpForm.ResetComboBoxSource(cmbCodiceIstituto, "treasurer");

        }


        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (!Meta.DrawStateIsDone)
                return;

            if (T.TableName == "registry") {
                Meta.GetFormData(true);
                //Imposta l'ipa del Destinatario, solo se Insert. Lo fa solo una volta, poi la persona lo puà modificare
                if (Meta.InsertMode) {
                    if ((R != null) && (R["ipa_fe"].ToString() != "")) {
                        txtIpa_ven_cliente.Text = R["ipa_fe"].ToString();
                    }
                    else {
                        txtIpa_ven_cliente.Text = "";
                    }
					if ((R != null) && (R["pec_fe"].ToString() != "")) {
						txtPec_ven_cliente.Text = R["pec_fe"].ToString();
					} else {
						txtPec_ven_cliente.Text = "";
					}
					if ((R != null) && (R["email_fe"].ToString() != "")) {
						txtEmail_ven_cliente.Text = R["email_fe"].ToString();
					} else {
						txtEmail_ven_cliente.Text = "";
					}

				}
                if (Meta.EditMode) {
                    if ((R != null) && (R["ipa_fe"].ToString() != "") ) {
                        txtIpa_ven_cliente.Text = R["ipa_fe"].ToString();
                    }
                    else {
                        txtIpa_ven_cliente.Text = "";
                    }
					if ((R != null) && (R["pec_fe"].ToString() != "")) {
						txtPec_ven_cliente.Text = R["pec_fe"].ToString();
					} else {
						txtPec_ven_cliente.Text = "";
					}
					if ((R != null) && (R["email_fe"].ToString() != "")) {
						txtEmail_ven_cliente.Text = R["email_fe"].ToString();
					} else {
						txtEmail_ven_cliente.Text = "";
					}
				}

            }

        }

        public void MetaData_BeforeFill() {
            Meta.myHelpForm.RefilterComboBoxSource(cmbCodiceIstituto, "treasurer");
        }
        public void MetaData_AfterFill() {
            txtEsercizio.ReadOnly = true;
            txtCodiceFiscale.Text = DS.license.Rows[0]["cf"].ToString();
            txtPIva.Text = DS.license.Rows[0]["p_iva"].ToString();
            AbilitaDisabilitaVisualizzaFattura();
            AbilitaDisabilitaControlli();
            ImpostaIpaRifEmittente();
            Calcola_e_Mostra_Nomefile();
        }
        public void Calcola_e_Mostra_Nomefile(){
            if (MetaData.Empty(this))  return;
            if (Meta.InsertMode)
                return;  
            if (DS.electronicinvoice.Rows.Count == 0) {
                return;
            }
            string NomeFile = BuildNomeFileXml();
            txtNomeFile.Text = NomeFile;
        }
        public void ImpostaIpaRifEmittente() {
            if (DS.electronicinvoice.Rows.Count == 0) {
                return;
            }
            DataRow Curr = DS.electronicinvoice.Rows[0];
            // Se agli attributi di sicurezza attuali corrisponde un solo ipa/rif amm, lo mettiamo in automatico come default e li rendiamo NON modificabili
            DataTable MyIpa = Conn.RUN_SELECT("ipa", "*", null, null, null, false);
            Conn.DeleteAllUnselectable(MyIpa);
            if (MyIpa.Rows.Count == 1) {
                DataRow rI = MyIpa.Rows[0];
                txtIpa_ven_emittente.Text = rI["ipa_fe"].ToString();
                grpIPAMittenteVendita.Enabled = false;
                Curr["ipa_ven_emittente"] = rI["ipa_fe"];
            }
            else {
                grpIPAMittenteVendita.Enabled = true;
            }
            DataTable MySdi_rifamm = Conn.RUN_SELECT("sdi_rifamm", "*", null, null, null, false);
            Conn.DeleteAllUnselectable(MySdi_rifamm);
            if (MySdi_rifamm.Rows.Count == 1) {
                DataRow rRA = MySdi_rifamm.Rows[0];
                txtRifamm_ven_emittente.Text = rRA["idsdi_rifamm"].ToString();
                grpRifAmmMittenteVendita.Enabled = false;
                Curr["rifamm_ven_emittente"] = rRA["idsdi_rifamm"];
            }
            else {
                grpRifAmmMittenteVendita.Enabled = true;
            }
        }

        public bool FatturaInviataSdI() {
            if (Meta.InsertMode)
                return false;
            DataRow Curr = DS.electronicinvoice.Rows[0];
            string filterInvoice = QHC.AppAnd(QHC.CmpEq("yelectronicinvoice", Curr["yelectronicinvoice"]), QHC.CmpEq("nelectronicinvoice", Curr["nelectronicinvoice"]));

            int nInvoice = Conn.RUN_SELECT_COUNT("invoice", filterInvoice, true);
            if (nInvoice == 0) {
                return false;
            }

            filterInvoice = QHC.AppAnd(QHC.CmpEq("yelectronicinvoice", Curr["yelectronicinvoice"]), QHC.CmpEq("nelectronicinvoice", Curr["nelectronicinvoice"]), QHC.IsNull("idsdi_vendita"));

            nInvoice = Conn.RUN_SELECT_COUNT("invoice", filterInvoice, true);
            if (nInvoice == 0) {
                return true;
            }
            return false;
        }

        public void AbilitaDisabilitaControlli() {
            if (DS.electronicinvoice.Rows.Count == 0) {
                btnInviaSdI.Enabled = false;
                btnGenera.Enabled = false;
                grpCedente.Enabled = true;
                grpCliente.Enabled = true;
                btnCheck.Enabled = false;
                btnInserisci.Enabled = false;
                btnModifica.Enabled = false;
                btnRimuovi.Enabled = false;
                return;
            }
            if( FatturaInviataSdI()){
                btnInviaSdI.Enabled = false;
                grpCedente.Enabled = false;
                grpCliente.Enabled = false;
                btnCheck.Enabled = false;
                btnInserisci.Enabled = false;
                btnModifica.Enabled = false;
                btnRimuovi.Enabled = false;
            }
            else{
                btnInviaSdI.Enabled = true;
                grpCedente.Enabled = true;
                grpCliente.Enabled = true;
                btnCheck.Enabled = true;
                btnInserisci.Enabled = true;
                btnModifica.Enabled = true;
                btnRimuovi.Enabled = true;
            }
            btnGenera.Enabled = true;
        }

        public void MetaData_AfterPost() {
            AbilitaDisabilitaVisualizzaFattura();
        }

        private void AbilitaDisabilitaVisualizzaFattura() {
            if (DS.electronicinvoice.Rows.Count == 0) {
                btnVisualizza.Enabled = false;
                return;
            }
            DataRow Curr = DS.electronicinvoice.Rows[0];
            if (Curr["rtf"] == DBNull.Value) {
                btnVisualizza.Enabled = false;
                return;
            }
            else {
                btnVisualizza.Enabled = true;
            }
        }

        string GetFilterForLinking(QueryHelper QH) {
            string filter = "";
            DataRow Curr = DS.electronicinvoice.Rows[0];
            int codiceCliente = CfgFn.GetNoNullInt32(Curr["idreg"]);
            if (codiceCliente > 0) {
                filter= QH.AppAnd(QH.IsNull("nelectronicinvoice"), QH.CmpEq("flagbuysell", "V"),
                    QH.CmpEq("idreg", Curr["idreg"]));
            }
            else {
                filter= QH.AppAnd(QH.IsNull("nelectronicinvoice"), QH.CmpEq("flagbuysell", "V"));
            }

            //In base al valore di config.femode, aggiunge i filtri su IPA/Rif.amm Emittente.
            object esercizio = Conn.GetEsercizio();
            object femode = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", esercizio), "femode");
            //Ipa e Rif.Amm
            if (femode.ToString() == "R") {
                //se valorizzano rifamm, vuol dire che usano un solo ipa emittente
                filter = QH.AppAnd(filter, QH.CmpEq("rifamm_ven_emittente", Curr["rifamm_ven_emittente"]));
            }
            //Ipa
            if (femode.ToString() == "I") {
                filter = QH.AppAnd(filter, QH.CmpEq("ipa_ven_emittente", Curr["ipa_ven_emittente"]));
            }

            object ipa_ven_cliente = Curr["ipa_ven_cliente"];
            if (ipa_ven_cliente.ToString() != "") {
                filter = QH.AppAnd(filter, QH.CmpEq("ipa_ven_cliente", ipa_ven_cliente));
            }
           
            object rifamm_ven_cliente = Curr["rifamm_ven_cliente"];
            if (rifamm_ven_cliente.ToString() != "") {
                filter = QH.AppAnd(filter, QH.CmpEq("rifamm_ven_cliente", rifamm_ven_cliente));
            }

			object email_ven_cliente = Curr["email_ven_cliente"];
			if (ipa_ven_cliente.ToString() != "") {
				filter = QH.AppAnd(filter, QH.CmpEq("email_ven_cliente", email_ven_cliente));
			}

			object pec_ven_cliente = Curr["pec_ven_cliente"];
			if (pec_ven_cliente.ToString() != "") {
				filter = QH.AppAnd(filter, QH.CmpEq("pec_ven_cliente", pec_ven_cliente));
			}


			//In base ai valori di IPA/Rif.Amm. destinatario, della prima fattura scelta, filtra le succesive.
			//if (DS.invoiceview.Rows.Count > 0) {
			//    DataRow rInvoice = DS.invoiceview.Rows[0];
			//    object ipa_ven_cliente = rInvoice["ipa_ven_cliente"];
			//    if (ipa_ven_cliente.ToString() != "") {
			//        filter = QH.AppAnd(filter, QH.CmpEq("ipa_ven_cliente", ipa_ven_cliente));
			//    }
			//    else {
			//        //questo else non dovrebbe MAI verificarsi, perchè l'IPA del destinatario è obbligatorio del tracciato.
			//        filter = QH.AppAnd(filter, QH.IsNull("ipa_ven_cliente"));
			//    }
			//    object rifamm_ven_cliente = rInvoice["rifamm_ven_cliente"];
			//    if (rifamm_ven_cliente.ToString() != "") {
			//        filter = QH.AppAnd(filter, QH.CmpEq("rifamm_ven_cliente", rifamm_ven_cliente));
			//    }
			//    else {
			//        filter = QH.AppAnd(filter, QH.IsNull("rifamm_ven_cliente"));
			//    }
			//}
			return filter;
        }


        private void btnInserisci_Click(object sender, EventArgs e) {
            if (MetaData.Empty(this))  return;
            MetaData.GetFormData(this, true);

            if ((txtIpa_ven_cliente.Text=="")&&(txtPec_ven_cliente.Text == "")&& (txtEmail_ven_cliente.Text=="")) {
                MessageBox.Show(this, "Inserire Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, o indirizzo PEC o mail F.E.del Destinatario.");
                return;
            }

            string MyFilter = GetFilterForLinking(QHS);
            string command = "choose.invoiceview.default." + MyFilter;

            MetaData.Choose(this, command);

            DataSet MyDS = (DataSet)gridFatture.DataSource;
            DataTable MyTable = MyDS.Tables[gridFatture.DataMember.ToString()];
            //Se abbiamo scelto una fattura e l'anagrafica non è sta valorizzata: 
            if ((MyTable.Rows.Count > 0) &&(txtCreditoreDebitore.Text=="")) {
                DataRow MyRow = MyTable.Rows[0];
                object idreg = MyRow["idreg"];
                txtCreditoreDebitore.Text = MyRow["registry"].ToString();
                DataRow Curr = DS.electronicinvoice.Rows[0];
                Curr["idreg"] = idreg;
            }
        }

        private void btnRimuovi_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
            MetaData.Unlink_Grid(gridFatture);
        }

        private void btnModifica_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty)
                return;
            Meta.GetFormData(true);
			if ((txtIpa_ven_cliente.Text == "") && (txtPec_ven_cliente.Text == "")) {
				MessageBox.Show(this, "Inserire Codice Univoco Ufficio di PCC o Codice Univoco Ufficio di IPA, o indirizzo PEC del Destinatario.");
				return;
			}
			string MyFilter = GetFilterForLinking(QHC);
            string MyFilterSQL = GetFilterForLinking(QHS);
            Meta.MultipleLinkUnlinkRows("Composizione File Fatture Elettroniche",
                "Fatture incluse nel modello selezionato",
                "Fatture non incluse in alcun modello",
                DS.invoiceview, MyFilter, MyFilterSQL, "default");
        }

        private string sostituiscivirgolaconpunto(decimal importo) {
            string group = System.Globalization.NumberFormatInfo.CurrentInfo.NumberGroupSeparator;
            string dec = System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            string s1 = importo.ToString("g").Replace(group, "");
            return s1.Replace(dec, ".");
        }

        private void faiScegliereCartella() {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtPercorso.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private string aggiustaStringa(string stringa, bool toglichiocciola) {

            string s = stringa.Replace('’', ' ').Replace('´', ' ').Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'u').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'n').Replace('Ð', 'd').Replace('Ê', 'e').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'o').Replace('Õ', 'o').Replace('Û', 'u').Replace('Ý', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'a').Replace('Å', 'a').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'a').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'a').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'e').Replace(
                'Á', 'a').Replace('À', 'a').Replace('È', 'e').Replace('Í', 'i').Replace('Ì', 'i').Replace('Ó', 'o').Replace('Ò', 'o').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
            if (toglichiocciola)
                s = s.Replace('@', ' ');
            return s;
        }


        string getLatin1(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false);
            byte []b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] < 32) {
                    continue;
                }
                if ( b[i] >= 128) {
                    continue;
                }
                res += Encoding.ASCII.GetString(new byte[]{b[i]});
            }
            return res;
        }
        string getAZ09(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 65 && b[i] <= 90) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }
                if (b[i] >= 48 && b[i] <= 57) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }
                
            }
            return res;
        }
        string getAZ(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 65 && b[i] <= 90) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        string getdigit09(object o) {
            if (o == null || o == DBNull.Value) {
                return "";
            }
            string t = aggiustaStringa(o.ToString(), false).ToUpperInvariant();
            byte[] b = Encoding.ASCII.GetBytes(t);
            string res = "";
            for (int i = 0; i < t.Length; i++) {
                if (b[i] >= 48 && b[i] <= 57) {
                    res += Encoding.ASCII.GetString(new byte[] { b[i] });
                }

            }
            return res;
        }
        string format(object o) {
        
            if (o == null || o == DBNull.Value) return "";
            if (o.GetType() == typeof(DateTime)) return SecurityElement.Escape(FormatData((DateTime)o));
            if (o.GetType() == typeof(Decimal)) return SecurityElement.Escape(FormatDecimal((Decimal)o));
            if (o.GetType().ToString() == "System.Byte[]") return Convert.ToBase64String((byte[])o,
                                Base64FormattingOptions.InsertLineBreaks);
            string res =  SecurityElement.Escape(o.ToString());
            if (res != null) {
                res = res.Replace("\"", "&quot;").Replace("'", "&apos;");
            }
            return res;
        }

        string FormatData(DateTime Data) {
            return Data.Year.ToString() +"-"+ Data.Month.ToString().PadLeft(2, '0') +"-"+ Data.Day.ToString().PadLeft(2, '0');
        }
        string FormatDecimal(Decimal d) {
            return d.ToString("F2", CultureInfo.InvariantCulture);
        }

        string FormatGenericDecimal(Decimal d) {
            return d.ToString("N");
        }


        string FormatDecimalN(Decimal d,int N) {
            return d.ToString("F"+N, CultureInfo.InvariantCulture);
        }
        const string baseChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        public static string IntToString(int value) {

            string result = "";
            int Base = baseChars.Length; //=62

            do {
                result = baseChars[value % Base] + result;
                value = value / Base;
            }
            while (value > 0);

            return result;
        }

        private string BuildNomeFileXml() {
            DataRow Curr = DS.electronicinvoice.Rows[0];
            string Progressivo = IntToString(CfgFn.GetNoNullInt32(Curr["nelectronicinvoice"]));
            string CFTrasmittente = txtCodiceFiscale.Text;
            string NomeFileXml = "IT" + CFTrasmittente + "_" + Progressivo + ".xml";
            return NomeFileXml;
        }
        private void btnGenera_Click(object sender, EventArgs e) {
            if (DS.electronicinvoice.Rows.Count == 0) {
                return;
            }

            if (DS.invoiceview.Rows.Count == 0) {
                MessageBox.Show(this, "Non ci sono fatture!");
                return;
            }

            if (!Meta.GetFormData(false))
                return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                MessageBox.Show(this, "Per generare il file occorre prima SALVARE");
                return;
            }
            DataRow Curr = DS.electronicinvoice.Rows[0];
            DataTable tElectronicinvoice = Meta.Conn.CallSP("exp_electronicinvoice", 
                    new[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] },false,60).Tables[0];
            if (tElectronicinvoice.Rows.Count == 0) {
                MessageBox.Show(this, "Non vi sono fattura da esportare.");
                return;
            }
            DataTable tElectronicinvoicedetail = Meta.Conn.CallSP("exp_electronicinvoicedetail", 
                    new[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] },false,60).Tables[0];
            DataTable tElectronicinvoiceriepilogo = Meta.Conn.CallSP("exp_electronicinvoiceriepilogo",
                    new[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] },false,60).Tables[0];
            DataTable tElectronicinvoiceAllegati = Meta.Conn.CallSP("exp_electronicinvoiceallegati",
                    new[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] },false,60).Tables[0];

            //DialogResult dr = saveFileDialog1.ShowDialog(this);
            //if (dr == DialogResult.OK) {
            //    txtPercorso.Text = saveFileDialog1.FileName;
            //}
            //else {
            //    MessageBox.Show(this, "Non è stato selezionato il percorso in cui memorizzare il file");
            //    return;
            //}
            txtPercorso.Text = "";
            faiScegliereCartella();
            if (txtPercorso.Text == "") {
                MessageBox.Show(this, "Occorre specificare la cartella in cui creare il file", "errore");
                return;
            }

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            DataRow R = tElectronicinvoice.Rows[0];
            //ITAAABBB99T99X999W_00001.xml

            //string Progressivo = IntToString(CfgFn.GetNoNullInt32(Curr["nelectronicinvoice"]));
            //string CFTrasmittente = txtCodiceFiscale.Text;
            string NomeFile = BuildNomeFileXml();
            txtNomeFile.Text = NomeFile;
            string NomeCompletoFileXML = Path.Combine(txtPercorso.Text, NomeFile);
            try {
                File.Copy(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, NomeFile), NomeCompletoFileXML, true);
            }
            catch  {

            }
            txtPercorso.Text = NomeCompletoFileXML;


            StringWriter sw = new StringWriter();
            writer = new XmlTextWriter(sw);
            writer.Formatting = Formatting.Indented;

            writer.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' ");
            //I.ipa_ven_cliente as 'CodiceDestinatario',
            //I.rifamm_ven_cliente as 'RiferimentoAmministrazione',
            bool isPA = R["CodiceDestinatario"].ToString().Length == 6;
			
			string versione = isPA ? "FPA12" : "FPR12"; //FPA12
            string formatotrasmissione = versione;

            writer.WriteStartElement("p:FatturaElettronica");
            writer.WriteAttributeString("versione",  versione);
            writer.WriteAttributeString("xmlns", "ds", null, "http://www.w3.org/2000/09/xmldsig#");
            writer.WriteAttributeString("xmlns", "p", null, "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");// "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1"
            writer.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");
            //writer.WriteEndElement();

            //DataRow R = tElectronicinvoice.Rows[0];
            writer.WriteStartElement("FatturaElettronicaHeader"); //apre <FatturaElettronicaHeader>
            writer.WriteStartElement("DatiTrasmissione"); //Apre <DatiTrasmissione>
            writer.WriteStartElement("IdTrasmittente");// apre <IdTrasmittente>
            writer.WriteElementString("IdPaese", "IT");
            writer.WriteElementString("IdCodice", format(R["IdTrasmittenteCodice"]));
            writer.WriteEndElement();// chiude <IdTrasmittente>
            writer.WriteElementString("ProgressivoInvio", getLatin1(R["ProgressivoInvio"]));            
            writer.WriteElementString("FormatoTrasmissione", formatotrasmissione); ///era SDI11
            writer.WriteElementString("CodiceDestinatario", getAZ09(R["CodiceDestinatario"].ToString()));
			//1.1.5 < ContattiTrasmittente > Dati relativi ai contatti del trasmittente
			//1.1.5.1 < Telefono > xs:normalizedString Contatto telefonico fisso o mobile
			//1.1.5.2 < Email > xs:string   Indirizzo di posta elettronica

			if (R["CodiceDestinatario"].ToString() == "0000000" && R["pec_ven_cliente"] != DBNull.Value) {
				writer.WriteElementString("PECDestinatario", R["pec_ven_cliente"].ToString());
			}
			writer.WriteEndElement();// chiude <DatiTrasmissione>

            writer.WriteStartElement("CedentePrestatore"); //Apre <CedentePrestatore>
            writer.WriteStartElement("DatiAnagrafici"); //Apre <DatiAnagrafici>
            writer.WriteStartElement("IdFiscaleIVA");// apre <IdFiscaleIVA>
            writer.WriteElementString("IdPaese", "IT");
            writer.WriteElementString("IdCodice", format(R["IdFiscaleIvaCodiceDip"]));
            writer.WriteEndElement();// chiude <IdFiscaleIVA>
            writer.WriteElementString("CodiceFiscale", getAZ09(R["IdTrasmittenteCodice"]));
            writer.WriteStartElement("Anagrafica");// apre <Anagrafica>
            writer.WriteElementString("Denominazione", getLatin1(R["DenominazioneDip"]));
            writer.WriteEndElement();// chiude <Anagrafica>
            writer.WriteElementString("RegimeFiscale", format(R["RegimeFiscale"]));
            writer.WriteEndElement();// chiude <DatiAnagrafici>
            writer.WriteStartElement("Sede"); //Apre <Sede>
            writer.WriteElementString("Indirizzo", getLatin1(R["indirizzoDip"]));
            writer.WriteElementString("CAP", getdigit09(R["capDip"]));
            writer.WriteElementString("Comune", getLatin1(R["comuneDip"]));
            writer.WriteElementString("Provincia", getAZ(R["provinciaDip"]));
            writer.WriteElementString("Nazione", "IT");
            writer.WriteEndElement();// chiude <Sede>
			//		1.4.3 < StabileOrganizzazione > Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente non residente e con stabile organizzazione in Italia
			//	1.4.3.1 < Indirizzo > xs:normalizedString Indirizzo della sede del cessionario / committente(nome della via, piazza etc.)
			//	1.4.3.2 < NumeroCivico > xs:normalizedString Numero civico riferito all'indirizzo (non indicare se già presente nell'elemento informativo indirizzo)
			//	1.4.3.3 < CAP > xs:string   Codice Avviamento Postale
			//	1.4.3.4 < Comune > xs:normalizedString Comune relativo alla stabile organizzazione in Italia
			//	1.4.3.5 < Provincia > xs:string   Sigla della provincia di appartenenza del comune indicato nell'elemento informativo 1.4.3.4 <Comune>. Da valorizzare se l'elemento informativo 1.4,3.6 < Nazione > è uguale a IT
			//	1.4.3.6 < Nazione > xs:string   Codice della nazione espresso secondo lo standard ISO 3166 - 1 alpha - 2 code
			if ((versione == "FPR12") && (R["indirizzoStabileOrg"] != DBNull.Value)) {
				writersdi.WriteStartElement("StabileOrganizzazione"); //Apre <StabileOrganizzazione>
				writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoStabileOrg"]));
				writersdi.WriteElementString("CAP", getdigit09(R["capStabileOrg"]));
				writersdi.WriteElementString("Comune", getLatin1(R["comuneStabileOrg"]));
				writersdi.WriteElementString("Provincia", getAZ(R["provinciaStabileOrg"]));
				writersdi.WriteElementString("Nazione", getAZ(R["nazioneStabileOrg"]));
				writersdi.WriteEndElement();// chiude <StabileOrganizzazione>
			}

			//1.4.4 < RappresentanteFiscale > Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente che si avvale di rappresentante fiscale in Italia
			//	1.4.4.1 < IdFiscaleIVA > Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese(IT, DE, ES …..) ed i restanti(fino ad un massimo di 28) il codice vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
			//		1.4.4.1.1 < IdPaese > xs:string   Codice della nazione espresso secondo lo standard ISO 3166 - 1 alpha - 2 code
			//		1.4.4.1.2 < IdCodice > xs:string   Codice identificativo fiscale
			//		1.4.4.2 < Denominazione > (campo assente nella scheda indirizzi dell'anagrafica)				
			//		1.4.4.3 < Nome > (campo assente nella scheda indirizzi dell'anagrafica)			
			//		1.4.4.4 < Cognome > (campo assente nella scheda indirizzi dell'anagrafica)
			if ((versione == "FPR12") && (R["IdPaeseRappresentante"] != DBNull.Value)) {
				writersdi.WriteStartElement("RappresentanteFiscale"); //Apre <StabileOrganizzazione>
				writersdi.WriteElementString("IdPaese", getAZ(R["IdPaeseRappresentante"]));
				writersdi.WriteElementString("IdCodice", getAZ(R["IdCodiceRappresentante"]));
				writersdi.WriteElementString("Denominazione", getAZ(R["DenominazioneRappresentante"]));
				writersdi.WriteElementString("Nome", getAZ(R["NomeRappresentante"]));
				writersdi.WriteElementString("Cognome", getAZ(R["CognomeRappresentante"]));
				writersdi.WriteEndElement();// chiude <StabileOrganizzazione>
			}
			if (R["RiferimentoAmministrazione"].ToString() != "") {
                writer.WriteElementString("RiferimentoAmministrazione", getLatin1(R["RiferimentoAmministrazione"]));
            }
			if (R["RiferimentoAmministrazione"].ToString() != "") {
				writer.WriteElementString("RiferimentoAmministrazione", getLatin1(R["RiferimentoAmministrazione"]));
			}
			writer.WriteEndElement();// chiude <CedentePrestatore>

            writer.WriteStartElement("CessionarioCommittente"); //Apre <CessionarioCommittente>
            writer.WriteStartElement("DatiAnagrafici"); //Apre <DatiAnagrafici>
            if (R["IdFiscaleIvaCodiceCliente"].ToString() != "") {
                writer.WriteStartElement("IdFiscaleIVA");// apre <IdFiscaleIVA>
                writer.WriteElementString("IdPaese", getAZ(R["IdFiscaleIvaPaeseCliente"]));
                writer.WriteElementString("IdCodice", format(R["IdFiscaleIvaCodiceCliente"]));
                writer.WriteEndElement();// chiude <IdFiscaleIVA>
            }
            if (R["CFCliente"].ToString() != "") {
                writer.WriteElementString("CodiceFiscale", getAZ09(R["CFCliente"]));
            }
            writer.WriteStartElement("Anagrafica");// apre <Anagrafica>
            if (R["DenominazioneCliente"].ToString() != "") {
                writer.WriteElementString("Denominazione", getLatin1(R["DenominazioneCliente"]));
            }
            if (R["nomeCliente"].ToString() != "") {
                writer.WriteElementString("Nome", getLatin1(R["nomeCliente"]));
            }
            if (R["cognomeCliente"].ToString() != "") {
                writer.WriteElementString("Cognome", getLatin1(R["cognomeCliente"]));
            }
            writer.WriteEndElement();// chiude <Anagrafica>
            writer.WriteEndElement();// chiude <DatiAnagrafici>
            writer.WriteStartElement("Sede"); //Apre <Sede>
            writer.WriteElementString("Indirizzo", getLatin1(R["indirizzoCliente"]));
            writer.WriteElementString("CAP", getdigit09(R["capCliente"]));
            writer.WriteElementString("Comune", getLatin1(R["comuneCliente"]));
            writer.WriteElementString("Provincia", getAZ(R["provinciaCliente"]));
            writer.WriteElementString("Nazione", getAZ(R["nazioneCliente"]));
            writer.WriteEndElement();// chiude <Sede>
            writer.WriteEndElement();// chiude <CessionarioCommittente>

            writer.WriteEndElement();// Chiude -  <FatturaElettronicaHeader>
            foreach (DataRow rFattura in tElectronicinvoice.Select()) {
                writer.WriteStartElement("FatturaElettronicaBody"); //Apre <FatturaElettronicaBody>
                writer.WriteStartElement("DatiGenerali"); //Apre <DatiGenerali>
                writer.WriteStartElement("DatiGeneraliDocumento"); //Apre <DatiGeneraliDocumento>
                writer.WriteElementString("TipoDocumento", format(rFattura["TipoDocumento"]));
                writer.WriteElementString("Divisa", getAZ(rFattura["divisa"]));
                writer.WriteElementString("Data", format(rFattura["data"]));
                writer.WriteElementString("Numero", getLatin1(rFattura["numero"]));

                if (tElectronicinvoice.Columns.Contains("idstampkind") && rFattura["idstampkind"].ToString().ToUpper() == "DM19_2014") {
                    writer.WriteStartElement("DatiBollo"); //Apre <DatiBollo>
                    //writer.WriteElementString("NumeroBollo", format("DM-17-GIU-2014"));
                    writer.WriteElementString("BolloVirtuale", format("SI"));
                    decimal impBollo = 2;
                    writer.WriteElementString("ImportoBollo", format(impBollo));
                    writer.WriteEndElement();// Chiude -  <DatiBollo>
                }

                if (rFattura["tipoScontoMaggiorazione"].ToString() != "") {
                    writer.WriteStartElement("ScontoMaggiorazione"); //Apre <ScontoMaggiorazione>
                    writer.WriteElementString("Tipo", format(rFattura["tipoScontoMaggiorazione"]));
                    writer.WriteElementString("Importo", format(Math.Abs(CfgFn.GetNoNullDecimal(rFattura["sconto"]))));
                    writer.WriteEndElement();// Chiude -  <ScontoMaggiorazione>
                }
                writer.WriteElementString("ImportoTotaleDocumento", format(rFattura["ImportoTotaleDocumento"]));
                writer.WriteElementString("Causale", getLatin1(rFattura["causale"]));
                writer.WriteEndElement();// Chiude -  <DatiGeneraliDocumento>
               

                string filterOrdineAcquisto = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]),
                    QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]), QHC.IsNotNull("IdDocumento"));

                //"IdDocumento" viene valorizzato solo se c'è il collegamento al C.A. ed è stato indicato il cig o il cup nel dettaglio fattura.
                foreach (DataRow rDetail in tElectronicinvoicedetail.Select(filterOrdineAcquisto)) {
                    writer.WriteStartElement("DatiOrdineAcquisto");//Apre - <DatiOrdineAcquisto>
                    writer.WriteElementString("RiferimentoNumeroLinea", format(rDetail["RiferimentoNumeroLinea"]));
                    writer.WriteElementString("IdDocumento", format(rDetail["IdDocumento"]));
                    if (rDetail["DataDocumentoCollegato"].ToString() != "") {
                        writer.WriteElementString("Data", format(rDetail["DataDocumentoCollegato"]));
                    } 
                    if (rDetail["NumItem"].ToString() != "") {
                        writer.WriteElementString("NumItem", getLatin1(rDetail["NumItem"]));
                    }
                    if (rDetail["CodiceCUP"].ToString() != "") {
                        writer.WriteElementString("CodiceCUP", getLatin1(rDetail["CodiceCUP"]));
                    }
                    if (rDetail["CodiceCIG"].ToString() != "") {
                        writer.WriteElementString("CodiceCIG", getLatin1(rDetail["CodiceCIG"]));
                    }
                    writer.WriteEndElement();// Chiude -  <DatiOrdineAcquisto>
                }

                if (rFattura["tipofattura"].ToString() == "V" && rFattura["IdDocumentoFatturaMadre"].ToString()!="") {// Se è una Nota di Credito
                    writer.WriteStartElement("DatiFattureCollegate");
                    writer.WriteElementString("IdDocumento", getLatin1(rFattura["IdDocumentoFatturaMadre"]));
                    writer.WriteElementString("Data", format(rFattura["DataFatturaMadre"]));
                    writer.WriteEndElement();// Chiude -  <DatiFattureCollegate>
                }

                writer.WriteEndElement();// Chiude -  <DatiGenerali>

                writer.WriteStartElement("DatiBeniServizi"); //Apre <DatiBeniServizi>
                string filterDoc = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]), QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]));
                foreach (DataRow rDettFattura in tElectronicinvoicedetail.Select(filterDoc)) {
                    writer.WriteStartElement("DettaglioLinee"); //Apre <DettaglioLinee>
                    writer.WriteElementString("NumeroLinea", format(rDettFattura["NumeroLinea"]));
                    if (rDettFattura["TipoCessionePrestazione"].ToString() != "") {
                        writer.WriteElementString("TipoCessionePrestazione", format(rDettFattura["TipoCessionePrestazione"]));
                    }
                    if (rDettFattura["CodiceTipo"] != DBNull.Value) {
                        writer.WriteStartElement("CodiceArticolo"); //Apre <CodiceArticolo>
                        writer.WriteElementString("CodiceTipo", format(rDettFattura["CodiceTipo"]));
                        writer.WriteElementString("CodiceValore", format(rDettFattura["CodiceValore"]));
                        writer.WriteEndElement();//chiude  CodiceArticolo
                    }
                    decimal quantita = CfgFn.GetNoNullDecimal(rDettFattura["quantita"]);
                    writer.WriteElementString("Descrizione", getLatin1(rDettFattura["Descrizione"]).TrimEnd());
                    writer.WriteElementString("Quantita", format(quantita));
                    //PrezzoUnitario: decimali che vanno da un minimo di due ad un massimo di otto cifre
                    decimal prezzoUnitario = CfgFn.GetNoNullDecimal(rDettFattura["PrezzoUnitario"]);
                    decimal prezzoTotale = CfgFn.GetNoNullDecimal(rDettFattura["PrezzoTotale"]);
                    // prezzoUnitario: decimali che vanno da un minimo di due ad un massimo di otto cifre, in invoicedetail è decimal(19,5)
                    writer.WriteElementString("PrezzoUnitario", SecurityElement.Escape(FormatDecimalN(prezzoUnitario,6)));  //taxable di invoicedetail
                    if (rDettFattura["tipoScontoMaggiorazioneDettaglio"].ToString() != "") {
                        //calcola lo sconto a runtime, a scanso di equivoci
                        //int precision = 2;                        
                        //decimal scontoUnitario = CfgFn.Round((prezzoTotale / quantita) - prezzoUnitario, precision);
                        //decimal totCalcolato = CfgFn.Round((prezzoUnitario + scontoUnitario)*quantita, 2);
                        //while (precision < 8 && totCalcolato!=prezzoTotale) {
                        //    precision = precision + 1;
                        //    scontoUnitario = CfgFn.Round((prezzoTotale / quantita) - prezzoUnitario, precision);
                        //    totCalcolato = CfgFn.Round((prezzoUnitario + scontoUnitario) * quantita, 2);
                        //}
                        
                        writer.WriteStartElement("ScontoMaggiorazione"); //Apre <ScontoMaggiorazione>
                        writer.WriteElementString("Tipo", format(rDettFattura["tipoScontoMaggiorazioneDettaglio"]));
                        writer.WriteElementString("Percentuale", FormatDecimalN(Math.Abs(CfgFn.GetNoNullDecimal( rDettFattura["scontoDettaglio"])),2)); //scontoUnitario
                        writer.WriteEndElement();// Chiude -  <ScontoMaggiorazione>
                    }
                    // invoicedetailview.taxable_euro >> questo deve essere rispettato come somma totale
                    // deve essere PrezzoTotale = Quantita * (PrezzoUnitario + Sconto)
                    writer.WriteElementString("PrezzoTotale", format(prezzoTotale));
                    writer.WriteElementString("AliquotaIVA", format(rDettFattura["AliquotaIVA"]));
                    if (rDettFattura["Natura"].ToString() != "") {
                        writer.WriteElementString("Natura", format(rDettFattura["Natura"]));
                    }
                    writer.WriteEndElement();// Chiude -  <DettaglioLinee>
                }// chiusura foreach sui dettagli fattura

                foreach (DataRow rRiepilogo in tElectronicinvoiceriepilogo.Select(filterDoc)) {
                    writer.WriteStartElement("DatiRiepilogo");//Apre - <DatiRiepilogo>
                    writer.WriteElementString("AliquotaIVA", format(rRiepilogo["AliquotaIVA"]));
                    if (rRiepilogo["Natura"].ToString() != "") {
                        writer.WriteElementString("Natura", format(rRiepilogo["Natura"]));
                    }
                    writer.WriteElementString("ImponibileImporto", format(rRiepilogo["ImponibileImporto"]));
                    writer.WriteElementString("Imposta", format(rRiepilogo["Imposta"]));
                    writer.WriteElementString("EsigibilitaIVA", format(rRiepilogo["EsigibilitaIVA"]));
                    if (rRiepilogo["RiferimentoNormativo"].ToString() != "") {
                        writer.WriteElementString("RiferimentoNormativo", getLatin1(rRiepilogo["RiferimentoNormativo"]));
                    }
                    writer.WriteEndElement();// Chiude -  <DatiRiepilogo>
                }



                writer.WriteEndElement();// Chiude -  <DatiBeniServizi>

                if (rFattura["tipofattura"].ToString() == "F") {// Solo se Fattura inseriamo il blocco DatiPagamento
                    writer.WriteStartElement("DatiPagamento");//Apre - <DatiPagamento>
                    writer.WriteElementString("CondizioniPagamento", format(rFattura["CondizioniPagamento"]));

                    writer.WriteStartElement("DettaglioPagamento");
                    if (rFattura["ModalitaPagamento"].ToString().ToString() != "") {
                        writer.WriteElementString("ModalitaPagamento", format(rFattura["ModalitaPagamento"]));
                    }
                    //Data registrazione, usata anche prima    
                    writer.WriteElementString("DataRiferimentoTerminiPagamento", format(rFattura["data"]));
                    if (rFattura["idexpirationkind"].ToString() != "") {
                        DateTime DataScadenzaPagamento = CalcolaDataScadenza(rFattura["idexpirationkind"], rFattura["paymentexpiring"], rFattura["data"], rFattura["datadocumento"]);
                        int GiorniTerminiPagamento = CalcolaGiorniTerminiPagamento(rFattura["data"], DataScadenzaPagamento);
                        writer.WriteElementString("GiorniTerminiPagamento", GiorniTerminiPagamento.ToString());
                        writer.WriteElementString("DataScadenzaPagamento", FormatData(DataScadenzaPagamento));
                    }
                    writer.WriteElementString("ImportoPagamento", format(rFattura["ImportoPagamento"]));
                    if (rFattura["IBAN"].ToString() != "") {
                        writer.WriteElementString("IBAN", format(rFattura["IBAN"]));
                    }
                    if (rFattura["CodicePagamento"].ToString() != "") {
                        writer.WriteElementString("CodicePagamento", format(rFattura["CodicePagamento"]));
                    }
                    writer.WriteEndElement();// Chiude -  <DettaglioPagamento>

                    writer.WriteEndElement();// Chiude -  <DatiPagamento>

                }

                foreach (DataRow rAllegato in tElectronicinvoiceAllegati.Select(filterDoc)) {
                    writer.WriteStartElement("Allegati");//Apre - <Allegati>                        
                    writer.WriteElementString("NomeAttachment", getLatin1(rAllegato["filename"]));
                    writer.WriteElementString("Attachment", format(rAllegato["attachment"]));
                    writer.WriteEndElement();// Chiude -  <Allegati>
                }

                writer.WriteEndElement();// Chiude -  <FatturaElettronicaBody>
            }
            writer.WriteEndElement();//chiudep:Fattura
            writer.Close();


            StreamWriter stw = new StreamWriter(NomeCompletoFileXML);
            stw.Write(sw.ToString());
            stw.Flush();
            stw.Close();
            //DS.electronicinvoice.Rows[0]["docelectronicinvoice"] = sw.ToString();

            string xmlString = sw.ToString();
            byte[] xml = new UTF8Encoding().GetBytes(xmlString);
            DS.electronicinvoice.Rows[0]["rtf"] = xml;

            Meta.SaveFormData();
            MessageBox.Show("Creato il file " + NomeCompletoFileXML, "Avviso");
            //ValidaFile_conXSD();

        }

        private void ValidaFile_conXSD(){
            string fname = txtPercorso.Text.ToString();
            bool res = XML_XSD_Validator.Validate(fname, AppDomain.CurrentDomain.BaseDirectory + "fatturapa_v1.1.XSD");
            if (!res) {
                QueryCreator.ShowError(this, "Errore nella validazione dell'xml",
                                XML_XSD_Validator.GetError());
            }
           }

        private int  CalcolaGiorniTerminiPagamento(object datariferimento, DateTime DataScadenzaPagamento){
            DateTime Data_Riferimento = (DateTime)datariferimento;

            double dinizio = 0;
            double dfine = 0;

            try {
                dinizio = Data_Riferimento.ToOADate();
                dfine = DataScadenzaPagamento.ToOADate();
            }
            catch {
                return -1;
            }

            int ngiorni = Convert.ToInt32(Math.Floor(dfine - dinizio));
            return ngiorni;

        }
        private DateTime CalcolaDataScadenza(object TipoScadenza, object ngiorni, object dataregistrazione, object datadocumento) {
            int NNgiorni = CfgFn.GetNoNullInt32(ngiorni);
            DateTime Data_Registrazione = (DateTime)dataregistrazione;
            DateTime Data_Documento = (DateTime)datadocumento;
            DateTime Data_Scadenza = DateTime.MinValue;

            //  1	Data contabile = data registrazione
            //  2	Data documento
            //  3	Fine mese data documento
            //  4	Fine mese data contabile
            //  5	Pagamento Immediato

            if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(NNgiorni) > 0) {
                Data_Scadenza = Data_Registrazione.AddDays(NNgiorni);
            }
            if (CfgFn.GetNoNullInt32(TipoScadenza) == 1 && CfgFn.GetNoNullInt32(NNgiorni) == 0) {
                Data_Scadenza = Data_Registrazione;
            }
            if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(NNgiorni) > 0) {
                Data_Scadenza = Data_Documento.AddDays(NNgiorni);
            }
            if (CfgFn.GetNoNullInt32(TipoScadenza) == 2 && CfgFn.GetNoNullInt32(NNgiorni) == 0) {
                Data_Scadenza = Data_Documento;
            }
            if (CfgFn.GetNoNullInt32(TipoScadenza) == 3) {
                int intMese = Data_Documento.Month;
                int intAnno = Data_Documento.Year;
                int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
                DateTime FineMeseDataDocumento = new DateTime(intAnno, intMese, intGiorno);
                FineMeseDataDocumento = FineMeseDataDocumento.AddDays(NNgiorni);
                Data_Scadenza = FineMeseDataDocumento;
            }
            if (CfgFn.GetNoNullInt32(TipoScadenza) == 4) {
                int intMese = Data_Registrazione.Month;
                int intAnno = Data_Registrazione.Year;
                int intGiorno = DateTime.DaysInMonth(intAnno, intMese);
                DateTime FineMeseDataContabile = new DateTime(intAnno, intMese, intGiorno);
                FineMeseDataContabile = FineMeseDataContabile.AddDays(NNgiorni);
                Data_Scadenza = FineMeseDataContabile;
            }
            if (CfgFn.GetNoNullInt32(TipoScadenza) == 5) {
                Data_Scadenza = Data_Registrazione;
            }

            return Data_Scadenza;
        }

        private void btnCheck_Click(object sender, EventArgs e) {
            if (DS.electronicinvoice.Rows.Count == 0) {
                return;
            }

            if (DS.invoiceview.Rows.Count == 0) {
                MessageBox.Show(this, "Non ci sono fatture!");
                return;
            }

            if (!Meta.GetFormData(false)) return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                MessageBox.Show(this, "Per controllare i dati occorre prima SALVARE");
                return;
            }
            DataRow Curr = DS.electronicinvoice.Rows[0];
            DataTable tElectronicinvoicecheck = Meta.Conn.CallSP("exp_electronicinvoicecheck", new object[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] },false).Tables[0];
            if (tElectronicinvoicecheck == null) {
                return;
            }
            if (tElectronicinvoicecheck.Rows.Count == 0) {
                MessageBox.Show(this, "Non vi sono errori.");
                return;
            }

            exportclass.DataTableToExcel (tElectronicinvoicecheck, true);
        }

        private void btnVisualizza_Click(object sender, EventArgs e) {
            if (DS.electronicinvoice.Rows.Count == 0) {
                return;
            }

            if (!Meta.GetFormData(false))
                return;

            // Visualizza docelectronicinvoice 
            //Stream transformedData = new MemoryStream();

            //XmlDocument doc = new XmlDocument();
            //if (DS.electronicinvoice.Rows[0]["docelectronicinvoice"] == DBNull.Value)
            //    return;
            //doc.LoadXml(DS.electronicinvoice.Rows[0]["docelectronicinvoice"].ToString());

            //XslCompiledTransform xsltransform = new XslCompiledTransform();
            //xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + "fatturapa_v1.0.xsl");

            //xsltransform.Transform(doc, null, transformedData);
            //transformedData.Seek(0, SeekOrigin.Begin);
            //webBrowser1.DocumentStream = transformedData;

            // Visualizza rtf  
            //Stream transformedData = new MemoryStream();
            string tempFileName = Path.GetFileNameWithoutExtension(Path.GetTempFileName()) + ".htm";

            XmlWriter xw = XmlWriter.Create(tempFileName);
            XmlDocument doc = new XmlDocument();

            DataRow rFattura = DS.electronicinvoice.Rows[0];
            
            if (rFattura["rtf"] == DBNull.Value)
                return;
            
            byte[] xml = (byte[])DS.electronicinvoice.Rows[0]["rtf"];
            string xmlString = Encoding.UTF8.GetString(xml);
            try {
                doc.LoadXml(xmlString);
            }
            catch (Exception E2) {
                QueryCreator.ShowException(this,"Errore aprendo il file selezionato",E2);
                return;
            }

            XslCompiledTransform xsltransform = new XslCompiledTransform();
            //I.ipa_ven_cliente as 'CodiceDestinatario',
            //I.rifamm_ven_cliente as 'RiferimentoAmministrazione',
            bool isPA = rFattura["ipa_ven_cliente"].ToString().Length == 6;

            try {
                string xslNew = isPA ? "fatturapa_v1.2.xslt" : "fatturaordinaria_v1.2.xslt";
                string versione = doc.DocumentElement.Attributes["versione"].Value;
                string xsl = versione == "1.1" ? "fatturapa_v1.1.xslt" : xslNew;
                xsltransform.Load(AppDomain.CurrentDomain.BaseDirectory + xsl);
                xsltransform.Transform(doc, null, xw);
                xw.Flush();
                xw.Close();
            }
            catch (Exception E) {
                MessageBox.Show("Errore aprendo la fattura selezionata", "Errore");
                DataRow Curr = DS.electronicinvoice.Rows[0];
                string errmsg = "Frm_electronicinvoice_default: Errore su fatturapa_v1.2.xslt, Fattura anno: "+Curr["yelectronicinvoice"]+" numero: "+Curr["nelectronicinvoice"];
                Meta.LogError(errmsg, E);
            }



            try {
                System.Diagnostics.Process.Start(tempFileName);
            }
            catch (Exception ee) {
                QueryCreator.ShowException("Errore nella visualizzazione del file", ee);
            }
        }


        private void btnInviaSdI_Click(object sender, EventArgs e) {
            if (Meta.destroyed) return;

            //Crea le righe in sdi_vendita per ogni fattura selezionata
            DS.sdi_vendita.Clear();

            if (DS.electronicinvoice.Rows.Count == 0) {
                return;
            }

            if (DS.invoiceview.Rows.Count == 0) {
                MessageBox.Show(this, "Non ci sono fatture!");
                return;
            }

            if (!Meta.GetFormData(false))
                return;
            PostData.RemoveFalseUpdates(DS);
            if (DS.HasChanges()) {
                MessageBox.Show(this, "Per generare il file occorre prima SALVARE");
                return;
            }
			DataTable tElectronicinvoice = new DataTable();
			DataTable tElectronicinvoicedetail = new DataTable();
			DataTable tElectronicinvoiceriepilogo = new DataTable();
			DataTable tElectronicinvoiceAllegati = new DataTable();
			DataRow Curr = DS.electronicinvoice.Rows[0];
            Meta.dontClose = true;
			DataSet Out= Meta.Conn.CallSP("exp_electronicinvoice", new object[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] });
			if (Out == null) return;
			tElectronicinvoice = Out.Tables[0];
			if (tElectronicinvoice.Rows.Count == 0) {
                Meta.dontClose = false;
                MessageBox.Show(this, "Non vi sono fatture da esportare.");
                return;
            }
           
            DataSet Out1 = Meta.Conn.CallSP("exp_electronicinvoicedetail", new object[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] });
			if (Out1 != null) tElectronicinvoicedetail = Out1.Tables[0]; else return;
			DataSet Out2  = Meta.Conn.CallSP("exp_electronicinvoiceriepilogo", new object[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] });
			if (Out2 != null)  tElectronicinvoiceriepilogo = Out2.Tables[0]; else return;
			DataSet Out3  =  Meta.Conn.CallSP("exp_electronicinvoiceallegati", new object[] { Curr["yelectronicinvoice"], Curr["nelectronicinvoice"] });
			if (Out3 != null) tElectronicinvoiceAllegati = Out3.Tables[0];

			Meta.dontClose = false;
            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            DataRow R = tElectronicinvoice.Rows[0];

            string NomeFile = BuildNomeFileXml();
                        
            MetaData Sdi_Vendita = MetaData.GetMetaData(this, "sdi_vendita");
            Sdi_Vendita.SetDefaults(DS.sdi_vendita);

            foreach (DataRow rFattura in tElectronicinvoice.Select()) {
                Sdi_Vendita.SetDefaults(DS.sdi_vendita);
                DataRow rSdi_vendita = Sdi_Vendita.Get_New_Row(null, DS.sdi_vendita);
                rSdi_vendita["position"] = 1;  //rFattura["position"];
                //rSdi_vendita["filename"] = NomeFile; //calcolato in automatico ora
                rSdi_vendita["exported"] = "N";
                rSdi_vendita["ipa_fe"] = rFattura["ipa_ven_emittente"];
                rSdi_vendita["idsdi_rifamm"] = rFattura["rifamm_ven_emittente"];
    
                string filterInvoice = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]), QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]));
                DataRow rInvoice = DS.invoiceview.Select(filterInvoice)[0];
                rInvoice["idsdi_vendita"] = rSdi_vendita["idsdi_vendita"];

                StringWriter sw = new StringWriter();
                writersdi = new XmlTextWriter(sw);
                writersdi.Formatting = Formatting.Indented;

                writersdi.WriteProcessingInstruction("xml", "version='1.0' encoding='UTF-8' ");
                    //I.ipa_ven_cliente as 'CodiceDestinatario',
	                //I.rifamm_ven_cliente as 'RiferimentoAmministrazione',
                bool isPA = rFattura["CodiceDestinatario"].ToString().Length == 6;
				
			 

				string versione = isPA? "FPA12":"FPR12"; //FPA12
                string formatotrasmissione = versione;

                writersdi.WriteStartElement("p:FatturaElettronica");
                writersdi.WriteAttributeString("versione", versione);
                writersdi.WriteAttributeString("xmlns", "ds", null, "http://www.w3.org/2000/09/xmldsig#");
                writersdi.WriteAttributeString("xmlns", "p", null, "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2");
                writersdi.WriteAttributeString("xmlns", "xsi", null, "http://www.w3.org/2001/XMLSchema-instance");

                writersdi.WriteStartElement("FatturaElettronicaHeader"); //apre <FatturaElettronicaHeader>
                writersdi.WriteStartElement("DatiTrasmissione"); //Apre <DatiTrasmissione>
                writersdi.WriteStartElement("IdTrasmittente");// apre <IdTrasmittente>
                writersdi.WriteElementString("IdPaese", "IT");
                writersdi.WriteElementString("IdCodice", format(R["IdTrasmittenteCodice"]));
                writersdi.WriteEndElement();// chiude <IdTrasmittente>
                writersdi.WriteElementString("ProgressivoInvio", getLatin1(R["ProgressivoInvio"]));
                writersdi.WriteElementString("FormatoTrasmissione", formatotrasmissione); ///era SDI11
                writersdi.WriteElementString("CodiceDestinatario", getAZ09(R["CodiceDestinatario"]));
				//1.1.5 < ContattiTrasmittente > Dati relativi ai contatti del trasmittente
				//1.1.5.1 < Telefono > xs:normalizedString Contatto telefonico fisso o mobile
				//1.1.5.2 < Email > xs:string   Indirizzo di posta elettronica
                //if (R["email_ven_cliente"]!=DBNull.Value) {
                //    writersdi.WriteStartElement("ContattiTrasmittente"); //Apre <ContattiTrasmittente>
                //    writersdi.WriteElementString("Email", getAZ09(R["email_ven_cliente"]));
                //    writersdi.WriteEndElement();// chiude <ContattiTrasmittente>
                //}

                if (rFattura["CodiceDestinatario"].ToString() == "0000000" && R["pec_ven_cliente"] != DBNull.Value) {
					writersdi.WriteElementString("PECDestinatario", R["pec_ven_cliente"].ToString());
                }
			    
				writersdi.WriteEndElement();// chiude <DatiTrasmissione>
                writersdi.WriteStartElement("CedentePrestatore"); //Apre <CedentePrestatore>
                writersdi.WriteStartElement("DatiAnagrafici"); //Apre <DatiAnagrafici>
                writersdi.WriteStartElement("IdFiscaleIVA");// apre <IdFiscaleIVA>
                writersdi.WriteElementString("IdPaese", "IT");
                writersdi.WriteElementString("IdCodice", format(R["IdFiscaleIvaCodiceDip"]));
                writersdi.WriteEndElement();// chiude <IdFiscaleIVA>
                writersdi.WriteElementString("CodiceFiscale", getAZ09(R["IdTrasmittenteCodice"]));
                writersdi.WriteStartElement("Anagrafica");// apre <Anagrafica>
                writersdi.WriteElementString("Denominazione", getLatin1(R["DenominazioneDip"]));
                writersdi.WriteEndElement();// chiude <Anagrafica>
                writersdi.WriteElementString("RegimeFiscale", format(R["RegimeFiscale"]));
                writersdi.WriteEndElement();// chiude <DatiAnagrafici>
                writersdi.WriteStartElement("Sede"); //Apre <Sede>
                writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoDip"]));
                writersdi.WriteElementString("CAP", getdigit09(R["capDip"]));
                writersdi.WriteElementString("Comune", getLatin1(R["comuneDip"]));
                writersdi.WriteElementString("Provincia", getAZ(R["provinciaDip"]));
                writersdi.WriteElementString("Nazione", "IT");
                writersdi.WriteEndElement();// chiude <Sede>
				//		1.4.3 < StabileOrganizzazione > Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente non residente e con stabile organizzazione in Italia
				//	1.4.3.1 < Indirizzo > xs:normalizedString Indirizzo della sede del cessionario / committente(nome della via, piazza etc.)
				//	1.4.3.2 < NumeroCivico > xs:normalizedString Numero civico riferito all'indirizzo (non indicare se già presente nell'elemento informativo indirizzo)
				//	1.4.3.3 < CAP > xs:string   Codice Avviamento Postale
				//	1.4.3.4 < Comune > xs:normalizedString Comune relativo alla stabile organizzazione in Italia
				//	1.4.3.5 < Provincia > xs:string   Sigla della provincia di appartenenza del comune indicato nell'elemento informativo 1.4.3.4 <Comune>. Da valorizzare se l'elemento informativo 1.4,3.6 < Nazione > è uguale a IT
				//	1.4.3.6 < Nazione > xs:string   Codice della nazione espresso secondo lo standard ISO 3166 - 1 alpha - 2 code
				if ((versione == "FPR12") && (R["indirizzoStabileOrg"] !=DBNull.Value)) { 
					writersdi.WriteStartElement("StabileOrganizzazione"); //Apre <StabileOrganizzazione>
					writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoStabileOrg"]));
					writersdi.WriteElementString("CAP", getdigit09(R["capStabileOrg"]));
					writersdi.WriteElementString("Comune", getLatin1(R["comuneStabileOrg"]));
					writersdi.WriteElementString("Provincia", getAZ(R["provinciaStabileOrg"]));
					writersdi.WriteElementString("Nazione", getAZ(R["nazioneStabileOrg"]));
					writersdi.WriteEndElement();// chiude <StabileOrganizzazione>
				}

                if ((R["rea_number"] != DBNull.Value)) {
                    writersdi.WriteStartElement("IscrizioneREA"); //Apre <IscrizioneREA>
                    writersdi.WriteElementString("Ufficio", getAZ(R["rea_provinceoffice"]));
                    writersdi.WriteElementString("NumeroREA", getLatin1(R["rea_number"]));
                    if (format(R["rea_socialcapital"]) != ""){
                        writersdi.WriteElementString("CapitaleSociale", format(R["rea_socialcapital"]));
                    }
                    if (getLatin1(R["rea_partner"]) != "") {
                        writersdi.WriteElementString("SocioUnico", getLatin1(R["rea_partner"]));
                    }
                    writersdi.WriteElementString("StatoLiquidazione", getLatin1(R["rea_closingstatus"]));
                    writersdi.WriteEndElement();// chiude <IscrizioneREA>
                }

                //1.4.4 < RappresentanteFiscale > Blocco da valorizzare se e solo se l'elemento informativo 1.1.3 <FormatoTrasmissione> = "FPR12" (fattura tra privati), nel caso di cessionario/committente che si avvale di rappresentante fiscale in Italia
                //	1.4.4.1 < IdFiscaleIVA > Numero di identificazione fiscale ai fini IVA; i primi due caratteri rappresentano il paese(IT, DE, ES …..) ed i restanti(fino ad un massimo di 28) il codice vero e proprio che, per i residenti in Italia, corrisponde al numero di partita IVA.
                //		1.4.4.1.1 < IdPaese > xs:string   Codice della nazione espresso secondo lo standard ISO 3166 - 1 alpha - 2 code
                //		1.4.4.1.2 < IdCodice > xs:string   Codice identificativo fiscale
                //		1.4.4.2 < Denominazione > (campo assente nella scheda indirizzi dell'anagrafica)				
                //		1.4.4.3 < Nome > (campo assente nella scheda indirizzi dell'anagrafica)			
                //		1.4.4.4 < Cognome > (campo assente nella scheda indirizzi dell'anagrafica)
                if ((versione == "FPR12") && (R["IdPaeseRappresentante"] != DBNull.Value)){
					writersdi.WriteStartElement("RappresentanteFiscale"); //Apre <StabileOrganizzazione>
					writersdi.WriteElementString("IdPaese", getAZ(R["IdPaeseRappresentante"]));
					writersdi.WriteElementString("IdCodice", getAZ(R["IdCodiceRappresentante"]));
					writersdi.WriteElementString("Denominazione", getAZ(R["DenominazioneRappresentante"]));
					writersdi.WriteElementString("Nome", getAZ(R["NomeRappresentante"]));
					writersdi.WriteElementString("Cognome", getAZ(R["CognomeRappresentante"]));
					writersdi.WriteEndElement();// chiude <StabileOrganizzazione>
				}
				if (R["RiferimentoAmministrazione"].ToString() != "") {
                    writersdi.WriteElementString("RiferimentoAmministrazione", getLatin1(R["RiferimentoAmministrazione"]));
                }
                writersdi.WriteEndElement();// chiude <CedentePrestatore>

                writersdi.WriteStartElement("CessionarioCommittente"); //Apre <CessionarioCommittente>
                writersdi.WriteStartElement("DatiAnagrafici"); //Apre <DatiAnagrafici>
                if (R["IdFiscaleIvaCodiceCliente"].ToString() != "") {
                    writersdi.WriteStartElement("IdFiscaleIVA");// apre <IdFiscaleIVA>
                    writersdi.WriteElementString("IdPaese", getAZ(R["IdFiscaleIvaPaeseCliente"]));
                    writersdi.WriteElementString("IdCodice", format(R["IdFiscaleIvaCodiceCliente"]));
                    writersdi.WriteEndElement();// chiude <IdFiscaleIVA>
                }
                if (R["CFCliente"].ToString() != "") {
                    writersdi.WriteElementString("CodiceFiscale", getAZ09(R["CFCliente"]));
                }
                writersdi.WriteStartElement("Anagrafica");// apre <Anagrafica>
                if (R["DenominazioneCliente"].ToString() != "") {
                    writersdi.WriteElementString("Denominazione", getLatin1(R["DenominazioneCliente"]));
                }
                if (R["nomeCliente"].ToString() != "") {
                    writersdi.WriteElementString("Nome", getLatin1(R["nomeCliente"]));
                }
                if (R["cognomeCliente"].ToString() != "") {
                    writersdi.WriteElementString("Cognome", getLatin1(R["cognomeCliente"]));
                }
                writersdi.WriteEndElement();// chiude <Anagrafica>
                writersdi.WriteEndElement();// chiude <DatiAnagrafici>
                writersdi.WriteStartElement("Sede"); //Apre <Sede>
                writersdi.WriteElementString("Indirizzo", getLatin1(R["indirizzoCliente"]));
                writersdi.WriteElementString("CAP", getdigit09(R["capCliente"]));
                writersdi.WriteElementString("Comune", getLatin1(R["comuneCliente"]));
                writersdi.WriteElementString("Provincia", getAZ(R["provinciaCliente"]));
                writersdi.WriteElementString("Nazione", getAZ(R["nazioneCliente"]));
                writersdi.WriteEndElement();// chiude <Sede>
                writersdi.WriteEndElement();// chiude <CessionarioCommittente>

                writersdi.WriteEndElement();// Chiude -  <FatturaElettronicaHeader>
//            foreach (DataRow rFattura in tElectronicinvoice.Select()) {//Spostato sopra
                writersdi.WriteStartElement("FatturaElettronicaBody"); //Apre <FatturaElettronicaBody>
                writersdi.WriteStartElement("DatiGenerali"); //Apre <DatiGenerali>
                writersdi.WriteStartElement("DatiGeneraliDocumento"); //Apre <DatiGeneraliDocumento>
                writersdi.WriteElementString("TipoDocumento", format(rFattura["TipoDocumento"]));
                writersdi.WriteElementString("Divisa", getAZ(rFattura["divisa"]));
                writersdi.WriteElementString("Data", format(rFattura["data"]));
                writersdi.WriteElementString("Numero", getLatin1(rFattura["numero"]));

                if (tElectronicinvoice.Columns.Contains("idstampkind") && rFattura["idstampkind"].ToString().ToUpper() == "DM19_2014") {
                    writersdi.WriteStartElement("DatiBollo"); //Apre <DatiBollo>
                    //writersdi.WriteElementString("NumeroBollo", format("DM-17-GIU-2014"));
                    writersdi.WriteElementString("BolloVirtuale", format("SI"));
                    decimal impBollo = 2;
                    writersdi.WriteElementString("ImportoBollo", format(impBollo));
                    writersdi.WriteEndElement();// Chiude -  <DatiBollo>
                }

                if (rFattura["tipoScontoMaggiorazione"].ToString() != "") {
                    writersdi.WriteStartElement("ScontoMaggiorazione"); //Apre <ScontoMaggiorazione>
                    writersdi.WriteElementString("Tipo", format(rFattura["tipoScontoMaggiorazione"]));
                    writersdi.WriteElementString("Importo", format(Math.Abs(CfgFn.GetNoNullDecimal(rFattura["sconto"]))));
                    writersdi.WriteEndElement();// Chiude -  <ScontoMaggiorazione>
                }
                writersdi.WriteElementString("ImportoTotaleDocumento", format(rFattura["ImportoTotaleDocumento"]));
                writersdi.WriteElementString("Causale", getLatin1(rFattura["causale"]));
                writersdi.WriteEndElement();// Chiude -  <DatiGeneraliDocumento>
                string filterOrdineAcquisto = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]),
                    QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]), QHC.IsNotNull("IdDocumento"));

				//"IdDocumento" viene valorizzato solo se c'è il collegamento al C.A. ed è stato indicato il cig o il cup nel dettaglio fattura.
				
				
				foreach (DataRow rDetail in tElectronicinvoicedetail.Select(filterOrdineAcquisto)) {
                    writersdi.WriteStartElement("DatiOrdineAcquisto");//Apre - <DatiOrdineAcquisto>
                    writersdi.WriteElementString("RiferimentoNumeroLinea", format(rDetail["RiferimentoNumeroLinea"]));
                    writersdi.WriteElementString("IdDocumento", getLatin1(rDetail["IdDocumento"]));
                    if (rDetail["DataDocumentoCollegato"].ToString() != "") {
                        writersdi.WriteElementString("Data", format(rDetail["DataDocumentoCollegato"]));
                    } 
                    if (rDetail["NumItem"].ToString() != "") {
                        writersdi.WriteElementString("NumItem", getLatin1(rDetail["NumItem"]));
                    }
                    if (rDetail["CodiceCUP"].ToString() != "") {
                        writersdi.WriteElementString("CodiceCUP", getLatin1(rDetail["CodiceCUP"]));
                    }
                    if (rDetail["CodiceCIG"].ToString() != "") {
                        writersdi.WriteElementString("CodiceCIG", getLatin1(rDetail["CodiceCIG"]));
                    }
                    writersdi.WriteEndElement();// Chiude -  <DatiOrdineAcquisto>
                }
                if (rFattura["tipofattura"].ToString() == "V") {// Se è una Nota di Credito
                    writersdi.WriteStartElement("DatiFattureCollegate");
                    writersdi.WriteElementString("IdDocumento", getLatin1(rFattura["IdDocumentoFatturaMadre"]));
                    writersdi.WriteElementString("Data", format(rFattura["DataFatturaMadre"]));
                    writersdi.WriteEndElement();// Chiude -  <DatiFattureCollegate>
                }


                writersdi.WriteEndElement();// Chiude -  <DatiGenerali>

                writersdi.WriteStartElement("DatiBeniServizi"); //Apre <DatiBeniServizi>
                string filterDoc = QHC.AppAnd(QHC.CmpEq("idinvkind", rFattura["idinvkind"]), QHC.CmpEq("yinv", rFattura["yinv"]), QHC.CmpEq("ninv", rFattura["ninv"]));
                foreach (DataRow rDettFattura in tElectronicinvoicedetail.Select(filterDoc)) {
                    writersdi.WriteStartElement("DettaglioLinee"); //Apre <DettaglioLinee>
                    writersdi.WriteElementString("NumeroLinea", format(rDettFattura["NumeroLinea"]));
                    if (rDettFattura["TipoCessionePrestazione"].ToString() != "") {
                        writersdi.WriteElementString("TipoCessionePrestazione", format(rDettFattura["TipoCessionePrestazione"]));
                    }
                    if (rDettFattura["CodiceTipo"] != DBNull.Value) {
                        writersdi.WriteStartElement("CodiceArticolo"); //Apre <CodiceArticolo>
                        writersdi.WriteElementString("CodiceTipo", format(rDettFattura["CodiceTipo"]));
                        writersdi.WriteElementString("CodiceValore", format(rDettFattura["CodiceValore"]));
                        writersdi.WriteEndElement();//chiude  CodiceArticolo
                    }
                    writersdi.WriteElementString("Descrizione", getLatin1(rDettFattura["Descrizione"]).TrimEnd());
                    writersdi.WriteElementString("Quantita", format(rDettFattura["quantita"]));
                    decimal prezzoUnitario = CfgFn.GetNoNullDecimal(rDettFattura["PrezzoUnitario"]);
                    writersdi.WriteElementString("PrezzoUnitario", SecurityElement.Escape(FormatDecimalN(prezzoUnitario,6)));
                    if (rDettFattura["tipoScontoMaggiorazioneDettaglio"].ToString() != "") {
                        writersdi.WriteStartElement("ScontoMaggiorazione"); //Apre <ScontoMaggiorazione>
                        writersdi.WriteElementString("Tipo", format(rDettFattura["tipoScontoMaggiorazioneDettaglio"]));
                        writersdi.WriteElementString("Percentuale", FormatDecimalN(Math.Abs(CfgFn.GetNoNullDecimal( rDettFattura["scontoDettaglio"])),2));
                        writersdi.WriteEndElement();// Chiude -  <ScontoMaggiorazione>
                    }
                    writersdi.WriteElementString("PrezzoTotale", format(rDettFattura["PrezzoTotale"]));
                    writersdi.WriteElementString("AliquotaIVA", format(rDettFattura["AliquotaIVA"]));
                    if (rDettFattura["Natura"].ToString() != "") {
                        writersdi.WriteElementString("Natura", format(rDettFattura["Natura"]));
                    }
                    writersdi.WriteEndElement();// Chiude -  <DettaglioLinee>
                }// chiusura foreach sui dettagli fattura

                foreach (DataRow rRiepilogo in tElectronicinvoiceriepilogo.Select(filterDoc)) {
                    writersdi.WriteStartElement("DatiRiepilogo");//Apre - <DatiRiepilogo>
                    writersdi.WriteElementString("AliquotaIVA", format(rRiepilogo["AliquotaIVA"]));
                    if (rRiepilogo["Natura"].ToString() != "") {
                        writersdi.WriteElementString("Natura", format(rRiepilogo["Natura"]));
                    }
                    writersdi.WriteElementString("ImponibileImporto", format(rRiepilogo["ImponibileImporto"]));
                    writersdi.WriteElementString("Imposta", format(rRiepilogo["Imposta"]));
                    writersdi.WriteElementString("EsigibilitaIVA", format(rRiepilogo["EsigibilitaIVA"]));
                    if (rRiepilogo["RiferimentoNormativo"].ToString() != "") {
                        writersdi.WriteElementString("RiferimentoNormativo", getLatin1(rRiepilogo["RiferimentoNormativo"]));
                    }
                    writersdi.WriteEndElement();// Chiude -  <DatiRiepilogo>
                }



                writersdi.WriteEndElement();// Chiude -  <DatiBeniServizi>

                if (rFattura["tipofattura"].ToString() == "F") {// Solo se Fattura inseriamo il blocco DatiPagamento
                    writersdi.WriteStartElement("DatiPagamento");//Apre - <DatiPagamento>
                    writersdi.WriteElementString("CondizioniPagamento", format(rFattura["CondizioniPagamento"]));

                    writersdi.WriteStartElement("DettaglioPagamento");
                    if (rFattura["ModalitaPagamento"].ToString().ToString() != "") {
                        writersdi.WriteElementString("ModalitaPagamento", format(rFattura["ModalitaPagamento"]));
                    }
                    //Data registrazione, usata anche prima    
                    writersdi.WriteElementString("DataRiferimentoTerminiPagamento", format(rFattura["data"]));
                    if (rFattura["idexpirationkind"].ToString() != "") {
                        DateTime DataScadenzaPagamento = CalcolaDataScadenza(rFattura["idexpirationkind"], rFattura["paymentexpiring"], rFattura["data"], rFattura["datadocumento"]);
                        int GiorniTerminiPagamento = CalcolaGiorniTerminiPagamento(rFattura["data"], DataScadenzaPagamento);
                        writersdi.WriteElementString("GiorniTerminiPagamento", GiorniTerminiPagamento.ToString());
                        writersdi.WriteElementString("DataScadenzaPagamento", FormatData(DataScadenzaPagamento));
                    }
                    writersdi.WriteElementString("ImportoPagamento", format(rFattura["ImportoPagamento"]));
                    if (rFattura["IBAN"].ToString() != "") {
                        writersdi.WriteElementString("IBAN", format(rFattura["IBAN"]));
                    }
                    if (rFattura["CodicePagamento"].ToString() != "") {
                        writersdi.WriteElementString("CodicePagamento", format(rFattura["CodicePagamento"]));
                    }
                    writersdi.WriteEndElement();// Chiude -  <DettaglioPagamento>

                    writersdi.WriteEndElement();// Chiude -  <DatiPagamento>

                }
				if (tElectronicinvoiceAllegati.Rows.Count > 0) {
					foreach (DataRow rAllegato in tElectronicinvoiceAllegati.Select(filterDoc)) {
                    writersdi.WriteStartElement("Allegati");//Apre - <Allegati>                        
                    writersdi.WriteElementString("NomeAttachment", getLatin1(rAllegato["filename"]));
                    writersdi.WriteElementString("Attachment", format(rAllegato["attachment"]));
                    writersdi.WriteEndElement();// Chiude -  <Allegati>
                }
				}
				writersdi.WriteEndElement();// Chiude -  <FatturaElettronicaBody>
          
                writersdi.WriteEndElement();//chiudep:Fattura
                writersdi.Close();

                string xmlString = sw.ToString();
                rSdi_vendita["xml"] = xmlString;

                Meta.SaveFormData();
                Stream s = GenerateStreamFromString(xmlString);
                //ValidaXML_conXSD(s);
            }// foreach in TElectronicinvoice
        }// Fine 


        public Stream GenerateStreamFromString(string s) {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        private void ValidaXML_conXSD(Stream s) {
            bool res = XML_XSD_Validator.Validate(s, AppDomain.CurrentDomain.BaseDirectory + "fatturapa_v1.2.XSD");
            if (!res) {
                QueryCreator.ShowError(this, "Errore nella validazione dell'xml",
                                XML_XSD_Validator.GetError());
            }
        }




    }
}
