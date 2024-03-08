
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
[System.Xml.Serialization.XmlRoot("dsmeta_tassaiscrizioneconf_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tassaiscrizioneconf_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias2 		=> (MetaTable)Tables["annoaccademico_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tassaiscrizioneconf 		=> (MetaTable)Tables["tassaiscrizioneconf"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tassaiscrizioneconf_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tassaiscrizioneconf_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tassaiscrizioneconf_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tassaiscrizioneconf_default.xsd";

	#region create DataTables
	//////////////////// COSTOSCONTODEF /////////////////////////////////
	var tcostoscontodef= new MetaTable("costoscontodef");
	tcostoscontodef.defineColumn("idcostoscontodef", typeof(int),false);
	tcostoscontodef.defineColumn("title", typeof(string));
	Tables.Add(tcostoscontodef);
	tcostoscontodef.defineKey("idcostoscontodef");

	//////////////////// ANNOACCADEMICO_ALIAS2 /////////////////////////////////
	var tannoaccademico_alias2= new MetaTable("annoaccademico_alias2");
	tannoaccademico_alias2.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias2.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias2);
	tannoaccademico_alias2.defineKey("aa");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// TASSAISCRIZIONECONF /////////////////////////////////
	var ttassaiscrizioneconf= new MetaTable("tassaiscrizioneconf");
	ttassaiscrizioneconf.defineColumn("aa", typeof(string),false);
	ttassaiscrizioneconf.defineColumn("aamax", typeof(string));
	ttassaiscrizioneconf.defineColumn("aamin", typeof(string));
	ttassaiscrizioneconf.defineColumn("annofcmax", typeof(int));
	ttassaiscrizioneconf.defineColumn("annofcmin", typeof(int));
	ttassaiscrizioneconf.defineColumn("annomax", typeof(int));
	ttassaiscrizioneconf.defineColumn("annomin", typeof(int));
	ttassaiscrizioneconf.defineColumn("codice_corsostudio", typeof(string));
	ttassaiscrizioneconf.defineColumn("codice_didprog", typeof(string));
	ttassaiscrizioneconf.defineColumn("codice_didprogcurr", typeof(string));
	ttassaiscrizioneconf.defineColumn("codice_didprogori", typeof(string));
	ttassaiscrizioneconf.defineColumn("corsisingoli", typeof(string),false);
	ttassaiscrizioneconf.defineColumn("ct", typeof(DateTime),false);
	ttassaiscrizioneconf.defineColumn("cu", typeof(string),false);
	ttassaiscrizioneconf.defineColumn("idcostoscontodef", typeof(int));
	ttassaiscrizioneconf.defineColumn("idtassaiscrizioneconf", typeof(int),false);
	ttassaiscrizioneconf.defineColumn("lt", typeof(DateTime),false);
	ttassaiscrizioneconf.defineColumn("lu", typeof(string),false);
	ttassaiscrizioneconf.defineColumn("title", typeof(string),false);
	Tables.Add(ttassaiscrizioneconf);
	ttassaiscrizioneconf.defineKey("idtassaiscrizioneconf");

	#endregion


	#region DataRelation creation
	var cPar = new []{costoscontodef.Columns["idcostoscontodef"]};
	var cChild = new []{tassaiscrizioneconf.Columns["idcostoscontodef"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_costoscontodef_idcostoscontodef",cPar,cChild,false));

	cPar = new []{annoaccademico_alias2.Columns["aa"]};
	cChild = new []{tassaiscrizioneconf.Columns["aamin"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_annoaccademico_alias2_aamin",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{tassaiscrizioneconf.Columns["aamax"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_annoaccademico_alias1_aamax",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{tassaiscrizioneconf.Columns["aa"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
