
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonalestatuschanges_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazionepersonalestatuschanges_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfschedastatusdefaultview 		=> (MetaTable)Tables["perfschedastatusdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonalestatuschanges 		=> (MetaTable)Tables["perfvalutazionepersonalestatuschanges"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazionepersonalestatuschanges_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonalestatuschanges_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonalestatuschanges_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonalestatuschanges_default.xsd";

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

	//////////////////// PERFVALUTAZIONEPERSONALESTATUSCHANGES /////////////////////////////////
	var tperfvalutazionepersonalestatuschanges= new MetaTable("perfvalutazionepersonalestatuschanges");
	tperfvalutazionepersonalestatuschanges.defineColumn("changedate", typeof(DateTime));
	tperfvalutazionepersonalestatuschanges.defineColumn("changeuser", typeof(string));
	tperfvalutazionepersonalestatuschanges.defineColumn("ct", typeof(DateTime));
	tperfvalutazionepersonalestatuschanges.defineColumn("cu", typeof(string));
	tperfvalutazionepersonalestatuschanges.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazionepersonalestatuschanges.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonalestatuschanges.defineColumn("idperfvalutazionepersonalestatuschanges", typeof(int),false);
	tperfvalutazionepersonalestatuschanges.defineColumn("lt", typeof(DateTime));
	tperfvalutazionepersonalestatuschanges.defineColumn("lu", typeof(string));
	Tables.Add(tperfvalutazionepersonalestatuschanges);
	tperfvalutazionepersonalestatuschanges.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonalestatuschanges");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfschedastatusdefaultview.Columns["idperfschedastatus"]};
	var cChild = new []{perfvalutazionepersonalestatuschanges.Columns["idperfschedastatus"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonalestatuschanges_perfschedastatusdefaultview_idperfschedastatus",cPar,cChild,false));

	#endregion

}
}
}
