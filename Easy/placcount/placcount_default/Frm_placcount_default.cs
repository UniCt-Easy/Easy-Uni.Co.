/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

namespace placcount_default
{
	/// <summary>
	/// Summary description for Frm_placcount_default.
	/// </summary>
	public class Frm_placcount_default : System.Windows.Forms.Form
	{
		public placcount_default.vistaForm DS;
		public System.Windows.Forms.TabControl MetaDataDetail;
		public System.Windows.Forms.TabPage tabPage1;
		public string filteresercizio;
		MetaData Meta;
		//DataAccess Conn;
		private System.Windows.Forms.GroupBox grpParte;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtDenominazione;
		private System.Windows.Forms.TextBox txtCodice;
		private System.Windows.Forms.ComboBox cmbLivello;
		private System.Windows.Forms.TreeView treeViewContoEcon;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.TextBox txtOrdineStampa;
		private System.Windows.Forms.CheckBox chbAttivo;
		private System.Windows.Forms.RadioButton rdbricavi;
		private System.Windows.Forms.RadioButton rdbcosti;
		private System.ComponentModel.IContainer components;

		public Frm_placcount_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_placcount_default));
            this.DS = new placcount_default.vistaForm();
            this.treeViewContoEcon = new System.Windows.Forms.TreeView();
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chbAttivo = new System.Windows.Forms.CheckBox();
            this.grpParte = new System.Windows.Forms.GroupBox();
            this.rdbricavi = new System.Windows.Forms.RadioButton();
            this.rdbcosti = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.txtOrdineStampa = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.cmbLivello = new System.Windows.Forms.ComboBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpParte.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // treeViewContoEcon
            // 
            this.treeViewContoEcon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewContoEcon.ImageIndex = 1;
            this.treeViewContoEcon.ImageList = this.icons;
            this.treeViewContoEcon.Location = new System.Drawing.Point(0, 0);
            this.treeViewContoEcon.Name = "treeViewContoEcon";
            this.treeViewContoEcon.SelectedImageIndex = 0;
            this.treeViewContoEcon.ShowPlusMinus = false;
            this.treeViewContoEcon.Size = new System.Drawing.Size(401, 306);
            this.treeViewContoEcon.TabIndex = 1;
            this.treeViewContoEcon.Tag = "placcount.treeCR";
            this.treeViewContoEcon.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewContoEcon_AfterSelect);
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
            this.MetaDataDetail.Location = new System.Drawing.Point(403, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(477, 306);
            this.MetaDataDetail.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chbAttivo);
            this.tabPage1.Controls.Add(this.grpParte);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtDenominazione);
            this.tabPage1.Controls.Add(this.txtOrdineStampa);
            this.tabPage1.Controls.Add(this.txtCodice);
            this.tabPage1.Controls.Add(this.cmbLivello);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(469, 280);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principale";
            // 
            // chbAttivo
            // 
            this.chbAttivo.Location = new System.Drawing.Point(25, 220);
            this.chbAttivo.Name = "chbAttivo";
            this.chbAttivo.Size = new System.Drawing.Size(62, 24);
            this.chbAttivo.TabIndex = 11;
            this.chbAttivo.Tag = "placcount.active:S:N";
            this.chbAttivo.Text = "Attivo";
            this.chbAttivo.Click += new System.EventHandler(this.chbAttivo_Click);
            // 
            // grpParte
            // 
            this.grpParte.Controls.Add(this.rdbricavi);
            this.grpParte.Controls.Add(this.rdbcosti);
            this.grpParte.Location = new System.Drawing.Point(372, 32);
            this.grpParte.Name = "grpParte";
            this.grpParte.Size = new System.Drawing.Size(88, 72);
            this.grpParte.TabIndex = 8;
            this.grpParte.TabStop = false;
            this.grpParte.Text = "Parte";
            // 
            // rdbricavi
            // 
            this.rdbricavi.Location = new System.Drawing.Point(8, 48);
            this.rdbricavi.Name = "rdbricavi";
            this.rdbricavi.Size = new System.Drawing.Size(72, 16);
            this.rdbricavi.TabIndex = 1;
            this.rdbricavi.Tag = "placcount.placcpart:R";
            this.rdbricavi.Text = "Ricavi";
            this.rdbricavi.CheckedChanged += new System.EventHandler(this.rdbpassiva_CheckedChanged);
            // 
            // rdbcosti
            // 
            this.rdbcosti.Location = new System.Drawing.Point(8, 16);
            this.rdbcosti.Name = "rdbcosti";
            this.rdbcosti.Size = new System.Drawing.Size(56, 16);
            this.rdbcosti.TabIndex = 0;
            this.rdbcosti.Tag = "placcount.placcpart:C";
            this.rdbcosti.Text = "Costi";
            this.rdbcosti.CheckedChanged += new System.EventHandler(this.rdbattiva_CheckedChanged);
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
            this.txtDenominazione.Size = new System.Drawing.Size(332, 88);
            this.txtDenominazione.TabIndex = 3;
            this.txtDenominazione.Tag = "placcount.title";
            // 
            // txtOrdineStampa
            // 
            this.txtOrdineStampa.Location = new System.Drawing.Point(128, 80);
            this.txtOrdineStampa.Name = "txtOrdineStampa";
            this.txtOrdineStampa.Size = new System.Drawing.Size(176, 20);
            this.txtOrdineStampa.TabIndex = 2;
            this.txtOrdineStampa.Tag = "placcount.printingorder";
            // 
            // txtCodice
            // 
            this.txtCodice.Location = new System.Drawing.Point(128, 56);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(176, 20);
            this.txtCodice.TabIndex = 1;
            this.txtCodice.Tag = "placcount.codeplaccount";
            // 
            // cmbLivello
            // 
            this.cmbLivello.DataSource = this.DS.placcountlevel;
            this.cmbLivello.DisplayMember = "description";
            this.cmbLivello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLivello.Location = new System.Drawing.Point(128, 32);
            this.cmbLivello.Name = "cmbLivello";
            this.cmbLivello.Size = new System.Drawing.Size(176, 21);
            this.cmbLivello.TabIndex = 0;
            this.cmbLivello.Tag = "placcount.nlevel";
            this.cmbLivello.ValueMember = "nlevel";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // Frm_placcount_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(882, 309);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.treeViewContoEcon);
            this.Name = "Frm_placcount_default";
            this.Text = "Frm_placcount_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpParte.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.placcount,filteresercizio);
			//GetData.SetStaticFilter(DS.placcountview,filteresercizio);
			Meta.additional_search_condition = filteresercizio;
			GetData.SetSorting(DS.placcount,"printingorder");
			GetData.CacheTable(DS.placcountlevel,filteresercizio,null,true);		
		}
