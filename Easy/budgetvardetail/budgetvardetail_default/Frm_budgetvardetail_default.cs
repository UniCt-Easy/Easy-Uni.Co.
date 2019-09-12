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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using System.Data;
using metadatalibrary;
using funzioni_configurazione; 


namespace budgetvardetail_default 
{
    /// <summary>
    /// Summary description for frmDettaglioVariazionePrevisioneAnnuale.
    /// Revised by Nino on 22/12/2002
    /// Revised by Nino on 9/1/2003
    /// </summary>
    public class Frm_budgetvardetail_default : System.Windows.Forms.Form
    {
        private System.Windows.Forms.TextBox txtDataContabile;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEsercizio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        public vistaForm DS;
        private System.Windows.Forms.Button btnVariazione;
        private System.Windows.Forms.GroupBox groupBox5;
        MetaData Meta;
        string filteresercizio;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private GroupBox groupBox2;
        private Label label4;
        private TextBox textBox2;
        private GroupBox gboxStato;
        private ComboBox cmbStatus;
        private TextBox txtImporto;
        private RadioButton rdbDiminuzione;
        private RadioButton rdbAumento;
        private GroupBox grpImporto;
        private GroupBox gboxResponsabile;
        public TextBox txtResponsabile;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        public GroupBox gboxclass;
        public Button btnCodice1;
        public TextBox txtDenom1;
        public TextBox txtCodice;
    

