
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
[System.Xml.Serialization.XmlRoot("dsmeta_consolidamentorendicontattivitaprogettoora_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_consolidamentorendicontattivitaprogettoora_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoorapersonaleview 		=> (MetaTable)Tables["rendicontattivitaprogettoorapersonaleview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable consolidamentorendicontattivitaprogettoora 		=> (MetaTable)Tables["consolidamentorendicontattivitaprogettoora"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_consolidamentorendicontattivitaprogettoora_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_consolidamentorendicontattivitaprogettoora_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_consolidamentorendicontattivitaprogettoora_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_consolidamentorendicontattivitaprogettoora_default.xsd";

	#region create DataTables
	//////////////////// RENDICONTATTIVITAPROGETTOORAPERSONALEVIEW /////////////////////////////////
	var trendicontattivitaprogettoorapersonaleview= new MetaTable("rendicontattivitaprogettoorapersonaleview");
	trendicontattivitaprogettoorapersonaleview.defineColumn("dropdown_title", typeof(string),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("idprogetto", typeof(int));
	trendicontattivitaprogettoorapersonaleview.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("progetto_titolobreve", typeof(string));
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogetto_description", typeof(string));
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_ct", typeof(DateTime),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_cu", typeof(string),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_data", typeof(DateTime));
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_idconsolidamento", typeof(int));
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_idreg", typeof(int));
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_idsal", typeof(int));
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_lt", typeof(DateTime),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_lu", typeof(string),false);
	trendicontattivitaprogettoorapersonaleview.defineColumn("rendicontattivitaprogettoora_ore", typeof(int));
	trendicontattivitaprogettoorapersonaleview.defineColumn("sal_start", typeof(DateTime));
	trendicontattivitaprogettoorapersonaleview.defineColumn("sal_stop", typeof(DateTime));
	trendicontattivitaprogettoorapersonaleview.defineColumn("workpackage_raggruppamento", typeof(string));
	trendicontattivitaprogettoorapersonaleview.defineColumn("workpackage_title", typeof(string));
	Tables.Add(trendicontattivitaprogettoorapersonaleview);
	trendicontattivitaprogettoorapersonaleview.defineKey("idrendicontattivitaprogetto", "idrendicontattivitaprogettoora", "idworkpackage");

	//////////////////// CONSOLIDAMENTORENDICONTATTIVITAPROGETTOORA /////////////////////////////////
	var tconsolidamentorendicontattivitaprogettoora= new MetaTable("consolidamentorendicontattivitaprogettoora");
	tconsolidamentorendicontattivitaprogettoora.defineColumn("ct", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("cu", typeof(string));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("idconsolidamento", typeof(int),false);
	tconsolidamentorendicontattivitaprogettoora.defineColumn("idrendicontattivitaprogettoora", typeof(int),false);
	tconsolidamentorendicontattivitaprogettoora.defineColumn("lt", typeof(DateTime));
	tconsolidamentorendicontattivitaprogettoora.defineColumn("lu", typeof(string));
	Tables.Add(tconsolidamentorendicontattivitaprogettoora);
	tconsolidamentorendicontattivitaprogettoora.defineKey("idconsolidamento", "idrendicontattivitaprogettoora");

	#endregion


	#region DataRelation creation
	var cPar = new []{rendicontattivitaprogettoorapersonaleview.Columns["idrendicontattivitaprogettoora"]};
	var cChild = new []{consolidamentorendicontattivitaprogettoora.Columns["idrendicontattivitaprogettoora"]};
	Relations.Add(new DataRelation("FK_consolidamentorendicontattivitaprogettoora_rendicontattivitaprogettoorapersonaleview_idrendicontattivitaprogettoora",cPar,cChild,false));

	#endregion

}
}
}
