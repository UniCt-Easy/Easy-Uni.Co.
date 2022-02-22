
/*
Easy
Copyright (C) 2022 Universit� degli Studi di Catania (www.unict.it)
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
namespace csapaymethodlookup_lista {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaForm: System.Data.DataSet {

	#region Table members declaration
	///<summary>
	///Modalità di pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable paymethod		{get { return Tables["paymethod"];}}
	///<summary>
	///Look-up modalità di pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable csapaymethodlookup		{get { return Tables["csapaymethodlookup"];}}
	///<summary>
	///Trattamento delle spese
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable chargehandling		{get { return Tables["chargehandling"];}}
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
	//////////////////// paymethod /////////////////////////////////
	T= new DataTable("paymethod");
	C= new DataColumn("idpaymethod", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
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
	T.Columns.Add( new DataColumn("methodbankcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	T.Columns.Add( new DataColumn("allowdeputy", typeof(System.String)));
	C= new DataColumn("flag", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("footerpaymentadvice", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idpaymethod"]};


	//////////////////// csapaymethodlookup /////////////////////////////////
	T= new DataTable("csapaymethodlookup");
	C= new DataColumn("idcsapaymethod", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("csa_kind", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("csa_description", typeof(System.String)));
	T.Columns.Add( new DataColumn("idpaymethod", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("!description", typeof(System.String)));
	T.Columns.Add( new DataColumn("idchargehandling", typeof(System.Int32)));
	T.Columns.Add( new DataColumn("flag", typeof(System.Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idcsapaymethod"]};


	//////////////////// chargehandling /////////////////////////////////
	T= new DataTable("chargehandling");
	T.Columns.Add( new DataColumn("active", typeof(System.String)));
	C= new DataColumn("ct", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("description", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(System.DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(System.String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("handlingbankcode", typeof(System.String)));
	T.Columns.Add( new DataColumn("flag", typeof(System.Int32)));
	C= new DataColumn("idchargehandling", typeof(System.Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("motive", typeof(System.String)));
	T.Columns.Add( new DataColumn("payment_kind", typeof(System.String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idchargehandling"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{paymethod.Columns["idpaymethod"]};
	CChild = new DataColumn[1]{csapaymethodlookup.Columns["idpaymethod"]};
	Relations.Add(new DataRelation("FK_paymethod_csapaymethodlookup",CPar,CChild,false));

	CPar = new DataColumn[1]{chargehandling.Columns["idchargehandling"]};
	CChild = new DataColumn[1]{csapaymethodlookup.Columns["idchargehandling"]};
	Relations.Add(new DataRelation("chargehandling_csapaymethodlookup",CPar,CChild,false));

	#endregion

}
}
}
