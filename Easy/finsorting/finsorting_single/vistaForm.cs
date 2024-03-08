
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
namespace finsorting_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finsorting 		=> Tables["finsorting"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingapplicabilityview 		=> Tables["sortingapplicabilityview"];

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
	//////////////////// FINSORTING /////////////////////////////////
	var tfinsorting= new DataTable("finsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinsorting.Columns.Add(C);
	tfinsorting.Columns.Add( new DataColumn("quota", typeof(double)));
	Tables.Add(tfinsorting);
	tfinsorting.PrimaryKey =  new DataColumn[]{tfinsorting.Columns["idfin"], tfinsorting.Columns["idsor"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// SORTINGAPPLICABILITYVIEW /////////////////////////////////
	var tsortingapplicabilityview= new DataTable("sortingapplicabilityview");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	tsortingapplicabilityview.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("incomephase", typeof(string)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("expensephase", typeof(string)));
	C= new DataColumn("flagcheckavailability", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("flagforced", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	tsortingapplicabilityview.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tsortingapplicabilityview.Columns.Add(C);
	tsortingapplicabilityview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingapplicabilityview.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsortingapplicabilityview);
	tsortingapplicabilityview.PrimaryKey =  new DataColumn[]{tsortingapplicabilityview.Columns["idsorkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{finsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingfinsorting",cPar,cChild,false));

	#endregion

}
}
}
