
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
namespace parasubcontract_trasf_contratto {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable parasubcontract 		=> Tables["parasubcontract"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payrollview 		=> Tables["payrollview"];

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
	//////////////////// PARASUBCONTRACT /////////////////////////////////
	var tparasubcontract= new DataTable("parasubcontract");
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idpayrollkind", typeof(string)));
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idmatriculabook", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("duty", typeof(string)));
	C= new DataColumn("monthlen", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("idpat", typeof(int)));
	C= new DataColumn("grossamount", typeof(decimal));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("payrollccinfo", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	C= new DataColumn("employed", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tparasubcontract.Columns.Add( new DataColumn("lu", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("matricula", typeof(int)));
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tparasubcontract.Columns.Add(C);
	tparasubcontract.Columns.Add( new DataColumn("flagroundedmonths", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("txt", typeof(string)));
	tparasubcontract.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tparasubcontract.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tparasubcontract.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tparasubcontract);
	tparasubcontract.PrimaryKey =  new DataColumn[]{tparasubcontract.Columns["idcon"]};


	//////////////////// PAYROLLVIEW /////////////////////////////////
	var tpayrollview= new DataTable("payrollview");
	C= new DataColumn("idpayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("fiscalyear", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("enabletaxrelief", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("currentrounding", typeof(decimal));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("feegross", typeof(decimal));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("netfee", typeof(decimal)));
	tpayrollview.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpayrollview.Columns.Add( new DataColumn("cu", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("disbursementdate", typeof(DateTime)));
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("flagcomputed", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("flagsummarybalance", typeof(string)));
	C= new DataColumn("workingdays", typeof(short));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("idresidence", typeof(int)));
	C= new DataColumn("idcon", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpayrollview.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("npayroll", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("ycon", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("ncon", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("matricula", typeof(int)));
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("service", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("residencecity", typeof(string)));
	C= new DataColumn("idsor01", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor02", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor03", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor04", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	C= new DataColumn("idsor05", typeof(int));
	C.ReadOnly=true;
	tpayrollview.Columns.Add(C);
	tpayrollview.Columns.Add( new DataColumn("sortcode1", typeof(string)));
	tpayrollview.Columns.Add( new DataColumn("idcostpartition", typeof(int)));
	Tables.Add(tpayrollview);
	tpayrollview.PrimaryKey =  new DataColumn[]{tpayrollview.Columns["idpayroll"]};


	#endregion

}
}
}
