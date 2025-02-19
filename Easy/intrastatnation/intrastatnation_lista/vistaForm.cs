
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
namespace intrastatnation_lista {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Codice ISO nazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatnation 		=> Tables["intrastatnation"];

	///<summary>
	///Valuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable currency 		=> Tables["currency"];

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
	//////////////////// INTRASTATNATION /////////////////////////////////
	var tintrastatnation= new DataTable("intrastatnation");
	C= new DataColumn("idintrastatnation", typeof(string));
	C.AllowDBNull=false;
	tintrastatnation.Columns.Add(C);
	tintrastatnation.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tintrastatnation.Columns.Add( new DataColumn("description", typeof(string)));
	tintrastatnation.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatnation.Columns.Add( new DataColumn("lu", typeof(string)));
	tintrastatnation.Columns.Add( new DataColumn("!valuta", typeof(string)));
	Tables.Add(tintrastatnation);
	tintrastatnation.PrimaryKey =  new DataColumn[]{tintrastatnation.Columns["idintrastatnation"]};


	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new DataTable("currency");
	C= new DataColumn("idcurrency", typeof(int));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	tcurrency.Columns.Add( new DataColumn("codecurrency", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	Tables.Add(tcurrency);
	tcurrency.PrimaryKey =  new DataColumn[]{tcurrency.Columns["idcurrency"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{currency.Columns["idcurrency"]};
	var cChild = new []{intrastatnation.Columns["idcurrency"]};
	Relations.Add(new DataRelation("currency_intrastatnation",cPar,cChild,false));

	#endregion

}
}
}
