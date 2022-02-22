
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
using metadatalibrary;
using System.Data;

namespace accmotive_default
{
	/// <summary>
	/// Summary description for FrmAccMotive_default.
	/// </summary>
	public class FrmAccMotive_default : MetaDataForm
	{
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Splitter splitter1;
		public System.Windows.Forms.TabControl MetaDataDetail;
		private System.Windows.Forms.TabPage tabPrincipale;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label lblDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label lblCodice;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.GroupBox gboxConti;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.ComponentModel.IContainer components;
		public accmotive_default.vistaForm DS;
		private System.Windows.Forms.TabPage tabApplicabilita;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpOperazioni;
		private System.Windows.Forms.CheckBox chbAttivo;
        private TabPage tabClassificazione;
        private ImageList imageList1;
        private DataGrid dGridClassSup;
        private Button btnElimina;
        private Button btnModifica;
        private Button btnInserisci;
        private CheckBox chkFlagAmm;
        private CheckBox chkFalgDep;
        private GroupBox grpNaturadiSpesa;
        private RadioButton rdbContoCapitale;
        private RadioButton rdbSpesaCorrente;
        private CheckBox chkFalgGen;
        MetaData Meta;

		public FrmAccMotive_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			DS.accmotivedetail.ExtendedProperties["ViewTable"]= DS.accmotivedetailview;
			DS.accmotivedetailview.ExtendedProperties["RealTable"]= DS.accmotivedetail;

			DS.accmotivedetailview.Columns["idaccmotive"].ExtendedProperties["ViewSource"]="accmotivedetail.idaccmotive";
			DS.accmotivedetailview.Columns["idacc"].ExtendedProperties["ViewSource"]="accmotivedetail.idacc";

			DS.accmotivedetailview.Columns["ayear"].ExtendedProperties["ViewSource"]="accmotivedetail.ayear";
			DS.accmotivedetailview.Columns["cu"].ExtendedProperties["ViewSource"]="accmotivedetail.cu";
			DS.accmotivedetailview.Columns["ct"].ExtendedProperties["ViewSource"]="accmotivedetail.ct";
			DS.accmotivedetailview.Columns["lu"].ExtendedProperties["ViewSource"]="accmotivedetail.lu";
			DS.accmotivedetailview.Columns["lt"].ExtendedProperties["ViewSource"]="accmotivedetail.lt";
		

