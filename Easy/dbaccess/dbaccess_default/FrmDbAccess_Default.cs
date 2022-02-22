
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


using funzioni_configurazione;
using metadatalibrary;
using System;
using System.Data;
using System.IdentityModel.Selectors;
using System.Windows.Forms;

namespace dbaccess_default
{
    public partial class Frmdbaccess_default : MetaDataForm
    {
        MetaData Meta;

        public Frmdbaccess_default()
        {
            InitializeComponent();
        }

        public void MetaData_AfterLink()
        {
            Meta = MetaData.GetMetaData(this);
            Meta.CanInsert = false;
            Meta.CanSave = false;
            Meta.CanInsertCopy = false;

            GetData.CacheTable(DS.combo_dbaccess, "", "login", true);
            DataAccess.SetTableForReading(DS.combo_dbaccess, "dbaccess");
        }

        public void MetaData_AfterClear()
        {
            chkEveryone.Checked = false;
        }

        private void chkEveryone_CheckStateChanged(object sender, EventArgs e)
        {
            
            if (chkEveryone.Checked)
                foreach (Control ctrl in grpUtente.Controls) ctrl.Hide();
            else
                foreach (Control ctrl in grpUtente.Controls) ctrl.Show();
        }

        private void btnApplica_Click(object sender, System.EventArgs e)
        {
            if (Meta.IsEmpty) return;


            if (chkEveryone.Checked)
            {
                // dummy row
                DataRow toCheck = DS.dbaccess.NewRow();
                toCheck["iddbdepartment"] = "dummy";
                toCheck["login"] = "dummy";
                toCheck["pwdmaxage"] = CfgFn.GetNoNullInt32(txtPwdMaxAge.Text);
                toCheck["pwdwarning"] = CfgFn.GetNoNullInt32(txtPwdWarning.Text);

                if (Meta.IsValid(toCheck, out string errmess, out string errfield))
                {
                    string sql = string.Format("UPDATE dbaccess SET pwdmaxage = {0}, pwdwarning = {1}, lt = GETDATE(), lu = '{2}'", txtPwdMaxAge.Text, txtPwdWarning.Text, Meta.Conn.GetSys("user").ToString());
                    Meta.Conn.SQLRunner(sql, 30, out string error);

                    if (string.IsNullOrEmpty(error))
                    {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(string.Format("Validità di {0} giorni e preavviso di {1} giorni impostati per tutti gli utenti", txtPwdMaxAge.Text, txtPwdWarning.Text), "Applicazione impostazioni");
                    }
                    else
                    {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show(string.Format("Errore nell'applicazione delle impostazioni: {0}", error, "Applicazione impostazioni"));
                    }
                }
                else MetaFactory.factory.getSingleton<IMessageShower>().Show(string.Format("Errore nell'applicazione delle impostazioni: {0}", errmess, "Applicazione impostazioni"));
            }
            else
            {
                Meta.DoMainCommand("mainsave");

                // come controllo se Meta.DoMainCommand("mainsave") ha avuto successo? Mi serve per dare un feedback all'utente
                //MetaFactory.factory.getSingleton<IMessageShower>().Show(string.Format("Validità di {0} giorni e preavviso di {1} giorni impostati per l'utente", txtPwdMaxAge.Text, txtPwdWarning.Text), "Applicazione impostazioni");
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
