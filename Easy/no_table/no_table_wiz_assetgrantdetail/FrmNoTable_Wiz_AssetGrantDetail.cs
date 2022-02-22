
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;

namespace no_table_wiz_assetgrantdetail {
    public partial class FrmNoTable_Wiz_AssetGrantDetail : MetaDataForm {
        public FrmNoTable_Wiz_AssetGrantDetail() {
            InitializeComponent();
            tabController.HideTabsMode = Crownwood.Magic.Controls.TabControl.HideTabsModes.HideAlways;
        }

        #region Gestione Tabs

        string CustomTitle;
        /// <summary>
        /// Displays tab n. NewTab and updates buttons
        /// </summary>
        /// <param name="newTab"></param>
        void DisplayTabs(int newTab) {
            tabController.SelectedIndex = newTab;
            //Evaluates Buttons Appearance
            btnIndietro.Visible = (newTab > 0);
            if (newTab == tabController.TabPages.Count - 1)
                btnAvanti.Text = "Fine";
            else
                btnAvanti.Text = "Next >";
            Text = CustomTitle + " (Pagina " + (newTab + 1) + " di " + tabController.TabPages.Count + ")";
            if (newTab > 0) ShowPage(newTab);
        }
        
        void ShowPage(int NPasso) {
            btnIndietro.Enabled = true;
            btnAvanti.Enabled = true;

        }


        void StandardChangeTab(int step) {
            int oldTab = tabController.SelectedIndex;
            int newTab = oldTab + step;
            if ((newTab < 0) || (newTab > tabController.TabPages.Count)) return;
            if (!CustomChangeTab(oldTab, newTab)) return;
            if (newTab == tabController.TabPages.Count) {
                //if (show(this, "Si desidera eseguire ancora la procedura",
                //    "Conferma", MessageBoxButtons.YesNo) == DialogResult.Yes) {
                //    newTab = 1;
                //    ResetWizard();
                //}
                //else {
                    DialogResult = DialogResult.OK;
                    Close();
                    return;
                //}
            }
            DisplayTabs(newTab);
        }
        private void btnIndietro_Click(object sender, System.EventArgs e) {
            StandardChangeTab(-1);
        }
        private void btnAvanti_Click(object sender, System.EventArgs e) {
            StandardChangeTab(+1);
        }

        bool CustomChangeTab(int oldTab, int newTab) {
            if (oldTab == 0) {  

                try {
                DataSet Out = Conn.CallSP("closeyear_assetgrant",
                  new Object[4] {Meta.GetSys("esercizio"),
                                    DBNull.Value, // idasset
                                    DBNull.Value, // idpiece
                                    "V"
                                }
                  );

                    if (Out == null || Out.Tables.Count == 0) {
                        show(this, "Procedura terminata con errore", "Errore");
                        return false;
                    }
                    Out.Tables[0].TableName = "Cespiti ammortizzati";
                    HelpForm.SetDataGrid(gridRisultati, Out.Tables[0]);
                    if (Out.Tables[0].Rows.Count == 0) {
                        btnCreaRisconti.Visible = false;
                        lblRiepilogo.Text = "Non Saranno Generati Risconti per i Cespiti ammortizzati nell'esercizio corrente";
                    }
                    else {
                        btnCreaRisconti.Visible = true;
                        lblRiepilogo.Text = "Saranno Generati i seguenti Risconti per i Cespiti ammortizzati nell'esercizio corrente";
                    }
                }
                catch (Exception E) {
                    show(E.Message);
                    return false;
                }
             
              
                return CheckStandard(); // 0->1: nothing to do
            }
            if ((oldTab == 1) && (newTab == 0)) return true; //1->0:nothing to do!
            return true;
        }

        #endregion


        bool CheckStandard() {
            return true;
        }


        MetaData Meta;
        DataAccess Conn;
        QueryHelper QHS;
        CQueryHelper QHC;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Meta.CanSave = false;
            Meta.SearchEnabled = false;
            Meta.CanInsert = false;
            Meta.CanInsertCopy = false;
            Meta.CanCancel = false;

            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

        }
        public void MetaData_AfterClear() {
            DisplayTabs(0);
        }

        public void MetaData_AfterActivation() {
            CustomTitle = "Procedura di generazione automatica Risconti da Ammortamenti";
            //Selects first tab
            DisplayTabs(0);
        }


        private void btnCreaRisconti_Click(object sender, EventArgs e) {
            try {  
            DataSet Out = Conn.CallSP("closeyear_assetgrant",
            new[] {Meta.GetSys("esercizio"),
                            DBNull.Value,
                            DBNull.Value,
                            "C"
                          }
            );
            if (Out == null || Out.Tables.Count == 0)
                show(this, "Procedura terminata con errore", "Errore");
            else
                show(this, "Procedura eseguita", "");
            }
            catch (Exception E) {
                show(E.Message);
            }
        }

    }
}
