
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoreportregistryprogfin_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoreportregistryprogfin_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryprogfinsegview 		=> (MetaTable)Tables["registryprogfinsegview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportregistryprogfin 		=> (MetaTable)Tables["progettoreportregistryprogfin"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoreportregistryprogfin_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoreportregistryprogfin_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoreportregistryprogfin_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoreportregistryprogfin_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYPROGFINSEGVIEW /////////////////////////////////
	var tregistryprogfinsegview= new MetaTable("registryprogfinsegview");
	tregistryprogfinsegview.defineColumn("dropdown_title", typeof(string),false);
	tregistryprogfinsegview.defineColumn("idreg", typeof(int),false);
	tregistryprogfinsegview.defineColumn("idregistryprogfin", typeof(int),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_code", typeof(string));
	tregistryprogfinsegview.defineColumn("registryprogfin_ct", typeof(DateTime),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_cu", typeof(string),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_description", typeof(string));
	tregistryprogfinsegview.defineColumn("registryprogfin_lt", typeof(DateTime),false);
	tregistryprogfinsegview.defineColumn("registryprogfin_lu", typeof(string),false);
	tregistryprogfinsegview.defineColumn("title", typeof(string));
	Tables.Add(tregistryprogfinsegview);
	tregistryprogfinsegview.defineKey("idreg", "idregistryprogfin");

	//////////////////// PROGETTOREPORTREGISTRYPROGFIN /////////////////////////////////
	var tprogettoreportregistryprogfin= new MetaTable("progettoreportregistryprogfin");
	tprogettoreportregistryprogfin.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportregistryprogfin.defineColumn("cu", typeof(string),false);
	tprogettoreportregistryprogfin.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportregistryprogfin.defineColumn("idregistryprogfin", typeof(int),false);
	tprogettoreportregistryprogfin.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportregistryprogfin.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportregistryprogfin);
	tprogettoreportregistryprogfin.defineKey("idprogettoreport", "idregistryprogfin");

	#endregion


	#region DataRelation creation
	var cPar = new []{registryprogfinsegview.Columns["idregistryprogfin"]};
	var cChild = new []{progettoreportregistryprogfin.Columns["idregistryprogfin"]};
	Relations.Add(new DataRelation("FK_progettoreportregistryprogfin_registryprogfinsegview_idregistryprogfin",cPar,cChild,false));

	#endregion

}
}
}
