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
[System.Xml.Serialization.XmlRoot("dsmeta_tassaiscrizioneconf_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_tassaiscrizioneconf_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable costoscontodef 		=> (MetaTable)Tables["costoscontodef"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogoridefaultview 		=> (MetaTable)Tables["didprogoridefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogdefaultview 		=> (MetaTable)Tables["didprogdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiodefaultview 		=> (MetaTable)Tables["corsostudiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable corsostudiokinddefaultview 		=> (MetaTable)Tables["corsostudiokinddefaultview"];

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

	//////////////////// DIDPROGORIDEFAULTVIEW /////////////////////////////////
	var tdidprogoridefaultview= new MetaTable("didprogoridefaultview");
	tdidprogoridefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogoridefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogoridefaultview);
	tdidprogoridefaultview.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// DIDPROGDEFAULTVIEW /////////////////////////////////
	var tdidprogdefaultview= new MetaTable("didprogdefaultview");
	tdidprogdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogdefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogdefaultview.defineColumn("iddidprog", typeof(int),false);
	Tables.Add(tdidprogdefaultview);
	tdidprogdefaultview.defineKey("idcorsostudio", "iddidprog");

	//////////////////// CORSOSTUDIODEFAULTVIEW /////////////////////////////////
	var tcorsostudiodefaultview= new MetaTable("corsostudiodefaultview");
	tcorsostudiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	Tables.Add(tcorsostudiodefaultview);
	tcorsostudiodefaultview.defineKey("idcorsostudio");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_struttura_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturaparent_idstrutturakind", typeof(int));
	tstrutturadefaultview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// CORSOSTUDIOKINDDEFAULTVIEW /////////////////////////////////
	var tcorsostudiokinddefaultview= new MetaTable("corsostudiokinddefaultview");
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_active", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_ct", typeof(DateTime),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_cu", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_description", typeof(string));
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_lt", typeof(DateTime),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_lu", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("corsostudiokind_sortcode", typeof(int),false);
	tcorsostudiokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tcorsostudiokinddefaultview.defineColumn("idcorsostudiokind", typeof(int),false);
	tcorsostudiokinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tcorsostudiokinddefaultview);
	tcorsostudiokinddefaultview.defineKey("idcorsostudiokind");

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
	ttassaiscrizioneconf.defineColumn("aa", typeof(string));
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
	ttassaiscrizioneconf.defineColumn("idcorsostudio", typeof(int));
	ttassaiscrizioneconf.defineColumn("idcorsostudiokind", typeof(int));
	ttassaiscrizioneconf.defineColumn("idcostoscontodef", typeof(int),false);
	ttassaiscrizioneconf.defineColumn("iddidprog", typeof(int));
	ttassaiscrizioneconf.defineColumn("iddidprogcurr", typeof(int));
	ttassaiscrizioneconf.defineColumn("iddidprogori", typeof(int));
	ttassaiscrizioneconf.defineColumn("idstruttura", typeof(int));
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

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{tassaiscrizioneconf.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{didprogoridefaultview.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogoridefaultview_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{tassaiscrizioneconf.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{didprogcurr.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_didprogcurr_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{didprogdefaultview.Columns["iddidprog"]};
	cChild = new []{tassaiscrizioneconf.Columns["iddidprog"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_didprogdefaultview_iddidprog",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{didprogdefaultview.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_didprogdefaultview_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{corsostudiodefaultview.Columns["idcorsostudio"]};
	cChild = new []{tassaiscrizioneconf.Columns["idcorsostudio"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_corsostudiodefaultview_idcorsostudio",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{tassaiscrizioneconf.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{corsostudiokinddefaultview.Columns["idcorsostudiokind"]};
	cChild = new []{tassaiscrizioneconf.Columns["idcorsostudiokind"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_corsostudiokinddefaultview_idcorsostudiokind",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{tassaiscrizioneconf.Columns["aamax"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_annoaccademico_alias1_aamax",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{tassaiscrizioneconf.Columns["aamin"]};
	Relations.Add(new DataRelation("FK_tassaiscrizioneconf_annoaccademico_aamin",cPar,cChild,false));

	#endregion

}
}
}
