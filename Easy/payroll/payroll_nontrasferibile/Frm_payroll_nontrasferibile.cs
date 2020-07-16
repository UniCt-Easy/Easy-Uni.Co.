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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;

namespace payroll_nontrasferibile//cedolino_nontrasferibile//
{
	/// <summary>
	/// Summary description for frmcedolino_nontrasferibile.
	/// </summary>
	public class Frm_payroll_nontrasferibile : System.Windows.Forms.Form
	{
		public vistaForm DS;
		MetaData Meta;
		private System.Windows.Forms.DataGrid dgCedolino;
		private System.Windows.Forms.Button btnExcel;
		private System.Windows.Forms.Button btnChiudi;
		public System.Windows.Forms.GroupBox MetaDataDetail;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_payroll_nontrasferibile()
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
			this.DS = new vistaForm();
			this.dgCedolino = new System.Windows.Forms.DataGrid();
			this.btnExcel = new System.Windows.Forms.Button();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.MetaDataDetail = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCedolino)).BeginInit();
			this.SuspendLayout();
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// dgCedolino
			// 
			this.dgCedolino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.dgCedolino.CaptionVisible = false;
			this.dgCedolino.DataMember = "";
			this.dgCedolino.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgCedolino.Location = new System.Drawing.Point(8, 16);
			this.dgCedolino.Name = "dgCedolino";
			this.dgCedolino.Size = new System.Drawing.Size(728, 288);
			this.dgCedolino.TabIndex = 0;
			// 
			// btnExcel
			// 
			this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnExcel.Location = new System.Drawing.Point(16, 312);
			this.btnExcel.Name = "btnExcel";
			this.btnExcel.TabIndex = 1;
			this.btnExcel.Text = "Excel";
			this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnChiudi.Location = new System.Drawing.Point(656, 312);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.TabIndex = 2;
			this.btnChiudi.Text = "Chiudi";
			this.btnChiudi.Click += new System.EventHandler(this.btnChiudi_Click);
			// 
			// MetaDataDetail
			// 
			this.MetaDataDetail.Location = new System.Drawing.Point(208, 312);
			this.MetaDataDetail.Name = "MetaDataDetail";
			this.MetaDataDetail.Size = new System.Drawing.Size(200, 24);
			this.MetaDataDetail.TabIndex = 3;
			this.MetaDataDetail.TabStop = false;
			this.MetaDataDetail.Visible = false;
			// 
			// frmcedolino_nontrasferibile
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(744, 342);
			this.Controls.Add(this.MetaDataDetail);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.btnExcel);
			this.Controls.Add(this.dgCedolino);
			this.Name = "frmcedolino_nontrasferibile";
			this.Text = "frmcedolino_nontrasferibile";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgCedolino)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			Meta.CanCancel = false;
			Meta.CanInsert = false;
			Meta.CanInsertCopy = false;
			Meta.SearchEnabled = false;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            esercizio = (int)Meta.GetSys("esercizio");
            object flagMenuAdmin = Meta.GetSys("manage_prestazioni");

            riempiCedolinoNonTrasferibile();
		}


		/// <summary>
		/// Metodo che assegna la causa di non trasferibilit‡ dei cedolini presenti in CEDOLINONONTRASFERIBILE
		/// </summary>
		/// <param name="filtroCedolini">Cedolini a cui assegnare la causa</param>
		/// <param name="causa">Causa da assegnare</param>
		private void assegnaCausaACedoliniNonTrasferibili(string filtroCedolini,string causa) {
			if (filtroCedolini == "") return;
            string filtro = QHC.FieldInList("idpayroll", filtroCedolini);
			foreach(DataRow rCedolino in DS.payrollview.Select(filtro)) {
				rCedolino["!causa"] = causa;
			}
		}

        private void riempiCedolinoNonTrasferibile() {
            string queryContrattiAssegnisti = "select parasubcontract.idcon from parasubcontract "
                + "join parasubcontractyear on parasubcontractyear.idcon=parasubcontract.idcon "
                + "join service on parasubcontract.idser=service.idser where "
                + QHS.AppAnd(QHS.CmpEq("flagneedbalance", "N"), QHS.CmpEq("ayear", esercizio));
            DataTable tContrattiCheNonNecessitanoDiConguaglio = Meta.Conn.SQLRunner(queryContrattiAssegnisti);
            string filtroCedolini = "";
            // Selezione dei cedolini Non Trasferibili

            // 1. Cedolini dell'anno in corso di cui il contratto non ha un cedolino di conguaglio
            string queryContrattiSenzaConguaglio = "SELECT DISTINCT payroll.idcon"
                + " FROM payroll "
                + " WHERE NOT EXISTS "
                + " (SELECT * FROM payroll c "
                + " WHERE (c.fiscalyear = " + QHS.quote(esercizio) + ") "
                + " AND (c.idcon = payroll.idcon) "
                + " AND (c.flagbalance = " + QHS.quote("S") + ")) "
                + " AND EXISTS "
                + " (SELECT * FROM parasubcontractyear "
                + " WHERE (parasubcontractyear.idcon = payroll.idcon) "
                + " AND (parasubcontractyear.ayear = " + QHS.quote(esercizio) + "))";

            DataTable tContrattiSenzaConguaglio = Meta.Conn.SQLRunner(queryContrattiSenzaConguaglio);
            if (tContrattiSenzaConguaglio.Rows.Count > 0) {
                string filtroCedoliniSenzaConguaglio = QHS.AppAnd(
                    QHS.FieldIn("idcon", tContrattiSenzaConguaglio.Select()),
                    QHS.CmpEq("fiscalyear", esercizio));
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payrollview,
                    null, filtroCedoliniSenzaConguaglio, null, true);
                filtroCedolini = QHC.DistinctVal(DS.payrollview.Select("!causa is null"), "idpayroll");
                assegnaCausaACedoliniNonTrasferibili(filtroCedolini, "Contratto senza cedolino di conguaglio");
            }

            // 2. Cedolini Non Erogati di Conguaglio
            string filtraCedoliniConguaglio = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio),
                    QHS.IsNull("disbursementdate"), QHS.CmpEq("flagbalance", "S"));
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payrollview,
                null, filtraCedoliniConguaglio, null, true);
            DataRow[] rcnt = DS.payrollview.Select(QHC.IsNull("!causa"));
            filtroCedolini = QHC.DistinctVal(rcnt, "idpayroll");
            assegnaCausaACedoliniNonTrasferibili(filtroCedolini, "Cedolino di Conguaglio");

            ArrayList elencoContrattiConCedolinoDiConguaglio = new ArrayList();
            foreach (DataRow rCedolino in DS.payrollview.Rows) {
                elencoContrattiConCedolinoDiConguaglio.Add(rCedolino["idcon"]);
            }

            // 3. Primi Cedolini Non Erogati Anno Corrente - Questo filtro ha senso solo se esistono cedolini erogati
            // nell'anno in corso. Se non Ë mai stato erogato alcun cedolino si possono trasferire tutti i cedolini dell'anno
            string elencoPrimiCedoliniNonErogati = "";
            foreach (string idContratto in elencoContrattiConCedolinoDiConguaglio) {
                string filtroCedoliniErogati = QHS.AppAnd(QHS.CmpEq("idcon", idContratto),
                    QHS.CmpEq("flagbalance", "N"), QHS.CmpEq("fiscalyear", esercizio), QHS.IsNotNull("disbursementdate"));
                int nCedoliniErogatiNellAnno = Meta.Conn.RUN_SELECT_COUNT("payroll", filtroCedoliniErogati, true);
                if (nCedoliniErogatiNellAnno == 0) continue;
                string filter = QHS.AppAnd(QHS.CmpEq("idcon", idContratto), QHS.CmpEq("flagbalance", "N"),
                    QHS.CmpEq("fiscalyear", esercizio), QHS.IsNull("disbursementdate"),
                    QHS.FieldNotIn("idcon", tContrattiCheNonNecessitanoDiConguaglio.Select()));
                string orderby = "fiscalyear ASC,npayroll ASC";
                object idPrimoCedolino = Meta.Conn.DO_READ_VALUE("payroll", filter, "TOP 1 idpayroll", orderby);
                if ((idPrimoCedolino != null) && (idPrimoCedolino != DBNull.Value)) {
                    if (elencoPrimiCedoliniNonErogati == "") {
                        elencoPrimiCedoliniNonErogati = QHC.quote(idPrimoCedolino);
                    }
                    else {
                        elencoPrimiCedoliniNonErogati += "," + QHC.quote(idPrimoCedolino);
                    }
                }
            }
            if (elencoPrimiCedoliniNonErogati != "") {
                string fPrimiCedoliniAnnoCorr = QHC.FieldInList("idpayroll", elencoPrimiCedoliniNonErogati);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payrollview, null, fPrimiCedoliniAnnoCorr, null, true);
            }
            assegnaCausaACedoliniNonTrasferibili(elencoPrimiCedoliniNonErogati, "Primo Cedolino Non Erogato");


            // 3.  Cedolini dell'anno in corso di cui il contratto non esiste   nell'esercizio corrente
            string selectContrattiSenzaImputazione = "SELECT DISTINCT payroll.idcon"
                                                    + " FROM payroll "
                                                    + " WHERE ";
            string filterContrattiSenzaImputazione =
                " NOT EXISTS "
              + " (SELECT * FROM parasubcontractyear "
              + " WHERE (parasubcontractyear.idcon = payroll.idcon) "
              + " AND (parasubcontractyear.ayear = " + QHS.quote(esercizio) + ")) ";

            string filterCedoliniAnnoFiscaleNonErogati = QHS.AppAnd(QHS.CmpEq("fiscalyear", esercizio),
            QHS.IsNull("disbursementdate"), QHS.CmpEq("flagbalance", "N") );
            filterContrattiSenzaImputazione = QHS.AppAnd(filterContrattiSenzaImputazione, filterCedoliniAnnoFiscaleNonErogati);

            DataTable tContrattiSenzaSenzaImputazione = Meta.Conn.SQLRunner(selectContrattiSenzaImputazione + filterContrattiSenzaImputazione);
            if (tContrattiSenzaSenzaImputazione != null && tContrattiSenzaSenzaImputazione.Rows.Count > 0) {
                string filtraCedoliniSenzaImputazioneContratto = QHS.AppAnd (QHS.FieldIn("idcon", tContrattiSenzaSenzaImputazione.Select() ),
                  filterCedoliniAnnoFiscaleNonErogati);
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.payrollview,
                null, filtraCedoliniSenzaImputazioneContratto, null, true);
               
                filtroCedolini = QHC.DistinctVal(DS.payrollview.Select(QHC.IsNull("!causa")), "idpayroll");

                assegnaCausaACedoliniNonTrasferibili(filtroCedolini, "Cedolini con contratto senza imputazione nell'esercizio " + esercizio.ToString());
            }

            assegnaCaption();
            if (dgCedolino.DataSource == null) {
                HelpForm.SetDataGrid(dgCedolino, DS.Tables["payrollview"]);
                new formatgrids(dgCedolino).AutosizeColumnWidth();
            }
        }

		private void assegnaCaption() {
			foreach(DataColumn C in DS.Tables["payrollview"].Columns) {
				C.Caption = "";
			}
			DS.Tables["payrollview"].Columns["idpayroll"].Caption = "Num. Cedolino";
			DS.Tables["payrollview"].Columns["npayroll"].Caption = "Progressivo Anno";
			DS.Tables["payrollview"].Columns["fiscalyear"].Caption = "Anno Fiscale";
			DS.Tables["payrollview"].Columns["!causa"].Caption = "Causa";
			DS.Tables["payrollview"].Columns["ycon"].Caption = "Eserc. Contratto";
			DS.Tables["payrollview"].Columns["ncon"].Caption = "Num. Contratto";
			DS.Tables["payrollview"].Columns["registry"].Caption = "Percipiente";
			DS.Tables["payrollview"].Columns["codeupb"].Caption = "Cod. UPB";
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			string dataMember = dgCedolino.DataMember;
			CurrencyManager cm = (CurrencyManager) dgCedolino.BindingContext[DS, dataMember];
			DataView view = cm.List as DataView;
			DS.payrollview.ExtendedProperties["ExcelSort"] = view.Sort;
			exportclass.DataTableToExcel(DS.payrollview,true);
		}

		private void btnChiudi_Click(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}