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
namespace csa_contractkinddata_elenco {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Contributi Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkinddata 		=> Tables["csa_contractkinddata"];

	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractkind 		=> Tables["csa_contractkind"];

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
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

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
	EnforceConstraints = false;

	#region create DataTables
	DataColumn C;
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
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkinddata.Columns.Add(C);
	tcsa_contractkinddata.Columns.Add( new DataColumn("!codefin", typeof(string)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("!codeacc", typeof(string)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("idupb", typeof(string)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	tcsa_contractkinddata.Columns.Add( new DataColumn("!sortcode", typeof(string)));
	Tables.Add(tcsa_contractkinddata);
	tcsa_contractkinddata.PrimaryKey =  new DataColumn[]{tcsa_contractkinddata.Columns["idcsa_contractkind"], tcsa_contractkinddata.Columns["idcsa_contractkinddata"], tcsa_contractkinddata.Columns["ayear"]};


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
	Tables.Add(tcsa_contractkind);
	tcsa_contractkind.PrimaryKey =  new DataColumn[]{tcsa_contractkind.Columns["idcsa_contractkind"]};


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagprofit", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagloss", typeof(string)));
	taccount.Columns.Add( new DataColumn("placcount_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("patrimony_sign", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagcompetency", typeof(string)));
	taccount.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
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
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// CSA_CONTRACTKINDDATAVIEW /////////////////////////////////
	var tcsa_contractkinddataview= new DataTable("csa_contractkinddataview");
	C= new DataColumn("idcsa_contractkind", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("idcsa_contractkinddata", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("csa_contractkindcode", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("csa_contractkind", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractkinddataview.Columns.Add(C);
	tcsa_contractkinddataview.Columns.Add( new DataColumn("idfin", typeof(int)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("codefin", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("idacc", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("codeacc", typeof(string)));
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
	tcsa_contractkinddataview.Columns.Add( new DataColumn("flagcr", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("fin", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("account", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("upb", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("sort_siope", typeof(string)));
	tcsa_contractkinddataview.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tcsa_contractkinddataview);
	tcsa_contractkinddataview.PrimaryKey =  new DataColumn[]{tcsa_contractkinddataview.Columns["idcsa_contractkind"], tcsa_contractkinddataview.Columns["idcsa_contractkinddata"], tcsa_contractkinddataview.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{csa_contractkinddata.Columns["idsor_siope"]};
	Relations.Add(new DataRelation("FK_sorting_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{csa_contractkinddata.Columns["idacc"]};
	Relations.Add(new DataRelation("account_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{csa_contractkind.Columns["idcsa_contractkind"]};
	cChild = new []{csa_contractkinddata.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{csa_contractkinddata.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_csa_contractkinddata",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{csa_contractkinddata.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_csa_contractkinddata",cPar,cChild,false));

	#endregion

}
}
}
