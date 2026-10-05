/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using System.Linq;

namespace costpartitiondetail_default {
	/// <summary>
	/// Summary description for Frm_costpartitiondetail_default.
	/// </summary>
	public class Frm_costpartitiondetail_default : MetaDataForm {
		MetaData Meta;
		private DataAccess Conn;

        public costpartitiondetail_default.vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        QueryHelper QHS;
        private GroupBox grpImporto;
        private TextBox txtAmount;
        private Label label4;
        private Label label2;
        private GroupBox grpPercentuale;
        private TextBox txtRate;
        private Label label1;
        private CheckBox checkBox1;
        private GroupBox gboxTipo;
        private RadioButton rdbPercentuali;
        private RadioButton rdbCosti;
        private GroupBox groupBox3;
        private TextBox txtCodice;
        private Label label5;
        private TextBox txtDenominazione;
        private Label label3;
        private TextBox textBox1;
        private Label label6;
		private TabControl tabControlCoordinateAnalitiche;
		private TabPage tabPage1;
		public GroupBox gboxclass3;
		public Button btnCodice3;
		private TextBox txtDenom3;
		public TextBox txtCodice3;
		public GroupBox gboxclass2;
		public Button btnCodice2;
		private TextBox txtDenom2;
		public TextBox txtCodice2;
		public GroupBox gboxclass1;
		public Button btnCodice1;
		private TextBox txtDenom1;
		public TextBox txtCodice1;
		private TabPage tabPage2;
		public TextBox txtSortcode3_old;
		public TextBox txtSortcode2_old;
		public TextBox txtSortcode1_old;
		private GroupBox groupBoxSor3_old;
		private GroupBox groupBoxSor2_old;
		private GroupBox groupBoxSor1_old;
		CQueryHelper QHC;

		private struct Descriptor {
			public object EnvValue;
			public GroupBox Box;
			public DataColumn IDColumn;
			public DataColumn NameColumn;
		};

		private Descriptor[] GroupBoxDescriptors;

