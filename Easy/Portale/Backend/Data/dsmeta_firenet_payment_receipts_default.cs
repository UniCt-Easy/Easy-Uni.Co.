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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_payment_receipts_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_payment_receipts_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_years 		=> (MetaTable)Tables["firenet_years"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_payment_receipts 		=> (MetaTable)Tables["firenet_payment_receipts"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_payment_receipts_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_payment_receipts_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_payment_receipts_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_payment_receipts_default.xsd";

	#region create DataTables
	//////////////////// FIRENET_YEARS /////////////////////////////////
	var tfirenet_years= new MetaTable("firenet_years");
	tfirenet_years.defineColumn("id", typeof(int),false);
	Tables.Add(tfirenet_years);
	tfirenet_years.defineKey("id");

	//////////////////// FIRENET_PAYMENT_RECEIPTS /////////////////////////////////
	var tfirenet_payment_receipts= new MetaTable("firenet_payment_receipts");
	tfirenet_payment_receipts.defineColumn("codice_debitore", typeof(string));
	tfirenet_payment_receipts.defineColumn("created", typeof(DateTime));
	tfirenet_payment_receipts.defineColumn("data_valuta", typeof(string));
	tfirenet_payment_receipts.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_payment_receipts.defineColumn("filename", typeof(string));
	tfirenet_payment_receipts.defineColumn("id", typeof(int),false);
	tfirenet_payment_receipts.defineColumn("id_transazione", typeof(string));
	tfirenet_payment_receipts.defineColumn("importo", typeof(decimal));
	tfirenet_payment_receipts.defineColumn("modified", typeof(DateTime));
	tfirenet_payment_receipts.defineColumn("operator_user_id", typeof(int));
	tfirenet_payment_receipts.defineColumn("payment_request_id", typeof(string));
	tfirenet_payment_receipts.defineColumn("xml", typeof(string));
	Tables.Add(tfirenet_payment_receipts);
	tfirenet_payment_receipts.defineKey("id");

	#endregion

}
}
}
