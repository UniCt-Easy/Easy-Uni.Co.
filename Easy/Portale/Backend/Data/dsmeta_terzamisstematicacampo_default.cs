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
[System.Xml.Serialization.XmlRoot("dsmeta_terzamisstematicacampo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_terzamisstematicacampo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable terzamisstematicadefaultview 		=> (MetaTable)Tables["terzamisstematicadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable terzamisstematicacampo 		=> (MetaTable)Tables["terzamisstematicacampo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_terzamisstematicacampo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_terzamisstematicacampo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_terzamisstematicacampo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_terzamisstematicacampo_default.xsd";

	#region create DataTables
	//////////////////// TERZAMISSTEMATICADEFAULTVIEW /////////////////////////////////
	var tterzamisstematicadefaultview= new MetaTable("terzamisstematicadefaultview");
	tterzamisstematicadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tterzamisstematicadefaultview.defineColumn("idterzamisstematica", typeof(int),false);
	tterzamisstematicadefaultview.defineColumn("terzamisstematica_active", typeof(string));
	tterzamisstematicadefaultview.defineColumn("terzamisstematica_ct", typeof(DateTime),false);
	tterzamisstematicadefaultview.defineColumn("terzamisstematica_cu", typeof(string),false);
	tterzamisstematicadefaultview.defineColumn("terzamisstematica_lt", typeof(DateTime),false);
	tterzamisstematicadefaultview.defineColumn("terzamisstematica_lu", typeof(string),false);
	tterzamisstematicadefaultview.defineColumn("terzamisstematica_riferimento", typeof(string));
	tterzamisstematicadefaultview.defineColumn("title", typeof(string));
	Tables.Add(tterzamisstematicadefaultview);
	tterzamisstematicadefaultview.defineKey("idterzamisstematica");

	//////////////////// TERZAMISSTEMATICACAMPO /////////////////////////////////
	var tterzamisstematicacampo= new MetaTable("terzamisstematicacampo");
	tterzamisstematicacampo.defineColumn("active", typeof(string));
	tterzamisstematicacampo.defineColumn("ct", typeof(DateTime),false);
	tterzamisstematicacampo.defineColumn("cu", typeof(string),false);
	tterzamisstematicacampo.defineColumn("idterzamisstematica", typeof(int),false);
	tterzamisstematicacampo.defineColumn("idterzamisstematicacampo", typeof(int),false);
	tterzamisstematicacampo.defineColumn("lt", typeof(DateTime),false);
	tterzamisstematicacampo.defineColumn("lu", typeof(string),false);
	tterzamisstematicacampo.defineColumn("title", typeof(string));
	Tables.Add(tterzamisstematicacampo);
	tterzamisstematicacampo.defineKey("idterzamisstematica", "idterzamisstematicacampo");

	#endregion


	#region DataRelation creation
	var cPar = new []{terzamisstematicadefaultview.Columns["idterzamisstematica"]};
	var cChild = new []{terzamisstematicacampo.Columns["idterzamisstematica"]};
	Relations.Add(new DataRelation("FK_terzamisstematicacampo_terzamisstematicadefaultview_idterzamisstematica",cPar,cChild,false));

	#endregion

}
}
}
