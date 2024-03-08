
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metadatalibrary;
using funzioni_configurazione;
using metaeasylibrary;
using System.IO;
using stockmail;

namespace stock_ddt_in {
    public partial class FrmStock_ddt_in : MetaDataForm {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        DataAccess Conn;
        public FrmStock_ddt_in() {
            InitializeComponent();
            HelpForm.SetDenyNull(DS.stock.Columns["flagto_unload"], true);
        }
        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            DataRow Source = Meta.SourceRow;
            if (CfgFn.GetNoNullInt32( Source.Table.Columns["idstoreload_motive"].DefaultValue) != 0) {
                labCausale.Visible = false;
                cmbCausaleCarico.Visible = false;
            }


        }
        public void MetaData_AfterPost() {
            if (DS.stock.Rows.Count == 0) return;
            StockSendMail SM = new StockSendMail(Conn);
            SM.getItemsFromStock(DS.stock.Rows[0]);
            SM.SendMailToBookers();
        }


        public void MetaData_AfterFill(){
            DataRow Curr = DS.stock.Rows[0];
            if (Meta.FirstFillForThisRow &&  Meta.EditMode) {
                object O = Conn.DO_READ_VALUE("stockview", QHS.CmpEq("idstock", Curr["idstock"]), "residual");
                if (O != null && O != DBNull.Value) {
                    decimal N = CfgFn.GetNoNullDecimal(O);
                    txtResidual.Text = N.ToString("n");
                }
            }

            int idlist = CfgFn.GetNoNullInt32( Curr["idlist"]);
            bool AbilitaListino = false;
            if (idlist >0){
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.listview, null, QHS.CmpEq("idlist", idlist), null, true);
                if (DS.listview.Rows.Count != 0){
                    riempiOggetti(DS.listview.Rows[0]);
                }
            }
            //Se c'è un documento collegato no si può modificare il listino.
            if ((Curr["idmankind"] == DBNull.Value) && (Curr["idinvkind"] == DBNull.Value)){
                AbilitaListino = true;
            }
            else{
                AbilitaListino = false;
            }
            EnabledDisableListino(AbilitaListino);

            if (Curr["idinvkind"] == DBNull.Value){
                AbilitaQuantita(true);
            }
            else{
                AbilitaQuantita(false);
            }

