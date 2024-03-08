
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettocosto_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettocosto_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocostobudgetview 		=> (MetaTable)Tables["perfprogettocostobudgetview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getcostoview 		=> (MetaTable)Tables["getcostoview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable accmotivedefaultview 		=> (MetaTable)Tables["accmotivedefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable year 		=> (MetaTable)Tables["year"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocosto 		=> (MetaTable)Tables["perfprogettocosto"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettocosto_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettocosto_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettocosto_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettocosto_default.xsd";

	#region create DataTables
	//////////////////// PERFPROGETTOCOSTOBUDGETVIEW /////////////////////////////////
	var tperfprogettocostobudgetview= new MetaTable("perfprogettocostobudgetview");
	tperfprogettocostobudgetview.defineColumn("amount", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount2", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount3", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount4", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("amount5", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("annotation", typeof(string));
	tperfprogettocostobudgetview.defineColumn("ct", typeof(DateTime),false);
	tperfprogettocostobudgetview.defineColumn("cu", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("description", typeof(string));
	tperfprogettocostobudgetview.defineColumn("idacc", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("idaccmotive", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("idcostpartition", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idinv", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idsor1", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idsor2", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idsor3", typeof(int));
	tperfprogettocostobudgetview.defineColumn("idupb", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("lt", typeof(DateTime),false);
	tperfprogettocostobudgetview.defineColumn("lu", typeof(string),false);
	tperfprogettocostobudgetview.defineColumn("nvar", typeof(int),false);
	tperfprogettocostobudgetview.defineColumn("prevcassa", typeof(decimal));
	tperfprogettocostobudgetview.defineColumn("rownum", typeof(int),false);
	tperfprogettocostobudgetview.defineColumn("underwritingkind", typeof(string));
	tperfprogettocostobudgetview.defineColumn("underwritingkind_desc", typeof(string));
	tperfprogettocostobudgetview.defineColumn("yvar", typeof(int),false);
	tperfprogettocostobudgetview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tperfprogettocostobudgetview);
	tperfprogettocostobudgetview.defineKey("nvar", "rownum", "yvar");

	//////////////////// GETCOSTOVIEW /////////////////////////////////
	var tgetcostoview= new MetaTable("getcostoview");
	tgetcostoview.defineColumn("accmotive_title", typeof(string));
	tgetcostoview.defineColumn("adate", typeof(DateTime));
	tgetcostoview.defineColumn("amount", typeof(decimal));
	tgetcostoview.defineColumn("cf", typeof(string));
	tgetcostoview.defineColumn("description", typeof(string));
	tgetcostoview.defineColumn("doc", typeof(string));
	tgetcostoview.defineColumn("docdate", typeof(DateTime));
	tgetcostoview.defineColumn("idaccmotive", typeof(string),false);
	tgetcostoview.defineColumn("idexp", typeof(int),false);
	tgetcostoview.defineColumn("idupb", typeof(string),false);
	tgetcostoview.defineColumn("nmov", typeof(int));
	tgetcostoview.defineColumn("p_iva", typeof(string));
	tgetcostoview.defineColumn("payment_adate", typeof(DateTime));
	tgetcostoview.defineColumn("registry_title", typeof(string));
	tgetcostoview.defineColumn("transactiondate", typeof(DateTime));
	tgetcostoview.defineColumn("transmissiondate", typeof(DateTime));
	tgetcostoview.defineColumn("ymov", typeof(int),false);
	tgetcostoview.ExtendedProperties["NotEntityChild"]="true";
	Tables.Add(tgetcostoview);
	tgetcostoview.defineKey("idaccmotive", "idexp", "idupb", "ymov");

	//////////////////// UPBDEFAULTVIEW /////////////////////////////////
	var tupbdefaultview= new MetaTable("upbdefaultview");
	tupbdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview.defineColumn("idupb", typeof(string),false);
	tupbdefaultview.defineColumn("upb_active", typeof(string));
	Tables.Add(tupbdefaultview);
	tupbdefaultview.defineKey("idupb");

	//////////////////// ACCMOTIVEDEFAULTVIEW /////////////////////////////////
	var taccmotivedefaultview= new MetaTable("accmotivedefaultview");
	taccmotivedefaultview.defineColumn("accmotive_active", typeof(string));
	taccmotivedefaultview.defineColumn("dropdown_title", typeof(string),false);
	taccmotivedefaultview.defineColumn("idaccmotive", typeof(string),false);
	Tables.Add(taccmotivedefaultview);
	taccmotivedefaultview.defineKey("idaccmotive");

	//////////////////// YEAR /////////////////////////////////
	var tyear= new MetaTable("year");
	tyear.defineColumn("year", typeof(int),false);
	Tables.Add(tyear);
	tyear.defineKey("year");

	//////////////////// PERFPROGETTOCOSTO /////////////////////////////////
	var tperfprogettocosto= new MetaTable("perfprogettocosto");
	tperfprogettocosto.defineColumn("budget", typeof(decimal));
	tperfprogettocosto.defineColumn("budgetcurr", typeof(decimal));
	tperfprogettocosto.defineColumn("consuntivo", typeof(decimal));
	tperfprogettocosto.defineColumn("ct", typeof(DateTime),false);
	tperfprogettocosto.defineColumn("cu", typeof(string),false);
	tperfprogettocosto.defineColumn("idaccmotive", typeof(string),false);
	tperfprogettocosto.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettocosto.defineColumn("idperfprogettocosto", typeof(int),false);
	tperfprogettocosto.defineColumn("idupb", typeof(string),false);
	tperfprogettocosto.defineColumn("lt", typeof(DateTime),false);
	tperfprogettocosto.defineColumn("lu", typeof(string),false);
	tperfprogettocosto.defineColumn("year", typeof(int),false);
	Tables.Add(tperfprogettocosto);
	tperfprogettocosto.defineKey("idaccmotive", "idperfprogetto", "idperfprogettocosto", "idupb", "year");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettocosto.Columns["idaccmotive"], perfprogettocosto.Columns["idupb"]};
	var cChild = new []{perfprogettocostobudgetview.Columns["idaccmotive"], perfprogettocostobudgetview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettocostobudgetview_perfprogettocosto_idaccmotive-idupb",cPar,cChild,false));

	cPar = new []{perfprogettocosto.Columns["idaccmotive"], perfprogettocosto.Columns["idupb"]};
	cChild = new []{getcostoview.Columns["idaccmotive"], getcostoview.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_getcostoview_perfprogettocosto_idaccmotive-idupb",cPar,cChild,false));

	cPar = new []{upbdefaultview.Columns["idupb"]};
	cChild = new []{perfprogettocosto.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_upbdefaultview_idupb",cPar,cChild,false));

	cPar = new []{accmotivedefaultview.Columns["idaccmotive"]};
	cChild = new []{perfprogettocosto.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_accmotivedefaultview_idaccmotive",cPar,cChild,false));

	cPar = new []{year.Columns["year"]};
	cChild = new []{perfprogettocosto.Columns["year"]};
	Relations.Add(new DataRelation("FK_perfprogettocosto_year_year",cPar,cChild,false));

	#endregion

}
}
}
