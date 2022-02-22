
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

namespace regionalratevalidity_default//strutturaaliquoteregionali//
{
	/// <summary>
	/// Summary description for frmstrutturaaliquoteregionali.
	/// </summary>
	public class Frm_regionalratevalidity_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox grpScaglioni;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbTipoRitenuta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpRegione;
		public System.Windows.Forms.TextBox txtGeoRegione;
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_regionalratevalidity_default()
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
			this.DS = new regionalratevalidity_default.vistaForm();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.grpScaglioni = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.label3 = new System.Windows.Forms.Label();
			this.grpRegione = new System.Windows.Forms.GroupBox();
			this.txtGeoRegione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbTipoRitenuta = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.grpScaglioni.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.grpRegione.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 104);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(120, 20);
			this.textBox1.TabIndex = 3;
			this.textBox1.Tag = "regionalratevalidity.validitystart";
			this.textBox1.Text = "";
			// 
			// grpScaglioni
			// 
			this.grpScaglioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.grpScaglioni.Controls.Add(this.button3);
			this.grpScaglioni.Controls.Add(this.button2);
			this.grpScaglioni.Controls.Add(this.button1);
			this.grpScaglioni.Controls.Add(this.dataGrid1);
			this.grpScaglioni.Location = new System.Drawing.Point(8, 160);
			this.grpScaglioni.Name = "grpScaglioni";
			this.grpScaglioni.Size = new System.Drawing.Size(408, 264);
			this.grpScaglioni.TabIndex = 51;
			this.grpScaglioni.TabStop = false;
			this.grpScaglioni.Text = "Scaglioni della ritenuta";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(320, 16);
			this.button3.Name = "button3";
			this.button3.TabIndex = 46;
			this.button3.TabStop = false;
			this.button3.Tag = "delete";
			this.button3.Text = "Elimina";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(232, 16);
			this.button2.Name = "button2";
			this.button2.TabIndex = 45;
			this.button2.TabStop = false;
			this.button2.Tag = "edit.single";
			this.button2.Text = "Modifica";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(144, 16);
			this.button1.Name = "button1";
			this.button1.TabIndex = 44;
			this.button1.TabStop = false;
			this.button1.Tag = "insert.single";
			this.button1.Text = "Nuovo";
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(392, 208);
			this.dataGrid1.TabIndex = 43;
			this.dataGrid1.Tag = "regionalratebracket.default.single";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 49;
			this.label3.Text = "Data Inizio Struttura";
			this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// grpRegione
			// 
			this.grpRegione.Controls.Add(this.txtGeoRegione);
			this.grpRegione.Location = new System.Drawing.Point(120, 40);
			this.grpRegione.Name = "grpRegione";
			this.grpRegione.Size = new System.Drawing.Size(280, 48);
			this.grpRegione.TabIndex = 2;
			this.grpRegione.TabStop = false;
			this.grpRegione.Tag = "AutoChoose.txtGeoRegione.default";
			// 
			// txtGeoRegione
			// 
			this.txtGeoRegione.Location = new System.Drawing.Point(8, 16);
			this.txtGeoRegione.Name = "txtGeoRegione";
			this.txtGeoRegione.Size = new System.Drawing.Size(264, 20);
			this.txtGeoRegione.TabIndex = 0;
			this.txtGeoRegione.Tag = "geo_region_view.title?regionalratevalidityview.region";
			this.txtGeoRegione.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.TabIndex = 47;
			this.label2.Text = "Regione";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// cmbTipoRitenuta
			// 
			this.cmbTipoRitenuta.DataSource = this.DS.tax;
			this.cmbTipoRitenuta.DisplayMember = "description";
			this.cmbTipoRitenuta.Location = new System.Drawing.Point(120, 16);
			this.cmbTipoRitenuta.Name = "cmbTipoRitenuta";
			this.cmbTipoRitenuta.Size = new System.Drawing.Size(192, 21);
			this.cmbTipoRitenuta.TabIndex = 1;
			this.cmbTipoRitenuta.Tag = "regionalratevalidity.taxcode";
			this.cmbTipoRitenuta.ValueMember = "taxcode";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 45;
			this.label1.Text = "Tipo Ritenuta";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.grpRegione);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.cmbTipoRitenuta);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 144);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dati Generali";
			// 
			// Frm_regionalratevalidity_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(424, 430);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.grpScaglioni);
			this.Name = "Frm_regionalratevalidity_default";
			this.Text = "frmstrutturaaliquoteregionali";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.grpScaglioni.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.grpRegione.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink() 
		{
			MetaData Meta = MetaData.GetMetaData(this);
			bool IsAdmin = (Meta.GetSys("manage_prestazioni")!=null)
				? Meta.GetSys("manage_prestazioni").ToString()=="S"
				: false;
			Meta.CanSave=IsAdmin;
			Meta.CanInsert=IsAdmin;
			Meta.CanInsertCopy=IsAdmin;
			Meta.CanCancel=IsAdmin;
			string filter = "(geoappliance = 'R') and (taxkind = 'F')";
			GetData.SetStaticFilter(DS.tax,filter);
		}
	}
}
