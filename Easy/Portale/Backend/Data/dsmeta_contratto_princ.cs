
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
[System.Xml.Serialization.XmlRoot("dsmeta_contratto_princ"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_contratto_princ: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattokind 		=> (MetaTable)Tables["contrattokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contratto 		=> (MetaTable)Tables["contratto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_contratto_princ(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_contratto_princ (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_contratto_princ";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_contratto_princ.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// CONTRATTOKIND /////////////////////////////////
	var tcontrattokind= new MetaTable("contrattokind");
	tcontrattokind.defineColumn("description", typeof(string));
	tcontrattokind.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattokind.defineColumn("title", typeof(string),false);
	Tables.Add(tcontrattokind);
	tcontrattokind.defineKey("idcontrattokind");

	//////////////////// CONTRATTO /////////////////////////////////
	var tcontratto= new MetaTable("contratto");
	tcontratto.defineColumn("ct", typeof(DateTime),false);
	tcontratto.defineColumn("cu", typeof(string),false);
	tcontratto.defineColumn("estremibando", typeof(string));
	tcontratto.defineColumn("idcontratto", typeof(int),false);
	tcontratto.defineColumn("idcontrattokind", typeof(int),false);
	tcontratto.defineColumn("idreg", typeof(int),false);
	tcontratto.defineColumn("lt", typeof(DateTime),false);
	tcontratto.defineColumn("lu", typeof(string),false);
	tcontratto.defineColumn("start", typeof(DateTime),false);
	tcontratto.defineColumn("stop", typeof(DateTime));
	tcontratto.defineColumn("tempdef", typeof(string),false);
	tcontratto.defineColumn("tempindet", typeof(string),false);
	Tables.Add(tcontratto);
	tcontratto.defineKey("idcontratto");

	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{contratto.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_contratto_registry_idreg",cPar,cChild,false));

	cPar = new []{contrattokind.Columns["idcontrattokind"]};
	cChild = new []{contratto.Columns["idcontrattokind"]};
	Relations.Add(new DataRelation("FK_contratto_contrattokind_idcontrattokind",cPar,cChild,false));

	#endregion

}
}
}
