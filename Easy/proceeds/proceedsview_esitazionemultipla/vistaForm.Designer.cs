
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
namespace proceedsview_esitazionemultipla {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceedsview 		=> Tables["proceedsview"];

	///<summary>
	///Movimento bancario
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransaction 		=> Tables["banktransaction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	///<summary>
	///Importazione esiti e sospesi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bankimport 		=> Tables["bankimport"];

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
	//////////////////// PROCEEDSVIEW /////////////////////////////////
	var tproceedsview= new DataTable("proceedsview");
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	tproceedsview.Columns.Add( new DataColumn("npro_treasurer", typeof(int)));
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	tproceedsview.Columns.Add( new DataColumn("total", typeof(decimal)));
	C= new DataColumn("performed", typeof(decimal));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	tproceedsview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tproceedsview.Columns.Add( new DataColumn("kind", typeof(string)));
	tproceedsview.Columns.Add( new DataColumn("accountkind", typeof(string)));
	tproceedsview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tproceedsview.Columns.Add( new DataColumn("registry", typeof(string)));
	tproceedsview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tproceedsview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tproceedsview.Columns.Add( new DataColumn("finance", typeof(string)));
	tproceedsview.Columns.Add( new DataColumn("idman", typeof(int)));
	tproceedsview.Columns.Add( new DataColumn("manager", typeof(string)));
	tproceedsview.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	tproceedsview.Columns.Add( new DataColumn("yproceedstransmission", typeof(short)));
	tproceedsview.Columns.Add( new DataColumn("nproceedstransmission", typeof(int)));
	tproceedsview.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	tproceedsview.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tproceedsview.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	tproceedsview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedsview.Columns.Add(C);
	Tables.Add(tproceedsview);

	//////////////////// BANKTRANSACTION /////////////////////////////////
	var tbanktransaction= new DataTable("banktransaction");
	C= new DataColumn("yban", typeof(short));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("nban", typeof(int));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("kind", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("bankreference", typeof(string)));
	tbanktransaction.Columns.Add( new DataColumn("transactiondate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("valuedate", typeof(DateTime)));
	tbanktransaction.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbanktransaction.Columns.Add( new DataColumn("kpay", typeof(int)));
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbanktransaction.Columns.Add(C);
	tbanktransaction.Columns.Add( new DataColumn("idpay", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idpro", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idexp", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idinc", typeof(int)));
	tbanktransaction.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	Tables.Add(tbanktransaction);
	tbanktransaction.PrimaryKey =  new DataColumn[]{tbanktransaction.Columns["yban"], tbanktransaction.Columns["nban"], tbanktransaction.Columns["kpro"]};


	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	tincomeview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeview.Columns.Add(C);
	Tables.Add(tincomeview);

	//////////////////// BANKIMPORT /////////////////////////////////
	var tbankimport= new DataTable("bankimport");
	C= new DataColumn("idbankimport", typeof(int));
	C.AllowDBNull=false;
	tbankimport.Columns.Add(C);
	tbankimport.Columns.Add( new DataColumn("lastpayment", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastproceeds", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastbillincome", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lastbillexpense", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("totalpayment", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalproceeds", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillincome_plus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillincome_minus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillexpense_plus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("totalbillexpense_minus", typeof(decimal)));
	tbankimport.Columns.Add( new DataColumn("idbank", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("cu", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("lu", typeof(string)));
	tbankimport.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbankimport.Columns.Add( new DataColumn("ayear", typeof(short)));
	Tables.Add(tbankimport);
	tbankimport.PrimaryKey =  new DataColumn[]{tbankimport.Columns["idbankimport"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{incomeview.Columns["idinc"]};
	var cChild = new []{banktransaction.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeview_banktransaction",cPar,cChild,false));

	cPar = new []{bankimport.Columns["idbankimport"]};
	cChild = new []{banktransaction.Columns["idbankimport"]};
	Relations.Add(new DataRelation("bankimport_banktransaction",cPar,cChild,false));

	#endregion

}
}
}
