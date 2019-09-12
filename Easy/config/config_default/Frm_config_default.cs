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


namespace config_default
{
    public partial class Frm_config_default : Form
    {
        public MetaData Meta;
        public Frm_config_default()
        {
            InitializeComponent();
            CanGoEdit = true;
            HelpForm.SetDenyNull(DS.config.Columns["proceeds_flag"], true);
            HelpForm.SetDenyNull(DS.config.Columns["payment_flag"], true);
            // ASSET
            HelpForm.SetDenyNull(DS.config.Columns["asset_flagrestart"], true);
            HelpForm.SetDenyNull(DS.config.Columns["assetload_flag"], true);
            HelpForm.SetDenyNull(DS.config.Columns["linktoinvoice"], true);
            // BANKDIDISPOSITIONnell
            HelpForm.SetDenyNull(DS.config.Columns["electronictrasmission"], true);
            HelpForm.SetDenyNull(DS.config.Columns["electronicimport"], true);
            // CASUALCONTRACT
            HelpForm.SetDenyNull(DS.config.Columns["casualcontract_flagrestart"], true);
            // PROFSERVICE
            HelpForm.SetDenyNull(DS.config.Columns["profservice_flagrestart"], true);
            // BOOKING
            HelpForm.SetDenyNull(DS.config.Columns["booking_on_invoice"], true);
            DataAccess.SetTableForReading(DS.account_customer, "account");
            DataAccess.SetTableForReading(DS.account_supplier, "account");
            DataAccess.SetTableForReading(DS.account_ivapayment, "account");
            DataAccess.SetTableForReading(DS.account_invoicetoemit, "account");
            DataAccess.SetTableForReading(DS.account_invoicetoreceive, "account");
            DataAccess.SetTableForReading(DS.account_ivarefund, "account");
            DataAccess.SetTableForReading(DS.account_accruedcost, "account");
            DataAccess.SetTableForReading(DS.account_accruedrevenue, "account");
            DataAccess.SetTableForReading(DS.account_deferredcost, "account");
            DataAccess.SetTableForReading(DS.account_deferredrevenue, "account");
            DataAccess.SetTableForReading(DS.account_pl, "account");
            DataAccess.SetTableForReading(DS.account_pat, "account");
            DataAccess.SetTableForReading(DS.account_economic_result, "account");
            DataAccess.SetTableForReading(DS.account_previous_economic_result, "account");
            DataAccess.SetTableForReading(DS.account_unabatable_rimborso, "account");
            DataAccess.SetTableForReading(DS.account_unabatable_versamento, "account");
            DataAccess.SetTableForReading(DS.account_mainunabatable_rimborso, "account");
            DataAccess.SetTableForReading(DS.account_mainunabatable_versamento, "account");

            DataAccess.SetTableForReading(DS.account_mainivapayment, "account");
            DataAccess.SetTableForReading(DS.account_mainivapayment_internal, "account");
            DataAccess.SetTableForReading(DS.account_mainivarefund, "account");
            DataAccess.SetTableForReading(DS.account_mainivarefund_internal, "account");

            DataAccess.SetTableForReading(DS.account_ivapayment12, "account");
            DataAccess.SetTableForReading(DS.account_ivarefund12, "account");
            DataAccess.SetTableForReading(DS.account_mainivapayment_internal12, "account");
            DataAccess.SetTableForReading(DS.account_mainivapayment12, "account");
            DataAccess.SetTableForReading(DS.account_mainivarefund_internal12, "account");
            DataAccess.SetTableForReading(DS.account_mainivarefund12, "account");
            DataAccess.SetTableForReading(DS.account_revenue_gross_csa, "account");

            DataAccess.SetTableForReading(DS.account_split_ivapayment, "account");
            DataAccess.SetTableForReading(DS.account_unabatable_split, "account");

            DataAccess.SetTableForReading(DS.account_bankpaydoc, "account");
            DataAccess.SetTableForReading(DS.account_bankprodoc, "account");

            HelpForm.SetDenyNull(DS.config.Columns["flagepexp"], true);
            // EXPENSESETUP
            DataAccess.SetTableForReading(DS.sortingkind1, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind2, "sortingkind");
            DataAccess.SetTableForReading(DS.sortingkind3, "sortingkind");
            HelpForm.SetDenyNull(DS.config.Columns["automanagekind"], true);
            // FINSETUP
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagcredit"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagproceeds"], true);
            // FIN
            DataAccess.SetTableForReading(DS.fin_income_gross_csa, "finview");
            DataAccess.SetTableForReading(DS.fin_store, "finview");
          
