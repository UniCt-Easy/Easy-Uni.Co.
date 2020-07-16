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
namespace incomelast_elenco {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Partita pendente
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bill 		=> Tables["bill"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable billview 		=> Tables["billview"];

	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable income 		=> Tables["income"];

	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelast 		=> Tables["incomelast"];

	///<summary>
	///Documento di incasso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds 		=> Tables["proceeds"];

	///<summary>
	///totalizzatore su mov. di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incometotal 		=> Tables["incometotal"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomelastview 		=> Tables["incomelastview"];

	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomephase 		=> Tables["incomephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable proceeds_bankview 		=> Tables["proceeds_bankview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable banktransactionview 		=> Tables["banktransactionview"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

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
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


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
	tbill.Columns.Add( new DataColumn("banknum", typeof(int)));
	tbill.Columns.Add( new DataColumn("idbank", typeof(string)));
	Tables.Add(tbill);
	tbill.PrimaryKey =  new DataColumn[]{tbill.Columns["ybill"], tbill.Columns["nbill"], tbill.Columns["billkind"]};


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
	tmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanager.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


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
	tbillview.Columns.Add( new DataColumn("covered", typeof(decimal)));
	tbillview.Columns.Add( new DataColumn("toregularize", typeof(decimal)));
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
	tbillview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tbillview.Columns.Add( new DataColumn("treasurer", typeof(string)));
	tbillview.Columns.Add( new DataColumn("regularizationnote", typeof(string)));
	tbillview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tbillview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tbillview);
	tbillview.PrimaryKey =  new DataColumn[]{tbillview.Columns["ybill"], tbillview.Columns["nbill"], tbillview.Columns["billkind"]};


	//////////////////// INCOME /////////////////////////////////
	var tincome= new DataTable("income");
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
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
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincome.Columns.Add(C);
	tincome.Columns.Add( new DataColumn("idman", typeof(int)));
	tincome.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincome.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincome.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tincome.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tincome.Columns.Add( new DataColumn("external_reference", typeof(string)));
	Tables.Add(tincome);
	tincome.PrimaryKey =  new DataColumn[]{tincome.Columns["idinc"]};


	//////////////////// INCOMELAST /////////////////////////////////
	var tincomelast= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelast.Columns.Add(C);
	tincomelast.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelast.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomelast.Columns.Add( new DataColumn("idacccredit", typeof(string)));
	Tables.Add(tincomelast);
	tincomelast.PrimaryKey =  new DataColumn[]{tincomelast.Columns["idinc"]};


	//////////////////// PROCEEDS /////////////////////////////////
	var tproceeds= new DataTable("proceeds");
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("annulmentdate", typeof(DateTime)));
	tproceeds.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tproceeds.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tproceeds.Columns.Add( new DataColumn("txt", typeof(string)));
	tproceeds.Columns.Add( new DataColumn("idfin", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idman", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds.Columns.Add(C);
	tproceeds.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idstamphandling", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tproceeds.Columns.Add( new DataColumn("external_reference", typeof(string)));
	tproceeds.Columns.Add( new DataColumn("npro_treasurer", typeof(int)));
	Tables.Add(tproceeds);
	tproceeds.PrimaryKey =  new DataColumn[]{tproceeds.Columns["kpro"]};


	//////////////////// INCOMETOTAL /////////////////////////////////
	var tincometotal= new DataTable("incometotal");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincometotal.Columns.Add(C);
	tincometotal.Columns.Add( new DataColumn("available", typeof(decimal)));
	tincometotal.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincometotal.Columns.Add( new DataColumn("partitioned", typeof(decimal)));
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincometotal.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincometotal.Columns.Add(C);
	Tables.Add(tincometotal);
	tincometotal.PrimaryKey =  new DataColumn[]{tincometotal.Columns["ayear"], tincometotal.Columns["idinc"]};


	//////////////////// INCOMELASTVIEW /////////////////////////////////
	var tincomelastview= new DataTable("incomelastview");
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("parentymov", typeof(short)));
	tincomelastview.Columns.Add( new DataColumn("parentnmov", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("parentidinc", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("finance", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("upb", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("registry", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("idman", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("manager", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tincomelastview.Columns.Add( new DataColumn("npro", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("doc", typeof(string)));
	tincomelastview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tincomelastview.Columns.Add( new DataColumn("available", typeof(decimal)));
	C= new DataColumn("unpartitioned", typeof(decimal));
	C.ReadOnly=true;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("performed", typeof(decimal));
	C.ReadOnly=true;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("notperformed", typeof(decimal));
	C.ReadOnly=true;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("totflag", typeof(byte));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("flagarrear", typeof(string));
	C.ReadOnly=true;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	tincomelastview.Columns.Add( new DataColumn("autocode", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idpro", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomelastview.Columns.Add(C);
	tincomelastview.Columns.Add( new DataColumn("idtreasurer_main", typeof(int)));
	tincomelastview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	Tables.Add(tincomelastview);
	tincomelastview.PrimaryKey =  new DataColumn[]{tincomelastview.Columns["idinc"]};


	//////////////////// INCOMEPHASE /////////////////////////////////
	var tincomephase= new DataTable("incomephase");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tincomephase.Columns.Add(C);
	Tables.Add(tincomephase);
	tincomephase.PrimaryKey =  new DataColumn[]{tincomephase.Columns["nphase"]};


	//////////////////// PROCEEDS_BANKVIEW /////////////////////////////////
	var tproceeds_bankview= new DataTable("proceeds_bankview");
	C= new DataColumn("kpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("ypro", typeof(short));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("npro", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("idpro", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	tproceeds_bankview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("performed", typeof(decimal));
	C.ReadOnly=true;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("notperformed", typeof(decimal));
	C.ReadOnly=true;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tproceeds_bankview.Columns.Add(C);
	Tables.Add(tproceeds_bankview);
	tproceeds_bankview.PrimaryKey =  new DataColumn[]{tproceeds_bankview.Columns["kpro"], tproceeds_bankview.Columns["idpro"]};


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
	tbanktransactionview.Columns.Add( new DataColumn("kpay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypay", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npay", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("kpro", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("ypro", typeof(short)));
	tbanktransactionview.Columns.Add( new DataColumn("npro", typeof(int)));
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
	tbanktransactionview.Columns.Add( new DataColumn("idbankimport", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("motive", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("nbill", typeof(int)));
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
	tbanktransactionview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tbanktransactionview.Columns.Add( new DataColumn("registry", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tbanktransactionview.Columns.Add( new DataColumn("upb", typeof(string)));
	C= new DataColumn("idtreasurer", typeof(int));
	C.ReadOnly=true;
	tbanktransactionview.Columns.Add(C);
	Tables.Add(tbanktransactionview);
	tbanktransactionview.PrimaryKey =  new DataColumn[]{tbanktransactionview.Columns["yban"], tbanktransactionview.Columns["nban"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


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
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb.Columns.Add( new DataColumn("flag", typeof(int)));
	tupb.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	tupb.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_ra_quota", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_rb_quota", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_sa_quota", typeof(decimal)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{manager.Columns["idman"]};
	var cChild = new []{income.Columns["idman"]};
	Relations.Add(new DataRelation("manager_income",cPar,cChild,false));

	cPar = new []{bill.Columns["nbill"]};
	cChild = new []{incomelast.Columns["nbill"]};
	Relations.Add(new DataRelation("bill_incomelast",cPar,cChild,false));

	cPar = new []{income.Columns["idinc"]};
	cChild = new []{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",cPar,cChild,false));

	cPar = new []{proceeds.Columns["kpro"]};
	cChild = new []{incomelast.Columns["kpro"]};
	Relations.Add(new DataRelation("proceeds_incomelast",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{income.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_income",cPar,cChild,false));

	cPar = new []{incometotal.Columns["idinc"]};
	cChild = new []{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("incometotal_incomelast",cPar,cChild,false));

	cPar = new []{incomelastview.Columns["idinc"]};
	cChild = new []{income.Columns["idinc"]};
	Relations.Add(new DataRelation("incomelastview_income",cPar,cChild,false));

	cPar = new []{incomephase.Columns["nphase"]};
	cChild = new []{income.Columns["nphase"]};
	Relations.Add(new DataRelation("incomephase_income",cPar,cChild,false));

	cPar = new []{incomelast.Columns["kpro"], incomelast.Columns["idpro"]};
	cChild = new []{proceeds_bankview.Columns["kpro"], proceeds_bankview.Columns["idpro"]};
	Relations.Add(new DataRelation("incomelast_proceeds_bankview",cPar,cChild,false));

	cPar = new []{incomelast.Columns["idinc"]};
	cChild = new []{banktransactionview.Columns["idinc"]};
	Relations.Add(new DataRelation("incomelast_banktransactionview",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{incomelastview.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_incomelastview",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{incomelastview.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_incomelastview",cPar,cChild,false));

	#endregion

}
}
}
