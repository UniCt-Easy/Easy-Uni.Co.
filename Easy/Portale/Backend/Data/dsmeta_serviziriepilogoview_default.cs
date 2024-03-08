
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
[System.Xml.Serialization.XmlRoot("dsmeta_serviziriepilogoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_serviziriepilogoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable serviziriepilogoview 		=> (MetaTable)Tables["serviziriepilogoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_serviziriepilogoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_serviziriepilogoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_serviziriepilogoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_serviziriepilogoview_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// SERVIZIRIEPILOGOVIEW /////////////////////////////////
	var tserviziriepilogoview= new MetaTable("serviziriepilogoview");
	tserviziriepilogoview.defineColumn("anni", typeof(int));
	tserviziriepilogoview.defineColumn("cedolini", typeof(string));
	tserviziriepilogoview.defineColumn("ct", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("cu", typeof(string),false);
	tserviziriepilogoview.defineColumn("giorni", typeof(int));
	tserviziriepilogoview.defineColumn("idreg", typeof(int),false);
	tserviziriepilogoview.defineColumn("idserviziriepilogoview", typeof(string),false);
	tserviziriepilogoview.defineColumn("istituzione", typeof(string));
	tserviziriepilogoview.defineColumn("lt", typeof(DateTime),false);
	tserviziriepilogoview.defineColumn("lu", typeof(string),false);
	tserviziriepilogoview.defineColumn("mesi", typeof(int));
	tserviziriepilogoview.defineColumn("start", typeof(DateTime));
	tserviziriepilogoview.defineColumn("stop", typeof(DateTime));
	tserviziriepilogoview.defineColumn("tipologia", typeof(string),false);
	tserviziriepilogoview.defineColumn("totaldays", typeof(int));
	Tables.Add(tserviziriepilogoview);
	tserviziriepilogoview.defineKey("idreg", "idserviziriepilogoview");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydefaultview.Columns["idreg"]};
	var cChild = new []{serviziriepilogoview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_serviziriepilogoview_registrydefaultview_idreg",cPar,cChild,false));

	#endregion

}
}
}
