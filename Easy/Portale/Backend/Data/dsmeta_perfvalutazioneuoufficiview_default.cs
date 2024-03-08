
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuoufficiview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneuoufficiview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview_alias1 		=> (MetaTable)Tables["strutturadefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuodefaultview_alias1 		=> (MetaTable)Tables["perfvalutazioneuodefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuodefaultview 		=> (MetaTable)Tables["perfvalutazioneuodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview_alias1 		=> (MetaTable)Tables["perfschedastatusdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoufficiview 		=> (MetaTable)Tables["perfvalutazioneuoufficiview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneuoufficiview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuoufficiview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuoufficiview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuoufficiview_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// STRUTTURADEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tstrutturadefaultview_alias1= new MetaTable("strutturadefaultview_alias1");
	tstrutturadefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview_alias1.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview_alias1.ExtendedProperties["TableForReading"]="strutturadefaultview";
	Tables.Add(tstrutturadefaultview_alias1);
	tstrutturadefaultview_alias1.defineKey("idstruttura");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// PERFVALUTAZIONEUODEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tperfvalutazioneuodefaultview_alias1= new MetaTable("perfvalutazioneuodefaultview_alias1");
	tperfvalutazioneuodefaultview_alias1.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuodefaultview_alias1.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuodefaultview_alias1.defineColumn("year", typeof(int),false);
	tperfvalutazioneuodefaultview_alias1.ExtendedProperties["TableForReading"]="perfvalutazioneuodefaultview";
	Tables.Add(tperfvalutazioneuodefaultview_alias1);
	tperfvalutazioneuodefaultview_alias1.defineKey("idperfvalutazioneuo", "idstruttura", "year");

	//////////////////// PERFVALUTAZIONEUODEFAULTVIEW /////////////////////////////////
	var tperfvalutazioneuodefaultview= new MetaTable("perfvalutazioneuodefaultview");
	tperfvalutazioneuodefaultview.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuodefaultview.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuodefaultview.defineColumn("year", typeof(int),false);
	Tables.Add(tperfvalutazioneuodefaultview);
	tperfvalutazioneuodefaultview.defineKey("idperfvalutazioneuo", "idstruttura", "year");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tperfschedastatusdefaultview_alias1= new MetaTable("perfschedastatusdefaultview_alias1");
	tperfschedastatusdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview_alias1.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview_alias1.defineColumn("perfschedastatus_active", typeof(string));
	tperfschedastatusdefaultview_alias1.ExtendedProperties["TableForReading"]="perfschedastatusdefaultview";
	Tables.Add(tperfschedastatusdefaultview_alias1);
	tperfschedastatusdefaultview_alias1.defineKey("idperfschedastatus");

	//////////////////// PERFSCHEDASTATUSDEFAULTVIEW /////////////////////////////////
	var tperfschedastatusdefaultview= new MetaTable("perfschedastatusdefaultview");
	tperfschedastatusdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfschedastatusdefaultview.defineColumn("idperfschedastatus", typeof(int),false);
	tperfschedastatusdefaultview.defineColumn("perfschedastatus_active", typeof(string));
	Tables.Add(tperfschedastatusdefaultview);
	tperfschedastatusdefaultview.defineKey("idperfschedastatus");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{perfvalutazioneuoufficiview.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_year_year",cPar,cChild,false));

	cPar = new []{strutturadefaultview_alias1.Columns["idstruttura"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idstruttura_child"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_strutturadefaultview_alias1_idstruttura_child",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{perfvalutazioneuodefaultview_alias1.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idperfvalutazioneuo_child"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_perfvalutazioneuodefaultview_alias1_idperfvalutazioneuo_child",cPar,cChild,false));

	cPar = new []{perfvalutazioneuodefaultview.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_perfvalutazioneuodefaultview_idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview_alias1.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idperfschedastatus_child"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_perfschedastatusdefaultview_alias1_idperfschedastatus_child",cPar,cChild,false));

	cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	cChild = new []{perfvalutazioneuoufficiview.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoufficiview_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	#endregion

}
}
}
