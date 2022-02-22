
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
[System.Xml.Serialization.XmlRoot("dsmeta_pcsassunzionisimulate_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_pcsassunzionisimulate_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcontrattikindview 		=> (MetaTable)Tables["getcontrattikindview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview 		=> (MetaTable)Tables["contrattokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcsassunzionisimulate 		=> (MetaTable)Tables["pcsassunzionisimulate"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pcsassunzionisimulate_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pcsassunzionisimulate_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pcsassunzionisimulate_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pcsassunzionisimulate_default.xsd";

	#region create DataTables
	//////////////////// GETCONTRATTIKINDVIEW /////////////////////////////////
	var tgetcontrattikindview= new MetaTable("getcontrattikindview");
	tgetcontrattikindview.defineColumn("costolordoannuo", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_ck", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_inq", typeof(decimal));
	tgetcontrattikindview.defineColumn("costolordoannuo_stip", typeof(decimal));
	tgetcontrattikindview.defineColumn("costomese", typeof(decimal));
	tgetcontrattikindview.defineColumn("costoora", typeof(decimal));
	tgetcontrattikindview.defineColumn("idcontrattokind", typeof(int),false);
	tgetcontrattikindview.defineColumn("oremaxdidatempoparziale", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxdidatempopieno", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxgg", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxtempoparziale", typeof(int));
	tgetcontrattikindview.defineColumn("oremaxtempopieno", typeof(int));
	tgetcontrattikindview.defineColumn("oremindidatempoparziale", typeof(int));
	tgetcontrattikindview.defineColumn("oremindidatempopieno", typeof(int));
	tgetcontrattikindview.defineColumn("parttime", typeof(string));
	tgetcontrattikindview.defineColumn("tempdef", typeof(string));
	tgetcontrattikindview.defineColumn("title", typeof(string),false);
	Tables.Add(tgetcontrattikindview);
	tgetcontrattikindview.defineKey("idcontrattokind");

	//////////////////// CONTRATTOKINDDEFAULTVIEW /////////////////////////////////
	var tcontrattokinddefaultview= new MetaTable("contrattokinddefaultview");
	tcontrattokinddefaultview.defineColumn("contrattokind_active", typeof(string));
	tcontrattokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("idcontrattokind", typeof(int),false);
	Tables.Add(tcontrattokinddefaultview);
	tcontrattokinddefaultview.defineKey("idcontrattokind");

	//////////////////// PCSASSUNZIONISIMULATE /////////////////////////////////
	var tpcsassunzionisimulate= new MetaTable("pcsassunzionisimulate");
	tpcsassunzionisimulate.defineColumn("ct", typeof(DateTime),false);
	tpcsassunzionisimulate.defineColumn("cu", typeof(string),false);
	tpcsassunzionisimulate.defineColumn("data", typeof(DateTime));
	tpcsassunzionisimulate.defineColumn("finanziamento", typeof(string));
	tpcsassunzionisimulate.defineColumn("idcontrattokind", typeof(int));
	tpcsassunzionisimulate.defineColumn("idcontrattokind_start", typeof(int));
	tpcsassunzionisimulate.defineColumn("idpcsassunzionisimulate", typeof(int),false);
	tpcsassunzionisimulate.defineColumn("idsasd", typeof(int));
	tpcsassunzionisimulate.defineColumn("idstruttura", typeof(int));
	tpcsassunzionisimulate.defineColumn("legge", typeof(string));
	tpcsassunzionisimulate.defineColumn("lt", typeof(DateTime),false);
	tpcsassunzionisimulate.defineColumn("lu", typeof(string),false);
	tpcsassunzionisimulate.defineColumn("nominativo", typeof(string));
	tpcsassunzionisimulate.defineColumn("numeropersoneassunzione", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("percentuale", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("stipendio", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale1", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale2", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("totale3", typeof(decimal));
	tpcsassunzionisimulate.defineColumn("year", typeof(int),false);
	Tables.Add(tpcsassunzionisimulate);
	tpcsassunzionisimulate.defineKey("idpcsassunzionisimulate", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	var cChild = new []{pcsassunzionisimulate.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_pcsassunzionisimulate_contrattokinddefaultview_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
