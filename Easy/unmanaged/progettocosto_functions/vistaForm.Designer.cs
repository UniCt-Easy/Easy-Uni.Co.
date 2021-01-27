
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
namespace progettocosto_functions {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable progettocosto 		=> Tables["progettocosto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetdiaryora 		=> Tables["assetdiaryora"];

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
	//////////////////// PROGETTOCOSTO /////////////////////////////////
	var tprogettocosto= new DataTable("progettocosto");
	C= new DataColumn("idprogettocosto", typeof(int));
	C.AllowDBNull=false;
	tprogettocosto.Columns.Add(C);
	C= new DataColumn("idprogetto", typeof(int));
	C.AllowDBNull=false;
	tprogettocosto.Columns.Add(C);
	tprogettocosto.Columns.Add( new DataColumn("idworkpackage", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("idprogettotipocosto", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprogettocosto.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprogettocosto.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprogettocosto.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprogettocosto.Columns.Add(C);
	tprogettocosto.Columns.Add( new DataColumn("idsal", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("idexp", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("doc", typeof(string)));
	tprogettocosto.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tprogettocosto.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tprogettocosto.Columns.Add( new DataColumn("idpettycash", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("noperation", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("yoperation", typeof(short)));
	tprogettocosto.Columns.Add( new DataColumn("idcontrattokind", typeof(int)));
	tprogettocosto.Columns.Add( new DataColumn("idrendicontattivitaprogetto", typeof(int)));
	Tables.Add(tprogettocosto);
	tprogettocosto.PrimaryKey =  new DataColumn[]{tprogettocosto.Columns["idprogettocosto"], tprogettocosto.Columns["idprogetto"]};


	//////////////////// ASSETDIARYORA /////////////////////////////////
	var tassetdiaryora= new DataTable("assetdiaryora");
	C= new DataColumn("idassetdiaryora", typeof(int));
	C.AllowDBNull=false;
	tassetdiaryora.Columns.Add(C);
	C= new DataColumn("idassetdiary", typeof(int));
	C.AllowDBNull=false;
	tassetdiaryora.Columns.Add(C);
	tassetdiaryora.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tassetdiaryora.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tassetdiaryora.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tassetdiaryora.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tassetdiaryora.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tassetdiaryora.Columns.Add(C);
	tassetdiaryora.Columns.Add( new DataColumn("amount", typeof(decimal)));
	Tables.Add(tassetdiaryora);
	tassetdiaryora.PrimaryKey =  new DataColumn[]{tassetdiaryora.Columns["idassetdiaryora"], tassetdiaryora.Columns["idassetdiary"]};


	#endregion

}
}
}
