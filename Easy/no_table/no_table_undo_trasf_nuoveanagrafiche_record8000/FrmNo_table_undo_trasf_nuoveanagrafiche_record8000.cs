
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
using metaeasylibrary;
using funzioni_configurazione;

namespace no_table_undo_trasf_nuoveanagrafiche_record8000 {
    public partial class FrmNo_table_undo_trasf_nuoveanagrafiche_record8000 : MetaDataForm {
        MetaData Meta;

        public FrmNo_table_undo_trasf_nuoveanagrafiche_record8000()
        {
            InitializeComponent();
        }
        CQueryHelper QHC;
        QueryHelper QHS;
        public void MetaData_AfterLink () {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.CanSave = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;
  
        }
        int min_matricula;
        int max_matricula;
        public void MetaData_AfterActivation()
        {
            DataTable CurrMatricole= Meta.Conn.RUN_SELECT("importAnagrRecord8000", "*", "lt desc", QHS.CmpEq("kind","A"), null, false);
            if (CurrMatricole.Rows.Count == 0) return;
            int matricola_a = CfgFn.GetNoNullInt32(CurrMatricole.Rows[0]["lastmatr"]);
            CurrMatricole.Clear();
            CurrMatricole = Meta.Conn.RUN_SELECT("importAnagrRecord8000", "*", "lt desc", QHS.CmpEq("kind", "D"), null, false);
            int matricola_d = CfgFn.GetNoNullInt32(CurrMatricole.Rows[0]["lastmatr"]);

            txt_matricola_in_organico.Text = matricola_a.ToString();
            txt_matricola_personale_esterno.Text = matricola_d.ToString();

            min_matricula = Math.Min(matricola_d,matricola_a);
            max_matricula = Math.Max(matricola_d, matricola_a);
 
        }

        private bool isNumeric(string str, out int valore)
        {
            valore = 0;
            try
            {
                valore = Convert.ToInt32(str);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void btnAnnullaMatricole_Click (object sender, EventArgs e) {
         
            string matricola_da = txt_matricola_da.Text.Trim();
            string matricola_a = txt_matricola_a.Text.Trim();

            int imatricola_da = 0;
            int imatricola_a = 0;

            if ((matricola_da != "") && (isNumeric(matricola_da, out imatricola_da)))
            {
                imatricola_da = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), matricola_da, "x.y"));
            }
            if ((matricola_a != "") && (isNumeric(matricola_a, out imatricola_a)))
            {
                imatricola_a = CfgFn.GetNoNullInt32(HelpForm.GetObjectFromString(typeof(int), matricola_a, "x.y"));
            }

            string warning = " Saranno cancellati i numeri di matricola compresi tra " + matricola_da + " a " + matricola_a +
                             " (inclusi). L'operazione non sarà reversibile. Si desidera continuare?";

            if (show(warning, "Conferma cancellazione",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != DialogResult.Yes)
            {
                show("Operazione non eseguita");
                return;
            }

            string script = " update registry set extmatricula = null where convert(int,extmatricula) >= " + imatricola_da + 
                            " and convert(int,extmatricula) <= " + imatricola_a;
            DataTable T = Meta.Conn.SQLRunner(script, true);

            show("Operazione eseguita", "");
        }


        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
