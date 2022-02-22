
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogettoitineration_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_rendicontattivitaprogettoitineration_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable itinerationsegview 		=> (MetaTable)Tables["itinerationsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoitineration 		=> (MetaTable)Tables["rendicontattivitaprogettoitineration"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogettoitineration_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogettoitineration_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogettoitineration_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogettoitineration_default.xsd";

	#region create DataTables
	//////////////////// ITINERATIONSEGVIEW /////////////////////////////////
	var titinerationsegview= new MetaTable("itinerationsegview");
	titinerationsegview.defineColumn("description", typeof(string),false);
	titinerationsegview.defineColumn("dropdown_title", typeof(string),false);
	titinerationsegview.defineColumn("iditineration", typeof(int),false);
	titinerationsegview.defineColumn("itineration_active", typeof(string));
	titinerationsegview.defineColumn("itineration_adate", typeof(DateTime),false);
	titinerationsegview.defineColumn("itineration_additionalannotations", typeof(string));
	titinerationsegview.defineColumn("itineration_admincarkm", typeof(decimal));
	titinerationsegview.defineColumn("itineration_admincarkmcost", typeof(decimal));
	titinerationsegview.defineColumn("itineration_advanceapplied", typeof(string));
	titinerationsegview.defineColumn("itineration_advancepercentage", typeof(decimal));
	titinerationsegview.defineColumn("itineration_applierannotations", typeof(string));
	titinerationsegview.defineColumn("itineration_authdoc", typeof(string));
	titinerationsegview.defineColumn("itineration_authdocdate", typeof(DateTime));
	titinerationsegview.defineColumn("itineration_authneeded", typeof(string));
	titinerationsegview.defineColumn("itineration_authorizationdate", typeof(DateTime),false);
	titinerationsegview.defineColumn("itineration_cancelreason", typeof(string));
	titinerationsegview.defineColumn("itineration_clause_accepted", typeof(string));
	titinerationsegview.defineColumn("itineration_completed", typeof(string));
	titinerationsegview.defineColumn("itineration_ct", typeof(DateTime),false);
	titinerationsegview.defineColumn("itineration_cu", typeof(string),false);
	titinerationsegview.defineColumn("itineration_datecompleted", typeof(DateTime));
	titinerationsegview.defineColumn("itineration_flagmove", typeof(int));
	titinerationsegview.defineColumn("itineration_flagoutside", typeof(string));
	titinerationsegview.defineColumn("itineration_flagownfunds", typeof(string));
	titinerationsegview.defineColumn("itineration_flagweb", typeof(string));
	titinerationsegview.defineColumn("itineration_footkm", typeof(decimal));
	titinerationsegview.defineColumn("itineration_footkmcost", typeof(decimal));
	titinerationsegview.defineColumn("itineration_grossfactor", typeof(decimal));
	titinerationsegview.defineColumn("itineration_idaccmotive", typeof(string));
	titinerationsegview.defineColumn("itineration_idaccmotivedebit_crg", typeof(string));
	titinerationsegview.defineColumn("itineration_idaccmotivedebit_datacrg", typeof(DateTime));
	titinerationsegview.defineColumn("itineration_idauthmodel", typeof(int));
	titinerationsegview.defineColumn("itineration_iddalia_dipartimento", typeof(int));
	titinerationsegview.defineColumn("itineration_iddalia_funzionale", typeof(int));
	titinerationsegview.defineColumn("itineration_iddaliaposition", typeof(int));
	titinerationsegview.defineColumn("itineration_iddaliarecruitmentmotive", typeof(int));
	titinerationsegview.defineColumn("itineration_idforeigncountry", typeof(int));
	titinerationsegview.defineColumn("itineration_iditineration_ref", typeof(int));
	titinerationsegview.defineColumn("itineration_iditinerationstatus", typeof(int));
	titinerationsegview.defineColumn("itineration_idreg", typeof(int),false);
	titinerationsegview.defineColumn("itineration_idregistrylegalstatus", typeof(int));
	titinerationsegview.defineColumn("itineration_idregistrypaymethod", typeof(int));
	titinerationsegview.defineColumn("itineration_idser", typeof(int),false);
	titinerationsegview.defineColumn("itineration_idsor_siope", typeof(int));
	titinerationsegview.defineColumn("itineration_idsor1", typeof(int));
	titinerationsegview.defineColumn("itineration_idsor2", typeof(int));
	titinerationsegview.defineColumn("itineration_idsor3", typeof(int));
	titinerationsegview.defineColumn("itineration_idupb", typeof(string));
	titinerationsegview.defineColumn("itineration_location", typeof(string));
	titinerationsegview.defineColumn("itineration_lt", typeof(DateTime),false);
	titinerationsegview.defineColumn("itineration_lu", typeof(string),false);
	titinerationsegview.defineColumn("itineration_netfee", typeof(decimal));
	titinerationsegview.defineColumn("itineration_nfood", typeof(int));
	titinerationsegview.defineColumn("itineration_nitineration", typeof(int),false);
	titinerationsegview.defineColumn("itineration_noauthreason", typeof(string));
	titinerationsegview.defineColumn("itineration_owncarkm", typeof(decimal));
	titinerationsegview.defineColumn("itineration_owncarkmcost", typeof(decimal));
	titinerationsegview.defineColumn("itineration_rtf", typeof(Byte[]));
	titinerationsegview.defineColumn("itineration_start", typeof(DateTime),false);
	titinerationsegview.defineColumn("itineration_starttime", typeof(DateTime));
	titinerationsegview.defineColumn("itineration_stop", typeof(DateTime),false);
	titinerationsegview.defineColumn("itineration_stoptime", typeof(DateTime));
	titinerationsegview.defineColumn("itineration_supposedamount", typeof(decimal));
	titinerationsegview.defineColumn("itineration_supposedfood", typeof(decimal));
	titinerationsegview.defineColumn("itineration_supposedliving", typeof(decimal));
	titinerationsegview.defineColumn("itineration_supposedtravel", typeof(decimal));
	titinerationsegview.defineColumn("itineration_totadvance", typeof(decimal));
	titinerationsegview.defineColumn("itineration_total", typeof(decimal));
	titinerationsegview.defineColumn("itineration_totalgross", typeof(decimal));
	titinerationsegview.defineColumn("itineration_txt", typeof(string));
	titinerationsegview.defineColumn("itineration_vehicle_info", typeof(string));
	titinerationsegview.defineColumn("itineration_vehicle_motive", typeof(string));
	titinerationsegview.defineColumn("itineration_webwarn", typeof(string));
	titinerationsegview.defineColumn("itineration_yitineration", typeof(int),false);
	Tables.Add(titinerationsegview);
	titinerationsegview.defineKey("iditineration");

	//////////////////// RENDICONTATTIVITAPROGETTOITINERATION /////////////////////////////////
	var trendicontattivitaprogettoitineration= new MetaTable("rendicontattivitaprogettoitineration");
	trendicontattivitaprogettoitineration.defineColumn("iditineration", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoitineration.defineColumn("idworkpackage", typeof(int),false);
	Tables.Add(trendicontattivitaprogettoitineration);
	trendicontattivitaprogettoitineration.defineKey("iditineration", "idprogetto", "idrendicontattivitaprogetto", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{itinerationsegview.Columns["iditineration"]};
	var cChild = new []{rendicontattivitaprogettoitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoitineration_itinerationsegview_iditineration",cPar,cChild,false));

	#endregion

}
}
}
