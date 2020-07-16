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
using Xceed.Grid;
using System.Data;
using funzioni_configurazione;
using metadatalibrary;

namespace finbalance_default//bilancioassestamento//
{
	/// <summary>
	/// Summary description for FrmBilancioAssestamento.
	/// </summary>
	public class Frm_finbalance_default : System.Windows.Forms.Form
	{
		public vistaForm DS;
		public tempds DS2;
		DataTable MyBilancio;
		MetaData Meta;
		DataAccess Conn;
		string campoprevcompetenza;
		string campoprevcassa;
        bool SolaCassa = false;
        bool AbilitaColonneCassa = true;
		bool AbilitaColonneCompetenza=true;
		string eseguiForm;
		object  codicelivellooperativo;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnRicalcola;
		private System.Windows.Forms.Button btnExcel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabAssestamento;
		private System.Windows.Forms.TabPage tabTotali;
		private System.Windows.Forms.Button btnSalvaDatiPrevisione;
		private Xceed.Grid.GridControl gridControl1;
		private Xceed.Grid.GroupByRow groupByRow1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private Xceed.Grid.DataRow dataRowTemplate1;
		private System.Windows.Forms.TextBox txtAvanzoAmministrazioneEff;
		private System.Windows.Forms.TextBox txtAvanzoCassaEff;
		private System.Windows.Forms.TextBox txtDotazioneCreditiPres;
		private System.Windows.Forms.TextBox txtDotazioneCassaPres;
		private System.Windows.Forms.Label lblAvanzoAmministrazioneEff;
		private System.Windows.Forms.Label lblDotazioneCassaPres;
		private System.Windows.Forms.Label lblDotazioneCreditiPres;
		private System.Windows.Forms.Label lblAvanzoCassaEff;
		private System.Windows.Forms.TextBox txtVarResAttivi;
	        private System.Windows.Forms.Label lblVarResAttivi;
		decimal avanzoCassaEff;
		decimal avanzoAmministrazioneEff;
		decimal dotazioneCreditiPres;
		decimal dotazioneCassaPres;
		decimal totResiduiAttivi;
		decimal totResiduiPassivi;
		decimal totVarAssPrevPrinc;
		decimal totVarAssPrevSec;
		decimal totVarAssPrevPrinc_E;
		decimal totVarAssPrevSec_E;
		decimal totVarDotCassa;
		decimal totVarDotCrediti;
		decimal totSuppAvailPrev_S;
		decimal totSuppAvailPrev_E;
		decimal totActAvailPrev_S;
		decimal totActAvailPrev_E;
        decimal totVarResiduiAttivi;

		private System.Windows.Forms.Label lblResiduiAttivi;
		private System.Windows.Forms.Label lblResiduiPassivi;
		private System.Windows.Forms.TextBox txtResiduiAttivi;
		private System.Windows.Forms.TextBox txtResiduiPassivi;
		private System.Windows.Forms.TextBox txtVarAssestamentoPrevPrinc;
		private System.Windows.Forms.TextBox txtVarAssestamentoPrevSec;
		private System.Windows.Forms.TextBox txtVarAssestamentoDotCassa;
		private System.Windows.Forms.TextBox txtVarAssestamentoDotCrediti;
		private System.Windows.Forms.Label lblVarAssestamentoPrevPrinc;
		private System.Windows.Forms.Label lblVarAssestamentoPrevSec;
		private System.Windows.Forms.Label lblVarAssestamentoDotCassa;
		private System.Windows.Forms.Label lblVarAssestamentoDotCrediti;
		private Xceed.Grid.DataBoundColumn colcu;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1cu;
		private Xceed.Grid.DataCell celldataRowTemplate1cu;
		private Xceed.Grid.DataBoundColumn colct;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1ct;
		private Xceed.Grid.DataCell celldataRowTemplate1ct;
		private Xceed.Grid.DataBoundColumn collu;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1lu;
		private Xceed.Grid.DataCell celldataRowTemplate1lu;
		private Xceed.Grid.DataBoundColumn collt;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1lt;
		private Xceed.Grid.DataCell celldataRowTemplate1lt;
		private Xceed.Grid.DataBoundColumn colidbilancio;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1idfin;
		private Xceed.Grid.DataCell celldataRowTemplate1idfin;
		private Xceed.Grid.DataBoundColumn colcodicebilancio;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1codefin;
		private Xceed.Grid.DataCell celldataRowTemplate1codefin;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1title;
		private Xceed.Grid.DataCell celldataRowTemplate1title;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedcash;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedcash;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedcredits;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedcredits;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1revenue;
		private Xceed.Grid.DataCell celldataRowTemplate1revenue;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1expenditure;
		private Xceed.Grid.DataCell celldataRowTemplate1expenditure;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1actualcashsurplus;
		private Xceed.Grid.DataCell celldataRowTemplate1actualcashsurplus;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1actualcreditsurplus;
		private Xceed.Grid.DataCell celldataRowTemplate1actualcreditsurplus;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1previsionvariation;
		private Xceed.Grid.DataCell celldataRowTemplate1previsionvariation;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1secondaryprevvariation;
		private Xceed.Grid.DataCell celldataRowTemplate1secondaryprevvariation;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1creditvariation;
		private Xceed.Grid.DataCell celldataRowTemplate1creditvariation;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1cashvariation;
		private Xceed.Grid.DataCell celldataRowTemplate1cashvariation;

        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1revenuevariation;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2revenuevariation;

		private Xceed.Grid.DataBoundColumn coldenominazione;
		private Xceed.Grid.DataBoundColumn coldotazionecassapresunta;
		private Xceed.Grid.DataBoundColumn coldotazionecreditipresunta;
		private Xceed.Grid.DataBoundColumn colresiduiattivi;
		private Xceed.Grid.DataBoundColumn colresiduipassivi;
        private Xceed.Grid.DataBoundColumn colcassaassegnato;
        private Xceed.Grid.DataBoundColumn colassignedcash;
        private Xceed.Grid.DataBoundColumn colpagamenti;
        private Xceed.Grid.DataBoundColumn colpayment;
        private Xceed.Grid.DataBoundColumn colincassi;
        private Xceed.Grid.DataBoundColumn colproceeds;
        private Xceed.Grid.DataBoundColumn colactualprev;
        private Xceed.Grid.DataBoundColumn colactualprev1;
		private Xceed.Grid.DataBoundColumn colavanzocassaeffettivo;
		private Xceed.Grid.DataBoundColumn colavanzoamministrazioneeffettivo;
		private Xceed.Grid.DataBoundColumn colvarprevisioneprincipale;
		private Xceed.Grid.DataBoundColumn colvarprevisionesecondaria;
		private Xceed.Grid.DataBoundColumn colvardotazionecrediti;
		private Xceed.Grid.DataBoundColumn colvardotazionecassa;
        private Xceed.Grid.DataBoundColumn colvarresiduiattivi;
		private System.Windows.Forms.TabPage tabEntrata;
		private Xceed.Grid.GridControl gridControl2;
		private Xceed.Grid.DataRow dataRow1;
		private Xceed.Grid.DataCell dataCell2;
		private Xceed.Grid.DataCell dataCell3;
		private Xceed.Grid.DataCell dataCell4;
		private Xceed.Grid.DataCell dataCell5;
		private Xceed.Grid.DataCell dataCell7;
		private Xceed.Grid.DataCell dataCell8;
		private Xceed.Grid.DataCell dataCell9;
		private Xceed.Grid.DataCell dataCell10;
		private Xceed.Grid.DataCell dataCell11;
		private Xceed.Grid.DataCell dataCell12;
		private Xceed.Grid.DataCell dataCell13;
		private Xceed.Grid.DataCell dataCell14;
		private Xceed.Grid.DataCell dataCell15;
		private Xceed.Grid.DataCell dataCell16;
		private Xceed.Grid.DataCell dataCell17;
		private Xceed.Grid.DataCell dataCell18;
		private Xceed.Grid.DataCell dataCell19;
		private Xceed.Grid.GroupByRow groupByRow2;
		private Xceed.Grid.ColumnManagerRow columnManagerRow2;
		private Xceed.Grid.ColumnManagerCell columnManagerCell2;
		private Xceed.Grid.ColumnManagerCell columnManagerCell3;
		private Xceed.Grid.ColumnManagerCell columnManagerCell4;
		private Xceed.Grid.ColumnManagerCell columnManagerCell5;
		private Xceed.Grid.ColumnManagerCell columnManagerCell7;
		private Xceed.Grid.ColumnManagerCell columnManagerCell8;
		private Xceed.Grid.ColumnManagerCell columnManagerCell9;
		private Xceed.Grid.ColumnManagerCell columnManagerCell10;
		private Xceed.Grid.ColumnManagerCell columnManagerCell11;
		private Xceed.Grid.ColumnManagerCell columnManagerCell12;
		private Xceed.Grid.ColumnManagerCell columnManagerCell13;
		private Xceed.Grid.ColumnManagerCell columnManagerCell14;
		private Xceed.Grid.ColumnManagerCell columnManagerCell15;
		private Xceed.Grid.ColumnManagerCell columnManagerCell16;
		private Xceed.Grid.ColumnManagerCell columnManagerCell17;
		private Xceed.Grid.ColumnManagerCell columnManagerCell18;
		private Xceed.Grid.ColumnManagerCell columnManagerCell19;
		private finbalance_default.tempds DS3;
		private Xceed.Grid.DataBoundColumn colsupposedrevenue;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedrevenue;
		private Xceed.Grid.DataBoundColumn colsupposedexpenditure;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedexpenditure;
		private Xceed.Grid.DataBoundColumn colsupposedavailableprev;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedavailableprev;
		private Xceed.Grid.DataBoundColumn colactualavailableprev;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2actualavailableprev;
		private Xceed.Grid.DataBoundColumn colsupposedrevenue1;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedrevenue;
		private Xceed.Grid.DataBoundColumn colsupposedexpenditure1;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedexpenditure;
		private Xceed.Grid.DataBoundColumn colsupposedavailableprev1;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedavailableprev;
		private Xceed.Grid.DataBoundColumn colactualavailableprev1;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1actualavailableprev;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1payment;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1assignedcash;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1actualprev;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1proceeds;

        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2payment;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2assignedcash;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2proceeds;
        private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2actualprev;

		private Xceed.Grid.DataCell celldataRowTemplate1supposedrevenue;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedexpenditure;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedavailableprev;
		private Xceed.Grid.DataCell celldataRowTemplate1actualavailableprev;
		private Xceed.Grid.DataCell celldataRow1supposedrevenue;
		private Xceed.Grid.DataCell celldataRow1supposedexpenditure;
		private Xceed.Grid.DataCell celldataRow1supposedavailableprev;
		private Xceed.Grid.DataCell celldataRow1actualavailableprev;
        private Xceed.Grid.DataCell celldataRowTemplate1payment;
        private Xceed.Grid.DataCell celldataRowTemplate1assignedcash;
        private Xceed.Grid.DataCell celldataRowTemplate1actualprev;
        private Xceed.Grid.DataCell celldataRowTemplate1proceeds;
        private Xceed.Grid.DataCell celldataRow2payment;
        private Xceed.Grid.DataCell celldataRow2assignedcash;
        private Xceed.Grid.DataCell celldataRow2proceeds;
        private Xceed.Grid.DataCell celldataRow2actualprev;

        private Xceed.Grid.DataCell celldataRowTemplate1revenuevariation;
        private Xceed.Grid.DataCell celldataRow2revenuevariation;

		private System.Windows.Forms.CheckBox chkConsolida;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cmbUpb;

		//bool CurrAssured=false;
		object curridupb=DBNull.Value;
		bool DoConsolida=false;

		string tipoprincipale;
		string tiposecondaria;
		private System.Windows.Forms.TextBox txtResiduiPassiviPresunti;
		private System.Windows.Forms.TextBox txtResiduiAttiviPresunti;
		private System.Windows.Forms.Label lblResiduiPassiviPresunti;
		private System.Windows.Forms.Label lblResiduiAttiviPresunti;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.TextBox txtVarAssestamentoPrevPrincEntrata;
		private System.Windows.Forms.TextBox txtVarAssestamentoPrevSecEntrata;
		private System.Windows.Forms.Label lblVarAssestamentoPrevSec_E;
		private System.Windows.Forms.Label lblVarAssestamentoPrevPrinc_E;
		private System.Windows.Forms.Label labSupposedPrevDisp_S;
		private System.Windows.Forms.TextBox txtSupposedPrevDisp_S;
		private System.Windows.Forms.TextBox txtActualPrevDisp_S;
		private System.Windows.Forms.Label labActualPrevDisp_S;
		private System.Windows.Forms.TextBox txtActualPrevDisp_E;
		private System.Windows.Forms.Label labActualPrevDisp_E;
		private System.Windows.Forms.TextBox txtSupposedPrevDisp_E;
		private System.Windows.Forms.Label labSupposedPrevDisp_E;
		private Xceed.Grid.DataBoundColumn colcu1;
		private Xceed.Grid.DataBoundColumn colct1;
		private Xceed.Grid.DataBoundColumn collu1;
		private Xceed.Grid.DataBoundColumn collt1;
		private Xceed.Grid.DataBoundColumn colidfin;
		private Xceed.Grid.DataBoundColumn colcodefin;
		private Xceed.Grid.DataBoundColumn coltitle;
		private Xceed.Grid.DataBoundColumn colsupposedcash;
		private Xceed.Grid.DataBoundColumn colsupposedcredits;
		private Xceed.Grid.DataBoundColumn colrevenue;
		private Xceed.Grid.DataBoundColumn colexpenditure;
		private Xceed.Grid.DataBoundColumn colactualcashsurplus;
		private Xceed.Grid.DataBoundColumn colactualcreditsurplus;
		private Xceed.Grid.DataBoundColumn colprevisionvariation;
		private Xceed.Grid.DataBoundColumn colsecondaryprevvariation;
		private Xceed.Grid.DataBoundColumn colcreditvariation;
		private Xceed.Grid.DataBoundColumn colcashvariation;
        private Xceed.Grid.DataBoundColumn colrevenuevariation;

