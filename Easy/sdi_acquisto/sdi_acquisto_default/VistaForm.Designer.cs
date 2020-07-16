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
using System.Runtime.Serialization;
#pragma warning disable 1591
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedMember.Global
namespace sdi_acquisto_default {
[Serializable,DesignerCategory("code"),System.Xml.Serialization.XmlSchemaProvider("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRoot("VistaForm"),System.ComponentModel.Design.HelpKeyword("vs.data.DataSet")]
public partial class VistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fattura Elettronica-Acquisto
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_acquisto 		=> Tables["sdi_acquisto"];

	///<summary>
	///Stato fattura in SDI
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable sdi_status 		=> Tables["sdi_status"];

	///<summary>
	///Configurazione Pluriennale
	///</summary>
	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),Browsable(false)]
	public DataTable uniconfig 		=> Tables["uniconfig"];

	#endregion


	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables => base.Tables;

	[DebuggerNonUserCode,DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
// ReSharper disable once MemberCanBePrivate.Global
	public new DataRelationCollection Relations => base.Relations;

[DebuggerNonUserCode]
public VistaForm(){
	BeginInit();
	initClass();
	EndInit();
}
[DebuggerNonUserCode]
protected VistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCode]
private void initClass() {
	DataSetName = "VistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaForm.xsd";

	#region create DataTables
	DataColumn C;
	//////////////////// SDI_ACQUISTO /////////////////////////////////
	var tsdi_acquisto= new DataTable("sdi_acquisto");
	C= new DataColumn("idsdi_acquisto", typeof(int));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	C= new DataColumn("filename", typeof(string));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	C= new DataColumn("zipfilename", typeof(string));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	C= new DataColumn("xml", typeof(string));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	tsdi_acquisto.Columns.Add( new DataColumn("identificativo_sdi", typeof(long)));
	tsdi_acquisto.Columns.Add( new DataColumn("mt", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("ec", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("ec_sent", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("se", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("dt", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("flag_unseen", typeof(int)));
	tsdi_acquisto.Columns.Add( new DataColumn("idsdi_status", typeof(short)));
	C= new DataColumn("position", typeof(int));
	C.AllowDBNull=false;
	tsdi_acquisto.Columns.Add(C);
	tsdi_acquisto.Columns.Add( new DataColumn("ec_number", typeof(int)));
	tsdi_acquisto.Columns.Add( new DataColumn("title", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("description", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("ninvoice", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("codice_ipa", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("total", typeof(decimal)));
	tsdi_acquisto.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	tsdi_acquisto.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("mt_prot", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("ec_prot", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("se_prot", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("dt_prot", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("rejectreason", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("utente_accettata", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("utente_rifiutata", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("data_accettata", typeof(DateTime)));
	tsdi_acquisto.Columns.Add( new DataColumn("data_rifiutata", typeof(DateTime)));
	tsdi_acquisto.Columns.Add( new DataColumn("total_easy", typeof(decimal)));
	tsdi_acquisto.Columns.Add( new DataColumn("tipodocumento", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("notcreacontabilita", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("notcreacontabilitareason", typeof(string)));
	tsdi_acquisto.Columns.Add( new DataColumn("signedxml", typeof(string)));
	Tables.Add(tsdi_acquisto);
	tsdi_acquisto.PrimaryKey =  new DataColumn[]{tsdi_acquisto.Columns["idsdi_acquisto"]};


	//////////////////// SDI_STATUS /////////////////////////////////
	var tsdi_status= new DataTable("sdi_status");
	C= new DataColumn("idsdi_status", typeof(short));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("ct", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("cu", typeof(string));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("description", typeof(string));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	tsdi_status.Columns.Add( new DataColumn("listingorder", typeof(int)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	C= new DataColumn("lu", typeof(string));
	C.AllowDBNull=false;
	tsdi_status.Columns.Add(C);
	Tables.Add(tsdi_status);
	tsdi_status.PrimaryKey =  new DataColumn[]{tsdi_status.Columns["idsdi_status"]};


	//////////////////// UNICONFIG /////////////////////////////////
	var tuniconfig= new DataTable("uniconfig");
	C= new DataColumn("dummykey", typeof(int));
	C.AllowDBNull=false;
	tuniconfig.Columns.Add(C);
	tuniconfig.Columns.Add( new DataColumn("expensefinphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("incomefinphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("expenseregphase", typeof(byte)));
	tuniconfig.Columns.Add( new DataColumn("incomeregphase", typeof(byte)));
	C= new DataColumn("flagresearchagency", typeof(string));
	C.AllowDBNull=false;
	tuniconfig.Columns.Add(C);
	tuniconfig.Columns.Add( new DataColumn("idsorkind01", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind02", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind03", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind04", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("idsorkind05", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("sorkind01asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind02asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind03asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind04asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("sorkind05asfilter", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("tree_upb_withdescr", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("flag", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("ep360days", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("idente", typeof(int)));
	tuniconfig.Columns.Add( new DataColumn("publicagency", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("ssn_codasl", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("ssn_codregione", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("ssn_codssa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_provinceoffice", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_number", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_socialcapital", typeof(decimal)));
	tuniconfig.Columns.Add( new DataColumn("rea_partner", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("rea_closingstatus", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codicepaipa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codiceaoopa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codiceuopa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("perla_codicefiscalepa", typeof(string)));
	tuniconfig.Columns.Add( new DataColumn("webprotaddress", typeof(string)));
	Tables.Add(tuniconfig);
	tuniconfig.PrimaryKey =  new DataColumn[]{tuniconfig.Columns["dummykey"]};


	#endregion


	#region DataRelation creation
	var cPar = new []{sdi_status.Columns["idsdi_status"]};
	var cChild = new []{sdi_acquisto.Columns["idsdi_status"]};
	Relations.Add(new DataRelation("FK_sdi_status_sdi_acquisto",cPar,cChild,false));

	#endregion

}
}
}
