
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


namespace storeunload_default {
    partial class FrmSelectDetailsFromStock
    {
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
            this.btnBack = new System.Windows.Forms.Button();
            this.labelMsg = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.grpAnalitico = new System.Windows.Forms.GroupBox();
            this.gboxclass1 = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice1 = new System.Windows.Forms.TextBox();
            this.gboxclass3 = new System.Windows.Forms.GroupBox();
            this.btnCodice3 = new System.Windows.Forms.Button();
            this.txtDenom3 = new System.Windows.Forms.TextBox();
            this.txtCodice3 = new System.Windows.Forms.TextBox();
            this.gboxclass2 = new System.Windows.Forms.GroupBox();
            this.btnCodice2 = new System.Windows.Forms.Button();
            this.txtDenom2 = new System.Windows.Forms.TextBox();
            this.txtCodice2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbResponsabile = new System.Windows.Forms.ComboBox();
            this.lblMsg2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblidpackage = new System.Windows.Forms.Label();
            this.txtQuantita = new System.Windows.Forms.TextBox();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.gboxMerceSelezionata = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDisponibile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCodListino2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassificazione = new System.Windows.Forms.TextBox();
            this.txtDescListino2 = new System.Windows.Forms.TextBox();
            this.txtBooked = new System.Windows.Forms.TextBox();
            this.txtOrdered = new System.Windows.Forms.TextBox();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.grpListino = new System.Windows.Forms.GroupBox();
            this.chkListDescription = new System.Windows.Forms.CheckBox();
            this.chkFilterClass = new System.Windows.Forms.CheckBox();
            this.btnListino = new System.Windows.Forms.Button();
            this.txtCodListino = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.tabPage2.SuspendLayout();
            this.tabController.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grpAnalitico.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.gboxMerceSelezionata.SuspendLayout();
            this.grpListino.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(351, 452);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(72, 23);
            this.btnBack.TabIndex = 15;
            this.btnBack.Text = "< Indietro";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // labelMsg
            // 
            this.labelMsg.Location = new System.Drawing.Point(8, 8);
            this.labelMsg.Name = "labelMsg";
            this.labelMsg.Size = new System.Drawing.Size(576, 23);
            this.labelMsg.TabIndex = 0;
            this.labelMsg.Text = "label1";
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(431, 452);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(72, 23);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "Avanti >";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelMsg);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(600, 408);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Title = "Pagina 3 di 3";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(535, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            // 
            // tabController
            // 
            this.tabController.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(7, 11);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 1;
            this.tabController.SelectedTab = this.tabPage1;
            this.tabController.Size = new System.Drawing.Size(600, 433);
            this.tabController.TabIndex = 18;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grpAnalitico);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cmbResponsabile);
            this.tabPage1.Controls.Add(this.lblMsg2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(600, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Title = "Pagina 2 di 3";
            // 
            // grpAnalitico
            // 
            this.grpAnalitico.Controls.Add(this.gboxclass1);
            this.grpAnalitico.Controls.Add(this.gboxclass3);
            this.grpAnalitico.Controls.Add(this.gboxclass2);
            this.grpAnalitico.Location = new System.Drawing.Point(14, 123);
            this.grpAnalitico.Name = "grpAnalitico";
            this.grpAnalitico.Size = new System.Drawing.Size(366, 272);
            this.grpAnalitico.TabIndex = 21;
            this.grpAnalitico.TabStop = false;
            this.grpAnalitico.Text = "Analitico";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(15, 15);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(336, 80);
            this.gboxclass1.TabIndex = 4;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 23);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCodice1.Click += new System.EventHandler(this.btnCodice1_Click);
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(128, 20);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(200, 56);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 53);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(112, 23);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?x";
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(15, 187);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(336, 79);
            this.gboxclass3.TabIndex = 5;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 22);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCodice3.Click += new System.EventHandler(this.btnCodice3_Click);
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(128, 20);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(200, 55);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 51);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(112, 23);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?x";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(15, 101);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(336, 80);
            this.gboxclass2.TabIndex = 6;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(6, 25);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCodice2.Click += new System.EventHandler(this.btnCodice2_Click);
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(128, 20);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(200, 56);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(6, 53);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(112, 23);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?x";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 94);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 16);
            this.label9.TabIndex = 20;
            this.label9.Text = "Responsabile:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbResponsabile
            // 
            this.cmbResponsabile.DisplayMember = "description";
            this.cmbResponsabile.Location = new System.Drawing.Point(94, 94);
            this.cmbResponsabile.Name = "cmbResponsabile";
            this.cmbResponsabile.Size = new System.Drawing.Size(320, 23);
            this.cmbResponsabile.TabIndex = 19;
            this.cmbResponsabile.Tag = "";
            this.cmbResponsabile.SelectedIndexChanged += new System.EventHandler(this.cmbResponsabile_SelectedIndexChanged);
            // 
            // lblMsg2
            // 
            this.lblMsg2.Location = new System.Drawing.Point(5, 10);
            this.lblMsg2.Name = "lblMsg2";
            this.lblMsg2.Size = new System.Drawing.Size(576, 23);
            this.lblMsg2.TabIndex = 18;
            this.lblMsg2.Text = "Digitare la quantità da scaricare";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblidpackage);
            this.groupBox1.Controls.Add(this.txtQuantita);
            this.groupBox1.Location = new System.Drawing.Point(5, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 50);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            // 
            // lblidpackage
            // 
            this.lblidpackage.Location = new System.Drawing.Point(6, 20);
            this.lblidpackage.Name = "lblidpackage";
            this.lblidpackage.Size = new System.Drawing.Size(59, 18);
            this.lblidpackage.TabIndex = 15;
            this.lblidpackage.Text = "Quantità:";
            // 
            // txtQuantita
            // 
            this.txtQuantita.Location = new System.Drawing.Point(70, 17);
            this.txtQuantita.Name = "txtQuantita";
            this.txtQuantita.Size = new System.Drawing.Size(94, 23);
            this.txtQuantita.TabIndex = 16;
            this.txtQuantita.Tag = "";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.gboxMerceSelezionata);
            this.tabPage3.Controls.Add(this.grpListino);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.cmbMagazzino);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(600, 408);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Title = "Pagina 1 di 3";
            // 
            // gboxMerceSelezionata
            // 
            this.gboxMerceSelezionata.Controls.Add(this.label8);
            this.gboxMerceSelezionata.Controls.Add(this.label7);
            this.gboxMerceSelezionata.Controls.Add(this.txtDisponibile);
            this.gboxMerceSelezionata.Controls.Add(this.label6);
            this.gboxMerceSelezionata.Controls.Add(this.label5);
            this.gboxMerceSelezionata.Controls.Add(this.txtCodListino2);
            this.gboxMerceSelezionata.Controls.Add(this.label4);
            this.gboxMerceSelezionata.Controls.Add(this.label2);
            this.gboxMerceSelezionata.Controls.Add(this.label1);
            this.gboxMerceSelezionata.Controls.Add(this.txtClassificazione);
            this.gboxMerceSelezionata.Controls.Add(this.txtDescListino2);
            this.gboxMerceSelezionata.Controls.Add(this.txtBooked);
            this.gboxMerceSelezionata.Controls.Add(this.txtOrdered);
            this.gboxMerceSelezionata.Controls.Add(this.txtNumber);
            this.gboxMerceSelezionata.Location = new System.Drawing.Point(12, 190);
            this.gboxMerceSelezionata.Name = "gboxMerceSelezionata";
            this.gboxMerceSelezionata.Size = new System.Drawing.Size(585, 162);
            this.gboxMerceSelezionata.TabIndex = 22;
            this.gboxMerceSelezionata.TabStop = false;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(142, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(239, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Descrizione";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(428, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 18);
            this.label7.TabIndex = 23;
            this.label7.Text = "Quantità Disponibile:";
            // 
            // txtDisponibile
            // 
            this.txtDisponibile.Location = new System.Drawing.Point(427, 126);
            this.txtDisponibile.Name = "txtDisponibile";
            this.txtDisponibile.ReadOnly = true;
            this.txtDisponibile.Size = new System.Drawing.Size(116, 23);
            this.txtDisponibile.TabIndex = 22;
            this.txtDisponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(382, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Classificazione";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Codice Listino";
            // 
            // txtCodListino2
            // 
            this.txtCodListino2.Location = new System.Drawing.Point(9, 39);
            this.txtCodListino2.Name = "txtCodListino2";
            this.txtCodListino2.ReadOnly = true;
            this.txtCodListino2.Size = new System.Drawing.Size(127, 23);
            this.txtCodListino2.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(291, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Quantità Prenotata:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(151, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Ordini Inevasi:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Quantità in giacenza:";
            // 
            // txtClassificazione
            // 
            this.txtClassificazione.Location = new System.Drawing.Point(385, 39);
            this.txtClassificazione.Name = "txtClassificazione";
            this.txtClassificazione.ReadOnly = true;
            this.txtClassificazione.Size = new System.Drawing.Size(191, 23);
            this.txtClassificazione.TabIndex = 7;
            // 
            // txtDescListino2
            // 
            this.txtDescListino2.Location = new System.Drawing.Point(142, 39);
            this.txtDescListino2.Multiline = true;
            this.txtDescListino2.Name = "txtDescListino2";
            this.txtDescListino2.ReadOnly = true;
            this.txtDescListino2.Size = new System.Drawing.Size(239, 44);
            this.txtDescListino2.TabIndex = 6;
            // 
            // txtBooked
            // 
            this.txtBooked.Location = new System.Drawing.Point(290, 126);
            this.txtBooked.Name = "txtBooked";
            this.txtBooked.ReadOnly = true;
            this.txtBooked.Size = new System.Drawing.Size(116, 23);
            this.txtBooked.TabIndex = 2;
            this.txtBooked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtOrdered
            // 
            this.txtOrdered.Location = new System.Drawing.Point(148, 126);
            this.txtOrdered.Name = "txtOrdered";
            this.txtOrdered.ReadOnly = true;
            this.txtOrdered.Size = new System.Drawing.Size(116, 23);
            this.txtOrdered.TabIndex = 1;
            this.txtOrdered.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(10, 126);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.ReadOnly = true;
            this.txtNumber.Size = new System.Drawing.Size(116, 23);
            this.txtNumber.TabIndex = 0;
            this.txtNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpListino
            // 
            this.grpListino.Controls.Add(this.chkListDescription);
            this.grpListino.Controls.Add(this.chkFilterClass);
            this.grpListino.Controls.Add(this.btnListino);
            this.grpListino.Controls.Add(this.txtCodListino);
            this.grpListino.Controls.Add(this.txtDescrizione);
            this.grpListino.Location = new System.Drawing.Point(16, 56);
            this.grpListino.Name = "grpListino";
            this.grpListino.Size = new System.Drawing.Size(459, 100);
            this.grpListino.TabIndex = 20;
            this.grpListino.TabStop = false;
            // 
            // chkListDescription
            // 
            this.chkListDescription.Location = new System.Drawing.Point(15, 35);
            this.chkListDescription.Name = "chkListDescription";
            this.chkListDescription.Size = new System.Drawing.Size(168, 24);
            this.chkListDescription.TabIndex = 22;
            this.chkListDescription.TabStop = false;
            this.chkListDescription.Text = "Cerca per descrizione";
            // 
            // chkFilterClass
            // 
            this.chkFilterClass.Location = new System.Drawing.Point(15, 13);
            this.chkFilterClass.Name = "chkFilterClass";
            this.chkFilterClass.Size = new System.Drawing.Size(197, 22);
            this.chkFilterClass.TabIndex = 21;
            this.chkFilterClass.TabStop = false;
            this.chkFilterClass.Text = "Filtra per Class.Merceologica";
            // 
            // btnListino
            // 
            this.btnListino.BackColor = System.Drawing.SystemColors.Control;
            this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListino.ImageIndex = 0;
            this.btnListino.Location = new System.Drawing.Point(13, 63);
            this.btnListino.Name = "btnListino";
            this.btnListino.Size = new System.Drawing.Size(57, 23);
            this.btnListino.TabIndex = 20;
            this.btnListino.TabStop = false;
            this.btnListino.Tag = "";
            this.btnListino.Text = "Listino";
            this.btnListino.UseVisualStyleBackColor = false;
            this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
            // 
            // txtCodListino
            // 
            this.txtCodListino.Location = new System.Drawing.Point(76, 65);
            this.txtCodListino.Name = "txtCodListino";
            this.txtCodListino.Size = new System.Drawing.Size(142, 23);
            this.txtCodListino.TabIndex = 23;
            this.txtCodListino.Tag = "listview.intcode?mandatedetailview.intcode";
            this.txtCodListino.Leave += new System.EventHandler(this.txtCodListino_Leave);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(224, 40);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(223, 47);
            this.txtDescrizione.TabIndex = 24;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Magazzino:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.Location = new System.Drawing.Point(14, 29);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(303, 23);
            this.cmbMagazzino.TabIndex = 2;
            this.cmbMagazzino.Tag = "";
            // 
            // FrmSelectDetailsFromStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 486);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabController);
            this.Name = "FrmSelectDetailsFromStock";
            this.Text = "FrmSelectDetails";
            this.tabPage2.ResumeLayout(false);
            this.tabController.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grpAnalitico.ResumeLayout(false);
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.gboxMerceSelezionata.ResumeLayout(false);
            this.gboxMerceSelezionata.PerformLayout();
            this.grpListino.ResumeLayout(false);
            this.grpListino.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label labelMsg;
        private System.Windows.Forms.Button btnNext;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Button btnCancel;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMagazzino;
        private System.Windows.Forms.GroupBox grpListino;
        private System.Windows.Forms.CheckBox chkListDescription;
        private System.Windows.Forms.CheckBox chkFilterClass;
        private System.Windows.Forms.Button btnListino;
        private System.Windows.Forms.TextBox txtCodListino;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label lblMsg2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblidpackage;
        private System.Windows.Forms.TextBox txtQuantita;
        private System.Windows.Forms.GroupBox gboxMerceSelezionata;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCodListino2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassificazione;
        private System.Windows.Forms.TextBox txtDescListino2;
        private System.Windows.Forms.TextBox txtBooked;
        private System.Windows.Forms.TextBox txtOrdered;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDisponibile;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbResponsabile;
        private System.Windows.Forms.GroupBox grpAnalitico;
        public System.Windows.Forms.GroupBox gboxclass1;
        public System.Windows.Forms.Button btnCodice1;
        private System.Windows.Forms.TextBox txtDenom1;
        private System.Windows.Forms.TextBox txtCodice1;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        private System.Windows.Forms.TextBox txtDenom3;
        private System.Windows.Forms.TextBox txtCodice3;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        private System.Windows.Forms.TextBox txtDenom2;
        private System.Windows.Forms.TextBox txtCodice2;

    }
}
