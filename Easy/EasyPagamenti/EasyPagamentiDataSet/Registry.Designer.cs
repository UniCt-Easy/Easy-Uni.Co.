
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
using meta_registry;
using meta_registryaddress;
using meta_registryreference;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace EasyPagamentiDataSet {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_registry"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registry: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryaddressTable registryaddress 		=> (registryaddressTable)Tables["registryaddress"];

	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryreferenceTable registryreference 		=> (registryreferenceTable)Tables["registryreference"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","active","annotation","badgecode","birthdate","cf","ct","cu","extmatricula","foreigncf","forename","gender","idcategory","idcentralizedcategory","idcity","idmaritalstatus","idnation","idregistryclass","idtitle","location","lt","lu","maritalsurname","p_iva","rtf","surname","title","txt","residence","idregistrykind","authorization_free","multi_cf","toredirect","idaccmotivedebit","idaccmotivecredit","ccp","flagbankitaliaproceeds","idexternal","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm","email_fe","pec_fe");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new registryaddressTable();
	tregistryaddress.addBaseColumns("idreg","start","active","address","annotations","cap","ct","cu","flagforeign","idcity","idnation","location","lt","lu","officename","stop","idaddresskind","recipientagency");
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idreg", "start", "idaddresskind");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new registryreferenceTable();
	tregistryreference.addBaseColumns("idreg","idregistryreference","ct","cu","email","faxnumber","flagdefault","lt","lu","mobilenumber","msnnumber","phonenumber","referencename","registryreferencerole","rtf","skypenumber","txt","userweb","passwordweb","saltweb","iterweb","activeweb","pec");
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_registryaddress_registry","registry","registryaddress","idreg");
	this.defineRelation("FK_registryreference_registry","registry","registryreference","idreg");
	#endregion

}
}
}
