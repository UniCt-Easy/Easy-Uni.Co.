
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
namespace expensetaxcorrigeview_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expensetaxcorrigeview 		=> Tables["expensetaxcorrigeview"];

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

	///<summary>
	///Regione per applicazione imposta regionale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fiscaltaxregion 		=> Tables["fiscaltaxregion"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable geo_cityview 		=> Tables["geo_cityview"];

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
	texpensetaxcorrigeview.Columns.Add( new DataColumn("incomelinkedymov", typeof(short)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("incomelinkednmov", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("linkedidexp", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("expenselinkedymov", typeof(short)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("expenselinkednmov", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("ytaxpay", typeof(short)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("ntaxpay", typeof(int)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("ymov", typeof(short));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("nmov", typeof(int));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	texpensetaxcorrigeview.Columns.Add( new DataColumn("idreg", typeof(int)));
	C= new DataColumn("registry", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("expensedescription", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	C= new DataColumn("expenseadate", typeof(DateTime));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
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
	C= new DataColumn("phasedescription", typeof(string));
	C.AllowDBNull=false;
	texpensetaxcorrigeview.Columns.Add(C);
	texpensetaxcorrigeview.Columns.Add( new DataColumn("descriptionrenumeration", typeof(string)));
	texpensetaxcorrigeview.Columns.Add( new DataColumn("idtreasurer", typeof(int)));
	C= new DataColumn("department", typeof(string));
	C.ReadOnly=true;
	texpensetaxcorrigeview.Columns.Add(C);
	Tables.Add(texpensetaxcorrigeview);
	texpensetaxcorrigeview.PrimaryKey =  new DataColumn[]{texpensetaxcorrigeview.Columns["idexp"], texpensetaxcorrigeview.Columns["idexpensetaxcorrige"], texpensetaxcorrigeview.Columns["taxcode"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	ttax.Columns.Add( new DataColumn("active", typeof(string)));
	ttax.Columns.Add( new DataColumn("appliancebasis", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	ttax.Columns.Add( new DataColumn("geoappliance", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_cost", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_debit", typeof(string)));
	ttax.Columns.Add( new DataColumn("idaccmotive_pay", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxablecode", typeof(string)));
	C= new DataColumn("taxref", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("maintaxcode", typeof(int)));
	C= new DataColumn("taxkind", typeof(short));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// FISCALTAXREGION /////////////////////////////////
	var tfiscaltaxregion= new DataTable("fiscaltaxregion");
	C= new DataColumn("idfiscaltaxregion", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	tfiscaltaxregion.Columns.Add( new DataColumn("idcountry", typeof(int)));
	tfiscaltaxregion.Columns.Add( new DataColumn("idregion", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfiscaltaxregion.Columns.Add(C);
	Tables.Add(tfiscaltaxregion);
	tfiscaltaxregion.PrimaryKey =  new DataColumn[]{tfiscaltaxregion.Columns["idfiscaltaxregion"]};


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

	#endregion


	#region DataRelation creation
	var cPar = new []{tax.Columns["taxcode"]};
	var cChild = new []{expensetaxcorrigeview.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_expensetaxcorrigeview",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{expensetaxcorrigeview.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_expensetaxcorrigeview",cPar,cChild,false));

	cPar = new []{fiscaltaxregion.Columns["idfiscaltaxregion"]};
	cChild = new []{expensetaxcorrigeview.Columns["idfiscaltaxregion"]};
	Relations.Add(new DataRelation("fiscaltaxregion_expensetaxcorrigeview",cPar,cChild,false));

	cPar = new []{geo_cityview.Columns["idcity"]};
	cChild = new []{expensetaxcorrigeview.Columns["idcity"]};
	Relations.Add(new DataRelation("geo_cityview_expensetaxcorrigeview",cPar,cChild,false));

	#endregion

}
}
}
