
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
[System.Xml.Serialization.XmlRoot("dsmeta_deliberaistanza_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_deliberaistanza_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable delibera 		=> (MetaTable)Tables["delibera"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable deliberaistanza 		=> (MetaTable)Tables["deliberaistanza"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_deliberaistanza_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_deliberaistanza_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_deliberaistanza_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_deliberaistanza_seg.xsd";

	#region create DataTables
	//////////////////// DELIBERA /////////////////////////////////
	var tdelibera= new MetaTable("delibera");
	tdelibera.defineColumn("ct", typeof(DateTime),false);
	tdelibera.defineColumn("cu", typeof(string),false);
	tdelibera.defineColumn("data", typeof(DateTime),false);
	tdelibera.defineColumn("iddelibera", typeof(int),false);
	tdelibera.defineColumn("idreg_struttura", typeof(int));
	tdelibera.defineColumn("idstatuskind", typeof(int));
	tdelibera.defineColumn("lt", typeof(DateTime),false);
	tdelibera.defineColumn("lu", typeof(string),false);
	tdelibera.defineColumn("oggetto", typeof(string));
	tdelibera.defineColumn("protanno", typeof(int));
	tdelibera.defineColumn("protnumero", typeof(int));
	tdelibera.defineColumn("testo", typeof(string));
	Tables.Add(tdelibera);
	tdelibera.defineKey("iddelibera");

	//////////////////// DELIBERAISTANZA /////////////////////////////////
	var tdeliberaistanza= new MetaTable("deliberaistanza");
	tdeliberaistanza.defineColumn("ct", typeof(DateTime),false);
	tdeliberaistanza.defineColumn("cu", typeof(string),false);
	tdeliberaistanza.defineColumn("iddelibera", typeof(int),false);
	tdeliberaistanza.defineColumn("idistanza", typeof(int),false);
	tdeliberaistanza.defineColumn("idreg", typeof(int),false);
	tdeliberaistanza.defineColumn("lt", typeof(DateTime),false);
	tdeliberaistanza.defineColumn("lu", typeof(string),false);
	Tables.Add(tdeliberaistanza);
	tdeliberaistanza.defineKey("iddelibera", "idistanza", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{delibera.Columns["iddelibera"]};
	var cChild = new []{deliberaistanza.Columns["iddelibera"]};
	Relations.Add(new DataRelation("FK_deliberaistanza_delibera_iddelibera",cPar,cChild,false));

	#endregion

}
}
}
