
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
[System.Xml.Serialization.XmlRoot("dsmeta_accordoscambiomiporzanno_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_accordoscambiomiporzanno_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzannokind 		=> (MetaTable)Tables["didprogporzannokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accordoscambiomiporzanno 		=> (MetaTable)Tables["accordoscambiomiporzanno"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_accordoscambiomiporzanno_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_accordoscambiomiporzanno_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_accordoscambiomiporzanno_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_accordoscambiomiporzanno_seg.xsd";

	#region create DataTables
	//////////////////// DIDPROGPORZANNOKIND /////////////////////////////////
	var tdidprogporzannokind= new MetaTable("didprogporzannokind");
	tdidprogporzannokind.defineColumn("iddidprogporzannokind", typeof(int),false);
	tdidprogporzannokind.defineColumn("title", typeof(string),false);
	Tables.Add(tdidprogporzannokind);
	tdidprogporzannokind.defineKey("iddidprogporzannokind");

	//////////////////// ACCORDOSCAMBIOMIPORZANNO /////////////////////////////////
	var taccordoscambiomiporzanno= new MetaTable("accordoscambiomiporzanno");
	taccordoscambiomiporzanno.defineColumn("ct", typeof(DateTime),false);
	taccordoscambiomiporzanno.defineColumn("cu", typeof(string),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomi", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomidett", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("idaccordoscambiomiporzanno", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("iddidprogporzannokind", typeof(int),false);
	taccordoscambiomiporzanno.defineColumn("indice", typeof(int));
	taccordoscambiomiporzanno.defineColumn("lt", typeof(DateTime),false);
	taccordoscambiomiporzanno.defineColumn("lu", typeof(string),false);
	Tables.Add(taccordoscambiomiporzanno);
	taccordoscambiomiporzanno.defineKey("idaccordoscambiomi", "idaccordoscambiomidett", "idaccordoscambiomiporzanno", "iddidprogporzannokind");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprogporzannokind.Columns["iddidprogporzannokind"]};
	var cChild = new []{accordoscambiomiporzanno.Columns["iddidprogporzannokind"]};
	Relations.Add(new DataRelation("FK_accordoscambiomiporzanno_didprogporzannokind_iddidprogporzannokind",cPar,cChild,false));

	#endregion

}
}
}
