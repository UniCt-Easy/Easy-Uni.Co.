
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
namespace tax_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxablekind 		=> Tables["taxablekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied 		=> Tables["accmotiveapplied"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_pay 		=> Tables["accmotiveapplied_pay"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_cost 		=> Tables["accmotiveapplied_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxsorting 		=> Tables["taxsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable maintax 		=> Tables["maintax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxmotiveyear 		=> Tables["taxmotiveyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxfinmotive 		=> Tables["taxfinmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service1 		=> Tables["service1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_incomeintra 		=> Tables["finmotive_incomeintra"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_admintax 		=> Tables["finmotive_admintax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_expensecontra 		=> Tables["finmotive_expensecontra"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_incomeemploy 		=> Tables["finmotive_incomeemploy"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_expenseemploy 		=> Tables["finmotive_expenseemploy"];

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
	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	ttax.Columns.Add( new DataColumn("insuranceagencycode", typeof(string)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcodecredit", typeof(string)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcodef24ord", typeof(string)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcodecreditf24ord", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXABLEKIND /////////////////////////////////
	var ttaxablekind= new DataTable("taxablekind");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("evaluationorder", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("roundingkind", typeof(string)));
	C= new DataColumn("spcalcrefertaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("spcalcannualtaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("lu", typeof(string)));
	ttaxablekind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(ttaxablekind);
	ttaxablekind.PrimaryKey =  new DataColumn[]{ttaxablekind.Columns["taxablecode"], ttaxablekind.Columns["ayear"]};


	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new DataTable("accmotiveapplied");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("epoperation", typeof(string)));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.PrimaryKey =  new DataColumn[]{taccmotiveapplied.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_PAY /////////////////////////////////
	var taccmotiveapplied_pay= new DataTable("accmotiveapplied_pay");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	taccmotiveapplied_pay.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	taccmotiveapplied_pay.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_pay.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_pay.Columns.Add( new DataColumn("epoperation", typeof(string)));
	Tables.Add(taccmotiveapplied_pay);
	taccmotiveapplied_pay.PrimaryKey =  new DataColumn[]{taccmotiveapplied_pay.Columns["idaccmotive"]};


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
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.PrimaryKey =  new DataColumn[]{taccmotiveapplied_cost.Columns["idaccmotive"]};


	//////////////////// TAXSORTING /////////////////////////////////
	var ttaxsorting= new DataTable("taxsorting");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	ttaxsorting.Columns.Add(C);
	ttaxsorting.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	ttaxsorting.Columns.Add( new DataColumn("cu", typeof(string)));
	ttaxsorting.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	ttaxsorting.Columns.Add( new DataColumn("lu", typeof(string)));
	ttaxsorting.Columns.Add( new DataColumn("quota", typeof(decimal)));
	ttaxsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	ttaxsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	Tables.Add(ttaxsorting);
	ttaxsorting.PrimaryKey =  new DataColumn[]{ttaxsorting.Columns["idsor"], ttaxsorting.Columns["taxcode"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
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
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// MAINTAX /////////////////////////////////
	var tmaintax= new DataTable("maintax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	tmaintax.Columns.Add( new DataColumn("active", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	tmaintax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmaintax.Columns.Add(C);
	tmaintax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	tmaintax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	tmaintax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	Tables.Add(tmaintax);
	tmaintax.PrimaryKey =  new DataColumn[]{tmaintax.Columns["taxcode"]};


	//////////////////// TAXMOTIVEYEAR /////////////////////////////////
	var ttaxmotiveyear= new DataTable("taxmotiveyear");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	ttaxmotiveyear.Columns.Add( new DataColumn("idser", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	ttaxmotiveyear.Columns.Add( new DataColumn("!codeser", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!service", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!codemotive_cost", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!accmotive_cost", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!codemotive_pay", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!accmotive_pay", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!codemotive_debit", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("!accmotive_debit", typeof(string)));
	C= new DataColumn("idtaxmotiveyear", typeof(int));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	ttaxmotiveyear.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	Tables.Add(ttaxmotiveyear);
	ttaxmotiveyear.PrimaryKey =  new DataColumn[]{ttaxmotiveyear.Columns["idtaxmotiveyear"]};


	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new DataTable("accmotive");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	tservice.Columns.Add( new DataColumn("active", typeof(string)));
	tservice.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagapplyabatements", typeof(string)));
	C= new DataColumn("flagonlyfiscalabatement", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice.Columns.Add( new DataColumn("ivaamount", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("module", typeof(string)));
	tservice.Columns.Add( new DataColumn("rec770kind", typeof(string)));
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000", typeof(string)));
	tservice.Columns.Add( new DataColumn("webdefault", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdistraint", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000refund_i", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000refund_e", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagcsausability", typeof(int)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


	//////////////////// TAXFINMOTIVE /////////////////////////////////
	var ttaxfinmotive= new DataTable("taxfinmotive");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxfinmotive.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	ttaxfinmotive.Columns.Add(C);
	ttaxfinmotive.Columns.Add( new DataColumn("idmotincomeintra", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	ttaxfinmotive.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	ttaxfinmotive.Columns.Add( new DataColumn("lu", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("cu", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("idmotincomeemploy", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("idmotadmintax", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("idmotexpenseemploy", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("idmotexpensecontra", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!codemotive_incomeintra", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!finmotive_incomeintra", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!codemotive_admintax", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!finmotive_admintax", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!codemotive_expensecontra", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!finmotive_expensecontra", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!codemotive_incomeemploy", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!finmotive_incomeemploy", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!codemotive_expenseemploy", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!finmotive_expenseemploy", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!codeser", typeof(string)));
	ttaxfinmotive.Columns.Add( new DataColumn("!service", typeof(string)));
	Tables.Add(ttaxfinmotive);
	ttaxfinmotive.PrimaryKey =  new DataColumn[]{ttaxfinmotive.Columns["taxcode"], ttaxfinmotive.Columns["idser"]};


	//////////////////// SERVICE1 /////////////////////////////////
	var tservice1= new DataTable("service1");
	tservice1.Columns.Add( new DataColumn("active", typeof(string)));
	tservice1.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice1.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	tservice1.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(string)));
	tservice1.Columns.Add( new DataColumn("flagapplyabatements", typeof(string)));
	C= new DataColumn("flagonlyfiscalabatement", typeof(string));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	tservice1.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice1.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice1.Columns.Add( new DataColumn("ivaamount", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	tservice1.Columns.Add( new DataColumn("module", typeof(string)));
	tservice1.Columns.Add( new DataColumn("rec770kind", typeof(string)));
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice1.Columns.Add(C);
	tservice1.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
	tservice1.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tservice1.Columns.Add( new DataColumn("voce8000", typeof(string)));
	tservice1.Columns.Add( new DataColumn("webdefault", typeof(string)));
	tservice1.Columns.Add( new DataColumn("flagdistraint", typeof(string)));
	tservice1.Columns.Add( new DataColumn("voce8000refund_i", typeof(string)));
	tservice1.Columns.Add( new DataColumn("voce8000refund_e", typeof(string)));
	tservice1.Columns.Add( new DataColumn("flagcsausability", typeof(int)));
	tservice1.Columns.Add( new DataColumn("flagnoexemptionquote", typeof(string)));
	Tables.Add(tservice1);
	tservice1.PrimaryKey =  new DataColumn[]{tservice1.Columns["idser"]};


	//////////////////// FINMOTIVE_INCOMEINTRA /////////////////////////////////
	var tfinmotive_incomeintra= new DataTable("finmotive_incomeintra");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeintra.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeintra.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeintra.Columns.Add(C);
	tfinmotive_incomeintra.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeintra.Columns.Add(C);
	tfinmotive_incomeintra.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_incomeintra.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_incomeintra.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_incomeintra.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_incomeintra);
	tfinmotive_incomeintra.PrimaryKey =  new DataColumn[]{tfinmotive_incomeintra.Columns["idfinmotive"]};


	//////////////////// FINMOTIVE_ADMINTAX /////////////////////////////////
	var tfinmotive_admintax= new DataTable("finmotive_admintax");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_admintax.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_admintax.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_admintax.Columns.Add(C);
	tfinmotive_admintax.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_admintax.Columns.Add(C);
	tfinmotive_admintax.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_admintax.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_admintax.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_admintax.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_admintax);
	tfinmotive_admintax.PrimaryKey =  new DataColumn[]{tfinmotive_admintax.Columns["idfinmotive"]};


	//////////////////// FINMOTIVE_EXPENSECONTRA /////////////////////////////////
	var tfinmotive_expensecontra= new DataTable("finmotive_expensecontra");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expensecontra.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expensecontra.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expensecontra.Columns.Add(C);
	tfinmotive_expensecontra.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expensecontra.Columns.Add(C);
	tfinmotive_expensecontra.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_expensecontra.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_expensecontra.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_expensecontra.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_expensecontra);
	tfinmotive_expensecontra.PrimaryKey =  new DataColumn[]{tfinmotive_expensecontra.Columns["idfinmotive"]};


	//////////////////// FINMOTIVE_INCOMEEMPLOY /////////////////////////////////
	var tfinmotive_incomeemploy= new DataTable("finmotive_incomeemploy");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeemploy.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeemploy.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeemploy.Columns.Add(C);
	tfinmotive_incomeemploy.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_incomeemploy.Columns.Add(C);
	tfinmotive_incomeemploy.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_incomeemploy.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_incomeemploy.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_incomeemploy.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_incomeemploy);
	tfinmotive_incomeemploy.PrimaryKey =  new DataColumn[]{tfinmotive_incomeemploy.Columns["idfinmotive"]};


	//////////////////// FINMOTIVE_EXPENSEEMPLOY /////////////////////////////////
	var tfinmotive_expenseemploy= new DataTable("finmotive_expenseemploy");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expenseemploy.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expenseemploy.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expenseemploy.Columns.Add(C);
	tfinmotive_expenseemploy.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_expenseemploy.Columns.Add(C);
	tfinmotive_expenseemploy.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_expenseemploy.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_expenseemploy.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_expenseemploy.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_expenseemploy);
	tfinmotive_expenseemploy.PrimaryKey =  new DataColumn[]{tfinmotive_expenseemploy.Columns["idfinmotive"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finmotive_expenseemploy.Columns["idfinmotive"]};
	var cChild = new []{taxfinmotive.Columns["idmotexpenseemploy"]};
	Relations.Add(new DataRelation("FK_finmotive_expenseemploy_taxfinmotive",cPar,cChild,false));

	cPar = new []{finmotive_incomeemploy.Columns["idfinmotive"]};
	cChild = new []{taxfinmotive.Columns["idmotincomeemploy"]};
	Relations.Add(new DataRelation("FK_finmotive_incomeemploy_taxfinmotive",cPar,cChild,false));

	cPar = new []{finmotive_expensecontra.Columns["idfinmotive"]};
	cChild = new []{taxfinmotive.Columns["idmotexpensecontra"]};
	Relations.Add(new DataRelation("FK_finmotive_expensecontra_taxfinmotive",cPar,cChild,false));

	cPar = new []{finmotive_admintax.Columns["idfinmotive"]};
	cChild = new []{taxfinmotive.Columns["idmotadmintax"]};
	Relations.Add(new DataRelation("FK_finmotive_admintax_taxfinmotive",cPar,cChild,false));

	cPar = new []{finmotive_incomeintra.Columns["idfinmotive"]};
	cChild = new []{taxfinmotive.Columns["idmotincomeintra"]};
	Relations.Add(new DataRelation("FK_finmotive_incomeintra_taxfinmotive",cPar,cChild,false));

	cPar = new []{service1.Columns["idser"]};
	cChild = new []{taxfinmotive.Columns["idser"]};
	Relations.Add(new DataRelation("FK_service1_taxfinmotive",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{taxfinmotive.Columns["taxcode"]};
	Relations.Add(new DataRelation("FK_tax_taxfinmotive",cPar,cChild,false));

	cPar = new []{accmotiveapplied_cost.Columns["idaccmotive"]};
	cChild = new []{taxmotiveyear.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("accmotiveapplied_costtax",cPar,cChild,false));

	cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	cChild = new []{taxmotiveyear.Columns["idaccmotive_debit"]};
	Relations.Add(new DataRelation("accmotiveappliedtax",cPar,cChild,false));

	cPar = new []{accmotiveapplied_pay.Columns["idaccmotive"]};
	cChild = new []{taxmotiveyear.Columns["idaccmotive_pay"]};
	Relations.Add(new DataRelation("accmotiveapplied_paytax",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{taxmotiveyear.Columns["idser"]};
	Relations.Add(new DataRelation("FK_service_taxmotiveyear",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{taxsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingtaxsorting",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{taxsorting.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxtaxsorting",cPar,cChild,false));

	cPar = new []{maintax.Columns["taxcode"]};
	cChild = new []{tax.Columns["maintaxcode"]};
	Relations.Add(new DataRelation("maintaxtax",cPar,cChild,false));

	cPar = new []{taxablekind.Columns["taxablecode"]};
	cChild = new []{tax.Columns["taxablecode"]};
	Relations.Add(new DataRelation("taxablekindtax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{taxmotiveyear.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_taxmotiveyear",cPar,cChild,false));

	#endregion

}
}
}
