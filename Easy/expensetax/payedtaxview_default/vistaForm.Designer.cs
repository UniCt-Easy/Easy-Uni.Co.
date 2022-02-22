
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
namespace payedtaxview_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable payedtaxview 		=> Tables["payedtaxview"];

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


	//////////////////// PAYEDTAXVIEW /////////////////////////////////
	var tpayedtaxview= new DataTable("payedtaxview");
	tpayedtaxview.Columns.Add( new DataColumn("cf", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("address", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("cap", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("city", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("country", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("nation", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("location", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("payed_city", typeof(string)));
	tpayedtaxview.Columns.Add( new DataColumn("payed_fiscaltaxregion", typeof(string)));
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
	C= new DataColumn("taxcategory", typeof(string));
	C.ReadOnly=true;
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
	C= new DataColumn("datetaxpay", typeof(DateTime));
	C.ReadOnly=true;
	tpayedtaxview.Columns.Add(C);
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
	C= new DataColumn("department", typeof(string));
	C.ReadOnly=true;
	tpayedtaxview.Columns.Add(C);
	tpayedtaxview.Columns.Add( new DataColumn("start", typeof(DateTime)));
	tpayedtaxview.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	Tables.Add(tpayedtaxview);
	tpayedtaxview.PrimaryKey =  new DataColumn[]{tpayedtaxview.Columns["idexp"], tpayedtaxview.Columns["taxcode"], tpayedtaxview.Columns["nbracket"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{payedtaxview.Columns["idreg"]};
	Relations.Add(new DataRelation("registrypayedtaxview",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{payedtaxview.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxpayedtaxview",cPar,cChild,false));

	#endregion

}
}
}
