
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
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace customgroupoperation_print {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Gestione Sicurezza Tabelle per i gruppi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customgroupoperation 		=> Tables["customgroupoperation"];

	///<summary>
	///Gruppi di utenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customgroup 		=> Tables["customgroup"];

	///<summary>
	///Configurazione delle stampe
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable report 		=> Tables["report"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// CUSTOMGROUPOPERATION /////////////////////////////////
	var tcustomgroupoperation= new DataTable("customgroupoperation");
	C= new DataColumn("idgroup", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation.Columns.Add(C);
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation.Columns.Add(C);
	C= new DataColumn("operation", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation.Columns.Add(C);
	C= new DataColumn("defaultisdeny", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation.Columns.Add(C);
	tcustomgroupoperation.Columns.Add( new DataColumn("allowcondition", typeof(string)));
	tcustomgroupoperation.Columns.Add( new DataColumn("denycondition", typeof(string)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomgroupoperation.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcustomgroupoperation.Columns.Add( new DataColumn("cu", typeof(string)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tcustomgroupoperation);
	tcustomgroupoperation.PrimaryKey =  new DataColumn[]{tcustomgroupoperation.Columns["idgroup"], tcustomgroupoperation.Columns["tablename"], tcustomgroupoperation.Columns["operation"]};


	//////////////////// CUSTOMGROUP /////////////////////////////////
	var tcustomgroup= new DataTable("customgroup");
	C= new DataColumn("idcustomgroup", typeof(string));
	C.AllowDBNull=false;
	tcustomgroup.Columns.Add(C);
	tcustomgroup.Columns.Add( new DataColumn("groupname", typeof(string)));
	tcustomgroup.Columns.Add( new DataColumn("description", typeof(string)));
	tcustomgroup.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomgroup.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcustomgroup.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcustomgroup.Columns.Add( new DataColumn("cu", typeof(string)));
	tcustomgroup.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcustomgroup.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tcustomgroup);
	tcustomgroup.PrimaryKey =  new DataColumn[]{tcustomgroup.Columns["idcustomgroup"]};


	//////////////////// REPORT /////////////////////////////////
	var treport= new DataTable("report");
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	C= new DataColumn("reportname", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	treport.Columns.Add( new DataColumn("groupname", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	C= new DataColumn("filename", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	C= new DataColumn("orientation", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	Tables.Add(treport);
	treport.PrimaryKey =  new DataColumn[]{treport.Columns["reportname"], treport.Columns["modulename"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{customgroup.Columns["idcustomgroup"]};
	var cChild = new []{customgroupoperation.Columns["idgroup"]};
	Relations.Add(new DataRelation("customgroupcustomgroupoperation",cPar,cChild,false));

	cPar = new []{report.Columns["reportname"]};
	cChild = new []{customgroupoperation.Columns["tablename"]};
	Relations.Add(new DataRelation("reportcustomgroupoperation",cPar,cChild,false));

	#endregion

}
}
}
