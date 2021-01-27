
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ep_functions;
using metadatalibrary;

namespace assetgrantdetail_default {
    public partial class Frm_assetgrantdetail_default :Form {
        

        public MetaData Meta;
        private System.ComponentModel.Container components = null;
        public dsmeta DS;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private ComboBox comboBox1;
        private Label label3;
        private GroupBox grpClassif;
        private TextBox txtDescClassif;
        private TextBox txtIdClassif;
        private Button btnClassif;
        private GroupBox grpContributo;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label5;
        private Label label6;
        private GroupBox grpCespite;
        private Button btnSelezBene;
        private TextBox txtNumInv;
        private ComboBox cmbInventario;
        private Label label4;
        private GroupBox grpDettagli;
        private TextBox txtImporto;
        private TextBox txtAnnoRisc;
        private Label label2;
        private Label label1;
        private TabPage tabEP;
        private GroupBox grpBoxImpegniBudget;
        private Label label34;
        private Label label33;
        private TextBox txtNumIxBudget;
        private TextBox txtEsercIxBudget;
        private Label label25;
        private TextBox textBox1;
        bool inChiusura = false;


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

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;

            grpCespite.Enabled = abilita;
            grpContributo.Enabled = abilita;
            grpDettagli.Enabled = abilita;
            grpClassif.Enabled = abilita;
        }


        public void MetaData_AfterFill() {
            enableControls(false);
        }




