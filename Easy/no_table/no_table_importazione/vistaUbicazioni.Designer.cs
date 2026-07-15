/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("vistaUbicazioni"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaUbicazioni: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable location 		=> Tables["location"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable locationlevel 		=> Tables["locationlevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable division 		=> Tables["division"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaUbicazioni(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaUbicazioni (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaUbicazioni";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaUbicazioni.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// LOCATION /////////////////////////////////
	var tlocation= new DataTable("location");
	tlocation.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("locationcode", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlocation.Columns.Add( new DataColumn("txt", typeof(string)));
	tlocation.Columns.Add( new DataColumn("idman", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	C= new DataColumn("idlocation", typeof(int));
	C.AllowDBNull=false;
	tlocation.Columns.Add(C);
	tlocation.Columns.Add( new DataColumn("paridlocation", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tlocation.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tlocation);
	tlocation.PrimaryKey =  new DataColumn[]{tlocation.Columns["idlocation"]};


	//////////////////// LOCATIONLEVEL /////////////////////////////////
	var tlocationlevel= new DataTable("locationlevel");
	C= new DataColumn("codelen", typeof(byte));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tlocationlevel.Columns.Add(C);
	Tables.Add(tlocationlevel);
	tlocationlevel.PrimaryKey =  new DataColumn[]{tlocationlevel.Columns["nlevel"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// DIVISION /////////////////////////////////
	var tdivision= new DataTable("division");
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("address", typeof(string)));
	tdivision.Columns.Add( new DataColumn("cap", typeof(string)));
	tdivision.Columns.Add( new DataColumn("city", typeof(string)));
	C= new DataColumn("codedivision", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	tdivision.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tdivision.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tdivision);
	tdivision.PrimaryKey =  new DataColumn[]{tdivision.Columns["iddivision"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{division.Columns["iddivision"]};
	var cChild = new []{manager.Columns["iddivision"]};
	Relations.Add(new DataRelation("division_manager",cPar,cChild,false));

	cPar = new []{location.Columns["idlocation"]};
	cChild = new []{location.Columns["paridlocation"]};
	Relations.Add(new DataRelation("location_location",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{location.Columns["idman"]};
	Relations.Add(new DataRelation("manager_location",cPar,cChild,false));

	cPar = new []{locationlevel.Columns["nlevel"]};
	cChild = new []{location.Columns["nlevel"]};
	Relations.Add(new DataRelation("locationlevel_location",cPar,cChild,false));

	#endregion

}
}
}
