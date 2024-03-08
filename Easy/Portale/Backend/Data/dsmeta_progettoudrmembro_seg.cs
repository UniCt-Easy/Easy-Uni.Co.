
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettoudrmembro_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettoudrmembro_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable rendicontattivitaprogettourdmemboview 		=> (MetaTable)Tables["rendicontattivitaprogettourdmemboview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudrmembrokinddefaultview 		=> (MetaTable)Tables["progettoudrmembrokinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativimacroareaview 		=> (MetaTable)Tables["getregistrydocentiamministrativimacroareaview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettoudrmembro 		=> (MetaTable)Tables["progettoudrmembro"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettoudrmembro_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettoudrmembro_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettoudrmembro_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettoudrmembro_seg.xsd";

	#region create DataTables
	//////////////////// RENDICONTATTIVITAPROGETTOURDMEMBOVIEW /////////////////////////////////
	var trendicontattivitaprogettourdmemboview= new MetaTable("rendicontattivitaprogettourdmemboview");
	trendicontattivitaprogettourdmemboview.defineColumn("idprogetto", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("idprogettoudr", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("idprogettoudrmembro", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("idreg", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("oreanno", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oreannoimpegnate", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oreannorendicontate", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oreattivita", typeof(int));
	trendicontattivitaprogettourdmemboview.defineColumn("oremaxanno", typeof(int),false);
	trendicontattivitaprogettourdmemboview.defineColumn("stipendioannuo", typeof(decimal));
	trendicontattivitaprogettourdmemboview.defineColumn("stipendiorendicontato", typeof(decimal));
	trendicontattivitaprogettourdmemboview.defineColumn("year", typeof(int),false);
	Tables.Add(trendicontattivitaprogettourdmemboview);
	trendicontattivitaprogettourdmemboview.defineKey("idprogetto", "idprogettoudr", "idprogettoudrmembro", "idreg", "oremaxanno", "year");

	//////////////////// PROGETTOUDRMEMBROKINDDEFAULTVIEW /////////////////////////////////
	var tprogettoudrmembrokinddefaultview= new MetaTable("progettoudrmembrokinddefaultview");
	tprogettoudrmembrokinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tprogettoudrmembrokinddefaultview.defineColumn("idprogettoudrmembrokind", typeof(int),false);
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_active", typeof(string));
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_ct", typeof(DateTime),false);
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_cu", typeof(string),false);
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_description", typeof(string));
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_lt", typeof(DateTime),false);
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_lu", typeof(string),false);
	tprogettoudrmembrokinddefaultview.defineColumn("progettoudrmembrokind_sortcode", typeof(int));
	tprogettoudrmembrokinddefaultview.defineColumn("title", typeof(string));
	Tables.Add(tprogettoudrmembrokinddefaultview);
	tprogettoudrmembrokinddefaultview.defineKey("idprogettoudrmembrokind");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIMACROAREAVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativimacroareaview= new MetaTable("getregistrydocentiamministrativimacroareaview");
	tgetregistrydocentiamministrativimacroareaview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_areadidattica", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_categoria", typeof(string),false);
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_macroareadidattica", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministrativimacroareaview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativimacroareaview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativimacroareaview);
	tgetregistrydocentiamministrativimacroareaview.defineKey("idreg");

	//////////////////// PROGETTOUDRMEMBRO /////////////////////////////////
	var tprogettoudrmembro= new MetaTable("progettoudrmembro");
	tprogettoudrmembro.defineColumn("!orerendicontate", typeof(int));
	tprogettoudrmembro.defineColumn("costoorario", typeof(decimal));
	tprogettoudrmembro.defineColumn("ct", typeof(DateTime));
	tprogettoudrmembro.defineColumn("cu", typeof(string));
	tprogettoudrmembro.defineColumn("fondiprogetto", typeof(string));
	tprogettoudrmembro.defineColumn("giornipreventivati", typeof(int));
	tprogettoudrmembro.defineColumn("idprogetto", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudr", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudrmembro", typeof(int),false);
	tprogettoudrmembro.defineColumn("idprogettoudrmembrokind", typeof(int));
	tprogettoudrmembro.defineColumn("idreg", typeof(int),false);
	tprogettoudrmembro.defineColumn("impegno", typeof(decimal));
	tprogettoudrmembro.defineColumn("lt", typeof(DateTime));
	tprogettoudrmembro.defineColumn("lu", typeof(string));
	tprogettoudrmembro.defineColumn("orepreventivate", typeof(int));
	tprogettoudrmembro.defineColumn("ricavoorario", typeof(decimal));
	tprogettoudrmembro.defineColumn("start", typeof(DateTime));
	tprogettoudrmembro.defineColumn("stop", typeof(DateTime));
	Tables.Add(tprogettoudrmembro);
	tprogettoudrmembro.defineKey("idprogetto", "idprogettoudr", "idprogettoudrmembro");

	#endregion


	#region DataRelation creation
	var cPar = new []{rendicontattivitaprogettourdmemboview.Columns["idprogetto"], rendicontattivitaprogettourdmemboview.Columns["idprogettoudr"], rendicontattivitaprogettourdmemboview.Columns["idprogettoudrmembro"]};
	var cChild = new []{progettoudrmembro.Columns["idprogetto"], progettoudrmembro.Columns["idprogettoudr"], progettoudrmembro.Columns["idprogettoudrmembro"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_rendicontattivitaprogettourdmemboview_idprogetto-idprogettoudr-idprogettoudrmembro",cPar,cChild,false));

	cPar = new []{progettoudrmembrokinddefaultview.Columns["idprogettoudrmembrokind"]};
	cChild = new []{progettoudrmembro.Columns["idprogettoudrmembrokind"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_progettoudrmembrokinddefaultview_idprogettoudrmembrokind",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativimacroareaview.Columns["idreg"]};
	cChild = new []{progettoudrmembro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_progettoudrmembro_getregistrydocentiamministrativimacroareaview_idreg",cPar,cChild,false));

	#endregion

}
}
}
