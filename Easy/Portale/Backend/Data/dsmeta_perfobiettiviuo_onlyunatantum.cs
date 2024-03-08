
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfobiettiviuo_onlyunatantum"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfobiettiviuo_onlyunatantum: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoattach 		=> (MetaTable)Tables["perfobiettiviuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuosoglia 		=> (MetaTable)Tables["perfobiettiviuosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazionepersonaletusciaview 		=> (MetaTable)Tables["perfvalutazionepersonaletusciaview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuo 		=> (MetaTable)Tables["perfobiettiviuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfobiettiviuo_onlyunatantum(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfobiettiviuo_onlyunatantum (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfobiettiviuo_onlyunatantum";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfobiettiviuo_onlyunatantum.xsd";

	#region create DataTables
	//////////////////// PERFOBIETTIVIUOATTACH /////////////////////////////////
	var tperfobiettiviuoattach= new MetaTable("perfobiettiviuoattach");
	tperfobiettiviuoattach.defineColumn("idattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuoattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("title", typeof(string),false);
	Tables.Add(tperfobiettiviuoattach);
	tperfobiettiviuoattach.defineKey("idattach", "idperfobiettiviuo", "idperfobiettiviuoattach", "idperfvalutazioneuo");

	//////////////////// PERFOBIETTIVIUOSOGLIA /////////////////////////////////
	var tperfobiettiviuosoglia= new MetaTable("perfobiettiviuosoglia");
	tperfobiettiviuosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfobiettiviuosoglia.defineColumn("cu", typeof(string),false);
	tperfobiettiviuosoglia.defineColumn("description", typeof(string));
	tperfobiettiviuosoglia.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("idperfobiettiviuosoglia", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfobiettiviuosoglia.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfobiettiviuosoglia.defineColumn("lu", typeof(string),false);
	tperfobiettiviuosoglia.defineColumn("percentuale", typeof(decimal));
	tperfobiettiviuosoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfobiettiviuosoglia);
	tperfobiettiviuosoglia.defineKey("idperfobiettiviuo", "idperfobiettiviuosoglia", "idperfvalutazioneuo");

	//////////////////// PERFVALUTAZIONEPERSONALETUSCIAVIEW /////////////////////////////////
	var tperfvalutazionepersonaletusciaview= new MetaTable("perfvalutazionepersonaletusciaview");
	tperfvalutazionepersonaletusciaview.defineColumn("dropdown_title", typeof(string),false);
	tperfvalutazionepersonaletusciaview.defineColumn("idafferenza", typeof(int),false);
	tperfvalutazionepersonaletusciaview.defineColumn("idperfvalutazionepersonale", typeof(int),false);
	tperfvalutazionepersonaletusciaview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tperfvalutazionepersonaletusciaview);
	tperfvalutazionepersonaletusciaview.defineKey("idafferenza", "idperfvalutazionepersonale", "idreg");

	//////////////////// PERFOBIETTIVIUO /////////////////////////////////
	var tperfobiettiviuo= new MetaTable("perfobiettiviuo");
	tperfobiettiviuo.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuo.defineColumn("ct", typeof(DateTime));
	tperfobiettiviuo.defineColumn("cu", typeof(string));
	tperfobiettiviuo.defineColumn("description", typeof(string));
	tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("idperfvalutazionepersonale", typeof(int));
	tperfobiettiviuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("lt", typeof(DateTime));
	tperfobiettiviuo.defineColumn("lu", typeof(string));
	tperfobiettiviuo.defineColumn("note", typeof(string));
	tperfobiettiviuo.defineColumn("peso", typeof(decimal));
	tperfobiettiviuo.defineColumn("title", typeof(string));
	tperfobiettiviuo.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfobiettiviuo);
	tperfobiettiviuo.defineKey("idperfobiettiviuo", "idperfvalutazioneuo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	var cChild = new []{perfobiettiviuoattach.Columns["idperfobiettiviuo"], perfobiettiviuoattach.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuoattach_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfobiettiviuo.Columns["idperfobiettiviuo"], perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuosoglia.Columns["idperfobiettiviuo"], perfobiettiviuosoglia.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfobiettiviuo_idperfobiettiviuo-idperfvalutazioneuo",cPar,cChild,false));

	cPar = new []{perfvalutazionepersonaletusciaview.Columns["idperfvalutazionepersonale"]};
	cChild = new []{perfobiettiviuo.Columns["idperfvalutazionepersonale"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazionepersonaletusciaview_idperfvalutazionepersonale",cPar,cChild,false));

	#endregion

}
}
}
