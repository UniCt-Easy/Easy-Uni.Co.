
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
namespace progettoricavo_functions {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable progettoricavo 		=> Tables["progettoricavo"];

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
	//////////////////// PROGETTORICAVO /////////////////////////////////
	var tprogettoricavo= new DataTable("progettoricavo");
	C= new DataColumn("idprogettoricavo", typeof(int));
	C.AllowDBNull=false;
	tprogettoricavo.Columns.Add(C);
	C= new DataColumn("idprogetto", typeof(int));
	C.AllowDBNull=false;
	tprogettoricavo.Columns.Add(C);
	tprogettoricavo.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tprogettoricavo.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tprogettoricavo.Columns.Add(C);
	tprogettoricavo.Columns.Add( new DataColumn("doc", typeof(string)));
	tprogettoricavo.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tprogettoricavo.Columns.Add( new DataColumn("idcontrattokind", typeof(int)));
	tprogettoricavo.Columns.Add( new DataColumn("idinc", typeof(int)));
	tprogettoricavo.Columns.Add( new DataColumn("idprogettotipocosto", typeof(int)));
	tprogettoricavo.Columns.Add( new DataColumn("idrelated", typeof(string)));
	tprogettoricavo.Columns.Add( new DataColumn("idrendicontattivitaprogetto", typeof(int)));
	tprogettoricavo.Columns.Add( new DataColumn("idsal", typeof(int)));
	tprogettoricavo.Columns.Add( new DataColumn("idworkpackage", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tprogettoricavo.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tprogettoricavo.Columns.Add(C);
	Tables.Add(tprogettoricavo);
	tprogettoricavo.PrimaryKey =  new DataColumn[]{tprogettoricavo.Columns["idprogettoricavo"], tprogettoricavo.Columns["idprogetto"]};


	#endregion

}
}
}
