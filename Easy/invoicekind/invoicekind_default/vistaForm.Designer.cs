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
namespace invoicekind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	///<summary>
	///Registro IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivaregisterkind 		=> Tables["ivaregisterkind"];

	///<summary>
	///collegamento tra registri iva e  tipo documento iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekindregisterkind 		=> Tables["invoicekindregisterkind"];

	///<summary>
	///informazioni annuali su un tipo documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekindyear 		=> Tables["invoicekindyear"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountdiff 		=> Tables["accountdiff"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountdiscount 		=> Tables["accountdiscount"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountunabatable 		=> Tables["accountunabatable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_intra 		=> Tables["account_intra"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountdiff_intra 		=> Tables["accountdiff_intra"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountunabatable_intra 		=> Tables["accountunabatable_intra"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind_auto 		=> Tables["invoicekind_auto"];

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

	///<summary>
	///Codice IPA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ipa 		=> Tables["ipa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_split 		=> Tables["account_split"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountunabatable_split 		=> Tables["accountunabatable_split"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountdiff_split 		=> Tables["accountdiff_split"];

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
	EnforceConstraints = false;

	#region create DataTables
	DataColumn C;
	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("formatstring", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idinvkind_auto", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("printingcode", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("header", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("address", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes1", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes2", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes3", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("enable_fe", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new DataTable("ivaregisterkind");
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	Tables.Add(tivaregisterkind);
	tivaregisterkind.PrimaryKey =  new DataColumn[]{tivaregisterkind.Columns["idivaregisterkind"]};


	//////////////////// INVOICEKINDREGISTERKIND /////////////////////////////////
	var tinvoicekindregisterkind= new DataTable("invoicekindregisterkind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindregisterkind.Columns.Add(C);
	Tables.Add(tinvoicekindregisterkind);
	tinvoicekindregisterkind.PrimaryKey =  new DataColumn[]{tinvoicekindregisterkind.Columns["idinvkind"], tinvoicekindregisterkind.Columns["idivaregisterkind"]};


	//////////////////// INVOICEKINDYEAR /////////////////////////////////
	var tinvoicekindyear= new DataTable("invoicekindyear");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	tinvoicekindyear.Columns.Add( new DataColumn("idacc", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_deferred", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekindyear.Columns.Add(C);
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_discount", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_unabatable_intra", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_intra", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_deferred_intra", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_split", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_deferred_split", typeof(string)));
	tinvoicekindyear.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(string)));
	Tables.Add(tinvoicekindyear);
	tinvoicekindyear.PrimaryKey =  new DataColumn[]{tinvoicekindyear.Columns["idinvkind"], tinvoicekindyear.Columns["ayear"]};


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// ACCOUNTDIFF /////////////////////////////////
	var taccountdiff= new DataTable("accountdiff");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	taccountdiff.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	taccountdiff.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountdiff.Columns.Add(C);
	taccountdiff.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccountdiff.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountdiff.Columns.Add( new DataColumn("flagupb", typeof(string)));
	Tables.Add(taccountdiff);
	taccountdiff.PrimaryKey =  new DataColumn[]{taccountdiff.Columns["idacc"]};


	//////////////////// ACCOUNTDISCOUNT /////////////////////////////////
	var taccountdiscount= new DataTable("accountdiscount");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	taccountdiscount.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	taccountdiscount.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountdiscount.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountdiscount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountdiscount.Columns.Add(C);
	taccountdiscount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccountdiscount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountdiscount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	Tables.Add(taccountdiscount);
	taccountdiscount.PrimaryKey =  new DataColumn[]{taccountdiscount.Columns["idacc"]};


	//////////////////// ACCOUNTUNABATABLE /////////////////////////////////
	var taccountunabatable= new DataTable("accountunabatable");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	taccountunabatable.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountunabatable.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountunabatable.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountunabatable.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	taccountunabatable.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	taccountunabatable.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable.Columns.Add(C);
	taccountunabatable.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountunabatable.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountunabatable.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	Tables.Add(taccountunabatable);
	taccountunabatable.PrimaryKey =  new DataColumn[]{taccountunabatable.Columns["idacc"]};


	//////////////////// ACCOUNT_INTRA /////////////////////////////////
	var taccount_intra= new DataTable("account_intra");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	taccount_intra.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	taccount_intra.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	taccount_intra.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_intra.Columns.Add(C);
	taccount_intra.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_intra.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_intra);
	taccount_intra.PrimaryKey =  new DataColumn[]{taccount_intra.Columns["idacc"]};


	//////////////////// ACCOUNTDIFF_INTRA /////////////////////////////////
	var taccountdiff_intra= new DataTable("accountdiff_intra");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	taccountdiff_intra.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	taccountdiff_intra.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	taccountdiff_intra.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_intra.Columns.Add(C);
	taccountdiff_intra.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountdiff_intra.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountdiff_intra);
	taccountdiff_intra.PrimaryKey =  new DataColumn[]{taccountdiff_intra.Columns["idacc"]};


	//////////////////// ACCOUNTUNABATABLE_INTRA /////////////////////////////////
	var taccountunabatable_intra= new DataTable("accountunabatable_intra");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	taccountunabatable_intra.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	taccountunabatable_intra.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	taccountunabatable_intra.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_intra.Columns.Add(C);
	taccountunabatable_intra.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountunabatable_intra.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountunabatable_intra);
	taccountunabatable_intra.PrimaryKey =  new DataColumn[]{taccountunabatable_intra.Columns["idacc"]};


	//////////////////// INVOICEKIND_AUTO /////////////////////////////////
	var tinvoicekind_auto= new DataTable("invoicekind_auto");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind_auto.Columns.Add(C);
	tinvoicekind_auto.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind_auto.Columns.Add( new DataColumn("formatstring", typeof(string)));
	tinvoicekind_auto.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind_auto.Columns.Add( new DataColumn("idinvkind_auto", typeof(int)));
	Tables.Add(tinvoicekind_auto);
	tinvoicekind_auto.PrimaryKey =  new DataColumn[]{tinvoicekind_auto.Columns["idinvkind"]};


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


	//////////////////// IPA /////////////////////////////////
	var tipa= new DataTable("ipa");
	C= new DataColumn("ipa_fe", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("agencyname", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("officename", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	tipa.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tipa.Columns.Add( new DataColumn("cu", typeof(string)));
	tipa.Columns.Add( new DataColumn("lu", typeof(string)));
	tipa.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tipa.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tipa);
	tipa.PrimaryKey =  new DataColumn[]{tipa.Columns["ipa_fe"]};


	//////////////////// ACCOUNT_SPLIT /////////////////////////////////
	var taccount_split= new DataTable("account_split");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	taccount_split.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	taccount_split.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	taccount_split.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_split.Columns.Add(C);
	taccount_split.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_split.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_split);
	taccount_split.PrimaryKey =  new DataColumn[]{taccount_split.Columns["idacc"]};


	//////////////////// ACCOUNTUNABATABLE_SPLIT /////////////////////////////////
	var taccountunabatable_split= new DataTable("accountunabatable_split");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	taccountunabatable_split.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	taccountunabatable_split.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	taccountunabatable_split.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountunabatable_split.Columns.Add(C);
	taccountunabatable_split.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountunabatable_split.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountunabatable_split);
	taccountunabatable_split.PrimaryKey =  new DataColumn[]{taccountunabatable_split.Columns["idacc"]};


	//////////////////// ACCOUNTDIFF_SPLIT /////////////////////////////////
	var taccountdiff_split= new DataTable("accountdiff_split");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	taccountdiff_split.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	taccountdiff_split.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	taccountdiff_split.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountdiff_split.Columns.Add(C);
	taccountdiff_split.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountdiff_split.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountdiff_split);
	taccountdiff_split.PrimaryKey =  new DataColumn[]{taccountdiff_split.Columns["idacc"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{accountdiff_split.Columns["idacc"]};
	var cChild = new []{invoicekindyear.Columns["idacc_deferred_split"]};
	Relations.Add(new DataRelation("accountdiff_split_invoicekindyear",cPar,cChild,false));

	cPar = new []{accountunabatable_split.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_unabatable_split"]};
	Relations.Add(new DataRelation("accountunabatable_split_invoicekindyear",cPar,cChild,false));

	cPar = new []{account_split.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_split"]};
	Relations.Add(new DataRelation("account_split_invoicekindyear",cPar,cChild,false));

	cPar = new []{accountunabatable_intra.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_unabatable_intra"]};
	Relations.Add(new DataRelation("accountunabatable_intra_invoicekindyear",cPar,cChild,false));

	cPar = new []{account_intra.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_intra"]};
	Relations.Add(new DataRelation("account_intra_invoicekindyear",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicekindyear.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoicekindyear",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc"]};
	Relations.Add(new DataRelation("accountinvoicekindyear",cPar,cChild,false));

	cPar = new []{accountdiff.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_deferred"]};
	Relations.Add(new DataRelation("accountdiffinvoicekindyear",cPar,cChild,false));

	cPar = new []{accountdiscount.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_discount"]};
	Relations.Add(new DataRelation("accountdiscountinvoicekindyear",cPar,cChild,false));

	cPar = new []{accountunabatable.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_unabatable"]};
	Relations.Add(new DataRelation("accountunabatableinvoicekindyear",cPar,cChild,false));

	cPar = new []{accountdiff_intra.Columns["idacc"]};
	cChild = new []{invoicekindyear.Columns["idacc_deferred_intra"]};
	Relations.Add(new DataRelation("accountdiff_intra_invoicekindyear",cPar,cChild,false));

	cPar = new []{ivaregisterkind.Columns["idivaregisterkind"]};
	cChild = new []{invoicekindregisterkind.Columns["idivaregisterkind"]};
	Relations.Add(new DataRelation("ivaregisterkindinvoicekindregisterkind",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoicekindregisterkind.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoicekindregisterkind",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{invoicekind.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_invoicekind",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{invoicekind.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_invoicekind",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{invoicekind.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_invoicekind",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{invoicekind.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_invoicekind",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{invoicekind.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_invoicekind",cPar,cChild,false));

	cPar = new []{invoicekind_auto.Columns["idinvkind"]};
	cChild = new []{invoicekind.Columns["idinvkind_auto"]};
	Relations.Add(new DataRelation("FK_invoicekind_invoicekind_auto",cPar,cChild,false));

	cPar = new []{ipa.Columns["ipa_fe"]};
	cChild = new []{invoicekind.Columns["ipa_fe"]};
	Relations.Add(new DataRelation("FK_ipa_invoicekind",cPar,cChild,false));

	#endregion

}
}
}
