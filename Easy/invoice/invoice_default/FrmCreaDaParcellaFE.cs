
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using AskInfo;
using System.Xml;
using funzioni_configurazione;
using System.Text;

namespace invoice_default {
    public partial class FrmCreaDaParcellaFE : MetaDataForm {
        DataAccess Conn;
        MetaData Meta;
        DataSet DS;
        DataTable dettagli_fe = new DataTable();
        public DataTable Profservice = new DataTable();
        public DataRow rProfservice = null;
        public DataTable Tassociazioni = new DataTable();
        public DataRow[] AssociazioniRows = null;
        public DataTable Tallegati = new DataTable();
        string filterregistry;
        object flagactivity;
        DataTable InvoiceDetail;
        public DataRow[] PA_SelectedRows = null;
        public DataRow[] PA_SelectedRowsbk;
        public DataRow[] FE_SelectedRows = null;
        public DataRow[] FE_SelectedRowsbk;
        CQueryHelper QHC;
        QueryHelper QHS;
        public FrmCreaDaParcellaFE(MetaData Meta, object idsdi_acquisto, object flagactivity, string filterregistry, DataTable InvoiceDetail) {
            InitializeComponent();
            this.Meta = Meta;
            this.Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            this.DS = Meta.DS;
            this.flagactivity = flagactivity;
            this.filterregistry = filterregistry;
            this.InvoiceDetail = InvoiceDetail;
            CreaStrutturaDettagli_fe();
            CreaStrutturaTassociazioni();
            RiempiDataGridDettagliFE(idsdi_acquisto);
            RiempiGridParcella();
        }

