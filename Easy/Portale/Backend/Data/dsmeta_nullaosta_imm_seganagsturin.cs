
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
[System.Xml.Serialization.XmlRoot("dsmeta_nullaosta_imm_seganagsturin"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_nullaosta_imm_seganagsturin: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogoridefaultview 		=> (MetaTable)Tables["didprogoridefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta 		=> (MetaTable)Tables["nullaosta"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable nullaosta_imm_alias3 		=> (MetaTable)Tables["nullaosta_imm_alias3"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_nullaosta_imm_seganagsturin(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_nullaosta_imm_seganagsturin (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_nullaosta_imm_seganagsturin";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_nullaosta_imm_seganagsturin.xsd";

	#region create DataTables
	//////////////////// DIDPROGORIDEFAULTVIEW /////////////////////////////////
	var tdidprogoridefaultview= new MetaTable("didprogoridefaultview");
	tdidprogoridefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogoridefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogoridefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogoridefaultview);
	tdidprogoridefaultview.defineKey("iddidprogori");

	//////////////////// DIDPROGCURR /////////////////////////////////
	var tdidprogcurr= new MetaTable("didprogcurr");
	tdidprogcurr.defineColumn("codice", typeof(string));
	tdidprogcurr.defineColumn("codicemiur", typeof(string));
	tdidprogcurr.defineColumn("ct", typeof(DateTime),false);
	tdidprogcurr.defineColumn("cu", typeof(string),false);
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("lt", typeof(DateTime),false);
	tdidprogcurr.defineColumn("lu", typeof(string),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// NULLAOSTA /////////////////////////////////
	var tnullaosta= new MetaTable("nullaosta");
	tnullaosta.defineColumn("ct", typeof(DateTime),false);
	tnullaosta.defineColumn("cu", typeof(string),false);
	tnullaosta.defineColumn("data", typeof(DateTime),false);
	tnullaosta.defineColumn("extension", typeof(string));
	tnullaosta.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta.defineColumn("iddidprog", typeof(int),false);
	tnullaosta.defineColumn("idiscrizione", typeof(int));
	tnullaosta.defineColumn("idistanza", typeof(int),false);
	tnullaosta.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta.defineColumn("idreg", typeof(int),false);
	tnullaosta.defineColumn("lt", typeof(DateTime),false);
	tnullaosta.defineColumn("lu", typeof(string),false);
	tnullaosta.defineColumn("protanno", typeof(int));
	tnullaosta.defineColumn("protnumero", typeof(int));
	Tables.Add(tnullaosta);
	tnullaosta.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	//////////////////// NULLAOSTA_IMM_ALIAS3 /////////////////////////////////
	var tnullaosta_imm_alias3= new MetaTable("nullaosta_imm_alias3");
	tnullaosta_imm_alias3.defineColumn("annoimm", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("ct", typeof(DateTime),false);
	tnullaosta_imm_alias3.defineColumn("cu", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("idcorsostudio", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprog", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprogcurr", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("iddidprogori", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idistanza", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idistanzakind", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idnullaosta", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("idreg", typeof(int),false);
	tnullaosta_imm_alias3.defineColumn("lt", typeof(DateTime),false);
	tnullaosta_imm_alias3.defineColumn("lu", typeof(string),false);
	tnullaosta_imm_alias3.defineColumn("parttime", typeof(string),false);
	tnullaosta_imm_alias3.ExtendedProperties["TableForReading"]="nullaosta_imm";
	Tables.Add(tnullaosta_imm_alias3);
	tnullaosta_imm_alias3.defineKey("idcorsostudio", "iddidprog", "idistanza", "idistanzakind", "idnullaosta", "idreg");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	var cChild = new []{nullaosta_imm_alias3.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{didprogoridefaultview.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogoridefaultview_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{nullaosta_imm_alias3.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{nullaosta.Columns["idcorsostudio"], nullaosta.Columns["iddidprog"], nullaosta.Columns["idistanza"], nullaosta.Columns["idistanzakind"], nullaosta.Columns["idnullaosta"], nullaosta.Columns["idreg"]};
	cChild = new []{nullaosta_imm_alias3.Columns["idcorsostudio"], nullaosta_imm_alias3.Columns["iddidprog"], nullaosta_imm_alias3.Columns["idistanza"], nullaosta_imm_alias3.Columns["idistanzakind"], nullaosta_imm_alias3.Columns["idnullaosta"], nullaosta_imm_alias3.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_nullaosta_imm_alias3_nullaosta_idcorsostudio-iddidprog-idistanza-idistanzakind-idnullaosta-idreg-",cPar,cChild,false));

	#endregion

}
}
}
