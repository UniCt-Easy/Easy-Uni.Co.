/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaAccountVar")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaAccountVar: DataSet {

	#region Table members declaration
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account		{get { return Tables["account"];}}
	///<summary>
	///variazione di budget
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accountvar		{get { return Tables["accountvar"];}}
	///<summary>
	///Dettaglio variazione di Budget
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accountvardetail		{get { return Tables["accountvardetail"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaAccountVar(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaAccountVar (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaAccountVar";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaAccountVar.xsd";
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


	//////////////////// ACCOUNTVAR /////////////////////////////////
	T= new DataTable("accountvar");
	C= new DataColumn("yvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("enactment", typeof(String)));
	T.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idaccountvarstatus", typeof(Int32)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nenactment", typeof(String)));
	T.Columns.Add( new DataColumn("reason", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("variationkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idenactment", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["yvar"], T.Columns["nvar"]};


	//////////////////// ACCOUNTVARDETAIL /////////////////////////////////
	T= new DataTable("accountvardetail");
	C= new DataColumn("nvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yvar", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("rownum", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor1", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcostpartition", typeof(Int32)));
	T.Columns.Add( new DataColumn("underwritingkind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nvar"], T.Columns["yvar"], T.Columns["rownum"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{account.Columns["idacc"]};
	CChild = new DataColumn[1]{accountvardetail.Columns["idacc"]};
	Relations.Add(new DataRelation("account_accountvardetail",CPar,CChild,false));

	CPar = new DataColumn[2]{accountvar.Columns["yvar"], accountvar.Columns["nvar"]};
	CChild = new DataColumn[2]{accountvardetail.Columns["yvar"], accountvardetail.Columns["nvar"]};
	Relations.Add(new DataRelation("accountvar_accountvardetail",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{accountvardetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_accountvardetail",CPar,CChild,false));

	#endregion

}
}
}
