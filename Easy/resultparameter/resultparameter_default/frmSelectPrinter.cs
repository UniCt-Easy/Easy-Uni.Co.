
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using metadatalibrary;

namespace resultparameter_default {
    public partial class frmSelectPrinter : MetaDataForm {
        public frmSelectPrinter(string papersize) {
            InitializeComponent();
            PrintDocument pd = new PrintDocument();
            string defprn = pd.PrinterSettings.PrinterName;
            bool found = false;

            string selectedA3Printer = null;
            try {
                foreach (string prn in PrinterSettings.InstalledPrinters) {
                    int NSupported = 0;
                    if (papersize == "A3") {
                        PrintDocument pdoc = new PrintDocument();
                        pdoc.PrinterSettings.PrinterName = prn;
                        foreach (System.Drawing.Printing.PaperSize PS in pdoc.PrinterSettings.PaperSizes) {
                            if (PS.PaperName.ToString() == "A3") {
                                NSupported++;
                                if (selectedA3Printer == null) selectedA3Printer = prn;
                                if (pdoc.PrinterSettings.IsDefaultPrinter) selectedA3Printer = prn;
                            }
                        }
                        if (NSupported == 0) continue;
                    }
                    cmbPrn.Items.Add(prn);
                }
            }
            catch { ////System.ComponentModel.Win32Exception (0x80004005): Server RPC non disponibile
            }
            if (papersize == "A3") {
                if (selectedA3Printer != null) defprn = selectedA3Printer;
            }
            if (defprn != null) {
                cmbPrn.SelectedIndex = cmbPrn.Items.IndexOf(defprn);
            }
        }
    }
}
