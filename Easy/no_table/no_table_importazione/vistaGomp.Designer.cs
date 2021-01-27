
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("vistaGomp"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaGomp: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione lookup gomp
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_gomp 		=> Tables["stip_gomp"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaGomp(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaGomp (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaGomp";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaGomp.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// STIP_GOMP /////////////////////////////////
	var tstip_gomp= new DataTable("stip_gomp");
	C= new DataColumn("idstip_gomp", typeof(int));
	C.AllowDBNull=false;
	tstip_gomp.Columns.Add(C);
	C= new DataColumn("codicecausale", typeof(string));
	C.AllowDBNull=false;
	tstip_gomp.Columns.Add(C);
	C= new DataColumn("annoregolamento", typeof(int));
	C.AllowDBNull=false;
	tstip_gomp.Columns.Add(C);
	C= new DataColumn("fuoricorso", typeof(string));
	C.AllowDBNull=false;
	tstip_gomp.Columns.Add(C);
	tstip_gomp.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tstip_gomp.Columns.Add( new DataColumn("cu", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tstip_gomp.Columns.Add( new DataColumn("lu", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idaccmotiverevenue", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idaccmotiveundotax", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idaccmotiveundotaxpost", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("tipologiacorso", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idaccmotivecost", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_gomp.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	Tables.Add(tstip_gomp);
	tstip_gomp.PrimaryKey =  new DataColumn[]{tstip_gomp.Columns["idstip_gomp"]};


	#endregion

}
}
}
