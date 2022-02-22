
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using metadatalibrary;
using metaeasylibrary;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;
using funzioni_configurazione;
using Microsoft.Office.Interop.Excel;
using Button = System.Windows.Forms.Button;
using DataTable = System.Data.DataTable;
using GroupBox = System.Windows.Forms.GroupBox;
using TextBox = System.Windows.Forms.TextBox;

namespace funzioni_configurazione {
    public class siope_helper {
        private siope_finder siopeFinder;
        TextBox txtCodice;
        TextBox txtDenominazione;
        Button btnSiope;
        GroupBox grpBoxSiopeEP;
        bool spese;
        DataTable sorting_siope;
        private DataAccess conn;
        private MetaData meta;
        private QueryHelper qhs;
        private string lastCodice;
        private string newcomputesorting = "N";
        private Form mainForm;
        public siope_helper(Form F, TextBox txtCodice, TextBox txtDenominazione, Button btnSiope, GroupBox grpBoxSiopeEP, bool spese, DataTable sorting_siope) {
            this.txtCodice = txtCodice;
            this.txtDenominazione = txtDenominazione;
            this.btnSiope = btnSiope;
            this.grpBoxSiopeEP = grpBoxSiopeEP;
            this.spese = spese;
            this.sorting_siope = sorting_siope;
            this.mainForm = F;
            meta = MetaData.GetMetaData(F);
            conn = meta.Conn;
            qhs = conn.GetQueryHelper();
            //SIOPE_U_18 SIOPE_E_18
            DataAccess.SetTableForReading(sorting_siope, "sorting");
            string codesorkind =
                spese ? "SIOPE_U_18" : "SIOPE_E_18";
            object idsorkind = CfgFn.GetNoNullInt32( conn.DO_READ_VALUE("sortingkind", qhs.CmpEq("codesorkind", codesorkind), "idsorkind"));                
            GetData.SetStaticFilter(sorting_siope, qhs.CmpEq("idsorkind", idsorkind));


            btnSiope.Tag = "";
            siopeFinder  = new siope_finder(conn);
            if (btnSiope != null) {
                btnSiope.Click += ButtonSiope_Click;
            }
            txtCodice.Tag = $"{sorting_siope.TableName}.sortcode?x";
            txtCodice.Enabled = true;
            txtCodice.ReadOnly = false;
            grpBoxSiopeEP.Tag = $"AutoChoose.{txtCodice.Name}.tree";

            object o = conn.DO_READ_VALUE("siopekind", qhs.CmpEq("ayear", conn.GetEsercizio()), "newcomputesorting");
            if (o != null && o != DBNull.Value) newcomputesorting = o.ToString().ToUpper();

        }


        /// <summary>
        /// Imposta il filtro per la selezione della class. siope in base alle righe ammesse passate in input
        /// </summary>
        /// <param name="siopeRows"></param>
        void setFilterSiope(DataRow []siopeRows) {
            if (siopeRows == null || siopeRows.Length == 0) {
                clearFilterSiope();
                return;
            }
            
            MetaData.AutoInfo AI = meta.GetAutoInfo(txtCodice.Name);
            string listaIdsor = qhs.DistinctVal(siopeRows, "idsor");
            string filteridsor = qhs.FieldInList("idsor", listaIdsor);
            AI.startfilter = filteridsor;
           
        }
        void clearFilterSiope() {
            MetaData.AutoInfo AI = meta.GetAutoInfo(txtCodice.Name);           
            AI.startfilter = null;
        }

        void SetIdSiope(object idsor_siope) {
            meta.SetAutoField(idsor_siope, txtCodice);
        }
       
        /// <summary>
        /// Assegna il campo idsor_siope della riga della tabella principale in base alla eventuale selezione dell'utente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSiope_Click(object sender, EventArgs e) {           
            if (idCurrentAccmotive==DBNull.Value || idCurrentAccmotive==null || (newcomputesorting == "N")) {
                clearFilterSiope();
                meta.DoMainCommand("manage.sorting_siope.tree");
                return;
            }
            if(!meta.IsEmpty) meta.GetFormData(true);
                   
            object idsor = selectSiope();
            if (idsor != DBNull.Value && meta.PrimaryDataTable.Rows.Count>0) {
                meta.PrimaryDataTable.Rows[0]["idsor_siope"] = idsor;
            }
            if (!meta.IsEmpty) meta.FreshForm();
        }

        void fillSiopeControls( DataRow rSiopeSorting) {
            if (rSiopeSorting == null) {
                //Ho cancellato la causale, azzero il siope.
                txtCodice.Text = "";
                txtDenominazione.Text = "";
                SetIdSiope(DBNull.Value);
                return;
            }
            else {
                txtCodice.Text = rSiopeSorting["sortcode"].ToString();
                txtDenominazione.Text = rSiopeSorting["description"].ToString();
                SetIdSiope(rSiopeSorting["idsor"]);
            }
        }


