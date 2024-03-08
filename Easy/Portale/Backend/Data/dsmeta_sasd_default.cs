
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
[System.Xml.Serialization.XmlRoot("dsmeta_sasd_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_sasd_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istitutokind 		=> (MetaTable)Tables["istitutokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdistitutokind 		=> (MetaTable)Tables["sasdistitutokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable areadidatticadefaultview 		=> (MetaTable)Tables["areadidatticadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sasd_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sasd_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sasd_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sasd_default.xsd";

	#region create DataTables
	//////////////////// ISTITUTOKIND /////////////////////////////////
	var tistitutokind= new MetaTable("istitutokind");
	tistitutokind.defineColumn("idistitutokind", typeof(int),false);
	tistitutokind.defineColumn("lt", typeof(DateTime));
	tistitutokind.defineColumn("lu", typeof(string));
	tistitutokind.defineColumn("tipoistituto", typeof(string),false);
	tistitutokind.defineColumn("tipoistitutoen", typeof(string),false);
	tistitutokind.defineColumn("tipoistitutosigla", typeof(string),false);
	Tables.Add(tistitutokind);
	tistitutokind.defineKey("idistitutokind");

	//////////////////// SASDISTITUTOKIND /////////////////////////////////
	var tsasdistitutokind= new MetaTable("sasdistitutokind");
	tsasdistitutokind.defineColumn("idistitutokind", typeof(int),false);
	tsasdistitutokind.defineColumn("idsasd", typeof(int),false);
	tsasdistitutokind.defineColumn("lt", typeof(DateTime),false);
	tsasdistitutokind.defineColumn("lu", typeof(string),false);
	tsasdistitutokind.defineColumn("!idistitutokind_istitutokind_tipoistituto", typeof(string));
	tsasdistitutokind.defineColumn("!idistitutokind_istitutokind_tipoistitutoen", typeof(string));
	tsasdistitutokind.defineColumn("!idistitutokind_istitutokind_tipoistitutosigla", typeof(string));
	Tables.Add(tsasdistitutokind);
	tsasdistitutokind.defineKey("idistitutokind", "idsasd");

	//////////////////// AREADIDATTICADEFAULTVIEW /////////////////////////////////
	var tareadidatticadefaultview= new MetaTable("areadidatticadefaultview");
	tareadidatticadefaultview.defineColumn("areadidattica_active", typeof(string));
	tareadidatticadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tareadidatticadefaultview.defineColumn("idareadidattica", typeof(int),false);
	Tables.Add(tareadidatticadefaultview);
	tareadidatticadefaultview.defineKey("idareadidattica");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("codice_old", typeof(string));
	tsasd.defineColumn("idareadidattica", typeof(int));
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("lt", typeof(DateTime));
	tsasd.defineColumn("lu", typeof(string));
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	#endregion


	#region DataRelation creation
	var cPar = new []{sasd.Columns["idsasd"]};
	var cChild = new []{sasdistitutokind.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_sasdistitutokind_sasd_idsasd",cPar,cChild,false));

	cPar = new []{istitutokind.Columns["idistitutokind"]};
	cChild = new []{sasdistitutokind.Columns["idistitutokind"]};
	Relations.Add(new DataRelation("FK_sasdistitutokind_istitutokind_idistitutokind",cPar,cChild,false));

	cPar = new []{areadidatticadefaultview.Columns["idareadidattica"]};
	cChild = new []{sasd.Columns["idareadidattica"]};
	Relations.Add(new DataRelation("FK_sasd_areadidatticadefaultview_idareadidattica",cPar,cChild,false));

	#endregion

}
}
}
