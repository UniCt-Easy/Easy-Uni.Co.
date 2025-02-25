
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace taxpay_ritenutedapagare {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpay 		=> Tables["taxpay"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxsetup 		=> Tables["taxsetup"];

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
	//////////////////// TAXPAY /////////////////////////////////
	var ttaxpay= new DataTable("taxpay");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("ytaxpay", typeof(short));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("ntaxpay", typeof(int));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	ttaxpay.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	ttaxpay.Columns.Add( new DataColumn("txt", typeof(string)));
	ttaxpay.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	Tables.Add(ttaxpay);
	ttaxpay.PrimaryKey =  new DataColumn[]{ttaxpay.Columns["taxcode"], ttaxpay.Columns["ytaxpay"], ttaxpay.Columns["ntaxpay"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXSETUP /////////////////////////////////
	var ttaxsetup= new DataTable("taxsetup");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	ttaxsetup.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idfinexpensecontra", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idfinincomecontra", typeof(int)));
	C= new DataColumn("flagadminfinance", typeof(string));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	ttaxsetup.Columns.Add( new DataColumn("idfinadmintax", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	ttaxsetup.Columns.Add( new DataColumn("expiringday", typeof(short)));
	ttaxsetup.Columns.Add( new DataColumn("txt", typeof(string)));
	ttaxsetup.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	ttaxsetup.Columns.Add( new DataColumn("flag", typeof(byte)));
	Tables.Add(ttaxsetup);
	ttaxsetup.PrimaryKey =  new DataColumn[]{ttaxsetup.Columns["taxcode"], ttaxsetup.Columns["ayear"]};


	#endregion

}
}
}
