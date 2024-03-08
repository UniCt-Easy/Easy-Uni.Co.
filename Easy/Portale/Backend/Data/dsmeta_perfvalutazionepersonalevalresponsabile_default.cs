
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonalevalresponsabile_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazionepersonalevalresponsabile_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalecampaniasintview 		=> (MetaTable)Tables["perfvalutazionepersonalecampaniasintview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalevalresponsabile 		=> (MetaTable)Tables["perfvalutazionepersonalevalresponsabile"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazionepersonalevalresponsabile_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonalevalresponsabile_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonalevalresponsabile_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonalevalresponsabile_default.xsd";

	#region create DataTables
	//////////////////// PERFVALUTAZIONEPERSONALECAMPANIASINTVIEW /////////////////////////////////
	var tperfvalutazionepersonalecampaniasintview= new MetaTable("perfvalutazionepersonalecampaniasintview");
	tperfvalutazionepersonalecampaniasintview.defineColumn("afferenza_idmansionekind", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("afferenza_idstruttura", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("afferenza_start", typeof(DateTime));
	tperfvalutazionepersonalecampaniasintview.defineColumn("afferenza_stop", typeof(DateTime));
	tperfvalutazionepersonalecampaniasintview.defineColumn("dropdown_title", typeof(string),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("idafferenza", typeof(int),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("idreg", typeof(int),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("mansionekind_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfschedastatus_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_ct", typeof(DateTime),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_cu", typeof(string),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idperfschedastatus", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idreg_appr", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idreg_comp", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idreg_compcomp", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idreg_create", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idreg_val", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_idreg_valcomp", typeof(int));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_lt", typeof(DateTime),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_lu", typeof(string),false);
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_percateneo", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_perccomportamenti", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_percobiettivi", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_percperfuo", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_pesoateneo", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_pesocomportamenti", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_pesoobiettivi", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_pesoperfuo", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("perfvalutazionepersonale_risultato", typeof(decimal));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registry_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registryappr_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registrycomp_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registrycompcomp_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registrycreate_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registryval_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("registryvalcomp_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("struttura_title", typeof(string));
	tperfvalutazionepersonalecampaniasintview.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazionepersonalecampaniasintview);
	tperfvalutazionepersonalecampaniasintview.defineKey("idafferenza", "idperfvalutazionepersonale", "idreg");

	//////////////////// PERFVALUTAZIONEPERSONALEVALRESPONSABILE /////////////////////////////////
	var tperfvalutazionepersonalevalresponsabile= new MetaTable("perfvalutazionepersonalevalresponsabile");
	tperfvalutazionepersonalevalresponsabile.defineColumn("ct", typeof(DateTime));
	tperfvalutazionepersonalevalresponsabile.defineColumn("cu", typeof(string));
	tperfvalutazionepersonalevalresponsabile.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalevalresponsabile.defineColumn("idperfvalutazionepersonale_responsabile", typeof(int),false);
	tperfvalutazionepersonalevalresponsabile.defineColumn("lt", typeof(DateTime));
	tperfvalutazionepersonalevalresponsabile.defineColumn("lu", typeof(string));
	Tables.Add(tperfvalutazionepersonalevalresponsabile);
	tperfvalutazionepersonalevalresponsabile.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonale_responsabile");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazionepersonalecampaniasintview.Columns["idperfvalutazionepersonale"]};
	var cChild = new []{perfvalutazionepersonalevalresponsabile.Columns["idperfvalutazionepersonale_responsabile"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalevalresponsabile_perfvalutazionepersonalecampaniasintview_idperfvalutazionepersonale_responsabile",cPar,cChild,false));

	#endregion

}
}
}
