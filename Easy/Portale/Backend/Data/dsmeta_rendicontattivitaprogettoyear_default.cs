
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_rendicontattivitaprogettoyear_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_rendicontattivitaprogettoyear_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettoyear 		=> (MetaTable)Tables["rendicontattivitaprogettoyear"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_rendicontattivitaprogettoyear_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_rendicontattivitaprogettoyear_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_rendicontattivitaprogettoyear_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_rendicontattivitaprogettoyear_default.xsd";

	#region create DataTables
	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// RENDICONTATTIVITAPROGETTOYEAR /////////////////////////////////
	var trendicontattivitaprogettoyear= new MetaTable("rendicontattivitaprogettoyear");
	trendicontattivitaprogettoyear.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idrendicontattivitaprogetto", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idrendicontattivitaprogettoyear", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("idworkpackage", typeof(int),false);
	trendicontattivitaprogettoyear.defineColumn("ore", typeof(int));
	trendicontattivitaprogettoyear.defineColumn("year", typeof(int));
	Tables.Add(trendicontattivitaprogettoyear);
	trendicontattivitaprogettoyear.defineKey("idprogetto", "idrendicontattivitaprogetto", "idrendicontattivitaprogettoyear", "idworkpackage");

	#endregion


	#region DataRelation creation
	var cPar = new []{year.Columns["year"]};
	var cChild = new []{rendicontattivitaprogettoyear.Columns["year"]};
	Relations.Add(new DataRelation("FK_rendicontattivitaprogettoyear_year_year",cPar,cChild,false));

	#endregion

}
}
}