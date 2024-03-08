
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
[System.Xml.Serialization.XmlRoot("dsmeta_graduatoriaesitipos_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_graduatoriaesitipos_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable registrystudentiview 		=> (MetaTable)Tables["registrystudentiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable graduatoriaesitipos 		=> (MetaTable)Tables["graduatoriaesitipos"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_graduatoriaesitipos_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_graduatoriaesitipos_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_graduatoriaesitipos_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_graduatoriaesitipos_default.xsd";

	#region create DataTables
	//////////////////// REGISTRYSTUDENTIVIEW /////////////////////////////////
	var tregistrystudentiview= new MetaTable("registrystudentiview");
	tregistrystudentiview.defineColumn("dropdown_title", typeof(string),false);
	tregistrystudentiview.defineColumn("idcity", typeof(int));
	tregistrystudentiview.defineColumn("idnation", typeof(int));
	tregistrystudentiview.defineColumn("idreg", typeof(int),false);
	tregistrystudentiview.defineColumn("idregistryclass", typeof(string));
	tregistrystudentiview.defineColumn("idtitle", typeof(string));
	tregistrystudentiview.defineColumn("residence", typeof(int),false);
	Tables.Add(tregistrystudentiview);
	tregistrystudentiview.defineKey("idreg");

	//////////////////// GRADUATORIAESITIPOS /////////////////////////////////
	var tgraduatoriaesitipos= new MetaTable("graduatoriaesitipos");
	tgraduatoriaesitipos.defineColumn("ct", typeof(DateTime),false);
	tgraduatoriaesitipos.defineColumn("cu", typeof(string),false);
	tgraduatoriaesitipos.defineColumn("idcorsostudio", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idgraduatoriaesiti", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idgraduatoriaesitipos", typeof(int),false);
	tgraduatoriaesitipos.defineColumn("idreg_studenti", typeof(int));
	tgraduatoriaesitipos.defineColumn("idtipologiastudente", typeof(int));
	tgraduatoriaesitipos.defineColumn("lt", typeof(DateTime),false);
	tgraduatoriaesitipos.defineColumn("lu", typeof(string),false);
	tgraduatoriaesitipos.defineColumn("pos", typeof(int));
	tgraduatoriaesitipos.defineColumn("punteggio", typeof(decimal));
	Tables.Add(tgraduatoriaesitipos);
	tgraduatoriaesitipos.defineKey("idcorsostudio", "idgraduatoriaesiti", "idgraduatoriaesitipos");

	#endregion


	#region DataRelation creation
	var cPar = new []{registrystudentiview.Columns["idreg"]};
	var cChild = new []{graduatoriaesitipos.Columns["idreg_studenti"]};
	Relations.Add(new DataRelation("FK_graduatoriaesitipos_registrystudentiview_idreg_studenti",cPar,cChild,false));

	#endregion

}
}
}
