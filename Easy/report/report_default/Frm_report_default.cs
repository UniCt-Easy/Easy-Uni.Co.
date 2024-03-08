
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
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using System.IO;
using metaeasylibrary;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;
using System.Text;
using generaSQL;

namespace report_default //modulereportparameter//
{
    /// <summary>
    /// Summary description for frmmodulereportparameter.
    /// </summary>
    public class Frm_report_default : MetaDataForm {
        public /*Rana:modulereportparameter.*/ vistaForm DS;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox MetaDataDetail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog _openFileDialog1;
        private IOpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbOrientVert;
        private System.Windows.Forms.RadioButton rdbOrientOrizz;
        private System.Windows.Forms.ComboBox cmbGroupName;
        private System.Windows.Forms.TextBox txtDescrizione;
        private System.Windows.Forms.TextBox txtNomeRep;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGrid dgrReportParameter;
        private System.Windows.Forms.ImageList images;
        MetaData Meta;
        DataAccess Conn;

        private System.Windows.Forms.ComboBox cmbModuli;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gboxApplicazione;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox5;
        private CheckBox checkBox6;
        private CheckBox checkBox7;
        private RadioButton radioButton3;
        private Button btnReportAnalisys;
        private Button btnGeneraScript;
        private SaveFileDialog _saveFileDialog1;
        private ISaveFileDialog saveFileDialog1;
        private CheckBox chkScriptSP;
        private CheckBox checkBox8;
        private System.ComponentModel.IContainer components;

