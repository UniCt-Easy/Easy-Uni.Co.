
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
[System.Xml.Serialization.XmlRoot("dsmeta_sessione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_sessione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessionekinddefaultview 		=> (MetaTable)Tables["sessionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appellokinddefaultview 		=> (MetaTable)Tables["appellokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sessione 		=> (MetaTable)Tables["sessione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_sessione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_sessione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_sessione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_sessione_default.xsd";

	#region create DataTables
	//////////////////// SESSIONEKINDDEFAULTVIEW /////////////////////////////////
	var tsessionekinddefaultview= new MetaTable("sessionekinddefaultview");
	tsessionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsessionekinddefaultview.defineColumn("idsessionekind", typeof(int),false);
	tsessionekinddefaultview.defineColumn("sessionekind_active", typeof(string));
	Tables.Add(tsessionekinddefaultview);
	tsessionekinddefaultview.defineKey("idsessionekind");

	//////////////////// APPELLOKINDDEFAULTVIEW /////////////////////////////////
	var tappellokinddefaultview= new MetaTable("appellokinddefaultview");
	tappellokinddefaultview.defineColumn("appellokind_active", typeof(string));
	tappellokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tappellokinddefaultview.defineColumn("idappellokind", typeof(int),false);
	Tables.Add(tappellokinddefaultview);
	tappellokinddefaultview.defineKey("idappellokind");

	//////////////////// SESSIONE /////////////////////////////////
	var tsessione= new MetaTable("sessione");
	tsessione.defineColumn("ct", typeof(DateTime),false);
	tsessione.defineColumn("cu", typeof(string),false);
	tsessione.defineColumn("idappellokind", typeof(int));
	tsessione.defineColumn("idsessione", typeof(int),false);
	tsessione.defineColumn("idsessionekind", typeof(int));
	tsessione.defineColumn("lt", typeof(DateTime),false);
	tsessione.defineColumn("lu", typeof(string),false);
	tsessione.defineColumn("start", typeof(DateTime));
	tsessione.defineColumn("stop", typeof(DateTime));
	Tables.Add(tsessione);
	tsessione.defineKey("idsessione");

	#endregion


	#region DataRelation creation
	var cPar = new []{sessionekinddefaultview.Columns["idsessionekind"]};
	var cChild = new []{sessione.Columns["idsessionekind"]};
	Relations.Add(new DataRelation("FK_sessione_sessionekinddefaultview_idsessionekind",cPar,cChild,false));

	cPar = new []{appellokinddefaultview.Columns["idappellokind"]};
	cChild = new []{sessione.Columns["idappellokind"]};
	Relations.Add(new DataRelation("FK_sessione_appellokinddefaultview_idappellokind",cPar,cChild,false));

	#endregion

}
}
}
