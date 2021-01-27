
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


namespace no_table_wiz_del_anagrafiche_nonusate {
    partial class FrmNoTable_Wiz_Del_Anagrafiche_NonUsate {
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
            this.tabController = new Crownwood.Magic.Controls.TabControl();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.btnElimina = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDeselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.dgAnagrafica = new System.Windows.Forms.DataGrid();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.DS = new no_table_wiz_del_anagrafiche_nonusate.vistaForm();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkNonAttive = new System.Windows.Forms.CheckBox();
            this.tabController.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAnagrafica)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabController
            // 
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.IDEPixelArea = true;
            this.tabController.Location = new System.Drawing.Point(0, 0);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.SelectedTab = this.tabPage1;
            this.tabController.Size = new System.Drawing.Size(713, 404);
            this.tabController.TabIndex = 0;
            this.tabController.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnElimina);
            this.tabPage2.Controls.Add(this.pBar);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.btnRefresh);
            this.tabPage2.Controls.Add(this.btnDeselectAll);
            this.tabPage2.Controls.Add(this.btnSelectAll);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.dgAnagrafica);
            this.tabPage2.Location = new System.Drawing.Point(0, 0);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(713, 379);
            this.tabPage2.TabIndex = 4;
            this.tabPage2.Title = "Pagina 2 di 2";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(595, 58);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(108, 23);
            this.btnElimina.TabIndex = 7;
            this.btnElimina.Text = "Cancella";
            this.btnElimina.UseVisualStyleBackColor = true;
            this.btnElimina.Click += new System.EventHandler(this.btnElimina_Click);
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pBar.Location = new System.Drawing.Point(9, 342);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(694, 23);
            this.pBar.TabIndex = 6;
            this.pBar.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(6, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(681, 21);
            this.label10.TabIndex = 5;
            this.label10.Text = "Per selezionare più anagrafiche adoperare i tasti SHIFT o CONTROL";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(249, 58);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(108, 23);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Aggiorna Dati";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDeselectAll
            // 
            this.btnDeselectAll.Location = new System.Drawing.Point(125, 59);
            this.btnDeselectAll.Name = "btnDeselectAll";
            this.btnDeselectAll.Size = new System.Drawing.Size(108, 23);
            this.btnDeselectAll.TabIndex = 3;
            this.btnDeselectAll.Text = "Deseleziona Tutto";
            this.btnDeselectAll.UseVisualStyleBackColor = true;
            this.btnDeselectAll.Click += new System.EventHandler(this.btnDeselectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(3, 59);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(108, 23);
            this.btnSelectAll.TabIndex = 2;
            this.btnSelectAll.Text = "Seleziona Tutto";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 8);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(681, 21);
            this.label9.TabIndex = 1;
            this.label9.Text = "ELENCO DELLE ANAGRAFICHE INUTILIZZATE: SELEZIONARE QUELLE DA CANCELLARE";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dgAnagrafica
            // 
            this.dgAnagrafica.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgAnagrafica.DataMember = "";
            this.dgAnagrafica.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgAnagrafica.Location = new System.Drawing.Point(3, 88);
            this.dgAnagrafica.Name = "dgAnagrafica";
            this.dgAnagrafica.Size = new System.Drawing.Size(707, 248);
            this.dgAnagrafica.TabIndex = 0;
            this.dgAnagrafica.DoubleClick += new System.EventHandler(this.dbAnagrafica_DoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkNonAttive);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(0, 0);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(713, 379);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Title = "Pagina 1 di 2";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(9, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(575, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "- Non compare in alcuna configurazione";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(9, 176);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(575, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "- Non è stato imputato alcun compenso";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(575, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "- Non è stata imputata alcuna fattura";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(9, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(575, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "- Non è stata imputata movimentazione patrimoniale";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(575, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "- Non è stata imputata movimentazione finanziaria";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(581, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Una anagrafica è da considerarsi inutilizzata se:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(581, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "Questa procedura consente di cancellare le anagrafiche inutilizzate";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(584, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "WIZARD DI CANCELLAZIONE DELLE ANAGRAFICHE INUTILIZZATE";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Location = new System.Drawing.Point(530, 414);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "<< Indietro";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Location = new System.Drawing.Point(624, 414);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 23);
            this.btnNext.TabIndex = 2;
            this.btnNext.Text = "Avanti >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.tabController);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(713, 404);
            this.panel1.TabIndex = 3;
            // 
            // chkNonAttive
            // 
            this.chkNonAttive.AutoSize = true;
            this.chkNonAttive.Location = new System.Drawing.Point(23, 244);
            this.chkNonAttive.Name = "chkNonAttive";
            this.chkNonAttive.Size = new System.Drawing.Size(271, 17);
            this.chkNonAttive.TabIndex = 8;
            this.chkNonAttive.Text = "Si desidera considerare solo anagrafiche non attive";
            this.chkNonAttive.UseVisualStyleBackColor = true;
            // 
            // FrmNoTable_Wiz_Del_Anagrafiche_NonUsate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Name = "FrmNoTable_Wiz_Del_Anagrafiche_NonUsate";
            this.Text = "FrmNoTable_Wiz_Del_Anagrafiche_NonUsate";
            this.tabController.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAnagrafica)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public vistaForm DS;
        private Crownwood.Magic.Controls.TabControl tabController;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGrid dgAnagrafica;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDeselectAll;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.Button btnElimina;
        private System.Windows.Forms.CheckBox chkNonAttive;

    }
}
