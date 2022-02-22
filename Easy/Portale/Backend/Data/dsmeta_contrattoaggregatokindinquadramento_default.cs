
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_contrattoaggregatokindinquadramento_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_contrattoaggregatokindinquadramento_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramentoelencoview 		=> (MetaTable)Tables["inquadramentoelencoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattoaggregatokindinquadramento 		=> (MetaTable)Tables["contrattoaggregatokindinquadramento"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contrattoaggregatokindinquadramento_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contrattoaggregatokindinquadramento_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contrattoaggregatokindinquadramento_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contrattoaggregatokindinquadramento_default.xsd";

	#region create DataTables
	//////////////////// INQUADRAMENTOELENCOVIEW /////////////////////////////////
	var tinquadramentoelencoview= new MetaTable("inquadramentoelencoview");
	tinquadramentoelencoview.defineColumn("contrattokind_title", typeof(string));
	tinquadramentoelencoview.defineColumn("dropdown_title", typeof(string),false);
	tinquadramentoelencoview.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramentoelencoview.defineColumn("idinquadramento", typeof(int),false);
	tinquadramentoelencoview.defineColumn("inquadramento_costolordoannuo", typeof(decimal));
	tinquadramentoelencoview.defineColumn("inquadramento_costolordoannuooneri", typeof(decimal));
	tinquadramentoelencoview.defineColumn("inquadramento_ct", typeof(DateTime),false);
	tinquadramentoelencoview.defineColumn("inquadramento_cu", typeof(string),false);
	tinquadramentoelencoview.defineColumn("inquadramento_lt", typeof(DateTime),false);
	tinquadramentoelencoview.defineColumn("inquadramento_lu", typeof(string),false);
	tinquadramentoelencoview.defineColumn("inquadramento_siglaimportazione", typeof(string));
	tinquadramentoelencoview.defineColumn("inquadramento_start", typeof(DateTime));
	tinquadramentoelencoview.defineColumn("inquadramento_stop", typeof(DateTime));
	tinquadramentoelencoview.defineColumn("inquadramento_tempdef", typeof(string));
	tinquadramentoelencoview.defineColumn("inquadramento_title", typeof(string));
	Tables.Add(tinquadramentoelencoview);
	tinquadramentoelencoview.defineKey("idinquadramento");

	//////////////////// CONTRATTOAGGREGATOKINDINQUADRAMENTO /////////////////////////////////
	var tcontrattoaggregatokindinquadramento= new MetaTable("contrattoaggregatokindinquadramento");
	tcontrattoaggregatokindinquadramento.defineColumn("ct", typeof(DateTime));
	tcontrattoaggregatokindinquadramento.defineColumn("cu", typeof(string));
	tcontrattoaggregatokindinquadramento.defineColumn("idcontrattoaggregatokind", typeof(int),false);
	tcontrattoaggregatokindinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattoaggregatokindinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tcontrattoaggregatokindinquadramento.defineColumn("lt", typeof(DateTime));
	tcontrattoaggregatokindinquadramento.defineColumn("lu", typeof(string));
	Tables.Add(tcontrattoaggregatokindinquadramento);
	tcontrattoaggregatokindinquadramento.defineKey("idcontrattoaggregatokind", "idcontrattokind", "idinquadramento");

	#endregion


	#region DataRelation creation
	var cPar = new []{inquadramentoelencoview.Columns["idinquadramento"]};
	var cChild = new []{contrattoaggregatokindinquadramento.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_contrattoaggregatokindinquadramento_inquadramentoelencoview_idinquadramento",cPar,cChild,false));

	#endregion

}
}
}
