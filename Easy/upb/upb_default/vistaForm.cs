
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
namespace upb_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriter 		=> Tables["underwriter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbsorting 		=> Tables["upbsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable codicecofogmp 		=> Tables["codicecofogmp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable autoexpensesorting 		=> Tables["autoexpensesorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingexpensefilter 		=> Tables["sortingexpensefilter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finyearview 		=> Tables["finyearview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable autoincomesorting 		=> Tables["autoincomesorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingincomefilter 		=> Tables["sortingincomefilter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvardetailview 		=> Tables["finvardetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbsortingview 		=> Tables["upbsortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountyearview 		=> Tables["accountyearview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountvardetailview 		=> Tables["accountvardetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountprevisionview 		=> Tables["accountprevisionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epupbkind 		=> Tables["epupbkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbprofitpartition 		=> Tables["upbprofitpartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_dest 		=> Tables["upb_dest"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbattachment 		=> Tables["upbattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbyear 		=> Tables["upbyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb_capofila 		=> Tables["upb_capofila"];

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
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// UNDERWRITER /////////////////////////////////
	var tunderwriter= new DataTable("underwriter");
	C= new DataColumn("idunderwriter", typeof(int));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	Tables.Add(tunderwriter);
	tunderwriter.PrimaryKey =  new DataColumn[]{tunderwriter.Columns["idunderwriter"]};


	//////////////////// UPBSORTING /////////////////////////////////
	var tupbsorting= new DataTable("upbsorting");
	tupbsorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tupbsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tupbsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tupbsorting.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbsorting.Columns.Add(C);
	tupbsorting.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupbsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupbsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupbsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupbsorting.Columns.Add(C);
	Tables.Add(tupbsorting);
	tupbsorting.PrimaryKey =  new DataColumn[]{tupbsorting.Columns["idsor"], tupbsorting.Columns["idupb"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	Tables.Add(tfinview);

	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb.Columns.Add( new DataColumn("flag", typeof(int)));
	tupb.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	tupb.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idupb_capofila", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// CODICECOFOGMP /////////////////////////////////
	var tcodicecofogmp= new DataTable("codicecofogmp");
	C= new DataColumn("codice", typeof(string));
	C.AllowDBNull=false;
	tcodicecofogmp.Columns.Add(C);
	tcodicecofogmp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(tcodicecofogmp);

	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// AUTOEXPENSESORTING /////////////////////////////////
	var tautoexpensesorting= new DataTable("autoexpensesorting");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	tautoexpensesorting.Columns.Add( new DataColumn("idfin", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	tautoexpensesorting.Columns.Add( new DataColumn("idsor", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("numerator", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("denominator", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn1", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn2", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn3", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn4", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn5", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv1", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv2", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv3", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv4", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv5", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("cu", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tautoexpensesorting.Columns.Add( new DataColumn("lu", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tautoexpensesorting.Columns.Add( new DataColumn("idman", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("!sorting", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("!frazione", typeof(string)));
	Tables.Add(tautoexpensesorting);
	tautoexpensesorting.PrimaryKey =  new DataColumn[]{tautoexpensesorting.Columns["ayear"], tautoexpensesorting.Columns["idautosort"], tautoexpensesorting.Columns["idupb"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// SORTINGEXPENSEFILTER /////////////////////////////////
	var tsortingexpensefilter= new DataTable("sortingexpensefilter");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingexpensefilter.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	C= new DataColumn("jointolessspecifics", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tsortingexpensefilter.Columns.Add( new DataColumn("lu", typeof(string)));
	tsortingexpensefilter.Columns.Add( new DataColumn("idfin", typeof(int)));
	tsortingexpensefilter.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tsortingexpensefilter.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tsortingexpensefilter.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tsortingexpensefilter.Columns.Add( new DataColumn("!sorting", typeof(string)));
	Tables.Add(tsortingexpensefilter);
	tsortingexpensefilter.PrimaryKey =  new DataColumn[]{tsortingexpensefilter.Columns["ayear"], tsortingexpensefilter.Columns["idautosort"], tsortingexpensefilter.Columns["idupb"]};


	//////////////////// FINYEARVIEW /////////////////////////////////
	var tfinyearview= new DataTable("finyearview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("finance", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("nlevel", typeof(byte)));
	tfinyearview.Columns.Add( new DataColumn("leveldescr", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("upb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	Tables.Add(tfinyearview);
	tfinyearview.PrimaryKey =  new DataColumn[]{tfinyearview.Columns["idfin"], tfinyearview.Columns["idupb"]};


	//////////////////// AUTOINCOMESORTING /////////////////////////////////
	var tautoincomesorting= new DataTable("autoincomesorting");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tautoincomesorting.Columns.Add( new DataColumn("cu", typeof(string)));
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
	tautoincomesorting.Columns.Add( new DataColumn("denominator", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tautoincomesorting.Columns.Add( new DataColumn("lu", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("numerator", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idfin", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idman", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsor", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("!sorting", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("!frazione", typeof(string)));
	Tables.Add(tautoincomesorting);
	tautoincomesorting.PrimaryKey =  new DataColumn[]{tautoincomesorting.Columns["ayear"], tautoincomesorting.Columns["idautosort"], tautoincomesorting.Columns["idupb"]};


	//////////////////// SORTINGINCOMEFILTER /////////////////////////////////
	var tsortingincomefilter= new DataTable("sortingincomefilter");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingincomefilter.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	C= new DataColumn("jointolessspecifics", typeof(string));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tsortingincomefilter.Columns.Add( new DataColumn("lu", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("idfin", typeof(int)));
	tsortingincomefilter.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tsortingincomefilter.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("!sorting", typeof(string)));
	Tables.Add(tsortingincomefilter);
	tsortingincomefilter.PrimaryKey =  new DataColumn[]{tsortingincomefilter.Columns["ayear"], tsortingincomefilter.Columns["idautosort"], tsortingincomefilter.Columns["idupb"]};


	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new DataTable("treasurer");
	ttreasurer.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("agencycodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cabcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("depcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("description", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_payment", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcab", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	C= new DataColumn("codetreasurer", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("spexportexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagmultiexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("fileextension", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("spexportinc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("iban", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("bic", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cccbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cincbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbankcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcabcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ibancbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("siacodecbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("reccbikind", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("trasmcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("motivelen", typeof(short)));
	ttreasurer.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagedisp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor05", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("billcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// FINVARDETAILVIEW /////////////////////////////////
	var tfinvardetailview= new DataTable("finvardetailview");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationdescription", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idenactment", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("enactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	C= new DataColumn("variationkind", typeof(byte));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationkinddescr", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagprevision", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagcredit", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagproceeds", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagsecondaryprev", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("official", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nofficial", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentnumber", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("manager", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idfinvarstatus", typeof(short)));
	tfinvardetailview.Columns.Add( new DataColumn("finvarstatus", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idlcard", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("createexpense", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("phase", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("activity", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	C= new DataColumn("kindd", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("kindr", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("!prev_competenza", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("!prev_cassa", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("!crediti", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("!cassa", typeof(decimal)));
	Tables.Add(tfinvardetailview);

	//////////////////// UPBSORTINGVIEW /////////////////////////////////
	var tupbsortingview= new DataTable("upbsortingview");
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("sorting", typeof(string));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	tupbsortingview.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupbsortingview.Columns.Add(C);
	Tables.Add(tupbsortingview);
	tupbsortingview.PrimaryKey =  new DataColumn[]{tupbsortingview.Columns["idsor"], tupbsortingview.Columns["idupb"]};


	//////////////////// ACCOUNTYEARVIEW /////////////////////////////////
	var taccountyearview= new DataTable("accountyearview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	taccountyearview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("account", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	taccountyearview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("upb", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("paridacc", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("nlevel", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("leveldescr", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountyearview.Columns.Add(C);
	taccountyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	Tables.Add(taccountyearview);
	taccountyearview.PrimaryKey =  new DataColumn[]{taccountyearview.Columns["idupb"], taccountyearview.Columns["idacc"]};


	//////////////////// ACCOUNTVARDETAILVIEW /////////////////////////////////
	var taccountvardetailview= new DataTable("accountvardetailview");
	C= new DataColumn("yvar", typeof(int));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("variationdescription", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	taccountvardetailview.Columns.Add( new DataColumn("enactment", typeof(string)));
	taccountvardetailview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	taccountvardetailview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	taccountvardetailview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	taccountvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	taccountvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	taccountvardetailview.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	taccountvardetailview.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	taccountvardetailview.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	taccountvardetailview.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	taccountvardetailview.Columns.Add( new DataColumn("idaccountvarstatus", typeof(int)));
	taccountvardetailview.Columns.Add( new DataColumn("accountvarstatus", typeof(string)));
	C= new DataColumn("variationkind", typeof(int));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("variationkinddescr", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	taccountvardetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	taccountvardetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	taccountvardetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	taccountvardetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	taccountvardetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	taccountvardetailview.Columns.Add( new DataColumn("annotation", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
	Tables.Add(taccountvardetailview);
	taccountvardetailview.PrimaryKey =  new DataColumn[]{taccountvardetailview.Columns["yvar"], taccountvardetailview.Columns["nvar"], taccountvardetailview.Columns["rownum"]};


	//////////////////// ACCOUNTPREVISIONVIEW /////////////////////////////////
	var taccountprevisionview= new DataTable("accountprevisionview");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	taccountprevisionview.Columns.Add( new DataColumn("paridacc", typeof(string)));
	taccountprevisionview.Columns.Add( new DataColumn("idman", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("currentprevision", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("availableprevision", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("prevision2", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("currentprevision2", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("availableprevision2", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("prevision3", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("currentprevision3", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("availableprevision3", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("prevision4", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("currentprevision4", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("availableprevision4", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("prevision5", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("currentprevision5", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("availableprevision5", typeof(decimal));
	C.ReadOnly=true;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	taccountprevisionview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	taccountprevisionview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	taccountprevisionview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	Tables.Add(taccountprevisionview);
	taccountprevisionview.PrimaryKey =  new DataColumn[]{taccountprevisionview.Columns["idacc"], taccountprevisionview.Columns["idupb"]};


	//////////////////// EPUPBKIND /////////////////////////////////
	var tepupbkind= new DataTable("epupbkind");
	C= new DataColumn("idepupbkind", typeof(int));
	C.AllowDBNull=false;
	tepupbkind.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tepupbkind.Columns.Add(C);
	tepupbkind.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepupbkind.Columns.Add(C);
	tepupbkind.Columns.Add( new DataColumn("cu", typeof(string)));
	tepupbkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tepupbkind.Columns.Add( new DataColumn("lu", typeof(string)));
	tepupbkind.Columns.Add( new DataColumn("active", typeof(string)));
	tepupbkind.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tepupbkind);
	tepupbkind.PrimaryKey =  new DataColumn[]{tepupbkind.Columns["idepupbkind"]};


	//////////////////// UPBPROFITPARTITION /////////////////////////////////
	var tupbprofitpartition= new DataTable("upbprofitpartition");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbprofitpartition.Columns.Add(C);
	C= new DataColumn("idupb_dest", typeof(string));
	C.AllowDBNull=false;
	tupbprofitpartition.Columns.Add(C);
	tupbprofitpartition.Columns.Add( new DataColumn("quota", typeof(double)));
	tupbprofitpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tupbprofitpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tupbprofitpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tupbprofitpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tupbprofitpartition.Columns.Add( new DataColumn("!codeupb_dest", typeof(string)));
	tupbprofitpartition.Columns.Add( new DataColumn("!titleupb_dest", typeof(string)));
	Tables.Add(tupbprofitpartition);
	tupbprofitpartition.PrimaryKey =  new DataColumn[]{tupbprofitpartition.Columns["idupb"], tupbprofitpartition.Columns["idupb_dest"]};


	//////////////////// UPB_DEST /////////////////////////////////
	var tupb_dest= new DataTable("upb_dest");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	tupb_dest.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_dest.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	tupb_dest.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_dest.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	tupb_dest.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_dest.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_dest.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	tupb_dest.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_dest.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_dest.Columns.Add(C);
	tupb_dest.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_dest.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb_dest.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb_dest.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb_dest.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb_dest.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb_dest.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb_dest.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb_dest.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb_dest.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	Tables.Add(tupb_dest);
	tupb_dest.PrimaryKey =  new DataColumn[]{tupb_dest.Columns["idupb"]};


	//////////////////// UPBATTACHMENT /////////////////////////////////
	var tupbattachment= new DataTable("upbattachment");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tupbattachment.Columns.Add(C);
	tupbattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	tupbattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tupbattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tupbattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	tupbattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tupbattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tupbattachment);
	tupbattachment.PrimaryKey =  new DataColumn[]{tupbattachment.Columns["idupb"], tupbattachment.Columns["idattachment"]};


	//////////////////// UPBYEAR /////////////////////////////////
	var tupbyear= new DataTable("upbyear");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tupbyear.Columns.Add(C);
	tupbyear.Columns.Add( new DataColumn("revenueprevision", typeof(decimal)));
	tupbyear.Columns.Add( new DataColumn("costprevision", typeof(decimal)));
	tupbyear.Columns.Add( new DataColumn("locked", typeof(int)));
	tupbyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tupbyear.Columns.Add( new DataColumn("lu", typeof(string)));
	tupbyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tupbyear.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tupbyear);
	tupbyear.PrimaryKey =  new DataColumn[]{tupbyear.Columns["idupb"], tupbyear.Columns["ayear"]};


	//////////////////// UPB_CAPOFILA /////////////////////////////////
	var tupb_capofila= new DataTable("upb_capofila");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	tupb_capofila.Columns.Add( new DataColumn("active", typeof(string)));
	tupb_capofila.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	tupb_capofila.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb_capofila.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	tupb_capofila.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb_capofila.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb_capofila.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	tupb_capofila.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb_capofila.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb_capofila.Columns.Add(C);
	tupb_capofila.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb_capofila.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb_capofila.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb_capofila.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb_capofila.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb_capofila.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb_capofila.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb_capofila.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb_capofila.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb_capofila.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	Tables.Add(tupb_capofila);
	tupb_capofila.PrimaryKey =  new DataColumn[]{tupb_capofila.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{upb.Columns["idupb"]};
	var cChild = new []{upbattachment.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_upbattachment",cPar,cChild,false));

	cPar = new []{upb_dest.Columns["idupb"]};
	cChild = new []{upbprofitpartition.Columns["idupb_dest"]};
	Relations.Add(new DataRelation("upb_dest_upbprofitpartition",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upbprofitpartition.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_upbprofitpartition",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{accountvardetailview.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_accountvardetailview",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{accountyearview.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_accountyearview",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{finvardetailview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_finvardetailview",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingincomefilter.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_sortingincomefilter",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sortingincomefilter.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_sortingkind_sortingincomefilter",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{sortingincomefilter.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_sortingincomefilter",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{autoincomesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_autoincomesorting",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{autoincomesorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_sortingkind_autoincomesorting",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{autoincomesorting.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_autoincomesorting",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{finyearview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_finyearview",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingexpensefilter.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_sortingexpensefilter",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sortingexpensefilter.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_sortingkind_sortingexpensefilter",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{sortingexpensefilter.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_sortingexpensefilter",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{autoexpensesorting.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_autoexpensesorting",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{autoexpensesorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkind_autoexpensesorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{autoexpensesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_autoexpensesorting",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{upb.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_treasurer_upb",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{upb.Columns["idman"]};
	Relations.Add(new DataRelation("managerupb",cPar,cChild,false));

	cPar = new []{underwriter.Columns["idunderwriter"]};
	cChild = new []{upb.Columns["idunderwriter"]};
	Relations.Add(new DataRelation("underwriterupb",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upb.Columns["paridupb"]};
	Relations.Add(new DataRelation("upbupb",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{upb.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting2upb",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{upb.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting1upb",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{upb.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting3upb",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{upb.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting4upb",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{upb.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting5upb",cPar,cChild,false));

	cPar = new []{epupbkind.Columns["idepupbkind"]};
	cChild = new []{upb.Columns["idepupbkind"]};
	Relations.Add(new DataRelation("epupbkind_upb",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{upbsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_upbsorting",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upbsorting.Columns["idupb"]};
	Relations.Add(new DataRelation("upbupbsorting",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upbyear.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_upbyear",cPar,cChild,false));

	cPar = new []{upb_capofila.Columns["idupb"]};
	cChild = new []{upb.Columns["idupb_capofila"]};
	Relations.Add(new DataRelation("upb_capofila_upb",cPar,cChild,false));

	#endregion

}
}
}
