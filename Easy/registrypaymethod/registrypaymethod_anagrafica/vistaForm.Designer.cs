
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
namespace registrypaymethod_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaForm: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypaymethod 		=> Tables["registrypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bank 		=> Tables["bank"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cab 		=> Tables["cab"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymethod 		=> Tables["paymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable expirationkind 		=> Tables["expirationkind"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable currency 		=> Tables["currency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable chargehandling 		=> Tables["chargehandling"];

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
	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new DataTable("registrypaymethod");
	C= new DataColumn("regmodcode", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("cin", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idbank", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcab", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("flagstandard", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("iban", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("extracode", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("biccode", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("flag", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("notes", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("ccdedicato_doc", typeof(Byte[])));
	tregistrypaymethod.Columns.Add( new DataColumn("ccdedicato_cf", typeof(Byte[])));
	tregistrypaymethod.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("ccdedicato_stop", typeof(DateTime)));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.PrimaryKey =  new DataColumn[]{tregistrypaymethod.Columns["idreg"], tregistrypaymethod.Columns["idregistrypaymethod"]};


	//////////////////// BANK /////////////////////////////////
	var tbank= new DataTable("bank");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tbank.Columns.Add(C);
	Tables.Add(tbank);
	tbank.PrimaryKey =  new DataColumn[]{tbank.Columns["idbank"]};


	//////////////////// CAB /////////////////////////////////
	var tcab= new DataTable("cab");
	C= new DataColumn("idbank", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("idcab", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcab.Columns.Add(C);
	tcab.Columns.Add( new DataColumn("flagusable", typeof(string)));
	Tables.Add(tcab);
	tcab.PrimaryKey =  new DataColumn[]{tcab.Columns["idbank"], tcab.Columns["idcab"]};


	//////////////////// PAYMETHOD /////////////////////////////////
	var tpaymethod= new DataTable("paymethod");
	C= new DataColumn("idpaymethod", typeof(int));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	tpaymethod.Columns.Add( new DataColumn("methodbankcode", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("allowdeputy", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("footerpaymentadvice", typeof(string)));
	Tables.Add(tpaymethod);
	tpaymethod.PrimaryKey =  new DataColumn[]{tpaymethod.Columns["idpaymethod"]};


	//////////////////// EXPIRATIONKIND /////////////////////////////////
	var texpirationkind= new DataTable("expirationkind");
	C= new DataColumn("idexpirationkind", typeof(short));
	C.AllowDBNull=false;
	texpirationkind.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	texpirationkind.Columns.Add(C);
	texpirationkind.Columns.Add( new DataColumn("active", typeof(string)));
	Tables.Add(texpirationkind);
	texpirationkind.PrimaryKey =  new DataColumn[]{texpirationkind.Columns["idexpirationkind"]};


	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// CURRENCY /////////////////////////////////
	var tcurrency= new DataTable("currency");
	C= new DataColumn("idcurrency", typeof(int));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcurrency.Columns.Add(C);
	Tables.Add(tcurrency);
	tcurrency.PrimaryKey =  new DataColumn[]{tcurrency.Columns["idcurrency"]};


	//////////////////// CHARGEHANDLING /////////////////////////////////
	var tchargehandling= new DataTable("chargehandling");
	tchargehandling.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	tchargehandling.Columns.Add( new DataColumn("handlingbankcode", typeof(string)));
	tchargehandling.Columns.Add( new DataColumn("flag", typeof(int)));
	C= new DataColumn("idchargehandling", typeof(int));
	C.AllowDBNull=false;
	tchargehandling.Columns.Add(C);
	tchargehandling.Columns.Add( new DataColumn("motive", typeof(string)));
	tchargehandling.Columns.Add( new DataColumn("payment_kind", typeof(string)));
	Tables.Add(tchargehandling);
	tchargehandling.PrimaryKey =  new DataColumn[]{tchargehandling.Columns["idchargehandling"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{bank.Columns["idbank"]};
	var cChild = new []{cab.Columns["idbank"]};
	Relations.Add(new DataRelation("bankcab",cPar,cChild,false));

	cPar = new []{paymethod.Columns["idpaymethod"]};
	cChild = new []{registrypaymethod.Columns["idpaymethod"]};
	Relations.Add(new DataRelation("paymethodregistrypaymethod",cPar,cChild,false));

	cPar = new []{bank.Columns["idbank"]};
	cChild = new []{registrypaymethod.Columns["idbank"]};
	Relations.Add(new DataRelation("bankregistrypaymethod",cPar,cChild,false));

	cPar = new []{cab.Columns["idbank"], cab.Columns["idcab"]};
	cChild = new []{registrypaymethod.Columns["idbank"], registrypaymethod.Columns["idcab"]};
	Relations.Add(new DataRelation("cabregistrypaymethod",cPar,cChild,false));

	cPar = new []{expirationkind.Columns["idexpirationkind"]};
	cChild = new []{registrypaymethod.Columns["idexpirationkind"]};
	Relations.Add(new DataRelation("expirationkindregistrypaymethod",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["iddeputy"]};
	Relations.Add(new DataRelation("registryregistrypaymethod",cPar,cChild,false));

	cPar = new []{currency.Columns["idcurrency"]};
	cChild = new []{registrypaymethod.Columns["idcurrency"]};
	Relations.Add(new DataRelation("currency_registrypaymethod",cPar,cChild,false));

	cPar = new []{chargehandling.Columns["idchargehandling"]};
	cChild = new []{registrypaymethod.Columns["idchargehandling"]};
	Relations.Add(new DataRelation("chargehandling_registrypaymethod",cPar,cChild,false));

	#endregion

}
}
}
