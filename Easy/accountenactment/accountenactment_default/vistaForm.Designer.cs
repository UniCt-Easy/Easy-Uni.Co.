
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
namespace accountenactment_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountenactment 		=> Tables["accountenactment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountvarview 		=> Tables["accountvarview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountenactmentattachment 		=> Tables["accountenactmentattachment"];

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
	//////////////////// ACCOUNTENACTMENT /////////////////////////////////
	var taccountenactment= new DataTable("accountenactment");
	C= new DataColumn("idenactment", typeof(int));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	taccountenactment.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	C= new DataColumn("idenactmentstatus", typeof(short));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	taccountenactment.Columns.Add( new DataColumn("idsor01", typeof(int)));
	taccountenactment.Columns.Add( new DataColumn("idsor02", typeof(int)));
	taccountenactment.Columns.Add( new DataColumn("idsor03", typeof(int)));
	taccountenactment.Columns.Add( new DataColumn("idsor04", typeof(int)));
	taccountenactment.Columns.Add( new DataColumn("idsor05", typeof(int)));
	taccountenactment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	C= new DataColumn("nenactment", typeof(int));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	taccountenactment.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	taccountenactment.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yenactment", typeof(short));
	C.AllowDBNull=false;
	taccountenactment.Columns.Add(C);
	Tables.Add(taccountenactment);
	taccountenactment.PrimaryKey =  new DataColumn[]{taccountenactment.Columns["idenactment"]};


	//////////////////// ACCOUNTVARVIEW /////////////////////////////////
	var taccountvarview= new DataTable("accountvarview");
	C= new DataColumn("yvar", typeof(int));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	taccountvarview.Columns.Add( new DataColumn("enactment", typeof(string)));
	taccountvarview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	taccountvarview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	C= new DataColumn("variationkind", typeof(int));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("variationkinddescr", typeof(string));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("aumento", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("diminuzione", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("saldo", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("amount2", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("amount3", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("amount4", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("amount5", typeof(decimal));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccountvarview.Columns.Add(C);
	taccountvarview.Columns.Add( new DataColumn("idaccountvarstatus", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("accountvarstatus", typeof(string)));
	taccountvarview.Columns.Add( new DataColumn("reason", typeof(string)));
	taccountvarview.Columns.Add( new DataColumn("idman", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("statusimage", typeof(string));
	C.ReadOnly=true;
	taccountvarview.Columns.Add(C);
	taccountvarview.Columns.Add( new DataColumn("listingorder", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("idenactment", typeof(int)));
	taccountvarview.Columns.Add( new DataColumn("yenactment", typeof(short)));
	taccountvarview.Columns.Add( new DataColumn("enactmentnumber", typeof(int)));
	Tables.Add(taccountvarview);
	taccountvarview.PrimaryKey =  new DataColumn[]{taccountvarview.Columns["yvar"], taccountvarview.Columns["nvar"]};


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
	tsorting05.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


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
	tsorting01.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting02.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting03.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting04.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// ACCOUNTENACTMENTATTACHMENT /////////////////////////////////
	var taccountenactmentattachment= new DataTable("accountenactmentattachment");
	C= new DataColumn("idenactment", typeof(int));
	C.AllowDBNull=false;
	taccountenactmentattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	taccountenactmentattachment.Columns.Add(C);
	taccountenactmentattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	taccountenactmentattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	taccountenactmentattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	taccountenactmentattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	taccountenactmentattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	taccountenactmentattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	taccountenactmentattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	Tables.Add(taccountenactmentattachment);
	taccountenactmentattachment.PrimaryKey =  new DataColumn[]{taccountenactmentattachment.Columns["idenactment"], taccountenactmentattachment.Columns["idattachment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting04.Columns["idsor"]};
	var cChild = new []{accountenactment.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting03_accountenactment1",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{accountenactment.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_accountenactment",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{accountenactment.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_accountenactment",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{accountenactment.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_accountenactment",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{accountenactment.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_accountenactment",cPar,cChild,false));

	cPar = new []{accountenactment.Columns["idenactment"]};
	cChild = new []{accountvarview.Columns["idenactment"]};
	Relations.Add(new DataRelation("accountenactment_accountvarview",cPar,cChild,false));

	cPar = new []{accountenactment.Columns["idenactment"]};
	cChild = new []{accountenactmentattachment.Columns["idenactment"]};
	Relations.Add(new DataRelation("accountenactment_accountenactmentattachment",cPar,cChild,false));

	#endregion

}
}
}
