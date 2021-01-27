
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using funzioni_configurazione;
using System.Collections;


namespace notable_importazione
{
    public partial class FrmNotable_SelezionaAggiungiAnagrafica : Form
    {
        public DataRow SelectedRow;
        public DataTable Anagrafiche;
        public string Esito;


        public FrmNotable_SelezionaAggiungiAnagrafica(DataTable DT, DataRow RegistryFromInputFile,int RowNumberInInputFile)
        {
            InitializeComponent();
            lblMessage.Text = "Attenzione. L'anagrafica presente nel file di input alla linea " + RowNumberInInputFile.ToString() + " presenta dei sinonimi\n";
            lblMessage.Text += "Cliccando sul pulsante 'Crea' verrà creata una nuova anagrafica con i seguenti dettagli:";
            DataSet myDS = new DataSet();
            myDS.Tables.Add(DT);

            lblGridAction.Text = "In alternativa è possibile selezionare una delle anagrafiche mostrate nella griglia e cliccare su 'Seleziona'";
            Anagrafiche = DT;
            txtCognome.Text = RegistryFromInputFile["surname"].ToString();
            txtCognome.ReadOnly = true;
            txtNome.Text = RegistryFromInputFile["forename"].ToString();
            txtNome.ReadOnly = true;
            txtDenominazione.Text = RegistryFromInputFile["title"].ToString();
            txtDenominazione.ReadOnly = true;
            txtCF.Text = RegistryFromInputFile["cf"].ToString();
            txtCF.ReadOnly = true;
            txtCFExt.Text = RegistryFromInputFile["foreigncf"].ToString();
            txtCFExt.ReadOnly = true;
            txtPIva.Text = RegistryFromInputFile["p_iva"].ToString();
            txtPIva.ReadOnly = true;
            txtLocalita.Text = RegistryFromInputFile["location"].ToString();
            txtLocalita.ReadOnly = true;
            txtDataNascita.Text = RegistryFromInputFile["birthdate"].ToString();
            txtDataNascita.ReadOnly = true;

            if (RegistryFromInputFile["gender"].ToString().Trim() == "M")
                rdbM.Checked = true;
            else
                rdbF.Checked = true;

            rdbF.Enabled = false;
            rdbM.Enabled = false;
            HelpForm.SetDataGrid(DetailGrid, DT);
            new formatgrids(DetailGrid).AutosizeColumnWidth();
            
/*            
            DetailGrid.DataSource = myDS;


            DetailGrid.DataMember = "registry";
*/
        }

        private void btnCrea_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Si desidera procedere all'inserimento di una nuova anagrafica?", "Crea", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Esito = "Crea";
                this.Close();
            }
        }

        private void btnSeleziona_Click(object sender, EventArgs e)
        {
            Esito = "Seleziona";
            if (MessageBox.Show("Procedere con la riga selezionata?", "Seleziona", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                // Riga selezionata
                int CurrentRowNumber = DetailGrid.CurrentRowIndex;
                SelectedRow = Anagrafiche.Rows[CurrentRowNumber];
                this.Close();
            }
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Annullare l'operazione?", "Annulla", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                Esito = "Annulla";
                this.Close();
            }
        }



    }
}
