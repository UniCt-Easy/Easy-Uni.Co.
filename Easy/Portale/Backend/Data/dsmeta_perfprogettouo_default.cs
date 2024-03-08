
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
[System.Xml.Serialization.XmlRoot("dsmeta_perfprogettouo_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class dsmeta_perfprogettouo_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable getregistrydocentiamministrativi 		=> (MetaTable)Tables["getregistrydocentiamministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable mansionekind 		=> (MetaTable)Tables["mansionekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable struttura 		=> (MetaTable)Tables["struttura"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable afferenza 		=> (MetaTable)Tables["afferenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouomembro 		=> (MetaTable)Tables["perfprogettouomembro"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable perfprogettouo 		=> (MetaTable)Tables["perfprogettouo"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_perfprogettouo_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_perfprogettouo_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_perfprogettouo_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_perfprogettouo_default.xsd";

	#region create DataTables
	//////////////////// GETREGISTRYDOCENTIAMMINISTRATIVI /////////////////////////////////
	var tgetregistrydocentiamministrativi= new MetaTable("getregistrydocentiamministrativi");
	tgetregistrydocentiamministrativi.defineColumn("areadidattica", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("categoria", typeof(string),false);
	tgetregistrydocentiamministrativi.defineColumn("cf", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("contratto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("extmatricula", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("forename", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("idreg", typeof(int),false);
	tgetregistrydocentiamministrativi.defineColumn("istituto", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("macroareadidattica", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("ssd", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("struttura", typeof(string));
	tgetregistrydocentiamministrativi.defineColumn("surname", typeof(string));
	Tables.Add(tgetregistrydocentiamministrativi);
	tgetregistrydocentiamministrativi.defineKey("idreg");

	//////////////////// MANSIONEKIND /////////////////////////////////
	var tmansionekind= new MetaTable("mansionekind");
	tmansionekind.defineColumn("idmansionekind", typeof(int),false);
	tmansionekind.defineColumn("title", typeof(string),false);
	Tables.Add(tmansionekind);
	tmansionekind.defineKey("idmansionekind");

	//////////////////// STRUTTURA /////////////////////////////////
	var tstruttura= new MetaTable("struttura");
	tstruttura.defineColumn("active", typeof(string));
	tstruttura.defineColumn("idstruttura", typeof(int),false);
	tstruttura.defineColumn("paridstruttura", typeof(int));
	tstruttura.defineColumn("title", typeof(string));
	Tables.Add(tstruttura);
	tstruttura.defineKey("idstruttura");

	//////////////////// AFFERENZA /////////////////////////////////
	var tafferenza= new MetaTable("afferenza");
	tafferenza.defineColumn("idafferenza", typeof(int),false);
	tafferenza.defineColumn("idmansionekind", typeof(int));
	tafferenza.defineColumn("idreg", typeof(int),false);
	tafferenza.defineColumn("idstruttura", typeof(int));
	tafferenza.defineColumn("start", typeof(DateTime));
	tafferenza.defineColumn("stop", typeof(DateTime));
	Tables.Add(tafferenza);
	tafferenza.defineKey("idafferenza", "idreg");

	//////////////////// PERFPROGETTOUOMEMBRO /////////////////////////////////
	var tperfprogettouomembro= new MetaTable("perfprogettouomembro");
	tperfprogettouomembro.defineColumn("agile", typeof(string),false);
	tperfprogettouomembro.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("cu", typeof(string),false);
	tperfprogettouomembro.defineColumn("idafferenza", typeof(int));
	tperfprogettouomembro.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouomembro.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouomembro.defineColumn("idreg", typeof(int),false);
	tperfprogettouomembro.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouomembro.defineColumn("lu", typeof(string),false);
	tperfprogettouomembro.defineColumn("!idafferenza_afferenza_start", typeof(DateTime));
	tperfprogettouomembro.defineColumn("!idafferenza_afferenza_stop", typeof(DateTime));
	tperfprogettouomembro.defineColumn("!idafferenza_afferenza_idstruttura_title", typeof(string));
	tperfprogettouomembro.defineColumn("!idafferenza_afferenza_idstruttura_paridstruttura", typeof(int));
	tperfprogettouomembro.defineColumn("!idafferenza_afferenza_idmansionekind_title", typeof(string));
	tperfprogettouomembro.defineColumn("!idreg_getregistrydocentiamministrativi_surname", typeof(string));
	tperfprogettouomembro.defineColumn("!idreg_getregistrydocentiamministrativi_forename", typeof(string));
	Tables.Add(tperfprogettouomembro);
	tperfprogettouomembro.defineKey("idperfprogetto", "idperfprogettouo", "idreg");

	//////////////////// PERFPROGETTOUO /////////////////////////////////
	var tperfprogettouo= new MetaTable("perfprogettouo");
	tperfprogettouo.defineColumn("!struttura", typeof(string));
	tperfprogettouo.defineColumn("ct", typeof(DateTime),false);
	tperfprogettouo.defineColumn("cu", typeof(string),false);
	tperfprogettouo.defineColumn("description", typeof(string));
	tperfprogettouo.defineColumn("idperfprogetto", typeof(int),false);
	tperfprogettouo.defineColumn("idperfprogettouo", typeof(int),false);
	tperfprogettouo.defineColumn("lt", typeof(DateTime),false);
	tperfprogettouo.defineColumn("lu", typeof(string),false);
	tperfprogettouo.defineColumn("title", typeof(string));
	Tables.Add(tperfprogettouo);
	tperfprogettouo.defineKey("idperfprogetto", "idperfprogettouo");

	#endregion


	#region DataRelation creation
	var cPar = new []{perfprogettouo.Columns["idperfprogetto"], perfprogettouo.Columns["idperfprogettouo"]};
	var cChild = new []{perfprogettouomembro.Columns["idperfprogetto"], perfprogettouomembro.Columns["idperfprogettouo"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_perfprogettouo_idperfprogetto-idperfprogettouo",cPar,cChild,false));

	cPar = new []{getregistrydocentiamministrativi.Columns["idreg"]};
	cChild = new []{perfprogettouomembro.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_getregistrydocentiamministrativi_idreg",cPar,cChild,false));

	cPar = new []{afferenza.Columns["idafferenza"]};
	cChild = new []{perfprogettouomembro.Columns["idafferenza"]};
	Relations.Add(new DataRelation("FK_perfprogettouomembro_afferenza_idafferenza",cPar,cChild,false));

	cPar = new []{mansionekind.Columns["idmansionekind"]};
	cChild = new []{afferenza.Columns["idmansionekind"]};
	Relations.Add(new DataRelation("FK_afferenza_mansionekind_idmansionekind",cPar,cChild,false));

	cPar = new []{struttura.Columns["idstruttura"]};
	cChild = new []{afferenza.Columns["idstruttura"]};
	Relations.Add(new DataRelation("FK_afferenza_struttura_idstruttura",cPar,cChild,false));

	#endregion

}
}
}
