
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.Data;
using System.IO;
using exportdata;//exportdata
using funzioni_configurazione;//funzioni_configurazione
using System.Security.Cryptography;

namespace trasmissioneritenute//trasmissioneritenute//
{
	/// <summary>
	/// Summary description for FrmTrasmissioneRitenute.
	/// </summary>
	public class Frm_trasmissioneritenute : System.Windows.Forms.Form
	{
		private MetaData Meta;
		private DataTable tSomme;
		private System.Windows.Forms.TextBox txtNumeroTrasmissione;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkTrasmConfermata;
		public /*Rana:trasmissioneritenute.*/vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnInserisci;
		private System.Windows.Forms.Button btnRimuovi;
		private System.Windows.Forms.Button btnModifica;
		private System.Windows.Forms.Button btnEsporta;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.DataGrid gridDettagli;
		private System.Windows.Forms.DataGrid gridSomme;
		private System.Windows.Forms.Button btnVerifica;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtPathFile;
//		private System.Windows.Forms.ComboBox cmbRitenuta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		public Frm_trasmissioneritenute()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			HelpForm.SetDenyNull(DS.trasmissioneritenute.flagconfermaColumn, true);
			QueryCreator.SetTableForPosting(DS.payedtaxview, "dettaglioritenute");

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
			this.txtNumeroTrasmissione = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.chkTrasmConfermata = new System.Windows.Forms.CheckBox();
			this.DS = new /*Rana:trasmissioneritenute.*/vistaForm();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnRimuovi = new System.Windows.Forms.Button();
			this.btnInserisci = new System.Windows.Forms.Button();
			this.btnModifica = new System.Windows.Forms.Button();
			this.gridDettagli = new System.Windows.Forms.DataGrid();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.gridSomme = new System.Windows.Forms.DataGrid();
			this.btnEsporta = new System.Windows.Forms.Button();
			this.btnVerifica = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPathFile = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridSomme)).BeginInit();
			this.SuspendLayout();
			// 
			// txtNumeroTrasmissione
			// 
			this.txtNumeroTrasmissione.Location = new System.Drawing.Point(152, 24);
			this.txtNumeroTrasmissione.Name = "txtNumeroTrasmissione";
			this.txtNumeroTrasmissione.Size = new System.Drawing.Size(72, 20);
			this.txtNumeroTrasmissione.TabIndex = 0;
			this.txtNumeroTrasmissione.Tag = "trasmissioneritenute.idtrasmissioneritenute";
			this.txtNumeroTrasmissione.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(144, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "N° di trasmissione";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chkTrasmConfermata
			// 
			this.chkTrasmConfermata.Location = new System.Drawing.Point(392, 16);
			this.chkTrasmConfermata.Name = "chkTrasmConfermata";
			this.chkTrasmConfermata.Size = new System.Drawing.Size(152, 24);
			this.chkTrasmConfermata.TabIndex = 3;
			this.chkTrasmConfermata.Tag = "trasmissioneritenute.flagconferma:S:N";
			this.chkTrasmConfermata.Text = "Trasmissione confermata";
			this.chkTrasmConfermata.CheckedChanged += new System.EventHandler(this.chkTrasmConfermata_CheckedChanged);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.tabControl1);
			this.groupBox1.Location = new System.Drawing.Point(8, 80);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(640, 336);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dettaglio ritenute da trasmettere";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(8, 16);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(624, 312);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnRimuovi);
			this.tabPage1.Controls.Add(this.btnInserisci);
			this.tabPage1.Controls.Add(this.btnModifica);
			this.tabPage1.Controls.Add(this.gridDettagli);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(616, 286);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Dettagli";
			// 
			// btnRimuovi
			// 
			this.btnRimuovi.Location = new System.Drawing.Point(120, 8);
			this.btnRimuovi.Name = "btnRimuovi";
			this.btnRimuovi.Size = new System.Drawing.Size(75, 24);
			this.btnRimuovi.TabIndex = 1;
			this.btnRimuovi.Tag = "unlink";
			this.btnRimuovi.Text = "Rimuovi";
			// 
			// btnInserisci
			// 
			this.btnInserisci.Location = new System.Drawing.Point(8, 8);
			this.btnInserisci.Name = "btnInserisci";
			this.btnInserisci.Size = new System.Drawing.Size(75, 24);
			this.btnInserisci.TabIndex = 0;
			this.btnInserisci.Tag = "choose.payedtaxview.trasmissione.(idtrasmissioneritenute is null)";
			this.btnInserisci.Text = "Inserisci";
			// 
			// btnModifica
			// 
			this.btnModifica.Location = new System.Drawing.Point(232, 8);
			this.btnModifica.Name = "btnModifica";
			this.btnModifica.Size = new System.Drawing.Size(75, 24);
			this.btnModifica.TabIndex = 2;
			this.btnModifica.Text = "Modifica";
			this.btnModifica.Click += new System.EventHandler(this.btnModifica_Click);
			// 
			// gridDettagli
			// 
			this.gridDettagli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridDettagli.DataMember = "";
			this.gridDettagli.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridDettagli.Location = new System.Drawing.Point(8, 40);
			this.gridDettagli.Name = "gridDettagli";
			this.gridDettagli.Size = new System.Drawing.Size(600, 240);
			this.gridDettagli.TabIndex = 3;
			this.gridDettagli.Tag = "payedtaxview.trasmissione";
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.gridSomme);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(616, 262);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Somme";
			// 
			// gridSomme
			// 
			this.gridSomme.DataMember = "";
			this.gridSomme.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridSomme.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridSomme.Location = new System.Drawing.Point(0, 0);
			this.gridSomme.Name = "gridSomme";
			this.gridSomme.Size = new System.Drawing.Size(616, 262);
			this.gridSomme.TabIndex = 0;
			// 
			// btnEsporta
			// 
			this.btnEsporta.Location = new System.Drawing.Point(552, 16);
			this.btnEsporta.Name = "btnEsporta";
			this.btnEsporta.Size = new System.Drawing.Size(96, 23);
			this.btnEsporta.TabIndex = 4;
			this.btnEsporta.Text = "Esporta in un file";
			this.btnEsporta.Click += new System.EventHandler(this.btnEsporta_Click);
			// 
			// btnVerifica
			// 
			this.btnVerifica.Location = new System.Drawing.Point(248, 16);
			this.btnVerifica.Name = "btnVerifica";
			this.btnVerifica.Size = new System.Drawing.Size(120, 24);
			this.btnVerifica.TabIndex = 2;
			this.btnVerifica.Text = "Verifica trasmissione";
			this.btnVerifica.Click += new System.EventHandler(this.btnVerifica_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(16, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "trasmissioneritenute.eserciziocompetenza.year";
			this.textBox1.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(136, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "Esercizio di Competenza";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 48);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Percorso File Salvato:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtPathFile
			// 
			this.txtPathFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtPathFile.Location = new System.Drawing.Point(120, 48);
			this.txtPathFile.Name = "txtPathFile";
			this.txtPathFile.ReadOnly = true;
			this.txtPathFile.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtPathFile.Size = new System.Drawing.Size(528, 20);
			this.txtPathFile.TabIndex = 9;
			this.txtPathFile.TabStop = false;
			this.txtPathFile.Text = "";
			// 
			// FrmTrasmissioneRitenute
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(656, 422);
			this.Controls.Add(this.btnVerifica);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPathFile);
			this.Controls.Add(this.txtNumeroTrasmissione);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnEsporta);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.chkTrasmConfermata);
			this.Name = "FrmTrasmissioneRitenute";
			this.Text = "FrmTrasmissioneRitenute";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridDettagli)).EndInit();
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridSomme)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			impostaColonneTSomme();

		}

		string flagConferma = "";
		bool inCancellazione = false;
		public void MetaData_BeforePost()
		{	
			if (DS.trasmissioneritenute.Rows[0].RowState == DataRowState.Deleted)
			{
				inCancellazione = true;
				return;
			}
			inCancellazione = false;
			DataRow curr = DS.trasmissioneritenute[0];
			flagConferma = curr["flagconferma"].ToString();
			curr["flagconferma"] = "N";
		}

		private bool verificaTrasmissione()
		{
			object idtrasmissioneritenute = DS.trasmissioneritenute[0]["idtrasmissioneritenute"];
			DataSet dsCheck1 = Meta.Conn.CallSP("checkanagrafica_pertrasmissioneritenute",
				new object[] {idtrasmissioneritenute,"E"}, false, 0);
			DataSet dsCheck2 = Meta.Conn.CallSP("checkritenute_pertrasmissioneritenute",
				new object[] {idtrasmissioneritenute,"E"},false,0);
				
			DataTable dtCheck1 = (dsCheck1 != null) ? dsCheck1.Tables[0] : new DataTable();
			DataTable dtCheck2 = (dsCheck2 != null) ? dsCheck2.Tables[0] : new DataTable();

			bool esistonoRighe = ((dtCheck1.Rows.Count != 0) || (dtCheck2.Rows.Count != 0));
			if (esistonoRighe)
			{
				SubForm form = new SubForm(dtCheck1,dtCheck2);
				form.ShowDialog();//(LinkedForm);
				string messaggio = "Attenzione! la trasmissione non può essere confermata in quanto si sono verificati errori in : ";
				if (dtCheck1.Rows.Count > 0) messaggio += "CONTROLLO ANAGRAFICA ";
				if (dtCheck2.Rows.Count > 0) messaggio += "CONTROLLO RITENUTE ";
				MessageBox.Show(messaggio,"Attenzione",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return false;
			}
				return true;
		}

		public void MetaData_AfterPost()
		{
			if (inCancellazione) return;
			if (flagConferma == "N") return;
			bool isSalvabile = verificaTrasmissione();
			if (isSalvabile)
			{
				DialogResult dr = MessageBox.Show(this, @"Si è scelto di confermare la trasmissione.
	Se si continua nel salvataggio non sarà più possibile modificare i dettagli delle ritenute inclusi in questa trasmissione.
	Confermare l'operazione?", "Attenzione!", MessageBoxButtons.YesNoCancel);
				if (dr == DialogResult.Yes)
				{
					DS.trasmissioneritenute.Rows[0]["flagconferma"] = flagConferma;
					PostData pd = Meta.Get_PostData();
					pd.InitClass(DS, Meta.Conn);

					if (!pd.DO_POST())
					{
						MessageBox.Show(this, "Errore nel salvataggio della conferma");
						return;
					}
					if (DS.HasChanges())
					{
						MessageBox.Show("Errore nel salvataggio della conferma");
					}
				}
			}
		}

		private void impostaColonneTSomme()
		{
			// Tabella tSomme
			tSomme = new DataSet().Tables.Add();
			tSomme.Columns.Add("esercmovimento");
			tSomme.Columns.Add("codiceritenuta");
			tSomme.Columns.Add("denominazione");
			tSomme.Columns.Add("descrizione");
			tSomme.Columns.Add("imponibile");
			tSomme.Columns.Add("ritdipendente");
			tSomme.Columns.Add("ritamministrazione");
			tSomme.Columns["denominazione"].Caption = "Creditore";
			tSomme.Columns["descrizione"].Caption = "Ritenuta";
			tSomme.Columns["taxable"].Caption = "Imponibile";
			tSomme.Columns["employtax"].Caption = "Riten. dipend.";
			tSomme.Columns["admintax"].Caption = "Riten. ammin.";
			tSomme.Columns["ymov"].Caption = "Esercizio";
			tSomme.Columns["taxcode"].Caption = "Cod. ritenuta";
		}

		public void MetaData_AfterClear()
		{
			chkTrasmConfermata.Enabled = true;
			btnEsporta.Enabled = false;
			txtPathFile.Text = "";
		}

//		public void MetaData_BeforeFill() 
//		{
//			if (Meta.FirstFillForThisRow) 
//			{
//				vistaForm.tiporitenutaRow r = DS.tiporitenuta.NewtiporitenutaRow();
//				r["codiceritenuta"] = "tutte";
//				r["descrizione"] = "TUTTE LE RITENUTE";
//				r["createuser"] = "";
//				r["lastmoduser"] = "";
//				r["createtimestamp"] = new DateTime();
//				r["lastmodtimestamp"] = new DateTime();
//				DS.tiporitenuta.AddtiporitenutaRow(r);
//				DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.tiporitenuta, "descrizione", null, null, true);
//			}
//		}

		private void abilitaDisabilita() 
		{
			bool confermato = Meta.EditMode && (DS.trasmissioneritenute[0]["flagconferma",DataRowVersion.Original].ToString() == "S");
			Meta.CanCancel = !confermato;
			Meta.CanSave = !confermato;
			chkTrasmConfermata.Enabled = (DS.payedtaxview.Rows.Count > 0) && !confermato || Meta.IsEmpty;
			btnInserisci.Enabled = !Meta.IsEmpty && !chkTrasmConfermata.Checked;
			btnModifica.Enabled = !Meta.IsEmpty && !chkTrasmConfermata.Checked;
			btnRimuovi.Enabled = !Meta.IsEmpty && !chkTrasmConfermata.Checked && (DS.payedtaxview.Rows.Count > 0);
			btnEsporta.Enabled = confermato && (DS.payedtaxview.Rows.Count > 0);
		}
		
		public void MetaData_AfterFill()
		{
			abilitaDisabilita();
			calcolaSomme();
			txtPathFile.Text = "";
		}

		private void calcolaSomme() 
		{
			tSomme.Clear();
			foreach (DataRow r in DS.payedtaxview) 
			{
				string filtro = QueryCreator.WHERE_COLNAME_CLAUSE(r, 
					new string[] {"esercmovimento", "denominazione", "codiceritenuta"}, 
					DataRowVersion.Current, false);
				DataRow[] rSomme = tSomme.Select(filtro);
				if (rSomme.Length==0) 
				{
					DataRow rSomma = tSomme.NewRow();
					foreach (DataColumn c in tSomme.Columns) 
					{
						rSomma[c] = r[c.ColumnName];
					}
					tSomme.Rows.Add(rSomma);
				} 
				else 
				{
					foreach (string c in new string[] {"imponibile", "ritdipendente", "ritamministrazione"}) 
					{
						rSomme[0][c] = CfgFn.GetNoNullDecimal(rSomme[0][c]) + CfgFn.GetNoNullDecimal(r[c]);
					}
				}
			}
			HelpForm.SetDataGrid(gridSomme, tSomme);
			new formatgrids(gridSomme).AutosizeColumnWidth();
		}

		private void btnModifica_Click(object sender, System.EventArgs e) 
		{
			Cursor = Cursors.WaitCursor;
			Meta.GetFormData(true); 
			string MyFilter = "(idtrasmissioneritenute is null)";
			string MyFilterSQL = "(idtrasmissioneritenute is null)";

			Meta.MultipleLinkUnlinkRows("Composizione trasmissione ritenute",
				"Documenti inclusi nella 'trasmissione ritenute' selezionata", 
				"Documenti non inclusi in alcuna 'trasmissione ritenute'",
				DS.payedtaxview, MyFilter, MyFilterSQL, "trasmissione"); 
			Cursor = null;
		}

		private void btnEsporta_Click(object sender, System.EventArgs e)
		{
			DialogResult dr = folderBrowserDialog1.ShowDialog(this);
			if (dr != DialogResult.OK) return;
			string ErrMess;
			Cursor = Cursors.WaitCursor;
			object idtrasmissioneritenute = DS.trasmissioneritenute[0]["idtrasmissioneritenute"];
			DataSet ds = Meta.Conn.CallSP("estrai_anagrafica",
				new object[] {idtrasmissioneritenute,idtrasmissioneritenute},
				0, out ErrMess);
			if (ds == null)
			{
				Cursor = null;
				MessageBox.Show(this, ErrMess);
				return;
			}
			ds.Tables[0].TableName = "myanagrafica";

			DataSet dsIndirizzi = Meta.Conn.CallSP("estrai_indirizzo",
				new object[] {idtrasmissioneritenute,idtrasmissioneritenute},
				0, out ErrMess);
			if (dsIndirizzi == null)
			{
				Cursor = null;
				MessageBox.Show(this, ErrMess);
				return;
			}
			
			DataSet dsRitenute = Meta.Conn.CallSP("estrai_ritenute",
				new object[] {idtrasmissioneritenute,idtrasmissioneritenute},
				0, out ErrMess);
			if (dsRitenute == null)
			{
				Cursor = null;
				MessageBox.Show(this, ErrMess);
				return;
			}

			DataSet dsAltriDati = Meta.Conn.CallSP("estrai_totaledati",
				new object[] {idtrasmissioneritenute,idtrasmissioneritenute},
				0, out ErrMess);
			if (dsAltriDati == null)
			{
				Cursor = null;
				MessageBox.Show(this, ErrMess);
				return;
			}

			DataTable dtIndirizzo = dsIndirizzi.Tables[0];
			dsIndirizzi.Tables.Remove(dtIndirizzo);
			dtIndirizzo.TableName = "myindirizzo";
			ds.Tables.Add(dtIndirizzo);

			DataTable dtRitenute = dsRitenute.Tables[0];
			dsRitenute.Tables.Remove(dtRitenute);
			dtRitenute.TableName = "mydettaglioritenute";
			ds.Tables.Add(dtRitenute);

			DataTable dtAltriDati = dsAltriDati.Tables[0];
			dsAltriDati.Tables.Remove(dtAltriDati);
			dtAltriDati.TableName = "mytotaledati";
			ds.Tables.Add(dtAltriDati);

			DataTable dtLicenza = DataAccess.RUN_SELECT(Meta.Conn,"licenzauso","*",null,null,null,null,true);
			dtLicenza.TableName = "licenzauso";
			ds.Tables.Add(dtLicenza);
			
			int lenIdTrasmissione = 6;
			string zero = "000000";

			DataRow drRiten = dtRitenute.Select(null,"idtrasmissioneritenute ASC")[0];

			string pathDir = folderBrowserDialog1.SelectedPath;
			string iddbcliente = dtLicenza.Rows[0]["iddbcliente"].ToString();
			string idtrasmissione = drRiten["idtrasmissioneritenute"].ToString();
			string estensione = ".dat";
			if (idtrasmissione.Length < lenIdTrasmissione)
			{
				idtrasmissione = zero.Substring(1,(lenIdTrasmissione - idtrasmissione.Length)) + idtrasmissione;
			}

			string fileName = pathDir + "\\" + iddbcliente + "-" + idtrasmissione + estensione;
			
			FileStream fs = new FileStream(fileName, FileMode.Create);
			comprimiECripta(ds, fs);

			txtPathFile.Text = fileName;
			Cursor = null;
		}

		private void comprimiECripta(DataSet ds, FileStream stream)
		{

			Xceed.Compression.CompressedStream CS = new Xceed.Compression.CompressedStream(stream,
				Xceed.Compression.CompressionMethod.Deflated, Xceed.Compression.CompressionLevel.Normal);

			ICryptoTransform ct = new TripleDESCryptoServiceProvider().CreateEncryptor(
				new byte[]{40,22,10,2,6,11,23,45,66,23,9,8,44,69,52,57},
				new byte[]{5,7,99,55,37,12,10,8,59,43,66,78,19,25,23,3}
				);

			CryptoStream CryptoS = new CryptoStream(CS,	ct, CryptoStreamMode.Write);

			ds.WriteXml(CryptoS,XmlWriteMode.WriteSchema);
			CryptoS.Close();
		}

		private void chkTrasmConfermata_CheckedChanged(object sender, System.EventArgs e)
		{
			abilitaDisabilita();
		}

		private void btnExcel_Click(object sender, System.EventArgs e)
		{
			string ErrMess;
			Cursor = Cursors.WaitCursor;
			DataSet ds = Meta.Conn.CallSP("estrai_ritenute",
				new object[] {DS.trasmissioneritenute[0]["idtrasmissioneritenute"]},
				0, out ErrMess);
			if (ds == null) 
			{
				Cursor = null;
				MessageBox.Show(this, ErrMess);
				return;
			}
			exportdata.exportclass.DataTableToExcel(ds.Tables[0], true);
			Cursor = null;
		}

		private void btnVerifica_Click(object sender, System.EventArgs e)
		{
			if (DS.trasmissioneritenute.Rows.Count == 0)
			{
				MessageBox.Show(this, "Nessuna trasmissione da verificare!");
			} 
			else
			{
				if (DS.HasChanges())
				{
					MessageBox.Show("Per verificare la trasmissione occorre prima salvare");
					return;
				}
				bool res = verificaTrasmissione();
				if (res)
				{
					MessageBox.Show("Trasmissione verificata! E' possibile confermare");
				}
			}
		}


//		private void cmbRitenuta_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			string tagInserisci = "choose.ritenuteapplicateview.default.(idtrasmissioneritenute is null)";
//			if (cmbRitenuta.SelectedValue!="tutte") 
//			{
//				tagInserisci += "and(codiceritenuta="+QueryCreator.quotedstrvalue(cmbRitenuta.SelectedValue, true)+")";
//			}
//			Console.WriteLine(tagInserisci);
//			btnInserisci.Tag = tagInserisci;
//		}
	}
}
