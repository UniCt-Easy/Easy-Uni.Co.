
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
[System.Xml.Serialization.XmlRoot("dsmeta_strutturaresponsabile_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_strutturaresponsabile_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolo 		=> (MetaTable)Tables["perfruolo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaresponsabile 		=> (MetaTable)Tables["strutturaresponsabile"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_strutturaresponsabile_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_strutturaresponsabile_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_strutturaresponsabile_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_strutturaresponsabile_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("accmotive_codemotive", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_registry_codemotive", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_registry_title", typeof(string));
	tregistrydefaultview.defineColumn("accmotive_title", typeof(string));
	tregistrydefaultview.defineColumn("category_description", typeof(string));
	tregistrydefaultview.defineColumn("centralizedcategory_description", typeof(string));
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("geo_city_title", typeof(string));
	tregistrydefaultview.defineColumn("geo_nation_title", typeof(string));
	tregistrydefaultview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrydefaultview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrydefaultview.defineColumn("idcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrydefaultview.defineColumn("idcity", typeof(int));
	tregistrydefaultview.defineColumn("idnation", typeof(int));
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("idregistryclass", typeof(string));
	tregistrydefaultview.defineColumn("idtitle", typeof(string));
	tregistrydefaultview.defineColumn("maritalstatus_description", typeof(string));
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	tregistrydefaultview.defineColumn("registry_annotation", typeof(string));
	tregistrydefaultview.defineColumn("registry_authorization_free", typeof(string));
	tregistrydefaultview.defineColumn("registry_badgecode", typeof(string));
	tregistrydefaultview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistrydefaultview.defineColumn("registry_ccp", typeof(string));
	tregistrydefaultview.defineColumn("registry_cf", typeof(string));
	tregistrydefaultview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistrydefaultview.defineColumn("registry_cu", typeof(string),false);
	tregistrydefaultview.defineColumn("registry_email_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_extension", typeof(string));
	tregistrydefaultview.defineColumn("registry_extmatricula", typeof(string));
	tregistrydefaultview.defineColumn("registry_flag_pa", typeof(string));
	tregistrydefaultview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistrydefaultview.defineColumn("registry_foreigncf", typeof(string));
	tregistrydefaultview.defineColumn("registry_forename", typeof(string));
	tregistrydefaultview.defineColumn("registry_gender", typeof(string));
	tregistrydefaultview.defineColumn("registry_idexternal", typeof(int));
	tregistrydefaultview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistrydefaultview.defineColumn("registry_idregistrykind", typeof(int));
	tregistrydefaultview.defineColumn("registry_ipa_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistrydefaultview.defineColumn("registry_location", typeof(string));
	tregistrydefaultview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistrydefaultview.defineColumn("registry_lu", typeof(string),false);
	tregistrydefaultview.defineColumn("registry_maritalsurname", typeof(string));
	tregistrydefaultview.defineColumn("registry_multi_cf", typeof(string));
	tregistrydefaultview.defineColumn("registry_p_iva", typeof(string));
	tregistrydefaultview.defineColumn("registry_pec_fe", typeof(string));
	tregistrydefaultview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistrydefaultview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistrydefaultview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistrydefaultview.defineColumn("registry_surname", typeof(string));
	tregistrydefaultview.defineColumn("registry_toredirect", typeof(int));
	tregistrydefaultview.defineColumn("registry_txt", typeof(string));
	tregistrydefaultview.defineColumn("registryclass_description", typeof(string));
	tregistrydefaultview.defineColumn("registrykind_description", typeof(string));
	tregistrydefaultview.defineColumn("residence", typeof(int),false);
	tregistrydefaultview.defineColumn("residence_description", typeof(string));
	tregistrydefaultview.defineColumn("title", typeof(string),false);
	tregistrydefaultview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// PERFRUOLO /////////////////////////////////
	var tperfruolo= new MetaTable("perfruolo");
	tperfruolo.defineColumn("idperfruolo", typeof(string),false);
	Tables.Add(tperfruolo);
	tperfruolo.defineKey("idperfruolo");

	//////////////////// STRUTTURARESPONSABILE /////////////////////////////////
	var tstrutturaresponsabile= new MetaTable("strutturaresponsabile");
	tstrutturaresponsabile.defineColumn("idperfruolo", typeof(string));
	tstrutturaresponsabile.defineColumn("idreg", typeof(int));
	tstrutturaresponsabile.defineColumn("idstruttura", typeof(int),false);
	tstrutturaresponsabile.defineColumn("idstrutturaresponsabile", typeof(int),false);
	tstrutturaresponsabile.defineColumn("start", typeof(DateTime));
	tstrutturaresponsabile.defineColumn("stop", typeof(DateTime));
	Tables.Add(tstrutturaresponsabile);
	tstrutturaresponsabile.defineKey("idstruttura", "idstrutturaresponsabile");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydefaultview.Columns["idreg"]};
	var cChild = new []{strutturaresponsabile.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_strutturaresponsabile_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{strutturaresponsabile.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_strutturaresponsabile_perfruolo_idperfruolo",cPar,cChild,false));

	#endregion

}
}
}
