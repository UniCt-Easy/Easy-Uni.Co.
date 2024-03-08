
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
namespace registry_docenti_anagraficadetail {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_docenti 		=> Tables["registry_docenti"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_istituti 		=> Tables["registry_istituti"];

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
	//////////////////// REGISTRY_DOCENTI /////////////////////////////////
	var tregistry_docenti= new DataTable("registry_docenti");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	tregistry_docenti.Columns.Add( new DataColumn("cv", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("idclassconsorsuale", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idfonteindicebibliometrico", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idreg_istituti", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idsasd", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idstruttura", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("indicebibliometrico", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	tregistry_docenti.Columns.Add( new DataColumn("matricola", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("ricevimento", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("soggiorno", typeof(string)));
	Tables.Add(tregistry_docenti);
	tregistry_docenti.PrimaryKey =  new DataColumn[]{tregistry_docenti.Columns["idreg"]};


	//////////////////// REGISTRY_ISTITUTI /////////////////////////////////
	var tregistry_istituti= new DataTable("registry_istituti");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_istituti.Columns.Add(C);
	tregistry_istituti.Columns.Add( new DataColumn("idistitutoustat", typeof(int)));
	C= new DataColumn("idistitutokind", typeof(int));
	C.AllowDBNull=false;
	tregistry_istituti.Columns.Add(C);
	tregistry_istituti.Columns.Add( new DataColumn("title", typeof(string)));
	tregistry_istituti.Columns.Add( new DataColumn("title_en", typeof(string)));
	tregistry_istituti.Columns.Add( new DataColumn("nome", typeof(string)));
	tregistry_istituti.Columns.Add( new DataColumn("codicemiur", typeof(string)));
	tregistry_istituti.Columns.Add( new DataColumn("codiceustat", typeof(string)));
	tregistry_istituti.Columns.Add( new DataColumn("sortcode", typeof(int)));
	tregistry_istituti.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_istituti.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_istituti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_istituti.Columns.Add(C);
	tregistry_istituti.Columns.Add( new DataColumn("comune", typeof(string)));
	Tables.Add(tregistry_istituti);
	tregistry_istituti.PrimaryKey =  new DataColumn[]{tregistry_istituti.Columns["idreg"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry_istituti.Columns["idreg"]};
	var cChild = new []{registry_docenti.Columns["idreg_istituti"]};
	Relations.Add(new DataRelation("registry_istituti_registry_docenti",cPar,cChild,false));

	#endregion

}
}
}
