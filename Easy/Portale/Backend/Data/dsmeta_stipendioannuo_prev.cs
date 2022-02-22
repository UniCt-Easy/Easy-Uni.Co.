
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
[System.Xml.Serialization.XmlRoot("dsmeta_stipendioannuo_prev"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_stipendioannuo_prev: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable contrattoprevview 		=> (MetaTable)Tables["contrattoprevview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypersoneview 		=> (MetaTable)Tables["registrypersoneview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_stipendioannuo_prev(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_stipendioannuo_prev (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_stipendioannuo_prev";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_stipendioannuo_prev.xsd";

	#region create DataTables
	//////////////////// CONTRATTOPREVVIEW /////////////////////////////////
	var tcontrattoprevview= new MetaTable("contrattoprevview");
	tcontrattoprevview.defineColumn("contratto_classe", typeof(int));
	tcontrattoprevview.defineColumn("contratto_ct", typeof(DateTime),false);
	tcontrattoprevview.defineColumn("contratto_cu", typeof(string),false);
	tcontrattoprevview.defineColumn("contratto_datarivalutazione", typeof(DateTime));
	tcontrattoprevview.defineColumn("contratto_estremibando", typeof(string));
	tcontrattoprevview.defineColumn("contratto_idinquadramento", typeof(int));
	tcontrattoprevview.defineColumn("contratto_lt", typeof(DateTime),false);
	tcontrattoprevview.defineColumn("contratto_lu", typeof(string),false);
	tcontrattoprevview.defineColumn("contratto_parttime", typeof(decimal));
	tcontrattoprevview.defineColumn("contratto_percentualesufondiateneo", typeof(decimal));
	tcontrattoprevview.defineColumn("contratto_scatto", typeof(int));
	tcontrattoprevview.defineColumn("contratto_start", typeof(DateTime),false);
	tcontrattoprevview.defineColumn("contratto_stop", typeof(DateTime));
	tcontrattoprevview.defineColumn("contratto_tempdef", typeof(string));
	tcontrattoprevview.defineColumn("contratto_tempindet", typeof(string));
	tcontrattoprevview.defineColumn("contrattokind_title", typeof(string));
	tcontrattoprevview.defineColumn("dropdown_title", typeof(string),false);
	tcontrattoprevview.defineColumn("idcontratto", typeof(int),false);
	tcontrattoprevview.defineColumn("idcontrattokind", typeof(int),false);
	tcontrattoprevview.defineColumn("idreg", typeof(int),false);
	tcontrattoprevview.defineColumn("inquadramento_tempdef", typeof(string));
	tcontrattoprevview.defineColumn("inquadramento_title", typeof(string));
	Tables.Add(tcontrattoprevview);
	tcontrattoprevview.defineKey("idcontratto", "idreg");

	//////////////////// REGISTRYPERSONEVIEW /////////////////////////////////
	var tregistrypersoneview= new MetaTable("registrypersoneview");
	tregistrypersoneview.defineColumn("dropdown_title", typeof(string),false);
	tregistrypersoneview.defineColumn("idaccmotivecredit", typeof(string));
	tregistrypersoneview.defineColumn("idaccmotivedebit", typeof(string));
	tregistrypersoneview.defineColumn("idcategory", typeof(string));
	tregistrypersoneview.defineColumn("idcentralizedcategory", typeof(string));
	tregistrypersoneview.defineColumn("idcity", typeof(int));
	tregistrypersoneview.defineColumn("idnation", typeof(int));
	tregistrypersoneview.defineColumn("idreg", typeof(int),false);
	tregistrypersoneview.defineColumn("idregistryclass", typeof(string));
	tregistrypersoneview.defineColumn("idtitle", typeof(string));
	tregistrypersoneview.defineColumn("registry_active", typeof(string));
	tregistrypersoneview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrypersoneview);
	tregistrypersoneview.defineKey("idreg");

	//////////////////// STIPENDIOANNUO /////////////////////////////////
	var tstipendioannuo= new MetaTable("stipendioannuo");
	tstipendioannuo.defineColumn("caricoente", typeof(decimal));
	tstipendioannuo.defineColumn("ct", typeof(DateTime));
	tstipendioannuo.defineColumn("cu", typeof(string));
	tstipendioannuo.defineColumn("idcontratto", typeof(int),false);
	tstipendioannuo.defineColumn("idreg", typeof(int),false);
	tstipendioannuo.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuo.defineColumn("irap", typeof(decimal));
	tstipendioannuo.defineColumn("lordo", typeof(decimal));
	tstipendioannuo.defineColumn("lt", typeof(DateTime));
	tstipendioannuo.defineColumn("lu", typeof(string));
	tstipendioannuo.defineColumn("totale", typeof(decimal));
	tstipendioannuo.defineColumn("year", typeof(int),false);
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idcontratto", "idreg", "idstipendioannuo", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{contrattoprevview.Columns["idcontratto"]};
	var cChild = new []{stipendioannuo.Columns["idcontratto"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_contrattoprevview_idcontratto",cPar,cChild,false));

	cPar = new []{registrypersoneview.Columns["idreg"]};
	cChild = new []{stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_registrypersoneview_idreg",cPar,cChild,false));

	#endregion

}
}
}
