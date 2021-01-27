
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


namespace ct_upbfin_default {
    partial class Frn_ct_upbfin_default {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
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
        private void InitializeComponent() {
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxBilancio = new System.Windows.Forms.GroupBox();
            this.chkListTitle = new System.Windows.Forms.CheckBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.rdbEntrata = new System.Windows.Forms.RadioButton();
            this.rdbSpesa = new System.Windows.Forms.RadioButton();
            this.DS = new ct_upbfin_default.vistaForm();
            this.gboxUPB.SuspendLayout();
            this.gboxBilancio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(16, 20);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(342, 104);
            this.gboxUPB.TabIndex = 3;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(325, 20);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(126, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(207, 62);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxBilancio
            // 
            this.gboxBilancio.Controls.Add(this.chkListTitle);
            this.gboxBilancio.Controls.Add(this.txtDescrBilancio);
            this.gboxBilancio.Controls.Add(this.txtBilancio);
            this.gboxBilancio.Controls.Add(this.btnBilancio);
            this.gboxBilancio.Controls.Add(this.rdbEntrata);
            this.gboxBilancio.Controls.Add(this.rdbSpesa);
            this.gboxBilancio.Location = new System.Drawing.Point(364, 21);
            this.gboxBilancio.Name = "gboxBilancio";
            this.gboxBilancio.Size = new System.Drawing.Size(329, 103);
            this.gboxBilancio.TabIndex = 4;
            this.gboxBilancio.TabStop = false;
            this.gboxBilancio.Tag = "";
            this.gboxBilancio.Text = "Bilancio";
            // 
            // chkListTitle
            // 
            this.chkListTitle.Location = new System.Drawing.Point(8, 33);
            this.chkListTitle.Name = "chkListTitle";
            this.chkListTitle.Size = new System.Drawing.Size(151, 16);
            this.chkListTitle.TabIndex = 33;
            this.chkListTitle.TabStop = false;
            this.chkListTitle.Text = "Cerca per denominazione";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrBilancio.Location = new System.Drawing.Point(165, 14);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(158, 56);
            this.txtDescrBilancio.TabIndex = 32;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(2, 76);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(321, 20);
            this.txtBilancio.TabIndex = 6;
            this.txtBilancio.Tag = "finview.codefin?finvardetailview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.Location = new System.Drawing.Point(2, 50);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 20);
            this.btnBilancio.TabIndex = 5;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio";
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // rdbEntrata
            // 
            this.rdbEntrata.Checked = true;
            this.rdbEntrata.Location = new System.Drawing.Point(5, 15);
            this.rdbEntrata.Name = "rdbEntrata";
            this.rdbEntrata.Size = new System.Drawing.Size(64, 16);
            this.rdbEntrata.TabIndex = 0;
            this.rdbEntrata.TabStop = true;
            this.rdbEntrata.Tag = "finview.finpart:E?finvardetailview.finpart:E";
            this.rdbEntrata.Text = "Entrata";
            // 
            // rdbSpesa
            // 
            this.rdbSpesa.Location = new System.Drawing.Point(85, 15);
            this.rdbSpesa.Name = "rdbSpesa";
            this.rdbSpesa.Size = new System.Drawing.Size(64, 16);
            this.rdbSpesa.TabIndex = 1;
            this.rdbSpesa.Tag = "finview.finpart:S?finvardetailview.finpart:S";
            this.rdbSpesa.Text = "Spesa";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Frn_ct_upbfin_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 142);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.gboxBilancio);
            this.Name = "Frn_ct_upbfin_default";
            this.Text = "Frn_ct_upbfin_default";
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxBilancio.ResumeLayout(false);
            this.gboxBilancio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Button btnUPBCode;
        private System.Windows.Forms.GroupBox gboxBilancio;
        private System.Windows.Forms.CheckBox chkListTitle;
        private System.Windows.Forms.TextBox txtDescrBilancio;
        private System.Windows.Forms.TextBox txtBilancio;
        private System.Windows.Forms.Button btnBilancio;
        private System.Windows.Forms.RadioButton rdbEntrata;
        private System.Windows.Forms.RadioButton rdbSpesa;
        public vistaForm DS;
    }
}
