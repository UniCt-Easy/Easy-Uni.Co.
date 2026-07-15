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
[System.Xml.Serialization.XmlRoot("dsmeta_pannellofunzioniperf_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_pannellofunzioniperf_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview_alias4 		=> (MetaTable)Tables["strutturadefaultview_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias4 		=> (MetaTable)Tables["year_alias4"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview_alias3 		=> (MetaTable)Tables["strutturadefaultview_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias3 		=> (MetaTable)Tables["year_alias3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview_alias2 		=> (MetaTable)Tables["strutturadefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias2 		=> (MetaTable)Tables["year_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview_alias1 		=> (MetaTable)Tables["strutturadefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year_alias1 		=> (MetaTable)Tables["year_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekinddefaultview 		=> (MetaTable)Tables["mansionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable pannellofunzioniperf 		=> (MetaTable)Tables["pannellofunzioniperf"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_pannellofunzioniperf_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_pannellofunzioniperf_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_pannellofunzioniperf_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_pannellofunzioniperf_default.xsd";

	#region create DataTables
	//////////////////// STRUTTURADEFAULTVIEW_ALIAS4 /////////////////////////////////
	var tstrutturadefaultview_alias4= new MetaTable("strutturadefaultview_alias4");
	tstrutturadefaultview_alias4.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview_alias4.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview_alias4.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview_alias4.ExtendedProperties["TableForReading"]="strutturadefaultview";
	Tables.Add(tstrutturadefaultview_alias4);
	tstrutturadefaultview_alias4.defineKey("idstruttura");

	//////////////////// YEAR_ALIAS4 /////////////////////////////////
	var tyear_alias4= new MetaTable("year_alias4");
	tyear_alias4.defineColumn("year", typeof(int),false);
	tyear_alias4.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias4);
	tyear_alias4.defineKey("year");

	//////////////////// STRUTTURADEFAULTVIEW_ALIAS3 /////////////////////////////////
	var tstrutturadefaultview_alias3= new MetaTable("strutturadefaultview_alias3");
	tstrutturadefaultview_alias3.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview_alias3.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview_alias3.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview_alias3.ExtendedProperties["TableForReading"]="strutturadefaultview";
	Tables.Add(tstrutturadefaultview_alias3);
	tstrutturadefaultview_alias3.defineKey("idstruttura");

	//////////////////// YEAR_ALIAS3 /////////////////////////////////
	var tyear_alias3= new MetaTable("year_alias3");
	tyear_alias3.defineColumn("year", typeof(int),false);
	tyear_alias3.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias3);
	tyear_alias3.defineKey("year");

	//////////////////// STRUTTURADEFAULTVIEW_ALIAS2 /////////////////////////////////
	var tstrutturadefaultview_alias2= new MetaTable("strutturadefaultview_alias2");
	tstrutturadefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview_alias2.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview_alias2.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview_alias2.ExtendedProperties["TableForReading"]="strutturadefaultview";
	Tables.Add(tstrutturadefaultview_alias2);
	tstrutturadefaultview_alias2.defineKey("idstruttura");

	//////////////////// YEAR_ALIAS2 /////////////////////////////////
	var tyear_alias2= new MetaTable("year_alias2");
	tyear_alias2.defineColumn("year", typeof(int),false);
	tyear_alias2.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias2);
	tyear_alias2.defineKey("year");

	//////////////////// STRUTTURADEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tstrutturadefaultview_alias1= new MetaTable("strutturadefaultview_alias1");
	tstrutturadefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview_alias1.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview_alias1.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview_alias1.ExtendedProperties["TableForReading"]="strutturadefaultview";
	Tables.Add(tstrutturadefaultview_alias1);
	tstrutturadefaultview_alias1.defineKey("idstruttura");

	//////////////////// YEAR_ALIAS1 /////////////////////////////////
	var tyear_alias1= new MetaTable("year_alias1");
	tyear_alias1.defineColumn("year", typeof(int),false);
	tyear_alias1.ExtendedProperties["TableForReading"]="year";
	Tables.Add(tyear_alias1);
	tyear_alias1.defineKey("year");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("aoo_title", typeof(string));
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("idupb", typeof(string));
	tstrutturadefaultview.defineColumn("paridstruttura", typeof(int));
	tstrutturadefaultview.defineColumn("sede_title", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codice", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_codiceipa", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_ct", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_cu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_email", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_fax", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_idaoo", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idreg", typeof(int));
	tstrutturadefaultview.defineColumn("struttura_idsede", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_idstrutturakind", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_lt", typeof(DateTime),false);
	tstrutturadefaultview.defineColumn("struttura_lu", typeof(string),false);
	tstrutturadefaultview.defineColumn("struttura_pesoindicatori", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoobiettivi", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoprogaltreuo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_pesoproguo", typeof(decimal));
	tstrutturadefaultview.defineColumn("struttura_telefono", typeof(string));
	tstrutturadefaultview.defineColumn("struttura_title_en", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_struttura_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturakind_title", typeof(string));
	tstrutturadefaultview.defineColumn("strutturaparent_idstrutturakind", typeof(int));
	tstrutturadefaultview.defineColumn("strutturaparent_title", typeof(string));
	tstrutturadefaultview.defineColumn("title", typeof(string));
	tstrutturadefaultview.defineColumn("upb_title", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

	//////////////////// MANSIONEKINDDEFAULTVIEW /////////////////////////////////
	var tmansionekinddefaultview= new MetaTable("mansionekinddefaultview");
	tmansionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tmansionekinddefaultview.defineColumn("idmansionekind", typeof(int),false);
	Tables.Add(tmansionekinddefaultview);
	tmansionekinddefaultview.defineKey("idmansionekind");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PANNELLOFUNZIONIPERF /////////////////////////////////
	var tpannellofunzioniperf= new MetaTable("pannellofunzioniperf");
	tpannellofunzioniperf.defineColumn("eccellenza", typeof(decimal));
	tpannellofunzioniperf.defineColumn("eccellenzadesc", typeof(string));
	tpannellofunzioniperf.defineColumn("idmansionekind", typeof(int));
	tpannellofunzioniperf.defineColumn("idpannellofunzioniperf", typeof(int),false);
	tpannellofunzioniperf.defineColumn("idstruttura", typeof(int));
	tpannellofunzioniperf.defineColumn("idstruttura_impobbind", typeof(int));
	tpannellofunzioniperf.defineColumn("idstruttura_impobborg", typeof(int));
	tpannellofunzioniperf.defineColumn("idstruttura_ramoprecedente", typeof(int));
	tpannellofunzioniperf.defineColumn("idstruttura_ramosuccessivo", typeof(int));
	tpannellofunzioniperf.defineColumn("obiettivo", typeof(string));
	tpannellofunzioniperf.defineColumn("peso", typeof(decimal));
	tpannellofunzioniperf.defineColumn("pesoindicatori", typeof(decimal));
	tpannellofunzioniperf.defineColumn("pesoobiettivi", typeof(decimal));
	tpannellofunzioniperf.defineColumn("pesoprogaltreuo", typeof(decimal));
	tpannellofunzioniperf.defineColumn("pesoproguo", typeof(decimal));
	tpannellofunzioniperf.defineColumn("soglia", typeof(decimal));
	tpannellofunzioniperf.defineColumn("sogliadesc", typeof(string));
	tpannellofunzioniperf.defineColumn("target", typeof(decimal));
	tpannellofunzioniperf.defineColumn("targetdesc", typeof(string));
	tpannellofunzioniperf.defineColumn("year", typeof(int));
	tpannellofunzioniperf.defineColumn("year_annoprecedente", typeof(int));
	tpannellofunzioniperf.defineColumn("year_annosuccessivo", typeof(int));
	tpannellofunzioniperf.defineColumn("year_impobbind", typeof(int));
	tpannellofunzioniperf.defineColumn("year_impobborg", typeof(int));
	tpannellofunzioniperf.defineColumn("year_obbind", typeof(int));
	Tables.Add(tpannellofunzioniperf);
	tpannellofunzioniperf.defineKey("idpannellofunzioniperf");

	#endregion


	#region DataRelation creation
	var cPar = new []{strutturadefaultview_alias4.Columns["idstruttura"]};
	var cChild = new []{pannellofunzioniperf.Columns["idstruttura_ramosuccessivo"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_strutturadefaultview_alias4_idstruttura_ramosuccessivo",cPar,cChild,false));

	cPar = new []{year_alias4.Columns["year"]};
	cChild = new []{pannellofunzioniperf.Columns["year_annosuccessivo"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_year_alias4_year_annosuccessivo",cPar,cChild,false));

	cPar = new []{strutturadefaultview_alias3.Columns["idstruttura"]};
	cChild = new []{pannellofunzioniperf.Columns["idstruttura_ramoprecedente"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_strutturadefaultview_alias3_idstruttura_ramoprecedente",cPar,cChild,false));

	cPar = new []{year_alias3.Columns["year"]};
	cChild = new []{pannellofunzioniperf.Columns["year_annoprecedente"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_year_alias3_year_annoprecedente",cPar,cChild,false));

	cPar = new []{strutturadefaultview_alias2.Columns["idstruttura"]};
	cChild = new []{pannellofunzioniperf.Columns["idstruttura_impobbind"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_strutturadefaultview_alias2_idstruttura_impobbind",cPar,cChild,false));

	cPar = new []{year_alias2.Columns["year"]};
	cChild = new []{pannellofunzioniperf.Columns["year_impobbind"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_year_alias2_year_impobbind",cPar,cChild,false));

	cPar = new []{strutturadefaultview_alias1.Columns["idstruttura"]};
	cChild = new []{pannellofunzioniperf.Columns["idstruttura_impobborg"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_strutturadefaultview_alias1_idstruttura_impobborg",cPar,cChild,false));

	cPar = new []{year_alias1.Columns["year"]};
	cChild = new []{pannellofunzioniperf.Columns["year_impobborg"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_year_alias1_year_impobborg",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{pannellofunzioniperf.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_strutturadefaultview_idstruttura",cPar,cChild,false));

	cPar = new []{mansionekinddefaultview.Columns["idmansionekind"]};
	cChild = new []{pannellofunzioniperf.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_mansionekinddefaultview_idmansionekind",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{pannellofunzioniperf.Columns["year"]};
	Relations.Add(new DataRelation("FK_pannellofunzioniperf_year_year",cPar,cChild,false));

	#endregion

}
}
}
