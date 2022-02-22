
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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


namespace ep_functions {
    partial class FrmImpegniBudget {
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
            this.gridSpesa = new System.Windows.Forms.DataGrid();
            this.btnScollegaS = new System.Windows.Forms.Button();
            this.btnCollegaS = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.DS = new ep_functions.vistaEP();
            this.chkUpb = new System.Windows.Forms.CheckBox();
            this.chkConto = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // gridSpesa
            // 
            this.gridSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSpesa.DataMember = "";
            this.gridSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridSpesa.Location = new System.Drawing.Point(12, 12);
            this.gridSpesa.Name = "gridSpesa";
            this.gridSpesa.Size = new System.Drawing.Size(839, 386);
            this.gridSpesa.TabIndex = 1;
            this.gridSpesa.Paint += new System.Windows.Forms.PaintEventHandler(this.gridSpesa_Paint);
            // 
            // btnScollegaS
            // 
            this.btnScollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnScollegaS.Location = new System.Drawing.Point(422, 404);
            this.btnScollegaS.Name = "btnScollegaS";
            this.btnScollegaS.Size = new System.Drawing.Size(181, 23);
            this.btnScollegaS.TabIndex = 7;
            this.btnScollegaS.Text = "Annulla il collegamento";
            this.btnScollegaS.Click += new System.EventHandler(this.btnScollegaS_Click);
            // 
            // btnCollegaS
            // 
            this.btnCollegaS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCollegaS.Location = new System.Drawing.Point(183, 404);
            this.btnCollegaS.Name = "btnCollegaS";
            this.btnCollegaS.Size = new System.Drawing.Size(176, 23);
            this.btnCollegaS.TabIndex = 6;
            this.btnCollegaS.Text = "Collega a movimento esistente...";
            this.btnCollegaS.Click += new System.EventHandler(this.btnCollegaS_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(776, 446);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 15;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(671, 446);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // chkUpb
            // 
            this.chkUpb.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkUpb.Checked = true;
            this.chkUpb.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUpb.Location = new System.Drawing.Point(12, 467);
            this.chkUpb.Name = "chkUpb";
            this.chkUpb.Size = new System.Drawing.Size(472, 22);
            this.chkUpb.TabIndex = 17;
            this.chkUpb.Text = "Scegli il movimento a cui collegare l\'impegno tra quelli con lo stesso UPB";
            this.chkUpb.Visible = false;
            // 
            // chkConto
            // 
            this.chkConto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkConto.Checked = true;
            this.chkConto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkConto.Location = new System.Drawing.Point(12, 446);
            this.chkConto.Name = "chkConto";
            this.chkConto.Size = new System.Drawing.Size(472, 19);
            this.chkConto.TabIndex = 16;
            this.chkConto.Text = "Scegli il movimento a cui collegare l\'impegno tra quelli con lo stesso conto";
            this.chkConto.Visible = false;
            // 
            // FrmImpegniBudget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 502);
            this.Controls.Add(this.chkUpb);
            this.Controls.Add(this.chkConto);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnScollegaS);
            this.Controls.Add(this.btnCollegaS);
            this.Controls.Add(this.gridSpesa);
            this.Name = "FrmImpegniBudget";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmImpegniBudget";
            ((System.ComponentModel.ISupportInitialize)(this.gridSpesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid gridSpesa;
        private System.Windows.Forms.Button btnScollegaS;
        private System.Windows.Forms.Button btnCollegaS;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private vistaEP DS;
        private System.Windows.Forms.CheckBox chkUpb;
        private System.Windows.Forms.CheckBox chkConto;
    }
}
