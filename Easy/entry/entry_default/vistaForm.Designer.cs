/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace entry_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Scrittura in partita doppia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entry 		=> Tables["entry"];

	///<summary>
	///Dettaglio scrittura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetail 		=> Tables["entrydetail"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetailview 		=> Tables["entrydetailview"];

	///<summary>
	///Tipo scrittura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrykind 		=> Tables["entrykind"];

	///<summary>
	///Rateo dettaglio scrittura, Ã¨ un collegamento  tra una scrittura ed una precedentemente salvata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable entrydetailaccrual 		=> Tables["entrydetailaccrual"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

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
	//////////////////// ENTRY /////////////////////////////////
	var tentry= new DataTable("entry");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	tentry.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tentry.Columns.Add(C);
	tentry.Columns.Add( new DataColumn("doc", typeof(string)));
	tentry.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tentry.Columns.Add( new DataColumn("identrykind", typeof(int)));
	tentry.Columns.Add( new DataColumn("locked", typeof(string)));
	tentry.Columns.Add( new DataColumn("txt", typeof(string)));
	tentry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tentry.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tentry.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tentry.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tentry.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tentry.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tentry.Columns.Add( new DataColumn("official", typeof(string)));
	Tables.Add(tentry);
	tentry.PrimaryKey =  new DataColumn[]{tentry.Columns["yentry"], tentry.Columns["nentry"]};


	//////////////////// ENTRYDETAIL /////////////////////////////////
	var tentrydetail= new DataTable("entrydetail");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	tentrydetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	tentrydetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrydetail.Columns.Add(C);
	tentrydetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tentrydetail.Columns.Add( new DataColumn("!dare", typeof(decimal)));
	tentrydetail.Columns.Add( new DataColumn("!avere", typeof(decimal)));
	tentrydetail.Columns.Add( new DataColumn("!codiceconto", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("!conto", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("!registry", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tentrydetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tentrydetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tentrydetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tentrydetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tentrydetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tentrydetail.Columns.Add( new DataColumn("importcode", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("description", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("autogenerated", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tentrydetail.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tentrydetail.Columns.Add( new DataColumn("idepacc", typeof(int)));
	Tables.Add(tentrydetail);
	tentrydetail.PrimaryKey =  new DataColumn[]{tentrydetail.Columns["yentry"], tentrydetail.Columns["nentry"], tentrydetail.Columns["ndetail"]};


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


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
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// ENTRYDETAILVIEW /////////////////////////////////
	var tentrydetailview= new DataTable("entrydetailview");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("account", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("registry", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("upb", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("flagupb", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tentrydetailview.Columns.Add(C);
	tentrydetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tentrydetailview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("accmotive", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	tentrydetailview.Columns.Add( new DataColumn("identrykind", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("importcode", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("autogenerated", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("official", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idrelateddetail", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idepexp", typeof(int)));
	tentrydetailview.Columns.Add( new DataColumn("nepexp", typeof(string)));
	tentrydetailview.Columns.Add( new DataColumn("idepacc", typeof(int)));
	Tables.Add(tentrydetailview);
	tentrydetailview.PrimaryKey =  new DataColumn[]{tentrydetailview.Columns["yentry"], tentrydetailview.Columns["nentry"], tentrydetailview.Columns["ndetail"]};


	//////////////////// ENTRYKIND /////////////////////////////////
	var tentrykind= new DataTable("entrykind");
	C= new DataColumn("identrykind", typeof(int));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tentrykind.Columns.Add(C);
	Tables.Add(tentrykind);
	tentrykind.PrimaryKey =  new DataColumn[]{tentrykind.Columns["identrykind"]};


	//////////////////// ENTRYDETAILACCRUAL /////////////////////////////////
	var tentrydetailaccrual= new DataTable("entrydetailaccrual");
	C= new DataColumn("yentry", typeof(short));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	C= new DataColumn("nentry", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	C= new DataColumn("idaccrual", typeof(int));
	C.AllowDBNull=false;
	tentrydetailaccrual.Columns.Add(C);
	tentrydetailaccrual.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tentrydetailaccrual.Columns.Add( new DataColumn("yentrylinked", typeof(short)));
	tentrydetailaccrual.Columns.Add( new DataColumn("nentrylinked", typeof(int)));
	tentrydetailaccrual.Columns.Add( new DataColumn("ndetaillinked", typeof(int)));
	Tables.Add(tentrydetailaccrual);
	tentrydetailaccrual.PrimaryKey =  new DataColumn[]{tentrydetailaccrual.Columns["yentry"], tentrydetailaccrual.Columns["nentry"], tentrydetailaccrual.Columns["ndetail"], tentrydetailaccrual.Columns["idaccrual"]};


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
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


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
	tsorting05.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


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
	tsorting01.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting02.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting03.Columns.Add( new DataColumn("email", typeof(string)));
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
	tsorting04.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{entry.Columns["yentry"], entry.Columns["nentry"]};
	var cChild = new []{entrydetailaccrual.Columns["yentry"], entrydetailaccrual.Columns["nentry"]};
	Relations.Add(new DataRelation("entry_entrydetailaccrual",cPar,cChild,false));

	cPar = new []{entrydetail.Columns["yentry"], entrydetail.Columns["nentry"], entrydetail.Columns["ndetail"]};
	cChild = new []{entrydetailaccrual.Columns["yentry"], entrydetailaccrual.Columns["nentry"], entrydetailaccrual.Columns["ndetail"]};
	Relations.Add(new DataRelation("entrydetailentrydetailaccrual",cPar,cChild,false));

	cPar = new []{entry.Columns["yentry"], entry.Columns["nentry"]};
	cChild = new []{entrydetail.Columns["yentry"], entrydetail.Columns["nentry"]};
	Relations.Add(new DataRelation("entryentrydetail",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{entrydetail.Columns["idacc"]};
	Relations.Add(new DataRelation("accountentrydetail",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{entrydetail.Columns["idreg"]};
	Relations.Add(new DataRelation("registryentrydetail",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{entrydetail.Columns["idupb"]};
	Relations.Add(new DataRelation("upbentrydetail",cPar,cChild,false));

	cPar = new []{entrykind.Columns["identrykind"]};
	cChild = new []{entry.Columns["identrykind"]};
	Relations.Add(new DataRelation("entrykindentry",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{entry.Columns["idsor01"]};
	Relations.Add(new DataRelation("FK_sorting01_entry",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{entry.Columns["idsor02"]};
	Relations.Add(new DataRelation("FK_sorting02_entry",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{entry.Columns["idsor03"]};
	Relations.Add(new DataRelation("FK_sorting03_entry",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{entry.Columns["idsor04"]};
	Relations.Add(new DataRelation("FK_sorting04_entry",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{entry.Columns["idsor05"]};
	Relations.Add(new DataRelation("FK_sorting05_entry",cPar,cChild,false));

	#endregion

}
}
}
