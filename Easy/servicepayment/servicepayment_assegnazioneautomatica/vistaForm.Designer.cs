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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_serviceregistry;
using metadatalibrary;
namespace servicepayment_assegnazioneautomatica {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Assegnazione Automatica del Pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public MetaTable servicepayment 		{get { return (MetaTable)Tables["servicepayment"];}}
	///<summary>
	///Banca dati degli Incarichi - Anagrafe Prestazioni e Pubblicazione sito web istituzionale
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public serviceregistryTable serviceregistry 		{get { return (serviceregistryTable )Tables["serviceregistry"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public dsmeta(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";
	EnforceConstraints = false;

	#region create DataTables
	MetaTable T;
	//////////////////// SERVICEPAYMENT /////////////////////////////////
	T= new MetaTable("servicepayment");
	T.defineColumn("yservreg", typeof(Int32),false);
	T.defineColumn("nservreg", typeof(Int32),false);
	T.defineColumn("ypay", typeof(Int32),false);
	T.defineColumn("semesterpay", typeof(Int32),false);
	T.defineColumn("payedamount", typeof(Decimal));
	T.defineColumn("is_delivered", typeof(String));
	T.defineColumn("is_changed", typeof(String));
	T.defineColumn("ct", typeof(DateTime),false);
	T.defineColumn("cu", typeof(String),false);
	T.defineColumn("lt", typeof(DateTime),false);
	T.defineColumn("lu", typeof(String),false);
	T.defineColumn("is_blocked", typeof(String));
	Tables.Add(T);
	T.defineKey("yservreg", "nservreg", "ypay", "semesterpay");

	//////////////////// SERVICEREGISTRY /////////////////////////////////
	var tserviceregistry= new serviceregistryTable();
	tserviceregistry.addBaseColumns("yservreg","nservreg","id_service","employkind","iddepartment","is_annulled","is_delivered","is_changed","idconsultingkind","p_iva","cf","flagforeign","title","codcity","surname","forename","birthdate","gender","referencesemester","pa_code","idacquirekind","idapcontractkind","idfinancialactivity","description","start","stop","servicevariation","expectedamount","payment","ypay","idapmanager","idapregistrykind","idapactivitykind","pa_cf","pa_title","authorizationdate","officeduty","annotation","referencerule","ct","cu","lt","lu","rtf","txt","idreg","idcity","idrelated","is_blocked","regulation","paragraph","article","articlenumber","referencedate","idreferencerule","idapfinancialactivity","rulespecifics","expectationsdate","senderreporting","flaghuman","conferring_piva","conferring_forename","conferring_surname","conferring_flagforeign","conferring_birthdate","conferring_gender","conferring_codcity","conferring_idcity","idconferring","conferringstructure","ordinancelink","authorizingstructure","authorizinglink","actreference","announcementlink","otherservice","professionalservice","componentsvariable","idserviceregistrykind","employtime","notes","idsor01","idsor02","idsor03","idsor04","idsor05","certinterestconflicts","website_annulled");
	Tables.Add(tserviceregistry);
	tserviceregistry.defineKey("yservreg", "nservreg");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	this.defineRelation("serviceregistry_servicepayment","serviceregistry","servicepayment","yservreg","nservreg");
	#endregion

}
}
}
