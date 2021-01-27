
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
using System.IO;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;


namespace list_default{
    public partial class Frm_list_default : Form {
        MetaData Meta;
        public Frm_list_default()  {
            InitializeComponent();
        }

        CQueryHelper QHC;
        QueryHelper QHS;

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            DataAccess Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Meta.Conn.GetQueryHelper();

        }

        public void MetaData_AfterFill()
        {
            FreshLogo();
            if (Meta.InsertMode || Meta.EditMode) {
                fileimmagine.Enabled = true;
                btnRimuoviImmagine.Enabled = true;
            }
            SetGrids();
            EnableDisableCode();    
        }
        public void EnableDisableCode(){
            if (Meta.IsEmpty || Meta.InsertMode){
                txtIntcode.ReadOnly = false;
            }
            else {
                txtIntcode.ReadOnly = true;
            }
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R)
        {
            //FreshLogo();
        }

        void SetGridStyle() {
        }
        void ClearGrids() {
            foreach (DataGrid G in new DataGrid[] { 
                gridGiacenza,gridPrenotazioni,gridordiniinevasi,gridLast5ordini,gridlast5load,
                gridlast5unload,gridlast5year
            }) {
                G.DataBindings.Clear();
                G.DataSource = null;
                G.TableStyles.Clear();
            }

        }
        bool HasPackages() {
            if (Meta.IsEmpty) return false;
            DataRow Curr = DS.list.Rows[0];
            int N = CfgFn.GetNoNullInt32(Curr["unitsforpackage"]);
            return (N != 1);
        }
        void ClearListType(DataTable T) {
            foreach (DataColumn C in T.Columns) {
                MetaData.DescribeAColumn(T, C.ColumnName, "", -1);
            }
        }
        void CheckIntCol(DataTable T, string field) {
            foreach (DataRow R in T.Rows) {
                int N = CfgFn.GetNoNullInt32(R[field]);
                decimal D = CfgFn.GetNoNullDecimal(R[field]);
                if (CfgFn.GetNoNullInt32(D) != N) return;
            }
            DataColumn O= T.Columns[field];
            DataColumn C = new DataColumn("tempxx",typeof(System.Int32),null);
            C.Caption = O.Caption;
            C.ExtendedProperties["ListColPos"] = O.ExtendedProperties["ListColPos"];
            T.Columns.Add(C);
            foreach (DataRow R in T.Rows)
                R[C] = CfgFn.GetNoNullInt32(R[O]);
            T.Columns.Remove(O);
            C.ColumnName = field;
        }


