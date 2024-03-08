
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
[System.Xml.Serialization.XmlRoot("dsmeta_tirociniorelazione_seg"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_tirociniorelazione_seg: DataSet {

	#region Table members declaration
	///<summary>
	///2.5.25 Relazione Conclusiva di tirocinio 
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable tirociniorelazione 		=> (MetaTable)Tables["tirociniorelazione"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_tirociniorelazione_seg(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_tirociniorelazione_seg (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_tirociniorelazione_seg";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_tirociniorelazione_seg.xsd";

	#region create DataTables
	//////////////////// TIROCINIORELAZIONE /////////////////////////////////
	var ttirociniorelazione= new MetaTable("tirociniorelazione");
	ttirociniorelazione.defineColumn("attivitasvolta", typeof(string));
	ttirociniorelazione.defineColumn("autovalutazione", typeof(string));
	ttirociniorelazione.defineColumn("competenze", typeof(string));
	ttirociniorelazione.defineColumn("conclusioni", typeof(string));
	ttirociniorelazione.defineColumn("considerazioni", typeof(string));
	ttirociniorelazione.defineColumn("ct", typeof(DateTime));
	ttirociniorelazione.defineColumn("cu", typeof(string));
	ttirociniorelazione.defineColumn("descrazienda", typeof(string));
	ttirociniorelazione.defineColumn("idreg_referente", typeof(int),false);
	ttirociniorelazione.defineColumn("idreg_studenti", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirociniocandidatura", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirocinioprogetto", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirocinioproposto", typeof(int),false);
	ttirociniorelazione.defineColumn("idtirociniorelazione", typeof(int),false);
	ttirociniorelazione.defineColumn("introduzione", typeof(string));
	ttirociniorelazione.defineColumn("lt", typeof(DateTime));
	ttirociniorelazione.defineColumn("lu", typeof(string));
	Tables.Add(ttirociniorelazione);
	ttirociniorelazione.defineKey("idreg_referente", "idreg_studenti", "idtirociniocandidatura", "idtirocinioprogetto", "idtirocinioproposto", "idtirociniorelazione");

	#endregion

}
}
}
