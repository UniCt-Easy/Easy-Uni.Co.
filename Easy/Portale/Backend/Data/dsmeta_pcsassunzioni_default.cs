
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
[System.Xml.Serialization.XmlRoot("dsmeta_pcsassunzioni_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_pcsassunzioni_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcontrattikindview 		=> (MetaTable)Tables["getcontrattikindview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasddefaultview 		=> (MetaTable)Tables["sasddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview_alias1 		=> (MetaTable)Tables["contrattokinddefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokinddefaultview 		=> (MetaTable)Tables["contrattokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pcsassunzioni 		=> (MetaTable)Tables["pcsassunzioni"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pcsassunzioni_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pcsassunzioni_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pcsassunzioni_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pcsassunzioni_default.xsd";

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

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// SASDDEFAULTVIEW /////////////////////////////////
	var tsasddefaultview= new MetaTable("sasddefaultview");
	tsasddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsasddefaultview.defineColumn("idareadidattica", typeof(int));
	tsasddefaultview.defineColumn("idsasd", typeof(int),false);
	Tables.Add(tsasddefaultview);
	tsasddefaultview.defineKey("idsasd");

	//////////////////// CONTRATTOKINDDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tcontrattokinddefaultview_alias1= new MetaTable("contrattokinddefaultview_alias1");
	tcontrattokinddefaultview_alias1.defineColumn("contrattokind_active", typeof(string));
	tcontrattokinddefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tcontrattokinddefaultview_alias1.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokinddefaultview_alias1.ExtendedProperties["TableForReading"]="contrattokinddefaultview";
	Tables.Add(tcontrattokinddefaultview_alias1);
	tcontrattokinddefaultview_alias1.defineKey("idcontrattokind");

	//////////////////// CONTRATTOKINDDEFAULTVIEW /////////////////////////////////
	var tcontrattokinddefaultview= new MetaTable("contrattokinddefaultview");
	tcontrattokinddefaultview.defineColumn("contrattokind_active", typeof(string));
	tcontrattokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcontrattokinddefaultview.defineColumn("idcontrattokind", typeof(int),false);
	Tables.Add(tcontrattokinddefaultview);
	tcontrattokinddefaultview.defineKey("idcontrattokind");

	//////////////////// PCSASSUNZIONI /////////////////////////////////
	var tpcsassunzioni= new MetaTable("pcsassunzioni");
	tpcsassunzioni.defineColumn("ct", typeof(DateTime),false);
	tpcsassunzioni.defineColumn("cu", typeof(string),false);
	tpcsassunzioni.defineColumn("data", typeof(DateTime));
	tpcsassunzioni.defineColumn("finanziamento", typeof(string));
	tpcsassunzioni.defineColumn("idcontrattokind", typeof(int));
	tpcsassunzioni.defineColumn("idcontrattokind_start", typeof(int));
	tpcsassunzioni.defineColumn("idpcsassunzioni", typeof(int),false);
	tpcsassunzioni.defineColumn("idsasd", typeof(int));
	tpcsassunzioni.defineColumn("idstruttura", typeof(int));
	tpcsassunzioni.defineColumn("legge", typeof(string));
	tpcsassunzioni.defineColumn("lt", typeof(DateTime),false);
	tpcsassunzioni.defineColumn("lu", typeof(string),false);
	tpcsassunzioni.defineColumn("nominativo", typeof(string));
	tpcsassunzioni.defineColumn("numeropersoneassunzione", typeof(decimal));
	tpcsassunzioni.defineColumn("percentuale", typeof(decimal));
	tpcsassunzioni.defineColumn("stipendio", typeof(decimal));
	tpcsassunzioni.defineColumn("totale", typeof(decimal));
	tpcsassunzioni.defineColumn("totale1", typeof(decimal));
	tpcsassunzioni.defineColumn("totale2", typeof(decimal));
	tpcsassunzioni.defineColumn("totale3", typeof(decimal));
	tpcsassunzioni.defineColumn("year", typeof(int),false);
	Tables.Add(tpcsassunzioni);
	tpcsassunzioni.defineKey("idpcsassunzioni", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	var cChild = new []{pcsassunzioni.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{sasddefaultview.Columns["idsasd"]};
	cChild = new []{pcsassunzioni.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_sasddefaultview_idsasd",cPar,cChild,false));

	cPar = new []{contrattokinddefaultview_alias1.Columns["idcontrattokind"]};
	cChild = new []{pcsassunzioni.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_contrattokinddefaultview_alias1_idcontrattokind",cPar,cChild,false));

	cPar = new []{contrattokinddefaultview.Columns["idcontrattokind"]};
	cChild = new []{pcsassunzioni.Columns["idcontrattokind_start"]};
	Relations.Add(new DataRelation("FK_pcsassunzioni_contrattokinddefaultview_idcontrattokind_start",cPar,cChild,false));

	#endregion

}
}
}
