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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using funzioni_configurazione;
using ep_functions;
using System.Globalization;




namespace entry_wizard_scaricomagazzino{
    public partial class Frm_scaricomagazzino_ep : Form   {
        MetaData Meta;
        DataAccess Conn;
        string CustomTitle;
        QueryHelper QHS;
        CQueryHelper QHC;
        DataTable Info = new DataTable();
        DataTable ToldIdsor = new DataTable();
        DataTable Tinvoicedetail;
        public Frm_scaricomagazzino_ep(){
            InitializeComponent();
            tabController.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
            ToldIdsor.TableName = "ToldIdsor";
            ToldIdsor.Columns.Add("idsor1", typeof(string));
            ToldIdsor.Columns.Add("idsor2", typeof(string));
            ToldIdsor.Columns.Add("idsor3", typeof(string));
            DS.Tables.Add(ToldIdsor); 
            Info.TableName = "Info";

            Info.Columns.Add("invidsor1", typeof(string));
            Info.Columns["invidsor1"].Caption = ".";

            Info.Columns.Add("yinv", typeof(int));
            Info.Columns["yinv"].Caption = "Eserc.Fatt.";

            Info.Columns.Add("ninv", typeof(int));
            Info.Columns["ninv"].Caption = "Num.Fatt.";

            Info.Columns.Add("rownum", typeof(int));
            Info.Columns["rownum"].Caption = "Num.riga";

            Info.Columns.Add("detaildescription", typeof(string));
            Info.Columns["detaildescription"].Caption = "dett.Fatt";

            Info.Columns.Add("invcodesor1", typeof(string));
            Info.Columns["invcodesor1"].Caption = "dett.Fatt.Class.1";

            Info.Columns.Add("invidsor2", typeof(string));
            Info.Columns["invidsor2"].Caption = ".";

            Info.Columns.Add("invcodesor2", typeof(string));
            Info.Columns["invcodesor2"].Caption = "dett.Fatt.Class.2";

            Info.Columns.Add("invidsor3", typeof(string));
            Info.Columns["invidsor3"].Caption = ".";

            Info.Columns.Add("invcodesor3", typeof(string));
            Info.Columns["invcodesor3"].Caption = "dett.Fatt.Class.3";

            Info.Columns.Add("idsor1", typeof(string));
            Info.Columns["idsor1"].Caption = ".";

            Info.Columns.Add("amount", typeof(decimal));
            Info.Columns["amount"].Caption = "Costo";

            Info.Columns.Add("ystoreunload", typeof(int));
            Info.Columns["ystoreunload"].Caption = "Eserc.Scarico";

            Info.Columns.Add("nstoreunload", typeof(int));
            Info.Columns["nstoreunload"].Caption = "Num.Scarico";

            Info.Columns.Add("unloadcodesor1", typeof(string));
            Info.Columns["unloadcodesor1"].Caption = "dett.Scarico Class. 1";

            Info.Columns.Add("idsor2", typeof(string));
            Info.Columns["idsor2"].Caption = ".";

            Info.Columns.Add("unloadcodesor2", typeof(string));
            Info.Columns["unloadcodesor2"].Caption = "dett.Scarico Class.2";

            Info.Columns.Add("idsor3", typeof(string));
            Info.Columns["idsor3"].Caption = ".";

            Info.Columns.Add("unloadcodesor3", typeof(string));
            Info.Columns["unloadcodesor3"].Caption = "dett.Scarico Class.3"; 

            DS.Tables.Add(Info); 
        }

        public void MetaData_AfterActivation(){
            CustomTitle = "Genera Scritture in partita doppia";
            DisplayTabs(0);
        }

        private void btnNext_Click(object sender, EventArgs e){
            if (tabController.SelectedIndex == tabController.TabPages.Count - 1){
                GeneraScritture();
            }
            StandardChangeTab(+1);
        }

