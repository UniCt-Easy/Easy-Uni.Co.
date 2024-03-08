
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuostatuschanges_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazioneuostatuschanges_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuostatuschanges 		=> (MetaTable)Tables["perfvalutazioneuostatuschanges"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneuostatuschanges_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuostatuschanges_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuostatuschanges_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuostatuschanges_default.xsd";

	#region create DataTables
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

	//////////////////// PERFVALUTAZIONEUOSTATUSCHANGES /////////////////////////////////
	var tperfvalutazioneuostatuschanges= new MetaTable("perfvalutazioneuostatuschanges");
	tperfvalutazioneuostatuschanges.defineColumn("changedate", typeof(DateTime));
	tperfvalutazioneuostatuschanges.defineColumn("changeuser", typeof(string));
	tperfvalutazioneuostatuschanges.defineColumn("ct", typeof(DateTime));
	tperfvalutazioneuostatuschanges.defineColumn("cu", typeof(string));
	tperfvalutazioneuostatuschanges.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazioneuostatuschanges.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuostatuschanges.defineColumn("idperfvalutazioneuostatuschanges", typeof(int),false);
	tperfvalutazioneuostatuschanges.defineColumn("lt", typeof(DateTime));
	tperfvalutazioneuostatuschanges.defineColumn("lu", typeof(string));
	Tables.Add(tperfvalutazioneuostatuschanges);
	tperfvalutazioneuostatuschanges.defineKey("idperfvalutazioneuo", "idperfvalutazioneuostatuschanges");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	var cChild = new []{perfvalutazioneuostatuschanges.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuostatuschanges_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	#endregion

}
}
}
