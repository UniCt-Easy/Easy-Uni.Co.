/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

namespace assetacquire_massive {
    public partial class FormHint : Form {
        public FormHint(decimal totiva, decimal totivadetraibile, int number) {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            decimal IvaOne = CfgFn.RoundValuta(totiva / number);
            decimal IvaDetraibileOne = CfgFn.RoundValuta(totivadetraibile / number);
            decimal scartoIvaDecimal = (totiva - CfgFn.RoundValuta(IvaOne * number)) * 100;
            decimal scartoIvaDetraibileDecimal = (totivadetraibile - CfgFn.RoundValuta(IvaDetraibileOne * number)) * 100;
            int scartoIvaInt = Convert.ToInt32(scartoIvaDecimal);
            int scartoIvaDetraibileInt = Convert.ToInt32(scartoIvaDetraibileDecimal);
            if (scartoIvaInt < 0) {
                scartoIvaInt += number;
                IvaOne -= 0.01M;
            }
            if (scartoIvaDetraibileInt < 0) {
                scartoIvaDetraibileInt += number;
                IvaDetraibileOne -= 0.01M;
            }

            //Caso 1: tutti e due gli scarti sono 0
            if (scartoIvaInt == 0 && scartoIvaDetraibileInt == 0) {
                Q1.Text = number.ToString();
                Iva1.Text = totiva.ToString("c");
                IvaDet1.Text = totivadetraibile.ToString("c");
                return;
            }

            Q2.Visible = true;
            Iva2.Visible = true;
            IvaDet2.Visible = true;

            //Caso 2a:  scartoIvaDetraibile ==0 
            if (scartoIvaInt != 0 && scartoIvaDetraibileInt == 0) {
                int nbase = number - scartoIvaInt;
                decimal IvaBase = IvaOne * nbase;
                decimal IvaDetrBase = IvaDetraibileOne * nbase;
                decimal IvaSuppl = ((IvaOne + 0.01M) * scartoIvaInt);
                decimal IvaDetrSuppl = IvaDetraibileOne * scartoIvaInt;
                Q1.Text = nbase.ToString();
                Iva1.Text = IvaBase.ToString("c");
                IvaDet1.Text = IvaDetrBase.ToString("c");
                Q2.Text = scartoIvaInt.ToString();
                Iva2.Text = IvaSuppl.ToString("c");
                IvaDet2.Text = IvaDetrSuppl.ToString("c");
                return;
            }

            //Caso 2b:  scartoIvaInt ==0 
            if (scartoIvaInt == 0 && scartoIvaDetraibileInt != 0) {
                int nbase = number - scartoIvaDetraibileInt;
                decimal IvaBase = IvaOne * nbase;
                decimal IvaDetrBase = IvaDetraibileOne * nbase;
                decimal IvaSuppl = IvaOne * scartoIvaDetraibileInt;
                decimal IvaDetrSuppl = (IvaDetraibileOne + 0.01M) * scartoIvaDetraibileInt;
                Q1.Text = nbase.ToString();
                Iva1.Text = IvaBase.ToString("c");
                IvaDet1.Text = IvaDetrBase.ToString("c");
                Q2.Text = scartoIvaDetraibileInt.ToString();
                Iva2.Text = IvaSuppl.ToString("c");
                IvaDet2.Text = IvaDetrSuppl.ToString("c");
                return;
            }

            //Caso 3a: entrambi scarti !=0, uguali tra loro
            if (scartoIvaInt == scartoIvaDetraibileInt) {
                int nbase = number - scartoIvaDetraibileInt;
                decimal IvaBase = IvaOne * nbase;
                decimal IvaDetrBase = IvaDetraibileOne * nbase;
                decimal IvaSuppl = (IvaOne + 0.01M) * scartoIvaDetraibileInt;
                decimal IvaDetrSuppl = (IvaDetraibileOne + 0.01M) * scartoIvaDetraibileInt;
                Q1.Text = nbase.ToString();
                Iva1.Text = IvaBase.ToString("c");
                IvaDet1.Text = IvaDetrBase.ToString("c");
                Q2.Text = scartoIvaDetraibileInt.ToString();
                Iva2.Text = IvaSuppl.ToString("c");
                IvaDet2.Text = IvaDetrSuppl.ToString("c");
                return;
            }

            Q3.Visible = true;
            Iva3.Visible = true;
            IvaDet3.Visible = true;

            //Caso 3b: entrambi scarti !=0 e diversi tra loro
            if (scartoIvaInt < scartoIvaDetraibileInt) {
                int nbase = number - scartoIvaDetraibileInt;
                decimal IvaBase = IvaOne * nbase;
                decimal IvaDetrBase = IvaDetraibileOne * nbase;
                Q1.Text = nbase.ToString();
                Iva1.Text = IvaBase.ToString("c");
                IvaDet1.Text = IvaDetrBase.ToString("c");

                decimal IvaSuppl = (IvaOne + 0.01M) * scartoIvaInt;
                decimal IvaDetrSuppl = (IvaDetraibileOne + 0.01M) * scartoIvaInt;
                Q2.Text = scartoIvaInt.ToString();
                Iva2.Text = IvaSuppl.ToString("c");
                IvaDet2.Text = IvaDetrSuppl.ToString("c");

                int q3 = scartoIvaDetraibileInt - scartoIvaInt;

                decimal IvaSuppl2 = IvaOne * q3;
                decimal IvaDetrSuppl2 = (IvaDetraibileOne + 0.01M) * q3;
                Q3.Text = q3.ToString();
                Iva3.Text = IvaSuppl2.ToString("c");
                IvaDet3.Text = IvaDetrSuppl2.ToString("c");
                return;
            }
            else {

                int nbase = number - scartoIvaInt;
                decimal IvaBase = IvaOne * nbase;
                decimal IvaDetrBase = IvaDetraibileOne * nbase;
                Q1.Text = nbase.ToString();
                Iva1.Text = IvaBase.ToString("c");
                IvaDet1.Text = IvaDetrBase.ToString("c");

                decimal IvaSuppl = (IvaOne + 0.01M) * scartoIvaDetraibileInt;
                decimal IvaDetrSuppl = (IvaDetraibileOne + 0.01M) * scartoIvaDetraibileInt;
                Q2.Text = scartoIvaDetraibileInt.ToString();
                Iva2.Text = IvaSuppl.ToString("c");
                IvaDet2.Text = IvaDetrSuppl.ToString("c");

                int q3 = scartoIvaInt - scartoIvaDetraibileInt;

                decimal IvaSuppl2 = (IvaOne + 0.01M) * q3;
                decimal IvaDetrSuppl2 = IvaDetraibileOne * q3;
                Q3.Text = q3.ToString();
                Iva3.Text = IvaSuppl2.ToString("c");
                IvaDet3.Text = IvaDetrSuppl2.ToString("c");
            }




        }
        private void button1_Click(object sender, System.EventArgs e) {
            this.Close();
        }
    }
}