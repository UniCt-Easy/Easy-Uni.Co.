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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace accmotive_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	///<summary>
	///Dettaglio causale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotivedetail 		=> Tables["accmotivedetail"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotivedetailview 		=> Tables["accmotivedetailview"];

	///<summary>
	///Operazione EP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epoperation 		=> Tables["epoperation"];

	///<summary>
	///Associazione causale contabile - operazione EP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveepoperation 		=> Tables["accmotiveepoperation"];

	///<summary>
	///Classificazione causale E/P
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotivesorting 		=> Tables["accmotivesorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

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
	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new DataTable("accmotive");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("expensekind", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flag", typeof(byte)));
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEDETAIL /////////////////////////////////
	var taccmotivedetail= new DataTable("accmotivedetail");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotivedetail.Columns.Add(C);
	taccmotivedetail.Columns.Add( new DataColumn("!codiceconto", typeof(string)));
	taccmotivedetail.Columns.Add( new DataColumn("!conto", typeof(string)));
	Tables.Add(taccmotivedetail);
	taccmotivedetail.PrimaryKey =  new DataColumn[]{taccmotivedetail.Columns["idaccmotive"], taccmotivedetail.Columns["idacc"], taccmotivedetail.Columns["ayear"]};


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// ACCMOTIVEDETAILVIEW /////////////////////////////////
	var taccmotivedetailview= new DataTable("accmotivedetailview");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccmotivedetailview.Columns.Add(C);
	taccmotivedetailview.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccmotivedetailview.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccmotivedetailview.Columns.Add( new DataColumn("flagupb", typeof(string)));
	Tables.Add(taccmotivedetailview);
	taccmotivedetailview.PrimaryKey =  new DataColumn[]{taccmotivedetailview.Columns["idaccmotive"], taccmotivedetailview.Columns["idacc"]};


	//////////////////// EPOPERATION /////////////////////////////////
	var tepoperation= new DataTable("epoperation");
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	tepoperation.Columns.Add(C);
	tepoperation.Columns.Add( new DataColumn("title", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepoperation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepoperation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepoperation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepoperation.Columns.Add(C);
	Tables.Add(tepoperation);
	tepoperation.PrimaryKey =  new DataColumn[]{tepoperation.Columns["idepoperation"]};


	//////////////////// ACCMOTIVEEPOPERATION /////////////////////////////////
	var taccmotiveepoperation= new DataTable("accmotiveepoperation");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveepoperation.Columns.Add(C);
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveepoperation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveepoperation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveepoperation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveepoperation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveepoperation.Columns.Add(C);
	Tables.Add(taccmotiveepoperation);
	taccmotiveepoperation.PrimaryKey =  new DataColumn[]{taccmotiveepoperation.Columns["idaccmotive"], taccmotiveepoperation.Columns["idepoperation"]};


	//////////////////// ACCMOTIVESORTING /////////////////////////////////
	var taccmotivesorting= new DataTable("accmotivesorting");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotivesorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	taccmotivesorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotivesorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotivesorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotivesorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotivesorting.Columns.Add(C);
	taccmotivesorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	taccmotivesorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	taccmotivesorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	Tables.Add(taccmotivesorting);
	taccmotivesorting.PrimaryKey =  new DataColumn[]{taccmotivesorting.Columns["idaccmotive"], taccmotivesorting.Columns["idsor"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingview.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingview.Columns["idsor"]};
	var cChild = new []{accmotivesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_accmotivesorting",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{accmotivesorting.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotive_accmotivesorting",cPar,cChild,false));

	cPar = new []{epoperation.Columns["idepoperation"]};
	cChild = new []{accmotiveepoperation.Columns["idepoperation"]};
	Relations.Add(new DataRelation("epoperationaccmotiveepoperation",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{accmotiveepoperation.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveaccmotiveepoperation",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{accmotivedetail.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveaccmotivedetail",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{accmotivedetail.Columns["idacc"]};
	Relations.Add(new DataRelation("accountaccmotivedetail",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{accmotive.Columns["paridaccmotive"]};
	Relations.Add(new DataRelation("accmotiveaccmotive",cPar,cChild,false));

	#endregion

}
}
}
