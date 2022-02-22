
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
namespace wageaddition_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageaddition 		=> Tables["wageaddition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageadditionyear 		=> Tables["wageadditionyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable positionworkcontract 		=> Tables["positionworkcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable workingtime 		=> Tables["workingtime"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable contractlength 		=> Tables["contractlength"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageadditiontax 		=> Tables["wageadditiontax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageadditionsorting 		=> Tables["wageadditionsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_cost 		=> Tables["accmotiveapplied_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_debit 		=> Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_crg 		=> Tables["accmotiveapplied_crg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_distrained 		=> Tables["registry_distrained"];

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

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_position 		=> Tables["dalia_position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview1 		=> Tables["sortingview1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siope 		=> Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_recruitmentmotive 		=> Tables["dalia_recruitmentmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_funzionale 		=> Tables["dalia_funzionale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_dipartimento 		=> Tables["dalia_dipartimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable serviceattachmentkind 		=> Tables["serviceattachmentkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable wageadditionattachment 		=> Tables["wageadditionattachment"];

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
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	twageaddition.Columns.Add( new DataColumn("txt", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("ndays", typeof(int));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	twageaddition.Columns.Add(C);
	twageaddition.Columns.Add( new DataColumn("idupb", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("idsor1", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor2", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor3", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("completed", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	twageaddition.Columns.Add( new DataColumn("idregistrylegalstatus", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("authneeded", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("authdoc", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("authdocdate", typeof(DateTime)));
	twageaddition.Columns.Add( new DataColumn("noauthreason", typeof(string)));
	twageaddition.Columns.Add( new DataColumn("idreg_distrained", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor01", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor02", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor03", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor04", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor05", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("iddaliarecruitmentmotive", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("iddalia_funzionale", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("iddalia_dipartimento", typeof(int)));
	twageaddition.Columns.Add( new DataColumn("flagexcludefromcertificate", typeof(string)));
	Tables.Add(twageaddition);
	twageaddition.PrimaryKey =  new DataColumn[]{twageaddition.Columns["ycon"], twageaddition.Columns["ncon"]};


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
	tservice.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice.Columns.Add( new DataColumn("rec770kind", typeof(string)));
	tservice.Columns.Add( new DataColumn("codeser", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdistraint", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdalia", typeof(string)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


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
	ttax.Columns.Add( new DataColumn("taxref", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// WAGEADDITIONYEAR /////////////////////////////////
	var twageadditionyear= new DataTable("wageadditionyear");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	twageadditionyear.Columns.Add( new DataColumn("idposition", typeof(string)));
	twageadditionyear.Columns.Add( new DataColumn("idcontractlength", typeof(string)));
	twageadditionyear.Columns.Add( new DataColumn("idworkingtime", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionyear.Columns.Add(C);
	Tables.Add(twageadditionyear);
	twageadditionyear.PrimaryKey =  new DataColumn[]{twageadditionyear.Columns["ayear"], twageadditionyear.Columns["ycon"], twageadditionyear.Columns["ncon"]};


	//////////////////// POSITIONWORKCONTRACT /////////////////////////////////
	var tpositionworkcontract= new DataTable("positionworkcontract");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	C= new DataColumn("idposition", typeof(string));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	tpositionworkcontract.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	C= new DataColumn("flagforcedlength", typeof(string));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	C= new DataColumn("flagforcedtime", typeof(string));
	C.AllowDBNull=false;
	tpositionworkcontract.Columns.Add(C);
	Tables.Add(tpositionworkcontract);
	tpositionworkcontract.PrimaryKey =  new DataColumn[]{tpositionworkcontract.Columns["ayear"], tpositionworkcontract.Columns["idposition"]};


	//////////////////// WORKINGTIME /////////////////////////////////
	var tworkingtime= new DataTable("workingtime");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tworkingtime.Columns.Add(C);
	C= new DataColumn("idworkingtime", typeof(string));
	C.AllowDBNull=false;
	tworkingtime.Columns.Add(C);
	tworkingtime.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tworkingtime.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tworkingtime.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tworkingtime.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tworkingtime.Columns.Add(C);
	Tables.Add(tworkingtime);
	tworkingtime.PrimaryKey =  new DataColumn[]{tworkingtime.Columns["ayear"], tworkingtime.Columns["idworkingtime"]};


	//////////////////// CONTRACTLENGTH /////////////////////////////////
	var tcontractlength= new DataTable("contractlength");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tcontractlength.Columns.Add(C);
	C= new DataColumn("idcontractlength", typeof(string));
	C.AllowDBNull=false;
	tcontractlength.Columns.Add(C);
	tcontractlength.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcontractlength.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcontractlength.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcontractlength.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcontractlength.Columns.Add(C);
	Tables.Add(tcontractlength);
	tcontractlength.PrimaryKey =  new DataColumn[]{tcontractlength.Columns["ayear"], tcontractlength.Columns["idcontractlength"]};


	//////////////////// WAGEADDITIONTAX /////////////////////////////////
	var twageadditiontax= new DataTable("wageadditiontax");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	twageadditiontax.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	twageadditiontax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	twageadditiontax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditiontax.Columns.Add(C);
	twageadditiontax.Columns.Add( new DataColumn("!tiporitenuta", typeof(string)));
	twageadditiontax.Columns.Add( new DataColumn("!taxref", typeof(string)));
	Tables.Add(twageadditiontax);
	twageadditiontax.PrimaryKey =  new DataColumn[]{twageadditiontax.Columns["ycon"], twageadditiontax.Columns["ncon"], twageadditiontax.Columns["taxcode"]};


	//////////////////// WAGEADDITIONSORTING /////////////////////////////////
	var twageadditionsorting= new DataTable("wageadditionsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionsorting.Columns.Add(C);
	twageadditionsorting.Columns.Add( new DataColumn("quota", typeof(double)));
	twageadditionsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	twageadditionsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	Tables.Add(twageadditionsorting);
	twageadditionsorting.PrimaryKey =  new DataColumn[]{twageadditionsorting.Columns["idsor"], twageadditionsorting.Columns["ncon"], twageadditionsorting.Columns["ycon"]};


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
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


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
	tsorting1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting3.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


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


	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("residencekind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistrymainview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("city", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("qualification", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("human", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("location", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("nation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
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


	//////////////////// REGISTRY_DISTRAINED /////////////////////////////////
	var tregistry_distrained= new DataTable("registry_distrained");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	tregistry_distrained.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry_distrained.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	tregistry_distrained.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry_distrained.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry_distrained.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	tregistry_distrained.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry_distrained.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	tregistry_distrained.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry_distrained.Columns.Add(C);
	tregistry_distrained.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry_distrained.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry_distrained.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry_distrained.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry_distrained);
	tregistry_distrained.PrimaryKey =  new DataColumn[]{tregistry_distrained.Columns["idreg"]};


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
	tsorting01.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting02.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting03.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting04.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting05.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsortingview1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsortingview1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsortingview1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsortingview1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsortingview1.Columns.Add( new DataColumn("idsor05", typeof(int)));
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
	tsorting_siope.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor05", typeof(int)));
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


	//////////////////// DALIA_FUNZIONALE /////////////////////////////////
	var tdalia_funzionale= new DataTable("dalia_funzionale");
	C= new DataColumn("iddalia_funzionale", typeof(int));
	C.AllowDBNull=false;
	tdalia_funzionale.Columns.Add(C);
	C= new DataColumn("codefunz", typeof(string));
	C.AllowDBNull=false;
	tdalia_funzionale.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tdalia_funzionale.Columns.Add(C);
	tdalia_funzionale.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tdalia_funzionale.Columns.Add( new DataColumn("cu", typeof(string)));
	tdalia_funzionale.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdalia_funzionale.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tdalia_funzionale);
	tdalia_funzionale.PrimaryKey =  new DataColumn[]{tdalia_funzionale.Columns["iddalia_funzionale"]};


	//////////////////// DALIA_DIPARTIMENTO /////////////////////////////////
	var tdalia_dipartimento= new DataTable("dalia_dipartimento");
	C= new DataColumn("iddalia_dipartimento", typeof(int));
	C.AllowDBNull=false;
	tdalia_dipartimento.Columns.Add(C);
	C= new DataColumn("codedip", typeof(string));
	C.AllowDBNull=false;
	tdalia_dipartimento.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tdalia_dipartimento.Columns.Add(C);
	tdalia_dipartimento.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tdalia_dipartimento.Columns.Add( new DataColumn("cu", typeof(string)));
	tdalia_dipartimento.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdalia_dipartimento.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tdalia_dipartimento);
	tdalia_dipartimento.PrimaryKey =  new DataColumn[]{tdalia_dipartimento.Columns["iddalia_dipartimento"]};


	//////////////////// SERVICEATTACHMENTKIND /////////////////////////////////
	var tserviceattachmentkind= new DataTable("serviceattachmentkind");
	C= new DataColumn("idattachmentkind", typeof(int));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	tserviceattachmentkind.Columns.Add( new DataColumn("title", typeof(string)));
	tserviceattachmentkind.Columns.Add( new DataColumn("active", typeof(string)));
	tserviceattachmentkind.Columns.Add( new DataColumn("idser", typeof(int)));
	tserviceattachmentkind.Columns.Add( new DataColumn("flag", typeof(int)));
	tserviceattachmentkind.Columns.Add( new DataColumn("flagforced", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tserviceattachmentkind.Columns.Add(C);
	Tables.Add(tserviceattachmentkind);
	tserviceattachmentkind.PrimaryKey =  new DataColumn[]{tserviceattachmentkind.Columns["idattachmentkind"]};


	//////////////////// WAGEADDITIONATTACHMENT /////////////////////////////////
	var twageadditionattachment= new DataTable("wageadditionattachment");
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	twageadditionattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	twageadditionattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	twageadditionattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	twageadditionattachment.Columns.Add(C);
	twageadditionattachment.Columns.Add( new DataColumn("!serviceattachmentkind", typeof(string)));
	Tables.Add(twageadditionattachment);
	twageadditionattachment.PrimaryKey =  new DataColumn[]{twageadditionattachment.Columns["ycon"], twageadditionattachment.Columns["ncon"], twageadditionattachment.Columns["idattachment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{wageadditionsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingsubordinatecontractsorting",cPar,cChild,false));

	cPar = new []{wageaddition.Columns["ycon"], wageaddition.Columns["ncon"]};
	cChild = new []{wageadditionsorting.Columns["ycon"], wageadditionsorting.Columns["ncon"]};
	Relations.Add(new DataRelation("wageadditionsubordinatecontractsorting",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{wageadditiontax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxwageadditiontax",cPar,cChild,false));

	cPar = new []{wageaddition.Columns["ycon"], wageaddition.Columns["ncon"]};
	cChild = new []{wageadditiontax.Columns["ycon"], wageadditiontax.Columns["ncon"]};
	Relations.Add(new DataRelation("wageadditionwageadditiontax",cPar,cChild,false));

	cPar = new []{wageaddition.Columns["ycon"], wageaddition.Columns["ncon"]};
	cChild = new []{wageadditionyear.Columns["ycon"], wageadditionyear.Columns["ncon"]};
	Relations.Add(new DataRelation("wageadditionwageadditionyear",cPar,cChild,false));

	cPar = new []{workingtime.Columns["ayear"], workingtime.Columns["idworkingtime"]};
	cChild = new []{wageadditionyear.Columns["ayear"], wageadditionyear.Columns["idworkingtime"]};
	Relations.Add(new DataRelation("workingtimewageadditionyear",cPar,cChild,false));

	cPar = new []{contractlength.Columns["ayear"], contractlength.Columns["idcontractlength"]};
	cChild = new []{wageadditionyear.Columns["ayear"], wageadditionyear.Columns["idcontractlength"]};
	Relations.Add(new DataRelation("contractlengthwageadditionyear",cPar,cChild,false));

	cPar = new []{positionworkcontract.Columns["ayear"], positionworkcontract.Columns["idposition"]};
	cChild = new []{wageadditionyear.Columns["ayear"], wageadditionyear.Columns["idposition"]};
	Relations.Add(new DataRelation("positionworkcontractwageadditionyear",cPar,cChild,false));

	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_siope_wageaddition",cPar,cChild,false));

	cPar = new []{registry_distrained.Columns["idreg"]};
	cChild = new []{wageaddition.Columns["idreg_distrained"]};
	Relations.Add(new DataRelation("registry_distrained_wageaddition",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{wageaddition.Columns["idreg"]};
	Relations.Add(new DataRelation("registrywageaddition",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{wageaddition.Columns["idser"]};
	Relations.Add(new DataRelation("servicewageaddition",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{wageaddition.Columns["idupb"]};
	Relations.Add(new DataRelation("upbwageaddition",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1wageaddition",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2wageaddition",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3wageaddition",cPar,cChild,false));

	cPar = new []{accmotiveapplied_cost.Columns["idaccmotive"]};
	cChild = new []{wageaddition.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveappliedwageaddition",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{wageaddition.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debit_wageaddition",cPar,cChild,false));

	cPar = new []{accmotiveapplied_crg.Columns["idaccmotive"]};
	cChild = new []{wageaddition.Columns["idaccmotivedebit_crg"]};
	Relations.Add(new DataRelation("accmotiveapplied_crg_wageaddition",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_wageaddition",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_wageaddition",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_wageaddition",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_wageaddition",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{wageaddition.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_wageaddition",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{wageaddition.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_wageaddition",cPar,cChild,false));

	cPar = new []{dalia_recruitmentmotive.Columns["iddaliarecruitmentmotive"]};
	cChild = new []{wageaddition.Columns["iddaliarecruitmentmotive"]};
	Relations.Add(new DataRelation("dalia_recruitmentmotive_wageaddition",cPar,cChild,false));

	cPar = new []{dalia_funzionale.Columns["iddalia_funzionale"]};
	cChild = new []{wageaddition.Columns["iddalia_funzionale"]};
	Relations.Add(new DataRelation("dalia_funzionale_wageaddition",cPar,cChild,false));

	cPar = new []{dalia_dipartimento.Columns["iddalia_dipartimento"]};
	cChild = new []{wageaddition.Columns["iddalia_dipartimento"]};
	Relations.Add(new DataRelation("dalia_dipartimento_wageaddition",cPar,cChild,false));

	cPar = new []{serviceattachmentkind.Columns["idattachmentkind"]};
	cChild = new []{wageadditionattachment.Columns["idattachmentkind"]};
	Relations.Add(new DataRelation("serviceattachmentkind_wageadditionattachment",cPar,cChild,false));

	cPar = new []{wageaddition.Columns["ycon"], wageaddition.Columns["ncon"]};
	cChild = new []{wageadditionattachment.Columns["ycon"], wageadditionattachment.Columns["ncon"]};
	Relations.Add(new DataRelation("wageaddition_wageadditionattachment",cPar,cChild,false));

	#endregion

}
}
}
