
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


namespace no_table_formconverter
{
    partial class frm_formconverter
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
            this.txtDLLName = new System.Windows.Forms.TextBox();
            this.txtOutFileName = new System.Windows.Forms.TextBox();
            this.btnProceed = new System.Windows.Forms.Button();
            this.lblDLLName = new System.Windows.Forms.Label();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.lblNameSpace = new System.Windows.Forms.Label();
            this.DS = new no_table_formconverter.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDLLName
            // 
            this.txtDLLName.Location = new System.Drawing.Point(136, 29);
            this.txtDLLName.Name = "txtDLLName";
            this.txtDLLName.Size = new System.Drawing.Size(179, 20);
            this.txtDLLName.TabIndex = 0;
            // 
            // txtOutFileName
            // 
            this.txtOutFileName.Location = new System.Drawing.Point(136, 55);
            this.txtOutFileName.Name = "txtOutFileName";
            this.txtOutFileName.Size = new System.Drawing.Size(179, 20);
            this.txtOutFileName.TabIndex = 2;
            this.txtOutFileName.Text = "C:\\OutFile.aspx";
            // 
            // btnProceed
            // 
            this.btnProceed.Location = new System.Drawing.Point(253, 91);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 3;
            this.btnProceed.Text = "Procedi";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // lblDLLName
            // 
            this.lblDLLName.AutoSize = true;
            this.lblDLLName.Location = new System.Drawing.Point(66, 36);
            this.lblDLLName.Name = "lblDLLName";
            this.lblDLLName.Size = new System.Drawing.Size(61, 13);
            this.lblDLLName.TabIndex = 4;
            this.lblDLLName.Text = "Nome DLL:";
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.AutoSize = true;
            this.lblOutputFile.Location = new System.Drawing.Point(55, 62);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(72, 13);
            this.lblOutputFile.TabIndex = 6;
            this.lblOutputFile.Text = "File di Output:";
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(66, 9);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(247, 13);
            this.lblHeader.TabIndex = 7;
            this.lblHeader.Text = "Specificare nell\'apposita TextBox il nome della DLL";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(136, 91);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(100, 20);
            this.txtNameSpace.TabIndex = 8;
            this.txtNameSpace.Text = "HelpWeb";
            // 
            // lblNameSpace
            // 
            this.lblNameSpace.AutoSize = true;
            this.lblNameSpace.Location = new System.Drawing.Point(14, 96);
            this.lblNameSpace.Name = "lblNameSpace";
            this.lblNameSpace.Size = new System.Drawing.Size(109, 13);
            this.lblNameSpace.TabIndex = 9;
            this.lblNameSpace.Text = "Prefisso NameSpace:";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("it-IT");
            // 
            // frm_formconverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 126);
            this.Controls.Add(this.lblNameSpace);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.lblHeader);
            this.Controls.Add(this.lblOutputFile);
            this.Controls.Add(this.lblDLLName);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.txtOutFileName);
            this.Controls.Add(this.txtDLLName);
            this.MaximizeBox = false;
            this.Name = "frm_formconverter";
            this.Text = "frmno_table_formconverter";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDLLName;
        private System.Windows.Forms.TextBox txtOutFileName;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Label lblDLLName;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label lblNameSpace;
        public vistaForm DS;
    }
}
