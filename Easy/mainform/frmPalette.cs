
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
using System.Reflection;
using System.Diagnostics;

namespace mainform {
    public partial class frmPalette : Form {
        public frmPalette(int dummy) {
            InitializeComponent();
            if (Debugger.IsAttached)
                btnCode.Visible = true;
            myPalette = new ColorPalette();
            myPalette.SetTo(formcolors.metaPalette);

            InizializzaColori(myPalette);

            foreach (Control C1 in this.Controls) {
                Button B = C1 as Button;
                if (B == null)
                    continue;
                if (B.Tag == null)
                    continue;
                if (B.Tag.ToString() == "-")
                    continue;
                B.Click += B_Click;
            }
        }
        List<string> colorList;
        ColorPalette myPalette;


        public static ColorPalette LoadFromFilename(string fname) {
            try {
                ColorPalette CP = new ColorPalette();
                DataSet D = new DataSet();
                D.ReadXml(fname);
                DataTable T = D.Tables[0];
                DataRow R = T.Rows[0];

                foreach (DataColumn C in T.Columns) {
                    FieldInfo f = typeof(ColorPalette).GetField(C.ColumnName);
                    string[] rgb = R[C.ColumnName].ToString().Split(';');
                    if (rgb.Length != 3) continue;
                    int r = Convert.ToInt32(rgb[0]);
                    int g = Convert.ToInt32(rgb[1]);
                    int b = Convert.ToInt32(rgb[2]);
                    f.SetValue(CP, Color.FromArgb(r, g, b));
                }
                return CP;
            }
            catch (Exception e) {
                QueryCreator.ShowException("Errori nel caricamento della palette, il file non è valido", e);
                return null;
            }
        }

        public static void SaveToFilename(ColorPalette CP, string fname) {
            DataSet D = new DataSet();
            DataTable T = new DataTable("colori");
            FieldInfo[] all_f = typeof(ColorPalette).GetFields();
            foreach (FieldInfo f in all_f) {
                T.Columns.Add(f.Name);
            }
            DataRow R = T.NewRow();
            foreach (FieldInfo f in all_f) {
                Color c = (Color)f.GetValue(CP);
                R[f.Name] = c.R.ToString() + ";" + c.G.ToString() + ";" + c.B.ToString();
            }
            T.Rows.Add(R);
            D.Tables.Add(T);
            D.WriteXml(fname,XmlWriteMode.IgnoreSchema);
        }


        void InizializzaColori(ColorPalette cp) {
            colorList = new List<string>();
            foreach (Control C1 in this.Controls)
            {
                Button B = C1 as Button;
                if (B == null)
                    continue;
                if (B.Tag == null)
                    continue;
                if (B.Tag.ToString() == "-")
                    continue;
                  string tag = B.Tag.ToString().Trim();
                  B.Tag = tag;
                  Color c = LeggiColorePalette(cp,tag);
                  SetSampleColor(tag, c);
                  colorList.Add(tag);
            }
        }

        void SetSampleColor(string colorname, Color C) {
            foreach (Control C1 in this.Controls) {
                Button B = C1 as Button;
                if (B == null)
                    continue;
                if (B.Text.ToString().Trim() != "")
                    continue;
                string tag = B.Tag.ToString().Trim();
                if (tag != colorname)
                    continue;
                B.BackColor=C;
                return;
            }
        }

        void B_Click(object sender, EventArgs e) {
            Button B = sender as Button;
            if (B == null)
                return;
            if (B.Tag == null)
                return;
            string tag = B.Tag.ToString();
            ScegliColore(tag);
            

        }

        



        void ScegliColore(string tag) {
            Color c = LeggiColorePalette(myPalette, tag);
            colorDialog1.Color = c;            
            DialogResult D = colorDialog1.ShowDialog(this);
            if (D != DialogResult.OK)
                return;
            SetSampleColor(tag, colorDialog1.Color);
            ImpostaColorePalette(myPalette, tag, colorDialog1.Color);
        }


        
        void ImpostaColorePalette(ColorPalette CP, string colorname, Color c) {
            FieldInfo f = typeof(ColorPalette).GetField(colorname);
            f.SetValue(CP, c);
        }
        Color LeggiColorePalette(ColorPalette CP, string colorname) {
            FieldInfo f = typeof(ColorPalette).GetField(colorname);
            return (Color)f.GetValue(CP);
                
        }

        /// <summary>
        /// Ripristina valori classici
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button22_Click(object sender, EventArgs e) {
            ColorPalette c = new ColorPalette("old");
            myPalette.SetTo(c);
            InizializzaColori(myPalette);

        }

        private void btnModerno_Click(object sender, EventArgs e) {
            ColorPalette c = new ColorPalette("modern");
            myPalette.SetTo(c);
            InizializzaColori(myPalette);
        }

