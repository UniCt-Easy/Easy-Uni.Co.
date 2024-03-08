
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
[System.Xml.Serialization.XmlRoot("dsmeta_cefr_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_cefr_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cefr 		=> (MetaTable)Tables["cefr"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cefr_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cefr_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cefr_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cefr_default.xsd";

	#region create DataTables
	//////////////////// CEFR /////////////////////////////////
	var tcefr= new MetaTable("cefr");
	tcefr.defineColumn("active", typeof(string),false);
	tcefr.defineColumn("descriptioncompasc", typeof(string),false);
	tcefr.defineColumn("descriptioncomplett", typeof(string),false);
	tcefr.defineColumn("descriptionparlinter", typeof(string),false);
	tcefr.defineColumn("descriptionparlprod", typeof(string),false);
	tcefr.defineColumn("descriptionscritto", typeof(string),false);
	tcefr.defineColumn("idcefr", typeof(int),false);
	tcefr.defineColumn("lt", typeof(DateTime),false);
	tcefr.defineColumn("lu", typeof(string),false);
	tcefr.defineColumn("sortcode", typeof(int),false);
	tcefr.defineColumn("title", typeof(string),false);
	Tables.Add(tcefr);
	tcefr.defineKey("idcefr");

	#endregion

}
}
}
