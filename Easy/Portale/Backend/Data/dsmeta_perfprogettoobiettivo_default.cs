
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivointerazione 		=> (MetaTable)Tables["perfprogettoobiettivointerazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfsogliakind 		=> (MetaTable)Tables["perfsogliakind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivosoglia 		=> (MetaTable)Tables["perfprogettoobiettivosoglia"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoattivitainterazione 		=> (MetaTable)Tables["perfprogettoattivitainterazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaattach 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accountminusable 		=> (MetaTable)Tables["accountminusable"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivita_alias3 		=> (MetaTable)Tables["perfprogettoobiettivoattivita_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo 		=> (MetaTable)Tables["perfprogettoobiettivo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivo_default.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOOBIETTIVOINTERAZIONE /////////////////////////////////
	var tperfprogettoobiettivointerazione= new MetaTable("perfprogettoobiettivointerazione");
	tperfprogettoobiettivointerazione.defineColumn("commenti", typeof(string));
	tperfprogettoobiettivointerazione.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivointerazione.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivointerazione.defineColumn("data", typeof(DateTime));
	tperfprogettoobiettivointerazione.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("idperfprogettoobiettivointerazione", typeof(int),false);
	tperfprogettoobiettivointerazione.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivointerazione.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivointerazione.defineColumn("utente", typeof(string));
	Tables.Add(tperfprogettoobiettivointerazione);
	tperfprogettoobiettivointerazione.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivointerazione");

	//////////////////// PERFSOGLIAKIND /////////////////////////////////
	var tperfsogliakind= new MetaTable("perfsogliakind");
	tperfsogliakind.defineColumn("idperfsogliakind", typeof(string),false);
	Tables.Add(tperfsogliakind);
	tperfsogliakind.defineKey("idperfsogliakind");

	//////////////////// PERFPROGETTOOBIETTIVOSOGLIA /////////////////////////////////
	var tperfprogettoobiettivosoglia= new MetaTable("perfprogettoobiettivosoglia");
	tperfprogettoobiettivosoglia.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("description", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfprogettoobiettivosoglia", typeof(int),false);
	tperfprogettoobiettivosoglia.defineColumn("idperfsogliakind", typeof(string));
	tperfprogettoobiettivosoglia.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivosoglia.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivosoglia.defineColumn("percentuale", typeof(decimal));
	tperfprogettoobiettivosoglia.defineColumn("valorenumerico", typeof(decimal));
	Tables.Add(tperfprogettoobiettivosoglia);
	tperfprogettoobiettivosoglia.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivosoglia");

	//////////////////// PERFPROGETTOATTIVITAINTERAZIONE /////////////////////////////////
	var tperfprogettoattivitainterazione= new MetaTable("perfprogettoattivitainterazione");
	tperfprogettoattivitainterazione.defineColumn("commenti", typeof(string));
	tperfprogettoattivitainterazione.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoattivitainterazione.defineColumn("cu", typeof(string),false);
	tperfprogettoattivitainterazione.defineColumn("data", typeof(DateTime));
	tperfprogettoattivitainterazione.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfprogettoattivitainterazione.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoattivitainterazione.defineColumn("idperfprogettoattivitainterazione", typeof(int),false);
	tperfprogettoattivitainterazione.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoattivitainterazione.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoattivitainterazione.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoattivitainterazione.defineColumn("lu", typeof(string),false);
	tperfprogettoattivitainterazione.defineColumn("utente", typeof(string));
	Tables.Add(tperfprogettoattivitainterazione);
	tperfprogettoattivitainterazione.defineKey("idperfprogetto", "idperfprogettoattivitainterazione", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITAATTACH /////////////////////////////////
	var tperfprogettoobiettivoattivitaattach= new MetaTable("perfprogettoobiettivoattivitaattach");
	tperfprogettoobiettivoattivitaattach.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("data", typeof(DateTime));
	tperfprogettoobiettivoattivitaattach.defineColumn("idattach", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivitaattach.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettoobiettivoattivitaattach);
	tperfprogettoobiettivoattivitaattach.defineKey("idattach", "idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("title", typeof(string),false);
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

	//////////////////// ACCOUNTMINUSABLE /////////////////////////////////
	var taccountminusable= new MetaTable("accountminusable");
	taccountminusable.defineColumn("accountkind", typeof(string));
	taccountminusable.defineColumn("ayear", typeof(int),false);
	taccountminusable.defineColumn("codeacc", typeof(string),false);
	taccountminusable.defineColumn("idacc", typeof(string),false);
	taccountminusable.defineColumn("title", typeof(string),false);
	Tables.Add(taccountminusable);
	taccountminusable.defineKey("idacc");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITA_ALIAS3 /////////////////////////////////
	var tperfprogettoobiettivoattivita_alias3= new MetaTable("perfprogettoobiettivoattivita_alias3");
	tperfprogettoobiettivoattivita_alias3.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivoattivita_alias3.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita_alias3.defineColumn("description", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("idacc", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivoattivita_alias3.defineColumn("idupb", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivita_alias3.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoobiettivoattivita_alias3.defineColumn("title", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idacc_accountminusable_title", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idacc_accountminusable_codeacc", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idacc_accountminusable_accountkind", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idacc_accountminusable_ayear", typeof(int));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idreg_getregistrydocentiamministrativi_surname", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idreg_getregistrydocentiamministrativi_forename", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idreg_getregistrydocentiamministrativi_extmatricula", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idreg_getregistrydocentiamministrativi_contratto", typeof(string));
	tperfprogettoobiettivoattivita_alias3.defineColumn("!idupb_upb_title", typeof(string));
	tperfprogettoobiettivoattivita_alias3.ExtendedProperties["TableForReading"]="perfprogettoobiettivoattivita";
	Tables.Add(tperfprogettoobiettivoattivita_alias3);
	tperfprogettoobiettivoattivita_alias3.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

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

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// PERFPROGETTOOBIETTIVO /////////////////////////////////
	var tperfprogettoobiettivo= new MetaTable("perfprogettoobiettivo");
	tperfprogettoobiettivo.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivo.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivo.defineColumn("description", typeof(string));
	tperfprogettoobiettivo.defineColumn("idattach", typeof(int));
	tperfprogettoobiettivo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivo.defineColumn("lt", typeof(DateTime));
	tperfprogettoobiettivo.defineColumn("lu", typeof(string));
	tperfprogettoobiettivo.defineColumn("peso", typeof(decimal));
	tperfprogettoobiettivo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivo);
	tperfprogettoobiettivo.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettoobiettivo.Columns["idperfprogetto"], perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	var cChild = new []{perfprogettoobiettivosoglia.Columns["idperfprogetto"], perfprogettoobiettivosoglia.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfprogettoobiettivo_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfsogliakind.Columns["idperfsogliakind"]};
	cChild = new []{perfprogettoobiettivosoglia.Columns["idperfsogliakind"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivosoglia_perfsogliakind_idperfsogliakind",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogetto"], perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogetto"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_perfprogettoobiettivo_idperfprogetto-idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogetto"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoattivitainterazione.Columns["idperfprogetto"], perfprogettoattivitainterazione.Columns["idperfprogettoobiettivo"], perfprogettoattivitainterazione.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoattivitainterazione_perfprogettoobiettivoattivita_alias3_idperfprogetto-idperfprogettoobiettivo-idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogetto"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogetto"], perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivoattivita_alias3_idperfprogetto-idperfprogettoobiettivo-idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_upb_idupb",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

	cPar = new []{accountminusable.Columns["idacc"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["idacc"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_accountminusable_idacc",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita_alias3.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivita_alias3.Columns["paridperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_alias3_perfprogettoobiettivoattivita_alias3_idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfprogettoobiettivo.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivo_attach_idattach",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfprogettoobiettivo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivo_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	#endregion

}
}
}
