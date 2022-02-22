
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
using metaeasylibrary;
using metadatalibrary;
using System.Data.SqlClient;
using funzioni_configurazione;



namespace patrimony_default
{
	/// <summary>
	/// Summary description for Frm_patrimony.
	/// </summary>
	public class Frm_patrimony_default : MetaDataForm
	{
		public patrimony_default.vistaForm DS;
		public string filteresercizio;
		MetaData Meta;
		private System.Windows.Forms.TreeView treeView1;
		public System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtordinestampa;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox grpParte;
		private System.Windows.Forms.RadioButton rdbattiva;
		private System.Windows.Forms.RadioButton rdbpassiva;
		public System.Windows.Forms.TabControl MetaDataDetail;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.CheckBox chbpatrimonyattivo;
		private System.ComponentModel.IContainer components;// = null;

		public Frm_patrimony_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_patrimony_default));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chbpatrimonyattivo = new System.Windows.Forms.CheckBox();
            this.grpParte = new System.Windows.Forms.GroupBox();
            this.rdbpassiva = new System.Windows.Forms.RadioButton();
            this.rdbattiva = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtordinestampa = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.DS = new patrimony_default.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpParte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.icons;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowPlusMinus = false;
            this.treeView1.Size = new System.Drawing.Size(400, 408);
            this.treeView1.TabIndex = 0;
            this.treeView1.Tag = "patrimony.treeAP";
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // icons
            // 
            this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
            this.icons.TransparentColor = System.Drawing.Color.Transparent;
            this.icons.Images.SetKeyName(0, "");
            this.icons.Images.SetKeyName(1, "");
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.tabPage1);
            this.MetaDataDetail.Location = new System.Drawing.Point(402, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(462, 412);
            this.MetaDataDetail.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chbpatrimonyattivo);
            this.tabPage1.Controls.Add(this.grpParte);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDenominazione);
            this.tabPage1.Controls.Add(this.txtordinestampa);
            this.tabPage1.Controls.Add(this.txtCodice);
            this.tabPage1.Controls.Add(this.cmbLivello);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(454, 386);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            // 
            // chbpatrimonyattivo
            // 
            this.chbpatrimonyattivo.Location = new System.Drawing.Point(32, 232);
            this.chbpatrimonyattivo.Name = "chbpatrimonyattivo";
            this.chbpatrimonyattivo.Size = new System.Drawing.Size(104, 16);
            this.chbpatrimonyattivo.TabIndex = 8;
            this.chbpatrimonyattivo.Tag = "patrimony.active:S:N";
            this.chbpatrimonyattivo.Text = "Attivo";
            this.chbpatrimonyattivo.Click += new System.EventHandler(this.chbpatrimonyattivo_Click);
            // 
            // grpParte
            // 
            this.grpParte.Controls.Add(this.rdbpassiva);
            this.grpParte.Controls.Add(this.rdbattiva);
            this.grpParte.Location = new System.Drawing.Point(344, 32);
            this.grpParte.Name = "grpParte";
            this.grpParte.Size = new System.Drawing.Size(103, 72);
            this.grpParte.TabIndex = 4;
            this.grpParte.TabStop = false;
            this.grpParte.Text = "Parte";
            // 
            // rdbpassiva
            // 
            this.rdbpassiva.Location = new System.Drawing.Point(16, 48);
            this.rdbpassiva.Name = "rdbpassiva";
            this.rdbpassiva.Size = new System.Drawing.Size(81, 16);
            this.rdbpassiva.TabIndex = 5;
            this.rdbpassiva.Tag = "patrimony.patpart:P";
            this.rdbpassiva.Text = "Passività";
            this.rdbpassiva.CheckedChanged += new System.EventHandler(this.rdbpassiva_CheckedChanged);
            // 
            // rdbattiva
            // 
            this.rdbattiva.Location = new System.Drawing.Point(16, 16);
            this.rdbattiva.Name = "rdbattiva";
            this.rdbattiva.Size = new System.Drawing.Size(81, 16);
            this.rdbattiva.TabIndex = 5;
            this.rdbattiva.Tag = "patrimony.patpart:A";
            this.rdbattiva.Text = "Attività";
            this.rdbattiva.CheckedChanged += new System.EventHandler(this.rdbattiva_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(24, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Denominazione";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ordine Stampa";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(24, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Codice";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Livello";
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Location = new System.Drawing.Point(128, 112);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(319, 88);
            this.txtDenominazione.TabIndex = 3;
            this.txtDenominazione.Tag = "patrimony.title";
            // 
            // txtordinestampa
            // 
            this.txtordinestampa.Location = new System.Drawing.Point(128, 80);
            this.txtordinestampa.Name = "txtordinestampa";
            this.txtordinestampa.Size = new System.Drawing.Size(208, 20);
            this.txtordinestampa.TabIndex = 2;
            this.txtordinestampa.Tag = "patrimony.printingorder";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(128, 56);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(208, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "patrimony.codepatrimony";
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.patrimonylevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Location = new System.Drawing.Point(128, 32);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(208, 21);
            this.cmbLivello.TabIndex = 0;
            this.cmbLivello.Tag = "patrimony.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_patrimony_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(864, 410);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.treeView1);
            this.Name = "Frm_patrimony_default";
            this.Text = "Frm_patrimony";
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpParte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			filteresercizio= QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
		    Meta.additional_search_condition = filteresercizio;
			GetData.SetStaticFilter(DS.patrimony,filteresercizio);
            //GetData.SetStaticFilter(DS.patrimonyview,filteresercizio);
			GetData.SetSorting(DS.patrimony,"printingorder");
			GetData.CacheTable(DS.patrimonylevel,filteresercizio,null,true);		
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R)
		{
			if (T.TableName != "patrimony") return;
			cmbLivello.Enabled=false;
			grpParte.Enabled=false;
			if (R==null) return;
			txtCodice.ReadOnly = Meta.EditMode;
			txtordinestampa.ReadOnly = Meta.EditMode;
		}
		

		private void rdbpassiva_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbpassiva.Checked)	{
				MetaData.SetDefault(DS.patrimony,"patpart", "P");
			}
		}

		private void rdbattiva_CheckedChanged(object sender, System.EventArgs e)
		{
			if (rdbattiva.Checked)	{
				MetaData.SetDefault(DS.patrimony,"patpart", "A");
			}
		}

		public void MetaData_AfterFill()
		{
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
			//abilita/disabilita i controlli
			grpParte.Enabled=false;
			cmbLivello.Enabled=false;
			txtCodice.ReadOnly = Meta.EditMode;
			txtordinestampa.ReadOnly = Meta.EditMode;
		}
		public void MetaData_AfterClear()
		{
			grpParte.Enabled=true;
			cmbLivello.Enabled=true;
			txtCodice.ReadOnly=false;
			txtordinestampa.ReadOnly=false;
			txtDenominazione.ReadOnly=false;
            Meta.CanInsert = false;
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }

			TreeNode TN = e.Node;
			if (TN.Tag!=null) return;
			if (TN.Text.ToUpper()=="A"){
				DS.Tables["patrimony"].Columns["patpart"].DefaultValue="A";
			}
			else {
				DS.Tables["patrimony"].Columns["patpart"].DefaultValue="P";
			}
		}

		private void chbpatrimonyattivo_Click(object sender, System.EventArgs e)
		{
			if (!Meta.IsEmpty) 
			{
				if (((CheckBox)sender).CheckState==CheckState.Indeterminate)
					((CheckBox)sender).CheckState=CheckState.Unchecked;
			}
		}
	}
}
