/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace sorting_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Livello Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortinglevel 		=> Tables["sortinglevel"];

	///<summary>
	///previsione sulla classificazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingprev 		=> Tables["sortingprev"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind 		=> Tables["sortingkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accountprevisionview 		=> Tables["accountprevisionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingyearview 		=> Tables["sortingyearview"];

	///<summary>
	///Classificazione responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable managersorting 		=> Tables["managersorting"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable budgetprevisionview 		=> Tables["budgetprevisionview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable budgetvardetailview 		=> Tables["budgetvardetailview"];

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
	public DataTable sortingall 		=> Tables["sortingall"];

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
	//////////////////// SORTINGLEVEL /////////////////////////////////
	var tsortinglevel= new DataTable("sortinglevel");
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("flag", typeof(short));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	Tables.Add(tsortinglevel);
	tsortinglevel.PrimaryKey =  new DataColumn[]{tsortinglevel.Columns["nlevel"], tsortinglevel.Columns["idsorkind"]};


	//////////////////// SORTINGPREV /////////////////////////////////
	var tsortingprev= new DataTable("sortingprev");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingprev.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingprev.Columns.Add(C);
	tsortingprev.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingprev.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingprev.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingprev.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingprev.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingprev.Columns.Add(C);
	Tables.Add(tsortingprev);
	tsortingprev.PrimaryKey =  new DataColumn[]{tsortingprev.Columns["idsor"], tsortingprev.Columns["ayear"]};


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
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting.Columns.Add( new DataColumn("email", typeof(string)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


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
	tsortingkind.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
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
	Tables.Add(tsortingkind);
	tsortingkind.PrimaryKey =  new DataColumn[]{tsortingkind.Columns["idsorkind"]};


	//////////////////// ACCOUNTPREVISIONVIEW /////////////////////////////////
	var taccountprevisionview= new DataTable("accountprevisionview");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccountprevisionview.Columns.Add(C);
	taccountprevisionview.Columns.Add( new DataColumn("paridacc", typeof(string)));
	Tables.Add(taccountprevisionview);
	taccountprevisionview.PrimaryKey =  new DataColumn[]{taccountprevisionview.Columns["idsorkind"], taccountprevisionview.Columns["idsor"], taccountprevisionview.Columns["idacc"]};


	//////////////////// SORTINGYEARVIEW /////////////////////////////////
	var tsortingyearview= new DataTable("sortingyearview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	tsortingyearview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	tsortingyearview.Columns.Add( new DataColumn("printingorder", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	tsortingyearview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("totexpensevariation", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("totincomevariation", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("totexpense", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("totincome", typeof(decimal)));
	C= new DataColumn("currentincomeprevision", typeof(decimal));
	C.ReadOnly=true;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("currentexpenseprevision", typeof(decimal));
	C.ReadOnly=true;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("availableincomeprevision", typeof(decimal));
	C.ReadOnly=true;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("availableexpenseprevision", typeof(decimal));
	C.ReadOnly=true;
	tsortingyearview.Columns.Add(C);
	tsortingyearview.Columns.Add( new DataColumn("idman", typeof(int)));
	tsortingyearview.Columns.Add( new DataColumn("manager", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingyearview.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingyearview.Columns.Add(C);
	tsortingyearview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingyearview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingyearview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingyearview);

	//////////////////// MANAGERSORTING /////////////////////////////////
	var tmanagersorting= new DataTable("managersorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagersorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanagersorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanagersorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanagersorting.Columns.Add(C);
	tmanagersorting.Columns.Add( new DataColumn("quota", typeof(double)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanagersorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tmanagersorting.Columns.Add(C);
	Tables.Add(tmanagersorting);
	tmanagersorting.PrimaryKey =  new DataColumn[]{tmanagersorting.Columns["idman"], tmanagersorting.Columns["idsor"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// BUDGETPREVISIONVIEW /////////////////////////////////
	var tbudgetprevisionview= new DataTable("budgetprevisionview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tbudgetprevisionview.Columns.Add(C);
	tbudgetprevisionview.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tbudgetprevisionview.Columns.Add( new DataColumn("codesorkind", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("sortingkind", typeof(string)));
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tbudgetprevisionview.Columns.Add(C);
	tbudgetprevisionview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("sorting", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tbudgetprevisionview.Columns.Add(C);
	tbudgetprevisionview.Columns.Add( new DataColumn("leveldescr", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbudgetprevisionview.Columns.Add(C);
	tbudgetprevisionview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("upb", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tbudgetprevisionview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tbudgetprevisionview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tbudgetprevisionview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tbudgetprevisionview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tbudgetprevisionview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tbudgetprevisionview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tbudgetprevisionview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tbudgetprevisionview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tbudgetprevisionview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tbudgetprevisionview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tbudgetprevisionview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbudgetprevisionview.Columns.Add( new DataColumn("cu", typeof(string)));
	tbudgetprevisionview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbudgetprevisionview.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tbudgetprevisionview);
	tbudgetprevisionview.PrimaryKey =  new DataColumn[]{tbudgetprevisionview.Columns["ayear"], tbudgetprevisionview.Columns["idsor"], tbudgetprevisionview.Columns["idupb"]};


	//////////////////// BUDGETVARDETAILVIEW /////////////////////////////////
	var tbudgetvardetailview= new DataTable("budgetvardetailview");
	C= new DataColumn("ybudgetvar", typeof(int));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("nbudgetvar", typeof(int));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	tbudgetvardetailview.Columns.Add( new DataColumn("variationdescription", typeof(string)));
	tbudgetvardetailview.Columns.Add( new DataColumn("official", typeof(string)));
	tbudgetvardetailview.Columns.Add( new DataColumn("nofficial", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("idman", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("manager", typeof(string)));
	tbudgetvardetailview.Columns.Add( new DataColumn("idbudgetvarstatus", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("budgetvarstatus", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	tbudgetvardetailview.Columns.Add( new DataColumn("idsor", typeof(int)));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("sorting", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	tbudgetvardetailview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tbudgetvardetailview.Columns.Add(C);
	tbudgetvardetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tbudgetvardetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tbudgetvardetailview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tbudgetvardetailview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tbudgetvardetailview.Columns.Add( new DataColumn("cu", typeof(string)));
	tbudgetvardetailview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tbudgetvardetailview.Columns.Add( new DataColumn("lu", typeof(string)));
	tbudgetvardetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tbudgetvardetailview.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	C= new DataColumn("activity", typeof(string));
	C.ReadOnly=true;
	tbudgetvardetailview.Columns.Add(C);
	tbudgetvardetailview.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	C= new DataColumn("kindd", typeof(string));
	C.ReadOnly=true;
	tbudgetvardetailview.Columns.Add(C);
	C= new DataColumn("kindr", typeof(string));
	C.ReadOnly=true;
	tbudgetvardetailview.Columns.Add(C);
	Tables.Add(tbudgetvardetailview);
	tbudgetvardetailview.PrimaryKey =  new DataColumn[]{tbudgetvardetailview.Columns["ybudgetvar"], tbudgetvardetailview.Columns["nbudgetvar"], tbudgetvardetailview.Columns["rownum"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
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
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
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
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
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
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
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
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
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
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
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
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting05.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// SORTINGALL /////////////////////////////////
	var tsortingall= new DataTable("sortingall");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingall.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingall.Columns.Add( new DataColumn("email", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsortingall);
	tsortingall.PrimaryKey =  new DataColumn[]{tsortingall.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{budgetvardetailview.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_budgetvardetailview",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{budgetprevisionview.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_budgetprevisionview",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{managersorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_managersorting",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{managersorting.Columns["idman"]};
	Relations.Add(new DataRelation("manager_managersorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingyearview.Columns["idsor"]};
	Relations.Add(new DataRelation("sorting_sortingyearview",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sorting.Columns["paridsor"]};
	Relations.Add(new DataRelation("sortingsorting",cPar,cChild,false));

	cPar = new []{sortinglevel.Columns["nlevel"], sortinglevel.Columns["idsorkind"]};
	cChild = new []{sorting.Columns["nlevel"], sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortinglevelsorting",cPar,cChild,false));

	cPar = new []{sortingkind.Columns["idsorkind"]};
	cChild = new []{sorting.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindsorting",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{sortingprev.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingsortingprev",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{sorting.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_sorting",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{sorting.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_sorting",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{sorting.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_sorting",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{sorting.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_sorting",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{sorting.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_sorting",cPar,cChild,false));

	#endregion

}
}
}
