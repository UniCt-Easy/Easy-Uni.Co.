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
namespace flowchart_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchart 		=> Tables["flowchart"];

	///<summary>
	///Livelli dell'organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartlevel 		=> Tables["flowchartlevel"];

	///<summary>
	///Classificazione Organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartsorting 		=> Tables["flowchartsorting"];

	///<summary>
	///U.P.B. - Organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartupb 		=> Tables["flowchartupb"];

	///<summary>
	///Bilancio - Organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartfin 		=> Tables["flowchartfin"];

	///<summary>
	///Associazione organigramma - responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartmanager 		=> Tables["flowchartmanager"];

	///<summary>
	///Associazione Utente - Organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartuser 		=> Tables["flowchartuser"];

	///<summary>
	///Restrizioni associate alla voce di organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartrestrictedfunction 		=> Tables["flowchartrestrictedfunction"];

	///<summary>
	///Bilancio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fin 		=> Tables["fin"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Operatività
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable restrictedfunction 		=> Tables["restrictedfunction"];

	///<summary>
	///Utenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable customuser 		=> Tables["customuser"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

	///<summary>
	///Associazione organigramma - modulo stampe
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartmodulegroup 		=> Tables["flowchartmodulegroup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table 		=> Tables["no_table"];

	///<summary>
	///Associazione organigramma - modulo esportazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartexportmodule 		=> Tables["flowchartexportmodule"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable no_table1 		=> Tables["no_table1"];

	///<summary>
	///Associazione organigramma - tipo contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartestimatekind 		=> Tables["flowchartestimatekind"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

	///<summary>
	///Associazione organigramma - tipo fattura
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartinvoicekind 		=> Tables["flowchartinvoicekind"];

	///<summary>
	///Associazione organigramma - tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartmandatekind 		=> Tables["flowchartmandatekind"];

	///<summary>
	///Associazione organigramma - fondo piccole spese
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartpettycash 		=> Tables["flowchartpettycash"];

	///<summary>
	///Fondo economale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycash 		=> Tables["pettycash"];

	///<summary>
	///Tipo di documento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable invoicekind 		=> Tables["invoicekind"];

	///<summary>
	///Tipo contratto passivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable mandatekind 		=> Tables["mandatekind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting3 		=> Tables["sorting3"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting2 		=> Tables["sorting2"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting1 		=> Tables["sorting1"];

	///<summary>
	///Associazione organigramma - agente autorizzativo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartauthagency 		=> Tables["flowchartauthagency"];

	///<summary>
	///Agenti Autorizzativi, sono utilizzati in congiunzione ai modelli autorizzativi
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable authagency 		=> Tables["authagency"];

	///<summary>
	///Associazione organigramma - modello autorizzativo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartauthmodel 		=> Tables["flowchartauthmodel"];

	///<summary>
	///Usato nelle missioni
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable authmodel 		=> Tables["authmodel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting01 		=> Tables["sorting01"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting02 		=> Tables["sorting02"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting03 		=> Tables["sorting03"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting04 		=> Tables["sorting04"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting05 		=> Tables["sorting05"];

	///<summary>
	///Classificazione di organigramma
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable flowchartusersorting 		=> Tables["flowchartusersorting"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

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
	//////////////////// FLOWCHART /////////////////////////////////
	var tflowchart= new DataTable("flowchart");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("paridflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("codeflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	tflowchart.Columns.Add( new DataColumn("ayear", typeof(int)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(int));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	tflowchart.Columns.Add( new DataColumn("fax", typeof(string)));
	tflowchart.Columns.Add( new DataColumn("phone", typeof(string)));
	tflowchart.Columns.Add( new DataColumn("address", typeof(string)));
	tflowchart.Columns.Add( new DataColumn("idcity", typeof(int)));
	tflowchart.Columns.Add( new DataColumn("cap", typeof(string)));
	tflowchart.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchart.Columns.Add(C);
	tflowchart.Columns.Add( new DataColumn("idsor1", typeof(int)));
	tflowchart.Columns.Add( new DataColumn("idsor2", typeof(int)));
	tflowchart.Columns.Add( new DataColumn("idsor3", typeof(int)));
	Tables.Add(tflowchart);
	tflowchart.PrimaryKey =  new DataColumn[]{tflowchart.Columns["idflowchart"]};


	//////////////////// FLOWCHARTLEVEL /////////////////////////////////
	var tflowchartlevel= new DataTable("flowchartlevel");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(int));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartlevel.Columns.Add(C);
	Tables.Add(tflowchartlevel);
	tflowchartlevel.PrimaryKey =  new DataColumn[]{tflowchartlevel.Columns["ayear"], tflowchartlevel.Columns["nlevel"]};


	//////////////////// FLOWCHARTSORTING /////////////////////////////////
	var tflowchartsorting= new DataTable("flowchartsorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tflowchartsorting.Columns.Add(C);
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartsorting.Columns.Add(C);
	tflowchartsorting.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartsorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartsorting.Columns.Add(C);
	tflowchartsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tflowchartsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tflowchartsorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	Tables.Add(tflowchartsorting);
	tflowchartsorting.PrimaryKey =  new DataColumn[]{tflowchartsorting.Columns["idflowchart"], tflowchartsorting.Columns["idsor"]};


	//////////////////// FLOWCHARTUPB /////////////////////////////////
	var tflowchartupb= new DataTable("flowchartupb");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartupb.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tflowchartupb.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartupb.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartupb.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartupb.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartupb.Columns.Add(C);
	tflowchartupb.Columns.Add( new DataColumn("!codiceupb", typeof(string)));
	tflowchartupb.Columns.Add( new DataColumn("!upb", typeof(string)));
	Tables.Add(tflowchartupb);
	tflowchartupb.PrimaryKey =  new DataColumn[]{tflowchartupb.Columns["idflowchart"], tflowchartupb.Columns["idupb"]};


	//////////////////// FLOWCHARTFIN /////////////////////////////////
	var tflowchartfin= new DataTable("flowchartfin");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartfin.Columns.Add(C);
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tflowchartfin.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartfin.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartfin.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartfin.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartfin.Columns.Add(C);
	tflowchartfin.Columns.Add( new DataColumn("!codicefin", typeof(string)));
	tflowchartfin.Columns.Add( new DataColumn("!fin", typeof(string)));
	Tables.Add(tflowchartfin);
	tflowchartfin.PrimaryKey =  new DataColumn[]{tflowchartfin.Columns["idflowchart"], tflowchartfin.Columns["idfin"]};


	//////////////////// FLOWCHARTMANAGER /////////////////////////////////
	var tflowchartmanager= new DataTable("flowchartmanager");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartmanager.Columns.Add(C);
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tflowchartmanager.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartmanager.Columns.Add(C);
	Tables.Add(tflowchartmanager);
	tflowchartmanager.PrimaryKey =  new DataColumn[]{tflowchartmanager.Columns["idflowchart"], tflowchartmanager.Columns["idman"]};


	//////////////////// FLOWCHARTUSER /////////////////////////////////
	var tflowchartuser= new DataTable("flowchartuser");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	C= new DataColumn("idcustomuser", typeof(string));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	tflowchartuser.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tflowchartuser.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartuser.Columns.Add(C);
	tflowchartuser.Columns.Add( new DataColumn("!username", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("flagdefault", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tflowchartuser.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tflowchartuser.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tflowchartuser.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tflowchartuser.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tflowchartuser.Columns.Add( new DataColumn("title", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("all_sorkind01", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("all_sorkind02", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("all_sorkind03", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("all_sorkind04", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("all_sorkind05", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("sorkind01_withchilds", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("sorkind02_withchilds", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("sorkind03_withchilds", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("sorkind04_withchilds", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("sorkind05_withchilds", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("!sorting01", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("!sorting02", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("!sorting03", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("!sorting04", typeof(string)));
	tflowchartuser.Columns.Add( new DataColumn("!sorting05", typeof(string)));
	Tables.Add(tflowchartuser);
	tflowchartuser.PrimaryKey =  new DataColumn[]{tflowchartuser.Columns["idflowchart"], tflowchartuser.Columns["ndetail"], tflowchartuser.Columns["idcustomuser"]};


	//////////////////// FLOWCHARTRESTRICTEDFUNCTION /////////////////////////////////
	var tflowchartrestrictedfunction= new DataTable("flowchartrestrictedfunction");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartrestrictedfunction.Columns.Add(C);
	C= new DataColumn("idrestrictedfunction", typeof(int));
	C.AllowDBNull=false;
	tflowchartrestrictedfunction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartrestrictedfunction.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartrestrictedfunction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartrestrictedfunction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartrestrictedfunction.Columns.Add(C);
	Tables.Add(tflowchartrestrictedfunction);
	tflowchartrestrictedfunction.PrimaryKey =  new DataColumn[]{tflowchartrestrictedfunction.Columns["idflowchart"], tflowchartrestrictedfunction.Columns["idrestrictedfunction"]};


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
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("paridfin", typeof(int)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfin.Columns.Add(C);
	tfin.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tfin);
	tfin.PrimaryKey =  new DataColumn[]{tfin.Columns["idfin"]};


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
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("passwordweb", typeof(string)));
	tmanager.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmanager.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("txt", typeof(string)));
	tmanager.Columns.Add( new DataColumn("userweb", typeof(string)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// RESTRICTEDFUNCTION /////////////////////////////////
	var trestrictedfunction= new DataTable("restrictedfunction");
	C= new DataColumn("idrestrictedfunction", typeof(int));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	C= new DataColumn("variablename", typeof(string));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	trestrictedfunction.Columns.Add(C);
	Tables.Add(trestrictedfunction);
	trestrictedfunction.PrimaryKey =  new DataColumn[]{trestrictedfunction.Columns["idrestrictedfunction"]};


	//////////////////// CUSTOMUSER /////////////////////////////////
	var tcustomuser= new DataTable("customuser");
	C= new DataColumn("idcustomuser", typeof(string));
	C.AllowDBNull=false;
	tcustomuser.Columns.Add(C);
	tcustomuser.Columns.Add( new DataColumn("lastmodtimestamp", typeof(DateTime)));
	tcustomuser.Columns.Add( new DataColumn("lastmoduser", typeof(string)));
	C= new DataColumn("username", typeof(string));
	C.AllowDBNull=false;
	tcustomuser.Columns.Add(C);
	tcustomuser.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tcustomuser.Columns.Add( new DataColumn("cu", typeof(string)));
	tcustomuser.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcustomuser.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tcustomuser);
	tcustomuser.PrimaryKey =  new DataColumn[]{tcustomuser.Columns["idcustomuser"]};


	//////////////////// GEO_CITYVIEW /////////////////////////////////
	var tgeo_cityview= new DataTable("geo_cityview");
	C= new DataColumn("idcity", typeof(int));
	C.AllowDBNull=false;
	tgeo_cityview.Columns.Add(C);
	tgeo_cityview.Columns.Add( new DataColumn("title", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcity", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("country", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("oldcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newcountry", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("countrydatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("idregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("region", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("regiondatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newregion", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("idcontinent", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("nation", typeof(string)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestart", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("nationdatestop", typeof(DateTime)));
	tgeo_cityview.Columns.Add( new DataColumn("oldnation", typeof(int)));
	tgeo_cityview.Columns.Add( new DataColumn("newnation", typeof(int)));
	Tables.Add(tgeo_cityview);

	//////////////////// FLOWCHARTMODULEGROUP /////////////////////////////////
	var tflowchartmodulegroup= new DataTable("flowchartmodulegroup");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartmodulegroup.Columns.Add(C);
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	tflowchartmodulegroup.Columns.Add(C);
	C= new DataColumn("groupname", typeof(string));
	C.AllowDBNull=false;
	tflowchartmodulegroup.Columns.Add(C);
	tflowchartmodulegroup.Columns.Add( new DataColumn("lu", typeof(string)));
	tflowchartmodulegroup.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tflowchartmodulegroup);
	tflowchartmodulegroup.PrimaryKey =  new DataColumn[]{tflowchartmodulegroup.Columns["idflowchart"], tflowchartmodulegroup.Columns["modulename"], tflowchartmodulegroup.Columns["groupname"]};


	//////////////////// NO_TABLE /////////////////////////////////
	var tno_table= new DataTable("no_table");
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	C= new DataColumn("groupname", typeof(string));
	C.AllowDBNull=false;
	tno_table.Columns.Add(C);
	Tables.Add(tno_table);
	tno_table.PrimaryKey =  new DataColumn[]{tno_table.Columns["modulename"], tno_table.Columns["groupname"]};


	//////////////////// FLOWCHARTEXPORTMODULE /////////////////////////////////
	var tflowchartexportmodule= new DataTable("flowchartexportmodule");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartexportmodule.Columns.Add(C);
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	tflowchartexportmodule.Columns.Add(C);
	tflowchartexportmodule.Columns.Add( new DataColumn("lu", typeof(string)));
	tflowchartexportmodule.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tflowchartexportmodule);
	tflowchartexportmodule.PrimaryKey =  new DataColumn[]{tflowchartexportmodule.Columns["idflowchart"], tflowchartexportmodule.Columns["modulename"]};


	//////////////////// NO_TABLE1 /////////////////////////////////
	var tno_table1= new DataTable("no_table1");
	C= new DataColumn("modulename", typeof(string));
	C.AllowDBNull=false;
	tno_table1.Columns.Add(C);
	Tables.Add(tno_table1);
	tno_table1.PrimaryKey =  new DataColumn[]{tno_table1.Columns["modulename"]};


	//////////////////// FLOWCHARTESTIMATEKIND /////////////////////////////////
	var tflowchartestimatekind= new DataTable("flowchartestimatekind");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartestimatekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartestimatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartestimatekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartestimatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartestimatekind.Columns.Add(C);
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	tflowchartestimatekind.Columns.Add(C);
	Tables.Add(tflowchartestimatekind);
	tflowchartestimatekind.PrimaryKey =  new DataColumn[]{tflowchartestimatekind.Columns["idflowchart"], tflowchartestimatekind.Columns["idestimkind"]};


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
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	//////////////////// FLOWCHARTINVOICEKIND /////////////////////////////////
	var tflowchartinvoicekind= new DataTable("flowchartinvoicekind");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartinvoicekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartinvoicekind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tflowchartinvoicekind.Columns.Add(C);
	Tables.Add(tflowchartinvoicekind);
	tflowchartinvoicekind.PrimaryKey =  new DataColumn[]{tflowchartinvoicekind.Columns["idflowchart"], tflowchartinvoicekind.Columns["idinvkind"]};


	//////////////////// FLOWCHARTMANDATEKIND /////////////////////////////////
	var tflowchartmandatekind= new DataTable("flowchartmandatekind");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartmandatekind.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartmandatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartmandatekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartmandatekind.Columns.Add(C);
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tflowchartmandatekind.Columns.Add(C);
	Tables.Add(tflowchartmandatekind);
	tflowchartmandatekind.PrimaryKey =  new DataColumn[]{tflowchartmandatekind.Columns["idflowchart"], tflowchartmandatekind.Columns["idmankind"]};


	//////////////////// FLOWCHARTPETTYCASH /////////////////////////////////
	var tflowchartpettycash= new DataTable("flowchartpettycash");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartpettycash.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartpettycash.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartpettycash.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartpettycash.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartpettycash.Columns.Add(C);
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tflowchartpettycash.Columns.Add(C);
	Tables.Add(tflowchartpettycash);
	tflowchartpettycash.PrimaryKey =  new DataColumn[]{tflowchartpettycash.Columns["idflowchart"], tflowchartpettycash.Columns["idpettycash"]};


	//////////////////// PETTYCASH /////////////////////////////////
	var tpettycash= new DataTable("pettycash");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("pettycode", typeof(string)));
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	Tables.Add(tpettycash);
	tpettycash.PrimaryKey =  new DataColumn[]{tpettycash.Columns["idpettycash"]};


	//////////////////// INVOICEKIND /////////////////////////////////
	var tinvoicekind= new DataTable("invoicekind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("codeinvkind", typeof(string));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("idinvkind", typeof(int));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tinvoicekind.Columns.Add(C);
	tinvoicekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tinvoicekind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(tinvoicekind);
	tinvoicekind.PrimaryKey =  new DataColumn[]{tinvoicekind.Columns["idinvkind"]};


	//////////////////// MANDATEKIND /////////////////////////////////
	var tmandatekind= new DataTable("mandatekind");
	C= new DataColumn("idmankind", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tmandatekind.Columns.Add(C);
	tmandatekind.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tmandatekind.Columns.Add( new DataColumn("txt", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("email", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("office", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoasset", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("linktoinvoice", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("multireg", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("deltaamount", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("deltapercentage", typeof(decimal)));
	tmandatekind.Columns.Add( new DataColumn("flag_autodocnumbering", typeof(string)));
	tmandatekind.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	Tables.Add(tmandatekind);
	tmandatekind.PrimaryKey =  new DataColumn[]{tmandatekind.Columns["idmankind"]};


	//////////////////// SORTING3 /////////////////////////////////
	var tsorting3= new DataTable("sorting3");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting3.Columns.Add(C);
	tsorting3.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting3.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting3.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting3);
	tsorting3.PrimaryKey =  new DataColumn[]{tsorting3.Columns["idsor"]};


	//////////////////// SORTING2 /////////////////////////////////
	var tsorting2= new DataTable("sorting2");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting2.Columns.Add(C);
	tsorting2.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting2.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting2.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting2);
	tsorting2.PrimaryKey =  new DataColumn[]{tsorting2.Columns["idsor"]};


	//////////////////// SORTING1 /////////////////////////////////
	var tsorting1= new DataTable("sorting1");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("txt", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting1.Columns.Add(C);
	tsorting1.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting1.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting1.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	Tables.Add(tsorting1);
	tsorting1.PrimaryKey =  new DataColumn[]{tsorting1.Columns["idsor"]};


	//////////////////// FLOWCHARTAUTHAGENCY /////////////////////////////////
	var tflowchartauthagency= new DataTable("flowchartauthagency");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartauthagency.Columns.Add(C);
	C= new DataColumn("idauthagency", typeof(int));
	C.AllowDBNull=false;
	tflowchartauthagency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartauthagency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartauthagency.Columns.Add(C);
	Tables.Add(tflowchartauthagency);
	tflowchartauthagency.PrimaryKey =  new DataColumn[]{tflowchartauthagency.Columns["idflowchart"], tflowchartauthagency.Columns["idauthagency"]};


	//////////////////// AUTHAGENCY /////////////////////////////////
	var tauthagency= new DataTable("authagency");
	C= new DataColumn("idauthagency", typeof(int));
	C.AllowDBNull=false;
	tauthagency.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tauthagency.Columns.Add(C);
	tauthagency.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("ismanager", typeof(string));
	C.AllowDBNull=false;
	tauthagency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tauthagency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tauthagency.Columns.Add(C);
	C= new DataColumn("priority", typeof(int));
	C.AllowDBNull=false;
	tauthagency.Columns.Add(C);
	Tables.Add(tauthagency);
	tauthagency.PrimaryKey =  new DataColumn[]{tauthagency.Columns["idauthagency"]};


	//////////////////// FLOWCHARTAUTHMODEL /////////////////////////////////
	var tflowchartauthmodel= new DataTable("flowchartauthmodel");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartauthmodel.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartauthmodel.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartauthmodel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartauthmodel.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartauthmodel.Columns.Add(C);
	C= new DataColumn("idauthmodel", typeof(int));
	C.AllowDBNull=false;
	tflowchartauthmodel.Columns.Add(C);
	Tables.Add(tflowchartauthmodel);
	tflowchartauthmodel.PrimaryKey =  new DataColumn[]{tflowchartauthmodel.Columns["idflowchart"], tflowchartauthmodel.Columns["idauthmodel"]};


	//////////////////// AUTHMODEL /////////////////////////////////
	var tauthmodel= new DataTable("authmodel");
	C= new DataColumn("idauthmodel", typeof(int));
	C.AllowDBNull=false;
	tauthmodel.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tauthmodel.Columns.Add(C);
	tauthmodel.Columns.Add( new DataColumn("description", typeof(string)));
	tauthmodel.Columns.Add( new DataColumn("maxamount", typeof(decimal)));
	tauthmodel.Columns.Add( new DataColumn("maxlen", typeof(int)));
	C= new DataColumn("authfinrequired", typeof(string));
	C.AllowDBNull=false;
	tauthmodel.Columns.Add(C);
	tauthmodel.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tauthmodel.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tauthmodel.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tauthmodel.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tauthmodel.Columns.Add( new DataColumn("idsor05", typeof(int)));
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tauthmodel.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tauthmodel.Columns.Add(C);
	Tables.Add(tauthmodel);
	tauthmodel.PrimaryKey =  new DataColumn[]{tauthmodel.Columns["idauthmodel"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingview.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	//////////////////// FLOWCHARTUSERSORTING /////////////////////////////////
	var tflowchartusersorting= new DataTable("flowchartusersorting");
	C= new DataColumn("idflowchart", typeof(string));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	C= new DataColumn("ndetail", typeof(int));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	C= new DataColumn("idcustomuser", typeof(string));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	tflowchartusersorting.Columns.Add( new DataColumn("quota", typeof(double)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tflowchartusersorting.Columns.Add(C);
	Tables.Add(tflowchartusersorting);
	tflowchartusersorting.PrimaryKey =  new DataColumn[]{tflowchartusersorting.Columns["idflowchart"], tflowchartusersorting.Columns["ndetail"], tflowchartusersorting.Columns["idcustomuser"], tflowchartusersorting.Columns["idsor"]};


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


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{flowchartusersorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sorting_flowchartusersorting",cPar,cChild,false));

	cPar = new []{flowchartuser.Columns["idflowchart"], flowchartuser.Columns["ndetail"], flowchartuser.Columns["idcustomuser"]};
	cChild = new []{flowchartusersorting.Columns["idflowchart"], flowchartusersorting.Columns["ndetail"], flowchartusersorting.Columns["idcustomuser"]};
	Relations.Add(new DataRelation("FK_flowchartuser_flowchartusersorting",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartauthmodel.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartauthmodel",cPar,cChild,false));

	cPar = new []{authmodel.Columns["idauthmodel"]};
	cChild = new []{flowchartauthmodel.Columns["idauthmodel"]};
	Relations.Add(new DataRelation("authmodel_flowchartauthmodel",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartauthagency.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartauthagency",cPar,cChild,false));

	cPar = new []{authagency.Columns["idauthagency"]};
	cChild = new []{flowchartauthagency.Columns["idauthagency"]};
	Relations.Add(new DataRelation("authagency_flowchartauthagency",cPar,cChild,false));

	cPar = new []{pettycash.Columns["idpettycash"]};
	cChild = new []{flowchartpettycash.Columns["idpettycash"]};
	Relations.Add(new DataRelation("FK_pettycash_flowchartpettycash",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartpettycash.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchartpettycash",cPar,cChild,false));

	cPar = new []{mandatekind.Columns["idmankind"]};
	cChild = new []{flowchartmandatekind.Columns["idmankind"]};
	Relations.Add(new DataRelation("FK_mandatekind_flowchartmandatekind",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartmandatekind.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchartmandatekind",cPar,cChild,false));

	cPar = new []{invoicekind.Columns["idinvkind"]};
	cChild = new []{flowchartinvoicekind.Columns["idinvkind"]};
	Relations.Add(new DataRelation("FK_invoicekind_flowchartinvoicekind",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartinvoicekind.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchartinvoicekind",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{flowchartestimatekind.Columns["idestimkind"]};
	Relations.Add(new DataRelation("FK_estimatekind_flowchartestimatekind",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartestimatekind.Columns["idflowchart"]};
	Relations.Add(new DataRelation("FK_flowchart_flowchartestimatekind",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartexportmodule.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartexportmodule",cPar,cChild,false));

	cPar = new []{no_table1.Columns["modulename"]};
	cChild = new []{flowchartexportmodule.Columns["modulename"]};
	Relations.Add(new DataRelation("no_table1_flowchartexportmodule",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartmodulegroup.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartmodulegroup",cPar,cChild,false));

	cPar = new []{no_table.Columns["modulename"], no_table.Columns["groupname"]};
	cChild = new []{flowchartmodulegroup.Columns["modulename"], flowchartmodulegroup.Columns["groupname"]};
	Relations.Add(new DataRelation("no_table_flowchartmodulegroup",cPar,cChild,false));

	cPar = new []{restrictedfunction.Columns["idrestrictedfunction"]};
	cChild = new []{flowchartrestrictedfunction.Columns["idrestrictedfunction"]};
	Relations.Add(new DataRelation("restrictedfunction_flowchartrestrictedfunction",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartrestrictedfunction.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartrestrictedfunction",cPar,cChild,false));

	cPar = new []{customuser.Columns["idcustomuser"]};
	cChild = new []{flowchartuser.Columns["idcustomuser"]};
	Relations.Add(new DataRelation("customuser_flowchartuser",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartuser.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartuser",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{flowchartuser.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_flowchartuser",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{flowchartuser.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_flowchartuser",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{flowchartuser.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_flowchartuser",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{flowchartuser.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_flowchartuser",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{flowchartuser.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_flowchartuser",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartmanager.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartmanager",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{flowchartmanager.Columns["idman"]};
	Relations.Add(new DataRelation("manager_flowchartmanager",cPar,cChild,false));

	cPar = new []{fin.Columns["idfin"]};
	cChild = new []{flowchartfin.Columns["idfin"]};
	Relations.Add(new DataRelation("fin_flowchartfin",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartfin.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartfin",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{flowchartupb.Columns["idupb"]};
	Relations.Add(new DataRelation("upb_flowchartupb",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartupb.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartupb",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{flowchartsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("FK_sortingview_flowchartsorting",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchartsorting.Columns["idflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchartsorting",cPar,cChild,false));

	cPar = new []{flowchartlevel.Columns["ayear"], flowchartlevel.Columns["nlevel"]};
	cChild = new []{flowchart.Columns["ayear"], flowchart.Columns["nlevel"]};
	Relations.Add(new DataRelation("flowchartlevel_flowchart",cPar,cChild,false));

	cPar = new []{flowchart.Columns["idflowchart"]};
	cChild = new []{flowchart.Columns["paridflowchart"]};
	Relations.Add(new DataRelation("flowchart_flowchart",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{flowchart.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityview_flowchart",cPar,cChild,false));

	cPar = new []{sorting1.Columns["idsor"]};
	cChild = new []{flowchart.Columns["idsor1"]};
	Relations.Add(new DataRelation("sorting1_flowchart",cPar,cChild,false));

	cPar = new []{sorting2.Columns["idsor"]};
	cChild = new []{flowchart.Columns["idsor2"]};
	Relations.Add(new DataRelation("sorting2_flowchart",cPar,cChild,false));

	cPar = new []{sorting3.Columns["idsor"]};
	cChild = new []{flowchart.Columns["idsor3"]};
	Relations.Add(new DataRelation("sorting3_flowchart",cPar,cChild,false));

	#endregion

}
}
}
