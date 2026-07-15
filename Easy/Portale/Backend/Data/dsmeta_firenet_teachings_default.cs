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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_teachings_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_teachings_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_teachings 		=> (MetaTable)Tables["firenet_teachings"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_teachings_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_teachings_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_teachings_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_teachings_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// FIRENET_TEACHINGS /////////////////////////////////
	var tfirenet_teachings= new MetaTable("firenet_teachings");
	tfirenet_teachings.defineColumn("aa", typeof(int));
	tfirenet_teachings.defineColumn("accumulo_ore", typeof(int));
	tfirenet_teachings.defineColumn("area_disciplinare", typeof(string));
	tfirenet_teachings.defineColumn("attivo", typeof(string));
	tfirenet_teachings.defineColumn("bibliografia", typeof(string));
	tfirenet_teachings.defineColumn("codice", typeof(string));
	tfirenet_teachings.defineColumn("competenze_uscita", typeof(string));
	tfirenet_teachings.defineColumn("created", typeof(DateTime));
	tfirenet_teachings.defineColumn("creda", typeof(int));
	tfirenet_teachings.defineColumn("credb", typeof(int));
	tfirenet_teachings.defineColumn("credc", typeof(int));
	tfirenet_teachings.defineColumn("credd", typeof(int));
	tfirenet_teachings.defineColumn("crede", typeof(int));
	tfirenet_teachings.defineColumn("credf", typeof(int));
	tfirenet_teachings.defineColumn("debiti", typeof(string));
	tfirenet_teachings.defineColumn("descrizione", typeof(string));
	tfirenet_teachings.defineColumn("edit_operator_user_id", typeof(string));
	tfirenet_teachings.defineColumn("english", typeof(string));
	tfirenet_teachings.defineColumn("esame_abilitazione", typeof(string));
	tfirenet_teachings.defineColumn("fit_area_id", typeof(string));
	tfirenet_teachings.defineColumn("frequenza_minima", typeof(string));
	tfirenet_teachings.defineColumn("frequenza_minima_debito", typeof(string));
	tfirenet_teachings.defineColumn("id", typeof(int),false);
	tfirenet_teachings.defineColumn("idoneita", typeof(string));
	tfirenet_teachings.defineColumn("iterabile", typeof(string));
	tfirenet_teachings.defineColumn("livello", typeof(string));
	tfirenet_teachings.defineColumn("modalita", typeof(string));
	tfirenet_teachings.defineColumn("modified", typeof(DateTime));
	tfirenet_teachings.defineColumn("mutuabile", typeof(string));
	tfirenet_teachings.defineColumn("name", typeof(string));
	tfirenet_teachings.defineColumn("obiettivi", typeof(string));
	tfirenet_teachings.defineColumn("operator_user_id", typeof(int));
	tfirenet_teachings.defineColumn("ore", typeof(string));
	tfirenet_teachings.defineColumn("programma", typeof(string));
	tfirenet_teachings.defineColumn("scelta_docente", typeof(string));
	tfirenet_teachings.defineColumn("settore", typeof(string));
	tfirenet_teachings.defineColumn("sitografia", typeof(string));
	tfirenet_teachings.defineColumn("teachingtype_id", typeof(int));
	Tables.Add(tfirenet_teachings);
	tfirenet_teachings.defineKey("id");

	#endregion

}
}
}
