/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_debitoesonero_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_debitoesonero_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerostudenteseganagstuview 		=> (MetaTable)Tables["esonerostudenteseganagstuview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable debitoesonero 		=> (MetaTable)Tables["debitoesonero"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_debitoesonero_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_debitoesonero_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_debitoesonero_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_debitoesonero_seg.xsd";

	#region create DataTables
	//////////////////// ESONEROSTUDENTESEGANAGSTUVIEW /////////////////////////////////
	var tesonerostudenteseganagstuview= new MetaTable("esonerostudenteseganagstuview");
	tesonerostudenteseganagstuview.defineColumn("aa", typeof(string));
	tesonerostudenteseganagstuview.defineColumn("dropdown_title", typeof(string),false);
	tesonerostudenteseganagstuview.defineColumn("esonero_title", typeof(string));
	tesonerostudenteseganagstuview.defineColumn("esonerostudente_ct", typeof(DateTime),false);
	tesonerostudenteseganagstuview.defineColumn("esonerostudente_cu", typeof(string),false);
	tesonerostudenteseganagstuview.defineColumn("esonerostudente_esito", typeof(string));
	tesonerostudenteseganagstuview.defineColumn("esonerostudente_lt", typeof(DateTime),false);
	tesonerostudenteseganagstuview.defineColumn("esonerostudente_lu", typeof(string),false);
	tesonerostudenteseganagstuview.defineColumn("idesonero", typeof(int),false);
	tesonerostudenteseganagstuview.defineColumn("idesonerostudente", typeof(int),false);
	tesonerostudenteseganagstuview.defineColumn("idiscrizione", typeof(int));
	tesonerostudenteseganagstuview.defineColumn("idreg", typeof(int),false);
	tesonerostudenteseganagstuview.defineColumn("iscrizione_aa", typeof(string));
	tesonerostudenteseganagstuview.defineColumn("iscrizione_anno", typeof(int));
	tesonerostudenteseganagstuview.defineColumn("iscrizione_iddidprog", typeof(int));
	Tables.Add(tesonerostudenteseganagstuview);
	tesonerostudenteseganagstuview.defineKey("idesonero", "idesonerostudente", "idreg");

	//////////////////// DEBITOESONERO /////////////////////////////////
	var tdebitoesonero= new MetaTable("debitoesonero");
	tdebitoesonero.defineColumn("ct", typeof(DateTime));
	tdebitoesonero.defineColumn("cu", typeof(string));
	tdebitoesonero.defineColumn("iddebito", typeof(int),false);
	tdebitoesonero.defineColumn("idesonerostudente", typeof(int),false);
	tdebitoesonero.defineColumn("lt", typeof(DateTime));
	tdebitoesonero.defineColumn("lu", typeof(string));
	Tables.Add(tdebitoesonero);
	tdebitoesonero.defineKey("iddebito", "idesonerostudente");

	#endregion


	#region DataRelation creation
	var cPar = new []{esonerostudenteseganagstuview.Columns["idesonerostudente"]};
	var cChild = new []{debitoesonero.Columns["idesonerostudente"]};
	Relations.Add(new DataRelation("FK_debitoesonero_esonerostudenteseganagstuview_idesonerostudente",cPar,cChild,false));

	#endregion

}
}
}
