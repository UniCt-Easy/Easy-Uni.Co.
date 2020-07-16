/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace abatement_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Informazioni su una detrazione per un determinato esercizo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable abatementcode		{get { return Tables["abatementcode"];}}
	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tax		{get { return Tables["tax"];}}
	///<summary>
	///Tipo detrazione, usato nei contratti parasubordinati
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable abatement		{get { return Tables["abatement"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable abatementview		{get { return Tables["abatementview"];}}
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
	//////////////////// ABATEMENTCODE /////////////////////////////////
	T= new DataTable("abatementcode");
	C= new DataColumn("idabatement", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("code", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("exemption", typeof(Decimal)));
	T.Columns.Add( new DataColumn("maximal", typeof(Decimal)));
	T.Columns.Add( new DataColumn("rate", typeof(Decimal)));
	T.Columns.Add( new DataColumn("longdescription", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idabatement"], T.Columns["ayear"]};


	//////////////////// TAX /////////////////////////////////
	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("taxkind", typeof(Int16)));
	T.Columns.Add( new DataColumn("fiscaltaxcode", typeof(String)));
	T.Columns.Add( new DataColumn("flagunabatable", typeof(String)));
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
	T.Columns.Add( new DataColumn("taxablecode", typeof(String)));
	T.Columns.Add( new DataColumn("geoappliance", typeof(String)));
	T.Columns.Add( new DataColumn("appliancebasis", typeof(String)));
	C= new DataColumn("taxref", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("maintaxcode", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["taxcode"]};


	//////////////////// ABATEMENT /////////////////////////////////
	T= new DataTable("abatement");
	C= new DataColumn("idabatement", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("evaluatesp", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("evaluationorder", typeof(Int32)));
	C= new DataColumn("flagabatableexpense", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!descrizione", typeof(String)));
	T.Columns.Add( new DataColumn("!franchigia", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!massimale", typeof(Decimal)));
	T.Columns.Add( new DataColumn("!aliquota", typeof(Decimal)));
	T.Columns.Add( new DataColumn("appliance", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idabatement"]};


	//////////////////// ABATEMENTVIEW /////////////////////////////////
	T= new DataTable("abatementview");
	C= new DataColumn("idabatement", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("abatementcode", typeof(String)));
	C= new DataColumn("calculationkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("longdescription", typeof(String)));
	T.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("evaluatesp", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("evaluationorder", typeof(Int32)));
	T.Columns.Add( new DataColumn("abatementtitle", typeof(String)));
	T.Columns.Add( new DataColumn("exemption", typeof(Decimal)));
	T.Columns.Add( new DataColumn("maximal", typeof(Decimal)));
	T.Columns.Add( new DataColumn("rate", typeof(Decimal)));
	T.Columns.Add( new DataColumn("appliance", typeof(String)));
	T.Columns.Add( new DataColumn("flagabatableexpense", typeof(String)));
	T.Columns.Add( new DataColumn("taxref", typeof(String)));
	Tables.Add(T);

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{tax.Columns["taxcode"]};
	CChild = new DataColumn[1]{abatement.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxabatement",CPar,CChild,false));

	CPar = new DataColumn[1]{abatement.Columns["idabatement"]};
	CChild = new DataColumn[1]{abatementcode.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementabatementcode",CPar,CChild,false));

	#endregion

}
}
}
