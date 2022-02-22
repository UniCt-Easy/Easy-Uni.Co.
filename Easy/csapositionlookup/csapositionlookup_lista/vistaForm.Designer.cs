
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
namespace csapositionlookup_lista {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Look-Up Qualifiche
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csapositionlookup 		=> Tables["csapositionlookup"];

	///<summary>
	///Qualifica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable position 		=> Tables["position"];

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
	//////////////////// CSAPOSITIONLOOKUP /////////////////////////////////
	var tcsapositionlookup= new DataTable("csapositionlookup");
	C= new DataColumn("idcsaposition", typeof(int));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	tcsapositionlookup.Columns.Add( new DataColumn("csa_class", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("csa_role", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("idposition", typeof(int)));
	tcsapositionlookup.Columns.Add( new DataColumn("supposedtaxable", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	tcsapositionlookup.Columns.Add( new DataColumn("!description", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("!codeposition", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("csa_description", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("csa_compartment", typeof(string)));
	Tables.Add(tcsapositionlookup);
	tcsapositionlookup.PrimaryKey =  new DataColumn[]{tcsapositionlookup.Columns["idcsaposition"]};


	//////////////////// POSITION /////////////////////////////////
	var tposition= new DataTable("position");
	tposition.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("maxincomeclass", typeof(short)));
	C= new DataColumn("codeposition", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{position.Columns["idposition"]};
	var cChild = new []{csapositionlookup.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_position_csapositionlookup",cPar,cChild,false));

	#endregion

}
}
}
