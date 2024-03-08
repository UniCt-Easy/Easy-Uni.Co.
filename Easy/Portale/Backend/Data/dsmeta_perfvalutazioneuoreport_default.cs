
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneuoreport_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazioneuoreport_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuoreport 		=> (MetaTable)Tables["perfvalutazioneuoreport"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneuoreport_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneuoreport_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneuoreport_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneuoreport_default.xsd";

	#region create DataTables
	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEUOREPORT /////////////////////////////////
	var tperfvalutazioneuoreport= new MetaTable("perfvalutazioneuoreport");
	tperfvalutazioneuoreport.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuoreport.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuoreport.defineColumn("idperfvalutazioneuoreport", typeof(int),false);
	tperfvalutazioneuoreport.defineColumn("idstruttura", typeof(int));
	tperfvalutazioneuoreport.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuoreport.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuoreport.defineColumn("tipo", typeof(string));
	tperfvalutazioneuoreport.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazioneuoreport);
	tperfvalutazioneuoreport.defineKey("idperfvalutazioneuoreport");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	var cChild = new []{perfvalutazioneuoreport.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoreport_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazioneuoreport.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneuoreport_year_year",cPar,cChild,false));

	#endregion

}
}
}
