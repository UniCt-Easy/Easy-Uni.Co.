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
namespace sortingprevexpensevar_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingprevexpensevarview 		=> Tables["sortingprevexpensevarview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	///<summary>
	///Variazione classificazione spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingprevexpensevar 		=> Tables["sortingprevexpensevar"];

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
	//////////////////// SORTINGPREVEXPENSEVARVIEW /////////////////////////////////
	var tsortingprevexpensevarview= new DataTable("sortingprevexpensevarview");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	tsortingprevexpensevarview.Columns.Add( new DataColumn("idsorkind", typeof(int)));
	tsortingprevexpensevarview.Columns.Add( new DataColumn("idsor", typeof(int)));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	C= new DataColumn("sorting", typeof(string));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	tsortingprevexpensevarview.Columns.Add( new DataColumn("ayear", typeof(short)));
	tsortingprevexpensevarview.Columns.Add( new DataColumn("description", typeof(string)));
	tsortingprevexpensevarview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tsortingprevexpensevarview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingprevexpensevarview.Columns.Add(C);
	Tables.Add(tsortingprevexpensevarview);
	tsortingprevexpensevarview.PrimaryKey =  new DataColumn[]{tsortingprevexpensevarview.Columns["yvar"], tsortingprevexpensevarview.Columns["nvar"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsortingview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsortingview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsortingview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsortingview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsorkind"], tsortingview.Columns["idsor"], tsortingview.Columns["ayear"]};


	//////////////////// SORTINGPREVEXPENSEVAR /////////////////////////////////
	var tsortingprevexpensevar= new DataTable("sortingprevexpensevar");
	C= new DataColumn("yvar", typeof(short));
	C.AllowDBNull=false;
	tsortingprevexpensevar.Columns.Add(C);
	C= new DataColumn("nvar", typeof(int));
	C.AllowDBNull=false;
	tsortingprevexpensevar.Columns.Add(C);
	tsortingprevexpensevar.Columns.Add( new DataColumn("idsor", typeof(int)));
	tsortingprevexpensevar.Columns.Add( new DataColumn("ayear", typeof(short)));
	tsortingprevexpensevar.Columns.Add( new DataColumn("description", typeof(string)));
	tsortingprevexpensevar.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tsortingprevexpensevar.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tsortingprevexpensevar.Columns.Add( new DataColumn("txt", typeof(string)));
	tsortingprevexpensevar.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingprevexpensevar.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingprevexpensevar.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingprevexpensevar.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingprevexpensevar.Columns.Add(C);
	Tables.Add(tsortingprevexpensevar);
	tsortingprevexpensevar.PrimaryKey =  new DataColumn[]{tsortingprevexpensevar.Columns["yvar"], tsortingprevexpensevar.Columns["nvar"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortingview.Columns["idsor"]};
	var cChild = new []{sortingprevexpensevar.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingview_sortingprevexpensevar",cPar,cChild,false));

	#endregion

}
}
}
