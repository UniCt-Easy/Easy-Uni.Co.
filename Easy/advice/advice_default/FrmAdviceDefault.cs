
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
using Cronos;

namespace advice_default {
    public partial class FrmAldviceDefault : MetaDataForm {
        MetaData Meta;
        public FrmAldviceDefault() {
            InitializeComponent();
        }
        public void MetaData_AfterLink () {
            bool IsAdmin = false;

            Meta = MetaData.GetMetaData(this);
            if (Meta.GetSys("FlagMenuAdmin") != null)
                IsAdmin = (Meta.GetSys("FlagMenuAdmin").ToString() == "S");
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
            GetData.SetSorting(DS.advice, "adate desc");
        }

        private void genCrontab_Click(object sender, EventArgs e) {

            using (var form = new FrmCrontabGen()) {

                createForm(form, null);
                var result = form.ShowDialog();

                if (result == DialogResult.OK) {
                    txtCrontab.Text = form.Crontab;
                }
            }
        }

        private void btnTestCrontabGen_Click(object sender, EventArgs e) {

            try {
                DateTimeOffset start = new DateTimeOffset(DateTime.SpecifyKind(DateTime.Parse(textBox2.Text), DateTimeKind.Local));
                DateTimeOffset stop = new DateTimeOffset(DateTime.SpecifyKind(DateTime.Parse(txtStopdate.Text), DateTimeKind.Local));

                if (start > stop) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show("Le date di inizio e fine non sono compatibili", "Attenzione");
                    return;
                }

                var summary = new FrmCrontabSummary(start, stop, txtCrontab.Text);
                createForm(summary, null);
                summary.Show();
            }
            catch (Exception) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("La schedulazione non sarà applicata in quanto le date non sono valide", "Attenzione");
                return;
            }
        }
    }
}
