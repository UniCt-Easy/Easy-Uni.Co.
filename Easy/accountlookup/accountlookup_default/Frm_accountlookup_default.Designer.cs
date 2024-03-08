
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


namespace accountlookup_default
{
    partial class Frm_accountlookup_default
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
            this.grpAnnoSuccessivo = new System.Windows.Forms.GroupBox();
            this.grpPianoContiSucc = new System.Windows.Forms.GroupBox();
            this.txtNewPianoConti = new System.Windows.Forms.TextBox();
            this.btnNewPianoConti = new System.Windows.Forms.Button();
            this.grpAnnoCorrente = new System.Windows.Forms.GroupBox();
            this.grpPianoContiCorr = new System.Windows.Forms.GroupBox();
            this.txtPianoConti = new System.Windows.Forms.TextBox();
            this.btnPianoConti = new System.Windows.Forms.Button();
            this.DS = new accountlookup_default.vistaForm();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.grpAnnoSuccessivo.SuspendLayout();
            this.grpPianoContiSucc.SuspendLayout();
            this.grpAnnoCorrente.SuspendLayout();
            this.grpPianoContiCorr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpAnnoSuccessivo
            // 
            this.grpAnnoSuccessivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnnoSuccessivo.Controls.Add(this.grpPianoContiSucc);
            this.grpAnnoSuccessivo.Location = new System.Drawing.Point(13, 114);
            this.grpAnnoSuccessivo.Name = "grpAnnoSuccessivo";
            this.grpAnnoSuccessivo.Size = new System.Drawing.Size(432, 100);
            this.grpAnnoSuccessivo.TabIndex = 3;
            this.grpAnnoSuccessivo.TabStop = false;
            this.grpAnnoSuccessivo.Text = "Anno Successivo";
            // 
            // grpPianoContiSucc
            // 
            this.grpPianoContiSucc.Controls.Add(this.textBox2);
            this.grpPianoContiSucc.Controls.Add(this.txtNewPianoConti);
            this.grpPianoContiSucc.Controls.Add(this.btnNewPianoConti);
            this.grpPianoContiSucc.Location = new System.Drawing.Point(5, 16);
            this.grpPianoContiSucc.Name = "grpPianoContiSucc";
            this.grpPianoContiSucc.Size = new System.Drawing.Size(424, 78);
            this.grpPianoContiSucc.TabIndex = 0;
            this.grpPianoContiSucc.TabStop = false;
            this.grpPianoContiSucc.Tag = "AutoManage.txtNewPianoConti.treenew";
            this.grpPianoContiSucc.Text = "Nuovo Codice Conto";
            // 
            // txtNewPianoConti
            // 
            this.txtNewPianoConti.Location = new System.Drawing.Point(88, 30);
            this.txtNewPianoConti.Name = "txtNewPianoConti";
            this.txtNewPianoConti.Size = new System.Drawing.Size(100, 20);
            this.txtNewPianoConti.TabIndex = 2;
            this.txtNewPianoConti.Tag = "account1.codeacc?accountlookupview.newcodeacc";
            // 
            // btnNewPianoConti
            // 
            this.btnNewPianoConti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewPianoConti.ImageIndex = 0;
            this.btnNewPianoConti.Location = new System.Drawing.Point(8, 30);
            this.btnNewPianoConti.Name = "btnNewPianoConti";
            this.btnNewPianoConti.Size = new System.Drawing.Size(75, 23);
            this.btnNewPianoConti.TabIndex = 1;
            this.btnNewPianoConti.TabStop = false;
            this.btnNewPianoConti.Tag = "manage.account1.treenew";
            this.btnNewPianoConti.Text = "Conto";
            this.btnNewPianoConti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpAnnoCorrente
            // 
            this.grpAnnoCorrente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAnnoCorrente.Controls.Add(this.grpPianoContiCorr);
            this.grpAnnoCorrente.Location = new System.Drawing.Point(13, 10);
            this.grpAnnoCorrente.Name = "grpAnnoCorrente";
            this.grpAnnoCorrente.Size = new System.Drawing.Size(432, 100);
            this.grpAnnoCorrente.TabIndex = 2;
            this.grpAnnoCorrente.TabStop = false;
            this.grpAnnoCorrente.Text = "Anno Corrente";
            // 
            // grpPianoContiCorr
            // 
            this.grpPianoContiCorr.Controls.Add(this.textBox1);
            this.grpPianoContiCorr.Controls.Add(this.txtPianoConti);
            this.grpPianoContiCorr.Controls.Add(this.btnPianoConti);
            this.grpPianoContiCorr.Location = new System.Drawing.Point(8, 18);
            this.grpPianoContiCorr.Name = "grpPianoContiCorr";
            this.grpPianoContiCorr.Size = new System.Drawing.Size(421, 77);
            this.grpPianoContiCorr.TabIndex = 0;
            this.grpPianoContiCorr.TabStop = false;
            this.grpPianoContiCorr.Tag = "AutoManage.txtPianoConti.tree";
            this.grpPianoContiCorr.Text = "Codice  Conto Attuale";
            // 
            // txtPianoConti
            // 
            this.txtPianoConti.Location = new System.Drawing.Point(88, 32);
            this.txtPianoConti.Name = "txtPianoConti";
            this.txtPianoConti.Size = new System.Drawing.Size(100, 20);
            this.txtPianoConti.TabIndex = 3;
            this.txtPianoConti.Tag = "account.codeacc?accountlookupview.oldcodeacc";
            // 
            // btnPianoConti
            // 
            this.btnPianoConti.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPianoConti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPianoConti.ImageIndex = 0;
            this.btnPianoConti.Location = new System.Drawing.Point(8, 32);
            this.btnPianoConti.Name = "btnPianoConti";
            this.btnPianoConti.Size = new System.Drawing.Size(75, 23);
            this.btnPianoConti.TabIndex = 2;
            this.btnPianoConti.Tag = "manage.account.tree";
            this.btnPianoConti.Text = "Conto";
            this.btnPianoConti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(214, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(200, 53);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            this.textBox2.Tag = "account1.title?accountlookupview.newtitle";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(210, 16);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(206, 52);
            this.textBox1.TabIndex = 4;
            this.textBox1.TabStop = false;
            this.textBox1.Tag = "account.title?accountlookupview.oldtitle";
            // 
            // Frm_accountlookup_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 227);
            this.Controls.Add(this.grpAnnoSuccessivo);
            this.Controls.Add(this.grpAnnoCorrente);
            this.Name = "Frm_accountlookup_default";
            this.Text = "Form1";
            this.grpAnnoSuccessivo.ResumeLayout(false);
            this.grpPianoContiSucc.ResumeLayout(false);
            this.grpPianoContiSucc.PerformLayout();
            this.grpAnnoCorrente.ResumeLayout(false);
            this.grpPianoContiCorr.ResumeLayout(false);
            this.grpPianoContiCorr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.GroupBox grpAnnoSuccessivo;
        private System.Windows.Forms.GroupBox grpPianoContiSucc;
        private System.Windows.Forms.TextBox txtNewPianoConti;
        private System.Windows.Forms.Button btnNewPianoConti;
        private System.Windows.Forms.GroupBox grpAnnoCorrente;
        private System.Windows.Forms.GroupBox grpPianoContiCorr;
        private System.Windows.Forms.TextBox txtPianoConti;
        private System.Windows.Forms.Button btnPianoConti;
        public vistaForm DS;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
    }
}
