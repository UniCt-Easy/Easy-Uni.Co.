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

namespace admpay_assessment_choose {
    public partial class Frm_AdmPay_Assessment_Choose : Form {
        DataTable Accertamento;
        MetaData Meta;
        DataSet DS;
        public DataRow Choosen;
        public Frm_AdmPay_Assessment_Choose(DataTable ListaAccertamenti, MetaData Parent) {
            InitializeComponent();
            this.Text = "Scelta dell'Accertamento";
            this.Meta = Parent;
            this.Accertamento = ListaAccertamenti;
            this.DS = Accertamento.DataSet;

            MetaData MAccertamento = Meta.Dispatcher.Get("admpay_assessmentview");
            MAccertamento.DescribeColumns(Accertamento, "default");
            HelpForm.SetDataGrid(dgAccertamenti, Accertamento);
            formatgrids FGAccertamento = new formatgrids(dgAccertamenti);
            FGAccertamento.AutosizeColumnWidth();
        }

        private DataRow selezioneRiga() {
            string dataMember = dgAccertamenti.DataMember;
            CurrencyManager cm = (CurrencyManager)dgAccertamenti.BindingContext[DS, dataMember];
            DataView view = cm.List as DataView;
            if (view == null) return null;
            int rigaSelezionata = getRigaSelezionata(view);
            if (rigaSelezionata == -1) return null;
            DataRowView rChoosenView = view[rigaSelezionata];
            // Attenzione filtro solo x nappropriation in quanto tutte le impegnative
            // hanno gli altri 2 campi che compongono la chiave uguali
            CQueryHelper QHC = new CQueryHelper();
            string filtro = QHC.CmpEq("nassessment", rChoosenView["nassessment"]);
            DataRow[] rChoosen = Accertamento.Select(filtro);
            return (rChoosen.Length > 0) ? rChoosen[0] : null;
        }

        private int getRigaSelezionata(DataView view) {
            for (int i = 0; i < view.Count; i++) {
                if (dgAccertamenti.IsSelected(i)) {
                    return i;
                }
            }
            return -1;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            Choosen = selezioneRiga();
        }

        private void dgAccertamenti_DoubleClick(object sender, EventArgs e) {
            Choosen = selezioneRiga();
            this.DialogResult = (Choosen != null) ? DialogResult.OK : DialogResult.Cancel;
            this.Close();
        }
    }
}