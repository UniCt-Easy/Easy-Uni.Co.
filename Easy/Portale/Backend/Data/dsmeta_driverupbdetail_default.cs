
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
[System.Xml.Serialization.XmlRoot("dsmeta_driverupbdetail_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_driverupbdetail_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycoanview 		=> (MetaTable)Tables["registrycoanview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sortingcoanview 		=> (MetaTable)Tables["sortingcoanview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable driverupbdetail 		=> (MetaTable)Tables["driverupbdetail"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_driverupbdetail_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_driverupbdetail_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_driverupbdetail_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_driverupbdetail_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYCOANVIEW /////////////////////////////////
	var tregistrycoanview= new MetaTable("registrycoanview");
	tregistrycoanview.defineColumn("dropdown_title", typeof(string),false);
	tregistrycoanview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrycoanview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrycoanview.defineColumn("idcategory", typeof(string));
	tregistrycoanview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrycoanview.defineColumn("idcity", typeof(int));
	tregistrycoanview.defineColumn("idnation", typeof(int));
	tregistrycoanview.defineColumn("idreg", typeof(int),false);
	tregistrycoanview.defineColumn("idregistryclass", typeof(string));
	tregistrycoanview.defineColumn("idtitle", typeof(string));
	tregistrycoanview.defineColumn("registry_active", typeof(string));
	tregistrycoanview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrycoanview);
	tregistrycoanview.defineKey("idreg");

	//////////////////// SORTINGCOANVIEW /////////////////////////////////
	var tsortingcoanview= new MetaTable("sortingcoanview");
	tsortingcoanview.defineColumn("dropdown_title", typeof(string),false);
	tsortingcoanview.defineColumn("idsor", typeof(int),false);
	Tables.Add(tsortingcoanview);
	tsortingcoanview.defineKey("idsor");

	//////////////////// DRIVERUPBDETAIL /////////////////////////////////
	var tdriverupbdetail= new MetaTable("driverupbdetail");
	tdriverupbdetail.defineColumn("iddriverupb", typeof(int),false);
	tdriverupbdetail.defineColumn("iddriverupbdetail", typeof(int),false);
	tdriverupbdetail.defineColumn("idreg", typeof(int));
	tdriverupbdetail.defineColumn("idsor", typeof(int),false);
	tdriverupbdetail.defineColumn("quota", typeof(decimal));
	Tables.Add(tdriverupbdetail);
	tdriverupbdetail.defineKey("iddriverupb", "iddriverupbdetail");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrycoanview.Columns["idreg"]};
	var cChild = new []{driverupbdetail.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_driverupbdetail_registrycoanview_idreg",cPar,cChild,false));

	cPar = new []{sortingcoanview.Columns["idsor"]};
	cChild = new []{driverupbdetail.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_driverupbdetail_sortingcoanview_idsor",cPar,cChild,false));

	#endregion

}
}
}
