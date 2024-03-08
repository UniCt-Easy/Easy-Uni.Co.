
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettouomembro_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfprogettouomembro_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenzaammview 		=> (MetaTable)Tables["afferenzaammview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativinomcognview 		=> (MetaTable)Tables["getregistrydocentiamministrativinomcognview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouomembro 		=> (MetaTable)Tables["perfprogettouomembro"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettouomembro_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettouomembro_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettouomembro_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettouomembro_default.xsd";

	#region create DataTables
	//////////////////// AFFERENZAAMMVIEW /////////////////////////////////
	var tafferenzaammview= new MetaTable("afferenzaammview");
	tafferenzaammview.defineColumn("dropdown_title", typeof(string),false);
	tafferenzaammview.defineColumn("idafferenza", typeof(int),false);
	tafferenzaammview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tafferenzaammview);
	tafferenzaammview.defineKey("idafferenza", "idreg");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVINOMCOGNVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativinomcognview= new MetaTable("getregistrydocentiamministrativinomcognview");
	tgetregistrydocentiamministrativinomcognview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_cf", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_contratto", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_extmatricula", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_forename", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_istituto", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_ssd", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("getregistrydocentiamministrativi_struttura", typeof(string));
	tgetregistrydocentiamministrativinomcognview.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativinomcognview.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativinomcognview);
	tgetregistrydocentiamministrativinomcognview.defineKey("idreg");

	//////////////////// PERFPROGETTOUOMEMBRO /////////////////////////////////
	var tperfprogettouomembro= new MetaTable("perfprogettouomembro");
	tperfprogettouomembro.defineColumn("agile", typeof(string),false);
	tperfprogettouomembro.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("cu", typeof(string),false);
	tperfprogettouomembro.defineColumn("idafferenza", typeof(int));
	tperfprogettouomembro.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouomembro.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouomembro.defineColumn("idreg", typeof(int),false);
	tperfprogettouomembro.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfprogettouomembro);
	tperfprogettouomembro.defineKey("idperfprogetto", "idperfprogettouo", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{afferenzaammview.Columns["idafferenza"]};
	var cChild = new []{perfprogettouomembro.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_afferenzaammview_idafferenza",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativinomcognview.Columns["idreg"]};
	cChild = new []{afferenzaammview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_afferenzaammview_getregistrydocentiamministrativinomcognview_idreg",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativinomcognview.Columns["idreg"]};
	cChild = new []{perfprogettouomembro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_getregistrydocentiamministrativinomcognview_idreg",cPar,cChild,false));

	#endregion

}
}
}
