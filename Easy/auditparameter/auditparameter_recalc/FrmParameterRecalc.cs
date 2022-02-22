
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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metadatalibrary;
using metaeasylibrary;
using System.Data;

namespace auditparameter_recalc//parameterrecalc//
{
	/// <summary>
	/// Summary description for FrmParameterRecalc.
	/// </summary>
	public class Frm_auditparameter_recalc : MetaDataForm
	{
		private System.Windows.Forms.ListView TableList;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListView OpList;
		private System.Windows.Forms.Button btnAllTables;
		private System.Windows.Forms.Button btnAllOperations;
		private System.Windows.Forms.Button btnEsegui;
		private System.Windows.Forms.Button btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		MetaData Meta;
		public /*Rana:parameterrecalc.*/vistaForm DS;
		private System.Windows.Forms.Button btDeselezionaTabelle;
		DataAccess Conn;

		public Frm_auditparameter_recalc()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		public void MetaData_AfterLink(){
			Meta = MetaData.GetMetaData(this);
			Conn = Meta.Conn;
			GetData.SetSorting(DS.auditparameter,"tablename");
		}

		public void MetaData_AfterActivation(){
			DataTable TT= Conn.SQLRunner("SELECT DISTINCT objectname  from customobject where isreal='S' order by objectname");
			string prec=null;
			foreach(DataRow R in TT.Rows){
				string curr = R["objectname"].ToString();
				if (prec!=curr) {
					TableList.Items.Add(curr);
					prec=curr;
				}
			}
		}

		public void MetaData_AfterClear(){
			Text="Ricostruzione stored procedure (Business Logic)";
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Inserimento");
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("Modifica");
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Eliminazione");
            this.TableList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.OpList = new System.Windows.Forms.ListView();
            this.btnAllTables = new System.Windows.Forms.Button();
            this.btnAllOperations = new System.Windows.Forms.Button();
            this.btnEsegui = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.DS = new auditparameter_recalc.vistaForm();
            this.btDeselezionaTabelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
            this.SuspendLayout();
            // 
            // TableList
            // 
            this.TableList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.TableList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TableList.CheckBoxes = true;
            this.TableList.Location = new System.Drawing.Point(16, 32);
            this.TableList.Name = "TableList";
            this.TableList.Size = new System.Drawing.Size(584, 384);
            this.TableList.TabIndex = 0;
            this.TableList.UseCompatibleStateImageBehavior = false;
            this.TableList.View = System.Windows.Forms.View.List;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tabelle";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(622, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Operazioni";
            // 
            // OpList
            // 
            this.OpList.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.OpList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OpList.CheckBoxes = true;
            this.OpList.FullRowSelect = true;
            listViewItem1.StateImageIndex = 0;
            listViewItem1.Tag = "I";
            listViewItem2.StateImageIndex = 0;
            listViewItem2.Tag = "U";
            listViewItem3.StateImageIndex = 0;
            listViewItem3.Tag = "D";
            this.OpList.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.OpList.Location = new System.Drawing.Point(622, 56);
            this.OpList.Name = "OpList";
            this.OpList.Size = new System.Drawing.Size(136, 96);
            this.OpList.TabIndex = 3;
            this.OpList.UseCompatibleStateImageBehavior = false;
            this.OpList.View = System.Windows.Forms.View.List;
            // 
            // btnAllTables
            // 
            this.btnAllTables.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAllTables.Location = new System.Drawing.Point(328, 432);
            this.btnAllTables.Name = "btnAllTables";
            this.btnAllTables.Size = new System.Drawing.Size(112, 23);
            this.btnAllTables.TabIndex = 4;
            this.btnAllTables.Text = "Seleziona tutte";
            this.btnAllTables.Click += new System.EventHandler(this.btnAllTables_Click);
            // 
            // btnAllOperations
            // 
            this.btnAllOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAllOperations.Location = new System.Drawing.Point(638, 160);
            this.btnAllOperations.Name = "btnAllOperations";
            this.btnAllOperations.Size = new System.Drawing.Size(104, 23);
            this.btnAllOperations.TabIndex = 5;
            this.btnAllOperations.Text = "Seleziona tutte";
            this.btnAllOperations.Click += new System.EventHandler(this.btnAllOperations_Click);
            // 
            // btnEsegui
            // 
            this.btnEsegui.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEsegui.Location = new System.Drawing.Point(646, 248);
            this.btnEsegui.Name = "btnEsegui";
            this.btnEsegui.Size = new System.Drawing.Size(75, 23);
            this.btnEsegui.TabIndex = 6;
            this.btnEsegui.Text = "Esegui";
            this.btnEsegui.Click += new System.EventHandler(this.btnEsegui_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(646, 288);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Chiudi";
            // 
            // DS
            // 
            this.DS.DataSetName = "vistaForm";
            this.DS.EnforceConstraints = false;
            this.DS.Locale = new System.Globalization.CultureInfo("en-US");
            // 
            // btDeselezionaTabelle
            // 
            this.btDeselezionaTabelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btDeselezionaTabelle.Location = new System.Drawing.Point(136, 432);
            this.btDeselezionaTabelle.Name = "btDeselezionaTabelle";
            this.btDeselezionaTabelle.Size = new System.Drawing.Size(120, 23);
            this.btDeselezionaTabelle.TabIndex = 8;
            this.btDeselezionaTabelle.Text = "Deseleziona tutte";
            this.btDeselezionaTabelle.Click += new System.EventHandler(this.btDeselezionaTabelle_Click);
            // 
            // Frm_auditparameter_recalc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(768, 469);
            this.Controls.Add(this.btDeselezionaTabelle);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEsegui);
            this.Controls.Add(this.btnAllOperations);
            this.Controls.Add(this.btnAllTables);
            this.Controls.Add(this.OpList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TableList);
            this.Name = "Frm_auditparameter_recalc";
            this.Text = "FrmParameterRecalc";
            ((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnAllTables_Click(object sender, System.EventArgs e) {
			foreach(ListViewItem LI in TableList.Items){
				LI.Checked=true;
			}
		}

		private void btnAllOperations_Click(object sender, System.EventArgs e) {
			foreach(ListViewItem LI in OpList.Items){
				LI.Checked=true;
			}
		}

		private void btDeselezionaTabelle_Click(object sender, System.EventArgs e) {
			foreach(ListViewItem LI in TableList.Items){
				LI.Checked=false;
			}
		
		}

		private void btnEsegui_Click(object sender, System.EventArgs e) {
            string filterrule = Meta.GetSys("filterrule").ToString();
            RecalcProgress RC = new RecalcProgress(Conn, TableList, OpList, filterrule);
			RC.Show();
			RC.Run();
			
		}



	}
}
