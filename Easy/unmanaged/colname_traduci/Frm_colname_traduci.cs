/*
    Easy
    Copyright (C) 2020 Universit√† degli Studi di Catania (www.unict.it)
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;

namespace colname_traduci//colname//
{
	/// <summary>
	/// Summary description for FrmTraduci.
	/// </summary>
	public class Frm_colname_traduci : System.Windows.Forms.Form
	{
		private string oldTable;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtOld;
		private System.Windows.Forms.TextBox txtNew;
		private System.Windows.Forms.Button btnTraduciTutto;
		private System.Windows.Forms.Button btnTraduciSoloStringhe;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cmbNew;
		private System.Windows.Forms.ComboBox cmbOld;
		public colname_traduci.vistaForm DS;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_colname_traduci()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtOld = new System.Windows.Forms.TextBox();
			this.txtNew = new System.Windows.Forms.TextBox();
			this.cmbOld = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnTraduciTutto = new System.Windows.Forms.Button();
			this.btnTraduciSoloStringhe = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.cmbNew = new System.Windows.Forms.ComboBox();
			this.DS = new colname_traduci.vistaForm();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// txtOld
			// 
			this.txtOld.Location = new System.Drawing.Point(8, 56);
			this.txtOld.Multiline = true;
			this.txtOld.Name = "txtOld";
			this.txtOld.Size = new System.Drawing.Size(560, 768);
			this.txtOld.TabIndex = 0;
			this.txtOld.Text = "";
			// 
			// txtNew
			// 
			this.txtNew.Location = new System.Drawing.Point(576, 56);
			this.txtNew.Multiline = true;
			this.txtNew.Name = "txtNew";
			this.txtNew.Size = new System.Drawing.Size(560, 768);
			this.txtNew.TabIndex = 1;
			this.txtNew.Text = "";
			// 
			// cmbOld
			// 
			this.cmbOld.Location = new System.Drawing.Point(96, 16);
			this.cmbOld.MaxDropDownItems = 50;
			this.cmbOld.Name = "cmbOld";
			this.cmbOld.Size = new System.Drawing.Size(312, 21);
			this.cmbOld.Sorted = true;
			this.cmbOld.TabIndex = 3;
			this.cmbOld.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbOld.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			this.cmbOld.SelectedIndexChanged += new System.EventHandler(this.cmbOld_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 21);
			this.label1.TabIndex = 4;
			this.label1.Text = "Vecchia tabella:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btnTraduciTutto
			// 
			this.btnTraduciTutto.Location = new System.Drawing.Point(1000, 16);
			this.btnTraduciTutto.Name = "btnTraduciTutto";
			this.btnTraduciTutto.Size = new System.Drawing.Size(136, 23);
			this.btnTraduciTutto.TabIndex = 5;
			this.btnTraduciTutto.Text = "Traduci tutto";
			this.btnTraduciTutto.Click += new System.EventHandler(this.btnTraduciTutto_Click);
			// 
			// btnTraduciSoloStringhe
			// 
			this.btnTraduciSoloStringhe.Location = new System.Drawing.Point(840, 16);
			this.btnTraduciSoloStringhe.Name = "btnTraduciSoloStringhe";
			this.btnTraduciSoloStringhe.Size = new System.Drawing.Size(136, 23);
			this.btnTraduciSoloStringhe.TabIndex = 6;
			this.btnTraduciSoloStringhe.Text = "Traduci solo le stringhe";
			this.btnTraduciSoloStringhe.Click += new System.EventHandler(this.btnTraduciSoloStringhe_Click);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(424, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 21);
			this.label2.TabIndex = 7;
			this.label2.Text = "Nuova tabella:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// cmbNew
			// 
			this.cmbNew.Location = new System.Drawing.Point(496, 16);
			this.cmbNew.MaxDropDownItems = 50;
			this.cmbNew.Name = "cmbNew";
			this.cmbNew.Size = new System.Drawing.Size(312, 21);
			this.cmbNew.Sorted = true;
			this.cmbNew.TabIndex = 8;
			this.cmbNew.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmb_KeyDown);
			this.cmbNew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmb_KeyPress);
			this.cmbNew.SelectedIndexChanged += new System.EventHandler(this.cmbNew_SelectedIndexChanged);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// FrmTraduci
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(1144, 830);
			this.Controls.Add(this.cmbNew);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.cmbOld);
			this.Controls.Add(this.btnTraduciSoloStringhe);
			this.Controls.Add(this.btnTraduciTutto);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtNew);
			this.Controls.Add(this.txtOld);
			this.Name = "FrmTraduci";
			this.Text = "FrmTraduci";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink() {
			DataAccess dataAccess = MetaData.GetMetaData(this).Conn;

			GetData.CacheTable(DS.tablename);
			GetData.CacheTable(DS.colname);
		}

		public void MetaData_AfterClear() {
			object[] vecchi = new object[DS.tablename.Rows.Count];
			object[] nuovi = new object[DS.tablename.Rows.Count];

			for (int i=0; i<DS.tablename.Rows.Count; i++) {
				vecchi[i] = DS.tablename.Rows[i]["oldtable"];
				nuovi[i] = DS.tablename.Rows[i]["newtable"];
			}
			cmbOld.Items.AddRange(vecchi);
			cmbNew.Items.AddRange(nuovi);
		}

		/// <summary>
		/// Evento generato ad ogni pressione di tasto tale che "IsInputKey() = true"; 
		/// pertanto anche "ESC", "INVIO" e "BACKSPACE" ma non,
		/// ad esempio, "SINISTRA", "DESTRA", "HOME" e "CANC" che devono essere gestiti
		/// dall'evento "KeyDown".
		/// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
		/// </summary>
		/// <param name="sender">il ComboBox che si vuole gestire</param>
		/// <param name="e">l'evento</param>
		private void cmb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e) {
			//Se Ë stato premuto ESC o INVIO lascio la gestione dell'evento a .NET
			if ( (e.KeyChar == 27) || (e.KeyChar == 13) ) {
				return;
			}

			ComboBox acComboBox = (ComboBox) sender;

			int selectionStart = acComboBox.SelectionStart;
			if (selectionStart>acComboBox.Text.Length) selectionStart=acComboBox.Text.Length;

			//Se il tasto premuto Ë BACKSPACE, faccio cominciare la selezione un carattere prima
			//dell'inizio della selezione corrente
			if ( e.KeyChar == 8 ) {
				if (selectionStart > 0) {
					acComboBox.Select( selectionStart-1, acComboBox.Text.Length-(selectionStart-1) );
				} 
				else {
					acComboBox.SelectAll();
				}
			} 
			else {
				//Se Ë un qualunque altro carattere (quindi tale che IsInputKey()=true
				//e diverso anche da ESC, INVIO, BACK) allora lo gestisco io.

				//Cerco una riga del ComboBox che cominci per i primi "selectionStart" caratteri
				//della riga corrente concatenati col tasto premuto
				string ricerca = acComboBox.Text.Substring( 0, selectionStart ) + e.KeyChar;

				int index = acComboBox.FindString(ricerca);
			
				if ( index != -1 ) {
					//Se tale riga esiste, allora la seleziono
					if (acComboBox.SelectedIndex != index) {
						acComboBox.DroppedDown = false;
						acComboBox.SelectedIndex = index;
					}
					acComboBox.DroppedDown = true;
					if (selectionStart < acComboBox.Text.Length) {
						//e faccio cominciare la selezione da selectionstart + 1
						acComboBox.Select( selectionStart+1, acComboBox.Text.Length-(selectionStart+1) );
					}
				} 
				else {
					//Se invece tale riga non esiste, allora seleziono la riga attuale
					//dal carattere in posizione selectionStart fino alla fine
					acComboBox.DroppedDown = true;
					acComboBox.Select( selectionStart, acComboBox.Text.Length - selectionStart );
				}
			}
			//Forzo l'apertura della tendina per facilitare l'utente nella scelta
			e.Handled = true;
		}

		/// <summary>
		/// Evento generato prima di KeyPress. Lo uso per gestire la pressione dei tasti 
		/// "SINISTRA", "DESTRA", "HOME" e "CANC"
		/// che altrimenti non riuscirei ad intercettare con KeyPress.
		/// Precondizione: nel ComboBox DEVE ESSERE DropDownStyle = DropDown
		/// </summary>
		/// <param name="sender">il ComboBox da gestire</param>
		/// <param name="e">l'evento</param>
		private void cmb_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e) {
			ComboBox acComboBox = (ComboBox) sender;
			int selectionStart = acComboBox.SelectionStart;

			switch (e.KeyCode) {
					//Se Ë stato premuta la freccia "SINISTRA" faccio cominciare la selezione
					//un carattere prima rispetto alla selezione attuale
				case Keys.Left:
					if (selectionStart > 0) {
						acComboBox.Select( selectionStart-1, acComboBox.Text.Length-(selectionStart-1) );
					} 
					else {
						acComboBox.SelectAll();
					}
					break;

					//Se Ë stato premuto il tasto "CANC" seleziono la riga vuota del combobox
				case Keys.Delete:
					int index = acComboBox.FindString("");
					if ( index != -1 ) {
						acComboBox.DroppedDown = false;
						acComboBox.SelectedIndex = index;
						acComboBox.DroppedDown = true;
					} 
					acComboBox.SelectAll();
					break;

					//Se Ë stato premuta la freccia "DESTRA" faccio cominciare la selezione
					//un carattere dopo rispetto alla selezione attuale
				case Keys.Right:
					if (acComboBox.Text.Length > selectionStart) {
						acComboBox.Select( selectionStart+1, acComboBox.Text.Length-(selectionStart+1) );
					}
					break;

					//Se Ë stato premuto il tasto "HOME" seleziono tutta la riga attuale.
				case Keys.Home:
					acComboBox.SelectAll();
					break;

				default:
					//Altrimenti lascio la gestione di questo evento a .NET
					return;
			}
			e.Handled = true;
		}

		private string nuovoNomeColonna(string oldTable, string oldcol) {
			if (oldcol.StartsWith("!")) return oldcol;
			DataRow[] rColName = DS.colname.Select("oldtable='"+oldTable+"' and oldcol='"+oldcol+"'");
			if (rColName.Length==0) return oldcol;
			return rColName[0]["newcol"].ToString();
		}

		string ReplaceTableColumns(string input, string tablename){
			string output="";
			int i=0;
			while (i<input.Length){
				//Cerca l'inizio di un identificatore (sequenza di lettere e numeri iniziante con lettera
				while ((i<input.Length)&& !Char.IsLetter(input[i])){
					output+=input[i];
					i++;
				}
				//Ha trovato l'inizio di un identificatore
				if (i<input.Length){
					string buffer="";
					while ((i<input.Length)&& (Char.IsLetterOrDigit(input[i]) || (input[i]=='_'))) {
						buffer+=input[i];
						i++;
					}
					output+=nuovoNomeColonna(tablename, buffer);
				}
			}
			return output;
		}

		public int closedString(string S, int start,char stop){
			int index=start;
			while (index<S.Length){
				if (S[index]=='\\'){
					index++;
					index++;
					continue;
				}
				if (S[index]==stop){
					return index+1;
				}
				index++;
			}
			return -1;
		}

		public static int closedComment(string S,int start){
			if (S.IndexOf("*/",start)<0) return -1;
			return S.IndexOf("*/",start)+2;
		}

		public int nextNonComment(string S, int start){
			int index=start;
			while ((index<S.Length)&&(index>=0)){
				char C=S[index];

				//Salta i commenti normali
				if (C=='/'){
					try {
						//vede se Ë un commento normale ossia /* asas */
						if (S[index+1]=='*'){
							index= closedComment(S,index+2);
							continue;
						}
						if (S[index+1]=='/'){
							int next1 = S.IndexOf("\n",index);
							int next2 = S.IndexOf("\r",index);
							if ((next1==-1)&&(next2==-1)) return S.Length;
							if (next1==-1){
								index=next2+1;
								continue;
							}
							if (next2==-1){
								index=next1+1;
								continue;
							}
							if (next1<next2) 
								index=next1+1;
							else
								index=next2+1;
							continue;

						}
					}
					catch {
						return -1;
					}
				}
				if ((C==' ')||(C=='\n')||(C=='\r')||(C=='\t')){
					index++;
					continue;
				}
				return index;
			}
			
			return -1;
		}

		string traduciSoloStringhe(string S, string tablename) {
			string result = "";
			int index=0;
			while ((index>=0)&&(index<S.Length)){
				int pos = index;
				index= nextNonComment(S,index);
				if (index<0) return result+S.Substring(pos);
				result += S.Substring(pos, index-pos+1);
				char C=S[index];
				if (C=='"'){
					int inizio = index+1;
					index= closedString(S,index+1,'"');
					string costanteStringa = S.Substring(inizio, index-inizio);
					string newStr = ReplaceTableColumns(costanteStringa, tablename);
					result += newStr;
					continue;
				}
				if (C=='\''){
					int inizio = index+1;
					index= closedString(S,index+1,'\'');
					result += S.Substring(inizio, index-inizio);
					continue;
				}
				index++;
			}
			return result;
		}

		private void btnTraduciSoloStringhe_Click(object sender, System.EventArgs e) {
			if (oldTable==null) {
				MessageBox.Show(this, "Scegliere la tabella!");
				return;
			}
			txtNew.Text = traduciSoloStringhe(txtOld.Text, oldTable);
		}

		private void cmbNew_SelectedIndexChanged(object sender, System.EventArgs e) {
			object newTable = cmbNew.SelectedItem;
			DataRow[] r = DS.tablename.Select("newtable='"+newTable+"'");
			cmbOld.SelectedItem = r[0]["oldtable"];
		}

		private void cmbOld_SelectedIndexChanged(object sender, System.EventArgs e) {
			oldTable = (string) cmbOld.SelectedItem;
			DataRow[] r = DS.tablename.Select("oldtable='"+oldTable+"'");
			cmbNew.SelectedItem = r[0]["newtable"];
		}

		private void btnTraduciTutto_Click(object sender, System.EventArgs e) {
			if (oldTable==null) {
				MessageBox.Show(this, "Scegliere la tabella!");
				return;
			}
			txtNew.Text = ReplaceTableColumns(txtOld.Text, oldTable);
		}

	}
}
