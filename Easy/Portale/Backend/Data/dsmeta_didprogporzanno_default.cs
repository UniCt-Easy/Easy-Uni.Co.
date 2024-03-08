
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
[System.Xml.Serialization.XmlRoot("dsmeta_didprogporzanno_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_didprogporzanno_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzannokind 		=> (MetaTable)Tables["didprogporzannokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_didprogporzanno_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_didprogporzanno_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_didprogporzanno_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_didprogporzanno_default.xsd";

	#region create DataTables
	//////////////////// DIDPROGPORZANNOKIND /////////////////////////////////
	var tdidprogporzannokind= new MetaTable("didprogporzannokind");
	tdidprogporzannokind.defineColumn("iddidprogporzannokind", typeof(int),false);
	tdidprogporzannokind.defineColumn("title", typeof(string),false);
	Tables.Add(tdidprogporzannokind);
	tdidprogporzannokind.defineKey("iddidprogporzannokind");

	//////////////////// DIDPROGPORZANNO /////////////////////////////////
	var tdidprogporzanno= new MetaTable("didprogporzanno");
	tdidprogporzanno.defineColumn("aa", typeof(string),false);
	tdidprogporzanno.defineColumn("ct", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("cu", typeof(string),false);
	tdidprogporzanno.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzannokind", typeof(int));
	tdidprogporzanno.defineColumn("indice", typeof(int));
	tdidprogporzanno.defineColumn("lt", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("lu", typeof(string),false);
	tdidprogporzanno.defineColumn("start", typeof(DateTime));
	tdidprogporzanno.defineColumn("stop", typeof(DateTime));
	tdidprogporzanno.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzanno);
	tdidprogporzanno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprogporzannokind.Columns["iddidprogporzannokind"]};
	var cChild = new []{didprogporzanno.Columns["iddidprogporzannokind"]};
	Relations.Add(new DataRelation("FK_didprogporzanno_didprogporzannokind_iddidprogporzannokind",cPar,cChild,false));

	#endregion

}
}
}
