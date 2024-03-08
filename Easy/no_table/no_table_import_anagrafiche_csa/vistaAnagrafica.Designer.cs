
/*
Easy
Copyright (C) 2024 Università degli Studi di Catania (www.unict.it)
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
namespace no_table_import_anagrafiche_csa {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaAnagrafica"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class vistaAnagrafica: DataSet {

	#region Table members declaration
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry 		=> Tables["registry"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registryaddress 		=> Tables["registryaddress"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrypaymethod 		=> Tables["registrypaymethod"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrylegalstatus 		=> Tables["registrylegalstatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registrytaxablestatus 		=> Tables["registrytaxablestatus"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_amministrativi 		=> Tables["registry_amministrativi"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable registry_docenti 		=> Tables["registry_docenti"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public vistaAnagrafica(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected vistaAnagrafica (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "vistaAnagrafica";
	Prefix = "";
	Namespace = "http://tempuri.org/vistaAnagrafica.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// REGISTRY /////////////////////////////////
	var tregistry= new DataTable("registry");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("active", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("annotation", typeof(string)));
	tregistry.Columns.Add( new DataColumn("badgecode", typeof(string)));
	tregistry.Columns.Add( new DataColumn("birthdate", typeof(DateTime)));
	tregistry.Columns.Add( new DataColumn("cf", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("extmatricula", typeof(string)));
	tregistry.Columns.Add( new DataColumn("foreigncf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("forename", typeof(string)));
	tregistry.Columns.Add( new DataColumn("gender", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcentralizedcategory", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idmaritalstatus", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistry.Columns.Add( new DataColumn("idregistryclass", typeof(string)));
	tregistry.Columns.Add( new DataColumn("idtitle", typeof(string)));
	tregistry.Columns.Add( new DataColumn("location", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("maritalsurname", typeof(string)));
	tregistry.Columns.Add( new DataColumn("p_iva", typeof(string)));
	tregistry.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistry.Columns.Add( new DataColumn("surname", typeof(string)));
	C= new DataColumn("title", typeof(string));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("txt", typeof(string)));
	C= new DataColumn("residence", typeof(int));
	C.AllowDBNull=false;
	tregistry.Columns.Add(C);
	tregistry.Columns.Add( new DataColumn("idregistrykind", typeof(int)));
	tregistry.Columns.Add( new DataColumn("authorization_free", typeof(string)));
	tregistry.Columns.Add( new DataColumn("multi_cf", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flagbankitaliaproceeds", typeof(string)));
	tregistry.Columns.Add( new DataColumn("flag_pa", typeof(string)));
	tregistry.Columns.Add( new DataColumn("sdi_norifamm", typeof(string)));
	Tables.Add(tregistry);
	tregistry.PrimaryKey =  new DataColumn[]{tregistry.Columns["idreg"]};


	//////////////////// REGISTRYADDRESS /////////////////////////////////
	var tregistryaddress= new DataTable("registryaddress");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	tregistryaddress.Columns.Add( new DataColumn("active", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("address", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("annotations", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("cap", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("idcity", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("idnation", typeof(int)));
	tregistryaddress.Columns.Add( new DataColumn("location", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistryaddress.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("officename", typeof(string)));
	tregistryaddress.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idaddresskind", typeof(int));
	C.AllowDBNull=false;
	tregistryaddress.Columns.Add(C);
	Tables.Add(tregistryaddress);
	tregistryaddress.PrimaryKey =  new DataColumn[]{tregistryaddress.Columns["idreg"], tregistryaddress.Columns["start"], tregistryaddress.Columns["idaddresskind"]};


	//////////////////// REGISTRYPAYMETHOD /////////////////////////////////
	var tregistrypaymethod= new DataTable("registrypaymethod");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("idregistrypaymethod", typeof(int));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("regmodcode", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("cin", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("flagstandard", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iban", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idbank", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcab", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("iddeputy", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrypaymethod.Columns.Add(C);
	tregistrypaymethod.Columns.Add( new DataColumn("paymentdescr", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("paymentexpiring", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrypaymethod.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("refexternaldoc", typeof(string)));
	tregistrypaymethod.Columns.Add( new DataColumn("idcurrency", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idpaymethod", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idexpirationkind", typeof(short)));
	tregistrypaymethod.Columns.Add( new DataColumn("flag", typeof(int)));
	tregistrypaymethod.Columns.Add( new DataColumn("idchargehandling", typeof(int)));
	Tables.Add(tregistrypaymethod);
	tregistrypaymethod.PrimaryKey =  new DataColumn[]{tregistrypaymethod.Columns["idreg"], tregistrypaymethod.Columns["idregistrypaymethod"]};


	//////////////////// REGISTRYLEGALSTATUS /////////////////////////////////
	var tregistrylegalstatus= new DataTable("registrylegalstatus");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("active", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclass", typeof(short)));
	tregistrylegalstatus.Columns.Add( new DataColumn("incomeclassvalidity", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistrylegalstatus.Columns.Add( new DataColumn("lu", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrylegalstatus.Columns.Add( new DataColumn("txt", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idposition", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_compartment", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_role", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("csa_class", typeof(string)));
	tregistrylegalstatus.Columns.Add( new DataColumn("stop", typeof(DateTime)));
	C= new DataColumn("idregistrylegalstatus", typeof(int));
	C.AllowDBNull=false;
	tregistrylegalstatus.Columns.Add(C);
	tregistrylegalstatus.Columns.Add( new DataColumn("iddaliaposition", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("livello", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("idinquadramento", typeof(int)));
	tregistrylegalstatus.Columns.Add( new DataColumn("flagdefault", typeof(string)));
	Tables.Add(tregistrylegalstatus);
	tregistrylegalstatus.PrimaryKey =  new DataColumn[]{tregistrylegalstatus.Columns["idreg"], tregistrylegalstatus.Columns["idregistrylegalstatus"]};


	//////////////////// REGISTRYTAXABLESTATUS /////////////////////////////////
	var tregistrytaxablestatus= new DataTable("registrytaxablestatus");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("start", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	tregistrytaxablestatus.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistrytaxablestatus.Columns.Add(C);
	tregistrytaxablestatus.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	tregistrytaxablestatus.Columns.Add( new DataColumn("supposedincome", typeof(decimal)));
	tregistrytaxablestatus.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tregistrytaxablestatus);
	tregistrytaxablestatus.PrimaryKey =  new DataColumn[]{tregistrytaxablestatus.Columns["idreg"], tregistrytaxablestatus.Columns["start"]};


	//////////////////// REGISTRY_AMMINISTRATIVI /////////////////////////////////
	var tregistry_amministrativi= new DataTable("registry_amministrativi");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_amministrativi.Columns.Add(C);
	tregistry_amministrativi.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tregistry_amministrativi.Columns.Add( new DataColumn("cu", typeof(string)));
	tregistry_amministrativi.Columns.Add( new DataColumn("cv", typeof(string)));
	tregistry_amministrativi.Columns.Add( new DataColumn("idcontrattokind", typeof(int)));
	tregistry_amministrativi.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tregistry_amministrativi.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tregistry_amministrativi);
	tregistry_amministrativi.PrimaryKey =  new DataColumn[]{tregistry_amministrativi.Columns["idreg"]};


	//////////////////// REGISTRY_DOCENTI /////////////////////////////////
	var tregistry_docenti= new DataTable("registry_docenti");
	C= new DataColumn("idreg", typeof(int));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	tregistry_docenti.Columns.Add( new DataColumn("soggiorno", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("matricola", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("idclassconsorsuale", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("cv", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("idsasd", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("ricevimento", typeof(string)));
	tregistry_docenti.Columns.Add( new DataColumn("idreg_istituti", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idlocation_struttura", typeof(int)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tregistry_docenti.Columns.Add(C);
	tregistry_docenti.Columns.Add( new DataColumn("idcontrattokind", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idfonteindicebibliometrico", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("idstruttura", typeof(int)));
	tregistry_docenti.Columns.Add( new DataColumn("indicebibliometrico", typeof(int)));
	Tables.Add(tregistry_docenti);
	tregistry_docenti.PrimaryKey =  new DataColumn[]{tregistry_docenti.Columns["idreg"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{registry.Columns["idreg"]};
	var cChild = new []{registrytaxablestatus.Columns["idreg"]};
	Relations.Add(new DataRelation("FK_registry_registrytaxablestatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrylegalstatus.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registrylegalstatus",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registrypaymethod.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registrypaymethod",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registryaddress.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registryaddress",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_docenti.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registry_docenti",cPar,cChild,false));

	cPar = new []{registry.Columns["idreg"]};
	cChild = new []{registry_amministrativi.Columns["idreg"]};
	Relations.Add(new DataRelation("registry_registry_amministrativi",cPar,cChild,false));

	#endregion

}
}
}
