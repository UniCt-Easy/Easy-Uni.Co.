
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


namespace taxpay_wiz_liquidperiodica {
    partial class FrmError {
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
            this.btnOk = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabLiquidazione = new System.Windows.Forms.TabPage();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.lblLiq = new System.Windows.Forms.Label();
            this.tabFinanziario = new System.Windows.Forms.TabPage();
            this.dataGrid2 = new System.Windows.Forms.DataGrid();
            this.lblFin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIgnora = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabLiquidazione.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.tabFinanziario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(698, 363);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(151, 23);
            this.btnOk.TabIndex = 4;
            this.btnOk.Text = "Torna alla Liquidazione";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabLiquidazione);
            this.tabControl1.Controls.Add(this.tabFinanziario);
            this.tabControl1.Location = new System.Drawing.Point(2, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(859, 353);
            this.tabControl1.TabIndex = 6;
            // 
            // tabLiquidazione
            // 
            this.tabLiquidazione.Controls.Add(this.dataGrid1);
            this.tabLiquidazione.Controls.Add(this.lblLiq);
            this.tabLiquidazione.Location = new System.Drawing.Point(4, 22);
            this.tabLiquidazione.Name = "tabLiquidazione";
            this.tabLiquidazione.Padding = new System.Windows.Forms.Padding(3);
            this.tabLiquidazione.Size = new System.Drawing.Size(851, 327);
            this.tabLiquidazione.TabIndex = 0;
            this.tabLiquidazione.Text = "Liquidazione";
            this.tabLiquidazione.UseVisualStyleBackColor = true;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(3, 57);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(841, 264);
            this.dataGrid1.TabIndex = 1;
            // 
            // lblLiq
            // 
            this.lblLiq.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLiq.ForeColor = System.Drawing.Color.Blue;
            this.lblLiq.Location = new System.Drawing.Point(6, 3);
            this.lblLiq.Name = "lblLiq";
            this.lblLiq.Size = new System.Drawing.Size(625, 51);
            this.lblLiq.TabIndex = 0;
            // 
            // tabFinanziario
            // 
            this.tabFinanziario.Controls.Add(this.dataGrid2);
            this.tabFinanziario.Controls.Add(this.lblFin);
            this.tabFinanziario.Location = new System.Drawing.Point(4, 22);
            this.tabFinanziario.Name = "tabFinanziario";
            this.tabFinanziario.Padding = new System.Windows.Forms.Padding(3);
            this.tabFinanziario.Size = new System.Drawing.Size(851, 360);
            this.tabFinanziario.TabIndex = 1;
            this.tabFinanziario.Text = "Finanziario";
            this.tabFinanziario.UseVisualStyleBackColor = true;
            // 
            // dataGrid2
            // 
            this.dataGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid2.DataMember = "";
            this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid2.Location = new System.Drawing.Point(3, 57);
            this.dataGrid2.Name = "dataGrid2";
            this.dataGrid2.Size = new System.Drawing.Size(841, 297);
            this.dataGrid2.TabIndex = 2;
            // 
            // lblFin
            // 
            this.lblFin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFin.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFin.ForeColor = System.Drawing.Color.Blue;
            this.lblFin.Location = new System.Drawing.Point(6, 3);
            this.lblFin.Name = "lblFin";
            this.lblFin.Size = new System.Drawing.Size(842, 51);
            this.lblFin.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(612, 55);
            this.label1.TabIndex = 7;
            this.label1.Text = "N.B. I dettagli che qui vengono proposti verranno DESELEZIONATI in automatico a m" +
    "eno che si prema il bottone \"continua ignorando la segnalazione\"";
            // 
            // btnIgnora
            // 
            this.btnIgnora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIgnora.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnIgnora.Location = new System.Drawing.Point(624, 392);
            this.btnIgnora.Name = "btnIgnora";
            this.btnIgnora.Size = new System.Drawing.Size(226, 23);
            this.btnIgnora.TabIndex = 8;
            this.btnIgnora.Text = "Continua ignorando la segnalazione";
            this.btnIgnora.Click += new System.EventHandler(this.btnIgnora_Click);
            // 
            // FrmError
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 427);
            this.Controls.Add(this.btnIgnora);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOk);
            this.Name = "FrmError";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Elenco dettagli che violano i vincoli";
            this.tabControl1.ResumeLayout(false);
            this.tabLiquidazione.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.tabFinanziario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabLiquidazione;
        private System.Windows.Forms.TabPage tabFinanziario;
        private System.Windows.Forms.Label lblLiq;
        private System.Windows.Forms.Label lblFin;
        private System.Windows.Forms.DataGrid dataGrid1;
        private System.Windows.Forms.DataGrid dataGrid2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIgnora;
    }
}
