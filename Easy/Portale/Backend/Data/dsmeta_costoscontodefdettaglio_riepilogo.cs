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
[System.Xml.Serialization.XmlRoot("dsmeta_costoscontodefdettaglio_riepilogo"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_costoscontodefdettaglio_riepilogo: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettagliokinddefaultview 		=> (MetaTable)Tables["costoscontodefdettagliokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratadefdefaultview 		=> (MetaTable)Tables["ratadefdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fasciaiseedefdefaultview 		=> (MetaTable)Tables["fasciaiseedefdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettaglio 		=> (MetaTable)Tables["costoscontodefdettaglio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_costoscontodefdettaglio_riepilogo(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_costoscontodefdettaglio_riepilogo (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_costoscontodefdettaglio_riepilogo";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_costoscontodefdettaglio_riepilogo.xsd";

	#region create DataTables
	//////////////////// COSTOSCONTODEFDETTAGLIOKINDDEFAULTVIEW /////////////////////////////////
	var tcostoscontodefdettagliokinddefaultview= new MetaTable("costoscontodefdettagliokinddefaultview");
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotive_codemotive", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotive_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotiveaccmotiveundotaxpost_costoscontodefdettagliokind_codemotive", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotiveaccmotiveundotaxpost_costoscontodefdettagliokind_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotiverevenue_costoscontodefdettagliokind_codemotive", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotiverevenue_costoscontodefdettagliokind_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotiveundotax_costoscontodefdettagliokind_codemotive", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("accmotiveundotax_costoscontodefdettagliokind_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("costoscontodefdettagliokind_active", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("costoscontodefdettagliokind_codice", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("costoscontodefdettagliokind_ct", typeof(DateTime));
	tcostoscontodefdettagliokinddefaultview.defineColumn("costoscontodefdettagliokind_cu", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("costoscontodefdettagliokind_lt", typeof(DateTime));
	tcostoscontodefdettagliokinddefaultview.defineColumn("costoscontodefdettagliokind_lu", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcostoscontodefdettagliokinddefaultview.defineColumn("finmotive_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("finmotiveiva_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idaccmotivecredit", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idaccmotiverevenue", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idaccmotiveundotax", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idaccmotiveundotaxpost", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idcostoscontodefdettagliokind", typeof(int),false);
	tcostoscontodefdettagliokinddefaultview.defineColumn("idfinmotive", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idfinmotive_iva", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("idtassonomia", typeof(int));
	tcostoscontodefdettagliokinddefaultview.defineColumn("tassonomia_pagopa_causale", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("tassonomia_pagopa_title", typeof(string));
	tcostoscontodefdettagliokinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodefdettagliokinddefaultview);
	tcostoscontodefdettagliokinddefaultview.defineKey("idcostoscontodefdettagliokind");

	//////////////////// RATADEFDEFAULTVIEW /////////////////////////////////
	var tratadefdefaultview= new MetaTable("ratadefdefaultview");
	tratadefdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tratadefdefaultview.defineColumn("idcostoscontodef", typeof(int),false);
	tratadefdefaultview.defineColumn("idfasciaiseedef", typeof(int),false);
	tratadefdefaultview.defineColumn("idratadef", typeof(int),false);
	Tables.Add(tratadefdefaultview);
	tratadefdefaultview.defineKey("idcostoscontodef", "idfasciaiseedef", "idratadef");

	//////////////////// FASCIAISEEDEFDEFAULTVIEW /////////////////////////////////
	var tfasciaiseedefdefaultview= new MetaTable("fasciaiseedefdefaultview");
	tfasciaiseedefdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tfasciaiseedefdefaultview.defineColumn("fasciaiseedef_ct", typeof(DateTime),false);
	tfasciaiseedefdefaultview.defineColumn("fasciaiseedef_cu", typeof(string),false);
	tfasciaiseedefdefaultview.defineColumn("fasciaiseedef_lt", typeof(DateTime),false);
	tfasciaiseedefdefaultview.defineColumn("fasciaiseedef_lu", typeof(string),false);
	tfasciaiseedefdefaultview.defineColumn("idcostoscontodef", typeof(int),false);
	tfasciaiseedefdefaultview.defineColumn("idfasciaisee", typeof(string),false);
	tfasciaiseedefdefaultview.defineColumn("idfasciaiseedef", typeof(int),false);
	Tables.Add(tfasciaiseedefdefaultview);
	tfasciaiseedefdefaultview.defineKey("idcostoscontodef", "idfasciaiseedef");

	//////////////////// COSTOSCONTODEFDETTAGLIO /////////////////////////////////
	var tcostoscontodefdettaglio= new MetaTable("costoscontodefdettaglio");
	tcostoscontodefdettaglio.defineColumn("ct", typeof(DateTime));
	tcostoscontodefdettaglio.defineColumn("cu", typeof(string));
	tcostoscontodefdettaglio.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idcostoscontodefdettaglio", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idcostoscontodefdettagliokind", typeof(int));
	tcostoscontodefdettaglio.defineColumn("idfasciaiseedef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idratadef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("importo", typeof(decimal));
	tcostoscontodefdettaglio.defineColumn("lt", typeof(DateTime));
	tcostoscontodefdettaglio.defineColumn("lu", typeof(string));
	tcostoscontodefdettaglio.defineColumn("parama", typeof(decimal));
	tcostoscontodefdettaglio.defineColumn("paramb", typeof(decimal));
	tcostoscontodefdettaglio.defineColumn("paramc", typeof(decimal));
	tcostoscontodefdettaglio.defineColumn("paramd", typeof(decimal));
	tcostoscontodefdettaglio.defineColumn("percentuale", typeof(decimal));
	Tables.Add(tcostoscontodefdettaglio);
	tcostoscontodefdettaglio.defineKey("idcostoscontodef", "idcostoscontodefdettaglio", "idfasciaiseedef", "idratadef");

	#endregion


	#region DataRelation creation
	var cPar = new []{costoscontodefdettagliokinddefaultview.Columns["idcostoscontodefdettagliokind"]};
	var cChild = new []{costoscontodefdettaglio.Columns["idcostoscontodefdettagliokind"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_costoscontodefdettagliokinddefaultview_idcostoscontodefdettagliokind",cPar,cChild,false));

	cPar = new []{ratadefdefaultview.Columns["idratadef"]};
	cChild = new []{costoscontodefdettaglio.Columns["idratadef"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_ratadefdefaultview_idratadef",cPar,cChild,false));

	cPar = new []{fasciaiseedefdefaultview.Columns["idfasciaiseedef"]};
	cChild = new []{ratadefdefaultview.Columns["idfasciaiseedef"]};
	Relations.Add(new DataRelation("FK_ratadefdefaultview_fasciaiseedefdefaultview_idfasciaiseedef",cPar,cChild,false));

	cPar = new []{fasciaiseedefdefaultview.Columns["idfasciaiseedef"]};
	cChild = new []{costoscontodefdettaglio.Columns["idfasciaiseedef"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_fasciaiseedefdefaultview_idfasciaiseedef",cPar,cChild,false));

	#endregion

}
}
}