        bool assestapresunto = true;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
            this.DS = new finbalance_default.vistaForm();
            this.DS2 = new finbalance_default.tempds();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEsercizio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnRicalcola = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabAssestamento = new System.Windows.Forms.TabPage();
            this.gridControl1 = new Xceed.Grid.GridControl();
            this.colcu = new Xceed.Grid.DataBoundColumn();
            this.colct = new Xceed.Grid.DataBoundColumn();
            this.collu = new Xceed.Grid.DataBoundColumn();
            this.collt = new Xceed.Grid.DataBoundColumn();
            this.colidbilancio = new Xceed.Grid.DataBoundColumn();
            this.colcodicebilancio = new Xceed.Grid.DataBoundColumn();
            this.coldenominazione = new Xceed.Grid.DataBoundColumn();
            this.coldotazionecassapresunta = new Xceed.Grid.DataBoundColumn();
            this.coldotazionecreditipresunta = new Xceed.Grid.DataBoundColumn();
            this.colresiduiattivi = new Xceed.Grid.DataBoundColumn();
            this.colresiduipassivi = new Xceed.Grid.DataBoundColumn();
            this.colcassaassegnato = new Xceed.Grid.DataBoundColumn();
            this.colproceeds = new Xceed.Grid.DataBoundColumn();
            this.colpagamenti = new Xceed.Grid.DataBoundColumn();
            this.colactualprev = new Xceed.Grid.DataBoundColumn();
            this.colavanzocassaeffettivo = new Xceed.Grid.DataBoundColumn();
            this.colavanzoamministrazioneeffettivo = new Xceed.Grid.DataBoundColumn();
            this.colvarprevisioneprincipale = new Xceed.Grid.DataBoundColumn();
            this.colvarprevisionesecondaria = new Xceed.Grid.DataBoundColumn();
            this.colvardotazionecrediti = new Xceed.Grid.DataBoundColumn();
            this.colvardotazionecassa = new Xceed.Grid.DataBoundColumn();
            this.colsupposedrevenue1 = new Xceed.Grid.DataBoundColumn();
            this.colsupposedexpenditure1 = new Xceed.Grid.DataBoundColumn();
            this.colsupposedavailableprev1 = new Xceed.Grid.DataBoundColumn();
            this.colactualavailableprev1 = new Xceed.Grid.DataBoundColumn();
            this.colvarresiduiattivi = new Xceed.Grid.DataBoundColumn();
            this.colrevenuevariation = new Xceed.Grid.DataBoundColumn();
            this.dataRowTemplate1 = new Xceed.Grid.DataRow();
            this.celldataRowTemplate1cu = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1ct = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1lu = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1lt = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1idfin = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1codefin = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1title = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedcash = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedcredits = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1revenue = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1expenditure = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1actualcashsurplus = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1actualcreditsurplus = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1previsionvariation = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1secondaryprevvariation = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1creditvariation = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1cashvariation = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedrevenue = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedexpenditure = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedavailableprev = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1actualavailableprev = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1payment = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1assignedcash = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1actualprev = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1proceeds = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1revenuevariation = new Xceed.Grid.DataCell();
            this.groupByRow1 = new Xceed.Grid.GroupByRow();
            this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
            this.cellcolumnManagerRow1cu = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1ct = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1lu = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1lt = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1idfin = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1codefin = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1title = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedcash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedcredits = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1revenue = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1expenditure = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1actualcashsurplus = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1actualcreditsurplus = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1previsionvariation = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1secondaryprevvariation = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1creditvariation = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1cashvariation = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedrevenue = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedexpenditure = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedavailableprev = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1actualavailableprev = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1payment = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1assignedcash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1actualprev = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1proceeds = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2payment = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2assignedcash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2proceeds = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2actualprev = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1revenuevariation = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2revenuevariation = new Xceed.Grid.ColumnManagerCell();
            this.tabEntrata = new System.Windows.Forms.TabPage();
            this.gridControl2 = new Xceed.Grid.GridControl();
            this.colcu1 = new Xceed.Grid.DataBoundColumn();
            this.colct1 = new Xceed.Grid.DataBoundColumn();
            this.collu1 = new Xceed.Grid.DataBoundColumn();
            this.collt1 = new Xceed.Grid.DataBoundColumn();
            this.colidfin = new Xceed.Grid.DataBoundColumn();
            this.colcodefin = new Xceed.Grid.DataBoundColumn();
            this.coltitle = new Xceed.Grid.DataBoundColumn();
            this.colsupposedcash = new Xceed.Grid.DataBoundColumn();
            this.colsupposedcredits = new Xceed.Grid.DataBoundColumn();
            this.colrevenue = new Xceed.Grid.DataBoundColumn();
            this.colassignedcash = new Xceed.Grid.DataBoundColumn();
            this.colpayment = new Xceed.Grid.DataBoundColumn();
            this.colincassi = new Xceed.Grid.DataBoundColumn();
            this.colexpenditure = new Xceed.Grid.DataBoundColumn();
            this.colactualcashsurplus = new Xceed.Grid.DataBoundColumn();
            this.colactualcreditsurplus = new Xceed.Grid.DataBoundColumn();
            this.colprevisionvariation = new Xceed.Grid.DataBoundColumn();
            this.colsecondaryprevvariation = new Xceed.Grid.DataBoundColumn();
            this.colcreditvariation = new Xceed.Grid.DataBoundColumn();
            this.colcashvariation = new Xceed.Grid.DataBoundColumn();
            this.colsupposedrevenue = new Xceed.Grid.DataBoundColumn();
            this.colsupposedexpenditure = new Xceed.Grid.DataBoundColumn();
            this.colsupposedavailableprev = new Xceed.Grid.DataBoundColumn();
            this.colactualavailableprev = new Xceed.Grid.DataBoundColumn();
            this.colactualprev1 = new Xceed.Grid.DataBoundColumn();
            this.dataRow1 = new Xceed.Grid.DataRow();
            this.dataCell2 = new Xceed.Grid.DataCell();
            this.dataCell3 = new Xceed.Grid.DataCell();
            this.dataCell4 = new Xceed.Grid.DataCell();
            this.dataCell5 = new Xceed.Grid.DataCell();
            this.dataCell7 = new Xceed.Grid.DataCell();
            this.dataCell8 = new Xceed.Grid.DataCell();
            this.dataCell9 = new Xceed.Grid.DataCell();
            this.dataCell10 = new Xceed.Grid.DataCell();
            this.dataCell11 = new Xceed.Grid.DataCell();
            this.dataCell12 = new Xceed.Grid.DataCell();
            this.dataCell13 = new Xceed.Grid.DataCell();
            this.dataCell14 = new Xceed.Grid.DataCell();
            this.dataCell15 = new Xceed.Grid.DataCell();
            this.dataCell16 = new Xceed.Grid.DataCell();
            this.dataCell17 = new Xceed.Grid.DataCell();
            this.dataCell18 = new Xceed.Grid.DataCell();
            this.dataCell19 = new Xceed.Grid.DataCell();
            this.celldataRow1supposedrevenue = new Xceed.Grid.DataCell();
            this.celldataRow1supposedexpenditure = new Xceed.Grid.DataCell();
            this.celldataRow1supposedavailableprev = new Xceed.Grid.DataCell();
            this.celldataRow1actualavailableprev = new Xceed.Grid.DataCell();
            this.celldataRow2payment = new Xceed.Grid.DataCell();
            this.celldataRow2assignedcash = new Xceed.Grid.DataCell();
            this.celldataRow2proceeds = new Xceed.Grid.DataCell();
            this.celldataRow2actualprev = new Xceed.Grid.DataCell();
            this.celldataRow2revenuevariation = new Xceed.Grid.DataCell();
            this.DS3 = new finbalance_default.tempds();
            this.groupByRow2 = new Xceed.Grid.GroupByRow();
            this.columnManagerRow2 = new Xceed.Grid.ColumnManagerRow();
            this.columnManagerCell2 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell3 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell4 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell5 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell7 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell8 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell9 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell10 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell11 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell12 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell13 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell14 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell15 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell16 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell17 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell18 = new Xceed.Grid.ColumnManagerCell();
            this.columnManagerCell19 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedrevenue = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedexpenditure = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedavailableprev = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2actualavailableprev = new Xceed.Grid.ColumnManagerCell();
            this.tabTotali = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtActualPrevDisp_E = new System.Windows.Forms.TextBox();
            this.labActualPrevDisp_E = new System.Windows.Forms.Label();
            this.txtSupposedPrevDisp_E = new System.Windows.Forms.TextBox();
            this.labSupposedPrevDisp_E = new System.Windows.Forms.Label();
            this.txtVarAssestamentoPrevPrincEntrata = new System.Windows.Forms.TextBox();
            this.txtVarAssestamentoPrevSecEntrata = new System.Windows.Forms.TextBox();
            this.lblVarAssestamentoPrevSec_E = new System.Windows.Forms.Label();
            this.lblVarAssestamentoPrevPrinc_E = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtActualPrevDisp_S = new System.Windows.Forms.TextBox();
            this.labActualPrevDisp_S = new System.Windows.Forms.Label();
            this.txtSupposedPrevDisp_S = new System.Windows.Forms.TextBox();
            this.txtVarAssestamentoPrevPrinc = new System.Windows.Forms.TextBox();
            this.txtVarAssestamentoDotCassa = new System.Windows.Forms.TextBox();
            this.txtVarAssestamentoPrevSec = new System.Windows.Forms.TextBox();
            this.lblVarAssestamentoPrevSec = new System.Windows.Forms.Label();
            this.lblVarAssestamentoDotCrediti = new System.Windows.Forms.Label();
            this.lblVarAssestamentoDotCassa = new System.Windows.Forms.Label();
            this.lblVarAssestamentoPrevPrinc = new System.Windows.Forms.Label();
            this.txtVarAssestamentoDotCrediti = new System.Windows.Forms.TextBox();
            this.labSupposedPrevDisp_S = new System.Windows.Forms.Label();
            this.txtResiduiPassiviPresunti = new System.Windows.Forms.TextBox();
            this.txtResiduiAttiviPresunti = new System.Windows.Forms.TextBox();
            this.lblResiduiPassiviPresunti = new System.Windows.Forms.Label();
            this.lblResiduiAttiviPresunti = new System.Windows.Forms.Label();
            this.txtResiduiPassivi = new System.Windows.Forms.TextBox();
            this.txtResiduiAttivi = new System.Windows.Forms.TextBox();
            this.lblResiduiPassivi = new System.Windows.Forms.Label();
            this.lblResiduiAttivi = new System.Windows.Forms.Label();
            this.lblAvanzoAmministrazioneEff = new System.Windows.Forms.Label();
            this.lblDotazioneCassaPres = new System.Windows.Forms.Label();
            this.txtDotazioneCreditiPres = new System.Windows.Forms.TextBox();
            this.txtAvanzoAmministrazioneEff = new System.Windows.Forms.TextBox();
            this.txtDotazioneCassaPres = new System.Windows.Forms.TextBox();
            this.lblDotazioneCreditiPres = new System.Windows.Forms.Label();
            this.lblAvanzoCassaEff = new System.Windows.Forms.Label();
            this.txtAvanzoCassaEff = new System.Windows.Forms.TextBox();
            this.btnSalvaDatiPrevisione = new System.Windows.Forms.Button();
            this.chkConsolida = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbUpb = new System.Windows.Forms.ComboBox();
	    this.groupBox3 = new System.Windows.Forms.GroupBox();
	    this.txtVarResAttivi = new System.Windows.Forms.TextBox();
            this.lblVarResAttivi = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabAssestamento.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
            this.tabEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRow1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).BeginInit();
            this.tabTotali.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // DS2
            // 
            this.DS2.DataSetName = "tempds";
            this.DS2.EnforceConstraints = false;
            this.DS2.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Esercizio:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEsercizio
            // 
            this.txtEsercizio.Location = new System.Drawing.Point(64, 8);
            this.txtEsercizio.Name = "txtEsercizio";
            this.txtEsercizio.ReadOnly = true;
            this.txtEsercizio.Size = new System.Drawing.Size(72, 20);
            this.txtEsercizio.TabIndex = 1;
            this.txtEsercizio.Tag = "finbalance.ayear.year";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(144, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(200, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(48, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "finbalance.nfinbalance";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(256, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Assestamento:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(368, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(88, 20);
            this.textBox2.TabIndex = 5;
            this.textBox2.Tag = "finbalance.balancedate";
            // 
            // btnRicalcola
            // 
            this.btnRicalcola.Location = new System.Drawing.Point(464, 8);
            this.btnRicalcola.Name = "btnRicalcola";
            this.btnRicalcola.Size = new System.Drawing.Size(75, 23);
            this.btnRicalcola.TabIndex = 6;
            this.btnRicalcola.Text = "Ricalcola";
            this.btnRicalcola.Click += new System.EventHandler(this.btnRicalcola_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(560, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 7;
            this.btnExcel.Text = "Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabAssestamento);
            this.tabControl1.Controls.Add(this.tabEntrata);
            this.tabControl1.Controls.Add(this.tabTotali);
            this.tabControl1.Location = new System.Drawing.Point(8, 64);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(640, 390);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabAssestamento
            // 
            this.tabAssestamento.Controls.Add(this.gridControl1);
            this.tabAssestamento.Location = new System.Drawing.Point(4, 22);
            this.tabAssestamento.Name = "tabAssestamento";
            this.tabAssestamento.Size = new System.Drawing.Size(632, 326);
            this.tabAssestamento.TabIndex = 0;
            this.tabAssestamento.Text = "Assestamento Spese";
            this.tabAssestamento.UseVisualStyleBackColor = true;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Columns.Add(this.colcu);
            this.gridControl1.Columns.Add(this.colct);
            this.gridControl1.Columns.Add(this.collu);
            this.gridControl1.Columns.Add(this.collt);
            this.gridControl1.Columns.Add(this.colidbilancio);
            this.gridControl1.Columns.Add(this.colcodicebilancio);
            this.gridControl1.Columns.Add(this.coldenominazione);
            this.gridControl1.Columns.Add(this.coldotazionecassapresunta);
            this.gridControl1.Columns.Add(this.coldotazionecreditipresunta);
            this.gridControl1.Columns.Add(this.colresiduiattivi);
            this.gridControl1.Columns.Add(this.colresiduipassivi);
            this.gridControl1.Columns.Add(this.colcassaassegnato);
            this.gridControl1.Columns.Add(this.colpagamenti);
            this.gridControl1.Columns.Add(this.colproceeds);
            this.gridControl1.Columns.Add(this.colactualprev);
            this.gridControl1.Columns.Add(this.colavanzocassaeffettivo);
            this.gridControl1.Columns.Add(this.colavanzoamministrazioneeffettivo);
            this.gridControl1.Columns.Add(this.colvarprevisioneprincipale);
            this.gridControl1.Columns.Add(this.colvarprevisionesecondaria);
            this.gridControl1.Columns.Add(this.colvardotazionecrediti);
            this.gridControl1.Columns.Add(this.colvardotazionecassa);
            this.gridControl1.Columns.Add(this.colvarresiduiattivi);
            this.gridControl1.Columns.Add(this.colsupposedrevenue1);
            this.gridControl1.Columns.Add(this.colsupposedexpenditure1);
            this.gridControl1.Columns.Add(this.colsupposedavailableprev1);
            this.gridControl1.Columns.Add(this.colactualavailableprev1);
            this.gridControl1.DataRowTemplate = this.dataRowTemplate1;
            this.gridControl1.DataSource = this.DS2.finbalancedetail;
            this.gridControl1.FixedHeaderRows.Add(this.groupByRow1);
            this.gridControl1.FixedHeaderRows.Add(this.columnManagerRow1);
            this.gridControl1.Location = new System.Drawing.Point(8, 8);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(616, 312);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.FirstVisibleColumnChanged += new System.EventHandler(this.gridControl1_FirstVisibleColumnChanged);
            // 
            // colcu
            // 
            this.colcu.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcu.Title = "cu";
            this.colcu.VisibleIndex = 15;
            this.colcu.Initialize("cu");
            // 
            // colct
            // 
            this.colct.SortDirection = Xceed.Grid.SortDirection.None;
            this.colct.Title = "ct";
            this.colct.VisibleIndex = 16;
            this.colct.Initialize("ct");
            // 
            // collu
            // 
            this.collu.SortDirection = Xceed.Grid.SortDirection.None;
            this.collu.Title = "lu";
            this.collu.VisibleIndex = 17;
            this.collu.Initialize("lu");
            // 
            // collt
            // 
            this.collt.SortDirection = Xceed.Grid.SortDirection.None;
            this.collt.Title = "lt";
            this.collt.VisibleIndex = 18;
            this.collt.Initialize("lt");
            // 
            // colidbilancio
            // 
            this.colidbilancio.SortDirection = Xceed.Grid.SortDirection.None;
            this.colidbilancio.Title = "idfin";
            this.colidbilancio.VisibleIndex = 0;
            this.colidbilancio.Initialize("idfin");
            // 
            // colcodicebilancio
            // 
            this.colcodicebilancio.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcodicebilancio.Title = "codefin";
            this.colcodicebilancio.VisibleIndex = 1;
            this.colcodicebilancio.Initialize("codefin");
            // 
            // coldenominazione
            // 
            this.coldenominazione.SortDirection = Xceed.Grid.SortDirection.None;
            this.coldenominazione.Title = "title";
            this.coldenominazione.VisibleIndex = 2;
            this.coldenominazione.Initialize("title");
            // 
            // coldotazionecassapresunta
            // 
            this.coldotazionecassapresunta.SortDirection = Xceed.Grid.SortDirection.None;
            this.coldotazionecassapresunta.Title = "supposedcash";
            this.coldotazionecassapresunta.VisibleIndex = 3;
            this.coldotazionecassapresunta.Initialize("supposedcash");
            // 
            // coldotazionecreditipresunta
            // 
            this.coldotazionecreditipresunta.SortDirection = Xceed.Grid.SortDirection.None;
            this.coldotazionecreditipresunta.Title = "supposedcredits";
            this.coldotazionecreditipresunta.VisibleIndex = 4;
            this.coldotazionecreditipresunta.Initialize("supposedcredits");
            // 
            // colresiduiattivi
            // 
            this.colresiduiattivi.SortDirection = Xceed.Grid.SortDirection.None;
            this.colresiduiattivi.Title = "revenue";
            this.colresiduiattivi.VisibleIndex = 6;
            this.colresiduiattivi.Initialize("revenue");
            // 
            // colresiduipassivi
            // 
            this.colresiduipassivi.SortDirection = Xceed.Grid.SortDirection.None;
            this.colresiduipassivi.Title = "expenditure";
            this.colresiduipassivi.VisibleIndex = 8;
            this.colresiduipassivi.Initialize("expenditure");
            // 
            // colcassaassegnato
            // 
            this.colcassaassegnato.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcassaassegnato.Title = "assignedcash";
            this.colcassaassegnato.VisibleIndex = 10;
            this.colcassaassegnato.Initialize("assignedcash");
            // 
            // colpagamenti
            // 
            this.colpagamenti.SortDirection = Xceed.Grid.SortDirection.None;
            this.colpagamenti.Title = "payment";
            this.colpagamenti.VisibleIndex = 11;
            this.colpagamenti.Initialize("payment");
            // 
            // colproceeds
            // 
            this.colproceeds.SortDirection = Xceed.Grid.SortDirection.None;
            this.colproceeds.Title = "proceeds";
            this.colproceeds.VisibleIndex = 31;
            this.colproceeds.Initialize("proceeds");
            // 
            // colavanzocassaeffettivo
            // 
            this.colavanzocassaeffettivo.SortDirection = Xceed.Grid.SortDirection.None;
            this.colavanzocassaeffettivo.Title = "actualcashsurplus";
            this.colavanzocassaeffettivo.VisibleIndex = 12;
            this.colavanzocassaeffettivo.Initialize("actualcashsurplus");
            // 
            // colactualprev
            // 
            this.colactualprev.SortDirection = Xceed.Grid.SortDirection.None;
            this.colactualprev.Title = "actualprev";
            this.colactualprev.VisibleIndex = 9;
            this.colactualprev.Initialize("actualprev");
            // 
            // colavanzoamministrazioneeffettivo
            // 
            this.colavanzoamministrazioneeffettivo.SortDirection = Xceed.Grid.SortDirection.None;
            this.colavanzoamministrazioneeffettivo.Title = "actualcreditsurplus";
            this.colavanzoamministrazioneeffettivo.VisibleIndex = 14;
            this.colavanzoamministrazioneeffettivo.Initialize("actualcreditsurplus");
            // 
            // colvarprevisioneprincipale
            // 
            this.colvarprevisioneprincipale.SortDirection = Xceed.Grid.SortDirection.None;
            this.colvarprevisioneprincipale.Title = "previsionvariation";
            this.colvarprevisioneprincipale.VisibleIndex = 21;
            this.colvarprevisioneprincipale.Initialize("previsionvariation");
            // 
            // colvarprevisionesecondaria
            // 
            this.colvarprevisionesecondaria.SortDirection = Xceed.Grid.SortDirection.None;
            this.colvarprevisionesecondaria.Title = "secondaryprevvariation";
            this.colvarprevisionesecondaria.VisibleIndex = 22;
            this.colvarprevisionesecondaria.Initialize("secondaryprevvariation");
            // 
            // colvardotazionecrediti
            // 
            this.colvardotazionecrediti.SortDirection = Xceed.Grid.SortDirection.None;
            this.colvardotazionecrediti.Title = "creditvariation";
            this.colvardotazionecrediti.VisibleIndex = 23;
            this.colvardotazionecrediti.Initialize("creditvariation");
            // 
            // colvardotazionecassa
            // 
            this.colvardotazionecassa.SortDirection = Xceed.Grid.SortDirection.None;
            this.colvardotazionecassa.Title = "cashvariation";
            this.colvardotazionecassa.VisibleIndex = 24;
            this.colvardotazionecassa.Initialize("cashvariation");
            // 
            // colvarresiduiattivi
            // 
            this.colvarresiduiattivi.SortDirection = Xceed.Grid.SortDirection.None;
            this.colvarresiduiattivi.Title = "!revenuevariation";
            this.colvarresiduiattivi.VisibleIndex = 33;
            this.colvarresiduiattivi.Initialize("!revenuevariation");
            // 
            // colsupposedrevenue1
            // 
            this.colsupposedrevenue1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedrevenue1.Title = "supposedrevenue";
            this.colsupposedrevenue1.VisibleIndex = 5;
            this.colsupposedrevenue1.Initialize("supposedrevenue");
            // 
            // colsupposedexpenditure1
            // 
            this.colsupposedexpenditure1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedexpenditure1.Title = "supposedexpenditure";
            this.colsupposedexpenditure1.VisibleIndex = 7;
            this.colsupposedexpenditure1.Initialize("supposedexpenditure");
            // 
            // colsupposedavailableprev1
            // 
            this.colsupposedavailableprev1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedavailableprev1.Title = "supposedavailableprev";
            this.colsupposedavailableprev1.VisibleIndex = 19;
            this.colsupposedavailableprev1.Initialize("supposedavailableprev");
            // 
            // colactualavailableprev1
            // 
            this.colactualavailableprev1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colactualavailableprev1.Title = "actualavailableprev";
            this.colactualavailableprev1.VisibleIndex = 20;
            this.colactualavailableprev1.Initialize("actualavailableprev");
            // 
            // dataRowTemplate1
            // 
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1cu);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1ct);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1lu);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1lt);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1idfin);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1codefin);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1title);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedcash);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedcredits);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1revenue);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1expenditure);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1actualcashsurplus);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1actualcreditsurplus);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1previsionvariation);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1secondaryprevvariation);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1creditvariation);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1cashvariation);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedrevenue);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedexpenditure);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedavailableprev);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1actualavailableprev);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1payment);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1assignedcash);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1actualprev);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1proceeds);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1revenuevariation);
            this.celldataRowTemplate1cu.Initialize("cu");
            this.celldataRowTemplate1ct.Initialize("ct");
            this.celldataRowTemplate1lu.Initialize("lu");
            this.celldataRowTemplate1lt.Initialize("lt");
            this.celldataRowTemplate1idfin.Initialize("idfin");
            this.celldataRowTemplate1codefin.Initialize("codefin");
            this.celldataRowTemplate1title.Initialize("title");
            this.celldataRowTemplate1supposedcash.Initialize("supposedcash");
            this.celldataRowTemplate1supposedcredits.Initialize("supposedcredits");
            this.celldataRowTemplate1revenue.Initialize("revenue");
            this.celldataRowTemplate1expenditure.Initialize("expenditure");
            this.celldataRowTemplate1actualcashsurplus.Initialize("actualcashsurplus");
            this.celldataRowTemplate1actualcreditsurplus.Initialize("actualcreditsurplus");
            this.celldataRowTemplate1previsionvariation.Initialize("previsionvariation");
            this.celldataRowTemplate1secondaryprevvariation.Initialize("secondaryprevvariation");
            this.celldataRowTemplate1creditvariation.Initialize("creditvariation");
            this.celldataRowTemplate1cashvariation.Initialize("cashvariation");
            this.celldataRowTemplate1supposedrevenue.Initialize("supposedrevenue");
            this.celldataRowTemplate1supposedexpenditure.Initialize("supposedexpenditure");
            this.celldataRowTemplate1supposedavailableprev.Initialize("supposedavailableprev");
            this.celldataRowTemplate1actualavailableprev.Initialize("actualavailableprev");
            this.celldataRowTemplate1payment.Initialize("payment");
            this.celldataRowTemplate1assignedcash.Initialize("assignedcash");
            this.celldataRowTemplate1actualprev.Initialize("actualprev");
            this.celldataRowTemplate1proceeds.Initialize("proceeds");
            this.celldataRowTemplate1revenuevariation.Initialize("!revenuevariation");
            // 
            // groupByRow1
            // 
            this.groupByRow1.AllowGroupingModification = false;
            this.groupByRow1.ReadOnly = true;
            this.groupByRow1.Visible = false;
            // 
            // columnManagerRow1
            // 
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1cu);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1ct);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1lu);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1lt);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1idfin);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1codefin);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1title);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedcash);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedcredits);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1revenue);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1expenditure);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1actualcashsurplus);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1actualcreditsurplus);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1previsionvariation);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1secondaryprevvariation);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1creditvariation);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1cashvariation);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedrevenue);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedexpenditure);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedavailableprev);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1actualavailableprev);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1payment);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1assignedcash);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1proceeds);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1actualprev);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1revenuevariation);
            this.columnManagerRow1.Height = 35;
            this.cellcolumnManagerRow1cu.Initialize("cu");
            this.cellcolumnManagerRow1ct.Initialize("ct");
            this.cellcolumnManagerRow1lu.Initialize("lu");
            this.cellcolumnManagerRow1lt.Initialize("lt");
            this.cellcolumnManagerRow1idfin.Initialize("idfin");
            this.cellcolumnManagerRow1codefin.Initialize("codefin");
            this.cellcolumnManagerRow1title.Initialize("title");
            this.cellcolumnManagerRow1supposedcash.Initialize("supposedcash");
            this.cellcolumnManagerRow1supposedcredits.Initialize("supposedcredits");
            this.cellcolumnManagerRow1revenue.Initialize("revenue");
            this.cellcolumnManagerRow1expenditure.Initialize("expenditure");
            this.cellcolumnManagerRow1actualcashsurplus.Initialize("actualcashsurplus");
            this.cellcolumnManagerRow1actualcreditsurplus.Initialize("actualcreditsurplus");
            this.cellcolumnManagerRow1previsionvariation.Initialize("previsionvariation");
            this.cellcolumnManagerRow1secondaryprevvariation.Initialize("secondaryprevvariation");
            this.cellcolumnManagerRow1creditvariation.Initialize("creditvariation");
            this.cellcolumnManagerRow1cashvariation.Initialize("cashvariation");
            this.cellcolumnManagerRow1supposedrevenue.Initialize("supposedrevenue");
            this.cellcolumnManagerRow1supposedexpenditure.Initialize("supposedexpenditure");
            this.cellcolumnManagerRow1supposedavailableprev.Initialize("supposedavailableprev");
            this.cellcolumnManagerRow1actualavailableprev.Initialize("actualavailableprev");
            this.cellcolumnManagerRow1payment.Initialize("payment");
            this.cellcolumnManagerRow1assignedcash.Initialize("assignedcash");
            this.cellcolumnManagerRow1actualprev.Initialize("actualprev");
            this.cellcolumnManagerRow1revenuevariation.Initialize("!revenuevariation");
            // 
            // tabEntrata
            // 
            this.tabEntrata.Controls.Add(this.gridControl2);
            this.tabEntrata.Location = new System.Drawing.Point(4, 22);
            this.tabEntrata.Name = "tabEntrata";
            this.tabEntrata.Size = new System.Drawing.Size(632, 326);
            this.tabEntrata.TabIndex = 2;
            this.tabEntrata.Text = "Assestamento Entrate";
            this.tabEntrata.UseVisualStyleBackColor = true;
            // 
            // DS3
            // 
            this.DS3.DataSetName = "tempds";
            this.DS3.EnforceConstraints = false;
            this.DS3.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Columns.Add(this.colcu1);
            this.gridControl2.Columns.Add(this.colct1);
            this.gridControl2.Columns.Add(this.collu1);
            this.gridControl2.Columns.Add(this.collt1);
            this.gridControl2.Columns.Add(this.colidfin);
            this.gridControl2.Columns.Add(this.colcodefin);
            this.gridControl2.Columns.Add(this.coltitle);
            this.gridControl2.Columns.Add(this.colsupposedcash);
            this.gridControl2.Columns.Add(this.colsupposedcredits);
            this.gridControl2.Columns.Add(this.colrevenue);
            this.gridControl2.Columns.Add(this.colexpenditure);
            this.gridControl2.Columns.Add(this.colactualcashsurplus);
            this.gridControl2.Columns.Add(this.colactualcreditsurplus);
            this.gridControl2.Columns.Add(this.colprevisionvariation);
            this.gridControl2.Columns.Add(this.colsecondaryprevvariation);
            this.gridControl2.Columns.Add(this.colcreditvariation);
            this.gridControl2.Columns.Add(this.colcashvariation);
            this.gridControl2.Columns.Add(this.colrevenuevariation);
            this.gridControl2.Columns.Add(this.colsupposedrevenue);
            this.gridControl2.Columns.Add(this.colsupposedexpenditure);
            this.gridControl2.Columns.Add(this.colsupposedavailableprev);
            this.gridControl2.Columns.Add(this.colactualavailableprev);
            this.gridControl2.Columns.Add(this.colpayment);
            this.gridControl2.Columns.Add(this.colassignedcash);
            this.gridControl2.Columns.Add(this.colincassi);
            this.gridControl2.Columns.Add(this.colactualprev1);
            this.gridControl2.DataRowTemplate = this.dataRow1;
            this.gridControl2.DataSource = this.DS3.finbalancedetail;
            this.gridControl2.FixedHeaderRows.Add(this.groupByRow2);
            this.gridControl2.FixedHeaderRows.Add(this.columnManagerRow2);
            this.gridControl2.Location = new System.Drawing.Point(8, 7);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(616, 312);
            this.gridControl2.SortedColumns.AddRange(new Xceed.Grid.Column[] {
																				 this.colcodefin});
            this.gridControl2.TabIndex = 1;
            this.gridControl2.FirstVisibleColumnChanged += new System.EventHandler(this.gridControl2_FirstVisibleColumnChanged);
            this.gridControl2.CurrentColumnChanged += new System.EventHandler(this.gridControl2_CurrentColumnChanged);
            // 
            // colcu1
            // 
            this.colcu1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcu1.Title = "cu";
            this.colcu1.VisibleIndex = 15;
            this.colcu1.Initialize("cu");
            // 
            // colct1
            // 
            this.colct1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colct1.Title = "ct";
            this.colct1.VisibleIndex = 16;
            this.colct1.Initialize("ct");
            // 
            // collu1
            // 
            this.collu1.SortDirection = Xceed.Grid.SortDirection.None;
            this.collu1.Title = "lu";
            this.collu1.VisibleIndex = 17;
            this.collu1.Initialize("lu");
            // 
            // collt1
            // 
            this.collt1.SortDirection = Xceed.Grid.SortDirection.None;
            this.collt1.Title = "lt";
            this.collt1.VisibleIndex = 18;
            this.collt1.Initialize("lt");
            // 
            // colidfin
            // 
            this.colidfin.SortDirection = Xceed.Grid.SortDirection.None;
            this.colidfin.Title = "idfin";
            this.colidfin.VisibleIndex = 0;
            this.colidfin.Initialize("idfin");
            // 
            // colcodefin
            // 
            this.colcodefin.SortDirection = Xceed.Grid.SortDirection.Ascending;
            this.colcodefin.Title = "codefin";
            this.colcodefin.VisibleIndex = 1;
            this.colcodefin.Initialize("codefin");
            // 
            // coltitle
            // 
            this.coltitle.SortDirection = Xceed.Grid.SortDirection.None;
            this.coltitle.Title = "title";
            this.coltitle.VisibleIndex = 2;
            this.coltitle.Initialize("title");
            // 
            // colsupposedcash
            // 
            this.colsupposedcash.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedcash.Title = "supposedcash";
            this.colsupposedcash.VisibleIndex = 3;
            this.colsupposedcash.Initialize("supposedcash");
            // 
            // colsupposedcredits
            // 
            this.colsupposedcredits.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedcredits.Title = "supposedcredits";
            this.colsupposedcredits.VisibleIndex = 4;
            this.colsupposedcredits.Initialize("supposedcredits");
            // 
            // colpayment
            // 
            this.colpayment.SortDirection = Xceed.Grid.SortDirection.None;
            this.colpayment.Title = "payment";
            this.colpayment.VisibleIndex = 30;
            this.colpayment.Initialize("payment");
            // 
            // colassignedcash
            // 
            this.colassignedcash.SortDirection = Xceed.Grid.SortDirection.None;
            this.colassignedcash.Title = "assignedcash";
            this.colassignedcash.VisibleIndex = 31;
            this.colassignedcash.Initialize("assignedcash");
            // 
            // colincassi
            // 
            this.colincassi.SortDirection = Xceed.Grid.SortDirection.None;
            this.colincassi.Title = "proceeds";
            this.colincassi.VisibleIndex = 5;
            this.colincassi.Initialize("proceeds");
            // 
            // colactualprev1
            // 
            this.colactualprev1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colactualprev1.Title = "actualprev";
            this.colactualprev1.VisibleIndex = 6;
            this.colactualprev1.Initialize("actualprev");
            // 
            // colrevenue
            // 
            this.colrevenue.SortDirection = Xceed.Grid.SortDirection.None;
            this.colrevenue.Title = "revenue";
            this.colrevenue.VisibleIndex = 8;
            this.colrevenue.Initialize("revenue");
            // 
            // colexpenditure
            // 
            this.colexpenditure.SortDirection = Xceed.Grid.SortDirection.None;
            this.colexpenditure.Title = "expenditure";
            this.colexpenditure.VisibleIndex = 10;
            this.colexpenditure.Initialize("expenditure");
            // 
            // colactualcashsurplus
            // 
            this.colactualcashsurplus.SortDirection = Xceed.Grid.SortDirection.None;
            this.colactualcashsurplus.Title = "actualcashsurplus";
            this.colactualcashsurplus.VisibleIndex = 11;
            this.colactualcashsurplus.Initialize("actualcashsurplus");
            // 
            // colactualcreditsurplus
            // 
            this.colactualcreditsurplus.SortDirection = Xceed.Grid.SortDirection.None;
            this.colactualcreditsurplus.Title = "actualcreditsurplus";
            this.colactualcreditsurplus.VisibleIndex = 12;
            this.colactualcreditsurplus.Initialize("actualcreditsurplus");
            // 
            // colprevisionvariation
            // 
            this.colprevisionvariation.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevisionvariation.Title = "previsionvariation";
            this.colprevisionvariation.VisibleIndex = 19;
            this.colprevisionvariation.Initialize("previsionvariation");
            // 
            // colsecondaryprevvariation
            // 
            this.colsecondaryprevvariation.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsecondaryprevvariation.Title = "secondaryprevvariation";
            this.colsecondaryprevvariation.VisibleIndex = 20;
            this.colsecondaryprevvariation.Initialize("secondaryprevvariation");
            // 
            // colcreditvariation
            // 
            this.colcreditvariation.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcreditvariation.Title = "creditvariation";
            this.colcreditvariation.VisibleIndex = 21;
            this.colcreditvariation.Initialize("creditvariation");
            // 
            // colcashvariation
            // 
            this.colcashvariation.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcashvariation.Title = "cashvariation";
            this.colcashvariation.VisibleIndex = 22;
            this.colcashvariation.Initialize("cashvariation");
            // 
            // colrevenuevariation
            // 
            this.colrevenuevariation.SortDirection = Xceed.Grid.SortDirection.None;
            this.colrevenuevariation.Title = "!revenuevariation";
            this.colrevenuevariation.VisibleIndex = 33;
            this.colrevenuevariation.Initialize("!revenuevariation");
            // 
            // colsupposedrevenue
            // 
            this.colsupposedrevenue.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedrevenue.Title = "supposedrevenue";
            this.colsupposedrevenue.VisibleIndex = 7;
            this.colsupposedrevenue.Initialize("supposedrevenue");
            // 
            // colsupposedexpenditure
            // 
            this.colsupposedexpenditure.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedexpenditure.Title = "supposedexpenditure";
            this.colsupposedexpenditure.VisibleIndex = 9;
            this.colsupposedexpenditure.Initialize("supposedexpenditure");
            // 
            // colsupposedavailableprev
            // 
            this.colsupposedavailableprev.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedavailableprev.Title = "supposedavailableprev";
            this.colsupposedavailableprev.VisibleIndex = 13;
            this.colsupposedavailableprev.Initialize("supposedavailableprev");
            // 
            // colactualavailableprev
            // 
            this.colactualavailableprev.SortDirection = Xceed.Grid.SortDirection.None;
            this.colactualavailableprev.Title = "actualavailableprev";
            this.colactualavailableprev.VisibleIndex = 14;
            this.colactualavailableprev.Initialize("actualavailableprev");
            // 
            // dataRow1
            // 
            this.dataRow1.Cells.Add(this.dataCell2);
            this.dataRow1.Cells.Add(this.dataCell3);
            this.dataRow1.Cells.Add(this.dataCell4);
            this.dataRow1.Cells.Add(this.dataCell5);
            this.dataRow1.Cells.Add(this.dataCell7);
            this.dataRow1.Cells.Add(this.dataCell8);
            this.dataRow1.Cells.Add(this.dataCell9);
            this.dataRow1.Cells.Add(this.dataCell10);
            this.dataRow1.Cells.Add(this.dataCell11);
            this.dataRow1.Cells.Add(this.dataCell12);
            this.dataRow1.Cells.Add(this.dataCell13);
            this.dataRow1.Cells.Add(this.dataCell14);
            this.dataRow1.Cells.Add(this.dataCell15);
            this.dataRow1.Cells.Add(this.dataCell16);
            this.dataRow1.Cells.Add(this.dataCell17);
            this.dataRow1.Cells.Add(this.dataCell18);
            this.dataRow1.Cells.Add(this.dataCell19);
            this.dataRow1.Cells.Add(this.celldataRow1supposedrevenue);
            this.dataRow1.Cells.Add(this.celldataRow1supposedexpenditure);
            this.dataRow1.Cells.Add(this.celldataRow1supposedavailableprev);
            this.dataRow1.Cells.Add(this.celldataRow1actualavailableprev);
            this.dataRow1.Cells.Add(this.celldataRow2payment);
            this.dataRow1.Cells.Add(this.celldataRow2assignedcash);
            this.dataRow1.Cells.Add(this.celldataRow2proceeds);
            this.dataRow1.Cells.Add(this.celldataRow2actualprev);
            this.dataRow1.Cells.Add(this.celldataRow2revenuevariation);
            this.dataCell2.Initialize("cu");
            this.dataCell3.Initialize("ct");
            this.dataCell4.Initialize("lu");
            this.dataCell5.Initialize("lt");
            this.dataCell7.Initialize("idfin");
            this.dataCell8.Initialize("codefin");
            this.dataCell9.Initialize("title");
            this.dataCell10.Initialize("supposedcash");
            this.dataCell11.Initialize("supposedcredits");
            this.dataCell12.Initialize("revenue");
            this.dataCell13.Initialize("expenditure");
            this.dataCell14.Initialize("actualcashsurplus");
            this.dataCell15.Initialize("actualcreditsurplus");
            this.dataCell16.Initialize("previsionvariation");
            this.dataCell17.Initialize("secondaryprevvariation");
            this.dataCell18.Initialize("creditvariation");
            this.dataCell19.Initialize("cashvariation");
            this.celldataRow1supposedrevenue.Initialize("supposedrevenue");
            this.celldataRow1supposedexpenditure.Initialize("supposedexpenditure");
            this.celldataRow1supposedavailableprev.Initialize("supposedavailableprev");
            this.celldataRow1actualavailableprev.Initialize("actualavailableprev");
            this.celldataRow2payment.Initialize("payment");
            this.celldataRow2assignedcash.Initialize("assignedcash");
            this.celldataRow2proceeds.Initialize("proceeds");
            this.celldataRow2actualprev.Initialize("actualprev");
            this.celldataRow2revenuevariation.Initialize("!revenuevariation");
            // 
            // groupByRow2
            // 
            this.groupByRow2.AllowGroupingModification = false;
            this.groupByRow2.ReadOnly = true;
            this.groupByRow2.Visible = false;
            // 
            // columnManagerRow2
            // 
            this.columnManagerRow2.Cells.Add(this.columnManagerCell2);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell3);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell4);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell5);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell7);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell8);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell9);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell10);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell11);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell12);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell13);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell14);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell15);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell16);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell17);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell18);
            this.columnManagerRow2.Cells.Add(this.columnManagerCell19);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedrevenue);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedexpenditure);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedavailableprev);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2actualavailableprev);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2payment);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2assignedcash);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2proceeds);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2actualprev);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2revenuevariation);
            this.columnManagerRow2.Height = 35;
            this.columnManagerCell2.Initialize("cu");
            this.columnManagerCell3.Initialize("ct");
            this.columnManagerCell4.Initialize("lu");
            this.columnManagerCell5.Initialize("lt");
            this.columnManagerCell7.Initialize("idfin");
            this.columnManagerCell8.Initialize("codefin");
            this.columnManagerCell9.Initialize("title");
            this.columnManagerCell10.Initialize("supposedcash");
            this.columnManagerCell11.Initialize("supposedcredits");
            this.columnManagerCell12.Initialize("revenue");
            this.columnManagerCell13.Initialize("expenditure");
            this.columnManagerCell14.Initialize("actualcashsurplus");
            this.columnManagerCell15.Initialize("actualcreditsurplus");
            this.columnManagerCell16.Initialize("previsionvariation");
            this.columnManagerCell17.Initialize("secondaryprevvariation");
            this.columnManagerCell18.Initialize("creditvariation");
            this.columnManagerCell19.Initialize("cashvariation");
            this.cellcolumnManagerRow2supposedrevenue.Initialize("supposedrevenue");
            this.cellcolumnManagerRow2supposedexpenditure.Initialize("supposedexpenditure");
            this.cellcolumnManagerRow2supposedavailableprev.Initialize("supposedavailableprev");
            this.cellcolumnManagerRow2actualavailableprev.Initialize("actualavailableprev");
            this.cellcolumnManagerRow2payment.Initialize("payment");
            this.cellcolumnManagerRow2assignedcash.Initialize("assignedcash");
            this.cellcolumnManagerRow2proceeds.Initialize("proceeds");
            this.cellcolumnManagerRow2actualprev.Initialize("actualprev");
            this.cellcolumnManagerRow2revenuevariation.Initialize("!revenuevariation");
            // 
            // tabTotali
            // 
    	    this.tabTotali.Controls.Add(this.groupBox3);
            this.tabTotali.Controls.Add(this.groupBox2);
            this.tabTotali.Controls.Add(this.groupBox1);
            this.tabTotali.Controls.Add(this.txtResiduiPassiviPresunti);
            this.tabTotali.Controls.Add(this.txtResiduiAttiviPresunti);
            this.tabTotali.Controls.Add(this.lblResiduiPassiviPresunti);
            this.tabTotali.Controls.Add(this.lblResiduiAttiviPresunti);
            this.tabTotali.Controls.Add(this.txtResiduiPassivi);
            this.tabTotali.Controls.Add(this.txtResiduiAttivi);
            this.tabTotali.Controls.Add(this.lblResiduiPassivi);
            this.tabTotali.Controls.Add(this.lblResiduiAttivi);
            this.tabTotali.Controls.Add(this.lblAvanzoAmministrazioneEff);
            this.tabTotali.Controls.Add(this.lblDotazioneCassaPres);
            this.tabTotali.Controls.Add(this.txtDotazioneCreditiPres);
            this.tabTotali.Controls.Add(this.txtAvanzoAmministrazioneEff);
            this.tabTotali.Controls.Add(this.txtDotazioneCassaPres);
            this.tabTotali.Controls.Add(this.lblDotazioneCreditiPres);
            this.tabTotali.Controls.Add(this.lblAvanzoCassaEff);
            this.tabTotali.Controls.Add(this.txtAvanzoCassaEff);
            this.tabTotali.Location = new System.Drawing.Point(4, 22);
            this.tabTotali.Name = "tabTotali";
            this.tabTotali.Size = new System.Drawing.Size(632, 326);
            this.tabTotali.TabIndex = 1;
            this.tabTotali.Text = "Totali";
            this.tabTotali.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtActualPrevDisp_E);
            this.groupBox2.Controls.Add(this.labActualPrevDisp_E);
            this.groupBox2.Controls.Add(this.txtSupposedPrevDisp_E);
            this.groupBox2.Controls.Add(this.labSupposedPrevDisp_E);
            this.groupBox2.Controls.Add(this.txtVarAssestamentoPrevPrincEntrata);
            this.groupBox2.Controls.Add(this.txtVarAssestamentoPrevSecEntrata);
            this.groupBox2.Controls.Add(this.lblVarAssestamentoPrevSec_E);
            this.groupBox2.Controls.Add(this.lblVarAssestamentoPrevPrinc_E);
            this.groupBox2.Location = new System.Drawing.Point(264, 173);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 120);
            this.groupBox2.TabIndex = 68;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parte Entrate";
            // 
            // txtActualPrevDisp_E
            // 
            this.txtActualPrevDisp_E.Location = new System.Drawing.Point(232, 88);
            this.txtActualPrevDisp_E.Name = "txtActualPrevDisp_E";
            this.txtActualPrevDisp_E.ReadOnly = true;
            this.txtActualPrevDisp_E.Size = new System.Drawing.Size(104, 20);
            this.txtActualPrevDisp_E.TabIndex = 76;
            this.txtActualPrevDisp_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labActualPrevDisp_E
            // 
            this.labActualPrevDisp_E.Location = new System.Drawing.Point(24, 88);
            this.labActualPrevDisp_E.Name = "labActualPrevDisp_E";
            this.labActualPrevDisp_E.Size = new System.Drawing.Size(192, 16);
            this.labActualPrevDisp_E.TabIndex = 75;
            this.labActualPrevDisp_E.Text = "Prev.Disponibile Effettiva";
            this.labActualPrevDisp_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSupposedPrevDisp_E
            // 
            this.txtSupposedPrevDisp_E.Location = new System.Drawing.Point(232, 64);
            this.txtSupposedPrevDisp_E.Name = "txtSupposedPrevDisp_E";
            this.txtSupposedPrevDisp_E.ReadOnly = true;
            this.txtSupposedPrevDisp_E.Size = new System.Drawing.Size(104, 20);
            this.txtSupposedPrevDisp_E.TabIndex = 74;
            this.txtSupposedPrevDisp_E.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labSupposedPrevDisp_E
            // 
            this.labSupposedPrevDisp_E.Location = new System.Drawing.Point(24, 64);
            this.labSupposedPrevDisp_E.Name = "labSupposedPrevDisp_E";
            this.labSupposedPrevDisp_E.Size = new System.Drawing.Size(192, 16);
            this.labSupposedPrevDisp_E.TabIndex = 73;
            this.labSupposedPrevDisp_E.Text = "Prev.Disponibile presunta";
            this.labSupposedPrevDisp_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarAssestamentoPrevPrincEntrata
            // 
            this.txtVarAssestamentoPrevPrincEntrata.Location = new System.Drawing.Point(232, 16);
            this.txtVarAssestamentoPrevPrincEntrata.Name = "txtVarAssestamentoPrevPrincEntrata";
            this.txtVarAssestamentoPrevPrincEntrata.ReadOnly = true;
            this.txtVarAssestamentoPrevPrincEntrata.Size = new System.Drawing.Size(104, 20);
            this.txtVarAssestamentoPrevPrincEntrata.TabIndex = 63;
            this.txtVarAssestamentoPrevPrincEntrata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarAssestamentoPrevSecEntrata
            // 
            this.txtVarAssestamentoPrevSecEntrata.Location = new System.Drawing.Point(232, 40);
            this.txtVarAssestamentoPrevSecEntrata.Name = "txtVarAssestamentoPrevSecEntrata";
            this.txtVarAssestamentoPrevSecEntrata.ReadOnly = true;
            this.txtVarAssestamentoPrevSecEntrata.Size = new System.Drawing.Size(104, 20);
            this.txtVarAssestamentoPrevSecEntrata.TabIndex = 64;
            this.txtVarAssestamentoPrevSecEntrata.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVarAssestamentoPrevSec_E
            // 
            this.lblVarAssestamentoPrevSec_E.Location = new System.Drawing.Point(20, 40);
            this.lblVarAssestamentoPrevSec_E.Name = "lblVarAssestamentoPrevSec_E";
            this.lblVarAssestamentoPrevSec_E.Size = new System.Drawing.Size(200, 16);
            this.lblVarAssestamentoPrevSec_E.TabIndex = 62;
            this.lblVarAssestamentoPrevSec_E.Text = "Var. Assestamento Prev. Secondaria:";
            this.lblVarAssestamentoPrevSec_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVarAssestamentoPrevPrinc_E
            // 
            this.lblVarAssestamentoPrevPrinc_E.Location = new System.Drawing.Point(20, 16);
            this.lblVarAssestamentoPrevPrinc_E.Name = "lblVarAssestamentoPrevPrinc_E";
            this.lblVarAssestamentoPrevPrinc_E.Size = new System.Drawing.Size(200, 16);
            this.lblVarAssestamentoPrevPrinc_E.TabIndex = 61;
            this.lblVarAssestamentoPrevPrinc_E.Text = "Var. Assestamento Prev. Principale:";
            this.lblVarAssestamentoPrevPrinc_E.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtActualPrevDisp_S);
            this.groupBox1.Controls.Add(this.labActualPrevDisp_S);
            this.groupBox1.Controls.Add(this.txtSupposedPrevDisp_S);
            this.groupBox1.Controls.Add(this.txtVarAssestamentoPrevPrinc);
            this.groupBox1.Controls.Add(this.txtVarAssestamentoDotCassa);
            this.groupBox1.Controls.Add(this.txtVarAssestamentoPrevSec);
            this.groupBox1.Controls.Add(this.lblVarAssestamentoPrevSec);
            this.groupBox1.Controls.Add(this.lblVarAssestamentoDotCrediti);
            this.groupBox1.Controls.Add(this.lblVarAssestamentoDotCassa);
            this.groupBox1.Controls.Add(this.lblVarAssestamentoPrevPrinc);
            this.groupBox1.Controls.Add(this.txtVarAssestamentoDotCrediti);
            this.groupBox1.Controls.Add(this.labSupposedPrevDisp_S);
            this.groupBox1.Location = new System.Drawing.Point(264, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 162);
            this.groupBox1.TabIndex = 67;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parte spese";
            // 
            // txtActualPrevDisp_S
            // 
            this.txtActualPrevDisp_S.Location = new System.Drawing.Point(224, 136);
            this.txtActualPrevDisp_S.Name = "txtActualPrevDisp_S";
            this.txtActualPrevDisp_S.ReadOnly = true;
            this.txtActualPrevDisp_S.Size = new System.Drawing.Size(104, 20);
            this.txtActualPrevDisp_S.TabIndex = 72;
            this.txtActualPrevDisp_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labActualPrevDisp_S
            // 
            this.labActualPrevDisp_S.Location = new System.Drawing.Point(16, 136);
            this.labActualPrevDisp_S.Name = "labActualPrevDisp_S";
            this.labActualPrevDisp_S.Size = new System.Drawing.Size(192, 16);
            this.labActualPrevDisp_S.TabIndex = 71;
            this.labActualPrevDisp_S.Text = "Prev.Disponibile Effettiva";
            this.labActualPrevDisp_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSupposedPrevDisp_S
            // 
            this.txtSupposedPrevDisp_S.Location = new System.Drawing.Point(224, 112);
            this.txtSupposedPrevDisp_S.Name = "txtSupposedPrevDisp_S";
            this.txtSupposedPrevDisp_S.ReadOnly = true;
            this.txtSupposedPrevDisp_S.Size = new System.Drawing.Size(104, 20);
            this.txtSupposedPrevDisp_S.TabIndex = 70;
            this.txtSupposedPrevDisp_S.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarAssestamentoPrevPrinc
            // 
            this.txtVarAssestamentoPrevPrinc.Location = new System.Drawing.Point(224, 16);
            this.txtVarAssestamentoPrevPrinc.Name = "txtVarAssestamentoPrevPrinc";
            this.txtVarAssestamentoPrevPrinc.ReadOnly = true;
            this.txtVarAssestamentoPrevPrinc.Size = new System.Drawing.Size(104, 20);
            this.txtVarAssestamentoPrevPrinc.TabIndex = 59;
            this.txtVarAssestamentoPrevPrinc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarAssestamentoDotCassa
            // 
            this.txtVarAssestamentoDotCassa.Location = new System.Drawing.Point(224, 64);
            this.txtVarAssestamentoDotCassa.Name = "txtVarAssestamentoDotCassa";
            this.txtVarAssestamentoDotCassa.ReadOnly = true;
            this.txtVarAssestamentoDotCassa.Size = new System.Drawing.Size(104, 20);
            this.txtVarAssestamentoDotCassa.TabIndex = 61;
            this.txtVarAssestamentoDotCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVarAssestamentoPrevSec
            // 
            this.txtVarAssestamentoPrevSec.Location = new System.Drawing.Point(224, 40);
            this.txtVarAssestamentoPrevSec.Name = "txtVarAssestamentoPrevSec";
            this.txtVarAssestamentoPrevSec.ReadOnly = true;
            this.txtVarAssestamentoPrevSec.Size = new System.Drawing.Size(104, 20);
            this.txtVarAssestamentoPrevSec.TabIndex = 60;
            this.txtVarAssestamentoPrevSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVarAssestamentoPrevSec
            // 
            this.lblVarAssestamentoPrevSec.Location = new System.Drawing.Point(8, 40);
            this.lblVarAssestamentoPrevSec.Name = "lblVarAssestamentoPrevSec";
            this.lblVarAssestamentoPrevSec.Size = new System.Drawing.Size(200, 16);
            this.lblVarAssestamentoPrevSec.TabIndex = 54;
            this.lblVarAssestamentoPrevSec.Text = "Var. Assestamento Prev. Secondaria:";
            this.lblVarAssestamentoPrevSec.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVarAssestamentoDotCrediti
            // 
            this.lblVarAssestamentoDotCrediti.Location = new System.Drawing.Point(8, 88);
            this.lblVarAssestamentoDotCrediti.Name = "lblVarAssestamentoDotCrediti";
            this.lblVarAssestamentoDotCrediti.Size = new System.Drawing.Size(200, 16);
            this.lblVarAssestamentoDotCrediti.TabIndex = 56;
            this.lblVarAssestamentoDotCrediti.Text = "Var. Assestamento Dot. Crediti:";
            this.lblVarAssestamentoDotCrediti.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVarAssestamentoDotCassa
            // 
            this.lblVarAssestamentoDotCassa.Location = new System.Drawing.Point(8, 64);
            this.lblVarAssestamentoDotCassa.Name = "lblVarAssestamentoDotCassa";
            this.lblVarAssestamentoDotCassa.Size = new System.Drawing.Size(200, 16);
            this.lblVarAssestamentoDotCassa.TabIndex = 55;
            this.lblVarAssestamentoDotCassa.Text = "Var. Assestamento Dot. Cassa:";
            this.lblVarAssestamentoDotCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblVarAssestamentoPrevPrinc
            // 
            this.lblVarAssestamentoPrevPrinc.Location = new System.Drawing.Point(8, 16);
            this.lblVarAssestamentoPrevPrinc.Name = "lblVarAssestamentoPrevPrinc";
            this.lblVarAssestamentoPrevPrinc.Size = new System.Drawing.Size(200, 16);
            this.lblVarAssestamentoPrevPrinc.TabIndex = 53;
            this.lblVarAssestamentoPrevPrinc.Text = "Var. Assestamento Prev. Principale:";
            this.lblVarAssestamentoPrevPrinc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtVarAssestamentoDotCrediti
            // 
            this.txtVarAssestamentoDotCrediti.Location = new System.Drawing.Point(224, 88);
            this.txtVarAssestamentoDotCrediti.Name = "txtVarAssestamentoDotCrediti";
            this.txtVarAssestamentoDotCrediti.ReadOnly = true;
            this.txtVarAssestamentoDotCrediti.Size = new System.Drawing.Size(104, 20);
            this.txtVarAssestamentoDotCrediti.TabIndex = 62;
            this.txtVarAssestamentoDotCrediti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labSupposedPrevDisp_S
            // 
            this.labSupposedPrevDisp_S.Location = new System.Drawing.Point(16, 112);
            this.labSupposedPrevDisp_S.Name = "labSupposedPrevDisp_S";
            this.labSupposedPrevDisp_S.Size = new System.Drawing.Size(192, 16);
            this.labSupposedPrevDisp_S.TabIndex = 69;
            this.labSupposedPrevDisp_S.Text = "Prev.Disponibile presunta";
            this.labSupposedPrevDisp_S.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResiduiPassiviPresunti
            // 
            this.txtResiduiPassiviPresunti.Location = new System.Drawing.Point(128, 200);
            this.txtResiduiPassiviPresunti.Name = "txtResiduiPassiviPresunti";
            this.txtResiduiPassiviPresunti.ReadOnly = true;
            this.txtResiduiPassiviPresunti.Size = new System.Drawing.Size(104, 20);
            this.txtResiduiPassiviPresunti.TabIndex = 66;
            this.txtResiduiPassiviPresunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtResiduiAttiviPresunti
            // 
            this.txtResiduiAttiviPresunti.Location = new System.Drawing.Point(128, 160);
            this.txtResiduiAttiviPresunti.Name = "txtResiduiAttiviPresunti";
            this.txtResiduiAttiviPresunti.ReadOnly = true;
            this.txtResiduiAttiviPresunti.Size = new System.Drawing.Size(104, 20);
            this.txtResiduiAttiviPresunti.TabIndex = 65;
            this.txtResiduiAttiviPresunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblResiduiPassiviPresunti
            // 
            this.lblResiduiPassiviPresunti.Location = new System.Drawing.Point(128, 184);
            this.lblResiduiPassiviPresunti.Name = "lblResiduiPassiviPresunti";
            this.lblResiduiPassiviPresunti.Size = new System.Drawing.Size(136, 16);
            this.lblResiduiPassiviPresunti.TabIndex = 64;
            this.lblResiduiPassiviPresunti.Text = "Residui Passivi presunti:";
            this.lblResiduiPassiviPresunti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResiduiAttiviPresunti
            // 
            this.lblResiduiAttiviPresunti.Location = new System.Drawing.Point(128, 144);
            this.lblResiduiAttiviPresunti.Name = "lblResiduiAttiviPresunti";
            this.lblResiduiAttiviPresunti.Size = new System.Drawing.Size(128, 16);
            this.lblResiduiAttiviPresunti.TabIndex = 63;
            this.lblResiduiAttiviPresunti.Text = "Residui Attivi presunti:";
            this.lblResiduiAttiviPresunti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResiduiPassivi
            // 
            this.txtResiduiPassivi.Location = new System.Drawing.Point(8, 200);
            this.txtResiduiPassivi.Name = "txtResiduiPassivi";
            this.txtResiduiPassivi.ReadOnly = true;
            this.txtResiduiPassivi.Size = new System.Drawing.Size(104, 20);
            this.txtResiduiPassivi.TabIndex = 58;
            this.txtResiduiPassivi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtResiduiAttivi
            // 
            this.txtResiduiAttivi.Location = new System.Drawing.Point(8, 160);
            this.txtResiduiAttivi.Name = "txtResiduiAttivi";
            this.txtResiduiAttivi.ReadOnly = true;
            this.txtResiduiAttivi.Size = new System.Drawing.Size(104, 20);
            this.txtResiduiAttivi.TabIndex = 57;
            this.txtResiduiAttivi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblResiduiPassivi
            // 
            this.lblResiduiPassivi.Location = new System.Drawing.Point(8, 184);
            this.lblResiduiPassivi.Name = "lblResiduiPassivi";
            this.lblResiduiPassivi.Size = new System.Drawing.Size(96, 16);
            this.lblResiduiPassivi.TabIndex = 52;
            this.lblResiduiPassivi.Text = "Residui Passivi:";
            this.lblResiduiPassivi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblResiduiAttivi
            // 
            this.lblResiduiAttivi.Location = new System.Drawing.Point(8, 144);
            this.lblResiduiAttivi.Name = "lblResiduiAttivi";
            this.lblResiduiAttivi.Size = new System.Drawing.Size(104, 16);
            this.lblResiduiAttivi.TabIndex = 51;
            this.lblResiduiAttivi.Text = "Residui Attivi:";
            this.lblResiduiAttivi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAvanzoAmministrazioneEff
            // 
            this.lblAvanzoAmministrazioneEff.Location = new System.Drawing.Point(16, 16);
            this.lblAvanzoAmministrazioneEff.Name = "lblAvanzoAmministrazioneEff";
            this.lblAvanzoAmministrazioneEff.Size = new System.Drawing.Size(136, 16);
            this.lblAvanzoAmministrazioneEff.TabIndex = 44;
            this.lblAvanzoAmministrazioneEff.Text = "Avanzo Ammin. Effettivo:";
            this.lblAvanzoAmministrazioneEff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDotazioneCassaPres
            // 
            this.lblDotazioneCassaPres.Location = new System.Drawing.Point(8, 80);
            this.lblDotazioneCassaPres.Name = "lblDotazioneCassaPres";
            this.lblDotazioneCassaPres.Size = new System.Drawing.Size(144, 16);
            this.lblDotazioneCassaPres.TabIndex = 46;
            this.lblDotazioneCassaPres.Text = "Dotazione Cassa presunta:";
            this.lblDotazioneCassaPres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDotazioneCreditiPres
            // 
            this.txtDotazioneCreditiPres.Location = new System.Drawing.Point(152, 112);
            this.txtDotazioneCreditiPres.Name = "txtDotazioneCreditiPres";
            this.txtDotazioneCreditiPres.ReadOnly = true;
            this.txtDotazioneCreditiPres.Size = new System.Drawing.Size(104, 20);
            this.txtDotazioneCreditiPres.TabIndex = 49;
            this.txtDotazioneCreditiPres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAvanzoAmministrazioneEff
            // 
            this.txtAvanzoAmministrazioneEff.Location = new System.Drawing.Point(152, 16);
            this.txtAvanzoAmministrazioneEff.Name = "txtAvanzoAmministrazioneEff";
            this.txtAvanzoAmministrazioneEff.ReadOnly = true;
            this.txtAvanzoAmministrazioneEff.Size = new System.Drawing.Size(104, 20);
            this.txtAvanzoAmministrazioneEff.TabIndex = 45;
            this.txtAvanzoAmministrazioneEff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDotazioneCassaPres
            // 
            this.txtDotazioneCassaPres.Location = new System.Drawing.Point(152, 80);
            this.txtDotazioneCassaPres.Name = "txtDotazioneCassaPres";
            this.txtDotazioneCassaPres.ReadOnly = true;
            this.txtDotazioneCassaPres.Size = new System.Drawing.Size(104, 20);
            this.txtDotazioneCassaPres.TabIndex = 47;
            this.txtDotazioneCassaPres.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDotazioneCreditiPres
            // 
            this.lblDotazioneCreditiPres.Location = new System.Drawing.Point(8, 112);
            this.lblDotazioneCreditiPres.Name = "lblDotazioneCreditiPres";
            this.lblDotazioneCreditiPres.Size = new System.Drawing.Size(144, 16);
            this.lblDotazioneCreditiPres.TabIndex = 48;
            this.lblDotazioneCreditiPres.Text = "Dotazione Crediti presunta:";
            this.lblDotazioneCreditiPres.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAvanzoCassaEff
            // 
            this.lblAvanzoCassaEff.Location = new System.Drawing.Point(8, 48);
            this.lblAvanzoCassaEff.Name = "lblAvanzoCassaEff";
            this.lblAvanzoCassaEff.Size = new System.Drawing.Size(144, 16);
            this.lblAvanzoCassaEff.TabIndex = 42;
            this.lblAvanzoCassaEff.Text = "Avanzo Cassa Effettivo:";
            this.lblAvanzoCassaEff.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAvanzoCassaEff
            // 
            this.txtAvanzoCassaEff.Location = new System.Drawing.Point(152, 48);
            this.txtAvanzoCassaEff.Name = "txtAvanzoCassaEff";
            this.txtAvanzoCassaEff.ReadOnly = true;
            this.txtAvanzoCassaEff.Size = new System.Drawing.Size(104, 20);
            this.txtAvanzoCassaEff.TabIndex = 43;
            this.txtAvanzoCassaEff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSalvaDatiPrevisione
            // 
            this.btnSalvaDatiPrevisione.Location = new System.Drawing.Point(424, 32);
            this.btnSalvaDatiPrevisione.Name = "btnSalvaDatiPrevisione";
            this.btnSalvaDatiPrevisione.Size = new System.Drawing.Size(216, 24);
            this.btnSalvaDatiPrevisione.TabIndex = 50;
            this.btnSalvaDatiPrevisione.Text = "Rendi operativo l\'assestamento";
            this.btnSalvaDatiPrevisione.Click += new System.EventHandler(this.btnSalvaDatiPrevisione_Click);
            // 
            // chkConsolida
            // 
            this.chkConsolida.Location = new System.Drawing.Point(256, 36);
            this.chkConsolida.Name = "chkConsolida";
            this.chkConsolida.Size = new System.Drawing.Size(168, 16);
            this.chkConsolida.TabIndex = 53;
            this.chkConsolida.Text = "Visualizza dati consolidati";
            this.chkConsolida.CheckedChanged += new System.EventHandler(this.chkConsolida_CheckedChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 36);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 16);
            this.label13.TabIndex = 52;
            this.label13.Text = "UPB";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbUpb
            // 
            this.cmbUpb.DataSource = this.DS.upb;
            this.cmbUpb.DisplayMember = "codeupb";
            this.cmbUpb.Location = new System.Drawing.Point(48, 34);
            this.cmbUpb.Name = "cmbUpb";
            this.cmbUpb.Size = new System.Drawing.Size(192, 21);
            this.cmbUpb.TabIndex = 51;
            this.cmbUpb.ValueMember = "idupb";
            this.cmbUpb.SelectedIndexChanged += new System.EventHandler(this.cmbUpb_SelectedIndexChanged);
            // 
            // groupBox3
            // 
	    this.groupBox3.Controls.Add(this.txtVarResAttivi);
            this.groupBox3.Controls.Add(this.lblVarResAttivi);
            this.groupBox3.Location = new System.Drawing.Point(264, 300);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(360, 52);
            this.groupBox3.TabIndex = 69;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Residui Attivi";
	    // 
            // txtVarResAttivi
            // 
            this.txtVarResAttivi.Location = new System.Drawing.Point(234, 19);
            this.txtVarResAttivi.Name = "txtVarResAttivi";
            this.txtVarResAttivi.ReadOnly = true;
            this.txtVarResAttivi.Size = new System.Drawing.Size(104, 20);
            this.txtVarResAttivi.TabIndex = 65;
            this.txtVarResAttivi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVarResAttivi
            // 
            this.lblVarResAttivi.Location = new System.Drawing.Point(22, 19);
            this.lblVarResAttivi.Name = "lblVarResAttivi";
            this.lblVarResAttivi.Size = new System.Drawing.Size(200, 16);
            this.lblVarResAttivi.TabIndex = 64;
            this.lblVarResAttivi.Text = "Var. Residui Attivi:";
            this.lblVarResAttivi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Frm_finbalance_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(664, 480);
            this.Controls.Add(this.chkConsolida);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbUpb);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnRicalcola);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.txtEsercizio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalvaDatiPrevisione);
            this.Name = "Frm_finbalance_default";
            this.Text = "FrmBilancioAssestamento";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabTotali.ResumeLayout(false);
            this.tabTotali.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabEntrata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRow1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).EndInit();
            this.tabAssestamento.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        
		
		public Frm_finbalance_default() {
            Licenser.LicenseKey = "GRD39-TF4PC-94U4P-GBBA";         
			InitializeComponent();
			DS2.EnforceConstraints=false;
			//SetFormulas();
			gridControl1.DataSource= DS2.Tables["finbalancedetail"];
		}
		
		void SetFormulas() {

            if (DoConsolida || curridupb == DBNull.Value) {
				//Clear all formulas
				DS2.finbalancedetail.Columns["actualcreditsurplus"].Expression="";
				DS2.finbalancedetail.Columns["previsionvariation"].Expression = "";
				DS2.finbalancedetail.Columns["secondaryprevvariation"].Expression = "";
				DS2.finbalancedetail.Columns["creditvariation"].Expression = "";
				DS2.finbalancedetail.Columns["cashvariation"].Expression = "";
                DS2.finbalancedetail.Columns["!revenuevariation"].Expression = "";
		        DS3.finbalancedetail.Columns["previsionvariation"].Expression = "";
                DS3.finbalancedetail.Columns["secondaryprevvariation"].Expression = "";
                DS3.finbalancedetail.Columns["!revenuevariation"].Expression = "";
                gridControl1.SetDataBinding(DS2.finbalancedetail, null);
                gridControl2.SetDataBinding(DS3.finbalancedetail, null);
				return;
			}

			bool FinAssured=false;
			if (curridupb!=DBNull.Value){
                System.Data.DataRow UPBRow = DS.upb.Select(QHC.CmpEq("idupb", curridupb))[0];
				if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
			}
			
			string varprevisioneprincipaleexpr = "";
			string varprevisionesecondariaexpr = "";
            string varresiduiattivi = "";
            if (!FinAssured) {
                if (assestapresunto) {
                    switch (tipoprincipale) {

                        case "C": {
                            varprevisioneprincipaleexpr = "ISNULL(actualcreditsurplus,0) - ISNULL(supposedcredits,0)";
                            varresiduiattivi = "ISNULL(revenue,0) - ISNULL(supposedrevenue,0)";
                            break;
                        }
                        case "S": {
                            varprevisioneprincipaleexpr = "ISNULL(actualcashsurplus,0) - ISNULL(supposedcash,0)";
                            break;
                        }
                    }
                    switch (tiposecondaria) {
                        case "S": {
                            varprevisionesecondariaexpr = "ISNULL(actualcashsurplus,0) - ISNULL(supposedcash,0)";
                            break;
                        }
                        default: {
                            varprevisionesecondariaexpr = "";
                            break;
                        }
                    }
                }
                else {
                    //Sola cassa (in USCITA)
                    varprevisioneprincipaleexpr = "ISNULL(actualavailableprev,0)";

                    // (in ENTRATA)
                    DS3.finbalancedetail.Columns["previsionvariation"].Expression = varprevisioneprincipaleexpr;
                }
                string vardotazionecassaexpr = "ISNULL(actualcashsurplus,0) - ISNULL(supposedcash,0)";
                string vardotazionecreditiexpr = "ISNULL(actualcreditsurplus,0) - ISNULL(supposedcredits,0)";
                string avanzoamministrazioneeffettivoexpr = "ISNULL(actualcashsurplus,0) + ISNULL(revenue,0) - ISNULL(expenditure,0)";
                DS2.finbalancedetail.Columns["actualcreditsurplus"].Expression = avanzoamministrazioneeffettivoexpr;
                DS2.finbalancedetail.Columns["creditvariation"].Expression = vardotazionecreditiexpr;
                DS2.finbalancedetail.Columns["cashvariation"].Expression = vardotazionecassaexpr;
                DS2.finbalancedetail.Columns["!revenuevariation"].Expression = varresiduiattivi;
                DS3.finbalancedetail.Columns["!revenuevariation"].Expression = varresiduiattivi;
            }
            else {

                //varprevisioneprincipaleexpr = "ISNULL(supposedexpenditure,0) - ISNULL(expenditure,0)"+
                //    "+ISNULL(supposedavailableprev,0)-ISNULL(actualavailableprev,0)";
                varprevisioneprincipaleexpr = "ISNULL(actualavailableprev,0)- ISNULL(supposedavailableprev,0)";

                varprevisionesecondariaexpr = "ISNULL(expenditure,0) - ISNULL(supposedexpenditure,0)" +
                    "+ISNULL(actualavailableprev,0)-ISNULL(supposedavailableprev,0)";

                DS2.finbalancedetail.Columns["actualcreditsurplus"].Expression = "";
                DS2.finbalancedetail.Columns["creditvariation"].Expression = "";
                DS2.finbalancedetail.Columns["cashvariation"].Expression = "";
                DS2.finbalancedetail.Columns["!revenuevariation"].Expression = "";
                //string varprevisioneprincipaleexpr_e = "ISNULL(supposedrevenue,0) - ISNULL(revenue,0)"+
                //    "+ISNULL(supposedavailableprev,0)-ISNULL(actualavailableprev,0)";
                string varprevisioneprincipaleexpr_e = " ISNULL(actualavailableprev,0) - ISNULL(supposedavailableprev,0)";

                string varprevisionesecondariaexpr_e = "ISNULL(revenue,0) - ISNULL(supposedrevenue,0)" +
                    "+ISNULL(actualavailableprev,0) - ISNULL(supposedavailableprev,0)";
                DS3.finbalancedetail.Columns["previsionvariation"].Expression = varprevisioneprincipaleexpr_e;
                DS3.finbalancedetail.Columns["secondaryprevvariation"].Expression = varprevisionesecondariaexpr_e;
                DS3.finbalancedetail.Columns["!revenuevariation"].Expression = "";
            }


			DS2.finbalancedetail.Columns["previsionvariation"].Expression = varprevisioneprincipaleexpr;
			DS2.finbalancedetail.Columns["secondaryprevvariation"].Expression = varprevisionesecondariaexpr;


			gridControl1.SetDataBinding( DS2.finbalancedetail, null );
			gridControl2.SetDataBinding(DS3.finbalancedetail,null);

		}

        CQueryHelper QHC;
        QueryHelper QHS;

		public void MetaData_AfterLink() {
			Meta= MetaData.GetMetaData(this);
			Conn=Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
			string filter= QHS.CmpEq("ayear",esercizio);
			GetData.SetStaticFilter(DS.finbalance,filter);
            string filteresercizioprec = QHS.CmpEq("ayear", esercizio - 1);
			//object app = Conn.DO_READ_VALUE("accountingyear", filteresercizioprec, "flagfinsetupcopy");
            int app = CfgFn.GetNoNullInt32( Conn.DO_READ_VALUE("accountingyear", filteresercizioprec, "flag"))& 0x0F;
            eseguiForm = "S";
            if (app < 5) {
                if (app < 3)
                    eseguiForm = "N";
                else {
                    if (MessageBox.Show(this, "E' consigliabile, prima di eseguire l'assestamento del bilancio, " +
                            "finire l'inserimento degli accertamenti e degli impegni dell'anno precedente, " +
                            "ed eseguire il trasferimento dei residui attivi e passivi all'anno corrente.\n" +
                            "Tali operazioni NON sono state finora effettuate. Si desidera proseguire lo stesso?",
                            "Avviso", MessageBoxButtons.YesNo) != DialogResult.Yes) 
                        eseguiForm = "N";
                }                                
            }
			GetData.CacheTable(DS.accountingyear,filter,null,false);
			GetData.CacheTable(DS.finlevel,filter,null,false);
			GetData.CacheTable(DS.config,filter,null,false);
			GetData.CacheTable(DS.fin,filter,null,false);
			GetData.CacheTable(DS.upb,null,"codeupb",true);
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn,DS.fin,null,filter,null,false);
		}

		public void MetaData_BeforeActivation() {
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
            string filter = QHS.CmpEq("ayear", esercizio);
			MyBilancio=Conn.RUN_SELECT("fin","*","codefin",filter,null,null,false);
			int finkind= CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("config", filter, "fin_kind"));
            if (finkind == 1) {
                tipoprincipale = "C";
                tiposecondaria = "";
            }
            if (finkind == 2) {
                tipoprincipale = "S";
                tiposecondaria = "";
            }
            if (finkind == 3) {
                tipoprincipale = "C";
                tiposecondaria = "S";
            }

            int balancekind = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("config", filter, "balancekind"));
            assestapresunto = (balancekind != 2);

			campoprevcompetenza = null;
			campoprevcassa = null;

			if (tipoprincipale == "C") {
				campoprevcompetenza="prevision";
				if ((!(tiposecondaria == null)) && (tiposecondaria == "S")) {
					campoprevcassa = "secondaryprev";
                    AbilitaColonneCassa = true;
				}
				else {
					AbilitaColonneCassa = false;
				}
			}

			if (tipoprincipale == "S") {
				campoprevcassa="prevision";
                AbilitaColonneCassa = true;
                SolaCassa = true;
				if ((!(tiposecondaria == null)) && (tiposecondaria == "C")) {
					campoprevcompetenza = "secondaryprev";
				}
				else {
					AbilitaColonneCompetenza = false;
				}
			}
			

			if (eseguiForm != "S") {
				MessageBox.Show("In questa fase non Ë possibile eseguire questo form.");
				Meta.CanSave=false;
				Meta.CanInsert=false;
				Meta.CanInsertCopy=false;
				//Meta.SearchEnabled=false;
				btnSalvaDatiPrevisione.Enabled=false;
				
			}

            codicelivellooperativo = DS.finlevel.Compute("min(nlevel)", QHC.BitSet("flag", 1));
            SetFormulas();

            ImpostaHeaders();
			
		}



		public void MetaData_AfterPost() {
			if (!DS.HasChanges()) {
				CopyDStoXceed();
			}
		}


		void FillEmptyTempTable(DataTable T, string finpart){
            finpart = finpart.ToUpper();
            foreach (System.Data.DataRow R in MyBilancio.Select(null, "codefin")) {
                int flag = CfgFn.GetNoNullInt32(R["flag"]);
                if (((flag & 1) == 0) && (finpart == "S")) continue;
                if (((flag & 1) != 0) && (finpart == "E")) continue;
                object idfin = R["idfin"];
                //LASCIARE I TOSTRING, a questo punto un cast vale l'altro
                if (R["nlevel"].ToString().CompareTo(codicelivellooperativo.ToString()) < 0) continue;
                string filterchild = QHC.CmpEq("paridfin", idfin);
                if (MyBilancio.Select(filterchild).Length > 0) continue;

                System.Data.DataRow NewR = T.NewRow();
                NewR["idfin"] = R["idfin"];
                NewR["codefin"] = R["codefin"];
                NewR["title"] = R["title"];
                T.Rows.Add(NewR);
            }
		}

		void ResetTempTables(){
            DS2.EnforceConstraints = false;
            if (DS2.finbalancedetail.Rows.Count == 0) {
				FillEmptyTempTable(DS2.finbalancedetail,"S");
			}
			else {
                foreach (System.Data.DataRow R in DS2.finbalancedetail.Select(null, "codefin")) {
					R.BeginEdit();
					foreach(DataColumn C in DS2.finbalancedetail.Columns){
						if (C.DataType == typeof(decimal)) { 
							if (C.Expression==null ||C.Expression==""){
								if (C.ReadOnly){
									C.ReadOnly=false;
									R[C]=DBNull.Value;
									C.ReadOnly=true;
								}
								else {
									R[C]=DBNull.Value;
								}
							}
						}
					}
					R.EndEdit();
				}
			}
			DS2.AcceptChanges();

            DS3.EnforceConstraints = false;
            if (DS3.finbalancedetail.Rows.Count == 0) {
				FillEmptyTempTable(DS3.finbalancedetail,"E");
			}
			else {
                foreach (System.Data.DataRow R in DS3.finbalancedetail.Select(null, "codefin")) {
					R.BeginEdit();
					foreach(DataColumn C in DS3.finbalancedetail.Columns){
						if (C.DataType == typeof(decimal)) {
							if (C.Expression==null ||C.Expression==""){
								if (C.ReadOnly){
									C.ReadOnly=false;
									R[C]=DBNull.Value;
									C.ReadOnly=true;
								}
								else {
									R[C]=DBNull.Value;
								}
							}
						}
					}
					R.EndEdit();
				}
			}
			DS3.AcceptChanges();

		}



		void CopyDStoXceed(){

			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();

			DS2 = new tempds();
			DS3= new tempds();

			ImpostaHeaders();
			SetFormulas();
			ResetTempTables();

			if (DoConsolida==false && curridupb!=DBNull.Value){

                System.Data.DataRow[] R_E = DS.Tables["finbalancedetail"].Select(QHC.CmpEq("idupb", curridupb));
                System.Data.DataRow[] R_S = DS.Tables["finbalancedetail"].Select(QHC.CmpEq("idupb", curridupb));

				foreach (System.Data.DataRow RE in R_E){
                    string filter = QHC.CmpEq("idfin", RE["idfin"]);
                    System.Data.DataRow MyFin = MyBilancio.Select(filter)[0];
                    int flag = CfgFn.GetNoNullInt32(MyFin["flag"]);
                    if ((flag & 1) != 0) continue;
					System.Data.DataRow []FE = DS3.finbalancedetail.Select(filter);
					foreach(System.Data.DataRow FFE in FE){
						FFE.BeginEdit();
						foreach(DataColumn C in DS3.finbalancedetail.Columns){
							if (C.DataType == typeof(decimal)) { 
								if (C.Expression==null ||C.Expression==""){
									if (C.ReadOnly){
										C.ReadOnly=false;
										FFE[C]=RE[C.ColumnName];
										C.ReadOnly=true;
									}
									else {
										FFE[C]=RE[C.ColumnName];
									}
								}
							}
						}
						FFE.EndEdit();
					}
				}

				foreach (System.Data.DataRow RS in R_S){
                    string filter = QHC.CmpEq("idfin", RS["idfin"]);
                    System.Data.DataRow MyFin = MyBilancio.Select(filter)[0];
                    int flag = CfgFn.GetNoNullInt32(MyFin["flag"]);
                    if ((flag & 1) == 0) continue;
                    System.Data.DataRow[] FS = DS2.finbalancedetail.Select(filter);
					foreach(System.Data.DataRow FFS in FS){
						FFS.BeginEdit();
						foreach(DataColumn C in DS2.finbalancedetail.Columns){
							if (C.DataType == typeof(decimal)) { 
								if(C.Expression==null ||C.Expression==""){
									if (C.ReadOnly){
										C.ReadOnly=false;
										FFS[C]=RS[C.ColumnName];
										C.ReadOnly=true;
									}
									else {
										FFS[C]=RS[C.ColumnName];
									}
								}
							}
						}
						FFS.EndEdit();
					}
				}
			}
			else {
				string filterUPB="";
				if (curridupb!=DBNull.Value){
                    filterUPB = QHC.Like("idupb", curridupb.ToString() + "%");
                }
				foreach(System.Data.DataRow RE in DS3.finbalancedetail.Rows){
                    string filter = QHC.AppAnd(filterUPB, QHC.CmpEq("idfin", RE["idfin"]));
                    foreach (DataColumn C in DS3.finbalancedetail.Columns) {
						if (C.DataType != typeof(decimal)) continue;
						string expr= "SUM("+C.ColumnName+")";
						object O= DS.finbalancedetail.Compute(expr,filter);
						decimal Od= CfgFn.GetNoNullDecimal(O);
						if (Od==0) O=DBNull.Value;
						if (C.Expression==null ||C.Expression==""){
							if (C.ReadOnly){
								C.ReadOnly=false;
								RE[C.ColumnName]=O;
								C.ReadOnly=true;
							}
							else {
								RE[C.ColumnName]=O;
							}							
						}
					}						
				}
				foreach(System.Data.DataRow RS in DS2.finbalancedetail.Rows){
                    string filter = QHC.AppAnd(filterUPB, QHC.CmpEq("idfin", RS["idfin"]));
                    foreach (DataColumn C in DS2.finbalancedetail.Columns) {
						if (C.DataType != typeof(decimal)) continue;
						string expr= "SUM("+C.ColumnName+")";
						object O= DS.finbalancedetail.Compute(expr,filter);
						decimal Od= CfgFn.GetNoNullDecimal(O);
						if (Od==0) O=DBNull.Value;
						if (C.Expression==null ||C.Expression==""){
							if (C.ReadOnly){
								C.ReadOnly=false;
								RS[C.ColumnName]=O;
								C.ReadOnly=true;
							}
							else {
								RS[C.ColumnName]=O;
							}
						}
					}						
				}


			}
			DS2.AcceptChanges();
			DS3.AcceptChanges();

			Cursor.Current = Cursors.Default;

		}




		public void MetaData_AfterClear() {
			DS2.Clear();
			DS3.Clear();
			SvuotaTotali();
			btnRicalcola.Enabled=false;
			btnSalvaDatiPrevisione.Enabled=false;
		}


		bool TuttoZero(System.Data.DataRow R){
			foreach (DataColumn C in R.Table.Columns){
				if (C.DataType!=typeof(decimal))continue;
				if (CfgFn.GetNoNullDecimal(R[C])==0)continue;
				return false;
			}
			return true;

		}


		void CalculateVariations(System.Data.DataRow R){
			string idupb=R["idupb"].ToString();
		    if (idupb == "") return;
			bool FinAssured=false;
		    if (DS.upb.Select(QHC.CmpEq("idupb", idupb)).Length == 0) {
		        Meta.LogError("UPB di ID " + idupb + " non trovato.");
		        MessageBox.Show("UPB di ID " + idupb + " non trovato.", "Errore");
		        return;
		    }
            System.Data.DataRow UPBRow= DS.upb.Select(QHC.CmpEq("idupb",idupb))[0];
			if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
            System.Data.DataRow config = DS.config.Rows[0];
            bool usaCrediti = config["flagcredit"].ToString().ToUpper() == "S";
            bool usaCassa = config["flagproceeds"].ToString().ToUpper() == "S";

			decimal previsionvariation=0;
			decimal secondaryprevvariation=0;
            decimal revenuevariation = 0;
			decimal creditvariation=0;
			decimal cashvariation=0;
			string finpart= "";

            string filteridfin = QHC.CmpEq("idfin", R["idfin"]);
		    if (MyBilancio.Select(filteridfin).Length == 0) {
                Meta.LogError("Voce Bilancio di ID " + R["idfin"] + " non trovata.");
                MessageBox.Show("Voce Bilancio di ID " + R["idfin"] + " non trovata.", "Errore");
                return;
		    }

            System.Data.DataRow MyFin = MyBilancio.Select(filteridfin)[0];
            int flag = CfgFn.GetNoNullInt32(MyFin["flag"]);
            if ((flag & 1) == 0) {
                finpart = "E";
            }
            else {
                finpart = "S";
            } 

			if (finpart=="S"){
				if (!FinAssured){
                    if (assestapresunto) {
                        switch (tipoprincipale) {

                            case "C": {
                                previsionvariation = CfgFn.GetNoNullDecimal(R["actualcreditsurplus"]) -
                                    CfgFn.GetNoNullDecimal(R["supposedcredits"]);
                                creditvariation = previsionvariation;
                                break;
                            }
                            case "S": {
                                previsionvariation = CfgFn.GetNoNullDecimal(R["actualcashsurplus"]) -
                                    CfgFn.GetNoNullDecimal(R["supposedcash"]);
                                cashvariation = previsionvariation;
                                break;
                            }
                        }
                        switch (tiposecondaria) {
                            case "S": {
                                secondaryprevvariation = CfgFn.GetNoNullDecimal(R["actualcashsurplus"]) -
                                    CfgFn.GetNoNullDecimal(R["supposedcash"]);
                                cashvariation = secondaryprevvariation;
                                revenuevariation = CfgFn.GetNoNullDecimal(R["revenue"]) -
                                    CfgFn.GetNoNullDecimal(R["supposedrevenue"]);
                                break;
                            }
                            default:
                            cashvariation = CfgFn.GetNoNullDecimal(R["actualcashsurplus"]) -
                                CfgFn.GetNoNullDecimal(R["supposedcash"]);
                            break;

                        }
                    }
                    else {
                        previsionvariation = CfgFn.GetNoNullDecimal(R["actualavailableprev"]);
                        cashvariation = CfgFn.GetNoNullDecimal(R["actualcashsurplus"]) -
                                                             CfgFn.GetNoNullDecimal(R["supposedcash"]);
                    }
				}
				else {
                    if (assestapresunto) {
                        previsionvariation = CfgFn.GetNoNullDecimal(R["actualavailableprev"]) - 
                                             CfgFn.GetNoNullDecimal(R["supposedavailableprev"]) ;
                        secondaryprevvariation = previsionvariation +
                                                 CfgFn.GetNoNullDecimal(R["expenditure"]) - 
                                                 CfgFn.GetNoNullDecimal(R["supposedexpenditure"]);
                    }
                    else {
                        previsionvariation = CfgFn.GetNoNullDecimal(R["actualavailableprev"]);
                    }
				}
			}
			else {
                if (FinAssured) {
                    if (assestapresunto) {
                        previsionvariation = CfgFn.GetNoNullDecimal(R["actualavailableprev"]) -
                                             CfgFn.GetNoNullDecimal(R["supposedavailableprev"]);
                        secondaryprevvariation = previsionvariation
                                    + CfgFn.GetNoNullDecimal(R["revenue"])
                                    - CfgFn.GetNoNullDecimal(R["supposedrevenue"]);
                                    
                    }
                    else {
                        previsionvariation = CfgFn.GetNoNullDecimal(R["actualavailableprev"]);
                    }
                }
                else {
                    if (!assestapresunto) {
                        previsionvariation = CfgFn.GetNoNullDecimal(R["actualavailableprev"]);
                    }
                    else {
                        if (tiposecondaria == "S") {
                            revenuevariation = CfgFn.GetNoNullDecimal(R["revenue"]) -
                                CfgFn.GetNoNullDecimal(R["supposedrevenue"]);
                        }
                    }
                }
			}
			R["previsionvariation"]=previsionvariation;
			R["secondaryprevvariation"]=secondaryprevvariation;
			if (usaCrediti)  R["creditvariation"]=creditvariation;
			if (usaCassa)    R["cashvariation"]=cashvariation;
            R["!revenuevariation"] = revenuevariation;
	}

		void GetSPTableToDS(DataTable SPTable){
			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();

            // Cancellazione della voce di bilancio che totalizza l'avanzo di cassa
            // nel caso di !assestapresunto
            if (!assestapresunto) {
                string fEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
                object idFinAvanzo = Meta.Conn.DO_READ_VALUE("config", fEsercizio, "idfinincomesurplus");
                string f = QHC.CmpEq("idfin", idFinAvanzo);
                if (SPTable.Select(f).Length > 0) {
                    System.Data.DataRow rAvanzo = SPTable.Select(f)[0];
                    rAvanzo.Delete();
                    SPTable.AcceptChanges();
                }
            }

			System.Data.DataRow CurrPrev=  DS.finbalance.Rows[0];


            foreach (System.Data.DataRow RDS in DS.finbalancedetail.Select()) {
                string filter = QHC.MCmp(RDS, "idfin", "idupb");
                System.Data.DataRow[] Found = SPTable.Select(filter);
                if (Found.Length == 0) {
                    RDS["actualcreditsurplus"] = DBNull.Value;
                    RDS["actualcashsurplus"] = DBNull.Value;
                    RDS["supposedcredits"] = DBNull.Value;
                    RDS["supposedcash"] = DBNull.Value;
                    RDS["revenue"] = DBNull.Value;
                    RDS["expenditure"] = DBNull.Value;
                    RDS["previsionvariation"] = DBNull.Value;
                    RDS["secondaryprevvariation"] = DBNull.Value;
                    RDS["creditvariation"] = DBNull.Value;
                    RDS["cashvariation"] = DBNull.Value;
                    RDS["supposedrevenue"] = DBNull.Value;
                    RDS["supposedexpenditure"] = DBNull.Value;
                    RDS["supposedavailableprev"] = DBNull.Value;
                    RDS["actualavailableprev"] = DBNull.Value;
                }
            }



            //Deve adeguare DS.finbalancedetail al contenuto delle tabelle temporanee
			foreach (System.Data.DataRow RE in SPTable.Rows){
				//Quattro casi: la riga in DS Ë da modificare, cancellare, creare, ripristinare!
                string filter = QHC.MCmp(RE, "idfin", "idupb");
				System.Data.DataRow []Found=DS.finbalancedetail.Select(filter);
				//Vede se Ë da cancellare
				if (TuttoZero(RE)){
					//E' da cancellare, se c'Ë
					if (Found.Length>0){
						Found[0].Delete();
					}
					continue; 
				}
				//Vede se Ë da ripristinare 
				if (Found.Length==0){
					System.Data.DataRow []Deleted= DS.finbalancedetail.Select(filter,null,DataViewRowState.Deleted);
					if (Deleted.Length>0){
						Deleted[0].RejectChanges();
						Found=DS.finbalancedetail.Select(filter);
					}
				}
				//Vede se Ë da creare
				if (Found.Length==0){
					System.Data.DataRow NewRow= DS.finbalancedetail.NewRow();
					NewRow["idupb"]= RE["idupb"];
					NewRow["idfin"]= RE["idfin"];
					NewRow["codefin"]= RE["codefin"];
					NewRow["ayear"]=CurrPrev["ayear"];
					NewRow["nfinbalance"]=CurrPrev["nfinbalance"];

					DS.finbalancedetail.Rows.Add(NewRow);
					Found=DS.finbalancedetail.Select(filter);
				}
				//A questo punto Ë da modificare
				System.Data.DataRow Curr=Found[0];
                Curr.BeginEdit();
                foreach (DataColumn C in DS.finbalancedetail.Columns) {
					if (C.DataType!=typeof(decimal))continue;
					if (!SPTable.Columns.Contains(C.ColumnName))continue;
					if (C.ReadOnly){
						C.ReadOnly=false;
						Curr[C.ColumnName]=RE[C.ColumnName];
						C.ReadOnly=true;
					}
					else {
						Curr[C.ColumnName]=RE[C.ColumnName];
					}
				}
                Curr.EndEdit();
                CalculateVariations(Curr);

				//Elimina false modifiche se ve ne sono
				if (Curr.RowState==DataRowState.Modified){
					if (PostData.CheckForFalseUpdate(Curr))Curr.AcceptChanges();
				}

			}

			Cursor.Current = Cursors.Default;

		}


		void GetTempTableToDS(DataTable TempTable){

			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();

			System.Data.DataRow Main = DS.finbalance.Rows[0];
			MetaData metaFinBalDet= MetaData.GetMetaData(this,"finbalancedetail");
			metaFinBalDet.SetDefaults(DS.finbalancedetail);
			//Deve adeguare DS.prevfindetail al contenuto delle tabelle temporanee
			foreach (System.Data.DataRow RE in TempTable.Rows){
				RE.EndEdit();
				if (RE.RowState== DataRowState.Unchanged) continue;
				//Quattro casi: la riga in DS Ë da modificare, cancellare, creare, ripristinare!
                string filter = QHC.AppAnd(QHC.CmpEq("idfin", RE["idfin"]), QHC.CmpEq("idupb", curridupb));
                System.Data.DataRow[] Found = DS.finbalancedetail.Select(filter);
				//Vede se Ë da cancellare
				if (TuttoZero(RE)){
					//E' da cancellare, se c'Ë
					if (Found.Length>0){
                        RE["actualcreditsurplus"] = DBNull.Value;
                        RE["actualcashsurplus"] = DBNull.Value;
                        RE["supposedcredits"] = DBNull.Value;
                        RE["supposedcash"] = DBNull.Value;
                        RE["revenue"] = DBNull.Value;
                        RE["expenditure"] = DBNull.Value;
                        RE["previsionvariation"] = DBNull.Value;
                        RE["secondaryprevvariation"] = DBNull.Value;
                        RE["creditvariation"] = DBNull.Value;
                        RE["cashvariation"] = DBNull.Value;
                        RE["supposedrevenue"] = DBNull.Value;
                        RE["supposedexpenditure"] = DBNull.Value;
                        RE["supposedavailableprev"] = DBNull.Value;
                        RE["actualavailableprev"] = DBNull.Value;

					}
					continue; 
				}
				//Vede se Ë da ripristinare 
				if (Found.Length==0){
					System.Data.DataRow []Deleted= DS.finbalancedetail.Select(filter,null,DataViewRowState.Deleted);
					if (Deleted.Length>0){
						Deleted[0].RejectChanges();
						Found=DS.finbalancedetail.Select(filter);
					}
				}
				//Vede se Ë da creare
				if (Found.Length==0){
					System.Data.DataRow NewRow= metaFinBalDet.Get_New_Row(Main,DS.finbalancedetail);					
					NewRow["idupb"]= curridupb;
					NewRow["idfin"]= RE["idfin"];
					NewRow["codefin"]= RE["codefin"];
					//DS.prevfindetail.Rows.Add(NewRow);
					Found=DS.finbalancedetail.Select(filter);
				}
				//A questo punto Ë da modificare
				System.Data.DataRow Curr=Found[0];
                Curr.BeginEdit();
                foreach (DataColumn C in DS.finbalancedetail.Columns) {
					if (!TempTable.Columns.Contains(C.ColumnName))continue;
					if (C.DataType!=typeof(decimal))continue;
					if (C.ReadOnly){
						C.ReadOnly=false;
						Curr[C.ColumnName]=RE[C.ColumnName];
						C.ReadOnly=true;
					}
					else {
						Curr[C.ColumnName]=RE[C.ColumnName];
					}
				}
                Curr.EndEdit();
                //Elimina false modifiche se ve ne sono
				if (Curr.RowState==DataRowState.Modified){
					if (PostData.CheckForFalseUpdate(Curr))Curr.AcceptChanges();
				}

			}
			Cursor.Current= Cursors.Default;

		}

		void CopyXceedtoDS(){
			if (curridupb==DBNull.Value) return;
			if (DoConsolida) return;



            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            GetTempTableToDS(DS2.finbalancedetail);
			GetTempTableToDS(DS3.finbalancedetail);
            Cursor.Current = Cursors.Default;
        }


		void SvuotaTotali() {
			bool FinAssured=false;
			if (curridupb!=DBNull.Value){
				System.Data.DataRow UPBRow= DS.upb.Select(
					"(idupb="+QueryCreator.quotedstrvalue(curridupb,false)+")")[0];
				if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
			}

            txtAvanzoAmministrazioneEff.Visible = !SolaCassa && !FinAssured;
            lblAvanzoAmministrazioneEff.Visible = !SolaCassa && !FinAssured;
            txtDotazioneCreditiPres.Visible = !SolaCassa && !FinAssured;
            lblDotazioneCreditiPres.Visible = !SolaCassa && !FinAssured;
            txtResiduiAttivi.Visible = !SolaCassa;
            lblResiduiAttivi.Visible = !SolaCassa;
            txtResiduiPassivi.Visible = !SolaCassa;
            lblResiduiPassivi.Visible = !SolaCassa;
            txtResiduiAttiviPresunti.Visible = !SolaCassa;
            lblResiduiAttiviPresunti.Visible = !SolaCassa;
            txtResiduiPassiviPresunti.Visible = !SolaCassa;
            lblResiduiPassiviPresunti.Visible = !SolaCassa;
            lblDotazioneCassaPres.Visible = AbilitaColonneCassa && assestapresunto;
            txtDotazioneCassaPres.Visible = AbilitaColonneCassa && assestapresunto;
            txtVarAssestamentoDotCrediti.Visible = !SolaCassa && !FinAssured;
            lblVarAssestamentoDotCrediti.Visible = !SolaCassa && !FinAssured;
            lblVarAssestamentoPrevPrinc_E.Visible = true;
            txtVarAssestamentoPrevPrincEntrata.Visible = true;
			lblVarAssestamentoPrevSec_E.Visible= !SolaCassa && AbilitaColonneCassa;
			txtVarAssestamentoPrevSecEntrata.Visible= !SolaCassa && AbilitaColonneCassa;

			labSupposedPrevDisp_E.Visible= FinAssured;
			txtSupposedPrevDisp_E.Visible=FinAssured;
			labActualPrevDisp_E.Visible=FinAssured;
			txtActualPrevDisp_E.Visible=FinAssured;

			labSupposedPrevDisp_S.Visible= FinAssured;
			txtSupposedPrevDisp_S.Visible=FinAssured;
			labActualPrevDisp_S.Visible=FinAssured;
			txtActualPrevDisp_S.Visible=FinAssured;

            txtVarResAttivi.Visible = !FinAssured && assestapresunto && AbilitaColonneCassa;
            lblVarResAttivi.Visible = !FinAssured && assestapresunto && AbilitaColonneCassa;

			if (!(AbilitaColonneCassa && AbilitaColonneCompetenza)) {
				txtVarAssestamentoPrevSec.Visible = false;
				lblVarAssestamentoPrevSec.Visible = false;
			}

			txtAvanzoCassaEff.Text = "";
			txtAvanzoAmministrazioneEff.Text = "";
			txtDotazioneCreditiPres.Text = "";
			txtDotazioneCassaPres.Text = "";
			txtResiduiAttivi.Text = "";
			txtResiduiPassivi.Text = "";
			txtVarAssestamentoPrevPrinc.Text = "";
			txtVarAssestamentoPrevSec.Text = "";
			txtVarAssestamentoDotCassa.Text = "";
			txtVarAssestamentoDotCrediti.Text = "";
			txtVarAssestamentoPrevPrincEntrata.Text="";
			txtVarAssestamentoPrevSecEntrata.Text="";

			txtSupposedPrevDisp_E.Text="";
			txtActualPrevDisp_E.Text="";
			txtSupposedPrevDisp_S.Text="";
			txtActualPrevDisp_S.Text="";
            txtVarResAttivi.Text = "";

			avanzoCassaEff = 0;
			avanzoAmministrazioneEff = 0;
			dotazioneCreditiPres = 0;
			dotazioneCassaPres = 0;

			totResiduiAttivi = 0;
			totResiduiPassivi = 0;
			totVarAssPrevPrinc = 0;
			totVarAssPrevSec = 0;
			totVarDotCassa = 0;
			totVarDotCrediti = 0;
			totVarAssPrevPrinc_E=0;
			totVarAssPrevSec_E=0;
			totActAvailPrev_E=0;
			totActAvailPrev_S=0;
			totSuppAvailPrev_E=0;
			totSuppAvailPrev_S=0;



		}

		void RicalcolaTotali() {
			avanzoCassaEff = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"actualcashsurplus"));
			avanzoAmministrazioneEff = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"actualcreditsurplus"));
			dotazioneCreditiPres = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"supposedcredits"));
			dotazioneCassaPres = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"supposedcash"));
			totResiduiAttivi = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"revenue"));
			totResiduiPassivi = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"expenditure"));
			totVarDotCassa = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"cashvariation"));
			totVarDotCrediti = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"creditvariation"));
			totVarAssPrevPrinc = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"previsionvariation"));
			totVarAssPrevSec = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"secondaryprevvariation"));
			
			totSuppAvailPrev_E = CfgFn.RoundValuta(MetaData.SumColumn(DS3.finbalancedetail,"supposedavailableprev"));
			totActAvailPrev_E = CfgFn.RoundValuta(MetaData.SumColumn(DS3.finbalancedetail,"actualavailableprev"));
			totSuppAvailPrev_S = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"supposedavailableprev"));
			totActAvailPrev_S = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"actualavailableprev"));

            totVarAssPrevPrinc_E = CfgFn.RoundValuta(MetaData.SumColumn(DS3.finbalancedetail, "previsionvariation"));
            totVarAssPrevSec_E = CfgFn.RoundValuta(MetaData.SumColumn(DS3.finbalancedetail, "secondaryprevvariation"));
            
            totVarResiduiAttivi = CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail, "!revenuevariation"));

			decimal totrespres_E=CfgFn.RoundValuta(MetaData.SumColumn(DS3.finbalancedetail,"supposedrevenue"));
			decimal totrespres_S=CfgFn.RoundValuta(MetaData.SumColumn(DS2.finbalancedetail,"supposedexpenditure"));
			


			txtAvanzoCassaEff.Text = avanzoCassaEff.ToString("c");
			txtAvanzoAmministrazioneEff.Text = avanzoAmministrazioneEff.ToString("c");
			txtDotazioneCreditiPres.Text = dotazioneCreditiPres.ToString("c");
			txtDotazioneCassaPres.Text = dotazioneCassaPres.ToString("c");
			txtResiduiAttivi.Text = totResiduiAttivi.ToString("c");
			txtResiduiPassivi.Text = totResiduiPassivi.ToString("c");
			txtVarAssestamentoPrevPrinc.Text = totVarAssPrevPrinc.ToString("c");
			txtVarAssestamentoPrevSec.Text = totVarAssPrevSec.ToString("c");
			txtVarAssestamentoDotCassa.Text = totVarDotCassa.ToString("c");
			txtVarAssestamentoDotCrediti.Text = totVarDotCrediti.ToString("c");

            txtVarAssestamentoPrevPrincEntrata.Text = totVarAssPrevPrinc_E.ToString("c");
            txtVarAssestamentoPrevSecEntrata.Text = totVarAssPrevSec_E.ToString("c");

			txtActualPrevDisp_E.Text= totActAvailPrev_E.ToString("c");
			txtActualPrevDisp_S.Text= totActAvailPrev_S.ToString("c");
			txtSupposedPrevDisp_E.Text= totSuppAvailPrev_E.ToString("c");
			txtSupposedPrevDisp_S.Text= totSuppAvailPrev_S.ToString("c");
			txtResiduiAttiviPresunti.Text= totrespres_E.ToString("c");
			txtResiduiPassiviPresunti.Text= totrespres_S.ToString("c");
            txtVarResAttivi.Text = totVarResiduiAttivi.ToString("c");
		}

		public void MetaData_AfterFill() {
			RicalcolaTotali();
		}


		public void MetaData_BeforeFill() {
			btnRicalcola.Enabled=true;
			btnSalvaDatiPrevisione.Enabled=Meta.CanSave;

			if (Meta.FirstFillForThisRow) {
                foreach (System.Data.DataRow r in DS.finbalancedetail.Rows) {
                    CalculateVariations(r);
                }
				CopyDStoXceed();
			}
		}

		public void MetaData_AfterGetFormData() {			
			CopyXceedtoDS();
		}

		void ImpostaHeaders() {

			bool Disabled= (curridupb==DBNull.Value) || DoConsolida;
			bool FinAssured=false;
            if (curridupb != DBNull.Value) {
				System.Data.DataRow UPBRow= DS.upb.Select(
					"(idupb="+QueryCreator.quotedstrvalue(curridupb,false)+")")[0];
				if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
			}

            // Grid riferito a SPESA
			colcodicebilancio.Title = "Cod.Bil.";
			colcodicebilancio.CanBeSorted = false;
			colcodicebilancio.CanBeGrouped = false;
			colcodicebilancio.BackColor = Color.GreenYellow;
			colcodicebilancio.ReadOnly = true;
			colcodefin.VisibleIndex= 1;

			coldenominazione.Title = "Denominazione";
			coldenominazione.CanBeSorted = false;
			coldenominazione.CanBeGrouped = false;
			coldenominazione.ReadOnly = true;
			coldenominazione.BackColor = Color.YellowGreen;
			coldenominazione.VisibleIndex= 2;

			coldotazionecassapresunta.Title= "Avanzo cassa presunto";
			coldotazionecassapresunta.CanBeSorted=false;
			coldotazionecassapresunta.CanBeGrouped=false;
			coldotazionecassapresunta.BackColor= Color.Salmon;
			coldotazionecassapresunta.Width=80;
			coldotazionecassapresunta.ReadOnly = true;
			coldotazionecassapresunta.Visible= !FinAssured && assestapresunto;
			coldotazionecassapresunta.VisibleIndex=3;

			coldotazionecreditipresunta.Title =	"Avanzo Ammin. Presunto";
			coldotazionecreditipresunta.CanBeSorted=false;
			coldotazionecreditipresunta.CanBeGrouped=false;
			coldotazionecreditipresunta.BackColor= Color.Tomato;
			coldotazionecreditipresunta.Width=90;
			coldotazionecreditipresunta.ReadOnly = true;
			coldotazionecreditipresunta.Visible= !FinAssured && AbilitaColonneCompetenza && assestapresunto;
			coldotazionecreditipresunta.VisibleIndex=4;

			colsupposedrevenue1.Title =	"Residui Attivi Presunti";
			colsupposedrevenue1.CanBeSorted=false;
			colsupposedrevenue1.CanBeGrouped=false;
			colsupposedrevenue1.BackColor= Color.Yellow;
			colsupposedrevenue1.Width=80;
			colsupposedrevenue1.Visible= !FinAssured && AbilitaColonneCompetenza && assestapresunto;
			colsupposedrevenue1.VisibleIndex=6;
			colsupposedrevenue1.ReadOnly = true;

			colresiduiattivi.Title =	"Residui Attivi";
			colresiduiattivi.CanBeSorted=false;
			colresiduiattivi.CanBeGrouped=false;
			colresiduiattivi.BackColor= Color.Yellow;
			colresiduiattivi.Width=80;
			colresiduiattivi.Visible= !FinAssured && AbilitaColonneCompetenza && assestapresunto;
			colresiduiattivi.VisibleIndex=5;

			colsupposedexpenditure1.Title =	"Residui Passivi Presunti";
			colsupposedexpenditure1.CanBeSorted=false;
			colsupposedexpenditure1.CanBeGrouped=false;
			colsupposedexpenditure1.BackColor= Color.Yellow;
			colsupposedexpenditure1.Width=85;
			colsupposedexpenditure1.ReadOnly = true;
			colsupposedexpenditure1.Visible= FinAssured && assestapresunto;
			colsupposedexpenditure1.VisibleIndex=8;

			colresiduipassivi.Title =	"Residui Passivi";
			colresiduipassivi.CanBeSorted=false;
			colresiduipassivi.CanBeGrouped=false;
			colresiduipassivi.BackColor= Color.Yellow;
			colresiduipassivi.Width=80;
			colresiduipassivi.ReadOnly = true;
			colresiduipassivi.Visible= (FinAssured || AbilitaColonneCompetenza) && assestapresunto;
			colresiduipassivi.VisibleIndex=7;

            // colonna di Prev. Attuale Effettiva (solo !assegnapresunto)
            colactualprev.Title = "Prev. Attuale Effettiva";
            colactualprev.CanBeSorted = false;
            colactualprev.CanBeGrouped = false;
            colactualprev.BackColor = Color.Yellow;
            colactualprev.Width = 80;
            colactualprev.ReadOnly = true;
            colactualprev.Visible = !assestapresunto;
            colactualprev.VisibleIndex = 9;

            // colonna di Cassa Assegnato (solo !assegnapresunto)
            colcassaassegnato.Title = "Cassa Assegnato";
            colcassaassegnato.CanBeSorted = false;
            colcassaassegnato.CanBeGrouped = false;
            colcassaassegnato.BackColor = Color.Yellow;
            colcassaassegnato.Width = 80;
            colcassaassegnato.ReadOnly = true;
            colcassaassegnato.Visible = !assestapresunto;
            colcassaassegnato.VisibleIndex = 10;

            // colonna di Pagamenti (solo !assegnapresunto)
            colpagamenti.Title = "Pagamenti";
            colpagamenti.CanBeSorted = false;
            colpagamenti.CanBeGrouped = false;
            colpagamenti.BackColor = Color.Yellow;
            colpagamenti.Width = 80;
            colpagamenti.ReadOnly = true;
            colpagamenti.Visible = !assestapresunto;
            colpagamenti.VisibleIndex = 11;

            string lab_avanzocassaeffettivo = (assestapresunto) ? "Avanzo Cassa Effettivo" :
                "Cassa Residua";
            colavanzocassaeffettivo.Title = lab_avanzocassaeffettivo;
			colavanzocassaeffettivo.CanBeSorted=false;
			colavanzocassaeffettivo.CanBeGrouped=false;
			colavanzocassaeffettivo.BackColor= Color.Salmon;
			colavanzocassaeffettivo.Width=85;
			colavanzocassaeffettivo.ReadOnly = true;
			colavanzocassaeffettivo.Visible= !FinAssured;
			colavanzocassaeffettivo.VisibleIndex=12;

			colavanzoamministrazioneeffettivo.Title = "Avanzo Ammin. Effettivo";
			colavanzoamministrazioneeffettivo.CanBeSorted=false;
			colavanzoamministrazioneeffettivo.CanBeGrouped=false;
			colavanzoamministrazioneeffettivo.BackColor= Color.Tomato;
			colavanzoamministrazioneeffettivo.Width=90;
			colavanzoamministrazioneeffettivo.ReadOnly = true;
			colavanzoamministrazioneeffettivo.Visible= !FinAssured && AbilitaColonneCompetenza && assestapresunto;
			colavanzoamministrazioneeffettivo.VisibleIndex=13;


			colsupposedavailableprev1.Title = "Prev. Disponibile Presunta";
			colsupposedavailableprev1.CanBeSorted=false;
			colsupposedavailableprev1.CanBeGrouped=false;
			colsupposedavailableprev1.BackColor= Color.Tomato;
			colsupposedavailableprev1.Width=85;
			colsupposedavailableprev1.ReadOnly = true;
			colsupposedavailableprev1.Visible= FinAssured && assestapresunto;
			colsupposedavailableprev1.VisibleIndex=15;

			colactualavailableprev1.Title = "Prev. Disponibile Effettiva";
			colactualavailableprev1.CanBeSorted=false;
			colactualavailableprev1.CanBeGrouped=false;
			colactualavailableprev1.BackColor= Color.Tomato;
			colactualavailableprev1.Width=85;
			colactualavailableprev1.ReadOnly = true;
			colactualavailableprev1.Visible= FinAssured || !assestapresunto ;
			colactualavailableprev1.VisibleIndex=14;


			string varPrincipale = "";
			string varSecondaria = "";

			if (campoprevcompetenza != null) {
				if (campoprevcompetenza == "prevision") {
					varPrincipale = "Var. Prev. Competenza";
				}
				if (campoprevcompetenza == "secondaryprev") {
					varSecondaria = "Var. Prev. Competenza";
				}
			}

			if (campoprevcassa != null) {
				if (campoprevcassa == "prevision") {
					varPrincipale = "Var. Prev. Cassa";
				}
				if (campoprevcassa == "secondaryprev") {
					varSecondaria = "Var. Prev. Cassa";
				}
			}

			colvarprevisioneprincipale.Title = varPrincipale;
			colvarprevisioneprincipale.CanBeSorted=false;
			colvarprevisioneprincipale.CanBeGrouped=false;
			colvarprevisioneprincipale.BackColor= Color.Wheat;
			colvarprevisioneprincipale.Width=80;
			colvarprevisioneprincipale.ReadOnly = true;
			colvarprevisioneprincipale.Visible= true;
			colvarprevisioneprincipale.VisibleIndex=15;

			colvarprevisionesecondaria.Title = varSecondaria;
			colvarprevisionesecondaria.CanBeSorted=false;
			colvarprevisionesecondaria.CanBeGrouped=false;
			colvarprevisionesecondaria.BackColor= Color.Wheat;
			colvarprevisionesecondaria.Width=80;
			colvarprevisionesecondaria.ReadOnly = true;
			colvarprevisionesecondaria.Visible= true;
			colvarprevisionesecondaria.VisibleIndex=16;

			colvardotazionecrediti.Title = "Var. Dotazione Crediti";
			colvardotazionecrediti.CanBeSorted=false;
			colvardotazionecrediti.CanBeGrouped=false;
			colvardotazionecrediti.BackColor= Color.Wheat;
			colvardotazionecrediti.Width=85;
			colvardotazionecrediti.ReadOnly = true;
			colvardotazionecrediti.Visible= !FinAssured && AbilitaColonneCompetenza && assestapresunto;
			colvardotazionecrediti.VisibleIndex=17;

			colvardotazionecassa.Title = "Var. Dotazione Cassa";
			colvardotazionecassa.CanBeSorted=false;
			colvardotazionecassa.CanBeGrouped=false;
			colvardotazionecassa.BackColor= Color.Wheat;
			colvardotazionecassa.Width=85;
			colvardotazionecassa.ReadOnly = true;
			colvardotazionecassa.Visible= !FinAssured;
			colvardotazionecassa.VisibleIndex=18;

            // colonna di Var. ai residui attivi (solo assegnapresunto)
            colvarresiduiattivi.Title = "Var. Residui Attivi";
            colvarresiduiattivi.CanBeSorted = false;
            colvarresiduiattivi.CanBeGrouped = false;
            colvarresiduiattivi.BackColor = Color.Wheat;
            colvarresiduiattivi.Width = 85;
            colvarresiduiattivi.ReadOnly = true;
            colvarresiduiattivi.Visible = assestapresunto && AbilitaColonneCompetenza;
            colvarresiduiattivi.VisibleIndex = 19;

            // Sezione di mascheramento delle colonne che non devono mai apparire nei grid
            // in questa sezione rendiamo nascoste colonne come le ct, cu, lt, lu
            // e le colonne che devono comparire solo in uno dei due grid
			colidbilancio.Visible=false;
			colct.Visible=false;
			colcu.Visible=false;
			collu.Visible=false;
			collt.Visible=false;

			colidfin.Visible=false;
			colct1.Visible=false;
			colcu1.Visible=false;
			collu1.Visible=false;
			collt1.Visible=false;

			colsupposedcash.Visible=false;
			colsupposedcredits.Visible=false;
			colactualcashsurplus.Visible=false;
			colactualcreditsurplus.Visible=false;
			colcreditvariation.Visible=false;
			colcashvariation.Visible=false;
			colsupposedexpenditure.Visible=false;
			colexpenditure.Visible=false;
            colpayment.Visible = false;
            colproceeds.Visible = false;
            colassignedcash.Visible = false;
            // Fine sezione mascheramento colonne

            // Grid riferito ad ENTRATA
			colcodefin.Title = "Cod.Bil.";
			colcodefin.CanBeSorted = false;
			colcodefin.CanBeGrouped = false;
			colcodefin.BackColor = Color.GreenYellow;
			colcodefin.ReadOnly = true;
			colcodefin.VisibleIndex= 1;

			coltitle.Title = "Denominazione";
			coltitle.CanBeSorted = false;
			coltitle.CanBeGrouped = false;
			coltitle.ReadOnly = true;
			coltitle.BackColor = Color.YellowGreen;
			coltitle.VisibleIndex= 2;

			colsupposedrevenue.Title= "Res. Attivi presunti";
			colsupposedrevenue.CanBeSorted = false;
			colsupposedrevenue.CanBeGrouped = false;
			colsupposedrevenue.ReadOnly = true;
			colsupposedrevenue.BackColor = Color.Yellow;
            colsupposedrevenue.Visible = assestapresunto;
			colsupposedrevenue.VisibleIndex= 4;

			colrevenue.Title="Res. Attivi Effettivi";
			colrevenue.CanBeSorted = false;
			colrevenue.CanBeGrouped = false;
			colrevenue.ReadOnly = true;
			colrevenue.BackColor = Color.Yellow;
            colrevenue.Visible = assestapresunto;
			colrevenue.VisibleIndex= 3;

            // colonna di Prev. Attuale Effettiva (solo !assegnapresunto)
            colactualprev1.Title = "Prev. Attuale Effettiva";
            colactualprev1.CanBeSorted = false;
            colactualprev1.CanBeGrouped = false;
            colactualprev1.BackColor = Color.Yellow;
            colactualprev1.Width = 80;
            colactualprev1.ReadOnly = true;
            colactualprev1.Visible = !assestapresunto;
            colactualprev1.VisibleIndex = 5;

            // colonna di Incassi (solo !assegnapresunto)
            colincassi.Title = "Incassi";
            colincassi.CanBeSorted = false;
            colincassi.CanBeGrouped = false;
            colincassi.BackColor = Color.Yellow;
            colincassi.Width = 80;
            colincassi.ReadOnly = true;
            colincassi.Visible = !assestapresunto;
            colincassi.VisibleIndex = 6;

			colsupposedavailableprev.Title="Prev. Disponibile Presunta";
			colsupposedavailableprev.CanBeSorted = false;
			colsupposedavailableprev.CanBeGrouped = false;
			colsupposedavailableprev.ReadOnly = true;
			colsupposedavailableprev.BackColor = Color.Tomato;
            colsupposedavailableprev.Visible = assestapresunto;
			colsupposedavailableprev.VisibleIndex= 7;

			colactualavailableprev.Title="Prev. Disponibile Effettiva";
			colactualavailableprev.CanBeSorted = false;
			colactualavailableprev.CanBeGrouped = false;
			colactualavailableprev.ReadOnly = true;
			colactualavailableprev.BackColor = Color.Tomato;
			colactualavailableprev.VisibleIndex= 8;


			colprevisionvariation.Title=varPrincipale;
			colprevisionvariation.CanBeSorted = false;
			colprevisionvariation.CanBeGrouped = false;
			colprevisionvariation.ReadOnly = false;
			colprevisionvariation.BackColor = Color.Wheat;
			colprevisionvariation.VisibleIndex= 9;

			colsecondaryprevvariation.Title= varSecondaria;
			colsecondaryprevvariation.CanBeSorted = false;
			colsecondaryprevvariation.CanBeGrouped = false;
			colsecondaryprevvariation.ReadOnly = false;
			colsecondaryprevvariation.BackColor = Color.Wheat;
            colsecondaryprevvariation.Visible = assestapresunto;
			colsecondaryprevvariation.VisibleIndex= 10;

            // colonna di Var. ai residui attivi (solo assegnapresunto)
            colrevenuevariation.Title = "Var. Residui Attivi";
            colrevenuevariation.CanBeSorted = false;
            colrevenuevariation.CanBeGrouped = false;
            colrevenuevariation.BackColor = Color.Wheat;
            colrevenuevariation.Width = 85;
            colrevenuevariation.ReadOnly = true;
            colrevenuevariation.Visible = assestapresunto && AbilitaColonneCompetenza;
            colrevenuevariation.VisibleIndex = 11;

			// Se non mi trovo in una gestione mista la previsione secondaria non esiste
			if (!(AbilitaColonneCassa  && AbilitaColonneCompetenza)) {
				colvarprevisionesecondaria.Visible = false;
				colsecondaryprevvariation.Visible=false;
			}

		}

		void AddDescriptions() {
			foreach(System.Data.DataRow R in DS2.finbalancedetail.Rows) {
				string idbilancio= R["idfin"].ToString();
				string filter= "(idfin='"+idbilancio+"')";
				System.Data.DataRow []found = MyBilancio.Select(filter);
				if (found.Length==0) continue;
				R["title"]= found[0]["title"];
			}
		}
		private void btnRicalcola_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
            object liv = Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear", Meta.GetSys("esercizio")), "MAX(nlevel)");
            System.Data.DataRow Curr = DS.finbalance.Rows[0];
			object DataAss= Curr["balancedate"];
			if (DataAss == DBNull.Value) {
				MessageBox.Show("E' necessario specificare la data di assestamento");
				return;
			}

			Cursor.Current= Cursors.WaitCursor;
			Application.DoEvents();
			DataSet D = Conn.CallSP("compute_finbalance",
				new object[]{Meta.GetSys("esercizio"),liv},true,600);
			Cursor.Current= Cursors.Default;
			if (D==null) return;
			if (D.Tables.Count==0) return;
			DataTable T = D.Tables[0];
			if (T==null) return;
			GetSPTableToDS(T);

			CopyDStoXceed(); 
			RicalcolaTotali();
		}

		int ConvertPositionToIndex(Xceed.Grid.GridControl DG, DataTable DT, int Position, bool AbilitaGruppi)
		{
			int count=0;
			foreach (DataColumn C in DT.Columns)
			{
				if (DG.Columns[C.ColumnName].Visible)
				{
					if (DG.Columns[C.ColumnName].VisibleIndex<=Position)
						count++;
				}
			}
			return count;
		}


		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			if (Meta.IsEmpty)return;
			DataTable DT;
            Xceed.Grid.GridControl DG;
            if (tabControl1.SelectedTab == tabEntrata) {
                DT = DS3.finbalancedetail;
                DG = gridControl2;
            }
            else {
                DT = DS2.finbalancedetail;
                DG = gridControl1;
            }


			foreach (DataColumn C in DT.Columns)
			{
				int pos;
				if (DG.Columns[C.ColumnName].Visible)				
					pos= ConvertPositionToIndex(DG, DT, DG.Columns[C.ColumnName].VisibleIndex,false);
				else
					pos=-1;
				C.ExtendedProperties["ListColPos"]= pos;
				if (pos==-1)
				{
					C.ExtendedProperties["ExcelTitle"]= null;
				}
				else 
				{
					C.ExtendedProperties["ExcelTitle"]= DG.Columns[C.ColumnName].Title;
				}
			}

			string ExcelSorting= "";
			foreach (Column Sort in DG.SortedColumns)
			{
				string sortclause = Sort.FieldName;
				if (Sort.SortDirection== SortDirection.None) continue;
				if (Sort.SortDirection == SortDirection.Ascending)
				{
					sortclause+= " ASC ";
				}
				else 
				{
					sortclause+= " DESC ";
				}
				if (ExcelSorting!="") ExcelSorting+=",";
				ExcelSorting+= sortclause;
			}
			if (ExcelSorting=="")ExcelSorting=null;
			DT.ExtendedProperties["ExcelSort"]=ExcelSorting;
			
			exportclass.DataTableToExcel(DT,true);
		}

		private void btnSalvaDatiPrevisione_Click(object sender, System.EventArgs e)
		{
			if (!Meta.CanSave) return;
			Meta.GetFormData(true);
			Meta.SaveFormData();
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges())
			{
				MessageBox.Show("E' necessario salvare i dati prima di utilizzare questa funzione. Operazione annullata.");
				return;
			}
			salvaDati();
		}


		void salvaDati() {
			Meta.GetFormData(true);
			Meta.SaveFormData();
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges()) {
				MessageBox.Show("E' necessario salvare i dati prima di utilizzare questa funzione. Operazione annullata.");
				return;
			}

			bool procedi = true;
			
			if (Conn.RUN_SELECT_COUNT("finvar",QHS.AppAnd(
                QHS.CmpEq("yvar",Meta.GetSys("esercizio")),QHS.CmpEq("variationkind",3),
                QHS.CmpEq("flagproceeds","S")),false)>0) {
				if (MessageBox.Show("Esiste gi‡ la variazione di assestamento dell'avanzo di cassa effettivo. Procedo comunque?",
					"Conferma",MessageBoxButtons.OKCancel)!=DialogResult.OK) procedi = false;
			}
			if (!procedi) return;

			if (AbilitaColonneCompetenza) {
                if (Conn.RUN_SELECT_COUNT("finvar", QHS.AppAnd(
                    QHS.CmpEq("yvar", Meta.GetSys("esercizio")), QHS.CmpEq("variationkind", 3),
                    QHS.CmpEq("flagcredit", "S")), false) > 0) {
                    if (MessageBox.Show("Esiste gi‡ la variazione di assestamento dell'avanzo di amministrazione effettivo. Procedo comunque?",
						"Conferma",MessageBoxButtons.OKCancel)!=DialogResult.OK) {
						procedi = false;
					}
				}
			}

			if (!procedi) return;


			MetaData MetaVarBilCassa = Meta.Dispatcher.Get("finvar");
			MetaData MetaDettVarBilCassa = Meta.Dispatcher.Get("finvardetail");
			MetaVarBilCassa.SetDefaults(DS.Tables["finvar"]);
			MetaDettVarBilCassa.SetDefaults(DS.Tables["finvardetail"]);
            string configFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            object default_idfinvarstatus = Conn.DO_READ_VALUE("config", configFilter, "default_idfinvarstatus");

            if (AbilitaColonneCassa && AbilitaColonneCompetenza && assestapresunto) {
                // Creo la variazione di previsione di cassa se
                // i residui attivi presunti sono diversi dai residui attivi effettivi
                RowChange.MarkAsAutoincrement(DS.Tables["finvar"].Columns["nofficial"], null, null, 7);
                RowChange.MarkAsCustomAutoincrement(DS.Tables["finvar"].Columns["nofficial"], new RowChange.CustomCalcAutoID(CalcID));
                MetaData.SetDefault(DS.Tables["finvar"], "official", "S");
                MetaData.SetDefault(DS.Tables["finvar"], "idfinvarstatus", default_idfinvarstatus);
                System.Data.DataRow NewVarBilCassa = MetaVarBilCassa.Get_New_Row(null, DS.Tables["finvar"]);
                NewVarBilCassa["description"] = "Assestamento Fondo Cassa (Previsione) - Residui Attivi";
                NewVarBilCassa["variationkind"] = 3;
                NewVarBilCassa["flagsecondaryprev"] = "S";

                NewVarBilCassa["adate"] = DS.finbalance.Rows[0]["balancedate"];
                bool somethingdone = false;
                foreach (System.Data.DataRow R in DS.finbalancedetail.Rows) {
                    decimal diff = CfgFn.GetNoNullDecimal(R["!revenuevariation"]);
                    if (diff != 0) {
                        System.Data.DataRow NewDettVarBilCassaRow = MetaDettVarBilCassa.Get_New_Row(NewVarBilCassa, DS.Tables["finvardetail"]);
                        NewDettVarBilCassaRow["amount"] = diff;
                        NewDettVarBilCassaRow["idfin"] = R["idfin"];
                        NewDettVarBilCassaRow["idupb"] = R["idupb"];
                        somethingdone = true;
                    }
                }
                if (!somethingdone) {
                    NewVarBilCassa.Delete();
                }
            }

			if (campoprevcassa != null) {
                
                //Creo la variazione di previsione e poi aggiungo i dettagli
                RowChange.MarkAsAutoincrement(DS.Tables["finvar"].Columns["nofficial"], null, null, 7);
                RowChange.MarkAsCustomAutoincrement(DS.Tables["finvar"].Columns["nofficial"], new RowChange.CustomCalcAutoID(CalcID));
                MetaData.SetDefault(DS.Tables["finvar"], "official", "S");
                MetaData.SetDefault(DS.Tables["finvar"], "idfinvarstatus", default_idfinvarstatus);
                System.Data.DataRow NewVarBilCassa = MetaVarBilCassa.Get_New_Row(null,DS.Tables["finvar"]);
				NewVarBilCassa["description"] = "Assestamento Fondo Cassa (Previsione)";
				NewVarBilCassa["variationkind"] = 3;
				string fieldtoget="";
				if (campoprevcassa=="prevision"){
					NewVarBilCassa["flagprevision"] = "S";
					fieldtoget="previsionvariation";
				}
				else {
					NewVarBilCassa["flagsecondaryprev"] = "S";
					fieldtoget="secondaryprevvariation";
				}



				NewVarBilCassa["adate"] = DS.finbalance.Rows[0]["balancedate"];
				bool somethingdone=false;

				foreach(System.Data.DataRow R in DS.finbalancedetail.Rows) {
                    if (CfgFn.GetNoNullDecimal(R[fieldtoget]) != 0) {
                        System.Data.DataRow NewDettVarBilCassaRow = MetaDettVarBilCassa.Get_New_Row(NewVarBilCassa, DS.Tables["finvardetail"]);
                        NewDettVarBilCassaRow["amount"] = R[fieldtoget];
                        NewDettVarBilCassaRow["idfin"] = R["idfin"];
                        NewDettVarBilCassaRow["idupb"] = R["idupb"];
                        somethingdone = true;
                    }
                }

                string fEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
                object idFinAvanzo = Meta.Conn.DO_READ_VALUE("config", fEsercizio, "idfinincomesurplus");

                if (!assestapresunto) {
                    decimal importoVar = 0;
                    if ((idFinAvanzo != null) && (idFinAvanzo != DBNull.Value)) {
                        string expr = "ISNULL(startfloatfund,0) + " +
                            "ISNULL(competencyproceeds,0) + ISNULL(residualproceeds, 0) - " +
                            "(ISNULL(competencypayments,0) + ISNULL(residualpayments,0))";
                        importoVar = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("surplus",
                            QHS.CmpEq("ayear", CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) - 1),
                            expr));
                    }

                    if ((importoVar != 0) && (
                        (curridupb == null) ||
                        (curridupb == DBNull.Value) ||
                        (curridupb.ToString() == "0001"))) {
                        System.Data.DataRow NewDettVarBilCassaRow =
                            MetaDettVarBilCassa.Get_New_Row(NewVarBilCassa, DS.Tables["finvardetail"]);
                        NewDettVarBilCassaRow["amount"] = importoVar;
                        NewDettVarBilCassaRow["idfin"] = idFinAvanzo;
                        NewDettVarBilCassaRow["idupb"] = "0001";
                        somethingdone = true;
                    }
                }

				if (!somethingdone){
					NewVarBilCassa.Delete();
				}
			}

			//Creo la variazione Cassa principale e poi aggiungo i dettagli
            MetaData.SetDefault(DS.Tables["finvar"], "official", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "idfinvarstatus", default_idfinvarstatus);
			System.Data.DataRow NewVarCassaRow = MetaVarBilCassa.Get_New_Row(null, DS.Tables["finvar"]);
			NewVarCassaRow["description"]="Assestamento Fondo Cassa (Cassa)";
			NewVarCassaRow["variationkind"]=3;
			NewVarCassaRow["flagproceeds"] = "S";
			NewVarCassaRow["adate"]=DS.finbalance.Rows[0]["balancedate"];
            
            

			bool cashfound=false;
			foreach(System.Data.DataRow R in DS.finbalancedetail.Rows) {
				if (CfgFn.GetNoNullDecimal(R["cashvariation"])!=0) {
					System.Data.DataRow NewDettVarCassaRow = MetaDettVarBilCassa.Get_New_Row(NewVarCassaRow,DS.Tables["finvardetail"]);
					NewDettVarCassaRow["amount"] = R["cashvariation"];
					NewDettVarCassaRow["idfin"] = R["idfin"];
					NewDettVarCassaRow["idupb"] = R["idupb"];
					cashfound=true;
				}
			}
			if (!cashfound){
				NewVarCassaRow.Delete();
			}
			

			if (AbilitaColonneCompetenza) {
				MetaData MetaVarBilComp = Meta.Dispatcher.Get("finvar");
				MetaData MetaDettVarBilComp = Meta.Dispatcher.Get("finvardetail");
				MetaVarBilComp.SetDefaults(DS.Tables["finvar"]);
				MetaDettVarBilComp.SetDefaults(DS.Tables["finvardetail"]);

				//Creo la variazione di previsione e poi aggiungo i dettagli
                RowChange.MarkAsAutoincrement(DS.Tables["finvar"].Columns["nofficial"], null, null, 7);
                RowChange.MarkAsCustomAutoincrement(DS.Tables["finvar"].Columns["nofficial"], new RowChange.CustomCalcAutoID(CalcID));
                MetaData.SetDefault(DS.Tables["finvar"], "official", "S");
                MetaData.SetDefault(DS.Tables["finvar"], "idfinvarstatus", default_idfinvarstatus);
				System.Data.DataRow NewVarBilComp = MetaVarBilComp.Get_New_Row(null,DS.Tables["finvar"]);
				NewVarBilComp["description"] = "Assestamento Avanzo Amministrazione (Previsione)";
				NewVarBilComp["variationkind"] = 3;
				NewVarBilComp["flagprevision"] = "S";
				NewVarBilComp["adate"] = DS.finbalance.Rows[0]["balancedate"];

				//Creo la variazione Crediti principale e poi aggiungo i dettagli
                MetaData.SetDefault(DS.Tables["finvar"], "official", "N");
                System.Data.DataRow NewVarCreditiRow = MetaVarBilComp.Get_New_Row(null, DS.Tables["finvar"]);
				NewVarCreditiRow["description"]="Assestamento Avanzo Amministrazione (Crediti)";
				NewVarCreditiRow["variationkind"]=3;
				NewVarCreditiRow["flagcredit"] = "S";
				NewVarCreditiRow["adate"]=DS.finbalance.Rows[0]["balancedate"];

				bool creditdfound=false;
				bool prevfound=false;
			
				foreach(System.Data.DataRow R in DS.finbalancedetail.Rows) {
					if (CfgFn.GetNoNullDecimal(R["creditvariation"])!=0) {
						System.Data.DataRow NewDettVarCreditiRow = MetaDettVarBilComp.Get_New_Row(NewVarCreditiRow,DS.Tables["finvardetail"]);
						NewDettVarCreditiRow["amount"] = R["creditvariation"];
						NewDettVarCreditiRow["idfin"] = R["idfin"];
						NewDettVarCreditiRow["idupb"] = R["idupb"];
						creditdfound=true;
					}
					if (CfgFn.GetNoNullDecimal(R["previsionvariation"])!=0) {
						System.Data.DataRow NewDettVarBilCompRow = MetaDettVarBilComp.Get_New_Row(NewVarBilComp,DS.Tables["finvardetail"]);
						NewDettVarBilCompRow["amount"] = R["previsionvariation"];
						NewDettVarBilCompRow["idfin"] = R["idfin"];
						NewDettVarBilCompRow["idupb"] = R["idupb"];
						prevfound=true;
					}
				}
				if (!creditdfound) NewVarCreditiRow.Delete();
				if (!prevfound) NewVarBilComp.Delete();

			}
			PostData UpdatedDS = Meta.Get_PostData();
			UpdatedDS.InitClass(DS,Conn);
			bool res = UpdatedDS.DO_POST();
			if(!res) {
				DS.RejectChanges();
			}
			else {
				System.Data.DataRow Curr= DS.finbalance.Rows[0];
				Curr["official"]="S";
				Meta.SaveFormData();
				if (DS.HasChanges()) res=false;

				if (res) MessageBox.Show("Dati salvati con Successo!");
			}
			if (DS.HasChanges()) {
				MessageBox.Show("Attenzione - Sono presenti delle modifiche nel form!");
			}
		}

        private object CalcID(System.Data.DataRow R, System.Data.DataColumn C, DataAccess Conn) {
            // I selettori del campo NOFFICIAL sono YVAR e OFFICIAL
            int yvar = CfgFn.GetNoNullInt32(R["yvar"]);
            string official = R["official"].ToString().ToUpper();
            // Se la variazione non Ë ufficiale non calcolo il campo
            if (official != "S") {
                return DBNull.Value;
            }

            string filter = "(yvar = '" + yvar + "') AND (official = 'S')";
            object nOff = Conn.DO_READ_VALUE("finvar", filter, "MAX(nofficial)");
            if (nOff == null) return DBNull.Value;

            int nOfficial = 1 + CfgFn.GetNoNullInt32(nOff);

            return nOfficial;
        }

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (tabControl1.SelectedTab==tabTotali)
			{
				if (Meta.IsEmpty)
				{
					SvuotaTotali();
				}
				else 
				{
					RicalcolaTotali();
				}
			}
		}

		private void column5_SortDirectionChanged(object sender, System.EventArgs e)
		{
		
		}

		private void gridControl1_CurrentRowChanged(object sender, System.EventArgs e)
		{
			foreach (System.Data.DataRow R in DS2.finbalancedetail.Rows)
			{
				R.EndEdit();

			}
		}

		private void cellcolumnManagerRow1column1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void gridControl1_FirstVisibleColumnChanged(object sender, System.EventArgs e)
		{
			if (gridControl1.FirstVisibleColumn!=null)
			{
				if ((gridControl1.FirstVisibleColumn != gridControl1.Columns["codefin"])
					)
				{
					int F = gridControl1.FirstVisibleColumn.VisibleIndex;
					string order1="V("+gridControl1.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl1.Columns)
					{
						order1+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					bool FORWARD = (gridControl1.Columns["codefin"].VisibleIndex<F);
					if (FORWARD)
					{
						gridControl1.Columns["title"].VisibleIndex=F+1;
					}
					else 
					{
						gridControl1.Columns["title"].VisibleIndex=F;
					}
					
					string order2="V("+gridControl1.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl1.Columns)
					{
						order2+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					if (FORWARD)
					{
						gridControl1.Columns["codefin"].VisibleIndex=F;
					}
					else 
					{
						gridControl1.Columns["codefin"].VisibleIndex=F;
					}

					string order3="V("+gridControl1.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl1.Columns)
					{
						order3+=" "+CC.Title+" "+CC.VisibleIndex;
					}
				}
			}
		}
		private void gridControl2_FirstVisibleColumnChanged(object sender, System.EventArgs e) {
			if (gridControl2.FirstVisibleColumn!=null){
				if ((gridControl2.FirstVisibleColumn != gridControl2.Columns["codefin"])
					//&&	(gridControl1.FirstVisibleColumn != gridControl1.Columns["id2"])
					){
					int F = gridControl2.FirstVisibleColumn.VisibleIndex;
					string order1="V("+gridControl2.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl2.Columns){
						order1+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					bool FORWARD = (gridControl2.Columns["codefin"].VisibleIndex<F);
					if (FORWARD){
						gridControl2.Columns["title"].VisibleIndex=F+1;
					}
					else {
						gridControl2.Columns["title"].VisibleIndex=F;
					}
					
					string order2="V("+gridControl2.FirstVisibleColumn.VisibleIndex+")";
					//string order2="";
					foreach (Xceed.Grid.Column CC in gridControl2.Columns){
						order2+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					//					gridControl1.Columns["denominazione"].VisibleIndex=gridControl1.FirstVisibleColumn.VisibleIndex;
					if (FORWARD){
						gridControl2.Columns["codefin"].VisibleIndex=F;
					}
					else {
						gridControl2.Columns["codefin"].VisibleIndex=F;
					}

					string order3="V("+gridControl2.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl2.Columns){
						order3+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					//MessageBox.Show(order1+"\n"+order2+"\n"+order3);
				}
																					
			}
		}

		private void gridControl2_CurrentColumnChanged(object sender, System.EventArgs e) {
			foreach (System.Data.DataRow R in DS3.finbalancedetail.Rows){
				R.EndEdit();
			}

		}


		private void cmbUpb_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (Meta.IsEmpty) {
				try {
					if (cmbUpb.SelectedIndex>0){
						curridupb = cmbUpb.SelectedValue;
					}
					else {
                        curridupb = DBNull.Value;
					}
				}
				catch {}
				return;
			}
			if (!Meta.GetFormData(true))return;
			if (cmbUpb.SelectedIndex>0){
				curridupb = cmbUpb.SelectedValue;
			}
			else {
                curridupb = DBNull.Value;
			}
			CopyDStoXceed();
			ImpostaHeaders();
		}

		private void chkConsolida_CheckedChanged(object sender, System.EventArgs e) {
			if (Meta==null) return;
			if (Meta.IsEmpty) {
				DoConsolida=chkConsolida.Checked;
				return;
			}
			if (!Meta.GetFormData(true))return;
			DoConsolida=chkConsolida.Checked;
			CopyDStoXceed();			
			ImpostaHeaders();		
		}
	}
}
