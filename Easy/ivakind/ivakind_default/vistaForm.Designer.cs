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
namespace ivakind_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Elenco aliquote
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakind 		=> Tables["ivakind"];

	///<summary>
	///Tipo imponibile iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivataxablekind 		=> Tables["ivataxablekind"];

	///<summary>
	///Natura Fattura elettronica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable fenature 		=> Tables["fenature"];

	///<summary>
	///classificazione tipo iva
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable ivakindsorting 		=> Tables["ivakindsorting"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sortingview 		=> Tables["sortingview"];

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
	//////////////////// IVAKIND /////////////////////////////////
	var tivakind= new DataTable("ivakind");
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("codeivakind", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("rate", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	C= new DataColumn("unabatabilitypercentage", typeof(decimal));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("lu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakind.Columns.Add(C);
	tivakind.Columns.Add( new DataColumn("active", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idivataxablekind", typeof(int)));
	tivakind.Columns.Add( new DataColumn("flag", typeof(int)));
	tivakind.Columns.Add( new DataColumn("annotations", typeof(string)));
	tivakind.Columns.Add( new DataColumn("idfenature", typeof(string)));
	Tables.Add(tivakind);
	tivakind.PrimaryKey =  new DataColumn[]{tivakind.Columns["idivakind"]};


	//////////////////// IVATAXABLEKIND /////////////////////////////////
	var tivataxablekind= new DataTable("ivataxablekind");
	C= new DataColumn("idivataxablekind", typeof(int));
	C.AllowDBNull=false;
	tivataxablekind.Columns.Add(C);
	tivataxablekind.Columns.Add( new DataColumn("description", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivataxablekind.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tivataxablekind.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivataxablekind.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tivataxablekind.Columns.Add(C);
	Tables.Add(tivataxablekind);
	tivataxablekind.PrimaryKey =  new DataColumn[]{tivataxablekind.Columns["idivataxablekind"]};


	//////////////////// FENATURE /////////////////////////////////
	var tfenature= new DataTable("fenature");
	C= new DataColumn("idfenature", typeof(string));
	C.AllowDBNull=false;
	tfenature.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tfenature.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tfenature.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tfenature.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tfenature.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tfenature.Columns.Add(C);
	Tables.Add(tfenature);
	tfenature.PrimaryKey =  new DataColumn[]{tfenature.Columns["idfenature"]};


	//////////////////// IVAKINDSORTING /////////////////////////////////
	var tivakindsorting= new DataTable("ivakindsorting");
	C= new DataColumn("idivakind", typeof(int));
	C.AllowDBNull=false;
	tivakindsorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tivakindsorting.Columns.Add(C);
	tivakindsorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tivakindsorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	tivakindsorting.Columns.Add( new DataColumn("!sortingkind", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tivakindsorting.Columns.Add(C);
	tivakindsorting.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tivakindsorting.Columns.Add(C);
	tivakindsorting.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tivakindsorting);
	tivakindsorting.PrimaryKey =  new DataColumn[]{tivakindsorting.Columns["idivakind"], tivakindsorting.Columns["idsor"]};


	//////////////////// SORTINGVIEW /////////////////////////////////
	var tsortingview= new DataTable("sortingview");
	C= new DataColumn("codesorkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortingkind", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("leveldescr", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("paridsor", typeof(int)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("incomeprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("expenseprevision", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("start", typeof(short)));
	tsortingview.Columns.Add( new DataColumn("stop", typeof(short)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsortingview.Columns.Add(C);
	tsortingview.Columns.Add( new DataColumn("defaultn1", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn2", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn3", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn4", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaultn5", typeof(decimal)));
	tsortingview.Columns.Add( new DataColumn("defaults1", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults2", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults3", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults4", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("defaults5", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	tsortingview.Columns.Add( new DataColumn("movkind", typeof(string)));
	Tables.Add(tsortingview);
	tsortingview.PrimaryKey =  new DataColumn[]{tsortingview.Columns["idsor"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{ivakind.Columns["idivakind"]};
	var cChild = new []{ivakindsorting.Columns["idivakind"]};
	Relations.Add(new DataRelation("ivakind_ivakindsorting",cPar,cChild,false));

	cPar = new []{sortingview.Columns["idsor"]};
	cChild = new []{ivakindsorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingview_ivakindsorting",cPar,cChild,false));

	cPar = new []{fenature.Columns["idfenature"]};
	cChild = new []{ivakind.Columns["idfenature"]};
	Relations.Add(new DataRelation("FK_naturefe_ivakind",cPar,cChild,false));

	cPar = new []{ivataxablekind.Columns["idivataxablekind"]};
	cChild = new []{ivakind.Columns["idivataxablekind"]};
	Relations.Add(new DataRelation("ivataxablekind_ivakind",cPar,cChild,false));

	#endregion

}
}
}
