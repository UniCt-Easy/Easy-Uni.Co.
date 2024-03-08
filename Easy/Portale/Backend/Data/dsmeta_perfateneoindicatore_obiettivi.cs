
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfateneoindicatore_obiettivi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfateneoindicatore_obiettivi: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaperfateneoindicatore 		=> (MetaTable)Tables["strutturaperfateneoindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneostakeholder 		=> (MetaTable)Tables["perfateneostakeholder"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneostakeholderperfateneoindicatore 		=> (MetaTable)Tables["perfateneostakeholderperfateneoindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoindicatoreattach 		=> (MetaTable)Tables["perfateneoindicatoreattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativinomcognview 		=> (MetaTable)Tables["getregistrydocentiamministrativinomcognview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfateneoindicatore 		=> (MetaTable)Tables["perfateneoindicatore"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfateneoindicatore_obiettivi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfateneoindicatore_obiettivi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfateneoindicatore_obiettivi";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfateneoindicatore_obiettivi.xsd";

	#region create DataTables
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idreg_appr", typeof(int));
	tstruttura.defineColumn("idreg_resp", typeof(int));
	tstruttura.defineColumn("idreg_valut", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string));
	tstruttura.defineColumn("lt", typeof(DateTime),false);
	tstruttura.defineColumn("lu", typeof(string),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("pesoindicatori", typeof(decimal));
	tstruttura.defineColumn("pesoobiettivi", typeof(decimal));
	tstruttura.defineColumn("pesoprogaltreuo", typeof(decimal));
	tstruttura.defineColumn("pesoproguo", typeof(decimal));
	tstruttura.defineColumn("telefono", typeof(string));
	tstruttura.defineColumn("title", typeof(string));
	tstruttura.defineColumn("title_en", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

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
	tstrutturaperfateneoindicatore.defineColumn("!idstruttura_struttura_title", typeof(string));
	tstrutturaperfateneoindicatore.defineColumn("!idstruttura_registry_title", typeof(string));
	Tables.Add(tstrutturaperfateneoindicatore);
	tstrutturaperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfvalutazioneateneo", "idstruttura");

	//////////////////// PERFATENEOSTAKEHOLDER /////////////////////////////////
	var tperfateneostakeholder= new MetaTable("perfateneostakeholder");
	tperfateneostakeholder.defineColumn("ct", typeof(DateTime),false);
	tperfateneostakeholder.defineColumn("cu", typeof(string),false);
	tperfateneostakeholder.defineColumn("idperfateneostakeholder", typeof(int),false);
	tperfateneostakeholder.defineColumn("lt", typeof(DateTime),false);
	tperfateneostakeholder.defineColumn("lu", typeof(string),false);
	tperfateneostakeholder.defineColumn("title", typeof(string));
	Tables.Add(tperfateneostakeholder);
	tperfateneostakeholder.defineKey("idperfateneostakeholder");

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

	//////////////////// ATTACH /////////////////////////////////
	var tattach= new MetaTable("attach");
	tattach.defineColumn("attachment", typeof(Byte[]));
	tattach.defineColumn("ct", typeof(DateTime),false);
	tattach.defineColumn("cu", typeof(string),false);
	tattach.defineColumn("filename", typeof(string),false);
	tattach.defineColumn("hash", typeof(string),false);
	tattach.defineColumn("idattach", typeof(int),false);
	tattach.defineColumn("lt", typeof(DateTime),false);
	tattach.defineColumn("lu", typeof(string),false);
	tattach.defineColumn("size", typeof(int),false);
	Tables.Add(tattach);
	tattach.defineKey("idattach");

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
	tperfateneoindicatoreattach.defineColumn("!idattach_attach_filename", typeof(string));
	Tables.Add(tperfateneoindicatoreattach);
	tperfateneoindicatoreattach.defineKey("idattach", "idperfateneoindicatore", "idperfateneoindicatoreattach", "idperfateneoobiettivo", "idperfvalutazioneateneo");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVINOMCOGNVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativinomcognview= new MetaTable("getregistrydocentiamministrativinomcognview");
	tgetregistrydocentiamministrativinomcognview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativinomcognview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministrativinomcognview);
	tgetregistrydocentiamministrativinomcognview.defineKey("idreg");

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
	Tables.Add(tperfateneoindicatore);
	tperfateneoindicatore.defineKey("idperfateneoindicatore", "idperfateneoobiettivo", "idperfvalutazioneateneo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfateneoindicatore.Columns["idperfateneoindicatore"], perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	var cChild = new []{strutturaperfateneoindicatore.Columns["idperfateneoindicatore"], strutturaperfateneoindicatore.Columns["idperfateneoobiettivo"], strutturaperfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_strutturaperfateneoindicatore_perfateneoindicatore_idperfateneoindicatore-idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{strutturaperfateneoindicatore.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_strutturaperfateneoindicatore_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_valut"]};
	Relations.Add(new DataRelation("FK_struttura_registry_idreg_valut",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_resp"]};
	Relations.Add(new DataRelation("FK_struttura_registry_idreg_resp",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{struttura.Columns["idreg_appr"]};
	Relations.Add(new DataRelation("FK_struttura_registry_idreg_appr",cPar,cChild,false));

	cPar = new []{perfateneoindicatore.Columns["idperfateneoindicatore"], perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	cChild = new []{perfateneostakeholderperfateneoindicatore.Columns["idperfateneoindicatore"], perfateneostakeholderperfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneostakeholderperfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneostakeholderperfateneoindicatore_perfateneoindicatore_idperfateneoindicatore-idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{perfateneostakeholder.Columns["idperfateneostakeholder"]};
	cChild = new []{perfateneostakeholderperfateneoindicatore.Columns["idperfateneostakeholder"]};
	Relations.Add(new DataRelation("FK_perfateneostakeholderperfateneoindicatore_perfateneostakeholder_idperfateneostakeholder",cPar,cChild,false));

	cPar = new []{perfateneoindicatore.Columns["idperfateneoindicatore"], perfateneoindicatore.Columns["idperfateneoobiettivo"], perfateneoindicatore.Columns["idperfvalutazioneateneo"]};
	cChild = new []{perfateneoindicatoreattach.Columns["idperfateneoindicatore"], perfateneoindicatoreattach.Columns["idperfateneoobiettivo"], perfateneoindicatoreattach.Columns["idperfvalutazioneateneo"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatoreattach_perfateneoindicatore_idperfateneoindicatore-idperfateneoobiettivo-idperfvalutazioneateneo",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfateneoindicatoreattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatoreattach_attach_idattach",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativinomcognview.Columns["idreg"]};
	cChild = new []{perfateneoindicatore.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfateneoindicatore_getregistrydocentiamministrativinomcognview_idreg",cPar,cChild,false));

	#endregion

}
}
}
