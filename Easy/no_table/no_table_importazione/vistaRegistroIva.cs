
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaRegistroIva")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaRegistroIva: DataSet {

	#region Table members declaration
	///<summary>
	///Registro iva
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable ivaregister		{get { return Tables["ivaregister"];}}
	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoice		{get { return Tables["invoice"];}}
	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable invoicekind		{get { return Tables["invoicekind"];}}
	///<summary>
	///Registro IVA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable ivaregisterkind		{get { return Tables["ivaregisterkind"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaRegistroIva(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaRegistroIva";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaRegistroIva.xsd";
	SchemaSerializationMode = SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// IVAREGISTER /////////////////////////////////
	T= new DataTable("ivaregister");
	C= new DataColumn("nivaregister", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yivaregister", typeof(Int16));
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
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("protocolnum", typeof(Int32)));
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nivaregister"], T.Columns["yivaregister"], T.Columns["idivaregisterkind"]};


	//////////////////// INVOICE /////////////////////////////////
	T= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("registryreference", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(Int16)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(Int16)));
	T.Columns.Add( new DataColumn("idcurrency", typeof(Int32)));
	T.Columns.Add( new DataColumn("exchangerate", typeof(Double)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("packinglistnum", typeof(String)));
	T.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("flagdeferred", typeof(String)));
	C= new DataColumn("officiallyprinted", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idtreasurer", typeof(Int32)));
	T.Columns.Add( new DataColumn("flagintracom", typeof(String)));
	T.Columns.Add( new DataColumn("iso_origin", typeof(String)));
	T.Columns.Add( new DataColumn("iso_provenance", typeof(String)));
	T.Columns.Add( new DataColumn("iso_destination", typeof(String)));
	T.Columns.Add( new DataColumn("idcountry_origin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idcountry_destination", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatkind", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("iso_payment", typeof(String)));
	T.Columns.Add( new DataColumn("flag_ddt", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idblacklist", typeof(Int32)));
	T.Columns.Add( new DataColumn("idinvkind_real", typeof(Int32)));
	T.Columns.Add( new DataColumn("yinv_real", typeof(Int16)));
	T.Columns.Add( new DataColumn("ninv_real", typeof(Int32)));
	T.Columns.Add( new DataColumn("autoinvoice", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idfepaymethodcondition", typeof(String)));
	T.Columns.Add( new DataColumn("idfepaymethod", typeof(String)));
	T.Columns.Add( new DataColumn("nelectronicinvoice", typeof(Int32)));
	T.Columns.Add( new DataColumn("yelectronicinvoice", typeof(Int16)));
	T.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(String)));
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("toincludeinpaymentindicator", typeof(String)));
	T.Columns.Add( new DataColumn("resendingpcc", typeof(String)));
	T.Columns.Add( new DataColumn("touniqueregister", typeof(String)));
	T.Columns.Add( new DataColumn("idstampkind", typeof(String)));
	T.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(String)));
	T.Columns.Add( new DataColumn("flag_auto_split_payment", typeof(String)));
	T.Columns.Add( new DataColumn("idsdi_acquisto", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsdi_vendita", typeof(Int32)));
	T.Columns.Add( new DataColumn("flag_reverse_charge", typeof(String)));
	T.Columns.Add( new DataColumn("ipa_acq", typeof(String)));
	T.Columns.Add( new DataColumn("rifamm_acq", typeof(String)));
	T.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(String)));
	T.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(String)));
	T.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(String)));
	T.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ninv"], T.Columns["yinv"], T.Columns["idinvkind"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	T= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(String)));
	T.Columns.Add( new DataColumn("formatstring", typeof(String)));
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idinvkind_auto", typeof(Int32)));
	T.Columns.Add( new DataColumn("printingcode", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	T.Columns.Add( new DataColumn("address", typeof(String)));
	T.Columns.Add( new DataColumn("header", typeof(String)));
	T.Columns.Add( new DataColumn("notes1", typeof(String)));
	T.Columns.Add( new DataColumn("notes2", typeof(String)));
	T.Columns.Add( new DataColumn("notes3", typeof(String)));
	T.Columns.Add( new DataColumn("ipa_fe", typeof(String)));
	T.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"]};


	//////////////////// IVAREGISTERKIND /////////////////////////////////
	T= new DataTable("ivaregisterkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("registerclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idivaregisterkindunified", typeof(String)));
	T.Columns.Add( new DataColumn("flagactivity", typeof(Int16)));
	C= new DataColumn("codeivaregisterkind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idivaregisterkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("compensation", typeof(String)));
	T.Columns.Add( new DataColumn("idtreasurer", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idivaregisterkind"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{invoicekind.Columns["idinvkind"]};
	CChild = new DataColumn[1]{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoice_invoicekind",CPar,CChild,false));

	CPar = new DataColumn[3]{invoice.Columns["ninv"], invoice.Columns["yinv"], invoice.Columns["idinvkind"]};
	CChild = new DataColumn[3]{ivaregister.Columns["ninv"], ivaregister.Columns["yinv"], ivaregister.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_ivaregister_invoice",CPar,CChild,false));

	CPar = new DataColumn[1]{invoicekind.Columns["idinvkind"]};
	CChild = new DataColumn[1]{ivaregister.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_ivaregister_invoicekind",CPar,CChild,false));

	CPar = new DataColumn[1]{ivaregisterkind.Columns["idivaregisterkind"]};
	CChild = new DataColumn[1]{ivaregister.Columns["idivaregisterkind"]};
	Relations.Add(new DataRelation("FK_ivaregister_ivaregisterkind",CPar,CChild,false));

	#endregion

}
}
}
