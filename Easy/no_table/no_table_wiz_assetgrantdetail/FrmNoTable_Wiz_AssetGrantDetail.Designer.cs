
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


namespace no_table_wiz_assetgrantdetail {
    partial class FrmNoTable_Wiz_AssetGrantDetail {
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNoTable_Wiz_AssetGrantDetail));
			this.DS = new no_table_wiz_assetgrantdetail.vistaForm();
			this.panel1 = new System.Windows.Forms.Panel();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabController = new Crownwood.Magic.Controls.TabControl();
			this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
			this.gridRisultati = new System.Windows.Forms.DataGrid();
			this.lblRiepilogo = new System.Windows.Forms.Label();
			this.btnCreaRisconti = new System.Windows.Forms.Button();
			this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAvanti = new System.Windows.Forms.Button();
			this.btnIndietro = new System.Windows.Forms.Button();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.btnCancel = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.panel1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.tabController.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridRisultati)).BeginInit();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// panel1
			// 
			this.panel1.AutoSize = true;
			this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(895, 444);
			this.panel1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.tabController);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(871, 389);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			// 
			// tabController
			// 
			this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabController.IDEPixelArea = true;
			this.tabController.Location = new System.Drawing.Point(3, 16);
			this.tabController.Name = "tabController";
			this.tabController.SelectedIndex = 1;
			this.tabController.SelectedTab = this.tabPage2;
			this.tabController.Size = new System.Drawing.Size(865, 370);
			this.tabController.TabIndex = 0;
			this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
			// 
			// tabPage2
			// 
			this.tabPage2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabPage2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tabPage2.Controls.Add(this.gridRisultati);
			this.tabPage2.Controls.Add(this.lblRiepilogo);
			this.tabPage2.Controls.Add(this.btnCreaRisconti);
			this.tabPage2.Location = new System.Drawing.Point(0, 0);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(865, 345);
			this.tabPage2.TabIndex = 4;
			this.tabPage2.Title = "Pagina 2 di 2";
			// 
			// gridRisultati
			// 
			this.gridRisultati.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.gridRisultati.DataMember = "";
			this.gridRisultati.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridRisultati.Location = new System.Drawing.Point(9, 38);
			this.gridRisultati.Name = "gridRisultati";
			this.gridRisultati.Size = new System.Drawing.Size(843, 292);
			this.gridRisultati.TabIndex = 24;
			// 
			// lblRiepilogo
			// 
			this.lblRiepilogo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblRiepilogo.Location = new System.Drawing.Point(57, 6);
			this.lblRiepilogo.Name = "lblRiepilogo";
			this.lblRiepilogo.Size = new System.Drawing.Size(505, 23);
			this.lblRiepilogo.TabIndex = 8;
			this.lblRiepilogo.Text = "Saranno Generati i seguenti Risconti per i Cespiti ammortizzati nell\'esercizio co" +
    "rrente";
			this.lblRiepilogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnCreaRisconti
			// 
			this.btnCreaRisconti.Location = new System.Drawing.Point(568, 9);
			this.btnCreaRisconti.Name = "btnCreaRisconti";
			this.btnCreaRisconti.Size = new System.Drawing.Size(151, 23);
			this.btnCreaRisconti.TabIndex = 7;
			this.btnCreaRisconti.Text = "Crea Utilizzo Risconti/Riserve";
			this.btnCreaRisconti.Click += new System.EventHandler(this.btnCreaRisconti_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(0, 0);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(865, 345);
			this.tabPage1.TabIndex = 3;
			this.tabPage1.Title = "Pagina 1 di 2";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(3, 136);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(680, 39);
			this.label3.TabIndex = 2;
			this.label3.Text = "N.B. Verranno considerati gli ammortamenti ufficiali dei cespiti";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(680, 60);
			this.label2.TabIndex = 1;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(6, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(845, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "WIZARD DI GENERAZIONE AUTOMATICA DEI RISCONTI DA AMMORTAMENTI CESPITI";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// btnAvanti
			// 
			this.btnAvanti.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAvanti.Location = new System.Drawing.Point(423, 418);
			this.btnAvanti.Name = "btnAvanti";
			this.btnAvanti.Size = new System.Drawing.Size(75, 23);
			this.btnAvanti.TabIndex = 5;
			this.btnAvanti.Text = "Avanti >";
			this.btnAvanti.Click += new System.EventHandler(this.btnAvanti_Click);
			// 
			// btnIndietro
			// 
			this.btnIndietro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnIndietro.Location = new System.Drawing.Point(318, 418);
			this.btnIndietro.Name = "btnIndietro";
			this.btnIndietro.Size = new System.Drawing.Size(75, 23);
			this.btnIndietro.TabIndex = 4;
			this.btnIndietro.Text = "< Indietro";
			this.btnIndietro.Click += new System.EventHandler(this.btnIndietro_Click);
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(672, 217);
			this.tabPage4.TabIndex = 1;
			this.tabPage4.Text = "Correzioni";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// dataGrid2
			// 
			this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(6, 6);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(663, 206);
			this.dataGrid2.TabIndex = 0;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 24);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(672, 215);
			this.tabPage3.TabIndex = 0;
			this.tabPage3.Text = "Ritenute";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// dataGrid1
			// 
			this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(6, 6);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(663, 206);
			this.dataGrid1.TabIndex = 0;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(617, 418);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 8;
			this.btnCancel.Tag = "maincancel";
			this.btnCancel.Text = "Annulla";
			// 
			// FrmNoTable_Wiz_AssetGrantDetail
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(895, 444);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAvanti);
			this.Controls.Add(this.btnIndietro);
			this.Controls.Add(this.panel1);
			this.Name = "FrmNoTable_Wiz_AssetGrantDetail";
			this.Text = "FrmNoTable_Wiz_FillUnified";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.panel1.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.tabController.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridRisultati)).EndInit();
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAvanti;
        private System.Windows.Forms.Button btnIndietro;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.DataGrid gridRisultati;
        private System.Windows.Forms.Label lblRiepilogo;
        private System.Windows.Forms.Button btnCreaRisconti;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