        public Frm_report_default() {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            DS.reportparameter.ExtendedProperties["sort_by"] = "number";
            DS.reportparameter.ExtendedProperties["gridmaster"] = "report";
            openFileDialog1.Filter = "File di Crystal Report|*.rpt|Tutti i file|*.*";
            openFileDialog1.Title = "Selezione Report";
            //HelpForm.SetDenyNull(DS.modulereport.timeoutColumn,true);
            // verificare il comportamento della ExtProp "gridmaster"

            // il bottone Crystal Report (invisibile) non è gestito
            // di questo se ne occuperà Tommaso

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing) {
            if (disposing) {
                if (components != null) {
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
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_report_default));
            this.cmbModuli = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.chkScriptSP = new System.Windows.Forms.CheckBox();
            this.btnGeneraScript = new System.Windows.Forms.Button();
            this.btnReportAnalisys = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.gboxApplicazione = new System.Windows.Forms.GroupBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgrReportParameter = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbOrientVert = new System.Windows.Forms.RadioButton();
            this.rdbOrientOrizz = new System.Windows.Forms.RadioButton();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeRep = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbGroupName = new System.Windows.Forms.ComboBox();
            this._openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog1 = createOpenFileDialog(this._openFileDialog1);            
            this.images = new System.Windows.Forms.ImageList(this.components);
            this._saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog1 = createSaveFileDialog(this._saveFileDialog1);
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.DS = new report_default.vistaForm();
            this.MetaDataDetail.SuspendLayout();
            this.gboxApplicazione.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrReportParameter)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbModuli
            // 
            this.cmbModuli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModuli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModuli.Location = new System.Drawing.Point(125, 9);
            this.cmbModuli.Name = "cmbModuli";
            this.cmbModuli.Size = new System.Drawing.Size(775, 21);
            this.cmbModuli.TabIndex = 1;
            this.cmbModuli.Tag = "";
            this.cmbModuli.SelectedIndexChanged += new System.EventHandler(this.cmbModuli_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Modulo:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.checkBox8);
            this.MetaDataDetail.Controls.Add(this.chkScriptSP);
            this.MetaDataDetail.Controls.Add(this.btnGeneraScript);
            this.MetaDataDetail.Controls.Add(this.btnReportAnalisys);
            this.MetaDataDetail.Controls.Add(this.checkBox5);
            this.MetaDataDetail.Controls.Add(this.gboxApplicazione);
            this.MetaDataDetail.Controls.Add(this.textBox1);
            this.MetaDataDetail.Controls.Add(this.label5);
            this.MetaDataDetail.Controls.Add(this.groupBox3);
            this.MetaDataDetail.Controls.Add(this.checkBox1);
            this.MetaDataDetail.Controls.Add(this.groupBox2);
            this.MetaDataDetail.Controls.Add(this.groupBox1);
            this.MetaDataDetail.Controls.Add(this.txtFile);
            this.MetaDataDetail.Controls.Add(this.btnFile);
            this.MetaDataDetail.Controls.Add(this.txtDescrizione);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Controls.Add(this.txtNomeRep);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Location = new System.Drawing.Point(8, 61);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(903, 578);
            this.MetaDataDetail.TabIndex = 3;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Dettaglio prospetti";
            // 
            // chkScriptSP
            // 
            this.chkScriptSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkScriptSP.AutoSize = true;
            this.chkScriptSP.Location = new System.Drawing.Point(796, 260);
            this.chkScriptSP.Name = "chkScriptSP";
            this.chkScriptSP.Size = new System.Drawing.Size(68, 17);
            this.chkScriptSP.TabIndex = 20;
            this.chkScriptSP.Text = "script SP";
            this.chkScriptSP.UseVisualStyleBackColor = true;
            // 
            // btnGeneraScript
            // 
            this.btnGeneraScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraScript.Location = new System.Drawing.Point(796, 228);
            this.btnGeneraScript.Name = "btnGeneraScript";
            this.btnGeneraScript.Size = new System.Drawing.Size(99, 23);
            this.btnGeneraScript.TabIndex = 19;
            this.btnGeneraScript.Text = "Genera script";
            this.btnGeneraScript.UseVisualStyleBackColor = true;
            this.btnGeneraScript.Click += new System.EventHandler(this.btnGeneraScript_Click);
            // 
            // btnReportAnalisys
            // 
            this.btnReportAnalisys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReportAnalisys.Location = new System.Drawing.Point(796, 196);
            this.btnReportAnalisys.Name = "btnReportAnalisys";
            this.btnReportAnalisys.Size = new System.Drawing.Size(99, 23);
            this.btnReportAnalisys.TabIndex = 18;
            this.btnReportAnalisys.Text = "Analisi Report";
            this.btnReportAnalisys.UseVisualStyleBackColor = true;
            this.btnReportAnalisys.Click += new System.EventHandler(this.btnReportAnalisys_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(16, 155);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(56, 20);
            this.checkBox5.TabIndex = 17;
            this.checkBox5.Tag = "report.active:S:N";
            this.checkBox5.Text = "Attivo";
            // 
            // gboxApplicazione
            // 
            this.gboxApplicazione.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxApplicazione.Controls.Add(this.checkBox6);
            this.gboxApplicazione.Controls.Add(this.checkBox7);
            this.gboxApplicazione.Controls.Add(this.checkBox3);
            this.gboxApplicazione.Controls.Add(this.checkBox2);
            this.gboxApplicazione.Controls.Add(this.checkBox4);
            this.gboxApplicazione.Location = new System.Drawing.Point(719, 88);
            this.gboxApplicazione.Name = "gboxApplicazione";
            this.gboxApplicazione.Size = new System.Drawing.Size(176, 92);
            this.gboxApplicazione.TabIndex = 16;
            this.gboxApplicazione.TabStop = false;
            this.gboxApplicazione.Text = "Applicazione";
            // 
            // checkBox6
            // 
            this.checkBox6.Location = new System.Drawing.Point(8, 67);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(160, 19);
            this.checkBox6.TabIndex = 4;
            this.checkBox6.Tag = "report.flag_proceeds:S:N";
            this.checkBox6.Text = "Assegn. e Dot. Cassa";
            // 
            // checkBox7
            // 
            this.checkBox7.Location = new System.Drawing.Point(8, 48);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(160, 22);
            this.checkBox7.TabIndex = 3;
            this.checkBox7.Tag = "report.flag_credit:S:N";
            this.checkBox7.Text = "Assegn. e Dot. Crediti";
            // 
            // checkBox3
            // 
            this.checkBox3.Location = new System.Drawing.Point(8, 32);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(152, 16);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Tag = "report.flag_both:S:N";
            this.checkBox3.Text = "Competenza e cassa";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(66, 16);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 16);
            this.checkBox2.TabIndex = 1;
            this.checkBox2.Tag = "report.flag_comp:S:N";
            this.checkBox2.Text = "Competenza";
            // 
            // checkBox4
            // 
            this.checkBox4.Location = new System.Drawing.Point(8, 16);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(104, 16);
            this.checkBox4.TabIndex = 0;
            this.checkBox4.Tag = "report.flag_cash:S:N";
            this.checkBox4.Text = "Cassa";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(663, 157);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.Tag = "report.timeout";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(551, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 15;
            this.label5.Text = "Time Out (minuti)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Location = new System.Drawing.Point(719, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(176, 40);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Formato Carta";
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(94, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(66, 16);
            this.radioButton3.TabIndex = 2;
            this.radioButton3.Tag = "report.papersize:ASK";
            this.radioButton3.Text = "Custom";
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(48, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(40, 16);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "report.papersize:A4";
            this.radioButton2.Text = "A4";
            // 
            // radioButton1
            // 
            this.radioButton1.Location = new System.Drawing.Point(8, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(48, 16);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Tag = "report.papersize:A3";
            this.radioButton1.Text = "A3";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.Location = new System.Drawing.Point(423, 157);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 20);
            this.checkBox1.TabIndex = 9;
            this.checkBox1.Tag = "report.webvisible:S:N";
            this.checkBox1.Text = "Visibile da Web";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.dgrReportParameter);
            this.groupBox2.Location = new System.Drawing.Point(8, 180);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(767, 390);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametri prospetti";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(663, 80);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Tag = "delete";
            this.btnDelete.Text = "Elimina";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(663, 48);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Tag = "edit.single";
            this.btnEdit.Text = "Modifica";
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(663, 16);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(96, 23);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Tag = "insert.single";
            this.btnInsert.Text = "Inserisci";
            // 
            // dgrReportParameter
            // 
            this.dgrReportParameter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrReportParameter.DataMember = "";
            this.dgrReportParameter.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrReportParameter.Location = new System.Drawing.Point(8, 16);
            this.dgrReportParameter.Name = "dgrReportParameter";
            this.dgrReportParameter.Size = new System.Drawing.Size(639, 366);
            this.dgrReportParameter.TabIndex = 0;
            this.dgrReportParameter.Tag = "reportparameter.default.single";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rdbOrientVert);
            this.groupBox1.Controls.Add(this.rdbOrientOrizz);
            this.groupBox1.Location = new System.Drawing.Point(719, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 40);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Orientamento";
            // 
            // rdbOrientVert
            // 
            this.rdbOrientVert.Location = new System.Drawing.Point(8, 16);
            this.rdbOrientVert.Name = "rdbOrientVert";
            this.rdbOrientVert.Size = new System.Drawing.Size(80, 16);
            this.rdbOrientVert.TabIndex = 1;
            this.rdbOrientVert.Tag = "report.orientation:P";
            this.rdbOrientVert.Text = "Verticale";
            // 
            // rdbOrientOrizz
            // 
            this.rdbOrientOrizz.Location = new System.Drawing.Point(88, 16);
            this.rdbOrientOrizz.Name = "rdbOrientOrizz";
            this.rdbOrientOrizz.Size = new System.Drawing.Size(80, 16);
            this.rdbOrientOrizz.TabIndex = 0;
            this.rdbOrientOrizz.Tag = "report.orientation:L";
            this.rdbOrientOrizz.Text = "Orizzontale";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.Location = new System.Drawing.Point(112, 80);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(599, 20);
            this.txtFile.TabIndex = 5;
            this.txtFile.Tag = "report.filename";
            // 
            // btnFile
            // 
            this.btnFile.Location = new System.Drawing.Point(8, 80);
            this.btnFile.Name = "btnFile";
            this.btnFile.Size = new System.Drawing.Size(96, 23);
            this.btnFile.TabIndex = 4;
            this.btnFile.Text = "File";
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescrizione.Location = new System.Drawing.Point(112, 48);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(599, 20);
            this.txtDescrizione.TabIndex = 3;
            this.txtDescrizione.Tag = "report.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrizione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNomeRep
            // 
            this.txtNomeRep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNomeRep.Location = new System.Drawing.Point(112, 16);
            this.txtNomeRep.Name = "txtNomeRep";
            this.txtNomeRep.Size = new System.Drawing.Size(599, 20);
            this.txtNomeRep.TabIndex = 1;
            this.txtNomeRep.Tag = "report.reportname";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(21, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Gruppo:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbGroupName
            // 
            this.cmbGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGroupName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGroupName.Location = new System.Drawing.Point(127, 36);
            this.cmbGroupName.Name = "cmbGroupName";
            this.cmbGroupName.Size = new System.Drawing.Size(773, 21);
            this.cmbGroupName.TabIndex = 7;
            this.cmbGroupName.Tag = "";
            this.cmbGroupName.SelectedIndexChanged += new System.EventHandler(this.cmbGroupName_SelectedIndexChanged);
            // 
            // openFileDialog1
            // 
            //this.openFileDialog1.Filter = "File di Crystal Report|*.rpt|Tutti i file|*.*";
            //this.openFileDialog1.Title = "Selezione Report";
            // 
            // images
            // 
            this.images.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images.ImageStream")));
            this.images.TransparentColor = System.Drawing.Color.Transparent;
            this.images.Images.SetKeyName(0, "");
            this.images.Images.SetKeyName(1, "");
            this.images.Images.SetKeyName(2, "");
            this.images.Images.SetKeyName(3, "");
            this.images.Images.SetKeyName(4, "");
            this.images.Images.SetKeyName(5, "");
            this.images.Images.SetKeyName(6, "");
            this.images.Images.SetKeyName(7, "");
            this.images.Images.SetKeyName(8, "");
            this.images.Images.SetKeyName(9, "");
            this.images.Images.SetKeyName(10, "");
            this.images.Images.SetKeyName(11, "");
            this.images.Images.SetKeyName(12, "");
            this.images.Images.SetKeyName(13, "");
            // 
            // checkBox8
            // 
            this.checkBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox8.Location = new System.Drawing.Point(201, 155);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(192, 20);
            this.checkBox8.TabIndex = 21;
            this.checkBox8.Tag = "report.print_rs:S:N";
            this.checkBox8.Text = "Stampa con Reporting Services";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            // 
            // Frm_report_default
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(921, 639);
            this.Controls.Add(this.MetaDataDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbModuli);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbGroupName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Frm_report_default";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmmodulereportparameter";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.gboxApplicazione.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrReportParameter)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QueryHelper QHS;

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Conn.GetQueryHelper();
            //riempie il combo moduli
            string command = "select distinct modulename from report";
            DataTable ModuliTable = Meta.Conn.SQLRunner(command);

            object O = "";
            cmbModuli.Items.Add(O);
            foreach (DataRow R in ModuliTable.Rows)
                cmbModuli.Items.Add(R["modulename"].ToString());

            //riempie il combo gruppi
            command = "select distinct groupname from report where (groupname is not null) ";
            DataTable GruppiTable = Meta.Conn.SQLRunner(command);


            cmbGroupName.Items.Add(O); // la riga vuota
            foreach (DataRow R in GruppiTable.Rows)
                cmbGroupName.Items.Add(R["groupname"].ToString());
            HelpForm.SetDenyNull(DS.report.Columns["webvisible"], true);

//			GetData.SetStaticFilter(DS.modulereport, 
//				"((modulename like '%-Ufficiali') OR (modulename like '%-Altre'))");
            HelpForm.SetDenyNull(DS.report.Columns["active"], true);
            HelpForm.SetDenyNull(DS.report.Columns["print_rs"], true);
            HelpForm.SetDenyNull(DS.report.Columns["flag_comp"], true);
            HelpForm.SetDenyNull(DS.report.Columns["flag_cash"], true);
            HelpForm.SetDenyNull(DS.report.Columns["flag_both"], true);
            HelpForm.SetDenyNull(DS.report.Columns["flag_credit"], true);
            HelpForm.SetDenyNull(DS.report.Columns["flag_proceeds"], true);
        }

