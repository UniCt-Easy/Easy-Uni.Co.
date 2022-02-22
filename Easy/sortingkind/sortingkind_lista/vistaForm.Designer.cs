
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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace sortingkind_lista {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	///<summary>
	///Gestione del Menu
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable menu 		=> Tables["menu"];

	///<summary>
	///Tabella classificabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortabletable 		=> Tables["sortabletable"];

	///<summary>
	///Applicabilit√† dei tipi classificazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingapplicability 		=> Tables["sortingapplicability"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind1 		=> Tables["sortingkind1"];

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
	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	tsortingkind.Columns.Add( new DataColumn("allowedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS5", typeof(string)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// MENU /////////////////////////////////
	var tmenu= new DataTable("menu");
	C= new DataColumn("idmenu", typeof(int));
	C.AllowDBNull=false;
	tmenu.Columns.Add(C);
	tmenu.Columns.Add( new DataColumn("edittype", typeof(string)));
	tmenu.Columns.Add( new DataColumn("menucode", typeof(string)));
	tmenu.Columns.Add( new DataColumn("metadata", typeof(string)));
	tmenu.Columns.Add( new DataColumn("modal", typeof(string)));
	tmenu.Columns.Add( new DataColumn("ordernumber", typeof(int)));
	tmenu.Columns.Add( new DataColumn("parameter", typeof(string)));
	tmenu.Columns.Add( new DataColumn("paridmenu", typeof(int)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmenu.Columns.Add(C);
	tmenu.Columns.Add( new DataColumn("userid", typeof(string)));
	tmenu.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tmenu.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tmenu);
	tmenu.PrimaryKey =  new DataColumn[]{tmenu.Columns["idmenu"]};


	//////////////////// SORTABLETABLE /////////////////////////////////
	var tsortabletable= new DataTable("sortabletable");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tsortabletable.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortabletable.Columns.Add(C);
	tsortabletable.Columns.Add( new DataColumn("lu", typeof(string)));
	tsortabletable.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tsortabletable);
	tsortabletable.PrimaryKey =  new DataColumn[]{tsortabletable.Columns["tablename"]};


	//////////////////// SORTINGAPPLICABILITY /////////////////////////////////
	var tsortingapplicability= new DataTable("sortingapplicability");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingapplicability.Columns.Add(C);
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicability.Columns.Add(C);
	tsortingapplicability.Columns.Add( new DataColumn("cu", typeof(string)));
	tsortingapplicability.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingapplicability.Columns.Add( new DataColumn("lu", typeof(string)));
	tsortingapplicability.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tsortingapplicability);
	tsortingapplicability.PrimaryKey =  new DataColumn[]{tsortingapplicability.Columns["idsorkind"], tsortingapplicability.Columns["tablename"]};


	//////////////////// SORTINGKIND1 /////////////////////////////////
	var tsortingkind1= new DataTable("sortingkind1");
	tsortingkind1.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	tsortingkind1.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	tsortingkind1.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind1.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	tsortingkind1.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind1.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind1.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	Tables.Add(tsortingkind1);
	tsortingkind1.PrimaryKey =  new DataColumn[]{tsortingkind1.Columns["idsorkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingkind.Columns["idsorkind"]};
	var cChild = new []{sortingapplicability.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsortingapplicability",cPar,cChild,false));

	cPar = new []{sortabletable.Columns["tablename"]};
	cChild = new []{sortingapplicability.Columns["tablename"]};
	Relations.Add(new DataRelation("sortabletablesortingapplicability",cPar,cChild,false));

	cPar = new []{sortingkind1.Columns["idsorkind"]};
	cChild = new []{sortingkind.Columns["idparentkind"]};
	Relations.Add(new DataRelation("sortingkind_sortingkind1",cPar,cChild,false));

	cPar = new []{incomephase.Columns["nphase"]};
	cChild = new []{sortingkind.Columns["nphaseincome"]};
	Relations.Add(new DataRelation("incomephasesortingkind",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{sortingkind.Columns["nphaseexpense"]};
	Relations.Add(new DataRelation("expensephasesortingkind",cPar,cChild,false));

	#endregion

}
}
}
