
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace bill_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill 		=> Tables["bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransactionview 		=> Tables["banktransactionview"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	///<summary>
	///Operazione su sospeso (bolletta)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable billtransaction 		=> Tables["billtransaction"];

	///<summary>
	///Operazione su Partita Pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bankimportbill 		=> Tables["bankimportbill"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// BILL /////////////////////////////////
	var tbill= new DataTable("bill");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("registry", typeof(string)));
	tbill.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbill.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbill.Columns.Add( new DataColumn("active", typeof(string)));
	tbill.Columns.Add( new DataColumn("motive", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	Tables.Add(tbill);
	tbill.PrimaryKey =  new DataColumn[]{tbill.Columns["ybill"], tbill.Columns["nbill"], tbill.Columns["billkind"]};


	//////////////////// BANKTRANSACTIONVIEW /////////////////////////////////
	var tbanktransactionview= new DataTable("banktransactionview");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("bankreference", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransactionview.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransactionview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransactionview.Columns.Add( new DataColumn("ypay", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npro", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("kpro", typeof(int)));
	C= new DataColumn("income", typeof(decimal));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("expense", typeof(decimal));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	tbanktransactionview.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("yexp", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("nexp", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("yinc", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("ninc", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransactionview.Columns.Add(C);
	Tables.Add(tbanktransactionview);

	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new DataTable("treasurer");
	ttreasurer.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("agencycodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cabcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("depcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("description", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_payment", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcab", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	C= new DataColumn("codetreasurer", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("spexportexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagmultiexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("fileextension", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("spexportinc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("iban", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("bic", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cccbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cincbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbankcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcabcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ibancbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("siacodecbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("reccbikind", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("trasmcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("motivelen", typeof(short)));
	ttreasurer.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagedisp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor05", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// BILLTRANSACTION /////////////////////////////////
	var tbilltransaction= new DataTable("billtransaction");
	C= new DataColumn("ybilltran", typeof(short));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	C= new DataColumn("nbilltran", typeof(int));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tbilltransaction.Columns.Add(C);
	tbilltransaction.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbilltransaction.Columns.Add( new DataColumn("kind", typeof(string)));
	tbilltransaction.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	tbilltransaction.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbilltransaction.Columns.Add( new DataColumn("cu", typeof(string)));
	tbilltransaction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbilltransaction.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tbilltransaction);
	tbilltransaction.PrimaryKey =  new DataColumn[]{tbilltransaction.Columns["ybilltran"], tbilltransaction.Columns["nbilltran"]};


	//////////////////// BANKIMPORTBILL /////////////////////////////////
	var tbankimportbill= new DataTable("bankimportbill");
	C= new DataColumn("idbankimport", typeof(int));
	C.AllowDBNull=false;
	tbankimportbill.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tbankimportbill.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbankimportbill.Columns.Add(C);
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbankimportbill.Columns.Add(C);
	tbankimportbill.Columns.Add( new DataColumn("nbill", typeof(int)));
	tbankimportbill.Columns.Add( new DataColumn("idbank", typeof(string)));
	C= new DataColumn("banknum", typeof(int));
	C.AllowDBNull=false;
	tbankimportbill.Columns.Add(C);
	tbankimportbill.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbankimportbill.Columns.Add( new DataColumn("motive", typeof(string)));
	tbankimportbill.Columns.Add( new DataColumn("registry", typeof(string)));
	tbankimportbill.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbankimportbill.Columns.Add( new DataColumn("notes", typeof(string)));
	tbankimportbill.Columns.Add( new DataColumn("bankcode", typeof(string)));
	tbankimportbill.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbankimportbill.Columns.Add( new DataColumn("cu", typeof(string)));
	tbankimportbill.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbankimportbill.Columns.Add( new DataColumn("lu", typeof(string)));
	tbankimportbill.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tbankimportbill);
	tbankimportbill.PrimaryKey =  new DataColumn[]{tbankimportbill.Columns["idbankimport"], tbankimportbill.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{bill.Columns["ybill"], bill.Columns["nbill"], bill.Columns["billkind"]};
	var cChild = new []{bankimportbill.Columns["ybill"], bankimportbill.Columns["nbill"], bankimportbill.Columns["billkind"]};
	Relations.Add(new DataRelation("bill_bankimportbill",cPar,cChild,false));

	cPar = new []{bill.Columns["ybill"], bill.Columns["nbill"], bill.Columns["billkind"]};
	cChild = new []{billtransaction.Columns["ybilltran"], billtransaction.Columns["nbill"], billtransaction.Columns["kind"]};
	Relations.Add(new DataRelation("bill_billtransaction",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{bill.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_treasurer_bill",cPar,cChild,false));

	#endregion

}
}
}
