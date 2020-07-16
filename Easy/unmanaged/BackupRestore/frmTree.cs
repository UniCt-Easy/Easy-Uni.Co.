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
using System.Data;
using metadatalibrary;

namespace BackupRestore//BackupRestore//
{
	/// <summary>
	/// Summary description for frmTree.
	/// </summary>
	public class frmTree : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TreeView treeDB;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.ImageList icons;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtSelezione;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lblFile;

		private DataAccess Conn;
		public frmTree(DataAccess Conn, string[,] radici)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			this.Conn=Conn;
			SetTreeView(radici);
		}

		private void SetTreeView(string[,] radici) {
			if (radici==null) return;
			for (int i=0; i < radici.GetLength(1); i++) {
				TreeNode root = new TreeNode(@radici[0,i]+" ("+radici[1,i]+" MB)", 
					1, 0, GetChildren(radici[0,i].Remove(radici[0,i].Length-1,1)));
				//elimino \ finale
				root.Tag=radici[0,i].Remove(radici[0,i].Length-1,1);
				treeDB.Nodes.Add(root);
			}
		}

		private TreeNode[] GetChildren(string parent) {
			string cmd = "use master execute master.dbo.xp_dirtree N'"+parent+"', 1, 1";
			DataTable T = Conn.SQLRunner(cmd);
			if (T==null) return null;
			TreeNode[] children = new TreeNode[T.Rows.Count];
			int index=0;
			foreach (DataRow R in T.Rows) {
				int imgindex=1;
				int selectindex=0;
				//E' un file?
				if (R["file"].ToString()=="1") {
					imgindex=2;
					selectindex=2;
				}
				TreeNode node = new TreeNode(R["subdirectory"].ToString(),
					imgindex,selectindex);
				//se Ë una cartella ggiungo un nodo dummy
				if (R["file"].ToString()=="0") {
					node.Nodes.Add(new TreeNode("dummy"));
				}
				node.Tag=parent+treeDB.PathSeparator+R["subdirectory"].ToString();
				children[index]=node;
				index++;
			}
			return children;
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmTree));
			this.treeDB = new System.Windows.Forms.TreeView();
			this.icons = new System.Windows.Forms.ImageList(this.components);
			this.btnOK = new System.Windows.Forms.Button();
			this.btnAnnulla = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtSelezione = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.lblFile = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// treeDB
			// 
			this.treeDB.ImageList = this.icons;
			this.treeDB.Location = new System.Drawing.Point(8, 8);
			this.treeDB.Name = "treeDB";
			this.treeDB.Size = new System.Drawing.Size(424, 264);
			this.treeDB.Sorted = true;
			this.treeDB.TabIndex = 0;
			this.treeDB.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeDB_AfterSelect);
			this.treeDB.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeDB_BeforeExpand);
			// 
			// icons
			// 
			this.icons.ImageSize = new System.Drawing.Size(16, 16);
			this.icons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("icons.ImageStream")));
			this.icons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(152, 368);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			// 
			// btnAnnulla
			// 
			this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnAnnulla.Location = new System.Drawing.Point(248, 368);
			this.btnAnnulla.Name = "btnAnnulla";
			this.btnAnnulla.TabIndex = 2;
			this.btnAnnulla.Text = "Annulla";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 312);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "File selezionato";
			// 
			// txtSelezione
			// 
			this.txtSelezione.Location = new System.Drawing.Point(96, 280);
			this.txtSelezione.Name = "txtSelezione";
			this.txtSelezione.Size = new System.Drawing.Size(336, 20);
			this.txtSelezione.TabIndex = 4;
			this.txtSelezione.Text = "";
			this.txtSelezione.TextChanged += new System.EventHandler(this.txtSelezione_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 282);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "Nome file";
			// 
			// lblFile
			// 
			this.lblFile.Location = new System.Drawing.Point(96, 312);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(336, 48);
			this.lblFile.TabIndex = 6;
			// 
			// frmTree
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnAnnulla;
			this.ClientSize = new System.Drawing.Size(438, 396);
			this.Controls.Add(this.lblFile);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtSelezione);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnAnnulla);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.treeDB);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "frmTree";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Seleziona supporto";
			this.ResumeLayout(false);

		}
		#endregion

		private void treeDB_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e) {
			TreeNode selNode = e.Node;
			//Sui nodi radici non faccio nulla in quanto gi‡ valorizzati con i figli
			if (selNode.Parent==null) return;
			selNode.Nodes.Clear();
			selNode.Nodes.AddRange(GetChildren(selNode.Tag.ToString()));
		}

		private void treeDB_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e) {
			TreeNode selNode = e.Node;
			string selezione=selNode.Tag.ToString();
			if (selNode.ImageIndex!=2) {
				//ho selezionato una cartella
				if (!selezione.EndsWith(@"\")) selezione+=@"\";
				selezione+=txtSelezione.Text;
			}
			else {
				//selezionato un file
				txtSelezione.Text=selNode.Text;
			}
			lblFile.Text=selezione;
		}

		private void txtSelezione_TextChanged(object sender, System.EventArgs e) {
			lblFile.Text="";
			if (treeDB.SelectedNode!=null) {				
				lblFile.Text=treeDB.SelectedNode.Tag.ToString();
				if (!lblFile.Text.EndsWith(@"\")) lblFile.Text+=@"\";
			}
			lblFile.Text+=txtSelezione.Text;
		}
	
		public string SupportoSelezionato {
			get {
				return lblFile.Text;
			}
		}
	}
}
