
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
using System.Data;
using System.Collections;
using System.ComponentModel;
using metadatalibrary;
using System.Windows.Forms;

namespace inventorysortingamortizationyear_search//tipoclassrivalutazioneesercizio//
{
	/// <summary>
	/// Summary description for frmtipoclassrivalutazioneesercizio.
	/// </summary>
	public class Frm_inventorysortingamortizationyear_search : MetaDataForm
	{
		public vistaForm DS;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
        private GroupBox grbAccmotive;
        private TextBox txtCausale;
        private TextBox txtCodiceCausale;
        private Button btnAccmotive;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBox2;
        private TextBox txtCodiceCausaleScarico;
        private Button button4;
        private MetaData Meta;
        private DataAccess Conn;
        private GroupBox grpInventario;
        private TextBox txtDescClassif;
        private TextBox txtCodClassif;
        private Button btnClassif;
        private TextBox txtEserc;
        private Label labEsercizio;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_inventorysortingamortizationyear_search()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            DataAccess.SetTableForReading(DS.accmotiveapplied_load, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_unload,"accmotiveapplied");
        

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
            this.DS = new inventorysortingamortizationyear_search.vistaForm();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grbAccmotive = new System.Windows.Forms.GroupBox();
            this.txtCausale = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.btnAccmotive = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausaleScarico = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.grpInventario = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtCodClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.txtEserc = new System.Windows.Forms.TextBox();
            this.labEsercizio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grbAccmotive.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpInventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 0;
            this.button1.Tag = "choose.inventoryamortization.default";
            this.button1.Text = "Tipo Ammortamento";
            // 
            // comboBox1
            // 
            this.comboBox1.DataSource = this.DS.inventoryamortization;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(9, 37);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(311, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Tag = "inventorysortingamortizationyear.idinventoryamortization";
            this.comboBox1.ValueMember = "idinventoryamortization";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(323, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quota";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(326, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(88, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "inventorysortingamortizationyear.amortizationquota.fixed.6..%.100";
            // 
            // grbAccmotive
            // 
            this.grbAccmotive.Controls.Add(this.txtCausale);
            this.grbAccmotive.Controls.Add(this.txtCodiceCausale);
            this.grbAccmotive.Controls.Add(this.btnAccmotive);
            this.grbAccmotive.Location = new System.Drawing.Point(12, 216);
            this.grbAccmotive.Name = "grbAccmotive";
            this.grbAccmotive.Size = new System.Drawing.Size(256, 79);
            this.grbAccmotive.TabIndex = 4;
            this.grbAccmotive.TabStop = false;
            this.grbAccmotive.Tag = "AutoManage.txtCodiceCausale.tree.(in_use=\'S\')";
            this.grbAccmotive.Text = "Applicazione Ammortamento o Svalutazione";
            // 
            // txtCausale
            // 
            this.txtCausale.Location = new System.Drawing.Point(120, 18);
            this.txtCausale.Multiline = true;
            this.txtCausale.Name = "txtCausale";
            this.txtCausale.ReadOnly = true;
            this.txtCausale.Size = new System.Drawing.Size(128, 56);
            this.txtCausale.TabIndex = 2;
            this.txtCausale.Tag = "accmotiveapplied_load.motive?x";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(8, 50);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotiveapplied_load.codemotive?x";
            // 
            // btnAccmotive
            // 
            this.btnAccmotive.Location = new System.Drawing.Point(8, 18);
            this.btnAccmotive.Name = "btnAccmotive";
            this.btnAccmotive.Size = new System.Drawing.Size(104, 24);
            this.btnAccmotive.TabIndex = 0;
            this.btnAccmotive.Tag = "manage.accmotiveapplied_load.tree";
            this.btnAccmotive.Text = "Causale";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Location = new System.Drawing.Point(105, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 65);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.txtCodiceCausaleScarico);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(274, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(256, 79);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoManage.txtCodiceCausaleScarico.tree.(in_use=\'S\')";
            this.groupBox2.Text = "Scarico Cespite";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 18);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(128, 56);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "accmotiveapplied_unload.motive?x";
            // 
            // txtCodiceCausaleScarico
            // 
            this.txtCodiceCausaleScarico.Location = new System.Drawing.Point(8, 50);
            this.txtCodiceCausaleScarico.Name = "txtCodiceCausaleScarico";
            this.txtCodiceCausaleScarico.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausaleScarico.TabIndex = 1;
            this.txtCodiceCausaleScarico.Tag = "accmotiveapplied_unload.codemotive?x";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 24);
            this.button4.TabIndex = 0;
            this.button4.Tag = "manage.accmotiveapplied_unload.tree";
            this.button4.Text = "Causale";
            // 
            // grpInventario
            // 
            this.grpInventario.Controls.Add(this.txtDescClassif);
            this.grpInventario.Controls.Add(this.txtCodClassif);
            this.grpInventario.Controls.Add(this.btnClassif);
            this.grpInventario.Location = new System.Drawing.Point(12, 76);
            this.grpInventario.Name = "grpInventario";
            this.grpInventario.Size = new System.Drawing.Size(354, 132);
            this.grpInventario.TabIndex = 3;
            this.grpInventario.TabStop = false;
            this.grpInventario.Tag = "AutoManage.txtCodClassif.tree";
            this.grpInventario.Text = "Class. Inventariale";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(114, 16);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(232, 73);
            this.txtDescClassif.TabIndex = 1;
            this.txtDescClassif.Tag = "inventorytreeview.description";
            // 
            // txtCodClassif
            // 
            this.txtCodClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodClassif.Location = new System.Drawing.Point(6, 106);
            this.txtCodClassif.Name = "txtCodClassif";
            this.txtCodClassif.Size = new System.Drawing.Size(340, 20);
            this.txtCodClassif.TabIndex = 9;
            this.txtCodClassif.Tag = "inventorytreeview.codeinv?x";
            // 
            // btnClassif
            // 
            this.btnClassif.Location = new System.Drawing.Point(6, 77);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(88, 23);
            this.btnClassif.TabIndex = 0;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview.tree";
            this.btnClassif.Text = "Classificazione";
            // 
            // txtEserc
            // 
            this.txtEserc.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtEserc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEserc.Location = new System.Drawing.Point(12, 42);
            this.txtEserc.Name = "txtEserc";
            this.txtEserc.Size = new System.Drawing.Size(80, 20);
            this.txtEserc.TabIndex = 1;
            this.txtEserc.Tag = "inventorysortingamortizationyear.ayear.year";
            // 
            // labEsercizio
            // 
            this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labEsercizio.Location = new System.Drawing.Point(16, 23);
            this.labEsercizio.Name = "labEsercizio";
            this.labEsercizio.Size = new System.Drawing.Size(55, 16);
            this.labEsercizio.TabIndex = 0;
            this.labEsercizio.Text = "Esercizio";
            this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Frm_inventorysortingamortizationyear_search
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(540, 322);
            this.Controls.Add(this.txtEserc);
            this.Controls.Add(this.labEsercizio);
            this.Controls.Add(this.grpInventario);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbAccmotive);
            this.Name = "Frm_inventorysortingamortizationyear_search";
            this.Text = "frmtipoclassrivalutazioneesercizio";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grbAccmotive.ResumeLayout(false);
            this.grbAccmotive.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpInventario.ResumeLayout(false);
            this.grpInventario.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
        QueryHelper QHS;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            
            string filterEpOperationCarSF = QHS.CmpEq("idepoperation", "ammorta");
            string filterEpOperationScarSF = QHS.CmpEq("idepoperation", "scar_ammorta");
            string filterEpOperationCarEP = QHS.CmpEq("idepoperation", "ammorta");
            string filterEpOperationScarEP = QHS.CmpEq("idepoperation", "scar_ammorta");
            DS.accmotiveapplied_load.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCarEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_load, filterEpOperationCarSF);
            GetData.SetStaticFilter(DS.inventorysortingamortizationyear, QHS.CmpEq("ayear",Meta.GetSys("esercizio")));
            DS.accmotiveapplied_unload.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationScarEP;
            GetData.SetStaticFilter(DS.accmotiveapplied_unload, filterEpOperationScarSF);
        }
        public void MetaData_AfterClear()
        {
            txtEserc.Text = Meta.GetSys("esercizio").ToString();
            txtEserc.ReadOnly = false;
        }
        public void MetaData_AfterFill()
        {
            txtEserc.ReadOnly = true;
        }
	}
}
