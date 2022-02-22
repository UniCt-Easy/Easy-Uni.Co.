
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


namespace bookingdetail_default
{
    partial class Frm_bookingdetail_default
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DS = new bookingdetail_default.vistaForm();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbidman = new System.Windows.Forms.ComboBox();
            this.txtnbooking = new System.Windows.Forms.TextBox();
            this.txtybooking = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.lblEsercizio = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPagePrincipale = new System.Windows.Forms.TabPage();
            this.txtEvaso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkAuthorizeed = new System.Windows.Forms.CheckBox();
            this.cmbMagazzino = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gboxListClass = new System.Windows.Forms.GroupBox();
            this.txtCodiceClass = new System.Windows.Forms.TextBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.txtDescrListClass = new System.Windows.Forms.TextBox();
            this.btnListClassCode = new System.Windows.Forms.Button();
            this.grpArticolo = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.pbox = new System.Windows.Forms.PictureBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.txtNumber = new System.Windows.Forms.TextBox();
            this.txtDesArt = new System.Windows.Forms.TextBox();
            this.lblDesArt = new System.Windows.Forms.Label();
            this.txtCodArt = new System.Windows.Forms.TextBox();
            this.lblCodArt = new System.Windows.Forms.Label();
            this.tabPageAnalitico = new System.Windows.Forms.TabPage();
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
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPagePrincipale.SuspendLayout();
            this.gboxListClass.SuspendLayout();
            this.grpArticolo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
            this.tabPageAnalitico.SuspendLayout();
            this.gboxclass3.SuspendLayout();
            this.gboxclass2.SuspendLayout();
            this.gboxclass1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cmbidman);
            this.groupBox2.Location = new System.Drawing.Point(279, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(319, 47);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Responsabile";
            // 
            // cmbidman
            // 
            this.cmbidman.DataSource = this.DS.manager;
            this.cmbidman.DisplayMember = "title";
            this.cmbidman.FormattingEnabled = true;
            this.cmbidman.Location = new System.Drawing.Point(6, 17);
            this.cmbidman.Name = "cmbidman";
            this.cmbidman.Size = new System.Drawing.Size(307, 21);
            this.cmbidman.TabIndex = 0;
            this.cmbidman.Tag = "booking.idman?bookingdetailview.idman";
            this.cmbidman.ValueMember = "idman";
            // 
            // txtnbooking
            // 
            this.txtnbooking.Location = new System.Drawing.Point(206, 23);
            this.txtnbooking.Name = "txtnbooking";
            this.txtnbooking.Size = new System.Drawing.Size(67, 20);
            this.txtnbooking.TabIndex = 3;
            this.txtnbooking.Tag = "booking.nbooking?bookingdetailview.nbooking";
            // 
            // txtybooking
            // 
            this.txtybooking.Location = new System.Drawing.Point(86, 23);
            this.txtybooking.Name = "txtybooking";
            this.txtybooking.Size = new System.Drawing.Size(60, 20);
            this.txtybooking.TabIndex = 1;
            this.txtybooking.Tag = "booking.ybooking.year?bookingdetailview.ybooking.year";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(156, 26);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(44, 13);
            this.lblNumero.TabIndex = 2;
            this.lblNumero.Text = "Numero";
            // 
            // lblEsercizio
            // 
            this.lblEsercizio.AutoSize = true;
            this.lblEsercizio.Location = new System.Drawing.Point(31, 26);
            this.lblEsercizio.Name = "lblEsercizio";
            this.lblEsercizio.Size = new System.Drawing.Size(49, 13);
            this.lblEsercizio.TabIndex = 0;
            this.lblEsercizio.Text = "Esercizio";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPagePrincipale);
            this.tabControl1.Controls.Add(this.tabPageAnalitico);
            this.tabControl1.Location = new System.Drawing.Point(3, 58);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(604, 380);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPagePrincipale
            // 
            this.tabPagePrincipale.Controls.Add(this.txtEvaso);
            this.tabPagePrincipale.Controls.Add(this.label2);
            this.tabPagePrincipale.Controls.Add(this.chkAuthorizeed);
            this.tabPagePrincipale.Controls.Add(this.cmbMagazzino);
            this.tabPagePrincipale.Controls.Add(this.label7);
            this.tabPagePrincipale.Controls.Add(this.gboxListClass);
            this.tabPagePrincipale.Controls.Add(this.grpArticolo);
            this.tabPagePrincipale.Location = new System.Drawing.Point(4, 22);
            this.tabPagePrincipale.Name = "tabPagePrincipale";
            this.tabPagePrincipale.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePrincipale.Size = new System.Drawing.Size(596, 354);
            this.tabPagePrincipale.TabIndex = 0;
            this.tabPagePrincipale.Text = "Principale";
            this.tabPagePrincipale.UseVisualStyleBackColor = true;
            // 
            // txtEvaso
            // 
            this.txtEvaso.Location = new System.Drawing.Point(182, 290);
            this.txtEvaso.Name = "txtEvaso";
            this.txtEvaso.ReadOnly = true;
            this.txtEvaso.Size = new System.Drawing.Size(100, 20);
            this.txtEvaso.TabIndex = 16;
            this.txtEvaso.Tag = "";
            this.txtEvaso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Quantità evasa";
            // 
            // chkAuthorizeed
            // 
            this.chkAuthorizeed.Location = new System.Drawing.Point(9, 266);
            this.chkAuthorizeed.Name = "chkAuthorizeed";
            this.chkAuthorizeed.Size = new System.Drawing.Size(273, 16);
            this.chkAuthorizeed.TabIndex = 14;
            this.chkAuthorizeed.TabStop = false;
            this.chkAuthorizeed.Tag = "bookingdetail.authorized:S:N";
            this.chkAuthorizeed.Text = "Autorizzato";
            // 
            // cmbMagazzino
            // 
            this.cmbMagazzino.DataSource = this.DS.store;
            this.cmbMagazzino.DisplayMember = "description";
            this.cmbMagazzino.FormattingEnabled = true;
            this.cmbMagazzino.Location = new System.Drawing.Point(6, 236);
            this.cmbMagazzino.Name = "cmbMagazzino";
            this.cmbMagazzino.Size = new System.Drawing.Size(277, 21);
            this.cmbMagazzino.TabIndex = 13;
            this.cmbMagazzino.Tag = "bookingdetail.idstore?bookingdetailview.idstore";
            this.cmbMagazzino.ValueMember = "idstore";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 220);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Magazzino";
            // 
            // gboxListClass
            // 
            this.gboxListClass.Controls.Add(this.txtCodiceClass);
            this.gboxListClass.Controls.Add(this.chkListTitle);
            this.gboxListClass.Controls.Add(this.txtDescrListClass);
            this.gboxListClass.Controls.Add(this.btnListClassCode);
            this.gboxListClass.Location = new System.Drawing.Point(288, 220);
            this.gboxListClass.Name = "gboxListClass";
            this.gboxListClass.Size = new System.Drawing.Size(298, 106);
            this.gboxListClass.TabIndex = 12;
            this.gboxListClass.TabStop = false;
            this.gboxListClass.Tag = "AutoManage.txtCodiceClass.tree";
            this.gboxListClass.Text = "Classificazione Merceologica";
            // 
            // txtCodiceClass
            // 
            this.txtCodiceClass.Location = new System.Drawing.Point(8, 74);
            this.txtCodiceClass.Name = "txtCodiceClass";
            this.txtCodiceClass.Size = new System.Drawing.Size(120, 20);
            this.txtCodiceClass.TabIndex = 3;
            this.txtCodiceClass.Tag = "listclass.codelistclass?bookingdetailview.codelistclass";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 22);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(200, 16);
            this.chkListTitle.TabIndex = 1;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // txtDescrListClass
            // 
            this.txtDescrListClass.Location = new System.Drawing.Point(133, 44);
            this.txtDescrListClass.Multiline = true;
            this.txtDescrListClass.Name = "txtDescrListClass";
            this.txtDescrListClass.ReadOnly = true;
            this.txtDescrListClass.Size = new System.Drawing.Size(159, 53);
            this.txtDescrListClass.TabIndex = 0;
            this.txtDescrListClass.TabStop = false;
            this.txtDescrListClass.Tag = "listclass.title";
            // 
            // btnListClassCode
            // 
            this.btnListClassCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnListClassCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListClassCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnListClassCode.Location = new System.Drawing.Point(8, 44);
            this.btnListClassCode.Name = "btnListClassCode";
            this.btnListClassCode.Size = new System.Drawing.Size(120, 25);
            this.btnListClassCode.TabIndex = 2;
            this.btnListClassCode.TabStop = false;
            this.btnListClassCode.Tag = "";
            this.btnListClassCode.Text = "Class.Merceologica";
            this.btnListClassCode.UseVisualStyleBackColor = false;
            this.btnListClassCode.Click += new System.EventHandler(this.btnListClassCode_Click);
            // 
            // grpArticolo
            // 
            this.grpArticolo.Controls.Add(this.label1);
            this.grpArticolo.Controls.Add(this.txtPrice);
            this.grpArticolo.Controls.Add(this.pbox);
            this.grpArticolo.Controls.Add(this.lblNumber);
            this.grpArticolo.Controls.Add(this.txtNumber);
            this.grpArticolo.Controls.Add(this.txtDesArt);
            this.grpArticolo.Controls.Add(this.lblDesArt);
            this.grpArticolo.Controls.Add(this.txtCodArt);
            this.grpArticolo.Controls.Add(this.lblCodArt);
            this.grpArticolo.Location = new System.Drawing.Point(0, 19);
            this.grpArticolo.Name = "grpArticolo";
            this.grpArticolo.Size = new System.Drawing.Size(586, 194);
            this.grpArticolo.TabIndex = 10;
            this.grpArticolo.TabStop = false;
            this.grpArticolo.Text = "Articolo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(169, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Prezzo unitario";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(251, 59);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 32;
            this.txtPrice.Tag = "bookingdetail.price?bookingdetailview.price.C";
            // 
            // pbox
            // 
            this.pbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbox.Location = new System.Drawing.Point(386, 11);
            this.pbox.Name = "pbox";
            this.pbox.Size = new System.Drawing.Size(194, 177);
            this.pbox.TabIndex = 31;
            this.pbox.TabStop = false;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Location = new System.Drawing.Point(198, 37);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(47, 13);
            this.lblNumber.TabIndex = 2;
            this.lblNumber.Text = "Quantità";
            // 
            // txtNumber
            // 
            this.txtNumber.Location = new System.Drawing.Point(251, 34);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 20);
            this.txtNumber.TabIndex = 3;
            this.txtNumber.Tag = "bookingdetail.number.n?bookingdetailview.number.N";
            // 
            // txtDesArt
            // 
            this.txtDesArt.Location = new System.Drawing.Point(10, 85);
            this.txtDesArt.Multiline = true;
            this.txtDesArt.Name = "txtDesArt";
            this.txtDesArt.Size = new System.Drawing.Size(341, 93);
            this.txtDesArt.TabIndex = 5;
            this.txtDesArt.Tag = "list.description?bookingdetailview.list";
            // 
            // lblDesArt
            // 
            this.lblDesArt.AutoSize = true;
            this.lblDesArt.Location = new System.Drawing.Point(6, 69);
            this.lblDesArt.Name = "lblDesArt";
            this.lblDesArt.Size = new System.Drawing.Size(62, 13);
            this.lblDesArt.TabIndex = 4;
            this.lblDesArt.Text = "Descrizione";
            // 
            // txtCodArt
            // 
            this.txtCodArt.Location = new System.Drawing.Point(53, 34);
            this.txtCodArt.Name = "txtCodArt";
            this.txtCodArt.Size = new System.Drawing.Size(100, 20);
            this.txtCodArt.TabIndex = 1;
            this.txtCodArt.Tag = "list.intcode?bookingdetailview.intcode";
            // 
            // lblCodArt
            // 
            this.lblCodArt.AutoSize = true;
            this.lblCodArt.Location = new System.Drawing.Point(7, 37);
            this.lblCodArt.Name = "lblCodArt";
            this.lblCodArt.Size = new System.Drawing.Size(40, 13);
            this.lblCodArt.TabIndex = 0;
            this.lblCodArt.Text = "Codice";
            // 
            // tabPageAnalitico
            // 
            this.tabPageAnalitico.Controls.Add(this.gboxclass3);
            this.tabPageAnalitico.Controls.Add(this.gboxclass2);
            this.tabPageAnalitico.Controls.Add(this.gboxclass1);
            this.tabPageAnalitico.Location = new System.Drawing.Point(4, 22);
            this.tabPageAnalitico.Name = "tabPageAnalitico";
            this.tabPageAnalitico.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAnalitico.Size = new System.Drawing.Size(596, 354);
            this.tabPageAnalitico.TabIndex = 1;
            this.tabPageAnalitico.Text = "Analitico";
            this.tabPageAnalitico.UseVisualStyleBackColor = true;
            // 
            // gboxclass3
            // 
            this.gboxclass3.Controls.Add(this.btnCodice3);
            this.gboxclass3.Controls.Add(this.txtDenom3);
            this.gboxclass3.Controls.Add(this.txtCodice3);
            this.gboxclass3.Location = new System.Drawing.Point(15, 159);
            this.gboxclass3.Name = "gboxclass3";
            this.gboxclass3.Size = new System.Drawing.Size(337, 64);
            this.gboxclass3.TabIndex = 2;
            this.gboxclass3.TabStop = false;
            this.gboxclass3.Tag = "AutoManage.txtCodice3.treeclassmovimenti";
            this.gboxclass3.Text = "Classificazione 3";
            // 
            // btnCodice3
            // 
            this.btnCodice3.Location = new System.Drawing.Point(8, 16);
            this.btnCodice3.Name = "btnCodice3";
            this.btnCodice3.Size = new System.Drawing.Size(88, 23);
            this.btnCodice3.TabIndex = 4;
            this.btnCodice3.Tag = "manage.sorting3.tree";
            this.btnCodice3.Text = "Codice";
            this.btnCodice3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom3
            // 
            this.txtDenom3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom3.Location = new System.Drawing.Point(128, 8);
            this.txtDenom3.Multiline = true;
            this.txtDenom3.Name = "txtDenom3";
            this.txtDenom3.ReadOnly = true;
            this.txtDenom3.Size = new System.Drawing.Size(201, 52);
            this.txtDenom3.TabIndex = 3;
            this.txtDenom3.TabStop = false;
            this.txtDenom3.Tag = "sorting3.description";
            // 
            // txtCodice3
            // 
            this.txtCodice3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice3.Location = new System.Drawing.Point(8, 40);
            this.txtCodice3.Name = "txtCodice3";
            this.txtCodice3.Size = new System.Drawing.Size(112, 20);
            this.txtCodice3.TabIndex = 4;
            this.txtCodice3.Tag = "sorting3.sortcode?mandatedetailview.sortcode3";
            // 
            // gboxclass2
            // 
            this.gboxclass2.Controls.Add(this.btnCodice2);
            this.gboxclass2.Controls.Add(this.txtDenom2);
            this.gboxclass2.Controls.Add(this.txtCodice2);
            this.gboxclass2.Location = new System.Drawing.Point(15, 89);
            this.gboxclass2.Name = "gboxclass2";
            this.gboxclass2.Size = new System.Drawing.Size(336, 64);
            this.gboxclass2.TabIndex = 1;
            this.gboxclass2.TabStop = false;
            this.gboxclass2.Tag = "AutoManage.txtCodice2.treeclassmovimenti";
            this.gboxclass2.Text = "Classificazione 2";
            // 
            // btnCodice2
            // 
            this.btnCodice2.Location = new System.Drawing.Point(8, 16);
            this.btnCodice2.Name = "btnCodice2";
            this.btnCodice2.Size = new System.Drawing.Size(88, 23);
            this.btnCodice2.TabIndex = 4;
            this.btnCodice2.Tag = "manage.sorting2.tree";
            this.btnCodice2.Text = "Codice";
            this.btnCodice2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom2
            // 
            this.txtDenom2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom2.Location = new System.Drawing.Point(128, 8);
            this.txtDenom2.Multiline = true;
            this.txtDenom2.Name = "txtDenom2";
            this.txtDenom2.ReadOnly = true;
            this.txtDenom2.Size = new System.Drawing.Size(200, 52);
            this.txtDenom2.TabIndex = 3;
            this.txtDenom2.TabStop = false;
            this.txtDenom2.Tag = "sorting2.description";
            // 
            // txtCodice2
            // 
            this.txtCodice2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice2.Location = new System.Drawing.Point(8, 40);
            this.txtCodice2.Name = "txtCodice2";
            this.txtCodice2.Size = new System.Drawing.Size(112, 20);
            this.txtCodice2.TabIndex = 2;
            this.txtCodice2.Tag = "sorting2.sortcode?mandatedetailview.sortcode2";
            // 
            // gboxclass1
            // 
            this.gboxclass1.Controls.Add(this.btnCodice1);
            this.gboxclass1.Controls.Add(this.txtDenom1);
            this.gboxclass1.Controls.Add(this.txtCodice1);
            this.gboxclass1.Location = new System.Drawing.Point(15, 19);
            this.gboxclass1.Name = "gboxclass1";
            this.gboxclass1.Size = new System.Drawing.Size(336, 64);
            this.gboxclass1.TabIndex = 0;
            this.gboxclass1.TabStop = false;
            this.gboxclass1.Tag = "AutoManage.txtCodice1.treeclassmovimenti";
            this.gboxclass1.Text = "Classificazione 1";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(8, 16);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting1.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(128, 8);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(200, 52);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting1.description";
            // 
            // txtCodice1
            // 
            this.txtCodice1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice1.Location = new System.Drawing.Point(8, 40);
            this.txtCodice1.Name = "txtCodice1";
            this.txtCodice1.Size = new System.Drawing.Size(112, 20);
            this.txtCodice1.TabIndex = 2;
            this.txtCodice1.Tag = "sorting1.sortcode?mandatedetailview.sortcode1";
            // 
            // Frm_bookingdetail_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 447);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtnbooking);
            this.Controls.Add(this.txtybooking);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.lblEsercizio);
            this.Name = "Frm_bookingdetail_default";
            this.Text = "Frm_bookingdetail_default";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPagePrincipale.ResumeLayout(false);
            this.tabPagePrincipale.PerformLayout();
            this.gboxListClass.ResumeLayout(false);
            this.gboxListClass.PerformLayout();
            this.grpArticolo.ResumeLayout(false);
            this.grpArticolo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
            this.tabPageAnalitico.ResumeLayout(false);
            this.gboxclass3.ResumeLayout(false);
            this.gboxclass3.PerformLayout();
            this.gboxclass2.ResumeLayout(false);
            this.gboxclass2.PerformLayout();
            this.gboxclass1.ResumeLayout(false);
            this.gboxclass1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbidman;
        private System.Windows.Forms.TextBox txtnbooking;
        private System.Windows.Forms.TextBox txtybooking;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.Label lblEsercizio;
        public vistaForm DS;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPagePrincipale;
        private System.Windows.Forms.CheckBox chkAuthorizeed;
        private System.Windows.Forms.ComboBox cmbMagazzino;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gboxListClass;
        private System.Windows.Forms.TextBox txtCodiceClass;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.TextBox txtDescrListClass;
        private System.Windows.Forms.Button btnListClassCode;
        private System.Windows.Forms.GroupBox grpArticolo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.TextBox txtNumber;
        private System.Windows.Forms.TextBox txtDesArt;
        private System.Windows.Forms.Label lblDesArt;
        private System.Windows.Forms.TextBox txtCodArt;
        private System.Windows.Forms.Label lblCodArt;
        private System.Windows.Forms.TabPage tabPageAnalitico;
        public System.Windows.Forms.GroupBox gboxclass3;
        public System.Windows.Forms.Button btnCodice3;
        private System.Windows.Forms.TextBox txtDenom3;
        private System.Windows.Forms.TextBox txtCodice3;
        public System.Windows.Forms.GroupBox gboxclass2;
        public System.Windows.Forms.Button btnCodice2;
        private System.Windows.Forms.TextBox txtDenom2;
        private System.Windows.Forms.TextBox txtCodice2;
        public System.Windows.Forms.GroupBox gboxclass1;
        public System.Windows.Forms.Button btnCodice1;
        private System.Windows.Forms.TextBox txtDenom1;
        private System.Windows.Forms.TextBox txtCodice1;
        private System.Windows.Forms.TextBox txtEvaso;
        private System.Windows.Forms.Label label2;
    }
}
