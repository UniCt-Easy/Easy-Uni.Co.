/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace registrylegalstatus_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Qualifica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable position 		=> Tables["position"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Inquadramento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrylegalstatus 		=> Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrylegalstatusregview 		=> Tables["registrylegalstatusregview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrymainview 		=> Tables["registrymainview"];

	///<summary>
	///Posizione Dalia
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dalia_position 		=> Tables["dalia_position"];

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
	//////////////////// POSITION /////////////////////////////////
	var tposition= new DataTable("position");
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	tposition.Columns.Add( new DataColumn("maxincomeclass", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tposition.Columns.Add(C);
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


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


	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new DataTable("registrylegalstatus");
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("idposition", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclass", typeof(short)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclassvalidity", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrylegalstatus.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_compartment", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_role", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_class", typeof(string)));
	C= new DataColumn("idregistrylegalstatus", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.PrimaryKey =  new DataColumn[]{tregistrylegalstatus.Columns["idreg"], tregistrylegalstatus.Columns["idregistrylegalstatus"]};


	//////////////////// REGISTRYLEGALSTATUSREGVIEW /////////////////////////////////
	var tregistrylegalstatusregview= new DataTable("registrylegalstatusregview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatusregview.Columns.Add(C);
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	tregistrylegalstatusregview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrylegalstatusregview.Columns.Add(C);
	tregistrylegalstatusregview.Columns.Add( new DataColumn("idposition", typeof(int)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("position", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("incomeclass", typeof(short)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("incomeclassvalidity", typeof(DateTime)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("idregistrylegalstatus", typeof(int)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("csa_compartment", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("csa_role", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("csa_class", typeof(string)));
	tregistrylegalstatusregview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	Tables.Add(tregistrylegalstatusregview);

	//////////////////// REGISTRYMAINVIEW /////////////////////////////////
	var tregistrymainview= new DataTable("registrymainview");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistrymainview.Columns.Add(C);
	tregistrymainview.Columns.Add( new DataColumn("coderesidence", typeof(string)));
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
	tregistrymainview.Columns.Add( new DataColumn("category", typeof(string)));
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
	tregistrymainview.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistrymainview.Columns.Add( new DataColumn("registryclass", typeof(string)));
	Tables.Add(tregistrymainview);
	tregistrymainview.PrimaryKey =  new DataColumn[]{tregistrymainview.Columns["idreg"]};


	//////////////////// DALIA_POSITION /////////////////////////////////
	var tdalia_position= new DataTable("dalia_position");
	C= new DataColumn("iddaliaposition", typeof(int));
	C.AllowDBNull=false;
	tdalia_position.Columns.Add(C);
	tdalia_position.Columns.Add( new DataColumn("codedaliaposition", typeof(string)));
	tdalia_position.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tdalia_position);
	tdalia_position.PrimaryKey =  new DataColumn[]{tdalia_position.Columns["iddaliaposition"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrylegalstatus",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{registrylegalstatus.Columns["idposition"]};
	Relations.Add(new DataRelation("positionregistrylegalstatus",cPar,cChild,false));

	cPar = new []{dalia_position.Columns["iddaliaposition"]};
	cChild = new []{registrylegalstatus.Columns["iddaliaposition"]};
	Relations.Add(new DataRelation("dalia_position_registrylegalstatus",cPar,cChild,false));

	#endregion

}
}
}
