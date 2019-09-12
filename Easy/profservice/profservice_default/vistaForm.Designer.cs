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
namespace profservice_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	///<summary>
	///Ritenuta su parcella professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservicetax 		=> Tables["profservicetax"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Parcella Professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservice 		=> Tables["profservice"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Tipo Spesa Professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profrefund 		=> Tables["profrefund"];

	///<summary>
	///Spese Documentate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservicerefund 		=> Tables["profservicerefund"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Classificazione contratto professionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservicesorting 		=> Tables["profservicesorting"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied 		=> Tables["accmotiveapplied"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_debit 		=> Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_crg 		=> Tables["accmotiveapplied_crg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	///<summary>
	///Posizione Dalia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_position 		=> Tables["dalia_position"];

	///<summary>
	///Partecipante a gara
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profserviceavcp 		=> Tables["profserviceavcp"];

	///<summary>
	///Partecipante a gara, associazione a lotti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profserviceavcpdetail 		=> Tables["profserviceavcpdetail"];

	///<summary>
	///Lotto parcella
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservicecig 		=> Tables["profservicecig"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview1 		=> Tables["sortingview1"];

	///<summary>
	///Dettaglio documento IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicedetail 		=> Tables["invoicedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siope 		=> Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_recruitmentmotive 		=> Tables["dalia_recruitmentmotive"];

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
	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("flagonlyfiscalabatement", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("ivaamount", typeof(string)));
	tservice.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("active", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagapplyabatements", typeof(string)));
	tservice.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(string)));
	tservice.Columns.Add( new DataColumn("module", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdalia", typeof(string)));
	tservice.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


	//////////////////// PROFSERVICETAX /////////////////////////////////
	var tprofservicetax= new DataTable("profservicetax");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	tprofservicetax.Columns.Add( new DataColumn("!taxref", typeof(string)));
	tprofservicetax.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tprofservicetax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	tprofservicetax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofservicetax.Columns.Add(C);
	tprofservicetax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("deduction", typeof(decimal)));
	tprofservicetax.Columns.Add( new DataColumn("employtaxgross", typeof(decimal)));
	Tables.Add(tprofservicetax);
	tprofservicetax.PrimaryKey =  new DataColumn[]{tprofservicetax.Columns["ycon"], tprofservicetax.Columns["ncon"], tprofservicetax.Columns["taxcode"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// PROFSERVICE /////////////////////////////////
	var tprofservice= new DataTable("profservice");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ndays", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("ivarate", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("ivafieldnumber", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("pensioncontributionrate", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("socialsecurityrate", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("totalcost", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("description", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("txt", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tprofservice.Columns.Add( new DataColumn("doc", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tprofservice.Columns.Add( new DataColumn("flaginvoiced", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("yinv", typeof(short)));
	tprofservice.Columns.Add( new DataColumn("ninv", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idupb", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("flagmixed", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tprofservice.Columns.Add( new DataColumn("authneeded", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("authdoc", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("authdocdate", typeof(DateTime)));
	tprofservice.Columns.Add( new DataColumn("noauthreason", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("totalgross", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("epkind", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("!imponibileiva", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("iddaliarecruitmentmotive", typeof(int)));
	Tables.Add(tprofservice);
	tprofservice.PrimaryKey =  new DataColumn[]{tprofservice.Columns["ycon"], tprofservice.Columns["ncon"]};


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


	//////////////////// PROFREFUND /////////////////////////////////
	var tprofrefund= new DataTable("profrefund");
	C= new DataColumn("idlinkedrefund", typeof(string));
	C.AllowDBNull=false;
	tprofrefund.Columns.Add(C);
	tprofrefund.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofrefund.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofrefund.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofrefund.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofrefund.Columns.Add(C);
	tprofrefund.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tprofrefund.Columns.Add( new DataColumn("flagfiscaldeduction", typeof(string)));
	tprofrefund.Columns.Add( new DataColumn("flagsecuritydeduction", typeof(string)));
	tprofrefund.Columns.Add( new DataColumn("flagivadeduction", typeof(string)));
	Tables.Add(tprofrefund);
	tprofrefund.PrimaryKey =  new DataColumn[]{tprofrefund.Columns["idlinkedrefund"]};


	//////////////////// PROFSERVICEREFUND /////////////////////////////////
	var tprofservicerefund= new DataTable("profservicerefund");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(int));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	tprofservicerefund.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	C= new DataColumn("idlinkedrefund", typeof(string));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	tprofservicerefund.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservicerefund.Columns.Add(C);
	Tables.Add(tprofservicerefund);
	tprofservicerefund.PrimaryKey =  new DataColumn[]{tprofservicerefund.Columns["ycon"], tprofservicerefund.Columns["ncon"], tprofservicerefund.Columns["nrefund"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// PROFSERVICESORTING /////////////////////////////////
	var tprofservicesorting= new DataTable("profservicesorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservicesorting.Columns.Add(C);
	tprofservicesorting.Columns.Add( new DataColumn("quota", typeof(double)));
	tprofservicesorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tprofservicesorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	Tables.Add(tprofservicesorting);
	tprofservicesorting.PrimaryKey =  new DataColumn[]{tprofservicesorting.Columns["idsor"], tprofservicesorting.Columns["ycon"], tprofservicesorting.Columns["ncon"]};


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
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


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
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("in_use", typeof(string)));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.PrimaryKey =  new DataColumn[]{taccmotiveapplied.Columns["idaccmotive"]};


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
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


	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new DataTable("accmotiveapplied_debit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("in_use", typeof(string)));
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.PrimaryKey =  new DataColumn[]{taccmotiveapplied_debit.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_CRG /////////////////////////////////
	var taccmotiveapplied_crg= new DataTable("accmotiveapplied_crg");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("in_use", typeof(string)));
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.PrimaryKey =  new DataColumn[]{taccmotiveapplied_crg.Columns["idaccmotive"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// DALIA_POSITION /////////////////////////////////
	var tdalia_position= new DataTable("dalia_position");
	C= new DataColumn("iddaliaposition", typeof(int));
	C.AllowDBNull=false;
	tdalia_position.Columns.Add(C);
	tdalia_position.Columns.Add( new DataColumn("codedaliaposition", typeof(string)));
	tdalia_position.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tdalia_position);
	tdalia_position.PrimaryKey =  new DataColumn[]{tdalia_position.Columns["iddaliaposition"]};


	//////////////////// PROFSERVICEAVCP /////////////////////////////////
	var tprofserviceavcp= new DataTable("profserviceavcp");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	C= new DataColumn("idavcp", typeof(int));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	tprofserviceavcp.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	C= new DataColumn("flagcontractor", typeof(string));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	tprofserviceavcp.Columns.Add( new DataColumn("flagnonparticipating", typeof(string)));
	tprofserviceavcp.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tprofserviceavcp.Columns.Add( new DataColumn("idavcp_role", typeof(string)));
	tprofserviceavcp.Columns.Add( new DataColumn("idmain_avcp", typeof(int)));
	tprofserviceavcp.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tprofserviceavcp.Columns.Add(C);
	tprofserviceavcp.Columns.Add( new DataColumn("!capogruppo", typeof(string)));
	Tables.Add(tprofserviceavcp);
	tprofserviceavcp.PrimaryKey =  new DataColumn[]{tprofserviceavcp.Columns["ycon"], tprofserviceavcp.Columns["ncon"], tprofserviceavcp.Columns["idavcp"]};


	//////////////////// PROFSERVICEAVCPDETAIL /////////////////////////////////
	var tprofserviceavcpdetail= new DataTable("profserviceavcpdetail");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofserviceavcpdetail.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofserviceavcpdetail.Columns.Add(C);
	C= new DataColumn("idavcp", typeof(int));
	C.AllowDBNull=false;
	tprofserviceavcpdetail.Columns.Add(C);
	C= new DataColumn("cigcode", typeof(string));
	C.AllowDBNull=false;
	tprofserviceavcpdetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofserviceavcpdetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofserviceavcpdetail.Columns.Add(C);
	Tables.Add(tprofserviceavcpdetail);
	tprofserviceavcpdetail.PrimaryKey =  new DataColumn[]{tprofserviceavcpdetail.Columns["ycon"], tprofserviceavcpdetail.Columns["ncon"], tprofserviceavcpdetail.Columns["idavcp"], tprofserviceavcpdetail.Columns["cigcode"]};


	//////////////////// PROFSERVICECIG /////////////////////////////////
	var tprofservicecig= new DataTable("profservicecig");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservicecig.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservicecig.Columns.Add(C);
	C= new DataColumn("cigcode", typeof(string));
	C.AllowDBNull=false;
	tprofservicecig.Columns.Add(C);
	tprofservicecig.Columns.Add( new DataColumn("contractamount", typeof(decimal)));
	tprofservicecig.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tprofservicecig.Columns.Add( new DataColumn("cu", typeof(string)));
	tprofservicecig.Columns.Add( new DataColumn("description", typeof(string)));
	tprofservicecig.Columns.Add( new DataColumn("idavcp", typeof(int)));
	tprofservicecig.Columns.Add( new DataColumn("idavcp_choice", typeof(string)));
	tprofservicecig.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tprofservicecig.Columns.Add( new DataColumn("lu", typeof(string)));
	tprofservicecig.Columns.Add( new DataColumn("start_contract", typeof(DateTime)));
	tprofservicecig.Columns.Add( new DataColumn("stop_contract", typeof(DateTime)));
	tprofservicecig.Columns.Add( new DataColumn("!capogruppo", typeof(string)));
	Tables.Add(tprofservicecig);
	tprofservicecig.PrimaryKey =  new DataColumn[]{tprofservicecig.Columns["ycon"], tprofservicecig.Columns["ncon"], tprofservicecig.Columns["cigcode"]};


	//////////////////// SORTINGVIEW1 /////////////////////////////////
	var tsortingview1= new DataTable("sortingview1");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	tsortingview1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	tsortingview1.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingview1.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview1.Columns.Add(C);
	tsortingview1.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview1.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview1.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview1.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview1.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview1.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview1.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview1);
	tsortingview1.PrimaryKey =  new DataColumn[]{tsortingview1.Columns["idsor"]};


	//////////////////// INVOICEDETAIL /////////////////////////////////
	var tinvoicedetail= new DataTable("invoicedetail");
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("paymentcompetency", typeof(DateTime)));
	tinvoicedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	tinvoicedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("manrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("nman", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("unabatable", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("yman", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("estimrownum", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("nestim", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yestim", typeof(short)));
	tinvoicedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idexp_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("ninv_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("yinv_main", typeof(short)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicedetail.Columns.Add(C);
	tinvoicedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatcode", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("weight", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("va3type", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("intrastatoperationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatservice", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idunit", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("npackage", typeof(decimal)));
	tinvoicedetail.Columns.Add( new DataColumn("flag", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("exception12", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("intra12operationkind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("move12", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idupb_iva", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idinvkind_main", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("leasing", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("usedmodesospesometro", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("resetresidualmandate", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idfetransfer", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("fereferencerule", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("rounding", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("flagbit", typeof(byte)));
	tinvoicedetail.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tinvoicedetail.Columns.Add( new DataColumn("ycon", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("ncon", typeof(int)));
	tinvoicedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tinvoicedetail);
	tinvoicedetail.PrimaryKey =  new DataColumn[]{tinvoicedetail.Columns["ninv"], tinvoicedetail.Columns["rownum"], tinvoicedetail.Columns["yinv"], tinvoicedetail.Columns["idinvkind"]};


	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new DataTable("sorting_siope");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siope.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siope.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_siope);
	tsorting_siope.PrimaryKey =  new DataColumn[]{tsorting_siope.Columns["idsor"]};


	//////////////////// DALIA_RECRUITMENTMOTIVE /////////////////////////////////
	var tdalia_recruitmentmotive= new DataTable("dalia_recruitmentmotive");
	C= new DataColumn("iddaliarecruitmentmotive", typeof(int));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdalia_recruitmentmotive.Columns.Add(C);
	Tables.Add(tdalia_recruitmentmotive);
	tdalia_recruitmentmotive.PrimaryKey =  new DataColumn[]{tdalia_recruitmentmotive.Columns["iddaliarecruitmentmotive"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting_siope.Columns["idsor"]};
	var cChild = new []{profservice.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_siope_profservice",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{profservicecig.Columns["ycon"], profservicecig.Columns["ncon"]};
	Relations.Add(new DataRelation("profservice_profservicecig",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{profserviceavcpdetail.Columns["ycon"], profserviceavcpdetail.Columns["ncon"]};
	Relations.Add(new DataRelation("FK_profservice_profserviceavcpdetail",cPar,cChild,false));

	cPar = new []{profserviceavcp.Columns["ycon"], profserviceavcp.Columns["ncon"], profserviceavcp.Columns["idavcp"]};
	cChild = new []{profserviceavcpdetail.Columns["ycon"], profserviceavcpdetail.Columns["ncon"], profserviceavcpdetail.Columns["idavcp"]};
	Relations.Add(new DataRelation("FK_profserviceavcp_profserviceavcpdetail",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{profserviceavcp.Columns["ycon"], profserviceavcp.Columns["ncon"]};
	Relations.Add(new DataRelation("FK_profservice_profserviceavcp",cPar,cChild,false));

	cPar = new []{profserviceavcp.Columns["ycon"], profserviceavcp.Columns["ncon"], profserviceavcp.Columns["idavcp"]};
	cChild = new []{profserviceavcp.Columns["ycon"], profserviceavcp.Columns["ncon"], profserviceavcp.Columns["idmain_avcp"]};
	Relations.Add(new DataRelation("FK_profserviceavcp_profserviceavcp",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{profservicesorting.Columns["ycon"], profservicesorting.Columns["ncon"]};
	Relations.Add(new DataRelation("profserviceprofcontractsorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{profservicesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingprofservicesorting",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{profservicerefund.Columns["ycon"], profservicerefund.Columns["ncon"]};
	Relations.Add(new DataRelation("profserviceprofservicerefund",cPar,cChild,false));

	cPar = new []{profrefund.Columns["idlinkedrefund"]};
	cChild = new []{profservicerefund.Columns["idlinkedrefund"]};
	Relations.Add(new DataRelation("profrefundprofservicerefund",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{profservice.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_profservice",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_profservice",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_profservice",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_profservice",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_profservice",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_profservice",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{profservice.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_profservice",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{profservice.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_profservice",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{profservice.Columns["idreg"]};
	Relations.Add(new DataRelation("registryprofservice",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{profservice.Columns["idser"]};
	Relations.Add(new DataRelation("serviceprofservice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{profservice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindprofservice",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1profservice",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2profservice",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{profservice.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3profservice",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{profservice.Columns["idupb"]};
	Relations.Add(new DataRelation("upbprofservice",cPar,cChild,false));

	cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	cChild = new []{profservice.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveappliedprofservice",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{profservice.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakindprofservice",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{profservicetax.Columns["ycon"], profservicetax.Columns["ncon"]};
	Relations.Add(new DataRelation("profserviceprofservicetax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{profservicetax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxprofservicetax",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{invoicedetail.Columns["ycon"], invoicedetail.Columns["ncon"]};
	Relations.Add(new DataRelation("profservice_invoicedetail",cPar,cChild,false));

	cPar = new []{dalia_recruitmentmotive.Columns["iddaliarecruitmentmotive"]};
	cChild = new []{profservice.Columns["iddaliarecruitmentmotive"]};
	Relations.Add(new DataRelation("dalia_recruitmentmotive_profservice",cPar,cChild,false));

	#endregion

}
}
}
