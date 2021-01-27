
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using bankdispositionsetup_import;
using System.IO;
using System.Data;
using metadatalibrary;
using funzioni_configurazione;

namespace bankdispositionsetup_mps
{
    /// <summary>
    /// Summary description for FrmMontePaschi.
    /// </summary>
    public class FrmMontePaschi : System.Windows.Forms.Form
    {
        MetaData Meta;
        ImportazioneEsitiBancariMPS import;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInizioElaborazione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFineElaborazione;
        private System.Windows.Forms.TextBox txtUltimaEsitazioneDB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelOperazione;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnChiudi;
        private System.Windows.Forms.Button btnEsita;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnApriFile;
        public bankdispositionsetup_mps.vistaForm DS;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public FrmMontePaschi()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
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
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInizioElaborazione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFineElaborazione = new System.Windows.Forms.TextBox();
            this.txtUltimaEsitazioneDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelOperazione = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnEsita = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnApriFile = new System.Windows.Forms.Button();
            this.DS = new bankdispositionsetup_mps.vistaForm();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInizioElaborazione);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFineElaborazione);
            this.groupBox1.Location = new System.Drawing.Point(144, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(224, 40);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elaborazione";
            // 
            // txtInizioElaborazione
            // 
            this.txtInizioElaborazione.Location = new System.Drawing.Point(40, 16);
            this.txtInizioElaborazione.Name = "txtInizioElaborazione";
            this.txtInizioElaborazione.ReadOnly = true;
            this.txtInizioElaborazione.Size = new System.Drawing.Size(72, 20);
            this.txtInizioElaborazione.TabIndex = 21;
            this.txtInizioElaborazione.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "Inizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(112, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Fine:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFineElaborazione
            // 
            this.txtFineElaborazione.Location = new System.Drawing.Point(144, 16);
            this.txtFineElaborazione.Name = "txtFineElaborazione";
            this.txtFineElaborazione.ReadOnly = true;
            this.txtFineElaborazione.Size = new System.Drawing.Size(72, 20);
            this.txtFineElaborazione.TabIndex = 23;
            this.txtFineElaborazione.Text = "";
            // 
            // txtUltimaEsitazioneDB
            // 
            this.txtUltimaEsitazioneDB.Location = new System.Drawing.Point(8, 49);
            this.txtUltimaEsitazioneDB.Name = "txtUltimaEsitazioneDB";
            this.txtUltimaEsitazioneDB.ReadOnly = true;
            this.txtUltimaEsitazioneDB.Size = new System.Drawing.Size(120, 20);
            this.txtUltimaEsitazioneDB.TabIndex = 40;
            this.txtUltimaEsitazioneDB.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 39;
            this.label3.Text = "Ultima esitazione sul DB";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(148, 414);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(472, 23);
            this.progressBar1.TabIndex = 35;
            // 
            // labelOperazione
            // 
            this.labelOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOperazione.Location = new System.Drawing.Point(4, 414);
            this.labelOperazione.Name = "labelOperazione";
            this.labelOperazione.Size = new System.Drawing.Size(144, 29);
            this.labelOperazione.TabIndex = 36;
            this.labelOperazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(8, 6);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(552, 20);
            this.txtFile.TabIndex = 31;
            this.txtFile.Text = "";
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(568, 3);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(48, 23);
            this.btnChiudi.TabIndex = 34;
            this.btnChiudi.Text = "Esci";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnEsita
            // 
            this.btnEsita.Enabled = false;
            this.btnEsita.Location = new System.Drawing.Point(488, 41);
            this.btnEsita.Name = "btnEsita";
            this.btnEsita.Size = new System.Drawing.Size(64, 23);
            this.btnEsita.TabIndex = 33;
            this.btnEsita.Text = "Esita";
            this.btnEsita.Click += new System.EventHandler(this.btnEsita_Click);
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(8, 73);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(608, 336);
            this.dataGrid1.TabIndex = 32;
            // 
            // btnApriFile
            // 
            this.btnApriFile.Location = new System.Drawing.Point(400, 41);
            this.btnApriFile.Name = "btnApriFile";
            this.btnApriFile.Size = new System.Drawing.Size(64, 23);
            this.btnApriFile.TabIndex = 37;
            this.btnApriFile.Text = "Apri file";
            this.btnApriFile.Click += new System.EventHandler(this.btnApriFile_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // FrmMontePaschi
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(624, 446);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtUltimaEsitazioneDB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelOperazione);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnEsita);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.btnApriFile);
            this.Name = "FrmMontePaschi";
            this.Text = "FrmMontePaschi";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion



        private void btnApriFile_Click(object sender, System.EventArgs e)
        {
            StreamReader sr = import.getStreamReader(252, openFileDialog1, txtFile);
            if (sr == null)
            {
                return;
            }
            labelOperazione.Text = "Lettura file";

            btnEsita.Enabled = parseFile(sr);

            labelOperazione.Text = null;
            progressBar1.Value = 0;
            Cursor = null;
        }

        bool parseFile(StreamReader sr)
        {
            ArrayList altriEsercizi = new ArrayList();
            txtInizioElaborazione.Text = null;
            txtFineElaborazione.Text = null;
            DS.giornaledicassa.Clear();
            DS.gdc.Clear();
            Application.DoEvents();
            Cursor = Cursors.WaitCursor;
            int numFile = 0;
            progressBar1.Maximum = (int)sr.BaseStream.Length;
            while (sr.Peek() != -1)
            {
                int numRecord = 0;
                numFile++;
                DataRow rTC = DS.gdc.NewRow();
                if (!leggiRecordDiTesta(sr, rTC)) return false;
                //				DS.gdc.Rows.Add(rTC);
                int tipoRecord = import.leggiNumerico(sr, 2);
                while (tipoRecord == 2)
                {
                    numRecord++;
                    DataRow rDett = DS.giornaledicassa.NewRow();
                    rDett["DATAPRODUZIONEFLUSSO"] = rTC["DATAPRODUZIONEFLUSSO"];
                    rDett["CODICEFILIALE"] = rTC["CODICEFILIALE"];
                    rDett["CODICEENTE"] = rTC["CODICEENTE"];
                    rDett["ESERCIZIOFINANZIARIO"] = rTC["ESERCIZIOFINANZIARIO"];
                    rDett["DATADIRIFERIMENTO"] = rTC["DATADIRIFERIMENTO"];
                    if (!leggiRecordDiDettaglio(sr, rDett)) return false;
                    if (CfgFn.GetNoNullInt32(rDett["ESERCIZIOFINANZIARIO"]) == CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")))
                    {
                        DS.giornaledicassa.Rows.Add(rDett);
                    }
                    else
                    {
                        if (!altriEsercizi.Contains(rDett["ESERCIZIOFINANZIARIO"]))
                        {
                            altriEsercizi.Add(rDett["ESERCIZIOFINANZIARIO"]);
                        }
                    }
                    tipoRecord = import.leggiNumerico(sr, 2);
                    progressBar1.Value = (int)sr.BaseStream.Position;
                    Application.DoEvents();
                }
                if (tipoRecord != 3)
                {
                    QueryCreator.ShowError(this, "Mi aspettavo il record 3 invece ho ricevuto il record " + tipoRecord, "");
                    return false;
                }
                if (!leggiRecordDiTotali(sr, rTC)) return false;
                if (!leggiRecordDiCoda(sr, rTC)) return false;
            }
            sr.Close();
            copia_Mps_IN020304();
            if (!import.completaParsing(dataGrid1, txtInizioElaborazione, txtFineElaborazione))
            {
                return false;
            }
            if (altriEsercizi.Count > 0)
            {
                string messaggio = "Nel file ci sono esitazioni relative ad esercizi diversi.\nDopo aver esitato nel "
                + Meta.GetSys("esercizio")
                + ", se necessario, occorrerà ripetere l'operazione anche per ";
                if (altriEsercizi.Count == 1)
                {
                    messaggio += "l'esercizio " + altriEsercizi[0];
                }
                if (altriEsercizi.Count > 1)
                {
                    messaggio += "gli esercizi " + altriEsercizi[0];
                    for (int i = 1; i < altriEsercizi.Count - 1; i++)
                    {
                        messaggio += ", " + altriEsercizi[i];
                    }
                    messaggio += " e " + altriEsercizi[altriEsercizi.Count - 1];
                }
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, messaggio);
            }
            return true;
        }

        /// <summary>
        /// 	01 - RECORD IDENTIFICATIVO DI FLUSSO
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        bool leggiRecordDiTesta(TextReader tr, DataRow r)
        {
            int tipoRecord = import.leggiNumerico(tr, 2);
            r["TIPORECORD1"] = tipoRecord;//NUMERICO		 2		 1
            r["PROGRESSIVODIFLUSSO1"] = import.leggiNumerico(tr, 5);//	NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            int tipoFlusso = import.leggiNumerico(tr, 3);
            r["TIPOFLUSSO"] = tipoFlusso;//NUMERICO		 3		 3 INDICA LA TIPOLOGIA DEL FLUSSO IN TRASMISSIONE:      011    GIORNALE DI CASSA
            r["DATAPRODUZIONEFLUSSO"] = import.leggiDataAMG(tr, 8);//NUMERICO		 8		 4 ESPRESSO NEL FORMATO DATA   AAAAMMGG
            r["PROGRESSIVOPERDATA"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		 5 UTILIZZATO IN CASO DI PIU’ FLUSSI INVIATI NELLA STESSA DATA ( PRIMO INVIO = 0 ) 
            r["CODICEFILIALE"] = import.leggiNumerico(tr, 5);//NUMERICO		 5		 6 CODICE DELLA FILIALE CHE EFFETTUA IL  SERVIZIO DI TESORERIA 
            r["CODICEENTE"] = import.leggiNumerico(tr, 3);//NUMERICO		 3		 7 CODICE DELL’ENTE FORNITO DALLA DIPENDENZA CHE EFFETTUA IL SERVIZIO DI TESORERIA 
            r["ANAGRAFICAENTE"] = import.leggiAlfanumerico(tr, 35);//CARATTERE		35
            r["ESERCIZIOFINANZIARIO"] = import.leggiNumerico(tr, 4);//(AAAA)			NUMERICO		 4
            r["DATADIRIFERIMENTO"] = import.leggiDataAMG(tr, 8);//NUMERICO		 8		 8 GIORNATA A CUI SI RIFERISCONO LE INFORMAZIONI CONTENUTE NEL FLUSSO (AAAAMMGG)
            r["DIVISA"] = import.leggiAlfanumerico(tr, 1);//CARATTERE		 1		 9
            r["FILLER1"] = import.leggiAlfanumerico(tr, 175);//CARATTERE	         175
            if (tipoRecord != 1)
            {
                QueryCreator.ShowError(this, "Mi aspettavo il record 1 invece ho ricevuto il record " + tipoRecord, "");
                return false;
            }
            if (tipoFlusso != 11)
            {
                QueryCreator.ShowError(this, "Mi aspettavo il flusso 11 (giornale di cassa) invece ho ricevuto il flusso " + tipoFlusso, "");
                return false;
            }
            return import.vaiACapo(tr);
        }

        /// <summary>
        /// 02 - RECORD DI DETTAGLIO DEI MOVIMENTI DELLA GIORNATA
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        bool leggiRecordDiDettaglio(TextReader tr, DataRow r)
        {
            //			r["TIPORECORD"] = import.leggiNumerico(tr, 2);//NUMERICO		 2		 1
            r["PROGRESSIVODIFLUSSO"] = import.leggiNumerico(tr, 5);//NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            r["NUMEROORDINATIVO_O_CARTACONTABILE"] = import.leggiNumerico(tr, 7);//NUMERICO		 7
            r["PROGRESSIVODISPOSIZIONE"] = import.leggiNumerico(tr, 5);//NUMERICO		 5		10 INDICA L’ESECUZIONE DI UN SUB_ORDINATIVO
            r["FLAGORDINATIVO_CARTACONTABILE"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		11 0   =   ORDINATIVO;		1   =  CARTA CONTABILE
            r["BENEFICIARIO_O_OBBLIGATO"] = import.leggiAlfanumerico(tr, 60);//CARATTERE		60
            r["FLAGCOMPETENZA_RESIDUI"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		12	0   =   COMPETENZA;		1   =   RESIDUI		
            r["FLAGENTRATE_USCITE"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		13 0   =   ENTRATE;		1   =   USCITE
            r["IMPORTO"] = import.leggiDecimale(tr, 15);//NUMERICO		15		14 IMPORTO DELL’OPERAZIONE ESPRESSO NELLA DIVISA CON CUI L’ENTE INTRATTIENE IL 	RAPPORTO CON IL TESORIERE
            r["FLAGFRUTTIFERO_INFRUTTIFERO"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		15 1   =   FRUTTIFERO;		2   =   INFRUTTIFERO;    PER GLI ENTI IN T.U.   ZERO PER GLI ALTRI
            r["IMPORTOFRUTTIFERO"] = import.leggiDecimale(tr, 15);//NUMERICO		15		16 EVENTUALE PARTE FRUTTIFERA DELL’IMPORTO TOTALE (14); 	SOLO PER LE USCITE DEGLI ENTI IN T.U.
            r["STORNO"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		17 1   =   OPERAZIONE STORNATA;	 ZERO NEGLI ALTRI CASI  
            r["BOLLETTA"] = import.leggiNumerico(tr, 9);//NUMERICO		 9		18 NUMERO DELLA BOLLETTA EMESSA IN AUTOMATICO A FRONTE DI UN INCASSO
            r["CONTOCORRENTE"] = import.leggiNumerico(tr, 7);//NUMERICO		 7		19 CONTO CORRENTE A CUI E’ IMPUTATA L’OPERAZIONE;	VALORIZZATO SOLO SE CONTO VINCOLO O DI EVIDENZA
            r["DATAVALUTA"] = import.leggiDataAMG(tr, 8);//NUMERICO		 8		20 VALUTA DELL’OPERAZIONE (AAAAMMGG);   NON VALORIZZATO PER GLI ENTI IN T.U. TAB. A
            r["VALUTASPECIALE"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		21 INDICA UNA VALUTA FUORI DAGLI STANDARD; NON VALORIZZATO PER ENTI IN T.U. TAB. A  
            r["GIROFONDI"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		22 INDICA CHE L’OPERAZIONE E’ AVVENUTA CON MODALITA’ GIROFONDI
            r["DIVISAOPERAZIONE"] = import.leggiAlfanumerico(tr, 1);//CARATTERE		 1		23 INDICA LA DIVISA DELL’OPERAZIONE SE DIVERSA DALLA DIVISA CON CUI L’ENTE INTRATTIENE IL RAPPORTO CON IL TESORIERE (9);	E   =   EURO	L   =   LIRE ; 	  BLANK NEGLI ALTRI CASI
            r["CONTROVALOREDIVISAOPERAZIONE"] = import.leggiDecimale(tr, 15);//NUMERICO		15		24 24)	CONTROVALORE DERIVATO DALLA CONVERSIONE TRA LE DUE DIVISE ZERO NEL CASO NON SIA STATA EFFETTUATA ALCUNA CONVERSIONE
            r["MODALITADIESECUZIONE"] = import.leggiAlfanumerico(tr, 1);//CARATTERE		 1		27
            //27)	MODALITA’ DI ESECUZIONE:
            //A = ASSEGNO CIRCOLARE
            //B = BONIFICO
            //C = CASSA
            //G = GIROFONDI
            //I = ASSEGNO CIRCOLARE N.T. INVIATO AL BENEFICIARIO	
            //L = ASSEGNO POSTALE LOCALIZZATO
            //P = BOLLETTINO POSTALE
            //R = REGOLARIZZAZIONE CARTA CONTABILE
            //S = STORNO
            //T = TRATTENUTE
            r["CARTACONTABILE"] = import.leggiNumerico(tr, 7);//NUMERICO		 7		28 CARTA CONTABILE REGOLARIZZATA DALL’ORDINATIVO/SUB INDICATO
            r["DATIRISERVATIALLENTE"] = import.leggiAlfanumerico(tr, 7);//CARATTERE		 7		29	 29)	DATI CHE L’ENTE HA INVIATO PER SUOI USI INTERNI
            r["DESCRIZIONEOPERAZIONE"] = import.leggiAlfanumerico(tr, 50);//CARATTERE 		50
            r["CRO_NUMEROASSEGNO"] = import.leggiLong(tr, 13);//NUMERICO		13		30 30)	SE LA MODALITA’ DI ESECUZIONE E’  BONIFICO, E’ VALORIZZATO CON IL CRO, SE E’ ASSEGNO CIRCOLARE CON IL NUMERO DELL’ASSEGNO. 
            r["FILLER"] = import.leggiAlfanumerico(tr, 16);//CARATTERE		16
            return import.vaiACapo(tr);
        }

        /// <summary>
        /// 03 - RECORD DI TOTALI
        /// </summary>
        /// <param name="tr"></param>
        /// <param name="r"></param>
        /// <returns></returns>
        bool leggiRecordDiTotali(TextReader tr, DataRow r)
        {
            string segno;
            //			r["TIPORECORD"] = import.leggiNumerico(tr, 2);//NUMERICO		 2		 1
            r["PROGRESSIVODIFLUSSO3"] = import.leggiNumerico(tr, 5);//NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            r["RISCOSSIONIGIORNATA"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["PAGAMENTIGIORNATA"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["RISCOSSIONIGIORNATEPRECEDENTI"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["PAGAMENTIGIORNATEPRECEDENTI"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["RISCOSSIONITOTALI"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["PAGAMENTITOTALI"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOINIZIALE"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOALLADATARIFERIMENTO"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOFRUTTIFERO"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["SALDOINFRUTTIFERO"] = import.leggiDecimaleConSegno(tr, 16, out segno);//NUMERICO		15
            r["ECCEDENZAGIACENZAMASSIMA"] = import.leggiDecimale(tr, 15);//NUMERICO		15		26 26)	PER ENTI IN TESORERIA UNICA TABELLA B
            r["FILLER3"] = import.leggiAlfanumerico(tr, 68);//CARATTERE		68
            return import.vaiACapo(tr);
        }

        bool leggiRecordDiCoda(TextReader tr, DataRow row)
        {
            int tipoRecord = import.leggiNumerico(tr, 2);
            Hashtable r = new Hashtable();
            //			r["TIPORECORD"] = tipoRecord;//NUMERICO		 2		 1
            /*r["PROGRESSIVODIFLUSSO1"] =*/
            import.leggiNumerico(tr, 5);//	NUMERICO		 5		 2 PROGRESSIVO DEL RECORD ALL’INTERNO DEL FLUSSO
            r["TIPOFLUSSO"] = import.leggiNumerico(tr, 3);//NUMERICO		 3		 3 INDICA LA TIPOLOGIA DEL FLUSSO IN TRASMISSIONE:      011    GIORNALE DI CASSA
            r["DATAPRODUZIONEFLUSSO"] = import.leggiDataAMG(tr, 8);//NUMERICO		 8		 4 ESPRESSO NEL FORMATO DATA   AAAAMMGG
            r["PROGRESSIVOPERDATA"] = import.leggiNumerico(tr, 1);//NUMERICO		 1		 5 UTILIZZATO IN CASO DI PIU’ FLUSSI INVIATI NELLA STESSA DATA ( PRIMO INVIO = 0 ) 
            r["CODICEFILIALE"] = import.leggiNumerico(tr, 5);//NUMERICO		 5		 6 CODICE DELLA FILIALE CHE EFFETTUA IL  SERVIZIO DI TESORERIA 
            r["CODICEENTE"] = import.leggiNumerico(tr, 3);//NUMERICO		 3		 7 CODICE DELL’ENTE FORNITO DALLA DIPENDENZA CHE EFFETTUA IL SERVIZIO DI TESORERIA 
            r["ANAGRAFICAENTE"] = import.leggiAlfanumerico(tr, 35);//CARATTERE		35
            r["ESERCIZIOFINANZIARIO"] = import.leggiNumerico(tr, 4);//(AAAA)			NUMERICO		 4
            r["DATADIRIFERIMENTO"] = import.leggiDataAMG(tr, 8);//NUMERICO		 8		 8 GIORNATA A CUI SI RIFERISCONO LE INFORMAZIONI CONTENUTE NEL FLUSSO (AAAAMMGG)
            r["DIVISA"] = import.leggiAlfanumerico(tr, 1);//CARATTERE		 1		 9
            r["FILLER1"] = import.leggiAlfanumerico(tr, 175);//CARATTERE	         175
            if (tipoRecord != 99)
            {
                QueryCreator.ShowError(this, "Mi aspettavo il record 1 invece ho ricevuto il record " + tipoRecord, "");
                return false;
            }
            foreach (DictionaryEntry de in r)
            {
                if (!row[(string)de.Key].Equals(de.Value))
                {
                    QueryCreator.ShowError(this, "Errore durante la lettura del file",
                        "Differenze nella colonna " + de.Key
                        + "\r\nrecord 01: " + row[(string)de.Key]
                        + "\r\nrecord 99: " + de.Value);
                }
            }
            return import.vaiACapo(tr);
        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Meta.MainRefreshEnabled = false;
            Meta.SearchEnabled = false;
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            DataAccess.SetTableForReading(DS.bankdispositionsetup, "config");
            import = new ImportazioneEsitiBancariMPS(this, true, labelOperazione, progressBar1, Meta.Conn);
            Text = "Importazione esiti dei movimenti MontePaschi";
            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
            if (ultimaEsitazioneDB == DBNull.Value) {
                ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1) + "' )"
                    , "max(transactiondate)");
            }

            if (ultimaEsitazioneDB is DateTime)
            {
                txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
            }
        }

        public void MetaData_AfterFill()
        {
            Text = "Importazione esiti dei movimenti MontePaschi";
        }

        public void MetaData_AfterClear()
        {
            Text = "Importazione esiti dei movimenti MontePaschi";
        }

        private void copia_Mps_IN020304()
        {
            import.DS.flussobanca.Clear();
            foreach (DataRow s in DS.giornaledicassa.Rows)
            {
                DataRow r = import.DS.flussobanca.NewRow();
                int flagCartacontabile = (int)s["FLAGORDINATIVO_CARTACONTABILE"];
                int flagUscite = (int)s["FLAGENTRATE_USCITE"];
                int flagStorno = (int)s["STORNO"];
                string modalitaEsecuzione = (string)s["MODALITADIESECUZIONE"];
                int tipo = flagCartacontabile * 2 + flagUscite;
                switch (tipo)
                {
                    case 0: r["TIPDOC"] = "R"; break;
                    case 1: r["TIPDOC"] = "M"; break;
                    case 2: r["TIPDOC"] = "I"; break;
                    case 3: r["TIPDOC"] = "P"; break;
                }
                if (flagCartacontabile == 1)
                {
                    r["NUMQUI"] = s["NUMEROORDINATIVO_O_CARTACONTABILE"];
                }
                else
                {
                    if (modalitaEsecuzione == "R")
                    {
                        r["NUMQUI"] = s["CARTACONTABILE"];
                    }
                    else
                    {
                        r["NUMQUI"] = -(int)s["BOLLETTA"];
                    }
                }
                r["SEGNO"] = flagStorno == 1 ? "-" : "+";
                r["INDREG"] = modalitaEsecuzione == "R" ? "R" : " ";

                r["ISTTS"] = s["CODICEFILIALE"];
                r["CODEN"] = s["CODICEENTE"];
                r["ESERC"] = s["ESERCIZIOFINANZIARIO"];
                //				r["TIPDOC"] = s["tipdoc"]; assegnato sopra
                r["NUMDOC"] = s["NUMEROORDINATIVO_O_CARTACONTABILE"];
                r["PRODOC"] = s["PROGRESSIVODISPOSIZIONE"];
                //				r["CAPBIL"] = s[""];
                //				r["ARTBIL"] = s[""];
                //				r["CDMEC"] = s[""];
                //				r["ANNOCO"] = s[""];
                r["IMPDOC"] = s["IMPORTO"];
                //				r["SEGNO"] = s["segno"]; assegnato sopra
                r["DTELAB"] = s["DATAPRODUZIONEFLUSSO"];
                //				r["DTELAB"] = s["datacaricamento"];coincide con data pagamento
                r["DTPAG"] = s["DATADIRIFERIMENTO"];
                r["DVAL"] = s["DATAVALUTA"];
                //				r["NUMQUI"] = s[""];assegnato sopra
                //				r["NUMDIS"] = s[""];
                //				r["IMPRIT"] = s[""];
                //				r["INDREG"] = s["indreg"];assegnato sopra
                r["DVALBE"] = DBNull.Value;
                //				r["NUMPRA"] = s[""];
                //				r["CODVER"] = s[""];
                //				r["NUMPRR"] = s[""];
                //				r["PROGPR"] = s[""];
                //				r["IBOLLI"] = s[""];
                //				r["INDBOL"] = s[""];
                //				r["ICOMM"] = s[""];
                //				r["INDCOM"] = s[""];
                //				r["ISPE"] = s[""];
                //				r["INDSPE"] = s[""];
                r["TPAGTS"] = s["MODALITADIESECUZIONE"];
                //				r["CODABI"] = s[""];
                //				r["CODCAB"] = s[""];
                r["CONTO"] = s["CONTOCORRENTE"];
                r["CIN"] = "";
                //				r["IBAN_PAE"] = s[""];
                //				r["IBAN_CHK"] = s[""];
                //				r["IBAN_COO"] = s[""];
                r["NCNT"] = s["CONTOCORRENTE"];
                //				r["CTIPIPU"] = s[""];
                //				r["DESVER"] = s[""];
                //				r["CCGU"] = s[""];
                //				r["CCPV"] = s[""];
                //				r["CCUP"] = s[""];
                //				r["FILLER"] = s[""];
                r["ANABE"] = s["BENEFICIARIO_O_OBBLIGATO"];
                //				r["INDIR"] = s["indirizzo"];
                //				r["CAP"] = s["cap"];
                //				r["LOC"] = s["localita"];
                //				r["CFISC"] = "";
                r["CAUSALE"] = s["DESCRIZIONEOPERAZIONE"];
                //r["FILLER"] = s[""];
                //				r[""] = s["TIPO RECORD"];
                //				r[""] = s["PROGRESSIVO DI FLUSSO"];
                //				r[""] = s["FLAG COMPETENZA/RESIDUI"];
                //				r[""] = s["FLAG FRUTTIFERO/INFRUTTIFERO"];
                //				r[""] = s["IMPORTO FRUTTIFERO"];
                //				r[""] = s["VALUTA SPECIALE"];
                //				r[""] = s["GIROFONDI"];
                //				r[""] = s["DIVISA OPERAZIONE"];
                //				r[""] = s["CONTROVALORE DIVISA OPERAZIONE"];
                //				r[""] = s["DATI RISERVATI ALL’ENTE"];
                //				r[""] = s["CRO/NUMERO ASSEGNO"];
                //				r[""] = s["GIROFONDI"];
                //				r[""] = s["FILLER"];
                import.DS.flussobanca.Rows.Add(r);
            }
            DS.giornaledicassa.Clear();
        }

        private void btnChiudi_Click(object sender, System.EventArgs e)
        {
            this.Dispose();
        }

        private void btnEsita_Click(object sender, System.EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            btnEsita.Enabled = !import.esita(true);

            labelOperazione.Text = null;
            progressBar1.Value = 0;
            Cursor = null;

            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
            if (ultimaEsitazioneDB is DateTime)
            {
                txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
            }
        }
    }

    public class ImportazioneEsitiBancariMPS : ImportazioneEsitiBancari
    {
        DataAccess Conn;
        public ImportazioneEsitiBancariMPS(Form form, bool chiusuraAutomaticaPartitePendenti,
            Label labelOperazione, ProgressBar progressBar1, DataAccess Conn)
            :
            base(form, chiusuraAutomaticaPartitePendenti, labelOperazione, progressBar1)
        {
            this.Conn = Conn;
        }
        public override BANCA getBanca()
        {
            return BANCA.MPS;
        }
        public override DataTable getInfoMandati(object esercDocPagamento, object numDocPagamento)
        {
            string query = "SELECT s.ymov as ypay, el.kpay, p.npay, el.idpay, PRODOC = el.idpay, NUMQUI=el.nbill,"
                + "TPAGTS=m.methodbankcode, "//codicemodalitaCass
                + "sCODABI=el.idbank, "//codiceabi
                + "sCODCAB=el.idcab, "//codicecab
                + "CONTO=REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(el.cc,''),',',''),'.',''),'_',''),'-',''),'*',''),'+',''),'/',''),':',''),';',''), "//contocorrente
                + "CIN=ISNULL(el.cin,''), "//cin
                + "ANABE=ISNULL(c.title,''), "//denominazioneben
                + "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "//codicefiscaleben
                + "CAUSALE = CASE WHEN (SELECT COUNT(*) FROM expense s1 JOIN expenselast sl1 on s1.idexp=sl1.idexp "
                + " WHERE s1.ymov = s.ymov AND sl1.kpay = el.kpay AND sl1.idpay = el.idpay) > 1 THEN 'ACCORPAMENTO PAGAMENTI' "
                + " ELSE ISNULL(s.doc,'') + ISNULL(CONVERT(varchar(12),s.docdate),'') + ISNULL(s.description,'') END "
                + "FROM expense s "
                + "JOIN expenselast el ON s.idexp=el.idexp "
                + "JOIN payment p ON p.kpay = el.kpay "
                + "JOIN paymethod m ON (el.idpaymethod = m.idpaymethod) "
                + "JOIN registry c ON (c.idreg = s.idreg) "
                + "JOIN registryclass ctc ON (ctc.idregistryclass = c.idregistryclass) "
                + "WHERE (p.ypay = " + esercDocPagamento
                + ") and (p.npay = " + numDocPagamento
                + ") AND (el.idpay is not null)";
            string errMsg;
            DataTable tInfo = Conn.SQLRunner(query, -1, out errMsg);
            if (tInfo == null)
            {
                QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n" + query, errMsg);
            }
            tInfo.Columns.Add("CODABI", typeof(string));
            tInfo.Columns.Add("CODCAB", typeof(string));
            foreach (DataRow r in tInfo.Rows)
            {
                r["CODABI"] = r["sCODABI"];
                r["CODCAB"] = r["sCODCAB"];
            }
            return tInfo;
        }

        public override DataTable getInfoReversali(object esercDocIncasso, object numDocIncasso)
        {
            string query = "SELECT e.ymov as ypro, el.kpro, p.npro, el.idpro, PRODOC = el.idpro, TPAGTS='', CODABI=0, CODCAB=0, CONTO='', CIN='', NUMQUI=el.nbill,"
               + "ANABE=ISNULL(c.title,''), "
               + "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "
               + "CAUSALE=CASE WHEN (SELECT COUNT(*) FROM income e1 join incomelast el1 ON e1.idinc=el1.idinc"
               + " WHERE e1.ymov = e.ymov AND el1.kpro = el.kpro "
               + " AND el1.idpro = el.idpro) > 1 THEN 'ACCORPAMENTO INCASSI' ELSE "
               + " ISNULL(e.doc,'') + ISNULL(CONVERT(varchar(12),e.docdate),'') + ISNULL(e.description,'') END "
               + " FROM income e "
               + " JOIN incomelast el on e.idinc=el.idinc "
               + " JOIN proceeds p ON p.kpro = el.kpro "
               + "JOIN registry c ON c.idreg = e.idreg "
               + "JOIN registryclass ctc ON ctc.idregistryclass = c.idregistryclass "
               + "WHERE p.ypro = " + esercDocIncasso
               + " AND p.npro = " + numDocIncasso
               + " AND el.idpro is not null";
            string errMsg;
            DataTable tInfo = Conn.SQLRunner(query, -1, out errMsg);
            if (tInfo == null)
            {
                QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n" + query, errMsg);
            }
            return tInfo;
        }
    }
}
