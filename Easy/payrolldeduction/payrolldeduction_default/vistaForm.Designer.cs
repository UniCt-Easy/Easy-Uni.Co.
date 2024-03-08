
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
namespace payrolldeduction_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolldeduction 		=> Tables["payrolldeduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deduction 		=> Tables["deduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxablekind 		=> Tables["taxablekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductioncode 		=> Tables["deductioncode"];

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
	//////////////////// PAYROLLDEDUCTION /////////////////////////////////
	var tpayrolldeduction= new DataTable("payrolldeduction");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tpayrolldeduction.Columns.Add(C);
	tpayrolldeduction.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	tpayrolldeduction.Columns.Add( new DataColumn("annualamount", typeof(decimal)));
	tpayrolldeduction.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	Tables.Add(tpayrolldeduction);
	tpayrolldeduction.PrimaryKey =  new DataColumn[]{tpayrolldeduction.Columns["idpayroll"], tpayrolldeduction.Columns["iddeduction"]};


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


	//////////////////// DEDUCTION /////////////////////////////////
	var tdeduction= new DataTable("deduction");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	tdeduction.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeduction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tdeduction.Columns.Add( new DataColumn("flagdeductibleexpense", typeof(string)));
	Tables.Add(tdeduction);
	tdeduction.PrimaryKey =  new DataColumn[]{tdeduction.Columns["iddeduction"]};


	//////////////////// TAXABLEKIND /////////////////////////////////
	var ttaxablekind= new DataTable("taxablekind");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("evaluationorder", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("idtaxablekind", typeof(string)));
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


	//////////////////// DEDUCTIONCODE /////////////////////////////////
	var tdeductioncode= new DataTable("deductioncode");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	tdeductioncode.Columns.Add( new DataColumn("code", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("description", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	Tables.Add(tdeductioncode);
	tdeductioncode.PrimaryKey =  new DataColumn[]{tdeductioncode.Columns["iddeduction"], tdeductioncode.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payroll.Columns["idpayroll"]};
	var cChild = new []{payrolldeduction.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolldeduction",cPar,cChild,false));

	cPar = new []{deduction.Columns["iddeduction"]};
	cChild = new []{payrolldeduction.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductionpayrolldeduction",cPar,cChild,false));

	cPar = new []{taxablekind.Columns["taxablecode"]};
	cChild = new []{payrolldeduction.Columns["taxablecode"]};
	Relations.Add(new DataRelation("taxablekindpayrolldeduction",cPar,cChild,false));

	cPar = new []{deductioncode.Columns["iddeduction"]};
	cChild = new []{payrolldeduction.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductioncodepayrolldeduction",cPar,cChild,false));

	#endregion

}
}
}
