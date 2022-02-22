
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRootAttribute("vistaRipImpegniBudgetContributiContrattiCSA")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaRipImpegniBudgetContributiContrattiCSA: System.Data.DataSet {

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
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csa_contracttaxepexp		{get { return Tables["csa_contracttaxepexp"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaRipImpegniBudgetContributiContrattiCSA(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaRipImpegniBudgetContributiContrattiCSA";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaRipImpegniBudgetContributiContrattiCSA.xsd";
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

	//////////////////// csa_contracttax /////////////////////////////////
	T= new DataTable("csa_contracttax");
	C= new DataColumn("idcsa_contract", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idfin", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idexp", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idacc", typeof(System.String)));
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
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor_siope", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idepexp", typeof(System.Int32)));
	Tables.Add(T);

	//////////////////// csa_contracttaxepexp /////////////////////////////////
	T= new DataTable("csa_contracttaxepexp");
	C= new DataColumn("idcsa_contract", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idcsa_contracttax", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("quota", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
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
	T.Columns.Add( new DataColumn("idepexp", typeof(System.Int32)));
	Tables.Add(T);

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

	CPar = new DataColumn[3]{csa_contracttax.Columns["idcsa_contract"], csa_contracttax.Columns["idcsa_contracttax"], csa_contracttax.Columns["ayear"]};
	CChild = new DataColumn[3]{csa_contracttaxepexp.Columns["idcsa_contract"], csa_contracttaxepexp.Columns["idcsa_contracttax"], csa_contracttaxepexp.Columns["ayear"]};
	Relations.Add(new DataRelation("csa_contracttax_csa_contracttaxexpense",CPar,CChild,false));

	#endregion

}
}
}