        void StandardChangeTab(int step){
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count){
                btnNext.Visible = false;
                btnBack.Visible = false;
                btnCancel.Visible = false;
                btnOK.Visible = true;
            }
            if ((oldTab == 1) && (newTab == 0)){
                newTab = 1;
            }
            DisplayTabs(newTab);
        }


        void DisplayTabs(int newTab){
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1){
                btnBack.Visible = false;
                btnNext.Text = "Esegui.";
                if (DS.Tables["Info"].Rows.Count == 0){
                    btnNext.Enabled = false;
                }
            }
            else
                btnNext.Text = "Avanti >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
        }

        private void btnCancel_Click(object sender, EventArgs e){
            this.Close();
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            GetData.CacheTable(DS.config, filteresercizio, null, false);
            btnOK.Visible = false;
        }

        bool CustomChangeTab(int oldTab, int newTab){
            if (oldTab == 0){
                RiempiGridStorno();
                return true; // 0->1: visualizza le scritture che saranno generate
            }
            if ((oldTab == 1) && (newTab == 0)){
                return true; //1->0:nothing to do!
            }
            return true;
        }
//WHERE (IK.flag & 1) = 0 
// AND
//    NOT EXISTS (
//                SELECT * FROM entry 
//                WHERE  idrelated = 'storeunloaddetail§'  
//                        + convert(varchar(10),UNL.idstoreunload) 
//                        + '§' 
//                        + convert(varchar(10),UNL.idstoreunloaddetail)
//                 ) 
 
