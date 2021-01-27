
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


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace csa_contractkindrules_search {
	/// <summary>
	/// </summary>
    public class Frm_csa_contractkindrules_search : System.Windows.Forms.Form
    {
        public vistaForm DS;
        MetaData Meta;
        DataAccess Conn;
        private GroupBox MetaDataDetail;
        private ComboBox cmbTipoContratto;
        private GroupBox gboxtipo;
        private RadioButton rdbCompetenza;
        private RadioButton rdbResidui;
        private CheckBox ckbAttivo;
        private TextBox textBox3;
        private Label label4;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label1;
        private TextBox tipo;
        private Label label2;
        private TextBox txtEsercDoc;
        private Label labEsercizio;
        //private IContainer components;

		public Frm_csa_contractkindrules_search() {
			InitializeComponent();
       		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.ckbAttivo = new System.Windows.Forms.CheckBox();
			this.gboxtipo = new System.Windows.Forms.GroupBox();
			this.rdbCompetenza = new System.Windows.Forms.RadioButton();
			this.rdbResidui = new System.Windows.Forms.RadioButton();
			this.cmbTipoContratto = new System.Windows.Forms.ComboBox();
			this.DS = new csa_contractkindrules_search.vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tipo = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtEsercDoc = new System.Windows.Forms.TextBox();
			this.labEsercizio = new System.Windows.Forms.Label();
			this.MetaDataDetail.SuspendLayout();
			this.gboxtipo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Controls.Add(this.textBox3);
			this.MetaDataDetail.Controls.Add(this.label4);
			this.MetaDataDetail.Controls.Add(this.ckbAttivo);
			this.MetaDataDetail.Controls.Add(this.gboxtipo);
			this.MetaDataDetail.Controls.Add(this.cmbTipoContratto);
			this.MetaDataDetail.Location = new System.Drawing.Point(12, 12);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(540, 94);
			this.MetaDataDetail.TabIndex = 1;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Tag = "";
			this.MetaDataDetail.Text = "Regola generale CSA";
			// 
			// textBox3
			// 
			this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox3.Location = new System.Drawing.Point(11, 64);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(189, 20);
			this.textBox3.TabIndex = 2;
			this.textBox3.Tag = "csa_contractkind.contractkindcode?csa_contractkindrulesview.contractkindcode";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(11, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 29;
			this.label4.Text = "Codice:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// ckbAttivo
			// 
			this.ckbAttivo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.ckbAttivo.Location = new System.Drawing.Point(416, 72);
			this.ckbAttivo.Name = "ckbAttivo";
			this.ckbAttivo.Size = new System.Drawing.Size(80, 16);
			this.ckbAttivo.TabIndex = 28;
			this.ckbAttivo.Tag = "csa_contractkind.active:S:N?csa_contractkindrulesview.active:S:N";
			this.ckbAttivo.Text = "Attivo";
			// 
			// gboxtipo
			// 
			this.gboxtipo.Controls.Add(this.rdbCompetenza);
			this.gboxtipo.Controls.Add(this.rdbResidui);
			this.gboxtipo.Location = new System.Drawing.Point(398, 10);
			this.gboxtipo.Name = "gboxtipo";
			this.gboxtipo.Size = new System.Drawing.Size(135, 56);
			this.gboxtipo.TabIndex = 27;
			this.gboxtipo.TabStop = false;
			this.gboxtipo.Text = "Tipo";
			// 
			// rdbCompetenza
			// 
			this.rdbCompetenza.Location = new System.Drawing.Point(18, 13);
			this.rdbCompetenza.Name = "rdbCompetenza";
			this.rdbCompetenza.Size = new System.Drawing.Size(96, 16);
			this.rdbCompetenza.TabIndex = 1;
			this.rdbCompetenza.Tag = "csa_contractkind.flagcr:C?csa_contractkindrulesview.flagcr:C";
			this.rdbCompetenza.Text = "Competenza";
			// 
			// rdbResidui
			// 
			this.rdbResidui.Location = new System.Drawing.Point(18, 35);
			this.rdbResidui.Name = "rdbResidui";
			this.rdbResidui.Size = new System.Drawing.Size(96, 16);
			this.rdbResidui.TabIndex = 1;
			this.rdbResidui.Tag = "csa_contractkind.flagcr:R?csa_contractkindrulesview.flagcr:R";
			this.rdbResidui.Text = "Residui";
			// 
			// cmbTipoContratto
			// 
			this.cmbTipoContratto.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.cmbTipoContratto.DataSource = this.DS.csa_contractkind;
			this.cmbTipoContratto.DisplayMember = "description";
			this.cmbTipoContratto.Location = new System.Drawing.Point(11, 19);
			this.cmbTipoContratto.Name = "cmbTipoContratto";
			this.cmbTipoContratto.Size = new System.Drawing.Size(356, 21);
			this.cmbTipoContratto.TabIndex = 1;
			this.cmbTipoContratto.Tag = "csa_contractkindrules.idcsa_contractkind?csa_contractkindrulesview.idcsa_contract" +
    "kind";
			this.cmbTipoContratto.ValueMember = "idcsa_contractkind";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.textBox2);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.tipo);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtEsercDoc);
			this.groupBox1.Controls.Add(this.labEsercizio);
			this.groupBox1.Location = new System.Drawing.Point(12, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(540, 194);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Regola";
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(8, 21);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 16);
			this.label3.TabIndex = 3;
			this.label3.Text = "#";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBox2
			// 
			this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox2.Location = new System.Drawing.Point(11, 40);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(80, 20);
			this.textBox2.TabIndex = 1;
			this.textBox2.Tag = "csa_contractkindrules.idcsa_rule?csa_contractkindrulesview.idcsa_rule";
			// 
			// textBox1
			// 
			this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.textBox1.Location = new System.Drawing.Point(11, 144);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(501, 20);
			this.textBox1.TabIndex = 44;
			this.textBox1.Tag = "csa_contractkindrules.ruolocsa?csa_contractkindrulesview.ruolocsa";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 123);
			this.label1.Name = "label1";
			this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label1.Size = new System.Drawing.Size(96, 18);
			this.label1.TabIndex = 6;
			this.label1.Text = "Ruolo CSA:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tipo
			// 
			this.tipo.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.tipo.Location = new System.Drawing.Point(11, 93);
			this.tipo.Name = "tipo";
			this.tipo.Size = new System.Drawing.Size(501, 20);
			this.tipo.TabIndex = 2;
			this.tipo.Tag = "csa_contractkindrules.capitolocsa?csa_contractkindrulesview.capitolocsa";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(10, 72);
			this.label2.Name = "label2";
			this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.label2.Size = new System.Drawing.Size(122, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "Capitolo CSA:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEsercDoc
			// 
			this.txtEsercDoc.Anchor = System.Windows.Forms.AnchorStyles.Right;
			this.txtEsercDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtEsercDoc.Location = new System.Drawing.Point(432, 40);
			this.txtEsercDoc.Name = "txtEsercDoc";
			this.txtEsercDoc.Size = new System.Drawing.Size(80, 20);
			this.txtEsercDoc.TabIndex = 40;
			this.txtEsercDoc.Tag = "csa_contractkindrules.ayear?csa_contractkindrulesview.ayear";
			// 
			// labEsercizio
			// 
			this.labEsercizio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labEsercizio.Location = new System.Drawing.Point(429, 21);
			this.labEsercizio.Name = "labEsercizio";
			this.labEsercizio.Size = new System.Drawing.Size(55, 16);
			this.labEsercizio.TabIndex = 4;
			this.labEsercizio.Text = "Esercizio";
			this.labEsercizio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// Frm_csa_contractkindrules_search
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(570, 323);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.MetaDataDetail);
			this.Name = "Frm_csa_contractkindrules_search";
			this.Text = "frmContractKindRules";
			this.MetaDataDetail.ResumeLayout(false);
			this.MetaDataDetail.PerformLayout();
			this.gboxtipo.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}
		#endregion
        
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
		
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            string filter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.SetStaticFilter(DS.csa_contractkindrulesview, filter);
            GetData.SetStaticFilter(DS.csa_contractkindrules, filter);
            GetData.SetStaticFilter(DS.csa_contractkindyear, filter);
            //Meta.CanInsert = false;
            //Meta.CanInsertCopy = false;
            //Meta.CanCancel = false;
         }
       
    }
}
