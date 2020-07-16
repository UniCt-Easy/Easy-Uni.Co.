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
namespace deduction_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Imponibile
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable taxablekind 		=> Tables["taxablekind"];

	///<summary>
	///Imputazione tipo deduzione 
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductioncode 		=> Tables["deductioncode"];

	///<summary>
	///Codici Deduzioni per Esercizio
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deduction 		=> Tables["deduction"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deductionview 		=> Tables["deductionview"];

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
	//////////////////// TAXABLEKIND /////////////////////////////////
	var ttaxablekind= new DataTable("taxablekind");
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("evaluationorder", typeof(int));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("roundingkind", typeof(string)));
	C= new DataColumn("spcalcrefertaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("spcalcannualtaxable", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	ttaxablekind.Columns.Add(C);
	ttaxablekind.Columns.Add( new DataColumn("lu", typeof(string)));
	ttaxablekind.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(ttaxablekind);
	ttaxablekind.PrimaryKey =  new DataColumn[]{ttaxablekind.Columns["taxablecode"], ttaxablekind.Columns["ayear"]};


	//////////////////// DEDUCTIONCODE /////////////////////////////////
	var tdeductioncode= new DataTable("deductioncode");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductioncode.Columns.Add(C);
	tdeductioncode.Columns.Add( new DataColumn("code", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("description", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("rate", typeof(decimal)));
	tdeductioncode.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeductioncode.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	Tables.Add(tdeductioncode);
	tdeductioncode.PrimaryKey =  new DataColumn[]{tdeductioncode.Columns["iddeduction"], tdeductioncode.Columns["ayear"]};


	//////////////////// DEDUCTION /////////////////////////////////
	var tdeduction= new DataTable("deduction");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	tdeduction.Columns.Add( new DataColumn("!codicededuzione", typeof(string)));
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tdeduction.Columns.Add(C);
	tdeduction.Columns.Add( new DataColumn("lu", typeof(string)));
	tdeduction.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	tdeduction.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tdeduction.Columns.Add( new DataColumn("flagdeductibleexpense", typeof(string)));
	tdeduction.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tdeduction.Columns.Add( new DataColumn("!franchigia", typeof(decimal)));
	tdeduction.Columns.Add( new DataColumn("!massimale", typeof(decimal)));
	tdeduction.Columns.Add( new DataColumn("!aliquota", typeof(decimal)));
	Tables.Add(tdeduction);
	tdeduction.PrimaryKey =  new DataColumn[]{tdeduction.Columns["iddeduction"]};


	//////////////////// DEDUCTIONVIEW /////////////////////////////////
	var tdeductionview= new DataTable("deductionview");
	C= new DataColumn("iddeduction", typeof(int));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(int));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	tdeductionview.Columns.Add( new DataColumn("deductioncode", typeof(string)));
	C= new DataColumn("calculationkind", typeof(string));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	C= new DataColumn("taxablecode", typeof(string));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	tdeductionview.Columns.Add( new DataColumn("longdescription", typeof(string)));
	tdeductionview.Columns.Add( new DataColumn("validitystart", typeof(DateTime)));
	tdeductionview.Columns.Add( new DataColumn("validitystop", typeof(DateTime)));
	C= new DataColumn("evaluatesp", typeof(string));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	tdeductionview.Columns.Add( new DataColumn("evaluationorder", typeof(int)));
	tdeductionview.Columns.Add( new DataColumn("deductiontitle", typeof(string)));
	tdeductionview.Columns.Add( new DataColumn("exemption", typeof(decimal)));
	tdeductionview.Columns.Add( new DataColumn("maximal", typeof(decimal)));
	tdeductionview.Columns.Add( new DataColumn("rate", typeof(decimal)));
	C= new DataColumn("flagdeductibleexpense", typeof(string));
	C.AllowDBNull=false;
	tdeductionview.Columns.Add(C);
	Tables.Add(tdeductionview);
	tdeductionview.PrimaryKey =  new DataColumn[]{tdeductionview.Columns["iddeduction"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{taxablekind.Columns["taxablecode"]};
	var cChild = new []{deduction.Columns["taxablecode"]};
	Relations.Add(new DataRelation("taxablekinddeduction",cPar,cChild,false));

	cPar = new []{deduction.Columns["iddeduction"]};
	cChild = new []{deductioncode.Columns["iddeduction"]};
	Relations.Add(new DataRelation("deductiondeductioncode",cPar,cChild,false));

	#endregion

}
}
}
