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
using System.Data;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace parasubcontract_nontrasferibile {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable parasubcontract		{get { return Tables["parasubcontract"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable parasubcontractview		{get { return Tables["parasubcontractview"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
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
	T.Columns.Add( new DataColumn("requested_doc", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"]};


	//////////////////// PARASUBCONTRACTVIEW /////////////////////////////////
	T= new DataTable("parasubcontractview");
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
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
	C= new DataColumn("registry", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("matricula", typeof(Int32)));
	T.Columns.Add( new DataColumn("duty", typeof(String)));
	T.Columns.Add( new DataColumn("idpayrollkind", typeof(String)));
	T.Columns.Add( new DataColumn("payroll", typeof(String)));
	C= new DataColumn("idser", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("service", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idresidence", typeof(Int32)));
	T.Columns.Add( new DataColumn("city", typeof(String)));
	T.Columns.Add( new DataColumn("idcountry", typeof(Int32)));
	T.Columns.Add( new DataColumn("country", typeof(String)));
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
	T.Columns.Add( new DataColumn("activitycode", typeof(String)));
	T.Columns.Add( new DataColumn("activity", typeof(String)));
	T.Columns.Add( new DataColumn("idotherinsurance", typeof(String)));
	T.Columns.Add( new DataColumn("otherinsurance", typeof(String)));
	T.Columns.Add( new DataColumn("idpat", typeof(Int32)));
	T.Columns.Add( new DataColumn("patcode", typeof(String)));
	T.Columns.Add( new DataColumn("pat", typeof(String)));
	T.Columns.Add( new DataColumn("idmatriculabook", typeof(String)));
	T.Columns.Add( new DataColumn("matriculabook", typeof(String)));
	T.Columns.Add( new DataColumn("regionaltax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("countrytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("citytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("ratequantity", typeof(Int32)));
	T.Columns.Add( new DataColumn("startmonth", typeof(Int32)));
	T.Columns.Add( new DataColumn("suspendedregionaltax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("suspendedcountrytax", typeof(Decimal)));
	T.Columns.Add( new DataColumn("suspendedcitytax", typeof(Decimal)));
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
	T.Columns.Add( new DataColumn("!causa", typeof(String)));
	Tables.Add(T);

	#endregion

}
}
}
