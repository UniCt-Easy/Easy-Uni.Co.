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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace ep_functions {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaEP")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaEP: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable epexpview		{get { return Tables["epexpview"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable epaccview		{get { return Tables["epaccview"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaEP(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaEP (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaEP";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaEP.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// EPEXPVIEW /////////////////////////////////
	T= new DataTable("epexpview");
	C= new DataColumn("idepexp", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yepexp", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nepexp", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("amount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount5", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available5", typeof(Decimal)));
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("account", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("upb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridepexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("parentyepexp", typeof(Int16)));
	T.Columns.Add( new DataColumn("parentnepexp", typeof(Int32)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	T.Columns.Add( new DataColumn("!livprecedente", typeof(String)));
	T.Columns.Add( new DataColumn("phase", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idepexp"]};


	//////////////////// EPACCVIEW /////////////////////////////////
	T= new DataTable("epaccview");
	C= new DataColumn("idepacc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yepacc", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nepacc", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nphase", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("phase", typeof(String)));
	T.Columns.Add( new DataColumn("flagvariation", typeof(String)));
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("amount", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("amount2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("amount5", typeof(Decimal)));
	C= new DataColumn("totamount", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("curramount", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("curramount5", typeof(Decimal)));
	C= new DataColumn("totcurramount", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("available", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available2", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available3", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available4", typeof(Decimal)));
	T.Columns.Add( new DataColumn("available5", typeof(Decimal)));
	C= new DataColumn("totavailable", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("totalrevenue", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("totalcredit", typeof(Decimal));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("account", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("upb", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridepacc", typeof(Int32)));
	T.Columns.Add( new DataColumn("parentyepacc", typeof(Int16)));
	T.Columns.Add( new DataColumn("parentnepacc", typeof(Int32)));
	T.Columns.Add( new DataColumn("start", typeof(DateTime)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idreg", typeof(Int32)));
	T.Columns.Add( new DataColumn("registry", typeof(String)));
	T.Columns.Add( new DataColumn("doc", typeof(String)));
	T.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("idman", typeof(Int32)));
	T.Columns.Add( new DataColumn("manager", typeof(String)));
	T.Columns.Add( new DataColumn("idrelated", typeof(String)));
	T.Columns.Add( new DataColumn("flagaccountusage", typeof(Int32)));
	C= new DataColumn("rateiattivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("rateipassivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("riscontiattivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("riscontipassivi", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("debit", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("credit", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("cost", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("revenue", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("fixedassets", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("freeusesurplus", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("captiveusesurplus", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	C= new DataColumn("reserve", typeof(String));
	C.ReadOnly=true;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("!livprecedente", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("codemotive", typeof(String)));
	T.Columns.Add( new DataColumn("idsor01", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor02", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor03", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor04", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsor05", typeof(Int32)));
	Tables.Add(T);

	#endregion

}
}
}
