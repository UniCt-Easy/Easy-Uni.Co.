
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;

namespace itinerationrefundkind_default {//ClassSpeseMissione//
	/// <summary>
	/// Summary description for frmclassspesemissione.
	/// </summary>
	public class Frm_itinerationrefundkind_default : MetaDataForm {
		MetaData Meta;
		private System.Windows.Forms.ImageList images;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox txtCodiceCausale;
		private System.Windows.Forms.Button button2;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private GroupBox groupBox3;
        private RadioButton radioButton4;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton radioButton6;
        private RadioButton radioButton5;
        private RadioButton radioButton8;
        private RadioButton radioButton7;
        private GroupBox groupBox4;
        private CheckBox checkBox10;
        private CheckBox checkBox9;
        private CheckBox checkBox8;
        private CheckBox checkBox7;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private CheckBox checkBox4;
        private CheckBox checkBox11;
        private CheckBox checkBox12;
		private GroupBox grpTracciabilità;
		private CheckBox chkApplyTax;
		private CheckBox chkAmountNotIncluded;
		private CheckBox chkAttachmentNotBlocking;
		private CheckBox chkAttachmentBlocking;
		private CheckBox chkTraceability;
		private GroupBox groupBox1;
		private ComboBox comboTipo;
		private System.ComponentModel.IContainer components;

