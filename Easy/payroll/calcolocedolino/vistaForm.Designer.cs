
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace calcolocedolino {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontract 		=> Tables["parasubcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolldeduction 		=> Tables["payrolldeduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollabatement 		=> Tables["payrollabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltax 		=> Tables["payrolltax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxbracket 		=> Tables["payrolltaxbracket"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractyear 		=> Tables["parasubcontractyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcud 		=> Tables["exhibitedcud"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable otherinail 		=> Tables["otherinail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pat 		=> Tables["pat"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcuddeduction 		=> Tables["exhibitedcuddeduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductioncode 		=> Tables["deductioncode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductibleexpense 		=> Tables["deductibleexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxablekind 		=> Tables["taxablekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deduction 		=> Tables["deduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractfamily 		=> Tables["parasubcontractfamily"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatement 		=> Tables["abatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatableexpense 		=> Tables["abatableexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatementcode 		=> Tables["abatementcode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcudabatement 		=> Tables["exhibitedcudabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cafdocument 		=> Tables["cafdocument"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxcorrige 		=> Tables["payrolltaxcorrige"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// PARASUBCONTRACT /////////////////////////////////
	var tparasubcontract= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("duty", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idpat", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("matricula", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("idupb", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tparasubcontract);
	tparasubcontract.PrimaryKey =  new DataColumn[]{tparasubcontract.Columns["idcon"]};


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("flagbalance", typeof(string));
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
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


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
	tpayrolltax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("annualcreditapplied", typeof(decimal)));
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


	//////////////////// PARASUBCONTRACTYEAR /////////////////////////////////
	var tparasubcontractyear= new DataTable("parasubcontractyear");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractyear.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractyear.Columns.Add(C);
	tparasubcontractyear.Columns.Add( new DataColumn("regionaltax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("countrytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("citytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedcountrytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("idotherinsurance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("activitycode", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("notaxappliance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("applybrackets", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("highertax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablecud", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("cuddays", typeof(short)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablecontract", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ndays", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablepension", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("fiscaldeduction", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("notaxdeduction", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("idresidence", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("annualincome", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("citytax_account", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ratequantity_account", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("startmonth_account", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("flagbonusappliance", typeof(string)));
	Tables.Add(tparasubcontractyear);
	tparasubcontractyear.PrimaryKey =  new DataColumn[]{tparasubcontractyear.Columns["ayear"], tparasubcontractyear.Columns["idcon"]};


	//////////////////// EXHIBITEDCUD /////////////////////////////////
	var texhibitedcud= new DataTable("exhibitedcud");
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("citytaxapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("regionaltaxapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("transfermotive", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("cfotherdeputy", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texhibitedcud.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("flagignoreprevcud", typeof(string));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	C= new DataColumn("taxablepension", typeof(decimal));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("inpsowed", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("inpsretained", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("irpefapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("irpefsuspended", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texhibitedcud.Columns.Add( new DataColumn("lu", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("ndays", typeof(int)));
	C= new DataColumn("nmonths", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("idcity", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("idlinkeddbdepartment", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("irpefgross", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("earnings_based_abatements", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("totabatements", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusnotapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("flagbonusaccredited", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("idlinkedcon", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusapplied2020", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusnotapplied2020", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("earnings_based_abatements2020", typeof(decimal)));
	Tables.Add(texhibitedcud);
	texhibitedcud.PrimaryKey =  new DataColumn[]{texhibitedcud.Columns["idexhibitedcud"], texhibitedcud.Columns["idcon"]};


	//////////////////// OTHERINAIL /////////////////////////////////
	var totherinail= new DataTable("otherinail");
	C= new DataColumn("idotherinail", typeof(int));
	C.AllowDBNull=false;
	totherinail.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	totherinail.Columns.Add(C);
	totherinail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	totherinail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	totherinail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	totherinail.Columns.Add( new DataColumn("nmonths", typeof(int)));
	Tables.Add(totherinail);
	totherinail.PrimaryKey =  new DataColumn[]{totherinail.Columns["idotherinail"], totherinail.Columns["idcon"]};


	//////////////////// PAT /////////////////////////////////
	var tpat= new DataTable("pat");
	C= new DataColumn("idpat", typeof(int));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	tpat.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	C= new DataColumn("patcode", typeof(string));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	tpat.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	tpat.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("active", typeof(string)));
	tpat.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("lu", typeof(string)));
	tpat.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	Tables.Add(tpat);
	tpat.PrimaryKey =  new DataColumn[]{tpat.Columns["idpat"]};


	//////////////////// EXHIBITEDCUDDEDUCTION /////////////////////////////////
	var texhibitedcuddeduction= new DataTable("exhibitedcuddeduction");
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcuddeduction.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcuddeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	texhibitedcuddeduction.Columns.Add(C);
	texhibitedcuddeduction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	Tables.Add(texhibitedcuddeduction);
	texhibitedcuddeduction.PrimaryKey =  new DataColumn[]{texhibitedcuddeduction.Columns["idexhibitedcud"], texhibitedcuddeduction.Columns["idcon"], texhibitedcuddeduction.Columns["iddeduction"]};


	//////////////////// DEDUCTIONCODE /////////////////////////////////
	var tdeductioncode= new DataTable("deductioncode");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	tdeductioncode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("code", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("description", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeductioncode.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tdeductioncode);
	tdeductioncode.PrimaryKey =  new DataColumn[]{tdeductioncode.Columns["ayear"], tdeductioncode.Columns["iddeduction"]};


	//////////////////// DEDUCTIBLEEXPENSE /////////////////////////////////
	var tdeductibleexpense= new DataTable("deductibleexpense");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	tdeductibleexpense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tdeductibleexpense.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("totalamount", typeof(decimal));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	tdeductibleexpense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeductibleexpense.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tdeductibleexpense);
	tdeductibleexpense.PrimaryKey =  new DataColumn[]{tdeductibleexpense.Columns["ayear"], tdeductibleexpense.Columns["idcon"], tdeductibleexpense.Columns["iddeduction"]};


	//////////////////// TAXABLEKIND /////////////////////////////////
	var ttaxablekind= new DataTable("taxablekind");
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("roundingkind", typeof(string)));
	ttaxablekind.Columns.Add( new DataColumn("idtaxablekind", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	ttaxablekind.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("evaluationorder", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("spcalcannualtaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("spcalcrefertaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	Tables.Add(ttaxablekind);
	ttaxablekind.PrimaryKey =  new DataColumn[]{ttaxablekind.Columns["taxablecode"], ttaxablekind.Columns["ayear"]};


	//////////////////// DEDUCTION /////////////////////////////////
	var tdeduction= new DataTable("deduction");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	tdeduction.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("flagdeductibleexpense", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	tdeduction.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeduction.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	Tables.Add(tdeduction);
	tdeduction.PrimaryKey =  new DataColumn[]{tdeduction.Columns["iddeduction"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// PARASUBCONTRACTFAMILY /////////////////////////////////
	var tparasubcontractfamily= new DataTable("parasubcontractfamily");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("idfamily", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("idaffinity", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("surname", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("stopapplication", typeof(DateTime)));
	C= new DataColumn("flagdependent", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	C= new DataColumn("foreignresident", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("idcitybirth", typeof(int)));
	tparasubcontractfamily.Columns.Add( new DataColumn("idnation", typeof(int)));
	tparasubcontractfamily.Columns.Add( new DataColumn("startapplication", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("starthandicap", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("forename", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("appliancepercentage", typeof(decimal)));
	tparasubcontractfamily.Columns.Add( new DataColumn("gender", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tparasubcontractfamily.Columns.Add( new DataColumn("childasparent", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	Tables.Add(tparasubcontractfamily);
	tparasubcontractfamily.PrimaryKey =  new DataColumn[]{tparasubcontractfamily.Columns["ayear"], tparasubcontractfamily.Columns["idcon"], tparasubcontractfamily.Columns["idfamily"]};


	//////////////////// ABATEMENT /////////////////////////////////
	var tabatement= new DataTable("abatement");
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	tabatement.Columns.Add( new DataColumn("appliance", typeof(string)));
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	tabatement.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("flagabatableexpense", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	tabatement.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("lu", typeof(string)));
	tabatement.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	Tables.Add(tabatement);
	tabatement.PrimaryKey =  new DataColumn[]{tabatement.Columns["idabatement"]};


	//////////////////// ABATABLEEXPENSE /////////////////////////////////
	var tabatableexpense= new DataTable("abatableexpense");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tabatableexpense.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tabatableexpense.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatableexpense.Columns.Add(C);
	tabatableexpense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tabatableexpense.Columns.Add( new DataColumn("cu", typeof(string)));
	tabatableexpense.Columns.Add( new DataColumn("totalamount", typeof(decimal)));
	tabatableexpense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tabatableexpense.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tabatableexpense);
	tabatableexpense.PrimaryKey =  new DataColumn[]{tabatableexpense.Columns["ayear"], tabatableexpense.Columns["idcon"], tabatableexpense.Columns["idabatement"]};


	//////////////////// ABATEMENTCODE /////////////////////////////////
	var tabatementcode= new DataTable("abatementcode");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tabatementcode.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatementcode.Columns.Add(C);
	tabatementcode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tabatementcode.Columns.Add( new DataColumn("code", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("description", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tabatementcode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	Tables.Add(tabatementcode);
	tabatementcode.PrimaryKey =  new DataColumn[]{tabatementcode.Columns["ayear"], tabatementcode.Columns["idabatement"]};


	//////////////////// EXHIBITEDCUDABATEMENT /////////////////////////////////
	var texhibitedcudabatement= new DataTable("exhibitedcudabatement");
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcudabatement.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcudabatement.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	texhibitedcudabatement.Columns.Add(C);
	texhibitedcudabatement.Columns.Add( new DataColumn("amount", typeof(decimal)));
	Tables.Add(texhibitedcudabatement);
	texhibitedcudabatement.PrimaryKey =  new DataColumn[]{texhibitedcudabatement.Columns["idexhibitedcud"], texhibitedcudabatement.Columns["idcon"], texhibitedcudabatement.Columns["idabatement"]};


	//////////////////// CAFDOCUMENT /////////////////////////////////
	var tcafdocument= new DataTable("cafdocument");
	C= new DataColumn("idcafdocument", typeof(int));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("cafdocumentkind", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("docdate", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	tcafdocument.Columns.Add( new DataColumn("citytaxtorefundhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtoretainhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtorefundhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtoretainhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("idcity", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tcafdocument.Columns.Add( new DataColumn("irpeftorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("irpeftoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("monthfirstinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("monthsecondinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("nquotafirstinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("nquotasecondinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("firstrateadvance", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("separatedincomehusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("separatedincome", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("secondrateadvance", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	tcafdocument.Columns.Add( new DataColumn("citytaxaccount", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxaccounthusband", typeof(decimal)));
	Tables.Add(tcafdocument);
	tcafdocument.PrimaryKey =  new DataColumn[]{tcafdocument.Columns["idcafdocument"], tcafdocument.Columns["idcon"]};


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
	tpayrolltaxcorrige.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	Tables.Add(tpayrolltaxcorrige);
	tpayrolltaxcorrige.PrimaryKey =  new DataColumn[]{tpayrolltaxcorrige.Columns["idpayroll"], tpayrolltaxcorrige.Columns["idpayrolltaxcorrige"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payroll.Columns["idpayroll"]};
	var cChild = new []{payrolltaxcorrige.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltaxcorrige",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{cafdocument.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractcafdocument",cPar,cChild,false));

	cPar = new []{exhibitedcud.Columns["idexhibitedcud"], exhibitedcud.Columns["idcon"]};
	cChild = new []{exhibitedcudabatement.Columns["idexhibitedcud"], exhibitedcudabatement.Columns["idcon"]};
	Relations.Add(new DataRelation("exhibitedcudexhibitedcudabatement",cPar,cChild,false));

	cPar = new []{exhibitedcud.Columns["idexhibitedcud"], exhibitedcud.Columns["idcon"]};
	cChild = new []{exhibitedcuddeduction.Columns["idexhibitedcud"], exhibitedcuddeduction.Columns["idcon"]};
	Relations.Add(new DataRelation("exhibitedcudexhibitedcuddeduction",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{otherinail.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractotherinail",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{exhibitedcud.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractexhibitedcud",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractyear.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractyear",cPar,cChild,false));

	cPar = new []{payrolltax.Columns["idpayroll"], payrolltax.Columns["idpayrolltax"]};
	cChild = new []{payrolltaxbracket.Columns["idpayroll"], payrolltaxbracket.Columns["idpayrolltax"]};
	Relations.Add(new DataRelation("payrolltaxpayrolltaxbracket",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltax",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrollabatement.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrollabatement",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolldeduction.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolldeduction",cPar,cChild,false));

	cPar = new []{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idcon"]};
	cChild = new []{payroll.Columns["fiscalyear"], payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractyearpayroll",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",cPar,cChild,false));

	cPar = new []{pat.Columns["idpat"]};
	cChild = new []{parasubcontract.Columns["idpat"]};
	Relations.Add(new DataRelation("patparasubcontract",cPar,cChild,false));

	#endregion

}
}
}
