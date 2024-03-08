
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneateneores_consoglie"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfvalutazioneateneores_consoglie: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable validatori 		=> (MetaTable)Tables["validatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoresvalidatori 		=> (MetaTable)Tables["perfvalutazioneateneoresvalidatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoressoglia 		=> (MetaTable)Tables["perfvalutazioneateneoressoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneoresattach 		=> (MetaTable)Tables["perfvalutazioneateneoresattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getdocentiamministrativiresponsabilidefaultview 		=> (MetaTable)Tables["getdocentiamministrativiresponsabilidefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfmissiondefaultview 		=> (MetaTable)Tables["perfmissiondefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneores 		=> (MetaTable)Tables["perfvalutazioneateneores"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneateneores_consoglie(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneateneores_consoglie (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneateneores_consoglie";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneateneores_consoglie.xsd";

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

	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFVALUTAZIONEATENEORESSOGLIA /////////////////////////////////
	var tperfvalutazioneateneoressoglia= new MetaTable("perfvalutazioneateneoressoglia");
	tperfvalutazioneateneoressoglia.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneateneoressoglia.defineColumn("cu", typeof(string),false);
	tperfvalutazioneateneoressoglia.defineColumn("description", typeof(string));
	tperfvalutazioneateneoressoglia.defineColumn("idperfmission", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfvalutazioneateneoressoglia.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("idperfvalutazioneateneores", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("idperfvalutazioneateneoressoglia", typeof(int),false);
	tperfvalutazioneateneoressoglia.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneateneoressoglia.defineColumn("lu", typeof(string),false);
	tperfvalutazioneateneoressoglia.defineColumn("percentuale", typeof(decimal));
	tperfvalutazioneateneoressoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfvalutazioneateneoressoglia);
	tperfvalutazioneateneoressoglia.defineKey("idperfmission", "idperfvalutazioneateneo", "idperfvalutazioneateneores", "idperfvalutazioneateneoressoglia");

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

	//////////////////// GETDOCENTIAMMINISTRATIVIRESPONSABILIDEFAULTVIEW /////////////////////////////////
	var tgetdocentiamministrativiresponsabilidefaultview= new MetaTable("getdocentiamministrativiresponsabilidefaultview");
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("idreg", typeof(int),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("ruolo", typeof(string),false);
	tgetdocentiamministrativiresponsabilidefaultview.defineColumn("struttura", typeof(string),false);
	Tables.Add(tgetdocentiamministrativiresponsabilidefaultview);
	tgetdocentiamministrativiresponsabilidefaultview.defineKey("idreg", "ruolo", "struttura");

	//////////////////// PERFMISSIONDEFAULTVIEW /////////////////////////////////
	var tperfmissiondefaultview= new MetaTable("perfmissiondefaultview");
	tperfmissiondefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfmissiondefaultview.defineColumn("idperfmission", typeof(int),false);
	tperfmissiondefaultview.defineColumn("perfmission_active", typeof(string));
	tperfmissiondefaultview.defineColumn("perfmission_ct", typeof(DateTime));
	tperfmissiondefaultview.defineColumn("perfmission_cu", typeof(string));
	tperfmissiondefaultview.defineColumn("perfmission_lt", typeof(DateTime));
	tperfmissiondefaultview.defineColumn("perfmission_lu", typeof(string));
	tperfmissiondefaultview.defineColumn("title", typeof(string));
	Tables.Add(tperfmissiondefaultview);
	tperfmissiondefaultview.defineKey("idperfmission");

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

	cPar = new []{perfvalutazioneateneores.Columns["idperfmission"], perfvalutazioneateneores.Columns["idperfvalutazioneateneo"], perfvalutazioneateneores.Columns["idperfvalutazioneateneores"]};
	cChild = new []{perfvalutazioneateneoressoglia.Columns["idperfmission"], perfvalutazioneateneoressoglia.Columns["idperfvalutazioneateneo"], perfvalutazioneateneoressoglia.Columns["idperfvalutazioneateneores"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoressoglia_perfvalutazioneateneores_idperfmission-idperfvalutazioneateneo-idperfvalutazioneateneores",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfvalutazioneateneoressoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoressoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{perfvalutazioneateneores.Columns["idperfvalutazioneateneo"], perfvalutazioneateneores.Columns["idperfvalutazioneateneores"]};
	cChild = new []{perfvalutazioneateneoresattach.Columns["idperfvalutazioneateneo"], perfvalutazioneateneoresattach.Columns["idperfvalutazioneateneores"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneoresattach_perfvalutazioneateneores_idperfvalutazioneateneo-idperfvalutazioneateneores",cPar,cChild,false));

	cPar = new []{getdocentiamministrativiresponsabilidefaultview.Columns["idreg"]};
	cChild = new []{perfvalutazioneateneores.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_getdocentiamministrativiresponsabilidefaultview_idreg",cPar,cChild,false));

	cPar = new []{perfmissiondefaultview.Columns["idperfmission"]};
	cChild = new []{perfvalutazioneateneores.Columns["idperfmission"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneores_perfmissiondefaultview_idperfmission",cPar,cChild,false));

	#endregion

}
}
}
