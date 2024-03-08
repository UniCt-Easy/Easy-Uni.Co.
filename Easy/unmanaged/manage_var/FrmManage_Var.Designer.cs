
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


namespace manage_var {
    partial class FrmManage_Var {
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabVarEntrata = new System.Windows.Forms.TabPage();
            this.grpClassEntrata = new System.Windows.Forms.GroupBox();
            this.btnDeleteClassI = new System.Windows.Forms.Button();
            this.btnUpdateClassI = new System.Windows.Forms.Button();
            this.btnInsertClassI = new System.Windows.Forms.Button();
            this.dgClassEntrata = new System.Windows.Forms.DataGrid();
            this.grpVarEntrata = new System.Windows.Forms.GroupBox();
            this.dgVarEntrata = new System.Windows.Forms.DataGrid();
            this.tabVarSpesa = new System.Windows.Forms.TabPage();
            this.grpClassSpesa = new System.Windows.Forms.GroupBox();
            this.btnDeleteClassE = new System.Windows.Forms.Button();
            this.btnUpdateClassE = new System.Windows.Forms.Button();
            this.btnInsertClassE = new System.Windows.Forms.Button();
            this.dgClassSpesa = new System.Windows.Forms.DataGrid();
            this.grpVarSpesa = new System.Windows.Forms.GroupBox();
            this.dgVarSpesa = new System.Windows.Forms.DataGrid();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.dsMov = new manage_var.dsMov();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabVarEntrata.SuspendLayout();
            this.grpClassEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClassEntrata)).BeginInit();
            this.grpVarEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVarEntrata)).BeginInit();
            this.tabVarSpesa.SuspendLayout();
            this.grpClassSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgClassSpesa)).BeginInit();
            this.grpVarSpesa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVarSpesa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMov)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tabVarEntrata);
            this.tabControl1.Controls.Add(this.tabVarSpesa);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(531, 439);
            this.tabControl1.TabIndex = 0;
            // 
            // tabVarEntrata
            // 
            this.tabVarEntrata.Controls.Add(this.grpClassEntrata);
            this.tabVarEntrata.Controls.Add(this.grpVarEntrata);
            this.tabVarEntrata.Location = new System.Drawing.Point(4, 25);
            this.tabVarEntrata.Name = "tabVarEntrata";
            this.tabVarEntrata.Padding = new System.Windows.Forms.Padding(3);
            this.tabVarEntrata.Size = new System.Drawing.Size(523, 410);
            this.tabVarEntrata.TabIndex = 0;
            this.tabVarEntrata.Text = "Var. Entrata";
            this.tabVarEntrata.UseVisualStyleBackColor = true;
            // 
            // grpClassEntrata
            // 
            this.grpClassEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassEntrata.Controls.Add(this.btnDeleteClassI);
            this.grpClassEntrata.Controls.Add(this.btnUpdateClassI);
            this.grpClassEntrata.Controls.Add(this.btnInsertClassI);
            this.grpClassEntrata.Controls.Add(this.dgClassEntrata);
            this.grpClassEntrata.Location = new System.Drawing.Point(6, 172);
            this.grpClassEntrata.Name = "grpClassEntrata";
            this.grpClassEntrata.Size = new System.Drawing.Size(511, 232);
            this.grpClassEntrata.TabIndex = 1;
            this.grpClassEntrata.TabStop = false;
            this.grpClassEntrata.Text = "Classificazioni";
            // 
            // btnDeleteClassI
            // 
            this.btnDeleteClassI.Location = new System.Drawing.Point(198, 19);
            this.btnDeleteClassI.Name = "btnDeleteClassI";
            this.btnDeleteClassI.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteClassI.TabIndex = 11;
            this.btnDeleteClassI.Text = "Cancella";
            this.btnDeleteClassI.Click += new System.EventHandler(this.btnDeleteClassI_Click);
            // 
            // btnUpdateClassI
            // 
            this.btnUpdateClassI.Location = new System.Drawing.Point(102, 19);
            this.btnUpdateClassI.Name = "btnUpdateClassI";
            this.btnUpdateClassI.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateClassI.TabIndex = 10;
            this.btnUpdateClassI.Text = "Correggi";
            this.btnUpdateClassI.Click += new System.EventHandler(this.btnUpdateClassI_Click);
            // 
            // btnInsertClassI
            // 
            this.btnInsertClassI.Location = new System.Drawing.Point(6, 19);
            this.btnInsertClassI.Name = "btnInsertClassI";
            this.btnInsertClassI.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClassI.TabIndex = 9;
            this.btnInsertClassI.Text = "Inserisci";
            this.btnInsertClassI.Click += new System.EventHandler(this.btnInsertClassI_Click);
            // 
            // dgClassEntrata
            // 
            this.dgClassEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgClassEntrata.DataMember = "";
            this.dgClassEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClassEntrata.Location = new System.Drawing.Point(6, 48);
            this.dgClassEntrata.Name = "dgClassEntrata";
            this.dgClassEntrata.Size = new System.Drawing.Size(499, 178);
            this.dgClassEntrata.TabIndex = 0;
            // 
            // grpVarEntrata
            // 
            this.grpVarEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVarEntrata.Controls.Add(this.dgVarEntrata);
            this.grpVarEntrata.Location = new System.Drawing.Point(6, 6);
            this.grpVarEntrata.Name = "grpVarEntrata";
            this.grpVarEntrata.Size = new System.Drawing.Size(511, 160);
            this.grpVarEntrata.TabIndex = 0;
            this.grpVarEntrata.TabStop = false;
            this.grpVarEntrata.Text = "Variazioni";
            // 
            // dgVarEntrata
            // 
            this.dgVarEntrata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVarEntrata.DataMember = "";
            this.dgVarEntrata.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVarEntrata.Location = new System.Drawing.Point(6, 19);
            this.dgVarEntrata.Name = "dgVarEntrata";
            this.dgVarEntrata.Size = new System.Drawing.Size(499, 135);
            this.dgVarEntrata.TabIndex = 0;
            this.dgVarEntrata.DoubleClick += new System.EventHandler(this.dgVarEntrata_DoubleClick);
            this.dgVarEntrata.CurrentCellChanged += new System.EventHandler(this.dgVarEntrata_CurrentCellChanged);
            // 
            // tabVarSpesa
            // 
            this.tabVarSpesa.Controls.Add(this.label1);
            this.tabVarSpesa.Controls.Add(this.grpClassSpesa);
            this.tabVarSpesa.Controls.Add(this.grpVarSpesa);
            this.tabVarSpesa.Location = new System.Drawing.Point(4, 25);
            this.tabVarSpesa.Name = "tabVarSpesa";
            this.tabVarSpesa.Padding = new System.Windows.Forms.Padding(3);
            this.tabVarSpesa.Size = new System.Drawing.Size(523, 410);
            this.tabVarSpesa.TabIndex = 1;
            this.tabVarSpesa.Text = "Var. Spesa";
            this.tabVarSpesa.UseVisualStyleBackColor = true;
            // 
            // grpClassSpesa
            // 
            this.grpClassSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClassSpesa.Controls.Add(this.btnDeleteClassE);
            this.grpClassSpesa.Controls.Add(this.btnUpdateClassE);
            this.grpClassSpesa.Controls.Add(this.btnInsertClassE);
            this.grpClassSpesa.Controls.Add(this.dgClassSpesa);
            this.grpClassSpesa.Location = new System.Drawing.Point(6, 194);
            this.grpClassSpesa.Name = "grpClassSpesa";
            this.grpClassSpesa.Size = new System.Drawing.Size(511, 210);
            this.grpClassSpesa.TabIndex = 3;
            this.grpClassSpesa.TabStop = false;
            this.grpClassSpesa.Text = "Classificazioni";
            // 
            // btnDeleteClassE
            // 
            this.btnDeleteClassE.Location = new System.Drawing.Point(198, 19);
            this.btnDeleteClassE.Name = "btnDeleteClassE";
            this.btnDeleteClassE.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteClassE.TabIndex = 15;
            this.btnDeleteClassE.Text = "Cancella";
            this.btnDeleteClassE.Click += new System.EventHandler(this.btnDeleteClassE_Click);
            // 
            // btnUpdateClassE
            // 
            this.btnUpdateClassE.Location = new System.Drawing.Point(102, 19);
            this.btnUpdateClassE.Name = "btnUpdateClassE";
            this.btnUpdateClassE.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateClassE.TabIndex = 14;
            this.btnUpdateClassE.Text = "Correggi";
            this.btnUpdateClassE.Click += new System.EventHandler(this.btnUpdateClassE_Click);
            // 
            // btnInsertClassE
            // 
            this.btnInsertClassE.Location = new System.Drawing.Point(6, 19);
            this.btnInsertClassE.Name = "btnInsertClassE";
            this.btnInsertClassE.Size = new System.Drawing.Size(75, 23);
            this.btnInsertClassE.TabIndex = 13;
            this.btnInsertClassE.Text = "Inserisci";
            this.btnInsertClassE.Click += new System.EventHandler(this.btnInsertClassE_Click);
            // 
            // dgClassSpesa
            // 
            this.dgClassSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgClassSpesa.DataMember = "";
            this.dgClassSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgClassSpesa.Location = new System.Drawing.Point(6, 48);
            this.dgClassSpesa.Name = "dgClassSpesa";
            this.dgClassSpesa.Size = new System.Drawing.Size(499, 156);
            this.dgClassSpesa.TabIndex = 12;
            // 
            // grpVarSpesa
            // 
            this.grpVarSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpVarSpesa.Controls.Add(this.dgVarSpesa);
            this.grpVarSpesa.Location = new System.Drawing.Point(6, 19);
            this.grpVarSpesa.Name = "grpVarSpesa";
            this.grpVarSpesa.Size = new System.Drawing.Size(511, 176);
            this.grpVarSpesa.TabIndex = 2;
            this.grpVarSpesa.TabStop = false;
            this.grpVarSpesa.Text = "Variazioni";
            // 
            // dgVarSpesa
            // 
            this.dgVarSpesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVarSpesa.DataMember = "";
            this.dgVarSpesa.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgVarSpesa.Location = new System.Drawing.Point(6, 19);
            this.dgVarSpesa.Name = "dgVarSpesa";
            this.dgVarSpesa.Size = new System.Drawing.Size(499, 151);
            this.dgVarSpesa.TabIndex = 0;
            this.dgVarSpesa.DoubleClick += new System.EventHandler(this.dgVarSpesa_DoubleClick);
            this.dgVarSpesa.CurrentCellChanged += new System.EventHandler(this.dgVarSpesa_CurrentCellChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(466, 457);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
            this.btnAnnulla.TabIndex = 4;
            this.btnAnnulla.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(370, 457);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 3;
            this.btnOk.Text = "Ok";
            // 
            // dsMov
            // 
            this.dsMov.DataSetName = "dsMov";
            this.dsMov.EnforceConstraints = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(9, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Doppio click su una riga  per cambiare la descrizione o associare un finanziament" +
                "o";
            // 
            // FrmManage_Var
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 492);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabControl1);
            this.Name = "FrmManage_Var";
            this.Text = "Gestione Variazioni";
            this.tabControl1.ResumeLayout(false);
            this.tabVarEntrata.ResumeLayout(false);
            this.grpClassEntrata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClassEntrata)).EndInit();
            this.grpVarEntrata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVarEntrata)).EndInit();
            this.tabVarSpesa.ResumeLayout(false);
            this.tabVarSpesa.PerformLayout();
            this.grpClassSpesa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgClassSpesa)).EndInit();
            this.grpVarSpesa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVarSpesa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsMov)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabVarEntrata;
        private System.Windows.Forms.TabPage tabVarSpesa;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox grpClassEntrata;
        private System.Windows.Forms.GroupBox grpVarEntrata;
        private System.Windows.Forms.DataGrid dgVarEntrata;
        private System.Windows.Forms.GroupBox grpClassSpesa;
        private System.Windows.Forms.GroupBox grpVarSpesa;
        private System.Windows.Forms.DataGrid dgVarSpesa;
        private System.Windows.Forms.DataGrid dgClassEntrata;
        private System.Windows.Forms.Button btnDeleteClassI;
        private System.Windows.Forms.Button btnUpdateClassI;
        private System.Windows.Forms.Button btnInsertClassI;
        private System.Windows.Forms.Button btnDeleteClassE;
        private System.Windows.Forms.Button btnUpdateClassE;
        private System.Windows.Forms.Button btnInsertClassE;
        private System.Windows.Forms.DataGrid dgClassSpesa;
        public dsMov dsMov;
        private System.Windows.Forms.Label label1;
    }
}
