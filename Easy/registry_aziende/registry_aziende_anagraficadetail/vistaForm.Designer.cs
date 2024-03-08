
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
namespace registry_aziende_anagraficadetail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_aziende 		=> Tables["registry_aziende"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ateco 		=> Tables["ateco"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable nace 		=> Tables["nace"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable naturagiur 		=> Tables["naturagiur"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable numerodip 		=> Tables["numerodip"];

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
	//////////////////// REGISTRY_AZIENDE /////////////////////////////////
	var tregistry_aziende= new DataTable("registry_aziende");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_aziende.Columns.Add(C);
	tregistry_aziende.Columns.Add( new DataColumn("title_en", typeof(string)));
	tregistry_aziende.Columns.Add( new DataColumn("idnaturagiur", typeof(int)));
	tregistry_aziende.Columns.Add( new DataColumn("idateco", typeof(int)));
	tregistry_aziende.Columns.Add( new DataColumn("idnace", typeof(string)));
	tregistry_aziende.Columns.Add( new DataColumn("idnumerodip", typeof(int)));
	tregistry_aziende.Columns.Add( new DataColumn("txt_en", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_aziende.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_aziende.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_aziende.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_aziende.Columns.Add(C);
	tregistry_aziende.Columns.Add( new DataColumn("pic", typeof(string)));
	Tables.Add(tregistry_aziende);
	tregistry_aziende.PrimaryKey =  new DataColumn[]{tregistry_aziende.Columns["idreg"]};


	//////////////////// ATECO /////////////////////////////////
	var tateco= new DataTable("ateco");
	C= new DataColumn("idateco", typeof(int));
	C.AllowDBNull=false;
	tateco.Columns.Add(C);
	tateco.Columns.Add( new DataColumn("codice", typeof(string)));
	tateco.Columns.Add( new DataColumn("title", typeof(string)));
	tateco.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tateco.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tateco);
	tateco.PrimaryKey =  new DataColumn[]{tateco.Columns["idateco"]};


	//////////////////// NACE /////////////////////////////////
	var tnace= new DataTable("nace");
	C= new DataColumn("idnace", typeof(string));
	C.AllowDBNull=false;
	tnace.Columns.Add(C);
	C= new DataColumn("activity", typeof(string));
	C.AllowDBNull=false;
	tnace.Columns.Add(C);
	tnace.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tnace.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tnace);
	tnace.PrimaryKey =  new DataColumn[]{tnace.Columns["idnace"]};


	//////////////////// NATURAGIUR /////////////////////////////////
	var tnaturagiur= new DataTable("naturagiur");
	C= new DataColumn("idnaturagiur", typeof(int));
	C.AllowDBNull=false;
	tnaturagiur.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tnaturagiur.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(int));
	C.AllowDBNull=false;
	tnaturagiur.Columns.Add(C);
	tnaturagiur.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tnaturagiur.Columns.Add(C);
	tnaturagiur.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tnaturagiur.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tnaturagiur);
	tnaturagiur.PrimaryKey =  new DataColumn[]{tnaturagiur.Columns["idnaturagiur"]};


	//////////////////// NUMERODIP /////////////////////////////////
	var tnumerodip= new DataTable("numerodip");
	C= new DataColumn("idnumerodip", typeof(int));
	C.AllowDBNull=false;
	tnumerodip.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tnumerodip.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(int));
	C.AllowDBNull=false;
	tnumerodip.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tnumerodip.Columns.Add(C);
	tnumerodip.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tnumerodip.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tnumerodip);
	tnumerodip.PrimaryKey =  new DataColumn[]{tnumerodip.Columns["idnumerodip"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{ateco.Columns["idateco"]};
	var cChild = new []{registry_aziende.Columns["idateco"]};
	Relations.Add(new DataRelation("ateco_registry_aziende",cPar,cChild,false));

	cPar = new []{nace.Columns["idnace"]};
	cChild = new []{registry_aziende.Columns["idnace"]};
	Relations.Add(new DataRelation("nace_registry_aziende",cPar,cChild,false));

	cPar = new []{naturagiur.Columns["idnaturagiur"]};
	cChild = new []{registry_aziende.Columns["idnaturagiur"]};
	Relations.Add(new DataRelation("naturagiur_registry_aziende",cPar,cChild,false));

	cPar = new []{numerodip.Columns["idnumerodip"]};
	cChild = new []{registry_aziende.Columns["idnumerodip"]};
	Relations.Add(new DataRelation("numerodip_registry_aziende",cPar,cChild,false));

	#endregion

}
}
}
