
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
namespace payrollabatement_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollabatement 		=> Tables["payrollabatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatement 		=> Tables["abatement"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abatementcode 		=> Tables["abatementcode"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

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
	//////////////////// PAYROLLABATEMENT /////////////////////////////////
	var tpayrollabatement= new DataTable("payrollabatement");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollabatement.Columns.Add(C);
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tpayrollabatement.Columns.Add(C);
	tpayrollabatement.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrollabatement.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrollabatement.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrollabatement);
	tpayrollabatement.PrimaryKey =  new DataColumn[]{tpayrollabatement.Columns["idpayroll"], tpayrollabatement.Columns["idabatement"]};


	//////////////////// ABATEMENT /////////////////////////////////
	var tabatement= new DataTable("abatement");
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tabatement.Columns.Add(C);
	tabatement.Columns.Add( new DataColumn("lu", typeof(string)));
	tabatement.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tabatement.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tabatement.Columns.Add( new DataColumn("flagabatableexpense", typeof(string)));
	tabatement.Columns.Add( new DataColumn("appliance", typeof(string)));
	Tables.Add(tabatement);
	tabatement.PrimaryKey =  new DataColumn[]{tabatement.Columns["idabatement"]};


	//////////////////// ABATEMENTCODE /////////////////////////////////
	var tabatementcode= new DataTable("abatementcode");
	C= new DataColumn("idabatement", typeof(int));
	C.AllowDBNull=false;
	tabatementcode.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tabatementcode.Columns.Add(C);
	tabatementcode.Columns.Add( new DataColumn("code", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("description", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tabatementcode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tabatementcode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tabatementcode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	Tables.Add(tabatementcode);
	tabatementcode.PrimaryKey =  new DataColumn[]{tabatementcode.Columns["idabatement"], tabatementcode.Columns["ayear"]};


	//////////////////// PAYROLL /////////////////////////////////
	var tpayroll= new DataTable("payroll");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayroll.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayroll.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayroll.Columns.Add(C);
	tpayroll.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpayroll);
	tpayroll.PrimaryKey =  new DataColumn[]{tpayroll.Columns["idpayroll"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
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
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payroll.Columns["idpayroll"]};
	var cChild = new []{payrollabatement.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrollabatement",cPar,cChild,false));

	cPar = new []{abatement.Columns["idabatement"]};
	cChild = new []{payrollabatement.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementpayrollabatement",cPar,cChild,false));

	cPar = new []{abatementcode.Columns["idabatement"]};
	cChild = new []{payrollabatement.Columns["idabatement"]};
	Relations.Add(new DataRelation("abatementcodepayrollabatement",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payrollabatement.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayrollabatement",cPar,cChild,false));

	#endregion

}
}
}
