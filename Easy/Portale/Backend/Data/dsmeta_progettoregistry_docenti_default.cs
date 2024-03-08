
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoregistry_docenti_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoregistry_docenti_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoregistry_docenti 		=> (MetaTable)Tables["progettoregistry_docenti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoregistry_docenti_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoregistry_docenti_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoregistry_docenti_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoregistry_docenti_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("classconsorsuale_title", typeof(string));
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("fonteindicebibliometrico_title", typeof(string));
	tregistrydocentiview.defineColumn("geo_city_title", typeof(string));
	tregistrydocentiview.defineColumn("geo_nation_title", typeof(string));
	tregistrydocentiview.defineColumn("idcity", typeof(int));
	tregistrydocentiview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrydocentiview.defineColumn("idnation", typeof(int));
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("idreg_istituti", typeof(int));
	tregistrydocentiview.defineColumn("idsasd", typeof(int));
	tregistrydocentiview.defineColumn("idstruttura", typeof(int));
	tregistrydocentiview.defineColumn("maritalstatus_description", typeof(string));
	tregistrydocentiview.defineColumn("registry_active", typeof(string));
	tregistrydocentiview.defineColumn("registry_annotation", typeof(string));
	tregistrydocentiview.defineColumn("registry_authorization_free", typeof(string));
	tregistrydocentiview.defineColumn("registry_badgecode", typeof(string));
	tregistrydocentiview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrydocentiview.defineColumn("registry_ccp", typeof(string));
	tregistrydocentiview.defineColumn("registry_cf", typeof(string));
	tregistrydocentiview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_cu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_docenti_ct", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_docenti_cu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_docenti_cv", typeof(string));
	tregistrydocentiview.defineColumn("registry_docenti_idcontrattokind", typeof(int));
	tregistrydocentiview.defineColumn("registry_docenti_idfonteindicebibliometrico", typeof(int));
	tregistrydocentiview.defineColumn("registry_docenti_idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_docenti_indicebibliometrico", typeof(int));
	tregistrydocentiview.defineColumn("registry_docenti_lt", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_docenti_lu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_docenti_matricola", typeof(string));
	tregistrydocentiview.defineColumn("registry_docenti_ricevimento", typeof(string));
	tregistrydocentiview.defineColumn("registry_docenti_soggiorno", typeof(string));
	tregistrydocentiview.defineColumn("registry_email_fe", typeof(string));
	tregistrydocentiview.defineColumn("registry_extension", typeof(string));
	tregistrydocentiview.defineColumn("registry_extmatricula", typeof(string));
	tregistrydocentiview.defineColumn("registry_flag_pa", typeof(string));
	tregistrydocentiview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrydocentiview.defineColumn("registry_foreigncf", typeof(string));
	tregistrydocentiview.defineColumn("registry_forename", typeof(string));
	tregistrydocentiview.defineColumn("registry_gender", typeof(string));
	tregistrydocentiview.defineColumn("registry_idaccmotivecredit", typeof(string));
	tregistrydocentiview.defineColumn("registry_idaccmotivedebit", typeof(string));
	tregistrydocentiview.defineColumn("registry_idcategory", typeof(string));
	tregistrydocentiview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistrydocentiview.defineColumn("registry_idexternal", typeof(int));
	tregistrydocentiview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrydocentiview.defineColumn("registry_idregistryclass", typeof(string));
	tregistrydocentiview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrydocentiview.defineColumn("registry_idtitle", typeof(string));
	tregistrydocentiview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrydocentiview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrydocentiview.defineColumn("registry_location", typeof(string));
	tregistrydocentiview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrydocentiview.defineColumn("registry_lu", typeof(string),false);
	tregistrydocentiview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrydocentiview.defineColumn("registry_multi_cf", typeof(string));
	tregistrydocentiview.defineColumn("registry_p_iva", typeof(string));
	tregistrydocentiview.defineColumn("registry_pec_fe", typeof(string));
	tregistrydocentiview.defineColumn("registry_residence", typeof(int),false);
	tregistrydocentiview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrydocentiview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrydocentiview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrydocentiview.defineColumn("registry_surname", typeof(string));
	tregistrydocentiview.defineColumn("registry_toredirect", typeof(int));
	tregistrydocentiview.defineColumn("registry_txt", typeof(string));
	tregistrydocentiview.defineColumn("registryclass_description", typeof(string));
	tregistrydocentiview.defineColumn("registryistituti_title", typeof(string));
	tregistrydocentiview.defineColumn("residence_description", typeof(string));
	tregistrydocentiview.defineColumn("sasd_codice", typeof(string));
	tregistrydocentiview.defineColumn("sasd_title", typeof(string));
	tregistrydocentiview.defineColumn("struttura_idstrutturakind", typeof(int));
	tregistrydocentiview.defineColumn("struttura_title", typeof(string));
	tregistrydocentiview.defineColumn("strutturakind_title", typeof(string));
	tregistrydocentiview.defineColumn("title", typeof(string),false);
	tregistrydocentiview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// PROGETTOREGISTRY_DOCENTI /////////////////////////////////
	var tprogettoregistry_docenti= new MetaTable("progettoregistry_docenti");
	tprogettoregistry_docenti.defineColumn("ct", typeof(DateTime));
	tprogettoregistry_docenti.defineColumn("cu", typeof(string));
	tprogettoregistry_docenti.defineColumn("idprogetto", typeof(int),false);
	tprogettoregistry_docenti.defineColumn("idreg_docenti", typeof(int),false);
	tprogettoregistry_docenti.defineColumn("lt", typeof(DateTime));
	tprogettoregistry_docenti.defineColumn("lu", typeof(string));
	Tables.Add(tprogettoregistry_docenti);
	tprogettoregistry_docenti.defineKey("idprogetto", "idreg_docenti");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydocentiview.Columns["idreg"]};
	var cChild = new []{progettoregistry_docenti.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_progettoregistry_docenti_registrydocentiview_idreg_docenti",cPar,cChild,false));

	#endregion

}
}
}
