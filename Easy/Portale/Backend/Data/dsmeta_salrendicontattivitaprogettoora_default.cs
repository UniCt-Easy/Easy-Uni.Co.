
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
[System.Xml.Serialization.XmlRoot("dsmeta_salrendicontattivitaprogettoora_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_salrendicontattivitaprogettoora_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoorasegsalview 		=> (MetaTable)Tables["rendicontattivitaprogettoorasegsalview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable salrendicontattivitaprogettoora 		=> (MetaTable)Tables["salrendicontattivitaprogettoora"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_salrendicontattivitaprogettoora_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_salrendicontattivitaprogettoora_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_salrendicontattivitaprogettoora_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_salrendicontattivitaprogettoora_default.xsd";

	#region create DataTables
	//////////////////// RENDICONTATTIVITAPROGETTOORASEGSALVIEW /////////////////////////////////
	var trendicontattivitaprogettoorasegsalview= new MetaTable("rendicontattivitaprogettoorasegsalview");
	trendicontattivitaprogettoorasegsalview.defineColumn("dropdown_title", typeof(string),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("registry_title", typeof(string));
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogetto_description", typeof(string));
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogetto_idreg", typeof(int));
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_ct", typeof(DateTime),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_cu", typeof(string),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_data", typeof(DateTime));
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_idsal", typeof(int));
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_lt", typeof(DateTime),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_lu", typeof(string),false);
	trendicontattivitaprogettoorasegsalview.defineColumn("rendicontattivitaprogettoora_ore", typeof(int));
	trendicontattivitaprogettoorasegsalview.defineColumn("sal_start", typeof(DateTime));
	trendicontattivitaprogettoorasegsalview.defineColumn("sal_stop", typeof(DateTime));
	trendicontattivitaprogettoorasegsalview.defineColumn("workpackage_raggruppamento", typeof(string));
	trendicontattivitaprogettoorasegsalview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(trendicontattivitaprogettoorasegsalview);
	trendicontattivitaprogettoorasegsalview.defineKey("idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// SALRENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var tsalrendicontattivitaprogettoora= new MetaTable("salrendicontattivitaprogettoora");
	tsalrendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	tsalrendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	tsalrendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	tsalrendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	tsalrendicontattivitaprogettoora.defineColumn("idsal", typeof(int),false);
	tsalrendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	tsalrendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	Tables.Add(tsalrendicontattivitaprogettoora);
	tsalrendicontattivitaprogettoora.defineKey("idprogetto", "idrendicontattivitaprogettoora", "idsal");

	#endregion


	#region DataRelation creation
	var cPar = new []{rendicontattivitaprogettoorasegsalview.Columns["idrendicontattivitaprogettoora"]};
	var cChild = new []{salrendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	Relations.Add(new DataRelation("FK_salrendicontattivitaprogettoora_rendicontattivitaprogettoorasegsalview_idrendicontattivitaprogettoora",cPar,cChild,false));

	#endregion

}
}
}
