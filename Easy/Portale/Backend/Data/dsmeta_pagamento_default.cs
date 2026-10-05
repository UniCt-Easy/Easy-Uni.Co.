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
[System.Xml.Serialization.XmlRoot("dsmeta_pagamento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pagamento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamentokinddefaultview 		=> (MetaTable)Tables["pagamentokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pagamento 		=> (MetaTable)Tables["pagamento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pagamento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pagamento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pagamento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pagamento_default.xsd";

	#region create DataTables
	//////////////////// PAGAMENTOKINDDEFAULTVIEW /////////////////////////////////
	var tpagamentokinddefaultview= new MetaTable("pagamentokinddefaultview");
	tpagamentokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tpagamentokinddefaultview.defineColumn("idpagamentokind", typeof(int),false);
	tpagamentokinddefaultview.defineColumn("pagamentokind_active", typeof(string));
	tpagamentokinddefaultview.defineColumn("pagamentokind_ct", typeof(DateTime),false);
	tpagamentokinddefaultview.defineColumn("pagamentokind_cu", typeof(string),false);
	tpagamentokinddefaultview.defineColumn("pagamentokind_lt", typeof(DateTime),false);
	tpagamentokinddefaultview.defineColumn("pagamentokind_lu", typeof(string),false);
	tpagamentokinddefaultview.defineColumn("pagamentokind_sortcode", typeof(int),false);
	tpagamentokinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tpagamentokinddefaultview);
	tpagamentokinddefaultview.defineKey("idpagamentokind");

	//////////////////// PAGAMENTO /////////////////////////////////
	var tpagamento= new MetaTable("pagamento");
	tpagamento.defineColumn("ct", typeof(DateTime),false);
	tpagamento.defineColumn("cu", typeof(string),false);
	tpagamento.defineColumn("dataora", typeof(DateTime));
	tpagamento.defineColumn("iddebito", typeof(int),false);
	tpagamento.defineColumn("idpagamento", typeof(int),false);
	tpagamento.defineColumn("idpagamentokind", typeof(int));
	tpagamento.defineColumn("idreg", typeof(int),false);
	tpagamento.defineColumn("lt", typeof(DateTime),false);
	tpagamento.defineColumn("lu", typeof(string),false);
	Tables.Add(tpagamento);
	tpagamento.defineKey("iddebito", "idpagamento", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{pagamentokinddefaultview.Columns["idpagamentokind"]};
	var cChild = new []{pagamento.Columns["idpagamentokind"]};
	Relations.Add(new DataRelation("FK_pagamento_pagamentokinddefaultview_idpagamentokind",cPar,cChild,false));

	#endregion

}
}
}
