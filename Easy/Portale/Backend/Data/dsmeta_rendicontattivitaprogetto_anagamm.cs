
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogetto_anagamm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_rendicontattivitaprogetto_anagamm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itineration 		=> (MetaTable)Tables["itineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackagesegview 		=> (MetaTable)Tables["workpackagesegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosegview 		=> (MetaTable)Tables["progettosegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogetto_anagamm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogetto_anagamm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogetto_anagamm";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogetto_anagamm.xsd";

	#region create DataTables
	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_start", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("!idsal_sal_stop", typeof(DateTime));
	trendicontattivitaprogettoora.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// ITINERATION /////////////////////////////////
	var titineration= new MetaTable("itineration");
	titineration.defineColumn("active", typeof(string));
	titineration.defineColumn("adate", typeof(DateTime),false);
	titineration.defineColumn("additionalannotations", typeof(string));
	titineration.defineColumn("admincarkm", typeof(decimal));
	titineration.defineColumn("admincarkmcost", typeof(decimal));
	titineration.defineColumn("advanceapplied", typeof(string));
	titineration.defineColumn("advancepercentage", typeof(decimal));
	titineration.defineColumn("applierannotations", typeof(string));
	titineration.defineColumn("authdoc", typeof(string));
	titineration.defineColumn("authdocdate", typeof(DateTime));
	titineration.defineColumn("authneeded", typeof(string));
	titineration.defineColumn("authorizationdate", typeof(DateTime),false);
	titineration.defineColumn("cancelreason", typeof(string));
	titineration.defineColumn("clause_accepted", typeof(string));
	titineration.defineColumn("completed", typeof(string));
	titineration.defineColumn("ct", typeof(DateTime),false);
	titineration.defineColumn("cu", typeof(string),false);
	titineration.defineColumn("datecompleted", typeof(DateTime));
	titineration.defineColumn("description", typeof(string),false);
	titineration.defineColumn("flagmove", typeof(int));
	titineration.defineColumn("flagoutside", typeof(string));
	titineration.defineColumn("flagownfunds", typeof(string));
	titineration.defineColumn("flagweb", typeof(string));
	titineration.defineColumn("footkm", typeof(decimal));
	titineration.defineColumn("footkmcost", typeof(decimal));
	titineration.defineColumn("grossfactor", typeof(decimal));
	titineration.defineColumn("idaccmotive", typeof(string));
	titineration.defineColumn("idaccmotivedebit", typeof(string));
	titineration.defineColumn("idaccmotivedebit_crg", typeof(string));
	titineration.defineColumn("idaccmotivedebit_datacrg", typeof(DateTime));
	titineration.defineColumn("idauthmodel", typeof(int));
	titineration.defineColumn("iddalia_dipartimento", typeof(int));
	titineration.defineColumn("iddalia_funzionale", typeof(int));
	titineration.defineColumn("iddaliaposition", typeof(int));
	titineration.defineColumn("iddaliarecruitmentmotive", typeof(int));
	titineration.defineColumn("idforeigncountry", typeof(int));
	titineration.defineColumn("iditineration", typeof(int),false);
	titineration.defineColumn("iditineration_ref", typeof(int));
	titineration.defineColumn("iditinerationstatus", typeof(int));
	titineration.defineColumn("idreg", typeof(int),false);
	titineration.defineColumn("idregistrylegalstatus", typeof(int));
	titineration.defineColumn("idregistrypaymethod", typeof(int));
	titineration.defineColumn("idser", typeof(int),false);
	titineration.defineColumn("idsor_siope", typeof(int));
	titineration.defineColumn("idsor1", typeof(int));
	titineration.defineColumn("idsor2", typeof(int));
	titineration.defineColumn("idsor3", typeof(int));
	titineration.defineColumn("idupb", typeof(string));
	titineration.defineColumn("location", typeof(string));
	titineration.defineColumn("lt", typeof(DateTime),false);
	titineration.defineColumn("lu", typeof(string),false);
	titineration.defineColumn("netfee", typeof(decimal));
	titineration.defineColumn("nfood", typeof(int));
	titineration.defineColumn("nitineration", typeof(int),false);
	titineration.defineColumn("noauthreason", typeof(string));
	titineration.defineColumn("owncarkm", typeof(decimal));
	titineration.defineColumn("owncarkmcost", typeof(decimal));
	titineration.defineColumn("rtf", typeof(Byte[]));
	titineration.defineColumn("start", typeof(DateTime),false);
	titineration.defineColumn("starttime", typeof(DateTime));
	titineration.defineColumn("stop", typeof(DateTime),false);
	titineration.defineColumn("stoptime", typeof(DateTime));
	titineration.defineColumn("supposedamount", typeof(decimal));
	titineration.defineColumn("supposedfood", typeof(decimal));
	titineration.defineColumn("supposedliving", typeof(decimal));
	titineration.defineColumn("supposedtravel", typeof(decimal));
	titineration.defineColumn("totadvance", typeof(decimal));
	titineration.defineColumn("total", typeof(decimal));
	titineration.defineColumn("totalgross", typeof(decimal));
	titineration.defineColumn("txt", typeof(string));
	titineration.defineColumn("vehicle_info", typeof(string));
	titineration.defineColumn("vehicle_motive", typeof(string));
	titineration.defineColumn("webwarn", typeof(string));
	titineration.defineColumn("yitineration", typeof(int),false);
	Tables.Add(titineration);
	titineration.defineKey("iditineration");

	//////////////////// RENDICONTATTIVITAPROGETTOITINERATION /////////////////////////////////
	var trendicontattivitaprogettoitineration= new MetaTable("rendicontattivitaprogettoitineration");
	trendicontattivitaprogettoitineration.defineColumn("iditineration", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idworkpackage", typeof(int),false);
	Tables.Add(trendicontattivitaprogettoitineration);
	trendicontattivitaprogettoitineration.defineKey("iditineration", "idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// WORKPACKAGESEGVIEW /////////////////////////////////
	var tworkpackagesegview= new MetaTable("workpackagesegview");
	tworkpackagesegview.defineColumn("dropdown_title", typeof(string),false);
	tworkpackagesegview.defineColumn("idprogetto", typeof(int),false);
	tworkpackagesegview.defineColumn("idworkpackage", typeof(int),false);
	tworkpackagesegview.defineColumn("raggruppamento", typeof(string));
	tworkpackagesegview.defineColumn("struttura_idstrutturakind", typeof(int));
	tworkpackagesegview.defineColumn("struttura_title", typeof(string));
	tworkpackagesegview.defineColumn("strutturakind_title", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_acronimo", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_ct", typeof(DateTime),false);
	tworkpackagesegview.defineColumn("workpackage_cu", typeof(string),false);
	tworkpackagesegview.defineColumn("workpackage_description", typeof(string));
	tworkpackagesegview.defineColumn("workpackage_idstruttura", typeof(int));
	tworkpackagesegview.defineColumn("workpackage_lt", typeof(DateTime),false);
	tworkpackagesegview.defineColumn("workpackage_lu", typeof(string),false);
	tworkpackagesegview.defineColumn("workpackage_start", typeof(DateTime));
	tworkpackagesegview.defineColumn("workpackage_stop", typeof(DateTime));
	tworkpackagesegview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(tworkpackagesegview);
	tworkpackagesegview.defineKey("idworkpackage");

	//////////////////// PROGETTOSEGVIEW /////////////////////////////////
	var tprogettosegview= new MetaTable("progettosegview");
	tprogettosegview.defineColumn("dropdown_title", typeof(string),false);
	tprogettosegview.defineColumn("idcorsostudio", typeof(int));
	tprogettosegview.defineColumn("idcurrency", typeof(int));
	tprogettosegview.defineColumn("idprogetto", typeof(int),false);
	tprogettosegview.defineColumn("idreg", typeof(int));
	tprogettosegview.defineColumn("idreg_aziende", typeof(int));
	tprogettosegview.defineColumn("idreg_aziende_fin", typeof(int));
	tprogettosegview.defineColumn("idstrumentofin", typeof(int));
	Tables.Add(tprogettosegview);
	tprogettosegview.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("!orerendicont", typeof(string));
	trendicontattivitaprogetto.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("datainizioprevista", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("iditineration", typeof(int));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogetto.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogetto.defineColumn("orepreventivate", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("stop", typeof(DateTime));
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	var cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_sal_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idprogetto"], rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogetto.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["idprogetto"], rendicontattivitaprogettoitineration.Columns["idrendicontattivitaprogetto"], rendicontattivitaprogettoitineration.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_rendicontattivitaprogetto_idprogetto-idrendicontattivitaprogetto-idworkpackage",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{rendicontattivitaprogettoitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_itineration_iditineration",cPar,cChild,false));

	cPar = new []{workpackagesegview.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_workpackagesegview_idworkpackage",cPar,cChild,false));

	cPar = new []{progettosegview.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogetto.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogetto_progettosegview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
