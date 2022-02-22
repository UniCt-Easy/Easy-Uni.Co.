
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_registryclass_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registryclass_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryclass 		=> (MetaTable)Tables["registryclass"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registryclass_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registryclass_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registryclass_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registryclass_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYCLASS /////////////////////////////////
	var tregistryclass= new MetaTable("registryclass");
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
	tregistryclass.defineColumn("idregistryclass", typeof(string),false);
	tregistryclass.defineColumn("lt", typeof(DateTime),false);
	tregistryclass.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistryclass);
	tregistryclass.defineKey("idregistryclass");

	#endregion

}
}
}
