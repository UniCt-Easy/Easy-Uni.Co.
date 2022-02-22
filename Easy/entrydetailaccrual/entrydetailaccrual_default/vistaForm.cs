
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
namespace entrydetailaccrual_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Rateo dettaglio scrittura, Ã¨ un collegamento  tra una scrittura ed una precedentemente salvata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetailaccrual 		=> Tables["entrydetailaccrual"];

	///<summary>
	///Tipo scrittura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrykind 		=> Tables["entrykind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrykind_linked 		=> Tables["entrykind_linked"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetailview 		=> Tables["entrydetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetailview_linked 		=> Tables["entrydetailview_linked"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetailaccrualview 		=> Tables["entrydetailaccrualview"];

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
	//////////////////// ENTRYDETAILACCRUAL /////////////////////////////////
	var tentrydetailaccrual= new DataTable("entrydetailaccrual");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	C= new DataColumn("idaccrual", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	tentrydetailaccrual.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tentrydetailaccrual.Columns.Add( new DataColumn("yentrylinked", typeof(short)));
	tentrydetailaccrual.Columns.Add( new DataColumn("nentrylinked", typeof(int)));
	tentrydetailaccrual.Columns.Add( new DataColumn("ndetaillinked", typeof(int)));
	Tables.Add(tentrydetailaccrual);
	tentrydetailaccrual.PrimaryKey =  new DataColumn[]{tentrydetailaccrual.Columns["yentry"], tentrydetailaccrual.Columns["nentry"], tentrydetailaccrual.Columns["ndetail"], tentrydetailaccrual.Columns["idaccrual"]};


	//////////////////// ENTRYKIND /////////////////////////////////
	var tentrykind= new DataTable("entrykind");
	C= new DataColumn("identrykind", typeof(int));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	Tables.Add(tentrykind);
	tentrykind.PrimaryKey =  new DataColumn[]{tentrykind.Columns["identrykind"]};


	//////////////////// ENTRYKIND_LINKED /////////////////////////////////
	var tentrykind_linked= new DataTable("entrykind_linked");
	C= new DataColumn("identrykind", typeof(int));
	C.AllowDBNull=false;
	tentrykind_linked.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentrykind_linked.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrykind_linked.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrykind_linked.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tentrykind_linked.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrykind_linked.Columns.Add(C);
	Tables.Add(tentrykind_linked);
	tentrykind_linked.PrimaryKey =  new DataColumn[]{tentrykind_linked.Columns["identrykind"]};


	//////////////////// ENTRYDETAILVIEW /////////////////////////////////
	var tentrydetailview= new DataTable("entrydetailview");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("give", typeof(decimal));
	C.ReadOnly=true;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("have", typeof(decimal));
	C.ReadOnly=true;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("account", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("registry", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("upb", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("flagupb", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("doc", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("accmotive", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("identrykind", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tentrydetailview);
	tentrydetailview.PrimaryKey =  new DataColumn[]{tentrydetailview.Columns["yentry"], tentrydetailview.Columns["nentry"], tentrydetailview.Columns["ndetail"]};


	//////////////////// ENTRYDETAILVIEW_LINKED /////////////////////////////////
	var tentrydetailview_linked= new DataTable("entrydetailview_linked");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	tentrydetailview_linked.Columns.Add( new DataColumn("idreg", typeof(int)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("give", typeof(decimal));
	C.ReadOnly=true;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("have", typeof(decimal));
	C.ReadOnly=true;
	tentrydetailview_linked.Columns.Add(C);
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor1", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor2", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor3", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	tentrydetailview_linked.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tentrydetailview_linked.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("account", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("registry", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("upb", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("flagupb", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailview_linked.Columns.Add(C);
	tentrydetailview_linked.Columns.Add( new DataColumn("doc", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("accmotive", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tentrydetailview_linked.Columns.Add( new DataColumn("identrykind", typeof(int)));
	tentrydetailview_linked.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tentrydetailview_linked.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tentrydetailview_linked.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tentrydetailview_linked);
	tentrydetailview_linked.PrimaryKey =  new DataColumn[]{tentrydetailview_linked.Columns["yentry"], tentrydetailview_linked.Columns["nentry"], tentrydetailview_linked.Columns["ndetail"]};


	//////////////////// ENTRYDETAILACCRUALVIEW /////////////////////////////////
	var tentrydetailaccrualview= new DataTable("entrydetailaccrualview");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	tentrydetailaccrualview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("rateamount", typeof(decimal));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	tentrydetailaccrualview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	tentrydetailaccrualview.Columns.Add( new DataColumn("lu", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("account", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("registry", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("upb", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("flagupb", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("adate", typeof(string));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	C= new DataColumn("doc", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailaccrualview.Columns.Add(C);
	tentrydetailaccrualview.Columns.Add( new DataColumn("docdate", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idaccmotive", typeof(DateTime)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("accmotive", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("identrykind", typeof(int)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("flagap", typeof(string)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tentrydetailaccrualview.Columns.Add( new DataColumn("idepacc", typeof(int)));
	Tables.Add(tentrydetailaccrualview);
	tentrydetailaccrualview.PrimaryKey =  new DataColumn[]{tentrydetailaccrualview.Columns["yentry"], tentrydetailaccrualview.Columns["nentry"], tentrydetailaccrualview.Columns["ndetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{entrykind_linked.Columns["identrykind"]};
	var cChild = new []{entrydetailview_linked.Columns["identrykind"]};
	Relations.Add(new DataRelation("entrykind_linkedentrydetailview_linked",cPar,cChild,false));

	cPar = new []{entrykind.Columns["identrykind"]};
	cChild = new []{entrydetailview.Columns["identrykind"]};
	Relations.Add(new DataRelation("entrykindentrydetailview",cPar,cChild,false));

	cPar = new []{entrydetailview.Columns["yentry"], entrydetailview.Columns["nentry"], entrydetailview.Columns["ndetail"]};
	cChild = new []{entrydetailaccrual.Columns["yentry"], entrydetailaccrual.Columns["nentry"], entrydetailaccrual.Columns["ndetail"]};
	Relations.Add(new DataRelation("entrydetailview_entrydetailaccrual",cPar,cChild,false));

	cPar = new []{entrydetailview_linked.Columns["yentry"], entrydetailview_linked.Columns["nentry"], entrydetailview_linked.Columns["ndetail"]};
	cChild = new []{entrydetailaccrual.Columns["yentrylinked"], entrydetailaccrual.Columns["nentrylinked"], entrydetailaccrual.Columns["ndetaillinked"]};
	Relations.Add(new DataRelation("entrydetailview_linkedentrydetailaccrual",cPar,cChild,false));

	cPar = new []{entrydetailaccrualview.Columns["yentry"], entrydetailaccrualview.Columns["nentry"], entrydetailaccrualview.Columns["ndetail"]};
	cChild = new []{entrydetailaccrual.Columns["yentrylinked"], entrydetailaccrual.Columns["nentrylinked"], entrydetailaccrual.Columns["ndetaillinked"]};
	Relations.Add(new DataRelation("entrydetailaccrualview_entrydetailaccrual",cPar,cChild,false));

	#endregion

}
}
}
