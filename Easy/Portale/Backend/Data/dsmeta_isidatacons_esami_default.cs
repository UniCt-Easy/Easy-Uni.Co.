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
[System.Xml.Serialization.XmlRoot("dsmeta_isidatacons_esami_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_isidatacons_esami_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isidatacons_esami 		=> (MetaTable)Tables["isidatacons_esami"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_isidatacons_esami_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_isidatacons_esami_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_isidatacons_esami_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_isidatacons_esami_default.xsd";

	#region create DataTables
	//////////////////// ISIDATACONS_ESAMI /////////////////////////////////
	var tisidatacons_esami= new MetaTable("isidatacons_esami");
	tisidatacons_esami.defineColumn("aaesame", typeof(string));
	tisidatacons_esami.defineColumn("anno_di_conferma", typeof(string));
	tisidatacons_esami.defineColumn("anno_di_corso", typeof(int));
	tisidatacons_esami.defineColumn("anno_passaggio", typeof(string));
	tisidatacons_esami.defineColumn("anno_scolastico", typeof(string));
	tisidatacons_esami.defineColumn("anno_scolastico_di_conferma", typeof(string));
	tisidatacons_esami.defineColumn("anno_scolastico_passaggio", typeof(string));
	tisidatacons_esami.defineColumn("anticipo_sino", typeof(string));
	tisidatacons_esami.defineColumn("area", typeof(int));
	tisidatacons_esami.defineColumn("codice_insegnante", typeof(int));
	tisidatacons_esami.defineColumn("codicestudente", typeof(int));
	tisidatacons_esami.defineColumn("corso", typeof(string));
	tisidatacons_esami.defineColumn("corsoaggiuntivo", typeof(string));
	tisidatacons_esami.defineColumn("crediti", typeof(decimal));
	tisidatacons_esami.defineColumn("data_esame", typeof(DateTime));
	tisidatacons_esami.defineColumn("descrizioneprova1", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova10", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova2", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova3", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova4", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova5", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova6", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova7", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova8", typeof(string));
	tisidatacons_esami.defineColumn("descrizioneprova9", typeof(string));
	tisidatacons_esami.defineColumn("docente", typeof(string));
	tisidatacons_esami.defineColumn("durante_anno_principale", typeof(string));
	tisidatacons_esami.defineColumn("equipollenza", typeof(string));
	tisidatacons_esami.defineColumn("escluso_dalla_media", typeof(string));
	tisidatacons_esami.defineColumn("id", typeof(int),false);
	tisidatacons_esami.defineColumn("inesame", typeof(string));
	tisidatacons_esami.defineColumn("lingua", typeof(string));
	tisidatacons_esami.defineColumn("livello_conferma", typeof(string));
	tisidatacons_esami.defineColumn("livpreacc", typeof(string));
	tisidatacons_esami.defineColumn("media_votazione", typeof(decimal));
	tisidatacons_esami.defineColumn("noscheda", typeof(string));
	tisidatacons_esami.defineColumn("nostatistiche", typeof(string));
	tisidatacons_esami.defineColumn("noteesame", typeof(string));
	tisidatacons_esami.defineColumn("numero_commissione", typeof(int));
	tisidatacons_esami.defineColumn("oreeff", typeof(decimal));
	tisidatacons_esami.defineColumn("oreprev", typeof(decimal));
	tisidatacons_esami.defineColumn("prova_esame_1", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_10", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_2", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_3", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_4", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_5", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_6", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_7", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_8", typeof(string));
	tisidatacons_esami.defineColumn("prova_esame_9", typeof(string));
	tisidatacons_esami.defineColumn("rec_debiti", typeof(string));
	tisidatacons_esami.defineColumn("relatore", typeof(string));
	tisidatacons_esami.defineColumn("ripetente", typeof(string));
	tisidatacons_esami.defineColumn("risultato_esame", typeof(string));
	tisidatacons_esami.defineColumn("sessione", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_1", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_10", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_2", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_3", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_4", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_5", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_6", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_7", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_8", typeof(string));
	tisidatacons_esami.defineColumn("sessione_esame_9", typeof(string));
	tisidatacons_esami.defineColumn("sessione2", typeof(string));
	tisidatacons_esami.defineColumn("sospensioni_ecc", typeof(string));
	tisidatacons_esami.defineColumn("specifica_corso", typeof(string));
	tisidatacons_esami.defineColumn("tipo_compimento", typeof(string));
	tisidatacons_esami.defineColumn("titolo_tesi", typeof(string));
	tisidatacons_esami.defineColumn("titolotesiesecutiva", typeof(string));
	tisidatacons_esami.defineColumn("voto_conferma", typeof(string));
	tisidatacons_esami.defineColumn("voto_laurea", typeof(decimal));
	tisidatacons_esami.defineColumn("voto_passaggio", typeof(decimal));
	tisidatacons_esami.defineColumn("voto_promozione", typeof(string));
	Tables.Add(tisidatacons_esami);
	tisidatacons_esami.defineKey("id");

	#endregion

}
}
}
