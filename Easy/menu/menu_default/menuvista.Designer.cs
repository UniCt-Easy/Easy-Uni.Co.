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
namespace menu_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Gestione del Menu
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable menu 		=> Tables["menu"];

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
	//////////////////// MENU /////////////////////////////////
	var tmenu= new DataTable("menu");
	C= new DataColumn("idmenu", typeof(int));
	C.AllowDBNull=false;
	tmenu.Columns.Add(C);
	tmenu.Columns.Add( new DataColumn("paridmenu", typeof(int)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmenu.Columns.Add(C);
	tmenu.Columns.Add( new DataColumn("ordernumber", typeof(int)));
	tmenu.Columns.Add( new DataColumn("metadata", typeof(string)));
	tmenu.Columns.Add( new DataColumn("edittype", typeof(string)));
	tmenu.Columns.Add( new DataColumn("modal", typeof(string)));
	tmenu.Columns.Add( new DataColumn("parameter", typeof(string)));
	tmenu.Columns.Add( new DataColumn("menucode", typeof(string)));
	tmenu.Columns.Add( new DataColumn("userid", typeof(string)));
	tmenu.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tmenu.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tmenu);
	tmenu.PrimaryKey =  new DataColumn[]{tmenu.Columns["idmenu"]};


	#endregion

}
}
}
