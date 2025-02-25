
/*
Easy
Copyright (C) 2025 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_nettuno_offertaformativaafam_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_nettuno_offertaformativaafam_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nettuno_offertaformativaafam 		=> (MetaTable)Tables["nettuno_offertaformativaafam"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_nettuno_offertaformativaafam_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_nettuno_offertaformativaafam_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_nettuno_offertaformativaafam_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_nettuno_offertaformativaafam_default.xsd";

	#region create DataTables
	//////////////////// NETTUNO_OFFERTAFORMATIVAAFAM /////////////////////////////////
	var tnettuno_offertaformativaafam= new MetaTable("nettuno_offertaformativaafam");
	tnettuno_offertaformativaafam.defineColumn("annosc", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("crediti", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("daanno", typeof(int),false);
	tnettuno_offertaformativaafam.defineColumn("desccorso", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("desclivello", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("descmateria", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("finoanno", typeof(int),false);
	tnettuno_offertaformativaafam.defineColumn("idcorso", typeof(int),false);
	tnettuno_offertaformativaafam.defineColumn("idlivello", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("idmateria", typeof(int),false);
	tnettuno_offertaformativaafam.defineColumn("idsc", typeof(int),false);
	tnettuno_offertaformativaafam.defineColumn("ore", typeof(int),false);
	tnettuno_offertaformativaafam.defineColumn("tipoesame", typeof(string));
	tnettuno_offertaformativaafam.defineColumn("tipologia", typeof(string));
	Tables.Add(tnettuno_offertaformativaafam);
	tnettuno_offertaformativaafam.defineKey("idcorso", "idmateria", "idsc");

	#endregion

}
}
}