		public Frm_costpartitiondetail_default() {
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			
			if( disposing ) {
				if(components != null) {
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void MetaData_AfterActivation() {
			
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.grpImporto = new System.Windows.Forms.GroupBox();
			this.txtAmount = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.grpPercentuale = new System.Windows.Forms.GroupBox();
			this.txtRate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.gboxTipo = new System.Windows.Forms.GroupBox();
			this.rdbPercentuali = new System.Windows.Forms.RadioButton();
			this.rdbCosti = new System.Windows.Forms.RadioButton();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtCodice = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtDenominazione = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.DS = new costpartitiondetail_default.vistaForm();
			this.tabControlCoordinateAnalitiche = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.gboxclass3 = new System.Windows.Forms.GroupBox();
			this.btnCodice3 = new System.Windows.Forms.Button();
			this.txtDenom3 = new System.Windows.Forms.TextBox();
			this.txtCodice3 = new System.Windows.Forms.TextBox();
			this.gboxclass2 = new System.Windows.Forms.GroupBox();
			this.btnCodice2 = new System.Windows.Forms.Button();
			this.txtDenom2 = new System.Windows.Forms.TextBox();
			this.txtCodice2 = new System.Windows.Forms.TextBox();
			this.gboxclass1 = new System.Windows.Forms.GroupBox();
			this.btnCodice1 = new System.Windows.Forms.Button();
			this.txtDenom1 = new System.Windows.Forms.TextBox();
			this.txtCodice1 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.groupBoxSor3_old = new System.Windows.Forms.GroupBox();
			this.txtSortcode3_old = new System.Windows.Forms.TextBox();
			this.groupBoxSor2_old = new System.Windows.Forms.GroupBox();
			this.txtSortcode2_old = new System.Windows.Forms.TextBox();
			this.groupBoxSor1_old = new System.Windows.Forms.GroupBox();
			this.txtSortcode1_old = new System.Windows.Forms.TextBox();
			this.grpImporto.SuspendLayout();
			this.grpPercentuale.SuspendLayout();
			this.gboxTipo.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.tabControlCoordinateAnalitiche.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.gboxclass3.SuspendLayout();
			this.gboxclass2.SuspendLayout();
			this.gboxclass1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBoxSor3_old.SuspendLayout();
			this.groupBoxSor2_old.SuspendLayout();
			this.groupBoxSor1_old.SuspendLayout();
			this.SuspendLayout();
			// 
			// grpImporto
			// 
			this.grpImporto.Controls.Add(this.txtAmount);
			this.grpImporto.Controls.Add(this.label4);
			this.grpImporto.Controls.Add(this.label2);
			this.grpImporto.Location = new System.Drawing.Point(12, 160);
			this.grpImporto.Name = "grpImporto";
			this.grpImporto.Size = new System.Drawing.Size(182, 72);
			this.grpImporto.TabIndex = 58;
			this.grpImporto.TabStop = false;
			this.grpImporto.Text = " ";
			// 
			// txtAmount
			// 
			this.txtAmount.Location = new System.Drawing.Point(17, 32);
			this.txtAmount.Name = "txtAmount";
			this.txtAmount.Size = new System.Drawing.Size(130, 20);
			this.txtAmount.TabIndex = 55;
			this.txtAmount.Tag = "costpartitiondetail.amount";
			this.txtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(14, 16);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(42, 13);
			this.label4.TabIndex = 54;
			this.label4.Text = "Importo";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(34, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(10, 13);
			this.label2.TabIndex = 53;
			this.label2.Text = " ";
			// 
			// grpPercentuale
			// 
			this.grpPercentuale.Controls.Add(this.txtRate);
			this.grpPercentuale.Controls.Add(this.label1);
			this.grpPercentuale.Location = new System.Drawing.Point(12, 237);
			this.grpPercentuale.Name = "grpPercentuale";
			this.grpPercentuale.Size = new System.Drawing.Size(182, 85);
			this.grpPercentuale.TabIndex = 59;
			this.grpPercentuale.TabStop = false;
			this.grpPercentuale.Text = " ";
			// 
			// txtRate
			// 
			this.txtRate.Location = new System.Drawing.Point(17, 39);
			this.txtRate.Name = "txtRate";
			this.txtRate.Size = new System.Drawing.Size(130, 20);
			this.txtRate.TabIndex = 56;
			this.txtRate.Tag = "costpartitiondetail.rate.fixed.6..%.100";
			this.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(14, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 55;
			this.label1.Text = "Percentuale";
			// 
			// checkBox1
			// 
			this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.checkBox1.AutoSize = true;
			this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBox1.Location = new System.Drawing.Point(278, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(53, 17);
			this.checkBox1.TabIndex = 351;
			this.checkBox1.TabStop = false;
			this.checkBox1.Tag = "costpartition.active:S:N?costpartitiondetailview.active:S:N";
			this.checkBox1.Text = "Attiva";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// gboxTipo
			// 
			this.gboxTipo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxTipo.Controls.Add(this.rdbPercentuali);
			this.gboxTipo.Controls.Add(this.rdbCosti);
			this.gboxTipo.Location = new System.Drawing.Point(382, 12);
			this.gboxTipo.Name = "gboxTipo";
			this.gboxTipo.Size = new System.Drawing.Size(191, 45);
			this.gboxTipo.TabIndex = 348;
			this.gboxTipo.TabStop = false;
			this.gboxTipo.Text = "Tipo Ripartizione";
			// 
			// rdbPercentuali
			// 
			this.rdbPercentuali.AutoSize = true;
			this.rdbPercentuali.Location = new System.Drawing.Point(96, 18);
			this.rdbPercentuali.Name = "rdbPercentuali";
			this.rdbPercentuali.Size = new System.Drawing.Size(78, 17);
			this.rdbPercentuali.TabIndex = 4;
			this.rdbPercentuali.Tag = "costpartition.kind:P?costpartitiondetailview.kind:Percentuali";
			this.rdbPercentuali.Text = "Percentuali";
			this.rdbPercentuali.UseVisualStyleBackColor = true;
			// 
			// rdbCosti
			// 
			this.rdbCosti.Location = new System.Drawing.Point(6, 16);
			this.rdbCosti.Name = "rdbCosti";
			this.rdbCosti.Size = new System.Drawing.Size(71, 23);
			this.rdbCosti.TabIndex = 0;
			this.rdbCosti.Tag = "costpartition.kind:C?costpartitiondetailview.kind:Importi";
			this.rdbCosti.Text = "Importi";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtCodice);
			this.groupBox3.Controls.Add(this.label5);
			this.groupBox3.Controls.Add(this.checkBox1);
			this.groupBox3.Location = new System.Drawing.Point(12, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(348, 45);
			this.groupBox3.TabIndex = 347;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Ripartizione";
			// 
			// txtCodice
			// 
			this.txtCodice.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.txtCodice.Location = new System.Drawing.Point(61, 17);
			this.txtCodice.Name = "txtCodice";
			this.txtCodice.Size = new System.Drawing.Size(211, 20);
			this.txtCodice.TabIndex = 36;
			this.txtCodice.Tag = "costpartition.costpartitioncode?costpartitiondetailview.costpartitioncode";
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.Location = new System.Drawing.Point(10, 17);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(45, 16);
			this.label5.TabIndex = 37;
			this.label5.Text = "Codice:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtDenominazione
			// 
			this.txtDenominazione.Location = new System.Drawing.Point(12, 81);
			this.txtDenominazione.Multiline = true;
			this.txtDenominazione.Name = "txtDenominazione";
			this.txtDenominazione.Size = new System.Drawing.Size(348, 64);
			this.txtDenominazione.TabIndex = 349;
			this.txtDenominazione.Tag = "costpartition.title?costpartitiondetailview.title";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(88, 16);
			this.label3.TabIndex = 350;
			this.label3.Text = "Denominazione:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.Location = new System.Drawing.Point(491, 79);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(79, 20);
			this.textBox1.TabIndex = 352;
			this.textBox1.Tag = "costpartitiondetail.iddetail";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(447, 84);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(39, 13);
			this.label6.TabIndex = 353;
			this.label6.Text = "# Riga";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// tabControlCoordinateAnalitiche
			// 
			this.tabControlCoordinateAnalitiche.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControlCoordinateAnalitiche.Controls.Add(this.tabPage1);
			this.tabControlCoordinateAnalitiche.Controls.Add(this.tabPage2);
			this.tabControlCoordinateAnalitiche.Location = new System.Drawing.Point(200, 160);
			this.tabControlCoordinateAnalitiche.Name = "tabControlCoordinateAnalitiche";
			this.tabControlCoordinateAnalitiche.SelectedIndex = 0;
			this.tabControlCoordinateAnalitiche.Size = new System.Drawing.Size(383, 418);
			this.tabControlCoordinateAnalitiche.TabIndex = 360;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.gboxclass3);
			this.tabPage1.Controls.Add(this.gboxclass2);
			this.tabPage1.Controls.Add(this.gboxclass1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(375, 392);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Attuali";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// gboxclass3
			// 
			this.gboxclass3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass3.Controls.Add(this.btnCodice3);
			this.gboxclass3.Controls.Add(this.txtDenom3);
			this.gboxclass3.Controls.Add(this.txtCodice3);
			this.gboxclass3.Location = new System.Drawing.Point(11, 261);
			this.gboxclass3.Name = "gboxclass3";
			this.gboxclass3.Size = new System.Drawing.Size(350, 109);
			this.gboxclass3.TabIndex = 58;
			this.gboxclass3.TabStop = false;
			this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
			this.gboxclass3.Text = "Classificazione 3";
			// 
			// btnCodice3
			// 
			this.btnCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodice3.Location = new System.Drawing.Point(6, 57);
			this.btnCodice3.Name = "btnCodice3";
			this.btnCodice3.Size = new System.Drawing.Size(88, 23);
			this.btnCodice3.TabIndex = 4;
			this.btnCodice3.TabStop = false;
			this.btnCodice3.Tag = "manage.sorting3.tree";
			this.btnCodice3.Text = "Codice";
			this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom3
			// 
			this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom3.Location = new System.Drawing.Point(128, 24);
			this.txtDenom3.Multiline = true;
			this.txtDenom3.Name = "txtDenom3";
			this.txtDenom3.ReadOnly = true;
			this.txtDenom3.Size = new System.Drawing.Size(216, 57);
			this.txtDenom3.TabIndex = 3;
			this.txtDenom3.TabStop = false;
			this.txtDenom3.Tag = "sorting3.description";
			// 
			// txtCodice3
			// 
			this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice3.Location = new System.Drawing.Point(6, 83);
			this.txtCodice3.Name = "txtCodice3";
			this.txtCodice3.Size = new System.Drawing.Size(338, 20);
			this.txtCodice3.TabIndex = 2;
			this.txtCodice3.Tag = "sorting3.sortcode?costpartitiondetailview.sortcode3";
			// 
			// gboxclass2
			// 
			this.gboxclass2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass2.Controls.Add(this.btnCodice2);
			this.gboxclass2.Controls.Add(this.txtDenom2);
			this.gboxclass2.Controls.Add(this.txtCodice2);
			this.gboxclass2.Location = new System.Drawing.Point(10, 129);
			this.gboxclass2.Name = "gboxclass2";
			this.gboxclass2.Size = new System.Drawing.Size(350, 121);
			this.gboxclass2.TabIndex = 57;
			this.gboxclass2.TabStop = false;
			this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
			this.gboxclass2.Text = "Classificazione 2";
			// 
			// btnCodice2
			// 
			this.btnCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodice2.Location = new System.Drawing.Point(6, 69);
			this.btnCodice2.Name = "btnCodice2";
			this.btnCodice2.Size = new System.Drawing.Size(88, 23);
			this.btnCodice2.TabIndex = 4;
			this.btnCodice2.TabStop = false;
			this.btnCodice2.Tag = "manage.sorting2.tree";
			this.btnCodice2.Text = "Codice";
			this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom2
			// 
			this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom2.Location = new System.Drawing.Point(128, 24);
			this.txtDenom2.Multiline = true;
			this.txtDenom2.Name = "txtDenom2";
			this.txtDenom2.ReadOnly = true;
			this.txtDenom2.Size = new System.Drawing.Size(214, 68);
			this.txtDenom2.TabIndex = 3;
			this.txtDenom2.TabStop = false;
			this.txtDenom2.Tag = "sorting2.description";
			// 
			// txtCodice2
			// 
			this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice2.Location = new System.Drawing.Point(6, 95);
			this.txtCodice2.Name = "txtCodice2";
			this.txtCodice2.Size = new System.Drawing.Size(336, 20);
			this.txtCodice2.TabIndex = 2;
			this.txtCodice2.Tag = "sorting2.sortcode?costpartitiondetailview.sortcode2";
			// 
			// gboxclass1
			// 
			this.gboxclass1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gboxclass1.Controls.Add(this.btnCodice1);
			this.gboxclass1.Controls.Add(this.txtDenom1);
			this.gboxclass1.Controls.Add(this.txtCodice1);
			this.gboxclass1.Location = new System.Drawing.Point(10, 12);
			this.gboxclass1.Name = "gboxclass1";
			this.gboxclass1.Size = new System.Drawing.Size(350, 111);
			this.gboxclass1.TabIndex = 56;
			this.gboxclass1.TabStop = false;
			this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
			this.gboxclass1.Text = "Classificazione 1";
			// 
			// btnCodice1
			// 
			this.btnCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCodice1.Location = new System.Drawing.Point(6, 59);
			this.btnCodice1.Name = "btnCodice1";
			this.btnCodice1.Size = new System.Drawing.Size(88, 23);
			this.btnCodice1.TabIndex = 4;
			this.btnCodice1.TabStop = false;
			this.btnCodice1.Tag = "manage.sorting1.tree";
			this.btnCodice1.Text = "Codice";
			this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// txtDenom1
			// 
			this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDenom1.Location = new System.Drawing.Point(128, 24);
			this.txtDenom1.Multiline = true;
			this.txtDenom1.Name = "txtDenom1";
			this.txtDenom1.ReadOnly = true;
			this.txtDenom1.Size = new System.Drawing.Size(214, 58);
			this.txtDenom1.TabIndex = 3;
			this.txtDenom1.TabStop = false;
			this.txtDenom1.Tag = "sorting1.description";
			// 
			// txtCodice1
			// 
			this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtCodice1.Location = new System.Drawing.Point(6, 85);
			this.txtCodice1.Name = "txtCodice1";
			this.txtCodice1.Size = new System.Drawing.Size(336, 20);
			this.txtCodice1.TabIndex = 2;
			this.txtCodice1.Tag = "sorting1.sortcode?costpartitiondetailview.sortcode1";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.groupBoxSor3_old);
			this.tabPage2.Controls.Add(this.groupBoxSor2_old);
			this.tabPage2.Controls.Add(this.groupBoxSor1_old);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(491, 392);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Informazioni storiche";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// groupBoxSor3_old
			// 
			this.groupBoxSor3_old.Controls.Add(this.txtSortcode3_old);
			this.groupBoxSor3_old.Location = new System.Drawing.Point(6, 155);
			this.groupBoxSor3_old.Name = "groupBoxSor3_old";
			this.groupBoxSor3_old.Size = new System.Drawing.Size(320, 65);
			this.groupBoxSor3_old.TabIndex = 368;
			this.groupBoxSor3_old.TabStop = false;
			// 
			// txtSortcode3_old
			// 
			this.txtSortcode3_old.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSortcode3_old.Location = new System.Drawing.Point(6, 36);
			this.txtSortcode3_old.Name = "txtSortcode3_old";
			this.txtSortcode3_old.Size = new System.Drawing.Size(140, 20);
			this.txtSortcode3_old.TabIndex = 362;
			this.txtSortcode3_old.Tag = "costpartitiondetailview.sortcode3?costpartitiondetailview.sortcode3";
			// 
			// groupBoxSor2_old
			// 
			this.groupBoxSor2_old.Controls.Add(this.txtSortcode2_old);
			this.groupBoxSor2_old.Location = new System.Drawing.Point(6, 84);
			this.groupBoxSor2_old.Name = "groupBoxSor2_old";
			this.groupBoxSor2_old.Size = new System.Drawing.Size(320, 65);
			this.groupBoxSor2_old.TabIndex = 367;
			this.groupBoxSor2_old.TabStop = false;
			// 
			// txtSortcode2_old
			// 
			this.txtSortcode2_old.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSortcode2_old.Location = new System.Drawing.Point(6, 39);
			this.txtSortcode2_old.Name = "txtSortcode2_old";
			this.txtSortcode2_old.Size = new System.Drawing.Size(140, 20);
			this.txtSortcode2_old.TabIndex = 361;
			this.txtSortcode2_old.Tag = "costpartitiondetailview.sortcode2?costpartitiondetailview.sortcode2";
			// 
			// groupBoxSor1_old
			// 
			this.groupBoxSor1_old.Controls.Add(this.txtSortcode1_old);
			this.groupBoxSor1_old.Location = new System.Drawing.Point(6, 10);
			this.groupBoxSor1_old.Name = "groupBoxSor1_old";
			this.groupBoxSor1_old.Size = new System.Drawing.Size(320, 68);
			this.groupBoxSor1_old.TabIndex = 366;
			this.groupBoxSor1_old.TabStop = false;
			// 
			// txtSortcode1_old
			// 
			this.txtSortcode1_old.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSortcode1_old.Location = new System.Drawing.Point(6, 41);
			this.txtSortcode1_old.Name = "txtSortcode1_old";
			this.txtSortcode1_old.Size = new System.Drawing.Size(140, 20);
			this.txtSortcode1_old.TabIndex = 360;
			this.txtSortcode1_old.Tag = "costpartitiondetailview.sortcode1?costpartitiondetailview.sortcode1";
			// 
			// Frm_costpartitiondetail_default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(587, 584);
			this.Controls.Add(this.tabControlCoordinateAnalitiche);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.gboxTipo);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.txtDenominazione);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.grpPercentuale);
			this.Controls.Add(this.grpImporto);
			this.Name = "Frm_costpartitiondetail_default";
			this.Text = "Frm_costpartitiondetail_default";
			this.grpImporto.ResumeLayout(false);
			this.grpImporto.PerformLayout();
			this.grpPercentuale.ResumeLayout(false);
			this.grpPercentuale.PerformLayout();
			this.gboxTipo.ResumeLayout(false);
			this.gboxTipo.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.tabControlCoordinateAnalitiche.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.gboxclass3.ResumeLayout(false);
			this.gboxclass3.PerformLayout();
			this.gboxclass2.ResumeLayout(false);
			this.gboxclass2.PerformLayout();
			this.gboxclass1.ResumeLayout(false);
			this.gboxclass1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBoxSor3_old.ResumeLayout(false);
			this.groupBoxSor3_old.PerformLayout();
			this.groupBoxSor2_old.ResumeLayout(false);
			this.groupBoxSor2_old.PerformLayout();
			this.groupBoxSor1_old.ResumeLayout(false);
			this.groupBoxSor1_old.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		public void MetaData_AfterRowSelect(DataTable T, DataRow R) {

		}

        private void EnableDisableControls(bool enable) {

            bool readOnly = !enable;

            // funzione ricorsiva per abilitazione/disabilitazione
            void EnableDisableChildren(Control parent, bool enabled) {

                foreach (Control c in parent.Controls) {
                    c.Enabled = enabled;

                    if (c.HasChildren)
                        EnableDisableChildren(c, enabled);
                }
            }

            foreach (Control c in Controls) {

                // per i textbox va impostato readonly opposto ad enable
                if (c is TextBox tb) {

                    tb.ReadOnly = readOnly;
                    continue;
                }

                EnableDisableChildren(c, enable);
            }
        }

        public void MetaData_AfterClear() {

            GroupBoxDescriptors
                ._forEach((descriptor, pos) => {
                    descriptor.Box.Visible = true;
                    descriptor.Box.Text = $"Classificazione {pos + 1}";
                });

            bool enable = true;
            EnableDisableControls(enable); // abilitiamo
        }

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Conn = Meta.Conn;
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
			DataAccess.SetTableForReading(DS.sorting3, "sorting");

            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;

            GroupBoxDescriptors = new Descriptor[] {
				new Descriptor {
					EnvValue = Meta.GetSys("idsortingkind1"),
					Box = groupBoxSor1_old,
					IDColumn = DS.costpartitiondetailview.Columns["idsorkind1"],
					NameColumn = DS.costpartitiondetailview.Columns["sortingkind1"],
				},
				new Descriptor {
					EnvValue = Meta.GetSys("idsortingkind2"),
					Box = groupBoxSor2_old,
					IDColumn = DS.costpartitiondetailview.Columns["idsorkind2"],
					NameColumn = DS.costpartitiondetailview.Columns["sortingkind2"],
				},
				new Descriptor {
					EnvValue = Meta.GetSys("idsortingkind3"),
					Box = groupBoxSor3_old,
					IDColumn = DS.costpartitiondetailview.Columns["idsorkind3"],
					NameColumn = DS.costpartitiondetailview.Columns["sortingkind3"],
				},
			};

            DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null,
                filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0))
            {
                DataRow r = tExpSetup.Rows[0];
                object idsorkind1 = r["idsortingkind1"];
                object idsorkind2 = r["idsortingkind2"];
                object idsorkind3 = r["idsortingkind3"];
                SetGBoxClass(this, 1, idsorkind1);
                SetGBoxClass(this, 2, idsorkind2);
                SetGBoxClass(this, 3, idsorkind3);
			}	
		}

