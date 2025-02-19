
/*
Easy
Copyright (C) 2024 UniversitÓ degli Studi di Catania (www.unict.it)
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
[System.Xml.Serialization.XmlRoot("dsmeta_didprogori_default"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_didprogori_default: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogporzanno 		=> (MetaTable)Tables["didprogporzanno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable annoaccademico 		=> (MetaTable)Tables["annoaccademico"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didproganno 		=> (MetaTable)Tables["didproganno"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable didprogori 		=> (MetaTable)Tables["didprogori"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_didprogori_default(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_didprogori_default (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_didprogori_default";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_didprogori_default.xsd";

	#region create DataTables
	//////////////////// DIDPROGPORZANNO /////////////////////////////////
	var tdidprogporzanno= new MetaTable("didprogporzanno");
	tdidprogporzanno.defineColumn("aa", typeof(string),false);
	tdidprogporzanno.defineColumn("ct", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("cu", typeof(string),false);
	tdidprogporzanno.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprog", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidproganno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogori", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzanno", typeof(int),false);
	tdidprogporzanno.defineColumn("iddidprogporzannokind", typeof(int));
	tdidprogporzanno.defineColumn("indice", typeof(int));
	tdidprogporzanno.defineColumn("lt", typeof(DateTime),false);
	tdidprogporzanno.defineColumn("lu", typeof(string),false);
	tdidprogporzanno.defineColumn("start", typeof(DateTime));
	tdidprogporzanno.defineColumn("stop", typeof(DateTime));
	tdidprogporzanno.defineColumn("title", typeof(string));
	Tables.Add(tdidprogporzanno);
	tdidprogporzanno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori", "iddidprogporzanno");

	//////////////////// ANNOACCADEMICO /////////////////////////////////
	var tannoaccademico= new MetaTable("annoaccademico");
	tannoaccademico.defineColumn("aa", typeof(string),false);
	Tables.Add(tannoaccademico);
	tannoaccademico.defineKey("aa");

	//////////////////// DIDPROGANNO /////////////////////////////////
	var tdidproganno= new MetaTable("didproganno");
	tdidproganno.defineColumn("aa", typeof(string),false);
	tdidproganno.defineColumn("anno", typeof(int));
	tdidproganno.defineColumn("cf", typeof(decimal));
	tdidproganno.defineColumn("ct", typeof(DateTime),false);
	tdidproganno.defineColumn("cu", typeof(string),false);
	tdidproganno.defineColumn("idcorsostudio", typeof(int),false);
	tdidproganno.defineColumn("iddidprog", typeof(int),false);
	tdidproganno.defineColumn("iddidproganno", typeof(int),false);
	tdidproganno.defineColumn("iddidprogcurr", typeof(int),false);
	tdidproganno.defineColumn("iddidprogori", typeof(int),false);
	tdidproganno.defineColumn("lt", typeof(DateTime),false);
	tdidproganno.defineColumn("lu", typeof(string),false);
	tdidproganno.defineColumn("title", typeof(string));
	Tables.Add(tdidproganno);
	tdidproganno.defineKey("aa", "idcorsostudio", "iddidprog", "iddidproganno", "iddidprogcurr", "iddidprogori");

	//////////////////// DIDPROGORI /////////////////////////////////
	var tdidprogori= new MetaTable("didprogori");
	tdidprogori.defineColumn("codice", typeof(string));
	tdidprogori.defineColumn("ct", typeof(DateTime),false);
	tdidprogori.defineColumn("cu", typeof(string),false);
	tdidprogori.defineColumn("idcorsostudio", typeof(int),false);
	tdidprogori.defineColumn("iddidprog", typeof(int),false);
	tdidprogori.defineColumn("iddidprogcurr", typeof(int),false);
	tdidprogori.defineColumn("iddidprogori", typeof(int),false);
	tdidprogori.defineColumn("lt", typeof(DateTime),false);
	tdidprogori.defineColumn("lu", typeof(string),false);
	tdidprogori.defineColumn("title", typeof(string));
	Tables.Add(tdidprogori);
	tdidprogori.defineKey("idcorsostudio", "iddidprog", "iddidprogcurr", "iddidprogori");

	#endregion


	#region DataRelation creation
	var cPar = new []{didprogori.Columns["idcorsostudio"], didprogori.Columns["iddidprog"], didprogori.Columns["iddidprogcurr"], didprogori.Columns["iddidprogori"]};
	var cChild = new []{didproganno.Columns["idcorsostudio"], didproganno.Columns["iddidprog"], didproganno.Columns["iddidprogcurr"], didproganno.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_didproganno_didprogori_idcorsostudio-iddidprog-iddidprogcurr-iddidprogori",cPar,cChild,false));

	cPar = new []{didproganno.Columns["aa"], didproganno.Columns["idcorsostudio"], didproganno.Columns["iddidprog"], didproganno.Columns["iddidproganno"], didproganno.Columns["iddidprogcurr"], didproganno.Columns["iddidprogori"]};
	cChild = new []{didprogporzanno.Columns["aa"], didprogporzanno.Columns["idcorsostudio"], didprogporzanno.Columns["iddidprog"], didprogporzanno.Columns["iddidproganno"], didprogporzanno.Columns["iddidprogcurr"], didprogporzanno.Columns["iddidprogori"]};
	Relations.Add(new DataRelation("FK_didprogporzanno_didproganno_aa-idcorsostudio-iddidprog-iddidproganno-iddidprogcurr-iddidprogori",cPar,cChild,false));

	cPar = new []{annoaccademico.Columns["aa"]};
	cChild = new []{didproganno.Columns["aa"]};
	Relations.Add(new DataRelation("FK_didproganno_annoaccademico_aa",cPar,cChild,false));

	#endregion

}
}
}
