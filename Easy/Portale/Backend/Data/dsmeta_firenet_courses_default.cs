
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_courses_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_courses_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_courses 		=> (MetaTable)Tables["firenet_courses"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_courses_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_courses_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_courses_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_courses_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// FIRENET_COURSES /////////////////////////////////
	var tfirenet_courses= new MetaTable("firenet_courses");
	tfirenet_courses.defineColumn("aa", typeof(string));
	tfirenet_courses.defineColumn("attivo", typeof(decimal));
	tfirenet_courses.defineColumn("contributo", typeof(decimal));
	tfirenet_courses.defineColumn("corso_singolo", typeof(string));
	tfirenet_courses.defineColumn("created", typeof(DateTime));
	tfirenet_courses.defineColumn("creditifinali", typeof(string));
	tfirenet_courses.defineColumn("dcpl", typeof(string));
	tfirenet_courses.defineColumn("debiti_attribuibili", typeof(string));
	tfirenet_courses.defineColumn("descrizione", typeof(string));
	tfirenet_courses.defineColumn("dipartimento", typeof(string));
	tfirenet_courses.defineColumn("durata", typeof(string));
	tfirenet_courses.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_courses.defineColumn("english", typeof(string));
	tfirenet_courses.defineColumn("fit", typeof(string));
	tfirenet_courses.defineColumn("id", typeof(int),false);
	tfirenet_courses.defineColumn("master", typeof(string));
	tfirenet_courses.defineColumn("mediaponderata", typeof(string));
	tfirenet_courses.defineColumn("modalita_prova_finale", typeof(string));
	tfirenet_courses.defineColumn("modalita_selezione", typeof(string));
	tfirenet_courses.defineColumn("modified", typeof(DateTime));
	tfirenet_courses.defineColumn("name", typeof(string));
	tfirenet_courses.defineColumn("note", typeof(string));
	tfirenet_courses.defineColumn("obiettivi_formativi", typeof(string));
	tfirenet_courses.defineColumn("obiettivi_formativi_en", typeof(decimal));
	tfirenet_courses.defineColumn("operator_user_id", typeof(int));
	tfirenet_courses.defineColumn("sbocchi_occupazionali", typeof(string));
	tfirenet_courses.defineColumn("sbocchi_occupazionali_en", typeof(string));
	tfirenet_courses.defineColumn("sperimentale", typeof(decimal));
	Tables.Add(tfirenet_courses);
	tfirenet_courses.defineKey("id");

	#endregion


	#region DataRelation creation
	var cPar = new []{annoaccademico.Columns["aa"]};
	var cChild = new []{firenet_courses.Columns["aa"]};
	Relations.Add(new DataRelation("FK_firenet_courses_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
