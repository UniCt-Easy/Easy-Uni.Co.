
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
namespace payrolltax_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltax 		=> Tables["payrolltax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payroll 		=> Tables["payroll"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrolltaxbracket 		=> Tables["payrolltaxbracket"];

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
	//////////////////// PAYROLLTAX /////////////////////////////////
	var tpayrolltax= new DataTable("payrolltax");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltax.Columns.Add(C);
	tpayrolltax.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("deduction", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrolltax.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayrolltax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("employtaxgross", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualtaxabletotal", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("annualpayedemploytax", typeof(decimal)));
	tpayrolltax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tpayrolltax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tpayrolltax.Columns.Add( new DataColumn("annualcreditapplied", typeof(decimal)));
	Tables.Add(tpayrolltax);
	tpayrolltax.PrimaryKey =  new DataColumn[]{tpayrolltax.Columns["idpayroll"], tpayrolltax.Columns["idpayrolltax"]};


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
	C= new DataColumn("flagbalance", typeof(string));
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


	//////////////////// PAYROLLTAXBRACKET /////////////////////////////////
	var tpayrolltaxbracket= new DataTable("payrolltaxbracket");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	C= new DataColumn("idpayrolltax", typeof(int));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(short));
	C.AllowDBNull=false;
	tpayrolltaxbracket.Columns.Add(C);
	tpayrolltaxbracket.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("lu", typeof(string)));
	tpayrolltaxbracket.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tpayrolltaxbracket);
	tpayrolltaxbracket.PrimaryKey =  new DataColumn[]{tpayrolltaxbracket.Columns["idpayroll"], tpayrolltaxbracket.Columns["idpayrolltax"], tpayrolltaxbracket.Columns["nbracket"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{payrolltax.Columns["idpayroll"], payrolltax.Columns["idpayrolltax"]};
	var cChild = new []{payrolltaxbracket.Columns["idpayroll"], payrolltaxbracket.Columns["idpayrolltax"]};
	Relations.Add(new DataRelation("payrolltaxpayrolltaxbracket",cPar,cChild,false));

	cPar = new []{payroll.Columns["idpayroll"]};
	cChild = new []{payrolltax.Columns["idpayroll"]};
	Relations.Add(new DataRelation("payrollpayrolltax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payrolltax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayrolltax",cPar,cChild,false));

	#endregion

}
}
}
