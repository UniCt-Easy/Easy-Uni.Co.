
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
[System.Xml.Serialization.XmlRoot("dsmeta_relatore_segistcons"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_relatore_segistcons: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable relatorekinddefaultview 		=> (MetaTable)Tables["relatorekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydocentiview 		=> (MetaTable)Tables["registrydocentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable relatore 		=> (MetaTable)Tables["relatore"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_relatore_segistcons(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_relatore_segistcons (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_relatore_segistcons";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_relatore_segistcons.xsd";

	#region create DataTables
	//////////////////// RELATOREKINDDEFAULTVIEW /////////////////////////////////
	var trelatorekinddefaultview= new MetaTable("relatorekinddefaultview");
	trelatorekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	trelatorekinddefaultview.defineColumn("idrelatorekind", typeof(int),false);
	Tables.Add(trelatorekinddefaultview);
	trelatorekinddefaultview.defineKey("idrelatorekind");

	//////////////////// REGISTRYDOCENTIVIEW /////////////////////////////////
	var tregistrydocentiview= new MetaTable("registrydocentiview");
	tregistrydocentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydocentiview.defineColumn("idcity", typeof(int));
	tregistrydocentiview.defineColumn("idclassconsorsuale", typeof(int));
	tregistrydocentiview.defineColumn("idnation", typeof(int));
	tregistrydocentiview.defineColumn("idreg", typeof(int),false);
	tregistrydocentiview.defineColumn("idreg_istituti", typeof(int));
	tregistrydocentiview.defineColumn("idregistryclass", typeof(string));
	tregistrydocentiview.defineColumn("idsasd", typeof(int));
	tregistrydocentiview.defineColumn("idstruttura", typeof(int));
	tregistrydocentiview.defineColumn("idtitle", typeof(string));
	tregistrydocentiview.defineColumn("registry_residence", typeof(int),false);
	Tables.Add(tregistrydocentiview);
	tregistrydocentiview.defineKey("idreg");

	//////////////////// RELATORE /////////////////////////////////
	var trelatore= new MetaTable("relatore");
	trelatore.defineColumn("ct", typeof(DateTime),false);
	trelatore.defineColumn("cu", typeof(string),false);
	trelatore.defineColumn("idistanza", typeof(int),false);
	trelatore.defineColumn("idreg", typeof(int),false);
	trelatore.defineColumn("idreg_docenti", typeof(int));
	trelatore.defineColumn("idrelatore", typeof(int),false);
	trelatore.defineColumn("idrelatorekind", typeof(int));
	trelatore.defineColumn("lt", typeof(DateTime),false);
	trelatore.defineColumn("lu", typeof(string),false);
	Tables.Add(trelatore);
	trelatore.defineKey("idistanza", "idreg", "idrelatore");

	#endregion


	#region DataRelation creation
	var cPar = new []{relatorekinddefaultview.Columns["idrelatorekind"]};
	var cChild = new []{relatore.Columns["idrelatorekind"]};
	Relations.Add(new DataRelation("FK_relatore_relatorekinddefaultview_idrelatorekind",cPar,cChild,false));

	cPar = new []{registrydocentiview.Columns["idreg"]};
	cChild = new []{relatore.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_relatore_registrydocentiview_idreg_docenti",cPar,cChild,false));

	#endregion

}
}
}