        void RiempiGridParcella() {
            string filter = QHS.AppAnd(filterregistry, QHS.CmpEq("flaginvoiced", 'N'), QHS.IsNull("idinvkind"));
            Profservice = Conn.RUN_SELECT("profserviceview", "*", null, filter, null, false);
            Conn.DeleteAllUnselectable(Profservice);

            if (Profservice.Select().Length > 0) {
                Profservice.PrimaryKey = new DataColumn[]{Profservice.Columns["ycon"],
															  Profservice.Columns["ncon"]};
                MetaData MProfservice;
                MProfservice = Meta.Dispatcher.Get("profserviceview");
                MProfservice.DescribeColumns(Profservice, "default");
                DataSet D = new DataSet();
                D.Tables.Add(Profservice);
                HelpForm.SetDataGrid(dgrParcella, Profservice);
                dgrParcella.TableStyles.Clear();
                HelpForm.SetGridStyle(dgrParcella, Profservice);
                formatgrids format = new formatgrids(dgrParcella);
                format.AutosizeColumnWidth();
                //SelezionaTutto();
            }
        }
        void CreaStrutturaTassociazioni() {
            Tassociazioni.TableName = "Tassociazioni";

            Tassociazioni.Columns.Add("NumeroLinea", typeof(string));
            Tassociazioni.Columns["NumeroLinea"].Caption = "NumeroLinea";
            Tassociazioni.Columns.Add("idmankind", typeof(string));
            Tassociazioni.Columns["idmankind"].Caption = ".";
            Tassociazioni.Columns.Add("yman", typeof(int));
            Tassociazioni.Columns["yman"].Caption = ".";
            Tassociazioni.Columns.Add("nman", typeof(int));
            Tassociazioni.Columns["nman"].Caption = ".";
            //Tassociazioni.Columns.Add("manrownum", typeof(int));    Tassociazioni.Columns["manrownum"].Caption = ".";
            Tassociazioni.Columns.Add("rownum", typeof(int));
            Tassociazioni.Columns["rownum"].Caption = ".";//è quello della riga ordine

            Tassociazioni.Columns.Add("idgroup", typeof(int));
            Tassociazioni.Columns["idgroup"].Caption = ".";
            Tassociazioni.Columns.Add("idivakind", typeof(int));
            Tassociazioni.Columns["idivakind"].Caption = "TipoIVA";
            Tassociazioni.Columns.Add("taxrate", typeof(double));
            Tassociazioni.Columns["taxrate"].Caption = "AliquotaIVA";

            Tassociazioni.Columns.Add("residual", typeof(decimal));            //Tassociazioni.Columns["residual"].Caption = "
            Tassociazioni.Columns.Add("detaildescription", typeof(string));    // Tassociazioni.Columns["detaildescription"].Caption = "
            Tassociazioni.Columns.Add("taxable", typeof(decimal));             // Tassociazioni.Columns["taxable"].Caption = "
            Tassociazioni.Columns.Add("tax", typeof(decimal));                  //Tassociazioni.Columns["tax"].Caption = "
            Tassociazioni.Columns.Add("discount", typeof(decimal));             //Tassociazioni.Columns["discount"].Caption = "
            Tassociazioni.Columns.Add("idupb", typeof(string));                 //Tassociazioni.Columns["idupb"].Caption = "
            Tassociazioni.Columns.Add("idsor1", typeof(int));                   //Tassociazioni.Columns["idsor1"].Caption = "
            Tassociazioni.Columns.Add("idsor2", typeof(int));                  // Tassociazioni.Columns["idsor2"].Caption = "
            Tassociazioni.Columns.Add("idsor3", typeof(int));                  // Tassociazioni.Columns["idsor3"].Caption = "
            Tassociazioni.Columns.Add("idcostpartition", typeof(int));         // Tassociazioni.Columns["idcostpartition"].Caption = "
            Tassociazioni.Columns.Add("competencystart", typeof(DateTime));     //Tassociazioni.Columns["competencystart"].Caption = "
            Tassociazioni.Columns.Add("competencystop", typeof(DateTime));     // Tassociazioni.Columns["competencystop"].Caption = "
            Tassociazioni.Columns.Add("idaccmotive", typeof(string));           //Tassociazioni.Columns["idaccmotive"].Caption = "
            Tassociazioni.Columns.Add("va3type", typeof(string));               //Tassociazioni.Columns["va3type"].Caption = "
            Tassociazioni.Columns.Add("idlist", typeof(int));                   //Tassociazioni.Columns["idlist"].Caption = "
            Tassociazioni.Columns.Add("idunit", typeof(int));                   //Tassociazioni.Columns["idunit"].Caption = "
            Tassociazioni.Columns.Add("idpackage", typeof(int));               // Tassociazioni.Columns["idpackage"].Caption = "
            Tassociazioni.Columns.Add("unitsforpackage", typeof(int));          //Tassociazioni.Columns["unitsforpackage"].Caption = "
            Tassociazioni.Columns.Add("expensekind", typeof(string));           //Tassociazioni.Columns["expensekind"].Caption = "
            Tassociazioni.Columns.Add("number", typeof(decimal));               //Tassociazioni.Columns["number"].Caption = "
            Tassociazioni.Columns.Add("npackage", typeof(decimal));             //Tassociazioni.Columns["npackage"].Caption = "
            Tassociazioni.Columns.Add("assetkind", typeof(string));             //Tassociazioni.Columns["assetkind"].Caption = "
            Tassociazioni.Columns.Add("unabatable", typeof(decimal));           //Tassociazioni.Columns["unabatable"].Caption = "
            Tassociazioni.Columns.Add("cigcode", typeof(string));
            Tassociazioni.Columns.Add("cupcode", typeof(string));
        }

