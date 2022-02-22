
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
namespace unifiedf24ep_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipi Sanzioni F24 EP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24epsanctionkind 		=> Tables["f24epsanctionkind"];

	///<summary>
	///Informazioni ente contabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable license 		=> Tables["license"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Modello F24 EP consolidato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedf24ep 		=> Tables["unifiedf24ep"];

	///<summary>
	///Sanzione F24 EP
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedf24epsanction 		=> Tables["unifiedf24epsanction"];

	///<summary>
	///Ritenute centralizzate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedtax 		=> Tables["unifiedtax"];

	///<summary>
	///Correzioni Ritenute centralizzate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedtaxcorrige 		=> Tables["unifiedtaxcorrige"];

	///<summary>
	///iddb dei vari dipartimenti presenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dbdepartment 		=> Tables["dbdepartment"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Nomi e codici dei mesi nel codice fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

	///<summary>
	///Tipo recupero consolidato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedclawback 		=> Tables["unifiedclawback"];

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
	//////////////////// F24EPSANCTIONKIND /////////////////////////////////
	var tf24epsanctionkind= new DataTable("f24epsanctionkind");
	C= new DataColumn("idsanction", typeof(int));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("fiscaltaxcode", typeof(string));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	C= new DataColumn("flagagency", typeof(string));
	C.AllowDBNull=false;
	tf24epsanctionkind.Columns.Add(C);
	Tables.Add(tf24epsanctionkind);
	tf24epsanctionkind.PrimaryKey =  new DataColumn[]{tf24epsanctionkind.Columns["idsanction"]};


	//////////////////// LICENSE /////////////////////////////////
	var tlicense= new DataTable("license");
	C= new DataColumn("dummykey", typeof(string));
	C.AllowDBNull=false;
	tlicense.Columns.Add(C);
	tlicense.Columns.Add( new DataColumn("address1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("address2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agency", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("agencyname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("annotations", typeof(string)));
	tlicense.Columns.Add( new DataColumn("cap", typeof(string)));
	tlicense.Columns.Add( new DataColumn("cf", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkbackup1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkbackup2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkflag", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checklic", typeof(string)));
	tlicense.Columns.Add( new DataColumn("checkman", typeof(string)));
	tlicense.Columns.Add( new DataColumn("country", typeof(string)));
	tlicense.Columns.Add( new DataColumn("dbname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("department", typeof(string)));
	tlicense.Columns.Add( new DataColumn("departmentcode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("departmentname", typeof(string)));
	tlicense.Columns.Add( new DataColumn("email", typeof(string)));
	tlicense.Columns.Add( new DataColumn("expiringlic", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("expiringman", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("fax", typeof(string)));
	tlicense.Columns.Add( new DataColumn("iddb", typeof(int)));
	tlicense.Columns.Add( new DataColumn("idreg", typeof(int)));
	tlicense.Columns.Add( new DataColumn("lickind", typeof(string)));
	tlicense.Columns.Add( new DataColumn("licstatus", typeof(string)));
	tlicense.Columns.Add( new DataColumn("location", typeof(string)));
	tlicense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tlicense.Columns.Add( new DataColumn("lu", typeof(string)));
	tlicense.Columns.Add( new DataColumn("mankind", typeof(string)));
	tlicense.Columns.Add( new DataColumn("manstatus", typeof(string)));
	tlicense.Columns.Add( new DataColumn("nmsgs", typeof(int)));
	tlicense.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tlicense.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tlicense.Columns.Add( new DataColumn("referent", typeof(string)));
	tlicense.Columns.Add( new DataColumn("sent", typeof(string)));
	tlicense.Columns.Add( new DataColumn("serverbackup1", typeof(string)));
	tlicense.Columns.Add( new DataColumn("serverbackup2", typeof(string)));
	tlicense.Columns.Add( new DataColumn("servername", typeof(string)));
	tlicense.Columns.Add( new DataColumn("swmorecode", typeof(string)));
	tlicense.Columns.Add( new DataColumn("swmoreflag", typeof(int)));
	tlicense.Columns.Add( new DataColumn("idcity", typeof(int)));
	Tables.Add(tlicense);
	tlicense.PrimaryKey =  new DataColumn[]{tlicense.Columns["dummykey"]};


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
	tconfig.Columns.Add( new DataColumn("finvarofficial_default", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
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
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("wageimportappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("balancekind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("idpaymethodabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("iban_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("email_f24", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// UNIFIEDF24EP /////////////////////////////////
	var tunifiedf24ep= new DataTable("unifiedf24ep");
	C= new DataColumn("idunifiedf24ep", typeof(int));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	tunifiedf24ep.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("paymentdate", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	tunifiedf24ep.Columns.Add( new DataColumn("nmonth", typeof(int)));
	Tables.Add(tunifiedf24ep);
	tunifiedf24ep.PrimaryKey =  new DataColumn[]{tunifiedf24ep.Columns["idunifiedf24ep"]};


	//////////////////// UNIFIEDF24EPSANCTION /////////////////////////////////
	var tunifiedf24epsanction= new DataTable("unifiedf24epsanction");
	C= new DataColumn("idunifiedf24ep", typeof(int));
	C.AllowDBNull=false;
	tunifiedf24epsanction.Columns.Add(C);
	C= new DataColumn("idsanction", typeof(int));
	C.AllowDBNull=false;
	tunifiedf24epsanction.Columns.Add(C);
	tunifiedf24epsanction.Columns.Add( new DataColumn("idcity", typeof(int)));
	tunifiedf24epsanction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tunifiedf24epsanction.Columns.Add( new DataColumn("ayear", typeof(short)));
	tunifiedf24epsanction.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	C= new DataColumn("idsanctionf24", typeof(int));
	C.AllowDBNull=false;
	tunifiedf24epsanction.Columns.Add(C);
	tunifiedf24epsanction.Columns.Add( new DataColumn("!fiscaltaxcode", typeof(string)));
	Tables.Add(tunifiedf24epsanction);
	tunifiedf24epsanction.PrimaryKey =  new DataColumn[]{tunifiedf24epsanction.Columns["idunifiedf24ep"], tunifiedf24epsanction.Columns["idsanctionf24"]};


	//////////////////// UNIFIEDTAX /////////////////////////////////
	var tunifiedtax= new DataTable("unifiedtax");
	C= new DataColumn("idunifiedtax", typeof(int));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	tunifiedtax.Columns.Add( new DataColumn("idunifiedf24ep", typeof(int)));
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	tunifiedtax.Columns.Add( new DataColumn("nbracket", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("exemptionquota", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("competencydate", typeof(DateTime)));
	tunifiedtax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tunifiedtax.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	tunifiedtax.Columns.Add( new DataColumn("nmonth", typeof(short)));
	tunifiedtax.Columns.Add( new DataColumn("iddbdepartment", typeof(string)));
	tunifiedtax.Columns.Add( new DataColumn("idreg", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("ymov", typeof(short)));
	tunifiedtax.Columns.Add( new DataColumn("nmov", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("npay", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("idexp", typeof(int)));
	Tables.Add(tunifiedtax);
	tunifiedtax.PrimaryKey =  new DataColumn[]{tunifiedtax.Columns["idunifiedtax"]};


	//////////////////// UNIFIEDTAXCORRIGE /////////////////////////////////
	var tunifiedtaxcorrige= new DataTable("unifiedtaxcorrige");
	C= new DataColumn("idunifiedtaxcorrige", typeof(int));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	tunifiedtaxcorrige.Columns.Add( new DataColumn("idunifiedf24ep", typeof(int)));
	C= new DataColumn("idexpensetaxcorrige", typeof(int));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	tunifiedtaxcorrige.Columns.Add( new DataColumn("ayear", typeof(short)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("employamount", typeof(decimal)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("adminamount", typeof(decimal)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("idcity", typeof(int)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedtaxcorrige.Columns.Add(C);
	tunifiedtaxcorrige.Columns.Add( new DataColumn("nmonth", typeof(short)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("iddbdepartment", typeof(string)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("idreg", typeof(int)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("ymov", typeof(short)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("nmov", typeof(int)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("npay", typeof(int)));
	tunifiedtaxcorrige.Columns.Add( new DataColumn("idexp", typeof(int)));
	Tables.Add(tunifiedtaxcorrige);
	tunifiedtaxcorrige.PrimaryKey =  new DataColumn[]{tunifiedtaxcorrige.Columns["idunifiedtaxcorrige"]};


	//////////////////// DBDEPARTMENT /////////////////////////////////
	var tdbdepartment= new DataTable("dbdepartment");
	tdbdepartment.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("iddbdepartment", typeof(string));
	C.AllowDBNull=false;
	tdbdepartment.Columns.Add(C);
	tdbdepartment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdbdepartment.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tdbdepartment);
	tdbdepartment.PrimaryKey =  new DataColumn[]{tdbdepartment.Columns["iddbdepartment"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	C= new DataColumn("taxkind", typeof(short));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("fiscaltaxcodecredit", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new DataTable("monthname");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname.Columns.Add(C);
	tmonthname.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	tmonthname.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tmonthname);
	tmonthname.PrimaryKey =  new DataColumn[]{tmonthname.Columns["code"]};


	//////////////////// UNIFIEDCLAWBACK /////////////////////////////////
	var tunifiedclawback= new DataTable("unifiedclawback");
	tunifiedclawback.Columns.Add( new DataColumn("idunifiedf24ep", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tunifiedclawback.Columns.Add( new DataColumn("iddbdepartment", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("idreg", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tunifiedclawback.Columns.Add( new DataColumn("cu", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tunifiedclawback.Columns.Add( new DataColumn("lu", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("ymov", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("nmov", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("npay", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("idexp", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("identifying_marks", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("code", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("tiporiga", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("rifb_month", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("rifb_year", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("rifa_month", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("rifa_year", typeof(int)));
	tunifiedclawback.Columns.Add( new DataColumn("rifa", typeof(string)));
	C= new DataColumn("idunifiedclawback", typeof(int));
	C.AllowDBNull=false;
	tunifiedclawback.Columns.Add(C);
	tunifiedclawback.Columns.Add( new DataColumn("ayear", typeof(string)));
	tunifiedclawback.Columns.Add( new DataColumn("nmonth", typeof(string)));
	Tables.Add(tunifiedclawback);
	tunifiedclawback.PrimaryKey =  new DataColumn[]{tunifiedclawback.Columns["idunifiedclawback"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{unifiedf24ep.Columns["idunifiedf24ep"]};
	var cChild = new []{unifiedclawback.Columns["idunifiedf24ep"]};
	Relations.Add(new DataRelation("unifiedf24ep_unifiedclawback",cPar,cChild,false));

	cPar = new []{dbdepartment.Columns["iddbdepartment"]};
	cChild = new []{unifiedclawback.Columns["iddbdepartment"]};
	Relations.Add(new DataRelation("dbdepartment_unifiedclawback",cPar,cChild,false));

	cPar = new []{unifiedf24ep.Columns["idunifiedf24ep"]};
	cChild = new []{unifiedtaxcorrige.Columns["idunifiedf24ep"]};
	Relations.Add(new DataRelation("unifiedf24ep_unifiedtaxcorrige",cPar,cChild,false));

	cPar = new []{dbdepartment.Columns["iddbdepartment"]};
	cChild = new []{unifiedtaxcorrige.Columns["iddbdepartment"]};
	Relations.Add(new DataRelation("dbdepartment_unifiedtaxcorrige",cPar,cChild,false));

	cPar = new []{unifiedf24ep.Columns["idunifiedf24ep"]};
	cChild = new []{unifiedtax.Columns["idunifiedf24ep"]};
	Relations.Add(new DataRelation("unifiedf24ep_unifiedtax",cPar,cChild,false));

	cPar = new []{dbdepartment.Columns["iddbdepartment"]};
	cChild = new []{unifiedtax.Columns["iddbdepartment"]};
	Relations.Add(new DataRelation("dbdepartment_unifiedtax",cPar,cChild,false));

	cPar = new []{unifiedf24ep.Columns["idunifiedf24ep"]};
	cChild = new []{unifiedf24epsanction.Columns["idunifiedf24ep"]};
	Relations.Add(new DataRelation("unifiedf24ep_unifiedf24epsanction",cPar,cChild,false));

	cPar = new []{f24epsanctionkind.Columns["idsanction"]};
	cChild = new []{unifiedf24epsanction.Columns["idsanction"]};
	Relations.Add(new DataRelation("f24epsanctionkind_unifiedf24epsanction",cPar,cChild,false));

	cPar = new []{monthname.Columns["code"]};
	cChild = new []{unifiedf24ep.Columns["nmonth"]};
	Relations.Add(new DataRelation("monthname_unifiedf24ep",cPar,cChild,false));

	#endregion

}
}
}
