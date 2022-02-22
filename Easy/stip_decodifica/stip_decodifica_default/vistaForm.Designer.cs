
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
namespace stip_decodifica_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///elenco voci prog. esterno segr. studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_voce 		=> Tables["stip_voce"];

	///<summary>
	///elenco tasse  prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_tassa 		=> Tables["stip_tassa"];

	///<summary>
	///decodifica vocie e tasse prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_decodifica 		=> Tables["stip_decodifica"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_credit 		=> Tables["accmotiveapplied_credit"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_revenue 		=> Tables["accmotiveapplied_revenue"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_undotax 		=> Tables["accmotiveapplied_undotax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotiveapplied_undotaxpost 		=> Tables["accmotiveapplied_undotaxpost"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finmotive_income 		=> Tables["finmotive_income"];

	///<summary>
	///elenco corsi laurea prog. esterno gestione studenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable stip_corsolaurea 		=> Tables["stip_corsolaurea"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

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
	//////////////////// STIP_VOCE /////////////////////////////////
	var tstip_voce= new DataTable("stip_voce");
	C= new DataColumn("idstipvoce", typeof(int));
	C.AllowDBNull=false;
	tstip_voce.Columns.Add(C);
	tstip_voce.Columns.Add( new DataColumn("codicevoce", typeof(string)));
	tstip_voce.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_voce.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_voce.Columns.Add(C);
	tstip_voce.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_voce.Columns.Add(C);
	Tables.Add(tstip_voce);
	tstip_voce.PrimaryKey =  new DataColumn[]{tstip_voce.Columns["idstipvoce"]};


	//////////////////// STIP_TASSA /////////////////////////////////
	var tstip_tassa= new DataTable("stip_tassa");
	C= new DataColumn("idstiptassa", typeof(int));
	C.AllowDBNull=false;
	tstip_tassa.Columns.Add(C);
	tstip_tassa.Columns.Add( new DataColumn("codicetassa", typeof(string)));
	tstip_tassa.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_tassa.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_tassa.Columns.Add(C);
	tstip_tassa.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_tassa.Columns.Add(C);
	Tables.Add(tstip_tassa);
	tstip_tassa.PrimaryKey =  new DataColumn[]{tstip_tassa.Columns["idstiptassa"]};


	//////////////////// STIP_DECODIFICA /////////////////////////////////
	var tstip_decodifica= new DataTable("stip_decodifica");
	C= new DataColumn("idstipdecodifica", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	C= new DataColumn("idstiptassa", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	C= new DataColumn("idstipvoce", typeof(int));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("idstipcorsolaurea", typeof(int)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiverevenue", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idfinmotive", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiveundotax", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("idaccmotiveundotaxpost", typeof(string)));
	tstip_decodifica.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_decodifica.Columns.Add(C);
	tstip_decodifica.Columns.Add( new DataColumn("idestimkind", typeof(string)));
	Tables.Add(tstip_decodifica);
	tstip_decodifica.PrimaryKey =  new DataColumn[]{tstip_decodifica.Columns["idstipdecodifica"]};


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


	//////////////////// ACCMOTIVEAPPLIED_REVENUE /////////////////////////////////
	var taccmotiveapplied_revenue= new DataTable("accmotiveapplied_revenue");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_revenue.Columns.Add(C);
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_revenue.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotiveapplied_revenue);
	taccmotiveapplied_revenue.PrimaryKey =  new DataColumn[]{taccmotiveapplied_revenue.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_UNDOTAX /////////////////////////////////
	var taccmotiveapplied_undotax= new DataTable("accmotiveapplied_undotax");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotax.Columns.Add(C);
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_undotax.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotiveapplied_undotax);
	taccmotiveapplied_undotax.PrimaryKey =  new DataColumn[]{taccmotiveapplied_undotax.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVEAPPLIED_UNDOTAXPOST /////////////////////////////////
	var taccmotiveapplied_undotaxpost= new DataTable("accmotiveapplied_undotaxpost");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	C= new DataColumn("motive", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("active", typeof(string)));
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("idepoperation", typeof(string)));
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("epoperation", typeof(string)));
	C= new DataColumn("in_use", typeof(string));
	C.AllowDBNull=false;
	taccmotiveapplied_undotaxpost.Columns.Add(C);
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("flagamm", typeof(string)));
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("flagdep", typeof(string)));
	taccmotiveapplied_undotaxpost.Columns.Add( new DataColumn("expensekind", typeof(string)));
	Tables.Add(taccmotiveapplied_undotaxpost);
	taccmotiveapplied_undotaxpost.PrimaryKey =  new DataColumn[]{taccmotiveapplied_undotaxpost.Columns["idaccmotive"]};


	//////////////////// FINMOTIVE_INCOME /////////////////////////////////
	var tfinmotive_income= new DataTable("finmotive_income");
	C= new DataColumn("idfinmotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	tfinmotive_income.Columns.Add( new DataColumn("paridfinmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinmotive_income.Columns.Add(C);
	tfinmotive_income.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tfinmotive_income.Columns.Add( new DataColumn("lu", typeof(string)));
	tfinmotive_income.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tfinmotive_income.Columns.Add( new DataColumn("cu", typeof(string)));
	Tables.Add(tfinmotive_income);
	tfinmotive_income.PrimaryKey =  new DataColumn[]{tfinmotive_income.Columns["idfinmotive"]};


	//////////////////// STIP_CORSOLAUREA /////////////////////////////////
	var tstip_corsolaurea= new DataTable("stip_corsolaurea");
	C= new DataColumn("idstipcorsolaurea", typeof(int));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("codicecorsolaurea", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("descrizione", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idupb", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tstip_corsolaurea.Columns.Add(C);
	tstip_corsolaurea.Columns.Add( new DataColumn("anno", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("dipartimento", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("percorso", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("sede", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("codicedipartimento", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("codicepercorso", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("codicesede", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("descrizionecorsolaurea", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("codicecausale", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("causale", typeof(string)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idstiptassa", typeof(int)));
	tstip_corsolaurea.Columns.Add( new DataColumn("idstipvoce", typeof(int)));
	Tables.Add(tstip_corsolaurea);
	tstip_corsolaurea.PrimaryKey =  new DataColumn[]{tstip_corsolaurea.Columns["idstipcorsolaurea"]};


	//////////////////// ESTIMATEKIND /////////////////////////////////
	var testimatekind= new DataTable("estimatekind");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatekind.Columns.Add(C);
	testimatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("email", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("office", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	testimatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	testimatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("address", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("header", typeof(string)));
	testimatekind.Columns.Add( new DataColumn("idivakind_forced", typeof(int)));
	testimatekind.Columns.Add( new DataColumn("flag", typeof(int)));
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{stip_voce.Columns["idstipvoce"]};
	var cChild = new []{stip_decodifica.Columns["idstipvoce"]};
	Relations.Add(new DataRelation("stip_voce_stip_decodifica",cPar,cChild,false));

	cPar = new []{stip_tassa.Columns["idstiptassa"]};
	cChild = new []{stip_decodifica.Columns["idstiptassa"]};
	Relations.Add(new DataRelation("stip_tassa_stip_decodifica",cPar,cChild,false));

	cPar = new []{finmotive_income.Columns["idfinmotive"]};
	cChild = new []{stip_decodifica.Columns["idfinmotive"]};
	Relations.Add(new DataRelation("finmotive_stip_decodifica",cPar,cChild,false));

	cPar = new []{accmotiveapplied_credit.Columns["idaccmotive"]};
	cChild = new []{stip_decodifica.Columns["idaccmotivecredit"]};
	Relations.Add(new DataRelation("accmotiveapplied_credit_stip_decodifica",cPar,cChild,false));

	cPar = new []{accmotiveapplied_revenue.Columns["idaccmotive"]};
	cChild = new []{stip_decodifica.Columns["idaccmotiverevenue"]};
	Relations.Add(new DataRelation("accmotiveapplied_revenue_stip_decodifica",cPar,cChild,false));

	cPar = new []{accmotiveapplied_undotax.Columns["idaccmotive"]};
	cChild = new []{stip_decodifica.Columns["idaccmotiveundotax"]};
	Relations.Add(new DataRelation("accmotiveapplied_undotax_stip_decodifica",cPar,cChild,false));

	cPar = new []{accmotiveapplied_undotaxpost.Columns["idaccmotive"]};
	cChild = new []{stip_decodifica.Columns["idaccmotiveundotaxpost"]};
	Relations.Add(new DataRelation("accmotiveapplied_undotaxpost_stip_decodifica",cPar,cChild,false));

	cPar = new []{stip_corsolaurea.Columns["idstipcorsolaurea"]};
	cChild = new []{stip_decodifica.Columns["idstipcorsolaurea"]};
	Relations.Add(new DataRelation("stip_corsolaurea_stip_decodifica",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{stip_decodifica.Columns["idestimkind"]};
	Relations.Add(new DataRelation("estimatekind_stip_decodifica",cPar,cChild,false));

	#endregion

}
}
}
