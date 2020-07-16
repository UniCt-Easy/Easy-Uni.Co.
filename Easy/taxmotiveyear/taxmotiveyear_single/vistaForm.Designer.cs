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
namespace taxmotiveyear_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Impostazioni EP imposte 
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxmotiveyear 		=> Tables["taxmotiveyear"];

	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_cost 		=> Tables["accmotiveapplied_cost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_debit 		=> Tables["accmotiveapplied_debit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_pay 		=> Tables["accmotiveapplied_pay"];

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
	//////////////////// TAXMOTIVEYEAR /////////////////////////////////
	var ttaxmotiveyear= new DataTable("taxmotiveyear");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	ttaxmotiveyear.Columns.Add( new DataColumn("idser", typeof(int)));
	ttaxmotiveyear.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
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
	ttaxmotiveyear.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttaxmotiveyear.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	C= new DataColumn("idtaxmotiveyear", typeof(int));
	C.AllowDBNull=false;
	ttaxmotiveyear.Columns.Add(C);
	Tables.Add(ttaxmotiveyear);
	ttaxmotiveyear.PrimaryKey =  new DataColumn[]{ttaxmotiveyear.Columns["idtaxmotiveyear"]};


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
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_cost.Columns.Add(C);
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_cost.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotiveapplied_cost);
	taccmotiveapplied_cost.PrimaryKey =  new DataColumn[]{taccmotiveapplied_cost.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_DEBIT /////////////////////////////////
	var taccmotiveapplied_debit= new DataTable("accmotiveapplied_debit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_debit.Columns.Add(C);
	taccmotiveapplied_debit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	Tables.Add(taccmotiveapplied_debit);
	taccmotiveapplied_debit.PrimaryKey =  new DataColumn[]{taccmotiveapplied_debit.Columns["idaccmotive"]};


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
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_pay.Columns.Add(C);
	taccmotiveapplied_pay.Columns.Add( new DataColumn("epoperation", typeof(string)));
	Tables.Add(taccmotiveapplied_pay);
	taccmotiveapplied_pay.PrimaryKey =  new DataColumn[]{taccmotiveapplied_pay.Columns["idaccmotive"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{service.Columns["idser"]};
	var cChild = new []{taxmotiveyear.Columns["idser"]};
	Relations.Add(new DataRelation("FK_service_taxmotive",cPar,cChild,false));

	cPar = new []{accmotiveapplied_cost.Columns["idaccmotive"]};
	cChild = new []{taxmotiveyear.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_taxmotive",cPar,cChild,false));

	cPar = new []{accmotiveapplied_debit.Columns["idaccmotive"]};
	cChild = new []{taxmotiveyear.Columns["idaccmotive_debit"]};
	Relations.Add(new DataRelation("accmotiveapplied_apprit_taxmotive",cPar,cChild,false));

	cPar = new []{accmotiveapplied_pay.Columns["idaccmotive"]};
	cChild = new []{taxmotiveyear.Columns["idaccmotive_pay"]};
	Relations.Add(new DataRelation("accmotiveapplied_pay_taxmotive",cPar,cChild,false));

	#endregion

}
}
}
