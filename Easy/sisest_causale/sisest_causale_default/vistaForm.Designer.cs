
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace sisest_causale_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sisest_causale		{get { return Tables["sisest_causale"];}}
	///<summary>
	///Causali finanziarie (gerarchia)
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable finmotive		{get { return Tables["finmotive"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable finmotive_bollo		{get { return Tables["finmotive_bollo"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable finmotive_regionale		{get { return Tables["finmotive_regionale"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotiveapplied		{get { return Tables["accmotiveapplied"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotiveapplied_regionale_credit		{get { return Tables["accmotiveapplied_regionale_credit"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotiveapplied_regionale		{get { return Tables["accmotiveapplied_regionale"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotiveapplied_bollo		{get { return Tables["accmotiveapplied_bollo"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotiveapplied_bollo_credit		{get { return Tables["accmotiveapplied_bollo_credit"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotiveapplied_credit		{get { return Tables["accmotiveapplied_credit"];}}
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
	//////////////////// SISEST_CAUSALE /////////////////////////////////
	T= new DataTable("sisest_causale");
	C= new DataColumn("idcausale", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codicecausale", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("descrizione", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("note", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("idfinmotive", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_credit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_bollo", typeof(String)));
	T.Columns.Add( new DataColumn("idfinmotive_bollo", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_bollo_credit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_regionale", typeof(String)));
	T.Columns.Add( new DataColumn("idfinmotive_regionale", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_regionale_credit", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("tiporiga", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("tipocompetenza", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcausale"]};


	//////////////////// FINMOTIVE /////////////////////////////////
	T= new DataTable("finmotive");
	C= new DataColumn("idfinmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridfinmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfinmotive"]};


	//////////////////// FINMOTIVE_BOLLO /////////////////////////////////
	T= new DataTable("finmotive_bollo");
	C= new DataColumn("idfinmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridfinmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfinmotive"]};


	//////////////////// FINMOTIVE_REGIONALE /////////////////////////////////
	T= new DataTable("finmotive_regionale");
	C= new DataColumn("idfinmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridfinmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfinmotive"]};


	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	T= new DataTable("accmotiveapplied");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("motive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idepoperation", typeof(String)));
	T.Columns.Add( new DataColumn("epoperation", typeof(String)));
	C= new DataColumn("in_use", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);

	//////////////////// ACCMOTIVEAPPLIED_REGIONALE_CREDIT /////////////////////////////////
	T= new DataTable("accmotiveapplied_regionale_credit");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("motive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idepoperation", typeof(String)));
	T.Columns.Add( new DataColumn("epoperation", typeof(String)));
	C= new DataColumn("in_use", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);

	//////////////////// ACCMOTIVEAPPLIED_REGIONALE /////////////////////////////////
	T= new DataTable("accmotiveapplied_regionale");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("motive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idepoperation", typeof(String)));
	T.Columns.Add( new DataColumn("epoperation", typeof(String)));
	C= new DataColumn("in_use", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);

	//////////////////// ACCMOTIVEAPPLIED_BOLLO /////////////////////////////////
	T= new DataTable("accmotiveapplied_bollo");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("motive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idepoperation", typeof(String)));
	T.Columns.Add( new DataColumn("epoperation", typeof(String)));
	C= new DataColumn("in_use", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);

	//////////////////// ACCMOTIVEAPPLIED_BOLLO_CREDIT /////////////////////////////////
	T= new DataTable("accmotiveapplied_bollo_credit");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("motive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idepoperation", typeof(String)));
	T.Columns.Add( new DataColumn("epoperation", typeof(String)));
	C= new DataColumn("in_use", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);

	//////////////////// ACCMOTIVEAPPLIED_CREDIT /////////////////////////////////
	T= new DataTable("accmotiveapplied_credit");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("motive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idepoperation", typeof(String)));
	T.Columns.Add( new DataColumn("epoperation", typeof(String)));
	C= new DataColumn("in_use", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{finmotive_bollo.Columns["idfinmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idfinmotive_bollo"]};
	Relations.Add(new DataRelation("finmotive_bollo_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{finmotive.Columns["idfinmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("finmotive_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{finmotive_regionale.Columns["idfinmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idfinmotive_regionale"]};
	Relations.Add(new DataRelation("finmotive_regionale_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotiveapplied.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveapplied_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotiveapplied_regionale_credit.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idaccmotive_regionale_credit"]};
	Relations.Add(new DataRelation("accmotiveapplied_regionale_credit_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotiveapplied_regionale.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idaccmotive_regionale"]};
	Relations.Add(new DataRelation("accmotiveapplied_regionale_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotiveapplied_bollo.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idaccmotive_bollo"]};
	Relations.Add(new DataRelation("accmotiveapplied_bollo_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotiveapplied_bollo_credit.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idaccmotive_bollo_credit"]};
	Relations.Add(new DataRelation("accmotiveapplied_bollo_credit_sisest_causale",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotiveapplied_credit.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{sisest_causale.Columns["idaccmotive_credit"]};
	Relations.Add(new DataRelation("accmotiveapplied_credit_sisest_causale",CPar,CChild,false));

	#endregion

}
}
}
