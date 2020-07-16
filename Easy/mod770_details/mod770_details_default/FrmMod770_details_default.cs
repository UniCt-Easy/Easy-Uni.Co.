/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.IO;
using System.Text;
using funzioni_configurazione;

namespace mod770_details_default
{
	/// <summary>
	/// Summary description for FrmMod770_details_default.
	/// </summary>
	public class FrmMod770_details_default : System.Windows.Forms.Form
	{
        DataTable tMod770;
        private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox txtPercorso;
		private System.Windows.Forms.Button btnSalvaIn;
		public mod770_details_default.vistaForm DS;
		private MetaData Meta;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private Button buttonGenera770;
        private GroupBox groupBox4;
        private Button buttonLegendaI;
        private Button buttonRecordI;
        private GroupBox groupBox5;
        private Button btnDatiB;
        private Button btnLegendaB;
        private Button btnDatiA;
        private Button btnLegendaA;
        private GroupBox grpVerifiche;
        private DataGrid dgrVerifiche;
        System.EventHandler[] AllList = new System.EventHandler[6];
        private GroupBox groupBox1;
        private Button btnRiepilogoRitenute;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public FrmMod770_details_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMod770_details_default));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.btnSalvaIn = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.DS = new mod770_details_default.vistaForm();
            this.buttonGenera770 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonLegendaI = new System.Windows.Forms.Button();
            this.buttonRecordI = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnDatiB = new System.Windows.Forms.Button();
            this.btnLegendaB = new System.Windows.Forms.Button();
            this.btnDatiA = new System.Windows.Forms.Button();
            this.btnLegendaA = new System.Windows.Forms.Button();
            this.grpVerifiche = new System.Windows.Forms.GroupBox();
            this.dgrVerifiche = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRiepilogoRitenute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.grpVerifiche.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrVerifiche)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(16, 92);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(868, 73);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            this.richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(146, 66);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(738, 20);
            this.txtPercorso.TabIndex = 6;
            // 
            // btnSalvaIn
            // 
            this.btnSalvaIn.AutoSize = true;
            this.btnSalvaIn.Location = new System.Drawing.Point(16, 64);
            this.btnSalvaIn.Name = "btnSalvaIn";
            this.btnSalvaIn.Size = new System.Drawing.Size(124, 23);
            this.btnSalvaIn.TabIndex = 5;
            this.btnSalvaIn.Text = "Percorso in cui salvare";
            this.btnSalvaIn.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "77s";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // buttonGenera770
            // 
            this.buttonGenera770.Location = new System.Drawing.Point(15, 12);
            this.buttonGenera770.Name = "buttonGenera770";
            this.buttonGenera770.Size = new System.Drawing.Size(212, 38);
            this.buttonGenera770.TabIndex = 15;
            this.buttonGenera770.Text = "Genera modello 770 (record I)";
            this.buttonGenera770.UseVisualStyleBackColor = true;
            this.buttonGenera770.Click += new System.EventHandler(this.buttonGenera770_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonLegendaI);
            this.groupBox4.Controls.Add(this.buttonRecordI);
            this.groupBox4.Location = new System.Drawing.Point(16, 221);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(682, 51);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "RECORD DI TIPO \"I\": Procedure di pignoramento presso terzi e lavoratori autonomi " +
    "stranieri privi di codice fiscale italiano";
            // 
            // buttonLegendaI
            // 
            this.buttonLegendaI.Location = new System.Drawing.Point(81, 20);
            this.buttonLegendaI.Name = "buttonLegendaI";
            this.buttonLegendaI.Size = new System.Drawing.Size(84, 23);
            this.buttonLegendaI.TabIndex = 11;
            this.buttonLegendaI.Text = "Legenda \"I\"";
            this.buttonLegendaI.UseVisualStyleBackColor = true;
            this.buttonLegendaI.Click += new System.EventHandler(this.buttonLegendaI_Click);
            // 
            // buttonRecordI
            // 
            this.buttonRecordI.Location = new System.Drawing.Point(175, 20);
            this.buttonRecordI.Name = "buttonRecordI";
            this.buttonRecordI.Size = new System.Drawing.Size(84, 23);
            this.buttonRecordI.TabIndex = 10;
            this.buttonRecordI.Text = "Dati \"I\"";
            this.buttonRecordI.UseVisualStyleBackColor = true;
            this.buttonRecordI.Click += new System.EventHandler(this.buttonRecordI_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnDatiB);
            this.groupBox5.Controls.Add(this.btnLegendaB);
            this.groupBox5.Controls.Add(this.btnDatiA);
            this.groupBox5.Controls.Add(this.btnLegendaA);
            this.groupBox5.Location = new System.Drawing.Point(16, 171);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(420, 43);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "RECORD DI TIPO A  e di tipo B:";
            // 
            // btnDatiB
            // 
            this.btnDatiB.Location = new System.Drawing.Point(319, 14);
            this.btnDatiB.Name = "btnDatiB";
            this.btnDatiB.Size = new System.Drawing.Size(84, 23);
            this.btnDatiB.TabIndex = 15;
            this.btnDatiB.Text = "Dati \"B\"";
            this.btnDatiB.UseVisualStyleBackColor = true;
            this.btnDatiB.Click += new System.EventHandler(this.btnDatiB_Click);
            // 
            // btnLegendaB
            // 
            this.btnLegendaB.Location = new System.Drawing.Point(229, 14);
            this.btnLegendaB.Name = "btnLegendaB";
            this.btnLegendaB.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaB.TabIndex = 14;
            this.btnLegendaB.Text = "Legenda \"B\"";
            this.btnLegendaB.UseVisualStyleBackColor = true;
            this.btnLegendaB.Click += new System.EventHandler(this.btnLegendaB_Click);
            // 
            // btnDatiA
            // 
            this.btnDatiA.Location = new System.Drawing.Point(96, 14);
            this.btnDatiA.Name = "btnDatiA";
            this.btnDatiA.Size = new System.Drawing.Size(84, 23);
            this.btnDatiA.TabIndex = 13;
            this.btnDatiA.Text = "Dati \"A\"";
            this.btnDatiA.UseVisualStyleBackColor = true;
            this.btnDatiA.Click += new System.EventHandler(this.btnDatiA_Click);
            // 
            // btnLegendaA
            // 
            this.btnLegendaA.Location = new System.Drawing.Point(6, 14);
            this.btnLegendaA.Name = "btnLegendaA";
            this.btnLegendaA.Size = new System.Drawing.Size(84, 23);
            this.btnLegendaA.TabIndex = 12;
            this.btnLegendaA.Text = "Legenda \"A\"";
            this.btnLegendaA.UseVisualStyleBackColor = true;
            this.btnLegendaA.Click += new System.EventHandler(this.btnLegendaA_Click);
            // 
            // grpVerifiche
            // 
            this.grpVerifiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVerifiche.Controls.Add(this.dgrVerifiche);
            this.grpVerifiche.Location = new System.Drawing.Point(16, 278);
            this.grpVerifiche.Name = "grpVerifiche";
            this.grpVerifiche.Size = new System.Drawing.Size(871, 117);
            this.grpVerifiche.TabIndex = 19;
            this.grpVerifiche.TabStop = false;
            // 
            // dgrVerifiche
            // 
            this.dgrVerifiche.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrVerifiche.DataMember = "";
            this.dgrVerifiche.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrVerifiche.Location = new System.Drawing.Point(6, 19);
            this.dgrVerifiche.Name = "dgrVerifiche";
            this.dgrVerifiche.Size = new System.Drawing.Size(859, 92);
            this.dgrVerifiche.TabIndex = 3;
            this.dgrVerifiche.Tag = " ";
            this.dgrVerifiche.DoubleClick += new System.EventHandler(this.dgrVerifiche_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRiepilogoRitenute);
            this.groupBox1.Location = new System.Drawing.Point(443, 171);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(420, 43);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Riepilogo Ritenute di tipo Fiscale e Arretrati";
            // 
            // btnRiepilogoRitenute
            // 
            this.btnRiepilogoRitenute.Location = new System.Drawing.Point(67, 14);
            this.btnRiepilogoRitenute.Name = "btnRiepilogoRitenute";
            this.btnRiepilogoRitenute.Size = new System.Drawing.Size(275, 23);
            this.btnRiepilogoRitenute.TabIndex = 15;
            this.btnRiepilogoRitenute.Text = "Riepilogo Ritenute di tipo Fiscale e Arretrati";
            this.btnRiepilogoRitenute.UseVisualStyleBackColor = true;
            this.btnRiepilogoRitenute.Click += new System.EventHandler(this.btnRiepilogoRitenute_Click);
            // 
            // FrmMod770_details_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(892, 406);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpVerifiche);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.buttonGenera770);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.txtPercorso);
            this.Controls.Add(this.btnSalvaIn);
            this.Name = "FrmMod770_details_default";
            this.Text = "FrmMod770_details_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.grpVerifiche.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrVerifiche)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


        QueryHelper QHS;
        CQueryHelper QHC;
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
			int esercizio = (int)Meta.GetSys("esercizio");
			GetData.CacheTable(DS.mod770_details, "ayear="+esercizio, "colorder", false);

			Meta.CanSave = false;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.SearchEnabled = false;

            string link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni/";
			switch (esercizio) {
                case 2017: link = "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/7702017unificato/Modello+7702017unificato/"; break; 
                case 2016: link = "http://www.agenziaentrate.gov.it/wps/content/nsilib/nsi/home/cosadevifare/dichiarare/dichiarazionisostitutiimposta/770+2016+semplificato/modello+770+2016+semplificato/indice+modello+770+2016+semplificato"; break; 
                case 2015: link = "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/770+2015+Semplificato/Scheda+770+2015+Semplificato/"; break;        
                case 2014: link = "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/770S2014/Modello+770+2014+Semp/"; break;        
                case 2013: link = "http://www.agenziaentrate.gov.it/wps/content/nsilib/nsi/home/cosadevifare/dichiarare/dichiarazionisostitutiimposta/770s2013/compinvio+770+semplificato+2013/swcompilazione+770+semplificato+2013"; break;        
                case 2012: link = "http://www.agenziaentrate.gov.it/wps/content/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioniSostitutiImposta/770S2012/SchedaInfo7702012Semp/"; break;        
                case 2011: link = "http://www.agenziaentrate.gov.it/wps/portal/entrate/cosa_devi_fare/Nsilib/Nsi/Home/CosaDeviFare/Dichiarare/DichiarazioneSostitutiImposta/770S2011/Modello+770+2011+Semp/"; break;        
                case 2010: link = "http://www.agenziaentrate.it/wps/wcm/connect/Nsilib/Nsi/Strumenti/Software/Dichiarazioni+2010/Modello+770+Semplificato+e+Ordinario+2010/770+Semplificato/"; break;
                //case 2010: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni+2010/770+Semplificato+2010/"; break;
                case 2009: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni+2009/770+Semplificato+2009/"; break;
                case 2008: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni+2008/770+Semplificato+2008/"; break;
                case 2007: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/Strumenti/Software/Dichiarazioni/"; break;
                case 2006: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/SoftwareAP/2006/Dichiarazioni/770+semplificato/"; break;
				case 2005: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/SoftwareAP/2005/Altri+modelli+di+dichiarazione/SW+770+semplificato/"; break;
				case 2004: link = "http://www.agenziaentrate.it/ilwwcm/connect/Nsi/SoftwareAP/2004/770/770+semplificato/"; break;
				case 2003: link = "http://www1.agenziaentrate.it/software/2003/altri/770/semplificato/index.htm"; break;
				case 2002: link = "http://www1.agenziaentrate.it/software/2002/dichiarazione/770/770s_software.htm"; break;
				case 2001: link = "http://www1.agenziaentrate.it/modulistica/dichiarazione/2001/adssoft00.htm"; break;
				case 2000: link = "http://www1.agenziaentrate.it/modulistica/dichiarazione/2000/adssoft00.htm"; break;
			}

			this.richTextBox1.Text = "La dichiarazione 770 generata può essere importata, visualizzata, corretta, stampata ed inviata telematicamente tramite il \"Software di compilazione modello 770 semplificato "
				+ esercizio
				+ "\" dell'Agenzia delle Entrate.\nTale software si può scaricare gratuitamente a questo indirizzo:\n"
				+ link
				+ "\nUna volta installato ed avviato tale software, usare la voce di menù: 'File / Importa "
				+ esercizio
				+ "'";
            InitializeAllList();

            //buttonGenera770.Visible = false;
            //btnGenera770.Visible = false;
            //grpControlli.Visible = false;
		}
		
		private string vuoto(string formato, int lunghezza) {
			switch (formato) {
                case "AN"://P-N
				case "CF"://P-N
				case "PR"://P-N
                case "VP":// P
                case "VN"://P-N
					return "".PadLeft(lunghezza);
                case "DA":
                case "DT"://P-N
				case "CN"://P-N
				case "PI"://P-N
				case "NU"://P-N
                case "N3"://P-N
				case "N5"://P-N
				case "CB"://P-N
					return "".PadLeft(lunghezza, '0');
			}
            MessageBox.Show(this, "Impossibile creare la stringa vuota per il formato '" + formato+"'");
			return "".PadLeft(lunghezza);
		}

		private string formattaCampoPosizionale(DataRow r, int lunghezza) {
            string filtro = "(frame='" + r["quadro"] + "') and (colnumber='" + r["colonna"] + "')";
            DataRow rFormato = DS.mod770_details.Select(filtro)[0];
            Object valore;
			switch (rFormato["format"].ToString()) {
				case "AN"://P-N
				case "CF"://P-N
				case "PR"://P-N
					string s = getString(r, out valore).ToUpper();
					if (s.Length>=lunghezza) {
						return s.Substring(0, lunghezza);
					}
					return s.PadRight(lunghezza);
				case "DT"://P-N
					DateTime dt = getDateTime(r, out valore);
					return dt.ToString("ddMMyyyy");
				case "CN"://P-N
				case "PI"://P-N
				case "NU"://P-N
				case "CB"://P-N
					string t = getInt(r, out valore).ToString();
					return t.PadLeft(lunghezza, '0');
                case "N1":
                    return getInt(r, out valore).ToString().PadLeft(1, '0');
                case "N5":
					return getInt(r, out valore).ToString().PadLeft(5,'0');
                case "N3":
                    return getInt(r, out valore).ToString().PadLeft(3, '0');
			}
			MessageBox.Show(this, "Formato Errato " + rFormato["format"] + " nella Colonna" + r["colonna"]+" del quadro "+r["quadro"]);
			return null;
		}

		/// <summary>
		/// Con riferimento ai campi non posizionali, nel caso in cui la lunghezza del dato da inserire
		///	dovesse eccedere i 16 caratteri disponibili, dovrà essere inserito un ulteriore elemento con un
		/// identico campo-codice e con un campo-valore il cui primo carattere dovrà essere impostato
		/// con il simbolo “+”, mentre i successivi quindici potranno essere utilizzati per la
		/// continuazione del dato da inserire.
		/// </summary>
		/// <param name="campoCodice"></param>
		/// <param name="s"></param>
		/// <returns></returns>
		private string[] stringaASinistra(string campoCodice, string s) {
			s = s.ToUpper().Trim();
			if (s.Length <= 16) return new string[] {campoCodice + s.PadRight(16)};
			string[] result = new string[(s.Length + 13) / 15];
			result[0] = campoCodice + s.Substring(0, 16);
			for (int i=1; i<result.Length-1; i++) {
				result[i] = campoCodice + "+" + s.Substring(1 + i*15, 15);
			}
			result[result.Length-1] = campoCodice + "+" + s.Substring(15*result.Length - 14).PadRight(15);
			return result;
		}

        private Type getTipo(DataRow rFormato) {
            switch (rFormato["format"].ToString()) {
                case "AN"://P-N
                case "CF"://P-N
                case "PR"://P-N
                case "N10"://N
                case "CB12"://N
                    return typeof(string);
                case "CN"://P-N
                case "PI"://P-N
                case "DA"://N
                case "NP"://N
                case "NU"://P-N
                case "PC"://N
                case "QU"://N
                case "CB"://P-N
                case "N1"://N
                case "N2"://N
                case "N3"://N
                case "N4"://N
                case "N5"://N
                    return typeof(int);
                case "DT"://P-N
                case "DN"://N
                case "D4"://N
                case "D6"://N
                    return typeof(DateTime);
                case "VP"://P
                case "VN"://P-N
                    return typeof(decimal);
            }
            MessageBox.Show("Formato sconosciuto nel quadro " + rFormato["frame"] + " colonna " + rFormato["colnumber"]);
            return null;
        }

		private string getString(DataRow r, out object valore) {
            if (r["intero"] != DBNull.Value) {
                MessageBox.Show(this,"Intero e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                MessageBox.Show(this,"Data e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value)
            {
                MessageBox.Show(this, "Decimale e non stringa nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }

            return  (string) (valore = aggiustaStringa(r["stringa"].ToString()));
        }

        private int getInt(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                MessageBox.Show(this,"Stringa e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value) {
                MessageBox.Show(this,"Data e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value)
            {
                MessageBox.Show(this, "Decimale e non intero nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (int) (valore = r["intero"]);
        }

        private decimal getDecimal(DataRow r, out object valore)
        {
            if (r["stringa"] != DBNull.Value)
            {
                MessageBox.Show(this, "Stringa e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["data"] != DBNull.Value)
            {
                MessageBox.Show(this, "Data e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["intero"] != DBNull.Value)
            {
                MessageBox.Show(this, "Intero e non decimal nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (decimal)(valore = r["decimale"]);
        }

        private DateTime getDateTime(DataRow r, out object valore) {
            if (r["stringa"] != DBNull.Value) {
                MessageBox.Show(this,"Stringa e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["intero"] != DBNull.Value) {
                MessageBox.Show(this,"Intero e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            if (r["decimale"] != DBNull.Value)
            {
                MessageBox.Show(this, "Decimale e non data nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
            }
            return (DateTime) (valore = r["data"]);
		}

		private string[] formattaCampoNonPosizionale(DataRow r, out object valore) {
            string campoCodice = r["quadro"] + r["riga"].ToString().PadLeft(3, '0') + r["colonna"];
            if (r["quadro"].ToString().Substring(0,2) == "SY") campoCodice = r["quadro"].ToString() + r["colonna"].ToString();
            if (r["quadro"].ToString() == "SS")
                return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(16) };
            string filtro = "(frame='" + r["quadro"] + "') and (colnumber='" + r["colonna"] + "')";
            DataRow[] rFormato = DS.mod770_details.Select(filtro);
			switch (rFormato[0]["format"].ToString()) {
				case "AN"://P-N
				case "CF"://P-N
				case "PR"://P-N
					return stringaASinistra(campoCodice, getString(r, out valore));
				case "CN"://P-N
                    return new string[] { campoCodice + getInt(r, out valore).ToString().PadLeft(11, '0')};
				case "PI"://P-N
					return stringaASinistra(campoCodice, getInt(r, out valore).ToString());
				case "DA"://N
				case "NP"://N
				case "NU"://P-N
				case "PC"://N
				case "QU"://N
					return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(16)};
				case "CB"://P-N
				case "N1"://N
					return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(1,'0').PadLeft(16)};
				case "N2"://N
					return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(2,'0').PadLeft(16)};
				case "N3"://N
                    return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(3, '0').PadLeft(16) };
				case "N5"://N
                    return new string[] {campoCodice + getInt(r, out valore).ToString().PadLeft(5, '0').PadLeft(16) };
				case "N10"://N
                    return new string[] {campoCodice + getString(r, out valore).PadLeft(10, '0').PadLeft(16) };
                case "N11"://N
                    return new string[] { campoCodice + getString(r, out valore).PadLeft(11, '0').PadLeft(16) };
				case "CB12"://N
                    return new string[] {campoCodice + getString(r, out valore).PadLeft(12, '0').PadLeft(16) };
				case "DT"://P-N
				case "DN"://N
					return new string[] {campoCodice + getDateTime(r, out valore).ToString("ddMMyyyy").PadLeft(16)};
				case "D4"://N
                    return new string[] {campoCodice + getDateTime(r, out valore).ToString("ddMM").PadLeft(16) };
				case "D6"://N
                    return new string[] {campoCodice + getDateTime(r, out valore).ToString("MMyyyy").PadLeft(16) };
                case "VP"://N
                case "VN"://P-N
                    return new string[] { campoCodice + getDecimal(r, out valore).ToString().PadLeft(16) };
                default: MessageBox.Show("FCNP: Formato sconosciuto nel quadro " + r["quadro"] + " colonna " + r["colonna"]);
                    valore = null;
                    return null;
			}
		}

		private string getHeader(DataTable t, string quadro, int progressivoComunicazione) {
			StringBuilder sb = new StringBuilder();
			string filtro = "(frame='"+quadro+"')";
			DataRow[] record = DS.mod770_details.Select(filtro);
			foreach (DataRow r in record) {
				string formato = (string) r["format"];
				int lunghezza = (int) r["fieldlen"];
                string filtro2 = "(quadro='" + quadro + "') and (progr=" + progressivoComunicazione
					+ ") and (colonna='" + r["colnumber"] + "')";
				DataRow[] r770 = t.Select(filtro2);
                if (r770.Length > 1) {
                    MessageBox.Show(this, "Errore interno: trovate " + r770.Length + " righe con questo filtro\n" + filtro2);
                }
				if (r770.Length==0) {
					sb.Append(vuoto(formato, lunghezza));
				} 
				else {
					sb.Append(formattaCampoPosizionale(r770[0], lunghezza));
				}
			}
			return sb.ToString();
		}

		private int scriviRecord(TextWriter tw, string header, DataTable t, string quadri) {
			int numeroRecord = 1;
			string pc = header.Substring(17, 8);
			int progressivoComunicazione = Int32.Parse(pc);
			string filtro = "(progr="+progressivoComunicazione+") and (quadro IN("+quadri+"))";
			DataRow[] record = t.Select(filtro, "quadro, riga, colonna");
			tw.Write(header);
			int aDisposizione = 1809;//1898 - 89 (posizioni per i campi posizionali) = 1809
            Object valore;
			foreach (DataRow r in record) {
				foreach (string s in formattaCampoNonPosizionale(r, out valore)) {
					if (s.Length > aDisposizione) {
						tw.WriteLine("A".PadLeft(aDisposizione));
						numeroRecord++;
						tw.Write(header);
						aDisposizione = 1809;
					}
					tw.Write(s);
					aDisposizione -= s.Length;
				}
			}
			tw.WriteLine("A".PadLeft(aDisposizione));
			return numeroRecord;
		}

		private TextWriter getStreamWriter() {
            //try {
            //    return new StreamWriter(txtPercorso.Text, false, Encoding.Default);
            //} 
            //catch (Exception) {
			if (saveFileDialog1.ShowDialog(this)!=DialogResult.OK) return null;
			txtPercorso.Text = saveFileDialog1.FileName;
			try {
				return new StreamWriter(txtPercorso.Text, false, Encoding.Default);
			} 
			catch (Exception e) {
				QueryCreator.ShowException(this, "Inserire il percorso del file dove salvare il modello770", e);
			}
            //}
			return null;
		}
	
/*		private bool controllaConfigurazionePrestazioni() {
			DataTable prestazioniSenzaTiporecord = DataAccess.RUN_SELECT(Meta.Conn,
				"service", null, null, "(rec770kind is null)", null, null, true);

			if (prestazioniSenzaTiporecord.Rows.Count > 0) {
				string errore = "Per generare il modello 770 occorre configurare il campo tiporecord770 della tabella tipoprestazione."
					+ "\n\nI seguenti tipi di prestazione non sono stati ancora configurati:\n";
				foreach (DataRow r in prestazioniSenzaTiporecord.Rows) {
					errore += "\n"+r["idser"].ToString().PadRight(10)+"\t"+r["description"];
				}
				errore += "\n\nSi prega di contattare l'assistenza.";
				MessageBox.Show(this, errore, "Errore");
				return false;
			}

			int esercizio = (int) Meta.GetSys("esercizio");

			string queryPrest = "select * from service "
				+ "left outer join motive770service "
				+ "on service.idser=motive770service.idser "
				+ "and ayear=" + (esercizio-1)
				+ " where rec770kind='H' and idmot is null";

			DataTable prestazioniHSenzaCausali = Meta.Conn.SQLRunner(queryPrest);

			if (prestazioniHSenzaCausali.Rows.Count > 0) {
				string errore = "Per generare il modello 770 occorre configurare il campo codicecausale della tabella cdcausale770prestazione."
					+ "\n\nInserire la causale per l'anno "	+ (esercizio-1)
					+ " per i seguenti tipi di prestazione:\n";
				foreach (DataRow r in prestazioniHSenzaCausali.Rows) {
					errore += "\n"+r["idser"].ToString().PadRight(10)+"\t"+r["description"];
				}
				errore += "\n\nSi prega di contattare l'assistenza.";
				MessageBox.Show(this, errore, "Errore");
				return false;
			}

			string queryRiten = "select distinct r.taxcode, r.description from service p "
				+ "join servicetax rp on p.idser=rp.idser and p.rec770kind in ('G','H') "
				+ "join taxcode r on r.taxcode=rp.taxcode and isnull(r.taxcode,'O')='O'";

			DataTable ritenuteGHSenzaTipo = Meta.Conn.SQLRunner(queryRiten);

			if (ritenuteGHSenzaTipo.Rows.Count > 0) {
				string errore = "Per generare il modello 770 occorre configurare il campo tiporitenuta della tabella tiporitenuta."
					+ "\n\nInserire il tiporitenuta per i seguenti tipi di ritenuta:\n";
				foreach (DataRow r in ritenuteGHSenzaTipo.Rows) {
					errore += "\n"+r["taxcode"].ToString().PadRight(10)+"\t"+r["description"];
				}
				errore += "\n\nSi prega di contattare l'assistenza.";
				MessageBox.Show(this, errore, "Errore");
				return false;
			}
			return true;
		}*/

/*		private bool ignoraEventualiErrori() {
			string errMsg;
			DataSet ds = Meta.Conn.CallSP("check_modello770", new object[] {2005},-1, out errMsg);
			if (errMsg != null) {
				MessageBox.Show(this, "Si è verificato il seguente errore nel calcolo del 770:"
					+"\n"+errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
				return false;
			}
			if (ds.Tables[0].Rows.Count == 0) return true;
			SubForm f = new SubForm(ds.Tables[0]);
			return f.ShowDialog(this) == DialogResult.OK;
		}*/

		private void salva770(TextWriter tw, DataSet ds, bool soloRecordH) {

			tw.WriteLine(getHeader(ds.Tables[0], "HRA", 1) + "A");

			tw.WriteLine(getHeader(ds.Tables[0], "HRB", 1) + "A");

			int nRecordG = 0;
            int nRG = 0;
			int nRecordH = 0;
            int nRH = 0;
            int nRecordI = 0;
            int nRI = 0;
            if (soloRecordH) {
                DataRow[] rH = ds.Tables[0].Select("(quadro='HRH')and(colonna='03')");
                nRH = rH.Length;
                foreach (DataRow rph in rH) {
                    int progressivoComunicazione = Convert.ToInt32(rph["intero"]);
                    string headerH = getHeader(ds.Tables[0], "HRH", progressivoComunicazione);
                    nRecordH += scriviRecord(tw, headerH, ds.Tables[0], "'AU'");
                }

                DataRow[] rI = ds.Tables[0].Select("(quadro='HRI')and(colonna='03')");
                nRI = rI.Length;
                foreach (DataRow rph in rI) {
                    int progressivoComunicazione = Convert.ToInt32(rph["intero"]);
                    string headerI = getHeader(ds.Tables[0], "HRI", progressivoComunicazione);
                    nRecordI += scriviRecord(tw, headerI, ds.Tables[0], "'SY001','SY007','SY008','SY009','SY010','SY011','SY016', 'SY017', 'SY018', 'SY019', 'SY020'");
                }
            }
                 string recordZ = "Z".PadRight(15)//Tipo record + Filler 
                + "1".PadLeft(9, '0')//Numero record di tipo ‘B’ 
                + "0".PadLeft(9, '0')//Numero record di tipo ‘D’ 
                + nRecordI.ToString().PadLeft(9, '0')//Numero record di tipo ‘I’ 
                //Questo tipo rec. non è presente nelle specifiche tecniche del 2009,2008,2007,2006
                //+ "0".PadLeft(9, '0')//Numero record di tipo ‘O’ 
                + "A".PadLeft(1856);//1898-15-9*3 = 1855

			tw.WriteLine(recordZ);

			tw.Close();

            if (soloRecordH) {
                MessageBox.Show(this, "Modello 770 salvato nel file: " + saveFileDialog1.FileName
                    + "\nComunicazioni Somme liquidate a seguito di procedure di pignoramento presso terzi e lavoratori autonomi stranieri privi di codice fiscale italiano:   " + nRI + "  (" + nRecordI + " record di tipo \"I\")",
                    "Creazione 770 terminata");
            }
            else {
                MessageBox.Show(this, "Modello 770 salvato nel file: " + saveFileDialog1.FileName
                    + "\n\nComunicazioni Lavoro Dipendente: " + nRG + "  (" + nRecordG + " record di tipo \"G\")",
                    "Creazione 770 terminata");
            }
		}

        

        //Questo metodo va chiamato prima di generare il mod770, è presenta anche nel modello CUD
       
        private void FormatDataGrid(DataTable tResult)
        {
            foreach (DataColumn C in tResult.Columns)
            {
                tResult.Columns[C.ColumnName].Caption = "";
            }
            tResult.Columns["errorcode"].Caption = "#";
            tResult.Columns["errordescr"].Caption = "Descrizione";
            tResult.Columns["blockingerror"].Caption = "Bloccante";

            tResult.Columns["errorcode"].ExtendedProperties["ListColPos"] = 0;
            tResult.Columns["errordescr"].ExtendedProperties["ListColPos"] = 1;
            tResult.Columns["blockingerror"].ExtendedProperties["ListColPos"] = 2;

            HelpForm.SetGridStyle(dgrVerifiche, tResult);
            metadatalibrary.formatgrids fg = new formatgrids(dgrVerifiche);
            fg.AutosizeColumnWidth();
        }

        private DataRow GetGridSelectedRows(DataGrid G)
        {
            DataSet DSV = (DataSet)G.DataSource;
            if (DSV == null) return null;
            DataTable TV = DSV.Tables[G.DataMember];
            if (TV == null) return null;

            if (TV.Rows.Count == 0) return null;
            DataRowView DV = null;
            try
            {
                DV = (DataRowView)G.BindingContext[DSV, TV.TableName].Current;
            }
            catch
            {
                DV = null;
            }
            if (DV == null) return null;

            DataRow R = DV.Row;
            return R;
        }

        private void VisualizzaElenchi(int errorcode)
        {
     
            if (errorcode <= 0) return;
            AllList[errorcode - 1](null, null);
        }

        private void dgrVerifiche_DoubleClick(object sender, EventArgs e)
        {
            DataRow RigheSelezionata = GetGridSelectedRows(dgrVerifiche);
            if (RigheSelezionata == null)
                return;
            if (!RigheSelezionata.Table.Columns.Contains("errorcode")) return;

            if (CfgFn.GetNoNullInt32(RigheSelezionata["errorcode"]) > 0)
                VisualizzaElenchi(CfgFn.GetNoNullInt32(RigheSelezionata["errorcode"]));
        }

        private bool VerificaPrestazioni(string recordKind)
        {
            dgrVerifiche.DataSource = null;
            int  esercizioRedditi = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1;
            string errMess;
            DataSet ds_check = Meta.Conn.CallSP("check_mod_770", new object[] { esercizioRedditi, recordKind }, 600, out errMess);
            if (errMess != null)
            {
                MessageBox.Show(this, "Errore nella chiamata della procedura di verifica: " + errMess, "Errore");
                return false;
            }
            DataTable tResult = ds_check.Tables[0];

            if (tResult.Rows.Count != 0)
            {
                // Visualizzazione del grid
                FormatDataGrid(tResult);
                HelpForm.SetDataGrid(dgrVerifiche, tResult);
                if (tResult.Select(QHC.CmpEq("blockingerror", "S")).Length > 0)
                {
                    bool isAdmin = false;
                    if (Meta.GetSys("manage_prestazioni") != null)
                    {
                        isAdmin = (Meta.GetSys("manage_prestazioni").ToString().ToUpper() == "S");
                    }

                    if (!isAdmin)
                        return false;
                    else
                        if (MessageBox.Show(" Si desidera proseguire l''elaborazione nonostante  gli errori?", "Errore",
                       MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            return true;
                        else
                            return false;
                }
                else
                {
                    return true;
                }
            }
            else return true;
        }

        private void Excel_Click(object sender, EventArgs e, DataTable T)
        {
            if (T.Rows.Count == 0)
            {
                MessageBox.Show("Nessun elemento trovato");
                return;
            }
            exportclass.DataTableToExcel(T, true);
        }


        private void VisualizzaDati(object sender, EventArgs e, DataTable T)
        {
             Excel_Click(sender, e, T);
        }

        private void btn01_Click(object sender, EventArgs e)
        {
            //Contratti non pagati
            int esercizio = (int)Meta.GetSys("esercizio");
            string sqlCmd = "select distinct "
                + " 'Esistono dei cedolini nei seguenti contratti i cui pagamenti non sono ancora stati trasmessi in banca: "
                + " poichè in tali contratti ci sono cedolini non pagati, "
                + " tali cedolini vanno trasferiti nella competenza dell''esercizio attuale.' as 'Errore',"
                + " parasubcontract.ycon as 'Eserc.', parasubcontract.ncon as 'Num.', exhibitedcud.idexhibitedcud as 'CUD'"
                + " FROM parasubcontract "
                + " JOIN parasubcontractyear "
                + " ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                + " AND  parasubcontractyear.ayear = " + (esercizio - 1) + " "
                + "join payroll on payroll.idcon = parasubcontract.idcon "
                + "left outer join exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon "
                + "where not exists (select * from expensepayroll "
                + "join expenselink ON expenselink.idparent = expensepayroll.idexp "
                + "join expenselast on expenselast.idexp = expenselink.idchild "
                + "join payment on payment.kpay = expenselast.kpay "
                + "where payment.kpaymenttransmission is not null "
                + "and payroll.idpayroll = expensepayroll.idpayroll)"
                + " and isnull(payroll.flagbalance,'N')='N' "
                + "and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' "
                + "and payroll.fiscalyear = " + (esercizio - 1)

                + " and exhibitedcud.fiscalyear = " + (esercizio - 1);


            DataTable T = Meta.Conn.SQLRunner(sqlCmd);

            if (T != null)
            {
                VisualizzaDati(sender, e, T);
            }

        }


         private void btn02_Click(object sender, EventArgs e)
        {
			//Prestazioni Certificazioni CUD
            int esercizio = (int)Meta.GetSys("esercizio");
           string sqlCmd = "SELECT DISTINCT 'Esistono dei contratti esibiti come CUD in altri contratti, "
                   + " le cui prestazioni però non sono associate al modello 770' as 'Errore', "
				   + " service.description as 'Prestazione', parasubcontract.ycon as 'Eserc.', " 
                   + "parasubcontract.ncon as 'Numero' "
                   + "FROM parasubcontract "
                   + "JOIN parasubcontractyear "
                   + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                   + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " " 
                   + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                   + "JOIN exhibitedcud on exhibitedcud.idlinkedcon = parasubcontract.idcon "
                   + "JOIN service ON service.idser = parasubcontract.idser "
                   + "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                   + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                   + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                   + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) + ") "
                   + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                   + "and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' "
                   + "AND   ISNULL(service.rec770kind,'')<> 'G' ";
                   

           DataTable T = Meta.Conn.SQLRunner(sqlCmd);

           if (T != null)
			{
			   VisualizzaDati(sender, e, T);
			}
        }

          private void btn03_Click(object sender, EventArgs e)
        {
			//3) Prestazioni Certificazioni In Non CUD
            int esercizio = (int)Meta.GetSys("esercizio");
           string sqlCmd =   "SELECT DISTINCT 'Ci contratti contenenti CUD, le cui prestazioni non sono configurate per il modello 770' as 'Errore'," 
			       + " service.description as 'Prestazione', parasubcontract.ycon as 'Esercizio', " 
                   + "parasubcontract.ncon as 'Numero' "
                   + "FROM parasubcontract "
                   + "JOIN parasubcontractyear "
                   + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                   + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " "
                   + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                   + "JOIN exhibitedcud on exhibitedcud.idcon = parasubcontract.idcon "
                   + "JOIN service ON service.idser = parasubcontract.idser "
                   + "WHERE EXISTS (select * from payroll JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll "
                   + "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp "
                   + "JOIN expenselast on expenselast.idexp = expenselink.idchild "
                   + "WHERE payroll.idcon = parasubcontract.idcon  AND payroll.fiscalyear =  " + (esercizio - 1) + ") "
                   + "AND   exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                   + "and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' "
                   + "AND   ISNULL(service.rec770kind,'')<> 'G' ";
                   

           DataTable T = Meta.Conn.SQLRunner(sqlCmd);

           if (T != null)
			{
			   VisualizzaDati(sender, e, T);
			}
        }

          private void btn04_Click(object sender, EventArgs e)
          {
              // 4) CUD in Contratti Non Conguagliati
              int esercizio = (int)Meta.GetSys("esercizio");
              string sqlCmd = "SELECT 'Esistono dei percipienti con contratti esibiti come CUD in altri contratti, " 
                              + " e a questi ultimi non è stato erogato il conguaglio' as 'Errore', "
                              + " parasubcontract.ycon as 'Esercizio', parasubcontract.ncon as 'Numero', registry.title as 'Nominativo Percip.' "
                              + "FROM parasubcontract "
                              + "JOIN parasubcontractyear "
                              + "ON  parasubcontractyear.idcon =  parasubcontract.idcon "
                              + "AND  parasubcontractyear.ayear = " + (esercizio - 1) + " "
                              + "JOIN registry ON parasubcontract.idreg = registry.idreg "
                              + "JOIN service ON service.idser = parasubcontract.idser "
                              + "join exhibitedcud on parasubcontract.idcon = exhibitedcud.idcon "
                              + "WHERE  EXISTS (select * from payroll "
                                      + "WHERE payroll.idcon = parasubcontract.idcon "
                                      + " and payroll.flagbalance = 'S' "
                                      + " and disbursementdate is null "
                                      + "and payroll.fiscalyear = " + (esercizio - 1) + " )"
                              + "and exhibitedcud.fiscalyear = " + (esercizio - 1) + " "
                              + "and isnull(parasubcontractyear.flagexcludefromcertificate,'N')='N' "
                              + "AND ISNULL(service.rec770kind,'') = 'G' ";

              DataTable T = Meta.Conn.SQLRunner(sqlCmd);

              if (T != null)
              {
                  VisualizzaDati(sender, e, T);
              }
          }
          private void btn05_Click(object sender, EventArgs e)
          {
              //5) Prestazioni Senza Causale
              int esercizio = (int)Meta.GetSys("esercizio");
              string sqlCmd = "SELECT DISTINCT ' Ci sono prestazioni adoperate che confluiranno nel record H senza causale. Bisogna impostarla ' as 'Errore', " +
                      " service.codeser as 'Cod. Prestazione', service.description as 'Prestazione' " +
                      " FROM expense " +
                      " JOIN expenselast on expense.idexp = expenselast.idexp " +
                      " JOIN payment " +
                      " ON payment.kpay = expenselast.kpay " +
                      " JOIN paymenttransmission " +
                      " ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission " +
                      " JOIN service on service.idser=expenselast.idser " +
                      " LEFT OUTER JOIN motive770service M " +
                      " ON M.idser = service.idser " +
                      " AND " + QHS.CmpEq("M.ayear", (esercizio - 1)) +
                      " JOIN registry ON expense.idreg = registry.idreg " +
                      " WHERE registry.idregistryclass <> '10' " +
                      " AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
                      " AND " + QHS.CmpEq("year(paymenttransmission.transmissiondate)", (esercizio - 1)) +
                      " AND service.rec770kind = 'H' " +
                      " AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp) " +
                      " + ISNULL( " +
                      " (SELECT SUM(amount) FROM expensevar " +
                      " WHERE expensevar.idexp = expense.idexp " +
                      " AND " + QHS.CmpLe("expensevar.yvar", (esercizio - 1)) +
                      " AND ISNULL(autokind,0) <> 4) " +
                      " ,0)) > 0 " +
                      " and (select count(*) from expensetax where expensetax.idexp=expense.idexp) > 0 " +
                      " and m.idmot is null";

              DataTable T = Meta.Conn.SQLRunner(sqlCmd);

              if (T != null)
              {
                  VisualizzaDati(sender, e, T);
              }
          }
        private void btn06_Click(object sender, EventArgs e)
{
	// 6 Presenza Provvigioni
    int esercizio = (int)Meta.GetSys("esercizio");
    string sqlCmd =  "SELECT DISTINCT  'Sono state pagate delle provvigioni. Controllare le causali delle dichiarazioni nelle quali sono state usate' as 'Errore', "  +
     " registry.title AS 'Anagrafica', ISNULL(registry.cf, registry.foreigncf) AS 'cf' " +
            " FROM expense " +
            " JOIN expenselast on expense.idexp = expenselast.idexp " +
            " JOIN payment " +
            " ON payment.kpay = expenselast.kpay " +
            " JOIN paymenttransmission " +
            " ON paymenttransmission.kpaymenttransmission = payment.kpaymenttransmission " +
            " JOIN service on service.idser=expenselast.idser " +
            " LEFT OUTER JOIN motive770service M " +
            " ON M.idser = service.idser " +
            " AND " + QHS.CmpEq("M.ayear", (esercizio - 1)) +
            " JOIN registry ON expense.idreg = registry.idreg " +
            " WHERE registry.idregistryclass <> '10' " +
            " AND NOT EXISTS(SELECT * FROM registryrole WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
            " AND " + QHS.CmpEq("year(paymenttransmission.transmissiondate)", (esercizio - 1)) +
            " AND service.rec770kind = 'H' " +
            " AND ((select expenseyear.amount from expenseyear where expenseyear.idexp = expenselast.idexp) " +
            " + ISNULL( " +
            " (SELECT SUM(amount) FROM expensevar " +
            " WHERE expensevar.idexp = expense.idexp " +
            " AND " + QHS.CmpLe("expensevar.yvar", (esercizio - 1)) +
            " AND ISNULL(autokind,0) <> 4) " +
            " ,0)) > 0 " +
            " and (select count(*) from expensetax where expensetax.idexp=expense.idexp) > 0 " +
            " AND " + QHS.CmpEq("service.codeser", "07_PROVVIGIONI");
          
   DataTable T = Meta.Conn.SQLRunner(sqlCmd);

   if (T != null)
	{
	   VisualizzaDati(sender, e, T);
	}
}
        private void InitializeAllList()
        {
            //1)  Contratti non pagati
            AllList[0] = this.btn01_Click;

            //2)  
            AllList[1] = this.btn02_Click;

            //3) 
            AllList[2] = this.btn03_Click;

            //4)  
            AllList[3] = this.btn04_Click;

            //5)   
            AllList[4] = this.btn05_Click;

            //6)  
            AllList[5] = this.btn06_Click;
        }
		private void btnGenera770_Click(object sender, System.EventArgs e) {

        }


		private void btnSalva_Click(object sender, System.EventArgs e) {
			if (saveFileDialog1.ShowDialog(this)==DialogResult.OK) {
				txtPercorso.Text = saveFileDialog1.FileName;
			}
		}

		private void richTextBox1_LinkClicked(object sender, System.Windows.Forms.LinkClickedEventArgs e) {
			System.Diagnostics.Process.Start(e.LinkText);
		}

        class Colonna:IComparable {
            public string quadro;
            public int riga;
            int colorder;
            public string colonna;
            public Type type;

            public Colonna(DataRow rFormato, int riga, Type tipo) {
                this.quadro = (string)rFormato["frame"];
                this.riga = riga;
                this.colorder = (int)rFormato["colorder"];
                this.colonna = (string)rFormato["colnumber"];
                this.type = tipo;
            }

            public int CompareTo(Object obj) {
                Colonna c = (Colonna)obj;
                if (c.riga==riga) {
                    return colorder - c.colorder;
                }
                return riga-c.riga;
            }
        }

        private string getNomeColonnaExcel(List<Colonna> list, object quadro, object riga, object colonna) {
            foreach (Colonna c in list) {
                if (c.quadro.Equals(quadro) && c.colonna.Equals(colonna) && !c.riga.Equals(riga))
                {
                    return quadro + "-rig" + riga + "-col" + colonna;
                }
            }
            return quadro + "-col" + colonna;
        }

        private void visualizzaQuadroInExcel(string record)
        {
            string filtroQuadro = "";
            if (record == "A") filtroQuadro = "quadro in ('HRA')";
            if (record == "B") filtroQuadro = "quadro in ('HRB')";
            
            if (record == "I") filtroQuadro = "quadro in ('HRI','SY001','SY007','SY008','SY009','SY010','SY011','SY016', 'SY017', 'SY018', 'SY019', 'SY020')";
            Cursor = Cursors.WaitCursor;
            if (tMod770 != null)
            {
                DataRow[] righe770_old = tMod770.Select(filtroQuadro, "progr");
                if (righe770_old.Length == 0)
                {
                    generaIlModello770(record == "I", false);
                }
            }
            else
            {
                generaIlModello770(record == "I", false);
            }
            
            DataRow [] righe770 = tMod770.Select(filtroQuadro, "progr");
            if (righe770.Length == 0) {
                MessageBox.Show(this, "Non ci sono dati per il record " + record);
                Cursor = null;
                return;
            }
            Object valore;
            List<Colonna> lColonne = new List<Colonna>();
            foreach (DataRow r in righe770) {
                string filtro = "frame='" + r["quadro"] + "' and colnumber='" + r["colonna"]+"'";
                DataRow[] rr = DS.mod770_details.Select(filtro);
                if (rr.Length != 1) {
                    MessageBox.Show(this, "Ho trovato " + rr.Length + " righe con questo filtro:\n" + filtro);
                }
                formattaCampoNonPosizionale(r, out valore);
                Colonna c = new Colonna(rr[0], (int)r["riga"], valore.GetType());
                int pos = lColonne.BinarySearch(c);
                if (pos < 0) {
                    lColonne.Insert(-pos - 1, c);
                }
            }
            DataTable t = new DataTable();
            foreach (Colonna c in lColonne) {
                string campoCodice = getNomeColonnaExcel(lColonne, c.quadro, c.riga, c.colonna);
                t.Columns.Add(campoCodice, c.type);
            }
            DataRow riga = t.NewRow();
            t.Rows.Add(riga);
            int progr = (int)righe770[0]["progr"];
            foreach (DataRow r in righe770) {
                if (progr != (int)r["progr"]) {
                    progr = (int)r["progr"];
                    riga = t.NewRow();
                    t.Rows.Add(riga);
                }
                string campoCodice = getNomeColonnaExcel(lColonne, r["quadro"], r["riga"], r["colonna"]);
                formattaCampoNonPosizionale(r, out valore);
                if (!t.Columns.Contains(campoCodice)) continue;
                if (riga[campoCodice] != DBNull.Value) {
                    MessageBox.Show(this, "Il campo "+campoCodice+" è stato assegnato due volte");
                }
                riga[campoCodice] = valore;
            }
            exportclass.DataTableToExcel(t, true);
            Cursor = null;
        }

       
        private void visualizzaLegenda(string filtroQuadro) {
            Cursor = Cursors.WaitCursor;
            DataRow[] legenda = DS.mod770_details.Select(filtroQuadro, "colorder");
            DataTable t = new DataTable();
            t.Columns.Add("Quadro", typeof(System.String));
            t.Columns.Add("Colonna", typeof(System.String));
            t.Columns.Add("Descrizione", typeof(System.String));
            t.Columns.Add("Formato", typeof(System.String));
            t.Columns.Add("Posizione", typeof(System.Int32));
            t.Columns.Add("Lunghezza campo", typeof(System.Int32));
            t.Columns.Add("Sezione", typeof(System.String));
            t.Columns.Add("Valori ammessi", typeof(System.String));
            foreach (DataRow r in legenda)
            {
                t.Rows.Add(r["frame"], r["colnumber"], r["description"], r["format"], r["position"], r["fieldlen"], r["section"], r["admittedvalues"]);
            }
            exportclass.DataTableToExcel(t, true);
            Cursor = null;
        }

        private void buttonPrestazioni_Click(object sender, EventArgs e) {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = @"select distinct expenselast.idser 
                            from expenselast
                            join expenselink on expenselink.idchild = expenselast.idexp
                            join expensetax on expensetax.idexp = expenselink.idparent
                            join expense on expense.idexp=expensetax.idexp 
                            where ymov>=" + (esercizio - 1) + " and idser is not null";
                            DataTable tPrestAttive = DataAccess.SQLRunner(Meta.Conn, query);
            DataTable tPrestazioni = DataAccess.RUN_SELECT(Meta.Conn, "service", null, null, null, null, null, true);
            DataTable t = new DataTable();
            t.Columns.Add("Prestazioni del record 'G'");
            t.Columns.Add("Prestazioni del record 'H'");
            t.Columns.Add("Prestazioni non inserite nel modello 770");
            t.Columns.Add("Prestazioni non usate nel " + (esercizio - 1));
            List<string> lg = new List<string>();
            List<string> lh = new List<string>();
            List<string> ll = new List<string>();
            List<string> ln = new List<string>();
            foreach (DataRow rp in tPrestazioni.Rows) {
                if (tPrestAttive.Select("idser='" + rp["idser"]+"'").Length > 0) {
                    switch (rp["rec770kind"].ToString().ToUpper()) {
                        case "G": lg.Add(rp["idser"] + " - " + rp["description"]); break;
                        case "H": lh.Add(rp["idser"] + " - " + rp["description"]); break;
                        default: ll.Add(rp["idser"] + " - " + rp["description"]); break;
                    }
                }
                else {
                    switch (rp["rec770kind"].ToString().ToUpper()) {
                        case "G": ln.Add("G - "+rp["idser"] + " - " + rp["description"]); break;
                        case "H": ln.Add("H - "+rp["idser"] + " - " + rp["description"]); break;
                        default: ln.Add("* - "+rp["idser"] + " - " + rp["description"]); break;
                    }
                }
            }
            int max = lg.Count;
            if (lh.Count > max) max = lh.Count;
            if (ll.Count > max) max = ll.Count;
            if (ln.Count > max) max = ln.Count;
            for (int i = 0; i < max; i++) {
                DataRow r = t.NewRow();
                if (lg.Count > i) r[0] = lg[i];
                if (lh.Count > i) r[1] = lh[i];
                if (ll.Count > i) r[2] = ll[i];
                if (ln.Count > i) r[3] = ln[i];
                t.Rows.Add(r);
            }
            exportclass.DataTableToExcel(t, true);
        }

        private DataTable getConfigurazionePrestazioni() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "select distinct idser from expensetax "
                + "join expenselast on expenselast.idexp=expensetax.idexp "
                + "join expense on expense.idexp = expenselast.idexp "
                + "where ymov>=" + (esercizio - 1)
                + " and idser is not null";
            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
            string prestazioni = QueryCreator.ColumnValues(t, null, "idser", true);
            string filtroPrestazioni = prestazioni == "" ? "0=1" : "service.idser in (" + prestazioni + ")";
            string s = @"select service.active, service.idser,service.codeser, service.description, service.rec770kind, motive770service.idmot, 
                        service.module, service.certificatekind, certificate=certificationmodel.description,
                        cisonoritfiscali=case when exists (select * from servicetax join tax on service.idser=servicetax.idser and servicetax.taxcode=tax.taxcode and taxkind=1) then 'S' else 'N' end
                        from service
                        left outer join motive770service on service.idser=motive770service.idser and motive770service.ayear="
                        +esercizio
                        +@" left outer join certificationmodel on service.certificatekind=certificationmodel.idcertificationmodel
                        where "+filtroPrestazioni;
            return DataAccess.SQLRunner(Meta.Conn, s);
        }

        private DataTable getPercipientiParasubordinatiRecG() {
            int esercizio = (int)Meta.GetSys("esercizio");
	        string query = "SELECT " +			
		    "co.idreg, " +
		    "registry.title, " + 
		    "co.ycon, " +
		    "co.ncon, " +
		    "service.codeser, " +
		    "service.description, " +
		    "im.stopcompetency " + 
	        "FROM  payroll ce " +
	        "JOIN parasubcontract co ON co.idcon = ce.idcon " +
                "JOIN parasubcontractyear im ON co.idcon = im.idcon " + 
                "AND im.ayear =  " + (esercizio - 1) +
	        "JOIN service on service.idser = co.idser " +
	        "JOIN registry ON co.idreg = registry.idreg " +
	        "WHERE ce.flagbalance = 'S' " +
	        "AND ce.fiscalyear= " + (esercizio - 1) + 
	        "AND NOT EXISTS (SELECT idlinkedcon FROM exhibitedcud " +
			        "WHERE idlinkedcon = ce.idcon and " +
                    "exhibitedcud.fiscalyear = " +  (esercizio - 1) + ") " +
	        "AND EXISTS (SELECT payroll.idpayroll FROM payroll " +
			        "JOIN expensepayroll ON payroll.idpayroll = expensepayroll.idpayroll " +
			        "JOIN expenselink ON expenselink.idparent = expensepayroll.idexp " +
			        "JOIN expenselast ON expenselast.idexp = expenselink.idchild " +
			        "JOIN payment ON payment.kpay=expenselast.kpay " +
			        "WHERE payroll.idcon =  " + 
			        "co.idcon and payment.kpaymenttransmission IS NOT NULL) " +
	        "AND service.rec770kind='G' ";

            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
            return t;
        }

         private DataTable getAltriPercipientiRecG() {
            int esercizio = (int)Meta.GetSys("esercizio");
            DateTime TrediciGennAnnoRedditi = new DateTime(esercizio -1, 1, 13);
            DateTime DodiciGennAnnoDichiar = new DateTime(esercizio, 1, 12);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();
	        string query = " SELECT " +
	                "expense.idreg, " +
	                "registry.title, " +
	                "service.codeser, " +
	                "service.description, " +
	                "expense.idexp, " + 
	                (esercizio -1) + "as ymov," + 
	                "expense.nmov " +
	                "FROM expense " +
	                "JOIN expenseyear " +
		                "ON expenseyear.idexp = expense.idexp " +
	                "JOIN expenselast " +
		                "ON expense.idexp = expenselast.idexp " +
	                "JOIN service " +
		                "ON service.idser=expenselast.idser " +
	                "JOIN registry " +
		                "ON expense.idreg = registry.idreg " +
	                "JOIN payment " +
		                "ON payment.kpay=expenselast.kpay " +
	                "JOIN paymenttransmission  "+
		                "ON paymenttransmission.kpaymenttransmission= " +
		                "payment.kpaymenttransmission " +
                    "WHERE transmissiondate BETWEEN  " + QHS.quote(TrediciGennAnnoRedditi) + 
                        " AND " + QHS.quote(DodiciGennAnnoDichiar) +
			            "AND registry.idregistryclass <> '10' " +
			            "AND NOT EXISTS(SELECT * FROM registryrole " +
				                   "WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
			            "AND service.rec770kind='G' " +
			            "AND (expenseyear.amount " +
				            "+ ISNULL( " + 
					            "(SELECT SUM(amount) FROM expensevar " +
					            "WHERE expensevar.idexp = expense.idexp " +
					            "AND expensevar.yvar <= " + (esercizio -1) +
					            "AND ISNULL(autokind,0) <> 4)" +
				            ",0)) > 0 " +
			            "AND NOT EXISTS (select * from expensepayroll " +
			            "JOIN expenselink " +
				            "ON expenselink.idparent = expensepayroll.idexp " +
				            "JOIN expensetax " +
				            "ON expense.idexp = expensetax.idexp " +
			            "WHERE expensetax.idexp = expenselink.idchild) ";

                    DataTable t = DataAccess.SQLRunner(Meta.Conn, query);
                
                    return t;
        }

        private DataTable getPercipientiRecH() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string query = "SELECT " +
		        "expense.idreg, " +
		        "registry.title, " +
		        "service.codeser, " +
		        "service.description, " +
		        "expense.idexp, " +
		        (esercizio -1) + "as ymov," +
		        "expense.nmov " +
		        "FROM expense " +
		        "JOIN expenselast on expense.idexp = expenselast.idexp " +
		        "JOIN payment " +
			        "ON payment.kpay = expenselast.kpay " +
		        "JOIN paymenttransmission " +
			        "ON paymenttransmission.kpaymenttransmission = " +
			        "payment.kpaymenttransmission " +
		        "JOIN service on service.idser=expenselast.idser " +
		        "JOIN registry ON expense.idreg = registry.idreg " +
		        "WHERE registry.idregistryclass <> '10' " +
			        "AND NOT EXISTS(SELECT * FROM registryrole " +
			        "WHERE idrole = '16' AND registryrole.idreg = expense.idreg) " +
			        "AND YEAR(paymenttransmission.transmissiondate)= " + (esercizio -1) +
			        "AND service.rec770kind = 'H' " +
			        "AND ((SELECT expenseyear.amount from expenseyear  " +
			        "where expenseyear.idexp = expenselast.idexp) " +
			        "+ ISNULL( " +
				        "(SELECT SUM(amount) FROM expensevar " +
				        "WHERE expensevar.idexp = expense.idexp " +
				        "AND expensevar.yvar <= " + (esercizio -1) +
				        "AND ISNULL(autokind,0) <> 4) " + 
			        ",0)) > 0 " +
			        "AND (SELECT count(*) from expensetax " +
			              "WHERE expensetax.idexp=expense.idexp) > 0";

            DataTable t = DataAccess.SQLRunner(Meta.Conn, query);

            return t;
        }

        private bool verificaDomFiscaleNonResidenti (int idreg, DateTime date) {
        // Se il percipiente è non residente si verifica che alla 
	    // data di riferimento esista almeno un domicilio fiscale in Italia
            if (date == QueryCreator.EmptyDate()) return false;
	        QueryHelper QHS = Meta.Conn.GetQueryHelper();
            // Verifico esistenza di una residenza all'estero alla data di riferimento
            object idDomFiscale = Meta.Conn.DO_READ_VALUE("address", 
                                  QHS.CmpEq("codeaddress", "07_SW_DOM"), "idaddress");
            object idResidenza  = Meta.Conn.DO_READ_VALUE("address", 
                                  QHS.CmpEq("codeaddress", "07_SW_DEF"), "idaddress");

            string filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), 
				       QHS.CmpEq("idaddresskind", idResidenza), 
				       QHS.CmpEq("ISNULL(flagforeign, 'N')",'S'),
                       "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + 
				       QHS.quote(date) + "))");
            
	        object idNation = Meta.Conn.DO_READ_VALUE("registryaddress", filter, "idnation");
            if ((idNation != DBNull.Value) && (idNation != null)) {
                // In presenza di un indirizzo di residenza estero verifico l''esistenza  
		        // di un domicilio fiscale in Italia alla data di riferimento
                    filter = QHS.AppAnd(QHS.CmpEq("idreg", idreg), 
				        QHS.CmpEq("idaddresskind", idDomFiscale),
				        QHS.CmpEq("ISNULL(flagforeign, 'N')",'N'),
                        "(" + QHS.quote(date) + " BETWEEN start AND ISNULL(stop," + 
				        QHS.quote(date) + "))");
		        object idCity = Meta.Conn.DO_READ_VALUE("registryaddress", filter, "idcity");
                if ((idCity == DBNull.Value) || (idCity == null)) {
            	        return false;
        	    }
            }
	        return true;
        }

        private DataTable controllaNonResidentiRecordG() {
	        int esercizio = (int)Meta.GetSys("esercizio");
            DateTime PrimoGennAnnoRedditi = new DateTime(esercizio -1, 1, 1);
            DateTime TrentunoDicAnnoRedditi = new DateTime(esercizio -1, 12, 31);
            DateTime PrimoGennAnnoDichiar = new DateTime(esercizio, 1, 1);
        
	        DataTable t = getPercipientiParasubordinatiRecG();
            DataTable z = new DataTable();
            // ATTENZIONE. Rivedere i tipi del datatable z e controllare se t contiene righe
	        z.Columns.Add("Tipo Contratto");
            z.Columns.Add("Cod. Percipiente", typeof(System.Int32));
            z.Columns.Add("Percipiente", typeof(System.String));
            z.Columns.Add("Eserc. Contratto / Pagamento", typeof(System.Int32));
            z.Columns.Add("Num. Contratto / Pagamento", typeof(System.Int32));
            z.Columns.Add("Cod. Prestazione", typeof(System.String));
            z.Columns.Add("Prestazione", typeof(System.String));
            z.Columns.Add("Problema");
            z.Columns.Add("Data Riferimento", typeof(System.DateTime));
            if (t != null) {
                // Controllo sui percipienti dei contratti parasubordinati
                foreach (DataRow r in t.Rows) {
                    int idreg = CfgFn.GetNoNullInt32(r["idreg"]);
                    if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoRedditi)) {
                        z.Rows.Add("Parasubordinati", r["idreg"], r["title"],
                                   r["ycon"], r["ncon"], r["codeser"], r["description"],
                                   "Non ha un domicilio fiscale in Italia valido alla data",
                                   PrimoGennAnnoRedditi);
                    }

                    DateTime fineContratto = (DateTime)r["stopcompetency"];

                    if (!verificaDomFiscaleNonResidenti(idreg, fineContratto)) {
                        z.Rows.Add("Parasubordinati", r["idreg"], r["title"],
                                   r["ycon"], r["ncon"], r["codeser"], r["description"],
                                   "Non ha un domicilio fiscale in Italia valido a fine contratto/fine anno",
                                   r["stopcompetency"]);
                    }

                    if (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiar)) {
                        z.Rows.Add("Parasubordinati", r["idreg"], r["title"],
                                   r["ycon"], r["ncon"], r["codeser"], r["description"],
                                   "Non ha un domicilio fiscale in Italia valido alla data",
                                   PrimoGennAnnoDichiar);
                    }
                }
            }
	        // Controllo sui percipienti di contratti diversi da parasubordinati 
	        // da includere nel RECORD G
            DataTable t1 = getAltriPercipientiRecG();
            if (t1 == null) return z;
            foreach (DataRow r in t1.Rows) {
                int idreg = CfgFn.GetNoNullInt32(r["idreg"]);
		        if  (!verificaDomFiscaleNonResidenti(idreg,PrimoGennAnnoRedditi)){
			        z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"], 
	                           r["ymov"], r["nmov"],r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia valido alla data", 
				               PrimoGennAnnoRedditi);
	            }
		
		        if  (!verificaDomFiscaleNonResidenti(idreg,TrentunoDicAnnoRedditi)){
			        z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"], 
	                           r["ymov"], r["nmov"],r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia valido alla data", 
				               TrentunoDicAnnoRedditi);
	            }
                
                if  (!verificaDomFiscaleNonResidenti(idreg, PrimoGennAnnoDichiar)){
			        z.Rows.Add("Altri Pagamenti record G", r["idreg"], r["title"], 
	                           r["ymov"], r["nmov"],r["codeser"], r["description"],
                               "Non ha un domicilio fiscale in Italia  valido alla data", 
				               PrimoGennAnnoDichiar);
	            }    
            }
            return z;
	    }

        private void generaIlModello770(bool soloRecordHI, bool salvaSuFile) {
            Cursor = Cursors.WaitCursor;
            string esercizio = ((int)Meta.GetSys("esercizio") % 100).ToString();
            if (esercizio.Length < 2) {
                esercizio = "0" + esercizio;
            }
            string errMsg;

            object[] parametriA = new object[] { };
            DataSet ds_RecordA = Meta.Conn.CallSP("exp_modello770_" + esercizio + "_a", parametriA, 60 * 60, out errMsg);
            if (ds_RecordA == null)
            {
                MessageBox.Show(this, "Si è verificato il seguente errore nel calcolo del Record A del modello 770:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return;
            }

            DataSet ds = new DataSet();
            DataTable tRecordA = ds_RecordA.Tables[0];

            ds.Merge(tRecordA);

            object[] parametriI = new object[] { };
            DataSet ds_RecordI = Meta.Conn.CallSP("exp_modello770_" + esercizio + "_i", parametriI, 60 * 60, out errMsg);
            if (ds_RecordI == null)
            {
                MessageBox.Show(this, "Si è verificato il seguente errore nel calcolo del Record I del modello 770:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return;
            }

      
            DataTable tRecordI = ds_RecordI.Tables[0];

            ds.Merge(tRecordI);


            // SIMULO Calcolo il numero delle comunicazioni G o H inviate da inserire in record B (rispettivamente 1 E 1)
            int nRecordI;

            // Calcolo il numero delle comunicaizoni I inviate da inserire in record B
            DataRow[] rI = ds.Tables[0].Select("(quadro='HRI')and(colonna='03')");
            
            nRecordI = rI.Length;
           

            object[] parametriGH = new object[] { 0, 0, nRecordI };
            DataSet ds_RecordB = Meta.Conn.CallSP("exp_modello770_" + esercizio + "_b", parametriGH, 60 * 60, out errMsg);
            if (ds_RecordB == null)
            {
                MessageBox.Show(this, "Si è verificato il seguente errore nel calcolo del Record B del modello 770:"
                    + "\n" + errMsg + "\nRiprovare o chiamare l'ASSISTENZA");
                Cursor = null;
                return;
            }

            DataTable tRecordB = ds_RecordB.Tables[0];
            ds.Merge(tRecordB);

            tMod770 = ds.Tables[0];

            foreach (DataRow r in tMod770.Select("quadro<>'SS'")) {
                string filtro = "frame='" + r["quadro"] + "' and colnumber='" + r["colonna"] + "'";
                DataRow[] rFormato = DS.mod770_details.Select(filtro);
                if (rFormato.Length != 1) {
                    MessageBox.Show(this, "Formato sconosciuto: " + filtro);
                    Cursor = null;
                    return;
                }
            }

            HelpForm.SetDataGrid(dgrVerifiche, tMod770);
            Cursor = null;

            if (salvaSuFile) {
                TextWriter tw = getStreamWriter();
                if (tw == null) {
                    return;
                }
                salva770(tw, ds, soloRecordHI);
            }
        }

        private void buttonGenera770_Click(object sender, EventArgs e) {
            generaIlModello770(true, true);
        }

        private void buttonLegendaI_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame in ('SY001','SY007','SY008','SY009','SY010','SY011', 'SY016','SY017','SY018','SY019','SY020')");
        }

        private void buttonRecordI_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("I");
        }

        private void btnLegendaA_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame = 'HRA'");
        }

        private void btnLegendaB_Click(object sender, EventArgs e)
        {
            visualizzaLegenda("frame = 'HRB'");
        }

        private void btnDatiA_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("A");
        }

        private void btnDatiB_Click(object sender, EventArgs e)
        {
            visualizzaQuadroInExcel("B");
        }

        private void btnGenera770_RecordG_Click(object sender, EventArgs e) {
            generaIlModello770(false, true);
        }

        private string aggiustaStringa(string stringa) {

            string s = stringa.Replace('’', ' ').Replace('´', ' ').Replace('Ç', 'c').Replace('ç', 'c').Replace('€', 'e').Replace('|', ' ').Replace('\\', ' ').Replace('£', ' ').Replace('§', ' ').Replace('[', ' ').Replace('#', ' ').Replace('!', ' ').Replace('Ù', 'u').Replace(
                'Ö', 'o').Replace('Ü', 'u').Replace('Ñ', 'n').Replace('Ð', 'd').Replace('Ê', 'e').Replace('Ë', 'e').Replace('Î', 'i').Replace('Ï', 'i').Replace('Ô', 'o').Replace('Õ', 'o').Replace('Û', 'u').Replace('Ý', 'y').Replace(
                ']', ' ').Replace('`', ' ').Replace('{', ' ').Replace('}', ' ').Replace('~', ' ').Replace('ü', 'u').Replace('â', 'a').Replace('ä', 'a').Replace('å', 'a').Replace('ê', 'e').Replace('ë', 'e').Replace('ï', 'i').Replace(
                'î', 'i').Replace('Ä', 'a').Replace('Å', 'a').Replace('ô', 'o').Replace('ö', 'o').Replace('û', 'u').Replace('ÿ', 'y').Replace('ñ', 'n').Replace('Â', 'a').Replace('¥', 'y').Replace('ã', 'a').Replace('Ã', 'a').Replace(
                'õ', 'o').Replace('ý', 'y').Replace('é', 'e').Replace('à', 'a').Replace('è', 'e').Replace('ì', 'i').Replace('ò', 'o').Replace('ù', 'u').Replace('á', 'a').Replace('í', 'i').Replace('ó', 'o').Replace('É', 'e').Replace(
                'Á', 'a').Replace('À', 'a').Replace('È', 'e').Replace('Í', 'i').Replace('Ì', 'i').Replace('Ó', 'o').Replace('Ò', 'o').Replace('Ú', 'u').Replace('\t', ' ').Replace('\n', ' ').Replace('\r', ' ').Replace('°', ' ');
          
            return s;
            }

        private void CallExportForm(string spname) {
            Meta.Dispatcher.Edit(this, "export", "default", false, spname);
        }

        private void btnRiepilogoRitenute_Click(object sender, EventArgs e) {
            CallExportForm("exp_modello770_riepilogo_ritenute");
        }
    }
}