
/*
Easy
Copyright (C) 2021 Universit‡ degli Studi di Catania (www.unict.it)
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
namespace taxpay_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Liquidazione delle ritenute gi√† effettuate (storico)
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpay 		=> Tables["taxpay"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpayview 		=> Tables["taxpayview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxpayexpenseview 		=> Tables["taxpayexpenseview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payedtaxview 		=> Tables["payedtaxview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetaxcorrigeview 		=> Tables["expensetaxcorrigeview"];

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
	//////////////////// TAXPAY /////////////////////////////////
	var ttaxpay= new DataTable("taxpay");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("ytaxpay", typeof(short));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("ntaxpay", typeof(int));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	ttaxpay.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	ttaxpay.Columns.Add( new DataColumn("txt", typeof(string)));
	ttaxpay.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpay.Columns.Add(C);
	Tables.Add(ttaxpay);
	ttaxpay.PrimaryKey =  new DataColumn[]{ttaxpay.Columns["taxcode"], ttaxpay.Columns["ytaxpay"], ttaxpay.Columns["ntaxpay"]};


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
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXPAYVIEW /////////////////////////////////
	var ttaxpayview= new DataTable("taxpayview");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("taxkind", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("ytaxpay", typeof(short));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("ntaxpay", typeof(int));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("stop", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	ttaxpayview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayview.Columns.Add(C);
	Tables.Add(ttaxpayview);
	ttaxpayview.PrimaryKey =  new DataColumn[]{ttaxpayview.Columns["taxcode"], ttaxpayview.Columns["ytaxpay"], ttaxpayview.Columns["ntaxpay"]};


	//////////////////// TAXPAYEXPENSEVIEW /////////////////////////////////
	var ttaxpayexpenseview= new DataTable("taxpayexpenseview");
	C= new DataColumn("ytaxpay", typeof(short));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("ntaxpay", typeof(int));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	ttaxpayexpenseview.Columns.Add( new DataColumn("parentidexp", typeof(int)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	ttaxpayexpenseview.Columns.Add( new DataColumn("idreg", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("registry", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idfin", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("codefin", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("finance", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idupb", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("codeupb", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("upb", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idman", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("manager", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("ypay", typeof(short)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("npay", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("doc", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("docdate", typeof(DateTime)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	ttaxpayexpenseview.Columns.Add( new DataColumn("amount", typeof(decimal)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("ayearstartamount", typeof(decimal)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("curramount", typeof(decimal)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("available", typeof(decimal)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("cin", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idbank", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idcab", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("cc", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idser", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("service", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("ivaamount", typeof(decimal)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("autokind", typeof(byte)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("idpayment", typeof(int)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("flagarrear", typeof(string)));
	ttaxpayexpenseview.Columns.Add( new DataColumn("expiration", typeof(DateTime)));
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	ttaxpayexpenseview.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxpayexpenseview.Columns.Add(C);
	Tables.Add(ttaxpayexpenseview);
	ttaxpayexpenseview.PrimaryKey =  new DataColumn[]{ttaxpayexpenseview.Columns["idexp"]};


	//////////////////// PAYEDTAXVIEW /////////////////////////////////
	var tpayedtaxview= new DataTable("payedtaxview");
	tpayedtaxview.Columns.Add( new DataColumn("cf", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("address", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("cap", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("city", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("country", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("nation", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	tpayedtaxview.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	tpayedtaxview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpayedtaxview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("expensedescription", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	tpayedtaxview.Columns.Add( new DataColumn("idser", typeof(int)));
	tpayedtaxview.Columns.Add( new DataColumn("codeser", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("service", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	tpayedtaxview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("taxkind", typeof(short));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	tpayedtaxview.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayedtaxview.Columns.Add( new DataColumn("competencydate", typeof(DateTime)));
	tpayedtaxview.Columns.Add( new DataColumn("datetaxpay", typeof(DateTime)));
	tpayedtaxview.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	tpayedtaxview.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayedtaxview.Columns.Add(C);
	tpayedtaxview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	tpayedtaxview.Columns.Add( new DataColumn("taxcategory", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("department", typeof(string)));
	Tables.Add(tpayedtaxview);
	tpayedtaxview.PrimaryKey =  new DataColumn[]{tpayedtaxview.Columns["idexp"], tpayedtaxview.Columns["nbracket"], tpayedtaxview.Columns["taxcode"]};


	//////////////////// EXPENSETAXCORRIGEVIEW /////////////////////////////////
	var texpensetaxcorrigeview= new DataTable("expensetaxcorrigeview");
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("idexpensetaxcorrige", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("tax", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	texpensetaxcorrigeview.Columns.Add( new DataColumn("employamount", typeof(decimal)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("adminamount", typeof(decimal)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("idcity", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("city", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("provincecode", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("fiscaltaxregion", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("linkedidinc", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("linkedidexp", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	texpensetaxcorrigeview.Columns.Add( new DataColumn("ymov", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("nmov", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("phasedescription", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("expensedescription", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("descriptionrenumeration", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("department", typeof(string)));
	Tables.Add(texpensetaxcorrigeview);
	texpensetaxcorrigeview.PrimaryKey =  new DataColumn[]{texpensetaxcorrigeview.Columns["idexp"], texpensetaxcorrigeview.Columns["idexpensetaxcorrige"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{taxpay.Columns["ytaxpay"], taxpay.Columns["ntaxpay"]};
	var cChild = new []{expensetaxcorrigeview.Columns["ytaxpay"], expensetaxcorrigeview.Columns["ntaxpay"]};
	Relations.Add(new DataRelation("taxpayexpensetaxcorrigeview",cPar,cChild,false));

	cPar = new []{taxpay.Columns["taxcode"], taxpay.Columns["ytaxpay"], taxpay.Columns["ntaxpay"]};
	cChild = new []{taxpayexpenseview.Columns["taxcode"], taxpayexpenseview.Columns["ytaxpay"], taxpayexpenseview.Columns["ntaxpay"]};
	Relations.Add(new DataRelation("taxpaytaxpayexpenseview",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{taxpay.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxtaxpay",cPar,cChild,false));

	cPar = new []{taxpay.Columns["ytaxpay"], taxpay.Columns["ntaxpay"]};
	cChild = new []{payedtaxview.Columns["ytaxpay"], payedtaxview.Columns["ntaxpay"]};
	Relations.Add(new DataRelation("taxpay_payedtaxview",cPar,cChild,false));

	#endregion

}
}
}
