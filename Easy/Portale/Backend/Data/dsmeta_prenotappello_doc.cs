/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_prenotappello_doc"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_prenotappello_doc: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pianostudioattivformprenotview 		=> (MetaTable)Tables["pianostudioattivformprenotview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prenotappello 		=> (MetaTable)Tables["prenotappello"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_prenotappello_doc(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_prenotappello_doc (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_prenotappello_doc";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_prenotappello_doc.xsd";

	#region create DataTables
	//////////////////// PIANOSTUDIOATTIVFORMPRENOTVIEW /////////////////////////////////
	var tpianostudioattivformprenotview= new MetaTable("pianostudioattivformprenotview");
	tpianostudioattivformprenotview.defineColumn("attivformscelta_idinsegn", typeof(int));
	tpianostudioattivformprenotview.defineColumn("attivformscelta_idinsegninteg", typeof(int));
	tpianostudioattivformprenotview.defineColumn("attivformscelta_tipovalutaz", typeof(string));
	tpianostudioattivformprenotview.defineColumn("attivformscelta_title", typeof(string));
	tpianostudioattivformprenotview.defineColumn("dropdown_title", typeof(string),false);
	tpianostudioattivformprenotview.defineColumn("idattivform_scelta", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("idcorsostudio", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("iddidprog", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("idiscrizione", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("idpianostudio", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("idpianostudioattivform", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("idreg", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("idsostenimento", typeof(int));
	tpianostudioattivformprenotview.defineColumn("insegn_codice", typeof(string));
	tpianostudioattivformprenotview.defineColumn("insegn_denominazione", typeof(string));
	tpianostudioattivformprenotview.defineColumn("insegninteg_codice", typeof(string));
	tpianostudioattivformprenotview.defineColumn("insegninteg_denominazione", typeof(string));
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_anno", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_ct", typeof(DateTime),false);
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_cu", typeof(string),false);
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_idattivform", typeof(int),false);
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_idiscrizionebmi", typeof(int));
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_lt", typeof(DateTime),false);
	tpianostudioattivformprenotview.defineColumn("pianostudioattivform_lu", typeof(string),false);
	tpianostudioattivformprenotview.defineColumn("registry_title", typeof(string));
	tpianostudioattivformprenotview.defineColumn("sostenimento_idreg", typeof(int));
	tpianostudioattivformprenotview.defineColumn("sostenimento_voto", typeof(decimal));
	tpianostudioattivformprenotview.defineColumn("sostenimento_votolode", typeof(string));
	tpianostudioattivformprenotview.defineColumn("sostenimento_votosu", typeof(int));
	Tables.Add(tpianostudioattivformprenotview);
	tpianostudioattivformprenotview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idreg");

	//////////////////// PRENOTAPPELLO /////////////////////////////////
	var tprenotappello= new MetaTable("prenotappello");
	tprenotappello.defineColumn("ct", typeof(DateTime),false);
	tprenotappello.defineColumn("cu", typeof(string),false);
	tprenotappello.defineColumn("data", typeof(DateTime),false);
	tprenotappello.defineColumn("idappello", typeof(int),false);
	tprenotappello.defineColumn("idattivform", typeof(int),false);
	tprenotappello.defineColumn("idiscrizione", typeof(int),false);
	tprenotappello.defineColumn("idpianostudio", typeof(int),false);
	tprenotappello.defineColumn("idpianostudioattivform", typeof(int),false);
	tprenotappello.defineColumn("idprenotappello", typeof(int),false);
	tprenotappello.defineColumn("idprova", typeof(int),false);
	tprenotappello.defineColumn("idreg", typeof(int),false);
	tprenotappello.defineColumn("lt", typeof(DateTime),false);
	tprenotappello.defineColumn("lu", typeof(string),false);
	Tables.Add(tprenotappello);
	tprenotappello.defineKey("idappello", "idattivform", "idiscrizione", "idpianostudio", "idpianostudioattivform", "idprenotappello", "idprova", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pianostudioattivformprenotview.Columns["idpianostudioattivform"]};
	var cChild = new []{prenotappello.Columns["idpianostudioattivform"]};
	Relations.Add(new DataRelation("FK_prenotappello_pianostudioattivformprenotview_idpianostudioattivform",cPar,cChild,false));

	#endregion

}
}
}
