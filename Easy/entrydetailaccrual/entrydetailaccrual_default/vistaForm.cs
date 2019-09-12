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
namespace entrydetailaccrual_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Rateo dettaglio scrittura, Ã¨ un collegamento  tra una scrittura ed una precedentemente salvata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable entrydetailaccrual		{get { return Tables["entrydetailaccrual"];}}
	///<summary>
	///Tipo scrittura
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable entrykind		{get { return Tables["entrykind"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable entrykind_linked		{get { return Tables["entrykind_linked"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable entrydetailview		{get { return Tables["entrydetailview"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable entrydetailview_linked		{get { return Tables["entrydetailview_linked"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable entrydetailaccrualview		{get { return Tables["entrydetailaccrualview"];}}
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
	//////////////////// ENTRYDETAILACCRUAL /////////////////////////////////
	T= new DataTable("entrydetailaccrual");
	C= new DataColumn("yentry", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nentry", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idaccrual", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("yentrylinked", typeof(Int16)));
	T.Columns.Add( new DataColumn("nentrylinked", typeof(Int32)));
	T.Columns.Add( new DataColumn("ndetaillinked", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yentry"], T.Columns["nentry"], T.Columns["ndetail"], T.Columns["idaccrual"]};


	//////////////////// ENTRYKIND /////////////////////////////////
	T= new DataTable("entrykind");
	C= new DataColumn("identrykind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["identrykind"]};


	//////////////////// ENTRYKIND_LINKED /////////////////////////////////
	T= new DataTable("entrykind_linked");
	C= new DataColumn("identrykind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["identrykind"]};


	//////////////////// ENTRYDETAILVIEW /////////////////////////////////
	T= new DataTable("entrydetailview");
	C= new DataColumn("yentry", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nentry", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("amount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("give", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("have", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc", typeof(String)));
	T.Columns.Add( new DataColumn("account", typeof(String)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("upb", typeof(String)));
	T.Columns.Add( new DataColumn("idaccountkind", typeof(String)));
	T.Columns.Add( new DataColumn("flagregistry", typeof(String)));
	T.Columns.Add( new DataColumn("flagupb", typeof(String)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("accmotive", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive", typeof(String)));
	T.Columns.Add( new DataColumn("identrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yentry"], T.Columns["nentry"], T.Columns["ndetail"]};


	//////////////////// ENTRYDETAILVIEW_LINKED /////////////////////////////////
	T= new DataTable("entrydetailview_linked");
	C= new DataColumn("yentry", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nentry", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("amount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("give", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("have", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor1", typeof(String)));
	T.Columns.Add( new DataColumn("idsor2", typeof(String)));
	T.Columns.Add( new DataColumn("idsor3", typeof(String)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc", typeof(String)));
	T.Columns.Add( new DataColumn("account", typeof(String)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("upb", typeof(String)));
	T.Columns.Add( new DataColumn("idaccountkind", typeof(String)));
	T.Columns.Add( new DataColumn("flagregistry", typeof(String)));
	T.Columns.Add( new DataColumn("flagupb", typeof(String)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("accmotive", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive", typeof(String)));
	T.Columns.Add( new DataColumn("identrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yentry"], T.Columns["nentry"], T.Columns["ndetail"]};


	//////////////////// ENTRYDETAILACCRUALVIEW /////////////////////////////////
	T= new DataTable("entrydetailaccrualview");
	C= new DataColumn("yentry", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nentry", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	C= new DataColumn("amount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rateamount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("available", typeof(Decimal)));
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	C= new DataColumn("ct", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lu", typeof(DateTime)));
	T.Columns.Add( new DataColumn("codeupb", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc", typeof(String)));
	T.Columns.Add( new DataColumn("account", typeof(String)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("upb", typeof(String)));
	T.Columns.Add( new DataColumn("idaccountkind", typeof(String)));
	T.Columns.Add( new DataColumn("flagregistry", typeof(String)));
	T.Columns.Add( new DataColumn("flagupb", typeof(String)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	C= new DataColumn("adate", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("doc", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("docdate", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(DateTime)));
	T.Columns.Add( new DataColumn("accmotive", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive", typeof(String)));
	T.Columns.Add( new DataColumn("identrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	T.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("flagap", typeof(String)));
	T.Columns.Add( new DataColumn("idepexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("idepacc", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yentry"], T.Columns["nentry"], T.Columns["ndetail"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{entrykind_linked.Columns["identrykind"]};
	CChild = new DataColumn[1]{entrydetailview_linked.Columns["identrykind"]};
	Relations.Add(new DataRelation("entrykind_linkedentrydetailview_linked",CPar,CChild,false));

	CPar = new DataColumn[1]{entrykind.Columns["identrykind"]};
	CChild = new DataColumn[1]{entrydetailview.Columns["identrykind"]};
	Relations.Add(new DataRelation("entrykindentrydetailview",CPar,CChild,false));

	CPar = new DataColumn[3]{entrydetailview.Columns["yentry"], entrydetailview.Columns["nentry"], entrydetailview.Columns["ndetail"]};
	CChild = new DataColumn[3]{entrydetailaccrual.Columns["yentry"], entrydetailaccrual.Columns["nentry"], entrydetailaccrual.Columns["ndetail"]};
	Relations.Add(new DataRelation("entrydetailview_entrydetailaccrual",CPar,CChild,false));

	CPar = new DataColumn[3]{entrydetailview_linked.Columns["yentry"], entrydetailview_linked.Columns["nentry"], entrydetailview_linked.Columns["ndetail"]};
	CChild = new DataColumn[3]{entrydetailaccrual.Columns["yentrylinked"], entrydetailaccrual.Columns["nentrylinked"], entrydetailaccrual.Columns["ndetaillinked"]};
	Relations.Add(new DataRelation("entrydetailview_linkedentrydetailaccrual",CPar,CChild,false));

	CPar = new DataColumn[3]{entrydetailaccrualview.Columns["yentry"], entrydetailaccrualview.Columns["nentry"], entrydetailaccrualview.Columns["ndetail"]};
	CChild = new DataColumn[3]{entrydetailaccrual.Columns["yentrylinked"], entrydetailaccrual.Columns["nentrylinked"], entrydetailaccrual.Columns["ndetaillinked"]};
	Relations.Add(new DataRelation("entrydetailaccrualview_entrydetailaccrual",CPar,CChild,false));

	#endregion

}
}
}
