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
namespace epupbkind_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable epupbkind		{get { return Tables["epupbkind"];}}
	///<summary>
	///Tipo EP dell' upb, informazioni annuali su UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable epupbkindyear		{get { return Tables["epupbkindyear"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account_cost		{get { return Tables["account_cost"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account_revenue		{get { return Tables["account_revenue"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account_risconto		{get { return Tables["account_risconto"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account_rateo		{get { return Tables["account_rateo"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable account_riserva		{get { return Tables["account_riserva"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotive_cost		{get { return Tables["accmotive_cost"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotive_revenue		{get { return Tables["accmotive_revenue"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotive_accruals		{get { return Tables["accmotive_accruals"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotive_deferredcost		{get { return Tables["accmotive_deferredcost"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable accmotive_reserve		{get { return Tables["accmotive_reserve"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable epupbkindview		{get { return Tables["epupbkindview"];}}
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


	//////////////////// EPUPBKINDYEAR /////////////////////////////////
	T= new DataTable("epupbkindyear");
	C= new DataColumn("idepupbkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idacc_cost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_accruals", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("adjustmentkind", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_accruals", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idepupbkind"], T.Columns["ayear"]};


	//////////////////// ACCOUNT_COST /////////////////////////////////
	T= new DataTable("account_cost");
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// ACCOUNT_REVENUE /////////////////////////////////
	T= new DataTable("account_revenue");
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// ACCOUNT_RISCONTO /////////////////////////////////
	T= new DataTable("account_risconto");
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// ACCOUNT_RATEO /////////////////////////////////
	T= new DataTable("account_rateo");
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// ACCOUNT_RISERVA /////////////////////////////////
	T= new DataTable("account_riserva");
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
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idacc"]};


	//////////////////// ACCMOTIVE_COST /////////////////////////////////
	T= new DataTable("accmotive_cost");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_REVENUE /////////////////////////////////
	T= new DataTable("accmotive_revenue");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_ACCRUALS /////////////////////////////////
	T= new DataTable("accmotive_accruals");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_DEFERREDCOST /////////////////////////////////
	T= new DataTable("accmotive_deferredcost");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_RESERVE /////////////////////////////////
	T= new DataTable("accmotive_reserve");
	C= new DataColumn("idaccmotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	C= new DataColumn("codemotive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridaccmotive", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdep", typeof(String)));
	T.Columns.Add( new DataColumn("flagamm", typeof(String)));
	T.Columns.Add( new DataColumn("expensekind", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idaccmotive"]};


	//////////////////// EPUPBKINDVIEW /////////////////////////////////
	T= new DataTable("epupbkindview");
	C= new DataColumn("idepupbkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("isresource", typeof(String)));
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idacc_cost", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc_cost", typeof(String)));
	T.Columns.Add( new DataColumn("account_cost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("account_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("account_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_accruals", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc_accruals", typeof(String)));
	T.Columns.Add( new DataColumn("account_accruals", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("codeacc_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("account_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_cost", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_revenue", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_deferredcost", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_accruals", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_accruals", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive_reserve", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("adjustmentkind", typeof(String)));
	T.Columns.Add( new DataColumn("adjustment", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idepupbkind"], T.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{accmotive_revenue.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idaccmotive_revenue"]};
	Relations.Add(new DataRelation("accmotive_revenue_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotive_cost.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("accmotive_cost_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{account_rateo.Columns["idacc"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idacc_accruals"]};
	Relations.Add(new DataRelation("account_rateo_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{account_risconto.Columns["idacc"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idacc_deferredcost"]};
	Relations.Add(new DataRelation("account_risconto_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{account_revenue.Columns["idacc"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idacc_revenue"]};
	Relations.Add(new DataRelation("account_revenue_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{account_cost.Columns["idacc"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idacc_cost"]};
	Relations.Add(new DataRelation("account_cost_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{epupbkind.Columns["idepupbkind"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idepupbkind"]};
	Relations.Add(new DataRelation("epupbkind_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{account_riserva.Columns["idacc"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idacc_reserve"]};
	Relations.Add(new DataRelation("account_riserva_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotive_reserve.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idaccmotive_reserve"]};
	Relations.Add(new DataRelation("accmotive_deferredcost_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotive_accruals.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idaccmotive_accruals"]};
	Relations.Add(new DataRelation("accmotive_rateo_epupbkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{accmotive_deferredcost.Columns["idaccmotive"]};
	CChild = new DataColumn[1]{epupbkindyear.Columns["idaccmotive_deferredcost"]};
	Relations.Add(new DataRelation("accmotive_risconto_epupbkindyear",CPar,CChild,false));

	#endregion

}
}
}
