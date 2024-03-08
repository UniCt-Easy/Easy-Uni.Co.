
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_registrycvattachment_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_registrycvattachment_default: DataSet {

	#region Table members declaration
	///<summary>
	///CV
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycvattachment 		=> (MetaTable)Tables["registrycvattachment"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach_cv 		=> (MetaTable)Tables["attach_cv"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrycvattachment_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrycvattachment_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrycvattachment_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrycvattachment_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYCVATTACHMENT /////////////////////////////////
	var tregistrycvattachment= new MetaTable("registrycvattachment");
	tregistrycvattachment.defineColumn("idreg", typeof(int),false);
	tregistrycvattachment.defineColumn("idregistrycvattachment", typeof(int),false);
	tregistrycvattachment.defineColumn("attachment", typeof(Byte[]));
	tregistrycvattachment.defineColumn("ct", typeof(DateTime),false);
	tregistrycvattachment.defineColumn("cu", typeof(string),false);
	tregistrycvattachment.defineColumn("filename", typeof(string));
	tregistrycvattachment.defineColumn("lt", typeof(DateTime),false);
	tregistrycvattachment.defineColumn("lu", typeof(string),false);
	tregistrycvattachment.defineColumn("referencedate", typeof(DateTime));
	tregistrycvattachment.defineColumn("!attachment", typeof(int));
	Tables.Add(tregistrycvattachment);
	tregistrycvattachment.defineKey("idreg", "idregistrycvattachment");

	//////////////////// ATTACH_CV /////////////////////////////////
	var tattach_cv= new MetaTable("attach_cv");
	tattach_cv.defineColumn("attachment", typeof(string),false);
	tattach_cv.defineColumn("ct", typeof(DateTime),false);
	tattach_cv.defineColumn("cu", typeof(string),false);
	tattach_cv.defineColumn("filename", typeof(string),false);
	tattach_cv.defineColumn("hash", typeof(string),false);
	tattach_cv.defineColumn("idattach", typeof(int),false);
	tattach_cv.defineColumn("lt", typeof(DateTime),false);
	tattach_cv.defineColumn("lu", typeof(string),false);
	tattach_cv.defineColumn("size", typeof(int),false);
	Tables.Add(tattach_cv);
	tattach_cv.defineKey("idattach");

	#endregion


	#region DataRelation creation
	var cPar = new []{attach_cv.Columns["idattach"]};
	var cChild = new []{registrycvattachment.Columns["!attachment"]};
	Relations.Add(new DataRelation("attach_cv_registrycvattachment",cPar,cChild,false));

	#endregion

}
}
}
