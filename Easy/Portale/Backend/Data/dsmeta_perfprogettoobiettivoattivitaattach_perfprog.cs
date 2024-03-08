
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivoattivitaattach_perfprog"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivoattivitaattach_perfprog: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitadefaultview 		=> (MetaTable)Tables["perfprogettoobiettivoattivitadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo 		=> (MetaTable)Tables["perfprogettoobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaattach 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaattach"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivoattivitaattach_perfprog(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivoattivitaattach_perfprog (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivoattivitaattach_perfprog";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivoattivitaattach_perfprog.xsd";

	#region create DataTables
	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITADEFAULTVIEW /////////////////////////////////
	var tperfprogettoobiettivoattivitadefaultview= new MetaTable("perfprogettoobiettivoattivitadefaultview");
	tperfprogettoobiettivoattivitadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettoobiettivoattivitadefaultview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	Tables.Add(tperfprogettoobiettivoattivitadefaultview);
	tperfprogettoobiettivoattivitadefaultview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVO /////////////////////////////////
	var tperfprogettoobiettivo= new MetaTable("perfprogettoobiettivo");
	tperfprogettoobiettivo.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivo.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivo.defineColumn("description", typeof(string));
	tperfprogettoobiettivo.defineColumn("idattach", typeof(int));
	tperfprogettoobiettivo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("lt", typeof(DateTime));
	tperfprogettoobiettivo.defineColumn("lu", typeof(string));
	tperfprogettoobiettivo.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivo);
	tperfprogettoobiettivo.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITAATTACH /////////////////////////////////
	var tperfprogettoobiettivoattivitaattach= new MetaTable("perfprogettoobiettivoattivitaattach");
	tperfprogettoobiettivoattivitaattach.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("data", typeof(DateTime));
	tperfprogettoobiettivoattivitaattach.defineColumn("idattach", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettoobiettivoattivitaattach);
	tperfprogettoobiettivoattivitaattach.defineKey("idattach", "idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_attach_idattach",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivitadefaultview.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivoattivitadefaultview_idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivitadefaultview.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitadefaultview_perfprogettoobiettivo_idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivo_idperfprogettoobiettivo",cPar,cChild,false));

	#endregion

}
}
}
