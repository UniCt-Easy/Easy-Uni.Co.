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
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using metadatalibrary;
using Xceed.Grid;
using System.Collections.Generic;

namespace metaeasylibrary
{
	/// <summary>
	/// Summary description for FrmElencoErrori.
	/// </summary>
	public class FrmElencoErrori : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ImageList MyPics;
		private Xceed.Grid.GroupByRow groupByRow1;
		private Xceed.Grid.GroupByRow groupByRow2;
		private Xceed.Grid.GroupByRow groupByRow3;
		private Xceed.Grid.ColumnManagerRow columnManagerRow1;
		private Xceed.Grid.DataRow dataRowTemplate1;
        private Xceed.Grid.VisualGridElementStyle dataRowStyle1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.PictureBox Disegno;
		private System.Windows.Forms.Button btnAnnulla;
		private System.Windows.Forms.Button btnIgnora;
		private Xceed.Grid.GridControl gridX;
		private System.Windows.Forms.Button btnExcel;
		private System.Windows.Forms.Label label1;
		DataTable Dati;

        static FrmElencoErrori() {
        }

		public FrmElencoErrori(EasyProcedureMessageCollection Msgs)
		{
			//
			// Required for Windows Form Designer support
			//
            InitializeComponent();

            MetaData.SetColor(this, true);
			Disegno.Image= MyPics.Images[0];

            //if (Msgs.PostMsgs){
            //    labCheckType.Text="Controlli dopo il tentato salvataggio";
            //}
            //else {
            //    labCheckType.Text="Controlli prima del salvataggio";
            //}

			if (!Msgs.CanIgnore){
				btnIgnora.Visible=false;
				btnIgnora.Enabled=false;
				//Bitmap BM2 = new Bitmap("bin\\STOP.gif");
				Disegno.Image= MyPics.Images[1];
			}

			DataSet D = new DataSet("Nino");
			DataTable T = new DataTable("errori");
            T.Columns.Add("flagsystem", typeof(string));
            T.Columns["flagsystem"].Caption = "Note";
            T.Columns.Add("msg",typeof(string));
			T.Columns["msg"].Caption="Messaggio di errore";
			T.Columns.Add("codice",typeof(string));
			T.Columns["codice"].Caption="Codice";
			T.Columns.Add("id",typeof(string));
			T.Columns["id"].Caption="#";
            T.Columns.Add("kind", typeof(string));
            T.Columns["kind"].Caption = "Gravità";
            D.Tables.Add(T);

            Dictionary<string, bool> allm = new Dictionary<string, bool>();
			foreach (EasyProcedureMessage CM in Msgs){
                string m = ConvertCarriages(CM.LongMess);
                if (allm.ContainsKey(m + CM.AuditID)) continue;
                allm[m + CM.AuditID] = true;
				System.Data.DataRow R = T.NewRow();
                if (CM.flagsystem) {
                    R["flagsystem"] = "di SISTEMA";
                }
                else {
                    R["flagsystem"] = "NON di SISTEMA";
                }
				R["msg"]=m;
				R["kind"]= CM.ErrorType;
				R["codice"]=CM.AuditID;
                string prePost = CM.PostMsgs ? "post" : "pre";
                if (CM.TableName == null || CM.Operation == null || CM.EnforcementNumber == null) {
                    R["id"] = CM.CanIgnore?"System warning":"dberror";
                }
                else {
                    R["id"] = $"{prePost}/{CM.TableName}/{CM.Operation.Substring(0, 1)}/{CM.EnforcementNumber}";
                }
				T.Rows.Add(R);
			}

			gridX.BeginInit();
			gridX.SetDataBinding(D, "errori");
			gridX.SortedColumns.Add("kind", false);
			gridX.SortedColumns.Add("codice", true);
			foreach (DataColumn C in T.Columns) { 
				gridX.Columns[C.ColumnName].Title = C.Caption;
            }
            gridX.Columns["flagsystem"].Width = 60;
            gridX.Columns["id"].Width = 100;
            gridX.Columns["msg"].Width=500;
			gridX.Columns["kind"].Width=75;
			gridX.Columns["codice"].Width=75;
			gridX.Columns["id"].Width=100;
			gridX.EndInit();
			Dati= T;


		}

