
/*
Easy
Copyright (C) 2021 Università degli Studi di Catania (www.unict.it)
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
using funzioni_configurazione;
using System.Diagnostics;

namespace no_table_checkpatrimonio {
    public partial class FrmCheckPatrimonio : Form {
        DataAccess Conn;
        MetaData Meta;

        List<FunzioneCheck> CheckList = new List<FunzioneCheck>();
        void AssociaFunzioniABottoni() {
            CheckList.Add(new FunzioneCheck(btnTestA1, txtTestA1, CalcolaA1, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA2, txtTestA2, CalcolaA2, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA3, txtTestA3, CalcolaA3, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA4, txtTestA4, CalcolaA4, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA5, txtTestA5, CalcolaA5, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA6, txtTestA6, CalcolaA6, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA7, txtTestA7, CalcolaA7, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA8, txtTestA8, CalcolaA8, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestA9, txtTestA9, CalcolaA9, VisualizzaDati));

            CheckList.Add(new FunzioneCheck(btnTestB1, txtTestB1, CalcolaB1, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestB2, txtTestB2, CalcolaB2, VisualizzaDati));

            CheckList.Add(new FunzioneCheck(btnTestC1, txtTestC1, CalcolaC1, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestC2, txtTestC2, CalcolaC2, VisualizzaDati));

            CheckList.Add(new FunzioneCheck(btnTestD1, txtTestD1, CalcolaD1, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestD2, txtTestD2, CalcolaD2, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestD5, txtTestD5, CalcolaD5, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestD6, txtTestD6, CalcolaD6, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestD7, txtTestD7, CalcolaD7, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestD8, txtTestD8, CalcolaD8, VisualizzaDati));

            CheckList.Add(new FunzioneCheck(btnTestE1, txtTestE1, CalcolaE1, VisualizzaDati));
            CheckList.Add(new FunzioneCheck(btnTestE2, txtTestE2, CalcolaE2, VisualizzaDati));

        }

        public FrmCheckPatrimonio() {
            InitializeComponent();
            AssociaFunzioniABottoni();

        }

        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            DisabilitaFunzioni();
            Meta.canInsert = false;
            Meta.canSave = false;
            Meta.searchEnabled = false;
            Meta.CanCancel = false;
        }
        public void DisabilitaFunzioni() {
            btnTestF1.Enabled = false;
            btnTestF2.Enabled = false;
            btnTestF3.Enabled = false;
            btnTestF4.Enabled = false;
            btnTestF5.Enabled = false;
            btnTestD3.Enabled = false;
            btnTestD4.Enabled = false;
            btnTestD9.Enabled = false;
        }

        #region Visualizzazione dati

        public void VisualizzaDati(DataTable T,string explanation) {
            if (T == null) return;
            if (T.Rows.Count == 0) {
                MessageBox.Show("Nessun elemento trovato");
                return;
            }
            int sel = 0;
            if (rdbExpToExcel.Checked) sel = 1;
            if (rdbExpToCsv.Checked) sel = 2;
            if (rdbExpToListing.Checked) sel = 3;

            switch (sel) {
                case 1: {
                        ToExcel(T);
                        break;
                    }
                case 2: {
                        ToCsv(T);
                        break;
                    }
                case 3: {
                        if (T.DataSet == null) {
                            DataSet D = new DataSet();
                            D.Tables.Add(T);
                        }
                        ToGrid(T,explanation);
                        break;
                    }
                default: {
                        ToExcel(T);
                        break;
                    }
            }

        }

        private void ToExcel(DataTable T) {
            if (T.Rows.Count == 0) {
                MessageBox.Show("Nessun elemento trovato");
                return;
            }
            exportclass.DataTableToExcel(T, true);
        }

        private void ToGrid(DataTable T, string explanation) {
            //gridRisultati.DataSource = null;
            //gridRisultati.DataBindings.Clear();
            HelpForm.SetDataGrid(gridRisultati, T);
            tabControl1.SelectedTab = tabPageRisultati;
            labelRisultato.Text = explanation;

        }
        //private void ToListing(string dataTable, string listType, string filter) {
        //    MetaData MElenco = MetaData.GetMetaData(this, dataTable);
        //    int rowsfound = Conn.RUN_SELECT_COUNT(dataTable, filter, true);
        //    if (rowsfound == 0) {
        //        MessageBox.Show("Nessun elemento trovato");
        //        return;
        //    }

        //    if (MElenco == null) return;
        //    MElenco.ContextFilter = filter;
        //    bool result = MElenco.Edit(Meta.LinkedForm.ParentForm, "default", false);
        //    DataRow R = MElenco.SelectOne(listType, filter, null, null);
        //    if (R != null) MElenco.SelectRow(R, listType);
        //}

        private void ToCsv(DataTable T) {
            if (T.Rows.Count == 0) {
                MessageBox.Show("Nessun elemento trovato");
                return;
            }
            OpenFileDialog FD = new OpenFileDialog();
            FD.Title = "Seleziona il file CSV da creare";
            FD.AddExtension = true;
            FD.DefaultExt = "CSV";
            FD.CheckFileExists = false;
            FD.CheckPathExists = true;
            FD.Multiselect = false;
            DialogResult DR = FD.ShowDialog();
            if (DR != DialogResult.OK) {
                MessageBox.Show("Non è stata scelta la destinazione");
                return;
            }

            try {
                exportclass.dataTableToCommaSeparatedValues(T, true, FD.FileName);
                Process.Start(FD.FileName);
            }
            catch (Exception E) {
                QueryCreator.ShowException(E);
            }

        }

        #endregion

        public class FunzioneCheck {
            public delegate DataTable CalcolaErrori();
            public delegate void VisualizzaFn(DataTable T,string explanation);
            CalcolaErrori Calc;
            VisualizzaFn view;
            public string listtype;
            public Button Btn;
            public TextBox explanation;

            public FunzioneCheck(Button Btn, TextBox Explanation, CalcolaErrori Calc,  VisualizzaFn View) {
                this.Btn = Btn;
                this.Calc = Calc;
                this.explanation = Explanation;
                Btn.Click += this.ButtonClick;
                this.view = View;
            }
            public DataTable Calcola() {
                return Calc();
            }
            private void ButtonClick(object sender, EventArgs e) {
                DataTable T = Calc();
                
                view(T, explanation.Text);
            }
        }

        private void btnVerificaTutto_Click(object sender, EventArgs e) {
            foreach( FunzioneCheck F in CheckList){
                DataTable T = F.Calcola();
                if (T == null || T.Rows.Count == 0) {
                    F.Btn.Visible=false;
                    F.explanation.Visible=false;
                }
                else {
                    F.Btn.Visible=true;
                    F.explanation.Visible=true;
                }
            }
        }

        //carichi cespite e accessori senza buoni di carico (con flag 'da inserire in buono') , scaricati
        DataTable CalcolaA1() {
            string sqlCmd =
            "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "AUK.codeassetunloadkind as 'tipo buono scarico'," +
                    "AU.yassetunload as 'Eserc.buono scarico'," +
                    "AU.nassetunload as 'Num.buono scarico' " +
                    " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    " WHERE  " +
                    "   ( (B.idassetload is null) AND (B.flag&1 <> 0) )   " +
                    "  AND " +
                    "  ( (A.idassetunload is not null) OR (A.flag&1 = 0) ) 	";
            DataTable T = Conn.SQLRunner(sqlCmd,false);
            return T;
        }

        //carichi cespiti ed accessori nuove acquisizioni non in buono di carico ma da inserire in buono carico
        DataTable CalcolaA2() {
            string sqlCmd =
            "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                " FROM  asset A " +
                " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                " WHERE  " +
                "  ( B.idassetload is  null )   " +
                "  AND " +
                "  ( (B.flag & 1) <>0 ) " +
                "  AND  " +
                "  ( (B.flag & 2) = 0) ";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //carichi cespite e accessori inseriti in buoni di carico (senza flag ''da inserire in buono'') 
        DataTable CalcolaA3() {
            string sqlCmd =
            "SELECT A.idasset as 'Num.Cespite',"+ 
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "ALK.codeassetloadkind as 'tipo buono carico'," +
                    "AL.yassetload as 'Eserc.buono carico'," +
                    "AL.nassetload as 'Num.buono carico' " +
            " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    " WHERE  " +
	                "    ( (B.idassetload is not null) AND (B.flag&1 = 0) )";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //carichi accessori senza buoni di carico (CON flag ''da inserire in buono'') e al contempo nuove acquisizioni 
        DataTable CalcolaE1() {
            string sqlCmd =
            "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                    " FROM  asset A" +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire" +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv" +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory" +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload" +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind" +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload" +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind" +
                    " WHERE " +
	                "    A.idpiece > 1		" +
                    "    AND ( (B.idassetload is null) AND ( (B.flag&1) <> 0) )  " +
	                "    AND ( (B.flag& 2)  = 0) ";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //cespiti/accessori ammortizzati in data successiva allo scarico:
        // la prima query prende quelli da 'Non includere nel buono di scarico' e confronta la data dell'ammortamento
        // la seconda query prende quelli inclusi nel buono di scarico e confronta la data del buono
        DataTable CalcolaD1() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "ALK.codeassetloadkind as 'Tipo Buono Carico'," +
                    "AL.yassetload as 'Eserc.Buono Carico'," +
                    "AL.nassetload as 'N.Buono Carico'," +
                    "AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    "AU.yassetunload as 'Eserc.Buono Scarico'," +
                    "AU.nassetunload as 'N.Buono Scarico' " +
                    " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    " WHERE  " +
                    "    (A.idassetunload is null)  " +
                    "    AND exists ( " +
                    "        select * from assetamortization AA where AA.idasset= A.idasset and AA.idpiece=A.idpiece " +
                    "	                AND (AA.flag&1) = 0		 " +
                    "	                 AND  year(AA.adate) > year(AU.adate) " +
                    "            ) "+

                   " UNION "+

                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "ALK.codeassetloadkind as 'Tipo Buono Carico'," +
                    "AL.yassetload as 'Eserc.Buono Carico'," +
                    "AL.nassetload as 'N.Buono Carico'," +
                    "AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    "AU.yassetunload as 'Eserc.Buono Scarico'," +
                    "AU.nassetunload as 'N.Buono Scarico' " +
                    "FROM  asset A " +
                    "join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    "join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    "LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    "left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    "left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    "left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    "left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    "WHERE  " +
	                "   (A.idassetunload is null)  " +
	                "    AND exists ( " +
		            "        select * from assetamortization AA  " +
					"                    join assetunload AAU on AA.idassetunload = AAU.idassetunload " +
					"                    where AA.idasset= A.idasset and AA.idpiece=A.idpiece " +
					"                    AND (AA.flag&1) <> 0				 " +
                    "                     AND  year(AAU.adate) > year(AU.adate) " +
			        "            )";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        // accessori con AMMORTAMENTI ma senza flag ''nuova acquisizione'
        DataTable CalcolaD5() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                    " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    " WHERE  " +
                    "   A.idpiece> 1  " +
                    "     and ( (B.flag & 2) <> 0) " +
                    "     AND exists(	select * from assetamortization AA  " +
                    "                     where AA.idasset= A.idasset and AA.idpiece=A.idpiece " +
                    "             ) ";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //cespiti o accessori con AMMORTAMENTI senza flag ''includi in buono scarico'', ma inclusi in buono scarico
        DataTable CalcolaD6() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +            
                    " FROM  asset A "+
                    "join assetacquire B					on A.nassetacquire=B.nassetacquire "+
                    "LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory "+
                    "join inventorytree ITREE			on B.idinv= ITREE.idinv "+
                    "left outer join assetload AL		on AL.idassetload=B.idassetload "+
                    "left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind "+
                    "left outer join assetunload AU		on AU.idassetunload=A.idassetunload "+
                    "left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind "+
                    "WHERE exists  "+
                    "(	select * from assetamortization AA  "+
                    "    where  AA.idassetunload is not null  "+
                    "        AND AA.idasset= A.idasset and AA.idpiece=A.idpiece "+
                    "    AND (AA.flag&1) = 0							  " +
                    ")";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //cespiti o accessori con AMMORTAMENTI aventi flag "includi in buono scarico" ma senza buono scarico
        DataTable CalcolaD7() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                    " FROM  asset A" +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire" +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv" +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory" +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload" +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind" +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload" +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind" +
                    " WHERE exists " +
                    "  (	select * from assetamortization AA 					" +
                    "                     where AA.idasset= A.idasset and AA.idpiece=A.idpiece" +
                    "                    AND AA.idassetunload is null AND AA.idassetload is null" +
                    "                     AND (AA.flag&1) <> 0" +
                    "             )";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        // cespiti o accessori con buoni di carico senza data ratifica
        DataTable CalcolaB1() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "ALK.codeassetloadkind as 'Tipo Buono Carico'," +
                    "AL.yassetload as 'Eserc.Buono Carico'," +
                    "AL.nassetload as 'N.Buono Carico'" +
                "FROM  asset A " +
                "join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                "join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                "LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                "left outer join assetload AL		on AL.idassetload=B.idassetload " +
                "left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                "left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                "left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                "WHERE  " +
	            "    AL.idassetload is not null and AL.ratificationdate is null";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        // Cespiti o accessori con buoni di scarico senza data contabile
        DataTable CalcolaC2() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    "AU.yassetunload as 'Eserc.Buono Scarico'," +
                    "AU.nassetunload as 'N.Buono Scarico' " +
                    "FROM  asset A " +
                    "join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    "join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    "LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    "left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    "left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    "left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    "left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    "WHERE  " +
                    "    AU.idassetunload is not null and AU.adate is null ";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        // cespiti o accessori con ammortamenti non inclusi in buono di scarico e senza data contabile
        DataTable CalcolaD8() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                    " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire" +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv" +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory" +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload" +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind" +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload" +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind" +
                    " WHERE " +
                    "    exists(select * from assetamortization AA " +
                    "                where AA.idasset=A.idasset and AA.idpiece=A.idpiece" +
                    "                    AND ((AA.flag&1)  = 0) " +
                    "                    AND (AA.adate is null)" +
                    "        )";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        // cespiti/accessori caricati in data successivo allo scarico
        // La prima query considera quelli da non includere in buono carico, e senza buono, quindi la data del carico
        // la seconda query considera quelli col buono di carico e quindi la data del buono
        DataTable CalcolaA4() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.', " +
                    " year(B.adate) as 'Eserc.Carico'," +
                    "AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    "AU.yassetunload as 'Eserc.Buono Scarico'," +
                    "AU.nassetunload as 'N.Buono Scarico' " +
                    " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    " WHERE  " +
                    "  ( (B.idassetload is null) AND (B.flag&1 = 0) )   " +
                    "  AND " +
                    "  AU.idassetunload is not null " +
                    "  AND " +
                    "  year(AU.adate) < year(B.adate) " +
                    " UNION " +
                " SELECT I.codeinventory as 'codice inventario'," +
                    " A.ninventory as 'n.inv.'," +
                    " A.nassetacquire as 'n.carico'," +
                    " ITREE.codeinv as 'class.inv.'," +
                    " year(B.adate) as 'Eserc.Carico'," +
                    " AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    " AU.yassetunload as 'Eserc.Buono Scarico'," +
                    " AU.nassetunload as 'N.Buono Scarico' " +
                    " FROM  asset A " +
                    " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                    " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                    " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                    " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                    " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                    " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                    " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                    " WHERE  " +
                    "  ( (B.idassetload is not null) AND (B.flag&1 <> 0) )   " +
                    "  AND " +
                    "    AU.idassetunload is not null " +
                    "  AND " +
                    "   year(AU.adate) < year(AL.adate)                 ";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //Cespiti/accessori ammortizzati oltre il valore iniziale
        DataTable CalcolaD2() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                "FROM  asset A "+
                "join assetacquire B					on A.nassetacquire=B.nassetacquire "+
                "join inventorytree ITREE			on B.idinv= ITREE.idinv "+
                "join assetview_current ACURR	    on A.idasset= ACURR.idasset and A.idpiece=ACURR.idpiece "+
                "LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory "+
                "left outer join assetload AL		on AL.idassetload=B.idassetload "+
                "left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind "+
                "left outer join assetunload AU		on AU.idassetunload=A.idassetunload "+
                "left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind "+
                "WHERE  " +
                " ACURR.currentvalue<0";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //cespiti scaricati con accessori non scaricati o  scaricati in data successiva al cespite
        DataTable CalcolaC1() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    "AU.yassetunload as 'Eserc.Buono Scarico'," +
                    "AU.nassetunload as 'N.Buono Scarico' " +
                " FROM asset A " +
                " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                " WHERE  " +
                " A.idpiece = 1              " +
                " AND	( A.idassetunload is not null OR ( (A.flag & 1) =0)  )   " +
                " AND EXISTS(	 " +
	            "    select * from asset ACC  " +
			    "            where ACC.idasset=A.idasset and ACC.idpiece>1 " +
				"                and 	( ACC.idassetunload is null AND ( (ACC.flag & 1) <>0)  )	  " +
	            "    ) " +
                " UNION "+
                " SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'," +
                    "AUK.codeassetunloadkind as 'Tipo Buono Scarico'," +
                    "AU.yassetunload as 'Eserc.Buono Scarico'," +
                    "AU.nassetunload as 'N.Buono Scarico' " +
                " FROM  asset A " +
                " join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                " join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                " LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                " left outer join assetload AL		on AL.idassetload=B.idassetload " +
                " left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                " left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                " left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                " WHERE  " +
                " A.idpiece = 1 " +
                " AND	( A.idassetunload is not null OR ( (A.flag & 1) =0)  )  " +
                " AND EXISTS(	 " +
	            "    select * from asset ACC  " +
		        "        join assetunload ACC_U on ACC.idassetunload = ACC_U.idassetunload " +
			    "            where  ACC.idasset=A.idasset and ACC.idpiece>1 " +
				"	                AND year(ACC_U.adate)  > year(AU.adate) " +
	            "    )  " ;

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        // cespiti ed accessori senza data inizio esistenza, ancora in carico
        DataTable CalcolaA5() {
            string sqlCmd =
                "SELECT I.codeinventory as 'codice inventario'," +
                    "A.ninventory as 'n.inv.'," +
                    "A.nassetacquire as 'n.carico'," +
                    "ITREE.codeinv as 'class.inv.'" +
                "FROM  asset A " +
                "join assetacquire B					on A.nassetacquire=B.nassetacquire " +
                "join inventorytree ITREE			on B.idinv= ITREE.idinv " +
                "LEFT  OUTER JOIN inventory   I		ON b.idinventory=I.idinventory " +
                "left outer join assetload AL		on AL.idassetload=B.idassetload " +
                "left outer join assetloadkind ALK	on ALK.idassetloadkind=AL.idassetloadkind " +
                "left outer join assetunload AU		on AU.idassetunload=A.idassetunload " +
                "left outer join assetunloadkind AUK on AUK.idassetunloadkind=AU.idassetunloadkind " +
                "WHERE  " +
                "  A.lifestart is null " +
                "  and 	( A.idassetunload is null AND ( (A.flag & 1) <>0)  ) ";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }
        //Numeri di inventario duplicati
        DataTable CalcolaA6() {
            string sqlCmd =
                " SELECT A.idasset as 'Id Cespite', "+
                        " A.nassetacquire as 'Numero Carico Cespite', "+
                        " AA.adate as 'Data acquisizione carico', "+
                        " AA.description as 'Descrizione', "+
                        " AA.idinventory as 'Codice Inventario',  "+
                        "  A.ninventory as 'Numero inventario', "+
                        "  AA.startnumber as 'Numero iniziale', "+
                        " AA.number as 'Quantità', "+
                        " assetloadkind.codeassetloadkind as 'Codice Buono Carico',  "+
                        " assetload.yassetload as 'Eserc. Buono Carico',   "+
                        " assetload.nassetload as 'Num. Buono Carico',   "+
                        " A.cu as 'Creato da' "+
                " FROM asset A "+
                " JOIN assetacquire AA  "+
	            " on AA.nassetacquire= A.nassetacquire "+
                "  left outer join assetload "+
	            " on assetload.idassetload = AA.idassetload "+
                " left outer join assetloadkind "+
	            " on assetloadkind.idassetloadkind = assetload.idassetloadkind "+
                " JOIN inventory i  "+
		        " ON i.idinventory = AA.idinventory "+
                " WHERE A.idpiece = 1 AND "+
                    " exists (select * from asset B  "+
                        " join assetacquire BB on BB.nassetacquire= B.nassetacquire "+
                        " where  B.idpiece = 1 AND "+
                        " B.ninventory= A.ninventory and "+
                        " BB.idinventory= AA.idinventory and "+
                        " A.idasset <> B.idasset "+
                    " ) "+
                " ORDER BY "+
                " AA.idinventory,assetload.yassetload, AA.startnumber, AA.nassetacquire ";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //Salti nella numerazione dell'inventario
        DataTable CalcolaA7() {
            string sqlCmd =
                    "	SELECT  " +
                    "		a.idasset as 'Id Cespite', " +
                    "		a.nassetacquire as 'Numero Carico Cespite', " +
                    "		b.adate	as 'Data acquisizione carico', " +
                    "		b.description as 'Descrizione', " +
                    "		ti.codeinventory as 'Codice Inventario',  " +
                    "		ti.description as 'Tipo Inventario', " +
                    "		a.ninventory as 'Numero inventario', " +
                    "		b.startnumber as 'Numero iniziale', " +
                    "		b.number as 'Quantità', " +
                    "		tb.codeassetloadkind as 'Codice Buono Carico',  " +
                    "		tb.description as 'Tipo Buono Carico',    " +
                    "		assetload.yassetload as 'Eserc. Buono Carico',   " +
                    "		assetload.nassetload as 'Num. Buono Carico',   " +
                    "		a.cu as 'Creato da'		 " +
                    "	FROM  asset a  " +
                    "	JOIN  assetacquire b  " +
                    "		ON a.nassetacquire=b.nassetacquire " +
                    "	left outer join assetload " +
                    "		on assetload.idassetload = b.idassetload " +
                    "	LEFT  OUTER JOIN inventory ti  " +
                    "		ON ti.idinventory = b.idinventory " +
                    "	LEFT  OUTER JOIN assetloadkind tb  " +
                    "		ON tb.idassetloadkind = assetload.idassetloadkind " +
                    "	WHERE a.idpiece= 1 and " +
                    "		NOT EXISTS  " +
                    "		(SELECT * FROM asset c  " +
                    "		 JOIN  assetacquire d ON  c.nassetacquire=d.nassetacquire  " +
                    "		 WHERE c.idpiece = 1 AND d.idinventory = b.idinventory " +
                    "			AND c.ninventory = a.ninventory+1) " +
                    "	AND   a.ninventory < " +
                    "		( SELECT MAX(f.startnumber+isnull(f.number,1)-1) FROM assetacquire f  " +
                    "		  WHERE f.idinventory=b.idinventory )  " +
                    "	ORDER BY " +
                    "	b.idinventory,assetload.yassetload, b.startnumber, b.nassetacquire	 ";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }
        //Accessori non associati a Cespiti 
        DataTable CalcolaE2() {
            string sqlCmd =
                " SELECT  " +
                "	accessorio.idpiece 		AS 'Idpiece'," +
                "	accessorio.idasset 		AS 'Idasset'," +
                "	accessorio.nassetacquire	AS 'Carico Accessorio', " +
                "	assetloadkind.codeassetloadkind 	AS 'Tipo Buono Carico'," +
                "	assetload.yassetload 	AS 'Eserc. Buono Carico'," +
                "	assetload.nassetload 	AS 'Num. Buono Carico'," +
                "	assetunloadkind.codeassetunloadkind 	AS 'Tipo Buono Scarico'," +
                "	assetunload.yassetunload 	AS 'Eserc. Buono Scarico'," +
                "	assetunload.nassetunload 	AS 'Num. Buono Scarico'" +
                " FROM asset accessorio " +
                "	LEFT OUTER JOIN assetacquire on accessorio.nassetacquire=assetacquire.nassetacquire" +
                "	left outer join assetload on assetacquire.idassetload=assetload.idassetload" +
                "	left outer join assetloadkind on assetloadkind.idassetloadkind=assetload.idassetloadkind" +
                "	left outer join assetunload on assetunload.idassetunload=accessorio.idassetunload" +
                "	left outer join assetunloadkind on assetunloadkind.idassetunloadkind=assetunload.idassetunloadkind" +
                " WHERE 	accessorio.idpiece>1" +
                "	AND accessorio.idasset not in (select idasset from asset where idpiece = 1)" +
                " ORDER BY accessorio.idasset,accessorio.idpiece";

            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //Buoni di Carico con ratifiche incoerenti
        DataTable CalcolaB2() {
            string sqlCmd =
                "	SELECT "+
                "		assetloadkind.description 'Tipo Buono', "+
                "		assetload.yassetload 'Eserc.Buono', "+
                "		assetload.nassetload 'Num.Buono', "+
                "		assetload.ratificationdate as 'Data Ratifica' "+
                "	FROM assetload  "+
                "	JOIN assetloadkind "+ 
                "		ON assetloadkind.idassetloadkind = assetload.idassetloadkind "+
                "	WHERE	assetload.ratificationdate < assetload.adate ";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //Carichi Accessori con quantità errata
        DataTable CalcolaA8() {
            string sqlCmd =
            " SELECT  " +
            "	'C' as 'Cespite/Accessorio', " +
            "	(select count(*)  " +
            "	   from asset  " +
            "	  where nassetacquire= assetacquire.nassetacquire " +
            "	  AND asset.idpiece = 1)  AS 'Q.tà', " +
            "	assetacquire.nassetacquire AS 'Num. Carico', " +
            "	number        		   AS 'Q.tà nel carico', " +
            "	yman   	      		   AS 'Esercizio Ordine', " +
            "	nman          		   AS 'Numero Ordine', " +
            "	rownum	      		   AS 'Riga Ordine', " +
            "	description   		   AS 'Descrizione', " +
            "	adate AS 'Data Contabile' " +
            " FROM    assetacquire   " +
            " JOIN    asset  " +
            "	ON asset.nassetacquire = assetacquire.nassetacquire " +
            "	AND asset.idpiece = 1 " +
            " WHERE   number is null or number<1 OR  " +
            "	((select count(*) from asset cespite  " +
            "	 where cespite.nassetacquire=assetacquire.nassetacquire " +
            "	 AND   cespite.idpiece = 1) not in (0,number)) " +

            " UNION " +
            " SELECT " +
            "	'A' as 'Cespite/Accessorio', " +
            "	(select count(*)  " +
            "	   from asset  " +
            "	  where nassetacquire= assetacquire.nassetacquire " +
            "	  and asset.idpiece>1)  AS 'Q.tà', " +
            "	assetacquire.nassetacquire AS 'Num. Carico', " +
            "	number        		   AS 'Q.tà nel carico', " +
            "	yman   	      		   AS 'Esercizio Ordine', " +
            "	nman          		   AS 'Numero Ordine', " +
            "	rownum	      		   AS 'Riga Ordine', " +
            "	description   		   AS 'Descrizione', " +
            "	adate AS 'Data Contabile' " +
            " FROM    assetacquire   " +
            " JOIN    asset  " +
            "	ON asset.nassetacquire = assetacquire.nassetacquire " +
            "	AND asset.idpiece > 1 " +
            " WHERE   (number is null or number<1 OR  " +
            "	(select count(*) from asset accessorio  " +
            "	 where accessorio.nassetacquire=assetacquire.nassetacquire " +
            "	 AND   idpiece >1) not in (0,number)) " +
            " ORDER BY assetacquire.nassetacquire ";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }

        //Carichi Cespite senza Cespite
        DataTable CalcolaA9() {
            string sqlCmd =
                " SELECT " +
                "	nassetacquire AS 'Num. Carico Bene', " +
                "	yman   	      AS 'Esercizio Ordine', " +
                "	nman          AS 'Numero Ordine', " +
                "	rownum	      AS 'Riga Ordine', " +
                "	description   AS 'Descrizione', " +
                "	adate AS 'Data Contabile', " +
                "	CASE (flag&2) " +
                "		WHEN 0 THEN 'Nuova acquisizione' " +
                "		else 'Posseduto' " +
                "	END 	      AS 'Tipo Carico' " +
                " FROM    assetacquire   " +
                " WHERE   (select count(*) from asset where asset.nassetacquire =assetacquire.nassetacquire) = 0 " +
                " ORDER BY nassetacquire ";
            DataTable T = Conn.SQLRunner(sqlCmd, false);
            return T;
        }
    }


}
