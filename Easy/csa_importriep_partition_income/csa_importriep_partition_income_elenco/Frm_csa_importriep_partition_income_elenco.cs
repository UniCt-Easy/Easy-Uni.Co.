
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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AskInfo;
using metadatalibrary;
using funzioni_configurazione;


namespace csa_importriep_partition_income_elenco {
    public partial class Frm_csa_importriep_partition_income_elenco : MetaDataForm {
        MetaData Meta;
        DataAccess Conn;
        public Frm_csa_importriep_partition_income_elenco() {
            InitializeComponent();
            }

        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            GetData.CacheTable(DS.incomephase,null, "nphase", true);

            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.CanCancel = false;
            DataAccess.SetTableForReading(DS.Tables["registry_main"], "registry");
            GetData.SetStaticFilter(DS.csa_import, QHS.CmpEq("yimport", Conn.GetEsercizio()));

        }

        public void MetaData_AfterFill() {
            VisualizzaMovimentoEntrata();
            enableControls(false);
        }

        public void MetaData_AfterClear() {
            enableControls(true);
            txtEsercImport.Text = Conn.GetEsercizio().ToString();

        }

        private void enableControls(bool abilita) {
            bool readOnly = !abilita;
            gboxEntrata.Enabled = abilita;
            groupCredDeb.Enabled = abilita;
            gBoxAnagraficaRiep.Enabled = abilita;
            grpMatricola.Enabled = abilita;
            gboxtipo.Enabled = abilita;
            gBoxCapitoloCSA.Enabled = abilita;
            gBoxCompetenza.Enabled = abilita;
            //gBoxDettaglio.Enabled = abilita;
            //gBoxImportazione.Enabled = abilita;
            gBoxImporto.Enabled = abilita;
           // gBoxRiepilogo.Enabled = abilita;
            //txtQuota.ReadOnly = readOnly;
            //txtEsercizio.ReadOnly = readOnly;
            //txtVoceCsa.ReadOnly = readOnly;
        }



        private void VisualizzaMovimentoEntrata() {
            if (MetaData.Empty(this)) return;
            //Calcola e riempie i campi relativi alla fase precedente:
            object idinc = DS.Tables["csa_importriep_partition_income"].Rows[0]["idinc"];
            string filter = QHS.CmpEq("idinc", idinc);
            DataTable DT = Conn.RUN_SELECT("income", "idinc,ymov,nmov,nphase", null, filter, null, true);
            if (DT.Rows.Count == 0) return;
            txtEserc.Text = DT.Rows[0]["ymov"].ToString();
            txtNum.Text = DT.Rows[0]["nmov"].ToString();
            cmbFaseEntrata.SelectedValue = DT.Rows[0]["nphase"];
        }

        
    }
}




       
