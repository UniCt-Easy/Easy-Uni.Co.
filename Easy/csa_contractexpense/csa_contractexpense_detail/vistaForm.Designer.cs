
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace csa_contractexpense_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractexpense 		=> (MetaTable)Tables["csa_contractexpense"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expensephase 		=> (MetaTable)Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable expenseview 		=> (MetaTable)Tables["expenseview"];

	///<summary>
	///Regola generale CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractkind 		=> (MetaTable)Tables["csa_contractkind"];

	///<summary>
	///Informazioni annuali su Regola generale CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable csa_contractkindyear 		=> (MetaTable)Tables["csa_contractkindyear"];

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
	EnforceConstraints = false;

	#region create DataTables
	//////////////////// CSA_CONTRACTEXPENSE /////////////////////////////////
	var tcsa_contractexpense= new MetaTable("csa_contractexpense");
	tcsa_contractexpense.defineColumn("idcsa_contract", typeof(int),false);
	tcsa_contractexpense.defineColumn("ayear", typeof(short),false);
	tcsa_contractexpense.defineColumn("ndetail", typeof(int),false);
	tcsa_contractexpense.defineColumn("quota", typeof(decimal));
	tcsa_contractexpense.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractexpense.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractexpense.defineColumn("cu", typeof(string),false);
	tcsa_contractexpense.defineColumn("lu", typeof(string),false);
	tcsa_contractexpense.defineColumn("idexp", typeof(int));
	Tables.Add(tcsa_contractexpense);
	tcsa_contractexpense.defineKey("idcsa_contract", "ayear", "ndetail");

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new MetaTable("expensephase");
	texpensephase.defineColumn("ct", typeof(DateTime),false);
	texpensephase.defineColumn("cu", typeof(string),false);
	texpensephase.defineColumn("description", typeof(string),false);
	texpensephase.defineColumn("lt", typeof(DateTime),false);
	texpensephase.defineColumn("lu", typeof(string),false);
	texpensephase.defineColumn("nphase", typeof(byte),false);
	Tables.Add(texpensephase);
	texpensephase.defineKey("nphase");

	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new MetaTable("expenseview");
	texpenseview.defineColumn("idexp", typeof(int),false);
	texpenseview.defineColumn("nphase", typeof(byte),false);
	texpenseview.defineColumn("phase", typeof(string),false);
	texpenseview.defineColumn("ymov", typeof(short),false);
	texpenseview.defineColumn("nmov", typeof(int),false);
	texpenseview.defineColumn("parentidexp", typeof(int));
	texpenseview.defineColumn("parentymov", typeof(short));
	texpenseview.defineColumn("parentnmov", typeof(int));
	texpenseview.defineColumn("idformerexpense", typeof(int));
	texpenseview.defineColumn("formerymov", typeof(short));
	texpenseview.defineColumn("formernmov", typeof(int));
	texpenseview.defineColumn("ayear", typeof(short),false);
	texpenseview.defineColumn("idfin", typeof(int));
	texpenseview.defineColumn("codefin", typeof(string));
	texpenseview.defineColumn("finance", typeof(string));
	texpenseview.defineColumn("idupb", typeof(string));
	texpenseview.defineColumn("codeupb", typeof(string));
	texpenseview.defineColumn("upb", typeof(string));
	texpenseview.defineColumn("idsor01", typeof(int));
	texpenseview.defineColumn("idsor02", typeof(int));
	texpenseview.defineColumn("idsor03", typeof(int));
	texpenseview.defineColumn("idsor04", typeof(int));
	texpenseview.defineColumn("idsor05", typeof(int));
	texpenseview.defineColumn("idreg", typeof(int));
	texpenseview.defineColumn("registry", typeof(string));
	texpenseview.defineColumn("cf", typeof(string));
	texpenseview.defineColumn("p_iva", typeof(string));
	texpenseview.defineColumn("idman", typeof(int));
	texpenseview.defineColumn("manager", typeof(string));
	texpenseview.defineColumn("kpay", typeof(int));
	texpenseview.defineColumn("ypay", typeof(short));
	texpenseview.defineColumn("npay", typeof(int));
	texpenseview.defineColumn("paymentadate", typeof(DateTime));
	texpenseview.defineColumn("doc", typeof(string));
	texpenseview.defineColumn("docdate", typeof(DateTime));
	texpenseview.defineColumn("description", typeof(string),false);
	texpenseview.defineColumn("amount", typeof(decimal));
	texpenseview.defineColumn("ayearstartamount", typeof(decimal));
	texpenseview.defineColumn("curramount", typeof(decimal));
	texpenseview.defineColumn("available", typeof(decimal));
	texpenseview.defineColumn("idregistrypaymethod", typeof(int));
	texpenseview.defineColumn("idpaymethod", typeof(int));
	texpenseview.defineColumn("iban", typeof(string));
	texpenseview.defineColumn("cin", typeof(string));
	texpenseview.defineColumn("idbank", typeof(string));
	texpenseview.defineColumn("idcab", typeof(string));
	texpenseview.defineColumn("cc", typeof(string));
	texpenseview.defineColumn("iddeputy", typeof(int));
	texpenseview.defineColumn("deputy", typeof(string));
	texpenseview.defineColumn("refexternaldoc", typeof(string));
	texpenseview.defineColumn("paymentdescr", typeof(string));
	texpenseview.defineColumn("idser", typeof(int));
	texpenseview.defineColumn("service", typeof(string));
	texpenseview.defineColumn("codeser", typeof(string));
	texpenseview.defineColumn("servicestart", typeof(DateTime));
	texpenseview.defineColumn("servicestop", typeof(DateTime));
	texpenseview.defineColumn("ivaamount", typeof(decimal));
	texpenseview.defineColumn("flag", typeof(byte));
	texpenseview.defineColumn("totflag", typeof(byte));
	texpenseview.defineColumn("flagarrear", typeof(string),true,true);
	texpenseview.defineColumn("autokind", typeof(byte));
	texpenseview.defineColumn("idpayment", typeof(int));
	texpenseview.defineColumn("expiration", typeof(DateTime));
	texpenseview.defineColumn("adate", typeof(DateTime),false);
	texpenseview.defineColumn("autocode", typeof(int));
	texpenseview.defineColumn("idclawback", typeof(int));
	texpenseview.defineColumn("clawback", typeof(string));
	texpenseview.defineColumn("clawbackref", typeof(string));
	texpenseview.defineColumn("nbill", typeof(int));
	texpenseview.defineColumn("idpay", typeof(int));
	texpenseview.defineColumn("npaymenttransmission", typeof(int));
	texpenseview.defineColumn("transmissiondate", typeof(DateTime));
	texpenseview.defineColumn("idaccdebit", typeof(string));
	texpenseview.defineColumn("codeaccdebit", typeof(string));
	texpenseview.defineColumn("cigcode", typeof(string));
	texpenseview.defineColumn("cupcode", typeof(string));
	texpenseview.defineColumn("txt", typeof(string));
	texpenseview.defineColumn("cu", typeof(string),false);
	texpenseview.defineColumn("ct", typeof(DateTime),false);
	texpenseview.defineColumn("lu", typeof(string),false);
	texpenseview.defineColumn("lt", typeof(DateTime),false);
	Tables.Add(texpenseview);

	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	var tcsa_contractkind= new MetaTable("csa_contractkind");
	tcsa_contractkind.defineColumn("idcsa_contractkind", typeof(int),false);
	tcsa_contractkind.defineColumn("contractkindcode", typeof(string),false);
	tcsa_contractkind.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractkind.defineColumn("cu", typeof(string),false);
	tcsa_contractkind.defineColumn("description", typeof(string),false);
	tcsa_contractkind.defineColumn("flagcr", typeof(string),false);
	tcsa_contractkind.defineColumn("flagkeepalive", typeof(string));
	tcsa_contractkind.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractkind.defineColumn("lu", typeof(string),false);
	tcsa_contractkind.defineColumn("active", typeof(string));
	tcsa_contractkind.defineColumn("idunderwriting", typeof(int));
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.defineKey("idcsa_contractkind");

	//////////////////// CSA_CONTRACTKINDYEAR /////////////////////////////////
	var tcsa_contractkindyear= new MetaTable("csa_contractkindyear");
	tcsa_contractkindyear.defineColumn("idcsa_contractkind", typeof(int),false);
	tcsa_contractkindyear.defineColumn("ayear", typeof(short),false);
	tcsa_contractkindyear.defineColumn("idupb", typeof(string));
	tcsa_contractkindyear.defineColumn("idacc_main", typeof(string));
	tcsa_contractkindyear.defineColumn("idfin_main", typeof(int));
	tcsa_contractkindyear.defineColumn("ct", typeof(DateTime),false);
	tcsa_contractkindyear.defineColumn("cu", typeof(string),false);
	tcsa_contractkindyear.defineColumn("lt", typeof(DateTime),false);
	tcsa_contractkindyear.defineColumn("lu", typeof(string),false);
	tcsa_contractkindyear.defineColumn("idsor_siope_main", typeof(int));
	Tables.Add(tcsa_contractkindyear);
	tcsa_contractkindyear.defineKey("idcsa_contractkind", "ayear");

	#endregion


	#region DataRelation creation
	var cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	var cChild = new []{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("FK_csa_contractkindyear_csa_contractkind",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{csa_contractexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("FK_expenseview_csa_contractexpense",cPar,cChild,false));

	#endregion

}
}
}
