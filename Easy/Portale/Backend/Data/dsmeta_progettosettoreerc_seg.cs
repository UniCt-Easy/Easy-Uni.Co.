
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettosettoreerc_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettosettoreerc_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable settoreerc 		=> (MetaTable)Tables["settoreerc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettosettoreerc 		=> (MetaTable)Tables["progettosettoreerc"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettosettoreerc_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettosettoreerc_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettosettoreerc_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettosettoreerc_seg.xsd";

	#region create DataTables
	//////////////////// SETTOREERC /////////////////////////////////
	var tsettoreerc= new MetaTable("settoreerc");
	tsettoreerc.defineColumn("active", typeof(string));
	tsettoreerc.defineColumn("ct", typeof(DateTime));
	tsettoreerc.defineColumn("cu", typeof(string));
	tsettoreerc.defineColumn("description", typeof(string));
	tsettoreerc.defineColumn("idsettoreerc", typeof(int),false);
	tsettoreerc.defineColumn("lt", typeof(DateTime));
	tsettoreerc.defineColumn("lu", typeof(string));
	tsettoreerc.defineColumn("sortcode", typeof(int));
	tsettoreerc.defineColumn("title", typeof(string));
	Tables.Add(tsettoreerc);
	tsettoreerc.defineKey("idsettoreerc");

	//////////////////// PROGETTOSETTOREERC /////////////////////////////////
	var tprogettosettoreerc= new MetaTable("progettosettoreerc");
	tprogettosettoreerc.defineColumn("ct", typeof(DateTime),false);
	tprogettosettoreerc.defineColumn("cu", typeof(string),false);
	tprogettosettoreerc.defineColumn("idprogetto", typeof(int),false);
	tprogettosettoreerc.defineColumn("idsettoreerc", typeof(int),false);
	tprogettosettoreerc.defineColumn("lt", typeof(DateTime),false);
	tprogettosettoreerc.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettosettoreerc);
	tprogettosettoreerc.defineKey("idprogetto", "idsettoreerc");

	#endregion


	#region DataRelation creation
	var cPar = new []{settoreerc.Columns["idsettoreerc"]};
	var cChild = new []{progettosettoreerc.Columns["idsettoreerc"]};
	Relations.Add(new DataRelation("FK_progettosettoreerc_settoreerc_idsettoreerc",cPar,cChild,false));

	#endregion

}
}
}
