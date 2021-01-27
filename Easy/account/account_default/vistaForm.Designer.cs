
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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace account_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	///<summary>
	///Livelli del piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountlevel 		=> Tables["accountlevel"];

	///<summary>
	///Tipo conto, determina il modo in cui Ã¨ movimentato nelle varie situazioni.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountkind 		=> Tables["accountkind"];

	///<summary>
	///Classificazione conto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountsorting 		=> Tables["accountsorting"];

	///<summary>
	///Stato Patrimoniale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable patrimony 		=> Tables["patrimony"];

	///<summary>
	///Conto Economico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable placcount 		=> Tables["placcount"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountspecial 		=> Tables["accountspecial"];

	///<summary>
	///Previsione di budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountyear 		=> Tables["accountyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountvardetailview 		=> Tables["accountvardetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountyearview 		=> Tables["accountyearview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_economico 		=> Tables["sorting_economico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_investimenti 		=> Tables["sorting_investimenti"];

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
	taccount.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
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
	taccount.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagenablebudgetprev", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	taccount.Columns.Add( new DataColumn("idsor_economicbudget", typeof(int)));
	taccount.Columns.Add( new DataColumn("economicbudget_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("idsor_investmentbudget", typeof(int)));
	taccount.Columns.Add( new DataColumn("investmentbudget_sign", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// ACCOUNTLEVEL /////////////////////////////////
	var taccountlevel= new DataTable("accountlevel");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	taccountlevel.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(taccountlevel);
	taccountlevel.PrimaryKey =  new DataColumn[]{taccountlevel.Columns["ayear"], taccountlevel.Columns["nlevel"]};


	//////////////////// ACCOUNTKIND /////////////////////////////////
	var taccountkind= new DataTable("accountkind");
	C= new DataColumn("idaccountkind", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	taccountkind.Columns.Add( new DataColumn("flagda", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountkind.Columns.Add(C);
	taccountkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(taccountkind);
	taccountkind.PrimaryKey =  new DataColumn[]{taccountkind.Columns["idaccountkind"]};


	//////////////////// ACCOUNTSORTING /////////////////////////////////
	var taccountsorting= new DataTable("accountsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	taccountsorting.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountsorting.Columns.Add(C);
	taccountsorting.Columns.Add( new DataColumn("quota", typeof(double)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountsorting.Columns.Add(C);
	taccountsorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	taccountsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	taccountsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	taccountsorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	Tables.Add(taccountsorting);
	taccountsorting.PrimaryKey =  new DataColumn[]{taccountsorting.Columns["idacc"], taccountsorting.Columns["idsor"]};


	//////////////////// PATRIMONY /////////////////////////////////
	var tpatrimony= new DataTable("patrimony");
	C= new DataColumn("idpatrimony", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("patpart", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("codepatrimony", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("paridpatrimony", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	tpatrimony.Columns.Add( new DataColumn("txt", typeof(string)));
	tpatrimony.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpatrimony.Columns.Add(C);
	tpatrimony.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tpatrimony);
	tpatrimony.PrimaryKey =  new DataColumn[]{tpatrimony.Columns["idpatrimony"]};


	//////////////////// PLACCOUNT /////////////////////////////////
	var tplaccount= new DataTable("placcount");
	C= new DataColumn("idplaccount", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("placcpart", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("codeplaccount", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("paridplaccount", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	tplaccount.Columns.Add( new DataColumn("txt", typeof(string)));
	tplaccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	Tables.Add(tplaccount);
	tplaccount.PrimaryKey =  new DataColumn[]{tplaccount.Columns["idplaccount"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingview.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	//////////////////// ACCOUNTSPECIAL /////////////////////////////////
	var taccountspecial= new DataTable("accountspecial");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	taccountspecial.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	taccountspecial.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("txt", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountspecial.Columns.Add(C);
	taccountspecial.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccountspecial.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountspecial);
	taccountspecial.PrimaryKey =  new DataColumn[]{taccountspecial.Columns["idacc"]};


	//////////////////// ACCOUNTYEAR /////////////////////////////////
	var taccountyear= new DataTable("accountyear");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	taccountyear.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	taccountyear.Columns.Add(C);
	taccountyear.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	taccountyear.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	taccountyear.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	taccountyear.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	Tables.Add(taccountyear);
	taccountyear.PrimaryKey =  new DataColumn[]{taccountyear.Columns["idacc"], taccountyear.Columns["idupb"]};


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
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	taccountvardetailview.Columns.Add(C);
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
	taccountyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("nlevel", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("leveldescr", typeof(string)));
	taccountyearview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	taccountyearview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	taccountyearview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	taccountyearview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	taccountyearview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	taccountyearview.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	Tables.Add(taccountyearview);
	taccountyearview.PrimaryKey =  new DataColumn[]{taccountyearview.Columns["idacc"], taccountyearview.Columns["idupb"]};


	//////////////////// SORTING_ECONOMICO /////////////////////////////////
	var tsorting_economico= new DataTable("sorting_economico");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	tsorting_economico.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_economico.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	tsorting_economico.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	tsorting_economico.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_economico.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	tsorting_economico.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	tsorting_economico.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_economico.Columns.Add(C);
	tsorting_economico.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_economico.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_economico.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_economico);
	tsorting_economico.PrimaryKey =  new DataColumn[]{tsorting_economico.Columns["idsor"]};


	//////////////////// SORTING_INVESTIMENTI /////////////////////////////////
	var tsorting_investimenti= new DataTable("sorting_investimenti");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	tsorting_investimenti.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_investimenti.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	tsorting_investimenti.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	tsorting_investimenti.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_investimenti.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	tsorting_investimenti.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	tsorting_investimenti.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_investimenti.Columns.Add(C);
	tsorting_investimenti.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_investimenti.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_investimenti.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_investimenti);
	tsorting_investimenti.PrimaryKey =  new DataColumn[]{tsorting_investimenti.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{account.Columns["idacc"]};
	var cChild = new []{accountyearview.Columns["idacc"]};
	Relations.Add(new DataRelation("account_accountyearview",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{accountvardetailview.Columns["idacc"]};
	Relations.Add(new DataRelation("account_accountvardetailview",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{accountsorting.Columns["idacc"]};
	Relations.Add(new DataRelation("accountaccountsorting",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{accountsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_accountsorting",cPar,cChild,false));

	cPar = new []{accountspecial.Columns["idacc"], accountspecial.Columns["ayear"]};
	cChild = new []{account.Columns["idacc_special"], account.Columns["ayear"]};
	Relations.Add(new DataRelation("accountspecial_account",cPar,cChild,false));

	cPar = new []{placcount.Columns["idplaccount"]};
	cChild = new []{account.Columns["idplaccount"]};
	Relations.Add(new DataRelation("placcountaccount",cPar,cChild,false));

	cPar = new []{patrimony.Columns["idpatrimony"]};
	cChild = new []{account.Columns["idpatrimony"]};
	Relations.Add(new DataRelation("patrimonyaccount",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{account.Columns["paridacc"]};
	Relations.Add(new DataRelation("accountaccount",cPar,cChild,false));

	cPar = new []{accountkind.Columns["idaccountkind"]};
	cChild = new []{account.Columns["idaccountkind"]};
	Relations.Add(new DataRelation("accountkindaccount",cPar,cChild,false));

	cPar = new []{accountlevel.Columns["ayear"], accountlevel.Columns["nlevel"]};
	cChild = new []{account.Columns["ayear"], account.Columns["nlevel"]};
	Relations.Add(new DataRelation("accountlevelaccount",cPar,cChild,false));

	cPar = new []{sorting_economico.Columns["idsor"]};
	cChild = new []{account.Columns["idsor_economicbudget"]};
	Relations.Add(new DataRelation("FK_sorting_economico_account",cPar,cChild,false));

	cPar = new []{sorting_investimenti.Columns["idsor"]};
	cChild = new []{account.Columns["idsor_investmentbudget"]};
	Relations.Add(new DataRelation("FK_sorting_investimenti_account",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{accountyear.Columns["idacc"]};
	Relations.Add(new DataRelation("account_accountyear",cPar,cChild,false));

	#endregion

}
}
}
