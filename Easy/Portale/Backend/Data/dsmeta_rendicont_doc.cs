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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicont_doc"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_rendicont_doc: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontaltrokind 		=> (MetaTable)Tables["rendicontaltrokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontaltro 		=> (MetaTable)Tables["rendicontaltro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicont 		=> (MetaTable)Tables["rendicont"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicont_doc(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicont_doc (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicont_doc";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicont_doc.xsd";

	#region create DataTables
	//////////////////// RENDICONTALTROKIND /////////////////////////////////
	var trendicontaltrokind= new MetaTable("rendicontaltrokind");
	trendicontaltrokind.defineColumn("active", typeof(string),false);
	trendicontaltrokind.defineColumn("idrendicontaltrokind", typeof(int),false);
	trendicontaltrokind.defineColumn("title", typeof(string),false);
	Tables.Add(trendicontaltrokind);
	trendicontaltrokind.defineKey("idrendicontaltrokind");

	//////////////////// RENDICONTALTRO /////////////////////////////////
	var trendicontaltro= new MetaTable("rendicontaltro");
	trendicontaltro.defineColumn("!title", typeof(string));
	trendicontaltro.defineColumn("aa", typeof(string),false);
	trendicontaltro.defineColumn("ct", typeof(DateTime),false);
	trendicontaltro.defineColumn("cu", typeof(string),false);
	trendicontaltro.defineColumn("data", typeof(DateTime),false);
	trendicontaltro.defineColumn("idreg_docenti", typeof(int),false);
	trendicontaltro.defineColumn("idrendicontaltro", typeof(int),false);
	trendicontaltro.defineColumn("idrendicontaltrokind", typeof(int),false);
	trendicontaltro.defineColumn("lt", typeof(DateTime),false);
	trendicontaltro.defineColumn("lu", typeof(string),false);
	trendicontaltro.defineColumn("ore", typeof(decimal),false);
	trendicontaltro.defineColumn("!idrendicontaltrokind_rendicontaltrokind_title", typeof(string));
	Tables.Add(trendicontaltro);
	trendicontaltro.defineKey("aa", "idreg_docenti", "idrendicontaltro");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// RENDICONT /////////////////////////////////
	var trendicont= new MetaTable("rendicont");
	trendicont.defineColumn("aa", typeof(string),false);
	trendicont.defineColumn("ct", typeof(DateTime),false);
	trendicont.defineColumn("cu", typeof(string),false);
	trendicont.defineColumn("idreg_docenti", typeof(int),false);
	trendicont.defineColumn("lt", typeof(DateTime),false);
	trendicont.defineColumn("lu", typeof(string),false);
	trendicont.defineColumn("title", typeof(string));
	Tables.Add(trendicont);
	trendicont.defineKey("aa", "idreg_docenti");

	#endregion


	#region DataRelation creation
	var cPar = new []{rendicont.Columns["aa"], rendicont.Columns["idreg_docenti"]};
	var cChild = new []{rendicontaltro.Columns["aa"], rendicontaltro.Columns["idreg_docenti"]};
	Relations.Add(new DataRelation("FK_rendicontaltro_rendicont_aa-idreg_docenti",cPar,cChild,false));

	cPar = new []{rendicontaltrokind.Columns["idrendicontaltrokind"]};
	cChild = new []{rendicontaltro.Columns["idrendicontaltrokind"]};
	Relations.Add(new DataRelation("FK_rendicontaltro_rendicontaltrokind_idrendicontaltrokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{rendicont.Columns["aa"]};
	Relations.Add(new DataRelation("FK_rendicont_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
