
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace GeneraLiveUpdateForServices {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("genconfig"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class genconfig: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione Annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable config 		=> Tables["config"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public genconfig(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected genconfig (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "genconfig";
	Prefix = "";
	Namespace = "http://tempuri.org/genconfig.xsd";

	#region create DataTables
	//////////////////// CONFIG /////////////////////////////////
	var tconfig= new DataTable("config");
	tconfig.Columns.Add( new DataColumn("dirdiff", typeof(string)));
	tconfig.Columns.Add( new DataColumn("diruff_main", typeof(string)));
	tconfig.Columns.Add( new DataColumn("dirweb_main", typeof(string)));
	Tables.Add(tconfig);

	#endregion

}
}
}
