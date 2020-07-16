/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using Xceed.Grid.Editors;
using metadatalibrary;
using System.Data;
using funzioni_configurazione;//funzioni_configurazione
using metaeasylibrary;
using System.Reflection;

namespace prevfin_default{//bilancioprevisione//
	/// <summary>
	/// Summary description for FrmBilancioPrevisione.
	/// </summary>
	public class Frm_prevfin_default : System.Windows.Forms.Form {
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnRicalcola;
		private System.Windows.Forms.Button btnSalvaDatiPrevisione;
		public vistaForm DS;
		private Xceed.Grid.GridControl gridControl1;
		private Xceed.Grid.GroupByRow groupByRow1;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private Xceed.Grid.DataRow dataRowTemplate1;
		DataTable MyBilancio;
		MetaData Meta;
		DataAccess Conn;
		int esercizio;
        int newesercizio;

        /// <summary>
        /// Dataset per USCITE
        /// </summary>
		private tempds DS2;
		bool AbilitaColonneCassa=true;
		bool AbilitaColonneCompetenza=true;
		private System.Windows.Forms.TextBox txtTotFondoCassa;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPrevisione;
		private System.Windows.Forms.TabPage tabTotali;
		private System.Windows.Forms.TextBox txtIncassiPresunti;
		private System.Windows.Forms.TextBox txtPagamentiPresunti;
		private System.Windows.Forms.TextBox txtResPassiviPresunti;
		private System.Windows.Forms.TextBox txtResAttiviPresunti;
		private System.Windows.Forms.TextBox txtAvanzoPresunto;
		private System.Windows.Forms.TextBox txtFondoCassaPresunto;
		private System.Windows.Forms.Label labAssCassa;
		private System.Windows.Forms.TextBox txtAssegnareCassa;
		private System.Windows.Forms.TextBox txtAssegnareCompetenza;
		private System.Windows.Forms.TextBox txtPrevisioneCompetenza;
		private System.Windows.Forms.Label labCassa;
		private System.Windows.Forms.TextBox txtPrevisioneCassa;
		string campoprevcompetenza;
		string campoprevcassa;
		//string campoprevcompetenzaprecedente;
		//string campoprevcassaprecedente;
		private System.Windows.Forms.Label labAssCompetenza;
		private System.Windows.Forms.Label labCompetenza;
		object  codicelivellooperativo;
		private System.Windows.Forms.Button btnExcel;
		private Xceed.Grid.DataBoundColumn colidbilancio;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1idfin;
		private Xceed.Grid.DataCell celldataRowTemplate1idfin;
		private Xceed.Grid.DataBoundColumn colcodicebilancio;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1codefin;
		private Xceed.Grid.DataCell celldataRowTemplate1codefin;
		private Xceed.Grid.DataBoundColumn coldenominazione;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1title;
		private Xceed.Grid.DataCell celldataRowTemplate1title;
		private Xceed.Grid.DataBoundColumn colfondocassa;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1floatfund;
		private Xceed.Grid.DataCell celldataRowTemplate1floatfund;
		private Xceed.Grid.DataBoundColumn colpagamentipresunti;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedpayments;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedpayments;
		private Xceed.Grid.DataBoundColumn colincassipresunti;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedproceeds;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedproceeds;
		private Xceed.Grid.DataBoundColumn colresiduipassivipresunti;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedexpenditure;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedexpenditure;
		private Xceed.Grid.DataBoundColumn colresiduiattivipresunti;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedrevenue;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedrevenue;
		private Xceed.Grid.DataBoundColumn colentratedaassegnarecompetenza;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1incometopartitioncompetency;
		private Xceed.Grid.DataCell celldataRowTemplate1incometopartitioncompetency;
		private Xceed.Grid.DataBoundColumn colentratedaassegnarecassa;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1incometopartitioncash;
		private Xceed.Grid.DataCell celldataRowTemplate1incometopartitioncash;
		private Xceed.Grid.DataBoundColumn colbilancioprevisionecassa;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1cash;
		private Xceed.Grid.DataCell celldataRowTemplate1cash;
		public Xceed.Grid.DataBoundColumn colbilancioprevisionecompetenza;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1competency;
		private Xceed.Grid.DataCell celldataRowTemplate1competency;
		private Xceed.Grid.DataBoundColumn colavanzoamministrazionepresunto;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedcreditsurplus;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedcreditsurplus;
		private Xceed.Grid.DataBoundColumn colfondocassapresunto;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1supposedfloatfund;
		private Xceed.Grid.DataCell celldataRowTemplate1supposedfloatfund;
		private System.Windows.Forms.TabPage tabEntrata;
		private System.Windows.Forms.ComboBox cmbUpb;
		private Xceed.Grid.GridControl gridControl2;
		private Xceed.Grid.GroupByRow groupByRow2;
		private Xceed.Grid.ColumnManagerRow columnManagerRow2;
		private Xceed.Grid.DataRow dataRowTemplate2;

		/// <summary>
		/// Dataset per ENTRATE
		/// </summary>
        private prevfin_default.tempds DS3;
		private Xceed.Grid.DataBoundColumn colidfin;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2idfin;
		private Xceed.Grid.DataCell celldataRowTemplate2idfin;
		private Xceed.Grid.DataBoundColumn colcodefin;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2codefin;
		private Xceed.Grid.DataCell celldataRowTemplate2codefin;
		private Xceed.Grid.DataBoundColumn coltitle;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2title;
		private Xceed.Grid.DataCell celldataRowTemplate2title;
		private Xceed.Grid.DataBoundColumn colfloatfund;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2floatfund;
		private Xceed.Grid.DataCell celldataRowTemplate2floatfund;
		private Xceed.Grid.DataBoundColumn colsupposedpayments;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedpayments;
		private Xceed.Grid.DataCell celldataRowTemplate2supposedpayments;
		private Xceed.Grid.DataBoundColumn colsupposedproceeds;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedproceeds;
		private Xceed.Grid.DataCell celldataRowTemplate2supposedproceeds;
		private Xceed.Grid.DataBoundColumn colsupposedexpenditure;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedexpenditure;
		private Xceed.Grid.DataCell celldataRowTemplate2supposedexpenditure;
		private Xceed.Grid.DataBoundColumn colsupposedrevenue;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedrevenue;
		private Xceed.Grid.DataCell celldataRowTemplate2supposedrevenue;
		private Xceed.Grid.DataBoundColumn colincometopartitioncompetency;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2incometopartitioncompetency;
		private Xceed.Grid.DataCell celldataRowTemplate2incometopartitioncompetency;
		private Xceed.Grid.DataBoundColumn colincometopartitioncash;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2incometopartitioncash;
		private Xceed.Grid.DataCell celldataRowTemplate2incometopartitioncash;
		private Xceed.Grid.DataBoundColumn colcash;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2cash;
		private Xceed.Grid.DataCell celldataRowTemplate2cash;
		private Xceed.Grid.DataBoundColumn colcompetency;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2competency;
		private Xceed.Grid.DataCell celldataRowTemplate2competency;
		private Xceed.Grid.DataBoundColumn colsupposedcreditsurplus;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedcreditsurplus;
		private Xceed.Grid.DataCell celldataRowTemplate2supposedcreditsurplus;
		private Xceed.Grid.DataBoundColumn colsupposedfloatfund;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2supposedfloatfund;
		private Xceed.Grid.DataCell celldataRowTemplate2supposedfloatfund;
		private Xceed.Grid.DataBoundColumn colprevision2;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2prevision2;
		private Xceed.Grid.DataBoundColumn colprevision3;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2prevision3;
		private Xceed.Grid.DataBoundColumn colprevision4;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2prevision4;
		private Xceed.Grid.DataBoundColumn colprevision5;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2prevision5;
		private Xceed.Grid.DataBoundColumn colavailableprevision;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow2availableprevision;
		private Xceed.Grid.DataBoundColumn colprevision21;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1prevision2;
		private Xceed.Grid.DataBoundColumn colprevision31;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1prevision3;
		private Xceed.Grid.DataBoundColumn colprevision41;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1prevision4;
		private Xceed.Grid.DataBoundColumn colprevision51;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1prevision5;
		private Xceed.Grid.DataBoundColumn colavailableprevision1;
		private Xceed.Grid.ColumnManagerCell cellcolumnManagerRow1availableprevision;
		private Xceed.Grid.DataCell celldataRowTemplate2prevision2;
		private Xceed.Grid.DataCell celldataRowTemplate2prevision3;
		private Xceed.Grid.DataCell celldataRowTemplate2prevision4;
		private Xceed.Grid.DataCell celldataRowTemplate2prevision5;
		private Xceed.Grid.DataCell celldataRowTemplate2availableprevision;
		private Xceed.Grid.DataCell celldataRowTemplate1prevision2;
		private Xceed.Grid.DataCell celldataRowTemplate1prevision3;
		private Xceed.Grid.DataCell celldataRowTemplate1prevision4;
		private Xceed.Grid.DataCell celldataRowTemplate1prevision5;
		private Xceed.Grid.DataCell celldataRowTemplate1availableprevision;

