/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace no_table_fin_mef_afam {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind_c 		=> Tables["sortingkind_c"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingkind_p 		=> Tables["sortingkind_p"];

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
	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new DataTable("no_table");
	tno_table.Columns.Add( new DataColumn("id_no_table", typeof(int)));
	Tables.Add(tno_table);

	//////////////////// SORTINGKIND_C /////////////////////////////////
	var tsortingkind_c= new DataTable("sortingkind_c");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	tsortingkind_c.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	tsortingkind_c.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	tsortingkind_c.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_c.Columns.Add(C);
	tsortingkind_c.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind_c.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind_c.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind_c.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind_c.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("allowedS1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("allowedS2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("allowedS3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("allowedS4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("allowedS5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedD1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedD2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedD3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedD4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("forcedD5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelD1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelD2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelD3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelD4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("labelD5", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedD1", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedD2", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedD3", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedD4", typeof(string)));
	tsortingkind_c.Columns.Add( new DataColumn("lockedD5", typeof(string)));
	Tables.Add(tsortingkind_c);
	tsortingkind_c.PrimaryKey =  new DataColumn[]{tsortingkind_c.Columns["idsorkind"]};


	//////////////////// SORTINGKIND_P /////////////////////////////////
	var tsortingkind_p= new DataTable("sortingkind_p");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	tsortingkind_p.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	tsortingkind_p.Columns.Add( new DataColumn("flagdate", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedN1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedN2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedN3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedN4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedN5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedS1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedS2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedS3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedS4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedS5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedv1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedv2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedv3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedv4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedv5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("idparentkind", typeof(int)));
	tsortingkind_p.Columns.Add( new DataColumn("labelfordate", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labeln1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labeln2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labeln3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labeln4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labeln5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labels1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labels2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labels3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labels4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labels5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelv1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelv2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelv3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelv4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelv5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedN1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedN2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedN3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedN4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedN5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedS1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedS2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedS3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedS4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedS5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedv1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedv2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedv3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedv4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedv5", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingkind_p.Columns.Add(C);
	tsortingkind_p.Columns.Add( new DataColumn("nodatelabel", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("nphaseexpense", typeof(byte)));
	tsortingkind_p.Columns.Add( new DataColumn("nphaseincome", typeof(byte)));
	tsortingkind_p.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingkind_p.Columns.Add( new DataColumn("stop", typeof(short)));
	tsortingkind_p.Columns.Add( new DataColumn("totalexpression", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("allowedS1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("allowedS2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("allowedS3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("allowedS4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("allowedS5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedD1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedD2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedD3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedD4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("forcedD5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelD1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelD2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelD3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelD4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("labelD5", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedD1", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedD2", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedD3", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedD4", typeof(string)));
	tsortingkind_p.Columns.Add( new DataColumn("lockedD5", typeof(string)));
	Tables.Add(tsortingkind_p);
	tsortingkind_p.PrimaryKey =  new DataColumn[]{tsortingkind_p.Columns["idsorkind"]};


	#endregion

}
}
}
