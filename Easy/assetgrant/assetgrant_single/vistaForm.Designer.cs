
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
namespace assetgrant_single {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable underwriting 		=> Tables["underwriting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable assetgrant 		=> Tables["assetgrant"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable epacc 		=> Tables["epacc"];

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
	//////////////////// ACCMOTIVE /////////////////////////////////
	var taccmotive= new DataTable("accmotive");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flagdep", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive.Columns.Add(C);
	taccmotive.Columns.Add( new DataColumn("expensekind", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// UNDERWRITING /////////////////////////////////
	var tunderwriting= new DataTable("underwriting");
	C= new DataColumn("idunderwriting", typeof(int));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("active", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("codeunderwriting", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	tunderwriting.Columns.Add( new DataColumn("doc", typeof(string)));
	tunderwriting.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tunderwriting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tunderwriting.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tunderwriting.Columns.Add(C);
	Tables.Add(tunderwriting);
	tunderwriting.PrimaryKey =  new DataColumn[]{tunderwriting.Columns["idunderwriting"]};


	//////////////////// ASSETGRANT /////////////////////////////////
	var tassetgrant= new DataTable("assetgrant");
	C= new DataColumn("idasset", typeof(int));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	C= new DataColumn("idgrant", typeof(int));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	tassetgrant.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	tassetgrant.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("amount", typeof(decimal));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	tassetgrant.Columns.Add( new DataColumn("ygrant", typeof(short)));
	tassetgrant.Columns.Add( new DataColumn("description", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("doc", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tassetgrant.Columns.Add( new DataColumn("idgrantload", typeof(int)));
	tassetgrant.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tassetgrant.Columns.Add( new DataColumn("lu", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tassetgrant.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("idpiece", typeof(int));
	C.AllowDBNull=false;
	tassetgrant.Columns.Add(C);
	tassetgrant.Columns.Add( new DataColumn("idepacc", typeof(int)));
	tassetgrant.Columns.Add( new DataColumn("flag_financesource", typeof(string)));
	tassetgrant.Columns.Add( new DataColumn("flag_entryprofitreservedone", typeof(string)));
	Tables.Add(tassetgrant);
	tassetgrant.PrimaryKey =  new DataColumn[]{tassetgrant.Columns["idasset"], tassetgrant.Columns["idgrant"], tassetgrant.Columns["idpiece"]};


	//////////////////// EPACC /////////////////////////////////
	var tepacc= new DataTable("epacc");
	C= new DataColumn("idepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("doc", typeof(string)));
	tepacc.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("idman", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idreg", typeof(int)));
	tepacc.Columns.Add( new DataColumn("idrelated", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nepacc", typeof(int));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	C= new DataColumn("nphase", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("paridepacc", typeof(int)));
	tepacc.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tepacc.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tepacc.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("yepacc", typeof(short));
	C.AllowDBNull=false;
	tepacc.Columns.Add(C);
	tepacc.Columns.Add( new DataColumn("flagvariation", typeof(string)));
	tepacc.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	Tables.Add(tepacc);
	tepacc.PrimaryKey =  new DataColumn[]{tepacc.Columns["idepacc"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{underwriting.Columns["idunderwriting"]};
	var cChild = new []{assetgrant.Columns["idunderwriting"]};
	Relations.Add(new DataRelation("underwriting_assetgrant",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{assetgrant.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotive_assetgrant",cPar,cChild,false));

	cPar = new []{epacc.Columns["idepacc"]};
	cChild = new []{assetgrant.Columns["idepacc"]};
	Relations.Add(new DataRelation("epacc_assetgrant",cPar,cChild,false));

	#endregion

}
}
}
