
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


namespace mandatekind_associa
{
    partial class Frm_mandatekind_associa
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
            this.listMandatekind = new System.Windows.Forms.ListView();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.DS = new mandatekind_associa.vistaForm();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // listMandatekind
            // 
            this.listMandatekind.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listMandatekind.AutoArrange = false;
            this.listMandatekind.CheckBoxes = true;
            this.listMandatekind.Location = new System.Drawing.Point(420, 37);
            this.listMandatekind.Name = "listMandatekind";
            this.listMandatekind.Size = new System.Drawing.Size(328, 332);
            this.listMandatekind.TabIndex = 74;
            this.listMandatekind.Tag = "mandatekind_original.richiesta";
            this.listMandatekind.UseCompatibleStateImageBehavior = false;
            this.listMandatekind.View = System.Windows.Forms.View.List;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(417, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(273, 16);
            this.label3.TabIndex = 73;
            this.label3.Text = "Elenco dei Tipi  Richiesta d\'Acquisto associabili";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(100, 42);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(160, 20);
            this.textBox23.TabIndex = 77;
            this.textBox23.Tag = "mandatekind.idmankind";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(100, 72);
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(277, 59);
            this.textBox24.TabIndex = 78;
            this.textBox24.Tag = "mandatekind.description";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(19, 76);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(75, 19);
            this.label18.TabIndex = 80;
            this.label18.Text = "Descrizione:";
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(35, 46);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(59, 16);
            this.label19.TabIndex = 79;
            this.label19.Text = "Codice:";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_mandatekind_associa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 412);
            this.Controls.Add(this.textBox23);
            this.Controls.Add(this.textBox24);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.listMandatekind);
            this.Controls.Add(this.label3);
            this.Name = "Frm_mandatekind_associa";
            this.Text = "Frm_mandatekind_associa";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.ListView listMandatekind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;

    }
}
