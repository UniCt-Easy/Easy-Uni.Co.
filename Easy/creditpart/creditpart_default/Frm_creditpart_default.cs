
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
using metaeasylibrary;
using funzioni_configurazione;//funzioni_configurazione

namespace creditpart_default//assegnazionecrediti//
{
	/// <summary>
	/// Summary description for frmassegnazionecrediti.
	/// Revised by Nino on 19/12/2002
	/// </summary>
	public class Frm_creditpart_default : MetaDataForm
	{
		private System.Windows.Forms.GroupBox grpAccertamento;
		private System.Windows.Forms.Button btnAccertamento;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public /*Rana:assegnazionecrediti.*/vistaForm DS;
		private System.Windows.Forms.TextBox txtEsercEntrata;
		private System.Windows.Forms.GroupBox grpAssegnazione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtNumAssegnazione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox grpBilancio;
		private System.Windows.Forms.TextBox txtDescrBilancio;
		private System.Windows.Forms.TextBox txtBilancio;
		private System.Windows.Forms.Button btnBilancio;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtImporto;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDataContabile;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.TextBox txtNumEntrata;
		private System.Windows.Forms.TextBox txtEsercAssegnazione;
		MetaData Meta;
		DataAccess Conn;
		string filteresercizio;
		private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private GroupBox gboxUPB;
        public TextBox txtUPB;
        private TextBox txtDescrUPB;
        private Button btnUPBCode;
		string command;

