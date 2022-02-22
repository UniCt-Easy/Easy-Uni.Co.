
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettotipocostokindtax_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_progettotipocostokindtax_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotive 		=> (MetaTable)Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettotipocostokindtax 		=> (MetaTable)Tables["progettotipocostokindtax"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettotipocostokindtax_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettotipocostokindtax_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettotipocostokindtax_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettotipocostokindtax_seg.xsd";

	#region create DataTables
	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new MetaTable("accmotive");
	taccmotive.defineColumn("idaccmotive", typeof(string),false);
	taccmotive.defineColumn("title", typeof(string),false);
	Tables.Add(taccmotive);
	taccmotive.defineKey("idaccmotive");

	//////////////////// TAX /////////////////////////////////
	var ttax= new MetaTable("tax");
	ttax.defineColumn("active", typeof(string));
	ttax.defineColumn("appliancebasis", typeof(string));
	ttax.defineColumn("ct", typeof(DateTime),false);
	ttax.defineColumn("cu", typeof(string),false);
	ttax.defineColumn("description", typeof(string),false);
	ttax.defineColumn("fiscaltaxcode", typeof(string));
	ttax.defineColumn("fiscaltaxcodecredit", typeof(string));
	ttax.defineColumn("flagunabatable", typeof(string));
	ttax.defineColumn("geoappliance", typeof(string));
	ttax.defineColumn("idaccmotive_cost", typeof(string));
	ttax.defineColumn("idaccmotive_debit", typeof(string));
	ttax.defineColumn("idaccmotive_pay", typeof(string));
	ttax.defineColumn("insuranceagencycode", typeof(string));
	ttax.defineColumn("lt", typeof(DateTime),false);
	ttax.defineColumn("lu", typeof(string),false);
	ttax.defineColumn("maintaxcode", typeof(int));
	ttax.defineColumn("taxablecode", typeof(string));
	ttax.defineColumn("taxcode", typeof(int),false);
	ttax.defineColumn("taxkind", typeof(int),false);
	ttax.defineColumn("taxref", typeof(string),false);
	ttax.defineColumn("!idaccmotive_cost_accmotive_title", typeof(string));
	ttax.defineColumn("!idaccmotive_debit_accmotive_title", typeof(string));
	ttax.defineColumn("!idaccmotive_pay_accmotive_title", typeof(string));
	Tables.Add(ttax);
	ttax.defineKey("taxcode");

	//////////////////// PROGETTOTIPOCOSTOKINDTAX /////////////////////////////////
	var tprogettotipocostokindtax= new MetaTable("progettotipocostokindtax");
	tprogettotipocostokindtax.defineColumn("ct", typeof(DateTime));
	tprogettotipocostokindtax.defineColumn("cu", typeof(string));
	tprogettotipocostokindtax.defineColumn("idprogettokind", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("idprogettotipocostokind", typeof(int),false);
	tprogettotipocostokindtax.defineColumn("lt", typeof(DateTime));
	tprogettotipocostokindtax.defineColumn("lu", typeof(string));
	tprogettotipocostokindtax.defineColumn("taxcode", typeof(int),false);
	Tables.Add(tprogettotipocostokindtax);
	tprogettotipocostokindtax.defineKey("idprogettokind", "idprogettotipocostokind", "taxcode");

	#endregion


	#region DataRelation creation
	var cPar = new []{tax.Columns["taxcode"]};
	var cChild = new []{progettotipocostokindtax.Columns["taxcode"]};
	Relations.Add(new DataRelation("FK_progettotipocostokindtax_tax_taxcode",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{tax.Columns["idaccmotive_pay"]};
	Relations.Add(new DataRelation("FK_tax_accmotive_idaccmotive_pay",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{tax.Columns["idaccmotive_debit"]};
	Relations.Add(new DataRelation("FK_tax_accmotive_idaccmotive_debit",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{tax.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("FK_tax_accmotive_idaccmotive_cost",cPar,cChild,false));

	#endregion

}
}
}
