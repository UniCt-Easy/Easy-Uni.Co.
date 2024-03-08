
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogettoprogettoview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_rendicontattivitaprogettoprogettoview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progetto 		=> (MetaTable)Tables["progetto"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoprogettoview 		=> (MetaTable)Tables["rendicontattivitaprogettoprogettoview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogettoprogettoview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogettoprogettoview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogettoprogettoview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogettoprogettoview_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// PROGETTO /////////////////////////////////
	var tprogetto= new MetaTable("progetto");
	tprogetto.defineColumn("idprogetto", typeof(int),false);
	tprogetto.defineColumn("titolobreve", typeof(string));
	Tables.Add(tprogetto);
	tprogetto.defineKey("idprogetto");

	//////////////////// RENDICONTATTIVITAPROGETTOPROGETTOVIEW /////////////////////////////////
	var trendicontattivitaprogettoprogettoview= new MetaTable("rendicontattivitaprogettoprogettoview");
	trendicontattivitaprogettoprogettoview.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoprogettoview.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettoprogettoview.defineColumn("oreanno", typeof(int));
	trendicontattivitaprogettoprogettoview.defineColumn("oreattivita", typeof(int));
	trendicontattivitaprogettoprogettoview.defineColumn("oremaxanno", typeof(int),false);
	trendicontattivitaprogettoprogettoview.defineColumn("stipendioannuo", typeof(decimal));
	trendicontattivitaprogettoprogettoview.defineColumn("stipendiorendicontato", typeof(decimal));
	trendicontattivitaprogettoprogettoview.defineColumn("year", typeof(int),false);
	Tables.Add(trendicontattivitaprogettoprogettoview);
	trendicontattivitaprogettoprogettoview.defineKey("idprogetto", "idreg", "oremaxanno", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{rendicontattivitaprogettoprogettoview.Columns["year"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoprogettoview_year_year",cPar,cChild,false));

	cPar = new []{registrydefaultview.Columns["idreg"]};
	cChild = new []{rendicontattivitaprogettoprogettoview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoprogettoview_registrydefaultview_idreg",cPar,cChild,false));

	cPar = new []{progetto.Columns["idprogetto"]};
	cChild = new []{rendicontattivitaprogettoprogettoview.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoprogettoview_progetto_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
