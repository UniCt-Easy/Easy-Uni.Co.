
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
[System.Xml.Serialization.XmlRoot("dsmeta_fasciaiseedef_sconti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_fasciaiseedef_sconti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratakind 		=> (MetaTable)Tables["ratakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratadef 		=> (MetaTable)Tables["ratadef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fasciaisee 		=> (MetaTable)Tables["fasciaisee"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable fasciaiseedef 		=> (MetaTable)Tables["fasciaiseedef"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_fasciaiseedef_sconti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_fasciaiseedef_sconti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_fasciaiseedef_sconti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_fasciaiseedef_sconti.xsd";

	#region create DataTables
	//////////////////// RATAKIND /////////////////////////////////
	var tratakind= new MetaTable("ratakind");
	tratakind.defineColumn("idratakind", typeof(string),false);
	tratakind.defineColumn("title", typeof(string));
	Tables.Add(tratakind);
	tratakind.defineKey("idratakind");

	//////////////////// RATADEF /////////////////////////////////
	var tratadef= new MetaTable("ratadef");
	tratadef.defineColumn("ct", typeof(DateTime),false);
	tratadef.defineColumn("cu", typeof(string),false);
	tratadef.defineColumn("decorrenza", typeof(DateTime));
	tratadef.defineColumn("idcostoscontodef", typeof(int),false);
	tratadef.defineColumn("idfasciaiseedef", typeof(int),false);
	tratadef.defineColumn("idratadef", typeof(int),false);
	tratadef.defineColumn("idratakind", typeof(string));
	tratadef.defineColumn("lt", typeof(DateTime),false);
	tratadef.defineColumn("lu", typeof(string),false);
	tratadef.defineColumn("scadenza", typeof(DateTime));
	Tables.Add(tratadef);
	tratadef.defineKey("idcostoscontodef", "idfasciaiseedef", "idratadef");

	//////////////////// FASCIAISEE /////////////////////////////////
	var tfasciaisee= new MetaTable("fasciaisee");
	tfasciaisee.defineColumn("idfasciaisee", typeof(string),false);
	tfasciaisee.defineColumn("title", typeof(string));
	Tables.Add(tfasciaisee);
	tfasciaisee.defineKey("idfasciaisee");

	//////////////////// FASCIAISEEDEF /////////////////////////////////
	var tfasciaiseedef= new MetaTable("fasciaiseedef");
	tfasciaiseedef.defineColumn("ct", typeof(DateTime),false);
	tfasciaiseedef.defineColumn("cu", typeof(string),false);
	tfasciaiseedef.defineColumn("idcostoscontodef", typeof(int),false);
	tfasciaiseedef.defineColumn("idfasciaisee", typeof(string),false);
	tfasciaiseedef.defineColumn("idfasciaiseedef", typeof(int),false);
	tfasciaiseedef.defineColumn("lt", typeof(DateTime),false);
	tfasciaiseedef.defineColumn("lu", typeof(string),false);
	Tables.Add(tfasciaiseedef);
	tfasciaiseedef.defineKey("idcostoscontodef", "idfasciaiseedef");

	#endregion


	#region DataRelation creation
	var cPar = new []{fasciaiseedef.Columns["idcostoscontodef"], fasciaiseedef.Columns["idfasciaiseedef"]};
	var cChild = new []{ratadef.Columns["idcostoscontodef"], ratadef.Columns["idfasciaiseedef"]};
	Relations.Add(new DataRelation("FK_ratadef_fasciaiseedef_idcostoscontodef-idfasciaiseedef",cPar,cChild,false));

	cPar = new []{ratakind.Columns["idratakind"]};
	cChild = new []{ratadef.Columns["idratakind"]};
	Relations.Add(new DataRelation("FK_ratadef_ratakind_idratakind",cPar,cChild,false));

	cPar = new []{fasciaisee.Columns["idfasciaisee"]};
	cChild = new []{fasciaiseedef.Columns["idfasciaisee"]};
	Relations.Add(new DataRelation("FK_fasciaiseedef_fasciaisee_idfasciaisee",cPar,cChild,false));

	#endregion

}
}
}
