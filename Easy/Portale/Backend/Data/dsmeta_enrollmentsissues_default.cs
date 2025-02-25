
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
[System.Xml.Serialization.XmlRoot("dsmeta_enrollmentsissues_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_enrollmentsissues_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable issues 		=> (MetaTable)Tables["issues"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable enrollmentsissues 		=> (MetaTable)Tables["enrollmentsissues"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_enrollmentsissues_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_enrollmentsissues_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_enrollmentsissues_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_enrollmentsissues_default.xsd";

	#region create DataTables
	//////////////////// ISSUES /////////////////////////////////
	var tissues= new MetaTable("issues");
	tissues.defineColumn("attribute_name", typeof(string));
	tissues.defineColumn("ct", typeof(DateTime),false);
	tissues.defineColumn("cu", typeof(string),false);
	tissues.defineColumn("idenrollmentsissues", typeof(int),false);
	tissues.defineColumn("idissues", typeof(int),false);
	tissues.defineColumn("issue_description", typeof(string));
	tissues.defineColumn("lt", typeof(DateTime),false);
	tissues.defineColumn("lu", typeof(string),false);
	Tables.Add(tissues);
	tissues.defineKey("idenrollmentsissues", "idissues");

	//////////////////// ENROLLMENTSISSUES /////////////////////////////////
	var tenrollmentsissues= new MetaTable("enrollmentsissues");
	tenrollmentsissues.defineColumn("academic_year", typeof(string));
	tenrollmentsissues.defineColumn("birth_date", typeof(string));
	tenrollmentsissues.defineColumn("birth_place", typeof(string));
	tenrollmentsissues.defineColumn("ct", typeof(DateTime),false);
	tenrollmentsissues.defineColumn("cu", typeof(string),false);
	tenrollmentsissues.defineColumn("data_request", typeof(string));
	tenrollmentsissues.defineColumn("degree_class_code", typeof(string));
	tenrollmentsissues.defineColumn("degree_course_code", typeof(string));
	tenrollmentsissues.defineColumn("degree_course_year", typeof(string));
	tenrollmentsissues.defineColumn("family_name", typeof(string));
	tenrollmentsissues.defineColumn("file_code", typeof(string));
	tenrollmentsissues.defineColumn("file_status", typeof(string));
	tenrollmentsissues.defineColumn("given_name", typeof(string));
	tenrollmentsissues.defineColumn("idenrollmentsissues", typeof(int),false);
	tenrollmentsissues.defineColumn("institute_code", typeof(string));
	tenrollmentsissues.defineColumn("institute_name", typeof(string));
	tenrollmentsissues.defineColumn("lt", typeof(DateTime),false);
	tenrollmentsissues.defineColumn("lu", typeof(string),false);
	tenrollmentsissues.defineColumn("message", typeof(string));
	tenrollmentsissues.defineColumn("person_id", typeof(string));
	tenrollmentsissues.defineColumn("programme_type_code", typeof(string));
	tenrollmentsissues.defineColumn("status", typeof(string));
	tenrollmentsissues.defineColumn("subscriber_id", typeof(string));
	tenrollmentsissues.defineColumn("subscriber_message", typeof(string));
	tenrollmentsissues.defineColumn("subscriber_name", typeof(string));
	tenrollmentsissues.defineColumn("tax_code", typeof(string));
	Tables.Add(tenrollmentsissues);
	tenrollmentsissues.defineKey("idenrollmentsissues");

	#endregion


	#region DataRelation creation
	var cPar = new []{enrollmentsissues.Columns["idenrollmentsissues"]};
	var cChild = new []{issues.Columns["idenrollmentsissues"]};
	Relations.Add(new DataRelation("FK_issues_enrollmentsissues_idenrollmentsissues",cPar,cChild,false));

	#endregion

}
}
}
