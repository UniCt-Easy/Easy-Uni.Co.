
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
[System.Xml.Serialization.XmlRoot("dsmeta_tax_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tax_seg: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias2 		=> (MetaTable)Tables["accmotivedefaultview_alias2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview_alias1 		=> (MetaTable)Tables["accmotivedefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tax 		=> (MetaTable)Tables["tax"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tax_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tax_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tax_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tax_seg.xsd";

	#region create DataTables
	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS2 /////////////////////////////////
	var taccmotivedefaultview_alias2= new MetaTable("accmotivedefaultview_alias2");
	taccmotivedefaultview_alias2.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias2.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias2.defineColumn("paridaccmotive", typeof(string));
	taccmotivedefaultview_alias2.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias2);
	taccmotivedefaultview_alias2.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var taccmotivedefaultview_alias1= new MetaTable("accmotivedefaultview_alias1");
	taccmotivedefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview_alias1.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview_alias1.defineColumn("paridaccmotive", typeof(string));
	taccmotivedefaultview_alias1.ExtendedProperties["TableForReading"]="accmotivedefaultview";
	Tables.Add(taccmotivedefaultview_alias1);
	taccmotivedefaultview_alias1.defineKey("idaccmotive");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview.defineColumn("paridaccmotive", typeof(string));
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

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
	Tables.Add(ttax);
	ttax.defineKey("taxcode");

	#endregion


	#region DataRelation creation
	var cPar = new []{accmotivedefaultview_alias2.Columns["idaccmotive"]};
	var cChild = new []{tax.Columns["idaccmotive_pay"]};
	Relations.Add(new DataRelation("FK_tax_accmotivedefaultview_alias2_idaccmotive_pay",cPar,cChild,false));

	cPar = new []{accmotivedefaultview_alias1.Columns["idaccmotive"]};
	cChild = new []{tax.Columns["idaccmotive_debit"]};
	Relations.Add(new DataRelation("FK_tax_accmotivedefaultview_alias1_idaccmotive_debit",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{tax.Columns["idaccmotive_cost"]};
	Relations.Add(new DataRelation("FK_tax_accmotivedefaultview_idaccmotive_cost",cPar,cChild,false));

	#endregion

}
}
}
