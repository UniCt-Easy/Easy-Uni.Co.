
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
[System.Xml.Serialization.XmlRoot("dsmeta_insegn_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_insegn_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd_alias1 		=> (MetaTable)Tables["sasd_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegcaratteristica 		=> (MetaTable)Tables["insegnintegcaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegninteg 		=> (MetaTable)Tables["insegninteg"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sasd 		=> (MetaTable)Tables["sasd"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegncaratteristica 		=> (MetaTable)Tables["insegncaratteristica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokinddefaultview 		=> (MetaTable)Tables["corsostudiokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegn 		=> (MetaTable)Tables["insegn"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_insegn_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_insegn_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_insegn_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_insegn_default.xsd";

	#region create DataTables
	//////////////////// SASD_ALIAS1 /////////////////////////////////
	var tsasd_alias1= new MetaTable("sasd_alias1");
	tsasd_alias1.defineColumn("codice", typeof(string),false);
	tsasd_alias1.defineColumn("idsasd", typeof(int),false);
	tsasd_alias1.defineColumn("title", typeof(string),false);
	tsasd_alias1.ExtendedProperties["TableForReading"]="sasd";
	Tables.Add(tsasd_alias1);
	tsasd_alias1.defineKey("idsasd");

	//////////////////// INSEGNINTEGCARATTERISTICA /////////////////////////////////
	var tinsegnintegcaratteristica= new MetaTable("insegnintegcaratteristica");
	tinsegnintegcaratteristica.defineColumn("cf", typeof(decimal));
	tinsegnintegcaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("cu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idinsegnintegcaratteristica", typeof(int),false);
	tinsegnintegcaratteristica.defineColumn("idsasd", typeof(int));
	tinsegnintegcaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegnintegcaratteristica.defineColumn("lu", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("profess", typeof(string),false);
	tinsegnintegcaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tinsegnintegcaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	Tables.Add(tinsegnintegcaratteristica);
	tinsegnintegcaratteristica.defineKey("idinsegn", "idinsegninteg", "idinsegnintegcaratteristica");

	//////////////////// INSEGNINTEG /////////////////////////////////
	var tinsegninteg= new MetaTable("insegninteg");
	tinsegninteg.defineColumn("codice", typeof(string));
	tinsegninteg.defineColumn("ct", typeof(DateTime),false);
	tinsegninteg.defineColumn("cu", typeof(string),false);
	tinsegninteg.defineColumn("denominazione", typeof(string));
	tinsegninteg.defineColumn("denominazione_en", typeof(string));
	tinsegninteg.defineColumn("idinsegn", typeof(int),false);
	tinsegninteg.defineColumn("idinsegninteg", typeof(int),false);
	tinsegninteg.defineColumn("lt", typeof(DateTime),false);
	tinsegninteg.defineColumn("lu", typeof(string),false);
	tinsegninteg.defineColumn("!insegnintegcaratteristica", typeof(string));
	Tables.Add(tinsegninteg);
	tinsegninteg.defineKey("idinsegn", "idinsegninteg");

	//////////////////// SASD /////////////////////////////////
	var tsasd= new MetaTable("sasd");
	tsasd.defineColumn("codice", typeof(string),false);
	tsasd.defineColumn("idsasd", typeof(int),false);
	tsasd.defineColumn("title", typeof(string),false);
	Tables.Add(tsasd);
	tsasd.defineKey("idsasd");

	//////////////////// INSEGNCARATTERISTICA /////////////////////////////////
	var tinsegncaratteristica= new MetaTable("insegncaratteristica");
	tinsegncaratteristica.defineColumn("cf", typeof(decimal));
	tinsegncaratteristica.defineColumn("ct", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("cu", typeof(string),false);
	tinsegncaratteristica.defineColumn("idinsegn", typeof(int),false);
	tinsegncaratteristica.defineColumn("idinsegncaratteristica", typeof(int),false);
	tinsegncaratteristica.defineColumn("idsasd", typeof(int));
	tinsegncaratteristica.defineColumn("lt", typeof(DateTime),false);
	tinsegncaratteristica.defineColumn("lu", typeof(string),false);
	tinsegncaratteristica.defineColumn("profess", typeof(string),false);
	tinsegncaratteristica.defineColumn("!idsasd_sasd_codice", typeof(string));
	tinsegncaratteristica.defineColumn("!idsasd_sasd_title", typeof(string));
	Tables.Add(tinsegncaratteristica);
	tinsegncaratteristica.defineKey("idinsegn", "idinsegncaratteristica");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudiolivello", typeof(int));
	tcorsostudiodefaultview.defineColumn("idcorsostudionorma", typeof(int));
	tcorsostudiodefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// CORSOSTUDIOKINDDEFAULTVIEW /////////////////////////////////
	var tcorsostudiokinddefaultview= new MetaTable("corsostudiokinddefaultview");
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_active", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("idcorsostudiokind", typeof(int),false);
	Tables.Add(tcorsostudiokinddefaultview);
	tcorsostudiokinddefaultview.defineKey("idcorsostudiokind");

	//////////////////// INSEGN /////////////////////////////////
	var tinsegn= new MetaTable("insegn");
	tinsegn.defineColumn("codice", typeof(string));
	tinsegn.defineColumn("ct", typeof(DateTime),false);
	tinsegn.defineColumn("cu", typeof(string),false);
	tinsegn.defineColumn("denominazione", typeof(string));
	tinsegn.defineColumn("denominazione_en", typeof(string));
	tinsegn.defineColumn("idcorsostudio", typeof(int));
	tinsegn.defineColumn("idcorsostudiokind", typeof(int));
	tinsegn.defineColumn("idinsegn", typeof(int),false);
	tinsegn.defineColumn("idstruttura", typeof(int));
	tinsegn.defineColumn("lt", typeof(DateTime),false);
	tinsegn.defineColumn("lu", typeof(string),false);
	Tables.Add(tinsegn);
	tinsegn.defineKey("idinsegn");

	#endregion


	#region DataRelation creation
	var cPar = new []{insegn.Columns["idinsegn"]};
	var cChild = new []{insegninteg.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_insegninteg_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{insegninteg.Columns["idinsegn"], insegninteg.Columns["idinsegninteg"]};
	cChild = new []{insegnintegcaratteristica.Columns["idinsegn"], insegnintegcaratteristica.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_insegnintegcaratteristica_insegninteg_idinsegn-idinsegninteg",cPar,cChild,false));

	cPar = new []{sasd_alias1.Columns["idsasd"]};
	cChild = new []{insegnintegcaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_insegnintegcaratteristica_sasd_alias1_idsasd",cPar,cChild,false));

	cPar = new []{insegn.Columns["idinsegn"]};
	cChild = new []{insegncaratteristica.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_insegncaratteristica_insegn_idinsegn",cPar,cChild,false));

	cPar = new []{sasd.Columns["idsasd"]};
	cChild = new []{insegncaratteristica.Columns["idsasd"]};
	Relations.Add(new DataRelation("FK_insegncaratteristica_sasd_idsasd",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{insegn.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_insegn_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{insegn.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_insegn_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{corsostudiokinddefaultview.Columns["idcorsostudiokind"]};
	cChild = new []{insegn.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_insegn_corsostudiokinddefaultview_idcorsostudiokind",cPar,cChild,false));

	#endregion

}
}
}
