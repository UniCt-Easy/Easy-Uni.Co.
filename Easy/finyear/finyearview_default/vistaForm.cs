
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
namespace finyearview_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Previsione iniziale su coppia upb-bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finyear 		=> Tables["finyear"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finyearview 		=> Tables["finyearview"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

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
	//////////////////// UPB /////////////////////////////////
	var tupb= new DataTable("upb");
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("requested", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("granted", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("previousappropriation", typeof(decimal)));
	tupb.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tupb.Columns.Add( new DataColumn("txt", typeof(string)));
	tupb.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("assured", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tupb.Columns.Add(C);
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// FINYEAR /////////////////////////////////
	var tfinyear= new DataTable("finyear");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinyear.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinyear.Columns.Add(C);
	tfinyear.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinyear.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyear.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinyear.Columns.Add(C);
	tfinyear.Columns.Add( new DataColumn("ayear", typeof(int)));
	Tables.Add(tfinyear);
	tfinyear.PrimaryKey =  new DataColumn[]{tfinyear.Columns["idfin"], tfinyear.Columns["idupb"]};


	//////////////////// FINYEARVIEW /////////////////////////////////
	var tfinyearview= new DataTable("finyearview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("finance", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("paridupb", typeof(string)));
	tfinyearview.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("limit", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinyearview.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	tfinyearview.Columns.Add(C);
	tfinyearview.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tfinyearview.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tfinyearview);
	tfinyearview.PrimaryKey =  new DataColumn[]{tfinyearview.Columns["idfin"], tfinyearview.Columns["idupb"]};


	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{upb.Columns["idupb"]};
	var cChild = new []{finyearview.Columns["idupb"]};
	Relations.Add(new DataRelation("upbfinyearview",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{finyearview.Columns["idfin"]};
	Relations.Add(new DataRelation("finfinyearview",cPar,cChild,false));

	cPar = new []{finyearview.Columns["idfin"], finyearview.Columns["idupb"]};
	cChild = new []{finyearview.Columns["idfin"], finyearview.Columns["paridupb"]};
	Relations.Add(new DataRelation("finyearviewfinyearview",cPar,cChild,false));

	#endregion

}
}
}
