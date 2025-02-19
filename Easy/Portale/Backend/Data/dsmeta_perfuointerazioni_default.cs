
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfuointerazioni_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_perfuointerazioni_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfinterazionekind 		=> (MetaTable)Tables["perfinterazionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfuointerazioni 		=> (MetaTable)Tables["perfuointerazioni"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfuointerazioni_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfuointerazioni_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfuointerazioni_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfuointerazioni_default.xsd";

	#region create DataTables
	//////////////////// PERFINTERAZIONEKIND /////////////////////////////////
	var tperfinterazionekind= new MetaTable("perfinterazionekind");
	tperfinterazionekind.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfinterazionekind.defineColumn("title", typeof(string));
	Tables.Add(tperfinterazionekind);
	tperfinterazionekind.defineKey("idperfinterazionekind");

	//////////////////// PERFUOINTERAZIONI /////////////////////////////////
	var tperfuointerazioni= new MetaTable("perfuointerazioni");
	tperfuointerazioni.defineColumn("commenti", typeof(string));
	tperfuointerazioni.defineColumn("commentival", typeof(string));
	tperfuointerazioni.defineColumn("ct", typeof(DateTime),false);
	tperfuointerazioni.defineColumn("cu", typeof(string),false);
	tperfuointerazioni.defineColumn("data", typeof(DateTime));
	tperfuointerazioni.defineColumn("idperfinterazionekind", typeof(int),false);
	tperfuointerazioni.defineColumn("idperfuointerazioni", typeof(int),false);
	tperfuointerazioni.defineColumn("idperfvalutazioneuo", typeof(int),false);
	tperfuointerazioni.defineColumn("lt", typeof(DateTime),false);
	tperfuointerazioni.defineColumn("lu", typeof(string),false);
	tperfuointerazioni.defineColumn("utente", typeof(string));
	Tables.Add(tperfuointerazioni);
	tperfuointerazioni.defineKey("idperfuointerazioni", "idperfvalutazioneuo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfinterazionekind.Columns["idperfinterazionekind"]};
	var cChild = new []{perfuointerazioni.Columns["idperfinterazionekind"]};
	Relations.Add(new DataRelation("FK_perfuointerazioni_perfinterazionekind_idperfinterazionekind",cPar,cChild,false));

	#endregion

}
}
}
