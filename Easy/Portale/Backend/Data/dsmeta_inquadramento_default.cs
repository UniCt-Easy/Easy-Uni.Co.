
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
[System.Xml.Serialization.XmlRoot("dsmeta_inquadramento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_inquadramento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendio 		=> (MetaTable)Tables["stipendio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_inquadramento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_inquadramento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_inquadramento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_inquadramento_default.xsd";

	#region create DataTables
	//////////////////// STIPENDIO /////////////////////////////////
	var tstipendio= new MetaTable("stipendio");
	tstipendio.defineColumn("!previdenza", typeof(decimal));
	tstipendio.defineColumn("!tesoro", typeof(decimal));
	tstipendio.defineColumn("!totalece", typeof(decimal));
	tstipendio.defineColumn("!tredicesima", typeof(decimal));
	tstipendio.defineColumn("assegno", typeof(decimal));
	tstipendio.defineColumn("classe", typeof(int));
	tstipendio.defineColumn("ct", typeof(DateTime));
	tstipendio.defineColumn("cu", typeof(string));
	tstipendio.defineColumn("idcontrattokind", typeof(int),false);
	tstipendio.defineColumn("idinquadramento", typeof(int),false);
	tstipendio.defineColumn("idstipendio", typeof(int),false);
	tstipendio.defineColumn("iis", typeof(decimal));
	tstipendio.defineColumn("irap", typeof(decimal));
	tstipendio.defineColumn("lordo", typeof(decimal));
	tstipendio.defineColumn("lt", typeof(DateTime));
	tstipendio.defineColumn("lu", typeof(string));
	tstipendio.defineColumn("scatto", typeof(int));
	tstipendio.defineColumn("siglaimportazione", typeof(string));
	tstipendio.defineColumn("stipendio", typeof(decimal));
	tstipendio.defineColumn("totale", typeof(decimal));
	Tables.Add(tstipendio);
	tstipendio.defineKey("idcontrattokind", "idinquadramento", "idstipendio");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("costolordoannuo", typeof(decimal));
	tinquadramento.defineColumn("costolordoannuooneri", typeof(decimal));
	tinquadramento.defineColumn("ct", typeof(DateTime),false);
	tinquadramento.defineColumn("cu", typeof(string),false);
	tinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("lt", typeof(DateTime),false);
	tinquadramento.defineColumn("lu", typeof(string),false);
	tinquadramento.defineColumn("siglaimportazione", typeof(string));
	tinquadramento.defineColumn("start", typeof(DateTime));
	tinquadramento.defineColumn("stop", typeof(DateTime));
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idcontrattokind", "idinquadramento");

	#endregion


	#region DataRelation creation
	var cPar = new []{inquadramento.Columns["idcontrattokind"], inquadramento.Columns["idinquadramento"]};
	var cChild = new []{stipendio.Columns["idcontrattokind"], stipendio.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_stipendio_inquadramento_idcontrattokind-idinquadramento",cPar,cChild,false));

	#endregion

}
}
}
