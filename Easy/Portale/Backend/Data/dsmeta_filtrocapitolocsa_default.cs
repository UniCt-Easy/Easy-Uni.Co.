
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_filtrocapitolocsa_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_filtrocapitolocsa_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ruolocsa 		=> (MetaTable)Tables["ruolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable position 		=> (MetaTable)Tables["position"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsaruolocsa 		=> (MetaTable)Tables["filtrocapitolocsaruolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable capitolocsa 		=> (MetaTable)Tables["capitolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsacapitolocsa 		=> (MetaTable)Tables["filtrocapitolocsacapitolocsa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable filtrocapitolocsa 		=> (MetaTable)Tables["filtrocapitolocsa"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_filtrocapitolocsa_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_filtrocapitolocsa_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_filtrocapitolocsa_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_filtrocapitolocsa_default.xsd";

	#region create DataTables
	//////////////////// RUOLOCSA /////////////////////////////////
	var truolocsa= new MetaTable("ruolocsa");
	truolocsa.defineColumn("idruolocsa", typeof(string),false);
	Tables.Add(truolocsa);
	truolocsa.defineKey("idruolocsa");

	//////////////////// POSITION /////////////////////////////////
	var tposition= new MetaTable("position");
	tposition.defineColumn("active", typeof(string));
	tposition.defineColumn("idposition", typeof(int),false);
	tposition.defineColumn("title", typeof(string));
	Tables.Add(tposition);
	tposition.defineKey("idposition");

	//////////////////// FILTROCAPITOLOCSARUOLOCSA /////////////////////////////////
	var tfiltrocapitolocsaruolocsa= new MetaTable("filtrocapitolocsaruolocsa");
	tfiltrocapitolocsaruolocsa.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsaruolocsa.defineColumn("cu", typeof(string));
	tfiltrocapitolocsaruolocsa.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsaruolocsa.defineColumn("idfiltrocapitolocsaruolocsa", typeof(int),false);
	tfiltrocapitolocsaruolocsa.defineColumn("idposition", typeof(int),false);
	tfiltrocapitolocsaruolocsa.defineColumn("idruolocsa", typeof(string),false);
	tfiltrocapitolocsaruolocsa.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsaruolocsa.defineColumn("lu", typeof(string));
	tfiltrocapitolocsaruolocsa.defineColumn("!idposition_position_title", typeof(string));
	Tables.Add(tfiltrocapitolocsaruolocsa);
	tfiltrocapitolocsaruolocsa.defineKey("idfiltrocapitolocsa", "idfiltrocapitolocsaruolocsa");

	//////////////////// CAPITOLOCSA /////////////////////////////////
	var tcapitolocsa= new MetaTable("capitolocsa");
	tcapitolocsa.defineColumn("idcapitolocsa", typeof(string),false);
	Tables.Add(tcapitolocsa);
	tcapitolocsa.defineKey("idcapitolocsa");

	//////////////////// FILTROCAPITOLOCSACAPITOLOCSA /////////////////////////////////
	var tfiltrocapitolocsacapitolocsa= new MetaTable("filtrocapitolocsacapitolocsa");
	tfiltrocapitolocsacapitolocsa.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsacapitolocsa.defineColumn("cu", typeof(string));
	tfiltrocapitolocsacapitolocsa.defineColumn("idcapitolocsa", typeof(string),false);
	tfiltrocapitolocsacapitolocsa.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsacapitolocsa.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsacapitolocsa.defineColumn("lu", typeof(string));
	Tables.Add(tfiltrocapitolocsacapitolocsa);
	tfiltrocapitolocsacapitolocsa.defineKey("idcapitolocsa", "idfiltrocapitolocsa");

	//////////////////// FILTROCAPITOLOCSA /////////////////////////////////
	var tfiltrocapitolocsa= new MetaTable("filtrocapitolocsa");
	tfiltrocapitolocsa.defineColumn("ct", typeof(DateTime));
	tfiltrocapitolocsa.defineColumn("cu", typeof(string));
	tfiltrocapitolocsa.defineColumn("description", typeof(string));
	tfiltrocapitolocsa.defineColumn("idfiltrocapitolocsa", typeof(int),false);
	tfiltrocapitolocsa.defineColumn("lt", typeof(DateTime));
	tfiltrocapitolocsa.defineColumn("lu", typeof(string));
	tfiltrocapitolocsa.defineColumn("title", typeof(string));
	Tables.Add(tfiltrocapitolocsa);
	tfiltrocapitolocsa.defineKey("idfiltrocapitolocsa");

	#endregion


	#region DataRelation creation
	var cPar = new []{filtrocapitolocsa.Columns["idfiltrocapitolocsa"]};
	var cChild = new []{filtrocapitolocsaruolocsa.Columns["idfiltrocapitolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaruolocsa_filtrocapitolocsa_idfiltrocapitolocsa",cPar,cChild,false));

	cPar = new []{ruolocsa.Columns["idruolocsa"]};
	cChild = new []{filtrocapitolocsaruolocsa.Columns["idruolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaruolocsa_ruolocsa_idruolocsa",cPar,cChild,false));

	cPar = new []{position.Columns["idposition"]};
	cChild = new []{filtrocapitolocsaruolocsa.Columns["idposition"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsaruolocsa_position_idposition",cPar,cChild,false));

	cPar = new []{filtrocapitolocsa.Columns["idfiltrocapitolocsa"]};
	cChild = new []{filtrocapitolocsacapitolocsa.Columns["idfiltrocapitolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsacapitolocsa_filtrocapitolocsa_idfiltrocapitolocsa",cPar,cChild,false));

	cPar = new []{capitolocsa.Columns["idcapitolocsa"]};
	cChild = new []{filtrocapitolocsacapitolocsa.Columns["idcapitolocsa"]};
	Relations.Add(new DataRelation("FK_filtrocapitolocsacapitolocsa_capitolocsa_idcapitolocsa",cPar,cChild,false));

	#endregion

}
}
}
