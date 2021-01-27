
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace epexpvar_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Variazione movimento Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpvar 		=> Tables["epexpvar"];

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

	#region create DataTables
	DataColumn C;
	//////////////////// EPEXPVAR /////////////////////////////////
	var tepexpvar= new DataTable("epexpvar");
	C= new DataColumn("idepexp", typeof(int));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	tepexpvar.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpvar.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpvar.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpvar.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	Tables.Add(tepexpvar);
	tepexpvar.PrimaryKey =  new DataColumn[]{tepexpvar.Columns["idepexp"], tepexpvar.Columns["nvar"]};


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
	tepexpview.Columns.Add( new DataColumn("idsor01", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idsor02", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idsor03", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idsor04", typeof(string)));
	tepexpview.Columns.Add( new DataColumn("idsor05", typeof(string)));
	Tables.Add(tepexpview);

	#endregion


	#region DataRelation creation
	var cPar = new []{epexpview.Columns["idepexp"]};
	var cChild = new []{epexpvar.Columns["idepexp"]};
	Relations.Add(new DataRelation("epexpview_epexpvar",cPar,cChild,false));

	#endregion

}
}
}
