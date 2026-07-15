/*
Easy
Copyright (C) 2026 Università degli Studi di Catania (www.unict.it)
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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;

namespace invoiceadditionalfields_detail {
	public partial class Frm_invoiceadditionalfields_detail : MetaDataForm {
		MetaData Meta;
		private IFormController controller;
		IDataAccess Conn;
		public Frm_invoiceadditionalfields_detail() {
			InitializeComponent();
		}
		QueryHelper QHS;
		CQueryHelper QHC;
		string lblSection = "";
		public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
			Conn = this.getInstance<IDataAccess>();
			controller = this.getInstance<IFormController>();
			QHC = new CQueryHelper();
	
			DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.invoicemultifieldkind, null, null, null, false);
			GetData.CacheTable(DS.invoicemultifieldkind);
			InizializeRdbSections();

		}


		//Valorizza le label che in realtà sono Text con il "fieldcode" di invoicemultifieldkind
		//Se il valore è già presente in "invoiceadditionalfields", lo scrive direttamente nel text, diversamente lo legge dalla 
		// tabella di configurazione per consentirne la valorizzazione

		private void InizializeRdbSections() {
			DataRow[] RR = DS.invoicemultifieldkind.Select(null, "ordernumber asc");

			if (RR.Length > 0) {
				// Estrazione valori distinti della colonna "tabname"
				var distinctTabNames = DS.invoicemultifieldkind.AsEnumerable()
										.Select(row => row.Field<string>("tabname"))
										.Distinct()
										.ToList();

				string[] distinctTabNamesArray = distinctTabNames.ToArray();


				for (int i = 0; i < distinctTabNamesArray.Length; i++) {
					string radioButtonName = "rdbTabname" + (i + 1); // rdbTabname1, rdbTabname2, ...

					// Cerca il controllo nel form (o nel container appropriato)
					Control[] controls = this.Controls.Find(radioButtonName, true);

					if (controls.Length > 0 && controls[0] is RadioButton rdb) {
						rdb.Text = Regex.Replace(distinctTabNamesArray[i], "([A-Z])", " $1").Trim();
						rdb.Tag = "invoiceadditionalfields.tabname:" + distinctTabNamesArray[i];
						if (i == 0) {
							lblSection = distinctTabNamesArray[i];
							grpTabName1.Text = rdb.Text;
							rdb.Checked = true;
							rdb.PerformClick();
						}
						else
							rdb.Checked = false;
					}
					else {
						continue;
					}
				}


				for (int i = distinctTabNamesArray.Length; i < 5; i++) {
					string radioButtonName = "rdbTabname" + (i + 1); // rdbTabname1, rdbTabname2, ...

					// Cerca il controllo nel form (o nel container appropriato)
					Control[] controls = this.Controls.Find(radioButtonName, true);

					if (controls.Length > 0 && controls[0] is RadioButton rdb) {
						rdb.Visible = false;
						rdb.Checked = false;
						rdb.Tag = null;
					}
					else {
						continue;
					}
				}
			
			}
			else {

				for (int i = 0; i < 5; i++) {
					string radioButtonName = "rdbTabname" + (i + 1); // rdbTabname1, rdbTabname2, ...

					// Cerca il controllo nel form (o nel container appropriato)
					Control[] controls = this.Controls.Find(radioButtonName, true);

					if (controls.Length > 0 && controls[0] is RadioButton rdb) {
						rdb.Visible = false;
						rdb.Tag = null;
					}
					else {
						continue;
					}
				}

			}
		}
			

		private void ManageRdbSections(object sender) {
			string name = "";
			if (sender is RadioButton radioButton) {
				name = radioButton.Name;
			}

			DataRow[] RR = DS.invoicemultifieldkind.Select(null, "ordernumber asc");

			if (RR.Length > 0) {
				// Estrazione valori distinti della colonna "tabname"
				var distinctTabNames = DS.invoicemultifieldkind.AsEnumerable()
										.Select(row => row.Field<string>("tabname"))
										.Distinct()
										.ToList();

				string[] distinctTabNamesArray = distinctTabNames.ToArray();


				for (int i = 0; i < distinctTabNamesArray.Length; i++) {
					string radioButtonName = "rdbTabname" + (i + 1); // rdbTabname1, rdbTabname2, ...

					// Cerca il controllo nel form (o nel container appropriato)
					Control[] controls = this.Controls.Find(radioButtonName, true);

					if (controls.Length > 0 && controls[0] is RadioButton rdb) {
						if (rdb.Checked && rdb.Name == name) {
							lblSection = distinctTabNamesArray[i];
							grpTabName1.Text = rdb.Text;
							break;
						}
					}
				}
			}
		}

		public void ClearLabelEField() {
			Control[] textBoxes = new Control[] { txtLabelforInt11, txtLabelforDate11, txtLabelforString11, txtLabelforString21, txtLabelforString31 };
			Control[] textBoxesValues = new Control[] {txtFieldInt1, txtFieldDate1, txtFieldString1, txtFieldString2, txtFieldString3 };
			Control[] pictureBoxes = new Control[] { pictureBoxInt11,pictureBoxDate11,pictureBoxString11,pictureBoxString21,pictureBoxString31};
			// Aggiorna il testo della TextBox corrente e il suo Tag
			for (int i = 0; i < textBoxes.Length; i++) {
				if (textBoxes[i] is TextBox textBox) {
					textBoxes[i].Text = "";
					textBoxes[i].Tag = "";
				}
			}

			for (int i = 0; i < textBoxesValues.Length; i++) {
				if (textBoxesValues[i] is TextBox textBox) {
					textBoxesValues[i].Text = "";
					textBoxesValues[i].Tag = "";
				}
			}
		}

		private class FieldControlSet {
			public List<GroupBox> GroupBoxes {
				get; set;
			}
			public List<TextBox> LabelTextBoxes {
				get; set;
			}
			public List<TextBox> ValueTextBoxes {
				get; set;
			}
			public Dictionary<Control, string> ToolTips {
				get; set;
			}
			public List<PictureBox> PictureBox {
				get; set;
			}
		}

		private void SetControlsForType(string systype, string labelPrefix, string valuePrefix, string suffix,
			FieldControlSet controls, DataRow Curr, string lblSection) {

			// Costruisce il filtro per selezionare i campi attivi della sezione corrente
			string filter = qhc.AppAnd(QHC.CmpEq("tabname", lblSection), QHC.CmpEq("systype", systype), QHC.CmpEq("active", "S"));
			DataRow[] rows = DS.invoicemultifieldkind.Select(filter, "ordernumber asc");

			// Svuota i tooltip esistenti
			if (controls.ToolTips != null)
				controls.ToolTips.Clear();

			// Per ogni controllo (GroupBox, LabelTextBox, ValueTextBox, PictureBox)
			for (int i = 0; i < controls.GroupBoxes.Count; i++) {
				if (i < rows.Length) {
					// Recupera la riga di configurazione
					DataRow row = rows[i];

					// Mostra e imposta il titolo del GroupBox
					controls.GroupBoxes[i].Visible = true;
					controls.GroupBoxes[i].Text = row["fieldname"].ToString();

					// Costruisce i nomi dei campi da leggere nel DataRow corrente
					string labelField = $"{labelPrefix}{i + 1}{suffix}";
					string valueField = $"{valuePrefix}{i + 1}{suffix}";

					// Imposta il testo e la visibilità del campo etichetta
					controls.LabelTextBoxes[i].Visible = true;
					controls.LabelTextBoxes[i].Text = (Curr[labelField] != DBNull.Value) ? Curr[labelField].ToString() : row["fieldcode"].ToString();
					controls.LabelTextBoxes[i].Tag = $"invoiceadditionalfields.{labelField}";

					// Imposta il testo e la visibilità del campo valore
					controls.ValueTextBoxes[i].Visible = true;
					controls.ValueTextBoxes[i].Text = (Curr[valueField] != DBNull.Value) ? Curr[valueField].ToString() : "";
					controls.ValueTextBoxes[i].Tag = $"invoiceadditionalfields.{valueField}";

					// Se ci sono note configurate, mostra l'icona e imposta il tooltip
					if (!string.IsNullOrWhiteSpace(row["notes"].ToString())) {
						if (controls.ToolTips == null)
							controls.ToolTips = new Dictionary<Control, string>();
						controls.ToolTips.Add(controls.PictureBox[i], row["notes"].ToString());
						controls.PictureBox[i].Visible = true;
					}
					else {
						// Nessuna nota: nasconde l'icona e rimuove eventuale tooltip associato
						controls.PictureBox[i].Visible = false;
						if ((controls.ToolTips != null) && (controls.ToolTips.ContainsKey(controls.PictureBox[i])))
							controls.ToolTips.Remove(controls.PictureBox[i]);
					}
				}
				else {
					// Se non c'è una riga di configurazione corrispondente, nasconde i controlli e rimuove Tooltip
					controls.GroupBoxes[i].Visible = false;

					controls.LabelTextBoxes[i].Visible = false;
					controls.LabelTextBoxes[i].Tag = "";

					controls.ValueTextBoxes[i].Visible = false;
					controls.ValueTextBoxes[i].Tag = "";

					if ((controls.ToolTips != null) && (controls.ToolTips.ContainsKey(controls.PictureBox[i])))
						controls.ToolTips.Remove(controls.PictureBox[i]);
					controls.PictureBox[i].Visible = false;
				}
			}

			// Applica i tooltip configurati con aspetto grafico personalizzato
			if (controls.ToolTips != null) {
				ToolTip tip = new ToolTip();
				tip.BackColor = Color.LightYellow;
				tip.ForeColor = Color.DarkBlue;
				tip.IsBalloon = true;
				tip.ToolTipTitle = "Suggerimento";
				tip.ToolTipIcon = ToolTipIcon.Info;
				tip.AutoPopDelay = 10000;
				tip.InitialDelay = 200;
				tip.ReshowDelay = 100;

				foreach (var kvp in controls.ToolTips) {
					tip.SetToolTip(kvp.Key, kvp.Value);
				}
			}
		}

		public void ValorizzaLabelEField() {
			if (Meta.IsEmpty)
				return;

			DataRow Curr = DS.invoiceadditionalfields.Rows[0];
			if (Meta.EditMode)
				lblSection = Curr["tabname"].ToString();

			string filterDoc = qhc.AppAnd(QHC.CmpEq("tabname", lblSection));
			DataRow[] RR = DS.invoicemultifieldkind.Select(filterDoc, "ordernumber asc");

			if (RR.Length > 0) {
				grpTabName1.Text = Regex.Replace(lblSection, "([A-Z])", " $1").Trim();

				if (controller.InsertMode) {
					Curr["documentkind"] = RR[0]["documentkind"].ToString();
					Curr["tabname"] = lblSection;
				}
			}

			// INT
			SetControlsForType("int", "labelfield", "valuefield", "int", new FieldControlSet {
				GroupBoxes = new List<GroupBox> { grpInt11 },
				LabelTextBoxes = new List<TextBox> { txtLabelforInt11 },
				ValueTextBoxes = new List<TextBox> { txtFieldInt1 },
				PictureBox = new List<PictureBox> { pictureBoxInt11}
			}, Curr, lblSection);

			// STRING
			SetControlsForType("string", "labelfield", "valuefield", "str", new FieldControlSet {
				GroupBoxes = new List<GroupBox> { grpString11, grpString21, grpString31 },
				LabelTextBoxes = new List<TextBox> { txtLabelforString11, txtLabelforString21, txtLabelforString31 },
				ValueTextBoxes = new List<TextBox> { txtFieldString1, txtFieldString2, txtFieldString3 },
				PictureBox = new List<PictureBox> { pictureBoxString11, pictureBoxString21, pictureBoxString31 }
			}, Curr, lblSection);

			// DATE
			SetControlsForType("date", "labelfield", "valuefield", "date", new FieldControlSet {
				GroupBoxes = new List<GroupBox> { grpDate11 },
				LabelTextBoxes = new List<TextBox> { txtLabelforDate11 },
				ValueTextBoxes = new List<TextBox> { txtFieldDate1 },
				PictureBox = new List<PictureBox> { pictureBoxDate11 }
			}, Curr, lblSection);

			// Post-assegnazione valori speciali in edit mode
			if (!controller.InsertMode) {
				txtFieldInt1.Text = HelpForm.StringValue(Curr["valuefield1int"], txtFieldInt1.Tag?.ToString());
				txtFieldDate1.Text = HelpForm.StringValue(Curr["valuefield1date"], txtFieldDate1.Tag?.ToString());
			}
		}

		
		public void MetaData_AfterFill() {
			if (Meta.EditMode)
				grpTabName.Enabled = false;
			else
				grpTabName.Enabled = true;
			ValorizzaLabelEField();
		}

		public void MetaData_AfterGetFormData() {
			if (DS.invoiceadditionalfields.Rows.Count == 0) return;
			DataRow Curr = DS.invoiceadditionalfields.Rows[0];
			if (Curr["valuefield1int"] == DBNull.Value) {
				Curr["labelfield1int"] = DBNull.Value;
			}
			if (Curr["valuefield1str"] == DBNull.Value) {
				Curr["labelfield1str"] = DBNull.Value;
			}
			if (Curr["valuefield2str"] == DBNull.Value) {
				Curr["labelfield2str"] = DBNull.Value;
			}

			if (Curr["valuefield3str"] == DBNull.Value) {
				Curr["labelfield3str"] = DBNull.Value;
			}
			if (Curr["valuefield1date"] == DBNull.Value) {
				Curr["labelfield1date"] = DBNull.Value;
			}
		}

		private void RdbTabname_CheckedChanged(object sender, EventArgs e) {
			if (!(sender is RadioButton rdb) || !rdb.Checked)
				return;

			ManageRdbSections(rdb);
			ClearLabelEField();
			ValorizzaLabelEField();

		}


		private void rdbTabname1_CheckedChanged(object sender, EventArgs e) {
			RdbTabname_CheckedChanged(sender,e);
		}

		private void rdbTabname2_CheckedChanged(object sender, EventArgs e) {
			RdbTabname_CheckedChanged(sender,e);
		}
	}
}
