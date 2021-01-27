
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace contarighe {
	public partial class Form1 :Form {
		public Form1() {
			InitializeComponent();
		}

		void clear() {
			txtTotCartelle.Text = "";
			txtFileConsiderati.Text = "";
			barProgetti.Maximum = 0;
			barProgetti.Value = 0;
			barraFile.Maximum = 0;
			barraFile.Value = 0;
		}

		private void btnSelezionaRoot_Click(object sender, EventArgs e) {
			var res = selezionaCartella.ShowDialog(this);
			if (res != DialogResult.OK) return;
			txtRoot.Text = selezionaCartella.SelectedPath;
		}

	

		private void btnCalcola_Click(object sender, EventArgs e) {
			btnCalcola.Visible = false;
			clear();
			calcola();
			btnCalcola.Visible = true;
		}


		void calcola() {
			var allFiles =enumeraFiles(txtRoot.Text,"*.cs");
			int limite = Convert.ToInt32(txtThreeShold.Text);
			long totRighe = 0;
			long totMeta=0;
			long totFrm=0;
			long totFrm1000 = 0;
			long totrigheFrm1000 = 0;
			barraFile.Maximum = allFiles.Count;
			foreach (var f in allFiles) {
				barraFile.Increment(1);
				var righeFile=contaRighe(f);
				totRighe += righeFile;
				var fName = Path.GetFileName(f);
				if (fName.StartsWith("meta_")) totMeta+=righeFile;
				if (fName.ToLowerInvariant().StartsWith("frm")) {
					totFrm+=righeFile;
					if (righeFile >= limite) {
						totFrm1000++;
						totrigheFrm1000 += righeFile;
					}
				}
				txtRigheTotali.Text = totRighe.ToString();
				txtCodiceForm.Text = totFrm.ToString();
				txtForm1000.Text = totFrm1000.ToString();
				txtRigheForm1000.Text = totrigheFrm1000.ToString();
				txtCodiceMeta.Text = totMeta.ToString();
				Application.DoEvents();
			}
		}

		List<string> enumeraFiles(string path,string fileMask) {
			List<string> fileDaElaborare = new List<string>();
			int metaNum = 0;
			int frmNum = 0;
			var subdir = Directory.EnumerateDirectories(txtRoot.Text,"*.*",SearchOption.AllDirectories);
			List<string> alldir = subdir.ToList();
			alldir.Add(txtRoot.Text);
			txtTotCartelle.Text = alldir.Count().ToString();
			Application.DoEvents();
			barProgetti.Maximum = alldir.Count();
			barProgetti.Value = 0;
			foreach (var dir in alldir) {
				barProgetti.Increment(1);
				txtFileConsiderati.Text = fileDaElaborare.Count.ToString();
				txtMeta.Text = metaNum.ToString();
				txtForm.Text = frmNum.ToString();
				Application.DoEvents();
				var fileDir = Directory.EnumerateFiles(dir,fileMask);
				foreach (var f in fileDir) {
					var fName = Path.GetFileName(f);
					if (fName.StartsWith("vista")) continue;
					if (fName.StartsWith("AssemblyInfo")) continue;
					if (fName.StartsWith("Temporary")) continue;
					if (fName.Contains("Designer.")) continue;
					if (fName.StartsWith("meta_")) metaNum++;
					if (fName.ToLowerInvariant().StartsWith("frm")) frmNum++;
					fileDaElaborare.Add(f);
				}

			}
			txtFileConsiderati.Text = fileDaElaborare.Count.ToString();
			txtMeta.Text = metaNum.ToString();
			txtForm.Text = frmNum.ToString();
			Application.DoEvents();

			return fileDaElaborare;
		}

		long contaRighe(string fileName) {
			var f = File.ReadAllLines(fileName);
			long lines = 0;
			bool insideDesigner = false;
			foreach (var r in f) {
				if (r.Contains("Windows Form Designer generated code")) {
					insideDesigner = true;
					continue;
				}
				if (insideDesigner ) {
					if (r.Contains("#endregion"))insideDesigner = false;
					continue;
				}

				if (r.TrimStart().StartsWith("//")) continue;

				if (r.Trim() == "") continue;
				lines++;
			}

			if (insideDesigner) {
				MessageBox.Show("avviso");
			}

			return lines;
		}

		bool checkForText(string fileName,string what) {
			var f = File.ReadAllText(fileName);
			if (f.Contains(what)) return true;
			return false;
		}

		void calcolaMetodi(string fileName, Dictionary<string,int> metodi) {
			var f = File.ReadAllText(fileName);
			foreach (string metodo in metodi.Keys.ToArray()) {
				if (f.Contains(metodo)) metodi[metodo]++;
			}
		}

		private void btnCercaMsgBox_Click(object sender, EventArgs e) {
			btnCercaMsgBox.Visible = false;
			var allFiles =enumeraFiles(txtRoot.Text,"*.cs");
			long totFound = 0;
			barraFile.Maximum = allFiles.Count;
			var sb= new StringBuilder();
			foreach (var f in allFiles) {
				barraFile.Increment(1);
				if (checkForText(f,txtToSearch.Text)) {
					totFound++;
					sb.AppendLine(f);
					txtElencoMetaMsgBox.Text = sb.ToString();
					txtNFound.Text = totFound.ToString();
				}
				Application.DoEvents();
			}
			btnCercaMsgBox.Visible = true;
		}

		private void btnContaMetodi_Click(object sender, EventArgs e) {
			btnContaMetodi.Visible = false;
			var allFiles =enumeraFiles(txtRoot.Text,"frm*.cs");
			barraFile.Maximum = allFiles.Count;
			var sb= new StringBuilder();
			var metodi = new Dictionary<string, int>();
			metodi["MetaData_AfterClear"] = 0;
			metodi["MetaData_BeforeFill"] = 0;
			metodi["MetaData_AfterFill"] = 0;
			metodi["MetaData_AfterGetFormData"] = 0;
			metodi["MetaData_AfterLink"] = 0;
			metodi["MetaData_BeforeActivation"] = 0;
			metodi["MetaData_AfterActivation"] = 0;
			metodi["MetaData_BeforePost"] = 0;
			metodi["MetaData_AfterPost"] = 0;
			metodi["MetaData_BeforeRowSelect"] = 0;
			metodi["MetaData_AfterRowSelect"] = 0;
			metodi["MetaData_AfterLink"] = 0;

			foreach (var f in allFiles) {
				barraFile.Increment(1);
				calcolaMetodi(f, metodi);
				sb.Clear();
				foreach (string metodo in metodi.Keys) {
					sb.AppendLine($"{metodo}:{metodi[metodo]}");
				}
				txtMetodi.Text = sb.ToString();
				Application.DoEvents();
			}
			btnContaMetodi.Visible = true;
		}
	}
}
