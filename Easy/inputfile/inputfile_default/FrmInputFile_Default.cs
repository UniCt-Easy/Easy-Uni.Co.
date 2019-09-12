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

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using System.IO;
using System.Data.OleDb;

namespace inputfile_default
{
	/// <summary>
	/// Summary description for FrmInputFile_Default.
	/// </summary>
	public class FrmInputFile_Default : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ComboBox comboBox1;
		public inputfile_default.vistaForm DS;
		private System.Windows.Forms.TextBox txtPar1;
		private System.Windows.Forms.TextBox txtPar2;
		private System.Windows.Forms.TextBox txtPar3;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Label labpar1;
		private System.Windows.Forms.Label labpar2;
		private System.Windows.Forms.Label labpar3;
		private System.Windows.Forms.Button btnTest;
		MetaData Meta;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FrmInputFile_Default()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.label1 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.DS = new inputfile_default.vistaForm();
			this.labpar1 = new System.Windows.Forms.Label();
			this.txtPar1 = new System.Windows.Forms.TextBox();
			this.txtPar2 = new System.Windows.Forms.TextBox();
			this.labpar2 = new System.Windows.Forms.Label();
			this.txtPar3 = new System.Windows.Forms.TextBox();
			this.labpar3 = new System.Windows.Forms.Label();
			this.btnTest = new System.Windows.Forms.Button();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Codice";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 24);
			this.textBox1.Name = "textBox1";
			this.textBox1.TabIndex = 1;
			this.textBox1.Tag = "inputfile.idinputfile";
			this.textBox1.Text = "";
			// 
			// textBox2
			// 
			this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox2.Location = new System.Drawing.Point(128, 24);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(448, 20);
			this.textBox2.TabIndex = 3;
			this.textBox2.Tag = "inputfile.title";
			this.textBox2.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(128, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Descrizione";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(8, 56);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(96, 23);
			this.button1.TabIndex = 4;
			this.button1.Tag = "manage.filetype.default";
			this.button1.Text = "Tipo file";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.filetype;
			this.comboBox1.DisplayMember = "title";
			this.comboBox1.Location = new System.Drawing.Point(128, 56);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(240, 21);
			this.comboBox1.TabIndex = 5;
			this.comboBox1.Tag = "inputfile.idfiletype";
			this.comboBox1.ValueMember = "idfiletype";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// labpar1
			// 
			this.labpar1.Location = new System.Drawing.Point(8, 96);
			this.labpar1.Name = "labpar1";
			this.labpar1.Size = new System.Drawing.Size(320, 16);
			this.labpar1.TabIndex = 6;
			this.labpar1.Tag = "filetype.labelpar1";
			this.labpar1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPar1
			// 
			this.txtPar1.Location = new System.Drawing.Point(336, 88);
			this.txtPar1.Name = "txtPar1";
			this.txtPar1.Size = new System.Drawing.Size(240, 20);
			this.txtPar1.TabIndex = 7;
			this.txtPar1.Tag = "inputfile.param1";
			this.txtPar1.Text = "";
			// 
			// txtPar2
			// 
			this.txtPar2.Location = new System.Drawing.Point(336, 112);
			this.txtPar2.Name = "txtPar2";
			this.txtPar2.Size = new System.Drawing.Size(240, 20);
			this.txtPar2.TabIndex = 9;
			this.txtPar2.Tag = "inputfile.param2";
			this.txtPar2.Text = "";
			// 
			// labpar2
			// 
			this.labpar2.Location = new System.Drawing.Point(8, 120);
			this.labpar2.Name = "labpar2";
			this.labpar2.Size = new System.Drawing.Size(320, 16);
			this.labpar2.TabIndex = 8;
			this.labpar2.Tag = "filetype.labelpar2";
			this.labpar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtPar3
			// 
			this.txtPar3.Location = new System.Drawing.Point(336, 136);
			this.txtPar3.Name = "txtPar3";
			this.txtPar3.Size = new System.Drawing.Size(240, 20);
			this.txtPar3.TabIndex = 11;
			this.txtPar3.Tag = "inputfile.param3";
			this.txtPar3.Text = "";
			// 
			// labpar3
			// 
			this.labpar3.Location = new System.Drawing.Point(8, 136);
			this.labpar3.Name = "labpar3";
			this.labpar3.Size = new System.Drawing.Size(320, 16);
			this.labpar3.TabIndex = 10;
			this.labpar3.Tag = "filetype.labelpar3";
			this.labpar3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnTest
			// 
			this.btnTest.Location = new System.Drawing.Point(216, 160);
			this.btnTest.Name = "btnTest";
			this.btnTest.Size = new System.Drawing.Size(168, 23);
			this.btnTest.TabIndex = 12;
			this.btnTest.Text = "Prova a leggere il file";
			this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(8, 240);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(576, 216);
			this.dataGrid1.TabIndex = 13;
			this.dataGrid1.Tag = "inputfilecolumn.default.default";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(8, 208);
			this.button2.Name = "button2";
			this.button2.TabIndex = 14;
			this.button2.Tag = "edit.default";
			this.button2.Text = "Modifica";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(104, 208);
			this.button3.Name = "button3";
			this.button3.TabIndex = 15;
			this.button3.Tag = "insert.default";
			this.button3.Text = "Insert";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(200, 208);
			this.button4.Name = "button4";
			this.button4.TabIndex = 16;
			this.button4.Tag = "delete";
			this.button4.Text = "Elimina";
			// 
			// FrmInputFile_Default
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 469);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.btnTest);
			this.Controls.Add(this.txtPar3);
			this.Controls.Add(this.labpar3);
			this.Controls.Add(this.txtPar2);
			this.Controls.Add(this.labpar2);
			this.Controls.Add(this.txtPar1);
			this.Controls.Add(this.labpar1);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label1);
			this.Name = "FrmInputFile_Default";
			this.Text = "FrmInputFile_Default";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();
		}

		public void MetaData_AfterRowSelect(DataTable T, DataRow R){
			if (T.TableName=="filetype"){
				if (R==null) 
					EnableDisableTextBox("");
				else
					EnableDisableTextBox(R["idfiletype"].ToString());
			}
		}
		void EnableDisableTextBox(string idfiletype){
			DataRow R=null;
			if (idfiletype!=""){
				DataRow []RR=DS.filetype.Select(QHC.CmpEq("idfiletype", idfiletype));
				if (RR.Length>0) R=RR[0];
			}
			if (R==null){
				txtPar1.Visible=false;
				labpar1.Visible=false;
				txtPar2.Visible=false;
				labpar2.Visible=false;
				txtPar3.Visible=false;
				labpar3.Visible=false;
				return;
			}
			bool flagvisible=(R["labelpar1"].ToString()!="");
			txtPar1.Visible=flagvisible;
			labpar1.Visible=flagvisible;
			labpar1.Text=R["labelpar1"].ToString();

			flagvisible=(R["labelpar2"].ToString()!="");
			txtPar2.Visible=flagvisible;
			labpar2.Visible=flagvisible;
			labpar2.Text=R["labelpar2"].ToString();
			
			flagvisible=(R["labelpar3"].ToString()!="");
			txtPar3.Visible=flagvisible;
			labpar3.Visible=flagvisible;
			labpar3.Text=R["labelpar3"].ToString();
			
		}

		private void btnTest_Click(object sender, System.EventArgs e) {
			if (Meta.IsEmpty) return;
			DialogResult Res= openFileDialog1.ShowDialog(this);
			if (Res!=DialogResult.OK) return;
			Meta.GetFormData(true);
			DataRow Curr= DS.inputfile.Rows[0];

			string filename= openFileDialog1.FileName;
			FileInfo FI = new FileInfo(filename);
			string filenamenoext= Path.GetFileNameWithoutExtension(filename);
			string dir = Path.GetDirectoryName(filename);
			string filtertype = QHC.CmpEq("idfiletype", Curr["idfiletype"]);
			DataRow CurrType=DS.filetype.Select(filtertype)[0];
			string connect= CurrType["connectionstring"].ToString();
			connect= connect.Replace("%<filenamenoext>%",filenamenoext);
			connect= connect.Replace("%<dir>%",dir);
			connect= connect.Replace("%<filename>%",filename);
			if (Curr["param1"].ToString()!="")	connect= connect.Replace("%<par1>%",dir);
			if (Curr["param2"].ToString()!="")	connect= connect.Replace("%<par2>%",dir);
			if (Curr["param3"].ToString()!="")	connect= connect.Replace("%<par3>%",dir);

			string query= CurrType["querystring"].ToString();
			query= query.Replace("%<filenamenoext>%",filenamenoext);
			query= query.Replace("%<dir>%",dir);
			query= query.Replace("%<filename>%",filename);
			if (Curr["param1"].ToString()!="")	query= query.Replace("%<par1>%",dir);
			if (Curr["param2"].ToString()!="")	query= query.Replace("%<par2>%",dir);
			if (Curr["param3"].ToString()!="")	query= query.Replace("%<par3>%",dir);

			DataSet D= new DataSet();
			try {
				OleDbConnection OleConn =new OleDbConnection(connect);
				OleConn.Open();
				//DataTable T = OleConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[]{null,null,null,null});
				//exportclass.DataTableToExcel(T,false);
				OleDbDataAdapter OleAdapter= new OleDbDataAdapter(query,OleConn);
				
				OleAdapter.Fill(D);
				OleConn.Close();
			}
			catch (Exception E){
				QueryCreator.ShowException(E);
				return;
			}
			if (D.Tables.Count==0) {
				MessageBox.Show("Non ho letto nulla!");
				return;
			}
			exportclass.DataTableToExcel(D.Tables[0],false);
		}

	}
}
