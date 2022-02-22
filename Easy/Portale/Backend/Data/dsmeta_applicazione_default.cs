
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
[System.Xml.Serialization.XmlRoot("dsmeta_applicazione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_applicazione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable menuwebdefaultview 		=> (MetaTable)Tables["menuwebdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable applicazione 		=> (MetaTable)Tables["applicazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_applicazione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_applicazione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_applicazione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_applicazione_default.xsd";

	#region create DataTables
	//////////////////// MENUWEBDEFAULTVIEW /////////////////////////////////
	var tmenuwebdefaultview= new MetaTable("menuwebdefaultview");
	tmenuwebdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tmenuwebdefaultview.defineColumn("idmenuweb", typeof(int),false);
	tmenuwebdefaultview.defineColumn("idmenuwebparent", typeof(int));
	Tables.Add(tmenuwebdefaultview);
	tmenuwebdefaultview.defineKey("idmenuweb");

	//////////////////// APPLICAZIONE /////////////////////////////////
	var tapplicazione= new MetaTable("applicazione");
	tapplicazione.defineColumn("backend", typeof(string));
	tapplicazione.defineColumn("client", typeof(string));
	tapplicazione.defineColumn("dllcorefolder", typeof(string));
	tapplicazione.defineColumn("dlloutputfolder", typeof(string));
	tapplicazione.defineColumn("idapplicazione", typeof(int),false);
	tapplicazione.defineColumn("idmenuweb", typeof(int));
	tapplicazione.defineColumn("metadati", typeof(string));
	tapplicazione.defineColumn("metapagefolder", typeof(string));
	tapplicazione.defineColumn("scriptFolder", typeof(string));
	tapplicazione.defineColumn("solutionfile", typeof(string));
	tapplicazione.defineColumn("testFolder", typeof(string));
	tapplicazione.defineColumn("title", typeof(string));
	Tables.Add(tapplicazione);
	tapplicazione.defineKey("idapplicazione");

	#endregion


	#region DataRelation creation
	var cPar = new []{menuwebdefaultview.Columns["idmenuweb"]};
	var cChild = new []{applicazione.Columns["idmenuweb"]};
	Relations.Add(new DataRelation("FK_applicazione_menuwebdefaultview_idmenuweb",cPar,cChild,false));

	#endregion

}
}
}
