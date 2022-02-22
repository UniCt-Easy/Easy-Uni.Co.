
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
[System.Xml.Serialization.XmlRoot("dsmeta_dichiar_isee_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_dichiar_isee_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiarkinddefaultview 		=> (MetaTable)Tables["dichiarkinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar 		=> (MetaTable)Tables["dichiar"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable dichiar_isee 		=> (MetaTable)Tables["dichiar_isee"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_dichiar_isee_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_dichiar_isee_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_dichiar_isee_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_dichiar_isee_seganagstu.xsd";

	#region create DataTables
	//////////////////// DICHIARKINDDEFAULTVIEW /////////////////////////////////
	var tdichiarkinddefaultview= new MetaTable("dichiarkinddefaultview");
	tdichiarkinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdichiarkinddefaultview.defineColumn("iddichiarkind", typeof(int),false);
	Tables.Add(tdichiarkinddefaultview);
	tdichiarkinddefaultview.defineKey("iddichiarkind");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DICHIAR /////////////////////////////////
	var tdichiar= new MetaTable("dichiar");
	tdichiar.defineColumn("aa", typeof(string));
	tdichiar.defineColumn("ct", typeof(DateTime),false);
	tdichiar.defineColumn("cu", typeof(string),false);
	tdichiar.defineColumn("date", typeof(DateTime),false);
	tdichiar.defineColumn("extension", typeof(string));
	tdichiar.defineColumn("iddichiar", typeof(int),false);
	tdichiar.defineColumn("iddichiarkind", typeof(int),false);
	tdichiar.defineColumn("idreg", typeof(int),false);
	tdichiar.defineColumn("lt", typeof(DateTime),false);
	tdichiar.defineColumn("lu", typeof(string),false);
	tdichiar.defineColumn("protanno", typeof(int));
	tdichiar.defineColumn("protnumero", typeof(int));
	Tables.Add(tdichiar);
	tdichiar.defineKey("iddichiar", "idreg");

	//////////////////// DICHIAR_ISEE /////////////////////////////////
	var tdichiar_isee= new MetaTable("dichiar_isee");
	tdichiar_isee.defineColumn("anno", typeof(int),false);
	tdichiar_isee.defineColumn("conforme", typeof(string),false);
	tdichiar_isee.defineColumn("ct", typeof(DateTime),false);
	tdichiar_isee.defineColumn("cu", typeof(string),false);
	tdichiar_isee.defineColumn("dataauthdiff", typeof(DateTime));
	tdichiar_isee.defineColumn("datasottoscriz", typeof(DateTime),false);
	tdichiar_isee.defineColumn("enterilascio", typeof(string),false);
	tdichiar_isee.defineColumn("iddichiar", typeof(int),false);
	tdichiar_isee.defineColumn("idreg", typeof(int),false);
	tdichiar_isee.defineColumn("isee", typeof(decimal),false);
	tdichiar_isee.defineColumn("lt", typeof(DateTime),false);
	tdichiar_isee.defineColumn("lu", typeof(string),false);
	tdichiar_isee.defineColumn("numeroprot", typeof(string),false);
	Tables.Add(tdichiar_isee);
	tdichiar_isee.defineKey("iddichiar", "idreg");

	#endregion


	#region DataRelation creation
	this.defineRelation("FK_dichiar_dichiarkinddefaultview_iddichiarkind","dichiarkinddefaultview","dichiar","iddichiarkind");
	this.defineRelation("FK_dichiar_annoaccademico_aa","annoaccademico","dichiar","aa");
	this.defineRelation("FK_dichiar_isee_dichiar_iddichiar-idreg-","dichiar","dichiar_isee","iddichiar","idreg");
	#endregion

}
}
}
