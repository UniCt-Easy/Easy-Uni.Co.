
/*
Easy
Copyright (C) 2024 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace paymethod_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Modalit√† di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymethod 		=> Tables["paymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable abi_label_lookup 		=> Tables["abi_label_lookup"];

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
	EnforceConstraints = false;

	#region create DataTables
	DataColumn C;
	//////////////////// PAYMETHOD /////////////////////////////////
	var tpaymethod= new DataTable("paymethod");
	C= new DataColumn("idpaymethod", typeof(int));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	tpaymethod.Columns.Add( new DataColumn("methodbankcode", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("allowdeputy", typeof(string)));
	C= new DataColumn("flag", typeof(int));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	tpaymethod.Columns.Add( new DataColumn("footerpaymentadvice", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("committeeamount", typeof(decimal)));
	tpaymethod.Columns.Add( new DataColumn("committeecode", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("minamount", typeof(decimal)));
	tpaymethod.Columns.Add( new DataColumn("maxamount", typeof(decimal)));
	tpaymethod.Columns.Add( new DataColumn("abi_label", typeof(string)));
	Tables.Add(tpaymethod);
	tpaymethod.PrimaryKey =  new DataColumn[]{tpaymethod.Columns["idpaymethod"]};


	//////////////////// ABI_LABEL_LOOKUP /////////////////////////////////
	var tabi_label_lookup= new DataTable("abi_label_lookup");
	C= new DataColumn("abi_label", typeof(string));
	C.AllowDBNull=false;
	tabi_label_lookup.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tabi_label_lookup.Columns.Add(C);
	tabi_label_lookup.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tabi_label_lookup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tabi_label_lookup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tabi_label_lookup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tabi_label_lookup.Columns.Add(C);
	Tables.Add(tabi_label_lookup);
	tabi_label_lookup.PrimaryKey =  new DataColumn[]{tabi_label_lookup.Columns["abi_label"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{abi_label_lookup.Columns["abi_label"]};
	var cChild = new []{paymethod.Columns["abi_label"]};
	Relations.Add(new DataRelation("abi_label_lookup_paymethod",cPar,cChild,false));

	#endregion

}
}
}
