/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
namespace voce8000lookup_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000 		=> Tables["voce8000"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000lookup 		=> Tables["voce8000lookup"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000_impon 		=> Tables["voce8000_impon"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000_quotaesente 		=> Tables["voce8000_quotaesente"];

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
	//////////////////// VOCE8000 /////////////////////////////////
	var tvoce8000= new DataTable("voce8000");
	C= new DataColumn("voce", typeof(string));
	C.AllowDBNull=false;
	tvoce8000.Columns.Add(C);
	tvoce8000.Columns.Add( new DataColumn("description", typeof(string)));
	tvoce8000.Columns.Add( new DataColumn("active", typeof(string)));
	tvoce8000.Columns.Add( new DataColumn("kind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000.Columns.Add(C);
	tvoce8000.Columns.Add( new DataColumn("capitolo", typeof(string)));
	tvoce8000.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	Tables.Add(tvoce8000);
	tvoce8000.PrimaryKey =  new DataColumn[]{tvoce8000.Columns["voce"]};


	//////////////////// VOCE8000LOOKUP /////////////////////////////////
	var tvoce8000lookup= new DataTable("voce8000lookup");
	C= new DataColumn("idvoce", typeof(int));
	C.AllowDBNull=false;
	tvoce8000lookup.Columns.Add(C);
	tvoce8000lookup.Columns.Add( new DataColumn("conto", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000lookup.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000lookup.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000lookup.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000lookup.Columns.Add(C);
	tvoce8000lookup.Columns.Add( new DataColumn("servicekind", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("taxref", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("voce", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("taxcode", typeof(int)));
	tvoce8000lookup.Columns.Add( new DataColumn("voceimponibile", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("flagcsausability", typeof(int)));
	tvoce8000lookup.Columns.Add( new DataColumn("vocequotaesente", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("capitolovoce", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("capitoloimponibile", typeof(string)));
	tvoce8000lookup.Columns.Add( new DataColumn("capitoloquotaesente", typeof(string)));
	Tables.Add(tvoce8000lookup);
	tvoce8000lookup.PrimaryKey =  new DataColumn[]{tvoce8000lookup.Columns["idvoce"]};


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


	//////////////////// VOCE8000_IMPON /////////////////////////////////
	var tvoce8000_impon= new DataTable("voce8000_impon");
	C= new DataColumn("voce", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_impon.Columns.Add(C);
	tvoce8000_impon.Columns.Add( new DataColumn("description", typeof(string)));
	tvoce8000_impon.Columns.Add( new DataColumn("active", typeof(string)));
	tvoce8000_impon.Columns.Add( new DataColumn("kind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_impon.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_impon.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_impon.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_impon.Columns.Add(C);
	tvoce8000_impon.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	Tables.Add(tvoce8000_impon);
	tvoce8000_impon.PrimaryKey =  new DataColumn[]{tvoce8000_impon.Columns["voce"]};


	//////////////////// VOCE8000_QUOTAESENTE /////////////////////////////////
	var tvoce8000_quotaesente= new DataTable("voce8000_quotaesente");
	C= new DataColumn("voce", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_quotaesente.Columns.Add(C);
	tvoce8000_quotaesente.Columns.Add( new DataColumn("description", typeof(string)));
	tvoce8000_quotaesente.Columns.Add( new DataColumn("active", typeof(string)));
	tvoce8000_quotaesente.Columns.Add( new DataColumn("kind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_quotaesente.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_quotaesente.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_quotaesente.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_quotaesente.Columns.Add(C);
	tvoce8000_quotaesente.Columns.Add( new DataColumn("flag_geo", typeof(string)));
	Tables.Add(tvoce8000_quotaesente);
	tvoce8000_quotaesente.PrimaryKey =  new DataColumn[]{tvoce8000_quotaesente.Columns["voce"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{voce8000_impon.Columns["voce"]};
	var cChild = new []{voce8000lookup.Columns["voceimponibile"]};
	Relations.Add(new DataRelation("voce8000_impon_voce8000lookup",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"], tax.Columns["taxref"]};
	cChild = new []{voce8000lookup.Columns["taxcode"], voce8000lookup.Columns["taxref"]};
	Relations.Add(new DataRelation("FK_tax_voce8000lookup",cPar,cChild,false));

	cPar = new []{voce8000.Columns["voce"]};
	cChild = new []{voce8000lookup.Columns["voce"]};
	Relations.Add(new DataRelation("FK_voce8000_voce8000lookup",cPar,cChild,false));

	cPar = new []{voce8000_quotaesente.Columns["voce"]};
	cChild = new []{voce8000lookup.Columns["vocequotaesente"]};
	Relations.Add(new DataRelation("voce8000_quotaesente_voce8000lookup",cPar,cChild,false));

	#endregion

}
}
}
