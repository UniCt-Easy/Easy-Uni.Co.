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
namespace notable_importazione {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaCAttivi"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaCAttivi: DataSet {

	#region Table members declaration
	///<summary>
	///Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimate 		=> Tables["estimate"];

	///<summary>
	///Dettaglio contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatedetail 		=> Tables["estimatedetail"];

	///<summary>
	///Tipo di Contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable estimatekind 		=> Tables["estimatekind"];

	///<summary>
	///Responsabile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable manager 		=> Tables["manager"];

	///<summary>
	///Contabilizzazione contratto attivo
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable incomeestimate 		=> Tables["incomeestimate"];

	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	///<summary>
	///Sezione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable division 		=> Tables["division"];

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
public vistaCAttivi(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaCAttivi (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaCAttivi";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaCAttivi.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// ESTIMATE /////////////////////////////////
	var testimate= new DataTable("estimate");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("deliveryaddress", typeof(string)));
	testimate.Columns.Add( new DataColumn("deliveryexpiration", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("doc", typeof(string)));
	testimate.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	testimate.Columns.Add( new DataColumn("exchangerate", typeof(double)));
	testimate.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	C= new DataColumn("officiallyprinted", typeof(string));
	C.AllowDBNull=false;
	testimate.Columns.Add(C);
	testimate.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	testimate.Columns.Add( new DataColumn("registryreference", typeof(string)));
	testimate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	testimate.Columns.Add( new DataColumn("txt", typeof(string)));
	testimate.Columns.Add( new DataColumn("idman", typeof(int)));
	testimate.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	testimate.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	testimate.Columns.Add( new DataColumn("flagintracom", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit_crg", typeof(string)));
	testimate.Columns.Add( new DataColumn("idaccmotivecredit_datacrg", typeof(DateTime)));
	testimate.Columns.Add( new DataColumn("idsor_underwriter", typeof(int)));
	testimate.Columns.Add( new DataColumn("idunderwriting", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor01", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor02", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor03", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor04", typeof(int)));
	testimate.Columns.Add( new DataColumn("idsor05", typeof(int)));
	testimate.Columns.Add( new DataColumn("external_reference", typeof(string)));
	Tables.Add(testimate);
	testimate.PrimaryKey =  new DataColumn[]{testimate.Columns["idestimkind"], testimate.Columns["yestim"], testimate.Columns["nestim"]};


	//////////////////// ESTIMATEDETAIL /////////////////////////////////
	var testimatedetail= new DataTable("estimatedetail");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("rownum", typeof(int));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("annotations", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("detaildescription", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("discount", typeof(double)));
	testimatedetail.Columns.Add( new DataColumn("idupb", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	testimatedetail.Columns.Add(C);
	testimatedetail.Columns.Add( new DataColumn("ninvoiced", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("number", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("start", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("tax", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("taxable", typeof(decimal)));
	testimatedetail.Columns.Add( new DataColumn("taxrate", typeof(double)));
	testimatedetail.Columns.Add( new DataColumn("toinvoice", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idaccmotive", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idreg", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idgroup", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("competencystart", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("competencystop", typeof(DateTime)));
	testimatedetail.Columns.Add( new DataColumn("idinc_taxable", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idinc_iva", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idivakind", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor1", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor2", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor3", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idaccmotiveannulment", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("epkind", typeof(string)));
	testimatedetail.Columns.Add( new DataColumn("idlist", typeof(int)));
	testimatedetail.Columns.Add( new DataColumn("idsor_siope", typeof(int)));
	Tables.Add(testimatedetail);
	testimatedetail.PrimaryKey =  new DataColumn[]{testimatedetail.Columns["idestimkind"], testimatedetail.Columns["yestim"], testimatedetail.Columns["nestim"], testimatedetail.Columns["rownum"]};


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
	Tables.Add(testimatekind);
	testimatekind.PrimaryKey =  new DataColumn[]{testimatekind.Columns["idestimkind"]};


	//////////////////// MANAGER /////////////////////////////////
	var tmanager= new DataTable("manager");
	tmanager.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("email", typeof(string)));
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
	C= new DataColumn("idman", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tmanager.Columns.Add(C);
	tmanager.Columns.Add( new DataColumn("wantswarn", typeof(string)));
	tmanager.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tmanager.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tmanager.Columns.Add( new DataColumn("newidman", typeof(int)));
	tmanager.Columns.Add( new DataColumn("financeactive", typeof(string)));
	Tables.Add(tmanager);
	tmanager.PrimaryKey =  new DataColumn[]{tmanager.Columns["idman"]};


	//////////////////// INCOMEESTIMATE /////////////////////////////////
	var tincomeestimate= new DataTable("incomeestimate");
	C= new DataColumn("idestimkind", typeof(string));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("nestim", typeof(int));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("yestim", typeof(short));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("idinc", typeof(int));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	C= new DataColumn("movkind", typeof(short));
	C.AllowDBNull=false;
	tincomeestimate.Columns.Add(C);
	Tables.Add(tincomeestimate);
	tincomeestimate.PrimaryKey =  new DataColumn[]{tincomeestimate.Columns["idestimkind"], tincomeestimate.Columns["nestim"], tincomeestimate.Columns["yestim"], tincomeestimate.Columns["idinc"]};


	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idivataxablekind", typeof(int)));
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	tivakind.Columns.Add( new DataColumn("flag", typeof(int)));
	tivakind.Columns.Add( new DataColumn("annotations", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idfenature", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// DIVISION /////////////////////////////////
	var tdivision= new DataTable("division");
	tdivision.Columns.Add( new DataColumn("address", typeof(string)));
	tdivision.Columns.Add( new DataColumn("cap", typeof(string)));
	tdivision.Columns.Add( new DataColumn("city", typeof(string)));
	tdivision.Columns.Add( new DataColumn("country", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	tdivision.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	tdivision.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	tdivision.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tdivision.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("codedivision", typeof(string));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	C= new DataColumn("iddivision", typeof(int));
	C.AllowDBNull=false;
	tdivision.Columns.Add(C);
	Tables.Add(tdivision);
	tdivision.PrimaryKey =  new DataColumn[]{tdivision.Columns["iddivision"]};


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
	tsorting.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tsorting.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["yestim"], estimate.Columns["nestim"]};
	var cChild = new []{incomeestimate.Columns["idestimkind"], incomeestimate.Columns["yestim"], incomeestimate.Columns["nestim"]};
	Relations.Add(new DataRelation("estimate_incomeestimate",cPar,cChild,false));

	cPar = new []{division.Columns["iddivision"]};
	cChild = new []{manager.Columns["iddivision"]};
	Relations.Add(new DataRelation("division_manager",cPar,cChild,false));

	cPar = new []{ivakind.Columns["idivakind"]};
	cChild = new []{estimatedetail.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakind_estimatedetail",cPar,cChild,false));

	cPar = new []{estimate.Columns["idestimkind"], estimate.Columns["yestim"], estimate.Columns["nestim"]};
	cChild = new []{estimatedetail.Columns["idestimkind"], estimatedetail.Columns["yestim"], estimatedetail.Columns["nestim"]};
	Relations.Add(new DataRelation("FK_estimatedetail_estimate",cPar,cChild,false));

	cPar = new []{estimatekind.Columns["idestimkind"]};
	cChild = new []{estimate.Columns["idestimkind"]};
	Relations.Add(new DataRelation("FK_estimate_estimatekind",cPar,cChild,false));

	cPar = new []{manager.Columns["idman"]};
	cChild = new []{estimate.Columns["idman"]};
	Relations.Add(new DataRelation("manager_estimate",cPar,cChild,false));

	#endregion

}
}
}
