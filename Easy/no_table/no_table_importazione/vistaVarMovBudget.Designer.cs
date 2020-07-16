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
namespace notable_importazione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaVarMovBudget"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaVarMovBudget: DataSet {

	#region Table members declaration
	///<summary>
	///Variazione movimento Accertamento di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epaccvar 		=> Tables["epaccvar"];

	///<summary>
	///Variazione movimento Impegno di Budget
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epexpvar 		=> Tables["epexpvar"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaVarMovBudget(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaVarMovBudget (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaVarMovBudget";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaVarMovBudget.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// EPACCVAR /////////////////////////////////
	var tepaccvar= new DataTable("epaccvar");
	C= new DataColumn("idepacc", typeof(int));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	tepaccvar.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepaccvar.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepaccvar.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepaccvar.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tepaccvar.Columns.Add(C);
	Tables.Add(tepaccvar);
	tepaccvar.PrimaryKey =  new DataColumn[]{tepaccvar.Columns["idepacc"], tepaccvar.Columns["nvar"]};


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
	tepexpvar.Columns.Add( new DataColumn("amount2", typeof(decimal)));
	tepexpvar.Columns.Add( new DataColumn("amount3", typeof(decimal)));
	tepexpvar.Columns.Add( new DataColumn("amount4", typeof(decimal)));
	tepexpvar.Columns.Add( new DataColumn("amount5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tepexpvar.Columns.Add(C);
	Tables.Add(tepexpvar);
	tepexpvar.PrimaryKey =  new DataColumn[]{tepexpvar.Columns["idepexp"], tepexpvar.Columns["nvar"]};


	#endregion

}
}
}
