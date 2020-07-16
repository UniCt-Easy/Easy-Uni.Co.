/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using meta_serviceregistry;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace servicepayment_assegnazioneautomatica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Assegnazione Automatica del Pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable servicepayment 		=> (MetaTable)Tables["servicepayment"];

	///<summary>
	///Banca dati degli Incarichi - Anagrafe Prestazioni e Pubblicazione sito web istituzionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public serviceregistryTable serviceregistry 		=> (serviceregistryTable)Tables["serviceregistry"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// SERVICEPAYMENT /////////////////////////////////
	var tservicepayment= new MetaTable("servicepayment");
	tservicepayment.defineColumn("yservreg", typeof(int),false);
	tservicepayment.defineColumn("nservreg", typeof(int),false);
	tservicepayment.defineColumn("ypay", typeof(int),false);
	tservicepayment.defineColumn("semesterpay", typeof(int),false);
	tservicepayment.defineColumn("payedamount", typeof(decimal));
	tservicepayment.defineColumn("is_delivered", typeof(string));
	tservicepayment.defineColumn("is_changed", typeof(string));
	tservicepayment.defineColumn("ct", typeof(DateTime),false);
	tservicepayment.defineColumn("cu", typeof(string),false);
	tservicepayment.defineColumn("lt", typeof(DateTime),false);
	tservicepayment.defineColumn("lu", typeof(string),false);
	tservicepayment.defineColumn("is_blocked", typeof(string));
	Tables.Add(tservicepayment);
	tservicepayment.defineKey("yservreg", "nservreg", "ypay", "semesterpay");

	//////////////////// SERVICEREGISTRY /////////////////////////////////
	var tserviceregistry= new serviceregistryTable();
	tserviceregistry.addBaseColumns("yservreg","nservreg","id_service","employkind","iddepartment","is_annulled","is_delivered","is_changed","idconsultingkind","p_iva","cf","flagforeign","title","codcity","surname","forename","birthdate","gender","referencesemester","pa_code","idacquirekind","idapcontractkind","idfinancialactivity","description","start","stop","servicevariation","expectedamount","payment","ypay","idapmanager","idapregistrykind","idapactivitykind","pa_cf","pa_title","authorizationdate","officeduty","annotation","referencerule","ct","cu","lt","lu","rtf","txt","idreg","idcity","idrelated","is_blocked","regulation","paragraph","article","articlenumber","referencedate","idreferencerule","idapfinancialactivity","rulespecifics","expectationsdate","senderreporting","flaghuman","conferring_piva","conferring_forename","conferring_surname","conferring_flagforeign","conferring_birthdate","conferring_gender","conferring_codcity","conferring_idcity","idconferring","conferringstructure","ordinancelink","authorizingstructure","authorizinglink","actreference","announcementlink","otherservice","professionalservice","componentsvariable","idserviceregistrykind","employtime","notes","idsor01","idsor02","idsor03","idsor04","idsor05","certinterestconflicts","website_annulled");
	Tables.Add(tserviceregistry);
	tserviceregistry.defineKey("yservreg", "nservreg");

	#endregion


	#region DataRelation creation
	this.defineRelation("serviceregistry_servicepayment","serviceregistry","servicepayment","yservreg","nservreg");
	#endregion

}
}
}
