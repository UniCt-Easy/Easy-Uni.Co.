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
[System.Xml.Serialization.XmlRoot("dsmeta_esonerocostoscontodef_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_esonerocostoscontodef_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerodefaultview 		=> (MetaTable)Tables["esonerodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefscontiview 		=> (MetaTable)Tables["costoscontodefscontiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerocostoscontodef 		=> (MetaTable)Tables["esonerocostoscontodef"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_esonerocostoscontodef_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_esonerocostoscontodef_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_esonerocostoscontodef_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_esonerocostoscontodef_default.xsd";

	#region create DataTables
	//////////////////// ESONERODEFAULTVIEW /////////////////////////////////
	var tesonerodefaultview= new MetaTable("esonerodefaultview");
	tesonerodefaultview.defineColumn("aa", typeof(string),false);
	tesonerodefaultview.defineColumn("costoscontodef_title", typeof(string));
	tesonerodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tesonerodefaultview.defineColumn("esonero_applunavolta", typeof(string));
	tesonerodefaultview.defineColumn("esonero_ct", typeof(DateTime),false);
	tesonerodefaultview.defineColumn("esonero_cu", typeof(string),false);
	tesonerodefaultview.defineColumn("esonero_description", typeof(string));
	tesonerodefaultview.defineColumn("esonero_idesoneroanskind", typeof(int));
	tesonerodefaultview.defineColumn("esonero_lt", typeof(DateTime),false);
	tesonerodefaultview.defineColumn("esonero_lu", typeof(string),false);
	tesonerodefaultview.defineColumn("esonero_retroattivo", typeof(string));
	tesonerodefaultview.defineColumn("esonero_soloconisee", typeof(string));
	tesonerodefaultview.defineColumn("esoneroanskind_description", typeof(string));
	tesonerodefaultview.defineColumn("esoneroanskind_title", typeof(string));
	tesonerodefaultview.defineColumn("idcostoscontodef", typeof(int),false);
	tesonerodefaultview.defineColumn("idesonero", typeof(int),false);
	tesonerodefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tesonerodefaultview);
	tesonerodefaultview.defineKey("idesonero");

	//////////////////// COSTOSCONTODEFSCONTIVIEW /////////////////////////////////
	var tcostoscontodefscontiview= new MetaTable("costoscontodefscontiview");
	tcostoscontodefscontiview.defineColumn("costoscontodef_ct", typeof(DateTime));
	tcostoscontodefscontiview.defineColumn("costoscontodef_cu", typeof(string));
	tcostoscontodefscontiview.defineColumn("costoscontodef_idcostoscontodefkind", typeof(int),false);
	tcostoscontodefscontiview.defineColumn("costoscontodef_lt", typeof(DateTime));
	tcostoscontodefscontiview.defineColumn("costoscontodef_lu", typeof(string));
	tcostoscontodefscontiview.defineColumn("costoscontodefparent_title", typeof(string));
	tcostoscontodefscontiview.defineColumn("dropdown_title", typeof(string),false);
	tcostoscontodefscontiview.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodefscontiview.defineColumn("paridcostoscontodef", typeof(int));
	tcostoscontodefscontiview.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodefscontiview);
	tcostoscontodefscontiview.defineKey("idcostoscontodef");

	//////////////////// ESONEROCOSTOSCONTODEF /////////////////////////////////
	var tesonerocostoscontodef= new MetaTable("esonerocostoscontodef");
	tesonerocostoscontodef.defineColumn("ct", typeof(DateTime),false);
	tesonerocostoscontodef.defineColumn("cu", typeof(string),false);
	tesonerocostoscontodef.defineColumn("idcostoscontodef", typeof(int),false);
	tesonerocostoscontodef.defineColumn("idesonero", typeof(int),false);
	tesonerocostoscontodef.defineColumn("lt", typeof(DateTime),false);
	tesonerocostoscontodef.defineColumn("lu", typeof(string),false);
	Tables.Add(tesonerocostoscontodef);
	tesonerocostoscontodef.defineKey("idcostoscontodef", "idesonero");

	#endregion


	#region DataRelation creation
	var cPar = new []{esonerodefaultview.Columns["idesonero"]};
	var cChild = new []{esonerocostoscontodef.Columns["idesonero"]};
	Relations.Add(new DataRelation("FK_esonerocostoscontodef_esonerodefaultview_idesonero",cPar,cChild,false));

	cPar = new []{costoscontodefscontiview.Columns["idcostoscontodef"]};
	cChild = new []{esonerocostoscontodef.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_esonerocostoscontodef_costoscontodefscontiview_idcostoscontodef",cPar,cChild,false));

	#endregion

}
}
}
