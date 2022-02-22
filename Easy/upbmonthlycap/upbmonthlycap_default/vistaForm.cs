
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
namespace upbmonthlycap_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbyear 		=> Tables["upbyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbyearview 		=> Tables["upbyearview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbmonthlycap 		=> Tables["upbmonthlycap"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbmonthlycapview 		=> Tables["upbmonthlycapview"];

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
	tupb.Columns.Add( new DataColumn("flag", typeof(int)));
	tupb.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	tupb.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_ra_quota", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_rb_quota", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_sa_quota", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("idupb_capofila", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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


	//////////////////// UPBYEARVIEW /////////////////////////////////
	var tupbyearview= new DataTable("upbyearview");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("idman", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("manager", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("iddivision", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("codedivision", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("division", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupbyearview.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupbyearview.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("initialprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("incomeinitialprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("currentprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("incomecurrentprevision", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("initialsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("incomeinitialsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("currentsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("incomecurrentsecondaryprev", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("incomeprevavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("expenseprevavailable", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("appropriation", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("assessment", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("payment", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("proceeds", typeof(decimal));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("active", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("activity", typeof(string));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	C= new DataColumn("kindd", typeof(string));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("kindr", typeof(string));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupbyearview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupbyearview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupbyearview.Columns.Add( new DataColumn("epupbkind", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupbyearview.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("revenueprevision", typeof(decimal)));
	tupbyearview.Columns.Add( new DataColumn("costprevision", typeof(decimal)));
	tupbyearview.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	C= new DataColumn("ri_ra_quota", typeof(int));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("ri_rb_quota", typeof(int));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	C= new DataColumn("ri_sa_quota", typeof(int));
	C.ReadOnly=true;
	tupbyearview.Columns.Add(C);
	tupbyearview.Columns.Add( new DataColumn("idupb_capofila", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("codeupb_capofila", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("upb_capofila", typeof(string)));
	tupbyearview.Columns.Add( new DataColumn("locked", typeof(int)));
	Tables.Add(tupbyearview);
	tupbyearview.PrimaryKey =  new DataColumn[]{tupbyearview.Columns["idupb"], tupbyearview.Columns["ayear"]};


	//////////////////// UPBMONTHLYCAP /////////////////////////////////
	var tupbmonthlycap= new DataTable("upbmonthlycap");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tupbmonthlycap.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbmonthlycap.Columns.Add(C);
	tupbmonthlycap.Columns.Add( new DataColumn("amount_1", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_2", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_3", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_4", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_5", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_6", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_7", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_8", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_9", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_10", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_11", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_12", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("amount_reserve", typeof(decimal)));
	tupbmonthlycap.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tupbmonthlycap.Columns.Add( new DataColumn("lu", typeof(string)));
	tupbmonthlycap.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tupbmonthlycap.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tupbmonthlycap);
	tupbmonthlycap.PrimaryKey =  new DataColumn[]{tupbmonthlycap.Columns["ayear"], tupbmonthlycap.Columns["idupb"]};


	//////////////////// UPBMONTHLYCAPVIEW /////////////////////////////////
	var tupbmonthlycapview= new DataTable("upbmonthlycapview");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbmonthlycapview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tupbmonthlycapview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupbmonthlycapview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tupbmonthlycapview.Columns.Add(C);
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_1", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_2", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_3", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_4", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_5", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_6", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_7", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_8", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_9", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_10", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_11", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_12", typeof(decimal)));
	tupbmonthlycapview.Columns.Add( new DataColumn("amount_reserve", typeof(decimal)));
	Tables.Add(tupbmonthlycapview);
	tupbmonthlycapview.PrimaryKey =  new DataColumn[]{tupbmonthlycapview.Columns["idupb"], tupbmonthlycapview.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{upbyear.Columns["idupb"]};
	var cChild = new []{upb.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_upbyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upbmonthlycap.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_upbmonthlycap",cPar,cChild,false));

	cPar = new []{upbyearview.Columns["idupb"], upbyearview.Columns["ayear"]};
	cChild = new []{upbmonthlycap.Columns["idupb"], upbmonthlycap.Columns["ayear"]};
	Relations.Add(new DataRelation("upbyearview_upbmonthlycap",cPar,cChild,false));

	#endregion

}
}
}
