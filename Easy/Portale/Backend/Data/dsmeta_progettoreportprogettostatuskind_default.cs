
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoreportprogettostatuskind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoreportprogettostatuskind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettostatuskinddefaultview 		=> (MetaTable)Tables["progettostatuskinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportprogettostatuskind 		=> (MetaTable)Tables["progettoreportprogettostatuskind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoreportprogettostatuskind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoreportprogettostatuskind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoreportprogettostatuskind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoreportprogettostatuskind_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOSTATUSKINDDEFAULTVIEW /////////////////////////////////
	var tprogettostatuskinddefaultview= new MetaTable("progettostatuskinddefaultview");
	tprogettostatuskinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributo", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributoente", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributoenterichiesto", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_contributorichiesto", typeof(string));
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_ct", typeof(DateTime),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_cu", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_lt", typeof(DateTime),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_lu", typeof(string),false);
	tprogettostatuskinddefaultview.defineColumn("progettostatuskind_sortcode", typeof(int),false);
	tprogettostatuskinddefaultview.defineColumn("title", typeof(string),false);
	Tables.Add(tprogettostatuskinddefaultview);
	tprogettostatuskinddefaultview.defineKey("idprogettostatuskind");

	//////////////////// PROGETTOREPORTPROGETTOSTATUSKIND /////////////////////////////////
	var tprogettoreportprogettostatuskind= new MetaTable("progettoreportprogettostatuskind");
	tprogettoreportprogettostatuskind.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportprogettostatuskind.defineColumn("cu", typeof(string),false);
	tprogettoreportprogettostatuskind.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportprogettostatuskind.defineColumn("idprogettostatuskind", typeof(int),false);
	tprogettoreportprogettostatuskind.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportprogettostatuskind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportprogettostatuskind);
	tprogettoreportprogettostatuskind.defineKey("idprogettoreport", "idprogettostatuskind");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettostatuskinddefaultview.Columns["idprogettostatuskind"]};
	var cChild = new []{progettoreportprogettostatuskind.Columns["idprogettostatuskind"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettostatuskind_progettostatuskinddefaultview_idprogettostatuskind",cPar,cChild,false));

	#endregion

}
}
}
