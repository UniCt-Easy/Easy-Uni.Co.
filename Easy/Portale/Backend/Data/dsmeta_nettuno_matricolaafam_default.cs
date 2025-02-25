
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
[System.Xml.Serialization.XmlRoot("dsmeta_nettuno_matricolaafam_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_nettuno_matricolaafam_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nettuno_matricolaafam 		=> (MetaTable)Tables["nettuno_matricolaafam"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_nettuno_matricolaafam_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_nettuno_matricolaafam_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_nettuno_matricolaafam_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_nettuno_matricolaafam_default.xsd";

	#region create DataTables
	//////////////////// NETTUNO_MATRICOLAAFAM /////////////////////////////////
	var tnettuno_matricolaafam= new MetaTable("nettuno_matricolaafam");
	tnettuno_matricolaafam.defineColumn("aannoaccademico", typeof(string));
	tnettuno_matricolaafam.defineColumn("annoaccademico", typeof(string));
	tnettuno_matricolaafam.defineColumn("annocorso", typeof(int));
	tnettuno_matricolaafam.defineColumn("codfisc", typeof(string));
	tnettuno_matricolaafam.defineColumn("cognome", typeof(string));
	tnettuno_matricolaafam.defineColumn("daannoaccademico", typeof(string));
	tnettuno_matricolaafam.defineColumn("dataimmatricolazione", typeof(string));
	tnettuno_matricolaafam.defineColumn("datastato", typeof(string));
	tnettuno_matricolaafam.defineColumn("desccorso", typeof(string));
	tnettuno_matricolaafam.defineColumn("desclivello", typeof(string));
	tnettuno_matricolaafam.defineColumn("descstatomatricola", typeof(string));
	tnettuno_matricolaafam.defineColumn("email", typeof(string));
	tnettuno_matricolaafam.defineColumn("emailistituzionale", typeof(string));
	tnettuno_matricolaafam.defineColumn("flagfuoricorso", typeof(int));
	tnettuno_matricolaafam.defineColumn("flagparttime", typeof(int));
	tnettuno_matricolaafam.defineColumn("flagripetente", typeof(int));
	tnettuno_matricolaafam.defineColumn("idcorso", typeof(int));
	tnettuno_matricolaafam.defineColumn("idlivello", typeof(string));
	tnettuno_matricolaafam.defineColumn("idsc", typeof(int));
	tnettuno_matricolaafam.defineColumn("idu", typeof(string));
	tnettuno_matricolaafam.defineColumn("iseedichiarato", typeof(string));
	tnettuno_matricolaafam.defineColumn("matricola", typeof(string));
	tnettuno_matricolaafam.defineColumn("nome", typeof(string));
	tnettuno_matricolaafam.defineColumn("statomatricola", typeof(int));
	tnettuno_matricolaafam.defineColumn("tipomatricola", typeof(string));
	Tables.Add(tnettuno_matricolaafam);
	//tnettuno_matricolaafam.defineKey("annoaccademico", "idcorso", "idsc", "idu", "annocorso");

	#endregion

}
}
}