        static object GetCtrlByName(Form F, string Name) {
            System.Reflection.FieldInfo Ctrl = F.GetType().GetField(Name);
            if (Ctrl == null) return null;
            //if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;                         
            //Label L =  (Label) Ctrl.GetValue(this);                        
            //return L;
            return Ctrl.GetValue(F);
        }


        public static void SetGBoxClass(Form F, int num, object sortingkind) {
            var conn = F.getInstance<IDataAccess>();
            var meta = F.getInstance<IMetaData>();
            var ds = F.getInstance<DataSet>();
            var sec = F.getInstance<ISecurity>();
            var model = MetaFactory.factory.getSingleton<IMetaModel>();

            string nums = num.ToString();
            if (sortingkind == null || sortingkind == DBNull.Value || sortingkind.ToString() == "null") {
                var g = (GroupBox)GetCtrlByName(F, "gboxclass" + nums);
                g.Tag = null;
                g.Visible = false;
                var c = (TextBox)GetCtrlByName(F, "txtCodice" + nums);
                c.Tag = null;
            }
            else {
                QueryHelper qhs = conn.GetQueryHelper();
                var filter = qhs.CmpEq("idsorkind", CfgFn.GetNoNullInt32(sortingkind));
                model.setStaticFilter(ds.Tables["sorting" + nums], filter);
				model.cacheTable(ds.Tables["sorting" + nums]);
                //GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);
                var gboxclass = (GroupBox)GetCtrlByName(F, "gboxclass" + nums);
                var btnCodice = (Button)GetCtrlByName(F, "btnCodice" + nums);
                var txtCodice = (TextBox)GetCtrlByName(F, "txtCodice" + nums);
                //gboxclass.Tag = "AutoManage.txtCodice0" + nums + ".tree." + filter;
                var title = conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                //btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
				btnCodice.Tag = "manage.sorting" + nums + ".tree." + filter;
           
                model.setExtraParams(ds.Tables["sorting" + nums], filter);
                //ds.Tables["sorting" + nums].ExtendedProperties[MetaData.ExtraParams] = filter;
                gboxclass.Tag = "AutoChoose.txtCodice" + nums + ".treeusable";
                txtCodice.Tag = "sorting" + nums + ".sortcode?costpartitiondetailview.sortcode" + nums;

			}
        }

