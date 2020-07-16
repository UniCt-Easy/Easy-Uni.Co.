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
namespace itinerationlap_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Località Estere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable foreigncountry 		=> Tables["foreigncountry"];

	///<summary>
	///Tipi di riduzione della diaria
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable reduction 		=> Tables["reduction"];

	///<summary>
	///Tappa missione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationlap 		=> Tables["itinerationlap"];

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
	//////////////////// FOREIGNCOUNTRY /////////////////////////////////
	var tforeigncountry= new DataTable("foreigncountry");
	C= new DataColumn("idforeigncountry", typeof(int));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigncountry.Columns.Add(C);
	tforeigncountry.Columns.Add( new DataColumn("codeforeigncountry", typeof(string)));
	Tables.Add(tforeigncountry);
	tforeigncountry.PrimaryKey =  new DataColumn[]{tforeigncountry.Columns["idforeigncountry"]};


	//////////////////// REDUCTION /////////////////////////////////
	var treduction= new DataTable("reduction");
	C= new DataColumn("idreduction", typeof(string));
	C.AllowDBNull=false;
	treduction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	treduction.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	treduction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	treduction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	treduction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	treduction.Columns.Add(C);
	Tables.Add(treduction);
	treduction.PrimaryKey =  new DataColumn[]{treduction.Columns["idreduction"]};


	//////////////////// ITINERATIONLAP /////////////////////////////////
	var titinerationlap= new DataTable("itinerationlap");
	C= new DataColumn("lapnumber", typeof(short));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	titinerationlap.Columns.Add( new DataColumn("advancepercentage", typeof(decimal)));
	titinerationlap.Columns.Add( new DataColumn("allowance", typeof(decimal)));
	titinerationlap.Columns.Add( new DataColumn("reductionpercentage", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("days", typeof(double));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("flagitalian", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("hours", typeof(double));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	titinerationlap.Columns.Add( new DataColumn("idforeigncountry", typeof(int)));
	titinerationlap.Columns.Add( new DataColumn("idreduction", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	titinerationlap.Columns.Add( new DataColumn("starttime", typeof(DateTime)));
	titinerationlap.Columns.Add( new DataColumn("stoptime", typeof(DateTime)));
	C= new DataColumn("iditineration", typeof(int));
	C.AllowDBNull=false;
	titinerationlap.Columns.Add(C);
	Tables.Add(titinerationlap);
	titinerationlap.PrimaryKey =  new DataColumn[]{titinerationlap.Columns["iditineration"], titinerationlap.Columns["lapnumber"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{reduction.Columns["idreduction"]};
	var cChild = new []{itinerationlap.Columns["idreduction"]};
	Relations.Add(new DataRelation("reduction_itinerationlap",cPar,cChild,false));

	cPar = new []{foreigncountry.Columns["idforeigncountry"]};
	cChild = new []{itinerationlap.Columns["idforeigncountry"]};
	Relations.Add(new DataRelation("foreigncountry_itinerationlap",cPar,cChild,false));

	#endregion

}
}
}