//and I.yinv  =2010

        void RiempiGridStorno() {
            int esercizio = (int)Meta.GetSys("esercizio");
            string sqlCmd = "";
            sqlCmd =
                    " SELECT  "+
                    " ( select top 1 R.flagactivity "+
                    " from invoicekindregisterkind IR "+
                    " join ivaregisterkind R "+
                    " on R.idivaregisterkind = IR.idivaregisterkind "+
                    " where I.idinvkind = IR.idinvkind ) as TipoAttivita, "+
                    "   I.yinv,I.ninv,IDET.rownum, I.flagdeferred, I.flagintracom, I.idaccmotivedebit, I.idreg, I.idinvkind, I.exchangerate, I.idaccmotivedebit,  " +
                    "   IDET.taxable, UNL.number, IDET.unabatable, IDET.tax, IDET.idaccmotive, IDET.idupb,IDET.competencystart, IDET.competencystop,  "+
                    "   IDET.detaildescription,"+
                    "   IDET.idsor1 as invidsor1, IDET.idsor2 as invidsor2, IDET.idsor3 as invidsor3, "+
                    "   UNL.idsor1 as idsor1, UNL.idsor2 as idsor2, UNL.idsor3 as idsor3 ,"+
                    " IS1.sortcode as invcodesor1, IS2.sortcode as invcodesor2, IS3.sortcode as invcodesor3,"+
                    " UNLSORT1.sortcode as unloadcodesor1, UNLSORT2.sortcode as unloadcodesor2, UNLSORT3.sortcode as unloadcodesor3, " +
                    " UNL.idstoreunload, UNL.idstoreunloaddetail," +
                    " MAIN_UNL.description, MAIN_UNL.adate, MAIN_UNL.ystoreunload, MAIN_UNL.nstoreunload" +
                    " FROM invoice I "+
                    " JOIN invoicekind IK "+
		            "   ON I.idinvkind = IK.idinvkind "+
                    " JOIN invoicedetail  IDET "+
                    "   ON I.idinvkind = IDET.idinvkind and I.yinv = IDET.yinv and I.ninv = IDET.ninv "+
                    " JOIN list L    "+
                    "   ON IDET.idlist = L.idlist   "+
                    " JOIN stock  S  "+
                    " ON S.idinvkind = IDET.idinvkind "+
                    " AND S.yinv = IDET.yinv "+
                    " AND S.ninv = IDET.ninv "+
                    " AND S.inv_idgroup   = IDET.idgroup " +
                    " JOIN storeunloaddetail   UNL  "+
                    "   ON UNL.idstock = S.idstock  " +
                    " JOIN storeunload   MAIN_UNL  " +
                    "   ON MAIN_UNL.idstoreunload = UNL.idstoreunload  " +
                    " LEFT OUTER JOIN sorting IS1"+
                    "   ON IS1.idsor = IDET.idsor1"+
                    " LEFT OUTER JOIN sorting IS2"+
                    "   ON IS2.idsor = IDET.idsor2"+
                    " LEFT OUTER JOIN sorting IS3"+
                    "   ON IS3.idsor = IDET.idsor3"+
                    " LEFT OUTER JOIN sorting UNLSORT1"+
                    "   ON UNLSORT1.idsor = UNL.idsor1"+
                    " LEFT OUTER JOIN sorting UNLSORT2"+
                    "   ON UNLSORT2.idsor = UNL.idsor2"+
                    " LEFT OUTER JOIN sorting UNLSORT3"+
                    "   ON UNLSORT3.idsor = UNL.idsor3" +

                    " WHERE (IK.flag & 1) = 0 " +
                    " AND "+
                    " NOT EXISTS (SELECT * FROM entry WHERE " +
                    " idrelated = 'storeunloaddetail§' " + 
                    " + convert(varchar(10),UNL.idstoreunload)"+
                    " + '§'" + 
                    " + convert(varchar(10),UNL.idstoreunloaddetail))"+
                    " AND I.yinv  ="+  esercizio +
                    " ORDER BY I.yinv, I.ninv asc ";


            Tinvoicedetail = Meta.Conn.SQLRunner(sqlCmd);
            if (Tinvoicedetail.Rows.Count == 0){
                MessageBox.Show("Non ci sono elementi da elaboarare");
                return;
            }
            // Per ogni dettaglio fattura visualizziamo la scrittura in EP
            foreach (DataRow rDetail in Tinvoicedetail.Select()){
                VisualizzaScritturedaGenerare(rDetail);
            }

            if (DS.Tables["Info"].Rows.Count > 0){
                gridEP.DataSource = null;
                HelpForm.SetDataGrid(gridEP, DS.Tables["Info"]);
            }
        }


        // VISUALIZZA E BASTA
        void VisualizzaScritturedaGenerare(DataRow rDetail){
            object idreg = rDetail["idreg"];
            object idreg_iva = idreg;
            object esercizio = Meta.GetSys("esercizio");

            if (rDetail["yinv"].ToString() != esercizio.ToString()){
                return;
            }
            EP_functions EP = new EP_functions(Meta.Dispatcher);
            if (!EP.attivo) return;

            DataRow currInvSetup = DS.config.Rows[0];

            object idregVersamento12 = currInvSetup["paymentagency12"];
            object idregRimborso12 = currInvSetup["refundagency12"];
            object idacc_refund12 = EP.GetAccountForIvaRefund12();
            object idacc_payment12 = EP.GetAccountForIvaPayment12();


            bool istituzionale = (CfgFn.GetNoNullInt32(rDetail["TipoAttivita"]) == 1);
            bool deferred = (rDetail["flagdeferred"].ToString().ToUpper() == "S");
            bool isIntraCom = (rDetail["flagintracom"].ToString().ToUpper() != "N");// Flagintracom può valere: S-intracom, N o X-extracom.
            bool INVERTI_DEBITO_CREDITO = (istituzionale && isIntraCom);

            string filtroInvKind = QHS.CmpEq("idinvkind", rDetail["idinvkind"]);

            DataTable Tinvoicekind = Conn.RUN_SELECT("invoicekind", "*", null, filtroInvKind, null, true);
            DataRow TipoDoc = Tinvoicekind.Rows[0];

            filtroInvKind = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filtroInvKind);
            DataTable Tinvoicekindyear = Conn.RUN_SELECT("invoicekindyear", "*", null, filtroInvKind, null, true);
            DataRow TipoDocYear = Tinvoicekindyear.Rows[0];

            object invkind_idacc_iva = DBNull.Value;
            object invkind_idacc_iva_intracom = DBNull.Value;

            object idacc_unabatable = DBNull.Value;
            //costo iva indetraibile (per chi calcola riga per riga e gestisce tale conto)
            if (isIntraCom){
                idacc_unabatable = TipoDocYear["idacc_unabatable_intra"];
            }
            if (!isIntraCom || idacc_unabatable == DBNull.Value){
                idacc_unabatable = TipoDocYear["idacc_unabatable"];
            }
            //conto per l'iva
            if (deferred){
                invkind_idacc_iva = (TipoDocYear["idacc_deferred"] != DBNull.Value)
                    ? TipoDocYear["idacc_deferred"] : TipoDocYear["idacc"];
            }
            else{
                invkind_idacc_iva = TipoDocYear["idacc"];
            }
            //conto per l'iva di segno opposto per fatture intracom.
            if (isIntraCom){
                if (deferred){
                    invkind_idacc_iva_intracom = (TipoDocYear["idacc_deferred_intra"] != DBNull.Value)
                        ? TipoDocYear["idacc_deferred_intra"] : TipoDocYear["idacc_intra"];
                }
                else{
                    invkind_idacc_iva_intracom = TipoDocYear["idacc_intra"];
                }
            }

            //Per le fatture istituzionali non intracom ignora l'iva detraibileSara 
            if (istituzionale && !isIntraCom){
                invkind_idacc_iva = DBNull.Value;
            }

            byte flag = CfgFn.GetNoNullByte(TipoDoc["flag"]);
            if (isIntraCom && istituzionale){
                object idacc_ivapay = DBNull.Value;
                idreg_iva = idregVersamento12;
                idacc_ivapay = idacc_payment12;
                if (invkind_idacc_iva == DBNull.Value) invkind_idacc_iva = idacc_ivapay;
            }

            string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
            string filterkind = QHC.CmpEq("idinvkind", rDetail["idinvkind"]);
            //DataRow rInvoiceKind = DS.invoicekind.Select(filterkind)[0];
            DataRow rInvoiceKind = Tinvoicekind.Rows[0];// è lo stesso di sopra

            double abatablerate = CfgFn.GetNoNullDouble(
                        Meta.Conn.DO_READ_VALUE("invoicekindyearview",
                        GetData.MergeFilters(filterkind, filterEsercizio)
                        , "abatablerate"));
            double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(rDetail["exchangerate"]));

            ////foreach (DataRow Rinvdet in DS.invoicedetail.Select())
            ////{
            double R_imponibile = CfgFn.GetNoNullDouble(rDetail["taxable"]);

            double iva = CfgFn.GetNoNullDouble(rDetail["tax"]);
            double quantita = CfgFn.GetNoNullDouble(rDetail["number"]);
            double imponibileD = CfgFn.RoundValuta(R_imponibile * quantita * tassocambio);
            decimal imponibile = Convert.ToDecimal(imponibileD);

            double ivaindetraibile = 0;
            double ivadetraibilelorda = 0;
            double ivadetraibile = 0;

            if (istituzionale){
                ivaindetraibile = CfgFn.RoundValuta(iva);
                ivadetraibile = 0;
            }
            else{
                ivaindetraibile = CfgFn.GetNoNullDouble(rDetail["unabatable"]);
                ivadetraibilelorda = CfgFn.RoundValuta((iva - ivaindetraibile));
                ivadetraibile = CfgFn.RoundValuta(ivadetraibilelorda * abatablerate);
            }
            decimal valore_iva_totale = CfgFn.GetNoNullDecimal(rDetail["tax"]);
            decimal valore_iva_detraibile = CfgFn.GetNoNullDecimal(ivadetraibile);
            decimal iva_indetraibile = valore_iva_totale - valore_iva_detraibile;

            // valore_costo = da usare unitamente al conto di costo
            //   è pari all'imponibile + iva indetraibile ove il conto dell'iva indetraibile non sia configurato
            decimal valore_costo = CfgFn.GetNoNullDecimal(imponibile);
            if (idacc_unabatable == DBNull.Value){
                valore_costo += iva_indetraibile;
            }

            if (invkind_idacc_iva == DBNull.Value && valore_iva_detraibile > 0){
                string tipo = deferred ? "differita" : "immediata";
                // I messaggi nella generazine delle scritture NON verranno visualizzati
                MessageBox.Show("Non è stata trovato il conto per l'iva " + tipo + " per il tipo documento " +
                    rDetail["idinvkind"].ToString());
                valore_costo = valore_costo + valore_iva_detraibile;
                valore_iva_detraibile = 0;
            }

            if (invkind_idacc_iva == DBNull.Value && isIntraCom && istituzionale && iva_indetraibile > 0){
                MessageBox.Show("Non è stata trovato il conto per l'iva  per il tipo documento " +
                    rDetail["idinvkind"].ToString());
                iva_indetraibile = 0;
            }

            object idaccmotive = rDetail["idaccmotive"];
            if (idaccmotive == DBNull.Value){
                MessageBox.Show("Attenzione, il dettaglio " + rDetail["detaildescription"].ToString() +
                    " non ha la causale!");
                return;//continue; Diventa un return perchè siamo già nel dettaglio
            }

            DataRow[] REntries = EP.GetAccMotiveDetails(idaccmotive);
            if (REntries.Length == 0){
                MessageBox.Show("Non è stato configurata la causale di costo del dettaglio n." +
                    rDetail["rownum"].ToString() + ". La scrittura non pareggerà.", "Errore");
            }

            //scrittura sul costo iva indetraibile (solo per gli acquisti ove conto configurato)
            if (idacc_unabatable != DBNull.Value && iva_indetraibile > 0){
                // NON DEVE EFFETTUARE LA SCRITTURA MA DEVE INSERIRE LA RIGA NELLA TABELLA
                    DataRow RigadaVisualizzare = DS.Tables["Info"].NewRow();
                    foreach (DataColumn C in Tinvoicedetail.Columns){
                        if (!DS.Tables["Info"].Columns.Contains(C.ColumnName)) continue;
                        RigadaVisualizzare[C.ColumnName] = rDetail[C.ColumnName];
                    }
                    RigadaVisualizzare["amount"] = iva_indetraibile;

                    DS.Tables["Info"].Rows.Add(RigadaVisualizzare);
            }

            //scrittura su costo/ricavo (eventualmente include iva indetraibile)
            foreach (DataRow RE in REntries){
                // NON DEVE EFFETTUARE LA SCRITTURA MA DEVE INSERIRE LA RIGA NELLA TABELLA
                    DataRow RigadaVisualizzare = DS.Tables["Info"].NewRow();
                    foreach (DataColumn C in Tinvoicedetail.Columns){
                        if (!DS.Tables["Info"].Columns.Contains(C.ColumnName)) continue;
                        RigadaVisualizzare[C.ColumnName] = rDetail[C.ColumnName];
                    }
                    RigadaVisualizzare["amount"] = valore_costo;

                    DS.Tables["Info"].Rows.Add(RigadaVisualizzare);
            }
        }
     

        bool GeneraScritture(){
            if (MessageBox.Show("Si vuole procedere alla generazione delle scritture in partita doppia ?", "Avviso",
                    MessageBoxButtons.OKCancel) == DialogResult.Cancel) return false;
            DataTable storeunloaddetail = Conn.CreateTableByName("storeunloaddetail", "*");

            foreach (DataRow rDetail in Tinvoicedetail.Select()){
                
                EP_functions EP = new EP_functions(Meta.Dispatcher);
                if (!EP.attivo) return false;

                string filter = QHS.AppAnd(QHS.CmpEq("idstoreunload", rDetail["idstoreunload"]), QHS.CmpEq("idstoreunloaddetail", rDetail["idstoreunloaddetail"]));
                Conn.RUN_SELECT_INTO_TABLE(storeunloaddetail, null, filter, null, true);

                DataRow rStoreunloaddetail = storeunloaddetail.Select(filter)[0];
                EP.GetEntryForDocument(rStoreunloaddetail);

                object doc = DBNull.Value;
                doc = "Scarico n. "+rDetail["nstoreunload"].ToString();

                DataRow rr = EP.SetEntry(rDetail["description"], rDetail["adate"],
                    doc, DBNull.Value, EP_functions.GetIdForDocument(rStoreunloaddetail));

                EP.ClearDetails(rr);
                
                //---------------------------------------------------------------------------------------------------
                object idreg = rDetail["idreg"];
                object idreg_iva = idreg;
                object esercizio = Meta.GetSys("esercizio");

                DataRow currInvSetup = DS.config.Rows[0];

                object idregVersamento12 = currInvSetup["paymentagency12"];
                object idregRimborso12 = currInvSetup["refundagency12"];
                object idacc_refund12 = EP.GetAccountForIvaRefund12();
                object idacc_payment12 = EP.GetAccountForIvaPayment12();


                bool istituzionale = (CfgFn.GetNoNullInt32(rDetail["TipoAttivita"]) == 1);
                bool deferred = (rDetail["flagdeferred"].ToString().ToUpper() == "S");
                bool isIntraCom = (rDetail["flagintracom"].ToString().ToUpper() != "N");// Flagintracom può valere: S-intracom, N o X-extracom.
                bool INVERTI_DEBITO_CREDITO = (istituzionale && isIntraCom);

                string filtroInvKind = QHS.CmpEq("idinvkind", rDetail["idinvkind"]);

                DataTable Tinvoicekind = Conn.RUN_SELECT("invoicekind", "*", null, filtroInvKind, null, true);
                DataRow TipoDoc = Tinvoicekind.Rows[0];

                filtroInvKind = QHS.AppAnd(QHS.CmpEq("ayear", Meta.GetSys("esercizio")), filtroInvKind);
                DataTable Tinvoicekindyear = Conn.RUN_SELECT("invoicekindyear", "*", null, filtroInvKind, null, true);
                DataRow TipoDocYear = Tinvoicekindyear.Rows[0];

                object invkind_idacc_iva = DBNull.Value;
                object invkind_idacc_iva_intracom = DBNull.Value;

                object idacc_unabatable = DBNull.Value;
                //costo iva indetraibile (per chi calcola riga per riga e gestisce tale conto)
                if (isIntraCom){
                    idacc_unabatable = TipoDocYear["idacc_unabatable_intra"];
                }
                if (!isIntraCom || idacc_unabatable == DBNull.Value){
                    idacc_unabatable = TipoDocYear["idacc_unabatable"];
                }
                //conto per l'iva
                if (deferred){
                    invkind_idacc_iva = (TipoDocYear["idacc_deferred"] != DBNull.Value)
                        ? TipoDocYear["idacc_deferred"] : TipoDocYear["idacc"];
                }
                else{
                    invkind_idacc_iva = TipoDocYear["idacc"];
                }
                //conto per l'iva di segno opposto per fatture intracom.
                if (isIntraCom){
                    if (deferred){
                        invkind_idacc_iva_intracom = (TipoDocYear["idacc_deferred_intra"] != DBNull.Value)
                            ? TipoDocYear["idacc_deferred_intra"] : TipoDocYear["idacc_intra"];
                    }
                    else{
                        invkind_idacc_iva_intracom = TipoDocYear["idacc_intra"];
                    }
                }

                //Per le fatture istituzionali non intracom ignora l'iva detraibileSara 
                if (istituzionale && !isIntraCom){
                    invkind_idacc_iva = DBNull.Value;
                }

                object invkind_idacc_discount = TipoDocYear["idacc_discount"];
                byte flag = CfgFn.GetNoNullByte(TipoDoc["flag"]);
                string idepcontext;
                idepcontext = "FATACQ";

                if (isIntraCom && istituzionale){
                    object idacc_ivapay = DBNull.Value;
                    idreg_iva = idregVersamento12;
                    idacc_ivapay = idacc_payment12;
                    if (invkind_idacc_iva == DBNull.Value) invkind_idacc_iva = idacc_ivapay;
                }

                string filterEsercizio = QHC.CmpEq("ayear", Meta.GetSys("esercizio"));
                string filterkind = QHC.CmpEq("idinvkind", rDetail["idinvkind"]);
                DataRow rInvoiceKind = Tinvoicekind.Rows[0];// è lo stesso di sopra

                double abatablerate = CfgFn.GetNoNullDouble(
                            Meta.Conn.DO_READ_VALUE("invoicekindyearview",
                            GetData.MergeFilters(filterkind, filterEsercizio)
                            , "abatablerate"));

                double tassocambio = CfgFn.GetNoNullDouble(CfgFn.GetNoNullDouble(rDetail["exchangerate"]));

                double R_imponibile = CfgFn.GetNoNullDouble(rDetail["taxable"]);

                double iva = CfgFn.GetNoNullDouble(rDetail["tax"]);
                double quantita = CfgFn.GetNoNullDouble(rDetail["number"]);
                double imponibileD = CfgFn.RoundValuta(R_imponibile * quantita * tassocambio);
                decimal imponibile = Convert.ToDecimal(imponibileD);

                double ivaindetraibile = 0;
                double ivadetraibilelorda = 0;
                double ivadetraibile = 0;

                if (istituzionale){
                    ivaindetraibile = CfgFn.RoundValuta(iva);
                    ivadetraibile = 0;
                }
                else{
                    ivaindetraibile = CfgFn.GetNoNullDouble(rDetail["unabatable"]);
                    ivadetraibilelorda = CfgFn.RoundValuta((iva - ivaindetraibile));
                    ivadetraibile = CfgFn.RoundValuta(ivadetraibilelorda * abatablerate);
                }
                decimal valore_iva_totale = CfgFn.GetNoNullDecimal(rDetail["tax"]);

                //iva = iva detraibile, da movimentarsi con il conto normale dell'iva (acq/vendite)
                decimal valore_iva_detraibile = CfgFn.GetNoNullDecimal(ivadetraibile);
                decimal iva_indetraibile = valore_iva_totale - valore_iva_detraibile;

                // valore_costo = da usare unitamente al conto di costo
                //   è pari all'imponibile + iva indetraibile ove il conto dell'iva indetraibile non sia configurato
                decimal valore_costo = CfgFn.GetNoNullDecimal(imponibile);
                if (idacc_unabatable == DBNull.Value){
                    valore_costo += iva_indetraibile;
                }

                if (invkind_idacc_iva == DBNull.Value && valore_iva_detraibile > 0)
                {
                    string tipo = deferred ? "differita" : "immediata";
                    //////MessageBox.Show("Non è stata trovato il conto per l'iva " + tipo + " per il tipo documento " +
                    //////    rDetail["idinvkind"].ToString());
                    valore_costo = valore_costo + valore_iva_detraibile;
                    valore_iva_detraibile = 0;
                    //return;
                }

                if (invkind_idacc_iva == DBNull.Value && isIntraCom && istituzionale && iva_indetraibile > 0){
                    //////MessageBox.Show("Non è stata trovato il conto per l'iva  per il tipo documento " +
                    //////    rDetail["idinvkind"].ToString());
                    iva_indetraibile = 0;
                }

                object idaccmotive = rDetail["idaccmotive"];
                if (idaccmotive == DBNull.Value)
                {
                    //////MessageBox.Show("Attenzione, il dettaglio " + rDetail["detaildescription"].ToString() +
                    //////    " non ha la causale!");
                    continue; 
                }
                object idaccmotive_main_debit = rDetail["idaccmotivedebit"];
                if (idaccmotive_main_debit == DBNull.Value)
                {
                    idaccmotive_main_debit = idaccmotive;
                }
                DataRow[] REntries = EP.GetAccMotiveDetails(idaccmotive);
                if (REntries.Length == 0){
                    //////MessageBox.Show("Non è stato configurata la causale di costo del dettaglio n." +
                    //////    rDetail["rownum"].ToString() + ". La scrittura non pareggerà.", "Errore");
                }

                //scrittura sul costo iva indetraibile (solo per gli acquisti ove conto configurato)
                // COSTO NUOVO
                if (idacc_unabatable != DBNull.Value && iva_indetraibile > 0)
                {
                    EP.EffettuaScrittura(idepcontext,
                        iva_indetraibile,
                        idacc_unabatable,
                        idreg, rDetail["idupb"], rDetail["competencystart"], rDetail["competencystop"],
                        rDetail, idaccmotive);
                }

                //scrittura su costo/ricavo (eventualmente include iva indetraibile)
                foreach (DataRow RE in REntries)
                {
                    EP.EffettuaScrittura(idepcontext,
                        valore_costo,
                        RE["idacc"],
                        idreg, rDetail["idupb"], rDetail["competencystart"], rDetail["competencystop"],
                        rDetail, idaccmotive);
                }

                // A COSTO VECCHIO sulle vecchie coordiante
                ToldIdsor.Clear();
                DataRow Roldidsor = DS.Tables["ToldIdsor"].NewRow();
                Roldidsor["idsor1"] = rDetail["invidsor1"];
                Roldidsor["idsor2"] = rDetail["invidsor2"];
                Roldidsor["idsor3"] = rDetail["invidsor3"];
                DS.Tables["ToldIdsor"].Rows.Add(Roldidsor);

                if (idacc_unabatable != DBNull.Value && iva_indetraibile > 0)
                {
                    EP.EffettuaScrittura(idepcontext,
                        -iva_indetraibile,
                        idacc_unabatable,
                        idreg, rDetail["idupb"], rDetail["competencystart"], rDetail["competencystop"],
                        Roldidsor, idaccmotive);
                }

                //scrittura su costo/ricavo (eventualmente include iva indetraibile)
                foreach (DataRow RE in REntries)
                {
                    EP.EffettuaScrittura(idepcontext,
                        -valore_costo,
                        RE["idacc"],
                        idreg, rDetail["idupb"], rDetail["competencystart"], rDetail["competencystop"],
                        Roldidsor, idaccmotive);
                }

                //---------------------------------------------------------------------------------------------------
                EP.RemoveEmptyDetails();

                MetaData MetaEntry = MetaData.GetMetaData(this, "entry");
                PostData Post = MetaEntry.Get_PostData();

                Post.InitClass(EP.D, Meta.Conn);
                if (Post.DO_POST()){
                    EditEntry(EP, rDetail);
                }
            }
            return true;
        }

        void EditEntry(EP_functions EP, DataRow rDetail){
            DataTable storeunloaddetail = Conn.CreateTableByName("storeunloaddetail", "*");
                string filter = QHS.AppAnd(QHS.CmpEq("idstoreunload", rDetail["idstoreunload"]), QHS.CmpEq("idstoreunloaddetail", rDetail["idstoreunloaddetail"]));
                Conn.RUN_SELECT_INTO_TABLE(storeunloaddetail, null, filter, null, true);

                DataRow rStoreunloaddetail = storeunloaddetail.Select(filter)[0];
                EP.EditRelatedEntry(Meta, rStoreunloaddetail);
        }

        private void btnOK_Click(object sender, EventArgs e){
            this.Close();
            this.Dispose();
        }

    }
}