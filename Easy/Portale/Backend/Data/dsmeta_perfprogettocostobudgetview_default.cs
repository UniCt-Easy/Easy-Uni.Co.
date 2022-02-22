
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettocostobudgetview_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfprogettocostobudgetview_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettocostobudgetview 		=> (MetaTable)Tables["perfprogettocostobudgetview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettocostobudgetview_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettocostobudgetview_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettocostobudgetview_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettocostobudgetview_default.xsd";

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
	Tables.Add(tperfprogettocostobudgetview);
	tperfprogettocostobudgetview.defineKey("nvar", "rownum", "yvar");

	#endregion

}
}
}
