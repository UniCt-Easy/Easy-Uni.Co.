/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_logreportprogetti_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_logreportprogetti_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable virtualuser 		=> (MetaTable)Tables["virtualuser"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativiprjnomcognmatview 		=> (MetaTable)Tables["getregistrydocentiamministrativiprjnomcognmatview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettocataniaview 		=> (MetaTable)Tables["progettocataniaview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable logreportprogetti 		=> (MetaTable)Tables["logreportprogetti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_logreportprogetti_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_logreportprogetti_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_logreportprogetti_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_logreportprogetti_default.xsd";

	#region create DataTables
	//////////////////// VIRTUALUSER /////////////////////////////////
	var tvirtualuser= new MetaTable("virtualuser");
	tvirtualuser.defineColumn("cf", typeof(string));
	tvirtualuser.defineColumn("codicedipartimento", typeof(string),false);
	tvirtualuser.defineColumn("email", typeof(string));
	tvirtualuser.defineColumn("forename", typeof(string),false);
	tvirtualuser.defineColumn("idvirtualuser", typeof(int),false);
	tvirtualuser.defineColumn("surname", typeof(string),false);
	tvirtualuser.defineColumn("sys_user", typeof(string),false);
	tvirtualuser.defineColumn("username", typeof(string),false);
	Tables.Add(tvirtualuser);
	tvirtualuser.defineKey("idvirtualuser");

	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVIPRJNOMCOGNMATVIEW /////////////////////////////////
	var tgetregistrydocentiamministrativiprjnomcognmatview= new MetaTable("getregistrydocentiamministrativiprjnomcognmatview");
	tgetregistrydocentiamministrativiprjnomcognmatview.defineColumn("dropdown_title", typeof(string),false);
	tgetregistrydocentiamministrativiprjnomcognmatview.defineColumn("getregistrydocentiamministrativiprj_active", typeof(string));
	tgetregistrydocentiamministrativiprjnomcognmatview.defineColumn("idreg", typeof(int),false);
	Tables.Add(tgetregistrydocentiamministrativiprjnomcognmatview);
	tgetregistrydocentiamministrativiprjnomcognmatview.defineKey("idreg");

	//////////////////// PROGETTOCATANIAVIEW /////////////////////////////////
	var tprogettocataniaview= new MetaTable("progettocataniaview");
	tprogettocataniaview.defineColumn("dropdown_title", typeof(string),false);
	tprogettocataniaview.defineColumn("idprogetto", typeof(int),false);
	Tables.Add(tprogettocataniaview);
	tprogettocataniaview.defineKey("idprogetto");

	//////////////////// LOGREPORTPROGETTI /////////////////////////////////
	var tlogreportprogetti= new MetaTable("logreportprogetti");
	tlogreportprogetti.defineColumn("ct", typeof(DateTime));
	tlogreportprogetti.defineColumn("cu", typeof(string));
	tlogreportprogetti.defineColumn("dati", typeof(string));
	tlogreportprogetti.defineColumn("idlogreportprogetti", typeof(int),false);
	tlogreportprogetti.defineColumn("idprogetto", typeof(int));
	tlogreportprogetti.defineColumn("idreg", typeof(int));
	tlogreportprogetti.defineColumn("lt", typeof(DateTime));
	tlogreportprogetti.defineColumn("lu", typeof(string));
	tlogreportprogetti.defineColumn("start", typeof(DateTime));
	tlogreportprogetti.defineColumn("stop", typeof(DateTime));
	tlogreportprogetti.defineColumn("username", typeof(string));
	tlogreportprogetti.defineColumn("verbouse", typeof(string));
	Tables.Add(tlogreportprogetti);
	tlogreportprogetti.defineKey("idlogreportprogetti");

	#endregion


	#region DataRelation creation
	var cPar = new []{virtualuser.Columns["sys_user"]};
	var cChild = new []{logreportprogetti.Columns["username"]};
	Relations.Add(new DataRelation("FK_logreportprogetti_virtualuser_username",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativiprjnomcognmatview.Columns["idreg"]};
	cChild = new []{logreportprogetti.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_logreportprogetti_getregistrydocentiamministrativiprjnomcognmatview_idreg",cPar,cChild,false));

	cPar = new []{progettocataniaview.Columns["idprogetto"]};
	cChild = new []{logreportprogetti.Columns["idprogetto"]};
	Relations.Add(new DataRelation("FK_logreportprogetti_progettocataniaview_idprogetto",cPar,cChild,false));

	#endregion

}
}
}
