
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_stipendioannuo_prev"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_stipendioannuo_prev: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrylegalstatusprevview 		=> (MetaTable)Tables["registrylegalstatusprevview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrypersoneview 		=> (MetaTable)Tables["registrypersoneview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable stipendioannuo 		=> (MetaTable)Tables["stipendioannuo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_stipendioannuo_prev(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_stipendioannuo_prev (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_stipendioannuo_prev";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_stipendioannuo_prev.xsd";

	#region create DataTables
	//////////////////// REGISTRYLEGALSTATUSPREVVIEW /////////////////////////////////
	var tregistrylegalstatusprevview= new MetaTable("registrylegalstatusprevview");
	tregistrylegalstatusprevview.defineColumn("dropdown_title", typeof(string),false);
	tregistrylegalstatusprevview.defineColumn("idposition", typeof(int));
	tregistrylegalstatusprevview.defineColumn("idreg", typeof(int),false);
	tregistrylegalstatusprevview.defineColumn("idregistrylegalstatus", typeof(int),false);
	tregistrylegalstatusprevview.defineColumn("inquadramento_tempdef", typeof(string));
	tregistrylegalstatusprevview.defineColumn("inquadramento_title", typeof(string));
	tregistrylegalstatusprevview.defineColumn("position_title", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_active", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_csa_class", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_csa_compartment", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_csa_role", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_ct", typeof(DateTime));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_cu", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_datarivalutazione", typeof(DateTime));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_iddaliaposition", typeof(int));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_idinquadramento", typeof(int));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_incomeclass", typeof(int));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_incomeclassvalidity", typeof(DateTime));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_livello", typeof(int));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_lt", typeof(DateTime));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_lu", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_parttime", typeof(decimal));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_percentualesufondiateneo", typeof(decimal));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_rtf", typeof(Byte[]));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_start", typeof(DateTime),false);
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_stop", typeof(DateTime));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_tempdef", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_tempindet", typeof(string));
	tregistrylegalstatusprevview.defineColumn("registrylegalstatus_txt", typeof(string));
	Tables.Add(tregistrylegalstatusprevview);
	tregistrylegalstatusprevview.defineKey("idreg", "idregistrylegalstatus");

	//////////////////// REGISTRYPERSONEVIEW /////////////////////////////////
	var tregistrypersoneview= new MetaTable("registrypersoneview");
	tregistrypersoneview.defineColumn("dropdown_title", typeof(string),false);
	tregistrypersoneview.defineColumn("idreg", typeof(int),false);
	tregistrypersoneview.defineColumn("registry_active", typeof(string));
	Tables.Add(tregistrypersoneview);
	tregistrypersoneview.defineKey("idreg");

	//////////////////// STIPENDIOANNUO /////////////////////////////////
	var tstipendioannuo= new MetaTable("stipendioannuo");
	tstipendioannuo.defineColumn("caricoente", typeof(decimal));
	tstipendioannuo.defineColumn("ct", typeof(DateTime));
	tstipendioannuo.defineColumn("cu", typeof(string));
	tstipendioannuo.defineColumn("idreg", typeof(int),false);
	tstipendioannuo.defineColumn("idregistrylegalstatus", typeof(int),false);
	tstipendioannuo.defineColumn("idstipendioannuo", typeof(int),false);
	tstipendioannuo.defineColumn("irap", typeof(decimal));
	tstipendioannuo.defineColumn("lordo", typeof(decimal));
	tstipendioannuo.defineColumn("lt", typeof(DateTime));
	tstipendioannuo.defineColumn("lu", typeof(string));
	tstipendioannuo.defineColumn("totale", typeof(decimal));
	tstipendioannuo.defineColumn("year", typeof(int),false);
	Tables.Add(tstipendioannuo);
	tstipendioannuo.defineKey("idreg", "idregistrylegalstatus", "idstipendioannuo", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrylegalstatusprevview.Columns["idregistrylegalstatus"]};
	var cChild = new []{stipendioannuo.Columns["idregistrylegalstatus"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_registrylegalstatusprevview_idregistrylegalstatus",cPar,cChild,false));

	cPar = new []{registrypersoneview.Columns["idreg"]};
	cChild = new []{registrylegalstatusprevview.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registrylegalstatusprevview_registrypersoneview_idreg",cPar,cChild,false));

	cPar = new []{registrypersoneview.Columns["idreg"]};
	cChild = new []{stipendioannuo.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_stipendioannuo_registrypersoneview_idreg",cPar,cChild,false));

	#endregion

}
}
}
