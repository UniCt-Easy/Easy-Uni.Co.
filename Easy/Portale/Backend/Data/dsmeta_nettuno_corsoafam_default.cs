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
[System.Xml.Serialization.XmlRoot("dsmeta_nettuno_corsoafam_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_nettuno_corsoafam_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nettuno_corsoafam 		=> (MetaTable)Tables["nettuno_corsoafam"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_nettuno_corsoafam_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_nettuno_corsoafam_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_nettuno_corsoafam_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_nettuno_corsoafam_default.xsd";

	#region create DataTables
	//////////////////// NETTUNO_CORSOAFAM /////////////////////////////////
	var tnettuno_corsoafam= new MetaTable("nettuno_corsoafam");
	tnettuno_corsoafam.defineColumn("codicecorso", typeof(string));
	tnettuno_corsoafam.defineColumn("desccorso", typeof(string));
	tnettuno_corsoafam.defineColumn("desclivello", typeof(string));
	tnettuno_corsoafam.defineColumn("flagammissione", typeof(int),false);
	tnettuno_corsoafam.defineColumn("flagiscrizione", typeof(int),false);
	tnettuno_corsoafam.defineColumn("idcorso", typeof(int),false);
	tnettuno_corsoafam.defineColumn("idlivello", typeof(string));
	tnettuno_corsoafam.defineColumn("idsc", typeof(int),false);
	tnettuno_corsoafam.defineColumn("programmaesameammissione", typeof(string));
	tnettuno_corsoafam.defineColumn("programmaesameammissioneeng", typeof(string));
	tnettuno_corsoafam.defineColumn("reqsupplement", typeof(string));
	tnettuno_corsoafam.defineColumn("reqsupplementeng", typeof(string));
	tnettuno_corsoafam.defineColumn("ultimoaggiornamento", typeof(string));
	Tables.Add(tnettuno_corsoafam);
	tnettuno_corsoafam.defineKey("idcorso");

	#endregion

}
}
}
