
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
[System.Xml.Serialization.XmlRoot("dsmeta_esonero_carriera"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_esonero_carriera: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esoneroanskind 		=> (MetaTable)Tables["esoneroanskind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodefscontiview 		=> (MetaTable)Tables["costoscontodefscontiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonero 		=> (MetaTable)Tables["esonero"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonero_carriera 		=> (MetaTable)Tables["esonero_carriera"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_esonero_carriera(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_esonero_carriera (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_esonero_carriera";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_esonero_carriera.xsd";

	#region create DataTables
	//////////////////// ESONEROANSKIND /////////////////////////////////
	var tesoneroanskind= new MetaTable("esoneroanskind");
	tesoneroanskind.defineColumn("description", typeof(string),false);
	tesoneroanskind.defineColumn("idesoneroanskind", typeof(int),false);
	tesoneroanskind.defineColumn("title", typeof(string),false);
	Tables.Add(tesoneroanskind);
	tesoneroanskind.defineKey("idesoneroanskind");

	//////////////////// COSTOSCONTODEFSCONTIVIEW /////////////////////////////////
	var tcostoscontodefscontiview= new MetaTable("costoscontodefscontiview");
	tcostoscontodefscontiview.defineColumn("dropdown_title", typeof(string),false);
	tcostoscontodefscontiview.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodefscontiview.defineColumn("paridcostoscontodef", typeof(int));
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

	//////////////////// ESONERO_CARRIERA /////////////////////////////////
	var tesonero_carriera= new MetaTable("esonero_carriera");
	tesonero_carriera.defineColumn("annofcmax", typeof(int));
	tesonero_carriera.defineColumn("annofcmin", typeof(int));
	tesonero_carriera.defineColumn("annoiscrmax", typeof(int));
	tesonero_carriera.defineColumn("annoiscrmin", typeof(int));
	tesonero_carriera.defineColumn("cfaaprecmax", typeof(decimal));
	tesonero_carriera.defineColumn("cfaaprecmin", typeof(decimal));
	tesonero_carriera.defineColumn("ct", typeof(DateTime),false);
	tesonero_carriera.defineColumn("cu", typeof(string),false);
	tesonero_carriera.defineColumn("idesonero", typeof(int),false);
	tesonero_carriera.defineColumn("lt", typeof(DateTime),false);
	tesonero_carriera.defineColumn("lu", typeof(string),false);
	tesonero_carriera.defineColumn("parttime", typeof(string));
	tesonero_carriera.defineColumn("tutticfaaprec", typeof(string));
	Tables.Add(tesonero_carriera);
	tesonero_carriera.defineKey("idesonero");

	#endregion


	#region DataRelation creation
	var cPar = new []{esoneroanskind.Columns["idesoneroanskind"]};
	var cChild = new []{esonero.Columns["idesoneroanskind"]};
	Relations.Add(new DataRelation("FK_esonero_esoneroanskind_idesoneroanskind",cPar,cChild,false));

	cPar = new []{costoscontodefscontiview.Columns["idcostoscontodef"]};
	cChild = new []{esonero.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_esonero_costoscontodefscontiview_idcostoscontodef",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{esonero.Columns["aa"]};
	Relations.Add(new DataRelation("FK_esonero_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{esonero.Columns["idesonero"]};
	cChild = new []{esonero_carriera.Columns["idesonero"]};
	Relations.Add(new DataRelation("FK_esonero_carriera_esonero_idesonero-",cPar,cChild,false));

	#endregion

}
}
}
