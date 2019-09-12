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
using System.Collections;
using System.IO;
using Install;

namespace no_table_unifydip {
    public partial class Frm_Uniydip : Form {
        public Frm_Uniydip() {
            InitializeComponent();
            tabController.HideTabsMode =
    Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }



        #region Gestione Tabs

        DataAccess Source;
        DataAccess Dest;
        DataAccess Conn;
        int fattore;

        string CustomTitle="Trasferimento dati NON DBO da un dipartimento all'altro";
        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnBack.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnNext.Text = "Ricomincia.";
            else
                btnNext.Text = "Next >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            if (newTab > 0) ShowPage(newTab);
        }
        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                if (MessageBox.Show(this, "Si desidera eseguire ancora la procedura",
                    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                    newTab = 1;
                    ResetWizard();
                }
                else {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                }
            }
            DisplayTabs(newTab);
        }
        private void btnBack_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }
        private void btnNext_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if (oldTab == 0) {
                return CheckStandard(); // 0->1: nothing to do
            }
            if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
            if (oldTab == 1 && newTab == 2) {// Scelta dipartimento  -> avanti

                if (Source != null) {
                    Source.Close();
                    Source.Destroy();
                    Source = null;
                }

                if (Dest != null) {
                    Dest.Close();
                    Dest.Destroy();
                    Dest = null;
                }


                object Ofattore = HelpForm.GetObjectFromString(typeof(int), txtFattore.Text.Trim(), "x.y");
                if (Ofattore == null || Ofattore == DBNull.Value) {
                    MessageBox.Show(this, "E' necessario inserire il fattore moltiplicativo","Errore");
                    return false;
                }
                fattore = CfgFn.GetNoNullInt32(Ofattore);
                if (fattore <= 0) {
                    MessageBox.Show(this, "E' necessario inserire il fattore moltiplicativo", "Errore");
                    return false;
                }

                string errore;
                string errore2;
                string dettaglio;
                string dettaglio2;
                string sourceserver = Conn.GetSys("server").ToString();
                string sourcedatabase = Conn.GetSys("database").ToString();

                Source = Easy_DataAccess.getEasyDataAccess("Source DB", sourceserver,sourcedatabase, 
                                            txtSourceUser.Text.Trim(), txtSourcePwd.Text.Trim(),
                                    txtSourceDip.Text.Trim(),
                                    Convert.ToInt32(Conn.GetSys("esercizio")),
                                    Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore, out dettaglio);
                Dest = Easy_DataAccess.getEasyDataAccess("Source DB",
                                    sourceserver,
                                    sourcedatabase,
                                   txtDestUser.Text.Trim(),
                                    txtDestPwd.Text.Trim(),
                                  txtDipDestinazione.Text.Trim(),
                                  Convert.ToInt32(Conn.GetSys("esercizio")),
                                  Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore2, out dettaglio2);
                if (Source == null || errore != null) {
                    QueryCreator.ShowError(this, errore, dettaglio);
                    if (Dest!= null) Dest.Destroy();
                    return false;
                }
                if (Dest == null || errore2 != null) {
                    QueryCreator.ShowError(this, errore2, dettaglio2);
                    Source.Destroy();
                    return false;
                }


                if (!Source.Open()) {
                    Source.Destroy();
                    Source = null;
                    MessageBox.Show(this, "Non è stato possibile collegarsi al dip. di origine " + txtSourceDip.Text.Trim());
                    return false;
                }
                if (!Dest.Open()) {
                    Source.Close();
                    Source.Destroy();
                    Source = null;

                    Dest.Destroy();
                    Dest = null;
                    MessageBox.Show(this, "Non è stato possibile collegarsi al dip. di destinazione " + txtDipDestinazione.Text.Trim());
                    return false;
                }


            }
            return true;
        }

        #endregion


        public void MetaData_AfterLink() {
            MetaData Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            
        }


        bool CheckStandard() {
            return true;
        }
        void ResetWizard() {
        }

        void ShowPage(int NPasso) {
            btnBack.Enabled = false;
            btnNext.Enabled = false;
            if (NPasso == 2) {
                if (ImportData(true,false)) {
                    btnNext.Enabled = true;
                    btnCopia.Visible = true;
                }
                else {
                    btnNext.Enabled = false;
                }
                return;
            }
            //if (NPasso == 3) {
            //    VerificaFinEffettuata = false;
            //    ShowCheckFin();
            //    EnableDisableButtons_CheckFin();
            //    return;
            //}
            //if (NPasso == 4) {
            //    CopyDBO_Done = false;
            //    EnableDisableButtons_CopyDBO();
            //    return;
            //}
            //if (NPasso == 5) {
            //    CopyNonDBO_Done = false;
            //    EnableDisableButtons_CopyNonDBO();
            //    return;
            //}
            btnBack.Enabled = true;
            btnNext.Enabled = true;

        }

                 


        //Analizza la situazione dei db
        CopyManager Get_CopyManager(DataAccess Source, DataAccess Dest,int fattore, string depcode, bool append_suffix,
                        int oldfactor) {

           

            QueryHelper QHS = Conn.GetQueryHelper();
            CopyManager CM = new CopyManager(Source, Dest);

            bool first_dip = false;
            if (Dest.RUN_SELECT_COUNT("expense", null, false) == 0) first_dip = true;
            string intsuffix = "-" + fattore.ToString();
            string suffix = "-" + depcode;
            if (depcode == "amministrazione") suffix = "-amm";
            string forcedsuffix = suffix;
            if (!append_suffix) {
                suffix = "";
                intsuffix = "";
            }
        

            string sourcedatabase = Conn.GetSys("database").ToString();
            bool isAmministrazione = false;
            if (depcode == "amministrazione") isAmministrazione = true;


            //Copia tutte le tabelle DBO
            foreach (string dbotable in new string[] {
                "address", "assetusagekind", "bank", "cab", "category",
                "centralizedcategory", "currency", "ddt_in_motive", "ddt_out_motive",
                "inventorysortinglevel", "inventorytree", "inventorytreelink",
                "itinerationrefundkind", "ivapayperiodicity", "list", "listclass", "maintenancekind",
                "maritalstatus", "package", "paymethod", "registryaddress", "registrykind", "registrylegalstatus",
                "registryrole", "registrytaxablestatus", "service", "servicetax", "stamphandling",
                "storeload_motive", "storeunload_motive", "tax", "title", "unit"
            }) {

                CM.Add(new Copyer(dbotable, Conn)
                           .SkipIfNotEmpty()
                           .ShouldClearDestDB(first_dip)
                    );

            }


            

             foreach (string dbotable2 in new string[] {
                 //"accmotive", "accmotivedetail", 
                 //"accmotiveepoperation", "accountlookup", 
                 "csa_agency","csa_agencypaymethod", "csa_contractkind", "csa_contractkindrules", "csapaymethodlookup",
                 "csapositionlookup", 
                 "dbuseradvice", 
                 "inventorytreemultifieldkind", "linkedserveraccess",
                 "mainaccountingyear", "multifieldkind", "parasubcontractlist", 
                 //"patrimonylookup", "placcountlookup", 
                 "registrycf", "registrydurc", "registrypiva", "role",
                 "roleservice", "unifiedf24ep", "unifiedf24epsanction"
             }) {
                 CM.Add(new Copyer(dbotable2, Conn)
                           .SkipIfNotEmpty()
                           .ShouldClearDestDB(first_dip)
                    );
             }

             CM.Add(new Copyer("unifiedtax", Conn)
                            .AddPrivateTranslator("idexp",new IdentityTranslator())
                            .SkipIfNotEmpty()
                            .ShouldClearDestDB(first_dip)
                     );
             CM.Add(new Copyer("unifiedtaxcorrige", Conn)
                            .AddPrivateTranslator("idexp", new IdentityTranslator())
                             .SkipIfNotEmpty()
                             .ShouldClearDestDB(first_dip)
                      );

             foreach (string dbotable3 in new string[] {
                 //"account", "accountlevel", "accountkind",                  
                 "filetype", 
                 //"patrimony","patrimonylevel", 
                 //"placcount", "placcountlevel", 
                 "registry",  "registrypaymethod", "registryreference",
                 "unifiedivaregister", 
                 "unifiedivaregisterkind"
             }) {
                 CM.Add(new Copyer(dbotable3, Conn)
                           .SkipIfNotEmpty()
                           .ShouldClearDestDB(first_dip)
                    );
             }



            //Sezione
            //CM.Add(new Copyer("division", Conn)
            //    .DefinesPreTranslator("iddivision", CreateConditionalOffsetApplier("division", "iddivision", cento * fattore,cento))
            //    .AddPrivateTranslator("codedivision", new StringAppender(suffix,20))
            //    .AddPrivateTranslator("description", new StringAppender(suffix,150))
            //    );
            CM.Add(new Copyer("division", Conn)
                     .DontCopy()
                     .DefinesPreTranslator("iddivision",new set_to_null())
                );


            //Responsabile --> bisogna differenziare i title!!!
            //CM.Add(new Copyer("manager", Conn)
            //    .DefinesPreTranslator("idman", CreateConditionalOffsetApplier("manager", "idman", mille * fattore,mille))
            //    .AddPrivateTranslator("title",new StringAppender(suffix,150))
            //    );

            CM.Add(new Copyer("manager", Conn)
                     .DefinesPreTranslator("idman",
                                           CreateBaseLookupTraslator("manager", "newidman", "idman",
                                                                     "idman").SetAllowNoTranslation(true)                                                                     
                                                                     )                                          
                     .SkipIfNotEmpty()
              );



            //Recuperi
            CM.Add(new MergeWithIntKey("clawback", Conn, "idclawback", "clawbackref").ShouldClearDestDB(first_dip));
            CM.Add(new Copyer("clawbacksorting",Conn)
                        .SkipDuplicates()
                        .ShouldClearDestDB(first_dip)
                        .SkipOnNull("idsor")
                        );

           

            
            CM.Add(new Copyer("finlevel", Conn)
                        .SkipIfNotEmpty()
                        .ShouldClearDestDB(first_dip)
            );

            //Tabelle speciali: Bilancio, UPB, Classificazioni
            CM.Add(new FinCopyer(Conn));


            //siamo rimasti d'accordo che la struttura delle upb la riempiamo PRIMA di iniziare la migrazione
            //CM.Add(new UpbCopyer(Conn, fattore,first_dip));
            CM.Add(new Copyer("upb", Conn)
                      .DefinesPreTranslator("idupb",
                                            CreateBaseLookupTraslator("upb", "newcodeupb", "codeupb",
                                                                      "idupb").SetAllowNoTranslation(true)
                                            )
                      .SkipIfNotEmpty()
               );

            
            
            CM.Add(new SortingCopyer(Conn).ShouldClearDestDB(false));
            //CM.Add(new Copyer("finlast", Conn));
            //CM.Add(new Copyer("finlink", Conn)
            //                .SetExternalCode("idchild", "idfin")
            //                .SetExternalCode("idparent", "idfin")
            //        );
            //CM.Add(new Copyer("finlookup", Conn)
            //                .SetExternalCode("oldidfin", "idfin")
            //                .SetExternalCode("newidfin", "idfin")
            //        );
            CM.Add(new Copyer("finlast", Conn)
                        .SkipOnNull("idfin")
                        .SkipIfNotEmpty()
            );

            CM.Add(new Copyer("finlookup", Conn)
                        .SkipIfNotEmpty()
                        .SetExternalCode("oldidfin","idfin")
                        .SkipOnNull("oldidfin")
                        .SetExternalCode("newidfin", "idfin")
                        .SkipOnNull("newidfin")
                        );

            CM.Add(new Copyer("finsorting", Conn).SkipIfNotEmpty().SkipOnNull("idfin").SkipOnNull("idsor"));
            CM.Add(new Copyer("upbsorting", Conn).SkipDuplicates().SkipOnNull("idsor"));

            //Variazioni di bilancio
            CM.Add(new Copyer("finvar", Conn)
                       .DefinesPreTranslator("finvar.nvar", 
                            CreateConditionalOffsetApplier("finvar", "nvar", mille * fattore,mille*oldfactor)
                            .SetFilterConflict("(yvar<=2012)"))
                       .SetExternalCode("nvar", "finvar.nvar")
                   );

            CM.Add(new Copyer("finvardetail", Conn)
                        .SetExternalCode("nvar", "finvar.nvar")
                        .SetFilter(QHS.CmpGe("yvar", 2006))  
                        );
            CM.Add(new FinYearCopyer(Conn));

            string filterexp="(idexp not in (select EL.idchild from expenselink EL join expense S "+
                                    " on EL.idparent=S.idexp WHERE S.ymov<2006 and EL.nlevel=1))";
                        
            //Movimenti di spesa ed entrata
            CM.Add(new Copyer("expense", Conn)
                        .SetExternalCode("idformerexpense", "idexp")
                        .AllowNoTranslation("idformerexpense")
                        .SetExternalCode("idpayment", "idexp")
                        .SetExternalCode("parentidexp", "idexp")
                        .SetExternalCode("nmov", "exp.nmov")
                        .SkipOnNull("idpayment")
                        .SetFilter(filterexp)
                        .DefinesPreTranslator("idexp", CreateOffsetApplier("expense", "idexp", accoda,filterexp))
                        .DefinesPreTranslator("exp.nmov", CreateConditionalOffsetApplier("expense", "nmov", diecimila * fattore, diecimila*oldfactor))
                        );

            string filterinc = "(idinc not in (select EL.idchild from incomelink EL join income S " +
                                    " on EL.idparent=S.idinc WHERE S.ymov<2006 and EL.nlevel=1))";
            CM.Add(new Copyer("income", Conn)
                .SetExternalCode("parentidinc", "idinc")
                .SetExternalCode("idpayment", "idexp")
                .SetExternalCode("nmov", "inc.nmov")
                .SkipOnNull("idpayment")
                .SetFilter(filterinc)
                .DefinesPreTranslator("idinc", CreateOffsetApplier("income", "idinc", accoda,filterinc))
                .DefinesPreTranslator("inc.nmov", CreateConditionalOffsetApplier("income", "nmov", diecimila * fattore, diecimila * oldfactor)));


            CM.Add(new Copyer("incomeyear", Conn).SetFilter(QHS.CmpGe("ayear", 2006)).SkipOnNull("idinc"));
            CM.Add(new Copyer("expenseyear", Conn).SetFilter(QHS.CmpGe("ayear", 2006)).SkipOnNull("idexp"));
            //CM.Add(new Copyer("incometotal", Conn).SetFilter(QHS.CmpGe("ayear", 2006)).SkipOnNull("idinc"));
            //CM.Add(new Copyer("expensetotal", Conn).SetFilter(QHS.CmpGe("ayear", 2006)).SkipOnNull("idexp"));
            //CM.Add(new Copyer("incomelink", Conn)
            //            .SetExternalCode("idchild", "idinc")
            //            .SetExternalCode("idparent", "idinc")
            //            .SkipOnNull("idchild")
            //            );
            //CM.Add(new Copyer("expenselink", Conn)
            //            .SetExternalCode("idchild", "idexp")
            //            .SetExternalCode("idparent", "idexp")
            //            .SkipOnNull("idchild")
            //    );
            CM.Add(new Copyer("expenselast", Conn).SkipOnNull("idexp"));

            //Contabilizzazioni
            CM.Add(new Copyer("expensemandate", Conn).SkipOnNull("idexp"));
            CM.Add(new Copyer("expenseinvoice", Conn).SkipOnNull("idexp"));



            //Tesoriere
            CM.Add(new Copyer("treasurer", Conn)
                .DefinesPreTranslator("idtreasurer", CreateConditionalOffsetApplier("treasurer", "idtreasurer", cento * fattore,cento))
                .AddPrivateTranslator("codetreasurer", new StringAppender(suffix,20))
            );

            //dipende da idman e da idtreasurer
            CM.Add(new Copyer("paymenttransmission", Conn)
                            .SetFilter(QHS.CmpGe("ypaymenttransmission", 2006))
                            .DefinesPreTranslator("kpaymenttransmission", CreateOffsetApplier("paymenttransmission", "kpaymenttransmission", accoda))
                            .DefinesPreTranslator("npaymenttransmission", CreateConditionalOffsetApplier("paymenttransmission", "npaymenttransmission", diecimila * fattore,diecimila)));


            CM.Add(new Copyer("proceedstransmission", Conn)
                            .SetFilter(QHS.CmpGe("yproceedstransmission", 2006))
                            .DefinesPreTranslator("kproceedstransmission", CreateOffsetApplier("proceedstransmission", "kproceedstransmission", accoda))
                            .DefinesPreTranslator("nproceedstransmission", CreateConditionalOffsetApplier("proceedstransmission", "nproceedstransmission", diecimila * fattore,diecimila)));


            CM.Add(new Copyer("payment", Conn)
                        .SetFilter(QHS.CmpGe("ypay", 2006))
                        .DefinesPreTranslator("kpay", CreateOffsetApplier("payment", "kpay", accoda))
                        .DefinesPreTranslator("npay", CreateConditionalOffsetApplier("payment", "npay", diecimila * fattore,diecimila)));

            CM.Add(new Copyer("bill", Conn)
                     .SetFilter(QHS.CmpGe("ybill", 2006))
                     .DefinesPreTranslator("nbill", CreateConditionalOffsetApplier("bill", "nbill", diecimila * fattore,diecimila)));

            CM.Add(new Copyer("payment_bank", Conn).SkipOnNull("kpay"));
            CM.Add(new Copyer("proceeds_bank", Conn).SkipOnNull("kpro"));


            //dipende da idman, idfin, idtreasurer,kproceedstransmission
            CM.Add(new Copyer("proceeds", Conn)
                        .SetFilter(QHS.CmpGe("ypro",2006))
                        .DefinesPreTranslator("kpro", CreateOffsetApplier("proceeds", "kpro", accoda))
                        .DefinesPreTranslator("npro", CreateConditionalOffsetApplier("proceeds", "npro", mille * fattore,mille)));


            //Tabelle dipendenti da income , assegnazione crediti ed incassi
            CM.Add(new Copyer("incomelast", Conn).SkipOnNull("idinc"));
            CM.Add(new Copyer("proceedspart", Conn).SkipOnNull("idinc").SkipOnNull("idfin"));
            CM.Add(new Copyer("creditpart", Conn).SkipOnNull("idinc").SkipOnNull("idfin"));


            //E' inutile perché la chiave è il codice stesso
            //CreateLookupTraslator("mandatekind", "idmankind", "idmankind");
            //CreateLookupTraslator("mandatekind", "idmankind", "idmankind");
            CM.Add(new Copyer("mandatekind", Conn)
                //.ShouldClearDestDB(first_dip)
                .DefinesPreTranslator("idmankind",  new StringAppender(forcedsuffix,20))
                .AddPrivateTranslator("description", new StringAppender(forcedsuffix, 50))
                );

            CM.Add(new Copyer("estimatekind", Conn)
                //.ShouldClearDestDB(first_dip)
                .DefinesPreTranslator("idestimkind", new StringAppender(forcedsuffix, 20))
                .AddPrivateTranslator("description", new StringAppender(forcedsuffix, 50))
                );

            //Contratti passivi
            CM.Add(new Copyer("mandate", Conn)
                        //.DefinesPreTranslator("nman", CreateConditionalOffsetApplier("mandate", "nman", diecimila * fattore,diecimila))
            );

            CM.Add(new Copyer("mandateattachment", Conn));
            CM.Add(new Copyer("mandatedetail", Conn)
                        .SetExternalCode("idexp_iva", "idexp")
                        .SetExternalCode("idexp_taxable", "idexp")
                        .AllowNoTranslation("idexp_iva")
                        .AllowNoTranslation("idexp_taxable")
                );
            CM.Add(new Copyer("mandatesorting", Conn).SkipOnNull("idsor"));

            //Contratti attivi
            CM.Add(new Copyer("estimate", Conn)
                        //.DefinesPreTranslator("nestim", CreateConditionalOffsetApplier("estimate", "nestim", diecimila * fattore, diecimila))
            );
            CM.Add(new Copyer("incomeestimate", Conn));
            CM.Add(new Copyer("incomeinvoice", Conn).SkipOnNull("idinc"));

            CM.Add(new Copyer("estimatedetail", Conn)
                        .SetExternalCode("idinc_iva", "idinc")
                        .SetExternalCode("idinc_taxable", "idinc")
                        .AllowNoTranslation("idinc_iva")
                        .AllowNoTranslation("idinc_taxable")
                );
            CM.Add(new Copyer("estimatesorting", Conn).SkipOnNull("idsor"));



            //Tipo inventario
            CM.Add(new MergeWithIntKey("inventorykind", Conn, "idinventorykind", "codeinventorykind"));
            //Ente inventario
            CM.Add(new MergeWithIntKey("inventoryagency", Conn, "idinventoryagency", "codeinventoryagency"));
            //Inventario
            CM.Add(new AppendStringToCodeField("inventory", Conn, "idinventory", "codeinventory", suffix,20)
                .AddPrivateTranslator("description", new StringAppender(suffix,50))     
                );


            //Tipo buon carico
            CM.Add(new AppendStringToCodeField("assetloadkind", Conn, "idassetloadkind", 
                                                    "codeassetloadkind",suffix,20)
                .AddPrivateTranslator("description", new StringAppender(suffix,50))                    
             );
            //Tipo buono scarico
            CM.Add(new AppendStringToCodeField("assetunloadkind", Conn, "idassetunloadkind", 
                                                    "codeassetunloadkind",suffix,20)
                .AddPrivateTranslator("description", new StringAppender(suffix,50))                
             );


            //Tipi Ammortamenti
            CM.Add(new MergeWithIntKey("inventoryamortization", Conn, "idinventoryamortization", "codeinventoryamortization"));
            //Associazione tipi ammortamento classificazione inventariale
            CM.Add(new Copyer("inventorysortingamortizationyear", Conn)
                .SkipDuplicates()
                );

            //CM.Add(new Copyer("inventorysortinglevel",Conn)
            //        .SkipDuplicates()
            //        );

            CM.Add(new Copyer("locationsorting", Conn)
                    .SkipDuplicates()
                    .SkipOnNull("idsor")
                    .SkipOnNull("idlocation")
                    );



            
            CM.Add(new Copyer("inventorytreesorting", Conn)
                    .SkipDuplicates()
                    .SkipOnNull("idsor")
                );

            //Causale di carico
            CM.Add(new MergeWithIntKey("assetloadmotive", Conn, "idmot", "codemot")
                    .CreateTranslatorAs("idmot_load")
                    .AddPrivateTranslator("description", new StringAppender(suffix,50)) 
                );

            //Causale di scarico
            CM.Add(new MergeWithIntKey("assetunloadmotive", Conn, "idmot", "codemot")
                    .CreateTranslatorAs("idmot_unload")
                    .AddPrivateTranslator("description", new StringAppender(suffix,50)) 
                );

            //Buoni di carico e scarico
            CM.Add(new Copyer("assetload", Conn)
                        .DefinesPreTranslator("idassetload", CreateOffsetApplier("assetload", "idassetload", accoda))
                        .SetExternalCode("idmot", "idmot_load"));

            CM.Add(new Copyer("assetunload", Conn)
                        .DefinesPreTranslator("idassetunload", CreateOffsetApplier("assetunload", "idassetunload", accoda))
                        .SetExternalCode("idmot", "idmot_unload"));

            //Carico cespite
            CM.Add(new Copyer("assetacquire", Conn)
                    .DefinesPreTranslator("nassetacquire", CreateOffsetApplier("assetacquire", "nassetacquire", accoda))
                    .SetExternalCode("idmot","idmot_load")
            );

            //Cespite
            CM.Add(new Copyer("asset", Conn)
                    .DefinesPreTranslator("idasset", CreateOffsetApplier("asset", "idasset", accoda))
                    .SetExternalCode("idasset_prev", "idasset"));


            CM.Add(new Copyer("assetvar", Conn)
                        .DefinesPreTranslator("nvar_asset", CreateConditionalOffsetApplier("assetvar", "nvar", mille * fattore,mille))
                        .SetExternalCode("nvar", "nvar_asset")
                        .DefinesPreTranslator("idassetvar", CreateOffsetApplier("assetvar", "idassetvar", accoda))
            );
            CM.Add(new Copyer("assetvardetail", Conn)
                        .SetExternalCode("nvar", "nvar_asset")
                        .SetExternalCode("idmot","idmot_load")
            );



            //Ubicazioni e livelli ubicazioni
            //CM.Add(new LocationLevelCopyer(Conn));
            //CM.Add(new LocationCopyer(Conn));
            //Siamo rimasti d'accordo che creiamo la struttura delle ubicazioni COMPLETA prima di fare la migrazione
            CM.Add(new Copyer("location", Conn)
                       .DefinesPreTranslator("idlocation",
                                             CreateBaseLookupTraslator("location", "newlocationcode", "locationcode",
                                                                       "idlocation").SetAllowNoTranslation(true)
                                              )
                       
                       .SkipIfNotEmpty()
                );


            //Ammortamenti
            CM.Add(new Copyer("assetamortization", Conn)
                    .DefinesPreTranslator("namortization", CreateOffsetApplier("assetamortization", "namortization", accoda)));
            CM.Add(new Copyer("assetconsignee", Conn)
                    .SkipDuplicates()
                );
            CM.Add(new Copyer("assetusage", Conn));
            CM.Add(new Copyer("assetloadexpense", Conn).SkipOnNull("idexp"));
            CM.Add(new Copyer("assetunloadincome", Conn).SkipOnNull("idinc"));
            CM.Add(new Copyer("assetlocation", Conn).SkipOnNull("idlocation"));
            CM.Add(new Copyer("assetmanager", Conn).SkipOnNull("idman"));
            CM.Add(new Copyer("assettolink", Conn)
                    .SetExternalCode("idinventory_tolink", "idinventory")
                    // ninventory non è da rimappare in quanto stiamo differenziando gli inventory
                    //.SetExternalCode("ninventory_tolink", "ninventory") 
                );


            CM.Add(new MergeWithIntKey("sortingkind", Conn, "idsorkind", "codesorkind")
                        .SetExternalCode("idparentkind", "idsorkind")
                        .SetFilter(QHS.FieldIn("codesorkind",
                            new object[] { "07E_SIOPE", "WIFIN", "WIFINRR", "WIFINV", "WIREG", "WIREGV",
                                                "WIREGR","WIUPB","07U_SIOPE","WIAM1","WIAM2"}))
                        //.ShouldClearDestDB(first_dip)
                        );
            CM.Add(new Copyer("sortinglevel", Conn)
                        .SkipDuplicates()
                        .SkipOnNull("idsorkind")
                        );



            CM.Add(new ForcedAppendWithIntKey("pettycash", Conn, "idpettycash", "pettycode")
                    .AddPrivateTranslator("description",new StringAppender(suffix,50))       
                    .AddPrivateTranslator("pettycode", new StringAppender(suffix,20))
                    .ShouldClearDestDB(first_dip)
                );
            CM.Add(new Copyer("pettycashexpense", Conn).SkipOnNull("idexp"));
            CM.Add(new Copyer("pettycashincome", Conn).SkipOnNull("idinc"));
            CM.Add(new Copyer("pettycashoperation", Conn)
                        .SetFilter(QHS.CmpGe("yoperation", 2006))
                        .AllowNoTranslation("idexp")
                        .AllowNoTranslation("idman")
                        );

            CM.Add(new Copyer("pettycashoperationitineration", Conn)
                       .SetFilter("idpettycash in (select idpettycash from pettycash)")        //salta qualche cadavere
                       );

            CM.Add(new Copyer("pettycashoperationinvoice", Conn)
                        .SetFilter("idpettycash in (select idpettycash from pettycash)")        //salta qualche cadavere
                );
            CM.Add(new Copyer("pettycashoperationsorted", Conn).SkipOnNull("idsor"));
            CM.Add(new Copyer("pettycashsetup", Conn)
                        .SetFilter(QHS.CmpGe("ayear",2006))
                        .SetExternalCode("idfinincome", "idfin")
                        .SetExternalCode("idfinexpense", "idfin"));

            CM.Add(new MergeWithIntKey("ivakind", Conn, "idivakind", "codeivakind")
                    .ShouldClearDestDB(first_dip)
                );

            //Tipo fattura
            CM.Add(new AppendStringToCodeField("invoicekind", Conn, "idinvkind", "codeinvkind",forcedsuffix,20)
                        .AddPrivateTranslator("description", new StringAppender(forcedsuffix, 50))
                .ShouldClearDestDB(first_dip)
                );
            CM.Add(new Copyer("invoice", Conn)
                       //.DefinesPreTranslator("ninv", CreateConditionalOffsetApplier("invoice", "ninv", diecimila * fattore,diecimila))
                       .SetExternalCode("idinvkind_real", "idinvkind")
                       //.SetExternalCode("ninv_real", "ninv")                       
            );
            CM.Add(new Copyer("invoicedetail", Conn)
                        .SetExternalCode("idupb_iva", "idupb")
                        .SetExternalCode("idexp_iva", "idexp")
                        .SetExternalCode("idexp_taxable", "idexp")
                        .SetExternalCode("idinc_iva", "idinc")
                        .SetExternalCode("idinc_taxable", "idinc")
                        .AllowNoTranslation("idinc_iva")
                        .AllowNoTranslation("idinc_taxable")
                        .AllowNoTranslation("idexp_iva")
                        .AllowNoTranslation("idexp_taxable")
                        //.SetExternalCode("ninv_main", "ninv")
                        );

            CM.Add(new Copyer("invoicekindyear", Conn).SkipDuplicates());
            CM.Add(new Copyer("invoicekindregisterkind", Conn)
                        .ShouldClearDestDB(first_dip) 
                        .SkipDuplicates()
            );
            CM.Add(new Copyer("invoicesorting", Conn).SkipOnNull("idsor"));
            CM.Add(new Copyer("invoicedeferred", Conn));


            CM.Add(new Copyer("ivapay", Conn)
                        .DefinesPreTranslator("nivapay", CreateConditionalOffsetApplier("ivapay", "nivapay", mille * fattore,mille)));
            CM.Add(new Copyer("ivapaydetail", Conn));
            CM.Add(new Copyer("ivapayexpense", Conn).SkipOnNull("idexp"));
            CM.Add(new Copyer("ivapayincome", Conn).SkipOnNull("idinc"));


            CM.Add(new AppendStringToCodeField("ivaregisterkind", Conn, "idivaregisterkind", "codeivaregisterkind", forcedsuffix, 20)                    
                                .ShouldClearDestDB(first_dip)
                                .AddPrivateTranslator("description", new StringAppender(suffix,50))    
                );

            CM.Add(new Copyer("ivaregister", Conn)
                   //.DefinesPreTranslator("nivaregister", CreateConditionalOffsetApplier("ivaregister", "nivaregister", diecimila * fattore,diecimila))
            );

            CM.Add(new Copyer("expensevar", Conn)
                            .SkipOnNull("idpayment")
                            .SkipOnNull("idexp")
                            .SetExternalCode("idpayment", "idexp")
                            .SetFilter(QHS.CmpGe("yvar",2006)));
            CM.Add(new Copyer("incomevar", Conn)
                                        .SetFilter(QHS.CmpGe("yvar",2006))
                                        .SkipOnNull("idinc")
             );
            CM.Add(new Copyer("expensesorted", Conn).SetExternalCode("paridsor", "idsor").SkipOnNull("idexp").SkipOnNull("idsor"));
            CM.Add(new Copyer("incomesorted", Conn).SetExternalCode("paridsor", "idsor").SkipOnNull("idinc").SkipOnNull("idsor"));
            CM.Add(new Copyer("expensetax", Conn).SkipOnNull("idexp"));
            CM.Add(new Copyer("expensetaxcorrige", Conn)
                .SkipOnNull("idexp")
                .SetExternalCode("linkedidexp","idexp")
                .AllowNoTranslation("linkedidexp")
                .SetExternalCode("linkedidinc","idinc")
                .AllowNoTranslation("linkedidinc")
            );
            CM.Add(new Copyer("expensetaxofficial", Conn)
                .SkipOnNull("idexp")
            );

            CM.Add(new Copyer("autoexpensesorting",Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
                        .SetExternalCode("idsorkindreg","idsorkind")
                        .SetExternalCode("idsorreg","idsor")
                        .SetFilter(QHS.CmpGe("ayear", 2006))
                        .SkipOnNull("idsor"));
            CM.Add(new Copyer("autoincomesorting", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
                        .SetExternalCode("idsorkindreg", "idsorkind")
                        .SetExternalCode("idsorreg", "idsor")
                        .SetFilter(QHS.CmpGe("ayear", 2006))
                        .SkipOnNull("idsor"));

            CM.Add(new Copyer("sortingapplicability", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty());

            CM.Add(new Copyer("sortingexpensefilter", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
                        .SetExternalCode("idsorkindreg", "idsorkind")
                        .SetExternalCode("idsorreg", "idsor")
                        .SetFilter(QHS.CmpGe("ayear", 2006))
                        .SkipOnNull("idsor"));

            CM.Add(new Copyer("sortingincomefilter", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
                        .SetExternalCode("idsorkindreg", "idsorkind")
                        .SetExternalCode("idsorreg", "idsor")
                        .SetFilter(QHS.CmpGe("ayear", 2006))
                        .SkipOnNull("idsor"));

            CM.Add(new Copyer("sortinglink", Conn)
                       .SetExternalCode("idparent","idsor")
                       .SetExternalCode("idchild", "idsor")
                       .ShouldClearDestDB(first_dip)
                       .SkipIfNotEmpty()
                       .SkipOnNull("idparent"));

            CM.Add(new Copyer("sortingprev", Conn)
                       .ShouldClearDestDB(first_dip)
                       .SkipIfNotEmpty()
                       .SetFilter(QHS.CmpGe("ayear", 2006))
                       .SkipOnNull("idsor"));


            CM.Add(new Copyer("sortingtranslation", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
                        .SetExternalCode("idsortingchild", "idsor")
                        .SetExternalCode("idsortingmaster", "idsor")
                        .SkipOnNull("idsortingchild")
                        .SkipOnNull("idsortingmaster")
            );

            //Non importiamo le sezioni
            //CM.Add(new Copyer("divisionsorting", Conn)
            //                .ShouldClearDestDB(first_dip)
            //            .SkipDuplicates()
            //);

            
            CM.Add(new Copyer("managersorting", Conn)
                            //.ShouldClearDestDB(first_dip)
                            .SkipOnNull("idsor")
                            .SkipOnNull("idman")
                        .SkipDuplicates()
            );



            CM.Add(new Copyer("iva_prorata", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
            );

            CM.Add(new Copyer("iva_mixed", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipIfNotEmpty()
            );



            CM.Add(new SurplusCopyer(Conn));

            CM.Add(new Copyer("autoclawbacksorting", Conn)
                        .ShouldClearDestDB(first_dip)
                        .SkipDuplicates()
                        .SetFilter(QHS.CmpGe("ayear", 2006))
                        .SkipOnNull("idsor"));

            CM.Add(new Copyer("taxpay", Conn)
                    .DefinesPreTranslator("ntaxpay", CreateConditionalOffsetApplier("taxpay", "ntaxpay", mille * fattore,mille*oldfactor)));

            CM.Add(new Copyer("taxpayexpense", Conn).SkipOnNull("idexp"));
            
            

           
            CM.Add(new Copyer("registrysorting", Conn)
                        .SkipDuplicates()
                        .SkipOnNull("idsor")
            );

            //NO!!! E' DBO!! CM.Add(new Copyer("commonconfig", Conn).ShouldClearDestDB(first_dip).SetFilter(QHS.CmpGe("ayear", 2006)));


            CM.Add(new Copyer("banktransaction", Conn)
                    .SetFilter(QHS.CmpGe("yban",2006))
                    .DefinesPreTranslator("nban", CreateConditionalOffsetApplier("banktransaction", "nban", diecimila * fattore,diecimila*oldfactor))
                    .SkipOnNull("idexp")
                    .SkipOnNull("idinc")
                    .SkipOnNull("kpay")
                    .SkipOnNull("kpro")

            );
                    
            //Aggiungiamo i compensi
            if (isAmministrazione) {


                //Compensi a dipendenti
                foreach (string t in new string[] { "wageaddition", "wageadditiontax", "wageadditionsorting",
                            "wageadditionyear"}) {
                    CM.Add(new Copyer(t, Conn).ShouldClearDestDB(true));

                }

                CM.Add(new Copyer("expensewageaddition", Conn)
                   .ShouldClearDestDB(true)
                   .SkipOnNull("idexp")
                 );

                //tabelle dbo
                foreach (string t in new string[] { "workingtime", "contractlength", "positionworkcontract" }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );

                }


                CM.Add(new Copyer("csa_contract", Conn).ShouldClearDestDB(true)
                        .SetExternalCode("idacc_main", "idacc")
                        .SetExternalCode("idexp_main", "idexp")
                        .SetExternalCode("idfin_main", "idfin")

                    );
                CM.Add(new Copyer("csa_contractkindyear", Conn).ShouldClearDestDB(true)
                        .SetExternalCode("idacc_main", "idacc")
                        .SetExternalCode("idfin_main", "idfin")

                    );
                CM.Add(new Copyer("csa_importver", Conn).ShouldClearDestDB(true)
                        .SetExternalCode("idfin_income", "idfin")
                        .SetExternalCode("idacc_debit", "idacc")
                        .SetExternalCode("idfin_expense", "idfin")
                        .SetExternalCode("idacc_expense", "idacc")
                        .SetExternalCode("idfin_incomeclawback", "idfin")
                        .SetExternalCode("idacc_internalcredit", "idacc")
                        //.SetExternalCode("idreg_agency", "idreg")
                        .SetExternalCode("idexp_cost", "idexp")
                        .SetExternalCode("idfin_cost", "idfin")
                        .SetExternalCode("idacc_cost", "idacc")


                    );
                CM.Add(new Copyer("csa_incomesetup", Conn).ShouldClearDestDB(true)
                        .SetExternalCode("idfin_income", "idfin")
                        .SetExternalCode("idacc_debit", "idacc")
                        .SetExternalCode("idfin_expense", "idfin")
                        .SetExternalCode("idacc_expense", "idacc")
                        .SetExternalCode("idfin_incomeclawback", "idfin")
                        .SetExternalCode("idacc_internalcredit", "idacc")
                        .SetExternalCode("idacc_revenue", "idacc")
                        .SetExternalCode("idacc_agency_credit", "idacc")


                    );
                

                foreach (string t in new string[] {
                    "csa_contracttax","csa_contractregistry","csa_contractkinddata"
                    }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );
                }

                //ho rimosso le dbo ed il resto è nell'istruz. precedente
                //foreach (string t in new string[] { "csa_agency", "csa_agencypaymethod", 
                //    "csa_contracttax","csa_contractkind","csa_contractkinddata","csa_contractkindrules","csa_contractregistry"    
                //    }) {
                //    CM.Add(new Copyer(t, Conn)
                //                .ShouldClearDestDB(true)
                //            );
                //}




                //Contratto professionale
                CM.Add(new Copyer("profservice", Conn).ShouldClearDestDB(true)
                       //.SetExternalCode("idaccmotivedebit", "idaccmotive")
                       //.SetExternalCode("idaccmotivedebit_crg", "idaccmotive")
                       //.SetExternalCode("idaccmotivedebit_datacrg", "idaccmotive")
                   );

                CM.Add(new Copyer("expenseprofservice", Conn)
                   .ShouldClearDestDB(true)
                   .SkipOnNull("idexp")
                 );

                foreach (string t in new string[] {  "profservicetax", "profservicesorting"  ,
                            "profrefund","profservicerefund"
                            
                    }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );
                }

               
                //Contratto Occasionale
                CM.Add(new Copyer("casualcontract", Conn).ShouldClearDestDB(true)
                        //.SetFilter(QHS.CmpGe("ycon", 2006))  superfluo, non ve ne sono
                        //.SetExternalCode("idaccmotivedebit", "idaccmotive")
                        //.SetExternalCode("idaccmotivedebit_crg", "idaccmotive")
                        //.SetExternalCode("idaccmotivedebit_datacrg", "idaccmotive")
                    );
                CM.Add(new Copyer("expensecasualcontract", Conn)
                  .ShouldClearDestDB(true)
                  .SkipOnNull("idexp")
                );

                foreach (string t in new string[] {  "casualcontractexemption", "casualcontracttax","casualcontracttaxbracket",
                                "casualcontractyear","casualcontractsorting",
                                "casualrefund","casualcontractrefund",
                                "casualdeduction","casualcontractdeduction"
                                


                    }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                                //.SetFilter(QHS.CmpGe("ycon", 2006))
                            );
                }

                //tabelle dbo
                foreach (string t in new string[] { "emenscontractkind","inpsactivity","otherinsurance",
                            "motive770service"}) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );

                }

               


                //Missioni
                CM.Add(new Copyer("itineration", Conn).ShouldClearDestDB(true)
                        //.SetFilter(QHS.CmpGe("yitineration", 2006))  superfluo, non ve ne sono
                       //.SetExternalCode("idaccmotivedebit", "idaccmotive")
                       //.SetExternalCode("idaccmotivedebit_crg", "idaccmotive")
                       //.SetExternalCode("idaccmotivedebit_datacrg", "idaccmotive")
                   );

                CM.Add(new Copyer("itinerationsorting", Conn)
                        .SkipDuplicates()
                        .SkipOnNull("idsor")
                );
                CM.Add(new Copyer("expenseitineration", Conn)
                 .ShouldClearDestDB(true)
                 .SkipOnNull("idexp")
               );
                foreach (string t in new string[] { "authagency", "itinerationauthagency","itinerationlap",
                            "itinerationtax","itinerationrefund","itinerationattachment"
                    }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                                //.SkipOnNull("iditineration")
                            );
                }
                //tabelle DBO
                foreach (string t in new string[] { "position","foreigncountry","reduction"
                        }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );

                }


                //Parasubordinati
                CM.Add(new Copyer("parasubcontract", Conn).ShouldClearDestDB(true)
                       //.SetExternalCode("idaccmotivedebit", "idaccmotive")
                       //.SetExternalCode("idaccmotivedebit_crg", "idaccmotive")
                       //.SetExternalCode("idaccmotivedebit_datacrg", "idaccmotive")
                   );

                CM.Add(new Copyer("parasubcontractsorting", Conn)
                       .SkipDuplicates()
                       .SkipOnNull("idsor")
               );
                CM.Add(new Copyer("expensepayroll", Conn)
                 .ShouldClearDestDB(true)
                 .SkipOnNull("idexp")
               );
                foreach (string t in new string[] { "otherinail", "payrollkind","matriculabook","pat",
                                "exhibitedcud","exhibitedcudabatement",
                                "abatableexpense","parasubcontractfamily", 
                                "payroll","payrolltax","payrolltaxcorrige","payrolltaxbracket","payrollabatement","parasubcontractyear",
                                "cafdocument",
                                "deduction","deductibleexpense","deductioncode","exhibitedcuddeduction","payrolldeduction"

                    }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );
                }
                //tabelle DBO
                foreach (string t in new string[] {  "abatement","abatementcode","affinity"
                                    //"otherinsurance","inpsactivity","emenscontractkind"   già presenti
                        }) {
                    CM.Add(new Copyer(t, Conn)
                                .ShouldClearDestDB(true)
                            );

                }


                //Aggiungere tabelle su conti EP, causali e via dicendo
                CM.Add(new Copyer("account", Conn)
                        .ShouldClearDestDB(true)
                        .DontCopy()
                        .DefinesPreTranslator("idacc", new set_to_null())
                    );

                CM.Add(new Copyer("accmotive", Conn)
                        .ShouldClearDestDB(true)
                        .DontCopy()
                        .DefinesPreTranslator("idaccmotive", new set_to_null())
                    );

                

                CM.Add(new Copyer("patrimony", Conn)
                      .ShouldClearDestDB(true)
                      .DontCopy()
                      .DefinesPreTranslator("idpatrimony", new set_to_null())
                  );

                CM.Add(new Copyer("placcount", Conn)
                      .ShouldClearDestDB(true)
                      .DontCopy()
                      .DefinesPreTranslator("idplaccount", new set_to_null())
                  );


               


                //Regole e controlli 
                CM.Add(new Copyer("audit", Conn)
                                        .ShouldClearDestDB(true));
                CM.Add(new Copyer("auditcheck", Conn)
                                        .ShouldClearDestDB(true));


                //Stampe ed esportazioni
                CM.Add(new Copyer("exportfunction", Conn)
                         .ShouldClearDestDB(true));
                CM.Add(new Copyer("exportfunctionparam", Conn)
                         .ShouldClearDestDB(true));
                CM.Add(new Copyer("report", Conn)
                         .ShouldClearDestDB(true));
                CM.Add(new Copyer("reportparameter", Conn)
                         .ShouldClearDestDB(true));
                CM.Add(new Copyer("reportadditionalparam", Conn)
                         .ShouldClearDestDB(true));


                //configurazioni
                CM.Add(new Copyer("config", Conn)
                        .SetFilter(QHS.CmpGe("ayear", 2006))
                        .ShouldClearDestDB(first_dip)
                        .SetExternalCode("idsortingkind1", "idsorkind")
                        .SetExternalCode("idsortingkind2", "idsorkind")
                        .SetExternalCode("idsortingkind3", "idsorkind")
                        .SetExternalCode("idacc_accruedcost", "idacc")
                        .SetExternalCode("idacc_accruedrevenue", "idacc")
                        .SetExternalCode("idacc_customer", "idacc")
                        .SetExternalCode("idacc_deferredcost", "idacc")
                        .SetExternalCode("idacc_deferredcredit", "idacc")
                        .SetExternalCode("idacc_deferreddebit", "idacc")
                        .SetExternalCode("idacc_deferredrevenue", "idacc")
                        .SetExternalCode("idacc_ivapayment", "idacc")
                        .SetExternalCode("idacc_ivarefund", "idacc")
                        .SetExternalCode("idacc_patrimony", "idacc")
                        .SetExternalCode("idacc_pl", "idacc")
                        .SetExternalCode("idacc_supplier", "idacc")
                        //.SetExternalCode("idaccmotive_admincar", "idaccmotive")
                        //.SetExternalCode("idaccmotive_foot", "idaccmotive")
                        //.SetExternalCode("idaccmotive_owncar", "idaccmotive")

                        .SetExternalCode("idfinexpense", "idfin")
                        .SetExternalCode("idfinexpensesurplus", "idfin")
                        .SetExternalCode("idfinincomesurplus", "idfin")
                        .SetExternalCode("idfinivapayment", "idfin")
                        .SetExternalCode("idfinivarefund", "idfin")
                        //.SetExternalCode("idivapayperiodicity", "idfin")

                        .SkipIfNotEmpty());

                CM.Add(new Copyer("accountingyear", Conn)
                       .SkipIfNotEmpty()
                       .ShouldClearDestDB(first_dip)
                       .SetFilter(QHS.CmpGe("ayear", 2006)));
                CM.Add(new Copyer("uniconfig", Conn)
                            .ShouldClearDestDB(first_dip)
                            .SkipIfNotEmpty());
                CM.Add(new Copyer("generalreportparameter", Conn)
                            .ShouldClearDestDB(first_dip)
                            .SkipIfNotEmpty());
                CM.Add(new Copyer("expensephase", Conn)
                            .SkipIfNotEmpty()
                            .ShouldClearDestDB(first_dip)
                );
                CM.Add(new Copyer("incomephase", Conn)
                            .SkipIfNotEmpty()
                            .ShouldClearDestDB(first_dip)
                );



            }



            //Per il primo che capita: copiamo l'anagrafica e tabelle correlate
            //NO: le tabelle dbo le copiamo preventivamente
            


            return CM;
        }

        Dictionary<string,translator> Tr= new Dictionary<string,translator>();
        
        CopyManager CM =null;
        const int  accoda=0;
        const int diecimila=10000;
        const int  mille=1000;
        const int cento = 100;



        bool ImportData(bool checkOnly, bool silent) {
            if (CM == null) CM = Get_CopyManager(Source, Dest, fattore,txtSourceDip.Text, chkSuffix.Checked,0);
            //Decidere cosa fare con le disposizioni di pagamento paydisposition, paydispositiondetail
            if (!silent) MessageBox.Show("CopyManager creato", "Informazione");

            CopyDisplay CD = new CopyDisplay(pBarCurrTab, txtSituazione);

            if (CM.CheckAll(CD)) {
                if (!silent) MessageBox.Show("Verifica effettuata", "Informazione");
                if (!checkOnly) {
                    //if (CM.CopyAll(CD)) {
                    //    CD = new CopyDisplay(pBarCurrTab, txtSituazione);
                    //    ExecuteFinalScripts(Dest,CD);
                    //}
                }
                return true;
            }
            else {
                MessageBox.Show("Errore nella creazione del CopyManager", "Errore");
                return false;
            }

        }

        //void ExecuteFinalScripts(DataAccess Dest,CopyDisplay CD) {
        //    string[] sql = new string[]{
        //        //"rebuild_all",

        //    };
        //    CD.Start("Esecuzione script di completamento");
        //    foreach (string S in sql) {
        //        CD.Start(".", S, 1);
        //        Dest.DO_SYS_CMD(S);
        //        CD.Stop(true);
        //    }
        //    MessageBox.Show("Esecuzione script completata");

        //}
        private void btnCopia_Click(object sender, EventArgs e) {
            btnCopia.Visible = false;
            if (CM == null) return;
            CopyDisplay CD = new CopyDisplay(pBarCurrTab, txtSituazione);
            CM.CopyAll(CD);
            MessageBox.Show("Copia completata.", "Informazione");
            //btnCopia.Visible = true;
        }
        
        
       
       
        translator CreateLookupTraslator(string table, string codefield, string keyfield) {
            return CreateLookupTraslator(table, codefield, keyfield, null);
        }

        lookup_translator CreateLookupTraslator(string table, string codefield, string keyfield, string filter) {
            lookup_translator LTR = new lookup_translator(table, codefield, keyfield);
            LTR.initialize(Source, Dest, filter);
            txtSituazione.Text += LTR.ToString() + "\r\n";
            return LTR;

        }

        base_lookup_translator CreateBaseLookupTraslator(string table, string source_codefield, string dest_codefield, string keyfield) {
            return CreateBaseLookupTraslator(table, source_codefield, dest_codefield, keyfield, null);
        }

        base_lookup_translator CreateBaseLookupTraslator(string table, string source_codefield, string dest_codefield, 
                            string keyfield, string filter) {
            base_lookup_translator LTR = new base_lookup_translator(table, source_codefield, dest_codefield, keyfield);
            LTR.initialize(Source, Dest, filter);
            txtSituazione.Text += LTR.ToString() + "\r\n";
            return LTR;

        }
        conditional_offset_applier CreateConditionalOffsetApplier(string table, string field, int offset, int threeshold) {
            return CreateConditionalOffsetApplier(table, field, offset, null, threeshold);
        }

        conditional_offset_applier CreateConditionalOffsetApplier(string table, string field, int offset, string filter, int threeshold) {
            conditional_offset_applier AP = new conditional_offset_applier(table, field, threeshold);
            AP.initialize(Source, Dest, offset, filter);
            txtSituazione.Text += AP.ToString() + "\r\n";
            Application.DoEvents();
            return AP;
        }

        offset_applier CreateOffsetApplier(string table, string field, int offset) {
            return CreateOffsetApplier(table, field, offset, null);
        }

        offset_applier CreateOffsetApplier(string table, string field, int offset, string filter) {
            offset_applier AP = new offset_applier(table, field);
            AP.initialize(Source, Dest, offset,filter);
            txtSituazione.Text += AP.ToString() + "\r\n";
            Application.DoEvents();
            return AP;
        }

        public void EseguiMigrazioneBatch() {
            tabController.SelectedIndex = 2;
            btnBack.Visible = false;
            btnNext.Visible = false;

            QueryHelper QHS = Conn.GetQueryHelper();
            string superuser = txtSuperUser.Text;
            string superpwd = txtSuperPwd.Text;
            EasyDepManager EDM = new EasyDepManager(Conn);
            //Crea tutti i dipartimenti che servono
            CopyDisplay CD = new CopyDisplay(pBarCurrTab, txtSituazione);

            //foreach (string depname in new string[] { "amministrazione" }) {
            //    if (Conn.RUN_SELECT_COUNT("dbaccess", QHS.CmpEq("iddbdepartment", depname), false) > 0) {
            //        CD.Comment("Dipartimento " + depname + " presente.\r\n");
            //        continue;
            //    }
            //    CD.Comment("Creo il dipartimento " + depname + "\r\n");
            //    bool res = EDM.BatchCreateDepartment(superuser, superpwd, depname, depname.ToUpper(), depname);
            //    if (!res) {
            //        MessageBox.Show("Errore nella creazione del dipartimento " + depname);
            //        return;
            //    }
            //}

            List<string> DepProcessed = new List<string>();

            /*
                "lettere|disum|1", "umanistici|disum|2",
                "medicina|dimet|6", "mediclinica|dimet|7",
                "farmacia|disfar|9", "farmaco|disfar|10", 
                "facecon|disei|3","impreter|disei|4","scienzeeco|disei|5",
                "giurispru|digspes|15","giuridic|digspes|16","scienzepol|digspes|17","ricsoc|digspes|18","polpubb|digspes|19",
                "scienzemfn|disit|11","informatica|disit|12","tecnoavan|disit|13","scienzevita|disit|14"
            */

            string destserver = Conn.GetSys("server").ToString();
            string destdatabase = Conn.GetSys("database").ToString();

            foreach (string assoc in new string[]{
                "disum|amministrazione|20|1",
                "disei|amministrazione|21|3",
                "disfar|amministrazione|22|9", 
                "dimet|amministrazione|23|6", 
                "digspes|amministrazione|24|15",
                "diss|amministrazione|25|0",
                "disit|amministrazione|26|11",
                "cespa|amministrazione|28|0",
                "amministrazione|amministrazione|29|0"
            }) {

                string[] par = assoc.Split('|');
                string source = par[0];
                string dest = par[1];
                int fattore = CfgFn.GetNoNullInt32(par[2]);
                int old_min_factor = CfgFn.GetNoNullInt32(par[3]);


                bool appendsuffix = true;
                if (source == "disum" || source == "dimet" || source == "disfar" || source == "disei" || source == "digspes"
                            || source == "disit") {
                    appendsuffix = false;
                }

                
                CD.Comment("Copio il dip. " + source + " nel gruppo " + dest + " con ordinale " + fattore.ToString() + "\r\n");

                string sourceserver = Conn.GetSys("server").ToString();
                string sourcedatabase = Conn.GetSys("database").ToString();
                if (txtSourceServer.Text.Trim() != "") sourceserver = txtSourceServer.Text.Trim();
                if (txtSourceDataBase.Text.Trim() != "") sourcedatabase = txtSourceDataBase.Text.Trim();
                string errore;
                string dettaglio;
                string errore2;
                string dettaglio2;
                string realsource = source;
                if (realsource == "diss") realsource = "scienzemed";
                Source = Easy_DataAccess.getEasyDataAccess("Source DB", sourceserver, sourcedatabase,
                                            superuser, superpwd, realsource,
                                    Convert.ToInt32(Conn.GetSys("esercizio")),
                                    Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore, out dettaglio);


                Dest = Easy_DataAccess.getEasyDataAccess("Source DB", destserver, destdatabase,
                                   superuser, superpwd, dest,
                                  Convert.ToInt32(Conn.GetSys("esercizio")),
                                  Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore2, out dettaglio2);
                if (Source == null || errore != null) {
                    QueryCreator.ShowError(this, errore, dettaglio);
                    if (Dest != null) Dest.Destroy();
                    return;
                }
                if (Dest == null || errore2 != null) {
                    QueryCreator.ShowError(this, errore2, dettaglio2);
                    Source.Destroy();
                    return;
                }

                if (!Source.Open()) {
                    Source.Destroy();
                    Source = null;
                    MessageBox.Show(this, "Non è stato possibile collegarsi al dip. di origine " + txtSourceDip.Text.Trim());
                    return;
                }
                if (!Dest.Open()) {
                    Source.Close();
                    Source.Destroy();
                    Source = null;

                    Dest.Destroy();
                    Dest = null;
                    MessageBox.Show(this, "Non è stato possibile collegarsi al dip. di destinazione " + txtDipDestinazione.Text.Trim());
                    return;
                }

                int nmov = Dest.RUN_SELECT_COUNT("expense", QHS.Between("nmov", fattore * 10000, fattore * 10000 + 2000), false);
                if (nmov > 0) {
                    CD.Comment("Dipartimento con ordinale " + fattore + " già presente. Dipartimento " + source + " saltato.\r\n");                    
                    continue;
                }
                if (!DepProcessed.Contains(dest)) DepProcessed.Add(dest);

                CM = Get_CopyManager(Source, Dest, fattore,source,appendsuffix,old_min_factor);


                if (!CM.CheckAll(CD)) {
                    MessageBox.Show("Errore nella creazione del CopyManager", "Errore");
                    return;
                }
                CD.Comment("Verifica di " + source + " completata\r\n");
                if (!CM.CopyAll(CD)) {
                    MessageBox.Show("Errore durante la copia di " + source);
                    return;
                }
                CD.Comment("Abilito gli utenti\r\n");

                Easy_DataAccess ED = Easy_DataAccess.getEasyDataAccess("Dest DB", destserver, destdatabase,
                                   superuser, superpwd, dest,
                                  Convert.ToInt32(Conn.GetSys("esercizio")),
                                  Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore2, out dettaglio2);
                    


                DataTable Utenti = Conn.RUN_SELECT("dbaccess", "*", null, null, null, false);
                Utenti.CaseSensitive=false;
                CQueryHelper QHC = new CQueryHelper();
                foreach(DataRow SourceUser in Utenti.Select(QHC.CmpEq("iddbdepartment",source))){
                    errore = "";
                    if (Utenti.Select(QHC.AppAnd(QHC.CmpEq("iddbdepartment", dest), QHC.CmpEq("login", SourceUser["login"]))).Length == 0) {
                        ED.linkUserToDepartment(SourceUser["login"].ToString(), out errore);
                        if (errore != null && errore != "")
                            CD.Comment("Errore aggiungendo l'utente " + SourceUser["login"].ToString() + ":" + errore + "\r\n");
                    }
                }
                CD.Comment("Utenti aggiunti\r\n");
                ED.Close();
                ED.Destroy();

                Source.Close();
                Source.Destroy();

                Dest.Close();
                Dest.Destroy();

            }

            foreach (string depname in DepProcessed) {
                CD.Comment("Ricompilo le regole per il dipartimento " + depname + "\r\n");
                string errore3, dettaglio3;
                Easy_DataAccess ED = Easy_DataAccess.getEasyDataAccess("Dest DB", destserver, destdatabase,
                                   superuser, superpwd, depname,
                                  Convert.ToInt32(Conn.GetSys("esercizio")),
                                  Convert.ToDateTime(Conn.GetSys("datacontabile")), out errore3, out dettaglio3);
                    


                Meta_EasyDispatcher ME = new Meta_EasyDispatcher(ED);
                MetaData Meta = ME.Get("config"); //uno vale l'altro
                string filterrules = Meta.GetSys("filterrule").ToString();
                DataTable TT = ED.SQLRunner("SELECT DISTINCT objectname  from customobject where isreal='S' order by objectname");
                string err;
                CD.Start(depname, "ricompilazione regole", TT.Rows.Count);
                foreach (DataRow R in TT.Rows) {
                    Application.DoEvents();
                    string curr = R["objectname"].ToString();
                    err = EasyAudits.RecalcAudit(ED, curr, "I", filterrules);
                    err = EasyAudits.RecalcAudit(ED, curr, "U", filterrules);
                    err = EasyAudits.RecalcAudit(ED, curr, "D", filterrules);
                    CD.Update(1);
                }
                CD.Stop(true);
                ED.SQLRunner("delete from sptocompile where " + QHS.CmpNe("opkind", 'M'), false);


                DateTime inizio = DateTime.Now;
                CD.Comment("Ricalcolo i totali per il gruppo " + depname + " fnizio: "+inizio.ToShortTimeString());
                ED.CallSP("rebuild_all",new object[]{},false,100000);
                DateTime fine = DateTime.Now;
                CD.Comment("Ricalcolo i totali per il gruppo " + depname + " fine: " + fine.ToShortTimeString() );
                CD.Comment("Elapsed time  for " + depname + " : " + ((TimeSpan)fine.Subtract(inizio)).ToString());
                ED.Close();
                ED.Destroy();
                    
            }









            MessageBox.Show("Copia completata con successo.", "Informazione");


        }

        private void btnFaiTutto_Click(object sender, EventArgs e) {
            EseguiMigrazioneBatch();
        }

        

        
    }

   
  

   


    

  
   
}