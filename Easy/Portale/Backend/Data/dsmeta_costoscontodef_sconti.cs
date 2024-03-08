
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
[System.Xml.Serialization.XmlRoot("dsmeta_costoscontodef_sconti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_costoscontodef_sconti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratadef 		=> (MetaTable)Tables["ratadef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fasciaiseedef 		=> (MetaTable)Tables["fasciaiseedef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettagliokind 		=> (MetaTable)Tables["costoscontodefdettagliokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefdettaglio 		=> (MetaTable)Tables["costoscontodefdettaglio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef_alias1 		=> (MetaTable)Tables["costoscontodef_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_costoscontodef_sconti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_costoscontodef_sconti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_costoscontodef_sconti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_costoscontodef_sconti.xsd";

	#region create DataTables
	//////////////////// RATADEF /////////////////////////////////
	var tratadef= new MetaTable("ratadef");
	tratadef.defineColumn("idcostoscontodef", typeof(int),false);
	tratadef.defineColumn("idfasciaiseedef", typeof(int),false);
	tratadef.defineColumn("idratadef", typeof(int),false);
	tratadef.defineColumn("idratakind", typeof(string));
	Tables.Add(tratadef);
	tratadef.defineKey("idcostoscontodef", "idfasciaiseedef", "idratadef");

	//////////////////// FASCIAISEEDEF /////////////////////////////////
	var tfasciaiseedef= new MetaTable("fasciaiseedef");
	tfasciaiseedef.defineColumn("idcostoscontodef", typeof(int),false);
	tfasciaiseedef.defineColumn("idfasciaisee", typeof(string),false);
	tfasciaiseedef.defineColumn("idfasciaiseedef", typeof(int),false);
	Tables.Add(tfasciaiseedef);
	tfasciaiseedef.defineKey("idcostoscontodef", "idfasciaiseedef");

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
	tcostoscontodefdettaglio.defineColumn("!idcostoscontodefdettagliokind_costoscontodefdettagliokind_title", typeof(string));
	tcostoscontodefdettaglio.defineColumn("!idfasciaiseedef_fasciaiseedef_idfasciaisee", typeof(string));
	tcostoscontodefdettaglio.defineColumn("!idratadef_ratadef_idratakind", typeof(string));
	Tables.Add(tcostoscontodefdettaglio);
	tcostoscontodefdettaglio.defineKey("idcostoscontodef", "idcostoscontodefdettaglio", "idfasciaiseedef", "idratadef");

	//////////////////// COSTOSCONTODEF_ALIAS1 /////////////////////////////////
	var tcostoscontodef_alias1= new MetaTable("costoscontodef_alias1");
	tcostoscontodef_alias1.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef_alias1.defineColumn("title", typeof(string));
	tcostoscontodef_alias1.ExtendedProperties["TableForReading"]="costoscontodef";
	Tables.Add(tcostoscontodef_alias1);
	tcostoscontodef_alias1.defineKey("idcostoscontodef");

	//////////////////// COSTOSCONTODEF /////////////////////////////////
	var tcostoscontodef= new MetaTable("costoscontodef");
	tcostoscontodef.defineColumn("ct", typeof(DateTime));
	tcostoscontodef.defineColumn("cu", typeof(string));
	tcostoscontodef.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef.defineColumn("idcostoscontodefkind", typeof(int),false);
	tcostoscontodef.defineColumn("lt", typeof(DateTime));
	tcostoscontodef.defineColumn("lu", typeof(string));
	tcostoscontodef.defineColumn("paridcostoscontodef", typeof(int));
	tcostoscontodef.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodef);
	tcostoscontodef.defineKey("idcostoscontodef");

	#endregion


	#region DataRelation creation
	var cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	var cChild = new []{costoscontodefdettaglio.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{ratadef.Columns["idratadef"]};
	cChild = new []{costoscontodefdettaglio.Columns["idratadef"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_ratadef_idratadef",cPar,cChild,false));

	cPar = new []{fasciaiseedef.Columns["idfasciaiseedef"]};
	cChild = new []{costoscontodefdettaglio.Columns["idfasciaiseedef"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_fasciaiseedef_idfasciaiseedef",cPar,cChild,false));

	cPar = new []{costoscontodefdettagliokind.Columns["idcostoscontodefdettagliokind"]};
	cChild = new []{costoscontodefdettaglio.Columns["idcostoscontodefdettagliokind"]};
	Relations.Add(new DataRelation("FK_costoscontodefdettaglio_costoscontodefdettagliokind_idcostoscontodefdettagliokind",cPar,cChild,false));

	cPar = new []{costoscontodef_alias1.Columns["idcostoscontodef"]};
	cChild = new []{costoscontodef.Columns["paridcostoscontodef"]};
	Relations.Add(new DataRelation("FK_costoscontodef_costoscontodef_alias1_paridcostoscontodef",cPar,cChild,false));

	#endregion

}
}
}
