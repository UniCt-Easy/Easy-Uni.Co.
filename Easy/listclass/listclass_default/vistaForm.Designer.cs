/*
    Easy
    Copyright (C) 2019 Universit‡ degli Studi di Catania (www.unict.it)

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
namespace listclass_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclass 		=> Tables["listclass"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied 		=> Tables["accmotiveapplied"];

	///<summary>
	///Codice del servizio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatservice 		=> Tables["intrastatservice"];

	///<summary>
	/// Natura della transazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatsupplymethod 		=> Tables["intrastatsupplymethod"];

	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclassyear 		=> Tables["listclassyear"];

	///<summary>
	///Nomenclatura combinata
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatcode 		=> Tables["intrastatcode"];

	///<summary>
	///Unit√† di misura supplementare
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatmeasure 		=> Tables["intrastatmeasure"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable intrastatcodeview 		=> Tables["intrastatcodeview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable inventorytreeview 		=> Tables["inventorytreeview"];

	///<summary>
	///Causali finanziarie (gerarchia)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive 		=> Tables["finmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_credit 		=> Tables["accmotiveapplied_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable listclassyearview 		=> Tables["listclassyearview"];

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
	//////////////////// LISTCLASS /////////////////////////////////
	var tlistclass= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("paridlistclass", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tlistclass.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlistclass.Columns.Add(C);
	tlistclass.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("flag", typeof(int)));
	tlistclass.Columns.Add( new DataColumn("idinv", typeof(int)));
	tlistclass.Columns.Add( new DataColumn("assetkind", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("va3type", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tlistclass.Columns.Add( new DataColumn("intra12operationkind", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	tlistclass.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tlistclass.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	Tables.Add(tlistclass);
	tlistclass.PrimaryKey =  new DataColumn[]{tlistclass.Columns["idlistclass"]};


	//////////////////// ACCMOTIVEAPPLIED /////////////////////////////////
	var taccmotiveapplied= new DataTable("accmotiveapplied");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	taccmotiveapplied.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied.Columns.Add(C);
	Tables.Add(taccmotiveapplied);
	taccmotiveapplied.PrimaryKey =  new DataColumn[]{taccmotiveapplied.Columns["idaccmotive"]};


	//////////////////// INTRASTATSERVICE /////////////////////////////////
	var tintrastatservice= new DataTable("intrastatservice");
	C= new DataColumn("idintrastatservice", typeof(int));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tintrastatservice.Columns.Add(C);
	Tables.Add(tintrastatservice);
	tintrastatservice.PrimaryKey =  new DataColumn[]{tintrastatservice.Columns["idintrastatservice"]};


	//////////////////// INTRASTATSUPPLYMETHOD /////////////////////////////////
	var tintrastatsupplymethod= new DataTable("intrastatsupplymethod");
	C= new DataColumn("idintrastatsupplymethod", typeof(int));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tintrastatsupplymethod.Columns.Add(C);
	Tables.Add(tintrastatsupplymethod);
	tintrastatsupplymethod.PrimaryKey =  new DataColumn[]{tintrastatsupplymethod.Columns["idintrastatsupplymethod"]};


	//////////////////// LISTCLASSYEAR /////////////////////////////////
	var tlistclassyear= new DataTable("listclassyear");
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclassyear.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tlistclassyear.Columns.Add(C);
	tlistclassyear.Columns.Add( new DataColumn("idintrastatservice", typeof(int)));
	tlistclassyear.Columns.Add( new DataColumn("idintrastatcode", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tlistclassyear.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclassyear.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tlistclassyear.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tlistclassyear.Columns.Add(C);
	Tables.Add(tlistclassyear);
	tlistclassyear.PrimaryKey =  new DataColumn[]{tlistclassyear.Columns["idlistclass"], tlistclassyear.Columns["ayear"]};


	//////////////////// INTRASTATCODE /////////////////////////////////
	var tintrastatcode= new DataTable("intrastatcode");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	tintrastatcode.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tintrastatcode.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatcode.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("idintrastatcode", typeof(int));
	C.AllowDBNull=false;
	tintrastatcode.Columns.Add(C);
	Tables.Add(tintrastatcode);
	tintrastatcode.PrimaryKey =  new DataColumn[]{tintrastatcode.Columns["idintrastatcode"]};


	//////////////////// INTRASTATMEASURE /////////////////////////////////
	var tintrastatmeasure= new DataTable("intrastatmeasure");
	C= new DataColumn("idintrastatmeasure", typeof(int));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatmeasure.Columns.Add(C);
	tintrastatmeasure.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatmeasure.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tintrastatmeasure);
	tintrastatmeasure.PrimaryKey =  new DataColumn[]{tintrastatmeasure.Columns["idintrastatmeasure"]};


	//////////////////// INTRASTATCODEVIEW /////////////////////////////////
	var tintrastatcodeview= new DataTable("intrastatcodeview");
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	C= new DataColumn("idintrastatcode", typeof(int));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	C= new DataColumn("code", typeof(string));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tintrastatcodeview.Columns.Add(C);
	tintrastatcodeview.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tintrastatcodeview.Columns.Add( new DataColumn("measurecode", typeof(string)));
	tintrastatcodeview.Columns.Add( new DataColumn("measuredescription", typeof(string)));
	tintrastatcodeview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tintrastatcodeview.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tintrastatcodeview);
	tintrastatcodeview.PrimaryKey =  new DataColumn[]{tintrastatcodeview.Columns["idintrastatcode"]};


	//////////////////// INVENTORYTREEVIEW /////////////////////////////////
	var tinventorytreeview= new DataTable("inventorytreeview");
	C= new DataColumn("idinv", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	tinventorytreeview.Columns.Add( new DataColumn("paridinv", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("idinv_lev1", typeof(int));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("codeinv_lev1", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	tinventorytreeview.Columns.Add( new DataColumn("lookupcode", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinventorytreeview.Columns.Add(C);
	Tables.Add(tinventorytreeview);
	tinventorytreeview.PrimaryKey =  new DataColumn[]{tinventorytreeview.Columns["idinv"]};


	//////////////////// FINMOTIVE /////////////////////////////////
	var tfinmotive= new DataTable("finmotive");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	tfinmotive.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive.Columns.Add(C);
	tfinmotive.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive);
	tfinmotive.PrimaryKey =  new DataColumn[]{tfinmotive.Columns["idfinmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_CREDIT /////////////////////////////////
	var taccmotiveapplied_credit= new DataTable("accmotiveapplied_credit");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_credit.Columns.Add(C);
	taccmotiveapplied_credit.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_credit.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotiveapplied_credit);
	taccmotiveapplied_credit.PrimaryKey =  new DataColumn[]{taccmotiveapplied_credit.Columns["idaccmotive"]};


	//////////////////// LISTCLASSYEARVIEW /////////////////////////////////
	var tlistclassyearview= new DataTable("listclassyearview");
	C= new DataColumn("idlistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclassyearview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tlistclassyearview.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tlistclassyearview.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(string));
	C.AllowDBNull=false;
	tlistclassyearview.Columns.Add(C);
	tlistclassyearview.Columns.Add( new DataColumn("paridlistclass", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tlistclassyearview.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tlistclassyearview.Columns.Add(C);
	tlistclassyearview.Columns.Add( new DataColumn("authrequired", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("codemotive", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("motive", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("idinv", typeof(int)));
	tlistclassyearview.Columns.Add( new DataColumn("codeinv", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("inventorytree", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("assetkind", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("va3type", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("flag", typeof(int)));
	tlistclassyearview.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(int)));
	tlistclassyearview.Columns.Add( new DataColumn("intra12operationkind", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("idintrastatservice", typeof(int)));
	tlistclassyearview.Columns.Add( new DataColumn("codeintrastatservice", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("intrastatservice", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("idintrastatcode", typeof(int)));
	tlistclassyearview.Columns.Add( new DataColumn("codeintrastatcode", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("intrastatcode", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("idintrastatmeasure", typeof(int)));
	tlistclassyearview.Columns.Add( new DataColumn("measurecode", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("measuredescription", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("cu", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tlistclassyearview.Columns.Add( new DataColumn("lu", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tlistclassyearview.Columns.Add( new DataColumn("flagvisiblekind", typeof(byte)));
	tlistclassyearview.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("fincodemotive", typeof(string)));
	tlistclassyearview.Columns.Add( new DataColumn("finmotive", typeof(string)));
	Tables.Add(tlistclassyearview);
	tlistclassyearview.PrimaryKey =  new DataColumn[]{tlistclassyearview.Columns["idlistclass"], tlistclassyearview.Columns["ayear"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{intrastatmeasure.Columns["idintrastatmeasure"]};
	var cChild = new []{intrastatcode.Columns["idintrastatmeasure"]};
	Relations.Add(new DataRelation("intrastatmeasure_intrastatcode",cPar,cChild,false));

	cPar = new []{listclass.Columns["idlistclass"]};
	cChild = new []{listclassyear.Columns["idlistclass"]};
	Relations.Add(new DataRelation("listclass_listclassyear",cPar,cChild,false));

	cPar = new []{intrastatservice.Columns["idintrastatservice"]};
	cChild = new []{listclassyear.Columns["idintrastatservice"]};
	Relations.Add(new DataRelation("intrastatservice_listclassyear",cPar,cChild,false));

	cPar = new []{intrastatcode.Columns["idintrastatcode"]};
	cChild = new []{listclassyear.Columns["idintrastatcode"]};
	Relations.Add(new DataRelation("intrastatcode_listclassyear",cPar,cChild,false));

	cPar = new []{accmotiveapplied.Columns["idaccmotive"]};
	cChild = new []{listclass.Columns["idaccmotive"]};
	Relations.Add(new DataRelation("FK_accmotiveapplied_listclass",cPar,cChild,false));

	cPar = new []{listclass.Columns["idlistclass"]};
	cChild = new []{listclass.Columns["paridlistclass"]};
	Relations.Add(new DataRelation("FK_listclass_listclass",cPar,cChild,false));

	cPar = new []{inventorytreeview.Columns["idinv"]};
	cChild = new []{listclass.Columns["idinv"]};
	Relations.Add(new DataRelation("inventorytreeview_listclass",cPar,cChild,false));

	cPar = new []{intrastatsupplymethod.Columns["idintrastatsupplymethod"]};
	cChild = new []{listclass.Columns["idintrastatsupplymethod"]};
	Relations.Add(new DataRelation("intrastatsupplymethod_listclass",cPar,cChild,false));

	cPar = new []{finmotive.Columns["idfinmotive"]};
	cChild = new []{listclass.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("finmotive_listclass",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{listclass.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("accmotiveapplied_credit_listclass",cPar,cChild,false));

	#endregion

}
}
}
