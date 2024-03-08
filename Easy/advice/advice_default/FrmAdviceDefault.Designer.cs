
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


namespace advice_default {
    partial class FrmAldviceDefault {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAldviceDefault));
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.MetaDataToolBar = new System.Windows.Forms.ToolBar();
            this.seleziona = new System.Windows.Forms.ToolBarButton();
            this.impostaricerca = new System.Windows.Forms.ToolBarButton();
            this.effettuaricerca = new System.Windows.Forms.ToolBarButton();
            this.modifica = new System.Windows.Forms.ToolBarButton();
            this.inserisci = new System.Windows.Forms.ToolBarButton();
            this.inseriscicopia = new System.Windows.Forms.ToolBarButton();
            this.elimina = new System.Windows.Forms.ToolBarButton();
            this.Salva = new System.Windows.Forms.ToolBarButton();
            this.aggiorna = new System.Windows.Forms.ToolBarButton();
            this.MetaDataDetail = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnTestCrontabGen = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrontabGen = new System.Windows.Forms.Button();
            this.txtStopdate = new System.Windows.Forms.TextBox();
            this.lblCrontab = new System.Windows.Forms.Label();
            this.lblStopdate = new System.Windows.Forms.Label();
            this.txtCrontab = new System.Windows.Forms.TextBox();
            this.txtAdvice = new System.Windows.Forms.TextBox();
            this.dgrComunicazioni = new System.Windows.Forms.DataGrid();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAlertCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DS = new advice_default.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrComunicazioni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // MetaDataToolBar
            // 
            this.MetaDataToolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.MetaDataToolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.seleziona,
            this.impostaricerca,
            this.effettuaricerca,
            this.modifica,
            this.inserisci,
            this.inseriscicopia,
            this.elimina,
            this.Salva,
            this.aggiorna});
            this.MetaDataToolBar.ButtonSize = new System.Drawing.Size(56, 56);
            this.MetaDataToolBar.DropDownArrows = true;
            this.MetaDataToolBar.ImageList = this.images;
            this.MetaDataToolBar.Location = new System.Drawing.Point(0, 0);
            this.MetaDataToolBar.Name = "MetaDataToolBar";
            this.MetaDataToolBar.ShowToolTips = true;
            this.MetaDataToolBar.Size = new System.Drawing.Size(680, 106);
            this.MetaDataToolBar.TabIndex = 22;
            this.MetaDataToolBar.Tag = "";
            // 
            // seleziona
            // 
            this.seleziona.ImageIndex = 1;
            this.seleziona.Name = "seleziona";
            this.seleziona.Tag = "mainselect";
            this.seleziona.Text = "Seleziona";
            this.seleziona.ToolTipText = "Seleziona l\'elemento desiderato";
            // 
            // impostaricerca
            // 
            this.impostaricerca.ImageIndex = 10;
            this.impostaricerca.Name = "impostaricerca";
            this.impostaricerca.Tag = "mainsetsearch";
            this.impostaricerca.Text = "Imposta Ricerca";
            this.impostaricerca.ToolTipText = "Imposta una nuova ricerca";
            // 
            // effettuaricerca
            // 
            this.effettuaricerca.ImageIndex = 12;
            this.effettuaricerca.Name = "effettuaricerca";
            this.effettuaricerca.Tag = "maindosearch";
            this.effettuaricerca.Text = "Effettua Ricerca";
            this.effettuaricerca.ToolTipText = "Cerca in base ai dati immessi";
            // 
            // modifica
            // 
            this.modifica.ImageIndex = 6;
            this.modifica.Name = "modifica";
            this.modifica.Tag = "mainedit";
            this.modifica.Text = "Modifica";
            this.modifica.ToolTipText = "Modifica l\'elemento selezionato";
            // 
            // inserisci
            // 
            this.inserisci.ImageIndex = 0;
            this.inserisci.Name = "inserisci";
            this.inserisci.Tag = "maininsert";
            this.inserisci.Text = "Inserisci";
            this.inserisci.ToolTipText = "Inserisci un nuovo elemento";
            // 
            // inseriscicopia
            // 
            this.inseriscicopia.ImageIndex = 9;
            this.inseriscicopia.Name = "inseriscicopia";
            this.inseriscicopia.Tag = "maininsertcopy";
            this.inseriscicopia.Text = "Inserisci copia";
            this.inseriscicopia.ToolTipText = "Inserisci un nuovo elemento copiando i dati da quello attuale";
            // 
            // elimina
            // 
            this.elimina.ImageIndex = 3;
            this.elimina.Name = "elimina";
            this.elimina.Tag = "maindelete";
            this.elimina.Text = "Elimina";
            this.elimina.ToolTipText = "Elimina l\'elemento selezionato";
            // 
            // Salva
            // 
            this.Salva.ImageIndex = 2;
            this.Salva.Name = "Salva";
            this.Salva.Tag = "mainsave";
            this.Salva.Text = "Salva";
            this.Salva.ToolTipText = "Salva le modifiche effettuate";
            // 
            // aggiorna
            // 
            this.aggiorna.ImageIndex = 13;
            this.aggiorna.Name = "aggiorna";
            this.aggiorna.Tag = "mainrefresh";
            this.aggiorna.Text = "Aggiorna";
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Controls.Add(this.txtAdvice);
            this.MetaDataDetail.Controls.Add(this.dgrComunicazioni);
            this.MetaDataDetail.Controls.Add(this.textBox1);
            this.MetaDataDetail.Controls.Add(this.label1);
            this.MetaDataDetail.Controls.Add(this.label8);
            this.MetaDataDetail.Controls.Add(this.txtAlertCode);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Location = new System.Drawing.Point(6, 51);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(668, 491);
            this.MetaDataDetail.TabIndex = 23;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.btnTestCrontabGen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnCrontabGen);
            this.groupBox1.Controls.Add(this.txtStopdate);
            this.groupBox1.Controls.Add(this.lblCrontab);
            this.groupBox1.Controls.Add(this.lblStopdate);
            this.groupBox1.Controls.Add(this.txtCrontab);
            this.groupBox1.Location = new System.Drawing.Point(376, 183);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 164);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Schedulazione";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.Location = new System.Drawing.Point(11, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(122, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Tag = "advice.adate";
            // 
            // btnTestCrontabGen
            // 
            this.btnTestCrontabGen.Location = new System.Drawing.Point(141, 68);
            this.btnTestCrontabGen.Name = "btnTestCrontabGen";
            this.btnTestCrontabGen.Size = new System.Drawing.Size(122, 46);
            this.btnTestCrontabGen.TabIndex = 15;
            this.btnTestCrontabGen.Text = "Riepilogo";
            this.btnTestCrontabGen.UseVisualStyleBackColor = true;
            this.btnTestCrontabGen.Click += new System.EventHandler(this.btnTestCrontabGen_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Data Comunicazione";
            // 
            // btnCrontabGen
            // 
            this.btnCrontabGen.Location = new System.Drawing.Point(11, 68);
            this.btnCrontabGen.Name = "btnCrontabGen";
            this.btnCrontabGen.Size = new System.Drawing.Size(124, 46);
            this.btnCrontabGen.TabIndex = 14;
            this.btnCrontabGen.Text = "Configura";
            this.btnCrontabGen.UseVisualStyleBackColor = true;
            this.btnCrontabGen.Click += new System.EventHandler(this.genCrontab_Click);
            // 
            // txtStopdate
            // 
            this.txtStopdate.Location = new System.Drawing.Point(141, 38);
            this.txtStopdate.Name = "txtStopdate";
            this.txtStopdate.Size = new System.Drawing.Size(122, 20);
            this.txtStopdate.TabIndex = 13;
            this.txtStopdate.Tag = "advice.stopdate";
            // 
            // lblCrontab
            // 
            this.lblCrontab.AutoSize = true;
            this.lblCrontab.Location = new System.Drawing.Point(45, 135);
            this.lblCrontab.Name = "lblCrontab";
            this.lblCrontab.Size = new System.Drawing.Size(90, 13);
            this.lblCrontab.TabIndex = 12;
            this.lblCrontab.Text = "Codifica (crontab)";
            // 
            // lblStopdate
            // 
            this.lblStopdate.AutoSize = true;
            this.lblStopdate.Location = new System.Drawing.Point(138, 22);
            this.lblStopdate.Name = "lblStopdate";
            this.lblStopdate.Size = new System.Drawing.Size(53, 13);
            this.lblStopdate.TabIndex = 11;
            this.lblStopdate.Text = "Data Fine";
            // 
            // txtCrontab
            // 
            this.txtCrontab.Location = new System.Drawing.Point(141, 132);
            this.txtCrontab.Name = "txtCrontab";
            this.txtCrontab.ReadOnly = true;
            this.txtCrontab.Size = new System.Drawing.Size(122, 20);
            this.txtCrontab.TabIndex = 10;
            this.txtCrontab.Tag = "advice.crontab";
            this.txtCrontab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAdvice
            // 
            this.txtAdvice.AcceptsReturn = true;
            this.txtAdvice.AcceptsTab = true;
            this.txtAdvice.BackColor = System.Drawing.SystemColors.Window;
            this.txtAdvice.Font = new System.Drawing.Font("Arial", 9.75F);
            this.txtAdvice.Location = new System.Drawing.Point(8, 367);
            this.txtAdvice.Multiline = true;
            this.txtAdvice.Name = "txtAdvice";
            this.txtAdvice.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAdvice.Size = new System.Drawing.Size(652, 117);
            this.txtAdvice.TabIndex = 5;
            this.txtAdvice.Tag = "advice.description";
            // 
            // dgrComunicazioni
            // 
            this.dgrComunicazioni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrComunicazioni.DataMember = "";
            this.dgrComunicazioni.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrComunicazioni.Location = new System.Drawing.Point(8, 8);
            this.dgrComunicazioni.Name = "dgrComunicazioni";
            this.dgrComunicazioni.Size = new System.Drawing.Size(652, 165);
            this.dgrComunicazioni.TabIndex = 1;
            this.dgrComunicazioni.Tag = "advice.default";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(8, 240);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(318, 107);
            this.textBox1.TabIndex = 4;
            this.textBox1.Tag = "advice.title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Titolo";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 183);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Comunicazione";
            // 
            // txtAlertCode
            // 
            this.txtAlertCode.BackColor = System.Drawing.SystemColors.Window;
            this.txtAlertCode.Location = new System.Drawing.Point(8, 199);
            this.txtAlertCode.Name = "txtAlertCode";
            this.txtAlertCode.Size = new System.Drawing.Size(318, 20);
            this.txtAlertCode.TabIndex = 2;
            this.txtAlertCode.Tag = "advice.codeadvice";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 351);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Dettagli";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // FrmAldviceDefault
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(680, 554);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.MetaDataToolBar);
            this.Name = "FrmAldviceDefault";
            this.Text = "FrmAdviceDefault";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrComunicazioni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public vistaForm DS;
        private System.Windows.Forms.ImageList images;
        public System.Windows.Forms.ToolBar MetaDataToolBar;
        private System.Windows.Forms.ToolBarButton seleziona;
        private System.Windows.Forms.ToolBarButton impostaricerca;
        private System.Windows.Forms.ToolBarButton effettuaricerca;
        private System.Windows.Forms.ToolBarButton modifica;
        private System.Windows.Forms.ToolBarButton inserisci;
        private System.Windows.Forms.ToolBarButton inseriscicopia;
        private System.Windows.Forms.ToolBarButton elimina;
        private System.Windows.Forms.ToolBarButton Salva;
        private System.Windows.Forms.ToolBarButton aggiorna;
        public System.Windows.Forms.Panel MetaDataDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAlertCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGrid dgrComunicazioni;
        private System.Windows.Forms.TextBox txtAdvice;
        private System.Windows.Forms.Label lblCrontab;
        private System.Windows.Forms.Label lblStopdate;
        private System.Windows.Forms.TextBox txtCrontab;
        private System.Windows.Forms.TextBox txtStopdate;
        private System.Windows.Forms.Button btnCrontabGen;
        private System.Windows.Forms.Button btnTestCrontabGen;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
