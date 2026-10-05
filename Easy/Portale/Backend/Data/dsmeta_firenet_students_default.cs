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
[System.Xml.Serialization.XmlRoot("dsmeta_firenet_students_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_firenet_students_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable firenet_students 		=> (MetaTable)Tables["firenet_students"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_firenet_students_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_firenet_students_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_firenet_students_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_firenet_students_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// FIRENET_STUDENTS /////////////////////////////////
	var tfirenet_students= new MetaTable("firenet_students");
	tfirenet_students.defineColumn("aa", typeof(string));
	tfirenet_students.defineColumn("aafinale", typeof(string));
	tfirenet_students.defineColumn("anni_fuori_corso", typeof(string));
	tfirenet_students.defineColumn("anno_frequenza", typeof(string));
	tfirenet_students.defineColumn("anno_frequenza_parziale", typeof(string));
	tfirenet_students.defineColumn("annotazioni", typeof(string));
	tfirenet_students.defineColumn("attesa_diploma_primo_livello", typeof(string));
	tfirenet_students.defineColumn("autorizzazione_riprese", typeof(string));
	tfirenet_students.defineColumn("autorizzazione_trattamento", typeof(string));
	tfirenet_students.defineColumn("badge", typeof(string));
	tfirenet_students.defineColumn("competenze_musicali", typeof(string));
	tfirenet_students.defineColumn("consigliato", typeof(string));
	tfirenet_students.defineColumn("consigliatoparity", typeof(string));
	tfirenet_students.defineColumn("corsi_multipli", typeof(string));
	tfirenet_students.defineColumn("corso_attuale_conservatorio", typeof(string));
	tfirenet_students.defineColumn("corso_compatibile", typeof(string));
	tfirenet_students.defineColumn("corso_compatibile_dettagli", typeof(string));
	tfirenet_students.defineColumn("corso_scuola_secondaria", typeof(string));
	tfirenet_students.defineColumn("course_id", typeof(int));
	tfirenet_students.defineColumn("created", typeof(string));
	tfirenet_students.defineColumn("creditifinale", typeof(string));
	tfirenet_students.defineColumn("data_attesa_diploma_primo_livello", typeof(string));
	tfirenet_students.defineColumn("data_debito_armonia", typeof(string));
	tfirenet_students.defineColumn("data_debito_lettura_partitura", typeof(string));
	tfirenet_students.defineColumn("data_debito_lingua_italiana", typeof(string));
	tfirenet_students.defineColumn("data_debito_pianistica", typeof(string));
	tfirenet_students.defineColumn("data_debito_poesia_musica_drammaturgia_musicale", typeof(string));
	tfirenet_students.defineColumn("data_debito_ritmica", typeof(string));
	tfirenet_students.defineColumn("data_debito_storia_musica", typeof(string));
	tfirenet_students.defineColumn("datafinale", typeof(string));
	tfirenet_students.defineColumn("debito_armonia", typeof(string));
	tfirenet_students.defineColumn("debito_lettura_partitura", typeof(string));
	tfirenet_students.defineColumn("debito_lingua_italiana", typeof(string));
	tfirenet_students.defineColumn("debito_pianistica", typeof(string));
	tfirenet_students.defineColumn("debito_poesia_musica_drammaturgia_musicale", typeof(string));
	tfirenet_students.defineColumn("debito_ritmica", typeof(string));
	tfirenet_students.defineColumn("debito_storia_musica", typeof(string));
	tfirenet_students.defineColumn("dichiarazione_competenze_musicali", typeof(string));
	tfirenet_students.defineColumn("dichiarazione_sostitutiva", typeof(string));
	tfirenet_students.defineColumn("dichiarazione_valore", typeof(string));
	tfirenet_students.defineColumn("domanda_estera", typeof(string));
	tfirenet_students.defineColumn("edit_operator_user_id", typeof(int));
	tfirenet_students.defineColumn("enrollment_id", typeof(int));
	tfirenet_students.defineColumn("esecutivafinale", typeof(string));
	tfirenet_students.defineColumn("esonero_reddito", typeof(string));
	tfirenet_students.defineColumn("famiglia_convivente", typeof(string));
	tfirenet_students.defineColumn("final_teacher_id", typeof(int));
	tfirenet_students.defineColumn("fratelli_sorelle_iscritti", typeof(string));
	tfirenet_students.defineColumn("id", typeof(int),false);
	tfirenet_students.defineColumn("informazioni_aggiuntive", typeof(string));
	tfirenet_students.defineColumn("instrument_id", typeof(int));
	tfirenet_students.defineColumn("invalidita", typeof(string));
	tfirenet_students.defineColumn("isee", typeof(string));
	tfirenet_students.defineColumn("isidata", typeof(string));
	tfirenet_students.defineColumn("manifesto", typeof(string));
	tfirenet_students.defineColumn("matricola", typeof(string));
	tfirenet_students.defineColumn("modified", typeof(string));
	tfirenet_students.defineColumn("motivo_tempo_parziale", typeof(string));
	tfirenet_students.defineColumn("nessun_debito", typeof(string));
	tfirenet_students.defineColumn("no_altro_corso_accademico", typeof(string));
	tfirenet_students.defineColumn("no_altro_corso_universitario", typeof(string));
	tfirenet_students.defineColumn("noidoneita", typeof(string));
	tfirenet_students.defineColumn("non_rinnovato", typeof(string));
	tfirenet_students.defineColumn("note", typeof(string));
	tfirenet_students.defineColumn("note_private", typeof(string));
	tfirenet_students.defineColumn("notificato", typeof(string));
	tfirenet_students.defineColumn("operator_user_id", typeof(int));
	tfirenet_students.defineColumn("planstatus_id", typeof(int));
	tfirenet_students.defineColumn("primolivelloestero", typeof(string));
	tfirenet_students.defineColumn("provenienza_liceo_musicale", typeof(string));
	tfirenet_students.defineColumn("provenienza_preaccademico", typeof(string));
	tfirenet_students.defineColumn("puntifinale", typeof(string));
	tfirenet_students.defineColumn("richiesta_borsa_studio", typeof(string));
	tfirenet_students.defineColumn("sessionefinale", typeof(string));
	tfirenet_students.defineColumn("specialistica", typeof(string));
	tfirenet_students.defineColumn("studente_diplomando", typeof(string));
	tfirenet_students.defineColumn("studente_straniero", typeof(string));
	tfirenet_students.defineColumn("studentstatus_id", typeof(int));
	tfirenet_students.defineColumn("studio_spartito_teacher_id", typeof(int));
	tfirenet_students.defineColumn("teacher_id", typeof(int));
	tfirenet_students.defineColumn("titolo_studi2", typeof(string));
	tfirenet_students.defineColumn("titolo_studi3", typeof(string));
	tfirenet_students.defineColumn("titolodistudio", typeof(string));
	tfirenet_students.defineColumn("titolofinale", typeof(string));
	tfirenet_students.defineColumn("turandot", typeof(string));
	tfirenet_students.defineColumn("user_id", typeof(int));
	tfirenet_students.defineColumn("votofinale", typeof(string));
	Tables.Add(tfirenet_students);
	tfirenet_students.defineKey("id");

	#endregion


	#region DataRelation creation
	var cPar = new []{annoaccademico.Columns["aa"]};
	var cChild = new []{firenet_students.Columns["aa"]};
	Relations.Add(new DataRelation("FK_firenet_students_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
