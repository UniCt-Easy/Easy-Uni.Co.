
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
using System.Text.RegularExpressions;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;

namespace mandate_default {
    public partial class FrmUpdConsipMotive : MetaDataForm {
        string template_to_compile;
        public string template_compiled;
        DataTable consip_category;
        CQueryHelper QHC;
        public FrmUpdConsipMotive(string template, string consipmotive, DataTable category) {
            InitializeComponent();
            QHC = new CQueryHelper();
            this.template_to_compile = template;
            this.consip_category = category;
            FillControlsFromTemplate();
            List<string> l = new List<string>();
            Dictionary<string, string> start = decodifica(template, consipmotive);
            foreach(string k in start.Keys) {
                if (start[k] == "%<" + k + ">%") {
                    l.Add(k);
                }
            }
            foreach(string toClear in l) {
                start[toClear] = "";
            }
            UpdateTemplateFromDictionary(start);
            txtDescrizione.Text = consipmotive;
        }

        List<string> calcola(string s) {
            List<string> l = new List<string>();
            int start = 0;
            int index = s.IndexOf("%<", start);
            while (index > 0) {
                int closing = s.IndexOf(">%", index + 2);
                if (closing < 0) break;
                l.Add(s.Substring(index + 2, closing - (index + 2)));
                start = index + 2;
                index = s.IndexOf("%<", start);
            }
            return l;
        }


        public TextBox AddTextBoxToForm(GroupBox G, int x, int y, string tipo) {
            TextBox T = new TextBox();
                       
            
            T.Location = new Point(230 + x, 20 + y);
            T.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
            T.Name = "txt_" + Ncontrol.ToString();
            if (tipo == "c") {
                T.Tag = "x.y.c";
                T.GotFocus += new System.EventHandler(HelpForm.EnterDecTextBox);
                T.Leave += new System.EventHandler(HelpForm.LeaveDecTextBox);
                T.Multiline = false;
                T.Size = new Size(350, 10);
                T.TextAlign = HorizontalAlignment.Right;
            }
            else {
                if (tipo == "n") {
                    T.Tag = "x.y.n";
                    T.GotFocus += new System.EventHandler(HelpForm.EnterNumTextBox);
                    T.Leave += new System.EventHandler(HelpForm.LeaveNumTextBox);
                    T.Multiline = false;
                    T.Size = new Size(350, 10);
                    T.TextAlign = HorizontalAlignment.Right;
                }
                else {
                    T.Multiline = true;
                    T.Size = new Size(350, 40);
                    T.ScrollBars = ScrollBars.Vertical;
                }
            }
            Ncontrol++;
            T.Leave += new System.EventHandler(this.txt_Leave);
            G.Controls.Add(T);
            return T;
        }

        public ComboBox AddComboBoxToForm(GroupBox G,int x, int y) {
            ComboBox C = new ComboBox();
            C.Size = new Size(350, 20);
            C.Location = new Point(230 + x, 20 + y);
            C.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
            C.Name = "cmb_" + Ncontrol.ToString();
            C.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Ncontrol++;
            C.Items.Add("");
            foreach (DataRow R in this.consip_category.Select(QHC.CmpEq("active", "S"))) {
                C.Items.Add(R["description"]);
            }
            C.SelectedIndexChanged += new System.EventHandler(this.ComboBoxCategory_SelectedIndexChanged);
            G.Controls.Add(C);
            return C;
        }

