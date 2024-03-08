
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
[System.Xml.Serialization.XmlRoot("dsmeta_mansionekindcomportamento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_mansionekindcomportamento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias1 		=> (MetaTable)Tables["year_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfcomportamentodefaultview 		=> (MetaTable)Tables["perfcomportamentodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekindcomportamento 		=> (MetaTable)Tables["mansionekindcomportamento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_mansionekindcomportamento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_mansionekindcomportamento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_mansionekindcomportamento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_mansionekindcomportamento_default.xsd";

	#region create DataTables
	//////////////////// YEAR_ALIAS1 /////////////////////////////////
	var tyear_alias1= new MetaTable("year_alias1");
	tyear_alias1.defineColumn("year", typeof(int),false);
	tyear_alias1.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias1);
	tyear_alias1.defineKey("year");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFCOMPORTAMENTODEFAULTVIEW /////////////////////////////////
	var tperfcomportamentodefaultview= new MetaTable("perfcomportamentodefaultview");
	tperfcomportamentodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfcomportamentodefaultview.defineColumn("idperfcomportamento", typeof(int),false);
	tperfcomportamentodefaultview.defineColumn("perfcomportamento_ct", typeof(DateTime),false);
	tperfcomportamentodefaultview.defineColumn("perfcomportamento_cu", typeof(string),false);
	tperfcomportamentodefaultview.defineColumn("perfcomportamento_description", typeof(string));
	tperfcomportamentodefaultview.defineColumn("perfcomportamento_lt", typeof(DateTime),false);
	tperfcomportamentodefaultview.defineColumn("perfcomportamento_lu", typeof(string),false);
	tperfcomportamentodefaultview.defineColumn("perfcomportamento_peso", typeof(decimal));
	tperfcomportamentodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfcomportamentodefaultview);
	tperfcomportamentodefaultview.defineKey("idperfcomportamento");

	//////////////////// MANSIONEKINDCOMPORTAMENTO /////////////////////////////////
	var tmansionekindcomportamento= new MetaTable("mansionekindcomportamento");
	tmansionekindcomportamento.defineColumn("ct", typeof(DateTime),false);
	tmansionekindcomportamento.defineColumn("cu", typeof(string),false);
	tmansionekindcomportamento.defineColumn("idmansionekind", typeof(int),false);
	tmansionekindcomportamento.defineColumn("idperfcomportamento", typeof(int),false);
	tmansionekindcomportamento.defineColumn("lt", typeof(DateTime),false);
	tmansionekindcomportamento.defineColumn("lu", typeof(string),false);
	tmansionekindcomportamento.defineColumn("year_start", typeof(int));
	tmansionekindcomportamento.defineColumn("year_stop", typeof(int));
	Tables.Add(tmansionekindcomportamento);
	tmansionekindcomportamento.defineKey("idmansionekind", "idperfcomportamento");

	#endregion


	#region DataRelation creation
	var cPar = new []{year_alias1.Columns["year"]};
	var cChild = new []{mansionekindcomportamento.Columns["year_stop"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_year_alias1_year_stop",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{mansionekindcomportamento.Columns["year_start"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_year_year_start",cPar,cChild,false));

	cPar = new []{perfcomportamentodefaultview.Columns["idperfcomportamento"]};
	cChild = new []{mansionekindcomportamento.Columns["idperfcomportamento"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_perfcomportamentodefaultview_idperfcomportamento",cPar,cChild,false));

	#endregion

}
}
}
