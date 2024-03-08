
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_registry_anagrafica1"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registry_anagrafica1: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryaddress 		=> (MetaTable)Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryreference 		=> (MetaTable)Tables["registryreference"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclass 		=> (MetaTable)Tables["registryclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypaymethod 		=> (MetaTable)Tables["registrypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable title 		=> (MetaTable)Tables["title"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable residence 		=> (MetaTable)Tables["residence"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable maritalstatus 		=> (MetaTable)Tables["maritalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable timbratura 		=> (MetaTable)Tables["timbratura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoorario 		=> (MetaTable)Tables["costoorario"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registry_anagrafica1(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registry_anagrafica1 (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registry_anagrafica1";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registry_anagrafica1.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string));
	tregistry.defineColumn("gender", typeof(string));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("surname", typeof(string));
	tregistry.defineColumn("title", typeof(string));
	tregistry.defineColumn("txt", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new MetaTable("registryaddress");
	tregistryaddress.defineColumn("idreg", typeof(int),false);
	tregistryaddress.defineColumn("start", typeof(DateTime),false);
	tregistryaddress.defineColumn("active", typeof(string));
	tregistryaddress.defineColumn("address", typeof(string));
	tregistryaddress.defineColumn("annotations", typeof(string));
	tregistryaddress.defineColumn("cap", typeof(string));
	tregistryaddress.defineColumn("ct", typeof(DateTime));
	tregistryaddress.defineColumn("cu", typeof(string));
	tregistryaddress.defineColumn("flagforeign", typeof(string));
	tregistryaddress.defineColumn("idcity", typeof(int));
	tregistryaddress.defineColumn("idnation", typeof(int));
	tregistryaddress.defineColumn("location", typeof(string));
	tregistryaddress.defineColumn("lt", typeof(DateTime));
	tregistryaddress.defineColumn("lu", typeof(string));
	tregistryaddress.defineColumn("officename", typeof(string));
	tregistryaddress.defineColumn("stop", typeof(DateTime));
	tregistryaddress.defineColumn("idaddresskind", typeof(int),false);
	tregistryaddress.defineColumn("recipientagency", typeof(string));
	Tables.Add(tregistryaddress);
	tregistryaddress.defineKey("idreg", "start", "idaddresskind");

	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new MetaTable("registryreference");
	tregistryreference.defineColumn("idreg", typeof(int),false);
	tregistryreference.defineColumn("idregistryreference", typeof(int),false);
	tregistryreference.defineColumn("ct", typeof(DateTime),false);
	tregistryreference.defineColumn("cu", typeof(string),false);
	tregistryreference.defineColumn("email", typeof(string));
	tregistryreference.defineColumn("faxnumber", typeof(string));
	tregistryreference.defineColumn("flagdefault", typeof(string));
	tregistryreference.defineColumn("lt", typeof(DateTime),false);
	tregistryreference.defineColumn("lu", typeof(string),false);
	tregistryreference.defineColumn("mobilenumber", typeof(string));
	tregistryreference.defineColumn("msnnumber", typeof(string));
	tregistryreference.defineColumn("phonenumber", typeof(string));
	tregistryreference.defineColumn("referencename", typeof(string),false);
	tregistryreference.defineColumn("registryreferencerole", typeof(string));
	tregistryreference.defineColumn("rtf", typeof(Byte[]));
	tregistryreference.defineColumn("skypenumber", typeof(string));
	tregistryreference.defineColumn("txt", typeof(string));
	tregistryreference.defineColumn("userweb", typeof(string));
	tregistryreference.defineColumn("passwordweb", typeof(string));
	tregistryreference.defineColumn("saltweb", typeof(string));
	tregistryreference.defineColumn("iterweb", typeof(int));
	tregistryreference.defineColumn("activeweb", typeof(string));
	Tables.Add(tregistryreference);
	tregistryreference.defineKey("idreg", "idregistryreference");

	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new MetaTable("registryclass");
	tregistryclass.defineColumn("idregistryclass", typeof(string),false);
	tregistryclass.defineColumn("active", typeof(string));
	tregistryclass.defineColumn("ct", typeof(DateTime),false);
	tregistryclass.defineColumn("cu", typeof(string),false);
	tregistryclass.defineColumn("description", typeof(string),false);
	tregistryclass.defineColumn("flagbadgecode", typeof(string),false);
	tregistryclass.defineColumn("flagbadgecode_forced", typeof(string),false);
	tregistryclass.defineColumn("flagCF", typeof(string),false);
	tregistryclass.defineColumn("flagcf_forced", typeof(string),false);
	tregistryclass.defineColumn("flagcfbutton", typeof(string));
	tregistryclass.defineColumn("flagextmatricula", typeof(string),false);
	tregistryclass.defineColumn("flagextmatricula_forced", typeof(string),false);
	tregistryclass.defineColumn("flagfiscalresidence", typeof(string),false);
	tregistryclass.defineColumn("flagfiscalresidence_forced", typeof(string),false);
	tregistryclass.defineColumn("flagforeigncf", typeof(string),false);
	tregistryclass.defineColumn("flagforeigncf_forced", typeof(string),false);
	tregistryclass.defineColumn("flaghuman", typeof(string));
	tregistryclass.defineColumn("flaginfofromcfbutton", typeof(string));
	tregistryclass.defineColumn("flagmaritalstatus", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalstatus_forced", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalsurname", typeof(string),false);
	tregistryclass.defineColumn("flagmaritalsurname_forced", typeof(string),false);
	tregistryclass.defineColumn("flagothers", typeof(string),false);
	tregistryclass.defineColumn("flagothers_forced", typeof(string),false);
	tregistryclass.defineColumn("flagp_iva", typeof(string),false);
	tregistryclass.defineColumn("flagp_iva_forced", typeof(string),false);
	tregistryclass.defineColumn("flagqualification", typeof(string),false);
	tregistryclass.defineColumn("flagqualification_forced", typeof(string),false);
	tregistryclass.defineColumn("flagresidence", typeof(string),false);
	tregistryclass.defineColumn("flagresidence_forced", typeof(string),false);
	tregistryclass.defineColumn("flagtitle", typeof(string),false);
	tregistryclass.defineColumn("flagtitle_forced", typeof(string),false);
	tregistryclass.defineColumn("lt", typeof(DateTime),false);
	tregistryclass.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new MetaTable("registrypaymethod");
	tregistrypaymethod.defineColumn("idreg", typeof(int),false);
	tregistrypaymethod.defineColumn("idregistrypaymethod", typeof(int),false);
	tregistrypaymethod.defineColumn("regmodcode", typeof(string),false);
	tregistrypaymethod.defineColumn("active", typeof(string));
	tregistrypaymethod.defineColumn("cc", typeof(string));
	tregistrypaymethod.defineColumn("cin", typeof(string));
	tregistrypaymethod.defineColumn("ct", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("cu", typeof(string),false);
	tregistrypaymethod.defineColumn("flagstandard", typeof(string));
	tregistrypaymethod.defineColumn("iban", typeof(string));
	tregistrypaymethod.defineColumn("idbank", typeof(string));
	tregistrypaymethod.defineColumn("idcab", typeof(string));
	tregistrypaymethod.defineColumn("iddeputy", typeof(int));
	tregistrypaymethod.defineColumn("lt", typeof(DateTime),false);
	tregistrypaymethod.defineColumn("lu", typeof(string),false);
	tregistrypaymethod.defineColumn("paymentdescr", typeof(string));
	tregistrypaymethod.defineColumn("paymentexpiring", typeof(short));
	tregistrypaymethod.defineColumn("rtf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("txt", typeof(string));
	tregistrypaymethod.defineColumn("refexternaldoc", typeof(string));
	tregistrypaymethod.defineColumn("idcurrency", typeof(int));
	tregistrypaymethod.defineColumn("idpaymethod", typeof(int));
	tregistrypaymethod.defineColumn("idexpirationkind", typeof(short));
	tregistrypaymethod.defineColumn("extracode", typeof(string));
	tregistrypaymethod.defineColumn("biccode", typeof(string));
	tregistrypaymethod.defineColumn("flag", typeof(int));
	tregistrypaymethod.defineColumn("idchargehandling", typeof(int));
	tregistrypaymethod.defineColumn("notes", typeof(string));
	tregistrypaymethod.defineColumn("ccdedicato_doc", typeof(Byte[]));
	tregistrypaymethod.defineColumn("ccdedicato_cf", typeof(Byte[]));
	tregistrypaymethod.defineColumn("requested_doc", typeof(int));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.defineKey("idreg", "idregistrypaymethod");

	//////////////////// TITLE /////////////////////////////////
	var ttitle= new MetaTable("title");
	ttitle.defineColumn("idtitle", typeof(string),false);
	ttitle.defineColumn("active", typeof(string));
	ttitle.defineColumn("ct", typeof(DateTime),false);
	ttitle.defineColumn("cu", typeof(string),false);
	ttitle.defineColumn("description", typeof(string),false);
	ttitle.defineColumn("lt", typeof(DateTime),false);
	ttitle.defineColumn("lu", typeof(string),false);
	Tables.Add(ttitle);
	ttitle.defineKey("idtitle");

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

	//////////////////// MARITALSTATUS /////////////////////////////////
	var tmaritalstatus= new MetaTable("maritalstatus");
	tmaritalstatus.defineColumn("idmaritalstatus", typeof(string),false);
	tmaritalstatus.defineColumn("active", typeof(string));
	tmaritalstatus.defineColumn("ct", typeof(DateTime),false);
	tmaritalstatus.defineColumn("cu", typeof(string),false);
	tmaritalstatus.defineColumn("description", typeof(string),false);
	tmaritalstatus.defineColumn("lt", typeof(DateTime),false);
	tmaritalstatus.defineColumn("lu", typeof(string),false);
	Tables.Add(tmaritalstatus);
	tmaritalstatus.defineKey("idmaritalstatus");

	//////////////////// TIMBRATURA /////////////////////////////////
	var ttimbratura= new MetaTable("timbratura");
	ttimbratura.defineColumn("idtimbratura", typeof(int),false);
	ttimbratura.defineColumn("idreg", typeof(int),false);
	ttimbratura.defineColumn("data", typeof(DateTime));
	ttimbratura.defineColumn("minuti", typeof(int));
	ttimbratura.defineColumn("convalida", typeof(string));
	ttimbratura.defineColumn("ct", typeof(DateTime),false);
	ttimbratura.defineColumn("cu", typeof(string),false);
	ttimbratura.defineColumn("lt", typeof(DateTime),false);
	ttimbratura.defineColumn("lu", typeof(string),false);
	Tables.Add(ttimbratura);
	ttimbratura.defineKey("idtimbratura", "idreg");

	//////////////////// COSTOORARIO /////////////////////////////////
	var tcostoorario= new MetaTable("costoorario");
	tcostoorario.defineColumn("idcostoorario", typeof(int),false);
	tcostoorario.defineColumn("idreg", typeof(int),false);
	tcostoorario.defineColumn("start", typeof(DateTime));
	tcostoorario.defineColumn("stop", typeof(DateTime));
	tcostoorario.defineColumn("netto", typeof(decimal));
	tcostoorario.defineColumn("oneri", typeof(decimal));
	tcostoorario.defineColumn("irap", typeof(decimal));
	tcostoorario.defineColumn("totale", typeof(decimal));
	tcostoorario.defineColumn("ct", typeof(DateTime),false);
	tcostoorario.defineColumn("cu", typeof(string),false);
	tcostoorario.defineColumn("lt", typeof(DateTime),false);
	tcostoorario.defineColumn("lu", typeof(string),false);
	Tables.Add(tcostoorario);
	tcostoorario.defineKey("idcostoorario", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registryreference.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryreference_registry",cPar,cChild,false));

	cPar = new []{registryclass.Columns["idregistryclass"]};
	cChild = new []{registry.Columns["idregistryclass"]};
	Relations.Add(new DataRelation("registryclassregistry",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrypaymethod",cPar,cChild,false));

	cPar = new []{title.Columns["idtitle"]};
	cChild = new []{registry.Columns["idtitle"]};
	Relations.Add(new DataRelation("title_registry",cPar,cChild,false));

	cPar = new []{residence.Columns["idresidence"]};
	cChild = new []{registry.Columns["residence"]};
	Relations.Add(new DataRelation("residenceregistry",cPar,cChild,false));

	cPar = new []{maritalstatus.Columns["idmaritalstatus"]};
	cChild = new []{registry.Columns["idmaritalstatus"]};
	Relations.Add(new DataRelation("maritalstatus_registry",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{timbratura.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_timbratura",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{costoorario.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_costoorario",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registryaddress_registry",cPar,cChild,false));

	#endregion

}
}
}
