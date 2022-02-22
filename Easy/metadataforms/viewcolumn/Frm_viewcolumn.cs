
/*
Easy
Copyright (C) 2022 Università degli Studi di Catania (www.unict.it)
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
using System.Windows.Forms;
using metadatalibrary;



namespace viewcolumn//viewcolumn//
{
	/// <summary>
	/// Summary description for frmviewcolumn.
	/// </summary>
	public class Frm_viewcolumn : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button CancButton;
		private System.Windows.Forms.Button OkButton;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		public /*Rana:viewcolumn.*/vistaForm DS;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ComboBox comboCol;
		private System.Windows.Forms.ComboBox comboTab;
		MetaData Meta;
		DataRow SourceRow;
		DataTable AllowedColumns;
		DataTable SourceTable;
		string MainTable;
		private System.Windows.Forms.ComboBox comboColName;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_viewcolumn()
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
			this.CancButton = new System.Windows.Forms.Button();
			this.OkButton = new System.Windows.Forms.Button();
			this.comboCol = new System.Windows.Forms.ComboBox();
			this.DS = new /*Rana:viewcolumn.*/vistaForm();
			this.comboTab = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboColName = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// CancButton
			// 
			this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancButton.Location = new System.Drawing.Point(96, 224);
			this.CancButton.Name = "CancButton";
			this.CancButton.Size = new System.Drawing.Size(72, 23);
			this.CancButton.TabIndex = 29;
			this.CancButton.Text = "Cancel";
			// 
			// OkButton
			// 
			this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OkButton.Location = new System.Drawing.Point(200, 224);
			this.OkButton.Name = "OkButton";
			this.OkButton.Size = new System.Drawing.Size(72, 23);
			this.OkButton.TabIndex = 28;
			this.OkButton.Tag = "mainsave";
			this.OkButton.Text = "Ok";
			// 
			// comboCol
			// 
			this.comboCol.DataSource = this.DS.columntypes;
			this.comboCol.DisplayMember = "field";
			this.comboCol.Location = new System.Drawing.Point(128, 64);
			this.comboCol.Name = "comboCol";
			this.comboCol.Size = new System.Drawing.Size(200, 21);
			this.comboCol.TabIndex = 27;
			this.comboCol.Tag = "viewcolumn.realcolumn";
			this.comboCol.ValueMember = "field";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// comboTab
			// 
			this.comboTab.DataSource = this.DS.customobject;
			this.comboTab.DisplayMember = "objectname";
			this.comboTab.Location = new System.Drawing.Point(128, 32);
			this.comboTab.Name = "comboTab";
			this.comboTab.Size = new System.Drawing.Size(200, 21);
			this.comboTab.TabIndex = 26;
			this.comboTab.Tag = "viewcolumn.realtable";
			this.comboTab.ValueMember = "objectname";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 64);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(104, 23);
			this.label3.TabIndex = 25;
			this.label3.Text = "Column name";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 32);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(96, 23);
			this.label4.TabIndex = 24;
			this.label4.Text = "Real table name";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(112, 23);
			this.label2.TabIndex = 22;
			this.label2.Text = "Column Name (view)";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(128, 32);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(208, 20);
			this.textBox1.TabIndex = 21;
			this.textBox1.Tag = "viewcolumn.objectname";
			this.textBox1.Text = "";
			this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 23);
			this.label1.TabIndex = 20;
			this.label1.Text = "View Name";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.comboCol);
			this.groupBox1.Controls.Add(this.comboTab);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Location = new System.Drawing.Point(8, 112);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(352, 100);
			this.groupBox1.TabIndex = 30;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Location from where info is taken";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboColName);
			this.groupBox2.Controls.Add(this.textBox1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Location = new System.Drawing.Point(8, 8);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(352, 96);
			this.groupBox2.TabIndex = 31;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "View Field";
			// 
			// comboColName
			// 
			this.comboColName.DataSource = this.DS.columntypesprincipale;
			this.comboColName.DisplayMember = "field";
			this.comboColName.Location = new System.Drawing.Point(128, 64);
			this.comboColName.Name = "comboColName";
			this.comboColName.Size = new System.Drawing.Size(208, 21);
			this.comboColName.TabIndex = 23;
			this.comboColName.Tag = "viewcolumn.colname";
			this.comboColName.ValueMember = "field";
			// 
			// frmviewcolumn
			// 
			this.AcceptButton = this.OkButton;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.CancButton;
			this.ClientSize = new System.Drawing.Size(376, 269);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.CancButton);
			this.Controls.Add(this.OkButton);
			this.Name = "frmviewcolumn";
			this.Text = "frmviewcolumn";
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public void MetaData_AfterLink()
		{
			Meta = MetaData.GetMetaData(this);
			
			SourceRow =	 Meta.SourceRow;
			SourceTable = SourceRow.Table;
			MainTable= SourceTable.DataSet.Tables["customobject"].Rows[0]["realtable"].ToString();
			DataAccess.SetTableForReading(DS.columntypesprincipale,"columntypes");
			string tableview=   SourceRow["objectname"].ToString();
			GetData.CacheTable(DS.columntypesprincipale,
				"(tablename='"+tableview+"')",null,true);
			AllowedColumns = Meta.Conn.CallSP("sp_depends",
				new object[]{tableview}).Tables[0];
			//eliminato il filtro (isreal='S') per poter visualizzare anche le view
			GetData.CacheTable(DS.customobject,null,"objectname",true);
		}

		public void MetaData_BeforeActivation(){
			//Elimina dal combo Column Name i campi già classificati
			foreach (DataRow Present in SourceTable.Select()){
				if (Present["colname"].ToString()=="") continue;
				if (Present==SourceRow) continue;
				string filter = "(tablename='"+Present["objectname"]+"')AND"+
					 "(field='"+Present["colname"]+"')";

				DataRow []todelete = DS.columntypesprincipale.Select(filter);
				if (todelete.Length>0) todelete[0].Delete();
			}
			DS.columntypesprincipale.AcceptChanges();

			//Elimina dal combo RealTable le tabelle non facenti parte della vista
			DataRow [] AllTB=DS.customobject.Select("objectname<>''");
			foreach(DataRow TB in AllTB){
				//if (TB["objectname"].ToString()=="") continue;
				string filter = "(name='dbo."+TB["objectname"]+"')";
				if (AllowedColumns.Select(filter).Length>0) continue;
				TB.Delete();
				TB.AcceptChanges();
			}

		}


		public void MetaData_AfterRowSelect(DataTable T, DataRow R){			
			if ((T.TableName == "customobject")&&(R!=null)) FilterColumns(R);
			if ((T.TableName == "columntypesprincipale")&&(R!=null)) SetDefaultField();
		}

		public void MetaData_AfterFill(){
			if (!Meta.InsertMode)return;

			DataRow CurrRow=DS.viewcolumn.Rows[0];
			if (SourceRow["realtable"].ToString()=="") {
				SourceRow["realtable"]= MainTable;
				HelpForm.SetComboBoxValue(comboTab, MainTable);
			}

			SetDefaultField();

		}

		void SetDefaultField(){
			//Imposta il realcolumn di defaut ove presente uno uguale al columnname
			HelpForm.SetComboBoxValue(comboCol, comboColName.SelectedValue.ToString());

		}

		void FilterColumns(DataRow CustomObj){
			string filtertable= "(name='dbo."+CustomObj["objectname"].ToString()+"')";
			DataTable ComboT= (DataTable) comboCol.DataSource;
			string CurrColName = DS.Tables["viewcolumn"].Rows[0]["colname"].ToString();
			DataRow []All= ComboT.Select("field<>''");
			foreach (DataRow Col in All){

				string filterfield= "(column='"+Col["field"].ToString()+"')";
				string filter = filtertable+"AND"+filterfield;
				string excludeclassified= "(colname<>'"+CurrColName+"')AND"+
					"(realtable='"+Col["tablename"].ToString()+"')AND"+
					"(realcolumn='"+Col["field"].ToString()+"')";
				if (SourceTable.Select(excludeclassified).Length>0){
					Col.Delete();
					continue;
				}

				//esclude le chiavi delle tabelle secondarie
				if (comboTab.SelectedValue.ToString() != MainTable){
					if (Col["iskey"].ToString().ToUpper()=="S"){
						Col.Delete();
						continue;
					}					
				}

				if (AllowedColumns.Select(filter).Length>0) continue;
				Col.Delete();			
			}
			DS.columntypes.AcceptChanges();
			
		}


	}
}