        private object idCurrentAccmotive = DBNull.Value;

        /// <summary>
        /// Acquisisce la causale EP corrente per le future ricerche
        ///  andrebbe richiamata nell'afterclear con DBNull, nell'afterfill con l'idaccmotive della riga corrente
        /// </summary>
        /// <param name="idaccmotive"></param>
        public void setCausaleEPCorrente(object idaccmotive) {
            idCurrentAccmotive = idaccmotive;
            if ((idaccmotive == null) || idaccmotive == DBNull.Value) {                
                clearFilterSiope();
                return;
            }
            DataRow[] rClass = siopeFinder.getSiopeForAccmotive(idaccmotive, spese);
            setFilterSiope(rClass);
        }

        /// <summary>
        /// Data una causale EP imposta la  class. siope associata aggiornando anche i txt relativi e riempiendo/svuotando la tabella sorting_siope.
        /// Qualora non ci siano class.siope associate, restituisce DBNull e non fa nulla.
        /// Se ve n'è una sola, la seleziona, se ve ne sono di più le fa scegliere a video
        /// </summary>
        /// <param name="curr"></param>
        /// <param name="idaccmotive"></param>
        /// <param name="faiscegliere"></param>
        /// <returns>idsor della class.siope</returns>
        public object selectSiope( ) {
            if (newcomputesorting == "N") {
                return DBNull.Value;
            }

            if ((idCurrentAccmotive==null)|| idCurrentAccmotive == DBNull.Value) {
                //E' dubbio se dovrebbe svuotarlo
                //fillSiopeControls(null);
                //fillSortingTable(sorting_siope, null);
                clearFilterSiope();
                return DBNull.Value;
            }
           
            DataRow [] rClass = siopeFinder.getSiopeForAccmotive(idCurrentAccmotive,spese);
            setFilterSiope(rClass);
            if (rClass == null || rClass.Length==0) {
                 //Il messaggio compare solo se si clicca il Button
                 MetaFactory.factory.getSingleton<IMessageShower>().Show(mainForm,"Nessuna classificazione siope associata alla causale", "Avviso");
                //E' dubbio se dovrebbe svuotarlo
                //fillSiopeControls(null);
                //fillSortingTable(sorting_siope, null);
                clearFilterSiope();
                return DBNull.Value;
            }
            
            int countClassSiope = rClass.Length;
            if (countClassSiope == 1) {
                DataRow rAccmotivesortingview = rClass[0];
                string filteridsor = qhs.CmpEq("idsor", rAccmotivesortingview["idsor"]);
                DataTable tSorting = conn.RUN_SELECT("sorting", "idsor,sortcode,description", null, filteridsor, null,
                    false);

                DataRow rSorting = tSorting.Rows[0];
                fillSiopeControls(rSorting);
                fillSortingTable(sorting_siope, rSorting["idsor"]);
                return rSorting["idsor"];
            }
            if ((countClassSiope > 1) ){
                string VistaScelta = "sortingview";
                MetaData msortingview = meta.Dispatcher.Get(VistaScelta);
                msortingview.FilterLocked = true;
                msortingview.DS = meta.DS;
                string listaIdsor = qhs.DistinctVal(rClass, "idsor");
                string filteridsor = qhs.AppAnd(qhs.CmpEq("ayear", conn.GetEsercizio()), qhs.FieldInList("idsor", listaIdsor));
                bool SceltaNonEffettuata = true;
                while (SceltaNonEffettuata) {
                    DataRow rSortingview = msortingview.SelectOne("default", filteridsor, null, null);
                    if (rSortingview != null) {
                        SceltaNonEffettuata = false;
                        fillSiopeControls(rSortingview);
                        fillSortingTable(sorting_siope, rSortingview["idsor"]);
                        return rSortingview["idsor"];
                    }
                    if (SceltaNonEffettuata) {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(mainForm, "E' necessario selezionare una classificazione siope associata alla causale", "Avviso");
                    }
                }
            }
            
            fillSiopeControls(null);
            fillSortingTable(sorting_siope, null);
                        
            return DBNull.Value;
        }

        private void fillSortingTable(DataTable sorting_siope, object idsor) {
            sorting_siope.Clear();
            if (idsor == null || idsor==DBNull.Value)return;
            DataAccess.RUN_SELECT_INTO_TABLE(meta.Conn, sorting_siope, null, qhs.CmpEq("idsor", idsor), null, true);
        }

    }
}
