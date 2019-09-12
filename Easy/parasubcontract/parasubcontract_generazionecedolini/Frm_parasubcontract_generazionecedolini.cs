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
using System.Data;
using metadatalibrary;
using System.Globalization;
using funzioni_configurazione;//funzioni_configurazione
using calcolocedolino;//calcolocedolino

namespace parasubcontract_generazionecedolini {//contratto_generazionecedolini//

	//	struct IntervalloDiDate {
	//		public DateTime MinDate, MaxDate;
	//	}
	//
	/// <summary>
	/// Summary description for FrmGenerazioneCedolini.
	/// </summary>
	public class FrmGenerazioneCedolini : System.Windows.Forms.Form {
		//		private IntervalloDiDate dtpInizio, dtpFine;
		private DataSet DS;
		private DataTable tGrid;
		private DataRow[] rGrid;

        /// <summary>
        /// Indice in tGrid del primo cedolino da erogare pari all'indice dell'ultimo erogato + 1. Se non è stato erogato nulla vale 0.
        /// </summary>
		private int selectedRow, primoCedolinoDaErogare;
		MetaData Meta;
		MetaData metaCedolino;
		DataRow[] rCedoliniErogati;
		int esercizio;
        CQueryHelper QHC;
        QueryHelper QHS;
		DateTime dtpInizioMinDate = DateTimePicker.MinDateTime;
		DateTime dtpInizioMaxDate = DateTimePicker.MaxDateTime;
		DateTime dtpFineMinDate = DateTimePicker.MinDateTime;
		DateTime dtpFineMaxDate = DateTimePicker.MaxDateTime;


		private System.Windows.Forms.Button btnSalva;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRimanenteContratto;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Button btnDurataInMesi;
		private System.Windows.Forms.NumericUpDown numUpDownMesi;
		private System.Windows.Forms.TextBox txtCompenso;
		private System.Windows.Forms.Button btnDividiInDue;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnUnisciColSuccessivo;
		private System.Windows.Forms.Button btnUnisciColPrecedente;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DataGrid gridCedolini;
		private System.Windows.Forms.GroupBox grpCedolinoSelezionato;
		private System.Windows.Forms.Label labelAvviso;
		private System.Windows.Forms.Button btnRicalcolaCompensi;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFineContratto;
		private System.Windows.Forms.TextBox txtDataInizio;
		private System.Windows.Forms.TextBox txtDataFine;
		private System.Windows.Forms.TextBox txtCompensoAnnuale;
		private System.Windows.Forms.TextBox txtTotaleCedolini;
		private System.Windows.Forms.Button btnCedoliniStandard;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// Costruttore
		/// </summary>
		/// <param name="meta">MetaData del form contratto</param>
		/// <param name="MetaCedolino">MetaData della tabella cedolino</param>
		/// <param name="ds">DataSet del form contratto</param>
		/// <param name="partiConAttualiCompensi">true se i cedolini devono essere letti dal DataSet;
		/// false se devono essere generati cedolini "standard"</param>
		/// <param name="compensoLordo">compenso del contratto</param>
		/// <param name="dataInizioContratto">data di inizio del contratto</param>
		/// <param name="dataFineContratto">data di fine del contratto</param>
		/// <param name="rCedoliniErogati">cedolini di questo contratto già erogati</param>
		public FrmGenerazioneCedolini(MetaData meta, MetaData MetaCedolino,
			DataSet ds, bool partiConAttualiCompensi,
			decimal compensoLordo,
			DateTime dataInizioContratto, DateTime dataFineContratto, 
			DataRow [] rCedoliniErogati
			) {
			Meta = meta;
			DS = ds;
			this.rCedoliniErogati = rCedoliniErogati;
			esercizio = (int)Meta.GetSys("esercizio");
			metaCedolino = MetaCedolino;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
			InitializeComponent();

			HelpForm.ExtLeaveDateTimeTextBox(txtDataInizio,"x.x");
			HelpForm.ExtLeaveDateTimeTextBox(txtDataFine,"x.x");
			
			txtFineContratto.Text = HelpForm.StringValue(dataFineContratto, "x.y");

			tGrid = new DataSet().Tables.Add();
			tGrid.Columns.Add("datainizio", typeof(DateTime)).Caption = "Data di inizio";
			tGrid.Columns.Add("datafine", typeof(DateTime)).Caption = "Data di fine";
			tGrid.Columns.Add("compenso", typeof(decimal)).Caption = "Compenso";
			tGrid.Columns.Add("flagerogato", typeof(string)).Caption = "Erogato";

			HelpForm.SetDataGrid(gridCedolini, tGrid);
			gridCedolini.AllowSorting = false;

			if (partiConAttualiCompensi) {  //i cedolini devono essere letti dal DataSet
                DataRow[] rCedoliniNonDiConguaglio = DS.Tables["payroll"].Select(QHC.CmpEq("flagbalance", 'N'), "fiscalyear, npayroll");

                primoCedolinoDaErogare = 0; //iniziamo con un valore di default
                //In tGrid tutti i cedolini, erogati e non 
                for (int i=0; i<rCedoliniNonDiConguaglio.Length; i++) {
					bool flagErogato = rCedoliniNonDiConguaglio[i]["disbursementdate"] != DBNull.Value;
					tGrid.Rows.Add(new object[] {
													(DateTime) rCedoliniNonDiConguaglio[i]["start"],
													(DateTime) rCedoliniNonDiConguaglio[i]["stop"],
													(decimal) rCedoliniNonDiConguaglio[i]["feegross"],
													flagErogato ? (object)"S" : DBNull.Value
												});
					if (flagErogato) {
						primoCedolinoDaErogare = i+1;
					}
				}
				rGrid = tGrid.Select(null, "datainizio");
				calcolaICompensiEdITotaliAPartireDalleDateNelGrid(false);
			}
			else {                          //devono essere generati cedolini "standard"
                rGrid = tGrid.Select(null, "datainizio");
				foreach(DataRow rCed in rCedoliniErogati) {
					if ((int)rCed["fiscalyear"] == esercizio) {
						tGrid.Rows.Add(new object [] {
														 rCed["start"], rCed["stop"],
														 rCed["feegross"], "S"
													 });
					}
				}
                //primoCedolinoDaErogare è pari all'indice in rCedoliniNonDiConguaglio del primo cedolino aumentato di uno
                primoCedolinoDaErogare = tGrid.Rows.Count;
				Cedolino[] cedolini = generaCedoliniStandard();
				salvaICedoliniNelDataSet(cedolini);
			}
		}

		/// <summary>
		/// Serve per eliminare la multiselezione del grid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HelpForm_MouseUp(object sender, MouseEventArgs e) {
			if (sender==null) return;
			if (!typeof(DataGrid).IsAssignableFrom(sender.GetType())) return;
			DataGrid G = (DataGrid) sender;
			DataSet D = G.DataSource as DataSet;
			if (D==null) return;
			DataTable T = D.Tables[G.DataMember];
			if (T==null) return;

			System.Windows.Forms.DataGrid.HitTestInfo myHitTest = G.HitTest(e.X,e.Y);
			if (myHitTest.Type== System.Windows.Forms.DataGrid.HitTestType.Cell){
				int Row = myHitTest.Row;
				if (!G.IsSelected(Row)){
					ClearSelection(G);
					GridSelectRow(G,Row);
				}
			}
			else {
				int Row = myHitTest.Row;
				ClearSelection(G);
				GridSelectRow(G,Row);
			}
		}

		private static void GridSelectRow(DataGrid G, int Row){
			try {
				G.Select(Row);
			}
			catch {
			}
		}

