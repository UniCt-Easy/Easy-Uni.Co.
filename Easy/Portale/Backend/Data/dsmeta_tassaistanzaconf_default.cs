
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
[System.Xml.Serialization.XmlRoot("dsmeta_tassaistanzaconf_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tassaistanzaconf_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istanzakinddefaultview 		=> (MetaTable)Tables["istanzakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassaistanzaconf 		=> (MetaTable)Tables["tassaistanzaconf"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tassaistanzaconf_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tassaistanzaconf_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tassaistanzaconf_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tassaistanzaconf_default.xsd";

	#region create DataTables
	//////////////////// ISTANZAKINDDEFAULTVIEW /////////////////////////////////
	var tistanzakinddefaultview= new MetaTable("istanzakinddefaultview");
	tistanzakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tistanzakinddefaultview.defineColumn("idistanzakind", typeof(int),false);
	Tables.Add(tistanzakinddefaultview);
	tistanzakinddefaultview.defineKey("idistanzakind");

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

	//////////////////// TASSAISTANZACONF /////////////////////////////////
	var ttassaistanzaconf= new MetaTable("tassaistanzaconf");
	ttassaistanzaconf.defineColumn("aa", typeof(string),false);
	ttassaistanzaconf.defineColumn("ct", typeof(DateTime),false);
	ttassaistanzaconf.defineColumn("cu", typeof(string),false);
	ttassaistanzaconf.defineColumn("idcostoscontodef", typeof(int),false);
	ttassaistanzaconf.defineColumn("idistanzakind", typeof(int),false);
	ttassaistanzaconf.defineColumn("idtassaistanzaconf", typeof(int),false);
	ttassaistanzaconf.defineColumn("lt", typeof(DateTime),false);
	ttassaistanzaconf.defineColumn("lu", typeof(string),false);
	ttassaistanzaconf.defineColumn("nullaosta", typeof(string));
	Tables.Add(ttassaistanzaconf);
	ttassaistanzaconf.defineKey("idtassaistanzaconf");

	#endregion


	#region DataRelation creation
	var cPar = new []{istanzakinddefaultview.Columns["idistanzakind"]};
	var cChild = new []{tassaistanzaconf.Columns["idistanzakind"]};
	Relations.Add(new DataRelation("FK_tassaistanzaconf_istanzakinddefaultview_idistanzakind",cPar,cChild,false));

	cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	cChild = new []{tassaistanzaconf.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_tassaistanzaconf_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{tassaistanzaconf.Columns["aa"]};
	Relations.Add(new DataRelation("FK_tassaistanzaconf_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
