
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfvalutazioneateneovalidatore_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfvalutazioneateneovalidatore_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable validatori 		=> (MetaTable)Tables["validatori"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfmission 		=> (MetaTable)Tables["perfmission"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfvalutazioneateneovalidatore 		=> (MetaTable)Tables["perfvalutazioneateneovalidatore"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfvalutazioneateneovalidatore_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfvalutazioneateneovalidatore_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfvalutazioneateneovalidatore_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfvalutazioneateneovalidatore_default.xsd";

	#region create DataTables
	//////////////////// VALIDATORI /////////////////////////////////
	var tvalidatori= new MetaTable("validatori");
	tvalidatori.defineColumn("ct", typeof(DateTime));
	tvalidatori.defineColumn("cu", typeof(string));
	tvalidatori.defineColumn("idvalidatori", typeof(int),false);
	tvalidatori.defineColumn("lt", typeof(DateTime));
	tvalidatori.defineColumn("lu", typeof(string));
	tvalidatori.defineColumn("title", typeof(string));
	Tables.Add(tvalidatori);
	tvalidatori.defineKey("idvalidatori");

	//////////////////// PERFMISSION /////////////////////////////////
	var tperfmission= new MetaTable("perfmission");
	tperfmission.defineColumn("ct", typeof(DateTime));
	tperfmission.defineColumn("cu", typeof(string));
	tperfmission.defineColumn("idperfmission", typeof(int),false);
	tperfmission.defineColumn("lt", typeof(DateTime));
	tperfmission.defineColumn("lu", typeof(string));
	tperfmission.defineColumn("title", typeof(string));
	Tables.Add(tperfmission);
	tperfmission.defineKey("idperfmission");

	//////////////////// PERFVALUTAZIONEATENEOVALIDATORE /////////////////////////////////
	var tperfvalutazioneateneovalidatore= new MetaTable("perfvalutazioneateneovalidatore");
	tperfvalutazioneateneovalidatore.defineColumn("ct", typeof(DateTime),false);
	tperfvalutazioneateneovalidatore.defineColumn("cu", typeof(string),false);
	tperfvalutazioneateneovalidatore.defineColumn("idperfmission", typeof(int),false);
	tperfvalutazioneateneovalidatore.defineColumn("idperfvalutazioneateneo", typeof(int),false);
	tperfvalutazioneateneovalidatore.defineColumn("idperfvalutazioneateneores", typeof(int),false);
	tperfvalutazioneateneovalidatore.defineColumn("idvalidatori", typeof(int),false);
	tperfvalutazioneateneovalidatore.defineColumn("lt", typeof(DateTime),false);
	tperfvalutazioneateneovalidatore.defineColumn("lu", typeof(string),false);
	Tables.Add(tperfvalutazioneateneovalidatore);
	tperfvalutazioneateneovalidatore.defineKey("idperfmission", "idperfvalutazioneateneo", "idperfvalutazioneateneores", "idvalidatori");

	#endregion


	#region DataRelation creation
	var cPar = new []{validatori.Columns["idvalidatori"]};
	var cChild = new []{perfvalutazioneateneovalidatore.Columns["idvalidatori"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneovalidatore_validatori_idvalidatori",cPar,cChild,false));

	cPar = new []{perfmission.Columns["idperfmission"]};
	cChild = new []{perfvalutazioneateneovalidatore.Columns["idperfmission"]};
	Relations.Add(new DataRelation("FK_perfvalutazioneateneovalidatore_perfmission_idperfmission",cPar,cChild,false));

	#endregion

}
}
}
