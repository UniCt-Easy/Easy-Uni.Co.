/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
namespace finmotivedetail_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Dettaglio causale finanziaria
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotivedetail 		=> Tables["finmotivedetail"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

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
	//////////////////// FINMOTIVEDETAIL /////////////////////////////////
	var tfinmotivedetail= new DataTable("finmotivedetail");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinmotivedetail.Columns.Add(C);
	Tables.Add(tfinmotivedetail);
	tfinmotivedetail.PrimaryKey =  new DataColumn[]{tfinmotivedetail.Columns["idfinmotive"], tfinmotivedetail.Columns["idfin"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("finpart", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("paridfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinview.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("idupb", typeof(string)));
	Tables.Add(tfinview);
	tfinview.PrimaryKey =  new DataColumn[]{tfinview.Columns["idfin"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finview.Columns["idfin"]};
	var cChild = new []{finmotivedetail.Columns["idfin"]};
	Relations.Add(new DataRelation("finview_finmotivedetail",cPar,cChild,false));

	#endregion

}
}
}
