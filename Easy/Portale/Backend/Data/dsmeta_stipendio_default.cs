
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
[System.Xml.Serialization.XmlRoot("dsmeta_stipendio_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_stipendio_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendio 		=> (MetaTable)Tables["stipendio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_stipendio_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_stipendio_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_stipendio_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_stipendio_default.xsd";

	#region create DataTables
	//////////////////// STIPENDIO /////////////////////////////////
	var tstipendio= new MetaTable("stipendio");
	tstipendio.defineColumn("!previdenza", typeof(decimal));
	tstipendio.defineColumn("!tesoro", typeof(decimal));
	tstipendio.defineColumn("!totalece", typeof(decimal));
	tstipendio.defineColumn("!tredicesima", typeof(decimal));
	tstipendio.defineColumn("anzianitamax", typeof(int));
	tstipendio.defineColumn("anzianitamin", typeof(int));
	tstipendio.defineColumn("assegno", typeof(decimal));
	tstipendio.defineColumn("classe", typeof(int));
	tstipendio.defineColumn("ct", typeof(DateTime));
	tstipendio.defineColumn("cu", typeof(string));
	tstipendio.defineColumn("elementoperequativo", typeof(decimal));
	tstipendio.defineColumn("idcontrattokind", typeof(int));
	tstipendio.defineColumn("idinquadramento", typeof(int),false);
	tstipendio.defineColumn("idposition", typeof(int),false);
	tstipendio.defineColumn("idstipendio", typeof(int),false);
	tstipendio.defineColumn("iis", typeof(decimal));
	tstipendio.defineColumn("indennitaateneo", typeof(decimal));
	tstipendio.defineColumn("indennitaposizioneminima", typeof(decimal));
	tstipendio.defineColumn("irap", typeof(decimal));
	tstipendio.defineColumn("lordo", typeof(decimal));
	tstipendio.defineColumn("lordonotredicesima", typeof(decimal));
	tstipendio.defineColumn("lt", typeof(DateTime));
	tstipendio.defineColumn("lu", typeof(string));
	tstipendio.defineColumn("rifnormativo", typeof(string));
	tstipendio.defineColumn("scatto", typeof(int));
	tstipendio.defineColumn("siglaimportazione", typeof(string));
	tstipendio.defineColumn("start", typeof(DateTime));
	tstipendio.defineColumn("stipendio", typeof(decimal));
	tstipendio.defineColumn("stop", typeof(DateTime));
	tstipendio.defineColumn("totale", typeof(decimal));
	Tables.Add(tstipendio);
	tstipendio.defineKey("idinquadramento", "idposition", "idstipendio");

	#endregion

}
}
}
