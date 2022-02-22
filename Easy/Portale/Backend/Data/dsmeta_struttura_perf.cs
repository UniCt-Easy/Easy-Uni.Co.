
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
[System.Xml.Serialization.XmlRoot("dsmeta_struttura_perf"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_struttura_perf: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry_alias1 		=> (MetaTable)Tables["registry_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfruolo 		=> (MetaTable)Tables["perfruolo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaresponsabile 		=> (MetaTable)Tables["strutturaresponsabile"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatorekind 		=> (MetaTable)Tables["perfindicatorekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfindicatore 		=> (MetaTable)Tables["perfindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfstrutturaperfindicatore 		=> (MetaTable)Tables["perfstrutturaperfindicatore"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registry 		=> (MetaTable)Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenza 		=> (MetaTable)Tables["afferenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturakinddefaultview 		=> (MetaTable)Tables["strutturakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_struttura_perf(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_struttura_perf (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_struttura_perf";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_struttura_perf.xsd";

	#region create DataTables
	//////////////////// REGISTRY_ALIAS1 /////////////////////////////////
	var tregistry_alias1= new MetaTable("registry_alias1");
	tregistry_alias1.defineColumn("active", typeof(string),false);
	tregistry_alias1.defineColumn("idreg", typeof(int),false);
	tregistry_alias1.defineColumn("title", typeof(string),false);
	tregistry_alias1.ExtendedProperties["TableForReading"]="registry";
	Tables.Add(tregistry_alias1);
	tregistry_alias1.defineKey("idreg");

	//////////////////// PERFRUOLO /////////////////////////////////
	var tperfruolo= new MetaTable("perfruolo");
	tperfruolo.defineColumn("idperfruolo", typeof(string),false);
	Tables.Add(tperfruolo);
	tperfruolo.defineKey("idperfruolo");

	//////////////////// STRUTTURARESPONSABILE /////////////////////////////////
	var tstrutturaresponsabile= new MetaTable("strutturaresponsabile");
	tstrutturaresponsabile.defineColumn("idperfruolo", typeof(string));
	tstrutturaresponsabile.defineColumn("idreg", typeof(int));
	tstrutturaresponsabile.defineColumn("idstruttura", typeof(int),false);
	tstrutturaresponsabile.defineColumn("idstrutturaresponsabile", typeof(int),false);
	tstrutturaresponsabile.defineColumn("start", typeof(DateTime));
	tstrutturaresponsabile.defineColumn("stop", typeof(DateTime));
	tstrutturaresponsabile.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tstrutturaresponsabile);
	tstrutturaresponsabile.defineKey("idstruttura", "idstrutturaresponsabile");

	//////////////////// PERFINDICATOREKIND /////////////////////////////////
	var tperfindicatorekind= new MetaTable("perfindicatorekind");
	tperfindicatorekind.defineColumn("idperfindicatorekind", typeof(int),false);
	tperfindicatorekind.defineColumn("title", typeof(string));
	Tables.Add(tperfindicatorekind);
	tperfindicatorekind.defineKey("idperfindicatorekind");

	//////////////////// PERFINDICATORE /////////////////////////////////
	var tperfindicatore= new MetaTable("perfindicatore");
	tperfindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfindicatore.defineColumn("cu", typeof(string),false);
	tperfindicatore.defineColumn("description", typeof(string),false);
	tperfindicatore.defineColumn("idperfindicatore", typeof(int),false);
	tperfindicatore.defineColumn("idperfindicatorekind", typeof(int));
	tperfindicatore.defineColumn("inverso", typeof(string));
	tperfindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfindicatore.defineColumn("lu", typeof(string),false);
	tperfindicatore.defineColumn("title", typeof(string));
	Tables.Add(tperfindicatore);
	tperfindicatore.defineKey("idperfindicatore");

	//////////////////// PERFSTRUTTURAPERFINDICATORE /////////////////////////////////
	var tperfstrutturaperfindicatore= new MetaTable("perfstrutturaperfindicatore");
	tperfstrutturaperfindicatore.defineColumn("ct", typeof(DateTime),false);
	tperfstrutturaperfindicatore.defineColumn("cu", typeof(string),false);
	tperfstrutturaperfindicatore.defineColumn("idperfindicatore", typeof(int),false);
	tperfstrutturaperfindicatore.defineColumn("idstruttura", typeof(int),false);
	tperfstrutturaperfindicatore.defineColumn("lt", typeof(DateTime),false);
	tperfstrutturaperfindicatore.defineColumn("lu", typeof(string),false);
	tperfstrutturaperfindicatore.defineColumn("!idperfindicatore_perfindicatore_title", typeof(string));
	tperfstrutturaperfindicatore.defineColumn("!idperfindicatore_perfindicatorekind_title", typeof(string));
	tperfstrutturaperfindicatore.defineColumn("!idperfindicatore_perfindicatore_description", typeof(string));
	Tables.Add(tperfstrutturaperfindicatore);
	tperfstrutturaperfindicatore.defineKey("idperfindicatore", "idstruttura");

	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new MetaTable("registry");
	tregistry.defineColumn("active", typeof(string),false);
	tregistry.defineColumn("idreg", typeof(int),false);
	tregistry.defineColumn("title", typeof(string),false);
	Tables.Add(tregistry);
	tregistry.defineKey("idreg");

	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// AFFERENZA /////////////////////////////////
	var tafferenza= new MetaTable("afferenza");
	tafferenza.defineColumn("ct", typeof(DateTime),false);
	tafferenza.defineColumn("cu", typeof(string),false);
	tafferenza.defineColumn("idafferenza", typeof(int),false);
	tafferenza.defineColumn("idmansionekind", typeof(int));
	tafferenza.defineColumn("idreg", typeof(int),false);
	tafferenza.defineColumn("idstruttura", typeof(int),false);
	tafferenza.defineColumn("lt", typeof(DateTime),false);
	tafferenza.defineColumn("lu", typeof(string),false);
	tafferenza.defineColumn("start", typeof(DateTime));
	tafferenza.defineColumn("stop", typeof(DateTime));
	tafferenza.defineColumn("!idmansionekind_mansionekind_title", typeof(string));
	tafferenza.defineColumn("!idreg_registry_title", typeof(string));
	Tables.Add(tafferenza);
	tafferenza.defineKey("idafferenza", "idreg", "idstruttura");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

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

	#endregion


	#region DataRelation creation
	var cPar = new []{struttura.Columns["idstruttura"]};
	var cChild = new []{strutturaresponsabile.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_strutturaresponsabile_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{registry_alias1.Columns["idreg"]};
	cChild = new []{strutturaresponsabile.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_strutturaresponsabile_registry_alias1_idreg",cPar,cChild,false));

	cPar = new []{perfruolo.Columns["idperfruolo"]};
	cChild = new []{strutturaresponsabile.Columns["idperfruolo"]};
	Relations.Add(new DataRelation("FK_strutturaresponsabile_perfruolo_idperfruolo",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{perfstrutturaperfindicatore.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_perfstrutturaperfindicatore_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{perfindicatore.Columns["idperfindicatore"]};
	cChild = new []{perfstrutturaperfindicatore.Columns["idperfindicatore"]};
	Relations.Add(new DataRelation("FK_perfstrutturaperfindicatore_perfindicatore_idperfindicatore",cPar,cChild,false));

	cPar = new []{perfindicatorekind.Columns["idperfindicatorekind"]};
	cChild = new []{perfindicatore.Columns["idperfindicatorekind"]};
	Relations.Add(new DataRelation("FK_perfindicatore_perfindicatorekind_idperfindicatorekind",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{afferenza.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_afferenza_struttura_idstruttura",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{afferenza.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_afferenza_registry_idreg",cPar,cChild,false));

	cPar = new []{mansionekind.Columns["idmansionekind"]};
	cChild = new []{afferenza.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_afferenza_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{struttura.Columns["paridstruttura"]};
	Relations.Add(new DataRelation("FK_struttura_strutturadefaultview_paridstruttura",cPar,cChild,false));

	cPar = new []{upbdefaultview.Columns["idupb"]};
	cChild = new []{struttura.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_struttura_upbdefaultview_idupb",cPar,cChild,false));

	cPar = new []{strutturakinddefaultview.Columns["idstrutturakind"]};
	cChild = new []{struttura.Columns["idstrutturakind"]};
	Relations.Add(new DataRelation("FK_struttura_strutturakinddefaultview_idstrutturakind",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{struttura.Columns["paridstruttura"]};
	Relations.Add(new DataRelation("FK_struttura_struttura_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
