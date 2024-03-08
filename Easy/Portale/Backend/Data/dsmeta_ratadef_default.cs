
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
[System.Xml.Serialization.XmlRoot("dsmeta_ratadef_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ratadef_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratakinddefaultview 		=> (MetaTable)Tables["ratakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ratadef 		=> (MetaTable)Tables["ratadef"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ratadef_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ratadef_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ratadef_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ratadef_default.xsd";

	#region create DataTables
	//////////////////// RATAKINDDEFAULTVIEW /////////////////////////////////
	var tratakinddefaultview= new MetaTable("ratakinddefaultview");
	tratakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tratakinddefaultview.defineColumn("idratakind", typeof(string),false);
	Tables.Add(tratakinddefaultview);
	tratakinddefaultview.defineKey("idratakind");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{ratakinddefaultview.Columns["idratakind"]};
	var cChild = new []{ratadef.Columns["idratakind"]};
	Relations.Add(new DataRelation("FK_ratadef_ratakinddefaultview_idratakind",cPar,cChild,false));

	#endregion

}
}
}
