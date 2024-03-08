
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
namespace pccdebitstatusdetail_detail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pccdebitstatusdetail 		=> Tables["pccdebitstatusdetail"];

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
	//////////////////// PCCDEBITSTATUSDETAIL /////////////////////////////////
	var tpccdebitstatusdetail= new DataTable("pccdebitstatusdetail");
	C= new DataColumn("idpccdebitstatusdetail", typeof(int));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("yinv", typeof(short));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("ninv", typeof(int));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	tpccdebitstatusdetail.Columns.Add( new DataColumn("idpcc", typeof(int)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("importononcommerciale", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_sosp_contenzioso", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_sosp_contenzioso", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("start_sosp_contenzioso", typeof(DateTime)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_sosp_contestazione", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_sosp_contestazione", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("start_sosp_contestazione", typeof(DateTime)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_sosp_regolareverifica", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_sosp_regolareverifica", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("start_sosp_regolareverifica", typeof(DateTime)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("imp_nonliquidabile", typeof(decimal)));
	tpccdebitstatusdetail.Columns.Add( new DataColumn("iva_nonliquidabile", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpccdebitstatusdetail.Columns.Add(C);
	Tables.Add(tpccdebitstatusdetail);
	tpccdebitstatusdetail.PrimaryKey =  new DataColumn[]{tpccdebitstatusdetail.Columns["idpccdebitstatusdetail"], tpccdebitstatusdetail.Columns["idinvkind"], tpccdebitstatusdetail.Columns["yinv"], tpccdebitstatusdetail.Columns["ninv"]};


	#endregion

}
}
}
