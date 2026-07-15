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
namespace upbcostpartitionsetup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable costpartition 		=> Tables["costpartition"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbcostpartitionsetup 		=> Tables["upbcostpartitionsetup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upbcostpartitionsetupview 		=> Tables["upbcostpartitionsetupview"];

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
	//////////////////// COSTPARTITION /////////////////////////////////
	var tcostpartition= new DataTable("costpartition");
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tcostpartition.Columns.Add(C);
	tcostpartition.Columns.Add( new DataColumn("title", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("kind", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("lu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcostpartition.Columns.Add( new DataColumn("cu", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("active", typeof(string)));
	tcostpartition.Columns.Add( new DataColumn("description", typeof(string)));
	Tables.Add(tcostpartition);
	tcostpartition.PrimaryKey =  new DataColumn[]{tcostpartition.Columns["idcostpartition"]};


	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("active", typeof(string)));
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousassessment", typeof(decimal)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tupb.Columns.Add( new DataColumn("cigcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("idepupbkind", typeof(int)));
	tupb.Columns.Add( new DataColumn("flag", typeof(int)));
	tupb.Columns.Add( new DataColumn("uesiopecode", typeof(string)));
	tupb.Columns.Add( new DataColumn("cofogmpcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("ri_ra_quota", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("ri_rb_quota", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("ri_sa_quota", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("idupb_capofila", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


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
	taccmotive.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("expensekind", typeof(string)));
	taccmotive.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// UPBCOSTPARTITIONSETUP /////////////////////////////////
	var tupbcostpartitionsetup= new DataTable("upbcostpartitionsetup");
	C= new DataColumn("idupbcostpartitionsetup", typeof(int));
	C.AllowDBNull=false;
	tupbcostpartitionsetup.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbcostpartitionsetup.Columns.Add(C);
	tupbcostpartitionsetup.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tupbcostpartitionsetup.Columns.Add(C);
	tupbcostpartitionsetup.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupbcostpartitionsetup.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupbcostpartitionsetup.Columns.Add( new DataColumn("cu", typeof(string)));
	tupbcostpartitionsetup.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tupbcostpartitionsetup.Columns.Add( new DataColumn("lu", typeof(string)));
	tupbcostpartitionsetup.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tupbcostpartitionsetup);
	tupbcostpartitionsetup.PrimaryKey =  new DataColumn[]{tupbcostpartitionsetup.Columns["idupbcostpartitionsetup"]};


	//////////////////// UPBCOSTPARTITIONSETUPVIEW /////////////////////////////////
	var tupbcostpartitionsetupview= new DataTable("upbcostpartitionsetupview");
	C= new DataColumn("idupbcostpartitionsetup", typeof(int));
	C.AllowDBNull=false;
	tupbcostpartitionsetupview.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupbcostpartitionsetupview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupbcostpartitionsetupview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tupbcostpartitionsetupview.Columns.Add(C);
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("accmotive", typeof(string)));
	C= new DataColumn("idcostpartition", typeof(int));
	C.AllowDBNull=false;
	tupbcostpartitionsetupview.Columns.Add(C);
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("costpartitioncode", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("costpartitiondescription", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("costpartition", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("cu", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("lu", typeof(string)));
	tupbcostpartitionsetupview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tupbcostpartitionsetupview);

	#endregion


	#region DataRelation creation
	var cPar = new []{upb.Columns["idupb"]};
	var cChild = new []{upbcostpartitionsetup.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_upbcostpartitionsetup",cPar,cChild,false));

	cPar = new []{costpartition.Columns["idcostpartition"]};
	cChild = new []{upbcostpartitionsetup.Columns["idcostpartition"]};
	Relations.Add(new DataRelation("costpartition_upbcostpartitionsetup",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{upbcostpartitionsetup.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("accmotive_upbcostpartitionsetup",cPar,cChild,false));

	#endregion

}
}
}
