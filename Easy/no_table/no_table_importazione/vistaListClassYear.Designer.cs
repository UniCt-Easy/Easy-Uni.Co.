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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace notable_importazione {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaListClassYear")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaListClassYear: DataSet {

	#region Table members declaration
	///<summary>
	///Nomenclatura combinata
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable intrastatcode		{get { return Tables["intrastatcode"];}}
	///<summary>
	///Codice del servizio
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable intrastatservice		{get { return Tables["intrastatservice"];}}
	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable listclassyear		{get { return Tables["listclassyear"];}}
	///<summary>
	///Classificazione Merceologica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable listclass		{get { return Tables["listclass"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaListClassYear(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaListClassYear (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaListClassYear";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaListClassYear.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// INTRASTATCODE /////////////////////////////////
	T= new DataTable("intrastatcode");
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("code", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idintrastatmeasure", typeof(Int32)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	C= new DataColumn("idintrastatcode", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idintrastatcode"]};


	//////////////////// INTRASTATSERVICE /////////////////////////////////
	T= new DataTable("intrastatservice");
	C= new DataColumn("idintrastatservice", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("code", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idintrastatservice"]};


	//////////////////// LISTCLASSYEAR /////////////////////////////////
	T= new DataTable("listclassyear");
	C= new DataColumn("idlistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ayear", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idintrastatservice", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatcode", typeof(Int32)));
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlistclass"], T.Columns["ayear"]};


	//////////////////// LISTCLASS /////////////////////////////////
	T= new DataTable("listclass");
	C= new DataColumn("idlistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("codelistclass", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paridlistclass", typeof(String)));
	C= new DataColumn("printingorder", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("authrequired", typeof(String)));
	T.Columns.Add( new DataColumn("idaccmotive", typeof(String)));
	T.Columns.Add( new DataColumn("idinv", typeof(Int32)));
	T.Columns.Add( new DataColumn("assetkind", typeof(String)));
	T.Columns.Add( new DataColumn("va3type", typeof(String)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idintrastatsupplymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("intra12operationkind", typeof(String)));
	T.Columns.Add( new DataColumn("flagvisiblekind", typeof(Byte)));
	T.Columns.Add( new DataColumn("idfinmotive", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idlistclass"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{intrastatcode.Columns["idintrastatcode"]};
	CChild = new DataColumn[1]{listclassyear.Columns["idintrastatcode"]};
	Relations.Add(new DataRelation("intrastatcode_listclassyear",CPar,CChild,false));

	CPar = new DataColumn[1]{intrastatservice.Columns["idintrastatservice"]};
	CChild = new DataColumn[1]{listclassyear.Columns["idintrastatservice"]};
	Relations.Add(new DataRelation("intrastatservice_listclassyear",CPar,CChild,false));

	CPar = new DataColumn[1]{listclass.Columns["idlistclass"]};
	CChild = new DataColumn[1]{listclassyear.Columns["idlistclass"]};
	Relations.Add(new DataRelation("listclass_listclassyear",CPar,CChild,false));

	#endregion

}
}
}
