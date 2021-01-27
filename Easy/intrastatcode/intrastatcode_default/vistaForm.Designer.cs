
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace intrastatcode_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Nomenclatura combinata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatcode 		=> Tables["intrastatcode"];

	///<summary>
	///Unit√† di misura supplementare
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatmeasure 		=> Tables["intrastatmeasure"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatcodeview 		=> Tables["intrastatcodeview"];

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
	//////////////////// INTRASTATCODE /////////////////////////////////
	var tintrastatcode= new DataTable("intrastatcode");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	tintrastatcode.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tintrastatcode.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatcode.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idintrastatcode", typeof(int));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	Tables.Add(tintrastatcode);
	tintrastatcode.PrimaryKey =  new DataColumn[]{tintrastatcode.Columns["idintrastatcode"]};


	//////////////////// INTRASTATMEASURE /////////////////////////////////
	var tintrastatmeasure= new DataTable("intrastatmeasure");
	C= new DataColumn("idintrastatmeasure", typeof(int));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	tintrastatmeasure.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatmeasure.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tintrastatmeasure);
	tintrastatmeasure.PrimaryKey =  new DataColumn[]{tintrastatmeasure.Columns["idintrastatmeasure"]};


	//////////////////// INTRASTATCODEVIEW /////////////////////////////////
	var tintrastatcodeview= new DataTable("intrastatcodeview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	C= new DataColumn("idintrastatcode", typeof(int));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	tintrastatcodeview.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tintrastatcodeview.Columns.Add( new DataColumn("measurecode", typeof(string)));
	tintrastatcodeview.Columns.Add( new DataColumn("measuredescription", typeof(string)));
	tintrastatcodeview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatcodeview.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tintrastatcodeview);
	tintrastatcodeview.PrimaryKey =  new DataColumn[]{tintrastatcodeview.Columns["idintrastatcode"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{intrastatmeasure.Columns["idintrastatmeasure"]};
	var cChild = new []{intrastatcode.Columns["idintrastatmeasure"]};
	Relations.Add(new DataRelation("intrastatmeasure_intrastatcode",cPar,cChild,false));

	#endregion

}
}
}
