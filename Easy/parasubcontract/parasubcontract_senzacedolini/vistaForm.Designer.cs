
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
namespace parasubcontract_senzacedolini {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontract 		=> Tables["parasubcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractview 		=> Tables["parasubcontractview"];

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
	tparasubcontract.Columns.Add( new DataColumn("idcostpartitioin", typeof(int)));
	Tables.Add(tparasubcontract);
	tparasubcontract.PrimaryKey =  new DataColumn[]{tparasubcontract.Columns["idcon"]};


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
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
	tpayroll.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// PARASUBCONTRACTVIEW /////////////////////////////////
	var tparasubcontractview= new DataTable("parasubcontractview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("matricula", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("duty", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("payroll", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("service", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("idresidence", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("city", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("activitycode", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("activity", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idotherinsurance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("otherinsurance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idpat", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("patcode", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("pat", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("matriculabook", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("regionaltax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("countrytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("citytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedcountrytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("notaxappliance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("applybrackets", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("highertax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablecud", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("cuddays", typeof(short)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablecontract", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("ndays", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablepension", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("fiscaldeduction", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("notaxdeduction", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	tparasubcontractview.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	tparasubcontractview.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tparasubcontractview);

	#endregion


	#region DataRelation creation
	var cPar = new []{parasubcontract.Columns["idcon"]};
	var cChild = new []{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",cPar,cChild,false));

	#endregion

}
}
}
