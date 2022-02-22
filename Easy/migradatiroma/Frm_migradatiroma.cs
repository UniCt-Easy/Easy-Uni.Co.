
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using SituazioneViewer;//SituazioneViewer
using funzioni_configurazione;
using System.Xml;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace migradatiroma//istitutocassiere_situazione//
{
	/// <summary>
	/// Summary description for frmistitutocassiere_situazione.
	/// </summary>
	public class Frm_migradatiroma : MetaDataForm
	{
		public vistaForm DS;
		private System.Windows.Forms.Button btnMigraDati;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList images;
        private FolderBrowserDialog openDir;
        private TextBox pathDir;
        public MetaData Meta;
        private Button btnMigraReversali;
        private Button btnSelectDir;

        private string id_flusso_mandato = "";
		private string id_flusso_reversale = "";
 

		public Frm_migradatiroma()
		{
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
		protected override void Dispose( bool disposing )
		{
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
            this.components = new System.ComponentModel.Container();
            this.btnMigraDati = new System.Windows.Forms.Button();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.DS = new migradatiroma.vistaForm();
            this.openDir = new System.Windows.Forms.FolderBrowserDialog();
            this.pathDir = new System.Windows.Forms.TextBox();
            this.btnMigraReversali = new System.Windows.Forms.Button();
            this.btnSelectDir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnMigraDati
            // 
            this.btnMigraDati.Location = new System.Drawing.Point(21, 97);
            this.btnMigraDati.Name = "btnMigraDati";
            this.btnMigraDati.Size = new System.Drawing.Size(137, 36);
            this.btnMigraDati.TabIndex = 0;
            this.btnMigraDati.Text = "Migra Mandati";
            this.btnMigraDati.Click += new System.EventHandler(this.btnMigraDati_Click);
            // 
            // images
            // 
            this.images.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.images.ImageSize = new System.Drawing.Size(16, 16);
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // openDir
            // 
            this.openDir.ShowNewFolderButton = false;
            // 
            // pathDir
            // 
            this.pathDir.Location = new System.Drawing.Point(186, 34);
            this.pathDir.Name = "pathDir";
            this.pathDir.Size = new System.Drawing.Size(591, 22);
            this.pathDir.TabIndex = 1;
            // 
            // btnMigraReversali
            // 
            this.btnMigraReversali.Location = new System.Drawing.Point(186, 98);
            this.btnMigraReversali.Name = "btnMigraReversali";
            this.btnMigraReversali.Size = new System.Drawing.Size(137, 35);
            this.btnMigraReversali.TabIndex = 2;
            this.btnMigraReversali.Text = "MIgra Reversali";
            this.btnMigraReversali.UseVisualStyleBackColor = true;
            this.btnMigraReversali.Click += new System.EventHandler(this.btnMigraReversali_Click);
            // 
            // btnSelectDir
            // 
            this.btnSelectDir.Location = new System.Drawing.Point(12, 12);
            this.btnSelectDir.Name = "btnSelectDir";
            this.btnSelectDir.Size = new System.Drawing.Size(146, 44);
            this.btnSelectDir.TabIndex = 3;
            this.btnSelectDir.Text = "Seleziona cartella";
            this.btnSelectDir.UseVisualStyleBackColor = true;
            this.btnSelectDir.Click += new System.EventHandler(this.btnSelectDir_Click);
            // 
            // Frm_migradatiroma
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(789, 157);
            this.Controls.Add(this.btnSelectDir);
            this.Controls.Add(this.btnMigraReversali);
            this.Controls.Add(this.pathDir);
            this.Controls.Add(this.btnMigraDati);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_migradatiroma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() 
		{
				Meta = MetaData.GetMetaData(this);
			
		}

		public void MetaData_AfterFill(){
		}

		public void MetaData_AfterClear(){
		}

		private void btnSelectDir_Click(object sender, EventArgs e) {
			if (openDir.ShowDialog(this) == DialogResult.OK) {
				pathDir.Text = openDir.SelectedPath;
			}

		}

		public void ElaboraXml() {
			//string path = "C:/Users/frach/Dropbox/integrazioni/task da testare/15439 Recupero ordinativi da file OPI - Roma Tor Vergata/opi";

			//foreach (var filename in Directory.GetFiles(path)) { 
			//	XmlDocument xmldocument = new XmlDocument();
			//	xmldocument.Load(filename);
			//	ElaboraFile(xmldocument);
			//}
			if (pathDir.Text.Contains("Mandati") || pathDir.Text.Contains("Mandato")
				|| pathDir.Text.Contains("mandati") || pathDir.Text.Contains("mandato")) {
				List<string> allFiles = DirSearch(pathDir.Text);
				DS.Clear();
				foreach (string filename in allFiles) {
					XmlDocument xmldocument = new XmlDocument();
					xmldocument.Load(filename);
					ElaboraFile(xmldocument);
				}
			} else if (pathDir.Text.Contains("Reversali") || pathDir.Text.Contains("Reversale")
						|| pathDir.Text.Contains("reversali") || pathDir.Text.Contains("reversale")) {
						List<string> allFiles = DirSearch(pathDir.Text);
						DS.Clear();
						foreach (string filename in allFiles) {
							XmlDocument xmldocument = new XmlDocument();
							xmldocument.Load(filename);
							ElaboraFileReversali(xmldocument);
						}
				   }

			SaveData();
			MetaFactory.factory.getSingleton<IMessageShower>().Show("Dati salvati");
		}
		
		private List<String> DirSearch(string sDir) {
			List<String> files = new List<string>();

			try {
				foreach (string s in Directory.GetFiles(sDir, "*.xml")) {
					files.Add(s);
                }
            } catch(System.Exception e) {
				show(e.Message);
            }

			return files;
        }

		public void ElaboraFile(XmlDocument Xdoc) {
			XmlNodeList ElencoFileXML = Xdoc.SelectNodes("/flusso_ordinativi");
			foreach (XmlNode fileXml in ElencoFileXML) {
				foreach (XmlNode Xtestata_flusso in fileXml.SelectNodes("testata_flusso")) {
					string codice_abi_bt = Xtestata_flusso["codice_ABI_BT"].InnerText;
					string identificativo_flusso = Xtestata_flusso["identificativo_flusso"].InnerText;
					this.id_flusso_mandato = identificativo_flusso;
					DateTime data_ora_creazione_flusso = XmlHelper.AsDate(Xtestata_flusso, "data_ora_creazione_flusso"); 
					string codice_ente = Xtestata_flusso["codice_ente"].InnerText;
					string descrizione_ente = Xtestata_flusso["descrizione_ente"].InnerText;
					string codice_istat_ente = Xtestata_flusso["codice_istat_ente"].InnerText;
					string codice_fiscale_ente = Xtestata_flusso["codice_fiscale_ente"].InnerText;
					string codice_tramite_ente = Xtestata_flusso["codice_tramite_ente"].InnerText;
					string codice_tramite_BT = Xtestata_flusso["codice_tramite_BT"].InnerText;
					string codice_ente_BT = Xtestata_flusso["codice_ente_BT"].InnerText;
					string riferimento_ente = getXmlText(Xtestata_flusso, "riferimento_ente");

					DataRow NewMandatoTestataFlusso = DS.Tables["MandatoTestataFlusso"].NewRow();
					NewMandatoTestataFlusso["codice_ABI_BT"] = codice_abi_bt;
					NewMandatoTestataFlusso["identificativo_flusso"] = identificativo_flusso;
					NewMandatoTestataFlusso["data_ora_creazione_flusso"] = data_ora_creazione_flusso;
					NewMandatoTestataFlusso["codice_ente"] = codice_ente;
					NewMandatoTestataFlusso["descrizione_ente"] = descrizione_ente;
					NewMandatoTestataFlusso["codice_istat_ente"] = codice_istat_ente;
					NewMandatoTestataFlusso["codice_fiscale_ente"] = codice_fiscale_ente;
					NewMandatoTestataFlusso["codice_tramite_ente"] = codice_tramite_ente;
					NewMandatoTestataFlusso["codice_tramite_BT"] = codice_tramite_BT;
					NewMandatoTestataFlusso["codice_ente_BT"] = codice_ente_BT;
					NewMandatoTestataFlusso["riferimento_ente"] = riferimento_ente;
					DS.Tables["MandatoTestataFlusso"].Rows.Add(NewMandatoTestataFlusso);
				}

				foreach (XmlNode Xmandato in fileXml.SelectNodes("mandato")) {
					string tipo_operazione = Xmandato["tipo_operazione"].InnerText;
					int numero_mandato = XmlHelper.AsInt(Xmandato, "numero_mandato");
					DateTime data_mandato = XmlHelper.AsDate(Xmandato, "data_mandato");
					decimal importo_mandato = XmlHelper.AsDecimal(Xmandato, "importo_mandato");
					string conto_evidenza = getXmlText(Xmandato, "conto_evidenza");
					string estremi_provvedimento_autorizzativo = getXmlText(Xmandato, "estremi_provvedimento_autorizzativo");
					string responsabile_provvedimento = getXmlText(Xmandato, "responsabile_provvedimento");
					string ufficio_responsabile = getXmlText(Xmandato, "ufficio_responsabile");
					string codice_struttura = "";

					
					foreach (XmlNode Xinformazioni_beneficiario in Xmandato.SelectNodes("informazioni_beneficiario")) {
						int progressivo_beneficiario = XmlHelper.AsInt(Xinformazioni_beneficiario, "progressivo_beneficiario");
						decimal importo_beneficiario = XmlHelper.AsDecimal(Xinformazioni_beneficiario, "importo_beneficiario");
						string tipo_pagamento = Xinformazioni_beneficiario["tipo_pagamento"].InnerText;
						Object data_esecuzione_pagamento = XmlHelper.AsOptionalDate(Xinformazioni_beneficiario, "data_esecuzione_pagamento");
						Object data_scadenza_pagamento = XmlHelper.AsOptionalDate(Xinformazioni_beneficiario, "data_scadenza_pagamento");
						string destinazione = Xinformazioni_beneficiario["destinazione"].InnerText;
						string numero_conto_banca_italia_ente_ricevente = getXmlText(Xinformazioni_beneficiario, "numero_conto_banca_italia_ente_ricevente");
						string tipo_contabilita_ente_ricevente = getXmlText(Xinformazioni_beneficiario, "tipo_contabilita_ente_ricevente");
						string causale = Xinformazioni_beneficiario["causale"].InnerText;
												
						foreach (XmlNode Xclassificazione in Xinformazioni_beneficiario.SelectNodes("classificazione")) {
							string codice_cgu = Xclassificazione["codice_cgu"].InnerText;
							string codice_cup = getXmlText(Xclassificazione, "codice_cup");
							decimal importo = XmlHelper.AsDecimal(Xclassificazione, "importo");

							foreach (XmlNode Xclassificazione_dati_siope_uscite in Xclassificazione.SelectNodes("classificazione_dati_siope_uscite")) {
								string tipo_debito_siope_nc = getXmlText(Xclassificazione_dati_siope_uscite, "tipo_debito_siope_nc");
								string tipo_debito_siope_c = getXmlText(Xclassificazione_dati_siope_uscite, "tipo_debito_siope_c");
								string codice_cig_siope = getXmlText(Xclassificazione_dati_siope_uscite, "codice_cig_siope");
								string motivo_esclusione_cig_siope = getXmlText(Xclassificazione_dati_siope_uscite, "motivo_esclusione_cig_siope");

								string tipo_debito_siope = tipo_debito_siope_nc != null ? tipo_debito_siope_nc : tipo_debito_siope_c;

								foreach (XmlNode Xfattura_siope in Xclassificazione_dati_siope_uscite.SelectNodes("fattura_siope")) {
									string codice_ipa_ente_siope = Xfattura_siope["codice_ipa_ente_siope"].InnerText;
									string tipo_documento_siope_e = Xfattura_siope["tipo_documento_siope_e"].InnerText;
									string identificativo_lotto_sdi_siope = Xfattura_siope["identificativo_lotto_sdi_siope"].InnerText;
									
									foreach (XmlNode Xdati_fattura_siope in Xfattura_siope.SelectNodes("dati_fattura_siope")) {
										string numero_fattura_siope = Xdati_fattura_siope["numero_fattura_siope"].InnerText;
										decimal importo_siope = XmlHelper.AsDecimal(Xdati_fattura_siope, "importo_siope");
										DateTime data_scadenza_pagam_siope = XmlHelper.AsDate(Xdati_fattura_siope, "data_scadenza_pagam_siope");
										string motivo_scadenza_siope = getXmlText(Xdati_fattura_siope, "motivo_scadenza_siope");
										string natura_spesa_siope = getXmlText(Xdati_fattura_siope, "natura_spesa_siope");
										string utilizzo_nota_di_credito = getXmlText(Xdati_fattura_siope, "utilizzo_nota_di_credito");

										DataRow NewDatiFatturaSiope = DS.Tables["MandatoDatiFatturaSiope"].NewRow();
										NewDatiFatturaSiope["identificativo_flusso"] = this.id_flusso_mandato;
										NewDatiFatturaSiope["tipo_operazione"] = tipo_operazione;
										NewDatiFatturaSiope["numero_mandato"] = numero_mandato;
										NewDatiFatturaSiope["progressivo_beneficiario"] = progressivo_beneficiario;
										NewDatiFatturaSiope["codice_cgu"] = codice_cgu;
										NewDatiFatturaSiope["tipo_debito_siope"] = tipo_debito_siope;
										NewDatiFatturaSiope["codice_ipa_ente_siope"] = codice_ipa_ente_siope;
										NewDatiFatturaSiope["tipo_documento_siope_e"] = tipo_documento_siope_e;
										NewDatiFatturaSiope["identificativo_lotto_sdi_siope"] = identificativo_lotto_sdi_siope;
										NewDatiFatturaSiope["numero_fattura_siope"] = numero_fattura_siope;
										NewDatiFatturaSiope["importo_siope"] = importo_siope;
										NewDatiFatturaSiope["data_scadenza_pagam_siope"] = data_scadenza_pagam_siope;
										NewDatiFatturaSiope["motivo_scadenza_siope"] = motivo_scadenza_siope;
										NewDatiFatturaSiope["natura_spesa_siope"] = natura_spesa_siope;
										NewDatiFatturaSiope["utilizzo_nota_di_credito"] = utilizzo_nota_di_credito;
										DS.Tables["MandatoDatiFatturaSiope"].Rows.Add(NewDatiFatturaSiope);
									}

									DataRow NewFatturaSiope = DS.Tables["MandatoFatturaSiope"].NewRow();
									NewFatturaSiope["identificativo_flusso"] = this.id_flusso_mandato;
									NewFatturaSiope["tipo_operazione"] = tipo_operazione;
									NewFatturaSiope["numero_mandato"] = numero_mandato;
									NewFatturaSiope["progressivo_beneficiario"] = progressivo_beneficiario;
									NewFatturaSiope["codice_cgu"] = codice_cgu;
									NewFatturaSiope["tipo_debito_siope"] = tipo_debito_siope;
									NewFatturaSiope["codice_ipa_ente_siope"] = codice_ipa_ente_siope;
									NewFatturaSiope["tipo_documento_siope_e"] = tipo_documento_siope_e;
									NewFatturaSiope["identificativo_lotto_sdi_siope"] = identificativo_lotto_sdi_siope;
									DS.Tables["MandatoFatturaSiope"].Rows.Add(NewFatturaSiope);
								}

								foreach (XmlNode Xdati_arconet_siope in Xclassificazione_dati_siope_uscite.SelectNodes("dati_arconet_siope")) {
									string codice_missione_siope = Xdati_arconet_siope["codice_missione_siope"].InnerText;
									string codice_programma_siope = Xdati_arconet_siope["codice_programma_siope"].InnerText;
									string codice_economico_siope = Xdati_arconet_siope["codice_economico_siope"].InnerText;
									decimal importo_codice_economico_siope = XmlHelper.AsDecimal(Xdati_arconet_siope, "importo_codice_economico_siope");
									string codice_UE_siope = getXmlText(Xdati_arconet_siope, "codice_UE_siope");
									string codice_entrata_siope = getXmlText(Xdati_arconet_siope, "codice_entrata_siope");

									foreach (XmlNode Xcofog_siope in Xdati_arconet_siope.SelectNodes("cofog_siope")) {
										string codice_cofog_siope = Xcofog_siope["codice_cofog_siope"].InnerText;
										decimal importo_cofog_siope = XmlHelper.AsDecimal(Xcofog_siope, "importo_cofog_siope");

										DataRow NewCofogSiope = DS.Tables["MandatoCofogSiope"].NewRow();
										NewCofogSiope["identificativo_flusso"] = this.id_flusso_mandato;
										NewCofogSiope["tipo_operazione"] = tipo_operazione;
										NewCofogSiope["numero_mandato"] = numero_mandato;
										NewCofogSiope["progressivo_beneficiario"] = progressivo_beneficiario;
										NewCofogSiope["codice_cgu"] = codice_cgu;
										NewCofogSiope["tipo_debito_siope"] = tipo_debito_siope;
										NewCofogSiope["codice_missione_siope"] = codice_missione_siope;
										NewCofogSiope["codice_programma_siope"] = codice_programma_siope;
										NewCofogSiope["codice_economico_siope"] = codice_economico_siope;
										NewCofogSiope["codice_cofog_siope"] = codice_cofog_siope;
										NewCofogSiope["importo_cofog_siope"] = importo_cofog_siope;
										DS.Tables["MandatoCofogSiope"].Rows.Add(NewCofogSiope);
									}

									DataRow NewDatiArconetSiope = DS.Tables["MandatoDatiArconetSiope"].NewRow();
									NewDatiArconetSiope["identificativo_flusso"] = this.id_flusso_mandato;
									NewDatiArconetSiope["tipo_operazione"] = tipo_operazione;
									NewDatiArconetSiope["numero_mandato"] = numero_mandato;
									NewDatiArconetSiope["progressivo_beneficiario"] = progressivo_beneficiario;
									NewDatiArconetSiope["codice_cgu"] = codice_cgu;
									NewDatiArconetSiope["tipo_debito_siope"] = tipo_debito_siope;
									NewDatiArconetSiope["codice_missione_siope"] = codice_missione_siope;
									NewDatiArconetSiope["codice_programma_siope"] = codice_programma_siope;
									NewDatiArconetSiope["codice_economico_siope"] = codice_economico_siope;
									NewDatiArconetSiope["importo_codice_economico_siope"] = importo_codice_economico_siope;
									NewDatiArconetSiope["codice_UE_siope"] = codice_UE_siope;
									NewDatiArconetSiope["codice_entrata_siope"] = codice_entrata_siope;									
									DS.Tables["MandatoDatiArconetSiope"].Rows.Add(NewDatiArconetSiope);
								}

								DataRow NewClassificazioneDatiSiopeUscite = DS.Tables["MandatoClassificazioneDatiSiopeUscite"].NewRow();
								NewClassificazioneDatiSiopeUscite["identificativo_flusso"] = this.id_flusso_mandato;
								NewClassificazioneDatiSiopeUscite["tipo_operazione"] = tipo_operazione;
								NewClassificazioneDatiSiopeUscite["numero_mandato"] = numero_mandato;
								NewClassificazioneDatiSiopeUscite["progressivo_beneficiario"] = progressivo_beneficiario;
								NewClassificazioneDatiSiopeUscite["codice_cgu"] = codice_cgu;
								NewClassificazioneDatiSiopeUscite["tipo_debito_siope"] = tipo_debito_siope;
								NewClassificazioneDatiSiopeUscite["codice_cig_siope"] = codice_cig_siope;
								NewClassificazioneDatiSiopeUscite["motivo_esclusione_cig_siope"] = motivo_esclusione_cig_siope;
								DS.Tables["MandatoClassificazioneDatiSiopeUscite"].Rows.Add(NewClassificazioneDatiSiopeUscite);
							}

							DataRow NewClassificazione = DS.Tables["MandatoClassificazione"].NewRow();
							NewClassificazione["identificativo_flusso"] = this.id_flusso_mandato;
							NewClassificazione["tipo_operazione"] = tipo_operazione;
							NewClassificazione["numero_mandato"] = numero_mandato;
							NewClassificazione["progressivo_beneficiario"] = progressivo_beneficiario;
							NewClassificazione["codice_cgu"] = codice_cgu;
							NewClassificazione["codice_cup"] = codice_cup;
							NewClassificazione["importo"] = importo;							
							DS.Tables["MandatoClassificazione"].Rows.Add(NewClassificazione);
						}

						foreach (XmlNode Xbollo in Xinformazioni_beneficiario.SelectNodes("bollo")) {
							string assoggettamento_bollo = Xbollo["assoggettamento_bollo"].InnerText;
							string causale_esenzione_bollo = Xbollo["causale_esenzione_bollo"].InnerText;

							DataRow NewBollo = DS.Tables["MandatoBollo"].NewRow();
							NewBollo["identificativo_flusso"] = this.id_flusso_mandato;
							NewBollo["tipo_operazione"] = tipo_operazione;
							NewBollo["numero_mandato"] = numero_mandato;
							NewBollo["progressivo_beneficiario"] = progressivo_beneficiario;
							NewBollo["assoggettamento_bollo"] = assoggettamento_bollo;
							NewBollo["causale_esenzione_bollo"] = causale_esenzione_bollo;
							DS.Tables["MandatoBollo"].Rows.Add(NewBollo);
						}

						foreach (XmlNode Xspese in Xinformazioni_beneficiario.SelectNodes("spese")) {
							string soggetto_destinatario_delle_spese = Xspese["soggetto_destinatario_delle_spese"].InnerText;
							string natura_pagamento = Xspese["natura_pagamento"].InnerText;
							string causale_esenzione_spese = Xspese["causale_esenzione_spese"].InnerText;

							DataRow NewSpese = DS.Tables["MandatoSpese"].NewRow();
							NewSpese["identificativo_flusso"] = this.id_flusso_mandato;
							NewSpese["tipo_operazione"] = tipo_operazione;
							NewSpese["numero_mandato"] = numero_mandato;
							NewSpese["progressivo_beneficiario"] = progressivo_beneficiario;
							NewSpese["soggetto_destinatario_delle_spese"] = soggetto_destinatario_delle_spese;
							NewSpese["natura_pagamento"] = natura_pagamento;
							NewSpese["causale_esenzione_spese"] = causale_esenzione_spese;
							DS.Tables["MandatoSpese"].Rows.Add(NewSpese);
						}

						foreach (XmlNode Xbeneficiario in Xinformazioni_beneficiario.SelectNodes("beneficiario")) {
							string anagrafica_beneficiario = Xbeneficiario["anagrafica_beneficiario"].InnerText;
							string indirizzo_beneficiario = getXmlText(Xbeneficiario, "indirizzo_beneficiario");
							string cap_beneficiario = getXmlText(Xbeneficiario, "cap_beneficiario");
							string localita_beneficiario = getXmlText(Xbeneficiario, "localita_beneficiario");
							string provincia_beneficiario = getXmlText(Xbeneficiario, "provincia_beneficiario");
							string stato_beneficiario = getXmlText(Xbeneficiario, "stato_beneficiario");							string partita_iva_beneficiario = getXmlText(Xbeneficiario, "partita_iva_beneficiario");
							string codice_fiscale_beneficiario = getXmlText(Xbeneficiario, "codice_fiscale_beneficiario");

							DataRow NewBeneficiario = DS.Tables["MandatoBeneficiario"].NewRow();
							NewBeneficiario["identificativo_flusso"] = this.id_flusso_mandato;
							NewBeneficiario["tipo_operazione"] = tipo_operazione;
							NewBeneficiario["numero_mandato"] = numero_mandato;
							NewBeneficiario["progressivo_beneficiario"] = progressivo_beneficiario;
							NewBeneficiario["anagrafica_beneficiario"] = anagrafica_beneficiario;
							NewBeneficiario["indirizzo_beneficiario"] = indirizzo_beneficiario;
							NewBeneficiario["cap_beneficiario"] = cap_beneficiario;
							NewBeneficiario["localita_beneficiario"] = localita_beneficiario;
							NewBeneficiario["provincia_beneficiario"] = provincia_beneficiario;
							NewBeneficiario["stato_beneficiario"] = stato_beneficiario;
							NewBeneficiario["partita_iva_beneficiario"] = partita_iva_beneficiario;
							NewBeneficiario["codice_fiscale_beneficiario"] = codice_fiscale_beneficiario;
							DS.Tables["MandatoBeneficiario"].Rows.Add(NewBeneficiario);
						}

						foreach (XmlNode Xsospeso in Xinformazioni_beneficiario.SelectNodes("sospeso")) {
							int numero_provvisorio = XmlHelper.AsInt(Xsospeso, "numero_provvisorio");
							decimal importo_provvisorio = XmlHelper.AsDecimal(Xsospeso, "importo_provvisorio");

							DataRow NewSospeso = DS.Tables["MandatoSospeso"].NewRow();
							NewSospeso["identificativo_flusso"] = this.id_flusso_mandato;
							NewSospeso["tipo_operazione"] = tipo_operazione;
							NewSospeso["numero_mandato"] = numero_mandato;
							NewSospeso["progressivo_beneficiario"] = progressivo_beneficiario;
							NewSospeso["numero_provvisorio"] = numero_provvisorio;
							NewSospeso["importo_provvisorio"] = importo_provvisorio;							
							DS.Tables["MandatoSospeso"].Rows.Add(NewSospeso);
						}

						foreach (XmlNode Xdelegato in Xinformazioni_beneficiario.SelectNodes("delegato")) {
							string anagrafica_delegato = Xdelegato["anagrafica_delegato"].InnerText;
							string indirizzo_delegato = getXmlText(Xdelegato, "indirizzo_delegato");
							string cap_delegato = getXmlText(Xdelegato, "cap_delegato");
							string localita_delegato = getXmlText(Xdelegato, "localita_delegato");
							string provincia_delegato = getXmlText(Xdelegato, "provincia_delegato"); 
							string stato_delegato = getXmlText(Xdelegato, "stato_delegato");
							string codice_fiscale_delegato = getXmlText(Xdelegato, "codice_fiscale_delegato");

							DataRow NewDelegato = DS.Tables["MandatoDelegato"].NewRow();
							NewDelegato["identificativo_flusso"] = this.id_flusso_mandato;
							NewDelegato["tipo_operazione"] = tipo_operazione;
							NewDelegato["numero_mandato"] = numero_mandato;
							NewDelegato["progressivo_beneficiario"] = progressivo_beneficiario;
							NewDelegato["anagrafica_delegato"] = anagrafica_delegato;
							NewDelegato["indirizzo_delegato"] = indirizzo_delegato;
							NewDelegato["cap_delegato"] = cap_delegato;
							NewDelegato["localita_delegato"] = localita_delegato;
							NewDelegato["provincia_delegato"] = provincia_delegato;
							NewDelegato["stato_delegato"] = stato_delegato;
							NewDelegato["codice_fiscale_delegato"] = codice_fiscale_delegato;
							DS.Tables["MandatoDelegato"].Rows.Add(NewDelegato);
						}

						foreach (XmlNode Xsepa_credit_transfer in Xinformazioni_beneficiario.SelectNodes("sepa_credit_transfer")) {
							string iban = Xsepa_credit_transfer["iban"].InnerText;
							string bic = getXmlText(Xsepa_credit_transfer, "bic");
							string identificativo_end_to_end = getXmlText(Xsepa_credit_transfer, "identificativo_end_to_end");

							DataRow NewSepaCreditTransfer = DS.Tables["MandatoSepaCreditTransfer"].NewRow();
							NewSepaCreditTransfer["identificativo_flusso"] = this.id_flusso_mandato;
							NewSepaCreditTransfer["tipo_operazione"] = tipo_operazione;
							NewSepaCreditTransfer["numero_mandato"] = numero_mandato;
							NewSepaCreditTransfer["progressivo_beneficiario"] = progressivo_beneficiario;
							NewSepaCreditTransfer["iban"] = iban;
							NewSepaCreditTransfer["bic"] = bic;
							NewSepaCreditTransfer["identificativo_end_to_end"] = identificativo_end_to_end;							
							DS.Tables["MandatoSepaCreditTransfer"].Rows.Add(NewSepaCreditTransfer);
						}

						foreach (XmlNode Xritenute in Xinformazioni_beneficiario.SelectNodes("ritenute")) {
							decimal importo_ritenute = XmlHelper.AsDecimal(Xritenute, "importo_ritenute");
							int numero_reversale = XmlHelper.AsInt(Xritenute, "numero_reversale");
							int progressivo_versante = XmlHelper.AsInt(Xritenute, "progressivo_versante");

							DataRow NewRitenute = DS.Tables["MandatoRitenute"].NewRow();
							NewRitenute["identificativo_flusso"] = this.id_flusso_mandato;
							NewRitenute["tipo_operazione"] = tipo_operazione;
							NewRitenute["numero_mandato"] = numero_mandato;
							NewRitenute["progressivo_beneficiario"] = progressivo_beneficiario;
							NewRitenute["importo_ritenute"] = importo_ritenute;
							NewRitenute["numero_reversale"] = numero_reversale;
							NewRitenute["progressivo_versante"] = progressivo_versante;
							DS.Tables["MandatoRitenute"].Rows.Add(NewRitenute);
						}

						foreach (XmlNode Xinformazioni_aggiuntive in Xinformazioni_beneficiario.SelectNodes("informazioni_aggiuntive")) {
							string lingua = getXmlText(Xinformazioni_aggiuntive, "lingua");
							string riferimento_documento_esterno = getXmlText(Xinformazioni_aggiuntive, "riferimento_documento_esterno");

							foreach (XmlNode Xavviso_pagoPA in Xinformazioni_aggiuntive.SelectNodes("avviso_pagoPA")) {
								string codice_identificativo_ente = Xavviso_pagoPA["codice_identificativo_ente"].InnerText;
								string numero_avviso = getXmlText(Xavviso_pagoPA, "numero_avviso");

								DataRow NewAvvisoPagoPA = DS.Tables["MandatoAvvisoPagoPA"].NewRow();
								NewAvvisoPagoPA["identificativo_flusso"] = this.id_flusso_mandato;
								NewAvvisoPagoPA["tipo_operazione"] = tipo_operazione;
								NewAvvisoPagoPA["numero_mandato"] = numero_mandato;
								NewAvvisoPagoPA["progressivo_beneficiario"] = progressivo_beneficiario;
								NewAvvisoPagoPA["riferimento_documento_esterno"] = riferimento_documento_esterno;
								NewAvvisoPagoPA["codice_identificativo_ente"] = codice_identificativo_ente;
								NewAvvisoPagoPA["numero_avviso"] = numero_avviso;
								DS.Tables["MandatoAvvisoPagoPA"].Rows.Add(NewAvvisoPagoPA);
							}

							DataRow NewInformazioniAggiuntive = DS.Tables["MandatoInformazioniAggiuntive"].NewRow();
							NewInformazioniAggiuntive["identificativo_flusso"] = this.id_flusso_mandato;
							NewInformazioniAggiuntive["tipo_operazione"] = tipo_operazione;
							NewInformazioniAggiuntive["numero_mandato"] = numero_mandato;
							NewInformazioniAggiuntive["progressivo_beneficiario"] = progressivo_beneficiario;
							NewInformazioniAggiuntive["lingua"] = lingua;
							NewInformazioniAggiuntive["riferimento_documento_esterno"] = riferimento_documento_esterno;
							DS.Tables["MandatoInformazioniAggiuntive"].Rows.Add(NewInformazioniAggiuntive);
						}

						DataRow NewMandatoInformazioniBeneficiario = DS.Tables["MandatoInformazioniBeneficiario"].NewRow();
						NewMandatoInformazioniBeneficiario["identificativo_flusso"] = this.id_flusso_mandato;
						NewMandatoInformazioniBeneficiario["tipo_operazione"] = tipo_operazione;
						NewMandatoInformazioniBeneficiario["numero_mandato"] = numero_mandato;
						NewMandatoInformazioniBeneficiario["progressivo_beneficiario"] = progressivo_beneficiario;
						NewMandatoInformazioniBeneficiario["importo_beneficiario"] = importo_beneficiario;
						NewMandatoInformazioniBeneficiario["tipo_pagamento"] = tipo_pagamento;
						NewMandatoInformazioniBeneficiario["data_esecuzione_pagamento"] = data_esecuzione_pagamento;
						NewMandatoInformazioniBeneficiario["data_scadenza_pagamento"] = data_scadenza_pagamento;
						NewMandatoInformazioniBeneficiario["destinazione"] = destinazione;
						NewMandatoInformazioniBeneficiario["numero_conto_banca_italia_ente_ricevente"] = numero_conto_banca_italia_ente_ricevente;
						NewMandatoInformazioniBeneficiario["tipo_contabilita_ente_ricevente"] = tipo_contabilita_ente_ricevente;
						NewMandatoInformazioniBeneficiario["causale"] = causale;
						DS.Tables["MandatoInformazioniBeneficiario"].Rows.Add(NewMandatoInformazioniBeneficiario);
					}
					
					//se esiste la struttura, c'è un solo elemento
					foreach (XmlNode Xdati_a_disposizione_ente_mandato in Xmandato.SelectNodes("dati_a_disposizione_ente_mandato")) {
						codice_struttura = getXmlText(Xdati_a_disposizione_ente_mandato, "codice_struttura");
					}

					DataRow NewMandato = DS.Tables["Mandato"].NewRow();
					NewMandato["identificativo_flusso"] = this.id_flusso_mandato;
					NewMandato["tipo_operazione"] = tipo_operazione;
					NewMandato["numero_mandato"] = numero_mandato;
					NewMandato["data_mandato"] = data_mandato;
					NewMandato["importo_mandato"] = importo_mandato;					
					NewMandato["conto_evidenza"] = conto_evidenza;
					NewMandato["estremi_provvedimento_autorizzativo"] = estremi_provvedimento_autorizzativo;
					NewMandato["responsabile_provvedimento"] = responsabile_provvedimento;
					NewMandato["ufficio_responsabile"] = ufficio_responsabile;
					NewMandato["codice_struttura"] = codice_struttura;
					DS.Tables["Mandato"].Rows.Add(NewMandato);
				}
			}

		}

		public void ElaboraFileReversali(XmlDocument Xdoc) {
			XmlNodeList ElencoFileXML = Xdoc.SelectNodes("/flusso_ordinativi");
			foreach (XmlNode fileXml in ElencoFileXML) {
				foreach (XmlNode Xtestata_flusso in fileXml.SelectNodes("testata_flusso")) {
					string codice_abi_bt = Xtestata_flusso["codice_ABI_BT"].InnerText;
					string identificativo_flusso = Xtestata_flusso["identificativo_flusso"].InnerText;
					this.id_flusso_reversale = identificativo_flusso;
					DateTime data_ora_creazione_flusso = XmlHelper.AsDate(Xtestata_flusso, "data_ora_creazione_flusso");
					string codice_ente = Xtestata_flusso["codice_ente"].InnerText;
					string descrizione_ente = Xtestata_flusso["descrizione_ente"].InnerText;
					string codice_istat_ente = Xtestata_flusso["codice_istat_ente"].InnerText;
					string codice_fiscale_ente = Xtestata_flusso["codice_fiscale_ente"].InnerText;
					string codice_tramite_ente = Xtestata_flusso["codice_tramite_ente"].InnerText;
					string codice_tramite_BT = Xtestata_flusso["codice_tramite_BT"].InnerText;
					string codice_ente_BT = Xtestata_flusso["codice_ente_BT"].InnerText;
					string riferimento_ente = getXmlText(Xtestata_flusso, "riferimento_ente");

					DataRow NewReversaleTestataFlusso = DS.Tables["ReversaleTestataFlusso"].NewRow();
					NewReversaleTestataFlusso["codice_ABI_BT"] = codice_abi_bt;
					NewReversaleTestataFlusso["identificativo_flusso"] = identificativo_flusso;
					NewReversaleTestataFlusso["data_ora_creazione_flusso"] = data_ora_creazione_flusso;
					NewReversaleTestataFlusso["codice_ente"] = codice_ente;
					NewReversaleTestataFlusso["descrizione_ente"] = descrizione_ente;
					NewReversaleTestataFlusso["codice_istat_ente"] = codice_istat_ente;
					NewReversaleTestataFlusso["codice_fiscale_ente"] = codice_fiscale_ente;
					NewReversaleTestataFlusso["codice_tramite_ente"] = codice_tramite_ente;
					NewReversaleTestataFlusso["codice_tramite_BT"] = codice_tramite_BT;
					NewReversaleTestataFlusso["codice_ente_BT"] = codice_ente_BT;
					NewReversaleTestataFlusso["riferimento_ente"] = riferimento_ente;
					DS.Tables["ReversaleTestataFlusso"].Rows.Add(NewReversaleTestataFlusso);
				}

				foreach (XmlNode Xreversale in fileXml.SelectNodes("reversale")) {
					string tipo_operazione = Xreversale["tipo_operazione"].InnerText;
					int numero_reversale = XmlHelper.AsInt(Xreversale, "numero_reversale");
					DateTime data_reversale = XmlHelper.AsDate(Xreversale, "data_reversale");
					decimal importo_reversale = XmlHelper.AsDecimal(Xreversale, "importo_reversale");
					string conto_evidenza = getXmlText(Xreversale, "conto_evidenza");
					string codice_struttura = "";

					//se esiste la struttura, c'è un solo elemento
					foreach (XmlNode Xdati_a_disposizione_ente_reversale in Xreversale.SelectNodes("dati_a_disposizione_ente_reversale")) {
						codice_struttura = getXmlText(Xdati_a_disposizione_ente_reversale, "codice_struttura");
					}

					foreach (XmlNode Xinformazioni_versante in Xreversale.SelectNodes("informazioni_versante")) {
						int progressivo_versante = XmlHelper.AsInt(Xinformazioni_versante, "progressivo_versante");
						decimal importo_versante = XmlHelper.AsDecimal(Xinformazioni_versante, "importo_versante");
						string tipo_riscossione = getXmlText(Xinformazioni_versante, "tipo_riscossione");
						string tipo_entrata = getXmlText(Xinformazioni_versante, "tipo_entrata");
						string destinazione = getXmlText(Xinformazioni_versante, "destinazione");
						string causale = Xinformazioni_versante["causale"].InnerText;

						foreach (XmlNode Xclassificazione in Xinformazioni_versante.SelectNodes("classificazione")) {
							string codice_cge = Xclassificazione["codice_cge"].InnerText;
							decimal importo = XmlHelper.AsDecimal(Xclassificazione, "importo");

							foreach (XmlNode Xclassificazione_dati_siope_entrate in Xclassificazione.SelectNodes("classificazione_dati_siope_entrate")) {
								string tipo_debito_siope_c = getXmlText(Xclassificazione_dati_siope_entrate, "tipo_debito_siope_c");
								string tipo_debito_siope_nc = getXmlText(Xclassificazione_dati_siope_entrate, "tipo_debito_siope_nc");

								string tipo_debito_siope = tipo_debito_siope_c != null ? tipo_debito_siope_c : tipo_debito_siope_nc;

								foreach (XmlNode Xfattura_siope in Xclassificazione_dati_siope_entrate.SelectNodes("fattura_siope")) {
									string codice_ipa_ente_siope = Xfattura_siope["codice_ipa_ente_siope"].InnerText;
									string tipo_documento_siope_e = Xfattura_siope["tipo_documento_siope_e"].InnerText;
									string identificativo_lotto_sdi_siope = Xfattura_siope["identificativo_lotto_sdi_siope"].InnerText;

									foreach (XmlNode Xdati_fattura_siope in Xfattura_siope.SelectNodes("dati_fattura_siope")) {
										string numero_fattura_siope = Xdati_fattura_siope["numero_fattura_siope"].InnerText;
										decimal importo_siope = XmlHelper.AsDecimal(Xdati_fattura_siope, "importo_siope");
										DateTime data_scadenza_pagam_siope = XmlHelper.AsDate(Xdati_fattura_siope, "data_scadenza_pagam_siope");
										string motivo_scadenza_siope = getXmlText(Xdati_fattura_siope, "motivo_scadenza_siope");
										string natura_spesa_siope = getXmlText(Xdati_fattura_siope, "natura_spesa_siope");

										DataRow NewDatiFatturaSiope = DS.Tables["ReversaleDatiFatturaSiope"].NewRow();
										NewDatiFatturaSiope["identificativo_flusso"] = this.id_flusso_reversale;
										NewDatiFatturaSiope["tipo_operazione"] = tipo_operazione;
										NewDatiFatturaSiope["numero_reversale"] = numero_reversale;
										NewDatiFatturaSiope["progressivo_versante"] = progressivo_versante;
										NewDatiFatturaSiope["codice_cge"] = codice_cge;
										NewDatiFatturaSiope["tipo_debito_siope"] = tipo_debito_siope;
										NewDatiFatturaSiope["codice_ipa_ente_siope"] = codice_ipa_ente_siope;
										NewDatiFatturaSiope["tipo_documento_siope_e"] = tipo_documento_siope_e;
										NewDatiFatturaSiope["identificativo_lotto_sdi_siope"] = identificativo_lotto_sdi_siope;
										NewDatiFatturaSiope["numero_fattura_siope"] = numero_fattura_siope;
										NewDatiFatturaSiope["importo_siope"] = importo_siope;
										NewDatiFatturaSiope["data_scadenza_pagam_siope"] = data_scadenza_pagam_siope;
										NewDatiFatturaSiope["motivo_scadenza_siope"] = motivo_scadenza_siope;
										NewDatiFatturaSiope["natura_spesa_siope"] = natura_spesa_siope;
										DS.Tables["ReversaleDatiFatturaSiope"].Rows.Add(NewDatiFatturaSiope);
									}

									DataRow NewFatturaSiope = DS.Tables["ReversaleFatturaSiope"].NewRow();
									NewFatturaSiope["identificativo_flusso"] = this.id_flusso_reversale;
									NewFatturaSiope["tipo_operazione"] = tipo_operazione;
									NewFatturaSiope["numero_reversale"] = numero_reversale;
									NewFatturaSiope["progressivo_versante"] = progressivo_versante;
									NewFatturaSiope["codice_cge"] = codice_cge;
									NewFatturaSiope["tipo_debito_siope"] = tipo_debito_siope;
									NewFatturaSiope["codice_ipa_ente_siope"] = codice_ipa_ente_siope;
									NewFatturaSiope["tipo_documento_siope_e"] = tipo_documento_siope_e;
									NewFatturaSiope["identificativo_lotto_sdi_siope"] = identificativo_lotto_sdi_siope;
									DS.Tables["ReversaleFatturaSiope"].Rows.Add(NewFatturaSiope);
								}

								DataRow NewClassificazioneDatiSiopeEntrate = DS.Tables["ReversaleClassificazioneDatiSiopeEntrate"].NewRow();
								NewClassificazioneDatiSiopeEntrate["identificativo_flusso"] = this.id_flusso_reversale;
								NewClassificazioneDatiSiopeEntrate["tipo_operazione"] = tipo_operazione;
								NewClassificazioneDatiSiopeEntrate["numero_reversale"] = numero_reversale;
								NewClassificazioneDatiSiopeEntrate["progressivo_versante"] = progressivo_versante;
								NewClassificazioneDatiSiopeEntrate["codice_cge"] = codice_cge;
								NewClassificazioneDatiSiopeEntrate["tipo_debito_siope"] = tipo_debito_siope;
								DS.Tables["ReversaleClassificazioneDatiSiopeEntrate"].Rows.Add(NewClassificazioneDatiSiopeEntrate);
							}

							DataRow NewClassificazione = DS.Tables["ReversaleClassificazione"].NewRow();
							NewClassificazione["identificativo_flusso"] = this.id_flusso_reversale;
							NewClassificazione["tipo_operazione"] = tipo_operazione;
							NewClassificazione["numero_reversale"] = numero_reversale;
							NewClassificazione["progressivo_versante"] = progressivo_versante;
							NewClassificazione["codice_cge"] = codice_cge;
							NewClassificazione["importo"] = importo;
							DS.Tables["ReversaleClassificazione"].Rows.Add(NewClassificazione);
						}

						foreach (XmlNode Xbollo in Xinformazioni_versante.SelectNodes("bollo")) {
							string assoggettamento_bollo = Xbollo["assoggettamento_bollo"].InnerText;
							string causale_esenzione_bollo = Xbollo["causale_esenzione_bollo"].InnerText;

							DataRow NewBollo = DS.Tables["ReversaleBollo"].NewRow();
							NewBollo["identificativo_flusso"] = this.id_flusso_reversale;
							NewBollo["tipo_operazione"] = tipo_operazione;
							NewBollo["numero_reversale"] = numero_reversale;
							NewBollo["progressivo_versante"] = progressivo_versante;
							NewBollo["assoggettamento_bollo"] = assoggettamento_bollo;
							NewBollo["causale_esenzione_bollo"] = causale_esenzione_bollo;
							DS.Tables["ReversaleBollo"].Rows.Add(NewBollo);
						}

						foreach (XmlNode Xversante in Xinformazioni_versante.SelectNodes("versante")) {
							string anagrafica_versante = Xversante["anagrafica_versante"].InnerText;
							string indirizzo_versante = getXmlText(Xversante, "indirizzo_versante");
							string cap_versante = getXmlText(Xversante, "cap_versante");
							string localita_versante = getXmlText(Xversante, "localita_versante");
							string provincia_versante = getXmlText(Xversante, "provincia_versante");
							string stato_versante = Xversante["stato_versante"].InnerText;
							string partita_iva_versante = getXmlText(Xversante, "partita_iva_versante");
							string codice_fiscale_versante = getXmlText(Xversante, "codice_fiscale_versante");

							DataRow Newversante = DS.Tables["ReversaleVersante"].NewRow();
							Newversante["identificativo_flusso"] = this.id_flusso_reversale;
							Newversante["tipo_operazione"] = tipo_operazione;
							Newversante["numero_reversale"] = numero_reversale;
							Newversante["progressivo_versante"] = progressivo_versante;
							Newversante["anagrafica_versante"] = anagrafica_versante;
							Newversante["indirizzo_versante"] = indirizzo_versante;
							Newversante["cap_versante"] = cap_versante;
							Newversante["localita_versante"] = localita_versante;
							Newversante["provincia_versante"] = provincia_versante;
							Newversante["stato_versante"] = stato_versante;
							Newversante["partita_iva_versante"] = partita_iva_versante;
							Newversante["codice_fiscale_versante"] = codice_fiscale_versante;
							DS.Tables["ReversaleVersante"].Rows.Add(Newversante);
						}

						foreach (XmlNode Xsospeso in Xinformazioni_versante.SelectNodes("sospeso")) {
							int numero_provvisorio = XmlHelper.AsInt(Xsospeso, "numero_provvisorio");
							decimal importo_provvisorio = XmlHelper.AsDecimal(Xsospeso, "importo_provvisorio");

							DataRow NewSospeso = DS.Tables["ReversaleSospeso"].NewRow();
							NewSospeso["identificativo_flusso"] = this.id_flusso_reversale;
							NewSospeso["tipo_operazione"] = tipo_operazione;
							NewSospeso["numero_reversale"] = numero_reversale;
							NewSospeso["progressivo_versante"] = progressivo_versante;
							NewSospeso["numero_provvisorio"] = numero_provvisorio;
							NewSospeso["importo_provvisorio"] = importo_provvisorio;
							DS.Tables["ReversaleSospeso"].Rows.Add(NewSospeso);
						}

						foreach (XmlNode Xmandato_associato in Xinformazioni_versante.SelectNodes("mandato_associato")) {
							string numero_mandato = Xmandato_associato["numero_mandato"].InnerText;
							string progressivo_beneficiario = getXmlText(Xmandato_associato, "progressivo_beneficiario");

							DataRow NewMandatoAssociato = DS.Tables["ReversaleMandatoAssociato"].NewRow();
							NewMandatoAssociato["identificativo_flusso"] = this.id_flusso_reversale;
							NewMandatoAssociato["tipo_operazione"] = tipo_operazione;
							NewMandatoAssociato["numero_reversale"] = numero_reversale;
							NewMandatoAssociato["progressivo_versante"] = progressivo_versante;
							NewMandatoAssociato["numero_mandato"] = numero_mandato;
							NewMandatoAssociato["progressivo_beneficiario"] = progressivo_beneficiario;
							DS.Tables["ReversaleMandatoAssociato"].Rows.Add(NewMandatoAssociato);
						}

                        foreach (XmlNode Xinformazioni_aggiuntive in Xinformazioni_versante.SelectNodes("informazioni_aggiuntive")) {
                            string lingua = getXmlText(Xinformazioni_aggiuntive, "lingua");
                            string riferimento_documento_esterno = getXmlText(Xinformazioni_aggiuntive, "riferimento_documento_esterno");

                            DataRow NewInformazioniAggiuntive = DS.Tables["ReversaleInformazioniAggiuntive"].NewRow();
                            NewInformazioniAggiuntive["identificativo_flusso"] = this.id_flusso_reversale;
                            NewInformazioniAggiuntive["tipo_operazione"] = tipo_operazione;
                            NewInformazioniAggiuntive["numero_reversale"] = numero_reversale;
                            NewInformazioniAggiuntive["progressivo_versante"] = progressivo_versante;
                            NewInformazioniAggiuntive["lingua"] = lingua;
                            NewInformazioniAggiuntive["riferimento_documento_esterno"] = riferimento_documento_esterno;
                            DS.Tables["ReversaleInformazioniAggiuntive"].Rows.Add(NewInformazioniAggiuntive);
                        }

                        foreach (XmlNode Xdati_a_disposizione_ente_versante in Xinformazioni_versante.SelectNodes("dati_a_disposizione_ente_versante")) {
							string lingua = getXmlText(Xdati_a_disposizione_ente_versante, "lingua");
							string riferimento_documento_esterno = getXmlText(Xdati_a_disposizione_ente_versante, "riferimento_documento_esterno");

							DataRow NewDatiADisposizioneEnteVersante = DS.Tables["ReversaleDatiADisposizioneEnteVersante"].NewRow();
							NewDatiADisposizioneEnteVersante["identificativo_flusso"] = this.id_flusso_reversale;
							NewDatiADisposizioneEnteVersante["tipo_operazione"] = tipo_operazione;
							NewDatiADisposizioneEnteVersante["numero_reversale"] = numero_reversale;
							NewDatiADisposizioneEnteVersante["progressivo_versante"] = progressivo_versante;
							NewDatiADisposizioneEnteVersante["lingua"] = lingua;
							NewDatiADisposizioneEnteVersante["riferimento_documento_esterno"] = riferimento_documento_esterno;
							DS.Tables["ReversaleDatiADisposizioneEnteVersante"].Rows.Add(NewDatiADisposizioneEnteVersante);
						}

						DataRow NewInformazioniVersante = DS.Tables["ReversaleInformazioniVersante"].NewRow();
						NewInformazioniVersante["identificativo_flusso"] = this.id_flusso_reversale;
						NewInformazioniVersante["tipo_operazione"] = tipo_operazione;
						NewInformazioniVersante["numero_reversale"] = numero_reversale;
						NewInformazioniVersante["progressivo_versante"] = progressivo_versante;
						NewInformazioniVersante["importo_versante"] = importo_versante;
						NewInformazioniVersante["tipo_riscossione"] = tipo_riscossione;
						NewInformazioniVersante["tipo_entrata"] = tipo_entrata;
						NewInformazioniVersante["destinazione"] = destinazione;
						NewInformazioniVersante["causale"] = causale;
						DS.Tables["ReversaleInformazioniVersante"].Rows.Add(NewInformazioniVersante);
					}

					DataRow NewReversale = DS.Tables["Reversale"].NewRow();
					NewReversale["identificativo_flusso"] = this.id_flusso_reversale;
					NewReversale["tipo_operazione"] = tipo_operazione;
					NewReversale["numero_reversale"] = numero_reversale;
					NewReversale["data_reversale"] = data_reversale;
					NewReversale["importo_reversale"] = importo_reversale;
					NewReversale["conto_evidenza"] = conto_evidenza;
					NewReversale["codice_struttura"] = codice_struttura;					
					DS.Tables["Reversale"].Rows.Add(NewReversale);
				}
			}
			

		}
		//public void elabora(){	
		//	//Xdoc.SelectNodes("/flusso_giornale_di_cassa/testata_messaggio/codice_ABI_BT").Inn;
		//	string idbank = getXmlText(Xdoc, "//flusso_giornale_di_cassa/testata_messaggio/codice_ABI_BT");
		//	M.idbank = idbank;
		//	M.identificativo_flusso_BT = getXmlText(Xdoc, "//flusso_giornale_di_cassa/identificativo_flusso_BT");
		//	//Scorre l'elenco dei flussi (forse superfluo)
		//	XmlNodeList ElencoFlussi = Xdoc.SelectNodes("/flusso_giornale_di_cassa");
		//	foreach (XmlNode XFlusso in ElencoFlussi) { }


		//}

		static string getXmlText(XmlNode x, string xpath)
        {
            try
            {
                XmlNode n = x.SelectSingleNode(xpath);
                if (n != null)
                {
                    return n.InnerText;
                }
            }
            catch (Exception e)
            {
                string errore = e.Message + " " + e.ToString();
            }
            return null;
        }

		private void SaveData() {
			//se non ci sono cambiamenti non fare nulla
			if (!DS.HasChanges()) return;
			// Salva  dataset DS
			Easy_PostData MyPostData = new Easy_PostData();
			MyPostData.InitClass(DS, Meta.Conn);
			MyPostData.DO_POST();
		}

        private void btnMigraDati_Click(object sender, EventArgs e) {
			ElaboraXml();
		}

        private void btnMigraReversali_Click(object sender, EventArgs e) {
			ElaboraXml();
		}
    }
}
