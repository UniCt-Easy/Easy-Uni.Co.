
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
[System.Xml.Serialization.XmlRoot("dsmeta_attivform_gruppo"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_attivform_gruppo: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzannodefaultview 		=> (MetaTable)Tables["didprogporzannodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogannodefaultview 		=> (MetaTable)Tables["didprogannodefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogoridefaultview 		=> (MetaTable)Tables["didprogoridefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogcurr 		=> (MetaTable)Tables["didprogcurr"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegnintegdefaultview 		=> (MetaTable)Tables["insegnintegdefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable insegndefaultview 		=> (MetaTable)Tables["insegndefaultview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable attivform 		=> (MetaTable)Tables["attivform"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_attivform_gruppo(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_attivform_gruppo (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_attivform_gruppo";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_attivform_gruppo.xsd";

	#region create DataTables
	//////////////////// DIDPROGPORZANNODEFAULTVIEW /////////////////////////////////
	var tdidprogporzannodefaultview= new MetaTable("didprogporzannodefaultview");
	tdidprogporzannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogporzannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzannodefaultview.defineColumn("iddidprogporzanno", typeof(int),false);
	Tables.Add(tdidprogporzannodefaultview);
	tdidprogporzannodefaultview.defineKey("iddidprogporzanno");

	//////////////////// DIDPROGANNODEFAULTVIEW /////////////////////////////////
	var tdidprogannodefaultview= new MetaTable("didprogannodefaultview");
	tdidprogannodefaultview.defineColumn("aa", typeof(string),false);
	tdidprogannodefaultview.defineColumn("dropdown_title", typeof(string),false);
	tdidprogannodefaultview.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprog", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidproganno", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogannodefaultview.defineColumn("iddidprogori", typeof(int),false);
	Tables.Add(tdidprogannodefaultview);
	tdidprogannodefaultview.defineKey("iddidproganno");

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
	tdidprogcurr.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprog", typeof(int),false);
	tdidprogcurr.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogcurr.defineColumn("title", typeof(string));
	Tables.Add(tdidprogcurr);
	tdidprogcurr.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr");

	//////////////////// INSEGNINTEGDEFAULTVIEW /////////////////////////////////
	var tinsegnintegdefaultview= new MetaTable("insegnintegdefaultview");
	tinsegnintegdefaultview.defineColumn("denominazione", typeof(string));
	tinsegnintegdefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegnintegdefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegnintegdefaultview.defineColumn("idinsegninteg", typeof(int),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_codice", typeof(string));
	tinsegnintegdefaultview.defineColumn("insegninteg_ct", typeof(DateTime),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_cu", typeof(string),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_denominazione_en", typeof(string));
	tinsegnintegdefaultview.defineColumn("insegninteg_lt", typeof(DateTime),false);
	tinsegnintegdefaultview.defineColumn("insegninteg_lu", typeof(string),false);
	Tables.Add(tinsegnintegdefaultview);
	tinsegnintegdefaultview.defineKey("idinsegninteg");

	//////////////////// INSEGNDEFAULTVIEW /////////////////////////////////
	var tinsegndefaultview= new MetaTable("insegndefaultview");
	tinsegndefaultview.defineColumn("dropdown_title", typeof(string),false);
	tinsegndefaultview.defineColumn("idcorsostudio", typeof(int));
	tinsegndefaultview.defineColumn("idinsegn", typeof(int),false);
	tinsegndefaultview.defineColumn("idstruttura", typeof(int));
	Tables.Add(tinsegndefaultview);
	tinsegndefaultview.defineKey("idinsegn");

	//////////////////// ATTIVFORM /////////////////////////////////
	var tattivform= new MetaTable("attivform");
	tattivform.defineColumn("aa", typeof(string),false);
	tattivform.defineColumn("ct", typeof(DateTime),false);
	tattivform.defineColumn("cu", typeof(string),false);
	tattivform.defineColumn("idattivform", typeof(int),false);
	tattivform.defineColumn("idcorsostudio", typeof(int),false);
	tattivform.defineColumn("iddidprog", typeof(int),false);
	tattivform.defineColumn("iddidproganno", typeof(int),false);
	tattivform.defineColumn("iddidprogcurr", typeof(int),false);
	tattivform.defineColumn("iddidproggrupp", typeof(int));
	tattivform.defineColumn("iddidprogori", typeof(int),false);
	tattivform.defineColumn("iddidprogporzanno", typeof(int),false);
	tattivform.defineColumn("idinsegn", typeof(int),false);
	tattivform.defineColumn("idinsegninteg", typeof(int));
	tattivform.defineColumn("idsede", typeof(int),false);
	tattivform.defineColumn("lt", typeof(DateTime),false);
	tattivform.defineColumn("lu", typeof(string),false);
	tattivform.defineColumn("obbform", typeof(string));
	tattivform.defineColumn("obbform_en", typeof(string));
	tattivform.defineColumn("sortcode", typeof(int));
	tattivform.defineColumn("start", typeof(DateTime));
	tattivform.defineColumn("stop", typeof(DateTime));
	tattivform.defineColumn("tipovalutaz", typeof(string));
	tattivform.defineColumn("title", typeof(string));
	Tables.Add(tattivform);
	tattivform.defineKey("aa", "idattivform", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprogporzannodefaultview.Columns["iddidprogporzanno"]};
	var cChild = new []{attivform.Columns["iddidprogporzanno"]};
	Relations.Add(new DataRelation("FK_attivform_didprogporzannodefaultview_iddidprogporzanno",cPar,cChild,false));

	cPar = new []{didprogannodefaultview.Columns["iddidproganno"]};
	cChild = new []{didprogporzannodefaultview.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_didprogporzannodefaultview_didprogannodefaultview_iddidproganno",cPar,cChild,false));

	cPar = new []{didprogannodefaultview.Columns["iddidproganno"]};
	cChild = new []{attivform.Columns["iddidproganno"]};
	Relations.Add(new DataRelation("FK_attivform_didprogannodefaultview_iddidproganno",cPar,cChild,false));

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{didprogannodefaultview.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_didprogannodefaultview_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogoridefaultview.Columns["iddidprogori"]};
	cChild = new []{attivform.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_attivform_didprogoridefaultview_iddidprogori",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{didprogoridefaultview.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_didprogoridefaultview_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{didprogcurr.Columns["iddidprogcurr"]};
	cChild = new []{attivform.Columns["iddidprogcurr"]};
	Relations.Add(new DataRelation("FK_attivform_didprogcurr_iddidprogcurr",cPar,cChild,false));

	cPar = new []{insegnintegdefaultview.Columns["idinsegninteg"]};
	cChild = new []{attivform.Columns["idinsegninteg"]};
	Relations.Add(new DataRelation("FK_attivform_insegnintegdefaultview_idinsegninteg",cPar,cChild,false));

	cPar = new []{insegndefaultview.Columns["idinsegn"]};
	cChild = new []{attivform.Columns["idinsegn"]};
	Relations.Add(new DataRelation("FK_attivform_insegndefaultview_idinsegn",cPar,cChild,false));

	#endregion

}
}
}
