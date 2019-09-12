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
namespace casualcontract_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Pagamento Prestazione Occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontract 		=> Tables["casualcontract"];

	///<summary>
	///Ritenute
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontracttax 		=> Tables["casualcontracttax"];

	///<summary>
	///Scaglione ritenute su occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontracttaxbracket 		=> Tables["casualcontracttaxbracket"];

	///<summary>
	///Spese Documentate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontractrefund 		=> Tables["casualcontractrefund"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	///<summary>
	///Altra Forma Assicurativa (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable otherinsurance 		=> Tables["otherinsurance"];

	///<summary>
	///Attivit√† Previdenziale INPS (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inpsactivity 		=> Tables["inpsactivity"];

	///<summary>
	///Informazioni annual sul contratto occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontractyear 		=> Tables["casualcontractyear"];

	///<summary>
	///Tipo Spesa occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualrefund 		=> Tables["casualrefund"];

	///<summary>
	///Quota Esente Prestazione Occasionale per Imponibile Previdenziale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontractexemption 		=> Tables["casualcontractexemption"];

	///<summary>
	///Tipo Rapporto (per l'E-Mens)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable emenscontractkind 		=> Tables["emenscontractkind"];

	///<summary>
	///Deduzione su contr.occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontractdeduction 		=> Tables["casualcontractdeduction"];

	///<summary>
	///Detrazione su compenso occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualdeduction 		=> Tables["casualdeduction"];

	///<summary>
	///Classificazione contratto occasionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontractsorting 		=> Tables["casualcontractsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_cost 		=> Tables["accmotiveapplied_cost"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	///<summary>
	///Scaglioni Imposta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratebracket 		=> Tables["taxratebracket"];

	///<summary>
	///Abbinamento prestazione con la causale del modello 770
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable motive770service 		=> Tables["motive770service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_debit 		=> Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_crg 		=> Tables["accmotiveapplied_crg"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

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
	///Registro unico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable uniqueregister 		=> Tables["uniqueregister"];

	///<summary>
	///Codice IPA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ipa 		=> Tables["ipa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccview 		=> Tables["pccview"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitmotive 		=> Tables["pccdebitmotive"];

	///<summary>
	///trattasi di valori codificati dalla PCC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitstatus 		=> Tables["pccdebitstatus"];

	///<summary>
	///Posizione Dalia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_position 		=> Tables["dalia_position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview1 		=> Tables["sortingview1"];

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
	//////////////////// CASUALCONTRACT /////////////////////////////////
	var tcasualcontract= new DataTable("casualcontract");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("description", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("ndays", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("!codiceritenutainps", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("txt", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tcasualcontract.Columns.Add( new DataColumn("completed", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("authneeded", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("authdoc", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("authdocdate", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("noauthreason", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("arrivaldate", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("annotations", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("resendingpcc", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("expensekind", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idpccdebitmotive", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("datecompleted", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("iddaliarecruitmentmotive", typeof(int)));
	Tables.Add(tcasualcontract);
	tcasualcontract.PrimaryKey =  new DataColumn[]{tcasualcontract.Columns["ycon"], tcasualcontract.Columns["ncon"]};


	//////////////////// CASUALCONTRACTTAX /////////////////////////////////
	var tcasualcontracttax= new DataTable("casualcontracttax");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttax.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttax.Columns.Add(C);
	tcasualcontracttax.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tcasualcontracttax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("employtaxgross", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("cu", typeof(string)));
	tcasualcontracttax.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcasualcontracttax.Columns.Add( new DataColumn("lu", typeof(string)));
	tcasualcontracttax.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcasualcontracttax.Columns.Add( new DataColumn("!tiporitenuta", typeof(string)));
	tcasualcontracttax.Columns.Add( new DataColumn("!taxref", typeof(string)));
	tcasualcontracttax.Columns.Add( new DataColumn("deduction", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("!imponibilenetto", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("!aliquotaamm", typeof(decimal)));
	tcasualcontracttax.Columns.Add( new DataColumn("!aliquotadip", typeof(decimal)));
	Tables.Add(tcasualcontracttax);
	tcasualcontracttax.PrimaryKey =  new DataColumn[]{tcasualcontracttax.Columns["ycon"], tcasualcontracttax.Columns["ncon"], tcasualcontracttax.Columns["taxcode"]};


	//////////////////// CASUALCONTRACTTAXBRACKET /////////////////////////////////
	var tcasualcontracttaxbracket= new DataTable("casualcontracttaxbracket");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontracttaxbracket.Columns.Add(C);
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("!imponibile", typeof(decimal)));
	tcasualcontracttaxbracket.Columns.Add( new DataColumn("!taxref", typeof(string)));
	Tables.Add(tcasualcontracttaxbracket);
	tcasualcontracttaxbracket.PrimaryKey =  new DataColumn[]{tcasualcontracttaxbracket.Columns["ycon"], tcasualcontracttaxbracket.Columns["ncon"], tcasualcontracttaxbracket.Columns["taxcode"], tcasualcontracttaxbracket.Columns["nbracket"]};


	//////////////////// CASUALCONTRACTREFUND /////////////////////////////////
	var tcasualcontractrefund= new DataTable("casualcontractrefund");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	tcasualcontractrefund.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tcasualcontractrefund.Columns.Add( new DataColumn("!tipodeduzione", typeof(string)));
	C= new DataColumn("idlinkedrefund", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	tcasualcontractrefund.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractrefund.Columns.Add(C);
	tcasualcontractrefund.Columns.Add( new DataColumn("ayear", typeof(int)));
	Tables.Add(tcasualcontractrefund);
	tcasualcontractrefund.PrimaryKey =  new DataColumn[]{tcasualcontractrefund.Columns["ycon"], tcasualcontractrefund.Columns["ncon"], tcasualcontractrefund.Columns["nrefund"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
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
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


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


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("codeser", typeof(string));
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
	tservice.Columns.Add( new DataColumn("flagnoexemptionquote", typeof(string)));
	tservice.Columns.Add( new DataColumn("servicecode770", typeof(string)));
	tservice.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


	//////////////////// OTHERINSURANCE /////////////////////////////////
	var totherinsurance= new DataTable("otherinsurance");
	C= new DataColumn("idotherinsurance", typeof(string));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	totherinsurance.Columns.Add(C);
	totherinsurance.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	totherinsurance.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(totherinsurance);
	totherinsurance.PrimaryKey =  new DataColumn[]{totherinsurance.Columns["idotherinsurance"], totherinsurance.Columns["ayear"]};


	//////////////////// INPSACTIVITY /////////////////////////////////
	var tinpsactivity= new DataTable("inpsactivity");
	C= new DataColumn("activitycode", typeof(string));
	C.AllowDBNull=false;
	tinpsactivity.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tinpsactivity.Columns.Add(C);
	tinpsactivity.Columns.Add( new DataColumn("description", typeof(string)));
	tinpsactivity.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tinpsactivity.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tinpsactivity);
	tinpsactivity.PrimaryKey =  new DataColumn[]{tinpsactivity.Columns["activitycode"], tinpsactivity.Columns["ayear"]};


	//////////////////// CASUALCONTRACTYEAR /////////////////////////////////
	var tcasualcontractyear= new DataTable("casualcontractyear");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractyear.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractyear.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractyear.Columns.Add(C);
	tcasualcontractyear.Columns.Add( new DataColumn("activitycode", typeof(string)));
	tcasualcontractyear.Columns.Add( new DataColumn("idotherinsurance", typeof(string)));
	tcasualcontractyear.Columns.Add( new DataColumn("idemenscontractkind", typeof(string)));
	tcasualcontractyear.Columns.Add( new DataColumn("taxableotheragency", typeof(decimal)));
	tcasualcontractyear.Columns.Add( new DataColumn("flaghigherrate", typeof(string)));
	tcasualcontractyear.Columns.Add( new DataColumn("higherrate", typeof(decimal)));
	Tables.Add(tcasualcontractyear);
	tcasualcontractyear.PrimaryKey =  new DataColumn[]{tcasualcontractyear.Columns["ayear"], tcasualcontractyear.Columns["ycon"], tcasualcontractyear.Columns["ncon"]};


	//////////////////// CASUALREFUND /////////////////////////////////
	var tcasualrefund= new DataTable("casualrefund");
	C= new DataColumn("idlinkedrefund", typeof(string));
	C.AllowDBNull=false;
	tcasualrefund.Columns.Add(C);
	tcasualrefund.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcasualrefund.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualrefund.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcasualrefund.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualrefund.Columns.Add(C);
	tcasualrefund.Columns.Add( new DataColumn("deduction", typeof(string)));
	tcasualrefund.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	Tables.Add(tcasualrefund);
	tcasualrefund.PrimaryKey =  new DataColumn[]{tcasualrefund.Columns["idlinkedrefund"]};


	//////////////////// CASUALCONTRACTEXEMPTION /////////////////////////////////
	var tcasualcontractexemption= new DataTable("casualcontractexemption");
	C= new DataColumn("startvalidity", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractexemption.Columns.Add(C);
	tcasualcontractexemption.Columns.Add( new DataColumn("exemptionquota", typeof(decimal)));
	tcasualcontractexemption.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tcasualcontractexemption);
	tcasualcontractexemption.PrimaryKey =  new DataColumn[]{tcasualcontractexemption.Columns["startvalidity"]};


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
	temenscontractkind.PrimaryKey =  new DataColumn[]{temenscontractkind.Columns["ayear"], temenscontractkind.Columns["idemenscontractkind"]};


	//////////////////// CASUALCONTRACTDEDUCTION /////////////////////////////////
	var tcasualcontractdeduction= new DataTable("casualcontractdeduction");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	tcasualcontractdeduction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractdeduction.Columns.Add(C);
	Tables.Add(tcasualcontractdeduction);
	tcasualcontractdeduction.PrimaryKey =  new DataColumn[]{tcasualcontractdeduction.Columns["ycon"], tcasualcontractdeduction.Columns["ncon"], tcasualcontractdeduction.Columns["iddeduction"]};


	//////////////////// CASUALDEDUCTION /////////////////////////////////
	var tcasualdeduction= new DataTable("casualdeduction");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tcasualdeduction.Columns.Add(C);
	tcasualdeduction.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcasualdeduction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualdeduction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcasualdeduction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualdeduction.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	tcasualdeduction.Columns.Add(C);
	Tables.Add(tcasualdeduction);
	tcasualdeduction.PrimaryKey =  new DataColumn[]{tcasualdeduction.Columns["iddeduction"]};


	//////////////////// CASUALCONTRACTSORTING /////////////////////////////////
	var tcasualcontractsorting= new DataTable("casualcontractsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontractsorting.Columns.Add(C);
	tcasualcontractsorting.Columns.Add( new DataColumn("quota", typeof(double)));
	tcasualcontractsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tcasualcontractsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tcasualcontractsorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	Tables.Add(tcasualcontractsorting);
	tcasualcontractsorting.PrimaryKey =  new DataColumn[]{tcasualcontractsorting.Columns["idsor"], tcasualcontractsorting.Columns["ycon"], tcasualcontractsorting.Columns["ncon"]};


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
	taccmotiveapplied_cost.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("in_use", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.PrimaryKey =  new DataColumn[]{taccmotiveapplied_cost.Columns["idaccmotive"]};


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


	//////////////////// MOTIVE770SERVICE /////////////////////////////////
	var tmotive770service= new DataTable("motive770service");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tmotive770service.Columns.Add(C);
	tmotive770service.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tmotive770service.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("idmot", typeof(string));
	C.AllowDBNull=false;
	tmotive770service.Columns.Add(C);
	tmotive770service.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tmotive770service.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tmotive770service.Columns.Add(C);
	Tables.Add(tmotive770service);
	tmotive770service.PrimaryKey =  new DataColumn[]{tmotive770service.Columns["ayear"], tmotive770service.Columns["idser"]};


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
	taccmotiveapplied_debit.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
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
	taccmotiveapplied_crg.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_crg.Columns.Add(C);
	taccmotiveapplied_crg.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_crg.Columns.Add( new DataColumn("flagdep", typeof(string)));
	Tables.Add(taccmotiveapplied_crg);
	taccmotiveapplied_crg.PrimaryKey =  new DataColumn[]{taccmotiveapplied_crg.Columns["idaccmotive"]};


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
	tconfig.Columns.Add( new DataColumn("cudactivitycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagivapaybyrow", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("invoice_flagregister", typeof(string)));
	tconfig.Columns.Add( new DataColumn("default_idfinvarstatus", typeof(short)));
	tconfig.Columns.Add( new DataColumn("flagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainflagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagva3", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("paymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("minrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idreg_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("finvar_warnmail", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_revenue_gross_csa", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idfinincome_gross_csa", typeof(int)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


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


	//////////////////// UNIQUEREGISTER /////////////////////////////////
	var tuniqueregister= new DataTable("uniqueregister");
	C= new DataColumn("iduniqueregister", typeof(int));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	tuniqueregister.Columns.Add( new DataColumn("yinv", typeof(short)));
	tuniqueregister.Columns.Add( new DataColumn("ninv", typeof(int)));
	tuniqueregister.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	tuniqueregister.Columns.Add( new DataColumn("yman", typeof(short)));
	tuniqueregister.Columns.Add( new DataColumn("nman", typeof(int)));
	tuniqueregister.Columns.Add( new DataColumn("idmankind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tuniqueregister.Columns.Add(C);
	Tables.Add(tuniqueregister);
	tuniqueregister.PrimaryKey =  new DataColumn[]{tuniqueregister.Columns["iduniqueregister"], tuniqueregister.Columns["ycon"], tuniqueregister.Columns["ncon"]};


	//////////////////// IPA /////////////////////////////////
	var tipa= new DataTable("ipa");
	C= new DataColumn("ipa_fe", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("agencyname", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	C= new DataColumn("officename", typeof(string));
	C.AllowDBNull=false;
	tipa.Columns.Add(C);
	tipa.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tipa.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tipa.Columns.Add( new DataColumn("cu", typeof(string)));
	tipa.Columns.Add( new DataColumn("lu", typeof(string)));
	tipa.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tipa.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tipa);
	tipa.PrimaryKey =  new DataColumn[]{tipa.Columns["ipa_fe"]};


	//////////////////// PCCVIEW /////////////////////////////////
	var tpccview= new DataTable("pccview");
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	tpccview.Columns.Add(C);
	C= new DataColumn("idpcc", typeof(int));
	C.AllowDBNull=false;
	tpccview.Columns.Add(C);
	tpccview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tpccview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tpccview.Columns.Add( new DataColumn("yinv", typeof(short)));
	tpccview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tpccview.Columns.Add( new DataColumn("ycon", typeof(int)));
	tpccview.Columns.Add( new DataColumn("ncon", typeof(int)));
	tpccview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tpccview.Columns.Add( new DataColumn("mandatekind", typeof(string)));
	tpccview.Columns.Add( new DataColumn("yman", typeof(short)));
	tpccview.Columns.Add( new DataColumn("nman", typeof(int)));
	Tables.Add(tpccview);
	tpccview.PrimaryKey =  new DataColumn[]{tpccview.Columns["idpcc"]};


	//////////////////// PCCDEBITMOTIVE /////////////////////////////////
	var tpccdebitmotive= new DataTable("pccdebitmotive");
	C= new DataColumn("idpccdebitmotive", typeof(string));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	tpccdebitmotive.Columns.Add( new DataColumn("description", typeof(string)));
	tpccdebitmotive.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitmotive.Columns.Add(C);
	tpccdebitmotive.Columns.Add( new DataColumn("flagstatus", typeof(int)));
	Tables.Add(tpccdebitmotive);
	tpccdebitmotive.PrimaryKey =  new DataColumn[]{tpccdebitmotive.Columns["idpccdebitmotive"]};


	//////////////////// PCCDEBITSTATUS /////////////////////////////////
	var tpccdebitstatus= new DataTable("pccdebitstatus");
	C= new DataColumn("idpccdebitstatus", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	tpccdebitstatus.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatus.Columns.Add(C);
	tpccdebitstatus.Columns.Add( new DataColumn("listingorder", typeof(int)));
	tpccdebitstatus.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tpccdebitstatus);
	tpccdebitstatus.PrimaryKey =  new DataColumn[]{tpccdebitstatus.Columns["idpccdebitstatus"]};


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
	var cChild = new []{casualcontract.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_siope_casualcontract",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{pccview.Columns["ycon"], pccview.Columns["ncon"]};
	Relations.Add(new DataRelation("FK_casualcontract_pccview",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{uniqueregister.Columns["ycon"], uniqueregister.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontract_uniqueregister",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{casualcontractsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_casualcontractsorting",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{casualcontractsorting.Columns["ycon"], casualcontractsorting.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractcasualcontractsorting",cPar,cChild,false));

	cPar = new []{casualdeduction.Columns["iddeduction"]};
	cChild = new []{casualcontractdeduction.Columns["iddeduction"]};
	Relations.Add(new DataRelation("casualdeductioncasualcontractdeduction",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{casualcontractdeduction.Columns["ycon"], casualcontractdeduction.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractcasualcontractdeduction",cPar,cChild,false));

	cPar = new []{emenscontractkind.Columns["idemenscontractkind"]};
	cChild = new []{casualcontractyear.Columns["idemenscontractkind"]};
	Relations.Add(new DataRelation("emenscontractkindcasualcontractyear",cPar,cChild,false));

	cPar = new []{inpsactivity.Columns["activitycode"]};
	cChild = new []{casualcontractyear.Columns["activitycode"]};
	Relations.Add(new DataRelation("inpsactivitycasualcontractyear",cPar,cChild,false));

	cPar = new []{otherinsurance.Columns["idotherinsurance"]};
	cChild = new []{casualcontractyear.Columns["idotherinsurance"]};
	Relations.Add(new DataRelation("otherinsurancecasualcontractyear",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{casualcontractyear.Columns["ycon"], casualcontractyear.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractcasualcontractyear",cPar,cChild,false));

	cPar = new []{casualrefund.Columns["idlinkedrefund"]};
	cChild = new []{casualcontractrefund.Columns["idlinkedrefund"]};
	Relations.Add(new DataRelation("casualrefundcasualcontractrefund",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{casualcontractrefund.Columns["ycon"], casualcontractrefund.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractcasualcontractrefund",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{casualcontracttaxbracket.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_casualcontracttaxbracket",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{casualcontracttaxbracket.Columns["ycon"], casualcontracttaxbracket.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractcasualcontracttaxbracket",cPar,cChild,false));

	cPar = new []{casualcontracttax.Columns["ycon"], casualcontracttax.Columns["ncon"], casualcontracttax.Columns["taxcode"]};
	cChild = new []{casualcontracttaxbracket.Columns["ycon"], casualcontracttaxbracket.Columns["ncon"], casualcontracttaxbracket.Columns["taxcode"]};
	Relations.Add(new DataRelation("casualcontracttaxcasualcontracttaxbracket",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{casualcontracttax.Columns["ycon"], casualcontracttax.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractcasualcontracttax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{casualcontracttax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxcasualcontracttax",cPar,cChild,false));

	cPar = new []{pccdebitmotive.Columns["idpccdebitmotive"]};
	cChild = new []{casualcontract.Columns["idpccdebitmotive"]};
	Relations.Add(new DataRelation("FK_pccdebitmotive_casualcontract",cPar,cChild,false));

	cPar = new []{pccdebitstatus.Columns["idpccdebitstatus"]};
	cChild = new []{casualcontract.Columns["idpccdebitstatus"]};
	Relations.Add(new DataRelation("FK_pccdebitstatus_casualcontract",cPar,cChild,false));

	cPar = new []{ipa.Columns["ipa_fe"]};
	cChild = new []{casualcontract.Columns["ipa_fe"]};
	Relations.Add(new DataRelation("FK_ipa_casualcontract",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_casualcontract",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_casualcontract",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_casualcontract",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{casualcontract.Columns["idser"]};
	Relations.Add(new DataRelation("servicecasualcontract",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{casualcontract.Columns["idreg"]};
	Relations.Add(new DataRelation("registrycasualcontract",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{casualcontract.Columns["idupb"]};
	Relations.Add(new DataRelation("upbcasualcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_cost.Columns["idaccmotive"]};
	cChild = new []{casualcontract.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveapplied_casualcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{casualcontract.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_casualcontract",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{casualcontract.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_casualcontract",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_casualcontract",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_casualcontract",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_casualcontract",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_casualcontract",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{casualcontract.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_casualcontract",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{casualcontract.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_casualcontract",cPar,cChild,false));

	cPar = new []{dalia_recruitmentmotive.Columns["iddaliarecruitmentmotive"]};
	cChild = new []{casualcontract.Columns["iddaliarecruitmentmotive"]};
	Relations.Add(new DataRelation("dalia_recruitmentmotive_casualcontract",cPar,cChild,false));

	#endregion

}
}
}
