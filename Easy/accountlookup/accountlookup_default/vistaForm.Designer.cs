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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace accountlookup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Livelli del piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountlevel 		=> Tables["accountlevel"];

	///<summary>
	///Converti voci del Piano dei Conti annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountlookup 		=> Tables["accountlookup"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account1 		=> Tables["account1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountlookupview 		=> Tables["accountlookupview"];

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
	//////////////////// ACCOUNTLEVEL /////////////////////////////////
	var taccountlevel= new DataTable("accountlevel");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	taccountlevel.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountlevel.Columns.Add(C);
	Tables.Add(taccountlevel);
	taccountlevel.PrimaryKey =  new DataColumn[]{taccountlevel.Columns["ayear"], taccountlevel.Columns["nlevel"]};


	//////////////////// ACCOUNTLOOKUP /////////////////////////////////
	var taccountlookup= new DataTable("accountlookup");
	C= new DataColumn("oldidacc", typeof(string));
	C.AllowDBNull=false;
	taccountlookup.Columns.Add(C);
	C= new DataColumn("newidacc", typeof(string));
	C.AllowDBNull=false;
	taccountlookup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountlookup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountlookup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountlookup.Columns.Add(C);
	taccountlookup.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(taccountlookup);
	taccountlookup.PrimaryKey =  new DataColumn[]{taccountlookup.Columns["oldidacc"], taccountlookup.Columns["newidacc"]};


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
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// ACCOUNT1 /////////////////////////////////
	var taccount1= new DataTable("account1");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	taccount1.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount1.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount1.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount1.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	taccount1.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	taccount1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount1.Columns.Add(C);
	taccount1.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount1.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount1.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount1.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount1.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount1.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount1.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount1.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	Tables.Add(taccount1);
	taccount1.PrimaryKey =  new DataColumn[]{taccount1.Columns["idacc"]};


	//////////////////// ACCOUNTLOOKUPVIEW /////////////////////////////////
	var taccountlookupview= new DataTable("accountlookupview");
	C= new DataColumn("oldidacc", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("oldayear", typeof(short));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("oldcodeacc", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("oldtitle", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("newidacc", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("newayear", typeof(short));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("newcodeacc", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("newtitle", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	taccountlookupview.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountlookupview.Columns.Add(C);
	Tables.Add(taccountlookupview);
	taccountlookupview.PrimaryKey =  new DataColumn[]{taccountlookupview.Columns["oldidacc"], taccountlookupview.Columns["newidacc"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{account.Columns["idacc"]};
	var cChild = new []{accountlookup.Columns["oldidacc"]};
	Relations.Add(new DataRelation("account_accountlookup",cPar,cChild,false));

	cPar = new []{account1.Columns["idacc"]};
	cChild = new []{accountlookup.Columns["newidacc"]};
	Relations.Add(new DataRelation("account1_accountlookup",cPar,cChild,false));

	#endregion

}
}
}
