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
namespace epupbkind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epupbkind 		=> Tables["epupbkind"];

	///<summary>
	///Tipo EP dell' upb, informazioni annuali su UPB nell'economico patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epupbkindyear 		=> Tables["epupbkindyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_cost 		=> Tables["account_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_revenue 		=> Tables["account_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_risconto 		=> Tables["account_risconto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_rateo 		=> Tables["account_rateo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_riserva 		=> Tables["account_riserva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive_cost 		=> Tables["accmotive_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive_revenue 		=> Tables["accmotive_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive_accruals 		=> Tables["accmotive_accruals"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive_deferredcost 		=> Tables["accmotive_deferredcost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive_reserve 		=> Tables["accmotive_reserve"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epupbkindview 		=> Tables["epupbkindview"];

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


	//////////////////// EPUPBKINDYEAR /////////////////////////////////
	var tepupbkindyear= new DataTable("epupbkindyear");
	C= new DataColumn("idepupbkind", typeof(int));
	C.AllowDBNull=false;
	tepupbkindyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepupbkindyear.Columns.Add(C);
	tepupbkindyear.Columns.Add( new DataColumn("idacc_cost", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idacc_accruals", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tepupbkindyear.Columns.Add( new DataColumn("cu", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tepupbkindyear.Columns.Add( new DataColumn("lu", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idacc_reserve", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("adjustmentkind", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idaccmotive_revenue", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idaccmotive_deferredcost", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idaccmotive_reserve", typeof(string)));
	tepupbkindyear.Columns.Add( new DataColumn("idaccmotive_accruals", typeof(string)));
	Tables.Add(tepupbkindyear);
	tepupbkindyear.PrimaryKey =  new DataColumn[]{tepupbkindyear.Columns["idepupbkind"], tepupbkindyear.Columns["ayear"]};


	//////////////////// ACCOUNT_COST /////////////////////////////////
	var taccount_cost= new DataTable("account_cost");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_cost.Columns.Add(C);
	taccount_cost.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_cost.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount_cost.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	Tables.Add(taccount_cost);
	taccount_cost.PrimaryKey =  new DataColumn[]{taccount_cost.Columns["idacc"]};


	//////////////////// ACCOUNT_REVENUE /////////////////////////////////
	var taccount_revenue= new DataTable("account_revenue");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_revenue.Columns.Add(C);
	taccount_revenue.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_revenue.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount_revenue.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	Tables.Add(taccount_revenue);
	taccount_revenue.PrimaryKey =  new DataColumn[]{taccount_revenue.Columns["idacc"]};


	//////////////////// ACCOUNT_RISCONTO /////////////////////////////////
	var taccount_risconto= new DataTable("account_risconto");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	taccount_risconto.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	taccount_risconto.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	taccount_risconto.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_risconto.Columns.Add(C);
	taccount_risconto.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_risconto.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount_risconto.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	Tables.Add(taccount_risconto);
	taccount_risconto.PrimaryKey =  new DataColumn[]{taccount_risconto.Columns["idacc"]};


	//////////////////// ACCOUNT_RATEO /////////////////////////////////
	var taccount_rateo= new DataTable("account_rateo");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	taccount_rateo.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	taccount_rateo.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	taccount_rateo.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_rateo.Columns.Add(C);
	taccount_rateo.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_rateo.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount_rateo.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	Tables.Add(taccount_rateo);
	taccount_rateo.PrimaryKey =  new DataColumn[]{taccount_rateo.Columns["idacc"]};


	//////////////////// ACCOUNT_RISERVA /////////////////////////////////
	var taccount_riserva= new DataTable("account_riserva");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	taccount_riserva.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	taccount_riserva.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	taccount_riserva.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_riserva.Columns.Add(C);
	taccount_riserva.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_riserva.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount_riserva.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	Tables.Add(taccount_riserva);
	taccount_riserva.PrimaryKey =  new DataColumn[]{taccount_riserva.Columns["idacc"]};


	//////////////////// ACCMOTIVE_COST /////////////////////////////////
	var taccmotive_cost= new DataTable("accmotive_cost");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	taccmotive_cost.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	taccmotive_cost.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive_cost.Columns.Add(C);
	taccmotive_cost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive_cost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive_cost.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotive_cost);
	taccmotive_cost.PrimaryKey =  new DataColumn[]{taccmotive_cost.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_REVENUE /////////////////////////////////
	var taccmotive_revenue= new DataTable("accmotive_revenue");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	taccmotive_revenue.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	taccmotive_revenue.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive_revenue.Columns.Add(C);
	taccmotive_revenue.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive_revenue.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive_revenue.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotive_revenue);
	taccmotive_revenue.PrimaryKey =  new DataColumn[]{taccmotive_revenue.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_ACCRUALS /////////////////////////////////
	var taccmotive_accruals= new DataTable("accmotive_accruals");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	taccmotive_accruals.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	taccmotive_accruals.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive_accruals.Columns.Add(C);
	taccmotive_accruals.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive_accruals.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive_accruals.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotive_accruals);
	taccmotive_accruals.PrimaryKey =  new DataColumn[]{taccmotive_accruals.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_DEFERREDCOST /////////////////////////////////
	var taccmotive_deferredcost= new DataTable("accmotive_deferredcost");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	taccmotive_deferredcost.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	taccmotive_deferredcost.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive_deferredcost.Columns.Add(C);
	taccmotive_deferredcost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive_deferredcost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive_deferredcost.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotive_deferredcost);
	taccmotive_deferredcost.PrimaryKey =  new DataColumn[]{taccmotive_deferredcost.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE_RESERVE /////////////////////////////////
	var taccmotive_reserve= new DataTable("accmotive_reserve");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	taccmotive_reserve.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	taccmotive_reserve.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive_reserve.Columns.Add(C);
	taccmotive_reserve.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive_reserve.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive_reserve.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotive_reserve);
	taccmotive_reserve.PrimaryKey =  new DataColumn[]{taccmotive_reserve.Columns["idaccmotive"]};


	//////////////////// EPUPBKINDVIEW /////////////////////////////////
	var tepupbkindview= new DataTable("epupbkindview");
	C= new DataColumn("idepupbkind", typeof(int));
	C.AllowDBNull=false;
	tepupbkindview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tepupbkindview.Columns.Add(C);
	tepupbkindview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tepupbkindview.Columns.Add(C);
	tepupbkindview.Columns.Add( new DataColumn("isresource", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepupbkindview.Columns.Add(C);
	tepupbkindview.Columns.Add( new DataColumn("idacc_cost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codeacc_cost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("account_cost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idacc_revenue", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codeacc_revenue", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("account_revenue", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codeacc_deferredcost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("account_deferredcost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idacc_accruals", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codeacc_accruals", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("account_accruals", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idacc_reserve", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codeacc_reserve", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("account_reserve", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codemotive_cost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idaccmotive_revenue", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codemotive_revenue", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idaccmotive_deferredcost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codemotive_deferredcost", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idaccmotive_accruals", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codemotive_accruals", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("idaccmotive_reserve", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("codemotive_reserve", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tepupbkindview.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepupbkindview.Columns.Add(C);
	tepupbkindview.Columns.Add( new DataColumn("cu", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("adjustmentkind", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("adjustment", typeof(string)));
	tepupbkindview.Columns.Add( new DataColumn("flag", typeof(int)));
	tepupbkindview.Columns.Add( new DataColumn("considerapreimpegni", typeof(string)));
	Tables.Add(tepupbkindview);
	tepupbkindview.PrimaryKey =  new DataColumn[]{tepupbkindview.Columns["idepupbkind"], tepupbkindview.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{accmotive_revenue.Columns["idaccmotive"]};
	var cChild = new []{epupbkindyear.Columns["idaccmotive_revenue"]};
	Relations.Add(new DataRelation("accmotive_revenue_epupbkindyear",cPar,cChild,false));

	cPar = new []{accmotive_cost.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("accmotive_cost_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_rateo.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_accruals"]};
	Relations.Add(new DataRelation("account_rateo_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_risconto.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_deferredcost"]};
	Relations.Add(new DataRelation("account_risconto_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_revenue.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_revenue"]};
	Relations.Add(new DataRelation("account_revenue_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_cost.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_cost"]};
	Relations.Add(new DataRelation("account_cost_epupbkindyear",cPar,cChild,false));

	cPar = new []{epupbkind.Columns["idepupbkind"]};
	cChild = new []{epupbkindyear.Columns["idepupbkind"]};
	Relations.Add(new DataRelation("epupbkind_epupbkindyear",cPar,cChild,false));

	cPar = new []{account_riserva.Columns["idacc"]};
	cChild = new []{epupbkindyear.Columns["idacc_reserve"]};
	Relations.Add(new DataRelation("account_riserva_epupbkindyear",cPar,cChild,false));

	cPar = new []{accmotive_reserve.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_reserve"]};
	Relations.Add(new DataRelation("accmotive_deferredcost_epupbkindyear",cPar,cChild,false));

	cPar = new []{accmotive_accruals.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_accruals"]};
	Relations.Add(new DataRelation("accmotive_rateo_epupbkindyear",cPar,cChild,false));

	cPar = new []{accmotive_deferredcost.Columns["idaccmotive"]};
	cChild = new []{epupbkindyear.Columns["idaccmotive_deferredcost"]};
	Relations.Add(new DataRelation("accmotive_risconto_epupbkindyear",cPar,cChild,false));

	#endregion

}
}
}
