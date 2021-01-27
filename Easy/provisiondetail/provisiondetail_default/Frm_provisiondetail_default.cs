
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
using metaeasylibrary;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;


namespace provisiondetail_default {//UnDettVarBilancio//
	/// <summary>
	/// Summary description for frmUnDettVarBilancio.
	/// </summary>
	public class Frm_provisiondetail_default : System.Windows.Forms.Form {
		public dsmeta DS;
        private System.ComponentModel.IContainer components;
		MetaData Meta;
		private System.Windows.Forms.ImageList imageList1;
		
        CQueryHelper QHC;
        private GroupBox grbDettaglio;
        private Label label4;
        private TextBox txtDataDoc;
        private GroupBox grpImporto;
        private RadioButton rdbDiminuzione;
        private RadioButton rdbAumento;
        private TextBox txtImporto;
        private TextBox txtDescrizione;
        private Label label2;
        private GroupBox grbFondo;
        private GroupBox groupCredDeb;
        private TextBox txtCreDeb;
        private Label label6;
        private TextBox txtDenominazione;
        private Label lblDenominazione;
        private Label label1;
        private TextBox textBox1;
        private GroupBox grpCausale;
        private TextBox txtDescrizioneCausale;
        private TextBox txtCodiceCausale;
        private Button button2;
        private GroupBox groupBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button1;
        private TextBox textBox17;
        private Label label3;
        private TextBox txtDenominzioneFondo;
        private TextBox textBox4;
        private Label label5;
        private TextBox txtEsercizio;
        private Label label7;
        QueryHelper QHS;
		public Frm_provisiondetail_default() {
			InitializeComponent();
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_provisiondetail_default));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grbDettaglio = new System.Windows.Forms.GroupBox();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataDoc = new System.Windows.Forms.TextBox();
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbFondo = new System.Windows.Forms.GroupBox();
            this.txtDenominzioneFondo = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupCredDeb = new System.Windows.Forms.GroupBox();
            this.txtCreDeb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.grpCausale = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.DS = new provisiondetail_default.dsmeta();
            this.grbDettaglio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpImporto.SuspendLayout();
            this.grbFondo.SuspendLayout();
            this.groupCredDeb.SuspendLayout();
            this.grpCausale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // grbDettaglio
            // 
            this.grbDettaglio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDettaglio.Controls.Add(this.txtEsercizio);
            this.grbDettaglio.Controls.Add(this.label7);
            this.grbDettaglio.Controls.Add(this.textBox4);
            this.grbDettaglio.Controls.Add(this.label5);
            this.grbDettaglio.Controls.Add(this.groupBox1);
            this.grbDettaglio.Controls.Add(this.label4);
            this.grbDettaglio.Controls.Add(this.txtDataDoc);
            this.grbDettaglio.Controls.Add(this.grpImporto);
            this.grbDettaglio.Controls.Add(this.txtDescrizione);
            this.grbDettaglio.Controls.Add(this.label2);
            this.grbDettaglio.Location = new System.Drawing.Point(12, 375);
            this.grbDettaglio.Name = "grbDettaglio";
            this.grbDettaglio.Size = new System.Drawing.Size(628, 309);
            this.grbDettaglio.TabIndex = 21;
            this.grbDettaglio.TabStop = false;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(68, 22);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(100, 20);
            this.txtEsercizio.TabIndex = 62;
            this.txtEsercizio.Tag = "provisiondetail.ydetail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 61;
            this.label7.Text = "Esercizio";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(514, 25);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 60;
            this.textBox4.Tag = "provisiondetail.rownum";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(480, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 59;
            this.label5.Text = "Num.";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(259, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(356, 144);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
            this.groupBox1.Text = "Causale di reddito (se immessa genera un accertamento di budget)";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(120, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(225, 86);
            this.textBox2.TabIndex = 2;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "accmotiveapplied.motive";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(6, 108);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(339, 20);
            this.textBox3.TabIndex = 1;
            this.textBox3.Tag = "accmotiveapplied.codemotive?x";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 0;
            this.button1.TabStop = false;
            this.button1.Tag = "manage.accmotiveapplied.tree";
            this.button1.Text = "Causale";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "Data dettaglio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDataDoc
            // 
            this.txtDataDoc.Location = new System.Drawing.Point(22, 140);
            this.txtDataDoc.Name = "txtDataDoc";
            this.txtDataDoc.Size = new System.Drawing.Size(125, 20);
            this.txtDataDoc.TabIndex = 24;
            this.txtDataDoc.Tag = "provisiondetail.adate?provisiondetailview.adate";
            // 
            // grpImporto
            // 
            this.grpImporto.Controls.Add(this.rdbDiminuzione);
            this.grpImporto.Controls.Add(this.rdbAumento);
            this.grpImporto.Controls.Add(this.txtImporto);
            this.grpImporto.Location = new System.Drawing.Point(13, 62);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(240, 56);
            this.grpImporto.TabIndex = 21;
            this.grpImporto.TabStop = false;
            this.grpImporto.Tag = "provisiondetail.amount.valuesigned";
            this.grpImporto.Text = "Importo";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(140, 29);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(94, 16);
            this.rdbDiminuzione.TabIndex = 2;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbAumento
            // 
            this.rdbAumento.Checked = true;
            this.rdbAumento.Location = new System.Drawing.Point(140, 12);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(94, 16);
            this.rdbAumento.TabIndex = 1;
            this.rdbAumento.TabStop = true;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(6, 18);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "provisiondetail.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(16, 236);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(598, 51);
            this.txtDescrizione.TabIndex = 22;
            this.txtDescrizione.Tag = "provisiondetail.description?provisiondetailview.detaildescription";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Descrizione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grbFondo
            // 
            this.grbFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFondo.Controls.Add(this.txtDenominzioneFondo);
            this.grbFondo.Controls.Add(this.textBox17);
            this.grbFondo.Controls.Add(this.label1);
            this.grbFondo.Controls.Add(this.label3);
            this.grbFondo.Controls.Add(this.textBox1);
            this.grbFondo.Controls.Add(this.groupCredDeb);
            this.grbFondo.Controls.Add(this.txtDenominazione);
            this.grbFondo.Controls.Add(this.lblDenominazione);
            this.grbFondo.Location = new System.Drawing.Point(12, 12);
            this.grbFondo.Name = "grbFondo";
            this.grbFondo.Size = new System.Drawing.Size(628, 189);
            this.grbFondo.TabIndex = 50;
            this.grbFondo.TabStop = false;
            // 
            // txtDenominzioneFondo
            // 
            this.txtDenominzioneFondo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominzioneFondo.Location = new System.Drawing.Point(186, 13);
            this.txtDenominzioneFondo.Name = "txtDenominzioneFondo";
            this.txtDenominzioneFondo.Size = new System.Drawing.Size(436, 20);
            this.txtDenominzioneFondo.TabIndex = 59;
            this.txtDenominzioneFondo.Tag = "provision.title";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(41, 13);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(100, 20);
            this.textBox17.TabIndex = 58;
            this.textBox17.Tag = "provision.idprovision";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(453, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 55;
            this.label1.Text = "Data dettaglio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 57;
            this.label3.Text = "Num.";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(500, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(115, 20);
            this.textBox1.TabIndex = 54;
            this.textBox1.Tag = "provision.adate?provisiondetailview.provisionadate";
            // 
            // groupCredDeb
            // 
            this.groupCredDeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupCredDeb.Controls.Add(this.txtCreDeb);
            this.groupCredDeb.Controls.Add(this.label6);
            this.groupCredDeb.Location = new System.Drawing.Point(13, 111);
            this.groupCredDeb.Name = "groupCredDeb";
            this.groupCredDeb.Size = new System.Drawing.Size(602, 62);
            this.groupCredDeb.TabIndex = 52;
            this.groupCredDeb.TabStop = false;
            this.groupCredDeb.Tag = "AutoChoose.txtCreDeb.anagrafica.(active<>\'N\')";
            this.groupCredDeb.Text = "Anagrafica";
            // 
            // txtCreDeb
            // 
            this.txtCreDeb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreDeb.Location = new System.Drawing.Point(120, 23);
            this.txtCreDeb.Name = "txtCreDeb";
            this.txtCreDeb.Size = new System.Drawing.Size(474, 20);
            this.txtCreDeb.TabIndex = 1;
            this.txtCreDeb.Tag = "registry.title?provisiondetailview.registry";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Denominazione:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(84, 56);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(363, 50);
            this.txtDenominazione.TabIndex = 51;
            this.txtDenominazione.Tag = "provision.description?provisiondetailview.description";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(6, 56);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(72, 42);
            this.lblDenominazione.TabIndex = 50;
            this.lblDenominazione.Text = "Descrizione Fondo:";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCausale
            // 
            this.grpCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCausale.Controls.Add(this.txtDescrizioneCausale);
            this.grpCausale.Controls.Add(this.txtCodiceCausale);
            this.grpCausale.Controls.Add(this.button2);
            this.grpCausale.Location = new System.Drawing.Point(12, 225);
            this.grpCausale.Name = "grpCausale";
            this.grpCausale.Size = new System.Drawing.Size(628, 144);
            this.grpCausale.TabIndex = 51;
            this.grpCausale.TabStop = false;
            this.grpCausale.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
            this.grpCausale.Text = "Causale di reddito (se immessa genera un accertamento di budget)";
            // 
            // txtDescrizioneCausale
            // 
            this.txtDescrizioneCausale.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneCausale.Location = new System.Drawing.Point(120, 16);
            this.txtDescrizioneCausale.Multiline = true;
            this.txtDescrizioneCausale.Name = "txtDescrizioneCausale";
            this.txtDescrizioneCausale.ReadOnly = true;
            this.txtDescrizioneCausale.Size = new System.Drawing.Size(497, 86);
            this.txtDescrizioneCausale.TabIndex = 2;
            this.txtDescrizioneCausale.TabStop = false;
            this.txtDescrizioneCausale.Tag = "accmotiveapplied.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodiceCausale.Location = new System.Drawing.Point(6, 108);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(611, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.TabStop = false;
            this.button2.Tag = "manage.accmotiveapplied.tree";
            this.button2.Text = "Causale";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_provisiondetail_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(659, 701);
            this.Controls.Add(this.grpCausale);
            this.Controls.Add(this.grbFondo);
            this.Controls.Add(this.grbDettaglio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_provisiondetail_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.grbDettaglio.ResumeLayout(false);
            this.grbDettaglio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.grbFondo.ResumeLayout(false);
            this.grbFondo.PerformLayout();
            this.groupCredDeb.ResumeLayout(false);
            this.groupCredDeb.PerformLayout();
            this.grpCausale.ResumeLayout(false);
            this.grpCausale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            HelpForm.SetDenyNull(DS.provisiondetail.Columns["description"], true);
            HelpForm.SetDenyNull(DS.provisiondetail.Columns["adate"], true);
            HelpForm.SetDenyNull(DS.provisiondetail.Columns["amount"], true);


            string filterEpOperationRicavo = QHS.CmpEq("idepoperation", "ric_accantonamento");
            //string filterEpOperationCosto = QHS.CmpEq("idepoperation", "costo_accantonamento");

            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationRicavo;

            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationRicavo);
        }

        public void MetaData_AfterFill() {
            txtEsercizio.ReadOnly = true;
            enableControls(false);
        }

        public void MetaData_AfterClear() {
            txtImporto.Text = "";
            rdbAumento.Checked = false;
            rdbDiminuzione.Checked = false;
            enableControls(true);
        }

        private void enableControls(bool abilita) {
            grbDettaglio.Enabled = abilita;
            grbFondo.Enabled = abilita;
            txtEsercizio.ReadOnly = true;
        }
        }
}
