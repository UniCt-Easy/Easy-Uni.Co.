
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
[System.Xml.Serialization.XmlRoot("dsmeta_bandomipropedeut_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_bandomipropedeut_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegndefaultview 		=> (MetaTable)Tables["insegndefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomipropedeut 		=> (MetaTable)Tables["bandomipropedeut"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_bandomipropedeut_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_bandomipropedeut_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_bandomipropedeut_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_bandomipropedeut_seg.xsd";

	#region create DataTables
	//////////////////// INSEGNDEFAULTVIEW /////////////////////////////////
	var tinsegndefaultview= new MetaTable("insegndefaultview");
	tinsegndefaultview.defineColumn("corsostudio_title", typeof(string));
	tinsegndefaultview.defineColumn("corsostudiokind_title", typeof(string));
	tinsegndefaultview.defineColumn("denominazione", typeof(string));
	tinsegndefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegndefaultview.defineColumn("idcorsostudio", typeof(int));
	tinsegndefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegndefaultview.defineColumn("idstruttura", typeof(int));
	tinsegndefaultview.defineColumn("insegn_codice", typeof(string));
	tinsegndefaultview.defineColumn("insegn_ct", typeof(DateTime),false);
	tinsegndefaultview.defineColumn("insegn_cu", typeof(string),false);
	tinsegndefaultview.defineColumn("insegn_denominazione_en", typeof(string));
	tinsegndefaultview.defineColumn("insegn_idcorsostudiokind", typeof(int));
	tinsegndefaultview.defineColumn("insegn_lt", typeof(DateTime),false);
	tinsegndefaultview.defineColumn("insegn_lu", typeof(string),false);
	tinsegndefaultview.defineColumn("struttura_title", typeof(string));
	Tables.Add(tinsegndefaultview);
	tinsegndefaultview.defineKey("idinsegn");

	//////////////////// BANDOMIPROPEDEUT /////////////////////////////////
	var tbandomipropedeut= new MetaTable("bandomipropedeut");
	tbandomipropedeut.defineColumn("ct", typeof(DateTime),false);
	tbandomipropedeut.defineColumn("cu", typeof(string),false);
	tbandomipropedeut.defineColumn("idbandomi", typeof(int),false);
	tbandomipropedeut.defineColumn("idinsegn", typeof(int),false);
	tbandomipropedeut.defineColumn("lt", typeof(DateTime),false);
	tbandomipropedeut.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandomipropedeut);
	tbandomipropedeut.defineKey("idbandomi", "idinsegn");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_bandomipropedeut_insegndefaultview_idinsegn","insegndefaultview","bandomipropedeut","idinsegn");
	#endregion

}
}
}
