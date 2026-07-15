/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_nettuno_percorsoafam_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_nettuno_percorsoafam_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nettuno_percorsoafam 		=> (MetaTable)Tables["nettuno_percorsoafam"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_nettuno_percorsoafam_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_nettuno_percorsoafam_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_nettuno_percorsoafam_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_nettuno_percorsoafam_default.xsd";

	#region create DataTables
	//////////////////// NETTUNO_PERCORSOAFAM /////////////////////////////////
	var tnettuno_percorsoafam= new MetaTable("nettuno_percorsoafam");
	tnettuno_percorsoafam.defineColumn("annoaccademico", typeof(string));
	tnettuno_percorsoafam.defineColumn("annocorso", typeof(int));
	tnettuno_percorsoafam.defineColumn("codfisc", typeof(string));
	tnettuno_percorsoafam.defineColumn("cognome", typeof(string));
	tnettuno_percorsoafam.defineColumn("creditiottenuti", typeof(string));
	tnettuno_percorsoafam.defineColumn("creditiparziali", typeof(string));
	tnettuno_percorsoafam.defineColumn("dataesame", typeof(string));
	tnettuno_percorsoafam.defineColumn("dataultimoesame", typeof(string));
	tnettuno_percorsoafam.defineColumn("desccorso", typeof(string));
	tnettuno_percorsoafam.defineColumn("desclivello", typeof(string));
	tnettuno_percorsoafam.defineColumn("descmateria", typeof(string));
	tnettuno_percorsoafam.defineColumn("descrissultato", typeof(string));
	tnettuno_percorsoafam.defineColumn("desctipoesame", typeof(string));
	tnettuno_percorsoafam.defineColumn("idcorso", typeof(int));
	tnettuno_percorsoafam.defineColumn("idlivello", typeof(string));
	tnettuno_percorsoafam.defineColumn("idmateria", typeof(int));

	tnettuno_percorsoafam.defineColumn("idrisultato", typeof(int));
	tnettuno_percorsoafam.defineColumn("idsc", typeof(int));
	tnettuno_percorsoafam.defineColumn("idu", typeof(string));
	tnettuno_percorsoafam.defineColumn("nome", typeof(string));
	tnettuno_percorsoafam.defineColumn("sessione", typeof(string));
	tnettuno_percorsoafam.defineColumn("tipoesame", typeof(string));
	tnettuno_percorsoafam.defineColumn("tipomatricola", typeof(string));
	tnettuno_percorsoafam.defineColumn("voto", typeof(string));
	Tables.Add(tnettuno_percorsoafam);
	//tnettuno_percorsoafam.defineKey("idcorso", "idmateria", "idrisultato", "idsc", "idu", "tipoesame", "dataesame", "annocorso");

	#endregion

}
}
}
