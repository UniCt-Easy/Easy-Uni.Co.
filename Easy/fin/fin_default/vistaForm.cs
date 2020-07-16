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
namespace fin_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Classificazione bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finsorting 		=> Tables["finsorting"];

	///<summary>
	///Livelli del bilancio annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finlevel 		=> Tables["finlevel"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Informazioni su voce bilancio foglia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finlast 		=> Tables["finlast"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finunified 		=> Tables["finunified"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finyearview 		=> Tables["finyearview"];

	///<summary>
	///Configurazione classificazioni automatiche movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable autoexpensesorting 		=> Tables["autoexpensesorting"];

	///<summary>
	///Configurazione classificazioni automatiche movimenti di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable autoincomesorting 		=> Tables["autoincomesorting"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	///<summary>
	///Configurazione filtro classificazione spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingexpensefilter 		=> Tables["sortingexpensefilter"];

	///<summary>
	///Configurazione filtro classificazione entrate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingincomefilter 		=> Tables["sortingincomefilter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finvardetailview 		=> Tables["finvardetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied 		=> Tables["accmotiveapplied"];

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
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// FINSORTING /////////////////////////////////
	var tfinsorting= new DataTable("finsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	tfinsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tfinsorting.Columns.Add( new DataColumn("!tipoclass", typeof(string)));
	tfinsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	tfinsorting.Columns.Add( new DataColumn("quota", typeof(double)));
	Tables.Add(tfinsorting);
	tfinsorting.PrimaryKey =  new DataColumn[]{tfinsorting.Columns["idfin"], tfinsorting.Columns["idsor"]};


	//////////////////// FINLEVEL /////////////////////////////////
	var tfinlevel= new DataTable("finlevel");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("flag", typeof(short));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	Tables.Add(tfinlevel);
	tfinlevel.PrimaryKey =  new DataColumn[]{tfinlevel.Columns["ayear"], tfinlevel.Columns["nlevel"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// FINLAST /////////////////////////////////
	var tfinlast= new DataTable("finlast");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinlast.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinlast.Columns.Add(C);
	tfinlast.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tfinlast.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinlast.Columns.Add(C);
	tfinlast.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tfinlast.Columns.Add( new DataColumn("idacc", typeof(string)));
	tfinlast.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	Tables.Add(tfinlast);
	tfinlast.PrimaryKey =  new DataColumn[]{tfinlast.Columns["idfin"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// FINUNIFIED /////////////////////////////////
	var tfinunified= new DataTable("finunified");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	tfinunified.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	tfinunified.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	tfinunified.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinunified.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	tfinunified.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinunified.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinunified.Columns.Add(C);
	tfinunified.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tfinunified.Columns.Add( new DataColumn("idacc", typeof(string)));
	tfinunified.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tfinunified.Columns.Add( new DataColumn("account", typeof(string)));
	Tables.Add(tfinunified);

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


	//////////////////// FINYEARVIEW /////////////////////////////////
	var tfinyearview= new DataTable("finyearview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("finance", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("nlevel", typeof(byte)));
	tfinyearview.Columns.Add( new DataColumn("leveldescr", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("upb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tfinyearview);
	tfinyearview.PrimaryKey =  new DataColumn[]{tfinyearview.Columns["idfin"], tfinyearview.Columns["idupb"]};


	//////////////////// AUTOEXPENSESORTING /////////////////////////////////
	var tautoexpensesorting= new DataTable("autoexpensesorting");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	tautoexpensesorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tautoexpensesorting.Columns.Add( new DataColumn("cu", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn1", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn2", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn3", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn4", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultn5", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv1", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv2", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv3", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv4", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("defaultv5", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("denominator", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("idupb", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tautoexpensesorting.Columns.Add( new DataColumn("lu", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("numerator", typeof(int)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	tautoexpensesorting.Columns.Add( new DataColumn("idman", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("idsor", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tautoexpensesorting.Columns.Add(C);
	tautoexpensesorting.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tautoexpensesorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("!sorting", typeof(string)));
	tautoexpensesorting.Columns.Add( new DataColumn("!frazione", typeof(string)));
	Tables.Add(tautoexpensesorting);
	tautoexpensesorting.PrimaryKey =  new DataColumn[]{tautoexpensesorting.Columns["ayear"], tautoexpensesorting.Columns["idautosort"], tautoexpensesorting.Columns["idfin"]};


	//////////////////// AUTOINCOMESORTING /////////////////////////////////
	var tautoincomesorting= new DataTable("autoincomesorting");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tautoincomesorting.Columns.Add( new DataColumn("cu", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn1", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn2", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn3", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn4", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultn5", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv1", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv2", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv3", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv4", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("defaultv5", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("denominator", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("idupb", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tautoincomesorting.Columns.Add( new DataColumn("lu", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("numerator", typeof(int)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("idman", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsor", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tautoincomesorting.Columns.Add(C);
	tautoincomesorting.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tautoincomesorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("!sorting", typeof(string)));
	tautoincomesorting.Columns.Add( new DataColumn("!frazione", typeof(string)));
	Tables.Add(tautoincomesorting);
	tautoincomesorting.PrimaryKey =  new DataColumn[]{tautoincomesorting.Columns["ayear"], tautoincomesorting.Columns["idautosort"], tautoincomesorting.Columns["idfin"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	tsortingkind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// SORTINGEXPENSEFILTER /////////////////////////////////
	var tsortingexpensefilter= new DataTable("sortingexpensefilter");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingexpensefilter.Columns.Add( new DataColumn("cu", typeof(string)));
	tsortingexpensefilter.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("jointolessspecifics", typeof(string));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tsortingexpensefilter.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingexpensefilter.Columns.Add(C);
	tsortingexpensefilter.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tsortingexpensefilter.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tsortingexpensefilter.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tsortingexpensefilter.Columns.Add( new DataColumn("!sorting", typeof(string)));
	Tables.Add(tsortingexpensefilter);
	tsortingexpensefilter.PrimaryKey =  new DataColumn[]{tsortingexpensefilter.Columns["ayear"], tsortingexpensefilter.Columns["idautosort"], tsortingexpensefilter.Columns["idfin"]};


	//////////////////// SORTINGINCOMEFILTER /////////////////////////////////
	var tsortingincomefilter= new DataTable("sortingincomefilter");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	C= new DataColumn("idautosort", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tsortingincomefilter.Columns.Add( new DataColumn("cu", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("jointolessspecifics", typeof(string));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tsortingincomefilter.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idsorreg", typeof(int)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingincomefilter.Columns.Add(C);
	tsortingincomefilter.Columns.Add( new DataColumn("idsorkindreg", typeof(int)));
	tsortingincomefilter.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("!sortingcode", typeof(string)));
	tsortingincomefilter.Columns.Add( new DataColumn("!sorting", typeof(string)));
	Tables.Add(tsortingincomefilter);
	tsortingincomefilter.PrimaryKey =  new DataColumn[]{tsortingincomefilter.Columns["ayear"], tsortingincomefilter.Columns["idautosort"], tsortingincomefilter.Columns["idfin"]};


	//////////////////// FINVARDETAILVIEW /////////////////////////////////
	var tfinvardetailview= new DataTable("finvardetailview");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationdescription", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("enactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nenactment", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	C= new DataColumn("variationkind", typeof(byte));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("variationkinddescr", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagprevision", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagcredit", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagproceeds", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flagsecondaryprev", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("official", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nofficial", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("enactmentnumber", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("manager", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idfinvarstatus", typeof(short)));
	tfinvardetailview.Columns.Add( new DataColumn("finvarstatus", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idlcard", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("createexpense", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("phase", typeof(string)));
	tfinvardetailview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tfinvardetailview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("activity", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	C= new DataColumn("kindd", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	C= new DataColumn("kindr", typeof(string));
	C.ReadOnly=true;
	tfinvardetailview.Columns.Add(C);
	tfinvardetailview.Columns.Add( new DataColumn("!prev_cassa", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("!prev_competenza", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("!crediti", typeof(decimal)));
	tfinvardetailview.Columns.Add( new DataColumn("!cassa", typeof(decimal)));
	Tables.Add(tfinvardetailview);
	tfinvardetailview.PrimaryKey =  new DataColumn[]{tfinvardetailview.Columns["yvar"], tfinvardetailview.Columns["nvar"], tfinvardetailview.Columns["rownum"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("idman", typeof(int));
	C.ReadOnly=true;
	tfinview.Columns.Add(C);
	C= new DataColumn("manager", typeof(string));
	C.ReadOnly=true;
	tfinview.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.ReadOnly=true;
	tfinview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tfinview.Columns.Add( new DataColumn("cupcode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	Tables.Add(tfinview);

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("codeacc", typeof(string)));
	taccount.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new DataTable("accmotiveapplied");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.PrimaryKey =  new DataColumn[]{taccmotiveapplied.Columns["idaccmotive"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{fin.Columns["idfin"]};
	var cChild = new []{finvardetailview.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_finvardetailview",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sortingincomefilter.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_sortingincomefilter_sortingkind",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingincomefilter.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingincomefilter_sorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{sortingincomefilter.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_sortingincomefilter",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sortingexpensefilter.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_sortingexpensefilter_sortingkind",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingexpensefilter.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingexpensefilter_sorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{sortingexpensefilter.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_sortingexpensefilter",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{autoincomesorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_autoincomesorting_sortingkind",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{autoincomesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_autoincomesorting_sorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{autoincomesorting.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_autoincomesorting",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{autoexpensesorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("FK_autoexpensesorting_sortingkind",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{autoexpensesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_autoexpensesorting_sorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{autoexpensesorting.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_autoexpensesorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finyearview.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_finyearview",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finunified.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_finunified",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{finlast.Columns["idacc"]};
	Relations.Add(new DataRelation("account_finlast",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{finlast.Columns["idman"]};
	Relations.Add(new DataRelation("manager_finlast",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finlast.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_finlast",cPar,cChild,false));

	cPar = new []{finlevel.Columns["ayear"], finlevel.Columns["nlevel"]};
	cChild = new []{fin.Columns["ayear"], fin.Columns["nlevel"]};
	Relations.Add(new DataRelation("finlevelfin",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{fin.Columns["paridfin"]};
	Relations.Add(new DataRelation("finfin",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{finsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingview_finsorting",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finsorting.Columns["idfin"]};
	Relations.Add(new DataRelation("finfinsorting",cPar,cChild,false));

	cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	cChild = new []{finlast.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveapplied_finlast",cPar,cChild,false));

	#endregion

}
}
}
