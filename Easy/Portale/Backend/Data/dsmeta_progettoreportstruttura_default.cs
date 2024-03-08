
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoreportstruttura_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettoreportstruttura_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaperfelenchiparentview 		=> (MetaTable)Tables["strutturaperfelenchiparentview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoreportstruttura 		=> (MetaTable)Tables["progettoreportstruttura"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoreportstruttura_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoreportstruttura_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoreportstruttura_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoreportstruttura_default.xsd";

	#region create DataTables
	//////////////////// STRUTTURAPERFELENCHIPARENTVIEW /////////////////////////////////
	var tstrutturaperfelenchiparentview= new MetaTable("strutturaperfelenchiparentview");
	tstrutturaperfelenchiparentview.defineColumn("aoo_title", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturaperfelenchiparentview.defineColumn("idstruttura", typeof(int),false);
	tstrutturaperfelenchiparentview.defineColumn("idupb", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("sede_title", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_active", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_codice", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturaperfelenchiparentview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturaperfelenchiparentview.defineColumn("struttura_email", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_fax", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturaperfelenchiparentview.defineColumn("struttura_idreg", typeof(int));
	tstrutturaperfelenchiparentview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturaperfelenchiparentview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturaperfelenchiparentview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturaperfelenchiparentview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturaperfelenchiparentview.defineColumn("struttura_paridstruttura", typeof(int));
	tstrutturaperfelenchiparentview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturaperfelenchiparentview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturaperfelenchiparentview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturaperfelenchiparentview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturaperfelenchiparentview.defineColumn("struttura_telefono", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("struttura_title_en", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("strutturakind_title", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("title", typeof(string));
	tstrutturaperfelenchiparentview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturaperfelenchiparentview);
	tstrutturaperfelenchiparentview.defineKey("idstruttura");

	//////////////////// PROGETTOREPORTSTRUTTURA /////////////////////////////////
	var tprogettoreportstruttura= new MetaTable("progettoreportstruttura");
	tprogettoreportstruttura.defineColumn("ct", typeof(DateTime),false);
	tprogettoreportstruttura.defineColumn("cu", typeof(string),false);
	tprogettoreportstruttura.defineColumn("idprogettoreport", typeof(int),false);
	tprogettoreportstruttura.defineColumn("idstruttura", typeof(int),false);
	tprogettoreportstruttura.defineColumn("lt", typeof(DateTime),false);
	tprogettoreportstruttura.defineColumn("lu", typeof(string),false);
	Tables.Add(tprogettoreportstruttura);
	tprogettoreportstruttura.defineKey("idprogettoreport", "idstruttura");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturaperfelenchiparentview.Columns["idstruttura"]};
	var cChild = new []{progettoreportstruttura.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_progettoreportstruttura_strutturaperfelenchiparentview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
