
/*
Easy
Copyright (C) 2023 Universita' degli Studi di Catania (www.unict.it)
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
namespace EasyPagamentiDataSet {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("Dipartimenti"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class Dipartimenti: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable CodiciDipartimenti 		=> Tables["CodiciDipartimenti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public Dipartimenti(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected Dipartimenti (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "Dipartimenti";
	Prefix = "";
	Namespace = "http://tempuri.org/Dipartimenti.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// CODICIDIPARTIMENTI /////////////////////////////////
	var tCodiciDipartimenti= new DataTable("CodiciDipartimenti");
	C= new DataColumn("CodiceDipartimento", typeof(string));
	C.AllowDBNull=false;
	tCodiciDipartimenti.Columns.Add(C);
	C= new DataColumn("Dipartimento", typeof(string));
	C.AllowDBNull=false;
	tCodiciDipartimenti.Columns.Add(C);
	tCodiciDipartimenti.Columns.Add( new DataColumn("IPServer", typeof(Byte[])));
	tCodiciDipartimenti.Columns.Add( new DataColumn("NomeDB", typeof(Byte[])));
	tCodiciDipartimenti.Columns.Add( new DataColumn("UserDB", typeof(Byte[])));
	tCodiciDipartimenti.Columns.Add( new DataColumn("PassDB", typeof(Byte[])));
	tCodiciDipartimenti.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tCodiciDipartimenti.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tCodiciDipartimenti);
	tCodiciDipartimenti.PrimaryKey =  new DataColumn[]{tCodiciDipartimenti.Columns["CodiceDipartimento"]};


	#endregion

}
}
}
