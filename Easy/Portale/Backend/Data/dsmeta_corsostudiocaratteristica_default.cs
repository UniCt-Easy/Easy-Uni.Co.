
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
[System.Xml.Serialization.XmlRoot("dsmeta_corsostudiocaratteristica_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_corsostudiocaratteristica_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasdgruppodefaultview 		=> (MetaTable)Tables["sasdgruppodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ambitoareadiscdefaultview 		=> (MetaTable)Tables["ambitoareadiscdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipoattformdefaultview 		=> (MetaTable)Tables["tipoattformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiocaratteristica 		=> (MetaTable)Tables["corsostudiocaratteristica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_corsostudiocaratteristica_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_corsostudiocaratteristica_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_corsostudiocaratteristica_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_corsostudiocaratteristica_default.xsd";

	#region create DataTables
	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// SASDGRUPPODEFAULTVIEW /////////////////////////////////
	var tsasdgruppodefaultview= new MetaTable("sasdgruppodefaultview");
	tsasdgruppodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasdgruppodefaultview.defineColumn("idsasdgruppo", typeof(int),false);
	tsasdgruppodefaultview.defineColumn("idtipoattform", typeof(int),false);
	Tables.Add(tsasdgruppodefaultview);
	tsasdgruppodefaultview.defineKey("idsasdgruppo");

	//////////////////// AMBITOAREADISCDEFAULTVIEW /////////////////////////////////
	var tambitoareadiscdefaultview= new MetaTable("ambitoareadiscdefaultview");
	tambitoareadiscdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tambitoareadiscdefaultview.defineColumn("idambitoareadisc", typeof(int),false);
	tambitoareadiscdefaultview.defineColumn("idclassescuola", typeof(int));
	Tables.Add(tambitoareadiscdefaultview);
	tambitoareadiscdefaultview.defineKey("idambitoareadisc");

	//////////////////// TIPOATTFORMDEFAULTVIEW /////////////////////////////////
	var ttipoattformdefaultview= new MetaTable("tipoattformdefaultview");
	ttipoattformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttipoattformdefaultview.defineColumn("idtipoattform", typeof(int),false);
	Tables.Add(ttipoattformdefaultview);
	ttipoattformdefaultview.defineKey("idtipoattform");

	//////////////////// CORSOSTUDIOCARATTERISTICA /////////////////////////////////
	var tcorsostudiocaratteristica= new MetaTable("corsostudiocaratteristica");
	tcorsostudiocaratteristica.defineColumn("cf", typeof(decimal));
	tcorsostudiocaratteristica.defineColumn("cfmax", typeof(decimal));
	tcorsostudiocaratteristica.defineColumn("cfmin", typeof(decimal));
	tcorsostudiocaratteristica.defineColumn("ct", typeof(DateTime),false);
	tcorsostudiocaratteristica.defineColumn("cu", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("idambitoareadisc", typeof(int));
	tcorsostudiocaratteristica.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiocaratteristica.defineColumn("idcorsostudiocaratteristica", typeof(int),false);
	tcorsostudiocaratteristica.defineColumn("idsasd", typeof(int));
	tcorsostudiocaratteristica.defineColumn("idsasdgruppo", typeof(int));
	tcorsostudiocaratteristica.defineColumn("idtipoattform", typeof(int));
	tcorsostudiocaratteristica.defineColumn("lt", typeof(DateTime),false);
	tcorsostudiocaratteristica.defineColumn("lu", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("obblig", typeof(string),false);
	tcorsostudiocaratteristica.defineColumn("profess", typeof(string),false);
	Tables.Add(tcorsostudiocaratteristica);
	tcorsostudiocaratteristica.defineKey("idcorsostudiocaratteristica");

	#endregion


	#region DataRelation creation
	var cPar = new []{sasddefaultview.Columns["idsasd"]};
	var cChild = new []{corsostudiocaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{sasdgruppodefaultview.Columns["idsasdgruppo"]};
	cChild = new []{corsostudiocaratteristica.Columns["idsasdgruppo"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_sasdgruppodefaultview_idsasdgruppo",cPar,cChild,false));

	cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	cChild = new []{sasdgruppodefaultview.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_sasdgruppodefaultview_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	cPar = new []{ambitoareadiscdefaultview.Columns["idambitoareadisc"]};
	cChild = new []{corsostudiocaratteristica.Columns["idambitoareadisc"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_ambitoareadiscdefaultview_idambitoareadisc",cPar,cChild,false));

	cPar = new []{tipoattformdefaultview.Columns["idtipoattform"]};
	cChild = new []{corsostudiocaratteristica.Columns["idtipoattform"]};
	Relations.Add(new DataRelation("FK_corsostudiocaratteristica_tipoattformdefaultview_idtipoattform",cPar,cChild,false));

	#endregion

}
}
}
