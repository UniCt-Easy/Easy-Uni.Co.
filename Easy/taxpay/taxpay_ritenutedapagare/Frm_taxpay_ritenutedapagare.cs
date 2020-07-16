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
using funzioni_configurazione;

namespace taxpay_ritenutedapagare//liquidazioneritenuta_dapagare//
{
	/// <summary>
	/// Summary description for frmliquidazioneritenuta_dapagare.
	/// </summary>
	public class Frm_taxpay_ritenutedapagare : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private DataAccess Conn;
		private System.Windows.Forms.Label lblTitolo;
		private System.Windows.Forms.Button btnChiudi;
		private System.Windows.Forms.DataGrid gridRitenuta;
		public vistaForm DS;
		private MetaData Meta;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtEsercizio;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.Label label2;
		private string filter_eserc="";

		public Frm_taxpay_ritenutedapagare()
		{
			InitializeComponent();
			lblTitolo.Text="Di seguito sono elencate tutte le ritenute "+
				"non ancora liquidate.";
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
			this.lblTitolo = new System.Windows.Forms.Label();
			this.btnChiudi = new System.Windows.Forms.Button();
			this.gridRitenuta = new System.Windows.Forms.DataGrid();
			this.DS = new taxpay_ritenutedapagare.vistaForm();
			this.label1 = new System.Windows.Forms.Label();
			this.txtEsercizio = new System.Windows.Forms.TextBox();
			this.txtData = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.gridRitenuta)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).BeginInit();
			this.SuspendLayout();
			// 
			// lblTitolo
			// 
			this.lblTitolo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblTitolo.Location = new System.Drawing.Point(16, 16);
			this.lblTitolo.Name = "lblTitolo";
			this.lblTitolo.Size = new System.Drawing.Size(376, 32);
			this.lblTitolo.TabIndex = 0;
			// 
			// btnChiudi
			// 
			this.btnChiudi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.btnChiudi.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnChiudi.Location = new System.Drawing.Point(168, 288);
			this.btnChiudi.Name = "btnChiudi";
			this.btnChiudi.TabIndex = 2;
			this.btnChiudi.Text = "Chiudi";
			// 
			// gridRitenuta
			// 
			this.gridRitenuta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gridRitenuta.CaptionVisible = false;
			this.gridRitenuta.DataMember = "";
			this.gridRitenuta.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.gridRitenuta.Location = new System.Drawing.Point(16, 80);
			this.gridRitenuta.Name = "gridRitenuta";
			this.gridRitenuta.Size = new System.Drawing.Size(376, 192);
			this.gridRitenuta.TabIndex = 3;
			// 
			// DS
			// 
			this.DS.DataSetName = "vistaForm";
			this.DS.Locale = new System.Globalization.CultureInfo("en-US");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Esercizio";
			// 
			// txtEsercizio
			// 
			this.txtEsercizio.Location = new System.Drawing.Point(80, 56);
			this.txtEsercizio.Name = "txtEsercizio";
			this.txtEsercizio.ReadOnly = true;
			this.txtEsercizio.Size = new System.Drawing.Size(40, 20);
			this.txtEsercizio.TabIndex = 5;
			this.txtEsercizio.Text = "";
			this.txtEsercizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtData
			// 
			this.txtData.Location = new System.Drawing.Point(256, 56);
			this.txtData.Name = "txtData";
			this.txtData.ReadOnly = true;
			this.txtData.Size = new System.Drawing.Size(72, 20);
			this.txtData.TabIndex = 7;
			this.txtData.Text = "";
			this.txtData.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(160, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 16);
			this.label2.TabIndex = 6;
			this.label2.Text = "Data contabile";
			// 
			// Frm_taxpay_ritenutedapagare
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnChiudi;
			this.ClientSize = new System.Drawing.Size(408, 326);
			this.Controls.Add(this.txtData);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtEsercizio);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.gridRitenuta);
			this.Controls.Add(this.btnChiudi);
			this.Controls.Add(this.lblTitolo);
			this.Name = "Frm_taxpay_ritenutedapagare";
			this.Text = "frmliquidazioneritenuta_dapagare";
			((System.ComponentModel.ISupportInitialize)(this.gridRitenuta)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.DS)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion
        QueryHelper QHS;
        CQueryHelper QHC;
        int esercizio;
		public void MetaData_AfterLink() {
			Meta=MetaData.GetMetaData(this);
			this.Conn=Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
			esercizio = (int) Meta.GetSys("esercizio");
            filter_eserc = QHS.CmpEq("ayear", esercizio);
			GetData.CacheTable(DS.tax, null, null, true);
			GetData.CacheTable(DS.taxsetup,filter_eserc,null,false);
			txtEsercizio.Text=esercizio.ToString();
			txtData.Text= ((DateTime)Meta.GetSys("datacontabile")).ToShortDateString();
            GetData.SetStaticFilter(DS.tax,QHS.AppAnd(QHS.IsNull("maintaxcode"),QHS.NullOrEq("active","S")));
				//((DateTime)Conn.sys["datacontabile"]).ToShortDateString();
		}

		public void MetaData_AfterClear() {
			this.Text="Ritenute non ancora liquidate";
		}

		public void MetaData_AfterFill() {
			this.Text="Ritenute non ancora liquidate";
		}

		public void MetaData_AfterActivation() {
			Esegui();
		}

		private bool ControllaConfRitenuta(DataRow RigaAutRiten) {
            int flag = CfgFn.GetNoNullInt32(RigaAutRiten["idexpirationkind"]);
            if ((flag & 0x08) != 0) {
                if (RigaAutRiten["expiringday"] == DBNull.Value) return false;
                if (CfgFn.GetNoNullInt32(RigaAutRiten["expiringday"]) < 1) return false;
            }

            if (RigaAutRiten["idexpirationkind"] == DBNull.Value) return false;
            int mesiperiodicita = CfgFn.GetNoNullInt32(RigaAutRiten["idexpirationkind"]);
            if ((mesiperiodicita < 1) || (mesiperiodicita > 12) || (mesiperiodicita == 5) ||
                (mesiperiodicita == 7) || (mesiperiodicita == 8) || (mesiperiodicita == 9) ||
                (mesiperiodicita == 10) || (mesiperiodicita == 11))
                return false;
          
            return true;
		}

        private int CalcolaPeriodo(int mese, int mesiperiodicita, DataRow RigaAutRiten) {
            if ( ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) == 0) &&
                    mese <= mesiperiodicita) return 1;
            int periodo = mese / mesiperiodicita;
            if (mese % mesiperiodicita > 0) periodo++;
            if ((CfgFn.GetNoNullInt32(RigaAutRiten["flag"]) & 0x08) != 0) {
                if (((DateTime)Meta.GetSys("datacontabile")).Day <=
                    CfgFn.GetNoNullInt32(RigaAutRiten["expiringday"]))
                       periodo--;
            }
            return periodo;
        }
		

		private bool CalcolaDateDaPeriodo (DataRow RigaAutRiten, out DateTime DataInizio,
			out DateTime DataFine) {

            int mesiperiodicita = CfgFn.GetNoNullInt32(RigaAutRiten["idexpirationkind"]);
			DataInizio = new DateTime(1,1,1);
			DataFine = new DateTime(1,1,1);
			if (12 % mesiperiodicita > 0) {
				// periodo non ammesso!
				return false;
			}
			int annocorrente = esercizio;//(int)Conn.sys["esercizio"];
			int mesecorrente = ((DateTime)Meta.GetSys("datacontabile")).Month;
				//((DateTime)Conn.sys["datacontabile"]).Month;
			int periodocorrente = CalcolaPeriodo(mesecorrente, mesiperiodicita, RigaAutRiten);
			if (periodocorrente < 1) { // vero se tipoperiodo=P e se il periodo Ë il primo dell'anno
				// si posiziona sull'ultimo periodo dell'anno precedente
				periodocorrente=12/mesiperiodicita;
				annocorrente--;
			}

			int meseinizioperiodo = mesiperiodicita*(periodocorrente-1)+1;
			int mesefineperiodo = mesiperiodicita*periodocorrente;
            DataInizio = new DateTime(annocorrente,1, 1);
			DataFine = new DateTime(annocorrente, mesefineperiodo, 
				DateTime.DaysInMonth(annocorrente, mesefineperiodo));

			return true;
		}

		private bool CallStoredProcedure(object codiceritenuta, DateTime datafine) {
			DataSet Out=Conn.CallSP("compute_taxpay", 
				new object[] {esercizio, codiceritenuta, datafine},true,-1);
			if (Out==null) return false;
			if (Out.Tables.Count==0) return false; //no answer from sp
			return (Out.Tables[0].Rows.Count>0);
		}
		
		private void Esegui() {
			DataSet DSrit=new DataSet();
			DataTable T=new DataTable("ritenutedapagare");
			DSrit.Tables.Add(T);
			T.Columns.Add("codice",typeof(string));
			T.Columns[0].Caption="Codice ritenuta";
			T.Columns.Add("descrizione",typeof(string));
			T.Columns[1].Caption="Descrizione";
			string filter_auto="";
			DateTime Datainizio, Datafine;
			foreach (DataRow R in DS.tax.Rows) {
                filter_auto = QHC.AppAnd(QHC.CmpEq("taxcode", R["taxcode"]), filter_eserc);
				DataRow[] Rauto=DS.taxsetup.Select(filter_auto);
				if (Rauto.Length==0) continue;
				if (!ControllaConfRitenuta(Rauto[0])) continue;
				Datainizio=new DateTime(1,1,1);
				Datafine=new DateTime(1,1,1);
				CalcolaDateDaPeriodo(Rauto[0],out Datainizio,out Datafine);
				if (!CallStoredProcedure(R["taxcode"], Datafine)) continue;
				DataRow Rrit=T.NewRow();
				Rrit["codice"]=R["taxref"];
				Rrit["descrizione"]=R["description"];
				T.Rows.Add(Rrit);
			}

			if (T==null || T.Rows.Count==0) {
				MessageBox.Show("Non ci sono ritenute da pagare","Informazioni",
					MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			HelpForm.SetDataGrid(gridRitenuta,T);
		}
	}
}
