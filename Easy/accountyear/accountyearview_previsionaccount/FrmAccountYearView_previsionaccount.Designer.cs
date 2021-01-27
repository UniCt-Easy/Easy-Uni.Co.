
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


namespace accountyearview_previsionaccount
{
    partial class FrmAccountYearView_previsionaccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing){
            inChiusura = true;
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.grpImporto5 = new System.Windows.Forms.GroupBox();
            this.txtImporto5 = new System.Windows.Forms.TextBox();
            this.grpImporto4 = new System.Windows.Forms.GroupBox();
            this.txtImporto4 = new System.Windows.Forms.TextBox();
            this.grpImporto3 = new System.Windows.Forms.GroupBox();
            this.txtImporto3 = new System.Windows.Forms.TextBox();
            this.grpImporto2 = new System.Windows.Forms.GroupBox();
            this.txtImporto2 = new System.Windows.Forms.TextBox();
            this.grpImporto1 = new System.Windows.Forms.GroupBox();
            this.txtImporto1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.txtDenominazioneConto = new System.Windows.Forms.TextBox();
            this.txtCodiceConto = new System.Windows.Forms.TextBox();
            this.btnConto = new System.Windows.Forms.Button();
            this.DS = new accountyearview_previsionaccount.vistaForm();
            this.grpImporto5.SuspendLayout();
            this.grpImporto4.SuspendLayout();
            this.grpImporto3.SuspendLayout();
            this.grpImporto2.SuspendLayout();
            this.grpImporto1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(639, 190);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 21;
            this.btnOK.Tag = "mainsave";
            this.btnOK.Text = "OK";
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(743, 190);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 22;
            this.btnAnnulla.Text = "Annulla";
            // 
            // grpImporto5
            // 
            this.grpImporto5.Controls.Add(this.txtImporto5);
            this.grpImporto5.Location = new System.Drawing.Point(673, 130);
            this.grpImporto5.Name = "grpImporto5";
            this.grpImporto5.Size = new System.Drawing.Size(148, 48);
            this.grpImporto5.TabIndex = 28;
            this.grpImporto5.TabStop = false;
            this.grpImporto5.Tag = "";
            this.grpImporto5.Text = "Budget anno";
            // 
            // txtImporto5
            // 
            this.txtImporto5.Location = new System.Drawing.Point(6, 18);
            this.txtImporto5.Name = "txtImporto5";
            this.txtImporto5.Size = new System.Drawing.Size(104, 20);
            this.txtImporto5.TabIndex = 1;
            this.txtImporto5.Tag = "accountyearview.prevision5";
            // 
            // grpImporto4
            // 
            this.grpImporto4.Controls.Add(this.txtImporto4);
            this.grpImporto4.Location = new System.Drawing.Point(509, 130);
            this.grpImporto4.Name = "grpImporto4";
            this.grpImporto4.Size = new System.Drawing.Size(148, 48);
            this.grpImporto4.TabIndex = 27;
            this.grpImporto4.TabStop = false;
            this.grpImporto4.Tag = "";
            this.grpImporto4.Text = "Budget anno";
            // 
            // txtImporto4
            // 
            this.txtImporto4.Location = new System.Drawing.Point(6, 18);
            this.txtImporto4.Name = "txtImporto4";
            this.txtImporto4.Size = new System.Drawing.Size(104, 20);
            this.txtImporto4.TabIndex = 1;
            this.txtImporto4.Tag = "accountyearview.prevision4";
            // 
            // grpImporto3
            // 
            this.grpImporto3.Controls.Add(this.txtImporto3);
            this.grpImporto3.Location = new System.Drawing.Point(342, 130);
            this.grpImporto3.Name = "grpImporto3";
            this.grpImporto3.Size = new System.Drawing.Size(148, 48);
            this.grpImporto3.TabIndex = 26;
            this.grpImporto3.TabStop = false;
            this.grpImporto3.Tag = "";
            this.grpImporto3.Text = "Budget anno";
            // 
            // txtImporto3
            // 
            this.txtImporto3.Location = new System.Drawing.Point(6, 18);
            this.txtImporto3.Name = "txtImporto3";
            this.txtImporto3.Size = new System.Drawing.Size(104, 20);
            this.txtImporto3.TabIndex = 1;
            this.txtImporto3.Tag = "accountyearview.prevision3";
            // 
            // grpImporto2
            // 
            this.grpImporto2.Controls.Add(this.txtImporto2);
            this.grpImporto2.Location = new System.Drawing.Point(176, 130);
            this.grpImporto2.Name = "grpImporto2";
            this.grpImporto2.Size = new System.Drawing.Size(148, 48);
            this.grpImporto2.TabIndex = 25;
            this.grpImporto2.TabStop = false;
            this.grpImporto2.Tag = "";
            this.grpImporto2.Text = "Budget anno";
            // 
            // txtImporto2
            // 
            this.txtImporto2.Location = new System.Drawing.Point(6, 18);
            this.txtImporto2.Name = "txtImporto2";
            this.txtImporto2.Size = new System.Drawing.Size(104, 20);
            this.txtImporto2.TabIndex = 1;
            this.txtImporto2.Tag = "accountyearview.prevision2";
            // 
            // grpImporto1
            // 
            this.grpImporto1.Controls.Add(this.txtImporto1);
            this.grpImporto1.Location = new System.Drawing.Point(12, 130);
            this.grpImporto1.Name = "grpImporto1";
            this.grpImporto1.Size = new System.Drawing.Size(148, 48);
            this.grpImporto1.TabIndex = 24;
            this.grpImporto1.TabStop = false;
            this.grpImporto1.Tag = "";
            this.grpImporto1.Text = "Budget anno";
            // 
            // txtImporto1
            // 
            this.txtImporto1.Location = new System.Drawing.Point(6, 18);
            this.txtImporto1.Name = "txtImporto1";
            this.txtImporto1.Size = new System.Drawing.Size(104, 20);
            this.txtImporto1.TabIndex = 1;
            this.txtImporto1.Tag = "accountyearview.prevision";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkListTitle);
            this.groupBox1.Controls.Add(this.txtDenominazioneConto);
            this.groupBox1.Controls.Add(this.txtCodiceConto);
            this.groupBox1.Controls.Add(this.btnConto);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 113);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(5, 8);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(155, 19);
            this.chkListTitle.TabIndex = 57;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // txtDenominazioneConto
            // 
            this.txtDenominazioneConto.Location = new System.Drawing.Point(134, 27);
            this.txtDenominazioneConto.Multiline = true;
            this.txtDenominazioneConto.Name = "txtDenominazioneConto";
            this.txtDenominazioneConto.ReadOnly = true;
            this.txtDenominazioneConto.Size = new System.Drawing.Size(172, 56);
            this.txtDenominazioneConto.TabIndex = 2;
            this.txtDenominazioneConto.TabStop = false;
            this.txtDenominazioneConto.Tag = "accountminusable.title";
            // 
            // txtCodiceConto
            // 
            this.txtCodiceConto.Location = new System.Drawing.Point(6, 87);
            this.txtCodiceConto.Name = "txtCodiceConto";
            this.txtCodiceConto.Size = new System.Drawing.Size(300, 20);
            this.txtCodiceConto.TabIndex = 1;
            this.txtCodiceConto.Tag = "accountminusable.codeacc?x";
            this.txtCodiceConto.Enter += new System.EventHandler(this.textBox2_Enter);
            this.txtCodiceConto.Leave += new System.EventHandler(this.txtCodiceConto_Leave);
            // 
            // btnConto
            // 
            this.btnConto.Location = new System.Drawing.Point(8, 57);
            this.btnConto.Name = "btnConto";
            this.btnConto.Size = new System.Drawing.Size(120, 23);
            this.btnConto.TabIndex = 0;
            this.btnConto.TabStop = false;
            this.btnConto.Tag = "";
            this.btnConto.Text = "Conto";
            this.btnConto.Click += new System.EventHandler(this.btnConto_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // FrmAccountYearView_previsionaccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 227);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpImporto5);
            this.Controls.Add(this.grpImporto4);
            this.Controls.Add(this.grpImporto3);
            this.Controls.Add(this.grpImporto2);
            this.Controls.Add(this.grpImporto1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnAnnulla);
            this.Name = "FrmAccountYearView_previsionaccount";
            this.Text = "FrmAccountYearView_previsionaccount";
            this.grpImporto5.ResumeLayout(false);
            this.grpImporto5.PerformLayout();
            this.grpImporto4.ResumeLayout(false);
            this.grpImporto4.PerformLayout();
            this.grpImporto3.ResumeLayout(false);
            this.grpImporto3.PerformLayout();
            this.grpImporto2.ResumeLayout(false);
            this.grpImporto2.PerformLayout();
            this.grpImporto1.ResumeLayout(false);
            this.grpImporto1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.GroupBox grpImporto5;
        private System.Windows.Forms.TextBox txtImporto5;
        private System.Windows.Forms.GroupBox grpImporto4;
        private System.Windows.Forms.TextBox txtImporto4;
        private System.Windows.Forms.GroupBox grpImporto3;
        private System.Windows.Forms.TextBox txtImporto3;
        private System.Windows.Forms.GroupBox grpImporto2;
        private System.Windows.Forms.TextBox txtImporto2;
        private System.Windows.Forms.GroupBox grpImporto1;
        private System.Windows.Forms.TextBox txtImporto1;
        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.TextBox txtDenominazioneConto;
        private System.Windows.Forms.TextBox txtCodiceConto;
        private System.Windows.Forms.Button btnConto;
    }
}
