/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_appelloattivform_appello"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_appelloattivform_appello: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformappelloview 		=> (MetaTable)Tables["attivformappelloview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable appelloattivform 		=> (MetaTable)Tables["appelloattivform"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_appelloattivform_appello(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_appelloattivform_appello (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_appelloattivform_appello";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_appelloattivform_appello.xsd";

	#region create DataTables
	//////////////////// ATTIVFORMAPPELLOVIEW /////////////////////////////////
	var tattivformappelloview= new MetaTable("attivformappelloview");
	tattivformappelloview.defineColumn("aa", typeof(string),false);
	tattivformappelloview.defineColumn("attivform_ct", typeof(DateTime),false);
	tattivformappelloview.defineColumn("attivform_cu", typeof(string),false);
	tattivformappelloview.defineColumn("attivform_iddidproggrupp", typeof(int));
	tattivformappelloview.defineColumn("attivform_lt", typeof(DateTime),false);
	tattivformappelloview.defineColumn("attivform_lu", typeof(string),false);
	tattivformappelloview.defineColumn("attivform_obbform", typeof(string));
	tattivformappelloview.defineColumn("attivform_obbform_en", typeof(string));
	tattivformappelloview.defineColumn("attivform_sortcode", typeof(int));
	tattivformappelloview.defineColumn("attivform_start", typeof(DateTime));
	tattivformappelloview.defineColumn("attivform_stop", typeof(DateTime));
	tattivformappelloview.defineColumn("attivform_tipovalutaz", typeof(string));
	tattivformappelloview.defineColumn("attivform_title", typeof(string));
	tattivformappelloview.defineColumn("didprog_aa", typeof(string));
	tattivformappelloview.defineColumn("didprog_idsede", typeof(int));
	tattivformappelloview.defineColumn("didprog_title", typeof(string));
	tattivformappelloview.defineColumn("didproggrupp_title", typeof(string));
	tattivformappelloview.defineColumn("dropdown_title", typeof(string),false);
	tattivformappelloview.defineColumn("idattivform", typeof(int),false);
	tattivformappelloview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprog", typeof(int),false);
	tattivformappelloview.defineColumn("iddidproganno", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprogori", typeof(int),false);
	tattivformappelloview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformappelloview.defineColumn("idinsegn", typeof(int),false);
	tattivformappelloview.defineColumn("idinsegninteg", typeof(int));
	tattivformappelloview.defineColumn("idsede", typeof(int),false);
	tattivformappelloview.defineColumn("insegn_codice", typeof(string));
	tattivformappelloview.defineColumn("insegn_denominazione", typeof(string));
	tattivformappelloview.defineColumn("insegninteg_codice", typeof(string));
	tattivformappelloview.defineColumn("insegninteg_denominazione", typeof(string));
	tattivformappelloview.defineColumn("sede_attivform_title", typeof(string));
	tattivformappelloview.defineColumn("sede_title", typeof(string));
	Tables.Add(tattivformappelloview);
	tattivformappelloview.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	//////////////////// APPELLOATTIVFORM /////////////////////////////////
	var tappelloattivform= new MetaTable("appelloattivform");
	tappelloattivform.defineColumn("aa", typeof(string),false);
	tappelloattivform.defineColumn("ct", typeof(DateTime),false);
	tappelloattivform.defineColumn("cu", typeof(string),false);
	tappelloattivform.defineColumn("idappello", typeof(int),false);
	tappelloattivform.defineColumn("idattivform", typeof(int),false);
	tappelloattivform.defineColumn("idcorsostudio", typeof(int),false);
	tappelloattivform.defineColumn("iddidprog", typeof(int),false);
	tappelloattivform.defineColumn("iddidproganno", typeof(int),false);
	tappelloattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tappelloattivform.defineColumn("iddidprogori", typeof(int),false);
	tappelloattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tappelloattivform.defineColumn("lt", typeof(DateTime),false);
	tappelloattivform.defineColumn("lu", typeof(string),false);
	Tables.Add(tappelloattivform);
	tappelloattivform.defineKey("aa", "idappello", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{attivformappelloview.Columns["idattivform"]};
	var cChild = new []{appelloattivform.Columns["idattivform"]};
	Relations.Add(new DataRelation("FK_appelloattivform_attivformappelloview_idattivform",cPar,cChild,false));

	#endregion

}
}
}
