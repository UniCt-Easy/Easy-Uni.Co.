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
namespace csa_contractkind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkind 		=> Tables["csa_contractkind"];

	///<summary>
	///Contributi Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkinddata 		=> Tables["csa_contractkinddata"];

	///<summary>
	///Regole di individuazione CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindrules 		=> Tables["csa_contractkindrules"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///Informazioni annuali su tipo contratto csa
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindyear 		=> Tables["csa_contractkindyear"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account_main 		=> Tables["account_main"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin_main 		=> Tables["fin_main"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkindview 		=> Tables["csa_contractkindview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_main 		=> Tables["sorting_main"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Finanziamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb1 		=> Tables["upb1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkinddataview 		=> Tables["csa_contractkinddataview"];

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
	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	var tcsa_contractkind= new DataTable("csa_contractkind");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkind.Columns.Add(C);
	tcsa_contractkind.Columns.Add( new DataColumn("flagkeepalive", typeof(string)));
	tcsa_contractkind.Columns.Add( new DataColumn("active", typeof(string)));
	tcsa_contractkind.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.PrimaryKey =  new DataColumn[]{tcsa_contractkind.Columns["idcsa_contractkind"]};


	//////////////////// CSA_CONTRACTKINDDATA /////////////////////////////////
	var tcsa_contractkinddata= new DataTable("csa_contractkinddata");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("idcsa_contractkinddata", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	tcsa_contractkinddata.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("idacc", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	tcsa_contractkinddata.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("!codeacc", typeof(string)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("!codefin", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	tcsa_contractkinddata.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("!codeupb", typeof(string)));
	Tables.Add(tcsa_contractkinddata);
	tcsa_contractkinddata.PrimaryKey =  new DataColumn[]{tcsa_contractkinddata.Columns["idcsa_contractkind"], tcsa_contractkinddata.Columns["idcsa_contractkinddata"], tcsa_contractkinddata.Columns["ayear"]};


	//////////////////// CSA_CONTRACTKINDRULES /////////////////////////////////
	var tcsa_contractkindrules= new DataTable("csa_contractkindrules");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkindrules.Columns.Add(C);
	C= new DataColumn("idcsa_rule", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkindrules.Columns.Add(C);
	tcsa_contractkindrules.Columns.Add( new DataColumn("capitolocsa", typeof(string)));
	tcsa_contractkindrules.Columns.Add( new DataColumn("ruolocsa", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindrules.Columns.Add(C);
	tcsa_contractkindrules.Columns.Add( new DataColumn("cu", typeof(string)));
	tcsa_contractkindrules.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindrules.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkindrules.Columns.Add(C);
	Tables.Add(tcsa_contractkindrules);
	tcsa_contractkindrules.PrimaryKey =  new DataColumn[]{tcsa_contractkindrules.Columns["idcsa_contractkind"], tcsa_contractkindrules.Columns["idcsa_rule"], tcsa_contractkindrules.Columns["ayear"]};


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// CSA_CONTRACTKINDYEAR /////////////////////////////////
	var tcsa_contractkindyear= new DataTable("csa_contractkindyear");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	tcsa_contractkindyear.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkindyear.Columns.Add( new DataColumn("idacc_main", typeof(string)));
	tcsa_contractkindyear.Columns.Add( new DataColumn("idfin_main", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindyear.Columns.Add(C);
	tcsa_contractkindyear.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	Tables.Add(tcsa_contractkindyear);
	tcsa_contractkindyear.PrimaryKey =  new DataColumn[]{tcsa_contractkindyear.Columns["idcsa_contractkind"], tcsa_contractkindyear.Columns["ayear"]};


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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// ACCOUNT_MAIN /////////////////////////////////
	var taccount_main= new DataTable("account_main");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	taccount_main.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	taccount_main.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	taccount_main.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount_main.Columns.Add(C);
	taccount_main.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount_main.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount_main);
	taccount_main.PrimaryKey =  new DataColumn[]{taccount_main.Columns["idacc"]};


	//////////////////// FIN_MAIN /////////////////////////////////
	var tfin_main= new DataTable("fin_main");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	tfin_main.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	tfin_main.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	tfin_main.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin_main.Columns.Add(C);
	Tables.Add(tfin_main);
	tfin_main.PrimaryKey =  new DataColumn[]{tfin_main.Columns["idfin"]};


	//////////////////// CSA_CONTRACTKINDVIEW /////////////////////////////////
	var tcsa_contractkindview= new DataTable("csa_contractkindview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("idacc_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("codeacc_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("account_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("idfin_main", typeof(int)));
	tcsa_contractkindview.Columns.Add( new DataColumn("codefin_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("fin_main", typeof(string)));
	C= new DataColumn("contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("flagkeepalive", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("description", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkindview.Columns.Add(C);
	tcsa_contractkindview.Columns.Add( new DataColumn("idsor_siope_main", typeof(int)));
	tcsa_contractkindview.Columns.Add( new DataColumn("sortcode_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("sorting_main", typeof(string)));
	tcsa_contractkindview.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tcsa_contractkindview.Columns.Add( new DataColumn("underwriting", typeof(string)));
	Tables.Add(tcsa_contractkindview);
	tcsa_contractkindview.PrimaryKey =  new DataColumn[]{tcsa_contractkindview.Columns["ayear"], tcsa_contractkindview.Columns["idcsa_contractkind"]};


	//////////////////// SORTING_MAIN /////////////////////////////////
	var tsorting_main= new DataTable("sorting_main");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	tsorting_main.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_main.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	tsorting_main.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	tsorting_main.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_main.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	tsorting_main.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	tsorting_main.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_main.Columns.Add(C);
	tsorting_main.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_main.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting_main);
	tsorting_main.PrimaryKey =  new DataColumn[]{tsorting_main.Columns["idsor"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


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


	//////////////////// UPB1 /////////////////////////////////
	var tupb1= new DataTable("upb1");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb1.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb1.Columns.Add(C);
	Tables.Add(tupb1);
	tupb1.PrimaryKey =  new DataColumn[]{tupb1.Columns["idupb"]};


	//////////////////// CSA_CONTRACTKINDDATAVIEW /////////////////////////////////
	var tcsa_contractkinddataview= new DataTable("csa_contractkinddataview");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("csa_contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("csa_contractkind", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("idcsa_contractkinddata", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	tcsa_contractkinddataview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("codeacc", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	tcsa_contractkinddataview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("sortcode_siope", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	Tables.Add(tcsa_contractkinddataview);
	tcsa_contractkinddataview.PrimaryKey =  new DataColumn[]{tcsa_contractkinddataview.Columns["idcsa_contractkind"], tcsa_contractkinddataview.Columns["idcsa_contractkinddata"], tcsa_contractkinddataview.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	var cChild = new []{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{account_main.Columns["idacc"]};
	cChild = new []{csa_contractkindyear.Columns["idacc_main"]};
	Relations.Add(new DataRelation("account_main_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{fin_main.Columns["idfin"]};
	cChild = new []{csa_contractkindyear.Columns["idfin_main"]};
	Relations.Add(new DataRelation("fin_main_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_contractkindyear.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{sorting_main.Columns["idsor"]};
	cChild = new []{csa_contractkindyear.Columns["idsor_siope_main"]};
	Relations.Add(new DataRelation("FK_sorting_main_csa_contractkindyear",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkindrules.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindrules",cPar,cChild,false));

	cPar = new []{upb1.Columns["idupb"]};
	cChild = new []{csa_contractkinddata.Columns["idupb"]};
	Relations.Add(new DataRelation("upb1_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{csa_contractkinddata.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{csa_contractkinddata.Columns["idacc"]};
	Relations.Add(new DataRelation("account_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkinddata.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{sorting.Columns["idsor"]};
	cChild = new []{csa_contractkinddata.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{underwriting.Columns["idunderwriting"]};
	cChild = new []{csa_contractkind.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("FK_underwriting_csa_contractkind",cPar,cChild,false));

	#endregion

}
}
}
