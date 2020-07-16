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

namespace admpay_spt {
using System;
using System.Data;
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "2.0.0.0")]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class vistaForm: System.Data.DataSet {
// List of DataTables
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable admpay{get { return this.Tables["admpay"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_00{get { return this.Tables["SPT_00"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_99{get { return this.Tables["SPT_99"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_01{get { return this.Tables["SPT_01"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_02{get { return this.Tables["SPT_02"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_03{get { return this.Tables["SPT_03"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_04{get { return this.Tables["SPT_04"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_05{get { return this.Tables["SPT_05"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_06{get { return this.Tables["SPT_06"];}}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.Browsable(false)]
public DataTable SPT_07{get { return this.Tables["SPT_07"];}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
[System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
public new System.Data.DataTableCollection Tables {get {return base.Tables;}}

[System.Diagnostics.DebuggerNonUserCodeAttribute()]
public vistaForm(){
this.BeginInit();
this.InitClass();
this.EndInit();
}
[System.Diagnostics.DebuggerNonUserCodeAttribute()]
private void InitClass() {
this.DataSetName = "vistaForm";
this.Prefix = "";
this.Namespace = "http://tempuri.org/vistaForm.xsd";
this.EnforceConstraints = false;
	DataTable T;
	DataColumn C;
	DataColumn [] key;
	T= new DataTable("admpay");
	C= new DataColumn("yadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("nadmpay", typeof(System.Int32), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("description", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("amount", typeof(System.Decimal), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	T.Columns.Add(new DataColumn("processed", typeof(System.String), ""));
	C= new DataColumn("adate", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("cu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("ct", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lu", typeof(System.String), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	C= new DataColumn("lt", typeof(System.DateTime), "");
	C.AllowDBNull=false;
	T.Columns.Add(C);

	Tables.Add(T);
//Primary Key
	key = new DataColumn[2]{
	T.Columns["yadmpay"], 	T.Columns["nadmpay"]};
	T.PrimaryKey = key;

	T= new DataTable("SPT_00");
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataelaborazione", typeof(System.DateTime), ""));
	Tables.Add(T);
	T= new DataTable("SPT_99");
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataelaborazione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("totalepartite", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("totaleimporto", typeof(System.Int32), ""));
	Tables.Add(T);
	T= new DataTable("SPT_01");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("dpt", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicefiscale", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cognome1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("nome1", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("indirizzo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("localita", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cap", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("provinciaresid", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("modalpagamento", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiposervizio", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iban", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cin", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("abi", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("cab", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("contocorrente", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("ufficioservizio", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("capitolospesa", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("capitolobilancio", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("qualifica", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("livello", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("classe", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("scatti", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("aliquotamedia", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataprossimoaps", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("imponibilerataannocorrente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("irpefrataannocorrente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("irpefarretratiannocorrente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("irpefarretratiannoprecedente", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("irpeftotalenetta", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoannuolordo", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importomensilelordo", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importomensilenetto", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importonetto13ma", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoprev13ma", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoirpef13ma", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("percptime", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numerofigli", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("numeroaltrifam", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("detrazionibase", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("detrazioniconiuge", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("detrazionifigli", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("detrazionialtrifam", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("flageffettoconiuge", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("totaledetrazioni", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("numerominori3anni", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("codiceregimecontributivo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codregioneirap", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("aliquotamassima", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("aliquotamaxforzata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("CodiceComuneAccon", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceComuneSaldo", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceAccontoDich", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceAccontoCong", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceAc", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceAcCong", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("CodiceComuneRes", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("SPT_02");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codiceassegno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("sottocodiceassegno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("importolordotabellare", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importolordorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoriduzionept", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoriduzionete", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoritprev", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("datascadassegno", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("flagimponfiscale", typeof(System.String), ""));
	Tables.Add(T);
	T= new DataTable("SPT_03");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codiceassegno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codritprevass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("aliquotalavoratore", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("percentualeapplicazione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("imponibile", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoritenuta", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("aliquotadatore", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importodatore", typeof(System.Decimal), ""));
	Tables.Add(T);
	T= new DataTable("SPT_04");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codiceritenuta", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("tiporitenuta", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("flagriduzimpon", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("progressivodebito", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importoritenuta", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("datascadritextra", typeof(System.DateTime), ""));
	Tables.Add(T);
	T= new DataTable("SPT_05");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codiceritenutacategoria", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codiceassegno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("importoritenuta", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("datascadritcat", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("tiporitcat", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("percapplritcat", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("percritcat", typeof(System.Decimal), ""));
	Tables.Add(T);
	T= new DataTable("SPT_06");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codiceassegno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicearretrato", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datalotto", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("numlotto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("annoriferimento", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("importolordorata", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoriduzionept", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoriduzionepe", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoritenute", typeof(System.Decimal), ""));
	Tables.Add(T);
	T= new DataTable("SPT_07");
	T.Columns.Add(new DataColumn("numeroriga", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("tiporecord", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("iscrizione", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("rata", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("dataemissione", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("codiceassegno", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("codicearretrato", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("datalotto", typeof(System.DateTime), ""));
	T.Columns.Add(new DataColumn("numlotto", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("annoriferimento", typeof(System.Int32), ""));
	T.Columns.Add(new DataColumn("codritprevass", typeof(System.String), ""));
	T.Columns.Add(new DataColumn("imponibile", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoritlavoratore", typeof(System.Decimal), ""));
	T.Columns.Add(new DataColumn("importoritdatore", typeof(System.Decimal), ""));
	Tables.Add(T);
}
}
}
