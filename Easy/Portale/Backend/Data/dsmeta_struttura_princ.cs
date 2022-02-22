
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
[System.Xml.Serialization.XmlRoot("dsmeta_struttura_princ"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_struttura_princ: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakinddefaultview 		=> (MetaTable)Tables["strutturakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable sededefaultview 		=> (MetaTable)Tables["sededefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable aoodefaultview 		=> (MetaTable)Tables["aoodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_struttura_princ(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_struttura_princ (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_struttura_princ";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_struttura_princ.xsd";

	#region create DataTables
	//////////////////// UPBDEFAULTVIEW /////////////////////////////////
	var tupbdefaultview= new MetaTable("upbdefaultview");
	tupbdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview.defineColumn("idtreasurer", typeof(int));
	tupbdefaultview.defineColumn("idunderwriter", typeof(int));
	tupbdefaultview.defineColumn("idupb", typeof(string),false);
	tupbdefaultview.defineColumn("idupb_capofila", typeof(string));
	tupbdefaultview.defineColumn("paridupb", typeof(string));
	tupbdefaultview.defineColumn("upb_active", typeof(string));
	Tables.Add(tupbdefaultview);
	tupbdefaultview.defineKey("idupb");

	//////////////////// STRUTTURAKINDDEFAULTVIEW /////////////////////////////////
	var tstrutturakinddefaultview= new MetaTable("strutturakinddefaultview");
	tstrutturakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturakinddefaultview.defineColumn("idstrutturakind", typeof(int),false);
	tstrutturakinddefaultview.defineColumn("strutturakind_active", typeof(string));
	Tables.Add(tstrutturakinddefaultview);
	tstrutturakinddefaultview.defineKey("idstrutturakind");

	//////////////////// SEDEDEFAULTVIEW /////////////////////////////////
	var tsededefaultview= new MetaTable("sededefaultview");
	tsededefaultview.defineColumn("dropdown_title", typeof(string),false);
	tsededefaultview.defineColumn("idcity", typeof(int));
	tsededefaultview.defineColumn("idnation", typeof(int));
	tsededefaultview.defineColumn("idsede", typeof(int),false);
	Tables.Add(tsededefaultview);
	tsededefaultview.defineKey("idsede");

	//////////////////// AOODEFAULTVIEW /////////////////////////////////
	var taoodefaultview= new MetaTable("aoodefaultview");
	taoodefaultview.defineColumn("dropdown_title", typeof(string),false);
	taoodefaultview.defineColumn("idaoo", typeof(int),false);
	taoodefaultview.defineColumn("idsede", typeof(int));
	Tables.Add(taoodefaultview);
	taoodefaultview.defineKey("idaoo");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("codice", typeof(string));
	tstruttura.defineColumn("codiceipa", typeof(string));
	tstruttura.defineColumn("ct", typeof(DateTime),false);
	tstruttura.defineColumn("cu", typeof(string),false);
	tstruttura.defineColumn("email", typeof(string));
	tstruttura.defineColumn("fax", typeof(string));
	tstruttura.defineColumn("idaoo", typeof(int));
	tstruttura.defineColumn("idreg", typeof(int));
	tstruttura.defineColumn("idsede", typeof(int),false);
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("idstrutturakind", typeof(int),false);
	tstruttura.defineColumn("idupb", typeof(string),false);
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

	#endregion


	#region DataRelation creation
	var cPar = new []{upbdefaultview.Columns["idupb"]};
	var cChild = new []{struttura.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_struttura_upbdefaultview_idupb",cPar,cChild,false));

	cPar = new []{strutturakinddefaultview.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakinddefaultview_idstrutturakind",cPar,cChild,false));

	cPar = new []{sededefaultview.Columns["idsede"]};
	cChild = new []{struttura.Columns["idsede"]};
	Relations.Add(new DataRelation("FK_struttura_sededefaultview_idsede",cPar,cChild,false));

	cPar = new []{aoodefaultview.Columns["idaoo"]};
	cChild = new []{struttura.Columns["idaoo"]};
	Relations.Add(new DataRelation("FK_struttura_aoodefaultview_idaoo",cPar,cChild,false));

	#endregion

}
}
}
