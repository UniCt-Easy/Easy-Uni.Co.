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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace sortingall_tree {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingall 		=> Tables["sortingall"];

	///<summary>
	///Livello Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortinglevel 		=> Tables["sortinglevel"];

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
	//////////////////// SORTINGALL /////////////////////////////////
	var tsortingall= new DataTable("sortingall");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsortingall.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingall.Columns.Add(C);
	tsortingall.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingall.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingall.Columns.Add( new DataColumn("email", typeof(string)));
	tsortingall.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsortingall.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsortingall);
	tsortingall.PrimaryKey =  new DataColumn[]{tsortingall.Columns["idsor"]};


	//////////////////// SORTINGLEVEL /////////////////////////////////
	var tsortinglevel= new DataTable("sortinglevel");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	C= new DataColumn("flag", typeof(short));
	C.AllowDBNull=false;
	tsortinglevel.Columns.Add(C);
	Tables.Add(tsortinglevel);
	tsortinglevel.PrimaryKey =  new DataColumn[]{tsortinglevel.Columns["idsorkind"], tsortinglevel.Columns["nlevel"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sortinglevel.Columns["idsorkind"], sortinglevel.Columns["nlevel"]};
	var cChild = new []{sortingall.Columns["idsorkind"], sortingall.Columns["nlevel"]};
	Relations.Add(new DataRelation("sortinglevel_sortingall",cPar,cChild,false));

	cPar = new []{sortingall.Columns["idsor"]};
	cChild = new []{sortingall.Columns["paridsor"]};
	Relations.Add(new DataRelation("sortingall_sortingall",cPar,cChild,false));

	#endregion

}
}
}
