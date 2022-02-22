
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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
using meta_provisiondetail;
using meta_provision;
using meta_registry;
using meta_accmotiveapplied;
using metadatalibrary;
namespace provisiondetail_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("dsmeta")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio accantonamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public provisiondetailTable provisiondetail 		{get { return (provisiondetailTable )Tables["provisiondetail"];}}
	///<summary>
	///Fondo accantonamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public provisionTable provision 		{get { return (provisionTable )Tables["provision"];}}
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public registryTable registry 		{get { return (registryTable )Tables["registry"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public accmotiveappliedTable accmotiveapplied 		{get { return (accmotiveappliedTable )Tables["accmotiveapplied"];}}
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
	//////////////////// PROVISIONDETAIL /////////////////////////////////
	var tprovisiondetail= new provisiondetailTable();
	tprovisiondetail.addBaseColumns("idprovision","description","amount","cu","ct","lu","lt","rownum","adate","idaccmotive","ydetail");
	Tables.Add(tprovisiondetail);
	tprovisiondetail.defineKey("idprovision", "rownum");

	//////////////////// PROVISION /////////////////////////////////
	var tprovision= new provisionTable();
	tprovision.addBaseColumns("idprovision","description","idreg","idepexp","ct","cu","lt","lu","idsor01","idsor02","idsor03","idsor04","idsor05","active","adate");
	Tables.Add(tprovision);
	tprovision.defineKey("idprovision");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","rtf","surname","title","txt","residence","idregistrykind","authorization_free","multi_cf","toredirect","idaccmotivedebit","idaccmotivecredit","ccp","flagbankitaliaproceeds","idexternal","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new accmotiveappliedTable();
	taccmotiveapplied.addBaseColumns("idaccmotive","paridaccmotive","codemotive","motive","cu","ct","lu","lt","active","idepoperation","epoperation","in_use","flagdep","flagamm");
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.defineKey("idaccmotive");

	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	this.defineRelation("registry_provision","registry","provision","idreg");
	this.defineRelation("provision_provisiondetail","provision","provisiondetail","idprovision");
	this.defineRelation("accmotiveapplied_provisiondetail","accmotiveapplied","provisiondetail","idaccmotive");
	#endregion

}
}
}
