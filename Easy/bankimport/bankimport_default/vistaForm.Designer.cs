
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
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_bankimport;
using meta_banktransaction;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace bankimport_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Importazione esiti e sospesi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public bankimportTable bankimport 		=> (bankimportTable)Tables["bankimport"];

	///<summary>
	///Operazione su Partita Pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bankimportbill 		=> (MetaTable)Tables["bankimportbill"];

	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public banktransactionTable banktransaction 		=> (banktransactionTable)Tables["banktransaction"];

	///<summary>
	///Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bank 		=> (MetaTable)Tables["bank"];

	///<summary>
	///Operazione su sospeso (bolletta)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable billtransaction 		=> (MetaTable)Tables["billtransaction"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// BANKIMPORT /////////////////////////////////
	var tbankimport= new bankimportTable();
	tbankimport.addBaseColumns("idbankimport","lastpayment","lastproceeds","lastbillincome","lastbillexpense","totalpayment","totalproceeds","totalbillincome_plus","totalbillincome_minus","totalbillexpense_plus","totalbillexpense_minus","idbank","ct","cu","lt","lu","ayear","adate","identificativo_flusso_bt");
	Tables.Add(tbankimport);
	tbankimport.defineKey("idbankimport");

	//////////////////// BANKIMPORTBILL /////////////////////////////////
	var tbankimportbill= new MetaTable("bankimportbill");
	tbankimportbill.defineColumn("idbankimport", typeof(int),false);
	tbankimportbill.defineColumn("iddetail", typeof(int),false);
	tbankimportbill.defineColumn("billkind", typeof(string),false);
	tbankimportbill.defineColumn("ybill", typeof(short),false);
	tbankimportbill.defineColumn("nbill", typeof(int));
	tbankimportbill.defineColumn("banknum", typeof(int),false);
	tbankimportbill.defineColumn("amount", typeof(decimal));
	tbankimportbill.defineColumn("motive", typeof(string));
	tbankimportbill.defineColumn("registry", typeof(string));
	tbankimportbill.defineColumn("adate", typeof(DateTime));
	tbankimportbill.defineColumn("notes", typeof(string));
	tbankimportbill.defineColumn("bankcode", typeof(string));
	tbankimportbill.defineColumn("ct", typeof(DateTime));
	tbankimportbill.defineColumn("cu", typeof(string));
	tbankimportbill.defineColumn("lt", typeof(DateTime));
	tbankimportbill.defineColumn("lu", typeof(string));
	tbankimportbill.defineColumn("idbank", typeof(string));
	tbankimportbill.defineColumn("idtreasurer", typeof(int));
	Tables.Add(tbankimportbill);
	tbankimportbill.defineKey("idbankimport", "iddetail");

	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new banktransactionTable();
	tbanktransaction.addBaseColumns("nban","yban","amount","bankreference","kind","transactiondate","valuedate","idpay","idpro","ct","cu","lt","lu","idexp","idinc","kpay","kpro","idbankimport","motive","nbill");
	Tables.Add(tbanktransaction);
	tbanktransaction.defineKey("nban", "yban");

	//////////////////// BANK /////////////////////////////////
	var tbank= new MetaTable("bank");
	tbank.defineColumn("idbank", typeof(string),false);
	tbank.defineColumn("ct", typeof(DateTime),false);
	tbank.defineColumn("cu", typeof(string),false);
	tbank.defineColumn("description", typeof(string),false);
	tbank.defineColumn("flagusable", typeof(string));
	tbank.defineColumn("lt", typeof(DateTime),false);
	tbank.defineColumn("lu", typeof(string),false);
	Tables.Add(tbank);
	tbank.defineKey("idbank");

	//////////////////// BILLTRANSACTION /////////////////////////////////
	var tbilltransaction= new MetaTable("billtransaction");
	tbilltransaction.defineColumn("ybilltran", typeof(short),false);
	tbilltransaction.defineColumn("nbilltran", typeof(int),false);
	tbilltransaction.defineColumn("nbill", typeof(int),false);
	tbilltransaction.defineColumn("amount", typeof(decimal),false);
	tbilltransaction.defineColumn("adate", typeof(DateTime));
	tbilltransaction.defineColumn("kind", typeof(string));
	tbilltransaction.defineColumn("idbankimport", typeof(int));
	tbilltransaction.defineColumn("ct", typeof(DateTime));
	tbilltransaction.defineColumn("cu", typeof(string));
	tbilltransaction.defineColumn("lt", typeof(DateTime));
	tbilltransaction.defineColumn("lu", typeof(string));
	Tables.Add(tbilltransaction);
	tbilltransaction.defineKey("ybilltran", "nbilltran");

	#endregion


	#region DataRelation creation
	this.defineRelation("bankimport_billtransaction","bankimport","billtransaction","idbankimport");
	this.defineRelation("bankimport_banktransaction","bankimport","banktransaction","idbankimport");
	this.defineRelation("bankimport_bankimportbill","bankimport","bankimportbill","idbankimport");
	this.defineRelation("bank_bankimport","bank","bankimport","idbank");
	#endregion

}
}
}
