
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
namespace assetload_storico {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Buono di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetload 		=> Tables["assetload"];

	///<summary>
	///Tipi di buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadkind 		=> Tables["assetloadkind"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Causali di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadmotive 		=> Tables["assetloadmotive"];

	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensephase 		=> Tables["expensephase"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetacquireview 		=> Tables["assetacquireview"];

	///<summary>
	///Movimenti di spesa collegati a buoni di carico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetloadexpense 		=> Tables["assetloadexpense"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenseview 		=> Tables["expenseview"];

	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expenselast 		=> Tables["expenselast"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetamortizationunloadview 		=> Tables["assetamortizationunloadview"];

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
	//////////////////// ASSETLOAD /////////////////////////////////
	var tassetload= new DataTable("assetload");
	C= new DataColumn("idassetload", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("yassetload", typeof(short));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("nassetload", typeof(int));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("idreg", typeof(int)));
	tassetload.Columns.Add( new DataColumn("idmot", typeof(int)));
	tassetload.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetload.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("description", typeof(string)));
	tassetload.Columns.Add( new DataColumn("enactment", typeof(string)));
	tassetload.Columns.Add( new DataColumn("enactmentdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("printdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("ratificationdate", typeof(DateTime)));
	tassetload.Columns.Add( new DataColumn("txt", typeof(string)));
	tassetload.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetload.Columns.Add(C);
	tassetload.Columns.Add( new DataColumn("transmitted", typeof(string)));
	Tables.Add(tassetload);
	tassetload.PrimaryKey =  new DataColumn[]{tassetload.Columns["idassetload"]};


	//////////////////// ASSETLOADKIND /////////////////////////////////
	var tassetloadkind= new DataTable("assetloadkind");
	C= new DataColumn("idassetloadkind", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadkind.Columns.Add(C);
	tassetloadkind.Columns.Add( new DataColumn("flag", typeof(byte)));
	tassetloadkind.Columns.Add( new DataColumn("active", typeof(string)));
	tassetloadkind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetloadkind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tassetloadkind);
	tassetloadkind.PrimaryKey =  new DataColumn[]{tassetloadkind.Columns["idassetloadkind"]};


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
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// ASSETLOADMOTIVE /////////////////////////////////
	var tassetloadmotive= new DataTable("assetloadmotive");
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetloadmotive.Columns.Add(C);
	tassetloadmotive.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tassetloadmotive.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tassetloadmotive);
	tassetloadmotive.PrimaryKey =  new DataColumn[]{tassetloadmotive.Columns["idmot"]};


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


	//////////////////// ASSETACQUIREVIEW /////////////////////////////////
	var tassetacquireview= new DataTable("assetacquireview");
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("yman", typeof(short)));
	tassetacquireview.Columns.Add( new DataColumn("nman", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("rownum", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("idmot", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("assetloadmotive", typeof(string)));
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("codeinv", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("inventorytree", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("inventory", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("assetloadkind", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetacquireview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("number", typeof(int));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("taxrate", typeof(double)));
	tassetacquireview.Columns.Add( new DataColumn("discount", typeof(double)));
	tassetacquireview.Columns.Add( new DataColumn("startnumber", typeof(int)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("flagload", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("loadkind", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("ispieceacquire", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetacquireview.Columns.Add(C);
	tassetacquireview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("cost", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idmankind", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("!pieceorasset", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("yinv", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("ninv", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("idinvkind", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("invrownum", typeof(int)));
	tassetacquireview.Columns.Add( new DataColumn("invoicekind", typeof(string)));
	tassetacquireview.Columns.Add( new DataColumn("historicalvalue", typeof(decimal)));
	tassetacquireview.Columns.Add( new DataColumn("cost_discounted", typeof(decimal)));
	Tables.Add(tassetacquireview);
	tassetacquireview.PrimaryKey =  new DataColumn[]{tassetacquireview.Columns["nassetacquire"]};


	//////////////////// ASSETLOADEXPENSE /////////////////////////////////
	var tassetloadexpense= new DataTable("assetloadexpense");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tassetloadexpense.Columns.Add(C);
	tassetloadexpense.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetloadexpense.Columns.Add( new DataColumn("cu", typeof(string)));
	tassetloadexpense.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetloadexpense.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetloadexpense.Columns.Add( new DataColumn("!ymov", typeof(short)));
	tassetloadexpense.Columns.Add( new DataColumn("!nmov", typeof(int)));
	tassetloadexpense.Columns.Add( new DataColumn("!expensedescription", typeof(string)));
	tassetloadexpense.Columns.Add( new DataColumn("!npay", typeof(string)));
	tassetloadexpense.Columns.Add( new DataColumn("!expensedoc", typeof(string)));
	tassetloadexpense.Columns.Add( new DataColumn("!amount", typeof(string)));
	C= new DataColumn("idassetload", typeof(int));
	C.AllowDBNull=false;
	tassetloadexpense.Columns.Add(C);
	Tables.Add(tassetloadexpense);
	tassetloadexpense.PrimaryKey =  new DataColumn[]{tassetloadexpense.Columns["idassetload"], tassetloadexpense.Columns["idexp"]};


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
	texpenseview.Columns.Add( new DataColumn("biccode", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("paymethod_flag", typeof(int)));
	texpenseview.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(string)));
	texpenseview.Columns.Add( new DataColumn("extracode", typeof(string)));
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
	Tables.Add(tconfig);
	tconfig.PrimaryKey =  new DataColumn[]{tconfig.Columns["ayear"]};


	//////////////////// EXPENSELAST /////////////////////////////////
	var texpenselast= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("cc", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("cin", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("idbank", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("idcab", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpay", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idregistrypaymethod", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("idser", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpenselast.Columns.Add(C);
	texpenselast.Columns.Add( new DataColumn("nbill", typeof(int)));
	texpenselast.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	texpenselast.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	texpenselast.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	Tables.Add(texpenselast);
	texpenselast.PrimaryKey =  new DataColumn[]{texpenselast.Columns["idexp"]};


	//////////////////// ASSETAMORTIZATIONUNLOADVIEW /////////////////////////////////
	var tassetamortizationunloadview= new DataTable("assetamortizationunloadview");
	C= new DataColumn("namortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("idpiece", typeof(int)));
	C= new DataColumn("idinventoryamortization", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("codeinventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("inventoryamortization", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("idinventory", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("inventory", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("ninventory", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idlocation", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("locationcode", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("location", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idcurrlocation", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("currlocationcode", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("currlocation", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idman", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("manager", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idcurrman", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("currmanager", typeof(string)));
	C= new DataColumn("nassetacquire", typeof(int));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("loaddescription", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("assetvalue", typeof(decimal)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("amortizationquota", typeof(double)));
	C= new DataColumn("amount", typeof(decimal));
	C.ReadOnly=true;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetunload", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetunloadkind", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("assetunloadkind", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("yassetunload", typeof(short)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("nassetunload", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetload", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("idassetloadkind", typeof(int)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("assetloadkind", typeof(string)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("yassetload", typeof(short)));
	tassetamortizationunloadview.Columns.Add( new DataColumn("nassetload", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("flagunload", typeof(string));
	C.ReadOnly=true;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("flagload", typeof(string));
	C.ReadOnly=true;
	tassetamortizationunloadview.Columns.Add(C);
	tassetamortizationunloadview.Columns.Add( new DataColumn("transmitted", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetamortizationunloadview.Columns.Add(C);
	Tables.Add(tassetamortizationunloadview);
	tassetamortizationunloadview.PrimaryKey =  new DataColumn[]{tassetamortizationunloadview.Columns["namortization"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{assetload.Columns["idassetload"]};
	var cChild = new []{assetamortizationunloadview.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetload_assetamortizationunloadview",cPar,cChild,false));

	cPar = new []{expenselast.Columns["idexp"]};
	cChild = new []{assetloadexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenselast_assetloadexpense",cPar,cChild,false));

	cPar = new []{assetload.Columns["idassetload"]};
	cChild = new []{assetloadexpense.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetloadassetloadexpense",cPar,cChild,false));

	cPar = new []{expenseview.Columns["idexp"]};
	cChild = new []{assetloadexpense.Columns["idexp"]};
	Relations.Add(new DataRelation("expenseview_assetloadexpense",cPar,cChild,false));

	cPar = new []{assetload.Columns["idassetload"]};
	cChild = new []{assetacquireview.Columns["idassetload"]};
	Relations.Add(new DataRelation("assetloadassetacquireview",cPar,cChild,false));

	cPar = new []{assetloadmotive.Columns["idmot"]};
	cChild = new []{assetload.Columns["idmot"]};
	Relations.Add(new DataRelation("assetloadmotiveassetload",cPar,cChild,false));

	cPar = new []{assetloadkind.Columns["idassetloadkind"]};
	cChild = new []{assetload.Columns["idassetloadkind"]};
	Relations.Add(new DataRelation("assetloadkindassetload",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{assetload.Columns["idreg"]};
	Relations.Add(new DataRelation("registryassetload",cPar,cChild,false));

	#endregion

}
}
}