		public Frm_creditpart_default()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_creditpart_default));
            this.grpAccertamento = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumEntrata = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtEsercEntrata = new System.Windows.Forms.TextBox();
            this.btnAccertamento = new System.Windows.Forms.Button();
            this.DS = new creditpart_default.vistaForm();
            this.grpAssegnazione = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumAssegnazione = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEsercAssegnazione = new System.Windows.Forms.TextBox();
            this.grpBilancio = new System.Windows.Forms.GroupBox();
            this.txtDescrBilancio = new System.Windows.Forms.TextBox();
            this.txtBilancio = new System.Windows.Forms.TextBox();
            this.btnBilancio = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtImporto = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDataContabile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gboxUPB = new System.Windows.Forms.GroupBox();
            this.txtUPB = new System.Windows.Forms.TextBox();
            this.txtDescrUPB = new System.Windows.Forms.TextBox();
            this.btnUPBCode = new System.Windows.Forms.Button();
            this.grpAccertamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.grpAssegnazione.SuspendLayout();
            this.grpBilancio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gboxUPB.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpAccertamento
            // 
            this.grpAccertamento.Controls.Add(this.label3);
            this.grpAccertamento.Controls.Add(this.txtNumEntrata);
            this.grpAccertamento.Controls.Add(this.label4);
            this.grpAccertamento.Controls.Add(this.txtEsercEntrata);
            this.grpAccertamento.Controls.Add(this.btnAccertamento);
            this.grpAccertamento.Location = new System.Drawing.Point(8, 8);
            this.grpAccertamento.Name = "grpAccertamento";
            this.grpAccertamento.Size = new System.Drawing.Size(160, 104);
            this.grpAccertamento.TabIndex = 0;
            this.grpAccertamento.TabStop = false;
            this.grpAccertamento.Tag = "";
            this.grpAccertamento.Text = "???";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Numero:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNumEntrata
            // 
            this.txtNumEntrata.Location = new System.Drawing.Point(80, 72);
            this.txtNumEntrata.Name = "txtNumEntrata";
            this.txtNumEntrata.Size = new System.Drawing.Size(72, 20);
            this.txtNumEntrata.TabIndex = 2;
            this.txtNumEntrata.Tag = "incomeview.nmov?creditpartview.nmov";
            this.txtNumEntrata.Leave += new System.EventHandler(this.txtNumEntrata_Leave);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Esercizio:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercEntrata
            // 
            this.txtEsercEntrata.Location = new System.Drawing.Point(80, 48);
            this.txtEsercEntrata.Name = "txtEsercEntrata";
            this.txtEsercEntrata.Size = new System.Drawing.Size(72, 20);
            this.txtEsercEntrata.TabIndex = 1;
            this.txtEsercEntrata.Tag = "incomeview.ymov.year?creditpartview.ymov.year";
            this.txtEsercEntrata.Leave += new System.EventHandler(this.txtEsercEntrata_Leave);
            // 
            // btnAccertamento
            // 
            this.btnAccertamento.Location = new System.Drawing.Point(16, 16);
            this.btnAccertamento.Name = "btnAccertamento";
            this.btnAccertamento.Size = new System.Drawing.Size(120, 23);
            this.btnAccertamento.TabIndex = 0;
            this.btnAccertamento.TabStop = false;
            this.btnAccertamento.Tag = "";
            this.btnAccertamento.Text = "???";
            this.btnAccertamento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccertamento.Click += new System.EventHandler(this.btnAccertamento_Click);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // grpAssegnazione
            // 
            this.grpAssegnazione.Controls.Add(this.label1);
            this.grpAssegnazione.Controls.Add(this.txtNumAssegnazione);
            this.grpAssegnazione.Controls.Add(this.label2);
            this.grpAssegnazione.Controls.Add(this.txtEsercAssegnazione);
            this.grpAssegnazione.Location = new System.Drawing.Point(216, 8);
            this.grpAssegnazione.Name = "grpAssegnazione";
            this.grpAssegnazione.Size = new System.Drawing.Size(112, 104);
            this.grpAssegnazione.TabIndex = 1;
            this.grpAssegnazione.TabStop = false;
            this.grpAssegnazione.Text = "Assegnazione";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.TabIndex = 11;
            this.label1.Text = "Numero:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumAssegnazione
            // 
            this.txtNumAssegnazione.Location = new System.Drawing.Point(8, 72);
            this.txtNumAssegnazione.Name = "txtNumAssegnazione";
            this.txtNumAssegnazione.Size = new System.Drawing.Size(96, 20);
            this.txtNumAssegnazione.TabIndex = 1;
            this.txtNumAssegnazione.Tag = "creditpart.ncreditpart?creditpartview.ncreditpart";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Esercizio:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEsercAssegnazione
            // 
            this.txtEsercAssegnazione.Location = new System.Drawing.Point(8, 32);
            this.txtEsercAssegnazione.Name = "txtEsercAssegnazione";
            this.txtEsercAssegnazione.ReadOnly = true;
            this.txtEsercAssegnazione.Size = new System.Drawing.Size(56, 20);
            this.txtEsercAssegnazione.TabIndex = 8;
            this.txtEsercAssegnazione.TabStop = false;
            this.txtEsercAssegnazione.Tag = "creditpart.ycreditpart?creditpartview.ycreditpart";
            // 
            // grpBilancio
            // 
            this.grpBilancio.Controls.Add(this.txtDescrBilancio);
            this.grpBilancio.Controls.Add(this.txtBilancio);
            this.grpBilancio.Controls.Add(this.btnBilancio);
            this.grpBilancio.Location = new System.Drawing.Point(8, 233);
            this.grpBilancio.Name = "grpBilancio";
            this.grpBilancio.Size = new System.Drawing.Size(405, 113);
            this.grpBilancio.TabIndex = 3;
            this.grpBilancio.TabStop = false;
            this.grpBilancio.Tag = "AutoManage.txtBilancio.treesupb";
            this.grpBilancio.Text = "Bilancio";
            // 
            // txtDescrBilancio
            // 
            this.txtDescrBilancio.Location = new System.Drawing.Point(144, 16);
            this.txtDescrBilancio.Multiline = true;
            this.txtDescrBilancio.Name = "txtDescrBilancio";
            this.txtDescrBilancio.ReadOnly = true;
            this.txtDescrBilancio.Size = new System.Drawing.Size(252, 64);
            this.txtDescrBilancio.TabIndex = 54;
            this.txtDescrBilancio.TabStop = false;
            this.txtDescrBilancio.Tag = "finview.title";
            // 
            // txtBilancio
            // 
            this.txtBilancio.Location = new System.Drawing.Point(15, 87);
            this.txtBilancio.Name = "txtBilancio";
            this.txtBilancio.Size = new System.Drawing.Size(379, 20);
            this.txtBilancio.TabIndex = 1;
            this.txtBilancio.Tag = "finview.codefin?creditpartview.codefin";
            // 
            // btnBilancio
            // 
            this.btnBilancio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBilancio.ImageIndex = 0;
            this.btnBilancio.ImageList = this.imageList1;
            this.btnBilancio.Location = new System.Drawing.Point(16, 57);
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
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 71;
            this.label5.Text = "Descrizione:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(80, 15);
            this.txtDescrizione.Multiline = true;
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(314, 64);
            this.txtDescrizione.TabIndex = 1;
            this.txtDescrizione.Tag = "creditpart.description?creditpartview.description";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 74;
            this.label6.Text = "Importo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtImporto
            // 
            this.txtImporto.Location = new System.Drawing.Point(80, 87);
            this.txtImporto.Name = "txtImporto";
            this.txtImporto.Size = new System.Drawing.Size(96, 20);
            this.txtImporto.TabIndex = 2;
            this.txtImporto.Tag = "creditpart.amount?creditpartview.amount";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(224, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 76;
            this.label7.Text = "Data contabile:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataContabile
            // 
            this.txtDataContabile.Location = new System.Drawing.Point(311, 91);
            this.txtDataContabile.Name = "txtDataContabile";
            this.txtDataContabile.Size = new System.Drawing.Size(83, 20);
            this.txtDataContabile.TabIndex = 3;
            this.txtDataContabile.Tag = "creditpart.adate?creditpartview.adate";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDescrizione);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtImporto);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtDataContabile);
            this.groupBox1.Location = new System.Drawing.Point(8, 352);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(405, 125);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dati Contabili";
            // 
            // gboxUPB
            // 
            this.gboxUPB.Controls.Add(this.txtUPB);
            this.gboxUPB.Controls.Add(this.txtDescrUPB);
            this.gboxUPB.Controls.Add(this.btnUPBCode);
            this.gboxUPB.Location = new System.Drawing.Point(8, 118);
            this.gboxUPB.Name = "gboxUPB";
            this.gboxUPB.Size = new System.Drawing.Size(405, 109);
            this.gboxUPB.TabIndex = 2;
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
            // Frm_creditpart_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(426, 485);
            this.Controls.Add(this.gboxUPB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpBilancio);
            this.Controls.Add(this.grpAssegnazione);
            this.Controls.Add(this.grpAccertamento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_creditpart_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmassegnazionecrediti";
            this.grpAccertamento.ResumeLayout(false);
            this.grpAccertamento.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.grpAssegnazione.ResumeLayout(false);
            this.grpAssegnazione.PerformLayout();
            this.grpBilancio.ResumeLayout(false);
            this.grpBilancio.PerformLayout();
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
			Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

			filteresercizio=QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
			GetData.CacheTable(DS.incomephase);
			GetData.SetStaticFilter(DS.finview, QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S')));
			GetData.SetStaticFilter(DS.incomeview, filteresercizio);
			DS.incomeview.ExtendedProperties["sort_by"]="ymov desc, nmov desc";
			command="";

            //DataRow ParentIncome;
            //string nomeTabella = "";
            //if (Meta.edit_type == "detail") {
            //    nomeTabella = "income";
            //}
            //if (Meta.edit_type == "variazione") {
            //    nomeTabella = "incomeview";
            //}

            
		}

		void CambiaFiltroMovimento(bool SearchMode){
			string filter;
            int nphasefin = CfgFn.GetNoNullInt32(Meta.GetSys("incomefinphase"));
            //DataRow[] fasi = DS.incomephase.Select("flagfinance='S'");
			filter=QHS.CmpEq("nphase", nphasefin);
			if (!SearchMode) filter = QHS.AppAnd(filter, QHS.CmpNe("unpartitioned", 0));
			//grpAccertamento.Tag+="."+filter;
			command="choose.incomeview.assegnazionecredito"+"."+filter;
		}

		public void MetaData_BeforeActivation() {
			string DescrFase="";
//			string filter="";
            int nphasefin = CfgFn.GetNoNullInt32( Meta.GetSys("incomefinphase"));
            int nphasemax = CfgFn.GetNoNullInt32(Meta.GetSys("maxincomephase"));
			
            //if (nphasefin==nphasemax) {
                DataRow[] fasi = DS.incomephase.Select(QHC.CmpEq("nphase",nphasefin));
            if (fasi.Length > 0) {
				DescrFase=fasi[0]["description"].ToString();
//				filter="(codicefase='"+fasi[0]["codicefase"].ToString()+"')"+
//					" AND (assegnare <> 0)";
//				grpAccertamento.Tag+="."+filter;
//				command="choose.entrataview.assegnazionecredito"+"."+filter;
				grpAccertamento.Text=DescrFase;
				btnAccertamento.Text=DescrFase;
			}
		}

		public void MetaData_AfterClear() {
			txtEsercAssegnazione.Text=Meta.GetSys("esercizio").ToString();
			grpAccertamento.Enabled=true;
			if (!Meta.GointToInsertMode) CambiaFiltroMovimento(true);
			if (Meta.IsEmpty)
			{
				txtEsercEntrata.Text="";
				txtEsercEntrata.ReadOnly=false;
			}
            string f = QHS.AppAnd(filteresercizio, QHS.CmpEq("finpart", 'S'), QHS.CmpEq("idupb", "0001"));
			GetData.SetStaticFilter(DS.finview, f);
		}

		public void MetaData_AfterFill() {
			string filter;
			if (!Meta.InsertMode){
				grpAccertamento.Enabled=false;
			}
			if (Meta.InsertMode)
			{
				txtEsercEntrata.Text = Meta.GetSys("esercizio").ToString();
				txtEsercEntrata.ReadOnly=true;
			}
			CambiaFiltroMovimento(false);
			if (DS.incomeview.Rows.Count>0){
				//
				filter = QHS.CmpEq("idupb", DS.incomeview.Rows[0]["idupb"]);
			}
			else {
				filter=QHS.CmpEq("idupb", "0001");
			}
            string f = QHS.AppAnd(filteresercizio, filter, QHS.CmpEq("finpart", 'S'));
			GetData.SetStaticFilter(DS.finview, f);
		}

		private void DoChooseCommand(Control sender){			
			string filter="";
			string mycommand=command;
			if  (sender==txtNumEntrata){
				filter=Meta.myHelpForm.GetSpecificCondition(grpAccertamento.Controls, "incomeview");
			}
			else {
				string eserc = txtEsercEntrata.Text.Trim();
				if (eserc!="") filter = QHS.CmpEq("ymov", eserc);
			}

			if (Meta.InsertMode)
			{
				string filter1= QHS.CmpEq("ymov", Meta.GetSys("esercizio"));
				filter = GetData.MergeFilters(filter,filter1);
                mycommand = QHS.AppAnd(mycommand, filter);
			}
			if (!(Meta.InsertMode) && (filter!=""))
                mycommand = QHS.AppAnd(mycommand, filter);
			
			if (!MetaData.Choose(this,mycommand)){
				if (sender!=null) sender.Focus();
			}
		}

		// restituisce l'importo per la nuova assegnazione (0 se c'è qualche anomalia)
		decimal GetImportoAssegnabile(DataRow RigaEntrataView)
		{
            decimal unpartitioned = CfgFn.GetNoNullDecimal(RigaEntrataView["unpartitioned"]);
            if (unpartitioned < 0) unpartitioned = 0;
            return unpartitioned;
		}

        decimal GetAssignableAmount() {
            if (Meta.IsEmpty) return 0;
            DataRow Curr = DS.creditpart.Rows[0];
            if (Curr["idinc"] == DBNull.Value) return 0;
            if (DS.incomeview.Rows.Count==0) return 0;
            DataRow CurrIncomeView = DS.incomeview.Rows[0];
            string filter = QHS.AppAnd(QHS.CmpEq("idinc", CurrIncomeView["idinc"]),
                QHS.CmpEq("ayear", CurrIncomeView["ayear"]));
            DataTable ImportoEntrata = Meta.Conn.RUN_SELECT("incometotal", "*", null, filter, null, true);
            if (ImportoEntrata.Rows.Count != 1) return 0;
            DataRow R = ImportoEntrata.Rows[0];
            decimal importocorrente = CfgFn.GetNoNullDecimal(R["curramount"]);
            decimal importoassegnato = CfgFn.GetNoNullDecimal(R["partitioned"]);
            decimal importoassegnazione = importocorrente - importoassegnato;
            if (importoassegnazione >= 0)
                return importoassegnazione;
            else
                return 0;
        }



		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName == "incomeview"){
				if (Meta.InsertMode){
					if (R==null){
						txtImporto.Text="";
						DS.creditpart.Rows[0]["amount"]=DBNull.Value;
						return;
					}
					Meta.GetFormData(true);
                    DS.creditpart.Rows[0]["amount"] = GetImportoAssegnabile(R);
					Meta.FreshForm();
				}
			}
            
           
		}

		private void btnAccertamento_Click(object sender, System.EventArgs e) {
			DoChooseCommand(null);
		}

		private void txtNumEntrata_Leave(object sender, System.EventArgs e) {
			
			if (txtNumEntrata.Text.Trim()!=""){
				DoChooseCommand((Control)sender);
				return;
			}
			//if txtNumentrata is empty:
			if (Meta.IsEmpty) return;
			ClearEntrata(false);	
		}

		void ClearEntrata(bool ClearEsercizio){
			txtImporto.Text="";
			txtNumAssegnazione.Text="";
			txtNumEntrata.Text="";
			if (ClearEsercizio) txtEsercEntrata.Text="";
			if (Meta.IsEmpty) return;
			DS.creditpart.Rows[0]["idinc"]=0;
			DS.creditpart.Rows[0]["ncreditpart"]=0;
			DS.creditpart.Rows[0]["amount"]=DBNull.Value;
		}

		private void txtEsercEntrata_Leave(object sender, System.EventArgs e) {
			string esercentrata=txtEsercEntrata.Text.Trim();
			if (esercentrata==""){
				MetaData.Choose(this, "choose.incomeview.unknown.clear");
				return;
			}
			
			//if txtEsercEntrata is not Empty:
			if (Meta.IsEmpty) return;
				
			if(DS.incomeview.Rows.Count>0 ){
				if (esercentrata== DS.incomeview.Rows[0]["ymov"].ToString())
					return;
				else{
					ClearEntrata(false);
					return;
				}	
			}

		}

		private void btnBilancio_Click(object sender, System.EventArgs e) {
			string filter;
			int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
		
			string filteridfin= QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.BitSet("flag", 0));
			DS.finview.Clear();
			//Il filtro sull'UPB c'è sempre
			if (DS.incomeview.Rows.Count>0){
				//
				filter = QHS.CmpEq("idupb", DS.incomeview.Rows[0]["idupb"]);
			}
			else {
                filter = QHS.CmpEq("idupb", "0001");
			}
			filter= QHS.AppAnd(filteridfin, filter);
			GetData.SetStaticFilter(DS.finview,filter);
            //DataAccess.RUN_SELECT_INTO_TABLE(Conn,DS.finview,null,filter,null,true);
			DS.finview.ExtendedProperties[MetaData.ExtraParams]=filter;
			MetaData.DoMainCommand(this,"manage.finview.treesupb");
		}

        private void btnUpb_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) {
                Meta.DoMainCommand("manage.upb.tree");
                return;
            }
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
          
            //calcola idunderwriting di income ove presente
            object idunderwriting = DBNull.Value;
            if (DS.incomeview.Select().Length > 0)
                idunderwriting = DS.incomeview.Rows[0]["idunderwriting"];
            if (idunderwriting == DBNull.Value ) {
                //era manage.upb.tree
                //Meta.DoMainCommand("manage.upb.tree");
                Meta.GetFormData(true);
                string filter = QHS.AppAnd(filteresercizio,QHS.CmpGt("expenseprevavailable", QHS.Field("creditavailable")),
                                            QHS.CmpEq("finpart", "S"));
                MetaData MetaUY = MetaData.GetMetaData(this, "upbfinyearview");
                MetaUY.DS = new DataSet();
                MetaUY.linkedForm = this;
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
                string filter = QHS.AppAnd(filteresercizio,QHS.CmpGt("expenseprevavailable", QHS.Field("creditavailable")),
                                            QHS.CmpEq("finpart", "S"), 
                                            QHS.CmpEq("idunderwriting", idunderwriting));
                MetaData MetaUnder = MetaData.GetMetaData(this, "upbunderwritingyearview");
                MetaUnder.DS = new DataSet();
                MetaUnder.linkedForm = this;
                MetaUnder.FilterLocked = true;
                DataRow Und = MetaUnder.SelectOne("crediti", filter, "upbunderwritingyearview", null);
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
        }
	}
}
