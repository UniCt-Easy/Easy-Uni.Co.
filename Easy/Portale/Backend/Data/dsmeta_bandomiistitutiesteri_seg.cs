
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
[System.Xml.Serialization.XmlRoot("dsmeta_bandomiistitutiesteri_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_bandomiistitutiesteri_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryistitutiesteriview 		=> (MetaTable)Tables["registryistitutiesteriview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomiistitutiesteri 		=> (MetaTable)Tables["bandomiistitutiesteri"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_bandomiistitutiesteri_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_bandomiistitutiesteri_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_bandomiistitutiesteri_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_bandomiistitutiesteri_seg.xsd";

	#region create DataTables
	//////////////////// REGISTRYISTITUTIESTERIVIEW /////////////////////////////////
	var tregistryistitutiesteriview= new MetaTable("registryistitutiesteriview");
	tregistryistitutiesteriview.defineColumn("dropdown_title", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("geo_city_title", typeof(string));
	tregistryistitutiesteriview.defineColumn("geo_nation_title", typeof(string));
	tregistryistitutiesteriview.defineColumn("idcity", typeof(int));
	tregistryistitutiesteriview.defineColumn("idnace", typeof(string));
	tregistryistitutiesteriview.defineColumn("idnation", typeof(int));
	tregistryistitutiesteriview.defineColumn("idreg", typeof(int),false);
	tregistryistitutiesteriview.defineColumn("nace_activity", typeof(string));
	tregistryistitutiesteriview.defineColumn("nace_idnace", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_active", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_annotation", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_authorization_free", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_badgecode", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistryistitutiesteriview.defineColumn("registry_ccp", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_cf", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistryistitutiesteriview.defineColumn("registry_cu", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("registry_email_fe", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_extension", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_extmatricula", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_flag_pa", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_foreigncf", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_forename", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_gender", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_idcategory", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_idexternal", typeof(int));
	tregistryistitutiesteriview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_idregistryclass", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_idregistrykind", typeof(int));
	tregistryistitutiesteriview.defineColumn("registry_idtitle", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_ipa_fe", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_city", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_code", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_ct", typeof(DateTime),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_cu", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_idreg", typeof(int),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_institutionalcode", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_lt", typeof(DateTime),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_lu", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_name", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("registry_istitutiesteri_referencenumber", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_location", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistryistitutiesteriview.defineColumn("registry_lu", typeof(string),false);
	tregistryistitutiesteriview.defineColumn("registry_maritalsurname", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_multi_cf", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_p_iva", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_pec_fe", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistryistitutiesteriview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_surname", typeof(string));
	tregistryistitutiesteriview.defineColumn("registry_toredirect", typeof(int));
	tregistryistitutiesteriview.defineColumn("registry_txt", typeof(string));
	tregistryistitutiesteriview.defineColumn("residence", typeof(int),false);
	tregistryistitutiesteriview.defineColumn("residence_description", typeof(string));
	tregistryistitutiesteriview.defineColumn("title", typeof(string),false);
	Tables.Add(tregistryistitutiesteriview);
	tregistryistitutiesteriview.defineKey("idreg");

	//////////////////// BANDOMIISTITUTIESTERI /////////////////////////////////
	var tbandomiistitutiesteri= new MetaTable("bandomiistitutiesteri");
	tbandomiistitutiesteri.defineColumn("ct", typeof(DateTime),false);
	tbandomiistitutiesteri.defineColumn("cu", typeof(string),false);
	tbandomiistitutiesteri.defineColumn("idbandomi", typeof(int),false);
	tbandomiistitutiesteri.defineColumn("idreg_istitutiesteri", typeof(int),false);
	tbandomiistitutiesteri.defineColumn("lt", typeof(DateTime),false);
	tbandomiistitutiesteri.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandomiistitutiesteri);
	tbandomiistitutiesteri.defineKey("idbandomi", "idreg_istitutiesteri");

	#endregion


	#region DataRelation creation
	var cPar = new []{registryistitutiesteriview.Columns["idreg"]};
	var cChild = new []{bandomiistitutiesteri.Columns["idreg_istitutiesteri"]};
	Relations.Add(new DataRelation("FK_bandomiistitutiesteri_registryistitutiesteriview_idreg_istitutiesteri",cPar,cChild,false));

	#endregion

}
}
}
