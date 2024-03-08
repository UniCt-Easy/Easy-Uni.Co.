
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
namespace flussoincassidetail_bollettino {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Incassi comunicatici dal nodo pagamenti o simili
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussoincassi 		=> Tables["flussoincassi"];

	///<summary>
	///dettaglio flusso incassi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussoincassidetail 		=> Tables["flussoincassidetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flussoincassidetailview 		=> Tables["flussoincassidetailview"];

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
	//////////////////// FLUSSOINCASSI /////////////////////////////////
	var tflussoincassi= new DataTable("flussoincassi");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussoincassi.Columns.Add(C);
	tflussoincassi.Columns.Add( new DataColumn("codiceflusso", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("trn", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tflussoincassi.Columns.Add( new DataColumn("cu", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tflussoincassi.Columns.Add( new DataColumn("lu", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("ayear", typeof(short)));
	tflussoincassi.Columns.Add( new DataColumn("causale", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("dataincasso", typeof(DateTime)));
	tflussoincassi.Columns.Add( new DataColumn("nbill", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("importo", typeof(decimal)));
	tflussoincassi.Columns.Add( new DataColumn("to_complete", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("elaborato", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("active", typeof(string)));
	tflussoincassi.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tflussoincassi.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tflussoincassi);
	tflussoincassi.PrimaryKey =  new DataColumn[]{tflussoincassi.Columns["idflusso"]};


	//////////////////// FLUSSOINCASSIDETAIL /////////////////////////////////
	var tflussoincassidetail= new DataTable("flussoincassidetail");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussoincassidetail.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tflussoincassidetail.Columns.Add(C);
	tflussoincassidetail.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("iuv", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("importo", typeof(decimal)));
	tflussoincassidetail.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tflussoincassidetail.Columns.Add( new DataColumn("cu", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tflussoincassidetail.Columns.Add( new DataColumn("lu", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("cf", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("dataesitopagamento", typeof(DateTime)));
	tflussoincassidetail.Columns.Add( new DataColumn("identificativounivocoriscossione", typeof(string)));
	tflussoincassidetail.Columns.Add( new DataColumn("codicepsp", typeof(string)));
	Tables.Add(tflussoincassidetail);
	tflussoincassidetail.PrimaryKey =  new DataColumn[]{tflussoincassidetail.Columns["idflusso"], tflussoincassidetail.Columns["iddetail"]};


	//////////////////// FLUSSOINCASSIDETAILVIEW /////////////////////////////////
	var tflussoincassidetailview= new DataTable("flussoincassidetailview");
	C= new DataColumn("idflusso", typeof(int));
	C.AllowDBNull=false;
	tflussoincassidetailview.Columns.Add(C);
	C= new DataColumn("iddetail", typeof(int));
	C.AllowDBNull=false;
	tflussoincassidetailview.Columns.Add(C);
	tflussoincassidetailview.Columns.Add( new DataColumn("importo", typeof(decimal)));
	tflussoincassidetailview.Columns.Add( new DataColumn("iuv", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("cf", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tflussoincassidetailview.Columns.Add( new DataColumn("lu", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tflussoincassidetailview.Columns.Add( new DataColumn("cu", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("iduniqueformcode", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("codiceflusso", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("nbill", typeof(int)));
	tflussoincassidetailview.Columns.Add( new DataColumn("trn", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("dataincasso", typeof(DateTime)));
	tflussoincassidetailview.Columns.Add( new DataColumn("ayear", typeof(short)));
	tflussoincassidetailview.Columns.Add( new DataColumn("causale", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("importotale", typeof(decimal)));
	tflussoincassidetailview.Columns.Add( new DataColumn("active", typeof(string)));
	tflussoincassidetailview.Columns.Add( new DataColumn("elaborato", typeof(string)));
	Tables.Add(tflussoincassidetailview);
	tflussoincassidetailview.PrimaryKey =  new DataColumn[]{tflussoincassidetailview.Columns["idflusso"], tflussoincassidetailview.Columns["iddetail"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{flussoincassi.Columns["idflusso"]};
	var cChild = new []{flussoincassidetail.Columns["idflusso"]};
	Relations.Add(new DataRelation("flussoincassi_flussoincassidetail",cPar,cChild,false));

	#endregion

}
}
}
