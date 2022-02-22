
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
[System.Xml.Serialization.XmlRoot("dsmeta_afferenza_amm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_afferenza_amm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturaperfelenchiview 		=> (MetaTable)Tables["strutturaperfelenchiview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenza 		=> (MetaTable)Tables["afferenza"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_afferenza_amm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_afferenza_amm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_afferenza_amm";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_afferenza_amm.xsd";

	#region create DataTables
	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// STRUTTURAPERFELENCHIVIEW /////////////////////////////////
	var tstrutturaperfelenchiview= new MetaTable("strutturaperfelenchiview");
	tstrutturaperfelenchiview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturaperfelenchiview.defineColumn("idstruttura", typeof(int),false);
	tstrutturaperfelenchiview.defineColumn("idupb", typeof(string));
	tstrutturaperfelenchiview.defineColumn("paridstruttura", typeof(int));
	Tables.Add(tstrutturaperfelenchiview);
	tstrutturaperfelenchiview.defineKey("idstruttura");

	//////////////////// AFFERENZA /////////////////////////////////
	var tafferenza= new MetaTable("afferenza");
	tafferenza.defineColumn("ct", typeof(DateTime),false);
	tafferenza.defineColumn("cu", typeof(string),false);
	tafferenza.defineColumn("idafferenza", typeof(int),false);
	tafferenza.defineColumn("idmansionekind", typeof(int));
	tafferenza.defineColumn("idreg", typeof(int),false);
	tafferenza.defineColumn("idstruttura", typeof(int));
	tafferenza.defineColumn("lt", typeof(DateTime),false);
	tafferenza.defineColumn("lu", typeof(string),false);
	tafferenza.defineColumn("start", typeof(DateTime));
	tafferenza.defineColumn("stop", typeof(DateTime));
	Tables.Add(tafferenza);
	tafferenza.defineKey("idafferenza", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{mansionekind.Columns["idmansionekind"]};
	var cChild = new []{afferenza.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_afferenza_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{strutturaperfelenchiview.Columns["idstruttura"]};
	cChild = new []{afferenza.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_afferenza_strutturaperfelenchiview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
