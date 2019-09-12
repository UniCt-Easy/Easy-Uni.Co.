/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace itinerationlapweb_default
{
    partial class Frm_itinerationlapweb_default
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
            this.chkitaliaestero = new System.Windows.Forms.CheckBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtFrazioneGiorni = new System.Windows.Forms.TextBox();
            this.txtDataOraInizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDataOraTermine = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGiorni = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOre = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnLocalita = new System.Windows.Forms.Button();
            this.cmbLocalita = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // chkitaliaestero
            // 
            this.chkitaliaestero.Location = new System.Drawing.Point(44, 162);
            this.chkitaliaestero.Name = "chkitaliaestero";
            this.chkitaliaestero.Size = new System.Drawing.Size(72, 16);
            this.chkitaliaestero.TabIndex = 75;
            this.chkitaliaestero.TabStop = false;
            this.chkitaliaestero.Tag = "itinerationlap.flagitalian:S:N";
            this.chkitaliaestero.Text = "Italia";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(324, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 72;
            this.label11.Text = "N. giorni frazionario";
            // 
            // txtFrazioneGiorni
            // 
            this.txtFrazioneGiorni.Location = new System.Drawing.Point(444, 51);
            this.txtFrazioneGiorni.Name = "txtFrazioneGiorni";
            this.txtFrazioneGiorni.ReadOnly = true;
            this.txtFrazioneGiorni.Size = new System.Drawing.Size(136, 20);
            this.txtFrazioneGiorni.TabIndex = 73;
            this.txtFrazioneGiorni.TabStop = false;
            this.txtFrazioneGiorni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDataOraInizio
            // 
            this.txtDataOraInizio.Location = new System.Drawing.Point(116, 19);
            this.txtDataOraInizio.Name = "txtDataOraInizio";
            this.txtDataOraInizio.Size = new System.Drawing.Size(160, 20);
            this.txtDataOraInizio.TabIndex = 57;
            this.txtDataOraInizio.Tag = "itinerationlap.starttime.g";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 58;
            this.label1.Text = "Data/ora inizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 61;
            this.label2.Text = "Data/ora termine:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataOraTermine
            // 
            this.txtDataOraTermine.Location = new System.Drawing.Point(116, 51);
            this.txtDataOraTermine.Name = "txtDataOraTermine";
            this.txtDataOraTermine.Size = new System.Drawing.Size(160, 20);
            this.txtDataOraTermine.TabIndex = 62;
            this.txtDataOraTermine.Tag = "itinerationlap.stoptime.g";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(284, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 23);
            this.label5.TabIndex = 68;
            this.label5.Text = "Giorni:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtGiorni
            // 
            this.txtGiorni.Location = new System.Drawing.Point(340, 19);
            this.txtGiorni.Name = "txtGiorni";
            this.txtGiorni.Size = new System.Drawing.Size(88, 20);
            this.txtGiorni.TabIndex = 59;
            this.txtGiorni.Tag = "itinerationlap.days";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(436, 19);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 23);
            this.label6.TabIndex = 69;
            this.label6.Text = "Ore:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOre
            // 
            this.txtOre.Location = new System.Drawing.Point(492, 19);
            this.txtOre.Name = "txtOre";
            this.txtOre.Size = new System.Drawing.Size(88, 20);
            this.txtOre.TabIndex = 60;
            this.txtOre.Tag = "itinerationlap.hours";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(148, 91);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(432, 48);
            this.txtDescrizione.TabIndex = 63;
            this.txtDescrizione.Tag = "itinerationlap.description";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(28, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 24);
            this.label4.TabIndex = 67;
            this.label4.Text = "Descrizione:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnLocalita
            // 
            this.btnLocalita.Location = new System.Drawing.Point(156, 155);
            this.btnLocalita.Name = "btnLocalita";
            this.btnLocalita.Size = new System.Drawing.Size(88, 23);
            this.btnLocalita.TabIndex = 64;
            this.btnLocalita.TabStop = false;
            this.btnLocalita.Tag = "manage.foreigncountry.default";
            this.btnLocalita.Text = "Località Estera:";
            this.btnLocalita.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbLocalita
            // 
            this.cmbLocalita.DisplayMember = "description";
            this.cmbLocalita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocalita.Location = new System.Drawing.Point(260, 155);
            this.cmbLocalita.Name = "cmbLocalita";
            this.cmbLocalita.Size = new System.Drawing.Size(320, 21);
            this.cmbLocalita.TabIndex = 65;
            this.cmbLocalita.Tag = "itinerationlap.idforeigncountry";
            this.cmbLocalita.ValueMember = "idforeigncountry";
            // 
            // Frm_itinerationlapweb_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 198);
            this.Controls.Add(this.chkitaliaestero);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtFrazioneGiorni);
            this.Controls.Add(this.txtDataOraInizio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDataOraTermine);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtGiorni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtOre);
            this.Controls.Add(this.txtDescrizione);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnLocalita);
            this.Controls.Add(this.cmbLocalita);
            this.Name = "Frm_itinerationlapweb_default";
            this.Text = "Frm_itinerationlapweb_default";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkitaliaestero;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtFrazioneGiorni;
        private System.Windows.Forms.TextBox txtDataOraInizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDataOraTermine;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGiorni;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOre;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLocalita;
        private System.Windows.Forms.ComboBox cmbLocalita;
    }
}