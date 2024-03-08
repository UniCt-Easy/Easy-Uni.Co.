
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
namespace notable_importazione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaStipDecodifica"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaStipDecodifica: DataSet {

	#region Table members declaration
	///<summary>
	///decodifica vocie e tasse prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_decodifica 		=> Tables["stip_decodifica"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaStipDecodifica(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaStipDecodifica (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaStipDecodifica";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaStipDecodifica.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// STIP_DECODIFICA /////////////////////////////////
	var tstip_decodifica= new DataTable("stip_decodifica");
	C= new DataColumn("idstiptassa", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	C= new DataColumn("idstipvoce", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiverevenue", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiveundotax", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiveundotaxpost", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("cu", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("lu", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idstipcorsolaurea", typeof(int)));
	C= new DataColumn("idstipdecodifica", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	Tables.Add(tstip_decodifica);
	tstip_decodifica.PrimaryKey =  new DataColumn[]{tstip_decodifica.Columns["idstipdecodifica"]};


	#endregion

}
}
}
