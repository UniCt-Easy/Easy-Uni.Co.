
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
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace position_riepilogo{
	/// <summary>
    /// Summary description for Frm_position_riepilogo.
	/// </summary>
	public class Frm_position_riepilogo : MetaDataForm {
        public MetaData meta;
        public DataAccess Conn;
        bool first = true;
        DataTable qualifica;
        bool inChiusura = false;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabDiarieItalia;
		private System.Windows.Forms.TabPage tabRimborsospese;
		private System.Windows.Forms.TabPage tabRiduzionediaria;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGrid dtGridRimborso;
		private System.Windows.Forms.DataGrid dtGridRiduzione;
		public vistaForm DS;
		private System.Windows.Forms.ComboBox cmbClasse;
		private System.Windows.Forms.ComboBox cmbQualifica;
		private System.Windows.Forms.TextBox txtData;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtPercAnticipo;
		private System.Windows.Forms.TextBox txtImportoDiaria;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.DataGrid dtGridDiarie;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		DataRow GetQualificaRow(){
			return ((DataRowView)cmbQualifica.SelectedItem).Row;
		}

		public Frm_position_riepilogo()
		{
			InitializeComponent();
		}

		public void MetaData_AfterClear()
		{	
			if(first==true)
			{
				Qualifica_Change(GetQualificaRow());
				first=false;
                EseguiQuery();
			}
		}
        CQueryHelper QHC;
        QueryHelper QHS;
		public void MetaData_AfterLink() {
			meta =  MetaData.GetMetaData(this);
            QHC = new CQueryHelper();
            QHS = meta.Conn.GetQueryHelper();
			GetData.CacheTable(DS.position);

			txtData.Text=((DateTime)meta.GetSys("datacontabile")).ToShortDateString();
			
			qualifica = meta.Conn.RUN_SELECT("position","idposition,description,maxincomeclass","description",null,null,true);
			cmbQualifica.DataSource = qualifica;
			cmbQualifica.DisplayMember="description";
			cmbQualifica.ValueMember="idposition";

		}

		public void MetaData_AfterActivation()
		{
			Qualifica_Change(GetQualificaRow());
		}

		public void Qualifica_Change(DataRow R) {
			Conn = meta.Conn;
			if (R["maxincomeclass"]==DBNull.Value){
				cmbClasse.Items.Clear();
				return;
			}
			int valore = Convert.ToInt32(R["maxincomeclass"]);
			cmbClasse.Items.Clear();
			cmbClasse.Items.Add("Iniziale");
			cmbClasse.SelectedIndex=0;
			if (valore>=1){
				for (int i=0; i<valore; i++){
					cmbClasse.Items.Add(i+1);
					 
				}
			}
		}
		
		public void EseguiQuery()
		{
			if (first==true)
				return;
			object qualifica=cmbQualifica.SelectedValue;
			object classe=cmbClasse.SelectedIndex;
			object data=HelpForm.GetObjectFromString(typeof(DateTime),txtData.Text,null);
			if (data == null) data=DBNull.Value;
		    if (data != DBNull.Value) {
                if (((DateTime )data).Year<1000) data = DBNull.Value;
		    }
			txtImportoDiaria.Text ="";
			txtPercAnticipo.Text = "";
			DS.itinerationrefundruledetailview.Clear();
			DS.foreignallowanceruledetailview.Clear();
			DS.reductionruledetailview.Clear();
				
			if ((qualifica==DBNull.Value)|| ((int)classe==-1))
				return;

            object idallowancerule = meta.Conn.DO_READ_VALUE("allowancerule", QHS.CmpLe("start", data), "max(idallowancerule)");
            if (idallowancerule == null) return;
            string filter_diarieitalia = "";
            filter_diarieitalia = QHS.AppAnd(QHS.CmpEq("idposition", qualifica),
                QHS.Between(QHS.quote(classe), QHS.Field("minincomeclass"), QHS.Field("maxincomeclass")),
                QHS.CmpEq("idallowancerule", idallowancerule));

            DataTable TDiarieItalia;
            TDiarieItalia = Conn.RUN_SELECT("allowanceruledetailview", "amount,advancepercentage", "iddetail", filter_diarieitalia, "1", false);

            if (TDiarieItalia != null)
			{
                if (TDiarieItalia.Rows.Count != 0)
				{
                    DataRow RDiarieItalia = TDiarieItalia.Rows[0];
					txtImportoDiaria.Text = CfgFn.GetNoNullDecimal(RDiarieItalia["amount"]).ToString("c");
					txtPercAnticipo.Text = CfgFn.GetNoNullDecimal(RDiarieItalia["advancepercentage"]).ToString("p");
				}
				else
				{
					txtImportoDiaria.Text ="";
					txtPercAnticipo.Text ="";
				}
			}

            object idforeigngrouprule = Conn.DO_READ_VALUE("foreigngrouprule", QHS.CmpLe("start",data),
                "MAX(idforeigngrouprule)");
    
            string filter_group = 
                QHS.AppAnd(QHS.CmpEq("idposition", qualifica), 
                QHS.Between(QHS.quote(classe), QHS.Field("minincomeclass"), QHS.Field("maxincomeclass")),
                QHS.CmpEq("idforeigngrouprule", idforeigngrouprule));
            
            object foreigngroupnumber = Conn.DO_READ_VALUE("foreigngroupruledetailview", filter_group,"MAX(foreigngroupnumber)");

            string filter_forall = "";

            object idforeignallowancerule;
            idforeignallowancerule = Conn.DO_READ_VALUE("foreignallowancerule", filter_forall, "MAX(idforeignallowancerule)");
            
            string query =
            "SELECT idforeignallowancerule, iddetail, foreigncountry, start, minforeigngroupnumber, maxforeigngroupnumber, amount, advancepercentage " +
            " FROM foreignallowanceruledetailview v " +
            " WHERE " + QHS.AppAnd(
            QHS.Between(QHS.quote(foreigngroupnumber), QHS.Field("minforeigngroupnumber"), QHS.Field("maxforeigngroupnumber")),
            " start = (SELECT MAX(start) FROM foreignallowancerule f " +
            " WHERE " + QHS.AppAnd(QHS.CmpEq("f.idforeignallowancerule", QHS.Field("v.idforeignallowancerule")),
            QHS.CmpLe("start", data)) + ")")
            + " ORDER BY foreigncountry ";

            string errMess;
            DataTable TDiarieEstere = Conn.SQLRunner(query, 0, out errMess);

            if ((TDiarieEstere != null) && (TDiarieEstere.Rows.Count != 0)) {
                foreach (DataRow R in TDiarieEstere.Rows) {
                    AddRowToTable(R, DS.foreignallowanceruledetailview);
                }
            }
	
			HelpForm.SetDataGrid(dtGridDiarie,DS.foreignallowanceruledetailview);
			formatgrids FGDiarie= new formatgrids(dtGridDiarie);
			FGDiarie.AutosizeColumnWidth();

            object iditinerationrefundrule = Conn.DO_READ_VALUE("itinerationrefundrule", QHS.CmpLe("start",data),
                "MAX(iditinerationrefundrule)");

            string filter_itref = QHS.AppAnd(QHS.CmpEq("iditinerationrefundrule", iditinerationrefundrule),
                QHS.CmpEq("idposition", qualifica),
                QHS.Between(QHS.quote(classe), QHS.Field("minincomeclass"), QHS.Field("maxincomeclass")));

            DataTable TRimborso = Conn.RUN_SELECT("itinerationrefundruledetailview", "*",
                "iddetail", filter_itref, null, false);

            if ((TRimborso != null) && (TRimborso.Rows.Count != 0)) {
                foreach (DataRow R in TRimborso.Rows) {
                    AddRowToTable(R, DS.itinerationrefundruledetailview);
                }
            }

			HelpForm.SetDataGrid(dtGridRimborso,DS.itinerationrefundruledetailview);
			formatgrids FGrimborso= new formatgrids(dtGridRimborso);
			FGrimborso.AutosizeColumnWidth();

            object idreductionrule = Conn.DO_READ_VALUE("reductionrule", QHS.CmpLe("start", data),
                        "MAX(idreductionrule)");

            string f_red = QHS.CmpEq("idreductionrule", idreductionrule);
            DataTable TRiduzioneDiaria = Conn.RUN_SELECT("reductionruledetailview", "*", "idreduction", f_red, null, false);

            if ((TRiduzioneDiaria != null) && (TRiduzioneDiaria.Rows.Count != 0)) {
                foreach (DataRow R in TRiduzioneDiaria.Rows) {
                    AddRowToTable(R, DS.reductionruledetailview);
                }
            }

            HelpForm.SetDataGrid(dtGridRiduzione, DS.reductionruledetailview);
			formatgrids FGriduzione= new formatgrids(dtGridRiduzione);
			FGriduzione.AutosizeColumnWidth();

			DS.AcceptChanges();
		}

		void AddRowToTable(DataRow R, DataTable T){			
			DataRow NewR = T.NewRow();
			foreach(DataColumn C in R.Table.Columns) {
			    if (!T.Columns.Contains(C.ColumnName)) continue;
				NewR[C.ColumnName]= R[C.ColumnName];
			}
			T.Rows.Add(NewR);
		}
	
	
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			inChiusura = true;
			if( disposing ) {
				if(components != null) {
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
		private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDiarieItalia = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtGridDiarie = new System.Windows.Forms.DataGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercAnticipo = new System.Windows.Forms.TextBox();
            this.txtImportoDiaria = new System.Windows.Forms.TextBox();
            this.tabRimborsospese = new System.Windows.Forms.TabPage();
            this.dtGridRimborso = new System.Windows.Forms.DataGrid();
            this.tabRiduzionediaria = new System.Windows.Forms.TabPage();
            this.dtGridRiduzione = new System.Windows.Forms.DataGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtData = new System.Windows.Forms.TextBox();
            this.cmbQualifica = new System.Windows.Forms.ComboBox();
            this.DS = new position_riepilogo.vistaForm();
            this.cmbClasse = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabDiarieItalia.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDiarie)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabRimborsospese.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRimborso)).BeginInit();
            this.tabRiduzionediaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRiduzione)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabDiarieItalia);
            this.tabControl1.Controls.Add(this.tabRimborsospese);
            this.tabControl1.Controls.Add(this.tabRiduzionediaria);
            this.tabControl1.Location = new System.Drawing.Point(24, 96);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(528, 312);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.Tag = "";
            // 
            // tabDiarieItalia
            // 
            this.tabDiarieItalia.Controls.Add(this.groupBox2);
            this.tabDiarieItalia.Controls.Add(this.groupBox1);
            this.tabDiarieItalia.Location = new System.Drawing.Point(4, 22);
            this.tabDiarieItalia.Name = "tabDiarieItalia";
            this.tabDiarieItalia.Size = new System.Drawing.Size(520, 286);
            this.tabDiarieItalia.TabIndex = 0;
            this.tabDiarieItalia.Text = "Diarie ";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dtGridDiarie);
            this.groupBox2.Location = new System.Drawing.Point(8, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(504, 216);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estero";
            // 
            // dtGridDiarie
            // 
            this.dtGridDiarie.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridDiarie.DataMember = "";
            this.dtGridDiarie.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtGridDiarie.Location = new System.Drawing.Point(8, 16);
            this.dtGridDiarie.Name = "dtGridDiarie";
            this.dtGridDiarie.Size = new System.Drawing.Size(488, 192);
            this.dtGridDiarie.TabIndex = 6;
            this.dtGridDiarie.Tag = "foreignallowanceruledetailview.default";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPercAnticipo);
            this.groupBox1.Controls.Add(this.txtImportoDiaria);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 56);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Italia";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(264, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "Anticipo (%):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Importo diaria:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPercAnticipo
            // 
            this.txtPercAnticipo.Enabled = false;
            this.txtPercAnticipo.Location = new System.Drawing.Point(376, 16);
            this.txtPercAnticipo.Name = "txtPercAnticipo";
            this.txtPercAnticipo.Size = new System.Drawing.Size(96, 20);
            this.txtPercAnticipo.TabIndex = 5;
            // 
            // txtImportoDiaria
            // 
            this.txtImportoDiaria.Enabled = false;
            this.txtImportoDiaria.Location = new System.Drawing.Point(104, 16);
            this.txtImportoDiaria.Name = "txtImportoDiaria";
            this.txtImportoDiaria.Size = new System.Drawing.Size(96, 20);
            this.txtImportoDiaria.TabIndex = 4;
            // 
            // tabRimborsospese
            // 
            this.tabRimborsospese.Controls.Add(this.dtGridRimborso);
            this.tabRimborsospese.Location = new System.Drawing.Point(4, 22);
            this.tabRimborsospese.Name = "tabRimborsospese";
            this.tabRimborsospese.Size = new System.Drawing.Size(520, 286);
            this.tabRimborsospese.TabIndex = 2;
            this.tabRimborsospese.Text = "Rimborso spese";
            // 
            // dtGridRimborso
            // 
            this.dtGridRimborso.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridRimborso.DataMember = "";
            this.dtGridRimborso.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtGridRimborso.Location = new System.Drawing.Point(8, 8);
            this.dtGridRimborso.Name = "dtGridRimborso";
            this.dtGridRimborso.Size = new System.Drawing.Size(504, 272);
            this.dtGridRimborso.TabIndex = 1;
            this.dtGridRimborso.Tag = "itinerationrefundruledetailview.default";
            // 
            // tabRiduzionediaria
            // 
            this.tabRiduzionediaria.Controls.Add(this.dtGridRiduzione);
            this.tabRiduzionediaria.Location = new System.Drawing.Point(4, 22);
            this.tabRiduzionediaria.Name = "tabRiduzionediaria";
            this.tabRiduzionediaria.Size = new System.Drawing.Size(520, 286);
            this.tabRiduzionediaria.TabIndex = 3;
            this.tabRiduzionediaria.Text = "Riduzione diaria";
            // 
            // dtGridRiduzione
            // 
            this.dtGridRiduzione.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridRiduzione.CaptionVisible = false;
            this.dtGridRiduzione.DataMember = "";
            this.dtGridRiduzione.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dtGridRiduzione.Location = new System.Drawing.Point(8, 7);
            this.dtGridRiduzione.Name = "dtGridRiduzione";
            this.dtGridRiduzione.Size = new System.Drawing.Size(504, 272);
            this.dtGridRiduzione.TabIndex = 1;
            this.dtGridRiduzione.Tag = "reductionruledetailview.default";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(0, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Qualifica:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Classe:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(272, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(144, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Data inizio missione:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtData
            // 
            this.txtData.Location = new System.Drawing.Point(416, 56);
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(136, 20);
            this.txtData.TabIndex = 2;
            this.txtData.Leave += new System.EventHandler(this.txtData_Leave);
            // 
            // cmbQualifica
            // 
            this.cmbQualifica.DisplayMember = "idposition";
            this.cmbQualifica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQualifica.Location = new System.Drawing.Point(96, 16);
            this.cmbQualifica.Name = "cmbQualifica";
            this.cmbQualifica.Size = new System.Drawing.Size(456, 21);
            this.cmbQualifica.TabIndex = 0;
            this.cmbQualifica.Tag = "";
            this.cmbQualifica.ValueMember = "idposition";
            this.cmbQualifica.SelectedIndexChanged += new System.EventHandler(this.cmbQualifica_SelectedIndexChanged);
            // 
            // cmbClasse
            // 
            this.cmbClasse.DisplayMember = "incomeclass";
            this.cmbClasse.Location = new System.Drawing.Point(96, 56);
            this.cmbClasse.Name = "cmbClasse";
            this.cmbClasse.Size = new System.Drawing.Size(152, 21);
            this.cmbClasse.TabIndex = 1;
            this.cmbClasse.ValueMember = "incomeclass";
            this.cmbClasse.SelectedIndexChanged += new System.EventHandler(this.cmbClasse_SelectedIndexChanged);
            // 
            // Frm_position_riepilogo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(584, 421);
            this.Controls.Add(this.cmbClasse);
            this.Controls.Add(this.cmbQualifica);
            this.Controls.Add(this.txtData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_position_riepilogo";
            this.Text = "Frm_position_riepilogo";
            this.tabControl1.ResumeLayout(false);
            this.tabDiarieItalia.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridDiarie)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabRimborsospese.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRimborso)).EndInit();
            this.tabRiduzionediaria.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRiduzione)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void cmbClasse_SelectedIndexChanged(object sender, System.EventArgs e) {
			if (!meta.DrawStateIsDone) return;
            EseguiQuery();
		}

		
		private void txtData_Leave(object sender, System.EventArgs e)
		{
			if (inChiusura) return;
			object data=HelpForm.GetObjectFromString(typeof(DateTime),txtData.Text,null);
			if (data == null) {
				txtData.Text=(string)data;
				return;
			}
            EseguiQuery();
		}

		private void cmbQualifica_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (!meta.DrawStateIsDone)return;
			Qualifica_Change(GetQualificaRow());		
		}
	}
}