		string ConvertCarriages(string S){
			S = S.Replace("\r","\n");
			S = S.Replace("\n\n","\n");
			S = S.Replace("\n","\r\n");
			return S;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmElencoErrori));
            this.MyPics = new System.Windows.Forms.ImageList(this.components);
            this.Disegno = new System.Windows.Forms.PictureBox();
            this.btnAnnulla = new System.Windows.Forms.Button();
            this.btnIgnora = new System.Windows.Forms.Button();
            this.groupByRow1 = new Xceed.Grid.GroupByRow();
            this.groupByRow2 = new Xceed.Grid.GroupByRow();
            this.gridX = new Xceed.Grid.GridControl();
            this.dataRowTemplate1 = new Xceed.Grid.DataRow();
            this.dataRowStyle1 = new Xceed.Grid.VisualGridElementStyle();
            this.groupByRow3 = new Xceed.Grid.GroupByRow();
            this.columnManagerRow1 = new Xceed.Grid.ColumnManagerRow();
            this.btnExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Disegno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).BeginInit();
            this.SuspendLayout();
            // 
            // MyPics
            // 
            this.MyPics.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("MyPics.ImageStream")));
            this.MyPics.TransparentColor = System.Drawing.Color.Transparent;
            this.MyPics.Images.SetKeyName(0, "");
            this.MyPics.Images.SetKeyName(1, "");
            // 
            // Disegno
            // 
            this.Disegno.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Disegno.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Disegno.Image = ((System.Drawing.Image)(resources.GetObject("Disegno.Image")));
            this.Disegno.Location = new System.Drawing.Point(328, 336);
            this.Disegno.Name = "Disegno";
            this.Disegno.Size = new System.Drawing.Size(80, 72);
            this.Disegno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Disegno.TabIndex = 1;
            this.Disegno.TabStop = false;
            // 
            // btnAnnulla
            // 
            this.btnAnnulla.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAnnulla.Location = new System.Drawing.Point(104, 360);
            this.btnAnnulla.Name = "btnAnnulla";
            this.btnAnnulla.Size = new System.Drawing.Size(152, 23);
            this.btnAnnulla.TabIndex = 2;
            this.btnAnnulla.Text = "Non salvare";
            this.btnAnnulla.Click += new System.EventHandler(this.btnAnnulla_Click);
            // 
            // btnIgnora
            // 
            this.btnIgnora.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnIgnora.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnIgnora.Location = new System.Drawing.Point(448, 360);
            this.btnIgnora.Name = "btnIgnora";
            this.btnIgnora.Size = new System.Drawing.Size(200, 23);
            this.btnIgnora.TabIndex = 3;
            this.btnIgnora.Text = "Ignora i messaggi e salva lo stesso";
            this.btnIgnora.Click += new System.EventHandler(this.btnIgnora_Click);
            // 
            // groupByRow1
            // 
            this.groupByRow1.AllowDrop = true;
            this.groupByRow1.AutoHeightMode = Xceed.Grid.AutoHeightMode.Minimum;
            this.groupByRow1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupByRow1.CellBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.groupByRow1.CellFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupByRow1.NoGroupText = "Trascina qui l\'intestazione di una colonna per formare un raggruppamento";
            this.groupByRow1.Trimming = System.Drawing.StringTrimming.None;
            // 
            // groupByRow2
            // 
            this.groupByRow2.AllowDrop = true;
            this.groupByRow2.AutoHeightMode = Xceed.Grid.AutoHeightMode.Minimum;
            this.groupByRow2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupByRow2.CellBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.groupByRow2.CellFont = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold);
            this.groupByRow2.NoGroupText = "Trascina qui l\'intestazione di una colonna per formare un raggruppamento";
            this.groupByRow2.Trimming = System.Drawing.StringTrimming.None;
            // 
            // gridX
            // 
            this.gridX.AllowCellNavigation = true;
            this.gridX.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridX.ClipPartialLine = false;
            this.gridX.DataRowTemplate = this.dataRowTemplate1;
            this.gridX.DataRowTemplateStyles.Add(this.dataRowStyle1);
            this.gridX.FixedHeaderRows.Add(this.groupByRow3);
            this.gridX.FixedHeaderRows.Add(this.columnManagerRow1);
            this.gridX.InactiveSelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.gridX.InactiveSelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.gridX.Location = new System.Drawing.Point(8, 24);
            this.gridX.Name = "gridX";
            this.gridX.ReadOnly = true;
            // 
            // 
            // 
            this.gridX.RowSelectorPane.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(102)))));
            this.gridX.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            this.gridX.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            this.gridX.SelectionMode = System.Windows.Forms.SelectionMode.One;
            this.gridX.Size = new System.Drawing.Size(932, 304);
            this.gridX.TabIndex = 4;
            this.gridX.Trimming = System.Drawing.StringTrimming.None;
            this.gridX.WordWrap = true;
            this.gridX.AddingDataRow += new Xceed.Grid.AddingDataRowEventHandler(this.gridX_AddingDataRow);
            // 
            // dataRowTemplate1
            // 
            this.dataRowTemplate1.Height = 64;
            // 
            // dataRowStyle1
            // 
            this.dataRowStyle1.ClipPartialLine = false;
            this.dataRowStyle1.Trimming = System.Drawing.StringTrimming.None;
            this.dataRowStyle1.VerticalAlignment = Xceed.Grid.VerticalAlignment.Center;
            this.dataRowStyle1.WordWrap = true;
            // 
            // groupByRow3
            // 
            this.groupByRow3.AutoHeightMode = Xceed.Grid.AutoHeightMode.AllContent;
            this.groupByRow3.CellBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(102)))));
            // 
            // 
            // 
            this.groupByRow3.RowSelector.BackColor = System.Drawing.SystemColors.ControlDark;
            this.groupByRow3.Visible = false;
            // 
            // btnExcel
            // 
            this.btnExcel.Location = new System.Drawing.Point(280, 0);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(208, 23);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "Esporta l\'elenco degli errori in Excel";
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(780, 392);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "powered by MetaDataLibrary";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmElencoErrori
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(948, 413);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.gridX);
            this.Controls.Add(this.btnIgnora);
            this.Controls.Add(this.btnAnnulla);
            this.Controls.Add(this.Disegno);
            this.Name = "FrmElencoErrori";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elenco errori ed avvertimenti";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmElencoErrori_Closing);
            this.Load += new System.EventHandler(this.FrmElencoErrori_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Disegno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataRowTemplate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.columnManagerRow1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		bool CanClose=false;
		private void FrmElencoErrori_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
			e.Cancel=!CanClose;
		}

		private void btnAnnulla_Click(object sender, System.EventArgs e) {
			CanClose=true;
		}

		private void btnIgnora_Click(object sender, System.EventArgs e) {
			CanClose=true;
		}

		private void btnExcel_Click(object sender, System.EventArgs e) {
			if (Dati!=null) 
				exportclass.DataTableToExcel(Dati,true,null,null);
		}

		private void FrmElencoErrori_Load(object sender, System.EventArgs e) {
		
		}

        private void gridX_AddingDataRow(object sender, AddingDataRowEventArgs e) {

        }
	}
}
