/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("vistaEntiCsa"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaEntiCsa: DataSet {

	#region Table members declaration
	///<summary>
	///Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agency 		=> Tables["csa_agency"];

	///<summary>
	///Modalità pagamento Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agencypaymethod 		=> Tables["csa_agencypaymethod"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaEntiCsa(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaEntiCsa (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaEntiCsa";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaEntiCsa.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// CSA_AGENCY /////////////////////////////////
	var tcsa_agency= new DataTable("csa_agency");
	C= new DataColumn("idcsa_agency", typeof(int));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("ente", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("isinternal", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	tcsa_agency.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(tcsa_agency);
	tcsa_agency.PrimaryKey =  new DataColumn[]{tcsa_agency.Columns["idcsa_agency"]};


	//////////////////// CSA_AGENCYPAYMETHOD /////////////////////////////////
	var tcsa_agencypaymethod= new DataTable("csa_agencypaymethod");
	C= new DataColumn("idcsa_agency", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("idcsa_agencypaymethod", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	tcsa_agencypaymethod.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	Tables.Add(tcsa_agencypaymethod);
	tcsa_agencypaymethod.PrimaryKey =  new DataColumn[]{tcsa_agencypaymethod.Columns["idcsa_agency"], tcsa_agencypaymethod.Columns["idcsa_agencypaymethod"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{csa_agency.Columns["idcsa_agency"]};
	var cChild = new []{csa_agencypaymethod.Columns["idcsa_agency"]};
	Relations.Add(new DataRelation("csa_agency_csa_agencypaymethod",cPar,cChild,false));

	#endregion

}
}
}
