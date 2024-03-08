
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
[System.Xml.Serialization.XmlRoot("dsmeta_progettobudgetvariazione_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_progettobudgetvariazione_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable progettobudgetvariazione 		=> (MetaTable)Tables["progettobudgetvariazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_progettobudgetvariazione_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_progettobudgetvariazione_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_progettobudgetvariazione_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_progettobudgetvariazione_default.xsd";

	#region create DataTables
	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview.defineColumn("accmotive_ct", typeof(DateTime),false);
	taccmotivedefaultview.defineColumn("accmotive_cu", typeof(string),false);
	taccmotivedefaultview.defineColumn("accmotive_expensekind", typeof(string));
	taccmotivedefaultview.defineColumn("accmotive_flag", typeof(int));
	taccmotivedefaultview.defineColumn("accmotive_flagamm", typeof(string));
	taccmotivedefaultview.defineColumn("accmotive_flagdep", typeof(string));
	taccmotivedefaultview.defineColumn("accmotive_lt", typeof(DateTime),false);
	taccmotivedefaultview.defineColumn("accmotive_lu", typeof(string),false);
	taccmotivedefaultview.defineColumn("accmotive_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("accmotiveparent_codemotive", typeof(string));
	taccmotivedefaultview.defineColumn("accmotiveparent_title", typeof(string));
	taccmotivedefaultview.defineColumn("codemotive", typeof(string),false);
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	taccmotivedefaultview.defineColumn("paridaccmotive", typeof(string));
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

	//////////////////// UPBDEFAULTVIEW /////////////////////////////////
	var tupbdefaultview= new MetaTable("upbdefaultview");
	tupbdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview.defineColumn("epupbkind_description", typeof(string));
	tupbdefaultview.defineColumn("epupbkind_title", typeof(string));
	tupbdefaultview.defineColumn("idtreasurer", typeof(int));
	tupbdefaultview.defineColumn("idunderwriter", typeof(int));
	tupbdefaultview.defineColumn("idupb", typeof(string),false);
	tupbdefaultview.defineColumn("idupb_capofila", typeof(string));
	tupbdefaultview.defineColumn("paridupb", typeof(string));
	tupbdefaultview.defineColumn("title", typeof(string),false);
	tupbdefaultview.defineColumn("treasurer_description", typeof(string));
	tupbdefaultview.defineColumn("underwriter_description", typeof(string));
	tupbdefaultview.defineColumn("upb_active", typeof(string));
	tupbdefaultview.defineColumn("upb_assured", typeof(string));
	tupbdefaultview.defineColumn("upb_cigcode", typeof(string));
	tupbdefaultview.defineColumn("upb_codeupb", typeof(string),false);
	tupbdefaultview.defineColumn("upb_cofogmpcode", typeof(string));
	tupbdefaultview.defineColumn("upb_ct", typeof(DateTime),false);
	tupbdefaultview.defineColumn("upb_cu", typeof(string),false);
	tupbdefaultview.defineColumn("upb_cupcode", typeof(string));
	tupbdefaultview.defineColumn("upb_expiration", typeof(DateTime));
	tupbdefaultview.defineColumn("upb_flag", typeof(int));
	tupbdefaultview.defineColumn("upb_flagactivity", typeof(int));
	tupbdefaultview.defineColumn("upb_flagkind", typeof(int));
	tupbdefaultview.defineColumn("upb_granted", typeof(decimal));
	tupbdefaultview.defineColumn("upb_idepupbkind", typeof(int));
	tupbdefaultview.defineColumn("upb_lt", typeof(DateTime),false);
	tupbdefaultview.defineColumn("upb_lu", typeof(string),false);
	tupbdefaultview.defineColumn("upb_newcodeupb", typeof(string));
	tupbdefaultview.defineColumn("upb_previousappropriation", typeof(decimal));
	tupbdefaultview.defineColumn("upb_previousassessment", typeof(decimal));
	tupbdefaultview.defineColumn("upb_printingorder", typeof(string),false);
	tupbdefaultview.defineColumn("upb_requested", typeof(decimal));
	tupbdefaultview.defineColumn("upb_ri_ra_quota", typeof(decimal));
	tupbdefaultview.defineColumn("upb_ri_rb_quota", typeof(decimal));
	tupbdefaultview.defineColumn("upb_ri_sa_quota", typeof(decimal));
	tupbdefaultview.defineColumn("upb_rtf", typeof(Byte[]));
	tupbdefaultview.defineColumn("upb_start", typeof(DateTime));
	tupbdefaultview.defineColumn("upb_stop", typeof(DateTime));
	tupbdefaultview.defineColumn("upb_txt", typeof(string));
	tupbdefaultview.defineColumn("upb_uesiopecode", typeof(string));
	tupbdefaultview.defineColumn("upbcapofila_title", typeof(string));
	tupbdefaultview.defineColumn("upbparent_title", typeof(string));
	Tables.Add(tupbdefaultview);
	tupbdefaultview.defineKey("idupb");

	//////////////////// PROGETTOBUDGETVARIAZIONE /////////////////////////////////
	var tprogettobudgetvariazione= new MetaTable("progettobudgetvariazione");
	tprogettobudgetvariazione.defineColumn("ct", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("cu", typeof(string));
	tprogettobudgetvariazione.defineColumn("data", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("idaccmotive", typeof(string));
	tprogettobudgetvariazione.defineColumn("idprogetto", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idprogettobudget", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idprogettobudgetvariazione", typeof(int),false);
	tprogettobudgetvariazione.defineColumn("idupb", typeof(string));
	tprogettobudgetvariazione.defineColumn("lt", typeof(DateTime));
	tprogettobudgetvariazione.defineColumn("lu", typeof(string));
	tprogettobudgetvariazione.defineColumn("newamount", typeof(decimal));
	Tables.Add(tprogettobudgetvariazione);
	tprogettobudgetvariazione.defineKey("idprogetto", "idprogettobudget", "idprogettobudgetvariazione");

	#endregion


	#region DataRelation creation
	var cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	var cChild = new []{progettobudgetvariazione.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_progettobudgetvariazione_accmotivedefaultview_idaccmotive",cPar,cChild,false));

	cPar = new []{upbdefaultview.Columns["idupb"]};
	cChild = new []{progettobudgetvariazione.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_progettobudgetvariazione_upbdefaultview_idupb",cPar,cChild,false));

	#endregion

}
}
}
