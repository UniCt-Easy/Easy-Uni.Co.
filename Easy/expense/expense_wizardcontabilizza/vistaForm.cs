/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace expense_wizardcontabilizza {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

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
	///Contabilizzazione missione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseitineration 		=> Tables["expenseitineration"];

	///<summary>
	///Missione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itineration 		=> Tables["itineration"];

	///<summary>
	///Variazione movimento di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevar 		=> Tables["expensevar"];

	///<summary>
	///Variazione movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomevar 		=> Tables["incomevar"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Contabilizzazione fattura acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseinvoice 		=> Tables["expenseinvoice"];

	///<summary>
	///Fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeinvoice 		=> Tables["incomeinvoice"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tipomovimento 		=> Tables["tipomovimento"];

	///<summary>
	///Contabilizzazione cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensepayroll 		=> Tables["expensepayroll"];

	///<summary>
	///Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	///<summary>
	///Contabilizzazione contratto occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensecasualcontract 		=> Tables["expensecasualcontract"];

	///<summary>
	///Contabilizzazione parcella professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseprofservice 		=> Tables["expenseprofservice"];

	///<summary>
	///Pagamento Prestazione Occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontract 		=> Tables["casualcontract"];

	///<summary>
	///Parcella Professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservice 		=> Tables["profservice"];

	///<summary>
	///Contabilizzazione compenso dipendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensewageaddition 		=> Tables["expensewageaddition"];

	///<summary>
	///Altri Compensi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageaddition 		=> Tables["wageaddition"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Contratto Passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandate 		=> Tables["mandate"];

	///<summary>
	///Contabilizzazione Contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensemandate 		=> Tables["expensemandate"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

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
	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	texpense.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// INCOME /////////////////////////////////
	var tincome= new DataTable("income");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tincome.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincome.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincome.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("txt", typeof(string)));
	tincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


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
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseyear.Columns.Add(C);
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
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeyear.Columns.Add(C);
	Tables.Add(tincomeyear);
	tincomeyear.PrimaryKey =  new DataColumn[]{tincomeyear.Columns["idinc"], tincomeyear.Columns["ayear"]};


	//////////////////// EXPENSEITINERATION /////////////////////////////////
	var texpenseitineration= new DataTable("expenseitineration");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseitineration.Columns.Add(C);
	texpenseitineration.Columns.Add( new DataColumn("movkind", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseitineration.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseitineration.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseitineration.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseitineration.Columns.Add(C);
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	texpenseitineration.Columns.Add(C);
	Tables.Add(texpenseitineration);
	texpenseitineration.PrimaryKey =  new DataColumn[]{texpenseitineration.Columns["idexp"], texpenseitineration.Columns["iditineration"]};


	//////////////////// ITINERATION /////////////////////////////////
	var titineration= new DataTable("itineration");
	C= new DataColumn("yitineration", typeof(short));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("nitineration", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("authorizationdate", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("admincarkmcost", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("owncarkmcost", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("footkmcost", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("admincarkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("owncarkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("footkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("grossfactor", typeof(double)));
	titineration.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("totalgross", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("total", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("totadvance", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("completed", typeof(string)));
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("idupb", typeof(string)));
	titineration.Columns.Add( new DataColumn("idsor01", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor02", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor03", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor04", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(titineration);
	titineration.PrimaryKey =  new DataColumn[]{titineration.Columns["iditineration"]};


	//////////////////// EXPENSEVAR /////////////////////////////////
	var texpensevar= new DataTable("expensevar");
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevar.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpensevar.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	texpensevar.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensevar.Columns.Add(C);
	Tables.Add(texpensevar);
	texpensevar.PrimaryKey =  new DataColumn[]{texpensevar.Columns["nvar"], texpensevar.Columns["idexp"]};


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
	Tables.Add(tincomevar);
	tincomevar.PrimaryKey =  new DataColumn[]{tincomevar.Columns["idinc"], tincomevar.Columns["nvar"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("paridfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// EXPENSEINVOICE /////////////////////////////////
	var texpenseinvoice= new DataTable("expenseinvoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	texpenseinvoice.Columns.Add( new DataColumn("movkind", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseinvoice.Columns.Add(C);
	Tables.Add(texpenseinvoice);
	texpenseinvoice.PrimaryKey =  new DataColumn[]{texpenseinvoice.Columns["idinvkind"], texpenseinvoice.Columns["yinv"], texpenseinvoice.Columns["ninv"], texpenseinvoice.Columns["idexp"]};


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
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
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
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["idinvkind"], tinvoice.Columns["yinv"], tinvoice.Columns["ninv"]};


	//////////////////// INCOMEINVOICE /////////////////////////////////
	var tincomeinvoice= new DataTable("incomeinvoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	tincomeinvoice.Columns.Add( new DataColumn("movkind", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeinvoice.Columns.Add(C);
	Tables.Add(tincomeinvoice);
	tincomeinvoice.PrimaryKey =  new DataColumn[]{tincomeinvoice.Columns["idinvkind"], tincomeinvoice.Columns["yinv"], tincomeinvoice.Columns["ninv"], tincomeinvoice.Columns["idinc"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(int));
	C.AllowDBNull=false;
	ttipomovimento.Columns.Add(C);
	ttipomovimento.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttipomovimento);
	ttipomovimento.PrimaryKey =  new DataColumn[]{ttipomovimento.Columns["idtipo"]};


	//////////////////// EXPENSEPAYROLL /////////////////////////////////
	var texpensepayroll= new DataTable("expensepayroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	texpensepayroll.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensepayroll.Columns.Add(C);
	texpensepayroll.Columns.Add( new DataColumn("cu", typeof(string)));
	texpensepayroll.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texpensepayroll.Columns.Add( new DataColumn("lu", typeof(string)));
	texpensepayroll.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(texpensepayroll);
	texpensepayroll.PrimaryKey =  new DataColumn[]{texpensepayroll.Columns["idpayroll"], texpensepayroll.Columns["idexp"]};


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tpayroll.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// EXPENSECASUALCONTRACT /////////////////////////////////
	var texpensecasualcontract= new DataTable("expensecasualcontract");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensecasualcontract.Columns.Add(C);
	Tables.Add(texpensecasualcontract);
	texpensecasualcontract.PrimaryKey =  new DataColumn[]{texpensecasualcontract.Columns["ycon"], texpensecasualcontract.Columns["idexp"], texpensecasualcontract.Columns["ncon"]};


	//////////////////// EXPENSEPROFSERVICE /////////////////////////////////
	var texpenseprofservice= new DataTable("expenseprofservice");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	C= new DataColumn("movkind", typeof(short));
	C.AllowDBNull=false;
	texpenseprofservice.Columns.Add(C);
	Tables.Add(texpenseprofservice);
	texpenseprofservice.PrimaryKey =  new DataColumn[]{texpenseprofservice.Columns["ycon"], texpenseprofservice.Columns["idexp"], texpenseprofservice.Columns["ncon"]};


	//////////////////// CASUALCONTRACT /////////////////////////////////
	var tcasualcontract= new DataTable("casualcontract");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("ndays", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("description", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tcasualcontract);
	tcasualcontract.PrimaryKey =  new DataColumn[]{tcasualcontract.Columns["ycon"], tcasualcontract.Columns["ncon"]};


	//////////////////// PROFSERVICE /////////////////////////////////
	var tprofservice= new DataTable("profservice");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("socialsecurityrate", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("pensioncontributionrate", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("ivarate", typeof(decimal)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("totalcost", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ndays", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("ivafieldnumber", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("description", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("doc", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tprofservice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tprofservice);
	tprofservice.PrimaryKey =  new DataColumn[]{tprofservice.Columns["ycon"], tprofservice.Columns["ncon"]};


	//////////////////// EXPENSEWAGEADDITION /////////////////////////////////
	var texpensewageaddition= new DataTable("expensewageaddition");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensewageaddition.Columns.Add(C);
	Tables.Add(texpensewageaddition);
	texpensewageaddition.PrimaryKey =  new DataColumn[]{texpensewageaddition.Columns["ycon"], texpensewageaddition.Columns["ncon"], texpensewageaddition.Columns["idexp"]};


	//////////////////// WAGEADDITION /////////////////////////////////
	var twageaddition= new DataTable("wageaddition");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("ndays", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	twageaddition.Columns.Add( new DataColumn("idsor01", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor02", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor03", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor04", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(twageaddition);
	twageaddition.PrimaryKey =  new DataColumn[]{twageaddition.Columns["ycon"], twageaddition.Columns["ncon"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// MANDATE /////////////////////////////////
	var tmandate= new DataTable("mandate");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("idman", typeof(int)));
	tmandate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	tmandate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	tmandate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tmandate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tmandate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tmandate.Columns.Add( new DataColumn("doc", typeof(string)));
	tmandate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandate.Columns.Add(C);
	tmandate.Columns.Add( new DataColumn("active", typeof(string)));
	tmandate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmandate);
	tmandate.PrimaryKey =  new DataColumn[]{tmandate.Columns["idmankind"], tmandate.Columns["yman"], tmandate.Columns["nman"]};


	//////////////////// EXPENSEMANDATE /////////////////////////////////
	var texpensemandate= new DataTable("expensemandate");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("yman", typeof(short));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("nman", typeof(int));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	texpensemandate.Columns.Add( new DataColumn("movkind", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensemandate.Columns.Add(C);
	Tables.Add(texpensemandate);
	texpensemandate.PrimaryKey =  new DataColumn[]{texpensemandate.Columns["idmankind"], texpensemandate.Columns["yman"], texpensemandate.Columns["nman"], texpensemandate.Columns["idexp"]};


	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmandatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cin", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("kpay", typeof(int)));
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
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelast.Columns.Add( new DataColumn("kpro", typeof(int)));
	Tables.Add(tincomelast);
	tincomelast.PrimaryKey =  new DataColumn[]{tincomelast.Columns["idinc"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{income.Columns["idinc"]};
	var cChild = new []{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensemandate.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensemandate",cPar,cChild,false));

	cPar = new []{mandate.Columns["idmankind"], mandate.Columns["yman"], mandate.Columns["nman"]};
	cChild = new []{expensemandate.Columns["idmankind"], expensemandate.Columns["yman"], expensemandate.Columns["nman"]};
	Relations.Add(new DataRelation("mandateexpensemandate",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{mandate.Columns["idmankind"]};
	Relations.Add(new DataRelation("mandatekindmandate",cPar,cChild,false));

	cPar = new []{wageaddition.Columns["ycon"], wageaddition.Columns["ncon"]};
	cChild = new []{expensewageaddition.Columns["ycon"], expensewageaddition.Columns["ncon"]};
	Relations.Add(new DataRelation("wageadditionexpensewageaddition",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensewageaddition.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensewageaddition",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseprofservice.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseprofservice",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{expenseprofservice.Columns["ycon"], expenseprofservice.Columns["ncon"]};
	Relations.Add(new DataRelation("profserviceexpenseprofservice",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensecasualcontract.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensecasualcontract",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{expensecasualcontract.Columns["ycon"], expensecasualcontract.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractexpensecasualcontract",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensepayroll.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensepayroll",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{expensepayroll.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollexpensepayroll",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{incomeinvoice.Columns["idinvkind"], incomeinvoice.Columns["yinv"], incomeinvoice.Columns["ninv"]};
	Relations.Add(new DataRelation("invoiceincomeinvoice",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeinvoice.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomeinvoice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{invoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindinvoice",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{expenseinvoice.Columns["idinvkind"], expenseinvoice.Columns["yinv"], expenseinvoice.Columns["ninv"]};
	Relations.Add(new DataRelation("invoiceexpenseinvoice",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseinvoice.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseinvoice",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomevar.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomevar",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expensevar.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpensevar",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{expenseitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_expenseitineration",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseitineration.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseitineration",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbincomeyear",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeincomeyear",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finincomeyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{expenseyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upbexpenseyear",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseexpenseyear",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{expenseyear.Columns["idfin"]};
	Relations.Add(new DataRelation("finexpenseyear",cPar,cChild,false));

	cPar = new []{incomephase.Columns["nphase"]};
	cChild = new []{income.Columns["nphase"]};
	Relations.Add(new DataRelation("incomephaseincome",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{income.Columns["idman"]};
	Relations.Add(new DataRelation("managerincome",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registryincome",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{income.Columns["parentidinc"]};
	Relations.Add(new DataRelation("incomeincome",cPar,cChild,false));

	cPar = new []{expensephase.Columns["nphase"]};
	cChild = new []{expense.Columns["nphase"]};
	Relations.Add(new DataRelation("expensephaseexpense",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{expense.Columns["idman"]};
	Relations.Add(new DataRelation("managerexpense",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{expense.Columns["idreg"]};
	Relations.Add(new DataRelation("registryexpense",cPar,cChild,false));

	cPar = new []{expense.Columns["idexp"]};
	cChild = new []{expense.Columns["parentidexp"]};
	Relations.Add(new DataRelation("expenseexpense",cPar,cChild,false));

	#endregion

}
}
}
