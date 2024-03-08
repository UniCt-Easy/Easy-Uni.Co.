
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
[System.Xml.Serialization.XmlRoot("dsmeta_didprogdatepiano_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_didprogdatepiano_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdatepiano 		=> (MetaTable)Tables["didprogdatepiano"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_didprogdatepiano_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_didprogdatepiano_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_didprogdatepiano_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_didprogdatepiano_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DIDPROGDATEPIANO /////////////////////////////////
	var tdidprogdatepiano= new MetaTable("didprogdatepiano");
	tdidprogdatepiano.defineColumn("aa", typeof(string));
	tdidprogdatepiano.defineColumn("ct", typeof(DateTime),false);
	tdidprogdatepiano.defineColumn("cu", typeof(string),false);
	tdidprogdatepiano.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdatepiano.defineColumn("iddidprog", typeof(int),false);
	tdidprogdatepiano.defineColumn("iddidprogdatepiano", typeof(int),false);
	tdidprogdatepiano.defineColumn("lt", typeof(DateTime),false);
	tdidprogdatepiano.defineColumn("lu", typeof(string),false);
	tdidprogdatepiano.defineColumn("start", typeof(DateTime));
	tdidprogdatepiano.defineColumn("stop", typeof(DateTime));
	Tables.Add(tdidprogdatepiano);
	tdidprogdatepiano.defineKey("idcorsostudio", "iddidprog", "iddidprogdatepiano");

	#endregion


	#region DataRelation creation
	var cPar = new []{annoaccademico.Columns["aa"]};
	var cChild = new []{didprogdatepiano.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprogdatepiano_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
