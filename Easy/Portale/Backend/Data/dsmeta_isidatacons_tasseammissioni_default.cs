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
[System.Xml.Serialization.XmlRoot("dsmeta_isidatacons_tasseammissioni_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_isidatacons_tasseammissioni_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable isidatacons_tasseammissioni 		=> (MetaTable)Tables["isidatacons_tasseammissioni"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_isidatacons_tasseammissioni_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_isidatacons_tasseammissioni_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_isidatacons_tasseammissioni_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_isidatacons_tasseammissioni_default.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// ISIDATACONS_TASSEAMMISSIONI /////////////////////////////////
	var tisidatacons_tasseammissioni= new MetaTable("isidatacons_tasseammissioni");
	tisidatacons_tasseammissioni.defineColumn("codicestudente", typeof(int));
	tisidatacons_tasseammissioni.defineColumn("tipo", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("aa", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("data_versamento", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("numero_versamento", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("data_incasso", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("importo", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("foto_bollettino", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("ccp", typeof(int));
	tisidatacons_tasseammissioni.defineColumn("codice_mav", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("codice_bollettino", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("pagabile_dal", typeof(DateTime));
	tisidatacons_tasseammissioni.defineColumn("pagabile_al", typeof(DateTime));
	tisidatacons_tasseammissioni.defineColumn("max", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("perc", typeof(float));
	tisidatacons_tasseammissioni.defineColumn("isee_importo", typeof(float));
	tisidatacons_tasseammissioni.defineColumn("anno_solare", typeof(int));
	tisidatacons_tasseammissioni.defineColumn("data_flusso_pagopa", typeof(DateTime));
	tisidatacons_tasseammissioni.defineColumn("marca_da_bollo", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("data_generazione_iuv", typeof(DateTime));
	tisidatacons_tasseammissioni.defineColumn("eventuale_esonero", typeof(string));
	tisidatacons_tasseammissioni.defineColumn("note", typeof(string));
	Tables.Add(tisidatacons_tasseammissioni);

	#endregion


	#region DataRelation creation
	var cPar = new []{annoaccademico.Columns["aa"]};
	var cChild = new []{isidatacons_tasseammissioni.Columns["aa"]};
	Relations.Add(new DataRelation("FK_isidatacons_tasseammissioni_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