        public Frm_budgetvardetail_default() {
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
         
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_budgetvardetail_default));
            this.DS = new budgetvardetail_default.vistaForm();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.gboxResponsabile = new System.Windows.Forms.GroupBox();
            this.txtResponsabile = new System.Windows.Forms.TextBox();
            this.gboxStato = new System.Windows.Forms.GroupBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.btnVariazione = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.rdbDiminuzione = new System.Windows.Forms.RadioButton();
            this.rdbAumento = new System.Windows.Forms.RadioButton();
            this.grpImporto = new System.Windows.Forms.GroupBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.gboxclass = new System.Windows.Forms.GroupBox();
            this.btnCodice1 = new System.Windows.Forms.Button();
            this.txtDenom1 = new System.Windows.Forms.TextBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.gboxResponsabile.SuspendLayout();
            this.gboxStato.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpImporto.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.gboxclass.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.gboxResponsabile);
            this.groupBox5.Controls.Add(this.gboxStato);
            this.groupBox5.Controls.Add(this.txtDataContabile);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.txtNumero);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.txtEsercizio);
            this.groupBox5.Controls.Add(this.btnVariazione);
            this.groupBox5.Controls.Add(this.txtDescrizione);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(4, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(634, 182);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "AutoChoose.txtNumero.default";
            this.groupBox5.Text = "Dati variazione";
            // 
            // gboxResponsabile
            // 
            this.gboxResponsabile.Controls.Add(this.txtResponsabile);
            this.gboxResponsabile.Location = new System.Drawing.Point(16, 129);
            this.gboxResponsabile.Name = "gboxResponsabile";
            this.gboxResponsabile.Size = new System.Drawing.Size(294, 40);
            this.gboxResponsabile.TabIndex = 6;
            this.gboxResponsabile.TabStop = false;
            this.gboxResponsabile.Tag = "AutoChoose.txtResponsabile.default.(financeactive=\'S\')";
            this.gboxResponsabile.Text = "Responsabile";
            // 
            // txtResponsabile
            // 
            this.txtResponsabile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponsabile.Location = new System.Drawing.Point(11, 14);
            this.txtResponsabile.Name = "txtResponsabile";
            this.txtResponsabile.Size = new System.Drawing.Size(273, 20);
            this.txtResponsabile.TabIndex = 0;
            this.txtResponsabile.Tag = "manager.title?x";
            // 
            // gboxStato
            // 
            this.gboxStato.Controls.Add(this.cmbStatus);
            this.gboxStato.Location = new System.Drawing.Point(361, 12);
            this.gboxStato.Name = "gboxStato";
            this.gboxStato.Size = new System.Drawing.Size(256, 44);
            this.gboxStato.TabIndex = 1;
            this.gboxStato.TabStop = false;
            this.gboxStato.Text = "Stato";
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DataSource = this.DS.budgetvarstatus;
            this.cmbStatus.DisplayMember = "description";
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Location = new System.Drawing.Point(6, 15);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(243, 21);
            this.cmbStatus.TabIndex = 43;
            this.cmbStatus.Tag = "budgetvar.idbudgetvarstatus?budgetvardetailview.idbudgetvarstatus";
            this.cmbStatus.ValueMember = "idbudgetvarstatus";
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(537, 149);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.ReadOnly = true;
            this.txtDataContabile.Size = new System.Drawing.Size(80, 20);
            this.txtDataContabile.TabIndex = 19;
            this.txtDataContabile.TabStop = false;
            this.txtDataContabile.Tag = "budgetvar.adate";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(98, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(280, 17);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(64, 20);
            this.txtNumero.TabIndex = 2;
            this.txtNumero.Tag = "budgetvar.nbudgetvar?budgetvardetailview.nbudgetvar";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(228, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(445, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 21);
            this.label5.TabIndex = 18;
            this.label5.Text = "Data contabile:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(158, 17);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(64, 20);
            this.txtEsercizio.TabIndex = 5;
            this.txtEsercizio.TabStop = false;
            this.txtEsercizio.Tag = "";
            this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnVariazione
            // 
            this.btnVariazione.Location = new System.Drawing.Point(16, 16);
            this.btnVariazione.Name = "btnVariazione";
            this.btnVariazione.Size = new System.Drawing.Size(72, 23);
            this.btnVariazione.TabIndex = 1;
            this.btnVariazione.TabStop = false;
            this.btnVariazione.Tag = "choose.budgetvar.default";
            this.btnVariazione.Text = "Variazione";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(16, 68);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.ReadOnly = true;
            this.txtDescrizione.Size = new System.Drawing.Size(294, 55);
            this.txtDescrizione.TabIndex = 5;
            this.txtDescrizione.TabStop = false;
            this.txtDescrizione.Tag = "budgetvar.description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Descrizione Variazione";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(329, 397);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(292, 52);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "budgetvardetail.description";
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(262, 397);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 18);
            this.label8.TabIndex = 30;
            this.label8.Text = "Descrizione:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Location = new System.Drawing.Point(5, 455);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(633, 72);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Gestione interfaccia web";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Annotazioni";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(85, 16);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(531, 50);
            this.textBox2.TabIndex = 2;
            this.textBox2.Tag = "budgetvardetail.annotation";
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(7, 19);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(120, 20);
            this.txtImporto.TabIndex = 3;
            this.txtImporto.Tag = "budgetvardetail.amount";
            // 
            // rdbDiminuzione
            // 
            this.rdbDiminuzione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbDiminuzione.Location = new System.Drawing.Point(154, 32);
            this.rdbDiminuzione.Name = "rdbDiminuzione";
            this.rdbDiminuzione.Size = new System.Drawing.Size(90, 16);
            this.rdbDiminuzione.TabIndex = 2;
            this.rdbDiminuzione.TabStop = true;
            this.rdbDiminuzione.Tag = "-";
            this.rdbDiminuzione.Text = "Diminuzione";
            // 
            // rdbAumento
            // 
            this.rdbAumento.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbAumento.Checked = true;
            this.rdbAumento.Location = new System.Drawing.Point(154, 14);
            this.rdbAumento.Name = "rdbAumento";
            this.rdbAumento.Size = new System.Drawing.Size(79, 16);
            this.rdbAumento.TabIndex = 1;
            this.rdbAumento.TabStop = true;
            this.rdbAumento.Tag = "+";
            this.rdbAumento.Text = "Aumento";
            // 
            // grpImporto
            // 
            this.grpImporto.Controls.Add(this.rdbAumento);
            this.grpImporto.Controls.Add(this.rdbDiminuzione);
            this.grpImporto.Controls.Add(this.txtImporto);
            this.grpImporto.Location = new System.Drawing.Point(5, 397);
            this.grpImporto.Name = "grpImporto";
            this.grpImporto.Size = new System.Drawing.Size(250, 52);
            this.grpImporto.TabIndex = 3;
            this.grpImporto.TabStop = false;
            this.grpImporto.Tag = "budgetvardetail.amount.valuesigned";
            this.grpImporto.Text = "Importo";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(3, 184);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(413, 104);
            this.gboxUPB.TabIndex = 1;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            this.gboxUPB.Text = "UPB";
            // 
            // txtUPB
            // 
            this.txtUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUPB.Location = new System.Drawing.Point(8, 77);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(396, 20);
            this.txtUPB.TabIndex = 5;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrUPB.Location = new System.Drawing.Point(175, 9);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(229, 62);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(8, 51);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "manage.upb.tree";
            this.btnUPBCode.Text = "UPB";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            // 
            // gboxclass
            // 
            this.gboxclass.Controls.Add(this.btnCodice1);
            this.gboxclass.Controls.Add(this.txtDenom1);
            this.gboxclass.Controls.Add(this.txtCodice);
            this.gboxclass.Location = new System.Drawing.Point(4, 290);
            this.gboxclass.Name = "gboxclass";
            this.gboxclass.Size = new System.Drawing.Size(413, 104);
            this.gboxclass.TabIndex = 31;
            this.gboxclass.TabStop = false;
            this.gboxclass.Tag = "AutoManage.txtCodice.treeclassmovimenti";
            this.gboxclass.Text = "Classificazione";
            // 
            // btnCodice1
            // 
            this.btnCodice1.Location = new System.Drawing.Point(4, 52);
            this.btnCodice1.Name = "btnCodice1";
            this.btnCodice1.Size = new System.Drawing.Size(88, 23);
            this.btnCodice1.TabIndex = 4;
            this.btnCodice1.Tag = "manage.sorting.tree";
            this.btnCodice1.Text = "Codice";
            this.btnCodice1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDenom1
            // 
            this.txtDenom1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenom1.Location = new System.Drawing.Point(161, 8);
            this.txtDenom1.Multiline = true;
            this.txtDenom1.Name = "txtDenom1";
            this.txtDenom1.ReadOnly = true;
            this.txtDenom1.Size = new System.Drawing.Size(244, 64);
            this.txtDenom1.TabIndex = 3;
            this.txtDenom1.TabStop = false;
            this.txtDenom1.Tag = "sorting.description";
            // 
            // txtCodice
            // 
            this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCodice.Location = new System.Drawing.Point(4, 78);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(399, 20);
            this.txtCodice.TabIndex = 2;
            this.txtCodice.Tag = "sorting.sortcode?x";
            // 
            // Frm_budgetvardetail_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(648, 531);
            this.Controls.Add(this.gboxclass);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.grpImporto);
            this.Controls.Add(this.label8);
            this.Name = "Frm_budgetvardetail_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDettaglioVariazionePrevisioneAnnuale";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gboxResponsabile.ResumeLayout(false);
            this.gboxResponsabile.PerformLayout();
            this.gboxStato.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.grpImporto.ResumeLayout(false);
            this.grpImporto.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.gboxclass.ResumeLayout(false);
            this.gboxclass.PerformLayout();
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
            filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filteresercvar = QHS.CmpEq("ybudgetvar", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.budgetvar, filteresercvar);
            GetData.SetStaticFilter(DS.budgetvardetail, filteresercvar);
            txtEsercizio.Text = Meta.GetSys("esercizio").ToString();
            GetData.CacheTable(DS.config, filteresercizio, null, false);
              //Come default visualizziamo i grp dell'importo
            grpImporto.Visible = true;

            string filter = (string)Meta.ExtraParameter;
            if (filter != null)
            {
                string filtercodice = QHS.CmpEq("idsorkind", filter);

                Meta.StartFilter = filtercodice;
                GetData.SetStaticFilter(DS.sorting, filtercodice);
                GetData.SetStaticFilter(DS.budgetvar, filtercodice);
                GetData.SetStaticFilter(DS.sortingkind, filtercodice);
            }
   
            //GetData.SetStaticFilter(DS.budgetvardetailview, filtercodice);

        }

       
        public void MetaData_AfterClear() {
            //Visualizza il default e reimpost i Tag.
            grpImporto.Visible = true;
            gboxResponsabile.Enabled = true;
            gboxStato.Enabled = true;
            btnUPBCode.Enabled = true;
            txtUPB.ReadOnly = false;
            btnCodice1.Enabled = true;
            txtCodice.ReadOnly = false;
 
            //Visualizza il default e reimposta i Tag.
            grpImporto.Visible = true;
           

            txtImporto.Text = "";
            rdbAumento.Checked = false;
            rdbDiminuzione.Checked = false;
            rdbAumento.Tag = "+";
            rdbDiminuzione.Tag = "-";
            grpImporto.Tag = "budgetvardetail.amount.valuesigned";
            txtImporto.Tag = "budgetvardetail.amount";
        }

        public void MetaData_AfterActivation() {
            if (DS.sortingkind.Rows.Count == 0) return;
            DataRow CurrTipo = DS.sortingkind.Rows[0];
            Meta.Name = "Dettagli Variazioni budget per \"" + CurrTipo["description"] + "\"";
            gboxclass.Text = CurrTipo["description"].ToString();
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (Meta.IsEmpty) {
                if (T.TableName == "budgetvar") {
          
                    gboxResponsabile.Enabled = R == null;
                    gboxStato.Enabled = R == null;
                    
                   
                }
            }
        }
        public void MetaData_BeforeFill() {
        }

        public void MetaData_AfterFill() {
            if (!Meta.IsEmpty)
            {
                gboxResponsabile.Enabled = false;
                gboxStato.Enabled = false;
            }
            if (Meta.EditMode) {
                btnUPBCode.Enabled = false;
                txtUPB.ReadOnly = true;
                btnCodice1.Enabled = false;
                txtCodice.ReadOnly = true;
            }
            else {
                btnUPBCode.Enabled = true;
                txtUPB.ReadOnly = false;
                btnCodice1.Enabled = true;
                txtCodice.ReadOnly = false;
            }

        }

    }
}
