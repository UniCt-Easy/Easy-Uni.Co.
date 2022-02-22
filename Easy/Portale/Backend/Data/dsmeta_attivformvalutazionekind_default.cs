
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
[System.Xml.Serialization.XmlRoot("dsmeta_attivformvalutazionekind_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_attivformvalutazionekind_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable valutazionekind 		=> (MetaTable)Tables["valutazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformvalutazionekind 		=> (MetaTable)Tables["attivformvalutazionekind"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_attivformvalutazionekind_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_attivformvalutazionekind_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_attivformvalutazionekind_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_attivformvalutazionekind_default.xsd";

	#region create DataTables
	//////////////////// VALUTAZIONEKIND /////////////////////////////////
	var tvalutazionekind= new MetaTable("valutazionekind");
	tvalutazionekind.defineColumn("active", typeof(string),false);
	tvalutazionekind.defineColumn("ct", typeof(DateTime),false);
	tvalutazionekind.defineColumn("cu", typeof(string),false);
	tvalutazionekind.defineColumn("description", typeof(string));
	tvalutazionekind.defineColumn("idvalutazionekind", typeof(int),false);
	tvalutazionekind.defineColumn("lt", typeof(DateTime),false);
	tvalutazionekind.defineColumn("lu", typeof(string),false);
	tvalutazionekind.defineColumn("sortcode", typeof(int),false);
	tvalutazionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tvalutazionekind);
	tvalutazionekind.defineKey("idvalutazionekind");

	//////////////////// ATTIVFORMVALUTAZIONEKIND /////////////////////////////////
	var tattivformvalutazionekind= new MetaTable("attivformvalutazionekind");
	tattivformvalutazionekind.defineColumn("aa", typeof(string),false);
	tattivformvalutazionekind.defineColumn("ct", typeof(DateTime),false);
	tattivformvalutazionekind.defineColumn("cu", typeof(string),false);
	tattivformvalutazionekind.defineColumn("idattivform", typeof(int),false);
	tattivformvalutazionekind.defineColumn("idcorsostudio", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprog", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidproganno", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprogori", typeof(int),false);
	tattivformvalutazionekind.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformvalutazionekind.defineColumn("idvalutazionekind", typeof(int),false);
	tattivformvalutazionekind.defineColumn("lt", typeof(DateTime),false);
	tattivformvalutazionekind.defineColumn("lu", typeof(string),false);
	Tables.Add(tattivformvalutazionekind);
	tattivformvalutazionekind.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idvalutazionekind");

	#endregion


	#region DataRelation creation
	var cPar = new []{valutazionekind.Columns["idvalutazionekind"]};
	var cChild = new []{attivformvalutazionekind.Columns["idvalutazionekind"]};
	Relations.Add(new DataRelation("FK_attivformvalutazionekind_valutazionekind_idvalutazionekind",cPar,cChild,false));

	#endregion

}
}
}
