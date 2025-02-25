
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
namespace registrydurc_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrydurc 		=> Tables["registrydurc"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrydurcview 		=> Tables["registrydurcview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrydurcattachment 		=> Tables["registrydurcattachment"];

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
	//////////////////// REGISTRYDURC /////////////////////////////////
	var tregistrydurc= new DataTable("registrydurc");
	C= new DataColumn("idregistrydurc", typeof(int));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	tregistrydurc.Columns.Add( new DataColumn("iddurckind", typeof(short)));
	tregistrydurc.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("selfcertification", typeof(Byte[])));
	tregistrydurc.Columns.Add( new DataColumn("durccertification", typeof(Byte[])));
	tregistrydurc.Columns.Add( new DataColumn("doc", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tregistrydurc.Columns.Add( new DataColumn("inpscode", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("inailcode", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("buildingcode", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("otherinsurancecode", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrydurc.Columns.Add(C);
	tregistrydurc.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrydurc.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrydurc.Columns.Add( new DataColumn("flagirregular", typeof(string)));
	Tables.Add(tregistrydurc);
	tregistrydurc.PrimaryKey =  new DataColumn[]{tregistrydurc.Columns["idregistrydurc"], tregistrydurc.Columns["idreg"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("toredirect", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idaccmotivedebit", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// REGISTRYDURCVIEW /////////////////////////////////
	var tregistrydurcview= new DataTable("registrydurcview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	C= new DataColumn("idregistrydurc", typeof(int));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	tregistrydurcview.Columns.Add( new DataColumn("iddurckind", typeof(short)));
	C= new DataColumn("durckinddescr", typeof(string));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	tregistrydurcview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tregistrydurcview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrydurcview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	tregistrydurcview.Columns.Add( new DataColumn("selfcertification", typeof(Byte[])));
	tregistrydurcview.Columns.Add( new DataColumn("durccertification", typeof(Byte[])));
	tregistrydurcview.Columns.Add( new DataColumn("doc", typeof(string)));
	tregistrydurcview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tregistrydurcview.Columns.Add( new DataColumn("inpscode", typeof(string)));
	tregistrydurcview.Columns.Add( new DataColumn("inailcode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrydurcview.Columns.Add(C);
	Tables.Add(tregistrydurcview);
	tregistrydurcview.PrimaryKey =  new DataColumn[]{tregistrydurcview.Columns["idreg"], tregistrydurcview.Columns["idregistrydurc"]};


	//////////////////// REGISTRYDURCATTACHMENT /////////////////////////////////
	var tregistrydurcattachment= new DataTable("registrydurcattachment");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrydurcattachment.Columns.Add(C);
	C= new DataColumn("idregistrydurc", typeof(int));
	C.AllowDBNull=false;
	tregistrydurcattachment.Columns.Add(C);
	C= new DataColumn("idattachment", typeof(int));
	C.AllowDBNull=false;
	tregistrydurcattachment.Columns.Add(C);
	tregistrydurcattachment.Columns.Add( new DataColumn("attachment", typeof(Byte[])));
	tregistrydurcattachment.Columns.Add( new DataColumn("filename", typeof(string)));
	tregistrydurcattachment.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistrydurcattachment.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistrydurcattachment.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistrydurcattachment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistrydurcattachment.Columns.Add( new DataColumn("idattachmentkind", typeof(int)));
	Tables.Add(tregistrydurcattachment);
	tregistrydurcattachment.PrimaryKey =  new DataColumn[]{tregistrydurcattachment.Columns["idreg"], tregistrydurcattachment.Columns["idregistrydurc"], tregistrydurcattachment.Columns["idattachment"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registrydurc.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrydurc",cPar,cChild,false));

	cPar = new []{registrydurc.Columns["idreg"], registrydurc.Columns["idregistrydurc"]};
	cChild = new []{registrydurcattachment.Columns["idreg"], registrydurcattachment.Columns["idregistrydurc"]};
	Relations.Add(new DataRelation("registrydurc_registrydurcattachment",cPar,cChild,false));

	#endregion

}
}
}
