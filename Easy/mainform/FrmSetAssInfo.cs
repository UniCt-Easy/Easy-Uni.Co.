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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace mainform {
    public partial class FrmSetAssInfo : Form {
        public FrmSetAssInfo() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (folderBrowserDialog1.ShowDialog(this) == DialogResult.OK) {
                txtEasyFolder.Text = folderBrowserDialog1.SelectedPath;
            }

        }
        private List<String> DirSearch(string sDir) {
            List<String> files = new List<String>();
            try {
                foreach (string f in Directory.GetFiles(sDir,"*AssemblyInfo.cs")) {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir)) {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt) {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }

        void setFile(string assInfoFileName) {
            StreamReader file =new StreamReader(assInfoFileName);
            string line;
            StringBuilder sb = new StringBuilder();
            while ((line = file.ReadLine()) != null) {
                if (line.StartsWith("using System.Reflection;") ||
                    line.StartsWith("[assembly: AssemblyVersion")
                    ) {
                    sb.AppendLine(line);
                   
                }
                
            }

            file.Close();

            StreamWriter sw = new StreamWriter(assInfoFileName);
            sw.Write(sb.ToString());
            sw.Flush();
            sw.Close();

        }
        private void btnSetFileInfo_Click(object sender, EventArgs e) {
            btnSetFileInfo.Visible = false;
            List<string> allFiles = DirSearch(txtEasyFolder.Text);
            foreach (string fileName in allFiles) {
                if (fileName.EndsWith("AssemblyInfo.cs")) {
                    setFile(fileName);
                }
            }
            btnSetFileInfo.Visible = true;
        }
    }
}
