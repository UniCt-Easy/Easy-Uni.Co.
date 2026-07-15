/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace metaeasylibrary {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("VistaEasyAudits"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class VistaEasyAudits: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable audit 		=> Tables["audit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable auditparameter 		=> Tables["auditparameter"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tableop 		=> Tables["tableop"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable auditcheckview 		=> Tables["auditcheckview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public VistaEasyAudits(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected VistaEasyAudits (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "VistaEasyAudits";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaEasyAudits.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// AUDIT /////////////////////////////////
	var taudit= new DataTable("audit");
	C= new DataColumn("idaudit", typeof(string));
	C.AllowDBNull=false;
	taudit.Columns.Add(C);
	C= new DataColumn("severity", typeof(string));
	C.AllowDBNull=false;
	taudit.Columns.Add(C);
	taudit.Columns.Add( new DataColumn("title", typeof(string)));
	taudit.Columns.Add( new DataColumn("flagsystem", typeof(string)));
	Tables.Add(taudit);
	taudit.PrimaryKey =  new DataColumn[]{taudit.Columns["idaudit"]};


	//////////////////// AUDITPARAMETER /////////////////////////////////
	var tauditparameter= new DataTable("auditparameter");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tauditparameter.Columns.Add(C);
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	tauditparameter.Columns.Add(C);
	C= new DataColumn("isprecheck", typeof(string));
	C.AllowDBNull=false;
	tauditparameter.Columns.Add(C);
	C= new DataColumn("parameterid", typeof(short));
	C.AllowDBNull=false;
	tauditparameter.Columns.Add(C);
	C= new DataColumn("paramtable", typeof(string));
	C.AllowDBNull=false;
	tauditparameter.Columns.Add(C);
	C= new DataColumn("paramcolumn", typeof(string));
	C.AllowDBNull=false;
	tauditparameter.Columns.Add(C);
	tauditparameter.Columns.Add( new DataColumn("flagoldvalue", typeof(string)));
	Tables.Add(tauditparameter);
	tauditparameter.PrimaryKey =  new DataColumn[]{tauditparameter.Columns["tablename"], tauditparameter.Columns["opkind"], tauditparameter.Columns["isprecheck"], tauditparameter.Columns["parameterid"]};


	//////////////////// TABLEOP /////////////////////////////////
	var ttableop= new DataTable("tableop");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	ttableop.Columns.Add(C);
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	ttableop.Columns.Add(C);
	Tables.Add(ttableop);
	ttableop.PrimaryKey =  new DataColumn[]{ttableop.Columns["tablename"], ttableop.Columns["opkind"]};


	//////////////////// AUDITCHECKVIEW /////////////////////////////////
	var tauditcheckview= new DataTable("auditcheckview");
	C= new DataColumn("tablename", typeof(string));
	C.AllowDBNull=false;
	tauditcheckview.Columns.Add(C);
	C= new DataColumn("opkind", typeof(string));
	C.AllowDBNull=false;
	tauditcheckview.Columns.Add(C);
	C= new DataColumn("idcheck", typeof(short));
	C.AllowDBNull=false;
	tauditcheckview.Columns.Add(C);
	C= new DataColumn("idaudit", typeof(string));
	C.AllowDBNull=false;
	tauditcheckview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tauditcheckview.Columns.Add(C);
	C= new DataColumn("severity", typeof(string));
	C.AllowDBNull=false;
	tauditcheckview.Columns.Add(C);
	tauditcheckview.Columns.Add( new DataColumn("sqlcmd", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("message", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("precheck", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("flag_comp", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("flag_cash", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("flag_both", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("flag_credit", typeof(string)));
	tauditcheckview.Columns.Add( new DataColumn("flag_proceeds", typeof(string)));
	Tables.Add(tauditcheckview);
	tauditcheckview.PrimaryKey =  new DataColumn[]{tauditcheckview.Columns["tablename"], tauditcheckview.Columns["opkind"], tauditcheckview.Columns["idcheck"], tauditcheckview.Columns["idaudit"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{tableop.Columns["tablename"], tableop.Columns["opkind"]};
	var cChild = new []{auditcheckview.Columns["tablename"], auditcheckview.Columns["opkind"]};
	Relations.Add(new DataRelation("tableopauditcheckview",cPar,cChild,false));

	cPar = new []{tableop.Columns["tablename"], tableop.Columns["opkind"]};
	cChild = new []{auditparameter.Columns["tablename"], auditparameter.Columns["opkind"]};
	Relations.Add(new DataRelation("tableopauditparameter",cPar,cChild,false));

	#endregion

}
}
}