		public void MetaData_AfterFill() {

			if (Meta.IsEmpty) return;
            DataRow Curr = DS.costpartitiondetail.Rows[0];
            DataRow rcostpartitiondetail = Curr;
            DataRow rCostPartition = rcostpartitiondetail.GetParentRow("costpartition_costpartitiondetail");
			if (rCostPartition == null) return;

			object kind = rCostPartition["kind"];
            if (kind != DBNull.Value)
            {
                grpImporto.Visible = (kind.ToString() == "C");
                grpPercentuale.Visible = (kind.ToString() == "P");
            }

			// controlliamo sulla redirezione alla vista e visualizziamo o meno i controlli
			if (DS.costpartitiondetailview.Rows.Count > 0) {

				var viewData = DS.costpartitiondetailview.Rows[0];

				bool computeVisibility(Descriptor d) {

					object value = viewData[d.IDColumn];

					if (d.EnvValue == null || value == DBNull.Value)
						return false;

					return d.EnvValue?.ToString() != value?.ToString();
				}

				GroupBoxDescriptors
					._forEach(descriptor => {
						descriptor.Box.Visible = computeVisibility(descriptor);
						descriptor.Box.Text = viewData[descriptor.NameColumn].ToString();
					});
			}

            bool enable = false;
            EnableDisableControls(enable);  // disabilitiamo
		}
	}
}