
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
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaRipImpegniBudgetContrattiCSA")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaRipImpegniBudgetContrattiCSA: System.Data.DataSet {

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
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contractepexp		{get { return Tables["csa_contractepexp"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaRipImpegniBudgetContrattiCSA(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaRipImpegniBudgetContrattiCSA";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaRipImpegniBudgetContrattiCSA.xsd";
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// csa_contract /////////////////////////////////
	T= new DataTable("csa_contract");
	C= new DataColumn("idcsa_contract", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ycontract", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncontract", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_contractkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	C= new DataColumn("title", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagkeepalive", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("idacc_main", typeof(System.String)));
	T.Columns.Add( new DataColumn("idexp_main", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idfin_main", typeof(System.Int32)));
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
	T.Columns.Add( new DataColumn("flagrecreate", typeof(System.String)));
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_siope_main", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idunderwriting", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idepexp_main", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contract"], T.Columns["ayear"]};


	//////////////////// csa_contractkindyear /////////////////////////////////
	T= new DataTable("csa_contractkindyear");
	C= new DataColumn("idcsa_contractkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("idacc_main", typeof(System.String)));
	T.Columns.Add( new DataColumn("idfin_main", typeof(System.Int32)));
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
	T.Columns.Add( new DataColumn("idsor_siope_main", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contractkind"], T.Columns["ayear"]};


	//////////////////// csa_contractkind /////////////////////////////////
	T= new DataTable("csa_contractkind");
	C= new DataColumn("idcsa_contractkind", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("contractkindcode", typeof(System.String));
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
	C= new DataColumn("flagcr", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagkeepalive", typeof(System.String)));
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("idunderwriting", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contractkind"]};


	//////////////////// csa_contractepexp /////////////////////////////////
	T= new DataTable("csa_contractepexp");
	C= new DataColumn("idcsa_contract", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("quota", typeof(System.Decimal)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idepexp", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsa_contract"], T.Columns["ayear"], T.Columns["ndetail"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{csa_contract.Columns["idcsa_contract"], csa_contract.Columns["ayear"]};
	CChild = new DataColumn[2]{csa_contractepexp.Columns["idcsa_contract"], csa_contractepexp.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contract_csa_contractexpense",CPar,CChild,false));

	CPar = new DataColumn[1]{csa_contractkind.Columns["idcsa_contractkind"]};
	CChild = new DataColumn[1]{csa_contractkindyear.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contractkindyear",CPar,CChild,false));

	CPar = new DataColumn[1]{csa_contractkind.Columns["idcsa_contractkind"]};
	CChild = new DataColumn[1]{csa_contract.Columns["idcsa_contractkind"]};
	Relations.Add(new DataRelation("csa_contractkind_csa_contract",CPar,CChild,false));

	#endregion

}
}
}
