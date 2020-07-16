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
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaProfiloSISEST")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaProfiloSISEST: DataSet {

	#region Table members declaration
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sisest_profilo		{get { return Tables["sisest_profilo"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaProfiloSISEST(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaProfiloSISEST (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaProfiloSISEST";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaProfiloSISEST.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// SISEST_PROFILO /////////////////////////////////
	T= new DataTable("sisest_profilo");
	C= new DataColumn("idprofilo", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codiceprofilo", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("annoaccademico", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("descrizione", typeof(String)));
	C= new DataColumn("importo_rata", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("importo_bollo", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("importo_regionale", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("importo_bollettino", typeof(Decimal));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ayear", typeof(Int16)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idprofilo"]};


	#endregion

}
}
}
