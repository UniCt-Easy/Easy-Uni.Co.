
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace upbaccountview_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable manager		{get { return Tables["manager"];}}
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account		{get { return Tables["account"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upbaccountview		{get { return Tables["upbaccountview"];}}
	///<summary>
	///Tipo UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable epupbkind		{get { return Tables["epupbkind"];}}
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
	//////////////////// UPB /////////////////////////////////
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("assured", typeof(String)));
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	T.Columns.Add( new DataColumn("granted", typeof(Decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridupb", typeof(String)));
	T.Columns.Add( new DataColumn("previousappropriation", typeof(Decimal)));
	T.Columns.Add( new DataColumn("previousassessment", typeof(Decimal)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("requested", typeof(Decimal)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunderwriter", typeof(Int32)));
	T.Columns.Add( new DataColumn("cupcode", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagactivity", typeof(Int16)));
	T.Columns.Add( new DataColumn("flagkind", typeof(Byte)));
	T.Columns.Add( new DataColumn("newcodeupb", typeof(String)));
	T.Columns.Add( new DataColumn("idtreasurer", typeof(Int32)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	T.Columns.Add( new DataColumn("idepupbkind", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idupb"]};


	//////////////////// MANAGER /////////////////////////////////
	T= new DataTable("manager");
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("passwordweb", typeof(String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("userweb", typeof(String)));
	C= new DataColumn("idman", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("wantswarn", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("newidman", typeof(Int32)));
	T.Columns.Add( new DataColumn("financeactive", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idman"]};


	//////////////////// ACCOUNT /////////////////////////////////
	T= new DataTable("account");
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagregistry", typeof(String)));
	T.Columns.Add( new DataColumn("flagtransitory", typeof(String)));
	T.Columns.Add( new DataColumn("flagupb", typeof(String)));
	T.Columns.Add( new DataColumn("idaccountkind", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridacc", typeof(String)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idpatrimony", typeof(String)));
	T.Columns.Add( new DataColumn("idplaccount", typeof(String)));
	T.Columns.Add( new DataColumn("flagprofit", typeof(String)));
	T.Columns.Add( new DataColumn("flagloss", typeof(String)));
	T.Columns.Add( new DataColumn("placcount_sign", typeof(String)));
	T.Columns.Add( new DataColumn("patrimony_sign", typeof(String)));
	T.Columns.Add( new DataColumn("flagcompetency", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc_special", typeof(String)));
	T.Columns.Add( new DataColumn("flagenablebudgetprev", typeof(String)));
	T.Columns.Add( new DataColumn("flagaccountusage", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// UPBACCOUNTVIEW /////////////////////////////////
	T= new DataTable("upbaccountview");
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("account", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("upb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("currentprev", typeof(Decimal)));
	T.Columns.Add( new DataColumn("currentprev2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("currentprev3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("currentprev4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("currentprev5", typeof(Decimal)));
	C= new DataColumn("epexp1", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp1_2", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp1_3", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp1_4", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp1_5", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp2", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp2_2", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp2_3", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp2_4", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("epexp2_5", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("dare", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("avere", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagactivity", typeof(Int16)));
	C= new DataColumn("activity", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagkind", typeof(Byte)));
	C= new DataColumn("kinddidattica", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("kindricerca", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("contabilitaspeciale", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cigcode", typeof(String)));
	T.Columns.Add( new DataColumn("cupcode", typeof(String)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idepupbkind", typeof(Int32)));
	T.Columns.Add( new DataColumn("epupbkind", typeof(String)));
	T.Columns.Add( new DataColumn("flagaccountusage", typeof(Int32)));
	C= new DataColumn("rateiattivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("credit", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("debit", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("cost", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("revenue", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("reserve", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagenablebudgetprev", typeof(String)));
	T.Columns.Add( new DataColumn("flagprofit", typeof(String)));
	T.Columns.Add( new DataColumn("flagloss", typeof(String)));
	T.Columns.Add( new DataColumn("flagcompetency", typeof(String)));
	C= new DataColumn("contoordine", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("isresource", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("available", typeof(Decimal)));
	T.Columns.Add( new DataColumn("sortcode_investimenti", typeof(String)));
	T.Columns.Add( new DataColumn("sortcode_economico", typeof(String)));
	T.Columns.Add( new DataColumn("provision", typeof(String)));
	T.Columns.Add( new DataColumn("flagusable", typeof(String)));
	T.Columns.Add( new DataColumn("epacc1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc1_2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc1_3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc1_4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc1_5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc2_2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc2_3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc2_4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("epacc2_5", typeof(Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"], T.Columns["idupb"]};


	//////////////////// EPUPBKIND /////////////////////////////////
	T= new DataTable("epupbkind");
	C= new DataColumn("idepupbkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("isresource", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idepupbkind"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{epupbkind.Columns["idepupbkind"]};
	CChild = new DataColumn[1]{upbaccountview.Columns["idepupbkind"]};
	Relations.Add(new DataRelation("FK_epupbkind_upbaccountview",CPar,CChild,false));

	CPar = new DataColumn[1]{account.Columns["idacc"]};
	CChild = new DataColumn[1]{upbaccountview.Columns["idacc"]};
	Relations.Add(new DataRelation("FK_account_upbaccountview",CPar,CChild,false));

	CPar = new DataColumn[1]{manager.Columns["idman"]};
	CChild = new DataColumn[1]{upbaccountview.Columns["idman"]};
	Relations.Add(new DataRelation("FK_manager_upbaccountview",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{upbaccountview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_upbaccountview",CPar,CChild,false));

	#endregion

}
}
}
