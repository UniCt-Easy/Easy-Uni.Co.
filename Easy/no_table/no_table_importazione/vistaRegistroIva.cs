/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("vistaRegistroIva"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaRegistroIva: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivaregister 		=> Tables["ivaregister"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivaregisterkind 		=> Tables["ivaregisterkind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaRegistroIva(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaRegistroIva (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaRegistroIva";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaRegistroIva.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// IVAREGISTER /////////////////////////////////
	var tivaregister= new DataTable("ivaregister");
	C= new DataColumn("nivaregister", typeof(int));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("yivaregister", typeof(short));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	tivaregister.Columns.Add( new DataColumn("protocolnum", typeof(int)));
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivaregister.Columns.Add(C);
	tivaregister.Columns.Add( new DataColumn("emails", typeof(string)));
	Tables.Add(tivaregister);
	tivaregister.PrimaryKey =  new DataColumn[]{tivaregister.Columns["nivaregister"], tivaregister.Columns["yivaregister"], tivaregister.Columns["idivaregisterkind"]};


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("txt", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
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
	tinvoice.Columns.Add( new DataColumn("autoinvoice", typeof(string)));
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
	tinvoice.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("toincludeinpaymentindicator", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("resendingpcc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("touniqueregister", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idstampkind", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("flag_auto_split_payment", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idsdi_acquisto", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsdi_vendita", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("flag_reverse_charge", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_acq", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_acq", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(string)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["ninv"], tinvoice.Columns["yinv"], tinvoice.Columns["idinvkind"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
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
	tinvoicekind.Columns.Add( new DataColumn("address", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("header", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes1", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes2", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("notes3", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// IVAREGISTERKIND /////////////////////////////////
	var tivaregisterkind= new DataTable("ivaregisterkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("idivaregisterkindunified", typeof(string)));
	tivaregisterkind.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("codeivaregisterkind", typeof(string));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(int));
	C.AllowDBNull=false;
	tivaregisterkind.Columns.Add(C);
	tivaregisterkind.Columns.Add( new DataColumn("compensation", typeof(string)));
	tivaregisterkind.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tivaregisterkind);
	tivaregisterkind.PrimaryKey =  new DataColumn[]{tivaregisterkind.Columns["idivaregisterkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{invoicekind.Columns["idinvkind"]};
	var cChild = new []{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_invoicekind",cPar,cChild,false));

	cPar = new []{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	cChild = new []{ivaregister.Columns["ninv"], ivaregister.Columns["yinv"], ivaregister.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_ivaregister_invoice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{ivaregister.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_ivaregister_invoicekind",cPar,cChild,false));

	cPar = new []{ivaregisterkind.Columns["idivaregisterkind"]};
	cChild = new []{ivaregister.Columns["idivaregisterkind"]};
	Relations.Add(new DataRelation("FK_ivaregister_ivaregisterkind",cPar,cChild,false));

	#endregion

}
}
}
