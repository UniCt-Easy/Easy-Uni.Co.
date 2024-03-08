
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


using CurrencyManager;
using HelpWeb;
using metadatalibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace AskCurrencyExchange {
    public static class UiHelper {
        public static void UpdateControls(Manager currencyManager, TextBox txtExchange, /*Button btnCurrencyExchange,*/ /*IDataAccess conn,*/ DataRow entity, params string[] dateStrings) {

            if (entity == null) return;
            if (entity["idcurrency"] == DBNull.Value) return;

            uint previousDays = 7;
            int idCurrency = entity.Field<int>("idcurrency");
            string codeCurrency = currencyManager.GetCodeCurrency(idCurrency);

            if (codeCurrency == currencyManager.ReferenceCurrency.ToString()) return;

            //var QHS = conn.GetQueryHelper();
            //var idFilter = QHS.CmpEq("idcurrency", entity["idcurrency"]);

            // se abbiamo date di riferimento prendiamo la prima altrimenti usiamo quella odierna
            var referenceDate = ValidDates(dateStrings).Any() ? ValidDates(dateStrings).First() : DateTime.Now;

            //var dateFilter = QHS.CmpEq("referencedate", referenceDate);
            //var rate = conn.DO_READ_VALUE("currencyexchange", QHS.AppAnd(idFilter, dateFilter), "eurocurrencyrate");

            double? rate = null;
            try {
                rate = currencyManager.GetDailyEuroCurrencyRate(referenceDate, idCurrency, previousDays);
            }
            // se abbiamo un errore non gestito
            catch (Exception) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(Errors.Unrecoverable());
                return;
            }

            if (rate != null) {
                //btnCurrencyExchange.Hide();
                txtExchange.Text = HelpForm.StringValue(rate, txtExchange.Tag.ToString());

                return;
            }

            // se non abbiamo un tasso di cambio
            MetaFactory.factory.getSingleton<IMessageShower>().Show(Errors.NoData(referenceDate, previousDays, codeCurrency));
            //btnCurrencyExchange.Show();
        }

        public static void UpdateControls(MetaPage page, Manager currencyManager, hwTextBox txtExchange, EventHandler txtExchangeEH, /*hwButton btnCurrencyExchange,*/ /*IDataAccess conn,*/ DataRow entity, params string[] dateStrings) {

            if (entity == null) return;
            if (entity["idcurrency"] == DBNull.Value) return;

            uint previousDays = 7;
            int idCurrency = entity.Field<int>("idcurrency");
            string codeCurrency = currencyManager.GetCodeCurrency(idCurrency);

            if (codeCurrency == currencyManager.ReferenceCurrency.ToString()) return;

            //// se stiamo scegliendo nella choose
            //if (entity.Table.TableName == "currencyexchange") {
            //    //btnCurrencyExchange.Visible = true;
            //    txtExchange.Text = HelpForm.StringValue(entity["eurocurrencyrate"], txtExchange.Tag.ToString());

            //    return;
            //}

            //var QHS = conn.GetQueryHelper();
            //var idFilter = QHS.CmpEq("idcurrency", entity["idcurrency"]);

            // se abbiamo date di riferimento prendiamo la prima altrimenti usiamo quella odierna
            var referenceDate = ValidDates(dateStrings).Any() ? ValidDates(dateStrings).First() : DateTime.Now;

            //var dateFilter = QHS.CmpEq("referencedate", referenceDate);
            //var rate = conn.DO_READ_VALUE("currencyexchange", QHS.AppAnd(idFilter, dateFilter), "eurocurrencyrate");

            double? rate = null;
            try {
                rate = currencyManager.GetDailyEuroCurrencyRate(referenceDate, idCurrency, previousDays);
            }
            // se abbiamo un errore non gestito
            catch (Exception) {
                page.ShowClientMessage(Errors.Unrecoverable(), "Errore");
                return;
            }

            // se abbiamo un tasso di cambio
            if (rate != null) {
                //btnCurrencyExchange.Visible = false;
                txtExchange.Text = HelpForm.StringValue(rate, txtExchange.Tag.ToString());
                txtExchangeEH(null, null);

                return;
            }

            // se non abbiamo un tasso di cambio
            page.ShowClientMessage(Errors.NoData(referenceDate, previousDays, codeCurrency), codeCurrency);
            return;
            //updateTag(btnCurrencyExchange, QHS, idFilter, referenceDate, new TimeSpan(15, 0, 0, 0));
            //btnCurrencyExchange.Visible = true;
        }

        public static void CreateForm(TextBox txtCambio, IDataAccess conn, DataRow entity) {

            if (entity == null) return;
            
            using (var frmAskCurrencyExchange = new FrmAskCurrencyExchange(conn, entity, txtCambio.Tag.ToString())) {
                MetaFactory.factory.getSingleton<IFormCreationListener>().create(frmAskCurrencyExchange, null);
                var result = frmAskCurrencyExchange.ShowDialog();

                if (result == DialogResult.OK) {
                    txtCambio.Text = frmAskCurrencyExchange.Rate;
                }
            }
        }

        private static void updateTag(hwButton btnCurrencyExchange, QueryHelper QHS, string filter, DateTime referenceDate, TimeSpan halfRange) {
            var chooseDateFilter = QHS.AppAnd(QHS.CmpGt("referencedate", referenceDate - halfRange), QHS.CmpLt("referencedate", referenceDate + halfRange));
            btnCurrencyExchange.Tag = string.Join(".", "choose", "currencyexchange", "default", QHS.AppAnd(filter, chooseDateFilter));
        }

        public static List<DateTime> ValidDates(string[] dateStrings) {
            var results = new List<DateTime>();
            foreach (var dateString in dateStrings)
                if (DateTime.TryParse(dateString, out DateTime date)) results.Add(date);

            return results;
        }
    }
}
