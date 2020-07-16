/*
    Easy
    Copyright (C) 2020 UniversitÃ  degli Studi di Catania (www.unict.it)
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
using metaeasylibrary;
using System.Data;
using dbbridge;//dbbridge
using System.Text;
using SPConvert;//SPConvert
using System.IO;
using System.Xml;
using System.Xml.XPath;

namespace colname_default//colname//
{
	/// <summary>
	/// Summary description for frmColname.
	/// </summary>
	public class Frm_colname_default : System.Windows.Forms.Form
	{
		public string DRIVE = "c:";
		//		private string SOLUTION = "CompEc.sln";
		private string SOLUTION = "CompEc.sln";
		private string DIRECTORY = @"\easy";
		private DataAccess mainDA, targetDA;//TO DO 
		//mainDA dovrebbe essere la connessione principale e targetDA la connessione al DB da modificare
		//per mancanza di tempo li faccio coincidere
		private System.Windows.Forms.Button buttonForeignKeys;
		private System.Windows.Forms.Button buttonPrimaryKeys;
		private System.Windows.Forms.Button buttonUnique;
		private System.Windows.Forms.Button buttonTabelle;
		private System.Windows.Forms.Button buttonColonne;
		private System.Windows.Forms.Button buttonStoredProcedure;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Button buttonRuleEnforcement;
		private System.Windows.Forms.Label labelOperazione;
		private System.Windows.Forms.Button buttonIndirectRel;
		private System.Windows.Forms.Button buttonDirectRel;
		private System.Windows.Forms.Button buttonGroupOperation;
		private System.Windows.Forms.Button buttonAggiornamentoDB;
		private System.Windows.Forms.Button buttonViste;
		private System.Windows.Forms.Button buttonCompilaProcedure;
		private System.Windows.Forms.Button buttonTrigger;
		private System.Windows.Forms.Button buttonCompila;
		private System.Windows.Forms.GroupBox groupBoxAggiorna;
		private System.Windows.Forms.GroupBox groupBoxRinomina;
		private System.Windows.Forms.GroupBox groupBoxCompila;
		private System.Windows.Forms.Button buttonParameter;
		private System.Windows.Forms.Button buttonDataSet;
		private System.Windows.Forms.Button buttonSolution;
		public /*Rana:colname.*/vistaForm DS;
		private System.Windows.Forms.Button buttonTabelleRename;
		private System.Windows.Forms.Button buttonForm;
		private System.Windows.Forms.TextBox textBoxSolution;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox chkSoloNuovi;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_colname_default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			this.textBoxSolution.Text = DRIVE+"\\wintrash\\"+SOLUTION;
			DS.CaseSensitive=false;
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			/*			this.showIndex = new System.Windows.Forms.Button();
						this.showHelp = new System.Windows.Forms.Button();
						this.navigatorCombo = new System.Windows.Forms.ComboBox();
						this.label1 = new System.Windows.Forms.Label();
						this.showKeyword = new System.Windows.Forms.Button();
						this.keyword = new System.Windows.Forms.TextBox();
						this.label2 = new System.Windows.Forms.Label();
						this.label3 = new System.Windows.Forms.Label();
						this.parameterTextBox = new System.Windows.Forms.TextBox();

						// Help Navigator Label
						this.label1.Location = new System.Drawing.Point(112, 64);
						this.label1.Size = new System.Drawing.Size(168, 16);
						this.label1.Text = "Help Navigator:";

						// Keyword Label
						this.label2.Location = new System.Drawing.Point(120, 184);
						this.label2.Size = new System.Drawing.Size(100, 16);
						this.label2.Text = "Keyworc:";

						// Parameter Label
						this.label3.Location = new System.Drawing.Point(112, 120);
						this.label3.Size = new System.Drawing.Size(168, 16);
						this.label3.Text = "Parameter:";

						// Show Index Button
						this.showIndex.Location = new System.Drawing.Point(16, 16);
						this.showIndex.Size = new System.Drawing.Size(264, 32);
						this.showIndex.TabIndex = 0;
						this.showIndex.Text = "Show Help Index";
						this.showIndex.Click += new System.EventHandler(this.showIndex_Click);

						// Show Help Button
						this.showHelp.Location = new System.Drawing.Point(16, 80);
						this.showHelp.Size = new System.Drawing.Size(80, 80);
						this.showHelp.TabIndex = 1;
						this.showHelp.Text = "Show Help";
						this.showHelp.Click += new System.EventHandler(this.showHelp_Click);

						// Show Keyword Button
						this.showKeyword.Location = new System.Drawing.Point(16, 192);
						this.showKeyword.Size = new System.Drawing.Size(88, 32);
						this.showKeyword.TabIndex = 4;
						this.showKeyword.Text = "Show Keyword";
						this.showKeyword.Click += new System.EventHandler(this.showKeyword_Click);

						// Help Navigator ComboBox
						this.navigatorCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
						this.navigatorCombo.Location = new System.Drawing.Point(112, 80);
						this.navigatorCombo.Size = new System.Drawing.Size(168, 21);
						this.navigatorCombo.TabIndex = 2;

						// Keyword TextBox
						this.keyword.Location = new System.Drawing.Point(120, 200);
						this.keyword.Size = new System.Drawing.Size(160, 20);
						this.keyword.TabIndex = 5;
						this.keyword.Text = "";

						// Parameter TextBox
						this.parameterTextBox.Location = new System.Drawing.Point(112, 136);
						this.parameterTextBox.Size = new System.Drawing.Size(168, 20);
						this.parameterTextBox.TabIndex = 8;
						this.parameterTextBox.Text = "";

						// Set up how the form should be displayed and add the controls to the form.
						this.ClientSize = new System.Drawing.Size(292, 266);
						this.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.parameterTextBox, this.label3,
																					  this.label2, this.keyword,
																					  this.showKeyword, this.label1,
																					  this.navigatorCombo, this.showHelp,
																					  this.showIndex});
						this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
						this.Text = "Help App";

						// Load the various values of the HelpNavigator enumeration
						// into the combo box.
						TypeConverter converter;
						converter = TypeDescriptor.GetConverter(typeof(HelpNavigator));
						foreach(object value in converter.GetStandardValues()) 
						{
							navigatorCombo.Items.Add(value);
						}*/
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
			this.buttonForeignKeys = new System.Windows.Forms.Button();
			this.buttonPrimaryKeys = new System.Windows.Forms.Button();
			this.buttonUnique = new System.Windows.Forms.Button();
			this.buttonTabelle = new System.Windows.Forms.Button();
			this.buttonColonne = new System.Windows.Forms.Button();
			this.buttonStoredProcedure = new System.Windows.Forms.Button();
			this.buttonViste = new System.Windows.Forms.Button();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.buttonRuleEnforcement = new System.Windows.Forms.Button();
			this.buttonDirectRel = new System.Windows.Forms.Button();
			this.labelOperazione = new System.Windows.Forms.Label();
			this.buttonIndirectRel = new System.Windows.Forms.Button();
			this.buttonGroupOperation = new System.Windows.Forms.Button();
			this.buttonAggiornamentoDB = new System.Windows.Forms.Button();
			this.buttonCompilaProcedure = new System.Windows.Forms.Button();
			this.buttonTrigger = new System.Windows.Forms.Button();
			this.buttonCompila = new System.Windows.Forms.Button();
			this.groupBoxAggiorna = new System.Windows.Forms.GroupBox();
			this.buttonParameter = new System.Windows.Forms.Button();
			this.groupBoxRinomina = new System.Windows.Forms.GroupBox();
			this.groupBoxCompila = new System.Windows.Forms.GroupBox();
			this.buttonDataSet = new System.Windows.Forms.Button();
			this.buttonSolution = new System.Windows.Forms.Button();
			this.DS = new /*Rana:colname.*/vistaForm();
			this.buttonTabelleRename = new System.Windows.Forms.Button();
			this.buttonForm = new System.Windows.Forms.Button();
			this.textBoxSolution = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.chkSoloNuovi = new System.Windows.Forms.CheckBox();
			this.groupBoxAggiorna.SuspendLayout();
			this.groupBoxRinomina.SuspendLayout();
			this.groupBoxCompila.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonForeignKeys
			// 
			this.buttonForeignKeys.Location = new System.Drawing.Point(248, 16);
			this.buttonForeignKeys.Name = "buttonForeignKeys";
			this.buttonForeignKeys.Size = new System.Drawing.Size(72, 23);
			this.buttonForeignKeys.TabIndex = 7;
			this.buttonForeignKeys.Text = "Foreign keys";
			this.buttonForeignKeys.Click += new System.EventHandler(this.buttonForeignKeys_Click);
			// 
			// buttonPrimaryKeys
			// 
			this.buttonPrimaryKeys.Location = new System.Drawing.Point(328, 16);
			this.buttonPrimaryKeys.Name = "buttonPrimaryKeys";
			this.buttonPrimaryKeys.Size = new System.Drawing.Size(72, 23);
			this.buttonPrimaryKeys.TabIndex = 8;
			this.buttonPrimaryKeys.Text = "Primary keys";
			this.buttonPrimaryKeys.Click += new System.EventHandler(this.buttonPrimaryKeys_Click);
			// 
			// buttonUnique
			// 
			this.buttonUnique.Location = new System.Drawing.Point(408, 16);
			this.buttonUnique.Name = "buttonUnique";
			this.buttonUnique.Size = new System.Drawing.Size(72, 23);
			this.buttonUnique.TabIndex = 9;
			this.buttonUnique.Text = "Unique";
			this.buttonUnique.Click += new System.EventHandler(this.buttonUnique_Click);
			// 
			// buttonTabelle
			// 
			this.buttonTabelle.Location = new System.Drawing.Point(88, 16);
			this.buttonTabelle.Name = "buttonTabelle";
			this.buttonTabelle.Size = new System.Drawing.Size(72, 23);
			this.buttonTabelle.TabIndex = 10;
			this.buttonTabelle.Text = "Tabelle";
			this.buttonTabelle.Click += new System.EventHandler(this.buttonTabelle_Click);
			// 
			// buttonColonne
			// 
			this.buttonColonne.Location = new System.Drawing.Point(8, 16);
			this.buttonColonne.Name = "buttonColonne";
			this.buttonColonne.Size = new System.Drawing.Size(72, 23);
			this.buttonColonne.TabIndex = 11;
			this.buttonColonne.Text = "Colonne";
			this.buttonColonne.Click += new System.EventHandler(this.buttonColonne_Click);
			// 
			// buttonStoredProcedure
			// 
			this.buttonStoredProcedure.Location = new System.Drawing.Point(168, 16);
			this.buttonStoredProcedure.Name = "buttonStoredProcedure";
			this.buttonStoredProcedure.Size = new System.Drawing.Size(72, 23);
			this.buttonStoredProcedure.TabIndex = 12;
			this.buttonStoredProcedure.Text = "Procedure";
			this.buttonStoredProcedure.Click += new System.EventHandler(this.buttonstoredProcedure_Click);
			// 
			// buttonViste
			// 
			this.buttonViste.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonViste.Location = new System.Drawing.Point(4, 16);
			this.buttonViste.Name = "buttonViste";
			this.buttonViste.TabIndex = 13;
			this.buttonViste.Text = "Viste";
			this.buttonViste.Click += new System.EventHandler(this.buttonViste_Click);
			// 
			// progressBar1
			// 
			this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar1.Location = new System.Drawing.Point(8, 287);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(488, 23);
			this.progressBar1.TabIndex = 14;
			// 
			// buttonRuleEnforcement
			// 
			this.buttonRuleEnforcement.Location = new System.Drawing.Point(248, 16);
			this.buttonRuleEnforcement.Name = "buttonRuleEnforcement";
			this.buttonRuleEnforcement.Size = new System.Drawing.Size(88, 23);
			this.buttonRuleEnforcement.TabIndex = 15;
			this.buttonRuleEnforcement.Text = "RuleEnforcement";
			this.buttonRuleEnforcement.Click += new System.EventHandler(this.buttonRuleEnforcement_Click);
			// 
			// buttonDirectRel
			// 
			this.buttonDirectRel.Location = new System.Drawing.Point(8, 16);
			this.buttonDirectRel.Name = "buttonDirectRel";
			this.buttonDirectRel.TabIndex = 16;
			this.buttonDirectRel.Text = "Direct rel";
			this.buttonDirectRel.Click += new System.EventHandler(this.buttonDirectRel_Click);
			// 
			// labelOperazione
			// 
			this.labelOperazione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.labelOperazione.Location = new System.Drawing.Point(8, 263);
			this.labelOperazione.Name = "labelOperazione";
			this.labelOperazione.Size = new System.Drawing.Size(488, 23);
			this.labelOperazione.TabIndex = 17;
			this.labelOperazione.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// buttonIndirectRel
			// 
			this.buttonIndirectRel.Location = new System.Drawing.Point(88, 16);
			this.buttonIndirectRel.Name = "buttonIndirectRel";
			this.buttonIndirectRel.TabIndex = 18;
			this.buttonIndirectRel.Text = "Indirect rel";
			this.buttonIndirectRel.Click += new System.EventHandler(this.buttonIndirectRel_Click);
			// 
			// buttonGroupOperation
			// 
			this.buttonGroupOperation.Location = new System.Drawing.Point(168, 16);
			this.buttonGroupOperation.Name = "buttonGroupOperation";
			this.buttonGroupOperation.TabIndex = 19;
			this.buttonGroupOperation.Text = "Group operation";
			this.buttonGroupOperation.Click += new System.EventHandler(this.buttonGroupOperation_Click);
			// 
			// buttonAggiornamentoDB
			// 
			this.buttonAggiornamentoDB.Location = new System.Drawing.Point(384, 184);
			this.buttonAggiornamentoDB.Name = "buttonAggiornamentoDB";
			this.buttonAggiornamentoDB.Size = new System.Drawing.Size(96, 23);
			this.buttonAggiornamentoDB.TabIndex = 20;
			this.buttonAggiornamentoDB.Text = "Aggiornamento completo DB";
			this.buttonAggiornamentoDB.Click += new System.EventHandler(this.buttonAggiornamentoDB_Click);
			// 
			// buttonCompilaProcedure
			// 
			this.buttonCompilaProcedure.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonCompilaProcedure.Location = new System.Drawing.Point(84, 16);
			this.buttonCompilaProcedure.Name = "buttonCompilaProcedure";
			this.buttonCompilaProcedure.TabIndex = 21;
			this.buttonCompilaProcedure.Text = "Procedure";
			this.buttonCompilaProcedure.Click += new System.EventHandler(this.buttonCompilaProcedure_Click);
			// 
			// buttonTrigger
			// 
			this.buttonTrigger.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonTrigger.Location = new System.Drawing.Point(164, 16);
			this.buttonTrigger.Name = "buttonTrigger";
			this.buttonTrigger.TabIndex = 22;
			this.buttonTrigger.Text = "Trigger";
			this.buttonTrigger.Click += new System.EventHandler(this.buttonTrigger_Click);
			// 
			// buttonCompila
			// 
			this.buttonCompila.Location = new System.Drawing.Point(256, 136);
			this.buttonCompila.Name = "buttonCompila";
			this.buttonCompila.Size = new System.Drawing.Size(152, 23);
			this.buttonCompila.TabIndex = 23;
			this.buttonCompila.Text = "Compila singola procedura";
			this.buttonCompila.Click += new System.EventHandler(this.buttonCompila_Click);
			// 
			// groupBoxAggiorna
			// 
			this.groupBoxAggiorna.Controls.Add(this.buttonParameter);
			this.groupBoxAggiorna.Controls.Add(this.buttonDirectRel);
			this.groupBoxAggiorna.Controls.Add(this.buttonIndirectRel);
			this.groupBoxAggiorna.Controls.Add(this.buttonGroupOperation);
			this.groupBoxAggiorna.Controls.Add(this.buttonRuleEnforcement);
			this.groupBoxAggiorna.Location = new System.Drawing.Point(40, 8);
			this.groupBoxAggiorna.Name = "groupBoxAggiorna";
			this.groupBoxAggiorna.Size = new System.Drawing.Size(424, 48);
			this.groupBoxAggiorna.TabIndex = 24;
			this.groupBoxAggiorna.TabStop = false;
			this.groupBoxAggiorna.Text = "Aggiorna";
			// 
			// buttonParameter
			// 
			this.buttonParameter.Location = new System.Drawing.Point(344, 16);
			this.buttonParameter.Name = "buttonParameter";
			this.buttonParameter.TabIndex = 20;
			this.buttonParameter.Text = "Parameter";
			this.buttonParameter.Click += new System.EventHandler(this.buttonParameter_Click);
			// 
			// groupBoxRinomina
			// 
			this.groupBoxRinomina.Controls.Add(this.buttonColonne);
			this.groupBoxRinomina.Controls.Add(this.buttonTabelle);
			this.groupBoxRinomina.Controls.Add(this.buttonStoredProcedure);
			this.groupBoxRinomina.Controls.Add(this.buttonForeignKeys);
			this.groupBoxRinomina.Controls.Add(this.buttonPrimaryKeys);
			this.groupBoxRinomina.Controls.Add(this.buttonUnique);
			this.groupBoxRinomina.Location = new System.Drawing.Point(8, 64);
			this.groupBoxRinomina.Name = "groupBoxRinomina";
			this.groupBoxRinomina.Size = new System.Drawing.Size(488, 48);
			this.groupBoxRinomina.TabIndex = 25;
			this.groupBoxRinomina.TabStop = false;
			this.groupBoxRinomina.Text = "Rinomina";
			// 
			// groupBoxCompila
			// 
			this.groupBoxCompila.Controls.Add(this.buttonViste);
			this.groupBoxCompila.Controls.Add(this.buttonCompilaProcedure);
			this.groupBoxCompila.Controls.Add(this.buttonTrigger);
			this.groupBoxCompila.Location = new System.Drawing.Point(8, 120);
			this.groupBoxCompila.Name = "groupBoxCompila";
			this.groupBoxCompila.Size = new System.Drawing.Size(248, 48);
			this.groupBoxCompila.TabIndex = 26;
			this.groupBoxCompila.TabStop = false;
			this.groupBoxCompila.Text = "Compila";
			// 
			// buttonDataSet
			// 
			this.buttonDataSet.Location = new System.Drawing.Point(280, 184);
			this.buttonDataSet.Name = "buttonDataSet";
			this.buttonDataSet.Size = new System.Drawing.Size(88, 23);
			this.buttonDataSet.TabIndex = 27;
			this.buttonDataSet.Text = "DataSet";
			this.buttonDataSet.Click += new System.EventHandler(this.buttonDataSet_Click);
			// 
			// buttonSolution
			// 
			this.buttonSolution.Location = new System.Drawing.Point(192, 184);
			this.buttonSolution.Name = "buttonSolution";
			this.buttonSolution.TabIndex = 28;
			this.buttonSolution.Text = "Solution";
			this.buttonSolution.Click += new System.EventHandler(this.buttonSolution_Click);
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.EnforceConstraints = false;
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// buttonTabelleRename
			// 
			this.buttonTabelleRename.Location = new System.Drawing.Point(8, 184);
			this.buttonTabelleRename.Name = "buttonTabelleRename";
			this.buttonTabelleRename.TabIndex = 29;
			this.buttonTabelleRename.Text = "Tab. Ren.";
			this.buttonTabelleRename.Click += new System.EventHandler(this.buttonTabelleRename_Click);
			// 
			// buttonForm
			// 
			this.buttonForm.Location = new System.Drawing.Point(96, 184);
			this.buttonForm.Name = "buttonForm";
			this.buttonForm.TabIndex = 30;
			this.buttonForm.Text = "Form";
			this.buttonForm.Click += new System.EventHandler(this.buttonForm_Click);
			// 
			// textBoxSolution
			// 
			this.textBoxSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSolution.Location = new System.Drawing.Point(8, 232);
			this.textBoxSolution.Name = "textBoxSolution";
			this.textBoxSolution.Size = new System.Drawing.Size(480, 20);
			this.textBoxSolution.TabIndex = 37;
			this.textBoxSolution.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(416, 136);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 23);
			this.button2.TabIndex = 38;
			this.button2.Text = "Controlla DS";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 216);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 39;
			this.label1.Text = "Source solution";
			// 
			// chkSoloNuovi
			// 
			this.chkSoloNuovi.Checked = true;
			this.chkSoloNuovi.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkSoloNuovi.Location = new System.Drawing.Point(200, 208);
			this.chkSoloNuovi.Name = "chkSoloNuovi";
			this.chkSoloNuovi.Size = new System.Drawing.Size(232, 16);
			this.chkSoloNuovi.TabIndex = 40;
			this.chkSoloNuovi.Text = "Non compilare progetti già compilati";
			// 
			// frmColname
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(504, 317);
			this.Controls.Add(this.chkSoloNuovi);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.textBoxSolution);
			this.Controls.Add(this.buttonForm);
			this.Controls.Add(this.buttonTabelleRename);
			this.Controls.Add(this.buttonSolution);
			this.Controls.Add(this.buttonDataSet);
			this.Controls.Add(this.groupBoxCompila);
			this.Controls.Add(this.groupBoxRinomina);
			this.Controls.Add(this.groupBoxAggiorna);
			this.Controls.Add(this.buttonCompila);
			this.Controls.Add(this.buttonAggiornamentoDB);
			this.Controls.Add(this.labelOperazione);
			this.Controls.Add(this.progressBar1);
			this.Name = "frmColname";
			this.Text = "frmColname";
			this.groupBoxAggiorna.ResumeLayout(false);
			this.groupBoxRinomina.ResumeLayout(false);
			this.groupBoxCompila.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		public void MetaData_AfterLink()
		{
//			string dsn = "daacm su locale";
//			string server = ".";
//			string database = "daacm";
//			int esercizio = 2005;
//			DateTime dataContabile = DateTime.Now.Date;
//			mainDA = MetaData.GetMetaData(this).Conn;
//			targetDA = new DataAccess(dsn, server, database, esercizio, dataContabile);
//			label1.Text = targetDA.GetSys("database")+ " su "+targetDA.GetSys("server");
			mainDA = MetaData.GetMetaData(this).Conn;
			targetDA = MetaData.GetMetaData(this).Conn;
		}

		#region utilities

		private void buttonCompila_Click(object sender, System.EventArgs e)
		{
			new frmSPConvert(targetDA).ShowDialog(this);
		}

		/// <summary>
		/// Rinomina un oggetto o una colonna del database
		/// </summary>
		/// <param name="tipo">
		/// "column" se si vuole rinominare una colonna.
		/// "object" se si vuole rinominare oggetti che includono vincoli (CHECK, FOREIGN KEY, PRIMARY/UNIQUE KEY), tabelle utente, viste, stored procedure, trigger e regole.
		/// </param>
		/// <param name="vecchioNome">nome corrente dell'oggetto</param>
		/// <param name="nuovoNome">nuovo nome che si vuole dare all'oggetto specificato.</param>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinomina(string tipo, object vecchioNome, object nuovoNome) 
		{
			//EXEC sp_rename N'[dbo].[colname]', N'colname2', N'object'
			//EXECUTE sp_rename N'dbo.colname.Tmp_oldtable_1', N'oldtable', 'COLUMN'
			string query = "exec sp_rename '"+vecchioNome+"', '"+nuovoNome+"', '"+tipo+"'";

			DataTable t = targetDA.SQLRunner(query);
			if (t==null) 
			{
				//return DialogResult.OK;
				return visualizzaMsgBox(targetDA.LastError);
			} 
			else 
			{
				return DialogResult.OK;
			}
		}

		/// <summary>
		/// Legge una tabella dal DB.
		/// </summary>
		/// <param name="emptyTable">DataTable da riempire</param>
		/// <param name="order_by">ordine con cui si vuole leggere le righe; null se si vogliono leggere in sequenza</param>
		/// <param name="filter">filtro da applicare alla lettura delle righe; null se si vogliono leggere tutte le righe </param>
		/// <param name="TOP">numero di righe da leggere; null se si vogliono leggere tutte</param>
		/// <returns>false se c'è stato un errore; true se la tabella è stata letta correttamente</returns>
		private bool leggiTabella (
			DataAccess dataAccess,
			DataTable emptyTable, 
			string order_by, 
			string filter, 
			string TOP
		)
		{
			emptyTable.Clear();
			DataAccess.RUN_SELECT_INTO_TABLE(dataAccess, emptyTable, order_by, filter, TOP, ! emptyTable.TableName.StartsWith("sys"));
			string errore = dataAccess.LastError;
			if (errore!="") 
			{
				MessageBox.Show(this, errore+"\r\n\r\nLette "+emptyTable.Rows.Count+" righe da "+emptyTable.TableName);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Esegue una query per riempire una tabella
		/// </summary>
		/// <param name="emptyTable">DataTable da riempire</param>
		/// <param name="query">query da eseguire</param>
		/// <param name="order_by">ordine con cui si vuole leggere le righe; null se si vogliono leggere in sequenza</param>
		/// <param name="filter">filtro da applicare alla lettura delle righe; null se si vogliono leggere tutte le righe </param>
		/// <param name="TOP">numero di righe da leggere; null se si vogliono leggere tutte</param>
		/// <returns>false se c'è stato un errore; true se la tabella è stata letta correttamente</returns>
		/// 
		private bool leggiAlcuneColonneDellaTabella(string query, DataTable emptyTable) 
		{
			emptyTable.Clear();
			DataTable t = mainDA.SQLRunner(query);

			foreach (DataRow r in t.Rows) 
			{
				DataRow et = emptyTable.NewRow();
				foreach (DataColumn c in t.Columns)
				{
					et[c.ColumnName] = r[c];
				}
				emptyTable.Rows.Add(et);
				et.AcceptChanges();
			}
			string errore = mainDA.LastError;
			if (errore!="") 
			{
				MessageBox.Show(this, errore+"\r\n\r\nLette "+emptyTable.Rows.Count+" righe da "+emptyTable.TableName);
				return false;
			}
			return true;
		}

		/// <summary>
		/// Visualizza una messagebox per segnalare un errore.
		/// </summary>
		/// <param name="errore">messaggio di errore da segnalare all'utente</param>
		/// <returns>
		/// DialogResult.OK se l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult visualizzaMsgBox(string errore) 
		{
			errore += "\n\nPremere OK per passare all'oggetto successivo, ANNULLA per interrompere";
			return MessageBox.Show(this, errore, "Errore!", MessageBoxButtons.OKCancel);
		}

		/// <summary>
		/// Da chiamarsi ogni volta che si inizia un nuovo processo di aggiornamento.
		/// Visualizza una label informativa ed azzera la progress bar.
		/// </summary>
		/// <param name="righe">righe su cui agirà il processo di elaborazione</param></param>
		/// <param name="tipoElementi">tipo di elementi che verranno elaborati (tabelle, colonne, procedure, ecc.)</param>
		private void inizializzaProgressBar(DataRow[] righe, string tipoElementi) 
		{
			labelOperazione.Text = "Elaborazione di "+righe.Length+" "+tipoElementi;
			progressBar1.Value = 0;
			progressBar1.Maximum = righe.Length;
		}

		/// <summary>
		/// Da chiamarsi ogni volta che si inizia un nuovo processo di aggiornamento.
		/// Visualizza una label informativa ed azzera la progress bar.
		/// </summary>
		/// <param name="t">tabella sul quale agirà il processo di elaborazione</param>
		/// <param name="tipoElementi">tipo di elementi che verranno elaborati (tabelle, colonne, procedure, ecc.)</param>
		private void inizializzaProgressBar(DataTable t, string tipoElementi) 
		{
			labelOperazione.Text = "Elaborazione di "+t.Rows.Count+" "+tipoElementi+"; Tabella="+t.TableName;
			progressBar1.Value = 0;
			progressBar1.Maximum = t.Rows.Count;
		}

		/// <summary>
		/// Scrive sul DataBase.
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult scriviSulDataBase() 
		{
			Console.WriteLine("INIZIO SCRITTURA SUL DB");
			MetaData meta = MetaData.GetMetaData(this);
			PostData postData = meta.Get_PostData();
			postData.InitClass(DS, mainDA);
			string errore = mainDA.LastError;
			if (postData.DO_POST()) 
			{
				MessageBox.Show(this, errore, "Scrittura sul DB effettuata con successo");
				foreach (DataTable t in DS.Tables) 
				{
					t.Clear();
				}
				return DialogResult.OK;
			}
			else
			{
				return visualizzaMsgBox("Errore durante la scrittura sul DB\r\n"+errore);
			}
		}

		#endregion

		#region ForeignKey e Unique
		/// <summary>
		/// Cerca un numero all'interno di una stringa da partire dal carattere startindex
		/// </summary>
		/// <param name="s">stringa al cui interno ricercare un numero</param>
		/// <param name="startIndex">posizione di partenza per la ricerca all'interno della stringa</param>
		/// <returns>numero a due cifre trovato riempito eventualmente con _ a sinistra</returns>
		private string getContatore(string s, int startIndex) 
		{
			try 
			{
				return Int32.Parse(s.Substring(3,2)).ToString();
			} 
			catch (FormatException) 
			{
			}

			try 
			{
				return "_"+Int32.Parse(s.Substring(3,1));
			} 
			catch (FormatException) 
			{
			}

			return "__";
		}

		/// <summary>
		/// Assegna ai vincoli Unique del DB un nome del tipo
		/// "UQ_nometabella"
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinominaUnique() 
		{
			bool ok = leggiTabella(targetDA, DS.sysobjects, null, null, null);
			if (!ok) return DialogResult.Cancel;

			DataRow[] unique = DS.sysobjects.Select("xtype='UQ'");

			inizializzaProgressBar(unique, "vincoli unique");
			foreach (DataRow rConstraint in unique) 
			{
				DataRow rTabella = rConstraint.GetParentRow("sysobjectssysobjects");
				string vecchioNome = rConstraint["name"].ToString();
				if (!vecchioNome.StartsWith("xak")) 
				{
					string errore = "La seguente relazione non comincia per 'xak'\n" + vecchioNome+"\n\nTabella = " + rTabella["name"];
					if (visualizzaMsgBox(errore) == DialogResult.Cancel) 
					{
						return DialogResult.Cancel;
					}
				} 
				else 
				{
					string sContatore = getContatore(vecchioNome, 3);
					string nuovoNome = "UQ"+sContatore+"_"+rTabella["name"];
					if (rinomina("object", vecchioNome, nuovoNome) == DialogResult.Cancel) 
					{
						return DialogResult.Cancel;
					}
				}
				progressBar1.Value ++;
			}

			return DialogResult.OK;
		}

		private void buttonUnique_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rinominaUnique();
			this.Cursor = null;
			this.progressBar1.Value = 0;
		}

		/// <summary>
		/// Rinomina i vincoli foreign key assegnando il nome del tipo
		/// FK_n_tabellafiglio_tabellapadre, dove 
		/// n è un contatore numerico, tabellafiglio e tabellapadre sono le due tabelle
		/// tra cui c'è la relazione molti ad uno.
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinominaForeignKeys() 
		{
			this.Cursor = Cursors.WaitCursor;
			bool ok = leggiTabella(targetDA, DS.sysobjects, null, null, null);
			if (!ok) return DialogResult.Cancel;
			
			String query = "select distinct constid, fkeyid, rkeyid from sysforeignkeys";
			ok = leggiAlcuneColonneDellaTabella(query, DS.sysforeignkeys);
/*			ok = leggiAlcuneColonneDellaTabella (//TODO da correggere
				DS.sysforeignkeys, 
				"distinct constid, fkeyid, rkeyid",
				null, null, null, null
				);*/
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.sysforeignkeys, "foreign keys");

			foreach (DataRow rForeignKey in DS.sysforeignkeys.Rows) 
			{
				DataRow rRelazione = rForeignKey.GetParentRow("sysobjectssysforeignkeys");
				DataRow rFiglio = rForeignKey.GetParentRow("sysobjectssysforeignkeys_figlio");
				DataRow rPadre = rForeignKey.GetParentRow("sysobjectssysforeignkeys_padre");
				string relazione = rRelazione["name"].ToString();
				string figlio = rFiglio["name"].ToString();
				string padre = rPadre["name"].ToString();
				if (!relazione.StartsWith("xfk")) 
				{
					string errore ="La seguente relazione non comincia per 'xfk'\n"	+ relazione+"\n\nFiglio = " + figlio+"\nPadre = " + padre;
					if (visualizzaMsgBox(errore) == DialogResult.Cancel) 
					{
						return DialogResult.Cancel;
					}
				} 
				else 
				{
					string sContatore = getContatore(relazione, 3);
					string nuovoNome = "FK"+sContatore+"_"+figlio+"_"+padre;
					if (rinomina("object", relazione, nuovoNome) == DialogResult.Cancel) 
					{
						return DialogResult.Cancel;
					}
				}
				progressBar1.Value ++;
			}
			progressBar1.Value = 0;
			this.Cursor = null;
			return DialogResult.OK;
		}

		private void buttonForeignKeys_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rinominaForeignKeys();
			this.Cursor = null;
			this.progressBar1.Value = 0;
		}

		#endregion

		#region PrimaryKey

		/// <summary>
		/// Rinomina i vincoli di Primary Key assegnando un nome del tipo
		/// "PK_nometabella"
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinominaPrimaryKeys() 
		{
			bool ok = leggiTabella(targetDA, DS.sysobjects, null, null, null);
			if (!ok) return DialogResult.Cancel;

			DataRow[] primaryKeys = DS.sysobjects.Select("xtype='PK'");
			
			inizializzaProgressBar(primaryKeys, "primary keys");

			foreach (DataRow rPrimaryKey in primaryKeys) 
			{
				DataRow rTabella = rPrimaryKey.GetParentRow("sysobjectssysobjects");
				if (rinomina("object", rPrimaryKey["name"], "PK_"+rTabella["name"])
					== DialogResult.Cancel) 
				{
					return DialogResult.Cancel;
				}
				progressBar1.Value ++;
			}
			return DialogResult.OK;
		}

		private void buttonPrimaryKeys_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rinominaPrimaryKeys();
			this.Cursor = null;
			this.progressBar1.Value = 0;
		}

		#endregion

		#region colonne, tabelle, procedure

		private void buttonTabelle_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rinominaTabelle();
			this.Cursor = null;
			this.progressBar1.Value = 0;
		}

		private void buttonColonne_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rinominaColonne();
			this.Cursor = null;
			this.progressBar1.Value = 0;
		}

		private void buttonstoredProcedure_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			rinominaProcedure();
			this.Cursor = null;
			this.progressBar1.Value = 0;
		}

		/// <summary>
		/// Rinomina le procedure. I vecchi ed i nuovi nomi sono letti dalla tabella procedures.
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinominaProcedure() 
		{
			bool ok = leggiTabella(mainDA, DS.procedures, null, null, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.procedures, "procedure");

			foreach (DataRow rSpName in DS.procedures.Rows) 
			{
				if (rinomina("object", rSpName["oldname"], rSpName["newname"])
					== DialogResult.Cancel) 
				{
					return DialogResult.Cancel;
				}
				progressBar1.Value ++;
			}
			return DialogResult.OK;
		}


		/// <summary>
		/// Rinomina le colonne delle tabelle. I vecchi ed i nuovi nomi sono letti dalla tabella colname
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinominaColonne() 
		{
			bool ok = leggiTabella(mainDA, DS.colname, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.sysobjects, null, null, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.colname, "colonne");

			foreach (DataRow rColName in DS.colname.Rows) 
			{
				string tabella = QueryCreator.quotedstrvalue(rColName["oldtable"], false);
				DataRow[] rSysObjects = DS.sysobjects.Select("xtype='U' and name="+tabella);
				if (rSysObjects.Length>0) 
				{
					string vecchiaTabella = rColName["oldtable"].ToString();
					string vecchiaColonna = rColName["oldcol"].ToString();
					string nuovaColonna = rColName["newcol"].ToString();
					int confronto = String.Compare(vecchiaColonna, nuovaColonna, true);
					if (confronto != 0) {
						if (rinomina("COLUMN", vecchiaTabella+"."+vecchiaColonna, nuovaColonna)
							== DialogResult.Cancel) {
							DS.colname.Clear();
							return DialogResult.Cancel;
						}
					} else {
						if (vecchiaColonna != nuovaColonna) {
							if (rinomina("COLUMN", vecchiaTabella+"."+vecchiaColonna, "xxx"+nuovaColonna)
								== DialogResult.Cancel) {
								DS.colname.Clear();
								return DialogResult.Cancel;
							}
							if (rinomina("COLUMN", vecchiaTabella+".xxx"+nuovaColonna, nuovaColonna)
								== DialogResult.Cancel) {
								DS.colname.Clear();
								return DialogResult.Cancel;
							}
						}
					}
				}
				progressBar1.Value ++;
				Application.DoEvents();
			}

			progressBar1.Value = 0;
			DS.colname.Clear();
			return DialogResult.OK;
		}

		/// <summary>
		/// Rinomina le tabelle. I vecchi ed i nuovi nomi sono letti dalla tabelle tablename.
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult rinominaTabelle() 
		{
			bool ok = leggiTabella(mainDA, DS.tablename, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.sysobjects, null, null, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.tablename, "tabelle");
			foreach (DataRow rTableName in DS.tablename.Rows) 
			{
				if (rinomina("object", rTableName["oldtable"], rTableName["newtable"])
					== DialogResult.Cancel) 
				{
					DS.tablename.Clear();
					return DialogResult.Cancel;
				}
				progressBar1.Value ++;
				Application.DoEvents();
			}
			DS.tablename.Clear();
			progressBar1.Value = 0;
			return DialogResult.OK;
		}

		#endregion

		#region compilazione di viste, procedure e trigger

		private void buttonViste_Click(object sender, System.EventArgs e)
		{

			compilaProcedure("V", "viste");
			MessageBox.Show(this, "HO FINITO!");
		}


		private void buttonCompilaProcedure_Click(object sender, System.EventArgs e)
		{
			compilaProcedure("P", "procedure");
			MessageBox.Show(this, "HO FINITO!");
			
			MetaData metaTempVar = MetaData.GetMetaData(this, "ren_tempvar");
			foreach (DictionaryEntry de in DBBridge.tempVar) 
			{
				NuovoNomeVariabileTemporanea n = (NuovoNomeVariabileTemporanea) de.Value;
				DataRow r = metaTempVar.Get_New_Row(null, DS.ren_tempvar);
				r["oldname"] = de.Key;
				r["newname"] = n.newName;
				r["occur"] = n.occur;
			}
			scriviSulDataBase();
		}

		private void buttonTrigger_Click(object sender, System.EventArgs e)
		{
			compilaProcedure("TR", "trigger");
			MessageBox.Show(this, "HO FINITO!");
		}

		/// <summary>
		/// Prerequisito: syscomments deve essere stato già letto interamente.
		/// Compila una singola stored procedure. Essa viene letta dalla tabella syscomments,
		/// data in pasto al metodo compila di DBBridge, ed eseguita.
		/// </summary>
		/// <param name="rObject">Riga di sysobjects contenente informazioni relative alla procedura da compilare</param>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult compilaUnaProcedura(DataRow rObject) 
		{
			string intestazione = "--Pino Rana, elaborazione del ";

			StringBuilder sb = new StringBuilder();
			foreach (DataRow rStoredProcedure in rObject.GetChildRows("sysobjectssyscomments")) 
			{
				if (Convert.ToInt32(rStoredProcedure["encrypted"])==0) 
				{
					sb.Append(rStoredProcedure["text"]);
				}
			}
			string vecchio = sb.ToString();
			if ((vecchio!="")&&(!vecchio.StartsWith(intestazione)))
			{
				string nuovo = DBBridge.Compile(targetDA, vecchio, null);
				SPBridge spBridge = new SPBridge(nuovo);
				string skipped;
				SPToken spToken = spBridge.NextToken(out skipped);
				int currentPosition = spBridge.GetMark();
				nuovo = intestazione + DateTime.Now + "\r\n"
					+ skipped + "ALTER" + nuovo.Substring(currentPosition);
				DataTable t = targetDA.SQLRunner(nuovo);
				if (t==null) 
				{
					string messaggio = targetDA.LastError;
					int posMsg = messaggio.LastIndexOf(" - Msg:\r\n");
//					string errore = (posMsg<0) ? messaggio :
//						"--" + messaggio.Substring(posMsg+9) + "\r\n"
//						+ "--" + messaggio.Substring(0, posMsg);
					string errore = messaggio+"\r\n\r\n===================================\r\n\r\n"+nuovo;
					frmSPConvert form = new frmSPConvert(targetDA);
					form.txtToConvert.Text = QueryCreator.GetPrintable(vecchio);
					form.txtConverted.Text = QueryCreator.GetPrintable(errore);
					form.ShowDialog(this);
					DialogResult dr = visualizzaMsgBox("");
					if (dr==DialogResult.Cancel) return dr;
				}
			}
			return DialogResult.OK;
		}

		/// <summary>
		/// Prerequisiti: le procedure devono essere già state rinominate.
		/// Compila tutte le procedure.
		/// </summary>
		/// <param name="xtype"></param>
		/// <param name="tipoProcedura"></param>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult compilaProcedure(string xtype, string tipoProcedura) 
		{

			bool ok = leggiTabella(mainDA, DS.syscomments, null, null, null);
			if (!ok) return DialogResult.Cancel;
			
			string filtro = "xtype ='"+xtype+"' and OBJECTPROPERTY(id, 'IsMSShipped')=0";
			if (xtype=="P") 
			{
				filtro += " and name not like 'sp_i%' and name not like 'sp_u%' and name not like 'sp_d%'";
			}

			ok = leggiTabella(targetDA, DS.sysobjects, null, filtro, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.sysobjects, tipoProcedura);

			foreach (DataRow rObject in DS.sysobjects.Rows) 
			{
				DialogResult dr = compilaUnaProcedura(rObject);
				if (dr==DialogResult.Cancel) return dr;
				progressBar1.Value ++;
				Application.DoEvents();
			}
			progressBar1.Value = 0;

			DS.syscomments.Clear();
			DS.sysobjects.Clear();
			return DialogResult.OK;
		}

		#endregion

		#region aggiornamento di RuleEnforcement

		/// <summary>
		/// Aggiorna la tabella ruleenforcement. Gli statement vengono compilati alla stessa stregua delle procedure
		/// ed i message subiscono anche una precompilazione.
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult aggiornaRuleEnforcement() 
		{
			bool ok = leggiTabella(targetDA, DS.auditcheck, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(mainDA, DS.tablename, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(mainDA, DS.colname, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.sysobjects, null, "(xtype="+QueryCreator.quotedstrvalue("U",true)+")", null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.auditcheck, "rule enforcement");

			foreach (DataRow re in DS.auditcheck.Rows) 
			{
				string statementCompilato = SPBridge.Compile(targetDA, re["statement"].ToString(), null);

				string messageCompilato;
				DialogResult dialogResult = compilaUnRuleEnforcement(re, out messageCompilato);
				if (dialogResult==DialogResult.Cancel) 
				{
					progressBar1.Value = 0;
					return DialogResult.Cancel;
				}
				DataRow[] rTableName = DS.tablename.Select("oldtable='"+re["dbtable"]+"'");
				if (rTableName.Length>0) 
				{
					re["dbtable"] = rTableName[0]["newtable"];
				}
				re["statement"] = statementCompilato;
				re["message"] = messageCompilato;
				progressBar1.Value ++;
				Application.DoEvents();
			}
			progressBar1.Value = 0;
			return scriviSulDataBase();
		}

		/// <summary>
		/// Stack delle chiamate:
		/// buttonRuleEnforcement_Click
		/// compilaUnRuleEnforcement
		/// compilaColonna
		/// cercaNelleTabellePadriEFiglie
		/// getTabellePadri - getTabelleFiglie - getNomiTabelle
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRuleEnforcement_Click(object sender, System.EventArgs e)
		{
			aggiornaRuleEnforcement();
		}

		private string traduciColonna(string oldCol) 
		{
			string filtro2 = 
				"(oldcol=" + QueryCreator.quotedstrvalue(oldCol, false) 
				+ ")and (not newcol like 'DELETE%')";
			DataRow[] rCol2 = DS.colname.Select(filtro2);
			IEnumerator e = rCol2.GetEnumerator();
			bool trovato = e.MoveNext();
			if (!trovato) 
			{
//				MessageBox.Show(this, "Non trovata la traduzione della colonna "+oldCol);
				return null;
			}
			DataRow r = (DataRow) e.Current;
			string newCol = r["newcol"].ToString();
			string traduzioni = "\n" + newCol + "(tab. " + r["oldtable"] + ")";
			bool errore = false;
			while (e.MoveNext()) 
			{
				DataRow r2 = (DataRow) e.Current;
				string alternativa = r2["newcol"].ToString();
				traduzioni += "\n" + alternativa + " (tab. " + r2["oldtable"] + ")";
				if (alternativa != newCol) 
				{
					errore = true;
				}
			}
			if (errore) 
			{
				MessageBox.Show(this, "Colonna "+oldCol+" tradotta in maniera differente:\n"
					+ traduzioni);
			}
			return newCol;
		}

		/// <summary>
		/// Dato un riferimento del tipo "[tabella].colonna", restituisce "[nuovonometabella.]nuovonomecolonna".
		/// Se la tabella viene omessa, allora la colonna verrà cercata tra tutte le tabelle padri e figlie
		/// della tabella principale.
		/// </summary>
		/// <param name="tabellaPrincipale">nome della tabella principale</param>
		/// <param name="riferimento">
		/// riferimento ad una colonna della tabella principale o di una sua tabella padre o figlia.
		/// </param>
		/// <returns>versione compilata del riferimento dato, ottenuto rinominando il nome della tabella e della colonna riferiti</returns>
		private string compilaColonna(string tabellaPrincipale, string riferimento) 
		{
			if (riferimento=="esercizio") return "esercizio";
			string tabella = tabellaPrincipale;
			string colonna = riferimento;
			int punto = riferimento.IndexOf('.');
			if (punto!=-1) 
			{
				tabella = riferimento.Substring(0,punto);
				colonna = riferimento.Substring(punto+1);
			}
			tabella = tabella.Trim().ToLower();
			colonna = colonna.Trim().ToLower();
			if (tabella.StartsWith("custom")) 
			{
				return tabella + "." + colonna;
			}
			string filtro = 				
				"(oldtable=" + QueryCreator.quotedstrvalue(tabella, false) 
				+ ") and (oldcol=" + QueryCreator.quotedstrvalue(colonna, false) 
				+ ")";
			DataRow[] rColonna = DS.colname.Select(filtro);
			if (rColonna.Length!=1) 
			{
				string compilata = cercaNelleTabellePadriEFiglie(tabellaPrincipale, colonna);
				if (compilata != null) 
				{
					return compilata;
				} 
				else 
				{
					return traduciColonna(colonna);
				}
			}
			string nuovaColonna = rColonna[0]["newcol"].ToString();
			if (punto==-1) return nuovaColonna;
			DataRow rTabella = rColonna[0].GetParentRow("tablenamecolname");
			return rTabella["newtable"] + "." + nuovaColonna;
		}

		/// <summary>
		/// Cerca la colonna data tra i padri e i figli della tabella data 
		/// </summary>
		/// <param name="tabella">Nome della tabella di cui cercare i padri e i figli</param>
		/// <param name="colonna">Colonna da cercare fra le colonne dei padri e dei figli di tabella</param>
		/// <returns>stringa del tipo "nometabella.colonnarinominata" 
		/// dove nometabella è il nuovo nome di una tabella padre o figlio della tabella data;
		/// colonnarinominata è il nuovo nome della colonna data
		/// </returns>
		private string cercaNelleTabellePadriEFiglie(string tabella, string colonna) 
		{
			DataRow[] rTabella = DS.sysobjects.Select("name='"+tabella+"'");
			int constid = Convert.ToInt32(rTabella[0]["id"]);

			DataRow[] padri = getTabellePadri(constid);
			DataRow[] figlie = getTabelleFiglie(constid);
			string[][] nomi = getNomiTabelle(padri, figlie);
			foreach (string[] nome in nomi) 
			{
				string filtro = 				
					"(oldtable='"
					+ nome[0]
					+ "') and (oldcol='" 
					+ colonna
					+ "')";

				DataRow[] rColonna = DS.colname.Select(filtro);
				if (rColonna.Length==1) 
				{
					return nome[1] + "." + rColonna[0]["newcol"];
				}
			}
			return null;
		}

		/// <summary>
		/// Dati due insiemi di DataRow che contengono informazioni relative a tabelle
		/// restituisce per ciascuna tabella il vecchio ed il nuovo nome che deve assumere dopo la compilazione
		/// </summary>
		/// <param name="padri">primo insieme di DataRow della tabella sysobjects relativi a tabelle utente</param>
		/// <param name="figlie">secondo insieme di DataRow della tabella sysobjects relativi a tabelle utente</param>
		/// <returns>Matrice di stringhe, ciascuna riga contenente il vecchio ed il nuovo nome di una tabella padre o figlia della tabella data</returns>
		private string[][] getNomiTabelle(DataRow[] padri, DataRow[] figlie) 
		{
			string[][] nomi = new string[padri.Length + figlie.Length][];
			int contatore = 0;
			foreach (DataRow rPadre in padri) 
			{
				DataRow[] rVecchioNome = DS.tablename.Select("oldtable='"+rPadre["name"]+"'");
				nomi[contatore] = new string[] 
				{
					rVecchioNome[0]["oldtable"].ToString(),
					rVecchioNome[0]["newtable"].ToString(),
				};
				contatore ++;
			}
			foreach (DataRow rFiglia in figlie) 
			{
				DataRow[] rVecchioNome = DS.tablename.Select("oldtable='"+rFiglia["name"]+"'");
				nomi[contatore] = new string[] 
				{
					rVecchioNome[0]["oldtable"].ToString(),
					rVecchioNome[0]["newtable"].ToString(),
				};
				contatore ++;
			}
			return nomi;
		}

		/// <summary>
		/// Data una riga della tabella ruleenforcement, elabora la colonna "message" di tale riga e
		/// restituisce la versione compilata del valore ivi contenuto
		/// ossia sostituisce tutti i riferimenti.
		/// I riferimenti devono essere del tipo "[tabella.]colonna" e saranno
		/// trasformati in "[nuovonometabella.]nuovonomecolonna".
		/// </summary>
		/// <param name="re">Riga di ruleenforcement</param>
		/// <param name="compilato">Versione compilata della colonna data in ingresso</param>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult compilaUnRuleEnforcement(DataRow re, out string compilata) 
		{
			string tabella = re["dbtable"].ToString();
			string statement = re["message"].ToString();
			compilata = "";
			int inizio = statement.IndexOf("%<");
			int fine = 0;
			while (inizio!=-1) 
			{
				inizio += 2;
				compilata += statement.Substring(fine, inizio-fine);
				fine = statement.IndexOf(">%", inizio);
				string variabile = statement.Substring(inizio, fine-inizio);
//				bool figlioOPadre;
				string valoreVariabile = compilaColonna(tabella, variabile);
//				if (figlioOPadre) 
//				{
//					string messaggio = re["ruleid"]+"/"
//						+ re["dbtable"] + "/"
//						+ re["dboperation"] + "/"
//						+ re["enforcementid"]+ " - "
//						+ variabile + " -> "
//						+ valoreVariabile;
//					//					Console.WriteLine(messaggio);
//				}
				if (valoreVariabile==null) 
				{
					string errore =
						QueryCreator.WHERE_KEY_CLAUSE(re, DataRowVersion.Current, false)
						+ "\r\n\r\nRule Enforcement = '" + statement + "'"
						+ "\r\n\r\nvariabile non trovata = '" + variabile + "'";
					DialogResult dialogResult = visualizzaMsgBox(errore);
					if (dialogResult==DialogResult.Cancel) return dialogResult;
				}
				compilata += valoreVariabile;
				inizio = statement.IndexOf("%<", fine);
			}
			compilata += statement.Substring(fine);
			/*			Console.WriteLine(statement);
						Console.WriteLine("--------------------------");
						Console.WriteLine(nuovo);
						Console.WriteLine("==========================");*/
			return DialogResult.OK;
		}

		/// <summary>
		/// Restituisce un insieme di righe di sysobjects contenenti ciascuna informazioni
		/// relative ad una tabella padre della tabella avente id=fkeyid.
		/// </summary>
		/// <param name="fkeyid">Identificativo della tabella di cui si stanno cercando le tabelle padri</param>
		/// <returns>Righe contenenti informazioni relative ai padri della tabella data</returns>
		private DataRow[] getTabellePadri(int fkeyid) 
		{

			string query = "select distinct constid, rkeyid from sysforeignkeys where (fkeyid="+QueryCreator.quotedstrvalue(fkeyid, true)+")";
			bool ok = leggiAlcuneColonneDellaTabella(query, DS.sysforeignkeys);
/*			bool ok = leggiAlcuneColonneDellaTabella (//TODO da correggere
				DS.sysforeignkeys, 
				"distinct constid, rkeyid",
				null, 
				"(fkeyid="+QueryCreator.quotedstrvalue(fkeyid, true)+")", 
				null, null
				);*/
			if (!ok) return null;

			int numPadri = DS.sysforeignkeys.Rows.Count;
			DataRow[] padri = new DataRow[numPadri];
			for(int i=0; i<numPadri; i++) 
			{
				padri[i] = DS.sysforeignkeys.Rows[i].GetParentRow("sysobjectssysforeignkeys_padre");
			}
			return padri;
		}

		/// <summary>
		/// Restituisce un insieme di righe di sysobjects contenenti ciascuna informazioni
		/// relative ad una tabella figlia della tabella avente id=fkeyid.
		/// </summary>
		/// <param name="fkeyid">Identificativo della tabella di cui si stanno cercando le tabelle padri</param>
		/// <returns>Righe contenenti informazioni relative ai figli della tabella data</returns>
		private DataRow[] getTabelleFiglie(int rkeyid) 
		{
			string query = "select distinct constid, fkeyid from sysforeignkeys where (rkeyid="+QueryCreator.quotedstrvalue(rkeyid, true)+")";
			bool ok = leggiAlcuneColonneDellaTabella(query, DS.sysforeignkeys);
/*			bool ok = leggiAlcuneColonneDellaTabella (//TODO da correggere
				DS.sysforeignkeys, 
				"distinct constid, fkeyid",
				null, 
				"(rkeyid="+QueryCreator.quotedstrvalue(rkeyid, true)+")", 
				null, null
				);*/
			if (!ok) return null;

			int numFigli = DS.sysforeignkeys.Rows.Count;
			DataRow[] figli = new DataRow[numFigli];
			for(int i=0; i<numFigli; i++) 
			{
				figli[i] = DS.sysforeignkeys.Rows[i].GetParentRow("sysobjectssysforeignkeys_figlio");
			}
			return figli;
		}
		#endregion

		#region aggiornamento di CustomDirectRel, CustomIndirectRel, CustomGroupOperation

		/// <summary>
		/// Aggiorna le tabelle "customdirectrel" e "customdirectrelcol".
		/// Nella prima aggiorna i filtri "filter", "navigationfilterparent" e "insertfilterparent"
		/// ed i nomi delle tabelle in "fromtable" e "totable".
		/// Nella seconda aggiorna i nomi delle colonne in "fromfield" e "tofield".
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult aggiornaCustomDirectRel() 
		{
			bool ok = leggiTabella(mainDA, DS.tablename, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(mainDA, DS.colname, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.customdirectrel, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.customdirectrelcol, null, null, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.customdirectrel, "custom direct rel");

			foreach (DataRow r in DS.customdirectrel.Rows) 
			{
				aggiornaFiltro(r, "totable", "filter");
				aggiornaFiltro(r, "fromtable", "navigationfilterparent");
				aggiornaFiltro(r, "fromtable", "insertfilterparent");

				foreach (DataRow rChild in r.GetChildRows("customdirectrelcustomdirectrelcol"))
				{
					DialogResult dr = aggiornaNomeColonna(r["fromtable"], rChild, "fromfield");
					if (dr == DialogResult.Cancel) return DialogResult.Cancel;

					object toTable = r["totableview"] is DBNull ? r["totable"] : r["totableview"];
					dr = aggiornaNomeColonna(toTable, rChild, "tofield");
					if (dr == DialogResult.Cancel) return DialogResult.Cancel;
				}

				DialogResult res = aggiornaNomeTabella(r, "fromtable");
				if (res == DialogResult.Cancel) return DialogResult.Cancel;

				res = aggiornaNomeTabella(r, "totable");
				if (res == DialogResult.Cancel) return DialogResult.Cancel; 

				progressBar1.Value ++;
				Application.DoEvents();
			}
			return scriviSulDataBase();
		}

		private void buttonDirectRel_Click(object sender, System.EventArgs e)
		{
			aggiornaCustomDirectRel();
		}

		/// <summary>
		/// Prerequisito: la tabella DS.tablename deve essere già riempita.
		/// Dato un DataRow ed il nome di una sua colonna, aggiorna il nome della tabella che è lì contenuto.
		/// </summary>
		/// <param name="r">DataRow da aggiornare</param>
		/// <param name="colonnaVecchioNomeTabella">colonna di r da aggiornare</param>
		/// <returns>
		/// DialogResult.Cancel se c'è stato un problema e l'utente ha deciso di annullare tutte le operazioni.
		/// DialogResult.OK se tutto è andato bene oppure l'utente ha deciso di ignorare un eventuale errore.
		/// </returns>
		private DialogResult aggiornaNomeTabella(DataRow r, string colonnaVecchioNomeTabella) 
		{
			string query = "oldtable="+QueryCreator.quotedstrvalue(r[colonnaVecchioNomeTabella], false);
			DataRow[] rTableName = DS.tablename.Select(query);
			if (rTableName.Length != 1) 
			{
				return visualizzaMsgBox (
					"Errore durante l'aggiornamento del nome della tabella "+r.Table.TableName
					+ "\r\n\r\n" + QueryCreator.WHERE_KEY_CLAUSE(r, DataRowVersion.Current, false)
					+ "\r\n\r\nHo trovato "+rTableName.Length+" righe corrispondenti alla seguente query:"
					+ "\r\n" + query
					);
			}
			r[colonnaVecchioNomeTabella] = rTableName[0]["newtable"];
			return DialogResult.OK;
		}

		/// <summary>
		/// Prerequisito: la tabella DS.tablename deve essere già riempita.
		/// Dato un nome di tabella, un DataRow ed il nome di una sua colonna, aggiorna il nome della colonna che è lì contenuto.
		/// </summary>
		/// <param name="vecchioNomeTabella">nome della tabella a cui appartiene il nome di colonna da aggiornare</param>
		/// <param name="r">DataRow da aggiornare</param>
		/// <param name="colonnaVecchioNomeTabella">colonna di r da aggiornare</param>
		/// <returns>
		/// DialogResult.Cancel se c'è stato un problema e l'utente ha deciso di annullare tutte le operazioni.
		/// DialogResult.OK se tutto è andato bene oppure l'utente ha deciso di ignorare un eventuale errore.
		/// </returns>
		private DialogResult aggiornaNomeColonna(object vecchioNomeTabella, DataRow r, string colonnaVecchioNomeColonna) 
		{
			string oldtable = QueryCreator.quotedstrvalue(vecchioNomeTabella, false);
			string oldcol = QueryCreator.quotedstrvalue(r[colonnaVecchioNomeColonna], false);
			string query = "(oldtable=" + oldtable + ") and (oldcol=" + oldcol + ")";
			DataRow[] rColName = DS.colname.Select(query);
			if (rColName.Length != 1) 
			{
				return visualizzaMsgBox (
					"Errore durante l'aggiornamento del nome delle colonne in "+r.Table.TableName
					+ "\r\n\r\n" + QueryCreator.WHERE_KEY_CLAUSE(r, DataRowVersion.Current, false)
					+ "\r\n\r\nHo trovato "+rColName.Length+" righe corrispondenti alla seguente query:"
					+ "\r\n" + query
					);
			}
			r[colonnaVecchioNomeColonna] = rColName[0]["newcol"];
			return DialogResult.OK;
		}

		/// <summary>
		/// Dato un DataRow ed i nomi delle sue due colonne in cui sono contenuti rispettivamente
		/// il nome di una tabella ed un filtro abbinato a tale tabella, aggiorna tale filtro
		/// </summary>
		/// <param name="rCustomRel">DataRow da aggiornare</param>
		/// <param name="nomeTabella">colonna di rCustomRel contenente il nome della tabella a cui è associato il filtro</param>
		/// <param name="nomeFiltro">colonna di rCustomRel contenente il filtro da aggiornare</param>
		private void aggiornaFiltro(DataRow rCustomRel, string nomeTabella, string nomeFiltro) 
		{
			string tabella = rCustomRel[nomeTabella].ToString();
			string filtro = rCustomRel[nomeFiltro].ToString();
			Aliases aliases = new Aliases();
			aliases.AddAlias(tabella, tabella);
			string s1 = compilaStringaPartendoDaTabFiglia(aliases, filtro, tabella);
			string s2 = compilaStringaPartendoDaTabPadre(aliases, s1, tabella);
			string compilato = SPBridge.Compile(mainDA, s2, aliases);
			rCustomRel[nomeFiltro] = compilato;
		}
		/// <summary>
		/// Sostituisce tutte le occorrenze di "Parent(TabellapadreTabellaFiglia)" o "Child(TabellapadreTabellaFiglia)"
		/// con "Parent(NuovatabellapadreNuovatabellafiglia)" o "Child(NuovatabellapadreNuovatabellafiglia)"
		/// a seconda che si passi come "stringaDaCercare" "Parent(" o "Child(".
		/// Vengono inoltre aggiunti ad "aliases" gli alias ("Parent(NuovatabellapadreNuovatabellafiglia)", tabellapadre)
		/// o ("Child(NuovatabellapadreNuovatabellafiglia)", tabellapadre).
		/// </summary>
		/// <param name="aliases">Insieme di alias di tabelle</param>
		/// <param name="filtro">filtro da compilare</param>
		/// <param name="stringaDaCercare">nome di funzione (può essere "Parent(" o "Child("</param>
		/// <param name="tabella">nome di tabella a cui è associato il filtro</param>
		/// <returns>Filtro aggiornato.</returns>
		private string compilaStringaPartendoDaTabFiglia(Aliases aliases, string filtro, string tabellaFiglia) 
		{
			string stringaDaCercare = "Parent(";
			int inizio = filtro.IndexOf(stringaDaCercare);
			if (inizio==-1) return filtro;
			int fine = 0;
			string nuovaStringa = filtro.Substring(0, inizio);
			while (inizio!=-1) 
			{
				fine = filtro.IndexOf(tabellaFiglia + ")", inizio);
				inizio += stringaDaCercare.Length;

				string table = filtro.Substring(inizio, fine-inizio);

				DataRow[] rPadre = DS.tablename.Select("oldtable="+QueryCreator.quotedstrvalue(table, false));
				string padre = rPadre[0]["newtable"].ToString();
				DataRow[] rFiglio = DS.tablename.Select("oldtable="+QueryCreator.quotedstrvalue(tabellaFiglia, false));
				string figlio = rFiglio[0]["newtable"].ToString();

				string alias = stringaDaCercare + padre + figlio + ")";
				nuovaStringa += alias;

				aliases.AddAlias(table, alias);

				inizio = filtro.IndexOf(stringaDaCercare, fine);
			}
			nuovaStringa += filtro.Substring(fine + tabellaFiglia.Length + 1);
			return nuovaStringa;
		}

		private string compilaStringaPartendoDaTabPadre(Aliases aliases, string filtro, string tabellaPadre) 
		{
			string stringaDaCercare = "Child(";
			int inizio = filtro.IndexOf(stringaDaCercare);
			if (inizio==-1) return filtro;
			int fine = 0;
			string nuovaStringa = filtro.Substring(0, inizio);
			while (inizio!=-1) 
			{
				inizio += stringaDaCercare.Length + tabellaPadre.Length;
				fine = filtro.IndexOf(")", inizio);
				string tabFiglia = filtro.Substring(inizio, fine - inizio);

				DataRow[] rPadre = DS.tablename.Select("oldtable="+QueryCreator.quotedstrvalue(tabellaPadre, false));
				string padre = rPadre[0]["newtable"].ToString();
				DataRow[] rFiglio = DS.tablename.Select("oldtable="+QueryCreator.quotedstrvalue(tabFiglia, false));
				string figlio = rFiglio[0]["newtable"].ToString();

				string alias = stringaDaCercare + padre + figlio + ")";
				nuovaStringa += alias;

				aliases.AddAlias(tabFiglia, alias);

				inizio = filtro.IndexOf(stringaDaCercare, fine);
			}
			nuovaStringa += filtro.Substring(fine + 1);
			return nuovaStringa;
		}

		/// <summary>
		/// Aggiorna le tabelle "customindirectrel" e "customindirectrelcol".
		/// Nella prima aggiorna i filtri "filterparenttable2", "filtermiddle", "navigationfilterparenttable1", "insertfilterparenttable1"
		/// ed i nomi delle tabelle in "parenttable1", "parenttable2" e "middletable".
		/// Nella seconda aggiorna i nomi delle colonne in "parentfield" e "middlefield".
		/// </summary>
		private DialogResult aggiornaCustomIndirectRel() 
		{
			bool ok = leggiTabella(mainDA, DS.tablename, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(mainDA, DS.colname, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.customindirectrel, null, null, null);
			if (!ok) return DialogResult.Cancel;

			ok = leggiTabella(targetDA, DS.customindirectrelcol, null, null, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.customindirectrel, "custom indirect rel");
			foreach (DataRow r in DS.customindirectrel.Rows) 
			{
				aggiornaFiltro(r, "parenttable2", "filterparenttable2");
				aggiornaFiltro(r, "middletable", "filtermiddle");
				aggiornaFiltro(r, "parenttable1", "navigationfilterparenttable1");
				aggiornaFiltro(r, "parenttable1", "insertfilterparenttable1");

				foreach (DataRow rChild in r.GetChildRows("customindirectrelcustomindirectrelcol")) 
				{
					int parentNumber = Convert.ToInt32(rChild["parentnumber"]);
					object parentTable = (parentNumber==1) ? r["parenttable1"] : r["parenttable2"];

					DialogResult dr = aggiornaNomeColonna(parentTable, rChild, "parentfield");
					if (dr == DialogResult.Cancel) return DialogResult.Cancel;

					dr = aggiornaNomeColonna(r["middletable"], rChild, "middlefield");
					if (dr == DialogResult.Cancel) return DialogResult.Cancel;
				}
				
				DialogResult res = aggiornaNomeTabella(r, "parenttable1");
				if (res == DialogResult.Cancel) return DialogResult.Cancel;

				res = aggiornaNomeTabella(r, "parenttable2");
				if (res == DialogResult.Cancel) return DialogResult.Cancel;

				res = aggiornaNomeTabella(r, "middletable");
				if (res == DialogResult.Cancel) return DialogResult.Cancel;

				progressBar1.Value ++;
				Application.DoEvents();
			}
			return scriviSulDataBase();
		}

		private void buttonIndirectRel_Click(object sender, System.EventArgs e) 
		{
			aggiornaCustomIndirectRel();
		}

		/// <summary>
		/// Aggiorna la tabella customgroupoperation cambiando i nomi delle tabelle
		/// contenuti nella colonna dbtable
		/// </summary>
		/// <returns>
		/// DialogResult.OK se non ci sono stati errori oppure l'utente ha deciso di ignorare l'eventuale errore.
		/// DialogResult.CANCEL se ci sono stati errori e l'utente ha deciso di interrompere l'esecuzione del programma.
		/// </returns>
		private DialogResult aggiornaCustomGroupOperation() 
		{
			bool ok = leggiTabella(mainDA, DS.tablename, null, null, null);
			if (!ok) return DialogResult.Cancel;

			string filtro = "(operation=" + QueryCreator.quotedstrvalue("S", true) +")";

			ok = leggiTabella(targetDA, DS.customgroupoperation, null, filtro, null);
			if (!ok) return DialogResult.Cancel;

			inizializzaProgressBar(DS.customgroupoperation, "custom group operation");
			foreach (DataRow r in DS.customgroupoperation.Rows) 
			{
				DialogResult dr = aggiornaNomeTabella(r, "tablename");
				if (dr==DialogResult.Cancel) return dr;
				progressBar1.Value ++;
			}
			return scriviSulDataBase();
		}

		private void buttonGroupOperation_Click(object sender, System.EventArgs e)
		{
			aggiornaCustomGroupOperation();
		}
		#endregion

		#region aggiornamento di Parameter

		private DialogResult aggiornaParameter() 
		{
			leggiTabella(mainDA, DS.tablename, null, null, null);
			leggiTabella(mainDA, DS.ruleparameter, null, null , null);
			leggiTabella(mainDA, DS.colname, null, null, null);
			inizializzaProgressBar(DS.ruleparameter, "parameter");
			foreach(DataRow r in DS.ruleparameter.Rows) 
			{
				DataRow[] rTableName = DS.tablename.Select("oldtable='"+r["tablename"]+"'");
				if (rTableName.Length > 0) 
				{
					r["tablename"] = rTableName[0]["newtable"];
				} 

				DataRow[] rColName = DS.colname.Select("oldtable='"+r["paramtable"]+"' and oldcol='"+r["paramcolumn"]+"'");
				if (rColName.Length > 0) 
				{
					r["paramcolumn"] = rColName[0]["newcol"];
				} 

					rTableName = DS.tablename.Select("oldtable='"+r["paramtable"]+"'");
				if (rTableName.Length > 0) 
				{
					r["paramtable"] = rTableName[0]["newtable"];
				} 

				progressBar1.Value ++;
				Application.DoEvents();
			}
			return scriviSulDataBase();
		}

		private void buttonParameter_Click(object sender, System.EventArgs e)
		{
			aggiornaParameter();
			progressBar1.Value = 0;
		}

		#endregion

		#region aggiornamento DB

		private void buttonAggiornamentoDB_Click(object sender, System.EventArgs e)
		{
			compilaDB();
			labelOperazione.Text = null;
			progressBar1.Value = 0;
		}

		/// <summary>
		/// Lancia in sequenza tutte le compilazioni per aggiornare il DataBase.
		/// </summary>
		private void compilaDB() 
		{
			if (aggiornaParameter()==DialogResult.Cancel) return;
			if (aggiornaCustomDirectRel()==DialogResult.Cancel) return;
			if (aggiornaCustomIndirectRel()==DialogResult.Cancel) return;
			if (aggiornaCustomGroupOperation()==DialogResult.Cancel) return;
			if (aggiornaRuleEnforcement()==DialogResult.Cancel) return;
			if (rinominaColonne()==DialogResult.Cancel) return;
			if (rinominaTabelle()==DialogResult.Cancel) return;
			if (rinominaProcedure()==DialogResult.Cancel) return;
			if (compilaProcedure("V", "viste")==DialogResult.Cancel) return;
			if (compilaProcedure("TR", "trigger")==DialogResult.Cancel) return;
			if (compilaProcedure("P", "procedure")==DialogResult.Cancel) return;
			if (rinominaForeignKeys()==DialogResult.Cancel) return;
			if (rinominaPrimaryKeys()==DialogResult.Cancel) return;
			if (rinominaUnique()==DialogResult.Cancel) return;
			MessageBox.Show(this, "DB aggiornato!");
		}

		#endregion

		#region Aggiornamento del DataSet

		/// <summary>
		/// Restituisce il nuovo nome che deve assumemere una colonna andandolo a leggere dalla tabella "colname"
		/// </summary>
		/// <param name="oldTable">vecchio nome della tabella a cui appartiene la tabella da rinominare</param>
		/// <param name="oldcol">vecchio nome della colonna da rinominare</param>
		/// <returns>nuovo nome che deve assumere la colonna</returns>
		private string nuovoNomeColonna(string oldTable, string oldcol) 
		{
			if (oldcol.StartsWith("!")) return oldcol;
			DataRow[] rColName = DS.colname.Select("oldtable='"+oldTable+"' and oldcol='"+oldcol+"'");
			if (rColName.Length==0) return oldcol;
			return rColName[0]["newcol"].ToString();
		}

		/// <summary>
		/// Restituisce il nuovo nome che deve assumere una tabella andandolo a leggere dalla tabella "tablename"
		/// </summary>
		/// <param name="oldTable">vecchio nome della tabella</param>
		/// <returns>nuovo nome che deve assumere la tabella</returns>
		private string nuovoNomeTabella(string oldTable) 
		{
			DataRow[] rTableName = DS.tablename.Select("oldtable='"+oldTable+"'");
			if (rTableName.Length == 0) return oldTable;
			return rTableName[0]["newtable"].ToString();
		}

		/// <summary>
		/// Aggiorna tutti i nomi delle tabelle e delle relazioni di un dataset
		/// </summary>
		/// <param name="nomeFile">nome del file (.xsd) in cui è contenuto il dataset</param>
		/// <param name="ds">dataset da aggiornare</param>
		/// <returns>true se aggiornamento OK; false se c'è stato qualche problema</returns>
		private bool compilaDataSet(string nomeFile) 
		{
			DataSet ds = new DataSet();
			ds.ReadXml(nomeFile);
			string NameWithoutExtension= nomeFile.Substring(0,nomeFile.Length-3);
			string XSXName= NameWithoutExtension+"xsx";
			StreamReader TR = new StreamReader(XSXName, Encoding.Default);
			string XSXString = TR.ReadToEnd();
			TR.Close();
			int lastslash=nomeFile.LastIndexOf("\\");
			int myslash = nomeFile.Substring(0,lastslash-1).LastIndexOf("\\");
			string DSName = nomeFile.Substring(myslash+1);

			
			string CSString=null;
			string CSName=null;
			try {
				CSName= NameWithoutExtension+"cs";
				StreamReader TR2 = new StreamReader(CSName, Encoding.Default);
				CSString = TR2.ReadToEnd();
				string olddsname=ds.DataSetName;
				CSString = CSString.Replace(olddsname,"vistaForm");
				TR2.Close();
			}
			catch{}

			//DSName=DSName.Substring(0,DSName.Length-1);



			bool result = true;
			foreach (DataTable t in ds.Tables) 
			{
				DataRow[] rAlias = DS.alias.Select("dataset='"+DSName+"' and tabella='"+t.TableName+"'");

				if ((rAlias.Length==0) || !(rAlias[0]["alias"] is DBNull)) {
				 //non è una tabella temporanea
					string oldTable = (rAlias.Length==0) ? t.TableName : rAlias[0]["alias"].ToString();
					string nnt = nuovoNomeTabella(oldTable);
					XSXString = XSXString.Replace("<"+oldTable+"_XmlElement",
						"<"+nnt+"_XmlElement");
					if (nnt==oldTable) {
						//Console.WriteLine("TABELLA NON TRADOTTA:  "+t.TableName);
						//result = false;
					} 
					ArrayList colonneDaCancellare = new ArrayList();
					foreach (DataColumn c in t.Columns) {
						DataRow[] rAliasCol = DS.aliascol.Select("dataset='"+DSName+"' and tabella='"+oldTable+"' and colonna='"+c.ColumnName+"'");
						if (rAliasCol.Length==0) {
							string nnc = nuovoNomeColonna(oldTable, c.ColumnName);
							if (nnc!=null) {
								if (nnc.ToLower().StartsWith("delete_")) {
									colonneDaCancellare.Add(c);
								} 
								else {
									if (c.ColumnName.ToLower()==nnc.ToLower() && c.ColumnName!=nnc){
										c.ColumnName="xisuasassasasasaiusiasauisa";
										c.ColumnName=nnc;
									}
									else {
										if (t.Columns[nnc]==null)
											c.ColumnName = nnc;
										else {
											if (c.Caption!=nnc){
												c.ColumnName="excol_"+c.ColumnName+"_future_"+nnc;
												MessageBox.Show("table "+t.TableName+" col."+c.ColumnName);
											}
										}
									}
								}
							}
						}
					}
					foreach (DataColumn c in colonneDaCancellare) {
						try {
							t.Columns.Remove(c);
						} catch (ArgumentException e) {
							Console.WriteLine(t.TableName+"."+c.ColumnName+": "+e.Message);
						}
					}

					if (rAlias.Length==0) {
						 //è una tabella reale
						t.TableName = nnt;
					}
					
				}
			}

			Hashtable h = new Hashtable();

			foreach (DataRelation r in ds.Relations) 
			{
				string[] chiave = new string[] {r.ChildTable.TableName, r.ParentTable.TableName};
				ArrayList AL = (ArrayList) h[chiave];
				if (AL==null){
					AL= new ArrayList();
					h[chiave]= AL;
				}
				AL.Add(r.RelationName);
			}

			foreach (DictionaryEntry de in h) 
			{
				string[] relazione = (string[]) de.Key;
				ArrayList al = (ArrayList) de.Value;
				
				string VecchioNome= al[0].ToString();
				string nuovoNome = relazione[0]+relazione[1];

				if (ds.Relations[nuovoNome]==null){
					XSXString= XSXString.Replace(VecchioNome+"_XmlKeyref",nuovoNome+"_XmlKeyref");
					ds.Relations[VecchioNome].RelationName = nuovoNome;
				}
				
				for (int i=1; i<al.Count; i++) 
				{
					string nnome=nuovoNome+"_"+i.ToString();
					if (ds.Relations[nnome]==null){
					
						XSXString= XSXString.Replace(VecchioNome+"_XmlKeyref",nnome+"_XmlKeyref");
						ds.Relations[al[i].ToString()].RelationName = nuovoNome+"_"+i;
					}
				}
			}
			if ((ds.Namespace.IndexOf("vista")>=0)||(ds.Namespace.IndexOf("Vista")>=0)){
				string oldnamespace= ds.Namespace;
				//ds.Namespace="vistaForm";
				ds.DataSetName="vistaForm";
				int i=0;
				foreach(DataTable T in ds.Tables){
					foreach (Constraint CC in T.Constraints){
						i++;
						if (T.Constraints["vistaFormKey"+i.ToString()]==null){
							CC.ConstraintName= "vistaFormKey"+i.ToString();
						}
					}
				}	
			}


			if (result) {
				File.SetAttributes(nomeFile,FileAttributes.Archive);
				File.SetAttributes(XSXName,FileAttributes.Archive);
				//ds.Namespace= 
				ds.WriteXmlSchema(nomeFile);		
				StreamWriter TW= new StreamWriter(XSXName,false,Encoding.Default);
				TW.Write(XSXString);
				TW.Flush();
				TW.Close();
				if (CSString!=null){
					File.SetAttributes(CSName,FileAttributes.Archive);
					StreamWriter TW2= new StreamWriter(CSName,false,Encoding.Default);
					TW2.Write(CSString);
					TW2.Flush();
					TW2.Close();
				}


			}
			return result;
		}

		/// <summary>
		/// Scandisce una directory e tutte le sue sottodirectory per cercare tutti i file .xsd
		/// (i dataset), ed aggiorna tali file chiamando il metodo compilaDataSet
		/// </summary>
		/// <param name="path">directory radice della solution</param>
		/// <param name="di">directory da scandire per cercare i dataset</param>
		private void CambiaDataSetInDirectory(string path, DirectoryInfo di) 
		{
			int lunghezzaPath = path.Length;
			foreach (FileInfo fi in di.GetFiles("*.xsd")) 
			{
				if (!compilaDataSet(fi.FullName)) {
					Console.WriteLine("ERRORE ================== "+fi.FullName+"\r\n");
				}
				
			}

			foreach (DirectoryInfo subdir in di.GetDirectories()) 
			{
				CambiaDataSetInDirectory(path, subdir);
			}

		}

		private void buttonDataSet_Click(object sender, System.EventArgs e)
		{
			string errore = mainDA.LastError;
			leggiTabella(mainDA, DS.tablename, null, null, null);
			leggiTabella(mainDA, DS.colname, null, null, null);
			leggiTabella(mainDA, DS.alias, null, null, null);
			leggiTabella(mainDA, DS.aliascol, null, null, null);
			string path = DRIVE+DIRECTORY;
			CambiaDataSetInDirectory(path, new DirectoryInfo(path));
		}

		#endregion

		#region inizializza tabelle di rename progetti e form

		/// <summary>
		/// Partendo dal nome di un metadato e per ogni edittype 
		/// scrive nella tabella ren_form le informazioni relative al form
		/// restituito dalla chiamata al metodo GetForm(edittype) di tale metadato.
		/// </summary>
		/// <param name="metaDataName">Nome del metadato associato a dei form tramite alcuni edittype</param>
		private void scriviSuTabellaRenForm(string metaDataName) {
			//			Console.WriteLine("METADATA: "+metaDataName);
			MetaData metaForm = MetaData.GetMetaData(this,"ren_form");
#pragma warning disable 612
			MetaData meta2 = metaForm.Dispatcher.Get(metaDataName);
#pragma warning restore 612
			if (typeof(Meta_easydata)==meta2.GetType()) {
				MessageBox.Show("Warning: il metadato '" + metaDataName + "' non esiste.");
			}
			switch (metaDataName) {
				case "resultparameter": 
					meta2.ExtraParameter = "Compensi-Altre.rieprite";
					break;
				case "export": 
					meta2.ExtraParameter = "esportazione_avanzo_amministrazione";
					break;
				case "persgenautomovimenti":
					meta2.ExtraParameter = DRIVE+@"\software\utility\Esegui770\bin\debug\Esegui770.exe";
					break;
			}
			metaForm.SetDefaults(DS.ren_form);
			foreach (string editType in meta2.EditTypes) {
				DataRow rForm;
				if (DS.ren_form.Select("(metadata="+QueryCreator.quotedstrvalue(metaDataName,false)+")and"+
					"(edittype="+QueryCreator.quotedstrvalue(editType,false)+")").Length==0){
					rForm = metaForm.Get_New_Row(null, DS.ren_form);
					rForm["metadata"] = metaDataName;
					rForm["edittype"] = editType;
				}
				else {
					rForm = DS.ren_form.Select("(metadata="+QueryCreator.quotedstrvalue(metaDataName,false)+")and"+
						"(edittype="+QueryCreator.quotedstrvalue(editType,false)+")")[0];
				}

				Form form=null;
				try {
					form=meta2.GetPublicForm(editType);
				}
				catch (Exception E) {
					QueryCreator.ShowException(E);
				}

				if (form==null) {
					MessageBox.Show("Warning: Non esiste il form '"+editType+"' della tabella '"+metaDataName+"'");
					continue;
				} 
				else {
					Type type = form.GetType();
					/*					string nameSpace = type.Namespace;
											string name = type.Name;
											//				Console.WriteLine(editType+" "+form.GetType());*/
					rForm["namespace"] = type.Namespace;
					rForm["form"] = type.Name;
				}
			}	
			
		}

		/// <summary>
		/// Apre la solution e, per ogni progetto contenuto, memorizza nella tabella "ren_progetto"
		/// l'identificativo, il nome, la directory ed il nome del file .csproj.
		/// Se il nome del progetto comincia per "meta_" (cioè è un metadata), allorachiama 
		/// il metodo scriviSuRenForm
		/// per aggiungere alla tabella ren_form i form che vengono resituiti dal metodo GetForm
		/// del metadata in questione.
		/// </summary>
		/// <param name="path">directory in cui si trova la solution</param>
		/// <returns>identificativo della solution data</returns>
		private string scriviTabelleProgettiEForm(string solutionPath) 
		{
			string progetto = DS.ren_progetto.TableName;
			MetaData mProg = MetaData.GetMetaData(this, progetto);

			//DataTable t = mProg.Conn.SQLRunner("truncate table "+progetto);
			//t = mProg.Conn.SQLRunner("truncate table ren_form");
			mProg.Conn.RUN_SELECT_INTO_TABLE(DS.ren_progetto,null,null,null,false);
			mProg.Conn.RUN_SELECT_INTO_TABLE(DS.ren_form,null,null,null,false);


			FileInfo solution = new FileInfo(solutionPath);
			progressBar1.Maximum = Solution.contaProgetti(solution);
			StreamReader sr = solution.OpenText();
			sr.ReadLine();
			string line = sr.ReadLine();
			string idSolution = line.Substring(9, 38);
			mProg.SetDefaults(DS.ren_progetto);

			while (line.StartsWith("Project(\"{"))
			{
				string package = line.Substring(9, 38);

				int fine1 = line.IndexOf('"', 53);
				int inizio2 = fine1 + 4;
				int fine2 = line.IndexOf('"', inizio2);

				string csproj = line.Substring(inizio2, fine2-inizio2);
				int pos = csproj.LastIndexOf('\\');
				string nomeProgetto = line.Substring(53, fine1 - 53);
				if ((idSolution != package)&&(nomeProgetto != "SetupCrystalMerge")) 
				{
					MessageBox.Show("Errore nella solution "+idSolution+"\r\n"+line);
				}
				string idprogetto=line.Substring(fine2 + 4, 38);
				DataRow rRenProgetto;
				if (DS.ren_progetto.Select("idprogetto="+
					QueryCreator.quotedstrvalue(idprogetto,false)).Length==0){
					rRenProgetto = mProg.Get_New_Row(null, DS.ren_progetto);
					rRenProgetto["idprogetto"] = line.Substring(fine2 + 4, 38);
				}
				else {
					rRenProgetto=DS.ren_progetto.Select("idprogetto="+
					QueryCreator.quotedstrvalue(idprogetto,false))[0];
				}
				rRenProgetto["progetto"] = nomeProgetto;
				rRenProgetto["directory"] = csproj.Substring(0, pos);
				rRenProgetto["csproj"] = csproj.Substring(pos + 1);

				if (nomeProgetto.StartsWith("meta_")) 
				{
					scriviSuTabellaRenForm(nomeProgetto.Substring(5));
				}

				sr.ReadLine();
				sr.ReadLine();
				sr.ReadLine();
				progressBar1.Value ++;
				Application.DoEvents();
				line = sr.ReadLine();
			}
			progressBar1.Value = 0;
			return idSolution;
		}

		#endregion

		#region inizializza tabelle di rename dei riferimenti e dei file inclusi

		/// <summary>
		/// Data una lista di riferimenti a progetti, 
		/// per ciascun riferimento scrive nella tabella ren_riferimento
		/// l'identificativo ed il nome del progetto riferito.
		/// </summary>
		/// <param name="mRif"></param>
		/// <param name="rProgetto"></param>
		/// <param name="list"></param>
		/// <param name="fileName"></param>
		/// <param name="package"></param>
		private void scriviSuRenRiferimento(MetaData mRif, DataRow rProgetto, XmlNodeList list, string fileName, string package) 
		{
			mRif.SetDefaults(DS.ren_riferimento);
			foreach (XmlElement progetto in list) 
			{
				string idprogetto= rProgetto["idprogetto"].ToString();
				string idriferimento = progetto.GetAttribute("Project");
				DataRow rRif;
				if (DS.ren_riferimento.Select("(idprogetto="+QueryCreator.quotedstrvalue(idprogetto,false)+")and"+
					"(idriferimento="+QueryCreator.quotedstrvalue(idriferimento,false)+")").Length==0){
					rRif = mRif.Get_New_Row(rProgetto, DS.ren_riferimento);					
					rRif["idriferimento"] = progetto.GetAttribute("Project");
				}
				else {
					rRif=DS.ren_riferimento.Select("(idprogetto="+QueryCreator.quotedstrvalue(idprogetto,false)+")and"+
					"(idriferimento="+QueryCreator.quotedstrvalue(idriferimento,false)+")")[0];
				}

				rRif["riferimento"] = progetto.GetAttribute("Name");
				rRif["private"] = progetto.GetAttribute("Private");
				if (progetto.GetAttribute("Package") != package) 
				{
					MessageBox.Show(this, "Errore nel riferimento "
						+ rRif["riferimento"]
						+ " del progetto " 
						+ fileName
						+ "\r\nIdSolution = "
						+ package
						+ "\r\nPackage = "
						+ package
						);
				}
			}
		}

		/// <summary>
		/// Data una lista di file inclusi in un progetto, per ciascun file
		/// scrive nella tabella ren_cs il nome della directory in cui si trova il file ed il nome del file.
		/// Inoltre, se si tratta di un form, allora memorizza tali informazioni anche nella tabella ren_form
		/// </summary>
		/// <param name="mFil">MetaData della tabella ren_cs</param>
		/// <param name="rProgetto">riga della tabella ren_progetto del progetto che include i file della lista "listaFile"</param>
		/// <param name="listaFile">lista dei file inclusi in un progetto</param>
		/// <param name="path">directory della solution</param>
		private void scriviSuRenFileInclusiEAggiornaRenForm(MetaData mFil, DataRow rProgetto, XmlNodeList listaFile, string path) {
			foreach (XmlElement file in listaFile) {
				mFil.SetDefaults(DS.ren_cs);
				string filtro = "directory=" + QueryCreator.quotedstrvalue(rProgetto["directory"], false)
					+ " and cs=" + QueryCreator.quotedstrvalue(file.GetAttribute("RelPath"), false);
				DataRow[] rSel = DS.ren_cs.Select(filtro);
				DataRow rFil = (rSel.Length == 0)
					? mFil.Get_New_Row(rProgetto, DS.ren_cs)
					: rSel[0];
				rFil["directory"] = rProgetto["directory"];
				rFil["cs"] = file.GetAttribute("RelPath");
				string subType = file.GetAttribute("SubType");
				rFil["subtype"] = subType;
				if (subType=="Form") 
				{
					string nomeFile = Path.Combine(path, rFil["directory"] + "\\" + rFil["cs"]);
					StreamReader sr = new StreamReader(nomeFile);
					string s = sr.ReadToEnd();
					int inizioNS = s.IndexOf("namespace ") + "namespace ".Length;
					int fineNS = s.IndexOfAny(new char[] {' ','\r'}, inizioNS);
					string nameSpace = s.Substring(inizioNS, fineNS-inizioNS);
					int inizioNomeClasse = s.IndexOf("public class ") + "public class ".Length;
					int fineNomeClasse = s.IndexOfAny(new char[] {' ','\r'}, inizioNomeClasse);
					string nomeClasse = s.Substring(inizioNomeClasse, fineNomeClasse-inizioNomeClasse);
					rProgetto["namespace"] = nameSpace;
					foreach (DataRow rForm in DS.ren_form.Select("namespace='"+nameSpace+"' and form='"+nomeClasse+"'"))
					{
						rForm["directory"] = rFil["directory"];
						rForm["cs"] = rFil["cs"];
					}
				}
			}
		}

		/// <summary>
		/// PREREQUISITO: la tabella ren_progetto deve essere precedentemente riempita
		/// mediante una chiamata al metodo scriviTabelleProgettiEForm
		/// SCOPO: 
		/// Per ogni progetto contenuto nella tabella ren_progetto chiama i metodi
		/// scriviSuRenRifProgetti e scriviSuRenFileInclusiEAggiornaRenForm per inserire nelle 
		/// rispettive tabelle i riferimenti agli altri progetti ed i file inclusi nel
		/// progetto corrente.
		/// </summary>
		/// <param name="package">identificativo della solution; serve per verficare la coerenza tra la solution
		/// ed i progetti da essa referenziati</param>
		/// <param name="path">directory della solution</param>
		private void scriviTabelleFileInclusiERifProgetti(string package, string path) 
		{
			string rifProgetto = DS.ren_riferimento.TableName;

			MetaData mRif = MetaData.GetMetaData(this, DS.ren_riferimento.TableName);
			MetaData mFil = MetaData.GetMetaData(this, DS.ren_cs.TableName);

			mRif.Conn.RUN_SELECT_INTO_TABLE(DS.ren_riferimento,null,null,null,false);
			mRif.Conn.RUN_SELECT_INTO_TABLE(DS.ren_cs,null,null,null,false);

			//DataTable t = mRif.Conn.SQLRunner("truncate table "+rifProgetto);
			//t = mFil.Conn.SQLRunner("truncate table "+DS.ren_cs.TableName);

			progressBar1.Maximum = DS.ren_progetto.Rows.Count;
			foreach (DataRow rProgetto in DS.ren_progetto.Rows) 
			{
				string fileName = Path.Combine(path, rProgetto["directory"] + "\\" + rProgetto["csproj"]);
				//				Console.WriteLine(fileName);
				XmlDocument doc = new XmlDocument();
				if (rProgetto["csproj"].ToString()!="SetupCrystalMerge.vdproj") 
				{
					doc.Load(fileName);
					
					XmlElement settings = (XmlElement) doc.SelectSingleNode("VisualStudioProject/CSHARP/Build/Settings");
					rProgetto["AssemblyName"] = settings.GetAttribute("AssemblyName");
					rProgetto["RootNamespace"] = settings.GetAttribute("RootNamespace");

					XmlElement config = (XmlElement) doc.SelectSingleNode("VisualStudioProject/CSHARP/Build/Settings/Config");
					rProgetto["OutputPath"] = config.GetAttribute("OutputPath");

					XmlNodeList riferimentiAiProgetti = doc.SelectNodes("VisualStudioProject/CSHARP/Build/References/Reference[@Project]");
					scriviSuRenRiferimento(mRif, rProgetto, riferimentiAiProgetti, fileName, package);

					XmlNodeList fileInclusi = doc.SelectNodes("VisualStudioProject/CSHARP/Files/Include/File[@BuildAction='Compile']");
					scriviSuRenFileInclusiEAggiornaRenForm(mFil, rProgetto, fileInclusi, path);
				}
				progressBar1.Value ++;
				Application.DoEvents();
			}
			progressBar1.Value = 0;
		}

		#endregion

		#region aggiornamento tabella di rename progetti

		private DialogResult eseguiQuery(string query) 
		{
			MetaData meta = MetaData.GetMetaData(this);
			DataTable t = meta.Conn.SQLRunner(query);
			return (t==null) ? visualizzaMsgBox(meta.Conn.LastError) : DialogResult.OK;
		}

		/// <summary>
		/// PREREQUISITO: questo metodo va chiamato dopo scriviTabelleProgettiEForm
		/// e scriviTabelleFileInclusiERifProgetti
		/// SCOPO:
		/// preleva informazioni da altre tabelle già riempite
		/// per completare la tabella ren_progetto
		/// </summary>
		private DialogResult aggiornaTabellaProgetti() 
		{

			/*			string query = "update ren_progetto set namespace = progetto";
						if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

						Hashtable h = new Hashtable();
						h.Add("UnFabbisogno",		"fabbisognoaggiuntivosingle");
						h.Add("TreeBilancio",		"bilanciotree");
						h.Add("listapaesi",			"paeselista");
						h.Add("ClassGerarchica",	"classtreecreddebi");
						h.Add("FrmCreditoreDebitore","CreditoreDebitore");
						h.Add("Pagamento",			"ModPagamentoCredDebi");
						h.Add("FrmPagamento",		"ModPagamentoCredDeb");
						h.Add("ClassificazioniRipartizioniFondi","classripartizionilista");
						//			h.Add("paese",				"paeselista");

						foreach (DictionaryEntry de in h) 
						{
							query = "update ren_progetto set namespace='" + de.Key + "' where progetto='" + de.Value + "'";
							if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;
						}*/

			string query = "update ren_progetto"
				+ " set nuovadirectory=m.metadata, tabella=m.metadata, edittype=m.edittype"
				+ " from ren_progetto p"
				+ " join ren_cs c on p.idprogetto=c.idprogetto"
				+ " join ren_form m on c.directory=m.directory and c.cs=m.cs";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

			query = "update ren_progetto"
				+ " set nuovadirectory=substring(progetto,6,200), tabella=substring(progetto,6,200), edittype='meta'"
				+ " where progetto like 'meta_%' and progetto!='MetaDataPanel'";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

			query = "update ren_progetto"
				+ " set nuovadirectory = v.realtable"
				+ " from ren_progetto p"
				+ " join ren_vista v on p.tabella=v.objectname and v.realtable is not null";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

			query = "update ren_progetto"
				+ " set nuovadirectory = t.newtable"
				+ " from tablename t"
				+ " where t.oldtable = nuovadirectory";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

			query = "update ren_progetto"
				+ " set nuovadirectory='unmanaged', nuovonome=progetto"
				+ " where tabella is null";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

			query = "update ren_progetto"
				+ " set nuovadirectory='', nuovonome=progetto"
				+ " where progetto='mainform'";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;
	
			query = "update ren_progetto"
				+ " set nuovonome = 'meta_' + isnull("
				+ " (select t.newtable from tablename t where t.oldtable=tabella)"
				+ " , tabella)"
				+ " where edittype = 'meta'";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;

			query = "update ren_progetto"
				+ " set nuovonome = isnull("
				+ " (select t.newtable from tablename t where t.oldtable=tabella)"
				+ " , tabella) + '_' + edittype"
				+ " where edittype != 'meta'";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;
			
			query = "update ren_progetto"
				+ " set numeroform ="
				+ " (select count(*) from ren_cs c where c.idprogetto=ren_progetto.idprogetto and c.subtype='form')";
			if (eseguiQuery(query)==DialogResult.Cancel) return DialogResult.Cancel;
			
			query = "update ren_progetto"
				+ " set referenti ="
				+ " (select count(*) from ren_riferimento r where ren_progetto.idprogetto=r.idriferimento)";
			return eseguiQuery(query);
		}

		#endregion

		#region Crea nuova solution

		private void buttonSolution_Click(object sender, System.EventArgs e)
		{
			FileInfo solution1 = new FileInfo(textBoxSolution.Text);//unidata0
			int posslash= textBoxSolution.Text.LastIndexOf("\\");
			SOLUTION= textBoxSolution.Text.Substring(posslash+1);
			FileInfo solution2 = new FileInfo(DRIVE+DIRECTORY+"\\"+SOLUTION);
			FileInfo solution3 = new FileInfo(DRIVE+DIRECTORY+@"\New"+SOLUTION);

			eseguiQuery("update ren_progetto set nuovireferenti = referenti");
			int numeroProgetti = Solution.setMainformFirst(solution1);
			creaNuovaSolution(solution1, solution2, numeroProgetti);
			aggiustaRiferimenti(solution2, solution3, numeroProgetti);

			DirectoryInfo dll = new DirectoryInfo(Path.Combine(solution1.DirectoryName, "dll"));
			copiaDirectory(dll, solution2.Directory.CreateSubdirectory("dll"));
			copiaDirectory(dll, solution2.Directory.CreateSubdirectory(@"mainform\bin\debug"));

			DirectoryInfo crystal = new DirectoryInfo(Path.Combine(solution1.DirectoryName, "SetupCrystalMerge"));
			copiaDirectory(crystal, solution2.Directory.CreateSubdirectory("SetupCrystalMerge"));
			scriviSulDataBase();
		}

		/// <summary>
		/// Copia i file di metaDataLibrary e metaCampusLibrary nella nuova solution
		/// </summary>
		/// <param name="dirDLLVecchiaSolution">directory della nuova solution</param>
		/// <param name="dirNuovaSolution">directory della nuova solution</param>
		private void copiaDirectory(DirectoryInfo sorgente, DirectoryInfo destinazione) 
		{
			foreach (FileInfo fileSorgente in sorgente.GetFiles()) 
			{
				string fileDestinazione = Path.Combine(destinazione.FullName, fileSorgente.Name);
				if (File.Exists(fileDestinazione)) 
				{
					File.SetAttributes(fileDestinazione, FileAttributes.Archive);
				}
				fileSorgente.CopyTo(fileDestinazione, true);
			}
			foreach (DirectoryInfo dir in sorgente.GetDirectories()) 
			{
				copiaDirectory(dir, destinazione.CreateSubdirectory(dir.Name));
			}
		}

		/// <summary>
		/// Restituisce la nuova directory in cui deve essere memorizzato un progetto
		/// andandolo a leggere dalla tabella ren_progetto
		/// </summary>
		/// <param name="progetto">vecchio nome del progetto di cui si vuole conoscere la nuova directory di memorizzazione</param>
		/// <returns>nuova cartella in cui memorizzare il progetto</returns>
		private string getNuovaCartellaProgetto(string progetto) {
			DataRow[] rProgetto = DS.ren_progetto.Select("progetto='"+progetto+"'");
			if (rProgetto.Length==0) {
				MessageBox.Show("Non ho trovato una cartella per il progetto:"+progetto);
				string S="nino";
				return S;
			}
			else {
				return rProgetto[0]["nuovadirectory"].ToString();
			}
		}

		/// <summary>
		/// Restituisce il nuovo nome che deve assumere un progetto andandolo a leggere dalla tabella ren_progetto
		/// </summary>
		/// <param name="progetto">vecchio nome del progetto</param>
		/// <returns>nuovo nome del progetto</returns>
		private string getNuovoRiferimento(string progetto, string idProgetto) 
		{
			DataRow[] rProgetto = DS.ren_progetto.Select("idprogetto='"+idProgetto+"'");
			if (rProgetto.Length==0) {
				MessageBox.Show("Non ho trovato un riferimento per il progetto:"+progetto);
				string S="nino";
				return S;
			} 
			else {
				return rProgetto[0]["nuovonome"].ToString();
			}
		}

		private void copiaRiferimento(XmlElement riferimento, FileInfo oldSln, Progetto progetto, DirectoryInfo dir, DirectoryInfo uniData) 
		{
			string name = riferimento.GetAttribute("Name");
			if (name=="metacampuslibrary") {
				riferimento.SetAttribute("Name", "metaeasylibrary");
				riferimento.SetAttribute("AssemblyName", "metaeasylibrary");
				riferimento.SetAttribute("HintPath", @"..\DLL\metaeasylibrary.dll");
				return;
			}
			//			riferimento.SetAttribute("Private", "False");
			XmlNode attributoProgetto = riferimento.GetAttributeNode("Project");
			if (attributoProgetto != null)
			{
				string project = riferimento.GetAttribute("Project");
				riferimento.SetAttribute("Name", getNuovoRiferimento(name, project));
				riferimento.SetAttribute("Private", "True");
			}
			else if (riferimento.GetAttributeNode("HintPath") != null) 
			{
				string rel1 = getPercorsoRelativo(oldSln.Directory, progetto.oldDir, riferimento.GetAttribute("HintPath"));
				/*					if ((privato != "") && !rel1.ToLower().EndsWith("metadatalibrary.dll") && !rel1.ToLower().EndsWith("metacampuslibrary.dll"))
									{
										Console.WriteLine(privato);
									}*/
				if (rel1.ToLower().EndsWith("magiclibrary.dll"))
				{
					/*						if (privato != "False") 
											{
												Console.WriteLine(progetto.progetto+" "+privato);
											}*/
					rel1 = @"dll\MagicLibrary.DLL";
				} 
				string rel2 = getPercorsoRelativo(dir, uniData, rel1);
				riferimento.SetAttribute("HintPath", rel2);
			}
		}

		/// <summary>
		/// A partire da una vecchia solution ne crea una nuova adottando i nuovi nomi dei progetti e dei namespace.
		/// Per ogni progetto della solution vengono rinominati i riferimenti, viene creata una nuova directory
		/// e lì copiati tutti i file inclusi opportunamente modificati (viene cambiato il loro namespace).
		/// </summary>
		/// <param name="oldSln">vecchia solution</param>
		/// <param name="uniData">directory in cui creare la nuova solution</param>
		private void creaNuovaSolution(FileInfo oldSln, FileInfo newSln, int numeroProgetti) 
		{
			DS.ren_cs.CaseSensitive=false;
			DS.ren_form.CaseSensitive=false;
			DS.ren_progetto.CaseSensitive=false;
			DS.ren_riferimento.CaseSensitive=false;
			leggiTabella(mainDA, DS.tablename, null, null, null);
			leggiTabella(mainDA, DS.colname, null, null, null);
			leggiTabella(mainDA, DS.ren_progetto, null, null, null);
			leggiTabella(mainDA, DS.ren_riferimento, null, null, null);
			leggiTabella(mainDA, DS.ren_cs, null, null, null);
			leggiTabella(mainDA, DS.ren_form, null, null, null);
			leggiTabella(mainDA, DS.procedures, null, null, null);
			progressBar1.Maximum = numeroProgetti;

			foreach (Progetto progetto in new Solution(oldSln, newSln)) 
			{
				//				Console.WriteLine("========== "+progetto.progetto+" "+progetto.csProj);
				string nuovoNomeProgetto = getNuovoRiferimento(progetto.progetto, progetto.idProgetto);
				string nuovaCartellaProgetto = Path.Combine(getNuovaCartellaProgetto(progetto.progetto), nuovoNomeProgetto);
				
				bool compile=true;
				if (chkSoloNuovi.Checked && Directory.Exists(
						newSln.Directory.FullName+"\\"+nuovaCartellaProgetto)) compile=false;

				if (chkSoloNuovi.Checked && compile)MessageBox.Show("Compilo "+nuovaCartellaProgetto);
				

				DirectoryInfo dir = newSln.Directory.CreateSubdirectory(nuovaCartellaProgetto);

				DataRow rProgetto = DS.ren_progetto.Select("idprogetto='" + progetto.idProgetto + "'")[0];
				int numeroForm = Convert.ToInt32(rProgetto["numeroform"]);
				string nomeForm = null;
				if (numeroForm == 1) 
				{
					DataRow rFormNelProgetto = DS.ren_cs.Select("idprogetto='" +progetto.idProgetto + "' and subtype='Form'")[0];
					nomeForm = Path.GetFileNameWithoutExtension(rFormNelProgetto["cs"].ToString());
				}
				ArrayList csDatasetDaCancellare = new ArrayList();
				foreach (XmlElement file in progetto.fileInclusi) 
				{
					string sorgente = Path.Combine(progetto.oldDir.FullName, file.GetAttribute("RelPath"));
					string relPath = file.GetAttribute("RelPath");
					if ((numeroForm == 1)&&(Path.GetFileNameWithoutExtension(relPath) == nomeForm)) 
					{
						relPath = "Frm_" + rProgetto["nuovonome"] + Path.GetExtension(relPath);
						file.SetAttribute("RelPath", relPath);
						if (file.GetAttributeNode("DependentUpon") != null) 
						{
							file.SetAttribute("DependentUpon", "Frm_" + rProgetto["nuovonome"] + ".cs");
						}
					}
					string nomeFile = Path.GetFileName(sorgente);
					if ((progetto.progetto.StartsWith("meta_")&&(nomeFile==progetto.progetto.Substring(5)+".cs")))
					{
						relPath = rProgetto["nuovonome"] + ".cs";
						file.SetAttribute("RelPath", relPath);
					}
					if (nomeFile.ToUpper().StartsWith("VISTA"))
					{
						string oldext=nomeFile.Substring(nomeFile.IndexOf("."));
						relPath="vistaForm"+oldext;
						file.SetAttribute("RelPath",relPath);
						if (oldext.ToUpper()==".XSD")
						{
							file.SetAttribute("LastGenOutput","vistaForm.cs");
							file.RemoveAttribute("Generator");
							csDatasetDaCancellare.Add("vistaForm.cs");
						}
						if (oldext.ToUpper()!=".XSD")
						{
							file.SetAttribute("ParentElement","vistaForm.xsd");
						}
						if (file.GetAttributeNode("DependentUpon") != null) 
						{
							file.SetAttribute("DependentUpon", "vistaForm.xsd");
						}
					}
					string destinazione = Path.Combine(dir.FullName, relPath);
					//					Console.WriteLine(sorgente+" -> "+destinazione);

					if (File.Exists(destinazione)) 
					{
						File.SetAttributes(destinazione, FileAttributes.Archive);
					}
					if ((file.GetAttribute("BuildAction")=="Compile")
						&&(nomeFile != "AssemblyInfo.cs")
						//&&(nomeFile != "vistaindtrasfertaitalia.cs")
						//&&(nomeFile != "vistaubicazione.cs")
						)
					{
						modificaUsing_NameSpace_E_GetForm(compile,progetto, sorgente, 
							destinazione, nuovoNomeProgetto, file.GetAttribute("SubType"));
					} 
					else 
					{
						File.Copy(sorgente, destinazione, true);
					}
				}

				foreach (string ds in csDatasetDaCancellare) {
					progetto.rimuoviFileIncluso(ds);
				}

				foreach (XmlElement riferimento in progetto.riferimenti) 
				{
					copiaRiferimento(riferimento, oldSln, progetto, dir, newSln.Directory);
				}

				foreach (XmlElement config in progetto.config) 
				{
					string outputPath = config.GetAttribute("OutputPath");
					if ((outputPath.ToLower()!=@"bin\debug\")&&(outputPath.ToLower()!=@"bin\release\"))
					{
						string rel1 = getPercorsoRelativo(oldSln.Directory, progetto.oldDir, outputPath);
						string rel2 = getPercorsoRelativo(dir, newSln.Directory, rel1);
						/*							if ((rel1.ToLower() != @"mainform\bin\debug") && (rel1.ToLower() != @"mainform\bin\release")) 
														{
															Console.WriteLine(outputPath + " " + rel2);
														}*/
						config.SetAttribute("OutputPath", rel2);
					}
				}

				progetto.salvaConNome(nuovaCartellaProgetto, nuovoNomeProgetto);
				progressBar1.Value ++;
				Application.DoEvents();
			}
			progressBar1.Value = 0;
		}

		/// <summary>
		/// Restituisce il percorso relativo di un file di arrivo rispetto ad una directory di partenza 
		/// </summary>
		/// <param name="partenza">directory da cui parte il percorso</param>
		/// <param name="dirArrivo">directory contenente il file di arrivo</param>
		/// <param name="fileArrivo">file a cui il percorso deve arrivare</param>
		/// <returns></returns>
		private string getPercorsoRelativo(DirectoryInfo partenza, DirectoryInfo dirArrivo, string fileArrivo) 
		{
			DirectoryInfo arrivo = new DirectoryInfo(Path.Combine(dirArrivo.FullName, fileArrivo));
			string[] path1 = partenza.FullName.Split('\\');
			string[] path2 = arrivo.FullName.Split('\\');
			int i;
			for (i=0; i<path1.Length; i++) 
			{
				if (path1[i].ToUpper() != path2[i].ToUpper()) 
				{
					break;
				}
			}
			string result = "";
			for (int j=i; j<path1.Length; j++) 
			{
				result = Path.Combine(result, "..");
			}
			for (int j=i; j<path2.Length; j++) 
			{
				result = Path.Combine(result, path2[j]);
			}
			return result;
		}

		#endregion

		#region modifica namespace
		/*
		/// <summary>
		/// Restituisce il nuovo nome che deve assumere il namespace dato andandolo
		/// a leggere dalla tabella ren_namespace
		/// </summary>
		/// <param name="nameSpace">Nome del namespace da cambiare</param>
		/// <returns>nuovo nome del namespace</returns>
				private string getNuovoNamespace(string nameSpace) 
				{
					DataRow[] rProgetto = DS.ren_progetto.Select("namespace='"+nameSpace+"'");
					return rProgetto[0]["nuovonome"].ToString();
				}*/

		/// <summary>
		/// PREREQUISITO:
		/// Ds.ren_riferimento e DS.ren_progetto devono essere stati già letti.
		/// SCOPO:
		/// Restituisce il nuovo nome da dare ad un riferimento o lasciandolo inalterato se questo
		/// è un riferimento di sistema
		/// </summary>
		/// <param name="riferimento">Riferimento il cui nome è da cambiare</param>
		/// <param name="rifSistema">Varrà true se il riferimento dato è di sistema; 
		/// false se è un riferimento ad un altro progetto della solution</param>
		/// <returns>nuovo nome da dare al riferimento</returns>
		private string getNuovoUsing(string idProgetto, string riferimento, out bool rifSistema) 
		{
			DataRow[] rRifProgetto = DS.ren_riferimento.Select("idprogetto='"+idProgetto+"' and riferimento='"+riferimento+"'");
			rifSistema = rRifProgetto.Length==0;
			if (rifSistema)
			{
				return riferimento +";";
			} 
			else 
			{
				DataRow[] rProgetto = DS.ren_progetto.Select("idprogetto='"+rRifProgetto[0]["idriferimento"]+"'");
				if (rProgetto.Length==0) 
				{
					MessageBox.Show("Non ho trovato il riferimento "+rRifProgetto[0]["idriferimento"].ToString());
					return null;
				}
				return rProgetto[0]["nuovonome"].ToString() +";//"+riferimento;
			}
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
					while ((i<input.Length)&& (Char.IsLetterOrDigit(input[i]) || (input[i]=='_'))) 
					{
						buffer+=input[i];
						i++;
					}
					output+=nuovoNomeColonna(tablename, buffer);
				}
			}
			return output;
		}

		private string cambiaCostruttoreDatasetNelForm(string contenutoCS) {
			int b = contenutoCS.IndexOf(" DS;");
			if (b==-1) return contenutoCS;
			int a = b;
			while (Char.IsLetterOrDigit(contenutoCS[a-1])||(contenutoCS[a-1]=='_')) a--;
			string tipoDataSet = contenutoCS.Substring(a, b-a);
			if (tipoDataSet == "DataSet") return contenutoCS;
			return contenutoCS.Replace(tipoDataSet, "vistaForm");
		}

		private bool trovaParametroStringa(string cs, string nomeMetodo, int aPartireDa, 
			out int inizio, out int fine) {
			int openpar=0;
			inizio=aPartireDa;
			while (true){
				inizio = cs.IndexOf(nomeMetodo, inizio);
				if (inizio==-1) {
					fine = -1;
					return false;
				}
				inizio += nomeMetodo.Length;
				openpar=SkipComments.nextNonComment(cs,inizio);
				if (cs[openpar]!='(') {
					inizio=openpar;
					continue;
				}
				break;
			}
			int stop = SkipComments.closeBlock(cs,openpar+1,'(',')');
			if (stop<0) stop=cs.Length+1;
			inizio=openpar+1;
			while (cs[inizio] != '"') {
				string ms= cs.Substring(aPartireDa, inizio-aPartireDa);
				inizio = SkipComments.nextNonComment(cs, inizio+1);
				if (inizio<0){
					fine=-1;
					return false;
				}
				if (inizio>stop) {
					return trovaParametroStringa(cs,nomeMetodo,stop+1,out inizio, out fine);
				}
			}
			fine = SkipComments.closedString(cs, inizio+1 , '"') - 1;
			return true;
		}

		private string cambiaCostruttoreMetadato(string cs, string nuovaTabella) {
			StringTokenizer st = new StringTokenizer(cs, new string[] {
			  "public", "class", "%1", ":", "Meta_campusdata"});
			if (!st.MoveNext()) return cs;
			string result = st.Current
				+ "public class "
				+ st.parametri["%1"]
				+ " : Meta_easydata"
				+ st.getParteRimanente();
			int inizio, fine;
			trovaParametroStringa(result, "base", 0, out inizio, out fine);
			result = result.Substring(0, inizio+1) + nuovaTabella + result.Substring(fine); 
			return result;
		}

		private string cambiaMetodo(string cs, string oldTable,string MethodName) {
			string result = "";
			int pos = 0;
			int inizio, fine;
			while (trovaParametroStringa(cs, MethodName, pos, out inizio, out fine)) {
				string oldCol = cs.Substring(inizio+1, fine-inizio-1);
				string colName = nuovoNomeColonna(oldTable, oldCol);
				string s = (colName == null) 
					? cs.Substring(pos, fine-pos)
					: cs.Substring(pos, inizio-pos+1) + colName;
				result += s;
				pos = fine;
			}
			result += cs.Substring(pos);
			return result;
		}

		string TraduciNomeRelazione(string relname,string maintable){
			if (relname.StartsWith(maintable)){
				string tablechild= relname.Substring(maintable.Length);
				if (DS.tablename.Select("oldtable='"+tablechild+"'").Length>0){
					return nuovoNomeTabella(maintable)+nuovoNomeTabella(tablechild);
				}
			}
			if (relname.EndsWith(maintable)){
				string tableparent= relname.Substring(0,relname.Length- maintable.Length);
				if (DS.tablename.Select("oldtable='"+tableparent+"'").Length>0){
					return nuovoNomeTabella(tableparent)+nuovoNomeTabella(maintable);
				}
			}
			//MessageBox.Show("Not found relation:"+relname+ "( main table was "+maintable+")");
			return relname;
		}
		
		private string cambiaGetParentRow(string cs, string mainTable) {
			StringTokenizer st=new StringTokenizer(cs,
				new string[] {"GetParentRow(","%1",")"});					
			StringBuilder SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);
				if (st.parametri["%1"].ToString().StartsWith("\"")){
					string rel = togliLeVirgolette(st.parametri["%1"].ToString());
					string relName = TraduciNomeRelazione(rel,mainTable);
					SB.Append("GetParentRow(\""+relName+"\")");
				}
				else {
					SB.Append("GetParentRow("+st.parametri["%1"].ToString()+")");
				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			st=new StringTokenizer(cs,
				new string[] {"GetChildRow(","%1",")"});					
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);
				if (st.parametri["%1"].ToString().StartsWith("\"")){
					string relName = TraduciNomeRelazione(st.parametri["%1"].ToString(),mainTable);
					SB.Append("GetChildRow("+relName+")");
				}
				else {
					SB.Append("GetChildRow("+st.parametri["%1"].ToString()+")");
				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			return cs;
		}

			
		private string cambiaMetodoTabella(string cs, string MethodName) {
			string result = "";
			int pos = 0;
			int inizio, fine;
			while (trovaParametroStringa(cs, MethodName, pos, out inizio, out fine)) {
				string oldTab = cs.Substring(inizio+1, fine-inizio-1);
				string tabName = nuovoNomeTabella(oldTab);
				string s = (tabName == null) 
					? cs.Substring(pos, fine-pos)
					: cs.Substring(pos, inizio-pos+1) + tabName;
				result += s;
				pos = fine;
			}
			result += cs.Substring(pos);
			return result;
		}

		string ChangeInsideSelectOne(string S){
			int next=0;
			//Salta la prima virgola
			while ((next>=0)&&(S[next]!=',')) next = SkipComments.nextNonComment(S,next+1);
			if (next>=0) next++;
			//Salta la seconda virgola
			while ((next>=0)&&(S[next]!=',')) next = SkipComments.nextNonComment(S,next+1);
				
			if (next>=0){
				next = SkipComments.nextNonComment(S, next+1);
				if (S[next]=='"'){
					int nextquote= SkipComments.closedString(S,next+1,'"');
					string oldtable=S.Substring(next+1,nextquote-next-2);
					string newtable = "\""+nuovoNomeTabella(oldtable)+"\"";
					return S.Substring(0,next)+newtable+S.Substring(nextquote);
				}				
			}
			return S;
		}
	
		private string cambiaIsValid(string S, string oldTable) {
			string prima, dopo;
			string cs = SkipComments.getFunctionCode("IsValid", S, out prima, out dopo,2);
			foreach (DataRow r in DS.colname.Select("oldtable='"+oldTable+"'")) {
				string s = "R[\"" + r["oldcol"] + "\"]";
				string t = "R[\"" + r["newcol"] + "\"]";
				cs = cs.Replace(s, t);

				s = "errfield=\"" + r["oldcol"] + "\"";
				t = "errfield=\"" + r["newcol"] + "\"";
				cs = cs.Replace(s, t);

				s = "errfield= \"" + r["oldcol"] + "\"";
				t = "errfield= \"" + r["newcol"] + "\"";
				cs = cs.Replace(s, t);

				s = "errfield =\"" + r["oldcol"] + "\"";
				t = "errfield =\"" + r["newcol"] + "\"";
				cs = cs.Replace(s, t);

				s = "errfield = \"" + r["oldcol"] + "\"";
				t = "errfield = \"" + r["newcol"] + "\"";
				cs = cs.Replace(s, t);


				s= "R.Table.Columns[\""+r["oldcol"]+"\"]";
				t= "R.Table.Columns[\""+r["newcol"]+"\"]";
				cs = cs.Replace(s, t);

			}
			return prima + cs + dopo;
		}

		private string cambiaGetNewRow(string S, string oldTable) {
			string prima, dopo;
			string cs = SkipComments.getFunctionCode("Get_New_Row", S, out prima, out dopo,2);
			foreach (DataRow r in DS.colname.Select("oldtable='"+oldTable+"'")) {
				string s = "RowChange.SetSelector(T,\""+r["oldcol"]+"\"";
				string t = "RowChange.SetSelector(T,\""+r["newcol"]+"\"";
				cs = cs.Replace(s, t);

				s= "T.Columns[\""+r["oldcol"]+"\"]";
				t= "T.Columns[\""+r["newcol"]+"\"]";
				cs = cs.Replace(s, t);

			}
			return prima + cs + dopo;
		}

		string cambiaSelectOne(string S){
			string Before;
			string After;
			string Codice= SkipComments.getFunctionCode("SelectOne",S,out Before, out After,2);
			if (Codice==null) return S;
			int start=0;
			int next = Codice.IndexOf("base.SelectOne(",start);
			while ((next>=0)&&SkipComments.IsInsideComment(Codice,0,next)){
				next = Codice.IndexOf("base.SelectOne(",next+1);
			}
			while (next>0){
				int endelencopar=SkipComments.closeBlock(Codice,next+15,'(',')');
				string skipped=Codice.Substring(start,next-start+15);
				Before += skipped;								
				Before+= ChangeInsideSelectOne(Codice.Substring(next+15,endelencopar-next-15));
				start=endelencopar;
				next =  Codice.IndexOf("base.SelectOne(",start);
				while ((next>=0)&&SkipComments.IsInsideComment(Codice,0,next)){
					next = Codice.IndexOf("base.SelectOne(",next+1);
				}
			}
			Before+= Codice.Substring(start);
			return Before+After;
		}


		string CambiaRiferimentiATabelle(string cs) 
		{
			StringTokenizer st=new StringTokenizer(cs,
				new string[] {"DS.Tables[","%1","]",".","Columns","[","%2","]"});
					
			StringBuilder SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= togliLeVirgolette(st.parametri["%1"].ToString());
				if (oldtable!=null){
					string newtable= nuovoNomeTabella(oldtable);

					string oldcol = togliLeVirgolette(st.parametri["%2"].ToString());
					if (oldcol!=null){
						string newcol = nuovoNomeColonna(oldtable,oldcol);
						SB.Append("DS.Tables[\""+newtable+"\"].Columns[\""+newcol+"\"]");				
					}
					else {
						SB.Append("DS.Tables[\""+newtable+"\"].Columns["+st.parametri["%2"]+"]");				
					}
				}
				else {
					SB.Append("DS.Tables["+st.parametri["%1"]+"].Columns["+st.parametri["%2"]+"]");				
				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st=new StringTokenizer(cs,
				new string[]{"DS.Tables[", "%1", "]", ".", "Rows", "[", "%0", "]", ".", "Columns", "[", "%2", "]"});
					
			SB= new StringBuilder();
			foreach (string precedente in st)
			{
				SB.Append(precedente);

				string oldtable= togliLeVirgolette(st.parametri["%1"].ToString());
				if (oldtable!=null)
				{
					string newtable= nuovoNomeTabella(oldtable);

					string oldcol = togliLeVirgolette(st.parametri["%2"].ToString());
					if (oldcol!=null)
					{
						string newcol = nuovoNomeColonna(oldtable,oldcol);
						if (newcol==null) 
						{
							newcol = oldcol;
						}
						SB.Append("DS.Tables[\""+newtable+"\"].Rows["+st.parametri["%0"]+"].Columns[\""+newcol+"\"]");				
					}
					else 
					{
						SB.Append("DS.Tables[\""+newtable+"\"].Rows["+st.parametri["%0"]+"].Columns["+st.parametri["%2"]+"]");				
					}
				}
				else 
				{
					SB.Append("DS.Tables["+st.parametri["%1"]+"].Rows["+st.parametri["%0"]+"].Columns["+st.parametri["%2"]+"]");				
				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			st=new StringTokenizer(cs,
				new string[]{"DS.", "%1", ".", "Rows", "[", "%0", "]", ".", "Columns", "[", "%2", "]"});
					
			SB= new StringBuilder();
			foreach (string precedente in st) {
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				if (oldtable!=null) {
					string newtable= nuovoNomeTabella(oldtable);

					string oldcol = togliLeVirgolette(st.parametri["%2"].ToString());
					if (oldcol!=null) {
						string newcol = nuovoNomeColonna(oldtable,oldcol);
						if (newcol==null) {
							newcol = oldcol;
						}
						SB.Append("DS."+newtable+".Rows["+st.parametri["%0"]+"].Columns[\""+newcol+"\"]");				
					}
					else {
						SB.Append("DS."+newtable+".Rows["+st.parametri["%0"]+"].Columns["+st.parametri["%2"]+"]");				
					}
				}
				else {
					SB.Append("DS."+st.parametri["%1"]+".Rows["+st.parametri["%0"]+"].Columns["+st.parametri["%2"]+"]");				
				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st=new StringTokenizer(cs,
				new string[]{"DS.", "%1", ".", "Rows", "[", "%0", "]", "[", "%2", "]"});
					
			SB= new StringBuilder();
			foreach (string precedente in st) {
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				if (oldtable!=null) {
					string newtable= nuovoNomeTabella(oldtable);

					string oldcol = togliLeVirgolette(st.parametri["%2"].ToString());
					if (oldcol!=null) {
						string newcol = nuovoNomeColonna(oldtable,oldcol);
						if (newcol==null) {
							newcol = oldcol;
						}
						SB.Append("DS."+newtable+".Rows["+st.parametri["%0"]+"][\""+newcol+"\"]");				
					}
					else {
						SB.Append("DS."+newtable+".Rows["+st.parametri["%0"]+"].["+st.parametri["%2"]+"]");				
					}
				}
				else {
					SB.Append("DS."+st.parametri["%1"]+".Rows["+st.parametri["%0"]+"]["+st.parametri["%2"]+"]");				
				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st=new StringTokenizer(cs,
				new string[]{"Tables","[","%1","]"});
			
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= togliLeVirgolette(st.parametri["%1"].ToString());		
				if (oldtable!=null){
					string newtable= nuovoNomeTabella(oldtable);
					SB.Append("Tables[\""+newtable+"\"]");				
				}
				else {
					SB.Append("Tables["+st.parametri["%1"]+"]");				

				}
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st=new StringTokenizer(cs,
				new string[]{"DS.","%1",".","Columns","[","%2","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				if (oldtable!=null){
					string newtable= nuovoNomeTabella(oldtable);

					string oldcol = togliLeVirgolette(st.parametri["%2"].ToString());			
					if (oldcol!=null){
						string newcol = nuovoNomeColonna(oldtable,oldcol);
						SB.Append("DS."+newtable+".Columns[\""+newcol+"\"]");				
					}
					else {
						SB.Append("DS."+newtable+".Columns["+st.parametri["%2"]+"]");				
					}
				}
				else {
					SB.Append("DS."+st.parametri["%1"]+".Columns["+st.parametri["%2"]+"]");				
				}

			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st=new StringTokenizer(cs,
				new string[]{"DS.","%1",".","%2"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				string tempoldcol = st.parametri["%2"].ToString();
				
				int idx = tempoldcol.IndexOf("column");
				if (idx<0){
					SB.Append("DS."+oldtable+"."+tempoldcol);				
					continue;
				}

				string oldcol= tempoldcol.Substring(0,idx);
				
				
				string newtable= nuovoNomeTabella(oldtable);				
				string newcol = nuovoNomeColonna(oldtable,oldcol)+"column";
				SB.Append("DS."+newtable+"."+newcol);				
				SB.Append(tempoldcol.Substring(idx));
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			st= new StringTokenizer(cs,
				new string[]{"TableName","=","=","%1"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				string newtable= nuovoNomeTabellaConVirgolette(oldtable);
				SB.Append("TableName == "+newtable);				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st= new StringTokenizer(cs,
				new string[]{"ColumnName","=","=","%1"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				string newtable= nuovoNomeColonnaUnicoConVirgolette(oldtable);
				SB.Append("ColumnName == "+newtable);				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			
			st= new StringTokenizer(cs,
				new string[]{"TableName","!","=","%1"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				string newtable= nuovoNomeTabellaConVirgolette(oldtable);
				SB.Append("TableName != "+newtable);				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st= new StringTokenizer(cs,
				new string[]{"Columns","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("Columns["+newcol+"]");				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			st= new StringTokenizer(cs,
				new string[]{"R","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("R["+newcol+"]");				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			st= new StringTokenizer(cs,
				new string[]{"Curr","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("Curr["+newcol+"]");				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			st= new StringTokenizer(cs,
				new string[]{"DR","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("DR["+newcol+"]");				
			}

			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st= new StringTokenizer(cs,
				new string[]{"NewRow","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("NewRow["+newcol+"]");				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st= new StringTokenizer(cs,
				new string[]{"ParentRow","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("ParentRow["+newcol+"]");				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			
			st= new StringTokenizer(cs,
				new string[]{"r","[","%1","]"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldcol= st.parametri["%1"].ToString();
				string newcol= nuovoNomeColonnaUnicoConVirgolette(oldcol);
				SB.Append("r["+newcol+"]");				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();



			st=new StringTokenizer(cs,
				new string[]{"DS.","%1"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);

				string oldtable= st.parametri["%1"].ToString();
				string newtable= nuovoNomeTabella(oldtable);
				SB.Append("DS."+newtable);				
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();


			st=new StringTokenizer(cs,
				new string[]{"Conn.RUN_SELECT(","%1",",","%2",",","%3",",","%4"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);
				string oldtable= st.parametri["%1"].ToString();
				if (!oldtable.StartsWith("\"")){
					SB.Append("Conn.RUN_SELECT("+st.parametri["%1"].ToString()+
										","+st.parametri["%2"].ToString()+
										","+st.parametri["%3"].ToString()+
										","+st.parametri["%4"].ToString());
					continue;
				}
				string newtable= nuovoNomeTabella(togliLeVirgolette(oldtable));
				string collist= ReplaceTableColumns(st.parametri["%2"].ToString(),togliLeVirgolette(oldtable));
				string orderby = ReplaceTableColumns(st.parametri["%3"].ToString(),togliLeVirgolette(oldtable));
				string filter = ReplaceTableColumns(st.parametri["%4"].ToString(),togliLeVirgolette(oldtable));

				SB.Append("Conn.RUN_SELECT(\""+newtable+"\""+
					","+collist+
					","+orderby+
					","+filter);
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

								 
			st=new StringTokenizer(cs,
				new string[]{"Conn.RUN_SELECT_COUNT(","%1",",","%2"});
			SB= new StringBuilder();
			foreach (string precedente in st){
				SB.Append(precedente);
				string oldtable= st.parametri["%1"].ToString();
				if (!oldtable.StartsWith("\"")){
					SB.Append("Conn.RUN_SELECT_COUNT("+st.parametri["%1"].ToString()+
						","+st.parametri["%2"].ToString());
					continue;
				}
				string newtable= nuovoNomeTabella(togliLeVirgolette(oldtable));
				string filter= ReplaceTableColumns(st.parametri["%2"].ToString(),togliLeVirgolette(oldtable));

				SB.Append("Conn.RUN_SELECT_COUNT(\""+newtable+"\""+
					","+filter);
			}
			SB.Append(st.getParteRimanente());
			cs =SB.ToString();

			
			
			//RUN_SELECT_COUNT("missionemovspesa",filter
			return cs;

		}
		/// <summary>
		/// Copia un file C# cambiando il namespace e tutti i nomi dei progetti delle clausole using 
		/// Inoltre, se tale file è un metadata, allora chiama la funzione correggiMetadata;
		/// </summary>
		/// <param name="sr">file C# originale</param>
		/// <param name="sw">file C# modificato</param>
		private void modificaUsing_NameSpace_E_GetForm(bool compile, Progetto progetto, string sorgente, string destinazione, string nuovoNamespace, string SubType) {
			ArrayList usingDaEliminare = new ArrayList();
			StreamReader sr1 = new StreamReader(sorgente, Encoding.Default);
			//mdc contiene tutto il file
			string mdc = sr1.ReadToEnd();
			string maintable="**";
			if (DS.ren_progetto.Select("idprogetto='"+progetto.idProgetto+"'").Length==1)
				maintable=DS.ren_progetto.Select("idprogetto='"+progetto.idProgetto+"'")[0]["tabella"].ToString();
			else 
				maintable="**";

			//Parte che riguarda solo i metadati
			if (progetto.progetto.StartsWith("meta_")) {
				ArrayList riferimentiDaEliminare = new ArrayList();
				mdc = correggiMetadata(progetto, mdc, riferimentiDaEliminare);
				foreach (string idRiferimento in riferimentiDaEliminare) {
					progetto.rimuoviRiferimento(idRiferimento);
					string nameSpaceDaEliminare = DS.ren_progetto.Select("idprogetto='" + idRiferimento + "'")[0]["namespace"].ToString();
					usingDaEliminare.Add(nameSpaceDaEliminare);
				}
			}
			if (!compile) 
			{
				return;
			}

			ArrayList alMetadatiUsati = new ArrayList();
			StringReader sr = new StringReader(mdc);
			StringWriter sgw = new StringWriter();//destinazione,false,Encoding.Default);
				//new StreamWriter(destinazione, false, Encoding.Default);

			//Cambia gli using in testa al codice, fermandosi alla riga del namespace
			string linea = sr.ReadLine();
			try {
				while (!linea.StartsWith("namespace")) {

					if (linea.StartsWith("using")) {
						int posPV = linea.IndexOf(';');
						string riferimento = linea.Substring(6, posPV - 6);
						if (riferimento.StartsWith("meta_")) {
							alMetadatiUsati.Add(riferimento);
						}
						if (usingDaEliminare.IndexOf(riferimento) == -1) {
							if (riferimento=="metacampuslibrary") {
								linea = "using metaeasylibrary;";
							} else {
								bool rifSistema;
								string nuovo=getNuovoUsing(progetto.idProgetto, riferimento, out rifSistema);
								if (nuovo!=null)
									linea = "using " + nuovo;
								else
								{
									MessageBox.Show("using not found:"+linea);
									linea = linea+" //non ho trovato l'using";
								}
							}
						} 
						else {
							linea = "//Pino: "+linea+" diventato inutile";
						}
					}
					sgw.WriteLine(linea);
					linea = sr.ReadLine();
				}
			}
			catch (Exception e) {
				MessageBox.Show(e+"\n"+sorgente);
			}


			//cambia il namespace del file
			string nameSpace = linea.Substring(10); 
			bool pg = nameSpace.EndsWith("{");
			string spg = pg ? "{" : "";
			if (pg) nameSpace = nameSpace.Remove(nameSpace.Length-1, 1);
			nameSpace = nameSpace.TrimEnd();
			sgw.WriteLine("namespace " + nuovoNamespace + spg + "//" + nameSpace + "//");


			//Legge in cs tutto il resto
			string cs = sgw + sr.ReadToEnd();
			StreamWriter sw =null;
			try {
				 sw = new StreamWriter(destinazione, false, Encoding.Default);
			}
			catch (Exception E) {
				QueryCreator.ShowException("Non sono riuscito a creare il file"+destinazione,E);
				
			}

			//elimina i riferimenti al namespace corrente
			cs = cs.Replace(" " + nameSpace + ".", " /*Rana:" + nameSpace + ".*/");

			//solita cosa ostrogota
			foreach (string metadato in alMetadatiUsati) {
				DataRow[] rProgetto = DS.ren_progetto.Select("progetto='"+metadato+"'");
				string nuovoNomeProgetto = rProgetto[0]["nuovonome"].ToString();
				nuovoNomeProgetto = nuovoNomeProgetto.Substring(0,1).ToUpper() + nuovoNomeProgetto.Substring(1);
				string meta = metadato.Substring(0,1).ToUpper() + metadato.Substring(1);
				cs = cs.Replace(meta, nuovoNomeProgetto);
			}

			//Altra parte che riguarda solo i metadati
			if (progetto.progetto.StartsWith("meta_")) {
				string vecchiaTabella = progetto.progetto.Substring(5);
				string nuovaTabella = nuovoNamespace.Substring(5);
				string nomeClasse =  "Meta_" + vecchiaTabella;

				StringTokenizer st = new StringTokenizer(cs, new string[] {"public", "class", nomeClasse});
				bool trovato = st.MoveNext();
				cs = st.Current + "public class Meta_" + nuovaTabella;

				st.setPattern(new string[] {"public", nomeClasse});
				trovato = st.MoveNext();
				cs += st.Current + "public Meta_" + nuovaTabella;
				cs += st.getParteRimanente();

				cs = cambiaCostruttoreMetadato(cs,nuovaTabella);
				cs = cambiaMetodo(cs,vecchiaTabella,"DescribeAColumn");
				cs = cambiaMetodo(cs,vecchiaTabella,"SetDefault");
				cs = cambiaMetodo(cs,vecchiaTabella,"SetSelector");				
				cs = cambiaGetNewRow(cs,vecchiaTabella);
				cs = cambiaIsValid(cs,vecchiaTabella);
				cs = cambiaSelectOne(cs);
				cs= cambiaGetParentRow(cs,vecchiaTabella);
				cs = CambiaRiferimentiATabelle(cs);
				cs = cambiaSelect(cs);
				//cs = cambiaDoReadValue(cs);
				cs = cambiaCallSP(cs);

			}
			else {
				if (SubType=="Form") 
				{
					cs = cambiaCostruttoreForm(cs, nuovoNamespace);
					cs = cambiaTagNelForm(cs);
					cs = cambiaCostruttoreDatasetNelForm(cs);
					cs = cambiaMetodoTabella(cs,"GetMetaData");
					//cs = cambiaDoReadValue(cs);
					cs = cambiaSelect(cs);
					cs = CambiaRiferimentiATabelle(cs);
					cs= cambiaGetParentRow(cs,maintable);
					cs = cambiaCallSP(cs);
				}
			}
			sw.Write(cs);
			sw.Close();
		}


		private string compilaCondizioneConVirgolette(string vecchiaTabella, string condizione) {
			string oldTable = togliLeVirgolette(vecchiaTabella);
			if (oldTable == null) return condizione;

			int i=-1;
			do {
				i = SkipComments.nextNonComment(condizione, i+1);
			} while ((i!=-1)&&(condizione[i]!='"'));

			if (i==-1) return condizione;

			int f = SkipComments.closedString(condizione, i+1, '"');
			string espressione = condizione.Substring(i, f-i);
			string result = condizione.Substring(0, i);
			result += ReplaceTableColumns(espressione, oldTable);
			result += condizione.Substring(f);
			return result;
		}

		private string compilaEspressioneConVirgolette(string vecchiaTabella, string espressione) {
			string oldTable = togliLeVirgolette(vecchiaTabella);
			if (oldTable == null) return espressione;

			string oldcol = togliLeVirgolette(espressione);
			if (oldcol==null) return espressione;

			return ReplaceTableColumns(espressione, vecchiaTabella);
		}


		private string cambiaSelect(string cs) {
			StringTokenizer st = new StringTokenizer(cs, new string[] {"DS", ".", "%1", ".", "Select", "(", "%2"});
			StringBuilder SB= new StringBuilder();
			foreach (string precedente in st) {
				string nuovoFiltro = ReplaceTableColumns(st.parametri["%2"].ToString(), st.parametri["%1"].ToString());
				SB.Append( precedente
					+ "DS."+st.parametri["%1"]+".Select("
					+ nuovoFiltro);
			}
			SB.Append( st.getParteRimanente());
			cs = SB.ToString();

			st = new StringTokenizer(cs, new string[] {"DS", ".", "Tables", "[","%1", "]",".", "Select", "(", "%2"});
			SB= new StringBuilder();
			foreach (string precedente in st) {
				if (st.parametri["%1"].ToString().StartsWith("\"")){
					string nuovoFiltro = ReplaceTableColumns(st.parametri["%2"].ToString(), 
								togliLeVirgolette(st.parametri["%1"].ToString()));
					SB.Append( precedente
						+ "DS.Tables["+st.parametri["%1"]+"].Select("
						+ nuovoFiltro);
				}
				else {
					SB.Append( precedente
						+ "DS.Tables["+st.parametri["%1"]+"].Select("+st.parametri["%2"]);
				}
			}
			SB.Append( st.getParteRimanente());
			cs = SB.ToString();
			return cs;
		}


		private string cambiaCallSP(string cs) {
			StringTokenizer st = new StringTokenizer(cs, new string[] {"CallSP", "(", "%1"});
			StringBuilder SB= new StringBuilder();
			foreach (string precedente in st) {
				if (st.parametri["%1"].ToString().StartsWith("\"")){
					string nomesp= togliLeVirgolette(st.parametri["%1"].ToString());
					if (DS.procedures.Select("oldname='"+nomesp+"'").Length==0){
						SB.Append( precedente
							+ "CallSP("+st.parametri["%1"]);
					}
					else {
						string newsp=DS.procedures.Select("oldname='"+nomesp+"'")[0]["newname"].ToString();
						SB.Append( precedente
							+ "CallSP(\""+newsp+"\"");
					}

				}
				else {
					SB.Append( precedente
						+ "CallSP("+st.parametri["%1"]);
				}
			}
			SB.Append( st.getParteRimanente());
			cs = SB.ToString();


			st = new StringTokenizer(cs, new string[] {"CallSPParameter", "(", "%1"});
			SB= new StringBuilder();
			foreach (string precedente in st) {
				if (st.parametri["%1"].ToString().StartsWith("\"")){
					string nomesp= togliLeVirgolette(st.parametri["%1"].ToString());
					if (DS.procedures.Select("oldname='"+nomesp+"'").Length==0){
						SB.Append( precedente
							+ "CallSPParameter("+st.parametri["%1"]);
					}
					else {
						string newsp=DS.procedures.Select("oldname='"+nomesp+"'")[0]["newname"].ToString();
						SB.Append( precedente
							+ "CallSPParameter(\""+newsp+"\"");
					}

				}
				else {
					SB.Append( precedente
						+ "CallSPParameter("+st.parametri["%1"]);
				}
			}
			SB.Append( st.getParteRimanente());
			cs = SB.ToString();


			st = new StringTokenizer(cs, new string[] {"CallSPParameterDataSet", "(", "%1"});
			SB= new StringBuilder();
			foreach (string precedente in st) {
				if (st.parametri["%1"].ToString().StartsWith("\"")){
					string nomesp= togliLeVirgolette(st.parametri["%1"].ToString());
					if (DS.procedures.Select("oldname='"+nomesp+"'").Length==0){
						SB.Append( precedente
							+ "CallSPParameterDataSet("+st.parametri["%1"]);
					}
					else {
						string newsp=DS.procedures.Select("oldname='"+nomesp+"'")[0]["newname"].ToString();
						SB.Append( precedente
							+ "CallSPParameterDataSet(\""+newsp+"\"");
					}

				}
				else {
					SB.Append( precedente
						+ "CallSPParameterDataSet("+st.parametri["%1"]);
				}
			}
			SB.Append( st.getParteRimanente());
			cs = SB.ToString();

			return cs;
		}




		

		private string nuovoNomeColonnaUnicoConVirgolette(string vecchiaColonna) {
			string oldcol = togliLeVirgolette(vecchiaColonna);
			if (oldcol==null) return vecchiaColonna;
			DataRow[] rCol = DS.colname.Select("oldcol='"+oldcol+"' and newcol not like 'DELETE_%'");
			if (rCol.Length==0) return vecchiaColonna;
			string found=rCol[0]["newcol"].ToString();
			if (rCol.Length==1) return "\""+found+"\"";

			for (int i = 1; i< rCol.Length;i++){
				if (rCol[i]["newcol"].ToString()!=found) return vecchiaColonna;

			}
			return "\""+found+"\"";
		}


		private string nuovoNomeTabellaConVirgolette(string vecchiaTabella) {
			string oldTable = togliLeVirgolette(vecchiaTabella);
			if (oldTable == null) return vecchiaTabella;
			DataRow[] rTableName = DS.tablename.Select("oldtable='"+oldTable+"'");
			if (rTableName.Length == 0) return vecchiaTabella;
			return "\"" + rTableName[0]["newtable"] + "\"";
		}

		private int getProssimaOccorrenza(string S, int start, char c){
			int index=start;
			while ((index>=0)&&(index<S.Length)){
				index = SkipComments.nextNonComment(S,index);
				if (index<0) return -1;
				char C=S[index];
				if (C=='"'){
					index = SkipComments.closedString(S,index+1,'"');
					continue;
				}
				if (C=='\''){
					index = SkipComments.closedString(S,index+1,'\'');
					continue;
				}
				if (C==c){
					return index;
				}
				index++;
			}
			return -1;
		}


		private int vaiAFineParametro(string cs, int posInizioParametro, char separatore) {
			int v, pa;
			int pc = posInizioParametro;
			do {
				v = getProssimaOccorrenza(cs, pc, separatore);
				pa = getProssimaOccorrenza(cs, pc, '(');
				if (pa==-1) {
					return v;
				} else {
					pc = SkipComments.closeBlock(cs, pa+1, '(', ')');
				}
			} while ((pc != -1) && (v > pa));
			return v;
		}

		


		private string cambiaCostruttoreForm(string cs, string nameSpace) 
		{
			StringTokenizer st = new StringTokenizer(cs, new string[]
				{"class","%1",":","System",".","Windows",".","Forms",".","Form"});
			if (!st.MoveNext()) return cs;
			string nomeForm = st.parametri["%1"].ToString();
			string result = st.Current
				+ "class Frm_"
				+ nameSpace
				+ " : System.Windows.Forms.Form";
			st.setPattern(new string[] {"public",nomeForm,"(",")"});
			if (!st.MoveNext()) return cs;
			result += st.Current
				+ "public Frm_"
				+ nameSpace
				+ "()"
				+ st.getParteRimanente();
			return result;
		}

		private string sostituisciNomeColonnaNelTag(string oldTable, string oldcol) 
		{
			int dp = oldcol.IndexOf(":");
			if (dp==-1) 
			{
				dp = oldcol.Length;
			} 
			string vecchiaColonna = oldcol.Substring(0, dp);
			string resto = oldcol.Substring(dp);
			DataRow[] rColName = DS.colname.Select("oldtable='"+oldTable+"' and oldcol='"+vecchiaColonna+"'");
			if (rColName.Length==0) return oldcol;
			return rColName[0]["newcol"] + resto;
		}

		private string compilaTag(string tag) 
		{
			string campo0 = HelpForm.GetField(tag, 0);
			string campo1 = HelpForm.GetField(tag, 1);
			string campo2 = HelpForm.GetField(tag, 2);
			switch (campo0) 
			{
				case "manage":
				case "choose":
				case "comboedit":
					string filtro = HelpForm.GetField(tag, 3);
					string r1 = campo0 + "."
						+ nuovoNomeTabella(campo1) + "."
						+ campo2;
					if (filtro != null) 
					{
						r1 += "." + ReplaceTableColumns(filtro, campo1);
					}
					return r1;
			}
			if (campo1==null) return nuovoNomeTabella(campo0);
			int pos = tag.IndexOf(campo1) + campo1.Length;
			string resto = tag.Substring(pos);
			string r3 = nuovoNomeTabella(campo0) + "."
				+ sostituisciNomeColonnaNelTag(campo0, campo1)
				+ resto;
			return r3;
		}

		private string cambiaTagNelForm(string cs) 
		{
			int inizioRegione = cs.IndexOf("#region Windows Form Designer generated code");
			if (inizioRegione==-1) return cs;
			int fineRegione = cs.IndexOf("#endregion", inizioRegione);

			StringBuilder sb = new StringBuilder();
			string s = cs.Substring(inizioRegione, fineRegione-inizioRegione);
			int chiusura = 1;
			int posTag = s.IndexOf(".Tag = \"");
			while (posTag != -1) 
			{
				string before = s.Substring(chiusura-1, posTag+9-chiusura);
				sb.Append(before);
				chiusura = SkipComments.closedString(s, posTag+8, '"');
				string tag = s.Substring(posTag+8, chiusura-posTag-9);
				if (tag!="") 
				{
					string standardTag = HelpForm.GetStandardTag(tag);
					string searchTag = HelpForm.GetSearchTag(tag);
					if (standardTag == searchTag) 
					{
						string newTag = compilaTag(standardTag);
						sb.Append(newTag);
					} 
					else 
					{
						string newTag = compilaTag(standardTag) + "?" + compilaTag(searchTag);
						sb.Append(newTag);
					}
				}
				posTag = s.IndexOf(".Tag = \"", chiusura);
			}
			string result = cs.Substring(0, inizioRegione)
				+ sb
				+ s.Substring(chiusura-1)
				+ cs.Substring(fineRegione);
			return result;
		}



		private string togliLeVirgolette(string s) {
			int i = -1;
			do {
				i = SkipComments.nextNonComment(s, i+1);
				if (i==-1) return null;
			} while (s[i] != '"');
			int f = SkipComments.closedString(s, i+1, '"');
			return s.Substring(i+1, f-i-2);
		}

		#endregion

		#region rinomina Form

		/*		private string[] splitString(string stringa, string separatrice) 
				{
					ArrayList al = new ArrayList();
					int inizio = 0;
					int fine = stringa.IndexOf(separatrice);
					while (fine != -1) 
					{
						al.Add(stringa.Substring(inizio, fine-inizio));
						inizio = fine + separatrice.Length;
						fine = stringa.IndexOf(separatrice, inizio);
					}
					al.Add(stringa.Substring(inizio));
					return (string[]) al.ToArray("".GetType());
				}*/

		#endregion


		private string sostituisciPattern(string cs, string[] pattern, string stringaSostitutiva)
		{
			StringTokenizer st = new StringTokenizer(cs, pattern);
			string s = "";
			foreach (string split in st)
			{
				s += split + stringaSostitutiva;
			}
			return s + st.getParteRimanente();
		}

		private string sostituisciGetformbydllname(string cs)
		{
			try {
				string[] pattern = new string[] {"GetFormByDllName", "(", "%1", ")"};
				StringTokenizer st = new StringTokenizer(cs, pattern);
				string s = "";
				foreach (string split in st) {
					string vecchioNome = st.parametri["%1"].ToString();
					vecchioNome = vecchioNome.Substring(1, vecchioNome.Length - 2);
					object NuovoNome;
					if ( DS.ren_progetto.Select("AssemblyName='" + vecchioNome +"'").Length==0){
						NuovoNome=vecchioNome;
						MessageBox.Show("In ren_progetto non trovo l'assemblyname "+vecchioNome);
					}
					else {
						NuovoNome = DS.ren_progetto.Select("AssemblyName='" + vecchioNome +"'")[0]["nuovonome"];
					}
					s += split + "GetFormByDllName(\"" + NuovoNome + "\")";
				}
				return s + st.getParteRimanente();
			}
			catch (Exception E){
				QueryCreator.ShowException(cs,E);
				return cs;
			}
		}

		private string correggiMetadata(Progetto progetto, string cs, ArrayList riferimentiDaEliminare) 
		{
			string metadata = progetto.progetto.Substring(5);
			cs = sostituisciGetformbydllname(cs);

			DataRow[] righeForm = DS.ren_form.Select("metadata='" + metadata + "'");

			foreach (DataRow rForm in righeForm) 
			{
				DataRow rCs = rForm.GetParentRow("ren_csren_form");
				if (rCs==null)
				{
					MessageBox.Show("Salto Form (per Rcs) "+rForm["metadata"].ToString()+"--"+
						rForm["edittype"].ToString()+"--"+
						rForm["namespace"].ToString()+"--"+
						rForm["form"].ToString()+"--"+rForm["directory"].ToString()+"--"+
						rForm["cs"].ToString());
					continue;
				}

				DataRow rProgettoForm = rCs.GetParentRow("ren_progettoren_file_cs");
				if (rProgettoForm==null)
				{
					MessageBox.Show("Salto Form (per rProgettoForm) "+rForm["metadata"].ToString()+"--"+
						rForm["edittype"].ToString()+"--"+
						rForm["namespace"].ToString()+"--"+
						rForm["form"].ToString()+"--"+rForm["directory"].ToString()+"--"+
						rForm["cs"].ToString());
					continue;
				}
				int numeroForm = Convert.ToInt32(rProgettoForm["numeroform"]);
				if (numeroForm==1) 
				{
					string stringaSostitutiva = "return MetaData.GetFormByDllName(\"" + rProgettoForm["nuovonome"] + "\");//PinoRana";
					string nomeForm = rForm["form"].ToString();
					string[] pattern = new string[] {nomeForm, "*", "=", "new", nomeForm, "(", ")", ";", "return", "*", ";"};
					cs = sostituisciPattern(cs, pattern, stringaSostitutiva);

					pattern = new string[] {"return", "new", nomeForm, "(", ")", ";"};
					cs = sostituisciPattern(cs, pattern, stringaSostitutiva);

					if (StringTokenizer.cercaParola(cs, nomeForm, 0) == -1)
					{
						string query = "idprogetto='" + progetto.idProgetto + "' and idriferimento='" + rProgettoForm["idprogetto"] +"'";
						DataRow[] rRiferimento = DS.ren_riferimento.Select(query);
						if (rRiferimento.Length > 0) 
						{
							string idRiferimento = rRiferimento[0]["idriferimento"].ToString();
							string riferimento = rRiferimento[0]["riferimento"].ToString();
							if ((riferimentiDaEliminare.IndexOf(idRiferimento) == -1)
								&& (riferimento != "CreditoreDebitoreAnagrafica"))
							{
								riferimentiDaEliminare.Add(idRiferimento);
								int numeroRiferentesi = Convert.ToInt32(rProgettoForm["nuovireferenti"]);
								rProgettoForm["nuovireferenti"] = numeroRiferentesi - 1;
								DS.ren_riferimento.Rows.Remove(rRiferimento[0]);
							}
						}
					}
				}
			}
			return cs;
		}

		/*		private void rinominaForm(string dir1, string dir2) 
				{
					leggiTabella(DS.ren_form, null, null, null, null);
					leggiTabella(DS.ren_cs, null, null, null, null);
					leggiTabella(DS.ren_progetto, null, null, null, null);
					leggiTabella(DS.ren_riferimento, null, null, null, null);
					progressBar1.Maximum = DS.ren_form.Rows.Count;
					foreach (DataRow rForm in DS.ren_form.Rows) 
					{
						DataRow rProgettoMeta = DS.ren_progetto.Select("progetto='meta_" + rForm["metadata"] + "'")[0];
						DataRow rCsMeta = DS.ren_cs.Select("idprogetto='" + rProgettoMeta["idprogetto"] + "' and cs='" + rForm["metadata"] + ".cs'")[0];
				
						string nomeFileInput = Path.Combine(dir1, rCsMeta["directory"] + "\\" + rCsMeta["cs"]);
						string nomeFileOutput = Path.Combine(dir2, rProgettoMeta["nuovadirectory"] + "\\" + rCsMeta["cs"]);

						string nuovoNomeProgetto = getNuovoRiferimento(rProgettoMeta["progetto"].ToString(), rProgettoMeta["idProgetto"].ToString());
						modificaUsingENameSpace(rProgettoMeta["idprogetto"].ToString(), nomeFileInput, nomeFileOutput, nuovoNomeProgetto);

						StreamReader sr = new StreamReader(nomeFileOutput);

						string stringaSostitutiva = "return MetaData.GetFormByDllName(\"" + rForm["metadata"] + "\");//PinoRana";

						string[] pattern = new string[] {rForm["form"].ToString(), "*", "=", "new", rForm["form"].ToString(), "(", ")", ";", "return", "*", ";"};
						string cs = sostituisciPattern(sr.ReadToEnd(), pattern, stringaSostitutiva);

						pattern = new string[] {"return", "new", rForm["form"].ToString(), "(", ")", ";"};
						cs = sostituisciPattern(cs, pattern, stringaSostitutiva);

						sr.Close();
						StreamWriter sw = new StreamWriter(nomeFileOutput);
						sw.Write(cs);
						sw.Close();
						progressBar1.Value ++;
						Application.DoEvents();
					}
					progressBar1.Value = 0;
				}*/

		private void buttonTabelleRename_Click(object sender, System.EventArgs e)
		{
			string path = new FileInfo(textBoxSolution.Text).DirectoryName;

			MetaData meta = MetaData.GetMetaData(this);

			string idSolution = scriviTabelleProgettiEForm(textBoxSolution.Text);
			scriviTabelleFileInclusiERifProgetti(idSolution, path);
			scriviSulDataBase();
			aggiornaTabellaProgetti();

			Console.WriteLine("HO FINITO");
		}

		private void buttonForm_Click(object sender, System.EventArgs e)
		{
			leggiTabella(mainDA, DS.ren_progetto, null, null, null);
			StreamReader sr = File.OpenText(DRIVE+@"\wintrash\meta_entrata\entrata.cs");
			sostituisciGetformbydllname(sr.ReadToEnd());
			/*			scriviSuTabellaRenForm("liquidazioneiva");
						string nomeFile = @"c:\WINTRASH\liquidazioneiva_acconto\frmliquidazioneiva_acconto.cs";
						StreamReader sr = new StreamReader(nomeFile);
						string s = sr.ReadToEnd();
						int inizioNS = s.IndexOf("namespace ") + "namespace ".Length;
						int fineNS = s.IndexOfAny(new char[] {' ','\r'}, inizioNS);
						string nameSpace = s.Substring(inizioNS, fineNS-inizioNS);
						int inizioNomeClasse = s.IndexOf("public class ") + "public class ".Length;
						int fineNomeClasse = s.IndexOfAny(new char[] {' ','\r'}, inizioNomeClasse);
						string nomeClasse = s.Substring(inizioNomeClasse, fineNomeClasse-inizioNomeClasse);
						DataRow[] rForms = DS.ren_form.Select("namespace='"+nameSpace+"' and form='"+nomeClasse+"'");
						DataRow drForm = rForms[0];
						foreach (DataRow rForm in rForms)
						{
							Console.WriteLine("HO TROVATO "+rForm);
							/*					rForm["directory"] = rFil["directory"];
												rForm["cs"] = rFil["cs"];*/
			//			}



			/*			StreamReader sr = new StreamReader("c:/prova/errori.txt");
						String progetto = sr.ReadLine();
						while (progetto.StartsWith("------ Inizio generazione: Progetto: ")) 
						{
							for (int i=0; i<4; i++) 
							{
								sr.ReadLine();
							}
							String riga = sr.ReadLine();
							if (riga.StartsWith("error ")) 
							{
								Console.WriteLine();
								Console.WriteLine(progetto);
								while (!riga.StartsWith("Building satellite assemblies...")) 
								{
									if (riga!="") 
									{
										Console.WriteLine(riga);
									}
									riga = sr.ReadLine();
								}
							}
							while (!riga.StartsWith("Building satellite assemblies...")) 
							{
								riga = sr.ReadLine();
							}
							for (int i=0; i<4; i++) 
							{
								progetto = sr.ReadLine();
							}
						}*/
		}

		private void associaGuidaAiControlli(Control controllo) 
		{
			/*			foreach (Control c in controllo.Controls) 
						{
							helpProvider1.SetHelpNavigator(this, HelpNavigator.TableOfContents);
						}*/
		}

		public static HelpProvider getHelpProviderForForm(Form form) 
		{
			HelpProvider helpProvider = new HelpProvider();
			helpProvider.HelpNamespace = Path.Combine("help", form.Name+".htm");
			helpProvider.SetHelpNavigator(form, HelpNavigator.TableOfContents);
			return helpProvider;
		}

		private void aggiustaRiferimenti(FileInfo oldSln, FileInfo newSln, int numeroProgetti)
		{
			progressBar1.Maximum = numeroProgetti;
			foreach (Progetto progetto in new Solution(oldSln, newSln)) 
			{
				DataRow rProgetto = DS.ren_progetto.Select("idprogetto='" + progetto.idProgetto + "'")[0];
				DirectoryInfo dir = new FileInfo(Path.Combine(DRIVE+DIRECTORY, progetto.relPath)).Directory;
				string rel2 = getPercorsoRelativo(dir, newSln.Directory, @"mainform\bin\debug");
				int numeroRiferentesi = Convert.ToInt32(rProgetto["nuovireferenti"]);

				foreach (XmlElement config in progetto.config) 
				{
					if (config.GetAttribute("Name") == "Debug") 
					{
						if (numeroRiferentesi == 0) 
						{
							config.SetAttribute("OutputPath", rel2);
						}
						else 
						{
							config.SetAttribute("OutputPath", @"bin\debug");
						}
					}
				}
				progetto.salvaConNome(dir.FullName, progetto.progetto);
				progressBar1.Value ++;
				Application.DoEvents();
			}
			progressBar1.Value = 0;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			leggiTabella(mainDA, DS.ren_form, null, null, null);
			foreach (DataRow rForm in DS.ren_form.Rows) 
			{
				DirectoryInfo di = new DirectoryInfo(DRIVE+@"\wintrash\"+rForm["directory"].ToString());
				foreach (FileInfo fi in di.GetFiles("*.xsd")) 
				{
					DataSet ds = new DataSet();
					ds.ReadXml(fi.FullName);
					DataTable dt = ds.Tables[rForm["metadata"].ToString()];
					if (dt != null) 
					{
						DataColumn[] primaryKey = dt.PrimaryKey;
						if ((primaryKey==null) || (primaryKey.Length==0))
						{
							Console.WriteLine(rForm["metadata"]+" "+fi.FullName);
						}
					}
				}
			}
		}
	}
}
//F  xfk? foreign key
//PK xpk  primary key
//UQ xak? unique
//U       user table

//D  DF__ default
//S  sys  system table
//TR tr   trigger
//V       view
//P  sp   procedure

