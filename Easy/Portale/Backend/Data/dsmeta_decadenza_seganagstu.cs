
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
[System.Xml.Serialization.XmlRoot("dsmeta_decadenza_seganagstu"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_decadenza_seganagstu: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable decadenza 		=> (MetaTable)Tables["decadenza"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_decadenza_seganagstu(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_decadenza_seganagstu (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_decadenza_seganagstu";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_decadenza_seganagstu.xsd";

	#region create DataTables
	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DECADENZA /////////////////////////////////
	var tdecadenza= new MetaTable("decadenza");
	tdecadenza.defineColumn("aa", typeof(string),false);
	tdecadenza.defineColumn("ct", typeof(DateTime),false);
	tdecadenza.defineColumn("cu", typeof(string),false);
	tdecadenza.defineColumn("data", typeof(DateTime),false);
	tdecadenza.defineColumn("iddecadenza", typeof(int),false);
	tdecadenza.defineColumn("idiscrizione", typeof(int),false);
	tdecadenza.defineColumn("idreg_studenti", typeof(int),false);
	tdecadenza.defineColumn("lt", typeof(DateTime),false);
	tdecadenza.defineColumn("lu", typeof(string),false);
	tdecadenza.defineColumn("protanno", typeof(int),false);
	tdecadenza.defineColumn("protnumero", typeof(int),false);
	Tables.Add(tdecadenza);
	tdecadenza.defineKey("iddecadenza", "idiscrizione", "idreg_studenti");

	#endregion


	#region DataRelation creation
	var cPar = new []{annoaccademico.Columns["aa"]};
	var cChild = new []{decadenza.Columns["aa"]};
	Relations.Add(new DataRelation("FK_decadenza_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