        public void MetaData_AfterActivation() {
            cmbModuli.SelectedIndex = 0;
        }


        public void MetaData_AfterFill() {
            // abilita disabilita il combo Moduli
            if (Meta.InsertMode) {
                cmbModuli.Enabled = true;
            }
            else {
                cmbModuli.Enabled = false;
            }
            DataRow r = DS.report.Rows[0];

            cmbGroupName.SelectedIndex = indexOfString(cmbGroupName.Items, r["groupname"].ToString());
            cmbModuli.SelectedIndex = indexOfString(cmbModuli.Items, r["modulename"].ToString());
            //HelpForm.SetComboBoxValue(cmbModuli, r["modulename"].ToString());
        }

        int indexOfString(ComboBox.ObjectCollection list, string s) {
            for (int i = 0; i < list.Count; i++) {
                if (list[i].ToString().ToLower() == s.ToLower()) return i;
            }
            return -1;
        }

        public void MetaData_AfterClear() {
            cmbModuli.Enabled = true;
            cmbGroupName.SelectedIndex = 0;
            cmbModuli.SelectedIndex = 0;
            Meta.additional_search_condition = null;
        }

        public void MetaData_BeforePost() {
            if (Meta.InsertMode) {

                DataRow Curr = DS.report.Rows[0];
                object reportname = Curr["reportname"];
                foreach (DataRow Dett in DS.reportparameter.Rows) {
                    if (!Dett["reportname"].Equals(reportname))
                        Dett["reportname"] = reportname;
                }

            }

        }

