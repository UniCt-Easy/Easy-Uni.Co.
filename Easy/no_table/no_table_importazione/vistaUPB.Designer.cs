
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
namespace notable_importazione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaUPB"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaUPB: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable division 		=> Tables["division"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriter 		=> Tables["underwriter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epupbkind 		=> Tables["epupbkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbyear 		=> Tables["upbyear"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaUPB(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaUPB (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaUPB";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaUPB.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	tmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// DIVISION /////////////////////////////////
	var tdivision= new DataTable("division");
	tdivision.Columns.Add( new DataColumn("address", typeof(string)));
	tdivision.Columns.Add( new DataColumn("cap", typeof(string)));
	tdivision.Columns.Add( new DataColumn("city", typeof(string)));
	tdivision.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	tdivision.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tdivision.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("codedivision", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	Tables.Add(tdivision);
	tdivision.PrimaryKey =  new DataColumn[]{tdivision.Columns["iddivision"]};


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
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
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
	tupb.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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
	ttreasurer.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// UNDERWRITER /////////////////////////////////
	var tunderwriter= new DataTable("underwriter");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	C= new DataColumn("idunderwriter", typeof(int));
	C.AllowDBNull=false;
	tunderwriter.Columns.Add(C);
	Tables.Add(tunderwriter);
	tunderwriter.PrimaryKey =  new DataColumn[]{tunderwriter.Columns["idunderwriter"]};


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
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tepupbkind.Columns.Add(C);
	tepupbkind.Columns.Add( new DataColumn("isresource", typeof(string)));
	tepupbkind.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tepupbkind);
	tepupbkind.PrimaryKey =  new DataColumn[]{tepupbkind.Columns["idepupbkind"]};


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


	#endregion


	#region DataRelation creation
	var cPar = new []{treasurer.Columns["idtreasurer"]};
	var cChild = new []{upb.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_treasurer_upb",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{upb.Columns["idman"]};
	Relations.Add(new DataRelation("manager_upb",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upb.Columns["paridupb"]};
	Relations.Add(new DataRelation("upb_upb",cPar,cChild,false));

	cPar = new []{underwriter.Columns["idunderwriter"]};
	cChild = new []{upb.Columns["idunderwriter"]};
	Relations.Add(new DataRelation("underwriter_upb",cPar,cChild,false));

	cPar = new []{division.Columns["iddivision"]};
	cChild = new []{manager.Columns["iddivision"]};
	Relations.Add(new DataRelation("division_manager",cPar,cChild,false));

	cPar = new []{epupbkind.Columns["idepupbkind"]};
	cChild = new []{upb.Columns["idepupbkind"]};
	Relations.Add(new DataRelation("epupbkind_upb",cPar,cChild,false));

	cPar = new []{upbyear.Columns["idupb"]};
	cChild = new []{upb.Columns["idupb"]};
	Relations.Add(new DataRelation("upbyear_upb",cPar,cChild,false));

	#endregion

}
}
}