			DS.accmotivedetailview.Columns["account"].ExtendedProperties["ViewSource"]="account.title";
			DS.accmotivedetailview.Columns["codeacc"].ExtendedProperties["ViewSource"]="account.codeacc";
			DS.accmotivedetailview.Columns["idaccountkind"].ExtendedProperties["ViewSource"]="account.idaccountkind";
			DS.accmotivedetailview.Columns["flagregistry"].ExtendedProperties["ViewSource"]="account.flagregistry";
			DS.accmotivedetailview.Columns["flagupb"].ExtendedProperties["ViewSource"]="account.flagupb";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAccMotive_default));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.chkFalgGen = new System.Windows.Forms.CheckBox();
            this.grpNaturadiSpesa = new System.Windows.Forms.GroupBox();
            this.rdbContoCapitale = new System.Windows.Forms.RadioButton();
            this.rdbSpesaCorrente = new System.Windows.Forms.RadioButton();
            this.chkFlagAmm = new System.Windows.Forms.CheckBox();
            this.chkFalgDep = new System.Windows.Forms.CheckBox();
            this.chbAttivo = new System.Windows.Forms.CheckBox();
            this.gboxConti = new System.Windows.Forms.GroupBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.tabApplicabilita = new System.Windows.Forms.TabPage();
            this.grpOperazioni = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.tabClassificazione = new System.Windows.Forms.TabPage();
            this.dGridClassSup = new System.Windows.Forms.DataGrid();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DS = new accmotive_default.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.grpNaturadiSpesa.SuspendLayout();
            this.gboxConti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabApplicabilita.SuspendLayout();
            this.grpOperazioni.SuspendLayout();
            this.tabClassificazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(283, 517);
            this.treeView1.TabIndex = 2;
            this.treeView1.Tag = "accmotive.tree";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(283, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 517);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.tabPrincipale);
            this.MetaDataDetail.Controls.Add(this.tabApplicabilita);
            this.MetaDataDetail.Controls.Add(this.tabClassificazione);
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.ImageList = this.imageList1;
            this.MetaDataDetail.Location = new System.Drawing.Point(286, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(662, 517);
            this.MetaDataDetail.TabIndex = 5;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.chkFalgGen);
            this.tabPrincipale.Controls.Add(this.grpNaturadiSpesa);
            this.tabPrincipale.Controls.Add(this.chkFlagAmm);
            this.tabPrincipale.Controls.Add(this.chkFalgDep);
            this.tabPrincipale.Controls.Add(this.chbAttivo);
            this.tabPrincipale.Controls.Add(this.gboxConti);
            this.tabPrincipale.Controls.Add(this.txtDenominazione);
            this.tabPrincipale.Controls.Add(this.lblDenominazione);
            this.tabPrincipale.Controls.Add(this.txtCodice);
            this.tabPrincipale.Controls.Add(this.lblCodice);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(654, 490);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // chkFalgGen
            // 
            this.chkFalgGen.AutoSize = true;
            this.chkFalgGen.Location = new System.Drawing.Point(210, 10);
            this.chkFalgGen.Name = "chkFalgGen";
            this.chkFalgGen.Size = new System.Drawing.Size(281, 17);
            this.chkFalgGen.TabIndex = 27;
            this.chkFalgGen.Tag = "accmotive.flag:0";
            this.chkFalgGen.Text = "Vieta il salvataggio della fattura in assenza di contratto";
            this.chkFalgGen.UseVisualStyleBackColor = true;
            // 
            // grpNaturadiSpesa
            // 
            this.grpNaturadiSpesa.Controls.Add(this.rdbContoCapitale);
            this.grpNaturadiSpesa.Controls.Add(this.rdbSpesaCorrente);
            this.grpNaturadiSpesa.Location = new System.Drawing.Point(441, 33);
            this.grpNaturadiSpesa.Name = "grpNaturadiSpesa";
            this.grpNaturadiSpesa.Size = new System.Drawing.Size(206, 36);
            this.grpNaturadiSpesa.TabIndex = 26;
            this.grpNaturadiSpesa.TabStop = false;
            this.grpNaturadiSpesa.Text = "Natura di spesa PCC";
            // 
            // rdbContoCapitale
            // 
            this.rdbContoCapitale.AutoSize = true;
            this.rdbContoCapitale.Location = new System.Drawing.Point(104, 13);
            this.rdbContoCapitale.Name = "rdbContoCapitale";
            this.rdbContoCapitale.Size = new System.Drawing.Size(93, 17);
            this.rdbContoCapitale.TabIndex = 25;
            this.rdbContoCapitale.TabStop = true;
            this.rdbContoCapitale.Tag = "accmotive.expensekind:CA";
            this.rdbContoCapitale.Text = "Conto capitale";
            this.rdbContoCapitale.UseVisualStyleBackColor = true;
            // 
            // rdbSpesaCorrente
            // 
            this.rdbSpesaCorrente.AutoSize = true;
            this.rdbSpesaCorrente.Location = new System.Drawing.Point(8, 14);
            this.rdbSpesaCorrente.Name = "rdbSpesaCorrente";
            this.rdbSpesaCorrente.Size = new System.Drawing.Size(97, 17);
            this.rdbSpesaCorrente.TabIndex = 24;
            this.rdbSpesaCorrente.TabStop = true;
            this.rdbSpesaCorrente.Tag = "accmotive.expensekind:CO";
            this.rdbSpesaCorrente.Text = "Spesa corrente";
            this.rdbSpesaCorrente.UseVisualStyleBackColor = true;
            // 
            // chkFlagAmm
            // 
            this.chkFlagAmm.AutoSize = true;
            this.chkFlagAmm.Location = new System.Drawing.Point(210, 33);
            this.chkFlagAmm.Name = "chkFlagAmm";
            this.chkFlagAmm.Size = new System.Drawing.Size(171, 17);
            this.chkFlagAmm.TabIndex = 25;
            this.chkFlagAmm.Tag = "";
            this.chkFlagAmm.Text = "Utilizzabile dall\'Amministrazione";
            this.chkFlagAmm.UseVisualStyleBackColor = true;
            this.chkFlagAmm.Visible = false;
            // 
            // chkFalgDep
            // 
            this.chkFalgDep.AutoSize = true;
            this.chkFalgDep.Location = new System.Drawing.Point(210, 56);
            this.chkFalgDep.Name = "chkFalgDep";
            this.chkFalgDep.Size = new System.Drawing.Size(154, 17);
            this.chkFalgDep.TabIndex = 24;
            this.chkFalgDep.Tag = "";
            this.chkFalgDep.Text = "Utilizzabile dal Dipartimento";
            this.chkFalgDep.UseVisualStyleBackColor = true;
            this.chkFalgDep.Visible = false;
            // 
            // chbAttivo
            // 
            this.chbAttivo.Location = new System.Drawing.Point(578, 10);
            this.chbAttivo.Name = "chbAttivo";
            this.chbAttivo.Size = new System.Drawing.Size(73, 24);
            this.chbAttivo.TabIndex = 23;
            this.chbAttivo.Tag = "accmotive.active:S:N";
            this.chbAttivo.Text = "Attivo";
            this.chbAttivo.Click += new System.EventHandler(this.chbAttivo_Click);
            // 
            // gboxConti
            // 
            this.gboxConti.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxConti.Controls.Add(this.dataGrid1);
            this.gboxConti.Controls.Add(this.button2);
            this.gboxConti.Controls.Add(this.button3);
            this.gboxConti.Controls.Add(this.button1);
            this.gboxConti.Location = new System.Drawing.Point(16, 128);
            this.gboxConti.Name = "gboxConti";
            this.gboxConti.Size = new System.Drawing.Size(630, 351);
            this.gboxConti.TabIndex = 22;
            this.gboxConti.TabStop = false;
            this.gboxConti.Text = "Conti movimentati";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(104, 24);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(518, 319);
            this.dataGrid1.TabIndex = 22;
            this.dataGrid1.Tag = "accmotivedetail.lista.single";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 20;
            this.button2.Tag = "edit.single";
            this.button2.Text = "Correggi";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(16, 88);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 21;
            this.button3.Tag = "delete";
            this.button3.Text = "Cancella";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 19;
            this.button1.Tag = "insert.single";
            this.button1.Text = "Aggiungi";
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(16, 80);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(630, 42);
            this.txtDenominazione.TabIndex = 4;
            this.txtDenominazione.Tag = "accmotive.title";
            // 
            // lblDenominazione
            // 
            this.lblDenominazione.Location = new System.Drawing.Point(8, 56);
            this.lblDenominazione.Name = "lblDenominazione";
            this.lblDenominazione.Size = new System.Drawing.Size(88, 24);
            this.lblDenominazione.TabIndex = 18;
            this.lblDenominazione.Text = "Denominazione:";
            this.lblDenominazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(16, 32);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(160, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "accmotive.codemotive";
            // 
            // lblCodice
            // 
            this.lblCodice.Location = new System.Drawing.Point(16, 8);
            this.lblCodice.Name = "lblCodice";
            this.lblCodice.Size = new System.Drawing.Size(56, 24);
            this.lblCodice.TabIndex = 15;
            this.lblCodice.Text = "Codice:";
            this.lblCodice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabApplicabilita
            // 
            this.tabApplicabilita.Controls.Add(this.grpOperazioni);
            this.tabApplicabilita.Controls.Add(this.label1);
            this.tabApplicabilita.Location = new System.Drawing.Point(4, 23);
            this.tabApplicabilita.Name = "tabApplicabilita";
            this.tabApplicabilita.Size = new System.Drawing.Size(654, 490);
            this.tabApplicabilita.TabIndex = 1;
            this.tabApplicabilita.Text = "Applicabilità";
            this.tabApplicabilita.UseVisualStyleBackColor = true;
            // 
            // grpOperazioni
            // 
            this.grpOperazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOperazioni.Controls.Add(this.listView1);
            this.grpOperazioni.Location = new System.Drawing.Point(8, 24);
            this.grpOperazioni.Name = "grpOperazioni";
            this.grpOperazioni.Size = new System.Drawing.Size(638, 463);
            this.grpOperazioni.TabIndex = 2;
            this.grpOperazioni.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.Location = new System.Drawing.Point(8, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(622, 439);
            this.listView1.TabIndex = 0;
            this.listView1.Tag = "epoperation.lista";
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(488, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Elenco delle Operazioni associabili alla causale:";
            // 
            // tabClassificazione
            // 
            this.tabClassificazione.Controls.Add(this.dGridClassSup);
            this.tabClassificazione.Controls.Add(this.btnElimina);
            this.tabClassificazione.Controls.Add(this.btnModifica);
            this.tabClassificazione.Controls.Add(this.btnInserisci);
            this.tabClassificazione.ImageIndex = 1;
            this.tabClassificazione.Location = new System.Drawing.Point(4, 23);
            this.tabClassificazione.Name = "tabClassificazione";
            this.tabClassificazione.Size = new System.Drawing.Size(654, 490);
            this.tabClassificazione.TabIndex = 2;
            this.tabClassificazione.Text = "Classificazione";
            this.tabClassificazione.UseVisualStyleBackColor = true;
            // 
            // dGridClassSup
            // 
            this.dGridClassSup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dGridClassSup.DataMember = "";
            this.dGridClassSup.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dGridClassSup.Location = new System.Drawing.Point(79, 8);
            this.dGridClassSup.Name = "dGridClassSup";
            this.dGridClassSup.Size = new System.Drawing.Size(567, 474);
            this.dGridClassSup.TabIndex = 21;
            this.dGridClassSup.Tag = "accmotivesorting.default.default";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(1, 72);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 24);
            this.btnElimina.TabIndex = 20;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(1, 40);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 24);
            this.btnModifica.TabIndex = 19;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(1, 8);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 24);
            this.btnInserisci.TabIndex = 18;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            
            // 
            // FrmAccMotive_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(948, 517);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmAccMotive_default";
            this.Text = "FrmAccMotive_default";
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.grpNaturadiSpesa.ResumeLayout(false);
            this.grpNaturadiSpesa.PerformLayout();
            this.gboxConti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabApplicabilita.ResumeLayout(false);
            this.grpOperazioni.ResumeLayout(false);
            this.tabClassificazione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dGridClassSup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.accmotivedetail,filter);
			GetData.SetStaticFilter(DS.accmotivedetailview, filter);
			GetData.SetStaticFilter(DS.sortingview, filter);
			GetData.CacheTable(DS.epoperation,null,"title",false);
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "accmotive") {
				if (R == null) {
					grpOperazioni.Visible = false;
                    gboxConti.Visible = false;
                    grpNaturadiSpesa.Visible = false;
				}
				else {
					string idAccMotive = R["idaccmotive"].ToString();
					string filtro = QHC.Like("paridaccmotive", R["idaccmotive"].ToString() + "%");
					DataRow [] rAccMotive = DS.accmotive.Select(filtro);
					grpOperazioni.Visible = (rAccMotive.Length == 0);
                    gboxConti.Visible = (rAccMotive.Length == 0);
                    grpNaturadiSpesa.Visible = (rAccMotive.Length == 0);
				}
			}
		}

		public void MetaData_AfterFill() {
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
            //if (!Meta.IsEmpty && Meta.EditMode) {
            //    txtCodice.ReadOnly = true;
            //}
            //if (Meta.InsertMode) {
            //    txtCodice.ReadOnly = false;
            //}
		}

		public void MetaData_AfterClear() {
			grpOperazioni.Visible = true;
            gboxConti.Visible = true;
            grpNaturadiSpesa.Visible = true;
            //txtCodice.ReadOnly = false;
            Meta.CanInsert = false;
		}

		private void chbAttivo_Click(object sender, System.EventArgs e) {
			if (!Meta.IsEmpty){
				if (chbAttivo.CheckState == CheckState.Indeterminate) {
					chbAttivo.CheckState=CheckState.Unchecked;
				}
			}
		}

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
        }
	}
}
