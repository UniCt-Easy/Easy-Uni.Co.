
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
[System.Xml.Serialization.XmlRoot("dsmeta_convalidato_segistrein"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_convalidato_segistrein: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changeskinddefaultview 		=> (MetaTable)Tables["changeskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable changes 		=> (MetaTable)Tables["changes"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformdefaultview 		=> (MetaTable)Tables["attivformdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable convalidato 		=> (MetaTable)Tables["convalidato"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_convalidato_segistrein(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_convalidato_segistrein (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_convalidato_segistrein";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_convalidato_segistrein.xsd";

	#region create DataTables
	//////////////////// CHANGESKINDDEFAULTVIEW /////////////////////////////////
	var tchangeskinddefaultview= new MetaTable("changeskinddefaultview");
	tchangeskinddefaultview.defineColumn("changeskind_idchanges", typeof(int));
	tchangeskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tchangeskinddefaultview.defineColumn("idchangeskind", typeof(int),false);
	Tables.Add(tchangeskinddefaultview);
	tchangeskinddefaultview.defineKey("idchangeskind");

	//////////////////// CHANGES /////////////////////////////////
	var tchanges= new MetaTable("changes");
	tchanges.defineColumn("idchanges", typeof(int),false);
	tchanges.defineColumn("title", typeof(string),false);
	Tables.Add(tchanges);
	tchanges.defineKey("idchanges");

	//////////////////// ATTIVFORMDEFAULTVIEW /////////////////////////////////
	var tattivformdefaultview= new MetaTable("attivformdefaultview");
	tattivformdefaultview.defineColumn("aa", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_ct", typeof(DateTime),false);
	tattivformdefaultview.defineColumn("attivform_cu", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_iddidproggrupp", typeof(int));
	tattivformdefaultview.defineColumn("attivform_lt", typeof(DateTime),false);
	tattivformdefaultview.defineColumn("attivform_lu", typeof(string),false);
	tattivformdefaultview.defineColumn("attivform_obbform", typeof(string));
	tattivformdefaultview.defineColumn("attivform_obbform_en", typeof(string));
	tattivformdefaultview.defineColumn("attivform_sortcode", typeof(int));
	tattivformdefaultview.defineColumn("attivform_start", typeof(DateTime));
	tattivformdefaultview.defineColumn("attivform_stop", typeof(DateTime));
	tattivformdefaultview.defineColumn("attivform_tipovalutaz", typeof(string));
	tattivformdefaultview.defineColumn("didproganno_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogcurr_title", typeof(string));
	tattivformdefaultview.defineColumn("didproggrupp_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogori_title", typeof(string));
	tattivformdefaultview.defineColumn("didprogporzanno_title", typeof(string));
	tattivformdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tattivformdefaultview.defineColumn("idattivform", typeof(int),false);
	tattivformdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprog", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidproganno", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogori", typeof(int),false);
	tattivformdefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegn", typeof(int),false);
	tattivformdefaultview.defineColumn("idinsegninteg", typeof(int));
	tattivformdefaultview.defineColumn("idsede", typeof(int),false);
	tattivformdefaultview.defineColumn("insegn_codice", typeof(string));
	tattivformdefaultview.defineColumn("insegn_denominazione", typeof(string));
	tattivformdefaultview.defineColumn("insegninteg_codice", typeof(string));
	tattivformdefaultview.defineColumn("insegninteg_denominazione", typeof(string));
	tattivformdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tattivformdefaultview);
	tattivformdefaultview.defineKey("idattivform");

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
	tconvalidato.defineColumn("idiscrizionebmi", typeof(int));
	tconvalidato.defineColumn("idistanza", typeof(int));
	tconvalidato.defineColumn("idlearningagrstud", typeof(int));
	tconvalidato.defineColumn("idlearningagrtrainer", typeof(int));
	tconvalidato.defineColumn("idpratica", typeof(int));
	tconvalidato.defineColumn("idreg", typeof(int),false);
	tconvalidato.defineColumn("lt", typeof(DateTime),false);
	tconvalidato.defineColumn("lu", typeof(string),false);
	Tables.Add(tconvalidato);
	tconvalidato.defineKey("idconvalida", "idconvalidato", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{changeskinddefaultview.Columns["idchangeskind"]};
	var cChild = new []{convalidato.Columns["idchangeskind"]};
	Relations.Add(new DataRelation("FK_convalidato_changeskinddefaultview_idchangeskind",cPar,cChild,false));

	cPar = new []{changes.Columns["idchanges"]};
	cChild = new []{changeskinddefaultview.Columns["changeskind_idchanges"]};
	Relations.Add(new DataRelation("FK_changeskinddefaultview_changes_idchanges",cPar,cChild,false));

	cPar = new []{changes.Columns["idchanges"]};
	cChild = new []{convalidato.Columns["idchanges"]};
	Relations.Add(new DataRelation("FK_convalidato_changes_idchanges",cPar,cChild,false));

	cPar = new []{attivformdefaultview.Columns["idattivform"]};
	cChild = new []{convalidato.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_convalidato_attivformdefaultview_idattivform",cPar,cChild,false));

	#endregion

}
}
}
