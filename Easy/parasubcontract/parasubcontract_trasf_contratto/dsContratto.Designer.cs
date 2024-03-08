
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
namespace parasubcontract_trasf_contratto {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsContratto"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsContratto: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontract 		=> Tables["parasubcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractyear 		=> Tables["parasubcontractyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractfamily 		=> Tables["parasubcontractfamily"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable contrattonontrasferibile 		=> Tables["contrattonontrasferibile"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable otherinsurance 		=> Tables["otherinsurance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inpsactivity 		=> Tables["inpsactivity"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emenscontractkind 		=> Tables["emenscontractkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollview 		=> Tables["payrollview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsContratto(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsContratto (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsContratto";
	Prefix = "";
	Namespace = "http://tempuri.org/dsContratto.xsd";

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
	tparasubcontract.Columns.Add( new DataColumn("!denominazione", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("!causa", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
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
	tparasubcontractyear.Columns.Add( new DataColumn("idemenscontractkind", typeof(string)));
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
	tparasubcontractyear.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("idresidence", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("flagbonusappliance", typeof(string)));
	Tables.Add(tparasubcontractyear);
	tparasubcontractyear.PrimaryKey =  new DataColumn[]{tparasubcontractyear.Columns["ayear"], tparasubcontractyear.Columns["idcon"]};


	//////////////////// PARASUBCONTRACTFAMILY /////////////////////////////////
	var tparasubcontractfamily= new DataTable("parasubcontractfamily");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("idfamily", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("idaffinity", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("surname", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("forename", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("idcitybirth", typeof(int)));
	tparasubcontractfamily.Columns.Add( new DataColumn("idnation", typeof(int)));
	tparasubcontractfamily.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("gender", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("cf", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("startapplication", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("stopapplication", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("appliancepercentage", typeof(decimal)));
	tparasubcontractfamily.Columns.Add( new DataColumn("starthandicap", typeof(DateTime)));
	C= new DataColumn("foreignresident", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("flagdependent", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	Tables.Add(tparasubcontractfamily);
	tparasubcontractfamily.PrimaryKey =  new DataColumn[]{tparasubcontractfamily.Columns["idcon"], tparasubcontractfamily.Columns["idfamily"], tparasubcontractfamily.Columns["ayear"]};


	//////////////////// CONTRATTONONTRASFERIBILE /////////////////////////////////
	var tcontrattonontrasferibile= new DataTable("contrattonontrasferibile");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	tcontrattonontrasferibile.Columns.Add( new DataColumn("!causa", typeof(string)));
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	tcontrattonontrasferibile.Columns.Add( new DataColumn("duty", typeof(string)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tcontrattonontrasferibile.Columns.Add(C);
	tcontrattonontrasferibile.Columns.Add( new DataColumn("idpat", typeof(int)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("matricula", typeof(int)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("cu", typeof(string)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("lu", typeof(string)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcontrattonontrasferibile.Columns.Add( new DataColumn("!denominazione", typeof(string)));
	Tables.Add(tcontrattonontrasferibile);
	tcontrattonontrasferibile.PrimaryKey =  new DataColumn[]{tcontrattonontrasferibile.Columns["idcon"]};


	//////////////////// OTHERINSURANCE /////////////////////////////////
	var totherinsurance= new DataTable("otherinsurance");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	C= new DataColumn("idotherinsurance", typeof(string));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	totherinsurance.Columns.Add( new DataColumn("lu", typeof(string)));
	totherinsurance.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(totherinsurance);
	totherinsurance.PrimaryKey =  new DataColumn[]{totherinsurance.Columns["ayear"], totherinsurance.Columns["idotherinsurance"]};


	//////////////////// INPSACTIVITY /////////////////////////////////
	var tinpsactivity= new DataTable("inpsactivity");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tinpsactivity.Columns.Add(C);
	C= new DataColumn("activitycode", typeof(string));
	C.AllowDBNull=false;
	tinpsactivity.Columns.Add(C);
	tinpsactivity.Columns.Add( new DataColumn("description", typeof(string)));
	tinpsactivity.Columns.Add( new DataColumn("lu", typeof(string)));
	tinpsactivity.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tinpsactivity);
	tinpsactivity.PrimaryKey =  new DataColumn[]{tinpsactivity.Columns["ayear"], tinpsactivity.Columns["activitycode"]};


	//////////////////// EMENSCONTRACTKIND /////////////////////////////////
	var temenscontractkind= new DataTable("emenscontractkind");
	C= new DataColumn("idemenscontractkind", typeof(string));
	C.AllowDBNull=false;
	temenscontractkind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	temenscontractkind.Columns.Add(C);
	temenscontractkind.Columns.Add( new DataColumn("description", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("annotations", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("flagactivityrequested", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("module", typeof(string)));
	Tables.Add(temenscontractkind);
	temenscontractkind.PrimaryKey =  new DataColumn[]{temenscontractkind.Columns["ayear"], temenscontractkind.Columns["idemenscontractkind"]};


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tpayroll.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// PAYROLLVIEW /////////////////////////////////
	var tpayrollview= new DataTable("payrollview");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tpayrollview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrollview.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayrollview.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("matricula", typeof(int)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("service", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("residencecity", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("sortcode1", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpayrollview);
	tpayrollview.PrimaryKey =  new DataColumn[]{tpayrollview.Columns["idpayroll"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{parasubcontract.Columns["idcon"]};
	var cChild = new []{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractfamily.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractfamily",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractyear.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractyear",cPar,cChild,false));

	cPar = new []{otherinsurance.Columns["ayear"], otherinsurance.Columns["idotherinsurance"]};
	cChild = new []{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idotherinsurance"]};
	Relations.Add(new DataRelation("otherinsuranceparasubcontractyear",cPar,cChild,false));

	cPar = new []{inpsactivity.Columns["ayear"], inpsactivity.Columns["activitycode"]};
	cChild = new []{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["activitycode"]};
	Relations.Add(new DataRelation("inpsactivityparasubcontractyear",cPar,cChild,false));

	cPar = new []{emenscontractkind.Columns["ayear"], emenscontractkind.Columns["idemenscontractkind"]};
	cChild = new []{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idemenscontractkind"]};
	Relations.Add(new DataRelation("emenscontractkindparasubcontractyear",cPar,cChild,false));

	#endregion

}
}
}
