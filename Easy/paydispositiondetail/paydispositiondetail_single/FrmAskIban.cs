
/*
Easy
Copyright (C) 2024 Universit� degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using metadatalibrary;

namespace paydispositiondetail_single
{
    public partial class FrmAskIban : MetaDataForm
    {
        public string insertedIBAN = "";
        public FrmAskIban(string iban)
        {
            InitializeComponent();
            txtIBAN.Text = iban;
            insertedIBAN = iban;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            insertedIBAN = CfgFn.normalizzaIBAN(txtIBAN.Text.ToUpper());
            if (insertedIBAN == "") return;
            if (insertedIBAN.Length < 2)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Lunghezza del codice IBAN errata");
                this.DialogResult = DialogResult.None;
            }
            if (!insertedIBAN.StartsWith("IT")) return;
            if (!CfgFn.verificaIban(insertedIBAN))
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Il codice digitato non � un codice IBAN valido!");
                this.DialogResult = DialogResult.None;
            }
            if (insertedIBAN.Length != 27)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show("Il codice IBAN per l'Italia deve essere composto da 27 caratteri");
                this.DialogResult = DialogResult.None;
            }
        }
    }
}
