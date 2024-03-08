
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace bankdispositionsetup_cbi {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymenttransmission 		=> Tables["paymenttransmission"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bankdispositionsetup 		=> Tables["bankdispositionsetup"];

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
	//////////////////// PAYMENTTRANSMISSION /////////////////////////////////
	var tpaymenttransmission= new DataTable("paymenttransmission");
	C= new DataColumn("npaymenttransmission", typeof(int));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("ypaymenttransmission", typeof(short));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	tpaymenttransmission.Columns.Add( new DataColumn("transmissiondate", typeof(DateTime)));
	tpaymenttransmission.Columns.Add( new DataColumn("idman", typeof(int)));
	tpaymenttransmission.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("kpaymenttransmission", typeof(int));
	C.AllowDBNull=false;
	tpaymenttransmission.Columns.Add(C);
	tpaymenttransmission.Columns.Add( new DataColumn("flagmailsent", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("transmissionkind", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("streamdate", typeof(DateTime)));
	tpaymenttransmission.Columns.Add( new DataColumn("bankdate", typeof(DateTime)));
	tpaymenttransmission.Columns.Add( new DataColumn("flagtransmissionenabled", typeof(string)));
	tpaymenttransmission.Columns.Add( new DataColumn("noep", typeof(string)));
	Tables.Add(tpaymenttransmission);
	tpaymenttransmission.PrimaryKey =  new DataColumn[]{tpaymenttransmission.Columns["kpaymenttransmission"]};


	//////////////////// BANKDISPOSITIONSETUP /////////////////////////////////
	var tbankdispositionsetup= new DataTable("bankdispositionsetup");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tbankdispositionsetup.Columns.Add(C);
	tbankdispositionsetup.Columns.Add( new DataColumn("kpaymenttransmission", typeof(int)));
	tbankdispositionsetup.Columns.Add( new DataColumn("kproceedstransmission", typeof(int)));
	Tables.Add(tbankdispositionsetup);
	tbankdispositionsetup.PrimaryKey =  new DataColumn[]{tbankdispositionsetup.Columns["ayear"]};


	#endregion

}
}
}
