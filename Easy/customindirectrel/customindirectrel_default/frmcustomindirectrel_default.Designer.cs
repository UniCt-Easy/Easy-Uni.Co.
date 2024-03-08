
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


namespace customindirectrel_default {
    partial class frmcustomindirectrel_default {
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.FromTable = new System.Windows.Forms.GroupBox();
            this.txtFromTable = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtParent1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtParent2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtParent2w = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInsertFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtNavFilter = new System.Windows.Forms.TextBox();
            this.ckbdefault = new System.Windows.Forms.CheckBox();
            this.ckbnavfil = new System.Windows.Forms.CheckBox();
            this.ckbinsfil = new System.Windows.Forms.CheckBox();
            this.ckbnav = new System.Windows.Forms.CheckBox();
            this.ckbins = new System.Windows.Forms.CheckBox();
            this.gboxCustomindirectrelcol = new System.Windows.Forms.GroupBox();
            this.btnInsCustomdirectrelcol = new System.Windows.Forms.Button();
            this.btnDelCustomdirectrelcol = new System.Windows.Forms.Button();
            this.btnUpdCustomdirectrelcol = new System.Windows.Forms.Button();
            this.datagridCustomindirectrelcol = new System.Windows.Forms.DataGrid();
            this.DS = new customindirectrel_default.dsmeta();
            this.cmblist = new System.Windows.Forms.ComboBox();
            this.cmbedit = new System.Windows.Forms.ComboBox();
            this.FromTable.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gboxCustomindirectrelcol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridCustomindirectrelcol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(29, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Descrizione";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(109, 18);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(63, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Tag = "customindirectrel.idcustomindirectrel";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(109, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(768, 20);
            this.textBox1.TabIndex = 12;
            this.textBox1.Tag = "customindirectrel.description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(687, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 18;
            this.label3.Text = "Edittype";
            // 
            // FromTable
            // 
            this.FromTable.Controls.Add(this.txtFromTable);
            this.FromTable.Location = new System.Drawing.Point(32, 85);
            this.FromTable.Name = "FromTable";
            this.FromTable.Size = new System.Drawing.Size(413, 40);
            this.FromTable.TabIndex = 16;
            this.FromTable.TabStop = false;
            this.FromTable.Tag = "AutoChoose.txtFromTable.default";
            this.FromTable.Text = "Tabella di mezzo";
            // 
            // txtFromTable
            // 
            this.txtFromTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromTable.Location = new System.Drawing.Point(6, 16);
            this.txtFromTable.Name = "txtFromTable";
            this.txtFromTable.Size = new System.Drawing.Size(401, 20);
            this.txtFromTable.TabIndex = 6;
            this.txtFromTable.Tag = "customobject_middle.objectname?customindirectrel.middletable";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 15);
            this.label4.TabIndex = 20;
            this.label4.Text = "Filtro su tabella di mezzo";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(182, 138);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(695, 20);
            this.textBox4.TabIndex = 19;
            this.textBox4.Tag = "customindirectrel.filtermiddle";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtParent1);
            this.groupBox1.Location = new System.Drawing.Point(26, 164);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 40);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "AutoChoose.txtParent1.default";
            this.groupBox1.Text = "Tabella origine";
            // 
            // txtParent1
            // 
            this.txtParent1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParent1.Location = new System.Drawing.Point(6, 16);
            this.txtParent1.Name = "txtParent1";
            this.txtParent1.Size = new System.Drawing.Size(401, 20);
            this.txtParent1.TabIndex = 6;
            this.txtParent1.Tag = "customobject_parent1.objectname?customindirectrel.parenttable1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtParent2);
            this.groupBox2.Location = new System.Drawing.Point(464, 164);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(413, 40);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "AutoChoose.txtParent2.default";
            this.groupBox2.Text = "Tabella destinazione";
            // 
            // txtParent2
            // 
            this.txtParent2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParent2.Location = new System.Drawing.Point(6, 16);
            this.txtParent2.Name = "txtParent2";
            this.txtParent2.Size = new System.Drawing.Size(401, 20);
            this.txtParent2.TabIndex = 6;
            this.txtParent2.Tag = "customobject_parent2.objectname?customindirectrel.parenttable2";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtParent2w);
            this.groupBox3.Location = new System.Drawing.Point(26, 210);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(413, 40);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "AutoChoose.txtParent2w.default.(isreal=\'N\')";
            this.groupBox3.Text = "Vista per elenco destinazione";
            // 
            // txtParent2w
            // 
            this.txtParent2w.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtParent2w.Location = new System.Drawing.Point(6, 16);
            this.txtParent2w.Name = "txtParent2w";
            this.txtParent2w.Size = new System.Drawing.Size(401, 20);
            this.txtParent2w.TabIndex = 6;
            this.txtParent2w.Tag = "customobject_parent2view.objectname?customindirectrel.parenttable2view";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(461, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 15);
            this.label5.TabIndex = 23;
            this.label5.Text = "Listtype";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 261);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(163, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "Filtro attivazione inserimento";
            // 
            // txtInsertFilter
            // 
            this.txtInsertFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsertFilter.Location = new System.Drawing.Point(207, 260);
            this.txtInsertFilter.Name = "txtInsertFilter";
            this.txtInsertFilter.Size = new System.Drawing.Size(679, 20);
            this.txtInsertFilter.TabIndex = 24;
            this.txtInsertFilter.Tag = "customindirectrel.insertfilterparenttable1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 311);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(123, 15);
            this.label7.TabIndex = 27;
            this.label7.Text = "Filtro su destinazione";
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(182, 310);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(704, 20);
            this.textBox10.TabIndex = 26;
            this.textBox10.Tag = "customindirectrel.filterparenttable2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(38, 285);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Filtro attivazione navigazione";
            // 
            // txtNavFilter
            // 
            this.txtNavFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavFilter.Location = new System.Drawing.Point(207, 284);
            this.txtNavFilter.Name = "txtNavFilter";
            this.txtNavFilter.Size = new System.Drawing.Size(679, 20);
            this.txtNavFilter.TabIndex = 28;
            this.txtNavFilter.Tag = "customindirectrel.navigationfilterparenttable1";
            // 
            // ckbdefault
            // 
            this.ckbdefault.Location = new System.Drawing.Point(599, 336);
            this.ckbdefault.Name = "ckbdefault";
            this.ckbdefault.Size = new System.Drawing.Size(287, 48);
            this.ckbdefault.TabIndex = 37;
            this.ckbdefault.Tag = "customindirectrel.flag:4";
            this.ckbdefault.Text = "Valori di default custom in inserimento (sp_getcustomrelationindirectdefault)";
            // 
            // ckbnavfil
            // 
            this.ckbnavfil.Location = new System.Drawing.Point(271, 336);
            this.ckbnavfil.Name = "ckbnavfil";
            this.ckbnavfil.Size = new System.Drawing.Size(308, 24);
            this.ckbnavfil.TabIndex = 35;
            this.ckbnavfil.Tag = "customindirectrel.flag:2";
            this.ckbnavfil.Text = "Filtro custom su navigazione  (sp_getcustomrelationfilter)";
            // 
            // ckbinsfil
            // 
            this.ckbinsfil.Location = new System.Drawing.Point(271, 360);
            this.ckbinsfil.Name = "ckbinsfil";
            this.ckbinsfil.Size = new System.Drawing.Size(308, 24);
            this.ckbinsfil.TabIndex = 36;
            this.ckbinsfil.Tag = "customindirectrel.flag:3";
            this.ckbinsfil.Text = "Filtro custom su inserimento (sp_getcustomrelationfilter)";
            // 
            // ckbnav
            // 
            this.ckbnav.Location = new System.Drawing.Point(38, 336);
            this.ckbnav.Name = "ckbnav";
            this.ckbnav.Size = new System.Drawing.Size(285, 24);
            this.ckbnav.TabIndex = 33;
            this.ckbnav.Tag = "customindirectrel.flag:0";
            this.ckbnav.Text = "Può navigare da origine a destinazione";
            // 
            // ckbins
            // 
            this.ckbins.Location = new System.Drawing.Point(38, 360);
            this.ckbins.Name = "ckbins";
            this.ckbins.Size = new System.Drawing.Size(285, 24);
            this.ckbins.TabIndex = 34;
            this.ckbins.Tag = "customindirectrel.flag:1";
            this.ckbins.Text = "Può inserire da origine a destinazione";
            // 
            // gboxCustomindirectrelcol
            // 
            this.gboxCustomindirectrelcol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCustomindirectrelcol.Controls.Add(this.btnInsCustomdirectrelcol);
            this.gboxCustomindirectrelcol.Controls.Add(this.btnDelCustomdirectrelcol);
            this.gboxCustomindirectrelcol.Controls.Add(this.btnUpdCustomdirectrelcol);
            this.gboxCustomindirectrelcol.Controls.Add(this.datagridCustomindirectrelcol);
            this.gboxCustomindirectrelcol.Location = new System.Drawing.Point(12, 390);
            this.gboxCustomindirectrelcol.Name = "gboxCustomindirectrelcol";
            this.gboxCustomindirectrelcol.Size = new System.Drawing.Size(901, 153);
            this.gboxCustomindirectrelcol.TabIndex = 38;
            this.gboxCustomindirectrelcol.TabStop = false;
            this.gboxCustomindirectrelcol.Text = "Colonne della relazione";
            // 
            // btnInsCustomdirectrelcol
            // 
            this.btnInsCustomdirectrelcol.Location = new System.Drawing.Point(8, 19);
            this.btnInsCustomdirectrelcol.Name = "btnInsCustomdirectrelcol";
            this.btnInsCustomdirectrelcol.Size = new System.Drawing.Size(75, 24);
            this.btnInsCustomdirectrelcol.TabIndex = 7;
            this.btnInsCustomdirectrelcol.TabStop = false;
            this.btnInsCustomdirectrelcol.Tag = "insert.single";
            this.btnInsCustomdirectrelcol.Text = "Inserisci";
            // 
            // btnDelCustomdirectrelcol
            // 
            this.btnDelCustomdirectrelcol.Location = new System.Drawing.Point(8, 83);
            this.btnDelCustomdirectrelcol.Name = "btnDelCustomdirectrelcol";
            this.btnDelCustomdirectrelcol.Size = new System.Drawing.Size(75, 24);
            this.btnDelCustomdirectrelcol.TabIndex = 9;
            this.btnDelCustomdirectrelcol.TabStop = false;
            this.btnDelCustomdirectrelcol.Tag = "delete";
            this.btnDelCustomdirectrelcol.Text = "Elimina";
            // 
            // btnUpdCustomdirectrelcol
            // 
            this.btnUpdCustomdirectrelcol.Location = new System.Drawing.Point(8, 51);
            this.btnUpdCustomdirectrelcol.Name = "btnUpdCustomdirectrelcol";
            this.btnUpdCustomdirectrelcol.Size = new System.Drawing.Size(75, 24);
            this.btnUpdCustomdirectrelcol.TabIndex = 8;
            this.btnUpdCustomdirectrelcol.TabStop = false;
            this.btnUpdCustomdirectrelcol.Tag = "edit.single";
            this.btnUpdCustomdirectrelcol.Text = "Modifica";
            // 
            // datagridCustomindirectrelcol
            // 
            this.datagridCustomindirectrelcol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridCustomindirectrelcol.CaptionVisible = false;
            this.datagridCustomindirectrelcol.DataMember = "";
            this.datagridCustomindirectrelcol.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.datagridCustomindirectrelcol.Location = new System.Drawing.Point(96, 19);
            this.datagridCustomindirectrelcol.Name = "datagridCustomindirectrelcol";
            this.datagridCustomindirectrelcol.Size = new System.Drawing.Size(789, 128);
            this.datagridCustomindirectrelcol.TabIndex = 10;
            this.datagridCustomindirectrelcol.Tag = "customindirectrelcol.single";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // cmblist
            // 
            this.cmblist.DataSource = this.DS.listtype;
            this.cmblist.DisplayMember = "list";
            this.cmblist.FormattingEnabled = true;
            this.cmblist.Location = new System.Drawing.Point(515, 225);
            this.cmblist.Name = "cmblist";
            this.cmblist.Size = new System.Drawing.Size(152, 21);
            this.cmblist.TabIndex = 40;
            this.cmblist.Tag = "customindirectrel.listtype";
            this.cmblist.ValueMember = "list";
            // 
            // cmbedit
            // 
            this.cmbedit.DataSource = this.DS.edittype;
            this.cmbedit.DisplayMember = "edit";
            this.cmbedit.FormattingEnabled = true;
            this.cmbedit.Location = new System.Drawing.Point(743, 225);
            this.cmbedit.Name = "cmbedit";
            this.cmbedit.Size = new System.Drawing.Size(134, 21);
            this.cmbedit.TabIndex = 39;
            this.cmbedit.Tag = "customindirectrel.edittype";
            this.cmbedit.ValueMember = "edit";
            // 
            // frmcustomindirectrel_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 544);
            this.Controls.Add(this.cmblist);
            this.Controls.Add(this.cmbedit);
            this.Controls.Add(this.gboxCustomindirectrelcol);
            this.Controls.Add(this.ckbdefault);
            this.Controls.Add(this.ckbnavfil);
            this.Controls.Add(this.ckbinsfil);
            this.Controls.Add(this.ckbnav);
            this.Controls.Add(this.ckbins);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNavFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInsertFilter);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FromTable);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Name = "frmcustomindirectrel_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "customindirectrel_default";
            this.FromTable.ResumeLayout(false);
            this.FromTable.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxCustomindirectrelcol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridCustomindirectrelcol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public customindirectrel_default.dsmeta DS;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox FromTable;
        private System.Windows.Forms.TextBox txtFromTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtParent1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtParent2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtParent2w;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtInsertFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNavFilter;
        private System.Windows.Forms.CheckBox ckbdefault;
        private System.Windows.Forms.CheckBox ckbnavfil;
        private System.Windows.Forms.CheckBox ckbinsfil;
        private System.Windows.Forms.CheckBox ckbnav;
        private System.Windows.Forms.CheckBox ckbins;
        private System.Windows.Forms.GroupBox gboxCustomindirectrelcol;
        private System.Windows.Forms.Button btnInsCustomdirectrelcol;
        private System.Windows.Forms.Button btnDelCustomdirectrelcol;
        private System.Windows.Forms.Button btnUpdCustomdirectrelcol;
        private System.Windows.Forms.DataGrid datagridCustomindirectrelcol;
        private System.Windows.Forms.ComboBox cmblist;
        private System.Windows.Forms.ComboBox cmbedit;
    }
}

