
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
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;

namespace customdirectrel_default {
    partial class frmcustomdirectrel_default {
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
            this.FromTable = new System.Windows.Forms.GroupBox();
            this.txtFromTable = new System.Windows.Forms.TextBox();
            this.ToTable = new System.Windows.Forms.GroupBox();
            this.txtToTable = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInsertFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNavFilter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.ToTableView = new System.Windows.Forms.GroupBox();
            this.txtToTableView = new System.Windows.Forms.TextBox();
            this.gboxCustomdirectrelcol = new System.Windows.Forms.GroupBox();
            this.btnInsCustomdirectrelcol = new System.Windows.Forms.Button();
            this.btnDelCustomdirectrelcol = new System.Windows.Forms.Button();
            this.btnUpdCustomdirectrelcol = new System.Windows.Forms.Button();
            this.datagridCustomdirectrelcol = new System.Windows.Forms.DataGrid();
            this.ckbnav = new System.Windows.Forms.CheckBox();
            this.ckbins = new System.Windows.Forms.CheckBox();
            this.DS = new customdirectrel_default.dsmeta();
            this.ckbnavfil = new System.Windows.Forms.CheckBox();
            this.ckbinsfil = new System.Windows.Forms.CheckBox();
            this.ckbdefault = new System.Windows.Forms.CheckBox();
            this.cmbedit = new System.Windows.Forms.ComboBox();
            this.cmblist = new System.Windows.Forms.ComboBox();
            this.FromTable.SuspendLayout();
            this.ToTable.SuspendLayout();
            this.ToTableView.SuspendLayout();
            this.gboxCustomdirectrelcol.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.datagridCustomdirectrelcol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // FromTable
            // 
            this.FromTable.Controls.Add(this.txtFromTable);
            this.FromTable.Location = new System.Drawing.Point(29, 76);
            this.FromTable.Name = "FromTable";
            this.FromTable.Size = new System.Drawing.Size(413, 40);
            this.FromTable.TabIndex = 3;
            this.FromTable.TabStop = false;
            this.FromTable.Tag = "AutoChoose.txtFromTable.default.(isreal=\'S\')";
            this.FromTable.Text = "Tabella di partenza";
            // 
            // txtFromTable
            // 
            this.txtFromTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFromTable.Location = new System.Drawing.Point(6, 16);
            this.txtFromTable.Name = "txtFromTable";
            this.txtFromTable.Size = new System.Drawing.Size(401, 20);
            this.txtFromTable.TabIndex = 6;
            this.txtFromTable.Tag = "customobject.objectname?customdirectrel.fromtable";
            // 
            // ToTable
            // 
            this.ToTable.Controls.Add(this.txtToTable);
            this.ToTable.Location = new System.Drawing.Point(29, 214);
            this.ToTable.Name = "ToTable";
            this.ToTable.Size = new System.Drawing.Size(413, 40);
            this.ToTable.TabIndex = 7;
            this.ToTable.TabStop = false;
            this.ToTable.Tag = "AutoChoose.txtToTable.default.(isreal=\'S\')";
            this.ToTable.Text = "Tabella di arrivo";
            // 
            // txtToTable
            // 
            this.txtToTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToTable.Location = new System.Drawing.Point(6, 16);
            this.txtToTable.Name = "txtToTable";
            this.txtToTable.Size = new System.Drawing.Size(401, 20);
            this.txtToTable.TabIndex = 6;
            this.txtToTable.Tag = "customobject1.objectname?customdirectrel.totable";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(112, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(768, 20);
            this.textBox1.TabIndex = 8;
            this.textBox1.Tag = "customdirectrel.description";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(112, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(68, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Tag = "customdirectrel.idcustomdirectrel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Descrizione";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 265);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Edittype";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "Filtro";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(112, 127);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(774, 20);
            this.textBox4.TabIndex = 14;
            this.textBox4.Tag = "customdirectrel.filter";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Filtro attivazione  inserimento";
            // 
            // txtInsertFilter
            // 
            this.txtInsertFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInsertFilter.Location = new System.Drawing.Point(201, 162);
            this.txtInsertFilter.Name = "txtInsertFilter";
            this.txtInsertFilter.Size = new System.Drawing.Size(685, 20);
            this.txtInsertFilter.TabIndex = 19;
            this.txtInsertFilter.Tag = "customdirectrel.insertfilterparent";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(143, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Filtro attivazione navigazione";
            // 
            // txtNavFilter
            // 
            this.txtNavFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavFilter.Location = new System.Drawing.Point(201, 188);
            this.txtNavFilter.Name = "txtNavFilter";
            this.txtNavFilter.Size = new System.Drawing.Size(685, 20);
            this.txtNavFilter.TabIndex = 21;
            this.txtNavFilter.Tag = "customdirectrel.navigationfilterparent";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(447, 267);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 24;
            this.label8.Text = "Listtype";
            // 
            // ToTableView
            // 
            this.ToTableView.Controls.Add(this.txtToTableView);
            this.ToTableView.Location = new System.Drawing.Point(451, 214);
            this.ToTableView.Name = "ToTableView";
            this.ToTableView.Size = new System.Drawing.Size(435, 40);
            this.ToTableView.TabIndex = 8;
            this.ToTableView.TabStop = false;
            this.ToTableView.Tag = "AutoChoose.txtToTableView.default.(isreal=\'N\')";
            this.ToTableView.Text = "Vista per elenco (opzionale)";
            // 
            // txtToTableView
            // 
            this.txtToTableView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtToTableView.Location = new System.Drawing.Point(6, 16);
            this.txtToTableView.Name = "txtToTableView";
            this.txtToTableView.Size = new System.Drawing.Size(423, 20);
            this.txtToTableView.TabIndex = 6;
            this.txtToTableView.Tag = "customobjecttableview.objectname?customdirectrel.totableview";
            // 
            // gboxCustomdirectrelcol
            // 
            this.gboxCustomdirectrelcol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxCustomdirectrelcol.Controls.Add(this.btnInsCustomdirectrelcol);
            this.gboxCustomdirectrelcol.Controls.Add(this.btnDelCustomdirectrelcol);
            this.gboxCustomdirectrelcol.Controls.Add(this.btnUpdCustomdirectrelcol);
            this.gboxCustomdirectrelcol.Controls.Add(this.datagridCustomdirectrelcol);
            this.gboxCustomdirectrelcol.Location = new System.Drawing.Point(12, 348);
            this.gboxCustomdirectrelcol.Name = "gboxCustomdirectrelcol";
            this.gboxCustomdirectrelcol.Size = new System.Drawing.Size(901, 153);
            this.gboxCustomdirectrelcol.TabIndex = 26;
            this.gboxCustomdirectrelcol.TabStop = false;
            this.gboxCustomdirectrelcol.Text = "Colonne della relazione";
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
            // datagridCustomdirectrelcol
            // 
            this.datagridCustomdirectrelcol.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.datagridCustomdirectrelcol.CaptionVisible = false;
            this.datagridCustomdirectrelcol.DataMember = "";
            this.datagridCustomdirectrelcol.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.datagridCustomdirectrelcol.Location = new System.Drawing.Point(96, 19);
            this.datagridCustomdirectrelcol.Name = "datagridCustomdirectrelcol";
            this.datagridCustomdirectrelcol.Size = new System.Drawing.Size(789, 128);
            this.datagridCustomdirectrelcol.TabIndex = 10;
            this.datagridCustomdirectrelcol.Tag = "customdirectrelcol.single";
            // 
            // ckbnav
            // 
            this.ckbnav.Location = new System.Drawing.Point(20, 291);
            this.ckbnav.Name = "ckbnav";
            this.ckbnav.Size = new System.Drawing.Size(331, 24);
            this.ckbnav.TabIndex = 27;
            this.ckbnav.Tag = "customdirectrel.flag:0";
            this.ckbnav.Text = "Può navigare dalla tabella di partenza alla tabella destinazione";
            // 
            // ckbins
            // 
            this.ckbins.Location = new System.Drawing.Point(20, 315);
            this.ckbins.Name = "ckbins";
            this.ckbins.Size = new System.Drawing.Size(331, 24);
            this.ckbins.TabIndex = 29;
            this.ckbins.Tag = "customdirectrel.flag:1";
            this.ckbins.Text = "Può inserire dalla tabella di partenza alla tabella destinazione";
            this.ckbins.CheckedChanged += new System.EventHandler(this.ckbins_CheckedChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // ckbnavfil
            // 
            this.ckbnavfil.Location = new System.Drawing.Point(427, 291);
            this.ckbnavfil.Name = "ckbnavfil";
            this.ckbnavfil.Size = new System.Drawing.Size(198, 24);
            this.ckbnavfil.TabIndex = 30;
            this.ckbnavfil.Tag = "customdirectrel.flag:2";
            this.ckbnavfil.Text = "Filtro custom per navigazione";
            // 
            // ckbinsfil
            // 
            this.ckbinsfil.Location = new System.Drawing.Point(427, 315);
            this.ckbinsfil.Name = "ckbinsfil";
            this.ckbinsfil.Size = new System.Drawing.Size(198, 24);
            this.ckbinsfil.TabIndex = 31;
            this.ckbinsfil.Tag = "customdirectrel.flag:3";
            this.ckbinsfil.Text = "Filtro custom per inserimento";
            // 
            // ckbdefault
            // 
            this.ckbdefault.Location = new System.Drawing.Point(643, 291);
            this.ckbdefault.Name = "ckbdefault";
            this.ckbdefault.Size = new System.Drawing.Size(254, 48);
            this.ckbdefault.TabIndex = 32;
            this.ckbdefault.Tag = "customdirectrel.flag:4";
            this.ckbdefault.Text = "Valori di default custom in inserimento (sp_getcustomrelationdefault)";
            // 
            // cmbedit
            // 
            this.cmbedit.DataSource = this.DS.edittype;
            this.cmbedit.DisplayMember = "edit";
            this.cmbedit.FormattingEnabled = true;
            this.cmbedit.Location = new System.Drawing.Point(84, 264);
            this.cmbedit.Name = "cmbedit";
            this.cmbedit.Size = new System.Drawing.Size(352, 21);
            this.cmbedit.TabIndex = 33;
            this.cmbedit.Tag = "customdirectrel.edittype";
            this.cmbedit.ValueMember = "edit";
            // 
            // cmblist
            // 
            this.cmblist.DataSource = this.DS.listtype;
            this.cmblist.DisplayMember = "list";
            this.cmblist.FormattingEnabled = true;
            this.cmblist.Location = new System.Drawing.Point(496, 264);
            this.cmblist.Name = "cmblist";
            this.cmblist.Size = new System.Drawing.Size(384, 21);
            this.cmblist.TabIndex = 34;
            this.cmblist.Tag = "customdirectrel.listtype";
            this.cmblist.ValueMember = "list";
            // 
            // frmcustomdirectrel_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 541);
            this.Controls.Add(this.cmblist);
            this.Controls.Add(this.cmbedit);
            this.Controls.Add(this.ckbdefault);
            this.Controls.Add(this.ckbnavfil);
            this.Controls.Add(this.ckbinsfil);
            this.Controls.Add(this.ckbnav);
            this.Controls.Add(this.ckbins);
            this.Controls.Add(this.gboxCustomdirectrelcol);
            this.Controls.Add(this.ToTableView);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtNavFilter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtInsertFilter);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ToTable);
            this.Controls.Add(this.FromTable);
            this.Name = "frmcustomdirectrel_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "customdirectrel_default";
            this.FromTable.ResumeLayout(false);
            this.FromTable.PerformLayout();
            this.ToTable.ResumeLayout(false);
            this.ToTable.PerformLayout();
            this.ToTableView.ResumeLayout(false);
            this.ToTableView.PerformLayout();
            this.gboxCustomdirectrelcol.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.datagridCustomdirectrelcol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion

        public customdirectrel_default.dsmeta DS;
        private System.Windows.Forms.GroupBox FromTable;
        private System.Windows.Forms.TextBox txtFromTable;
        private System.Windows.Forms.GroupBox ToTable;
        private System.Windows.Forms.TextBox txtToTable;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox4;
        private Label label6;
        private TextBox txtInsertFilter;
        private Label label7;
        private TextBox txtNavFilter;
        private Label label8;
        private GroupBox ToTableView;
        private TextBox txtToTableView;
        private GroupBox gboxCustomdirectrelcol;
        private Button btnInsCustomdirectrelcol;
        private Button btnDelCustomdirectrelcol;
        private Button btnUpdCustomdirectrelcol;
        private DataGrid datagridCustomdirectrelcol;
        private CheckBox ckbnav;
        private CheckBox ckbins;
        private CheckBox ckbnavfil;
        private CheckBox ckbinsfil;
        private CheckBox ckbdefault;
        private ComboBox cmbedit;
        private ComboBox cmblist;
    }
}

