
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
namespace pettycashoperation_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperation 		=> Tables["pettycashoperation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycash 		=> Tables["pettycash"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationsorted 		=> Tables["pettycashoperationsorted"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tipomovimento 		=> Tables["tipomovimento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationcasualcontract 		=> Tables["pettycashoperationcasualcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationinvoice 		=> Tables["pettycashoperationinvoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationitineration 		=> Tables["pettycashoperationitineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationprofservice 		=> Tables["pettycashoperationprofservice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_debit 		=> Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_cost 		=> Tables["accmotiveapplied_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable casualcontract 		=> Tables["casualcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoice 		=> Tables["invoice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itineration 		=> Tables["itineration"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable profservice 		=> Tables["profservice"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashsetup 		=> Tables["pettycashsetup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable clawbacksetup 		=> Tables["clawbacksetup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expense 		=> Tables["expense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashexpenseview 		=> Tables["pettycashexpenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashincomeview 		=> Tables["pettycashincomeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashoperationunderwriting 		=> Tables["pettycashoperationunderwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill 		=> Tables["bill"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable billview 		=> Tables["billview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siope 		=> Tables["sorting_siope"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartition 		=> Tables["costpartition"];

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
	//////////////////// PETTYCASHOPERATION /////////////////////////////////
	var tpettycashoperation= new DataTable("pettycashoperation");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("yrestore", typeof(short)));
	tpettycashoperation.Columns.Add( new DataColumn("nrestore", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("doc", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tpettycashoperation.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("txt", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperation.Columns.Add(C);
	tpettycashoperation.Columns.Add( new DataColumn("idexp", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("idman", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpettycashoperation.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpettycashoperation.Columns.Add( new DataColumn("nlist", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("nbill", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tpettycashoperation.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpettycashoperation);
	tpettycashoperation.PrimaryKey =  new DataColumn[]{tpettycashoperation.Columns["idpettycash"], tpettycashoperation.Columns["yoperation"], tpettycashoperation.Columns["noperation"]};


	//////////////////// PETTYCASH /////////////////////////////////
	var tpettycash= new DataTable("pettycash");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tpettycash);
	tpettycash.PrimaryKey =  new DataColumn[]{tpettycash.Columns["idpettycash"]};


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


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// SORTINGKIND /////////////////////////////////
	var tsortingkind= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind.Columns.Add(C);
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("!importo", typeof(decimal)));
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// PETTYCASHOPERATIONSORTED /////////////////////////////////
	var tpettycashoperationsorted= new DataTable("pettycashoperationsorted");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("idsubclass", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	tpettycashoperationsorted.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("description", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("tobecontinued", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuen1", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuen2", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuen3", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuen4", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuen5", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("values1", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("values2", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("values3", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("values4", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("values5", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuev1", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuev2", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuev3", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuev4", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("valuev5", typeof(decimal)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("txt", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationsorted.Columns.Add(C);
	tpettycashoperationsorted.Columns.Add( new DataColumn("!percentuale", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tpettycashoperationsorted.Columns.Add( new DataColumn("!idsorkind", typeof(int)));
	Tables.Add(tpettycashoperationsorted);
	tpettycashoperationsorted.PrimaryKey =  new DataColumn[]{tpettycashoperationsorted.Columns["idpettycash"], tpettycashoperationsorted.Columns["yoperation"], tpettycashoperationsorted.Columns["noperation"], tpettycashoperationsorted.Columns["idsor"], tpettycashoperationsorted.Columns["idsubclass"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// TIPOMOVIMENTO /////////////////////////////////
	var ttipomovimento= new DataTable("tipomovimento");
	C= new DataColumn("idtipo", typeof(int));
	C.AllowDBNull=false;
	ttipomovimento.Columns.Add(C);
	ttipomovimento.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttipomovimento);
	ttipomovimento.PrimaryKey =  new DataColumn[]{ttipomovimento.Columns["idtipo"]};


	//////////////////// PETTYCASHOPERATIONCASUALCONTRACT /////////////////////////////////
	var tpettycashoperationcasualcontract= new DataTable("pettycashoperationcasualcontract");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationcasualcontract.Columns.Add(C);
	Tables.Add(tpettycashoperationcasualcontract);
	tpettycashoperationcasualcontract.PrimaryKey =  new DataColumn[]{tpettycashoperationcasualcontract.Columns["idpettycash"], tpettycashoperationcasualcontract.Columns["yoperation"], tpettycashoperationcasualcontract.Columns["noperation"], tpettycashoperationcasualcontract.Columns["ycon"], tpettycashoperationcasualcontract.Columns["ncon"]};


	//////////////////// PETTYCASHOPERATIONINVOICE /////////////////////////////////
	var tpettycashoperationinvoice= new DataTable("pettycashoperationinvoice");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationinvoice.Columns.Add(C);
	Tables.Add(tpettycashoperationinvoice);
	tpettycashoperationinvoice.PrimaryKey =  new DataColumn[]{tpettycashoperationinvoice.Columns["idpettycash"], tpettycashoperationinvoice.Columns["yoperation"], tpettycashoperationinvoice.Columns["noperation"], tpettycashoperationinvoice.Columns["idinvkind"], tpettycashoperationinvoice.Columns["yinv"], tpettycashoperationinvoice.Columns["ninv"]};


	//////////////////// PETTYCASHOPERATIONITINERATION /////////////////////////////////
	var tpettycashoperationitineration= new DataTable("pettycashoperationitineration");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("movkind", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationitineration.Columns.Add(C);
	Tables.Add(tpettycashoperationitineration);
	tpettycashoperationitineration.PrimaryKey =  new DataColumn[]{tpettycashoperationitineration.Columns["iditineration"], tpettycashoperationitineration.Columns["idpettycash"], tpettycashoperationitineration.Columns["noperation"], tpettycashoperationitineration.Columns["yoperation"]};


	//////////////////// PETTYCASHOPERATIONPROFSERVICE /////////////////////////////////
	var tpettycashoperationprofservice= new DataTable("pettycashoperationprofservice");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationprofservice.Columns.Add(C);
	Tables.Add(tpettycashoperationprofservice);
	tpettycashoperationprofservice.PrimaryKey =  new DataColumn[]{tpettycashoperationprofservice.Columns["idpettycash"], tpettycashoperationprofservice.Columns["yoperation"], tpettycashoperationprofservice.Columns["noperation"], tpettycashoperationprofservice.Columns["ycon"], tpettycashoperationprofservice.Columns["ncon"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoicekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new DataTable("accmotiveapplied_debit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("in_use", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_debit.Columns.Add( new DataColumn("flagamm", typeof(string)));
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.PrimaryKey =  new DataColumn[]{taccmotiveapplied_debit.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_COST /////////////////////////////////
	var taccmotiveapplied_cost= new DataTable("accmotiveapplied_cost");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	taccmotiveapplied_cost.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	taccmotiveapplied_cost.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("epoperation", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("in_use", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.PrimaryKey =  new DataColumn[]{taccmotiveapplied_cost.Columns["idaccmotive"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// CASUALCONTRACT /////////////////////////////////
	var tcasualcontract= new DataTable("casualcontract");
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("completed", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcasualcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tcasualcontract.Columns.Add(C);
	tcasualcontract.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tcasualcontract.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tcasualcontract.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tcasualcontract);
	tcasualcontract.PrimaryKey =  new DataColumn[]{tcasualcontract.Columns["ycon"], tcasualcontract.Columns["ncon"]};


	//////////////////// INVOICE /////////////////////////////////
	var tinvoice= new DataTable("invoice");
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("doc", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	tinvoice.Columns.Add( new DataColumn("flagdeferred", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	tinvoice.Columns.Add(C);
	tinvoice.Columns.Add( new DataColumn("packinglistdate", typeof(DateTime)));
	tinvoice.Columns.Add( new DataColumn("packinglistnum", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tinvoice.Columns.Add( new DataColumn("registryreference", typeof(string)));
	tinvoice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tinvoice.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	Tables.Add(tinvoice);
	tinvoice.PrimaryKey =  new DataColumn[]{tinvoice.Columns["idinvkind"], tinvoice.Columns["yinv"], tinvoice.Columns["ninv"]};


	//////////////////// ITINERATION /////////////////////////////////
	var titineration= new DataTable("itineration");
	C= new DataColumn("nitineration", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("yitineration", typeof(short));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("admincarkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("admincarkmcost", typeof(decimal)));
	C= new DataColumn("authorizationdate", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("completed", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("footkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("footkmcost", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("grossfactor", typeof(double)));
	titineration.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("idsor1", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor2", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor3", typeof(int)));
	titineration.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("owncarkm", typeof(double)));
	titineration.Columns.Add( new DataColumn("owncarkmcost", typeof(decimal)));
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("totadvance", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("total", typeof(decimal)));
	titineration.Columns.Add( new DataColumn("totalgross", typeof(decimal)));
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titineration.Columns.Add(C);
	titineration.Columns.Add( new DataColumn("idsor01", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor02", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor03", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor04", typeof(int)));
	titineration.Columns.Add( new DataColumn("idsor05", typeof(int)));
	titineration.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	titineration.Columns.Add( new DataColumn("idsor_siope", typeof(short)));
	Tables.Add(titineration);
	titineration.PrimaryKey =  new DataColumn[]{titineration.Columns["iditineration"]};


	//////////////////// PROFSERVICE /////////////////////////////////
	var tprofservice= new DataTable("profservice");
	C= new DataColumn("ncon", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("description", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("doc", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("flaginvoiced", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idupb", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("ivafieldnumber", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("ivarate", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("ndays", typeof(int));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("ninv", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("pensioncontributionrate", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("socialsecurityrate", typeof(decimal)));
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tprofservice.Columns.Add(C);
	tprofservice.Columns.Add( new DataColumn("totalcost", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("yinv", typeof(short)));
	tprofservice.Columns.Add( new DataColumn("idivakind", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tprofservice.Columns.Add( new DataColumn("totalgross", typeof(decimal)));
	tprofservice.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tprofservice.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(tprofservice);
	tprofservice.PrimaryKey =  new DataColumn[]{tprofservice.Columns["ycon"], tprofservice.Columns["ncon"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


	//////////////////// PETTYCASHSETUP /////////////////////////////////
	var tpettycashsetup= new DataTable("pettycashsetup");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idfinincome", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("registrymanager", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("autoclassify", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("idacc", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("idsor_siopeexp", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idsor_siopeinc", typeof(int)));
	Tables.Add(tpettycashsetup);
	tpettycashsetup.PrimaryKey =  new DataColumn[]{tpettycashsetup.Columns["ayear"], tpettycashsetup.Columns["idpettycash"]};


	//////////////////// CLAWBACKSETUP /////////////////////////////////
	var tclawbacksetup= new DataTable("clawbacksetup");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tclawbacksetup.Columns.Add(C);
	C= new DataColumn("idclawback", typeof(int));
	C.AllowDBNull=false;
	tclawbacksetup.Columns.Add(C);
	tclawbacksetup.Columns.Add( new DataColumn("clawbackfinance", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tclawbacksetup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tclawbacksetup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tclawbacksetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tclawbacksetup.Columns.Add(C);
	tclawbacksetup.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tclawbacksetup.Columns.Add( new DataColumn("txt", typeof(string)));
	tclawbacksetup.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	Tables.Add(tclawbacksetup);
	tclawbacksetup.PrimaryKey =  new DataColumn[]{tclawbacksetup.Columns["ayear"], tclawbacksetup.Columns["idclawback"]};


	//////////////////// EXPENSE /////////////////////////////////
	var texpense= new DataTable("expense");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
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
	texpense.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	texpense.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("idclawback", typeof(int)));
	texpense.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpense.Columns.Add(C);
	texpense.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	texpense.Columns.Add( new DataColumn("idpayment", typeof(int)));
	texpense.Columns.Add( new DataColumn("idformerexpense", typeof(int)));
	texpense.Columns.Add( new DataColumn("autokind", typeof(byte)));
	texpense.Columns.Add( new DataColumn("autocode", typeof(int)));
	Tables.Add(texpense);
	texpense.PrimaryKey =  new DataColumn[]{texpense.Columns["idexp"]};


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
	texpenseview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(texpenseview);
	texpenseview.PrimaryKey =  new DataColumn[]{texpenseview.Columns["idexp"]};


	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("agencycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("appropriationphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("assessmentphasecode", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("asset_flagnumbering", typeof(string)));
	tconfig.Columns.Add( new DataColumn("asset_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("assetload_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("boxpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("casualcontract_flagrestart", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("currpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredexpensephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("deferredincomephase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronicimport", typeof(string)));
	tconfig.Columns.Add( new DataColumn("electronictrasmission", typeof(string)));
	tconfig.Columns.Add( new DataColumn("expense_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("expensephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flagautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagepexp", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("foreignhours", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_accruedrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_customer", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcost", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredcredit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferreddebit", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_deferredrevenue", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_patrimony", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_pl", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_supplier", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_admincar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_foot", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idaccmotive_owncar", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idclawback", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinexpensesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinincomesurplus", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("importappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("income_expiringdays", typeof(short)));
	tconfig.Columns.Add( new DataColumn("incomephase", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tconfig.Columns.Add(C);
	tconfig.Columns.Add( new DataColumn("minpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("motivelen", typeof(short)));
	tconfig.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	tconfig.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	tconfig.Columns.Add( new DataColumn("payment_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("payment_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("prevpartitiontitle", typeof(string)));
	tconfig.Columns.Add( new DataColumn("proceeds_finlevel", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flag", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("proceeds_flagautoprintdate", typeof(string)));
	tconfig.Columns.Add( new DataColumn("profservice_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("wageaddition_flagrestart", typeof(string)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// PETTYCASHEXPENSEVIEW /////////////////////////////////
	var tpettycashexpenseview= new DataTable("pettycashexpenseview");
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	tpettycashexpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tpettycashexpenseview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	tpettycashexpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
	tpettycashexpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	tpettycashexpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpettycashexpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tpettycashexpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tpettycashexpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	tpettycashexpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	tpettycashexpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	tpettycashexpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	tpettycashexpenseview.Columns.Add( new DataColumn("flag", typeof(byte)));
	tpettycashexpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tpettycashexpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tpettycashexpenseview.Columns.Add( new DataColumn("totflag", typeof(byte)));
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	tpettycashexpenseview.Columns.Add(C);
	tpettycashexpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashexpenseview.Columns.Add(C);
	tpettycashexpenseview.Columns.Add( new DataColumn("kpay", typeof(int)));
	Tables.Add(tpettycashexpenseview);
	tpettycashexpenseview.PrimaryKey =  new DataColumn[]{tpettycashexpenseview.Columns["yoperation"], tpettycashexpenseview.Columns["noperation"], tpettycashexpenseview.Columns["idpettycash"], tpettycashexpenseview.Columns["idexp"]};


	//////////////////// PETTYCASHINCOMEVIEW /////////////////////////////////
	var tpettycashincomeview= new DataTable("pettycashincomeview");
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	tpettycashincomeview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	tpettycashincomeview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tpettycashincomeview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	tpettycashincomeview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tpettycashincomeview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("finance", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("upb", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpettycashincomeview.Columns.Add( new DataColumn("registry", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("idman", typeof(int)));
	tpettycashincomeview.Columns.Add( new DataColumn("manager", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tpettycashincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
	tpettycashincomeview.Columns.Add( new DataColumn("doc", typeof(string)));
	tpettycashincomeview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	tpettycashincomeview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tpettycashincomeview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tpettycashincomeview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tpettycashincomeview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tpettycashincomeview.Columns.Add( new DataColumn("flag", typeof(byte)));
	tpettycashincomeview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	tpettycashincomeview.Columns.Add(C);
	tpettycashincomeview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashincomeview.Columns.Add(C);
	Tables.Add(tpettycashincomeview);
	tpettycashincomeview.PrimaryKey =  new DataColumn[]{tpettycashincomeview.Columns["yoperation"], tpettycashincomeview.Columns["noperation"], tpettycashincomeview.Columns["idpettycash"], tpettycashincomeview.Columns["idinc"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tfinview);
	tfinview.PrimaryKey =  new DataColumn[]{tfinview.Columns["idfin"], tfinview.Columns["idupb"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting01.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting02.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting03.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting04.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// PETTYCASHOPERATIONUNDERWRITING /////////////////////////////////
	var tpettycashoperationunderwriting= new DataTable("pettycashoperationunderwriting");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	C= new DataColumn("yoperation", typeof(short));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	C= new DataColumn("noperation", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	tpettycashoperationunderwriting.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashoperationunderwriting.Columns.Add(C);
	tpettycashoperationunderwriting.Columns.Add( new DataColumn("!underwriting", typeof(string)));
	tpettycashoperationunderwriting.Columns.Add( new DataColumn("!codeunderwriting", typeof(string)));
	Tables.Add(tpettycashoperationunderwriting);
	tpettycashoperationunderwriting.PrimaryKey =  new DataColumn[]{tpettycashoperationunderwriting.Columns["idpettycash"], tpettycashoperationunderwriting.Columns["yoperation"], tpettycashoperationunderwriting.Columns["noperation"], tpettycashoperationunderwriting.Columns["idunderwriting"]};


	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("active", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tunderwriting.Columns.Add( new DataColumn("codeunderwriting", typeof(string)));
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


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
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbill.Columns.Add(C);
	tbill.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbill.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbill.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	Tables.Add(tbill);
	tbill.PrimaryKey =  new DataColumn[]{tbill.Columns["ybill"], tbill.Columns["nbill"], tbill.Columns["billkind"]};


	//////////////////// BILLVIEW /////////////////////////////////
	var tbillview= new DataTable("billview");
	C= new DataColumn("ybill", typeof(short));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("nbill", typeof(int));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("billkind", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	tbillview.Columns.Add( new DataColumn("active", typeof(string)));
	tbillview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbillview.Columns.Add( new DataColumn("registry", typeof(string)));
	tbillview.Columns.Add( new DataColumn("motive", typeof(string)));
	tbillview.Columns.Add( new DataColumn("total", typeof(decimal)));
	tbillview.Columns.Add( new DataColumn("reduction", typeof(decimal)));
	C= new DataColumn("covered", typeof(decimal));
	C.ReadOnly=true;
	tbillview.Columns.Add(C);
	tbillview.Columns.Add( new DataColumn("toregularize", typeof(decimal)));
	tbillview.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbillview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbillview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	tbillview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbillview.Columns.Add(C);
	Tables.Add(tbillview);
	tbillview.PrimaryKey =  new DataColumn[]{tbillview.Columns["ybill"], tbillview.Columns["nbill"], tbillview.Columns["billkind"]};


	//////////////////// SORTING_SIOPE /////////////////////////////////
	var tsorting_siope= new DataTable("sorting_siope");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siope.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siope.Columns.Add(C);
	tsorting_siope.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siope.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siope.Columns.Add( new DataColumn("email", typeof(string)));
	tsorting_siope.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting_siope.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting_siope);
	tsorting_siope.PrimaryKey =  new DataColumn[]{tsorting_siope.Columns["idsor"]};


	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new DataTable("costpartition");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartition.Columns.Add(C);
	tcostpartition.Columns.Add( new DataColumn("title", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("kind", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tcostpartition);
	tcostpartition.PrimaryKey =  new DataColumn[]{tcostpartition.Columns["idcostpartition"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{underwriting.Columns["idunderwriting"]};
	var cChild = new []{pettycashoperationunderwriting.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("underwriting_pettycashoperationunderwriting",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashoperationunderwriting.Columns["idpettycash"], pettycashoperationunderwriting.Columns["yoperation"], pettycashoperationunderwriting.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperation_pettycashoperationunderwriting",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashincomeview.Columns["idpettycash"], pettycashincomeview.Columns["yoperation"], pettycashincomeview.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperation_pettycashincomeview",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashexpenseview.Columns["idpettycash"], pettycashexpenseview.Columns["yoperation"], pettycashexpenseview.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperation_pettycashexpenseview",cPar,cChild,false));

	cPar = new []{profservice.Columns["ycon"], profservice.Columns["ncon"]};
	cChild = new []{pettycashoperationprofservice.Columns["ycon"], pettycashoperationprofservice.Columns["ncon"]};
	Relations.Add(new DataRelation("profservicepettycashoperationprofservice",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashoperationprofservice.Columns["idpettycash"], pettycashoperationprofservice.Columns["yoperation"], pettycashoperationprofservice.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperationpettycashoperationprofservice",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashoperationitineration.Columns["idpettycash"], pettycashoperationitineration.Columns["yoperation"], pettycashoperationitineration.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperationpettycashoperationitineration",cPar,cChild,false));

	cPar = new []{itineration.Columns["iditineration"]};
	cChild = new []{pettycashoperationitineration.Columns["iditineration"]};
	Relations.Add(new DataRelation("itineration_pettycashoperationitineration",cPar,cChild,false));

	cPar = new []{invoice.Columns["idinvkind"], invoice.Columns["yinv"], invoice.Columns["ninv"]};
	cChild = new []{pettycashoperationinvoice.Columns["idinvkind"], pettycashoperationinvoice.Columns["yinv"], pettycashoperationinvoice.Columns["ninv"]};
	Relations.Add(new DataRelation("invoicepettycashoperationinvoice",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{pettycashoperationinvoice.Columns["idinvkind"]};
	Relations.Add(new DataRelation("invoicekindpettycashoperationinvoice",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashoperationinvoice.Columns["idpettycash"], pettycashoperationinvoice.Columns["yoperation"], pettycashoperationinvoice.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperationpettycashoperationinvoice",cPar,cChild,false));

	cPar = new []{casualcontract.Columns["ycon"], casualcontract.Columns["ncon"]};
	cChild = new []{pettycashoperationcasualcontract.Columns["ycon"], pettycashoperationcasualcontract.Columns["ncon"]};
	Relations.Add(new DataRelation("casualcontractpettycashoperationcasualcontract",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashoperationcasualcontract.Columns["idpettycash"], pettycashoperationcasualcontract.Columns["yoperation"], pettycashoperationcasualcontract.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperationpettycashoperationcasualcontract",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsorting",cPar,cChild,false));

	cPar = new []{pettycashoperation.Columns["idpettycash"], pettycashoperation.Columns["yoperation"], pettycashoperation.Columns["noperation"]};
	cChild = new []{pettycashoperationsorted.Columns["idpettycash"], pettycashoperationsorted.Columns["yoperation"], pettycashoperationsorted.Columns["noperation"]};
	Relations.Add(new DataRelation("pettycashoperationpettycashoperationsorted",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{pettycashoperationsorted.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_pettycashoperationsorted",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1pettycashoperation",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{pettycashoperation.Columns["idreg"]};
	Relations.Add(new DataRelation("registrypettycashoperation",cPar,cChild,false));

	cPar = new []{accmotiveapplied_cost.Columns["idaccmotive"]};
	cChild = new []{pettycashoperation.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("accmotiveapplied_costpettycashoperation",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{pettycashoperation.Columns["idaccmotive_debit"]};
	Relations.Add(new DataRelation("accmotiveapplied_debitpettycashoperation",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{pettycashoperation.Columns["idman"]};
	Relations.Add(new DataRelation("managerpettycashoperation",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{pettycashoperation.Columns["idupb"]};
	Relations.Add(new DataRelation("upbpettycashoperation",cPar,cChild,false));

	cPar = new []{pettycash.Columns["idpettycash"]};
	cChild = new []{pettycashoperation.Columns["idpettycash"]};
	Relations.Add(new DataRelation("pettycashpettycashoperation",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{pettycashoperation.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseviewpettycashoperation",cPar,cChild,false));

	cPar = new []{finview.Columns["idfin"], finview.Columns["idupb"]};
	cChild = new []{pettycashoperation.Columns["idfin"], pettycashoperation.Columns["idupb"]};
	Relations.Add(new DataRelation("finview_pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_pettycashoperation",cPar,cChild,false));

	cPar = new []{bill.Columns["nbill"]};
	cChild = new []{pettycashoperation.Columns["nbill"]};
	Relations.Add(new DataRelation("bill_pettycashoperation",cPar,cChild,false));

	cPar = new []{sorting_siope.Columns["idsor"]};
	cChild = new []{pettycashoperation.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("sorting_siope_pettycashoperation",cPar,cChild,false));

	cPar = new []{costpartition.Columns["idcostpartition"]};
	cChild = new []{pettycashoperation.Columns["idcostpartition"]};
	Relations.Add(new DataRelation("costpartition_pettycashoperation",cPar,cChild,false));

	#endregion

}
}
}