            CalcolaQuantitaConfezioni();
            //CalcolaCostoUnitario();

        }


        private void EnabledDisableListino(bool AbilitaListino){
            gboxListino.Enabled = AbilitaListino;
            //  Il codice è stato commentato perchè gestiva la modifica del MAGAZZINO del form principale e LISTINO nel dettaglio
            //  in modo asincrono, nel senso se veniva modificato uno l'altro veniva disabilitato e viceversa, 
            //  ma ora non ha può motivo di esistere, perchè :
            //  1) il listino è disabilitato se c'è un documento;
            //  2) il metodo EnabledDisableStoreRegistry() del form principale ddt_in_default() disabilita il combo del magazzino.
            //
            //if (!esistelistino){
            //    gboxListino.Enabled = false;
            //    return;
            //}

            //DataRow rDetail = Meta.SourceRow;
            //DataRow rMain = rDetail.GetParentRow("ddt_in_stock");
                                                  

            //if (rMain["idstore", DataRowVersion.Original].Equals(rMain["idstore", DataRowVersion.Current])){
            //    gboxListino.Enabled = true;
            //}
            //else{
            //    gboxListino.Enabled = false;
            //}
        }

        private void AbilitaQuantita(bool abilita){
            txtQuantita.Enabled = abilita;
            txtQuantitaConfezioni.Enabled = abilita;
        }

        private void riempiOggetti(DataRow listRow){
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";
            bool has_expiry = (listRow["has_expiry"].ToString() != "S") ? false : true;
            
            if (!has_expiry)
            {
                lblScadenza.Visible = false;
                txtValiditystop.Visible = false;
            }
            else
            {
                lblScadenza.Visible = true;
                txtValiditystop.Visible = true;
            }
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.unit, null, QHS.CmpEq("idunit", listRow["idunit"]), null, true);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraCS, listRow["idunit"]);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.package, null, QHS.CmpEq("idpackage", listRow["idpackage"]), null, true);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraAcquisto, listRow["idpackage"]);

            if (listRow["idunit"] != DBNull.Value)
            {
                string UnitaCarico = listRow["unit"].ToString();
                lblQuantita.Text = "N. " + UnitaCarico;
            }
            else
            {
                lblQuantita.Text = "Quantità";
            }
            if (listRow["idpackage"] != DBNull.Value)
            {
                string UnitaAcquisto = listRow["package"].ToString();
                lblQuantitaConfezioni.Text = "N. " + UnitaAcquisto;
            }
            else
            {
                lblQuantitaConfezioni.Text = "Quantità totale";
            }
            FreshLogo(listRow);

        }

        void FreshLogo(DataRow listRow)
        {
            //Meta = MetaData.GetMetaData(this);
            //pictureBox1.Image=(byte[])(DS.logo[0]["logo"]);
            //DataRow Curr = HelpForm.GetLastSelected(DS.list);

            if (listRow == null) return;

            try
            {
                if (listRow["pic"] != DBNull.Value)
                {
                    MemoryStream MS = new MemoryStream((byte[])listRow["pic"]);
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

        private void svuotaOggetti(){
            txtDescrizioneListino.Text = "";
            txtCoeffConversione.Text = "";
            lblQuantitaConfezioni.Text = "Quantità totale";
            lblQuantita.Text = "Quantità";

            DS.unit.Clear();
            //if (cmbUnitaMisuraCS.SelectedIndex > 0)
            //{
            //    cmbUnitaMisuraCS.SelectedIndex = -1;
            //}
            DS.package.Clear();
            //if (cmbUnitaMisuraAcquisto.SelectedIndex > 0)
            //{
            //    cmbUnitaMisuraAcquisto.SelectedIndex = -1;
            //}

            if ((!MetaData.Empty(this))){
                DS.stock.Rows[0]["idlist"] = DBNull.Value;
            }
        }

        private void btnListino_Click(object sender, EventArgs e){
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.stock.Rows[0];
            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;

            Curr["idlist"] = Choosen["idlist"];

            riempiOggetti(Choosen);

            return;
        }

        private void txtListino_Leave(object sender, EventArgs e){
            if (txtListino.Text == ""){
                svuotaOggetti();
                return;
            }
            if (DS.stock.Rows.Count == 0) return;
            if (!Meta.DrawStateIsDone) return;

            string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));

            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));

            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;
            DataRow Curr = DS.stock.Rows[0];
            Curr["idlist"] = Choosen["idlist"];

            riempiOggetti(Choosen);

            return;
        }

        private void txtquantitatotale_Leave(object sender, EventArgs e){
            if (!Meta.DrawStateIsDone) return;
            CalcolaQuantitaUnitaria();
            //CalcolaCostoTotale();
       }

        ///// <summary>
        ///// calcola costo unitario * quantità unitaria
        ///// </summary>
        //private void CalcolaCostoTotale(){
        //    decimal quantita = CfgFn.GetNoNullDecimal(txtQuantita.Text);
        //    if (quantita == 0){
        //        txtCostoTotale.Text = HelpForm.StringValue(quantita, "x.y.fixed.2...1");
        //        return;
        //    }
        //    decimal CostoUnitario = CfgFn.GetNoNullDecimal(txtCostoUnitario.Text);
        //    decimal CostoTotale = CfgFn.RoundValuta(CostoUnitario * CfgFn.GetNoNullDecimal(txtQuantita.Text));
        //    txtCostoTotale.Text = HelpForm.StringValue(CostoTotale, "x.y.fixed.2...1");
        //}

        /// <summary>
        /// calcola la q. unitaria in base a quella in confezioni
        /// </summary>
        private void CalcolaQuantitaUnitaria(){
            decimal npackage = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtQuantitaConfezioni.Text, null));
            txtQuantitaConfezioni.Text = HelpForm.StringValue(npackage, "x.y.fixed.2...1");
            decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(txtQuantitaConfezioni.Text);
            if (quantitaConfezioni == 0){
                txtQuantita.Text = HelpForm.StringValue(quantitaConfezioni, "x.y.fixed.2...1"); 
                return;
            }

            int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
            if (unitsforpackage == 0)
                unitsforpackage = 1;
            decimal number = npackage * unitsforpackage;
            txtQuantita.Text = HelpForm.StringValue(number, "x.y.fixed.2...1"); 
        }

        private void textQuantita_Leave(object sender, EventArgs e){
            //CalcolaQuantitaConfezioni();
        }

        /// <summary>
        /// Calcola il n. confezioni a partire dalla quantità
        /// </summary>
        private void CalcolaQuantitaConfezioni(){
            decimal quantita=CfgFn.GetNoNullDecimal(txtQuantita.Text);
            if (quantita==0){
                txtQuantitaConfezioni.Text = HelpForm.StringValue(quantita, "x.y.fixed.2...1");
                return; 
            }

            decimal number = CfgFn.GetNoNullDecimal(txtQuantita.Text);
            int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
            if (unitsforpackage == 0)
                unitsforpackage = 1;
            decimal npackage = number / unitsforpackage;
            txtQuantitaConfezioni.Text = HelpForm.StringValue(npackage, "x.y.fixed.2...1"); 
        }

        ///// <summary>
        ///// Calcola costo totale / quantità in unità
        ///// </summary>
        //private void CalcolaCostoUnitario(){
        //    decimal quantita = CfgFn.GetNoNullDecimal(txtQuantita.Text);
        //    if (quantita == 0){
        //        txtCostoUnitario.Text = HelpForm.StringValue(quantita, "x.y.fixed.2...1"); 
        //        return;
        //    }
        //    decimal CostoTotale = CfgFn.GetNoNullDecimal(txtCostoTotale.Text);
        //    decimal CostoUnitario = CfgFn.Round(CostoTotale / CfgFn.GetNoNullDecimal(txtQuantita.Text),5);
        //    txtCostoUnitario.Text = HelpForm.StringValue(CostoUnitario, "x.y.fixed.5...1");
        //}


    }
}
