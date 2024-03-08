
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
[System.Xml.Serialization.XmlRoot("dsmeta_aoo_princ"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_aoo_princ: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoo 		=> (MetaTable)Tables["aoo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_aoo_princ(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_aoo_princ (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_aoo_princ";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_aoo_princ.xsd";

	#region create DataTables
	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// AOO /////////////////////////////////
	var taoo= new MetaTable("aoo");
	taoo.defineColumn("codiceaooipa", typeof(string));
	taoo.defineColumn("ct", typeof(DateTime),false);
	taoo.defineColumn("cu", typeof(string),false);
	taoo.defineColumn("idaoo", typeof(int),false);
	taoo.defineColumn("idreg", typeof(int));
	taoo.defineColumn("idsede", typeof(int));
	taoo.defineColumn("lt", typeof(DateTime),false);
	taoo.defineColumn("lu", typeof(string),false);
	taoo.defineColumn("title", typeof(string),false);
	Tables.Add(taoo);
	taoo.defineKey("idaoo");

	#endregion


	#region DataRelation creation
	var cPar = new []{sededefaultview.Columns["idsede"]};
	var cChild = new []{aoo.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_aoo_sededefaultview_idsede",cPar,cChild,false));

	#endregion

}
}
}
