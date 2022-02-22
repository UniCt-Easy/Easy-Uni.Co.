
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace bankdispositionsetup_importnew {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill 		=> Tables["bill"];

	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransaction 		=> Tables["banktransaction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussobanca 		=> Tables["flussobanca"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds_bankview 		=> Tables["proceeds_bankview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment_bankview 		=> Tables["payment_bankview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable carime 		=> Tables["carime"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable EF06_TestaCoda 		=> Tables["EF06_TestaCoda"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable EF06 		=> Tables["EF06"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable IN0109 		=> Tables["IN0109"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable gdc 		=> Tables["gdc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable giornaledicassa 		=> Tables["giornaledicassa"];

	///<summary>
	///Operazione su sospeso (bolletta)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable billtransaction 		=> Tables["billtransaction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bppugliese 		=> Tables["bppugliese"];

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
	//////////////////// BILL /////////////////////////////////
	var tbill= new DataTable("bill");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill.Columns.Add( new DataColumn("active", typeof(string)));
	tbill.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tbill);
	tbill.PrimaryKey =  new DataColumn[]{tbill.Columns["ybill"], tbill.Columns["nbill"], tbill.Columns["billkind"]};


	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new DataTable("banktransaction");
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransaction.Columns.Add( new DataColumn("bankreference", typeof(string)));
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("kpro", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idpro", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idinc", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	Tables.Add(tbanktransaction);
	tbanktransaction.PrimaryKey =  new DataColumn[]{tbanktransaction.Columns["nban"], tbanktransaction.Columns["yban"]};


	//////////////////// FLUSSOBANCA /////////////////////////////////
	var tflussobanca= new DataTable("flussobanca");
	tflussobanca.Columns.Add( new DataColumn("SEGNO", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("tipomovbancario", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("NUMQUI", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("ISTTS", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("CODEN", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("ESERC", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("TIPDOC", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("NUMDOC", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("PRODOC", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("CAPBIL", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("ARTBIL", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("CDMEC", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("ANNOCO", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("IMPDOC", typeof(decimal)));
	tflussobanca.Columns.Add( new DataColumn("DTELAB", typeof(DateTime)));
	tflussobanca.Columns.Add( new DataColumn("DTPAG", typeof(DateTime)));
	tflussobanca.Columns.Add( new DataColumn("DVAL", typeof(DateTime)));
	tflussobanca.Columns.Add( new DataColumn("NUMDIS", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("IMPRIT", typeof(decimal)));
	tflussobanca.Columns.Add( new DataColumn("INDREG", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("DVALBE", typeof(DateTime)));
	tflussobanca.Columns.Add( new DataColumn("NUMPRA", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CODVER", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("NUMPRR", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("PROGPR", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("IBOLLI", typeof(decimal)));
	tflussobanca.Columns.Add( new DataColumn("INDBOL", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("ICOMM", typeof(decimal)));
	tflussobanca.Columns.Add( new DataColumn("INDCOM", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("ISPE", typeof(decimal)));
	tflussobanca.Columns.Add( new DataColumn("INDSPE", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("TPAGTS", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CODABI", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CODCAB", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CONTO", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CIN", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("IBAN_PAE", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("IBAN_CHK", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("IBAN_COO", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("NCNT", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CTIPIPU", typeof(int)));
	tflussobanca.Columns.Add( new DataColumn("DESVER", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CCGU", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CCPV", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CCUP", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("FILLER", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("ANABE", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("INDIR", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CAP", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("LOC", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CFISC", typeof(string)));
	tflussobanca.Columns.Add( new DataColumn("CAUSALE", typeof(string)));
	Tables.Add(tflussobanca);

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

	//////////////////// PROCEEDS_BANKVIEW /////////////////////////////////
	var tproceeds_bankview= new DataTable("proceeds_bankview");
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("idpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	tproceeds_bankview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	Tables.Add(tproceeds_bankview);
	tproceeds_bankview.PrimaryKey =  new DataColumn[]{tproceeds_bankview.Columns["kpro"], tproceeds_bankview.Columns["idpro"]};


	//////////////////// PAYMENT_BANKVIEW /////////////////////////////////
	var tpayment_bankview= new DataTable("payment_bankview");
	C= new DataColumn("kpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idpay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("ypay", typeof(short));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("npay", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	tpayment_bankview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayment_bankview.Columns.Add(C);
	Tables.Add(tpayment_bankview);
	tpayment_bankview.PrimaryKey =  new DataColumn[]{tpayment_bankview.Columns["kpay"], tpayment_bankview.Columns["idpay"]};


	//////////////////// CARIME /////////////////////////////////
	var tcarime= new DataTable("carime");
	tcarime.Columns.Add( new DataColumn("codiceistituto", typeof(int)));
	tcarime.Columns.Add( new DataColumn("codicedipendenza", typeof(int)));
	tcarime.Columns.Add( new DataColumn("codiceente", typeof(int)));
	tcarime.Columns.Add( new DataColumn("codiceesercizio", typeof(int)));
	tcarime.Columns.Add( new DataColumn("codicedivisaente", typeof(string)));
	tcarime.Columns.Add( new DataColumn("abi", typeof(int)));
	tcarime.Columns.Add( new DataColumn("cab", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numeroconto", typeof(string)));
	tcarime.Columns.Add( new DataColumn("datamovimento", typeof(DateTime)));
	tcarime.Columns.Add( new DataColumn("tipomovimento", typeof(string)));
	tcarime.Columns.Add( new DataColumn("numdocumento", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numsub", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numricevuta", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numcapitolo", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numarticolo", typeof(int)));
	tcarime.Columns.Add( new DataColumn("annoresiduo", typeof(int)));
	tcarime.Columns.Add( new DataColumn("codicedivisacliente", typeof(string)));
	tcarime.Columns.Add( new DataColumn("importodivisacliente", typeof(decimal)));
	tcarime.Columns.Add( new DataColumn("importoricevuta", typeof(decimal)));
	tcarime.Columns.Add( new DataColumn("segno", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codiceesecuzione", typeof(int)));
	tcarime.Columns.Add( new DataColumn("codicebolli", typeof(int)));
	tcarime.Columns.Add( new DataColumn("importibolli", typeof(decimal)));
	tcarime.Columns.Add( new DataColumn("codicespese", typeof(int)));
	tcarime.Columns.Add( new DataColumn("importospese", typeof(decimal)));
	tcarime.Columns.Add( new DataColumn("datavaluta", typeof(DateTime)));
	tcarime.Columns.Add( new DataColumn("numdocrif", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numsubrif", typeof(int)));
	tcarime.Columns.Add( new DataColumn("abicliente", typeof(int)));
	tcarime.Columns.Add( new DataColumn("cabcliente", typeof(int)));
	tcarime.Columns.Add( new DataColumn("descrizionecliente", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codicecausale", typeof(int)));
	tcarime.Columns.Add( new DataColumn("causale1", typeof(string)));
	tcarime.Columns.Add( new DataColumn("causale2", typeof(string)));
	tcarime.Columns.Add( new DataColumn("causale3", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codicetipoimputazione", typeof(string)));
	tcarime.Columns.Add( new DataColumn("imputazionefruttifera", typeof(int)));
	tcarime.Columns.Add( new DataColumn("imputazioneinfruttifera", typeof(int)));
	tcarime.Columns.Add( new DataColumn("imputazionevincolata", typeof(int)));
	tcarime.Columns.Add( new DataColumn("imputazionedelegazioni", typeof(int)));
	tcarime.Columns.Add( new DataColumn("imputazionegiornaliera", typeof(int)));
	tcarime.Columns.Add( new DataColumn("destfruttiferainfruttifera", typeof(int)));
	tcarime.Columns.Add( new DataColumn("indicatoreadisposizione", typeof(int)));
	tcarime.Columns.Add( new DataColumn("entratauscita", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codicedivisaesercizio", typeof(string)));
	tcarime.Columns.Add( new DataColumn("importodivisaente", typeof(decimal)));
	tcarime.Columns.Add( new DataColumn("space01", typeof(string)));
	tcarime.Columns.Add( new DataColumn("space02", typeof(string)));
	tcarime.Columns.Add( new DataColumn("space03", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codiceresiduo", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numerosubcaricati", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numerosottoconto", typeof(string)));
	tcarime.Columns.Add( new DataColumn("cf", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codicefornitore", typeof(int)));
	tcarime.Columns.Add( new DataColumn("numerocro", typeof(string)));
	tcarime.Columns.Add( new DataColumn("numeroassegnoda", typeof(string)));
	tcarime.Columns.Add( new DataColumn("numeroassegnoa", typeof(string)));
	tcarime.Columns.Add( new DataColumn("descrizionecausaleaggiuntiva", typeof(string)));
	tcarime.Columns.Add( new DataColumn("codicebeneficiario", typeof(string)));
	tcarime.Columns.Add( new DataColumn("filler", typeof(string)));
	tcarime.Columns.Add( new DataColumn("tipdoc", typeof(string)));
	tcarime.Columns.Add( new DataColumn("indreg", typeof(string)));
	Tables.Add(tcarime);

	//////////////////// EF06_TESTACODA /////////////////////////////////
	var tEF06_TestaCoda= new DataTable("EF06_TestaCoda");
	tEF06_TestaCoda.Columns.Add( new DataColumn("ISTTS1", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("FILTESE", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("CODENT1", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("ESERC1", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("TIPREC", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("WA035", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("WA040", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("FILLER", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("NOINC", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNO1", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("ITOIN2", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("NOPPAG", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNOP", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("ITOPA2", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNOG", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IGIACZ", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IUTANZ", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IVIANZ", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IPROI1", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IPROP1", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IFCPR1", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNOF", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("BYTLEU", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("NOINC_", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNO1_", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("ITOIN2_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("NOPPAG_", typeof(int)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNOP_", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("ITOPA2_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNOG_", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IGIACZ_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IUTANZ_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IVIANZ_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IPROI1_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IPROP1_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("IFCPR1_", typeof(decimal)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("SEGNOF_", typeof(string)));
	tEF06_TestaCoda.Columns.Add( new DataColumn("BYTLEU_", typeof(string)));
	Tables.Add(tEF06_TestaCoda);

	//////////////////// EF06 /////////////////////////////////
	var tEF06= new DataTable("EF06");
	tEF06.Columns.Add( new DataColumn("ISTTS1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("FILTESE", typeof(string)));
	tEF06.Columns.Add( new DataColumn("CODENT1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("ESERC1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("TIPREC", typeof(string)));
	tEF06.Columns.Add( new DataColumn("TIPDOC", typeof(string)));
	tEF06.Columns.Add( new DataColumn("NUMDO1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("PRODO1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("CAPBI2", typeof(int)));
	tEF06.Columns.Add( new DataColumn("ARBTI2", typeof(int)));
	tEF06.Columns.Add( new DataColumn("ANNOC1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("IMPMA1", typeof(decimal)));
	tEF06.Columns.Add( new DataColumn("SEGNOP", typeof(string)));
	tEF06.Columns.Add( new DataColumn("DTPAG9", typeof(DateTime)));
	tEF06.Columns.Add( new DataColumn("DVALP2", typeof(DateTime)));
	tEF06.Columns.Add( new DataColumn("PROST1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("ANABE", typeof(string)));
	tEF06.Columns.Add( new DataColumn("DCAP", typeof(string)));
	tEF06.Columns.Add( new DataColumn("CODGEN", typeof(string)));
	tEF06.Columns.Add( new DataColumn("IMPRI1", typeof(decimal)));
	tEF06.Columns.Add( new DataColumn("INDREG", typeof(string)));
	tEF06.Columns.Add( new DataColumn("DESTU", typeof(string)));
	tEF06.Columns.Add( new DataColumn("INDCBI", typeof(string)));
	tEF06.Columns.Add( new DataColumn("CAUTS", typeof(string)));
	tEF06.Columns.Add( new DataColumn("NUMOA1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("PROGA1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("DVALB2", typeof(DateTime)));
	tEF06.Columns.Add( new DataColumn("CODVER", typeof(string)));
	tEF06.Columns.Add( new DataColumn("NUMPRA", typeof(string)));
	tEF06.Columns.Add( new DataColumn("DESVER", typeof(string)));
	tEF06.Columns.Add( new DataColumn("NUMPR1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("PROGP1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("MANRI1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("PRORI1", typeof(string)));
	tEF06.Columns.Add( new DataColumn("DTELT2", typeof(DateTime)));
	tEF06.Columns.Add( new DataColumn("IBOLL1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("INDBOL", typeof(string)));
	tEF06.Columns.Add( new DataColumn("ICOMT1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("INDCOM", typeof(string)));
	tEF06.Columns.Add( new DataColumn("ISPEP1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("INDSPT", typeof(string)));
	tEF06.Columns.Add( new DataColumn("BYTLEU", typeof(string)));
	tEF06.Columns.Add( new DataColumn("BYTLEC", typeof(string)));
	tEF06.Columns.Add( new DataColumn("INDMO", typeof(string)));
	tEF06.Columns.Add( new DataColumn("INDSI", typeof(string)));
	tEF06.Columns.Add( new DataColumn("TPAGTS", typeof(int)));
	tEF06.Columns.Add( new DataColumn("CABIT1", typeof(int)));
	tEF06.Columns.Add( new DataColumn("CABDTX", typeof(int)));
	tEF06.Columns.Add( new DataColumn("NUMBO", typeof(string)));
	tEF06.Columns.Add( new DataColumn("CINRT", typeof(string)));
	tEF06.Columns.Add( new DataColumn("CDMEC2", typeof(long)));
	tEF06.Columns.Add( new DataColumn("IMPMA2", typeof(decimal)));
	tEF06.Columns.Add( new DataColumn("FILLER", typeof(string)));
	Tables.Add(tEF06);

	//////////////////// IN0109 /////////////////////////////////
	var tIN0109= new DataTable("IN0109");
	tIN0109.Columns.Add( new DataColumn("ISTTS", typeof(int)));
	tIN0109.Columns.Add( new DataColumn("CODEN", typeof(int)));
	tIN0109.Columns.Add( new DataColumn("ESERC", typeof(int)));
	tIN0109.Columns.Add( new DataColumn("DESC", typeof(string)));
	tIN0109.Columns.Add( new DataColumn("NDG", typeof(long)));
	tIN0109.Columns.Add( new DataColumn("DTELAB", typeof(DateTime)));
	tIN0109.Columns.Add( new DataColumn("FILTS", typeof(int)));
	tIN0109.Columns.Add( new DataColumn("SEG_FDO", typeof(string)));
	tIN0109.Columns.Add( new DataColumn("FDO", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("REV_INC", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("REV_CAR", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("IMP_PPI", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("MAN_PAG", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("MAN_CAR", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("IMP_PPP", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("SAL_DIR", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("SAL_FAT", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("FIDO", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("IMP_LIB", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("IMP_NTU", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("IMP_TU", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("IMP_ANT", typeof(decimal)));
	tIN0109.Columns.Add( new DataColumn("FILLER", typeof(string)));
	Tables.Add(tIN0109);

	//////////////////// GDC /////////////////////////////////
	var tgdc= new DataTable("gdc");
	tgdc.Columns.Add( new DataColumn("TIPORECORD1", typeof(int)));
	tgdc.Columns.Add( new DataColumn("PROGRESSIVODIFLUSSO1", typeof(int)));
	tgdc.Columns.Add( new DataColumn("TIPOFLUSSO", typeof(int)));
	tgdc.Columns.Add( new DataColumn("DATAPRODUZIONEFLUSSO", typeof(DateTime)));
	tgdc.Columns.Add( new DataColumn("PROGRESSIVOPERDATA", typeof(int)));
	tgdc.Columns.Add( new DataColumn("CODICEFILIALE", typeof(int)));
	tgdc.Columns.Add( new DataColumn("CODICEENTE", typeof(int)));
	tgdc.Columns.Add( new DataColumn("ANAGRAFICAENTE", typeof(string)));
	tgdc.Columns.Add( new DataColumn("ESERCIZIOFINANZIARIO", typeof(int)));
	tgdc.Columns.Add( new DataColumn("DATADIRIFERIMENTO", typeof(DateTime)));
	tgdc.Columns.Add( new DataColumn("DIVISA", typeof(string)));
	tgdc.Columns.Add( new DataColumn("FILLER1", typeof(string)));
	tgdc.Columns.Add( new DataColumn("TIPORECORD3", typeof(string)));
	tgdc.Columns.Add( new DataColumn("PROGRESSIVODIFLUSSO3", typeof(string)));
	tgdc.Columns.Add( new DataColumn("RISCOSSIONIGIORNATA", typeof(string)));
	tgdc.Columns.Add( new DataColumn("PAGAMENTIGIORNATA", typeof(string)));
	tgdc.Columns.Add( new DataColumn("RISCOSSIONIGIORNATEPRECEDENTI", typeof(string)));
	tgdc.Columns.Add( new DataColumn("PAGAMENTIGIORNATEPRECEDENTI", typeof(string)));
	tgdc.Columns.Add( new DataColumn("RISCOSSIONITOTALI", typeof(string)));
	tgdc.Columns.Add( new DataColumn("PAGAMENTITOTALI", typeof(string)));
	tgdc.Columns.Add( new DataColumn("SALDOINIZIALE", typeof(string)));
	tgdc.Columns.Add( new DataColumn("SALDOALLADATARIFERIMENTO", typeof(string)));
	tgdc.Columns.Add( new DataColumn("SALDOFRUTTIFERO", typeof(string)));
	tgdc.Columns.Add( new DataColumn("SALDOINFRUTTIFERO", typeof(string)));
	tgdc.Columns.Add( new DataColumn("ECCEDENZAGIACENZAMASSIMA", typeof(string)));
	tgdc.Columns.Add( new DataColumn("FILLER3", typeof(string)));
	Tables.Add(tgdc);

	//////////////////// GIORNALEDICASSA /////////////////////////////////
	var tgiornaledicassa= new DataTable("giornaledicassa");
	tgiornaledicassa.Columns.Add( new DataColumn("DATAPRODUZIONEFLUSSO", typeof(DateTime)));
	tgiornaledicassa.Columns.Add( new DataColumn("CODICEFILIALE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("CODICEENTE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("ESERCIZIOFINANZIARIO", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("DATADIRIFERIMENTO", typeof(DateTime)));
	tgiornaledicassa.Columns.Add( new DataColumn("TIPORECORD", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("PROGRESSIVODIFLUSSO", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("NUMEROORDINATIVO_O_CARTACONTABILE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("PROGRESSIVODISPOSIZIONE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("FLAGORDINATIVO_CARTACONTABILE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("BENEFICIARIO_O_OBBLIGATO", typeof(string)));
	tgiornaledicassa.Columns.Add( new DataColumn("FLAGCOMPETENZA_RESIDUI", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("FLAGENTRATE_USCITE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("IMPORTO", typeof(decimal)));
	tgiornaledicassa.Columns.Add( new DataColumn("FLAGFRUTTIFERO_INFRUTTIFERO", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("IMPORTOFRUTTIFERO", typeof(decimal)));
	tgiornaledicassa.Columns.Add( new DataColumn("STORNO", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("BOLLETTA", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("CONTOCORRENTE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("DATAVALUTA", typeof(DateTime)));
	tgiornaledicassa.Columns.Add( new DataColumn("VALUTASPECIALE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("GIROFONDI", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("DIVISAOPERAZIONE", typeof(string)));
	tgiornaledicassa.Columns.Add( new DataColumn("CONTROVALOREDIVISAOPERAZIONE", typeof(decimal)));
	tgiornaledicassa.Columns.Add( new DataColumn("MODALITADIESECUZIONE", typeof(string)));
	tgiornaledicassa.Columns.Add( new DataColumn("CARTACONTABILE", typeof(int)));
	tgiornaledicassa.Columns.Add( new DataColumn("DATIRISERVATIALLENTE", typeof(string)));
	tgiornaledicassa.Columns.Add( new DataColumn("DESCRIZIONEOPERAZIONE", typeof(string)));
	tgiornaledicassa.Columns.Add( new DataColumn("CRO_NUMEROASSEGNO", typeof(long)));
	tgiornaledicassa.Columns.Add( new DataColumn("FILLER", typeof(string)));
	Tables.Add(tgiornaledicassa);

	//////////////////// BILLTRANSACTION /////////////////////////////////
	var tbilltransaction= new DataTable("billtransaction");
	C= new DataColumn("ybilltran", typeof(short));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	C= new DataColumn("nbilltran", typeof(int));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	tbilltransaction.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbilltransaction.Columns.Add( new DataColumn("kind", typeof(string)));
	tbilltransaction.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("kpro", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("idpro", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbilltransaction.Columns.Add( new DataColumn("cu", typeof(string)));
	tbilltransaction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbilltransaction.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tbilltransaction);
	tbilltransaction.PrimaryKey =  new DataColumn[]{tbilltransaction.Columns["ybilltran"], tbilltransaction.Columns["nbilltran"]};


	//////////////////// BPPUGLIESE /////////////////////////////////
	var tbppugliese= new DataTable("bppugliese");
	tbppugliese.Columns.Add( new DataColumn("codiceistituto", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("codicedipendenza", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("codiceente", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("codiceesercizio", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("codicedivisaente", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("abi", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("cab", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("numeroconto", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("datamovimento", typeof(DateTime)));
	tbppugliese.Columns.Add( new DataColumn("tipomovimento", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("numdocumento", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("numsub", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("numricevuta", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("numcapitolo", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("numarticolo", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("annoresiduo", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("codicedivisacliente", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("importodivisacliente", typeof(decimal)));
	tbppugliese.Columns.Add( new DataColumn("importoricevuta", typeof(decimal)));
	tbppugliese.Columns.Add( new DataColumn("segno", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codiceesecuzione", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("codicebolli", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("importibolli", typeof(decimal)));
	tbppugliese.Columns.Add( new DataColumn("codicespese", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("importospese", typeof(decimal)));
	tbppugliese.Columns.Add( new DataColumn("datavaluta", typeof(DateTime)));
	tbppugliese.Columns.Add( new DataColumn("numdocrif", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("numsubrif", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("abicliente", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("cabcliente", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("descrizionecliente", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codicecausale", typeof(int)));
	tbppugliese.Columns.Add( new DataColumn("causale1", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("causale2", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("causale3", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codicetipoimputazione", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("filler", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("indicatoreeu", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("indicatoreiban", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("coordinateibanextraue", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codicebicswiftbdestin", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codiceswiftbtramite", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codiceversamentoinpdap", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codicemissione", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codiceprogramma", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codicepianofin", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codicecofog", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codiceue", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("codiceentrata", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("tipdoc", typeof(string)));
	tbppugliese.Columns.Add( new DataColumn("indreg", typeof(string)));
	Tables.Add(tbppugliese);

	#endregion


	#region DataRelation creation
	var cPar = new []{payment_bankview.Columns["kpay"], payment_bankview.Columns["idpay"]};
	var cChild = new []{banktransaction.Columns["kpay"], banktransaction.Columns["idpay"]};
	Relations.Add(new DataRelation("payment_bankview_banktransaction",cPar,cChild,false));

	cPar = new []{proceeds_bankview.Columns["kpro"], proceeds_bankview.Columns["idpro"]};
	cChild = new []{banktransaction.Columns["kpro"], banktransaction.Columns["idpro"]};
	Relations.Add(new DataRelation("proceeds_bankview_banktransaction",cPar,cChild,false));

	#endregion

}
}
}
