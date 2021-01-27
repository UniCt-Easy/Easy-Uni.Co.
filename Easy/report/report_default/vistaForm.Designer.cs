
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
namespace report_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Configurazione delle stampe
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable report 		=> Tables["report"];

	///<summary>
	///Parametro del prospetto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable reportparameter 		=> Tables["reportparameter"];

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
	//////////////////// REPORT /////////////////////////////////
	var treport= new DataTable("report");
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	treport.Columns.Add( new DataColumn("groupname", typeof(string)));
	C= new DataColumn("filename", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	C= new DataColumn("orientation", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	treport.Columns.Add( new DataColumn("papersize", typeof(string)));
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	C= new DataColumn("reportname", typeof(string));
	C.AllowDBNull=false;
	treport.Columns.Add(C);
	treport.Columns.Add( new DataColumn("webvisible", typeof(string)));
	treport.Columns.Add( new DataColumn("timeout", typeof(int)));
	treport.Columns.Add( new DataColumn("flag_both", typeof(string)));
	treport.Columns.Add( new DataColumn("flag_cash", typeof(string)));
	treport.Columns.Add( new DataColumn("flag_comp", typeof(string)));
	treport.Columns.Add( new DataColumn("active", typeof(string)));
	treport.Columns.Add( new DataColumn("flag_credit", typeof(string)));
	treport.Columns.Add( new DataColumn("flag_proceeds", typeof(string)));
	treport.Columns.Add( new DataColumn("print_rs", typeof(string)));
	Tables.Add(treport);
	treport.PrimaryKey =  new DataColumn[]{treport.Columns["reportname"]};


	//////////////////// REPORTPARAMETER /////////////////////////////////
	var treportparameter= new DataTable("reportparameter");
	C= new DataColumn("reportname", typeof(string));
	C.AllowDBNull=false;
	treportparameter.Columns.Add(C);
	C= new DataColumn("paramname", typeof(string));
	C.AllowDBNull=false;
	treportparameter.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	treportparameter.Columns.Add(C);
	treportparameter.Columns.Add( new DataColumn("tag", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("systype", typeof(string)));
	C= new DataColumn("number", typeof(short));
	C.AllowDBNull=false;
	treportparameter.Columns.Add(C);
	treportparameter.Columns.Add( new DataColumn("hintkind", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("hint", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("iscombobox", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("datasource", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("valuemember", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("displaymember", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("noselectionforall", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("help", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	treportparameter.Columns.Add( new DataColumn("cu", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("filter", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	treportparameter.Columns.Add( new DataColumn("lu", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("help2", typeof(string)));
	treportparameter.Columns.Add( new DataColumn("selectioncode", typeof(string)));
	Tables.Add(treportparameter);
	treportparameter.PrimaryKey =  new DataColumn[]{treportparameter.Columns["reportname"], treportparameter.Columns["paramname"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{report.Columns["reportname"]};
	var cChild = new []{reportparameter.Columns["reportname"]};
	Relations.Add(new DataRelation("reportreportparameter",cPar,cChild,false));

	#endregion

}
}
}
