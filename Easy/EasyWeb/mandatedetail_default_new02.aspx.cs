
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using HelpWeb;
using AllDataSet;
using metadatalibrary;
using funzioni_configurazione;

public partial class mandatedetail_default_new02 : MetaPage {
    vistaForm_mandatedetail DS;
    public override DataSet GetDataSet() {
        return DS;
    }
    public override DataSet CreateNewDataSet() {
        return new vistaForm_mandatedetail();
    }
    public override void SetDataSet(DataSet D) {
        DS = (vistaForm_mandatedetail)D;
    }

    double tasso_cambio = 1;
    object codiceresponsabile = DBNull.Value;
    private string newcomputesorting = "N";

    /// <summary>
    /// Filtro calcolato in base al tipo documento collegabile o meno al tipo fattura (aliquote=0 o tutte)
    /// </summary>
    private string basefilteriva = "";

    private string basefilterupb = "";

    public override void AfterLink(bool firsttime, bool formToLink) {
        Meta.Name = "Dettaglio prenotazione d'ordine";

        GetData.SetSorting(DS.listview, "description");
        if (formToLink) {
            idivakind.DataSource = DS.ivakind;
            idivakind.DataValueField = "idivakind";
            idivakind.DataTextField = "description";


            cmbUnitaMisuraAcquisto.DataSource = DS.package;
            cmbUnitaMisuraAcquisto.DataValueField = "idpackage";
            cmbUnitaMisuraAcquisto.DataTextField = "description";

            cmbUnitaMisuraCS.DataSource = DS.unit;
            cmbUnitaMisuraCS.DataValueField = "idunit";
            cmbUnitaMisuraCS.DataTextField = "description";
        }
        tasso_cambio = 1;
        codiceresponsabile = DBNull.Value;
        Hashtable h = (Hashtable)Meta.ExtraParameter;
        if (h == null) {
            //grpValoreUnitInValutaText = "Valore totale in valuta (non impostata)";
            tasso_cambio = 1;
            codiceresponsabile = DBNull.Value;
        } else {
            //grpValoreUnitInValuta.Text = "Valore totale in valuta  (" + h["nomevaluta"].ToString() + ")";
            tasso_cambio = Convert.ToDouble(h["cambio"]);
            codiceresponsabile = h["codiceresponsabile"];
        }



        DataRow DR = Meta.SourceRow;
        DataTable MandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
        QHS.CmpEq("idmankind", DR["idmankind"]), null, null, true);
        string filter_total;

        if (DR["idupb"] != DBNull.Value)
            filter_total = QHS.AppOr(QHS.CmpEq("idupb", DR["idupb"]), QHS.NullOrEq("idman", codiceresponsabile));
        else
            filter_total = QHS.NullOrEq("idman", codiceresponsabile);
        if (codiceresponsabile != DBNull.Value)
            GetData.SetStaticFilter(DS.upb, filter_total);

        // Filtro sull'eserczio corrente
        //string filter_yearview = QHS.CmpEq("ayear", Conn.GetSys("esercizio"));
        //GetData.SetStaticFilter(DS.upbyearview, filter_yearview);

        if (firsttime) {

            //Filtriamo gli upb con lo stesso tipo attivit� del Tipo contratto passivo.
            //Le upb con tipoattivit� 'qualsiasi' verranno sempre mostrate
            //Filtriamo anche i tipi Aliquota Iva
            int flagactivity = 0;
            if (MandateKind.Rows.Count > 0) {
                flagactivity = CfgFn.GetNoNullInt32(MandateKind.Rows[0]["flagactivity"]);
            }
            string filterAactivityUpb = "";

            if (flagactivity == 1) { //istituzionale
                rdbCommerciale.Enabled = rdbPromiscua.Enabled = rdbQualsiasi.Enabled = false;
                filterAactivityUpb = QHS.CmpEq("flagactivity", 1);
            }

            if (flagactivity == 2) { //commerciale
                rdbPromiscua.Enabled = rdbIstituzionale.Enabled = rdbQualsiasi.Enabled = false;
                filterAactivityUpb = QHS.CmpEq("flagactivity", 2);
            }


            if (filterAactivityUpb != "") {
                filterAactivityUpb = QHS.AppOr(QHS.CmpEq("flagactivity", 4), filterAactivityUpb);
            }



            ImpostaTageFiltriUPB(CfgFn.GetNoNullInt32(DR["flagactivity"]), DR["idupb"]);


            int flag = 0;
            if (MandateKind.Rows.Count > 0) {
                flag = CfgFn.GetNoNullInt32(MandateKind.Rows[0]["flagactivity"]);
            }
            string filterivakind = "";
            if (flag == 1)
                filterivakind = QHS.BitSet("flag", 0);
            if (flag == 2)
                filterivakind = QHS.BitSet("flag", 1);
            if (flag == 3)
                filterivakind = QHS.BitSet("flag", 2);
            if (filterivakind != "" && DR["idivakind"] != DBNull.Value) {
                filterivakind = QHS.AppOr(QHS.CmpEq("idivakind", DR["idivakind"]), filterivakind);
            }
            string statfilterivakind = "";
            if (filterivakind != "")
                statfilterivakind = QHS.AppAnd(statfilterivakind, filterivakind);

            if (statfilterivakind != "")
                GetData.SetStaticFilter(DS.ivakind, statfilterivakind);
        }