		//bool CurrAssured=false;
        bool SolaCassa = false;
		object curridupb=DBNull.Value;
		bool DoConsolida=false;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtIncomeCompetency;
		private System.Windows.Forms.TextBox txtIncomeCash;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox chkConsolida;
		private System.Windows.Forms.Label labIncomeCompetency;
		private System.Windows.Forms.Label labIncomeCash;
		private System.Windows.Forms.TextBox txtResiduiAttiviRipartiti;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label labFCassa;
		private System.Windows.Forms.Label labIncPresunti;
		private System.Windows.Forms.Label labPagPresunti;
		private System.Windows.Forms.Label labResPassPres;
		private System.Windows.Forms.Label labResAttPres;
		private System.Windows.Forms.Label labAvaAmmPres;
		private System.Windows.Forms.Label labFCassaPres;
		private System.Windows.Forms.Label labResAttPresRip;
        private ColumnManagerCell cellcolumnManagerRow1idfin1;
        private ColumnManagerCell cellcolumnManagerRow1codefin1;
        private ColumnManagerCell cellcolumnManagerRow1title1;
        private ColumnManagerCell cellcolumnManagerRow1floatfund1;
        private ColumnManagerCell cellcolumnManagerRow1supposedpayments1;
        private ColumnManagerCell cellcolumnManagerRow1supposedproceeds1;
        private ColumnManagerCell cellcolumnManagerRow1supposedexpenditure1;
        private ColumnManagerCell cellcolumnManagerRow1supposedrevenue1;
        private ColumnManagerCell cellcolumnManagerRow1incometopartitioncompetency1;
        private ColumnManagerCell cellcolumnManagerRow1incometopartitioncash1;
        private ColumnManagerCell cellcolumnManagerRow1cash1;
        private ColumnManagerCell cellcolumnManagerRow1competency1;
        private ColumnManagerCell cellcolumnManagerRow1supposedcreditsurplus1;
        private ColumnManagerCell cellcolumnManagerRow1supposedfloatfund1;
        private ColumnManagerCell cellcolumnManagerRow1prevision21;
        private ColumnManagerCell cellcolumnManagerRow1prevision31;
        private ColumnManagerCell cellcolumnManagerRow1prevision41;
        private ColumnManagerCell cellcolumnManagerRow1prevision51;
        private ColumnManagerCell cellcolumnManagerRow1availableprevision1;
        private ColumnManagerCell cellcolumnManagerRow2idfin1;
        private ColumnManagerCell cellcolumnManagerRow2codefin1;
        private ColumnManagerCell cellcolumnManagerRow2title1;
        private ColumnManagerCell cellcolumnManagerRow2floatfund1;
        private ColumnManagerCell cellcolumnManagerRow2supposedpayments1;
        private ColumnManagerCell cellcolumnManagerRow2supposedproceeds1;
        private ColumnManagerCell cellcolumnManagerRow2supposedexpenditure1;
        private ColumnManagerCell cellcolumnManagerRow2supposedrevenue1;
        private ColumnManagerCell cellcolumnManagerRow2incometopartitioncompetency1;
        private ColumnManagerCell cellcolumnManagerRow2incometopartitioncash1;
        private ColumnManagerCell cellcolumnManagerRow2cash1;
        private ColumnManagerCell cellcolumnManagerRow2competency1;
        private ColumnManagerCell cellcolumnManagerRow2supposedcreditsurplus1;
        private ColumnManagerCell cellcolumnManagerRow2supposedfloatfund1;
        private ColumnManagerCell cellcolumnManagerRow2prevision21;
        private ColumnManagerCell cellcolumnManagerRow2prevision31;
        private ColumnManagerCell cellcolumnManagerRow2prevision41;
        private ColumnManagerCell cellcolumnManagerRow2prevision51;
        private ColumnManagerCell cellcolumnManagerRow2availableprevision1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        QueryHelper QHS;
        CQueryHelper QHC;

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
            this.DS2 = new prevfin_default.tempds();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRicalcola = new System.Windows.Forms.Button();
            this.btnSalvaDatiPrevisione = new System.Windows.Forms.Button();
            this.gridControl1 = new Xceed.Grid.GridControl();
            this.colidbilancio = new Xceed.Grid.DataBoundColumn();
            this.colcodicebilancio = new Xceed.Grid.DataBoundColumn();
            this.coldenominazione = new Xceed.Grid.DataBoundColumn();
            this.colfondocassa = new Xceed.Grid.DataBoundColumn();
            this.colpagamentipresunti = new Xceed.Grid.DataBoundColumn();
            this.colincassipresunti = new Xceed.Grid.DataBoundColumn();
            this.colresiduipassivipresunti = new Xceed.Grid.DataBoundColumn();
            this.colresiduiattivipresunti = new Xceed.Grid.DataBoundColumn();
            this.colentratedaassegnarecompetenza = new Xceed.Grid.DataBoundColumn();
            this.colentratedaassegnarecassa = new Xceed.Grid.DataBoundColumn();
            this.colbilancioprevisionecassa = new Xceed.Grid.DataBoundColumn();
            this.colbilancioprevisionecompetenza = new Xceed.Grid.DataBoundColumn();
            this.colavanzoamministrazionepresunto = new Xceed.Grid.DataBoundColumn();
            this.colfondocassapresunto = new Xceed.Grid.DataBoundColumn();
            this.colprevision21 = new Xceed.Grid.DataBoundColumn();
            this.colprevision31 = new Xceed.Grid.DataBoundColumn();
            this.colprevision41 = new Xceed.Grid.DataBoundColumn();
            this.colprevision51 = new Xceed.Grid.DataBoundColumn();
            this.colavailableprevision1 = new Xceed.Grid.DataBoundColumn();
            this.dataRowTemplate1 = new Xceed.Grid.DataRow();
            this.celldataRowTemplate1idfin = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1codefin = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1title = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1floatfund = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedpayments = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedproceeds = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedexpenditure = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedrevenue = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1incometopartitioncompetency = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1incometopartitioncash = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1cash = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1competency = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedcreditsurplus = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1supposedfloatfund = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1prevision2 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1prevision3 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1prevision4 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1prevision5 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate1availableprevision = new Xceed.Grid.DataCell();
            this.groupByRow1 = new Xceed.Grid.GroupByRow();
            this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
            this.cellcolumnManagerRow1idfin = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1codefin = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1title = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1floatfund = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedpayments = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedproceeds = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedexpenditure = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedrevenue = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1incometopartitioncompetency = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1incometopartitioncash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1cash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1competency = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedcreditsurplus = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedfloatfund = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision2 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision3 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision4 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision5 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1availableprevision = new Xceed.Grid.ColumnManagerCell();
            this.labFCassa = new System.Windows.Forms.Label();
            this.txtTotFondoCassa = new System.Windows.Forms.TextBox();
            this.txtIncassiPresunti = new System.Windows.Forms.TextBox();
            this.labIncPresunti = new System.Windows.Forms.Label();
            this.txtPagamentiPresunti = new System.Windows.Forms.TextBox();
            this.labPagPresunti = new System.Windows.Forms.Label();
            this.txtResPassiviPresunti = new System.Windows.Forms.TextBox();
            this.labResPassPres = new System.Windows.Forms.Label();
            this.txtResAttiviPresunti = new System.Windows.Forms.TextBox();
            this.labResAttPres = new System.Windows.Forms.Label();
            this.txtAvanzoPresunto = new System.Windows.Forms.TextBox();
            this.labAvaAmmPres = new System.Windows.Forms.Label();
            this.txtFondoCassaPresunto = new System.Windows.Forms.TextBox();
            this.labFCassaPres = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPrevisione = new System.Windows.Forms.TabPage();
            this.tabEntrata = new System.Windows.Forms.TabPage();
            this.gridControl2 = new Xceed.Grid.GridControl();
            this.colidfin = new Xceed.Grid.DataBoundColumn();
            this.colcodefin = new Xceed.Grid.DataBoundColumn();
            this.coltitle = new Xceed.Grid.DataBoundColumn();
            this.colfloatfund = new Xceed.Grid.DataBoundColumn();
            this.colsupposedpayments = new Xceed.Grid.DataBoundColumn();
            this.colsupposedproceeds = new Xceed.Grid.DataBoundColumn();
            this.colsupposedexpenditure = new Xceed.Grid.DataBoundColumn();
            this.colsupposedrevenue = new Xceed.Grid.DataBoundColumn();
            this.colincometopartitioncompetency = new Xceed.Grid.DataBoundColumn();
            this.colincometopartitioncash = new Xceed.Grid.DataBoundColumn();
            this.colcash = new Xceed.Grid.DataBoundColumn();
            this.colcompetency = new Xceed.Grid.DataBoundColumn();
            this.colsupposedcreditsurplus = new Xceed.Grid.DataBoundColumn();
            this.colsupposedfloatfund = new Xceed.Grid.DataBoundColumn();
            this.colprevision2 = new Xceed.Grid.DataBoundColumn();
            this.colprevision3 = new Xceed.Grid.DataBoundColumn();
            this.colprevision4 = new Xceed.Grid.DataBoundColumn();
            this.colprevision5 = new Xceed.Grid.DataBoundColumn();
            this.colavailableprevision = new Xceed.Grid.DataBoundColumn();
            this.dataRowTemplate2 = new Xceed.Grid.DataRow();
            this.celldataRowTemplate2idfin = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2codefin = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2title = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2floatfund = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2supposedpayments = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2supposedproceeds = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2supposedexpenditure = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2supposedrevenue = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2incometopartitioncompetency = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2incometopartitioncash = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2cash = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2competency = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2supposedcreditsurplus = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2supposedfloatfund = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2prevision2 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2prevision3 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2prevision4 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2prevision5 = new Xceed.Grid.DataCell();
            this.celldataRowTemplate2availableprevision = new Xceed.Grid.DataCell();
            this.DS3 = new prevfin_default.tempds();
            this.groupByRow2 = new Xceed.Grid.GroupByRow();
            this.columnManagerRow2 = new Xceed.Grid.ColumnManagerRow();
            this.cellcolumnManagerRow2idfin = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2codefin = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2title = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2floatfund = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedpayments = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedproceeds = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedexpenditure = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedrevenue = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2incometopartitioncompetency = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2incometopartitioncash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2cash = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2competency = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedcreditsurplus = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedfloatfund = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision2 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision3 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision4 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision5 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2availableprevision = new Xceed.Grid.ColumnManagerCell();
            this.tabTotali = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtResiduiAttiviRipartiti = new System.Windows.Forms.TextBox();
            this.labResAttPresRip = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtIncomeCompetency = new System.Windows.Forms.TextBox();
            this.txtIncomeCash = new System.Windows.Forms.TextBox();
            this.labIncomeCash = new System.Windows.Forms.Label();
            this.labIncomeCompetency = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labCassa = new System.Windows.Forms.Label();
            this.txtPrevisioneCassa = new System.Windows.Forms.TextBox();
            this.txtPrevisioneCompetenza = new System.Windows.Forms.TextBox();
            this.labCompetenza = new System.Windows.Forms.Label();
            this.txtAssegnareCassa = new System.Windows.Forms.TextBox();
            this.labAssCassa = new System.Windows.Forms.Label();
            this.txtAssegnareCompetenza = new System.Windows.Forms.TextBox();
            this.labAssCompetenza = new System.Windows.Forms.Label();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.chkConsolida = new System.Windows.Forms.CheckBox();
            this.cmbUpb = new System.Windows.Forms.ComboBox();
            this.DS = new prevfin_default.vistaForm();
            this.cellcolumnManagerRow1idfin1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1codefin1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1title1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1floatfund1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedpayments1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedproceeds1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedexpenditure1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedrevenue1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1incometopartitioncompetency1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1incometopartitioncash1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1cash1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1competency1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedcreditsurplus1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1supposedfloatfund1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision21 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision31 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision41 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1prevision51 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow1availableprevision1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2idfin1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2codefin1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2title1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2floatfund1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedpayments1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedproceeds1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedexpenditure1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedrevenue1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2incometopartitioncompetency1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2incometopartitioncash1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2cash1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2competency1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedcreditsurplus1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2supposedfloatfund1 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision21 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision31 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision41 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2prevision51 = new Xceed.Grid.ColumnManagerCell();
            this.cellcolumnManagerRow2availableprevision1 = new Xceed.Grid.ColumnManagerCell();
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPrevisione.SuspendLayout();
            this.tabEntrata.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).BeginInit();
            this.tabTotali.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // DS2
            // 
            this.DS2.DataSetName = "tempds";
            this.DS2.EnforceConstraints = false;
            this.DS2.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(296, 8);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(72, 20);
            this.textBox3.TabIndex = 11;
            this.textBox3.Tag = "prevfin.previsiondate";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(200, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 23);
            this.label3.TabIndex = 10;
            this.label3.Text = "Data Previsione";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(144, 8);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 20);
            this.textBox2.TabIndex = 9;
            this.textBox2.Tag = "prevfin.nprevfin";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(96, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Numero";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(56, 8);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(32, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.Tag = "prevfin.ayear.year";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Esercizio";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRicalcola
            // 
            this.btnRicalcola.Location = new System.Drawing.Point(400, 8);
            this.btnRicalcola.Name = "btnRicalcola";
            this.btnRicalcola.Size = new System.Drawing.Size(144, 23);
            this.btnRicalcola.TabIndex = 12;
            this.btnRicalcola.Text = "Ricalcola valori presunti";
            this.btnRicalcola.Click += new System.EventHandler(this.btnRicalcola_Click);
            // 
            // btnSalvaDatiPrevisione
            // 
            this.btnSalvaDatiPrevisione.Location = new System.Drawing.Point(440, 40);
            this.btnSalvaDatiPrevisione.Name = "btnSalvaDatiPrevisione";
            this.btnSalvaDatiPrevisione.Size = new System.Drawing.Size(232, 24);
            this.btnSalvaDatiPrevisione.TabIndex = 13;
            this.btnSalvaDatiPrevisione.Text = "Rendi ufficiale il bilancio di previsione";
            this.btnSalvaDatiPrevisione.Click += new System.EventHandler(this.btnSalvaDatiPrevisione_Click);
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Columns.Add(this.colidbilancio);
            this.gridControl1.Columns.Add(this.colcodicebilancio);
            this.gridControl1.Columns.Add(this.coldenominazione);
            this.gridControl1.Columns.Add(this.colfondocassa);
            this.gridControl1.Columns.Add(this.colpagamentipresunti);
            this.gridControl1.Columns.Add(this.colincassipresunti);
            this.gridControl1.Columns.Add(this.colresiduipassivipresunti);
            this.gridControl1.Columns.Add(this.colresiduiattivipresunti);
            this.gridControl1.Columns.Add(this.colentratedaassegnarecompetenza);
            this.gridControl1.Columns.Add(this.colentratedaassegnarecassa);
            this.gridControl1.Columns.Add(this.colbilancioprevisionecassa);
            this.gridControl1.Columns.Add(this.colbilancioprevisionecompetenza);
            this.gridControl1.Columns.Add(this.colavanzoamministrazionepresunto);
            this.gridControl1.Columns.Add(this.colfondocassapresunto);
            this.gridControl1.Columns.Add(this.colprevision21);
            this.gridControl1.Columns.Add(this.colprevision31);
            this.gridControl1.Columns.Add(this.colprevision41);
            this.gridControl1.Columns.Add(this.colprevision51);
            this.gridControl1.Columns.Add(this.colavailableprevision1);
            this.gridControl1.DataRowTemplate = this.dataRowTemplate1;
            this.gridControl1.DataSource = this.DS2.prevfindetail;
            this.gridControl1.FixedHeaderRows.Add(this.groupByRow1);
            this.gridControl1.FixedHeaderRows.Add(this.columnManagerRow1);
            this.gridControl1.Location = new System.Drawing.Point(8, 8);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(656, 336);
            this.gridControl1.TabIndex = 14;
            this.gridControl1.CurrentColumnChanged += new System.EventHandler(this.gridControl1_CurrentColumnChanged);
            this.gridControl1.FirstVisibleColumnChanged += new System.EventHandler(this.gridControl1_FirstVisibleColumnChanged);
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
            // colfondocassa
            // 
            this.colfondocassa.SortDirection = Xceed.Grid.SortDirection.None;
            this.colfondocassa.Title = "floatfund";
            this.colfondocassa.VisibleIndex = 3;
            this.colfondocassa.Initialize("floatfund");
            // 
            // colpagamentipresunti
            // 
            this.colpagamentipresunti.SortDirection = Xceed.Grid.SortDirection.None;
            this.colpagamentipresunti.Title = "supposedpayments";
            this.colpagamentipresunti.VisibleIndex = 5;
            this.colpagamentipresunti.Initialize("supposedpayments");
            // 
            // colincassipresunti
            // 
            this.colincassipresunti.SortDirection = Xceed.Grid.SortDirection.None;
            this.colincassipresunti.Title = "supposedproceeds";
            this.colincassipresunti.VisibleIndex = 4;
            this.colincassipresunti.Initialize("supposedproceeds");
            // 
            // colresiduipassivipresunti
            // 
            this.colresiduipassivipresunti.SortDirection = Xceed.Grid.SortDirection.None;
            this.colresiduipassivipresunti.Title = "supposedexpenditure";
            this.colresiduipassivipresunti.VisibleIndex = 8;
            this.colresiduipassivipresunti.Initialize("supposedexpenditure");
            // 
            // colresiduiattivipresunti
            // 
            this.colresiduiattivipresunti.SortDirection = Xceed.Grid.SortDirection.None;
            this.colresiduiattivipresunti.Title = "supposedrevenue";
            this.colresiduiattivipresunti.VisibleIndex = 7;
            this.colresiduiattivipresunti.Initialize("supposedrevenue");
            // 
            // colentratedaassegnarecompetenza
            // 
            this.colentratedaassegnarecompetenza.SortDirection = Xceed.Grid.SortDirection.None;
            this.colentratedaassegnarecompetenza.Title = "incometopartitioncompetency";
            this.colentratedaassegnarecompetenza.VisibleIndex = 11;
            this.colentratedaassegnarecompetenza.Initialize("incometopartitioncompetency");
            // 
            // colentratedaassegnarecassa
            // 
            this.colentratedaassegnarecassa.SortDirection = Xceed.Grid.SortDirection.None;
            this.colentratedaassegnarecassa.Title = "incometopartitioncash";
            this.colentratedaassegnarecassa.VisibleIndex = 12;
            this.colentratedaassegnarecassa.Initialize("incometopartitioncash");
            // 
            // colbilancioprevisionecassa
            // 
            this.colbilancioprevisionecassa.SortDirection = Xceed.Grid.SortDirection.None;
            this.colbilancioprevisionecassa.Title = "cash";
            this.colbilancioprevisionecassa.VisibleIndex = 14;
            this.colbilancioprevisionecassa.Initialize("cash");
            // 
            // colbilancioprevisionecompetenza
            // 
            this.colbilancioprevisionecompetenza.SortDirection = Xceed.Grid.SortDirection.None;
            this.colbilancioprevisionecompetenza.Title = "competency";
            this.colbilancioprevisionecompetenza.VisibleIndex = 13;
            this.colbilancioprevisionecompetenza.Initialize("competency");
            // 
            // colavanzoamministrazionepresunto
            // 
            this.colavanzoamministrazionepresunto.SortDirection = Xceed.Grid.SortDirection.None;
            this.colavanzoamministrazionepresunto.Title = "supposedcreditsurplus";
            this.colavanzoamministrazionepresunto.VisibleIndex = 9;
            this.colavanzoamministrazionepresunto.Initialize("supposedcreditsurplus");
            // 
            // colfondocassapresunto
            // 
            this.colfondocassapresunto.SortDirection = Xceed.Grid.SortDirection.None;
            this.colfondocassapresunto.Title = "supposedfloatfund";
            this.colfondocassapresunto.VisibleIndex = 6;
            this.colfondocassapresunto.Initialize("supposedfloatfund");
            // 
            // colprevision21
            // 
            this.colprevision21.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision21.Title = "prevision2";
            this.colprevision21.VisibleIndex = 15;
            this.colprevision21.Initialize("prevision2");
            // 
            // colprevision31
            // 
            this.colprevision31.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision31.Title = "prevision3";
            this.colprevision31.VisibleIndex = 16;
            this.colprevision31.Initialize("prevision3");
            // 
            // colprevision41
            // 
            this.colprevision41.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision41.Title = "prevision4";
            this.colprevision41.VisibleIndex = 17;
            this.colprevision41.Initialize("prevision4");
            // 
            // colprevision51
            // 
            this.colprevision51.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision51.Title = "prevision5";
            this.colprevision51.VisibleIndex = 18;
            this.colprevision51.Initialize("prevision5");
            // 
            // colavailableprevision1
            // 
            this.colavailableprevision1.SortDirection = Xceed.Grid.SortDirection.None;
            this.colavailableprevision1.Title = "availableprevision";
            this.colavailableprevision1.VisibleIndex = 10;
            this.colavailableprevision1.Initialize("availableprevision");
            // 
            // dataRowTemplate1
            // 
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1idfin);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1codefin);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1title);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1floatfund);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedpayments);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedproceeds);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedexpenditure);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedrevenue);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1incometopartitioncompetency);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1incometopartitioncash);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1cash);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1competency);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedcreditsurplus);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1supposedfloatfund);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1prevision2);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1prevision3);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1prevision4);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1prevision5);
            this.dataRowTemplate1.Cells.Add(this.celldataRowTemplate1availableprevision);
            this.celldataRowTemplate1idfin.Initialize("idfin");
            this.celldataRowTemplate1codefin.Initialize("codefin");
            this.celldataRowTemplate1title.Initialize("title");
            this.celldataRowTemplate1floatfund.Initialize("floatfund");
            this.celldataRowTemplate1supposedpayments.Initialize("supposedpayments");
            this.celldataRowTemplate1supposedproceeds.Initialize("supposedproceeds");
            this.celldataRowTemplate1supposedexpenditure.Initialize("supposedexpenditure");
            this.celldataRowTemplate1supposedrevenue.Initialize("supposedrevenue");
            this.celldataRowTemplate1incometopartitioncompetency.Initialize("incometopartitioncompetency");
            this.celldataRowTemplate1incometopartitioncash.Initialize("incometopartitioncash");
            this.celldataRowTemplate1cash.Initialize("cash");
            this.celldataRowTemplate1competency.Initialize("competency");
            this.celldataRowTemplate1supposedcreditsurplus.Initialize("supposedcreditsurplus");
            this.celldataRowTemplate1supposedfloatfund.Initialize("supposedfloatfund");
            this.celldataRowTemplate1prevision2.Initialize("prevision2");
            this.celldataRowTemplate1prevision3.Initialize("prevision3");
            this.celldataRowTemplate1prevision4.Initialize("prevision4");
            this.celldataRowTemplate1prevision5.Initialize("prevision5");
            this.celldataRowTemplate1availableprevision.Initialize("availableprevision");
            // 
            // groupByRow1
            // 
            this.groupByRow1.AllowGroupingModification = false;
            this.groupByRow1.ReadOnly = true;
            this.groupByRow1.Visible = false;
            // 
            // columnManagerRow1
            // 
            this.columnManagerRow1.AllowColumnReorder = false;
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1idfin);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1codefin);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1title);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1floatfund);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedpayments);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedproceeds);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedexpenditure);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedrevenue);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1incometopartitioncompetency);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1incometopartitioncash);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1cash);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1competency);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedcreditsurplus);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1supposedfloatfund);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1prevision2);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1prevision3);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1prevision4);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1prevision5);
            this.columnManagerRow1.Cells.Add(this.cellcolumnManagerRow1availableprevision);
            this.columnManagerRow1.Height = 33;
            this.cellcolumnManagerRow1idfin.Initialize("idfin");
            this.cellcolumnManagerRow1codefin.Initialize("codefin");
            this.cellcolumnManagerRow1title.Initialize("title");
            this.cellcolumnManagerRow1floatfund.Initialize("floatfund");
            this.cellcolumnManagerRow1supposedpayments.Initialize("supposedpayments");
            this.cellcolumnManagerRow1supposedproceeds.Initialize("supposedproceeds");
            this.cellcolumnManagerRow1supposedexpenditure.Initialize("supposedexpenditure");
            this.cellcolumnManagerRow1supposedrevenue.Initialize("supposedrevenue");
            this.cellcolumnManagerRow1incometopartitioncompetency.Initialize("incometopartitioncompetency");
            this.cellcolumnManagerRow1incometopartitioncash.Initialize("incometopartitioncash");
            this.cellcolumnManagerRow1cash.Initialize("cash");
            this.cellcolumnManagerRow1competency.Initialize("competency");
            this.cellcolumnManagerRow1supposedcreditsurplus.Initialize("supposedcreditsurplus");
            this.cellcolumnManagerRow1supposedfloatfund.Initialize("supposedfloatfund");
            this.cellcolumnManagerRow1prevision2.Initialize("prevision2");
            this.cellcolumnManagerRow1prevision3.Initialize("prevision3");
            this.cellcolumnManagerRow1prevision4.Initialize("prevision4");
            this.cellcolumnManagerRow1prevision5.Initialize("prevision5");
            this.cellcolumnManagerRow1availableprevision.Initialize("availableprevision");
            // 
            // labFCassa
            // 
            this.labFCassa.Location = new System.Drawing.Point(24, 16);
            this.labFCassa.Name = "labFCassa";
            this.labFCassa.Size = new System.Drawing.Size(72, 16);
            this.labFCassa.TabIndex = 15;
            this.labFCassa.Text = "Fondo cassa";
            this.labFCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTotFondoCassa
            // 
            this.txtTotFondoCassa.Location = new System.Drawing.Point(32, 32);
            this.txtTotFondoCassa.Name = "txtTotFondoCassa";
            this.txtTotFondoCassa.ReadOnly = true;
            this.txtTotFondoCassa.Size = new System.Drawing.Size(104, 20);
            this.txtTotFondoCassa.TabIndex = 16;
            this.txtTotFondoCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIncassiPresunti
            // 
            this.txtIncassiPresunti.Location = new System.Drawing.Point(168, 32);
            this.txtIncassiPresunti.Name = "txtIncassiPresunti";
            this.txtIncassiPresunti.ReadOnly = true;
            this.txtIncassiPresunti.Size = new System.Drawing.Size(104, 20);
            this.txtIncassiPresunti.TabIndex = 18;
            this.txtIncassiPresunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labIncPresunti
            // 
            this.labIncPresunti.Location = new System.Drawing.Point(168, 16);
            this.labIncPresunti.Name = "labIncPresunti";
            this.labIncPresunti.Size = new System.Drawing.Size(96, 16);
            this.labIncPresunti.TabIndex = 17;
            this.labIncPresunti.Text = "Incassi presunti";
            this.labIncPresunti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPagamentiPresunti
            // 
            this.txtPagamentiPresunti.Location = new System.Drawing.Point(288, 32);
            this.txtPagamentiPresunti.Name = "txtPagamentiPresunti";
            this.txtPagamentiPresunti.ReadOnly = true;
            this.txtPagamentiPresunti.Size = new System.Drawing.Size(104, 20);
            this.txtPagamentiPresunti.TabIndex = 20;
            this.txtPagamentiPresunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labPagPresunti
            // 
            this.labPagPresunti.Location = new System.Drawing.Point(288, 16);
            this.labPagPresunti.Name = "labPagPresunti";
            this.labPagPresunti.Size = new System.Drawing.Size(104, 16);
            this.labPagPresunti.TabIndex = 19;
            this.labPagPresunti.Text = "Pagamenti presunti";
            this.labPagPresunti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResPassiviPresunti
            // 
            this.txtResPassiviPresunti.Location = new System.Drawing.Point(168, 80);
            this.txtResPassiviPresunti.Name = "txtResPassiviPresunti";
            this.txtResPassiviPresunti.ReadOnly = true;
            this.txtResPassiviPresunti.Size = new System.Drawing.Size(100, 20);
            this.txtResPassiviPresunti.TabIndex = 24;
            this.txtResPassiviPresunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labResPassPres
            // 
            this.labResPassPres.Location = new System.Drawing.Point(168, 64);
            this.labResPassPres.Name = "labResPassPres";
            this.labResPassPres.Size = new System.Drawing.Size(128, 16);
            this.labResPassPres.TabIndex = 23;
            this.labResPassPres.Text = "Residui Passivi presunti";
            this.labResPassPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtResAttiviPresunti
            // 
            this.txtResAttiviPresunti.Location = new System.Drawing.Point(32, 80);
            this.txtResAttiviPresunti.Name = "txtResAttiviPresunti";
            this.txtResAttiviPresunti.ReadOnly = true;
            this.txtResAttiviPresunti.Size = new System.Drawing.Size(100, 20);
            this.txtResAttiviPresunti.TabIndex = 22;
            this.txtResAttiviPresunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labResAttPres
            // 
            this.labResAttPres.Location = new System.Drawing.Point(32, 64);
            this.labResAttPres.Name = "labResAttPres";
            this.labResAttPres.Size = new System.Drawing.Size(120, 16);
            this.labResAttPres.TabIndex = 21;
            this.labResAttPres.Text = "Residui Attivi presunti";
            this.labResAttPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAvanzoPresunto
            // 
            this.txtAvanzoPresunto.Location = new System.Drawing.Point(408, 80);
            this.txtAvanzoPresunto.Name = "txtAvanzoPresunto";
            this.txtAvanzoPresunto.ReadOnly = true;
            this.txtAvanzoPresunto.Size = new System.Drawing.Size(100, 20);
            this.txtAvanzoPresunto.TabIndex = 28;
            this.txtAvanzoPresunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labAvaAmmPres
            // 
            this.labAvaAmmPres.Location = new System.Drawing.Point(408, 64);
            this.labAvaAmmPres.Name = "labAvaAmmPres";
            this.labAvaAmmPres.Size = new System.Drawing.Size(144, 16);
            this.labAvaAmmPres.TabIndex = 27;
            this.labAvaAmmPres.Text = "Avanzo Ammin. presunto";
            this.labAvaAmmPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFondoCassaPresunto
            // 
            this.txtFondoCassaPresunto.Location = new System.Drawing.Point(408, 32);
            this.txtFondoCassaPresunto.Name = "txtFondoCassaPresunto";
            this.txtFondoCassaPresunto.ReadOnly = true;
            this.txtFondoCassaPresunto.Size = new System.Drawing.Size(100, 20);
            this.txtFondoCassaPresunto.TabIndex = 26;
            this.txtFondoCassaPresunto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labFCassaPres
            // 
            this.labFCassaPres.Location = new System.Drawing.Point(408, 16);
            this.labFCassaPres.Name = "labFCassaPres";
            this.labFCassaPres.Size = new System.Drawing.Size(136, 16);
            this.labFCassaPres.TabIndex = 25;
            this.labFCassaPres.Text = "Fondo cassa presunto";
            this.labFCassaPres.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPrevisione);
            this.tabControl1.Controls.Add(this.tabEntrata);
            this.tabControl1.Controls.Add(this.tabTotali);
            this.tabControl1.Location = new System.Drawing.Point(0, 72);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(680, 376);
            this.tabControl1.TabIndex = 17;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPrevisione
            // 
            this.tabPrevisione.Controls.Add(this.gridControl1);
            this.tabPrevisione.Location = new System.Drawing.Point(4, 22);
            this.tabPrevisione.Name = "tabPrevisione";
            this.tabPrevisione.Size = new System.Drawing.Size(672, 350);
            this.tabPrevisione.TabIndex = 0;
            this.tabPrevisione.Text = "Previsione di spesa";
            // 
            // tabEntrata
            // 
            this.tabEntrata.Controls.Add(this.gridControl2);
            this.tabEntrata.Location = new System.Drawing.Point(4, 22);
            this.tabEntrata.Name = "tabEntrata";
            this.tabEntrata.Size = new System.Drawing.Size(672, 350);
            this.tabEntrata.TabIndex = 2;
            this.tabEntrata.Text = "Previsione di entrata";
            // 
            // gridControl2
            // 
            this.gridControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl2.Columns.Add(this.colidfin);
            this.gridControl2.Columns.Add(this.colcodefin);
            this.gridControl2.Columns.Add(this.coltitle);
            this.gridControl2.Columns.Add(this.colfloatfund);
            this.gridControl2.Columns.Add(this.colsupposedpayments);
            this.gridControl2.Columns.Add(this.colsupposedproceeds);
            this.gridControl2.Columns.Add(this.colsupposedexpenditure);
            this.gridControl2.Columns.Add(this.colsupposedrevenue);
            this.gridControl2.Columns.Add(this.colincometopartitioncompetency);
            this.gridControl2.Columns.Add(this.colincometopartitioncash);
            this.gridControl2.Columns.Add(this.colcash);
            this.gridControl2.Columns.Add(this.colcompetency);
            this.gridControl2.Columns.Add(this.colsupposedcreditsurplus);
            this.gridControl2.Columns.Add(this.colsupposedfloatfund);
            this.gridControl2.Columns.Add(this.colprevision2);
            this.gridControl2.Columns.Add(this.colprevision3);
            this.gridControl2.Columns.Add(this.colprevision4);
            this.gridControl2.Columns.Add(this.colprevision5);
            this.gridControl2.Columns.Add(this.colavailableprevision);
            this.gridControl2.DataRowTemplate = this.dataRowTemplate2;
            this.gridControl2.DataSource = this.DS3.prevfindetail;
            this.gridControl2.FixedHeaderRows.Add(this.groupByRow2);
            this.gridControl2.FixedHeaderRows.Add(this.columnManagerRow2);
            this.gridControl2.Location = new System.Drawing.Point(8, 8);
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(656, 336);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.CurrentColumnChanged += new System.EventHandler(this.gridControl2_CurrentColumnChanged);
            this.gridControl2.FirstVisibleColumnChanged += new System.EventHandler(this.gridControl2_FirstVisibleColumnChanged);
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
            this.colcodefin.SortDirection = Xceed.Grid.SortDirection.None;
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
            // colfloatfund
            // 
            this.colfloatfund.SortDirection = Xceed.Grid.SortDirection.None;
            this.colfloatfund.Title = "floatfund";
            this.colfloatfund.VisibleIndex = 3;
            this.colfloatfund.Initialize("floatfund");
            // 
            // colsupposedpayments
            // 
            this.colsupposedpayments.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedpayments.Title = "supposedpayments";
            this.colsupposedpayments.VisibleIndex = 5;
            this.colsupposedpayments.Initialize("supposedpayments");
            // 
            // colsupposedproceeds
            // 
            this.colsupposedproceeds.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedproceeds.Title = "supposedproceeds";
            this.colsupposedproceeds.VisibleIndex = 4;
            this.colsupposedproceeds.Initialize("supposedproceeds");
            // 
            // colsupposedexpenditure
            // 
            this.colsupposedexpenditure.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedexpenditure.Title = "supposedexpenditure";
            this.colsupposedexpenditure.VisibleIndex = 7;
            this.colsupposedexpenditure.Initialize("supposedexpenditure");
            // 
            // colsupposedrevenue
            // 
            this.colsupposedrevenue.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedrevenue.Title = "supposedrevenue";
            this.colsupposedrevenue.VisibleIndex = 13;
            this.colsupposedrevenue.Initialize("supposedrevenue");
            // 
            // colincometopartitioncompetency
            // 
            this.colincometopartitioncompetency.SortDirection = Xceed.Grid.SortDirection.None;
            this.colincometopartitioncompetency.Title = "incometopartitioncompetency";
            this.colincometopartitioncompetency.VisibleIndex = 11;
            this.colincometopartitioncompetency.Initialize("incometopartitioncompetency");
            // 
            // colincometopartitioncash
            // 
            this.colincometopartitioncash.SortDirection = Xceed.Grid.SortDirection.None;
            this.colincometopartitioncash.Title = "incometopartitioncash";
            this.colincometopartitioncash.VisibleIndex = 9;
            this.colincometopartitioncash.Initialize("incometopartitioncash");
            // 
            // colcash
            // 
            this.colcash.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcash.Title = "cash";
            this.colcash.VisibleIndex = 14;
            this.colcash.Initialize("cash");
            // 
            // colcompetency
            // 
            this.colcompetency.SortDirection = Xceed.Grid.SortDirection.None;
            this.colcompetency.Title = "competency";
            this.colcompetency.VisibleIndex = 12;
            this.colcompetency.Initialize("competency");
            // 
            // colsupposedcreditsurplus
            // 
            this.colsupposedcreditsurplus.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedcreditsurplus.Title = "supposedcreditsurplus";
            this.colsupposedcreditsurplus.VisibleIndex = 8;
            this.colsupposedcreditsurplus.Initialize("supposedcreditsurplus");
            // 
            // colsupposedfloatfund
            // 
            this.colsupposedfloatfund.SortDirection = Xceed.Grid.SortDirection.None;
            this.colsupposedfloatfund.Title = "supposedfloatfund";
            this.colsupposedfloatfund.VisibleIndex = 6;
            this.colsupposedfloatfund.Initialize("supposedfloatfund");
            // 
            // colprevision2
            // 
            this.colprevision2.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision2.Title = "prevision2";
            this.colprevision2.VisibleIndex = 15;
            this.colprevision2.Initialize("prevision2");
            // 
            // colprevision3
            // 
            this.colprevision3.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision3.Title = "prevision3";
            this.colprevision3.VisibleIndex = 16;
            this.colprevision3.Initialize("prevision3");
            // 
            // colprevision4
            // 
            this.colprevision4.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision4.Title = "prevision4";
            this.colprevision4.VisibleIndex = 17;
            this.colprevision4.Initialize("prevision4");
            // 
            // colprevision5
            // 
            this.colprevision5.SortDirection = Xceed.Grid.SortDirection.None;
            this.colprevision5.Title = "prevision5";
            this.colprevision5.VisibleIndex = 18;
            this.colprevision5.Initialize("prevision5");
            // 
            // colavailableprevision
            // 
            this.colavailableprevision.SortDirection = Xceed.Grid.SortDirection.None;
            this.colavailableprevision.Title = "availableprevision";
            this.colavailableprevision.VisibleIndex = 10;
            this.colavailableprevision.Initialize("availableprevision");
            // 
            // dataRowTemplate2
            // 
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2idfin);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2codefin);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2title);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2floatfund);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2supposedpayments);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2supposedproceeds);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2supposedexpenditure);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2supposedrevenue);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2incometopartitioncompetency);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2incometopartitioncash);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2cash);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2competency);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2supposedcreditsurplus);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2supposedfloatfund);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2prevision2);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2prevision3);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2prevision4);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2prevision5);
            this.dataRowTemplate2.Cells.Add(this.celldataRowTemplate2availableprevision);
            this.celldataRowTemplate2idfin.Initialize("idfin");
            this.celldataRowTemplate2codefin.Initialize("codefin");
            this.celldataRowTemplate2title.Initialize("title");
            this.celldataRowTemplate2floatfund.Initialize("floatfund");
            this.celldataRowTemplate2supposedpayments.Initialize("supposedpayments");
            this.celldataRowTemplate2supposedproceeds.Initialize("supposedproceeds");
            this.celldataRowTemplate2supposedexpenditure.Initialize("supposedexpenditure");
            this.celldataRowTemplate2supposedrevenue.Initialize("supposedrevenue");
            this.celldataRowTemplate2incometopartitioncompetency.Initialize("incometopartitioncompetency");
            this.celldataRowTemplate2incometopartitioncash.Initialize("incometopartitioncash");
            this.celldataRowTemplate2cash.Initialize("cash");
            this.celldataRowTemplate2competency.Initialize("competency");
            this.celldataRowTemplate2supposedcreditsurplus.Initialize("supposedcreditsurplus");
            this.celldataRowTemplate2supposedfloatfund.Initialize("supposedfloatfund");
            this.celldataRowTemplate2prevision2.Initialize("prevision2");
            this.celldataRowTemplate2prevision3.Initialize("prevision3");
            this.celldataRowTemplate2prevision4.Initialize("prevision4");
            this.celldataRowTemplate2prevision5.Initialize("prevision5");
            this.celldataRowTemplate2availableprevision.Initialize("availableprevision");
            // 
            // DS3
            // 
            this.DS3.DataSetName = "tempds";
            this.DS3.EnforceConstraints = false;
            this.DS3.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // groupByRow2
            // 
            this.groupByRow2.AllowGroupingModification = false;
            this.groupByRow2.ReadOnly = true;
            this.groupByRow2.Visible = false;
            // 
            // columnManagerRow2
            // 
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2idfin);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2codefin);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2title);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2floatfund);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedpayments);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedproceeds);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedexpenditure);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedrevenue);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2incometopartitioncompetency);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2incometopartitioncash);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2cash);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2competency);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedcreditsurplus);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2supposedfloatfund);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2prevision2);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2prevision3);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2prevision4);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2prevision5);
            this.columnManagerRow2.Cells.Add(this.cellcolumnManagerRow2availableprevision);
            this.columnManagerRow2.Height = 32;
            this.cellcolumnManagerRow2idfin.Initialize("idfin");
            this.cellcolumnManagerRow2codefin.Initialize("codefin");
            this.cellcolumnManagerRow2title.Initialize("title");
            this.cellcolumnManagerRow2floatfund.Initialize("floatfund");
            this.cellcolumnManagerRow2supposedpayments.Initialize("supposedpayments");
            this.cellcolumnManagerRow2supposedproceeds.Initialize("supposedproceeds");
            this.cellcolumnManagerRow2supposedexpenditure.Initialize("supposedexpenditure");
            this.cellcolumnManagerRow2supposedrevenue.Initialize("supposedrevenue");
            this.cellcolumnManagerRow2incometopartitioncompetency.Initialize("incometopartitioncompetency");
            this.cellcolumnManagerRow2incometopartitioncash.Initialize("incometopartitioncash");
            this.cellcolumnManagerRow2cash.Initialize("cash");
            this.cellcolumnManagerRow2competency.Initialize("competency");
            this.cellcolumnManagerRow2supposedcreditsurplus.Initialize("supposedcreditsurplus");
            this.cellcolumnManagerRow2supposedfloatfund.Initialize("supposedfloatfund");
            this.cellcolumnManagerRow2prevision2.Initialize("prevision2");
            this.cellcolumnManagerRow2prevision3.Initialize("prevision3");
            this.cellcolumnManagerRow2prevision4.Initialize("prevision4");
            this.cellcolumnManagerRow2prevision5.Initialize("prevision5");
            this.cellcolumnManagerRow2availableprevision.Initialize("availableprevision");
            // 
            // tabTotali
            // 
            this.tabTotali.Controls.Add(this.label17);
            this.tabTotali.Controls.Add(this.label16);
            this.tabTotali.Controls.Add(this.label15);
            this.tabTotali.Controls.Add(this.label14);
            this.tabTotali.Controls.Add(this.label12);
            this.tabTotali.Controls.Add(this.txtResiduiAttiviRipartiti);
            this.tabTotali.Controls.Add(this.labResAttPresRip);
            this.tabTotali.Controls.Add(this.groupBox2);
            this.tabTotali.Controls.Add(this.groupBox1);
            this.tabTotali.Controls.Add(this.labPagPresunti);
            this.tabTotali.Controls.Add(this.txtResPassiviPresunti);
            this.tabTotali.Controls.Add(this.labIncPresunti);
            this.tabTotali.Controls.Add(this.labFCassaPres);
            this.tabTotali.Controls.Add(this.txtPagamentiPresunti);
            this.tabTotali.Controls.Add(this.labResPassPres);
            this.tabTotali.Controls.Add(this.txtResAttiviPresunti);
            this.tabTotali.Controls.Add(this.txtAvanzoPresunto);
            this.tabTotali.Controls.Add(this.txtIncassiPresunti);
            this.tabTotali.Controls.Add(this.txtFondoCassaPresunto);
            this.tabTotali.Controls.Add(this.labFCassa);
            this.tabTotali.Controls.Add(this.labResAttPres);
            this.tabTotali.Controls.Add(this.labAvaAmmPres);
            this.tabTotali.Controls.Add(this.txtTotFondoCassa);
            this.tabTotali.Location = new System.Drawing.Point(4, 22);
            this.tabTotali.Name = "tabTotali";
            this.tabTotali.Size = new System.Drawing.Size(672, 350);
            this.tabTotali.TabIndex = 1;
            this.tabTotali.Text = "Totali";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Location = new System.Drawing.Point(472, 192);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(192, 32);
            this.label17.TabIndex = 45;
            this.label17.Text = "-- Entrate da assegnare competenza = Prev.Competenza di Entrata";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.Location = new System.Drawing.Point(472, 224);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(192, 32);
            this.label16.TabIndex = 44;
            this.label16.Text = "-- Entrate da assegnare cassa = Prev.Cassa di Entrata";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.Location = new System.Drawing.Point(472, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(192, 32);
            this.label15.TabIndex = 43;
            this.label15.Text = "-- Residui attivi presunti = Residui attivi ripartiti in uscita";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(472, 144);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 16);
            this.label14.TabIndex = 42;
            this.label14.Text = "Dovrebbe risultare:";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(472, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "Nota";
            // 
            // txtResiduiAttiviRipartiti
            // 
            this.txtResiduiAttiviRipartiti.Location = new System.Drawing.Point(32, 128);
            this.txtResiduiAttiviRipartiti.Name = "txtResiduiAttiviRipartiti";
            this.txtResiduiAttiviRipartiti.ReadOnly = true;
            this.txtResiduiAttiviRipartiti.Size = new System.Drawing.Size(100, 20);
            this.txtResiduiAttiviRipartiti.TabIndex = 40;
            this.txtResiduiAttiviRipartiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labResAttPresRip
            // 
            this.labResAttPresRip.Location = new System.Drawing.Point(32, 112);
            this.labResAttPresRip.Name = "labResAttPresRip";
            this.labResAttPresRip.Size = new System.Drawing.Size(248, 16);
            this.labResAttPresRip.TabIndex = 39;
            this.labResAttPresRip.Text = "Residui attivi presunti riparititi in uscita";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIncomeCompetency);
            this.groupBox2.Controls.Add(this.txtIncomeCash);
            this.groupBox2.Controls.Add(this.labIncomeCash);
            this.groupBox2.Controls.Add(this.labIncomeCompetency);
            this.groupBox2.Location = new System.Drawing.Point(16, 280);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(424, 48);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parte ENTRATE";
            // 
            // txtIncomeCompetency
            // 
            this.txtIncomeCompetency.Location = new System.Drawing.Point(120, 16);
            this.txtIncomeCompetency.Name = "txtIncomeCompetency";
            this.txtIncomeCompetency.ReadOnly = true;
            this.txtIncomeCompetency.Size = new System.Drawing.Size(88, 20);
            this.txtIncomeCompetency.TabIndex = 34;
            this.txtIncomeCompetency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIncomeCash
            // 
            this.txtIncomeCash.Location = new System.Drawing.Point(304, 16);
            this.txtIncomeCash.Name = "txtIncomeCash";
            this.txtIncomeCash.ReadOnly = true;
            this.txtIncomeCash.Size = new System.Drawing.Size(104, 20);
            this.txtIncomeCash.TabIndex = 33;
            this.txtIncomeCash.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labIncomeCash
            // 
            this.labIncomeCash.Location = new System.Drawing.Point(224, 16);
            this.labIncomeCash.Name = "labIncomeCash";
            this.labIncomeCash.Size = new System.Drawing.Size(64, 16);
            this.labIncomeCash.TabIndex = 1;
            this.labIncomeCash.Text = "Prev.cassa";
            this.labIncomeCash.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labIncomeCompetency
            // 
            this.labIncomeCompetency.Location = new System.Drawing.Point(8, 16);
            this.labIncomeCompetency.Name = "labIncomeCompetency";
            this.labIncomeCompetency.Size = new System.Drawing.Size(100, 23);
            this.labIncomeCompetency.TabIndex = 0;
            this.labIncomeCompetency.Text = "Prev.competenza";
            this.labIncomeCompetency.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labCassa);
            this.groupBox1.Controls.Add(this.txtPrevisioneCassa);
            this.groupBox1.Controls.Add(this.txtPrevisioneCompetenza);
            this.groupBox1.Controls.Add(this.labCompetenza);
            this.groupBox1.Controls.Add(this.txtAssegnareCassa);
            this.groupBox1.Controls.Add(this.labAssCassa);
            this.groupBox1.Controls.Add(this.txtAssegnareCompetenza);
            this.groupBox1.Controls.Add(this.labAssCompetenza);
            this.groupBox1.Location = new System.Drawing.Point(16, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 96);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parte USCITE";
            // 
            // labCassa
            // 
            this.labCassa.Location = new System.Drawing.Point(232, 16);
            this.labCassa.Name = "labCassa";
            this.labCassa.Size = new System.Drawing.Size(64, 23);
            this.labCassa.TabIndex = 35;
            this.labCassa.Text = "Previsione Cassa";
            this.labCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrevisioneCassa
            // 
            this.txtPrevisioneCassa.Location = new System.Drawing.Point(312, 16);
            this.txtPrevisioneCassa.Name = "txtPrevisioneCassa";
            this.txtPrevisioneCassa.ReadOnly = true;
            this.txtPrevisioneCassa.Size = new System.Drawing.Size(104, 20);
            this.txtPrevisioneCassa.TabIndex = 36;
            this.txtPrevisioneCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPrevisioneCompetenza
            // 
            this.txtPrevisioneCompetenza.Location = new System.Drawing.Point(112, 16);
            this.txtPrevisioneCompetenza.Name = "txtPrevisioneCompetenza";
            this.txtPrevisioneCompetenza.ReadOnly = true;
            this.txtPrevisioneCompetenza.Size = new System.Drawing.Size(88, 20);
            this.txtPrevisioneCompetenza.TabIndex = 34;
            this.txtPrevisioneCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labCompetenza
            // 
            this.labCompetenza.Location = new System.Drawing.Point(32, 16);
            this.labCompetenza.Name = "labCompetenza";
            this.labCompetenza.Size = new System.Drawing.Size(72, 24);
            this.labCompetenza.TabIndex = 33;
            this.labCompetenza.Text = "Previsione Competenza";
            this.labCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssegnareCassa
            // 
            this.txtAssegnareCassa.Location = new System.Drawing.Point(312, 56);
            this.txtAssegnareCassa.Name = "txtAssegnareCassa";
            this.txtAssegnareCassa.ReadOnly = true;
            this.txtAssegnareCassa.Size = new System.Drawing.Size(104, 20);
            this.txtAssegnareCassa.TabIndex = 30;
            this.txtAssegnareCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labAssCassa
            // 
            this.labAssCassa.Location = new System.Drawing.Point(206, 51);
            this.labAssCassa.Name = "labAssCassa";
            this.labAssCassa.Size = new System.Drawing.Size(98, 32);
            this.labAssCassa.TabIndex = 29;
            this.labAssCassa.Text = "Entrate da assegnare cassa";
            this.labAssCassa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAssegnareCompetenza
            // 
            this.txtAssegnareCompetenza.Location = new System.Drawing.Point(112, 56);
            this.txtAssegnareCompetenza.Name = "txtAssegnareCompetenza";
            this.txtAssegnareCompetenza.ReadOnly = true;
            this.txtAssegnareCompetenza.Size = new System.Drawing.Size(88, 20);
            this.txtAssegnareCompetenza.TabIndex = 32;
            this.txtAssegnareCompetenza.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAssegnareCompetenza.TextChanged += new System.EventHandler(this.txtAssegnareCompetenza_TextChanged);
            // 
            // labAssCompetenza
            // 
            this.labAssCompetenza.Location = new System.Drawing.Point(-3, 51);
            this.labAssCompetenza.Name = "labAssCompetenza";
            this.labAssCompetenza.Size = new System.Drawing.Size(112, 37);
            this.labAssCompetenza.TabIndex = 31;
            this.labAssCompetenza.Text = "Entrate da assegnare competenza";
            this.labAssCompetenza.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labAssCompetenza.Click += new System.EventHandler(this.labAssCompetenza_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(560, 8);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(104, 23);
            this.btnExcel.TabIndex = 18;
            this.btnExcel.Text = "Esporta in Excel";
            this.btnExcel.Click += new System.EventHandler(this.BtnExcel_Click);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(8, 40);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "UPB";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkConsolida
            // 
            this.chkConsolida.Location = new System.Drawing.Point(256, 40);
            this.chkConsolida.Name = "chkConsolida";
            this.chkConsolida.Size = new System.Drawing.Size(168, 16);
            this.chkConsolida.TabIndex = 21;
            this.chkConsolida.Text = "Visualizza dati consolidati";
            this.chkConsolida.CheckedChanged += new System.EventHandler(this.chkConsolida_CheckedChanged);
            // 
            // cmbUpb
            // 
            this.cmbUpb.DataSource = this.DS.upb;
            this.cmbUpb.DisplayMember = "codeupb";
            this.cmbUpb.Location = new System.Drawing.Point(48, 40);
            this.cmbUpb.Name = "cmbUpb";
            this.cmbUpb.Size = new System.Drawing.Size(192, 21);
            this.cmbUpb.TabIndex = 19;
            this.cmbUpb.ValueMember = "idupb";
            this.cmbUpb.SelectedIndexChanged += new System.EventHandler(this.cmbUpb_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // Frm_prevfin_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(680, 453);
            this.Controls.Add(this.chkConsolida);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbUpb);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnRicalcola);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnSalvaDatiPrevisione);
            this.Name = "Frm_prevfin_default";
            this.Text = "Bilancio di previsione";
            ((System.ComponentModel.ISupportInitialize)(this.DS2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPrevisione.ResumeLayout(false);
            this.tabEntrata.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow2)).EndInit();
            this.tabTotali.ResumeLayout(false);
            this.tabTotali.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		public Frm_prevfin_default() {
			//
			// Required for Windows Form Designer support
			//
            
            InitializeComponent();

			DS2.EnforceConstraints=false;
			gridControl1.DataSource= DS2.Tables["prevfindetail"];

		}



		/// <summary>
		/// Le formule sono sempre le stesse però i valori di alcuni campi sono a volte azzerati 
		/// per fare quadrare i valori  (nel caso di UPB a fin. certo)
		/// </summary>
		void SetFormulas(){

			if (DoConsolida || curridupb==DBNull.Value){
				//Clear all formulas
				DS2.prevfindetail.Columns["supposedfloatfund"].Expression="";
				DS2.prevfindetail.Columns["supposedcreditsurplus"].Expression="";
				DS2.prevfindetail.Columns["incometopartitioncash"].Expression="";
				DS2.prevfindetail.Columns["competency"].Expression="";
                DS3.prevfindetail.Columns["competency"].Expression= "";
				DS2.prevfindetail.Columns["cash"].Expression="";
				DS3.prevfindetail.Columns["cash"].Expression="";
				gridControl1.SetDataBinding( DS2.prevfindetail, null );
				gridControl2.SetDataBinding(DS3.prevfindetail,null);
				return;
			}

			bool FinAssured=false;
			if (curridupb!=DBNull.Value){
				System.Data.DataRow UPBRow= DS.upb.Select(QHC.CmpEq("idupb",curridupb))[0];
				if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
			}

			string fondocassapresuntoexpr="isnull(floatfund,0)+isnull(supposedproceeds,0)-isnull(supposedpayments,0)";
			DS2.prevfindetail.Columns["supposedfloatfund"].Expression=	fondocassapresuntoexpr;

			string avanzoamministrazionepresuntoexpr=fondocassapresuntoexpr+"+isnull(supposedrevenue,0)-isnull(supposedexpenditure,0)";
			DS2.prevfindetail.Columns["supposedcreditsurplus"].Expression=avanzoamministrazionepresuntoexpr;


            if (!SolaCassa) {
                DS2.prevfindetail.Columns["incometopartitioncash"].Expression = "";
                    //"isnull(cash,0)-isnull(supposedfloatfund,0)";
            }
            else {
                DS2.prevfindetail.Columns["incometopartitioncash"].Expression = "";
                DS2.prevfindetail.Columns["incometopartitioncash"].ReadOnly = false;
            }



			if (!FinAssured){
				DS2.prevfindetail.Columns["competency"].Expression=
					avanzoamministrazionepresuntoexpr+"+isnull(incometopartitioncompetency,0)";
				DS2.prevfindetail.Columns["competency"].ReadOnly=true;
			}
			else {
				DS2.prevfindetail.Columns["competency"].Expression= "";
				DS2.prevfindetail.Columns["competency"].ReadOnly=false;
				
			}

            if (!FinAssured) {
                    DS2.prevfindetail.Columns["cash"].Expression =
                        "isnull(incometopartitioncash,0)+isnull(supposedfloatfund,0)";
                    DS2.prevfindetail.Columns["cash"].ReadOnly = true;
             }
            else {
                DS2.prevfindetail.Columns["cash"].Expression = "";
                DS2.prevfindetail.Columns["cash"].ReadOnly = false;
            }
            DS3.prevfindetail.Columns["cash"].Expression = "";
            DS3.prevfindetail.Columns["cash"].ReadOnly = false;
			gridControl1.SetDataBinding( DS2.prevfindetail, null );
			gridControl2.SetDataBinding( DS3.prevfindetail, null );

		}

		public void MetaData_AfterPost(){
			if (!DS.HasChanges()){
				CopyDStoXceed();
				//AddDescriptions();
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
		public void MetaData_AfterLink(){
			Meta= MetaData.GetMetaData(this);
			Conn=Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			esercizio= Convert.ToInt32(Meta.GetSys("esercizio"));
            newesercizio = esercizio + 1;
            string filter = QHS.CmpEq("ayear", esercizio);
            string newfilter = QHS.CmpEq("ayear", newesercizio);
            GetData.SetStaticFilter(DS.prevfin, filter);
			GetData.CacheTable(DS.accountingyear,filter,null,false);
			GetData.CacheTable(DS.finlevel,newfilter,null,false);
			GetData.CacheTable(DS.config,filter,null,false);			
			GetData.CacheTable(DS.upb,null,"codeupb",true);
            this.Name = "Bilancio Previsione " + newesercizio;
        }

		public void MetaData_BeforeActivation(){
            string newfilter = QHS.CmpEq("ayear", newesercizio);
            MyBilancio = Conn.RUN_SELECT("fin", "*", "codefin", newfilter, null, null, false);
            string filter = QHS.CmpEq("ayear", esercizio);
            int finkind = CfgFn.GetNoNullInt32(Conn.DO_READ_VALUE("config", filter, "fin_kind"));
            //string tipoprincipale;
            //string tiposecondaria;
            if (finkind == 1) {
                //tipoprincipale = "C";
                //tiposecondaria = "";
                AbilitaColonneCassa = false;
            }
            if (finkind == 2) {
                //tipoprincipale = "S";
                //tiposecondaria = "";
                SolaCassa = true;
                AbilitaColonneCassa = true;
                campoprevcassa = "prevision";
                //campoprevcassaprecedente = "previousprevision";

            }
            if (finkind == 3) {
                //tipoprincipale = "C";
                //tiposecondaria = "S";
                AbilitaColonneCassa = true;
                campoprevcassa = "secondaryprev";
                //campoprevcassaprecedente = "previoussecondaryprev";

            }

			campoprevcompetenza="prevision";
			//campoprevcompetenzaprecedente="previousprevision";

            System.Data.DataRow E= DS.accountingyear.Rows[0];
			if ((DS.finlevel.Rows.Count==0) ||
                ((CfgFn.GetNoNullInt32(E["flag"]) & 0x0F) < 2) ||
                ((CfgFn.GetNoNullInt32(E["flag"]) & 0x0F) > 5)
                ){
				MessageBox.Show("In questa fase non è possibile eseguire questo form.");
				Meta.CanSave=false;
				Meta.CanInsert=false;
				Meta.CanInsertCopy=false;
				//Meta.SearchEnabled=false;
				//btnRicalcola.Enabled=false;
				btnSalvaDatiPrevisione.Enabled=false;
				//return;
			}
  
            codicelivellooperativo = DS.finlevel.Compute("min(nlevel)", QHC.BitSet("flag", 1));
			
            SetFormulas();
			ImpostaHeaders();

			
		}

        void RicalcolaCampiCalcolati() {
            foreach (System.Data.DataRow R in DS.prevfindetail.Rows) {
                if (R.RowState == DataRowState.Deleted) continue;
                object idfin = R["idfin"];
                if (idfin == DBNull.Value) continue;
                System.Data.DataRow[] foundFin = MyBilancio.Select(QHC.CmpEq("idfin", idfin));
                if (foundFin.Length == 0) continue;
                int flag =CfgFn.GetNoNullInt32(foundFin[0]["flag"]);
                string E_S = ((flag & 1) == 0) ? "E" : "S";

                bool FinAssured = false;
                System.Data.DataRow[] foundUpb = DS.upb.Select(QHC.MCmp(R, "idupb"));
                if (foundUpb.Length == 0) continue;
                System.Data.DataRow UPBRow = foundUpb[0];
                if (UPBRow["assured"].ToString().ToUpper() == "S") FinAssured = true;

                if (E_S == "S") {
                    decimal fondocassapresuntoexpr = CfgFn.GetNoNullDecimal(R["floatfund"]) +
                        CfgFn.GetNoNullDecimal(R["supposedproceeds"]) - CfgFn.GetNoNullDecimal(R["supposedpayments"]);

                    decimal avanzoamministrazionepresuntoexpr = fondocassapresuntoexpr +
                        CfgFn.GetNoNullDecimal(R["supposedrevenue"]) - CfgFn.GetNoNullDecimal(R["supposedexpenditure"]);

                    R["supposedfloatfund"] = fondocassapresuntoexpr;
                    R["supposedcreditsurplus"] = avanzoamministrazionepresuntoexpr;


                    if (!FinAssured) {
                        decimal competencyexpr =
                            avanzoamministrazionepresuntoexpr + CfgFn.GetNoNullDecimal(R["incometopartitioncompetency"]);
                        R["competency"] = competencyexpr;
                    }

                    if (!FinAssured) {
                        decimal cashexpr = CfgFn.GetNoNullDecimal(R["supposedfloatfund"]) +
                                       CfgFn.GetNoNullDecimal(R["incometopartitioncash"]);
                        R["cash"] = cashexpr;                       
                    }
                   
                }
                else {
                    if (!SolaCassa) {
                        decimal cashexpr = 
                            CfgFn.GetNoNullDecimal(R["supposedrevenue"]) + CfgFn.GetNoNullDecimal(R["competency"]);
                        //R["cash"] = cashexpr;
                    }

                }
            }
        }

		void ImpostaHeaders(){
			bool Disabled= (curridupb==DBNull.Value) || DoConsolida;
			bool FinAssured=false;
            if (curridupb != DBNull.Value) {
				System.Data.DataRow UPBRow= DS.upb.Select(QHC.CmpEq("idupb",curridupb))[0];
				if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
			}
			colcodicebilancio.Title=				"Cod.Bil.";
			colcodicebilancio.CanBeSorted=false;
			colcodicebilancio.CanBeGrouped=false;
			colcodicebilancio.BackColor= Color.GreenYellow;
			colcodicebilancio.ReadOnly=true;
			colcodefin.VisibleIndex= 1;

			coldenominazione.Title="Denominazione";
			coldenominazione.CanBeSorted=false;
			coldenominazione.CanBeGrouped=false;
			coldenominazione.ReadOnly=true;
			coldenominazione.BackColor= Color.YellowGreen;
			colcodefin.VisibleIndex= 2;

			colfondocassa.Title=					"Fondo cassa alla data";			
			colfondocassa.CanBeSorted=false;
			colfondocassa.CanBeGrouped=false;
			colfondocassa.Width=80;
			colfondocassa.ReadOnly=Disabled;
			colfondocassa.Visible=!FinAssured;
			colfondocassa.VisibleIndex= 3;

			colincassipresunti.Title=				"Incassi Presunti";
			colincassipresunti.CanBeSorted=false;
			colincassipresunti.CanBeGrouped=false;
			colincassipresunti.Width=70;
			colincassipresunti.ReadOnly=Disabled;
			colincassipresunti.Visible=!FinAssured;
			colincassipresunti.VisibleIndex= 4;

			colpagamentipresunti.Title=				"Pagam. Presunti";
			colpagamentipresunti.CanBeSorted=false;
			colpagamentipresunti.CanBeGrouped=false;
			colpagamentipresunti.Width=70;
			colpagamentipresunti.ReadOnly=Disabled;
			colpagamentipresunti.Visible=!FinAssured;
			colcodefin.VisibleIndex= 5;

			colfondocassapresunto.Title=			"Avanzo cassa presunto";
			colfondocassapresunto.CanBeSorted=false;
			colfondocassapresunto.CanBeGrouped=false;
			colfondocassapresunto.BackColor= Color.Salmon;
			colfondocassapresunto.Width=90;
			colfondocassapresunto.ReadOnly=Disabled;
			colfondocassapresunto.Visible= !FinAssured;
			colfondocassapresunto.Visible=!FinAssured;
			colcodefin.VisibleIndex= 6;


			colresiduiattivipresunti.Title=			"Res. Attivi Presunti";
			colresiduiattivipresunti.CanBeSorted=false;
			colresiduiattivipresunti.CanBeGrouped=false;
			colresiduiattivipresunti.Width=70;
			colresiduiattivipresunti.ReadOnly=Disabled;
			colresiduiattivipresunti.Visible=(!FinAssured) && (!SolaCassa);
			colresiduiattivipresunti.VisibleIndex= 7;

			
			colavailableprevision1.Title="Previsione Disponibile";
			colavailableprevision1.CanBeSorted=false;
			colavailableprevision1.CanBeGrouped=false;
			colavailableprevision1.Width=70;
			colavailableprevision1.ReadOnly=(!FinAssured) || Disabled;
			colavailableprevision1.Visible=FinAssured ;
			colresiduiattivipresunti.VisibleIndex= 8;

			colresiduipassivipresunti.Title=		"Res. Passivi Presunti";
			colresiduipassivipresunti.CanBeSorted=false;
			colresiduipassivipresunti.CanBeGrouped=false;
			colresiduipassivipresunti.Width=70;
			colresiduipassivipresunti.ReadOnly=Disabled;
			colresiduipassivipresunti.Visible= (!SolaCassa); //!FinAssured;
			colresiduipassivipresunti.VisibleIndex= FinAssured ? 14 : 9;


			colavanzoamministrazionepresunto.Title=	"Avanzo Amm. presunto";
			colavanzoamministrazionepresunto.CanBeSorted=false;
			colavanzoamministrazionepresunto.CanBeGrouped=false;
			colavanzoamministrazionepresunto.BackColor= Color.Tomato;
			colavanzoamministrazionepresunto.Width=80;
			colavanzoamministrazionepresunto.ReadOnly=Disabled;
			colavanzoamministrazionepresunto.Visible= (!FinAssured) && (!SolaCassa);
			colavanzoamministrazionepresunto.VisibleIndex= 10;
			

			colentratedaassegnarecompetenza.Title=	"Entrate da ass. Comp.";
			colentratedaassegnarecompetenza.CanBeSorted=false;
			colentratedaassegnarecompetenza.CanBeGrouped=false;
			//colentratedaassegnarecompetenza.Visible= AbilitaColonneCompetenza && (!SolaCassa) ;
			colentratedaassegnarecompetenza.Width=70;
			colentratedaassegnarecompetenza.ReadOnly=Disabled;
            colentratedaassegnarecompetenza.Visible = AbilitaColonneCompetenza && (!FinAssured) && (!SolaCassa);
			colentratedaassegnarecompetenza.VisibleIndex= 11;


			colentratedaassegnarecassa.Title=		"Entrate da ass. Cassa";
			colentratedaassegnarecassa.CanBeSorted=false;
			colentratedaassegnarecassa.CanBeGrouped=false;
			colentratedaassegnarecassa.Width=70;
			colentratedaassegnarecassa.Visible= AbilitaColonneCassa && !FinAssured;
            colentratedaassegnarecassa.ReadOnly = Disabled;// !SolaCassa;
			colentratedaassegnarecassa.VisibleIndex= 12;


			colbilancioprevisionecompetenza.Title=	"Previsione Competenza";
			colbilancioprevisionecompetenza.CanBeSorted=false;
			colbilancioprevisionecompetenza.CanBeGrouped=false;
			colbilancioprevisionecompetenza.BackColor= Color.Tomato;
			colbilancioprevisionecompetenza.Visible= AbilitaColonneCompetenza && (!SolaCassa);
			colbilancioprevisionecompetenza.Width=75;
			colbilancioprevisionecompetenza.VisibleIndex= 13;
			bool READ_ONLY = (!FinAssured) || Disabled;
			colbilancioprevisionecompetenza.ReadOnly =READ_ONLY;
			cellcolumnManagerRow1competency.ReadOnly=READ_ONLY ;
			celldataRowTemplate1competency.ReadOnly=READ_ONLY ;

			if (!SolaCassa)
                colbilancioprevisionecassa.Title=		"Previsione Cassa";
            else
                colbilancioprevisionecassa.Title = "Previsione";
			colbilancioprevisionecassa.CanBeSorted=false;
			colbilancioprevisionecassa.CanBeGrouped=false;
			colbilancioprevisionecassa.BackColor= Color.Salmon;
			colbilancioprevisionecassa.Width=70;
			colbilancioprevisionecassa.Visible= AbilitaColonneCassa;
            colbilancioprevisionecassa.ReadOnly = Disabled || !FinAssured;
			colbilancioprevisionecassa.VisibleIndex= 15;


			int esercizio= (int) Conn.GetSys("esercizio");
			esercizio++;


			esercizio++;
			colprevision2.Title="Previsione "+esercizio.ToString();			
			colprevision2.CanBeSorted=false;
			colprevision2.CanBeGrouped=false;
			colprevision2.Width=70;
			colprevision2.ReadOnly=Disabled;

			colprevision21.Title="Previsione "+esercizio.ToString();			
			colprevision21.CanBeSorted=false;
			colprevision21.CanBeGrouped=false;
			colprevision21.Width=70;
			colprevision21.ReadOnly=Disabled;
			colprevision21.VisibleIndex= 16;

			esercizio++;
			colprevision3.Title="Previsione "+esercizio.ToString();			
			colprevision3.CanBeSorted=false;
			colprevision3.CanBeGrouped=false;
			colprevision3.Width=70;
			colprevision3.ReadOnly=Disabled;

			colprevision31.Title="Previsione "+esercizio.ToString();			
			colprevision31.CanBeSorted=false;
			colprevision31.CanBeGrouped=false;
			colprevision31.Width=70;
			colprevision31.ReadOnly=Disabled;
			colprevision31.VisibleIndex= 17;

			esercizio++;
			colprevision4.Title="Previsione "+esercizio.ToString();			
			colprevision4.CanBeSorted=false;
			colprevision4.CanBeGrouped=false;
			colprevision4.Width=70;
			colprevision4.ReadOnly=Disabled;

			colprevision41.Title="Previsione "+esercizio.ToString();			
			colprevision41.CanBeSorted=false;
			colprevision41.CanBeGrouped=false;
			colprevision41.Width=70;
			colprevision41.ReadOnly=Disabled;
			colprevision41.VisibleIndex= 18;

			esercizio++;
			colprevision5.Title="Previsione "+esercizio.ToString();			
			colprevision5.CanBeSorted=false;
			colprevision5.CanBeGrouped=false;
			colprevision5.Width=70;
			colprevision5.ReadOnly=Disabled;

			colprevision51.Title="Previsione "+esercizio.ToString();			
			colprevision51.CanBeSorted=false;
			colprevision51.CanBeGrouped=false;
			colprevision51.Width=70;
			colprevision51.ReadOnly=Disabled;
			colprevision51.VisibleIndex= 19;


			colidbilancio.Visible=false;


			
			colcodefin.Title=				"Cod.Bil.";
			colcodefin.CanBeSorted=false;
			colcodefin.CanBeGrouped=false;
			colcodefin.BackColor= Color.GreenYellow;
			colcodefin.ReadOnly=true;			

			coltitle.Title="Denominazione";
			coltitle.CanBeSorted=false;
			coltitle.CanBeGrouped=false;
			coltitle.ReadOnly=true;
			coltitle.BackColor= Color.YellowGreen;

			colavailableprevision.Title="Previsione Disponibile";
			colavailableprevision.CanBeSorted=false;
			colavailableprevision.CanBeGrouped=false;
			colavailableprevision.Width=80;
			colavailableprevision.ReadOnly=(!FinAssured) || Disabled;
            colavailableprevision.Visible = FinAssured;


		    colcompetency.Title="Previsione Competenza";
            colcompetency.CanBeSorted = false;
			colcompetency.CanBeGrouped=false;
			colcompetency.Width=80;
            colcompetency.ReadOnly = Disabled;//false;
            colcompetency.Visible = !SolaCassa;
            colcompetency.BackColor = Color.Tomato;

			colsupposedrevenue.Title="Residui Attivi presunti";
			colsupposedrevenue.CanBeSorted=false;
			colsupposedrevenue.CanBeGrouped=false;
            colsupposedrevenue.Visible = !SolaCassa;
			colsupposedrevenue.Width=90;
			colsupposedrevenue.ReadOnly=Disabled;

            //colcash.Title="Previsione Cassa";

            if (!SolaCassa)
                colcash.Title = "Previsione Cassa";
            else
                colcash.Title = "Previsione";

			colcash.CanBeSorted=false;
			colcash.CanBeGrouped=false;
			colcash.Width=70;
            colcash.Visible = AbilitaColonneCassa;
			colcash.ReadOnly=Disabled; // || !SolaCassa;



			colfloatfund.Visible=false;
			colidfin.Visible=false;
			colincometopartitioncash.Visible=false;
			colincometopartitioncompetency.Visible=false;
			colsupposedcreditsurplus.Visible=false;
			colsupposedexpenditure.Visible=false;
			colsupposedfloatfund.Visible=false;
			colsupposedpayments.Visible=false;
			colsupposedproceeds.Visible=false;
		}


		void FillEmptyTempTable(DataTable T, string finpart){
             finpart=finpart.ToUpper();
			foreach(System.Data.DataRow R in MyBilancio.Select(null,"codefin")){
                int flag = CfgFn.GetNoNullInt32( R["flag"]);
                if (((flag & 1) == 0) && (finpart == "S")) continue;
                if (((flag & 1) != 0) && (finpart == "E")) continue;
                object idfin = R["idfin"];
                //LASCIARE I TOSTRING, a questo punto un cast vale l'altro
				if (R["nlevel"].ToString().CompareTo(codicelivellooperativo.ToString())<0) continue;
                string filterchild = QHC.CmpEq("paridfin", idfin);
				if (MyBilancio.Select(filterchild).Length>0) continue;

				System.Data.DataRow NewR= T.NewRow();
				NewR["idfin"]= R["idfin"];
				NewR["codefin"]=R["codefin"];
                NewR["title"] = R["title"];
                T.Rows.Add(NewR);
			}
			
			T.AcceptChanges();


		}

		void ResetTempTables(){
			DS2.EnforceConstraints=false;
			if (DS2.prevfindetail.Rows.Count==0){
				FillEmptyTempTable(DS2.prevfindetail,"S");
			}
			else {
				foreach (System.Data.DataRow R in DS2.prevfindetail.Select(null,"codefin")){
					R.BeginEdit();
					foreach(DataColumn C in DS2.prevfindetail.Columns){
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
			DS3.EnforceConstraints=false;
			if (DS3.prevfindetail.Rows.Count==0){
				FillEmptyTempTable(DS3.prevfindetail,"E");
			}
			else {

				foreach (System.Data.DataRow R in DS3.prevfindetail.Select(null,"codefin")){
					R.BeginEdit();
					foreach(DataColumn C in DS3.prevfindetail.Columns){
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

            if (DoConsolida == false && curridupb != DBNull.Value) {
				//Non è possibile filtrare per finpart, lo faccio nel ciclo
				System.Data.DataRow[] R_E=DS.Tables["prevfindetail"].Select(QHC.CmpEq("idupb",curridupb));
					//"(idupb="+QueryCreator.quotedstrvalue(curridupb,false)+")AND(substring(idfin,3,1)='E')");
				System.Data.DataRow[] R_S=DS.Tables["prevfindetail"].Select(QHC.CmpEq("idupb",curridupb));
					//"(idupb="+QueryCreator.quotedstrvalue(curridupb,false)+")AND(substring(idfin,3,1)='S')");

				foreach (System.Data.DataRow RE in R_E){
                    string filter = QHC.CmpEq("idfin", RE["idfin"]);
                    System.Data.DataRow MyFin = MyBilancio.Select(filter)[0];
                    int flag = CfgFn.GetNoNullInt32( MyFin["flag"]);
                    if ((flag & 1) != 0) continue;
					System.Data.DataRow []FE = DS3.prevfindetail.Select(filter);
					foreach(System.Data.DataRow FFE in FE){
						FFE.BeginEdit();
						foreach(DataColumn C in DS3.prevfindetail.Columns){
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
                    int flag = CfgFn.GetNoNullInt32( MyFin["flag"]);
                    if ((flag & 1) == 0) continue;
                    System.Data.DataRow[] FS = DS2.prevfindetail.Select(filter);
					foreach(System.Data.DataRow FFS in FS){
						FFS.BeginEdit();
						foreach(DataColumn C in DS2.prevfindetail.Columns){
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
				foreach(System.Data.DataRow RE in DS3.prevfindetail.Rows){
                    string filter = QHC.AppAnd(filterUPB, QHC.CmpEq("idfin", RE["idfin"]));
					foreach(DataColumn C in DS3.prevfindetail.Columns){
						if (C.DataType != typeof(decimal)) continue;
						string expr= "SUM("+C.ColumnName+")";
						object O= DS.prevfindetail.Compute(expr,filter);
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
				foreach(System.Data.DataRow RS in DS2.prevfindetail.Rows){
					string filter= QHC.AppAnd(filterUPB, QHC.CmpEq("idfin", RS["idfin"]));
					foreach(DataColumn C in DS2.prevfindetail.Columns){
						if (C.DataType != typeof(decimal)) continue;
						string expr= "SUM("+C.ColumnName+")";
						object O= DS.prevfindetail.Compute(expr,filter);
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

		public void MetaData_AfterClear(){
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
        



		void GetSPTableToDS(DataTable SPTable){
			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();

			System.Data.DataRow CurrPrev=  DS.prevfin.Rows[0];

            foreach (System.Data.DataRow RDS in DS.prevfindetail.Select()) {
                string filter = QHC.MCmp(RDS, "idfin", "idupb");
                System.Data.DataRow[] Found = SPTable.Select(filter);
                if (Found.Length == 0) {
                    RDS["previousprevision"] = DBNull.Value;
                    RDS["previoussecondaryprev"] = DBNull.Value;
                    RDS["competency"] = DBNull.Value;
                    RDS["cash"] = DBNull.Value;
                    RDS["prevision2"] = DBNull.Value;
                    RDS["prevision3"] = DBNull.Value;
                    RDS["prevision4"] = DBNull.Value;
                    RDS["prevision5"] = DBNull.Value;
                    //RDS["secondaryprev"] = DBNull.Value;
                    //if (CopiaResiduiPassiviPresunti){
                    //RDS["currentarrears"] = DBNull.Value;
                    RDS["previousarrears"] = DBNull.Value;
                    RDS["supposedpayments"] = DBNull.Value;
                    RDS["supposedproceeds"] = DBNull.Value;
                    RDS["supposedexpenditure"] = DBNull.Value;
                    RDS["supposedrevenue"] = DBNull.Value;
                    RDS["supposedfloatfund"] = DBNull.Value;
                    RDS["supposedcreditsurplus"] = DBNull.Value;
                    RDS["incometopartitioncompetency"] = DBNull.Value;
                    RDS["incometopartitioncash"] = DBNull.Value;
                    RDS["availableprevision"] = DBNull.Value;
                }
            }


			//Deve adeguare DS.prevfindetail al contenuto delle tabelle temporanee
			foreach (System.Data.DataRow RE in SPTable.Rows){
				//Quattro casi: la riga in DS è da modificare, cancellare, creare, ripristinare!
                string filter = QHC.MCmp(RE, "idfin", "idupb");
				System.Data.DataRow []Found=DS.prevfindetail.Select(filter);
				//Vede se è da cancellare
				if (TuttoZero(RE)){
					//E' da cancellare, se c'è
					if (Found.Length>0){
						Found[0].Delete();
					}
					continue; 
				}
				//Vede se è da ripristinare 
				if (Found.Length==0){
					System.Data.DataRow []Deleted= DS.prevfindetail.Select(filter,null,DataViewRowState.Deleted);
					if (Deleted.Length>0){
						Deleted[0].RejectChanges();
						Found=DS.prevfindetail.Select(filter);
					}
				}
				//Vede se è da creare
				if (Found.Length==0){
					System.Data.DataRow NewRow= DS.prevfindetail.NewRow();
					NewRow["idupb"]= RE["idupb"];
					NewRow["idfin"]= RE["idfin"];
					NewRow["codefin"]= RE["codefin"];
					NewRow["ayear"]=CurrPrev["ayear"];
					NewRow["nprevfin"]=CurrPrev["nprevfin"];

					DS.prevfindetail.Rows.Add(NewRow);
					Found=DS.prevfindetail.Select(filter);
				}
				//A questo punto è da modificare
				System.Data.DataRow Curr=Found[0];
                Curr.BeginEdit();
				foreach(DataColumn C in DS.prevfindetail.Columns){
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
				//Elimina false modifiche se ve ne sono
				if (Curr.RowState==DataRowState.Modified){
					if (PostData.CheckForFalseUpdate(Curr))Curr.AcceptChanges();
				}

			}
            RicalcolaCampiCalcolati();
			Cursor.Current= Cursors.Default;

		}


		void GetTempTableToDS(DataTable TempTable){

			Cursor.Current = Cursors.WaitCursor;
			Application.DoEvents();

            System.Data.DataRow Main = DS.prevfin.Rows[0];
			MetaData metaPrevFinDet= MetaData.GetMetaData(this,"prevfindetail");
			metaPrevFinDet.SetDefaults(DS.prevfindetail);
			//Deve adeguare DS.prevfindetail al contenuto delle tabelle temporanee
			foreach (System.Data.DataRow RE in TempTable.Rows){
				RE.EndEdit();
				if (RE.RowState== DataRowState.Unchanged) continue;
				//Quattro casi: la riga in DS è da modificare, cancellare, creare, ripristinare!
                string filter = QHC.AppAnd(QHC.CmpEq("idfin", RE["idfin"]), QHC.CmpEq("idupb", curridupb));
				System.Data.DataRow []Found=DS.prevfindetail.Select(filter);
				//Vede se è da cancellare
				if (TuttoZero(RE)){
					//E' da cancellare, se c'è
                    if (Found.Length > 0) {
                        System.Data.DataRow R = Found[0];
                        //NON DEVE AZZERARE QUESTI VALORI, che non vanno MAI toccati in questo form
                        //R["previousprevision"] = DBNull.Value;
                        //R["previoussecondaryprev"] = DBNull.Value;
                        //R["previousarrears"] = DBNull.Value;

                        R["competency"] = DBNull.Value;
                        R["cash"] = DBNull.Value;
                        R["prevision2"] = DBNull.Value;
                        R["prevision3"] = DBNull.Value;
                        R["prevision4"] = DBNull.Value;
                        R["prevision5"] = DBNull.Value;
                        //R["secondaryprev"] = DBNull.Value;
                        //if (CopiaResiduiPassiviPresunti){
                        //R["currentarrears"] = DBNull.Value;
                        R["supposedpayments"] = DBNull.Value;
                        R["supposedproceeds"] = DBNull.Value;
                        R["supposedexpenditure"] = DBNull.Value;
                        R["supposedrevenue"] = DBNull.Value;
                        R["supposedfloatfund"] = DBNull.Value;
                        R["supposedcreditsurplus"] = DBNull.Value;
                        R["incometopartitioncompetency"] = DBNull.Value;
                        R["incometopartitioncash"] = DBNull.Value;
                        R["availableprevision"] = DBNull.Value;
                    }
				}
				//Vede se è da ripristinare 
				if (Found.Length==0){
					System.Data.DataRow []Deleted= DS.prevfindetail.Select(filter,null,DataViewRowState.Deleted);
					if (Deleted.Length>0){
						Deleted[0].RejectChanges();
						Found=DS.prevfindetail.Select(filter);
					}
				}
				//Vede se è da creare
				if (Found.Length==0){
					System.Data.DataRow NewRow= metaPrevFinDet.Get_New_Row(Main,DS.prevfindetail);					
					NewRow["idupb"]= curridupb;
					NewRow["idfin"]= RE["idfin"];
					NewRow["codefin"]= RE["codefin"];
					//DS.prevfindetail.Rows.Add(NewRow);
					Found=DS.prevfindetail.Select(filter);
				}
				//A questo punto è da modificare
				System.Data.DataRow Curr=Found[0];
                Curr.BeginEdit();
				foreach(DataColumn C in DS.prevfindetail.Columns){
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
            if (curridupb == DBNull.Value) return;
			if (DoConsolida) return;


			Cursor.Current= Cursors.WaitCursor;
			Application.DoEvents();
			GetTempTableToDS(DS2.prevfindetail);
			GetTempTableToDS(DS3.prevfindetail);
			Cursor.Current= Cursors.Default;
		}


		void RicalcolaTotali(){
            EnableDisableButtons(false);
         
			txtAssegnareCassa.Text=MetaData.SumColumn(DS2.prevfindetail,"incometopartitioncash").ToString("c");
			txtAssegnareCompetenza.Text=MetaData.SumColumn(DS2.prevfindetail,"incometopartitioncompetency").ToString("c");
			txtAvanzoPresunto.Text=MetaData.SumColumn(DS2.prevfindetail,"supposedcreditsurplus").ToString("c");
			txtFondoCassaPresunto.Text=MetaData.SumColumn(DS2.prevfindetail,"supposedfloatfund").ToString("c");
			txtIncassiPresunti.Text=MetaData.SumColumn(DS2.prevfindetail,"supposedproceeds").ToString("c");
			txtPagamentiPresunti.Text=MetaData.SumColumn(DS2.prevfindetail,"supposedpayments").ToString("c");
			txtPrevisioneCassa.Text=MetaData.SumColumn(DS2.prevfindetail,"cash").ToString("c");
			txtPrevisioneCompetenza.Text=MetaData.SumColumn(DS2.prevfindetail,"competency").ToString("c");
			txtResAttiviPresunti.Text=MetaData.SumColumn(DS3.prevfindetail,"supposedrevenue").ToString("c");
			txtResiduiAttiviRipartiti.Text=MetaData.SumColumn(DS2.prevfindetail,"supposedrevenue").ToString("c");
			txtResPassiviPresunti.Text=MetaData.SumColumn(DS2.prevfindetail,"supposedexpenditure").ToString("c");
			txtTotFondoCassa.Text=MetaData.SumColumn(DS2.prevfindetail,"floatfund").ToString("c");

			txtIncomeCash.Text= MetaData.SumColumn(DS3.prevfindetail,"cash").ToString("c");
			txtIncomeCompetency.Text= MetaData.SumColumn(DS3.prevfindetail,"competency").ToString("c");


            bool Disabled = (curridupb == DBNull.Value) || DoConsolida;
			bool FinAssured=false;
			if (curridupb!=DBNull.Value){
				System.Data.DataRow UPBRow= DS.upb.Select(QHC.CmpEq("idupb",curridupb))[0];
				if (UPBRow["assured"].ToString().ToUpper()=="S") FinAssured=true;
			}

            //
            labResAttPres.Visible = !SolaCassa;
            txtResAttiviPresunti.Visible = (!SolaCassa);
            labResPassPres.Visible = !SolaCassa;
            txtResPassiviPresunti.Visible = !SolaCassa;
            //labResAttPresRip.Visible = !SolaCassa;
            //txtResiduiAttiviRipartiti.Visible = !SolaCassa;
            //labAssCompetenza.Visible = !SolaCassa;
            //txtAssegnareCompetenza.Visible = !SolaCassa;
            labIncomeCompetency.Visible = !SolaCassa;
            txtIncomeCompetency.Visible = !SolaCassa;
            txtPrevisioneCompetenza.Visible = !SolaCassa;
            labCompetenza.Visible = !SolaCassa;
            //labAvaAmmPres.Visible = !SolaCassa;
            //txtAvanzoPresunto.Visible = !SolaCassa;
            //



			labFCassa.Visible=!FinAssured;
			labIncPresunti.Visible=!FinAssured;
			labPagPresunti.Visible=!FinAssured;
			labFCassaPres.Visible=!FinAssured;
            labAvaAmmPres.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtTotFondoCassa.Visible = !FinAssured;
            txtIncassiPresunti.Visible = !FinAssured;
            txtPagamentiPresunti.Visible = !FinAssured;
            txtAvanzoPresunto.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtFondoCassaPresunto.Visible = !FinAssured;

            labAssCassa.Visible = !FinAssured;
            labAssCompetenza.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtAssegnareCassa.Visible = !FinAssured;
            txtAssegnareCompetenza.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;

            labResAttPresRip.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtResiduiAttiviRipartiti.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            if (SolaCassa)
            {
                label15.Visible = false;
                label17.Visible = false;
                label16.Location = new System.Drawing.Point(472, 160);
            }
            EnableDisableButtons(true);
         
		}


		void SvuotaTotali(){
			txtAssegnareCassa.Visible=AbilitaColonneCassa;
			txtAssegnareCompetenza.Visible=AbilitaColonneCompetenza;
			labAssCassa.Visible=AbilitaColonneCassa;
			labAssCompetenza.Visible=AbilitaColonneCompetenza;
			txtPrevisioneCassa.Visible= AbilitaColonneCassa;
			txtPrevisioneCompetenza.Visible=AbilitaColonneCompetenza;
			labCassa.Visible=AbilitaColonneCassa;
			labCompetenza.Visible=AbilitaColonneCompetenza;
			labIncomeCompetency.Visible=AbilitaColonneCompetenza;
			txtIncomeCompetency.Visible=AbilitaColonneCompetenza;
			labIncomeCash.Visible=AbilitaColonneCassa;
			txtIncomeCash.Visible=AbilitaColonneCassa;
			
			txtAssegnareCassa.Text="";
			txtAssegnareCompetenza.Text="";
			txtAvanzoPresunto.Text="";
			txtFondoCassaPresunto.Text="";
			txtIncassiPresunti.Text="";
			txtPagamentiPresunti.Text="";
			txtPrevisioneCassa.Text="";
			txtPrevisioneCompetenza.Text="";
			txtResAttiviPresunti.Text="";
			txtResPassiviPresunti.Text="";
			txtTotFondoCassa.Text="";

			txtIncomeCash.Text= "";
			txtIncomeCompetency.Text= "";
			txtResiduiAttiviRipartiti.Text="";

            bool Disabled = (curridupb == DBNull.Value) || DoConsolida;
			bool FinAssured=false;
            if (curridupb != DBNull.Value) {
				System.Data.DataRow []UPBRow= DS.upb.Select(QHC.CmpEq("idupb",curridupb));
                if (UPBRow.Length > 0) {
                    if (UPBRow[0]["assured"].ToString().ToUpper() == "S") FinAssured = true;
                }
			}

            //
            labResAttPres.Visible = !SolaCassa;
            txtResAttiviPresunti.Visible = (!SolaCassa);
            labResPassPres.Visible = !SolaCassa;
            txtResPassiviPresunti.Visible = !SolaCassa;
            //labResAttPresRip.Visible = !SolaCassa;
            //txtResiduiAttiviRipartiti.Visible = !SolaCassa;
            //labAssCompetenza.Visible = !SolaCassa;
            //txtAssegnareCompetenza.Visible = !SolaCassa;
            labIncomeCompetency.Visible = !SolaCassa;
            txtIncomeCompetency.Visible = !SolaCassa;
            txtPrevisioneCompetenza.Visible = !SolaCassa;
            labCompetenza.Visible = !SolaCassa;
            //labAvaAmmPres.Visible = !SolaCassa;
            //txtAvanzoPresunto.Visible = !SolaCassa;
            //
			labFCassa.Visible=!FinAssured;
			labIncPresunti.Visible=!FinAssured;
			labPagPresunti.Visible=!FinAssured;
			labFCassaPres.Visible=!FinAssured;
            labAvaAmmPres.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtTotFondoCassa.Visible = !FinAssured;
            txtIncassiPresunti.Visible = !FinAssured;
            txtPagamentiPresunti.Visible = !FinAssured;
 
            txtAvanzoPresunto.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtFondoCassaPresunto.Visible = !FinAssured;

            labAssCassa.Visible = !FinAssured;
            labAssCompetenza.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtAssegnareCassa.Visible = !FinAssured;
            txtAssegnareCompetenza.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;

            labResAttPresRip.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            txtResiduiAttiviRipartiti.Visible = (!FinAssured) && (!SolaCassa); //!FinAssured;
            if (SolaCassa) {
                label15.Visible = false;
                label17.Visible = false;
                label16.Location = new System.Drawing.Point(472, 160);
            }
			
		}
		public void MetaData_AfterFill(){
            if (Meta.FirstFillForThisRow) {
                if (Meta.InsertMode) DO_INIT_FIN();
                checkPrevision();
            }
            
			RicalcolaTotali();
		}


		public void MetaData_BeforeFill(){
			btnRicalcola.Enabled=true;
			btnSalvaDatiPrevisione.Enabled=Meta.CanSave;

            

            string prevFilter = QHS.AppAnd(QHS.CmpEq("ayear", esercizio), QHS.CmpEq("official", 'S'));
            if (Meta.EditMode) {
                System.Data.DataRow CurrPrev = DS.prevfin.Rows[0];
                prevFilter = QHS.AppAnd(prevFilter, QHS.CmpNe("nprevfin", CurrPrev["nprevfin"]));
            }
            int numOfficial = Conn.RUN_SELECT_COUNT("prevfin", prevFilter, false);
            if (numOfficial >= 1) {
                //Nell'esercizio corrente esiste un altro bilancio di previsione ufficiale
                btnSalvaDatiPrevisione.Enabled = false;
            }

			if (Meta.FirstFillForThisRow){
				CopyDStoXceed();
			}
		}

		public void MetaData_AfterGetFormData(){
            if (curridupb == DBNull.Value) return;
			if (DoConsolida) return;
			CopyXceedtoDS();
		}
		private void gridControl1_CurrentColumnChanged(object sender, System.EventArgs e) {
			foreach (System.Data.DataRow R in DS2.prevfindetail.Rows){
				R.EndEdit();

			}
		}

        private void checkPrevision() {
            object esercizio = Meta.GetSys("esercizio");
            DataSet dsApp = Meta.Conn.CallSP("exp_not_spread_prevision", new object[] { esercizio });
            if ((dsApp == null) || (dsApp.Tables.Count == 0)) return;
            DataTable tResult = dsApp.Tables[0];
            if (tResult.Rows.Count == 0) return;
            FrmError frm = new FrmError(tResult);
            frm.ShowDialog();

        }
		private void btnRicalcola_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			Meta.GetFormData(true);
			object liv=Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear",esercizio), "MAX(nlevel)");
			System.Data.DataRow Curr=DS.prevfin.Rows[0];
			object DataPrev= Curr["previsiondate"];
			if (DataPrev == DBNull.Value){
				MessageBox.Show("E' necessario specificare la data di previsione");
				return;
			}

			Cursor.Current= Cursors.WaitCursor;
			Application.DoEvents();
			DataSet D = Conn.CallSP("compute_finprevision",
				new object[]{Meta.GetSys("esercizio"),DataPrev,liv},true,600);
			Cursor.Current= Cursors.Default;
			if (D==null) return;
			if (D.Tables.Count==0) return;
			DataTable T = D.Tables[0];
			if (T==null) return;
			GetSPTableToDS(T);

			CopyDStoXceed(); 
			RicalcolaTotali();
		}


        private void DO_INIT_FIN() {
            if (Meta.IsEmpty) return;
            // Disabilitare i bottoni
            EnableDisableButtons(false);
            object liv = Conn.DO_READ_VALUE("finlevel",QHS.CmpEq("ayear",newesercizio), "MAX(nlevel)");
            Cursor.Current = Cursors.WaitCursor;
            Application.DoEvents();
            if (DS.prevfin.Rows.Count == 0) return;
            System.Data.DataRow Curr = DS.prevfin.Rows[0];
            object DataPrev = Curr["previsiondate"];

            DataSet D = Conn.CallSP("compute_startprevision",
                new object[] {esercizio,DataPrev, liv }, true, 600);
            Cursor.Current = Cursors.Default;
            if (D == null) return;
            if (D.Tables.Count == 0) return;
            DataTable T = D.Tables[0];
            if (T == null) return;
            GetSPTableToDS(T);

            CopyDStoXceed();
            //Riabilita i bottoni
            EnableDisableButtons(true);
            RicalcolaTotali();
        }

        private void EnableDisableButtons(bool enable){
            btnRicalcola.Enabled = enable;
            btnSalvaDatiPrevisione.Enabled = enable; 
        }


		private void gridControl1_FirstVisibleColumnChanged(object sender, System.EventArgs e) {
			if (gridControl1.FirstVisibleColumn!=null){
				if ((gridControl1.FirstVisibleColumn != gridControl1.Columns["codefin"])
					//&&	(gridControl1.FirstVisibleColumn != gridControl1.Columns["id2"])
					){
					int F = gridControl1.FirstVisibleColumn.VisibleIndex;
					string order1="V("+gridControl1.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl1.Columns){
						order1+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					bool FORWARD = (gridControl1.Columns["codefin"].VisibleIndex<F);
					if (FORWARD){
						gridControl1.Columns["title"].VisibleIndex=F+1;
					}
					else {
						gridControl1.Columns["title"].VisibleIndex=F;
					}
					
					string order2="V("+gridControl1.FirstVisibleColumn.VisibleIndex+")";
					//string order2="";
					foreach (Xceed.Grid.Column CC in gridControl1.Columns){
						order2+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					//					gridControl1.Columns["denominazione"].VisibleIndex=gridControl1.FirstVisibleColumn.VisibleIndex;
					if (FORWARD){
						gridControl1.Columns["codefin"].VisibleIndex=F;
					}
					else {
						gridControl1.Columns["codefin"].VisibleIndex=F;
					}

					string order3="V("+gridControl1.FirstVisibleColumn.VisibleIndex+")";
					foreach (Xceed.Grid.Column CC in gridControl1.Columns){
						order3+=" "+CC.Title+" "+CC.VisibleIndex;
					}
					//MessageBox.Show(order1+"\n"+order2+"\n"+order3);
				}
																					
			}

		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e) {
			
			if (tabControl1.SelectedTab==tabTotali){
				if (Meta.IsEmpty){
					SvuotaTotali();
				}
				else {
					RicalcolaTotali();
				}
			}
		}

        private void refreshStartPrevision() {
            if (DS.prevfin.Rows.Count == 0) return;
            System.Data.DataRow Curr = DS.prevfin.Rows[0];
            if (Curr["previsiondate"] == DBNull.Value) {
                MessageBox.Show(this, "Non è stata specificata la data di previsione", "Errore");
                return;
            }
            int newesercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio")) + 1;
            object levelusable = Meta.Conn.DO_READ_VALUE("finlevel", QHS.CmpEq("ayear", newesercizio), "MAX(nlevel)");
            if ((levelusable == null) || (levelusable == DBNull.Value)) {
                MessageBox.Show(this, "Non esistono livelli di bilancio!", "Errore");
                return;
            }

            DataSet dsApp = Meta.Conn.CallSP("compute_startprevision",
                new object[] { Meta.GetSys("esercizio"), Curr["previsiondate"], levelusable }, true, 600);
            if ((dsApp == null) || (dsApp.Tables.Count == 0)) return;
            System.Data.DataTable t = dsApp.Tables[0];
            if (t == null) return;

            foreach (System.Data.DataRow rPrevision in t.Rows) {
                string filter = QHC.MCmp(rPrevision, new string [] {"idupb", "idfin"});
                // Aggiungi la riga
                MetaData MetaPrevFinDetail = MetaData.GetMetaData(this, "prevfindetail");
                MetaPrevFinDetail.SetDefaults(DS.prevfindetail);
                if (DS.prevfindetail.Select(filter).Length == 0) {
                    System.Data.DataRow rPFD = MetaPrevFinDetail.Get_New_Row(Curr, DS.prevfindetail);
                    rPFD["idfin"] = rPrevision["idfin"];
                    rPFD["idupb"] = rPrevision["idupb"];
                    rPFD["previousprevision"] = rPrevision["previousprevision"];
                    if ((AbilitaColonneCassa) && (!SolaCassa)) {
                        rPFD["previoussecondaryprev"] = rPrevision["previoussecondaryprev"];
                    }
                }
                else {
                    System.Data.DataRow rPFD = DS.prevfindetail.Select(filter)[0];
                    decimal mainPrev_DS = CfgFn.GetNoNullDecimal(rPFD["previousprevision"]);
                    decimal mainPrev_SP = CfgFn.GetNoNullDecimal(rPrevision["previousprevision"]);
                    if (mainPrev_DS != mainPrev_SP) {
                        rPFD["previousprevision"] = mainPrev_SP;
                    }
                    if ((AbilitaColonneCassa) && (!SolaCassa)) {
                        decimal secPrev_DS = CfgFn.GetNoNullDecimal(rPFD["previoussecondaryprev"]);
                        decimal secPrev_SP = CfgFn.GetNoNullDecimal(rPrevision["previoussecondaryprev"]);
                        if (secPrev_DS != secPrev_SP) {
                            rPFD["previoussecondaryprev"] = secPrev_SP;
                        }
                    }
                }
            }
        }
		//Tabella finyear
		//currentarrears (supposeexpenditures o supposedrevenue) e previousarrears (previousarrears)
		//limit
		//previousprevision  e previoussecondaryprev
		//prevision secondaryprev
		//prevision2 prevision3 prevision4 prevision5


		//Deve anche calcolare, per ogni riga di finyear: previousprevision e previoussecondaryprev
		private void btnSalvaDatiPrevisione_Click(object sender, System.EventArgs e) {
      
			if (!Meta.CanSave) return;
			if (DS.prevfin.Rows.Count==0) return;
            Meta.GetFormData(true);
            refreshStartPrevision();
			Meta.SaveFormData();
			PostData.RemoveFalseUpdates(DS);
			if (DS.HasChanges()){
				MessageBox.Show("E' necessario salvare i dati prima di utilizzare questa funzione. Operazione annullata.");
				return;
			}

            

			bool CopiaResiduiPassiviPresunti=false;
            if (!SolaCassa)
            {
                if (AbilitaColonneCassa && AbilitaColonneCompetenza)
                {
                    System.Data.DataRow persbil = DS.config.Rows[0];
                    string field = persbil["boxpartitiontitle"].ToString();
                    if (field == "") field = "Residui dell'anno precedente";
                    if (persbil["currpartitiontitle"].ToString() != "")
                    {
                        field += "/" + persbil["currpartitiontitle"].ToString();
                    }
                    else
                    {
                        field += "/Es. corrente";
                    };
                    if (MessageBox.Show("Copio il campo 'Residui passivi presunti' in " +
                        QueryCreator.quotedstrvalue(field, false) + "?", "Informazioni aggiuntive", MessageBoxButtons.OKCancel)
                        == DialogResult.OK)
                    {
                        CopiaResiduiPassiviPresunti = true;
                    }
                }
            }

			int eserciziosucc=esercizio+1;
            string filtersucc = QHS.CmpEq("ayear", eserciziosucc);
//			DataTable NewBilancio=Conn.RUN_SELECT("finyear","*",null,filter,null,null,false);
			DataTable NewBilancio=Conn.RUN_SELECT("finyear","*",null,filtersucc,null,null,false);
            DataColumn NewCol = new DataColumn("!parid",typeof(int));
            NewCol.AllowDBNull=true;
            NewBilancio.Columns.Add(NewCol);
            NewCol = new DataColumn("!nlevel",typeof(byte));
            NewCol.AllowDBNull=true;
            NewBilancio.Columns.Add(NewCol);
            foreach (System.Data.DataRow R in NewBilancio.Select()) {
                object idfin = R["idfin"];
                System.Data.DataRow MyF = MyBilancio.Select(QHC.CmpEq("idfin", idfin))[0];
                R["!parid"] = MyF["paridfin"];
                R["!nlevel"] = MyF["nlevel"];
            }
            //string prefix= esercizio.ToString().Substring(2,2)+"%";
            //string filterconvert="(oldidfin LIKE "+
            //    QueryCreator.quotedstrvalue(prefix,false)+")";
            //DataTable ConvertBilancio=Conn.RUN_SELECT("finlookup","*",null,filterconvert,null,null,true);

			MetaData MetaFinYear= MetaData.GetMetaData(this,"finyear");
			MetaFinYear.SetDefaults(NewBilancio);
			MetaData.SetDefault(NewBilancio,"ayear",eserciziosucc);

			//Azzera tutti i dati sensibili
			foreach(System.Data.DataRow R in NewBilancio.Rows){
				R["previousprevision"]=DBNull.Value;
				R["previoussecondaryprev"]=DBNull.Value;
				R["prevision"]=DBNull.Value;
				R["prevision2"]=DBNull.Value;
				R["prevision3"]=DBNull.Value;
				R["prevision4"]=DBNull.Value;
				R["prevision5"]=DBNull.Value;
				R["secondaryprev"]=DBNull.Value;
				//if (CopiaResiduiPassiviPresunti){
					R["currentarrears"]=DBNull.Value;
					R["previousarrears"]=DBNull.Value;
				//}
			}

            //RicalcolaCampiCalcolati();
			//Per ogni riga in DS (si riferiscono solo a foglie) sommo i dati corrispondenti in NewBilancio
			// se c'è la riga in finyear, altrimenti la creo
			foreach(System.Data.DataRow Source in DS.prevfindetail.Rows){
				bool somethingtodo=false;
				if ((campoprevcompetenza!=null)&&  Source["competency"]!=DBNull.Value)somethingtodo=true;
				if ((campoprevcassa!=null)&&  Source["cash"]!=DBNull.Value)somethingtodo=true;

                if (CfgFn.GetNoNullDecimal(Source["previousprevision"]) != 0) somethingtodo = true;
				if(CfgFn.GetNoNullDecimal(Source["previoussecondaryprev"])!= 0) somethingtodo = true;
			    if(CfgFn.GetNoNullDecimal(Source["prevision2"])!= 0) somethingtodo = true;
                if (CfgFn.GetNoNullDecimal(Source["prevision3"]) != 0) somethingtodo = true;
                if (CfgFn.GetNoNullDecimal(Source["prevision4"]) != 0) somethingtodo = true;
                if (CfgFn.GetNoNullDecimal(Source["prevision5"]) != 0) somethingtodo = true;
                if (CopiaResiduiPassiviPresunti) {
                    if (CfgFn.GetNoNullDecimal(Source["supposedexpenditure"]) != 0) somethingtodo = true;
                    if (CfgFn.GetNoNullDecimal(Source["supposedrevenue"]) != 0) somethingtodo = true;
                    if (CfgFn.GetNoNullDecimal(Source["previousarrears"]) != 0) somethingtodo = true;
                }
				if (!somethingtodo)continue;

				object idupb= Source["idupb"];
                object oldidbilancio = Source["idfin"];
                object newidbilancio = oldidbilancio;
                //System.Data.DataRow []cvb = ConvertBilancio.Select("oldidfin="+
                //    QueryCreator.quotedstrvalue(oldidbilancio,false));
                //if (cvb.Length==0){
                //    newidbilancio=eserciziosucc.ToString().Substring(2,2)+
                //        oldidbilancio.Substring(2);
                //}
                //else {
                //    newidbilancio=cvb[0]["newidfin"].ToString();
                //}
				System.Data.DataRow []Dests= NewBilancio.Select(QHC.AppAnd(QHC.CmpEq("idfin",newidbilancio),
                                    QHC.CmpEq("idupb",idupb)));

                System.Data.DataRow BB = MyBilancio.Select(QHC.CmpEq("idfin", newidbilancio))[0];
                int flag = CfgFn.GetNoNullInt32(BB["flag"]);
                string finpart = (flag & 1) == 0 ? "E" : "S";

                if (Dests.Length == 0) {
					MetaData.SetDefault(NewBilancio,"idfin",newidbilancio);
					MetaData.SetDefault(NewBilancio,"idupb",idupb);
					System.Data.DataRow NewRow= MetaFinYear.Get_New_Row(null,NewBilancio);
                    System.Data.DataRow MyF = MyBilancio.Select(QHC.CmpEq("idfin", newidbilancio))[0];
                    NewRow["!parid"] = MyF["paridfin"];
                    NewRow["!nlevel"] = MyF["nlevel"];
                    Dests = NewBilancio.Select(QHC.AppAnd(QHC.CmpEq("idfin", newidbilancio),
                                    QHC.CmpEq("idupb", idupb)));
				}
				if (Dests.Length==0){
					MessageBox.Show("Errore nella creazione delle righe del bil. di previsione. Contattare l'assistenza.");
					return;
				}

				if ((AbilitaColonneCompetenza)&& (!SolaCassa)){
					decimal valcompetenza= CfgFn.GetNoNullDecimal(Dests[0][campoprevcompetenza]);
					decimal currval=CfgFn.GetNoNullDecimal(Source["competency"]);
					valcompetenza+=currval;
					Dests[0][campoprevcompetenza]= valcompetenza;
				}
				if (AbilitaColonneCassa){
					decimal valcassa= CfgFn.GetNoNullDecimal(Dests[0][campoprevcassa]);
					decimal currval1=CfgFn.GetNoNullDecimal(Source["cash"]);
					valcassa+=currval1;
					Dests[0][campoprevcassa]= valcassa;
				}
				foreach (string field in new string[]{"prevision2","prevision3","prevision4","prevision5",
						"previousprevision","previoussecondaryprev"}){
					decimal valfield=CfgFn.GetNoNullDecimal(Dests[0][field]);
					decimal currvalfield= CfgFn.GetNoNullDecimal(Source[field]);
					valfield+=currvalfield;
					Dests[0][field]= valfield;
				}

				string arrfield="";
				if (finpart=="S")
					arrfield="supposedexpenditure";
				else
					arrfield="supposedrevenue";

				if (CopiaResiduiPassiviPresunti){
					decimal valresidui= CfgFn.GetNoNullDecimal(Dests[0]["currentarrears"]);
					decimal currval2=CfgFn.GetNoNullDecimal(Source[arrfield]);
					valresidui+=currval2;
					Dests[0]["currentarrears"]= valresidui;

					decimal valresiduiprec= CfgFn.GetNoNullDecimal(Dests[0]["previousarrears"]);
                    decimal currval2prec = CfgFn.GetNoNullDecimal(Source["previousarrears"]);
					valresiduiprec+=currval2prec;
					Dests[0]["previousarrears"]= valresiduiprec;

				}

			}
			//Calcola, in NewBilancio, le previsioni di tutti i livelli operativi articolati come somma delle
			// previsioni dei dettagli
			object OLivOp= Conn.DO_READ_VALUE("finlevel", QHS.AppAnd(QHS.CmpEq("ayear",eserciziosucc),
                        		QHS.BitSet("flag", 1)),"min(nlevel)");
			int minlivop=1;
			if (OLivOp!=DBNull.Value)minlivop= Convert.ToInt32(OLivOp);
            int maxlivop = CfgFn.GetNoNullInt32(
                Conn.DO_READ_VALUE("finlevel", QHS.AppAnd(QHS.CmpEq("ayear", eserciziosucc),
                        		QHS.BitSet("flag", 1)), "max(nlevel)")
                );


			//Calcola il livello liv come somma dei figli ove presenti
			for (int liv=maxlivop-1; liv>=minlivop; liv--){
				//Crea tutte le righe che servono eventualmente non presenti in finyear

				//Per ogni riga di livello liv+1 vede se esiste quella padre. Se non esiste la crea.
				int childlevel = liv+1;
                System.Data.DataRow[] Childs = NewBilancio.Select(QHC.CmpEq("!nlevel", childlevel));//"((len(idfin)-3)/4="+childlevel+")");
				foreach (System.Data.DataRow  Child in Childs){
                    object parid = Child["!parid"];
                    string filterpar = QHC.AppAnd(QHC.MCmp(Child, "idupb"), QHC.CmpEq("idfin", parid));
					System.Data.DataRow []Parents= NewBilancio.Select(filterpar);
					if (Parents.Length==0){
						MetaData.SetDefault(NewBilancio,"ayear",eserciziosucc);
						MetaData.SetDefault(NewBilancio,"idfin",parid);
						MetaData.SetDefault(NewBilancio,"idupb",Child["idupb"]);
						System.Data.DataRow NewParent=NewBilancio.NewRow();
                        System.Data.DataRow MyF = MyBilancio.Select(QHC.CmpEq("idfin", parid))[0];
                        NewParent["!parid"] = MyF["paridfin"];
                        NewParent["!nlevel"] = MyF["nlevel"];
						NewBilancio.Rows.Add(NewParent);
					}
				}
                
                System.Data.DataRow[] LivR = NewBilancio.Select(QHC.CmpEq("!nlevel", liv));
                    //"((len(idfin)-3)/4="+liv+")");      //"nlevel="+liv.ToString());
                
                string query = "select newidfin, oldidfin FROM finlookup JOIN fin " +
                        " ON finlookup.newidfin = fin.idfin " + 
                         " where " +  QHS.CmpEq("ayear", eserciziosucc) ;
                DataTable Tfinlookup = Conn.SQLRunner(query);

				foreach(System.Data.DataRow B in LivR){
					object currid=B["idfin"];
                    string filterparent = QHC.AppAnd(QHC.MCmp(B, "idupb"), QHC.CmpEq("!parid", currid));
                    //Salta quelle non articolate
                    if (NewBilancio.Select(filterparent).Length == 0) continue;
                    if (AbilitaColonneCompetenza && (!SolaCassa)) {
						object rescomp= CfgFn.GetNoNullDecimal(NewBilancio.Compute("SUM("+campoprevcompetenza+")",
							filterparent));
						B[campoprevcompetenza]=rescomp;
					}
					if (AbilitaColonneCassa){
						object rescassa=  CfgFn.GetNoNullDecimal(NewBilancio.Compute("SUM("+campoprevcassa+")",
							filterparent));
						B[campoprevcassa]=rescassa;
					}
					if (CopiaResiduiPassiviPresunti){
						object resresidui=  CfgFn.GetNoNullDecimal(NewBilancio.Compute("SUM(currentarrears)",
							filterparent));
						B["currentarrears"]=resresidui;
                        object resresiduiprev = CfgFn.GetNoNullDecimal(NewBilancio.Compute("SUM(previousarrears)",
                            filterparent));
                        B["previousarrears"] = resresiduiprev;						
					}
                  
                    //if (Tfinlookup.Select(QHC.CmpEq("newidfin", currid)).Length==0){
                    //    //totalizza "previousprevision","previoussecondaryprev"
                        foreach (string field in new string[]{"previousprevision","previoussecondaryprev"})
                        {
                            object val = CfgFn.GetNoNullDecimal(NewBilancio.Compute("SUM(" + field + ")", filterparent));
                            B[field] = val;
                        }

                    //}

                    foreach (string field in new string[]{"prevision2","prevision3","prevision4","prevision5"}){
                        object val = CfgFn.GetNoNullDecimal(NewBilancio.Compute("SUM(" + field + ")",
                            filterparent));
                        B[field] = val;
                    }



				    }
			}

			//Elimina le righe con tutti i campi a zero
			foreach(System.Data.DataRow R in NewBilancio.Select()){
				bool todel=true;
				foreach (string field in new string[]{   "prevision","secondaryprev","currentarrears","previousarrears",
														 "previousprevision","previoussecondaryprev",
														 "prevision2","prevision3","prevision4","prevision5"}) {
					if (CfgFn.GetNoNullDecimal(R[field])==0)continue;
					todel=false;
					break;
				}
				if (todel)R.Delete();
			}
            NewBilancio.Columns.Remove("!parid");
            NewBilancio.Columns.Remove("!nlevel");

			MetaData metabil= MetaData.GetMetaData(this,"finyear");
			PostData CP= metabil.Get_PostData();
			DataSet DD= new DataSet("ii");
			DD.Tables.Add(SortByUPB(NewBilancio));
			ClearDataSet.RemoveConstraints(DD);
			CP.InitClass(DD,Conn);
			bool res = CP.DO_POST();						
			if (res){
				System.Data.DataRow Curr= DS.prevfin.Rows[0];
				Curr["official"]="S";
				Meta.SaveFormData();
				if (DS.HasChanges()) res=false;

			}
            if (!SolaCassa) {
                if (res)
                {
                    if (MessageBox.Show("Creo la ripartizione dell'avanzo di amministrazione presunto (nella dotazione crediti) per l'anno successivo?", "Conferma",
                        MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        res = CreaDotazioneCrediti();
                    }
                }
            }
			if (res) {
				if (MessageBox.Show("Creo la ripartizione dell'avanzo di cassa presunto (nella dotazione cassa) per l'anno successivo?","Conferma",
					MessageBoxButtons.OKCancel)==DialogResult.OK){
					res= CreaDotazioneCassa();
				}
			}
            DS.finvardetail.Clear();
            DS.finvar.Clear();

		}
        void CopyDataRow(DataTable DestTable, System.Data.DataRow ToCopy) {
            System.Data.DataRow Dest = DestTable.NewRow();
            DataRowVersion ToConsider = DataRowVersion.Current;
            if (ToCopy.RowState == DataRowState.Deleted) ToConsider = DataRowVersion.Original;
            if (ToCopy.RowState == DataRowState.Modified) ToConsider = DataRowVersion.Original;
            if (ToCopy.RowState != DataRowState.Added) {
                foreach (DataColumn C in DestTable.Columns) {
                    Dest[C.ColumnName] = ToCopy[C.ColumnName, ToConsider];
                }
                DestTable.Rows.Add(Dest);
                Dest.AcceptChanges();
            }
            if (ToCopy.RowState == DataRowState.Deleted) {
                Dest.Delete();
                return;
            }
            foreach (DataColumn C in DestTable.Columns) {
                Dest[C.ColumnName] = ToCopy[C.ColumnName];
            }
            if (ToCopy.RowState == DataRowState.Added) {
                DestTable.Rows.Add(Dest);
            }

        }

        public DataTable SortByUPB(DataTable Source) {
            //Mette gli inserimenti delle righe di upb di livello maggiore in fondo            
            DataTable Upb = Conn.RUN_SELECT("upb", "*", null, null, null, false);
            DataTable Dest = Source.Clone();
            Dest.Clear();
            //Copia tutte le righe cancellate
            foreach (System.Data.DataRow RI in Source.Rows) {
                if (RI.RowState!=DataRowState.Deleted) continue;
                CopyDataRow(Dest, RI);
            }
            bool somethingdone = true;
            while (somethingdone) {
                somethingdone = false;
                foreach (System.Data.DataRow RI in Source.Select()) {
                    object idupb = RI["idupb"];

                    //Se la riga è stata già copiata la salta
                    string filterme = QHC.CmpKey(RI);
                    if (Dest.Select(filterme).Length > 0) continue;

                    System.Data.DataRow U = Upb.Select(QHC.CmpEq("idupb", idupb))[0];
                    //Vede se U ha dei padri in Source - se ce li ha devono stare anche in Dest
                    object paridupb = U["paridupb"];
                    if (paridupb == DBNull.Value) {
                        CopyDataRow(Dest, RI);
                        somethingdone = true;
                        continue;
                    }

                    string filtermyparent = QHC.AppAnd(
                        QHC.CmpEq("idfin", RI["idfin"]), QHC.CmpEq("idupb", paridupb));
                    if (Source.Select(filtermyparent).Length == 0) {
                        //Non ha padre in Source, allora la copia subito
                        CopyDataRow(Dest, RI);
                        somethingdone = true;
                        continue;
                    }
                    if (Dest.Select(filtermyparent).Length > 0) {
                        //Padre è stato già copiato, si può procedere
                        CopyDataRow(Dest, RI);
                        somethingdone = true;
                        continue;
                    }
                    //Salta questa riga
                    continue;
                }
            }
            return Dest;
        }


		bool CreaDotazioneCrediti(){
			int eserciziosucc=esercizio+1;
			if (Conn.RUN_SELECT_COUNT("finvar",QHS.AppAnd(QHS.CmpEq("yvar",eserciziosucc),
                            QHS.CmpEq("variationkind",2),QHS.CmpEq("flagcredit","S")),false)>0){
				if (MessageBox.Show("Esiste già la ripartizione dell'avanzo di amministrazione presunto. Procedo comunque?",
					"Conferma",MessageBoxButtons.OKCancel)!=DialogResult.OK) return true;
			}
            string filter = QHS.AppAnd(QHS.CmpEq("ayear", eserciziosucc), QHS.BitSet("flag", 0));
			DataTable NewBilancio=Conn.RUN_SELECT("fin","*","codefin",filter,null,null,false);
            //string prefix= esercizio.ToString().Substring(2,2)+"%";
            //string filterconvert="(oldidfin LIKE "+
            //    QueryCreator.quotedstrvalue(prefix,false)+")";
            //DataTable ConvertBilancio=Conn.RUN_SELECT("finlookup","*",null,filterconvert,null,null,true);


			DS.finvardetail.Clear();
			DS.finvar.Clear();
            string Configfilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            object default_idfinvarstatus = Conn.DO_READ_VALUE("config", Configfilter, "default_idfinvarstatus");

			//Creo la variazione Crediti principale e poi aggiungo i dettagli
			MetaData MetaFinVar = Meta.Dispatcher.Get("finvar");
			MetaData MetaFinVarDetail = Meta.Dispatcher.Get("finvardetail");
			MetaFinVar.SetDefaults(DS.Tables["finvar"]);
            MetaData.SetDefault(DS.Tables["finvar"], "flagprevision", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "flagsecondaryprev", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "flagproceeds", "N");
			MetaData.SetDefault(DS.Tables["finvar"], "flagcredit","S");
            MetaData.SetDefault(DS.Tables["finvar"], "official", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "idfinvarstatus", default_idfinvarstatus);
			MetaFinVarDetail.SetDefaults(DS.Tables["finvardetail"]);
			System.Data.DataRow NewFinVarRow = MetaFinVar.Get_New_Row(null, DS.Tables["finvar"]);
			NewFinVarRow["yvar"]=eserciziosucc;
			NewFinVarRow["description"]="Avanzo amministrazione presunto";
			NewFinVarRow["variationkind"]= 2;
			NewFinVarRow["adate"]=DS.prevfin.Rows[0]["previsiondate"];



			//Per ogni riga in DS (si riferiscono solo a foglie) sommo i dati corrispondenti in NewBilancio
			foreach(System.Data.DataRow Source in DS.prevfindetail.Rows){
				bool somethingtodo=false;
                object idupb = Source["idupb"];
                System.Data.DataRow Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
                if (Upb["assured"].ToString().ToUpper() == "S") continue;
				if (CfgFn.GetNoNullDecimal(Source["supposedcreditsurplus"])!=0)somethingtodo=true;
				if (!somethingtodo)continue;

				object oldidbilancio= Source["idfin"];
				object newidbilancio=oldidbilancio;
                //System.Data.DataRow []cvb = ConvertBilancio.Select("oldidfin="+
                //    QueryCreator.quotedstrvalue(oldidbilancio,false));
                //if (cvb.Length==0){
                //    newidbilancio=eserciziosucc.ToString().Substring(2,2)+
                //        oldidbilancio.Substring(2);
                //}
                //else {
                //    newidbilancio=cvb[0]["newidfin"].ToString();
                //}
                System.Data.DataRow[] CheckBil = MyBilancio.Select(QHC.CmpEq("paridfin", newidbilancio));
                if (CheckBil.Length > 0) {
                    continue;
                }

				System.Data.DataRow []DestsBil= NewBilancio.Select(QHC.CmpEq("idfin",newidbilancio));
				if (DestsBil.Length==0){
					MessageBox.Show("Errore: l'idbilancio "+newidbilancio+
						" non è stato trovato nell'esercizio successivo.");
					return false;
				}

				System.Data.DataRow []Dests = DS.finvardetail.Select(QHC.AppAnd(QHC.CmpEq("idfin",newidbilancio),
                        QHC.CmpEq("idupb",Source["idupb"])));
				System.Data.DataRow FinVarDet;
				if (Dests.Length>0){
					FinVarDet=Dests[0];
				}
				else {
                    System.Data.DataRow FinVarDetRow = MetaFinVarDetail.Get_New_Row(NewFinVarRow, DS.finvardetail);
                    //FinVarDetRow["yvar"]=NewFinVarRow["yvar"];
                    //FinVarDetRow["nvar"]=NewFinVarRow["nvar"];
					FinVarDetRow["idfin"]=newidbilancio;
					FinVarDetRow["idupb"]=Source["idupb"];
					FinVarDetRow["description"]=NewFinVarRow["description"];
					FinVarDetRow["amount"]=0;
                    //DS.Tables["finvardetail"].Rows.Add(FinVarDetRow);
					FinVarDet = FinVarDetRow;

				}
				FinVarDet["amount"]=CfgFn.GetNoNullDecimal(FinVarDet["amount"])+
					CfgFn.GetNoNullDecimal( Source["supposedcreditsurplus"]);
			}
            if (DS.finvardetail.Rows.Count == 0) return true;
			PostData CP= MetaFinVar.Get_PostData();
			CP.InitClass(DS,Conn);
			bool res = CP.DO_POST();						
			return res;
		}

		bool CreaDotazioneCassa(){
			int eserciziosucc=esercizio+1;

			if (Conn.RUN_SELECT_COUNT("finvar",QHS.AppAnd(QHC.CmpEq("yvar",eserciziosucc),
                    QHS.CmpEq("variationkind",2),QHS.CmpEq("flagproceeds","S")),false)>0){
				if (MessageBox.Show("Esiste già la ripartizione dell'avanzo di cassa presunto. Procedo comunque?",
					"Conferma",MessageBoxButtons.OKCancel)!=DialogResult.OK) return true;
			}

            string filter = QHS.AppAnd(QHS.CmpEq("ayear", eserciziosucc), QHS.BitSet("flag", 0));
            DataTable NewBilancio = Conn.RUN_SELECT("fin", "*", "codefin", filter, null, null, false);

            //string prefix= esercizio.ToString().Substring(2,2)+"%";
            //string filterconvert="(oldidfin LIKE "+
            //    QueryCreator.quotedstrvalue(prefix,false)+")";
            //DataTable ConvertBilancio=Conn.RUN_SELECT("finlookup","*",null,filterconvert,null,null,true);
            string configFilter = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            object default_idfinvarstatus = Conn.DO_READ_VALUE("config", configFilter, "default_idfinvarstatus");

			DS.finvardetail.Clear();
			DS.finvar.Clear();

			MetaData MetaFinVar = Meta.Dispatcher.Get("finvar");
			MetaData MetaFinVarDetail = Meta.Dispatcher.Get("finvardetail");
			MetaFinVar.SetDefaults(DS.Tables["finvar"]);
            MetaData.SetDefault(DS.Tables["finvar"], "flagprevision", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "flagsecondaryprev", "N");
			MetaData.SetDefault(DS.Tables["finvar"],"flagproceeds","S");
            MetaData.SetDefault(DS.Tables["finvar"], "flagcredit", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "official", "N");
            MetaData.SetDefault(DS.Tables["finvar"], "idfinvarstatus", default_idfinvarstatus);
			MetaFinVarDetail.SetDefaults(DS.Tables["finvardetail"]);
			System.Data.DataRow NewFinVarRow = MetaFinVar.Get_New_Row(null, DS.Tables["finvar"]);
			NewFinVarRow["yvar"]=eserciziosucc;
			NewFinVarRow["description"]="Fondo cassa presunto";
			NewFinVarRow["variationkind"]=2;
			NewFinVarRow["adate"]=DS.prevfin.Rows[0]["previsiondate"];

			//Per ogni riga in DS (si riferiscono solo a foglie) sommo i dati corrispondenti in NewBilancio
			foreach(System.Data.DataRow Source in DS.prevfindetail.Rows){
                object idupb = Source["idupb"];
                System.Data.DataRow  Upb = DS.upb.Select(QHC.CmpEq("idupb", idupb))[0];
                if (Upb["assured"].ToString().ToUpper() == "S") continue;

                bool somethingtodo = false;
				if (CfgFn.GetNoNullDecimal(Source["supposedfloatfund"])!=0)somethingtodo=true;
				if (!somethingtodo)continue;

				object oldidbilancio= Source["idfin"];
                object newidbilancio = oldidbilancio;
                //System.Data.DataRow []cvb = ConvertBilancio.Select("oldidfin="+
                //    QueryCreator.quotedstrvalue(oldidbilancio,false));
                //if (cvb.Length==0){
                //    newidbilancio=eserciziosucc.ToString().Substring(2,2)+
                //        oldidbilancio.Substring(2);
                //}
                //else {
                //    newidbilancio=cvb[0]["newidfin"].ToString();
                //}
                System.Data.DataRow[] CheckBil = MyBilancio.Select(QHC.CmpEq("paridfin", newidbilancio));
                if (CheckBil.Length > 0) {
                    continue;
                }

				System.Data.DataRow []DestsBil= NewBilancio.Select(QHC.CmpEq("idfin",newidbilancio));
				if (DestsBil.Length==0){
					MessageBox.Show("Errore: l'idbilancio "+newidbilancio+
						" non è stato trovato nell'esercizio successivo.");
					return false;
				}

				System.Data.DataRow []Dests = DS.finvardetail.Select(
                    QHC.AppAnd(QHC.CmpEq("idfin",newidbilancio),QHC.CmpEq("idupb",Source["idupb"])));

				System.Data.DataRow FinVarDetail;
				if (Dests.Length>0){
					FinVarDetail=Dests[0];
				}
				else {
                    System.Data.DataRow FinVarDetailRow = MetaFinVarDetail.Get_New_Row(NewFinVarRow, DS.finvardetail);
                    //FinVarDetailRow["yvar"]=NewFinVarRow["yvar"];
                    //FinVarDetailRow["nvar"]=NewFinVarRow["nvar"];
					FinVarDetailRow["idupb"]=Source["idupb"];
					FinVarDetailRow["idfin"]=newidbilancio;
					FinVarDetailRow["description"]=NewFinVarRow["description"];
					FinVarDetailRow["amount"]=0;
					//DS.Tables["finvardetail"].Rows.Add(FinVarDetailRow);
					FinVarDetail = FinVarDetailRow;

				}
				FinVarDetail["amount"]=CfgFn.GetNoNullDecimal(FinVarDetail["amount"])+
					CfgFn.GetNoNullDecimal( Source["supposedfloatfund"]);
			}
            if (DS.finvardetail.Rows.Count == 0) return true;

			PostData CP= MetaFinVar.Get_PostData();
			CP.InitClass(DS,Conn);
			bool res = CP.DO_POST();						
			return res;
		}
	


		int ConvertPositionToIndex(int Position, bool AbilitaGruppi){
			int count=0;
			foreach (DataColumn C in DS2.prevfindetail.Columns){
				if (gridControl1.Columns[C.ColumnName].Visible){
					if (gridControl1.Columns[C.ColumnName].VisibleIndex<=Position)
						count++;
				}
			}
			return count;
		}

		private void BtnExcel_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty)return;
			DataTable DT;
            GridControl GRID;
            if (tabControl1.SelectedTab == tabEntrata) {
                DT = DS3.prevfindetail;
                GRID = gridControl2;
            }
            else {
                DT = DS2.prevfindetail;
                GRID = gridControl1;
            }


			//			if (AbilitaGruppi){ 
			//				//Rende visibile le colonne in group by
			//				foreach (DataColumn C in DT.Columns){
			//					if (gridX.Columns[C.ColumnName].Visible) continue;
			//					if (!IsGrouped(C.ColumnName))continue;
			//					gridX.Columns[C.ColumnName].Visible=true;
			//				}
			//			}

			foreach (DataColumn C in DT.Columns){
				int pos;
                if (GRID.Columns[C.ColumnName].Visible)
                    pos = ConvertPositionToIndex(GRID.Columns[C.ColumnName].VisibleIndex, false);
				else
					pos=-1;
				C.ExtendedProperties["ListColPos"]= pos;
				if (pos==-1){
					C.ExtendedProperties["ExcelTitle"]= null;
				}
				else {
                    C.ExtendedProperties["ExcelTitle"] = GRID.Columns[C.ColumnName].Title;
				}
			}

			string ExcelSorting= "";
           
            ExcelSorting = "codefin ASC";
			DT.ExtendedProperties["ExcelSort"]=ExcelSorting;
			
			exportclass.DataTableToExcel(DT,true);

		}

		private void cellcolumnManagerRow1ayear_Click(object sender, System.EventArgs e) {
		
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
			foreach (System.Data.DataRow R in DS3.prevfindetail.Rows){
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
						curridupb=DBNull.Value;
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
            RicalcolaTotali();
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
            RicalcolaTotali();
		}

		private void txtAssegnareCompetenza_TextChanged(object sender, System.EventArgs e) {
		
		}

		private void labAssCompetenza_Click(object sender, System.EventArgs e) {
		
		}

	}


}
