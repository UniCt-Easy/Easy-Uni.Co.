
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


namespace no_table_calcola_integrazione_previsione {
    partial class FrmTrasfPrevisionInBudget {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose (bool disposing) {
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
        private void InitializeComponent () {
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTrasfPrevisionInBudget));
			this.DS = new no_table_calcola_integrazione_previsione.vistaForm();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnVisualizza = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.rdbMostraTutto = new System.Windows.Forms.RadioButton();
			this.rdbRettifiche = new System.Windows.Forms.RadioButton();
			this.rdbRicaviRiserveExCofi = new System.Windows.Forms.RadioButton();
			this.rdbCostiAmmortamento = new System.Windows.Forms.RadioButton();
			this.btnTrasferisciVariazioni = new System.Windows.Forms.Button();
			this.dgDettaglio = new System.Windows.Forms.DataGrid();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDettaglio)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(12, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(557, 64);
			this.groupBox2.TabIndex = 9;
			this.groupBox2.TabStop = false;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Location = new System.Drawing.Point(10, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(541, 43);
			this.label2.TabIndex = 2;
			this.label2.Text = resources.GetString("label2.Text");
			// 
			// btnVisualizza
			// 
			this.btnVisualizza.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnVisualizza.Location = new System.Drawing.Point(12, 76);
			this.btnVisualizza.Name = "btnVisualizza";
			this.btnVisualizza.Size = new System.Drawing.Size(222, 45);
			this.btnVisualizza.TabIndex = 13;
			this.btnVisualizza.Text = "Calcola Budget iniziale non operativo";
			this.btnVisualizza.UseVisualStyleBackColor = true;
			this.btnVisualizza.Click += new System.EventHandler(this.btnVisualizza_Click);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.rdbMostraTutto);
			this.groupBox3.Controls.Add(this.rdbRettifiche);
			this.groupBox3.Controls.Add(this.rdbRicaviRiserveExCofi);
			this.groupBox3.Controls.Add(this.rdbCostiAmmortamento);
			this.groupBox3.Location = new System.Drawing.Point(240, 71);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(329, 114);
			this.groupBox3.TabIndex = 12;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Dettagli calcolo";
			// 
			// rdbMostraTutto
			// 
			this.rdbMostraTutto.AutoSize = true;
			this.rdbMostraTutto.Location = new System.Drawing.Point(6, 87);
			this.rdbMostraTutto.Name = "rdbMostraTutto";
			this.rdbMostraTutto.Size = new System.Drawing.Size(88, 17);
			this.rdbMostraTutto.TabIndex = 4;
			this.rdbMostraTutto.TabStop = true;
			this.rdbMostraTutto.Text = "Calcola Tutto";
			this.rdbMostraTutto.UseVisualStyleBackColor = true;
			// 
			// rdbRettifiche
			// 
			this.rdbRettifiche.AutoSize = true;
			this.rdbRettifiche.Location = new System.Drawing.Point(6, 64);
			this.rdbRettifiche.Name = "rdbRettifiche";
			this.rdbRettifiche.Size = new System.Drawing.Size(283, 17);
			this.rdbRettifiche.TabIndex = 3;
			this.rdbRettifiche.TabStop = true;
			this.rdbRettifiche.Text = "Rettifiche previsione Ricavo da Commessa Completata";
			this.rdbRettifiche.UseVisualStyleBackColor = true;
			// 
			// rdbRicaviRiserveExCofi
			// 
			this.rdbRicaviRiserveExCofi.AutoSize = true;
			this.rdbRicaviRiserveExCofi.Location = new System.Drawing.Point(6, 42);
			this.rdbRicaviRiserveExCofi.Name = "rdbRicaviRiserveExCofi";
			this.rdbRicaviRiserveExCofi.Size = new System.Drawing.Size(240, 17);
			this.rdbRicaviRiserveExCofi.TabIndex = 2;
			this.rdbRicaviRiserveExCofi.TabStop = true;
			this.rdbRicaviRiserveExCofi.Text = "Previsioni di ricavo per utilizzo riserve ex COFI";
			this.rdbRicaviRiserveExCofi.UseVisualStyleBackColor = true;
			// 
			// rdbCostiAmmortamento
			// 
			this.rdbCostiAmmortamento.AutoSize = true;
			this.rdbCostiAmmortamento.Location = new System.Drawing.Point(6, 19);
			this.rdbCostiAmmortamento.Name = "rdbCostiAmmortamento";
			this.rdbCostiAmmortamento.Size = new System.Drawing.Size(228, 17);
			this.rdbCostiAmmortamento.TabIndex = 1;
			this.rdbCostiAmmortamento.TabStop = true;
			this.rdbCostiAmmortamento.Text = "Previsioni triennali di costi di ammortamento";
			this.rdbCostiAmmortamento.UseVisualStyleBackColor = true;
			// 
			// btnTrasferisciVariazioni
			// 
			this.btnTrasferisciVariazioni.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnTrasferisciVariazioni.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnTrasferisciVariazioni.Location = new System.Drawing.Point(172, 479);
			this.btnTrasferisciVariazioni.Name = "btnTrasferisciVariazioni";
			this.btnTrasferisciVariazioni.Size = new System.Drawing.Size(222, 38);
			this.btnTrasferisciVariazioni.TabIndex = 10;
			this.btnTrasferisciVariazioni.Text = "Conferma Calcolo";
			this.btnTrasferisciVariazioni.UseVisualStyleBackColor = true;
			this.btnTrasferisciVariazioni.Click += new System.EventHandler(this.btnTrasferisciVariazioni_Click);
			// 
			// dgDettaglio
			// 
			this.dgDettaglio.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dgDettaglio.DataMember = "";
			this.dgDettaglio.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgDettaglio.Location = new System.Drawing.Point(12, 201);
			this.dgDettaglio.Name = "dgDettaglio";
			this.dgDettaglio.Size = new System.Drawing.Size(557, 236);
			this.dgDettaglio.TabIndex = 6;
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.Location = new System.Drawing.Point(22, 452);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(557, 14);
			this.label1.TabIndex = 14;
			this.label1.Text = "Se esiste già una Variazione di Budget di tipo \"Non operativo\",  questa verrà SOV" +
    "RASCRITTA.";
			// 
			// FrmTrasfPrevisionInBudget
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(581, 548);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnTrasferisciVariazioni);
			this.Controls.Add(this.dgDettaglio);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.btnVisualizza);
			this.Name = "FrmTrasfPrevisionInBudget";
			this.Text = "Trasferimento ";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgDettaglio)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion
        public vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.RadioButton rdbRettifiche;
		private System.Windows.Forms.RadioButton rdbRicaviRiserveExCofi;
		private System.Windows.Forms.RadioButton rdbCostiAmmortamento;
		private System.Windows.Forms.Button btnTrasferisciVariazioni;
		private System.Windows.Forms.RadioButton rdbMostraTutto;
		private System.Windows.Forms.DataGrid dgDettaglio;
		private System.Windows.Forms.Button btnVisualizza;
		private System.Windows.Forms.Label label1;
	}
}
