
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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace treasurer_situazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Istituto Cassiere
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable treasurerstart		{get { return Tables["treasurerstart"];}}
	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable treasurer		{get { return Tables["treasurer"];}}
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
	//////////////////// TREASURERSTART /////////////////////////////////
	T= new DataTable("treasurerstart");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idtreasurer", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idtreasurer"]};


	//////////////////// TREASURER /////////////////////////////////
	T= new DataTable("treasurer");
	T.Columns.Add( new DataColumn("address", typeof(String)));
	T.Columns.Add( new DataColumn("agencycodefortransmission", typeof(String)));
	T.Columns.Add( new DataColumn("cabcodefortransmission", typeof(String)));
	T.Columns.Add( new DataColumn("cap", typeof(String)));
	T.Columns.Add( new DataColumn("cc", typeof(String)));
	T.Columns.Add( new DataColumn("cin", typeof(String)));
	T.Columns.Add( new DataColumn("city", typeof(String)));
	T.Columns.Add( new DataColumn("country", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("depcodefortransmission", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("faxnumber", typeof(String)));
	T.Columns.Add( new DataColumn("faxprefix", typeof(String)));
	C= new DataColumn("flagdefault", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idaccmotive_payment", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(String)));
	T.Columns.Add( new DataColumn("idbank", typeof(String)));
	T.Columns.Add( new DataColumn("idcab", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("phoneprefix", typeof(String)));
	C= new DataColumn("codetreasurer", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idtreasurer", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("spexportexp", typeof(String)));
	T.Columns.Add( new DataColumn("flagmultiexp", typeof(String)));
	T.Columns.Add( new DataColumn("fileextension", typeof(String)));
	T.Columns.Add( new DataColumn("spexportinc", typeof(String)));
	T.Columns.Add( new DataColumn("iban", typeof(String)));
	T.Columns.Add( new DataColumn("bic", typeof(String)));
	T.Columns.Add( new DataColumn("flagfruitful", typeof(String)));
	T.Columns.Add( new DataColumn("cccbi", typeof(String)));
	T.Columns.Add( new DataColumn("cincbi", typeof(String)));
	T.Columns.Add( new DataColumn("idbankcbi", typeof(String)));
	T.Columns.Add( new DataColumn("idcabcbi", typeof(String)));
	T.Columns.Add( new DataColumn("ibancbi", typeof(String)));
	T.Columns.Add( new DataColumn("siacodecbi", typeof(String)));
	T.Columns.Add( new DataColumn("reccbikind", typeof(String)));
	T.Columns.Add( new DataColumn("trasmcode", typeof(String)));
	T.Columns.Add( new DataColumn("flagbank_grouping", typeof(Int32)));
	T.Columns.Add( new DataColumn("motivelen", typeof(Int16)));
	T.Columns.Add( new DataColumn("motiveprefix", typeof(String)));
	T.Columns.Add( new DataColumn("motiveseparator", typeof(String)));
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("flagedisp", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("billcode", typeof(String)));
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("header", typeof(String)));
	T.Columns.Add( new DataColumn("savepath", typeof(String)));
	T.Columns.Add( new DataColumn("departmentname_fe", typeof(String)));
	T.Columns.Add( new DataColumn("idstruttura", typeof(Int32)));
	T.Columns.Add( new DataColumn("enable_ndoc_treasurer", typeof(String)));
	T.Columns.Add( new DataColumn("flussocrediticode", typeof(String)));
	T.Columns.Add( new DataColumn("ftpuser", typeof(String)));
	T.Columns.Add( new DataColumn("ftppassword", typeof(String)));
	T.Columns.Add( new DataColumn("ftpaddress", typeof(String)));
	T.Columns.Add( new DataColumn("pasvmode", typeof(String)));
	T.Columns.Add( new DataColumn("ftpport", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idtreasurer"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{treasurer.Columns["idtreasurer"]};
	CChild = new DataColumn[1]{treasurerstart.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("treasurer_treasurerstart",CPar,CChild,false));

	#endregion

}
}
}