        public Frm_assetgrantdetail_default() {
            InitializeComponent();
        }
                                  


        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
            Meta.CanSave = false;

        
        }

       






        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_assetgrantdetail_default));
            this.DS = new assetgrantdetail_default.dsmeta();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpClassif = new System.Windows.Forms.GroupBox();
            this.txtDescClassif = new System.Windows.Forms.TextBox();
            this.txtIdClassif = new System.Windows.Forms.TextBox();
            this.btnClassif = new System.Windows.Forms.Button();
            this.grpContributo = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpCespite = new System.Windows.Forms.GroupBox();
            this.btnSelezBene = new System.Windows.Forms.Button();
            this.txtNumInv = new System.Windows.Forms.TextBox();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grpDettagli = new System.Windows.Forms.GroupBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtAnnoRisc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabEP = new System.Windows.Forms.TabPage();
            this.grpBoxImpegniBudget = new System.Windows.Forms.GroupBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.txtNumIxBudget = new System.Windows.Forms.TextBox();
            this.txtEsercIxBudget = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpClassif.SuspendLayout();
            this.grpContributo.SuspendLayout();
            this.grpCespite.SuspendLayout();
            this.grpDettagli.SuspendLayout();
            this.tabEP.SuspendLayout();
            this.grpBoxImpegniBudget.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "dsmeta";
            this.DS.EnforceConstraints = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabEP);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(956, 316);
            this.tabControl1.TabIndex = 54;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.grpClassif);
            this.tabPage1.Controls.Add(this.grpContributo);
            this.tabPage1.Controls.Add(this.grpCespite);
            this.tabPage1.Controls.Add(this.grpDettagli);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(948, 290);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Principale";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DataSource = this.DS.inventoryagency;
            this.comboBox1.DisplayMember = "description";
            this.comboBox1.Location = new System.Drawing.Point(477, 130);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(435, 21);
            this.comboBox1.TabIndex = 44;
            this.comboBox1.Tag = "inventory.idinventoryagency";
            this.comboBox1.ValueMember = "idinventoryagency";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(477, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 16);
            this.label3.TabIndex = 45;
            this.label3.Text = "Ente proprietario dei cespiti:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpClassif
            // 
            this.grpClassif.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassif.Controls.Add(this.txtDescClassif);
            this.grpClassif.Controls.Add(this.txtIdClassif);
            this.grpClassif.Controls.Add(this.btnClassif);
            this.grpClassif.Location = new System.Drawing.Point(472, 19);
            this.grpClassif.Name = "grpClassif";
            this.grpClassif.Size = new System.Drawing.Size(440, 79);
            this.grpClassif.TabIndex = 43;
            this.grpClassif.TabStop = false;
            this.grpClassif.Tag = "AutoManage.txtIdClassif.tree";
            this.grpClassif.Text = "Classificazione inventariale";
            // 
            // txtDescClassif
            // 
            this.txtDescClassif.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescClassif.Location = new System.Drawing.Point(170, 11);
            this.txtDescClassif.Multiline = true;
            this.txtDescClassif.Name = "txtDescClassif";
            this.txtDescClassif.ReadOnly = true;
            this.txtDescClassif.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescClassif.Size = new System.Drawing.Size(264, 62);
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
            this.txtIdClassif.Tag = "inventorytreeview.codeinv?assetgrantdetailview.codeinv";
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
            // grpContributo
            // 
            this.grpContributo.Controls.Add(this.textBox3);
            this.grpContributo.Controls.Add(this.textBox4);
            this.grpContributo.Controls.Add(this.label5);
            this.grpContributo.Controls.Add(this.label6);
            this.grpContributo.Location = new System.Drawing.Point(6, 124);
            this.grpContributo.Name = "grpContributo";
            this.grpContributo.Size = new System.Drawing.Size(452, 142);
            this.grpContributo.TabIndex = 42;
            this.grpContributo.TabStop = false;
            this.grpContributo.Tag = "";
            this.grpContributo.Text = "Contributo";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(118, 59);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox3.Size = new System.Drawing.Size(328, 70);
            this.textBox3.TabIndex = 16;
            this.textBox3.Tag = "assetgrant.description";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(118, 24);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 15;
            this.textBox4.Tag = "assetgrantdetail.idgrant";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Descrizione ";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Numero ";
            // 
            // grpCespite
            // 
            this.grpCespite.Controls.Add(this.label25);
            this.grpCespite.Controls.Add(this.textBox1);
            this.grpCespite.Controls.Add(this.btnSelezBene);
            this.grpCespite.Controls.Add(this.txtNumInv);
            this.grpCespite.Controls.Add(this.cmbInventario);
            this.grpCespite.Controls.Add(this.label4);
            this.grpCespite.Location = new System.Drawing.Point(6, 6);
            this.grpCespite.Name = "grpCespite";
            this.grpCespite.Size = new System.Drawing.Size(452, 98);
            this.grpCespite.TabIndex = 41;
            this.grpCespite.TabStop = false;
            this.grpCespite.Tag = "";
            this.grpCespite.Text = "Cespite";
            // 
            // btnSelezBene
            // 
            this.btnSelezBene.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelezBene.Location = new System.Drawing.Point(19, 58);
            this.btnSelezBene.Name = "btnSelezBene";
            this.btnSelezBene.Size = new System.Drawing.Size(93, 21);
            this.btnSelezBene.TabIndex = 18;
            this.btnSelezBene.TabStop = false;
            this.btnSelezBene.Tag = "choose.assetview.default";
            this.btnSelezBene.Text = "N. Inventario";
            // 
            // txtNumInv
            // 
            this.txtNumInv.Location = new System.Drawing.Point(120, 59);
            this.txtNumInv.Name = "txtNumInv";
            this.txtNumInv.Size = new System.Drawing.Size(100, 20);
            this.txtNumInv.TabIndex = 19;
            this.txtNumInv.Tag = "assetview.ninventory?assetgrantdetailview.ninventory";
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DataSource = this.DS.inventory;
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbInventario.Location = new System.Drawing.Point(118, 21);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(328, 21);
            this.cmbInventario.TabIndex = 17;
            this.cmbInventario.Tag = "inventory.idinventory.(active=\'S\')?assetgrantdetailview.idinventory";
            this.cmbInventario.ValueMember = "idinventory";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Inventario";
            // 
            // grpDettagli
            // 
            this.grpDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDettagli.AutoSize = true;
            this.grpDettagli.Controls.Add(this.txtImporto);
            this.grpDettagli.Controls.Add(this.txtAnnoRisc);
            this.grpDettagli.Controls.Add(this.label2);
            this.grpDettagli.Controls.Add(this.label1);
            this.grpDettagli.Location = new System.Drawing.Point(472, 167);
            this.grpDettagli.Name = "grpDettagli";
            this.grpDettagli.Size = new System.Drawing.Size(434, 99);
            this.grpDettagli.TabIndex = 40;
            this.grpDettagli.TabStop = false;
            this.grpDettagli.Tag = "";
            this.grpDettagli.Text = "Dettaglio";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(118, 59);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(131, 20);
            this.txtImporto.TabIndex = 16;
            this.txtImporto.Tag = "assetgrantdetail.amount";
            // 
            // txtAnnoRisc
            // 
            this.txtAnnoRisc.Location = new System.Drawing.Point(118, 20);
            this.txtAnnoRisc.Name = "txtAnnoRisc";
            this.txtAnnoRisc.Size = new System.Drawing.Size(77, 20);
            this.txtAnnoRisc.TabIndex = 15;
            this.txtAnnoRisc.Tag = "assetgrantdetail.ydetail.year";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Importo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Anno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabEP
            // 
            this.tabEP.Controls.Add(this.grpBoxImpegniBudget);
            this.tabEP.Location = new System.Drawing.Point(4, 22);
            this.tabEP.Name = "tabEP";
            this.tabEP.Size = new System.Drawing.Size(948, 290);
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
            this.grpBoxImpegniBudget.Location = new System.Drawing.Point(17, 17);
            this.grpBoxImpegniBudget.Name = "grpBoxImpegniBudget";
            this.grpBoxImpegniBudget.Size = new System.Drawing.Size(199, 71);
            this.grpBoxImpegniBudget.TabIndex = 54;
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
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(237, 60);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 53;
            this.label25.Tag = "";
            this.label25.Text = "N.parte";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(299, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 20);
            this.textBox1.TabIndex = 52;
            this.textBox1.Tag = "assetgrantdetail.idpiece";
            // 
            // Frm_assetgrantdetail_default
            // 
            this.ClientSize = new System.Drawing.Size(967, 331);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_assetgrantdetail_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.grpClassif.ResumeLayout(false);
            this.grpClassif.PerformLayout();
            this.grpContributo.ResumeLayout(false);
            this.grpContributo.PerformLayout();
            this.grpCespite.ResumeLayout(false);
            this.grpCespite.PerformLayout();
            this.grpDettagli.ResumeLayout(false);
            this.grpDettagli.PerformLayout();
            this.tabEP.ResumeLayout(false);
            this.grpBoxImpegniBudget.ResumeLayout(false);
            this.grpBoxImpegniBudget.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

    }
}
