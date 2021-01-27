
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
namespace manage_automatismi {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsMov"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsMov: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensesorted 		=> Tables["expensesorted"];

	///<summary>
	///Classificazione Movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomesorted 		=> Tables["incomesorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomevarview 		=> Tables["incomevarview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevarview 		=> Tables["expensevarview"];

	///<summary>
	///Finanziamento fase Prenotazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwritingappropriation 		=> Tables["underwritingappropriation"];

	///<summary>
	///Finanziamento fase Liquidazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwritingpayment 		=> Tables["underwritingpayment"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsMov(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsMov (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsMov";
	Prefix = "";
	Namespace = "http://tempuri.org/dsMov.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new DataTable("expensesorted");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("description", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	texpensesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	texpensesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpensesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!sorting", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!adate", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("!idfin", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!codefin", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!finance", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!idupb", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!upb", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("!ymov", typeof(int)));
	texpensesorted.Columns.Add( new DataColumn("!nmov", typeof(int)));
	texpensesorted.Columns.Add( new DataColumn("!nphase", typeof(byte)));
	texpensesorted.Columns.Add( new DataColumn("!phase", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	Tables.Add(texpensesorted);
	texpensesorted.PrimaryKey =  new DataColumn[]{texpensesorted.Columns["idexp"], texpensesorted.Columns["idsor"], texpensesorted.Columns["idsubclass"]};


	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new DataTable("incomesorted");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("description", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tincomesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	tincomesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincomesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!sorting", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!adate", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("!idfin", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!finance", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!idupb", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!upb", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("!ymov", typeof(int)));
	tincomesorted.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tincomesorted.Columns.Add( new DataColumn("!nphase", typeof(byte)));
	tincomesorted.Columns.Add( new DataColumn("!phase", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	Tables.Add(tincomesorted);
	tincomesorted.PrimaryKey =  new DataColumn[]{tincomesorted.Columns["idinc"], tincomesorted.Columns["idsor"], tincomesorted.Columns["idsubclass"]};


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
	texpenseview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenseview);
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"]};


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
	tincomeview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("!codeunderwriting", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("!underwriting", typeof(string)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


	//////////////////// INCOMEVARVIEW /////////////////////////////////
	var tincomevarview= new DataTable("incomevarview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	tincomevarview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomevarview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomevarview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	tincomevarview.Columns.Add( new DataColumn("transferkind", typeof(string)));
	tincomevarview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevarview.Columns.Add(C);
	tincomevarview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomevarview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomevarview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tincomevarview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tincomevarview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tincomevarview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tincomevarview.Columns.Add( new DataColumn("movkind", typeof(short)));
	Tables.Add(tincomevarview);
	tincomevarview.PrimaryKey =  new DataColumn[]{tincomevarview.Columns["idinc"], tincomevarview.Columns["nvar"]};


	//////////////////// EXPENSEVARVIEW /////////////////////////////////
	var texpensevarview= new DataTable("expensevarview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	texpensevarview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensevarview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpensevarview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevarview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	texpensevarview.Columns.Add( new DataColumn("transferkind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevarview.Columns.Add(C);
	texpensevarview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("yinv", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("ninv", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("movkind", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("!codeunderwriting", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("!underwriting", typeof(string)));
	Tables.Add(texpensevarview);
	texpensevarview.PrimaryKey =  new DataColumn[]{texpensevarview.Columns["idexp"], texpensevarview.Columns["nvar"]};


	//////////////////// UNDERWRITINGAPPROPRIATION /////////////////////////////////
	var tunderwritingappropriation= new DataTable("underwritingappropriation");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingappropriation.Columns.Add(C);
	tunderwritingappropriation.Columns.Add( new DataColumn("!codeunderwriting", typeof(string)));
	tunderwritingappropriation.Columns.Add( new DataColumn("!underwriting", typeof(string)));
	Tables.Add(tunderwritingappropriation);
	tunderwritingappropriation.PrimaryKey =  new DataColumn[]{tunderwritingappropriation.Columns["idunderwriting"], tunderwritingappropriation.Columns["idexp"]};


	//////////////////// UNDERWRITINGPAYMENT /////////////////////////////////
	var tunderwritingpayment= new DataTable("underwritingpayment");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwritingpayment.Columns.Add(C);
	tunderwritingpayment.Columns.Add( new DataColumn("!codeunderwriting", typeof(string)));
	tunderwritingpayment.Columns.Add( new DataColumn("!underwriting", typeof(string)));
	Tables.Add(tunderwritingpayment);
	tunderwritingpayment.PrimaryKey =  new DataColumn[]{tunderwritingpayment.Columns["idunderwriting"], tunderwritingpayment.Columns["idexp"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{expenseview.Columns["idexp"]};
	var cChild = new []{underwritingpayment.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_underwritingpayment",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{underwritingappropriation.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_underwritingappropriation",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{incomesorted.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeviewincomesorted",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{expensesorted.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseviewexpensesorted",cPar,cChild,false));

	#endregion

}
}
}
