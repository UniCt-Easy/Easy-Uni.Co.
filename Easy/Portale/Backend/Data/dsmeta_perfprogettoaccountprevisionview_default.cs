
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettoaccountprevisionview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettoaccountprevisionview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitadefaultview_alias1 		=> (MetaTable)Tables["perfprogettoobiettivoattivitadefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivoattivitadefaultview 		=> (MetaTable)Tables["perfprogettoobiettivoattivitadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoobiettivo 		=> (MetaTable)Tables["perfprogettoobiettivo"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettodefaultview 		=> (MetaTable)Tables["perfprogettodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable account 		=> (MetaTable)Tables["account"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettoaccountprevisionview 		=> (MetaTable)Tables["perfprogettoaccountprevisionview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettoaccountprevisionview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettoaccountprevisionview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettoaccountprevisionview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettoaccountprevisionview_default.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOOBIETTIVOATTIVITADEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tperfprogettoobiettivoattivitadefaultview_alias1= new MetaTable("perfprogettoobiettivoattivitadefaultview_alias1");
	tperfprogettoobiettivoattivitadefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettoobiettivoattivitadefaultview_alias1.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview_alias1.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview_alias1.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview_alias1.ExtendedProperties["TableForReading"]="perfprogettoobiettivoattivitadefaultview";
	Tables.Add(tperfprogettoobiettivoattivitadefaultview_alias1);
	tperfprogettoobiettivoattivitadefaultview_alias1.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// UPBDEFAULTVIEW /////////////////////////////////
	var tupbdefaultview= new MetaTable("upbdefaultview");
	tupbdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview.defineColumn("idupb", typeof(string),false);
	tupbdefaultview.defineColumn("upb_active", typeof(string));
	Tables.Add(tupbdefaultview);
	tupbdefaultview.defineKey("idupb");

	//////////////////// PERFPROGETTOOBIETTIVOATTIVITADEFAULTVIEW /////////////////////////////////
	var tperfprogettoobiettivoattivitadefaultview= new MetaTable("perfprogettoobiettivoattivitadefaultview");
	tperfprogettoobiettivoattivitadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettoobiettivoattivitadefaultview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivoattivitadefaultview.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	Tables.Add(tperfprogettoobiettivoattivitadefaultview);
	tperfprogettoobiettivoattivitadefaultview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	//////////////////// PERFPROGETTOOBIETTIVO /////////////////////////////////
	var tperfprogettoobiettivo= new MetaTable("perfprogettoobiettivo");
	tperfprogettoobiettivo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoobiettivo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettoobiettivo);
	tperfprogettoobiettivo.defineKey("idperfprogetto", "idperfprogettoobiettivo");

	//////////////////// PERFPROGETTODEFAULTVIEW /////////////////////////////////
	var tperfprogettodefaultview= new MetaTable("perfprogettodefaultview");
	tperfprogettodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tperfprogettodefaultview.defineColumn("idperfprogetto", typeof(int),false);
	Tables.Add(tperfprogettodefaultview);
	tperfprogettodefaultview.defineKey("idperfprogetto");

	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new MetaTable("account");
	taccount.defineColumn("ayear", typeof(int),false);
	taccount.defineColumn("codeacc", typeof(string),false);
	taccount.defineColumn("idacc", typeof(string),false);
	taccount.defineColumn("title", typeof(string),false);
	Tables.Add(taccount);
	taccount.defineKey("idacc");

	//////////////////// PERFPROGETTOACCOUNTPREVISIONVIEW /////////////////////////////////
	var tperfprogettoaccountprevisionview= new MetaTable("perfprogettoaccountprevisionview");
	tperfprogettoaccountprevisionview.defineColumn("account", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("availableprevision", typeof(decimal));
	tperfprogettoaccountprevisionview.defineColumn("codeacc", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("codeupb", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("currentprevision", typeof(decimal));
	tperfprogettoaccountprevisionview.defineColumn("idacc", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettoaccountprevisionview.defineColumn("idperfprogettoobiettivo", typeof(int),false);
	tperfprogettoaccountprevisionview.defineColumn("idperfprogettoobiettivoattivita", typeof(int),false);
	tperfprogettoaccountprevisionview.defineColumn("idupb", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("paridperfprogettoobiettivoattivita", typeof(int));
	tperfprogettoaccountprevisionview.defineColumn("perfprogetto_title", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("perfprogettoobiettivo_title", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("perfprogettoobiettivoattivita_title", typeof(string));
	tperfprogettoaccountprevisionview.defineColumn("prevision", typeof(decimal));
	tperfprogettoaccountprevisionview.defineColumn("upb", typeof(string));
	Tables.Add(tperfprogettoaccountprevisionview);
	tperfprogettoaccountprevisionview.defineKey("idperfprogetto", "idperfprogettoobiettivo", "idperfprogettoobiettivoattivita");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettoobiettivoattivitadefaultview_alias1.Columns["idperfprogettoobiettivoattivita"]};
	var cChild = new []{perfprogettoaccountprevisionview.Columns["paridperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoaccountprevisionview_perfprogettoobiettivoattivitadefaultview_alias1_paridperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{upbdefaultview.Columns["idupb"]};
	cChild = new []{perfprogettoaccountprevisionview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettoaccountprevisionview_upbdefaultview_idupb",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivoattivitadefaultview.Columns["idperfprogettoobiettivoattivita"]};
	cChild = new []{perfprogettoaccountprevisionview.Columns["idperfprogettoobiettivoattivita"]};
	Relations.Add(new DataRelation("FK_perfprogettoaccountprevisionview_perfprogettoobiettivoattivitadefaultview_idperfprogettoobiettivoattivita",cPar,cChild,false));

	cPar = new []{perfprogettoobiettivo.Columns["idperfprogettoobiettivo"]};
	cChild = new []{perfprogettoaccountprevisionview.Columns["idperfprogettoobiettivo"]};
	Relations.Add(new DataRelation("FK_perfprogettoaccountprevisionview_perfprogettoobiettivo_idperfprogettoobiettivo",cPar,cChild,false));

	cPar = new []{perfprogettodefaultview.Columns["idperfprogetto"]};
	cChild = new []{perfprogettoaccountprevisionview.Columns["idperfprogetto"]};
	Relations.Add(new DataRelation("FK_perfprogettoaccountprevisionview_perfprogettodefaultview_idperfprogetto",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{perfprogettoaccountprevisionview.Columns["idacc"]};
	Relations.Add(new DataRelation("FK_perfprogettoaccountprevisionview_account_idacc",cPar,cChild,false));

	#endregion

}
}
}
