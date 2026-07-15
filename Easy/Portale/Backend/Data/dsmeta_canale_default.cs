/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_canale_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_canale_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canaleregistry 		=> (MetaTable)Tables["canaleregistry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable canale 		=> (MetaTable)Tables["canale"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_canale_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_canale_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_canale_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_canale_default.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("acronim", typeof(string));
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("annotation", typeof(string));
	tregistry.defineColumn("authorization_free", typeof(string));
	tregistry.defineColumn("badgecode", typeof(string));
	tregistry.defineColumn("birthdate", typeof(DateTime),false);
	tregistry.defineColumn("ccp", typeof(string));
	tregistry.defineColumn("cf", typeof(string));
	tregistry.defineColumn("code", typeof(string));
	tregistry.defineColumn("codicemiur", typeof(string));
	tregistry.defineColumn("codiceustat", typeof(string));
	tregistry.defineColumn("ct", typeof(DateTime),false);
	tregistry.defineColumn("cu", typeof(string),false);
	tregistry.defineColumn("email_fe", typeof(string));
	tregistry.defineColumn("extension", typeof(string));
	tregistry.defineColumn("extmatricula", typeof(string));
	tregistry.defineColumn("flag_pa", typeof(string));
	tregistry.defineColumn("flagbankitaliaproceeds", typeof(string));
	tregistry.defineColumn("foreigncf", typeof(string));
	tregistry.defineColumn("forename", typeof(string),false);
	tregistry.defineColumn("gender", typeof(string),false);
	tregistry.defineColumn("idaccmotivecredit", typeof(string));
	tregistry.defineColumn("idaccmotivedebit", typeof(string));
	tregistry.defineColumn("idanpr", typeof(string));
	tregistry.defineColumn("idateco", typeof(int));
	tregistry.defineColumn("idcategory", typeof(string));
	tregistry.defineColumn("idcentralizedcategory", typeof(string));
	tregistry.defineColumn("idcity", typeof(int));
	tregistry.defineColumn("idexternal", typeof(int));
	tregistry.defineColumn("idfonteindicebibliometrico", typeof(int));
	tregistry.defineColumn("idistitutokind", typeof(int));
	tregistry.defineColumn("idmaritalstatus", typeof(string));
	tregistry.defineColumn("idnace", typeof(string));
	tregistry.defineColumn("idnation", typeof(int));
	tregistry.defineColumn("idnaturagiur", typeof(int));
	tregistry.defineColumn("idnumerodip", typeof(int));
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("idreg_istituti", typeof(int));
	tregistry.defineColumn("idregistryclass", typeof(string));
	tregistry.defineColumn("idregistrykind", typeof(int));
	tregistry.defineColumn("idsasd", typeof(int));
	tregistry.defineColumn("idstruttura", typeof(int));
	tregistry.defineColumn("idtitle", typeof(string));
	tregistry.defineColumn("indicebibliometrico", typeof(int));
	tregistry.defineColumn("institutionalcode", typeof(string));
	tregistry.defineColumn("ipa_fe", typeof(string));
	tregistry.defineColumn("ipa_perlapa", typeof(string));
	tregistry.defineColumn("location", typeof(string));
	tregistry.defineColumn("lt", typeof(DateTime),false);
	tregistry.defineColumn("lu", typeof(string),false);
	tregistry.defineColumn("maritalsurname", typeof(string));
	tregistry.defineColumn("multi_cf", typeof(string));
	tregistry.defineColumn("p_iva", typeof(string));
	tregistry.defineColumn("pec_fe", typeof(string));
	tregistry.defineColumn("pic", typeof(string));
	tregistry.defineColumn("referencenumber", typeof(string));
	tregistry.defineColumn("residence", typeof(int),false);
	tregistry.defineColumn("ricevimento", typeof(string));
	tregistry.defineColumn("rtf", typeof(Byte[]));
	tregistry.defineColumn("sdi_defrifamm", typeof(string));
	tregistry.defineColumn("sdi_norifamm", typeof(string));
	tregistry.defineColumn("soggiorno", typeof(string));
	tregistry.defineColumn("surname", typeof(string),false);
	tregistry.defineColumn("title", typeof(string),false);
	tregistry.defineColumn("title_en", typeof(string));
	tregistry.defineColumn("toredirect", typeof(int));
	tregistry.defineColumn("txt", typeof(string));
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// CANALEREGISTRY /////////////////////////////////
	var tcanaleregistry= new MetaTable("canaleregistry");
	tcanaleregistry.defineColumn("ct", typeof(DateTime),false);
	tcanaleregistry.defineColumn("cu", typeof(string),false);
	tcanaleregistry.defineColumn("idcanale", typeof(int),false);
	tcanaleregistry.defineColumn("idreg", typeof(int),false);
	tcanaleregistry.defineColumn("lt", typeof(DateTime),false);
	tcanaleregistry.defineColumn("lu", typeof(string),false);
	tcanaleregistry.defineColumn("!idreg_registry_surname", typeof(string));
	tcanaleregistry.defineColumn("!idreg_registry_forename", typeof(string));
	tcanaleregistry.defineColumn("!idreg_registry_cf", typeof(string));
	tcanaleregistry.defineColumn("!idreg_registry_extmatricula", typeof(string));
	tcanaleregistry.defineColumn("!idreg_registry_active", typeof(string));
	tcanaleregistry.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tcanaleregistry);
	tcanaleregistry.defineKey("idcanale", "idreg");

	//////////////////// CANALE /////////////////////////////////
	var tcanale= new MetaTable("canale");
	tcanale.defineColumn("!filtrostud", typeof(string));
	tcanale.defineColumn("aa", typeof(string),false);
	tcanale.defineColumn("ct", typeof(DateTime),false);
	tcanale.defineColumn("cu", typeof(string),false);
	tcanale.defineColumn("CUIN", typeof(string));
	tcanale.defineColumn("idattivform", typeof(int),false);
	tcanale.defineColumn("idcanale", typeof(int),false);
	tcanale.defineColumn("idcorsostudio", typeof(int),false);
	tcanale.defineColumn("iddidprog", typeof(int),false);
	tcanale.defineColumn("iddidproganno", typeof(int),false);
	tcanale.defineColumn("iddidprogcurr", typeof(int),false);
	tcanale.defineColumn("iddidprogori", typeof(int),false);
	tcanale.defineColumn("iddidprogporzanno", typeof(int),false);
	tcanale.defineColumn("idsede", typeof(int),false);
	tcanale.defineColumn("lt", typeof(DateTime),false);
	tcanale.defineColumn("lu", typeof(string),false);
	tcanale.defineColumn("numerostud", typeof(int));
	tcanale.defineColumn("sortcode", typeof(int));
	tcanale.defineColumn("title", typeof(string));
	Tables.Add(tcanale);
	tcanale.defineKey("aa", "idattivform", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{canale.Columns["idcanale"]};
	var cChild = new []{canaleregistry.Columns["idcanale"]};
	Relations.Add(new DataRelation("FK_canaleregistry_canale_idcanale",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{canaleregistry.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_canaleregistry_registry_idreg",cPar,cChild,false));

	#endregion

}
}
}
