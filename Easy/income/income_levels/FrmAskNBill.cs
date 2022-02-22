
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
using metadatalibrary;


namespace income_levels {
    public partial class FrmAskNBill : MetaDataForm {
        bool AbilitaAggiornamento = false;
        DataTable Bollette;

        public FrmAskNBill(DataTable BillView) {
            InitializeComponent();
            this.Bollette = BillView;
            gridBollette.DataBindings.Clear();
            HelpForm.SetDataGrid(gridBollette, Bollette);
            AbilitaAggiornamento = true;

        }
        private void selezioneRigheCambiata() {
            if (!AbilitaAggiornamento) return;
            CurrencyManager cm = (CurrencyManager)gridBollette.BindingContext[Bollette.DataSet, gridBollette.DataMember];
            DataView view = cm.List as DataView;
            if (view == null) {
                return;
            }
            string elenco = "";
            for (int i = 0; i < view.Count; i++) {
                if (gridBollette.IsSelected(i)) {
                    elenco += "," + view[i]["nbill"];
                }
            }

            if (elenco != "") elenco = elenco.Remove(0, 1);


            bool esisteSelezione = elenco != "";
            btnOk.Enabled = esisteSelezione;

            txtBollette.Text = elenco;
        }

        private void gridBollette_MouseClick(object sender, MouseEventArgs e) {
            selezioneRigheCambiata();
        }

        private void gridBollette_CurrentCellChanged(object sender, EventArgs e) {
            selezioneRigheCambiata();
        }
    }
}
