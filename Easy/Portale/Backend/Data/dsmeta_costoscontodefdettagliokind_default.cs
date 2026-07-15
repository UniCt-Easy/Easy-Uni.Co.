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
[System.Xml.Serialization.XmlRoot("dsmeta_costoscontodefdettagliokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_costoscontodefdettagliokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotivedefaultview_alias1 		=> (MetaTable)Tables["finmotivedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable finmotivedefaultview 		=> (MetaTable)Tables["finmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassonomia_pagopa 		=> (MetaTable)Tables["tassonomia_pagopa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias3 		=> (MetaTable)Tables["accmotivedefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias2 		=> (MetaTable)Tables["accmotivedefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias1 		=> (MetaTable)Tables["accmotivedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettagliokind 		=> (MetaTable)Tables["costoscontodefdettagliokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_costoscontodefdettagliokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_costoscontodefdettagliokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_costoscontodefdettagliokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_costoscontodefdettagliokind_default.xsd";

	#region create DataTables
	//////////////////// FINMOTIVEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tfinmotivedefaultview_alias1= new MetaTable("finmotivedefaultview_alias1");
	tfinmotivedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tfinmotivedefaultview_alias1.defineColumn("finmotive_active", typeof(string));
	tfinmotivedefaultview_alias1.defineColumn("idfinmotive", typeof(string),false);
	tfinmotivedefaultview_alias1.ExtendedProperties["TableForReading"]="finmotivedefaultview";
	Tables.Add(tfinmotivedefaultview_alias1);
	tfinmotivedefaultview_alias1.defineKey("idfinmotive");

	//////////////////// FINMOTIVEDEFAULTVIEW /////////////////////////////////
	var tfinmotivedefaultview= new MetaTable("finmotivedefaultview");
	tfinmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tfinmotivedefaultview.defineColumn("finmotive_active", typeof(string));
	tfinmotivedefaultview.defineColumn("idfinmotive", typeof(string),false);
	Tables.Add(tfinmotivedefaultview);
	tfinmotivedefaultview.defineKey("idfinmotive");

	//////////////////// TASSONOMIA_PAGOPA /////////////////////////////////
	var ttassonomia_pagopa= new MetaTable("tassonomia_pagopa");
	ttassonomia_pagopa.defineColumn("causale", typeof(string),false);
	ttassonomia_pagopa.defineColumn("idtassonomia", typeof(int),false);
	ttassonomia_pagopa.defineColumn("title", typeof(string));
	Tables.Add(ttassonomia_pagopa);
	ttassonomia_pagopa.defineKey("idtassonomia");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS3 /////////////////////////////////
	var taccmotivedefaultview_alias3= new MetaTable("accmotivedefaultview_alias3");
	taccmotivedefaultview_alias3.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias3.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias3.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias3);
	taccmotivedefaultview_alias3.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var taccmotivedefaultview_alias2= new MetaTable("accmotivedefaultview_alias2");
	taccmotivedefaultview_alias2.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias2.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias2.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias2);
	taccmotivedefaultview_alias2.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var taccmotivedefaultview_alias1= new MetaTable("accmotivedefaultview_alias1");
	taccmotivedefaultview_alias1.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias1.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias1.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias1);
	taccmotivedefaultview_alias1.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

	//////////////////// COSTOSCONTODEFDETTAGLIOKIND /////////////////////////////////
	var tcostoscontodefdettagliokind= new MetaTable("costoscontodefdettagliokind");
	tcostoscontodefdettagliokind.defineColumn("active", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("codice", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("ct", typeof(DateTime));
	tcostoscontodefdettagliokind.defineColumn("cu", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idaccmotivecredit", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idaccmotiverevenue", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idaccmotiveundotax", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idaccmotiveundotaxpost", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idcostoscontodefdettagliokind", typeof(int),false);
	tcostoscontodefdettagliokind.defineColumn("idfinmotive", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idfinmotive_iva", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("idtassonomia", typeof(int));
	tcostoscontodefdettagliokind.defineColumn("lt", typeof(DateTime));
	tcostoscontodefdettagliokind.defineColumn("lu", typeof(string));
	tcostoscontodefdettagliokind.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodefdettagliokind);
	tcostoscontodefdettagliokind.defineKey("idcostoscontodefdettagliokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{finmotivedefaultview_alias1.Columns["idfinmotive"]};
	var cChild = new []{costoscontodefdettagliokind.Columns["idfinmotive_iva"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_finmotivedefaultview_alias1_idfinmotive_iva",cPar,cChild,false));

	cPar = new []{finmotivedefaultview.Columns["idfinmotive"]};
	cChild = new []{costoscontodefdettagliokind.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_finmotivedefaultview_idfinmotive",cPar,cChild,false));

	cPar = new []{tassonomia_pagopa.Columns["idtassonomia"]};
	cChild = new []{costoscontodefdettagliokind.Columns["idtassonomia"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_tassonomia_pagopa_idtassonomia",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias3.Columns["idaccmotive"]};
	cChild = new []{costoscontodefdettagliokind.Columns["idaccmotiveundotaxpost"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_accmotivedefaultview_alias3_idaccmotiveundotaxpost",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias2.Columns["idaccmotive"]};
	cChild = new []{costoscontodefdettagliokind.Columns["idaccmotiveundotax"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_accmotivedefaultview_alias2_idaccmotiveundotax",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias1.Columns["idaccmotive"]};
	cChild = new []{costoscontodefdettagliokind.Columns["idaccmotiverevenue"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_accmotivedefaultview_alias1_idaccmotiverevenue",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{costoscontodefdettagliokind.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettagliokind_accmotivedefaultview_idaccmotivecredit",cPar,cChild,false));

	#endregion

}
}
}
