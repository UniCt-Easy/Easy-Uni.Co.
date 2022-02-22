
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontaltro_docente"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_rendicontaltro_docente: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontaltrokinddefaultview 		=> (MetaTable)Tables["rendicontaltrokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontaltro 		=> (MetaTable)Tables["rendicontaltro"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontaltro_docente(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontaltro_docente (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontaltro_docente";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontaltro_docente.xsd";

	#region create DataTables
	//////////////////// RENDICONTALTROKINDDEFAULTVIEW /////////////////////////////////
	var trendicontaltrokinddefaultview= new MetaTable("rendicontaltrokinddefaultview");
	trendicontaltrokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	trendicontaltrokinddefaultview.defineColumn("idrendicontaltrokind", typeof(int),false);
	Tables.Add(trendicontaltrokinddefaultview);
	trendicontaltrokinddefaultview.defineKey("idrendicontaltrokind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

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
	Tables.Add(trendicontaltro);
	trendicontaltro.defineKey("aa", "idreg_docenti", "idrendicontaltro");

	#endregion


	#region DataRelation creation
	var cPar = new []{rendicontaltrokinddefaultview.Columns["idrendicontaltrokind"]};
	var cChild = new []{rendicontaltro.Columns["idrendicontaltrokind"]};
	Relations.Add(new DataRelation("FK_rendicontaltro_rendicontaltrokinddefaultview_idrendicontaltrokind",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{rendicontaltro.Columns["aa"]};
	Relations.Add(new DataRelation("FK_rendicontaltro_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
