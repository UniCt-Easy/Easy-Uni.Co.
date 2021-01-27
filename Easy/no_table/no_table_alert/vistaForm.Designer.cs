
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
namespace no_table_alert {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Avvisi da dare all'avvio del programma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable alert 		=> Tables["alert"];

	///<summary>
	///Configurazione DB
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dbuser 		=> Tables["dbuser"];

	///<summary>
	///Associazione utente - avviso
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dbuseralert 		=> Tables["dbuseralert"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

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
	//////////////////// ALERT /////////////////////////////////
	var talert= new DataTable("alert");
	C= new DataColumn("idalert", typeof(int));
	C.AllowDBNull=false;
	talert.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	talert.Columns.Add(C);
	talert.Columns.Add( new DataColumn("alertdetail", typeof(string)));
	talert.Columns.Add( new DataColumn("query", typeof(string)));
	talert.Columns.Add( new DataColumn("tablename", typeof(string)));
	talert.Columns.Add( new DataColumn("edittype", typeof(string)));
	talert.Columns.Add( new DataColumn("listtype", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	talert.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	talert.Columns.Add(C);
	talert.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	talert.Columns.Add( new DataColumn("cu", typeof(string)));
	talert.Columns.Add( new DataColumn("alertcode", typeof(string)));
	Tables.Add(talert);
	talert.PrimaryKey =  new DataColumn[]{talert.Columns["idalert"]};


	//////////////////// DBUSER /////////////////////////////////
	var tdbuser= new DataTable("dbuser");
	tdbuser.Columns.Add( new DataColumn("forename", typeof(string)));
	tdbuser.Columns.Add( new DataColumn("initpwd", typeof(string)));
	C= new DataColumn("login", typeof(string));
	C.AllowDBNull=false;
	tdbuser.Columns.Add(C);
	tdbuser.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdbuser.Columns.Add( new DataColumn("lu", typeof(string)));
	tdbuser.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tdbuser.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tdbuser.Columns.Add( new DataColumn("surname", typeof(string)));
	Tables.Add(tdbuser);
	tdbuser.PrimaryKey =  new DataColumn[]{tdbuser.Columns["login"]};


	//////////////////// DBUSERALERT /////////////////////////////////
	var tdbuseralert= new DataTable("dbuseralert");
	C= new DataColumn("idalert", typeof(int));
	C.AllowDBNull=false;
	tdbuseralert.Columns.Add(C);
	C= new DataColumn("login", typeof(string));
	C.AllowDBNull=false;
	tdbuseralert.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdbuseralert.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdbuseralert.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdbuseralert.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdbuseralert.Columns.Add(C);
	Tables.Add(tdbuseralert);
	tdbuseralert.PrimaryKey =  new DataColumn[]{tdbuseralert.Columns["idalert"], tdbuseralert.Columns["login"]};


	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new DataTable("no_table");
	C= new DataColumn("idnotable", typeof(string));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	Tables.Add(tno_table);
	tno_table.PrimaryKey =  new DataColumn[]{tno_table.Columns["idnotable"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{dbuser.Columns["login"]};
	var cChild = new []{dbuseralert.Columns["login"]};
	Relations.Add(new DataRelation("dbuser_useralert",cPar,cChild,false));

	cPar = new []{alert.Columns["idalert"]};
	cChild = new []{dbuseralert.Columns["idalert"]};
	Relations.Add(new DataRelation("alert_useralert",cPar,cChild,false));

	#endregion

}
}
}
