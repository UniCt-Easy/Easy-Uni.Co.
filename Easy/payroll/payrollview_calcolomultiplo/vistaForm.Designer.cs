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
namespace payrollview_calcolomultiplo {
[System.CodeDom.Compiler.GeneratedCodeAttribute("HDSGene", "2.0")]
[DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable payroll		{get { return Tables["payroll"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable parasubcontract		{get { return Tables["parasubcontract"];}}
	[DebuggerNonUserCodeAttribute()][Browsable(false)]
	public DataTable payrollview		{get { return Tables["payrollview"];}}
	#endregion


[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// payroll /////////////////////////////////
	T= new DataTable("payroll");
	C= new DataColumn("idcon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idpayroll", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("npayroll", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagbalance", typeof(System.String)));
	T.Columns.Add( new DataColumn("disbursementdate", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idresidence", typeof(System.Int32)));
	C= new DataColumn("workingdays", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("feegross", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("netfee", typeof(System.Decimal)));
	C= new DataColumn("flagcomputed", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	C= new DataColumn("enabletaxrelief", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("stop", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!eserccontratto", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("!numcontratto", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpayroll"]};


	//////////////////// parasubcontract /////////////////////////////////
	T= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ycon", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("duty", typeof(System.String)));
	T.Columns.Add( new DataColumn("idpayrollkind", typeof(System.String)));
	C= new DataColumn("idser", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("employed", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("stop", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("monthlen", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("grossamount", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idpat", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("matricula", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idmatriculabook", typeof(System.String)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(System.String)));
	T.Columns.Add( new DataColumn("idupb", typeof(System.String)));
	T.Columns.Add( new DataColumn("idsor1", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor2", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idsor3", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("idaccmotivedebit", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_crg", typeof(System.String)));
	T.Columns.Add( new DataColumn("idaccmotivedebit_datacrg", typeof(System.DateTime)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcon"]};


	//////////////////// payrollview /////////////////////////////////
	T= new DataTable("payrollview");
	C= new DataColumn("idpayroll", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("feegross", typeof(System.Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("netfee", typeof(System.Decimal)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("disbursementdate", typeof(System.DateTime)));
	C= new DataColumn("stop", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagbalance", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagsummarybalance", typeof(System.String)));
	C= new DataColumn("workingdays", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idresidence", typeof(System.Int32)));
	C= new DataColumn("idcon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	C= new DataColumn("npayroll", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ycon", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ncon", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("registry", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idreg", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("matricula", typeof(System.Int32)));
	C= new DataColumn("idser", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("service", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeser", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("residencecity", typeof(System.String)));
	C= new DataColumn("idsor01", typeof(System.Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(System.Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(System.Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(System.Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(System.Int32));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ymov_lastphase", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("nmov_lastphase", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("ypay", typeof(System.Int16)));
	T.Columns.Add( new DataColumn("npay", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpayroll"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{parasubcontract.Columns["idcon"]};
	CChild = new DataColumn[1]{payroll.Columns["idcon"]};
	Relations.Add(new DataRelation("parasubcontractpayroll",CPar,CChild));

	#endregion

}
}
}
