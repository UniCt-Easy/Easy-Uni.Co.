
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
namespace itinerationrefundkind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Rimborso Spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundkind 		=> Tables["itinerationrefundkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied 		=> Tables["accmotiveapplied"];

	///<summary>
	///Elenco dei Tipi Rimborsi spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundkindgroup 		=> Tables["itinerationrefundkindgroup"];

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
	//////////////////// ITINERATIONREFUNDKIND /////////////////////////////////
	var titinerationrefundkind= new DataTable("itinerationrefundkind");
	C= new DataColumn("iditinerationrefundkind", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("codeitinerationrefundkind", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkind.Columns.Add(C);
	titinerationrefundkind.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("iditinerationrefundkindgroup", typeof(int)));
	titinerationrefundkind.Columns.Add( new DataColumn("!itinerationrefundkindgroup", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("active", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagbalance", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagadvance", typeof(string)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagmedia", typeof(byte)));
	titinerationrefundkind.Columns.Add( new DataColumn("flagvisible", typeof(int)));
	Tables.Add(titinerationrefundkind);
	titinerationrefundkind.PrimaryKey =  new DataColumn[]{titinerationrefundkind.Columns["iditinerationrefundkind"]};


	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new DataTable("accmotiveapplied");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("idepoperation", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("epoperation", typeof(string)));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.PrimaryKey =  new DataColumn[]{taccmotiveapplied.Columns["idaccmotive"]};


	//////////////////// ITINERATIONREFUNDKINDGROUP /////////////////////////////////
	var titinerationrefundkindgroup= new DataTable("itinerationrefundkindgroup");
	C= new DataColumn("iditinerationrefundkindgroup", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundkindgroup.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkindgroup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkindgroup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkindgroup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundkindgroup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundkindgroup.Columns.Add(C);
	Tables.Add(titinerationrefundkindgroup);
	titinerationrefundkindgroup.PrimaryKey =  new DataColumn[]{titinerationrefundkindgroup.Columns["iditinerationrefundkindgroup"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{itinerationrefundkindgroup.Columns["iditinerationrefundkindgroup"]};
	var cChild = new []{itinerationrefundkind.Columns["iditinerationrefundkindgroup"]};
	Relations.Add(new DataRelation("itinerationrefundkindgroupitinerationrefundkind",cPar,cChild,false));

	cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	cChild = new []{itinerationrefundkind.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveapplieditinerationrefundkind",cPar,cChild,false));

	#endregion

}
}
}
