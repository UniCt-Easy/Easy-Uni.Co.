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
[System.Xml.Serialization.XmlRoot("dsmeta_esonerostudente_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_esonerostudente_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable iscrizionedefaultview 		=> (MetaTable)Tables["iscrizionedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerodefaultview 		=> (MetaTable)Tables["esonerodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable esonerostudente 		=> (MetaTable)Tables["esonerostudente"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_esonerostudente_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_esonerostudente_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_esonerostudente_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_esonerostudente_seganagstu.xsd";

	#region create DataTables
	//////////////////// ISCRIZIONEDEFAULTVIEW /////////////////////////////////
	var tiscrizionedefaultview= new MetaTable("iscrizionedefaultview");
	tiscrizionedefaultview.defineColumn("aa", typeof(string),false);
	tiscrizionedefaultview.defineColumn("anno", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_aa", typeof(string));
	tiscrizionedefaultview.defineColumn("didprog_idsede", typeof(int));
	tiscrizionedefaultview.defineColumn("didprog_title", typeof(string));
	tiscrizionedefaultview.defineColumn("dropdown_title", typeof(string),false);
	tiscrizionedefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iddidprog", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idiscrizione", typeof(int),false);
	tiscrizionedefaultview.defineColumn("idreg", typeof(int),false);
	tiscrizionedefaultview.defineColumn("iscrizione_ct", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_cu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_data", typeof(DateTime));
	tiscrizionedefaultview.defineColumn("iscrizione_lt", typeof(DateTime),false);
	tiscrizionedefaultview.defineColumn("iscrizione_lu", typeof(string),false);
	tiscrizionedefaultview.defineColumn("iscrizione_matricola", typeof(string));
	tiscrizionedefaultview.defineColumn("registry_title", typeof(string));
	tiscrizionedefaultview.defineColumn("sede_title", typeof(string));
	Tables.Add(tiscrizionedefaultview);
	tiscrizionedefaultview.defineKey("idcorsostudio", "iddidprog", "idiscrizione", "idreg");

	//////////////////// ESONERODEFAULTVIEW /////////////////////////////////
	var tesonerodefaultview= new MetaTable("esonerodefaultview");
	tesonerodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tesonerodefaultview.defineColumn("idesonero", typeof(int),false);
	Tables.Add(tesonerodefaultview);
	tesonerodefaultview.defineKey("idesonero");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ESONEROSTUDENTE /////////////////////////////////
	var tesonerostudente= new MetaTable("esonerostudente");
	tesonerostudente.defineColumn("aa", typeof(string));
	tesonerostudente.defineColumn("ct", typeof(DateTime),false);
	tesonerostudente.defineColumn("cu", typeof(string),false);
	tesonerostudente.defineColumn("esito", typeof(string));
	tesonerostudente.defineColumn("idesonero", typeof(int),false);
	tesonerostudente.defineColumn("idesonerostudente", typeof(int),false);
	tesonerostudente.defineColumn("idiscrizione", typeof(int));
	tesonerostudente.defineColumn("idreg", typeof(int),false);
	tesonerostudente.defineColumn("lt", typeof(DateTime),false);
	tesonerostudente.defineColumn("lu", typeof(string),false);
	Tables.Add(tesonerostudente);
	tesonerostudente.defineKey("idesonero", "idesonerostudente", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{iscrizionedefaultview.Columns["idiscrizione"]};
	var cChild = new []{esonerostudente.Columns["idiscrizione"]};
	Relations.Add(new DataRelation("FK_esonerostudente_iscrizionedefaultview_idiscrizione",cPar,cChild,false));

	cPar = new []{esonerodefaultview.Columns["idesonero"]};
	cChild = new []{esonerostudente.Columns["idesonero"]};
	Relations.Add(new DataRelation("FK_esonerostudente_esonerodefaultview_idesonero",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{esonerostudente.Columns["aa"]};
	Relations.Add(new DataRelation("FK_esonerostudente_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
