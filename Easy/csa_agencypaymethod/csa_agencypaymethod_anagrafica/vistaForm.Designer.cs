/*
    Easy
    Copyright (C) 2019 Universit� degli Studi di Catania (www.unict.it)

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
namespace csa_agencypaymethod_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Modalità pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypaymethod 		=> Tables["registrypaymethod"];

	///<summary>
	///Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable bank 		=> Tables["bank"];

	///<summary>
	///Sportello Banca
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable cab 		=> Tables["cab"];

	///<summary>
	///Modalità di pagamento
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable paymethod 		=> Tables["paymethod"];

	///<summary>
	///Anagrafica
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	///<summary>
	///Modalità pagamento Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agencypaymethod 		=> Tables["csa_agencypaymethod"];

	///<summary>
	///Ente CSA
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable csa_agency 		=> Tables["csa_agency"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable deputy 		=> Tables["deputy"];

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
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tpaymethod.Columns.Add(C);
	tpaymethod.Columns.Add( new DataColumn("methodbankcode", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("allowdeputy", typeof(string)));
	tpaymethod.Columns.Add( new DataColumn("footerpaymentadvice", typeof(string)));
	Tables.Add(tpaymethod);
	tpaymethod.PrimaryKey =  new DataColumn[]{tpaymethod.Columns["idpaymethod"]};


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


	//////////////////// CSA_AGENCYPAYMETHOD /////////////////////////////////
	var tcsa_agencypaymethod= new DataTable("csa_agencypaymethod");
	C= new DataColumn("idcsa_agency", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("idcsa_agencypaymethod", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("vocecsa", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agencypaymethod.Columns.Add(C);
	tcsa_agencypaymethod.Columns.Add( new DataColumn("idreg", typeof(int)));
	Tables.Add(tcsa_agencypaymethod);
	tcsa_agencypaymethod.PrimaryKey =  new DataColumn[]{tcsa_agencypaymethod.Columns["idcsa_agency"], tcsa_agencypaymethod.Columns["idcsa_agencypaymethod"]};


	//////////////////// CSA_AGENCY /////////////////////////////////
	var tcsa_agency= new DataTable("csa_agency");
	C= new DataColumn("idcsa_agency", typeof(int));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("ente", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("isinternal", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcsa_agency.Columns.Add(C);
	Tables.Add(tcsa_agency);
	tcsa_agency.PrimaryKey =  new DataColumn[]{tcsa_agency.Columns["idcsa_agency"]};


	//////////////////// DEPUTY /////////////////////////////////
	var tdeputy= new DataTable("deputy");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	tdeputy.Columns.Add( new DataColumn("cf", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("p_iva", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	tdeputy.Columns.Add( new DataColumn("annotation", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tdeputy.Columns.Add( new DataColumn("gender", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("surname", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("forename", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	tdeputy.Columns.Add( new DataColumn("txt", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tdeputy.Columns.Add(C);
	tdeputy.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("idcity", typeof(int)));
	tdeputy.Columns.Add( new DataColumn("idnation", typeof(int)));
	tdeputy.Columns.Add( new DataColumn("location", typeof(string)));
	tdeputy.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	Tables.Add(tdeputy);
	tdeputy.PrimaryKey =  new DataColumn[]{tdeputy.Columns["idreg"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registrypaymethod.Columns["idreg"], registrypaymethod.Columns["idregistrypaymethod"]};
	var cChild = new []{csa_agencypaymethod.Columns["idregistrypaymethod"], csa_agencypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registrypaymethod_csa_agencypaymethod",cPar,cChild,false));

	cPar = new []{csa_agency.Columns["idcsa_agency"]};
	cChild = new []{csa_agencypaymethod.Columns["idcsa_agency"]};
	Relations.Add(new DataRelation("csa_agency_csa_agencypaymethod",cPar,cChild,false));

	cPar = new []{bank.Columns["idbank"]};
	cChild = new []{cab.Columns["idbank"]};
	Relations.Add(new DataRelation("bankcab",cPar,cChild,false));

	cPar = new []{paymethod.Columns["idpaymethod"]};
	cChild = new []{registrypaymethod.Columns["idpaymethod"]};
	Relations.Add(new DataRelation("paymethodregistrypaymethod",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registryregistrypaymethod",cPar,cChild,false));

	cPar = new []{deputy.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["iddeputy"]};
	Relations.Add(new DataRelation("deputy_registrypaymethod",cPar,cChild,false));

	cPar = new []{bank.Columns["idbank"]};
	cChild = new []{registrypaymethod.Columns["idbank"]};
	Relations.Add(new DataRelation("bankregistrypaymethod",cPar,cChild,false));

	cPar = new []{cab.Columns["idbank"], cab.Columns["idcab"]};
	cChild = new []{registrypaymethod.Columns["idbank"], registrypaymethod.Columns["idcab"]};
	Relations.Add(new DataRelation("cabregistrypaymethod",cPar,cChild,false));

	#endregion

}
}
}
