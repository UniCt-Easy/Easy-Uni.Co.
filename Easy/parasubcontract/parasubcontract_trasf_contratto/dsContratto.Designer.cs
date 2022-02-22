
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace parasubcontract_trasf_contratto {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsContratto")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsContratto: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable parasubcontract		{get { return Tables["parasubcontract"];}}
	///<summary>
	///informazioni annuali sul contratto parasubordinato
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable parasubcontractyear		{get { return Tables["parasubcontractyear"];}}
	///<summary>
	///Familiare - Dettaglio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable parasubcontractfamily		{get { return Tables["parasubcontractfamily"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable contrattonontrasferibile		{get { return Tables["contrattonontrasferibile"];}}
	///<summary>
	///Altra Forma Assicurativa (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable otherinsurance		{get { return Tables["otherinsurance"];}}
	///<summary>
	///Attivit√† Previdenziale INPS (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable inpsactivity		{get { return Tables["inpsactivity"];}}
	///<summary>
	///Tipo Rapporto (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable emenscontractkind		{get { return Tables["emenscontractkind"];}}
	///<summary>
	///Cedolino
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable payroll		{get { return Tables["payroll"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsContratto(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected dsContratto (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsContratto";
	Prefix = "";
	Namespace = "http://tempuri.org/dsContratto.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// PARASUBCONTRACT /////////////////////////////////
	T= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ycon", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("duty", typeof(String)));
	T.Columns.Add( new DataColumn("idpayrollkind", typeof(String)));
	C= new DataColumn("idser", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("employed", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpat", typeof(Int32)));
	T.Columns.Add( new DataColumn("matricula", typeof(Int32)));
	T.Columns.Add( new DataColumn("idmatriculabook", typeof(String)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("!denominazione", typeof(String)));
	T.Columns.Add( new DataColumn("!causa", typeof(String)));
	T.Columns.Add( new DataColumn("requested_doc", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"]};


	//////////////////// PARASUBCONTRACTYEAR /////////////////////////////////
	T= new DataTable("parasubcontractyear");
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("regionaltax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("countrytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("citytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ratequantity", typeof(Int32)));
	T.Columns.Add( new DataColumn("startmonth", typeof(Int32)));
	T.Columns.Add( new DataColumn("suspendedregionaltax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("suspendedcitytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("suspendedcountrytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idotherinsurance", typeof(String)));
	T.Columns.Add( new DataColumn("activitycode", typeof(String)));
	T.Columns.Add( new DataColumn("idemenscontractkind", typeof(String)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("notaxappliance", typeof(String)));
	T.Columns.Add( new DataColumn("applybrackets", typeof(String)));
	T.Columns.Add( new DataColumn("highertax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxablecud", typeof(Decimal)));
	T.Columns.Add( new DataColumn("cuddays", typeof(Int16)));
	T.Columns.Add( new DataColumn("taxablecontract", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ndays", typeof(Int32)));
	T.Columns.Add( new DataColumn("taxablepension", typeof(Decimal)));
	T.Columns.Add( new DataColumn("fiscaldeduction", typeof(Decimal)));
	T.Columns.Add( new DataColumn("notaxdeduction", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxablegross", typeof(Decimal)));
	T.Columns.Add( new DataColumn("taxablenet", typeof(Decimal)));
	T.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idresidence", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagbonusappliance", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idcon"]};


	//////////////////// PARASUBCONTRACTFAMILY /////////////////////////////////
	T= new DataTable("parasubcontractfamily");
	C= new DataColumn("idcon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idfamily", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idaffinity", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("idcitybirth", typeof(Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("flagforeign", typeof(String)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	T.Columns.Add( new DataColumn("startapplication", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stopapplication", typeof(DateTime)));
	T.Columns.Add( new DataColumn("appliancepercentage", typeof(Decimal)));
	T.Columns.Add( new DataColumn("starthandicap", typeof(DateTime)));
	C= new DataColumn("foreignresident", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagdependent", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"], T.Columns["idfamily"], T.Columns["ayear"]};


	//////////////////// CONTRATTONONTRASFERIBILE /////////////////////////////////
	T= new DataTable("contrattonontrasferibile");
	C= new DataColumn("idcon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!causa", typeof(String)));
	C= new DataColumn("ycon", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("duty", typeof(String)));
	T.Columns.Add( new DataColumn("idpayrollkind", typeof(String)));
	C= new DataColumn("idser", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("employed", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpat", typeof(Int32)));
	T.Columns.Add( new DataColumn("matricula", typeof(Int32)));
	T.Columns.Add( new DataColumn("idmatriculabook", typeof(String)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("!denominazione", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"]};


	//////////////////// OTHERINSURANCE /////////////////////////////////
	T= new DataTable("otherinsurance");
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idotherinsurance", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idotherinsurance"]};


	//////////////////// INPSACTIVITY /////////////////////////////////
	T= new DataTable("inpsactivity");
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("activitycode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["activitycode"]};


	//////////////////// EMENSCONTRACTKIND /////////////////////////////////
	T= new DataTable("emenscontractkind");
	C= new DataColumn("idemenscontractkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("flagactivityrequested", typeof(String)));
	T.Columns.Add( new DataColumn("module", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idemenscontractkind"]};


	//////////////////// PAYROLL /////////////////////////////////
	T= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("feegross", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("netfee", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagbalance", typeof(String)));
	C= new DataColumn("workingdays", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idresidence", typeof(Int32)));
	C= new DataColumn("idcon", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	C= new DataColumn("npayroll", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagsummarybalance", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpayroll"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{parasubcontract.Columns["idcon"]};
	CChild = new DataColumn[1]{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",CPar,CChild,false));

	CPar = new DataColumn[1]{parasubcontract.Columns["idcon"]};
	CChild = new DataColumn[1]{parasubcontractfamily.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractfamily",CPar,CChild,false));

	CPar = new DataColumn[1]{parasubcontract.Columns["idcon"]};
	CChild = new DataColumn[1]{parasubcontractyear.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractyear",CPar,CChild,false));

	CPar = new DataColumn[2]{otherinsurance.Columns["ayear"], otherinsurance.Columns["idotherinsurance"]};
	CChild = new DataColumn[2]{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idotherinsurance"]};
	Relations.Add(new DataRelation("otherinsuranceparasubcontractyear",CPar,CChild,false));

	CPar = new DataColumn[2]{inpsactivity.Columns["ayear"], inpsactivity.Columns["activitycode"]};
	CChild = new DataColumn[2]{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["activitycode"]};
	Relations.Add(new DataRelation("inpsactivityparasubcontractyear",CPar,CChild,false));

	CPar = new DataColumn[2]{emenscontractkind.Columns["ayear"], emenscontractkind.Columns["idemenscontractkind"]};
	CChild = new DataColumn[2]{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idemenscontractkind"]};
	Relations.Add(new DataRelation("emenscontractkindparasubcontractyear",CPar,CChild,false));

	#endregion

}
}
}
