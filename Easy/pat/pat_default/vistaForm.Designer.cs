
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
namespace pat_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pat 		=> Tables["pat"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24sediinail 		=> Tables["f24sediinail"];

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
	//////////////////// PAT /////////////////////////////////
	var tpat= new DataTable("pat");
	C= new DataColumn("idpat", typeof(int));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	C= new DataColumn("patcode", typeof(string));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpat.Columns.Add(C);
	tpat.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("active", typeof(string)));
	tpat.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpat.Columns.Add( new DataColumn("cu", typeof(string)));
	tpat.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("lu", typeof(string)));
	tpat.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tpat.Columns.Add( new DataColumn("cc", typeof(string)));
	tpat.Columns.Add( new DataColumn("codicesede", typeof(string)));
	Tables.Add(tpat);
	tpat.PrimaryKey =  new DataColumn[]{tpat.Columns["idpat"]};


	//////////////////// F24SEDIINAIL /////////////////////////////////
	var tf24sediinail= new DataTable("f24sediinail");
	C= new DataColumn("codicesede", typeof(string));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	tf24sediinail.Columns.Add( new DataColumn("nomesede", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("indirizzo", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("cap", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("citta", typeof(string)));
	tf24sediinail.Columns.Add( new DataColumn("provincia", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24sediinail.Columns.Add(C);
	Tables.Add(tf24sediinail);
	tf24sediinail.PrimaryKey =  new DataColumn[]{tf24sediinail.Columns["codicesede"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{f24sediinail.Columns["codicesede"]};
	var cChild = new []{pat.Columns["codicesede"]};
	Relations.Add(new DataRelation("f24sediinail_pat",cPar,cChild,false));

	#endregion

}
}
}
