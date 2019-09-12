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
namespace sdi_acquisto_default {
[Serializable()][DesignerCategoryAttribute("code")][System.Xml.Serialization.XmlSchemaProviderAttribute("GetTypedDataSetSchema")]
[System.Xml.Serialization.XmlRootAttribute("VistaForm")][System.ComponentModel.Design.HelpKeywordAttribute("vs.data.DataSet")]
public partial class VistaForm: DataSet {

	#region Table members declaration
	///<summary>
	///Fattura Elettronica-Acquisto
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sdi_acquisto		{get { return Tables["sdi_acquisto"];}}
	///<summary>
	///Stato fattura in SDI
	///</summary>
	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)][Browsable(false)]
	public DataTable sdi_status		{get { return Tables["sdi_status"];}}
	#endregion


	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataTableCollection Tables {get {return base.Tables;}}

	[DebuggerNonUserCodeAttribute()][DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
	public new DataRelationCollection Relations {get {return base.Relations; } } 

[DebuggerNonUserCodeAttribute()]
public VistaForm(){
	BeginInit();
	InitClass();
	EndInit();
}
[DebuggerNonUserCodeAttribute()]
protected VistaForm (SerializationInfo info,StreamingContext ctx):base(info,ctx) {}
[DebuggerNonUserCodeAttribute()]
private void InitClass() {
	DataSetName = "VistaForm";
	Prefix = "";
	Namespace = "http://tempuri.org/VistaForm.xsd";
	EnforceConstraints = false;

	#region create DataTables
	DataTable T;
	DataColumn C;
	//////////////////// SDI_ACQUISTO /////////////////////////////////
	T= new DataTable("sdi_acquisto");
	C= new DataColumn("idsdi_acquisto", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("filename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("zipfilename", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("adate", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("xml", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("identificativo_sdi", typeof(Int32)));
	T.Columns.Add( new DataColumn("mt", typeof(String)));
	T.Columns.Add( new DataColumn("ec", typeof(String)));
	T.Columns.Add( new DataColumn("ec_sent", typeof(String)));
	T.Columns.Add( new DataColumn("se", typeof(String)));
	T.Columns.Add( new DataColumn("dt", typeof(String)));
	T.Columns.Add( new DataColumn("flag_unseen", typeof(Int32)));
	T.Columns.Add( new DataColumn("idsdi_status", typeof(Int16)));
	C= new DataColumn("position", typeof(Int32));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	T.Columns.Add( new DataColumn("ec_number", typeof(Int32)));
	T.Columns.Add( new DataColumn("title", typeof(String)));
	T.Columns.Add( new DataColumn("description", typeof(String)));
	T.Columns.Add( new DataColumn("ninvoice", typeof(String)));
	T.Columns.Add( new DataColumn("riferimento_amministrazione", typeof(String)));
	T.Columns.Add( new DataColumn("codice_ipa", typeof(String)));
	T.Columns.Add( new DataColumn("total", typeof(Decimal)));
	T.Columns.Add( new DataColumn("protocoldate", typeof(DateTime)));
	T.Columns.Add( new DataColumn("arrivalprotocolnum", typeof(String)));
	T.Columns.Add( new DataColumn("mt_prot", typeof(String)));
	T.Columns.Add( new DataColumn("ec_prot", typeof(String)));
	T.Columns.Add( new DataColumn("se_prot", typeof(String)));
	T.Columns.Add( new DataColumn("dt_prot", typeof(String)));
	T.Columns.Add( new DataColumn("rejectreason", typeof(String)));
	T.Columns.Add( new DataColumn("utente_accettata", typeof(String)));
	T.Columns.Add( new DataColumn("utente_rifiutata", typeof(String)));
	T.Columns.Add( new DataColumn("data_accettata", typeof(DateTime)));
	T.Columns.Add( new DataColumn("data_rifiutata", typeof(DateTime)));
	T.Columns.Add( new DataColumn("total_easy", typeof(Decimal)));
	T.Columns.Add( new DataColumn("tipodocumento", typeof(String)));
	T.Columns.Add( new DataColumn("notcreacontabilita", typeof(String)));
	T.Columns.Add( new DataColumn("notcreacontabilitareason", typeof(String)));
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsdi_acquisto"]};


	//////////////////// SDI_STATUS /////////////////////////////////
	T= new DataTable("sdi_status");
	C= new DataColumn("idsdi_status", typeof(Int16));
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
	T.Columns.Add( new DataColumn("listingorder", typeof(Int32)));
	C= new DataColumn("lt", typeof(DateTime));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	C= new DataColumn("lu", typeof(String));
	C.AllowDBNull=false;
	T.Columns.Add(C);
	Tables.Add(T);
	T.PrimaryKey =  new DataColumn[]{T.Columns["idsdi_status"]};


	#endregion


	#region DataRelation creation
	DataColumn []CPar;
	DataColumn []CChild;
	CPar = new DataColumn[1]{sdi_status.Columns["idsdi_status"]};
	CChild = new DataColumn[1]{sdi_acquisto.Columns["idsdi_status"]};
	Relations.Add(new DataRelation("FK_sdi_status_sdi_acquisto",CPar,CChild,false));

	#endregion

}
}
}
