/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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

﻿namespace relation_default {
    partial class frmRelationDefault {
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtTabellaChild = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgridCol = new System.Windows.Forms.DataGrid();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.cmbChild = new System.Windows.Forms.ComboBox();
            this.DS = new relation_default.dsmeta();
            this.cmbParent = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgridCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Parent";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(430, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Child";
            // 
            // txtTabellaChild
            // 
            this.txtTabellaChild.Location = new System.Drawing.Point(12, 85);
            this.txtTabellaChild.Name = "txtTabellaChild";
            this.txtTabellaChild.Size = new System.Drawing.Size(801, 20);
            this.txtTabellaChild.TabIndex = 5;
            this.txtTabellaChild.Tag = "relation.title";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tabella child (mostrata in relazioni child)";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(12, 136);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(801, 61);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.Tag = "relation.description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(203, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Descrizione (significato nella tabella Child)";
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
            this.dgridCol.Location = new System.Drawing.Point(115, 215);
            this.dgridCol.Name = "dgridCol";
            this.dgridCol.ParentRowsVisible = false;
            this.dgridCol.ReadOnly = true;
            this.dgridCol.Size = new System.Drawing.Size(698, 97);
            this.dgridCol.TabIndex = 50;
            this.dgridCol.Tag = "relationcol.default.detail";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(12, 273);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 56;
            this.button3.Tag = "delete";
            this.button3.Text = "Elimina";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 55;
            this.button2.Tag = "edit.detail";
            this.button2.Text = "Modifica";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 54;
            this.button1.Tag = "insert.detail";
            this.button1.Text = "Nuova";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(730, 338);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 58;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(617, 338);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 57;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // cmbChild
            // 
            this.cmbChild.DataSource = this.DS.tabledescr_child;
            this.cmbChild.DisplayMember = "tablename";
            this.cmbChild.FormattingEnabled = true;
            this.cmbChild.Location = new System.Drawing.Point(433, 34);
            this.cmbChild.Name = "cmbChild";
            this.cmbChild.Size = new System.Drawing.Size(380, 21);
            this.cmbChild.TabIndex = 59;
            this.cmbChild.Tag = "relation.childtable";
            this.cmbChild.ValueMember = "tablename";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // cmbParent
            // 
            this.cmbParent.DataSource = this.DS.tabledescr_parent;
            this.cmbParent.DisplayMember = "tablename";
            this.cmbParent.FormattingEnabled = true;
            this.cmbParent.Location = new System.Drawing.Point(12, 34);
            this.cmbParent.Name = "cmbParent";
            this.cmbParent.Size = new System.Drawing.Size(396, 21);
            this.cmbParent.TabIndex = 60;
            this.cmbParent.Tag = "relation.parenttable";
            this.cmbParent.ValueMember = "tablename";
            // 
            // frmRelationDefault
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 383);
            this.Controls.Add(this.cmbParent);
            this.Controls.Add(this.cmbChild);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgridCol);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTabellaChild);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmRelationDefault";
            this.Text = " ";
            ((System.ComponentModel.ISupportInitialize)(this.dgridCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public dsmeta DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTabellaChild;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGrid dgridCol;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cmbChild;
        private System.Windows.Forms.ComboBox cmbParent;
    }
}