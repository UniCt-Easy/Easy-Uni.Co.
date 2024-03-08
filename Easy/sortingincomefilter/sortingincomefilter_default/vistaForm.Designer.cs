
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
namespace sortingincomefilter_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Configurazione filtro classificazione entrate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingincomefilter 		=> Tables["sortingincomefilter"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingapplicabilityview 		=> Tables["sortingapplicabilityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable classmovimenti1 		=> Tables["classmovimenti1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingincomefilterview 		=> Tables["sortingincomefilterview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

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
	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// SORTINGINCOMEFILTER /////////////////////////////////
	var tsortingincomefilter= new DataTable("sortingincomefilter");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tsortingincomefilter.Columns.Add( new DataColumn("idfin", typeof(int)));
	tsortingincomefilter.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("jointolessspecifics", typeof(string));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("lu", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tsortingincomefilter.Columns.Add( new DataColumn("cu", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingincomefilter.Columns.Add( new DataColumn("idman", typeof(int)));
	Tables.Add(tsortingincomefilter);
	tsortingincomefilter.PrimaryKey =  new DataColumn[]{tsortingincomefilter.Columns["ayear"], tsortingincomefilter.Columns["idautosort"]};


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
	tsortingkind.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// SORTINGAPPLICABILITYVIEW /////////////////////////////////
	var tsortingapplicabilityview= new DataTable("sortingapplicabilityview");
	C= new DataColumn("idsorkind", typeof(int));
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
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("flagforced", typeof(string));
	C.AllowDBNull=false;
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
	tsortingapplicabilityview.PrimaryKey =  new DataColumn[]{tsortingapplicabilityview.Columns["idsorkind"]};


	//////////////////// CLASSMOVIMENTI1 /////////////////////////////////
	var tclassmovimenti1= new DataTable("classmovimenti1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	tclassmovimenti1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	tclassmovimenti1.Columns.Add( new DataColumn("txt", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tclassmovimenti1.Columns.Add(C);
	tclassmovimenti1.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tclassmovimenti1);
	tclassmovimenti1.PrimaryKey =  new DataColumn[]{tclassmovimenti1.Columns["idsor"]};


	//////////////////// SORTINGINCOMEFILTERVIEW /////////////////////////////////
	var tsortingincomefilterview= new DataTable("sortingincomefilterview");
	tsortingincomefilterview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("finance", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("upb", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("regsortingkind", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("registrysortcode", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingincomefilterview.Columns.Add(C);
	tsortingincomefilterview.Columns.Add( new DataColumn("sortingcode", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("sorting", typeof(string)));
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilterview.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilterview.Columns.Add(C);
	tsortingincomefilterview.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tsortingincomefilterview.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tsortingincomefilterview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingincomefilterview.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("jointolessspecifics", typeof(string));
	C.AllowDBNull=false;
	tsortingincomefilterview.Columns.Add(C);
	tsortingincomefilterview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tsortingincomefilterview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilterview.Columns.Add(C);
	tsortingincomefilterview.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	tsortingincomefilterview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tsortingincomefilterview.Columns.Add( new DataColumn("lu", typeof(string)));
	tsortingincomefilterview.Columns.Add( new DataColumn("idman", typeof(int)));
	Tables.Add(tsortingincomefilterview);
	tsortingincomefilterview.PrimaryKey =  new DataColumn[]{tsortingincomefilterview.Columns["ayear"], tsortingincomefilterview.Columns["idautosort"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingkind.Columns["idsorkind"]};
	var cChild = new []{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsorting",cPar,cChild,false));

	cPar = new []{classmovimenti1.Columns["idsor"]};
	cChild = new []{sortingincomefilter.Columns["idsorreg"]};
	Relations.Add(new DataRelation("classmovimenti1sortingincomefilter",cPar,cChild,false));

	cPar = new []{sortingapplicabilityview.Columns["idsorkind"]};
	cChild = new []{sortingincomefilter.Columns["idsorkindreg"]};
	Relations.Add(new DataRelation("sortingapplicabilityviewsortingincomefilter",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{sortingincomefilter.Columns["idman"]};
	Relations.Add(new DataRelation("managersortingincomefilter",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingincomefilter.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingsortingincomefilter",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sortingincomefilter.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsortingincomefilter",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{sortingincomefilter.Columns["idfin"]};
	Relations.Add(new DataRelation("finsortingincomefilter",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{sortingincomefilter.Columns["idupb"]};
	Relations.Add(new DataRelation("upbsortingincomefilter",cPar,cChild,false));

	#endregion

}
}
}
