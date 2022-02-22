
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


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using funzioni_configurazione;
using metadatalibrary;

namespace mandatedetail_single {
    public partial class frmHint : MetaDataForm {
        public frmHint(decimal imponibileunitario, decimal totiva, decimal totivaindetraibile, int number,double excghrate, double discount) {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
           CfgFn.decimalFunction f = x => CfgFn.RoundValuta(x *
                                              Decimal.Round(Convert.ToDecimal(excghrate), 6) *
                                              Decimal.Round(Convert.ToDecimal(1 - discount), 6));

            decimal totImponibileDaTotale = f( number * imponibileunitario);
            decimal totImponibileDaDettagli = number * f(imponibileunitario);
            decimal impoDiff = Math.Round(totImponibileDaDettagli - totImponibileDaTotale,2);
            if (Math.Abs(impoDiff) <= 0.01m) { }
            decimal q1 = number;
            decimal impon1 = imponibileunitario;
            decimal iva1 = totiva;
            decimal ivaindet1 = totivaindetraibile;
            decimal impoNetto1 = totImponibileDaDettagli;

            decimal impon2 = 0;
            decimal impoNetto2 = 0;
            decimal iva2 = 0;
            decimal ivaindet2 = 0;

            if (totImponibileDaTotale == totImponibileDaDettagli) {
                Q1.Text = q1.ToString();
                imponibile1.Text = impoNetto1.ToString("N");
                importo1.Text= imponibileunitario.ToString("N");
                Iva1.Text = totiva.ToString("c");
                IvaDet1.Text = totivaindetraibile.ToString("C");                

            }
            else {
                 q1 = number - 1;
                impon1 = CfgFn.RoundValuta(imponibileunitario);
                iva1 = CfgFn.RoundValuta(totiva / number) * (number - 1);
                ivaindet1 = CfgFn.RoundValuta(totivaindetraibile / number) * (number - 1);
                impoNetto1 = q1 * f(impon1);


                Q1.Text = q1.ToString();
                importo1.Text = impon1.ToString("c");
                imponibile1.Text = impoNetto1.ToString("c");
                Iva1.Text = iva1.ToString("c");
                IvaDet1.Text = ivaindet1.ToString("c");

                impon2 =
                    CfgFn.funzioneInversa(0, 100 * imponibileunitario, f, totImponibileDaTotale - impoNetto1, 5);
                impoNetto2 = f(impon2);
                iva2 = totiva - iva1;
                ivaindet2 = totivaindetraibile - ivaindet1;

                Q2.Visible = true;
                imponibile2.Visible = true;
                importo2.Visible = true;
                Iva2.Visible = true;
                IvaDet2.Visible = true;

                Q2.Text = @"1";
                importo2.Text = impon2.ToString("c");
                imponibile2.Text = impoNetto2.ToString("c");
                Iva2.Text = iva2.ToString("c");
                IvaDet2.Text = ivaindet2.ToString("c");

                if (impoNetto1 + impoNetto2 != totImponibileDaTotale) {
                    show("Non sono riuscito a calcolare una suggerimento valido", "Avviso");
                }
            }
            Q3.Visible = true;
            imponibile3.Visible = true;
            importo3.Visible = true;
            Iva3.Visible = true;
            IvaDet3.Visible = true;

            Q3.Text = number.ToString();
            importo3.Text = (impon2+impon1).ToString("c");
            imponibile3.Text =( impoNetto2+impoNetto1).ToString("c");
            Iva3.Text = (iva1+iva2).ToString("c");
            IvaDet3.Text = (ivaindet1+ivaindet2).ToString("c");


        }

        private void btnCausaleAnnullamento_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
