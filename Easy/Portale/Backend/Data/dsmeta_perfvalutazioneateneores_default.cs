
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneateneores_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneateneores_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable validatori 		=> (MetaTable)Tables["validatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoresvalidatori 		=> (MetaTable)Tables["perfvalutazioneateneoresvalidatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfmission 		=> (MetaTable)Tables["perfmission"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneores 		=> (MetaTable)Tables["perfvalutazioneateneores"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneateneores_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneateneores_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneateneores_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneateneores_default.xsd";

	#region create DataTables
	//////////////////// VALIDATORI /////////////////////////////////
	var tvalidatori= new MetaTable("validatori");
	tvalidatori.defineColumn("ct", typeof(DateTime));
	tvalidatori.defineColumn("cu", typeof(string));
	tvalidatori.defineColumn("idvalidatori", typeof(int),false);
	tvalidatori.defineColumn("lt", typeof(DateTime));
	tvalidatori.defineColumn("lu", typeof(string));
	tvalidatori.defineColumn("title", typeof(string));
	Tables.Add(tvalidatori);
	tvalidatori.defineKey("idvalidatori");

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

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

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
	tperfvalutazioneateneores.defineColumn("percentualeraggiunta", typeof(decimal));
	tperfvalutazioneateneores.defineColumn("peso", typeof(decimal));
	tperfvalutazioneateneores.defineColumn("target", typeof(string));
	tperfvalutazioneateneores.defineColumn("valoreraggiunto", typeof(string));
	Tables.Add(tperfvalutazioneateneores);
	tperfvalutazioneateneores.defineKey("idperfmission", "idperfvalutazioneateneo", "idperfvalutazioneateneores");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfvalutazioneateneores.Columns["idperfmission"], perfvalutazioneateneores.Columns["idperfvalutazioneateneo"], perfvalutazioneateneores.Columns["idperfvalutazioneateneores"]};
	var cChild = new []{perfvalutazioneateneoresvalidatori.Columns["idperfmission"], perfvalutazioneateneoresvalidatori.Columns["idperfvalutazioneateneo"], perfvalutazioneateneoresvalidatori.Columns["idperfvalutazioneateneores"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoresvalidatori_perfvalutazioneateneores_idperfmission-idperfvalutazioneateneo-idperfvalutazioneateneores",cPar,cChild,false));

	cPar = new []{validatori.Columns["idvalidatori"]};
	cChild = new []{perfvalutazioneateneoresvalidatori.Columns["idvalidatori"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoresvalidatori_validatori_idvalidatori",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazioneateneores.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{perfmission.Columns["idperfmission"]};
	cChild = new []{perfvalutazioneateneores.Columns["idperfmission"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_perfmission_idperfmission",cPar,cChild,false));

	#endregion

}
}
}
