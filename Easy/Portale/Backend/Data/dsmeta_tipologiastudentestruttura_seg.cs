
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
[System.Xml.Serialization.XmlRoot("dsmeta_tipologiastudentestruttura_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tipologiastudentestruttura_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tipologiastudentestruttura 		=> (MetaTable)Tables["tipologiastudentestruttura"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tipologiastudentestruttura_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tipologiastudentestruttura_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tipologiastudentestruttura_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tipologiastudentestruttura_seg.xsd";

	#region create DataTables
	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_struttura_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturaparent_idstrutturakind", typeof(int));
	tstrutturadefaultview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// TIPOLOGIASTUDENTESTRUTTURA /////////////////////////////////
	var ttipologiastudentestruttura= new MetaTable("tipologiastudentestruttura");
	ttipologiastudentestruttura.defineColumn("ct", typeof(DateTime),false);
	ttipologiastudentestruttura.defineColumn("cu", typeof(string),false);
	ttipologiastudentestruttura.defineColumn("idbandods", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("idbandodsservizio", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("idstruttura", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("idtipologiastudente", typeof(int),false);
	ttipologiastudentestruttura.defineColumn("lt", typeof(DateTime),false);
	ttipologiastudentestruttura.defineColumn("lu", typeof(string),false);
	Tables.Add(ttipologiastudentestruttura);
	ttipologiastudentestruttura.defineKey("idbandods", "idbandodsservizio", "idstruttura", "idtipologiastudente");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	var cChild = new []{tipologiastudentestruttura.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_tipologiastudentestruttura_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
