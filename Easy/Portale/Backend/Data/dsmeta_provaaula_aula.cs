
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
[System.Xml.Serialization.XmlRoot("dsmeta_provaaula_aula"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class dsmeta_provaaula_aula: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provaaulaview 		=> (MetaTable)Tables["provaaulaview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public MetaTable provaaula 		=> (MetaTable)Tables["provaaula"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public dsmeta_provaaula_aula(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected dsmeta_provaaula_aula (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "dsmeta_provaaula_aula";
	Prefix = "";
	Namespace = "http://tempuri.org/dsmeta_provaaula_aula.xsd";

	#region create DataTables
	//////////////////// PROVAAULAVIEW /////////////////////////////////
	var tprovaaulaview= new MetaTable("provaaulaview");
	tprovaaulaview.defineColumn("annoaccademico_aa", typeof(string));
	tprovaaulaview.defineColumn("attivform_title", typeof(string));
	tprovaaulaview.defineColumn("corsostudio_annoistituz", typeof(int));
	tprovaaulaview.defineColumn("corsostudio_title", typeof(string));
	tprovaaulaview.defineColumn("didprog_title", typeof(string));
	tprovaaulaview.defineColumn("dropdown_title", typeof(string),false);
	tprovaaulaview.defineColumn("idattivform", typeof(int));
	tprovaaulaview.defineColumn("idcorsostudio", typeof(int));
	tprovaaulaview.defineColumn("iddidprog", typeof(int));
	tprovaaulaview.defineColumn("idprova", typeof(int),false);
	tprovaaulaview.defineColumn("idquestionario", typeof(int));
	tprovaaulaview.defineColumn("prova_ct", typeof(DateTime),false);
	tprovaaulaview.defineColumn("prova_cu", typeof(string),false);
	tprovaaulaview.defineColumn("prova_idappello", typeof(int));
	tprovaaulaview.defineColumn("prova_idvalutazionekind", typeof(int));
	tprovaaulaview.defineColumn("prova_lt", typeof(DateTime),false);
	tprovaaulaview.defineColumn("prova_lu", typeof(string),false);
	tprovaaulaview.defineColumn("prova_programma", typeof(string));
	tprovaaulaview.defineColumn("prova_start", typeof(DateTime));
	tprovaaulaview.defineColumn("prova_stop", typeof(DateTime));
	tprovaaulaview.defineColumn("questionario_title", typeof(string));
	tprovaaulaview.defineColumn("sede_title", typeof(string));
	tprovaaulaview.defineColumn("title", typeof(string));
	tprovaaulaview.defineColumn("valutazionekind_title", typeof(string));
	Tables.Add(tprovaaulaview);
	tprovaaulaview.defineKey("idprova");

	//////////////////// PROVAAULA /////////////////////////////////
	var tprovaaula= new MetaTable("provaaula");
	tprovaaula.defineColumn("ct", typeof(DateTime),false);
	tprovaaula.defineColumn("cu", typeof(string),false);
	tprovaaula.defineColumn("idappello", typeof(int));
	tprovaaula.defineColumn("idaula", typeof(int),false);
	tprovaaula.defineColumn("idcorsostudio", typeof(int));
	tprovaaula.defineColumn("iddidprog", typeof(int));
	tprovaaula.defineColumn("idedificio", typeof(int),false);
	tprovaaula.defineColumn("idprova", typeof(int),false);
	tprovaaula.defineColumn("idsede", typeof(int),false);
	tprovaaula.defineColumn("lt", typeof(DateTime),false);
	tprovaaula.defineColumn("lu", typeof(string),false);
	Tables.Add(tprovaaula);
	tprovaaula.defineKey("idaula", "idedificio", "idprova", "idsede");

	#endregion


	#region DataRelation creation
	var cPar = new []{provaaulaview.Columns["idprova"]};
	var cChild = new []{provaaula.Columns["idprova"]};
	Relations.Add(new DataRelation("FK_provaaula_provaaulaview_idprova",cPar,cChild,false));

	#endregion

}
}
}