		public Frm_itinerationrefundkind_default() {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_itinerationrefundkind_default));
			this.images = new System.Windows.Forms.ImageList(this.components);
			this.grpTracciabilità = new System.Windows.Forms.GroupBox();
			this.chkApplyTax = new System.Windows.Forms.CheckBox();
			this.chkAmountNotIncluded = new System.Windows.Forms.CheckBox();
			this.chkAttachmentNotBlocking = new System.Windows.Forms.CheckBox();
			this.chkAttachmentBlocking = new System.Windows.Forms.CheckBox();
			this.chkTraceability = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.checkBox12 = new System.Windows.Forms.CheckBox();
			this.checkBox11 = new System.Windows.Forms.CheckBox();
			this.checkBox10 = new System.Windows.Forms.CheckBox();
			this.checkBox9 = new System.Windows.Forms.CheckBox();
			this.checkBox8 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.radioButton8 = new System.Windows.Forms.RadioButton();
			this.radioButton7 = new System.Windows.Forms.RadioButton();
			this.radioButton6 = new System.Windows.Forms.RadioButton();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.txtCodiceCausale = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.DS = new itinerationrefundkind_default.vistaForm();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.comboTipo = new System.Windows.Forms.ComboBox();
			this.grpTracciabilità.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// images
			// 
			this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
			this.images.TransparentColor = System.Drawing.Color.Transparent;
			this.images.Images.SetKeyName(0, "");
			this.images.Images.SetKeyName(1, "");
			this.images.Images.SetKeyName(2, "");
			this.images.Images.SetKeyName(3, "");
			this.images.Images.SetKeyName(4, "");
			this.images.Images.SetKeyName(5, "");
			this.images.Images.SetKeyName(6, "");
			this.images.Images.SetKeyName(7, "");
			this.images.Images.SetKeyName(8, "");
			this.images.Images.SetKeyName(9, "");
			this.images.Images.SetKeyName(10, "");
			this.images.Images.SetKeyName(11, "");
			this.images.Images.SetKeyName(12, "");
			this.images.Images.SetKeyName(13, "");
			// 
			// grpTracciabilità
			// 
			this.grpTracciabilità.Controls.Add(this.chkApplyTax);
			this.grpTracciabilità.Controls.Add(this.chkAmountNotIncluded);
			this.grpTracciabilità.Controls.Add(this.chkAttachmentNotBlocking);
			this.grpTracciabilità.Controls.Add(this.chkAttachmentBlocking);
			this.grpTracciabilità.Controls.Add(this.chkTraceability);
			this.grpTracciabilità.Location = new System.Drawing.Point(14, 346);
			this.grpTracciabilità.Name = "grpTracciabilità";
			this.grpTracciabilità.Size = new System.Drawing.Size(684, 159);
			this.grpTracciabilità.TabIndex = 11;
			this.grpTracciabilità.TabStop = false;
			this.grpTracciabilità.Text = "Tracciabilità documentata";
			// 
			// chkApplyTax
			// 
			this.chkApplyTax.AutoSize = true;
			this.chkApplyTax.Location = new System.Drawing.Point(10, 127);
			this.chkApplyTax.Name = "chkApplyTax";
			this.chkApplyTax.Size = new System.Drawing.Size(448, 17);
			this.chkApplyTax.TabIndex = 4;
			this.chkApplyTax.Tag = "itinerationrefundkind.flagtraceability:4";
			this.chkApplyTax.Text = "Applica le ritenute/contributi all\'importo della spesa tracciabile in assenza del" +
    "la tracciabilità";
			this.chkApplyTax.UseVisualStyleBackColor = true;
			this.chkApplyTax.CheckedChanged += new System.EventHandler(this.chkApplyTax_CheckedChanged);
			// 
			// chkAmountNotIncluded
			// 
			this.chkAmountNotIncluded.AutoSize = true;
			this.chkAmountNotIncluded.Location = new System.Drawing.Point(10, 91);
			this.chkAmountNotIncluded.Name = "chkAmountNotIncluded";
			this.chkAmountNotIncluded.Size = new System.Drawing.Size(517, 17);
			this.chkAmountNotIncluded.TabIndex = 3;
			this.chkAmountNotIncluded.Tag = "itinerationrefundkind.flagtraceability:3";
			this.chkAmountNotIncluded.Text = "Pagare la spesa integralmente non considerandola imponibile (Dovrà essere trasmes" +
    "sa all\'ufficio stipendi)";
			this.chkAmountNotIncluded.UseVisualStyleBackColor = true;
			this.chkAmountNotIncluded.CheckedChanged += new System.EventHandler(this.chkAmountNotIncluded_CheckedChanged);
			// 
			// chkAttachmentNotBlocking
			// 
			this.chkAttachmentNotBlocking.AutoSize = true;
			this.chkAttachmentNotBlocking.Location = new System.Drawing.Point(10, 67);
			this.chkAttachmentNotBlocking.Name = "chkAttachmentNotBlocking";
			this.chkAttachmentNotBlocking.Size = new System.Drawing.Size(347, 17);
			this.chkAttachmentNotBlocking.TabIndex = 2;
			this.chkAttachmentNotBlocking.Tag = "itinerationrefundkind.flagtraceability:2";
			this.chkAttachmentNotBlocking.Text = "Obbligo allegato Ricevuta di Pagamento tracciabile (Non Bloccante)";
			this.chkAttachmentNotBlocking.UseVisualStyleBackColor = true;
			this.chkAttachmentNotBlocking.CheckedChanged += new System.EventHandler(this.chkAttachmentNotBlocking_CheckedChanged);
			// 
			// chkAttachmentBlocking
			// 
			this.chkAttachmentBlocking.AutoSize = true;
			this.chkAttachmentBlocking.Location = new System.Drawing.Point(10, 44);
			this.chkAttachmentBlocking.Name = "chkAttachmentBlocking";
			this.chkAttachmentBlocking.Size = new System.Drawing.Size(324, 17);
			this.chkAttachmentBlocking.TabIndex = 1;
			this.chkAttachmentBlocking.Tag = "itinerationrefundkind.flagtraceability:1";
			this.chkAttachmentBlocking.Text = "Obbligo allegato Ricevuta di Pagamento tracciabile (Bloccante)";
			this.chkAttachmentBlocking.UseVisualStyleBackColor = true;
			this.chkAttachmentBlocking.CheckedChanged += new System.EventHandler(this.chkAttachmentBlocking_CheckedChanged);
			// 
			// chkTraceability
			// 
			this.chkTraceability.AutoSize = true;
			this.chkTraceability.Location = new System.Drawing.Point(10, 20);
			this.chkTraceability.Name = "chkTraceability";
			this.chkTraceability.Size = new System.Drawing.Size(126, 17);
			this.chkTraceability.TabIndex = 0;
			this.chkTraceability.Tag = "itinerationrefundkind.flagtraceability:0";
			this.chkTraceability.Text = "Richiesta tracciabilità";
			this.chkTraceability.UseVisualStyleBackColor = true;
			this.chkTraceability.CheckedChanged += new System.EventHandler(this.chkTraceability_CheckedChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.checkBox12);
			this.groupBox4.Controls.Add(this.checkBox11);
			this.groupBox4.Controls.Add(this.checkBox10);
			this.groupBox4.Controls.Add(this.checkBox9);
			this.groupBox4.Controls.Add(this.checkBox8);
			this.groupBox4.Controls.Add(this.checkBox7);
			this.groupBox4.Controls.Add(this.checkBox6);
			this.groupBox4.Controls.Add(this.checkBox5);
			this.groupBox4.Controls.Add(this.checkBox4);
			this.groupBox4.Location = new System.Drawing.Point(336, 210);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(362, 133);
			this.groupBox4.TabIndex = 10;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Nascondi sezioni";
			// 
			// checkBox12
			// 
			this.checkBox12.AutoSize = true;
			this.checkBox12.Location = new System.Drawing.Point(178, 65);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new System.Drawing.Size(123, 17);
			this.checkBox12.TabIndex = 8;
			this.checkBox12.Tag = "itinerationrefundkind.flagvisible:8";
			this.checkBox12.Text = "Percentuale anticipo";
			this.checkBox12.UseVisualStyleBackColor = true;
			// 
			// checkBox11
			// 
			this.checkBox11.AutoSize = true;
			this.checkBox11.Location = new System.Drawing.Point(178, 42);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new System.Drawing.Size(181, 17);
			this.checkBox11.TabIndex = 7;
			this.checkBox11.Tag = "itinerationrefundkind.flagvisible:7";
			this.checkBox11.Text = "Comunicazioni per il responsabile";
			this.checkBox11.UseVisualStyleBackColor = true;
			// 
			// checkBox10
			// 
			this.checkBox10.AutoSize = true;
			this.checkBox10.Location = new System.Drawing.Point(178, 19);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new System.Drawing.Size(91, 17);
			this.checkBox10.TabIndex = 6;
			this.checkBox10.Tag = "itinerationrefundkind.flagvisible:6";
			this.checkBox10.Text = "Limiti di spesa";
			this.checkBox10.UseVisualStyleBackColor = true;
			// 
			// checkBox9
			// 
			this.checkBox9.AutoSize = true;
			this.checkBox9.Location = new System.Drawing.Point(178, 88);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new System.Drawing.Size(56, 17);
			this.checkBox9.TabIndex = 5;
			this.checkBox9.Tag = "itinerationrefundkind.flagvisible:5";
			this.checkBox9.Text = "Valuta";
			this.checkBox9.UseVisualStyleBackColor = true;
			// 
			// checkBox8
			// 
			this.checkBox8.AutoSize = true;
			this.checkBox8.Location = new System.Drawing.Point(8, 111);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new System.Drawing.Size(112, 17);
			this.checkBox8.TabIndex = 4;
			this.checkBox8.Tag = "itinerationrefundkind.flagvisible:4";
			this.checkBox8.Text = "Importo accordato";
			this.checkBox8.UseVisualStyleBackColor = true;
			// 
			// checkBox7
			// 
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(8, 88);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(151, 17);
			this.checkBox7.TabIndex = 3;
			this.checkBox7.Tag = "itinerationrefundkind.flagvisible:3";
			this.checkBox7.Text = "Importo non rendicontabile";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(8, 65);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(63, 17);
			this.checkBox6.TabIndex = 2;
			this.checkBox6.Tag = "itinerationrefundkind.flagvisible:2";
			this.checkBox6.Text = "Località";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(8, 42);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(79, 17);
			this.checkBox5.TabIndex = 1;
			this.checkBox5.Tag = "itinerationrefundkind.flagvisible:1";
			this.checkBox5.Text = "Inizio e fine";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(8, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(81, 17);
			this.checkBox4.TabIndex = 0;
			this.checkBox4.Tag = "itinerationrefundkind.flagvisible:0";
			this.checkBox4.Text = "Documento";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.radioButton8);
			this.groupBox3.Controls.Add(this.radioButton7);
			this.groupBox3.Controls.Add(this.radioButton6);
			this.groupBox3.Controls.Add(this.radioButton5);
			this.groupBox3.Controls.Add(this.radioButton4);
			this.groupBox3.Controls.Add(this.radioButton3);
			this.groupBox3.Controls.Add(this.radioButton2);
			this.groupBox3.Controls.Add(this.radioButton1);
			this.groupBox3.Location = new System.Drawing.Point(14, 210);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(290, 130);
			this.groupBox3.TabIndex = 9;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Mezzo di Trasporto";
			// 
			// radioButton8
			// 
			this.radioButton8.AutoSize = true;
			this.radioButton8.Location = new System.Drawing.Point(157, 100);
			this.radioButton8.Name = "radioButton8";
			this.radioButton8.Size = new System.Drawing.Size(124, 17);
			this.radioButton8.TabIndex = 21;
			this.radioButton8.TabStop = true;
			this.radioButton8.Tag = "itinerationrefundkind.flagmedia::7";
			this.radioButton8.Text = "Altro (Mezzo straord.)";
			this.radioButton8.UseVisualStyleBackColor = true;
			// 
			// radioButton7
			// 
			this.radioButton7.AutoSize = true;
			this.radioButton7.Location = new System.Drawing.Point(13, 100);
			this.radioButton7.Name = "radioButton7";
			this.radioButton7.Size = new System.Drawing.Size(129, 17);
			this.radioButton7.TabIndex = 20;
			this.radioButton7.TabStop = true;
			this.radioButton7.Tag = "itinerationrefundkind.flagmedia::6";
			this.radioButton7.Text = "Altro (Mezzo ordinario)";
			this.radioButton7.UseVisualStyleBackColor = true;
			// 
			// radioButton6
			// 
			this.radioButton6.AutoSize = true;
			this.radioButton6.Location = new System.Drawing.Point(157, 74);
			this.radioButton6.Name = "radioButton6";
			this.radioButton6.Size = new System.Drawing.Size(108, 17);
			this.radioButton6.TabIndex = 19;
			this.radioButton6.TabStop = true;
			this.radioButton6.Tag = "itinerationrefundkind.flagmedia::5";
			this.radioButton6.Text = "Mezzo a noleggio";
			this.radioButton6.UseVisualStyleBackColor = true;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(13, 74);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(96, 17);
			this.radioButton5.TabIndex = 18;
			this.radioButton5.TabStop = true;
			this.radioButton5.Tag = "itinerationrefundkind.flagmedia::4";
			this.radioButton5.Text = "Mezzo amm.ne";
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(157, 49);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(51, 17);
			this.radioButton4.TabIndex = 17;
			this.radioButton4.TabStop = true;
			this.radioButton4.Tag = "itinerationrefundkind.flagmedia::3";
			this.radioButton4.Text = "Nave";
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(13, 48);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(62, 17);
			this.radioButton3.TabIndex = 16;
			this.radioButton3.TabStop = true;
			this.radioButton3.Tag = "itinerationrefundkind.flagmedia::2";
			this.radioButton3.Text = "Pullman";
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(157, 21);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(53, 17);
			this.radioButton2.TabIndex = 15;
			this.radioButton2.TabStop = true;
			this.radioButton2.Tag = "itinerationrefundkind.flagmedia::1";
			this.radioButton2.Text = "Treno";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(13, 21);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(53, 17);
			this.radioButton1.TabIndex = 14;
			this.radioButton1.TabStop = true;
			this.radioButton1.Tag = "itinerationrefundkind.flagmedia::0";
			this.radioButton1.Text = "Aereo";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(24, 155);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(184, 17);
			this.checkBox2.TabIndex = 6;
			this.checkBox2.Tag = "itinerationrefundkind.flagadvance:S:N";
			this.checkBox2.Text = "Valido per la richiesta dell\'anticipo";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(24, 187);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(176, 17);
			this.checkBox3.TabIndex = 7;
			this.checkBox3.Tag = "itinerationrefundkind.flagbalance:S:N";
			this.checkBox3.Text = "Valido per il saldo della missione";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(195, 33);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 3;
			this.checkBox1.Tag = "itinerationrefundkind.active:S:N";
			this.checkBox1.Text = "Attiva";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(26, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Descrizione:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.textBox5);
			this.groupBox2.Controls.Add(this.txtCodiceCausale);
			this.groupBox2.Controls.Add(this.button2);
			this.groupBox2.Location = new System.Drawing.Point(363, 111);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(335, 89);
			this.groupBox2.TabIndex = 5;
			this.groupBox2.TabStop = false;
			this.groupBox2.Tag = "AutoManage.txtCodiceCausale.tree";
			this.groupBox2.Text = "Causale";
			// 
			// textBox5
			// 
			this.textBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.textBox5.Location = new System.Drawing.Point(123, 16);
			this.textBox5.Multiline = true;
			this.textBox5.Name = "textBox5";
			this.textBox5.ReadOnly = true;
			this.textBox5.Size = new System.Drawing.Size(206, 52);
			this.textBox5.TabIndex = 2;
			this.textBox5.TabStop = false;
			this.textBox5.Tag = "accmotiveapplied.motive";
			// 
			// txtCodiceCausale
			// 
			this.txtCodiceCausale.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtCodiceCausale.Location = new System.Drawing.Point(11, 48);
			this.txtCodiceCausale.Name = "txtCodiceCausale";
			this.txtCodiceCausale.Size = new System.Drawing.Size(104, 20);
			this.txtCodiceCausale.TabIndex = 1;
			this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?x";
			// 
			// button2
			// 
			this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.button2.Location = new System.Drawing.Point(11, 16);
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
			// 
			// txtCodice
			// 
			this.txtCodice.Location = new System.Drawing.Point(14, 31);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(100, 20);
			this.txtCodice.TabIndex = 1;
			this.txtCodice.Tag = "itinerationrefundkind.codeitinerationrefundkind";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(14, 75);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(323, 71);
			this.textBox2.TabIndex = 2;
			this.textBox2.Tag = "itinerationrefundkind.description";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(25, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 8;
			this.label1.Text = "Codice:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboTipo);
			this.groupBox1.Location = new System.Drawing.Point(357, 27);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(298, 48);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tipo";
			// 
			// comboTipo
			// 
			this.comboTipo.DataSource = this.DS.itinerationrefundkindgroup;
			this.comboTipo.DisplayMember = "description";
			this.comboTipo.FormattingEnabled = true;
			this.comboTipo.Location = new System.Drawing.Point(17, 21);
			this.comboTipo.Name = "comboTipo";
			this.comboTipo.Size = new System.Drawing.Size(263, 21);
			this.comboTipo.TabIndex = 13;
			this.comboTipo.Tag = "itinerationrefundkind.iditinerationrefundkindgroup";
			this.comboTipo.ValueMember = "iditinerationrefundkindgroup";
			// 
			// Frm_itinerationrefundkind_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(711, 511);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpTracciabilità);
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.checkBox3);
			this.Controls.Add(this.checkBox2);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.txtCodice);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.checkBox1);
			this.Name = "Frm_itinerationrefundkind_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmitinerationrefundkind";
			this.grpTracciabilità.ResumeLayout(false);
			this.grpTracciabilità.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		
		public void MetaData_AfterLink() {
			Meta= MetaData.GetMetaData(this);
			
            string filterEpOperationSF = Meta.QHS.CmpEq("idepoperation", "missioni");
            string filterEpOperationEP = Meta.QHS.CmpEq("idepoperation", "missioni");
			GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationSF);
			DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams]=filterEpOperationEP;
            HelpForm.SetDenyNull(DS.itinerationrefundkind.Columns["flagbalance"], true);
            HelpForm.SetDenyNull(DS.itinerationrefundkind.Columns["flagadvance"], true);
            HelpForm.SetDenyNull(DS.itinerationrefundkind.Columns["flagtraceability"], true);
            GetData.CacheTable(DS.itinerationrefundkindgroup, null, "description", true);
        }


        public void MetaData_AfterFill () {
            if (Meta.EditMode) {
                txtCodice.ReadOnly = true;
				if (Meta.FirstFillForThisRow)
					Meta.getData.GetTemporaryValues(DS.itinerationrefundkind);
			}
            else {
                txtCodice.ReadOnly = false;
			}
			impostaTracciabilita();
		}

		public void MetaData_AfterClear()
		{
			chkAttachmentBlocking.Enabled = true;
			chkAttachmentNotBlocking.Enabled = true;
			chkAmountNotIncluded.Enabled = true;
			chkApplyTax.Enabled = true;
		}

		#region task 19904
		// flag traceability
		// 0 -- > Spesa Non Imponibile solo se il pagamento è tracciabile
		// 1 -- > Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante) 
		// 2 -- > Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)
		// 3 -- > Non includere l'importo della spesa imponibile nel pagamento della missione per l' applicazione delle ritenute, deve essere  trasmessa all'ufficio stipendi
		// 4 -- > Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità
		private void impostaTracciabilita()
		{
			if (DS.itinerationrefundkind.Rows.Count == 0) return;
			DataRow Curr = DS.itinerationrefundkind.Rows[0];

			int flagTraceability = CfgFn.GetNoNullInt32(Curr["flagtraceability"]);

			// "Richiesta tracciabilità" non è flaggato
			// tolgo l'eventuale flag dagli altri checkbox e li disabilito
			if ((flagTraceability & 1) == 0)
			{
				if (flagTraceability > 1)
				{
					chkAttachmentBlocking.Checked = false;
					chkAttachmentNotBlocking.Checked = false;
					chkAmountNotIncluded.Checked = false;
					chkApplyTax.Checked = false;
				}

				chkAttachmentBlocking.Enabled = false;
				chkAttachmentNotBlocking.Enabled = false;
				chkAmountNotIncluded.Enabled = false;
				chkApplyTax.Enabled = false;
			}
			// è stato flaggato "Richiesta tracciabilità"
			// abilito gli altri checkbox
			else
			{
				chkAttachmentBlocking.Enabled = true;
				chkAttachmentNotBlocking.Enabled = true;
				chkAmountNotIncluded.Enabled = true;
				chkApplyTax.Enabled = true;

				// è stato flaggato "Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità"
				// rimuovo l'eventuale flag da "Non includere l'importo della spesa imponibile nel pagamento della missione per l'applicazione delle ritenute, deve essere trasmessa all'ufficio stipendi" e lo disabilito
				if ((flagTraceability & 16) != 0)
				{
					chkAmountNotIncluded.Checked = false;

					chkAmountNotIncluded.Enabled = false;
				}

				// è stato flaggato "Non includere l'importo della spesa imponibile nel pagamento della missione per l'applicazione delle ritenute, deve essere trasmessa all'ufficio stipendi"
				// rimuovo l'eventuale flag da "Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità" e lo disabilito
				if ((flagTraceability & 8) != 0)
				{
					chkApplyTax.Checked = false;

					chkApplyTax.Enabled = false;
				}

				// è stato flaggato "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)"
				// rimuovo l'eventualeflag da "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante)" e lo disabilito
				if ((flagTraceability & 4) != 0)
				{
					chkAttachmentBlocking.Checked = false;

					chkAttachmentBlocking.Enabled = false;
				}

				// è stato flaggato "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante)"
				// rimuovo l'eventualeflag da "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)" e lo disabilito
				if ((flagTraceability & 2) != 0)
				{
					chkAttachmentNotBlocking.Checked = false;

					chkAttachmentNotBlocking.Enabled = false;
				}
			}
		}

		private void chkTraceability_CheckedChanged(object sender, EventArgs e)
		{
			if (Meta.EditMode || Meta.InsertMode)
			{
				// è stato flaggato "Richiesta tracciabilità"
				// abilito gli altri checkbox
				if (chkTraceability.Checked)
				{
					chkAttachmentBlocking.Enabled = true;
					chkAttachmentNotBlocking.Enabled = true;
					chkAmountNotIncluded.Enabled = true;
					chkApplyTax.Enabled = true;
				}
				// "Richiesta tracciabilità" non è flaggato
				// tolgo l'eventuale flag dagli altri checkbox e li disabilito
				else
				{
					chkAttachmentBlocking.Checked = false;
					chkAttachmentNotBlocking.Checked = false;
					chkAmountNotIncluded.Checked = false;
					chkApplyTax.Checked = false;

					chkAttachmentBlocking.Enabled = false;
					chkAttachmentNotBlocking.Enabled = false;
					chkAmountNotIncluded.Enabled = false;
					chkApplyTax.Enabled = false;
				}
			}
		}

		private void chkAmountNotIncluded_CheckedChanged(object sender, EventArgs e)
		{
			if (Meta.EditMode || Meta.InsertMode)
			{
				// è stato flaggato "Non includere l'importo della spesa imponibile nel pagamento della missione per l'applicazione delle ritenute, deve essere trasmessa all'ufficio stipendi"
				// rimuovo l'eventuale flag da "Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità" e lo disabilito
				if (chkAmountNotIncluded.Checked)
				{
					chkApplyTax.Checked = false;

					chkApplyTax.Enabled = false;
				}
				// è stato tolto il flag "Non includere l'importo della spesa imponibile nel pagamento della missione per l'applicazione delle ritenute, deve essere trasmessa all'ufficio stipendi"
				// abilito il checkbox "Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità"
				else
				{
					chkApplyTax.Enabled = true;
				}
			}
		}

		private void chkApplyTax_CheckedChanged(object sender, EventArgs e)
		{
			if (Meta.EditMode || Meta.InsertMode)
			{
				// è stato flaggato "Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità"
				// rimuovo l'eventuale flag da "Non includere l'importo della spesa imponibile nel pagamento della missione per l'applicazione delle ritenute, deve essere trasmessa all'ufficio stipendi" e lo disabilito
				if (chkApplyTax.Checked)
				{
					chkAmountNotIncluded.Checked = false;

					chkAmountNotIncluded.Enabled = false;
				}
				// è stato tolto il flag "Applica le ritenute/contributi all'importo della spesa tracciabile in assenza della tracciabilità"
				// abilito il checkbox "Non includere l'importo della spesa imponibile nel pagamento della missione per l'applicazione delle ritenute, deve essere trasmessa all'ufficio stipendi"
				else
				{
					chkAmountNotIncluded.Enabled = true;
				}
			}
		}

		private void chkAttachmentBlocking_CheckedChanged(object sender, EventArgs e)
		{
			if (Meta.EditMode || Meta.InsertMode)
			{
				// è stato flaggato "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante)"
				// rimuovo l'eventualeflag da "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)" e lo disabilito
				if (chkAttachmentBlocking.Checked)
				{
					chkAttachmentNotBlocking.Checked = false;

					chkAttachmentNotBlocking.Enabled = false;
				}
				// è stato tolto il flag "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante)"
				// abilito il checkbox "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)"
				else
				{
					chkAttachmentNotBlocking.Enabled = true;
				}
			}
		}

		private void chkAttachmentNotBlocking_CheckedChanged(object sender, EventArgs e)
		{
			if (Meta.EditMode || Meta.InsertMode)
			{
				// è stato flaggato "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)"
				// rimuovo l'eventualeflag da "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante)" e lo disabilito
				if (chkAttachmentNotBlocking.Checked)
				{
					chkAttachmentBlocking.Checked = false;

					chkAttachmentBlocking.Enabled = false;
				}
				// è stato tolto il flag "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Non Bloccante)"
				// abilito il checkbox "Obbligatorietà allegato digitale attestante il pagamento tracciabile (Bloccante)"
				else
				{
					chkAttachmentBlocking.Enabled = true;
				}
			}
		}
		#endregion
	}
}
