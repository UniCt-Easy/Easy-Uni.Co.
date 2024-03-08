
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
[System.Xml.Serialization.XmlRoot("dsmeta_mansionekind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_mansionekind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias2 		=> (MetaTable)Tables["year_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfpositionattach 		=> (MetaTable)Tables["perfpositionattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias1 		=> (MetaTable)Tables["year_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfcomportamento 		=> (MetaTable)Tables["perfcomportamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekindcomportamento 		=> (MetaTable)Tables["mansionekindcomportamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_mansionekind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_mansionekind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_mansionekind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_mansionekind_default.xsd";

	#region create DataTables
	//////////////////// YEAR_ALIAS2 /////////////////////////////////
	var tyear_alias2= new MetaTable("year_alias2");
	tyear_alias2.defineColumn("year", typeof(int),false);
	tyear_alias2.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias2);
	tyear_alias2.defineKey("year");

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// PERFPOSITIONATTACH /////////////////////////////////
	var tperfpositionattach= new MetaTable("perfpositionattach");
	tperfpositionattach.defineColumn("ct", typeof(DateTime),false);
	tperfpositionattach.defineColumn("cu", typeof(string),false);
	tperfpositionattach.defineColumn("idattach", typeof(int));
	tperfpositionattach.defineColumn("idmansionekind", typeof(int),false);
	tperfpositionattach.defineColumn("idperfpositionattach", typeof(int),false);
	tperfpositionattach.defineColumn("lt", typeof(DateTime),false);
	tperfpositionattach.defineColumn("lu", typeof(string),false);
	tperfpositionattach.defineColumn("year", typeof(int));
	tperfpositionattach.defineColumn("!idattach_attach_filename", typeof(string));
	Tables.Add(tperfpositionattach);
	tperfpositionattach.defineKey("idmansionekind", "idperfpositionattach");

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

	//////////////////// PERFCOMPORTAMENTO /////////////////////////////////
	var tperfcomportamento= new MetaTable("perfcomportamento");
	tperfcomportamento.defineColumn("ct", typeof(DateTime),false);
	tperfcomportamento.defineColumn("cu", typeof(string),false);
	tperfcomportamento.defineColumn("description", typeof(string));
	tperfcomportamento.defineColumn("idperfcomportamento", typeof(int),false);
	tperfcomportamento.defineColumn("lt", typeof(DateTime),false);
	tperfcomportamento.defineColumn("lu", typeof(string),false);
	tperfcomportamento.defineColumn("peso", typeof(decimal));
	tperfcomportamento.defineColumn("title", typeof(string));
	Tables.Add(tperfcomportamento);
	tperfcomportamento.defineKey("idperfcomportamento");

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
	tmansionekindcomportamento.defineColumn("!idperfcomportamento_perfcomportamento_title", typeof(string));
	tmansionekindcomportamento.defineColumn("!idperfcomportamento_perfcomportamento_description", typeof(string));
	tmansionekindcomportamento.defineColumn("!idperfcomportamento_perfcomportamento_peso", typeof(decimal));
	Tables.Add(tmansionekindcomportamento);
	tmansionekindcomportamento.defineKey("idmansionekind", "idperfcomportamento");

	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("ct", typeof(DateTime),false);
	tmansionekind.defineColumn("cu", typeof(string),false);
	tmansionekind.defineColumn("generascheda", typeof(string));
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("lt", typeof(DateTime),false);
	tmansionekind.defineColumn("lu", typeof(string),false);
	tmansionekind.defineColumn("pesoateneo", typeof(decimal));
	tmansionekind.defineColumn("pesocomp", typeof(decimal));
	tmansionekind.defineColumn("pesoindividuale", typeof(decimal));
	tmansionekind.defineColumn("pesouo", typeof(decimal));
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	#endregion


	#region DataRelation creation
	var cPar = new []{mansionekind.Columns["idmansionekind"]};
	var cChild = new []{perfpositionattach.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_perfpositionattach_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{year_alias2.Columns["year"]};
	cChild = new []{perfpositionattach.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfpositionattach_year_alias2_year",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfpositionattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfpositionattach_attach_idattach",cPar,cChild,false));

	cPar = new []{mansionekind.Columns["idmansionekind"]};
	cChild = new []{mansionekindcomportamento.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{year_alias1.Columns["year"]};
	cChild = new []{mansionekindcomportamento.Columns["year_stop"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_year_alias1_year_stop",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{mansionekindcomportamento.Columns["year_start"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_year_year_start",cPar,cChild,false));

	cPar = new []{perfcomportamento.Columns["idperfcomportamento"]};
	cChild = new []{mansionekindcomportamento.Columns["idperfcomportamento"]};
	Relations.Add(new DataRelation("FK_mansionekindcomportamento_perfcomportamento_idperfcomportamento",cPar,cChild,false));

	#endregion

}
}
}
