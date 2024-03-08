
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
namespace payedtaxf24ordview_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payedtaxf24ordview 		=> Tables["payedtaxf24ordview"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable f24ordinario 		=> Tables["f24ordinario"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable monthname 		=> Tables["monthname"];

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
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


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


	//////////////////// PAYEDTAXF24ORDVIEW /////////////////////////////////
	var tpayedtaxf24ordview= new DataTable("payedtaxf24ordview");
	tpayedtaxf24ordview.Columns.Add( new DataColumn("cf", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("address", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("cap", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("city", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("country", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("nation", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("location", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("payed_city", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("payed_fiscaltaxregion", typeof(string)));
	C= new DataColumn("idexp", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	C= new DataColumn("nphase", typeof(byte));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("phase", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("idreg", typeof(int)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("registry", typeof(string)));
	C= new DataColumn("expensedescription", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("idser", typeof(int)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("codeser", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("service", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("taxkind", typeof(short));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("taxcategory", typeof(string));
	C.ReadOnly=true;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("competencydate", typeof(DateTime)));
	C= new DataColumn("datetaxpay", typeof(DateTime));
	C.ReadOnly=true;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("department", typeof(string));
	C.ReadOnly=true;
	tpayedtaxf24ordview.Columns.Add(C);
	tpayedtaxf24ordview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("fiscaltaxcodecreditf24ord", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("fiscaltaxcodef24ord", typeof(string)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("idf24ordinario", typeof(int)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("ayear", typeof(int)));
	tpayedtaxf24ordview.Columns.Add( new DataColumn("nmonth", typeof(int)));
	Tables.Add(tpayedtaxf24ordview);
	tpayedtaxf24ordview.PrimaryKey =  new DataColumn[]{tpayedtaxf24ordview.Columns["idexp"], tpayedtaxf24ordview.Columns["taxcode"], tpayedtaxf24ordview.Columns["nbracket"]};


	//////////////////// F24ORDINARIO /////////////////////////////////
	var tf24ordinario= new DataTable("f24ordinario");
	C= new DataColumn("idf24ordinario", typeof(int));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	tf24ordinario.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("nmonth", typeof(int));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	C= new DataColumn("paymentdate", typeof(DateTime));
	C.AllowDBNull=false;
	tf24ordinario.Columns.Add(C);
	tf24ordinario.Columns.Add( new DataColumn("taxpay_start", typeof(DateTime)));
	tf24ordinario.Columns.Add( new DataColumn("taxpay_stop", typeof(DateTime)));
	Tables.Add(tf24ordinario);
	tf24ordinario.PrimaryKey =  new DataColumn[]{tf24ordinario.Columns["idf24ordinario"]};


	//////////////////// MONTHNAME /////////////////////////////////
	var tmonthname= new DataTable("monthname");
	C= new DataColumn("code", typeof(int));
	C.AllowDBNull=false;
	tmonthname.Columns.Add(C);
	tmonthname.Columns.Add( new DataColumn("cfvalue", typeof(string)));
	tmonthname.Columns.Add( new DataColumn("title", typeof(string)));
	Tables.Add(tmonthname);
	tmonthname.PrimaryKey =  new DataColumn[]{tmonthname.Columns["code"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{payedtaxf24ordview.Columns["idreg"]};
	Relations.Add(new DataRelation("registrypayedtaxview",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payedtaxf24ordview.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayedtaxview",cPar,cChild,false));

	cPar = new []{f24ordinario.Columns["idf24ordinario"]};
	cChild = new []{payedtaxf24ordview.Columns["idf24ordinario"]};
	Relations.Add(new DataRelation("f24ordinario_payedtaxf24ordview",cPar,cChild,false));

	cPar = new []{monthname.Columns["code"]};
	cChild = new []{payedtaxf24ordview.Columns["nmonth"]};
	Relations.Add(new DataRelation("monthname_payedtaxf24ordview",cPar,cChild,false));

	#endregion

}
}
}