        void CreaStrutturaDettagli_fe() {
            dettagli_fe.TableName = "dettagli_fe";

            dettagli_fe.Columns.Add("NumeroLinea", typeof(string));
            dettagli_fe.Columns["NumeroLinea"].Caption = "NumeroLinea";
            dettagli_fe.Columns.Add("Descrizione", typeof(string));
            dettagli_fe.Columns["Descrizione"].Caption = "Descrizione";
            dettagli_fe.Columns.Add("Quantita", typeof(decimal));
            dettagli_fe.Columns["Quantita"].Caption = "Q.tà";
            dettagli_fe.Columns.Add("PrezzoUnitario", typeof(decimal));
            dettagli_fe.Columns["PrezzoUnitario"].Caption = "PrezzoUnitario";
            dettagli_fe.Columns.Add("PrezzoTotale", typeof(decimal));
            dettagli_fe.Columns["PrezzoTotale"].Caption = "PrezzoTotale";
            dettagli_fe.Columns.Add("AliquotaIVA", typeof(decimal));
            dettagli_fe.Columns["AliquotaIVA"].Caption = "AliquotaIVA";
            dettagli_fe.Columns.Add("Natura", typeof(string));
            dettagli_fe.Columns["Natura"].Caption = "Natura";

            dettagli_fe.Columns.Add("ImportoIVA", typeof(decimal));
            dettagli_fe.Columns["ImportoIVA"].Caption = "Importo IVA";
            dettagli_fe.Columns.Add("ImportoSconto", typeof(decimal));
            dettagli_fe.Columns["ImportoSconto"].Caption = "Importo Sconto";
            dettagli_fe.Columns.Add("PercentualeSconto", typeof(decimal));
            dettagli_fe.Columns["PercentualeSconto"].Caption = "Percentuale Sconto";
            dettagli_fe.Columns.Add("unitsforpackage", typeof(decimal));
            dettagli_fe.Columns["unitsforpackage"].Caption = ".";

            dettagli_fe.Columns.Add("cigcode", typeof(string));
            dettagli_fe.Columns["cigcode"].Caption = "cig";
            dettagli_fe.Columns.Add("cupcode", typeof(string));
            dettagli_fe.Columns["cupcode"].Caption = "cup";
        }

        void CreaStrutturaTallegati() {
            Tallegati.TableName = "Tallegati";

            //            Tallegati.Columns.Add("idattachment", typeof(int));
            Tallegati.Columns.Add("attachment", typeof(byte[]));
            Tallegati.Columns.Add("filename", typeof(string));
        }

        void RecupareAllegati(object idsdi_acquisto) {
            DataTable SDI_acquisto;
            SDI_acquisto = Conn.RUN_SELECT("sdi_acquisto", "*", null, QHS.CmpEq("idsdi_acquisto", idsdi_acquisto), null, false);

            DataRow Curr = SDI_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file da importare\nErrore";
                show(this, messaggio);
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;

            XmlNodeList Allegati = document.SelectNodes("//FatturaElettronicaBody/Allegati");
            if (Allegati == null)
                return;

            DataRow R = null;
            foreach (XmlNode Dettaglio in Allegati) {
                R = Tallegati.NewRow();
                string NomeAttachment = Dettaglio["NomeAttachment"].InnerText;
                R["filename"] = NomeAttachment;
                //string FormatoAttachment = Dettaglio["FormatoAttachment"].InnerText;
                string Attachment = Dettaglio["Attachment"].InnerText;
                byte[] bytes = Encoding.Default.GetBytes(Attachment);
                Attachment = Encoding.UTF8.GetString(bytes);
                R["attachment"] = Attachment;
                Tallegati.Rows.Add(R);
            }
            Tallegati.AcceptChanges();
        }


        static string getXmlText(XmlDocument x, string xpath) {
            try {
                XmlNode n = x.SelectSingleNode(xpath);
                if (n != null) {
                    return n.InnerText;
                }
            }
            catch {
            }
            return null;
        }


