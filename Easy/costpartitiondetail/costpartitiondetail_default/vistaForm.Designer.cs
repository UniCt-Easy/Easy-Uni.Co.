/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace costpartitiondetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio Costi Ripartizione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartitiondetail 		=> Tables["costpartitiondetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	///<summary>
	///Ripartizione dei costi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartition 		=> Tables["costpartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartitiondetailview 		=> Tables["costpartitiondetailview"];

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
	//////////////////// COSTPARTITIONDETAIL /////////////////////////////////
	var tcostpartitiondetail= new DataTable("costpartitiondetail");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartitiondetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tcostpartitiondetail.Columns.Add(C);
	tcostpartitiondetail.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tcostpartitiondetail.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcostpartitiondetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartitiondetail.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartitiondetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartitiondetail.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartitiondetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tcostpartitiondetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tcostpartitiondetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tcostpartitiondetail);
	tcostpartitiondetail.PrimaryKey =  new DataColumn[]{tcostpartitiondetail.Columns["idcostpartition"], tcostpartitiondetail.Columns["iddetail"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new DataTable("costpartition");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartition.Columns.Add(C);
	tcostpartition.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("description", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("kind", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tcostpartition);
	tcostpartition.PrimaryKey =  new DataColumn[]{tcostpartition.Columns["idcostpartition"]};


	//////////////////// COSTPARTITIONDETAILVIEW /////////////////////////////////
	var tcostpartitiondetailview= new DataTable("costpartitiondetailview");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartitiondetailview.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tcostpartitiondetailview.Columns.Add(C);
	tcostpartitiondetailview.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("title", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("kind", typeof(string));
	C.ReadOnly=true;
	tcostpartitiondetailview.Columns.Add(C);
	tcostpartitiondetailview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("codesorkind1", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("sortingkind1", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("sortcode1", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("codesorkind2", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("sortingkind2", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("sortcode2", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("codesorkind3", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("sortingkind3", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("idsor3", typeof(int)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("sortcode3", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("idsorkind3", typeof(int)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("idsorkind2", typeof(int)));
	tcostpartitiondetailview.Columns.Add( new DataColumn("idsorkind1", typeof(int)));
	Tables.Add(tcostpartitiondetailview);
	tcostpartitiondetailview.PrimaryKey =  new DataColumn[]{tcostpartitiondetailview.Columns["idcostpartition"], tcostpartitiondetailview.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{costpartition.Columns["idcostpartition"]};
	var cChild = new []{costpartitiondetail.Columns["idcostpartition"]};
	Relations.Add(new DataRelation("costpartition_costpartitiondetail",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{costpartitiondetail.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_costpartitiondetail",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{costpartitiondetail.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_costpartitiondetail",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{costpartitiondetail.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_costpartitiondetail",cPar,cChild,false));

	cPar = new []{costpartitiondetailview.Columns["idcostpartition"], costpartitiondetailview.Columns["iddetail"]};
	cChild = new []{costpartitiondetail.Columns["idcostpartition"], costpartitiondetail.Columns["iddetail"]};
	Relations.Add(new DataRelation("costpartitiondetailview_costpartitiondetail",cPar,cChild,false));

	#endregion

}
}
}
