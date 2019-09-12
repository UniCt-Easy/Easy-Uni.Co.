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
namespace treasurer_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tesoriere
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable treasurer 		=> Tables["treasurer"];

	///<summary>
	///Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bank 		=> Tables["bank"];

	///<summary>
	///Sportello Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cab 		=> Tables["cab"];

	///<summary>
	///Piano dei conti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive 		=> Tables["accmotive"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable accmotive1 		=> Tables["accmotive1"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bankcbi 		=> Tables["bankcbi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cabcbi 		=> Tables["cabcbi"];

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
	//////////////////// TREASURER /////////////////////////////////
	var ttreasurer= new DataTable("treasurer");
	C= new DataColumn("idtreasurer", typeof(int));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("codetreasurer", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("flagdefault", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("cin", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcab", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("address", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cap", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("city", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("country", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ftpuser", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ftppassword", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ftpaddress", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("pasvmode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ftpport", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("phoneprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("phonenumber", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("faxnumber", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttreasurer.Columns.Add(C);
	ttreasurer.Columns.Add( new DataColumn("idsor01", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor02", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor03", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor04", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("idsor05", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("agencycodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("depcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cabcodefortransmission", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_proceeds", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idaccmotive_payment", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("spexportexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagmultiexp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("fileextension", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("spexportinc", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("iban", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("bic", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagfruitful", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idbankcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("idcabcbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cccbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("cincbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ibancbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("siacodecbi", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("reccbikind", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("trasmcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagbank_grouping", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("motivelen", typeof(short)));
	ttreasurer.Columns.Add( new DataColumn("motiveprefix", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("motiveseparator", typeof(Char)));
	ttreasurer.Columns.Add( new DataColumn("annotations", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flagedisp", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("billcode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("active", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flag", typeof(int)));
	ttreasurer.Columns.Add( new DataColumn("header", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("savepath", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("departmentname_fe", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("enable_ndoc_treasurer", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("flussocrediticode", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("ftpdir", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("tramite_bt_code", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("tramite_agency_code", typeof(string)));
	ttreasurer.Columns.Add( new DataColumn("agency_istat_code", typeof(string)));
	Tables.Add(ttreasurer);
	ttreasurer.PrimaryKey =  new DataColumn[]{ttreasurer.Columns["idtreasurer"]};


	//////////////////// BANK /////////////////////////////////
	var tbank= new DataTable("bank");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	tbank.Columns.Add( new DataColumn("flagusable", typeof(string)));
	Tables.Add(tbank);
	tbank.PrimaryKey =  new DataColumn[]{tbank.Columns["idbank"]};


	//////////////////// CAB /////////////////////////////////
	var tcab= new DataTable("cab");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("idcab", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	tcab.Columns.Add( new DataColumn("address", typeof(string)));
	tcab.Columns.Add( new DataColumn("cap", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	tcab.Columns.Add( new DataColumn("flagusable", typeof(string)));
	Tables.Add(tcab);
	tcab.PrimaryKey =  new DataColumn[]{tcab.Columns["idbank"], tcab.Columns["idcab"]};


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
	Tables.Add(taccmotive);
	taccmotive.PrimaryKey =  new DataColumn[]{taccmotive.Columns["idaccmotive"]};


	//////////////////// ACCMOTIVE1 /////////////////////////////////
	var taccmotive1= new DataTable("accmotive1");
	C= new DataColumn("idaccmotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	taccmotive1.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("codemotive", typeof(string));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	taccmotive1.Columns.Add( new DataColumn("paridaccmotive", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	taccmotive1.Columns.Add(C);
	Tables.Add(taccmotive1);
	taccmotive1.PrimaryKey =  new DataColumn[]{taccmotive1.Columns["idaccmotive"]};


	//////////////////// BANKCBI /////////////////////////////////
	var tbankcbi= new DataTable("bankcbi");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tbankcbi.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbankcbi.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbankcbi.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tbankcbi.Columns.Add(C);
	tbankcbi.Columns.Add( new DataColumn("flagusable", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbankcbi.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbankcbi.Columns.Add(C);
	Tables.Add(tbankcbi);
	tbankcbi.PrimaryKey =  new DataColumn[]{tbankcbi.Columns["idbank"]};


	//////////////////// CABCBI /////////////////////////////////
	var tcabcbi= new DataTable("cabcbi");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	C= new DataColumn("idcab", typeof(string));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	tcabcbi.Columns.Add( new DataColumn("address", typeof(string)));
	tcabcbi.Columns.Add( new DataColumn("cap", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	tcabcbi.Columns.Add( new DataColumn("flagusable", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcabcbi.Columns.Add(C);
	Tables.Add(tcabcbi);
	tcabcbi.PrimaryKey =  new DataColumn[]{tcabcbi.Columns["idbank"], tcabcbi.Columns["idcab"]};


	//////////////////// SORTING01 /////////////////////////////////
	var tsorting01= new DataTable("sorting01");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting01.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting01.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting01.Columns.Add(C);
	tsorting01.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting01.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting01);
	tsorting01.PrimaryKey =  new DataColumn[]{tsorting01.Columns["idsor"]};


	//////////////////// SORTING02 /////////////////////////////////
	var tsorting02= new DataTable("sorting02");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting02.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting02.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting02.Columns.Add(C);
	tsorting02.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting02.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting02);
	tsorting02.PrimaryKey =  new DataColumn[]{tsorting02.Columns["idsor"]};


	//////////////////// SORTING03 /////////////////////////////////
	var tsorting03= new DataTable("sorting03");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting03.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting03.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting03.Columns.Add(C);
	tsorting03.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting03.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting03);
	tsorting03.PrimaryKey =  new DataColumn[]{tsorting03.Columns["idsor"]};


	//////////////////// SORTING04 /////////////////////////////////
	var tsorting04= new DataTable("sorting04");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting04.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting04.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting04.Columns.Add(C);
	tsorting04.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting04.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting04);
	tsorting04.PrimaryKey =  new DataColumn[]{tsorting04.Columns["idsor"]};


	//////////////////// SORTING05 /////////////////////////////////
	var tsorting05= new DataTable("sorting05");
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting05.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("movkind", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting05.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting05.Columns.Add(C);
	tsorting05.Columns.Add( new DataColumn("start", typeof(short)));
	tsorting05.Columns.Add( new DataColumn("stop", typeof(short)));
	Tables.Add(tsorting05);
	tsorting05.PrimaryKey =  new DataColumn[]{tsorting05.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{cabcbi.Columns["idbank"], cabcbi.Columns["idcab"]};
	var cChild = new []{treasurer.Columns["idbankcbi"], treasurer.Columns["idcabcbi"]};
	Relations.Add(new DataRelation("FK_cabcbi_treasurer",cPar,cChild,false));

	cPar = new []{bankcbi.Columns["idbank"]};
	cChild = new []{treasurer.Columns["idbankcbi"]};
	Relations.Add(new DataRelation("FK_bankcbi_treasurer",cPar,cChild,false));

	cPar = new []{bank.Columns["idbank"]};
	cChild = new []{treasurer.Columns["idbank"]};
	Relations.Add(new DataRelation("banktreasurer",cPar,cChild,false));

	cPar = new []{accmotive1.Columns["idaccmotive"]};
	cChild = new []{treasurer.Columns["idaccmotive_payment"]};
	Relations.Add(new DataRelation("accmotive18treasurer",cPar,cChild,false));

	cPar = new []{accmotive.Columns["idaccmotive"]};
	cChild = new []{treasurer.Columns["idaccmotive_proceeds"]};
	Relations.Add(new DataRelation("accmotive16treasurer",cPar,cChild,false));

	cPar = new []{cab.Columns["idbank"], cab.Columns["idcab"]};
	cChild = new []{treasurer.Columns["idbank"], treasurer.Columns["idcab"]};
	Relations.Add(new DataRelation("cabtreasurer",cPar,cChild,false));

	cPar = new []{sorting01.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor01"]};
	Relations.Add(new DataRelation("sorting01_treasurer",cPar,cChild,false));

	cPar = new []{sorting02.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor02"]};
	Relations.Add(new DataRelation("sorting02_treasurer",cPar,cChild,false));

	cPar = new []{sorting03.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor03"]};
	Relations.Add(new DataRelation("sorting03_treasurer",cPar,cChild,false));

	cPar = new []{sorting04.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor04"]};
	Relations.Add(new DataRelation("sorting04_treasurer",cPar,cChild,false));

	cPar = new []{sorting05.Columns["idsor"]};
	cChild = new []{treasurer.Columns["idsor05"]};
	Relations.Add(new DataRelation("sorting05_treasurer",cPar,cChild,false));

	#endregion

}
}
}
