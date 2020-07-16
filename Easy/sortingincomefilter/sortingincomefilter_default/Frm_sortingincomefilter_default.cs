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
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;

namespace sortingincomefilter_default//filtraclassentrate_config//
{
	/// <summary>
	/// Summary description for FormFiltraClassEntrate_Config.
	/// </summary>
	public class Frm_sortingincomefilter_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnDerived;
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
		private System.Windows.Forms.GroupBox gboxClassMov;
		private System.Windows.Forms.TextBox txtDescrizioneMov;
		private System.Windows.Forms.TextBox txtCodiceMov;
		private System.Windows.Forms.Button btnCodiceMov;
		private System.Windows.Forms.ComboBox cmbTipoMov;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox checkBoxFlagunisciamenospecifici;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ComboBox cmbResponsabile;
		private System.Windows.Forms.GroupBox gboxUpb;
		private System.Windows.Forms.TextBox txtDescrizioneUpb;
		private System.Windows.Forms.TextBox txtUpb;
		private System.Windows.Forms.Button btnUpb;
		private System.ComponentModel.IContainer components;

		public Frm_sortingincomefilter_default()
		{
			InitializeComponent();
            DataAccess.SetTableForReading(DS.Tables["classmovimenti1"],"sorting");
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sortingincomefilter_default));
            this.btnDerived = new System.Windows.Forms.Button();
            this.DS = new sortingincomefilter_default.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbTipoCred = new System.Windows.Forms.ComboBox();
            this.gboxClassCred = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneCred = new System.Windows.Forms.TextBox();
            this.txtCodiceCred = new System.Windows.Forms.TextBox();
            this.btnCodiceCred = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxUpb = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneUpb = new System.Windows.Forms.TextBox();
            this.txtUpb = new System.Windows.Forms.TextBox();
            this.btnUpb = new System.Windows.Forms.Button();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.gboxClassMov = new System.Windows.Forms.GroupBox();
            this.txtDescrizioneMov = new System.Windows.Forms.TextBox();
            this.txtCodiceMov = new System.Windows.Forms.TextBox();
            this.btnCodiceMov = new System.Windows.Forms.Button();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxFlagunisciamenospecifici = new System.Windows.Forms.CheckBox();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboxClassCred.SuspendLayout();
            this.gboxUpb.SuspendLayout();
            this.gboxBilAnnuale.SuspendLayout();
            this.gboxClassMov.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDerived
            // 
            this.btnDerived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDerived.Location = new System.Drawing.Point(737, 6);
            this.btnDerived.Name = "btnDerived";
            this.btnDerived.Size = new System.Drawing.Size(120, 23);
            this.btnDerived.TabIndex = 1;
            this.btnDerived.TabStop = false;
            this.btnDerived.Text = "Elenca pi˘ specifici";
            this.btnDerived.Click += new System.EventHandler(this.btnDerived_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cmbTipoCred);
            this.groupBox1.Controls.Add(this.gboxClassCred);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(4, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(853, 96);
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
            this.cmbTipoCred.Size = new System.Drawing.Size(613, 21);
            this.cmbTipoCred.TabIndex = 1;
            this.cmbTipoCred.Tag = "classmovimenti1.idsorkind?sortingincomefilterview.regsortingkind";
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
            this.gboxClassCred.Size = new System.Drawing.Size(837, 56);
            this.gboxClassCred.TabIndex = 2;
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
            this.txtDescrizioneCred.Size = new System.Drawing.Size(613, 40);
            this.txtDescrizioneCred.TabIndex = 6;
            this.txtDescrizioneCred.TabStop = false;
            this.txtDescrizioneCred.Tag = "classmovimenti1.description";
            // 
            // txtCodiceCred
            // 
            this.txtCodiceCred.Location = new System.Drawing.Point(8, 30);
            this.txtCodiceCred.Name = "txtCodiceCred";
            this.txtCodiceCred.Size = new System.Drawing.Size(185, 20);
            this.txtCodiceCred.TabIndex = 7;
            this.txtCodiceCred.Tag = "classmovimenti1.sortcode?sortingincomefilterview.registrysortcode";
            // 
            // btnCodiceCred
            // 
            this.btnCodiceCred.Location = new System.Drawing.Point(8, 8);
            this.btnCodiceCred.Name = "btnCodiceCred";
            this.btnCodiceCred.Size = new System.Drawing.Size(64, 23);
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
            // gboxUpb
            // 
            this.gboxUpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxUpb.Controls.Add(this.txtDescrizioneUpb);
            this.gboxUpb.Controls.Add(this.txtUpb);
            this.gboxUpb.Controls.Add(this.btnUpb);
            this.gboxUpb.Location = new System.Drawing.Point(418, 30);
            this.gboxUpb.Name = "gboxUpb";
            this.gboxUpb.Size = new System.Drawing.Size(439, 90);
            this.gboxUpb.TabIndex = 2;
            this.gboxUpb.TabStop = false;
            this.gboxUpb.Tag = "AutoManage.txtUpb.tree";
            // 
            // txtDescrizioneUpb
            // 
            this.txtDescrizioneUpb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneUpb.Location = new System.Drawing.Point(140, 8);
            this.txtDescrizioneUpb.Multiline = true;
            this.txtDescrizioneUpb.Name = "txtDescrizioneUpb";
            this.txtDescrizioneUpb.ReadOnly = true;
            this.txtDescrizioneUpb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizioneUpb.Size = new System.Drawing.Size(291, 50);
            this.txtDescrizioneUpb.TabIndex = 0;
            this.txtDescrizioneUpb.TabStop = false;
            this.txtDescrizioneUpb.Tag = "upb.title";
            // 
            // txtUpb
            // 
            this.txtUpb.Location = new System.Drawing.Point(8, 64);
            this.txtUpb.Name = "txtUpb";
            this.txtUpb.Size = new System.Drawing.Size(423, 20);
            this.txtUpb.TabIndex = 1;
            this.txtUpb.Tag = "upb.codeupb?sortingincomefilterview.codeupb";
            // 
            // btnUpb
            // 
            this.btnUpb.BackColor = System.Drawing.SystemColors.Control;
            this.btnUpb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUpb.Location = new System.Drawing.Point(6, 38);
            this.btnUpb.Name = "btnUpb";
            this.btnUpb.Size = new System.Drawing.Size(112, 20);
            this.btnUpb.TabIndex = 0;
            this.btnUpb.TabStop = false;
            this.btnUpb.Tag = "manage.upb.tree";
            this.btnUpb.Text = "U.P.B.:";
            this.btnUpb.UseVisualStyleBackColor = false;
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(4, 30);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(408, 90);
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
            this.btnBilancio.Location = new System.Drawing.Point(6, 38);
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
            this.txtCodiceBilancio.Location = new System.Drawing.Point(6, 64);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(396, 20);
            this.txtCodiceBilancio.TabIndex = 1;
            this.txtCodiceBilancio.Tag = "fin.codefin?sortingincomefilterview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(151, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(249, 50);
            this.txtDenominazioneBilancio.TabIndex = 2;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "fin.title";
            // 
            // gboxClassMov
            // 
            this.gboxClassMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClassMov.Controls.Add(this.txtDescrizioneMov);
            this.gboxClassMov.Controls.Add(this.txtCodiceMov);
            this.gboxClassMov.Controls.Add(this.btnCodiceMov);
            this.gboxClassMov.Location = new System.Drawing.Point(8, 48);
            this.gboxClassMov.Name = "gboxClassMov";
            this.gboxClassMov.Size = new System.Drawing.Size(837, 64);
            this.gboxClassMov.TabIndex = 2;
            this.gboxClassMov.TabStop = false;
            this.gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree";
            // 
            // txtDescrizioneMov
            // 
            this.txtDescrizioneMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneMov.Location = new System.Drawing.Point(216, 8);
            this.txtDescrizioneMov.Multiline = true;
            this.txtDescrizioneMov.Name = "txtDescrizioneMov";
            this.txtDescrizioneMov.ReadOnly = true;
            this.txtDescrizioneMov.Size = new System.Drawing.Size(613, 48);
            this.txtDescrizioneMov.TabIndex = 6;
            this.txtDescrizioneMov.TabStop = false;
            this.txtDescrizioneMov.Tag = "sorting.description";
            // 
            // txtCodiceMov
            // 
            this.txtCodiceMov.Location = new System.Drawing.Point(8, 32);
            this.txtCodiceMov.Name = "txtCodiceMov";
            this.txtCodiceMov.Size = new System.Drawing.Size(185, 20);
            this.txtCodiceMov.TabIndex = 1;
            this.txtCodiceMov.Tag = "sorting.sortcode?sortingincomefilterview.sortingcode";
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
            this.cmbTipoMov.ItemHeight = 13;
            this.cmbTipoMov.Location = new System.Drawing.Point(124, 24);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(721, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "sortingincomefilter.idsorkind";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(52, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.gboxClassMov);
            this.groupBox3.Controls.Add(this.cmbTipoMov);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(4, 270);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(853, 114);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            this.groupBox3.Text = "Classificazione movimento";
            // 
            // checkBoxFlagunisciamenospecifici
            // 
            this.checkBoxFlagunisciamenospecifici.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxFlagunisciamenospecifici.Location = new System.Drawing.Point(589, 8);
            this.checkBoxFlagunisciamenospecifici.Name = "checkBoxFlagunisciamenospecifici";
            this.checkBoxFlagunisciamenospecifici.Size = new System.Drawing.Size(144, 24);
            this.checkBoxFlagunisciamenospecifici.TabIndex = 0;
            this.checkBoxFlagunisciamenospecifici.Tag = "sortingincomefilter.jointolessspecifics:S:N";
            this.checkBoxFlagunisciamenospecifici.Text = "Unisci a meno specifici";
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbResponsabile.DataSource = this.DS.manager;
            this.cmbResponsabile.DisplayMember = "title";
            this.cmbResponsabile.Location = new System.Drawing.Point(128, 241);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(725, 21);
            this.cmbResponsabile.TabIndex = 3;
            this.cmbResponsabile.Tag = "sortingincomefilter.idman";
            this.cmbResponsabile.ValueMember = "idman";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 241);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 21;
            this.button1.TabStop = false;
            this.button1.Tag = "choose.manager.default";
            this.button1.Text = "Responsabile";
            // 
            // Frm_sortingincomefilter_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(861, 396);
            this.Controls.Add(this.cmbResponsabile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxFlagunisciamenospecifici);
            this.Controls.Add(this.btnDerived);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxUpb);
            this.Controls.Add(this.gboxBilAnnuale);
            this.Name = "Frm_sortingincomefilter_default";
            this.Text = "FormFiltraClassEntrate_Config";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.gboxClassCred.ResumeLayout(false);
            this.gboxClassCred.PerformLayout();
            this.gboxUpb.ResumeLayout(false);
            this.gboxUpb.PerformLayout();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.gboxClassMov.ResumeLayout(false);
            this.gboxClassMov.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink()
		{
			Meta= MetaData.GetMetaData(this);
			Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			string filtereserc = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.fin, QHS.AppAnd(filtereserc, QHS.BitClear("flag", 0)));
			GetData.SetStaticFilter(DS.sortingincomefilter,filtereserc);
			GetData.SetStaticFilter(DS.sortingincomefilterview,filtereserc);
			
			GetData.CacheTable(DS.upb);

            string filterCT = QHS.CmpEq("tablename", "registry");
            GetData.CacheTable(DS.sortingapplicabilityview, filterCT, null, true);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);

            string filterI_SK = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive,
                QHS.IsNotNull("nphaseincome"))), QHS.CmpEq("idsorkind", 0)));
            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI_SK);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (T.TableName == "sortingapplicabilityview") 
			{
				if (Meta.DrawStateIsDone) 
				{
					if ((!MetaData.Empty(this)))
					{
						DS.sortingincomefilter.Rows[0]["idsorreg"]=DBNull.Value;
						DS.sortingincomefilter.Rows[0]["idsorkindreg"]=DBNull.Value;
					}
					txtCodiceCred.Text="";
					txtDescrizioneCred.Text="";
					DS.classmovimenti1.Clear();
				}
				SetCodiceCredDeb();
			}
			if (T.TableName == "sortingkind") 
			{
				if (MetaData.GetMetaData(this).DrawState== MetaData.form_drawstates.done) 
				{
					if ((!MetaData.Empty(this)))
					{
						DS.sortingincomefilter.Rows[0]["idsor"]=0;
						DS.sortingincomefilter.Rows[0]["idsorkind"]=0;
					}
					txtCodiceMov.Text="";
					txtDescrizioneMov.Text="";
					DS.sorting.Clear();
				}
				SetCodiceMovim();
			}

		}

		void SetCodiceCredDeb()
		{
			btnCodiceCred.Enabled= (cmbTipoCred.SelectedIndex>0);
			txtCodiceCred.ReadOnly= (cmbTipoCred.SelectedIndex<=0);
			if (cmbTipoCred.SelectedIndex<=0)
			{
				txtCodiceCred.Text="";
				txtDescrizioneCred.Text="";
			}
			else 
			{
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
		void SetCodiceMovim()
		{
			btnCodiceMov.Enabled= (cmbTipoMov.SelectedIndex>0);
			txtCodiceMov.ReadOnly= (cmbTipoMov.SelectedIndex<=0);
			if (cmbTipoMov.SelectedIndex<=0)
			{
				txtCodiceMov.Text="";
				txtDescrizioneMov.Text="";
			}
			else 
			{
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


/*		public void MetaData_AfterClear()
		{
		}*/

		public void MetaData_AfterFill()
		{
			SetCodiceCredDeb();
			SetCodiceMovim();
		}

		private void btnDerived_Click(object sender, System.EventArgs e) 
		{
			string codicebil=txtCodiceBilancio.Text.Trim();
			string codeupb = txtUpb.Text.Trim();

            DataRow[] rUpb = DS.upb.Select(QHC.CmpEq("codeupb", codeupb));
            object idupb = (rUpb.Length > 0) ? rUpb[0]["idupb"] : DBNull.Value;

			string codicecre=txtCodiceCred.Text.Trim();
            object tipocre;
            if (cmbTipoCred.SelectedValue == null)
                tipocre = DBNull.Value;
            else
                tipocre = cmbTipoCred.SelectedValue;

            object codiceresp;
            if (cmbTipoCred.SelectedValue == null)
                codiceresp = DBNull.Value;
            else
                codiceresp = cmbResponsabile.SelectedValue;

            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			if (codicebil!="") filter=GetData.MergeFilters(filter, QHS.Like("codefin", codicebil+"%"));
            if (idupb != DBNull.Value) filter = GetData.MergeFilters(filter, QHS.Like("idupb", idupb + "%"));
            if ((tipocre != DBNull.Value) && (codicecre != "")) {
                filter = GetData.MergeFilters(filter, QHS.CmpEq("idsorkindreg", tipocre));
                filter = GetData.MergeFilters(filter, QHS.Like("registrysortcode", codicecre));
			}
            if (codiceresp != DBNull.Value) filter = GetData.MergeFilters(filter, QHS.CmpEq("idman", codiceresp));
			
			if ((!MetaData.Empty(this)))
			{
				Meta.GetFormData(true);
				string excludecurrent="";
				DataRow Curr = DS.sortingincomefilter.Rows[0];
				object idautosort= Curr["idautosort"];
				excludecurrent = QHS.CmpNe("idautosort", idautosort);
                filter = QHS.AppAnd(filter, excludecurrent);
            }
			DataRow Selected = Meta.SelectOne(Meta.DefaultListType,filter,null,null);
			if (Selected!=null) Meta.SelectRow(Selected,Meta.DefaultListType);
		}

	}
}
