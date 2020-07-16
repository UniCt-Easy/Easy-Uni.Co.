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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace taxregionsetupview_single//automatismiregionegeosingle//
{
	/// <summary>
	/// Summary description for frmautomatismiregionegeosingle.
	/// </summary>
	public class Frm_taxregionsetupview_single : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TextBox txtCredDeb;
		public vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.GroupBox grpTipo;
		private System.Windows.Forms.TextBox txtRegione;
        private System.Windows.Forms.TextBox txtProvincia;
		private System.Windows.Forms.RadioButton rdoRegione;
        private System.Windows.Forms.RadioButton rdoProvincia;
		private System.Windows.Forms.GroupBox grpRegione;
        private System.Windows.Forms.GroupBox grpProvincia;
		private MetaData Meta;

		public Frm_taxregionsetupview_single()
		{
			InitializeComponent();
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
            this.grpTipo = new System.Windows.Forms.GroupBox();
            this.rdoProvincia = new System.Windows.Forms.RadioButton();
            this.rdoRegione = new System.Windows.Forms.RadioButton();
            this.grpProvincia = new System.Windows.Forms.GroupBox();
            this.txtProvincia = new System.Windows.Forms.TextBox();
            this.grpRegione = new System.Windows.Forms.GroupBox();
            this.txtRegione = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCredDeb = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DS = new taxregionsetupview_single.vistaForm();
            this.grpTipo.SuspendLayout();
            this.grpProvincia.SuspendLayout();
            this.grpRegione.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpTipo
            // 
            this.grpTipo.Controls.Add(this.rdoProvincia);
            this.grpTipo.Controls.Add(this.rdoRegione);
            this.grpTipo.Controls.Add(this.grpProvincia);
            this.grpTipo.Controls.Add(this.grpRegione);
            this.grpTipo.Location = new System.Drawing.Point(16, 16);
            this.grpTipo.Name = "grpTipo";
            this.grpTipo.Size = new System.Drawing.Size(408, 123);
            this.grpTipo.TabIndex = 0;
            this.grpTipo.TabStop = false;
            this.grpTipo.Tag = "";
            this.grpTipo.Text = "Tipo ente";
            // 
            // rdoProvincia
            // 
            this.rdoProvincia.Location = new System.Drawing.Point(16, 80);
            this.rdoProvincia.Name = "rdoProvincia";
            this.rdoProvincia.Size = new System.Drawing.Size(80, 16);
            this.rdoProvincia.TabIndex = 10;
            this.rdoProvincia.Tag = "taxregionsetupview.kind:P";
            this.rdoProvincia.Text = "Provincia";
            this.rdoProvincia.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // rdoRegione
            // 
            this.rdoRegione.Location = new System.Drawing.Point(16, 32);
            this.rdoRegione.Name = "rdoRegione";
            this.rdoRegione.Size = new System.Drawing.Size(80, 16);
            this.rdoRegione.TabIndex = 9;
            this.rdoRegione.Tag = "taxregionsetupview.kind:R";
            this.rdoRegione.Text = "Regione";
            this.rdoRegione.CheckedChanged += new System.EventHandler(this.CheckedChanged);
            // 
            // grpProvincia
            // 
            this.grpProvincia.Controls.Add(this.txtProvincia);
            this.grpProvincia.Location = new System.Drawing.Point(104, 64);
            this.grpProvincia.Name = "grpProvincia";
            this.grpProvincia.Size = new System.Drawing.Size(288, 48);
            this.grpProvincia.TabIndex = 7;
            this.grpProvincia.TabStop = false;
            this.grpProvincia.Tag = "AutoChoose.txtProvincia.default";
            // 
            // txtProvincia
            // 
            this.txtProvincia.Location = new System.Drawing.Point(16, 16);
            this.txtProvincia.Name = "txtProvincia";
            this.txtProvincia.Size = new System.Drawing.Size(256, 20);
            this.txtProvincia.TabIndex = 6;
            this.txtProvincia.Tag = "geo_country.title?x";
            // 
            // grpRegione
            // 
            this.grpRegione.Controls.Add(this.txtRegione);
            this.grpRegione.Location = new System.Drawing.Point(104, 16);
            this.grpRegione.Name = "grpRegione";
            this.grpRegione.Size = new System.Drawing.Size(288, 48);
            this.grpRegione.TabIndex = 6;
            this.grpRegione.TabStop = false;
            this.grpRegione.Tag = "AutoChoose.txtRegione.default";
            // 
            // txtRegione
            // 
            this.txtRegione.Location = new System.Drawing.Point(16, 16);
            this.txtRegione.Name = "txtRegione";
            this.txtRegione.Size = new System.Drawing.Size(256, 20);
            this.txtRegione.TabIndex = 5;
            this.txtRegione.Tag = "geo_region.title?x";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtCredDeb);
            this.groupBox2.Location = new System.Drawing.Point(16, 145);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 48);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtCredDeb.lista.(active=\'S\')";
            this.groupBox2.Text = "Percipiente";
            // 
            // txtCredDeb
            // 
            this.txtCredDeb.Location = new System.Drawing.Point(16, 16);
            this.txtCredDeb.Name = "txtCredDeb";
            this.txtCredDeb.Size = new System.Drawing.Size(376, 20);
            this.txtCredDeb.TabIndex = 0;
            this.txtCredDeb.Tag = "registry.title?x";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(136, 206);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(240, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Annulla";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_taxregionsetupview_single
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(438, 241);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpTipo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Frm_taxregionsetupview_single";
            this.Tag = "";
            this.Text = "frmautomatismiregionegeosingle";
            this.grpTipo.ResumeLayout(false);
            this.grpProvincia.ResumeLayout(false);
            this.grpProvincia.PerformLayout();
            this.grpRegione.ResumeLayout(false);
            this.grpRegione.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
		}

		public void MetaData_AfterFill() {
			if (Meta.FirstFillForThisRow) Abilita();
		}

//		public void MetaData_BeforeFill() {
//			if (Meta.EditMode && Meta.FirstFillForThisRow) {
//				DataRow R=DS.automatismiregionegeoview.Rows[0];
//				string tipo=R["tipo"].ToString();
//				switch(tipo) {
//					case "R":
//						R["!idregione"]=R["idgeo"];
//						break;
//					case "P":
//						R["!idprovincia"]=R["idgeo"];
//						break;
//					case "E":
//						R["!idnazione"]=R["idgeo"];
//						break;
//				}
//			}
//		}

//		public void MetaData_AfterFill() {
//			System.Diagnostics.Debug.WriteLine("MetaData_AfterFill()");
//		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
			if (Meta.IsEmpty) return;
			if (T.TableName == "geo_region" ||
				T.TableName == "geo_country" ||
				T.TableName == "geo_nation") {
				DS.taxregionsetupview.Rows[0]["place"]=(R==null?"":R["title"]);
			}
			if (T.TableName == "registry") {
				DS.taxregionsetupview.Rows[0]["regionalagencytitle"]=(R==null?"":R["title"]);
			}
		}


		public void MetaData_BeforeActivation() {
			DataRelation rel1=DS.Relations["geo_regiontaxregionsetupview"];
			DataRelation rel2=DS.Relations["geo_countrytaxregionsetupview"];
			DataRelation rel3=DS.Relations["geo_nationtaxregionsetupview"];
			QueryCreator.SetRelationActivationFilter(rel1,"(kind='R')");
			QueryCreator.SetRelationActivationFilter(rel2,"(kind='P')");
			QueryCreator.SetRelationActivationFilter(rel3,"(kind='E')");
		}

		public void MetaData_AfterGetFormData() {
			Abilita();
		}

		private void Abilita() {
			if (Meta.IsEmpty) return;
			DataRow R=DS.taxregionsetupview.Rows[0];
			string tipo=R["kind"].ToString();
			switch(tipo) {
				case "R":
					txtRegione.ReadOnly=false;
                    grpRegione.Visible = true;

					txtProvincia.ReadOnly=true;
                    grpProvincia.Visible = false;

					break;
				case "P":
					txtRegione.ReadOnly=true;
                    grpRegione.Visible = false;

					txtProvincia.ReadOnly=false;
                    grpProvincia.Visible = true;

					break;
                //case "E":
                //    txtRegione.ReadOnly=true;
                //    grpRegione.Visible = false;

                //    txtProvincia.ReadOnly=true;
                //    grpProvincia.Visible = false;

                //    break;
				default:
					txtRegione.ReadOnly=false;
                    grpRegione.Visible = true;
					txtProvincia.ReadOnly=false;
                    grpProvincia.Visible = true;
					break;
			}
		}

		private void CheckedChanged(object sender, System.EventArgs e) {
			if (Meta!=null) {

				if (Meta.DrawStateIsDone)	Meta.GetFormData(true);
			}
		}
	}
}
