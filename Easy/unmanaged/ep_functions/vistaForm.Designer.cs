
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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace ep_functions {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaEP"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaEP: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpview 		=> Tables["epexpview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epaccview 		=> Tables["epaccview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaEP(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaEP (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaEP";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaEP.xsd";

	#region create DataTables
	DataColumn C;
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
	tepexpview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepexpview.Columns.Add( new DataColumn("available5", typeof(decimal)));
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
	tepexpview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("phase", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepexpview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tepexpview);
	tepexpview.PrimaryKey =  new DataColumn[]{tepexpview.Columns["idepexp"]};


	//////////////////// EPACCVIEW /////////////////////////////////
	var tepaccview= new DataTable("epaccview");
	C= new DataColumn("idepacc", typeof(int));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("yepacc", typeof(short));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("nepacc", typeof(int));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("phase", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("totamount", typeof(decimal));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("curramount2", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("curramount3", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("curramount4", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("curramount5", typeof(decimal)));
	C= new DataColumn("totcurramount", typeof(decimal));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("available", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("available2", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("available3", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("available4", typeof(decimal)));
	tepaccview.Columns.Add( new DataColumn("available5", typeof(decimal)));
	C= new DataColumn("totavailable", typeof(decimal));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("totalrevenue", typeof(decimal));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("totalcredit", typeof(decimal));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("account", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("paridepacc", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("parentyepacc", typeof(short)));
	tepaccview.Columns.Add( new DataColumn("parentnepacc", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepaccview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("registry", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("doc", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepaccview.Columns.Add( new DataColumn("idman", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("manager", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("flagaccountusage", typeof(int)));
	C= new DataColumn("rateiattivi", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("debit", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("credit", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("cost", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("revenue", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	C= new DataColumn("reserve", typeof(string));
	C.ReadOnly=true;
	tepaccview.Columns.Add(C);
	tepaccview.Columns.Add( new DataColumn("!livprecedente", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tepaccview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tepaccview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tepaccview);

	#endregion

}
}
}
