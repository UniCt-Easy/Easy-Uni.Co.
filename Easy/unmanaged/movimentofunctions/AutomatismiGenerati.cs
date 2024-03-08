
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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace movimentofunctions {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("AutomatismiGenerati"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class AutomatismiGenerati: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable automatismitable 		=> Tables["automatismitable"];

	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	///<summary>
	///Informazioni annuali su movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseyear 		=> Tables["expenseyear"];

	///<summary>
	///Informazioni annuali su mov. di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeyear 		=> Tables["incomeyear"];

	///<summary>
	///Variazione movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomevar 		=> Tables["incomevar"];

	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevar 		=> Tables["expensevar"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Documento di incasso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds 		=> Tables["proceeds"];

	///<summary>
	///Documento di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payment 		=> Tables["payment"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

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

	///<summary>
	///Dettaglio Ritenute
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetax 		=> Tables["expensetax"];

	///<summary>
	///Dettaglio Recuperi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseclawback 		=> Tables["expenseclawback"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselast 		=> Tables["expenselast"];

	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelast 		=> Tables["incomelast"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Dettaglio Riepilogo Ritenute
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetaxofficial 		=> Tables["expensetaxofficial"];

	///<summary>
	///Dettaglio Correzioni Ritenute
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetaxcorrige 		=> Tables["expensetaxcorrige"];

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

	///<summary>
	///Sospeso passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensebill 		=> Tables["expensebill"];

	///<summary>
	///Sospeso attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomebill 		=> Tables["incomebill"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public AutomatismiGenerati(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected AutomatismiGenerati (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "AutomatismiGenerati";
	Prefix = "";
	Namespace = "http://tempuri.org/AutomatismiGenerati.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// AUTOMATISMITABLE /////////////////////////////////
	var tautomatismitable= new DataTable("automatismitable");
	tautomatismitable.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tautomatismitable.Columns.Add( new DataColumn("movkind", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("idreg", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("idfin", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("idupb", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("idman", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("description", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tautomatismitable.Columns.Add( new DataColumn("codefin", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("autocode", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("registry", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("manager", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("doc", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	Tables.Add(tautomatismitable);

	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpense.Columns.Add( new DataColumn("cupcode", typeof(string)));
	texpense.Columns.Add( new DataColumn("cigcode", typeof(string)));
	texpense.Columns.Add( new DataColumn("idinc_linked", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// EXPENSEYEAR /////////////////////////////////
	var texpenseyear= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	texpenseyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseyear.Columns.Add( new DataColumn("cu", typeof(string)));
	texpenseyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texpenseyear.Columns.Add( new DataColumn("lu", typeof(string)));
	texpenseyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(texpenseyear);
	texpenseyear.PrimaryKey =  new DataColumn[]{texpenseyear.Columns["ayear"], texpenseyear.Columns["idexp"]};


	//////////////////// INCOMEYEAR /////////////////////////////////
	var tincomeyear= new DataTable("incomeyear");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	tincomeyear.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeyear.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeyear.Columns.Add( new DataColumn("cu", typeof(string)));
	tincomeyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tincomeyear.Columns.Add( new DataColumn("lu", typeof(string)));
	tincomeyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tincomeyear);
	tincomeyear.PrimaryKey =  new DataColumn[]{tincomeyear.Columns["idinc"], tincomeyear.Columns["ayear"]};


	//////////////////// INCOMEVAR /////////////////////////////////
	var tincomevar= new DataTable("incomevar");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomevar.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomevar.Columns.Add(C);
	tincomevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	tincomevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	Tables.Add(tincomevar);
	tincomevar.PrimaryKey =  new DataColumn[]{tincomevar.Columns["idinc"], tincomevar.Columns["nvar"]};


	//////////////////// INCOME /////////////////////////////////
	var tincome= new DataTable("income");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("nphase", typeof(byte)));
	tincome.Columns.Add( new DataColumn("ymov", typeof(short)));
	tincome.Columns.Add( new DataColumn("nmov", typeof(int)));
	tincome.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tincome.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("description", typeof(string)));
	tincome.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincome.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("txt", typeof(string)));
	tincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincome.Columns.Add( new DataColumn("cu", typeof(string)));
	tincome.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("lu", typeof(string)));
	tincome.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincome.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincome.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tincome.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new DataTable("expensevar");
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("yvar", typeof(short)));
	texpensevar.Columns.Add( new DataColumn("description", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensevar.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpensevar.Columns.Add( new DataColumn("cu", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("lu", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	texpensevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevar.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("yinv", typeof(short)));
	texpensevar.Columns.Add( new DataColumn("ninv", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(texpensevar);
	texpensevar.PrimaryKey =  new DataColumn[]{texpensevar.Columns["nvar"], texpensevar.Columns["idexp"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


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
	tproceeds.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tproceeds);
	tproceeds.PrimaryKey =  new DataColumn[]{tproceeds.Columns["kpro"]};


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
	tpayment.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpayment.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tpayment.Columns.Add( new DataColumn("npay_treasurer", typeof(int)));
	Tables.Add(tpayment);
	tpayment.PrimaryKey =  new DataColumn[]{tpayment.Columns["kpay"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new DataTable("expensesorted");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("description", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	texpensesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	texpensesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	texpensesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(texpensesorted);
	texpensesorted.PrimaryKey =  new DataColumn[]{texpensesorted.Columns["idexp"], texpensesorted.Columns["idsor"], texpensesorted.Columns["idsubclass"]};


	//////////////////// INCOMESORTED /////////////////////////////////
	var tincomesorted= new DataTable("incomesorted");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("description", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomesorted.Columns.Add(C);
	tincomesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tincomesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tincomesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	tincomesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	tincomesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	tincomesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	tincomesorted.Columns.Add( new DataColumn("originalamount", typeof(decimal)));
	Tables.Add(tincomesorted);
	tincomesorted.PrimaryKey =  new DataColumn[]{tincomesorted.Columns["idinc"], tincomesorted.Columns["idsor"], tincomesorted.Columns["idsubclass"]};


	//////////////////// EXPENSETAX /////////////////////////////////
	var texpensetax= new DataTable("expensetax");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	texpensetax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("competencydate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	texpensetax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("exemptionquota", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensetax.Columns.Add(C);
	texpensetax.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	texpensetax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	texpensetax.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	texpensetax.Columns.Add( new DataColumn("ayear", typeof(short)));
	texpensetax.Columns.Add( new DataColumn("idinc", typeof(int)));
	texpensetax.Columns.Add( new DataColumn("idcity", typeof(int)));
	texpensetax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	Tables.Add(texpensetax);
	texpensetax.PrimaryKey =  new DataColumn[]{texpensetax.Columns["taxcode"], texpensetax.Columns["idexp"], texpensetax.Columns["nbracket"]};


	//////////////////// EXPENSECLAWBACK /////////////////////////////////
	var texpenseclawback= new DataTable("expenseclawback");
	C= new DataColumn("idclawback", typeof(int));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	texpenseclawback.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseclawback.Columns.Add(C);
	Tables.Add(texpenseclawback);
	texpenseclawback.PrimaryKey =  new DataColumn[]{texpenseclawback.Columns["idexp"], texpenseclawback.Columns["idclawback"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iban", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenselast.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenselast.Columns.Add( new DataColumn("kpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(texpenselast);
	texpenselast.PrimaryKey =  new DataColumn[]{texpenselast.Columns["idexp"]};


	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomelast.Columns.Add( new DataColumn("flag", typeof(byte)));
	tincomelast.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelast.Columns.Add( new DataColumn("cu", typeof(string)));
	tincomelast.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tincomelast.Columns.Add( new DataColumn("lu", typeof(string)));
	tincomelast.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tincomelast);
	tincomelast.PrimaryKey =  new DataColumn[]{tincomelast.Columns["idinc"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamountx", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("payments_groupingkind", typeof(string)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_groupingkind", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// EXPENSETAXOFFICIAL /////////////////////////////////
	var texpensetaxofficial= new DataTable("expensetaxofficial");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("idexpensetaxofficial", typeof(int));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	texpensetaxofficial.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("exemptionquota", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	texpensetaxofficial.Columns.Add( new DataColumn("start", typeof(DateTime)));
	texpensetaxofficial.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensetaxofficial.Columns.Add(C);
	texpensetaxofficial.Columns.Add( new DataColumn("idcity", typeof(int)));
	texpensetaxofficial.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	Tables.Add(texpensetaxofficial);
	texpensetaxofficial.PrimaryKey =  new DataColumn[]{texpensetaxofficial.Columns["idexp"], texpensetaxofficial.Columns["idexpensetaxofficial"]};


	//////////////////// EXPENSETAXCORRIGE /////////////////////////////////
	var texpensetaxcorrige= new DataTable("expensetaxcorrige");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	C= new DataColumn("idexpensetaxcorrige", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	texpensetaxcorrige.Columns.Add( new DataColumn("employamount", typeof(decimal)));
	texpensetaxcorrige.Columns.Add( new DataColumn("adminamount", typeof(decimal)));
	texpensetaxcorrige.Columns.Add( new DataColumn("idcity", typeof(int)));
	texpensetaxcorrige.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	texpensetaxcorrige.Columns.Add( new DataColumn("linkedidinc", typeof(int)));
	texpensetaxcorrige.Columns.Add( new DataColumn("linkedidexp", typeof(int)));
	texpensetaxcorrige.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	texpensetaxcorrige.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	texpensetaxcorrige.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrige.Columns.Add(C);
	Tables.Add(texpensetaxcorrige);
	texpensetaxcorrige.PrimaryKey =  new DataColumn[]{texpensetaxcorrige.Columns["idexp"], texpensetaxcorrige.Columns["idexpensetaxcorrige"]};


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
	Tables.Add(tunderwritingpayment);
	tunderwritingpayment.PrimaryKey =  new DataColumn[]{tunderwritingpayment.Columns["idunderwriting"], tunderwritingpayment.Columns["idexp"]};


	//////////////////// EXPENSEBILL /////////////////////////////////
	var texpensebill= new DataTable("expensebill");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensebill.Columns.Add(C);
	Tables.Add(texpensebill);
	texpensebill.PrimaryKey =  new DataColumn[]{texpensebill.Columns["idexp"], texpensebill.Columns["ybill"], texpensebill.Columns["nbill"]};


	//////////////////// INCOMEBILL /////////////////////////////////
	var tincomebill= new DataTable("incomebill");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomebill.Columns.Add(C);
	Tables.Add(tincomebill);
	tincomebill.PrimaryKey =  new DataColumn[]{tincomebill.Columns["idinc"], tincomebill.Columns["ybill"], tincomebill.Columns["nbill"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{income.Columns["idinc"]};
	var cChild = new []{incomebill.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomebill",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensebill.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expensebill",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{underwritingpayment.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_underwritingpayment",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{underwritingappropriation.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_underwritingappropriation",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{expensetaxcorrige.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxexpensetaxcorrige",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensetaxcorrige.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensetaxcorrige",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{expensetaxofficial.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxexpensetaxofficial",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensetaxofficial.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensetaxofficial",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",cPar,cChild,false));

	cPar = new []{proceeds.Columns["kpro"]};
	cChild = new []{incomelast.Columns["kpro"]};
	Relations.Add(new DataRelation("proceeds_incomelast",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",cPar,cChild,false));

	cPar = new []{payment.Columns["kpay"]};
	cChild = new []{expenselast.Columns["kpay"]};
	Relations.Add(new DataRelation("payment_expenselast",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseclawback.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseclawback",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensetax.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensetax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{expensetax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxexpensetax",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomesorted.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomesorted",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensesorted.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensesorted",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensevar.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expensevar",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensevar.Columns["idpayment"]};
	Relations.Add(new DataRelation("expense_expensevar1",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{income.Columns["idman"]};
	Relations.Add(new DataRelation("managerincome",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registryincome",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("incomeincome",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{income.Columns["idpayment"]};
	Relations.Add(new DataRelation("expenseincome",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finincomeyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomeyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbincomeyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomevar.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomevar",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{expenseyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finexpenseyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{expenseyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbexpenseyear",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{expense.Columns["idman"]};
	Relations.Add(new DataRelation("managerexpense",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{expense.Columns["idreg"]};
	Relations.Add(new DataRelation("registryexpense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expense.Columns["parentidexp"]};
	Relations.Add(new DataRelation("expenseexpense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expense.Columns["idpayment"]};
	Relations.Add(new DataRelation("expenseexpense1",cPar,cChild,false));

	#endregion

}
}
}
