
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace payroll_trasf_cedolino {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsCedolino"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsCedolino: DataSet {

	#region Table members declaration
	///<summary>
	///Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	///<summary>
	///Ritenuta Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltax 		=> Tables["payrolltax"];

	///<summary>
	///Scaglione di un cedolino parasubordinato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxbracket 		=> Tables["payrolltaxbracket"];

	///<summary>
	///Dettaglio Deduzioni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolldeduction 		=> Tables["payrolldeduction"];

	///<summary>
	///Dettaglio Detrazioni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollabatement 		=> Tables["payrollabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cedolinonontrasferibile 		=> Tables["cedolinonontrasferibile"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cedolinoannosuccessivo 		=> Tables["cedolinoannosuccessivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cedolinoerogato 		=> Tables["cedolinoerogato"];

	///<summary>
	///Contratto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontract 		=> Tables["parasubcontract"];

	///<summary>
	///informazioni annuali sul contratto parasubordinato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractyear 		=> Tables["parasubcontractyear"];

	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	///<summary>
	///Storni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxcorrige 		=> Tables["payrolltaxcorrige"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_cedolinoerogato 		=> Tables["upb_cedolinoerogato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_payroll 		=> Tables["upb_payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_cedolinonontrasferibile 		=> Tables["upb_cedolinonontrasferibile"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_cedolinoannosuccessivo 		=> Tables["upb_cedolinoannosuccessivo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsCedolino(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsCedolino (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsCedolino";
	Prefix = "";
	Namespace = "http://tempuri.org/dsCedolino.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	tpayroll.Columns.Add( new DataColumn("!eserccontratto", typeof(int)));
	tpayroll.Columns.Add( new DataColumn("!numcontratto", typeof(int)));
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("!service", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("!flagneedbalance", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("!primocedolinononerogato", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("!denominazione", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tpayroll.Columns.Add( new DataColumn("!causa", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// PAYROLLTAX /////////////////////////////////
	var tpayrolltax= new DataTable("payrolltax");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	tpayrolltax.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("deduction", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrolltax.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtaxgross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualtaxabletotal", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualpayedemploytax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualcreditapplied", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	Tables.Add(tpayrolltax);
	tpayrolltax.PrimaryKey =  new DataColumn[]{tpayrolltax.Columns["idpayroll"], tpayrolltax.Columns["idpayrolltax"]};


	//////////////////// PAYROLLTAXBRACKET /////////////////////////////////
	var tpayrolltaxbracket= new DataTable("payrolltaxbracket");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(short));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	tpayrolltaxbracket.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tpayrolltaxbracket);
	tpayrolltaxbracket.PrimaryKey =  new DataColumn[]{tpayrolltaxbracket.Columns["idpayroll"], tpayrolltaxbracket.Columns["idpayrolltax"], tpayrolltaxbracket.Columns["nbracket"]};


	//////////////////// PAYROLLDEDUCTION /////////////////////////////////
	var tpayrolldeduction= new DataTable("payrolldeduction");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	tpayrolldeduction.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	tpayrolldeduction.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrolldeduction.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrolldeduction);
	tpayrolldeduction.PrimaryKey =  new DataColumn[]{tpayrolldeduction.Columns["idpayroll"], tpayrolldeduction.Columns["iddeduction"]};


	//////////////////// PAYROLLABATEMENT /////////////////////////////////
	var tpayrollabatement= new DataTable("payrollabatement");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollabatement.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tpayrollabatement.Columns.Add(C);
	tpayrollabatement.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrollabatement.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrollabatement.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrollabatement);
	tpayrollabatement.PrimaryKey =  new DataColumn[]{tpayrollabatement.Columns["idpayroll"], tpayrollabatement.Columns["idabatement"]};


	//////////////////// CEDOLINONONTRASFERIBILE /////////////////////////////////
	var tcedolinonontrasferibile= new DataTable("cedolinonontrasferibile");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	tcedolinonontrasferibile.Columns.Add( new DataColumn("!causa", typeof(string)));
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	tcedolinonontrasferibile.Columns.Add( new DataColumn("!eserccontratto", typeof(int)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("!numcontratto", typeof(int)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	tcedolinonontrasferibile.Columns.Add( new DataColumn("lu", typeof(string)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("cu", typeof(string)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcedolinonontrasferibile.Columns.Add(C);
	tcedolinonontrasferibile.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("!denominazione", typeof(string)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcedolinonontrasferibile.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	Tables.Add(tcedolinonontrasferibile);
	tcedolinonontrasferibile.PrimaryKey =  new DataColumn[]{tcedolinonontrasferibile.Columns["idpayroll"]};


	//////////////////// CEDOLINOANNOSUCCESSIVO /////////////////////////////////
	var tcedolinoannosuccessivo= new DataTable("cedolinoannosuccessivo");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("cu", typeof(string)));
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tcedolinoannosuccessivo.Columns.Add(C);
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcedolinoannosuccessivo.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	Tables.Add(tcedolinoannosuccessivo);
	tcedolinoannosuccessivo.PrimaryKey =  new DataColumn[]{tcedolinoannosuccessivo.Columns["idpayroll"]};


	//////////////////// CEDOLINOEROGATO /////////////////////////////////
	var tcedolinoerogato= new DataTable("cedolinoerogato");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	tcedolinoerogato.Columns.Add( new DataColumn("!eserccontratto", typeof(int)));
	tcedolinoerogato.Columns.Add( new DataColumn("!numcontratto", typeof(int)));
	tcedolinoerogato.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tcedolinoerogato.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	tcedolinoerogato.Columns.Add( new DataColumn("lu", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcedolinoerogato.Columns.Add( new DataColumn("cu", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcedolinoerogato.Columns.Add(C);
	tcedolinoerogato.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tcedolinoerogato.Columns.Add( new DataColumn("!denominazione", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("!causa", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcedolinoerogato.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	Tables.Add(tcedolinoerogato);
	tcedolinoerogato.PrimaryKey =  new DataColumn[]{tcedolinoerogato.Columns["idpayroll"]};


	//////////////////// PARASUBCONTRACT /////////////////////////////////
	var tparasubcontract= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("duty", typeof(string)));
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idpat", typeof(int)));
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("matricula", typeof(int)));
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("txt", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idupb", typeof(string)));
	Tables.Add(tparasubcontract);
	tparasubcontract.PrimaryKey =  new DataColumn[]{tparasubcontract.Columns["idcon"]};


	//////////////////// PARASUBCONTRACTYEAR /////////////////////////////////
	var tparasubcontractyear= new DataTable("parasubcontractyear");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractyear.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractyear.Columns.Add(C);
	tparasubcontractyear.Columns.Add( new DataColumn("citytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("countrytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("regionaltax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedcountrytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("applybrackets", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("activitycode", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("idotherinsurance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("notaxdeduction", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("fiscaldeduction", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("ndays", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("cuddays", typeof(short)));
	tparasubcontractyear.Columns.Add( new DataColumn("idresidence", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablecontract", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablecud", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablepension", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("highertax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("notaxappliance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("competencymonths", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("idemenscontractkind", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("annualincome", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("citytax_account", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ratequantity_account", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("startmonth_account", typeof(int)));
	Tables.Add(tparasubcontractyear);
	tparasubcontractyear.PrimaryKey =  new DataColumn[]{tparasubcontractyear.Columns["ayear"], tparasubcontractyear.Columns["idcon"]};


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	tservice.Columns.Add( new DataColumn("active", typeof(string)));
	tservice.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagapplyabatements", typeof(string)));
	C= new DataColumn("flagonlyfiscalabatement", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice.Columns.Add( new DataColumn("ivaamount", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("module", typeof(string)));
	tservice.Columns.Add( new DataColumn("rec770kind", typeof(string)));
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


	//////////////////// PAYROLLTAXCORRIGE /////////////////////////////////
	var tpayrolltaxcorrige= new DataTable("payrolltaxcorrige");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("idpayrolltaxcorrige", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	tpayrolltaxcorrige.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("employamount", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("adminamount", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("idcity", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	Tables.Add(tpayrolltaxcorrige);
	tpayrolltaxcorrige.PrimaryKey =  new DataColumn[]{tpayrolltaxcorrige.Columns["idpayroll"], tpayrolltaxcorrige.Columns["idpayrolltaxcorrige"]};


	//////////////////// UPB_CEDOLINOEROGATO /////////////////////////////////
	var tupb_cedolinoerogato= new DataTable("upb_cedolinoerogato");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	tupb_cedolinoerogato.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	tupb_cedolinoerogato.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoerogato.Columns.Add(C);
	tupb_cedolinoerogato.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_cedolinoerogato.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb_cedolinoerogato);
	tupb_cedolinoerogato.PrimaryKey =  new DataColumn[]{tupb_cedolinoerogato.Columns["idupb"]};


	//////////////////// UPB_PAYROLL /////////////////////////////////
	var tupb_payroll= new DataTable("upb_payroll");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	tupb_payroll.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_payroll.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_payroll.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_payroll.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_payroll.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb_payroll.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_payroll.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	tupb_payroll.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_payroll.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_payroll.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	tupb_payroll.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_payroll.Columns.Add(C);
	tupb_payroll.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_payroll.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_payroll.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_payroll.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_payroll.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_payroll.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb_payroll);
	tupb_payroll.PrimaryKey =  new DataColumn[]{tupb_payroll.Columns["idupb"]};


	//////////////////// UPB_CEDOLINONONTRASFERIBILE /////////////////////////////////
	var tupb_cedolinonontrasferibile= new DataTable("upb_cedolinonontrasferibile");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinonontrasferibile.Columns.Add(C);
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_cedolinonontrasferibile.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb_cedolinonontrasferibile);
	tupb_cedolinonontrasferibile.PrimaryKey =  new DataColumn[]{tupb_cedolinonontrasferibile.Columns["idupb"]};


	//////////////////// UPB_CEDOLINOANNOSUCCESSIVO /////////////////////////////////
	var tupb_cedolinoannosuccessivo= new DataTable("upb_cedolinoannosuccessivo");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_cedolinoannosuccessivo.Columns.Add(C);
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_cedolinoannosuccessivo.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb_cedolinoannosuccessivo);
	tupb_cedolinoannosuccessivo.PrimaryKey =  new DataColumn[]{tupb_cedolinoannosuccessivo.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{cedolinonontrasferibile.Columns["idpayroll"]};
	var cChild = new []{payrolltaxcorrige.Columns["idpayroll"]};
	Relations.Add(new DataRelation("cedolinonontrasferibile_payrolltaxcorrige",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltaxcorrige.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltaxcorrige",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractyear.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractyear",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{parasubcontract.Columns["idser"]};
	Relations.Add(new DataRelation("service_parasubcontract",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{cedolinonontrasferibile.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontract_cedolinonontrasferibile",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrollabatement.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrollabatement",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolldeduction.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolldeduction",cPar,cChild,false));

	cPar = new []{payrolltax.Columns["idpayroll"], payrolltax.Columns["idpayrolltax"]};
	cChild = new []{payrolltaxbracket.Columns["idpayroll"], payrolltaxbracket.Columns["idpayrolltax"]};
	Relations.Add(new DataRelation("payrolltaxpayrolltaxbracket",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltax",cPar,cChild,false));

	cPar = new []{cedolinonontrasferibile.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("cedolinonontrasferibile_payrolltax",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",cPar,cChild,false));

	cPar = new []{upb_cedolinoerogato.Columns["idupb"]};
	cChild = new []{cedolinoerogato.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_cedolinoerogato_cedolinoerogato",cPar,cChild,false));

	cPar = new []{upb_payroll.Columns["idupb"]};
	cChild = new []{payroll.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_payroll_payroll",cPar,cChild,false));

	cPar = new []{upb_cedolinonontrasferibile.Columns["idupb"]};
	cChild = new []{cedolinonontrasferibile.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_cedolinonontrasferibile_cedolinonontrasferibile",cPar,cChild,false));

	cPar = new []{upb_cedolinoannosuccessivo.Columns["idupb"]};
	cChild = new []{cedolinoannosuccessivo.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_cedolinoannosuccessivo_cedolinoannosuccessivo",cPar,cChild,false));

	#endregion

}
}
}
