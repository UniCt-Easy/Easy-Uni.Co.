
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
[System.Xml.Serialization.XmlRoot("dsmeta_titolostudio_docenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_titolostudio_docenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registryistitutiview 		=> (MetaTable)Tables["registryistitutiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable istattitolistudio 		=> (MetaTable)Tables["istattitolistudio"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable titolostudio 		=> (MetaTable)Tables["titolostudio"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_titolostudio_docenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_titolostudio_docenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_titolostudio_docenti";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_titolostudio_docenti.xsd";

	#region create DataTables
	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// REGISTRYISTITUTIVIEW /////////////////////////////////
	var tregistryistitutiview= new MetaTable("registryistitutiview");
	tregistryistitutiview.defineColumn("dropdown_title", typeof(string),false);
	tregistryistitutiview.defineColumn("idreg", typeof(int),false);
	tregistryistitutiview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistryistitutiview);
	tregistryistitutiview.defineKey("idreg");

	//////////////////// ISTATTITOLISTUDIO /////////////////////////////////
	var tistattitolistudio= new MetaTable("istattitolistudio");
	tistattitolistudio.defineColumn("idistattitolistudio", typeof(int),false);
	tistattitolistudio.defineColumn("titolo", typeof(string),false);
	Tables.Add(tistattitolistudio);
	tistattitolistudio.defineKey("idistattitolistudio");

	//////////////////// TITOLOSTUDIO /////////////////////////////////
	var ttitolostudio= new MetaTable("titolostudio");
	ttitolostudio.defineColumn("aa", typeof(string),false);
	ttitolostudio.defineColumn("conseguito", typeof(string),false);
	ttitolostudio.defineColumn("ct", typeof(DateTime));
	ttitolostudio.defineColumn("cu", typeof(string));
	ttitolostudio.defineColumn("data", typeof(DateTime),false);
	ttitolostudio.defineColumn("giudizio", typeof(string));
	ttitolostudio.defineColumn("idattach", typeof(int));
	ttitolostudio.defineColumn("idistattitolistudio", typeof(int),false);
	ttitolostudio.defineColumn("idreg", typeof(int),false);
	ttitolostudio.defineColumn("idreg_istituti", typeof(int),false);
	ttitolostudio.defineColumn("idtitolostudio", typeof(int),false);
	ttitolostudio.defineColumn("lt", typeof(DateTime));
	ttitolostudio.defineColumn("lu", typeof(string));
	ttitolostudio.defineColumn("voto", typeof(int));
	ttitolostudio.defineColumn("votolode", typeof(string));
	ttitolostudio.defineColumn("votosu", typeof(int));
	Tables.Add(ttitolostudio);
	ttitolostudio.defineKey("idreg", "idtitolostudio");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach.Columns["idattach"]};
	var cChild = new []{titolostudio.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_titolostudio_attach_idattach",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{titolostudio.Columns["aa"]};
	Relations.Add(new DataRelation("FK_titolostudio_annoaccademico_aa",cPar,cChild,false));

	cPar = new []{registryistitutiview.Columns["idreg"]};
	cChild = new []{titolostudio.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("FK_titolostudio_registryistitutiview_idreg_istituti",cPar,cChild,false));

	cPar = new []{istattitolistudio.Columns["idistattitolistudio"]};
	cChild = new []{titolostudio.Columns["idistattitolistudio"]};
	Relations.Add(new DataRelation("FK_titolostudio_istattitolistudio_idistattitolistudio",cPar,cChild,false));

	#endregion

}
}
}
