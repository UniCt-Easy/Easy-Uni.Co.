
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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


namespace clawbacksetup_default//automatismirecuperi//
{
	/// <summary>
	/// Summary description for frmautomatismirecuperi.
	/// </summary>
	public class Frm_clawbacksetup_default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox gboxBilancioEntrata;
		private System.Windows.Forms.Button btnRecupero;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.TextBox txtBilancioE;
		private System.Windows.Forms.Button btnBilancio;
		private System.ComponentModel.IContainer components;
		public dsmeta DS;
		private System.Windows.Forms.ComboBox cmbTipoRecupero;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.TextBox txtCodiceCausale;
		private System.Windows.Forms.Button button2;
        private GroupBox grpBilancioUscita;
        private TextBox textBox1;
        private TextBox txtBilancioS;
        private Button btnBilancioS;
        MetaData Meta;

		public Frm_clawbacksetup_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_clawbacksetup_default));
            this.gboxBilancioEntrata = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancioE = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.cmbTipoRecupero = new System.Windows.Forms.ComboBox();
            this.DS = new clawbacksetup_default.dsmeta();
            this.btnRecupero = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.grpBilancioUscita = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtBilancioS = new System.Windows.Forms.TextBox();
            this.btnBilancioS = new System.Windows.Forms.Button();
            this.gboxBilancioEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpBilancioUscita.SuspendLayout();
            this.SuspendLayout();
            // 
            // gboxBilancioEntrata
            // 
            this.gboxBilancioEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxBilancioEntrata.Controls.Add(this.txtDescrBilancio);
            this.gboxBilancioEntrata.Controls.Add(this.txtBilancioE);
            this.gboxBilancioEntrata.Controls.Add(this.btnBilancio);
            this.gboxBilancioEntrata.Location = new System.Drawing.Point(16, 136);
            this.gboxBilancioEntrata.Name = "gboxBilancioEntrata";
            this.gboxBilancioEntrata.Size = new System.Drawing.Size(474, 117);
            this.gboxBilancioEntrata.TabIndex = 14;
            this.gboxBilancioEntrata.TabStop = false;
            this.gboxBilancioEntrata.Tag = "AutoManage.txtBilancioE.treeE";
            this.gboxBilancioEntrata.Text = "Partita di giro in entrata per il recupero";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(136, 24);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(330, 52);
            this.txtDescrBilancio.TabIndex = 64;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "fin_e.title";
            // 
            // txtBilancioE
            // 
            this.txtBilancioE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBilancioE.Location = new System.Drawing.Point(16, 79);
            this.txtBilancioE.Name = "txtBilancioE";
            this.txtBilancioE.Size = new System.Drawing.Size(450, 20);
            this.txtBilancioE.TabIndex = 1;
            this.txtBilancioE.Tag = "fin_e.codefin?clawbacksetupview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(16, 49);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(96, 24);
            this.btnBilancio.TabIndex = 65;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "manage.fin_e.treeE";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // cmbTipoRecupero
            // 
            this.cmbTipoRecupero.DataSource = this.DS.clawback;
            this.cmbTipoRecupero.DisplayMember = "description";
            this.cmbTipoRecupero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoRecupero.Location = new System.Drawing.Point(128, 16);
            this.cmbTipoRecupero.Name = "cmbTipoRecupero";
            this.cmbTipoRecupero.Size = new System.Drawing.Size(288, 21);
            this.cmbTipoRecupero.TabIndex = 1;
            this.cmbTipoRecupero.Tag = "clawbacksetup.idclawback?clawbacksetupview.idclawback";
            this.cmbTipoRecupero.ValueMember = "idclawback";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btnRecupero
            // 
            this.btnRecupero.BackColor = System.Drawing.SystemColors.Control;
            this.btnRecupero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnRecupero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRecupero.Location = new System.Drawing.Point(24, 16);
            this.btnRecupero.Name = "btnRecupero";
            this.btnRecupero.Size = new System.Drawing.Size(88, 23);
            this.btnRecupero.TabIndex = 12;
            this.btnRecupero.TabStop = false;
            this.btnRecupero.Tag = "manage.clawback.default";
            this.btnRecupero.Text = "Recupero";
            this.btnRecupero.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.txtCodiceCausale);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Location = new System.Drawing.Point(16, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(328, 80);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoManage.txtCodiceCausale.tree";
            this.groupBox1.Text = "Causale per le scritture in partita doppia";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(120, 16);
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(200, 56);
            this.textBox5.TabIndex = 2;
            this.textBox5.TabStop = false;
            this.textBox5.Tag = "accmotiveapplied.motive";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(8, 48);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied.codemotive?clawbacksetupview.codemotive";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 0;
            this.button2.Tag = "manage.accmotiveapplied.tree";
            this.button2.Text = "Causale";
            // 
            // grpBilancioUscita
            // 
            this.grpBilancioUscita.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBilancioUscita.Controls.Add(this.textBox1);
            this.grpBilancioUscita.Controls.Add(this.txtBilancioS);
            this.grpBilancioUscita.Controls.Add(this.btnBilancioS);
            this.grpBilancioUscita.Location = new System.Drawing.Point(16, 259);
            this.grpBilancioUscita.Name = "grpBilancioUscita";
            this.grpBilancioUscita.Size = new System.Drawing.Size(474, 117);
            this.grpBilancioUscita.TabIndex = 16;
            this.grpBilancioUscita.TabStop = false;
            this.grpBilancioUscita.Tag = "AutoManage.txtBilancioS.treeS";
            this.grpBilancioUscita.Text = "Partita di giro in uscita  per il recupero";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(136, 24);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(330, 64);
            this.textBox1.TabIndex = 64;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "fin_s.title";
            // 
            // txtBilancioS
            // 
            this.txtBilancioS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBilancioS.Location = new System.Drawing.Point(16, 91);
            this.txtBilancioS.Name = "txtBilancioS";
            this.txtBilancioS.Size = new System.Drawing.Size(450, 20);
            this.txtBilancioS.TabIndex = 1;
            this.txtBilancioS.Tag = "fin_s.codefin?clawbacksetupview.codefin_s";
            // 
            // btnBilancioS
            // 
            this.btnBilancioS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancioS.ImageIndex = 0;
            this.btnBilancioS.ImageList = this.imageList1;
            this.btnBilancioS.Location = new System.Drawing.Point(16, 61);
            this.btnBilancioS.Name = "btnBilancioS";
            this.btnBilancioS.Size = new System.Drawing.Size(96, 24);
            this.btnBilancioS.TabIndex = 65;
            this.btnBilancioS.TabStop = false;
            this.btnBilancioS.Tag = "manage.fin_s.treeS";
            this.btnBilancioS.Text = "Bilancio:";
            this.btnBilancioS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_clawbacksetup_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(500, 401);
            this.Controls.Add(this.grpBilancioUscita);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gboxBilancioEntrata);
            this.Controls.Add(this.cmbTipoRecupero);
            this.Controls.Add(this.btnRecupero);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_clawbacksetup_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmautomatismirecuperi";
            this.gboxBilancioEntrata.ResumeLayout(false);
            this.gboxBilancioEntrata.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBilancioUscita.ResumeLayout(false);
            this.grpBilancioUscita.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			GetData.SetStaticFilter(DS.fin_e, "(ayear='"+Meta.GetSys("esercizio").ToString()+"') AND ((flag & 1)=0)");
			GetData.SetStaticFilter(DS.fin_s, "(ayear='"+Meta.GetSys("esercizio").ToString()+"') AND ((flag & 1)<>0)");
			GetData.SetStaticFilter(DS.clawbacksetupview,"(ayear='"+Meta.GetSys("esercizio").ToString()+"')");
			string filterEpOperation = "(idepoperation='clawback')"; //maria
			DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams]=filterEpOperation; //maria
			GetData.SetStaticFilter(DS.accmotiveapplied,filterEpOperation); //maria


		}

	}
}
