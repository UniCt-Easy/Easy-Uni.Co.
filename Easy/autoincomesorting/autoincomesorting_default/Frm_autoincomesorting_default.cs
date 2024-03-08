
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;

namespace autoincomesorting_default {//autoclassentrate_config//
	/// <summary>
	/// Summary description for FrmAutoClassentrate_Config.
	/// </summary>
	public class Frm_autoincomesorting_default : MetaDataForm {
		private System.Windows.Forms.Button btnDerived;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox TxtDenominatore;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox TxtNumeratore;
		private System.Windows.Forms.Label lblPercentuale;
		public System.Windows.Forms.Label labelignoradate;
		public System.Windows.Forms.CheckBox chkIgnoraDate;
		public System.Windows.Forms.TextBox valoreS5;
		public System.Windows.Forms.TextBox valoreN5;
		public System.Windows.Forms.TextBox valoreS4;
		public System.Windows.Forms.TextBox valoreN4;
		public System.Windows.Forms.TextBox valoreN2;
		public System.Windows.Forms.TextBox valoreS3;
		public System.Windows.Forms.TextBox valoreS2;
		public System.Windows.Forms.TextBox valoreN1;
		public System.Windows.Forms.TextBox valoreN3;
		public System.Windows.Forms.TextBox valoreS1;
		public System.Windows.Forms.Label labelS5;
		public System.Windows.Forms.Label labelS4;
		public System.Windows.Forms.Label labelS3;
		public System.Windows.Forms.Label labelS2;
		public System.Windows.Forms.Label labelS1;
		public System.Windows.Forms.Label labelN5;
		public System.Windows.Forms.Label labelN4;
		public System.Windows.Forms.Label labelN3;
		public System.Windows.Forms.Label labelN2;
		public System.Windows.Forms.Label labelN1;
		private System.Windows.Forms.GroupBox gboxClassMov;
		private System.Windows.Forms.TextBox txtDescrizioneMov;
		private System.Windows.Forms.TextBox txtCodiceMov;
		private System.Windows.Forms.Button btnCodiceMov;
		private System.Windows.Forms.ComboBox cmbTipoMov;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ComboBox cmbTipoCred;
		private System.Windows.Forms.GroupBox gboxClassCred;
		private System.Windows.Forms.TextBox txtDescrizioneCred;
		private System.Windows.Forms.TextBox txtCodiceCred;
		private System.Windows.Forms.Button btnCodiceCred;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gboxBilAnnuale;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.TextBox txtCodiceBilancio;
		private System.Windows.Forms.TextBox txtDenominazioneBilancio;
		public vistaForm DS;
		MetaData Meta;
		DataAccess Conn;
		private System.Windows.Forms.Button btnConflitti;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		public System.Windows.Forms.Label labelV5;
		public System.Windows.Forms.Label labelV4;
		public System.Windows.Forms.Label labelV3;
		public System.Windows.Forms.Label labelV2;
		public System.Windows.Forms.Label labelV1;
		public System.Windows.Forms.TextBox valoreV5;
		public System.Windows.Forms.TextBox valoreV4;
		public System.Windows.Forms.TextBox valoreV2;
		public System.Windows.Forms.TextBox valoreV1;
		public System.Windows.Forms.TextBox valoreV3;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox gBoxUpb;
		private System.Windows.Forms.TextBox txtDescrizioneUpb;
		private System.Windows.Forms.TextBox txtUpb;
		private System.Windows.Forms.Button btnUpb;
		private System.ComponentModel.IContainer components;

