/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
using meta_flussoincassi;
using meta_flussoincassidetail;
using meta_flussocreditidetail;
using meta_flussocrediti;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace pagoPaService {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Incassi comunicatici dal nodo pagamenti o simili
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussoincassiTable flussoincassi 		=> (flussoincassiTable)Tables["flussoincassi"];

	///<summary>
	///dettaglio flusso incassi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussoincassidetailTable flussoincassidetail 		=> (flussoincassidetailTable)Tables["flussoincassidetail"];

	///<summary>
	///Dettaglio flusso crediti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditidetailTable flussocreditidetail 		=> (flussocreditidetailTable)Tables["flussocreditidetail"];

	///<summary>
	///Crediti da comunicare al nodo pagamenti o simili, anche usata per i crediti che ci vengono comunicati dalle segreterie studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public flussocreditiTable flussocrediti 		=> (flussocreditiTable)Tables["flussocrediti"];

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
	//////////////////// FLUSSOINCASSI /////////////////////////////////
	var tflussoincassi= new flussoincassiTable();
	tflussoincassi.addBaseColumns("idflusso","codiceflusso","trn","ct","cu","lt","lu","ayear","causale","dataincasso","nbill","importo","to_complete","elaborato","active","idsor01","idsor02","idsor03","idsor04","idsor05");
	Tables.Add(tflussoincassi);
	tflussoincassi.defineKey("idflusso");

	//////////////////// FLUSSOINCASSIDETAIL /////////////////////////////////
	var tflussoincassidetail= new flussoincassidetailTable();
	tflussoincassidetail.addBaseColumns("idflusso","iddetail","iduniqueformcode","iuv","importo","ct","cu","lt","lu","cf","p_iva");
	Tables.Add(tflussoincassidetail);
	tflussoincassidetail.defineKey("idflusso", "iddetail");

	//////////////////// FLUSSOCREDITIDETAIL /////////////////////////////////
	var tflussocreditidetail= new flussocreditidetailTable();
	tflussocreditidetail.addBaseColumns("idflusso","iddetail","cu","ct","lu","lt","importoversamento","idestimkind","yestim","nestim","rownum","idinvkind","yinv","ninv","invrownum","idfinmotive","iduniqueformcode","idaccmotiverevenue","idaccmotivecredit","idaccmotiveundotax","idaccmotiveundotaxpost","idupb","idreg","stop","competencystart","competencystop","description","nform","expirationdate","barcodevalue","barcodeimage","qrcodevalue","qrcodeimage","cf","iuv","annulment","flag","idunivoco","codiceavviso","idsor1","idsor2","idsor3","idivakind","tax","number","idlist","p_iva");
	Tables.Add(tflussocreditidetail);
	tflussocreditidetail.defineKey("idflusso", "iddetail");

	//////////////////// FLUSSOCREDITI /////////////////////////////////
	var tflussocrediti= new flussocreditiTable();
	tflussocrediti.addBaseColumns("idflusso","cu","ct","lu","lt","datacreazioneflusso","flusso","istransmitted","idsor01","idsor02","idsor03","idsor04","idsor05","filename","progday","docdate","idestimkind");
	Tables.Add(tflussocrediti);
	tflussocrediti.defineKey("idflusso");

	#endregion


	#region DataRelation creation
	this.defineRelation("flussoincassi_flussoincassidetail","flussoincassi","flussoincassidetail","idflusso");
	#endregion

}
}
}
