
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
using System.Collections;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using metadatalibrary;
using generaSQL;
using report_default;

namespace exportfunction_default//expstoredprocedure//
{
	/// <summary>
	/// Summary description for frmexpstoredprocedure.
	/// </summary>
	public class frmexpstoredprocedure : MetaDataForm
	{
        CQueryHelper QHC;
        QueryHelper QHS;
        //aggiungere campi lastmoduser, lastmodtimestamp
		public System.Windows.Forms.GroupBox MetaDataDetail;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnInsert;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtDescrizione;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGrid dgrExpSPParam;
		private System.Windows.Forms.ComboBox cmbFormato;
		private System.Windows.Forms.TextBox txtNomeProc;
		private System.ComponentModel.IContainer components;
		public /*Rana:expstoredprocedure.*/vistaForm DS;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox1;
        private ImageList images;
        private CheckBox checkBox1;
        private TextBox textBox7;
        private Label label20;
        private Label label6;
        private ComboBox cmbModuli;
        private Button btnGeneraScript;
        private SaveFileDialog _saveFileDialog1;
        private ISaveFileDialog saveFileDialog1;
        private Button btnAnalisiSp;
        private CheckBox chkScriptSP;
        private CheckBox checkBox5;
        MetaData Meta;

		public frmexpstoredprocedure()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			DS.exportfunction.ExtendedProperties["sort_by"]="procedurename";
			DS.exportfunctionparam.ExtendedProperties["sort_by"]="number";
//			DS.delete_expstoredprocedureformat.ExtendedProperties["sort_by"]="colnumber";
			DS.exportfunctionparam.ExtendedProperties["gridmaster"]="exportfunction";
//			DS.delete_expstoredprocedureformat.ExtendedProperties["gridmaster"]="expstoredprocedure";
			HelpForm.SetDenyNull(DS.exportfunction.Columns["timeout"],true);
		    HelpForm.SetDenyNull(DS.exportfunction.Columns["active"], true);
            saveFileDialog1 = createSaveFileDialog(_saveFileDialog1);

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmexpstoredprocedure));
            this.MetaDataDetail = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.chkScriptSP = new System.Windows.Forms.CheckBox();
            this.btnAnalisiSp = new System.Windows.Forms.Button();
            this.btnGeneraScript = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.dgrExpSPParam = new System.Windows.Forms.DataGrid();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.DS = new exportfunction_default.vistaForm();
            this.txtDescrizione = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNomeProc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.images = new System.Windows.Forms.ImageList(this.components);
            this.cmbModuli = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this._saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.MetaDataDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrExpSPParam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // MetaDataDetail
            // 
            this.MetaDataDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MetaDataDetail.Controls.Add(this.checkBox5);
            this.MetaDataDetail.Controls.Add(this.chkScriptSP);
            this.MetaDataDetail.Controls.Add(this.btnAnalisiSp);
            this.MetaDataDetail.Controls.Add(this.btnGeneraScript);
            this.MetaDataDetail.Controls.Add(this.textBox7);
            this.MetaDataDetail.Controls.Add(this.label20);
            this.MetaDataDetail.Controls.Add(this.checkBox1);
            this.MetaDataDetail.Controls.Add(this.textBox1);
            this.MetaDataDetail.Controls.Add(this.label5);
            this.MetaDataDetail.Controls.Add(this.groupBox2);
            this.MetaDataDetail.Controls.Add(this.label4);
            this.MetaDataDetail.Controls.Add(this.cmbFormato);
            this.MetaDataDetail.Controls.Add(this.txtDescrizione);
            this.MetaDataDetail.Controls.Add(this.label3);
            this.MetaDataDetail.Controls.Add(this.txtNomeProc);
            this.MetaDataDetail.Controls.Add(this.label2);
            this.MetaDataDetail.Location = new System.Drawing.Point(12, 36);
            this.MetaDataDetail.Name = "MetaDataDetail";
            this.MetaDataDetail.Size = new System.Drawing.Size(907, 499);
            this.MetaDataDetail.TabIndex = 22;
            this.MetaDataDetail.TabStop = false;
            this.MetaDataDetail.Text = "Dettaglio procedure";
            // 
            // checkBox5
            // 
            this.checkBox5.Location = new System.Drawing.Point(561, 55);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(56, 20);
            this.checkBox5.TabIndex = 35;
            this.checkBox5.Tag = "exportfunction.active:S:N";
            this.checkBox5.Text = "Attivo";
            // 
            // chkScriptSP
            // 
            this.chkScriptSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkScriptSP.AutoSize = true;
            this.chkScriptSP.Location = new System.Drawing.Point(803, 210);
            this.chkScriptSP.Name = "chkScriptSP";
            this.chkScriptSP.Size = new System.Drawing.Size(68, 17);
            this.chkScriptSP.TabIndex = 34;
            this.chkScriptSP.Text = "script SP";
            this.chkScriptSP.UseVisualStyleBackColor = true;
            // 
            // btnAnalisiSp
            // 
            this.btnAnalisiSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnalisiSp.Location = new System.Drawing.Point(802, 152);
            this.btnAnalisiSp.Name = "btnAnalisiSp";
            this.btnAnalisiSp.Size = new System.Drawing.Size(99, 23);
            this.btnAnalisiSp.TabIndex = 33;
            this.btnAnalisiSp.Text = "Analisi SP";
            this.btnAnalisiSp.UseVisualStyleBackColor = true;
            this.btnAnalisiSp.Click += new System.EventHandler(this.btnAnalisiSp_Click);
            // 
            // btnGeneraScript
            // 
            this.btnGeneraScript.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeneraScript.Location = new System.Drawing.Point(803, 181);
            this.btnGeneraScript.Name = "btnGeneraScript";
            this.btnGeneraScript.Size = new System.Drawing.Size(99, 23);
            this.btnGeneraScript.TabIndex = 32;
            this.btnGeneraScript.Text = "Genera script";
            this.btnGeneraScript.UseVisualStyleBackColor = true;
            this.btnGeneraScript.Click += new System.EventHandler(this.btnGeneraScript_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(417, 97);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(89, 20);
            this.textBox7.TabIndex = 30;
            this.textBox7.Tag = "exportfunction.fileextension";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(414, 81);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(92, 13);
            this.label20.TabIndex = 31;
            this.label20.Text = "Estensione del file";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(419, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Tag = "exportfunction.webvisible:S:N";
            this.checkBox1.Text = "Visibile Web";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(419, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(80, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.Tag = "exportfunction.timeout";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(419, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 13;
            this.label5.Text = "Time Out (minuti)";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.dgrExpSPParam);
            this.groupBox2.Location = new System.Drawing.Point(0, 136);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(797, 357);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametri procedure";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(695, 74);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(96, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Tag = "delete";
            this.btnDelete.Text = "Elimina";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(695, 45);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(96, 23);
            this.btnEdit.TabIndex = 12;
            this.btnEdit.Tag = "edit.single";
            this.btnEdit.Text = "Modifica";
            // 
            // btnInsert
            // 
            this.btnInsert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsert.Location = new System.Drawing.Point(695, 16);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(96, 23);
            this.btnInsert.TabIndex = 11;
            this.btnInsert.Tag = "insert.single";
            this.btnInsert.Text = "Inserisci";
            // 
            // dgrExpSPParam
            // 
            this.dgrExpSPParam.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgrExpSPParam.DataMember = "";
            this.dgrExpSPParam.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dgrExpSPParam.Location = new System.Drawing.Point(8, 16);
            this.dgrExpSPParam.Name = "dgrExpSPParam";
            this.dgrExpSPParam.Size = new System.Drawing.Size(681, 335);
            this.dgrExpSPParam.TabIndex = 0;
            this.dgrExpSPParam.Tag = "exportfunctionparam.default.single";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(19, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Formato:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbFormato
            // 
            this.cmbFormato.DataSource = this.DS.tmp_fileformat;
            this.cmbFormato.DisplayMember = "description";
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.Location = new System.Drawing.Point(123, 95);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(280, 21);
            this.cmbFormato.TabIndex = 5;
            this.cmbFormato.Tag = "exportfunction.fileformat";
            this.cmbFormato.ValueMember = "fileformat";
            this.cmbFormato.SelectedIndexChanged += new System.EventHandler(this.cmbFormato_SelectedIndexChanged);
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // txtDescrizione
            // 
            this.txtDescrizione.Location = new System.Drawing.Point(123, 45);
            this.txtDescrizione.Name = "txtDescrizione";
            this.txtDescrizione.Size = new System.Drawing.Size(280, 20);
            this.txtDescrizione.TabIndex = 2;
            this.txtDescrizione.Tag = "exportfunction.description";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Descrizione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNomeProc
            // 
            this.txtNomeProc.Location = new System.Drawing.Point(123, 19);
            this.txtNomeProc.Name = "txtNomeProc";
            this.txtNomeProc.Size = new System.Drawing.Size(280, 20);
            this.txtNomeProc.TabIndex = 1;
            this.txtNomeProc.Tag = "exportfunction.procedurename";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.images.Images.SetKeyName(14, "");
            this.images.Images.SetKeyName(15, "");
            this.images.Images.SetKeyName(16, "");
            this.images.Images.SetKeyName(17, "");
            this.images.Images.SetKeyName(18, "");
            this.images.Images.SetKeyName(19, "");
            this.images.Images.SetKeyName(20, "");
            this.images.Images.SetKeyName(21, "");
            this.images.Images.SetKeyName(22, "");
            this.images.Images.SetKeyName(23, "");
            this.images.Images.SetKeyName(24, "");
            // 
            // cmbModuli
            // 
            this.cmbModuli.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbModuli.DataSource = this.DS.tmp_modulename;
            this.cmbModuli.DisplayMember = "modulename";
            this.cmbModuli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbModuli.Location = new System.Drawing.Point(115, 9);
            this.cmbModuli.Name = "cmbModuli";
            this.cmbModuli.Size = new System.Drawing.Size(804, 21);
            this.cmbModuli.TabIndex = 32;
            this.cmbModuli.Tag = "exportfunction.modulename";
            this.cmbModuli.ValueMember = "modulename";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 33;
            this.label6.Text = "Modulo:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmexpstoredprocedure
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(939, 547);
            this.Controls.Add(this.cmbModuli);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.MetaDataDetail);
            this.Name = "frmexpstoredprocedure";
            this.Text = "frmexpstoredprocedure";
            this.MetaDataDetail.ResumeLayout(false);
            this.MetaDataDetail.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgrExpSPParam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        public void MetaData_BeforePost() {
            if (Meta.InsertMode)
            {

                DataRow Curr = DS.exportfunction.Rows[0];
                object procedurename = Curr["procedurename"];
                foreach (DataRow Dett in DS.exportfunctionparam.Rows)
                {
                    if (!Dett["procedurename"].Equals(procedurename))
                        Dett["procedurename"] = procedurename;
                }

            }

            }
    public void MetaData_AfterLink() {
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
            Meta.Conn.AddExtendedProperty(DS.exportfunctionparam);
			FillFileFormatTmpTable();
			FillModuleNameTmpTable();
		}

        public void MetaData_BeforeFill() {
            
        }


        public void MetaData_AfterFill() {
            // abilita disabilita il combo Moduli
            //if (Meta.InsertMode)
            //{
            //    cmbModuli.Enabled = true;
             
            //}
            //else
            //{
            //    cmbModuli.Enabled = false;
    
            //}
            //DataRow r = DS.exportfunction.Rows[0];
 
        }


        void FillModuleNameTmpTable() {
            string command = "select distinct modulename from exportfunction";
            DataTable ModuliTable = Meta.Conn.SQLRunner(command);

            GetData.MarkToAddBlankRow(DS.tmp_modulename);
            GetData.Add_Blank_Row(DS.tmp_modulename);
            foreach (DataRow R in ModuliTable.Rows)
            {
                DS.tmp_modulename.Rows.Add(new object[] {R["modulename"]});
                
            }
            PostData.MarkAsTemporaryTable(DS.tmp_modulename, false);
            DS.tmp_modulename.AcceptChanges();


        }

        void calcolaSearchCondition() {
            string filter = null;
            if (cmbModuli.SelectedIndex > 0)
            {
                filter = QHS.AppAnd(filter, QHS.CmpEq("modulename", cmbModuli.SelectedItem));
            }
           
            Meta.additional_search_condition = filter;

        }
        private void cmbModuli_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;
            calcolaSearchCondition();
 
        }


        private void cmbFormato_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (!Meta.DrawStateIsDone) return;

        }

        void FillFileFormatTmpTable() {
            GetData.MarkToAddBlankRow(DS.tmp_fileformat);
            GetData.Add_Blank_Row(DS.tmp_fileformat);
            DS.tmp_fileformat.Rows.Add(new object[]{"F","File a lunghezza fissa"});
			DS.tmp_fileformat.Rows.Add(new object[]{"T","File con campi separati da tabulatori"});
			DS.tmp_fileformat.Rows.Add(new object[]{"C","File con campi separati da virgole"});
			DS.tmp_fileformat.Rows.Add(new object[]{"E","Trasferimento a Microsoft Excel"});
      
            PostData.MarkAsTemporaryTable(DS.tmp_fileformat, false);
			DS.tmp_fileformat.AcceptChanges();


        }


      

        public void MetaData_AfterClear() {
          

            Meta.additional_search_condition = null;
        }

       
		public void MetaData_AfterGetFormData() {            
            //if (Meta.InsertMode)
            //{
            //    if (CurrentRow["modulename"].ToString().ToLower() != cmbModuli.SelectedItem.ToString().ToLower())
            //    {
            //        CurrentRow["modulename"] = cmbModuli.SelectedItem;
            //    }
            //}
            if (Meta.InsertMode) {
                DataRow CurrentRow = HelpForm.GetLastSelected(DS.exportfunction);
                string filtro = QHC.CmpNe("procedurename", CurrentRow["procedurename"]);
                foreach (DataRow r in DS.exportfunctionparam.Select(filtro)) {
                    r["procedurename"] = CurrentRow["procedurename"];
                    //r.AcceptChanges();
                }
            }

        }

        private void btnGeneraScript_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            DataAccess Conn = Meta.Conn;
            DialogResult r = saveFileDialog1.ShowDialog(this);
            string fileName = saveFileDialog1.FileName;
            if (r != DialogResult.OK) return;
            DataRow Curr = DS.exportfunction.Rows[0];
            string procedurename = Curr["procedurename"].ToString();
            DataTable tRep = Conn.CreateTableByName("exportfunction", "*");
            Conn.RUN_SELECT_INTO_TABLE(tRep, null, QHS.CmpEq("procedurename", procedurename), null, false);
            DataTable tRepPar = Conn.CreateTableByName("exportfunctionparam", "*");
            Conn.RUN_SELECT_INTO_TABLE(tRepPar, "number", QHS.CmpEq("procedurename", procedurename), null, false);
            Conn.AddExtendedProperty(tRep);
            Conn.AddExtendedProperty( tRepPar);

            DataSet D1 = new DataSet();
            D1.Tables.Add(tRep);
            GeneraSQL.GeneraStrutturaEDati(Conn, D1, fileName, false, UpdateType.insertAndUpdate,
                DataGenerationType.onlyData, true);
            D1 = new DataSet();
            D1.Tables.Add(tRepPar);
            GeneraSQL.GeneraStrutturaEDati(Conn, D1, fileName, true, UpdateType.insertAndUpdate,
                DataGenerationType.onlyData, true);

            if (chkScriptSP.Checked) {
                StreamWriter sw = new StreamWriter(fileName, true);
                sw.Write(GeneraSQL.scriptOneSP(Conn, procedurename));
                sw.Flush();
                sw.Close();
            }
            show(this, "File salvato in " + fileName, "Avviso");
        }

        private void btnAnalisiSp_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.SaveFormData();
            DataAccess Conn = Meta.Conn;
            DataRow Curr = DS.exportfunction.Rows[0];
            string procedurename = Curr["procedurename"].ToString();
            FrmShowParams f = new FrmShowParams(procedurename,Conn);
            createForm(f, this);
            f.ShowDialog(this);
        }
    }
}
