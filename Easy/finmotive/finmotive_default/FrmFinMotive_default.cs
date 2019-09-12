/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace finmotive_default
{
	/// <summary>
	/// Summary description for FrmAccMotive_default.
	/// </summary>
	public class FrmFinMotive_default : System.Windows.Forms.Form
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
		private System.Windows.Forms.GroupBox gboxBilancio;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.ComponentModel.IContainer components;
		public finmotive_default.vistaForm DS;
        private System.Windows.Forms.CheckBox chbAttivo;
        private ImageList imageList1;

		MetaData Meta;

		public FrmFinMotive_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			DS.finmotivedetail.ExtendedProperties["ViewTable"]= DS.finmotivedetailview;
			DS.finmotivedetailview.ExtendedProperties["RealTable"]= DS.finmotivedetail;

			DS.finmotivedetailview.Columns["idfinmotive"].ExtendedProperties["ViewSource"]="finmotivedetail.idfinmotive";
			DS.finmotivedetailview.Columns["idfin"].ExtendedProperties["ViewSource"]="finmotivedetail.idfin";

			DS.finmotivedetailview.Columns["ayear"].ExtendedProperties["ViewSource"]="finmotivedetail.ayear";
			DS.finmotivedetailview.Columns["cu"].ExtendedProperties["ViewSource"]="finmotivedetail.cu";
			DS.finmotivedetailview.Columns["ct"].ExtendedProperties["ViewSource"]="finmotivedetail.ct";
			DS.finmotivedetailview.Columns["lu"].ExtendedProperties["ViewSource"]="finmotivedetail.lu";
			DS.finmotivedetailview.Columns["lt"].ExtendedProperties["ViewSource"]="finmotivedetail.lt";


            DS.finmotivedetailview.Columns["finance"].ExtendedProperties["ViewSource"] = "fin.title";
			DS.finmotivedetailview.Columns["codefin"].ExtendedProperties["ViewSource"]="fin.codefin";
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFinMotive_default));
            this.icons = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.MetaDataDetail = new System.Windows.Forms.TabControl();
            this.tabPrincipale = new System.Windows.Forms.TabPage();
            this.chbAttivo = new System.Windows.Forms.CheckBox();
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.lblDenominazione = new System.Windows.Forms.Label();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.lblCodice = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.DS = new finmotive_default.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.tabPrincipale.SuspendLayout();
            this.gboxBilancio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
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
            this.treeView1.Tag = "finmotive.tree";
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
            this.MetaDataDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MetaDataDetail.ImageList = this.imageList1;
            this.MetaDataDetail.Location = new System.Drawing.Point(286, 0);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.SelectedIndex = 0;
            this.MetaDataDetail.Size = new System.Drawing.Size(611, 517);
            this.MetaDataDetail.TabIndex = 5;
            // 
            // tabPrincipale
            // 
            this.tabPrincipale.Controls.Add(this.chbAttivo);
            this.tabPrincipale.Controls.Add(this.gboxBilancio);
            this.tabPrincipale.Controls.Add(this.txtDenominazione);
            this.tabPrincipale.Controls.Add(this.lblDenominazione);
            this.tabPrincipale.Controls.Add(this.txtCodice);
            this.tabPrincipale.Controls.Add(this.lblCodice);
            this.tabPrincipale.Location = new System.Drawing.Point(4, 23);
            this.tabPrincipale.Name = "tabPrincipale";
            this.tabPrincipale.Size = new System.Drawing.Size(603, 490);
            this.tabPrincipale.TabIndex = 0;
            this.tabPrincipale.Text = "Principale";
            this.tabPrincipale.UseVisualStyleBackColor = true;
            // 
            // chbAttivo
            // 
            this.chbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chbAttivo.Location = new System.Drawing.Point(527, 0);
            this.chbAttivo.Name = "chbAttivo";
            this.chbAttivo.Size = new System.Drawing.Size(73, 24);
            this.chbAttivo.TabIndex = 23;
            this.chbAttivo.Tag = "finmotive.active:S:N";
            this.chbAttivo.Text = "Attivo";
            this.chbAttivo.Click += new System.EventHandler(this.chbAttivo_Click);
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilancio.Controls.Add(this.dataGrid1);
            this.gboxBilancio.Controls.Add(this.button2);
            this.gboxBilancio.Controls.Add(this.button3);
            this.gboxBilancio.Controls.Add(this.button1);
            this.gboxBilancio.Location = new System.Drawing.Point(16, 128);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(579, 351);
            this.gboxBilancio.TabIndex = 22;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Text = "Voci di Bilancio movimentate";
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
            this.dataGrid1.Size = new System.Drawing.Size(467, 319);
            this.dataGrid1.TabIndex = 22;
            this.dataGrid1.Tag = "finmotivedetail.lista.single";
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
            this.txtDenominazione.Size = new System.Drawing.Size(579, 42);
            this.txtDenominazione.TabIndex = 4;
            this.txtDenominazione.Tag = "finmotive.title";
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
            this.txtCodice.Tag = "finmotive.codemotive";
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
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // FrmFinMotive_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(897, 517);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.treeView1);
            this.Name = "FrmFinMotive_default";
            this.Text = "FrmFinMotive_default";
            this.MetaDataDetail.ResumeLayout(false);
            this.tabPrincipale.ResumeLayout(false);
            this.tabPrincipale.PerformLayout();
            this.gboxBilancio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
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
			GetData.SetStaticFilter(DS.finmotivedetail,filter);
			GetData.SetStaticFilter(DS.finmotivedetailview, filter);
			
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (T.TableName == "finmotive") {
				if (R == null) {
                    gboxBilancio.Visible = false;
				}
				else {
					string idAccMotive = R["idfinmotive"].ToString();
					string filtro = QHC.Like("paridfinmotive", R["idfinmotive"].ToString() + "%");
					DataRow [] rAccMotive = DS.finmotive.Select(filtro);
                    gboxBilancio.Visible = (rAccMotive.Length == 0);
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
            gboxBilancio.Visible = true;
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
