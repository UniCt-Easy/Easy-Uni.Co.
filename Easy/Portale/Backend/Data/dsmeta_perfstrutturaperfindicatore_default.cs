
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfstrutturaperfindicatore_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfstrutturaperfindicatore_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatoredefaultview 		=> (MetaTable)Tables["perfindicatoredefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfstrutturaperfindicatore 		=> (MetaTable)Tables["perfstrutturaperfindicatore"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfstrutturaperfindicatore_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfstrutturaperfindicatore_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfstrutturaperfindicatore_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfstrutturaperfindicatore_default.xsd";

	#region create DataTables
	//////////////////// PERFINDICATOREDEFAULTVIEW /////////////////////////////////
	var tperfindicatoredefaultview= new MetaTable("perfindicatoredefaultview");
	tperfindicatoredefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfindicatoredefaultview.defineColumn("idperfindicatore", typeof(int),false);
	tperfindicatoredefaultview.defineColumn("perfindicatore_ct", typeof(DateTime),false);
	tperfindicatoredefaultview.defineColumn("perfindicatore_cu", typeof(string),false);
	tperfindicatoredefaultview.defineColumn("perfindicatore_description", typeof(string),false);
	tperfindicatoredefaultview.defineColumn("perfindicatore_idperfindicatorekind", typeof(int));
	tperfindicatoredefaultview.defineColumn("perfindicatore_inverso", typeof(string));
	tperfindicatoredefaultview.defineColumn("perfindicatore_lt", typeof(DateTime),false);
	tperfindicatoredefaultview.defineColumn("perfindicatore_lu", typeof(string),false);
	tperfindicatoredefaultview.defineColumn("perfindicatorekind_title", typeof(string));
	tperfindicatoredefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfindicatoredefaultview);
	tperfindicatoredefaultview.defineKey("idperfindicatore");

	//////////////////// PERFSTRUTTURAPERFINDICATORE /////////////////////////////////
	var tperfstrutturaperfindicatore= new MetaTable("perfstrutturaperfindicatore");
	tperfstrutturaperfindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfstrutturaperfindicatore.defineColumn("cu", typeof(string),false);
	tperfstrutturaperfindicatore.defineColumn("idperfindicatore", typeof(int),false);
	tperfstrutturaperfindicatore.defineColumn("idstruttura", typeof(int),false);
	tperfstrutturaperfindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfstrutturaperfindicatore.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfstrutturaperfindicatore);
	tperfstrutturaperfindicatore.defineKey("idperfindicatore", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfindicatoredefaultview.Columns["idperfindicatore"]};
	var cChild = new []{perfstrutturaperfindicatore.Columns["idperfindicatore"]};
	Relations.Add(new DataRelation("FK_perfstrutturaperfindicatore_perfindicatoredefaultview_idperfindicatore",cPar,cChild,false));

	#endregion

}
}
}
