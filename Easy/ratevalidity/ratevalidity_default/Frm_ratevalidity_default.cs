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

namespace ratevalidity_default//strutturaaliquote//
{
	/// <summary>
	/// Summary description for frmstrutturaaliquote.
	/// </summary>
	public class Frm_ratevalidity_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		public vistaForm DS;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btnIndElimina;
		private System.Windows.Forms.Button btnIndModifica;
		private System.Windows.Forms.Button btnIndInserisci;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_ratevalidity_default()
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
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.DS = new ratevalidity_default.vistaForm();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.button3 = new System.Windows.Forms.Button();
			this.btnIndElimina = new System.Windows.Forms.Button();
			this.btnIndModifica = new System.Windows.Forms.Button();
			this.btnIndInserisci = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(128, 64);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(88, 20);
			this.textBox2.TabIndex = 2;
			this.textBox2.Tag = "ratevalidity.validitystart";
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Data Inizio Struttura :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm1";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 48);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(448, 208);
			this.dataGrid1.TabIndex = 4;
			this.dataGrid1.Tag = "ratebracket.default.single";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.tax;
			this.comboBox1.DisplayMember = "description";
			this.comboBox1.Location = new System.Drawing.Point(128, 24);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(336, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "ratevalidity.taxcode";
			this.comboBox1.ValueMember = "taxcode";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(32, 24);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(88, 24);
			this.button3.TabIndex = 8;
			this.button3.TabStop = false;
			this.button3.Tag = "manage.tax.default";
			this.button3.Text = "Tipo ritenuta:";
			this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnIndElimina
			// 
			this.btnIndElimina.Location = new System.Drawing.Point(392, 16);
			this.btnIndElimina.Name = "btnIndElimina";
			this.btnIndElimina.Size = new System.Drawing.Size(68, 22);
			this.btnIndElimina.TabIndex = 14;
			this.btnIndElimina.TabStop = false;
			this.btnIndElimina.Tag = "delete";
			this.btnIndElimina.Text = "Elimina";
			// 
			// btnIndModifica
			// 
			this.btnIndModifica.Location = new System.Drawing.Point(304, 16);
			this.btnIndModifica.Name = "btnIndModifica";
			this.btnIndModifica.Size = new System.Drawing.Size(69, 22);
			this.btnIndModifica.TabIndex = 13;
			this.btnIndModifica.TabStop = false;
			this.btnIndModifica.Tag = "edit.single";
			this.btnIndModifica.Text = "Modifica";
			// 
			// btnIndInserisci
			// 
			this.btnIndInserisci.Location = new System.Drawing.Point(224, 16);
			this.btnIndInserisci.Name = "btnIndInserisci";
			this.btnIndInserisci.Size = new System.Drawing.Size(68, 22);
			this.btnIndInserisci.TabIndex = 12;
			this.btnIndInserisci.TabStop = false;
			this.btnIndInserisci.Tag = "insert.single";
			this.btnIndInserisci.Text = "Nuovo";
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.btnIndElimina);
			this.groupBox1.Controls.Add(this.btnIndModifica);
			this.groupBox1.Controls.Add(this.dataGrid1);
			this.groupBox1.Controls.Add(this.btnIndInserisci);
			this.groupBox1.Location = new System.Drawing.Point(16, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(472, 272);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Scaglioni della ritenuta";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.textBox2);
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.button3);
			this.groupBox2.Location = new System.Drawing.Point(16, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(472, 100);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Dati Generali";
			// 
			// Frm_ratevalidity_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 397);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_ratevalidity_default";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmstrutturaaliquote";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
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
		}
	}
}
