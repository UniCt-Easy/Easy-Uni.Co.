
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using meta_estimatedetail;
using meta_estimate;
using meta_estimatekind;
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace incomelastestimatedetail_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable incomelastestimatedetail 		=> (MetaTable)Tables["incomelastestimatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatedetailTable estimatedetail 		=> (estimatedetailTable)Tables["estimatedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimateTable estimate 		=> (estimateTable)Tables["estimate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public estimatekindTable estimatekind 		=> (estimatekindTable)Tables["estimatekind"];

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
	//////////////////// INCOMELASTESTIMATEDETAIL /////////////////////////////////
	var tincomelastestimatedetail= new MetaTable("incomelastestimatedetail");
	tincomelastestimatedetail.defineColumn("idinc", typeof(int),false);
	tincomelastestimatedetail.defineColumn("idestimkind", typeof(string),false);
	tincomelastestimatedetail.defineColumn("yestim", typeof(short),false);
	tincomelastestimatedetail.defineColumn("nestim", typeof(int),false);
	tincomelastestimatedetail.defineColumn("rownum", typeof(int),false);
	tincomelastestimatedetail.defineColumn("amount", typeof(decimal),false);
	tincomelastestimatedetail.defineColumn("ct", typeof(DateTime),false);
	tincomelastestimatedetail.defineColumn("cu", typeof(string),false);
	tincomelastestimatedetail.defineColumn("lt", typeof(DateTime),false);
	tincomelastestimatedetail.defineColumn("lu", typeof(string),false);
	tincomelastestimatedetail.defineColumn("originalamount", typeof(decimal));
	Tables.Add(tincomelastestimatedetail);
	tincomelastestimatedetail.defineKey("idinc", "idestimkind", "yestim", "nestim", "rownum");

	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new estimatedetailTable();
	testimatedetail.addBaseColumns("idestimkind","yestim","nestim","rownum","annotations","ct","cu","detaildescription","discount","idupb","lt","lu","ninvoiced","number","start","stop","tax","taxable","taxrate","toinvoice","idaccmotive","idreg","idgroup","competencystart","competencystop","idinc_taxable","idinc_iva","idivakind","idsor1","idsor2","idsor3","idaccmotiveannulment","epkind","idrevenuepartition","idepacc","idupb_iva","idlist","cigcode","idfinmotive","iduniqueformcode","flag","proceedsexpiring","nform","idsor_siope","idepacc_pre","rownum_main");
	Tables.Add(testimatedetail);
	testimatedetail.defineKey("idestimkind", "yestim", "nestim", "rownum");

	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new estimateTable();
	testimate.addBaseColumns("idestimkind","yestim","nestim","active","adate","ct","cu","deliveryaddress","deliveryexpiration","description","doc","docdate","exchangerate","idreg","lt","lu","officiallyprinted","paymentexpiring","registryreference","rtf","txt","idman","idcurrency","idexpirationkind","flagintracom","idaccmotivecredit","idaccmotivecredit_crg","idaccmotivecredit_datacrg","idsor_underwriter","idunderwriting","idsor01","idsor02","idsor03","idsor04","idsor05","external_reference","cigcode");
	Tables.Add(testimate);
	testimate.defineKey("idestimkind", "yestim", "nestim");

	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new estimatekindTable();
	testimatekind.addBaseColumns("idestimkind","active","ct","cu","description","idupb","lt","lu","rtf","txt","email","faxnumber","office","phonenumber","linktoinvoice","multireg","deltaamount","deltapercentage","flag_autodocnumbering","idsor01","idsor02","idsor03","idsor04","idsor05","address","header","idivakind_forced","flag");
	Tables.Add(testimatekind);
	testimatekind.defineKey("idestimkind");

	#endregion


	#region DataRelation creation
	this.defineRelation("estimatedetail_incomelastestimatedetail","estimatedetail","incomelastestimatedetail","idestimkind","yestim","nestim","rownum");
	this.defineRelation("estimate_incomelastestimatedetail","estimate","incomelastestimatedetail","idestimkind","yestim","nestim");
	this.defineRelation("estimatekind_incomelastestimatedetail","estimatekind","incomelastestimatedetail","idestimkind");
	#endregion

}
}
}
