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
namespace taxratestart_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Struttura Imposta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratestart 		=> Tables["taxratestart"];

	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///Scaglioni Imposta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxratebracket 		=> Tables["taxratebracket"];

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
	//////////////////// TAXRATESTART /////////////////////////////////
	var ttaxratestart= new DataTable("taxratestart");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxratestart.Columns.Add(C);
	C= new DataColumn("idtaxratestart", typeof(int));
	C.AllowDBNull=false;
	ttaxratestart.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratestart.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratestart.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxratestart.Columns.Add(C);
	ttaxratestart.Columns.Add( new DataColumn("enforcement", typeof(string)));
	ttaxratestart.Columns.Add( new DataColumn("taxablenumerator", typeof(decimal)));
	ttaxratestart.Columns.Add( new DataColumn("taxabledenominator", typeof(decimal)));
	Tables.Add(ttaxratestart);
	ttaxratestart.PrimaryKey =  new DataColumn[]{ttaxratestart.Columns["taxcode"], ttaxratestart.Columns["idtaxratestart"]};


	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
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
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// TAXRATEBRACKET /////////////////////////////////
	var ttaxratebracket= new DataTable("taxratebracket");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("idtaxratestart", typeof(int));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("nbracket", typeof(short));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	ttaxratebracket.Columns.Add( new DataColumn("minamount", typeof(decimal)));
	ttaxratebracket.Columns.Add( new DataColumn("maxamount", typeof(decimal)));
	C= new DataColumn("adminrate", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("employrate", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("adminnumerator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("admindenominator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("employnumerator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("employdenominator", typeof(decimal));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttaxratebracket.Columns.Add(C);
	Tables.Add(ttaxratebracket);
	ttaxratebracket.PrimaryKey =  new DataColumn[]{ttaxratebracket.Columns["taxcode"], ttaxratebracket.Columns["idtaxratestart"], ttaxratebracket.Columns["nbracket"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{tax.Columns["taxcode"]};
	var cChild = new []{taxratebracket.Columns["taxcode"]};
	Relations.Add(new DataRelation("tax_taxratebracket",cPar,cChild,false));

	cPar = new []{taxratestart.Columns["taxcode"], taxratestart.Columns["idtaxratestart"]};
	cChild = new []{taxratebracket.Columns["taxcode"], taxratebracket.Columns["idtaxratestart"]};
	Relations.Add(new DataRelation("taxratebracket_taxratestart",cPar,cChild,false));

	#endregion

}
}
}
