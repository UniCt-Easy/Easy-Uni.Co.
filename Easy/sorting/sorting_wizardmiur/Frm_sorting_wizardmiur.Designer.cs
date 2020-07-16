/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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

namespace sorting_wizardmiur {
    partial class Frm_sorting_wizardmiur {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_sorting_wizardmiur));
            this.chkTotPagati = new System.Windows.Forms.CheckBox();
            this.chkParzPagati = new System.Windows.Forms.CheckBox();
            this.rbtProporzione = new System.Windows.Forms.RadioButton();
            this.rbtSoloSiope = new System.Windows.Forms.RadioButton();
            this.chkNonPagati = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtSiopeEBilancio = new System.Windows.Forms.RadioButton();
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.btnDeselezionaTutto = new System.Windows.Forms.Button();
            this.btnSelezionaTutto = new System.Windows.Forms.Button();
            this.gridImpegni = new System.Windows.Forms.DataGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.chkAnniSuccessivi = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtFiltroDenBilancio = new System.Windows.Forms.TextBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.SubEntity_comboUPB = new System.Windows.Forms.ComboBox();
            this.DS = new sorting_wizardmiur.vistaForm();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxBilAnnuale = new System.Windows.Forms.GroupBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.txtCodiceBilancio = new System.Windows.Forms.TextBox();
            this.txtDenominazioneBilancio = new System.Windows.Forms.TextBox();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.gridImpClassSpesa = new System.Windows.Forms.DataGrid();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.tabController.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImpegni)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.gboxBilAnnuale.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImpClassSpesa)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkTotPagati
            // 
            this.chkTotPagati.AutoSize = true;
            this.chkTotPagati.Checked = true;
            this.chkTotPagati.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTotPagati.Location = new System.Drawing.Point(23, 45);
            this.chkTotPagati.Name = "chkTotPagati";
            this.chkTotPagati.Size = new System.Drawing.Size(452, 17);
            this.chkTotPagati.TabIndex = 3;
            this.chkTotPagati.Text = "Movimenti totalmente pagati (da classificare in base ai codici siope imputati in " +
                "ultima fase)";
            this.chkTotPagati.UseVisualStyleBackColor = true;
            // 
            // chkParzPagati
            // 
            this.chkParzPagati.AutoSize = true;
            this.chkParzPagati.Checked = true;
            this.chkParzPagati.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkParzPagati.Location = new System.Drawing.Point(12, 19);
            this.chkParzPagati.Name = "chkParzPagati";
            this.chkParzPagati.Size = new System.Drawing.Size(171, 17);
            this.chkParzPagati.TabIndex = 4;
            this.chkParzPagati.Text = "Movimenti parzialmente pagati";
            this.chkParzPagati.UseVisualStyleBackColor = true;
            // 
            // rbtProporzione
            // 
            this.rbtProporzione.AutoSize = true;
            this.rbtProporzione.Checked = true;
            this.rbtProporzione.Location = new System.Drawing.Point(34, 42);
            this.rbtProporzione.Name = "rbtProporzione";
            this.rbtProporzione.Size = new System.Drawing.Size(439, 17);
            this.rbtProporzione.TabIndex = 5;
            this.rbtProporzione.TabStop = true;
            this.rbtProporzione.Text = "Il movimento sarà interamente classificato (in proporzione ai codici siope in ult" +
                "ima fase)";
            this.rbtProporzione.UseVisualStyleBackColor = true;
            // 
            // rbtSoloSiope
            // 
            this.rbtSoloSiope.AutoSize = true;
            this.rbtSoloSiope.Location = new System.Drawing.Point(34, 65);
            this.rbtSoloSiope.Name = "rbtSoloSiope";
            this.rbtSoloSiope.Size = new System.Drawing.Size(303, 17);
            this.rbtSoloSiope.TabIndex = 6;
            this.rbtSoloSiope.Text = "Il movimento sarà classificato solo per l\'importo già pagato";
            this.rbtSoloSiope.UseVisualStyleBackColor = true;
            // 
            // chkNonPagati
            // 
            this.chkNonPagati.AutoSize = true;
            this.chkNonPagati.Checked = true;
            this.chkNonPagati.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNonPagati.Location = new System.Drawing.Point(23, 209);
            this.chkNonPagati.Name = "chkNonPagati";
            this.chkNonPagati.Size = new System.Drawing.Size(410, 17);
            this.chkNonPagati.TabIndex = 7;
            this.chkNonPagati.Text = "Movimenti non pagati (da classificare in base ai codici siope sulla voce di bilan" +
                "cio)";
            this.chkNonPagati.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Selezionare i movimenti in prima fase di spesa che si intende classificare in aut" +
                "omatico:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rbtSiopeEBilancio);
            this.groupBox1.Controls.Add(this.chkParzPagati);
            this.groupBox1.Controls.Add(this.rbtProporzione);
            this.groupBox1.Controls.Add(this.rbtSoloSiope);
            this.groupBox1.Location = new System.Drawing.Point(11, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(771, 135);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbtSiopeEBilancio
            // 
            this.rbtSiopeEBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtSiopeEBilancio.Location = new System.Drawing.Point(34, 88);
            this.rbtSiopeEBilancio.Name = "rbtSiopeEBilancio";
            this.rbtSiopeEBilancio.Size = new System.Drawing.Size(731, 35);
            this.rbtSiopeEBilancio.TabIndex = 7;
            this.rbtSiopeEBilancio.TabStop = true;
            this.rbtSiopeEBilancio.Text = "Il movimento sarà interamente classificato (in base ai codici siope in ultima fas" +
                "e per l\'importo pagato ed in base alla voce di bilancio per la parte rimanente)";
            this.rbtSiopeEBilancio.UseVisualStyleBackColor = true;
            // 
            // tabController
            // 
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(19, 2);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 2;
            this.tabController.SelectedTab = this.tabPage3;
            this.tabController.Size = new System.Drawing.Size(791, 529);
            this.tabController.TabIndex = 13;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2,
            this.tabPage3,
            this.tabPage4});
            // 
            // tabPage3
            // 
            this.tabPage3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPage3.Controls.Add(this.btnDeselezionaTutto);
            this.tabPage3.Controls.Add(this.btnSelezionaTutto);
            this.tabPage3.Controls.Add(this.gridImpegni);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Location = new System.Drawing.Point(0, 0);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(791, 504);
            this.tabPage3.TabIndex = 5;
            this.tabPage3.Title = "Pagina 3 di 4";
            // 
            // btnDeselezionaTutto
            // 
            this.btnDeselezionaTutto.AutoSize = true;
            this.btnDeselezionaTutto.Location = new System.Drawing.Point(104, 16);
            this.btnDeselezionaTutto.Name = "btnDeselezionaTutto";
            this.btnDeselezionaTutto.Size = new System.Drawing.Size(101, 23);
            this.btnDeselezionaTutto.TabIndex = 50;
            this.btnDeselezionaTutto.Text = "Deseleziona tutto";
            this.btnDeselezionaTutto.UseVisualStyleBackColor = true;
            this.btnDeselezionaTutto.Click += new System.EventHandler(this.btnDeselezionaTutto_Click);
            // 
            // btnSelezionaTutto
            // 
            this.btnSelezionaTutto.AutoSize = true;
            this.btnSelezionaTutto.Location = new System.Drawing.Point(10, 16);
            this.btnSelezionaTutto.Name = "btnSelezionaTutto";
            this.btnSelezionaTutto.Size = new System.Drawing.Size(89, 23);
            this.btnSelezionaTutto.TabIndex = 49;
            this.btnSelezionaTutto.Text = "Seleziona tutto";
            this.btnSelezionaTutto.UseVisualStyleBackColor = true;
            this.btnSelezionaTutto.Click += new System.EventHandler(this.btnSelezionaTutto_Click);
            // 
            // gridImpegni
            // 
            this.gridImpegni.AllowNavigation = false;
            this.gridImpegni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridImpegni.DataMember = "";
            this.gridImpegni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridImpegni.Location = new System.Drawing.Point(9, 48);
            this.gridImpegni.Name = "gridImpegni";
            this.gridImpegni.Size = new System.Drawing.Size(782, 453);
            this.gridImpegni.TabIndex = 42;
            this.gridImpegni.Tag = "DS.expenseview.default";
            this.gridImpegni.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridImpegni_MouseClick);
            this.gridImpegni.CurrentCellChanged += new System.EventHandler(this.gridImpegni_CurrentCellChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(204, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(558, 13);
            this.label5.TabIndex = 45;
            this.label5.Text = "Tenere premuto il tasto CTRL o MAIUSC e contemporaneamente cliccare con il mouse " +
                "per selezionare più movimenti";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(791, 504);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Title = "Pagina 1 di 4";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(12, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(770, 486);
            this.label2.TabIndex = 0;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkAnniSuccessivi);
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.chkTotPagati);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.chkNonPagati);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(791, 504);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Title = "Pagina 2 di 4";
            // 
            // chkAnniSuccessivi
            // 
            this.chkAnniSuccessivi.AutoSize = true;
            this.chkAnniSuccessivi.Checked = true;
            this.chkAnniSuccessivi.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAnniSuccessivi.Location = new System.Drawing.Point(23, 239);
            this.chkAnniSuccessivi.Name = "chkAnniSuccessivi";
            this.chkAnniSuccessivi.Size = new System.Drawing.Size(491, 17);
            this.chkAnniSuccessivi.TabIndex = 13;
            this.chkAnniSuccessivi.Text = "Trasferisci  anche le classificazioni effettuate sui pagamenti degli anni success" +
                "ivi a quello corrente";
            this.chkAnniSuccessivi.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.gboxUPB);
            this.groupBox2.Controls.Add(this.gboxBilAnnuale);
            this.groupBox2.Location = new System.Drawing.Point(23, 283);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 190);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ulteriori filtri sul bilancio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtFiltroDenBilancio);
            this.groupBox3.Location = new System.Drawing.Point(6, 133);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 51);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "La voce di bilancio deve contenere la seguente stringa:";
            // 
            // txtFiltroDenBilancio
            // 
            this.txtFiltroDenBilancio.Location = new System.Drawing.Point(8, 20);
            this.txtFiltroDenBilancio.Name = "txtFiltroDenBilancio";
            this.txtFiltroDenBilancio.Size = new System.Drawing.Size(298, 21);
            this.txtFiltroDenBilancio.TabIndex = 0;
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.SubEntity_comboUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(6, 20);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(312, 56);
            this.gboxUPB.TabIndex = 10;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "";
            // 
            // SubEntity_comboUPB
            // 
            this.SubEntity_comboUPB.DataSource = this.DS.upb;
            this.SubEntity_comboUPB.DisplayMember = "codeupb";
            this.SubEntity_comboUPB.Location = new System.Drawing.Point(8, 32);
            this.SubEntity_comboUPB.Name = "SubEntity_comboUPB";
            this.SubEntity_comboUPB.Size = new System.Drawing.Size(128, 21);
            this.SubEntity_comboUPB.TabIndex = 1;
            this.SubEntity_comboUPB.Tag = "expenseview.idupb";
            this.SubEntity_comboUPB.ValueMember = "idupb";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(136, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(168, 44);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 8);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            this.btnUPBCode.Click += new System.EventHandler(this.btnUPBCode_Click);
            // 
            // gboxBilAnnuale
            // 
            this.gboxBilAnnuale.Controls.Add(this.btnBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtCodiceBilancio);
            this.gboxBilAnnuale.Controls.Add(this.txtDenominazioneBilancio);
            this.gboxBilAnnuale.Location = new System.Drawing.Point(6, 75);
            this.gboxBilAnnuale.Name = "gboxBilAnnuale";
            this.gboxBilAnnuale.Size = new System.Drawing.Size(312, 58);
            this.gboxBilAnnuale.TabIndex = 11;
            this.gboxBilAnnuale.TabStop = false;
            this.gboxBilAnnuale.Tag = "AutoManage.txtCodiceBilancio.treesupb.(idupb=\'0001\')";
            // 
            // btnBilancio
            // 
            this.btnBilancio.BackColor = System.Drawing.SystemColors.Control;
            this.btnBilancio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBilancio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(8, 8);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(112, 20);
            this.btnBilancio.TabIndex = 1;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.UseVisualStyleBackColor = false;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // txtCodiceBilancio
            // 
            this.txtCodiceBilancio.Location = new System.Drawing.Point(8, 31);
            this.txtCodiceBilancio.Name = "txtCodiceBilancio";
            this.txtCodiceBilancio.Size = new System.Drawing.Size(112, 21);
            this.txtCodiceBilancio.TabIndex = 2;
            this.txtCodiceBilancio.Tag = "finview.codefin?expenseview.codefin";
            // 
            // txtDenominazioneBilancio
            // 
            this.txtDenominazioneBilancio.Location = new System.Drawing.Point(128, 8);
            this.txtDenominazioneBilancio.Multiline = true;
            this.txtDenominazioneBilancio.Name = "txtDenominazioneBilancio";
            this.txtDenominazioneBilancio.ReadOnly = true;
            this.txtDenominazioneBilancio.Size = new System.Drawing.Size(176, 42);
            this.txtDenominazioneBilancio.TabIndex = 3;
            this.txtDenominazioneBilancio.TabStop = false;
            this.txtDenominazioneBilancio.Tag = "finview.title";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label6);
            this.tabPage4.Controls.Add(this.gridImpClassSpesa);
            this.tabPage4.Location = new System.Drawing.Point(0, 0);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Selected = false;
            this.tabPage4.Size = new System.Drawing.Size(791, 504);
            this.tabPage4.TabIndex = 6;
            this.tabPage4.Title = "Pagina 4 di 4";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(206, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Saranno create le seguenti classificazioni:";
            // 
            // gridImpClassSpesa
            // 
            this.gridImpClassSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridImpClassSpesa.DataMember = "";
            this.gridImpClassSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridImpClassSpesa.Location = new System.Drawing.Point(3, 23);
            this.gridImpClassSpesa.Name = "gridImpClassSpesa";
            this.gridImpClassSpesa.Size = new System.Drawing.Size(785, 477);
            this.gridImpClassSpesa.TabIndex = 0;
            this.gridImpClassSpesa.Tag = "DS.expensesorted.default.default";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(511, 543);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 14;
            this.btnBack.Text = "Indietro";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(603, 543);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 15;
            this.btnNext.Text = "Avanti";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(728, 543);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Annulla";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(2, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 535);
            this.panel1.TabIndex = 17;
            // 
            // Frm_sorting_wizardmiur
            // 
            this.AcceptButton = this.btnNext;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(829, 573);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "Frm_sorting_wizardmiur";
            this.Text = "Frm_expsensesorted_wizardmiur";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabController.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImpegni)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.gboxBilAnnuale.ResumeLayout(false);
            this.gboxBilAnnuale.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridImpClassSpesa)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkTotPagati;
        private System.Windows.Forms.CheckBox chkParzPagati;
        private System.Windows.Forms.RadioButton rbtProporzione;
        private System.Windows.Forms.RadioButton rbtSoloSiope;
        private System.Windows.Forms.CheckBox chkNonPagati;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtSiopeEBilancio;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label2;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private System.Windows.Forms.DataGrid gridImpegni;
        private System.Windows.Forms.Label label5;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGrid gridImpClassSpesa;
        private System.Windows.Forms.GroupBox gboxUPB;
        private System.Windows.Forms.ComboBox SubEntity_comboUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.GroupBox gboxBilAnnuale;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.TextBox txtCodiceBilancio;
        private System.Windows.Forms.TextBox txtDenominazioneBilancio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtFiltroDenBilancio;
        public sorting_wizardmiur.vistaForm DS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDeselezionaTutto;
        private System.Windows.Forms.Button btnSelezionaTutto;
        private System.Windows.Forms.CheckBox chkAnniSuccessivi;
    }
}