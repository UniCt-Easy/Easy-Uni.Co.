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
[System.Xml.Serialization.XmlRoot("dsmeta_perfobiettiviuo_onlyunatantumpunteggio"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfobiettiviuo_onlyunatantumpunteggio: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuoattach 		=> (MetaTable)Tables["perfobiettiviuoattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuosoglia 		=> (MetaTable)Tables["perfobiettiviuosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneuo 		=> (MetaTable)Tables["perfvalutazioneuo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfobiettiviuo 		=> (MetaTable)Tables["perfobiettiviuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfobiettiviuo_onlyunatantumpunteggio(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfobiettiviuo_onlyunatantumpunteggio (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfobiettiviuo_onlyunatantumpunteggio";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfobiettiviuo_onlyunatantumpunteggio.xsd";

	#region create DataTables
	//////////////////// PERFOBIETTIVIUOATTACH /////////////////////////////////
	var tperfobiettiviuoattach= new MetaTable("perfobiettiviuoattach");
	tperfobiettiviuoattach.defineColumn("ct", typeof(DateTime));
	tperfobiettiviuoattach.defineColumn("cu", typeof(string));
	tperfobiettiviuoattach.defineColumn("idattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfobiettiviuoattach", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuoattach.defineColumn("lt", typeof(DateTime));
	tperfobiettiviuoattach.defineColumn("lu", typeof(string));
	tperfobiettiviuoattach.defineColumn("title", typeof(string),false);
	Tables.Add(tperfobiettiviuoattach);
	tperfobiettiviuoattach.defineKey("idattach", "idperfobiettiviuo", "idperfobiettiviuoattach", "idperfvalutazioneuo");

	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

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

	//////////////////// PERFVALUTAZIONEUO /////////////////////////////////
	var tperfvalutazioneuo= new MetaTable("perfvalutazioneuo");
	tperfvalutazioneuo.defineColumn("completamentopsauo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("completamentopsuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("cu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("idperfschedastatus", typeof(int));
	tperfvalutazioneuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfvalutazioneuo.defineColumn("idreg_appr", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_comp", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_compobborg", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_create", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_val", typeof(int));
	tperfvalutazioneuo.defineColumn("idreg_valobborg", typeof(int));
	tperfvalutazioneuo.defineColumn("idstruttura", typeof(int),false);
	tperfvalutazioneuo.defineColumn("indicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneuo.defineColumn("lu", typeof(string),false);
	tperfvalutazioneuo.defineColumn("motivazione", typeof(string));
	tperfvalutazioneuo.defineColumn("obiettiviindividuali", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoindicatori", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoobiettivi", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoprogaltreuo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("pesoproguo", typeof(decimal));
	tperfvalutazioneuo.defineColumn("risultato", typeof(decimal));
	tperfvalutazioneuo.defineColumn("year", typeof(int),false);
	Tables.Add(tperfvalutazioneuo);
	tperfvalutazioneuo.defineKey("idperfvalutazioneuo", "idstruttura", "year");

	//////////////////// PERFOBIETTIVIUO /////////////////////////////////
	var tperfobiettiviuo= new MetaTable("perfobiettiviuo");
	tperfobiettiviuo.defineColumn("completamento", typeof(decimal));
	tperfobiettiviuo.defineColumn("ct", typeof(DateTime));
	tperfobiettiviuo.defineColumn("cu", typeof(string));
	tperfobiettiviuo.defineColumn("description", typeof(string));
	tperfobiettiviuo.defineColumn("forzapunteggio", typeof(string));
	tperfobiettiviuo.defineColumn("idperfobiettiviuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("idperfvalutazionepersonale", typeof(int));
	tperfobiettiviuo.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfobiettiviuo.defineColumn("lt", typeof(DateTime));
	tperfobiettiviuo.defineColumn("lu", typeof(string));
	tperfobiettiviuo.defineColumn("note", typeof(string));
	tperfobiettiviuo.defineColumn("peso", typeof(decimal));
	tperfobiettiviuo.defineColumn("punteggio", typeof(int));
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

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfobiettiviuosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuosoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{perfvalutazioneuo.Columns["idperfvalutazioneuo"]};
	cChild = new []{perfobiettiviuo.Columns["idperfvalutazioneuo"]};
	Relations.Add(new DataRelation("FK_perfobiettiviuo_perfvalutazioneuo_idperfvalutazioneuo",cPar,cChild,false));

	#endregion

}
}
}
