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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace expense_automatismiritenute {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensevarview 		=> Tables["expensevarview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable automatismitable 		=> Tables["automatismitable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finyearview 		=> Tables["finyearview"];

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
	//////////////////// INCOMEVIEW /////////////////////////////////
	var tincomeview= new DataTable("incomeview");
	tincomeview.Columns.Add( new DataColumn("idinc", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("nphase", typeof(byte)));
	tincomeview.Columns.Add( new DataColumn("phase", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("ymov", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("nmov", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("ayear", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("description", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("unpartitioned", typeof(decimal)));
	tincomeview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	tincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tincomeview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tincomeview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tincomeview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tincomeview);

	//////////////////// EXPENSEVARVIEW /////////////////////////////////
	var texpensevarview= new DataTable("expensevarview");
	texpensevarview.Columns.Add( new DataColumn("idexp", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpensevarview.Columns.Add( new DataColumn("nphase", typeof(byte)));
	texpensevarview.Columns.Add( new DataColumn("phase", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("ymov", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("nmov", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("yvar", typeof(short)));
	texpensevarview.Columns.Add( new DataColumn("nvar", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("description", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensevarview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpensevarview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpensevarview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	texpensevarview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpensevarview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(texpensevarview);

	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	texpenseview.Columns.Add( new DataColumn("idexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nphase", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("phase", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("ymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("nmov", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("ayear", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("description", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("extracode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(texpenseview);

	//////////////////// AUTOMATISMITABLE /////////////////////////////////
	var tautomatismitable= new DataTable("automatismitable");
	tautomatismitable.Columns.Add( new DataColumn("movkind", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("idreg", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("registry", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("idman", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("manager", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("idfin", typeof(int)));
	tautomatismitable.Columns.Add( new DataColumn("codefin", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("idupb", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("description", typeof(string)));
	tautomatismitable.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tautomatismitable.Columns.Add( new DataColumn("livsupid", typeof(int)));
	Tables.Add(tautomatismitable);

	//////////////////// EXPENSEPHASE /////////////////////////////////
	var texpensephase= new DataTable("expensephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensephase.Columns.Add(C);
	Tables.Add(texpensephase);
	texpensephase.PrimaryKey =  new DataColumn[]{texpensephase.Columns["nphase"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// INCOME /////////////////////////////////
	var tincome= new DataTable("income");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("doc", typeof(string)));
	tincome.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tincome.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tincome.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("idpayment", typeof(int)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("doc", typeof(string)));
	texpense.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	texpense.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idclawback", typeof(int)));
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


	//////////////////// FINYEARVIEW /////////////////////////////////
	var tfinyearview= new DataTable("finyearview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.ReadOnly=true;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tfinyearview);
	tfinyearview.PrimaryKey =  new DataColumn[]{tfinyearview.Columns["idfin"], tfinyearview.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finyearview.Columns["idfin"], finyearview.Columns["idupb"]};
	var cChild = new []{automatismitable.Columns["idfin"], automatismitable.Columns["idupb"]};
	Relations.Add(new DataRelation("finyearview_automatismitable",cPar,cChild,false));

	#endregion

}
}
}
