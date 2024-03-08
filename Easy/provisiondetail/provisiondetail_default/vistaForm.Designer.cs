
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
using meta_provisiondetail;
using meta_provision;
using meta_registry;
using meta_accmotiveapplied;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace provisiondetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public provisiondetailTable provisiondetail 		=> (provisiondetailTable)Tables["provisiondetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public provisionTable provision 		=> (provisionTable)Tables["provision"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public accmotiveappliedTable accmotiveapplied 		=> (accmotiveappliedTable)Tables["accmotiveapplied"];

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
	//////////////////// PROVISIONDETAIL /////////////////////////////////
	var tprovisiondetail= new provisiondetailTable();
	tprovisiondetail.addBaseColumns("idprovision","description","amount","cu","ct","lu","lt","rownum","adate","idaccmotive","ydetail");
	Tables.Add(tprovisiondetail);
	tprovisiondetail.defineKey("idprovision", "rownum");

	//////////////////// PROVISION /////////////////////////////////
	var tprovision= new provisionTable();
	tprovision.addBaseColumns("idprovision","description","idreg","idepexp","ct","cu","lt","lu","idsor01","idsor02","idsor03","idsor04","idsor05","active","adate","title");
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
	this.defineRelation("registry_provision","registry","provision","idreg");
	this.defineRelation("provision_provisiondetail","provision","provisiondetail","idprovision");
	this.defineRelation("accmotiveapplied_provisiondetail","accmotiveapplied","provisiondetail","idaccmotive");
	#endregion

}
}
}
