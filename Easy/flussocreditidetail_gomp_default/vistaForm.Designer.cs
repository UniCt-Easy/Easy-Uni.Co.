
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace flussocreditidetail_gomp_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussocreditidetail_gomp 		=> Tables["flussocreditidetail_gomp"];

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
	//////////////////// FLUSSOCREDITIDETAIL_GOMP /////////////////////////////////
	var tflussocreditidetail_gomp= new DataTable("flussocreditidetail_gomp");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("annoregolamento", typeof(int)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("cf", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("codicecausale", typeof(string)));
	C= new DataColumn("codicecorsolaurea", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	C= new DataColumn("codicedipartimento", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	C= new DataColumn("codicesede", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("email", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("forename", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("fuoricorso", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("importoversamento", typeof(decimal)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("iuv", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflussocreditidetail_gomp.Columns.Add(C);
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("surname", typeof(string)));
	tflussocreditidetail_gomp.Columns.Add( new DataColumn("tipologiacorso", typeof(string)));
	Tables.Add(tflussocreditidetail_gomp);
	tflussocreditidetail_gomp.PrimaryKey =  new DataColumn[]{tflussocreditidetail_gomp.Columns["idflusso"], tflussocreditidetail_gomp.Columns["iddetail"]};


	#endregion

}
}
}
