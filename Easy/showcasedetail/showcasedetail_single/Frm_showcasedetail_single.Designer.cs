/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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

namespace showcasedetail_single
{
    partial class Frm_showcasedetail_single
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtDescrizioneClassificazione = new System.Windows.Forms.TextBox();
			this.lblDescrizioneClassificazione = new System.Windows.Forms.Label();
			this.txtCodiceClassificazione = new System.Windows.Forms.TextBox();
			this.lblCodiceClassificazione = new System.Windows.Forms.Label();
			this.gboxListino = new System.Windows.Forms.GroupBox();
			this.txtDescrizioneListino = new System.Windows.Forms.TextBox();
			this.chkFiltraDescrizioneClassificazione = new System.Windows.Forms.CheckBox();
			this.pbox = new System.Windows.Forms.PictureBox();
			this.lblDescrizioneListino = new System.Windows.Forms.Label();
			this.btnListino = new System.Windows.Forms.Button();
			this.txtCodiceListino = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.txtNomeArticolo = new System.Windows.Forms.TextBox();
			this.lblNomeArticolo = new System.Windows.Forms.Label();
			this.lblPrezzoUnitario = new System.Windows.Forms.Label();
			this.txtPrezzoUnitario = new System.Windows.Forms.TextBox();
			this.gbxAliquotaIVA = new System.Windows.Forms.GroupBox();
			this.btnTipoIVA = new System.Windows.Forms.Button();
			this.cmbTipoIVA = new System.Windows.Forms.ComboBox();
			this.DS = new showcasedetail_single.vistaForm();
			this.txtAliquotaIVA = new System.Windows.Forms.TextBox();
			this.lblAliquotaIVA = new System.Windows.Forms.Label();
			this.txtImportoIVA = new System.Windows.Forms.TextBox();
			this.lblImportoIVA = new System.Windows.Forms.Label();
			this.gbxPrezzoUnitario = new System.Windows.Forms.GroupBox();
			this.lblDisponibilit‡ = new System.Windows.Forms.Label();
			this.txtDisponibilit‡ = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.cmbTipoFattura = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.cmbTipoContrattoAttivo = new System.Windows.Forms.ComboBox();
			this.gboxUPB = new System.Windows.Forms.GroupBox();
			this.txtUPB = new System.Windows.Forms.TextBox();
			this.txtDescrUPB = new System.Windows.Forms.TextBox();
			this.btnUPBCode = new System.Windows.Forms.Button();
			this.textBoxcompetencystart = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.textBoxcompetencystop = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.gBoxupbIVA = new System.Windows.Forms.GroupBox();
			this.txtUPBiva = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnUpbIVA = new System.Windows.Forms.Button();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.gboxListino.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbox)).BeginInit();
			this.gbxAliquotaIVA.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.gbxPrezzoUnitario.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.gboxUPB.SuspendLayout();
			this.gBoxupbIVA.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtDescrizioneClassificazione);
			this.groupBox1.Controls.Add(this.lblDescrizioneClassificazione);
			this.groupBox1.Controls.Add(this.txtCodiceClassificazione);
			this.groupBox1.Controls.Add(this.lblCodiceClassificazione);
			this.groupBox1.Location = new System.Drawing.Point(488, 401);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(283, 181);
			this.groupBox1.TabIndex = 7;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Classificazione";
			// 
			// txtDescrizioneClassificazione
			// 
			this.txtDescrizioneClassificazione.Location = new System.Drawing.Point(6, 91);
			this.txtDescrizioneClassificazione.Multiline = true;
			this.txtDescrizioneClassificazione.Name = "txtDescrizioneClassificazione";
			this.txtDescrizioneClassificazione.ReadOnly = true;
			this.txtDescrizioneClassificazione.Size = new System.Drawing.Size(271, 84);
			this.txtDescrizioneClassificazione.TabIndex = 3;
			this.txtDescrizioneClassificazione.Tag = "listview.listclass";
			// 
			// lblDescrizioneClassificazione
			// 
			this.lblDescrizioneClassificazione.AutoSize = true;
			this.lblDescrizioneClassificazione.Location = new System.Drawing.Point(6, 75);
			this.lblDescrizioneClassificazione.Name = "lblDescrizioneClassificazione";
			this.lblDescrizioneClassificazione.Size = new System.Drawing.Size(62, 13);
			this.lblDescrizioneClassificazione.TabIndex = 2;
			this.lblDescrizioneClassificazione.Text = "Descrizione";
			// 
			// txtCodiceClassificazione
			// 
			this.txtCodiceClassificazione.Location = new System.Drawing.Point(52, 101);
			this.txtCodiceClassificazione.Name = "txtCodiceClassificazione";
			this.txtCodiceClassificazione.ReadOnly = true;
			this.txtCodiceClassificazione.Size = new System.Drawing.Size(100, 20);
			this.txtCodiceClassificazione.TabIndex = 1;
			this.txtCodiceClassificazione.Tag = "listview.codelistclass";
			// 
			// lblCodiceClassificazione
			// 
			this.lblCodiceClassificazione.AutoSize = true;
			this.lblCodiceClassificazione.Location = new System.Drawing.Point(6, 24);
			this.lblCodiceClassificazione.Name = "lblCodiceClassificazione";
			this.lblCodiceClassificazione.Size = new System.Drawing.Size(40, 13);
			this.lblCodiceClassificazione.TabIndex = 0;
			this.lblCodiceClassificazione.Text = "Codice";
			// 
			// gboxListino
			// 
			this.gboxListino.Controls.Add(this.txtDescrizioneListino);
			this.gboxListino.Controls.Add(this.chkFiltraDescrizioneClassificazione);
			this.gboxListino.Controls.Add(this.pbox);
			this.gboxListino.Controls.Add(this.lblDescrizioneListino);
			this.gboxListino.Controls.Add(this.btnListino);
			this.gboxListino.Controls.Add(this.txtCodiceListino);
			this.gboxListino.Location = new System.Drawing.Point(12, 401);
			this.gboxListino.Name = "gboxListino";
			this.gboxListino.Size = new System.Drawing.Size(470, 181);
			this.gboxListino.TabIndex = 6;
			this.gboxListino.TabStop = false;
			this.gboxListino.Tag = "";
			this.gboxListino.Text = "Listino";
			// 
			// txtDescrizioneListino
			// 
			this.txtDescrizioneListino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrizioneListino.Location = new System.Drawing.Point(6, 91);
			this.txtDescrizioneListino.Multiline = true;
			this.txtDescrizioneListino.Name = "txtDescrizioneListino";
			this.txtDescrizioneListino.ReadOnly = true;
			this.txtDescrizioneListino.Size = new System.Drawing.Size(324, 84);
			this.txtDescrizioneListino.TabIndex = 4;
			this.txtDescrizioneListino.Tag = "listview.description";
			// 
			// chkFiltraDescrizioneClassificazione
			// 
			this.chkFiltraDescrizioneClassificazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.chkFiltraDescrizioneClassificazione.Location = new System.Drawing.Point(6, 19);
			this.chkFiltraDescrizioneClassificazione.Name = "chkFiltraDescrizioneClassificazione";
			this.chkFiltraDescrizioneClassificazione.Size = new System.Drawing.Size(458, 24);
			this.chkFiltraDescrizioneClassificazione.TabIndex = 12;
			this.chkFiltraDescrizioneClassificazione.TabStop = false;
			this.chkFiltraDescrizioneClassificazione.Text = "Fitra per Descrizione/Class.Merceologica";
			// 
			// pbox
			// 
			this.pbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.pbox.Location = new System.Drawing.Point(336, 47);
			this.pbox.Name = "pbox";
			this.pbox.Size = new System.Drawing.Size(128, 128);
			this.pbox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pbox.TabIndex = 18;
			this.pbox.TabStop = false;
			// 
			// lblDescrizioneListino
			// 
			this.lblDescrizioneListino.AutoSize = true;
			this.lblDescrizioneListino.Location = new System.Drawing.Point(6, 75);
			this.lblDescrizioneListino.Name = "lblDescrizioneListino";
			this.lblDescrizioneListino.Size = new System.Drawing.Size(62, 13);
			this.lblDescrizioneListino.TabIndex = 3;
			this.lblDescrizioneListino.Text = "Descrizione";
			// 
			// btnListino
			// 
			this.btnListino.BackColor = System.Drawing.SystemColors.Control;
			this.btnListino.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnListino.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnListino.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnListino.ImageIndex = 0;
			this.btnListino.Location = new System.Drawing.Point(6, 49);
			this.btnListino.Name = "btnListino";
			this.btnListino.Size = new System.Drawing.Size(62, 23);
			this.btnListino.TabIndex = 1;
			this.btnListino.TabStop = false;
			this.btnListino.Tag = "";
			this.btnListino.Text = "Listino";
			this.btnListino.UseVisualStyleBackColor = false;
			this.btnListino.Click += new System.EventHandler(this.btnListino_Click);
			// 
			// txtCodiceListino
			// 
			this.txtCodiceListino.Location = new System.Drawing.Point(74, 51);
			this.txtCodiceListino.Name = "txtCodiceListino";
			this.txtCodiceListino.Size = new System.Drawing.Size(122, 20);
			this.txtCodiceListino.TabIndex = 13;
			this.txtCodiceListino.Tag = "listview.intcode?x";
			this.txtCodiceListino.Leave += new System.EventHandler(this.txtListino_Leave);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(696, 13);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(75, 23);
			this.btnOK.TabIndex = 8;
			this.btnOK.Tag = "mainsave";
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(696, 43);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.Size = new System.Drawing.Size(75, 23);
			this.btnAnnulla.TabIndex = 9;
			this.btnAnnulla.Text = "Annulla";
			this.btnAnnulla.UseVisualStyleBackColor = true;
			// 
			// txtNomeArticolo
			// 
			this.txtNomeArticolo.Location = new System.Drawing.Point(94, 15);
			this.txtNomeArticolo.Name = "txtNomeArticolo";
			this.txtNomeArticolo.Size = new System.Drawing.Size(596, 20);
			this.txtNomeArticolo.TabIndex = 1;
			this.txtNomeArticolo.Tag = "showcasedetail.title";
			// 
			// lblNomeArticolo
			// 
			this.lblNomeArticolo.AutoSize = true;
			this.lblNomeArticolo.Location = new System.Drawing.Point(12, 18);
			this.lblNomeArticolo.Name = "lblNomeArticolo";
			this.lblNomeArticolo.Size = new System.Drawing.Size(72, 13);
			this.lblNomeArticolo.TabIndex = 0;
			this.lblNomeArticolo.Text = "Nome articolo";
			// 
			// lblPrezzoUnitario
			// 
			this.lblPrezzoUnitario.AutoSize = true;
			this.lblPrezzoUnitario.Location = new System.Drawing.Point(6, 33);
			this.lblPrezzoUnitario.Name = "lblPrezzoUnitario";
			this.lblPrezzoUnitario.Size = new System.Drawing.Size(76, 13);
			this.lblPrezzoUnitario.TabIndex = 0;
			this.lblPrezzoUnitario.Text = "Prezzo unitario";
			// 
			// txtPrezzoUnitario
			// 
			this.txtPrezzoUnitario.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtPrezzoUnitario.Location = new System.Drawing.Point(88, 27);
			this.txtPrezzoUnitario.Name = "txtPrezzoUnitario";
			this.txtPrezzoUnitario.Size = new System.Drawing.Size(133, 20);
			this.txtPrezzoUnitario.TabIndex = 1;
			this.txtPrezzoUnitario.Tag = "showcasedetail.unitprice";
			this.txtPrezzoUnitario.Leave += new System.EventHandler(this.txtPrezzoUnitario_Leave);
			// 
			// gbxAliquotaIVA
			// 
			this.gbxAliquotaIVA.Controls.Add(this.btnTipoIVA);
			this.gbxAliquotaIVA.Controls.Add(this.cmbTipoIVA);
			this.gbxAliquotaIVA.Controls.Add(this.txtAliquotaIVA);
			this.gbxAliquotaIVA.Controls.Add(this.lblAliquotaIVA);
			this.gbxAliquotaIVA.Controls.Add(this.txtImportoIVA);
			this.gbxAliquotaIVA.Controls.Add(this.lblImportoIVA);
			this.gbxAliquotaIVA.Location = new System.Drawing.Point(245, 75);
			this.gbxAliquotaIVA.Name = "gbxAliquotaIVA";
			this.gbxAliquotaIVA.Size = new System.Drawing.Size(526, 54);
			this.gbxAliquotaIVA.TabIndex = 5;
			this.gbxAliquotaIVA.TabStop = false;
			// 
			// btnTipoIVA
			// 
			this.btnTipoIVA.Location = new System.Drawing.Point(6, 24);
			this.btnTipoIVA.Name = "btnTipoIVA";
			this.btnTipoIVA.Size = new System.Drawing.Size(64, 25);
			this.btnTipoIVA.TabIndex = 3;
			this.btnTipoIVA.TabStop = false;
			this.btnTipoIVA.Tag = "choose.ivakind.default";
			this.btnTipoIVA.Text = "Tipo IVA";
			// 
			// cmbTipoIVA
			// 
			this.cmbTipoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoIVA.DataSource = this.DS.ivakind;
			this.cmbTipoIVA.DisplayMember = "description";
			this.cmbTipoIVA.Location = new System.Drawing.Point(76, 28);
			this.cmbTipoIVA.Name = "cmbTipoIVA";
			this.cmbTipoIVA.Size = new System.Drawing.Size(288, 21);
			this.cmbTipoIVA.TabIndex = 2;
			this.cmbTipoIVA.Tag = "showcasedetail.idivakind";
			this.cmbTipoIVA.ValueMember = "idivakind";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// txtAliquotaIVA
			// 
			this.txtAliquotaIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtAliquotaIVA.Location = new System.Drawing.Point(370, 28);
			this.txtAliquotaIVA.Name = "txtAliquotaIVA";
			this.txtAliquotaIVA.ReadOnly = true;
			this.txtAliquotaIVA.Size = new System.Drawing.Size(72, 20);
			this.txtAliquotaIVA.TabIndex = 4;
			this.txtAliquotaIVA.TabStop = false;
			this.txtAliquotaIVA.Tag = "ivakind.rate.fixed.4..%.100";
			this.txtAliquotaIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblAliquotaIVA
			// 
			this.lblAliquotaIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblAliquotaIVA.AutoSize = true;
			this.lblAliquotaIVA.Location = new System.Drawing.Point(367, 12);
			this.lblAliquotaIVA.Name = "lblAliquotaIVA";
			this.lblAliquotaIVA.Size = new System.Drawing.Size(45, 13);
			this.lblAliquotaIVA.TabIndex = 35;
			this.lblAliquotaIVA.Text = "Aliquota";
			this.lblAliquotaIVA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtImportoIVA
			// 
			this.txtImportoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtImportoIVA.Location = new System.Drawing.Point(448, 28);
			this.txtImportoIVA.Name = "txtImportoIVA";
			this.txtImportoIVA.ReadOnly = true;
			this.txtImportoIVA.Size = new System.Drawing.Size(72, 20);
			this.txtImportoIVA.TabIndex = 5;
			this.txtImportoIVA.TabStop = false;
			this.txtImportoIVA.Tag = "";
			this.txtImportoIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblImportoIVA
			// 
			this.lblImportoIVA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblImportoIVA.AutoSize = true;
			this.lblImportoIVA.Location = new System.Drawing.Point(445, 12);
			this.lblImportoIVA.Name = "lblImportoIVA";
			this.lblImportoIVA.Size = new System.Drawing.Size(65, 13);
			this.lblImportoIVA.TabIndex = 35;
			this.lblImportoIVA.Text = "Importo unit.";
			this.lblImportoIVA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// gbxPrezzoUnitario
			// 
			this.gbxPrezzoUnitario.Controls.Add(this.txtPrezzoUnitario);
			this.gbxPrezzoUnitario.Controls.Add(this.lblPrezzoUnitario);
			this.gbxPrezzoUnitario.Location = new System.Drawing.Point(12, 75);
			this.gbxPrezzoUnitario.Name = "gbxPrezzoUnitario";
			this.gbxPrezzoUnitario.Size = new System.Drawing.Size(227, 54);
			this.gbxPrezzoUnitario.TabIndex = 4;
			this.gbxPrezzoUnitario.TabStop = false;
			// 
			// lblDisponibilit‡
			// 
			this.lblDisponibilit‡.AutoSize = true;
			this.lblDisponibilit‡.Location = new System.Drawing.Point(12, 49);
			this.lblDisponibilit‡.Name = "lblDisponibilit‡";
			this.lblDisponibilit‡.Size = new System.Drawing.Size(63, 13);
			this.lblDisponibilit‡.TabIndex = 2;
			this.lblDisponibilit‡.Text = "Disponibilit‡";
			// 
			// txtDisponibilit‡
			// 
			this.txtDisponibilit‡.Location = new System.Drawing.Point(94, 46);
			this.txtDisponibilit‡.Name = "txtDisponibilit‡";
			this.txtDisponibilit‡.Size = new System.Drawing.Size(50, 20);
			this.txtDisponibilit‡.TabIndex = 3;
			this.txtDisponibilit‡.Tag = "showcasedetail.availability";
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.cmbTipoFattura);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Controls.Add(this.button2);
			this.groupBox3.Controls.Add(this.cmbTipoContrattoAttivo);
			this.groupBox3.Location = new System.Drawing.Point(18, 296);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(375, 88);
			this.groupBox3.TabIndex = 57;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Tipo contratto attivo e Tipo Fattura";
			// 
			// cmbTipoFattura
			// 
			this.cmbTipoFattura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoFattura.DataSource = this.DS.invoicekind;
			this.cmbTipoFattura.DisplayMember = "description";
			this.cmbTipoFattura.Location = new System.Drawing.Point(71, 58);
			this.cmbTipoFattura.Name = "cmbTipoFattura";
			this.cmbTipoFattura.Size = new System.Drawing.Size(298, 21);
			this.cmbTipoFattura.TabIndex = 10;
			this.cmbTipoFattura.Tag = "showcasedetail.idinvkind";
			this.cmbTipoFattura.ValueMember = "idinvkind";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Tipo Fattura";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(6, 19);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(57, 24);
			this.button2.TabIndex = 0;
			this.button2.TabStop = false;
			this.button2.Tag = "Choose.estimatekind.default";
			this.button2.Text = "Tipo";
			// 
			// cmbTipoContrattoAttivo
			// 
			this.cmbTipoContrattoAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbTipoContrattoAttivo.DataSource = this.DS.estimatekind;
			this.cmbTipoContrattoAttivo.DisplayMember = "description";
			this.cmbTipoContrattoAttivo.Location = new System.Drawing.Point(69, 22);
			this.cmbTipoContrattoAttivo.Name = "cmbTipoContrattoAttivo";
			this.cmbTipoContrattoAttivo.Size = new System.Drawing.Size(300, 21);
			this.cmbTipoContrattoAttivo.TabIndex = 9;
			this.cmbTipoContrattoAttivo.Tag = "showcasedetail.idestimkind";
			this.cmbTipoContrattoAttivo.ValueMember = "idestimkind";
			// 
			// gboxUPB
			// 
			this.gboxUPB.Controls.Add(this.txtUPB);
			this.gboxUPB.Controls.Add(this.txtDescrUPB);
			this.gboxUPB.Controls.Add(this.btnUPBCode);
			this.gboxUPB.Location = new System.Drawing.Point(18, 141);
			this.gboxUPB.Name = "gboxUPB";
			this.gboxUPB.Padding = new System.Windows.Forms.Padding(5);
			this.gboxUPB.Size = new System.Drawing.Size(372, 140);
			this.gboxUPB.TabIndex = 58;
			this.gboxUPB.TabStop = false;
			this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
			this.gboxUPB.Text = "UPB";
			// 
			// txtUPB
			// 
			this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPB.Location = new System.Drawing.Point(8, 109);
			this.txtUPB.Name = "txtUPB";
			this.txtUPB.Size = new System.Drawing.Size(356, 20);
			this.txtUPB.TabIndex = 7;
			this.txtUPB.Tag = "upb.codeupb?x";
			// 
			// txtDescrUPB
			// 
			this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtDescrUPB.Location = new System.Drawing.Point(102, 11);
			this.txtDescrUPB.Multiline = true;
			this.txtDescrUPB.Name = "txtDescrUPB";
			this.txtDescrUPB.ReadOnly = true;
			this.txtDescrUPB.Size = new System.Drawing.Size(262, 91);
			this.txtDescrUPB.TabIndex = 4;
			this.txtDescrUPB.TabStop = false;
			this.txtDescrUPB.Tag = "upb.title";
			// 
			// btnUPBCode
			// 
			this.btnUPBCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
			this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUPBCode.Location = new System.Drawing.Point(8, 82);
			this.btnUPBCode.Name = "btnUPBCode";
			this.btnUPBCode.Size = new System.Drawing.Size(88, 20);
			this.btnUPBCode.TabIndex = 3;
			this.btnUPBCode.TabStop = false;
			this.btnUPBCode.Tag = "manage.upb.tree";
			this.btnUPBCode.Text = "U.P.B.";
			this.btnUPBCode.UseVisualStyleBackColor = false;
			// 
			// textBoxcompetencystart
			// 
			this.textBoxcompetencystart.Location = new System.Drawing.Point(292, 46);
			this.textBoxcompetencystart.Name = "textBoxcompetencystart";
			this.textBoxcompetencystart.Size = new System.Drawing.Size(90, 20);
			this.textBoxcompetencystart.TabIndex = 60;
			this.textBoxcompetencystart.Tag = "showcasedetail.competencystart";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(170, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(117, 13);
			this.label2.TabIndex = 59;
			this.label2.Text = "Data inizio competenza";
			// 
			// textBoxcompetencystop
			// 
			this.textBoxcompetencystop.Location = new System.Drawing.Point(520, 46);
			this.textBoxcompetencystop.Name = "textBoxcompetencystop";
			this.textBoxcompetencystop.Size = new System.Drawing.Size(90, 20);
			this.textBoxcompetencystop.TabIndex = 62;
			this.textBoxcompetencystop.Tag = "showcasedetail.competencystop";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(403, 49);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(111, 13);
			this.label3.TabIndex = 61;
			this.label3.Text = "Data fine competenza";
			// 
			// gBoxupbIVA
			// 
			this.gBoxupbIVA.Controls.Add(this.txtUPBiva);
			this.gBoxupbIVA.Controls.Add(this.label7);
			this.gBoxupbIVA.Controls.Add(this.btnUpbIVA);
			this.gBoxupbIVA.Controls.Add(this.textBox4);
			this.gBoxupbIVA.Location = new System.Drawing.Point(396, 141);
			this.gBoxupbIVA.Name = "gBoxupbIVA";
			this.gBoxupbIVA.Size = new System.Drawing.Size(375, 140);
			this.gBoxupbIVA.TabIndex = 63;
			this.gBoxupbIVA.TabStop = false;
			this.gBoxupbIVA.Tag = "AutoChoose.txtUPBiva.default.(active=\'S\')";
			this.gBoxupbIVA.Text = "UPB per la Contabilizzazione IVA";
			// 
			// txtUPBiva
			// 
			this.txtUPBiva.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtUPBiva.Location = new System.Drawing.Point(9, 110);
			this.txtUPBiva.Name = "txtUPBiva";
			this.txtUPBiva.Size = new System.Drawing.Size(360, 20);
			this.txtUPBiva.TabIndex = 7;
			this.txtUPBiva.Tag = "upb_iva.codeupb?x";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(7, 24);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(95, 50);
			this.label7.TabIndex = 6;
			this.label7.Text = "Utilizzare solo se diverso dal principale";
			// 
			// btnUpbIVA
			// 
			this.btnUpbIVA.BackColor = System.Drawing.SystemColors.Control;
			this.btnUpbIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnUpbIVA.ForeColor = System.Drawing.SystemColors.ControlText;
			this.btnUpbIVA.Location = new System.Drawing.Point(10, 82);
			this.btnUpbIVA.Name = "btnUpbIVA";
			this.btnUpbIVA.Size = new System.Drawing.Size(76, 20);
			this.btnUpbIVA.TabIndex = 5;
			this.btnUpbIVA.TabStop = false;
			this.btnUpbIVA.Tag = "manage.upb_iva.tree";
			this.btnUpbIVA.Text = "U.P.B.";
			this.btnUpbIVA.UseVisualStyleBackColor = false;
			// 
			// textBox4
			// 
			this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox4.Location = new System.Drawing.Point(112, 16);
			this.textBox4.Multiline = true;
			this.textBox4.Name = "textBox4";
			this.textBox4.ReadOnly = true;
			this.textBox4.Size = new System.Drawing.Size(257, 86);
			this.textBox4.TabIndex = 4;
			this.textBox4.TabStop = false;
			this.textBox4.Tag = "upb_iva.title";
			// 
			// Frm_showcasedetail_single
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(779, 593);
			this.Controls.Add(this.gBoxupbIVA);
			this.Controls.Add(this.textBoxcompetencystop);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxcompetencystart);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.gboxUPB);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.txtDisponibilit‡);
			this.Controls.Add(this.lblDisponibilit‡);
			this.Controls.Add(this.gbxPrezzoUnitario);
			this.Controls.Add(this.gbxAliquotaIVA);
			this.Controls.Add(this.txtNomeArticolo);
			this.Controls.Add(this.lblNomeArticolo);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gboxListino);
			this.Controls.Add(this.groupBox1);
			this.Name = "Frm_showcasedetail_single";
			this.Text = "Frm_showcasedetail_single";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.gboxListino.ResumeLayout(false);
			this.gboxListino.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pbox)).EndInit();
			this.gbxAliquotaIVA.ResumeLayout(false);
			this.gbxAliquotaIVA.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.gbxPrezzoUnitario.ResumeLayout(false);
			this.gbxPrezzoUnitario.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.gboxUPB.ResumeLayout(false);
			this.gboxUPB.PerformLayout();
			this.gBoxupbIVA.ResumeLayout(false);
			this.gBoxupbIVA.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDescrizioneClassificazione;
        private System.Windows.Forms.Label lblDescrizioneClassificazione;
        private System.Windows.Forms.TextBox txtCodiceClassificazione;
        private System.Windows.Forms.Label lblCodiceClassificazione;
        private System.Windows.Forms.GroupBox gboxListino;
        private System.Windows.Forms.CheckBox chkFiltraDescrizioneClassificazione;
        private System.Windows.Forms.Button btnListino;
        private System.Windows.Forms.TextBox txtCodiceListino;
        public vistaForm DS;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnAnnulla;
        private System.Windows.Forms.PictureBox pbox;
        private System.Windows.Forms.TextBox txtDescrizioneListino;
        private System.Windows.Forms.TextBox txtNomeArticolo;
        private System.Windows.Forms.Label lblDescrizioneListino;
        private System.Windows.Forms.Label lblNomeArticolo;
        private System.Windows.Forms.Label lblPrezzoUnitario;
        private System.Windows.Forms.TextBox txtPrezzoUnitario;
        private System.Windows.Forms.GroupBox gbxAliquotaIVA;
        private System.Windows.Forms.Button btnTipoIVA;
        private System.Windows.Forms.ComboBox cmbTipoIVA;
        private System.Windows.Forms.TextBox txtImportoIVA;
        private System.Windows.Forms.Label lblImportoIVA;
        private System.Windows.Forms.GroupBox gbxPrezzoUnitario;
        private System.Windows.Forms.TextBox txtAliquotaIVA;
        private System.Windows.Forms.Label lblAliquotaIVA;
        private System.Windows.Forms.Label lblDisponibilit‡;
        private System.Windows.Forms.TextBox txtDisponibilit‡;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cmbTipoContrattoAttivo;
        private System.Windows.Forms.GroupBox gboxUPB;
        public System.Windows.Forms.TextBox txtUPB;
        private System.Windows.Forms.TextBox txtDescrUPB;
        private System.Windows.Forms.Button btnUPBCode;
		private System.Windows.Forms.ComboBox cmbTipoFattura;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxcompetencystart;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBoxcompetencystop;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox gBoxupbIVA;
		public System.Windows.Forms.TextBox txtUPBiva;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnUpbIVA;
		private System.Windows.Forms.TextBox textBox4;
	}
}