        void SetGrids() {
            DataAccess Conn = Meta.Conn;

            if (Meta.IsEmpty || Meta.InsertMode) {
                ClearGrids();
                return;
            }
            ClearGrids();
            DataSet Temp = new DataSet();
            
            DataRow R = DS.list.Rows[0];
            bool HasP = HasPackages();
            
            DataTable TStockView = Conn.SQLRunner(
                            "select  ROUND((S.amount/S.number)*L.unitsforpackage,2) as amount_p, "+
                            "ROUND((S.amount/S.number),5) as amount, * " +
                            "from stockview S " +
                            " join list L on S.idlist=L.idlist " +
                            " where " + QHS.AppAnd(QHS.CmpEq("L.idlist", R["idlist"]), QHS.CmpGt("residual", 0),QHS.CmpGt("S.number",0)) +
                            " order by S.store asc, S.residual desc",false);
            Temp.Tables.Add(TStockView);
            ClearListType(TStockView);
            int nPos = 1;
            MetaData.DescribeAColumn(TStockView, "store", "Magazzino", nPos++);
            MetaData.DescribeAColumn(TStockView, "residual", "Giacenza", nPos++);
            HelpForm.SetFormatForColumn(TStockView.Columns["residual"], "n");
            MetaData.DescribeAColumn(TStockView, "unit", "Unità di misura", nPos++);
            MetaData.DescribeAColumn(TStockView, "amount", "Costo unit.", nPos++);
            HelpForm.SetFormatForColumn(TStockView.Columns["amount"], "n5");
            if (HasP) {
                MetaData.DescribeAColumn(TStockView, "amount", "Costo unit.", nPos++);
                HelpForm.SetFormatForColumn(TStockView.Columns["amount"], "n5");
                MetaData.DescribeAColumn(TStockView, "amount_p", "Costo confez.", nPos++);
            }
            else {
                MetaData.DescribeAColumn(TStockView, "amount", "Costo unit.", nPos++);
                HelpForm.SetFormatForColumn(TStockView.Columns["amount"], "c");
            }
            CheckIntCol(TStockView, "residual");

            gridGiacenza.TableStyles.Clear();
            HelpForm.SetDataGrid(gridGiacenza, TStockView);


            DataTable Tbooktotalview = Conn.RUN_SELECT("booktotalview", 
                                    "*", 
                                    "store asc,allocated desc",
                                QHS.AppAnd(QHS.MCmp(R, "idlist"), QHS.CmpGt("number", 0)),
                                null, false);
            Temp.Tables.Add(Tbooktotalview);
            ClearListType(Tbooktotalview);
            MetaData Mbooktotalview = MetaData.GetMetaData(this, "booktotalview");
            Mbooktotalview.DescribeColumns(Tbooktotalview, "list");
            gridPrenotazioni.TableStyles.Clear();
            CheckIntCol(Tbooktotalview, "number");
            CheckIntCol(Tbooktotalview, "allocated");
            CheckIntCol(Tbooktotalview, "booked");
            gridPrenotazioni.TableStyles.Clear();

            HelpForm.SetDataGrid(gridPrenotazioni, Tbooktotalview);

            //Accertarsi che ci sia il resp.
            DataTable Tmandatedetail_tostock = Conn.RUN_SELECT("mandatedetail_tostock", "*", "store asc,ntostock desc",
                               QHS.AppAnd(QHS.MCmp(R, "idlist"), QHS.CmpGt("ntostock", 0)),
                               null, false);
            Temp.Tables.Add(Tmandatedetail_tostock);
            MetaData Mmandatedetail_tostock  = MetaData.GetMetaData(this, "mandatedetail_tostock");
            Mmandatedetail_tostock.DescribeColumns(Tmandatedetail_tostock, "list");
            if (!HasP) {
                MetaData.DescribeAColumn(Tmandatedetail_tostock, "npackage", "", -1);
            }
            CheckIntCol(Tmandatedetail_tostock, "ordered");
            CheckIntCol(Tmandatedetail_tostock, "npackage");
            CheckIntCol(Tmandatedetail_tostock, "ntostock");
            gridordiniinevasi.TableStyles.Clear();
            HelpForm.SetDataGrid(gridordiniinevasi, Tmandatedetail_tostock);

            DataTable TLast5mandatedetail = Conn.SQLRunner(
                "select  top 5  MD.mandatekind,MD.yman,MD.nman,MD.registry, MD.npackage, "+
                "ROUND(MD.taxable_euro/MD.npackage,2) as amount, " +
                "MD.discount, ROUND(MD.ntostock/MD.unitsforpackage,2)as ntostock,S.adate ,P.description as package	from mandatedetail_tostock MD " +
	            "join mandate S on S.idmankind= MD.idmankind AND "+
		        "S.yman=MD.yman AND "+
				"S.nman=MD.nman  "+
                "join package P on MD.idpackage=P.idpackage "+
                "where MD.npackage>0 and "+QHS.CmpEq("MD.idlist",R["idlist"])+
	            " order by S.adate desc");
            Temp.Tables.Add(TLast5mandatedetail);
            int pos = 1;
            MetaData.DescribeAColumn(TLast5mandatedetail, "adate", "Data", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "mandatekind", "Tipo contratto", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "yman", "Es.Contratto", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "nman", "N.contratto", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "registry", "Fornitore", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "package", "Unità", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "npackage", "Ordinato", pos++);
            HelpForm.SetFormatForColumn(TLast5mandatedetail.Columns["npackage"], "n");
            MetaData.DescribeAColumn(TLast5mandatedetail, "ntostock", "Inevaso", pos++);
            HelpForm.SetFormatForColumn(TLast5mandatedetail.Columns["ntostock"], "n");
            MetaData.DescribeAColumn(TLast5mandatedetail, "amount", "Imponibile", pos++);
            MetaData.DescribeAColumn(TLast5mandatedetail, "discount", "Sconto", pos++);
            HelpForm.SetFormatForColumn(TLast5mandatedetail.Columns["discount"], "p");

            CheckIntCol(TLast5mandatedetail, "npackage");
            CheckIntCol(TLast5mandatedetail, "ntostock");

            gridLast5ordini.TableStyles.Clear();

            HelpForm.SetDataGrid(gridLast5ordini, TLast5mandatedetail);

            DataTable TLast5stock = Conn.SQLRunner(
                "select top 5 S.store, S.number, S.residual, ROUND((S.amount/S.number),5) as amount,"+
                "ROUND((S.amount/S.number)*L.unitsforpackage,5) as amount_p, S.adate,S.expiry, " +
                "S.mandatekind, S.yman,S.nman " +
                "from stockview S " +
                " join list L on S.idlist=L.idlist "+
                " where S.number>0 and "+QHS.CmpEq("S.idlist",R["idlist"])+
                " order by S.adate desc");
            Temp.Tables.Add(TLast5stock);
            ClearListType(TLast5stock);
            pos = 1;
            MetaData.DescribeAColumn(TLast5stock, "adate", "Data Arrivo", pos++);
            MetaData.DescribeAColumn(TLast5stock, "store", "Magazzino", pos++);
            MetaData.DescribeAColumn(TLast5stock, "number", "Caricati", pos++);
            MetaData.DescribeAColumn(TLast5stock, "residual", "Rimasti", pos++);
            if (HasP) {
                MetaData.DescribeAColumn(TLast5stock, "amount", "Costo unitario", pos++);
                HelpForm.SetFormatForColumn(TLast5stock.Columns["number"], "n5");
                MetaData.DescribeAColumn(TLast5stock, "amount_p", "Costo per confez.", pos++);
            }
            else {
                MetaData.DescribeAColumn(TLast5stock, "amount", "costo unitario", pos++);
                HelpForm.SetFormatForColumn(TLast5stock.Columns["number"], "c");
            }
            //HelpForm.SetFormatForColumn(TLast5stock.Columns["amount_p"], "c");

            HelpForm.SetFormatForColumn(TLast5stock.Columns["residual"], "n");
            if (chkDataScadenza.Checked)
                MetaData.DescribeAColumn(TLast5stock, "expiry", "Scadenza", pos++);
            else
                MetaData.DescribeAColumn(TLast5stock, "expiry", "", -1);

            MetaData.DescribeAColumn(TLast5stock, "mandatekind", "Tipo contr.", pos++);
            MetaData.DescribeAColumn(TLast5stock, "yman", "Eserc. contr.", pos++);
            MetaData.DescribeAColumn(TLast5stock, "nman", "N. contr.", pos++);


            CheckIntCol(TLast5stock, "number");
            CheckIntCol(TLast5stock, "residual");

            gridlast5load.TableStyles.Clear();
            HelpForm.SetDataGrid(gridlast5load, TLast5stock);

            DataTable TLast5unload = Conn.SQLRunner(
                "select top 5 store,adate,number,manager,U.description from storeunloaddetailview S " +
                "join list L on L.idlist=S.idlist " +
                "join unit U on L.idunit=U.idunit " +
                " where "+QHS.CmpEq("L.idlist",R["idlist"])+
                "order by S.adate desc ");
            Temp.Tables.Add(TLast5unload);
            pos = 1;
            MetaData.DescribeAColumn(TLast5unload, "adate", "Data", pos++);
            MetaData.DescribeAColumn(TLast5unload, "store", "Magazzino", pos++);
            MetaData.DescribeAColumn(TLast5unload, "number", "Scaricati", pos++);
            HelpForm.SetFormatForColumn(TLast5unload.Columns["number"], "n");
            MetaData.DescribeAColumn(TLast5unload, "description", "Unità", pos++);
            MetaData.DescribeAColumn(TLast5unload, "manager", "Responsabile", pos++);
            CheckIntCol(TLast5unload, "number");
            gridlast5unload.TableStyles.Clear();

            HelpForm.SetDataGrid(gridlast5unload, TLast5unload);
            string fstock=" where stock.idlist="+ QHS.quote(R["idlist"]) +
                            "and number<>0 and idinvkind is not null "+
                            "and datepart(year,adate)=accountingyear.ayear ";
                            
                            //QHS.CmpGe("datepart(year,adate)",
                            //        CfgFn.GetNoNullInt32(Conn.GetSys("esercizio"))-2));
            string sql = " select ayear, " +
                "  (select min(amount/number) from stock " + fstock + " ) as min_amount, " +
                "  (select max(amount/number) from stock " + fstock + " ) as max_amount," +
                "  ((select sum(amount) from stock " + fstock + ") /" +
                "   (select sum(number) from stock " + fstock + ")) as avg_amount, " +
                "  (select top 1 amount/number  from stock " + fstock +
                        "order by adate desc) as last_amount " +
                " from accountingyear where " +
                            QHS.Between("ayear",
                                    CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")) - 2,
                                    CfgFn.GetNoNullInt32(Conn.GetSys("esercizio")))+
                            " order by ayear desc";
            DataTable TPrices = Conn.SQLRunner(sql);
            decimal f = CfgFn.GetNoNullDecimal(
                Conn.DO_READ_VALUE("list", QHS.CmpEq("idlist", R["idlist"]), "unitsforpackage"));
            foreach (DataRow RR in TPrices.Select()) {
                RR["min_amount"] = CfgFn.Round(CfgFn.GetNoNullDecimal(RR["min_amount"]) * f, 2) ;
                RR["max_amount"] = CfgFn.Round(CfgFn.GetNoNullDecimal(RR["max_amount"]) * f, 2);
                RR["avg_amount"] = CfgFn.Round(CfgFn.GetNoNullDecimal(RR["avg_amount"]) * f, 2);
                RR["last_amount"] = CfgFn.Round(CfgFn.GetNoNullDecimal(RR["last_amount"]) * f, 2);
            }

            Temp.Tables.Add(TPrices);
            pos = 1;
            MetaData.DescribeAColumn(TPrices, "ayear", "Anno", pos++);
            MetaData.DescribeAColumn(TPrices, "min_amount", "Costo min", pos++);
            MetaData.DescribeAColumn(TPrices, "max_amount", "Costo_max", pos++);
            MetaData.DescribeAColumn(TPrices, "avg_amount", "Costo medio", pos++);
            MetaData.DescribeAColumn(TPrices, "last_amount", "Ultimo costo", pos++);
            HelpForm.SetDataGrid(gridlast5year, TPrices);

            decimal residual = MetaData.SumColumn(TStockView, "residual");
            decimal ntostock = MetaData.SumColumn(Tmandatedetail_tostock, "ntostock");
            decimal number   = MetaData.SumColumn(Tbooktotalview, "number");
            txtGiacenza.Text = "";
            if (residual > 0) txtGiacenza.Text = residual.ToString();
            txtOrdini.Text = "";
            if (ntostock > 0) txtOrdini.Text = ntostock.ToString();
            txtPrenotazioni.Text = "";
            if (number > 0) txtPrenotazioni.Text = number.ToString();

            SetGridStyle();
        }

