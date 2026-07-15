/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace no_table_itinerationamountdetail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationamountdetail 		=> Tables["itinerationamountdetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefund_advance 		=> Tables["itinerationrefund_advance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itineration 		=> Tables["itineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefund_balance 		=> Tables["itinerationrefund_balance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationtax 		=> Tables["itinerationtax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationlap 		=> Tables["itinerationlap"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundkind_balance 		=> Tables["itinerationrefundkind_balance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundkind_advance 		=> Tables["itinerationrefundkind_advance"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

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
	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new DataTable("no_table");
	C= new DataColumn("id_no_table", typeof(int));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	Tables.Add(tno_table);

	//////////////////// ITINERATIONAMOUNTDETAIL /////////////////////////////////
	var titinerationamountdetail= new DataTable("itinerationamountdetail");
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("totspesepreventivateanticipo", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("totspesesostenute", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("totspesedaconsiderare", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("indennsupplementare", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("indennkm", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("indennlordatrasfertait", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("indennlordatrasfertaestero", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("importolordo", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("contributiassicurativi", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("contributiprevidenziali", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("importoanticipo", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("quotaesente", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	C= new DataColumn("imponibile", typeof(decimal));
	C.AllowDBNull=false;
	titinerationamountdetail.Columns.Add(C);
	titinerationamountdetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	titinerationamountdetail.Columns.Add( new DataColumn("cu", typeof(string)));
	titinerationamountdetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	titinerationamountdetail.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(titinerationamountdetail);
	titinerationamountdetail.PrimaryKey =  new DataColumn[]{titinerationamountdetail.Columns["iditineration"], titinerationamountdetail.Columns["ndetail"]};


	//////////////////// ITINERATIONREFUND_ADVANCE /////////////////////////////////
	var titinerationrefund_advance= new DataTable("itinerationrefund_advance");
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefund_advance.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefund_advance.Columns.Add(C);
	titinerationrefund_advance.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund_advance.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund_advance.Columns.Add(C);
	titinerationrefund_advance.Columns.Add( new DataColumn("description", typeof(string)));
	titinerationrefund_advance.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	titinerationrefund_advance.Columns.Add( new DataColumn("extraallowance", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	titinerationrefund_advance.Columns.Add( new DataColumn("flagitalian", typeof(string)));
	titinerationrefund_advance.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	titinerationrefund_advance.Columns.Add( new DataColumn("iditinerationrefundkind", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund_advance.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund_advance.Columns.Add(C);
	titinerationrefund_advance.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titinerationrefund_advance.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	titinerationrefund_advance.Columns.Add( new DataColumn("doc", typeof(string)));
	titinerationrefund_advance.Columns.Add( new DataColumn("docamount", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	titinerationrefund_advance.Columns.Add( new DataColumn("flagadvancebalance", typeof(string)));
	titinerationrefund_advance.Columns.Add( new DataColumn("requiredamount", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("webwarn", typeof(string)));
	titinerationrefund_advance.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titinerationrefund_advance.Columns.Add( new DataColumn("noaccount", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("amount_c", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("docamount_c", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("requiredamount_c", typeof(decimal)));
	titinerationrefund_advance.Columns.Add( new DataColumn("flagtaxableexpense", typeof(int)));
	Tables.Add(titinerationrefund_advance);
	titinerationrefund_advance.PrimaryKey =  new DataColumn[]{titinerationrefund_advance.Columns["iditineration"], titinerationrefund_advance.Columns["nrefund"]};


	//////////////////// ITINERATION /////////////////////////////////
	var titineration= new DataTable("itineration");
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("admincarkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("admincarkmcost", typeof(decimal)));
	C= new DataColumn("authorizationdate", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("completed", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("footkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("footkmcost", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("grossfactor", typeof(double)));
	titineration.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	titineration.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	titineration.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	titineration.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("idregistrylegalstatus", typeof(int)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("idsor1", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor2", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor3", typeof(int)));
	titineration.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	C= new DataColumn("nitineration", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("owncarkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("owncarkmcost", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("totadvance", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("total", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("totalgross", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yitineration", typeof(short));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("applierannotations", typeof(string)));
	titineration.Columns.Add( new DataColumn("flagweb", typeof(string)));
	titineration.Columns.Add( new DataColumn("idauthmodel", typeof(int)));
	titineration.Columns.Add( new DataColumn("iditinerationstatus", typeof(int)));
	titineration.Columns.Add( new DataColumn("idman", typeof(int)));
	titineration.Columns.Add( new DataColumn("webwarn", typeof(string)));
	titineration.Columns.Add( new DataColumn("authdoc", typeof(string)));
	titineration.Columns.Add( new DataColumn("authdocdate", typeof(DateTime)));
	titineration.Columns.Add( new DataColumn("authneeded", typeof(string)));
	titineration.Columns.Add( new DataColumn("cancelreason", typeof(string)));
	titineration.Columns.Add( new DataColumn("noauthreason", typeof(string)));
	titineration.Columns.Add( new DataColumn("clause_accepted", typeof(string)));
	titineration.Columns.Add( new DataColumn("vehicle_info", typeof(string)));
	titineration.Columns.Add( new DataColumn("vehicle_motive", typeof(string)));
	titineration.Columns.Add( new DataColumn("location", typeof(string)));
	titineration.Columns.Add( new DataColumn("idsor01", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor02", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor03", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor04", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor05", typeof(int)));
	titineration.Columns.Add( new DataColumn("datecompleted", typeof(DateTime)));
	titineration.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	titineration.Columns.Add( new DataColumn("additionalannotations", typeof(string)));
	titineration.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	titineration.Columns.Add( new DataColumn("iditineration_ref", typeof(int)));
	titineration.Columns.Add( new DataColumn("advanceapplied", typeof(string)));
	titineration.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titineration.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("flagmove", typeof(int)));
	titineration.Columns.Add( new DataColumn("flagoutside", typeof(string)));
	titineration.Columns.Add( new DataColumn("flagownfunds", typeof(string)));
	titineration.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	titineration.Columns.Add( new DataColumn("nfood", typeof(int)));
	titineration.Columns.Add( new DataColumn("supposedamount", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("supposedfood", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("supposedliving", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("supposedtravel", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("iddaliarecruitmentmotive", typeof(int)));
	titineration.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titineration.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	titineration.Columns.Add( new DataColumn("iddalia_dipartimento", typeof(int)));
	titineration.Columns.Add( new DataColumn("iddalia_funzionale", typeof(int)));
	titineration.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	titineration.Columns.Add( new DataColumn("advancepercentagecourse", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("advancepercentagefood", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("advancepercentageliving", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("advancepercentagetravel", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("supposedcourse", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("flagexcludefromcertificate", typeof(string)));
	Tables.Add(titineration);
	titineration.PrimaryKey =  new DataColumn[]{titineration.Columns["iditineration"]};


	//////////////////// ITINERATIONREFUND_BALANCE /////////////////////////////////
	var titinerationrefund_balance= new DataTable("itinerationrefund_balance");
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefund_balance.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefund_balance.Columns.Add(C);
	titinerationrefund_balance.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund_balance.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund_balance.Columns.Add(C);
	titinerationrefund_balance.Columns.Add( new DataColumn("description", typeof(string)));
	titinerationrefund_balance.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	titinerationrefund_balance.Columns.Add( new DataColumn("extraallowance", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	titinerationrefund_balance.Columns.Add( new DataColumn("flagitalian", typeof(string)));
	titinerationrefund_balance.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	titinerationrefund_balance.Columns.Add( new DataColumn("iditinerationrefundkind", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund_balance.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund_balance.Columns.Add(C);
	titinerationrefund_balance.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titinerationrefund_balance.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	titinerationrefund_balance.Columns.Add( new DataColumn("doc", typeof(string)));
	titinerationrefund_balance.Columns.Add( new DataColumn("docamount", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	titinerationrefund_balance.Columns.Add( new DataColumn("flagadvancebalance", typeof(string)));
	titinerationrefund_balance.Columns.Add( new DataColumn("requiredamount", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("webwarn", typeof(string)));
	titinerationrefund_balance.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titinerationrefund_balance.Columns.Add( new DataColumn("noaccount", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("amount_c", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("docamount_c", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("requiredamount_c", typeof(decimal)));
	titinerationrefund_balance.Columns.Add( new DataColumn("flagtaxableexpense", typeof(int)));
	Tables.Add(titinerationrefund_balance);
	titinerationrefund_balance.PrimaryKey =  new DataColumn[]{titinerationrefund_balance.Columns["iditineration"], titinerationrefund_balance.Columns["nrefund"]};


	//////////////////// ITINERATIONTAX /////////////////////////////////
	var titinerationtax= new DataTable("itinerationtax");
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationtax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	titinerationtax.Columns.Add(C);
	titinerationtax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationtax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationtax.Columns.Add(C);
	titinerationtax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationtax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationtax.Columns.Add(C);
	titinerationtax.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	titinerationtax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	Tables.Add(titinerationtax);
	titinerationtax.PrimaryKey =  new DataColumn[]{titinerationtax.Columns["iditineration"], titinerationtax.Columns["taxcode"]};


	//////////////////// ITINERATIONLAP /////////////////////////////////
	var titinerationlap= new DataTable("itinerationlap");
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("lapnumber", typeof(short));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	titinerationlap.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titinerationlap.Columns.Add( new DataColumn("allowance", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("days", typeof(double));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("flagitalian", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("hours", typeof(double));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	titinerationlap.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titinerationlap.Columns.Add( new DataColumn("idreduction", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	titinerationlap.Columns.Add( new DataColumn("reductionpercentage", typeof(decimal)));
	titinerationlap.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titinerationlap.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	Tables.Add(titinerationlap);
	titinerationlap.PrimaryKey =  new DataColumn[]{titinerationlap.Columns["iditineration"], titinerationlap.Columns["lapnumber"]};


	//////////////////// ITINERATIONREFUNDKIND_BALANCE /////////////////////////////////
	var titinerationrefundkind_balance= new DataTable("itinerationrefundkind_balance");
	C= new DataColumn("iditinerationrefundkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	titinerationrefundkind_balance.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codeitinerationrefundkind", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	titinerationrefundkind_balance.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	titinerationrefundkind_balance.Columns.Add( new DataColumn("iditinerationrefundkindgroup", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_balance.Columns.Add(C);
	titinerationrefundkind_balance.Columns.Add( new DataColumn("flagadvance", typeof(string)));
	titinerationrefundkind_balance.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	titinerationrefundkind_balance.Columns.Add( new DataColumn("flagmedia", typeof(byte)));
	titinerationrefundkind_balance.Columns.Add( new DataColumn("flagvisible", typeof(int)));
	titinerationrefundkind_balance.Columns.Add( new DataColumn("flagtraceability", typeof(int)));
	Tables.Add(titinerationrefundkind_balance);
	titinerationrefundkind_balance.PrimaryKey =  new DataColumn[]{titinerationrefundkind_balance.Columns["iditinerationrefundkind"]};


	//////////////////// ITINERATIONREFUNDKIND_ADVANCE /////////////////////////////////
	var titinerationrefundkind_advance= new DataTable("itinerationrefundkind_advance");
	C= new DataColumn("iditinerationrefundkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	titinerationrefundkind_advance.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codeitinerationrefundkind", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	titinerationrefundkind_advance.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	titinerationrefundkind_advance.Columns.Add( new DataColumn("iditinerationrefundkindgroup", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind_advance.Columns.Add(C);
	titinerationrefundkind_advance.Columns.Add( new DataColumn("flagadvance", typeof(string)));
	titinerationrefundkind_advance.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	titinerationrefundkind_advance.Columns.Add( new DataColumn("flagmedia", typeof(byte)));
	titinerationrefundkind_advance.Columns.Add( new DataColumn("flagvisible", typeof(int)));
	titinerationrefundkind_advance.Columns.Add( new DataColumn("flagtraceability", typeof(int)));
	Tables.Add(titinerationrefundkind_advance);
	titinerationrefundkind_advance.PrimaryKey =  new DataColumn[]{titinerationrefundkind_advance.Columns["iditinerationrefundkind"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
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
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	C= new DataColumn("taxkind", typeof(short));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("insuranceagencycode", typeof(string)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcodecredit", typeof(string)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcodecreditf24ord", typeof(string)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcodef24ord", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


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
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("balancekind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("cudactivitycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("default_idfinvarstatus", typeof(short)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("finvar_warnmail", typeof(string)));
	tconfig.Columns.Add( new DataColumn("finvarofficial_default", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagivapaybyrow", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagva3", typeof(string)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("iban_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_revenue_gross_csa", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincome_gross_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idreg_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("invoice_flagregister", typeof(string)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("mainflagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("paymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("refundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("startivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("startivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("wageimportappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsor1_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor2_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor3_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idinpscenter", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpcashautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpcashautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idfin_store", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity_instit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("email", typeof(string)));
	tconfig.Columns.Add( new DataColumn("booking_on_invoice", typeof(string)));
	tconfig.Columns.Add( new DataColumn("lcard", typeof(string)));
	tconfig.Columns.Add( new DataColumn("itineration_directauth", typeof(string)));
	tconfig.Columns.Add( new DataColumn("email_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flaggroupby_expense", typeof(string)));
	C= new DataColumn("csa_flaggroupby_income", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("csa_flaglinktoexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsiopeincome_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_invoicetoemit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_invoicetoreceive", typeof(string)));
	tconfig.Columns.Add( new DataColumn("epannualthreeshold", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagbalance_csa", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagiva_immediate_or_deferred", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagenabletransmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idpccdebitstatus", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpaymentsplit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagsplitpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapaymentsplit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_split", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idfinivapaymentsplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("paymentagencysplit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("startivabalancesplit", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("agencynumber", typeof(string)));
	tconfig.Columns.Add( new DataColumn("femode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_economic_result", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_previous_economic_result", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_bankpaydoc", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_bankprodoc", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flagtransmissionlinking", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_forwarder", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idivakind_forwarder", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_grantdeferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_grantrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_assetrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_prorata_cost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_prorata_revenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeiva12exp", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeiva12inc", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivaexp", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivainc", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivasplitexp", typeof(int)));
	tconfig.Columns.Add( new DataColumn("csa_nominativo", typeof(string)));
	tconfig.Columns.Add( new DataColumn("csa_flag", typeof(int)));
	tconfig.Columns.Add( new DataColumn("csa_idchargehandling", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag", typeof(int)));
	tconfig.Columns.Add( new DataColumn("assignedrequirement", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("risconta_ammortamenti_futuri", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_estera", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idsor_siopeivavendita", typeof(int)));
	tconfig.Columns.Add( new DataColumn("matricolainpsf24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpcc", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{itineration.Columns["iditineration"]};
	var cChild = new []{itinerationrefund_advance.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_itinerationrefund",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{itinerationamountdetail.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_itinerationamountdetail",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{itinerationrefund_balance.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_itinerationrefund_balance",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{itinerationtax.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_itinerationtax",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{itinerationlap.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_itinerationlap",cPar,cChild,false));

	cPar = new []{itinerationrefundkind_advance.Columns["iditinerationrefundkind"]};
	cChild = new []{itinerationrefund_advance.Columns["iditinerationrefundkind"]};
	Relations.Add(new DataRelation("itinerationrefundkind_advance_itinerationrefund_advance",cPar,cChild,false));

	cPar = new []{itinerationrefundkind_balance.Columns["iditinerationrefundkind"]};
	cChild = new []{itinerationrefund_balance.Columns["iditinerationrefundkind"]};
	Relations.Add(new DataRelation("itinerationrefundkind_balance_itinerationrefund_balance",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{itinerationtax.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_itinerationtax",cPar,cChild,false));

	#endregion

}
}
}
