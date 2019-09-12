/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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
namespace pettycashsetup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fondo economale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycash 		=> Tables["pettycash"];

	///<summary>
	///Configurazione fondo economale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable pettycashsetup 		=> Tables["pettycashsetup"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Livelli del bilancio annuale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finlevel 		=> Tables["finlevel"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bilanciospesa 		=> Tables["bilanciospesa"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bilancioentrata 		=> Tables["bilancioentrata"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable account 		=> Tables["account"];

	///<summary>
	///U.P.B.
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable upb 		=> Tables["upb"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siopeentrate 		=> Tables["sorting_siopeentrate"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting_siopespese 		=> Tables["sorting_siopespese"];

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
	//////////////////// PETTYCASH /////////////////////////////////
	var tpettycash= new DataTable("pettycash");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("pettycode", typeof(string)));
	tpettycash.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycash.Columns.Add(C);
	tpettycash.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tpettycash.Columns.Add( new DataColumn("idsor05", typeof(int)));
	Tables.Add(tpettycash);
	tpettycash.PrimaryKey =  new DataColumn[]{tpettycash.Columns["idpettycash"]};


	//////////////////// PETTYCASHSETUP /////////////////////////////////
	var tpettycashsetup= new DataTable("pettycashsetup");
	C= new DataColumn("idpettycash", typeof(int));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("registrymanager", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idfinincome", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idfinexpense", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpettycashsetup.Columns.Add(C);
	tpettycashsetup.Columns.Add( new DataColumn("autoclassify", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("idacc", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("flag", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idupb", typeof(string)));
	tpettycashsetup.Columns.Add( new DataColumn("idsor_siopeinc", typeof(int)));
	tpettycashsetup.Columns.Add( new DataColumn("idsor_siopeexp", typeof(int)));
	Tables.Add(tpettycashsetup);
	tpettycashsetup.PrimaryKey =  new DataColumn[]{tpettycashsetup.Columns["idpettycash"], tpettycashsetup.Columns["ayear"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


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


	//////////////////// BILANCIOSPESA /////////////////////////////////
	var tbilanciospesa= new DataTable("bilanciospesa");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	tbilanciospesa.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	tbilanciospesa.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tbilanciospesa.Columns.Add( new DataColumn("idman", typeof(int)));
	tbilanciospesa.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	tbilanciospesa.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tbilanciospesa.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tbilanciospesa.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbilanciospesa.Columns.Add(C);
	Tables.Add(tbilanciospesa);
	tbilanciospesa.PrimaryKey =  new DataColumn[]{tbilanciospesa.Columns["idfin"]};


	//////////////////// BILANCIOENTRATA /////////////////////////////////
	var tbilancioentrata= new DataTable("bilancioentrata");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	tbilancioentrata.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	tbilancioentrata.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tbilancioentrata.Columns.Add( new DataColumn("idman", typeof(int)));
	tbilancioentrata.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	tbilancioentrata.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tbilancioentrata.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	tbilancioentrata.Columns.Add( new DataColumn("flag", typeof(byte)));
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbilancioentrata.Columns.Add(C);
	Tables.Add(tbilancioentrata);
	tbilancioentrata.PrimaryKey =  new DataColumn[]{tbilancioentrata.Columns["idfin"]};


	//////////////////// ACCOUNT /////////////////////////////////
	var taccount= new DataTable("account");
	C= new DataColumn("idacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("codeacc", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("flagregistry", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagtransitory", typeof(string)));
	taccount.Columns.Add( new DataColumn("flagupb", typeof(string)));
	taccount.Columns.Add( new DataColumn("idaccountkind", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("paridacc", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccount.Columns.Add(C);
	taccount.Columns.Add( new DataColumn("txt", typeof(string)));
	taccount.Columns.Add( new DataColumn("idpatrimony", typeof(string)));
	taccount.Columns.Add( new DataColumn("idplaccount", typeof(string)));
	Tables.Add(taccount);
	taccount.PrimaryKey =  new DataColumn[]{taccount.Columns["idacc"]};


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
	tupb.Columns.Add( new DataColumn("idman", typeof(int)));
	tupb.Columns.Add( new DataColumn("idunderwriter", typeof(int)));
	tupb.Columns.Add( new DataColumn("cupcode", typeof(string)));
	tupb.Columns.Add( new DataColumn("idsor01", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor02", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor03", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor04", typeof(int)));
	tupb.Columns.Add( new DataColumn("idsor05", typeof(int)));
	tupb.Columns.Add( new DataColumn("flagactivity", typeof(short)));
	tupb.Columns.Add( new DataColumn("flagkind", typeof(byte)));
	tupb.Columns.Add( new DataColumn("newcodeupb", typeof(string)));
	Tables.Add(tupb);
	tupb.PrimaryKey =  new DataColumn[]{tupb.Columns["idupb"]};


	//////////////////// SORTING_SIOPEENTRATE /////////////////////////////////
	var tsorting_siopeentrate= new DataTable("sorting_siopeentrate");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	tsorting_siopeentrate.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	tsorting_siopeentrate.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	tsorting_siopeentrate.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	tsorting_siopeentrate.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siopeentrate.Columns.Add(C);
	tsorting_siopeentrate.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siopeentrate.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_siopeentrate);
	tsorting_siopeentrate.PrimaryKey =  new DataColumn[]{tsorting_siopeentrate.Columns["idsor"]};


	//////////////////// SORTING_SIOPESPESE /////////////////////////////////
	var tsorting_siopespese= new DataTable("sorting_siopespese");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	tsorting_siopespese.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting_siopespese.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	tsorting_siopespese.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	tsorting_siopespese.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting_siopespese.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	tsorting_siopespese.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	tsorting_siopespese.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting_siopespese.Columns.Add(C);
	tsorting_siopespese.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting_siopespese.Columns.Add( new DataColumn("stop", typeof(short)));
	tsorting_siopespese.Columns.Add( new DataColumn("email", typeof(string)));
	Tables.Add(tsorting_siopespese);
	tsorting_siopespese.PrimaryKey =  new DataColumn[]{tsorting_siopespese.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{finlevel.Columns["ayear"], finlevel.Columns["nlevel"]};
	var cChild = new []{bilancioentrata.Columns["ayear"], bilancioentrata.Columns["nlevel"]};
	Relations.Add(new DataRelation("finlevelbilancioentrata",cPar,cChild,false));

	cPar = new []{finlevel.Columns["ayear"], finlevel.Columns["nlevel"]};
	cChild = new []{bilanciospesa.Columns["ayear"], bilanciospesa.Columns["nlevel"]};
	Relations.Add(new DataRelation("finlevelbilanciospesa",cPar,cChild,false));

	cPar = new []{upb.Columns["idupb"]};
	cChild = new []{pettycashsetup.Columns["idupb"]};
	Relations.Add(new DataRelation("FK_upb_pettycashsetup",cPar,cChild,false));

	cPar = new []{bilancioentrata.Columns["idfin"]};
	cChild = new []{pettycashsetup.Columns["idfinincome"]};
	Relations.Add(new DataRelation("bilancioentratapettycashsetup",cPar,cChild,false));

	cPar = new []{bilanciospesa.Columns["idfin"]};
	cChild = new []{pettycashsetup.Columns["idfinexpense"]};
	Relations.Add(new DataRelation("bilanciospesapettycashsetup",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{pettycashsetup.Columns["registrymanager"]};
	Relations.Add(new DataRelation("registrypettycashsetup",cPar,cChild,false));

	cPar = new []{pettycash.Columns["idpettycash"]};
	cChild = new []{pettycashsetup.Columns["idpettycash"]};
	Relations.Add(new DataRelation("pettycashpettycashsetup",cPar,cChild,false));

	cPar = new []{account.Columns["idacc"]};
	cChild = new []{pettycashsetup.Columns["idacc"]};
	Relations.Add(new DataRelation("accountpettycashsetup",cPar,cChild,false));

	cPar = new []{sorting_siopeentrate.Columns["idsor"]};
	cChild = new []{pettycashsetup.Columns["idsor_siopeinc"]};
	Relations.Add(new DataRelation("sorting_siopeentrate_pettycashsetup",cPar,cChild,false));

	cPar = new []{sorting_siopespese.Columns["idsor"]};
	cChild = new []{pettycashsetup.Columns["idsor_siopeexp"]};
	Relations.Add(new DataRelation("sorting_siopespese_pettycashsetup",cPar,cChild,false));

	#endregion

}
}
}
