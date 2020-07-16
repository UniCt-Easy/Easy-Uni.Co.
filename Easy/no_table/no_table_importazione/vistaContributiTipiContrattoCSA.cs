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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaContributiTipiContrattiCSA")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaContributiTipiContrattiCSA: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto CSA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contract		{get { return Tables["csa_contract"];}}
	///<summary>
	///Informazioni annuali su tipo contratto csa
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contractkindyear		{get { return Tables["csa_contractkindyear"];}}
	///<summary>
	///Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contractkind		{get { return Tables["csa_contractkind"];}}
	///<summary>
	///Contributi Contratto CSA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contracttax		{get { return Tables["csa_contracttax"];}}
	///<summary>
	///Regole di individuazione CSA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contractkindrules		{get { return Tables["csa_contractkindrules"];}}
	///<summary>
	///Contributi Tipo Contratto CSA
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contractkinddata		{get { return Tables["csa_contractkinddata"];}}
	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sorting		{get { return Tables["sorting"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaContributiTipiContrattiCSA(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaContributiTipiContrattiCSA (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaContributiTipiContrattiCSA";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaContributiTipiContrattiCSA.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// CSA_CONTRACT /////////////////////////////////
	T= new DataTable("csa_contract");
	C= new DataColumn("idcsa_contract", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ycontract", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncontract", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_contractkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagkeepalive", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_main", typeof(String)));
	T.Columns.Add( new DataColumn("idexp_main", typeof(Int32)));
	T.Columns.Add( new DataColumn("idfin_main", typeof(Int32)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagrecreate", typeof(String)));
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idsor_siope_main", typeof(Int32)));
	T.Columns.Add( new DataColumn("idunderwriting", typeof(Int32)));
	T.Columns.Add( new DataColumn("idepexp_main", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contract"], T.Columns["ayear"]};


	//////////////////// CSA_CONTRACTKINDYEAR /////////////////////////////////
	T= new DataTable("csa_contractkindyear");
	C= new DataColumn("idcsa_contractkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("idacc_main", typeof(String)));
	T.Columns.Add( new DataColumn("idfin_main", typeof(Int32)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idsor_siope_main", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contractkind"], T.Columns["ayear"]};


	//////////////////// CSA_CONTRACTKIND /////////////////////////////////
	T= new DataTable("csa_contractkind");
	C= new DataColumn("idcsa_contractkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("contractkindcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagcr", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagkeepalive", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("idunderwriting", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contractkind"]};


	//////////////////// CSA_CONTRACTTAX /////////////////////////////////
	T= new DataTable("csa_contracttax");
	C= new DataColumn("idcsa_contract", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("idsor_siope", typeof(Int32)));
	T.Columns.Add( new DataColumn("idepexp", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contract"], T.Columns["idcsa_contracttax"], T.Columns["ayear"]};


	//////////////////// CSA_CONTRACTKINDRULES /////////////////////////////////
	T= new DataTable("csa_contractkindrules");
	C= new DataColumn("idcsa_contractkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_rule", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("capitoloCSA", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ruoloCSA", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contractkind"], T.Columns["idcsa_rule"], T.Columns["ayear"]};


	//////////////////// CSA_CONTRACTKINDDATA /////////////////////////////////
	T= new DataTable("csa_contractkinddata");
	C= new DataColumn("idcsa_contractkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_contractkinddata", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(Int32)));
	T.Columns.Add( new DataColumn("idacc", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(String)));
	T.Columns.Add( new DataColumn("idsor_siope", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contractkind"], T.Columns["idcsa_contractkinddata"], T.Columns["ayear"]};


	//////////////////// SORTING /////////////////////////////////
	T= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("defaultN1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultN5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultS1", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS2", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS3", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS4", typeof(String)));
	T.Columns.Add( new DataColumn("defaultS5", typeof(String)));
	T.Columns.Add( new DataColumn("defaultv1", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("defaultv5", typeof(Decimal)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagnodate", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("movkind", typeof(String)));
	T.Columns.Add( new DataColumn("printingorder", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("idsorkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idsor", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridsor", typeof(Int32)));
	C= new DataColumn("nlevel", typeof(Byte));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("start", typeof(Int16)));
	T.Columns.Add( new DataColumn("stop", typeof(Int16)));
	T.Columns.Add( new DataColumn("email", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	CChild = new DataColumn[2]{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contracttax",CPar,CChild,false));

	CPar = new DataColumn[1]{csa_contractkind.Columns["idcsa_contractkind"]};
	CChild = new DataColumn[1]{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{csa_contractkind.Columns["idcsa_contractkind"]};
	CChild = new DataColumn[1]{csa_contract.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contract",CPar,CChild,false));

	CPar = new DataColumn[1]{csa_contractkind.Columns["idcsa_contractkind"]};
	CChild = new DataColumn[1]{csa_contractkinddata.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkinddata",CPar,CChild,false));

	CPar = new DataColumn[1]{csa_contractkinddata.Columns["idsor_siope"]};
	CChild = new DataColumn[1]{sorting.Columns["idsor"]};
	Relations.Add(new DataRelation("csa_contractkinddata_sorting",CPar,CChild,false));

	#endregion

}
}
}