        void calcolaSearchCondition() {
            string filter = null;
            if (cmbModuli.SelectedIndex > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("modulename", cmbModuli.SelectedItem));
            }
            if (cmbGroupName.SelectedIndex > 0) {
                filter = QHS.AppAnd(filter, QHS.CmpEq("groupname", cmbGroupName.SelectedItem));
            }
            Meta.additional_search_condition = filter;

        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R) {
            if (R == null) return;
            // valorizza il combo gruppo in fase edit
            if (T.TableName == "report") {

            }
        }

        private void btnFile_Click(object sender, System.EventArgs e) {
            if (Meta.IsEmpty) return;
            openFileDialog1.InitialDirectory = Meta.GetUsr("localreportdir").ToString();
            openFileDialog1.Title = "Scelta del file del Report";
            DialogResult res = openFileDialog1.ShowDialog(this);
            if (res != DialogResult.OK) return;

            txtFile.Text = System.IO.Path.GetFileName(openFileDialog1.FileName);
        }

        private void cmbModuli_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaSearchCondition();
            //Meta.DoMainCommand("mainsetsearch");
            //string filter = "(modulename="+
            //	QueryCreator.quotedstrvalue(cmbModuli.SelectedItem.ToString(),true)+
            //	")";
            //Meta.DoMainCommand("maindosearch.default."+filter);
            if (cmbModuli.SelectedIndex > 0) {
                MetaData.SetDefault(DS.report, "modulename", cmbModuli.SelectedItem.ToString());
            }
            else {
                MetaData.SetDefault(DS.report, "modulename", "");
            }
        }


        public void MetaData_AfterGetFormData() {
            CQueryHelper QHC = new CQueryHelper();
            DataRow CurrentRow = HelpForm.GetLastSelected(DS.report);
            if (Meta.InsertMode) {
                if (CurrentRow["modulename"].ToString().ToLower() != cmbModuli.SelectedItem.ToString().ToLower()) {
                    CurrentRow["modulename"] = cmbModuli.SelectedItem;
                }
            }
            if (CurrentRow["groupname"].ToString().ToLower() != cmbGroupName.SelectedItem.ToString().ToLower()) {
                CurrentRow["groupname"] = cmbGroupName.SelectedItem;
            }
            if (Meta.InsertMode) {
                string filtro = QHC.CmpNe("reportname", CurrentRow["reportname"]);
                foreach (DataRow r in DS.reportparameter.Select(filtro)) {
                    r["reportname"] = CurrentRow["reportname"];
                    //r.AcceptChanges();
                }
            }

        }



        private void cmbGroupName_SelectedIndexChanged(object sender, EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaSearchCondition();
            if (cmbGroupName.SelectedIndex > 0) {
                MetaData.SetDefault(DS.report, "groupname", cmbGroupName.SelectedItem.ToString());
            }
            else {
                MetaData.SetDefault(DS.report, "groupname", DBNull.Value);
            }
        }

        private void btnReportAnalisys_Click(object sender, EventArgs e) {
            ReportDocument ReportDoc = new ReportDocument();
            string path = Meta.GetUsr("localreportdir").ToString();
            string fName = txtFile.Text;
            string repFileName = Path.Combine(path, fName);

            try {
                // Open a temporary copy of the report.
                ReportDoc.Load(repFileName, OpenReportMethod.OpenReportByTempCopy);
            }
            catch (Exception ee) {
                QueryCreator.ShowException(this, "Impossibile caricare il report " + repFileName, ee);
                return;
            }
            //ReportDispatcherClass.setReportLogon(ReportDoc, Conn as Easy_DataAccess);

            CrystalDecisions.CrystalReports.Engine.Database crDatabase;
            CrystalDecisions.CrystalReports.Engine.Tables crTables;
            crDatabase = ReportDoc.Database;
            crTables = crDatabase.Tables;

            //Nome SP = spName;                              
            StringBuilder sbParam = new StringBuilder();
            foreach (ParameterFieldDefinition PF in ReportDoc.DataDefinition.ParameterFields) {
                //solo se appartengono al report in elaborazione
                if (PF.ReportName != "") continue;
                if (PF.IsLinked()) continue;
                //PF.Name @ayear
                //PF.ValueType Numberfield  StringField
                sbParam.AppendLine($"{PF.Name} type:{PF.ValueType}");
            }
            StringBuilder sbFormula = new StringBuilder();
            foreach (FormulaFieldDefinition FFD in ReportDoc.DataDefinition.FormulaFields) {
                sbFormula.AppendLine($"{FFD.FormulaName} kind: {FFD.ValueType}");

            }
            StringBuilder sbSP = new StringBuilder();
            sbSP.AppendLine($"Report principale:  {ReportDoc.FilePath}  Stored Procedure: {getSPName(ReportDoc)}");
            //mi scorro tutti i subreport (se presenti) del report principale
            ReportDefinition repDef = ReportDoc.ReportDefinition;
            foreach (Section sec in repDef.Sections) {
                foreach (ReportObject repObj in sec.ReportObjects) {
                    if (repObj.Kind != ReportObjectKind.SubreportObject) continue;
                    SubreportObject subRep = (SubreportObject) repObj;
                    ReportDocument SubReport = subRep.OpenSubreport(subRep.SubreportName);
                    sbSP.AppendLine($"SubReport: {SubReport.Name}  Stored Procedure: {getSPName(SubReport)}");
                    SubReport.Close();
                }
            }
            
            FrmShowParams p = new FrmShowParams(sbParam.ToString(), sbFormula.ToString(), sbSP.ToString(),Conn, getSPName(ReportDoc));
            ReportDoc.Close();
            createForm(p, this);
            p.Show(this);
            
        }

        static string getSPName(ReportDocument ReportDoc) {
            CrystalDecisions.CrystalReports.Engine.Database crDatabase;
            CrystalDecisions.CrystalReports.Engine.Tables crTables;
            crDatabase = ReportDoc.Database;
            crTables = crDatabase.Tables;
            string spName = "SP non trovata";
            //Imposto la location per tutte le tabelle del (sub)report in elaborazione
            foreach (CrystalDecisions.CrystalReports.Engine.Table crTable in crTables) {
                string[] pieces = crTable.Location.Split('.');
                spName = pieces[pieces.Length - 1];
                pieces = spName.Split(';');
                spName = pieces[0];
            }
            return spName;
        }

        private void btnGeneraScript_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            DialogResult r = saveFileDialog1.ShowDialog(this);
            string fileName = saveFileDialog1.FileName;
            if (r != DialogResult.OK) return;
            btnGeneraScript.Enabled = false;
            DataRow Curr = DS.report.Rows[0];
            string reportName = Curr["reportname"].ToString();
            DataTable tRep = Conn.CreateTableByName("report", "*");
            Conn.RUN_SELECT_INTO_TABLE(tRep, null, QHS.CmpEq("reportname", reportName), null, false);
            DataTable tRepPar = Conn.CreateTableByName("reportparameter", "*");
            Conn.RUN_SELECT_INTO_TABLE(tRepPar, "number", QHS.CmpEq("reportname", reportName), null, false);
            DataTable tRepAddPar = Conn.CreateTableByName("reportadditionalparam", "*");
            Conn.RUN_SELECT_INTO_TABLE(tRepAddPar, null,
                QHS.AppAnd(QHS.CmpEq("reportname", reportName), QHS.IsNull("stop")), null, false);
            Conn.AddExtendedProperty(tRep);
            Conn.AddExtendedProperty( tRepPar);
            Conn.AddExtendedProperty( tRepAddPar);

            DataSet D1 = new DataSet();
            D1.Tables.Add(tRep);
            GeneraSQL.GeneraStrutturaEDati(Conn, D1, fileName, false, UpdateType.insertAndUpdate,
                DataGenerationType.onlyData, true);
            D1 = new DataSet();
            D1.Tables.Add(tRepPar);
            GeneraSQL.GeneraStrutturaEDati(Conn, D1, fileName, true, UpdateType.insertAndUpdate,
                DataGenerationType.onlyData, true);
            D1 = new DataSet();
            D1.Tables.Add(tRepAddPar);
            GeneraSQL.GeneraStrutturaEDati(Conn, D1, fileName, true, UpdateType.onlyInsert, DataGenerationType.onlyData, true);

            Dictionary<string,bool> spAdded = new Dictionary<string, bool>();
            if (chkScriptSP.Checked) {
                ReportDocument ReportDoc = new ReportDocument();
                string path = Meta.GetUsr("localreportdir").ToString();
                string fName = txtFile.Text;
                string repFileName = Path.Combine(path, fName);

                try {
                    // Open a temporary copy of the report.
                    ReportDoc.Load(repFileName, OpenReportMethod.OpenReportByTempCopy);
                    StreamWriter sw = new StreamWriter(fileName, true);
                    string spName = getSPName(ReportDoc);
                    sw.Write(GeneraSQL.scriptOneSP(Conn, spName));
                    spAdded.Add(spName,true);


                    //mi scorro tutti i subreport (se presenti) del report principale
                    ReportDefinition repDef = ReportDoc.ReportDefinition;
                    foreach (Section sec in repDef.Sections) {
                        foreach (ReportObject repObj in sec.ReportObjects) {
                            if (repObj.Kind != ReportObjectKind.SubreportObject) continue;
                            SubreportObject subRep = (SubreportObject) repObj;                            
                            ReportDocument SubReport = subRep.OpenSubreport(subRep.SubreportName);
                            spName = getSPName(SubReport);
                            if (!spAdded.ContainsKey(spName) && spName!="stampa_logo") {
                                spAdded.Add(spName, true);
                                sw.Write(GeneraSQL.scriptOneSP(Conn, spName));
                            }
                            SubReport.Close();
                        }
                    }
                    ReportDoc.Close();
                    sw.Flush();
                    sw.Close();
                    sw.Dispose();
                }
                catch (Exception ee) {
                    QueryCreator.ShowException(this, "Impossibile caricare il report " + repFileName, ee);
                }
            }
            
            show(this, "File salvato in " + fileName, "Avviso");
            btnGeneraScript.Enabled = true;

        }
    }
}
