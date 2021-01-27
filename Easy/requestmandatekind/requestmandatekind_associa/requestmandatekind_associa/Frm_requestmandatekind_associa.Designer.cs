
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


namespace requestmandatekind_associa
{
    partial class Frm_requestmandatekind_associa
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
            this.DS = new requestmandatekind_associa.vistaForm();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.listResFun = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.MetaDataDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Controls.Add(this.textBox23);
            this.MetaDataDetail.Controls.Add(this.textBox24);
            this.MetaDataDetail.Controls.Add(this.label18);
            this.MetaDataDetail.Controls.Add(this.label19);
            this.MetaDataDetail.Location = new System.Drawing.Point(22, 269);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(382, 100);
            this.MetaDataDetail.TabIndex = 76;
            this.MetaDataDetail.TabStop = false;
            // 
            // textBox23
            // 
            this.textBox23.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox23.Location = new System.Drawing.Point(87, 17);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(160, 20);
            this.textBox23.TabIndex = 72;
            this.textBox23.Tag = "mandatekind_original.idmankind";
            // 
            // textBox24
            // 
            this.textBox24.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox24.Location = new System.Drawing.Point(87, 47);
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(277, 36);
            this.textBox24.TabIndex = 73;
            this.textBox24.Tag = "mandatekind_original.description";
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.Location = new System.Drawing.Point(6, 51);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 19);
            this.label18.TabIndex = 75;
            this.label18.Text = "Descrizione:";
            // 
            // label19
            // 
            this.label19.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label19.Location = new System.Drawing.Point(22, 21);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 16);
            this.label19.TabIndex = 74;
            this.label19.Text = "Codice:";
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(22, 37);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(382, 214);
            this.dataGrid1.TabIndex = 75;
            this.dataGrid1.Tag = "mandatekind_original.default";
            // 
            // listResFun
            // 
            this.listResFun.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listResFun.Location = new System.Drawing.Point(420, 37);
            this.listResFun.Name = "listResFun";
            this.listResFun.Size = new System.Drawing.Size(357, 332);
            this.listResFun.TabIndex = 74;
            this.listResFun.Tag = "mandatekind.default";
            this.listResFun.UseCompatibleStateImageBehavior = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(417, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 16);
            this.label3.TabIndex = 73;
            this.label3.Text = "Elenco dei Tipi Contratto Passivo associabili";
            // 
            // Frm_requestmandatekind_associa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 412);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.dataGrid1);
            this.Controls.Add(this.listResFun);
            this.Controls.Add(this.label3);
            this.Name = "Frm_requestmandatekind_associa";
            this.Text = "Frm_requestmandatekind_associa";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.GroupBox MetaDataDetail;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.ListView listResFun;
        private System.Windows.Forms.Label label3;

    }
}
