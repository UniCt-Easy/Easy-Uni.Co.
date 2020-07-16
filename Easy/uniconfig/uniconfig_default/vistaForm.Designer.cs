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
namespace uniconfig_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase_fin 		=> Tables["expensephase_fin"];

	///<summary>
	///Configurazione Pluriennale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable uniconfig 		=> Tables["uniconfig"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase_registry 		=> Tables["expensephase_registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase_fin 		=> Tables["incomephase_fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase_registry 		=> Tables["incomephase_registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind1 		=> Tables["sortingkind1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind2 		=> Tables["sortingkind2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind3 		=> Tables["sortingkind3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind4 		=> Tables["sortingkind4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingapplicabilityview 		=> Tables["sortingapplicabilityview"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind5 		=> Tables["sortingkind5"];

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
	//////////////////// EXPENSEPHASE_FIN /////////////////////////////////
	var texpensephase_fin= new DataTable("expensephase_fin");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase_fin.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase_fin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase_fin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase_fin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase_fin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase_fin.Columns.Add(C);
	Tables.Add(texpensephase_fin);
	texpensephase_fin.PrimaryKey =  new DataColumn[]{texpensephase_fin.Columns["nphase"]};


	//////////////////// UNICONFIG /////////////////////////////////
	var tuniconfig= new DataTable("uniconfig");
	C= new DataColumn("dummykey", typeof(int));
	C.AllowDBNull=false;
	tuniconfig.Columns.Add(C);
	tuniconfig.Columns.Add( new DataColumn("expensefinphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("incomefinphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("expenseregphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("incomeregphase", typeof(byte)));
	C= new DataColumn("flagresearchagency", typeof(string));
	C.AllowDBNull=false;
	tuniconfig.Columns.Add(C);
	tuniconfig.Columns.Add( new DataColumn("idsorkind01", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind02", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind03", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind04", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind05", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("sorkind01asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind02asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind03asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind04asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind05asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("tree_upb_withdescr", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("flag", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("ep360days", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("publicagency", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_provinceoffice", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_number", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_socialcapital", typeof(decimal)));
	tuniconfig.Columns.Add( new DataColumn("rea_partner", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codicepaipa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codiceaoopa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codiceuopa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codicefiscalepa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_closingstatus", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("webprotaddress", typeof(string)));
	Tables.Add(tuniconfig);
	tuniconfig.PrimaryKey =  new DataColumn[]{tuniconfig.Columns["dummykey"]};


	//////////////////// EXPENSEPHASE_REGISTRY /////////////////////////////////
	var texpensephase_registry= new DataTable("expensephase_registry");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase_registry.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase_registry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase_registry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase_registry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase_registry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase_registry.Columns.Add(C);
	Tables.Add(texpensephase_registry);
	texpensephase_registry.PrimaryKey =  new DataColumn[]{texpensephase_registry.Columns["nphase"]};


	//////////////////// INCOMEPHASE_FIN /////////////////////////////////
	var tincomephase_fin= new DataTable("incomephase_fin");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase_fin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase_fin.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase_fin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase_fin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase_fin.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase_fin.Columns.Add(C);
	Tables.Add(tincomephase_fin);
	tincomephase_fin.PrimaryKey =  new DataColumn[]{tincomephase_fin.Columns["nphase"]};


	//////////////////// INCOMEPHASE_REGISTRY /////////////////////////////////
	var tincomephase_registry= new DataTable("incomephase_registry");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase_registry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase_registry.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase_registry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase_registry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase_registry.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase_registry.Columns.Add(C);
	Tables.Add(tincomephase_registry);
	tincomephase_registry.PrimaryKey =  new DataColumn[]{tincomephase_registry.Columns["nphase"]};


	//////////////////// SORTINGKIND1 /////////////////////////////////
	var tsortingkind1= new DataTable("sortingkind1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	tsortingkind1.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind1.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	Tables.Add(tsortingkind1);
	tsortingkind1.PrimaryKey =  new DataColumn[]{tsortingkind1.Columns["idsorkind"]};


	//////////////////// SORTINGKIND2 /////////////////////////////////
	var tsortingkind2= new DataTable("sortingkind2");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind2.Columns.Add(C);
	tsortingkind2.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind2.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	Tables.Add(tsortingkind2);
	tsortingkind2.PrimaryKey =  new DataColumn[]{tsortingkind2.Columns["idsorkind"]};


	//////////////////// SORTINGKIND3 /////////////////////////////////
	var tsortingkind3= new DataTable("sortingkind3");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind3.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind3.Columns.Add(C);
	tsortingkind3.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind3.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	Tables.Add(tsortingkind3);
	tsortingkind3.PrimaryKey =  new DataColumn[]{tsortingkind3.Columns["idsorkind"]};


	//////////////////// SORTINGKIND4 /////////////////////////////////
	var tsortingkind4= new DataTable("sortingkind4");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind4.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind4.Columns.Add(C);
	tsortingkind4.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind4.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	Tables.Add(tsortingkind4);
	tsortingkind4.PrimaryKey =  new DataColumn[]{tsortingkind4.Columns["idsorkind"]};


	//////////////////// SORTINGAPPLICABILITYVIEW /////////////////////////////////
	var tsortingapplicabilityview= new DataTable("sortingapplicabilityview");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	tsortingapplicabilityview.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("incomephase", typeof(string)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("expensephase", typeof(string)));
	C= new DataColumn("flagcheckavailability", typeof(string));
	C.ReadOnly=true;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("flagforced", typeof(string));
	C.ReadOnly=true;
	tsortingapplicabilityview.Columns.Add(C);
	tsortingapplicabilityview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	tsortingapplicabilityview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingapplicabilityview);
	tsortingapplicabilityview.PrimaryKey =  new DataColumn[]{tsortingapplicabilityview.Columns["idsorkind"], tsortingapplicabilityview.Columns["tablename"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// SORTINGKIND5 /////////////////////////////////
	var tsortingkind5= new DataTable("sortingkind5");
	tsortingkind5.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	tsortingkind5.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	tsortingkind5.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind5.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind5.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tsortingkind5.Columns.Add(C);
	tsortingkind5.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind5.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind5.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	Tables.Add(tsortingkind5);
	tsortingkind5.PrimaryKey =  new DataColumn[]{tsortingkind5.Columns["idsorkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{expensephase_fin.Columns["nphase"]};
	var cChild = new []{uniconfig.Columns["expensefinphase"]};
	Relations.Add(new DataRelation("expensephase_fin_uniconfig",cPar,cChild,false));

	cPar = new []{expensephase_registry.Columns["nphase"]};
	cChild = new []{uniconfig.Columns["expenseregphase"]};
	Relations.Add(new DataRelation("expensephase_registry_uniconfig",cPar,cChild,false));

	cPar = new []{incomephase_fin.Columns["nphase"]};
	cChild = new []{uniconfig.Columns["incomefinphase"]};
	Relations.Add(new DataRelation("incomephase_fin_uniconfig",cPar,cChild,false));

	cPar = new []{incomephase_registry.Columns["nphase"]};
	cChild = new []{uniconfig.Columns["incomeregphase"]};
	Relations.Add(new DataRelation("incomephase_registry_uniconfig",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{uniconfig.Columns["idsorkind01"]};
	Relations.Add(new DataRelation("sortingkind_uniconfig",cPar,cChild,false));

	cPar = new []{sortingkind1.Columns["idsorkind"]};
	cChild = new []{uniconfig.Columns["idsorkind02"]};
	Relations.Add(new DataRelation("sortingkind1_uniconfig",cPar,cChild,false));

	cPar = new []{sortingkind2.Columns["idsorkind"]};
	cChild = new []{uniconfig.Columns["idsorkind03"]};
	Relations.Add(new DataRelation("sortingkind2_uniconfig",cPar,cChild,false));

	cPar = new []{sortingkind3.Columns["idsorkind"]};
	cChild = new []{uniconfig.Columns["idsorkind04"]};
	Relations.Add(new DataRelation("sortingkind3_uniconfig",cPar,cChild,false));

	cPar = new []{sortingkind4.Columns["idsorkind"]};
	cChild = new []{uniconfig.Columns["idsorkind05"]};
	Relations.Add(new DataRelation("sortingkind4_uniconfig",cPar,cChild,false));

	#endregion

}
}
}
