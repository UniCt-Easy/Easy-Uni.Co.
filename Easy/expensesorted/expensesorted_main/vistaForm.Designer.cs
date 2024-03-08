
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace expensesorted_main {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione Movimenti di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensesorted 		=> Tables["expensesorted"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	///<summary>
	///Traduzione classificazioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingtranslation 		=> Tables["sortingtranslation"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensesortedview 		=> Tables["expensesortedview"];

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
	//////////////////// EXPENSESORTED /////////////////////////////////
	var texpensesorted= new DataTable("expensesorted");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("description", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("txt", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesorted.Columns.Add(C);
	texpensesorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	texpensesorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("values1", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values2", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values3", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values4", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("values5", typeof(string)));
	texpensesorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	texpensesorted.Columns.Add( new DataColumn("paridsor", typeof(int)));
	texpensesorted.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	texpensesorted.Columns.Add( new DataColumn("ayear", typeof(short)));
	Tables.Add(texpensesorted);
	texpensesorted.PrimaryKey =  new DataColumn[]{texpensesorted.Columns["idsor"], texpensesorted.Columns["idexp"], texpensesorted.Columns["idsubclass"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedn5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedn5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockeds5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forceds5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("allowedS5", typeof(string)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// SORTINGTRANSLATION /////////////////////////////////
	var tsortingtranslation= new DataTable("sortingtranslation");
	C= new DataColumn("idsortingmaster", typeof(int));
	C.AllowDBNull=false;
	tsortingtranslation.Columns.Add(C);
	C= new DataColumn("idsortingchild", typeof(int));
	C.AllowDBNull=false;
	tsortingtranslation.Columns.Add(C);
	tsortingtranslation.Columns.Add( new DataColumn("numerator", typeof(int)));
	tsortingtranslation.Columns.Add( new DataColumn("denominator", typeof(int)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultn1", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultn2", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultn3", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultn4", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultn5", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingtranslation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingtranslation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingtranslation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingtranslation.Columns.Add(C);
	tsortingtranslation.Columns.Add( new DataColumn("percentage", typeof(decimal)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultv1", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultv2", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultv3", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultv4", typeof(string)));
	tsortingtranslation.Columns.Add( new DataColumn("defaultv5", typeof(string)));
	Tables.Add(tsortingtranslation);
	tsortingtranslation.PrimaryKey =  new DataColumn[]{tsortingtranslation.Columns["idsortingmaster"], tsortingtranslation.Columns["idsortingchild"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// EXPENSEVIEW /////////////////////////////////
	var texpenseview= new DataTable("expenseview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	texpenseview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("ypay", typeof(short));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymentadate", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
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
	texpenseview.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("deputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	texpenseview.Columns.Add( new DataColumn("flag", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	texpenseview.Columns.Add( new DataColumn("autocode", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("clawback", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenseview.Columns.Add(C);
	Tables.Add(texpenseview);

	//////////////////// EXPENSESORTEDVIEW /////////////////////////////////
	var texpensesortedview= new DataTable("expensesortedview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(short));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("sorting", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	texpensesortedview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	texpensesortedview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	texpensesortedview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	texpensesortedview.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("values1", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("values2", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("values3", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("values4", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("values5", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	texpensesortedview.Columns.Add( new DataColumn("paridsorkind", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("parcodesorkind", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("paridsubclass", typeof(short)));
	texpensesortedview.Columns.Add( new DataColumn("idfin", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("codefin", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("finance", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("idupb", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("upb", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	texpensesortedview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	texpensesortedview.Columns.Add(C);
	texpensesortedview.Columns.Add( new DataColumn("registry", typeof(string)));
	texpensesortedview.Columns.Add( new DataColumn("npay", typeof(int)));
	C= new DataColumn("expensedescr", typeof(string));
	C.AllowDBNull=false;
	texpensesortedview.Columns.Add(C);
	texpensesortedview.Columns.Add( new DataColumn("npaymenttransmission", typeof(int)));
	texpensesortedview.Columns.Add( new DataColumn("ypaymenttransmission", typeof(short)));
	Tables.Add(texpensesortedview);
	texpensesortedview.PrimaryKey =  new DataColumn[]{texpensesortedview.Columns["idexp"], texpensesortedview.Columns["idsubclass"], texpensesortedview.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingkind.Columns["idsorkind"]};
	var cChild = new []{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkind_sorting",cPar,cChild,false));

	cPar = new []{sortingtranslation.Columns["idsortingmaster"], sortingtranslation.Columns["idsortingchild"]};
	cChild = new []{expensesorted.Columns["paridsor"], expensesorted.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingtranslationexpensesorted",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{expensesorted.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingexpensesorted",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{expensesorted.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_expensesorted",cPar,cChild,false));

	#endregion

}
}
}