        public void MetaData_AfterClear()
        {
            SetGrids();
            fileimmagine.Enabled = false;
            btnRimuoviImmagine.Enabled = false;
            txtGiacenza.Text = "";
            txtOrdini.Text = "";
            txtPrenotazioni.Text = "";
            EnableDisableCode();
            pbox.Image = null;

            //FreshLogo();
        
        }
        private void btnListClassCode_Click (object sender, EventArgs e) {
            string filter = "";
           
            if (chkListTitle.Checked) {
                FrmAskDescr FR = new FrmAskDescr(0);
                DialogResult D = FR.ShowDialog(this);
                if (D != DialogResult.OK) return;
                filter = GetData.MergeFilters(filter,
                    "(title like " + QueryCreator.quotedstrvalue(
                    "%" + FR.txtDescrizione.Text + "%", true)) + ")";
                MetaData.DoMainCommand(this, "choose.listclass.default." + filter);
                return;
            }
            //DS.listclass.ExtendedProperties[MetaData.ExtraParams] = filter;
            MetaData.DoMainCommand(this, "manage.listclass.tree");   
           }

        private void fileimmagine_Click(object sender, EventArgs e)
        {
			// apri il open file dialog
			SalvaLogo();
        }

        void SalvaLogo()
        {
            if (Meta.IsEmpty) return;
            if (!Meta.GetFormData(true)) return;
            opendlg.Filter = "Immagine Jpeg (*.jpg) |*.jpg|Immagine Gif (*.gif)|*.gif|Immagine Png (*.png)|*.png";
            DialogResult dialogResult = opendlg.ShowDialog(this);
            if (dialogResult == DialogResult.Cancel) return;
            //DataRow Curr = HelpForm.GetLastSelected(DS.list);
            DataRow Curr = DS.list.Rows[0];
            if (Curr == null) return;
            //txtNomeFile.Text = openFileDialog1.FileName;

            string filename = opendlg.FileName;
            string fileext = filename.Substring(filename.LastIndexOf(".")).Substring(1).ToLower();
            if (fileext != "gif" && fileext != "jpg" && fileext != "jpeg" && fileext != "png")
            {
                MessageBox.Show("E' possibile utilizzare soltanto i seguenti tipi: \r\n.jpg,.gif,.png", "Errore", MessageBoxButtons.OK);
                return;
            }


            FileStream FS = new FileStream(opendlg.FileName, FileMode.Open,
                FileAccess.Read);

            if (FS == null) return;
            int n = (int)FS.Length;
            if (n == 0) return;
            try
            {
                byte[] ByteArray = new byte[n];
                FS.Read(ByteArray, 0, n);
                if (FS.Length == 0)
                {
                    Curr["pic"] = DBNull.Value;
                }
                FS.Close();
                Curr["pic"] = ByteArray;
                Curr["picext"] = fileext;
            }
            catch { }
            FreshLogo();
            //	pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

        }

        void FreshLogo()
        {
            //Meta = MetaData.GetMetaData(this);
            //pictureBox1.Image=(byte[])(DS.logo[0]["logo"]);
            //DataRow Curr = HelpForm.GetLastSelected(DS.list);
            DataRow Curr = DS.list.Rows[0];

            if (Curr == null) return;

            try
            {
                if (Curr["pic"] != DBNull.Value)
                {
                    MemoryStream MS = new MemoryStream((byte[])Curr["pic"]);
                    Image IM = new Bitmap(MS, false);
                    pbox.Image = IM;
                }
                else
                {
                    pbox.Image = null;
                }
            }
            catch
            {
                pbox.Image = null;
            }
        }

        private void txtListino_TextChanged(object sender, EventArgs e) {

        }

        private void btnRimuoviImmagine_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.list.Rows[0];
            Curr["pic"] = DBNull.Value;
            FreshLogo();



        }



    }
}
