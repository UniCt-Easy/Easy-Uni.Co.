
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
namespace unifiedtax_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

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

	///<summary>
	///iddb dei vari dipartimenti presenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable dbdepartment 		=> Tables["dbdepartment"];

	///<summary>
	///Ritenute centralizzate
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedtax 		=> Tables["unifiedtax"];

	///<summary>
	///Modello F24 EP consolidato
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable unifiedf24ep 		=> Tables["unifiedf24ep"];

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
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// DBDEPARTMENT /////////////////////////////////
	var tdbdepartment= new DataTable("dbdepartment");
	tdbdepartment.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("iddbdepartment", typeof(string));
	C.AllowDBNull=false;
	tdbdepartment.Columns.Add(C);
	tdbdepartment.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdbdepartment.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tdbdepartment);
	tdbdepartment.PrimaryKey =  new DataColumn[]{tdbdepartment.Columns["iddbdepartment"]};


	//////////////////// UNIFIEDTAX /////////////////////////////////
	var tunifiedtax= new DataTable("unifiedtax");
	C= new DataColumn("idunifiedtax", typeof(int));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	tunifiedtax.Columns.Add( new DataColumn("idunifiedf24ep", typeof(int)));
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	tunifiedtax.Columns.Add( new DataColumn("nbracket", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("abatements", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("adminnumerator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("admindenominator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("adminrate", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("admintax", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employnumerator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employdenominator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employrate", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("employtax", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxablegross", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("taxablenet", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("exemptionquota", typeof(decimal)));
	tunifiedtax.Columns.Add( new DataColumn("competencydate", typeof(DateTime)));
	tunifiedtax.Columns.Add( new DataColumn("idcity", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("idfiscaltaxregion", typeof(string)));
	tunifiedtax.Columns.Add( new DataColumn("ayear", typeof(short)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedtax.Columns.Add(C);
	tunifiedtax.Columns.Add( new DataColumn("nmonth", typeof(short)));
	tunifiedtax.Columns.Add( new DataColumn("iddbdepartment", typeof(string)));
	tunifiedtax.Columns.Add( new DataColumn("idreg", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("ymov", typeof(short)));
	tunifiedtax.Columns.Add( new DataColumn("nmov", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("npay", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("idexp", typeof(int)));
	tunifiedtax.Columns.Add( new DataColumn("servicestart", typeof(DateTime)));
	tunifiedtax.Columns.Add( new DataColumn("servicestop", typeof(DateTime)));
	Tables.Add(tunifiedtax);
	tunifiedtax.PrimaryKey =  new DataColumn[]{tunifiedtax.Columns["idunifiedtax"]};


	//////////////////// UNIFIEDF24EP /////////////////////////////////
	var tunifiedf24ep= new DataTable("unifiedf24ep");
	C= new DataColumn("idunifiedf24ep", typeof(int));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("nmonth", typeof(int));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	tunifiedf24ep.Columns.Add( new DataColumn("adate", typeof(DateTime)));
	C= new DataColumn("paymentdate", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tunifiedf24ep.Columns.Add(C);
	Tables.Add(tunifiedf24ep);
	tunifiedf24ep.PrimaryKey =  new DataColumn[]{tunifiedf24ep.Columns["idunifiedf24ep"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{unifiedf24ep.Columns["idunifiedf24ep"]};
	var cChild = new []{unifiedtax.Columns["idunifiedf24ep"]};
	Relations.Add(new DataRelation("unifiedf24ep_unifiedtax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{unifiedtax.Columns["taxcode"]};
	Relations.Add(new DataRelation("FK_tax_unifiedtax",cPar,cChild,false));

	cPar = new []{dbdepartment.Columns["iddbdepartment"]};
	cChild = new []{unifiedtax.Columns["iddbdepartment"]};
	Relations.Add(new DataRelation("FK_dbdepartment_unifiedtax",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{unifiedtax.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_unifiedtax",cPar,cChild,false));

	#endregion

}
}
}