        public GroupBox AddGroupBoxToForm(int x, int y) {
            GroupBox G = new GroupBox();
            G.Size = new Size(this.groupBox1.Width, 3 * this.Height / 4);
            G.Location = new Point(10 + x, 120 + y);
            G.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right)));
            this.Controls.Add(G);
            return G;
        }

        public Label AddLabelToForm(GroupBox G, string token, int x, int y) {
            Label L = new Label();
            L.Size = new Size(200, 20);
            L.Location = new Point(5 + x, 20 + y);
            L.Anchor = ((AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left)));
            L.Text = token;
            L.Name = "lbl_" + token;
            G.Controls.Add(L);
            return L;
        }
        List<string> token;
        Dictionary<string, TextBox> myTextBoxList = new Dictionary<string, TextBox>();
        Dictionary<string, ComboBox> myComboBoxList = new Dictionary<string, ComboBox>();

        int Ncontrol = 1;
        void FillControlsFromTemplate() {

            token = calcola(template_to_compile);
            int x = 0;
            int y = 0;
            GroupBox G = AddGroupBoxToForm(x, y);
            //string res = "";
            //foreach (string o in lt) res += o + "\r\n";
            //foreach (string o in lb) res += o + "\r\n";
            //txtOutput.Text = res;
            y += 10;
            foreach (string k in token) { // Desegno Texbox
                if (k.ToLower().Trim() == "categoria") {
                    Label L = AddLabelToForm(G, k, x, y);
                    ComboBox C = AddComboBoxToForm(G, x, y);
                    myComboBoxList[k] = C;
                    y += 40;
                }
                else {                  //G.Add(TP);                    
                    Label L = AddLabelToForm(G, k, x, y);
                    string tipo = "g";
                    string kl = k.ToLower();      
                    if (kl.Contains("€") || kl.Contains("euro") || kl.Contains("importo") 
                                        || kl.Contains("prezzo") || kl.Contains("costo")){
                        tipo = "c";                    
                    }
                    if (kl.Contains("quantità") || kl.Contains("quantita") || kl.Contains("numero") ) {
                        tipo = "n";
                    }
                    TextBox T = AddTextBoxToForm(G, x, y,tipo);
                    myTextBoxList[k] = T;
                    y += T.Height;
                }
                Ncontrol++;
            }


            this.Refresh();
        }
        void UpdateTemplateFromDictionary(Dictionary<string, string> start) {
            foreach (string k in start.Keys) {
                if (k.Trim().ToLower() == "categoria") {
                    myComboBoxList[k].SelectedItem = start[k];
                }
                else {
                    myTextBoxList[k].Text = start[k];
                }
            }

        }
        void UpdateTemplateFromControls() {
            string s = this.template_to_compile;
            foreach (string k in token) {
                string valore;
                if (k.Trim().ToLower() == "categoria") {
                    if (myComboBoxList[k].SelectedItem != null) {
                        valore = myComboBoxList[k].SelectedItem.ToString();
                        s = s.Replace("%<" + k + ">%", valore);
                    }
                }
                else {

                    valore = myTextBoxList[k].Text;
                    s = s.Replace("%<" + k + ">%", valore);
                }
            }

            this.template_compiled = s;
            txtDescrizione.Text = s;
        }

        private void btnOk_Click(object sender, EventArgs e) {
            UpdateTemplateFromControls();
        }

        private void txt_Leave(object sender, EventArgs e) {
            //string s = template_to_compile;
            //TextBox T = (TextBox)sender;
            //string token = T.Name.Substring(4, T.Name.Length - 4);
            //string valore;
            //valore = myTextBoxList[token].Text;
            //s = s.Replace("%<" + token + ">%", valore);
            //txtDescrizione.Text = s;
            UpdateTemplateFromControls();
        }

        private void ComboBoxCategory_SelectedIndexChanged(object sender, EventArgs e) {
            //string s = template_to_compile;
            //ComboBox C = (ComboBox)sender;
            //string token = C.Name.Substring(4, C.Name.Length - 4);
            //string valore;
            //valore = myComboBoxList[token].SelectedItem.ToString();
            //s = s.Replace("&<" + token + ">&", valore);
            //txtDescrizione.Text = s;
            UpdateTemplateFromControls();
        }

        string calcolaRegExp(string template) {
            string R = "";
            int start = 0;
            int index = template.IndexOf("%<", start);
            int lastPos = 0;
            while (index > 0) {
                if (lastPos != index) {
                    if (lastPos == 0) {
                        //R = "^";
                    }
                    string before = template.Substring(lastPos, index - lastPos);
                    R += Regex.Escape(before);
                }
                int closing = template.IndexOf(">%", index + 2);
                if (closing < 0) break;
                R += @"([\w\W]*)";
                start = closing + 2;
                lastPos = start;
                index = template.IndexOf("%<", start);
            }
            if (lastPos < template.Length) {
                R += Regex.Escape(template.Substring(lastPos));
            }
            return R;
        }

        Dictionary<string, string> decodifica(string template, string s) {
            List<string> l = calcola(template);
            Dictionary<string, string> res = new Dictionary<string, string>();
            Regex r = new Regex(calcolaRegExp(template));
            Match m = r.Match(s);
            for (int i = 1; i < m.Groups.Count; i++) {
                res[l[i - 1]] = m.Groups[i].Value;
            }

            return res;
        }

        private void FrmUpdConsipMotive_FormClosed(object sender, FormClosedEventArgs e) {
            MetaData.UnregisterAllEvents(this);
        }
    }
}