		/// <summary>
		/// Removes the selection from all grid rows
		/// </summary>
		/// <param name="G"></param>
		public static void ClearSelection(DataGrid G){
			DataSet GridDS= (DataSet) G.DataSource;
			if (GridDS==null) return;
			DataTable GridTB = GridDS.Tables[G.DataMember.ToString()];
			if (GridTB==null) return;
			try {
				for (int i=0; i< GridTB.Rows.Count; i++){
					if (G.IsSelected(i)) G.UnSelect(i);
				}
			}
			catch {
			}

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) {
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.btnSalva = new System.Windows.Forms.Button();
            this.btnCedoliniStandard = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCompensoAnnuale = new System.Windows.Forms.TextBox();
            this.txtTotaleCedolini = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRimanenteContratto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDurataInMesi = new System.Windows.Forms.Button();
            this.numUpDownMesi = new System.Windows.Forms.NumericUpDown();
            this.btnRicalcolaCompensi = new System.Windows.Forms.Button();
            this.txtCompenso = new System.Windows.Forms.TextBox();
            this.btnDividiInDue = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUnisciColSuccessivo = new System.Windows.Forms.Button();
            this.btnUnisciColPrecedente = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.gridCedolini = new System.Windows.Forms.DataGrid();
            this.grpCedolinoSelezionato = new System.Windows.Forms.GroupBox();
            this.txtDataFine = new System.Windows.Forms.TextBox();
            this.txtDataInizio = new System.Windows.Forms.TextBox();
            this.labelAvviso = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFineContratto = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMesi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCedolini)).BeginInit();
            this.grpCedolinoSelezionato.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalva
            // 
            this.btnSalva.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalva.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSalva.Location = new System.Drawing.Point(555, 440);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(88, 23);
            this.btnSalva.TabIndex = 10;
            this.btnSalva.Text = "OK";
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // btnCedoliniStandard
            // 
            this.btnCedoliniStandard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCedoliniStandard.Location = new System.Drawing.Point(555, 312);
            this.btnCedoliniStandard.Name = "btnCedoliniStandard";
            this.btnCedoliniStandard.Size = new System.Drawing.Size(160, 24);
            this.btnCedoliniStandard.TabIndex = 9;
            this.btnCedoliniStandard.Text = "Cedolini standard";
            this.btnCedoliniStandard.Click += new System.EventHandler(this.btnCedoliniStandard_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "nell\'anno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCompensoAnnuale
            // 
            this.txtCompensoAnnuale.Location = new System.Drawing.Point(8, 32);
            this.txtCompensoAnnuale.Name = "txtCompensoAnnuale";
            this.txtCompensoAnnuale.ReadOnly = true;
            this.txtCompensoAnnuale.Size = new System.Drawing.Size(112, 20);
            this.txtCompensoAnnuale.TabIndex = 1;
            this.txtCompensoAnnuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotaleCedolini
            // 
            this.txtTotaleCedolini.Location = new System.Drawing.Point(8, 16);
            this.txtTotaleCedolini.Name = "txtTotaleCedolini";
            this.txtTotaleCedolini.ReadOnly = true;
            this.txtTotaleCedolini.Size = new System.Drawing.Size(112, 20);
            this.txtTotaleCedolini.TabIndex = 0;
            this.txtTotaleCedolini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtCompensoAnnuale);
            this.groupBox1.Controls.Add(this.txtRimanenteContratto);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(615, 95);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 104);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Compenso da erogare";
            // 
            // txtRimanenteContratto
            // 
            this.txtRimanenteContratto.Location = new System.Drawing.Point(8, 80);
            this.txtRimanenteContratto.Name = "txtRimanenteContratto";
            this.txtRimanenteContratto.ReadOnly = true;
            this.txtRimanenteContratto.Size = new System.Drawing.Size(112, 20);
            this.txtRimanenteContratto.TabIndex = 3;
            this.txtRimanenteContratto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(1, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "fino alla fine del contratto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(659, 440);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Annulla";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtTotaleCedolini);
            this.groupBox3.Location = new System.Drawing.Point(615, 47);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(136, 40);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Totale cedolini";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnDurataInMesi);
            this.groupBox4.Controls.Add(this.numUpDownMesi);
            this.groupBox4.Location = new System.Drawing.Point(539, 200);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(212, 62);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            // 
            // btnDurataInMesi
            // 
            this.btnDurataInMesi.Location = new System.Drawing.Point(6, 8);
            this.btnDurataInMesi.Name = "btnDurataInMesi";
            this.btnDurataInMesi.Size = new System.Drawing.Size(144, 48);
            this.btnDurataInMesi.TabIndex = 0;
            this.btnDurataInMesi.Text = "Poni la durata di tutti i cedolini uguale a mesi:";
            this.btnDurataInMesi.Click += new System.EventHandler(this.btnDurataInMesi_Click);
            // 
            // numUpDownMesi
            // 
            this.numUpDownMesi.Location = new System.Drawing.Point(156, 24);
            this.numUpDownMesi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numUpDownMesi.Name = "numUpDownMesi";
            this.numUpDownMesi.Size = new System.Drawing.Size(40, 20);
            this.numUpDownMesi.TabIndex = 1;
            this.numUpDownMesi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnRicalcolaCompensi
            // 
            this.btnRicalcolaCompensi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRicalcolaCompensi.Location = new System.Drawing.Point(555, 282);
            this.btnRicalcolaCompensi.Name = "btnRicalcolaCompensi";
            this.btnRicalcolaCompensi.Size = new System.Drawing.Size(160, 24);
            this.btnRicalcolaCompensi.TabIndex = 8;
            this.btnRicalcolaCompensi.Text = "Ricalcola i compensi";
            this.btnRicalcolaCompensi.Click += new System.EventHandler(this.btnRicalcolaCompensi_Click);
            // 
            // txtCompenso
            // 
            this.txtCompenso.Location = new System.Drawing.Point(80, 88);
            this.txtCompenso.Name = "txtCompenso";
            this.txtCompenso.Size = new System.Drawing.Size(104, 20);
            this.txtCompenso.TabIndex = 5;
            this.txtCompenso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCompenso.Leave += new System.EventHandler(this.txtCompenso_Leave);
            // 
            // btnDividiInDue
            // 
            this.btnDividiInDue.Location = new System.Drawing.Point(200, 88);
            this.btnDividiInDue.Name = "btnDividiInDue";
            this.btnDividiInDue.Size = new System.Drawing.Size(120, 20);
            this.btnDividiInDue.TabIndex = 8;
            this.btnDividiInDue.Text = "Dividi in due";
            this.btnDividiInDue.Click += new System.EventHandler(this.btnDividiInDue_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Compenso";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUnisciColSuccessivo
            // 
            this.btnUnisciColSuccessivo.Location = new System.Drawing.Point(200, 56);
            this.btnUnisciColSuccessivo.Name = "btnUnisciColSuccessivo";
            this.btnUnisciColSuccessivo.Size = new System.Drawing.Size(120, 20);
            this.btnUnisciColSuccessivo.TabIndex = 7;
            this.btnUnisciColSuccessivo.Text = "Unisci col successivo";
            this.btnUnisciColSuccessivo.Click += new System.EventHandler(this.btnUnisciColSuccessivo_Click);
            // 
            // btnUnisciColPrecedente
            // 
            this.btnUnisciColPrecedente.Location = new System.Drawing.Point(200, 24);
            this.btnUnisciColPrecedente.Name = "btnUnisciColPrecedente";
            this.btnUnisciColPrecedente.Size = new System.Drawing.Size(120, 20);
            this.btnUnisciColPrecedente.TabIndex = 6;
            this.btnUnisciColPrecedente.Text = "Unisci col precedente";
            this.btnUnisciColPrecedente.Click += new System.EventHandler(this.btnUnisciColPrecedente_Click);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 20);
            this.label7.TabIndex = 2;
            this.label7.Text = "Data fine";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(16, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Data Inizio";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gridCedolini
            // 
            this.gridCedolini.AllowSorting = false;
            this.gridCedolini.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCedolini.DataMember = "";
            this.gridCedolini.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.gridCedolini.Location = new System.Drawing.Point(8, 8);
            this.gridCedolini.Name = "gridCedolini";
            this.gridCedolini.Size = new System.Drawing.Size(525, 328);
            this.gridCedolini.TabIndex = 2;
            this.gridCedolini.Paint += new System.Windows.Forms.PaintEventHandler(this.gridCedolini_Paint);
            this.gridCedolini.MouseUp += new System.Windows.Forms.MouseEventHandler(this.HelpForm_MouseUp);
            // 
            // grpCedolinoSelezionato
            // 
            this.grpCedolinoSelezionato.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.grpCedolinoSelezionato.Controls.Add(this.txtDataFine);
            this.grpCedolinoSelezionato.Controls.Add(this.txtDataInizio);
            this.grpCedolinoSelezionato.Controls.Add(this.txtCompenso);
            this.grpCedolinoSelezionato.Controls.Add(this.label8);
            this.grpCedolinoSelezionato.Controls.Add(this.label7);
            this.grpCedolinoSelezionato.Controls.Add(this.btnUnisciColPrecedente);
            this.grpCedolinoSelezionato.Controls.Add(this.btnUnisciColSuccessivo);
            this.grpCedolinoSelezionato.Controls.Add(this.label6);
            this.grpCedolinoSelezionato.Controls.Add(this.btnDividiInDue);
            this.grpCedolinoSelezionato.Location = new System.Drawing.Point(48, 344);
            this.grpCedolinoSelezionato.Name = "grpCedolinoSelezionato";
            this.grpCedolinoSelezionato.Size = new System.Drawing.Size(344, 120);
            this.grpCedolinoSelezionato.TabIndex = 1;
            this.grpCedolinoSelezionato.TabStop = false;
            this.grpCedolinoSelezionato.Text = "Cedolino selezionato";
            // 
            // txtDataFine
            // 
            this.txtDataFine.Location = new System.Drawing.Point(80, 56);
            this.txtDataFine.Name = "txtDataFine";
            this.txtDataFine.Size = new System.Drawing.Size(104, 20);
            this.txtDataFine.TabIndex = 3;
            this.txtDataFine.Leave += new System.EventHandler(this.txtDataFine_Leave);
            // 
            // txtDataInizio
            // 
            this.txtDataInizio.Location = new System.Drawing.Point(80, 24);
            this.txtDataInizio.Name = "txtDataInizio";
            this.txtDataInizio.Size = new System.Drawing.Size(104, 20);
            this.txtDataInizio.TabIndex = 1;
            this.txtDataInizio.Leave += new System.EventHandler(this.txtDataInizio_Leave);
            // 
            // labelAvviso
            // 
            this.labelAvviso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAvviso.Location = new System.Drawing.Point(8, 392);
            this.labelAvviso.Name = "labelAvviso";
            this.labelAvviso.Size = new System.Drawing.Size(440, 23);
            this.labelAvviso.TabIndex = 0;
            this.labelAvviso.Text = "Selezionare una riga per modificare il singolo cedolino.";
            this.labelAvviso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(547, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Fine contratto:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFineContratto
            // 
            this.txtFineContratto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFineContratto.Location = new System.Drawing.Point(627, 8);
            this.txtFineContratto.Name = "txtFineContratto";
            this.txtFineContratto.ReadOnly = true;
            this.txtFineContratto.Size = new System.Drawing.Size(100, 20);
            this.txtFineContratto.TabIndex = 4;
            // 
            // FrmGenerazioneCedolini
            // 
            this.AcceptButton = this.btnSalva;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(763, 478);
            this.Controls.Add(this.txtFineContratto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpCedolinoSelezionato);
            this.Controls.Add(this.labelAvviso);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnRicalcolaCompensi);
            this.Controls.Add(this.gridCedolini);
            this.Controls.Add(this.btnCedoliniStandard);
            this.Controls.Add(this.btnSalva);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGenerazioneCedolini";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compenso lordo dei cedolini";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMesi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridCedolini)).EndInit();
            this.grpCedolinoSelezionato.ResumeLayout(false);
            this.grpCedolinoSelezionato.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCedoliniStandard_Click(object sender, System.EventArgs e) {
			generaCedoliniStandard();
		}


		/// <summary>
		/// Mette nel grid cedolini "standard". Ci si basa sull'intervallo compreso tra 
		/// data inizio del primo ceodlino da erogare e data fine del contratto.
		/// Se l'intervallo dura esattamente n mesi, allora verranno generati n cedolini mensili
		/// altrimenti verranno generati n+1 cedolini giornalieri
		/// </summary>
		private Cedolino[] generaCedoliniStandard() {
			DateTime dataInizioContratto = (DateTime)DS.Tables["parasubcontract"].Rows[0]["start"];
			DateTime dataFineContratto = (DateTime)DS.Tables["parasubcontract"].Rows[0]["stop"];
			decimal compensoContratto = (decimal)DS.Tables["parasubcontract"].Rows[0]["grossamount"];
			decimal sommaRateDiQuestAnno;
			decimal sommaRateRimanentiContratto;
			
			Cedolino[] cedolini = CalcoliPerLaGenerazione.calcolaStipendiStandardDiQuestAnno(esercizio,
				dataInizioContratto, dataFineContratto, rCedoliniErogati, compensoContratto,
				out sommaRateDiQuestAnno, out sommaRateRimanentiContratto);

			arrotondaCompensiCedolini(cedolini);

			for (int i = cedolini.Length; i < rGrid.Length; i++){
				rGrid[i].Delete();
			}

			for (int i = primoCedolinoDaErogare; i < cedolini.Length; i++) {
				if (i >= rGrid.Length) {
					tGrid.Rows.Add(new object [] {
													 cedolini[i].dataInizio, cedolini[i].dataFine,
													 cedolini[i].compenso,DBNull.Value
												 });
				}
				else {
					rGrid[i]["datainizio"] = cedolini[i].dataInizio;
					rGrid[i]["datafine"] = cedolini[i].dataFine;
					rGrid[i]["compenso"] = cedolini[i].compenso;
					rGrid[i]["flagerogato"] = DBNull.Value;
				}
			}

			rGrid = tGrid.Select(null, "datainizio");

			txtCompensoAnnuale.Text = sommaRateDiQuestAnno.ToString("c");
			txtRimanenteContratto.Text = sommaRateRimanentiContratto.ToString("c");
			txtTotaleCedolini.Text = sommaRateDiQuestAnno.ToString("c");
			aggiornaGroupBoxInfoCedolini(true);
			return cedolini;
		}
		
		/// <summary>
		/// Cancella dal dataset tutti le righe delle tabelle figlie di una riga di cedolino
		/// </summary>
		/// <param name="rCedolino">riga padre</param>
		private void cancellaFigliDiCedolino(DataRow rCedolino) {
			foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolltax")) {
				foreach (DataRow r2 in r.GetChildRows("payrolltaxpayrolltaxbracket")) {
					r2.Delete();
				}
				r.Delete();
			}
            foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolltaxcorrige")) {
                r.Delete();
            }
			foreach (DataRow r in rCedolino.GetChildRows("payrollpayrollabatement")) {
				r.Delete();
			}
			foreach (DataRow r in rCedolino.GetChildRows("payrollpayrolldeduction")) {
				r.Delete();
			}
		}

		/// <summary>
		/// Dati n cedolini di tutto l'anno, arrotonda i compensi dei primi n-1 cedolini
		/// e il compenso dell'ultimo viene posto uguale 
		/// all'arrotondamento della somma dei compensi di tutti i cedolini
		/// meno la somma dei compensi arrotondati dei primi n-1 cedolini
		/// </summary>
		/// <param name="cedolini"></param>
		private void arrotondaCompensiCedolini(Cedolino[] cedolini) {
			decimal compensoAnnuale = 0;
			decimal compensoAnnualeArrotondato = 0;
		    if (cedolini.Length == 0) return;
			for (int i=0; i<cedolini.Length; i++) {
				compensoAnnuale += cedolini[i].compenso;
				if (i<cedolini.Length - 1) {
					cedolini[i].compenso = CfgFn.RoundValuta(cedolini[i].compenso);
					compensoAnnualeArrotondato += CfgFn.RoundValuta(cedolini[i].compenso);
				}
			}
			cedolini[cedolini.Length - 1].compenso = CfgFn.RoundValuta(compensoAnnuale - compensoAnnualeArrotondato);
		}

		/// <summary>
		/// Risultato della chiamata a questo metodo è che la tabella cedolino
		/// conterrà i cedolini con i dati passati in input
		/// </summary>
		/// <param name="cedoliniMensili"></param>
		private void salvaICedoliniNelDataSet(Cedolino[] cedolini) {
		    if (cedolini.Length > 0) {
		        DS.Tables["parasubcontractyear"].Rows[0]["stopcompetency"] = cedolini[cedolini.Length - 1].dataFine;
		    }
		    else {
		        DS.Tables["parasubcontractyear"].Rows[0]["stopcompetency"] = new DateTime(esercizio, 12, 31);
		        return;
		    }
			
			DataRow parentRow = DS.Tables["parasubcontract"].Rows[0];
			metaCedolino.SetDefaults(DS.Tables["payroll"]);
			MetaData.SetDefault(DS.Tables["payroll"], "fiscalyear", esercizio);
				
			DataRow[] rCedolini = DS.Tables["payroll"].Select(null, "idpayroll");
			for (int i=0; i<cedolini.Length; i++) {
				Cedolino cedolino = cedolini[i];
				if (!cedolino.flagErogato) {
					DataRow rCedolino = (i >= rCedolini.Length)
						? metaCedolino.Get_New_Row(parentRow, DS.Tables["payroll"]) 
						: rCedolini[i];
					rCedolino["workingdays"] = 1+(cedolino.dataFine-cedolino.dataInizio).Days;
					rCedolino["feegross"] = cedolino.compenso;
					rCedolino["npayroll"] = cedolino.meseRiferimento;
					rCedolino["fiscalyear"] = cedolino.annoRiferimento;
					rCedolino["flagbalance"] = "N";
                    rCedolino["flagsummarybalance"] = "N";
					rCedolino["idresidence"] = DS.Tables["parasubcontractyear"].Rows[0]["idresidence"];
					rCedolino["flagcomputed"] = "N";
					rCedolino["fiscalyear"] = esercizio;
					rCedolino["start"] = cedolino.dataInizio;
					rCedolino["stop"] = cedolino.dataFine;
					rCedolino["enabletaxrelief"] = "S";
					rCedolino["netfee"] = DBNull.Value;
				}
			}
			decimal compensoAnnuale = 0;
			for (int i = 0; i< cedolini.Length; i++) {
				compensoAnnuale += (decimal)cedolini[i].compenso;
			}
            
			DataRow rCedCong = (cedolini.Length >= rCedolini.Length)
				? metaCedolino.Get_New_Row(parentRow, DS.Tables["payroll"]) 
				: rCedolini[cedolini.Length];

			int numeroCedolini = cedolini.Length;
		        rCedCong["workingdays"] = 1 + (cedolini[numeroCedolini - 1].dataFine - cedolini[0].dataInizio).Days;
		        rCedCong["feegross"] = compensoAnnuale;
		        rCedCong["npayroll"] = cedolini[numeroCedolini - 1].meseRiferimento;
		        rCedCong["fiscalyear"] = cedolini[numeroCedolini - 1].annoRiferimento;
		        rCedCong["flagbalance"] = "S";
                rCedCong["flagsummarybalance"] = "N";
		        rCedCong["idresidence"] = DS.Tables["parasubcontractyear"].Rows[0]["idresidence"];
		        rCedCong["flagcomputed"] = "N";
		        rCedCong["fiscalyear"] = esercizio;
		        rCedCong["start"] = cedolini[0].dataInizio;
		        rCedCong["stop"] = cedolini[numeroCedolini - 1].dataFine;
		        rCedCong["enabletaxrelief"] = "S";
		        rCedCong["netfee"] = DBNull.Value;
		    
			

			for (int i=0; i<rCedolini.Length; i++) {
				if (rCedolini[i]["disbursementdate"] == DBNull.Value) {
					cancellaFigliDiCedolino(rCedolini[i]);
					if (i > cedolini.Length) {
						rCedolini[i].Delete();
					}
				}
			}
		}

		/// <summary>
		/// Converte la tabella del grid in un array di cedolini. Se c'è incoerenza tra la somma dei compensi
		/// nel grid e quella effettivamente a disposizione viene restituito null
		/// </summary>
		/// <param name="eseguiControlliPreventivi">true se devono essere visualizzati eventuali incoerenze
		/// tra la somma dei compensi nel grid e la somma a disposizione per l'anno in corso</param>
		/// <returns></returns>
		private Cedolino[] leggiICedoliniDalGrid(bool eseguiControlliPreventivi) {
			int esercizio = (int) Meta.GetSys("esercizio");
			Cedolino[] nuoviCedolini = new Cedolino[rGrid.Length];
            int primoCedolinoErogatoAnnoFiscale = -1;
            for (int j = 0; j < rCedoliniErogati.Length; j++) {
                if (CfgFn.GetNoNullInt32(rCedoliniErogati[j]["fiscalyear"]) == esercizio) {
                    primoCedolinoErogatoAnnoFiscale = j;
                    break;
                }
            }
            
			decimal sommaCompensi = 0;
			for (int i=0; i<nuoviCedolini.Length; i++) {
				decimal d = (decimal) rGrid[i]["compenso"];
				nuoviCedolini[i].compenso = d;
				if (i<primoCedolinoDaErogare) {
                    if (primoCedolinoErogatoAnnoFiscale >= 0) {
                        //task 10549: al cedolino di conguaglio veniva attribuito lo stesso numero del cedolino di conguaglio
                        nuoviCedolini[i].annoRiferimento = (int)rCedoliniErogati[i + primoCedolinoErogatoAnnoFiscale]["fiscalyear"];
                        nuoviCedolini[i].meseRiferimento = (int)rCedoliniErogati[i + primoCedolinoErogatoAnnoFiscale]["npayroll"];
                    }
                    else {
                        nuoviCedolini[i].annoRiferimento = esercizio;
                        nuoviCedolini[i].meseRiferimento = i + 1;
                    }
				} else {
					nuoviCedolini[i].annoRiferimento = esercizio;
					nuoviCedolini[i].meseRiferimento = (i>0) 
						? 1 + nuoviCedolini[i-1].meseRiferimento
						: 1;
				}
				nuoviCedolini[i].dataInizio = (DateTime) rGrid[i]["datainizio"];
				nuoviCedolini[i].dataFine = (DateTime) rGrid[i]["datafine"];
				nuoviCedolini[i].flagErogato = i < primoCedolinoDaErogare;
				sommaCompensi += d;
			}
			if ((eseguiControlliPreventivi) && (rGrid.Length>0)) {
				decimal compensoPrevistoQuestAnno = (decimal) HelpForm.GetObjectFromString(typeof(decimal), txtCompensoAnnuale.Text, "x");
				decimal compensoRimanente = (decimal) HelpForm.GetObjectFromString(typeof(decimal), txtRimanenteContratto.Text, "x");
				DateTime fineContratto = (DateTime) DS.Tables["parasubcontract"].Rows[0]["stop"];
				DateTime fineCompetenza = (DateTime) rGrid[rGrid.Length-1]["datafine"];
				if ((fineCompetenza == fineContratto) && (sommaCompensi != compensoRimanente)) {
					MessageBox.Show(this, "La somma dei compensi ("
						+ sommaCompensi.ToString("C")
						+ ") è diversa dal compenso ancora da erogare ("
						+ txtRimanenteContratto.Text
						+ ") previsto dal contratto.", "Impossibile salvare!");
					this.DialogResult = DialogResult.None;
					return null;
				}
				if (sommaCompensi > compensoRimanente) {
					MessageBox.Show(this, "La somma dei compensi ("
						+ sommaCompensi.ToString("C")
						+ ") non deve superare il compenso ancora da erogare ("
						+ txtRimanenteContratto.Text
						+ ") previsto dal contratto.", "Impossibile salvare!");
					this.DialogResult = DialogResult.None;
					return null;
				}
				decimal differenza = sommaCompensi - compensoPrevistoQuestAnno;
				if (differenza != 0) {
					string messaggio = "La somma dei compensi (" + sommaCompensi.ToString("C") + ") ";
					messaggio += (differenza < 0) ? 
						"è inferiore di " + (-differenza).ToString("C") + " rispetto al": 
						"supera di " + differenza.ToString("C") + " il";
					messaggio += " compenso ancora da erogare (" + compensoPrevistoQuestAnno.ToString("C") 
						+ ") previsto dal contratto.\nSi desidera procedere ugualmente?";

					DialogResult dr = MessageBox.Show(this, messaggio, "Avviso", MessageBoxButtons.YesNoCancel);
					if (dr != DialogResult.Yes) {
						this.DialogResult = DialogResult.None;
						return null;
					} 
				}
			}
			return nuoviCedolini;
		}
		
		/// <summary>
		/// Salva i cedolini dal grid nel dataset
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSalva_Click(object sender, System.EventArgs e) {
			Cedolino[] cedolini = leggiICedoliniDalGrid(true);
			if (cedolini != null) {
				salvaICedoliniNelDataSet(cedolini);
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="dataInizio"></param>
		/// <returns></returns>
		private int cercaRigaInGrid(DateTime dataInizio) {
			for (int i = 0; i<rGrid.Length; i++) {
				if ((DateTime)rGrid[i]["datainizio"] == dataInizio) {
					return i;
				}
			}
			return -1;
		}

		/// <summary>
		/// Restituisce l'indice di riga della tabella tGrid selezionata nel grid
		/// </summary>
		/// <returns></returns>
		private int getUnicaRigaSelezionata() {
			CurrencyManager cm = (CurrencyManager) gridCedolini.BindingContext[gridCedolini.DataSource, gridCedolini.DataMember];
			DataView view = cm.List as DataView;
			if (view == null) {
				return -1;
			}
			int result = -1;
			for (int i=0; i<view.Count; i++) {
				if (gridCedolini.IsSelected(i)) {
					if (result==-1) {
						result = cercaRigaInGrid((DateTime)view[i]["datainizio"]);
					} else {
						return -1;
					}
				}
			}
			return result;
		}

		/// <summary>
		/// A seconda della riga selezionata nel grid vengono aggiornati i textbox corrispondenti
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void gridCedolini_Paint(object sender, System.Windows.Forms.PaintEventArgs e) {
			aggiornaGroupBoxInfoCedolini(false);
		}

		/// <summary>
		/// Aggiorna i textbox corrispondenti al cedolino selezionato nel grid.
		/// </summary>
		/// <param name="aggiornaSempre">false se si desidera effettuare l'aggiornamento
		/// solo se è cambiata la riga selezionata</param>
		private void aggiornaGroupBoxInfoCedolini(bool aggiornaSempre) {
			int riga = getUnicaRigaSelezionata();
			if ((riga == selectedRow) && !aggiornaSempre) {
				return;
			}
			selectedRow = riga;
			if (riga >= 0) {
				labelAvviso.Visible = false;
				grpCedolinoSelezionato.Visible = true;

				setDateInizioEFine();

				txtCompenso.Text = ((decimal)rGrid[riga]["compenso"]).ToString("c");
			} else {
				labelAvviso.Visible = true;
				grpCedolinoSelezionato.Visible = false;
			}
			bool enabled = riga >= primoCedolinoDaErogare;
			btnUnisciColPrecedente.Enabled = riga > primoCedolinoDaErogare;
			btnUnisciColSuccessivo.Enabled = enabled && (riga<rGrid.Length-1); 
			grpCedolinoSelezionato.Text = enabled
				? "Cedolino selezionato"
				: "Cedolino selezionato già erogato";
			if (riga < 0) {
				txtDataInizio.ReadOnly = true;
				txtDataFine.ReadOnly = true;
			}
			bool abilitaBottoneDividi = enabled;
			if (riga >= 0){
				DateTime dataInizioCedolino = (DateTime) rGrid[riga]["datainizio"];
				DateTime dataFineCedolino = (DateTime) rGrid[riga]["datafine"];
				abilitaBottoneDividi = enabled && (dataFineCedolino != dataInizioCedolino)
					&& (dataInizioCedolino < new DateTime(esercizio, 12, 31));
			}
			btnDividiInDue.Enabled = abilitaBottoneDividi;
			txtCompenso.Enabled = enabled;
		}

		/// <summary>
		/// Setta gli intervalli di validità delle date di inizio e fine del cedolino selezionato.
		/// Normalmente i valori validi per la data di inizio sono quelli compresi tra l'inizio
		/// del primo cedolino da erogare e minimo(data di fine del cedolino, 31 dicembre di quest'anno)
		/// La data fine può invece assumere i valori compresi tra la data di inizio
		/// e minimo(data di fine del contratto, 12 gennaio dell'anno successivo)
		/// </summary>
		private void setDateInizioEFine() {
			int riga = selectedRow;
			if (riga == -1) {
				return;
			}
			if (riga < primoCedolinoDaErogare) {
				txtDataInizio.Enabled = false;
				txtDataFine.Enabled = false;
				txtDataInizio.Text = HelpForm.StringValue(rGrid[riga]["datainizio"], "x.y");
				txtDataFine.Text = HelpForm.StringValue(rGrid[riga]["datafine"], "x.y");
				return;
			}
			txtDataInizio.Enabled = true;
			txtDataFine.Enabled = true;

			DateTime gennaio12 = new DateTime(esercizio+1, 1, 12);

			DateTime inizioMin = (DateTime) rGrid[primoCedolinoDaErogare]["datainizio"];
			DateTime inizioMax = (DateTime) rGrid[riga]["datafine"];

			DateTime fineMin = (DateTime) rGrid[riga]["datainizio"];
			DateTime fineMax = (DateTime) DS.Tables["parasubcontract"].Rows[0]["stop"];

			if (inizioMax.Year > esercizio) {
				inizioMax = new DateTime(esercizio, 12, 31);
			}

			if (fineMax > gennaio12) {
				fineMax = gennaio12;
			}

			setMinEMaxDate(ref dtpInizioMinDate, ref dtpInizioMaxDate, txtDataInizio, inizioMin, inizioMax);
			setMinEMaxDate(ref dtpFineMinDate, ref dtpFineMaxDate, txtDataFine, fineMin, fineMax);

			DateTime inizio = (DateTime) rGrid[riga]["datainizio"];
			DateTime fine = (DateTime) rGrid[riga]["datafine"];

			txtDataInizio.Text = HelpForm.StringValue(inizio, "x.y");
			txtDataFine.Text = HelpForm.StringValue(fine, "x.y");
		}

		/// <summary>
		/// Imposta l'intervallo di validita di una data e disabilita eventualmente il textbox
		/// se l'intervallo è composto di un solo giorno.
		/// </summary>
		/// <param name="dtp"></param>
		/// <param name="txt">Textbox contenente la data</param>
		/// <param name="min">valore minimo valido</param>
		/// <param name="max">valore massimo valido</param>
		private void setMinEMaxDate(ref DateTime dtpMinDate, ref DateTime dtpMaxDate, TextBox txt, DateTime min, DateTime max) {
			if (min >= max) {
				txt.ReadOnly = true;
				dtpMinDate = DateTimePicker.MinDateTime;
				dtpMaxDate = DateTimePicker.MaxDateTime;
				return;
			}
			if (min >= dtpMaxDate) {
				dtpMaxDate = max;
				dtpMinDate = min;
			} else {
				dtpMinDate = min;
				dtpMaxDate = max;
			}
			txt.ReadOnly = false;
		}

		/// <summary>
		/// Cambia il compenso del cedolino selezionato se questo è valido,
		/// altrimenti verrà segnalato un errore
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void txtCompenso_Leave(object sender, System.EventArgs e) {
			int riga = selectedRow;
			if (riga==-1) {
				return;
			}
			object o = HelpForm.GetObjectFromString(typeof(decimal),txtCompenso.Text,"x.x");
			if ((o == null) || (o == DBNull.Value)) {
				string messaggio = (o == null) 
					? "E' stato inserito un valore non valido per il compenso."
					: "Il compenso è un dato obbligatorio e non è possibile cancellarlo.";
				string vecchioValore = ((decimal)rGrid[riga]["compenso"]).ToString("c");
				MessageBox.Show(this, messaggio
					+ "\nVerrà ripristinato il valore precedente."
					+ "\n\nValore inserito: " + txtCompenso.Text
					+ "\nValore precedente: " + vecchioValore, "Compenso non valido");
				txtCompenso.Text = vecchioValore;
				txtCompenso.Focus();
			} else {
				decimal compenso = (decimal) o;
				rGrid[riga]["compenso"] = CfgFn.RoundValuta(compenso);
				txtCompenso.Text = compenso.ToString("c");
			}
			decimal compensoDiQuestAnno = 0;
			for (int i=0; i<rGrid.Length; i++) {
				compensoDiQuestAnno += (decimal) rGrid[i]["compenso"];
			}
			txtTotaleCedolini.Text = compensoDiQuestAnno.ToString("C");
		}

		/// <summary>
		/// Cambia la data di fine del cedolino alla riga specificata.
		/// Vengono eliminati tutti i cedolini successivi a quello specificato 
		/// che abbiano data di fine inferiore alla nuovadatafine.
		/// Viene cambiata la data di inizio del cedolino immediatamente
		/// successivo a quelli eliminati e viene effettuata una ripartizione
		/// dei compensi tra questo cedolino ed il cedolino alla riga specificata.
		/// </summary>
		/// <param name="riga">riga del cedolino di cui si vuole cambiare la data di fine</param>
		/// <param name="nuovaDataFine">nuova data di fine del cedolino</param>
		private void cambiaDataFine(int riga, DateTime nuovaDataFine) {
			DateTime vecchiaDataFine = (DateTime) rGrid[riga]["datafine"];
			if (vecchiaDataFine == nuovaDataFine) {
				return;
			}
			DateTime vecchiaUltimaDataFine = (DateTime) rGrid[rGrid.Length-1]["datafine"];
			rGrid[riga]["datafine"] = nuovaDataFine;
			decimal compensoTot = (decimal) rGrid[riga]["compenso"];
			int i = riga+1;
			DateTime fineAnno = new DateTime(esercizio, 12, 31);
			bool confrontoInutile = nuovaDataFine >= fineAnno;
			while ((i<rGrid.Length) 
				&& (confrontoInutile || (nuovaDataFine.CompareTo(rGrid[i]["datafine"])) >= 0)) {
				compensoTot += (decimal) rGrid[i]["compenso"];
				rGrid[i].Delete();
				i++;
			}
			if (i < rGrid.Length) {
				compensoTot += (decimal)rGrid[i]["compenso"];

				DateTime fineCedSucc = (DateTime) rGrid[i]["datafine"];

				decimal compenso1 = ripartisciCompensoTraDueCedolini(
					(DateTime) rGrid[riga]["datainizio"],
					nuovaDataFine, fineCedSucc, compensoTot);

				rGrid[riga]["compenso"] = compenso1;

				rGrid[i]["datainizio"] = nuovaDataFine.AddDays(1);
				rGrid[i]["compenso"] = compensoTot - compenso1;
			}
			else {
				if (nuovaDataFine == vecchiaUltimaDataFine) {
					rGrid[riga]["compenso"] = compensoTot;
					
				} else {
					DateTime dataFineContratto = (DateTime) DS.Tables["parasubcontract"].Rows[0]["stop"];

					DateTime dataInizio = (DateTime) rGrid[riga]["datainizio"];
					int numVecchiGiorni = 1 + (vecchiaUltimaDataFine - dataInizio).Days;
					int numNuoviGiorni = 1 + (nuovaDataFine - dataInizio).Days;
					decimal pagaGiornaliera = compensoTot / numVecchiGiorni;
					decimal compenso1 = CfgFn.RoundValuta(numNuoviGiorni * pagaGiornaliera);
					

					if ((nuovaDataFine < vecchiaUltimaDataFine) && (nuovaDataFine < fineAnno)) {
						
						DateTime fineCedSucc = (vecchiaUltimaDataFine.Year > esercizio) ? fineAnno : vecchiaUltimaDataFine;
						compenso1 = ripartisciCompensoTraDueCedolini(
							(DateTime) rGrid[riga]["datainizio"],
							nuovaDataFine, fineCedSucc, compensoTot);

						decimal compenso2 = compensoTot - compenso1;
						tGrid.Rows.Add(new object[] {
														nuovaDataFine.AddDays(1), fineCedSucc, compenso2, DBNull.Value
													});
					}
					rGrid[riga]["compenso"] = compenso1;
					rGrid = tGrid.Select(null, "datainizio");

					calcolaICompensiEdITotaliAPartireDalleDateNelGrid(false);
				}
			}
			rGrid = tGrid.Select(null, "datainizio");
			aggiornaGroupBoxInfoCedolini(true);
		}

		/// <summary>
		/// Sostituisce nel grid i cedolini attuali con altri cedolini la cui durata in mesi
		/// (periodicità) è quella contenuta nel numericUpDown.
		/// I cedolini già erogati vengono lasciati inalterati.
		/// Indichiamo con dataInizio il giorno successivo alla data di fine dell'ultimo cedolino da erogare.
		/// Indichiamo con dataFine la data di fine contratto se questa ricade nell'esercizio corrente
		/// oppure la data compresa tra l'1 ed il 12 gennaio che abbia una distanza in mesi esattamente
		/// multipla della periodicità oppure 31 dicembre di quest'anno altrimenti.
		/// Indichiamo con num = (distanza in mesi tra data inizio e data fine) / periodicità.
		/// Se num è un numero intero allora verranno generati num cedolini con le date inizio e fine 
		/// distanziate tra di loro di n=periodicità mesi.
		/// Se num non è un numero intero allora verranno generati lo stesso num cedolini
		/// ma l'ultimo avrà una durata maggiore degli altri per far sì che la sua data di fine
		/// coincida con dataFine.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDurataInMesi_Click(object sender, System.EventArgs e) {
            if (rGrid.Length == 0)
                return;

			int periodicita = Convert.ToInt32(numUpDownMesi.Value);

            if (primoCedolinoDaErogare >= rGrid.Length) return;

			DateTime dataInizio = (DateTime) rGrid[primoCedolinoDaErogare]["datainizio"];
			DateTime dataFineContratto = (DateTime) DS.Tables["parasubcontract"].Rows[0]["stop"];

			DateTime dataFine = CalcoliPerLaGenerazione.calcolaFineCompetenzaAnnoFiscale(
				esercizio, dataInizio, dataFineContratto, periodicita);

			DateTime[] dateInizioCedoliniDaErogareQuestAnno, dateFineCedoliniDaErogareQuestAnno;
			CalcoliPerLaGenerazione.calcolaDateInizioEFineDeiCedolini(
				dataInizio,
				dataFine,
				periodicita,
				out dateInizioCedoliniDaErogareQuestAnno, out dateFineCedoliniDaErogareQuestAnno);

			int numCedoliniDiQuestAnno = dateInizioCedoliniDaErogareQuestAnno.Length + primoCedolinoDaErogare;
			for (int i=primoCedolinoDaErogare; i<numCedoliniDiQuestAnno; i++) {
				if (i<rGrid.Length) {
					rGrid[i]["datainizio"] = dateInizioCedoliniDaErogareQuestAnno[i - primoCedolinoDaErogare];
					rGrid[i]["datafine"] = dateFineCedoliniDaErogareQuestAnno[i - primoCedolinoDaErogare];
				} else {
					tGrid.Rows.Add(new object[] {
						dateInizioCedoliniDaErogareQuestAnno[i - primoCedolinoDaErogare], 
						dateFineCedoliniDaErogareQuestAnno[i - primoCedolinoDaErogare], 
						0, 
						DBNull.Value
					});
				}
			}
			for (int i=numCedoliniDiQuestAnno; i<rGrid.Length; i++) {
				rGrid[i].Delete();
			}
			rGrid = tGrid.Select(null, "datainizio");
			calcolaICompensiEdITotaliAPartireDalleDateNelGrid(true);
		}

		bool stoCambiandoLaDataInizio = false;
		/// <summary>
		/// Cambia la data di inizio del cedolino alla riga specificata.
		/// Elimina tutti i cedolini precedenti quello specificato
		/// che abbiano data di inizio maggiore della nuovaData di inizio.
		/// La data di fine del cedolino immediatamente precedente quelli eliminati
		/// viene posta uguale al giorno precedente la nuovaDataInizio e viene
		/// effettuata una ripartizione dei compensi tra questo cedolino
		/// ed il cedolino alla riga specificata.
		/// </summary>
		/// <param name="riga">riga del cedolino di cui si vuole cambiare la data di inizio</param>
		/// <param name="nuovaDataInizio">nuova data di inizio</param>
		private void cambiaDataInizio(int riga, DateTime nuovaDataInizio) {
			if (stoCambiandoLaDataInizio) return;
			DateTime vecchiaDataInizio = (DateTime) rGrid[riga]["datainizio"];
			if (vecchiaDataInizio == nuovaDataInizio) {
				return;
			}
			stoCambiandoLaDataInizio = true;
			DateTime dataInizioPrimoCedolino = (DateTime) rGrid[primoCedolinoDaErogare]["datainizio"]; 
			rGrid[riga]["datainizio"] = nuovaDataInizio;
			decimal compensoTot = (decimal) rGrid[riga]["compenso"];
			int i = riga-1;
			while ((i>=primoCedolinoDaErogare) && (nuovaDataInizio.CompareTo(rGrid[i]["datainizio"]) <= 0)) {
				compensoTot += (decimal) rGrid[i]["compenso"];
				rGrid[i].Delete();
				i--;
			}
			DateTime inizioCedPrec = dataInizioPrimoCedolino;

			if (i >= primoCedolinoDaErogare) {
				inizioCedPrec = (DateTime)rGrid[i]["datainizio"];
				compensoTot += (decimal) rGrid[i]["compenso"];
			}

			decimal compenso1 = ripartisciCompensoTraDueCedolini(
				inizioCedPrec,
				nuovaDataInizio.AddDays(-1),
				(DateTime) rGrid[riga]["datafine"],
				compensoTot);

			if (i == primoCedolinoDaErogare-1) {
				if (nuovaDataInizio > dataInizioPrimoCedolino) {
					inserisciCedolino(primoCedolinoDaErogare, dataInizioPrimoCedolino, 
						nuovaDataInizio.AddDays(-1), compenso1);
				}
			} else {
				rGrid[i]["datafine"] = nuovaDataInizio.AddDays(-1);
				rGrid[i]["compenso"] = compenso1;
			}
			rGrid[riga]["compenso"] = compensoTot - compenso1;
			rGrid = tGrid.Select(null, "datainizio");
			aggiornaGroupBoxInfoCedolini(true);
			stoCambiandoLaDataInizio = false;
		}

		/// <summary>
		/// A partire dal compenso da erogare tra le date inizio1 e fine2
		/// calcola la parte da erogare tra le date inizio1 e fine1.
		/// Se l'intervallo temporale (inizio1, fine2) ha durata in mesi 
		/// esattamente multipla  dell'intervallo (inizio1, fine1)
		/// e se entrambi gli intervalli sono multipli della durata di 1 mese,
		/// allora la ripartizione avviene in base alla durata mensile dei due intervalli,
		/// altrimenti la ripartizione avviene in base alla durata giornaliera
		/// </summary>
		/// <param name="inizio1">data di inizio del cedolino da calcolare coincidente
		/// con la data di inizio di competenza del compenso in input</param>
		/// <param name="fine1">data di fine del cedolino da calcolare</param>
		/// <param name="fine2">data di fine di competenza del compenso in input</param>
		/// <param name="compensoTot"></param>
		/// <returns></returns>
		private decimal ripartisciCompensoTraDueCedolini(DateTime inizio1, DateTime fine1, DateTime fine2, decimal compensoTot) {
			bool flagCalcoloARitroso;
			int diffMesi1 = CalcoliPerLaGenerazione.differenzaInMesi(inizio1, fine1, out flagCalcoloARitroso);
			int diffMesiTot = CalcoliPerLaGenerazione.differenzaInMesi(inizio1, fine2, out flagCalcoloARitroso);
			if (diffMesi1 * diffMesiTot == 0) {//ripartizione giornaliera
				int numGiorni1 = 1 + (fine1 - inizio1).Days;
				int numGiorniTot = 1 + (fine2 - inizio1).Days;
				decimal compenso1 = CfgFn.RoundValuta(numGiorni1 * compensoTot / numGiorniTot);
				return compenso1;
			} else {//ripartizione mensile
				decimal compenso1 = CfgFn.RoundValuta(diffMesi1 * compensoTot / diffMesiTot);
				return compenso1;
			}
		}

		/// <summary>
		/// Elimina il cedolino precedente e nel cedolino corrente viene posto:
		/// compenso = somma del compenso corrente + compenso del precedente
		/// dataInizio = data di inizio del cedolino precedente
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUnisciColPrecedente_Click(object sender, System.EventArgs e) {
			int riga = selectedRow;
			rGrid[riga]["datainizio"] = rGrid[riga-1]["datainizio"];
			rGrid[riga]["compenso"] = (decimal)rGrid[riga]["compenso"] + (decimal)rGrid[riga-1]["compenso"];
			rGrid[riga-1].Delete();
			rGrid = tGrid.Select(null, "datainizio");
			if (riga==1) {
				btnUnisciColPrecedente.Enabled = false;
			}
			aggiornaGroupBoxInfoCedolini(true);
		}

		/// <summary>
		/// Elimina il cedolino successivo e nel cedolino corrente viene posto:
		/// compenso = somma del compenso corrente + compenso del successivo
		/// dataFine = data di fine del cedolino successivo
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUnisciColSuccessivo_Click(object sender, System.EventArgs e) {
			int riga = selectedRow;
			rGrid[riga]["datafine"] = rGrid[riga+1]["datafine"];
			rGrid[riga]["compenso"] = (decimal)rGrid[riga]["compenso"] + (decimal)rGrid[riga+1]["compenso"];
			rGrid[riga+1].Delete();
			rGrid = tGrid.Select(null, "datainizio");
			if (riga==rGrid.Length-1) {
				btnUnisciColSuccessivo.Enabled = false;
			}
			aggiornaGroupBoxInfoCedolini(true);
		}

		/// <summary>
		/// Normalmente aggiunge un cedolino che ha:
		/// dataInizio = media tra data inizio e data fine del cedolino corrente;
		/// dataFine = data di fine del cedolino corrente;
		/// compenso = metà del compenso del cedolino corrente.
		/// Il cedolino corrente viene così modificato:
		/// dataFine = media tra data inizio e data fine del cedolino corrente - 1 giorno
		/// compenso = metà del compenso del cedolino corrente.
		/// Se la durata in mesi del cedolino di partenza non è un numero intero e pari
		/// allora la ripartizione avverrà in base giornaliera.
		/// Se la media tra data inizio e fine cedolino supera il 30 dicembre,
		/// allora verrà considerato il 30 dicembre come data fine del cedolino corrente
		/// e 31 dicembre come data inizio del nuovo cedolino.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDividiInDue_Click(object sender, System.EventArgs e) {
			int riga = selectedRow;
			DateTime inizio = (DateTime) rGrid[riga]["datainizio"];
			DateTime fine = (DateTime) rGrid[riga]["datafine"];
			decimal compenso = (decimal) rGrid[riga]["compenso"];
			bool flagCalcoloARitroso;
			int diffMesi = CalcoliPerLaGenerazione.differenzaInMesi(inizio, fine, out flagCalcoloARitroso);
			int mezzaDurata = diffMesi / 2;
			DateTime d;
			decimal compenso1;
			if ((diffMesi>0) && (mezzaDurata * 2 == diffMesi)) {
				compenso1 = CfgFn.RoundValuta(compenso/2);
				if (flagCalcoloARitroso) {
					d = fine.AddMonths(-mezzaDurata);
				} else {
					d = inizio.AddMonths(mezzaDurata).AddDays(-1);
				}
			} else {
				int numGiorni = 1 + (fine-inizio).Days;
				int numGiorni1 = numGiorni/2;
				compenso1 = CfgFn.RoundValuta(numGiorni1 * compenso / numGiorni);
				d = inizio.AddDays(numGiorni1-1);
			}
			DateTime dicembre30 = new DateTime(esercizio, 12, 30);
			if (d > dicembre30) {
				d = dicembre30;
				int numGiorni = 1 + (fine-inizio).Days;
				int numGiorni1 = 1 + (d - inizio).Days;
				compenso1 = CfgFn.RoundValuta(numGiorni1 * compenso / numGiorni);
			}
			rGrid[riga]["datafine"] = d;
			rGrid[riga]["compenso"] = compenso1;
			inserisciCedolino(riga+1, d.AddDays(1), fine, compenso - compenso1);
			rGrid = tGrid.Select(null, "datainizio");
			aggiornaGroupBoxInfoCedolini(true);
		}

		/// <summary>
		/// Inserisce in tGrid un cedolino alla riga specificata (shiftando tutti i cedolini successivi)
		/// </summary>
		/// <param name="indice">indice di riga in cui inserire il cedolino</param>
		/// <param name="dataInizio">data di inizio del nuovo cedolino</param>
		/// <param name="stop">data di fine del nuovo cedolino</param>
		/// <param name="compenso">compenso del nuovo cedolino</param>
		private void inserisciCedolino(int indice, DateTime dataInizio, 
			DateTime dataFine, decimal compenso) {
			if (indice == rGrid.Length) {
				tGrid.Rows.Add(new object[] {dataInizio, dataFine, compenso, DBNull.Value});
			} else {
				tGrid.Rows.Add(new object[] {
												rGrid[rGrid.Length-1]["datainizio"], 
												rGrid[rGrid.Length-1]["datafine"], 
												rGrid[rGrid.Length-1]["compenso"],
												DBNull.Value
											});
				for (int i=rGrid.Length-1; i>=indice+1; i--) {
					foreach (DataColumn c in tGrid.Columns) {
						rGrid[i][c] = rGrid[i-1][c];
					}
				}
				rGrid[indice]["datainizio"] = dataInizio;
				rGrid[indice]["datafine"] = dataFine;
				rGrid[indice]["compenso"] = compenso;
			}
		}

		/// <summary>
		/// A partire dalle date di inizio e fine dei cedolini del grid
		/// calcola i compensi di tali cedolini.
		/// Definiamo nMensili i cedolini che hanno durata multipla del mese.
		/// Definiamo giornalieri tutti gli altri cedolini.
		/// Definiamo nMesi la somma delle durate in mesi dei cedolini mensili.
		/// Definiamo nGiorni la somma delle durate in giorni dei cedolini giornalieri.
		/// Definiamo pagaGiornaliera = compenso / nGiorni
		/// Il compenso di ciascun cedolino giornaliero sarà posto uguale alla sua durata in giorni
		/// moltiplicato per la pagaGiornaliera.
		/// Definiamo sommaCedMens = compenso da erogare - somma dei compensi dei cedolini giornalieri
		/// Definiamo pagaMensile = sommaCedMens / nmesi
		/// Il compenso di ciascun cedolino mensile sarà posto uguale alla sua durata in mesi
		/// moltiplicato per la pagaMensile
		/// </summary>
		/// <param name="cambiaICompensiNelGrid"></param>
		private void calcolaICompensiEdITotaliAPartireDalleDateNelGrid(bool cambiaICompensiNelGrid) {
			//Inizio calcolo delle date di tutti i cedolini da erogare
			int numCedoliniDaErogareQuestAnno = rGrid.Length - primoCedolinoDaErogare;
		    if (numCedoliniDaErogareQuestAnno < 0) {
		        numCedoliniDaErogareQuestAnno = 0;
		    }

			DateTime dataInizioContratto = (DateTime) DS.Tables["parasubcontract"].Rows[0]["start"];
			DateTime dataFineContratto = (DateTime) DS.Tables["parasubcontract"].Rows[0]["stop"];
			decimal compensoContratto = (decimal) DS.Tables["parasubcontract"].Rows[0]["grossamount"];

            int index= numCedoliniDaErogareQuestAnno - 1 + primoCedolinoDaErogare;

			DateTime inizioAnnoFiscaleSuccessivo = 
                (index>=0 && index< rGrid.Length)? ((DateTime) rGrid[index]["datafine"]).AddDays(1):new DateTime(esercizio,1,1); 

			DateTime[] dateInizioCedoliniAnniSuccessivi, dateFineCedoliniAnniSuccessivi;
			CalcoliPerLaGenerazione.calcolaDateInizioEFineDeiCedolini(
				inizioAnnoFiscaleSuccessivo, 
				dataFineContratto, 1,
				out dateInizioCedoliniAnniSuccessivi, out dateFineCedoliniAnniSuccessivi);

			int numCedoliniDaErogare = numCedoliniDaErogareQuestAnno + dateInizioCedoliniAnniSuccessivi.Length;
		    if (numCedoliniDaErogare < 0) numCedoliniDaErogare = 0;

			DateTime[] dateInizioCedoliniDaErogare = new DateTime[numCedoliniDaErogare];
			DateTime[] dateFineCedoliniDaErogare = new DateTime[numCedoliniDaErogare];

			for (int i=0; i<numCedoliniDaErogareQuestAnno; i++) {
			    if (i  < dateInizioCedoliniDaErogare.Length) {
                    dateInizioCedoliniDaErogare[i] = (DateTime)rGrid[i + primoCedolinoDaErogare]["datainizio"];
                    dateFineCedoliniDaErogare[i] = (DateTime)rGrid[i + primoCedolinoDaErogare]["datafine"];
                }
            }

			dateInizioCedoliniAnniSuccessivi.CopyTo(dateInizioCedoliniDaErogare, numCedoliniDaErogareQuestAnno);
			dateFineCedoliniAnniSuccessivi.CopyTo(dateFineCedoliniDaErogare, numCedoliniDaErogareQuestAnno);
			//Fine calcolo delle date di tutti i cedolini da erogare

			decimal sommaRateDiQuestAnno;
			decimal sommaRateRimanentiContratto;
			
			Cedolino[] cedolini = CalcoliPerLaGenerazione.calcolaStipendiDiQuestAnno(
				esercizio,
				rCedoliniErogati, compensoContratto,
				dateInizioCedoliniDaErogare, dateFineCedoliniDaErogare,
				out sommaRateDiQuestAnno, out sommaRateRimanentiContratto);

			arrotondaCompensiCedolini(cedolini);
			decimal totaleCedolini = sommaRateDiQuestAnno;
			if (cambiaICompensiNelGrid) {
				for (int i=primoCedolinoDaErogare; i<rGrid.Length; i++) {
				    if (i  < cedolini.Length) {
				        rGrid[i]["compenso"] = cedolini[i].compenso;
				    }
				}
			} else {
				totaleCedolini = 0;
				foreach (DataRow r in rGrid) {
					totaleCedolini += (decimal) r["compenso"];
				}
			}

			txtCompensoAnnuale.Text = sommaRateDiQuestAnno.ToString("c");
			txtRimanenteContratto.Text = sommaRateRimanentiContratto.ToString("c");
			txtTotaleCedolini.Text = totaleCedolini.ToString("c");
			if (cambiaICompensiNelGrid){
				aggiornaGroupBoxInfoCedolini(true);
			}
		}

		private void btnRicalcolaCompensi_Click(object sender, System.EventArgs e) {
            if (rGrid.Length == 0)
                return;
			calcolaICompensiEdITotaliAPartireDalleDateNelGrid(true);
		}

		private object leggiData(TextBox txt, DateTime vecchiaData) {
			DateTime dtpMinDate = (txt == txtDataInizio) ? dtpInizioMinDate : dtpFineMinDate;
			DateTime dtpMaxDate = (txt == txtDataInizio) ? dtpInizioMaxDate : dtpFineMaxDate;
			string nome = (txt == txtDataInizio) ? "inizio" : "fine";
			string messaggio = null;
			object o = HelpForm.GetObjectFromString(typeof(DateTime), txt.Text, "x.y");

			if (o == null) {
				messaggio = "La data di "+nome+ " inserita non è valida.";
			}

			if (o == DBNull.Value) {
				messaggio = "La data di "+nome+" è obbligatoria e non è possibile cancellarla.";
				o = null;
			}

			if (o != null) {
				DateTime d = (DateTime) o;
				if ((d < dtpMinDate) || (d > dtpMaxDate)) {
					messaggio = "La data di "+nome+" deve essere compresa tra "
						+ HelpForm.StringValue(dtpMinDate, "x.y")
						+ " e "
						+ HelpForm.StringValue(dtpMaxDate, "x.y")
						+ ".";
					o = null;
				}
			}

			if (o == null) {
				string valorePrecedente = HelpForm.StringValue(vecchiaData, "x.y");
				MessageBox.Show(this, messaggio						
					+ "\nVerrà ripristinato il valore precedente."
					+ "\n\nData inserita: "+txt.Text
					+ "\nValore precedente: " + valorePrecedente, "Data di "+nome+" non valida");
				txt.Text = valorePrecedente;
				txt.Focus();
			}
			return o;
		}

		private void txtDataInizio_Leave(object sender, System.EventArgs e) {
			int riga = selectedRow;
			if (riga == -1) {
				return;
			}
			DateTime vecchiaDataInizio = (DateTime) rGrid[riga]["datainizio"];
			object nuovaDataInizio = leggiData(txtDataInizio, vecchiaDataInizio);		
			if (nuovaDataInizio != null) {
				cambiaDataInizio(riga, (DateTime)nuovaDataInizio);
			}
		}

		private void txtDataFine_Leave(object sender, System.EventArgs e) {
			int riga = selectedRow;
			if (riga == -1) {
				return;
			}
			DateTime vecchiaDataFine = (DateTime) rGrid[riga]["datafine"];
			object nuovaDataFine = leggiData(txtDataFine, vecchiaDataFine);
			if (nuovaDataFine != null) {
				cambiaDataFine(riga, (DateTime)nuovaDataFine);
			}
		}
	}
}