
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace position_riepilogo {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable foreignallowanceruledetailview 		=> Tables["foreignallowanceruledetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable reductionruledetailview 		=> Tables["reductionruledetailview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable itinerationrefundruledetailview 		=> Tables["itinerationrefundruledetailview"];

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
	//////////////////// FOREIGNALLOWANCERULEDETAILVIEW /////////////////////////////////
	var tforeignallowanceruledetailview= new DataTable("foreignallowanceruledetailview");
	C= new DataColumn("idforeignallowancerule", typeof(int));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("foreigncountry", typeof(string));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("minforeigngroupnumber", typeof(short));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("maxforeigngroupnumber", typeof(short));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	C= new DataColumn("advancepercentage", typeof(decimal));
	C.AllowDBNull=false;
	tforeignallowanceruledetailview.Columns.Add(C);
	Tables.Add(tforeignallowanceruledetailview);
	tforeignallowanceruledetailview.PrimaryKey =  new DataColumn[]{tforeignallowanceruledetailview.Columns["idforeignallowancerule"], tforeignallowanceruledetailview.Columns["iddetail"]};


	//////////////////// REDUCTIONRULEDETAILVIEW /////////////////////////////////
	var treductionruledetailview= new DataTable("reductionruledetailview");
	C= new DataColumn("idreductionrule", typeof(int));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("idreduction", typeof(string));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("reduction", typeof(string));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("reductionpercentage", typeof(decimal));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	treductionruledetailview.Columns.Add(C);
	Tables.Add(treductionruledetailview);
	treductionruledetailview.PrimaryKey =  new DataColumn[]{treductionruledetailview.Columns["idreductionrule"], treductionruledetailview.Columns["iddetail"]};


	//////////////////// ITINERATIONREFUNDRULEDETAILVIEW /////////////////////////////////
	var titinerationrefundruledetailview= new DataTable("itinerationrefundruledetailview");
	C= new DataColumn("iditinerationrefundrule", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("ruledescr", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("itinerationrefundkindgroup", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("minincomeclass", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("maxincomeclass", typeof(int));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("flag_italy", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("flag_eu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	C= new DataColumn("flag_extraeu", typeof(string));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	titinerationrefundruledetailview.Columns.Add( new DataColumn("nhour_min", typeof(int)));
	titinerationrefundruledetailview.Columns.Add( new DataColumn("nhour_max", typeof(int)));
	titinerationrefundruledetailview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	C= new DataColumn("advancepercentage", typeof(decimal));
	C.AllowDBNull=false;
	titinerationrefundruledetailview.Columns.Add(C);
	Tables.Add(titinerationrefundruledetailview);
	titinerationrefundruledetailview.PrimaryKey =  new DataColumn[]{titinerationrefundruledetailview.Columns["iditinerationrefundrule"], titinerationrefundruledetailview.Columns["iddetail"]};


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
	tposition.Columns.Add( new DataColumn("foreignclass", typeof(string)));
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


	#endregion

}
}
}
