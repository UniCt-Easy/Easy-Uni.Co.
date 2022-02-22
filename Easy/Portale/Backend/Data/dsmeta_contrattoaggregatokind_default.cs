
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
[System.Xml.Serialization.XmlRoot("dsmeta_contrattoaggregatokind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_contrattoaggregatokind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable inquadramento 		=> (MetaTable)Tables["inquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattoaggregatokindinquadramento 		=> (MetaTable)Tables["contrattoaggregatokindinquadramento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattoaggregatokind 		=> (MetaTable)Tables["contrattoaggregatokind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contrattoaggregatokind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contrattoaggregatokind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contrattoaggregatokind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contrattoaggregatokind_default.xsd";

	#region create DataTables
	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("active", typeof(string),false);
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// INQUADRAMENTO /////////////////////////////////
	var tinquadramento= new MetaTable("inquadramento");
	tinquadramento.defineColumn("costolordoannuo", typeof(decimal));
	tinquadramento.defineColumn("costolordoannuooneri", typeof(decimal));
	tinquadramento.defineColumn("ct", typeof(DateTime),false);
	tinquadramento.defineColumn("cu", typeof(string),false);
	tinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tinquadramento.defineColumn("lt", typeof(DateTime),false);
	tinquadramento.defineColumn("lu", typeof(string),false);
	tinquadramento.defineColumn("siglaimportazione", typeof(string));
	tinquadramento.defineColumn("start", typeof(DateTime));
	tinquadramento.defineColumn("stop", typeof(DateTime));
	tinquadramento.defineColumn("tempdef", typeof(string));
	tinquadramento.defineColumn("title", typeof(string));
	Tables.Add(tinquadramento);
	tinquadramento.defineKey("idcontrattokind", "idinquadramento");

	//////////////////// CONTRATTOAGGREGATOKINDINQUADRAMENTO /////////////////////////////////
	var tcontrattoaggregatokindinquadramento= new MetaTable("contrattoaggregatokindinquadramento");
	tcontrattoaggregatokindinquadramento.defineColumn("ct", typeof(DateTime));
	tcontrattoaggregatokindinquadramento.defineColumn("cu", typeof(string));
	tcontrattoaggregatokindinquadramento.defineColumn("idcontrattoaggregatokind", typeof(int),false);
	tcontrattoaggregatokindinquadramento.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattoaggregatokindinquadramento.defineColumn("idinquadramento", typeof(int),false);
	tcontrattoaggregatokindinquadramento.defineColumn("lt", typeof(DateTime));
	tcontrattoaggregatokindinquadramento.defineColumn("lu", typeof(string));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_contrattokind_title", typeof(string));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_inquadramento_title", typeof(string));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_inquadramento_tempdef", typeof(string));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_inquadramento_start", typeof(DateTime));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_inquadramento_stop", typeof(DateTime));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_inquadramento_costolordoannuo", typeof(decimal));
	tcontrattoaggregatokindinquadramento.defineColumn("!idinquadramento_inquadramento_costolordoannuooneri", typeof(decimal));
	Tables.Add(tcontrattoaggregatokindinquadramento);
	tcontrattoaggregatokindinquadramento.defineKey("idcontrattoaggregatokind", "idcontrattokind", "idinquadramento");

	//////////////////// CONTRATTOAGGREGATOKIND /////////////////////////////////
	var tcontrattoaggregatokind= new MetaTable("contrattoaggregatokind");
	tcontrattoaggregatokind.defineColumn("ct", typeof(DateTime));
	tcontrattoaggregatokind.defineColumn("cu", typeof(string));
	tcontrattoaggregatokind.defineColumn("idcontrattoaggregatokind", typeof(int),false);
	tcontrattoaggregatokind.defineColumn("lt", typeof(DateTime));
	tcontrattoaggregatokind.defineColumn("lu", typeof(string));
	tcontrattoaggregatokind.defineColumn("title", typeof(string));
	Tables.Add(tcontrattoaggregatokind);
	tcontrattoaggregatokind.defineKey("idcontrattoaggregatokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{contrattoaggregatokind.Columns["idcontrattoaggregatokind"]};
	var cChild = new []{contrattoaggregatokindinquadramento.Columns["idcontrattoaggregatokind"]};
	Relations.Add(new DataRelation("FK_contrattoaggregatokindinquadramento_contrattoaggregatokind_idcontrattoaggregatokind",cPar,cChild,false));

	cPar = new []{inquadramento.Columns["idinquadramento"]};
	cChild = new []{contrattoaggregatokindinquadramento.Columns["idinquadramento"]};
	Relations.Add(new DataRelation("FK_contrattoaggregatokindinquadramento_inquadramento_idinquadramento",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{inquadramento.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_inquadramento_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
