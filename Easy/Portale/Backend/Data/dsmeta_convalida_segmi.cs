
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_convalida_segmi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_convalida_segmi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprog 		=> (MetaTable)Tables["didprog"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskinddefaultview_alias1 		=> (MetaTable)Tables["changeskinddefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changes 		=> (MetaTable)Tables["changes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview 		=> (MetaTable)Tables["attivformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sostenimentodefaultview 		=> (MetaTable)Tables["sostenimentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskinddefaultview 		=> (MetaTable)Tables["changeskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidante 		=> (MetaTable)Tables["convalidante"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidakinddefaultview 		=> (MetaTable)Tables["convalidakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalida 		=> (MetaTable)Tables["convalida"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalida_segmi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalida_segmi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalida_segmi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalida_segmi.xsd";

	#region create DataTables
	//////////////////// DIDPROG /////////////////////////////////
	var tdidprog= new MetaTable("didprog");
	tdidprog.defineColumn("aa", typeof(string),false);
	tdidprog.defineColumn("idcorsostudio", typeof(int),false);
	tdidprog.defineColumn("iddidprog", typeof(int),false);
	tdidprog.defineColumn("idsede", typeof(int));
	tdidprog.defineColumn("title", typeof(string));
	Tables.Add(tdidprog);
	tdidprog.defineKey("idcorsostudio", "iddidprog");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// CHANGESKINDDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tchangeskinddefaultview_alias1= new MetaTable("changeskinddefaultview_alias1");
	tchangeskinddefaultview_alias1.defineColumn("changeskind_active", typeof(string));
	tchangeskinddefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tchangeskinddefaultview_alias1.defineColumn("idchangeskind", typeof(int),false);
	tchangeskinddefaultview_alias1.ExtendedProperties["TableForReading"]="changeskinddefaultview";
	Tables.Add(tchangeskinddefaultview_alias1);
	tchangeskinddefaultview_alias1.defineKey("idchangeskind");

	//////////////////// CHANGES /////////////////////////////////
	var tchanges= new MetaTable("changes");
	tchanges.defineColumn("idchanges", typeof(int),false);
	tchanges.defineColumn("title", typeof(string),false);
	Tables.Add(tchanges);
	tchanges.defineKey("idchanges");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// CONVALIDATO /////////////////////////////////
	var tconvalidato= new MetaTable("convalidato");
	tconvalidato.defineColumn("changesother", typeof(string));
	tconvalidato.defineColumn("ct", typeof(DateTime),false);
	tconvalidato.defineColumn("cu", typeof(string),false);
	tconvalidato.defineColumn("idattivform", typeof(int),false);
	tconvalidato.defineColumn("idchanges", typeof(int));
	tconvalidato.defineColumn("idchangeskind", typeof(int));
	tconvalidato.defineColumn("idconvalida", typeof(int),false);
	tconvalidato.defineColumn("idconvalidato", typeof(int),false);
	tconvalidato.defineColumn("iddichiar", typeof(int));
	tconvalidato.defineColumn("iddidprog", typeof(int));
	tconvalidato.defineColumn("idiscrizione", typeof(int));
	tconvalidato.defineColumn("idiscrizione_from", typeof(int));
	tconvalidato.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalidato.defineColumn("idistanza", typeof(int));
	tconvalidato.defineColumn("idlearningagrstud", typeof(int),false);
	tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato.defineColumn("idpratica", typeof(int));
	tconvalidato.defineColumn("idreg", typeof(int),false);
	tconvalidato.defineColumn("lt", typeof(DateTime),false);
	tconvalidato.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// SOSTENIMENTODEFAULTVIEW /////////////////////////////////
	var tsostenimentodefaultview= new MetaTable("sostenimentodefaultview");
	tsostenimentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsostenimentodefaultview.defineColumn("idappello", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idprova", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idreg", typeof(int),false);
	tsostenimentodefaultview.defineColumn("idsostenimento", typeof(int),false);
	Tables.Add(tsostenimentodefaultview);
	tsostenimentodefaultview.defineKey("idappello", "idprova", "idreg", "idsostenimento");

	//////////////////// CHANGESKINDDEFAULTVIEW /////////////////////////////////
	var tchangeskinddefaultview= new MetaTable("changeskinddefaultview");
	tchangeskinddefaultview.defineColumn("changes_title", typeof(string));
	tchangeskinddefaultview.defineColumn("changeskind_active", typeof(string));
	tchangeskinddefaultview.defineColumn("changeskind_description", typeof(string));
	tchangeskinddefaultview.defineColumn("changeskind_idchanges", typeof(int));
	tchangeskinddefaultview.defineColumn("changeskind_lt", typeof(DateTime),false);
	tchangeskinddefaultview.defineColumn("changeskind_lu", typeof(string),false);
	tchangeskinddefaultview.defineColumn("changeskind_sortcode", typeof(int),false);
	tchangeskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tchangeskinddefaultview.defineColumn("idchangeskind", typeof(int),false);
	tchangeskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tchangeskinddefaultview);
	tchangeskinddefaultview.defineKey("idchangeskind");

	//////////////////// CONVALIDANTE /////////////////////////////////
	var tconvalidante= new MetaTable("convalidante");
	tconvalidante.defineColumn("changes", typeof(string));
	tconvalidante.defineColumn("changesother", typeof(string));
	tconvalidante.defineColumn("ct", typeof(DateTime),false);
	tconvalidante.defineColumn("cu", typeof(string),false);
	tconvalidante.defineColumn("idchangeskind", typeof(int));
	tconvalidante.defineColumn("idconvalida", typeof(int),false);
	tconvalidante.defineColumn("idconvalidante", typeof(int),false);
	tconvalidante.defineColumn("iddichiar", typeof(int));
	tconvalidante.defineColumn("iddidprog", typeof(int));
	tconvalidante.defineColumn("idiscrizione", typeof(int));
	tconvalidante.defineColumn("idiscrizione_from", typeof(int));
	tconvalidante.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalidante.defineColumn("idistanza", typeof(int));
	tconvalidante.defineColumn("idlearningagrstud", typeof(int),false);
	tconvalidante.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidante.defineColumn("idpratica", typeof(int));
	tconvalidante.defineColumn("idreg", typeof(int),false);
	tconvalidante.defineColumn("idsostenimento", typeof(int));
	tconvalidante.defineColumn("idtirocinioprogetto", typeof(int));
	tconvalidante.defineColumn("lt", typeof(DateTime),false);
	tconvalidante.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidante);
	tconvalidante.defineKey("idconvalida", "idconvalidante", "idiscrizionebmi", "idlearningagrstud", "idreg");

	//////////////////// CONVALIDAKINDDEFAULTVIEW /////////////////////////////////
	var tconvalidakinddefaultview= new MetaTable("convalidakinddefaultview");
	tconvalidakinddefaultview.defineColumn("convalidakind_active", typeof(string));
	tconvalidakinddefaultview.defineColumn("convalidakind_ct", typeof(DateTime),false);
	tconvalidakinddefaultview.defineColumn("convalidakind_cu", typeof(string),false);
	tconvalidakinddefaultview.defineColumn("convalidakind_description", typeof(string),false);
	tconvalidakinddefaultview.defineColumn("convalidakind_lt", typeof(DateTime),false);
	tconvalidakinddefaultview.defineColumn("convalidakind_lu", typeof(string),false);
	tconvalidakinddefaultview.defineColumn("convalidakind_sortcode", typeof(int),false);
	tconvalidakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tconvalidakinddefaultview.defineColumn("idconvalidakind", typeof(int),false);
	tconvalidakinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tconvalidakinddefaultview);
	tconvalidakinddefaultview.defineKey("idconvalidakind");

	//////////////////// CONVALIDA /////////////////////////////////
	var tconvalida= new MetaTable("convalida");
	tconvalida.defineColumn("cf", typeof(decimal));
	tconvalida.defineColumn("cfintegrazione", typeof(decimal));
	tconvalida.defineColumn("ct", typeof(DateTime),false);
	tconvalida.defineColumn("cu", typeof(string),false);
	tconvalida.defineColumn("data", typeof(DateTime));
	tconvalida.defineColumn("idconvalida", typeof(int),false);
	tconvalida.defineColumn("idconvalidakind", typeof(int));
	tconvalida.defineColumn("iddichiar", typeof(int));
	tconvalida.defineColumn("iddidprog", typeof(int));
	tconvalida.defineColumn("idiscrizione", typeof(int));
	tconvalida.defineColumn("idiscrizione_from", typeof(int));
	tconvalida.defineColumn("idiscrizionebmi", typeof(int),false);
	tconvalida.defineColumn("idistanza", typeof(int));
	tconvalida.defineColumn("idlearningagrstud", typeof(int),false);
	tconvalida.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalida.defineColumn("idpratica", typeof(int));
	tconvalida.defineColumn("idreg", typeof(int),false);
	tconvalida.defineColumn("lt", typeof(DateTime),false);
	tconvalida.defineColumn("lu", typeof(string),false);
	tconvalida.defineColumn("voto", typeof(decimal));
	tconvalida.defineColumn("votolode", typeof(string));
	tconvalida.defineColumn("votosu", typeof(int));
	Tables.Add(tconvalida);
	tconvalida.defineKey("idconvalida", "idiscrizionebmi", "idlearningagrstud", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	var cChild = new []{convalidato.Columns["idconvalida"], convalidato.Columns["idiscrizionebmi"], convalidato.Columns["idlearningagrstud"], convalidato.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidato_convalida_idconvalida-idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{didprog.Columns["iddidprog"]};
	cChild = new []{convalidato.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_convalidato_didprog_iddidprog",cPar,cChild,false));

	cPar = new []{dichiar.Columns["iddichiar"]};
	cChild = new []{convalidato.Columns["iddichiar"]};
	Relations.Add(new DataRelation("FK_convalidato_dichiar_iddichiar",cPar,cChild,false));

	cPar = new []{changeskinddefaultview_alias1.Columns["idchangeskind"]};
	cChild = new []{convalidato.Columns["idchangeskind"]};
	Relations.Add(new DataRelation("FK_convalidato_changeskinddefaultview_alias1_idchangeskind",cPar,cChild,false));

	cPar = new []{changes.Columns["idchanges"]};
	cChild = new []{convalidato.Columns["idchanges"]};
	Relations.Add(new DataRelation("FK_convalidato_changes_idchanges",cPar,cChild,false));

	cPar = new []{attivformdefaultview.Columns["idattivform"]};
	cChild = new []{convalidato.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_convalidato_attivformdefaultview_idattivform",cPar,cChild,false));

	cPar = new []{convalida.Columns["idconvalida"], convalida.Columns["idiscrizionebmi"], convalida.Columns["idlearningagrstud"], convalida.Columns["idreg"]};
	cChild = new []{convalidante.Columns["idconvalida"], convalidante.Columns["idiscrizionebmi"], convalidante.Columns["idlearningagrstud"], convalidante.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_convalidante_convalida_idconvalida-idiscrizionebmi-idlearningagrstud-idreg",cPar,cChild,false));

	cPar = new []{sostenimentodefaultview.Columns["idsostenimento"]};
	cChild = new []{convalidante.Columns["idsostenimento"]};
	Relations.Add(new DataRelation("FK_convalidante_sostenimentodefaultview_idsostenimento",cPar,cChild,false));

	cPar = new []{changeskinddefaultview.Columns["idchangeskind"]};
	cChild = new []{convalidante.Columns["idchangeskind"]};
	Relations.Add(new DataRelation("FK_convalidante_changeskinddefaultview_idchangeskind",cPar,cChild,false));

	cPar = new []{convalidakinddefaultview.Columns["idconvalidakind"]};
	cChild = new []{convalida.Columns["idconvalidakind"]};
	Relations.Add(new DataRelation("FK_convalida_convalidakinddefaultview_idconvalidakind",cPar,cChild,false));

	#endregion

}
}
}
