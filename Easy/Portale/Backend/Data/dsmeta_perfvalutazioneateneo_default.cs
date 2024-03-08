
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneateneo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneateneo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoresattach 		=> (MetaTable)Tables["perfvalutazioneateneoresattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoresvalidatori 		=> (MetaTable)Tables["perfvalutazioneateneoresvalidatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfmission 		=> (MetaTable)Tables["perfmission"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneores 		=> (MetaTable)Tables["perfvalutazioneateneores"];

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
public dsmeta_perfvalutazioneateneo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneateneo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneateneo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneateneo_default.xsd";

	#region create DataTables
	//////////////////// PERFVALUTAZIONEATENEORESATTACH /////////////////////////////////
	var tperfvalutazioneateneoresattach= new MetaTable("perfvalutazioneateneoresattach");
	tperfvalutazioneateneoresattach.defineColumn("idattach", typeof(int),false);
	tperfvalutazioneateneoresattach.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneoresattach.defineColumn("idperfvalutazioneateneores", typeof(int),false);
	tperfvalutazioneateneoresattach.defineColumn("idperfvalutazioneateneoresattach", typeof(int),false);
	tperfvalutazioneateneoresattach.defineColumn("title", typeof(string),false);
	tperfvalutazioneateneoresattach.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfvalutazioneateneoresattach);
	tperfvalutazioneateneoresattach.defineKey("idattach", "idperfvalutazioneateneo", "idperfvalutazioneateneores", "idperfvalutazioneateneoresattach");

	//////////////////// PERFVALUTAZIONEATENEORESVALIDATORI /////////////////////////////////
	var tperfvalutazioneateneoresvalidatori= new MetaTable("perfvalutazioneateneoresvalidatori");
	tperfvalutazioneateneoresvalidatori.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("cu", typeof(string),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("idperfmission", typeof(int),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("idperfvalutazioneateneores", typeof(int),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("idvalidatori", typeof(int),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneateneoresvalidatori.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfvalutazioneateneoresvalidatori);
	tperfvalutazioneateneoresvalidatori.defineKey("idperfmission", "idperfvalutazioneateneo", "idperfvalutazioneateneores", "idvalidatori");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// PERFMISSION /////////////////////////////////
	var tperfmission= new MetaTable("perfmission");
	tperfmission.defineColumn("idperfmission", typeof(int),false);
	tperfmission.defineColumn("title", typeof(string));
	Tables.Add(tperfmission);
	tperfmission.defineKey("idperfmission");

	//////////////////// PERFVALUTAZIONEATENEORES /////////////////////////////////
	var tperfvalutazioneateneores= new MetaTable("perfvalutazioneateneores");
	tperfvalutazioneateneores.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneateneores.defineColumn("cu", typeof(string),false);
	tperfvalutazioneateneores.defineColumn("fonte", typeof(string));
	tperfvalutazioneateneores.defineColumn("idperfmission", typeof(int),false);
	tperfvalutazioneateneores.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneores.defineColumn("idperfvalutazioneateneores", typeof(int),false);
	tperfvalutazioneateneores.defineColumn("idreg", typeof(int));
	tperfvalutazioneateneores.defineColumn("indicatore", typeof(string));
	tperfvalutazioneateneores.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneateneores.defineColumn("lu", typeof(string),false);
	tperfvalutazioneateneores.defineColumn("Note", typeof(string));
	tperfvalutazioneateneores.defineColumn("percentualeraggiunta", typeof(decimal));
	tperfvalutazioneateneores.defineColumn("peso", typeof(decimal));
	tperfvalutazioneateneores.defineColumn("target", typeof(string));
	tperfvalutazioneateneores.defineColumn("valoreraggiunto", typeof(string));
	tperfvalutazioneateneores.defineColumn("!idperfmission_perfmission_title", typeof(string));
	tperfvalutazioneateneores.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tperfvalutazioneateneores);
	tperfvalutazioneateneores.defineKey("idperfmission", "idperfvalutazioneateneo", "idperfvalutazioneateneores");

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
	var cChild = new []{perfvalutazioneateneores.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_perfvalutazioneateneo_idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfvalutazioneateneores.Columns["idperfvalutazioneateneo"], perfvalutazioneateneores.Columns["idperfvalutazioneateneores"]};
	cChild = new []{perfvalutazioneateneoresattach.Columns["idperfvalutazioneateneo"], perfvalutazioneateneoresattach.Columns["idperfvalutazioneateneores"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoresattach_perfvalutazioneateneores_idperfvalutazioneateneo-idperfvalutazioneateneores",cPar,cChild,false));

	cPar = new []{perfvalutazioneateneores.Columns["idperfmission"], perfvalutazioneateneores.Columns["idperfvalutazioneateneo"], perfvalutazioneateneores.Columns["idperfvalutazioneateneores"]};
	cChild = new []{perfvalutazioneateneoresvalidatori.Columns["idperfmission"], perfvalutazioneateneoresvalidatori.Columns["idperfvalutazioneateneo"], perfvalutazioneateneoresvalidatori.Columns["idperfvalutazioneateneores"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoresvalidatori_perfvalutazioneateneores_idperfmission-idperfvalutazioneateneo-idperfvalutazioneateneores",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{perfvalutazioneateneores.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_registry_idreg",cPar,cChild,false));

	cPar = new []{perfmission.Columns["idperfmission"]};
	cChild = new []{perfvalutazioneateneores.Columns["idperfmission"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_perfmission_idperfmission",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfvalutazioneateneo.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneo_year_year",cPar,cChild,false));

	#endregion

}
}
}
