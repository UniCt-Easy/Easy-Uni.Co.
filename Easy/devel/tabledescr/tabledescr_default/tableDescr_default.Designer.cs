/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿namespace tabledescr_default {
    partial class tableDescr_default {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnAggiorna = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.dgridCol = new System.Windows.Forms.DataGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgridRel = new System.Windows.Forms.DataGrid();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button7 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSonarRelazioni = new System.Windows.Forms.Button();
            this.btnAllNames = new System.Windows.Forms.Button();
            this.btnCaptions = new System.Windows.Forms.Button();
            this.btnCaptionGlobale = new System.Windows.Forms.Button();
            this.btnLeggiDati = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxIsDbo = new System.Windows.Forms.CheckBox();
            this.DS = new tabledescr_default.vistaForm();
            this.comboBoxApplication = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridCol)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgridRel)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Table name";
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(12, 29);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(362, 20);
            this.txtTableName.TabIndex = 1;
            this.txtTableName.Tag = "tabledescr.tablename";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome breve";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 79);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(362, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "tabledescr.title";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(396, 29);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(500, 47);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.Tag = "tabledescr.description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(393, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descrizione";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(16, 105);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 451);
            this.tabControl1.TabIndex = 6;
            this.tabControl1.Tag = "relation.default.default";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnAggiorna);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.dgridCol);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(872, 425);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Colonne";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnAggiorna
            // 
            this.btnAggiorna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAggiorna.Location = new System.Drawing.Point(18, 385);
            this.btnAggiorna.Name = "btnAggiorna";
            this.btnAggiorna.Size = new System.Drawing.Size(75, 23);
            this.btnAggiorna.TabIndex = 57;
            this.btnAggiorna.Text = "Aggiorna";
            this.btnAggiorna.UseVisualStyleBackColor = true;
            this.btnAggiorna.Click += new System.EventHandler(this.btnAggiorna_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(18, 73);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 56;
            this.button4.Tag = "delete";
            this.button4.Text = "Elimina";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(18, 44);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 55;
            this.button5.Tag = "edit.default";
            this.button5.Text = "Modifica";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(18, 15);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 54;
            this.button6.Tag = "insert.default";
            this.button6.Text = "Nuova";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // dgridCol
            // 
            this.dgridCol.AllowNavigation = false;
            this.dgridCol.AllowSorting = false;
            this.dgridCol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridCol.DataMember = "";
            this.dgridCol.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgridCol.Location = new System.Drawing.Point(108, 15);
            this.dgridCol.Name = "dgridCol";
            this.dgridCol.ParentRowsVisible = false;
            this.dgridCol.ReadOnly = true;
            this.dgridCol.Size = new System.Drawing.Size(758, 393);
            this.dgridCol.TabIndex = 49;
            this.dgridCol.Tag = "coldescr.default.default";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.dgridRel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(872, 425);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tabelle parent";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.Location = new System.Drawing.Point(6, 386);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 58;
            this.button8.Text = "Calcola";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 75);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 53;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(6, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 52;
            this.button2.Tag = "edit.default";
            this.button2.Text = "Modifica";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 51;
            this.button1.Tag = "insert.default";
            this.button1.Text = "Nuova";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dgridRel
            // 
            this.dgridRel.AllowNavigation = false;
            this.dgridRel.AllowSorting = false;
            this.dgridRel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgridRel.DataMember = "";
            this.dgridRel.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgridRel.Location = new System.Drawing.Point(101, 17);
            this.dgridRel.Name = "dgridRel";
            this.dgridRel.ParentRowsVisible = false;
            this.dgridRel.ReadOnly = true;
            this.dgridRel.Size = new System.Drawing.Size(765, 392);
            this.dgridRel.TabIndex = 50;
            this.dgridRel.Tag = "relation_parent.parent.default";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.button7);
            this.tabPage4.Controls.Add(this.button9);
            this.tabPage4.Controls.Add(this.button10);
            this.tabPage4.Controls.Add(this.button11);
            this.tabPage4.Controls.Add(this.dataGrid1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(872, 425);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tabelle child";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button7.Location = new System.Drawing.Point(6, 385);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 63;
            this.button7.Text = "Calcola";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 74);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 62;
            this.button9.Tag = "delete";
            this.button9.Text = "Elimina";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 45);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 61;
            this.button10.Tag = "edit.child";
            this.button10.Text = "Modifica";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(6, 16);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(75, 23);
            this.button11.TabIndex = 60;
            this.button11.Tag = "insert.child";
            this.button11.Text = "Nuova";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // dataGrid1
            // 
            this.dataGrid1.AllowNavigation = false;
            this.dataGrid1.AllowSorting = false;
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(101, 16);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.ParentRowsVisible = false;
            this.dataGrid1.ReadOnly = true;
            this.dataGrid1.Size = new System.Drawing.Size(765, 392);
            this.dataGrid1.TabIndex = 59;
            this.dataGrid1.Tag = "relation_child.child.child";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSonarRelazioni);
            this.tabPage3.Controls.Add(this.btnAllNames);
            this.tabPage3.Controls.Add(this.btnCaptions);
            this.tabPage3.Controls.Add(this.btnCaptionGlobale);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(872, 425);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Tools";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSonarRelazioni
            // 
            this.btnSonarRelazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSonarRelazioni.Location = new System.Drawing.Point(247, 44);
            this.btnSonarRelazioni.Name = "btnSonarRelazioni";
            this.btnSonarRelazioni.Size = new System.Drawing.Size(75, 53);
            this.btnSonarRelazioni.TabIndex = 61;
            this.btnSonarRelazioni.Text = "Sonar relazioni";
            this.btnSonarRelazioni.UseVisualStyleBackColor = true;
            this.btnSonarRelazioni.Click += new System.EventHandler(this.btnSonarRelazioni_Click);
            // 
            // btnAllNames
            // 
            this.btnAllNames.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllNames.Location = new System.Drawing.Point(133, 44);
            this.btnAllNames.Name = "btnAllNames";
            this.btnAllNames.Size = new System.Drawing.Size(75, 53);
            this.btnAllNames.TabIndex = 60;
            this.btnAllNames.Text = "leggi nomi globale";
            this.btnAllNames.UseVisualStyleBackColor = true;
            this.btnAllNames.Click += new System.EventHandler(this.btnAllNames_Click);
            // 
            // btnCaptions
            // 
            this.btnCaptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCaptions.Location = new System.Drawing.Point(26, 113);
            this.btnCaptions.Name = "btnCaptions";
            this.btnCaptions.Size = new System.Drawing.Size(75, 35);
            this.btnCaptions.TabIndex = 58;
            this.btnCaptions.Text = "leggi Captions";
            this.btnCaptions.UseVisualStyleBackColor = true;
            this.btnCaptions.Click += new System.EventHandler(this.btnCaptions_Click);
            // 
            // btnCaptionGlobale
            // 
            this.btnCaptionGlobale.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCaptionGlobale.Location = new System.Drawing.Point(26, 44);
            this.btnCaptionGlobale.Name = "btnCaptionGlobale";
            this.btnCaptionGlobale.Size = new System.Drawing.Size(75, 53);
            this.btnCaptionGlobale.TabIndex = 59;
            this.btnCaptionGlobale.Text = "leggi Captions globale";
            this.btnCaptionGlobale.UseVisualStyleBackColor = true;
            this.btnCaptionGlobale.Click += new System.EventHandler(this.btnCaptionGlobale_Click);
            // 
            // btnLeggiDati
            // 
            this.btnLeggiDati.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLeggiDati.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnLeggiDati.Location = new System.Drawing.Point(267, 580);
            this.btnLeggiDati.Name = "btnLeggiDati";
            this.btnLeggiDati.Size = new System.Drawing.Size(137, 23);
            this.btnLeggiDati.TabIndex = 13;
            this.btnLeggiDati.Tag = "";
            this.btnLeggiDati.Text = "Leggi dati dal db";
            this.btnLeggiDati.UseVisualStyleBackColor = true;
            this.btnLeggiDati.Click += new System.EventHandler(this.btnLeggiDati_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(495, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Applicazione";
            // 
            // checkBoxIsDbo
            // 
            this.checkBoxIsDbo.AutoSize = true;
            this.checkBoxIsDbo.Location = new System.Drawing.Point(396, 83);
            this.checkBoxIsDbo.Name = "checkBoxIsDbo";
            this.checkBoxIsDbo.Size = new System.Drawing.Size(88, 17);
            this.checkBoxIsDbo.TabIndex = 4;
            this.checkBoxIsDbo.Tag = "tabledescr.isdbo:S:N";
            this.checkBoxIsDbo.Text = "Schema Dbo";
            this.checkBoxIsDbo.UseVisualStyleBackColor = true;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // comboBoxApplication
            // 
            this.comboBoxApplication.DataSource = this.DS.applicationlist;
            this.comboBoxApplication.DisplayMember = "description";
            this.comboBoxApplication.FormattingEnabled = true;
            this.comboBoxApplication.Location = new System.Drawing.Point(570, 79);
            this.comboBoxApplication.Name = "comboBoxApplication";
            this.comboBoxApplication.Size = new System.Drawing.Size(326, 21);
            this.comboBoxApplication.TabIndex = 5;
            this.comboBoxApplication.Tag = "tabledescr.idapplication";
            this.comboBoxApplication.ValueMember = "idapplication";
            // 
            // tableDescr_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 615);
            this.Controls.Add(this.comboBoxApplication);
            this.Controls.Add(this.checkBoxIsDbo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnLeggiDati);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTableName);
            this.Controls.Add(this.label1);
            this.Name = "tableDescr_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabella";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridCol)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgridRel)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnAggiorna;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.DataGrid dgridCol;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGrid dgridRel;
        private System.Windows.Forms.Button btnCaptions;
        public vistaForm DS;
        private System.Windows.Forms.Button btnCaptionGlobale;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnAllNames;
        private System.Windows.Forms.Button btnLeggiDati;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnSonarRelazioni;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.CheckBox checkBoxIsDbo;
		private System.Windows.Forms.ComboBox comboBoxApplication;
	}
}