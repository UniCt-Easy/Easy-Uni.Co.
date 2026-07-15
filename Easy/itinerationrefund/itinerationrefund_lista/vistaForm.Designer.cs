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
namespace itinerationrefund_lista {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable currency 		=> Tables["currency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefund 		=> Tables["itinerationrefund"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundkind 		=> Tables["itinerationrefundkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable foreigncountry 		=> Tables["foreigncountry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundattachment 		=> Tables["itinerationrefundattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundattachmentkind 		=> Tables["itinerationrefundattachmentkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itineration 		=> Tables["itineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable position 		=> Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrylegalstatus 		=> Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationstatus 		=> Tables["itinerationstatus"];

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
	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new DataTable("currency");
	C= new DataColumn("idcurrency", typeof(int));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("codecurrency", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	tcurrency.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tcurrency);
	tcurrency.PrimaryKey =  new DataColumn[]{tcurrency.Columns["idcurrency"]};


	//////////////////// ITINERATIONREFUND /////////////////////////////////
	var titinerationrefund= new DataTable("itinerationrefund");
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	titinerationrefund.Columns.Add( new DataColumn("description", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	titinerationrefund.Columns.Add( new DataColumn("extraallowance", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titinerationrefund.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	titinerationrefund.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("amount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("iditinerationrefundkind", typeof(int)));
	titinerationrefund.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefund.Columns.Add(C);
	titinerationrefund.Columns.Add( new DataColumn("flagitalian", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("flagadvancebalance", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("doc", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	titinerationrefund.Columns.Add( new DataColumn("requiredamount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("docamount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("webwarn", typeof(string)));
	titinerationrefund.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titinerationrefund.Columns.Add( new DataColumn("noaccount", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("amount_c", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("docamount_c", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("requiredamount_c", typeof(decimal)));
	titinerationrefund.Columns.Add( new DataColumn("flagtaxableexpense", typeof(int)));
	Tables.Add(titinerationrefund);
	titinerationrefund.PrimaryKey =  new DataColumn[]{titinerationrefund.Columns["nrefund"], titinerationrefund.Columns["iditineration"]};


	//////////////////// ITINERATIONREFUNDKIND /////////////////////////////////
	var titinerationrefundkind= new DataTable("itinerationrefundkind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	titinerationrefundkind.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("iditinerationrefundkindgroup", typeof(int)));
	C= new DataColumn("codeitinerationrefundkind", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("iditinerationrefundkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	titinerationrefundkind.Columns.Add( new DataColumn("active", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagadvance", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagtraceability", typeof(int)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagvisible", typeof(int)));
	Tables.Add(titinerationrefundkind);
	titinerationrefundkind.PrimaryKey =  new DataColumn[]{titinerationrefundkind.Columns["iditinerationrefundkind"]};


	//////////////////// FOREIGNCOUNTRY /////////////////////////////////
	var tforeigncountry= new DataTable("foreigncountry");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	tforeigncountry.Columns.Add( new DataColumn("flag_ue", typeof(string)));
	C= new DataColumn("codeforeigncountry", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("idforeigncountry", typeof(int));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	tforeigncountry.Columns.Add( new DataColumn("idmacroarea", typeof(int)));
	Tables.Add(tforeigncountry);
	tforeigncountry.PrimaryKey =  new DataColumn[]{tforeigncountry.Columns["idforeigncountry"]};


	//////////////////// ITINERATIONREFUNDATTACHMENT /////////////////////////////////
	var titinerationrefundattachment= new DataTable("itinerationrefundattachment");
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("nrefund", typeof(short));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	titinerationrefundattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	titinerationrefundattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	titinerationrefundattachment.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundattachment.Columns.Add(C);
	titinerationrefundattachment.Columns.Add( new DataColumn("active", typeof(string)));
	titinerationrefundattachment.Columns.Add( new DataColumn("iditinerationrefundattachmentkind", typeof(int)));
	titinerationrefundattachment.Columns.Add( new DataColumn("idfilestorage", typeof(string)));
	titinerationrefundattachment.Columns.Add( new DataColumn("!refundattachmentkind", typeof(string)));
	Tables.Add(titinerationrefundattachment);
	titinerationrefundattachment.PrimaryKey =  new DataColumn[]{titinerationrefundattachment.Columns["idattachment"], titinerationrefundattachment.Columns["iditineration"], titinerationrefundattachment.Columns["nrefund"]};


	//////////////////// ITINERATIONREFUNDATTACHMENTKIND /////////////////////////////////
	var titinerationrefundattachmentkind= new DataTable("itinerationrefundattachmentkind");
	C= new DataColumn("iditinerationrefundattachmentkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundattachmentkind.Columns.Add(C);
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("active", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("cu", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("lu", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("title", typeof(string)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("flag", typeof(int)));
	titinerationrefundattachmentkind.Columns.Add( new DataColumn("code", typeof(string)));
	Tables.Add(titinerationrefundattachmentkind);
	titinerationrefundattachmentkind.PrimaryKey =  new DataColumn[]{titinerationrefundattachmentkind.Columns["iditinerationrefundattachmentkind"]};


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
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
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
	titineration.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	titineration.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(string)));
	titineration.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(DateTime)));
	titineration.Columns.Add( new DataColumn("idregistrylegalstatus", typeof(int)));
	titineration.Columns.Add( new DataColumn("applierannotations", typeof(string)));
	titineration.Columns.Add( new DataColumn("flagweb", typeof(string)));
	titineration.Columns.Add( new DataColumn("idauthmodel", typeof(int)));
	titineration.Columns.Add( new DataColumn("iditinerationstatus", typeof(short)));
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


	//////////////////// POSITION /////////////////////////////////
	var tposition= new DataTable("position");
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codeposition", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("maxincomeclass", typeof(short)));
	tposition.Columns.Add( new DataColumn("foreignclass", typeof(string)));
	tposition.Columns.Add( new DataColumn("assegnoaggiuntivo", typeof(string)));
	tposition.Columns.Add( new DataColumn("costolordoannuo", typeof(decimal)));
	tposition.Columns.Add( new DataColumn("costolordoannuooneri", typeof(decimal)));
	tposition.Columns.Add( new DataColumn("elementoperequativo", typeof(string)));
	tposition.Columns.Add( new DataColumn("indennitadiateneo", typeof(string)));
	tposition.Columns.Add( new DataColumn("indennitadiposizione", typeof(string)));
	tposition.Columns.Add( new DataColumn("indvacancacontrattuale", typeof(string)));
	tposition.Columns.Add( new DataColumn("oremaxcompitididatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxcompitididatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxdidatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxdidatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxgg", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxtempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxtempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremincompitididatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremincompitididatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremindidatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremindidatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremintempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremintempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("orestraordinariemax", typeof(int)));
	tposition.Columns.Add( new DataColumn("parttime", typeof(string)));
	tposition.Columns.Add( new DataColumn("puntiorganico", typeof(decimal)));
	tposition.Columns.Add( new DataColumn("livello", typeof(string)));
	tposition.Columns.Add( new DataColumn("siglaesportazione", typeof(string)));
	tposition.Columns.Add( new DataColumn("siglaimportazione", typeof(string)));
	tposition.Columns.Add( new DataColumn("printingorder", typeof(int)));
	tposition.Columns.Add( new DataColumn("tempdef", typeof(string)));
	tposition.Columns.Add( new DataColumn("tipopersonale", typeof(string)));
	tposition.Columns.Add( new DataColumn("title", typeof(string)));
	tposition.Columns.Add( new DataColumn("totaletredicesima", typeof(string)));
	tposition.Columns.Add( new DataColumn("tredicesimaindennitaintegrativaspeciale", typeof(string)));
	tposition.Columns.Add( new DataColumn("tipoente", typeof(string)));
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new DataTable("registrylegalstatus");
	tregistrylegalstatus.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idposition", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclass", typeof(short)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclassvalidity", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrylegalstatus.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idregistrylegalstatus", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_compartment", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_role", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_class", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("datarivalutazione", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idinquadramento", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("parttime", typeof(decimal)));
	tregistrylegalstatus.Columns.Add( new DataColumn("percentualesufondiateneo", typeof(decimal)));
	tregistrylegalstatus.Columns.Add( new DataColumn("livello", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("tempdef", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("tempindet", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("flagdefault", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idclassconsorsuale", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idtipologiaruolo", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("anni", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("annokind", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("cedolini", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("giorni", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idtiponomina", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("istituzione", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("mesi", typeof(int)));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.PrimaryKey =  new DataColumn[]{tregistrylegalstatus.Columns["idreg"], tregistrylegalstatus.Columns["idregistrylegalstatus"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idexternal", typeof(int)));
	tregistry.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistry.Columns.Add( new DataColumn("email_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("pec_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ipa_perlapa", typeof(string)));
	tregistry.Columns.Add( new DataColumn("extension", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idateco", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idnace", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnaturagiur", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idnumerodip", typeof(int)));
	tregistry.Columns.Add( new DataColumn("pic", typeof(string)));
	tregistry.Columns.Add( new DataColumn("title_en", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idfonteindicebibliometrico", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idreg_istituti", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idsasd", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idstruttura", typeof(int)));
	tregistry.Columns.Add( new DataColumn("indicebibliometrico", typeof(int)));
	tregistry.Columns.Add( new DataColumn("ricevimento", typeof(string)));
	tregistry.Columns.Add( new DataColumn("soggiorno", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idanpr", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("active", typeof(string)));
	tservice.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
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
	tservice.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
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
	tservice.Columns.Add( new DataColumn("voce8000", typeof(string)));
	tservice.Columns.Add( new DataColumn("webdefault", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdistraint", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagcsausability", typeof(int)));
	tservice.Columns.Add( new DataColumn("voce8000refund_e", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000refund_i", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagnoexemptionquote", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdalia", typeof(string)));
	tservice.Columns.Add( new DataColumn("servicecode770", typeof(string)));
	tservice.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tservice.Columns.Add( new DataColumn("flagnoncumula", typeof(string)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


	//////////////////// ITINERATIONSTATUS /////////////////////////////////
	var titinerationstatus= new DataTable("itinerationstatus");
	C= new DataColumn("iditinerationstatus", typeof(short));
	C.AllowDBNull=false;
	titinerationstatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationstatus.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationstatus.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationstatus.Columns.Add(C);
	titinerationstatus.Columns.Add( new DataColumn("listingorder", typeof(short)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationstatus.Columns.Add(C);
	Tables.Add(titinerationstatus);
	titinerationstatus.PrimaryKey =  new DataColumn[]{titinerationstatus.Columns["iditinerationstatus"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{foreigncountry.Columns["idforeigncountry"]};
	var cChild = new []{itinerationrefund.Columns["idforeigncountry"]};
	Relations.Add(new DataRelation("FK_foreigncountry_itinerationrefund",cPar,cChild,false));

	cPar = new []{itinerationrefundkind.Columns["iditinerationrefundkind"]};
	cChild = new []{itinerationrefund.Columns["iditinerationrefundkind"]};
	Relations.Add(new DataRelation("itinerationrefundkind_itinerationrefund",cPar,cChild,false));

	cPar = new []{currency.Columns["idcurrency"]};
	cChild = new []{itinerationrefund.Columns["idcurrency"]};
	Relations.Add(new DataRelation("currency_itinerationrefund",cPar,cChild,false));

	cPar = new []{itinerationrefund.Columns["iditineration"], itinerationrefund.Columns["nrefund"]};
	cChild = new []{itinerationrefundattachment.Columns["iditineration"], itinerationrefundattachment.Columns["nrefund"]};
	Relations.Add(new DataRelation("itinerationrefundattachment_itinerationrefund",cPar,cChild,false));

	cPar = new []{itinerationrefundattachmentkind.Columns["iditinerationrefundattachmentkind"]};
	cChild = new []{itinerationrefundattachment.Columns["iditinerationrefundattachmentkind"]};
	Relations.Add(new DataRelation("itinerationrefundattachmentkind_itinerationrefundattachment",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{itinerationrefund.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_itinerationrefund",cPar,cChild,false));

	cPar = new []{registrylegalstatus.Columns["idreg"], registrylegalstatus.Columns["idregistrylegalstatus"]};
	cChild = new []{itineration.Columns["idreg"], itineration.Columns["idregistrylegalstatus"]};
	Relations.Add(new DataRelation("registrylegalstatus_itineration",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{itineration.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_itineration",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{itineration.Columns["idser"]};
	Relations.Add(new DataRelation("service_itineration",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("position_registrylegalstatus",cPar,cChild,false));

	cPar = new []{itinerationstatus.Columns["iditinerationstatus"]};
	cChild = new []{itineration.Columns["iditinerationstatus"]};
	Relations.Add(new DataRelation("itinerationstatus_itineration",cPar,cChild,false));

	#endregion

}
}
}
