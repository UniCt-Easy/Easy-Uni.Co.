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
[System.Xml.Serialization.XmlRoot("dsmeta_esonero_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_esonero_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esoneroanskinddefaultview 		=> (MetaTable)Tables["esoneroanskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefscontiview 		=> (MetaTable)Tables["costoscontodefscontiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonero 		=> (MetaTable)Tables["esonero"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_esonero_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_esonero_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_esonero_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_esonero_default.xsd";

	#region create DataTables
	//////////////////// ESONEROANSKINDDEFAULTVIEW /////////////////////////////////
	var tesoneroanskinddefaultview= new MetaTable("esoneroanskinddefaultview");
	tesoneroanskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_active", typeof(string));
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_ct", typeof(DateTime),false);
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_cu", typeof(string),false);
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_description", typeof(string),false);
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_lt", typeof(DateTime),false);
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_lu", typeof(string),false);
	tesoneroanskinddefaultview.defineColumn("esoneroanskind_sortcode", typeof(int),false);
	tesoneroanskinddefaultview.defineColumn("idesoneroanskind", typeof(int),false);
	tesoneroanskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tesoneroanskinddefaultview);
	tesoneroanskinddefaultview.defineKey("idesoneroanskind");

	//////////////////// COSTOSCONTODEFSCONTIVIEW /////////////////////////////////
	var tcostoscontodefscontiview= new MetaTable("costoscontodefscontiview");
	tcostoscontodefscontiview.defineColumn("dropdown_title", typeof(string),false);
	tcostoscontodefscontiview.defineColumn("idcostoscontodef", typeof(int),false);
	Tables.Add(tcostoscontodefscontiview);
	tcostoscontodefscontiview.defineKey("idcostoscontodef");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ESONERO /////////////////////////////////
	var tesonero= new MetaTable("esonero");
	tesonero.defineColumn("aa", typeof(string),false);
	tesonero.defineColumn("applunavolta", typeof(string));
	tesonero.defineColumn("ct", typeof(DateTime),false);
	tesonero.defineColumn("cu", typeof(string),false);
	tesonero.defineColumn("description", typeof(string));
	tesonero.defineColumn("idcostoscontodef", typeof(int),false);
	tesonero.defineColumn("idesonero", typeof(int),false);
	tesonero.defineColumn("idesoneroanskind", typeof(int));
	tesonero.defineColumn("lt", typeof(DateTime),false);
	tesonero.defineColumn("lu", typeof(string),false);
	tesonero.defineColumn("retroattivo", typeof(string));
	tesonero.defineColumn("soloconisee", typeof(string));
	tesonero.defineColumn("title", typeof(string),false);
	Tables.Add(tesonero);
	tesonero.defineKey("idesonero");

	#endregion


	#region DataRelation creation
	var cPar = new []{esoneroanskinddefaultview.Columns["idesoneroanskind"]};
	var cChild = new []{esonero.Columns["idesoneroanskind"]};
	Relations.Add(new DataRelation("FK_esonero_esoneroanskinddefaultview_idesoneroanskind",cPar,cChild,false));

	cPar = new []{costoscontodefscontiview.Columns["idcostoscontodef"]};
	cChild = new []{esonero.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_esonero_costoscontodefscontiview_idcostoscontodef",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{esonero.Columns["aa"]};
	Relations.Add(new DataRelation("FK_esonero_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
