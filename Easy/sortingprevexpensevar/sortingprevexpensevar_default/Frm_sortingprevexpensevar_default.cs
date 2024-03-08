
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace sortingprevexpensevar_default//varclassmovimentispese//
{
	/// <summary>
	/// Summary description for frmvarclassmovimentispese.
	/// </summary>
	public class Frm_sortingprevexpensevar_default : MetaDataForm
	{
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton rdbDiminuzione;
		private System.Windows.Forms.RadioButton rdbAumento;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.GroupBox grpClassificazione;
		private System.Windows.Forms.TextBox txtDescrClass;
		private System.Windows.Forms.TextBox txtCodiceClass;
		private System.Windows.Forms.Button btnClassificazione;
		private System.Windows.Forms.TextBox txtNumero;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label1;
		public vistaForm DS;
		MetaData Meta;
		public bool eseguito=false;
		public string param;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_sortingprevexpensevar_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sortingprevexpensevar_default));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.grpClassificazione = new System.Windows.Forms.GroupBox();
            this.txtDescrClass = new System.Windows.Forms.TextBox();
            this.txtCodiceClass = new System.Windows.Forms.TextBox();
            this.btnClassificazione = new System.Windows.Forms.Button();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DS = new sortingprevexpensevar_default.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.grpClassificazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbDiminuzione);
            this.groupBox2.Controls.Add(this.rdbAumento);
            this.groupBox2.Controls.Add(this.txtImporto);
            this.groupBox2.Location = new System.Drawing.Point(8, 88);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 64);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "sortingprevexpensevar.amount.valuesigned";
            this.groupBox2.Text = "Importo";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Location = new System.Drawing.Point(232, 38);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(96, 16);
            this.rdbDiminuzione.TabIndex = 3;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbAumento
            // 
            this.rdbAumento.Checked = true;
            this.rdbAumento.Location = new System.Drawing.Point(232, 14);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(96, 16);
            this.rdbAumento.TabIndex = 2;
            this.rdbAumento.TabStop = true;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(16, 25);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(128, 20);
            this.txtImporto.TabIndex = 1;
            this.txtImporto.Tag = "sortingprevexpensevar.amount?sortingprevexpensevarview.amount";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 24);
            this.label5.TabIndex = 39;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(104, 160);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(96, 20);
            this.txtDataContabile.TabIndex = 4;
            this.txtDataContabile.Tag = "sortingprevexpensevar.adate?sortingprevexpensevar.adate";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 24);
            this.label3.TabIndex = 37;
            this.label3.Text = "Descrizione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(104, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(240, 53);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "sortingprevexpensevar.description?sortingprevexpensevarview.description";
            // 
            // grpClassificazione
            // 
            this.grpClassificazione.Controls.Add(this.txtDescrClass);
            this.grpClassificazione.Controls.Add(this.txtCodiceClass);
            this.grpClassificazione.Controls.Add(this.btnClassificazione);
            this.grpClassificazione.Location = new System.Drawing.Point(8, 56);
            this.grpClassificazione.Name = "grpClassificazione";
            this.grpClassificazione.Size = new System.Drawing.Size(352, 96);
            this.grpClassificazione.TabIndex = 2;
            this.grpClassificazione.TabStop = false;
            this.grpClassificazione.Tag = "AutoManage.txtCodiceClass.tree";
            this.grpClassificazione.Text = "Classificazione";
            // 
            // txtDescrClass
            // 
            this.txtDescrClass.Location = new System.Drawing.Point(136, 24);
            this.txtDescrClass.Multiline = true;
            this.txtDescrClass.Name = "txtDescrClass";
            this.txtDescrClass.ReadOnly = true;
            this.txtDescrClass.Size = new System.Drawing.Size(208, 56);
            this.txtDescrClass.TabIndex = 5;
            this.txtDescrClass.TabStop = false;
            this.txtDescrClass.Tag = "sortingview.description";
            // 
            // txtCodiceClass
            // 
            this.txtCodiceClass.Location = new System.Drawing.Point(16, 56);
            this.txtCodiceClass.Name = "txtCodiceClass";
            this.txtCodiceClass.Size = new System.Drawing.Size(100, 20);
            this.txtCodiceClass.TabIndex = 4;
            this.txtCodiceClass.Tag = "sortingview.sortcode?sortingprevexpensevarview.sortcode";
            // 
            // btnClassificazione
            // 
            this.btnClassificazione.Image = ((System.Drawing.Image)(resources.GetObject("btnClassificazione.Image")));
            this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassificazione.Location = new System.Drawing.Point(16, 24);
            this.btnClassificazione.Name = "btnClassificazione";
            this.btnClassificazione.Size = new System.Drawing.Size(104, 23);
            this.btnClassificazione.TabIndex = 0;
            this.btnClassificazione.TabStop = false;
            this.btnClassificazione.Tag = "manage.sortingview.tree";
            this.btnClassificazione.Text = "Classificazione:";
            this.btnClassificazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(256, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(88, 20);
            this.txtNumero.TabIndex = 1;
            this.txtNumero.Tag = "sortingprevexpensevar.nvar?sortingprevexpensevarview.nvar";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(176, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 33;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(72, 24);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 32;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "sortingprevexpensevar.yvar?sortingprevexpensevarview.yvar";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtEsercizio);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Variazione budget dei costi";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtDescrizione);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.txtDataContabile);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(8, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(352, 192);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dati Contabili";
            // 
            // Frm_sortingprevexpensevar_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(370, 360);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpClassificazione);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_sortingprevexpensevar_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmvarclassmovimentispese";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpClassificazione.ResumeLayout(false);
            this.grpClassificazione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.SetStaticFilter(DS.sortingview, filteresercizio);

			if (Meta.edit_type == "default")
			{
				param = Meta.ExtraParameter.ToString();
                string filter = QHS.CmpEq("idsorkind", param);
				DataTable DescrClass=Meta.Conn.RUN_SELECT("sortingkind","description",null,
					filter, null, null, true);
				if (DescrClass.Rows.Count==0)
					Meta.Name = "Spese \""+param+"\"";
				else
					Meta.Name = "Spese \""+
						DescrClass.Rows[0]["description"].ToString()+"\"";
				
    			GetData.SetStaticFilter(DS.sortingprevexpensevarview, filter);
                grpClassificazione.Tag+="."+filter;
				btnClassificazione.Tag+="."+filter;
                if (DescrClass.Rows.Count != 0) {
                    grpClassificazione.Text = DescrClass.Rows[0]["description"].ToString();
                }
			}
			if (Meta.edit_type == "relation")
				Meta.Name = "Variazione spese \"\"";
		}


		public void MetaData_AfterFill()
		{
			DefinizioneTag();
		}


		public void DefinizioneTag()
		{
			if (eseguito)
				return;
			if (Meta.edit_type == "relation")
			{
                param = DS.sortingview.Rows[0]["idsorkind"].ToString();
				string filter = QHS.CmpEq("idsorkind", param);
                //GetData.SetStaticFilter(DS.sortingprevexpensevar, filter);
				GetData.SetStaticFilter(DS.sortingprevexpensevarview, filter);
				grpClassificazione.Tag+="."+filter;
				btnClassificazione.Tag+="."+filter;
				Meta.SetAutoMode(grpClassificazione);
			}
			eseguito=true;
		}


		

		public void MetaData_AfterClear()
		{
			txtEsercizio.Text=Meta.Conn.GetEsercizio().ToString();
		}

	}
}
