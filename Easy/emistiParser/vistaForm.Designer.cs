
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
using meta_emisti_import;
using meta_emisti_rec_01;
using meta_emisti_rec_10;
using meta_emisti_rec_02;
using meta_emisti_rec_03;
using meta_emisti_rec_04;
using meta_emisti_rec_05;
using meta_emisti_rec_06;
using meta_emisti_rec_07;
using meta_emisti_rec_08;
using meta_emisti_rec_09;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace emistiParser {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_importTable emisti_import 		=> (emisti_importTable)Tables["emisti_import"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_01Table emisti_rec_01 		=> (emisti_rec_01Table)Tables["emisti_rec_01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_10Table emisti_rec_10 		=> (emisti_rec_10Table)Tables["emisti_rec_10"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_02Table emisti_rec_02 		=> (emisti_rec_02Table)Tables["emisti_rec_02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_03Table emisti_rec_03 		=> (emisti_rec_03Table)Tables["emisti_rec_03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_04Table emisti_rec_04 		=> (emisti_rec_04Table)Tables["emisti_rec_04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_05Table emisti_rec_05 		=> (emisti_rec_05Table)Tables["emisti_rec_05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_06Table emisti_rec_06 		=> (emisti_rec_06Table)Tables["emisti_rec_06"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_07Table emisti_rec_07 		=> (emisti_rec_07Table)Tables["emisti_rec_07"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_08Table emisti_rec_08 		=> (emisti_rec_08Table)Tables["emisti_rec_08"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public emisti_rec_09Table emisti_rec_09 		=> (emisti_rec_09Table)Tables["emisti_rec_09"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta.xsd";

	#region create DataTables
	//////////////////// EMISTI_IMPORT /////////////////////////////////
	var temisti_import= new emisti_importTable();
	temisti_import.addBaseColumns("idemisti_import","adate","ct","cu","description","lt","lu","nimport","yimport","refexternaldoc","idcsa_import");
	Tables.Add(temisti_import);
	temisti_import.defineKey("idemisti_import");

	//////////////////// EMISTI_REC_01 /////////////////////////////////
	var temisti_rec_01= new emisti_rec_01Table();
	temisti_rec_01.addBaseColumns("nrec","rata","dataemissione","dpt","codicefiscale","cognome1","nome1","modalpagamento","tiposervizio","iban","cin","abi","cab","contocorrente","ufficioservizio","capitolospesa","capitolobilancio","qualifica","livello","classe","scatti","imponibilerataannocorrente","irpefrataannocorrente","irpefarretratiannocorrente","irpefarretratiannoprecedente","irpeftotalenetta","importoannuolordo","importomensilelordo","importomensilenetto","importonetto13ma","importoprev13ma","importoirpef13ma","detrazionibase","detrazioniconiuge","detrazionifigli","detrazionialtrifam","totaledetrazioni","codiceregimecontributivo","codregioneirap","codicecomuneaccon","codicecomunesaldo","irpefaccessorieac","irpefaccessorieap","regimecontributivocud","creditoirpef","aliquotamedia","ct","cu","lt","lu","iscrizione","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_01);
	temisti_rec_01.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_10 /////////////////////////////////
	var temisti_rec_10= new emisti_rec_10Table();
	temisti_rec_10.addBaseColumns("nrec","rata","emissione","imponibileritenutaacconto","imponibileritenutaaccontoiva","importoritenutaacconto","impcontrintegrcat","impcontrintegrinps","importoiva","perccontrintegrcat","perccontrintegrinps","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_10);
	temisti_rec_10.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_02 /////////////////////////////////
	var temisti_rec_02= new emisti_rec_02Table();
	temisti_rec_02.addBaseColumns("nrec","rata","dataemissione","codiceassegno","sottocodiceassegno","importolordotabellare","importolordorata","importoriduzionept","importoriduzionete","importoritprev","datascadassegno","flagimponfiscale","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_02);
	temisti_rec_02.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_03 /////////////////////////////////
	var temisti_rec_03= new emisti_rec_03Table();
	temisti_rec_03.addBaseColumns("nrec","rata","dataemissione","codiceassegno","codritprevass","aliquotalavoratore","percentualeapplicazione","imponibile","importoritenuta","aliquotadatore","importodatore","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_03);
	temisti_rec_03.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_04 /////////////////////////////////
	var temisti_rec_04= new emisti_rec_04Table();
	temisti_rec_04.addBaseColumns("nrec","rata","dataemissione","codiceritenuta","tiporitenuta","importoritenuta","importoritnetto","codritoneremens","importooneremens","codrit1tantum","importorit1tantum","codcontratto","ct","cu","lt","lu","idemisti_import","progressivo_rec_01","flagriduzimpon","progressivodebito");
	Tables.Add(temisti_rec_04);
	temisti_rec_04.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_05 /////////////////////////////////
	var temisti_rec_05= new emisti_rec_05Table();
	temisti_rec_05.addBaseColumns("nrec","rata","dataemissione","codiceritenutacategoria","codiceassegno","importoritenuta","datascadritcat","tiporitcat","percapplritcat","percritcat","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_05);
	temisti_rec_05.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_06 /////////////////////////////////
	var temisti_rec_06= new emisti_rec_06Table();
	temisti_rec_06.addBaseColumns("nrec","rata","dataemissione","codiceassegno","codicearretrato","datalotto","numlotto","annoriferimento","importolordorata","importoriduzionept","importoriduzionete","importoritenute","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_06);
	temisti_rec_06.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_07 /////////////////////////////////
	var temisti_rec_07= new emisti_rec_07Table();
	temisti_rec_07.addBaseColumns("nrec","rata","dataemissione","codiceassegno","codicearretrato","datalotto","numlotto","annoriferimento","codritprevass","imponibile","importoritlavoratore","importoritdatore","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_07);
	temisti_rec_07.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_08 /////////////////////////////////
	var temisti_rec_08= new emisti_rec_08Table();
	temisti_rec_08.addBaseColumns("nrec","rata","dataemissione","idelenco","codente","capbilstato","numpg","tipotass","annoriferimento","compenso","sottocompenso","tipolcompenso","importo","inizio_comp","fine_comp","quantita","imp_unitario","importoritenute","ufficioresponsabilecomunicante","ufficioserviziocomunicante","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_08);
	temisti_rec_08.defineKey("nrec", "idemisti_import");

	//////////////////// EMISTI_REC_09 /////////////////////////////////
	var temisti_rec_09= new emisti_rec_09Table();
	temisti_rec_09.addBaseColumns("nrec","rata","dataemissione","idelenco","capbilstato","numpg","annoriferimento","compenso","sottocompenso","tipolcompenso","codritprevass","imponibile","importoritlavoratore","importoritdatore","ct","cu","lt","lu","idemisti_import","progressivo_rec_01");
	Tables.Add(temisti_rec_09);
	temisti_rec_09.defineKey("nrec", "idemisti_import");

	#endregion


	#region DataRelation creation
	this.defineRelation("emisti_import_emisti_rec_01","emisti_import","emisti_rec_01","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_02","emisti_import","emisti_rec_02","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_03","emisti_import","emisti_rec_03","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_04","emisti_import","emisti_rec_04","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_05","emisti_import","emisti_rec_05","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_06","emisti_import","emisti_rec_06","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_07","emisti_import","emisti_rec_07","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_08","emisti_import","emisti_rec_08","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_09","emisti_import","emisti_rec_09","idemisti_import");
	this.defineRelation("emisti_import_emisti_rec_10","emisti_import","emisti_rec_10","idemisti_import");
	#endregion

}
}
}
