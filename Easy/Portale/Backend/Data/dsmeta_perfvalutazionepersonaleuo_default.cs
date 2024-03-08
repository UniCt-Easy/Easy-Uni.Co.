
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazionepersonaleuo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazionepersonaleuo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaleuo 		=> (MetaTable)Tables["perfvalutazionepersonaleuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazionepersonaleuo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazionepersonaleuo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazionepersonaleuo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazionepersonaleuo_default.xsd";

	#region create DataTables
	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// PERFVALUTAZIONEPERSONALEUO /////////////////////////////////
	var tperfvalutazionepersonaleuo= new MetaTable("perfvalutazionepersonaleuo");
	tperfvalutazionepersonaleuo.defineColumn("afferenza", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazionepersonaleuo.defineColumn("cu", typeof(string),false);
	tperfvalutazionepersonaleuo.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaleuo.defineColumn("idperfvalutazionepersonaleuo", typeof(int),false);
	tperfvalutazionepersonaleuo.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazionepersonaleuo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazionepersonaleuo.defineColumn("lu", typeof(string),false);
	tperfvalutazionepersonaleuo.defineColumn("peso", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("punteggio", typeof(decimal));
	tperfvalutazionepersonaleuo.defineColumn("punteggiopesato", typeof(decimal));
	Tables.Add(tperfvalutazionepersonaleuo);
	tperfvalutazionepersonaleuo.defineKey("idperfvalutazionepersonale", "idperfvalutazionepersonaleuo", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	var cChild = new []{perfvalutazionepersonaleuo.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfvalutazionepersonaleuo_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
