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
using metadatalibrary;
using System.Data;

namespace customdirectrel//customdirectrel//
{
	/// <summary>
	/// Summary description for FrmCustomDirectRel.
	/// </summary>
	public class Frm_customdirectrel : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		public /*Rana:customdirectrel.*/vistaForm DS;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.CheckBox chkCanNavigateFromParentToChild;
		private System.Windows.Forms.CheckBox chkCanInsertFromParentToChild;
		private System.Windows.Forms.CheckBox chkCustomFilterForNavigation;
		private System.Windows.Forms.CheckBox chkCustomFilterForInsert;
		private System.Windows.Forms.CheckBox chkCustomDefaults;
		MetaData Meta;
		private System.Windows.Forms.ComboBox cmbEdit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Frm_customdirectrel()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			DataAccess.SetTableForReading(DS.fromtable,"customobject");
			DataAccess.SetTableForReading(DS.totable,"customobject");

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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.DS = new /*Rana:customdirectrel.*/vistaForm();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.cmbEdit = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkCustomDefaults = new System.Windows.Forms.CheckBox();
			this.chkCustomFilterForInsert = new System.Windows.Forms.CheckBox();
			this.chkCustomFilterForNavigation = new System.Windows.Forms.CheckBox();
			this.chkCanInsertFromParentToChild = new System.Windows.Forms.CheckBox();
			this.chkCanNavigateFromParentToChild = new System.Windows.Forms.CheckBox();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Tabella origine della relazione";
			// 
			// comboBox1
			// 
			this.comboBox1.DataSource = this.DS.fromtable;
			this.comboBox1.DisplayMember = "objectname";
			this.comboBox1.Location = new System.Drawing.Point(8, 48);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(336, 21);
			this.comboBox1.TabIndex = 1;
			this.comboBox1.Tag = "customdirectrel.fromtable";
			this.comboBox1.ValueMember = "objectname";
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(360, 32);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(328, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Tabella Destinazione della relazione";
			// 
			// comboBox2
			// 
			this.comboBox2.DataSource = this.DS.totable;
			this.comboBox2.DisplayMember = "objectname";
			this.comboBox2.Location = new System.Drawing.Point(360, 48);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(336, 21);
			this.comboBox2.TabIndex = 3;
			this.comboBox2.Tag = "customdirectrel.fromtable";
			this.comboBox2.ValueMember = "objectname";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 88);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(360, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Descrizione che deve apparire nel menu di navigazione ";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 104);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(320, 20);
			this.textBox1.TabIndex = 5;
			this.textBox1.Tag = "customdirectrel.description";
			this.textBox1.Text = "";
			// 
			// cmbEdit
			// 
			this.cmbEdit.Location = new System.Drawing.Point(8, 144);
			this.cmbEdit.Name = "cmbEdit";
			this.cmbEdit.Size = new System.Drawing.Size(200, 21);
			this.cmbEdit.TabIndex = 6;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(360, 16);
			this.label4.TabIndex = 7;
			this.label4.Text = "Edit Type del form della tabella Destinazione da aprire";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(8, 168);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(504, 16);
			this.label5.TabIndex = 8;
			this.label5.Text = "Filtro aggiuntivo (oltre alla chiave esterna)  da applicare per la ricerca della " +
				"riga in Destinazione";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(8, 184);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(480, 20);
			this.textBox2.TabIndex = 9;
			this.textBox2.Tag = "customdirectrel.filter";
			this.textBox2.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkCustomDefaults);
			this.groupBox1.Controls.Add(this.chkCustomFilterForInsert);
			this.groupBox1.Controls.Add(this.chkCustomFilterForNavigation);
			this.groupBox1.Controls.Add(this.chkCanInsertFromParentToChild);
			this.groupBox1.Controls.Add(this.chkCanNavigateFromParentToChild);
			this.groupBox1.Location = new System.Drawing.Point(8, 224);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(680, 208);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Flag della relazione";
			// 
			// chkCustomDefaults
			// 
			this.chkCustomDefaults.Location = new System.Drawing.Point(16, 136);
			this.chkCustomDefaults.Name = "chkCustomDefaults";
			this.chkCustomDefaults.Size = new System.Drawing.Size(640, 48);
			this.chkCustomDefaults.TabIndex = 4;
			this.chkCustomDefaults.Text = "Chiama sp_getcustomrelationdefault(FromTable,ToTable,EditType) per ottenere i val" +
				"ori di default (fieldname, defaultvalue) in inserimento";
			// 
			// chkCustomFilterForInsert
			// 
			this.chkCustomFilterForInsert.Location = new System.Drawing.Point(16, 112);
			this.chkCustomFilterForInsert.Name = "chkCustomFilterForInsert";
			this.chkCustomFilterForInsert.Size = new System.Drawing.Size(648, 24);
			this.chkCustomFilterForInsert.TabIndex = 3;
			this.chkCustomFilterForInsert.Text = "Chiama sp_getcustomrelationfilter(FromTable,ToTable,EditType,\'I\') per ottenere fi" +
				"ltro custom supplementare in inserimento";
			// 
			// chkCustomFilterForNavigation
			// 
			this.chkCustomFilterForNavigation.Location = new System.Drawing.Point(16, 80);
			this.chkCustomFilterForNavigation.Name = "chkCustomFilterForNavigation";
			this.chkCustomFilterForNavigation.Size = new System.Drawing.Size(648, 24);
			this.chkCustomFilterForNavigation.TabIndex = 2;
			this.chkCustomFilterForNavigation.Text = "Chiama sp_getcustomrelationfilter(FromTable,ToTable,EditType,\'S\') per ottenere fi" +
				"ltro custom supplementare in navigazione";
			// 
			// chkCanInsertFromParentToChild
			// 
			this.chkCanInsertFromParentToChild.Location = new System.Drawing.Point(16, 48);
			this.chkCanInsertFromParentToChild.Name = "chkCanInsertFromParentToChild";
			this.chkCanInsertFromParentToChild.Size = new System.Drawing.Size(392, 24);
			this.chkCanInsertFromParentToChild.TabIndex = 1;
			this.chkCanInsertFromParentToChild.Text = "E\' possibile inserire un elemento di destinazione a partire dall\'origine";
			// 
			// chkCanNavigateFromParentToChild
			// 
			this.chkCanNavigateFromParentToChild.Location = new System.Drawing.Point(16, 16);
			this.chkCanNavigateFromParentToChild.Name = "chkCanNavigateFromParentToChild";
			this.chkCanNavigateFromParentToChild.Size = new System.Drawing.Size(408, 24);
			this.chkCanNavigateFromParentToChild.TabIndex = 0;
			this.chkCanNavigateFromParentToChild.Text = "E\' possibile navigare dall\'origine alla destinazione";
			// 
			// FrmCustomDirectRel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(704, 445);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.cmbEdit);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.comboBox1);
			this.Controls.Add(this.label1);
			this.Name = "FrmCustomDirectRel";
			this.Text = "FrmCustomDirectRel";
			this.Load += new System.EventHandler(this.FrmCustomDirectRel_Load);
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion



		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
		}


		void FillEditType(DataRow R){
			cmbEdit.Items.Clear();
			MetaData ToMeta = MetaData.GetMetaData(this, R["totable"].ToString());
			foreach (object OO in ToMeta.EditTypes){
				cmbEdit.Items.Add(OO.ToString());
			}
		}

		public void MetaData_AfterFill(){
			DataRow Curr = HelpForm.GetLastSelected(DS.customdirectrel);
			if (Curr==null) return;
			
			int flagval= (int)DS.customdirectrel.Rows[0]["flag"];
			if ((flagval & 1)== 1)
					chkCanInsertFromParentToChild.Checked = true;
			if ((flagval & 2)== 2)
					chkCanNavigateFromParentToChild.Checked = true;
			if ((flagval & 4)== 4)
					chkCustomFilterForNavigation.Checked = true;
			if ((flagval & 8)== 8)
					chkCustomFilterForInsert.Checked = true;
			if ((flagval & 16)==16)
					chkCustomDefaults.Checked = true;
		}

		public void MetaData_AfterGetFormData()
		{
			int flagins = 0; 
			if(chkCanInsertFromParentToChild.Checked)
				flagins = flagins + 1;
			if (chkCanNavigateFromParentToChild.Checked)
				flagins = flagins + 2;
			if (chkCustomFilterForNavigation.Checked)
				flagins = flagins + 4;
			if (chkCustomFilterForInsert.Checked)
				flagins = flagins + 8;
			if (chkCustomDefaults.Checked)
				flagins = flagins + 16;
			
			DataRow Curr = HelpForm.GetLastSelected(DS.customdirectrel);
			string filtro= "(tabellaorigine=" + QueryCreator.quotedstrvalue(Curr["fromtable"],true) +  "tabelladest=" + QueryCreator.quotedstrvalue(Curr["totable"],true) + ")";
		
		//	DataRow []DelChilds=DS.tipodocoperiva.Select(filtro,null,DataViewRowState.Deleted);
	

		}
		private void FrmCustomDirectRel_Load(object sender, System.EventArgs e)
		{
		
		}









	}
}
