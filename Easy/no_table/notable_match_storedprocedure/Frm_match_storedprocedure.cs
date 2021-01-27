
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using metadatalibrary;
using System.Text;
using System.Diagnostics;


//rpt_bilconsuntivo_new 2012,'31-12-2012','S',3,'0001','S','S','S','S'
namespace notable_match_storedprocedure{
    public partial class Frm_match_storedprocedure : Form{

        private static long tot_elapsed_old;
        private static long tot_elapsed_new;
        private const int C_SQLCOMMANDTIMEOUT = 600;
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;

        public Frm_match_storedprocedure(){
            InitializeComponent();

        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
        }

        private void btnMatch_Click(object sender, EventArgs e){
            ClearForm();
            bool successo = false;
            string vecchioNome = txtOldSP.Text;
            string nuovoNome = txtNewSP.Text;
            string listaparametri = txtparameter.Text;
            string filteroldSP = txFilterOldSP.Text;
            string filternewSP = txFilterNewSP.Text;
            tot_elapsed_old = 0;
            tot_elapsed_new = 0;
            
            DataTable T1 = new DataTable("T1");
            DataTable T2 = new DataTable("T2");
            StringReader Sread = new StringReader(listaparametri);
            string currparam = Sread.ReadLine();
            while ((currparam != null)&&(currparam.ToString()!=""))
            {
                string query1 = "exec " + vecchioNome + " " + currparam + " ";

                Stopwatch stop1 = new Stopwatch();
                stop1.Start();
                T1 = Meta.Conn.SQLRunner(query1, true, C_SQLCOMMANDTIMEOUT);
                stop1.Stop();
                long Stop1 = stop1.ElapsedMilliseconds;
                tot_elapsed_old = tot_elapsed_old + Stop1;

                if (T1 == null){
                    MessageBox.Show("La vecchia SP non esiste o presenta errori in esecuzione. La query eseguita è stata " + query1);
                    return;
                }

                if ((T1.Rows.Count > 0)&&(filteroldSP.ToString()!="")){
                    foreach( DataRow R in T1.Select(" not ("+filteroldSP+")")){
                        R.Delete();
                    }
                    T1.AcceptChanges();
                }
                if (T1.Rows.Count == 0)
                MessageBox.Show("La vecchia SP non ha restituito righe");

                string query2 = "exec " + nuovoNome + " " + currparam + " ";

                
                Stopwatch stop2 = new Stopwatch();
                stop2.Start();
                T2 = Meta.Conn.SQLRunner(query2, true, C_SQLCOMMANDTIMEOUT);
                stop2.Stop();
                long Stop2 = stop2.ElapsedMilliseconds;
                tot_elapsed_new = tot_elapsed_new+Stop2;
                if (T2 == null){
                    MessageBox.Show("La nuova SP non esiste o presenta errori in esecuzione. La query eseguita è stata " + query2);
                    return;
                }
                if ((T2.Rows.Count > 0) && (filternewSP.ToString() != "")){
                    foreach (DataRow R in T2.Select(" not (" + filternewSP + ")"))
                    {
                        R.Delete();
                    }
                    T2.AcceptChanges();
                }
                if (T2.Rows.Count == 0){
                    MessageBox.Show("La nuova SP non ha restituito righe");
                }

                if (T1.Rows.Count > 0 && T2.Rows.Count > 0){
                    successo = ConfrontoconSuccesso(T1, T2, currparam);
                    if (!successo){

                        tot_elapsed_old = tot_elapsed_old / 1000;
                        txtTime1.Text = tot_elapsed_old.ToString();

                        tot_elapsed_new = tot_elapsed_new / 1000;
                        txtTime2.Text = tot_elapsed_new.ToString();
                        return;
                    }
                }
                
                currparam = Sread.ReadLine();
                continue;
            }
            tot_elapsed_old = tot_elapsed_old / 1000;
            txtTime1.Text = tot_elapsed_old.ToString();

            tot_elapsed_new = tot_elapsed_new / 1000;
            txtTime2.Text = tot_elapsed_new.ToString();
            // Se i controlli hanno esito positivo le sp restituiscono lo stesso risultato
            MessageBox.Show("Le due sp restituiscono lo stesso risultato per tutte le combinazioni di parametri indicate.");

        }


