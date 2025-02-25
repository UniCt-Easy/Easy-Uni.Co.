
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_academicenrollmentchangerequest_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_academicenrollmentchangerequest_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable academicenrollmentchangerequest 		=> (MetaTable)Tables["academicenrollmentchangerequest"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_academicenrollmentchangerequest_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_academicenrollmentchangerequest_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_academicenrollmentchangerequest_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_academicenrollmentchangerequest_default.xsd";

	#region create DataTables
	//////////////////// ACADEMICENROLLMENTCHANGEREQUEST /////////////////////////////////
	var tacademicenrollmentchangerequest= new MetaTable("academicenrollmentchangerequest");
	tacademicenrollmentchangerequest.defineColumn("course_type_current", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("course_type_suggested", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("course_year_current", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("course_year_suggested", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("ct", typeof(DateTime),false);
	tacademicenrollmentchangerequest.defineColumn("cu", typeof(string),false);
	tacademicenrollmentchangerequest.defineColumn("degree_course_code", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("enrollment_year_current", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("enrollment_year_suggested", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("file_code", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("file_status", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("guid_file_code", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("idacademicenrollmentchangerequest", typeof(int),false);
	tacademicenrollmentchangerequest.defineColumn("institute_name_current", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("institute_name_suggested", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("lt", typeof(DateTime),false);
	tacademicenrollmentchangerequest.defineColumn("lu", typeof(string),false);
	tacademicenrollmentchangerequest.defineColumn("message", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("note", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("person_id", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("reason", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("request", typeof(string));
	tacademicenrollmentchangerequest.defineColumn("tax_code", typeof(string));
	Tables.Add(tacademicenrollmentchangerequest);
	tacademicenrollmentchangerequest.defineKey("idacademicenrollmentchangerequest");

	#endregion

}
}
}
