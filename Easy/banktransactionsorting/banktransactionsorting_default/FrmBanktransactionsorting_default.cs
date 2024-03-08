
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace banktransactionsorting_default {
    public partial class FrmBanktransactionsorting_default : MetaDataForm {
        
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        string filtroTipoMov;
        public FrmBanktransactionsorting_default() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            string filterCT = QHS.CmpEq("tablename", "banktransaction");
            DataTable t = DataAccess.RUN_SELECT(Meta.Conn, "sortingapplicability", null, null, filterCT, null, null, true);
            string filtroSorting = QHC.FieldIn("idsorkind", t.Select());
            DataRow rBankTransaction = Meta.SourceRow.Table.DataSet.Tables["banktransaction"].Rows[0];
            bool isSpesa = rBankTransaction["idexp"] != DBNull.Value;
            bool isEntrata = rBankTransaction["idinc"] != DBNull.Value;
            if (isSpesa && !isEntrata) {
                filtroTipoMov = "(movkind='S')";
            }
            if (isEntrata && !isSpesa) {
                filtroTipoMov = "(movkind='E')";
            }
            GetData.SetStaticFilter(DS.sortingapplicabilityview, filtroSorting);

            string filterActive = QHS.DoPar(QHS.AppOr(QHS.NullOrEq("active", 'S'), QHS.CmpEq("active", "")));
            string filterI = QHS.DoPar(QHS.AppOr(QHS.DoPar(QHS.AppAnd(QHS.NullOrLe("start", Meta.GetSys("esercizio")),
                    QHS.NullOrGe("stop", Meta.GetSys("esercizio")), filterActive, filterCT)), QHS.CmpEq("idsorkind", 0)));

            QueryCreator.SetFilterForInsert(DS.sortingapplicabilityview, filterI);
        }
        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (T != DS.sortingapplicabilityview) return;

            if (Meta.InsertMode) {
                decimal importo = calcolaImporto(Meta.SourceRow, QHC.CmpEq("idsorkind", cmbTipo.SelectedValue));
                txtImporto.Text = importo.ToString("c");
            }
            if (MetaData.GetMetaData(this).DrawState == MetaData.form_drawstates.done) {
                if ((!MetaData.Empty(this))) {
                    DS.banktransactionsorting.Rows[0]["idsor"] = 0;
                }
                txtCodice.Text = "";
                txtDescrizione.Text = "";
                DS.sorting.Clear();
            }
            SetCodice();
        }

        void SetCodice() {
            if (Meta.EditMode) return;
            btnCodice.Enabled = (cmbTipo.SelectedIndex > 0);
            txtCodice.ReadOnly = (cmbTipo.SelectedIndex <= 0);
            if (cmbTipo.SelectedIndex <= 0) {
                txtCodice.Text = "";
                txtDescrizione.Text = "";
            }
            else {
                string filter = QHS.CmpEq("idsorkind", cmbTipo.SelectedValue);
                if (filtroTipoMov != null) {
                    filter = QHS.AppAnd(filter, filtroTipoMov);
                }
                DataTable tSorting = DataAccess.RUN_SELECT(Meta.Conn, "sorting", null, null, filter, null, null, true);
                btnCodice.Tag = "manage.sorting.tree." + filter;
                //label per il form di selezione della voce di classificazione +"."+ filtro
                DS.sorting.ExtendedProperties[MetaData.ExtraParams] = tSorting;//  filter;
                //AutoManage.txtCodiceClass.tree
                gboxclass.Tag = "AutoManage.txtCodice.tree." + filter;
                MetaData.GetMetaData(this).SetAutoMode(gboxclass);
            }
        }

        private decimal calcolaImporto(DataRow rBankTransactionSorting, string filtroSuSorting) {
            DataRow rBankTransaction = rBankTransactionSorting.Table.DataSet.Tables["banktransaction"].Rows[0];
            decimal importo = CfgFn.GetNoNullDecimal(rBankTransaction["amount"]);
            DataRow[] rSorting = DS.sorting.Select(filtroSuSorting);
            string filtro = QHC.FieldIn("idsor", DS.sorting.Select(filtroSuSorting));
            object objImporto = rBankTransactionSorting.Table.Compute("sum(amount)", filtro);
            return importo - CfgFn.GetNoNullDecimal(objImporto);
        }

        public void MetaData_AfterFill() {
            SetCodice();
        }
    }
}