        public bool ConfrontoconSuccesso(DataTable T1, DataTable T2, string currparam){
            // Confronta il numero di righe
            if (T1.Rows.Count != T2.Rows.Count){
                MessageBox.Show("Con la combinazione di parametri  " + currparam +
                        "Le due sp restituiscono un diverso numero di righe.");
                txtParamOld.Text = currparam;
                txtParamNew.Text = currparam;
                VisualizzaOut(T1, T2);
                return false;
            }
            // Confronta il numero di colonne
            if (T1.Columns.Count != T2.Columns.Count){
                MessageBox.Show("Con la combinazione di parametri  " + currparam +
                        "Le due sp restituiscono un diverso numero di colonne.");
                txtParamOld.Text = currparam;
                txtParamNew.Text = currparam;
                VisualizzaOut(T1, T2);
                return false;
            }

            if (txtFields.Text.ToString() != ""){
                // Se è stato specificatp un elenco di campi, confronta solo quelle colonne.
                string[] fields = txtFields.Text.ToString().Split(',');
                foreach (string f in fields){
                    if ((T1.Columns.Contains(f)) && (T2.Columns.Contains(f))){
                        //Confronta i valori campo per campo
                        if (T2.Columns[f].ToString() != T1.Columns[f].ToString()){
                            MessageBox.Show("Con la combinazione di parametri  " + currparam +
                                " i risultati delle due SP sono diversi");
                            txtParamOld.Text = currparam;
                            txtParamNew.Text = currparam;
                            VisualizzaOut(T1, T2);
                            return false;
                        }
                    }
                    else{
                        if (!(T1.Columns.Contains(f)) && !(T2.Columns.Contains(f))){
                            MessageBox.Show("Con la combinazione di parametri  " + currparam +
                                " risulta che la colonna " + f + " è assente in entrambe le SP");
                            txtParamOld.Text = currparam;
                            txtParamNew.Text = currparam;
                            VisualizzaOut(T1, T2);
                            return false;
                        }
                        if (!(T1.Columns.Contains(f))){
                            MessageBox.Show("Con la combinazione di parametri  " + currparam +
                                " risulta che la colonna " + f + " è assente nella vecchia SP");
                            txtParamOld.Text = currparam;
                            txtParamNew.Text = currparam;
                            VisualizzaOut(T1, T2);
                            return false;
                        }
                        if (!(T2.Columns.Contains(f))){
                            MessageBox.Show("Con la combinazione di parametri  " + currparam +
                                " risulta che la colonna " + f + " è assente nella nuova SP");
                            txtParamOld.Text = currparam;
                            txtParamNew.Text = currparam;
                            VisualizzaOut(T1, T2);
                            return false;
                        }
                    }
                }
            }
            else{
                //Se non è stato specificato un elenco ci campi, confronta tutte le colonne
                foreach (DataColumn C in T1.Columns){
                    if (T2.Columns.Contains(C.ColumnName)){
                        //Confronta i valori campo per campo
                        if (T2.Columns[C.ColumnName].ToString() != T1.Columns[C.ColumnName].ToString()){
                            MessageBox.Show("Con la combinazione di parametri  " + currparam +
                                " i risultati delle due SP sono diversi");
                            txtParamOld.Text = currparam;
                            txtParamNew.Text = currparam;
                            VisualizzaOut(T1, T2);
                            return false;
                        }
                    }
                    else{
                        MessageBox.Show("Con la combinazione di parametri  " + currparam +
                            " risulta che la colonna " + C.ColumnName + " è assente nella nuova SP");
                        txtParamOld.Text = currparam;
                        txtParamNew.Text = currparam;
                        VisualizzaOut(T1, T2);
                        return false;
                    }
                }
            }



            return true;
        }

        public void ClearForm(){
            txtTime1.Text = "";
            txtTime2.Text = "";
            txtParamOld.Text = "";
            txtParamNew.Text = "";
            dataGridOldSP.DataSource = null;
            dataGridNewSP.DataSource = null;
            Meta.FreshForm();
        }
        public void VisualizzaOut(DataTable T1, DataTable T2){
            DS.Tables.Add(T1);
            DS.Tables.Add(T2);
            dataGridOldSP.DataSource = null;
            dataGridNewSP.DataSource = null;
            HelpForm.SetDataGrid(dataGridOldSP, T1);
            HelpForm.SetDataGrid(dataGridNewSP, T2);
            
        }

    }
}

