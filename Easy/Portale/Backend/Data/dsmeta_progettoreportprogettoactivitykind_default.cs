
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoreportprogettoactivitykind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoreportprogettoactivitykind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoactivitykinddefaultview 		=> (MetaTable)Tables["progettoactivitykinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportprogettoactivitykind 		=> (MetaTable)Tables["progettoreportprogettoactivitykind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoreportprogettoactivitykind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoreportprogettoactivitykind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoreportprogettoactivitykind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoreportprogettoactivitykind_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOACTIVITYKINDDEFAULTVIEW /////////////////////////////////
	var tprogettoactivitykinddefaultview= new MetaTable("progettoactivitykinddefaultview");
	tprogettoactivitykinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprogettoactivitykinddefaultview.defineColumn("idprogettoactivitykind", typeof(int),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_active", typeof(string));
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_ct", typeof(DateTime),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_cu", typeof(string),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_description", typeof(string));
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_lt", typeof(DateTime),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_lu", typeof(string),false);
	tprogettoactivitykinddefaultview.defineColumn("progettoactivitykind_sortcode", typeof(int));
	tprogettoactivitykinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tprogettoactivitykinddefaultview);
	tprogettoactivitykinddefaultview.defineKey("idprogettoactivitykind");

	//////////////////// PROGETTOREPORTPROGETTOACTIVITYKIND /////////////////////////////////
	var tprogettoreportprogettoactivitykind= new MetaTable("progettoreportprogettoactivitykind");
	tprogettoreportprogettoactivitykind.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportprogettoactivitykind.defineColumn("cu", typeof(string),false);
	tprogettoreportprogettoactivitykind.defineColumn("idprogettoactivitykind", typeof(int),false);
	tprogettoreportprogettoactivitykind.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportprogettoactivitykind.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportprogettoactivitykind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportprogettoactivitykind);
	tprogettoreportprogettoactivitykind.defineKey("idprogettoactivitykind", "idprogettoreport");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettoactivitykinddefaultview.Columns["idprogettoactivitykind"]};
	var cChild = new []{progettoreportprogettoactivitykind.Columns["idprogettoactivitykind"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettoactivitykind_progettoactivitykinddefaultview_idprogettoactivitykind",cPar,cChild,false));

	#endregion

}
}
}
