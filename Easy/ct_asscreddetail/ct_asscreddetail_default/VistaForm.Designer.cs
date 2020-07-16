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
namespace ct_asscreddetail_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("VistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class VistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finspesa 		=> Tables["finspesa"];

	///<summary>
	///Contiene la percentuale con cui la voce di spesa è assegnata alla voce di entrata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ct_asscreddetail 		=> Tables["ct_asscreddetail"];

	///<summary>
	///Consente di configurare l'assegnazione della stessa voce di entrata su varie uscite.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ct_asscred 		=> Tables["ct_asscred"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ct_asscreddetailview 		=> Tables["ct_asscreddetailview"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public VistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected VistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "VistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// FIN /////////////////////////////////
	var tfin= new DataTable("fin");
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
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


	//////////////////// FINSPESA /////////////////////////////////
	var tfinspesa= new DataTable("finspesa");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	tfinspesa.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	tfinspesa.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	tfinspesa.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinspesa.Columns.Add(C);
	Tables.Add(tfinspesa);
	tfinspesa.PrimaryKey =  new DataColumn[]{tfinspesa.Columns["idfin"]};


	//////////////////// CT_ASSCREDDETAIL /////////////////////////////////
	var tct_asscreddetail= new DataTable("ct_asscreddetail");
	C= new DataColumn("idct_asscred", typeof(int));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	C= new DataColumn("idfin_expense", typeof(int));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	C= new DataColumn("quota", typeof(double));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tct_asscreddetail.Columns.Add(C);
	Tables.Add(tct_asscreddetail);
	tct_asscreddetail.PrimaryKey =  new DataColumn[]{tct_asscreddetail.Columns["idct_asscred"], tct_asscreddetail.Columns["idfin_expense"]};


	//////////////////// CT_ASSCRED /////////////////////////////////
	var tct_asscred= new DataTable("ct_asscred");
	C= new DataColumn("idct_asscred", typeof(int));
	C.AllowDBNull=false;
	tct_asscred.Columns.Add(C);
	C= new DataColumn("idfin_income", typeof(int));
	C.AllowDBNull=false;
	tct_asscred.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tct_asscred.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tct_asscred.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tct_asscred.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tct_asscred.Columns.Add(C);
	tct_asscred.Columns.Add( new DataColumn("idsor", typeof(int)));
	Tables.Add(tct_asscred);
	tct_asscred.PrimaryKey =  new DataColumn[]{tct_asscred.Columns["idct_asscred"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// CT_ASSCREDDETAILVIEW /////////////////////////////////
	var tct_asscreddetailview= new DataTable("ct_asscreddetailview");
	C= new DataColumn("idct_asscred", typeof(int));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("idfin_income", typeof(int));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("yfinincome", typeof(short));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("finincomecode", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("finincometitle", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("idfin_expense", typeof(int));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("yfinexpense", typeof(short));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("finexpensecode", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("finexpensetitle", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("sorting", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("quota", typeof(double));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tct_asscreddetailview.Columns.Add(C);
	Tables.Add(tct_asscreddetailview);
	tct_asscreddetailview.PrimaryKey =  new DataColumn[]{tct_asscreddetailview.Columns["idct_asscred"], tct_asscreddetailview.Columns["idfin_expense"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{ct_asscred.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_ct_asscred",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{ct_asscred.Columns["idfin_income"]};
	Relations.Add(new DataRelation("FK_fin_ct_asscred",cPar,cChild,false));

	cPar = new []{finspesa.Columns["idfin"]};
	cChild = new []{ct_asscreddetail.Columns["idfin_expense"]};
	Relations.Add(new DataRelation("FK_finspesa_ct_asscreddetail",cPar,cChild,false));

	cPar = new []{ct_asscred.Columns["idct_asscred"]};
	cChild = new []{ct_asscreddetail.Columns["idct_asscred"]};
	Relations.Add(new DataRelation("FK_ct_asscred_ct_asscreddetail",cPar,cChild,false));

	#endregion

}
}
}
