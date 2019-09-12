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
namespace banktransaction_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransaction 		=> Tables["banktransaction"];

	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment 		=> Tables["payment"];

	///<summary>
	///Documento di incasso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds 		=> Tables["proceeds"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransactionview 		=> Tables["banktransactionview"];

	///<summary>
	///Classificazione su Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransactionsorting 		=> Tables["banktransactionsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	///<summary>
	///Importazione esiti e sospesi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bankimport 		=> Tables["bankimport"];

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
	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new DataTable("banktransaction");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("bankreference", typeof(string)));
	tbanktransaction.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransaction.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("kpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idpro", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	Tables.Add(tbanktransaction);
	tbanktransaction.PrimaryKey =  new DataColumn[]{tbanktransaction.Columns["yban"], tbanktransaction.Columns["nban"]};


	//////////////////// PAYMENT /////////////////////////////////
	var tpayment= new DataTable("payment");
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("npay_treasurer", typeof(int)));
	tpayment.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idman", typeof(int)));
	tpayment.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("txt", typeof(string)));
	tpayment.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment.Columns.Add(C);
	tpayment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayment.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	Tables.Add(tpayment);
	tpayment.PrimaryKey =  new DataColumn[]{tpayment.Columns["kpay"]};


	//////////////////// PROCEEDS /////////////////////////////////
	var tproceeds= new DataTable("proceeds");
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("npro_treasurer", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idreg", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idfin", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tproceeds.Columns.Add( new DataColumn("txt", typeof(string)));
	tproceeds.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	tproceeds.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	Tables.Add(tproceeds);
	tproceeds.PrimaryKey =  new DataColumn[]{tproceeds.Columns["kpro"]};


	//////////////////// BANKTRANSACTIONVIEW /////////////////////////////////
	var tbanktransactionview= new DataTable("banktransactionview");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("bankreference", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransactionview.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransactionview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransactionview.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypay", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npro", typeof(int)));
	C= new DataColumn("income", typeof(decimal));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("expense", typeof(decimal));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("yexp", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("nexp", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("yinc", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("ninc", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	Tables.Add(tbanktransactionview);

	//////////////////// BANKTRANSACTIONSORTING /////////////////////////////////
	var tbanktransactionsorting= new DataTable("banktransactionsorting");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransactionsorting.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransactionsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tbanktransactionsorting.Columns.Add(C);
	tbanktransactionsorting.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("!tipoclass", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionsorting.Columns.Add(C);
	C= new DataColumn("!codiceclass", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionsorting.Columns.Add(C);
	C= new DataColumn("!descrizione", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionsorting.Columns.Add(C);
	tbanktransactionsorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbanktransactionsorting.Columns.Add( new DataColumn("cu", typeof(string)));
	tbanktransactionsorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbanktransactionsorting.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tbanktransactionsorting);
	tbanktransactionsorting.PrimaryKey =  new DataColumn[]{tbanktransactionsorting.Columns["yban"], tbanktransactionsorting.Columns["nban"], tbanktransactionsorting.Columns["idsor"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("kpay", typeof(int)));
	C= new DataColumn("ypay", typeof(short));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	Tables.Add(texpenseview);
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingview.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	//////////////////// BANKIMPORT /////////////////////////////////
	var tbankimport= new DataTable("bankimport");
	C= new DataColumn("idbankimport", typeof(int));
	C.AllowDBNull=false;
	tbankimport.Columns.Add(C);
	tbankimport.Columns.Add( new DataColumn("lastpayment", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastproceeds", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastbillincome", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastbillexpense", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("totalpayment", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalproceeds", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillincome_plus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillincome_minus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillexpense_plus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillexpense_minus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("idbank", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("cu", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lu", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("ayear", typeof(short)));
	Tables.Add(tbankimport);
	tbankimport.PrimaryKey =  new DataColumn[]{tbankimport.Columns["idbankimport"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payment.Columns["kpay"]};
	var cChild = new []{expenseview.Columns["kpay"]};
	Relations.Add(new DataRelation("paymentexpenseview",cPar,cChild,false));

	cPar = new []{proceeds.Columns["kpro"]};
	cChild = new []{incomeview.Columns["kpro"]};
	Relations.Add(new DataRelation("proceedsincomeview",cPar,cChild,false));

	cPar = new []{banktransaction.Columns["yban"], banktransaction.Columns["nban"]};
	cChild = new []{banktransactionsorting.Columns["yban"], banktransactionsorting.Columns["nban"]};
	Relations.Add(new DataRelation("banktransaction_banktransactionsorting",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{banktransactionsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingviewbanktransactionsorting",cPar,cChild,false));

	cPar = new []{proceeds.Columns["kpro"]};
	cChild = new []{banktransaction.Columns["kpro"]};
	Relations.Add(new DataRelation("proceedsbanktransaction",cPar,cChild,false));

	cPar = new []{payment.Columns["kpay"]};
	cChild = new []{banktransaction.Columns["kpay"]};
	Relations.Add(new DataRelation("paymentbanktransaction",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"], expenseview.Columns["idpay"]};
	cChild = new []{banktransaction.Columns["idexp"], banktransaction.Columns["idpay"]};
	Relations.Add(new DataRelation("expenseviewbanktransaction",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"], incomeview.Columns["idpro"]};
	cChild = new []{banktransaction.Columns["idinc"], banktransaction.Columns["idpro"]};
	Relations.Add(new DataRelation("incomeviewbanktransaction",cPar,cChild,false));

	cPar = new []{bankimport.Columns["idbankimport"]};
	cChild = new []{banktransaction.Columns["idbankimport"]};
	Relations.Add(new DataRelation("bankimport_banktransaction",cPar,cChild,false));

	#endregion

}
}
}
