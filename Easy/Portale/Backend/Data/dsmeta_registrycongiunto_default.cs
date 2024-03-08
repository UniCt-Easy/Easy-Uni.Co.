
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
[System.Xml.Serialization.XmlRoot("dsmeta_registrycongiunto_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_registrycongiunto_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrydefaultview 		=> (MetaTable)Tables["registrydefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable congiuntokind 		=> (MetaTable)Tables["congiuntokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrycongiunto 		=> (MetaTable)Tables["registrycongiunto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_registrycongiunto_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_registrycongiunto_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_registrycongiunto_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_registrycongiunto_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYDEFAULTVIEW /////////////////////////////////
	var tregistrydefaultview= new MetaTable("registrydefaultview");
	tregistrydefaultview.defineColumn("dropdown_title", typeof(string),false);
	tregistrydefaultview.defineColumn("idreg", typeof(int),false);
	tregistrydefaultview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrydefaultview);
	tregistrydefaultview.defineKey("idreg");

	//////////////////// CONGIUNTOKIND /////////////////////////////////
	var tcongiuntokind= new MetaTable("congiuntokind");
	tcongiuntokind.defineColumn("active", typeof(string));
	tcongiuntokind.defineColumn("idcongiuntokind", typeof(int),false);
	tcongiuntokind.defineColumn("title", typeof(string));
	Tables.Add(tcongiuntokind);
	tcongiuntokind.defineKey("idcongiuntokind");

	//////////////////// REGISTRYCONGIUNTO /////////////////////////////////
	var tregistrycongiunto= new MetaTable("registrycongiunto");
	tregistrycongiunto.defineColumn("ct", typeof(DateTime),false);
	tregistrycongiunto.defineColumn("cu", typeof(string),false);
	tregistrycongiunto.defineColumn("idcongiuntokind", typeof(int));
	tregistrycongiunto.defineColumn("idreg", typeof(int),false);
	tregistrycongiunto.defineColumn("idreg_parente", typeof(int),false);
	tregistrycongiunto.defineColumn("idregistrycongiunto", typeof(int),false);
	tregistrycongiunto.defineColumn("lt", typeof(DateTime),false);
	tregistrycongiunto.defineColumn("lu", typeof(string),false);
	Tables.Add(tregistrycongiunto);
	tregistrycongiunto.defineKey("idreg", "idreg_parente", "idregistrycongiunto");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrydefaultview.Columns["idreg"]};
	var cChild = new []{registrycongiunto.Columns["idreg_parente"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_registrydefaultview_idreg_parente",cPar,cChild,false));

	cPar = new []{congiuntokind.Columns["idcongiuntokind"]};
	cChild = new []{registrycongiunto.Columns["idcongiuntokind"]};
	Relations.Add(new DataRelation("FK_registrycongiunto_congiuntokind_idcongiuntokind",cPar,cChild,false));

	#endregion

}
}
}
