
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
[System.Xml.Serialization.XmlRoot("dsmeta_ricostruzioneperiodonv_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_ricostruzioneperiodonv_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nonvalutabilitakinddefaultview 		=> (MetaTable)Tables["nonvalutabilitakinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico_alias1 		=> (MetaTable)Tables["annoaccademico_alias1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable ricostruzioneperiodonv 		=> (MetaTable)Tables["ricostruzioneperiodonv"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_ricostruzioneperiodonv_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_ricostruzioneperiodonv_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_ricostruzioneperiodonv_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_ricostruzioneperiodonv_default.xsd";

	#region create DataTables
	//////////////////// NONVALUTABILITAKINDDEFAULTVIEW /////////////////////////////////
	var tnonvalutabilitakinddefaultview= new MetaTable("nonvalutabilitakinddefaultview");
	tnonvalutabilitakinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tnonvalutabilitakinddefaultview.defineColumn("idnonvalutabilitakind", typeof(int),false);
	tnonvalutabilitakinddefaultview.defineColumn("nonvalutabilitakind_active", typeof(string));
	Tables.Add(tnonvalutabilitakinddefaultview);
	tnonvalutabilitakinddefaultview.defineKey("idnonvalutabilitakind");

	//////////////////// ANNOACCADEMICO_ALIAS1 /////////////////////////////////
	var tannoaccademico_alias1= new MetaTable("annoaccademico_alias1");
	tannoaccademico_alias1.defineColumn("aa", typeof(string),false);
	tannoaccademico_alias1.ExtendedProperties["TableForReading"]="annoaccademico";
	Tables.Add(tannoaccademico_alias1);
	tannoaccademico_alias1.defineKey("aa");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// RICOSTRUZIONEPERIODONV /////////////////////////////////
	var tricostruzioneperiodonv= new MetaTable("ricostruzioneperiodonv");
	tricostruzioneperiodonv.defineColumn("aa_start", typeof(string));
	tricostruzioneperiodonv.defineColumn("aa_stop", typeof(string));
	tricostruzioneperiodonv.defineColumn("idnonvalutabilitakind", typeof(int));
	tricostruzioneperiodonv.defineColumn("idreg", typeof(int),false);
	tricostruzioneperiodonv.defineColumn("idricostruzione", typeof(int),false);
	tricostruzioneperiodonv.defineColumn("idricostruzioneperiodonv", typeof(int),false);
	Tables.Add(tricostruzioneperiodonv);
	tricostruzioneperiodonv.defineKey("idreg", "idricostruzione", "idricostruzioneperiodonv");

	#endregion


	#region DataRelation creation
	var cPar = new []{nonvalutabilitakinddefaultview.Columns["idnonvalutabilitakind"]};
	var cChild = new []{ricostruzioneperiodonv.Columns["idnonvalutabilitakind"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_nonvalutabilitakinddefaultview_idnonvalutabilitakind",cPar,cChild,false));

	cPar = new []{annoaccademico_alias1.Columns["aa"]};
	cChild = new []{ricostruzioneperiodonv.Columns["aa_stop"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_annoaccademico_alias1_aa_stop",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{ricostruzioneperiodonv.Columns["aa_start"]};
	Relations.Add(new DataRelation("FK_ricostruzioneperiodonv_annoaccademico_aa_start",cPar,cChild,false));

	#endregion

}
}
}
