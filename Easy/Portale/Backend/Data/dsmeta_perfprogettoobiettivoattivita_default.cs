
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoobiettivoattivita_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoobiettivoattivita_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoattivitainterazione 		=> (MetaTable)Tables["perfprogettoattivitainterazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attach 		=> (MetaTable)Tables["attach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitaattach 		=> (MetaTable)Tables["perfprogettoobiettivoattivitaattach"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accountminusabledefaultview 		=> (MetaTable)Tables["accountminusabledefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministratividefaultview 		=> (MetaTable)Tables["getregistrydocentiamministratividefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivita 		=> (MetaTable)Tables["perfprogettoobiettivoattivita"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoobiettivoattivita_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoobiettivoattivita_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoobiettivoattivita_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoobiettivoattivita_default.xsd";

	#region create DataTables
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
	tperfprogettoobiettivoattivitaattach.defineColumn("!idattach_attach_filename", typeof(string));
	Tables.Add(tperfprogettoobiettivoattivitaattach);
	tperfprogettoobiettivoattivitaattach.defineKey("idattach", "idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// UPBDEFAULTVIEW /////////////////////////////////
	var tupbdefaultview= new MetaTable("upbdefaultview");
	tupbdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview.defineColumn("idupb", typeof(string),false);
	tupbdefaultview.defineColumn("upb_active", typeof(string));
	Tables.Add(tupbdefaultview);
	tupbdefaultview.defineKey("idupb");

	//////////////////// ACCOUNTMINUSABLEDEFAULTVIEW /////////////////////////////////
	var taccountminusabledefaultview= new MetaTable("accountminusabledefaultview");
	taccountminusabledefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccountminusabledefaultview.defineColumn("idacc", typeof(string),false);
	taccountminusabledefaultview.defineColumn("paridacc", typeof(string),false);
	Tables.Add(taccountminusabledefaultview);
	taccountminusabledefaultview.defineKey("idacc", "paridacc");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIDEFAULTVIEW /////////////////////////////////
	var tgetregistrydocentiamministratividefaultview= new MetaTable("getregistrydocentiamministratividefaultview");
	tgetregistrydocentiamministratividefaultview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministratividefaultview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministratividefaultview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministratividefaultview);
	tgetregistrydocentiamministratividefaultview.defineKey("idreg");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITA /////////////////////////////////
	var tperfprogettoobiettivoattivita= new MetaTable("perfprogettoobiettivoattivita");
	tperfprogettoobiettivoattivita.defineColumn("completamento", typeof(decimal));
	tperfprogettoobiettivoattivita.defineColumn("ct", typeof(DateTime),false);
	tperfprogettoobiettivoattivita.defineColumn("cu", typeof(string),false);
	tperfprogettoobiettivoattivita.defineColumn("datafineeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datafineprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datainizioeffettiva", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("datainizioprevista", typeof(DateTime));
	tperfprogettoobiettivoattivita.defineColumn("description", typeof(string));
	tperfprogettoobiettivoattivita.defineColumn("idacc", typeof(string));
	tperfprogettoobiettivoattivita.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivita.defineColumn("idreg", typeof(int));
	tperfprogettoobiettivoattivita.defineColumn("idupb", typeof(string));
	tperfprogettoobiettivoattivita.defineColumn("lt", typeof(DateTime),false);
	tperfprogettoobiettivoattivita.defineColumn("lu", typeof(string),false);
	tperfprogettoobiettivoattivita.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoobiettivoattivita.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivoattivita);
	tperfprogettoobiettivoattivita.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettoobiettivoattivita.Columns["idperfprogetto"], perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivoattivita"]};
	var cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idperfprogetto"], perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivo"], perfprogettoobiettivoattivitaattach.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_perfprogettoobiettivoattivita_idperfprogetto-idperfprogettoobiettivo-idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{attach.Columns["idattach"]};
	cChild = new []{perfprogettoobiettivoattivitaattach.Columns["idattach"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivitaattach_attach_idattach",cPar,cChild,false));

	cPar = new []{upbdefaultview.Columns["idupb"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_upbdefaultview_idupb",cPar,cChild,false));

	cPar = new []{accountminusabledefaultview.Columns["idacc"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["idacc"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_accountminusabledefaultview_idacc",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministratividefaultview.Columns["idreg"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_getregistrydocentiamministratividefaultview_idreg",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivita.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoobiettivoattivita.Columns["paridperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoobiettivoattivita_perfprogettoobiettivoattivita_idperfprogettoobiettivoattivita",cPar,cChild,false));

	#endregion

}
}
}
