
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
namespace trasmissionmanager_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable trasmissiondocument 		=> Tables["trasmissiondocument"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Responsabile Trasmissione Documenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable trasmissionmanager 		=> Tables["trasmissionmanager"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable trasmissionmanagerview 		=> Tables["trasmissionmanagerview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

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
	//////////////////// TRASMISSIONDOCUMENT /////////////////////////////////
	var ttrasmissiondocument= new DataTable("trasmissiondocument");
	C= new DataColumn("idtrasmissiondocument", typeof(string));
	C.AllowDBNull=false;
	ttrasmissiondocument.Columns.Add(C);
	ttrasmissiondocument.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttrasmissiondocument.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttrasmissiondocument.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttrasmissiondocument.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttrasmissiondocument.Columns.Add(C);
	Tables.Add(ttrasmissiondocument);
	ttrasmissiondocument.PrimaryKey =  new DataColumn[]{ttrasmissiondocument.Columns["idtrasmissiondocument"]};


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
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// TRASMISSIONMANAGER /////////////////////////////////
	var ttrasmissionmanager= new DataTable("trasmissionmanager");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	C= new DataColumn("idtrasmissiondocument", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttrasmissionmanager.Columns.Add(C);
	ttrasmissionmanager.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttrasmissionmanager.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(ttrasmissionmanager);
	ttrasmissionmanager.PrimaryKey =  new DataColumn[]{ttrasmissionmanager.Columns["ayear"], ttrasmissionmanager.Columns["idtrasmissiondocument"]};


	//////////////////// TRASMISSIONMANAGERVIEW /////////////////////////////////
	var ttrasmissionmanagerview= new DataTable("trasmissionmanagerview");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	ttrasmissionmanagerview.Columns.Add( new DataColumn("annotations", typeof(string)));
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	ttrasmissionmanagerview.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("idtrasmissiondocument", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	ttrasmissionmanagerview.Columns.Add( new DataColumn("description", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("surname", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("forename", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("idcity", typeof(int)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("gender", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("city", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("province", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("idnation", typeof(int)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("nation", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	ttrasmissionmanagerview.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttrasmissionmanagerview.Columns.Add(C);
	Tables.Add(ttrasmissionmanagerview);
	ttrasmissionmanagerview.PrimaryKey =  new DataColumn[]{ttrasmissionmanagerview.Columns["ayear"], ttrasmissionmanagerview.Columns["idtrasmissiondocument"]};


	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("residencekind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistrymainview.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("city", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("qualification", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalstatus", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("sortcode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registrykind", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("human", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("location", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistrymainview.Columns.Add( new DataColumn("nation", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{trasmissionmanager.Columns["idreg"]};
	Relations.Add(new DataRelation("registrytrasmissionmanager",cPar,cChild,false));

	cPar = new []{trasmissiondocument.Columns["idtrasmissiondocument"]};
	cChild = new []{trasmissionmanager.Columns["idtrasmissiondocument"]};
	Relations.Add(new DataRelation("trasmissiondocumenttrasmissionmanager",cPar,cChild,false));

	#endregion

}
}
}
