
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
namespace taxsetup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Automatismi delle ritenute
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxsetup 		=> Tables["taxsetup"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxsetupview 		=> Tables["taxsetupview"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bilancioversamento 		=> Tables["bilancioversamento"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bilancioapplicazione 		=> Tables["bilancioapplicazione"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bilanciocontributi 		=> Tables["bilanciocontributi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tmp_tiposcadenza 		=> Tables["tmp_tiposcadenza"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpaymentpartsetupview 		=> Tables["taxpaymentpartsetupview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxregionsetupview 		=> Tables["taxregionsetupview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finincomeemploy 		=> Tables["finincomeemploy"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable finexpenseemploy 		=> Tables["finexpenseemploy"];

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
	//////////////////// TAXSETUP /////////////////////////////////
	var ttaxsetup= new DataTable("taxsetup");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	ttaxsetup.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idfinexpensecontra", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idfinincomecontra", typeof(int)));
	C= new DataColumn("flagadminfinance", typeof(string));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	ttaxsetup.Columns.Add( new DataColumn("idfinadmintax", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	ttaxsetup.Columns.Add( new DataColumn("expiringday", typeof(short)));
	ttaxsetup.Columns.Add( new DataColumn("txt", typeof(string)));
	ttaxsetup.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	ttaxsetup.Columns.Add(C);
	ttaxsetup.Columns.Add( new DataColumn("idfinincomeemploy", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("idfinexpenseemploy", typeof(int)));
	ttaxsetup.Columns.Add( new DataColumn("taxpaykind", typeof(string)));
	Tables.Add(ttaxsetup);
	ttaxsetup.PrimaryKey =  new DataColumn[]{ttaxsetup.Columns["taxcode"], ttaxsetup.Columns["ayear"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXSETUPVIEW /////////////////////////////////
	var ttaxsetupview= new DataTable("taxsetupview");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	C= new DataColumn("taxkind", typeof(string));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	ttaxsetupview.Columns.Add( new DataColumn("flagregionalagency", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("paymentagency", typeof(int)));
	ttaxsetupview.Columns.Add( new DataColumn("paymentagencytitle", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("idfinexpensecontra", typeof(int)));
	ttaxsetupview.Columns.Add( new DataColumn("codefinexpensecontra", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("finexpensecontra", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("idfinincomecontra", typeof(int)));
	ttaxsetupview.Columns.Add( new DataColumn("codefinincomecontra", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("finincomecontra", typeof(string)));
	C= new DataColumn("flagadminfinance", typeof(string));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	ttaxsetupview.Columns.Add( new DataColumn("idfinadmintax", typeof(int)));
	ttaxsetupview.Columns.Add( new DataColumn("codefinadmintax", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("finadmintax", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	ttaxsetupview.Columns.Add( new DataColumn("expiringday", typeof(short)));
	ttaxsetupview.Columns.Add( new DataColumn("flagprevcurr", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxsetupview.Columns.Add(C);
	ttaxsetupview.Columns.Add( new DataColumn("idfinincomeemploy", typeof(int)));
	ttaxsetupview.Columns.Add( new DataColumn("codefinincomeemploy", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("finincomeemploy", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("idfinexpenseemploy", typeof(int)));
	ttaxsetupview.Columns.Add( new DataColumn("codefinexpenseemploy", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("finexpenseemploy", typeof(string)));
	ttaxsetupview.Columns.Add( new DataColumn("taxpaykind", typeof(string)));
	Tables.Add(ttaxsetupview);
	ttaxsetupview.PrimaryKey =  new DataColumn[]{ttaxsetupview.Columns["taxcode"], ttaxsetupview.Columns["ayear"]};


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


	//////////////////// BILANCIOVERSAMENTO /////////////////////////////////
	var tbilancioversamento= new DataTable("bilancioversamento");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	tbilancioversamento.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	tbilancioversamento.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tbilancioversamento.Columns.Add( new DataColumn("idman", typeof(int)));
	tbilancioversamento.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	tbilancioversamento.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tbilancioversamento.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbilancioversamento.Columns.Add(C);
	Tables.Add(tbilancioversamento);
	tbilancioversamento.PrimaryKey =  new DataColumn[]{tbilancioversamento.Columns["idfin"]};


	//////////////////// BILANCIOAPPLICAZIONE /////////////////////////////////
	var tbilancioapplicazione= new DataTable("bilancioapplicazione");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	tbilancioapplicazione.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	tbilancioapplicazione.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tbilancioapplicazione.Columns.Add( new DataColumn("idman", typeof(int)));
	tbilancioapplicazione.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	tbilancioapplicazione.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tbilancioapplicazione.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbilancioapplicazione.Columns.Add(C);
	Tables.Add(tbilancioapplicazione);
	tbilancioapplicazione.PrimaryKey =  new DataColumn[]{tbilancioapplicazione.Columns["idfin"]};


	//////////////////// BILANCIOCONTRIBUTI /////////////////////////////////
	var tbilanciocontributi= new DataTable("bilanciocontributi");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	tbilanciocontributi.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	tbilanciocontributi.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tbilanciocontributi.Columns.Add( new DataColumn("idman", typeof(int)));
	tbilanciocontributi.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	tbilanciocontributi.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tbilanciocontributi.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbilanciocontributi.Columns.Add(C);
	Tables.Add(tbilanciocontributi);
	tbilanciocontributi.PrimaryKey =  new DataColumn[]{tbilanciocontributi.Columns["idfin"]};


	//////////////////// TMP_TIPOSCADENZA /////////////////////////////////
	var ttmp_tiposcadenza= new DataTable("tmp_tiposcadenza");
	C= new DataColumn("tiposcadenza", typeof(short));
	C.AllowDBNull=false;
	ttmp_tiposcadenza.Columns.Add(C);
	ttmp_tiposcadenza.Columns.Add( new DataColumn("descrizione", typeof(string)));
	Tables.Add(ttmp_tiposcadenza);
	ttmp_tiposcadenza.PrimaryKey =  new DataColumn[]{ttmp_tiposcadenza.Columns["tiposcadenza"]};


	//////////////////// TAXPAYMENTPARTSETUPVIEW /////////////////////////////////
	var ttaxpaymentpartsetupview= new DataTable("taxpaymentpartsetupview");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	ttaxpaymentpartsetupview.Columns.Add( new DataColumn("taxkind", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	ttaxpaymentpartsetupview.Columns.Add( new DataColumn("registry", typeof(string)));
	ttaxpaymentpartsetupview.Columns.Add( new DataColumn("percentage", typeof(decimal)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpaymentpartsetupview.Columns.Add(C);
	Tables.Add(ttaxpaymentpartsetupview);
	ttaxpaymentpartsetupview.PrimaryKey =  new DataColumn[]{ttaxpaymentpartsetupview.Columns["taxcode"], ttaxpaymentpartsetupview.Columns["ayear"], ttaxpaymentpartsetupview.Columns["idreg"]};


	//////////////////// TAXREGIONSETUPVIEW /////////////////////////////////
	var ttaxregionsetupview= new DataTable("taxregionsetupview");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	ttaxregionsetupview.Columns.Add( new DataColumn("taxkind", typeof(string)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	C= new DataColumn("autoid", typeof(int));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	ttaxregionsetupview.Columns.Add( new DataColumn("kind", typeof(string)));
	ttaxregionsetupview.Columns.Add( new DataColumn("idplace", typeof(int)));
	ttaxregionsetupview.Columns.Add( new DataColumn("place", typeof(string)));
	ttaxregionsetupview.Columns.Add( new DataColumn("regionalagency", typeof(int)));
	ttaxregionsetupview.Columns.Add( new DataColumn("regionalagencytitle", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxregionsetupview.Columns.Add(C);
	Tables.Add(ttaxregionsetupview);
	ttaxregionsetupview.PrimaryKey =  new DataColumn[]{ttaxregionsetupview.Columns["taxcode"], ttaxregionsetupview.Columns["ayear"], ttaxregionsetupview.Columns["autoid"]};


	//////////////////// FININCOMEEMPLOY /////////////////////////////////
	var tfinincomeemploy= new DataTable("finincomeemploy");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	tfinincomeemploy.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	tfinincomeemploy.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinincomeemploy.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinincomeemploy.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	tfinincomeemploy.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinincomeemploy.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinincomeemploy.Columns.Add(C);
	Tables.Add(tfinincomeemploy);
	tfinincomeemploy.PrimaryKey =  new DataColumn[]{tfinincomeemploy.Columns["idfin"]};


	//////////////////// FINEXPENSEEMPLOY /////////////////////////////////
	var tfinexpenseemploy= new DataTable("finexpenseemploy");
	C= new DataColumn("idfin", typeof(int));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	tfinexpenseemploy.Columns.Add( new DataColumn("finpart", typeof(string)));
	C= new DataColumn("codefin", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	tfinexpenseemploy.Columns.Add( new DataColumn("paridfin", typeof(int)));
	tfinexpenseemploy.Columns.Add( new DataColumn("idman", typeof(int)));
	tfinexpenseemploy.Columns.Add( new DataColumn("manager", typeof(string)));
	C= new DataColumn("printingorder", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("prevision", typeof(decimal));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	tfinexpenseemploy.Columns.Add( new DataColumn("currentprevision", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("availableprevision", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("previousprevision", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("secondaryprev", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("currentsecondaryprev", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("availablesecondaryprev", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("previoussecondaryprev", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("currentarrears", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("previousarrears", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("prevision2", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("prevision3", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("prevision4", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("prevision5", typeof(decimal)));
	tfinexpenseemploy.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("flag", typeof(byte));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("flagusable", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("idupb", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("codeupb", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("upb", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfinexpenseemploy.Columns.Add(C);
	Tables.Add(tfinexpenseemploy);
	tfinexpenseemploy.PrimaryKey =  new DataColumn[]{tfinexpenseemploy.Columns["idfin"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{taxsetup.Columns["taxcode"], taxsetup.Columns["ayear"]};
	var cChild = new []{taxregionsetupview.Columns["taxcode"], taxregionsetupview.Columns["ayear"]};
	Relations.Add(new DataRelation("taxsetuptaxregionsetupview",cPar,cChild,false));

	cPar = new []{taxsetup.Columns["taxcode"], taxsetup.Columns["ayear"]};
	cChild = new []{taxpaymentpartsetupview.Columns["taxcode"], taxpaymentpartsetupview.Columns["ayear"]};
	Relations.Add(new DataRelation("taxsetuptaxpaymentpartsetupview",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{taxsetup.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxtaxsetup",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{taxsetup.Columns["paymentagency"]};
	Relations.Add(new DataRelation("registrytaxsetup",cPar,cChild,false));

	cPar = new []{bilancioversamento.Columns["idfin"]};
	cChild = new []{taxsetup.Columns["idfinexpensecontra"]};
	Relations.Add(new DataRelation("bilancioversamentotaxsetup",cPar,cChild,false));

	cPar = new []{bilancioapplicazione.Columns["idfin"]};
	cChild = new []{taxsetup.Columns["idfinincomecontra"]};
	Relations.Add(new DataRelation("bilancioapplicazionetaxsetup",cPar,cChild,false));

	cPar = new []{bilanciocontributi.Columns["idfin"]};
	cChild = new []{taxsetup.Columns["idfinadmintax"]};
	Relations.Add(new DataRelation("bilanciocontributitaxsetup",cPar,cChild,false));

	cPar = new []{tmp_tiposcadenza.Columns["tiposcadenza"]};
	cChild = new []{taxsetup.Columns["idexpirationkind"]};
	Relations.Add(new DataRelation("tmp_tiposcadenzataxsetup",cPar,cChild,false));

	cPar = new []{finincomeemploy.Columns["idfin"]};
	cChild = new []{taxsetup.Columns["idfinincomeemploy"]};
	Relations.Add(new DataRelation("finincomeemploy_taxsetup",cPar,cChild,false));

	cPar = new []{finexpenseemploy.Columns["idfin"]};
	cChild = new []{taxsetup.Columns["idfinexpenseemploy"]};
	Relations.Add(new DataRelation("finexpenseemploy_taxsetup",cPar,cChild,false));

	#endregion

}
}
}
