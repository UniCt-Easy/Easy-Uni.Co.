
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
[System.Xml.Serialization.XmlRoot("dsmeta_afferenza_docente"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_afferenza_docente: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekinddefaultview 		=> (MetaTable)Tables["mansionekinddefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable strutturadefaultview 		=> (MetaTable)Tables["strutturadefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenza 		=> (MetaTable)Tables["afferenza"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_afferenza_docente(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_afferenza_docente (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_afferenza_docente";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_afferenza_docente.xsd";

	#region create DataTables
	//////////////////// MANSIONEKINDDEFAULTVIEW /////////////////////////////////
	var tmansionekinddefaultview= new MetaTable("mansionekinddefaultview");
	tmansionekinddefaultview.defineColumn("dropdown_title", typeof(string),false);
	tmansionekinddefaultview.defineColumn("idmansionekind", typeof(int),false);
	Tables.Add(tmansionekinddefaultview);
	tmansionekinddefaultview.defineKey("idmansionekind");

	//////////////////// STRUTTURADEFAULTVIEW /////////////////////////////////
	var tstrutturadefaultview= new MetaTable("strutturadefaultview");
	tstrutturadefaultview.defineColumn("dropdown_title", typeof(string),false);
	tstrutturadefaultview.defineColumn("idstruttura", typeof(int),false);
	tstrutturadefaultview.defineColumn("struttura_active", typeof(string));
	Tables.Add(tstrutturadefaultview);
	tstrutturadefaultview.defineKey("idstruttura");

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
	var cPar = new []{mansionekinddefaultview.Columns["idmansionekind"]};
	var cChild = new []{afferenza.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_afferenza_mansionekinddefaultview_idmansionekind",cPar,cChild,false));

	cPar = new []{strutturadefaultview.Columns["idstruttura"]};
	cChild = new []{afferenza.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_afferenza_strutturadefaultview_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
