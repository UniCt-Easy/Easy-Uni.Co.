
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoudr_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoudr_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudrmembrokind 		=> (MetaTable)Tables["progettoudrmembrokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudrmembro 		=> (MetaTable)Tables["progettoudrmembro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudr 		=> (MetaTable)Tables["progettoudr"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoudr_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoudr_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoudr_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoudr_seg.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// PROGETTOUDRMEMBROKIND /////////////////////////////////
	var tprogettoudrmembrokind= new MetaTable("progettoudrmembrokind");
	tprogettoudrmembrokind.defineColumn("active", typeof(string),false);
	tprogettoudrmembrokind.defineColumn("idprogettoudrmembrokind", typeof(int),false);
	tprogettoudrmembrokind.defineColumn("title", typeof(string));
	Tables.Add(tprogettoudrmembrokind);
	tprogettoudrmembrokind.defineKey("idprogettoudrmembrokind");

	//////////////////// PROGETTOUDRMEMBRO /////////////////////////////////
	var tprogettoudrmembro= new MetaTable("progettoudrmembro");
	tprogettoudrmembro.defineColumn("!orerendicontate", typeof(int));
	tprogettoudrmembro.defineColumn("costoorario", typeof(decimal));
	tprogettoudrmembro.defineColumn("ct", typeof(DateTime));
	tprogettoudrmembro.defineColumn("cu", typeof(string));
	tprogettoudrmembro.defineColumn("idprogetto", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudrmembro", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudrmembrokind", typeof(int));
	tprogettoudrmembro.defineColumn("idreg", typeof(int),false);
	tprogettoudrmembro.defineColumn("impegno", typeof(decimal));
	tprogettoudrmembro.defineColumn("lt", typeof(DateTime));
	tprogettoudrmembro.defineColumn("lu", typeof(string));
	tprogettoudrmembro.defineColumn("orepreventivate", typeof(int));
	tprogettoudrmembro.defineColumn("ricavoorario", typeof(decimal));
	tprogettoudrmembro.defineColumn("!idprogettoudrmembrokind_progettoudrmembrokind_title", typeof(string));
	tprogettoudrmembro.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tprogettoudrmembro);
	tprogettoudrmembro.defineKey("idprogetto", "idprogettoudr", "idprogettoudrmembro");

	//////////////////// PROGETTOUDR /////////////////////////////////
	var tprogettoudr= new MetaTable("progettoudr");
	tprogettoudr.defineColumn("!budgetore", typeof(decimal));
	tprogettoudr.defineColumn("assegniricerca", typeof(int));
	tprogettoudr.defineColumn("borsedottorati", typeof(int));
	tprogettoudr.defineColumn("budget", typeof(decimal));
	tprogettoudr.defineColumn("contrattirtd", typeof(int));
	tprogettoudr.defineColumn("contributo", typeof(decimal));
	tprogettoudr.defineColumn("ct", typeof(DateTime));
	tprogettoudr.defineColumn("cu", typeof(string));
	tprogettoudr.defineColumn("description", typeof(string));
	tprogettoudr.defineColumn("idprogetto", typeof(int),false);
	tprogettoudr.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudr.defineColumn("impegnototale", typeof(decimal));
	tprogettoudr.defineColumn("impegnototaleore", typeof(int));
	tprogettoudr.defineColumn("lt", typeof(DateTime));
	tprogettoudr.defineColumn("lu", typeof(string));
	tprogettoudr.defineColumn("title", typeof(string));
	Tables.Add(tprogettoudr);
	tprogettoudr.defineKey("idprogetto", "idprogettoudr");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettoudr.Columns["idprogetto"], progettoudr.Columns["idprogettoudr"]};
	var cChild = new []{progettoudrmembro.Columns["idprogetto"], progettoudrmembro.Columns["idprogettoudr"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_progettoudr_idprogetto-idprogettoudr",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{progettoudrmembro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_registry_idreg",cPar,cChild,false));

	cPar = new []{progettoudrmembrokind.Columns["idprogettoudrmembrokind"]};
	cChild = new []{progettoudrmembro.Columns["idprogettoudrmembrokind"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_progettoudrmembrokind_idprogettoudrmembrokind",cPar,cChild,false));

	#endregion

}
}
}
