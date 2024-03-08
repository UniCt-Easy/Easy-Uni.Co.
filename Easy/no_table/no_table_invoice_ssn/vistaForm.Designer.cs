
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
using System.Globalization;
namespace no_table_invoice_ssn {
[System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
[DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable no_table		{get { return Tables["no_table"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable invoice		{get { return Tables["invoice"];}}
	#endregion


[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// no_table /////////////////////////////////
	T= new DataTable("no_table");
	C= new DataColumn("idnotable", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idnotable"]};


	//////////////////// invoice /////////////////////////////////
	T= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yinv", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ninv", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	C= new DataColumn("adate", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("autoinvoice", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(System.String)));
	T.Columns.Add( new DataColumn("docdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("exchangerate", typeof(System.Double)));
	T.Columns.Add( new DataColumn("flag", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("flag_ddt", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagdeferred", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagintracom", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idblacklist", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idcountry_destination", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idcountry_origin", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idcurrency", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("idintrastatkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("idintrastatpaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idinvkind_real", typeof(System.Int32)));
	C= new DataColumn("idreg", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor01", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idtreasurer", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("iso_destination", typeof(System.String)));
	T.Columns.Add( new DataColumn("iso_origin", typeof(System.String)));
	T.Columns.Add( new DataColumn("iso_payment", typeof(System.String)));
	T.Columns.Add( new DataColumn("iso_provenance", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ninv_real", typeof(System.Int32)));
	C= new DataColumn("officiallyprinted", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("packinglistdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("packinglistnum", typeof(System.String)));
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("registryreference", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("yinv_real", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("protocoldate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idfepaymethod", typeof(System.String)));
	T.Columns.Add( new DataColumn("idfepaymethodcondition", typeof(System.String)));
	T.Columns.Add( new DataColumn("nelectronicinvoice", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("yelectronicinvoice", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("annotations", typeof(System.String)));
	T.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(System.String)));
	T.Columns.Add( new DataColumn("toincludeinpaymentindicator", typeof(System.String)));
	T.Columns.Add( new DataColumn("resendingpcc", typeof(System.String)));
	T.Columns.Add( new DataColumn("touniqueregister", typeof(System.String)));
	T.Columns.Add( new DataColumn("idstampkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsdi_acquisto", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("flag_auto_split_payment", typeof(System.String)));
	T.Columns.Add( new DataColumn("flag_enable_split_payment", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsdi_vendita", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("flag_reverse_charge", typeof(System.String)));
	T.Columns.Add( new DataColumn("ipa_acq", typeof(System.String)));
	T.Columns.Add( new DataColumn("ipa_ven_cliente", typeof(System.String)));
	T.Columns.Add( new DataColumn("ipa_ven_emittente", typeof(System.String)));
	T.Columns.Add( new DataColumn("rifamm_acq", typeof(System.String)));
	T.Columns.Add( new DataColumn("rifamm_ven_cliente", typeof(System.String)));
	T.Columns.Add( new DataColumn("rifamm_ven_emittente", typeof(System.String)));
	T.Columns.Add( new DataColumn("ssnflagtipospesa", typeof(System.String)));
	T.Columns.Add( new DataColumn("ssntipospesa", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagbit", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("idinvkind_forwarder", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("ninv_forwarder", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("yinv_forwarder", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("ssn_nprot", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinvkind"], T.Columns["yinv"], T.Columns["ninv"]};


	#endregion

}
}
}
