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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_registrationuser_new"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registrationuser_new: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingkind 		=> (MetaTable)Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable uniconfig 		=> (MetaTable)Tables["uniconfig"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable flowchart 		=> (MetaTable)Tables["flowchart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrationuserflowchart 		=> (MetaTable)Tables["registrationuserflowchart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable userkind 		=> (MetaTable)Tables["userkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingusabledefaultview_alias4 		=> (MetaTable)Tables["sortingusabledefaultview_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingusabledefaultview_alias3 		=> (MetaTable)Tables["sortingusabledefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingusabledefaultview_alias2 		=> (MetaTable)Tables["sortingusabledefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingusabledefaultview_alias1 		=> (MetaTable)Tables["sortingusabledefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingusabledefaultview 		=> (MetaTable)Tables["sortingusabledefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable usertype 		=> (MetaTable)Tables["usertype"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrationuser 		=> (MetaTable)Tables["registrationuser"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrationuser_new(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrationuser_new (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrationuser_new";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrationuser_new.xsd";

	#region create DataTables
	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new MetaTable("sortingkind");
	tsortingkind.defineColumn("active", typeof(string));
	tsortingkind.defineColumn("allowedS1", typeof(string));
	tsortingkind.defineColumn("allowedS2", typeof(string));
	tsortingkind.defineColumn("allowedS3", typeof(string));
	tsortingkind.defineColumn("allowedS4", typeof(string));
	tsortingkind.defineColumn("allowedS5", typeof(string));
	tsortingkind.defineColumn("codesorkind", typeof(string),false);
	tsortingkind.defineColumn("ct", typeof(DateTime),false);
	tsortingkind.defineColumn("cu", typeof(string),false);
	tsortingkind.defineColumn("description", typeof(string),false);
	tsortingkind.defineColumn("flag", typeof(int),false);
	tsortingkind.defineColumn("flagdate", typeof(string));
	tsortingkind.defineColumn("forcedD1", typeof(string));
	tsortingkind.defineColumn("forcedD2", typeof(string));
	tsortingkind.defineColumn("forcedD3", typeof(string));
	tsortingkind.defineColumn("forcedD4", typeof(string));
	tsortingkind.defineColumn("forcedD5", typeof(string));
	tsortingkind.defineColumn("forcedN1", typeof(string));
	tsortingkind.defineColumn("forcedN2", typeof(string));
	tsortingkind.defineColumn("forcedN3", typeof(string));
	tsortingkind.defineColumn("forcedN4", typeof(string));
	tsortingkind.defineColumn("forcedN5", typeof(string));
	tsortingkind.defineColumn("forcedS1", typeof(string));
	tsortingkind.defineColumn("forcedS2", typeof(string));
	tsortingkind.defineColumn("forcedS3", typeof(string));
	tsortingkind.defineColumn("forcedS4", typeof(string));
	tsortingkind.defineColumn("forcedS5", typeof(string));
	tsortingkind.defineColumn("forcedv1", typeof(string));
	tsortingkind.defineColumn("forcedv2", typeof(string));
	tsortingkind.defineColumn("forcedv3", typeof(string));
	tsortingkind.defineColumn("forcedv4", typeof(string));
	tsortingkind.defineColumn("forcedv5", typeof(string));
	tsortingkind.defineColumn("idparentkind", typeof(int));
	tsortingkind.defineColumn("idsorkind", typeof(int),false);
	tsortingkind.defineColumn("labelD1", typeof(string));
	tsortingkind.defineColumn("labelD2", typeof(string));
	tsortingkind.defineColumn("labelD3", typeof(string));
	tsortingkind.defineColumn("labelD4", typeof(string));
	tsortingkind.defineColumn("labelD5", typeof(string));
	tsortingkind.defineColumn("labelfordate", typeof(string));
	tsortingkind.defineColumn("labeln1", typeof(string));
	tsortingkind.defineColumn("labeln2", typeof(string));
	tsortingkind.defineColumn("labeln3", typeof(string));
	tsortingkind.defineColumn("labeln4", typeof(string));
	tsortingkind.defineColumn("labeln5", typeof(string));
	tsortingkind.defineColumn("labels1", typeof(string));
	tsortingkind.defineColumn("labels2", typeof(string));
	tsortingkind.defineColumn("labels3", typeof(string));
	tsortingkind.defineColumn("labels4", typeof(string));
	tsortingkind.defineColumn("labels5", typeof(string));
	tsortingkind.defineColumn("labelv1", typeof(string));
	tsortingkind.defineColumn("labelv2", typeof(string));
	tsortingkind.defineColumn("labelv3", typeof(string));
	tsortingkind.defineColumn("labelv4", typeof(string));
	tsortingkind.defineColumn("labelv5", typeof(string));
	tsortingkind.defineColumn("lockedD1", typeof(string));
	tsortingkind.defineColumn("lockedD2", typeof(string));
	tsortingkind.defineColumn("lockedD3", typeof(string));
	tsortingkind.defineColumn("lockedD4", typeof(string));
	tsortingkind.defineColumn("lockedD5", typeof(string));
	tsortingkind.defineColumn("lockedN1", typeof(string));
	tsortingkind.defineColumn("lockedN2", typeof(string));
	tsortingkind.defineColumn("lockedN3", typeof(string));
	tsortingkind.defineColumn("lockedN4", typeof(string));
	tsortingkind.defineColumn("lockedN5", typeof(string));
	tsortingkind.defineColumn("lockedS1", typeof(string));
	tsortingkind.defineColumn("lockedS2", typeof(string));
	tsortingkind.defineColumn("lockedS3", typeof(string));
	tsortingkind.defineColumn("lockedS4", typeof(string));
	tsortingkind.defineColumn("lockedS5", typeof(string));
	tsortingkind.defineColumn("lockedv1", typeof(string));
	tsortingkind.defineColumn("lockedv2", typeof(string));
	tsortingkind.defineColumn("lockedv3", typeof(string));
	tsortingkind.defineColumn("lockedv4", typeof(string));
	tsortingkind.defineColumn("lockedv5", typeof(string));
	tsortingkind.defineColumn("lt", typeof(DateTime),false);
	tsortingkind.defineColumn("lu", typeof(string),false);
	tsortingkind.defineColumn("nodatelabel", typeof(string));
	tsortingkind.defineColumn("nphaseexpense", typeof(int));
	tsortingkind.defineColumn("nphaseincome", typeof(int));
	tsortingkind.defineColumn("start", typeof(int));
	tsortingkind.defineColumn("stop", typeof(int));
	tsortingkind.defineColumn("totalexpression", typeof(string));
	Tables.Add(tsortingkind);
	tsortingkind.defineKey("idsorkind");

	//////////////////// UNICONFIG /////////////////////////////////
	var tuniconfig= new MetaTable("uniconfig");
	tuniconfig.defineColumn("attachment_max_size_mb", typeof(int));
	tuniconfig.defineColumn("dummykey", typeof(int),false);
	tuniconfig.defineColumn("ep360days", typeof(string));
	tuniconfig.defineColumn("expensefinphase", typeof(int));
	tuniconfig.defineColumn("expenseregphase", typeof(int));
	tuniconfig.defineColumn("flag", typeof(int));
	tuniconfig.defineColumn("flagresearchagency", typeof(string),false);
	tuniconfig.defineColumn("idente", typeof(int));
	tuniconfig.defineColumn("idsorkind01", typeof(int));
	tuniconfig.defineColumn("idsorkind02", typeof(int));
	tuniconfig.defineColumn("idsorkind03", typeof(int));
	tuniconfig.defineColumn("idsorkind04", typeof(int));
	tuniconfig.defineColumn("idsorkind05", typeof(int));
	tuniconfig.defineColumn("incomefinphase", typeof(int));
	tuniconfig.defineColumn("incomeregphase", typeof(int));
	tuniconfig.defineColumn("perla_codiceaoopa", typeof(string));
	tuniconfig.defineColumn("perla_codicefiscalepa", typeof(string));
	tuniconfig.defineColumn("perla_codicepaipa", typeof(string));
	tuniconfig.defineColumn("perla_codiceuopa", typeof(string));
	tuniconfig.defineColumn("perla_pwd", typeof(string));
	tuniconfig.defineColumn("perla_user", typeof(string));
	tuniconfig.defineColumn("publicagency", typeof(string));
	tuniconfig.defineColumn("pwd_requiredigit", typeof(string));
	tuniconfig.defineColumn("pwd_requiredlength", typeof(int));
	tuniconfig.defineColumn("pwd_requireduniquechars", typeof(int));
	tuniconfig.defineColumn("pwd_requirelowercase", typeof(string));
	tuniconfig.defineColumn("pwd_requirenonalphanumeric", typeof(string));
	tuniconfig.defineColumn("pwd_requireuppercase", typeof(string));
	tuniconfig.defineColumn("rea_closingstatus", typeof(string));
	tuniconfig.defineColumn("rea_number", typeof(string));
	tuniconfig.defineColumn("rea_partner", typeof(string));
	tuniconfig.defineColumn("rea_provinceoffice", typeof(string));
	tuniconfig.defineColumn("rea_socialcapital", typeof(decimal));
	tuniconfig.defineColumn("sorkind01asfilter", typeof(string));
	tuniconfig.defineColumn("sorkind02asfilter", typeof(string));
	tuniconfig.defineColumn("sorkind03asfilter", typeof(string));
	tuniconfig.defineColumn("sorkind04asfilter", typeof(string));
	tuniconfig.defineColumn("sorkind05asfilter", typeof(string));
	tuniconfig.defineColumn("ssn_codasl", typeof(string));
	tuniconfig.defineColumn("ssn_codregione", typeof(string));
	tuniconfig.defineColumn("ssn_codssa", typeof(string));
	tuniconfig.defineColumn("tree_upb_withdescr", typeof(string));
	tuniconfig.defineColumn("webprotaddress", typeof(string));
	Tables.Add(tuniconfig);
	tuniconfig.defineKey("dummykey");

	//////////////////// FLOWCHART /////////////////////////////////
	var tflowchart= new MetaTable("flowchart");
	tflowchart.defineColumn("address", typeof(string));
	tflowchart.defineColumn("ayear", typeof(int));
	tflowchart.defineColumn("cap", typeof(string));
	tflowchart.defineColumn("codeflowchart", typeof(string),false);
	tflowchart.defineColumn("ct", typeof(DateTime),false);
	tflowchart.defineColumn("cu", typeof(string),false);
	tflowchart.defineColumn("fax", typeof(string));
	tflowchart.defineColumn("idcity", typeof(int));
	tflowchart.defineColumn("idflowchart", typeof(string),false);
	tflowchart.defineColumn("idsor1", typeof(int));
	tflowchart.defineColumn("idsor2", typeof(int));
	tflowchart.defineColumn("idsor3", typeof(int));
	tflowchart.defineColumn("location", typeof(string));
	tflowchart.defineColumn("lt", typeof(DateTime),false);
	tflowchart.defineColumn("lu", typeof(string),false);
	tflowchart.defineColumn("nlevel", typeof(int),false);
	tflowchart.defineColumn("paridflowchart", typeof(string),false);
	tflowchart.defineColumn("phone", typeof(string));
	tflowchart.defineColumn("printingorder", typeof(string),false);
	tflowchart.defineColumn("title", typeof(string),false);
	Tables.Add(tflowchart);
	tflowchart.defineKey("idflowchart");

	//////////////////// REGISTRATIONUSERFLOWCHART /////////////////////////////////
	var tregistrationuserflowchart= new MetaTable("registrationuserflowchart");
	tregistrationuserflowchart.defineColumn("idflowchart", typeof(string),false);
	tregistrationuserflowchart.defineColumn("idregistrationuser", typeof(int),false);
	Tables.Add(tregistrationuserflowchart);
	tregistrationuserflowchart.defineKey("idflowchart", "idregistrationuser");

	//////////////////// USERKIND /////////////////////////////////
	var tuserkind= new MetaTable("userkind");
	tuserkind.defineColumn("title", typeof(string));
	tuserkind.defineColumn("userkind", typeof(int),false);
	Tables.Add(tuserkind);
	tuserkind.defineKey("userkind");

	//////////////////// SORTINGUSABLEDEFAULTVIEW_ALIAS4 /////////////////////////////////
	var tsortingusabledefaultview_alias4= new MetaTable("sortingusabledefaultview_alias4");
	tsortingusabledefaultview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("idsor", typeof(int),false);
	tsortingusabledefaultview_alias4.defineColumn("paridsor", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortcode", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingkind_description", typeof(string));
	tsortingusabledefaultview_alias4.defineColumn("sortingparent_description", typeof(string));
	tsortingusabledefaultview_alias4.defineColumn("sortingparent_sortcode", typeof(string));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_codesorkind", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_ct", typeof(DateTime),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_cu", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_description", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_idsor01", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_idsor02", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_idsor03", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_idsor04", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_idsor05", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_idsorkind", typeof(int),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_leveldescr", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_lt", typeof(DateTime),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_lu", typeof(string),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_movkind", typeof(string));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_nlevel", typeof(int),false);
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_start", typeof(int));
	tsortingusabledefaultview_alias4.defineColumn("sortingusable_stop", typeof(int));
	tsortingusabledefaultview_alias4.ExtendedProperties["TableForReading"]="sortingusabledefaultview";
	Tables.Add(tsortingusabledefaultview_alias4);
	tsortingusabledefaultview_alias4.defineKey("idsor");

	//////////////////// SORTINGUSABLEDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tsortingusabledefaultview_alias3= new MetaTable("sortingusabledefaultview_alias3");
	tsortingusabledefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("idsor", typeof(int),false);
	tsortingusabledefaultview_alias3.defineColumn("paridsor", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortcode", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingkind_description", typeof(string));
	tsortingusabledefaultview_alias3.defineColumn("sortingparent_description", typeof(string));
	tsortingusabledefaultview_alias3.defineColumn("sortingparent_sortcode", typeof(string));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_codesorkind", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_ct", typeof(DateTime),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_cu", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_description", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_idsor01", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_idsor02", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_idsor03", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_idsor04", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_idsor05", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_idsorkind", typeof(int),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_leveldescr", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_lt", typeof(DateTime),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_lu", typeof(string),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_movkind", typeof(string));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_nlevel", typeof(int),false);
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_start", typeof(int));
	tsortingusabledefaultview_alias3.defineColumn("sortingusable_stop", typeof(int));
	tsortingusabledefaultview_alias3.ExtendedProperties["TableForReading"]="sortingusabledefaultview";
	Tables.Add(tsortingusabledefaultview_alias3);
	tsortingusabledefaultview_alias3.defineKey("idsor");

	//////////////////// SORTINGUSABLEDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tsortingusabledefaultview_alias2= new MetaTable("sortingusabledefaultview_alias2");
	tsortingusabledefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("idsor", typeof(int),false);
	tsortingusabledefaultview_alias2.defineColumn("paridsor", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortcode", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingkind_description", typeof(string));
	tsortingusabledefaultview_alias2.defineColumn("sortingparent_description", typeof(string));
	tsortingusabledefaultview_alias2.defineColumn("sortingparent_sortcode", typeof(string));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_codesorkind", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_ct", typeof(DateTime),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_cu", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_description", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_idsor01", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_idsor02", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_idsor03", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_idsor04", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_idsor05", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_idsorkind", typeof(int),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_leveldescr", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_lt", typeof(DateTime),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_lu", typeof(string),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_movkind", typeof(string));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_nlevel", typeof(int),false);
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_start", typeof(int));
	tsortingusabledefaultview_alias2.defineColumn("sortingusable_stop", typeof(int));
	tsortingusabledefaultview_alias2.ExtendedProperties["TableForReading"]="sortingusabledefaultview";
	Tables.Add(tsortingusabledefaultview_alias2);
	tsortingusabledefaultview_alias2.defineKey("idsor");

	//////////////////// SORTINGUSABLEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tsortingusabledefaultview_alias1= new MetaTable("sortingusabledefaultview_alias1");
	tsortingusabledefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("idsor", typeof(int),false);
	tsortingusabledefaultview_alias1.defineColumn("paridsor", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortcode", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingkind_description", typeof(string));
	tsortingusabledefaultview_alias1.defineColumn("sortingparent_description", typeof(string));
	tsortingusabledefaultview_alias1.defineColumn("sortingparent_sortcode", typeof(string));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_codesorkind", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_ct", typeof(DateTime),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_cu", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_description", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_idsor01", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_idsor02", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_idsor03", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_idsor04", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_idsor05", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_idsorkind", typeof(int),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_leveldescr", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_lt", typeof(DateTime),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_lu", typeof(string),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_movkind", typeof(string));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_nlevel", typeof(int),false);
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_start", typeof(int));
	tsortingusabledefaultview_alias1.defineColumn("sortingusable_stop", typeof(int));
	tsortingusabledefaultview_alias1.ExtendedProperties["TableForReading"]="sortingusabledefaultview";
	Tables.Add(tsortingusabledefaultview_alias1);
	tsortingusabledefaultview_alias1.defineKey("idsor");

	//////////////////// SORTINGUSABLEDEFAULTVIEW /////////////////////////////////
	var tsortingusabledefaultview= new MetaTable("sortingusabledefaultview");
	tsortingusabledefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsortingusabledefaultview.defineColumn("idsor", typeof(int),false);
	tsortingusabledefaultview.defineColumn("paridsor", typeof(int));
	tsortingusabledefaultview.defineColumn("sortcode", typeof(string),false);
	tsortingusabledefaultview.defineColumn("sortingkind_description", typeof(string));
	tsortingusabledefaultview.defineColumn("sortingparent_description", typeof(string));
	tsortingusabledefaultview.defineColumn("sortingparent_sortcode", typeof(string));
	tsortingusabledefaultview.defineColumn("sortingusable_codesorkind", typeof(string),false);
	tsortingusabledefaultview.defineColumn("sortingusable_ct", typeof(DateTime),false);
	tsortingusabledefaultview.defineColumn("sortingusable_cu", typeof(string),false);
	tsortingusabledefaultview.defineColumn("sortingusable_description", typeof(string),false);
	tsortingusabledefaultview.defineColumn("sortingusable_idsor01", typeof(int));
	tsortingusabledefaultview.defineColumn("sortingusable_idsor02", typeof(int));
	tsortingusabledefaultview.defineColumn("sortingusable_idsor03", typeof(int));
	tsortingusabledefaultview.defineColumn("sortingusable_idsor04", typeof(int));
	tsortingusabledefaultview.defineColumn("sortingusable_idsor05", typeof(int));
	tsortingusabledefaultview.defineColumn("sortingusable_idsorkind", typeof(int),false);
	tsortingusabledefaultview.defineColumn("sortingusable_leveldescr", typeof(string),false);
	tsortingusabledefaultview.defineColumn("sortingusable_lt", typeof(DateTime),false);
	tsortingusabledefaultview.defineColumn("sortingusable_lu", typeof(string),false);
	tsortingusabledefaultview.defineColumn("sortingusable_movkind", typeof(string));
	tsortingusabledefaultview.defineColumn("sortingusable_nlevel", typeof(int),false);
	tsortingusabledefaultview.defineColumn("sortingusable_start", typeof(int));
	tsortingusabledefaultview.defineColumn("sortingusable_stop", typeof(int));
	Tables.Add(tsortingusabledefaultview);
	tsortingusabledefaultview.defineKey("idsor");

	//////////////////// USERTYPE /////////////////////////////////
	var tusertype= new MetaTable("usertype");
	tusertype.defineColumn("usertype", typeof(string),false);
	Tables.Add(tusertype);
	tusertype.defineKey("usertype");

	//////////////////// REGISTRATIONUSER /////////////////////////////////
	var tregistrationuser= new MetaTable("registrationuser");
	tregistrationuser.defineColumn("!password", typeof(string));
	tregistrationuser.defineColumn("all_sorkind01", typeof(string));
	tregistrationuser.defineColumn("all_sorkind02", typeof(string));
	tregistrationuser.defineColumn("all_sorkind03", typeof(string));
	tregistrationuser.defineColumn("all_sorkind04", typeof(string));
	tregistrationuser.defineColumn("all_sorkind05", typeof(string));
	tregistrationuser.defineColumn("cf", typeof(string));
	tregistrationuser.defineColumn("ct", typeof(DateTime));
	tregistrationuser.defineColumn("cu", typeof(string));
	tregistrationuser.defineColumn("email", typeof(string));
	tregistrationuser.defineColumn("esercizio", typeof(int));
	tregistrationuser.defineColumn("flagdefault", typeof(string));
	tregistrationuser.defineColumn("forename", typeof(string));
	tregistrationuser.defineColumn("idregistrationuser", typeof(int),false);
	tregistrationuser.defineColumn("idregistrationuserstatus", typeof(int));
	tregistrationuser.defineColumn("idsor01", typeof(int));
	tregistrationuser.defineColumn("idsor02", typeof(int));
	tregistrationuser.defineColumn("idsor03", typeof(int));
	tregistrationuser.defineColumn("idsor04", typeof(int));
	tregistrationuser.defineColumn("idsor05", typeof(int));
	tregistrationuser.defineColumn("login", typeof(string));
	tregistrationuser.defineColumn("lt", typeof(DateTime));
	tregistrationuser.defineColumn("lu", typeof(string));
	tregistrationuser.defineColumn("matricola", typeof(string));
	tregistrationuser.defineColumn("requesttimestamp", typeof(DateTime));
	tregistrationuser.defineColumn("sorkind01_withchilds", typeof(string));
	tregistrationuser.defineColumn("sorkind02_withchilds", typeof(string));
	tregistrationuser.defineColumn("sorkind03_withchilds", typeof(string));
	tregistrationuser.defineColumn("sorkind04_withchilds", typeof(string));
	tregistrationuser.defineColumn("sorkind05_withchilds", typeof(string));
	tregistrationuser.defineColumn("start", typeof(DateTime));
	tregistrationuser.defineColumn("stop", typeof(DateTime));
	tregistrationuser.defineColumn("surname", typeof(string));
	tregistrationuser.defineColumn("title", typeof(string));
	tregistrationuser.defineColumn("userkind", typeof(int));
	tregistrationuser.defineColumn("usertype", typeof(string));
	Tables.Add(tregistrationuser);
	tregistrationuser.defineKey("idregistrationuser");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrationuser.Columns["idregistrationuser"]};
	var cChild = new []{registrationuserflowchart.Columns["idregistrationuser"]};
	Relations.Add(new DataRelation("FK_registrationuserflowchart_registrationuser_idregistrationuser",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{registrationuserflowchart.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_registrationuserflowchart_flowchart_idflowchart",cPar,cChild,false));

	cPar = new []{userkind.Columns["userkind"]};
	cChild = new []{registrationuser.Columns["userkind"]};
	Relations.Add(new DataRelation("FK_registrationuser_userkind_userkind",cPar,cChild,false));

	cPar = new []{sortingusabledefaultview_alias4.Columns["idsor"]};
	cChild = new []{registrationuser.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_registrationuser_sortingusabledefaultview_alias4_idsor05",cPar,cChild,false));

	cPar = new []{sortingusabledefaultview_alias3.Columns["idsor"]};
	cChild = new []{registrationuser.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_registrationuser_sortingusabledefaultview_alias3_idsor04",cPar,cChild,false));

	cPar = new []{sortingusabledefaultview_alias2.Columns["idsor"]};
	cChild = new []{registrationuser.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_registrationuser_sortingusabledefaultview_alias2_idsor03",cPar,cChild,false));

	cPar = new []{sortingusabledefaultview_alias1.Columns["idsor"]};
	cChild = new []{registrationuser.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_registrationuser_sortingusabledefaultview_alias1_idsor02",cPar,cChild,false));

	cPar = new []{sortingusabledefaultview.Columns["idsor"]};
	cChild = new []{registrationuser.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_registrationuser_sortingusabledefaultview_idsor01",cPar,cChild,false));

	cPar = new []{usertype.Columns["usertype"]};
	cChild = new []{registrationuser.Columns["usertype"]};
	Relations.Add(new DataRelation("FK_registrationuser_usertype_usertype",cPar,cChild,false));

	#endregion

}
}
}
