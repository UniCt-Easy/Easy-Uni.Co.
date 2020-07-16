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

namespace paydisposition_default {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class daticbiDataSet: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable RigheDisposizioni{get { return Tables["RigheDisposizioni"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable TestataDisposizioni{get { return Tables["TestataDisposizioni"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public daticbiDataSet(){
BeginInit();
InitClass();
EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
DataSetName = "daticbiDataSet";
Prefix = "";
Namespace = "http://tempuri.org/daticbiDataSet.xsd";
EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("RigheDisposizioni");
	C= new DataColumn("IdDisposizione", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("IdRiga", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("DataScadenza", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("Importo", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("AbiCliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CabCliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CCCliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CinCliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IBANCliente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PagamentoPerBonifico", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PagamentoPerCassa", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PagamentoPerAssegnoCircolare", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PagamentoPerAssegnoCircolareNonTrasf", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("PagamentoPerAssegnoQuietanza", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("TipoCodice", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("CodiceBeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DescrizioneBeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceFiscaleBeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IndirizzoBeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CapBeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("LocalitaBeneficiario", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("SiglaProvincia", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NumeroDocumento", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataDocumento", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NumeroRicevuta", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("TipoDocBeneficiario", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("RichiestaEsito", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("StampaAvviso", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("ChiaveControllo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Causale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CausaleDescrittiva", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataValuta", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["IdDisposizione"], 	T.Columns["IdRiga"]};
	T.PrimaryKey = key;

	T= new DataTable("TestataDisposizioni");
	C= new DataColumn("IdInvio", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("CodiceSia", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("Descrizione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("AbiAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CabAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ContoAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataDisposizioni", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("NomeSupporto", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DescrizioneAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("LocalitaAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("IndirizzoAzienda", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodificaFiscale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("RagioneSociale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ProvinciaFinanza", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("NumeroAutorizzazione", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("DataAutorizzazione", typeof(System.DateTime), ""));
	Tables.Add(T);
//Primary Key
	key = new DataColumn[1]{
	T.Columns["IdInvio"]};
	T.PrimaryKey = key;

}
}
}
