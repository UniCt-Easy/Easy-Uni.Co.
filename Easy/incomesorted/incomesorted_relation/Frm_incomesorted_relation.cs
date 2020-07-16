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

using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Globalization;
using metaeasylibrary;
using metadatalibrary;
using gestioneclassificazioni;
//using movimentofunctions;//movimentofunctions
using funzioni_configurazione;//funzioni_configurazione

namespace incomesorted_relation //impclassentrata_main//
{
    /// <summary>
    /// Summary description for frmimpclassentrata_main.
    /// </summary>
    public class Frm_incomesorted_relation : System.Windows.Forms.Form {
        private System.Windows.Forms.TextBox txtImporto;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox grpClassificazione;
        private System.Windows.Forms.TextBox txtDescrClass;
        private System.Windows.Forms.TextBox txtCodiceClass;
        private System.Windows.Forms.Button btnClassificazione;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpMovimento;
        public System.Windows.Forms.TextBox valoreS5;
        public System.Windows.Forms.TextBox valoreN5;
        public System.Windows.Forms.TextBox valoreS4;
        public System.Windows.Forms.TextBox valoreN4;
        public System.Windows.Forms.TextBox valoreN2;
        public System.Windows.Forms.TextBox valoreS3;
        public System.Windows.Forms.TextBox valoreS2;
        public System.Windows.Forms.TextBox valoreN1;
        public System.Windows.Forms.TextBox valoreN3;
        public System.Windows.Forms.TextBox valoreS1;
        public System.Windows.Forms.Label labelS5;
        public System.Windows.Forms.Label labelS4;
        public System.Windows.Forms.Label labelS3;
        public System.Windows.Forms.Label labelS2;
        public System.Windows.Forms.Label labelS1;
        public System.Windows.Forms.Label labelN5;
        public System.Windows.Forms.Label labelN4;
        public System.Windows.Forms.Label labelN3;
        public System.Windows.Forms.Label labelN2;
        public System.Windows.Forms.Label labelN1;
        private System.Windows.Forms.CheckBox chkIncompleto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelignoradate;
        private System.Windows.Forms.CheckBox chkIgnoraDate;
        private System.Windows.Forms.Label labelslash;
        private System.Windows.Forms.Label datalabel;
        public System.Windows.Forms.TextBox DataFine;
        public System.Windows.Forms.TextBox DataInizio;
        private System.Windows.Forms.TextBox txtSubMov;
        MetaData Meta;
        public object param;
        bool HasBeenActivated;
        public /*Rana:impclassentrata_main.*/ vistaForm DS;
        private System.Windows.Forms.Button btnMovimento;
        private System.Windows.Forms.Label labelPerc;
        private System.Windows.Forms.TextBox txtPercentuale;
        private System.Windows.Forms.Label lblPercentuale;
        public System.Windows.Forms.TextBox valoreV5;
        public System.Windows.Forms.TextBox valoreV4;
        public System.Windows.Forms.TextBox valoreV3;
        public System.Windows.Forms.TextBox valoreV2;
        public System.Windows.Forms.TextBox valoreV1;
        public System.Windows.Forms.Label labelV5;
        public System.Windows.Forms.Label labelV4;
        public System.Windows.Forms.Label labelV3;
        public System.Windows.Forms.Label labelV2;
        public System.Windows.Forms.Label labelV1;
        string lastidentrata = "";
        bool InChiusura = false;
        bool primolivello = false;
        bool secondolivello = false;
        bool terzolivello = false;
        bool formcorto = false;
        decimal importototale;
        decimal importoresiduo;
        private System.Windows.Forms.GroupBox groupBox1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Frm_incomesorted_relation() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            HasBeenActivated = false;

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            InChiusura = true;
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources =
                new System.ComponentModel.ComponentResourceManager(typeof(Frm_incomesorted_relation));
            this.txtSubMov = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grpClassificazione = new System.Windows.Forms.GroupBox();
            this.txtDescrClass = new System.Windows.Forms.TextBox();
            this.txtCodiceClass = new System.Windows.Forms.TextBox();
            this.btnClassificazione = new System.Windows.Forms.Button();
            this.grpMovimento = new System.Windows.Forms.GroupBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMovimento = new System.Windows.Forms.Button();
            this.valoreS5 = new System.Windows.Forms.TextBox();
            this.valoreN5 = new System.Windows.Forms.TextBox();
            this.valoreS4 = new System.Windows.Forms.TextBox();
            this.valoreN4 = new System.Windows.Forms.TextBox();
            this.valoreN2 = new System.Windows.Forms.TextBox();
            this.valoreS3 = new System.Windows.Forms.TextBox();
            this.valoreS2 = new System.Windows.Forms.TextBox();
            this.valoreN1 = new System.Windows.Forms.TextBox();
            this.valoreN3 = new System.Windows.Forms.TextBox();
            this.valoreS1 = new System.Windows.Forms.TextBox();
            this.labelS5 = new System.Windows.Forms.Label();
            this.labelS4 = new System.Windows.Forms.Label();
            this.labelS3 = new System.Windows.Forms.Label();
            this.labelS2 = new System.Windows.Forms.Label();
            this.labelS1 = new System.Windows.Forms.Label();
            this.labelN5 = new System.Windows.Forms.Label();
            this.labelN4 = new System.Windows.Forms.Label();
            this.labelN3 = new System.Windows.Forms.Label();
            this.labelN2 = new System.Windows.Forms.Label();
            this.labelN1 = new System.Windows.Forms.Label();
            this.chkIncompleto = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelignoradate = new System.Windows.Forms.Label();
            this.chkIgnoraDate = new System.Windows.Forms.CheckBox();
            this.labelslash = new System.Windows.Forms.Label();
            this.datalabel = new System.Windows.Forms.Label();
            this.DataFine = new System.Windows.Forms.TextBox();
            this.DataInizio = new System.Windows.Forms.TextBox();
            this.DS = new incomesorted_relation.vistaForm();
            this.labelPerc = new System.Windows.Forms.Label();
            this.txtPercentuale = new System.Windows.Forms.TextBox();
            this.lblPercentuale = new System.Windows.Forms.Label();
            this.valoreV5 = new System.Windows.Forms.TextBox();
            this.valoreV4 = new System.Windows.Forms.TextBox();
            this.valoreV3 = new System.Windows.Forms.TextBox();
            this.valoreV2 = new System.Windows.Forms.TextBox();
            this.valoreV1 = new System.Windows.Forms.TextBox();
            this.labelV5 = new System.Windows.Forms.Label();
            this.labelV4 = new System.Windows.Forms.Label();
            this.labelV3 = new System.Windows.Forms.Label();
            this.labelV2 = new System.Windows.Forms.Label();
            this.labelV1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpClassificazione.SuspendLayout();
            this.grpMovimento.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSubMov
            // 
            this.txtSubMov.Location = new System.Drawing.Point(272, 16);
            this.txtSubMov.Name = "txtSubMov";
            this.txtSubMov.Size = new System.Drawing.Size(80, 20);
            this.txtSubMov.TabIndex = 1;
            this.txtSubMov.TabStop = false;
            this.txtSubMov.Tag = "incomesorted.idsubclass?incomesortedview.idsubclass";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(8, 128);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(104, 20);
            this.txtImporto.TabIndex = 3;
            this.txtImporto.Tag = "incomesorted.amount?incomesortedview.amount";
            this.txtImporto.Leave += new System.EventHandler(this.txtImporto_Leave);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(8, 48);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(344, 48);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "incomesorted.description?incomesortedview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(248, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 24);
            this.label5.TabIndex = 19;
            this.label5.Text = "#";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 17;
            this.label4.Text = "Importo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 15;
            this.label3.Text = "Descrizione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpClassificazione
            // 
            this.grpClassificazione.Controls.Add(this.txtDescrClass);
            this.grpClassificazione.Controls.Add(this.txtCodiceClass);
            this.grpClassificazione.Controls.Add(this.btnClassificazione);
            this.grpClassificazione.Location = new System.Drawing.Point(8, 64);
            this.grpClassificazione.Name = "grpClassificazione";
            this.grpClassificazione.Size = new System.Drawing.Size(360, 80);
            this.grpClassificazione.TabIndex = 2;
            this.grpClassificazione.TabStop = false;
            this.grpClassificazione.Tag = "AutoManage.txtCodiceClass.tree";
            this.grpClassificazione.Text = "Classificazione (Ë necessario scegliere prima il movimento)";
            // 
            // txtDescrClass
            // 
            this.txtDescrClass.Location = new System.Drawing.Point(144, 16);
            this.txtDescrClass.Multiline = true;
            this.txtDescrClass.Name = "txtDescrClass";
            this.txtDescrClass.ReadOnly = true;
            this.txtDescrClass.Size = new System.Drawing.Size(200, 53);
            this.txtDescrClass.TabIndex = 5;
            this.txtDescrClass.TabStop = false;
            this.txtDescrClass.Tag = "sorting.description";
            // 
            // txtCodiceClass
            // 
            this.txtCodiceClass.Location = new System.Drawing.Point(16, 48);
            this.txtCodiceClass.Name = "txtCodiceClass";
            this.txtCodiceClass.Size = new System.Drawing.Size(104, 20);
            this.txtCodiceClass.TabIndex = 1;
            this.txtCodiceClass.Tag = "sorting.sortcode?incomesortedview.sortcode";
            // 
            // btnClassificazione
            // 
            this.btnClassificazione.Image = ((System.Drawing.Image) (resources.GetObject("btnClassificazione.Image")));
            this.btnClassificazione.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClassificazione.Location = new System.Drawing.Point(16, 16);
            this.btnClassificazione.Name = "btnClassificazione";
            this.btnClassificazione.Size = new System.Drawing.Size(104, 23);
            this.btnClassificazione.TabIndex = 11;
            this.btnClassificazione.TabStop = false;
            this.btnClassificazione.Tag = "manage.sorting.tree";
            this.btnClassificazione.Text = "Classificazione:";
            this.btnClassificazione.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpMovimento
            // 
            this.grpMovimento.Controls.Add(this.txtNumero);
            this.grpMovimento.Controls.Add(this.label2);
            this.grpMovimento.Controls.Add(this.txtEsercizio);
            this.grpMovimento.Controls.Add(this.label1);
            this.grpMovimento.Controls.Add(this.btnMovimento);
            this.grpMovimento.Location = new System.Drawing.Point(8, 8);
            this.grpMovimento.Name = "grpMovimento";
            this.grpMovimento.Size = new System.Drawing.Size(360, 56);
            this.grpMovimento.TabIndex = 1;
            this.grpMovimento.TabStop = false;
            this.grpMovimento.Tag = "AutoChoose.txtNumero.movimentiaperti";
            this.grpMovimento.Text = "Movimento di Entrata";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(288, 24);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.Tag = "incomeview.nmov?incomesortedview.nmov";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(240, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(176, 24);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.Size = new System.Drawing.Size(56, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "incomeview.ymov.year?incomesortedview.ymov.year";
            this.txtEsercizio.Leave += new System.EventHandler(this.txtEsercEntrata_Leave);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(120, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnMovimento
            // 
            this.btnMovimento.Location = new System.Drawing.Point(8, 20);
            this.btnMovimento.Name = "btnMovimento";
            this.btnMovimento.Size = new System.Drawing.Size(112, 24);
            this.btnMovimento.TabIndex = 20;
            this.btnMovimento.TabStop = false;
            this.btnMovimento.Tag = "";
            this.btnMovimento.Text = "Fase movimento";
            this.btnMovimento.Click += new System.EventHandler(this.btnMovimento_Click);
            // 
            // valoreS5
            // 
            this.valoreS5.Location = new System.Drawing.Point(520, 248);
            this.valoreS5.Name = "valoreS5";
            this.valoreS5.Size = new System.Drawing.Size(128, 20);
            this.valoreS5.TabIndex = 242;
            this.valoreS5.Tag = "";
            this.valoreS5.Visible = false;
            // 
            // valoreN5
            // 
            this.valoreN5.Location = new System.Drawing.Point(384, 248);
            this.valoreN5.Name = "valoreN5";
            this.valoreN5.Size = new System.Drawing.Size(128, 20);
            this.valoreN5.TabIndex = 241;
            this.valoreN5.Tag = "";
            this.valoreN5.Visible = false;
            // 
            // valoreS4
            // 
            this.valoreS4.Location = new System.Drawing.Point(520, 208);
            this.valoreS4.Name = "valoreS4";
            this.valoreS4.Size = new System.Drawing.Size(128, 20);
            this.valoreS4.TabIndex = 240;
            this.valoreS4.Tag = "";
            this.valoreS4.Visible = false;
            // 
            // valoreN4
            // 
            this.valoreN4.Location = new System.Drawing.Point(384, 208);
            this.valoreN4.Name = "valoreN4";
            this.valoreN4.Size = new System.Drawing.Size(128, 20);
            this.valoreN4.TabIndex = 239;
            this.valoreN4.Tag = "";
            this.valoreN4.Visible = false;
            // 
            // valoreN2
            // 
            this.valoreN2.Location = new System.Drawing.Point(384, 128);
            this.valoreN2.Name = "valoreN2";
            this.valoreN2.Size = new System.Drawing.Size(128, 20);
            this.valoreN2.TabIndex = 227;
            this.valoreN2.Tag = "";
            this.valoreN2.Visible = false;
            // 
            // valoreS3
            // 
            this.valoreS3.Location = new System.Drawing.Point(520, 168);
            this.valoreS3.Name = "valoreS3";
            this.valoreS3.Size = new System.Drawing.Size(128, 20);
            this.valoreS3.TabIndex = 236;
            this.valoreS3.Tag = "";
            this.valoreS3.Visible = false;
            // 
            // valoreS2
            // 
            this.valoreS2.Location = new System.Drawing.Point(520, 128);
            this.valoreS2.Name = "valoreS2";
            this.valoreS2.Size = new System.Drawing.Size(128, 20);
            this.valoreS2.TabIndex = 235;
            this.valoreS2.Tag = "";
            this.valoreS2.Visible = false;
            // 
            // valoreN1
            // 
            this.valoreN1.Location = new System.Drawing.Point(384, 88);
            this.valoreN1.Name = "valoreN1";
            this.valoreN1.Size = new System.Drawing.Size(128, 20);
            this.valoreN1.TabIndex = 226;
            this.valoreN1.Tag = "";
            this.valoreN1.Visible = false;
            // 
            // valoreN3
            // 
            this.valoreN3.Location = new System.Drawing.Point(384, 168);
            this.valoreN3.Name = "valoreN3";
            this.valoreN3.Size = new System.Drawing.Size(128, 20);
            this.valoreN3.TabIndex = 228;
            this.valoreN3.Tag = "";
            this.valoreN3.Visible = false;
            // 
            // valoreS1
            // 
            this.valoreS1.Location = new System.Drawing.Point(520, 88);
            this.valoreS1.Name = "valoreS1";
            this.valoreS1.Size = new System.Drawing.Size(128, 20);
            this.valoreS1.TabIndex = 234;
            this.valoreS1.Tag = "";
            this.valoreS1.Visible = false;
            // 
            // labelS5
            // 
            this.labelS5.Location = new System.Drawing.Point(520, 232);
            this.labelS5.Name = "labelS5";
            this.labelS5.Size = new System.Drawing.Size(128, 16);
            this.labelS5.TabIndex = 238;
            this.labelS5.Tag = "";
            this.labelS5.Text = "labelS5";
            this.labelS5.Visible = false;
            // 
            // labelS4
            // 
            this.labelS4.Location = new System.Drawing.Point(520, 192);
            this.labelS4.Name = "labelS4";
            this.labelS4.Size = new System.Drawing.Size(128, 16);
            this.labelS4.TabIndex = 237;
            this.labelS4.Tag = "";
            this.labelS4.Text = "labelS4";
            this.labelS4.Visible = false;
            // 
            // labelS3
            // 
            this.labelS3.Location = new System.Drawing.Point(520, 152);
            this.labelS3.Name = "labelS3";
            this.labelS3.Size = new System.Drawing.Size(128, 16);
            this.labelS3.TabIndex = 233;
            this.labelS3.Tag = "";
            this.labelS3.Text = "labelS3";
            this.labelS3.Visible = false;
            // 
            // labelS2
            // 
            this.labelS2.Location = new System.Drawing.Point(520, 112);
            this.labelS2.Name = "labelS2";
            this.labelS2.Size = new System.Drawing.Size(128, 16);
            this.labelS2.TabIndex = 232;
            this.labelS2.Tag = "";
            this.labelS2.Text = "labelS2";
            this.labelS2.Visible = false;
            // 
            // labelS1
            // 
            this.labelS1.Location = new System.Drawing.Point(520, 72);
            this.labelS1.Name = "labelS1";
            this.labelS1.Size = new System.Drawing.Size(128, 16);
            this.labelS1.TabIndex = 231;
            this.labelS1.Tag = "";
            this.labelS1.Text = "labelS1";
            this.labelS1.Visible = false;
            // 
            // labelN5
            // 
            this.labelN5.Location = new System.Drawing.Point(384, 232);
            this.labelN5.Name = "labelN5";
            this.labelN5.Size = new System.Drawing.Size(128, 16);
            this.labelN5.TabIndex = 230;
            this.labelN5.Tag = "";
            this.labelN5.Text = "labelN5";
            this.labelN5.Visible = false;
            // 
            // labelN4
            // 
            this.labelN4.Location = new System.Drawing.Point(384, 192);
            this.labelN4.Name = "labelN4";
            this.labelN4.Size = new System.Drawing.Size(128, 16);
            this.labelN4.TabIndex = 229;
            this.labelN4.Tag = "";
            this.labelN4.Text = "labelN4";
            this.labelN4.Visible = false;
            // 
            // labelN3
            // 
            this.labelN3.Location = new System.Drawing.Point(384, 152);
            this.labelN3.Name = "labelN3";
            this.labelN3.Size = new System.Drawing.Size(128, 16);
            this.labelN3.TabIndex = 225;
            this.labelN3.Tag = "";
            this.labelN3.Text = "labelN3";
            this.labelN3.Visible = false;
            // 
            // labelN2
            // 
            this.labelN2.Location = new System.Drawing.Point(384, 112);
            this.labelN2.Name = "labelN2";
            this.labelN2.Size = new System.Drawing.Size(128, 16);
            this.labelN2.TabIndex = 224;
            this.labelN2.Tag = "";
            this.labelN2.Text = "labelN2";
            this.labelN2.Visible = false;
            // 
            // labelN1
            // 
            this.labelN1.Location = new System.Drawing.Point(384, 72);
            this.labelN1.Name = "labelN1";
            this.labelN1.Size = new System.Drawing.Size(128, 16);
            this.labelN1.TabIndex = 223;
            this.labelN1.Tag = "";
            this.labelN1.Text = "labelN1";
            this.labelN1.Visible = false;
            // 
            // chkIncompleto
            // 
            this.chkIncompleto.Location = new System.Drawing.Point(16, 384);
            this.chkIncompleto.Name = "chkIncompleto";
            this.chkIncompleto.Size = new System.Drawing.Size(152, 16);
            this.chkIncompleto.TabIndex = 8;
            this.chkIncompleto.Tag = "incomesorted.tobecontinued:S:N";
            this.chkIncompleto.Text = "Da completare in seguito";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelignoradate);
            this.panel1.Controls.Add(this.chkIgnoraDate);
            this.panel1.Controls.Add(this.labelslash);
            this.panel1.Controls.Add(this.datalabel);
            this.panel1.Controls.Add(this.DataFine);
            this.panel1.Controls.Add(this.DataInizio);
            this.panel1.Location = new System.Drawing.Point(8, 320);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(360, 56);
            this.panel1.TabIndex = 4;
            // 
            // labelignoradate
            // 
            this.labelignoradate.Location = new System.Drawing.Point(24, 0);
            this.labelignoradate.Name = "labelignoradate";
            this.labelignoradate.Size = new System.Drawing.Size(280, 16);
            this.labelignoradate.TabIndex = 1002;
            this.labelignoradate.Tag = "sortingkind.nodatelabel";
            this.labelignoradate.Text = "ignora date custom";
            // 
            // chkIgnoraDate
            // 
            this.chkIgnoraDate.Location = new System.Drawing.Point(8, 0);
            this.chkIgnoraDate.Name = "chkIgnoraDate";
            this.chkIgnoraDate.Size = new System.Drawing.Size(20, 16);
            this.chkIgnoraDate.TabIndex = 5;
            this.chkIgnoraDate.Tag = "incomesorted.flagnodate:S:N";
            this.chkIgnoraDate.CheckStateChanged += new System.EventHandler(this.chkIgnoraDate_CheckStateChanged);
            // 
            // labelslash
            // 
            this.labelslash.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F,
                System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelslash.Location = new System.Drawing.Point(152, 32);
            this.labelslash.Name = "labelslash";
            this.labelslash.Size = new System.Drawing.Size(12, 16);
            this.labelslash.TabIndex = 144;
            this.labelslash.Text = "--";
            // 
            // datalabel
            // 
            this.datalabel.Location = new System.Drawing.Point(16, 16);
            this.datalabel.Name = "datalabel";
            this.datalabel.Size = new System.Drawing.Size(280, 16);
            this.datalabel.TabIndex = 143;
            this.datalabel.Tag = "sortingkind.labelfordate";
            this.datalabel.Text = "datalabel";
            this.datalabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DataFine
            // 
            this.DataFine.Location = new System.Drawing.Point(168, 32);
            this.DataFine.Name = "DataFine";
            this.DataFine.Size = new System.Drawing.Size(128, 20);
            this.DataFine.TabIndex = 7;
            this.DataFine.Tag = "incomesorted.stop";
            // 
            // DataInizio
            // 
            this.DataInizio.Location = new System.Drawing.Point(16, 32);
            this.DataInizio.Name = "DataInizio";
            this.DataInizio.Size = new System.Drawing.Size(128, 20);
            this.DataInizio.TabIndex = 6;
            this.DataInizio.Tag = "incomesorted.start";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // labelPerc
            // 
            this.labelPerc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Bold,
                System.Drawing.GraphicsUnit.Point, ((byte) (0)));
            this.labelPerc.Location = new System.Drawing.Point(240, 128);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(16, 16);
            this.labelPerc.TabIndex = 310;
            this.labelPerc.Text = "%";
            this.labelPerc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPercentuale
            // 
            this.txtPercentuale.Location = new System.Drawing.Point(144, 128);
            this.txtPercentuale.Name = "txtPercentuale";
            this.txtPercentuale.Size = new System.Drawing.Size(88, 20);
            this.txtPercentuale.TabIndex = 4;
            this.txtPercentuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentuale.Leave += new System.EventHandler(this.txtPercentuale_Leave);
            // 
            // lblPercentuale
            // 
            this.lblPercentuale.Location = new System.Drawing.Point(144, 112);
            this.lblPercentuale.Name = "lblPercentuale";
            this.lblPercentuale.Size = new System.Drawing.Size(88, 16);
            this.lblPercentuale.TabIndex = 309;
            this.lblPercentuale.Text = "Percentuale";
            this.lblPercentuale.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // valoreV5
            // 
            this.valoreV5.Location = new System.Drawing.Point(656, 248);
            this.valoreV5.Name = "valoreV5";
            this.valoreV5.Size = new System.Drawing.Size(128, 20);
            this.valoreV5.TabIndex = 320;
            this.valoreV5.Tag = "";
            this.valoreV5.Visible = false;
            // 
            // valoreV4
            // 
            this.valoreV4.Location = new System.Drawing.Point(656, 208);
            this.valoreV4.Name = "valoreV4";
            this.valoreV4.Size = new System.Drawing.Size(128, 20);
            this.valoreV4.TabIndex = 319;
            this.valoreV4.Tag = "";
            this.valoreV4.Visible = false;
            // 
            // valoreV3
            // 
            this.valoreV3.Location = new System.Drawing.Point(656, 168);
            this.valoreV3.Name = "valoreV3";
            this.valoreV3.Size = new System.Drawing.Size(128, 20);
            this.valoreV3.TabIndex = 316;
            this.valoreV3.Tag = "";
            this.valoreV3.Visible = false;
            // 
            // valoreV2
            // 
            this.valoreV2.Location = new System.Drawing.Point(656, 128);
            this.valoreV2.Name = "valoreV2";
            this.valoreV2.Size = new System.Drawing.Size(128, 20);
            this.valoreV2.TabIndex = 315;
            this.valoreV2.Tag = "";
            this.valoreV2.Visible = false;
            // 
            // valoreV1
            // 
            this.valoreV1.Location = new System.Drawing.Point(656, 88);
            this.valoreV1.Name = "valoreV1";
            this.valoreV1.Size = new System.Drawing.Size(128, 20);
            this.valoreV1.TabIndex = 314;
            this.valoreV1.Tag = "";
            this.valoreV1.Visible = false;
            // 
            // labelV5
            // 
            this.labelV5.Location = new System.Drawing.Point(656, 232);
            this.labelV5.Name = "labelV5";
            this.labelV5.Size = new System.Drawing.Size(128, 16);
            this.labelV5.TabIndex = 318;
            this.labelV5.Tag = "";
            this.labelV5.Text = "labelN5";
            this.labelV5.Visible = false;
            // 
            // labelV4
            // 
            this.labelV4.Location = new System.Drawing.Point(656, 192);
            this.labelV4.Name = "labelV4";
            this.labelV4.Size = new System.Drawing.Size(128, 16);
            this.labelV4.TabIndex = 317;
            this.labelV4.Tag = "";
            this.labelV4.Text = "labelN4";
            this.labelV4.Visible = false;
            // 
            // labelV3
            // 
            this.labelV3.Location = new System.Drawing.Point(656, 152);
            this.labelV3.Name = "labelV3";
            this.labelV3.Size = new System.Drawing.Size(128, 16);
            this.labelV3.TabIndex = 313;
            this.labelV3.Tag = "";
            this.labelV3.Text = "labelN3";
            this.labelV3.Visible = false;
            // 
            // labelV2
            // 
            this.labelV2.Location = new System.Drawing.Point(656, 112);
            this.labelV2.Name = "labelV2";
            this.labelV2.Size = new System.Drawing.Size(128, 16);
            this.labelV2.TabIndex = 312;
            this.labelV2.Tag = "";
            this.labelV2.Text = "labelN2";
            this.labelV2.Visible = false;
            // 
            // labelV1
            // 
            this.labelV1.Location = new System.Drawing.Point(656, 72);
            this.labelV1.Name = "labelV1";
            this.labelV1.Size = new System.Drawing.Size(128, 16);
            this.labelV1.TabIndex = 311;
            this.labelV1.Tag = "";
            this.labelV1.Text = "labelN1";
            this.labelV1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtSubMov);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.labelPerc);
            this.groupBox1.Controls.Add(this.lblPercentuale);
            this.groupBox1.Controls.Add(this.txtPercentuale);
            this.groupBox1.Location = new System.Drawing.Point(8, 144);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 168);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Contabili";
            // 
            // Frm_incomesorted_relation
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(794, 408);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.valoreV5);
            this.Controls.Add(this.valoreV4);
            this.Controls.Add(this.valoreV3);
            this.Controls.Add(this.valoreV2);
            this.Controls.Add(this.valoreV1);
            this.Controls.Add(this.valoreS5);
            this.Controls.Add(this.valoreN5);
            this.Controls.Add(this.valoreS4);
            this.Controls.Add(this.valoreN4);
            this.Controls.Add(this.valoreN2);
            this.Controls.Add(this.valoreS3);
            this.Controls.Add(this.valoreS2);
            this.Controls.Add(this.valoreN1);
            this.Controls.Add(this.valoreN3);
            this.Controls.Add(this.valoreS1);
            this.Controls.Add(this.labelV5);
            this.Controls.Add(this.labelV4);
            this.Controls.Add(this.labelV3);
            this.Controls.Add(this.labelV2);
            this.Controls.Add(this.labelV1);
            this.Controls.Add(this.chkIncompleto);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelS5);
            this.Controls.Add(this.labelS4);
            this.Controls.Add(this.labelS3);
            this.Controls.Add(this.labelS2);
            this.Controls.Add(this.labelS1);
            this.Controls.Add(this.labelN5);
            this.Controls.Add(this.labelN4);
            this.Controls.Add(this.labelN3);
            this.Controls.Add(this.labelN2);
            this.Controls.Add(this.labelN1);
            this.Controls.Add(this.grpClassificazione);
            this.Controls.Add(this.grpMovimento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_incomesorted_relation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmimpclassentrata_main";
            this.grpClassificazione.ResumeLayout(false);
            this.grpClassificazione.PerformLayout();
            this.grpMovimento.ResumeLayout(false);
            this.grpMovimento.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            object idsorkind = null;
            if (Meta.edit_type != "relation") {
                param = CfgFn.GetNoNullInt32( Meta.ExtraParameter.ToString());
                Meta.metaModel.setExtraParams(DS.sorting, QHS.CmpEq("idsorkind", param));
                DataTable DescrClass = Meta.Conn.RUN_SELECT("sortingkind", "description", null,
                    QHS.CmpEq("idsorkind", param), null, null, true);
                if (DescrClass.Rows.Count == 0)
                    Meta.Name = "Movimento di entrata a \"" + param + "\"";
                else
                    Meta.Name = "Movimento di entrata a \"" +
                                DescrClass.Rows[0]["description"].ToString() + "\"";

                Meta.DefaultListType = "lista." + param;
                idsorkind = param;
            }

            object classname = "";
            if (Meta.edit_type == "relation") { //Extract parameter from context filter 
                string fieldname = "idsor";
                int posizione = Meta.ContextFilter.IndexOf(fieldname);
                if (posizione != -1) {
                    int start = posizione + fieldname.Length + 1; //skips fieldname='
                    int stop = Meta.ContextFilter.IndexOf(")", start);
                    if (stop > start) {
                        param = Meta.ContextFilter.Substring(start, stop - start);
                        Meta.DefaultListType = "lista." + param;
                    }
                }

                idsorkind = CfgFn.GetNoNullInt32(Meta.Conn.DO_READ_VALUE("sorting", QHS.CmpEq("idsor", CfgFn.GetNoNullInt32(param)), "idsorkind"));
                classname = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("idsorkind", idsorkind), "description");

                if (classname != null) {
                    Meta.Name = "Imputazione entrata a \"" + classname.ToString() + "\"";
                }

            }

            string filter = QHS.CmpEq("idsorkind", idsorkind);
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.incomesorted, filteresercizio);
            GetData.SetStaticFilter(DS.incomesortedview, QHS.AppAnd(filter, filteresercizio));
            GetData.SetStaticFilter(DS.incomeview, filteresercizio);
            GetData.SetSorting(DS.incomesortedview, "ymov desc, nmov desc");

            GetData.CacheTable(DS.sortingkind, filter, null, false);
            grpClassificazione.Tag += "." + filter;
            btnClassificazione.Tag += "." + filter;

            DataTable ConfClassMovimento = Meta.Conn.RUN_SELECT("sortingkindview", "*", null,
                QHS.CmpEq("idsorkind", idsorkind), null, true);

            if (ConfClassMovimento.Rows.Count == 0) {
                MessageBox.Show("Non ho trovato il tipo classificazione " + classname.ToString() +
                                ". Provare ad aggiornare il menu da File/Menu/Aggiorna Menu ");
                Meta.CanSave = false;
                return;

            }
            /*
            if (ConfClassMovimento.Rows[0]["flagsubmovimento"].ToString()=="N")
            {
                MetaData.SetDefault(DS.incomesorted, "submovimento", 1);
                txtSubMov.ReadOnly=true;
            }
            */

            string fase = ConfClassMovimento.Rows[0]["incomephase"].ToString();
            object codicefase = ConfClassMovimento.Rows[0]["nphaseincome"];

            if (codicefase == DBNull.Value) {
                MessageBox.Show("Non Ë stata configurata la Fase di Entrata per il tipo classificazione " + (param) +
                                ". Completare la configurazione dal menu Configurazione/Classificazione/Tipo di Classificazione ");
            }

            grpMovimento.Text = fase;
            btnMovimento.Text = fase;
            string filtermovimento = //"(esercmovimento='"+Meta.Conn.sys["esercizio"].ToString()+"') AND"+
                QHS.CmpEq("nphase", CfgFn.GetNoNullInt32( codicefase));
            grpMovimento.Tag += "." + filtermovimento;
            btnMovimento.Tag += "." + filtermovimento;

            HelpForm.SetDenyNull(DS.incomesorted.Columns["tobecontinued"], true);
        }


        public void MetaData_AfterFill() {
            txtPercentuale.Visible = true;
            labelPerc.Visible = true;
            lblPercentuale.Visible = true;

            AnalizzaCheckIgnoraDate();
            if (Meta.FirstFillForThisRow && (DS.sortingkind.Rows.Count > 0)) {
                DataRow R = DS.incomesorted.Rows[0];
                if (R != null) {
                    lastidentrata = R["idinc"].ToString();
                    DataRow CurrTipo = DS.sortingkind.Rows[0];
                    object codicetipoclass = CurrTipo["idsorkind"];
                    DataTable TCurrEntrata = Meta.Conn.RUN_SELECT("incomeview", "*", null,
                        QHS.AppAnd(QHS.CmpEq("idinc", R["idinc"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio")))
                        , null, true);
                    DataRow CurrEntrata = null;
                    if ((TCurrEntrata != null) && (TCurrEntrata.Rows.Count > 0))
                        CurrEntrata = TCurrEntrata.Rows[0];
                    if (CurrEntrata != null) {
                        if (Meta.InsertMode) {
                            grpClassificazione.Enabled = true;
                            txtCodiceClass.ReadOnly = false;
                        }
                        else {
                            grpClassificazione.Enabled = false;
                            txtCodiceClass.ReadOnly = true;
                        }

                        importototale = GetNoNullDecimal(CurrEntrata["curramount"]);
                        decimal importoclassificato = GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("incomesortedview",
                            QHS.AppAnd(QHS.CmpEq("idinc", R["idinc"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                                QHS.CmpEq("idsorkind", codicetipoclass)), "ISNULL(SUM(amount),0)"));

                        if (CurrTipo["totalexpression"].ToString() == "") {
                            importoresiduo = importototale - importoclassificato;
                        }
                        else
                            importoresiduo = importototale;

                        decimal percentuale = 100;
                        decimal importomovimento = GetNoNullDecimal(R["amount"]);
                        if (importototale != 0) percentuale = importomovimento / importototale * 100;
                        decimal rounded = Math.Round(percentuale, 4);
                        txtPercentuale.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
                        //rounded.ToString("n");

                        GestioneClassificazioni.CalcAvailableIDClassesFor(DS.sorting,
                            Meta, codicetipoclass, CurrEntrata, "income");

                    }
                    else {
                        txtPercentuale.Text = "";
                        grpClassificazione.Enabled = false;
                        txtCodiceClass.ReadOnly = true;
                    }
                }
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "incomeview" && R != null) {
                if (Meta.InsertMode) {
                    grpClassificazione.Enabled = true;
                    txtCodiceClass.ReadOnly = false;
                }

                if (Meta.InsertMode && (DS.sortingkind.Rows.Count > 0)) {
                    DataRow CurrTipo = DS.sortingkind.Rows[0];
                    importototale = GetNoNullDecimal(R["curramount"]);
                    object codicetipoclass = CurrTipo["idsorkind"];
                    decimal importoclassificato = GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("incomesortedview",
                        QHS.AppAnd(QHS.CmpEq("idinc", R["idinc"]), QHS.CmpEq("ayear", Meta.GetSys("esercizio")),
                            QHS.CmpEq("idsorkind", codicetipoclass)), "ISNULL(SUM(amount),0)"));
                    if (CurrTipo["totalexpression"].ToString() == "") {
                        importoresiduo = importototale - importoclassificato;
                        txtImporto.Text = GetNoNullDecimal(importoresiduo).ToString("C");
                        ImpostaPercentuale(importoresiduo);
                    }
                    else {
                        importoresiduo = importototale;
                        decimal importo = GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                            txtImporto.Text, HelpForm.GetStandardTag(txtImporto.Tag)));
                        ImpostaPercentuale(importo);
                    }

                    GestioneClassificazioni.CalcAvailableIDClassesFor(DS.sorting, Meta, codicetipoclass, R, "income");
                    if (R["idinc"].ToString() != lastidentrata) {
                        lastidentrata = R["idinc"].ToString();
                        DS.incomesorted.Rows[0]["idsor"] = 0;
                        txtCodiceClass.Text = "";
                        txtDescrClass.Text = "";
                        DS.sorting.Clear();
                    }

                    //DS.impclassspesa.Rows[0]["importo"]=R["importocorrente"];
                    //Meta.FreshForm();
                }
            }

            if ((Meta.EditMode || Meta.InsertMode) && (T.TableName == "incomeview") && (R == null)) {
                DS.incomesorted.Rows[0]["idsor"] = 0;
                lastidentrata = "";
                txtCodiceClass.Text = "";
                txtDescrClass.Text = "";
                DS.sorting.Clear();
                grpClassificazione.Enabled = false;
                txtCodiceClass.ReadOnly = true;
            }
        }

        public void MetaData_AfterClear() {
            txtPercentuale.Visible = false;
            labelPerc.Visible = false;
            lblPercentuale.Visible = false;
            txtPercentuale.Text = "";
            grpClassificazione.Enabled = true;
            txtCodiceClass.ReadOnly = false;
        }

        TextBox GetTxtByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            if (!typeof(TextBox).IsAssignableFrom(Ctrl.FieldType)) return null;
            TextBox T = (TextBox) Ctrl.GetValue(this);
            return T;
        }

        Label GetLabByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            if (!typeof(Label).IsAssignableFrom(Ctrl.FieldType)) return null;
            Label L = (Label) Ctrl.GetValue(this);
            return L;
        }

        /// <summary>
        /// Restituisce un textbox ed imposta in automatico le variabili primo,secondo e terzolivello
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        TextBox GetTextBoxNum(int i) {
            int col = (i - 1) / 5;
            int row = ((i - 1) % 5) + 1;
            string suffix = "";
            switch (col) {
                case 0:
                    suffix = "N";
                    primolivello = true;
                    break;
                case 1:
                    suffix = "S";
                    secondolivello = true;
                    break;
                case 2:
                    suffix = "V";
                    terzolivello = true;
                    break;
            }

            suffix += row.ToString();
            TextBox T = GetTxtByName("valore" + suffix);
            return T;

        }

        /// <summary>
        /// Restituisce un textbox ed imposta in automatico le variabili fromcorto,
        ///			primo,secondo e terzolivello
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        Label GetLabelNum(int i) {
            int col = (i - 1) / 5;
            int row = ((i - 1) % 5) + 1;
            if (row > 3) formcorto = false;
            string suffix = "";
            switch (col) {
                case 0:
                    suffix = "N";
                    break;
                case 1:
                    suffix = "S";
                    break;
                case 2:
                    suffix = "V";
                    break;
            }

            suffix += row.ToString();
            Label L = GetLabByName("label" + suffix);
            return L;

        }



        public void MetaData_AfterActivation() {
            if (DS.sortingkind.Rows.Count == 0) return;
            DataRow Rtipo = DS.sortingkind.Rows[0];
            //txtPercentuale.Leave+=new EventHandler();
            int NControls = 0;
            bool read_only = false;


            if (Rtipo["flagdate"].ToString().ToLower() != "s") {
                chkIgnoraDate.Visible = false;
                labelignoradate.Visible = false;
                datalabel.Visible = false;
                labelslash.Visible = false;
                DataInizio.Visible = false;
                DataFine.Visible = false;
                chkIncompleto.Visible = false;
                formcorto = true;
            }
            else {
                HelpForm.SetDenyNull(DS.incomesorted.Columns["flagnodate"], true);
                formcorto = false;
            }

            labelignoradate.Text = Rtipo["nodatelabel"].ToString();
            datalabel.Text = Rtipo["labelfordate"].ToString();
            HasBeenActivated = true;

            foreach (string kind in new string[] {"n", "s", "v"}) {
                for (int i = 1; i <= 5; i++) {


                    string suffix = kind + i.ToString();
                    if (Rtipo["label" + suffix].ToString() == "") continue;
                    NControls++;
                    TextBox T = GetTextBoxNum(NControls);
                    T.Visible = true;
                    Label L = GetLabelNum(NControls);
                    L.Visible = true;
                    T.Tag = "incomesorted.value" + kind + i.ToString();

					Meta.myHelpForm.AddEvents(T);
					if (kind == "v")
						T.Tag = T.Tag.ToString() + ".N";

					L.Text = Rtipo["label" + kind + i.ToString()].ToString();
                    //L.Tag="tipoclassmovimenti.etichetta"+kind+i.ToString();

                    switch (Rtipo["locked" + suffix].ToString().ToLower()) {
                        case "s": {
                            T.Visible = false;
                            break;
                        }
                        case "n": {
                            T.Visible = true;
                            T.ReadOnly = read_only && !MustAsk(suffix);
                            break;
                        }
                        default: {
                            T.Visible = true;
                            T.ReadOnly = !MustAsk(suffix);
                            break;
                        }
                    }

                    if (Rtipo["forced" + suffix].ToString().ToLower() == "s") {
                        if (DS.incomesorted.Columns["value" + suffix].DefaultValue == DBNull.Value) {
                            if (kind == "n") MetaData.SetDefault(DS.incomesorted, "value" + suffix, 0);
                            if (kind == "v") MetaData.SetDefault(DS.incomesorted, "value" + suffix, 0);
                            if (kind == "s") MetaData.SetDefault(DS.incomesorted, "value" + suffix, "");
                        }

                        T.Visible = true;
                        T.ReadOnly = false;
                        HelpForm.SetDenyNull(DS.Tables["incomesorted"].Columns["value" + suffix], true);
                    }
                }


            }



            if (terzolivello) {
                Width = 864;
            }
            else {
                if (secondolivello) {
                    Width = 704;
                }
                else {
                    if (primolivello)
                        Width = 536;
                    else
                        Width = 376;
                }
            }

            if (formcorto) Height = 440;
            // Rusciano G. 20.07.2005
            // La riga che chiama il metodo CenterToScreen Ë stata ricommentata in quanto il posizionamento
            // al centro dello schermo non funziona nel caso in cui la finestra di MetaData non Ë impostata
            // a tutto schermo
            AutoScrollMinSize = new System.Drawing.Size(Size.Width - 8, Size.Height - 30); //-8,-30
            FormBorderStyle = FormBorderStyle.FixedDialog;
            AutoScroll = false;
            FrmCenter();

//			CenterToScreen();
        }

        bool MustAsk(string suffix) {
            if (DS.sortingtranslation.Rows.Count == 0) return true;
            DataRow CurrTrad = DS.sortingtranslation.Rows[0];
            string field = "default" + suffix.ToLower();
            if (CurrTrad[field].ToString().Trim() == "?") return true;
            return false;
        }


        void FrmCenter() {
            Form Par = MdiParent;
            int posx = (Par.Size.Width - Size.Width - 8) / 2;
            int posy = (Par.Size.Height - Size.Height - 130) / 2;
            if (posy < 0) posy = 0;
            if (posx < 0) posx = 0;
            StartPosition = FormStartPosition.Manual;
            Location = new System.Drawing.Point(posx, posy);
        }

        void AnalizzaCheckIgnoraDate() {
            if (chkIgnoraDate.Visible == false) return;
            if (chkIgnoraDate.CheckState == CheckState.Indeterminate) chkIgnoraDate.CheckState = CheckState.Unchecked;
            bool MostraDataInizioFine = !(chkIgnoraDate.CheckState == CheckState.Checked);
            datalabel.Visible = MostraDataInizioFine;
            DataInizio.Visible = MostraDataInizioFine;
            DataFine.Visible = MostraDataInizioFine;
            labelslash.Visible = MostraDataInizioFine;
        }

        private void chkIgnoraDate_CheckStateChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (!HasBeenActivated) return;
            AnalizzaCheckIgnoraDate();
        }

        void ImpostaPercentuale(decimal importomovimento) {
            decimal percentuale = 100;
            if (importototale != 0) percentuale = importomovimento / importototale * 100;
            decimal rounded = Math.Round(percentuale, 4);
            // calcola la percentuale in base all'importo
            txtPercentuale.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
        }

        private void txtImporto_Leave(object sender, System.EventArgs e) {
            if (!txtImporto.Modified) return;
            if (Meta.IsEmpty) return;
            //			importomovimento= Decimal.Parse(txtImporto.Text,
            //				NumberStyles.Currency,
            //				NumberFormatInfo.CurrentInfo);

            decimal importo = 0;
            if (!checkimporto()) {
                // ripristina l'importo originale
                decimal importomovimento;
                if (Meta.EditMode)
                    importomovimento = GetNoNullDecimal(DS.incomesorted.Rows[0]["amount", DataRowVersion.Original]);
                else
                    importomovimento = GetNoNullDecimal(DS.incomesorted.Rows[0]["amount", DataRowVersion.Default]);

                if (Meta.EditMode) {
                    txtImporto.Text = importomovimento.ToString("c");
                    importo = importomovimento;
                }
            }
            else {
                decimal importomovimento = GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtImporto.Text, HelpForm.GetStandardTag(txtImporto.Tag)));
                ImpostaPercentuale(importomovimento);
            }


            UpdateCampiChiocciola(importo);

        }

        void UpdateCampiChiocciola(decimal importo) {
            foreach (string kind in new string[] {"N", "S", "V"}) {
                for (int i = 1; i <= 5; i++) {
                    string suffix = kind + i.ToString();
                    if (IsChiocciola(suffix)) {
                        TextBox T = GetTxtByName("valore" + suffix);
                        T.Text = importo.ToString("c");
                    }
                }
            }
        }

        bool IsChiocciola(string suffix) {
            if (DS.sortingtranslation.Rows.Count == 0) return false;
            string field = "default" + suffix.ToLower();
            DataRow CurrTrad = DS.sortingtranslation.Rows[0];
            if (CurrTrad[field].ToString().Trim() == "@") return true;
            return false;
        }

        private void txtEsercEntrata_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (Meta.EditMode) return;

            string esercentrata = txtEsercizio.Text.Trim();
            if (esercentrata == "") {
                MetaData.Choose(this, "choose.incomeview.unknown.clear");
                return;
            }

            //if txtEsercEntrata is not Empty:
            if (Meta.IsEmpty) return;

            if (DS.incomeview.Rows.Count > 0) {
                if (esercentrata == DS.incomeview.Rows[0]["ymov"].ToString())
                    return;
                else {
                    ClearEntrata(false);
                    return;
                }
            }
        }

        private void ClearEntrata(bool ClearEsercizio) {
            //causa errore dopo un getformdata
            //			txtNumVariazione.Text="";
            txtNumero.Text = "";
            if (ClearEsercizio) txtEsercizio.Text = "";
            if (Meta.IsEmpty) return;
            if (!Meta.InsertMode) return; //idpsesa can be changed only on insert!
            DS.incomesorted.Rows[0]["idinc"] = 0;
        }


        private void txtPercentuale_Leave(object sender, System.EventArgs e) {
            // ripristina l'importo originale
            if (!txtPercentuale.Modified) return;

            if (!checkpercentuale()) {
                decimal percentuale = 100;
                decimal importomovimento = 0;
                try {
                    importomovimento = GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                        txtImporto.Text, HelpForm.GetStandardTag(txtImporto.Tag)));

                }
                catch {
                }

                if (importototale != 0) percentuale = importomovimento / importototale * 100;
                decimal rounded = Math.Round(percentuale, 4);
                // calcola la percentuale in base all'importo
                txtPercentuale.Text = HelpForm.StringValue(rounded, "x.y.fixed.4...1");
            }
            else {
                // calcola l'importo in base alla percentuale
                decimal perc = Decimal.Parse(txtPercentuale.Text,
                    NumberStyles.Number,
                    NumberFormatInfo.CurrentInfo);
                decimal importo = perc * importototale / 100;
                txtImporto.Text = importo.ToString("c");
                UpdateCampiChiocciola(importo);
                txtPercentuale.Text = HelpForm.StringValue(perc, "x.y.fixed.4...1");
            }
        }

        private bool checkpercentuale() {
            bool OK = false;
            if (txtPercentuale.Text == "") return false;
            decimal percentmax = 0;
            decimal importooriginale = 0;
            if (Meta.EditMode)
                importooriginale = GetNoNullDecimal(DS.incomesorted.Rows[0]["amount", DataRowVersion.Original]);
            if (importototale != 0) percentmax = (importoresiduo + importooriginale) / importototale * 100;
            string errmsg = "Il valore percentuale dovrebbe essere un numero compreso \r" +
                            "tra 0 e " + percentmax.ToString("n") + ". Proseguo comunque?";
            try {
                decimal percent = Decimal.Parse(txtPercentuale.Text,
                    NumberStyles.Number,
                    NumberFormatInfo.CurrentInfo);
                if ((percent < 0) || (percent > percentmax)) {
                    OK = (MessageBox.Show(errmsg, "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
                }
                else {
                    OK = true;
                }

            }
            catch {
                MessageBox.Show("E' necessario digitare un numero", "Avviso", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }

            return OK;
        }

        private bool checkimporto() {
            bool OK = false;
            decimal importooriginale = 0;
            if (Meta.EditMode)
                importooriginale = GetNoNullDecimal(DS.incomesorted.Rows[0]["amount",
                    DataRowVersion.Original]);

            if (txtImporto.Text == "") return false;
            string errmsg = "L'importo dovrebbe essere un numero compreso \r" +
                            "tra 0 e " + (importoresiduo + importooriginale).ToString("c") + ". Proseguo comunque?";
            try {
                decimal importo = GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(Decimal),
                    txtImporto.Text, HelpForm.GetStandardTag(txtImporto.Tag)));

                if ((importo >= 0) && (importo <= (importoresiduo + importooriginale))) {
                    OK = true;
                }
                else {
                    OK = (MessageBox.Show(errmsg, "Avviso", MessageBoxButtons.YesNo) == DialogResult.Yes);
                }

            }
            catch {
                MessageBox.Show("E' necessario inserire un numero", "Avviso", System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Exclamation);
                return false;
            }

            return OK;
        }


        static int GetNoNullInt32(object O) {
            if (O == null) return 0;
            if (O == DBNull.Value) return 0;
            try {
                return Convert.ToInt32(O);
            }
            catch {
                return 0;
            }
        }

        static decimal GetNoNullDecimal(object O) {
            if (O == null) return 0;
            if (O == DBNull.Value) return 0;
            try {
                return Convert.ToDecimal(O);
            }
            catch {
                return 0;
            }
        }

        private void btnMovimento_Click(object sender, System.EventArgs e) {
            int esercizio = (int) Meta.GetSys("esercizio");
            int esercText = CfgFn.GetNoNullInt32(txtEsercizio.Text);
            string MyFilter = QHS.CmpEq("ayear", esercizio);
            if (esercText != 0) MyFilter = GetData.MergeFilters(MyFilter, QHS.CmpEq("ymov", esercText));
            Meta.DoMainCommand("choose.incomeview.movimentiaperti." + MyFilter);          
        }


    }
}
