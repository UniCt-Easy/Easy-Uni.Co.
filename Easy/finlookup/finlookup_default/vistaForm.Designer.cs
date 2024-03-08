
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
namespace finlookup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Converti voci di Bilancio annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finlookup 		=> Tables["finlookup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview 		=> Tables["finview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finlookupview 		=> Tables["finlookupview"];

	///<summary>
	///Livelli del bilancio annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finlevel 		=> Tables["finlevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finview1 		=> Tables["finview1"];

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
	//////////////////// FINLOOKUP /////////////////////////////////
	var tfinlookup= new DataTable("finlookup");
	C= new DataColumn("oldidfin", typeof(int));
	C.AllowDBNull=false;
	tfinlookup.Columns.Add(C);
	C= new DataColumn("newidfin", typeof(int));
	C.AllowDBNull=false;
	tfinlookup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinlookup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlookup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinlookup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlookup.Columns.Add(C);
	Tables.Add(tfinlookup);
	tfinlookup.PrimaryKey =  new DataColumn[]{tfinlookup.Columns["oldidfin"], tfinlookup.Columns["newidfin"]};


	//////////////////// FINVIEW /////////////////////////////////
	var tfinview= new DataTable("finview");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview.Columns.Add(C);
	tfinview.Columns.Add( new DataColumn("paridfin", typeof(int)));
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


	//////////////////// FINLOOKUPVIEW /////////////////////////////////
	var tfinlookupview= new DataTable("finlookupview");
	C= new DataColumn("oldidfin", typeof(int));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("oldayear", typeof(short));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	tfinlookupview.Columns.Add( new DataColumn("oldpartfin", typeof(string)));
	C= new DataColumn("oldcodefin", typeof(string));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("oldtitle", typeof(string));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("newidfin", typeof(int));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("newayear", typeof(short));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	tfinlookupview.Columns.Add( new DataColumn("newpartfin", typeof(string)));
	C= new DataColumn("newfincode", typeof(string));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("newtitle", typeof(string));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlookupview.Columns.Add(C);
	Tables.Add(tfinlookupview);
	tfinlookupview.PrimaryKey =  new DataColumn[]{tfinlookupview.Columns["oldidfin"]};


	//////////////////// FINLEVEL /////////////////////////////////
	var tfinlevel= new DataTable("finlevel");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinlevel.Columns.Add(C);
	Tables.Add(tfinlevel);
	tfinlevel.PrimaryKey =  new DataColumn[]{tfinlevel.Columns["ayear"], tfinlevel.Columns["nlevel"]};


	//////////////////// FINVIEW1 /////////////////////////////////
	var tfinview1= new DataTable("finview1");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	tfinview1.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	tfinview1.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinview1.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinview1.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	tfinview1.Columns.Add( new DataColumn("prevision", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinview1.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinview1.Columns.Add(C);
	tfinview1.Columns.Add( new DataColumn("idupb", typeof(string)));
	Tables.Add(tfinview1);
	tfinview1.PrimaryKey =  new DataColumn[]{tfinview1.Columns["idfin"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finview1.Columns["idfin"]};
	var cChild = new []{finlookup.Columns["newidfin"]};
	Relations.Add(new DataRelation("bilancioview1finlookup",cPar,cChild,false));

	cPar = new []{finview.Columns["idfin"]};
	cChild = new []{finlookup.Columns["oldidfin"]};
	Relations.Add(new DataRelation("finviewfinlookup",cPar,cChild,false));

	#endregion

}
}
}
