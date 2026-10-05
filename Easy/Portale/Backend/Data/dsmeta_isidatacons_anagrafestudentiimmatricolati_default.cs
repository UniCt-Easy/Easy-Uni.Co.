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
[System.Xml.Serialization.XmlRoot("dsmeta_isidatacons_anagrafestudentiimmatricolati_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_isidatacons_anagrafestudentiimmatricolati_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isidatacons_anagrafestudentiimmatricolati 		=> (MetaTable)Tables["isidatacons_anagrafestudentiimmatricolati"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_isidatacons_anagrafestudentiimmatricolati_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_isidatacons_anagrafestudentiimmatricolati_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_isidatacons_anagrafestudentiimmatricolati_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_isidatacons_anagrafestudentiimmatricolati_default.xsd";

	#region create DataTables
	//////////////////// ISIDATACONS_ANAGRAFESTUDENTIIMMATRICOLATI /////////////////////////////////
	var tisidatacons_anagrafestudentiimmatricolati= new MetaTable("isidatacons_anagrafestudentiimmatricolati");
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("codicestudente", typeof(int));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("cognome", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("nome", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("corsolaurea", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("sesso", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("localita_di_nascita", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("provincia_di_nascita", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("data_di_nascita", typeof(DateTime));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("residenza", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("provincia_di_residenza", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("via", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("cap", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("telefono", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("titolo_di_studio", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("punteggio_ammissione", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("data_di_ammissione", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("anno_scolastico", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("anno_di_scuola_media", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("dispense", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("osservazioni", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("postitstud", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("ncf", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("dip_sup", typeof(bool));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("email", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("cell", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("debiti", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("regione_di_nascita", typeof(int));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("regione_di_residenza", typeof(int));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("nazionalita", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("nonattivo", typeof(bool));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("annoammiss", typeof(int));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("turandot", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("livpreacc", typeof(int));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("iscuniv", typeof(bool));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("fascia_reddituale", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("nazita", typeof(bool));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("certb", typeof(bool));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("titstudnomeist", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("titstudindist", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("titstuddatadipl", typeof(DateTime));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("voto_tit_stud", typeof(decimal));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("iscunivnew", typeof(decimal));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("iban", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("intestatario", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("freqla", typeof(int));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("scuola", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("studimusprec", typeof(bool));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("altriesamiconseguiti", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("notaprivata", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("votobieprecpertfa", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("numrichinpsisee", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("livellocertitaliano", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("livellocertsolfeggio", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("diversabilitaperc", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("iseeimporto", typeof(float));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("cittadinanza", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("emailist", typeof(string));
    tisidatacons_anagrafestudentiimmatricolati.defineColumn("titstudnazione", typeof(string));
    Tables.Add(tisidatacons_anagrafestudentiimmatricolati);

	#endregion

}
}
}
