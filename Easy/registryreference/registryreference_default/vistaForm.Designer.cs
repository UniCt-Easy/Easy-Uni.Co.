
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
namespace registryreference_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Contatto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryreference 		=> Tables["registryreference"];

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
	//////////////////// REGISTRYREFERENCE /////////////////////////////////
	var tregistryreference= new DataTable("registryreference");
	C= new DataColumn("referencename", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("registryreferencerole", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("mobilenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("email", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("userweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("flagdefault", typeof(string)));
	C= new DataColumn("idregistryreference", typeof(int));
	C.AllowDBNull=false;
	tregistryreference.Columns.Add(C);
	tregistryreference.Columns.Add( new DataColumn("skypenumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("msnnumber", typeof(string)));
	tregistryreference.Columns.Add( new DataColumn("pec", typeof(string)));
	Tables.Add(tregistryreference);
	tregistryreference.PrimaryKey =  new DataColumn[]{tregistryreference.Columns["idreg"], tregistryreference.Columns["idregistryreference"]};


	#endregion

}
}
}
