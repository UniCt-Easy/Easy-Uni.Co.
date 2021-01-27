
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

namespace no_table_elencoclientiforn {
    public partial class FrmElencoClientiFornitori : Form {
        MetaData Meta;
        QueryHelper QHC;
        public FrmElencoClientiFornitori() {
            InitializeComponent();
        }

        private void btnScegliFile_Click(object sender, EventArgs e) {
            DialogResult dr = saveFileDialog1.ShowDialog(this);
            if (dr == DialogResult.OK) {
                txtFile.Text = saveFileDialog1.FileName;
            }
        }

        //spazio: AN, CF, PR
        //zero:   PI, DT, NU
        private string formattaPosiz(object valore, int caratteri, string formato) {
            string s = valore.ToString();
            if (s.Length > caratteri) {
                s = s.Substring(0, caratteri);
            }
            switch (formato) {
                case "AN":
                case "CF":
                case "PR":
                    return s.PadRight(caratteri);
                case "PI":
                case "NU":
                    return s.PadLeft(caratteri, '0');
                case "DT":
                    if (valore == DBNull.Value) return "00000000";
                    return ((DateTime)valore).ToString("ddMMyyyy");
                default:
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Formato " + formato + " sconosciuto!");
                    return null;
            }
        }

        private void scriviRecordDiTestaODiCoda(int record, StreamWriter sw, DataRow r) {
            sw.Write(record);
            sw.Write(formattaPosiz(r["h02"], 3, "AN"));
            sw.Write(formattaPosiz(r["h03"], 2, "NU"));
            sw.Write(formattaPosiz(r["h04"], 2, "NU"));
            sw.Write(formattaPosiz(r["h05"],16, "CF"));
            sw.Write(formattaPosiz(r["h06"],11, "PI"));
            sw.Write(formattaPosiz(r["h07"],26, "AN"));
            sw.Write(formattaPosiz(r["h08"],25, "AN"));
            sw.Write(formattaPosiz(r["h09"], 1, "AN"));
            sw.Write(formattaPosiz(r["h10"], 8, "DT"));
            sw.Write(formattaPosiz(r["h11"],40, "AN"));
            sw.Write(formattaPosiz(r["h12"], 2, "PR"));
            sw.Write(formattaPosiz(r["h13"],70, "AN"));
            sw.Write(formattaPosiz(r["h14"],40, "AN"));
            sw.Write(formattaPosiz(r["h15"], 2, "AN"));
            sw.Write(formattaPosiz(r["h16"],16, "CF"));
            sw.Write(formattaPosiz(r["h17"], 4, "NU"));
            sw.Write(formattaPosiz(r["h18"], 4, "NU"));
            sw.Write(formattaPosiz(r["h19"], 4, "NU"));
            sw.Write(formattaPosiz(r["h20"],16, "CF"));
            sw.Write(formattaPosiz(r["h21"], 5, "NU"));
            sw.Write(formattaPosiz(r["h22"], 1, "NU"));
            sw.Write(formattaPosiz(r["h23"], 8, "DT"));
            sw.WriteLine("A".PadLeft(1491));
        }

        private DataTable chiamaSP(string sp, object[] parametri) {
            DataSet ds = Meta.Conn.CallSP(sp, parametri);
            if ((ds == null) || (ds.Tables.Count==0)) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Errore nella chiamata " + sp);
                return null;
            }
            return ds.Tables[0];
        }

        //sinist: CF, PI
        //destra: NP, NU
        private void scriviUnCampo(int record, StreamWriter sw, StringBuilder sb,
            DataRow r, string campo, string formato) {
            if (r[campo] == DBNull.Value) return;
            string s = null;
            switch (formato) {
                case "CF":
                case "PI":
                    s = campo + r[campo].ToString().PadRight(16);
                    break;
                case "NP":
                case "NU":
                    s = campo + r[campo].ToString().PadLeft(16, '0');
                    break;
                default:
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Formato " + formato + " sconosciuto!");
                    break;
            }
            if (sb.Length == 0) {
                sb.Append(record);
            }
            if (sb.Append(s).Length == 1681) {
                sw.WriteLine(sb + "A".PadLeft(117));
                sb.Length = 0;
            }
        }

