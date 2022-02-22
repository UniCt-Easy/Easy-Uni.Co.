
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
[System.Xml.Serialization.XmlRoot("dsmeta_bandodsiscr_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_bandodsiscr_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscresitokind 		=> (MetaTable)Tables["bandodsiscresitokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscresito 		=> (MetaTable)Tables["bandodsiscresito"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accreditokind 		=> (MetaTable)Tables["accreditokind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable bandodsiscr 		=> (MetaTable)Tables["bandodsiscr"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_bandodsiscr_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_bandodsiscr_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_bandodsiscr_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_bandodsiscr_seganagstu.xsd";

	#region create DataTables
	//////////////////// BANDODSISCRESITOKIND /////////////////////////////////
	var tbandodsiscresitokind= new MetaTable("bandodsiscresitokind");
	tbandodsiscresitokind.defineColumn("idbandodsiscresitokind", typeof(int),false);
	tbandodsiscresitokind.defineColumn("title", typeof(string),false);
	Tables.Add(tbandodsiscresitokind);
	tbandodsiscresitokind.defineKey("idbandodsiscresitokind");

	//////////////////// BANDODSISCRESITO /////////////////////////////////
	var tbandodsiscresito= new MetaTable("bandodsiscresito");
	tbandodsiscresito.defineColumn("ct", typeof(DateTime),false);
	tbandodsiscresito.defineColumn("cu", typeof(string),false);
	tbandodsiscresito.defineColumn("idbandods", typeof(int),false);
	tbandodsiscresito.defineColumn("idbandodsiscr", typeof(int),false);
	tbandodsiscresito.defineColumn("idbandodsiscresito", typeof(int),false);
	tbandodsiscresito.defineColumn("idbandodsiscresitokind", typeof(int));
	tbandodsiscresito.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsiscresito.defineColumn("idiscrizione", typeof(int),false);
	tbandodsiscresito.defineColumn("idreg_studenti", typeof(int),false);
	tbandodsiscresito.defineColumn("lt", typeof(DateTime),false);
	tbandodsiscresito.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandodsiscresito);
	tbandodsiscresito.defineKey("idbandods", "idbandodsiscr", "idbandodsiscresito", "idbandodsservizio", "idiscrizione", "idreg_studenti");

	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// ACCREDITOKIND /////////////////////////////////
	var taccreditokind= new MetaTable("accreditokind");
	taccreditokind.defineColumn("idaccreditokind", typeof(int),false);
	taccreditokind.defineColumn("title", typeof(string),false);
	Tables.Add(taccreditokind);
	taccreditokind.defineKey("idaccreditokind");

	//////////////////// BANDODSISCR /////////////////////////////////
	var tbandodsiscr= new MetaTable("bandodsiscr");
	tbandodsiscr.defineColumn("cfbonus", typeof(decimal));
	tbandodsiscr.defineColumn("ct", typeof(DateTime),false);
	tbandodsiscr.defineColumn("cu", typeof(string),false);
	tbandodsiscr.defineColumn("idaccreditokind", typeof(int));
	tbandodsiscr.defineColumn("idbandods", typeof(int),false);
	tbandodsiscr.defineColumn("idbandodsiscr", typeof(int),false);
	tbandodsiscr.defineColumn("idbandodsservizio", typeof(int),false);
	tbandodsiscr.defineColumn("idiscrizione", typeof(int),false);
	tbandodsiscr.defineColumn("idreg_studenti", typeof(int),false);
	tbandodsiscr.defineColumn("lt", typeof(DateTime),false);
	tbandodsiscr.defineColumn("lu", typeof(string),false);
	Tables.Add(tbandodsiscr);
	tbandodsiscr.defineKey("idbandods", "idbandodsiscr", "idbandodsservizio", "idiscrizione", "idreg_studenti");

	#endregion


	#region DataRelation creation
	var cPar = new []{bandodsiscr.Columns["idbandods"], bandodsiscr.Columns["idbandodsiscr"], bandodsiscr.Columns["idbandodsservizio"], bandodsiscr.Columns["idiscrizione"], bandodsiscr.Columns["idreg_studenti"]};
	var cChild = new []{bandodsiscresito.Columns["idbandods"], bandodsiscresito.Columns["idbandodsiscr"], bandodsiscresito.Columns["idbandodsservizio"], bandodsiscresito.Columns["idiscrizione"], bandodsiscresito.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_bandodsiscresito_bandodsiscr_idbandods-idbandodsiscr-idbandodsservizio-idiscrizione-idreg_studenti",cPar,cChild,false));

	cPar = new []{bandodsiscresitokind.Columns["idbandodsiscresitokind"]};
	cChild = new []{bandodsiscresito.Columns["idbandodsiscresitokind"]};
	Relations.Add(new DataRelation("FK_bandodsiscresito_bandodsiscresitokind_idbandodsiscresitokind",cPar,cChild,false));

	cPar = new []{registrystudentiview.Columns["idreg"]};
	cChild = new []{bandodsiscr.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_bandodsiscr_registrystudentiview_idreg_studenti",cPar,cChild,false));

	cPar = new []{accreditokind.Columns["idaccreditokind"]};
	cChild = new []{bandodsiscr.Columns["idaccreditokind"]};
	Relations.Add(new DataRelation("FK_bandodsiscr_accreditokind_idaccreditokind",cPar,cChild,false));

	#endregion

}
}
}
