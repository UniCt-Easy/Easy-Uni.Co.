
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuo_onlyunatantum"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneuo_onlyunatantum: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias2 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview_alias1 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuosoglia 		=> (MetaTable)Tables["perfobiettiviuosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoattach 		=> (MetaTable)Tables["perfobiettiviuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuo 		=> (MetaTable)Tables["perfobiettiviuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoufficiview 		=> (MetaTable)Tables["perfvalutazioneuoufficiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaperfelenchiview 		=> (MetaTable)Tables["strutturaperfelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuo 		=> (MetaTable)Tables["perfvalutazioneuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneuo_onlyunatantum(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuo_onlyunatantum (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuo_onlyunatantum";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuo_onlyunatantum.xsd";

	#region create DataTables
	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias2= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias2");
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_cf", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_contratto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_extmatricula", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_forename", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_istituto", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_resplevel", typeof(int));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("getdocentiamministrativiresponsabili_ssd", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineColumn("surname", typeof(string));
	tgetdocentiamministrativiresponsabilidefaultview_alias2.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias2);
	tgetdocentiamministrativiresponsabilidefaultview_alias2.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview_alias1= new MetaTable("getdocentiamministrativiresponsabilidefaultview_alias1");
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineColumn("struttura", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.ExtendedProperties["TableForReading"]="getdocentiamministrativiresponsabilidefaultview";
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview_alias1);
	tgetdocentiamministrativiresponsabilidefaultview_alias1.defineKey("idreg", "ruolo", "struttura");

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview= new MetaTable("getdocentiamministrativiresponsabilidefaultview");
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("struttura", typeof(string),false);
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview);
	tgetdocentiamministrativiresponsabilidefaultview.defineKey("idreg", "ruolo", "struttura");

	//////////////////// PERFOBIETTIVIUOSOGLIA /////////////////////////////////
	var tperfobiettiviuosoglia= new MetaTable("perfobiettiviuosoglia");
	tperfobiettiviuosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfobiettiviuosoglia.defineColumn("cu", typeof(string),false);
	tperfobiettiviuosoglia.defineColumn("description", typeof(string));
	tperfobiettiviuosoglia.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("idperfobiettiviuosoglia", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfobiettiviuosoglia.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfobiettiviuosoglia.defineColumn("lu", typeof(string),false);
	tperfobiettiviuosoglia.defineColumn("percentuale", typeof(decimal));
	tperfobiettiviuosoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfobiettiviuosoglia);
	tperfobiettiviuosoglia.defineKey("idperfobiettiviuo", "idperfobiettiviuosoglia", "idperfvalutazioneuo");

	//////////////////// PERFOBIETTIVIUOATTACH /////////////////////////////////
	var tperfobiettiviuoattach= new MetaTable("perfobiettiviuoattach");
	tperfobiettiviuoattach.defineColumn("idattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuoattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("title", typeof(string),false);
	Tables.Add(tperfobiettiviuoattach);
	tperfobiettiviuoattach.defineKey("idattach", "idperfobiettiviuo", "idperfobiettiviuoattach", "idperfvalutazioneuo");

	//////////////////// PERFOBIETTIVIUO /////////////////////////////////
	var tperfobiettiviuo= new MetaTable("perfobiettiviuo");
	tperfobiettiviuo.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuo.defineColumn("ct", typeof(DateTime));
	tperfobiettiviuo.defineColumn("cu", typeof(string));
	tperfobiettiviuo.defineColumn("description", typeof(string));
	tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("idperfvalutazionepersonale", typeof(int));
	tperfobiettiviuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("lt", typeof(DateTime));
	tperfobiettiviuo.defineColumn("lu", typeof(string));
	tperfobiettiviuo.defineColumn("note", typeof(string));
	tperfobiettiviuo.defineColumn("peso", typeof(decimal));
	tperfobiettiviuo.defineColumn("title", typeof(string));
	tperfobiettiviuo.defineColumn("valorenumerico", typeof(decimal));
	tperfobiettiviuo.defineColumn("!perfobiettiviuosoglia", typeof(string));
	tperfobiettiviuo.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfobiettiviuo);
	tperfobiettiviuo.defineKey("idperfobiettiviuo", "idperfvalutazioneuo");

	//////////////////// PERFVALUTAZIONEUOUFFICIVIEW /////////////////////////////////
	var tperfvalutazioneuoufficiview= new MetaTable("perfvalutazioneuoufficiview");
	tperfvalutazioneuoufficiview.defineColumn("completamento", typeof(decimal));
	tperfvalutazioneuoufficiview.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazioneuoufficiview.defineColumn("idperfschedastatus_child", typeof(int));
	tperfvalutazioneuoufficiview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuoufficiview.defineColumn("idperfvalutazioneuo_child", typeof(int),false);
	tperfvalutazioneuoufficiview.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuoufficiview.defineColumn("idstruttura_child", typeof(int),false);
	tperfvalutazioneuoufficiview.defineColumn("peso", typeof(int),false);
	tperfvalutazioneuoufficiview.defineColumn("title", typeof(string));
	tperfvalutazioneuoufficiview.defineColumn("title_child", typeof(string));
	tperfvalutazioneuoufficiview.defineColumn("year", typeof(int),false);
	Tables.Add(tperfvalutazioneuoufficiview);
	tperfvalutazioneuoufficiview.defineKey("idperfvalutazioneuo", "idperfvalutazioneuo_child", "idstruttura", "idstruttura_child", "year");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW /////////////////////////////////
	var tperfschedastatusdefaultview= new MetaTable("perfschedastatusdefaultview");
	tperfschedastatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_active", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_ct", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_cu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_description", typeof(string));
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lt", typeof(DateTime),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_lu", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

	//////////////////// STRUTTURAPERFELENCHIVIEW /////////////////////////////////
	var tstrutturaperfelenchiview= new MetaTable("strutturaperfelenchiview");
	tstrutturaperfelenchiview.defineColumn("aoo_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("idstruttura", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("idupb", typeof(string));
	tstrutturaperfelenchiview.defineColumn("paridstruttura", typeof(int));
	tstrutturaperfelenchiview.defineColumn("sede_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_active", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_codice", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturaperfelenchiview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("struttura_email", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_fax", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturaperfelenchiview.defineColumn("struttura_idreg", typeof(int));
	tstrutturaperfelenchiview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturaperfelenchiview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturaperfelenchiview.defineColumn("struttura_telefono", typeof(string));
	tstrutturaperfelenchiview.defineColumn("struttura_title_en", typeof(string));
	tstrutturaperfelenchiview.defineColumn("strutturakind_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("title", typeof(string));
	tstrutturaperfelenchiview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturaperfelenchiview);
	tstrutturaperfelenchiview.defineKey("idstruttura");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEUO /////////////////////////////////
	var tperfvalutazioneuo= new MetaTable("perfvalutazioneuo");
	tperfvalutazioneuo.defineColumn("completamentopsauo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("completamentopsuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazioneuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuo.defineColumn("idreg_appr", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_comp", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_compobborg", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_create", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_val", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_valobborg", typeof(int));
	tperfvalutazioneuo.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuo.defineColumn("indicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("obiettiviindividuali", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoindicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoobiettivi", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoprogaltreuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoproguo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("risultato", typeof(decimal));
	tperfvalutazioneuo.defineColumn("year", typeof(int),false);
	Tables.Add(tperfvalutazioneuo);
	tperfvalutazioneuo.defineKey("idperfvalutazioneuo", "idstruttura", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias2.Columns["idreg"]};
	var cChild = new []{perfvalutazioneuo.Columns["idreg_val"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilidefaultview_alias2_idreg_val",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview_alias1.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_comp"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilidefaultview_alias1_idreg_comp",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazioneuo.Columns["idreg_create"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_getdocentiamministrativiresponsabilidefaultview_idreg_create",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuosoglia.Columns["idperfobiettiviuo"], perfobiettiviuosoglia.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuoattach.Columns["idperfobiettiviuo"], perfobiettiviuoattach.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuoattach_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"], perfvalutazioneuo.Columns["idstruttura"], perfvalutazioneuo.Columns["year"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idperfvalutazioneuo"], perfvalutazioneuoufficiview.Columns["idstruttura"], perfvalutazioneuoufficiview.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_perfvalutazioneuo_idperfvalutazioneuo-idstruttura-year",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazioneuo.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	cPar = new []{strutturaperfelenchiview.Columns["idstruttura"]};
	cChild = new []{perfvalutazioneuo.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_strutturaperfelenchiview_idstruttura",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazioneuo.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuo_year_year",cPar,cChild,false));

	#endregion

}
}
}
