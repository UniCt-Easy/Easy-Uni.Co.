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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace mandateattachment_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Allegato a  c.passivo
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable mandateattachment		{get { return Tables["mandateattachment"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable attachmentkind		{get { return Tables["attachmentkind"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// MANDATEATTACHMENT /////////////////////////////////
	T= new DataTable("mandateattachment");
	C= new DataColumn("idmankind", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("yman", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("nman", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	T.Columns.Add( new DataColumn("filename", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idattachmentkind", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idmankind"], T.Columns["yman"], T.Columns["nman"], T.Columns["idattachment"]};


	//////////////////// ATTACHMENTKIND /////////////////////////////////
	T= new DataTable("attachmentkind");
	C= new DataColumn("idattachmentkind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idattachmentkind"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{attachmentkind.Columns["idattachmentkind"]};
	CChild = new DataColumn[1]{mandateattachment.Columns["idattachmentkind"]};
	Relations.Add(new DataRelation("attachmentkind_mandateattachment",CPar,CChild,false));

	#endregion

}
}
}