        void RiempiDataGridDettagliFE(object idsdi_acquisto) {
            DataTable SDI_acquisto;
            SDI_acquisto = Conn.RUN_SELECT("sdi_acquisto", "*", null, QHS.CmpEq("idsdi_acquisto", idsdi_acquisto), null, false);
            bool messageShown = false;

            DataRow Curr = SDI_acquisto.Rows[0];
            if (Curr["xml"] == DBNull.Value) {
                string messaggio;
                messaggio = "Non vi è alcun file da importare\nErrore";
                show(this, messaggio);
                return;
            }
            XmlDocument document = new XmlDocument();
            document.LoadXml(Curr["xml"].ToString());
            XmlElement Comunicazione = document.DocumentElement;

            XmlNodeList DettaglioLinee = document.SelectNodes("//FatturaElettronicaBody/DatiBeniServizi/DettaglioLinee");
            foreach (XmlNode Dettaglio in DettaglioLinee) {
                DataRow R = dettagli_fe.NewRow();
                string NumeroLinea = Dettaglio["NumeroLinea"].InnerText;
                R["NumeroLinea"] = NumeroLinea;
                string Descrizione = Dettaglio["Descrizione"].InnerText;
                R["Descrizione"] = Descrizione;
                //decimal Quantita = XmlConvert.ToDecimal(Dettaglio["Quantita"].InnerText);
                //R["Quantita"] = Quantita;
                decimal PrezzoUnitario = XmlConvert.ToDecimal(Dettaglio["PrezzoUnitario"].InnerText);
                R["PrezzoUnitario"] = PrezzoUnitario;
                decimal PrezzoTotale = XmlConvert.ToDecimal(Dettaglio["PrezzoTotale"].InnerText);
                R["PrezzoTotale"] = PrezzoTotale;

                decimal Quantita = 1;
                if ((PrezzoUnitario == 0) && (PrezzoTotale == 0))
                    continue;//Se gli importi sono 0, il dettaglio non va ne importato in Easy, ne mostrato nel grid. Task 7113.
                if (Dettaglio["Quantita"] != null) {
                    Quantita = XmlConvert.ToDecimal(Dettaglio["Quantita"].InnerText);
                    Quantita = Decimal.Round(Quantita, 2);
                    if ((Quantita == 0) && (PrezzoTotale != 0)) {
                        Quantita = 1;//se totale <> 0 e quantità = 0=>  Correggiamo la q.tà con 1 e importiamo il dettaglio. Task 7113.
                    }
                }
                else {
                    if (PrezzoUnitario != 0 && PrezzoTotale != 0) {
                        Quantita = Decimal.Round(PrezzoTotale / PrezzoUnitario, 2);
                        if (!messageShown) {
                            messageShown = true;
                            show("Per almeno un dettaglio è stato calcolata la quantità con la formula inversa PrezzoTotale/PrezzoUnitario", "Avviso");
                        }
                    }
                }
                R["Quantita"] = Quantita;

                double AliquotaIVA_Double = XmlConvert.ToDouble(Dettaglio["AliquotaIVA"].InnerText);
                AliquotaIVA_Double = AliquotaIVA_Double / 100;
                decimal AliquotaIVA = CfgFn.GetNoNullDecimal(AliquotaIVA_Double);
                R["AliquotaIVA"] = AliquotaIVA_Double;
                decimal IVA = Decimal.Round(PrezzoTotale * AliquotaIVA, 2);
                R["ImportoIVA"] = IVA;
                if (Dettaglio["Natura"] != null) {
                    string Natura = Dettaglio["Natura"].InnerText.ToString();// Da leggere solo se esiste
                    R["Natura"] = Natura;
                }

                decimal totaleSconto = 0;
                XmlNodeList ElencoSconti = Dettaglio.SelectNodes("ScontoMaggiorazione");
                foreach (XmlElement Sconto in ElencoSconti) {
                    string contenuto = Sconto.InnerText;
                    string tipo = Sconto.SelectNodes("Tipo")[0].InnerText.ToUpper();
                    decimal segno = (tipo == "SC") ? +1 : -1;
                    XmlNodeList Imp = Sconto.SelectNodes("Importo");
                    if (Imp != null && Imp.Count > 0) {
                        decimal xx = XmlConvert.ToDecimal(Imp[0].InnerText);
                        totaleSconto += segno * xx;
                        continue;
                    }
                    XmlNodeList Perc = Sconto.SelectNodes("Percentuale");
                    if (Perc != null && Perc.Count > 0) {
                        decimal pp = XmlConvert.ToDecimal(Perc[0].InnerText);
                        totaleSconto += segno * Decimal.Round(pp * PrezzoTotale / 100, 5);
                        continue;
                    }
                }
                //      importo sconto:prezzo totale = percentuale scont :100
                //      percentuale sconto = importo sconto*100/prezzo totale
                R["ImportoSconto"] = Decimal.Round(totaleSconto, 2);
                decimal PercentualeSconto = 0;
                if (totaleSconto != 0 && CfgFn.RoundValuta(PrezzoUnitario * Quantita) != 0) {
                    PercentualeSconto = Decimal.Round(totaleSconto, 2) / CfgFn.RoundValuta((PrezzoUnitario * Quantita));// *100
                }
                R["PercentualeSconto"] = Decimal.Round(PercentualeSconto, 3);

                dettagli_fe.Rows.Add(R);
            }
            dettagli_fe.AcceptChanges();

            DataSet D = new DataSet();
            D.Tables.Add(dettagli_fe);
            HelpForm.SetDataGrid(dgrDettagliFE, dettagli_fe);
            dgrDettagliFE.TableStyles.Clear();

            HelpForm.SetFormatForColumn(dettagli_fe.Columns["AliquotaIVA"], "p");
            HelpForm.SetFormatForColumn(dettagli_fe.Columns["PercentualeSconto"], "p");
            HelpForm.SetFormatForColumn(dettagli_fe.Columns["Quantita"], "n");
            HelpForm.SetGridStyle(dgrDettagliFE, dettagli_fe);

            formatgrids format = new formatgrids(dgrDettagliFE);
            format.AutosizeColumnWidth();
            //SelezionaTutto();
            if ((dettagli_fe == null) || (dettagli_fe.Rows.Count == 0)) {
                btnOk.Enabled = true;
            }
            else {
                btnOk.Enabled = false;
            }
        }

