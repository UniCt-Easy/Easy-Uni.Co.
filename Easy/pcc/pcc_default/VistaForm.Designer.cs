
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
namespace pcc_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("VistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class VistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Piattaforma per la certificazione dei crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pcc 		=> Tables["pcc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccsendview 		=> Tables["pccsendview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccpaymentview 		=> Tables["pccpaymentview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccexpiringview 		=> Tables["pccexpiringview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccexpenseview 		=> Tables["pccexpenseview"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public VistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected VistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "VistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaForm.xsd";

	#region create DataTables
	DataColumn C;
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


	//////////////////// PCCSENDVIEW /////////////////////////////////
	var tpccsendview= new DataTable("pccsendview");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("idpccsend", typeof(int));
	C.AllowDBNull=false;
	tpccsendview.Columns.Add(C);
	tpccsendview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccsendview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccsendview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccsendview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tpccsendview.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccsendview.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccsendview.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccsendview.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccsendview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tpccsendview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tpccsendview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpccsendview.Columns.Add( new DataColumn("taxabletotal", typeof(decimal)));
	tpccsendview.Columns.Add( new DataColumn("taxtotal", typeof(decimal)));
	tpccsendview.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tpccsendview.Columns.Add( new DataColumn("idfenature", typeof(string)));
	tpccsendview.Columns.Add( new DataColumn("taxabletotalbyiva", typeof(decimal)));
	tpccsendview.Columns.Add( new DataColumn("taxtotalbyiva", typeof(decimal)));
	tpccsendview.Columns.Add( new DataColumn("amountcigcup", typeof(decimal)));
	tpccsendview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tpccsendview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tpccsendview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("IdFiscaleIvaFornitore", typeof(string));
	C.ReadOnly=true;
	tpccsendview.Columns.Add(C);
	tpccsendview.Columns.Add( new DataColumn("CFfornitore", typeof(string)));
	C= new DataColumn("ImportoTotaleDocumento", typeof(decimal));
	C.ReadOnly=true;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.ReadOnly=true;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("numerodocumento", typeof(string));
	C.ReadOnly=true;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("causale", typeof(string));
	C.ReadOnly=true;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccsendview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccsendview.Columns.Add(C);
	Tables.Add(tpccsendview);
	tpccsendview.PrimaryKey =  new DataColumn[]{tpccsendview.Columns["idpcc"], tpccsendview.Columns["idpccsend"]};


	//////////////////// PCCPAYMENTVIEW /////////////////////////////////
	var tpccpaymentview= new DataTable("pccpaymentview");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccpaymentview.Columns.Add(C);
	C= new DataColumn("idpccpayment", typeof(int));
	C.AllowDBNull=false;
	tpccpaymentview.Columns.Add(C);
	tpccpaymentview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccpaymentview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccpaymentview.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpccpaymentview.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("kpay", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("npay", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("description", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("expensephase", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tpccpaymentview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccpaymentview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccpaymentview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccpaymentview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccpaymentview.Columns.Add(C);
	tpccpaymentview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("IdFiscaleIvaFornitore", typeof(string));
	C.ReadOnly=true;
	tpccpaymentview.Columns.Add(C);
	tpccpaymentview.Columns.Add( new DataColumn("CFfornitore", typeof(string)));
	C= new DataColumn("ImportoTotaleDocumento", typeof(decimal));
	C.ReadOnly=true;
	tpccpaymentview.Columns.Add(C);
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.ReadOnly=true;
	tpccpaymentview.Columns.Add(C);
	C= new DataColumn("numerodocumento", typeof(string));
	C.ReadOnly=true;
	tpccpaymentview.Columns.Add(C);
	tpccpaymentview.Columns.Add( new DataColumn("pettycash", typeof(string)));
	tpccpaymentview.Columns.Add( new DataColumn("idpettycash", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("yoperation", typeof(int)));
	tpccpaymentview.Columns.Add( new DataColumn("noperation", typeof(short)));
	Tables.Add(tpccpaymentview);
	tpccpaymentview.PrimaryKey =  new DataColumn[]{tpccpaymentview.Columns["idpcc"], tpccpaymentview.Columns["idpccpayment"]};


	//////////////////// PCCEXPIRINGVIEW /////////////////////////////////
	var tpccexpiringview= new DataTable("pccexpiringview");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("idpccexpiring", typeof(int));
	C.AllowDBNull=false;
	tpccexpiringview.Columns.Add(C);
	tpccexpiringview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccexpiringview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccexpiringview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccexpiringview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tpccexpiringview.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccexpiringview.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccexpiringview.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccexpiringview.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccexpiringview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tpccexpiringview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tpccexpiringview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpccexpiringview.Columns.Add( new DataColumn("expiringdate", typeof(DateTime)));
	tpccexpiringview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("IdFiscaleIvaFornitore", typeof(string));
	C.ReadOnly=true;
	tpccexpiringview.Columns.Add(C);
	tpccexpiringview.Columns.Add( new DataColumn("CFfornitore", typeof(string)));
	C= new DataColumn("ImportoTotaleDocumento", typeof(decimal));
	C.ReadOnly=true;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.ReadOnly=true;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("numerodocumento", typeof(string));
	C.ReadOnly=true;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccexpiringview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccexpiringview.Columns.Add(C);
	tpccexpiringview.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tpccexpiringview.Columns.Add( new DataColumn("invrownum", typeof(int)));
	Tables.Add(tpccexpiringview);
	tpccexpiringview.PrimaryKey =  new DataColumn[]{tpccexpiringview.Columns["idpcc"], tpccexpiringview.Columns["idpccexpiring"]};


	//////////////////// PCCEXPENSEVIEW /////////////////////////////////
	var tpccexpenseview= new DataTable("pccexpenseview");
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccexpenseview.Columns.Add(C);
	C= new DataColumn("idpccexpense", typeof(int));
	C.AllowDBNull=false;
	tpccexpenseview.Columns.Add(C);
	tpccexpenseview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccexpenseview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccexpenseview.Columns.Add( new DataColumn("nman", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpccexpenseview.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("expensetaxkind", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("motive", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("description", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("expensephase", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tpccexpenseview.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccexpenseview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccexpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccexpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccexpenseview.Columns.Add(C);
	tpccexpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("IdFiscaleIvaFornitore", typeof(string));
	C.ReadOnly=true;
	tpccexpenseview.Columns.Add(C);
	tpccexpenseview.Columns.Add( new DataColumn("CFfornitore", typeof(string)));
	C= new DataColumn("ImportoTotaleDocumento", typeof(decimal));
	C.ReadOnly=true;
	tpccexpenseview.Columns.Add(C);
	C= new DataColumn("dataemissione", typeof(DateTime));
	C.ReadOnly=true;
	tpccexpenseview.Columns.Add(C);
	C= new DataColumn("numerodocumento", typeof(string));
	C.ReadOnly=true;
	tpccexpenseview.Columns.Add(C);
	tpccexpenseview.Columns.Add( new DataColumn("invrownum", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tpccexpenseview.Columns.Add( new DataColumn("pccdebitstatus", typeof(string)));
	tpccexpenseview.Columns.Add( new DataColumn("pccdebitmotive", typeof(string)));
	Tables.Add(tpccexpenseview);
	tpccexpenseview.PrimaryKey =  new DataColumn[]{tpccexpenseview.Columns["idpcc"], tpccexpenseview.Columns["idpccexpense"]};


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


	#endregion


	#region DataRelation creation
	var cPar = new []{pcc.Columns["idpcc"]};
	var cChild = new []{pccexpenseview.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccexpenseview",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccexpiringview.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccexpiringview",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccpaymentview.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccpaymentview",cPar,cChild,false));

	cPar = new []{pcc.Columns["idpcc"]};
	cChild = new []{pccsendview.Columns["idpcc"]};
	Relations.Add(new DataRelation("FK_pcc_pccsendview",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_pcc",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_pcc",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_pcc",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_pcc",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{pcc.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_pcc",cPar,cChild,false));

	#endregion

}
}
}
