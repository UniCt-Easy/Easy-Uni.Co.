
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
namespace placcount_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Conto Economico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable placcount 		=> Tables["placcount"];

	///<summary>
	///Livelli gerarchici Conto Economico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable placcountlevel 		=> Tables["placcountlevel"];

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
	//////////////////// PLACCOUNT /////////////////////////////////
	var tplaccount= new DataTable("placcount");
	C= new DataColumn("idplaccount", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("placcpart", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("codeplaccount", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("paridplaccount", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	tplaccount.Columns.Add( new DataColumn("txt", typeof(string)));
	tplaccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tplaccount.Columns.Add(C);
	tplaccount.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tplaccount);
	tplaccount.PrimaryKey =  new DataColumn[]{tplaccount.Columns["idplaccount"]};


	//////////////////// PLACCOUNTLEVEL /////////////////////////////////
	var tplaccountlevel= new DataTable("placcountlevel");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tplaccountlevel.Columns.Add(C);
	Tables.Add(tplaccountlevel);
	tplaccountlevel.PrimaryKey =  new DataColumn[]{tplaccountlevel.Columns["ayear"], tplaccountlevel.Columns["nlevel"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{placcountlevel.Columns["ayear"], placcountlevel.Columns["nlevel"]};
	var cChild = new []{placcount.Columns["ayear"], placcount.Columns["nlevel"]};
	Relations.Add(new DataRelation("placcountlevelplaccount",cPar,cChild,false));

	cPar = new []{placcount.Columns["idplaccount"]};
	cChild = new []{placcount.Columns["paridplaccount"]};
	Relations.Add(new DataRelation("placcountplaccount",cPar,cChild,false));

	#endregion

}
}
}