        DataAccess.SetTableForReading(DS.sorting1, "sorting");
        DataAccess.SetTableForReading(DS.sorting2, "sorting");
        DataAccess.SetTableForReading(DS.sorting3, "sorting");

        DataTable tExpSetup = Conn.RUN_SELECT("config", "*", null, QHS.CmpEq("ayear", Conn.GetSys("esercizio")), null, null, true);
        if ((tExpSetup != null) && (tExpSetup.Rows.Count > 0)) {
            DataRow R = tExpSetup.Rows[0];
            object idsorkind1 = R["idsortingkind1"];
            object idsorkind2 = R["idsortingkind2"];
            object idsorkind3 = R["idsortingkind3"];
            SetGBoxClass(1, idsorkind1);
            SetGBoxClass(2, idsorkind2);
            SetGBoxClass(3, idsorkind3);
            if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                PanelAnalitico.Visible = false;// tabControl2.TabPages.Remove(tabAnalitico);
            }
        }

        Register_fn_TotImponibile();
    }


    void SetGBoxClass(int num, object sortingkind) {
        string nums = num.ToString();
        hwPanel gbox = new hwPanel();
        hwButton btncodice = new hwButton();
        //HtmlGenericControl gboxlabel = new HtmlGenericControl();

        switch (num) {
            case 1:
                gbox = gboxclass1;
                btncodice = btnCodice1;
                //gboxlabel = gboxlblgboxclass1;
                break;
            case 2:
                gbox = gboxclass2;
                btncodice = btnCodice2;
                //gboxlabel = gboxlblgboxclass2;
                break;
            case 3:
                gbox = gboxclass3;
                btncodice = btnCodice3;
                //gboxlabel = gboxlblgboxclass3;
                break;
        }


        if (sortingkind == DBNull.Value) {
            gbox.Enabled = false;
        } else {
            string filter = QHS.CmpEq("idsorkind", sortingkind);
            GetData.SetStaticFilter(DS.Tables["sorting" + nums], filter);

            string title = Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
            //gboxlabel.InnerText = title;
            gbox.GroupingText = title;
            gbox.Tag = "AutoManage.txtCodice" + nums + ".tree." + filter;
            btncodice.Tag = "manage.sorting" + nums + ".tree." + filter;
            DS.Tables["sorting" + nums].ExtendedProperties[ExtraParams] = filter;

        }
    }

    private void ImpostaTageFiltriUPB(int mandatedetailFlagactivity, object idupbToinclude) {
        string upbfilter = CalcolaFiltroUPB(mandatedetailFlagactivity);
        string filteradd = upbfilter;
        string filteractive = QHS.AppAnd(upbfilter, QHS.CmpEq("active", "S"));

        if (idupbToinclude != DBNull.Value && upbfilter != "") {
            filteradd = QHS.DoPar(QHS.AppOr(QHS.CmpEq("idupb", idupbToinclude), QHS.DoPar(upbfilter)));
        }

        GetData.SetStaticFilter(DS.upb, filteradd);

        if (upbfilter != "") {
            btnUpb.Tag = "choose.upbyearview.daticontabilimin." + filteractive;
        } else {
            btnUpb.Tag = "manage.upbyearview.tree";
        }
        if (PanelUpb.Tag != null)
            PanelUpb.Tag = "AutoChoose.txtCodiceUPB.default." + filteractive;
        CommFun.SetAutoMode(PanelUpb);
    }

    private string CalcolaFiltroUPB(int mandatedetail_flagactivity) {
        string filter_upb = "";
        if (mandatedetail_flagactivity == 1 || mandatedetail_flagactivity == 2) {
            //I valori di istituzionale e commerciale sono identici per le tabelle upb e mandatedetail
            filter_upb = QHS.AppAnd(filter_upb, QHS.CmpEq("flagactivity", mandatedetail_flagactivity));
            filter_upb = QHS.DoPar(QHS.AppOr(QHS.CmpEq("flagactivity", 4), filter_upb));
        }
        if (codiceresponsabile != DBNull.Value) {
            filter_upb = QHS.AppAnd(filter_upb, QHS.NullOrEq("idman", codiceresponsabile));
        }
        return filter_upb;
    }

    double tassocambio() {
        return tasso_cambio;
    }


    public void FiltraSelezioneListino() {
        ApplicationState APS = ApplicationState.GetApplicationState(this);
        MetaData M = APS.Dispatcher.Get("listino");
        M.edit_type = "parametri";
        APS.CallPage(this, M, false);

        //AppState.CallPage(this, M, false);
    }

    public void SelezionaListino(string idlistclass, string Description) {
        DataRow Curr = DS.mandatedetail.Rows[0];
        string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Conn.Security.GetSys("datacontabile"))));
        if (idlistclass != "") filter = QHS.AppAnd(filter, QHS.CmpEq("idlistclass", idlistclass));
        filter = QHS.AppAnd(filter, QHS.NullOrEq("active", "S"));
        filter = QHS.AppAnd(filter, QHS.BitSet("flagvisiblekind", 1)); //bit 1: visibile nei c. passivi. BitSet confronta con <> 0

        if (Description != "") {
            if (!Description.EndsWith("%")) Description += "%";
            if (!Description.StartsWith("%")) Description = "%" + Description;
            filter = QHS.AppAnd(filter, QHS.Like("description", Description));
        }

        string filterManKind = QHS.CmpEq("idmankind", Curr["idmankind"]);
        object AssetKind = Conn.DO_READ_VALUE("mandatekind", filterManKind, "assetkind");
        int IAssetKind = CfgFn.GetNoNullInt32(AssetKind);

        string filterAssetKind = "";
        ArrayList Alist = new ArrayList();

        if ((IAssetKind & 1) != 0) Alist.Add("A");
        if ((IAssetKind & 2) != 0) Alist.Add("P");
        if ((IAssetKind & 4) != 0) Alist.Add("S");
        if ((IAssetKind & 8) != 0) Alist.Add("M");
        if ((IAssetKind & 16) != 0) Alist.Add("O");

        foreach (string value in Alist) {
            filterAssetKind = QHS.AppOr(filterAssetKind, QHS.CmpEq("assetkind", value));
        }
        filterAssetKind = QHS.AppOr(filterAssetKind, QHS.IsNull("assetkind"));
        filter = QHS.AppAnd(filter, QHS.DoPar(filterAssetKind));

        CommFun.DoMainCommand("choose.listview.webdefault." + filter);
    }

    public void SelezionaListinoFiltrato() {
        Hashtable h = PState.var["filterListino"] as Hashtable;
        PState.var.Remove("filterListino");
        if (h == null) return;
        string idlistclass = h["idlistclass"].ToString();
        string descr = h["description"].ToString();
        SelezionaListino(idlistclass, descr);
    }
    public override void DoCommand(string command) {
        base.DoCommand(command);
        if (PState.IsEmpty) return;

        if (command == "filtraListino") {
            FiltraSelezioneListino();
        }
        if (command == "elencaListino") {
            SelezionaListino("", "");
        }
        if (command == "clientConfirmUpdating") {
            AggiornaDatiInBaseAUpb();
        }
    }


    void AggiornaDatiInBaseAUpb() {
        DataRow Curr = DS.mandatedetail.Rows[0];
        string filterUPB = QHS.CmpEq("idupb", Curr["idupb"]);
        object flagactivityUPB = Conn.DO_READ_VALUE("upb", filterUPB, "flagactivity");

        if ((Curr["flagactivity"].ToString() != flagactivityUPB.ToString())
            && (flagactivityUPB.ToString() == "1" || flagactivityUPB.ToString() == "2")) {
            bool do_update = ShowClientMessage("Cambio il Tipo attivit� in base all'UPB selezionato?", "Attenzione", System.Windows.Forms.MessageBoxButtons.OKCancel);
            if (!do_update)
                return;

            Curr["flagactivity"] = flagactivityUPB;
            if (flagactivityUPB.ToString() == "1")
                rdbIstituzionale.Checked = true;
            if (flagactivityUPB.ToString() == "2")
                rdbCommerciale.Checked = true;

        }
    }

    void ImpostaAttivita() {
        CommFun.DoMainCommand("clientConfirmUpdating");
    }

    public override void AfterRowSelect(DataTable T, DataRow R) {
        DataRow Curr = DS.mandatedetail.Rows[0];
        if ((T.TableName == "upb")||(T.TableName== "upbyearview")) {
            if (R != null) {
                ImpostaAttivita();
                if (R["cupcode"].ToString() == "") {
                    cupcode.Text = "";
                    return;
                }
                cupcode.Text = R["cupcode"].ToString();
                Curr["cupcode"] = R["cupcode"];
                UpdateQuantity(CfgFn.GetNoNullInt32(Curr["unitsforpackage"]));
                return;
            }
            else {
                cupcode.Text = "";
            }
        }

        if (T.TableName == "listview") {
            if (R != null) {
                object flagva3 = Conn.DO_READ_VALUE("config", QHS.CmpEq("ayear", Conn.Security.GetSys("esercizio")), "flagva3");
                if ((flagva3 == DBNull.Value) || (flagva3 == null))
                    flagva3 = "N";

                HelpMetaWeb.SetComboBoxValue(cmbUnitaMisuraAcquisto, R["idpackage"]);
                HelpMetaWeb.SetComboBoxValue(cmbUnitaMisuraCS, R["idunit"]);
                Curr["idpackage"] = R["idpackage"];
                Curr["idunit"] = R["idunit"];
                Curr["idlist"] = R["idlist"];
                Curr["unitsforpackage"] = R["unitsforpackage"];
                Curr["detaildescription"] = R["description"];
                if (CfgFn.GetNoNullDecimal(R["price"]) > 0) {
                    Curr["taxable"] = R["price"];
				}
				else {
                    Curr["taxable"] = DBNull.Value;
                }
                UpdateLabelQuantita();
                UpdateLabelTotQuantita();
                UpdateQuantity(CfgFn.GetNoNullInt32(Curr["unitsforpackage"]));

                string filterManKind = QHS.CmpEq("idmankind", Curr["idmankind"]);
                object linkToInvoice = Conn.DO_READ_VALUE("mandatekind", filterManKind, "linktoinvoice");
                object idlistclasssel = R["idlistclass"];
                string filterListClass = QHS.AppAnd(QHS.CmpEq("idlistclass", idlistclasssel), QHS.CmpEq("ayear", Conn.Security.GetSys("esercizio")));
                DataTable ListClass =
                        Conn.RUN_SELECT("listclassyearview", "*", null, filterListClass, null, true);
                if ((ListClass != null) && (ListClass.Rows.Count > 0) &&
                        (ListClass.Rows[0]["idinv"] != DBNull.Value ||
                         ListClass.Rows[0]["assetkind"] != DBNull.Value ||
                         ListClass.Rows[0]["va3type"] != DBNull.Value)) {

                    Curr["idinv"] = ListClass.Rows[0]["idinv"];
                    Curr["assetkind"] = ListClass.Rows[0]["assetkind"];

                    if ((linkToInvoice.ToString() != "N") && (flagva3.ToString() != "N"))
                        Curr["va3type"] = ListClass.Rows[0]["va3type"];
                    //Meta.FreshForm();

                }

                // Legge la causale EP associata alla classificazione merceologica del listino, e la scrive nella causale EP del dettaglio ordine.
                object idaccmotive = Conn.DO_READ_VALUE("listclass", QHS.CmpEq("idlistclass", R["idlistclass"]), "idaccmotive");
                Curr["idaccmotive"] = idaccmotive;
                ImpostaNaturadiSpesa(idaccmotive);
				object calcoloDoc = Conn.DO_READ_VALUE("siopekind", QHS.CmpEq("ayear", Conn.GetSys("esercizio")), "newcomputesorting");
				if (calcoloDoc != null && calcoloDoc != DBNull.Value)
					newcomputesorting = calcoloDoc.ToString().ToUpper();

				if (newcomputesorting.Equals("S")) {
					DataRow[] rClass = getSiopeForAccmotive(idaccmotive);
					if (rClass != null && rClass.Length == 1) {
						Curr["idsor_siope"] = rClass[0]["idsor"];
					}
				}

				this.CommFun.FreshForm(false, false);
            }
        }

        if (T.TableName == "ivakind") {
            if (R != null) {
                if (!this.CommFun.DrawStateIsDone)
                    return;
                Curr["taxrate"] = R["rate"];
                taxrate.Text = HelpForm.StringValue(Curr["taxrate"], taxrate.Tag);
                double aliquota = CfgFn.GetNoNullDouble(R["rate"]);
                double percindeduc = CfgFn.GetNoNullDouble(R["unabatabilitypercentage"]);
                unabatabilitypercentage.Text =
                HelpForm.StringValue(percindeduc, unabatabilitypercentage.Tag);
                UpdateQuantity(CfgFn.GetNoNullInt32(Curr["unitsforpackage"]));
                CalcolaImportiValuta(aliquota, percindeduc);
                CalcolaImportiEUR(aliquota, percindeduc);
            }
        }

    }

    public DataRow[] getSiopeForAccmotive(object idaccmotive) {
        if (idaccmotive == null || idaccmotive==DBNull.Value) {
            //Ho cancellato la causale, azzero il siope.
            return null;
        }        
        object idsorkindS = Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", "SIOPE_U_18"), "idsorkind");
        string filterClassEsistenti = QHS.AppAnd(QHS.CmpEq("idsorkind", idsorkindS), QHS.CmpEq("idaccmotive", idaccmotive));
        DataTable tAccmotivesortingview = Conn.RUN_SELECT("accmotivesortingview", "idsor", null, filterClassEsistenti, null, false);
        if (tAccmotivesortingview.Rows.Count>0) 
            return tAccmotivesortingview.Select();

        return null;   
    }

    private void ImpostaNaturadiSpesa(object idaccmotive) {
        if (idaccmotive == DBNull.Value) return;
        DataRow Curr = DS.mandatedetail.Rows[0];
        object expensekind = Conn.DO_READ_VALUE("accmotive", QHS.CmpEq("idaccmotive", idaccmotive), "expensekind");
        if (expensekind == DBNull.Value || expensekind == null) return;
        Curr["expensekind"] = expensekind;
    }



    public override void AfterFill() {
        //HelpForm.SetDenyNull(DS.mandatedetail.Columns["idivakind"], true);
        DataRow Curr = DS.mandatedetail.Rows[0];
        DataRow[] RR = DS.ivakind.Select(QHC.CmpEq("idivakind", Curr["idivakind"]));
        if (RR.Length != 0) {
            DataRow CurrIvaKind = RR[0];
            double aliquota = CfgFn.GetNoNullDouble(CurrIvaKind["rate"]);
            double percindeduc = CfgFn.GetNoNullDouble(CurrIvaKind["unabatabilitypercentage"]);
            CalcolaImponibileValuta();
            CalcolaImportiEUR(aliquota, percindeduc);

        }
        number.Attributes.Add("readonly", "readonly");
        taxabletotal.Attributes.Add("readonly", "readonly");

        if (!PState.InsertMode) {
            UpdateLabelQuantita();
            UpdateLabelTotQuantita();
        }

        //string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
        //BtnListino.Tag = "choose.listview.webdefault." + filter;

        if (PState.var.ContainsKey("filterListino")) {
            SelezionaListinoFiltrato();
        }

        ImpostaFiltroAliqIva();
        ImpostaTageFiltriUPB(getActivitySelection(), Curr["idupb"]);
    }

    private void ImpostaFiltroAliqIva() {
        if (Meta == null)
            return;
        if (!this.CommFun.DrawStateIsDone)
            return;
        string filteraliquote = CalcolaFiltroAliqIva();

        GetData.SetStaticFilter(DS.ivakind, filteraliquote);
        GetData.CacheTable(DS.ivakind);
        CommFun.HMW.FilteredPreFillCombo(idivakind, filteraliquote, true);
    }

    private string CalcolaFiltroAliqIva() {
        if (QHS == null)
            return basefilteriva;

        if (rdbQualsiasi.Checked)
            return basefilteriva; //nessun filtro
        if (rdbCommerciale.Checked)
            return QHS.AppAnd(basefilteriva, QHS.BitSet("flag", 1));  //tipo attivit� commerciale 
        if (rdbIstituzionale.Checked)
            return QHS.AppAnd(basefilteriva, QHS.BitSet("flag", 0));  //tipo attivit� istituzionale
        if (rdbPromiscua.Checked)
            return QHS.AppAnd(basefilteriva, QHS.BitSet("flag", 2));  //tipo attivit� promiscua/altro
        return basefilteriva;
    }

    int getActivitySelection() {
        if (rdbQualsiasi.Checked)
            return 4; //nessun filtro
        if (rdbCommerciale.Checked)
            return 2;  //tipo attivit� commerciale 
        if (rdbIstituzionale.Checked)
            return 1;  //tipo attivit� istituzionale
        if (rdbPromiscua.Checked)
            return 3;  //tipo attivit� promiscua/altro
        return 4;
    }

    void Register_fn_TotImponibile() {
        number.FunctionName = "CalcTotQuant();";
        number.DependsOn(txtQuantitaConfezioni);
        number.DependsOn(txtCoeffConversione);

        taxabletotval.FunctionName = "CalcImponibileTot();";
        taxabletotval.DependsOn(txtQuantitaConfezioni);
        taxabletotval.DependsOn(taxable);
        taxabletotval.DependsOn(discount);
        taxabletotval.DependsOn(txtCoeffConversione);
        //taxabletotval.DependsOn(number);

        tax.FunctionName = "CalcIva(" + HelpMetaWeb.JscriptString(tassocambio()) + ");";
        tax.DependsOn(taxabletotval);

        impindeduceur.FunctionName = "CalcIvaIndeduc(" + HelpMetaWeb.JscriptString(tassocambio()) + ");";
        impindeduceur.DependsOn(tax);

        taxabletotal.FunctionName = "CalcTaxableTotal(" + HelpMetaWeb.JscriptString(tassocambio()) + ");";
        taxabletotal.DependsOn(taxabletotval);

        taxabletotal.AddPostFormatEvent();////necessaria perch�  taxabletotal non ha tag
        taxabletotval.AddPostFormatEvent();////necessaria perch�  taxabletotval non ha tag

        //rimane da fare: double impindeducEUR = CfgFn.RoundValuta(ivaEUR * percindeduc);



    }

    private void CalcolaImportiValuta(double aliquota, double percindeduc) {
        DataRow Curr = DS.mandatedetail.Rows[0];

        try {
            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantita = CfgFn.GetNoNullDouble(Curr["npackage"]);
            //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
            double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio());
            double ivaEUR = CfgFn.RoundValuta(imponibiletotEUR * aliquota);
            //double iva        = CfgFn.RoundValuta(imponibiletot*aliquota);
            //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
            //double impindeduc=	CfgFn.RoundValuta(iva*percindeduc);
            //double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);
            double impindeducEUR = CfgFn.RoundValuta(ivaEUR * percindeduc);
            taxabletotval.Text = HelpForm.StringValue(imponibiletot,
                "x.y.fixed.2...1");//             imponibiletot.ToString("n");
            tax.Text = HelpForm.StringValue(ivaEUR, "x.y.fixed.2...1");//   iva.ToString("n");
            Curr["tax"] = ivaEUR;
            impindeduceur.Text = HelpForm.StringValue(impindeducEUR, "x.y.fixed.2...1");//  impindeduc.ToString("n");
            Curr["unabatable"] = impindeducEUR;
            Curr["taxrate"] = aliquota;
            taxrate.Text = HelpForm.StringValue(aliquota, taxrate.Tag.ToString());
            aliquota.ToString("p04");
        }
        catch {
            taxabletotval.Text = "";
            tax.Text = "";
            impindeduceur.Text = "";
            taxrate.Text = "";
        }
    }
    private void CalcolaImponibileValuta() {
        DataRow Curr = DS.mandatedetail.Rows[0];
        try {
            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantita = CfgFn.GetNoNullDouble(Curr["npackage"]);

            //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibiletot = CfgFn.RoundValuta((imponibile * (quantita) * (1 - sconto)));
            taxabletotval.Text = HelpForm.StringValue(imponibiletot, "x.y.fixed.2...1");//         imponibiletot.ToString("n");
        }
        catch {
            taxabletotval.Text = "";
        }
    }


    public void UpdateLabelQuantita() {
        DataRow Curr = DS.mandatedetail.Rows[0];
        int idpackage = CfgFn.GetNoNullInt32(Curr["idpackage"]);
        if (idpackage == 0)
            return;

        string filter = QHS.CmpEq("idpackage", idpackage);

        DataTable T = Conn.RUN_SELECT("package", "*", null, filter, null, false);

        if (T == null || T.Rows.Count == 0)
            return;
        lblQuantita.Text = "N. " + T.Rows[0]["description"].ToString();
        return;
    }

    public void UpdateLabelTotQuantita() {
        DataRow Curr = DS.mandatedetail.Rows[0];
        int idunit = CfgFn.GetNoNullInt32(Curr["idunit"]);
        if (idunit == 0)
            return;

        string filter = QHS.CmpEq("idunit", idunit);

        DataTable T = Conn.RUN_SELECT("unit", "*", null, filter, null, false);

        if (T == null || T.Rows.Count == 0)
            return;
        lblTotQuantOrd.Text = "N. " + T.Rows[0]["description"].ToString();


        return;
    }

    public void UpdateQuantity(int UnitsForPackage) {
        if (UnitsForPackage == 0)
            UnitsForPackage = 1;
        DataRow Curr = DS.mandatedetail.Rows[0];
        double QuantConf = CfgFn.GetNoNullDouble(Curr["npackage"]);
        decimal Result = Convert.ToDecimal(UnitsForPackage * QuantConf);

        Curr["number"] = Result;
        number.Text = Result.ToString();

    }

    private void CalcolaImportiEUR(double aliquota, double percindeduc) {
        DataRow Curr = DS.mandatedetail.Rows[0];

        try {
            double imponibile = CfgFn.GetNoNullDouble(Curr["taxable"]);
            double quantita = CfgFn.GetNoNullDouble(Curr["number"]);
            //double aliquota  = CfgFn.GetNoNullDouble(Curr["taxrate"]);
            double sconto = CfgFn.GetNoNullDouble(Curr["discount"]);
            double imponibiletot = CfgFn.RoundValuta((imponibile * quantita * (1 - sconto)));
            double imponibiletotEUR = CfgFn.RoundValuta(imponibiletot * tassocambio());
            //double iva        = CfgFn.GetNoNullDouble(Curr["tax"]);
            //double ivaEUR     = CfgFn.RoundValuta(iva*tassocambio);
            //double impindeduc=	CfgFn.GetNoNullDouble(Curr["unabatable"]);
            //double impindeducEUR=	CfgFn.RoundValuta(impindeduc*tassocambio);

            taxabletotal.Text = HelpForm.StringValue(imponibiletotEUR, "x.y.fixed.2...1");
            //Curr["taxable"] = imponibiletotEUR;
            //imponibiletotEUR.ToString("n");
            //txtIvaEUR.Text = HelpForm.StringValue(ivaEUR,
            //    "x.y.fixed.2...1"); //                .ToString("n");
            //txtImpDeducEUR.Text = HelpForm.StringValue(impindeducEUR,
            //    "x.y.fixed.2...1");//                .ToString("n");
        }
        catch {
            taxabletotal.Text = "";
            //Curr["taxable"] = 0;
            //txtIvaEUR.Text ="";	
            //txtImpDeducEUR.Text="";
        }

    }


    public void rdbQualsiasi_CheckedChanged(object sender, EventArgs e) {
        RadioButton rdb = sender as RadioButton;
        if (!CommFun.DrawStateIsDone) return;
        if (rdb == null)
            return;
        if (!rdb.Checked)
            return;
        ImpostaFiltroAliqIva();
        DataRow r = DS.mandatedetail.Rows[0];
        ImpostaTageFiltriUPB(getActivitySelection(), r["idupb"]);
    }


    protected void CheckBox1_CheckedChanged(object sender, EventArgs e) {

    }
}
