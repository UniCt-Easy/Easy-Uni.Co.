
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
namespace motive770service_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable service		{get { return Tables["service"];}}
	///<summary>
	///Abbinamento prestazione con la causale del modello 770
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable motive770service		{get { return Tables["motive770service"];}}
	///<summary>
	///Causali esenzione per il mod. 770
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable mod770_exemptioncode		{get { return Tables["mod770_exemptioncode"];}}
	///<summary>
	///Causali per il mod. 770
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable motive770		{get { return Tables["motive770"];}}
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable mod770_socialsecuritycode		{get { return Tables["mod770_socialsecuritycode"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaForm.xsd";
this.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// service /////////////////////////////////
	T= new DataTable("service");
	C= new DataColumn("idser", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("flagonlyfiscalabatement", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ivaamount", typeof(System.String)));
	T.Columns.Add( new DataColumn("certificatekind", typeof(System.String)));
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("flagapplyabatements", typeof(System.String)));
	T.Columns.Add( new DataColumn("idmotive", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("itinerationvisible", typeof(System.String)));
	T.Columns.Add( new DataColumn("codeser", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idser"]};


	//////////////////// motive770service /////////////////////////////////
	T= new DataTable("motive770service");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idser", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idmot", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("!tipoprestazione", typeof(System.String)));
	T.Columns.Add( new DataColumn("!causale770", typeof(System.String)));
	T.Columns.Add( new DataColumn("annotation", typeof(System.String)));
	T.Columns.Add( new DataColumn("exemptioncode", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("socialseccode", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idser"]};


	//////////////////// mod770_exemptioncode /////////////////////////////////
	T= new DataTable("mod770_exemptioncode");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("exemptioncode", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["exemptioncode"]};


	//////////////////// motive770 /////////////////////////////////
	T= new DataTable("motive770");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idmot", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["idmot"]};


	//////////////////// mod770_socialsecuritycode /////////////////////////////////
	T= new DataTable("mod770_socialsecuritycode");
	C= new DataColumn("ayear", typeof(System.Int16));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("socialseccode", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ct", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(System.String)));
	T.Columns.Add( new DataColumn("description", typeof(System.String)));
	T.Columns.Add( new DataColumn("lt", typeof(System.DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(System.String)));
	T.Columns.Add( new DataColumn("cfagency", typeof(System.String)));
	T.Columns.Add( new DataColumn("titleagency", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["ayear"], T.Columns["socialseccode"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[2]{mod770_exemptioncode.Columns["ayear"], mod770_exemptioncode.Columns["exemptioncode"]};
	CChild = new DataColumn[2]{motive770service.Columns["ayear"], motive770service.Columns["exemptioncode"]};
	Relations.Add(new DataRelation("mod770_exemptioncode_motive770service",CPar,CChild,false));

	CPar = new DataColumn[1]{service.Columns["idser"]};
	CChild = new DataColumn[1]{motive770service.Columns["idser"]};
	Relations.Add(new DataRelation("servicemotive770service",CPar,CChild,false));

	CPar = new DataColumn[2]{motive770.Columns["ayear"], motive770.Columns["idmot"]};
	CChild = new DataColumn[2]{motive770service.Columns["ayear"], motive770service.Columns["idmot"]};
	Relations.Add(new DataRelation("motive770_motive770service",CPar,CChild,false));

	CPar = new DataColumn[2]{mod770_socialsecuritycode.Columns["ayear"], mod770_socialsecuritycode.Columns["socialseccode"]};
	CChild = new DataColumn[2]{motive770service.Columns["ayear"], motive770service.Columns["socialseccode"]};
	Relations.Add(new DataRelation("mod770_socialsecuritycode_motive770service",CPar,CChild,false));

	#endregion

}
}
}
