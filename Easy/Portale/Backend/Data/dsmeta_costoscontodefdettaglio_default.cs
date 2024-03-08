
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
[System.Xml.Serialization.XmlRoot("dsmeta_costoscontodefdettaglio_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_costoscontodefdettaglio_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettagliokind 		=> (MetaTable)Tables["costoscontodefdettagliokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettaglio 		=> (MetaTable)Tables["costoscontodefdettaglio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_costoscontodefdettaglio_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_costoscontodefdettaglio_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_costoscontodefdettaglio_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_costoscontodefdettaglio_default.xsd";

	#region create DataTables
	//////////////////// COSTOSCONTODEFDETTAGLIOKIND /////////////////////////////////
	var tcostoscontodefdettagliokind= new MetaTable("costoscontodefdettagliokind");
	tcostoscontodefdettagliokind.defineColumn("idcostoscontodefdettagliokind", typeof(int),false);
	tcostoscontodefdettagliokind.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodefdettagliokind);
	tcostoscontodefdettagliokind.defineKey("idcostoscontodefdettagliokind");

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
	var cPar = new []{costoscontodefdettagliokind.Columns["idcostoscontodefdettagliokind"]};
	var cChild = new []{costoscontodefdettaglio.Columns["idcostoscontodefdettagliokind"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_costoscontodefdettagliokind_idcostoscontodefdettagliokind",cPar,cChild,false));

	#endregion

}
}
}
