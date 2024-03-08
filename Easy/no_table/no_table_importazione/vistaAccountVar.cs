
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
[System.Xml.Serialization.XmlRoot("vistaAccountVar"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaAccountVar: DataSet {

	#region Table members declaration
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	///<summary>
	///variazione di budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountvar 		=> Tables["accountvar"];

	///<summary>
	///Dettaglio variazione di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountvardetail 		=> Tables["accountvardetail"];

	///<summary>
	///Classificazione inventariale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytree 		=> Tables["inventorytree"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaAccountVar(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaAccountVar (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaAccountVar";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaAccountVar.xsd";

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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount.Columns.Add( new DataColumn("flag", typeof(int)));
	taccount.Columns.Add( new DataColumn("idacc_special", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagenablebudgetprev", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	taccount.Columns.Add( new DataColumn("economicbudget_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("investmentbudget_sign", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// ACCOUNTVAR /////////////////////////////////
	var taccountvar= new DataTable("accountvar");
	C= new DataColumn("yvar", typeof(int));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	taccountvar.Columns.Add( new DataColumn("annotation", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	taccountvar.Columns.Add( new DataColumn("enactment", typeof(string)));
	taccountvar.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	taccountvar.Columns.Add( new DataColumn("idaccountvarstatus", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("idman", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("idsor01", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("idsor02", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("idsor03", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("idsor04", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	taccountvar.Columns.Add( new DataColumn("nenactment", typeof(string)));
	taccountvar.Columns.Add( new DataColumn("reason", typeof(string)));
	taccountvar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	taccountvar.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("variationkind", typeof(int));
	C.AllowDBNull=false;
	taccountvar.Columns.Add(C);
	taccountvar.Columns.Add( new DataColumn("idenactment", typeof(int)));
	taccountvar.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccountvar);
	taccountvar.PrimaryKey =  new DataColumn[]{taccountvar.Columns["yvar"], taccountvar.Columns["nvar"]};


	//////////////////// ACCOUNTVARDETAIL /////////////////////////////////
	var taccountvardetail= new DataTable("accountvardetail");
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	C= new DataColumn("yvar", typeof(int));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	taccountvardetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	taccountvardetail.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	taccountvardetail.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	taccountvardetail.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	taccountvardetail.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	taccountvardetail.Columns.Add( new DataColumn("annotation", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	taccountvardetail.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountvardetail.Columns.Add(C);
	taccountvardetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	taccountvardetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	taccountvardetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	taccountvardetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	taccountvardetail.Columns.Add( new DataColumn("underwritingkind", typeof(string)));
	taccountvardetail.Columns.Add( new DataColumn("idinv", typeof(int)));
	Tables.Add(taccountvardetail);
	taccountvardetail.PrimaryKey =  new DataColumn[]{taccountvardetail.Columns["nvar"], taccountvardetail.Columns["yvar"], taccountvardetail.Columns["rownum"]};


	//////////////////// INVENTORYTREE /////////////////////////////////
	var tinventorytree= new DataTable("inventorytree");
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	tinventorytree.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tinventorytree.Columns.Add( new DataColumn("txt", typeof(string)));
	tinventorytree.Columns.Add( new DataColumn("idaccmotiveunload", typeof(string)));
	tinventorytree.Columns.Add( new DataColumn("idaccmotiveload", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytree.Columns.Add(C);
	tinventorytree.Columns.Add( new DataColumn("paridinv", typeof(int)));
	tinventorytree.Columns.Add( new DataColumn("lookupcode", typeof(string)));
	tinventorytree.Columns.Add( new DataColumn("idaccmotivediscount", typeof(string)));
	tinventorytree.Columns.Add( new DataColumn("idaccmotivetransfer", typeof(string)));
	Tables.Add(tinventorytree);
	tinventorytree.PrimaryKey =  new DataColumn[]{tinventorytree.Columns["idinv"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{account.Columns["idacc"]};
	var cChild = new []{accountvardetail.Columns["idacc"]};
	Relations.Add(new DataRelation("account_accountvardetail",cPar,cChild,false));

	cPar = new []{accountvar.Columns["yvar"], accountvar.Columns["nvar"]};
	cChild = new []{accountvardetail.Columns["yvar"], accountvardetail.Columns["nvar"]};
	Relations.Add(new DataRelation("accountvar_accountvardetail",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{accountvardetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_accountvardetail",cPar,cChild,false));

	#endregion

}
}
}
