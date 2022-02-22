
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
[System.Xml.Serialization.XmlRoot("dsmeta_attivformproped_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_attivformproped_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformpropedview 		=> (MetaTable)Tables["attivformpropedview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivformproped 		=> (MetaTable)Tables["attivformproped"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_attivformproped_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_attivformproped_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_attivformproped_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_attivformproped_default.xsd";

	#region create DataTables
	//////////////////// ATTIVFORMPROPEDVIEW /////////////////////////////////
	var tattivformpropedview= new MetaTable("attivformpropedview");
	tattivformpropedview.defineColumn("aa", typeof(string),false);
	tattivformpropedview.defineColumn("attivform_ct", typeof(DateTime),false);
	tattivformpropedview.defineColumn("attivform_cu", typeof(string),false);
	tattivformpropedview.defineColumn("attivform_iddidproggrupp", typeof(int));
	tattivformpropedview.defineColumn("attivform_lt", typeof(DateTime),false);
	tattivformpropedview.defineColumn("attivform_lu", typeof(string),false);
	tattivformpropedview.defineColumn("attivform_obbform", typeof(string));
	tattivformpropedview.defineColumn("attivform_obbform_en", typeof(string));
	tattivformpropedview.defineColumn("attivform_sortcode", typeof(int));
	tattivformpropedview.defineColumn("attivform_start", typeof(DateTime));
	tattivformpropedview.defineColumn("attivform_stop", typeof(DateTime));
	tattivformpropedview.defineColumn("attivform_tipovalutaz", typeof(string));
	tattivformpropedview.defineColumn("didproganno_title", typeof(string));
	tattivformpropedview.defineColumn("didprogcurr_title", typeof(string));
	tattivformpropedview.defineColumn("didproggrupp_title", typeof(string));
	tattivformpropedview.defineColumn("didprogori_title", typeof(string));
	tattivformpropedview.defineColumn("didprogporzanno_title", typeof(string));
	tattivformpropedview.defineColumn("dropdown_title", typeof(string),false);
	tattivformpropedview.defineColumn("idattivform", typeof(int),false);
	tattivformpropedview.defineColumn("idcorsostudio", typeof(int),false);
	tattivformpropedview.defineColumn("iddidprog", typeof(int),false);
	tattivformpropedview.defineColumn("iddidproganno", typeof(int),false);
	tattivformpropedview.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformpropedview.defineColumn("iddidprogori", typeof(int),false);
	tattivformpropedview.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformpropedview.defineColumn("idinsegn", typeof(int),false);
	tattivformpropedview.defineColumn("idinsegninteg", typeof(int));
	tattivformpropedview.defineColumn("idsede", typeof(int),false);
	tattivformpropedview.defineColumn("insegn_codice", typeof(string));
	tattivformpropedview.defineColumn("insegn_denominazione", typeof(string));
	tattivformpropedview.defineColumn("insegninteg_codice", typeof(string));
	tattivformpropedview.defineColumn("insegninteg_denominazione", typeof(string));
	tattivformpropedview.defineColumn("title", typeof(string));
	Tables.Add(tattivformpropedview);
	tattivformpropedview.defineKey("idattivform");

	//////////////////// ATTIVFORMPROPED /////////////////////////////////
	var tattivformproped= new MetaTable("attivformproped");
	tattivformproped.defineColumn("aa", typeof(string),false);
	tattivformproped.defineColumn("alternativa", typeof(int),false);
	tattivformproped.defineColumn("ct", typeof(DateTime),false);
	tattivformproped.defineColumn("cu", typeof(string),false);
	tattivformproped.defineColumn("idattivform", typeof(int),false);
	tattivformproped.defineColumn("idattivform_proped", typeof(int),false);
	tattivformproped.defineColumn("idcorsostudio", typeof(int),false);
	tattivformproped.defineColumn("iddidprog", typeof(int),false);
	tattivformproped.defineColumn("iddidproganno", typeof(int),false);
	tattivformproped.defineColumn("iddidprogcurr", typeof(int),false);
	tattivformproped.defineColumn("iddidprogori", typeof(int),false);
	tattivformproped.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivformproped.defineColumn("lt", typeof(DateTime),false);
	tattivformproped.defineColumn("lu", typeof(string),false);
	Tables.Add(tattivformproped);
	tattivformproped.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	#endregion


	#region DataRelation creation
	var cPar = new []{attivformpropedview.Columns["idattivform"]};
	var cChild = new []{attivformproped.Columns["idattivform_proped"]};
	Relations.Add(new DataRelation("FK_attivformproped_attivformpropedview_idattivform_proped",cPar,cChild,false));

	#endregion

}
}
}
