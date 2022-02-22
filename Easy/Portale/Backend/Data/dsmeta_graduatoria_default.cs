
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
[System.Xml.Serialization.XmlRoot("dsmeta_graduatoria_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_graduatoria_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriavar 		=> (MetaTable)Tables["graduatoriavar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriadesc 		=> (MetaTable)Tables["graduatoriadesc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoria 		=> (MetaTable)Tables["graduatoria"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_graduatoria_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_graduatoria_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_graduatoria_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_graduatoria_default.xsd";

	#region create DataTables
	//////////////////// GRADUATORIAVAR /////////////////////////////////
	var tgraduatoriavar= new MetaTable("graduatoriavar");
	tgraduatoriavar.defineColumn("idgraduatoriavar", typeof(int),false);
	tgraduatoriavar.defineColumn("title", typeof(string));
	Tables.Add(tgraduatoriavar);
	tgraduatoriavar.defineKey("idgraduatoriavar");

	//////////////////// GRADUATORIADESC /////////////////////////////////
	var tgraduatoriadesc= new MetaTable("graduatoriadesc");
	tgraduatoriadesc.defineColumn("ct", typeof(DateTime),false);
	tgraduatoriadesc.defineColumn("cu", typeof(string),false);
	tgraduatoriadesc.defineColumn("gradmax", typeof(decimal));
	tgraduatoriadesc.defineColumn("gradmin", typeof(decimal));
	tgraduatoriadesc.defineColumn("gradval", typeof(decimal));
	tgraduatoriadesc.defineColumn("idgraduatoria", typeof(int),false);
	tgraduatoriadesc.defineColumn("idgraduatoriadesc", typeof(int),false);
	tgraduatoriadesc.defineColumn("idgraduatoriavar", typeof(int));
	tgraduatoriadesc.defineColumn("lt", typeof(DateTime),false);
	tgraduatoriadesc.defineColumn("lu", typeof(string),false);
	tgraduatoriadesc.defineColumn("molt", typeof(decimal));
	tgraduatoriadesc.defineColumn("prefer", typeof(string));
	tgraduatoriadesc.defineColumn("!idgraduatoriavar_graduatoriavar_title", typeof(string));
	Tables.Add(tgraduatoriadesc);
	tgraduatoriadesc.defineKey("idgraduatoriadesc");

	//////////////////// GRADUATORIA /////////////////////////////////
	var tgraduatoria= new MetaTable("graduatoria");
	tgraduatoria.defineColumn("ammessimax", typeof(int));
	tgraduatoria.defineColumn("ct", typeof(DateTime),false);
	tgraduatoria.defineColumn("cu", typeof(string),false);
	tgraduatoria.defineColumn("idgraduatoria", typeof(int),false);
	tgraduatoria.defineColumn("lt", typeof(DateTime),false);
	tgraduatoria.defineColumn("lu", typeof(string),false);
	tgraduatoria.defineColumn("punteggiomin", typeof(decimal));
	tgraduatoria.defineColumn("title", typeof(string));
	Tables.Add(tgraduatoria);
	tgraduatoria.defineKey("idgraduatoria");

	#endregion


	#region DataRelation creation
	var cPar = new []{graduatoria.Columns["idgraduatoria"]};
	var cChild = new []{graduatoriadesc.Columns["idgraduatoria"]};
	Relations.Add(new DataRelation("FK_graduatoriadesc_graduatoria_idgraduatoria",cPar,cChild,false));

	cPar = new []{graduatoriavar.Columns["idgraduatoriavar"]};
	cChild = new []{graduatoriadesc.Columns["idgraduatoriavar"]};
	Relations.Add(new DataRelation("FK_graduatoriadesc_graduatoriavar_idgraduatoriavar",cPar,cChild,false));

	#endregion

}
}
}
