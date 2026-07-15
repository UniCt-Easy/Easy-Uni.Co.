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
[System.Xml.Serialization.XmlRoot("dsmeta_isidatacons_anagrafeammissioni_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_isidatacons_anagrafeammissioni_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isidatacons_anagrafeammissioni 		=> (MetaTable)Tables["isidatacons_anagrafeammissioni"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_isidatacons_anagrafeammissioni_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_isidatacons_anagrafeammissioni_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_isidatacons_anagrafeammissioni_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_isidatacons_anagrafeammissioni_default.xsd";

	#region create DataTables
	//////////////////// ISIDATACONS_ANAGRAFEAMMISSIONI /////////////////////////////////
	var tisidatacons_anagrafeammissioni= new MetaTable("isidatacons_anagrafeammissioni");
    tisidatacons_anagrafeammissioni.defineColumn("codicestudente", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("cognome", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("nome", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("corsolaurea", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("sesso", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("inseprep", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("provincia", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("datanasc", typeof(DateTime));
    tisidatacons_anagrafeammissioni.defineColumn("ncf", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("punti", typeof(float));
    tisidatacons_anagrafeammissioni.defineColumn("dataammiss", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("dataiscriz", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("annoammiss", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("numcommiss", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("note", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("iscritto", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("dip_sup", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("email", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("via", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("residenza", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("telefono", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("titstudio", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("locnasc", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("debiti", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("regione_di_nascita", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("regione_di_residenza", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("nazionalit", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("turandot", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("cell", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("codice_docente_preferito2", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("codice_docente_preferito3", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("livpreacc", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("iscuniv", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("nazita", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("certb", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("certb1", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("titstudnomeist", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("titstudindist", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("titstuddatadipl", typeof(DateTime));
    tisidatacons_anagrafeammissioni.defineColumn("voto_tit_stud", typeof(float));
    tisidatacons_anagrafeammissioni.defineColumn("iscunivnew", typeof(int));
    tisidatacons_anagrafeammissioni.defineColumn("turandot2", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("accda", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("accnatoa", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("accnatoil", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("accresin", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("risultato_esame", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("freqla", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("scuola", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("livellocertitaliano", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("livellocertsolfeggio", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("iseeimporto", typeof(float));
    tisidatacons_anagrafeammissioni.defineColumn("provpreacc", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("provlicei", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("provliceicorsi", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("cittadinanza", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("titstudnazione", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("dispense", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("osservazioni", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("noteesame", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("studimusprec", typeof(string));
    tisidatacons_anagrafeammissioni.defineColumn("altriesamiconseguiti", typeof(string));
    Tables.Add(tisidatacons_anagrafeammissioni);
	#endregion

}
}
}
