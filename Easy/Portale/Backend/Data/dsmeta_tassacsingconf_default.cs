
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
[System.Xml.Serialization.XmlRoot("dsmeta_tassacsingconf_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tassacsingconf_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef_alias2 		=> (MetaTable)Tables["costoscontodef_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef_alias1 		=> (MetaTable)Tables["costoscontodef_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassacsingconf 		=> (MetaTable)Tables["tassacsingconf"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tassacsingconf_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tassacsingconf_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tassacsingconf_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tassacsingconf_default.xsd";

	#region create DataTables
	//////////////////// COSTOSCONTODEF_ALIAS2 /////////////////////////////////
	var tcostoscontodef_alias2= new MetaTable("costoscontodef_alias2");
	tcostoscontodef_alias2.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef_alias2.defineColumn("title", typeof(string));
	tcostoscontodef_alias2.ExtendedProperties["TableForReading"]="costoscontodef";
	Tables.Add(tcostoscontodef_alias2);
	tcostoscontodef_alias2.defineKey("idcostoscontodef");

	//////////////////// COSTOSCONTODEF_ALIAS1 /////////////////////////////////
	var tcostoscontodef_alias1= new MetaTable("costoscontodef_alias1");
	tcostoscontodef_alias1.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef_alias1.defineColumn("title", typeof(string));
	tcostoscontodef_alias1.ExtendedProperties["TableForReading"]="costoscontodef";
	Tables.Add(tcostoscontodef_alias1);
	tcostoscontodef_alias1.defineKey("idcostoscontodef");

	//////////////////// COSTOSCONTODEF /////////////////////////////////
	var tcostoscontodef= new MetaTable("costoscontodef");
	tcostoscontodef.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodef);
	tcostoscontodef.defineKey("idcostoscontodef");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// TASSACSINGCONF /////////////////////////////////
	var ttassacsingconf= new MetaTable("tassacsingconf");
	ttassacsingconf.defineColumn("aa", typeof(string));
	ttassacsingconf.defineColumn("costomax", typeof(decimal));
	ttassacsingconf.defineColumn("ct", typeof(DateTime),false);
	ttassacsingconf.defineColumn("cu", typeof(string),false);
	ttassacsingconf.defineColumn("idcostoscontodef", typeof(int));
	ttassacsingconf.defineColumn("idcostoscontodef_2", typeof(int));
	ttassacsingconf.defineColumn("idcostoscontodef_sconto", typeof(int));
	ttassacsingconf.defineColumn("idtassacsingconf", typeof(int),false);
	ttassacsingconf.defineColumn("lt", typeof(DateTime),false);
	ttassacsingconf.defineColumn("lu", typeof(string),false);
	ttassacsingconf.defineColumn("numerosconto", typeof(int));
	Tables.Add(ttassacsingconf);
	ttassacsingconf.defineKey("idtassacsingconf");

	#endregion


	#region DataRelation creation
	var cPar = new []{costoscontodef_alias2.Columns["idcostoscontodef"]};
	var cChild = new []{tassacsingconf.Columns["idcostoscontodef_sconto"]};
	Relations.Add(new DataRelation("FK_tassacsingconf_costoscontodef_alias2_idcostoscontodef_sconto",cPar,cChild,false));

	cPar = new []{costoscontodef_alias1.Columns["idcostoscontodef"]};
	cChild = new []{tassacsingconf.Columns["idcostoscontodef_2"]};
	Relations.Add(new DataRelation("FK_tassacsingconf_costoscontodef_alias1_idcostoscontodef_2",cPar,cChild,false));

	cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	cChild = new []{tassacsingconf.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_tassacsingconf_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{tassacsingconf.Columns["aa"]};
	Relations.Add(new DataRelation("FK_tassacsingconf_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
