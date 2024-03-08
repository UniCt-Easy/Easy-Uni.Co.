
/*
Easy
Copyright (C) 2024 Universit‡ degli Studi di Catania (www.unict.it)
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
using meta_registryreference;
using meta_registryclass;
using meta_registryaddress;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace EasyPagamentiDataSet {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_anagrafica"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_anagrafica: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryTable registry 		=> (registryTable)Tables["registry"];

	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryreferenceTable registryreference 		=> (registryreferenceTable)Tables["registryreference"];

	///<summary>
	///Classificazione Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrykind 		=> (MetaTable)Tables["registrykind"];

	///<summary>
	///Modalit√† pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypaymethod 		=> (MetaTable)Tables["registrypaymethod"];

	///<summary>
	///Reddito Annuo Presunto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrytaxablestatus 		=> (MetaTable)Tables["registrytaxablestatus"];

	///<summary>
	/// Tipo Residenza
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	///<summary>
	///Tipo Indirizzo  (anagrafica)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable address 		=> (MetaTable)Tables["address"];

	///<summary>
	///Tipologie classificazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryclassTable registryclass 		=> (registryclassTable)Tables["registryclass"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public registryaddressTable registryaddress 		=> (registryaddressTable)Tables["registryaddress"];

	///<summary>
	///Storicizzazione Codice Fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycf 		=> (MetaTable)Tables["registrycf"];

	///<summary>
	///Storicizzazione Partita IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypiva 		=> (MetaTable)Tables["registrypiva"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_anagrafica(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_anagrafica (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_anagrafica";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_anagrafica.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new registryTable();
	tregistry.addBaseColumns("idreg","title","cf","p_iva","residence","idregistrykind","annotation","birthdate","gender","surname","forename","foreigncf","active","txt","rtf","cu","ct","lu","lt","extmatricula","idregistryclass","idcentralizedcategory","idtitle","idmaritalstatus","badgecode","maritalsurname","idcategory","idcity","location","idnation","authorization_free","multi_cf","idaccmotivecredit","idaccmotivedebit","ccp","flagbankitaliaproceeds","ipa_fe","flag_pa","sdi_norifamm","sdi_defrifamm","email_fe","pec_fe");
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new registryreferenceTable();
	tregistryreference.addBaseColumns("referencename","idreg","registryreferencerole","phonenumber","faxnumber","mobilenumber","email","userweb","passwordweb","txt","rtf","cu","ct","lu","lt","flagdefault","idregistryreference","skypenumber","msnnumber","pec");
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new MetaTable("registrykind");
	tregistrykind.defineColumn("idregistrykind", typeof(int),false);
	tregistrykind.defineColumn("sortcode", typeof(string),false);
	tregistrykind.defineColumn("description", typeof(string),false);
	tregistrykind.defineColumn("cu", typeof(string),false);
	tregistrykind.defineColumn("ct", typeof(DateTime),false);
	tregistrykind.defineColumn("lu", typeof(string),false);
	tregistrykind.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(tregistrykind);
	tregistrykind.defineKey("idregistrykind");

	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new MetaTable("registrypaymethod");
	tregistrypaymethod.defineColumn("regmodcode", typeof(string),false);
	tregistrypaymethod.defineColumn("idreg", typeof(int),false);
	tregistrypaymethod.defineColumn("idpaymethod", typeof(int));
	tregistrypaymethod.defineColumn("cin", typeof(string));
	tregistrypaymethod.defineColumn("iban", typeof(string));
	tregistrypaymethod.defineColumn("idbank", typeof(string));
	tregistrypaymethod.defineColumn("idcab", typeof(string));
	tregistrypaymethod.defineColumn("cc", typeof(string));
	tregistrypaymethod.defineColumn("paymentdescr", typeof(string));
	tregistrypaymethod.defineColumn("paymentexpiring", typeof(short));
	tregistrypaymethod.defineColumn("idexpirationkind", typeof(short));
	tregistrypaymethod.defineColumn("flagstandard", typeof(string));
	tregistrypaymethod.defineColumn("txt", typeof(string));
	tregistrypaymethod.defineColumn("rtf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("cu", typeof(string),false);
	tregistrypaymethod.defineColumn("ct", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("lu", typeof(string),false);
	tregistrypaymethod.defineColumn("active", typeof(string));
	tregistrypaymethod.defineColumn("lt", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("iddeputy", typeof(int));
	tregistrypaymethod.defineColumn("refexternaldoc", typeof(string));
	tregistrypaymethod.defineColumn("idregistrypaymethod", typeof(int),false);
	tregistrypaymethod.defineColumn("idcurrency", typeof(int));
	tregistrypaymethod.defineColumn("extracode", typeof(string));
	tregistrypaymethod.defineColumn("biccode", typeof(string));
	tregistrypaymethod.defineColumn("flag", typeof(int));
	tregistrypaymethod.defineColumn("idchargehandling", typeof(string));
	tregistrypaymethod.defineColumn("notes", typeof(string));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.defineKey("idreg", "idregistrypaymethod");

	//////////////////// REGISTRYTAXABLESTATUS /////////////////////////////////
	var tregistrytaxablestatus= new MetaTable("registrytaxablestatus");
	tregistrytaxablestatus.defineColumn("start", typeof(DateTime),false);
	tregistrytaxablestatus.defineColumn("idreg", typeof(int),false);
	tregistrytaxablestatus.defineColumn("supposedincome", typeof(decimal));
	tregistrytaxablestatus.defineColumn("txt", typeof(string));
	tregistrytaxablestatus.defineColumn("rtf", typeof(Byte[]));
	tregistrytaxablestatus.defineColumn("cu", typeof(string),false);
	tregistrytaxablestatus.defineColumn("ct", typeof(DateTime),false);
	tregistrytaxablestatus.defineColumn("lu", typeof(string),false);
	tregistrytaxablestatus.defineColumn("lt", typeof(DateTime),false);
	tregistrytaxablestatus.defineColumn("active", typeof(string));
	Tables.Add(tregistrytaxablestatus);
	tregistrytaxablestatus.defineKey("start", "idreg");

	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new MetaTable("residence");
	tresidence.defineColumn("idresidence", typeof(int),false);
	tresidence.defineColumn("coderesidence", typeof(string),false);
	tresidence.defineColumn("description", typeof(string),false);
	tresidence.defineColumn("lt", typeof(DateTime));
	tresidence.defineColumn("lu", typeof(string));
	tresidence.defineColumn("active", typeof(string));
	Tables.Add(tresidence);
	tresidence.defineKey("idresidence");

	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new MetaTable("address");
	taddress.defineColumn("idaddress", typeof(int),false);
	taddress.defineColumn("description", typeof(string),false);
	taddress.defineColumn("lt", typeof(DateTime));
	taddress.defineColumn("lu", typeof(string));
	taddress.defineColumn("active", typeof(string));
	taddress.defineColumn("codeaddress", typeof(string));
	Tables.Add(taddress);
	taddress.defineKey("idaddress");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new registryclassTable();
	tregistryclass.addBaseColumns("idregistryclass","description","flagtitle","flagcf","flagp_iva","flagqualification","flagextmatricula","flagbadgecode","flagmaritalstatus","flagforeigncf","flagmaritalsurname","flagothers","flagtitle_forced","flagcf_forced","flagp_iva_forced","flagqualification_forced","flagextmatricula_forced","flagbadgecode_forced","flagmaritalstatus_forced","flagforeigncf_forced","flagmaritalsurname_forced","flagothers_forced","active","cu","ct","lu","lt","flagresidence","flagresidence_forced","flagfiscalresidence","flagfiscalresidence_forced","flagcfbutton","flaginfofromcfbutton","flaghuman");
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new registryaddressTable();
	tregistryaddress.addBaseColumns("idreg","start","idaddresskind","annotations","ct","cu","stop","active","idcity","address","lt","lu","officename","cap","flagforeign","location","idnation","recipientagency");
	tregistryaddress.defineColumn("!descrtipoindirizzo", typeof(string));
	tregistryaddress.defineColumn("!comune", typeof(string));
	tregistryaddress.defineColumn("!localita", typeof(string));
	tregistryaddress.defineColumn("!nazione", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idreg", "start", "idaddresskind");

	//////////////////// REGISTRYCF /////////////////////////////////
	var tregistrycf= new MetaTable("registrycf");
	tregistrycf.defineColumn("idreg", typeof(int),false);
	tregistrycf.defineColumn("idregistrycf", typeof(int),false);
	tregistrycf.defineColumn("cf", typeof(string),false);
	tregistrycf.defineColumn("start", typeof(DateTime));
	tregistrycf.defineColumn("stop", typeof(DateTime),false);
	tregistrycf.defineColumn("ct", typeof(DateTime),false);
	tregistrycf.defineColumn("cu", typeof(string),false);
	tregistrycf.defineColumn("lt", typeof(DateTime),false);
	tregistrycf.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistrycf);
	tregistrycf.defineKey("idreg", "idregistrycf");

	//////////////////// REGISTRYPIVA /////////////////////////////////
	var tregistrypiva= new MetaTable("registrypiva");
	tregistrypiva.defineColumn("idreg", typeof(int),false);
	tregistrypiva.defineColumn("idregistrypiva", typeof(int),false);
	tregistrypiva.defineColumn("p_iva", typeof(string),false);
	tregistrypiva.defineColumn("start", typeof(DateTime));
	tregistrypiva.defineColumn("stop", typeof(DateTime));
	tregistrypiva.defineColumn("ct", typeof(DateTime),false);
	tregistrypiva.defineColumn("cu", typeof(string),false);
	tregistrypiva.defineColumn("lt", typeof(DateTime),false);
	tregistrypiva.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistrypiva);
	tregistrypiva.defineKey("idreg", "idregistrypiva");

	#endregion


	#region DataRelation creation
	this.defineRelation("registryregistrypiva","registry","registrypiva","idreg");
	this.defineRelation("registryregistrycf","registry","registrycf","idreg");
	var cPar = new []{address.Columns["idaddress"]};
	var cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("addressregistryaddress",cPar,cChild,false));

	this.defineRelation("registryregistryaddress","registry","registryaddress","idreg");
	this.defineRelation("registryregistrytaxablestatus","registry","registrytaxablestatus","idreg");
	this.defineRelation("registryregistrypaymethod","registry","registrypaymethod","idreg");
	this.defineRelation("registryregistryreference","registry","registryreference","idreg");
	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("residenceregistry",cPar,cChild,false));

	this.defineRelation("registryclassregistry","registryclass","registry","idregistryclass");
	this.defineRelation("registrykindregistry","registrykind","registry","idregistrykind");
	#endregion

}
}
}
