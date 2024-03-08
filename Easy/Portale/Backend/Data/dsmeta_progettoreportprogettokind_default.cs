
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoreportprogettokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoreportprogettokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettokindsegview 		=> (MetaTable)Tables["progettokindsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportprogettokind 		=> (MetaTable)Tables["progettoreportprogettokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoreportprogettokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoreportprogettokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoreportprogettokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoreportprogettokind_default.xsd";

	#region create DataTables
	//////////////////// PROGETTOKINDSEGVIEW /////////////////////////////////
	var tprogettokindsegview= new MetaTable("progettokindsegview");
	tprogettokindsegview.defineColumn("dropdown_title", typeof(string),false);
	tprogettokindsegview.defineColumn("idprogettokind", typeof(int),false);
	tprogettokindsegview.defineColumn("progettoactivitykind_title", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_ct", typeof(DateTime));
	tprogettokindsegview.defineColumn("progettokind_cu", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_description", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_idcorsostudio", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_idprogettoactivitykind", typeof(int));
	tprogettokindsegview.defineColumn("progettokind_lt", typeof(DateTime));
	tprogettokindsegview.defineColumn("progettokind_lu", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_oredivisionecostostipendio", typeof(int));
	tprogettokindsegview.defineColumn("progettokind_stipendioannoprec", typeof(string));
	tprogettokindsegview.defineColumn("progettokind_stipendiocomericavo", typeof(string));
	tprogettokindsegview.defineColumn("title", typeof(string));
	Tables.Add(tprogettokindsegview);
	tprogettokindsegview.defineKey("idprogettokind");

	//////////////////// PROGETTOREPORTPROGETTOKIND /////////////////////////////////
	var tprogettoreportprogettokind= new MetaTable("progettoreportprogettokind");
	tprogettoreportprogettokind.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportprogettokind.defineColumn("cu", typeof(string),false);
	tprogettoreportprogettokind.defineColumn("idprogettokind", typeof(int),false);
	tprogettoreportprogettokind.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportprogettokind.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportprogettokind.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportprogettokind);
	tprogettoreportprogettokind.defineKey("idprogettokind", "idprogettoreport");

	#endregion


	#region DataRelation creation
	var cPar = new []{progettokindsegview.Columns["idprogettokind"]};
	var cChild = new []{progettoreportprogettokind.Columns["idprogettokind"]};
	Relations.Add(new DataRelation("FK_progettoreportprogettokind_progettokindsegview_idprogettokind",cPar,cChild,false));

	#endregion

}
}
}
