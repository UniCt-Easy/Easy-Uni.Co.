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
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using System.IO;
using metadatalibrary;
using System.Net;
using System.Threading;
using System.Text;

namespace metaeasylibrary
{
    /// <summary>
    /// Summary description for frmEasyConnect.
    /// </summary>
    public class frmEasyConnect : System.Windows.Forms.Form
    {

        /// <summary>
        /// Output DataAccess Object
        /// </summary>
        public Easy_DataAccess MyDataAccess = null;

        /// <summary>
        /// Controlli pubblici per permettere la'accesso alle
        /// textbox da EasyBlazor per la login automatica LDAP
        /// </summary>
        public TextBox txtUser;
        public ComboBox cmbEnte;
        public TextBox txtLDAP;

        private NumericUpDown dmnEsercizio;
        private Button btnAnnulla;
        private Button btnOk;
        private Label lblDataCont;
        private Label lblEsercizio;
        private TextBox txtDataCont;
        private Label lblPassword;
        private Label lblUser;
        private TextBox txtPassword;
        private Label lblEnte;
        private TextBox txtDataBase;
        private Label label2;
        private TextBox txtServer;
        private Label label1;
        private CheckBox chkAvanzate;
        private TextBox txtDSN;
        private Label label3;
        private CheckBox chkAddToList;
        private Label label4;
        private TextBox txtDipartimento;
        private Label label5;
        private TextBox txtOldPwd;
        private Button btnDelete;
        private Label label6;
        private PictureBox pictureBox1;
        private Label label7;
        private Button btnMostra;

        private List<string[]> enti;

        bool GoodData;
        bool DontUpdate;

        DataSet LastAcc;
        string LastUser = "";
        string LastDB = "";

        CQueryHelper QHC = new CQueryHelper();

        void ReadLastConnection(string ntuser)
        {
            LastAcc = new DataSet();
            try
            {
                LastAcc.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "lastconnnt.xml", XmlReadMode.ReadSchema);
            }
            catch
            {
                LastAcc = null;
                DataSet LastAcc_old = new DataSet();
                try
                {
                    LastAcc_old.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "lastconn.xml", XmlReadMode.ReadSchema);
                    DataRow rLastOld = LastAcc_old.Tables["lastconn"].Rows[0];
                    LastUser = rLastOld["lastuser"].ToString();
                    LastDB = rLastOld["lastdb"].ToString();
                }
                catch { }

                return;
            }

            if (LastAcc.Tables["lastconn"].Select(QHC.CmpEq("ntuser", ntuser)).Length == 0)
                return;

