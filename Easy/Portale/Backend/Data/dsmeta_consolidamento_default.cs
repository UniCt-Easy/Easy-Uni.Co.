
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
[System.Xml.Serialization.XmlRoot("dsmeta_consolidamento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_consolidamento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable workpackage 		=> (MetaTable)Tables["workpackage"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sal 		=> (MetaTable)Tables["sal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogetto 		=> (MetaTable)Tables["rendicontattivitaprogetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoora 		=> (MetaTable)Tables["rendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable consolidamentorendicontattivitaprogettoora 		=> (MetaTable)Tables["consolidamentorendicontattivitaprogettoora"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable consolidamento 		=> (MetaTable)Tables["consolidamento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_consolidamento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_consolidamento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_consolidamento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_consolidamento_default.xsd";

	#region create DataTables
	//////////////////// WORKPACKAGE /////////////////////////////////
	var tworkpackage= new MetaTable("workpackage");
	tworkpackage.defineColumn("idprogetto", typeof(int),false);
	tworkpackage.defineColumn("idworkpackage", typeof(int),false);
	tworkpackage.defineColumn("raggruppamento", typeof(string));
	tworkpackage.defineColumn("title", typeof(string),false);
	Tables.Add(tworkpackage);
	tworkpackage.defineKey("idprogetto", "idworkpackage");

	//////////////////// SAL /////////////////////////////////
	var tsal= new MetaTable("sal");
	tsal.defineColumn("datablocco", typeof(DateTime));
	tsal.defineColumn("idprogetto", typeof(int),false);
	tsal.defineColumn("idsal", typeof(int),false);
	tsal.defineColumn("start", typeof(DateTime));
	tsal.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsal);
	tsal.defineKey("idprogetto", "idsal");

	//////////////////// RENDICONTATTIVITAPROGETTO /////////////////////////////////
	var trendicontattivitaprogetto= new MetaTable("rendicontattivitaprogetto");
	trendicontattivitaprogetto.defineColumn("description", typeof(string));
	trendicontattivitaprogetto.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogetto.defineColumn("idworkpackage", typeof(int),false);
	Tables.Add(trendicontattivitaprogetto);
	trendicontattivitaprogetto.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idworkpackage");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("start", typeof(DateTime));
	tprogetto.defineColumn("stop", typeof(DateTime));
	tprogetto.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var trendicontattivitaprogettoora= new MetaTable("rendicontattivitaprogettoora");
	trendicontattivitaprogettoora.defineColumn("!titleancestor", typeof(string));
	trendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("cu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("data", typeof(DateTime));
	trendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("idsal", typeof(int));
	trendicontattivitaprogettoora.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime),false);
	trendicontattivitaprogettoora.defineColumn("lu", typeof(string),false);
	trendicontattivitaprogettoora.defineColumn("ore", typeof(int));
	Tables.Add(trendicontattivitaprogettoora);
	trendicontattivitaprogettoora.defineKey("idprogetto", "idreg", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// CONSOLIDAMENTORENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var tconsolidamentorendicontattivitaprogettoora= new MetaTable("consolidamentorendicontattivitaprogettoora");
	tconsolidamentorendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("cu", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int),false);
	tconsolidamentorendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	tconsolidamentorendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("lu", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_progetto_titolobreve", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_progetto_start", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_progetto_stop", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_workpackage_raggruppamento", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_workpackage_title", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogetto_description", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_data", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_rendicontattivitaprogettoora_ore", typeof(int));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_sal_start", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_sal_stop", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("!idrendicontattivitaprogettoora_sal_datablocco", typeof(DateTime));
	Tables.Add(tconsolidamentorendicontattivitaprogettoora);
	tconsolidamentorendicontattivitaprogettoora.defineKey("idconsolidamento", "idrendicontattivitaprogettoora");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// CONSOLIDAMENTO /////////////////////////////////
	var tconsolidamento= new MetaTable("consolidamento");
	tconsolidamento.defineColumn("ct", typeof(DateTime));
	tconsolidamento.defineColumn("cu", typeof(string));
	tconsolidamento.defineColumn("idconsolidamento", typeof(int),false);
	tconsolidamento.defineColumn("idreg", typeof(int));
	tconsolidamento.defineColumn("lt", typeof(DateTime));
	tconsolidamento.defineColumn("lu", typeof(string));
	tconsolidamento.defineColumn("start", typeof(DateTime));
	tconsolidamento.defineColumn("stop", typeof(DateTime));
	Tables.Add(tconsolidamento);
	tconsolidamento.defineKey("idconsolidamento");

	#endregion


	#region DataRelation creation
	var cPar = new []{consolidamento.Columns["idconsolidamento"]};
	var cChild = new []{consolidamentorendicontattivitaprogettoora.Columns["idconsolidamento"]};
	Relations.Add(new DataRelation("FK_consolidamentorendicontattivitaprogettoora_consolidamento_idconsolidamento",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	cChild = new []{consolidamentorendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	Relations.Add(new DataRelation("FK_consolidamentorendicontattivitaprogettoora_rendicontattivitaprogettoora_idrendicontattivitaprogettoora",cPar,cChild,false));

	cPar = new []{workpackage.Columns["idworkpackage"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idworkpackage"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_workpackage_idworkpackage",cPar,cChild,false));

	cPar = new []{sal.Columns["idsal"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idsal"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_sal_idsal",cPar,cChild,false));

	cPar = new []{rendicontattivitaprogetto.Columns["idrendicontattivitaprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idrendicontattivitaprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_rendicontattivitaprogetto_idrendicontattivitaprogetto",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogettoora.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoora_progetto_idprogetto",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{consolidamento.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_consolidamento_registry_idreg",cPar,cChild,false));

	#endregion

}
}
}