        DataRow GetGridRowFE(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.CmpEq("NumeroLinea", G[index, 0]);

            DataRow[] selectresult = MyTable.Select(filter);
            if (selectresult.Length == 0)
                return null;
            return selectresult[0];
        }

        DataRow GetGridRow(DataGrid G, int index) {
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            string filter;
            filter = QHC.AppAnd(QHC.CmpEq("ycon", G[index, 0]),
                            QHC.CmpEq("ncon", G[index, 1]));

            DataRow[] selectresult = MyTable.Select(filter);
            if (selectresult.Length == 0)
                return null;
            return selectresult[0];
        }

        private DataRow[] GetGridSelectedRows(DataGrid G) {
            if (G.DataMember == null)
                return null;
            if (G.DataSource == null)
                return null;
            string TableName = G.DataMember.ToString();
            DataSet MyDS = (DataSet)G.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];
            int numrighetemp = MyTable.Rows.Count;
            int numrighe = 0;
            int i;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    numrighe++;
                }
            }

            DataRow[] Res = new DataRow[numrighe];
            int count = 0;
            for (i = 0; i < numrighetemp; i++) {
                if (G.IsSelected(i)) {
                    if (MyTable.TableName.Contains("profservice")) {
                        Res[count++] = GetGridRow(G, i);
                    }
                    else {
                        Res[count++] = GetGridRowFE(G, i);
                    }
                }
            }
            return Res;
        }

        void SelezionaTuttoDgrFE() {
            object dataSource = dgrDettagliFE.DataSource;
            if (dataSource == null)
                return;

            CurrencyManager cm = (CurrencyManager)
                dgrDettagliFE.BindingContext[dataSource, dgrDettagliFE.DataMember];

            DataView view = cm.List as DataView;

            if (view != null) {
                for (int i = 0; i < view.Count; i++) {
                    dgrDettagliFE.Select(i);
                }
            }
        }

        private object IndividuaAliquota(DataRow FE_Selected) {
            string filterAttivita = null;
            if (flagactivity != null) {
                int intflagactivity = CfgFn.GetNoNullInt32(flagactivity);
                if (intflagactivity == 1)
                    filterAttivita = QHS.BitSet("flag", 0);
                if (intflagactivity == 2)
                    filterAttivita = QHS.BitSet("flag", 1);
                if (intflagactivity == 3)
                    filterAttivita = QHS.BitSet("flag", 2);
            }
            object idivakind = DBNull.Value;
            //decimal AliquotaIVA = CfgFn.GetNoNullDecimal(FE_Selected["AliquotaIVA"]);
            double AliquotaIVA = CfgFn.GetNoNullDouble(FE_Selected["AliquotaIVA"]);
            if (CfgFn.GetNoNullDouble(AliquotaIVA) > 0) {
                DataTable Tivakind = Conn.RUN_SELECT("ivakind", "*", "unabatabilitypercentage ASC", QHS.AppAnd(QHS.CmpEq("rate", AliquotaIVA), QHS.CmpEq("active", "S"), filterAttivita), null, true);
                if ((Tivakind == null) || (Tivakind.Rows.Count == 0)) {
                    show("Non è stata trovata un'aliquota per l'iva al " +
                                    AliquotaIVA.ToString("n") + "%");
                    return null;
                }
                if (Tivakind.Rows.Count == 1) {
                    DataRow Rivakind = Tivakind.Rows[0];
                    idivakind = Rivakind["idivakind"];
                }
                if (Tivakind.Rows.Count > 1) {
                    string VistaScelta = "ivakind";
                    MetaData MIvakind = Meta.Dispatcher.Get(VistaScelta);
                    MIvakind.FilterLocked = true;
                    MIvakind.DS = DS;
                    double AliquotaIVA_Perc = CfgFn.GetNoNullDouble(AliquotaIVA) * 100;
                    show("Sono stati trovati diversi tipi IVA con aliquota al " +
                                    AliquotaIVA_Perc.ToString("n") + "%. Selezionare quello più appropriato.");
                    DataRow MyDR = null;
                    while (MyDR == null) {
                        MyDR = MIvakind.SelectOne("default", QHS.AppAnd(QHS.CmpEq("rate", AliquotaIVA), QHS.CmpEq("active", "S"), filterAttivita), null, null);
                        if (MyDR != null) {
                            idivakind = MyDR["idivakind"];
                        }
                    }
                }
            }
            else {
                // Se l'aliquota è 0, in base alla Natura, fa scegliere la corretta Aliquota 0.00 %
                string Natura = FE_Selected["Natura"].ToString();
                DataTable Tivakind = Conn.RUN_SELECT("ivakind", "*", "unabatabilitypercentage ASC", QHS.AppAnd(QHS.CmpEq("rate", 0), QHS.CmpEq("idfenature", Natura), QHS.CmpEq("active", "S"), filterAttivita), null, true);
                if ((Tivakind == null) || (Tivakind.Rows.Count == 0)) {
                    show("Non è stata trovata alcuna aliquota 0.00 % avente Natura di spesa" + Natura);
                }
                if (Tivakind.Rows.Count == 1) {
                    DataRow Rivakind = Tivakind.Rows[0];
                    idivakind = Rivakind["idivakind"];
                }
                if (Tivakind.Rows.Count > 1) {
                    string VistaScelta = "ivakind";
                    MetaData MIvakind = Meta.Dispatcher.Get(VistaScelta);
                    MIvakind.FilterLocked = true;
                    MIvakind.DS = DS;
                    DataRow MyDR = null;
                    while (MyDR == null) {
                        MyDR = MIvakind.SelectOne("default", QHC.AppAnd(QHC.CmpEq("rate", 0), QHC.CmpEq("idfenature", Natura), QHC.CmpEq("active", "S"), filterAttivita), null, null);
                        if (MyDR != null) {
                            idivakind = MyDR["idivakind"];
                        }
                    }
                }
            }
            return idivakind;
        }


        private void btnImportaTuttaFESenzaAssociazione_Click(object sender, EventArgs e) {
            SelezionaTuttoDgrFE();
            FE_SelectedRows = GetGridSelectedRows(dgrDettagliFE);
            if ((FE_SelectedRows == null) || (FE_SelectedRows.Length == 0)) {
                show("Non è stato selezionato alcun dettaglio della Fattura Elettronica.");
                return;
            }
            //Scrive le associazioni in Tassociazioni
            DataRow R = null;
            foreach (DataRow rFE in FE_SelectedRows) {
	            if (rFE.RowState == DataRowState.Detached || rFE.RowState == DataRowState.Deleted) continue;
                R = Tassociazioni.NewRow();

                R["NumeroLinea"] = rFE["NumeroLinea"];

                //Cerca di individuare l'aliquota corretta
                object idivakind = IndividuaAliquota(rFE);

                R["idivakind"] = idivakind;
                R["taxrate"] = rFE["AliquotaIVA"];
                R["detaildescription"] = rFE["Descrizione"];
                R["taxable"] = rFE["PrezzoUnitario"];
                R["tax"] = rFE["ImportoIVA"];
                R["discount"] = rFE["PercentualeSconto"];
                R["number"] = rFE["Quantita"];
                R["npackage"] = rFE["Quantita"];
                R["unitsforpackage"] = rFE["unitsforpackage"];
                R["residual"] = rFE["Quantita"];//number
                if (R.Table.Columns.Contains("cigcode") && rFE.Table.Columns.Contains("cigcode")) {
                    R["cigcode"] = rFE["cigcode"];

                }

                if (R.Table.Columns.Contains("cupcode") && rFE.Table.Columns.Contains("cupcode")) {
                    R["cupcode"] = rFE["cupcode"];
                }

                Tassociazioni.Rows.Add(R);
            }
            Tassociazioni.AcceptChanges();

            // Cancella le righe già selezionate dai datagrid
            foreach (DataRow RR in FE_SelectedRows) {
	            if (RR.RowState == DataRowState.Detached || RR.RowState == DataRowState.Deleted) continue;
                string filterDettFE = QHC.CmpEq("NumeroLinea", RR["NumeroLinea"]);
                foreach (DataRow rFE in dettagli_fe.Select(filterDettFE)) {
                    rFE.Delete();
                }
            }
            dettagli_fe.AcceptChanges();
            FE_SelectedRows = null;
            rProfservice = null;
            DialogResult = DialogResult.OK;
        }


        bool InsidePaintParcella = false;
        private void dgrParcella_Paint(object sender, PaintEventArgs e) {
            if (dgrParcella.DataMember == null || dgrParcella.DataMember == "")
                return;
            if (InsidePaintParcella)
                return;
            InsidePaintParcella = true;
          

            string TableName = dgrParcella.DataMember.ToString();
            DataSet MyDS = (DataSet)dgrParcella.DataSource;
            DataTable MyTable = MyDS.Tables[TableName];

            int numrighetemp = MyTable.Rows.Count;
            //DataRow gridrow = null;

            // Contiene le righe selezionate FE_RowSelectedbk, lo fa solo una volta
            if (PA_SelectedRowsbk == null)
                PA_SelectedRowsbk = new DataRow[numrighetemp];

            PA_SelectedRowsbk = GetGridSelectedRows(dgrParcella);
            InsidePaintParcella = false;


            if ((PA_SelectedRowsbk != null) && (PA_SelectedRowsbk.Length > 0)) {
                btnEseguiAssociazione.Enabled = true;
                btnImportaTuttaFESenzaAssociazione.Enabled = false;
            }
            else {
                btnEseguiAssociazione.Enabled = false;
                btnImportaTuttaFESenzaAssociazione.Enabled = true;
            }
        }

        private void btnEseguiAssociazione_Click(object sender, EventArgs e) {
            PA_SelectedRows = GetGridSelectedRows(dgrParcella);
            if ((PA_SelectedRows == null) || (PA_SelectedRows.Length == 0)) {
                show("Non è stato selezionato alcun Contratto Professionale.");
                return;
            }

            rProfservice = PA_SelectedRows[0];
            DialogResult = DialogResult.OK;
        }

        private void dgrParcella_MouseUp(object sender, MouseEventArgs e) {
            //Impedisce la multiselezione col mouse
            HelpForm.HelpForm_MouseUp(sender, e);
        }

        private void dgrParcella_KeyUp(object sender, KeyEventArgs e) {
            //Impedisce la multiselezione da tastiera
            HelpForm.HelpForm_KeyUp(sender, e);
        }

    }
}
