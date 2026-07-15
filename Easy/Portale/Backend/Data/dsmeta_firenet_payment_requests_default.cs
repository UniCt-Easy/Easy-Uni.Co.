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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_payment_requests_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_payment_requests_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_years 		=> (MetaTable)Tables["firenet_years"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_payment_requests 		=> (MetaTable)Tables["firenet_payment_requests"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_payment_requests_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_payment_requests_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_payment_requests_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_payment_requests_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_YEARS /////////////////////////////////
	var tfirenet_years= new MetaTable("firenet_years");
	tfirenet_years.defineColumn("id", typeof(int),false);
	Tables.Add(tfirenet_years);
	tfirenet_years.defineKey("id");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// FIRENET_PAYMENT_REQUESTS /////////////////////////////////
	var tfirenet_payment_requests= new MetaTable("firenet_payment_requests");
	tfirenet_payment_requests.defineColumn("aa", typeof(int));
	tfirenet_payment_requests.defineColumn("anagrafica_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("cap_debitore", typeof(decimal));
	tfirenet_payment_requests.defineColumn("causale_bollettino", typeof(string));
	tfirenet_payment_requests.defineColumn("codice_a_barre", typeof(decimal));
	tfirenet_payment_requests.defineColumn("codice_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("codice_fiscale_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("codice_identificativo_bollettino", typeof(decimal));
	tfirenet_payment_requests.defineColumn("codice_servizio", typeof(decimal));
	tfirenet_payment_requests.defineColumn("codice_sia", typeof(decimal));
	tfirenet_payment_requests.defineColumn("codice_sottoservizio", typeof(decimal));
	tfirenet_payment_requests.defineColumn("created", typeof(DateTime));
	tfirenet_payment_requests.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_payment_requests.defineColumn("email_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("id", typeof(int),false);
	tfirenet_payment_requests.defineColumn("id_transazione", typeof(decimal));
	tfirenet_payment_requests.defineColumn("identificativo_disposizione", typeof(decimal));
	tfirenet_payment_requests.defineColumn("importo", typeof(decimal));
	tfirenet_payment_requests.defineColumn("indirizzo_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("informazioni_pagamento", typeof(decimal));
	tfirenet_payment_requests.defineColumn("localita_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("modified", typeof(DateTime));
	tfirenet_payment_requests.defineColumn("numero_lista", typeof(decimal));
	tfirenet_payment_requests.defineColumn("parsed", typeof(int));
	tfirenet_payment_requests.defineColumn("payment_type_id", typeof(int));
	tfirenet_payment_requests.defineColumn("preiscription_id", typeof(decimal));
	tfirenet_payment_requests.defineColumn("provincia_debitore", typeof(string));
	tfirenet_payment_requests.defineColumn("scadenza", typeof(string));
	tfirenet_payment_requests.defineColumn("student_id", typeof(decimal));
	tfirenet_payment_requests.defineColumn("tax_id", typeof(decimal));
	tfirenet_payment_requests.defineColumn("tax_type_id", typeof(int));
	tfirenet_payment_requests.defineColumn("valore_codice_a_barre", typeof(decimal));
	Tables.Add(tfirenet_payment_requests);
	tfirenet_payment_requests.defineKey("id");

	#endregion

}
}
}
