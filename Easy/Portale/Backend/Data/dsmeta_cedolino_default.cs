
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
using metadatalibrary;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace Backend.Data {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("dsmeta_cedolino_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_cedolino_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mese 		=> (MetaTable)Tables["mese"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable cedolino 		=> (MetaTable)Tables["cedolino"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_cedolino_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_cedolino_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_cedolino_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_cedolino_default.xsd";

	#region create DataTables
	//////////////////// MESE /////////////////////////////////
	var tmese= new MetaTable("mese");
	tmese.defineColumn("idmese", typeof(int),false);
	tmese.defineColumn("title", typeof(string));
	Tables.Add(tmese);
	tmese.defineKey("idmese");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// CEDOLINO /////////////////////////////////
	var tcedolino= new MetaTable("cedolino");
	tcedolino.defineColumn("!previdenza", typeof(decimal));
	tcedolino.defineColumn("!tesoro", typeof(decimal));
	tcedolino.defineColumn("!tredicesima", typeof(decimal));
	tcedolino.defineColumn("assegno", typeof(decimal));
	tcedolino.defineColumn("classe", typeof(int));
	tcedolino.defineColumn("data", typeof(DateTime));
	tcedolino.defineColumn("idcedolino", typeof(int),false);
	tcedolino.defineColumn("idmese", typeof(int));
	tcedolino.defineColumn("idreg", typeof(int),false);
	tcedolino.defineColumn("idregistrylegalstatus", typeof(int),false);
	tcedolino.defineColumn("iis", typeof(decimal));
	tcedolino.defineColumn("irap", typeof(decimal));
	tcedolino.defineColumn("lordo", typeof(decimal));
	tcedolino.defineColumn("scatto", typeof(int));
	tcedolino.defineColumn("stipendio", typeof(decimal));
	tcedolino.defineColumn("totale", typeof(decimal));
	tcedolino.defineColumn("totalece", typeof(decimal));
	tcedolino.defineColumn("year", typeof(int));
	Tables.Add(tcedolino);
	tcedolino.defineKey("idcedolino", "idreg", "idregistrylegalstatus");

	#endregion


	#region DataRelation creation
	var cPar = new []{mese.Columns["idmese"]};
	var cChild = new []{cedolino.Columns["idmese"]};
	Relations.Add(new DataRelation("FK_cedolino_mese_idmese",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{cedolino.Columns["year"]};
	Relations.Add(new DataRelation("FK_cedolino_year_year",cPar,cChild,false));

	#endregion

}
}
}
