
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneateneo_obiettivi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneateneo_obiettivi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoobiettivosdgoals 		=> (MetaTable)Tables["perfateneoobiettivosdgoals"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoindicatoreattach 		=> (MetaTable)Tables["perfateneoindicatoreattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaperfateneoindicatore 		=> (MetaTable)Tables["strutturaperfateneoindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneostakeholderperfateneoindicatore 		=> (MetaTable)Tables["perfateneostakeholderperfateneoindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoindicatore 		=> (MetaTable)Tables["perfateneoindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfmission 		=> (MetaTable)Tables["perfmission"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoobiettivo 		=> (MetaTable)Tables["perfateneoobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneo 		=> (MetaTable)Tables["perfvalutazioneateneo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneateneo_obiettivi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneateneo_obiettivi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneateneo_obiettivi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneateneo_obiettivi.xsd";

	#region create DataTables
	//////////////////// PERFATENEOOBIETTIVOSDGOALS /////////////////////////////////
	var tperfateneoobiettivosdgoals= new MetaTable("perfateneoobiettivosdgoals");
	tperfateneoobiettivosdgoals.defineColumn("ct", typeof(DateTime),false);
	tperfateneoobiettivosdgoals.defineColumn("cu", typeof(string),false);
	tperfateneoobiettivosdgoals.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneoobiettivosdgoals.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneoobiettivosdgoals.defineColumn("idsdgoals", typeof(int),false);
	tperfateneoobiettivosdgoals.defineColumn("lt", typeof(DateTime),false);
	tperfateneoobiettivosdgoals.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfateneoobiettivosdgoals);
	tperfateneoobiettivosdgoals.defineKey("idperfateneoobiettivo", "idperfvalutazioneateneo", "idsdgoals");

	//////////////////// PERFATENEOINDICATOREATTACH /////////////////////////////////
	var tperfateneoindicatoreattach= new MetaTable("perfateneoindicatoreattach");
	tperfateneoindicatoreattach.defineColumn("ct", typeof(DateTime),false);
	tperfateneoindicatoreattach.defineColumn("cu", typeof(string),false);
	tperfateneoindicatoreattach.defineColumn("idattach", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfateneoindicatore", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfateneoindicatoreattach", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneoindicatoreattach.defineColumn("lt", typeof(DateTime),false);
	tperfateneoindicatoreattach.defineColumn("lu", typeof(string),false);
	tperfateneoindicatoreattach.defineColumn("title", typeof(string));
	Tables.Add(tperfateneoindicatoreattach);
	tperfateneoindicatoreattach.defineKey("idattach", "idperfateneoindicatore", "idperfateneoindicatoreattach", "idperfateneoobiettivo", "idperfvalutazioneateneo");

	//////////////////// STRUTTURAPERFATENEOINDICATORE /////////////////////////////////
	var tstrutturaperfateneoindicatore= new MetaTable("strutturaperfateneoindicatore");
	tstrutturaperfateneoindicatore.defineColumn("ct", typeof(DateTime),false);
	tstrutturaperfateneoindicatore.defineColumn("cu", typeof(string),false);
	tstrutturaperfateneoindicatore.defineColumn("idperfateneoindicatore", typeof(int),false);
	tstrutturaperfateneoindicatore.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tstrutturaperfateneoindicatore.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tstrutturaperfateneoindicatore.defineColumn("idstruttura", typeof(int),false);
	tstrutturaperfateneoindicatore.defineColumn("lt", typeof(DateTime),false);
	tstrutturaperfateneoindicatore.defineColumn("lu", typeof(string),false);
	Tables.Add(tstrutturaperfateneoindicatore);
	tstrutturaperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfvalutazioneateneo", "idstruttura");

	//////////////////// PERFATENEOSTAKEHOLDERPERFATENEOINDICATORE /////////////////////////////////
	var tperfateneostakeholderperfateneoindicatore= new MetaTable("perfateneostakeholderperfateneoindicatore");
	tperfateneostakeholderperfateneoindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("cu", typeof(string),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfateneoindicatore", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfateneostakeholder", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfateneostakeholderperfateneoindicatore.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfateneostakeholderperfateneoindicatore);
	tperfateneostakeholderperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfateneostakeholder", "idperfvalutazioneateneo");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

	//////////////////// PERFATENEOINDICATORE /////////////////////////////////
	var tperfateneoindicatore= new MetaTable("perfateneoindicatore");
	tperfateneoindicatore.defineColumn("codice", typeof(string));
	tperfateneoindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfateneoindicatore.defineColumn("cu", typeof(string),false);
	tperfateneoindicatore.defineColumn("fonte", typeof(string));
	tperfateneoindicatore.defineColumn("idperfateneoindicatore", typeof(int),false);
	tperfateneoindicatore.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneoindicatore.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneoindicatore.defineColumn("idreg", typeof(int));
	tperfateneoindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfateneoindicatore.defineColumn("lu", typeof(string),false);
	tperfateneoindicatore.defineColumn("Note", typeof(string));
	tperfateneoindicatore.defineColumn("percentualeraggiunta", typeof(string));
	tperfateneoindicatore.defineColumn("target", typeof(string));
	tperfateneoindicatore.defineColumn("titolo", typeof(string));
	tperfateneoindicatore.defineColumn("valoreraggiunto", typeof(string));
	tperfateneoindicatore.defineColumn("!idreg_getregistrydocentiamministrativi_surname", typeof(string));
	tperfateneoindicatore.defineColumn("!idreg_getregistrydocentiamministrativi_forename", typeof(string));
	Tables.Add(tperfateneoindicatore);
	tperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfvalutazioneateneo");

	//////////////////// PERFMISSION /////////////////////////////////
	var tperfmission= new MetaTable("perfmission");
	tperfmission.defineColumn("active", typeof(string));
	tperfmission.defineColumn("idperfmission", typeof(int),false);
	tperfmission.defineColumn("title", typeof(string));
	Tables.Add(tperfmission);
	tperfmission.defineKey("idperfmission");

	//////////////////// PERFATENEOOBIETTIVO /////////////////////////////////
	var tperfateneoobiettivo= new MetaTable("perfateneoobiettivo");
	tperfateneoobiettivo.defineColumn("codice", typeof(string));
	tperfateneoobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfateneoobiettivo.defineColumn("cu", typeof(string),false);
	tperfateneoobiettivo.defineColumn("descrizione", typeof(string));
	tperfateneoobiettivo.defineColumn("dimensionivalorepubblico", typeof(string));
	tperfateneoobiettivo.defineColumn("idperfateneoobiettivo", typeof(int),false);
	tperfateneoobiettivo.defineColumn("idperfmission", typeof(int),false);
	tperfateneoobiettivo.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfateneoobiettivo.defineColumn("lt", typeof(DateTime),false);
	tperfateneoobiettivo.defineColumn("lu", typeof(string),false);
	tperfateneoobiettivo.defineColumn("percentualeraggiunta", typeof(string));
	tperfateneoobiettivo.defineColumn("tipologia", typeof(string));
	tperfateneoobiettivo.defineColumn("!idperfmission_perfmission_title", typeof(string));
	tperfateneoobiettivo.defineColumn("!perfateneoindicatore", typeof(string));
	Tables.Add(tperfateneoobiettivo);
	tperfateneoobiettivo.defineKey("idperfateneoobiettivo", "idperfvalutazioneateneo");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFVALUTAZIONEATENEO /////////////////////////////////
	var tperfvalutazioneateneo= new MetaTable("perfvalutazioneateneo");
	tperfvalutazioneateneo.defineColumn("calcoloautomatico", typeof(string));
	tperfvalutazioneateneo.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneateneo.defineColumn("cu", typeof(string),false);
	tperfvalutazioneateneo.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneo.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneateneo.defineColumn("lu", typeof(string),false);
	tperfvalutazioneateneo.defineColumn("performance", typeof(decimal));
	tperfvalutazioneateneo.defineColumn("year", typeof(int));
	Tables.Add(tperfvalutazioneateneo);
	tperfvalutazioneateneo.defineKey("idperfvalutazioneateneo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazioneateneo.Columns["idperfvalutazioneateneo"]};
	var cChild = new []{perfateneoobiettivo.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneoobiettivo_perfvalutazioneateneo_idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfateneoobiettivo.Columns["idperfateneoobiettivo"], perfateneoobiettivo.Columns["idperfvalutazioneateneo"]};
	cChild = new []{perfateneoobiettivosdgoals.Columns["idperfateneoobiettivo"], perfateneoobiettivosdgoals.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneoobiettivosdgoals_perfateneoobiettivo_idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfateneoobiettivo.Columns["idperfateneoobiettivo"], perfateneoobiettivo.Columns["idperfvalutazioneateneo"]};
	cChild = new []{perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatore_perfateneoobiettivo_idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfateneoindicatore.Columns["idperfateneoindicatore"], perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	cChild = new []{perfateneoindicatoreattach.Columns["idperfateneoindicatore"], perfateneoindicatoreattach.Columns["idperfateneoobiettivo"], perfateneoindicatoreattach.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatoreattach_perfateneoindicatore_idperfateneoindicatore-idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfateneoindicatore.Columns["idperfateneoindicatore"], perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	cChild = new []{strutturaperfateneoindicatore.Columns["idperfateneoindicatore"], strutturaperfateneoindicatore.Columns["idperfateneoobiettivo"], strutturaperfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_strutturaperfateneoindicatore_perfateneoindicatore_idperfateneoindicatore-idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfateneoindicatore.Columns["idperfateneoindicatore"], perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	cChild = new []{perfateneostakeholderperfateneoindicatore.Columns["idperfateneoindicatore"], perfateneostakeholderperfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneostakeholderperfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneostakeholderperfateneoindicatore_perfateneoindicatore_idperfateneoindicatore-idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{perfateneoindicatore.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatore_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

	cPar = new []{perfmission.Columns["idperfmission"]};
	cChild = new []{perfateneoobiettivo.Columns["idperfmission"]};
	Relations.Add(new DataRelation("FK_perfateneoobiettivo_perfmission_idperfmission",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazioneateneo.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneo_year_year",cPar,cChild,false));

	#endregion

}
}
}