        private void btnScriviElenco_Click(object sender, EventArgs e) {
            if (txtFile.Text=="") {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Specificare il percorso del file da creare!");
                return;
            }
            DataTable tRecordTestaECoda = chiamaSP("exp_elencoclientifornit_intestazione", new object[] {});
            DataTable tClienti = chiamaSP("exp_elencoclienti", new object[] {Meta.GetSys("esercizio")});
            DataTable tFornitori = chiamaSP("exp_elencofornitori", new object[] { Meta.GetSys("esercizio") });
            StreamWriter sw = new StreamWriter(txtFile.Text, false, Encoding.Default);
            StringBuilder sb = new StringBuilder();
            scriviRecordDiTestaODiCoda(0, sw, tRecordTestaECoda.Rows[0]);
            foreach (DataRow r in tClienti.Rows) {
                scriviUnCampo(1, sw, sb, r, "CL001001", "NP");
                scriviUnCampo(1, sw, sb, r, "CL002001", "CF");
                scriviUnCampo(1, sw, sb, r, "CL003001", "PI");
                scriviUnCampo(1, sw, sb, r, "CL004001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL004002", "NU");
                scriviUnCampo(1, sw, sb, r, "CL005001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL006001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL007001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL008001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL008002", "NU");
                scriviUnCampo(1, sw, sb, r, "CL009001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL010001", "NU");
                scriviUnCampo(1, sw, sb, r, "CL011001", "NU");
            }
            if (sb.Length > 0) {
                sw.WriteLine(sb+"A".PadLeft(1798 - sb.Length));
            }
            sb.Length = 0;
            foreach (DataRow r in tFornitori.Rows) {
                scriviUnCampo(2, sw, sb, r, "FR001001", "NP");
                scriviUnCampo(2, sw, sb, r, "FR002001", "CF");
                scriviUnCampo(2, sw, sb, r, "FR003001", "PI");
                scriviUnCampo(2, sw, sb, r, "FR004001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR004002", "NU");
                scriviUnCampo(2, sw, sb, r, "FR005001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR006001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR007001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR008001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR009001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR009002", "NU");
                scriviUnCampo(2, sw, sb, r, "FR010001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR011001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR012001", "NU");
                scriviUnCampo(2, sw, sb, r, "FR013001", "NU");
            }
            if (sb.Length > 0) {
                sw.WriteLine(sb+"A".PadLeft(1798 - sb.Length));
            }
            sw.Write(3);
            sw.Write(tClienti.Rows.Count.ToString().PadLeft(8), '0');
            sw.Write(tFornitori.Rows.Count.ToString().PadLeft(8), '0');
            sw.Write(tClienti.Compute("sum(CL004001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL004002)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL005001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL006001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL007001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL008001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL008002)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL009001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL010001)", null).ToString().PadLeft(20), '0');
            sw.Write(tClienti.Compute("sum(CL011001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR004001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR004002)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR005001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR006001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR007001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR008001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR009001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR009002)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR010001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR011001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR012001)", null).ToString().PadLeft(20), '0');
            sw.Write(tFornitori.Compute("sum(FR013001)", null).ToString().PadLeft(20), '0');
            sw.WriteLine("A".PadLeft(1341));
            scriviRecordDiTestaODiCoda(9, sw, tRecordTestaECoda.Rows[0]);
            sw.Close();
            MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Elenco clienti/fornitori salvato in " + txtFile.Text);
        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            Meta.CanCancel = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
        }

        private void btnClienti_Click(object sender, EventArgs e) {
            DataTable t = chiamaSP("exp_elencoclienti", new object[] { Meta.GetSys("esercizio") });
            if (t.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Nessun cliente trovato");
            }
            exportclass.DataTableToExcel(t, true);
        }

        private void btnFornitori_Click(object sender, EventArgs e) {
            DataTable t = chiamaSP("exp_elencofornitori", new object[] { Meta.GetSys("esercizio") });
            if (t.Rows.Count == 0) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Nessun fornitore trovato");
            }
            exportclass.DataTableToExcel(t, true);
        }

        private void btnCheck_Click(object sender, EventArgs e) {
            object idcity = Meta.Conn.DO_READ_VALUE("license", null, "idcity");
            if (idcity == DBNull.Value) {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Andare in 'Configurazione'/'Informazioni Ente' ed inserire il comune");
            }
            DataTable t = chiamaSP("exp_check_clientifornitori", new object[] { Meta.GetSys("esercizio") });
            if (t.Rows.Count == 0) {
                if (idcity != DBNull.Value) {
                    MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Nessun problema riscontrato");
                }
            }
            exportclass.DataTableToExcel(t, true);
        }
    }
}
