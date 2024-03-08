
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
namespace pccsid_wizard_calcolo {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccsend 		=> Tables["pccsend"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pcc 		=> Tables["pcc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccexpiring 		=> Tables["pccexpiring"];

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
	public DataTable invoice 		=> Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdocamountvar 		=> Tables["pccdocamountvar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitstatusdetail 		=> Tables["pccdebitstatusdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccsplitpayment 		=> Tables["pccsplitpayment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccpayment 		=> Tables["pccpayment"];

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
	//////////////////// PCCSEND /////////////////////////////////
	var tpccsend= new DataTable("pccsend");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccsend.Columns.Add(C);
	C= new DataColumn("idpccsend", typeof(int));
	C.AllowDBNull=false;
	tpccsend.Columns.Add(C);
	tpccsend.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccsend.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccsend.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccsend.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccsend.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccsend.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccsend.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccsend.Columns.Add( new DataColumn("idmankind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccsend.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccsend.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccsend.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccsend.Columns.Add(C);
	tpccsend.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpccsend.Columns.Add( new DataColumn("taxabletotal", typeof(decimal)));
	tpccsend.Columns.Add( new DataColumn("taxtotal", typeof(decimal)));
	tpccsend.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tpccsend.Columns.Add( new DataColumn("idfenature", typeof(string)));
	tpccsend.Columns.Add( new DataColumn("taxabletotalbyiva", typeof(decimal)));
	tpccsend.Columns.Add( new DataColumn("taxtotalbyiva", typeof(decimal)));
	tpccsend.Columns.Add( new DataColumn("amountcigcup", typeof(decimal)));
	tpccsend.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tpccsend.Columns.Add( new DataColumn("cupcode", typeof(string)));
	Tables.Add(tpccsend);
	tpccsend.PrimaryKey =  new DataColumn[]{tpccsend.Columns["idpcc"], tpccsend.Columns["idpccsend"]};


	//////////////////// PCC /////////////////////////////////
	var tpcc= new DataTable("pcc");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpcc.Columns.Add(C);
	tpcc.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpcc.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpcc.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpcc.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpcc.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpcc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpcc.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpcc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpcc.Columns.Add(C);
	tpcc.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	tpcc.Columns.Add( new DataColumn("filename", typeof(string)));
	Tables.Add(tpcc);
	tpcc.PrimaryKey =  new DataColumn[]{tpcc.Columns["idpcc"]};


	//////////////////// PCCEXPIRING /////////////////////////////////
	var tpccexpiring= new DataTable("pccexpiring");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccexpiring.Columns.Add(C);
	C= new DataColumn("idpccexpiring", typeof(int));
	C.AllowDBNull=false;
	tpccexpiring.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccexpiring.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccexpiring.Columns.Add(C);
	tpccexpiring.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccexpiring.Columns.Add( new DataColumn("idmankind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccexpiring.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccexpiring.Columns.Add(C);
	tpccexpiring.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccexpiring.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccexpiring.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccexpiring.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccexpiring.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccexpiring.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccexpiring.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpccexpiring.Columns.Add( new DataColumn("expiringdate", typeof(DateTime)));
	tpccexpiring.Columns.Add( new DataColumn("invrownum", typeof(int)));
	tpccexpiring.Columns.Add( new DataColumn("manrownum", typeof(int)));
	Tables.Add(tpccexpiring);
	tpccexpiring.PrimaryKey =  new DataColumn[]{tpccexpiring.Columns["idpcc"], tpccexpiring.Columns["idpccexpiring"]};


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


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tinvoice.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_origin", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_provenance", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("iso_destination", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcountry_origin", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idcountry_destination", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idintrastatkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("iso_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_ddt", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idblacklist", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idinvkind_real", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("yinv_real", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("ninv_real", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("idfepaymethodcondition", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idfepaymethod", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("nelectronicinvoice", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("yelectronicinvoice", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("toincludeinpaymentindicator", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("resendingpcc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("touniqueregister", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["ninv"], tinvoice.Columns["yinv"], tinvoice.Columns["idinvkind"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// PCCDOCAMOUNTVAR /////////////////////////////////
	var tpccdocamountvar= new DataTable("pccdocamountvar");
	C= new DataColumn("idpccdocamountvar", typeof(int));
	C.AllowDBNull=false;
	tpccdocamountvar.Columns.Add(C);
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccdocamountvar.Columns.Add(C);
	tpccdocamountvar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccdocamountvar.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccdocamountvar.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccdocamountvar.Columns.Add( new DataColumn("idpccdebitstatusdetail", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdocamountvar.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccdocamountvar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdocamountvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdocamountvar.Columns.Add(C);
	Tables.Add(tpccdocamountvar);
	tpccdocamountvar.PrimaryKey =  new DataColumn[]{tpccdocamountvar.Columns["idpccdocamountvar"], tpccdocamountvar.Columns["idpcc"]};


	//////////////////// PCCDEBITSTATUSDETAIL /////////////////////////////////
	var tpccdebitstatusdetail= new DataTable("pccdebitstatusdetail");
	C= new DataColumn("idpccdebitstatusdetail", typeof(int));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	tpccdebitstatusdetail.Columns.Add( new DataColumn("idpcc", typeof(int)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("importononcommerciale", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_sosp_contenzioso", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_sosp_contenzioso", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("start_sosp_contenzioso", typeof(DateTime)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_sosp_contestazione", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_sosp_contestazione", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("start_sosp_contestazione", typeof(DateTime)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_sosp_regolareverifica", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_sosp_regolareverifica", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("start_sosp_regolareverifica", typeof(DateTime)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_nonliquidabile", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_nonliquidabile", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	Tables.Add(tpccdebitstatusdetail);
	tpccdebitstatusdetail.PrimaryKey =  new DataColumn[]{tpccdebitstatusdetail.Columns["idpccdebitstatusdetail"], tpccdebitstatusdetail.Columns["idinvkind"], tpccdebitstatusdetail.Columns["yinv"], tpccdebitstatusdetail.Columns["ninv"]};


	//////////////////// PCCSPLITPAYMENT /////////////////////////////////
	var tpccsplitpayment= new DataTable("pccsplitpayment");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccsplitpayment.Columns.Add(C);
	C= new DataColumn("idpccsplitpayment", typeof(int));
	C.AllowDBNull=false;
	tpccsplitpayment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccsplitpayment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccsplitpayment.Columns.Add(C);
	tpccsplitpayment.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccsplitpayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccsplitpayment.Columns.Add(C);
	tpccsplitpayment.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccsplitpayment.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccsplitpayment.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	Tables.Add(tpccsplitpayment);
	tpccsplitpayment.PrimaryKey =  new DataColumn[]{tpccsplitpayment.Columns["idpcc"], tpccsplitpayment.Columns["idpccsplitpayment"]};


	//////////////////// PCCPAYMENT /////////////////////////////////
	var tpccpayment= new DataTable("pccpayment");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccpayment.Columns.Add(C);
	C= new DataColumn("idpccpayment", typeof(int));
	C.AllowDBNull=false;
	tpccpayment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccpayment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccpayment.Columns.Add(C);
	tpccpayment.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("idmankind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccpayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccpayment.Columns.Add(C);
	tpccpayment.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccpayment.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccpayment.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpccpayment.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tpccpayment.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("kpay", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tpccpayment.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tpccpayment.Columns.Add( new DataColumn("description", typeof(string)));
	tpccpayment.Columns.Add( new DataColumn("idpettycash", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("yoperation", typeof(int)));
	tpccpayment.Columns.Add( new DataColumn("noperation", typeof(short)));
	Tables.Add(tpccpayment);
	tpccpayment.PrimaryKey =  new DataColumn[]{tpccpayment.Columns["idpcc"], tpccpayment.Columns["idpccpayment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{pcc.Columns["idpcc"]};
	var cChild = new []{pccpayment.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccpayment",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccexpiring.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccexpiring",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_pcc",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_pcc",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_pcc",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_pcc",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_pcc",cPar,cChild,false));

	cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	cChild = new []{pccsend.Columns["ninv"], pccsend.Columns["yinv"], pccsend.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_pccexpense",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccsend.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccsend",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccdocamountvar.Columns["idpcc"]};
	Relations.Add(new DataRelation("pcc_pccdocamountvar",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccdebitstatusdetail.Columns["idpcc"]};
	Relations.Add(new DataRelation("pcc_pccdebitstatusdetail",cPar,cChild,false));

	cPar = new []{pccdocamountvar.Columns["idpccdebitstatusdetail"], pccdocamountvar.Columns["idpcc"]};
	cChild = new []{pccdebitstatusdetail.Columns["idpccdebitstatusdetail"], pccdebitstatusdetail.Columns["idpcc"]};
	Relations.Add(new DataRelation("pccdebitstatusdetail_pccdocamountvar",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccsplitpayment.Columns["idpcc"]};
	Relations.Add(new DataRelation("pcc_pccsplitpayment",cPar,cChild,false));

	#endregion

}
}
}
