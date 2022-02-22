
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
[System.Xml.Serialization.XmlRoot("dsmeta_classconsorsuale_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_classconsorsuale_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sede 		=> (MetaTable)Tables["sede"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogclassconsorsuale 		=> (MetaTable)Tables["didprogclassconsorsuale"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable classconsorsuale 		=> (MetaTable)Tables["classconsorsuale"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_classconsorsuale_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_classconsorsuale_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_classconsorsuale_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_classconsorsuale_default.xsd";

	#region create DataTables
	//////////////////// SEDE /////////////////////////////////
	var tsede= new MetaTable("sede");
	tsede.defineColumn("idsede", typeof(int),false);
	tsede.defineColumn("title", typeof(string));
	Tables.Add(tsede);
	tsede.defineKey("idsede");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("annosolare", typeof(int));
	tdidprog.defineColumn("attribdebiti", typeof(string));
	tdidprog.defineColumn("ciclo", typeof(int));
	tdidprog.defineColumn("codice", typeof(string));
	tdidprog.defineColumn("codicemiur", typeof(string));
	tdidprog.defineColumn("dataconsmaxiscr", typeof(DateTime));
	tdidprog.defineColumn("freqobbl", typeof(string));
	tdidprog.defineColumn("idareadidattica", typeof(int));
	tdidprog.defineColumn("idconvenzione", typeof(int));
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("iddidprognumchiusokind", typeof(int));
	tdidprog.defineColumn("iddidprogsuddannokind", typeof(int),false);
	tdidprog.defineColumn("iderogazkind", typeof(int));
	tdidprog.defineColumn("idgraduatoria", typeof(int));
	tdidprog.defineColumn("idnation_lang", typeof(int));
	tdidprog.defineColumn("idnation_lang2", typeof(int));
	tdidprog.defineColumn("idnation_langvis", typeof(int));
	tdidprog.defineColumn("idreg_docenti", typeof(int));
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("idsessione", typeof(int));
	tdidprog.defineColumn("idtitolokind", typeof(int));
	tdidprog.defineColumn("immatoltreauth", typeof(string));
	tdidprog.defineColumn("modaccesso", typeof(string));
	tdidprog.defineColumn("modaccesso_en", typeof(string));
	tdidprog.defineColumn("obbformativi", typeof(string));
	tdidprog.defineColumn("obbformativi_en", typeof(string));
	tdidprog.defineColumn("preimmatoltreauth", typeof(string));
	tdidprog.defineColumn("progesamamm", typeof(string));
	tdidprog.defineColumn("prospoccupaz", typeof(string));
	tdidprog.defineColumn("provafinaledesc", typeof(string));
	tdidprog.defineColumn("regolamentotax", typeof(string));
	tdidprog.defineColumn("regolamentotaxurl", typeof(string));
	tdidprog.defineColumn("startiscrizioni", typeof(DateTime));
	tdidprog.defineColumn("stopiscrizioni", typeof(DateTime));
	tdidprog.defineColumn("title", typeof(string));
	tdidprog.defineColumn("title_en", typeof(string));
	tdidprog.defineColumn("utenzasost", typeof(int));
	tdidprog.defineColumn("website", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// DIDPROGCLASSCONSORSUALE /////////////////////////////////
	var tdidprogclassconsorsuale= new MetaTable("didprogclassconsorsuale");
	tdidprogclassconsorsuale.defineColumn("ct", typeof(DateTime),false);
	tdidprogclassconsorsuale.defineColumn("cu", typeof(string),false);
	tdidprogclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tdidprogclassconsorsuale.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogclassconsorsuale.defineColumn("iddidprog", typeof(int),false);
	tdidprogclassconsorsuale.defineColumn("lt", typeof(DateTime),false);
	tdidprogclassconsorsuale.defineColumn("lu", typeof(string),false);
	tdidprogclassconsorsuale.defineColumn("!iddidprog_didprog_title", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!iddidprog_annoaccademico_aa", typeof(string));
	tdidprogclassconsorsuale.defineColumn("!iddidprog_sede_title", typeof(string));
	Tables.Add(tdidprogclassconsorsuale);
	tdidprogclassconsorsuale.defineKey("idclassconsorsuale", "idcorsostudio", "iddidprog");

	//////////////////// CLASSCONSORSUALE /////////////////////////////////
	var tclassconsorsuale= new MetaTable("classconsorsuale");
	tclassconsorsuale.defineColumn("active", typeof(string),false);
	tclassconsorsuale.defineColumn("ambitodisci", typeof(string));
	tclassconsorsuale.defineColumn("corr2592017", typeof(string));
	tclassconsorsuale.defineColumn("description", typeof(string),false);
	tclassconsorsuale.defineColumn("idclassconsorsuale", typeof(int),false);
	tclassconsorsuale.defineColumn("lt", typeof(DateTime));
	tclassconsorsuale.defineColumn("lu", typeof(string));
	tclassconsorsuale.defineColumn("normativa", typeof(string),false);
	tclassconsorsuale.defineColumn("title", typeof(string),false);
	Tables.Add(tclassconsorsuale);
	tclassconsorsuale.defineKey("idclassconsorsuale");

	#endregion


	#region DataRelation creation
	var cPar = new []{classconsorsuale.Columns["idclassconsorsuale"]};
	var cChild = new []{didprogclassconsorsuale.Columns["idclassconsorsuale"]};
	Relations.Add(new DataRelation("FK_didprogclassconsorsuale_classconsorsuale_idclassconsorsuale",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{didprogclassconsorsuale.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_didprogclassconsorsuale_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{sede.Columns["idsede"]};
	cChild = new []{didprog.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_didprog_sede_idsede",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{didprog.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didprog_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
