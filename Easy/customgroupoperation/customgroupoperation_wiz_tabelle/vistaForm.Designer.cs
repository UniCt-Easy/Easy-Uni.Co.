
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace customgroupoperation_wiz_tabelle {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Gestione Sicurezza Tabelle per i gruppi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customgroupoperation 		=> Tables["customgroupoperation"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customobject 		=> Tables["customobject"];

	///<summary>
	///Gruppi di utenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customgroup 		=> Tables["customgroup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customgroupoperation_temp 		=> Tables["customgroupoperation_temp"];

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
	tcustomgroupoperation.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcustomgroupoperation.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcustomgroupoperation.Columns.Add( new DataColumn("cu", typeof(string)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcustomgroupoperation.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tcustomgroupoperation);
	tcustomgroupoperation.PrimaryKey =  new DataColumn[]{tcustomgroupoperation.Columns["idgroup"], tcustomgroupoperation.Columns["tablename"], tcustomgroupoperation.Columns["operation"]};


	//////////////////// CUSTOMOBJECT /////////////////////////////////
	var tcustomobject= new DataTable("customobject");
	C= new DataColumn("objectname", typeof(string));
	C.AllowDBNull=false;
	tcustomobject.Columns.Add(C);
	tcustomobject.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("isreal", typeof(string));
	C.AllowDBNull=false;
	tcustomobject.Columns.Add(C);
	tcustomobject.Columns.Add( new DataColumn("realtable", typeof(string)));
	tcustomobject.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomobject.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	Tables.Add(tcustomobject);
	tcustomobject.PrimaryKey =  new DataColumn[]{tcustomobject.Columns["objectname"]};


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


	//////////////////// CUSTOMGROUPOPERATION_TEMP /////////////////////////////////
	var tcustomgroupoperation_temp= new DataTable("customgroupoperation_temp");
	C= new DataColumn("idgroup", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation_temp.Columns.Add(C);
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation_temp.Columns.Add(C);
	C= new DataColumn("operation", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation_temp.Columns.Add(C);
	C= new DataColumn("defaultisdeny", typeof(string));
	C.AllowDBNull=false;
	tcustomgroupoperation_temp.Columns.Add(C);
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("allowcondition", typeof(string)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("denycondition", typeof(string)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("cu", typeof(string)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcustomgroupoperation_temp.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tcustomgroupoperation_temp);
	tcustomgroupoperation_temp.PrimaryKey =  new DataColumn[]{tcustomgroupoperation_temp.Columns["idgroup"], tcustomgroupoperation_temp.Columns["tablename"], tcustomgroupoperation_temp.Columns["operation"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{customobject.Columns["objectname"]};
	var cChild = new []{customgroupoperation.Columns["tablename"]};
	Relations.Add(new DataRelation("customobjectcustomgroupoperation",cPar,cChild,false));

	cPar = new []{customgroup.Columns["idcustomgroup"]};
	cChild = new []{customgroupoperation.Columns["idgroup"]};
	Relations.Add(new DataRelation("customgroupcustomgroupoperation",cPar,cChild,false));

	#endregion

}
}
}
