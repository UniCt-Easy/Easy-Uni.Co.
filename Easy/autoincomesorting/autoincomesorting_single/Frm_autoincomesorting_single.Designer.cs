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

namespace autoincomesorting_single
{
    partial class Frm_autoincomesorting_single
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
            this.DS = new autoincomesorting_single.vistaForm();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtDenominatore = new System.Windows.Forms.TextBox();
            this.btnCodiceMov = new System.Windows.Forms.Button();
            this.TxtNumeratore = new System.Windows.Forms.TextBox();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.labelignoradate = new System.Windows.Forms.Label();
            this.txtCodiceMov = new System.Windows.Forms.TextBox();
            this.txtDescrizioneMov = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
            this.gboxClassMov = new System.Windows.Forms.GroupBox();
            this.cmbTipoMov = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gboxClassMov.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(48, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 8);
            this.label4.TabIndex = 262;
            this.label4.Text = "__________________________";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // TxtDenominatore
            // 
            this.TxtDenominatore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDenominatore.Location = new System.Drawing.Point(72, 200);
            this.TxtDenominatore.Name = "TxtDenominatore";
            this.TxtDenominatore.Size = new System.Drawing.Size(80, 22);
            this.TxtDenominatore.TabIndex = 5;
            this.TxtDenominatore.Tag = "autoincomesorting.denominator";
            this.TxtDenominatore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCodiceMov
            // 
            this.btnCodiceMov.Location = new System.Drawing.Point(8, 8);
            this.btnCodiceMov.Name = "btnCodiceMov";
            this.btnCodiceMov.Size = new System.Drawing.Size(72, 23);
            this.btnCodiceMov.TabIndex = 2;
            this.btnCodiceMov.TabStop = false;
            this.btnCodiceMov.Tag = "manage.sorting.tree";
            this.btnCodiceMov.Text = "Codice";
            this.btnCodiceMov.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // TxtNumeratore
            // 
            this.TxtNumeratore.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtNumeratore.Location = new System.Drawing.Point(72, 160);
            this.TxtNumeratore.Name = "TxtNumeratore";
            this.TxtNumeratore.Size = new System.Drawing.Size(80, 22);
            this.TxtNumeratore.TabIndex = 4;
            this.TxtNumeratore.Tag = "autoincomesorting.numerator";
            this.TxtNumeratore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentuale.Location = new System.Drawing.Point(40, 144);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(160, 16);
            this.lblPercentuale.TabIndex = 260;
            this.lblPercentuale.Text = "Porzione da classificare";
            // 
            // labelignoradate
            // 
            this.labelignoradate.Location = new System.Drawing.Point(32, 112);
            this.labelignoradate.Name = "labelignoradate";
            this.labelignoradate.Size = new System.Drawing.Size(240, 16);
            this.labelignoradate.TabIndex = 3;
            this.labelignoradate.Tag = "";
            this.labelignoradate.Text = "ignora date custom";
            // 
            // txtCodiceMov
            // 
            this.txtCodiceMov.Location = new System.Drawing.Point(8, 32);
            this.txtCodiceMov.Name = "txtCodiceMov";
            this.txtCodiceMov.Size = new System.Drawing.Size(112, 20);
            this.txtCodiceMov.TabIndex = 1;
            this.txtCodiceMov.Tag = "sorting.sortcode?autoincomesortingview.sortingcode";
            // 
            // txtDescrizioneMov
            // 
            this.txtDescrizioneMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizioneMov.Location = new System.Drawing.Point(128, 8);
            this.txtDescrizioneMov.Multiline = true;
            this.txtDescrizioneMov.Name = "txtDescrizioneMov";
            this.txtDescrizioneMov.ReadOnly = true;
            this.txtDescrizioneMov.Size = new System.Drawing.Size(260, 48);
            this.txtDescrizioneMov.TabIndex = 6;
            this.txtDescrizioneMov.TabStop = false;
            this.txtDescrizioneMov.Tag = "sorting.description";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(313, 324);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 23;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(409, 324);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 24;
            this.btnAnnulla.Text = "Annulla";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.TxtDenominatore);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.TxtNumeratore);
            this.groupBox3.Controls.Add(this.lblPercentuale);
            this.groupBox3.Controls.Add(this.labelignoradate);
            this.groupBox3.Controls.Add(this.chkIgnoraDate);
            this.groupBox3.Controls.Add(this.gboxClassMov);
            this.groupBox3.Controls.Add(this.cmbTipoMov);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(9, 71);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(478, 247);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "";
            this.groupBox3.Text = "Classificazione movimento";
            // 
            // chkIgnoraDate
            // 
            this.chkIgnoraDate.Location = new System.Drawing.Point(8, 112);
            this.chkIgnoraDate.Name = "chkIgnoraDate";
            this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
            this.chkIgnoraDate.TabIndex = 3;
            this.chkIgnoraDate.Tag = "autoincomesorting.flagnodate:S:N";
            // 
            // gboxClassMov
            // 
            this.gboxClassMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxClassMov.Controls.Add(this.txtDescrizioneMov);
            this.gboxClassMov.Controls.Add(this.txtCodiceMov);
            this.gboxClassMov.Controls.Add(this.btnCodiceMov);
            this.gboxClassMov.Location = new System.Drawing.Point(8, 40);
            this.gboxClassMov.Name = "gboxClassMov";
            this.gboxClassMov.Size = new System.Drawing.Size(396, 64);
            this.gboxClassMov.TabIndex = 2;
            this.gboxClassMov.TabStop = false;
            this.gboxClassMov.Tag = "AutoManage.txtCodiceMov.tree";
            // 
            // cmbTipoMov
            // 
            this.cmbTipoMov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbTipoMov.DataSource = this.DS.sortingkind;
            this.cmbTipoMov.DisplayMember = "description";
            this.cmbTipoMov.Location = new System.Drawing.Point(70, 16);
            this.cmbTipoMov.Name = "cmbTipoMov";
            this.cmbTipoMov.Size = new System.Drawing.Size(334, 21);
            this.cmbTipoMov.TabIndex = 1;
            this.cmbTipoMov.Tag = "autoincomesorting.idsorkind";
            this.cmbTipoMov.ValueMember = "idsorkind";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tipo:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // Frm_autoincomesorting_single
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(496, 357);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.groupBox3);
            this.Name = "Frm_autoincomesorting_single";
            this.Text = "Frm_autoincomesorting_single";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gboxClassMov.ResumeLayout(false);
            this.gboxClassMov.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtDenominatore;
        private System.Windows.Forms.Button btnCodiceMov;
        private System.Windows.Forms.TextBox TxtNumeratore;
        private System.Windows.Forms.Label lblPercentuale;
        public System.Windows.Forms.Label labelignoradate;
        private System.Windows.Forms.TextBox txtCodiceMov;
        private System.Windows.Forms.TextBox txtDescrizioneMov;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox chkIgnoraDate;
        private System.Windows.Forms.GroupBox gboxClassMov;
        private System.Windows.Forms.ComboBox cmbTipoMov;
        private System.Windows.Forms.Label label2;

    }
}