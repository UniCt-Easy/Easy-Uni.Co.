
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
[System.Xml.Serialization.XmlRoot("dsmeta_tassaconf_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tassaconf_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassaconfkinddefaultview 		=> (MetaTable)Tables["tassaconfkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassaconf 		=> (MetaTable)Tables["tassaconf"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tassaconf_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tassaconf_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tassaconf_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tassaconf_default.xsd";

	#region create DataTables
	//////////////////// TASSACONFKINDDEFAULTVIEW /////////////////////////////////
	var ttassaconfkinddefaultview= new MetaTable("tassaconfkinddefaultview");
	ttassaconfkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	ttassaconfkinddefaultview.defineColumn("idtassaconfkind", typeof(int),false);
	Tables.Add(ttassaconfkinddefaultview);
	ttassaconfkinddefaultview.defineKey("idtassaconfkind");

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

	//////////////////// TASSACONF /////////////////////////////////
	var ttassaconf= new MetaTable("tassaconf");
	ttassaconf.defineColumn("aa", typeof(string),false);
	ttassaconf.defineColumn("ct", typeof(DateTime),false);
	ttassaconf.defineColumn("cu", typeof(string),false);
	ttassaconf.defineColumn("idcostoscontodef", typeof(int),false);
	ttassaconf.defineColumn("idtassaconf", typeof(int),false);
	ttassaconf.defineColumn("idtassaconfkind", typeof(int),false);
	ttassaconf.defineColumn("lt", typeof(DateTime),false);
	ttassaconf.defineColumn("lu", typeof(string),false);
	ttassaconf.defineColumn("title", typeof(string));
	Tables.Add(ttassaconf);
	ttassaconf.defineKey("idtassaconf");

	#endregion


	#region DataRelation creation
	var cPar = new []{tassaconfkinddefaultview.Columns["idtassaconfkind"]};
	var cChild = new []{tassaconf.Columns["idtassaconfkind"]};
	Relations.Add(new DataRelation("FK_tassaconf_tassaconfkinddefaultview_idtassaconfkind",cPar,cChild,false));

	cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	cChild = new []{tassaconf.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_tassaconf_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{tassaconf.Columns["aa"]};
	Relations.Add(new DataRelation("FK_tassaconf_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
