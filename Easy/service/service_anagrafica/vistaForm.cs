
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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace service_anagrafica {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("vistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public class vistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Tipi di ritenuta
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable tax 		=> Tables["tax"];

	///<summary>
	///associazione prestazione - ritenute
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable servicetax 		=> Tables["servicetax"];

	///<summary>
	///Certificazione Fiscale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable certificationmodel 		=> Tables["certificationmodel"];

	///<summary>
	///Causali per il mod. 770
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable motive770 		=> Tables["motive770"];

	///<summary>
	///Abbinamento prestazione con la causale del modello 770
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable motive770service 		=> Tables["motive770service"];

	///<summary>
	///Tipo Prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable service 		=> Tables["service"];

	///<summary>
	///classificazione tipi prestazione
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable servicesorting 		=> Tables["servicesorting"];

	///<summary>
	///Classificazione Movimenti
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sorting 		=> Tables["sorting"];

	///<summary>
	///Voci di Comunicazione 8000
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000 		=> Tables["voce8000"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000_s 		=> Tables["voce8000_s"];

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable voce8000_s1 		=> Tables["voce8000_s1"];

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
	//////////////////// TAX /////////////////////////////////
	var ttax= new DataTable("tax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	ttax.Columns.Add( new DataColumn("taxref", typeof(string)));
	ttax.Columns.Add( new DataColumn("taxkind", typeof(short)));
	ttax.Columns.Add( new DataColumn("fiscaltaxcode", typeof(string)));
	ttax.Columns.Add( new DataColumn("flagunabatable", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	ttax.Columns.Add(C);
	Tables.Add(ttax);
	ttax.PrimaryKey =  new DataColumn[]{ttax.Columns["taxcode"]};


	//////////////////// SERVICETAX /////////////////////////////////
	var tservicetax= new DataTable("servicetax");
	C= new DataColumn("taxcode", typeof(int));
	C.AllowDBNull=false;
	tservicetax.Columns.Add(C);
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservicetax.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservicetax.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservicetax.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservicetax.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservicetax.Columns.Add(C);
	Tables.Add(tservicetax);
	tservicetax.PrimaryKey =  new DataColumn[]{tservicetax.Columns["taxcode"], tservicetax.Columns["idser"]};


	//////////////////// CERTIFICATIONMODEL /////////////////////////////////
	var tcertificationmodel= new DataTable("certificationmodel");
	C= new DataColumn("idcertificationmodel", typeof(string));
	C.AllowDBNull=false;
	tcertificationmodel.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tcertificationmodel.Columns.Add(C);
	tcertificationmodel.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tcertificationmodel.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tcertificationmodel);
	tcertificationmodel.PrimaryKey =  new DataColumn[]{tcertificationmodel.Columns["idcertificationmodel"]};


	//////////////////// MOTIVE770 /////////////////////////////////
	var tmotive770= new DataTable("motive770");
	C= new DataColumn("idmot", typeof(string));
	C.AllowDBNull=false;
	tmotive770.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tmotive770.Columns.Add(C);
	tmotive770.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tmotive770.Columns.Add( new DataColumn("cu", typeof(string)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tmotive770.Columns.Add(C);
	tmotive770.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tmotive770.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tmotive770);
	tmotive770.PrimaryKey =  new DataColumn[]{tmotive770.Columns["idmot"], tmotive770.Columns["ayear"]};


	//////////////////// MOTIVE770SERVICE /////////////////////////////////
	var tmotive770service= new DataTable("motive770service");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tmotive770service.Columns.Add(C);
	C= new DataColumn("ayear", typeof(short));
	C.AllowDBNull=false;
	tmotive770service.Columns.Add(C);
	C= new DataColumn("idmot", typeof(string));
	C.AllowDBNull=false;
	tmotive770service.Columns.Add(C);
	tmotive770service.Columns.Add( new DataColumn("ct", typeof(DateTime)));
	tmotive770service.Columns.Add( new DataColumn("cu", typeof(string)));
	tmotive770service.Columns.Add( new DataColumn("lt", typeof(DateTime)));
	tmotive770service.Columns.Add( new DataColumn("lu", typeof(string)));
	Tables.Add(tmotive770service);
	tmotive770service.PrimaryKey =  new DataColumn[]{tmotive770service.Columns["idser"], tmotive770service.Columns["ayear"]};


	//////////////////// SERVICE /////////////////////////////////
	var tservice= new DataTable("service");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("codeser", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("flagonlyfiscalabatement", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("ivaamount", typeof(string)));
	tservice.Columns.Add( new DataColumn("certificatekind", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservice.Columns.Add(C);
	tservice.Columns.Add( new DataColumn("active", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagapplyabatements", typeof(string)));
	tservice.Columns.Add( new DataColumn("idmotive", typeof(int)));
	tservice.Columns.Add( new DataColumn("itinerationvisible", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagalwaysinfiscalmodels", typeof(string)));
	tservice.Columns.Add( new DataColumn("module", typeof(string)));
	tservice.Columns.Add( new DataColumn("allowedit", typeof(string)));
	tservice.Columns.Add( new DataColumn("rec770kind", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagneedbalance", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagforeign", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000", typeof(string)));
	tservice.Columns.Add( new DataColumn("webdefault", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdistraint", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000refund_i", typeof(string)));
	tservice.Columns.Add( new DataColumn("voce8000refund_e", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagcsausability", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagnoexemptionquote", typeof(string)));
	tservice.Columns.Add( new DataColumn("flagdalia", typeof(string)));
	tservice.Columns.Add( new DataColumn("servicecode770", typeof(string)));
	tservice.Columns.Add( new DataColumn("requested_doc", typeof(int)));
	tservice.Columns.Add( new DataColumn("flagnoncumula", typeof(string)));
	Tables.Add(tservice);
	tservice.PrimaryKey =  new DataColumn[]{tservice.Columns["idser"]};


	//////////////////// SERVICESORTING /////////////////////////////////
	var tservicesorting= new DataTable("servicesorting");
	C= new DataColumn("idser", typeof(int));
	C.AllowDBNull=false;
	tservicesorting.Columns.Add(C);
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tservicesorting.Columns.Add(C);
	tservicesorting.Columns.Add( new DataColumn("quota", typeof(decimal)));
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tservicesorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tservicesorting.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tservicesorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tservicesorting.Columns.Add(C);
	tservicesorting.Columns.Add( new DataColumn("!codiceclass", typeof(string)));
	tservicesorting.Columns.Add( new DataColumn("!descrizione", typeof(string)));
	Tables.Add(tservicesorting);
	tservicesorting.PrimaryKey =  new DataColumn[]{tservicesorting.Columns["idser"], tservicesorting.Columns["idsor"]};


	//////////////////// SORTING /////////////////////////////////
	var tsorting= new DataTable("sorting");
	C= new DataColumn("idsor", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("idsorkind", typeof(int));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("defaultN1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultN5", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultS1", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS2", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS3", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS4", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultS5", typeof(string)));
	tsorting.Columns.Add( new DataColumn("defaultv1", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv2", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv3", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv4", typeof(decimal)));
	tsorting.Columns.Add( new DataColumn("defaultv5", typeof(decimal)));
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("flagnodate", typeof(string)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("movkind", typeof(string)));
	C= new DataColumn("nlevel", typeof(byte));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("paridsor", typeof(int)));
	tsorting.Columns.Add( new DataColumn("printingorder", typeof(string)));
	tsorting.Columns.Add( new DataColumn("rtf", typeof(Byte[])));
	C= new DataColumn("sortcode", typeof(string));
	C.AllowDBNull=false;
	tsorting.Columns.Add(C);
	tsorting.Columns.Add( new DataColumn("txt", typeof(string)));
	Tables.Add(tsorting);
	tsorting.PrimaryKey =  new DataColumn[]{tsorting.Columns["idsor"]};


	//////////////////// VOCE8000 /////////////////////////////////
	var tvoce8000= new DataTable("voce8000");
	C= new DataColumn("voce", typeof(string));
	C.AllowDBNull=false;
	tvoce8000.Columns.Add(C);
	tvoce8000.Columns.Add( new DataColumn("description", typeof(string)));
	tvoce8000.Columns.Add( new DataColumn("active", typeof(string)));
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
	tvoce8000.Columns.Add( new DataColumn("kind", typeof(string)));
	tvoce8000.Columns.Add( new DataColumn("capitolo", typeof(string)));
	Tables.Add(tvoce8000);
	tvoce8000.PrimaryKey =  new DataColumn[]{tvoce8000.Columns["voce"]};


	//////////////////// VOCE8000_S /////////////////////////////////
	var tvoce8000_s= new DataTable("voce8000_s");
	C= new DataColumn("voce", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_s.Columns.Add(C);
	tvoce8000_s.Columns.Add( new DataColumn("description", typeof(string)));
	tvoce8000_s.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_s.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_s.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_s.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_s.Columns.Add(C);
	tvoce8000_s.Columns.Add( new DataColumn("kind", typeof(string)));
	Tables.Add(tvoce8000_s);
	tvoce8000_s.PrimaryKey =  new DataColumn[]{tvoce8000_s.Columns["voce"]};


	//////////////////// VOCE8000_S1 /////////////////////////////////
	var tvoce8000_s1= new DataTable("voce8000_s1");
	C= new DataColumn("voce", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_s1.Columns.Add(C);
	tvoce8000_s1.Columns.Add( new DataColumn("description", typeof(string)));
	tvoce8000_s1.Columns.Add( new DataColumn("active", typeof(string)));
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_s1.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_s1.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tvoce8000_s1.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tvoce8000_s1.Columns.Add(C);
	tvoce8000_s1.Columns.Add( new DataColumn("kind", typeof(string)));
	Tables.Add(tvoce8000_s1);
	tvoce8000_s1.PrimaryKey =  new DataColumn[]{tvoce8000_s1.Columns["voce"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sorting.Columns["idsor"]};
	var cChild = new []{servicesorting.Columns["idsor"]};
	Relations.Add(new DataRelation("sortingservicesorting",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{servicesorting.Columns["idser"]};
	Relations.Add(new DataRelation("serviceservicesorting",cPar,cChild,false));

	cPar = new []{voce8000.Columns["voce"]};
	cChild = new []{service.Columns["voce8000"]};
	Relations.Add(new DataRelation("FK_voce8000_service",cPar,cChild,false));

	cPar = new []{certificationmodel.Columns["idcertificationmodel"]};
	cChild = new []{service.Columns["certificatekind"]};
	Relations.Add(new DataRelation("certificationmodelservice",cPar,cChild,false));

	cPar = new []{voce8000_s.Columns["voce"]};
	cChild = new []{service.Columns["voce8000refund_i"]};
	Relations.Add(new DataRelation("voce8000_s_service",cPar,cChild,false));

	cPar = new []{voce8000_s1.Columns["voce"]};
	cChild = new []{service.Columns["voce8000refund_e"]};
	Relations.Add(new DataRelation("voce8000_s1_service",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{motive770service.Columns["idser"]};
	Relations.Add(new DataRelation("servicemotive770service",cPar,cChild,false));

	cPar = new []{motive770.Columns["idmot"], motive770.Columns["ayear"]};
	cChild = new []{motive770service.Columns["idmot"], motive770service.Columns["ayear"]};
	Relations.Add(new DataRelation("motive770motive770service",cPar,cChild,false));

	cPar = new []{service.Columns["idser"]};
	cChild = new []{servicetax.Columns["idser"]};
	Relations.Add(new DataRelation("serviceservicetax",cPar,cChild,false));

	cPar = new []{tax.Columns["taxcode"]};
	cChild = new []{servicetax.Columns["taxcode"]};
	Relations.Add(new DataRelation("taxservicetax",cPar,cChild,false));

	#endregion

}
}
}
