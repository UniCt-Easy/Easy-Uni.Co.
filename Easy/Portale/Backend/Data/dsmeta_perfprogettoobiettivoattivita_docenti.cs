
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivoattivita_docenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivoattivita_docenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitadocentiview_alias1 		=> (MetaTable)Tables["perfprogettoobiettivoattivitadocentiview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo 		=> (MetaTable)Tables["perfprogettoobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettodefaultview 		=> (MetaTable)Tables["perfprogettodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivita 		=> (MetaTable)Tables["perfprogettoobiettivoattivita"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivoattivita_docenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivoattivita_docenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivoattivita_docenti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivoattivita_docenti.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOOBIETTIVOATTIVITADOCENTIVIEW_ALIAS1 /////////////////////////////////
	var tperfprogettoobiettivoattivitadocentiview_alias1= new MetaTable("perfprogettoobiettivoattivitadocentiview_alias1");
	tperfprogettoobiettivoattivitadocentiview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettoobiettivoattivitadocentiview_alias1.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitadocentiview_alias1.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitadocentiview_alias1.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitadocentiview_alias1.ExtendedProperties["TableForReading"]="perfprogettoobiettivoattivitadocentiview";
	Tables.Add(tperfprogettoobiettivoattivitadocentiview_alias1);
	tperfprogettoobiettivoattivitadocentiview_alias1.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVO /////////////////////////////////
	var tperfprogettoobiettivo= new MetaTable("perfprogettoobiettivo");
	tperfprogettoobiettivo.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivo.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivo.defineColumn("description", typeof(string));
	tperfprogettoobiettivo.defineColumn("idattach", typeof(int));
	tperfprogettoobiettivo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("lt", typeof(DateTime));
	tperfprogettoobiettivo.defineColumn("lu", typeof(string));
	tperfprogettoobiettivo.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivo);
	tperfprogettoobiettivo.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	//////////////////// PERFPROGETTODEFAULTVIEW /////////////////////////////////
	var tperfprogettodefaultview= new MetaTable("perfprogettodefaultview");
	tperfprogettodefaultview.defineColumn("didprogsuddannokind_title", typeof(string));
	tperfprogettodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettodefaultview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettodefaultview.defineColumn("idstruttura", typeof(int));
	tperfprogettodefaultview.defineColumn("perfprogetto_benefici", typeof(string));
	tperfprogettodefaultview.defineColumn("perfprogetto_ct", typeof(DateTime));
	tperfprogettodefaultview.defineColumn("perfprogetto_cu", typeof(string));
	tperfprogettodefaultview.defineColumn("perfprogetto_datafineeffettiva", typeof(DateTime));
	tperfprogettodefaultview.defineColumn("perfprogetto_datafineprevista", typeof(DateTime));
	tperfprogettodefaultview.defineColumn("perfprogetto_datainizioeffettiva", typeof(DateTime));
	tperfprogettodefaultview.defineColumn("perfprogetto_datainizioprevista", typeof(DateTime));
	tperfprogettodefaultview.defineColumn("perfprogetto_description", typeof(string));
	tperfprogettodefaultview.defineColumn("perfprogetto_iddidprogsuddannokind", typeof(int));
	tperfprogettodefaultview.defineColumn("perfprogetto_idperfprogettostatus", typeof(int));
	tperfprogettodefaultview.defineColumn("perfprogetto_lt", typeof(DateTime));
	tperfprogettodefaultview.defineColumn("perfprogetto_lu", typeof(string));
	tperfprogettodefaultview.defineColumn("perfprogetto_note", typeof(string));
	tperfprogettodefaultview.defineColumn("perfprogetto_risultato", typeof(decimal));
	tperfprogettodefaultview.defineColumn("perfprogettostatus_title", typeof(string));
	tperfprogettodefaultview.defineColumn("struttura_idstrutturakind", typeof(int));
	tperfprogettodefaultview.defineColumn("struttura_title", typeof(string));
	tperfprogettodefaultview.defineColumn("strutturakind_title", typeof(string));
	tperfprogettodefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettodefaultview);
	tperfprogettodefaultview.defineKey("idperfprogetto");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITA /////////////////////////////////
	var tperfprogettoobiettivoattivita= new MetaTable("perfprogettoobiettivoattivita");
	tperfprogettoobiettivoattivita.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivoattivita.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivita.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivita.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("description", typeof(string));
	tperfprogettoobiettivoattivita.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivoattivita.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivita.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivita.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoobiettivoattivita.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivoattivita);
	tperfprogettoobiettivoattivita.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettoobiettivoattivitadocentiview_alias1.Columns["idperfprogettoobiettivoattivita"]};
	var cChild = new []{perfprogettoobiettivoattivita.Columns["paridperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_perfprogettoobiettivoattivitadocentiview_alias1_paridperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivitadocentiview_alias1.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitadocentiview_alias1_perfprogettoobiettivo_idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_perfprogettoobiettivo_idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettodefaultview.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_perfprogettodefaultview_idperfprogetto",cPar,cChild,false));

	#endregion

}
}
}
