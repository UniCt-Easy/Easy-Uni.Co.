
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


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Windows.Forms;
using ep_functions;
using metadatalibrary;
//using metaeasylibrary;

namespace assetgrant_default {
    public partial class Frm_assetgrant_default : MetaDataForm {
        public Frm_assetgrant_default() {
            InitializeComponent();
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetgrant_default));
            this.DS = new assetgrant_default.vistaForm();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gboxInventario = new System.Windows.Forms.GroupBox();
            this.grpClassif = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.grpCespite = new System.Windows.Forms.GroupBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSelezBene = new System.Windows.Forms.Button();
            this.cmbInventoryAgency = new System.Windows.Forms.ComboBox();
            this.txtNumInv = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gboxContributo = new System.Windows.Forms.GroupBox();
            this.txtDataDocumento = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtAnnoRisc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gboxFinanziamento = new System.Windows.Forms.GroupBox();
            this.txtFinanziamento = new System.Windows.Forms.TextBox();
            this.btnFinanziamento = new System.Windows.Forms.Button();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumIxBudget = new System.Windows.Forms.TextBox();
            this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
            this.gBoxCausale = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtCodiceCausale = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtValoreIniziale = new System.Windows.Forms.TextBox();
            this.txtValoreStorico = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gboxInventario.SuspendLayout();
            this.grpClassif.SuspendLayout();
            this.grpCespite.SuspendLayout();
            this.gboxContributo.SuspendLayout();
            this.gboxFinanziamento.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.grpBoxImpegniBudget.SuspendLayout();
            this.gBoxCausale.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 346);
            this.tabControl1.TabIndex = 55;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gboxInventario);
            this.tabPage1.Controls.Add(this.gboxContributo);
            this.tabPage1.Controls.Add(this.gboxFinanziamento);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 320);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gboxInventario
            // 
            this.gboxInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxInventario.Controls.Add(this.grpClassif);
            this.gboxInventario.Controls.Add(this.grpCespite);
            this.gboxInventario.Location = new System.Drawing.Point(466, 16);
            this.gboxInventario.Name = "gboxInventario";
            this.gboxInventario.Size = new System.Drawing.Size(392, 289);
            this.gboxInventario.TabIndex = 66;
            this.gboxInventario.TabStop = false;
            // 
            // grpClassif
            // 
            this.grpClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassif.Controls.Add(this.txtDescClassif);
            this.grpClassif.Controls.Add(this.txtIdClassif);
            this.grpClassif.Controls.Add(this.btnClassif);
            this.grpClassif.Location = new System.Drawing.Point(10, 199);
            this.grpClassif.Name = "grpClassif";
            this.grpClassif.Size = new System.Drawing.Size(372, 79);
            this.grpClassif.TabIndex = 48;
            this.grpClassif.TabStop = false;
            this.grpClassif.Tag = "AutoManage.txtIdClassif.tree";
            this.grpClassif.Text = "Classificazione inventariale";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(170, 11);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(192, 62);
            this.txtDescClassif.TabIndex = 19;
            this.txtDescClassif.TabStop = false;
            this.txtDescClassif.Tag = "inventorytreeview.description";
            // 
            // txtIdClassif
            // 
            this.txtIdClassif.Location = new System.Drawing.Point(8, 53);
            this.txtIdClassif.Name = "txtIdClassif";
            this.txtIdClassif.Size = new System.Drawing.Size(153, 20);
            this.txtIdClassif.TabIndex = 1;
            this.txtIdClassif.Tag = "inventorytreeview.codeinv?assetgrantview.codeinv";
            // 
            // btnClassif
            // 
            this.btnClassif.Image = ((System.Drawing.Image)(resources.GetObject("btnClassif.Image")));
            this.btnClassif.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassif.Location = new System.Drawing.Point(8, 17);
            this.btnClassif.Name = "btnClassif";
            this.btnClassif.Size = new System.Drawing.Size(120, 23);
            this.btnClassif.TabIndex = 17;
            this.btnClassif.TabStop = false;
            this.btnClassif.Tag = "manage.inventorytreeview.tree";
            this.btnClassif.Text = "Classificazione";
            // 
            // grpCespite
            // 
            this.grpCespite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCespite.Controls.Add(this.txtValoreStorico);
            this.grpCespite.Controls.Add(this.txtValoreIniziale);
            this.grpCespite.Controls.Add(this.label9);
            this.grpCespite.Controls.Add(this.label8);
            this.grpCespite.Controls.Add(this.label25);
            this.grpCespite.Controls.Add(this.textBox3);
            this.grpCespite.Controls.Add(this.cmbInventario);
            this.grpCespite.Controls.Add(this.label4);
            this.grpCespite.Controls.Add(this.btnSelezBene);
            this.grpCespite.Controls.Add(this.cmbInventoryAgency);
            this.grpCespite.Controls.Add(this.txtNumInv);
            this.grpCespite.Controls.Add(this.label3);
            this.grpCespite.Location = new System.Drawing.Point(6, 9);
            this.grpCespite.Name = "grpCespite";
            this.grpCespite.Size = new System.Drawing.Size(376, 175);
            this.grpCespite.TabIndex = 42;
            this.grpCespite.TabStop = false;
            this.grpCespite.Tag = "";
            this.grpCespite.Text = "Cespite";
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(246, 95);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 51;
            this.label25.Tag = "";
            this.label25.Text = "N.parte";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(308, 94);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(54, 20);
            this.textBox3.TabIndex = 50;
            this.textBox3.Tag = "assetgrant.idpiece";
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DataSource = this.DS.inventory;
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventario.Location = new System.Drawing.Point(118, 19);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(248, 21);
            this.cmbInventario.TabIndex = 49;
            this.cmbInventario.Tag = "assetview.idinventory?assetgrantview.idinventory";
            this.cmbInventario.ValueMember = "idinventory";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 48;
            this.label4.Text = "Inventario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSelezBene
            // 
            this.btnSelezBene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelezBene.Location = new System.Drawing.Point(12, 93);
            this.btnSelezBene.Name = "btnSelezBene";
            this.btnSelezBene.Size = new System.Drawing.Size(93, 21);
            this.btnSelezBene.TabIndex = 18;
            this.btnSelezBene.TabStop = false;
            this.btnSelezBene.Tag = "choose.assetview.default";
            this.btnSelezBene.Text = "N. Inventario";
            // 
            // cmbInventoryAgency
            // 
            this.cmbInventoryAgency.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventoryAgency.DataSource = this.DS.inventoryagency;
            this.cmbInventoryAgency.DisplayMember = "description";
            this.cmbInventoryAgency.Enabled = false;
            this.cmbInventoryAgency.Location = new System.Drawing.Point(9, 59);
            this.cmbInventoryAgency.Name = "cmbInventoryAgency";
            this.cmbInventoryAgency.Size = new System.Drawing.Size(350, 21);
            this.cmbInventoryAgency.TabIndex = 46;
            this.cmbInventoryAgency.Tag = "inventory.idinventoryagency";
            this.cmbInventoryAgency.ValueMember = "idinventoryagency";
            // 
            // txtNumInv
            // 
            this.txtNumInv.Location = new System.Drawing.Point(113, 94);
            this.txtNumInv.Name = "txtNumInv";
            this.txtNumInv.Size = new System.Drawing.Size(100, 20);
            this.txtNumInv.TabIndex = 19;
            this.txtNumInv.Tag = "assetview.ninventory?assetgrantview.ninventory";
            this.txtNumInv.TextChanged += new System.EventHandler(this.txtNumInv_TextChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 47;
            this.label3.Text = "Ente proprietario dei cespiti:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gboxContributo
            // 
            this.gboxContributo.Controls.Add(this.txtDataDocumento);
            this.gboxContributo.Controls.Add(this.label6);
            this.gboxContributo.Controls.Add(this.textBox2);
            this.gboxContributo.Controls.Add(this.label1);
            this.gboxContributo.Controls.Add(this.txtDescrizione);
            this.gboxContributo.Controls.Add(this.label5);
            this.gboxContributo.Controls.Add(this.txtImporto);
            this.gboxContributo.Controls.Add(this.txtAnnoRisc);
            this.gboxContributo.Controls.Add(this.label2);
            this.gboxContributo.Controls.Add(this.label7);
            this.gboxContributo.Location = new System.Drawing.Point(10, 67);
            this.gboxContributo.Name = "gboxContributo";
            this.gboxContributo.Size = new System.Drawing.Size(446, 238);
            this.gboxContributo.TabIndex = 65;
            this.gboxContributo.TabStop = false;
            this.gboxContributo.Text = "Contributo";
            // 
            // txtDataDocumento
            // 
            this.txtDataDocumento.Location = new System.Drawing.Point(137, 168);
            this.txtDataDocumento.Name = "txtDataDocumento";
            this.txtDataDocumento.Size = new System.Drawing.Size(80, 20);
            this.txtDataDocumento.TabIndex = 69;
            this.txtDataDocumento.Tag = "assetgrant.docdate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(24, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 74;
            this.label6.Text = "Data Documento";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(137, 139);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(293, 20);
            this.textBox2.TabIndex = 68;
            this.textBox2.Tag = "assetgrant.doc";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(45, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 21);
            this.label1.TabIndex = 73;
            this.label1.Text = "Documento";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(137, 77);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescrizione.Size = new System.Drawing.Size(293, 56);
            this.txtDescrizione.TabIndex = 67;
            this.txtDescrizione.Tag = "assetgrant.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(45, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 21);
            this.label5.TabIndex = 72;
            this.label5.Text = "Descrizione";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(137, 51);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(112, 20);
            this.txtImporto.TabIndex = 66;
            this.txtImporto.Tag = "assetgrant.amount";
            // 
            // txtAnnoRisc
            // 
            this.txtAnnoRisc.Location = new System.Drawing.Point(137, 28);
            this.txtAnnoRisc.Name = "txtAnnoRisc";
            this.txtAnnoRisc.Size = new System.Drawing.Size(112, 20);
            this.txtAnnoRisc.TabIndex = 65;
            this.txtAnnoRisc.Tag = "assetgrant.ygrant.year";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(35, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 71;
            this.label2.Text = "Importo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(14, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 16);
            this.label7.TabIndex = 70;
            this.label7.Text = "Anno";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gboxFinanziamento
            // 
            this.gboxFinanziamento.Controls.Add(this.txtFinanziamento);
            this.gboxFinanziamento.Controls.Add(this.btnFinanziamento);
            this.gboxFinanziamento.Location = new System.Drawing.Point(10, 16);
            this.gboxFinanziamento.Name = "gboxFinanziamento";
            this.gboxFinanziamento.Size = new System.Drawing.Size(446, 45);
            this.gboxFinanziamento.TabIndex = 47;
            this.gboxFinanziamento.TabStop = false;
            this.gboxFinanziamento.Tag = "AutoChoose.txtFinanziamento.default.(active = \'S\')";
            // 
            // txtFinanziamento
            // 
            this.txtFinanziamento.Location = new System.Drawing.Point(118, 9);
            this.txtFinanziamento.Multiline = true;
            this.txtFinanziamento.Name = "txtFinanziamento";
            this.txtFinanziamento.Size = new System.Drawing.Size(312, 22);
            this.txtFinanziamento.TabIndex = 2;
            this.txtFinanziamento.TabStop = false;
            this.txtFinanziamento.Tag = "underwriting.title?assetgrantview.underwriting";
            // 
            // btnFinanziamento
            // 
            this.btnFinanziamento.Location = new System.Drawing.Point(6, 9);
            this.btnFinanziamento.Name = "btnFinanziamento";
            this.btnFinanziamento.Size = new System.Drawing.Size(104, 23);
            this.btnFinanziamento.TabIndex = 0;
            this.btnFinanziamento.Tag = "choose.underwriting.default";
            this.btnFinanziamento.Text = "Finanziamento";
            this.btnFinanziamento.UseVisualStyleBackColor = true;
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.grpBoxImpegniBudget);
            this.tabEP.Controls.Add(this.gBoxCausale);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(871, 320);
            this.tabEP.TabIndex = 2;
            this.tabEP.Text = "EP";
            this.tabEP.UseVisualStyleBackColor = true;
            // 
            // grpBoxImpegniBudget
            // 
            this.grpBoxImpegniBudget.Controls.Add(this.label34);
            this.grpBoxImpegniBudget.Controls.Add(this.label33);
            this.grpBoxImpegniBudget.Controls.Add(this.txtNumIxBudget);
            this.grpBoxImpegniBudget.Controls.Add(this.txtEsercIxBudget);
            this.grpBoxImpegniBudget.Location = new System.Drawing.Point(10, 81);
            this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
            this.grpBoxImpegniBudget.Size = new System.Drawing.Size(199, 71);
            this.grpBoxImpegniBudget.TabIndex = 55;
            this.grpBoxImpegniBudget.TabStop = false;
            this.grpBoxImpegniBudget.Text = "Accertamento di Budget";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(14, 49);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(44, 13);
            this.label34.TabIndex = 7;
            this.label34.Text = "Numero";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(9, 25);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(49, 13);
            this.label33.TabIndex = 6;
            this.label33.Text = "Esercizio";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumIxBudget
            // 
            this.txtNumIxBudget.Location = new System.Drawing.Point(78, 45);
            this.txtNumIxBudget.Name = "txtNumIxBudget";
            this.txtNumIxBudget.ReadOnly = true;
            this.txtNumIxBudget.Size = new System.Drawing.Size(64, 20);
            this.txtNumIxBudget.TabIndex = 3;
            this.txtNumIxBudget.TabStop = false;
            this.txtNumIxBudget.Tag = "epacc.nepacc";
            // 
            // txtEsercIxBudget
            // 
            this.txtEsercIxBudget.Location = new System.Drawing.Point(78, 19);
            this.txtEsercIxBudget.Name = "txtEsercIxBudget";
            this.txtEsercIxBudget.ReadOnly = true;
            this.txtEsercIxBudget.Size = new System.Drawing.Size(64, 20);
            this.txtEsercIxBudget.TabIndex = 2;
            this.txtEsercIxBudget.TabStop = false;
            this.txtEsercIxBudget.Tag = "epacc.yepacc";
            // 
            // gBoxCausale
            // 
            this.gBoxCausale.Controls.Add(this.textBox1);
            this.gBoxCausale.Controls.Add(this.txtCodiceCausale);
            this.gBoxCausale.Controls.Add(this.button4);
            this.gBoxCausale.Location = new System.Drawing.Point(10, 16);
            this.gBoxCausale.Name = "gBoxCausale";
            this.gBoxCausale.Size = new System.Drawing.Size(608, 59);
            this.gBoxCausale.TabIndex = 54;
            this.gBoxCausale.TabStop = false;
            this.gBoxCausale.Tag = "AutoManage.txtCodiceCausale.tree";
            this.gBoxCausale.Text = "Ricavo";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(228, 18);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(374, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.Tag = "accmotive.title?x";
            // 
            // txtCodiceCausale
            // 
            this.txtCodiceCausale.Location = new System.Drawing.Point(118, 18);
            this.txtCodiceCausale.Name = "txtCodiceCausale";
            this.txtCodiceCausale.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceCausale.TabIndex = 1;
            this.txtCodiceCausale.Tag = "accmotive.codemotive?assetgrantview.codemotive";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(8, 18);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 24);
            this.button4.TabIndex = 0;
            this.button4.Tag = "manage.accmotive.tree";
            this.button4.Text = "Causale";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 13);
            this.label8.TabIndex = 52;
            this.label8.Text = "Valore iniziale";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 149);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 53;
            this.label9.Text = "Valore storico";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtValoreIniziale
            // 
            this.txtValoreIniziale.Location = new System.Drawing.Point(86, 123);
            this.txtValoreIniziale.Name = "txtValoreIniziale";
            this.txtValoreIniziale.Size = new System.Drawing.Size(127, 20);
            this.txtValoreIniziale.TabIndex = 54;
            this.txtValoreIniziale.Tag = "assetview.cost";
            // 
            // txtValoreStorico
            // 
            this.txtValoreStorico.Location = new System.Drawing.Point(86, 149);
            this.txtValoreStorico.Name = "txtValoreStorico";
            this.txtValoreStorico.Size = new System.Drawing.Size(127, 20);
            this.txtValoreStorico.TabIndex = 55;
            this.txtValoreStorico.Tag = "assetview.historical";
            // 
            // Frm_assetgrant_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 346);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_assetgrant_default";
            this.Text = "frmassetgrantdefault";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.gboxInventario.ResumeLayout(false);
            this.grpClassif.ResumeLayout(false);
            this.grpClassif.PerformLayout();
            this.grpCespite.ResumeLayout(false);
            this.grpCespite.PerformLayout();
            this.gboxContributo.ResumeLayout(false);
            this.gboxContributo.PerformLayout();
            this.gboxFinanziamento.ResumeLayout(false);
            this.gboxFinanziamento.PerformLayout();
            this.tabEP.ResumeLayout(false);
            this.grpBoxImpegniBudget.ResumeLayout(false);
            this.grpBoxImpegniBudget.PerformLayout();
            this.gBoxCausale.ResumeLayout(false);
            this.gBoxCausale.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        public vistaForm DS;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabEP;
        private GroupBox gboxFinanziamento;
        private TextBox txtFinanziamento;
        private Button btnFinanziamento;
        private GroupBox gboxInventario;
        private GroupBox grpClassif;
        private TextBox txtDescClassif;
        private TextBox txtIdClassif;
        private Button btnClassif;
        private ComboBox cmbInventoryAgency;
        private Label label3;
        private GroupBox grpCespite;
        private Button btnSelezBene;
        private TextBox txtNumInv;
        private GroupBox gboxContributo;
        private TextBox txtDataDocumento;
        private Label label6;
        private TextBox textBox2;
        private Label label1;
        private TextBox txtDescrizione;
        private Label label5;
        private TextBox txtImporto;
        private TextBox txtAnnoRisc;
        private Label label2;
        private Label label7;
        private GroupBox gBoxCausale;
        private TextBox textBox1;
        private TextBox txtCodiceCausale;
        private Button button4;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        public MetaData Meta;
        bool inChiusura = false;

        CQueryHelper QHC;
        private ComboBox cmbInventario;
        private Label label4;
        private GroupBox grpBoxImpegniBudget;
        private Label label34;
        private Label label33;
        private TextBox txtNumIxBudget;
        private TextBox txtEsercIxBudget;
        private Label label25;
        private TextBox textBox3;
        private TextBox txtValoreStorico;
        private TextBox txtValoreIniziale;
        private Label label9;
        private Label label8;
        QueryHelper QHS;


        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            inChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void MetaData_AfterClear() {
            enableControls(true);
        }

        public void MetaData_AfterLink() {

            Meta = MetaData.GetMetaData(this);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;

            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            GetData.CacheTable(DS.inventory);
            GetData.MarkToAddBlankRow(DS.inventory);
            GetData.CacheTable(DS.inventoryagency);
            GetData.MarkToAddBlankRow(DS.inventoryagency);
           
        }

        public void MetaData_AfterFill() {

            if (!Meta.IsEmpty) {
                if (DS.assetview.Rows.Count == 0)
                    ImpostaFiltrobtnSelezBene(null, false);
                else
                    ImpostaFiltrobtnSelezBene(DS.assetview.Rows[0], true);
            }

            enableControls(false);
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {

            bool ModoInsert = Meta.InsertMode;
            if (T.TableName == "inventory") {
                //				string filtro = (R == null) ? "" : ".(idinventory=" + QueryCreator.quotedstrvalue(R["idinventory"], false) + ")";
                //				btnSelezBene.Tag = "choose.assetpieceview.default" + filtro;
                if (!Meta.DrawStateIsDone) return;
                ImpostaFiltrobtnSelezBene(R, false);
            }

            //if (Meta.InsertMode)// <-- sa
            //    if ((cmbTipoRival.SelectedIndex<=0)||(txtNumInv.Text.Trim()==""))
            //        txtValoreIniziale.Text="";

        }

      

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            gboxFinanziamento.Enabled = abilita;
            gboxContributo.Enabled = abilita;
            gboxInventario.Enabled = abilita;
            gBoxCausale.Enabled = abilita;
        }

        void ImpostaFiltrobtnSelezBene(DataRow rAssetPiece, bool filtraIdPiece) {
            //string filtro = (rAssetPiece == null) ? "" : ".(idinventory=" + QueryCreator.quotedstrvalue(rAssetPiece["idinventory"], false) + ")";
            string filtro = (rAssetPiece == null) ? "" : QHS.CmpEq("idinventory", rAssetPiece["idinventory"]);
            btnSelezBene.Tag = "choose.assetview.default." + filtro;
        }

        private void txtNumInv_TextChanged(object sender, System.EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            if (Meta.IsEmpty) return;
            if (DS.assetview.Rows.Count == 0) {
                ImpostaFiltrobtnSelezBene(null, false);
                return;
            }
            DataRow R = DS.assetview.Rows[0];
            ImpostaFiltrobtnSelezBene(R, false);
    }
    }
}
