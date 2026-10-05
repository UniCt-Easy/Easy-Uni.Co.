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
namespace no_table_iban {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypaymethod 		=> Tables["registrypaymethod"];

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
	C= new DataColumn("idnotable", typeof(int));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	Tables.Add(tno_table);
	tno_table.PrimaryKey =  new DataColumn[]{tno_table.Columns["idnotable"]};


	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new DataTable("registrypaymethod");
	C= new DataColumn("regmodcode", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("cin", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idbank", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcab", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("flagstandard", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("iban", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("extracode", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("biccode", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("flag", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("notes", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("ccdedicato_doc", typeof(Byte[])));
	tregistrypaymethod.Columns.Add( new DataColumn("ccdedicato_cf", typeof(Byte[])));
	tregistrypaymethod.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("ccdedicato_stop", typeof(DateTime)));
	tregistrypaymethod.Columns.Add( new DataColumn("idfilestorage", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idfilestorage2", typeof(string)));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.PrimaryKey =  new DataColumn[]{tregistrypaymethod.Columns["idreg"], tregistrypaymethod.Columns["idregistrypaymethod"]};


	#endregion

}
}
}
