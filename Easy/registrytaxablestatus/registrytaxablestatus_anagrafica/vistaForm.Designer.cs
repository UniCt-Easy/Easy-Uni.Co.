
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
namespace registrytaxablestatus_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrytaxablestatus 		=> Tables["registrytaxablestatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrytaxablestatusattachment 		=> Tables["registrytaxablestatusattachment"];

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
	//////////////////// REGISTRYTAXABLESTATUS /////////////////////////////////
	var tregistrytaxablestatus= new DataTable("registrytaxablestatus");
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	tregistrytaxablestatus.Columns.Add( new DataColumn("supposedincome", typeof(decimal)));
	tregistrytaxablestatus.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrytaxablestatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	tregistrytaxablestatus.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tregistrytaxablestatus);
	tregistrytaxablestatus.PrimaryKey =  new DataColumn[]{tregistrytaxablestatus.Columns["start"], tregistrytaxablestatus.Columns["idreg"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// REGISTRYTAXABLESTATUSATTACHMENT /////////////////////////////////
	var tregistrytaxablestatusattachment= new DataTable("registrytaxablestatusattachment");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrytaxablestatusattachment.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatusattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tregistrytaxablestatusattachment.Columns.Add(C);
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistrytaxablestatusattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	Tables.Add(tregistrytaxablestatusattachment);
	tregistrytaxablestatusattachment.PrimaryKey =  new DataColumn[]{tregistrytaxablestatusattachment.Columns["idreg"], tregistrytaxablestatusattachment.Columns["start"], tregistrytaxablestatusattachment.Columns["idattachment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registrytaxablestatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrytaxablestatus",cPar,cChild,false));

	cPar = new []{registrytaxablestatus.Columns["idreg"], registrytaxablestatus.Columns["start"]};
	cChild = new []{registrytaxablestatusattachment.Columns["idreg"], registrytaxablestatusattachment.Columns["start"]};
	Relations.Add(new DataRelation("registrytaxablestatus_registrytaxablestatusattachment",cPar,cChild,false));

	#endregion

}
}
}
