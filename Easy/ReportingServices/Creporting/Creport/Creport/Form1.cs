
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


using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Creport {
    public partial class Form1 :Form {

        private bool Annodecrescente { get; set; }
        private bool Numerodecrescente { get; set; }

        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e) {
            var rv = new ReportViewer { Dock = DockStyle.Fill };
            this.Controls.Add(rv);
            new DataGridReportGenerator(rv.LocalReport).Run(Annodecrescente, Numerodecrescente);
            rv.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage;
            rv.RefreshReport();
        }


        private void Btn1_Click(object sender, System.EventArgs e) {
            CambiaAnno(sender, e);
            Form1_Load(sender, e);
        }

        private void Btn2_Click(object sender, System.EventArgs e) {
            CambiaNumero(sender, e);
            Form1_Load(sender, e);
        }


        private void CambiaAnno(object sender, System.EventArgs e) {
            this.Controls.Clear();
            this.InitializeComponent();
            this.Text = "Datagrid modificato";
            if (Annodecrescente == false) { button1.Text = "Anno Crescente"; this.Annodecrescente = true;}
            else { button1.Text = "Anno Decrescente"; this.Annodecrescente = false; }
        }

        private void CambiaNumero(object sender, System.EventArgs e) {
            this.Controls.Clear();
            this.InitializeComponent();
            this.Text = "Datagrid modificato";
            if (Numerodecrescente == false) { button2.Text = "Numero Crescente"; this.Numerodecrescente = true; }
            else { button2.Text = "Numero Decrescente"; this.Numerodecrescente = false; }
        }
    }
}
