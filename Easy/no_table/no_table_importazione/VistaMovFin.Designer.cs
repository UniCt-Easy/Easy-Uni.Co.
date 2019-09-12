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
using System.Globalization;
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("VistaMovFin")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class VistaMovFin: System.Data.DataSet {

	#region Table members declaration
	///<summary>
	///Movimento di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable income		{get { return Tables["income"];}}
	///<summary>
	///Informazioni annuali su mov. di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomeyear		{get { return Tables["incomeyear"];}}
	///<summary>
	///Informazioni annuali su movimento di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expenseyear		{get { return Tables["expenseyear"];}}
	///<summary>
	///Movimento di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expense		{get { return Tables["expense"];}}
	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable manager		{get { return Tables["manager"];}}
	///<summary>
	///Fasi di spesa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expensephase		{get { return Tables["expensephase"];}}
	///<summary>
	///Fasi di entrata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomephase		{get { return Tables["incomephase"];}}
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable upb		{get { return Tables["upb"];}}
	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable fin		{get { return Tables["fin"];}}
	///<summary>
	///Sezione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable division		{get { return Tables["division"];}}
	///<summary>
	///Movimento Bancario di pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable payment_bank		{get { return Tables["payment_bank"];}}
	///<summary>
	///Movimento Bancario di incasso
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable proceeds_bank		{get { return Tables["proceeds_bank"];}}
	///<summary>
	///Movimento di entrata - Dettaglio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable incomelast		{get { return Tables["incomelast"];}}
	///<summary>
	///Movimento di spesa - Dettaglio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable expenselast		{get { return Tables["expenselast"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public VistaMovFin(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "VistaMovFin";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaMovFin.xsd";
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// income /////////////////////////////////
	T= new DataTable("income");
	C= new DataColumn("adate", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(System.String)));
	T.Columns.Add( new DataColumn("docdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("expiration", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idreg", typeof(System.Int32)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("ymov", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpayment", typeof(System.Int32)));
	C= new DataColumn("idinc", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidinc", typeof(System.Int32)));
	C= new DataColumn("nphase", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idman", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("autokind", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("autocode", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("external_reference", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"]};


	//////////////////// incomeyear /////////////////////////////////
	T= new DataTable("incomeyear");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(System.Int32)));
	C= new DataColumn("idinc", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idinc"]};


	//////////////////// expenseyear /////////////////////////////////
	T= new DataTable("expenseyear");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount", typeof(System.Decimal)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idexp"]};


	//////////////////// expense /////////////////////////////////
	T= new DataTable("expense");
	C= new DataColumn("adate", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("doc", typeof(System.String)));
	T.Columns.Add( new DataColumn("docdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("expiration", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idreg", typeof(System.Int32)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nmov", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("ymov", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idclawback", typeof(System.Int32)));
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("parentidexp", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpayment", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idformerexpense", typeof(System.Int32)));
	C= new DataColumn("nphase", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idman", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("autokind", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("autocode", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("cigcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("cupcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("external_reference", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idexp"]};


	//////////////////// manager /////////////////////////////////
	T= new DataTable("manager");
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("email", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("passwordweb", typeof(System.String)));
	T.Columns.Add( new DataColumn("phonenumber", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("title", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("userweb", typeof(System.String)));
	C= new DataColumn("idman", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idman"]};


	//////////////////// expensephase /////////////////////////////////
	T= new DataTable("expensephase");
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// incomephase /////////////////////////////////
	T= new DataTable("incomephase");
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["nphase"]};


	//////////////////// upb /////////////////////////////////
	T= new DataTable("upb");
	C= new DataColumn("idupb", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("assured", typeof(System.String)));
	C= new DataColumn("codeupb", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("expiration", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("granted", typeof(System.Decimal)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("previousappropriation", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("previousassessment", typeof(System.Decimal)));
	C= new DataColumn("printingorder", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("requested", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("title", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("idman", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idunderwriter", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idupb"]};


	//////////////////// fin /////////////////////////////////
	T= new DataTable("fin");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codefin", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("title", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("idfin", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridfin", typeof(System.Int32)));
	C= new DataColumn("nlevel", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idfin"]};


	//////////////////// division /////////////////////////////////
	T= new DataTable("division");
	T.Columns.Add( new DataColumn("address", typeof(System.String)));
	T.Columns.Add( new DataColumn("cap", typeof(System.String)));
	T.Columns.Add( new DataColumn("city", typeof(System.String)));
	T.Columns.Add( new DataColumn("country", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("faxnumber", typeof(System.String)));
	T.Columns.Add( new DataColumn("faxprefix", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("phonenumber", typeof(System.String)));
	T.Columns.Add( new DataColumn("phoneprefix", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	C= new DataColumn("codedivision", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["iddivision"]};


	//////////////////// payment_bank /////////////////////////////////
	T= new DataTable("payment_bank");
	C= new DataColumn("idpay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	C= new DataColumn("amount", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nbill", typeof(System.Int32)));
	C= new DataColumn("kpay", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpay"], T.Columns["kpay"]};


	//////////////////// proceeds_bank /////////////////////////////////
	T= new DataTable("proceeds_bank");
	C= new DataColumn("idpro", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	C= new DataColumn("amount", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nbill", typeof(System.Int32)));
	C= new DataColumn("kpro", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpro"], T.Columns["kpro"]};


	//////////////////// incomelast /////////////////////////////////
	T= new DataTable("incomelast");
	C= new DataColumn("idinc", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpro", typeof(System.Int32)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nbill", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("kpro", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idacccredit", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idinc"]};


	//////////////////// expenselast /////////////////////////////////
	T= new DataTable("expenselast");
	C= new DataColumn("idexp", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cc", typeof(System.String)));
	T.Columns.Add( new DataColumn("cin", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flag", typeof(System.Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("iban", typeof(System.String)));
	T.Columns.Add( new DataColumn("idbank", typeof(System.String)));
	T.Columns.Add( new DataColumn("idcab", typeof(System.String)));
	T.Columns.Add( new DataColumn("iddeputy", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idregistrypaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idser", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("ivaamount", typeof(System.Decimal)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nbill", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("paymentdescr", typeof(System.String)));
	T.Columns.Add( new DataColumn("refexternaldoc", typeof(System.String)));
	T.Columns.Add( new DataColumn("servicestart", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("servicestop", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idpaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("kpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idaccdebit", typeof(System.String)));
	T.Columns.Add( new DataColumn("biccode", typeof(System.String)));
	T.Columns.Add( new DataColumn("extracode", typeof(System.String)));
	T.Columns.Add( new DataColumn("paymethod_allowdeputy", typeof(System.String)));
	T.Columns.Add( new DataColumn("paymethod_flag", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idchargehandling", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idexp"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{division.Columns["iddivision"]};
	CChild = new DataColumn[1]{manager.Columns["iddivision"]};
	Relations.Add(new DataRelation("division_manager",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{expenseyear.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_expenseyear",CPar,CChild,false));

	CPar = new DataColumn[1]{fin.Columns["idfin"]};
	CChild = new DataColumn[1]{expenseyear.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_expenseyear",CPar,CChild,false));

	CPar = new DataColumn[1]{expense.Columns["idexp"]};
	CChild = new DataColumn[1]{expenseyear.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenseyear",CPar,CChild,false));

	CPar = new DataColumn[1]{upb.Columns["idupb"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_incomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{fin.Columns["idfin"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idfin"]};
	Relations.Add(new DataRelation("FK_fin_incomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomeyear.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomeyear",CPar,CChild,false));

	CPar = new DataColumn[1]{income.Columns["idinc"]};
	CChild = new DataColumn[1]{incomelast.Columns["idinc"]};
	Relations.Add(new DataRelation("income_incomelast",CPar,CChild,false));

	CPar = new DataColumn[1]{expense.Columns["idexp"]};
	CChild = new DataColumn[1]{expenselast.Columns["idexp"]};
	Relations.Add(new DataRelation("expense_expenselast",CPar,CChild,false));

	#endregion

}
}
}