//
//		private bool TipoNumerico(string codicelivello){
//			DataRow[] Res = DS.placcountlevel.Select("(nlevel='"+codicelivello+"')AND"+
//				filteresercizio);
//			if (Res.Length!=1) return false;
//			string tipocodice=Res[0]["codekind"].ToString().ToUpper();
//			if (tipocodice=="N") return true;
//			return false;
//		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName != "placcount") return;
			cmbLivello.Enabled=false;
			grpParte.Enabled=false;
			if (R==null) return;
			txtCodice.ReadOnly=Meta.EditMode;
			txtOrdineStampa.ReadOnly=Meta.EditMode;
		}

		public void MetaData_AfterFill(){
            if (!Meta.CanInsert) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }
			bool ModoInsert= Meta.InsertMode;
			grpParte.Enabled=false;
			cmbLivello.Enabled=false;
			if (ModoInsert){
				DataRow R = HelpForm.GetLastSelected(DS.placcount);
				txtCodice.ReadOnly=false;
				txtOrdineStampa.ReadOnly=false;
				if (R==null) return;		
			}
			if (!Meta.IsEmpty && Meta.EditMode){
				txtCodice.ReadOnly = true;
				txtOrdineStampa.ReadOnly = true;
			}
		}
		public void MetaData_AfterClear() {
			grpParte.Enabled=true;
			cmbLivello.Enabled=true;
			txtCodice.ReadOnly=false;
			txtOrdineStampa.ReadOnly=false;
			txtDenominazione.ReadOnly=false;
            Meta.CanInsert = false;
		}

		private void rdbattiva_CheckedChanged(object sender, System.EventArgs e) {
			if (rdbcosti.Checked)	{
				MetaData.SetDefault(DS.placcount,"placcpart", "C");
			}
		}

		private void rdbpassiva_CheckedChanged(object sender, System.EventArgs e) {
			if (rdbricavi.Checked)	{
				MetaData.SetDefault(DS.placcount,"placcpart", "R");
			}
		}

		private void treeViewContoEcon_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
            if ((!Meta.IsEmpty) && (!Meta.CanInsert)) {
                Meta.CanInsert = true;
                Meta.FreshToolBar();
            }

			TreeNode TN = e.Node;
			if (TN.Tag!=null) return;
			if (TN.Text.ToUpper()=="C") {
				DS.Tables["placcount"].Columns["placcpart"].DefaultValue="C";
			}
			else {
				DS.Tables["placcount"].Columns["placcpart"].DefaultValue="R";
			}
		}

		private void chbAttivo_Click(object sender, System.EventArgs e) {
			if (!Meta.IsEmpty) {
				if (((CheckBox)sender).CheckState==CheckState.Indeterminate)
					((CheckBox)sender).CheckState=CheckState.Unchecked;
			}
		}


	}
}
