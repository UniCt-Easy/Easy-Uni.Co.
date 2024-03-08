
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
using System.Globalization;
namespace taxsortingsetup_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione Ritenute/Prestazioni
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable taxsortingsetup		{get { return Tables["taxsortingsetup"];}}
	///<summary>
	///Tipo di Rilevanza analitica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingkind		{get { return Tables["sortingkind"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingemployproc		{get { return Tables["sortingemployproc"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingtaxpay		{get { return Tables["sortingtaxpay"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingadminpay		{get { return Tables["sortingadminpay"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingadminproc		{get { return Tables["sortingadminproc"];}}
	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable tax		{get { return Tables["tax"];}}
	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable service		{get { return Tables["service"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sortingemploypay		{get { return Tables["sortingemploypay"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable taxsortingsetupview		{get { return Tables["taxsortingsetupview"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// taxsortingsetup /////////////////////////////////
	T= new DataTable("taxsortingsetup");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idautotaxsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idser", typeof(System.Int32)));
	C= new DataColumn("taxcode", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsorkind", typeof(System.Int32)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flaginherit", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_taxpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor_adminpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor_adminproc", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor_employproc", typeof(System.Int32)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor_employpay", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idautotaxsor"]};


	//////////////////// sortingkind /////////////////////////////////
	T= new DataTable("sortingkind");
	C= new DataColumn("idsorkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("nphaseincome", typeof(System.Byte)));
	T.Columns.Add( new DataColumn("nphaseexpense", typeof(System.Byte)));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagdate", typeof(System.String)));
	T.Columns.Add( new DataColumn("labelfordate", typeof(System.String)));
	T.Columns.Add( new DataColumn("nodatelabel", typeof(System.String)));
	T.Columns.Add( new DataColumn("labeln1", typeof(System.String)));
	T.Columns.Add( new DataColumn("labeln2", typeof(System.String)));
	T.Columns.Add( new DataColumn("labeln3", typeof(System.String)));
	T.Columns.Add( new DataColumn("labeln4", typeof(System.String)));
	T.Columns.Add( new DataColumn("labeln5", typeof(System.String)));
	T.Columns.Add( new DataColumn("labels1", typeof(System.String)));
	T.Columns.Add( new DataColumn("labels2", typeof(System.String)));
	T.Columns.Add( new DataColumn("labels3", typeof(System.String)));
	T.Columns.Add( new DataColumn("labels4", typeof(System.String)));
	T.Columns.Add( new DataColumn("labels5", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedN1", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedN2", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedN3", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedN4", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedN5", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedN1", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedN2", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedN3", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedN4", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedN5", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("totalexpression", typeof(System.String)));
	T.Columns.Add( new DataColumn("labelv1", typeof(System.String)));
	T.Columns.Add( new DataColumn("labelv2", typeof(System.String)));
	T.Columns.Add( new DataColumn("labelv3", typeof(System.String)));
	T.Columns.Add( new DataColumn("labelv4", typeof(System.String)));
	T.Columns.Add( new DataColumn("labelv5", typeof(System.String)));
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedv1", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedv2", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedv3", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedv4", typeof(System.String)));
	T.Columns.Add( new DataColumn("forcedv5", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedv1", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedv2", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedv3", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedv4", typeof(System.String)));
	T.Columns.Add( new DataColumn("lockedv5", typeof(System.String)));
	T.Columns.Add( new DataColumn("start", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(System.Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsorkind"]};


	//////////////////// sortingemployproc /////////////////////////////////
	T= new DataTable("sortingemployproc");
	C= new DataColumn("idsorkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(System.Int32)));
	C= new DataColumn("nlevel", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(System.String)));
	T.Columns.Add( new DataColumn("movkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(System.Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// sortingtaxpay /////////////////////////////////
	T= new DataTable("sortingtaxpay");
	C= new DataColumn("idsorkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(System.Int32)));
	C= new DataColumn("nlevel", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(System.String)));
	T.Columns.Add( new DataColumn("movkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(System.Decimal)));
	Tables.Add(T);

	//////////////////// sortingadminpay /////////////////////////////////
	T= new DataTable("sortingadminpay");
	C= new DataColumn("idsorkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(System.Int32)));
	C= new DataColumn("nlevel", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(System.String)));
	T.Columns.Add( new DataColumn("movkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(System.Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// sortingadminproc /////////////////////////////////
	T= new DataTable("sortingadminproc");
	C= new DataColumn("idsorkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(System.Int32)));
	C= new DataColumn("nlevel", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(System.String)));
	T.Columns.Add( new DataColumn("movkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(System.Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// tax /////////////////////////////////
	T= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("taxref", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("taxkind", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("fiscaltaxcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagunabatable", typeof(System.String)));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("taxablecode", typeof(System.String)));
	T.Columns.Add( new DataColumn("appliancebasis", typeof(System.String)));
	T.Columns.Add( new DataColumn("geoappliance", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotive_debit", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotive_pay", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotive_cost", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["taxcode"]};


	//////////////////// service /////////////////////////////////
	T= new DataTable("service");
	C= new DataColumn("idser", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeser", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("allowedit", typeof(System.String)));
	T.Columns.Add( new DataColumn("certificatekind", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagapplyabatements", typeof(System.String)));
	C= new DataColumn("flagonlyfiscalabatement", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idmotive", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("itinerationvisible", typeof(System.String)));
	T.Columns.Add( new DataColumn("ivaamount", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("module", typeof(System.String)));
	T.Columns.Add( new DataColumn("rec770kind", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idser"]};


	//////////////////// sortingemploypay /////////////////////////////////
	T= new DataTable("sortingemploypay");
	C= new DataColumn("idsorkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(System.Int32)));
	C= new DataColumn("nlevel", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(System.String)));
	T.Columns.Add( new DataColumn("rtf", typeof(System.Byte[])));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagnodate", typeof(System.String)));
	T.Columns.Add( new DataColumn("movkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(System.String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(System.Decimal)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	//////////////////// taxsortingsetupview /////////////////////////////////
	T= new DataTable("taxsortingsetupview");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idautotaxsor", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("taxref", typeof(System.String)));
	T.Columns.Add( new DataColumn("descrritenuta", typeof(System.String)));
	T.Columns.Add( new DataColumn("idser", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("codeser", typeof(System.String)));
	T.Columns.Add( new DataColumn("service", typeof(System.String)));
	T.Columns.Add( new DataColumn("flaginherit", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsorkind", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("codesorkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("sortingkind", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_employproc", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("sortcode_employproc", typeof(System.String)));
	T.Columns.Add( new DataColumn("sorting_employproc", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_adminproc", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("sortcode_adminproc", typeof(System.String)));
	T.Columns.Add( new DataColumn("sorting_adminproc", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_adminpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("sortcode_adminpay", typeof(System.String)));
	T.Columns.Add( new DataColumn("sorting_adminpay", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_taxpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("sortcode_taxpay", typeof(System.String)));
	T.Columns.Add( new DataColumn("sorting_taxpay", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_employpay", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("sortcode_employpay", typeof(System.String)));
	T.Columns.Add( new DataColumn("sorting_employpay", typeof(System.String)));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idautotaxsor"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{sortingemployproc.Columns["idsor"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idsor_employproc"]};
	Relations.Add(new DataRelation("sortingemployproc_taxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingadminpay.Columns["idsor"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idsor_adminpay"]};
	Relations.Add(new DataRelation("sortingadminpay_taxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingtaxpay.Columns["idsor"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idsor_taxpay"]};
	Relations.Add(new DataRelation("sortingtaxpay_taxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingadminproc.Columns["idsor"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idsor_adminproc"]};
	Relations.Add(new DataRelation("sortingadminproc_taxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{service.Columns["idser"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idser"]};
	Relations.Add(new DataRelation("servicetaxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingkind.Columns["idsorkind"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idsorkind"]};
	Relations.Add(new DataRelation("sortingkindtaxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{tax.Columns["taxcode"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxtaxsortingsetup",CPar,CChild,false));

	CPar = new DataColumn[1]{sortingemploypay.Columns["idsor"]};
	CChild = new DataColumn[1]{taxsortingsetup.Columns["idsor_employpay"]};
	Relations.Add(new DataRelation("sortingemploypay_taxsortingsetup",CPar,CChild,false));

	#endregion

}
}
}
