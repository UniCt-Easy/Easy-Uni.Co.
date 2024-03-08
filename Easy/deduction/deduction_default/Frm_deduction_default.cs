
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


using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;

namespace deduction_default//tipodeduzionelista//
{
    /// <summary>
    /// Summary description for frmtipodeduzionelista.
    /// </summary>
    public class Frm_deduction_default : MetaDataForm {
        public vistaForm DS;
        //private System.ComponentModel.IContainer components;
        private System.Windows.Forms.TextBox SubEntity_txtAliquota;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox SubEntity_txtMassimale;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox SubEntity_txtFranchigia;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox SubEntity_txtDescrizioneCod;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoImponibile;
        private System.Windows.Forms.Button btnTipoImponibile;
        private System.Windows.Forms.TextBox SubEntity_txtCodiceDeduzione;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpCodiceDeduzione;
        private System.Windows.Forms.TextBox SubEntity_txtDescEstesa;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label6;
        MetaData Meta;
        bool IsAdmin;

        public Frm_deduction_default() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {

            }
            base.Dispose(disposing);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            IsAdmin = false;
            string filteresercizio;

            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
            grpCodiceDeduzione.Text = "Dati del " + Meta.GetSys("esercizio").ToString();
            HelpForm.SetFormatForColumn(DS.deductioncode.Columns["rate"], "p");
            filteresercizio = Meta.QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.taxablekind, filteresercizio, null, true);
            GetData.SetStaticFilter(DS.deductioncode, filteresercizio);
            GetData.CacheTable(DS.deductionview, filteresercizio, null, false);
        }

        public void MetaData_BeforeFill() {
            //Controlla che vi sia o Crea una nuova riga nelle DataTable "codicededuzione" con valori di default.
            //			SolaLettura(false);
            if (Meta.InsertMode) {
                SolaLettura(!IsAdmin);
                CreateCodiceDeduzioneRow();
            }
            if (Meta.EditMode) {
                SolaLettura(!IsAdmin);
                //CreateCodiceDeduzioneRow();
            }
        }

        public void CreateCodiceDeduzioneRow() {
            if (Meta.IsEmpty) return;
            DataRow DRtipodeduzione = HelpForm.GetLastSelected(DS.deduction);
            DataRow[] R = DS.Tables["deductioncode"].Select("(iddeduction=" +
                QueryCreator.quotedstrvalue(DRtipodeduzione["iddeduction"], false) + ")");
            if (R.Length == 0) {
                MetaData MetaCD = MetaData.GetMetaData(this, "deductioncode");
                MetaCD.SetDefaults(DS.deductioncode);
                DataRow DR = MetaCD.Get_New_Row(DRtipodeduzione, DS.deductioncode);
            }
        }

        public void MetaData_AfterClear() {
            SolaLettura(!IsAdmin);
        }

        public void SolaLettura(bool noscrittura) {
            SubEntity_txtCodiceDeduzione.ReadOnly = noscrittura;
            SubEntity_txtDescrizioneCod.ReadOnly = noscrittura;
            SubEntity_txtFranchigia.ReadOnly = noscrittura;
            SubEntity_txtMassimale.ReadOnly = noscrittura;
            SubEntity_txtAliquota.ReadOnly = noscrittura;
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.DS = new deduction_default.vistaForm();
            this.SubEntity_txtAliquota = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SubEntity_txtMassimale = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.SubEntity_txtFranchigia = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.SubEntity_txtDescrizioneCod = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SubEntity_txtDescEstesa = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoImponibile = new System.Windows.Forms.ComboBox();
            this.btnTipoImponibile = new System.Windows.Forms.Button();
            this.SubEntity_txtCodiceDeduzione = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpCodiceDeduzione = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpCodiceDeduzione.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // SubEntity_txtAliquota
            // 
            this.SubEntity_txtAliquota.Location = new System.Drawing.Point(584, 80);
            this.SubEntity_txtAliquota.Name = "SubEntity_txtAliquota";
            this.SubEntity_txtAliquota.Size = new System.Drawing.Size(80, 20);
            this.SubEntity_txtAliquota.TabIndex = 5;
            this.SubEntity_txtAliquota.Tag = "deductioncode.rate.fixed.4..%.100?deductionview.rate.fixed.4..%.100";
            this.SubEntity_txtAliquota.Text = "";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(496, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 76;
            this.label11.Text = "Aliquota:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(136, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 24);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Tag = "deduction.flagdeductibleexpense:S:N";
            this.checkBox1.Text = "Onere deducibile";
            // 
            // SubEntity_txtMassimale
            // 
            this.SubEntity_txtMassimale.Location = new System.Drawing.Point(328, 80);
            this.SubEntity_txtMassimale.Name = "SubEntity_txtMassimale";
            this.SubEntity_txtMassimale.Size = new System.Drawing.Size(104, 20);
            this.SubEntity_txtMassimale.TabIndex = 4;
            this.SubEntity_txtMassimale.Tag = "deductioncode.maximal?deductionview.maximal";
            this.SubEntity_txtMassimale.Text = "";
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(256, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 23);
            this.label10.TabIndex = 73;
            this.label10.Text = "Massimale";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtFranchigia
            // 
            this.SubEntity_txtFranchigia.Location = new System.Drawing.Point(88, 80);
            this.SubEntity_txtFranchigia.Name = "SubEntity_txtFranchigia";
            this.SubEntity_txtFranchigia.TabIndex = 3;
            this.SubEntity_txtFranchigia.Tag = "deductioncode.exemption?deductionview.exemption";
            this.SubEntity_txtFranchigia.Text = "";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 23);
            this.label9.TabIndex = 71;
            this.label9.Text = "Franchigia";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtDescrizioneCod
            // 
            this.SubEntity_txtDescrizioneCod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.SubEntity_txtDescrizioneCod.Location = new System.Drawing.Point(128, 48);
            this.SubEntity_txtDescrizioneCod.Name = "SubEntity_txtDescrizioneCod";
            this.SubEntity_txtDescrizioneCod.Size = new System.Drawing.Size(540, 20);
            this.SubEntity_txtDescrizioneCod.TabIndex = 2;
            this.SubEntity_txtDescrizioneCod.Tag = "deductioncode.description?deductionview.deductiontitle";
            this.SubEntity_txtDescrizioneCod.Text = "";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 23);
            this.label8.TabIndex = 69;
            this.label8.Text = "Descrizione Cod.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(136, 120);
            this.textBox2.Name = "textBox2";
            this.textBox2.TabIndex = 6;
            this.textBox2.Tag = "deduction.validitystart";
            this.textBox2.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 24);
            this.label2.TabIndex = 65;
            this.label2.Text = "Data Inizio";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(552, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 72);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo Calcolo";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(8, 48);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(112, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "deduction.calculationkind:M";
            this.radioButton2.Text = "Mensile";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(112, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "deduction.calculationkind:G";
            this.radioButton1.Text = "Giornaliero";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(136, 152);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(280, 20);
            this.textBox5.TabIndex = 8;
            this.textBox5.Tag = "deduction.evaluatesp";
            this.textBox5.Text = "";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 64;
            this.label5.Text = "SP Calcolo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // SubEntity_txtDescEstesa
            // 
            this.SubEntity_txtDescEstesa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.SubEntity_txtDescEstesa.Location = new System.Drawing.Point(128, 112);
            this.SubEntity_txtDescEstesa.Multiline = true;
            this.SubEntity_txtDescEstesa.Name = "SubEntity_txtDescEstesa";
            this.SubEntity_txtDescEstesa.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SubEntity_txtDescEstesa.Size = new System.Drawing.Size(540, 152);
            this.SubEntity_txtDescEstesa.TabIndex = 11;
            this.SubEntity_txtDescEstesa.Tag = "deductioncode.longdescription?deductionview.longdescription";
            this.SubEntity_txtDescEstesa.Text = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 23);
            this.label4.TabIndex = 62;
            this.label4.Text = "Descrizione Estesa";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(136, 88);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(544, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Tag = "deduction.description";
            this.textBox3.Text = "";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 23);
            this.label3.TabIndex = 59;
            this.label3.Text = "Descrizione";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cmbTipoImponibile
            // 
            this.cmbTipoImponibile.DataSource = this.DS.taxablekind;
            this.cmbTipoImponibile.DisplayMember = "description";
            this.cmbTipoImponibile.Location = new System.Drawing.Point(136, 24);
            this.cmbTipoImponibile.Name = "cmbTipoImponibile";
            this.cmbTipoImponibile.Size = new System.Drawing.Size(248, 21);
            this.cmbTipoImponibile.TabIndex = 2;
            this.cmbTipoImponibile.Tag = "deduction.taxablecode";
            this.cmbTipoImponibile.ValueMember = "taxablecode";
            // 
            // btnTipoImponibile
            // 
            this.btnTipoImponibile.Location = new System.Drawing.Point(8, 24);
            this.btnTipoImponibile.Name = "btnTipoImponibile";
            this.btnTipoImponibile.Size = new System.Drawing.Size(104, 23);
            this.btnTipoImponibile.TabIndex = 1;
            this.btnTipoImponibile.Tag = "manage.taxablekind.default";
            this.btnTipoImponibile.Text = "Tipo Imponibile";
            // 
            // SubEntity_txtCodiceDeduzione
            // 
            this.SubEntity_txtCodiceDeduzione.Location = new System.Drawing.Point(128, 16);
            this.SubEntity_txtCodiceDeduzione.Name = "SubEntity_txtCodiceDeduzione";
            this.SubEntity_txtCodiceDeduzione.Size = new System.Drawing.Size(168, 20);
            this.SubEntity_txtCodiceDeduzione.TabIndex = 1;
            this.SubEntity_txtCodiceDeduzione.Tag = "deductioncode.code?deductionview.deductioncode";
            this.SubEntity_txtCodiceDeduzione.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 23);
            this.label1.TabIndex = 52;
            this.label1.Text = "Codice Deduzione";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // grpCodiceDeduzione
            // 
            this.grpCodiceDeduzione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCodiceDeduzione.Controls.Add(this.SubEntity_txtMassimale);
            this.grpCodiceDeduzione.Controls.Add(this.label11);
            this.grpCodiceDeduzione.Controls.Add(this.label10);
            this.grpCodiceDeduzione.Controls.Add(this.SubEntity_txtAliquota);
            this.grpCodiceDeduzione.Controls.Add(this.label9);
            this.grpCodiceDeduzione.Controls.Add(this.SubEntity_txtFranchigia);
            this.grpCodiceDeduzione.Controls.Add(this.SubEntity_txtDescrizioneCod);
            this.grpCodiceDeduzione.Controls.Add(this.label8);
            this.grpCodiceDeduzione.Controls.Add(this.label1);
            this.grpCodiceDeduzione.Controls.Add(this.SubEntity_txtCodiceDeduzione);
            this.grpCodiceDeduzione.Controls.Add(this.label4);
            this.grpCodiceDeduzione.Controls.Add(this.SubEntity_txtDescEstesa);
            this.grpCodiceDeduzione.Location = new System.Drawing.Point(8, 184);
            this.grpCodiceDeduzione.Name = "grpCodiceDeduzione";
            this.grpCodiceDeduzione.Size = new System.Drawing.Size(676, 272);
            this.grpCodiceDeduzione.TabIndex = 10;
            this.grpCodiceDeduzione.TabStop = false;
            this.grpCodiceDeduzione.Text = "Dati dell\'esercizio";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(576, 152);
            this.textBox4.Name = "textBox4";
            this.textBox4.TabIndex = 9;
            this.textBox4.Tag = "deduction.evaluationorder";
            this.textBox4.Text = "";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(464, 144);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(104, 23);
            this.label12.TabIndex = 67;
            this.label12.Text = "Ordine Valutazione";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(576, 120);
            this.textBox7.Name = "textBox7";
            this.textBox7.TabIndex = 7;
            this.textBox7.Tag = "deduction.validitystop";
            this.textBox7.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(464, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 23);
            this.label6.TabIndex = 68;
            this.label6.Text = "Data Fine";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Frm_deduction_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(692, 462);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.grpCodiceDeduzione);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTipoImponibile);
            this.Controls.Add(this.btnTipoImponibile);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox7);
            this.Name = "Frm_deduction_default";
            this.Text = "frmtipodeduzionelista";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grpCodiceDeduzione.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

    }
}
