
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
namespace transparencysent_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable transparencysent 		=> Tables["transparencysent"];

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
	//////////////////// TRANSPARENCYSENT /////////////////////////////////
	var ttransparencysent= new DataTable("transparencysent");
	ttransparencysent.Columns.Add( new DataColumn("identificativo_servizio", typeof(string)));
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttransparencysent.Columns.Add(C);
	C= new DataColumn("idsent", typeof(int));
	C.AllowDBNull=false;
	ttransparencysent.Columns.Add(C);
	ttransparencysent.Columns.Add( new DataColumn("idexp", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("description", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("sortcode_siope", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("description_siope", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("idreg", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("cf_foreigncf", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("p_iva", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("ragione_sociale", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("importo_pagato", typeof(decimal)));
	ttransparencysent.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("idsor05", typeof(int)));
	ttransparencysent.Columns.Add( new DataColumn("dipartimento", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("data_transazione", typeof(DateTime)));
	ttransparencysent.Columns.Add( new DataColumn("flagtransmissionstatus", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("active", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("ambito_temporale", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("tipologia_spesa", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	ttransparencysent.Columns.Add( new DataColumn("cu", typeof(string)));
	ttransparencysent.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	ttransparencysent.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(ttransparencysent);
	ttransparencysent.PrimaryKey =  new DataColumn[]{ttransparencysent.Columns["ayear"], ttransparencysent.Columns["idsent"]};


	#endregion

}
}
}
