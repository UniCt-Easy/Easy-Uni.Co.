
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


using metadatalibrary;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AskCurrencyExchange {
    public partial class FrmAskCurrencyExchange : Form {
        private readonly string stringValueFormat;
        private readonly DataTable currencyexchange;
        private readonly string codecurrency;

        public string Rate { get; set; }
        public FrmAskCurrencyExchange(IDataAccess conn, DataRow entity, string visualizationFormat) {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;

            stringValueFormat = visualizationFormat;

            var QHS = conn.GetQueryHelper();
            currencyexchange = conn.RUN_SELECT("currencyexchange", "*", "referencedate", QHS.CmpEq("idcurrency", entity["idcurrency"]), null, true);
            codecurrency = conn.DO_READ_VALUE("currency", QHS.CmpEq("idcurrency", entity["idcurrency"]), "codecurrency").ToString();

            Text = string.Format("Tassi medi giornalieri {0} -> EUR", codecurrency.ToString());

            listViewCurrencyExchange.View = View.Details;
            listViewCurrencyExchange.FullRowSelect = true;
            listViewCurrencyExchange.MultiSelect = false;

            listViewCurrencyExchange.Columns.Add("Data");
            listViewCurrencyExchange.Columns.Add("Tasso");

            listViewCurrencyExchange.DoubleClick += new EventHandler(buttonOk_Click);

            dateTimePickerFrom.Value = dateTimePickerFrom.Value.AddMonths(-1);
        }

        private void UpdateListView() {

            listViewCurrencyExchange.Items.Clear();
            listViewCurrencyExchange.Items.AddRange(currencyexchange.AsEnumerable()
                .Where(row => (DateTime)row["referencedate"] >= dateTimePickerFrom.Value.Date && dateTimePickerTo.Value.Date >= (DateTime)row["referencedate"])
                .Select(row => {
                    var date = row["referencedate"];
                    var rate = row["eurocurrencyrate"];

                    ListViewItem item = new ListViewItem(((DateTime)date).ToString("D")) { Tag = row };
                    item.SubItems.Add(HelpForm.StringValue(rate, stringValueFormat));

                    return item;
                })
                .ToArray());

            if (listViewCurrencyExchange.Items.Count == 0) {

                listViewCurrencyExchange.Hide();
                txtWarning.Text = string.Format("Nessun dato disponibile per {0} nell'intervallo selezionato", codecurrency);
                txtWarning.Show();
                buttonOk.Enabled = false;

                return;
            }

            listViewCurrencyExchange.Show();
            txtWarning.Hide();
            buttonOk.Enabled = true;

            listViewCurrencyExchange.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            listViewCurrencyExchange.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void dateTimePickerFrom_ValueChanged(object sender, EventArgs e) {
            UpdateListView();
        }

        private void dateTimePickerTo_ValueChanged(object sender, EventArgs e) {
            UpdateListView();
        }

        private void buttonOk_Click(object sender, EventArgs e) {

            if (listViewCurrencyExchange.SelectedItems.Count < 1) {
                Rate = null;
                DialogResult = DialogResult.Cancel;
            } else {
                Rate = HelpForm.StringValue(((DataRow)listViewCurrencyExchange.SelectedItems[0].Tag)["eurocurrencyrate"], stringValueFormat);
                DialogResult = DialogResult.OK;
            }

            Close();
        }
    }
}
