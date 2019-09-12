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
using metadatalibrary;
using System.Data;
using funzioni_configurazione;

namespace creditpart_detail//assegnazionecreditidetail//
{
	/// <summary>
	/// Summary description for frmAssegnazioneCreditiDetail.
	/// </summary>
	public class Frm_creditpart_detail : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.GroupBox grpAssegnazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumAssegnazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtEsercAssegnazione;
		private System.Windows.Forms.GroupBox grpAccertamento;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtNumEntrata;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEsercEntrata;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		public /*Rana:assegnazionecreditidetail.*/vistaForm DS;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.GroupBox groupBox1;
        MetaData Meta;
		string filterupb;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
        object idunderwriting = DBNull.Value;

		public Frm_creditpart_detail()
		{
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_creditpart_detail));
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpAssegnazione = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumAssegnazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercAssegnazione = new System.Windows.Forms.TextBox();
            this.grpAccertamento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumEntrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercEntrata = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.DS = new creditpart_detail.vistaForm();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.grpBilancio.SuspendLayout();
            this.grpAssegnazione.SuspendLayout();
            this.grpAccertamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(200, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 16);
            this.label7.TabIndex = 85;
            this.label7.Text = "Data contabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(304, 96);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(104, 20);
            this.txtDataContabile.TabIndex = 6;
            this.txtDataContabile.Tag = "creditpart.adate?creditpartview.adate";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 83;
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(96, 96);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 5;
            this.txtImporto.Tag = "creditpart.amount?creditpartview.amount";
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(96, 24);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(312, 64);
            this.txtDescrizione.TabIndex = 4;
            this.txtDescrizione.Tag = "creditpart.description?creditpartview.description";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 80;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpBilancio
            // 
            this.grpBilancio.Controls.Add(this.txtDescrBilancio);
            this.grpBilancio.Controls.Add(this.txtBilancio);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(4, 201);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(416, 120);
            this.grpBilancio.TabIndex = 3;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtBilancio.treesupb";
            this.grpBilancio.Text = "Bilancio";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(136, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(272, 72);
            this.txtDescrBilancio.TabIndex = 54;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(15, 94);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(395, 20);
            this.txtBilancio.TabIndex = 52;
            this.txtBilancio.Tag = "finview.codefin?creditpartview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(14, 64);
            this.btnBilancio.Name = "btnBilancio";
            this.btnBilancio.Size = new System.Drawing.Size(104, 24);
            this.btnBilancio.TabIndex = 62;
            this.btnBilancio.TabStop = false;
            this.btnBilancio.Tag = "";
            this.btnBilancio.Text = "Bilancio:";
            this.btnBilancio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBilancio.Click += new System.EventHandler(this.btnBilancio_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // grpAssegnazione
            // 
            this.grpAssegnazione.Controls.Add(this.label1);
            this.grpAssegnazione.Controls.Add(this.txtNumAssegnazione);
            this.grpAssegnazione.Controls.Add(this.label2);
            this.grpAssegnazione.Controls.Add(this.txtEsercAssegnazione);
            this.grpAssegnazione.Location = new System.Drawing.Point(229, 4);
            this.grpAssegnazione.Name = "grpAssegnazione";
            this.grpAssegnazione.Size = new System.Drawing.Size(184, 72);
            this.grpAssegnazione.TabIndex = 2;
            this.grpAssegnazione.TabStop = false;
            this.grpAssegnazione.Text = "Assegnazione";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumAssegnazione
            // 
            this.txtNumAssegnazione.Location = new System.Drawing.Point(80, 48);
            this.txtNumAssegnazione.Name = "txtNumAssegnazione";
            this.txtNumAssegnazione.Size = new System.Drawing.Size(96, 20);
            this.txtNumAssegnazione.TabIndex = 10;
            this.txtNumAssegnazione.TabStop = false;
            this.txtNumAssegnazione.Tag = "creditpart.ncreditpart?creditpartview.ncreditpart";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercAssegnazione
            // 
            this.txtEsercAssegnazione.Location = new System.Drawing.Point(80, 16);
            this.txtEsercAssegnazione.Name = "txtEsercAssegnazione";
            this.txtEsercAssegnazione.ReadOnly = true;
            this.txtEsercAssegnazione.Size = new System.Drawing.Size(56, 20);
            this.txtEsercAssegnazione.TabIndex = 8;
            this.txtEsercAssegnazione.TabStop = false;
            this.txtEsercAssegnazione.Tag = "creditpart.ycreditpart?creditpartview.ycreditpart";
            // 
            // grpAccertamento
            // 
            this.grpAccertamento.Controls.Add(this.label3);
            this.grpAccertamento.Controls.Add(this.txtNumEntrata);
            this.grpAccertamento.Controls.Add(this.label4);
            this.grpAccertamento.Controls.Add(this.txtEsercEntrata);
            this.grpAccertamento.Location = new System.Drawing.Point(8, 8);
            this.grpAccertamento.Name = "grpAccertamento";
            this.grpAccertamento.Size = new System.Drawing.Size(176, 72);
            this.grpAccertamento.TabIndex = 1;
            this.grpAccertamento.TabStop = false;
            this.grpAccertamento.Tag = "";
            this.grpAccertamento.Text = "Movimento di entrata";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumEntrata
            // 
            this.txtNumEntrata.Location = new System.Drawing.Point(72, 48);
            this.txtNumEntrata.Name = "txtNumEntrata";
            this.txtNumEntrata.ReadOnly = true;
            this.txtNumEntrata.Size = new System.Drawing.Size(96, 20);
            this.txtNumEntrata.TabIndex = 6;
            this.txtNumEntrata.TabStop = false;
            this.txtNumEntrata.Tag = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercEntrata
            // 
            this.txtEsercEntrata.Location = new System.Drawing.Point(72, 16);
            this.txtEsercEntrata.Name = "txtEsercEntrata";
            this.txtEsercEntrata.ReadOnly = true;
            this.txtEsercEntrata.Size = new System.Drawing.Size(56, 20);
            this.txtEsercEntrata.TabIndex = 4;
            this.txtEsercEntrata.TabStop = false;
            this.txtEsercEntrata.Tag = "";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Annulla";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(140, 479);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 7;
            this.btnOk.Tag = "mainsave";
            this.btnOk.Text = "Ok";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtDataContabile);
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(4, 327);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 128);
            this.groupBox1.TabIndex = 86;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Contabili";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 86);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(405, 109);
            this.gboxUPB.TabIndex = 87;
            this.gboxUPB.TabStop = false;
            this.gboxUPB.Tag = "AutoChoose.txtUPB.default.(active=\'S\')";
            // 
            // txtUPB
            // 
            this.txtUPB.Location = new System.Drawing.Point(10, 81);
            this.txtUPB.Name = "txtUPB";
            this.txtUPB.Size = new System.Drawing.Size(384, 20);
            this.txtUPB.TabIndex = 6;
            this.txtUPB.Tag = "upb.codeupb?x";
            // 
            // txtDescrUPB
            // 
            this.txtDescrUPB.Location = new System.Drawing.Point(145, 8);
            this.txtDescrUPB.Multiline = true;
            this.txtDescrUPB.Name = "txtDescrUPB";
            this.txtDescrUPB.ReadOnly = true;
            this.txtDescrUPB.Size = new System.Drawing.Size(251, 66);
            this.txtDescrUPB.TabIndex = 4;
            this.txtDescrUPB.TabStop = false;
            this.txtDescrUPB.Tag = "upb.title";
            // 
            // btnUPBCode
            // 
            this.btnUPBCode.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPBCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPBCode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnUPBCode.Location = new System.Drawing.Point(10, 57);
            this.btnUPBCode.Name = "btnUPBCode";
            this.btnUPBCode.Size = new System.Drawing.Size(112, 20);
            this.btnUPBCode.TabIndex = 2;
            this.btnUPBCode.TabStop = false;
            this.btnUPBCode.Tag = "";
            this.btnUPBCode.Text = "UPB:";
            this.btnUPBCode.UseVisualStyleBackColor = false;
            this.btnUPBCode.Click += new System.EventHandler(this.btnUpb_Click);
            // 
            // Frm_creditpart_detail
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(448, 523);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpBilancio);
            this.Controls.Add(this.grpAssegnazione);
            this.Controls.Add(this.grpAccertamento);
            this.Name = "Frm_creditpart_detail";
            this.Text = "frmAssegnazioneCreditiDetail";
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
            this.grpAssegnazione.ResumeLayout(false);
            this.grpAssegnazione.PerformLayout();
            this.grpAccertamento.ResumeLayout(false);
            this.grpAccertamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gboxUPB.ResumeLayout(false);
            this.gboxUPB.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

			string nomeTabella = "";
			if (Meta.edit_type == "detail") {
				nomeTabella = "incomeyear";
			}
			if (Meta.edit_type == "variazione") {
				nomeTabella = "incomeview";
			}
			DataRow Padre = Meta.SourceRow.Table.DataSet.Tables[nomeTabella].Rows[0];

			filterupb = QHS.CmpEq("idupb", Padre["idupb"]);
			string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            string f = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'), filterupb);
			GetData.SetStaticFilter(DS.finview, f);

            DataRow ParentIncome;
			if (Meta.edit_type == "detail") {
				nomeTabella = "income";
			}
            if (Meta.edit_type == "variazione") {
                nomeTabella = "incomeview";
            }
            
            ParentIncome = Meta.SourceRow.Table.DataSet.Tables[nomeTabella].Rows[0];
            idunderwriting = ParentIncome["idunderwriting"];

		}

		public void MetaData_AfterFill() {
			if (!Meta.FirstFillForThisRow) return;
			string esercMov = "";
			string numMov = "";
			string descrFase = "";
			if (Meta.edit_type == "detail") {
				DataRow R = Meta.SourceRow.GetParentRow("incomecreditpart");
				esercMov = R["ymov"].ToString();
				if (R.RowState==DataRowState.Added) {
					numMov = "";
				}
				else {
					numMov = R["nmov"].ToString();
				}
				object faseObj = Meta.Conn.DO_READ_VALUE("incomephase", QHS.CmpEq("nphase", Meta.GetSys("incomefinphase")),"description");
				if (faseObj != null) descrFase = faseObj.ToString();

//				DataRow fase = R.GetParentRow("incomephaseincome");
//				if (fase!=null) descrFase = fase["description"].ToString();
			}
			if (Meta.edit_type == "variazione"){
				if (DS.creditpart.Rows.Count == 0) return;
				DataRow Curr = DS.creditpart.Rows[0];
				string filterMov = QHS.CmpEq("idinc", Curr["idinc"]);
				DataTable movTable = DataAccess.RUN_SELECT(Meta.Conn, "income", "ymov,nmov,nphase", null,filterMov, null, null, true);
				if (movTable == null) return;
				esercMov = movTable.Rows[0]["ymov"].ToString();
				numMov = movTable.Rows[0]["nmov"].ToString();
				object faseObj = Meta.Conn.DO_READ_VALUE("incomephase",
					QHS.CmpEq("nphase", movTable.Rows[0]["nphase"]),"description");
				if (faseObj != null) descrFase = faseObj.ToString();
			}
			txtEsercEntrata.Text = esercMov;
			txtNumEntrata.Text = numMov;
			if (descrFase != "") grpAccertamento.Text = descrFase;
		}

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string filteridfin = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("finpart", 'S'));
	
			//Il filtro sull'UPB c'è sempre
            filter = QHS.AppAnd(filteridfin, filterupb);
			DS.finview.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.finview.treesupb");
		}

        private void btnUpb_Click(object sender, EventArgs e) {
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            if (idunderwriting == DBNull.Value) {
                //era manage.upb.tree
                //Meta.DoMainCommand("manage.upb.tree");
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(filteresercizio,QHS.CmpGt("expenseprevavailable", QHS.Field("creditavailable")),
                                            QHS.CmpEq("finpart", "S"));
                MetaData MetaUY = MetaData.GetMetaData(this, "upbfinyearview");
                MetaUY.DS = new DataSet();
                MetaUY.LinkedForm = this;
                MetaUY.FilterLocked = true;
                DataRow Und = MetaUY.SelectOne("crediti", filter, "upbfinyearview", null);
                if (Und == null) return;
                DataRow Curr = DS.creditpart.Rows[0];
                Curr["idupb"] = Und["idupb"];
                Curr["idfin"] = Und["idfin"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(Und["expenseprevavailable"]) - CfgFn.GetNoNullDecimal(Und["creditavailable"]);
                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount = amount_needed > amount_assignable ? amount_assignable : amount_needed;
                Curr["amount"] = amount;

                Meta.FreshForm(true);

            }
            else {
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(filteresercizio,QHS.CmpGt("expenseprevavailable", QHS.Field("creditavailable")),
                                            QHS.CmpEq("finpart", "S"),
                                            QHS.CmpEq("idunderwriting",idunderwriting));
                MetaData MetaUnder = MetaData.GetMetaData(this, "upbunderwritingyearview");
                MetaUnder.DS = new DataSet();
                MetaUnder.LinkedForm = this;
                MetaUnder.FilterLocked = true;
                DataRow Und = MetaUnder.SelectOne("crediti", filter, "upbunderwritingyearview", null);
                if (Und == null) return;
                DataRow Curr = DS.creditpart.Rows[0];
                Curr["idupb"] = Und["idupb"];
                Curr["idfin"] = Und["idfin"];
                decimal amount_needed = CfgFn.GetNoNullDecimal(Und["expenseprevavailable"]) - CfgFn.GetNoNullDecimal(Und["creditavailable"]);
                decimal amount_assignable = GetAssignableAmount();
                //sceglie il minimo tra i due
                decimal amount= amount_needed>amount_assignable? amount_assignable:amount_needed;
                Curr["amount"]=amount;

                Meta.FreshForm(true);

            }


        }

        decimal GetAssignableAmount() {
            DataTable SourceTable = Meta.SourceRow.Table;

            decimal default_amount = CfgFn.GetNoNullDecimal(SourceTable.Columns["amount"].DefaultValue);
            if (Meta.InsertMode) return default_amount;
            decimal original_amount = CfgFn.GetNoNullDecimal(DS.creditpart.Rows[0]["amount", DataRowVersion.Original]);
            return default_amount + original_amount;
        }

       
	}
}