		public Frm_autoincomesorting_default() {
			InitializeComponent();
			DataAccess.SetTableForReading(DS.Tables["classmovimenti1"],"sorting");
            DataAccess.SetTableForReading(DS.Tables["sortingkind1"], "sortingkind");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_autoincomesorting_default));
            this.btnDerived = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.valoreV5 = new System.Windows.Forms.TextBox();
            this.valoreV4 = new System.Windows.Forms.TextBox();
            this.valoreV2 = new System.Windows.Forms.TextBox();
            this.valoreV1 = new System.Windows.Forms.TextBox();
            this.valoreV3 = new System.Windows.Forms.TextBox();
            this.labelV5 = new System.Windows.Forms.Label();
            this.labelV4 = new System.Windows.Forms.Label();
            this.labelV3 = new System.Windows.Forms.Label();
            this.labelV2 = new System.Windows.Forms.Label();
            this.labelV1 = new System.Windows.Forms.Label();
            this.TxtDenominatore = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtNumeratore = new System.Windows.Forms.TextBox();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.labelignoradate = new System.Windows.Forms.Label();
            this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
            this.valoreS5 = new System.Windows.Forms.TextBox();
            this.valoreN5 = new System.Windows.Forms.TextBox();
            this.valoreS4 = new System.Windows.Forms.TextBox();
            this.valoreN4 = new System.Windows.Forms.TextBox();
            this.valoreN2 = new System.Windows.Forms.TextBox();
            this.valoreS3 = new System.Windows.Forms.TextBox();
            this.valoreS2 = new System.Windows.Forms.TextBox();
            this.valoreN1 = new System.Windows.Forms.TextBox();
            this.valoreN3 = new System.Windows.Forms.TextBox();
            this.valoreS1 = new System.Windows.Forms.TextBox();
            this.labelS5 = new System.Windows.Forms.Label();
            this.labelS4 = new System.Windows.Forms.Label();
            this.labelS3 = new System.Windows.Forms.Label();
            this.labelS2 = new System.Windows.Forms.Label();
            this.labelS1 = new System.Windows.Forms.Label();
            this.labelN5 = new System.Windows.Forms.Label();
            this.labelN4 = new System.Windows.Forms.Label();
            this.labelN3 = new System.Windows.Forms.Label();
            this.labelN2 = new System.Windows.Forms.Label();
            this.labelN1 = new System.Windows.Forms.Label();
            this.gboxClassMov = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneMov = new System.Windows.Forms.TextBox();
            this.txtCodiceMov = new System.Windows.Forms.TextBox();
            this.btnCodiceMov = new System.Windows.Forms.Button();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.DS = new autoincomesorting_default.vistaForm();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoCred = new System.Windows.Forms.ComboBox();
            this.gboxClassCred = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCred = new System.Windows.Forms.TextBox();
            this.txtCodiceCred = new System.Windows.Forms.TextBox();
            this.btnCodiceCred = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.btnConflitti = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gBoxUpb = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
            this.txtUpb = new System.Windows.Forms.TextBox();
            this.btnUpb = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.gboxClassMov.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboxClassCred.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gBoxUpb.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDerived
            // 
            this.btnDerived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDerived.Location = new System.Drawing.Point(640, 8);
            this.btnDerived.Name = "btnDerived";
            this.btnDerived.Size = new System.Drawing.Size(120, 23);
            this.btnDerived.TabIndex = 16;
            this.btnDerived.TabStop = false;
            this.btnDerived.Text = "Elenca più specifici";
            this.btnDerived.Click += new System.EventHandler(this.btnDerived_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.valoreV5);
            this.groupBox3.Controls.Add(this.valoreV4);
            this.groupBox3.Controls.Add(this.valoreV2);
            this.groupBox3.Controls.Add(this.valoreV1);
            this.groupBox3.Controls.Add(this.valoreV3);
            this.groupBox3.Controls.Add(this.labelV5);
            this.groupBox3.Controls.Add(this.labelV4);
            this.groupBox3.Controls.Add(this.labelV3);
            this.groupBox3.Controls.Add(this.labelV2);
            this.groupBox3.Controls.Add(this.labelV1);
            this.groupBox3.Controls.Add(this.TxtDenominatore);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtNumeratore);
            this.groupBox3.Controls.Add(this.lblPercentuale);
            this.groupBox3.Controls.Add(this.labelignoradate);
            this.groupBox3.Controls.Add(this.chkIgnoraDate);
            this.groupBox3.Controls.Add(this.valoreS5);
            this.groupBox3.Controls.Add(this.valoreN5);
            this.groupBox3.Controls.Add(this.valoreS4);
            this.groupBox3.Controls.Add(this.valoreN4);
            this.groupBox3.Controls.Add(this.valoreN2);
            this.groupBox3.Controls.Add(this.valoreS3);
            this.groupBox3.Controls.Add(this.valoreS2);
            this.groupBox3.Controls.Add(this.valoreN1);
            this.groupBox3.Controls.Add(this.valoreN3);
            this.groupBox3.Controls.Add(this.valoreS1);
            this.groupBox3.Controls.Add(this.labelS5);
            this.groupBox3.Controls.Add(this.labelS4);
            this.groupBox3.Controls.Add(this.labelS3);
            this.groupBox3.Controls.Add(this.labelS2);
            this.groupBox3.Controls.Add(this.labelS1);
            this.groupBox3.Controls.Add(this.labelN5);
            this.groupBox3.Controls.Add(this.labelN4);
            this.groupBox3.Controls.Add(this.labelN3);
            this.groupBox3.Controls.Add(this.labelN2);
            this.groupBox3.Controls.Add(this.labelN1);
            this.groupBox3.Controls.Add(this.gboxClassMov);
            this.groupBox3.Controls.Add(this.cmbTipoMov);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(8, 232);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(752, 240);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            this.groupBox3.Text = "Classificazione movimento";
            // 
            // valoreV5
            // 
            this.valoreV5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreV5.Location = new System.Drawing.Point(600, 198);
            this.valoreV5.Name = "valoreV5";
            this.valoreV5.Size = new System.Drawing.Size(144, 20);
            this.valoreV5.TabIndex = 299;
            this.valoreV5.Tag = "autoincomesorting.defaultv5";
            // 
            // valoreV4
            // 
            this.valoreV4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreV4.Location = new System.Drawing.Point(600, 158);
            this.valoreV4.Name = "valoreV4";
            this.valoreV4.Size = new System.Drawing.Size(144, 20);
            this.valoreV4.TabIndex = 297;
            this.valoreV4.Tag = "autoincomesorting.defaultv4";
            // 
            // valoreV2
            // 
            this.valoreV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreV2.Location = new System.Drawing.Point(600, 78);
            this.valoreV2.Name = "valoreV2";
            this.valoreV2.Size = new System.Drawing.Size(144, 20);
            this.valoreV2.TabIndex = 293;
            this.valoreV2.Tag = "autoincomesorting.defaultv2";
            // 
            // valoreV1
            // 
            this.valoreV1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreV1.Location = new System.Drawing.Point(600, 38);
            this.valoreV1.Name = "valoreV1";
            this.valoreV1.Size = new System.Drawing.Size(144, 20);
            this.valoreV1.TabIndex = 291;
            this.valoreV1.Tag = "autoincomesorting.defaultv1";
            // 
            // valoreV3
            // 
            this.valoreV3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreV3.Location = new System.Drawing.Point(600, 118);
            this.valoreV3.Name = "valoreV3";
            this.valoreV3.Size = new System.Drawing.Size(144, 20);
            this.valoreV3.TabIndex = 295;
            this.valoreV3.Tag = "autoincomesorting.defaultv3";
            // 
            // labelV5
            // 
            this.labelV5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelV5.Location = new System.Drawing.Point(600, 182);
            this.labelV5.Name = "labelV5";
            this.labelV5.Size = new System.Drawing.Size(144, 16);
            this.labelV5.TabIndex = 298;
            this.labelV5.Tag = "sortingkind.lablev5";
            this.labelV5.Text = "labelV5";
            // 
            // labelV4
            // 
            this.labelV4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelV4.Location = new System.Drawing.Point(600, 142);
            this.labelV4.Name = "labelV4";
            this.labelV4.Size = new System.Drawing.Size(144, 16);
            this.labelV4.TabIndex = 296;
            this.labelV4.Tag = "sortingkind.lablev4";
            this.labelV4.Text = "labelV4";
            // 
            // labelV3
            // 
            this.labelV3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelV3.Location = new System.Drawing.Point(600, 102);
            this.labelV3.Name = "labelV3";
            this.labelV3.Size = new System.Drawing.Size(144, 16);
            this.labelV3.TabIndex = 294;
            this.labelV3.Tag = "sortingkind.lablev3";
            this.labelV3.Text = "labelV3";
            // 
            // labelV2
            // 
            this.labelV2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelV2.Location = new System.Drawing.Point(600, 62);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(144, 16);
            this.labelV2.TabIndex = 292;
            this.labelV2.Tag = "sortingkind.lablev2";
            this.labelV2.Text = "labelV2";
            // 
            // labelV1
            // 
            this.labelV1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelV1.Location = new System.Drawing.Point(600, 22);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(144, 16);
            this.labelV1.TabIndex = 290;
            this.labelV1.Tag = "sortingkind.lablev1";
            this.labelV1.Text = "labelV1";
            // 
            // TxtDenominatore
            // 
            this.TxtDenominatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDenominatore.Location = new System.Drawing.Point(72, 200);
            this.TxtDenominatore.Name = "TxtDenominatore";
            this.TxtDenominatore.Size = new System.Drawing.Size(80, 22);
            this.TxtDenominatore.TabIndex = 4;
            this.TxtDenominatore.Tag = "autoincomesorting.denominator";
            this.TxtDenominatore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(48, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 8);
            this.label4.TabIndex = 264;
            this.label4.Text = "__________________________";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TxtNumeratore
            // 
            this.TxtNumeratore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeratore.Location = new System.Drawing.Point(72, 160);
            this.TxtNumeratore.Name = "TxtNumeratore";
            this.TxtNumeratore.Size = new System.Drawing.Size(80, 22);
            this.TxtNumeratore.TabIndex = 3;
            this.TxtNumeratore.Tag = "autoincomesorting.numerator";
            this.TxtNumeratore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentuale.Location = new System.Drawing.Point(40, 144);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(160, 16);
            this.lblPercentuale.TabIndex = 262;
            this.lblPercentuale.Text = "Porzione da classificare";
            // 
            // labelignoradate
            // 
            this.labelignoradate.Location = new System.Drawing.Point(32, 112);
            this.labelignoradate.Name = "labelignoradate";
            this.labelignoradate.Size = new System.Drawing.Size(240, 16);
            this.labelignoradate.TabIndex = 2;
            this.labelignoradate.Tag = "";
            this.labelignoradate.Text = "ignora date custom";
            // 
            // chkIgnoraDate
            // 
            this.chkIgnoraDate.Location = new System.Drawing.Point(8, 112);
            this.chkIgnoraDate.Name = "chkIgnoraDate";
            this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
            this.chkIgnoraDate.TabIndex = 260;
            this.chkIgnoraDate.Tag = "autoincomesorting.flagnodate:S:N";
            // 
            // valoreS5
            // 
            this.valoreS5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreS5.Location = new System.Drawing.Point(448, 200);
            this.valoreS5.Name = "valoreS5";
            this.valoreS5.Size = new System.Drawing.Size(144, 20);
            this.valoreS5.TabIndex = 289;
            this.valoreS5.Tag = "autoincomesorting.defaults5";
            // 
            // valoreN5
            // 
            this.valoreN5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreN5.Location = new System.Drawing.Point(296, 200);
            this.valoreN5.Name = "valoreN5";
            this.valoreN5.Size = new System.Drawing.Size(144, 20);
            this.valoreN5.TabIndex = 288;
            this.valoreN5.Tag = "autoincomesorting.defaultn5";
            // 
            // valoreS4
            // 
            this.valoreS4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreS4.Location = new System.Drawing.Point(448, 160);
            this.valoreS4.Name = "valoreS4";
            this.valoreS4.Size = new System.Drawing.Size(144, 20);
            this.valoreS4.TabIndex = 285;
            this.valoreS4.Tag = "autoincomesorting.defaults4";
            // 
            // valoreN4
            // 
            this.valoreN4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreN4.Location = new System.Drawing.Point(296, 160);
            this.valoreN4.Name = "valoreN4";
            this.valoreN4.Size = new System.Drawing.Size(144, 20);
            this.valoreN4.TabIndex = 284;
            this.valoreN4.Tag = "autoincomesorting.defaultn4";
            // 
            // valoreN2
            // 
            this.valoreN2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreN2.Location = new System.Drawing.Point(296, 80);
            this.valoreN2.Name = "valoreN2";
            this.valoreN2.Size = new System.Drawing.Size(144, 20);
            this.valoreN2.TabIndex = 276;
            this.valoreN2.Tag = "autoincomesorting.defaultn2";
            // 
            // valoreS3
            // 
            this.valoreS3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreS3.Location = new System.Drawing.Point(448, 120);
            this.valoreS3.Name = "valoreS3";
            this.valoreS3.Size = new System.Drawing.Size(144, 20);
            this.valoreS3.TabIndex = 281;
            this.valoreS3.Tag = "autoincomesorting.defaults3";
            // 
            // valoreS2
            // 
            this.valoreS2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreS2.Location = new System.Drawing.Point(448, 80);
            this.valoreS2.Name = "valoreS2";
            this.valoreS2.Size = new System.Drawing.Size(144, 20);
            this.valoreS2.TabIndex = 277;
            this.valoreS2.Tag = "autoincomesorting.defaults1";
            // 
            // valoreN1
            // 
            this.valoreN1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreN1.Location = new System.Drawing.Point(296, 40);
            this.valoreN1.Name = "valoreN1";
            this.valoreN1.Size = new System.Drawing.Size(144, 20);
            this.valoreN1.TabIndex = 272;
            this.valoreN1.Tag = "autoincomesorting.defaultn1";
            // 
            // valoreN3
            // 
            this.valoreN3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreN3.Location = new System.Drawing.Point(296, 120);
            this.valoreN3.Name = "valoreN3";
            this.valoreN3.Size = new System.Drawing.Size(144, 20);
            this.valoreN3.TabIndex = 280;
            this.valoreN3.Tag = "autoincomesorting.defaultn3";
            // 
            // valoreS1
            // 
            this.valoreS1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.valoreS1.Location = new System.Drawing.Point(448, 40);
            this.valoreS1.Name = "valoreS1";
            this.valoreS1.Size = new System.Drawing.Size(144, 20);
            this.valoreS1.TabIndex = 273;
            this.valoreS1.Tag = "autoincomesorting.defaults1";
            // 
            // labelS5
            // 
            this.labelS5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelS5.Location = new System.Drawing.Point(448, 184);
            this.labelS5.Name = "labelS5";
            this.labelS5.Size = new System.Drawing.Size(144, 16);
            this.labelS5.TabIndex = 287;
            this.labelS5.Tag = "sortingkind.lables5";
            this.labelS5.Text = "labelS5";
            // 
            // labelS4
            // 
            this.labelS4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelS4.Location = new System.Drawing.Point(448, 144);
            this.labelS4.Name = "labelS4";
            this.labelS4.Size = new System.Drawing.Size(144, 16);
            this.labelS4.TabIndex = 283;
            this.labelS4.Tag = "sortingkind.lables4";
            this.labelS4.Text = "labelS4";
            // 
            // labelS3
            // 
            this.labelS3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelS3.Location = new System.Drawing.Point(448, 104);
            this.labelS3.Name = "labelS3";
            this.labelS3.Size = new System.Drawing.Size(144, 16);
            this.labelS3.TabIndex = 279;
            this.labelS3.Tag = "sortingkind.lables3";
            this.labelS3.Text = "labelS3";
            // 
            // labelS2
            // 
            this.labelS2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelS2.Location = new System.Drawing.Point(448, 64);
            this.labelS2.Name = "labelS2";
            this.labelS2.Size = new System.Drawing.Size(144, 16);
            this.labelS2.TabIndex = 275;
            this.labelS2.Tag = "sortingkind.lables2";
            this.labelS2.Text = "labelS2";
            // 
            // labelS1
            // 
            this.labelS1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelS1.Location = new System.Drawing.Point(448, 24);
            this.labelS1.Name = "labelS1";
            this.labelS1.Size = new System.Drawing.Size(144, 16);
            this.labelS1.TabIndex = 271;
            this.labelS1.Tag = "sortingkind.lables1";
            this.labelS1.Text = "labelS1";
            // 
            // labelN5
            // 
            this.labelN5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelN5.Location = new System.Drawing.Point(296, 184);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new System.Drawing.Size(144, 16);
            this.labelN5.TabIndex = 286;
            this.labelN5.Tag = "sortingkind.lablen5";
            this.labelN5.Text = "labelN5";
            // 
            // labelN4
            // 
            this.labelN4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelN4.Location = new System.Drawing.Point(296, 144);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new System.Drawing.Size(144, 16);
            this.labelN4.TabIndex = 282;
            this.labelN4.Tag = "sortingkind.lablen4";
            this.labelN4.Text = "labelN4";
            // 
            // labelN3
            // 
            this.labelN3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelN3.Location = new System.Drawing.Point(296, 104);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new System.Drawing.Size(144, 16);
            this.labelN3.TabIndex = 278;
            this.labelN3.Tag = "sortingkind.lablen3";
            this.labelN3.Text = "labelN3";
            // 
            // labelN2
            // 
            this.labelN2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelN2.Location = new System.Drawing.Point(296, 64);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(144, 16);
            this.labelN2.TabIndex = 274;
            this.labelN2.Tag = "sortingkind.lablen2";
            this.labelN2.Text = "labelN2";
            // 
            // labelN1
            // 
            this.labelN1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelN1.Location = new System.Drawing.Point(296, 24);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(144, 16);
            this.labelN1.TabIndex = 270;
            this.labelN1.Tag = "sortingkind.lablen1";
            this.labelN1.Text = "labelN1";
            // 
            // gboxClassMov
            // 
            this.gboxClassMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClassMov.Controls.Add(this.txtDescrizioneMov);
            this.gboxClassMov.Controls.Add(this.txtCodiceMov);
            this.gboxClassMov.Controls.Add(this.btnCodiceMov);
            this.gboxClassMov.Location = new System.Drawing.Point(8, 40);
            this.gboxClassMov.Name = "gboxClassMov";
            this.gboxClassMov.Size = new System.Drawing.Size(280, 64);
            this.gboxClassMov.TabIndex = 2;
            this.gboxClassMov.TabStop = false;
            this.gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree";
            // 
            // txtDescrizioneMov
            // 
            this.txtDescrizioneMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneMov.Location = new System.Drawing.Point(128, 8);
            this.txtDescrizioneMov.Multiline = true;
            this.txtDescrizioneMov.Name = "txtDescrizioneMov";
            this.txtDescrizioneMov.ReadOnly = true;
            this.txtDescrizioneMov.Size = new System.Drawing.Size(144, 48);
            this.txtDescrizioneMov.TabIndex = 6;
            this.txtDescrizioneMov.TabStop = false;
            this.txtDescrizioneMov.Tag = "sorting.description";
            // 
            // txtCodiceMov
            // 
            this.txtCodiceMov.Location = new System.Drawing.Point(8, 32);
            this.txtCodiceMov.Name = "txtCodiceMov";
            this.txtCodiceMov.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceMov.TabIndex = 1;
            this.txtCodiceMov.Tag = "sorting.sortcode?autoincomesortingview.sortingcode";
            // 
            // btnCodiceMov
            // 
            this.btnCodiceMov.Location = new System.Drawing.Point(8, 8);
            this.btnCodiceMov.Name = "btnCodiceMov";
            this.btnCodiceMov.Size = new System.Drawing.Size(72, 23);
            this.btnCodiceMov.TabIndex = 2;
            this.btnCodiceMov.TabStop = false;
            this.btnCodiceMov.Tag = "manage.sorting.tree";
            this.btnCodiceMov.Text = "Codice";
            this.btnCodiceMov.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoMov.DataSource = this.DS.sortingkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(80, 16);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(208, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "autoincomesorting.idsorkind";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbTipoCred);
            this.groupBox1.Controls.Add(this.gboxClassCred);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 96);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            this.groupBox1.Text = "Classificazione versante";
            // 
            // cmbTipoCred
            // 
            this.cmbTipoCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoCred.DataSource = this.DS.sortingapplicabilityview;
            this.cmbTipoCred.DisplayMember = "description";
            this.cmbTipoCred.Location = new System.Drawing.Point(232, 8);
            this.cmbTipoCred.Name = "cmbTipoCred";
            this.cmbTipoCred.Size = new System.Drawing.Size(512, 21);
            this.cmbTipoCred.TabIndex = 1;
            this.cmbTipoCred.Tag = "classmovimenti1.idsorkind?autoincomesortingview.idsorkindreg";
            this.cmbTipoCred.ValueMember = "idsorkind";
            // 
            // gboxClassCred
            // 
            this.gboxClassCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClassCred.Controls.Add(this.txtDescrizioneCred);
            this.gboxClassCred.Controls.Add(this.txtCodiceCred);
            this.gboxClassCred.Controls.Add(this.btnCodiceCred);
            this.gboxClassCred.Location = new System.Drawing.Point(8, 32);
            this.gboxClassCred.Name = "gboxClassCred";
            this.gboxClassCred.Size = new System.Drawing.Size(736, 56);
            this.gboxClassCred.TabIndex = 14;
            this.gboxClassCred.TabStop = false;
            this.gboxClassCred.Tag = "AutoManage.txtCodiceCred.treeall";
            // 
            // txtDescrizioneCred
            // 
            this.txtDescrizioneCred.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneCred.Location = new System.Drawing.Point(216, 8);
            this.txtDescrizioneCred.Multiline = true;
            this.txtDescrizioneCred.Name = "txtDescrizioneCred";
            this.txtDescrizioneCred.ReadOnly = true;
            this.txtDescrizioneCred.Size = new System.Drawing.Size(512, 40);
            this.txtDescrizioneCred.TabIndex = 6;
            this.txtDescrizioneCred.TabStop = false;
            this.txtDescrizioneCred.Tag = "classmovimenti1.description";
            // 
            // txtCodiceCred
            // 
            this.txtCodiceCred.Location = new System.Drawing.Point(88, 16);
            this.txtCodiceCred.Name = "txtCodiceCred";
            this.txtCodiceCred.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceCred.TabIndex = 1;
            this.txtCodiceCred.Tag = "classmovimenti1.sortcode?autoincomesortingview.registrysortcode";
            // 
            // btnCodiceCred
            // 
            this.btnCodiceCred.Location = new System.Drawing.Point(8, 16);
            this.btnCodiceCred.Name = "btnCodiceCred";
            this.btnCodiceCred.Size = new System.Drawing.Size(72, 23);
            this.btnCodiceCred.TabIndex = 2;
            this.btnCodiceCred.TabStop = false;
            this.btnCodiceCred.Tag = "manage.classmovimenti1.treeall";
            this.btnCodiceCred.Text = "Codice";
            this.btnCodiceCred.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(160, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Tipo:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(8, 32);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(400, 56);
            this.gboxBilAnnuale.TabIndex = 1;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treealle";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(8, 8);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 0;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin.treealle";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.UseVisualStyleBackColor = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 32);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "fin.codefin?autoincomesortingview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(128, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(264, 40);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "fin.title";
            // 
            // btnConflitti
            // 
            this.btnConflitti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConflitti.Location = new System.Drawing.Point(528, 8);
            this.btnConflitti.Name = "btnConflitti";
            this.btnConflitti.Size = new System.Drawing.Size(104, 23);
            this.btnConflitti.TabIndex = 17;
            this.btnConflitti.TabStop = false;
            this.btnConflitti.Text = "Elenco conflitti";
            this.btnConflitti.Click += new System.EventHandler(this.btnConflitti_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 192);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 18;
            this.button1.TabStop = false;
            this.button1.Tag = "choose.manager.default";
            this.button1.Text = "Responsabile";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.manager;
            this.comboBox1.DisplayMember = "title";
            this.comboBox1.Location = new System.Drawing.Point(136, 192);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(616, 21);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.Tag = "autoincomesorting.idman";
            this.comboBox1.ValueMember = "idman";
            // 
            // gBoxUpb
            // 
            this.gBoxUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gBoxUpb.Controls.Add(this.txtDescrizioneUpb);
            this.gBoxUpb.Controls.Add(this.txtUpb);
            this.gBoxUpb.Controls.Add(this.btnUpb);
            this.gBoxUpb.Location = new System.Drawing.Point(416, 32);
            this.gBoxUpb.Name = "gBoxUpb";
            this.gBoxUpb.Size = new System.Drawing.Size(344, 56);
            this.gBoxUpb.TabIndex = 22;
            this.gBoxUpb.TabStop = false;
            this.gBoxUpb.Tag = "AutoManage.txtUpb.tree";
            // 
            // txtDescrizioneUpb
            // 
            this.txtDescrizioneUpb.Location = new System.Drawing.Point(120, 8);
            this.txtDescrizioneUpb.Multiline = true;
            this.txtDescrizioneUpb.Name = "txtDescrizioneUpb";
            this.txtDescrizioneUpb.ReadOnly = true;
            this.txtDescrizioneUpb.Size = new System.Drawing.Size(216, 46);
            this.txtDescrizioneUpb.TabIndex = 2;
            this.txtDescrizioneUpb.Tag = "upb.title";
            // 
            // txtUpb
            // 
            this.txtUpb.Location = new System.Drawing.Point(8, 32);
            this.txtUpb.Name = "txtUpb";
            this.txtUpb.Size = new System.Drawing.Size(104, 20);
            this.txtUpb.TabIndex = 1;
            this.txtUpb.Tag = "upb.codeupb?autoexpensesortingview.codeupb";
            // 
            // btnUpb
            // 
            this.btnUpb.Location = new System.Drawing.Point(8, 8);
            this.btnUpb.Name = "btnUpb";
            this.btnUpb.Size = new System.Drawing.Size(104, 20);
            this.btnUpb.TabIndex = 0;
            this.btnUpb.Tag = "manage.upb.tree";
            this.btnUpb.Text = "U.P.B.:";
            // 
            // Frm_autoincomesorting_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(760, 493);
            this.Controls.Add(this.gBoxUpb);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnConflitti);
            this.Controls.Add(this.btnDerived);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Name = "Frm_autoincomesorting_default";
            this.Text = "FrmAutoClassentrate_Config";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxClassMov.ResumeLayout(false);
            this.gboxClassMov.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gboxClassCred.ResumeLayout(false);
            this.gboxClassCred.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gBoxUpb.ResumeLayout(false);
            this.gBoxUpb.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.fin,QHS.AppAnd(filtereserc, QHS.BitClear("flag", 0)));
			GetData.SetStaticFilter(DS.autoincomesorting,filtereserc);
			GetData.SetStaticFilter(DS.autoincomesortingview,filtereserc);

            string filterCT = QHS.CmpEq("tablename", "registry");
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI_SA = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            string filterI_SK = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive,
                QHS.IsNotNull("nphaseincome"))), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI_SA);
            QueryCreator.SetFilterForInsert(DS.sortingkind, filterI_SK);

			GetData.CacheTable(DS.upb);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName == "sortingapplicabilityview") {
				if (Meta.DrawStateIsDone) {
					if ((!MetaData.Empty(this))){
						DS.autoincomesorting.Rows[0]["idsorreg"]=DBNull.Value;
						DS.autoincomesorting.Rows[0]["idsorkindreg"]=DBNull.Value;
					}
					txtCodiceCred.Text="";
					txtDescrizioneCred.Text="";
					DS.classmovimenti1.Clear();
				}
				SetCodiceCredDeb();
			}
			if (T.TableName == "sortingkind") {
				if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) {
					if ((!MetaData.Empty(this))){
						DS.autoincomesorting.Rows[0]["idsor"]=DBNull.Value;
                        DS.autoincomesorting.Rows[0]["idsorkind"] = 0;
					}
					txtCodiceMov.Text="";
					txtDescrizioneMov.Text="";
					DS.sorting.Clear();
				}
				SetCodiceMovim();
				AggiornaEtichette();
			}
		}

		void SetCodiceCredDeb(){
			btnCodiceCred.Enabled= (cmbTipoCred.SelectedIndex>0);
			txtCodiceCred.ReadOnly= (cmbTipoCred.SelectedIndex<=0);
			if (cmbTipoCred.SelectedIndex<=0){
				txtCodiceCred.Text="";
				txtDescrizioneCred.Text="";
			}
			else {
				string filter = QHS.CmpEq("idsorkind", cmbTipoCred.SelectedValue);
				btnCodiceCred.Tag="manage.classmovimenti1.treeall."+filter;
				gboxClassCred.Tag="AutoManage.txtCodiceCred.treeall."+filter;

				MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCodiceCred.Name);
				if (AI!=null) AI.startfilter=filter;

				//Meta.SetAutoMode(gboxClassCred);
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.classmovimenti1.ExtendedProperties[MetaData.ExtraParams]=filter;
			}
		}

		void SetCodiceMovim(){
			btnCodiceMov.Enabled= (cmbTipoMov.SelectedIndex >0);
			txtCodiceMov.ReadOnly= (cmbTipoMov.SelectedIndex<=0);
			if (cmbTipoMov.SelectedIndex<=0){
				txtCodiceMov.Text="";
				txtDescrizioneMov.Text="";
			}
			else {
				string filter = QHS.CmpEq("idsorkind", cmbTipoMov.SelectedValue);
				DataTable Available= Conn.RUN_SELECT("sorting","*",null,filter,null,null,true);
				btnCodiceMov.Tag="manage.sorting.tree."+filter;
				gboxClassMov.Tag="AutoManage.txtCodiceMov.tree."+filter;

				MetaData.AutoInfo AI = Meta.GetAutoInfo(txtCodiceMov.Name);
				if (AI!=null) AI.startfilter=filter;

				//Meta.SetAutoMode(gboxClassMov);
				//label per il form di selezione della voce di classificazione +"."+ filtro
				DS.sorting.ExtendedProperties[MetaData.ExtraParams]=Available;
			}
		}

		public void MetaData_AfterClear(){
			TxtDenominatore.TextAlign= HorizontalAlignment.Center;
			TxtNumeratore.TextAlign= HorizontalAlignment.Center;
		}

		public void MetaData_AfterFill(){
			SetCodiceCredDeb();
			SetCodiceMovim();
		}

		private void btnDerived_Click(object sender, System.EventArgs e) {
			string codicebil = txtCodiceBilancio.Text.Trim();
			string codicecre = txtCodiceCred.Text.Trim();
			string codeupb = txtUpb.Text.Trim();
			
			DataRow [] rUpb = DS.upb.Select(QHC.CmpEq("codeupb", codeupb));
			string idupb = (rUpb.Length > 0) ? rUpb[0]["idupb"].ToString() : "";

			string tipocre;
			if (cmbTipoCred.SelectedValue==null) tipocre="";
			else tipocre= cmbTipoCred.SelectedValue.ToString().Trim();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			if (codicebil!="") filter=GetData.MergeFilters(filter, QHS.Like("codefin", codicebil));
            if (idupb != "") filter = GetData.MergeFilters(filter, QHS.Like("idupb", idupb));
			if ((tipocre!="")&&(codicecre!="")){
				filter=GetData.MergeFilters(filter,QHS.CmpEq("regsortingkind", tipocre));
				filter=GetData.MergeFilters(filter, QHS.Like("registrysortcode", codicecre));
			}
			Meta.SelectOne(Meta.DefaultListType,filter,null,null);
		}


		void AggiornaEtichette(){
			if (cmbTipoMov.SelectedIndex<=0) {
				NascondiEtichette();
				return;
			}
			string codtipomov = cmbTipoMov.SelectedValue.ToString();
			DataRow Rtipo = DS.sortingkind.Select(QHC.CmpEq("idsorkind", codtipomov))[0];
			
			if (Rtipo["flagdate"].ToString().ToLower()!="s") {
				chkIgnoraDate.Visible = false;
				labelignoradate.Visible=false;
				HelpForm.SetDenyNull(DS.autoincomesorting.Columns["flagnodate"],false);
			}
			else {
				chkIgnoraDate.Visible = true;
				labelignoradate.Visible=true;
				HelpForm.SetDenyNull(DS.autoincomesorting.Columns["flagnodate"],true);
			}

			foreach(string kind in new string[]{"n","s","v"}) {
				for (int i=1; i<=5; i++) {
					string suffix= kind+i.ToString();
					TextBox T = GetTxtByName("valore"+suffix.ToUpper());
					Label L = GetLblByname("label"+suffix.ToUpper());
					if (Rtipo["label"+suffix].ToString()=="") {
						L.Visible=false;
						T.Visible=false;
						T.Text="";
					}
					else {
						L.Visible=true;
						L.Text= Rtipo["label"+suffix].ToString();
						T.Visible=true;
					}
					
					if (Rtipo["forced"+suffix].ToString().ToLower()=="s") {
						//						if (CurrRow["valore"+suffix]==DBNull.Value) 
						//						{
						//							if (kind=="N")CurrRow["valore"+suffix]=0;
						//							if (kind=="S")CurrRow["valore"+suffix]="";
						if (kind=="n") 
							MetaData.SetDefault(DS.autoincomesorting, "default"+suffix, 0);
						if (kind=="s") 
							MetaData.SetDefault(DS.autoincomesorting, "default"+suffix, "");
						if (kind=="v") 
							MetaData.SetDefault(DS.autoincomesorting, "default"+suffix, 0);
						//						}
						HelpForm.SetDenyNull(DS.Tables["autoincomesorting"].Columns["default"+suffix],true);
					}
					else {
						MetaData.SetDefault(DS.autoincomesorting, "default"+suffix, DBNull.Value);
						HelpForm.SetDenyNull(DS.Tables["autoincomesorting"].Columns["default"+suffix],false);
					}
				}
			}
		}

		void NascondiEtichette(){
			chkIgnoraDate.Visible = false;
			labelignoradate.Visible=false;
			foreach(string kind in new string[]{"N","S","V"}) {
				for (int i=1; i<=5; i++) {
					string suffix= kind+i.ToString();
					TextBox T = GetTxtByName("valore"+suffix);
					Label L = GetLblByname("label"+suffix);
					L.Visible=false;
					T.Visible=false;		
					T.Text="";
				}
			}

		}

		TextBox GetTxtByName(string Name) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;                         
			TextBox T =  (TextBox) Ctrl.GetValue(this);                        
			return T;
		}

		Label GetLblByname(string Name) {
			System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
			if (Ctrl==null) return null;
			if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;
			Label L = (Label) Ctrl.GetValue(this);
			return L; 
		}

		private void btnConflitti_Click(object sender, System.EventArgs e) {
			DataSet D = Conn.CallSP("sort_setup_conflict_income",
				new object[]{Meta.GetSys("esercizio")},
				true);
			if (D==null) return;
			if (D.Tables.Count==0) return;
			exportclass.DataTableToExcel(D.Tables[0],true);
		}
	}
}
