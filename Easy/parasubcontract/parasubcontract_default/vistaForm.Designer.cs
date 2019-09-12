/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
namespace parasubcontract_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontract 		=> Tables["parasubcontract"];

	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Descrizione Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollkind 		=> Tables["payrollkind"];

	///<summary>
	///Attivit√† Previdenziale INPS (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inpsactivity 		=> Tables["inpsactivity"];

	///<summary>
	///Altra Forma Assicurativa (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable otherinsurance 		=> Tables["otherinsurance"];

	///<summary>
	///Tipo libro matricola
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable matriculabook 		=> Tables["matriculabook"];

	///<summary>
	///Posizione Assicurativa Territoriale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pat 		=> Tables["pat"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Oneri Deducibili - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductibleexpense 		=> Tables["deductibleexpense"];

	///<summary>
	///Codici Deduzioni per Esercizio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deduction 		=> Tables["deduction"];

	///<summary>
	///Oneri Detraibili - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatableexpense 		=> Tables["abatableexpense"];

	///<summary>
	///Tipo detrazione, usato nei contratti parasubordinati
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatement 		=> Tables["abatement"];

	///<summary>
	///CUD Presentato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcud 		=> Tables["exhibitedcud"];

	///<summary>
	///Dettaglio Detrazioni CUD Presentato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcudabatement 		=> Tables["exhibitedcudabatement"];

	///<summary>
	///Dettaglio Deduzioni CUD Presentato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable exhibitedcuddeduction 		=> Tables["exhibitedcuddeduction"];

	///<summary>
	///Familiare - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractfamily 		=> Tables["parasubcontractfamily"];

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
	///Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city 		=> Tables["geo_city"];

	///<summary>
	///Altre Collaborazioni INAIL
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable otherinail 		=> Tables["otherinail"];

	///<summary>
	///Ritenuta Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltax 		=> Tables["payrolltax"];

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
	///Scaglione di un cedolino parasubordinato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxbracket 		=> Tables["payrolltaxbracket"];

	///<summary>
	///informazioni annuali sul contratto parasubordinato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractyear 		=> Tables["parasubcontractyear"];

	///<summary>
	///Tipo Rapporto (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emenscontractkind 		=> Tables["emenscontractkind"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Classificazione contratto parasubordinati
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractsorting 		=> Tables["parasubcontractsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensepayrollview 		=> Tables["expensepayrollview"];

	///<summary>
	///Comunicazioni da CAF
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cafdocument 		=> Tables["cafdocument"];

	///<summary>
	///Nomi e codici dei mesi nel codice fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tipocomunicazione 		=> Tables["tipocomunicazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_cost 		=> Tables["accmotiveapplied_cost"];

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

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Scaglioni Imposta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratebracket 		=> Tables["taxratebracket"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Storni Cedolino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxcorrige 		=> Tables["payrolltaxcorrige"];

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

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview1 		=> Tables["sortingview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll_altriesercizi 		=> Tables["payroll_altriesercizi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontractview 		=> Tables["parasubcontractview"];

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
	//////////////////// PARASUBCONTRACT /////////////////////////////////
	var tparasubcontract= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("duty", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idpat", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("matricula", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("txt", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tparasubcontract.Columns.Add( new DataColumn("idupb", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("idregistrylegalstatus", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("iddaliarecruitmentmotive", typeof(int)));
	Tables.Add(tparasubcontract);
	tparasubcontract.PrimaryKey =  new DataColumn[]{tparasubcontract.Columns["idcon"]};


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("servicecode770", typeof(string));
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
	tservice.Columns.Add( new DataColumn("flagdalia", typeof(string)));
	tservice.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tservice.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


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
	C= new DataColumn("idcountry", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("country", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestop", typeof(DateTime)));
	C= new DataColumn("idregion", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("region", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newregion", typeof(int)));
	C= new DataColumn("idnation", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("nation", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newnation", typeof(int)));
	Tables.Add(tgeo_cityview);
	tgeo_cityview.PrimaryKey =  new DataColumn[]{tgeo_cityview.Columns["idcity"]};


	//////////////////// PAYROLLKIND /////////////////////////////////
	var tpayrollkind= new DataTable("payrollkind");
	C= new DataColumn("idpayrollkind", typeof(string));
	C.AllowDBNull=false;
	tpayrollkind.Columns.Add(C);
	tpayrollkind.Columns.Add( new DataColumn("description", typeof(string)));
	tpayrollkind.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrollkind.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrollkind.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrollkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tpayrollkind);
	tpayrollkind.PrimaryKey =  new DataColumn[]{tpayrollkind.Columns["idpayrollkind"]};


	//////////////////// INPSACTIVITY /////////////////////////////////
	var tinpsactivity= new DataTable("inpsactivity");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tinpsactivity.Columns.Add(C);
	C= new DataColumn("activitycode", typeof(string));
	C.AllowDBNull=false;
	tinpsactivity.Columns.Add(C);
	tinpsactivity.Columns.Add( new DataColumn("description", typeof(string)));
	tinpsactivity.Columns.Add( new DataColumn("lu", typeof(string)));
	tinpsactivity.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tinpsactivity);
	tinpsactivity.PrimaryKey =  new DataColumn[]{tinpsactivity.Columns["activitycode"], tinpsactivity.Columns["ayear"]};


	//////////////////// OTHERINSURANCE /////////////////////////////////
	var totherinsurance= new DataTable("otherinsurance");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	C= new DataColumn("idotherinsurance", typeof(string));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	totherinsurance.Columns.Add( new DataColumn("lu", typeof(string)));
	totherinsurance.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(totherinsurance);
	totherinsurance.PrimaryKey =  new DataColumn[]{totherinsurance.Columns["idotherinsurance"], totherinsurance.Columns["ayear"]};


	//////////////////// MATRICULABOOK /////////////////////////////////
	var tmatriculabook= new DataTable("matriculabook");
	C= new DataColumn("idmatriculabook", typeof(string));
	C.AllowDBNull=false;
	tmatriculabook.Columns.Add(C);
	tmatriculabook.Columns.Add( new DataColumn("description", typeof(string)));
	tmatriculabook.Columns.Add( new DataColumn("cu", typeof(string)));
	tmatriculabook.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tmatriculabook.Columns.Add( new DataColumn("lu", typeof(string)));
	tmatriculabook.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tmatriculabook);
	tmatriculabook.PrimaryKey =  new DataColumn[]{tmatriculabook.Columns["idmatriculabook"]};


	//////////////////// PAT /////////////////////////////////
	var tpat= new DataTable("pat");
	C= new DataColumn("idpat", typeof(int));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	C= new DataColumn("patcode", typeof(string));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	tpat.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("active", typeof(string)));
	tpat.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("cu", typeof(string)));
	tpat.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("lu", typeof(string)));
	tpat.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tpat);
	tpat.PrimaryKey =  new DataColumn[]{tpat.Columns["idpat"]};


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
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// DEDUCTIBLEEXPENSE /////////////////////////////////
	var tdeductibleexpense= new DataTable("deductibleexpense");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	C= new DataColumn("totalamount", typeof(decimal));
	C.AllowDBNull=false;
	tdeductibleexpense.Columns.Add(C);
	tdeductibleexpense.Columns.Add( new DataColumn("cu", typeof(string)));
	tdeductibleexpense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tdeductibleexpense.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeductibleexpense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeductibleexpense.Columns.Add( new DataColumn("!descrdeduzione", typeof(string)));
	Tables.Add(tdeductibleexpense);
	tdeductibleexpense.PrimaryKey =  new DataColumn[]{tdeductibleexpense.Columns["ayear"], tdeductibleexpense.Columns["idcon"], tdeductibleexpense.Columns["iddeduction"]};


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


	//////////////////// ABATABLEEXPENSE /////////////////////////////////
	var tabatableexpense= new DataTable("abatableexpense");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tabatableexpense.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tabatableexpense.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatableexpense.Columns.Add(C);
	tabatableexpense.Columns.Add( new DataColumn("totalamount", typeof(decimal)));
	tabatableexpense.Columns.Add( new DataColumn("cu", typeof(string)));
	tabatableexpense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tabatableexpense.Columns.Add( new DataColumn("lu", typeof(string)));
	tabatableexpense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tabatableexpense.Columns.Add( new DataColumn("!descrdetrazione", typeof(string)));
	Tables.Add(tabatableexpense);
	tabatableexpense.PrimaryKey =  new DataColumn[]{tabatableexpense.Columns["ayear"], tabatableexpense.Columns["idcon"], tabatableexpense.Columns["idabatement"]};


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
	tabatement.Columns.Add( new DataColumn("description", typeof(string)));
	tabatement.Columns.Add( new DataColumn("evaluatesp", typeof(string)));
	tabatement.Columns.Add( new DataColumn("lu", typeof(string)));
	tabatement.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tabatement.Columns.Add( new DataColumn("appliance", typeof(string)));
	tabatement.Columns.Add( new DataColumn("flagabatableexpense", typeof(string)));
	Tables.Add(tabatement);
	tabatement.PrimaryKey =  new DataColumn[]{tabatement.Columns["idabatement"]};


	//////////////////// EXHIBITEDCUD /////////////////////////////////
	var texhibitedcud= new DataTable("exhibitedcud");
	texhibitedcud.Columns.Add( new DataColumn("idlinkedcon", typeof(string)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("nmonths", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	C= new DataColumn("taxablepension", typeof(decimal));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	C= new DataColumn("flagignoreprevcud", typeof(string));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("cfotherdeputy", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("transfermotive", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("inpsowed", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("inpsretained", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("irpefapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("irpefsuspended", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("regionaltaxapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("citytaxapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("cu", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texhibitedcud.Columns.Add( new DataColumn("lu", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	texhibitedcud.Columns.Add(C);
	texhibitedcud.Columns.Add( new DataColumn("ndays", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("citytax_account", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("idcity", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("idlinkeddbdepartment", typeof(string)));
	texhibitedcud.Columns.Add( new DataColumn("irpefgross", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("earnings_based_abatements", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusnotapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("fiscalbonusapplied", typeof(decimal)));
	texhibitedcud.Columns.Add( new DataColumn("flagbonusaccredited", typeof(int)));
	texhibitedcud.Columns.Add( new DataColumn("totabatements", typeof(decimal)));
	Tables.Add(texhibitedcud);
	texhibitedcud.PrimaryKey =  new DataColumn[]{texhibitedcud.Columns["idcon"], texhibitedcud.Columns["idexhibitedcud"]};


	//////////////////// EXHIBITEDCUDABATEMENT /////////////////////////////////
	var texhibitedcudabatement= new DataTable("exhibitedcudabatement");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcudabatement.Columns.Add(C);
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcudabatement.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	texhibitedcudabatement.Columns.Add(C);
	texhibitedcudabatement.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texhibitedcudabatement.Columns.Add( new DataColumn("!descrdetrazione", typeof(string)));
	Tables.Add(texhibitedcudabatement);
	texhibitedcudabatement.PrimaryKey =  new DataColumn[]{texhibitedcudabatement.Columns["idcon"], texhibitedcudabatement.Columns["idexhibitedcud"], texhibitedcudabatement.Columns["idabatement"]};


	//////////////////// EXHIBITEDCUDDEDUCTION /////////////////////////////////
	var texhibitedcuddeduction= new DataTable("exhibitedcuddeduction");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texhibitedcuddeduction.Columns.Add(C);
	C= new DataColumn("idexhibitedcud", typeof(int));
	C.AllowDBNull=false;
	texhibitedcuddeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	texhibitedcuddeduction.Columns.Add(C);
	texhibitedcuddeduction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texhibitedcuddeduction.Columns.Add( new DataColumn("!descrdeduzione", typeof(string)));
	Tables.Add(texhibitedcuddeduction);
	texhibitedcuddeduction.PrimaryKey =  new DataColumn[]{texhibitedcuddeduction.Columns["idcon"], texhibitedcuddeduction.Columns["idexhibitedcud"], texhibitedcuddeduction.Columns["iddeduction"]};


	//////////////////// PARASUBCONTRACTFAMILY /////////////////////////////////
	var tparasubcontractfamily= new DataTable("parasubcontractfamily");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("idfamily", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("idaffinity", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("surname", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("forename", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("idcitybirth", typeof(int)));
	tparasubcontractfamily.Columns.Add( new DataColumn("idnation", typeof(int)));
	tparasubcontractfamily.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("gender", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("cf", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("startapplication", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("stopapplication", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("appliancepercentage", typeof(decimal)));
	tparasubcontractfamily.Columns.Add( new DataColumn("starthandicap", typeof(DateTime)));
	C= new DataColumn("foreignresident", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	C= new DataColumn("flagdependent", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractfamily.Columns.Add(C);
	tparasubcontractfamily.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tparasubcontractfamily.Columns.Add( new DataColumn("childasparent", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontractfamily.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontractfamily.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	Tables.Add(tparasubcontractfamily);
	tparasubcontractfamily.PrimaryKey =  new DataColumn[]{tparasubcontractfamily.Columns["idcon"], tparasubcontractfamily.Columns["idfamily"], tparasubcontractfamily.Columns["ayear"]};


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
	tdeductioncode.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("lt", typeof(DateTime)));
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


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("npayroll", typeof(int)));
	C= new DataColumn("flagbalance", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("netfee", typeof(decimal)));
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
	tpayroll.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new DataTable("geo_city");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city.Columns.Add(C);
	tgeo_city.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("oldcity", typeof(int)));
	Tables.Add(tgeo_city);
	tgeo_city.PrimaryKey =  new DataColumn[]{tgeo_city.Columns["idcity"]};


	//////////////////// OTHERINAIL /////////////////////////////////
	var totherinail= new DataTable("otherinail");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	totherinail.Columns.Add(C);
	C= new DataColumn("idotherinail", typeof(int));
	C.AllowDBNull=false;
	totherinail.Columns.Add(C);
	totherinail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	totherinail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	totherinail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	totherinail.Columns.Add( new DataColumn("nmonths", typeof(int)));
	Tables.Add(totherinail);
	totherinail.PrimaryKey =  new DataColumn[]{totherinail.Columns["idcon"], totherinail.Columns["idotherinail"]};


	//////////////////// PAYROLLTAX /////////////////////////////////
	var tpayrolltax= new DataTable("payrolltax");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	tpayrolltax.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
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
	tpayrolltax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtaxgross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualtaxabletotal", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualpayedemploytax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("annualcreditapplied", typeof(decimal)));
	Tables.Add(tpayrolltax);
	tpayrolltax.PrimaryKey =  new DataColumn[]{tpayrolltax.Columns["idpayroll"], tpayrolltax.Columns["idpayrolltax"]};


	//////////////////// PAYROLLDEDUCTION /////////////////////////////////
	var tpayrolldeduction= new DataTable("payrolldeduction");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	tpayrolldeduction.Columns.Add( new DataColumn("taxablecode", typeof(string)));
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
	tpayrollabatement.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrollabatement.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrollabatement.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrollabatement);
	tpayrollabatement.PrimaryKey =  new DataColumn[]{tpayrollabatement.Columns["idpayroll"], tpayrollabatement.Columns["idabatement"]};


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


	//////////////////// PARASUBCONTRACTYEAR /////////////////////////////////
	var tparasubcontractyear= new DataTable("parasubcontractyear");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractyear.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractyear.Columns.Add(C);
	tparasubcontractyear.Columns.Add( new DataColumn("regionaltax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("countrytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("citytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("suspendedcountrytax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("idotherinsurance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("activitycode", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("cu", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("notaxappliance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("applybrackets", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("highertax", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablecud", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("cuddays", typeof(short)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablecontract", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ndays", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablepension", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("fiscaldeduction", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("notaxdeduction", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	tparasubcontractyear.Columns.Add( new DataColumn("idresidence", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("idemenscontractkind", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("citytax_account", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("ratequantity_account", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("startmonth_account", typeof(int)));
	tparasubcontractyear.Columns.Add( new DataColumn("annualincome", typeof(decimal)));
	tparasubcontractyear.Columns.Add( new DataColumn("flagbonusappliance", typeof(string)));
	tparasubcontractyear.Columns.Add( new DataColumn("flagexcludefromcertificate", typeof(string)));
	Tables.Add(tparasubcontractyear);
	tparasubcontractyear.PrimaryKey =  new DataColumn[]{tparasubcontractyear.Columns["ayear"], tparasubcontractyear.Columns["idcon"]};


	//////////////////// EMENSCONTRACTKIND /////////////////////////////////
	var temenscontractkind= new DataTable("emenscontractkind");
	C= new DataColumn("idemenscontractkind", typeof(string));
	C.AllowDBNull=false;
	temenscontractkind.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	temenscontractkind.Columns.Add(C);
	temenscontractkind.Columns.Add( new DataColumn("description", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("annotations", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("flagactivityrequested", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("module", typeof(string)));
	temenscontractkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(temenscontractkind);
	temenscontractkind.PrimaryKey =  new DataColumn[]{temenscontractkind.Columns["idemenscontractkind"], temenscontractkind.Columns["ayear"]};


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


	//////////////////// PARASUBCONTRACTSORTING /////////////////////////////////
	var tparasubcontractsorting= new DataTable("parasubcontractsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractsorting.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontractsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontractsorting.Columns.Add(C);
	tparasubcontractsorting.Columns.Add( new DataColumn("quota", typeof(double)));
	tparasubcontractsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tparasubcontractsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	Tables.Add(tparasubcontractsorting);
	tparasubcontractsorting.PrimaryKey =  new DataColumn[]{tparasubcontractsorting.Columns["idcon"], tparasubcontractsorting.Columns["idsor"]};


	//////////////////// EXPENSEPAYROLLVIEW /////////////////////////////////
	var texpensepayrollview= new DataTable("expensepayrollview");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	texpensepayrollview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	texpensepayrollview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpensepayrollview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	texpensepayrollview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensepayrollview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpensepayrollview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpensepayrollview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpensepayrollview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("service", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpensepayrollview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpensepayrollview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpensepayrollview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensepayrollview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpensepayrollview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	texpensepayrollview.Columns.Add( new DataColumn("cu", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	texpensepayrollview.Columns.Add( new DataColumn("lu", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	texpensepayrollview.Columns.Add(C);
	texpensepayrollview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpensepayrollview.Columns.Add( new DataColumn("upb", typeof(string)));
	Tables.Add(texpensepayrollview);

	//////////////////// CAFDOCUMENT /////////////////////////////////
	var tcafdocument= new DataTable("cafdocument");
	C= new DataColumn("idcafdocument", typeof(int));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("cafdocumentkind", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("docdate", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	tcafdocument.Columns.Add( new DataColumn("citytaxtorefundhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtoretainhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxtoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtorefundhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtoretainhusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("regionaltaxtoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("idcity", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tcafdocument.Columns.Add( new DataColumn("irpeftorefund", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("irpeftoretain", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("monthfirstinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("monthsecondinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("nquotafirstinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("nquotasecondinstalment", typeof(int)));
	tcafdocument.Columns.Add( new DataColumn("firstrateadvance", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("separatedincomehusband", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("separatedincome", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("secondrateadvance", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcafdocument.Columns.Add(C);
	tcafdocument.Columns.Add( new DataColumn("!descrcomunicazione", typeof(string)));
	tcafdocument.Columns.Add( new DataColumn("citytaxaccount", typeof(decimal)));
	tcafdocument.Columns.Add( new DataColumn("citytaxaccounthusband", typeof(decimal)));
	Tables.Add(tcafdocument);
	tcafdocument.PrimaryKey =  new DataColumn[]{tcafdocument.Columns["idcafdocument"], tcafdocument.Columns["idcon"]};


	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new DataTable("monthname");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname.Columns.Add(C);
	tmonthname.Columns.Add( new DataColumn("title", typeof(string)));
	tmonthname.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	Tables.Add(tmonthname);
	tmonthname.PrimaryKey =  new DataColumn[]{tmonthname.Columns["code"]};


	//////////////////// TIPOCOMUNICAZIONE /////////////////////////////////
	var ttipocomunicazione= new DataTable("tipocomunicazione");
	C= new DataColumn("codice", typeof(string));
	C.AllowDBNull=false;
	ttipocomunicazione.Columns.Add(C);
	ttipocomunicazione.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttipocomunicazione);
	ttipocomunicazione.PrimaryKey =  new DataColumn[]{ttipocomunicazione.Columns["codice"]};


	//////////////////// ACCMOTIVEAPPLIED_COST /////////////////////////////////
	var taccmotiveapplied_cost= new DataTable("accmotiveapplied_cost");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	taccmotiveapplied_cost.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	taccmotiveapplied_cost.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	taccmotiveapplied_cost.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("in_use", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.PrimaryKey =  new DataColumn[]{taccmotiveapplied_cost.Columns["idaccmotive"]};


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
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
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
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxref", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXRATEBRACKET /////////////////////////////////
	var ttaxratebracket= new DataTable("taxratebracket");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("idtaxratestart", typeof(int));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(short));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	ttaxratebracket.Columns.Add( new DataColumn("minamount", typeof(decimal)));
	ttaxratebracket.Columns.Add( new DataColumn("maxamount", typeof(decimal)));
	C= new DataColumn("admindenominator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("adminnumerator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("adminrate", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("employdenominator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("employnumerator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("employrate", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	Tables.Add(ttaxratebracket);
	ttaxratebracket.PrimaryKey =  new DataColumn[]{ttaxratebracket.Columns["taxcode"], ttaxratebracket.Columns["idtaxratestart"], ttaxratebracket.Columns["nbracket"]};


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


	//////////////////// PAYROLLTAXCORRIGE /////////////////////////////////
	var tpayrolltaxcorrige= new DataTable("payrolltaxcorrige");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("idpayrolltaxcorrige", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxcorrige.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
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
	tpayrolltaxcorrige.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	Tables.Add(tpayrolltaxcorrige);
	tpayrolltaxcorrige.PrimaryKey =  new DataColumn[]{tpayrolltaxcorrige.Columns["idpayroll"], tpayrolltaxcorrige.Columns["idpayrolltaxcorrige"]};


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
	taccmotiveapplied_debit.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("flagdep", typeof(string)));
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
	taccmotiveapplied_crg.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("flagdep", typeof(string)));
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


	//////////////////// PAYROLL_ALTRIESERCIZI /////////////////////////////////
	var tpayroll_altriesercizi= new DataTable("payroll_altriesercizi");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	tpayroll_altriesercizi.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayroll_altriesercizi.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	tpayroll_altriesercizi.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	C= new DataColumn("flagbalance", typeof(string));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	tpayroll_altriesercizi.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayroll_altriesercizi.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayroll_altriesercizi.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayroll_altriesercizi.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll_altriesercizi.Columns.Add(C);
	tpayroll_altriesercizi.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpayroll_altriesercizi.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpayroll_altriesercizi.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	Tables.Add(tpayroll_altriesercizi);
	tpayroll_altriesercizi.PrimaryKey =  new DataColumn[]{tpayroll_altriesercizi.Columns["idpayroll"]};


	//////////////////// PARASUBCONTRACTVIEW /////////////////////////////////
	var tparasubcontractview= new DataTable("parasubcontractview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tparasubcontractview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("registry", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("codedaliaposition", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("daliaposition", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("matricula", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("duty", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("payroll", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("service", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("codeser", typeof(string)));
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
	tparasubcontractview.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("matriculabook", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("regionaltax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("countrytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("citytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("ratequantity", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("startmonth", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedregionaltax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedcountrytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("suspendedcitytax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("notaxappliance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("applybrackets", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("highertax", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablecud", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("cuddays", typeof(short)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablecontract", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("ndays", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablepension", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("fiscaldeduction", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("notaxdeduction", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("startcompetency", typeof(DateTime)));
	tparasubcontractview.Columns.Add( new DataColumn("stopcompetency", typeof(DateTime)));
	tparasubcontractview.Columns.Add( new DataColumn("idemenscontractkind", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("txt", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("emenscontractkind", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("annualincome", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("flagbonusappliance", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("flagexcludefromcertificate", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("citytax_account", typeof(decimal)));
	tparasubcontractview.Columns.Add( new DataColumn("ratequantity_account", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("startmonth_account", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("codemotivedebit", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("codemotivedebit_crg", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tparasubcontractview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tparasubcontractview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	C= new DataColumn("idrelated", typeof(string));
	C.ReadOnly=true;
	tparasubcontractview.Columns.Add(C);
	tparasubcontractview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tparasubcontractview.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	Tables.Add(tparasubcontractview);
	tparasubcontractview.PrimaryKey =  new DataColumn[]{tparasubcontractview.Columns["ayear"], tparasubcontractview.Columns["idcon"]};


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
	var cPar = new []{tax.Columns["taxcode"]};
	var cChild = new []{payrolltaxcorrige.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_payrolltaxcorrige",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltaxcorrige.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltaxcorrige",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{cafdocument.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractcafdocument",cPar,cChild,false));

	cPar = new []{tipocomunicazione.Columns["codice"]};
	cChild = new []{cafdocument.Columns["cafdocumentkind"]};
	Relations.Add(new DataRelation("tipocomunicazionecafdocument",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{expensepayrollview.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractexpensepayrollview",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractsorting.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractsorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{parasubcontractsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingparasubcontractsorting",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractyear.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractyear",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{parasubcontractyear.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_cityviewparasubcontractyear",cPar,cChild,false));

	cPar = new []{otherinsurance.Columns["idotherinsurance"]};
	cChild = new []{parasubcontractyear.Columns["idotherinsurance"]};
	Relations.Add(new DataRelation("otherinsuranceparasubcontractyear",cPar,cChild,false));

	cPar = new []{inpsactivity.Columns["activitycode"]};
	cChild = new []{parasubcontractyear.Columns["activitycode"]};
	Relations.Add(new DataRelation("inpsactivityparasubcontractyear",cPar,cChild,false));

	cPar = new []{emenscontractkind.Columns["idemenscontractkind"]};
	cChild = new []{parasubcontractyear.Columns["idemenscontractkind"]};
	Relations.Add(new DataRelation("emenscontractkindparasubcontractyear",cPar,cChild,false));

	cPar = new []{payrolltax.Columns["idpayroll"], payrolltax.Columns["idpayrolltax"]};
	cChild = new []{payrolltaxbracket.Columns["idpayroll"], payrolltaxbracket.Columns["idpayrolltax"]};
	Relations.Add(new DataRelation("payrolltaxpayrolltaxbracket",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrollabatement.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrollabatement",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolldeduction.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolldeduction",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payrolltax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayrolltax",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltax",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{otherinail.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractotherinail",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{payroll.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_citypayroll",cPar,cChild,false));

	cPar = new []{parasubcontractyear.Columns["ayear"], parasubcontractyear.Columns["idcon"]};
	cChild = new []{payroll.Columns["fiscalyear"], payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractyearpayroll",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{parasubcontractfamily.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractparasubcontractfamily",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{exhibitedcuddeduction.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractexhibitedcuddeduction",cPar,cChild,false));

	cPar = new []{exhibitedcud.Columns["idcon"], exhibitedcud.Columns["idexhibitedcud"]};
	cChild = new []{exhibitedcuddeduction.Columns["idcon"], exhibitedcuddeduction.Columns["idexhibitedcud"]};
	Relations.Add(new DataRelation("exhibitedcudexhibitedcuddeduction",cPar,cChild,false));

	cPar = new []{deductioncode.Columns["iddeduction"]};
	cChild = new []{exhibitedcuddeduction.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductioncodeexhibitedcuddeduction",cPar,cChild,false));

	cPar = new []{exhibitedcud.Columns["idcon"], exhibitedcud.Columns["idexhibitedcud"]};
	cChild = new []{exhibitedcudabatement.Columns["idcon"], exhibitedcudabatement.Columns["idexhibitedcud"]};
	Relations.Add(new DataRelation("exhibitedcudexhibitedcudabatement",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{exhibitedcudabatement.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractexhibitedcudabatement",cPar,cChild,false));

	cPar = new []{abatementcode.Columns["idabatement"]};
	cChild = new []{exhibitedcudabatement.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementcodeexhibitedcudabatement",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{exhibitedcud.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractexhibitedcud",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{abatableexpense.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractabatableexpense",cPar,cChild,false));

	cPar = new []{abatementcode.Columns["idabatement"]};
	cChild = new []{abatableexpense.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementcodeabatableexpense",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{deductibleexpense.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractdeductibleexpense",cPar,cChild,false));

	cPar = new []{deductioncode.Columns["iddeduction"]};
	cChild = new []{deductibleexpense.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductioncodedeductibleexpense",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{parasubcontract.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_parasubcontract",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_parasubcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{parasubcontract.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_parasubcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{parasubcontract.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_parasubcontract",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{parasubcontract.Columns["idupb"]};
	Relations.Add(new DataRelation("upbparasubcontract",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3parasubcontract",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2parasubcontract",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1parasubcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_cost.Columns["idaccmotive"]};
	cChild = new []{parasubcontract.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveappliedparasubcontract",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{parasubcontract.Columns["idser"]};
	Relations.Add(new DataRelation("serviceparasubcontract",cPar,cChild,false));

	cPar = new []{payrollkind.Columns["idpayrollkind"]};
	cChild = new []{parasubcontract.Columns["idpayrollkind"]};
	Relations.Add(new DataRelation("payrollkindparasubcontract",cPar,cChild,false));

	cPar = new []{matriculabook.Columns["idmatriculabook"]};
	cChild = new []{parasubcontract.Columns["idmatriculabook"]};
	Relations.Add(new DataRelation("matriculabookparasubcontract",cPar,cChild,false));

	cPar = new []{pat.Columns["idpat"]};
	cChild = new []{parasubcontract.Columns["idpat"]};
	Relations.Add(new DataRelation("patparasubcontract",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{parasubcontract.Columns["idreg"]};
	Relations.Add(new DataRelation("registryparasubcontract",cPar,cChild,false));

	cPar = new []{parasubcontract.Columns["idcon"]};
	cChild = new []{payroll_altriesercizi.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontract_payroll_altriesercizi",cPar,cChild,false));

	cPar = new []{payroll_altriesercizi.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payroll_altriesercizi_payrolltax",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{payroll_altriesercizi.Columns["idresidence"]};
	Relations.Add(new DataRelation("geo_city_payroll_altriesercizi",cPar,cChild,false));

	cPar = new []{payroll_altriesercizi.Columns["idpayroll"]};
	cChild = new []{payrolltaxcorrige.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payroll_altriesercizi_payrolltaxcorrige",cPar,cChild,false));

	cPar = new []{payroll_altriesercizi.Columns["idpayroll"]};
	cChild = new []{payrolldeduction.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payroll_altriesercizi_payrolldeduction",cPar,cChild,false));

	cPar = new []{payroll_altriesercizi.Columns["idpayroll"]};
	cChild = new []{payrollabatement.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payroll_altriesercizi_payrollabatement",cPar,cChild,false));

	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{parasubcontract.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_parasubcontract",cPar,cChild,false));

	cPar = new []{dalia_recruitmentmotive.Columns["iddaliarecruitmentmotive"]};
	cChild = new []{parasubcontract.Columns["iddaliarecruitmentmotive"]};
	Relations.Add(new DataRelation("dalia_recruitmentmotive_parasubcontract",cPar,cChild,false));

	#endregion

}
}
}
