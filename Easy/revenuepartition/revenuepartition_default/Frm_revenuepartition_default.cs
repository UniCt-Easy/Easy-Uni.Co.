
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using System.Data;

namespace revenuepartition_default
{
	/// <summary>
	/// Summary description for Frm_revenuepartition_default.
	/// </summary>
	public class Frm_revenuepartition_default : MetaDataForm
	{
		MetaData Meta;
		public revenuepartition_default.vistaForm DS;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtDenominazione;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button btnElimina;
		private System.Windows.Forms.Button btnModifica;
        private System.Windows.Forms.Button btnInserisci;
        private GroupBox gboxTipo;
        private RadioButton rdbPercentuali;
        private RadioButton rdbrevenuei;
        private TabControl tabControl1;
        private TabPage tabDettagli;
        private TabPage tabAnnotazioni;
        private TextBox txtDescrizione;
        private CheckBox checkBox1;
        private TextBox txtCodice;
        private Label label5;
        private Button btnImporta;
        private Button btnSvuota;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_revenuepartition_default()
		{
			InitializeComponent();
			
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtCodice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDenominazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGrid1 = new System.Windows.Forms.DataGrid();
            this.btnElimina = new System.Windows.Forms.Button();
            this.btnModifica = new System.Windows.Forms.Button();
            this.btnInserisci = new System.Windows.Forms.Button();
            this.gboxTipo = new System.Windows.Forms.GroupBox();
            this.rdbPercentuali = new System.Windows.Forms.RadioButton();
            this.rdbrevenuei = new System.Windows.Forms.RadioButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDettagli = new System.Windows.Forms.TabPage();
            this.btnSvuota = new System.Windows.Forms.Button();
            this.tabAnnotazioni = new System.Windows.Forms.TabPage();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.DS = new revenuepartition_default.vistaForm();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnImporta = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
            this.gboxTipo.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDettagli.SuspendLayout();
            this.tabAnnotazioni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtCodice);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(13, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(302, 45);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ripartizione";
            // 
            // txtCodice
            // 
            this.txtCodice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodice.Location = new System.Drawing.Point(69, 19);
            this.txtCodice.Name = "txtCodice";
            this.txtCodice.Size = new System.Drawing.Size(211, 20);
            this.txtCodice.TabIndex = 36;
            this.txtCodice.Tag = "revenuepartition.revenuepartitioncode";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(18, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Codice:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDenominazione
            // 
            this.txtDenominazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDenominazione.Location = new System.Drawing.Point(13, 81);
            this.txtDenominazione.Multiline = true;
            this.txtDenominazione.Name = "txtDenominazione";
            this.txtDenominazione.Size = new System.Drawing.Size(523, 64);
            this.txtDenominazione.TabIndex = 4;
            this.txtDenominazione.Tag = "revenuepartition.title";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 29;
            this.label2.Text = "Denominazione:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGrid1
            // 
            this.dataGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid1.DataMember = "";
            this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid1.Location = new System.Drawing.Point(84, 14);
            this.dataGrid1.Name = "dataGrid1";
            this.dataGrid1.Size = new System.Drawing.Size(612, 250);
            this.dataGrid1.TabIndex = 34;
            this.dataGrid1.Tag = "revenuepartitiondetail.default.single";
            // 
            // btnElimina
            // 
            this.btnElimina.Location = new System.Drawing.Point(6, 87);
            this.btnElimina.Name = "btnElimina";
            this.btnElimina.Size = new System.Drawing.Size(72, 24);
            this.btnElimina.TabIndex = 33;
            this.btnElimina.Tag = "delete";
            this.btnElimina.Text = "Elimina";
            // 
            // btnModifica
            // 
            this.btnModifica.Location = new System.Drawing.Point(6, 55);
            this.btnModifica.Name = "btnModifica";
            this.btnModifica.Size = new System.Drawing.Size(72, 24);
            this.btnModifica.TabIndex = 32;
            this.btnModifica.Tag = "edit.single";
            this.btnModifica.Text = "Modifica";
            // 
            // btnInserisci
            // 
            this.btnInserisci.Location = new System.Drawing.Point(6, 23);
            this.btnInserisci.Name = "btnInserisci";
            this.btnInserisci.Size = new System.Drawing.Size(72, 24);
            this.btnInserisci.TabIndex = 31;
            this.btnInserisci.Tag = "insert.single";
            this.btnInserisci.Text = "Inserisci";
            // 
            // gboxTipo
            // 
            this.gboxTipo.Controls.Add(this.rdbPercentuali);
            this.gboxTipo.Controls.Add(this.rdbrevenuei);
            this.gboxTipo.Location = new System.Drawing.Point(337, 12);
            this.gboxTipo.Name = "gboxTipo";
            this.gboxTipo.Size = new System.Drawing.Size(191, 45);
            this.gboxTipo.TabIndex = 2;
            this.gboxTipo.TabStop = false;
            this.gboxTipo.Text = "Tipo Ripartizione";
            // 
            // rdbPercentuali
            // 
            this.rdbPercentuali.AutoSize = true;
            this.rdbPercentuali.Location = new System.Drawing.Point(103, 15);
            this.rdbPercentuali.Name = "rdbPercentuali";
            this.rdbPercentuali.Size = new System.Drawing.Size(78, 17);
            this.rdbPercentuali.TabIndex = 4;
            this.rdbPercentuali.Tag = "revenuepartition.kind:P";
            this.rdbPercentuali.Text = "Percentuali";
            this.rdbPercentuali.UseVisualStyleBackColor = true;
            // 
            // rdbrevenuei
            // 
            this.rdbrevenuei.Location = new System.Drawing.Point(26, 16);
            this.rdbrevenuei.Name = "rdbrevenuei";
            this.rdbrevenuei.Size = new System.Drawing.Size(71, 16);
            this.rdbrevenuei.TabIndex = 0;
            this.rdbrevenuei.Tag = "revenuepartition.kind:C";
            this.rdbrevenuei.Text = "Ricavi";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDettagli);
            this.tabControl1.Controls.Add(this.tabAnnotazioni);
            this.tabControl1.Location = new System.Drawing.Point(13, 167);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(710, 296);
            this.tabControl1.TabIndex = 8;
            // 
            // tabDettagli
            // 
            this.tabDettagli.Controls.Add(this.btnSvuota);
            this.tabDettagli.Controls.Add(this.btnInserisci);
            this.tabDettagli.Controls.Add(this.btnModifica);
            this.tabDettagli.Controls.Add(this.btnElimina);
            this.tabDettagli.Controls.Add(this.dataGrid1);
            this.tabDettagli.Location = new System.Drawing.Point(4, 22);
            this.tabDettagli.Name = "tabDettagli";
            this.tabDettagli.Padding = new System.Windows.Forms.Padding(3);
            this.tabDettagli.Size = new System.Drawing.Size(702, 270);
            this.tabDettagli.TabIndex = 0;
            this.tabDettagli.Text = "Dettagli";
            this.tabDettagli.UseVisualStyleBackColor = true;
            // 
            // btnSvuota
            // 
            this.btnSvuota.Location = new System.Drawing.Point(6, 207);
            this.btnSvuota.Name = "btnSvuota";
            this.btnSvuota.Size = new System.Drawing.Size(75, 23);
            this.btnSvuota.TabIndex = 347;
            this.btnSvuota.Text = "Svuota";
            this.btnSvuota.UseVisualStyleBackColor = true;
            this.btnSvuota.Click += new System.EventHandler(this.btnSvuota_Click);
            // 
            // tabAnnotazioni
            // 
            this.tabAnnotazioni.Controls.Add(this.txtDescrizione);
            this.tabAnnotazioni.Location = new System.Drawing.Point(4, 22);
            this.tabAnnotazioni.Name = "tabAnnotazioni";
            this.tabAnnotazioni.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnnotazioni.Size = new System.Drawing.Size(702, 270);
            this.tabAnnotazioni.TabIndex = 1;
            this.tabAnnotazioni.Text = "Descrizione";
            this.tabAnnotazioni.UseVisualStyleBackColor = true;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(7, 6);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(689, 258);
            this.txtDescrizione.TabIndex = 53;
            this.txtDescrizione.Tag = "revenuepartition.description";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBox1.Location = new System.Drawing.Point(666, 128);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(53, 17);
            this.checkBox1.TabIndex = 345;
            this.checkBox1.TabStop = false;
            this.checkBox1.Tag = "revenuepartition.active:S:N";
            this.checkBox1.Text = "Attiva";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnImporta
            // 
            this.btnImporta.Location = new System.Drawing.Point(638, 21);
            this.btnImporta.Name = "btnImporta";
            this.btnImporta.Size = new System.Drawing.Size(75, 23);
            this.btnImporta.TabIndex = 346;
            this.btnImporta.Text = "Importa";
            this.btnImporta.UseVisualStyleBackColor = true;
            this.btnImporta.Click += new System.EventHandler(this.btnImporta_Click);
            // 
            // Frm_revenuepartition_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(735, 475);
            this.Controls.Add(this.btnImporta);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.gboxTipo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.txtDenominazione);
            this.Controls.Add(this.label2);
            this.Name = "Frm_revenuepartition_default";
            this.Text = "Frm_revenuepartition_default";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
            this.gboxTipo.ResumeLayout(false);
            this.gboxTipo.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDettagli.ResumeLayout(false);
            this.tabAnnotazioni.ResumeLayout(false);
            this.tabAnnotazioni.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public void  MetaData_AfterClear(){
            btnImporta.Visible = false;
            btnSvuota.Visible = false;
            gboxTipo.Enabled = true;
		}

        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
		public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
		}

