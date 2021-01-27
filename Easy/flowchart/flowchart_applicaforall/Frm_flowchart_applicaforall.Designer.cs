
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


namespace flowchart_applicaforall
{
    partial class Frm_flowchart_applicaforall
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
            this.DS = new flowchart_applicaforall.vistaForm();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApplica = new System.Windows.Forms.Button();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(277, 53);
            this.label1.TabIndex = 3;
            this.label1.Text = "Procedura che applica le restrizioni impostate sull\'organigramma nella gestione d" +
                "ella sicurezza a tutti i dipartimenti del DataBase.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnApplica
            // 
            this.btnApplica.Location = new System.Drawing.Point(99, 123);
            this.btnApplica.Name = "btnApplica";
            this.btnApplica.Size = new System.Drawing.Size(75, 23);
            this.btnApplica.TabIndex = 2;
            this.btnApplica.Text = "Applica";
            this.btnApplica.UseVisualStyleBackColor = true;
            this.btnApplica.Click += new System.EventHandler(this.btnApplica_Click);
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(101, 64);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.Size = new System.Drawing.Size(123, 20);
            this.txtpassword.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Password";
            // 
            // Frm_flowchart_applicaforall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 155);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnApplica);
            this.Name = "Frm_flowchart_applicaforall";
            this.Text = "Frm_flowchart_applicaforall";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApplica;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtpassword;

    }
}