            // INVOICE
            DataAccess.SetTableForReading(DS.bilancioversamento, "finview");
            DataAccess.SetTableForReading(DS.bilanciorimborso, "finview");

            DataAccess.SetTableForReading(DS.creddebrimborso, "registry");
            DataAccess.SetTableForReading(DS.creddebversamento, "registry");

            DataAccess.SetTableForReading(DS.mainbilancioversamento, "finview");
            DataAccess.SetTableForReading(DS.mainbilanciorimborso, "finview");
            
            DataAccess.SetTableForReading(DS.maincreddebrimborso, "registry");
            DataAccess.SetTableForReading(DS.maincreddebversamento, "registry");

            //IVA SPLIT
            DataAccess.SetTableForReading(DS.mainbilancioversamentosplit, "finview");
            DataAccess.SetTableForReading(DS.maincreddebversamentosplit, "registry");


            // IVA INTRA
            DataAccess.SetTableForReading(DS.bilanciorimborso12, "finview");
            DataAccess.SetTableForReading(DS.bilancioversamento12, "finview");

            DataAccess.SetTableForReading(DS.creddebversamento12, "registry");
            DataAccess.SetTableForReading(DS.creddebrimborso12, "registry");

            DataAccess.SetTableForReading(DS.mainbilancioversamento12, "finview");
            DataAccess.SetTableForReading(DS.mainbilanciorimborso12, "finview");

            DataAccess.SetTableForReading(DS.maincreddebrimborso12, "registry");
            DataAccess.SetTableForReading(DS.maincreddebversamento12, "registry");
            DataAccess.SetTableForReading(DS.registry_csa, "registry");

            DataAccess.SetTableForReading(DS.accmotive_grantdeferredcost, "accmotive");
            DataAccess.SetTableForReading(DS.accmotive_grantrevenue, "accmotive");


            HelpForm.SetDenyNull(DS.config.Columns["flagrefund"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagpayment"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagpaymentsplit"], true);
            HelpForm.SetDenyNull(DS.config.Columns["mainflagrefund"], true);
            HelpForm.SetDenyNull(DS.config.Columns["mainflagpayment"], true);
            HelpForm.SetDenyNull(DS.config.Columns["mainflagrefund12"], true);
            HelpForm.SetDenyNull(DS.config.Columns["mainflagpayment12"], true);

