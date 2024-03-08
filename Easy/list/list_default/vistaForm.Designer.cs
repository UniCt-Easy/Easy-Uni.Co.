
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
namespace list_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable list 		=> Tables["list"];

	///<summary>
	///Unità di Misura per il carico/scarico
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unit 		=> Tables["unit"];

	///<summary>
	/// Unità di Misura per l'acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable package 		=> Tables["package"];

	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclass 		=> Tables["listclass"];

	///<summary>
	///Classificazione listino
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listsorting 		=> Tables["listsorting"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tassonomia_pagopa 		=> Tables["tassonomia_pagopa"];

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
	//////////////////// LIST /////////////////////////////////
	var tlist= new DataTable("list");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("intcode", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("intbarcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("extcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("extbarcode", typeof(string)));
	tlist.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("idpackage", typeof(int)));
	tlist.Columns.Add( new DataColumn("idunit", typeof(int)));
	tlist.Columns.Add( new DataColumn("unitsforpackage", typeof(int)));
	C= new DataColumn("has_expiry", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlist.Columns.Add(C);
	tlist.Columns.Add( new DataColumn("pic", typeof(Byte[])));
	tlist.Columns.Add( new DataColumn("picext", typeof(string)));
	tlist.Columns.Add( new DataColumn("nmin", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("ntoreorder", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("timesupply", typeof(int)));
	tlist.Columns.Add( new DataColumn("nmaxorder", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("price", typeof(decimal)));
	tlist.Columns.Add( new DataColumn("insinfo", typeof(string)));
	tlist.Columns.Add( new DataColumn("descrforuser", typeof(string)));
	tlist.Columns.Add( new DataColumn("idtassonomia", typeof(int)));
	Tables.Add(tlist);
	tlist.PrimaryKey =  new DataColumn[]{tlist.Columns["idlist"]};


	//////////////////// UNIT /////////////////////////////////
	var tunit= new DataTable("unit");
	C= new DataColumn("idunit", typeof(int));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tunit.Columns.Add(C);
	Tables.Add(tunit);
	tunit.PrimaryKey =  new DataColumn[]{tunit.Columns["idunit"]};


	//////////////////// PACKAGE /////////////////////////////////
	var tpackage= new DataTable("package");
	C= new DataColumn("idpackage", typeof(int));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tpackage.Columns.Add(C);
	Tables.Add(tpackage);
	tpackage.PrimaryKey =  new DataColumn[]{tpackage.Columns["idpackage"]};


	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("paridlistclass", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlistclass.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	Tables.Add(tlistclass);
	tlistclass.PrimaryKey =  new DataColumn[]{tlistclass.Columns["idlistclass"]};


	//////////////////// LISTSORTING /////////////////////////////////
	var tlistsorting= new DataTable("listsorting");
	C= new DataColumn("idlist", typeof(int));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	C= new DataColumn("quota", typeof(double));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tlistsorting.Columns.Add(C);
	tlistsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tlistsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	Tables.Add(tlistsorting);
	tlistsorting.PrimaryKey =  new DataColumn[]{tlistsorting.Columns["idlist"], tlistsorting.Columns["idsor"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// TASSONOMIA_PAGOPA /////////////////////////////////
	var ttassonomia_pagopa= new DataTable("tassonomia_pagopa");
	C= new DataColumn("idtassonomia", typeof(int));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	C= new DataColumn("versione", typeof(int));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	C= new DataColumn("causale", typeof(string));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	C= new DataColumn("descrizione", typeof(string));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	ttassonomia_pagopa.Columns.Add( new DataColumn("start", typeof(DateTime)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttassonomia_pagopa.Columns.Add(C);
	ttassonomia_pagopa.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("lu", typeof(string)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("title", typeof(string)));
	ttassonomia_pagopa.Columns.Add( new DataColumn("motivoriscossione", typeof(string)));
	Tables.Add(ttassonomia_pagopa);
	ttassonomia_pagopa.PrimaryKey =  new DataColumn[]{ttassonomia_pagopa.Columns["idtassonomia"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{listsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_listsorting",cPar,cChild,false));

	cPar = new []{list.Columns["idlist"]};
	cChild = new []{listsorting.Columns["idlist"]};
	Relations.Add(new DataRelation("FK_list_listsorting",cPar,cChild,false));

	cPar = new []{listclass.Columns["idlistclass"]};
	cChild = new []{list.Columns["idlistclass"]};
	Relations.Add(new DataRelation("FK_listclass_list",cPar,cChild,false));

	cPar = new []{package.Columns["idpackage"]};
	cChild = new []{list.Columns["idpackage"]};
	Relations.Add(new DataRelation("FK_package_list",cPar,cChild,false));

	cPar = new []{unit.Columns["idunit"]};
	cChild = new []{list.Columns["idunit"]};
	Relations.Add(new DataRelation("FK_unit_list",cPar,cChild,false));

	cPar = new []{tassonomia_pagopa.Columns["idtassonomia"]};
	cChild = new []{list.Columns["idtassonomia"]};
	Relations.Add(new DataRelation("tassonomia_pagopa_list",cPar,cChild,false));

	#endregion

}
}
}
