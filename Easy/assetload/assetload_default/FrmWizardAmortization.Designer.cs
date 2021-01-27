
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


namespace assetload_default {
    partial class FrmWizardAmortization {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabIntro = new Crownwood.Magic.Controls.TabPage();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbInventario = new System.Windows.Forms.ComboBox();
            this.txt_numinv_a = new System.Windows.Forms.TextBox();
            this.txt_numinv_da = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_numcarico_a = new System.Windows.Forms.TextBox();
            this.txt_numcarico_da = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_idbene_a = new System.Windows.Forms.TextBox();
            this.txt_idbene_da = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.grpUbicazione = new System.Windows.Forms.GroupBox();
            this.txtIDUbicazione = new System.Windows.Forms.TextBox();
            this.btnUbicazione = new System.Windows.Forms.Button();
            this.txtDescUbicazione = new System.Windows.Forms.TextBox();
            this.txtUbicazione = new System.Windows.Forms.TextBox();
            this.cboResponsabile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIncludiAumenti = new System.Windows.Forms.CheckBox();
            this.chkIncludiAsset = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabGrid = new Crownwood.Magic.Controls.TabPage();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.gridBeni = new System.Windows.Forms.DataGrid();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabController.SuspendLayout();
            this.tabIntro.SuspendLayout();
            this.grpUbicazione.SuspendLayout();
            this.tabGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBeni)).BeginInit();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(4, 12);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabGrid;
            this.tabController.Size = new System.Drawing.Size(629, 432);
            this.tabController.TabIndex = 5;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabIntro,
            this.tabGrid});
            // 
            // tabIntro
            // 
            this.tabIntro.Controls.Add(this.txtDescrizione);
            this.tabIntro.Controls.Add(this.label12);
            this.tabIntro.Controls.Add(this.label11);
            this.tabIntro.Controls.Add(this.label10);
            this.tabIntro.Controls.Add(this.label9);
            this.tabIntro.Controls.Add(this.label13);
            this.tabIntro.Controls.Add(this.cmbInventario);
            this.tabIntro.Controls.Add(this.txt_numinv_a);
            this.tabIntro.Controls.Add(this.txt_numinv_da);
            this.tabIntro.Controls.Add(this.label5);
            this.tabIntro.Controls.Add(this.label6);
            this.tabIntro.Controls.Add(this.txt_numcarico_a);
            this.tabIntro.Controls.Add(this.txt_numcarico_da);
            this.tabIntro.Controls.Add(this.label3);
            this.tabIntro.Controls.Add(this.label4);
            this.tabIntro.Controls.Add(this.txt_idbene_a);
            this.tabIntro.Controls.Add(this.txt_idbene_da);
            this.tabIntro.Controls.Add(this.label7);
            this.tabIntro.Controls.Add(this.label8);
            this.tabIntro.Controls.Add(this.grpUbicazione);
            this.tabIntro.Controls.Add(this.cboResponsabile);
            this.tabIntro.Controls.Add(this.label2);
            this.tabIntro.Controls.Add(this.chkIncludiAumenti);
            this.tabIntro.Controls.Add(this.chkIncludiAsset);
            this.tabIntro.Controls.Add(this.label1);
            this.tabIntro.Location = new System.Drawing.Point(0, 0);
            this.tabIntro.Name = "tabIntro";
            this.tabIntro.Selected = false;
            this.tabIntro.Size = new System.Drawing.Size(629, 407);
            this.tabIntro.TabIndex = 3;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(96, 288);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(517, 21);
            this.txtDescrizione.TabIndex = 44;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(24, 231);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(176, 23);
            this.label12.TabIndex = 43;
            this.label12.Text = "Inventario";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(16, 200);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 16);
            this.label11.TabIndex = 42;
            this.label11.Text = "Per numero carico cespite";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(16, 165);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(192, 23);
            this.label10.TabIndex = 41;
            this.label10.Text = "Identificativo cespite principale";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(16, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 40;
            this.label9.Text = "Descrizione";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(208, 234);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(40, 16);
            this.label13.TabIndex = 39;
            this.label13.Text = "Tipo";
            // 
            // cmbInventario
            // 
            this.cmbInventario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbInventario.DisplayMember = "description";
            this.cmbInventario.Location = new System.Drawing.Point(256, 232);
            this.cmbInventario.Name = "cmbInventario";
            this.cmbInventario.Size = new System.Drawing.Size(357, 21);
            this.cmbInventario.TabIndex = 34;
            this.cmbInventario.ValueMember = "idinventory";
            // 
            // txt_numinv_a
            // 
            this.txt_numinv_a.Location = new System.Drawing.Point(368, 264);
            this.txt_numinv_a.Name = "txt_numinv_a";
            this.txt_numinv_a.Size = new System.Drawing.Size(56, 21);
            this.txt_numinv_a.TabIndex = 37;
            this.txt_numinv_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_numinv_da
            // 
            this.txt_numinv_da.Location = new System.Drawing.Point(256, 264);
            this.txt_numinv_da.Name = "txt_numinv_da";
            this.txt_numinv_da.Size = new System.Drawing.Size(56, 21);
            this.txt_numinv_da.TabIndex = 35;
            this.txt_numinv_da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(344, 264);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 16);
            this.label5.TabIndex = 38;
            this.label5.Text = "a";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(216, 264);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 16);
            this.label6.TabIndex = 36;
            this.label6.Text = "Da";
            // 
            // txt_numcarico_a
            // 
            this.txt_numcarico_a.Location = new System.Drawing.Point(368, 200);
            this.txt_numcarico_a.Name = "txt_numcarico_a";
            this.txt_numcarico_a.Size = new System.Drawing.Size(56, 21);
            this.txt_numcarico_a.TabIndex = 31;
            this.txt_numcarico_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_numcarico_da
            // 
            this.txt_numcarico_da.Location = new System.Drawing.Point(256, 200);
            this.txt_numcarico_da.Name = "txt_numcarico_da";
            this.txt_numcarico_da.Size = new System.Drawing.Size(56, 21);
            this.txt_numcarico_da.TabIndex = 29;
            this.txt_numcarico_da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(344, 200);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 16);
            this.label3.TabIndex = 33;
            this.label3.Text = "a";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(216, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Da";
            // 
            // txt_idbene_a
            // 
            this.txt_idbene_a.Location = new System.Drawing.Point(368, 166);
            this.txt_idbene_a.Name = "txt_idbene_a";
            this.txt_idbene_a.Size = new System.Drawing.Size(56, 21);
            this.txt_idbene_a.TabIndex = 26;
            this.txt_idbene_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_idbene_da
            // 
            this.txt_idbene_da.Location = new System.Drawing.Point(256, 166);
            this.txt_idbene_da.Name = "txt_idbene_da";
            this.txt_idbene_da.Size = new System.Drawing.Size(56, 21);
            this.txt_idbene_da.TabIndex = 24;
            this.txt_idbene_da.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(344, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 16);
            this.label7.TabIndex = 27;
            this.label7.Text = "a";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(216, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 25;
            this.label8.Text = "Da";
            // 
            // grpUbicazione
            // 
            this.grpUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUbicazione.Controls.Add(this.txtIDUbicazione);
            this.grpUbicazione.Controls.Add(this.btnUbicazione);
            this.grpUbicazione.Controls.Add(this.txtDescUbicazione);
            this.grpUbicazione.Controls.Add(this.txtUbicazione);
            this.grpUbicazione.Location = new System.Drawing.Point(8, 88);
            this.grpUbicazione.Name = "grpUbicazione";
            this.grpUbicazione.Size = new System.Drawing.Size(605, 72);
            this.grpUbicazione.TabIndex = 12;
            this.grpUbicazione.TabStop = false;
            this.grpUbicazione.Tag = "AutoManage.txtUbicazione.tree";
            this.grpUbicazione.Text = "Ubicazione";
            // 
            // txtIDUbicazione
            // 
            this.txtIDUbicazione.Location = new System.Drawing.Point(296, 24);
            this.txtIDUbicazione.Name = "txtIDUbicazione";
            this.txtIDUbicazione.Size = new System.Drawing.Size(100, 21);
            this.txtIDUbicazione.TabIndex = 9;
            this.txtIDUbicazione.Visible = false;
            // 
            // btnUbicazione
            // 
            this.btnUbicazione.Location = new System.Drawing.Point(8, 16);
            this.btnUbicazione.Name = "btnUbicazione";
            this.btnUbicazione.Size = new System.Drawing.Size(128, 23);
            this.btnUbicazione.TabIndex = 6;
            this.btnUbicazione.TabStop = false;
            this.btnUbicazione.Tag = "manage.locationview.tree";
            this.btnUbicazione.Text = "Ubicazione";
            this.btnUbicazione.Click += new System.EventHandler(this.btnUbicazione_Click);
            // 
            // txtDescUbicazione
            // 
            this.txtDescUbicazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescUbicazione.Location = new System.Drawing.Point(144, 21);
            this.txtDescUbicazione.Multiline = true;
            this.txtDescUbicazione.Name = "txtDescUbicazione";
            this.txtDescUbicazione.ReadOnly = true;
            this.txtDescUbicazione.Size = new System.Drawing.Size(453, 48);
            this.txtDescUbicazione.TabIndex = 8;
            this.txtDescUbicazione.TabStop = false;
            this.txtDescUbicazione.Tag = "locationview.description";
            // 
            // txtUbicazione
            // 
            this.txtUbicazione.Location = new System.Drawing.Point(8, 40);
            this.txtUbicazione.Name = "txtUbicazione";
            this.txtUbicazione.Size = new System.Drawing.Size(128, 21);
            this.txtUbicazione.TabIndex = 1;
            this.txtUbicazione.Tag = "locationview.locationcode?assetview.locationcode";
            this.txtUbicazione.Leave += new System.EventHandler(this.txtUbicazione_Leave);
            // 
            // cboResponsabile
            // 
            this.cboResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboResponsabile.Location = new System.Drawing.Point(128, 56);
            this.cboResponsabile.Name = "cboResponsabile";
            this.cboResponsabile.Size = new System.Drawing.Size(485, 21);
            this.cboResponsabile.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Responsabile";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIncludiAumenti
            // 
            this.chkIncludiAumenti.Checked = true;
            this.chkIncludiAumenti.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludiAumenti.Location = new System.Drawing.Point(179, 32);
            this.chkIncludiAumenti.Name = "chkIncludiAumenti";
            this.chkIncludiAumenti.Size = new System.Drawing.Size(175, 18);
            this.chkIncludiAumenti.TabIndex = 2;
            this.chkIncludiAumenti.Text = "Rivalutazioni sugli accessori";
            // 
            // chkIncludiAsset
            // 
            this.chkIncludiAsset.Checked = true;
            this.chkIncludiAsset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIncludiAsset.Location = new System.Drawing.Point(16, 32);
            this.chkIncludiAsset.Name = "chkIncludiAsset";
            this.chkIncludiAsset.Size = new System.Drawing.Size(147, 16);
            this.chkIncludiAsset.TabIndex = 1;
            this.chkIncludiAsset.Text = "Rivalutazioni su cespiti";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(576, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selezionare i beni dei quali si desidera caricare le rivalutazioni";
            // 
            // tabGrid
            // 
            this.tabGrid.Controls.Add(this.btnSelezionaTutto);
            this.tabGrid.Controls.Add(this.label16);
            this.tabGrid.Controls.Add(this.label14);
            this.tabGrid.Controls.Add(this.gridBeni);
            this.tabGrid.Location = new System.Drawing.Point(0, 0);
            this.tabGrid.Name = "tabGrid";
            this.tabGrid.Size = new System.Drawing.Size(629, 407);
            this.tabGrid.TabIndex = 4;
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.Location = new System.Drawing.Point(8, 16);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(88, 23);
            this.btnSelezionaTutto.TabIndex = 26;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(112, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(456, 32);
            this.label16.TabIndex = 25;
            this.label16.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare più cespiti da scaricare";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(8, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(358, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "Cespiti e accessori di cui si intende caricare le rivalutazioni:";
            // 
            // gridBeni
            // 
            this.gridBeni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBeni.DataMember = "";
            this.gridBeni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridBeni.Location = new System.Drawing.Point(8, 64);
            this.gridBeni.Name = "gridBeni";
            this.gridBeni.Size = new System.Drawing.Size(613, 336);
            this.gridBeni.TabIndex = 0;
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(457, 460);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(377, 460);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(561, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Cancel";
            // 
            // FrmWizardAmortization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 495);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmWizardAmortization";
            this.Text = "FrmWizardAmortization";
            this.tabController.ResumeLayout(false);
            this.tabIntro.ResumeLayout(false);
            this.tabIntro.PerformLayout();
            this.grpUbicazione.ResumeLayout(false);
            this.grpUbicazione.PerformLayout();
            this.tabGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBeni)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabIntro;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbInventario;
        private System.Windows.Forms.TextBox txt_numinv_a;
        private System.Windows.Forms.TextBox txt_numinv_da;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_numcarico_a;
        private System.Windows.Forms.TextBox txt_numcarico_da;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_idbene_a;
        private System.Windows.Forms.TextBox txt_idbene_da;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox grpUbicazione;
        private System.Windows.Forms.TextBox txtIDUbicazione;
        private System.Windows.Forms.Button btnUbicazione;
        private System.Windows.Forms.TextBox txtDescUbicazione;
        private System.Windows.Forms.TextBox txtUbicazione;
        private System.Windows.Forms.ComboBox cboResponsabile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkIncludiAumenti;
        private System.Windows.Forms.CheckBox chkIncludiAsset;
        private System.Windows.Forms.Label label1;
        private Crownwood.Magic.Controls.TabPage tabGrid;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGrid gridBeni;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnCancel;
    }
}
