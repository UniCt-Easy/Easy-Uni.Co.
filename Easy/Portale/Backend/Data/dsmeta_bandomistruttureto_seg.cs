
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_bandomistruttureto_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_bandomistruttureto_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandomistruttureto 		=> (MetaTable)Tables["bandomistruttureto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_bandomistruttureto_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_bandomistruttureto_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_bandomistruttureto_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_bandomistruttureto_seg.xsd";

	#region create DataTables
	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string),false);
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// BANDOMISTRUTTURETO /////////////////////////////////
	var tbandomistruttureto= new MetaTable("bandomistruttureto");
	tbandomistruttureto.defineColumn("ct", typeof(DateTime),false);
	tbandomistruttureto.defineColumn("cu", typeof(string),false);
	tbandomistruttureto.defineColumn("idbandomi", typeof(int),false);
	tbandomistruttureto.defineColumn("idstruttura", typeof(int),false);
	tbandomistruttureto.defineColumn("lt", typeof(DateTime),false);
	tbandomistruttureto.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandomistruttureto);
	tbandomistruttureto.defineKey("idbandomi", "idstruttura");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_bandomistruttureto_strutturadefaultview_idstruttura","strutturadefaultview","bandomistruttureto","idstruttura");
	#endregion

}
}
}
