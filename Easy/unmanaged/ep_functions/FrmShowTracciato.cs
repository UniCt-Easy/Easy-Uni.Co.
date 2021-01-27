
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
using System.IO;
using System.Threading;
using System.Diagnostics;
using funzioni_configurazione;

namespace ep_functions {


    public partial class FrmShowTracciato : Form {
        public string GetTracciato(string[] tracciato) {
            string res = "";
            int pos = 0;
            foreach (string t in tracciato) {
                string[] ss = t.Split(';');
                string field = ss[0].PadLeft(30) + ": Pos." + pos.ToString().PadLeft(5) + " lunghezza " +
                               ss[3].PadLeft(4) +
                               " Tipo: " + ss[2].PadLeft(15);
                if (ss[2].ToLower() == "codificato") {
                    field += " Codifica:" + ss[4];
                }
                field += " Descrizione: " + ss[1];
                field += "\r\n";
                pos += CfgFn.GetNoNullInt32(ss[3]);
                res += field;
            }
            return res;
        }

        public DataTable GetTableTracciato(string[] tracciato) {
            int pos = 0;
            DataTable T = new DataTable("t");
            T.Columns.Add("nome", typeof(string));
            T.Columns.Add("posizione", typeof(int));
            T.Columns.Add("lunghezza", typeof(string));
            T.Columns.Add("tipo", typeof(string));
            T.Columns.Add("codifica", typeof(string));
            T.Columns.Add("Descrizione", typeof(string));

            foreach (string t in tracciato) {
                DataRow r = T.NewRow();
                string[] ss = t.Split(';');
                r["nome"] = ss[0];
                r["posizione"] = pos;
                r["lunghezza"] = CfgFn.GetNoNullInt32(ss[3]);
                r["tipo"] = ss[2];
                if (ss.Length == 5) r["codifica"] = ss[4];
                r["Descrizione"] = ss[1];
                pos += CfgFn.GetNoNullInt32(ss[3]);
                T.Rows.Add(r);
            }
            return T;
        }

        public FrmShowTracciato(string []tracciato, string titolo) {

            InitializeComponent();
            string S = GetTracciato(tracciato);
            DataTable T = GetTableTracciato(tracciato);

            if (S == "") {
                tabControl1.TabPages.Remove(tabPage1);
            }
            else {
                txtTracciato.Text = S;
                txtTracciato.Select(0, 0);
                tabPage1.Text = titolo;
            }
            if (T.DataSet == null) {
                DataSet D = new DataSet();
                D.Tables.Add(T);
            }
            if (T == null) {
                tabControl1.TabPages.Remove(tabGrid);
            }
            else {
                HelpForm.SetDataGrid(gridTab, T);

                ExcelMenu = new ContextMenu();
                ExcelMenu.MenuItems.Add("Excel", new EventHandler(Excel_Click));
                ExcelMenu.MenuItems.Add("CSV", new EventHandler(CSV_Click));
                gridTab.ContextMenu = ExcelMenu;
            }
        }
        ContextMenu ExcelMenu;

        private void Excel_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;
            exportclass.DataTableToExcel(T, true);
        }
        private void CSV_Click(object menusender, EventArgs e) {
            if (menusender == null) return;
            if (!(typeof(MenuItem).IsAssignableFrom(menusender.GetType()))) return;
            object sender = ((MenuItem)menusender).Parent.GetContextMenu().SourceControl;
            if (!(typeof(DataGrid).IsAssignableFrom(sender.GetType()))) return;
            DataGrid G = (DataGrid)sender;
            object DDS = G.DataSource;
            if (DDS == null) return;
            if (!typeof(DataSet).IsAssignableFrom(DDS.GetType())) return;
            string DDT = G.DataMember;
            if (DDT == null) return;
            DataTable T = ((DataSet)DDS).Tables[DDT];
            if (T == null) return;

            OpenFileDialog FD = new OpenFileDialog();
            FD.Title = "Seleziona il file da creare";
            FD.AddExtension = true;
            FD.DefaultExt = "CSV";
            FD.CheckFileExists = false;
            FD.CheckPathExists = true;
            FD.Multiselect = false;
            DialogResult DR = FD.ShowDialog();
            if (DR != DialogResult.OK) return;




            try {
                string S = exportclass.DataTableToCSV(T, true);
                StreamWriter SWR = new StreamWriter(FD.FileName, false, Encoding.Default);
                SWR.Write(S);
                SWR.Close();
                SWR.Dispose();
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
            }
            Process.Start(FD.FileName);


        }
    }
}
