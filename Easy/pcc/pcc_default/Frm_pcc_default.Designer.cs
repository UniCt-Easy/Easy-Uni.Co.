/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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

﻿namespace pcc_default {
    partial class Frm_pcc_default {
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
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.grpRigeneraFile = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.grpAnagrafica = new System.Windows.Forms.GroupBox();
            this.txtAnagrafica = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPercorso = new System.Windows.Forms.TextBox();
            this.btnCartella = new System.Windows.Forms.Button();
            this.btnRigeneraFile = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tabAttributi = new System.Windows.Forms.TabPage();
            this.gboxclass05 = new System.Windows.Forms.GroupBox();
            this.txtCodice05 = new System.Windows.Forms.TextBox();
            this.btnCodice05 = new System.Windows.Forms.Button();
            this.txtDenom05 = new System.Windows.Forms.TextBox();
            this.gboxclass04 = new System.Windows.Forms.GroupBox();
            this.txtCodice04 = new System.Windows.Forms.TextBox();
            this.btnCodice04 = new System.Windows.Forms.Button();
            this.txtDenom04 = new System.Windows.Forms.TextBox();
            this.gboxclass03 = new System.Windows.Forms.GroupBox();
            this.txtCodice03 = new System.Windows.Forms.TextBox();
            this.btnCodice03 = new System.Windows.Forms.Button();
            this.txtDenom03 = new System.Windows.Forms.TextBox();
            this.gboxclass02 = new System.Windows.Forms.GroupBox();
            this.txtCodice02 = new System.Windows.Forms.TextBox();
            this.btnCodice02 = new System.Windows.Forms.Button();
            this.txtDenom02 = new System.Windows.Forms.TextBox();
            this.gboxclass01 = new System.Windows.Forms.GroupBox();
            this.txtCodice01 = new System.Windows.Forms.TextBox();
            this.btnCodice01 = new System.Windows.Forms.Button();
            this.txtDenom01 = new System.Windows.Forms.TextBox();
            this.tabScadenza = new System.Windows.Forms.TabPage();
            this.btnEliminaCS = new System.Windows.Forms.Button();
            this.dataGrid3 = new System.Windows.Forms.DataGrid();
            this.tabPagamenti = new System.Windows.Forms.TabPage();
            this.btnEliminaCP = new System.Windows.Forms.Button();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.tabContabilizzazioni = new System.Windows.Forms.TabPage();
            this.btnEliminaCO = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabInvio = new System.Windows.Forms.TabPage();
            this.btnEliminaIN = new System.Windows.Forms.Button();
            this.gridFatture = new System.Windows.Forms.DataGrid();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabImportazione = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRigenera = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSalvaFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeFileRisposta = new System.Windows.Forms.TextBox();
            this.btnImportaFileEsito = new System.Windows.Forms.Button();
            this.DS = new pcc_default.VistaForm();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.grpRigeneraFile.SuspendLayout();
            this.grpAnagrafica.SuspendLayout();
            this.tabAttributi.SuspendLayout();
            this.gboxclass05.SuspendLayout();
            this.gboxclass04.SuspendLayout();
            this.gboxclass03.SuspendLayout();
            this.gboxclass02.SuspendLayout();
            this.gboxclass01.SuspendLayout();
            this.tabScadenza.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).BeginInit();
            this.tabPagamenti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.tabContabilizzazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabInvio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridFatture)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabImportazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(62, 14);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(65, 20);
            this.textBox3.TabIndex = 29;
            this.textBox3.Tag = "pcc.idpcc";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "Numero";
            // 
            // grpRigeneraFile
            // 
            this.grpRigeneraFile.Controls.Add(this.label1);
            this.grpRigeneraFile.Controls.Add(this.txtFilename);
            this.grpRigeneraFile.Controls.Add(this.grpAnagrafica);
            this.grpRigeneraFile.Controls.Add(this.label5);
            this.grpRigeneraFile.Controls.Add(this.txtPercorso);
            this.grpRigeneraFile.Controls.Add(this.btnCartella);
            this.grpRigeneraFile.Controls.Add(this.btnRigeneraFile);
            this.grpRigeneraFile.Location = new System.Drawing.Point(133, 12);
            this.grpRigeneraFile.Name = "grpRigeneraFile";
            this.grpRigeneraFile.Size = new System.Drawing.Size(476, 167);
            this.grpRigeneraFile.TabIndex = 45;
            this.grpRigeneraFile.TabStop = false;
            this.grpRigeneraFile.Text = "Rigenera file";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(260, 21);
            this.label1.TabIndex = 56;
            this.label1.Text = "Ultimo File generato";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(8, 137);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(356, 20);
            this.txtFilename.TabIndex = 55;
            this.txtFilename.Tag = "pcc.filename";
            // 
            // grpAnagrafica
            // 
            this.grpAnagrafica.Controls.Add(this.txtAnagrafica);
            this.grpAnagrafica.Location = new System.Drawing.Point(6, 19);
            this.grpAnagrafica.Name = "grpAnagrafica";
            this.grpAnagrafica.Size = new System.Drawing.Size(464, 43);
            this.grpAnagrafica.TabIndex = 54;
            this.grpAnagrafica.TabStop = false;
            this.grpAnagrafica.Tag = "AutoChoose.txtAnagrafica.default.(active=\'S\')";
            this.grpAnagrafica.Text = "Utente che trasmette il file (Inserire l\'utente della login al sito dalla PCC)";
            // 
            // txtAnagrafica
            // 
            this.txtAnagrafica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnagrafica.Location = new System.Drawing.Point(6, 16);
            this.txtAnagrafica.Name = "txtAnagrafica";
            this.txtAnagrafica.Size = new System.Drawing.Size(452, 20);
            this.txtAnagrafica.TabIndex = 1;
            this.txtAnagrafica.Tag = "registry.title?x";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(5, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(260, 21);
            this.label5.TabIndex = 53;
            this.label5.Text = "Indicare la cartella in cui salvare il file";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPercorso
            // 
            this.txtPercorso.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercorso.Location = new System.Drawing.Point(75, 86);
            this.txtPercorso.Name = "txtPercorso";
            this.txtPercorso.ReadOnly = true;
            this.txtPercorso.Size = new System.Drawing.Size(395, 20);
            this.txtPercorso.TabIndex = 52;
            // 
            // btnCartella
            // 
            this.btnCartella.AutoSize = true;
            this.btnCartella.Location = new System.Drawing.Point(6, 86);
            this.btnCartella.Name = "btnCartella";
            this.btnCartella.Size = new System.Drawing.Size(63, 25);
            this.btnCartella.TabIndex = 51;
            this.btnCartella.Text = "Cartella";
            this.btnCartella.UseVisualStyleBackColor = true;
            this.btnCartella.Click += new System.EventHandler(this.btnCartella_Click);
            // 
            // btnRigeneraFile
            // 
            this.btnRigeneraFile.AutoSize = true;
            this.btnRigeneraFile.Location = new System.Drawing.Point(384, 135);
            this.btnRigeneraFile.Name = "btnRigeneraFile";
            this.btnRigeneraFile.Size = new System.Drawing.Size(87, 25);
            this.btnRigeneraFile.TabIndex = 50;
            this.btnRigeneraFile.Text = "Rigenera File";
            this.btnRigeneraFile.UseVisualStyleBackColor = true;
            this.btnRigeneraFile.Click += new System.EventHandler(this.btnRigeneraFile_Click);
            // 
            // tabAttributi
            // 
            this.tabAttributi.Controls.Add(this.gboxclass05);
            this.tabAttributi.Controls.Add(this.gboxclass04);
            this.tabAttributi.Controls.Add(this.gboxclass03);
            this.tabAttributi.Controls.Add(this.gboxclass02);
            this.tabAttributi.Controls.Add(this.gboxclass01);
            this.tabAttributi.Location = new System.Drawing.Point(4, 22);
            this.tabAttributi.Name = "tabAttributi";
            this.tabAttributi.Padding = new System.Windows.Forms.Padding(3);
            this.tabAttributi.Size = new System.Drawing.Size(597, 372);
            this.tabAttributi.TabIndex = 1;
            this.tabAttributi.Text = "Attributi";
            this.tabAttributi.UseVisualStyleBackColor = true;
            // 
            // gboxclass05
            // 
            this.gboxclass05.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass05.Controls.Add(this.txtCodice05);
            this.gboxclass05.Controls.Add(this.btnCodice05);
            this.gboxclass05.Controls.Add(this.txtDenom05);
            this.gboxclass05.Location = new System.Drawing.Point(7, 278);
            this.gboxclass05.Name = "gboxclass05";
            this.gboxclass05.Size = new System.Drawing.Size(447, 64);
            this.gboxclass05.TabIndex = 10;
            this.gboxclass05.TabStop = false;
            this.gboxclass05.Tag = "";
            this.gboxclass05.Text = "Classificazione 5";
            // 
            // txtCodice05
            // 
            this.txtCodice05.Location = new System.Drawing.Point(9, 38);
            this.txtCodice05.Name = "txtCodice05";
            this.txtCodice05.Size = new System.Drawing.Size(219, 20);
            this.txtCodice05.TabIndex = 6;
            // 
            // btnCodice05
            // 
            this.btnCodice05.Location = new System.Drawing.Point(8, 16);
            this.btnCodice05.Name = "btnCodice05";
            this.btnCodice05.Size = new System.Drawing.Size(88, 23);
            this.btnCodice05.TabIndex = 4;
            this.btnCodice05.Tag = "manage.sorting05.tree";
            this.btnCodice05.Text = "Codice";
            this.btnCodice05.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom05
            // 
            this.txtDenom05.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom05.Location = new System.Drawing.Point(234, 8);
            this.txtDenom05.Multiline = true;
            this.txtDenom05.Name = "txtDenom05";
            this.txtDenom05.ReadOnly = true;
            this.txtDenom05.Size = new System.Drawing.Size(205, 52);
            this.txtDenom05.TabIndex = 3;
            this.txtDenom05.TabStop = false;
            this.txtDenom05.Tag = "sorting05.description";
            // 
            // gboxclass04
            // 
            this.gboxclass04.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxclass04.Controls.Add(this.txtCodice04);
            this.gboxclass04.Controls.Add(this.btnCodice04);
            this.gboxclass04.Controls.Add(this.txtDenom04);
            this.gboxclass04.Location = new System.Drawing.Point(7, 211);
            this.gboxclass04.Name = "gboxclass04";
            this.gboxclass04.Size = new System.Drawing.Size(447, 64);
            this.gboxclass04.TabIndex = 9;
            this.gboxclass04.TabStop = false;
            this.gboxclass04.Tag = "";
            this.gboxclass04.Text = "Classificazione 4";
            // 
            // txtCodice04
            // 
            this.txtCodice04.Location = new System.Drawing.Point(9, 38);
            this.txtCodice04.Name = "txtCodice04";
            this.txtCodice04.Size = new System.Drawing.Size(219, 20);
            this.txtCodice04.TabIndex = 6;
            // 
            // btnCodice04
            // 
            this.btnCodice04.Location = new System.Drawing.Point(8, 16);
            this.btnCodice04.Name = "btnCodice04";
            this.btnCodice04.Size = new System.Drawing.Size(88, 23);
            this.btnCodice04.TabIndex = 4;
            this.btnCodice04.Tag = "manage.sorting04.tree";
            this.btnCodice04.Text = "Codice";
            this.btnCodice04.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom04
            // 
            this.txtDenom04.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom04.Location = new System.Drawing.Point(234, 12);
            this.txtDenom04.Multiline = true;
            this.txtDenom04.Name = "txtDenom04";
            this.txtDenom04.ReadOnly = true;
            this.txtDenom04.Size = new System.Drawing.Size(205, 46);
            this.txtDenom04.TabIndex = 3;
            this.txtDenom04.TabStop = false;
            this.txtDenom04.Tag = "sorting04.description";
            // 
            // gboxclass03
            // 
            this.gboxclass03.Controls.Add(this.txtCodice03);
            this.gboxclass03.Controls.Add(this.btnCodice03);
            this.gboxclass03.Controls.Add(this.txtDenom03);
            this.gboxclass03.Location = new System.Drawing.Point(7, 142);
            this.gboxclass03.Name = "gboxclass03";
            this.gboxclass03.Size = new System.Drawing.Size(465, 64);
            this.gboxclass03.TabIndex = 8;
            this.gboxclass03.TabStop = false;
            this.gboxclass03.Tag = "";
            this.gboxclass03.Text = "Classificazione 3";
            // 
            // txtCodice03
            // 
            this.txtCodice03.Location = new System.Drawing.Point(8, 38);
            this.txtCodice03.Name = "txtCodice03";
            this.txtCodice03.Size = new System.Drawing.Size(219, 20);
            this.txtCodice03.TabIndex = 6;
            // 
            // btnCodice03
            // 
            this.btnCodice03.Location = new System.Drawing.Point(8, 16);
            this.btnCodice03.Name = "btnCodice03";
            this.btnCodice03.Size = new System.Drawing.Size(88, 23);
            this.btnCodice03.TabIndex = 4;
            this.btnCodice03.Tag = "manage.sorting03.tree";
            this.btnCodice03.Text = "Codice";
            this.btnCodice03.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom03
            // 
            this.txtDenom03.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom03.Location = new System.Drawing.Point(233, 8);
            this.txtDenom03.Multiline = true;
            this.txtDenom03.Name = "txtDenom03";
            this.txtDenom03.ReadOnly = true;
            this.txtDenom03.Size = new System.Drawing.Size(224, 52);
            this.txtDenom03.TabIndex = 3;
            this.txtDenom03.TabStop = false;
            this.txtDenom03.Tag = "sorting03.description";
            // 
            // gboxclass02
            // 
            this.gboxclass02.Controls.Add(this.txtCodice02);
            this.gboxclass02.Controls.Add(this.btnCodice02);
            this.gboxclass02.Controls.Add(this.txtDenom02);
            this.gboxclass02.Location = new System.Drawing.Point(7, 73);
            this.gboxclass02.Name = "gboxclass02";
            this.gboxclass02.Size = new System.Drawing.Size(465, 64);
            this.gboxclass02.TabIndex = 7;
            this.gboxclass02.TabStop = false;
            this.gboxclass02.Tag = "";
            this.gboxclass02.Text = "Classificazione 2";
            // 
            // txtCodice02
            // 
            this.txtCodice02.Location = new System.Drawing.Point(8, 38);
            this.txtCodice02.Name = "txtCodice02";
            this.txtCodice02.Size = new System.Drawing.Size(219, 20);
            this.txtCodice02.TabIndex = 6;
            // 
            // btnCodice02
            // 
            this.btnCodice02.Location = new System.Drawing.Point(8, 16);
            this.btnCodice02.Name = "btnCodice02";
            this.btnCodice02.Size = new System.Drawing.Size(88, 23);
            this.btnCodice02.TabIndex = 4;
            this.btnCodice02.Tag = "manage.sorting02.tree";
            this.btnCodice02.Text = "Codice";
            this.btnCodice02.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom02
            // 
            this.txtDenom02.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom02.Location = new System.Drawing.Point(233, 8);
            this.txtDenom02.Multiline = true;
            this.txtDenom02.Name = "txtDenom02";
            this.txtDenom02.ReadOnly = true;
            this.txtDenom02.Size = new System.Drawing.Size(224, 52);
            this.txtDenom02.TabIndex = 3;
            this.txtDenom02.TabStop = false;
            this.txtDenom02.Tag = "sorting02.description";
            // 
            // gboxclass01
            // 
            this.gboxclass01.Controls.Add(this.txtCodice01);
            this.gboxclass01.Controls.Add(this.btnCodice01);
            this.gboxclass01.Controls.Add(this.txtDenom01);
            this.gboxclass01.Location = new System.Drawing.Point(7, 6);
            this.gboxclass01.Name = "gboxclass01";
            this.gboxclass01.Size = new System.Drawing.Size(465, 64);
            this.gboxclass01.TabIndex = 6;
            this.gboxclass01.TabStop = false;
            this.gboxclass01.Tag = "";
            this.gboxclass01.Text = "Classificazione 1";
            // 
            // txtCodice01
            // 
            this.txtCodice01.Location = new System.Drawing.Point(7, 40);
            this.txtCodice01.Name = "txtCodice01";
            this.txtCodice01.Size = new System.Drawing.Size(220, 20);
            this.txtCodice01.TabIndex = 5;
            // 
            // btnCodice01
            // 
            this.btnCodice01.Location = new System.Drawing.Point(8, 16);
            this.btnCodice01.Name = "btnCodice01";
            this.btnCodice01.Size = new System.Drawing.Size(88, 23);
            this.btnCodice01.TabIndex = 4;
            this.btnCodice01.Tag = "manage.sorting01.tree";
            this.btnCodice01.Text = "Codice";
            this.btnCodice01.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom01
            // 
            this.txtDenom01.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom01.Location = new System.Drawing.Point(233, 8);
            this.txtDenom01.Multiline = true;
            this.txtDenom01.Name = "txtDenom01";
            this.txtDenom01.ReadOnly = true;
            this.txtDenom01.Size = new System.Drawing.Size(224, 52);
            this.txtDenom01.TabIndex = 3;
            this.txtDenom01.TabStop = false;
            this.txtDenom01.Tag = "sorting01.description";
            // 
            // tabScadenza
            // 
            this.tabScadenza.Controls.Add(this.btnEliminaCS);
            this.tabScadenza.Controls.Add(this.dataGrid3);
            this.tabScadenza.Location = new System.Drawing.Point(4, 22);
            this.tabScadenza.Name = "tabScadenza";
            this.tabScadenza.Size = new System.Drawing.Size(597, 372);
            this.tabScadenza.TabIndex = 3;
            this.tabScadenza.Text = "Scadenze";
            this.tabScadenza.UseVisualStyleBackColor = true;
            // 
            // btnEliminaCS
            // 
            this.btnEliminaCS.Location = new System.Drawing.Point(7, 30);
            this.btnEliminaCS.Name = "btnEliminaCS";
            this.btnEliminaCS.Size = new System.Drawing.Size(86, 26);
            this.btnEliminaCS.TabIndex = 16;
            this.btnEliminaCS.TabStop = false;
            this.btnEliminaCS.Tag = "delete";
            this.btnEliminaCS.Text = "Elimina";
            // 
            // dataGrid3
            // 
            this.dataGrid3.AllowNavigation = false;
            this.dataGrid3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid3.DataMember = "";
            this.dataGrid3.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid3.Location = new System.Drawing.Point(99, 7);
            this.dataGrid3.Name = "dataGrid3";
            this.dataGrid3.Size = new System.Drawing.Size(492, 357);
            this.dataGrid3.TabIndex = 10;
            this.dataGrid3.TabStop = false;
            this.dataGrid3.Tag = "pccexpiringview.default";
            // 
            // tabPagamenti
            // 
            this.tabPagamenti.Controls.Add(this.btnEliminaCP);
            this.tabPagamenti.Controls.Add(this.dataGrid2);
            this.tabPagamenti.Location = new System.Drawing.Point(4, 22);
            this.tabPagamenti.Name = "tabPagamenti";
            this.tabPagamenti.Size = new System.Drawing.Size(597, 372);
            this.tabPagamenti.TabIndex = 2;
            this.tabPagamenti.Text = "Pagamenti";
            this.tabPagamenti.UseVisualStyleBackColor = true;
            // 
            // btnEliminaCP
            // 
            this.btnEliminaCP.Location = new System.Drawing.Point(3, 28);
            this.btnEliminaCP.Name = "btnEliminaCP";
            this.btnEliminaCP.Size = new System.Drawing.Size(86, 26);
            this.btnEliminaCP.TabIndex = 16;
            this.btnEliminaCP.TabStop = false;
            this.btnEliminaCP.Tag = "delete";
            this.btnEliminaCP.Text = "Elimina";
            // 
            // dataGrid2
            // 
            this.dataGrid2.AllowNavigation = false;
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(95, 7);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(496, 357);
            this.dataGrid2.TabIndex = 10;
            this.dataGrid2.TabStop = false;
            this.dataGrid2.Tag = "pccpaymentview.default";
            // 
            // tabContabilizzazioni
            // 
            this.tabContabilizzazioni.Controls.Add(this.btnEliminaCO);
            this.tabContabilizzazioni.Controls.Add(this.dataGrid1);
            this.tabContabilizzazioni.Location = new System.Drawing.Point(4, 22);
            this.tabContabilizzazioni.Name = "tabContabilizzazioni";
            this.tabContabilizzazioni.Size = new System.Drawing.Size(597, 372);
            this.tabContabilizzazioni.TabIndex = 4;
            this.tabContabilizzazioni.Text = "Contabilizzazioni";
            this.tabContabilizzazioni.UseVisualStyleBackColor = true;
            // 
            // btnEliminaCO
            // 
            this.btnEliminaCO.Location = new System.Drawing.Point(4, 29);
            this.btnEliminaCO.Name = "btnEliminaCO";
            this.btnEliminaCO.Size = new System.Drawing.Size(86, 26);
            this.btnEliminaCO.TabIndex = 15;
            this.btnEliminaCO.TabStop = false;
            this.btnEliminaCO.Tag = "delete";
            this.btnEliminaCO.Text = "Elimina";
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowNavigation = false;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(96, 7);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(495, 357);
            this.dataGrid1.TabIndex = 10;
            this.dataGrid1.TabStop = false;
            this.dataGrid1.Tag = "pccexpenseview.default";
            // 
            // tabInvio
            // 
            this.tabInvio.Controls.Add(this.btnEliminaIN);
            this.tabInvio.Controls.Add(this.gridFatture);
            this.tabInvio.Location = new System.Drawing.Point(4, 22);
            this.tabInvio.Name = "tabInvio";
            this.tabInvio.Padding = new System.Windows.Forms.Padding(3);
            this.tabInvio.Size = new System.Drawing.Size(597, 372);
            this.tabInvio.TabIndex = 0;
            this.tabInvio.Text = "Invio";
            this.tabInvio.UseVisualStyleBackColor = true;
            // 
            // btnEliminaIN
            // 
            this.btnEliminaIN.Location = new System.Drawing.Point(6, 30);
            this.btnEliminaIN.Name = "btnEliminaIN";
            this.btnEliminaIN.Size = new System.Drawing.Size(86, 26);
            this.btnEliminaIN.TabIndex = 16;
            this.btnEliminaIN.TabStop = false;
            this.btnEliminaIN.Tag = "delete";
            this.btnEliminaIN.Text = "Elimina";
            // 
            // gridFatture
            // 
            this.gridFatture.AllowNavigation = false;
            this.gridFatture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridFatture.DataMember = "";
            this.gridFatture.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridFatture.Location = new System.Drawing.Point(98, 9);
            this.gridFatture.Name = "gridFatture";
            this.gridFatture.Size = new System.Drawing.Size(493, 357);
            this.gridFatture.TabIndex = 9;
            this.gridFatture.TabStop = false;
            this.gridFatture.Tag = "pccsendview.default";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabInvio);
            this.tabControl1.Controls.Add(this.tabContabilizzazioni);
            this.tabControl1.Controls.Add(this.tabPagamenti);
            this.tabControl1.Controls.Add(this.tabScadenza);
            this.tabControl1.Controls.Add(this.tabAttributi);
            this.tabControl1.Controls.Add(this.tabImportazione);
            this.tabControl1.Location = new System.Drawing.Point(9, 185);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 398);
            this.tabControl1.TabIndex = 30;
            // 
            // tabImportazione
            // 
            this.tabImportazione.Controls.Add(this.label4);
            this.tabImportazione.Controls.Add(this.btnRigenera);
            this.tabImportazione.Controls.Add(this.label3);
            this.tabImportazione.Controls.Add(this.btnSalvaFile);
            this.tabImportazione.Controls.Add(this.label2);
            this.tabImportazione.Controls.Add(this.txtNomeFileRisposta);
            this.tabImportazione.Controls.Add(this.btnImportaFileEsito);
            this.tabImportazione.Location = new System.Drawing.Point(4, 22);
            this.tabImportazione.Name = "tabImportazione";
            this.tabImportazione.Size = new System.Drawing.Size(597, 372);
            this.tabImportazione.TabIndex = 5;
            this.tabImportazione.Text = "Importa Esito";
            this.tabImportazione.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 300);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(408, 13);
            this.label4.TabIndex = 53;
            this.label4.Text = "Genera un file che sarà quello usato per il prossimo confronto, a solo scopo di v" +
    "erifica";
            // 
            // btnRigenera
            // 
            this.btnRigenera.Location = new System.Drawing.Point(17, 316);
            this.btnRigenera.Name = "btnRigenera";
            this.btnRigenera.Size = new System.Drawing.Size(97, 23);
            this.btnRigenera.TabIndex = 52;
            this.btnRigenera.Text = "Salva file";
            this.btnRigenera.UseVisualStyleBackColor = true;
            this.btnRigenera.Click += new System.EventHandler(this.btnRigenera_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 244);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(231, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Salva ultimo file generato, a soli scopi di verifica";
            // 
            // btnSalvaFile
            // 
            this.btnSalvaFile.Location = new System.Drawing.Point(17, 260);
            this.btnSalvaFile.Name = "btnSalvaFile";
            this.btnSalvaFile.Size = new System.Drawing.Size(97, 23);
            this.btnSalvaFile.TabIndex = 50;
            this.btnSalvaFile.Text = "Salva file";
            this.btnSalvaFile.UseVisualStyleBackColor = true;
            this.btnSalvaFile.Click += new System.EventHandler(this.btnSalvaFile_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Importazione del file di esito";
            // 
            // txtNomeFileRisposta
            // 
            this.txtNomeFileRisposta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeFileRisposta.Location = new System.Drawing.Point(17, 96);
            this.txtNomeFileRisposta.Name = "txtNomeFileRisposta";
            this.txtNomeFileRisposta.ReadOnly = true;
            this.txtNomeFileRisposta.Size = new System.Drawing.Size(567, 20);
            this.txtNomeFileRisposta.TabIndex = 48;
            // 
            // btnImportaFileEsito
            // 
            this.btnImportaFileEsito.Location = new System.Drawing.Point(17, 66);
            this.btnImportaFileEsito.Name = "btnImportaFileEsito";
            this.btnImportaFileEsito.Size = new System.Drawing.Size(196, 24);
            this.btnImportaFileEsito.TabIndex = 47;
            this.btnImportaFileEsito.Text = "Importa il File Excel o CSV";
            this.btnImportaFileEsito.Click += new System.EventHandler(this.btnImportaFileEsito_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "VistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_pcc_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 595);
            this.Controls.Add(this.grpRigeneraFile);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label9);
            this.Name = "Frm_pcc_default";
            this.Text = "Frm_pcc_default";
            this.grpRigeneraFile.ResumeLayout(false);
            this.grpRigeneraFile.PerformLayout();
            this.grpAnagrafica.ResumeLayout(false);
            this.grpAnagrafica.PerformLayout();
            this.tabAttributi.ResumeLayout(false);
            this.gboxclass05.ResumeLayout(false);
            this.gboxclass05.PerformLayout();
            this.gboxclass04.ResumeLayout(false);
            this.gboxclass04.PerformLayout();
            this.gboxclass03.ResumeLayout(false);
            this.gboxclass03.PerformLayout();
            this.gboxclass02.ResumeLayout(false);
            this.gboxclass02.PerformLayout();
            this.gboxclass01.ResumeLayout(false);
            this.gboxclass01.PerformLayout();
            this.tabScadenza.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid3)).EndInit();
            this.tabPagamenti.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.tabContabilizzazioni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabInvio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridFatture)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabImportazione.ResumeLayout(false);
            this.tabImportazione.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label9;
        public VistaForm DS;
        private System.Windows.Forms.GroupBox grpRigeneraFile;
        private System.Windows.Forms.GroupBox grpAnagrafica;
        private System.Windows.Forms.TextBox txtAnagrafica;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPercorso;
        private System.Windows.Forms.Button btnCartella;
        private System.Windows.Forms.Button btnRigeneraFile;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TabPage tabAttributi;
        public System.Windows.Forms.GroupBox gboxclass05;
        public System.Windows.Forms.TextBox txtCodice05;
        public System.Windows.Forms.Button btnCodice05;
        private System.Windows.Forms.TextBox txtDenom05;
        public System.Windows.Forms.GroupBox gboxclass04;
        public System.Windows.Forms.TextBox txtCodice04;
        public System.Windows.Forms.Button btnCodice04;
        private System.Windows.Forms.TextBox txtDenom04;
        public System.Windows.Forms.GroupBox gboxclass03;
        public System.Windows.Forms.TextBox txtCodice03;
        public System.Windows.Forms.Button btnCodice03;
        private System.Windows.Forms.TextBox txtDenom03;
        public System.Windows.Forms.GroupBox gboxclass02;
        public System.Windows.Forms.TextBox txtCodice02;
        public System.Windows.Forms.Button btnCodice02;
        private System.Windows.Forms.TextBox txtDenom02;
        public System.Windows.Forms.GroupBox gboxclass01;
        public System.Windows.Forms.TextBox txtCodice01;
        public System.Windows.Forms.Button btnCodice01;
        private System.Windows.Forms.TextBox txtDenom01;
        private System.Windows.Forms.TabPage tabScadenza;
        private System.Windows.Forms.Button btnEliminaCS;
        private System.Windows.Forms.DataGrid dataGrid3;
        private System.Windows.Forms.TabPage tabPagamenti;
        private System.Windows.Forms.Button btnEliminaCP;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.TabPage tabContabilizzazioni;
        private System.Windows.Forms.Button btnEliminaCO;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.TabPage tabInvio;
        private System.Windows.Forms.Button btnEliminaIN;
        private System.Windows.Forms.DataGrid gridFatture;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.TabPage tabImportazione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeFileRisposta;
        public System.Windows.Forms.Button btnImportaFileEsito;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSalvaFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnRigenera;
    }
}