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
namespace csa_contractepexp_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_contractepexp 		=> Tables["csa_contractepexp"];

	///<summary>
	///Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexp 		=> Tables["epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fase_epexp 		=> Tables["fase_epexp"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview 		=> Tables["epexpview"];

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
	//////////////////// CSA_CONTRACTEPEXP /////////////////////////////////
	var tcsa_contractepexp= new DataTable("csa_contractepexp");
	C= new DataColumn("idcsa_contract", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	tcsa_contractepexp.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_contractepexp.Columns.Add(C);
	tcsa_contractepexp.Columns.Add( new DataColumn("idepexp", typeof(int)));
	Tables.Add(tcsa_contractepexp);
	tcsa_contractepexp.PrimaryKey =  new DataColumn[]{tcsa_contractepexp.Columns["idcsa_contract"], tcsa_contractepexp.Columns["ayear"], tcsa_contractepexp.Columns["ndetail"]};


	//////////////////// EPEXP /////////////////////////////////
	var tepexp= new DataTable("epexp");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexp.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexp.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	tepexp.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexp.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepexp.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepexp.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexp.Columns.Add(C);
	Tables.Add(tepexp);
	tepexp.PrimaryKey =  new DataColumn[]{tepexp.Columns["idepexp"]};


	//////////////////// FASE_EPEXP /////////////////////////////////
	var tfase_epexp= new DataTable("fase_epexp");
	C= new DataColumn("nphase", typeof(int));
	C.AllowDBNull=false;
	tfase_epexp.Columns.Add(C);
	tfase_epexp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(tfase_epexp);
	tfase_epexp.PrimaryKey =  new DataColumn[]{tfase_epexp.Columns["nphase"]};


	//////////////////// EPEXPVIEW /////////////////////////////////
	var tepexpview= new DataTable("epexpview");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(short));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totalcost", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("totaldebit", typeof(decimal));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("paridepexp", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("parentyepexp", typeof(short)));
	tepexpview.Columns.Add( new DataColumn("parentnepexp", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepexpview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("registry", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("doc", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepexpview.Columns.Add( new DataColumn("idman", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("manager", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepexpview.Columns.Add(C);
	tepexpview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tepexpview);
	tepexpview.PrimaryKey =  new DataColumn[]{tepexpview.Columns["idepexp"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{epexpview.Columns["idepexp"]};
	var cChild = new []{csa_contractepexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview_csa_contractepexp",cPar,cChild,false));

	cPar = new []{epexp.Columns["idepexp"]};
	cChild = new []{csa_contractepexp.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexp_csa_contractepexp",cPar,cChild,false));

	#endregion

}
}
}