            HelpForm.SetDenyNull(DS.config.Columns["flagrefund12"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagpayment12"], true);
            HelpForm.SetDenyNull(DS.config.Columns["deferredexpensephase"], true);
            HelpForm.SetDenyNull(DS.config.Columns["deferredincomephase"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flag"], true);
            DataAccess.SetTableForReading(DS.bilanciospesa, "finview");
            DataAccess.SetTableForReading(DS.accmotiveapplied_admincar, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_owncar, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_foot, "accmotiveapplied");

            DataAccess.SetTableForReading(DS.accmotiveapplied_forwarder, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_assetrevenue, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_prorata_cost, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_prorata_revenue, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.incomephase1, "incomephase");
            DataAccess.SetTableForReading(DS.expensephase1, "expensephase");
            DataAccess.SetTableForReading(DS.finlevel1, "finlevel");

            DataAccess.SetTableForReading(DS.paymethodabi, "paymethod");
            DataAccess.SetTableForReading(DS.paymethodnoabi, "paymethod");

            //DEFAULT COORD. ANALITICHE FATTTURE MAGAZZINO
            DataAccess.SetTableForReading(DS.sorting1, "sorting");
            DataAccess.SetTableForReading(DS.sorting2, "sorting");
            DataAccess.SetTableForReading(DS.sorting3, "sorting");

            DataAccess.SetTableForReading(DS.sortingincomecsa, "sorting");

            //WAGEADDITION
            HelpForm.SetDenyNull(DS.config.Columns["wageaddition_flagrestart"], true);

            cmbIDpayABI.DataSource = DS.paymethodabi;
            cmbIDpayABI.ValueMember = "idpaymethod";
            cmbIDpayABI.DisplayMember = "description";

            cmbIdpayNOABI.DataSource = DS.paymethodnoabi;
            cmbIdpayNOABI.ValueMember = "idpaymethod";
            cmbIdpayNOABI.DisplayMember = "description";

            cmbInpsCenter.DataSource = DS.inpscenter;
            cmbInpsCenter.DisplayMember = "title";
            cmbInpsCenter.ValueMember = "idinpscenter";

            HelpForm.SetDenyNull(DS.config.Columns["finvarofficial_default"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagivapaybyrow"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagivaregphase"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagiva_immediate_or_deferred"], true);
            HelpForm.SetDenyNull(DS.config.Columns["mainflagivaregphase"], true);

            HelpForm.SetDenyNull(DS.config.Columns["default_idfinvarstatus"], true);
            HelpForm.SetDenyNull(DS.config.Columns["flagbank_grouping"], true);

            HelpForm.SetDenyNull(DS.config.Columns["flagbalance_csa"], true);
            HelpForm.SetDenyNull(DS.config.Columns["csa_nominativo"], true);
            HelpForm.SetDenyNull(DS.config.Columns["csa_flagtransmissionlinking"], true);
            HelpForm.SetDenyNull(DS.config.Columns["csa_flag"], true);

            HelpForm.SetDenyNull(DS.config.Columns["flagenabletransmission"], true);

            // INVOICE
            HelpForm.SetDenyNull(DS.config.Columns["flagsplitpayment"], true);

        }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

            string filteresercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));

            int numrighe = Meta.Conn.RUN_SELECT_COUNT("config", filteresercizio, true);
            if (numrighe == 1)
            {
                CanGoInsert = false;
                CanGoEdit = true;
            }
            else
            {
                CanGoInsert = true;
                CanGoEdit = false;
            }
            GetData.SetStaticFilter(DS.config, filteresercizio);
            //GetData.SetStaticFilter(DS.configview, filteresercizio);
            GetData.SetStaticFilter(DS.finlevel, filteresercizio);
            GetData.SetStaticFilter(DS.finlevel1, filteresercizio);
            // entry
            GetData.SetStaticFilter(DS.account_customer, filteresercizio);
            GetData.SetStaticFilter(DS.account_supplier, filteresercizio);
            GetData.SetStaticFilter(DS.account_ivapayment, filteresercizio);
            GetData.SetStaticFilter(DS.account_ivarefund, filteresercizio);
            GetData.SetStaticFilter(DS.account_accruedcost, filteresercizio);
            GetData.SetStaticFilter(DS.account_accruedrevenue, filteresercizio);
            GetData.SetStaticFilter(DS.account_deferredcost, filteresercizio);
            GetData.SetStaticFilter(DS.account_deferredrevenue, filteresercizio);
            GetData.SetStaticFilter(DS.account_unabatable_rimborso, filteresercizio);
            GetData.SetStaticFilter(DS.account_unabatable_versamento, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainunabatable_rimborso, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainunabatable_versamento, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivapayment, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivapayment_internal, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivarefund, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivarefund_internal, filteresercizio);
            GetData.SetStaticFilter(DS.account_revenue_gross_csa, filteresercizio);
          
            // IVA INTRA
            GetData.SetStaticFilter(DS.account_ivapayment12, filteresercizio);
            GetData.SetStaticFilter(DS.account_ivarefund12, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivapayment_internal12, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivapayment12, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivarefund_internal12, filteresercizio);
            GetData.SetStaticFilter(DS.account_mainivarefund12, filteresercizio);

            //IVA SPLIT
            GetData.SetStaticFilter(DS.account_split_ivapayment, filteresercizio);
            GetData.SetStaticFilter(DS.account_unabatable_split, filteresercizio);


            GetData.SetStaticFilter(DS.account_pl, filteresercizio);
            GetData.SetStaticFilter(DS.account_pat, filteresercizio);
            GetData.SetStaticFilter(DS.account_invoicetoemit, filteresercizio);
            GetData.SetStaticFilter(DS.account_invoicetoreceive, filteresercizio);
            GetData.SetSorting(DS.pccdebitstatus, "listingorder asc");

            //expense
            DS.expensephase.ExtendedProperties["sort_by"] = "nphase";
            object MinFaseSpesa = Meta.GetSys("expenseregphase");
            string filterperfasecredspesa = QHS.CmpGe("nphase", MinFaseSpesa);
            GetData.SetStaticFilter(DS.expensephase, filterperfasecredspesa);
            //GetData.SetStaticFilter(DS.finlevel, QHS.AppAnd(filteresercizio, QHS.CmpEq("flagusable", 'S')));
            //GetData.SetStaticFilter(DS.finlevel, QHS.AppAnd(filteresercizio, QHS.BitSet("flag", 1)));
            GetData.SetSorting(DS.finlevel, "nlevel");
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["payment_flagautoprintdate"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagautopayment"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagpcashautopayment"], true);
            //fin

            object MinFaseBilEntrata = Meta.GetSys("incomefinphase");
            string filterperfaseentrata = QHS.CmpGe("nphase", MinFaseBilEntrata);

            object MinFaseBilSpesa = Meta.GetSys("expensefinphase");
            string filterperfasespesa = QHS.CmpGe("nphase", MinFaseBilSpesa);

            DS.incomephase.ExtendedProperties["sort_by"] = "nphase";
            DS.expensephase.ExtendedProperties["sort_by"] = "nphase";

            GetData.SetStaticFilter(DS.incomephase, filterperfaseentrata);
            GetData.SetStaticFilter(DS.expensephase, filterperfasespesa);
            //income
            DS.incomephase.ExtendedProperties["sort_by"] = "nphase";
            object MinFaseEntrata = Meta.GetSys( "incomeregphase");
            string filterperfasecredentrata = QHS.CmpGe("nphase", MinFaseEntrata);
            GetData.SetStaticFilter(DS.incomephase, filterperfasecredentrata);
            //GetData.SetStaticFilter(DS.finlevel, QHS.AppAnd(filteresercizio, QHS.CmpEq("flagusable", 'S')));
            //GetData.SetStaticFilter(DS.finlevel, QHS.AppAnd(filteresercizio, QHS.BitSet("flag", 1)));
            GetData.SetSorting(DS.finlevel, "nlevel");
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["proceeds_flagautoprintdate"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagautoproceeds"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagdirectcsaclawback"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["flagpcashautoproceeds"], true);
   
            //invoice
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["invoice_flagregister"], true);
   
            //GetData.SetStaticFilter(DS.invoicesetupview, filteresercizio);
            string filter = GetData.MergeFilters(filteresercizio, QHS.CmpEq("idupb", "0001"));
            string fInc = QHS.BitClear("flag", 0);
            string fExp = QHS.BitSet("flag", 0);
            GetData.SetStaticFilter(DS.bilanciorimborso, QHS.AppAnd(filter, fInc));
            GetData.SetStaticFilter(DS.bilancioversamento, QHS.AppAnd(filter, fExp));
            GetData.SetStaticFilter(DS.bilanciorimborso12, QHS.AppAnd(filter, fInc));
            GetData.SetStaticFilter(DS.bilancioversamento12, QHS.AppAnd(filter, fExp));

            GetData.SetStaticFilter(DS.mainbilanciorimborso, QHS.AppAnd(filter, fInc));
            GetData.SetStaticFilter(DS.mainbilancioversamento, QHS.AppAnd(filter, fExp));
            GetData.SetStaticFilter(DS.mainbilanciorimborso12, QHS.AppAnd(filter, fInc));
            GetData.SetStaticFilter(DS.mainbilancioversamento12, QHS.AppAnd(filter, fExp));

            GetData.SetStaticFilter(DS.mainbilancioversamentosplit, QHS.AppAnd(filter, fExp));


            GetData.SetStaticFilter(DS.fin_income_gross_csa, QHS.AppAnd(filter, fInc));
            GetData.SetStaticFilter(DS.fin_store, QHS.AppAnd(filter, fExp));
            //itinerationsetup
            //GetData.SetStaticFilter(DS.itinerationsetupview, filter);

            //CSA
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["csa_flaggroupby_income"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["csa_flaggroupby_expense"], true);
            HelpForm.SetDenyNull(DS.Tables["config"].Columns["csa_flaglinktoexp"], true);
         
            //filter = GetData.MergeFilters(filter, QHS.CmpEq("idupb", "0001"));
            GetData.SetStaticFilter(DS.bilanciospesa, QHS.AppAnd(filter, fExp));

            SetGBoxClassCsa();
            //spese anticipate da spedizioniere
            string filterEpOperation = QHS.IsNull("idepoperation");
            DS.accmotiveapplied_forwarder.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_forwarder, filterEpOperation);
            DS.accmotiveapplied_admincar.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_admincar, filterEpOperation);
            DS.accmotiveapplied_owncar.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_owncar, filterEpOperation);
            DS.accmotiveapplied_foot.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_foot, filterEpOperation);
            DS.accmotiveapplied_assetrevenue.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_assetrevenue, filterEpOperation);
            DS.accmotiveapplied_prorata_cost.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_prorata_cost, filterEpOperation);
            DS.accmotiveapplied_prorata_revenue.ExtendedProperties[MetaData.ExtraParams] = filterEpOperation;
            GetData.SetStaticFilter(DS.accmotiveapplied_prorata_revenue, filterEpOperation);
            Meta.StartFilter = filteresercizio;

            Meta.SearchEnabled = false;
            Meta.CanInsertCopy = false;
            Meta.CanInsert = false;
            Meta.CanCancel = false;
            PostData.MarkAsTemporaryTable(DS.Tables["appkind"], false);

            fillWageImportAppName();
            setComboStipendi();
            SetFilterCoordStock();
            string filterAliquotaEsente = QHC.CmpEq("rate", 0);
            GetData.SetStaticFilter(DS.ivakind, filterAliquotaEsente);
            int esercizio = CfgFn.GetNoNullInt32(Meta.Conn.GetSys("esercizio"));
            if (esercizio >= 2018) {
                // codici Siope 2018
                DataAccess.SetTableForReading(DS.sorting_siopeivaexp, "sorting");
                DataAccess.SetTableForReading(DS.sorting_siopeiva12exp, "sorting");
                DataAccess.SetTableForReading(DS.sorting_siopeivasplitexp, "sorting");
                DataAccess.SetTableForReading(DS.sorting_siopeivainc, "sorting");
                DataAccess.SetTableForReading(DS.sorting_siopeiva12inc, "sorting");
                object idsorkindS = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopespese")), "idsorkind");
                object idsorkindE = Meta.Conn.DO_READ_VALUE("sortingkind", QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate")), "idsorkind");
                GetData.SetStaticFilter(DS.sorting_siopeivaexp, QHS.CmpEq("idsorkind", idsorkindS));
                GetData.SetStaticFilter(DS.sorting_siopeiva12exp, QHS.CmpEq("idsorkind", idsorkindS));
                GetData.SetStaticFilter(DS.sorting_siopeivainc, QHS.CmpEq("idsorkind", idsorkindE));
                GetData.SetStaticFilter(DS.sorting_siopeiva12inc, QHS.CmpEq("idsorkind", idsorkindE));
                GetData.SetStaticFilter(DS.sorting_siopeivasplitexp, QHS.CmpEq("idsorkind", idsorkindS));
            }
            else {
                grpBoxSiopeEPspeseSplit.Visible = false;
                grpBoxSiopeEPspese.Visible = false;
                grpBoxSiopeEPspese12.Visible = false;
                grpBoxSiopeEPentrate.Visible = false;
                grpBoxSiopeEPentrate12.Visible = false;
            }
        }

        object GetCtrlByName (string Name) {
            System.Reflection.FieldInfo Ctrl = this.GetType().GetField(Name);
            if (Ctrl == null) return null;
            return Ctrl.GetValue(this);
        }

        void SetGBoxClass (int num, object sortingkind) {
            if (sortingkind == DBNull.Value) {
                GroupBox G = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                G.Visible = false;
            }
            else {
                string filter = QHS.CmpEq("idsorkind", sortingkind);
                GetData.SetStaticFilter(DS.Tables["sorting" + num.ToString()], filter);
                GroupBox gboxclass = (GroupBox)GetCtrlByName("gboxclass" + num.ToString());
                Button btnCodice = (Button)GetCtrlByName("btnCodice" + num.ToString());
                gboxclass.Visible = true;
                gboxclass.Tag = "AutoManage.txtCodice" + num.ToString() + ".tree." + filter;
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filter, "description").ToString();
                gboxclass.Text = title;
                btnCodice.Tag = "manage.sorting" + num.ToString() + ".tree." + filter;
                DS.Tables["sorting" + num.ToString()].ExtendedProperties[MetaData.ExtraParams] = filter;
            }
        }

        void SetGBoxClassCsa()
        {
            string filterSiopeE = QHS.CmpEq("codesorkind", Meta.GetSys("codesorkind_siopeentrate"));
             DataTable tSortingkindE = Meta.Conn.RUN_SELECT("sortingkind", "*", null, filterSiopeE, null, null, true);

            if ((tSortingkindE != null) && (tSortingkindE.Rows.Count > 0))
            {
                DataRow RE = tSortingkindE.Rows[0];
                object idsorkindE = RE["idsorkind"];

                string filterE = QHS.CmpEq("idsorkind", idsorkindE);
                GetData.SetStaticFilter(DS.sortingincomecsa, filterE);
                string title = Meta.Conn.DO_READ_VALUE("sortingkind", filterE, "description").ToString();

                grpSiopeEntrata.Text = title + " per Lordi negativi";
                grpSiopeEntrata.Tag = "AutoManage.txtSiopeEntrataInt.tree." + filterE;
                btnSiopeEntrata.Tag = "manage.sortingincomecsa.tree." + filterE;

            }
        }
        void SetFilterCoordStock() {
            string filterEsercizio = QHS.CmpEq("ayear", Meta.GetSys("esercizio"));
            DataTable tSetup = Meta.Conn.RUN_SELECT("config", "*", null,
                filterEsercizio, null, null, true);
            if ((tSetup != null) && (tSetup.Rows.Count > 0)) {
                DataRow RSetup = tSetup.Rows[0];
                object idsorkind1 = RSetup["idsortingkind1"];
                object idsorkind2 = RSetup["idsortingkind2"];
                object idsorkind3 = RSetup["idsortingkind3"];
                SetGBoxClass(1, idsorkind1);
                SetGBoxClass(2, idsorkind2);
                SetGBoxClass(3, idsorkind3);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value && idsorkind3 == DBNull.Value) {
                    grpCoordMagazzino.Visible = false;
                }
            }
        }

        
        public void MetaData_AfterRowSelect (DataTable T, DataRow R) {
            if (Meta.IsEmpty) return;
            DataRow Curr =  DS.config.Rows[0];
            if (T.TableName == "sortingkind1" && Meta.DrawStateIsDone) {
                txtCodice1.Text = "";
                txtDenom1.Text = "";
                Curr["idsor1_stock"] = DBNull.Value;
                if (R == null) {
                    SetGBoxClass(1, DBNull.Value);
                }
                else {
                    SetGBoxClass(1, R["idsorkind"]);
                }
            }
            if (T.TableName == "sortingkind2" && Meta.DrawStateIsDone) {
                txtCodice2.Text = "";
                txtDenom2.Text = "";
                Curr["idsor2_stock"] = DBNull.Value;
              
                if (R == null) {
                    SetGBoxClass(2, DBNull.Value);
                }
                else {
                    SetGBoxClass(2, R["idsorkind"]);
                }
            }
            if (T.TableName == "sortingkind3" && Meta.DrawStateIsDone) {
                txtCodice3.Text = "";
                txtDenom3.Text = "";
                Curr["idsor3_stock"] = DBNull.Value;
              
                if (R == null) {
                    SetGBoxClass(3, DBNull.Value);
                }
                else {
                    SetGBoxClass(3, R["idsorkind"]);
                }
            }
            if ( cmbClass1.SelectedIndex <=0 &&
                 cmbClass2.SelectedIndex <=0 &&
                 cmbClass3.SelectedIndex <=0 ) {
                grpCoordMagazzino.Visible = false;
            }
            else {
                grpCoordMagazzino.Visible = true;
            }
            if (T.TableName == "chargehandling" && Meta.DrawStateIsDone) {
 
                if (R != null) {
                    if (LeggiFlagEsenteBancaPredefinita()) {
                        int flag_exemption = (CfgFn.GetNoNullInt32(R["flag"]) & 1);
                        chkEsenteSpese.Checked = !((flag_exemption & 1) == 0);
                    }

                }
            }
        }
        private bool LeggiFlagEsenteBancaPredefinita() {
            DataTable tTreasurer = Meta.Conn.RUN_SELECT("treasurer", "*", null, QHS.AppAnd(QHS.CmpEq("flagdefault", "S"), QHS.BitSet("flag", 1)), null, false);
            if (tTreasurer.Rows.Count == 0) return false;
            else
                return true;
        }
        private void fillWageImportAppName() {
            addRow("", "");
            addRow("CINECA", "Importazione da CINECA");
            addRow("SPT", "Importazione da S.P.T.");
            
            DS.appkind.AcceptChanges();
        }

        private void addRow(string code, string descr) {
            DataRow rWageImportAppName = DS.appkind.NewRow();
            rWageImportAppName["code"] = code;
            rWageImportAppName["description"] = descr;
            DS.appkind.Rows.Add(rWageImportAppName);
        }

        private void setComboStipendi() {
            cboStipendi.DataSource = DS.appkind;
            cboStipendi.DisplayMember = "description";
            cboStipendi.ValueMember = "code";
            cboStipendi.Tag = "config.wageimportappname";
        }

        public void MetaData_AfterClear()
        {
            if (CanGoInsert)
            {
                CanGoInsert = false;
                MetaData.DoMainCommand(this, "maininsert");
            }
            if (CanGoEdit)
            {
                CanGoEdit = false;
                MetaData.DoMainCommand(this, "maindosearch.default"); //edyttype associato
            }
          
        }

        public void MetaData_BeforeFill () {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.config.Rows[0];
         
            if (Curr["idsortingkind1"] == DBNull.Value && 
                Curr["idsortingkind2"] == DBNull.Value && 
                Curr["idsortingkind3"] == DBNull.Value) {
                grpCoordMagazzino.Visible = false;
            }
            else {
                grpCoordMagazzino.Visible = true;
            }
        }
        public void MetaData_AfterFill(){
            AbilitaBottoni(rdoTipoBuono.Checked);

        }

        private void AbilitaBottoni(bool enable)
        {
            chkReset.Enabled = !enable;
        }

        private void rdoUnica_CheckedChanged(object sender, System.EventArgs e)
        {
            AbilitaBottoni(rdoTipoBuono.Checked);
        }

        private void rdoTipoInv_CheckedChanged(object sender, System.EventArgs e)
        {
            AbilitaBottoni(rdoTipoBuono.Checked);
        }

        private void rdoEnte_CheckedChanged(object sender, System.EventArgs e)
        {
            AbilitaBottoni(rdoTipoBuono.Checked);
        }

        private void rdoTipoBuono_CheckedChanged(object sender, System.EventArgs e)
        {
            AbilitaBottoni(rdoTipoBuono.Checked);
        }
        private void btnProgramma_Click(object sender, System.EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DialogResult res = dlgSceltaProgramma.ShowDialog(this);
            if (res != DialogResult.OK) return;
            DS.config.Rows[0]["appname"] = dlgSceltaProgramma.FileName;
            txtProgramma.Text = dlgSceltaProgramma.FileName;
        }

        private void btnProgrImport_Click(object sender, System.EventArgs e)
        {
            if (Meta.IsEmpty) return;
            DialogResult res = dlgSceltaProgramma.ShowDialog(this);
            if (res != DialogResult.OK) return;
            DS.config.Rows[0]["importappname"] = dlgSceltaProgramma.FileName;
            txtProgrammaImport.Text = dlgSceltaProgramma.FileName;
        }

        private void rdbAutomatica_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbAutomaticaOccasionali.Checked)
            {
                chkAzzeraOccasionali.Enabled = true;
            }
        }

        private void rdbManuale_CheckedChanged(object sender, System.EventArgs e)
        {
            if (rdbManualeOccasionali.Checked)
            {
                chkAzzeraOccasionali.Checked = false;
                chkAzzeraOccasionali.Enabled = false;
            }
        }

       

        private void ckbFlagBilancio_CheckStateChanged(object sender, System.EventArgs e)
        {
            if (ckbFlagBilancio.Checked)
                cmbLivelloBil_Spesa.Enabled = true;
            else
                cmbLivelloBil_Spesa.Enabled = false;
        }

        private void ckbRevLimitaBilancio_CheckStateChanged(object sender, System.EventArgs e)
        {
            cmbLivelloBil_Entrata.Enabled = ckbRevLimitaBilancio.Checked;
        }

        private void rdbAutomaticaDipendenti_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAutomaticaDipendenti.Checked)
            {
                chkAzzeraDipendenti.Enabled = true;
            }
        }

        private void rdbManualeDipendenti_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManualeDipendenti.Checked)
            {
                chkAzzeraDipendenti.Checked = false;
                chkAzzeraDipendenti.Enabled = false;
            }
        }

        private void rdbAutomaticaProfessionali_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAutomaticaProfessionali.Checked)
            {
                chkAzzeraProfessionali.Enabled = true;
            }
        }

        private void rdbManualeProfessionali_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManualeProfessionali.Checked)
            {
                chkAzzeraProfessionali.Checked = false;
                chkAzzeraProfessionali.Enabled = false;
            }
        }

        private void rdbAutomaticaOccasionali_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAutomaticaOccasionali.Checked)
            {
                chkAzzeraOccasionali.Enabled = true;
            }
        }

        private void rdbManualeOccasionali_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbManualeOccasionali.Checked)
            {
                chkAzzeraOccasionali.Checked = false;
                chkAzzeraOccasionali.Enabled = false;
            }
        }



        private void chkNoAutoTax_CheckStateChanged(object sender, EventArgs e) {
            if (chkNoAutoTax.CheckState != CheckState.Checked) return;
            chkRitenMovEntrata.Checked = false;
            chkRitenuteCreaVariazione.Checked = false;
        }

        private void chkRitenMovEntrata_CheckStateChanged(object sender, EventArgs e) {
            if (chkRitenMovEntrata.CheckState != CheckState.Checked) return;
            chkNoAutoTax.Checked = false;
            chkRitenuteCreaVariazione.Checked = false;
        }

        private void chkRitenuteCreaVariazione_CheckStateChanged(object sender, EventArgs e) {
            if (chkRitenuteCreaVariazione.CheckState != CheckState.Checked) return;
            chkNoAutoTax.Checked = false;
            chkRitenMovEntrata.Checked = false;

        }

        private void chkContrib0_CheckStateChanged(object sender, EventArgs e) {
            if (chkContrib0.CheckState != CheckState.Checked) return;
            chkContr1.Checked = false;
            chkContrib2.Checked = false;
            chkContrib3.Checked = false;
        }

        private void chkContr1_CheckedChanged(object sender, EventArgs e) {
            if (chkContr1.CheckState != CheckState.Checked) return;
            chkContrib0.Checked = false;
            chkContrib2.Checked = false;
            chkContrib3.Checked = false;

        }

        private void chkContrib2_CheckedChanged(object sender, EventArgs e) {
            if (chkContrib2.CheckState != CheckState.Checked) return;
            chkContrib0.Checked = false;
            chkContr1.Checked = false;
            chkContrib3.Checked = false;

        }

        private void chkContrib3_CheckedChanged(object sender, EventArgs e) {
            if (chkContrib3.CheckState != CheckState.Checked) return;
            chkContrib0.Checked = false;
            chkContr1.Checked = false;
            chkContrib2.Checked = false;

        }

        private void groupBox11_Enter(object sender, EventArgs e) {

        }
    }
}