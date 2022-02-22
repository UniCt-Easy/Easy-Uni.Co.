
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
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace assetacquire_massive {
    public partial class FrmAssetacquire_massive : MetaDataForm {
        public FrmAssetacquire_massive() {
            InitializeComponent();
            this.txtQuantita.LostFocus += new System.EventHandler(this.txtQuantita_LostFocus);
            InChiusura = false;

            GetData.SetSorting(DS.upb, "codeupb ASC");
            cboCausale.DataSource = DS.assetloadmotive;
            cboInventario.DataSource = DS.inventory;
            cmbTipoOrdine.DataSource = DS.mandatekind;
            DataAccess.SetTableForReading(DS.managercespiti, "manager");
            DataAccess.SetTableForReading(DS.managerconsegnatario, "manager");
            DataAccess.SetTableForReading(DS.manager1, "manager");

        }

        private void chkHideTipoCarico_CheckStateChanged(object sender, EventArgs e) {
            grpTipoCarico.Visible = !chkHideTipoCarico.Checked;
        }

        QueryHelper QHS;
        CQueryHelper QHC;
        MetaData Meta;
        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            txtNumIniz.LostFocus += new System.EventHandler(this.txtNumIniz_LostFocus);
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            QHC = new CQueryHelper();

            string filter = "(ayear=" + QueryCreator.quotedstrvalue(Meta.GetSys("esercizio"), true) + ")";
            GetData.CacheTable(DS.config, filter, null, false);
            GetData.CacheTable(DS.multifieldkind, null, null, false);
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");
            DataTable tExpSetup = Meta.Conn.RUN_SELECT("config", "*", null,
            filter, null, null, true);
            if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
                DataRow R = tExpSetup.Rows[0];
                string idsorkind1 = R["idsortingkind1"].ToString();
                string idsorkind2 = R["idsortingkind2"].ToString();
                string idsorkind3 = R["idsortingkind3"].ToString();
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);

                if (gboxclass1.Visible == false && gboxclass2.Visible == false
                                                && gboxclass3.Visible == false) {
                    grpAnalitico.Visible = false;
                }
            }
            GetData.CacheTable(DS.multifieldkind, null, null, false);

        }

        void SetGBoxClass(int num, string sortingkind) {
            if (sortingkind == "") {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = "(idsorkind=" +
                    QueryCreator.quotedstrvalue(sortingkind, true) + ")";
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }
        object GetCtrlByName(string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        void EnableDisableButt() {
            if (Meta.InsertMode) {
                btnSalva.Visible = true;
                btnNuoviDati.Visible = false;
                txtComments.Visible = false;
                btnMostraCarico.Visible = false;
                tabControl.TabPages[0].Enabled = true;
                tabControl.TabPages[1].Enabled = true;
                tabControl.TabPages[2].Enabled = true;
            }
            else {
                btnSalva.Visible = false;
                btnNuoviDati.Visible = true;
                txtComments.Visible = true;
                btnMostraCarico.Visible = true;
                tabControl.TabPages[0].Enabled = false;
                tabControl.TabPages[1].Enabled = false;
                tabControl.TabPages[2].Enabled = false;
            }
        }
        

        private void txtImponibile_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaTotali(true, true);
        }


        private void txtImposta_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaTotali(true, true);
        }


        private void txtSconto_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            CalcolaTotali(true, true);
        }

        decimal TotIvaDetraibile = 0;
        decimal TotIvaGenerale = 0;
        decimal IvaGenResiduo = 0;
        decimal IvaDetResiduo = 0;
        int totquantita = 0;
        int residuo = 0;
        
        private void CalcolaTotali(bool EseguiGetFormData, bool RicalcolaTotIva) {
            if (MetaData.Empty(this)) return;

            //Se non sono in salvataggio eseguo la lettura
            if (EseguiGetFormData) MetaData.GetFormData(this, true);


            DataRow R = DS.Tables["assetacquire"].Rows[0];
            decimal imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
            decimal quantita = CfgFn.GetNoNullDecimal(R["number"]);
            decimal sconto = CfgFn.GetNoNullDecimal(R["discount"]);
            decimal imposta = CfgFn.GetNoNullDecimal(R["taxrate"]);
            decimal ivadetraibile = CfgFn.GetNoNullDecimal(R["abatable"]);

            decimal imponibiletot = CfgFn.RoundValuta(imponibile * (1 - sconto)) * quantita;
            decimal impostatot;
          
            if (RicalcolaTotIva) {
                if (MandateLinked) {
                    if (quantita == residuo || residuo == 0) {
                        impostatot = IvaGenResiduo;
                        ivadetraibile = IvaDetResiduo;
                    }
                    else {
                        impostatot =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                                Decimal.Truncate(IvaGenResiduo * 100 / residuo) / 100) * quantita);
                        ivadetraibile =
                            CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                                Decimal.Truncate(IvaDetResiduo * 100 / residuo) / 100) * quantita);

                    }
                }
                else {
                    impostatot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)) * imposta);
                }
            }
            else {
                impostatot = CfgFn.GetNoNullDecimal(R["tax"]);
            }

            decimal imponibileconiva = imponibiletot + impostatot;
            txtImpTotale.Text = imponibiletot.ToString("c");
            txtImpostaTotale.Text = impostatot.ToString("c");
            txtImpConIVA.Text = imponibileconiva.ToString("c");
            txtAbatable.Text = ivadetraibile.ToString("c");
        }

        bool CanGoInsert = true;

        public void MetaData_AfterClear() {
            AbilitaTipoCarico(true);
            AbilitaRigaOrdine(true);
            AbilitaAutoNumerazione(false);
            MandateLinked = false;
            //tabPageUtilizzo.Visible=true;
            ImpostaAutoIncrementoNumInventario(false);
            txtImpTotale.Text = "";
            txtImpostaTotale.Text = "";
            txtImpConIVA.Text = "";
            grpInventario.Enabled = true;
            btnNumInventario.Enabled = false;
            txtCredDeb.ReadOnly = false;
            HelpForm.SetDenyNull(DS.assetacquire.Columns["startnumber"], false);
            txtComments.Text = "";
            GetData.CacheTable(DS.multifieldkind, null, null, false);
            DisabilitaFattura(true);

            if (!CanGoInsert) return;
            CanGoInsert = false;
            MetaData.MainAdd(this);
        }

        public void DisabilitaFattura(bool enable) {
            grpRigaFattura.Enabled = enable;
        }

        /// <summary>
        /// Filtro sui 3 textbox
        /// </summary>
        /// <returns></returns>
        private string CalcolaFiltro() {
            string filter = "";
            if (cmbTipoOrdine.SelectedValue != null && cmbTipoOrdine.SelectedValue.ToString() != "") {
                filter = QHS.AppAnd(filter, QHC.CmpEq("idmankind", cmbTipoOrdine.SelectedValue));
            }

            string esercordine = txtEsercordine.Text.Trim();
            if (esercordine != "") filter = QHS.AppAnd(filter, QHS.CmpEq("yman", CfgFn.GetNoNullInt32(esercordine)));
            string numordine = txtNumordine.Text.Trim();
            if (numordine != "") filter = QHS.AppAnd(filter, QHS.CmpEq("nman", CfgFn.GetNoNullInt32(numordine)));
            string numriga = txtNumriga.Text.Trim();
            //			if (numriga!="") filter += "AND (rownum='"+numriga+"')";
            if (numriga != "") QHS.AppAnd(filter, QHS.CmpEq("idgroup", CfgFn.GetNoNullInt32(numriga)));
            filter = QHS.AppAnd(filter, QHS.CmpEq("idmandatestatus", 5)); // stato approvato
	
            return filter;
        }

        private void btnCollegaRiga_Click(object sender, System.EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            MetaData MRiga;
            //DataRow Curr = null;

            if (!Meta.IsEmpty) Meta.GetFormData(true);

            if ((Meta.InsertMode) || (Meta.EditMode))
                MRiga = MetaData.GetMetaData(this, "mandatedetailavailable");
            else
                //MRiga= MetaData.GetMetaData(this,"mandatedetailview");
                //ho creato il nuovo MRiga xkè quando andrà a selezionare la riga di mandatedetailview tramite idgroup 
                //non avrà 1 riga ma n, xkè ci sono nrighe per ogni gruppo in mandatedetailview
                MRiga = MetaData.GetMetaData(this, "mandatedetailgroupview");

            MRiga.FilterLocked = true;
            MRiga.DS = DS;

            string filter = CalcolaFiltro();
            filter = QHS.AppAnd(filter, QHS.CmpEq("linktoasset", "S"), QHS.IsNull("stop"));


            //filtro per quegli ordini che hanno caricato beni inventariabili e il cui ordine
            //ha un residuo diverso da zero
            string staticfilter;
            // Rusciano G. 09.03.2005 - La ricerca sulla disponibilità dei dettagli dell'ordine 
            // deve essere fatta sia in Insert che in Edit Mode
            // il dettaglio dell'ordine deve avere residuo > 0 e non <> 0
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                //sara, il residuo è calcolato su idgroup di mandatedetail non più su rownum
                staticfilter = QHS.AppAnd(QHS.CmpGt("residual", 0), QHS.IsNotNull("codeinv"));
                staticfilter = QHS.AppAnd(staticfilter, QHS.CmpEq("assetkind", "A"));
            }
            else // siamo in ricerca
                staticfilter = QHS.IsNotNull("codeinv");

            DataRow selRow = MRiga.SelectOne("dettaglio", QHS.AppAnd(staticfilter, filter), null, null);

            if (selRow == null) {
                if (Meta.InsertMode) {
                    if (typeof(TextBox).IsAssignableFrom(sender.GetType())) {
                        if (((TextBox)sender).Text.Trim() != "") ((TextBox)sender).Focus();
                    }
                }
                return;
            }


            //valorizzo dipendenti
            // Rusciano G. valorizzo i dipendenti non solo in Insert Mode ma anche in Edit Mode
            if ((Meta.InsertMode) || (Meta.EditMode)) {
                int oldquantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);

                DS.assetacquire.Rows[0]["idmankind"] = selRow["idmankind"];
                DS.assetacquire.Rows[0]["yman"] = selRow["yman"];
                DS.assetacquire.Rows[0]["nman"] = selRow["nman"];
                DS.assetacquire.Rows[0]["rownum"] = selRow["idgroup"];


                AbilitaCredDeb(false);
                string filtro_group = QHS.MCmp(selRow, "idmankind", "yman", "nman", "idgroup");
                string filtro_row = QHS.AppAnd(QHS.MCmp(selRow, "idmankind", "yman", "nman"),
                            QHS.CmpEq("rownum", selRow["idgroup"]));

                //				DataTable rOrdineGroup=Conn.RUN_SELECT("mandatedetailview","*",null,filtro,null,false);
                DataTable OrdineGroup = Conn.RUN_SELECT("mandatedetailgroupview", "*", null, filtro_group, null, false);

                var rOrdineGroup = OrdineGroup.First();

                DataTable ordUpb = Conn.SQLRunner("select * from mandatedetail where " + filtro_group, true);
                object iddupb = DBNull.Value;

                if (ordUpb != null && ordUpb.Rows.Count == 1) {
                    DS.assetacquire.Rows[0]["idupb"] = ordUpb.Rows[0]["idupb"];
                    DS.assetacquire.Rows[0]["idsor1"] = ordUpb.Rows[0]["idsor1"];
                    DS.assetacquire.Rows[0]["idsor2"] = ordUpb.Rows[0]["idsor2"];
                    DS.assetacquire.Rows[0]["idsor3"] = ordUpb.Rows[0]["idsor3"];
                }

                // Maria S. 20 06 2005: alcuni dettagli ordine hanno la descrizione null.
                // Eccezione nel richiamarli
                if (selRow["detaildescription"] == DBNull.Value) {
                    DS.assetacquire.Rows[0]["description"] = "";
                }
                else {
                    DS.assetacquire.Rows[0]["description"] = selRow["detaildescription"];
                }
                string filtroOrdine = QHS.MCmp(selRow, "idmankind", "yman", "nman");

                object tassoCambio = Meta.Conn.DO_READ_VALUE("mandate", filtroOrdine, "exchangerate");
                DS.assetacquire.Rows[0]["idreg"] = rOrdineGroup["idreg"];
                DS.assetacquire.Rows[0]["idinv"] = rOrdineGroup["idinv"];

                if (rOrdineGroup["idlist"] != DBNull.Value) {
                    DS.assetacquire.Rows[0]["idlist"] = rOrdineGroup["idlist"];

                }

                DataRow Rinv = SelezionaRigaFattura(rOrdineGroup);
                decimal impostacaricata = 0;
                decimal detraibilecaricato = 0;
                if (Rinv == null) {

                    DS.assetacquire.Rows[0]["idinvkind"] = DBNull.Value;
                    DS.assetacquire.Rows[0]["yinv"] = DBNull.Value;
                    DS.assetacquire.Rows[0]["ninv"] = DBNull.Value;
                    DS.assetacquire.Rows[0]["invrownum"] = DBNull.Value;


                    DS.assetacquire.Rows[0]["taxable"] = CfgFn.GetNoNullDecimal(rOrdineGroup["taxable"])
                        * CfgFn.GetNoNullDecimal(tassoCambio);
                    DS.assetacquire.Rows[0]["taxrate"] = rOrdineGroup["taxrate"];
                    DS.assetacquire.Rows[0]["discount"] = rOrdineGroup["discount"];


                    //svuoto i dati di cespite posseduto
                    //				DS.assetacquire.Rows[0]["yassetload"] = DBNull.Value;
                    //				DS.assetacquire.Rows[0]["nassetload"] = DBNull.Value;

                    //necessariamente da dettordinegenericooperativo
                    residuo = CfgFn.GetNoNullInt32(selRow["residual"]);

                    totquantita = CfgFn.GetNoNullInt32(rOrdineGroup["number"]);

                    TotIvaGenerale = CfgFn.GetNoNullDecimal(rOrdineGroup["tax"]);
                     impostacaricata = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                            filtro_row, "SUM(tax)"));
                     detraibilecaricato = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtro_row, "SUM(abatable)"));

                }
                else {
                    DS.assetacquire.Rows[0]["idinvkind"] = Rinv["idinvkind"];
                    DS.assetacquire.Rows[0]["yinv"] = Rinv["yinv"];
                    DS.assetacquire.Rows[0]["ninv"] = Rinv["ninv"];
                    DS.assetacquire.Rows[0]["invrownum"] = Rinv["invidgroup"];
                    DS.assetacquire.Rows[0]["taxable"] = CfgFn.Round(CfgFn.GetNoNullDecimal(Rinv["taxable"])
                                                                     * CfgFn.GetNoNullDecimal(tassoCambio), 2);

                    DS.assetacquire.Rows[0]["taxrate"] = Rinv["taxrate"];
                    DS.assetacquire.Rows[0]["discount"] = Rinv["discount"];
                    string filtro_groupinv = QHS.MCmp(Rinv, "idinvkind", "yinv", "ninv", "invidgroup");
                    object otax = Conn.DO_READ_VALUE("invoicedetailgroupview", filtro_groupinv, "tax", null);
                    decimal ivafattura = CfgFn.GetNoNullDecimal(otax);
                    int quantitafattura = CfgFn.GetNoNullInt32(Rinv["invoiced"]); //q.tà della fattura
                    int quantitacarico = CfgFn.GetNoNullInt32(Rinv["residual"]);// disponibile della fattura da caricare
                    residuo = CfgFn.GetNoNullInt32(Rinv["residual"]);
                    TotIvaGenerale = ivafattura;
                    //CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                    //    Decimal.Truncate(ivafattura * 100 / quantitafattura) / 100) * quantitacarico);
                    string filtro_inv = QHS.MCmp(Rinv, "idinvkind", "yinv", "ninv");
                    filtro_inv = QHS.AppAnd(filtro_inv, QHS.CmpEq("invrownum", Rinv["invidgroup"]));
                    impostacaricata = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtro_inv, "SUM(tax)"));
                    detraibilecaricato = CfgFn.GetNoNullDecimal(Conn.DO_READ_VALUE("assetacquire",
                        filtro_inv, "SUM(abatable)"));

                }
                IvaGenResiduo = TotIvaGenerale - impostacaricata;

                DS.assetacquire.Rows[0]["tax"] = IvaGenResiduo;

                Meta.FreshForm();
                DS.assetacquire.Rows[0]["number"] = residuo;
                txtQuantita.Text = residuo.ToString();

                if (Rinv != null) {
                    DataTable FatturaGroup = Conn.RUN_SELECT("invoicedetailgroupview", "*", null, QHS.MCmp(Rinv, "idinvkind", "yinv", "ninv", "invidgroup"), null, false);
                    TotIvaDetraibile = calcolaIvaDetraibile(rOrdineGroup, FatturaGroup.Rows[0]);
                }
                else {
                    TotIvaDetraibile = calcolaIvaDetraibile(rOrdineGroup, null);
                }
                                

                IvaDetResiduo = TotIvaDetraibile - detraibilecaricato;
                DS.assetacquire.Rows[0]["abatable"] = IvaDetResiduo;
                txtAbatable.Text = IvaDetResiduo.ToString("c");
                MandateLinked = true;

                if (CheckShowHint(IvaGenResiduo, IvaDetResiduo, residuo))
                    ShowHint(IvaGenResiduo, IvaDetResiduo, residuo);


                if (AggiornaRigheBeneInv(residuo, oldquantita))
                    CalcolaTotali(false, false);


                Object idlocation = rOrdineGroup["idlocation"];
                if (idlocation != DBNull.Value) {

                    MetaData.SetDefault(DS.assetlocation, "idlocation", idlocation);
                    AggiornaUbicazioneDaContrattoPassivo(idlocation);
                }


            }
            else {
                HelpForm.SetComboBoxValue(cmbTipoOrdine, selRow["idmankind"]);
                txtEsercordine.Text = selRow["yman"].ToString();
                txtNumordine.Text = selRow["nman"].ToString();
                //				txtNumriga.Text= selRow["rownum"].ToString();
                txtNumriga.Text = selRow["idgroup"].ToString();
                MandateLinked = false;
            }
        }

        /*dobbiamo controllare quanti sono i dett. fattura collegati a quell'ordine non ancora collegati a carichi: se ce ne sono 0, non facciamo niente, 
        se è 1 lo collego automaticamente, 
        se più di uno lo faccio scegliere dall'utente. 
        Dopo aver selezionato i dett.CP i dati verranno copiati dalla fattura nel carico cespite
        */
        DataRow SelezionaRigaFattura(DataRow SelRowMan) {
            string filter = QHS.AppAnd(QHS.MCmp(SelRowMan, "idmankind", "yman", "nman"),
                    QHS.CmpEq("manidgroup", SelRowMan["idgroup"]));
            filter = QHS.AppAnd(filter, QHS.CmpGt("residual", 0));
            //filter = QHS.AppAnd(filter, QHS.CmpGe("invoiced", SelRowMan["residual"]));// q.tà fattura >= q.tà carico Non va bene qui questa condizione [*]

            DataAccess Conn = MetaData.GetConnection(this);
            DataTable FatureView = Conn.RUN_SELECT("invoicedetailavailable", "*", null, filter, null, false);
            if (FatureView.Rows.Count == 0) return null;
            if (FatureView.Rows.Count == 1) return FatureView.Rows[0];
            if (FatureView.Rows.Count > 1) {
                MetaData MRigaInv = MetaData.GetMetaData(this, "invoicedetailavailable");
                MRigaInv.FilterLocked = true;
                MRigaInv.DS = DS;
                DataRow selRowInv = MRigaInv.SelectOne("dettaglio", filter, null, null);
                return selRowInv;
            }
            return null;
        }



        public void MetaData_BeforeFill() {
            if (Meta.IsEmpty) return;
            if (DS.assetacquire.Rows.Count == 0) return;
            DataRow R = DS.assetacquire.Rows[0];
            DataTable IDAvailable = null;
            DataRow rInvdetAvailable = null;
            if (R["idmankind"] != DBNull.Value &&
                R["yman"] != DBNull.Value &&
                R["nman"] != DBNull.Value &&
                R["rownum"] != DBNull.Value && !MandateLinked) {

                string filtro_cp = QHS.AppAnd(QHS.CmpEq("idmankind", R["idmankind"]), QHS.CmpEq("yman", R["yman"]),
                    QHS.CmpEq("nman", R["nman"]), QHS.CmpEq("idgroup", R["rownum"]));
                string filtro_CPperCespite = QHS.MCmp(R, "idmankind", "yman", "nman", "rownum");
                string filtro_Fattura = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]),
                QHS.CmpEq("ninv", R["ninv"]), QHS.CmpEq("invidgroup", R["invrownum"]));
                string filtro_FatturaPerCespite = QHS.AppAnd(QHS.CmpEq("idinvkind", R["idinvkind"]), QHS.CmpEq("yinv", R["yinv"]),
                QHS.CmpEq("ninv", R["ninv"]), QHS.CmpEq("invrownum", R["invrownum"]));
                DataTable MDAvailable = Meta.Conn.RUN_SELECT("mandatedetailavailable", "*", null, filtro_cp, null, false);
                residuo = 0;
                if (MDAvailable.Rows.Count == 0) {
                    show("Non ci sono dettagli dell'ordine specificato attivi. " +
                                    "Presumibilmente i dettagli associati sono stati cancellati o annullati. " +
                                    "E' necessario correggere i dati del contratto passivo correlato.");
                    //RIMOSSO PERCHE' GENERAVA ECCEZIONE MA C'E' GIA' MESSAGE BOX CHE AVVISA UTENTE 
                    //Meta.LogError("AssetAcquireMassive - MetaData_BeforeFill -  condizione di errore 1322- filtro:" + filtro_cp + " carico chiave:" +
                    //    QHS.CmpKey(R));
                    if (Meta.InsertMode) {
                        DS.asset.Clear();
                        R["idmankind"] = DBNull.Value;
                        R["yman"] = DBNull.Value;
                        R["nman"] = DBNull.Value;
                        R["rownum"] = DBNull.Value;
                        txtNumriga.Text = "";
                        txtNumordine.Text = "";
                        txtEsercordine.Text = "";
                        TotIvaGenerale = 0;
                        TotIvaDetraibile = 0;
                        IvaDetResiduo = 0;
                        IvaGenResiduo = 0;
                        totquantita = 0;
                        cmbTipoOrdine.SelectedIndex = -1;
                        return;
                    }
                }
                else {
                    IDAvailable = Meta.Conn.RUN_SELECT("invoicedetailavailable", "*", null, filtro_Fattura, null, false);
                    if (IDAvailable.Rows.Count > 0) {
                        rInvdetAvailable = IDAvailable.Rows[0];
                        residuo = CfgFn.GetNoNullInt32(rInvdetAvailable["residual"]);
                    }
                    else {
                        DataRow MDRAvailable = MDAvailable.Rows[0];
                        residuo = CfgFn.GetNoNullInt32(MDRAvailable["residual"]);
                    }
                }

                DataTable MDView = Meta.Conn.RUN_SELECT("mandatedetailgroupview", "*", null, filtro_cp, null, true);
                DataTable FatturaGroup = Conn.RUN_SELECT("invoicedetailgroupview", "*", null, filtro_Fattura, null, false);
                decimal impostacaricata = 0;
                decimal detraibilecaricato = 0;
                if (MDView.Rows.Count == 0) {
                    TotIvaGenerale = 0;
                    TotIvaDetraibile = 0;
                    IvaDetResiduo = 0;
                    IvaGenResiduo = 0;
                    totquantita = 0;
                }
                else {
                    DataRow MDRView = MDView.Rows[0];
                    if (FatturaGroup.Rows.Count > 0) {
                        impostacaricata = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_FatturaPerCespite, "SUM(tax)"));
                        detraibilecaricato = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_FatturaPerCespite, "SUM(abatable)"));
                        DataRow rFatturaGroup = FatturaGroup.Rows[0];
                        decimal ivafattura = CfgFn.GetNoNullDecimal(FatturaGroup.Rows[0]["tax"]);
                        int quantitafattura = CfgFn.GetNoNullInt32(rInvdetAvailable["invoiced"]); //q.tà della fattura
                        int quantitacarico = CfgFn.GetNoNullInt32(rInvdetAvailable["residual"]);// disponibile della fattura da caricare
                        residuo = CfgFn.GetNoNullInt32(rInvdetAvailable["residual"]);
                        TotIvaGenerale = ivafattura;
                        //CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(
                        //    Decimal.Truncate(ivafattura * 100 / quantitafattura) / 100) * quantitacarico);
                        TotIvaDetraibile = calcolaIvaDetraibile(MDRView, rFatturaGroup);                       
                        IvaDetResiduo = TotIvaDetraibile - detraibilecaricato;
                        IvaGenResiduo = TotIvaGenerale - impostacaricata;
                        totquantita = CfgFn.GetNoNullInt32(rFatturaGroup["number"]);


                    }
                    else {
                        impostacaricata = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_CPperCespite, "SUM(tax)"));
                        detraibilecaricato = CfgFn.GetNoNullDecimal(Meta.Conn.DO_READ_VALUE("assetacquire", filtro_CPperCespite, "SUM(abatable)"));
                        TotIvaGenerale = CfgFn.GetNoNullDecimal(MDRView["tax"]);
                        TotIvaDetraibile = calcolaIvaDetraibile(MDRView, null);
                        IvaDetResiduo = TotIvaDetraibile - detraibilecaricato;
                        IvaGenResiduo = TotIvaGenerale - impostacaricata;
                        totquantita = CfgFn.GetNoNullInt32(MDRView["number"]);
                    }
                    if (Meta.EditMode &&
                        R["idmankind", DataRowVersion.Original].ToString() ==
                        R["idmankind", DataRowVersion.Current].ToString() &&
                        R["yman", DataRowVersion.Original].ToString() == R["yman", DataRowVersion.Current].ToString() &&
                        R["nman", DataRowVersion.Original].ToString() == R["nman", DataRowVersion.Current].ToString() &&
                        R["rownum", DataRowVersion.Original].ToString() ==
                        R["rownum", DataRowVersion.Current].ToString()) {
                        residuo += CfgFn.GetNoNullInt32(R["number", DataRowVersion.Original]);
                        IvaDetResiduo += CfgFn.GetNoNullDecimal(R["abatable", DataRowVersion.Original]);
                        IvaGenResiduo += CfgFn.GetNoNullDecimal(R["tax", DataRowVersion.Original]);

                    }
                }
                MandateLinked = true;
            }




            //int flag = CfgFn.GetNoNullInt32(R["flag"]);
            //bool ispieceacquire = ((flag & 4) != 0);
            //if (ispieceacquire) {
            //    if (gridBene.Tag.ToString() != "asset.accessorio.accessorio") {
            //        gridBene.Tag = "asset.accessorio.accessorio";
            //        btnModificaBene.Tag = "edit.accessorio";
            //        gridBene.TableStyles.Clear();
            //        MetaData Asset = MetaData.GetMetaData(this, "asset");
            //        Asset.ComputeRowsAs(DS.Tables["asset"], "accessorio");
            //        Meta.myGetData.GetTemporaryValues(DS.asset);
            //        HelpForm.SetDataGrid(gridBene, DS.asset);

            //    }
            //}
            //else {
            //    if (gridBene.Tag.ToString() != "asset.dettaglio.dettaglio") {
            //        gridBene.Tag = "asset.dettaglio.dettaglio";
            //        btnModificaBene.Tag = "edit.dettaglio";
            //        gridBene.TableStyles.Clear();
            //        MetaData Asset = MetaData.GetMetaData(this, "asset");
            //        Asset.ComputeRowsAs(DS.Tables["asset"], "dettaglio");
            //        Meta.myGetData.GetTemporaryValues(DS.asset);
            //        HelpForm.SetDataGrid(gridBene, DS.asset);
            //    }
            //}
            int nassetacquire = CfgFn.GetNoNullInt32(R["nassetacquire"]);
            int newquantita = DS.asset.Select("nassetacquire=" + nassetacquire).Length;
            int oldquantita = CfgFn.GetNoNullInt32(R["number"]);
            if (newquantita != oldquantita) R["number"] = newquantita;

        }






        void AggiornaUbicazioneDaContrattoPassivo(Object idlocation)
        {

            if (MetaData.Empty(this)) return;
            MetaData.GetFormData(this, true);
            if (DS.assetlocation.Rows.Count == 0)
            {

                foreach (DataRow Curr in DS.asset.Select())
                {
                    MetaData Meta_AssetLocation = Meta.Dispatcher.Get("assetlocation");
                    Meta_AssetLocation.SetDefaults(DS.assetlocation);
                    DataRow RAssetLoc;
                    RAssetLoc = Meta_AssetLocation.Get_New_Row(Curr, DS.assetlocation);
                    RAssetLoc["idlocation"] = idlocation;

                }
            }
            else
            {
                string msg = "Si desidera aggiornare le ubicazioni specifiche del cespite in base a quelle del dettaglio del contratto passivo." +
                             "Confermi?";
                DialogResult res = show(msg, "Conferma",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    foreach (DataRow Curr in DS.assetlocation.Select())
                    {
                        Curr["idlocation"] = idlocation;
                    }
                }
            }
            Meta.FreshForm();
        }






        private void AbilitaCredDeb(bool enable) {
            txtCredDeb.ReadOnly = !enable;
        }
        /// <summary>
        /// Metodo che calcola l'IVA detraibile
        /// </summary>
        /// <param name="rDettOrdine">Riga del dettaglio ordine</param>
        /// <param name="quantitaAssegnata">Quantità assegnata al carico cespite</param>
        /// <returns>IVA detraibile</returns>
        decimal calcolaIvaDetraibile(DataRow rDettOrdine, DataRow rDettFattura) {
            if (DS.Tables["config"].Rows.Count == 0) return 0;
            DataRow tCurrSetup = DS.Tables["config"].Rows[0];
            if (tCurrSetup["linktoinvoice"].ToString().ToUpper() == "S")
                return calcolaIvaDetraibileDaFattura(rDettOrdine,rDettFattura);
            else
                return calcolaIvaDetraibileDaOrdine(rDettOrdine);
        }
        decimal calcolaIvaDetraibileDaOrdine(DataRow rDettOrdine) {
            decimal quantitaDettOrdine = CfgFn.GetNoNullDecimal(rDettOrdine["number"]);
            
            int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));

            string flagmixedDettOrdine = "N";
            if (CfgFn.GetNoNullInt32(rDettOrdine["flagactivity"]) == 3) flagmixedDettOrdine = "S";
            string filtro = QHS.AppAnd(QHS.CmpEq("flagmixed", flagmixedDettOrdine),
                                        QHC.CmpEq("ayear", esercizio));
       

            object OabatableRate = Meta.Conn.DO_READ_VALUE("invoicekindyearview", filtro, "TOP 1 abatablerate");
            double abatableRate = 1;
            if ((OabatableRate != null) && (OabatableRate != DBNull.Value)) {
                abatableRate = CfgFn.GetNoNullDouble(OabatableRate);
            }

            decimal tassoCambio = CfgFn.GetNoNullDecimal(rDettOrdine["exchangerate"]);
            decimal ivaDetraibile = CfgFn.RoundValuta(CfgFn.RoundValuta((CfgFn.GetNoNullDecimal(rDettOrdine["tax"])
                - CfgFn.GetNoNullDecimal(rDettOrdine["unabatable"])) * tassoCambio) * (decimal)abatableRate);

            //perequa l'iva detraibile sull quantità esegnata dall'iva detraibile totale
            //ivaDetraibile= CfgFn.RoundValuta(ivaDetraibile/quantitaDettOrdine)*quantitaAssegnata;
            return CfgFn.RoundValuta(ivaDetraibile);

        }

        decimal calcolaIvaDetraibileDaFattura(DataRow rDettOrdine,DataRow rDettIva) {

            decimal quantitaDettOrdine = CfgFn.GetNoNullDecimal(rDettOrdine["number"]);
            // Se la quantità assegnata al carico è differente dalla quantità del dettaglio ordine
            // assegna come IVA detraibile ZERO
            //if (quantitaAssegnata != quantitaDettOrdine) return 0;

            // Se il dettaglio dell'ordine non è collegato a dettagli fattura 
            // assegna come IVA detraibile ZERO
            string filtro = QHS.AppAnd(QHS.MCmp(rDettOrdine, "idmankind", "yman", "nman"),
                QHS.CmpEq("manidgroup", rDettOrdine["idgroup"]));
            string elencoCampiDettFattura = "idinvkind, yinv, ninv, number, tax, unabatable, adate, exchangerate";

            if (rDettIva == null) return calcolaIvaDetraibileDaOrdine(rDettOrdine);//  10673
            //decimal quantitaDettFattura = CfgFn.GetNoNullDecimal(rDettIva["number"]);
            // Se le quantità sono differenti prende i campi dall'ORDINE
            decimal unabatable = 0;
            decimal tax = 0;
            //if (quantitaDettOrdine != quantitaDettFattura) {
            //    unabatable = CfgFn.GetNoNullDecimal(rDettOrdine["unabatable"]);
            //    tax = CfgFn.GetNoNullDecimal(rDettOrdine["tax"]);
            //}
            //else {
            //    unabatable = CfgFn.GetNoNullDecimal(rDettIva["unabatable"]);
            //    tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDettIva["tax"]));
            //}
            unabatable = CfgFn.GetNoNullDecimal(rDettIva["unabatable"]);
            tax = CfgFn.RoundValuta(CfgFn.GetNoNullDecimal(rDettIva["tax"]));
            //Vanno entrambe proporzionate alla q.tà del carico, ossia alla q.tà della fattura disponibile per il carico

            string filter = (QHS.MCmp(rDettIva, "idinvkind", "yinv", "ninv", "invidgroup"));
            object residuo = Meta.Conn.DO_READ_VALUE("invoicedetailavailable", filter, "residual");

            unabatable = (unabatable / CfgFn.GetNoNullDecimal(rDettIva["number"])) * CfgFn.GetNoNullDecimal(residuo);
            tax = (tax / CfgFn.GetNoNullDecimal(rDettIva["number"])) * CfgFn.GetNoNullDecimal(residuo);
            string filtroTipoFattura = QHS.AppAnd(QHS.MCmp(rDettIva, "idinvkind"), QHS.CmpEq("ayear", rDettIva["yinv"]));
            object OabatableRate = Meta.Conn.DO_READ_VALUE("invoicekindyearview", filtroTipoFattura, "abatablerate");
            double abatableRate = 1;
            if ((OabatableRate != null) && (OabatableRate != DBNull.Value)) {
                abatableRate = CfgFn.GetNoNullDouble(OabatableRate);
            }

            decimal ivaDetraibile = CfgFn.RoundValuta(CfgFn.RoundValuta((tax - unabatable)) * (decimal)abatableRate);
            //ivaDetraibile= CfgFn.RoundValuta(ivaDetraibile/quantitaDettOrdine)*quantitaAssegnata;
            return ivaDetraibile;
        }


        bool CheckShowHint(decimal totiva, decimal totivadetraibile, int number) {
            //Verifica iva unitaria
            if (!verificaDivisibilita(totiva, number)) return true;
            if (!verificaDivisibilita(totivadetraibile, number)) return true;
            return false;

        }
        bool verificaDivisibilita(decimal X, int N) {
            if (N == 0) return false;
            decimal Xone = CfgFn.RoundValuta(X / N);
            decimal Xrebuilded = Xone * N;
            if (Xrebuilded == X) return true;
            return false;
        }
        void ShowHint(decimal totiva, decimal totivadetraibile, int number) {
            FormHint F = new FormHint(totiva, totivadetraibile, number);
            F.Show();

        }
         private bool AggiornaRigheBeneInv(int quantita, int oldquantita) {
            //può capitare ad esempio quando si seleziona una riga ordine che ha
            //una quantità ordinata < caricata
            if (oldquantita < 0 || quantita < 0) return false;

            //			if (quantita==oldquantita) return false;
            Meta.GetFormData(true);

            if (oldquantita <= quantita) {	//aggiungo righe

                var m = MetaData.GetMetaData(this, "asset");

                var righeCurrent = DS.asset.Select(null, "!ninventory ASC", DataViewRowState.CurrentRows);
                var righeDeleted = DS.asset.Select(null, "!ninventory ASC", DataViewRowState.Deleted);

                var nrCurrent = righeCurrent.Length;
                var nrDeleted = righeDeleted.Length;

                var numAutomatica = chkAuto.Enabled && chkAuto.Checked;

                //calcolo num. iniziale
                var numiniziale = 0;
                numiniziale = !numAutomatica ? CfgFn.GetNoNullInt32(txtNumIniz.Text) : GetMAXNumInventario();

                for (var i = 0; i < quantita; i++) {
                    //riga esistente da aggiornare
                    if (i < nrCurrent) {
                        var r = righeCurrent[i];
                        r["nassetacquire"] = DS.assetacquire.Rows[0]["nassetacquire"];
                        r["ninventory"] = numiniziale + i;
                        if (numAutomatica || numiniziale == 0)
                            r["!ninventory"] = DBNull.Value;//""
                        else
                            r["!ninventory"] = r["ninventory"];
                        r["!numeroriga"] = i + 1;
                        continue;
                    }
                    //riga cancellata da riproporre aggiornata
                    if (i >= nrCurrent && i < nrCurrent + nrDeleted) {
                        var r = righeDeleted[i - nrCurrent];
                        r.RejectChanges();
                        r["nassetacquire"] = DS.assetacquire.Rows[0]["nassetacquire"];
                        r["ninventory"] = numiniziale + i;
                        if (numAutomatica || numiniziale == 0)
                            r["!ninventory"] = DBNull.Value; // "";
                        else
                            r["!ninventory"] = r["ninventory"];
                        r["!numeroriga"] = i + 1;
                        ImpostaDefaultBeneInv(r);
                        continue;
                    }
                    //riga nuova
                    m.SetDefaults(DS.asset);
                    MetaData.SetDefault(DS.asset, "lifestart", DS.assetacquire.Rows[0]["adate"]);

                    DataRow row = m.Get_New_Row(DS.assetacquire.Rows[0], DS.asset);
                    row["idinventory"] = DS.assetacquire.Rows[0]["idinventory"];
                    row["ninventory"] = numiniziale + i;
                    if (numAutomatica || numiniziale == 0)
                        row["!ninventory"] = DBNull.Value; // "";
                    else
                        row["!ninventory"] = row["ninventory"];
                    row["!numeroriga"] = i + 1;
                }
            }
            else {
                //Se sono in modalità inserimento non faccio visualizzare nessun msg
                if (!Meta.InsertMode) {
                    string msg = "La diminuizione della quantità di beni caricati " +
                        "produrrà la cancellazione di cespiti dall'inventario. Continuare?";
                    DialogResult res = show(msg, "Conferma",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res != DialogResult.Yes) {
                        //rimetto a quantità il vecchio valore
                        DS.assetacquire.Rows[0]["number"] = oldquantita;
                        Meta.FreshForm();
                        txtQuantita.Focus();
                        return false;
                    }
                }
                int todel = oldquantita - quantita;

                DataRow[] lista = DS.asset.Select("!ninventory is null");
                foreach (DataRow D in lista) {
                    if (todel == 0) break;
                    foreach (DataRow ManR in DS.assetmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManR.Delete();
                    }
                    foreach (DataRow ManL in DS.assetlocation.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManL.Delete();
                    }
                    foreach (DataRow SubMan in DS.assetsubmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        SubMan.Delete();
                    }
                    D.Delete();
                    todel--;
                }


                //elimino righe in differenza tra oldquantita e quantita
                lista = DS.asset.Select("!ninventory is not null", "!ninventory desc");
                foreach (DataRow D in lista) {
                    if (todel == 0) break;
                    foreach (DataRow ManR in DS.assetmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManR.Delete();
                    }
                    foreach (DataRow ManL in DS.assetlocation.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        ManL.Delete();
                    }
                    foreach (DataRow SubMan in DS.assetsubmanager.Select(QHC.CmpEq("idasset", D["idasset"]))) {
                        SubMan.Delete();
                    }
                    D.Delete();
                    todel--;
                }
                //				for(int i = oldquantita; i > quantita; i--) {
                //					DataRow[] r = DS.asset.Select("!numeroriga="+i);
                //					if (r.Length > 0) r[0].Delete();
                //				}
            }
            return true;
        }
        private int GetMAXNumInventario() {
            if (DS.assetacquire.Rows.Count == 0) return 1;
            object codiceinventario = DS.assetacquire.Rows[0]["idinventory"];
            if ((codiceinventario == DBNull.Value) || (CfgFn.GetNoNullInt32(codiceinventario) == 0)) return 1;
            //string sql_numiniziale="SELECT ISNULL(startnumber,0) FROM inventory "+
            //	"WHERE idinventory = "+QueryCreator.quotedstrvalue(codiceinventario,true);
            string sql_numiniziale = "SELECT ISNULL(startnumber,0) FROM inventory WHERE " +
                QHS.CmpEq("idinventory", codiceinventario);
            DataTable t = Meta.Conn.SQLRunner(sql_numiniziale);
            int numiniziale = 0;
            if (t != null) numiniziale = CfgFn.GetNoNullInt32(t.Rows[0][0]);
            //string sqlmax = "SELECT ISNULL(MAX(ninventory),"+numiniziale.ToString()+") + 1 "+
            //	"FROM assetview "+
            //	"WHERE idinventory = "+QueryCreator.quotedstrvalue(codiceinventario,true)+
            //	" AND ninventory >= "+numiniziale.ToString();

            string sqlmax = "SELECT ISNULL(MAX(ninventory)," + numiniziale.ToString() + ") + 1 FROM assetview WHERE "
            + QHS.AppAnd(QHS.CmpEq("idinventory", codiceinventario), QHS.CmpGt("ninventory", numiniziale));

            t = Meta.Conn.SQLRunner(sqlmax);
            return CfgFn.GetNoNullInt32(t.Rows[0][0]);
        }
        private void ImpostaDefaultBeneInv(DataRow r) {
            foreach (DataColumn C in DS.asset.Columns) {
                if (C.ColumnName == "idasset" ||
                    C.ColumnName == "nassetacquire" ||
                    C.ColumnName == "ninventory" ||
                    C.ColumnName == "!numeroriga" ||
                    C.ColumnName == "!ninventory" ||
                    C.ColumnName == "cu" ||
                    C.ColumnName == "ct" ||
                    C.ColumnName == "lu" ||
                    C.ColumnName == "lt") continue;
                r[C.ColumnName] = C.DefaultValue;
            }
        }

       

        bool InChiusura = false;
        private void txtNumriga_Leave(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (txtNumriga.ReadOnly) return;
            if (Meta.IsEmpty) return;
            if (txtNumriga.Text == "") return;
            btnCollegaRiga_Click(sender, e);
        }

        private void radioPosseduto_CheckedChanged(object sender, System.EventArgs e) {
            chkIncludi.Checked = !radioPosseduto.Checked;
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (!radioPosseduto.Checked) return;
            AbilitaRigaOrdine(false);
            PulisciRigaOrdine();
            PulisciRigaFattura();
            if (Meta.InsertMode) {
                AbilitaAutoNumerazione(false);
                 ImpostaAutoIncrementoNumInventario(false);
            }
        }


        private void radioNuovo_CheckedChanged(object sender, System.EventArgs e) {
            chkIncludi.Checked = radioNuovo.Checked;
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;
            if (!radioNuovo.Checked) return;
            AbilitaRigaOrdine(true);
            //PulisciBenePosseduto();
            if (Meta.InsertMode) {
                AbilitaAutoNumerazione(true);
                 ImpostaAutoIncrementoNumInventario(chkAuto.Checked);
            }
        }
        public void ImpostaAutoIncrementoNumInventario(bool enable) {
            DataColumn C = DS.asset.Columns["ninventory"];
            if (enable) {
                RowChange.MarkAsAutoincrement(C, null, null, 7);
                RowChange.MarkAsCustomAutoincrement(C, new RowChange.CustomCalcAutoID(CalcID));
            }
            else {
                RowChange.ClearAutoIncrement(C);
                RowChange.ClearCustomAutoIncrement(C);
            }
        }
        private void AbilitaRigaOrdine(bool enable) {
            grpRiga.Enabled = enable;
        }

        private void PulisciRigaOrdine() {
            Meta.GetFormData(true);
            DataRow row = DS.assetacquire.Rows[0];
            row["idmankind"] = DBNull.Value;
            row["yman"] = DBNull.Value;
            row["nman"] = DBNull.Value;
            row["rownum"] = DBNull.Value;
            txtCredDeb.ReadOnly = false;
            Meta.FreshForm();
        }


        private void PulisciRigaFattura() {
            Meta.GetFormData(true);
            DataRow row = DS.assetacquire.Rows[0];
            row["idinvkind"] = DBNull.Value;
            row["yinv"] = DBNull.Value;
            row["ninv"] = DBNull.Value;
            row["invrownum"] = DBNull.Value;
            txtCredDeb.ReadOnly = false;
            Meta.FreshForm();
        }


        private void AbilitaAutoNumerazione(bool enable) {
            //se il check va disabilitato imposto il valore a true per la config. iniziale
            if (!enable && chkAuto.Checked) chkAuto.Checked = false;

            chkAuto.Enabled = enable;

            //se il check non è abilitato non abilito num. iniziale
            //if (enable && !chkAuto.Checked) return;

            AbilitaNumIniziale(!chkAuto.Checked);
        }
        private void AbilitaNumIniziale(bool enable) {
            //btnNumInventario.Enabled=enable && chkIspieceAcquire.Checked;
            txtNumIniz.ReadOnly = !enable;
            if (enable)
                txtNumIniz.PasswordChar = Convert.ToChar(0);
            else
                txtNumIniz.PasswordChar = ' ';
        }
        private object CalcID(DataRow R, DataColumn C, DataAccess Conn) {
            return GetMAXNumInventario();
        }
  

       

        private void AbilitaTipoCarico(bool enable) {
            radioNuovo.Enabled = enable;
            radioPosseduto.Enabled = enable;
        }

        public void MetaData_AfterFill() {
            EnableDisableButt();
            //ImpostaAutoIncrementoNumInventario(chkAuto.Checked);
            
            btnNumInventario.Enabled = false;


            Meta.MarkTableAsNotEntityChild(DS.asset);
            Meta.MarkTableAsNotEntityChild(DS.assetlocation);
            Meta.MarkTableAsNotEntityChild(DS.assetmanager);
            Meta.MarkTableAsNotEntityChild(DS.assetsubmanager);

            grpInventario.Enabled = true;
            
       

            chkAuto.Visible = true;


             AbilitaRigaOrdine(radioNuovo.Checked);
             AbilitaTipoCarico(true);
 
            //AbilitaTipoCarico(Meta.InsertMode);
            //in fase di inserimento il check autonumerazione è abilitato se il radiobutton
            //nuova acquisizione è true e se il check stesso è true oppure se non è a true
            //ma è abilitato il textbox num. iniziale
            bool valore = Meta.InsertMode && radioNuovo.Checked;
            AbilitaAutoNumerazione(valore);
            ImpostaAutoIncrementoNumInventario(Meta.InsertMode && chkAuto.Checked && chkAuto.Enabled);

            
            CalcolaTotali(false, false);  //Nino:: cambiato, prima era TRUE!!!
            if (Meta.InsertMode && Meta.FirstFillForThisRow) {
                chkAuto.Checked = true;
                DoAutoCheck();
            }
            DisabilitaFattura(false);

        }
        void DoAutoCheck() {
            AbilitaNumIniziale(!chkAuto.Checked);
            int numiniz = CfgFn.GetNoNullInt32(txtNumIniz.Text);
            VisualizzaONascondiNumInventario((numiniz != 0) && (!chkAuto.Checked));
            //CancellaNumInventario(chkAuto.Checked);
            ImpostaAutoIncrementoNumInventario(chkAuto.Checked);
            HelpForm.SetDenyNull(DS.assetacquire.Columns["startnumber"], !chkAuto.Checked);
            if (Meta.IsEmpty) return;
            int quantita = CfgFn.GetNoNullInt32(txtQuantita.Text);
            if (quantita == 0) return;
            int oldquantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);
            AggiornaRigheBeneInv(quantita, oldquantita);
        }
        void VisualizzaONascondiNumInventario(bool visualizza) {
            Meta.GetFormData(true);
            if (visualizza) {
                //svuoto il campo numinventario delle righe di asset (tab. figlio)
                foreach (DataRow r in DS.asset.Rows) {
                    if (r.RowState == DataRowState.Deleted) continue;
                    r["!ninventory"] = r["ninventory"]; //.ToString();
                }
            }
            else {
                foreach (DataRow r in DS.asset.Rows) {
                    if (r.RowState == DataRowState.Deleted) continue;
                    r["!ninventory"] = DBNull.Value;// "";
                }
            }
            //Meta.FreshForm();

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T.TableName == "locationview" && R != null) {
                if (R["idman"] != DBNull.Value) {
                    object newidman = R["idman"];
                    object selMan = Meta.GetAutoField(txtResponsabile);
                    if (selMan != DBNull.Value && selMan.ToString() != newidman.ToString()) {
                        show("Il responsabile è stato reimpostato in base all'ubicazione selezionata.");                        
                    }
                    Meta.SetAutoField(newidman, txtResponsabile);                    
                }
            }
            
            if (T.TableName == "inventorytreeview" && R != null) {
                    ClearMultifieldTab();
                    if (R["idinv"] != DBNull.Value) {
                        // Riempie la tabella inventorytreemultifieldkindkind
                        DS.inventorytreemultifieldkind.Clear();
                        Conn.RUN_SELECT_INTO_TABLE(DS.inventorytreemultifieldkind, null, QHS.CmpEq("idinv", R["idinv"]),null,false);
                        //Ridisegna il tab mettendo le etichette aggiuntive da valorizzare
                        FillMultifieldTab("", DS.multifieldkind,
                        DS.inventorytreemultifieldkind.Select(QHC.CmpEq("idinv", R["idinv"]), "idmultifieldkind"));
                    }
            }
        }

        private void chkAuto_CheckedChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            DoAutoCheck();
        }
       
        private void ControlloQuantita() {
            if (Meta.IsEmpty) return;
            if (!Meta.DrawStateIsDone) return;

            //leggo il valore quantita
            var quantita = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), txtQuantita.Text, null));
            if (quantita <= 0) {
                show("Inserire una quantità maggiore o uguale a zero", "Attenzione",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtQuantita.Focus();
                return;
            }

            var oldquantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);

            MetaData.GetFormData(this, true);
           
            if (AggiornaRigheBeneInv(quantita, oldquantita))CalcolaTotali(false, true);
           
        }


        bool InsideControlloQuantita = false;

        private void txtQuantita_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (InsideControlloQuantita) return;
            InsideControlloQuantita = true;
            try {
                ControlloQuantita();
            }
            catch { }
            InsideControlloQuantita = false;
        }



        private void txtQuantita_TextChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            if (txtQuantita.Text.Trim() == "") txtQuantita.Text = "0";
            //CalcolaTotali(true,true); maria 22 12 2005
        }
        private void txtImpostaTotale_TextChanged(object sender, EventArgs e) {
            if (Meta == null) return;
            if (!Meta.DrawStateIsDone) return;
            decimal imponibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImpTotale.Text, "x.y.c"));
            decimal iva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtImpostaTotale.Text, "x.y.c"));
            decimal tot = imponibile + iva;
            txtImpConIVA.Text = tot.ToString("c");
        }
        private void btnSuggerimento_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            decimal totiva = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtImpostaTotale.Text, txtImpostaTotale.Tag.ToString()));
            decimal totdetraibile = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(
                typeof(decimal), txtAbatable.Text, txtAbatable.Tag.ToString()));
            int quantita = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(
                typeof(int), txtQuantita.Text, txtQuantita.Tag.ToString()));
            if (quantita == 0) return;
            ShowHint(totiva, totdetraibile, quantita);
        }

        public void MetaData_BeforePost() {
            //Azzera le tabelle oggetto del salvataggio tranne la principale
            DS.assetlocation.Clear();
            DS.assetmanager.Clear();
            DS.assetsubmanager.Clear();
            DataRow curr = DS.assetacquire.Rows[0];

            object idman = curr["!idman"];
            object idloc = curr["!idlocation"];
            object idmanager = curr["!idmanager"];
            MetaData MAssetLoc = MetaData.GetMetaData(this, "assetlocation");
            MAssetLoc.SetDefaults(DS.assetlocation);

            MetaData MAssetManager = MetaData.GetMetaData(this, "assetmanager");
            MAssetManager.SetDefaults(DS.assetmanager);

            MetaData MAssetSubManager = MetaData.GetMetaData(this, "assetsubmanager");
            MAssetSubManager.SetDefaults(DS.assetsubmanager);
            //Imposta per ogni cespite l'ubicazione e il manager ove selezionati
            //Imposta per ogni cespite il valore multifield specificato 
            string S = GetMultifieldTab();
           
            foreach (DataRow RA in DS.asset.Rows) {
                RA["idinventory"] = curr["idinventory"];
                if (idloc != DBNull.Value) {
                    DataRow newLoc = MAssetLoc.Get_New_Row(RA, DS.assetlocation);
                    newLoc["idlocation"] = idloc;
                    RA["idcurrlocation"] = idloc;
                }
                if (idman != DBNull.Value) {
                    DataRow newMan = MAssetManager.Get_New_Row(RA, DS.assetmanager);
                    newMan["idman"] = idman;
                    RA["idcurrman"] = idman;
                }
                if (idmanager != DBNull.Value) {
                    DataRow newSubman = MAssetSubManager.Get_New_Row(RA, DS.assetsubmanager);
                    newSubman["idmanager"] = idmanager;
                    RA["idcurrsubman"] = idmanager;
                }
                if (S == "")
                    RA["multifield"] = DBNull.Value;
                else
                    RA["multifield"] = S;

            }
            
           
        }

        private void btnSalva_Click(object sender, EventArgs e) {
            if (!Meta.InsertMode) return;
            Meta.GetFormData(true);

            Meta.SaveFormData();
            if (!DS.HasChanges()) return; //non ha fatto nulla
            EnableDisableButt();

        }

        void OldAfterPost() {
            if (!Meta.InsertMode) return;
            //se non ci sono righe (ad es. clicco annulla in fase di inserimento)
            if (DS.assetacquire.Rows.Count < 1) return;
            //aggiorno il num. iniziale di assetacquire, solo per un cespite NON posseduto
            // questo non deve accadere per gli accessori.
            if (chkAuto.Checked && chkAuto.Enabled) {
                int quantita = CfgFn.GetNoNullInt32(DS.assetacquire.Rows[0]["number"]);
                if (quantita > 0) {
                    DataRow[] rows = DS.asset.Select(null, "ninventory ASC");
                    DS.assetacquire.Rows[0]["startnumber"] = CfgFn.GetNoNullInt32(rows[0]["ninventory"]);
                }
                else {
                    DS.assetacquire.Rows[0]["startnumber"] = GetMAXNumInventario();
                }
                PostData pd = Meta.Get_PostData();
                pd.InitClass(DS, Meta.Conn);
                if (pd.DO_POST()) {
                    DS.AcceptChanges();
                    Meta.FreshForm();
                }
            }

        }
        public void MetaData_AfterPost() {
            OldAfterPost();
            object min = DS.asset.Compute("min(ninventory)", null);
            object max = DS.asset.Compute("max(ninventory)", null);

            if (min == null || min == DBNull.Value) {
                show("Errori nel salvataggio");
                return;
            }
            DataRow curr = DS.assetacquire.Rows[0];
            int imin = CfgFn.GetNoNullInt32(min);
            int imax = CfgFn.GetNoNullInt32(max);
            string msg="Carico n."+curr["nassetacquire"].ToString() +" ";
            if (imin == imax) {
                msg += "Numero di inventario assegnato: " + imin.ToString();
            }
            else {
                msg += "Numeri di inventario assegnati: " + imin.ToString() + "-" + imax.ToString();
            }
            txtComments.Text=msg;
            txtNumIniz.Text = imin.ToString();
        }

        private void btnNuoviDati_Click(object sender, EventArgs e) {
            //Azzera le tabelle oggetto del salvataggio tranne la principale
            DS.asset.Clear();
            DS.assetlocation.Clear();
            DS.assetmanager.Clear();
        
            //Svuota tutti i default
            foreach(DataColumn C in DS.assetacquire.Columns){
                if (C.AllowDBNull){
                    MetaData.SetDefault(DS.assetacquire, C.ColumnName,DBNull.Value);
                    continue;
                }
				string typename= C.DataType.Name;
				switch(typename){
					case "String": MetaData.SetDefault(DS.assetacquire,C.ColumnName,"");
						break;
					case "Char": MetaData.SetDefault(DS.assetacquire,C.ColumnName,"");
						break;
					case "Double":MetaData.SetDefault(DS.assetacquire,C.ColumnName,0);
						break;
					case "Decimal":MetaData.SetDefault(DS.assetacquire,C.ColumnName,0);
						break;
					case "DateTime":MetaData.SetDefault(DS.assetacquire,C.ColumnName, QueryCreator.EmptyDate());
						break;
					case "Int16": MetaData.SetDefault(DS.assetacquire,C.ColumnName,0);
						break;
					case "Int32": MetaData.SetDefault(DS.assetacquire,C.ColumnName,0);
						break;
					case "Byte": MetaData.SetDefault(DS.assetacquire,C.ColumnName,0);
						break;
					default: MetaData.SetDefault(DS.assetacquire,C.ColumnName,"");
						break;
				}          

            }
            DataSet Copy = DS.Copy();
            Meta.DoMainCommand("maininsert");

            DataRow Old = Copy.Tables["assetacquire"].Rows[0];
            DataRow Curr = DS.assetacquire.Rows[0];

            //Per ogni campo rimette come default i valori inseriti ove indicato dal check
            if (chkContrattoPassivo.Checked) {
                foreach (string col in new string[] { "flag", "idmankind", "yman", "nman" })
                    Curr[col] = Old[col];
            }

            if (chkUPB.Checked) {
                Curr["idupb"] = Old["idupb"];
            }
            if (chkUbicResp.Checked) {
                foreach (string col in new string[] { "!idlocation", "!idman" })
                    Curr[col] = Old[col];
            }
            if (chkConsegnatario.Checked) {
                foreach (string col in new string[] { "!idmanager"})
                    Curr[col] = Old[col];

            }
            if (chkCedente.Checked) {
                foreach (string col in new string[] { "idreg"})
                    Curr[col] = Old[col];
            }
            if (chkClassInventariale.Checked) {
                foreach (string col in new string[] { "idinv" })
                    Curr[col] = Old[col];
                if (!chkMultifield.Checked) {
                    ClearMultifieldTab();
                    DS.inventorytreemultifieldkind.Clear();
                    //Riempie la tabella inventorytreemultifieldkind sulla base della classificazione da preservare
                    Conn.RUN_SELECT_INTO_TABLE(DS.inventorytreemultifieldkind, null, QHS.CmpEq("idinv", Curr["idinv"]), null, false);
                    //Ridisegna il tab mettendo le etichette aggiuntive da valorizzare 
                    //senza preservare il valore precedente(ossia come stringhe vuote)
                    FillMultifieldTab("", DS.multifieldkind,
                    DS.inventorytreemultifieldkind.Select(QHC.CmpEq("idinv", Curr["idinv"]), "idmultifieldkind"));
                }
            }
            else {
                 DS.inventorytreemultifieldkind.Clear();
                 ClearMultifieldTab();
            }
            
            
            Curr["idmot"] = Old["idmot"];
            if (chkDescrizione.Checked) {
                Curr["description"] = Old["description"];
            }
            if (chkDati.Checked) {
                foreach (string col in new string[] { "taxable","discount", "number", "taxrate", "tax","abatable" })
                    Curr[col] = Old[col]; 
            }
           

            Curr["adate"] = Old["adate"];
            Curr["idinventory"] = Old["idinventory"];
            Meta.FreshForm(true);
            txtQuantita.Text = Old["number"].ToString();
            txtQuantita_TextChanged(txtQuantita, null);
            txtQuantita_LostFocus(txtQuantita,null);
            DoAutoCheck();

        }

        private void btnMostraCarico_Click(object sender, EventArgs e) {
            if (!Meta.EditMode) return;
            MetaData newAssetAcquire = MetaData.GetMetaData(this, "assetacquire");
            DataRow Curr = DS.assetacquire.Rows[0];
            newAssetAcquire.Edit(this.ParentForm, "default", false);

            object numass = Curr["nassetacquire"];

            DataRow R = newAssetAcquire.SelectOne(newAssetAcquire.DefaultListType,
                QHS.CmpEq("nassetacquire",numass), "assetacquire", null);

            if (R != null) newAssetAcquire.SelectRow(R, newAssetAcquire.DefaultListType);

        }

        private void btnTermina_Click(object sender, EventArgs e) {
            if (!Meta.WarnUnsaved()) return;
            if (!Meta.IsEmpty) {
                DS.AcceptChanges();                
            }
            Close();
        }
        private void txtNumIniz_LostFocus(object sender, System.EventArgs e) {
            if (InChiusura) return;
            if (!Meta.DrawStateIsDone) return;
            if (MetaData.Empty(this)) return;

            int numiniziale = 0;
            numiniziale = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(numiniziale.GetType(), txtNumIniz.Text, null));
            string sNumIniziale = txtNumIniz.Text.Trim();
            bool NumInizIsLetter = false;
            for (int i = 0; i < sNumIniziale.Length; i++) {
                if (!(Char.IsNumber(sNumIniziale, i))) {
                    NumInizIsLetter = true;
                    break;
                }
            }

            if (numiniziale < 0 || sNumIniziale == "" || NumInizIsLetter) {
                //				show("Inserire un numero iniziale maggiore o uguale a zero.","Attenzione",
                //					MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                numiniziale = 0;
            }

            
           
                int oldnuminiziale = CfgFn.GetNoNullInt32(DS.Tables["assetacquire"].Rows[0]["startnumber"]);
                if ((numiniziale == 0) && (oldnuminiziale > 0)) {
                    show("Il n. iniziale non può essere 0.");
                    txtNumIniz.Text = oldnuminiziale.ToString();
                    txtNumIniz.Focus();
                    return;
                }

                if (oldnuminiziale == numiniziale) return;

                MetaData.GetFormData(this, true);

                if (DS.asset.Rows.Count < 1) return;
                string msg = "Questa operazione assegna un numero di inventario " +
                    "progressivo a tutti i cespiti del carico. Confermi?";
                DialogResult res = DialogResult.Yes;
                if ( (oldnuminiziale > 0)) res = show(msg, "Conferma",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes) {
                    //aggiorno num. inventario
                    int N = numiniziale;
                    foreach (DataRow row in DS.asset.Rows) {
                        if (row.RowState == DataRowState.Deleted) continue;
                        if (numiniziale == 0) {
                            row["!ninventory"] = DBNull.Value; //ex ""
                        }
                        else {
                            row["!ninventory"] = N;
                        }

                        row["ninventory"] = N++;
                    }
                }
                else {
                    //rimetto il valore precedente al num. iniziale e non faccio nulla
                    DS.assetacquire.Rows[0]["startnumber"] = oldnuminiziale;
                    Meta.FreshForm();
                }
            
            
        }

        #region gestione multifieldkind
        int TextHeight = 30;
        int TextWidth = 300;

        class mfield {
            public string fieldname;
            public string systype;
            public bool allownull;
            public string tag;
            public string fieldcode;
            public TextBox T;
        }

        void AddMultiFieldToForm(TabPage TP, mfield MF, int x, int y, int intab_count) {

            GroupBox G = new GroupBox();
            G.Size = new Size(320, 50);
            G.Location = new Point(10 + x, 15 + y);

            if (intab_count < 10) {
                G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left))));
            }
            else {
                G.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                                | AnchorStyles.Right)));
            }
            G.Text = MF.fieldname;
            if (!MF.allownull) {
                G.Text = G.Text + " (*)";
            }
            TP.Controls.Add(G);

            TextBox T = new TextBox();
            G.Controls.Add(T);
            T.Width = TextWidth; T.Height = TextHeight;
            //T.Multiline = true;
            //T.ScrollBars = ScrollBars.Vertical;
            T.Location = new Point(5, 18);
            T.Anchor = ((AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left)
                                | AnchorStyles.Right)));

            MF.T = T;
        }


        mfield[] allfields = new mfield[1];
        /// <summary>
        /// Aggiunge i textbox al tab e li riempie con i valori trovati in value
        /// </summary>
        /// <param name="value">stinga codificata</param>
        /// <param name="MFKind">tabella multifieldkind</param>
        /// <param name="Fields">inventorytreemultifieldkind filtrata per idinv</param>
        void FillMultifieldTab(string value, DataTable MFKind, DataRow[] Fields) {
            TabControl FT = new TabControl();
            FT.Dock = DockStyle.Fill;

            Dictionary<string, List<DataRow>> HL = new Dictionary<string, List<DataRow>>();
            ArrayList TabNameList = new ArrayList();
            foreach (DataRow F in Fields) {
                DataRow[] Fks = MFKind.Select(QHC.CmpEq("idmultifieldkind", F["idmultifieldkind"]), "ordernumber");
                if (Fks.Length == 0) continue;
                string tabname = Fks[0]["tabname"].ToString();
                List<DataRow> AL;
                if (HL.ContainsKey(tabname)) {
                    AL = HL[tabname] as List<DataRow>;
                }
                else {
                    AL = new List<DataRow>();
                    HL[tabname] = AL;
                    TabNameList.Add(tabname);
                }
                AL.Add(F);
            }



            tabInfoAgg.Controls.Clear();
            tabInfoAgg.Controls.Add(FT);

            Hashtable H = new Hashtable();
            string[] allmf = value.Split(new char[] { '§' });
            foreach (string coppia in allmf) {
                if (coppia == "") continue;
                string[] cc = coppia.Split(new char[] { '|' });
                string code = cc[0].ToLower();
                string val = cc[1];
                H[code] = val;
            }
            //allfields= array di stringhe del tipo chiave§valore
            allfields = new mfield[Fields.Length];

            //if (value == "") allfields = new mfield[0];
            TabNameList.Sort();
            int maincount = 1;

            foreach (string tabname in TabNameList) {
                TabPage TP = new TabPage(tabname == "null" ? "" : tabname);
                TP.AutoScroll = true;

                int x = 0;
                int y = 0;

                int tabcount = 1;
                foreach (DataRow Field in HL[tabname]) {
                    DataRow[] Fks = MFKind.Select(QHC.CmpEq("idmultifieldkind", Field["idmultifieldkind"]));
                    if (Fks.Length == 0) continue;
                    DataRow R = Fks[0];

                    string fieldcode = R["fieldcode"].ToString();
                    object XX = H[fieldcode.ToLower()];
                    if (XX == null) XX = "";
                    mfield MF = new mfield();
                    MF.fieldname = R["fieldname"].ToString();
                    MF.allownull = (R["allownull"].ToString().ToUpper() == "S");
                    MF.systype = R["systype"].ToString();
                    MF.tag = R["tag"].ToString();
                    MF.fieldcode = fieldcode;
                    AddMultiFieldToForm(TP, MF, x, y, tabcount); //inizio


                    MF.T.Text = XX.ToString();
                    if (MF.systype.ToLower() == "string")
                        MF.T.TextAlign = HorizontalAlignment.Left;
                    else
                        MF.T.TextAlign = HorizontalAlignment.Right;

                    allfields[maincount - 1] = MF;

                    if (R["len"] != DBNull.Value) MF.T.MaxLength = CfgFn.GetNoNullInt32(R["len"]);
                    tabcount++;
                    maincount++;
                    y += 52;
                    if (tabcount == 10) {
                        x += 350;
                        y = 0;
                    }
                }
                //Legenda campi obbligatori
                if (Fields.Length > 0) {
                    Label L = new Label();
                    this.tabInfoAgg.Controls.Add(L);
                    L.Text = "I campi contrassegnati da (*) sono obbligatori";
                    L.AutoSize = true;
                    L.Location = new Point(10 + x, 15 + y);
                }

                FT.TabPages.Add(TP);
            }


        }
    
        string GetMultifieldTab () {
            string res = "";
            foreach (mfield mf in allfields) {
                if (mf == null) continue;
                string value = mf.T.Text.Trim().Replace("§", "").Replace("|", "");
                if (value == "") continue;
                string fieldcode = mf.fieldcode;
                string coppia = fieldcode + "|" + value;
                if (res != "") res += "§";
                res += coppia;
            }
            return res;
        }

        void ClearMultifieldTab () {            
            tabInfoAgg.Controls.Clear();
            allfields = new mfield[1];
        }



        #endregion
        //TASK 10974
        bool MandateLinked = false;


        private void btnCollegaRigaFattura_Click(object sender, EventArgs e) {
            DataAccess Conn = MetaData.GetConnection(this);
            MetaData MRiga;
            MRiga = MetaData.GetMetaData(this, "invoicedetailgroupview");

            MRiga.FilterLocked = true;
            MRiga.DS = DS;
            string filter = CalcolaFiltroRigaFattura();
            DataRow selRow = MRiga.SelectOne("dettaglio", filter, null, null);
            if (selRow == null) {
                return;
            }

            HelpForm.SetComboBoxValue(cmbTipoFattura, selRow["idinvkind"]);
            txtEsercFattura.Text = selRow["yinv"].ToString();
            txtNumFattura.Text = selRow["ninv"].ToString();
        }

         private string CalcolaFiltroRigaFattura() {
            string filter = "";
            if (cmbTipoFattura.SelectedValue != null && CfgFn.GetNoNullInt32(cmbTipoFattura.SelectedValue) != 0) {
                filter = QHS.AppAnd(filter, QHC.CmpEq("idinvkind", cmbTipoFattura.SelectedValue));
            }
            string esercFattura = txtEsercFattura.Text.Trim();
            if (esercFattura != "")
                filter = QHS.AppAnd(filter, QHS.CmpEq("yinv", CfgFn.GetNoNullInt32(esercFattura)));
            string numFattura = txtNumFattura.Text.Trim();
            if (numFattura != "") filter = QHS.AppAnd(filter, QHS.CmpEq("ninv", CfgFn.GetNoNullInt32(numFattura)));
            return filter;
        }



    }
}
