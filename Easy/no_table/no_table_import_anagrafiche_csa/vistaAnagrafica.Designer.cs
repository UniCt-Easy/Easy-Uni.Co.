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
using System.Globalization;
using System.Runtime.Serialization;
#pragma warning disable 1591
namespace no_table_import_anagrafiche_csa {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("vistaAnagrafica")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class vistaAnagrafica: DataSet {

	#region Table members declaration
	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registry		{get { return Tables["registry"];}}
	///<summary>
	///Indirizzo di anagrafica
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registryaddress		{get { return Tables["registryaddress"];}}
	///<summary>
	///Modalità pagamento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registrypaymethod		{get { return Tables["registrypaymethod"];}}
	///<summary>
	///Inquadramento
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registrylegalstatus		{get { return Tables["registrylegalstatus"];}}
	///<summary>
	///Reddito Annuo Presunto
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable registrytaxablestatus		{get { return Tables["registrytaxablestatus"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public vistaAnagrafica(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected vistaAnagrafica (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "vistaAnagrafica";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaAnagrafica.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	T= new DataTable("registry");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("active", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("annotation", typeof(String)));
	T.Columns.Add( new DataColumn("badgecode", typeof(String)));
	T.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cf", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("extmatricula", typeof(String)));
	T.Columns.Add( new DataColumn("foreigncf", typeof(String)));
	T.Columns.Add( new DataColumn("forename", typeof(String)));
	T.Columns.Add( new DataColumn("gender", typeof(String)));
	T.Columns.Add( new DataColumn("idcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcentralizedcategory", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idmaritalstatus", typeof(String)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("idregistryclass", typeof(String)));
	T.Columns.Add( new DataColumn("idtitle", typeof(String)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("maritalsurname", typeof(String)));
	T.Columns.Add( new DataColumn("p_iva", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("surname", typeof(String)));
	C= new DataColumn("title", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	C= new DataColumn("residence", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("idregistrykind", typeof(Int32)));
	T.Columns.Add( new DataColumn("authorization_free", typeof(String)));
	T.Columns.Add( new DataColumn("multi_cf", typeof(String)));
	T.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"]};


	//////////////////// REGISTRYADDRESS /////////////////////////////////
	T= new DataTable("registryaddress");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("address", typeof(String)));
	T.Columns.Add( new DataColumn("annotations", typeof(String)));
	T.Columns.Add( new DataColumn("cap", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("flagforeign", typeof(String)));
	T.Columns.Add( new DataColumn("idcity", typeof(Int32)));
	T.Columns.Add( new DataColumn("idnation", typeof(Int32)));
	T.Columns.Add( new DataColumn("location", typeof(String)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("officename", typeof(String)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idaddresskind", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"], T.Columns["start"], T.Columns["idaddresskind"]};


	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	T= new DataTable("registrypaymethod");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("idregistrypaymethod", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("regmodcode", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("cc", typeof(String)));
	T.Columns.Add( new DataColumn("cin", typeof(String)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("cu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("flagstandard", typeof(String)));
	T.Columns.Add( new DataColumn("iban", typeof(String)));
	T.Columns.Add( new DataColumn("idbank", typeof(String)));
	T.Columns.Add( new DataColumn("idcab", typeof(String)));
	T.Columns.Add( new DataColumn("iddeputy", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("paymentdescr", typeof(String)));
	T.Columns.Add( new DataColumn("paymentexpiring", typeof(Int16)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("refexternaldoc", typeof(String)));
	T.Columns.Add( new DataColumn("idcurrency", typeof(Int32)));
	T.Columns.Add( new DataColumn("idpaymethod", typeof(Int32)));
	T.Columns.Add( new DataColumn("idexpirationkind", typeof(Int16)));
	T.Columns.Add( new DataColumn("flag", typeof(Int32)));
	T.Columns.Add( new DataColumn("idchargehandling", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"], T.Columns["idregistrypaymethod"]};


	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	T= new DataTable("registrylegalstatus");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
	T.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	T.Columns.Add( new DataColumn("cu", typeof(String)));
	T.Columns.Add( new DataColumn("incomeclass", typeof(Int16)));
	T.Columns.Add( new DataColumn("incomeclassvalidity", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	T.Columns.Add( new DataColumn("lu", typeof(String)));
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	T.Columns.Add( new DataColumn("idposition", typeof(Int32)));
	T.Columns.Add( new DataColumn("csa_compartment", typeof(String)));
	T.Columns.Add( new DataColumn("csa_role", typeof(String)));
	T.Columns.Add( new DataColumn("csa_class", typeof(String)));
	T.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idregistrylegalstatus", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("iddaliaposition", typeof(Int32)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"], T.Columns["idregistrylegalstatus"]};


	//////////////////// REGISTRYTAXABLESTATUS /////////////////////////////////
	T= new DataTable("registrytaxablestatus");
	C= new DataColumn("idreg", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("active", typeof(String)));
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
	T.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	T.Columns.Add( new DataColumn("supposedincome", typeof(Decimal)));
	T.Columns.Add( new DataColumn("txt", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idreg"], T.Columns["start"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{registrytaxablestatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrytaxablestatus",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registrylegalstatus",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registrypaymethod",CPar,CChild,false));

	CPar = new DataColumn[1]{registry.Columns["idreg"]};
	CChild = new DataColumn[1]{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registryaddress",CPar,CChild,false));

	#endregion

}
}
}
