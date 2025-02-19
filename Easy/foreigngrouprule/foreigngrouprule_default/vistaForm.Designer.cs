
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
namespace foreigngrouprule_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable foreigngrouprule 		=> Tables["foreigngrouprule"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable foreigngroupruledetail 		=> Tables["foreigngroupruledetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable position 		=> Tables["position"];

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
	//////////////////// FOREIGNGROUPRULE /////////////////////////////////
	var tforeigngrouprule= new DataTable("foreigngrouprule");
	C= new DataColumn("idforeigngrouprule", typeof(int));
	C.AllowDBNull=false;
	tforeigngrouprule.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigngrouprule.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigngrouprule.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tforeigngrouprule.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigngrouprule.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tforeigngrouprule.Columns.Add(C);
	Tables.Add(tforeigngrouprule);
	tforeigngrouprule.PrimaryKey =  new DataColumn[]{tforeigngrouprule.Columns["idforeigngrouprule"]};


	//////////////////// FOREIGNGROUPRULEDETAIL /////////////////////////////////
	var tforeigngroupruledetail= new DataTable("foreigngroupruledetail");
	C= new DataColumn("idforeigngrouprule", typeof(int));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	tforeigngroupruledetail.Columns.Add( new DataColumn("!position", typeof(string)));
	C= new DataColumn("minincomeclass", typeof(int));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("maxincomeclass", typeof(int));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("foreigngroupnumber", typeof(short));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tforeigngroupruledetail.Columns.Add(C);
	tforeigngroupruledetail.Columns.Add( new DataColumn("livello", typeof(int)));
	Tables.Add(tforeigngroupruledetail);
	tforeigngroupruledetail.PrimaryKey =  new DataColumn[]{tforeigngroupruledetail.Columns["idforeigngrouprule"], tforeigngroupruledetail.Columns["iddetail"]};


	//////////////////// POSITION /////////////////////////////////
	var tposition= new DataTable("position");
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("maxincomeclass", typeof(short)));
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{position.Columns["idposition"]};
	var cChild = new []{foreigngroupruledetail.Columns["idposition"]};
	Relations.Add(new DataRelation("position_foreigngroupruledetail",cPar,cChild,false));

	cPar = new []{foreigngrouprule.Columns["idforeigngrouprule"]};
	cChild = new []{foreigngroupruledetail.Columns["idforeigngrouprule"]};
	Relations.Add(new DataRelation("foreigngrouprule_foreigngroupruledetail",cPar,cChild,false));

	#endregion

}
}
}