            DataRow rLast = LastAcc.Tables["lastconn"].Select(QHC.CmpEq("ntuser", ntuser))[0];
            LastUser = rLast["lastuser"].ToString();
            LastDB = rLast["lastdb"].ToString();
        }

        void WriteLastConnection(string ntuser)
        {
            try
            {
                if (LastAcc == null)
                {
                    LastAcc = new LastConnection();
                }
                DataRow R;
                if (LastAcc.Tables["lastconn"].Select(QHC.CmpEq("ntuser", ntuser)).Length > 0)
                {
                    R = LastAcc.Tables["lastconn"].Select(QHC.CmpEq("ntuser", ntuser))[0];
                }
                else
                {
                    R = LastAcc.Tables["lastconn"].NewRow();
                    R["ntuser"] = ntuser;
                    LastAcc.Tables["lastconn"].Rows.Add(R);
                }
                R["lastuser"] = LastUser;
                R["lastdb"] = LastDB;

                LastAcc.WriteXml("lastconnnt.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception e)
            {
                QueryCreator.ShowException(e);
            }
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        void WriteDBList(dblist dbl)
        {
            string curpath = AppDomain.CurrentDomain.BaseDirectory;
            if (!curpath.EndsWith("\\"))
                curpath += "\\";

            try
            {
                dbl.WriteXml(curpath + "dblist.xml", XmlWriteMode.WriteSchema);
            }
            catch (Exception E)
            {
                QueryCreator.ShowException(E);
            }
        }

        dblist currList = new dblist();

        void CheckExistsDBList()
        {
            string curpath = AppDomain.CurrentDomain.BaseDirectory;
            if (!curpath.EndsWith("\\"))
                curpath += "\\";
            
            if (File.Exists(curpath + "dblist.xml"))
                return;

            currList = new dblist();
            AddDummytoList(currList);
            WriteDBList(currList);
        }

        /// <summary>
        /// Legge la lista dei db da file xml
        /// </summary>
        /// <returns></returns>
        dblist GetDBList()
        {
            string curpath = AppDomain.CurrentDomain.BaseDirectory;
            if (!curpath.EndsWith("\\"))
                curpath += "\\";

            if (!File.Exists(curpath + "dblist.xml"))
                return new dblist();

            dblist newdblist = new dblist();
            try
            {
                newdblist.ReadXml(curpath + "dblist.xml");
                if (!newdblist.Tables["db"].Columns.Contains("ldapserver"))
                    newdblist.Tables["db"].Columns.Add(new DataColumn("ldapserver", typeof(string)));
            }
            catch (Exception E)
            {
                QueryCreator.ShowException(E);
                AddDummytoList(newdblist);
            }
            newdblist.CaseSensitive = false;
            return newdblist;
        }

        /// <summary>
        /// Aggiunge una o più righe a dblist prendendole dall'ODBC list
        /// </summary>
        /// <param name="dbl"></param>
        bool AddDummytoList(DataSet dbl)
        {
            try
            {
                string curruser = System.Environment.UserName;
                if (dbl.Tables["db"].Select("ntuser=" + QueryCreator.quotedstrvalue(curruser, false)).Length > 0)
                    return false;

                //Adds a dummy row so it will never come here again
                DataRow dummy = dbl.Tables["db"].NewRow();
                dummy["ntuser"] = curruser;
                dummy["description"] = "**dummy**";
                dbl.Tables["db"].Rows.Add(dummy);
                //MergeODBCToList(dbl);

                return true;
            }
            catch (Exception E)
            {
                QueryCreator.ShowException(E);
            }

            return false;
        }

        void AddCurrentToList()
        {
            string filterusr = "(description=" + QueryCreator.quotedstrvalue(txtDSN.Text, false) + ")AND" +
                               "(ntuser=" + QueryCreator.quotedstrvalue(System.Environment.UserName.ToUpper(), false) +
                               ")";
            string filterall = "(description=" + QueryCreator.quotedstrvalue(txtDSN.Text, false) + ")AND" +
                               "(ntuser='*')";
            DataTable DB = currList.Tables["db"];
            DataRow dbr;
            DataRow[] foundall = DB.Select(filterall);
            if (foundall.Length > 0)
                return;

            DataRow[] foundusr = DB.Select(filterusr);
            if (foundusr.Length > 0)
            {
                dbr = foundusr[0];
                if ((dbr["server"].ToString() == txtServer.Text) &&
                    (dbr["database"].ToString() == txtDataBase.Text) &&
                    //(dbr["trusted"].ToString()== (chkIntegrata.Checked? "S":"N"))&&
                    (dbr["department"].ToString() == txtDipartimento.Text) &&
                    (dbr["ldapserver"].ToString() == txtLDAP.Text))
                    return;

                dbr["server"] = txtServer.Text;
                dbr["database"] = txtDataBase.Text;
                dbr["department"] = txtDipartimento.Text;
                dbr["user"] = txtUser.Text;
                dbr["ldapserver"] = txtLDAP.Text;
                WriteDBList(currList);
            }
            else
            {
                dbr = DB.NewRow();
                dbr["description"] = txtDSN.Text;
                dbr["server"] = txtServer.Text;
                dbr["database"] = txtDataBase.Text;
                dbr["ntuser"] = System.Environment.UserName.ToUpper();
                dbr["user"] = txtUser.Text;
                dbr["department"] = txtDipartimento.Text;
                dbr["ldapserver"] = txtLDAP.Text;
                DB.Rows.Add(dbr);
                WriteDBList(currList);
            }
        }

        void RemoveCurrentFromList()
        {
            string filterusr = "(description=" + QueryCreator.quotedstrvalue(txtDSN.Text, false) + ")AND" +
                               "(ntuser=" + QueryCreator.quotedstrvalue(System.Environment.UserName.ToUpper(), false) +
                               ")";
            string filterall = "(description=" + QueryCreator.quotedstrvalue(txtDSN.Text, false) + ")AND" +
                               "(ntuser='*')";
            DataTable DB = currList.Tables["db"];
            DataRow[] foundusr = DB.Select(filterusr);
            if (foundusr.Length == 0)
                return;

            foundusr[0].Delete();
            DB.AcceptChanges();
            WriteDBList(currList);
            
            int i = cmbEnte.SelectedIndex;
            enti.RemoveAt(i);
            cmbEnte.Items.RemoveAt(i);            
            if (i == enti.Count)
                i--;
            cmbEnte.SelectedIndex = i;

            UpdateTxt(i);
        }

        void DoAddRemoveItemFromList()
        {
            if (chkAddToList.Checked)
                AddCurrentToList();
            //else
            //  RemoveCurrentFromList();
        }

        void FillComboWithDBList(DataSet dbl)
        {
            string curruser = System.Environment.UserName;

            DataTable DB = dbl.Tables["db"];
            DB.CaseSensitive = false;
            DataRow[] dbrow = DB.Select("((ntuser=" + QueryCreator.quotedstrvalue(curruser, false) + ")" +
                                        "OR(ntuser='*'))AND(description<>'**dummy**')", "description");

            int nsubkey = dbrow.Length;
            enti = new List<string[]>();
            int index = 0;
            int defaultindex = -1;
            foreach (DataRow DBR in dbrow)
            {
                string str = DBR["description"].ToString();
                enti.Add(new string[] {
                    str, DBR["server"].ToString().Trim(), DBR["database"].ToString().Trim(),
                    DBR["user"].ToString(), DBR["department"].ToString(), DBR["ldapserver"].ToString()
                });
                if (str == LastDB)
                    defaultindex = index;

                index++;
            }
            DontUpdate = true;
            cmbEnte.BeginUpdate();
            cmbEnte.Items.Clear();
            for (int i = 0; i < index; i++)
            {
                try
                {
                    cmbEnte.Items.Add(enti[i][0]);
                }
                catch
                {
                    //parte rimanente degli enti
                }

            }
            cmbEnte.EndUpdate();

            dmnEsercizio.Text = DateTime.Today.Year.ToString();
            if (index > 0) cmbEnte.SelectedIndex = 0;
            if (dbrow.Length == 0)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this,
                    "Non ci sono enti configurati. Riempire le informazioni Nome Ente, Server, DataBase " +
                    "relative al database a cui ci si vuole connettere.",
                    "Avviso");
                chkAvanzate.Checked = true;
                chkAddToList.Checked = true;
            }
            MyDataAccess = null;
            GoodData = true;
            if (defaultindex != -1)
                cmbEnte.SelectedIndex = defaultindex;

            DontUpdate = false;
            cmbEnte_SelectedIndexChanged(null, null);
            
            if ((!txtUser.ReadOnly) && txtUser.Enabled)
                txtUser.Text = LastUser;

            chkAvanzate_CheckedChanged(null, null);
            txtPassword.Focus();
        }

        public frmEasyConnect()
        {
            string ntuser = System.Environment.UserName.ToUpper();
            InitializeComponent();

            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;

            MetaData.SetColor(this, true);
            txtDataCont.Text = DateTime.Today.ToShortDateString();
            //this.DBIdentifier= SourceName;
            ReadLastConnection(ntuser);
            DontUpdate = true;

            CheckExistsDBList();
            currList = GetDBList();
            if (AddDummytoList(currList)) WriteDBList(currList);
            FillComboWithDBList(currList);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEasyConnect));
            this.dmnEsercizio = new System.Windows.Forms.NumericUpDown();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblDataCont = new System.Windows.Forms.Label();
            this.lblEsercizio = new System.Windows.Forms.Label();
            this.txtDataCont = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblEnte = new System.Windows.Forms.Label();
            this.cmbEnte = new System.Windows.Forms.ComboBox();
            this.txtDataBase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAvanzate = new System.Windows.Forms.CheckBox();
            this.txtDSN = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAddToList = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDipartimento = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtLDAP = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMostra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dmnEsercizio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dmnEsercizio
            // 
            this.dmnEsercizio.Location = new System.Drawing.Point(446, 112);
            this.dmnEsercizio.Maximum = new decimal(new int[] {
            2038,
            0,
            0,
            0});
            this.dmnEsercizio.Minimum = new decimal(new int[] {
            1996,
            0,
            0,
            0});
            this.dmnEsercizio.Name = "dmnEsercizio";
            this.dmnEsercizio.Size = new System.Drawing.Size(57, 20);
            this.dmnEsercizio.TabIndex = 5;
            this.dmnEsercizio.Value = new decimal(new int[] {
            1996,
            0,
            0,
            0});
            this.dmnEsercizio.ValueChanged += new System.EventHandler(this.dmnEsercizio_ValueChanged);
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(422, 152);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(85, 24);
            this.btnAnnulla.TabIndex = 7;
            this.btnAnnulla.Text = "Annulla";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(334, 152);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 24);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblDataCont
            // 
            this.lblDataCont.Location = new System.Drawing.Point(198, 112);
            this.lblDataCont.Name = "lblDataCont";
            this.lblDataCont.Size = new System.Drawing.Size(93, 16);
            this.lblDataCont.TabIndex = 21;
            this.lblDataCont.Text = "Data Contabile:";
            this.lblDataCont.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEsercizio
            // 
            this.lblEsercizio.Location = new System.Drawing.Point(382, 112);
            this.lblEsercizio.Name = "lblEsercizio";
            this.lblEsercizio.Size = new System.Drawing.Size(61, 16);
            this.lblEsercizio.TabIndex = 20;
            this.lblEsercizio.Text = "Esercizio:";
            this.lblEsercizio.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // txtDataCont
            // 
            this.txtDataCont.Location = new System.Drawing.Point(294, 112);
            this.txtDataCont.Name = "txtDataCont";
            this.txtDataCont.Size = new System.Drawing.Size(77, 20);
            this.txtDataCont.TabIndex = 4;
            this.txtDataCont.Text = "5/22/2002";
            this.txtDataCont.TextChanged += new System.EventHandler(this.txtDataCont_TextChanged);
            this.txtDataCont.Leave += new System.EventHandler(this.txtDataCont_Leave);
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(183, 80);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(109, 16);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "Parola di accesso:";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUser
            // 
            this.lblUser.Location = new System.Drawing.Point(222, 48);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(69, 16);
            this.lblUser.TabIndex = 17;
            this.lblUser.Text = "Utente:";
            this.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(294, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(205, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(294, 48);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(205, 20);
            this.txtUser.TabIndex = 2;
            // 
            // lblEnte
            // 
            this.lblEnte.Location = new System.Drawing.Point(230, 16);
            this.lblEnte.Name = "lblEnte";
            this.lblEnte.Size = new System.Drawing.Size(61, 16);
            this.lblEnte.TabIndex = 14;
            this.lblEnte.Text = "Ente:";
            this.lblEnte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEnte
            // 
            this.cmbEnte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEnte.ItemHeight = 13;
            this.cmbEnte.Location = new System.Drawing.Point(294, 16);
            this.cmbEnte.Name = "cmbEnte";
            this.cmbEnte.Size = new System.Drawing.Size(205, 21);
            this.cmbEnte.TabIndex = 1;
            this.cmbEnte.SelectedIndexChanged += new System.EventHandler(this.cmbEnte_SelectedIndexChanged);
            // 
            // txtDataBase
            // 
            this.txtDataBase.Location = new System.Drawing.Point(112, 256);
            this.txtDataBase.Name = "txtDataBase";
            this.txtDataBase.Size = new System.Drawing.Size(232, 20);
            this.txtDataBase.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Database";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(112, 224);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(232, 20);
            this.txtServer.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(24, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 26;
            this.label1.Text = "Server";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAvanzate
            // 
            this.chkAvanzate.Location = new System.Drawing.Point(182, 152);
            this.chkAvanzate.Name = "chkAvanzate";
            this.chkAvanzate.Size = new System.Drawing.Size(85, 24);
            this.chkAvanzate.TabIndex = 6;
            this.chkAvanzate.TabStop = false;
            this.chkAvanzate.Text = "Dettagli";
            this.chkAvanzate.CheckedChanged += new System.EventHandler(this.chkAvanzate_CheckedChanged);
            // 
            // txtDSN
            // 
            this.txtDSN.Location = new System.Drawing.Point(112, 192);
            this.txtDSN.Name = "txtDSN";
            this.txtDSN.Size = new System.Drawing.Size(232, 20);
            this.txtDSN.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 31;
            this.label3.Text = "Nome Ente";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAddToList
            // 
            this.chkAddToList.Checked = true;
            this.chkAddToList.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAddToList.Location = new System.Drawing.Point(232, 354);
            this.chkAddToList.Name = "chkAddToList";
            this.chkAddToList.Size = new System.Drawing.Size(112, 24);
            this.chkAddToList.TabIndex = 13;
            this.chkAddToList.Text = "Elenca tra gli enti";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 288);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 33;
            this.label4.Text = "Dipartimento";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDipartimento
            // 
            this.txtDipartimento.Location = new System.Drawing.Point(112, 288);
            this.txtDipartimento.Name = "txtDipartimento";
            this.txtDipartimento.Size = new System.Drawing.Size(232, 20);
            this.txtDipartimento.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 386);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(352, 24);
            this.label5.TabIndex = 34;
            this.label5.Text = "Vecchia Password (da inserire se si è cambiata la propria password dall\'esterno d" +
    "el programma)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(104, 418);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(240, 20);
            this.txtOldPwd.TabIndex = 14;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(78, 354);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(102, 23);
            this.btnDelete.TabIndex = 35;
            this.btnDelete.Text = "Non mostrare più";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtLDAP
            // 
            this.txtLDAP.Location = new System.Drawing.Point(112, 318);
            this.txtLDAP.Name = "txtLDAP";
            this.txtLDAP.Size = new System.Drawing.Size(232, 20);
            this.txtLDAP.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 318);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "Server LDAP";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 13);
            this.label7.TabIndex = 39;
            this.label7.Text = "Easy         Tempo Srl";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::metaeasylibrary.Properties.Resources.logo_128x1281;
            this.pictureBox1.Location = new System.Drawing.Point(19, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(130, 127);
            this.pictureBox1.TabIndex = 38;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // btnMostra
            // 
            this.btnMostra.Location = new System.Drawing.Point(505, 78);
            this.btnMostra.Name = "btnMostra";
            this.btnMostra.Size = new System.Drawing.Size(46, 23);
            this.btnMostra.TabIndex = 40;
            this.btnMostra.Text = "mostra";
            this.btnMostra.UseVisualStyleBackColor = true;
            this.btnMostra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMostra_MouseDown);
            this.btnMostra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMostra_MouseUp);
            // 
            // frmEasyConnect
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnAnnulla;
            this.ClientSize = new System.Drawing.Size(563, 458);
            this.Controls.Add(this.btnMostra);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtLDAP);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDipartimento);
            this.Controls.Add(this.txtDSN);
            this.Controls.Add(this.txtDataBase);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.txtDataCont);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkAddToList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAvanzate);
            this.Controls.Add(this.dmnEsercizio);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblDataCont);
            this.Controls.Add(this.lblEsercizio);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblEnte);
            this.Controls.Add(this.cmbEnte);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmEasyConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Connessione al DB";
            this.Activated += new System.EventHandler(this.frmEasyConnect_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dmnEsercizio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        void UpdateTxt(int selectedIndex)
        {
            if (selectedIndex < 0) return;
            //chkAvanzate.Checked=false;
            txtServer.Text = enti[selectedIndex][1];
            txtDataBase.Text = enti[selectedIndex][2];
            txtDSN.Text = enti[selectedIndex][0];
            txtDipartimento.Text = enti[selectedIndex][4];
            txtUser.Text = enti[selectedIndex][3];
            txtLDAP.Text = enti[selectedIndex][5];
            chkAddToList.Checked = true;
        }

        private void cmbEnte_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (DontUpdate) return;
            pictureBox1.Visible = true;
            UpdateTxt(cmbEnte.SelectedIndex);
        }

        public static bool IsNet45OrNewer()
        {
            var result =
                Environment.Version.Major.Equals(4) &&
                Environment.Version.Minor.Equals(0) &&
                Environment.Version.Build.Equals(30319) &&
                Environment.Version.Revision >= 34000;

            return result;
        }

        /// <summary>
        /// Autentica l'utente con LDAP senza password
        /// </summary>
        /// <returns></returns>
        public void connectTrust()
        {
            this.DialogResult = DialogResult.None;
            if (connect(true))
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        bool connect(bool isTrusted = false)
        {
            string user22 = txtUser.Text;

            if (!GoodData)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Dati non validi");
                this.DialogResult = DialogResult.None;
                return false;
            }

            string server = txtServer.Text; // enti[selectedIndex,1];
            string remserver = "";
            string dbserver = "";
            string user = txtUser.Text.Trim();
            string pwd = txtPassword.Text.Trim();

            server = server.Trim();
            if (server.StartsWith("["))
            {
                int end = server.IndexOf("]", 1);
                if (end >= 1)
                {
                    remserver = server.Substring(1, end - 1).Trim();
                    dbserver = server.Substring(end + 1).Trim();
                }
                else
                {
                    dbserver = server.Trim();
                }
            }
            else
            {
                dbserver = server.Trim();
            }

            string dep = txtDipartimento.Text.Trim();
            string ext_user = user;
            string sys_user = user;

            string ldapserver = txtLDAP.Text.Trim();
            if (ldapserver != "")
            {
                string new_user = "";
                string new_pwd = "";

                if (isTrusted && pwd == "")
                    pwd = "dummypwd";
                try
                {
                    bool res2 = GetLDapAuth(ldapserver, user, pwd, dep, isTrusted,
                        out new_user, out new_pwd, out sys_user);
                    if (res2)
                    {
                        user = new_user;
                        pwd = new_pwd;
                    }
                }
                catch (Exception E)
                {
                    QueryCreator.ShowException(this, "Autenticazione al server LDAP fallita", E);
                }
            }

            string database = txtDataBase.Text; // enti[selectedIndex,2];
            DateTime T0;
            bool dataOk = DateTime.TryParse(txtDataCont.Text, out T0);
            if (!dataOk)
            {
                MetaFactory.factory.getSingleton<IMessageShower>().Show(this, "Dati non validi");
                this.DialogResult = DialogResult.None;
                return false;
            }
            DateTime T = new DateTime(T0.Year, T0.Month, T0.Day, 0, 0, 0);
            string DSN = txtDSN.Text; // enti[selectedIndex,0];
            string msg = null;
            string dettaglio = null;

            if (MyDataAccess == null)
            {
                MyDataAccess = Easy_DataAccess.getEasyDataAccess("DSN", dbserver.Trim(), database.Trim(),
                    user, pwd, txtOldPwd.Text.Trim(),
                    txtDipartimento.Text.Trim(),
                    T.Year, T, out msg, out dettaglio);

                //				//SSPIEnabled = (enti[selectedIndex,3]== "Yes");
                //				if (SSPIEnabled) {
                //					MyDataAccess = new Easy_DataAccess(DSN, dbserver.Trim(), database.Trim(), T.Year, T);
                //				}
                //				else {
                //					MyDataAccess = new Easy_DataAccess(DSN, dbserver.Trim(), database.Trim(), txtUser.Text, txtPassword.Text,
                //						T.Year, T);	
                //				}
            }
            if (msg == "") msg = null;
            string dbversion = "-";
            string serverVersion = "unknown";
            bool res = msg == null;
            if (res)
            {
                res = MyDataAccess.Open();
                serverVersion = MyDataAccess.ServerVersion();
                msg = "Non è stato possibile effettuare il collegamento al dipartimento.";
                dettaglio = MyDataAccess.LastError;
            }
            object iddb = DBNull.Value;

            if (res)
            {
                QueryHelper QHS = MyDataAccess.GetQueryHelper();
                string filtro = QHS.CmpEq("login", user);
                DataTable tAccess = MyDataAccess.RUN_SELECT("dbaccess", null, null, filtro, null, null, true);

                if (tAccess.Columns.Contains("pwdlastmod"))
                {
                    bool pwdStale = false;
                    DateTime today = DateTime.Now.Date;

                    foreach (DataRow rAccess in tAccess.Rows)
                    {
                        if (rAccess["pwdmaxage"] == DBNull.Value || Convert.ToInt32(rAccess["pwdmaxage"]) <= 0 || rAccess["pwdlastmod"] == DBNull.Value) continue;

                        TimeSpan validityperiod = new TimeSpan(Convert.ToInt32(rAccess["pwdmaxage"]), 0, 0, 0, 0);
                        DateTime expirationdate = ((DateTime)rAccess["pwdlastmod"]).Date + validityperiod;

                        if (today > expirationdate) pwdStale = true;

                        if ((rAccess["pwdwarning"]) != DBNull.Value && Convert.ToInt32(rAccess["pwdwarning"]) > 0 && !pwdStale)
                        {
                            TimeSpan warningperiod = new TimeSpan(Convert.ToInt32(rAccess["pwdwarning"]), 0, 0, 0, 0);
                            if (today > expirationdate - warningperiod)
                            {
                                MetaFactory.factory.getSingleton<IMessageShower>().Show("Attenzione, la password scadrà tra " + (expirationdate - today).Days + " giorni");
                            }
                        }
                    }

                    if (pwdStale)
                    {
                        MetaFactory.factory.getSingleton<IMessageShower>().Show("Password scaduta, è necessario aggiornarla");
                        Frm_changepassword_default F = new Frm_changepassword_default(MyDataAccess);
                        MetaFactory.factory.getSingleton<IFormCreationListener>().create(F, this);
                        if (F.ShowDialog() != DialogResult.OK)
                        {
                            msg = "Password scaduta, aggiornamento non effettuato";
                            dettaglio = null;
                        }
                        else
                        {
                            msg = "Aggiornamento password effettuato, autenticarsi con le nuove credenziali";
                            dettaglio = null;
                        }

                        res = !pwdStale;
                    }
                }
            }

            if (res)
            {
                MyDataAccess.externalUser = ext_user;
                if (sys_user != user)
                {
                    MyDataAccess.SetSys("user", sys_user);
                    MyDataAccess.SetSys("usergrouplist", null);
                    MyDataAccess.easySec.CalculateGroupList();
                    MyDataAccess.easySec.RecalcUserEnvironment();
                    MyDataAccess.easySec.ReadAllGroupOperations();
                }

                try
                {
                    dbversion = MyDataAccess.DO_READ_VALUE("updatedbversion", null, "max(versionname)") as string;
                    MyDataAccess.SetSys("dbversion", dbversion);
                }
                catch
                {
                }
                try
                {
                    iddb = MyDataAccess.DO_READ_VALUE("license", null, "iddb");
                }
                catch
                {
                }
                MyDataAccess.Close();
            }

            if (!res)
            {
                MyDataAccess = null;
                QueryCreator.ShowError(this, msg, dettaglio);
                if (!chkAddToList.Checked) DoAddRemoveItemFromList();
                this.DialogResult = DialogResult.None;
            }
            else
            {
                try
                {
                    //Leggo la versione del file locale
                    string localdir = Application.StartupPath;
                    string localversion = "-";
                    try
                    {
                        StreamReader read =
                            new StreamReader(localdir + "\\" + (IsNet45OrNewer() ? "versionesw4.txt" : "versionesw.txt"));
                        localversion = read.ReadLine();
                        read.Close();
                    }
                    catch
                    {
                    }
                    string machinename = (string)MyDataAccess.GetSys("computername");
                    string username = (string)MyDataAccess.GetSys("userdb");
                    server = server.Trim() + " ver." + decodeServerVersion(serverVersion);
                    string data =
                        "nomedb=" + QueryCreator.quotedstrvalue(database.Trim(), true) + ";" +
                        "server=" + QueryCreator.quotedstrvalue(server, true) + ";" +
                        "dep=" + QueryCreator.quotedstrvalue(username.Trim(), true) + ";" +
                        "dbversion=" + QueryCreator.quotedstrvalue(dbversion, true) + ";" +
                        "swversion=" + QueryCreator.quotedstrvalue(localversion, false) + ";" +
                        "username=" + QueryCreator.quotedstrvalue(user22, true) + ";" +
                        "machine=" + QueryCreator.quotedstrvalue(machinename, false) + ";" +
                        "iddb=" + QueryCreator.quotedstrvalue(iddb, false);

                    Logger L = new Logger(MyDataAccess, data);
                    Thread TT = new Thread(new ThreadStart(L.start));
                    TT.Name = "secondary";
                    TT.Start();

                }
                catch
                {
                }


                LastUser = txtUser.Text;
                LastDB = DSN;
                WriteLastConnection(System.Environment.UserName.ToUpper());
                DoAddRemoveItemFromList();

            }

            return res;
        }

        string decodeServerVersion(string ver)
        {
            if (ver == null) return "?";
            string[] vp = ver.Split('.');
            if (vp.Length >= 3)
            {

                if (vp[0] == "14")
                {
                    return "Sql2017";
                }
                if (vp[0] == "13")
                {
                    return "Sql2016";
                }
                if (vp[0] == "12")
                {
                    if (vp[2].CompareTo("5000") >= 0) return "sql2014SP2";
                    if (vp[2].CompareTo("4100") >= 0) return "sql2014SP1";
                    return "sql2014";
                }
                if (vp[0] == "11")
                {
                    if (vp[2].CompareTo("6020") >= 0) return "sql2012SP3";
                    if (vp[2].CompareTo("5058") >= 0) return "sql2012SP2";
                    if (vp[2].CompareTo("3000") >= 0) return "sql2012SP1";
                    return "sql2012";
                }
                if (vp[0] == "10" && vp[1] == "50")
                {
                    if (vp[2].CompareTo("6000") >= 0) return "sql2008R2SP3";
                    if (vp[2].CompareTo("4000") >= 0) return "sql2008R2SP2";
                    if (vp[2].CompareTo("2500") >= 0) return "sql2008R2SP1";
                    return "sql2008R2";
                }
                if (vp[0] == "10" && vp[1] == "00")
                {
                    if (vp[2].CompareTo("6000") >= 0) return "sql2008SP4";
                    if (vp[2].CompareTo("5500") >= 0) return "sql2008SP3";
                    if (vp[2].CompareTo("4000") >= 0) return "sql2008SP2";
                    if (vp[2].CompareTo("2531") >= 0) return "sql2008SP1";
                    return "sql2008";
                }
                if (vp[0] == "9")
                {
                    if (vp[2].CompareTo("5000") >= 0) return "sql2005SP4";
                    if (vp[2].CompareTo("4035") >= 0) return "sql2005SP3";
                    if (vp[2].CompareTo("3042") >= 0) return "sql2005SP2";
                    if (vp[2].CompareTo("2047") >= 0) return "sql2005SP1";
                    return "sql2005";
                }
                if (vp[0] == "8")
                {
                    return "sql2000";
                }
                if (vp[0] == "7")
                {
                    return "sql7";
                }
            }

            return ver;
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.None;
            if (connect())
            {
                this.DialogResult = DialogResult.OK;
            }

        }

        bool GetLDapAuth(string serverldap, string user, string pwd, string dep, bool isTrusted,
            out string db_user, out string db_pwd, out string sys_user)
        {
            db_user = user;
            db_pwd = pwd;
            sys_user = user;
            CQueryHelper QHC = new CQueryHelper();
            Hashtable H = new Hashtable();
            H["usr"] = user;
            H["pwd"] = pwd;
            H["dep"] = dep;
            H["tru"] = isTrusted ? "Y" : "";
            string SS = DataAccess.GetStringFromHashTable(H);
            Hashtable HH = DataAccess.GetHashFromString(SS);

            WebClient W = new WebClient();
            if (!serverldap.EndsWith("/")) serverldap += "/";
            W.BaseAddress = serverldap;

            byte[] B = W.DownloadData(serverldap + "LDAPService.aspx?x=" + SS);
            if ((B != null) && (B.Length > 0))
            {
                string S = Encoding.Default.GetString(B);

                if (!S.StartsWith("Errore"))
                {
                    Hashtable H1 = DataAccess.GetHashFromString(S);
                    db_pwd = H1["pwd"].ToString();
                    db_user = H1["usr"].ToString();
                    sys_user = H1["vusr"].ToString();
                }
                else
                {
                    return false;
                }
            }

            return true;
        }


        private void btnAnnulla_Click(object sender, System.EventArgs e)
        {
            MyDataAccess = null;
        }

        private void dmnEsercizio_ValueChanged(object sender, System.EventArgs e)
        {

            if (DontUpdate) return;
            DontUpdate = true;
            DateTime T;
            try
            {
                int anno = Convert.ToInt32(dmnEsercizio.Value);
                if (anno < DateTime.Now.Year)
                {
                    T = new DateTime(anno, 12, 31);
                    txtDataCont.Text = T.ToShortDateString();
                }
                if (anno == DateTime.Now.Year)
                {
                    T = new DateTime(anno, DateTime.Now.Month, DateTime.Now.Day);
                    txtDataCont.Text = T.ToShortDateString();
                }
                if (anno > DateTime.Now.Year)
                {
                    T = new DateTime(anno, 1, 1);
                    txtDataCont.Text = T.ToShortDateString();
                }
                GoodData = true;
            }
            catch
            {
                GoodData = false;
            }
            DontUpdate = false;

        }

        private void txtDataCont_Leave(object sender, System.EventArgs e)
        {
            if (DontUpdate) return;
            DontUpdate = true;
            try
            {
                string S = txtDataCont.Text;
                DateTime T;
                GoodData = DateTime.TryParse(S, out T);
                if (GoodData)
                {
                    dmnEsercizio.Value = T.Year;
                }
            }
            catch
            {
                GoodData = false;
            }
            DontUpdate = false;
        }

        private void chkAvanzate_CheckedChanged(object sender, System.EventArgs e)
        {
            if (chkAvanzate.Checked)
            {
                Size S = new Size(this.Width, txtOldPwd.Location.Y + txtOldPwd.Height * 2);
                Height = SizeFromClientSize(S).Height;
            }
            else
            {
                Size S = new Size(this.Width, btnOk.Location.Y + btnOk.Height + 10);
                Height = SizeFromClientSize(S).Height;   //baseHeight;
            }

        }


        private void txtDataCont_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            RemoveCurrentFromList();
            FillComboWithDBList(currList);
            UpdateTxt(cmbEnte.SelectedIndex);
        }

        private bool onetime = true;

        void doOneTime()
        {
            if (!onetime) return;
            onetime = false;

            if (this.Tag != null)
            {
                string[] args = (string[])this.Tag;
                if (args.Length < 4) return;
                if (args[0] != "autostart") return;
                string ente = args[1];

                if (args.Length > 5)
                {
                    txtDataCont.Text = args[4];
                    dmnEsercizio.Text = args[5];
                }

                int selected = -1;
                for (int i = 0; i < enti.Count; i++)
                {
                    string s = enti[i][0];
                    if (s == ente)
                    {
                        selected = i;
                        break;
                    }
                }
                if (selected < 0)
                {
                    for (int i = 0; i < enti.Count; i++)
                    {
                        string s = enti[i][0];
                        if (s.Contains(ente))
                        {
                            selected = i;
                            break;
                        }
                    }
                }
                if (selected >= 0)
                {
                    UpdateTxt(selected);
                    txtUser.Text = args[2];
                    txtPassword.Text = args[3];
                    if (connect())
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }

                }
            }
        }

        private void frmEasyConnect_Activated(object sender, EventArgs e)
        {
            doOneTime();
        }

        private void btnMostra_MouseDown(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = txtUser.PasswordChar;
        }

        private void btnMostra_MouseUp(object sender, MouseEventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() != "") return;
            if (!File.Exists(Path.Combine(Application.StartupPath, "mypwd_hires.txt"))) return;
            string s = File.ReadAllText(Path.Combine(Application.StartupPath, "mypwd_hires.txt"));
            string[] allDip = s.Split('\n');
            foreach (string dipPwd in allDip)
            {
                if (dipPwd.Trim() == "") continue;
                if (dipPwd.Split(':').Length != 2) continue;
                string dip = dipPwd.Split(':')[0].Trim();
                string pwd = dipPwd.Split(':')[1].Trim();
                if (dip.ToLower() == txtDSN.Text.ToLower())
                {
                    txtPassword.Text = pwd;
                    break;
                }
            }
            btnOk.PerformClick();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (txtPassword.Text.Trim() == "") return;
            if (!File.Exists(Path.Combine(Application.StartupPath, "mypwd_hires.txt"))) return;
            string s = File.ReadAllText(Path.Combine(Application.StartupPath, "mypwd_hires.txt"));
            string[] allDip = s.Split('\n');
            bool found = false;
            for (int i = 0; i < allDip.Length; i++)
            {
                var dipPwd = allDip[i];
                if (dipPwd.Trim() == "") continue;
                if (dipPwd.Split(':').Length != 2) continue;
                string dip = dipPwd.Split(':')[0].Trim();
                string pwd = dipPwd.Split(':')[1].Trim();
                if (dip.ToLower() == txtDSN.Text.ToLower())
                {
                    pwd = txtPassword.Text;
                    s = s.Replace(dipPwd, dip + ":" + pwd);
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                s = s + "\n" + txtDSN.Text + ":" + txtPassword.Text;
            }
            File.WriteAllText(Path.Combine(Application.StartupPath, "mypwd_hires.txt"), s);
            pictureBox1.Visible = false;
        }
    }

    class Logger
    {
        string data;
        DataAccess Conn;

        public Logger(DataAccess Conn, string data)
        {
            this.data = data;
            this.Conn = Conn.Duplicate();
        }

        public void start()
        {
            try
            {
                byte[] B2 = DataAccess.CryptString(data); //dati criptati
                string SS = QueryCreator.ByteArrayToString(B2); //stringa dei dati criptati

                WebClient W = new WebClient();
                W.BaseAddress = MetaData.errorLogBaseAddress; // "http://your-server/LiveLog/";
                //byte [] B = W.DownloadData("http://your-server/LiveLog/Do.aspx?x="+SS);
                byte[] B = W.DownloadData(MetaData.errorLogUrl + "?x=" + SS);//"http://your-server/LiveLog/DoEasy.aspx
                if ((B != null) && (B.Length > 0))
                {
                    W.Dispose();
                    object XXX = Conn.DO_SYS_CMD("exp_license '0'");
                    if (XXX != null)
                    {
                        string XX = XXX.ToString();
                        XX = data + ";" + XX.ToString();
                        B2 = DataAccess.CryptString(XX);
                        string SS2 = QueryCreator.ByteArrayToString(B2);
                        W = new WebClient();
                        W.BaseAddress = MetaData.errorLogBaseAddress; // "http://your-server/LiveLog/";
                        B = W.DownloadData(MetaData.errorLogUrl + "?y=" + SS2); //"http://your-server/LiveLog/DoEasy.aspx
                        Conn.DO_SYS_CMD("UPDATE license set sent='S'");
                    }
                }
                W.Dispose();
                Conn.Destroy();
            }
            catch (Exception E)
            {
                string S31 = E.Message;
                Conn.Destroy();
            }
        }
    }
}
