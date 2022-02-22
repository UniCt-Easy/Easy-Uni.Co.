
/*
Easy
Copyright (C) 2022 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("Anagrafica"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class Anagrafica: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Stato civile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable maritalstatus 		=> Tables["maritalstatus"];

	///<summary>
	///Categoria
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable category 		=> Tables["category"];

	///<summary>
	///Classificazione centralizzata anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable centralizedcategory 		=> Tables["centralizedcategory"];

	///<summary>
	///Qualifica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable position 		=> Tables["position"];

	///<summary>
	///Inquadramento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrylegalstatus 		=> Tables["registrylegalstatus"];

	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryreference 		=> Tables["registryreference"];

	///<summary>
	///Classificazione anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrysorting 		=> Tables["registrysorting"];

	///<summary>
	///Classificazione Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrykind 		=> Tables["registrykind"];

	///<summary>
	///Titolo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable title 		=> Tables["title"];

	///<summary>
	///Modalit√† pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypaymethod 		=> Tables["registrypaymethod"];

	///<summary>
	///Reddito Annuo Presunto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrytaxablestatus 		=> Tables["registrytaxablestatus"];

	///<summary>
	/// Tipo Residenza
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable residence 		=> Tables["residence"];

	///<summary>
	///Tipo Indirizzo  (anagrafica)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable address 		=> Tables["address"];

	///<summary>
	///Tipologie classificazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryclass 		=> Tables["registryclass"];

	///<summary>
	///Comuni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city 		=> Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_city_agencyview 		=> Tables["geo_city_agencyview"];

	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryaddress 		=> Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_nazione_alias 		=> Tables["geo_nazione_alias"];

	///<summary>
	///Nazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_nation 		=> Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	///<summary>
	///Storicizzazione Codice Fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrycf 		=> Tables["registrycf"];

	///<summary>
	///Storicizzazione Partita IVA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypiva 		=> Tables["registrypiva"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_debit 		=> Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_credit 		=> Tables["accmotiveapplied_credit"];

	///<summary>
	///DURC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrydurc 		=> Tables["registrydurc"];

	///<summary>
	///Tipo DURC
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable durckind 		=> Tables["durckind"];

	///<summary>
	///CV
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrycvattachment 		=> Tables["registrycvattachment"];

	///<summary>
	///Categorie particolari
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryspecialcategory770 		=> Tables["registryspecialcategory770"];

	///<summary>
	///Categoria speciale 770
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable specialcategory770 		=> Tables["specialcategory770"];

	///<summary>
	///Posizione Dalia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_position 		=> Tables["dalia_position"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public Anagrafica(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected Anagrafica (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "Anagrafica";
	Prefix = "";
	Namespace = "http://tempuri.org/Anagrafica.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("title", typeof(string)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("residence", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("active", typeof(string)));
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new DataTable("maritalstatus");
	C= new DataColumn("idmaritalstatus", typeof(string));
	C.AllowDBNull=false;
	tmaritalstatus.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmaritalstatus.Columns.Add(C);
	tmaritalstatus.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmaritalstatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmaritalstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmaritalstatus.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmaritalstatus.Columns.Add(C);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.PrimaryKey =  new DataColumn[]{tmaritalstatus.Columns["idmaritalstatus"]};


	//////////////////// CATEGORY /////////////////////////////////
	var tcategory= new DataTable("category");
	C= new DataColumn("idcategory", typeof(string));
	C.AllowDBNull=false;
	tcategory.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcategory.Columns.Add(C);
	tcategory.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcategory.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcategory.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcategory.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcategory.Columns.Add(C);
	Tables.Add(tcategory);
	tcategory.PrimaryKey =  new DataColumn[]{tcategory.Columns["idcategory"]};


	//////////////////// CENTRALIZEDCATEGORY /////////////////////////////////
	var tcentralizedcategory= new DataTable("centralizedcategory");
	C= new DataColumn("idcentralizedcategory", typeof(string));
	C.AllowDBNull=false;
	tcentralizedcategory.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcentralizedcategory.Columns.Add(C);
	tcentralizedcategory.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcentralizedcategory.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcentralizedcategory.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcentralizedcategory.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcentralizedcategory.Columns.Add(C);
	Tables.Add(tcentralizedcategory);
	tcentralizedcategory.PrimaryKey =  new DataColumn[]{tcentralizedcategory.Columns["idcentralizedcategory"]};


	//////////////////// POSITION /////////////////////////////////
	var tposition= new DataTable("position");
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("maxincomeclass", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new DataTable("registrylegalstatus");
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("idposition", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclass", typeof(short)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclassvalidity", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("!qualifica", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_compartment", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_role", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_class", typeof(string)));
	C= new DataColumn("idregistrylegalstatus", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.PrimaryKey =  new DataColumn[]{tregistrylegalstatus.Columns["idreg"], tregistrylegalstatus.Columns["idregistrylegalstatus"]};


	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new DataTable("registryreference");
	C= new DataColumn("referencename", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("registryreferencerole", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("mobilenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("email", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("userweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("flagdefault", typeof(string)));
	C= new DataColumn("idregistryreference", typeof(int));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("skypenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("msnnumber", typeof(string)));
	Tables.Add(tregistryreference);
	tregistryreference.PrimaryKey =  new DataColumn[]{tregistryreference.Columns["idreg"], tregistryreference.Columns["idregistryreference"]};


	//////////////////// REGISTRYSORTING /////////////////////////////////
	var tregistrysorting= new DataTable("registrysorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tregistrysorting.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrysorting.Columns.Add(C);
	tregistrysorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tregistrysorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrysorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrysorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrysorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrysorting.Columns.Add(C);
	tregistrysorting.Columns.Add( new DataColumn("quota", typeof(double)));
	tregistrysorting.Columns.Add( new DataColumn("!descrtipoclass", typeof(string)));
	Tables.Add(tregistrysorting);
	tregistrysorting.PrimaryKey =  new DataColumn[]{tregistrysorting.Columns["idsor"], tregistrysorting.Columns["idreg"]};


	//////////////////// REGISTRYKIND /////////////////////////////////
	var tregistrykind= new DataTable("registrykind");
	C= new DataColumn("idregistrykind", typeof(int));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrykind.Columns.Add(C);
	Tables.Add(tregistrykind);
	tregistrykind.PrimaryKey =  new DataColumn[]{tregistrykind.Columns["idregistrykind"]};


	//////////////////// TITLE /////////////////////////////////
	var ttitle= new DataTable("title");
	C= new DataColumn("idtitle", typeof(string));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttitle.Columns.Add(C);
	Tables.Add(ttitle);
	ttitle.PrimaryKey =  new DataColumn[]{ttitle.Columns["idtitle"]};


	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new DataTable("registrypaymethod");
	C= new DataColumn("regmodcode", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("cin", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iban", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idbank", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcab", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("flagstandard", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("extracode", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("biccode", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("flag", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idchargehandling", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("notes", typeof(string)));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.PrimaryKey =  new DataColumn[]{tregistrypaymethod.Columns["idreg"], tregistrypaymethod.Columns["idregistrypaymethod"]};


	//////////////////// REGISTRYTAXABLESTATUS /////////////////////////////////
	var tregistrytaxablestatus= new DataTable("registrytaxablestatus");
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	tregistrytaxablestatus.Columns.Add( new DataColumn("supposedincome", typeof(decimal)));
	tregistrytaxablestatus.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrytaxablestatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	tregistrytaxablestatus.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tregistrytaxablestatus);
	tregistrytaxablestatus.PrimaryKey =  new DataColumn[]{tregistrytaxablestatus.Columns["start"], tregistrytaxablestatus.Columns["idreg"]};


	//////////////////// RESIDENCE /////////////////////////////////
	var tresidence= new DataTable("residence");
	C= new DataColumn("idresidence", typeof(int));
	C.AllowDBNull=false;
	tresidence.Columns.Add(C);
	C= new DataColumn("coderesidence", typeof(string));
	C.AllowDBNull=false;
	tresidence.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tresidence.Columns.Add(C);
	tresidence.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tresidence.Columns.Add( new DataColumn("lu", typeof(string)));
	tresidence.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tresidence);
	tresidence.PrimaryKey =  new DataColumn[]{tresidence.Columns["idresidence"]};


	//////////////////// ADDRESS /////////////////////////////////
	var taddress= new DataTable("address");
	C= new DataColumn("idaddress", typeof(int));
	C.AllowDBNull=false;
	taddress.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	taddress.Columns.Add(C);
	taddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	taddress.Columns.Add( new DataColumn("lu", typeof(string)));
	taddress.Columns.Add( new DataColumn("active", typeof(string)));
	taddress.Columns.Add( new DataColumn("codeaddress", typeof(string)));
	Tables.Add(taddress);
	taddress.PrimaryKey =  new DataColumn[]{taddress.Columns["idaddress"]};


	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new DataTable("registryclass");
	C= new DataColumn("idregistryclass", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagtitle", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagcf", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagp_iva", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagqualification", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagextmatricula", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagbadgecode", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalstatus", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagforeigncf", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalsurname", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagothers", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagtitle_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagcf_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagp_iva_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagqualification_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagextmatricula_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagbadgecode_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalstatus_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagforeigncf_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagmaritalsurname_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("flagothers_forced", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryclass.Columns.Add(C);
	tregistryclass.Columns.Add( new DataColumn("flagresidence", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagresidence_forced", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagfiscalresidence", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagfiscalresidence_forced", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flagcfbutton", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flaginfofromcfbutton", typeof(string)));
	tregistryclass.Columns.Add( new DataColumn("flaghuman", typeof(string)));
	Tables.Add(tregistryclass);
	tregistryclass.PrimaryKey =  new DataColumn[]{tregistryclass.Columns["idregistryclass"]};


	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new DataTable("geo_city");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city.Columns.Add(C);
	tgeo_city.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_city.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_city.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_city.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_city);
	tgeo_city.PrimaryKey =  new DataColumn[]{tgeo_city.Columns["idcity"]};


	//////////////////// GEO_CITYVIEW /////////////////////////////////
	var tgeo_cityview= new DataTable("geo_cityview");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idcountry", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("country", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("region", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("nation", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newnation", typeof(int)));
	Tables.Add(tgeo_cityview);
	tgeo_cityview.PrimaryKey =  new DataColumn[]{tgeo_cityview.Columns["idcity"]};


	//////////////////// GEO_CITY_AGENCYVIEW /////////////////////////////////
	var tgeo_city_agencyview= new DataTable("geo_city_agencyview");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	tgeo_city_agencyview.Columns.Add( new DataColumn("title", typeof(string)));
	C= new DataColumn("idagency", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	tgeo_city_agencyview.Columns.Add( new DataColumn("agencyname", typeof(string)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("agencywebsite", typeof(string)));
	C= new DataColumn("idcode", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	C= new DataColumn("version", typeof(int));
	C.AllowDBNull=false;
	tgeo_city_agencyview.Columns.Add(C);
	tgeo_city_agencyview.Columns.Add( new DataColumn("codename", typeof(string)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("value", typeof(string)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_city_agencyview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	Tables.Add(tgeo_city_agencyview);
	tgeo_city_agencyview.PrimaryKey =  new DataColumn[]{tgeo_city_agencyview.Columns["idcity"], tgeo_city_agencyview.Columns["idagency"], tgeo_city_agencyview.Columns["idcode"], tgeo_city_agencyview.Columns["version"]};


	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new DataTable("registryaddress");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("idaddresskind", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	tregistryaddress.Columns.Add( new DataColumn("annotations", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("!descrtipoindirizzo", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("address", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("officename", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("cap", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("!comune", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("location", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("!localita", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("!nazione", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("recipientagency", typeof(string)));
	Tables.Add(tregistryaddress);
	tregistryaddress.PrimaryKey =  new DataColumn[]{tregistryaddress.Columns["idreg"], tregistryaddress.Columns["start"], tregistryaddress.Columns["idaddresskind"]};


	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("coderesidence", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("residencekind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistrymainview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("city", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("qualification", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	C= new DataColumn("human", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("category", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("location", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("nation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("codemotivedebit", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("codemotivecredit", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("ccp", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("ipa_fe", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sdi_defrifamm", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


	//////////////////// GEO_NAZIONE_ALIAS /////////////////////////////////
	var tgeo_nazione_alias= new DataTable("geo_nazione_alias");
	C= new DataColumn("idnation", typeof(int));
	C.AllowDBNull=false;
	tgeo_nazione_alias.Columns.Add(C);
	tgeo_nazione_alias.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("newnation", typeof(int)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_nazione_alias.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tgeo_nazione_alias);
	tgeo_nazione_alias.PrimaryKey =  new DataColumn[]{tgeo_nazione_alias.Columns["idnation"]};


	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new DataTable("geo_nation");
	C= new DataColumn("idnation", typeof(int));
	C.AllowDBNull=false;
	tgeo_nation.Columns.Add(C);
	tgeo_nation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_nation.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tgeo_nation.Columns.Add( new DataColumn("lu", typeof(string)));
	tgeo_nation.Columns.Add( new DataColumn("newnation", typeof(int)));
	tgeo_nation.Columns.Add( new DataColumn("oldnation", typeof(int)));
	Tables.Add(tgeo_nation);
	tgeo_nation.PrimaryKey =  new DataColumn[]{tgeo_nation.Columns["idnation"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	//////////////////// REGISTRYCF /////////////////////////////////
	var tregistrycf= new DataTable("registrycf");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	C= new DataColumn("idregistrycf", typeof(int));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	C= new DataColumn("cf", typeof(string));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	tregistrycf.Columns.Add( new DataColumn("start", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrycf.Columns.Add(C);
	Tables.Add(tregistrycf);
	tregistrycf.PrimaryKey =  new DataColumn[]{tregistrycf.Columns["idreg"], tregistrycf.Columns["idregistrycf"]};


	//////////////////// REGISTRYPIVA /////////////////////////////////
	var tregistrypiva= new DataTable("registrypiva");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	C= new DataColumn("idregistrypiva", typeof(int));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	C= new DataColumn("p_iva", typeof(string));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	tregistrypiva.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tregistrypiva.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypiva.Columns.Add(C);
	Tables.Add(tregistrypiva);
	tregistrypiva.PrimaryKey =  new DataColumn[]{tregistrypiva.Columns["idreg"], tregistrypiva.Columns["idregistrypiva"]};


	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new DataTable("accmotiveapplied_debit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	Tables.Add(taccmotiveapplied_debit);

	//////////////////// ACCMOTIVEAPPLIED_CREDIT /////////////////////////////////
	var taccmotiveapplied_credit= new DataTable("accmotiveapplied_credit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	Tables.Add(taccmotiveapplied_credit);

	//////////////////// REGISTRYDURC /////////////////////////////////
	var tregistrydurc= new DataTable("registrydurc");
	C= new DataColumn("idregistrydurc", typeof(int));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	tregistrydurc.Columns.Add( new DataColumn("iddurckind", typeof(short)));
	tregistrydurc.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("selfcertification", typeof(Byte[])));
	tregistrydurc.Columns.Add( new DataColumn("durccertification", typeof(Byte[])));
	tregistrydurc.Columns.Add( new DataColumn("doc", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("inpscode", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("inailcode", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("buildingcode", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("otherinsurancecode", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	tregistrydurc.Columns.Add( new DataColumn("!durckind", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrydurc.Columns.Add( new DataColumn("flagirregular", typeof(string)));
	Tables.Add(tregistrydurc);
	tregistrydurc.PrimaryKey =  new DataColumn[]{tregistrydurc.Columns["idregistrydurc"], tregistrydurc.Columns["idreg"]};


	//////////////////// DURCKIND /////////////////////////////////
	var tdurckind= new DataTable("durckind");
	C= new DataColumn("iddurckind", typeof(short));
	C.AllowDBNull=false;
	tdurckind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdurckind.Columns.Add(C);
	Tables.Add(tdurckind);
	tdurckind.PrimaryKey =  new DataColumn[]{tdurckind.Columns["iddurckind"]};


	//////////////////// REGISTRYCVATTACHMENT /////////////////////////////////
	var tregistrycvattachment= new DataTable("registrycvattachment");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrycvattachment.Columns.Add(C);
	C= new DataColumn("idregistrycvattachment", typeof(int));
	C.AllowDBNull=false;
	tregistrycvattachment.Columns.Add(C);
	tregistrycvattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrycvattachment.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrycvattachment.Columns.Add(C);
	tregistrycvattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrycvattachment.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrycvattachment.Columns.Add(C);
	tregistrycvattachment.Columns.Add( new DataColumn("referencedate", typeof(DateTime)));
	Tables.Add(tregistrycvattachment);
	tregistrycvattachment.PrimaryKey =  new DataColumn[]{tregistrycvattachment.Columns["idreg"], tregistrycvattachment.Columns["idregistrycvattachment"]};


	//////////////////// REGISTRYSPECIALCATEGORY770 /////////////////////////////////
	var tregistryspecialcategory770= new DataTable("registryspecialcategory770");
	C= new DataColumn("idregistryspecialcategory770", typeof(int));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	C= new DataColumn("idspecialcategory770", typeof(string));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	tregistryspecialcategory770.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tregistryspecialcategory770.Columns.Add(C);
	tregistryspecialcategory770.Columns.Add( new DataColumn("!specialcategory770", typeof(string)));
	Tables.Add(tregistryspecialcategory770);
	tregistryspecialcategory770.PrimaryKey =  new DataColumn[]{tregistryspecialcategory770.Columns["idregistryspecialcategory770"], tregistryspecialcategory770.Columns["idreg"]};


	//////////////////// SPECIALCATEGORY770 /////////////////////////////////
	var tspecialcategory770= new DataTable("specialcategory770");
	C= new DataColumn("idspecialcategory770", typeof(string));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tspecialcategory770.Columns.Add(C);
	Tables.Add(tspecialcategory770);

	//////////////////// DALIA_POSITION /////////////////////////////////
	var tdalia_position= new DataTable("dalia_position");
	C= new DataColumn("iddaliaposition", typeof(int));
	C.AllowDBNull=false;
	tdalia_position.Columns.Add(C);
	tdalia_position.Columns.Add( new DataColumn("codedaliaposition", typeof(string)));
	tdalia_position.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tdalia_position);
	tdalia_position.PrimaryKey =  new DataColumn[]{tdalia_position.Columns["iddaliaposition"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registryspecialcategory770.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registryspecialcategory770",cPar,cChild,false));

	cPar = new []{specialcategory770.Columns["idspecialcategory770"], specialcategory770.Columns["ayear"]};
	cChild = new []{registryspecialcategory770.Columns["idspecialcategory770"], registryspecialcategory770.Columns["ayear"]};
	Relations.Add(new DataRelation("FK_specialcategory770_registryspecialcategory770",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrycvattachment.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrycvattachment",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrydurc.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrydurc",cPar,cChild,false));

	cPar = new []{durckind.Columns["iddurckind"]};
	cChild = new []{registrydurc.Columns["iddurckind"]};
	Relations.Add(new DataRelation("FK_durckind_registrydurc",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypiva.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrypiva",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrycf.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrycf",cPar,cChild,false));

	cPar = new []{address.Columns["idaddress"]};
	cChild = new []{registryaddress.Columns["idaddresskind"]};
	Relations.Add(new DataRelation("addressregistryaddress",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{registryaddress.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityregistryaddress",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistryaddress",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{registryaddress.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nationregistryaddress",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{geo_city_agencyview.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewgeo_city_agencyview",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrytaxablestatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrytaxablestatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrypaymethod",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrysorting.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrysorting",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{registrysorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingview_registrysorting",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistryreference",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{registrylegalstatus.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_registrylegalstatus",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("positionregistrylegalstatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrylegalstatus",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("maritalstatusregistry",cPar,cChild,false));

	cPar = new []{category.Columns["idcategory"]};
	cChild = new []{registry.Columns["idcategory"]};
	Relations.Add(new DataRelation("categoryregistry",cPar,cChild,false));

	cPar = new []{centralizedcategory.Columns["idcentralizedcategory"]};
	cChild = new []{registry.Columns["idcentralizedcategory"]};
	Relations.Add(new DataRelation("centralizedcategoryregistry",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("titleregistry",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("residenceregistry",cPar,cChild,false));

	cPar = new []{registryclass.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("registryclassregistry",cPar,cChild,false));

	cPar = new []{geo_nazione_alias.Columns["idnation"]};
	cChild = new []{registry.Columns["idnation"]};
	Relations.Add(new DataRelation("geo_nazione_aliasregistry",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{registry.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityviewregistry",cPar,cChild,false));

	cPar = new []{registrykind.Columns["idregistrykind"]};
	cChild = new []{registry.Columns["idregistrykind"]};
	Relations.Add(new DataRelation("registrykindregistry",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivedebit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_debit_registry",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{registry.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_credit_registry",cPar,cChild,false));

	#endregion

}
}
}
