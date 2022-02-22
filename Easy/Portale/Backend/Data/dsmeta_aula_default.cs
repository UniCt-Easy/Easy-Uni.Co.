
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
[System.Xml.Serialization.XmlRoot("dsmeta_aula_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_aula_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sospensione 		=> (MetaTable)Tables["sospensione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable prova 		=> (MetaTable)Tables["prova"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provaaula 		=> (MetaTable)Tables["provaaula"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable lezione 		=> (MetaTable)Tables["lezione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_nation 		=> (MetaTable)Tables["geo_nation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable geo_city 		=> (MetaTable)Tables["geo_city"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aulakinddefaultview 		=> (MetaTable)Tables["aulakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable edificiodefaultview 		=> (MetaTable)Tables["edificiodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aula 		=> (MetaTable)Tables["aula"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_aula_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_aula_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_aula_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_aula_default.xsd";

	#region create DataTables
	//////////////////// SOSPENSIONE /////////////////////////////////
	var tsospensione= new MetaTable("sospensione");
	tsospensione.defineColumn("ct", typeof(DateTime),false);
	tsospensione.defineColumn("cu", typeof(string),false);
	tsospensione.defineColumn("idaula", typeof(int),false);
	tsospensione.defineColumn("idedificio", typeof(int),false);
	tsospensione.defineColumn("idreg", typeof(int));
	tsospensione.defineColumn("idsede", typeof(int),false);
	tsospensione.defineColumn("idsospensione", typeof(int),false);
	tsospensione.defineColumn("lt", typeof(DateTime),false);
	tsospensione.defineColumn("lu", typeof(string),false);
	tsospensione.defineColumn("motivo", typeof(string));
	tsospensione.defineColumn("start", typeof(DateTime),false);
	tsospensione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsospensione);
	tsospensione.defineKey("idaula", "idedificio", "idsede", "idsospensione");

	//////////////////// PROVA /////////////////////////////////
	var tprova= new MetaTable("prova");
	tprova.defineColumn("ct", typeof(DateTime),false);
	tprova.defineColumn("cu", typeof(string),false);
	tprova.defineColumn("idappello", typeof(int));
	tprova.defineColumn("idattivform", typeof(int));
	tprova.defineColumn("idcorsostudio", typeof(int));
	tprova.defineColumn("iddidprog", typeof(int));
	tprova.defineColumn("idprova", typeof(int),false);
	tprova.defineColumn("idquestionario", typeof(int));
	tprova.defineColumn("idvalutazionekind", typeof(int));
	tprova.defineColumn("lt", typeof(DateTime),false);
	tprova.defineColumn("lu", typeof(string),false);
	tprova.defineColumn("programma", typeof(string));
	tprova.defineColumn("start", typeof(DateTime),false);
	tprova.defineColumn("stop", typeof(DateTime),false);
	tprova.defineColumn("title", typeof(string),false);
	Tables.Add(tprova);
	tprova.defineKey("idprova");

	//////////////////// PROVAAULA /////////////////////////////////
	var tprovaaula= new MetaTable("provaaula");
	tprovaaula.defineColumn("ct", typeof(DateTime),false);
	tprovaaula.defineColumn("cu", typeof(string),false);
	tprovaaula.defineColumn("idappello", typeof(int));
	tprovaaula.defineColumn("idaula", typeof(int),false);
	tprovaaula.defineColumn("idcorsostudio", typeof(int));
	tprovaaula.defineColumn("iddidprog", typeof(int));
	tprovaaula.defineColumn("idedificio", typeof(int),false);
	tprovaaula.defineColumn("idprova", typeof(int),false);
	tprovaaula.defineColumn("idsede", typeof(int),false);
	tprovaaula.defineColumn("lt", typeof(DateTime),false);
	tprovaaula.defineColumn("lu", typeof(string),false);
	tprovaaula.defineColumn("!idprova_prova_title", typeof(string));
	tprovaaula.defineColumn("!idprova_prova_start", typeof(DateTime));
	tprovaaula.defineColumn("!idprova_prova_stop", typeof(DateTime));
	Tables.Add(tprovaaula);
	tprovaaula.defineKey("idaula", "idedificio", "idprova", "idsede");

	//////////////////// LEZIONE /////////////////////////////////
	var tlezione= new MetaTable("lezione");
	tlezione.defineColumn("!title", typeof(string));
	tlezione.defineColumn("aa", typeof(string),false);
	tlezione.defineColumn("ct", typeof(DateTime),false);
	tlezione.defineColumn("cu", typeof(string),false);
	tlezione.defineColumn("idaffidamento", typeof(int),false);
	tlezione.defineColumn("idattivform", typeof(int),false);
	tlezione.defineColumn("idaula", typeof(int),false);
	tlezione.defineColumn("idcanale", typeof(int),false);
	tlezione.defineColumn("idcorsostudio", typeof(int),false);
	tlezione.defineColumn("iddidprog", typeof(int),false);
	tlezione.defineColumn("iddidproganno", typeof(int),false);
	tlezione.defineColumn("iddidprogcurr", typeof(int),false);
	tlezione.defineColumn("iddidprogori", typeof(int),false);
	tlezione.defineColumn("iddidprogporzanno", typeof(int),false);
	tlezione.defineColumn("idedificio", typeof(int),false);
	tlezione.defineColumn("idlezione", typeof(int),false);
	tlezione.defineColumn("idreg_docenti", typeof(int),false);
	tlezione.defineColumn("idsede", typeof(int),false);
	tlezione.defineColumn("lt", typeof(DateTime),false);
	tlezione.defineColumn("lu", typeof(string),false);
	tlezione.defineColumn("nonsvolta", typeof(string));
	tlezione.defineColumn("stage", typeof(string));
	tlezione.defineColumn("start", typeof(DateTime),false);
	tlezione.defineColumn("stop", typeof(DateTime),false);
	tlezione.defineColumn("visita", typeof(string));
	Tables.Add(tlezione);
	tlezione.defineKey("aa", "idaffidamento", "idattivform", "idaula", "idcanale", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idedificio", "idlezione", "idreg_docenti", "idsede");

	//////////////////// GEO_NATION /////////////////////////////////
	var tgeo_nation= new MetaTable("geo_nation");
	tgeo_nation.defineColumn("idnation", typeof(int),false);
	tgeo_nation.defineColumn("title", typeof(string));
	Tables.Add(tgeo_nation);
	tgeo_nation.defineKey("idnation");

	//////////////////// GEO_CITY /////////////////////////////////
	var tgeo_city= new MetaTable("geo_city");
	tgeo_city.defineColumn("idcity", typeof(int),false);
	tgeo_city.defineColumn("title", typeof(string));
	Tables.Add(tgeo_city);
	tgeo_city.defineKey("idcity");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// AULAKINDDEFAULTVIEW /////////////////////////////////
	var taulakinddefaultview= new MetaTable("aulakinddefaultview");
	taulakinddefaultview.defineColumn("aulakind_active", typeof(string));
	taulakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	taulakinddefaultview.defineColumn("idaulakind", typeof(int),false);
	Tables.Add(taulakinddefaultview);
	taulakinddefaultview.defineKey("idaulakind");

	//////////////////// EDIFICIODEFAULTVIEW /////////////////////////////////
	var tedificiodefaultview= new MetaTable("edificiodefaultview");
	tedificiodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tedificiodefaultview.defineColumn("idcity", typeof(int));
	tedificiodefaultview.defineColumn("idedificio", typeof(int),false);
	tedificiodefaultview.defineColumn("idnation", typeof(int));
	tedificiodefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tedificiodefaultview);
	tedificiodefaultview.defineKey("idedificio");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("geo_city_title", typeof(string));
	tsededefaultview.defineColumn("geo_nation_title", typeof(string));
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	tsededefaultview.defineColumn("sede_address", typeof(string));
	tsededefaultview.defineColumn("sede_annotations", typeof(string));
	tsededefaultview.defineColumn("sede_cap", typeof(string));
	tsededefaultview.defineColumn("sede_ct", typeof(DateTime),false);
	tsededefaultview.defineColumn("sede_cu", typeof(string),false);
	tsededefaultview.defineColumn("sede_idreg", typeof(int));
	tsededefaultview.defineColumn("sede_idsedemiur", typeof(int));
	tsededefaultview.defineColumn("sede_latitude", typeof(decimal));
	tsededefaultview.defineColumn("sede_longitude", typeof(decimal));
	tsededefaultview.defineColumn("sede_lt", typeof(DateTime),false);
	tsededefaultview.defineColumn("sede_lu", typeof(string),false);
	tsededefaultview.defineColumn("title", typeof(string));
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// AULA /////////////////////////////////
	var taula= new MetaTable("aula");
	taula.defineColumn("address", typeof(string));
	taula.defineColumn("cap", typeof(string));
	taula.defineColumn("capienza", typeof(int));
	taula.defineColumn("capienzadis", typeof(int));
	taula.defineColumn("code", typeof(string));
	taula.defineColumn("ct", typeof(DateTime),false);
	taula.defineColumn("cu", typeof(string),false);
	taula.defineColumn("dotazioni", typeof(string));
	taula.defineColumn("idaula", typeof(int),false);
	taula.defineColumn("idaulakind", typeof(int));
	taula.defineColumn("idcity", typeof(int));
	taula.defineColumn("idedificio", typeof(int),false);
	taula.defineColumn("idnation", typeof(int));
	taula.defineColumn("idsede", typeof(int),false);
	taula.defineColumn("idstruttura", typeof(int));
	taula.defineColumn("latitude", typeof(decimal));
	taula.defineColumn("location", typeof(string));
	taula.defineColumn("longitude", typeof(decimal));
	taula.defineColumn("lt", typeof(DateTime),false);
	taula.defineColumn("lu", typeof(string),false);
	taula.defineColumn("title", typeof(string));
	Tables.Add(taula);
	taula.defineKey("idaula", "idedificio", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{aula.Columns["idaula"], aula.Columns["idedificio"], aula.Columns["idsede"]};
	var cChild = new []{sospensione.Columns["idaula"], sospensione.Columns["idedificio"], sospensione.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_sospensione_aula_idaula-idedificio-idsede",cPar,cChild,false));

	cPar = new []{aula.Columns["idaula"], aula.Columns["idedificio"], aula.Columns["idsede"]};
	cChild = new []{provaaula.Columns["idaula"], provaaula.Columns["idedificio"], provaaula.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_provaaula_aula_idaula-idedificio-idsede",cPar,cChild,false));

	cPar = new []{prova.Columns["idprova"]};
	cChild = new []{provaaula.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_provaaula_prova_idprova",cPar,cChild,false));

	cPar = new []{aula.Columns["idaula"], aula.Columns["idedificio"], aula.Columns["idsede"]};
	cChild = new []{lezione.Columns["idaula"], lezione.Columns["idedificio"], lezione.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_lezione_aula_idaula-idedificio-idsede",cPar,cChild,false));

	cPar = new []{geo_nation.Columns["idnation"]};
	cChild = new []{aula.Columns["idnation"]};
	Relations.Add(new DataRelation("FK_aula_geo_nation_idnation",cPar,cChild,false));

	cPar = new []{geo_city.Columns["idcity"]};
	cChild = new []{aula.Columns["idcity"]};
	Relations.Add(new DataRelation("FK_aula_geo_city_idcity",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{aula.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_aula_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{aulakinddefaultview.Columns["idaulakind"]};
	cChild = new []{aula.Columns["idaulakind"]};
	Relations.Add(new DataRelation("FK_aula_aulakinddefaultview_idaulakind",cPar,cChild,false));

	cPar = new []{edificiodefaultview.Columns["idedificio"]};
	cChild = new []{aula.Columns["idedificio"]};
	Relations.Add(new DataRelation("FK_aula_edificiodefaultview_idedificio",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{edificiodefaultview.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_edificiodefaultview_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{aula.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_aula_sededefaultview_idsede",cPar,cChild,false));

	#endregion

}
}
}