        private void btnTry_Click(object sender, EventArgs e) {
            formcolors.metaPalette.SetTo(myPalette);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void button31_Click(object sender, EventArgs e) {
            string currdir = AppDomain.CurrentDomain.BaseDirectory;
            if (!currdir.EndsWith("\\"))
                currdir += "\\";
            string fname = currdir + "customcolor.xml";
            formcolors.metaPalette.SetTo(myPalette);
            SaveToFilename(myPalette, fname);
            MessageBox.Show(this, "Salvataggio effettuato.", "Avviso");
            EventArgs a = new EventArgs();
                       
            this.Close();
        }

        /// <summary>
        /// Carica da file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button24_Click(object sender, EventArgs e) {
            DialogResult rr= openFileDialog1.ShowDialog(this);
            if (rr != DialogResult.OK)
                return;
            string fname = openFileDialog1.FileName;
            ColorPalette cp = LoadFromFilename(fname);
            if (cp == null) return;
            myPalette.SetTo(cp);
            InizializzaColori(myPalette);
            MessageBox.Show(this, "Caricamento effettuato", "Avviso");
        }

        private void btnSave_Click(object sender, EventArgs e) {
            DialogResult rr = saveFileDialog1.ShowDialog(this);
            if (rr != DialogResult.OK)
                return;
            string fname = saveFileDialog1.FileName;
            SaveToFilename(myPalette, fname);
            MessageBox.Show(this,"Salvataggio effettuato", "Avviso");
        }

        private void btnOfficeLike_Click(object sender, EventArgs e) {
            myPalette.ButtonBackColor = Color.FromArgb(176, 196, 222);
            myPalette.AutoChooseBackColor = Color.FromArgb(224, 224, 224);
            myPalette.MainFormBackColor = Color.FromArgb(224, 224, 224);
            myPalette.GridBackgroundColor = Color.FromArgb(230, 230, 230);
            myPalette.DisabledButtonForeColor = Color.FromArgb(0, 0, 128);
            myPalette.DisabledButtonBackColor = Color.FromArgb(221, 221, 221);
            myPalette.GridButtonForeColor = Color.FromArgb(0, 0, 128);
            myPalette.GridButtonBackColor = Color.FromArgb(176, 196, 222);
            myPalette.TextBoxReadOnlyBackColor = Color.FromArgb(235, 235, 235);
            myPalette.TextBoxReadOnlyForeColor = Color.FromArgb(0, 0, 0);
            myPalette.TextBoxNormalBackColor = Color.FromArgb(255, 255, 255);
            myPalette.TextBoxNormalForeColor = Color.FromArgb(25, 25, 112);
            myPalette.TextBoxEditingBackColor = Color.FromArgb(255, 255, 176);
            myPalette.TextBoxEditingForeColor = Color.FromArgb(0, 0, 0);
            myPalette.ButtonForeColor = Color.FromArgb(0, 0, 128);
            myPalette.TabControlHeaderColor = Color.FromArgb(255, 255, 255);
            myPalette.GridForeColor = Color.FromArgb(0, 0, 0);
            myPalette.GridBackColor = Color.FromArgb(255, 255, 255);
            myPalette.GridAlternatingBackColor = Color.FromArgb(243, 243, 243);
            myPalette.GridSelectionForeColor = Color.FromArgb(0, 0, 0);
            myPalette.GridSelectionBackColor = Color.FromArgb(255, 255, 176);
            myPalette.GridHeaderForeColor = Color.FromArgb(25, 25, 112);
            myPalette.GridHeaderBackColor = Color.FromArgb(176, 196, 222);
            myPalette.GboxBorderColor = Color.FromArgb(70, 130, 180);
            myPalette.GboxForeColor = Color.FromArgb(25, 25, 112);
            myPalette.TreeForeColor = Color.FromArgb(25, 25, 112);
            myPalette.TreeBackColor = Color.FromArgb(255, 255, 255);
            myPalette.MainForeColor = Color.FromArgb(25, 25, 112);
            myPalette.MainBackColor = Color.FromArgb(255, 255, 255);

            InizializzaColori(myPalette);

        }

        private void btnCode_Click(object sender, EventArgs e) {
            string s = "";
            foreach (Control C1 in this.Controls) {
                Button B = C1 as Button;
                if (B == null)
                    continue;
                string tag = B.Tag.ToString().Trim();
                if (tag == "-")
                    continue;
                if (B.Text.Trim() == "")
                    continue;
                Color C = LeggiColorePalette(myPalette, tag);
                s += "myPalette." + tag + "  = Color.FromArgb(" +
                    C.R.ToString() + "," + C.G.ToString() + "," + C.B.ToString() + ");\r\n";
            }
            Clipboard.SetText(s);
        }


    }
}
