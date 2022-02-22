
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using System.IO;
using funzioni_configurazione;
using System.Globalization;
using bankdispositionsetup_import;

namespace bankdispositionsetup_carime {
	/// <summary>
	/// Summary description for FrmCarime.
	/// </summary>
	public class FrmCarime : MetaDataForm {
		ImportazioneEsitiBancariCarime import;
		char[] buffer = new char[802];//globale per ottimizzazione lettura dal file
		MetaData Meta;
		private System.Windows.Forms.TextBox txtUltimaEsitazioneDB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtInizioElaborazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFineElaborazione;
		private System.Windows.Forms.Button btnApriCarime;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label labelOperazione;
		private System.Windows.Forms.TextBox txtFile;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.Button btnEsita;
		private System.Windows.Forms.DataGrid dataGrid1;
		public bankdispositionsetup_carime.vistaForm DS;
		private System.Windows.Forms.OpenFileDialog _openFileDialog1;
        CQueryHelper QHC;
        QueryHelper QHS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public IOpenFileDialog openFileDialog;

		public FrmCarime() {
			InitializeComponent();
            openFileDialog = createOpenFileDialog(_openFileDialog1);
		}

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
            this.txtUltimaEsitazioneDB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInizioElaborazione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFineElaborazione = new System.Windows.Forms.TextBox();
            this.btnApriCarime = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelOperazione = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnChiudi = new System.Windows.Forms.Button();
            this.btnEsita = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.DS = new bankdispositionsetup_carime.vistaForm();
            this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUltimaEsitazioneDB
            // 
            this.txtUltimaEsitazioneDB.Location = new System.Drawing.Point(12, 46);
            this.txtUltimaEsitazioneDB.Name = "txtUltimaEsitazioneDB";
            this.txtUltimaEsitazioneDB.ReadOnly = true;
            this.txtUltimaEsitazioneDB.Size = new System.Drawing.Size(120, 20);
            this.txtUltimaEsitazioneDB.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 20);
            this.label3.TabIndex = 29;
            this.label3.Text = "Ultima esitazione sul DB";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInizioElaborazione);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtFineElaborazione);
            this.groupBox1.Location = new System.Drawing.Point(148, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 40);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elaborazione";
            // 
            // txtInizioElaborazione
            // 
            this.txtInizioElaborazione.Location = new System.Drawing.Point(40, 16);
            this.txtInizioElaborazione.Name = "txtInizioElaborazione";
            this.txtInizioElaborazione.ReadOnly = true;
            this.txtInizioElaborazione.Size = new System.Drawing.Size(72, 20);
            this.txtInizioElaborazione.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Inizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(120, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Fine:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFineElaborazione
            // 
            this.txtFineElaborazione.Location = new System.Drawing.Point(152, 16);
            this.txtFineElaborazione.Name = "txtFineElaborazione";
            this.txtFineElaborazione.ReadOnly = true;
            this.txtFineElaborazione.Size = new System.Drawing.Size(72, 20);
            this.txtFineElaborazione.TabIndex = 7;
            // 
            // btnApriCarime
            // 
            this.btnApriCarime.Location = new System.Drawing.Point(412, 38);
            this.btnApriCarime.Name = "btnApriCarime";
            this.btnApriCarime.Size = new System.Drawing.Size(64, 23);
            this.btnApriCarime.TabIndex = 26;
            this.btnApriCarime.Text = "Apri file";
            this.btnApriCarime.Click += new System.EventHandler(this.btnApriCarime_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(148, 414);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(480, 23);
            this.progressBar1.TabIndex = 24;
            // 
            // labelOperazione
            // 
            this.labelOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelOperazione.Location = new System.Drawing.Point(4, 414);
            this.labelOperazione.Name = "labelOperazione";
            this.labelOperazione.Size = new System.Drawing.Size(144, 29);
            this.labelOperazione.TabIndex = 25;
            this.labelOperazione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(12, 6);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(560, 20);
            this.txtFile.TabIndex = 20;
            // 
            // btnChiudi
            // 
            this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnChiudi.Location = new System.Drawing.Point(580, 3);
            this.btnChiudi.Name = "btnChiudi";
            this.btnChiudi.Size = new System.Drawing.Size(48, 23);
            this.btnChiudi.TabIndex = 23;
            this.btnChiudi.Text = "Esci";
            this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
            // 
            // btnEsita
            // 
            this.btnEsita.Enabled = false;
            this.btnEsita.Location = new System.Drawing.Point(500, 38);
            this.btnEsita.Name = "btnEsita";
            this.btnEsita.Size = new System.Drawing.Size(64, 23);
            this.btnEsita.TabIndex = 22;
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
            this.dataGrid1.Location = new System.Drawing.Point(12, 70);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(616, 344);
            this.dataGrid1.TabIndex = 21;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // FrmCarime
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 446);
            this.Controls.Add(this.txtUltimaEsitazioneDB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnApriCarime);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.labelOperazione);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnChiudi);
            this.Controls.Add(this.btnEsita);
            this.Controls.Add(this.dataGrid1);
            this.Name = "FrmCarime";
            this.Text = "FrmCarime";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			Meta.MainRefreshEnabled=false;
			Meta.SearchEnabled=false;
			Meta.CanSave=false;
			Meta.CanInsert=false;
			Meta.CanInsertCopy=false;
			Meta.CanCancel=false;
            DataAccess.SetTableForReading(DS.bankdispositionsetup, "config");
			import = new ImportazioneEsitiBancariCarime(this, true, labelOperazione, progressBar1, Meta.Conn);
			Text = "Importazione esiti dei movimenti Banca di Carime";
            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
            if (ultimaEsitazioneDB == DBNull.Value){
                ultimaEsitazioneDB=Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + (CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1) + "' )"
                    , "max(transactiondate)");
            }

			if (ultimaEsitazioneDB is DateTime) {
				txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
			}
		}

		public void MetaData_AfterFill() {
			Text = "Importazione esiti dei movimenti Banca di Carime";
		}

		public void MetaData_AfterClear() {
			Text = "Importazione esiti dei movimenti Banca di Carime";
		}

		bool parseCarimeFile(StreamReader sr) {
            ArrayList altriEsercizi = new ArrayList();
            txtInizioElaborazione.Text = null;
			txtFineElaborazione.Text = null;
			DS.carime.Clear();
			Application.DoEvents();
			Cursor = Cursors.WaitCursor;

			Hashtable ht = new Hashtable();
            // La 1° posizione indica il Tipo Documento= TIPDOC, assume valori:
            //          M = mandato, R = reversale, I = part pend. incasso, P = part. Pend. pagamento
            // La 2° posizione indica il SEGNO.
            // La 3° posizione INDREG indica la regolarizzazione. Se valorizzaro a “R” trattasi di regolarizzazione.
            // Il movimento che agisce sulla bolletta c'ha sempre la R, sia esso Storno, Regolarizzazione, Annullo
            // L'apertura bolletta: non ha R, nella 3° posizione.
            // Chiusura bolletta, storno bolletta e regolarizzazione: ha R nella 3° posizione.
            // Il segno meno va inserito se e solo se Storni.

            ht["001"] = "R+ ";  //Riscossione Reversale
            ht["002"] = "R- ";  //Storno di Reversale

            ht["021"] = "R+R";  //Regolarizzazione Reversale
            ht["022"] = "R-R";  //Annullo regolarizzazione reversale = storno movimento reversale 

            ht["003"] = "I+ ";  //Apertura partita pendente incasso. 
            ht["004"] = "I- ";  //Storno Provvisorio Entrata

            ht["023"] = "R+R";  //Regolarizzazione provvisorio entrata. Verranno Saltati non ci serve il dato della regolarizzazione della bolletta, perchè è un dato che non memorizziamo.
            ht["024"] = "I-R";  //Annullo Regolarizzazione provvisorio entrata= Storno movimenti provvisorio entrata. SALTARE.


            ht["011"] = "M+ ";  //Pagamento Mandato 
            ht["012"] = "M- ";  //Storno Mandati

            ht["015"] = "M+ ";  //Disposizioni Uscita se NSUB > 0, è un Provvisorio di Uscita = 013 se NSUB= 0
            ht["016"] = "M- ";  //Storno Disposizioni Uscita 

            ht["031"] = "M+R";  //Regolarizzazione Mandato
            ht["032"] = "M-R";  //Annullo regolarizzazione Mandato = storno movimento Mandato

            ht["013"] = "P+ ";  //Apertura partita pendente pagamento
            ht["014"] = "P- ";  //Storno Provvisorio Uscita

            ht["033"] = "M+R";  //Regolarizzazione provvisorio Uscita. Verranno Saltati non ci serve il dato della regolarizzazione della bolletta, perchè è un dato che non memorizziamo.
            ht["034"] = "P-R";  //Annullo Regolarizzazione provvisorio Uscita = Storno movimenti provvisorio Uscita. SALTARE

            

			progressBar1.Maximum = (int) sr.BaseStream.Length;
			while (sr.Peek()!=-1) {
				DataRow r = DS.carime.NewRow();
				if (!leggiRigaCarime(sr, ht, r)) {
					return false;
				}
                if (CfgFn.GetNoNullInt32(r["codiceesercizio"]) == CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"))){
                    if (   
                        //r["tipomovimento"].ToString() != "024") && 
                        (r["tipomovimento"].ToString() != "040") 
                        && (r["tipomovimento"].ToString() != "049")
                        && (r["tipomovimento"].ToString() != "042")
                        && (r["tipomovimento"].ToString() != "043")
                        && (r["tipomovimento"].ToString() != "044")
                        //&& (r["tipomovimento"].ToString() != "034")
                        ){
                        DS.carime.Rows.Add(r);
                    }
                }
                else {
                    if (!altriEsercizi.Contains(r["codiceesercizio"]))
                    {
                        altriEsercizi.Add(r["codiceesercizio"]);
                    }
                }
				progressBar1.Value = (int) sr.BaseStream.Position;
				Application.DoEvents();
			}
			sr.Close();
			copia_Carime_IN020304();
			if (!import.completaParsing(dataGrid1, txtInizioElaborazione, txtFineElaborazione)) {
				return false;
			}
            if (altriEsercizi.Count > 0) {
                string messaggio = "Nel file ci sono esitazioni relative ad esercizi diversi.\nDopo aver esitato nel "
                + Meta.GetSys("esercizio")
                + ", se necessario, occorrerà ripetere l'operazione anche per ";
                if (altriEsercizi.Count == 1) {
                    messaggio += "l'esercizio " + altriEsercizi[0];
                }
                if (altriEsercizi.Count > 1) {
                    messaggio += "gli esercizi " + altriEsercizi[0];
                    for (int i = 1; i < altriEsercizi.Count - 1; i++) {
                        messaggio += ", " + altriEsercizi[i];
                    }
                    messaggio += " e " + altriEsercizi[altriEsercizi.Count - 1];
                }
                show(this, messaggio);
            }
            return true;
		}

		private void btnEsita_Click(object sender, System.EventArgs e) {
			Cursor = Cursors.WaitCursor;

			btnEsita.Enabled = !import.esita(true);

			labelOperazione.Text = null;
			progressBar1.Value = 0;
			Cursor = null;

            object ultimaEsitazioneDB = Meta.Conn.DO_READ_VALUE("banktransaction", "(yban = '" + Meta.GetSys("esercizio") + "')"
                , "max(transactiondate)");
			if (ultimaEsitazioneDB is DateTime) {
				txtUltimaEsitazioneDB.Text = ((DateTime)ultimaEsitazioneDB).ToShortDateString();
			}
		}

		private bool leggiRigaCarime(TextReader tr, Hashtable ht, DataRow r) {
			r["codiceistituto"] = import.leggiNumerico(tr, 5);          //CIST
			r["codicedipendenza"] = import.leggiNumerico(tr,5);         //CDIP
            r["codiceente"] = import.leggiNumerico(tr, 7);              //CENT
            r["codiceesercizio"] = import.leggiNumerico(tr, 4);         //CESE
            r["codicedivisaente"] = import.leggiAlfanumerico(tr, 3);    //CDIVENT
            r["abi"] = import.leggiNumerico(tr, 5);                     //CABICCO
            r["cab"] = import.leggiNumerico(tr, 5);                     //CCABCCO
            r["numeroconto"] = import.leggiAlfanumerico(tr, 12);        //NCNTCCO
            r["datamovimento"] = import.leggiDataAMG(tr, 8);            //DMOV

            string tipomovimento = import.leggiAlfanumerico(tr, 3);     //CMOV

            r["numdocumento"] = import.leggiNumerico(tr, 7);        //NDOC
            r["numsub"] = import.leggiNumerico(tr, 7);              //NSUB

            // Il Tipo mov. 15-'Disp. di uscita' equivale al mov. 11-'Pagamento mandato' se NSUB >0
            // Il Tipo mov. 15-'Disp. di uscita' equivale al mov. 13-'Apertura partita pendente pagamento' se NSUB = 0
            int NSUB = CfgFn.GetNoNullInt32(r["numsub"]);
            if (tipomovimento == "015"){
                if(NSUB > 0){
                    r["tipomovimento"] = "011";
                    tipomovimento = "011";
                    }
                else{
                    r["tipomovimento"] = "013";
                    tipomovimento = "013";
                }
            }
            else{
            r["tipomovimento"] = tipomovimento;
            }

         


            r["numricevuta"] = import.leggiNumerico(tr, 7);         //NRIC
            r["numcapitolo"] = import.leggiNumerico(tr, 7);         //NCAP
            r["numarticolo"] = import.leggiNumerico(tr, 3);         //NART
            r["annoresiduo"] = import.leggiNumerico(tr, 2);
            r["codicedivisacliente"] = import.leggiAlfanumerico(tr, 3); //CDIVCLI
            r["importodivisacliente"] = import.leggiDecimale(tr, 15);   //IDIVCLI

            string segno;
            r["importoricevuta"] = import.leggiDecimaleCarime(tr, out segno);//IRIC
            if ((tipomovimento == "002") || (tipomovimento == "012")||(tipomovimento == "016")
                || (tipomovimento == "022") || (tipomovimento == "032")){
                    r["importoricevuta"] = -(decimal)r["importoricevuta"];
            }

            r["segno"] = segno;

            if (tipomovimento == "016")
            {
                if (NSUB > 0)
                {
                    r["tipomovimento"] = "012";
                    tipomovimento = "012";
                }
                else
                {
                    r["tipomovimento"] = "014";
                    tipomovimento = "014";
                    segno = "-";
                    r["segno"] = segno;  
                }
            }
            else
            {
                r["tipomovimento"] = tipomovimento;
            }

        

            // In base alla combinazione dei 3 campi della Hashtable, valorizza TIPDOC, SEGNO e INDREG
            object o = ht[tipomovimento];

            // I tipi 040 e 049, 042,043,044, 050, 051,052 sono NON UTILIZZATO, però posso essere presenti nel file degli esiti, quindi li trascuriamo e NON li aggiungeremo 
            // alla tabella. 
            bool tipoInutilizzato = ((tipomovimento == "023") || (tipomovimento == "024")
                    ||(tipomovimento == "033") || (tipomovimento == "034")
                    || (tipomovimento == "042") || (tipomovimento == "043") || (tipomovimento == "044")
                    || (tipomovimento == "040") || (tipomovimento == "049") 
                    || (tipomovimento == "050")|| (tipomovimento == "051") || (tipomovimento == "052"));


            if ((o == null) && (!tipoInutilizzato)){
                string messaggio = "";
                foreach (object t in ht.Keys){
                    messaggio += ", " + t;
                }
                QueryCreator.ShowError(this, "Tipo di movimento sconosciuto: " + tipomovimento, "I tipi di movimento accettati sono:\n" + messaggio.Substring(2));
            }

            if (!tipoInutilizzato){
                string flag = (string)o;
                r["tipdoc"] = flag[0];
                r["segno"] = flag[1];
                r["indreg"] = flag[2];
                bool b1 = segno.Equals(r["segno"]);
                bool b2 = ( (tipomovimento == "002") || (tipomovimento == "012")|| (tipomovimento == "016")
                            || (tipomovimento == "022")|| (tipomovimento == "032"));
                if (b1 == b2){
                    QueryCreator.ShowError(this, "Errore nel segno di un importo\n" + tipomovimento + ": " + flag, "Errore durante la lettura del file");
                    return false;
                }
            }

           

            r["codiceesecuzione"] = import.leggiNumerico(tr, 3);            //CECZ
            r["codicebolli"] = import.leggiNumerico(tr, 3);                 //CBLL
            r["importibolli"] = import.leggiDecimale(tr, 9);                //IBLL
            r["codicespese"] = import.leggiNumerico(tr, 3);                 //CSPE
            r["importospese"] = import.leggiDecimale(tr, 9);                //ISPE
            r["datavaluta"] = import.leggiDataAMG(tr, 8);                   //DVAL
            r["numdocrif"] = import.leggiNumerico(tr,7 );                   //NDOCRIF
            r["numsubrif"] = import.leggiNumerico(tr, 3);                   //NSUBRIF
            r["abicliente"] = import.leggiNumerico(tr, 5);                  //CABICLI
            r["cabcliente"] = import.leggiNumerico(tr, 5);                  //CCABCLI
            r["descrizionecliente"] = import.leggiAlfanumerico(tr, 30);       //ZANACLI
            r["codicecausale"] = import.leggiNumerico(tr, 3);               //CCAU
            r["causale1"] = import.leggiAlfanumerico(tr, 30);               //ZCAU1
            r["causale2"] = import.leggiAlfanumerico(tr, 30);               //ZCAU2 
            r["causale3"] = import.leggiAlfanumerico(tr, 30);               //ZCAU3
            r["codicetipoimputazione"] = import.leggiAlfanumerico(tr, 3);       //CTIPIPU

            r["imputazionefruttifera"] = import.leggiNumerico(tr, 1);       //SFRUIPU
            r["imputazioneinfruttifera"] = import.leggiNumerico(tr, 1);     //SIFRIPU
            r["imputazionevincolata"] = import.leggiNumerico(tr, 1);        //SVINIPU
            r["imputazionedelegazioni"] = import.leggiNumerico(tr, 1);      //SDELIPU
            r["imputazionegiornaliera"] = import.leggiNumerico(tr, 1);      //SGIOIPU
            r["destfruttiferainfruttifera"] = import.leggiNumerico(tr, 1);  //S001IPU
            r["indicatoreadisposizione"] = import.leggiNumerico(tr, 1);     //S002IPU
            r["entratauscita"] = import.leggiAlfanumerico(tr, 1);           //SEOU
            r["codicedivisaesercizio"] = import.leggiAlfanumerico(tr, 3);   //CDIVESE
            r["importodivisaente"] = import.leggiDecimale(tr, 17);          //IDIVENT
            r["space01"] = import.leggiAlfanumerico(tr, 10);                //CCOD1
            r["space02"] = import.leggiAlfanumerico(tr, 10);                //CCOD2
            r["space03"] = import.leggiAlfanumerico(tr, 10);                //CCOD3
            r["codiceresiduo"] = import.leggiNumerico(tr, 4);               //CRES
            r["numerosubcaricati"] = import.leggiNumerico(tr, 7);           //NSUBCAR
            r["numerosottoconto"] = import.leggiAlfanumerico(tr, 7);            //NCNT
            r["cf"] = import.leggiAlfanumerico(tr, 16);                     //CFISCLI
            r["codicefornitore"] = import.leggiNumerico(tr, 7);             //CFOR
            r["numerocro"] = import.leggiAlfanumerico(tr, 16);              //NCRO
            r["numeroassegnoda"] = import.leggiAlfanumerico(tr, 16);        //NASSDA
            r["numeroassegnoa"] = import.leggiAlfanumerico(tr, 16);         // NASSA
            r["descrizionecausaleaggiuntiva"] = import.leggiAlfanumerico(tr, 90);  //ZCAU4
            r["codicebeneficiario"] = import.leggiAlfanumerico(tr, 16);     //CBEN
            r["filler"] = import.leggiAlfanumerico(tr, 242);                //FILLER
			return import.vaiACapo(tr);
		}

		private void copia_Carime_IN020304() {
            //Quando viene regolarizzato un mandato, ossia in presenza del TipoMov 031 vi è anche il TipoMov 033. Idem per 021 e 023, per le reversali.
            //Per quanto riguarda gli annullamenti di regolarizzazioni, la situazione è speculare.
            //Quando viene annullata la regolarizzazione di un mandato, ossia in presenza del TipoMov 032 vi è anche il TipoMov 034. 
            // Idem per 022 e 024, per le reversali.
            // Nel 031 abbiamo l'info del num.doc., mentre nel 033 abbiamo l'info del num. bolletta. Il legame tra i due è dato da NRIC.
            // Quindi, facciamo un ciclo preliminare per elaborare  i record 023, 024, 033, 034 e memorizzare in quattro hashtable NRIC. 
            // Queste verranno interrogate dopo
            
            Hashtable ht023 = new Hashtable();
            Hashtable ht033 = new Hashtable();
            Hashtable ht024 = new Hashtable();
            Hashtable ht034 = new Hashtable();
            string filtroRec023Rec033 = QHC.AppOr(QHC.CmpEq("tipomovimento", "023"), QHC.CmpEq("tipomovimento", "033"), QHC.CmpEq("tipomovimento", "024"),
               QHC.CmpEq("tipomovimento", "034"));
 
            foreach (DataRow s in DS.carime.Select(filtroRec023Rec033)){
                
                if (s["tipomovimento"].ToString() == "023"){
                    object NRIC023 = s["numricevuta"];
                    ht023[NRIC023] = s["numdocumento"];
                }
                if (s["tipomovimento"].ToString() == "033"){
                    object NRIC033 = s["numricevuta"];
                    ht033[NRIC033] = s["numdocumento"];
                }
                if (s["tipomovimento"].ToString() == "024")
                {
                    object NRIC0024 = s["numricevuta"];
                    ht024[NRIC0024] = s["numdocumento"];
                }
                if (s["tipomovimento"].ToString() == "034")
                {
                    object NRIC0034 = s["numricevuta"];
                    ht034[NRIC0034] = s["numdocumento"];
                }
               
                ////// new
                ////if (s["tipomovimento"].ToString() == "033"){
                ////    object NBolletta = s["numdocumento"];
                ////    HT033_[NBolletta] = s["numricevuta"];
                ////}
                ////if (s["tipomovimento"].ToString() == "031"){
                ////    object NRIC = s["numricevuta"];
                ////    HT031_[NBolletta] = s["beneficiario"];
                ////}
            }
 
			import.DS.flussobanca.Clear();
			foreach (DataRow s in DS.carime.Rows) {
				string tipoMov = s["tipomovimento"].ToString();
				DataRow r = import.DS.flussobanca.NewRow();
                r["CODEN"] = s["codiceente"]; 
                r["ESERC"] = s["codiceesercizio"];
				r["TIPDOC"] = s["tipdoc"];

                // Per i TipoMov. 003, 013, 004 e 014 Il numero documento rappresenta il numero del Provvisorio, ossia il numero della bolletta.
                if ((s["tipomovimento"].ToString() == "003") || (s["tipomovimento"].ToString() == "013")|| 
                    (s["tipomovimento"].ToString() == "004") || (s["tipomovimento"].ToString() == "014")) {
                        r["NUMDOC"] = DBNull.Value;
                        r["NUMQUI"] = s["numdocumento"];
                }
                /*
                // Il TipoMov 016 è lo storno della disposizione di Uscita. 
                if (s["tipomovimento"].ToString() == "016") {
                        if(CfgFn.GetNoNullInt32(s["numsub"])>0){
                            // NSUB >0 : identifica lo storno di un mandato
                                r["NUMDOC"] = s["numdocumento"];
                                r["NUMQUI"] = DBNull.Value;
                            }
                        else {
                            // NSUB = 0 : identifica lo storno di un provvisorio
                            r["NUMDOC"] = DBNull.Value;
                            r["NUMQUI"] = s["numdocumento"];
                            }
                    }
                */
                if ((s["tipomovimento"].ToString() == "001") || (s["tipomovimento"].ToString() == "002") || 
                    (s["tipomovimento"].ToString() == "011") || (s["tipomovimento"].ToString() == "012")){
                        r["NUMDOC"] = s["numdocumento"];
                        r["NUMQUI"] = DBNull.Value;
                }

                if (s["tipomovimento"].ToString() == "021"){
                    object NRIC = s["numricevuta"];
                    r["NUMDOC"] = s["numdocumento"];
                    if (ht023[NRIC] != null) 
                        r["NUMQUI"] = ht023[NRIC];
                    else
                     if (ht024[NRIC] != null)
                         r["NUMQUI"] = ht024[NRIC];
                    else
                        r["NUMQUI"] = DBNull.Value;
                }

                // nell'annullo di regolarizzazione di reversale si deve valorizzare il numero di provvisorio 
                // prendendolo dalla riga 023 (regolarizzazione provvisorio entrata), solo che questa riga potrebbe essere assente
                // si potrebbe leggere il numero provvisorio anche dalla riga 024 con lo stesso numero ricevuta
                if (s["tipomovimento"].ToString() == "022")
                {
                    object NRIC = s["numricevuta"];
                    r["NUMDOC"] = s["numdocumento"];

                    if (ht023[NRIC] != null)
                        r["NUMQUI"] = ht023[NRIC];
                    else
                        if (ht024[NRIC] != null)
                        {
                            r["NUMQUI"] = ht024[NRIC];
                        }

                        else
                            r["NUMQUI"] = DBNull.Value;
                }

                if (s["tipomovimento"].ToString() == "031"){
                    object NRIC = s["numricevuta"];

                    r["NUMDOC"] = s["numdocumento"];
                    if (ht033[NRIC] != null) 
                        r["NUMQUI"] = ht033[NRIC];
                    else if (ht034[NRIC]!= null)
                        r["NUMQUI"] = ht034[NRIC];
                    else
                        r["NUMQUI"] = DBNull.Value;
                }

                if (s["tipomovimento"].ToString() == "032")
                {
                    object NRIC = s["numricevuta"];

                    r["NUMDOC"] = s["numdocumento"];
                    if (ht033[NRIC] != null)
                        r["NUMQUI"] = ht033[NRIC];
                    else if (ht034[NRIC] != null)
                        r["NUMQUI"] = ht034[NRIC];
                    else
                        r["NUMQUI"] = DBNull.Value;
                }


                r["PRODOC"] = s["numsub"]; 
                r["CAPBIL"] = s["numcapitolo"]; 
				r["ARTBIL"] = s["numarticolo"]; 
                r["IMPDOC"] = s["importoricevuta"];
				r["SEGNO"] = s["segno"]; 
                r["DTELAB"] = s["datamovimento"];// Da rivedere (?)
                r["DTPAG"] = s["datamovimento"]; 
				r["DVAL"] = s["datavaluta"]; 
				r["INDREG"] = s["indreg"];
                r["DVALBE"] = DBNull.Value; // s["datavalutabeneficiario"];// Da rivedere (?)
                r["IBOLLI"] = s["importibolli"];   
                r["INDBOL"] = s["codicebolli"];
  				r["ISPE"] = s["importospese"];
                r["INDSPE"] = s["codicespese"];
                r["TPAGTS"] = s["codiceesecuzione"];// Da rivedere 
                r["CODABI"] = s["abicliente"]; 
                r["CODCAB"] = s["cabcliente"];
                //r["CONTO"] = s["conto"];    // DA RIVEDERE : NEL TRACCIATO MANCA
                //r["CIN"] = s["cin"];// DA RIVEDERE : NEL TRACCIATO MANCA
                r["NCNT"] = s["numerosottoconto"];
                r["ANABE"] = s["descrizionecliente"]; 
				r["CFISC"] = s["cf"];
                r["CAUSALE"] = s["codicecausale"];
				r["FILLER"] = s["tipomovimento"];
                r["CAUSALE"] = s["causale1"].ToString() + s["causale2"].ToString() + s["causale3"].ToString();
                if ((s["tipomovimento"].ToString() == "003") || (s["tipomovimento"].ToString() == "013"))
                    r["CAUSALE"] = "(Imputaz."+ s["codicetipoimputazione"].ToString()+")"+ r["CAUSALE"].ToString();

                // I TipiRec 023 e 033 e anche 024 - 034non li passiamo al motore degli esiti, sono serviti solo per valorizzare il num.bolletta di Rec. 021 e 031
                if ((s["tipomovimento"].ToString() != "023") && (s["tipomovimento"].ToString() != "033") &&
                    (s["tipomovimento"].ToString() != "024") && (s["tipomovimento"].ToString() != "034"))
                {
				    import.DS.flussobanca.Rows.Add(r);
                }
			}
			DS.carime.Clear();
		}

		private void btnApriCarime_Click(object sender, System.EventArgs e) {
            StreamReader sr = import.getStreamReader(802, _openFileDialog1, txtFile);
			if (sr == null) {
				return;
			}
			labelOperazione.Text = "Lettura file";

			btnEsita.Enabled = parseCarimeFile(sr);

			labelOperazione.Text = null;
			progressBar1.Value = 0;
			Cursor = null;
		}

		private void btnChiudi_Click(object sender, System.EventArgs e) {
			this.Dispose();
		}
		
	}

    public class ImportazioneEsitiBancariCarime : ImportazioneEsitiBancari {
        DataAccess Conn;
        public ImportazioneEsitiBancariCarime(Form form, bool chiusuraAutomaticaPartitePendenti,
            Label labelOperazione, ProgressBar progressBar1, DataAccess Conn)
            :
            base(form, chiusuraAutomaticaPartitePendenti, labelOperazione, progressBar1) {
            this.Conn = Conn;
        }

        public override BANCA getBanca() {
            return BANCA.CARIME;
        }

        public override DataTable getInfoMandati(object esercDocPagamento, object numDocPagamento) {
            string query = "SELECT s.ymov as ypay, sl.kpay, p.npay, sl.idpay, PRODOC = sl.idpay, NUMQUI=sl.nbill,"
                + "TPAGTS=m.methodbankcode, "//codicemodalitaCass
                + "sCODABI=sl.idbank, "//codiceabi
                + "sCODCAB=sl.idcab, "//codicecab
                + "CONTO=REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(ISNULL(sl.cc,''),',',''),'.',''),'_',''),'-',''),'*',''),'+',''),'/',''),':',''),';',''), "//contocorrente
                + "CIN=ISNULL(sl.cin,''), "//cin
                + "ANABE=ISNULL(c.title,''), "//denominazioneben
                + "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "//codicefiscaleben
                + "CAUSALE = ISNULL(s.description,'') "//descpagamento
                + "FROM expense s "
                + "JOIN expenselast sl on s.idexp=sl.idexp "
                + " JOIN payment p ON p.kpay = sl.kpay "
                + "JOIN paymethod m ON (sl.idpaymethod = m.idpaymethod) "
                + "JOIN registry c ON (c.idreg = s.idreg) "
                + "JOIN registryclass ctc ON (ctc.idregistryclass = c.idregistryclass) "
                + "WHERE (p.ypay = " + esercDocPagamento
                + ") and (p.npay = " + numDocPagamento
                + ") AND (sl.idpay is not null)";
            string errMsg;
            DataTable tInfo = Conn.SQLRunner(query, -1, out errMsg);
            if (tInfo == null) {
                QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n" + query, errMsg);
            }
            tInfo.Columns.Add("CODABI", typeof(string));
            tInfo.Columns.Add("CODCAB", typeof(string));
            foreach (DataRow r in tInfo.Rows) {
                r["CODABI"] = r["sCODABI"];
                r["CODCAB"] = r["sCODCAB"];
            }
            return tInfo;
        }

        public override DataTable getInfoReversali(object esercDocIncasso, object numDocIncasso) {
            string query = "SELECT e.ymov as ypro, el.kpro, p.npro, el.idpro, PRODOC = el.idpro, TPAGTS='', CODABI='', CODCAB='', CONTO='', CIN='', NUMQUI=el.nbill,"
                + "ANABE=ISNULL(c.title,''), "
                + "CFISC=CASE WHEN ctc.flaghuman = 'S' AND cf IS NOT NULL THEN c.cf WHEN ctc.flaghuman = 'S' AND c.cf IS NULL THEN REPLICATE('9',16) ELSE '' END, "
                + "CAUSALE=ISNULL(e.description,'') "
                + "FROM income e "
                + "JOIN incomelast el on e.idinc=el.idinc "
                + " JOIN proceeds p ON p.kpro = el.kpro "
                + "JOIN registry c ON c.idreg = e.idreg "
                + "JOIN registryclass ctc ON ctc.idregistryclass = c.idregistryclass "
                + "WHERE p.ypro = " + esercDocIncasso
                + " AND p.npro = " + numDocIncasso
                + " AND el.idpro is not null";
            string errMsg;
            DataTable tInfo = Conn.SQLRunner(query, -1, out errMsg);
            if (tInfo == null) {
                QueryCreator.ShowError(form, "Errore durante l'esecuzione della query:\r\n" + query, errMsg);
            }
            return tInfo;
        }
    }
}