        public void MetaData_AfterFill() {
            btnImporta.Visible = Meta.EditMode;
            btnSvuota.Visible = Meta.EditMode && DS.revenuepartitiondetail.Select().Length>0;
            gboxTipo.Enabled = DS.revenuepartitiondetail.Select().Length == 0;
        }

        void Importa() {
            if (!Meta.GetFormData(true)) return;

            OpenFileDialog _op = new OpenFileDialog();
            IOpenFileDialog op = createOpenFileDialog(_op);
            DialogResult dr = op.ShowDialog();
            if (dr != DialogResult.OK) {
                return ;
            }

            string fileName = op.FileName;

            DataTable T = new DataTable();
            //Aggiungere a T le colonne del foglio excel
            T.Columns.Add(new DataColumn("quota", typeof(decimal)));
            T.Columns.Add(new DataColumn("codice1", typeof(string)));
            T.Columns.Add(new DataColumn("codice2", typeof(string)));
            T.Columns.Add(new DataColumn("codice3", typeof(string)));


            ExcelImport x = new ExcelImport();
            x.ImportTable(fileName, T);

            if (T.Rows.Count == 0) return ;

           
            MetaData metarevenueDetail = Meta.Dispatcher.Get("revenuepartitiondetail");
            metarevenueDetail.SetDefaults(DS.revenuepartitiondetail);
            QueryHelper QHS = Meta.Conn.GetQueryHelper();

            //DataTable cfg = Meta.Conn.RUN_SELECT("config", "ayear,idsor1,idsor2,idsor3", null, QHS.CmpEq("ayear", Meta.GetSys("esercizio")), null, false);
            object idsorkind1 = Meta.GetSys("idsortingkind1");
            object idsorkind2 = Meta.GetSys("idsortingkind2");
            object idsorkind3 = Meta.GetSys("idsortingkind3");


            //bool usePerc = true;
            string fieldToUse = "rate";
            if (rdbrevenuei.Checked) {
                //usePerc = false;
                fieldToUse = "amount";               
            }

            DataRow main = DS.revenuepartition.Rows[0];

            foreach (DataRow r in T.Select()) {
                DataRow det = metarevenueDetail.Get_New_Row(main, DS.revenuepartitiondetail);
                det[fieldToUse] = r["quota"];
                object code1 = r["codice1"];
                object code2 = r["codice2"];
                object code3 = r["codice3"];

                object idsor1 = DBNull.Value;
                object idsor2 = DBNull.Value;
                object idsor3 = DBNull.Value;

                if (idsorkind1 != DBNull.Value && code1.ToString() != "") {
                    idsor1 = Meta.Conn.DO_READ_VALUE("sorting", QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind1), QHS.CmpEq("sortcode", code1.ToString().Trim())), "idsor");
                    if (idsor1 == null) {
                        idsor1 = DBNull.Value;
                        show("Codice " + code1 + " non trovato per coordinata analitica " + Meta.GetSys("titlesortingkind1"), "Errore");
                    }
                }
                if (idsorkind2 != DBNull.Value && code2.ToString() != "") {
                    idsor2 = Meta.Conn.DO_READ_VALUE("sorting", QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind2), QHS.CmpEq("sortcode", code2.ToString().Trim())), "idsor");
                    if (idsor2 == null) {
                        idsor2 = DBNull.Value;
                        show("Codice " + code2 + " non trovato per coordinata analitica " + Meta.GetSys("titlesortingkind2"), "Errore");
                    }
                }
                if (idsorkind3 != DBNull.Value && code3.ToString() != "") {
                    idsor3 = Meta.Conn.DO_READ_VALUE("sorting", QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkind3), QHS.CmpEq("sortcode", code3.ToString().Trim())), "idsor");
                    if (idsor3 == null) {
                        idsor3 = DBNull.Value;
                        show("Codice " + code3 + " non trovato per coordinata analitica " + Meta.GetSys("titlesortingkind3"), "Errore");
                    }
                }
                det["idsor1"] = idsor1;
                det["idsor2"] = idsor2;
                det["idsor3"] = idsor3;
            }

            Meta.FreshForm(true);
        }

        void Svuota() {
            if (!Meta.GetFormData(true)) return;
            foreach (DataRow r in DS.revenuepartitiondetail.Select()) {
                r.Delete();
            }
            Meta.FreshForm(false);
        }

        private void btnSvuota_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty || DS.revenuepartitiondetail.Select().Length == 0) return;
            if (show(this, "Cancello tutti i dettagli della ripartizione?", "Conferma", MessageBoxButtons.OKCancel) != DialogResult.OK) return;
            Svuota();
        }

        private void btnImporta_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Importa();
        }
	}
}
