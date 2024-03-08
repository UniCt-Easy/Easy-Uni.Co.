
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivointerazione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivointerazione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfinterazionekind 		=> (MetaTable)Tables["perfinterazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivointerazione 		=> (MetaTable)Tables["perfprogettoobiettivointerazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivointerazione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivointerazione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivointerazione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivointerazione_default.xsd";

	#region create DataTables
	//////////////////// PERFINTERAZIONEKIND /////////////////////////////////
	var tperfinterazionekind= new MetaTable("perfinterazionekind");
	tperfinterazionekind.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfinterazionekind.defineColumn("title", typeof(string));
	Tables.Add(tperfinterazionekind);
	tperfinterazionekind.defineKey("idperfinterazionekind");

	//////////////////// PERFPROGETTOOBIETTIVOINTERAZIONE /////////////////////////////////
	var tperfprogettoobiettivointerazione= new MetaTable("perfprogettoobiettivointerazione");
	tperfprogettoobiettivointerazione.defineColumn("commenti", typeof(string));
	tperfprogettoobiettivointerazione.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivointerazione.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivointerazione.defineColumn("data", typeof(DateTime));
	tperfprogettoobiettivointerazione.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("idperfprogettoobiettivointerazione", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivointerazione.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivointerazione.defineColumn("utente", typeof(string));
	Tables.Add(tperfprogettoobiettivointerazione);
	tperfprogettoobiettivointerazione.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivointerazione");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfinterazionekind.Columns["idperfinterazionekind"]};
	var cChild = new []{perfprogettoobiettivointerazione.Columns["idperfinterazionekind"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivointerazione_perfinterazionekind_idperfinterazionekind",cPar,cChild,false));

	#endregion

}
}
}
