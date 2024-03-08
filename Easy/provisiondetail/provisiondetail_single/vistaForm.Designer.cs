
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
namespace provisiondetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable provisiondetail 		=> Tables["provisiondetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied 		=> Tables["accmotiveapplied"];

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
	//////////////////// PROVISIONDETAIL /////////////////////////////////
	var tprovisiondetail= new DataTable("provisiondetail");
	C= new DataColumn("idprovision", typeof(int));
	C.AllowDBNull=false;
	tprovisiondetail.Columns.Add(C);
	tprovisiondetail.Columns.Add( new DataColumn("description", typeof(string)));
	tprovisiondetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprovisiondetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprovisiondetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprovisiondetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprovisiondetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	tprovisiondetail.Columns.Add(C);
	tprovisiondetail.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tprovisiondetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tprovisiondetail.Columns.Add( new DataColumn("ydetail", typeof(short)));
	Tables.Add(tprovisiondetail);
	tprovisiondetail.PrimaryKey =  new DataColumn[]{tprovisiondetail.Columns["idprovision"], tprovisiondetail.Columns["rownum"]};


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
	taccmotiveapplied.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("flagamm", typeof(string)));
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.PrimaryKey =  new DataColumn[]{taccmotiveapplied.Columns["idaccmotive"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	var cChild = new []{provisiondetail.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotiveapplied_provisiondetail",cPar,cChild,false));

	#endregion

}
}
}
