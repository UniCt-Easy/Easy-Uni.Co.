
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

namespace no_table_flowchartcopy{
    public partial class Frm_flowchartcopy : MetaDataForm {
        MetaData Meta;
        public Frm_flowchartcopy()  {
            InitializeComponent();
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            bool IsAdmin = false;
            if (Meta.GetSys("manage_prestazioni") != null)
                IsAdmin = (Meta.GetSys("manage_prestazioni").ToString() == "S");
            Meta.CanSave = IsAdmin;
            Meta.CanInsert = IsAdmin;
            Meta.CanInsertCopy = IsAdmin;
            Meta.CanCancel = IsAdmin;
        }

        public bool DatiValidi() {
            int esercizio;
            try {
                esercizio = (int)HelpForm.GetObjectFromString(typeof(int),
                    txtstartayear.Text.ToString(), "x.y.year");
                if ((esercizio < 0))
                {
                    show("L'esercizio non può essere negativo");
                    txtstartayear.Focus();
                    return false;
                }

            }
            catch {
                show("E' necessario inserire l'Esercizio DA cui copiare");
                txtstartayear.Focus();
                return false;
            }
            if (txtdbsource.Text.ToString() == ""){
                show("Indicare il dipartimento DA cui copiare i dati.");
                txtdbsource.Focus();
                return false;
            }

            if (txtdbdest.Text.ToString()==""){
                show("Indicare il dipartimento IN cui copiare i dati.");
                txtdbdest.Focus();
                return false;
            }
            return true;



        }

        private void btntrasferisci_Click(object sender, EventArgs e) {
            if (!DatiValidi()) return;
            object source = txtdbsource.Text;
            object startayear = HelpForm.GetObjectFromString(typeof(int),txtstartayear.Text.ToString(), "x.y.year");

            object dest = txtdbdest.Text;
            object stopayear = HelpForm.GetObjectFromString(typeof(int),txtstopayear.Text.ToString(), "x.y.year");

            DataSet Out = Meta.Conn.CallSP("compute_flowchartcopy", new object[] { source, dest, startayear, stopayear }, false, 600);
            if ((Out == null) || (Out.Tables.Count == 0) || Out.Tables[0].Rows.Count==0){
                show(this, "La sp non ha restituito risultati.");
                return;
            }
            DataTable t = Out.Tables[0];
            if (t.Rows.Count > 0) {
                string result = "";
                foreach (DataRow r in t.Rows){
                    result += "\n " + r["messaggio"];
                }
                show(this, result);
            }

   

        }
    }
}
