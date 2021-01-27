
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
namespace proceedspart_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Assegnazione incasso al bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceedspart 		=> Tables["proceedspart"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeview 		=> Tables["incomeview"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceedspartview 		=> Tables["proceedspartview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurerincome 		=> Tables["treasurerincome"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbincome 		=> Tables["upbincome"];

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
	//////////////////// PROCEEDSPART /////////////////////////////////
	var tproceedspart= new DataTable("proceedspart");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("nproceedspart", typeof(int));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("yproceedspart", typeof(short));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	tproceedspart.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	tproceedspart.Columns.Add( new DataColumn("txt", typeof(string)));
	tproceedspart.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspart.Columns.Add(C);
	tproceedspart.Columns.Add( new DataColumn("idupb", typeof(string)));
	tproceedspart.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tproceedspart.Columns.Add( new DataColumn("!upb", typeof(string)));
	Tables.Add(tproceedspart);
	tproceedspart.PrimaryKey =  new DataColumn[]{tproceedspart.Columns["idinc"], tproceedspart.Columns["nproceedspart"]};


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
	tincomeview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomeview.Columns.Add( new DataColumn("npro", typeof(int)));
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
	tincomeview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(tincomeview);
	tincomeview.PrimaryKey =  new DataColumn[]{tincomeview.Columns["idinc"]};


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
	Tables.Add(tfinview);
	tfinview.PrimaryKey =  new DataColumn[]{tfinview.Columns["idfin"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// PROCEEDSPARTVIEW /////////////////////////////////
	var tproceedspartview= new DataTable("proceedspartview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("nproceedspart", typeof(int));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("yproceedspart", typeof(short));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	tproceedspartview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	tproceedspartview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tproceedspartview.Columns.Add( new DataColumn("financeincome", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceedspartview.Columns.Add(C);
	tproceedspartview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	tproceedspartview.Columns.Add( new DataColumn("idupbincome", typeof(string)));
	tproceedspartview.Columns.Add( new DataColumn("codeupbincome", typeof(string)));
	tproceedspartview.Columns.Add( new DataColumn("upbincome", typeof(string)));
	tproceedspartview.Columns.Add( new DataColumn("idtreasurerincome", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("treasurerincome", typeof(string)));
	tproceedspartview.Columns.Add( new DataColumn("allocatedamount", typeof(decimal)));
	tproceedspartview.Columns.Add( new DataColumn("moneytotransfer", typeof(decimal)));
	tproceedspartview.Columns.Add( new DataColumn("moneytransfered", typeof(decimal)));
	tproceedspartview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tproceedspartview.Columns.Add( new DataColumn("treasurerproceeds", typeof(string)));
	tproceedspartview.Columns.Add( new DataColumn("idtreasurerproceeds", typeof(int)));
	Tables.Add(tproceedspartview);
	tproceedspartview.PrimaryKey =  new DataColumn[]{tproceedspartview.Columns["idinc"], tproceedspartview.Columns["nproceedspart"]};


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
	tconfig.Columns.Add( new DataColumn("finvarofficial_default", typeof(string)));
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
	tconfig.Columns.Add( new DataColumn("idregauto", typeof(int)));
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
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind1", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind2", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsortingkind3", typeof(int)));
	tconfig.Columns.Add( new DataColumn("fin_kind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("taxvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("flag_paymentamount", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("automanagekind", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	tconfig.Columns.Add( new DataColumn("cashvaliditykind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("wageimportappname", typeof(string)));
	tconfig.Columns.Add( new DataColumn("balancekind", typeof(byte)));
	tconfig.Columns.Add( new DataColumn("idpaymethodabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idpaymethodnoabi", typeof(int)));
	tconfig.Columns.Add( new DataColumn("iban_f24", typeof(string)));
	tconfig.Columns.Add( new DataColumn("cudactivitycode", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("flagivapaybyrow", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("invoice_flagregister", typeof(string)));
	tconfig.Columns.Add( new DataColumn("default_idfinvarstatus", typeof(short)));
	tconfig.Columns.Add( new DataColumn("flagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminpayment", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminrefund", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainflagivaregphase", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidacc_unabatable_refund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagva3", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("refundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("paymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("minrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("minpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idacc_ivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_ivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivapayment_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_mainivarefund_internal12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("startivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainrefundagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainpaymentagency12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainflagrefund12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainflagpayment12", typeof(string)));
	tconfig.Columns.Add( new DataColumn("mainidfinivarefund12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainidfinivapayment12", typeof(int)));
	tconfig.Columns.Add( new DataColumn("mainminrefund12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainminpayment12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("mainstartivabalance12", typeof(decimal)));
	tconfig.Columns.Add( new DataColumn("idreg_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("finvar_warnmail", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagdirectcsaclawback", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idacc_revenue_gross_csa", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idfinincome_gross_csa", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor1_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor2_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idsor3_stock", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idinpscenter", typeof(string)));
	tconfig.Columns.Add( new DataColumn("idivapayperiodicity_instit", typeof(int)));
	tconfig.Columns.Add( new DataColumn("idfin_store", typeof(int)));
	tconfig.Columns.Add( new DataColumn("flagpcashautopayment", typeof(string)));
	tconfig.Columns.Add( new DataColumn("flagpcashautoproceeds", typeof(string)));
	tconfig.Columns.Add( new DataColumn("email", typeof(string)));
	tconfig.Columns.Add( new DataColumn("lcard", typeof(string)));
	tconfig.Columns.Add( new DataColumn("booking_on_invoice", typeof(string)));
	tconfig.Columns.Add( new DataColumn("itineration_directauth", typeof(string)));
	tconfig.Columns.Add( new DataColumn("email_f24", typeof(string)));
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


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
	ttreasurer.Columns.Add( new DataColumn("billcode", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// TREASURERINCOME /////////////////////////////////
	var ttreasurerincome= new DataTable("treasurerincome");
	ttreasurerincome.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("agencycodefortransmission", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("cabcodefortransmission", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	ttreasurerincome.Columns.Add( new DataColumn("depcodefortransmission", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("description", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	ttreasurerincome.Columns.Add( new DataColumn("idaccmotive_payment", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("idcab", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	ttreasurerincome.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	C= new DataColumn("codetreasurer", typeof(string));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurerincome.Columns.Add(C);
	ttreasurerincome.Columns.Add( new DataColumn("spexportexp", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("flagmultiexp", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("fileextension", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("spexportinc", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("iban", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("bic", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("cccbi", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("cincbi", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("idbankcbi", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("idcabcbi", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("ibancbi", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("siacodecbi", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("reccbikind", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("trasmcode", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	ttreasurerincome.Columns.Add( new DataColumn("motivelen", typeof(short)));
	ttreasurerincome.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("motiveseparator", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("flagedisp", typeof(string)));
	ttreasurerincome.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurerincome.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurerincome.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurerincome.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurerincome.Columns.Add( new DataColumn("idsor05", typeof(int)));
	ttreasurerincome.Columns.Add( new DataColumn("billcode", typeof(string)));
	Tables.Add(ttreasurerincome);
	ttreasurerincome.PrimaryKey =  new DataColumn[]{ttreasurerincome.Columns["idtreasurer"]};


	//////////////////// UPBINCOME /////////////////////////////////
	var tupbincome= new DataTable("upbincome");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	tupbincome.Columns.Add( new DataColumn("active", typeof(string)));
	tupbincome.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	tupbincome.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupbincome.Columns.Add( new DataColumn("granted", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	tupbincome.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupbincome.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupbincome.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	tupbincome.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupbincome.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupbincome.Columns.Add(C);
	tupbincome.Columns.Add( new DataColumn("txt", typeof(string)));
	tupbincome.Columns.Add( new DataColumn("idman", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupbincome.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupbincome.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupbincome.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupbincome.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupbincome.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tupbincome);
	tupbincome.PrimaryKey =  new DataColumn[]{tupbincome.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{treasurerincome.Columns["idtreasurer"]};
	var cChild = new []{upbincome.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_treasurerincome_upbincome",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{upb.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_treasurer_upb",cPar,cChild,false));

	cPar = new []{upbincome.Columns["idupb"]};
	cChild = new []{incomeview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upbincome_incomeview",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{proceedspart.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_proceedspart",cPar,cChild,false));

	cPar = new []{finview.Columns["idfin"]};
	cChild = new []{proceedspart.Columns["idfin"]};
	Relations.Add(new DataRelation("finviewproceedspart",cPar,cChild,false));

	cPar = new []{incomeview.Columns["idinc"]};
	cChild = new []{proceedspart.Columns["idinc"]};
	Relations.Add(new DataRelation("incomeviewproceedspart",cPar,cChild,false));

	#endregion

}
}
}
