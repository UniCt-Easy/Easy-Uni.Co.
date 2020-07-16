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

namespace serviceregistrykind_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class VistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable serviceregistrykind{get { return Tables["serviceregistrykind"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public VistaForm(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "VistaForm";
Prefix = "";
Namespace = "http://tempuri.org/VistaForm.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("serviceregistrykind");
	C= new DataColumn("idserviceregistrykind", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("title", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("totransmit", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("topublish", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("active", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("flagconferringstructure", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagordinancelink", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagauthorizingstructure", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagauthorizinglink", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagactreference", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagannouncementlink", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagotherservice", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagprofessionalservice", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagcomponentsvariable", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("flagcvattachment", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("employkind", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagemploytime", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("otherservice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("professionalservice", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("componentsvariable", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagcertinterestconflicts", typeof(System.Int16), ""));
	T.Columns.Add(new DataColumn("certinterestconflicts", typeof(System.String), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["idserviceregistrykind"]};
	T.PrimaryKey = key;

}
}
}
