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
[System.Xml.Serialization.XmlRoot("dsmeta_decadenza_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_decadenza_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable decadenza 		=> (MetaTable)Tables["decadenza"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_decadenza_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_decadenza_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_decadenza_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_decadenza_seg.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("geo_city_title", typeof(string));
	tregistrystudentiview.defineColumn("geo_nation_title", typeof(string));
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("maritalstatus_description", typeof(string));
	tregistrystudentiview.defineColumn("registry_acronim", typeof(string));
	tregistrystudentiview.defineColumn("registry_active", typeof(string));
	tregistrystudentiview.defineColumn("registry_annotation", typeof(string));
	tregistrystudentiview.defineColumn("registry_authorization_free", typeof(string));
	tregistrystudentiview.defineColumn("registry_badgecode", typeof(string));
	tregistrystudentiview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrystudentiview.defineColumn("registry_ccp", typeof(string));
	tregistrystudentiview.defineColumn("registry_cf", typeof(string));
	tregistrystudentiview.defineColumn("registry_code", typeof(string));
	tregistrystudentiview.defineColumn("registry_codicemiur", typeof(string));
	tregistrystudentiview.defineColumn("registry_codiceustat", typeof(string));
	tregistrystudentiview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrystudentiview.defineColumn("registry_cu", typeof(string),false);
	tregistrystudentiview.defineColumn("registry_email_fe", typeof(string));
	tregistrystudentiview.defineColumn("registry_extension", typeof(string));
	tregistrystudentiview.defineColumn("registry_extmatricula", typeof(string));
	tregistrystudentiview.defineColumn("registry_flag_pa", typeof(string));
	tregistrystudentiview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrystudentiview.defineColumn("registry_foreigncf", typeof(string));
	tregistrystudentiview.defineColumn("registry_forename", typeof(string));
	tregistrystudentiview.defineColumn("registry_gender", typeof(string));
	tregistrystudentiview.defineColumn("registry_idaccmotivecredit", typeof(string));
	tregistrystudentiview.defineColumn("registry_idaccmotivedebit", typeof(string));
	tregistrystudentiview.defineColumn("registry_idanpr", typeof(string));
	tregistrystudentiview.defineColumn("registry_idateco", typeof(int));
	tregistrystudentiview.defineColumn("registry_idcategory", typeof(string));
	tregistrystudentiview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistrystudentiview.defineColumn("registry_idexternal", typeof(int));
	tregistrystudentiview.defineColumn("registry_idfonteindicebibliometrico", typeof(int));
	tregistrystudentiview.defineColumn("registry_idistitutokind", typeof(int));
	tregistrystudentiview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrystudentiview.defineColumn("registry_idnace", typeof(string));
	tregistrystudentiview.defineColumn("registry_idnaturagiur", typeof(int));
	tregistrystudentiview.defineColumn("registry_idnumerodip", typeof(int));
	tregistrystudentiview.defineColumn("registry_idreg_istituti", typeof(int));
	tregistrystudentiview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrystudentiview.defineColumn("registry_idsasd", typeof(int));
	tregistrystudentiview.defineColumn("registry_idstruttura", typeof(int));
	tregistrystudentiview.defineColumn("registry_indicebibliometrico", typeof(int));
	tregistrystudentiview.defineColumn("registry_institutionalcode", typeof(string));
	tregistrystudentiview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrystudentiview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrystudentiview.defineColumn("registry_location", typeof(string));
	tregistrystudentiview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrystudentiview.defineColumn("registry_lu", typeof(string),false);
	tregistrystudentiview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrystudentiview.defineColumn("registry_multi_cf", typeof(string));
	tregistrystudentiview.defineColumn("registry_p_iva", typeof(string));
	tregistrystudentiview.defineColumn("registry_pec_fe", typeof(string));
	tregistrystudentiview.defineColumn("registry_pic", typeof(string));
	tregistrystudentiview.defineColumn("registry_referencenumber", typeof(string));
	tregistrystudentiview.defineColumn("registry_ricevimento", typeof(string));
	tregistrystudentiview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrystudentiview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrystudentiview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrystudentiview.defineColumn("registry_soggiorno", typeof(string));
	tregistrystudentiview.defineColumn("registry_surname", typeof(string));
	tregistrystudentiview.defineColumn("registry_title_en", typeof(string));
	tregistrystudentiview.defineColumn("registry_toredirect", typeof(int));
	tregistrystudentiview.defineColumn("registry_txt", typeof(string));
	tregistrystudentiview.defineColumn("registryclass_description", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	tregistrystudentiview.defineColumn("residence_description", typeof(string));
	tregistrystudentiview.defineColumn("title", typeof(string),false);
	tregistrystudentiview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// DECADENZA /////////////////////////////////
	var tdecadenza= new MetaTable("decadenza");
	tdecadenza.defineColumn("aa", typeof(string),false);
	tdecadenza.defineColumn("ct", typeof(DateTime),false);
	tdecadenza.defineColumn("cu", typeof(string),false);
	tdecadenza.defineColumn("data", typeof(DateTime),false);
	tdecadenza.defineColumn("iddecadenza", typeof(int),false);
	tdecadenza.defineColumn("idiscrizione", typeof(int),false);
	tdecadenza.defineColumn("idreg_studenti", typeof(int),false);
	tdecadenza.defineColumn("lt", typeof(DateTime),false);
	tdecadenza.defineColumn("lu", typeof(string),false);
	tdecadenza.defineColumn("protanno", typeof(int),false);
	tdecadenza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tdecadenza);
	tdecadenza.defineKey("iddecadenza", "idiscrizione", "idreg_studenti");

	#endregion


	#region DataRelation creation
	var cPar = new []{annoaccademico.Columns["aa"]};
	var cChild = new []{decadenza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_decadenza_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	cChild = new []{decadenza.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_decadenza_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{iscrizionedefaultview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_iscrizionedefaultview_registrystudentiview_idreg",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{decadenza.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_decadenza_registrystudentiview_idreg_studenti",cPar,cChild,false));

	#endregion

}
}
}
