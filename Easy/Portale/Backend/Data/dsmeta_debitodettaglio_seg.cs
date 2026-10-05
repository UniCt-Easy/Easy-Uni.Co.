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
[System.Xml.Serialization.XmlRoot("dsmeta_debitodettaglio_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_debitodettaglio_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettaglio 		=> (MetaTable)Tables["costoscontodefdettaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debitodettaglio 		=> (MetaTable)Tables["debitodettaglio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_debitodettaglio_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_debitodettaglio_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_debitodettaglio_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_debitodettaglio_seg.xsd";

	#region create DataTables
	//////////////////// COSTOSCONTODEFDETTAGLIO /////////////////////////////////
	var tcostoscontodefdettaglio= new MetaTable("costoscontodefdettaglio");
	tcostoscontodefdettaglio.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idcostoscontodefdettaglio", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idcostoscontodefdettagliokind", typeof(int));
	tcostoscontodefdettaglio.defineColumn("idfasciaiseedef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("idratadef", typeof(int),false);
	tcostoscontodefdettaglio.defineColumn("importo", typeof(decimal));
	Tables.Add(tcostoscontodefdettaglio);
	tcostoscontodefdettaglio.defineKey("idcostoscontodef", "idcostoscontodefdettaglio", "idfasciaiseedef", "idratadef");

	//////////////////// COSTOSCONTODEF /////////////////////////////////
	var tcostoscontodef= new MetaTable("costoscontodef");
	tcostoscontodef.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodef);
	tcostoscontodef.defineKey("idcostoscontodef");

	//////////////////// DEBITODETTAGLIO /////////////////////////////////
	var tdebitodettaglio= new MetaTable("debitodettaglio");
	tdebitodettaglio.defineColumn("annulment", typeof(DateTime));
	tdebitodettaglio.defineColumn("ct", typeof(DateTime));
	tdebitodettaglio.defineColumn("cu", typeof(string));
	tdebitodettaglio.defineColumn("idcostoscontodef", typeof(int),false);
	tdebitodettaglio.defineColumn("idcostoscontodefdettaglio", typeof(int));
	tdebitodettaglio.defineColumn("iddebito", typeof(int),false);
	tdebitodettaglio.defineColumn("iddebitodettaglio", typeof(int),false);
	tdebitodettaglio.defineColumn("idflussocrediti", typeof(int));
	tdebitodettaglio.defineColumn("idflussocreditidetail", typeof(int));
	tdebitodettaglio.defineColumn("idreg", typeof(int),false);
	tdebitodettaglio.defineColumn("iduniqueformcode", typeof(string));
	tdebitodettaglio.defineColumn("importo", typeof(decimal));
	tdebitodettaglio.defineColumn("iuv", typeof(string));
	tdebitodettaglio.defineColumn("lt", typeof(DateTime));
	tdebitodettaglio.defineColumn("lu", typeof(string));
	Tables.Add(tdebitodettaglio);
	tdebitodettaglio.defineKey("iddebito", "iddebitodettaglio");

	#endregion


	#region DataRelation creation
	var cPar = new []{costoscontodefdettaglio.Columns["idcostoscontodefdettaglio"]};
	var cChild = new []{debitodettaglio.Columns["idcostoscontodefdettaglio"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_costoscontodefdettaglio_idcostoscontodefdettaglio",cPar,cChild,false));

	cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	cChild = new []{costoscontodefdettaglio.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	cChild = new []{debitodettaglio.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_debitodettaglio_costoscontodef_idcostoscontodef",cPar,cChild,false));

	#endregion

}
}
}
