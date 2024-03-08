
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
namespace autoincomesorting_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione classificazioni automatiche movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable autoincomesorting 		=> Tables["autoincomesorting"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable autoincomesortingview 		=> Tables["autoincomesortingview"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable classmovimenti1 		=> Tables["classmovimenti1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingapplicabilityview 		=> Tables["sortingapplicabilityview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

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
	//////////////////// AUTOINCOMESORTING /////////////////////////////////
	var tautoincomesorting= new DataTable("autoincomesorting");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("idfin", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsor", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("numerator", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("denominator", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn1", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn2", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn3", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn4", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn5", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv1", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv2", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv3", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv4", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv5", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("cu", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tautoincomesorting.Columns.Add( new DataColumn("lu", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tautoincomesorting.Columns.Add( new DataColumn("idman", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idupb", typeof(string)));
	Tables.Add(tautoincomesorting);
	tautoincomesorting.PrimaryKey =  new DataColumn[]{tautoincomesorting.Columns["ayear"], tautoincomesorting.Columns["idautosort"]};


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
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


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


	//////////////////// AUTOINCOMESORTINGVIEW /////////////////////////////////
	var tautoincomesortingview= new DataTable("autoincomesortingview");
	tautoincomesortingview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("finance", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("upb", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("regsortingkind", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("registrysortcode", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("idman", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("manager", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("sortingkind", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("sortingcode", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("sorting", typeof(string)));
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tautoincomesortingview.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tautoincomesortingview.Columns.Add(C);
	tautoincomesortingview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("codesorkindreg", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("codesorkind", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("idsor", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("numerator", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("denominator", typeof(int)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaultn1", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaultn2", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaultn3", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaultn4", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaultn5", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("cu", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tautoincomesortingview.Columns.Add( new DataColumn("lu", typeof(string)));
	tautoincomesortingview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tautoincomesortingview);
	tautoincomesortingview.PrimaryKey =  new DataColumn[]{tautoincomesortingview.Columns["ayear"], tautoincomesortingview.Columns["idautosort"]};


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
	C= new DataColumn("nlevel", typeof(byte));
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
	tclassmovimenti1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	tclassmovimenti1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tclassmovimenti1.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tclassmovimenti1);
	tclassmovimenti1.PrimaryKey =  new DataColumn[]{tclassmovimenti1.Columns["idsor"]};


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
	tsortingapplicabilityview.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tsortingapplicabilityview);
	tsortingapplicabilityview.PrimaryKey =  new DataColumn[]{tsortingapplicabilityview.Columns["idsorkind"]};


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
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


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
	tsortingkind1.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind1.Columns.Add(C);
	tsortingkind1.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedn1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedn1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedn2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedn2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedn3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedn3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedn4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedn4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedn5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedn5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockeds1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forceds1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockeds2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forceds2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockeds3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forceds3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockeds4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forceds4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockeds5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forceds5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind1.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind1.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind1.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tsortingkind1);
	tsortingkind1.PrimaryKey =  new DataColumn[]{tsortingkind1.Columns["idsorkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingkind1.Columns["idsorkind"]};
	var cChild = new []{classmovimenti1.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkind1_classmovimenti1",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsorting",cPar,cChild,false));

	cPar = new []{classmovimenti1.Columns["idsor"], classmovimenti1.Columns["idsorkind"]};
	cChild = new []{autoincomesorting.Columns["idsorreg"], autoincomesorting.Columns["idsorkindreg"]};
	Relations.Add(new DataRelation("FK_classmovimenti1_autoincomesorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{autoincomesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingautoincomesorting",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{autoincomesorting.Columns["idupb"]};
	Relations.Add(new DataRelation("upbautoincomesorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{autoincomesorting.Columns["idfin"]};
	Relations.Add(new DataRelation("finautoincomesorting",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{autoincomesorting.Columns["idman"]};
	Relations.Add(new DataRelation("managerautoincomesorting",cPar,cChild,false));

	#endregion

}
}
}
