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
namespace payroll_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	///<summary>
	///Ritenuta Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltax 		=> Tables["payrolltax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractview 		=> Tables["parasubcontractview"];

	///<summary>
	///Nomi e codici dei mesi nel codice fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

	///<summary>
	///Dettaglio Deduzioni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolldeduction 		=> Tables["payrolldeduction"];

	///<summary>
	///Dettaglio Detrazioni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollabatement 		=> Tables["payrollabatement"];

	///<summary>
	///Codici Deduzioni per Esercizio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deduction 		=> Tables["deduction"];

	///<summary>
	///Tipo detrazione, usato nei contratti parasubordinati
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatement 		=> Tables["abatement"];

	///<summary>
	///Imputazione tipo deduzione 
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductioncode 		=> Tables["deductioncode"];

	///<summary>
	///Informazioni su una detrazione per un determinato esercizo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatementcode 		=> Tables["abatementcode"];

	///<summary>
	///Tipo Imponibile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxablekind 		=> Tables["taxablekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollview 		=> Tables["payrollview"];

	///<summary>
	///Scaglione di un cedolino parasubordinato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxbracket 		=> Tables["payrolltaxbracket"];

	///<summary>
	///Storni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxcorrige 		=> Tables["payrolltaxcorrige"];

	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

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
	//////////////////// GEO_CITYVIEW /////////////////////////////////
	var tgeo_cityview= new DataTable("geo_cityview");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("country", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("region", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("nation", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newnation", typeof(int)));
	Tables.Add(tgeo_cityview);
	tgeo_cityview.PrimaryKey =  new DataColumn[]{tgeo_cityview.Columns["idcity"]};


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// PAYROLLTAX /////////////////////////////////
	var tpayrolltax= new DataTable("payrolltax");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	tpayrolltax.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("!descrritenuta", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtaxgross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("deduction", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrolltax.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualtaxabletotal", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualpayedemploytax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("annualcreditapplied", typeof(decimal)));
	Tables.Add(tpayrolltax);
	tpayrolltax.PrimaryKey =  new DataColumn[]{tpayrolltax.Columns["idpayroll"], tpayrolltax.Columns["idpayrolltax"]};


	//////////////////// PARASUBCONTRACTVIEW /////////////////////////////////
	var tparasubcontractview= new DataTable("parasubcontractview");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("ycon", typeof(int)));
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("registry", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("matricula", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("duty", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("payroll", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("service", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idresidence", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("city", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("activitycode", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("activity", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idotherinsurance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("otherinsurance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idpat", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("patcode", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("pat", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("notaxappliance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("highertax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("matriculabook", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("regionaltax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("countrytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("citytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedcountrytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	Tables.Add(tparasubcontractview);
	tparasubcontractview.PrimaryKey =  new DataColumn[]{tparasubcontractview.Columns["idcon"]};


	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new DataTable("monthname");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname.Columns.Add(C);
	tmonthname.Columns.Add( new DataColumn("title", typeof(string)));
	tmonthname.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	Tables.Add(tmonthname);
	tmonthname.PrimaryKey =  new DataColumn[]{tmonthname.Columns["code"]};


	//////////////////// PAYROLLDEDUCTION /////////////////////////////////
	var tpayrolldeduction= new DataTable("payrolldeduction");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	tpayrolldeduction.Columns.Add( new DataColumn("!codicededuzione", typeof(string)));
	tpayrolldeduction.Columns.Add( new DataColumn("!descrdeduzione", typeof(string)));
	tpayrolldeduction.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	tpayrolldeduction.Columns.Add( new DataColumn("!descrimponibile", typeof(string)));
	tpayrolldeduction.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrolldeduction.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrolldeduction);
	tpayrolldeduction.PrimaryKey =  new DataColumn[]{tpayrolldeduction.Columns["idpayroll"], tpayrolldeduction.Columns["iddeduction"]};


	//////////////////// PAYROLLABATEMENT /////////////////////////////////
	var tpayrollabatement= new DataTable("payrollabatement");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollabatement.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tpayrollabatement.Columns.Add(C);
	tpayrollabatement.Columns.Add( new DataColumn("!codicedetrazione", typeof(string)));
	tpayrollabatement.Columns.Add( new DataColumn("!descrdetrazione", typeof(string)));
	tpayrollabatement.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrollabatement.Columns.Add( new DataColumn("!descrritenuta", typeof(string)));
	tpayrollabatement.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrollabatement.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrollabatement);
	tpayrollabatement.PrimaryKey =  new DataColumn[]{tpayrollabatement.Columns["idpayroll"], tpayrollabatement.Columns["idabatement"]};


	//////////////////// DEDUCTION /////////////////////////////////
	var tdeduction= new DataTable("deduction");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	tdeduction.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeduction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tdeduction.Columns.Add( new DataColumn("flagdeductibleexpense", typeof(string)));
	Tables.Add(tdeduction);
	tdeduction.PrimaryKey =  new DataColumn[]{tdeduction.Columns["iddeduction"]};


	//////////////////// ABATEMENT /////////////////////////////////
	var tabatement= new DataTable("abatement");
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	tabatement.Columns.Add( new DataColumn("lu", typeof(string)));
	tabatement.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tabatement.Columns.Add( new DataColumn("flagabatableexpense", typeof(string)));
	tabatement.Columns.Add( new DataColumn("appliance", typeof(string)));
	Tables.Add(tabatement);
	tabatement.PrimaryKey =  new DataColumn[]{tabatement.Columns["idabatement"]};


	//////////////////// DEDUCTIONCODE /////////////////////////////////
	var tdeductioncode= new DataTable("deductioncode");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	tdeductioncode.Columns.Add( new DataColumn("code", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("description", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	Tables.Add(tdeductioncode);
	tdeductioncode.PrimaryKey =  new DataColumn[]{tdeductioncode.Columns["iddeduction"], tdeductioncode.Columns["ayear"]};


	//////////////////// ABATEMENTCODE /////////////////////////////////
	var tabatementcode= new DataTable("abatementcode");
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatementcode.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tabatementcode.Columns.Add(C);
	tabatementcode.Columns.Add( new DataColumn("code", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("description", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tabatementcode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tabatementcode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	Tables.Add(tabatementcode);
	tabatementcode.PrimaryKey =  new DataColumn[]{tabatementcode.Columns["idabatement"], tabatementcode.Columns["ayear"]};


	//////////////////// TAXABLEKIND /////////////////////////////////
	var ttaxablekind= new DataTable("taxablekind");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("evaluationorder", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("idtaxablekind", typeof(string)));
	ttaxablekind.Columns.Add( new DataColumn("roundingkind", typeof(string)));
	C= new DataColumn("spcalcrefertaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("spcalcannualtaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("lu", typeof(string)));
	ttaxablekind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(ttaxablekind);
	ttaxablekind.PrimaryKey =  new DataColumn[]{ttaxablekind.Columns["taxablecode"], ttaxablekind.Columns["ayear"]};


	//////////////////// PAYROLLVIEW /////////////////////////////////
	var tpayrollview= new DataTable("payrollview");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayrollview.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayrollview.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("matricula", typeof(int)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("service", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("residencecity", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("npay", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("nmov_lastphase", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("ymov_lastphase", typeof(int)));
	tpayrollview.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	Tables.Add(tpayrollview);

	//////////////////// PAYROLLTAXBRACKET /////////////////////////////////
	var tpayrolltaxbracket= new DataTable("payrolltaxbracket");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(short));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	tpayrolltaxbracket.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tpayrolltaxbracket);
	tpayrolltaxbracket.PrimaryKey =  new DataColumn[]{tpayrolltaxbracket.Columns["idpayroll"], tpayrolltaxbracket.Columns["idpayrolltax"], tpayrolltaxbracket.Columns["nbracket"]};


	//////////////////// PAYROLLTAXCORRIGE /////////////////////////////////
	var tpayrolltaxcorrige= new DataTable("payrolltaxcorrige");
	C= new DataColumn("idpayrolltaxcorrige", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	tpayrolltaxcorrige.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("employamount", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("adminamount", typeof(decimal)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("idcity", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	tpayrolltaxcorrige.Columns.Add( new DataColumn("!ente", typeof(string)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("!descrritenuta", typeof(string)));
	tpayrolltaxcorrige.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	Tables.Add(tpayrolltaxcorrige);
	tpayrolltaxcorrige.PrimaryKey =  new DataColumn[]{tpayrolltaxcorrige.Columns["idpayrolltaxcorrige"], tpayrolltaxcorrige.Columns["idpayroll"]};


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	tservice.Columns.Add( new DataColumn("active", typeof(string)));
	tservice.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagapplyabatements", typeof(string)));
	C= new DataColumn("flagonlyfiscalabatement", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice.Columns.Add( new DataColumn("ivaamount", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("module", typeof(string)));
	tservice.Columns.Add( new DataColumn("rec770kind", typeof(string)));
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


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
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payroll.Columns["idpayroll"]};
	var cChild = new []{payrolltaxcorrige.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payroll_payrolltaxcorrige",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payrolltaxcorrige.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayrolltaxcorrige",cPar,cChild,false));

	cPar = new []{payrolltax.Columns["idpayroll"], payrolltax.Columns["idpayrolltax"]};
	cChild = new []{payrolltaxbracket.Columns["idpayroll"], payrolltaxbracket.Columns["idpayrolltax"]};
	Relations.Add(new DataRelation("payrolltaxpayrolltaxbracket",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltaxbracket.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltaxbracket",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrollabatement.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrollabatement",cPar,cChild,false));

	cPar = new []{abatement.Columns["idabatement"]};
	cChild = new []{payrollabatement.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementpayrollabatement",cPar,cChild,false));

	cPar = new []{abatementcode.Columns["idabatement"]};
	cChild = new []{payrollabatement.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementcodepayrollabatement",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payrollabatement.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayrollabatement",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolldeduction.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolldeduction",cPar,cChild,false));

	cPar = new []{deduction.Columns["iddeduction"]};
	cChild = new []{payrolldeduction.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductionpayrolldeduction",cPar,cChild,false));

	cPar = new []{deductioncode.Columns["iddeduction"]};
	cChild = new []{payrolldeduction.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductioncodepayrolldeduction",cPar,cChild,false));

	cPar = new []{taxablekind.Columns["taxablecode"]};
	cChild = new []{payrolldeduction.Columns["taxablecode"]};
	Relations.Add(new DataRelation("taxablekindpayrolldeduction",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{parasubcontractview.Columns["idser"]};
	Relations.Add(new DataRelation("serviceparasubcontractview",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payrolltax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayrolltax",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltax",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{payroll.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_cityviewpayroll",cPar,cChild,false));

	cPar = new []{parasubcontractview.Columns["idcon"]};
	cChild = new []{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractviewpayroll",cPar,cChild,false));

	cPar = new []{monthname.Columns["code"]};
	cChild = new []{payroll.Columns["npayroll"]};
	Relations.Add(new DataRelation("monthnamepayroll",cPar,cChild,false));

	#endregion

}
}
}
