
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoregistry_amministrativi_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoregistry_amministrativi_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryamministrativiview 		=> (MetaTable)Tables["registryamministrativiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoregistry_amministrativi 		=> (MetaTable)Tables["progettoregistry_amministrativi"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoregistry_amministrativi_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoregistry_amministrativi_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoregistry_amministrativi_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoregistry_amministrativi_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYAMMINISTRATIVIVIEW /////////////////////////////////
	var tregistryamministrativiview= new MetaTable("registryamministrativiview");
	tregistryamministrativiview.defineColumn("category_description", typeof(string));
	tregistryamministrativiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryamministrativiview.defineColumn("geo_city_title", typeof(string));
	tregistryamministrativiview.defineColumn("geo_nation_title", typeof(string));
	tregistryamministrativiview.defineColumn("idcity", typeof(int));
	tregistryamministrativiview.defineColumn("idnation", typeof(int));
	tregistryamministrativiview.defineColumn("idreg", typeof(int),false);
	tregistryamministrativiview.defineColumn("idtitle", typeof(string));
	tregistryamministrativiview.defineColumn("maritalstatus_description", typeof(string));
	tregistryamministrativiview.defineColumn("registry_active", typeof(string));
	tregistryamministrativiview.defineColumn("registry_amministrativi_ct", typeof(DateTime));
	tregistryamministrativiview.defineColumn("registry_amministrativi_cu", typeof(string));
	tregistryamministrativiview.defineColumn("registry_amministrativi_cv", typeof(string));
	tregistryamministrativiview.defineColumn("registry_amministrativi_idcontrattokind", typeof(int));
	tregistryamministrativiview.defineColumn("registry_amministrativi_idreg", typeof(int),false);
	tregistryamministrativiview.defineColumn("registry_amministrativi_lt", typeof(DateTime));
	tregistryamministrativiview.defineColumn("registry_amministrativi_lu", typeof(string));
	tregistryamministrativiview.defineColumn("registry_annotation", typeof(string));
	tregistryamministrativiview.defineColumn("registry_authorization_free", typeof(string));
	tregistryamministrativiview.defineColumn("registry_badgecode", typeof(string));
	tregistryamministrativiview.defineColumn("registry_birthdate", typeof(DateTime));
	tregistryamministrativiview.defineColumn("registry_ccp", typeof(string));
	tregistryamministrativiview.defineColumn("registry_cf", typeof(string));
	tregistryamministrativiview.defineColumn("registry_ct", typeof(DateTime),false);
	tregistryamministrativiview.defineColumn("registry_cu", typeof(string),false);
	tregistryamministrativiview.defineColumn("registry_email_fe", typeof(string));
	tregistryamministrativiview.defineColumn("registry_extension", typeof(string));
	tregistryamministrativiview.defineColumn("registry_extmatricula", typeof(string));
	tregistryamministrativiview.defineColumn("registry_flag_pa", typeof(string));
	tregistryamministrativiview.defineColumn("registry_flagbankitaliaproceeds", typeof(string));
	tregistryamministrativiview.defineColumn("registry_foreigncf", typeof(string));
	tregistryamministrativiview.defineColumn("registry_forename", typeof(string));
	tregistryamministrativiview.defineColumn("registry_gender", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idaccmotivecredit", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idaccmotivedebit", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idcategory", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idcentralizedcategory", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idexternal", typeof(int));
	tregistryamministrativiview.defineColumn("registry_idmaritalstatus", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idregistryclass", typeof(string));
	tregistryamministrativiview.defineColumn("registry_idregistrykind", typeof(int));
	tregistryamministrativiview.defineColumn("registry_ipa_fe", typeof(string));
	tregistryamministrativiview.defineColumn("registry_ipa_perlapa", typeof(string));
	tregistryamministrativiview.defineColumn("registry_location", typeof(string));
	tregistryamministrativiview.defineColumn("registry_lt", typeof(DateTime),false);
	tregistryamministrativiview.defineColumn("registry_lu", typeof(string),false);
	tregistryamministrativiview.defineColumn("registry_maritalsurname", typeof(string));
	tregistryamministrativiview.defineColumn("registry_multi_cf", typeof(string));
	tregistryamministrativiview.defineColumn("registry_p_iva", typeof(string));
	tregistryamministrativiview.defineColumn("registry_pec_fe", typeof(string));
	tregistryamministrativiview.defineColumn("registry_residence", typeof(int),false);
	tregistryamministrativiview.defineColumn("registry_rtf", typeof(Byte[]));
	tregistryamministrativiview.defineColumn("registry_sdi_defrifamm", typeof(string));
	tregistryamministrativiview.defineColumn("registry_sdi_norifamm", typeof(string));
	tregistryamministrativiview.defineColumn("registry_surname", typeof(string));
	tregistryamministrativiview.defineColumn("registry_title", typeof(string),false);
	tregistryamministrativiview.defineColumn("registry_toredirect", typeof(int));
	tregistryamministrativiview.defineColumn("registry_txt", typeof(string));
	tregistryamministrativiview.defineColumn("registryclass_description", typeof(string));
	tregistryamministrativiview.defineColumn("registrykind_description", typeof(string));
	tregistryamministrativiview.defineColumn("residence_description", typeof(string));
	tregistryamministrativiview.defineColumn("title_description", typeof(string));
	Tables.Add(tregistryamministrativiview);
	tregistryamministrativiview.defineKey("idreg");

	//////////////////// PROGETTOREGISTRY_AMMINISTRATIVI /////////////////////////////////
	var tprogettoregistry_amministrativi= new MetaTable("progettoregistry_amministrativi");
	tprogettoregistry_amministrativi.defineColumn("ct", typeof(DateTime));
	tprogettoregistry_amministrativi.defineColumn("cu", typeof(string));
	tprogettoregistry_amministrativi.defineColumn("idprogetto", typeof(int),false);
	tprogettoregistry_amministrativi.defineColumn("idreg_amministrativi", typeof(int),false);
	tprogettoregistry_amministrativi.defineColumn("lt", typeof(DateTime));
	tprogettoregistry_amministrativi.defineColumn("lu", typeof(string));
	Tables.Add(tprogettoregistry_amministrativi);
	tprogettoregistry_amministrativi.defineKey("idprogetto", "idreg_amministrativi");

	#endregion


	#region DataRelation creation
	var cPar = new []{registryamministrativiview.Columns["idreg"]};
	var cChild = new []{progettoregistry_amministrativi.Columns["idreg_amministrativi"]};
	Relations.Add(new DataRelation("FK_progettoregistry_amministrativi_registryamministrativiview_idreg_amministrativi",cPar,cChild,false));

	#endregion

}
}
}
