
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
[System.Xml.Serialization.XmlRoot("dsmeta_upb_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_upb_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview 		=> (MetaTable)Tables["upbdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upbdefaultview_alias1 		=> (MetaTable)Tables["upbdefaultview_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable underwriter 		=> (MetaTable)Tables["underwriter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable treasurer 		=> (MetaTable)Tables["treasurer"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable epupbkind 		=> (MetaTable)Tables["epupbkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable upb 		=> (MetaTable)Tables["upb"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_upb_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_upb_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_upb_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_upb_default.xsd";

	#region create DataTables
	//////////////////// UPBDEFAULTVIEW /////////////////////////////////
	var tupbdefaultview= new MetaTable("upbdefaultview");
	tupbdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview.defineColumn("idtreasurer", typeof(int));
	tupbdefaultview.defineColumn("idunderwriter", typeof(int));
	tupbdefaultview.defineColumn("idupb", typeof(string),false);
	tupbdefaultview.defineColumn("idupb_capofila", typeof(string));
	tupbdefaultview.defineColumn("paridupb", typeof(string));
	Tables.Add(tupbdefaultview);
	tupbdefaultview.defineKey("idupb");

	//////////////////// UPBDEFAULTVIEW_ALIAS1 /////////////////////////////////
	var tupbdefaultview_alias1= new MetaTable("upbdefaultview_alias1");
	tupbdefaultview_alias1.defineColumn("dropdown_title", typeof(string),false);
	tupbdefaultview_alias1.defineColumn("idtreasurer", typeof(int));
	tupbdefaultview_alias1.defineColumn("idunderwriter", typeof(int));
	tupbdefaultview_alias1.defineColumn("idupb", typeof(string),false);
	tupbdefaultview_alias1.defineColumn("idupb_capofila", typeof(string));
	tupbdefaultview_alias1.defineColumn("paridupb", typeof(string));
	tupbdefaultview_alias1.ExtendedProperties["TableForReading"]="upbdefaultview";
	Tables.Add(tupbdefaultview_alias1);
	tupbdefaultview_alias1.defineKey("idupb");

	//////////////////// UNDERWRITER /////////////////////////////////
	var tunderwriter= new MetaTable("underwriter");
	tunderwriter.defineColumn("description", typeof(string),false);
	tunderwriter.defineColumn("idunderwriter", typeof(int),false);
	Tables.Add(tunderwriter);
	tunderwriter.defineKey("idunderwriter");

	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new MetaTable("treasurer");
	ttreasurer.defineColumn("description", typeof(string));
	ttreasurer.defineColumn("idtreasurer", typeof(int),false);
	Tables.Add(ttreasurer);
	ttreasurer.defineKey("idtreasurer");

	//////////////////// EPUPBKIND /////////////////////////////////
	var tepupbkind= new MetaTable("epupbkind");
	tepupbkind.defineColumn("description", typeof(string));
	tepupbkind.defineColumn("idepupbkind", typeof(int),false);
	tepupbkind.defineColumn("title", typeof(string),false);
	Tables.Add(tepupbkind);
	tepupbkind.defineKey("idepupbkind");

	//////////////////// UPB /////////////////////////////////
	var tupb= new MetaTable("upb");
	tupb.defineColumn("active", typeof(string));
	tupb.defineColumn("assured", typeof(string));
	tupb.defineColumn("cigcode", typeof(string));
	tupb.defineColumn("codeupb", typeof(string),false);
	tupb.defineColumn("cofogmpcode", typeof(string));
	tupb.defineColumn("ct", typeof(DateTime),false);
	tupb.defineColumn("cu", typeof(string),false);
	tupb.defineColumn("cupcode", typeof(string));
	tupb.defineColumn("expiration", typeof(DateTime));
	tupb.defineColumn("flag", typeof(int));
	tupb.defineColumn("flagactivity", typeof(int));
	tupb.defineColumn("flagkind", typeof(int));
	tupb.defineColumn("granted", typeof(decimal));
	tupb.defineColumn("idepupbkind", typeof(int));
	tupb.defineColumn("idtreasurer", typeof(int));
	tupb.defineColumn("idunderwriter", typeof(int));
	tupb.defineColumn("idupb", typeof(string),false);
	tupb.defineColumn("idupb_capofila", typeof(string));
	tupb.defineColumn("lt", typeof(DateTime),false);
	tupb.defineColumn("lu", typeof(string),false);
	tupb.defineColumn("newcodeupb", typeof(string));
	tupb.defineColumn("paridupb", typeof(string));
	tupb.defineColumn("previousappropriation", typeof(decimal));
	tupb.defineColumn("previousassessment", typeof(decimal));
	tupb.defineColumn("printingorder", typeof(string),false);
	tupb.defineColumn("requested", typeof(decimal));
	tupb.defineColumn("ri_ra_quota", typeof(decimal));
	tupb.defineColumn("ri_rb_quota", typeof(decimal));
	tupb.defineColumn("ri_sa_quota", typeof(decimal));
	tupb.defineColumn("rtf", typeof(Byte[]));
	tupb.defineColumn("start", typeof(DateTime));
	tupb.defineColumn("stop", typeof(DateTime));
	tupb.defineColumn("title", typeof(string),false);
	tupb.defineColumn("txt", typeof(string));
	tupb.defineColumn("uesiopecode", typeof(string));
	Tables.Add(tupb);
	tupb.defineKey("idupb");

	#endregion


	#region DataRelation creation
	var cPar = new []{upbdefaultview.Columns["idupb"]};
	var cChild = new []{upb.Columns["paridupb"]};
	Relations.Add(new DataRelation("FK_upb_upbdefaultview_paridupb",cPar,cChild,false));

	cPar = new []{upbdefaultview_alias1.Columns["idupb"]};
	cChild = new []{upb.Columns["idupb_capofila"]};
	Relations.Add(new DataRelation("FK_upb_upbdefaultview_alias1_idupb_capofila",cPar,cChild,false));

	cPar = new []{underwriter.Columns["idunderwriter"]};
	cChild = new []{upb.Columns["idunderwriter"]};
	Relations.Add(new DataRelation("FK_upb_underwriter_idunderwriter",cPar,cChild,false));

	cPar = new []{treasurer.Columns["idtreasurer"]};
	cChild = new []{upb.Columns["idtreasurer"]};
	Relations.Add(new DataRelation("FK_upb_treasurer_idtreasurer",cPar,cChild,false));

	cPar = new []{epupbkind.Columns["idepupbkind"]};
	cChild = new []{upb.Columns["idepupbkind"]};
	Relations.Add(new DataRelation("FK_upb_epupbkind_idepupbkind",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{upb.Columns["paridupb"]};
	Relations.Add(new DataRelation("FK_upb_upb_idupb",cPar,cChild,false));

	#endregion

}
}
}
