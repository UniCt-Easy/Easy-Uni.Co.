
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
namespace csapositionlookup_lista {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable position 		=> Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csapositionlookup 		=> Tables["csapositionlookup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inquadramento 		=> Tables["inquadramento"];

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
	tposition.Columns.Add( new DataColumn("assegnoaggiuntivo", typeof(string)));
	tposition.Columns.Add( new DataColumn("costolordoannuo", typeof(decimal)));
	tposition.Columns.Add( new DataColumn("costolordoannuooneri", typeof(decimal)));
	tposition.Columns.Add( new DataColumn("elementoperequativo", typeof(string)));
	tposition.Columns.Add( new DataColumn("indennitadiateneo", typeof(string)));
	tposition.Columns.Add( new DataColumn("indennitadiposizione", typeof(string)));
	tposition.Columns.Add( new DataColumn("indvacancacontrattuale", typeof(string)));
	tposition.Columns.Add( new DataColumn("oremaxcompitididatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxcompitididatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxdidatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxdidatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxgg", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxtempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremaxtempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremincompitididatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremincompitididatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremindidatempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremindidatempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremintempoparziale", typeof(int)));
	tposition.Columns.Add( new DataColumn("oremintempopieno", typeof(int)));
	tposition.Columns.Add( new DataColumn("orestraordinariemax", typeof(int)));
	tposition.Columns.Add( new DataColumn("parttime", typeof(string)));
	tposition.Columns.Add( new DataColumn("puntiorganico", typeof(decimal)));
	tposition.Columns.Add( new DataColumn("livello", typeof(string)));
	tposition.Columns.Add( new DataColumn("siglaesportazione", typeof(string)));
	tposition.Columns.Add( new DataColumn("siglaimportazione", typeof(string)));
	tposition.Columns.Add( new DataColumn("printingorder", typeof(int)));
	tposition.Columns.Add( new DataColumn("tempdef", typeof(string)));
	tposition.Columns.Add( new DataColumn("tipopersonale", typeof(string)));
	tposition.Columns.Add( new DataColumn("title", typeof(string)));
	tposition.Columns.Add( new DataColumn("totaletredicesima", typeof(string)));
	tposition.Columns.Add( new DataColumn("tredicesimaindennitaintegrativaspeciale", typeof(string)));
	tposition.Columns.Add( new DataColumn("tipoente", typeof(string)));
	Tables.Add(tposition);
	tposition.PrimaryKey =  new DataColumn[]{tposition.Columns["idposition"]};


	//////////////////// CSAPOSITIONLOOKUP /////////////////////////////////
	var tcsapositionlookup= new DataTable("csapositionlookup");
	C= new DataColumn("idcsaposition", typeof(int));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	tcsapositionlookup.Columns.Add( new DataColumn("csa_class", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("csa_compartment", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("csa_description", typeof(string)));
	tcsapositionlookup.Columns.Add( new DataColumn("csa_role", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	tcsapositionlookup.Columns.Add( new DataColumn("idposition", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsapositionlookup.Columns.Add(C);
	tcsapositionlookup.Columns.Add( new DataColumn("supposedtaxable", typeof(decimal)));
	tcsapositionlookup.Columns.Add( new DataColumn("livello", typeof(int)));
	tcsapositionlookup.Columns.Add( new DataColumn("idinquadramento", typeof(int)));
	Tables.Add(tcsapositionlookup);
	tcsapositionlookup.PrimaryKey =  new DataColumn[]{tcsapositionlookup.Columns["idcsaposition"]};


	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new DataTable("inquadramento");
	C= new DataColumn("idinquadramento", typeof(int));
	C.AllowDBNull=false;
	tinquadramento.Columns.Add(C);
	tinquadramento.Columns.Add( new DataColumn("idcontrattokind", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinquadramento.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinquadramento.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinquadramento.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinquadramento.Columns.Add(C);
	tinquadramento.Columns.Add( new DataColumn("title", typeof(string)));
	tinquadramento.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tinquadramento.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tinquadramento.Columns.Add( new DataColumn("tempdef", typeof(string)));
	tinquadramento.Columns.Add( new DataColumn("costolordoannuo", typeof(decimal)));
	tinquadramento.Columns.Add( new DataColumn("costolordoannuooneri", typeof(decimal)));
	tinquadramento.Columns.Add( new DataColumn("siglaimportazione", typeof(string)));
	C= new DataColumn("idposition", typeof(int));
	C.AllowDBNull=false;
	tinquadramento.Columns.Add(C);
	Tables.Add(tinquadramento);
	tinquadramento.PrimaryKey =  new DataColumn[]{tinquadramento.Columns["idinquadramento"], tinquadramento.Columns["idposition"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{position.Columns["idposition"]};
	var cChild = new []{csapositionlookup.Columns["idposition"]};
	Relations.Add(new DataRelation("position_csapositionlookup",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"], inquadramento.Columns["idposition"]};
	cChild = new []{csapositionlookup.Columns["idinquadramento"], csapositionlookup.Columns["idposition"]};
	Relations.Add(new DataRelation("inquadramento_csapositionlookup",cPar,cChild,false));

	#endregion

}
}
}
