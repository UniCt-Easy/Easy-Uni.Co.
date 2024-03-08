
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
using System.IO;
using stockmail;

namespace stock_default{
    public partial class Frm_stock_default : MetaDataForm {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        DataAccess Conn;
        public Frm_stock_default(){
            InitializeComponent();
        }

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            HelpForm.SetDenyNull(DS.stock.Columns["flagto_unload"], true);
            HelpForm.SetDenyNull(DS.stock.Columns["amount"], true);
        }
        public void MetaData_AfterClear(){
            svuotaOggetti();
            AbilitaTutto(true);
            AbilitaQuantita(true);
            txtQuantitaConfezioni.Text = "";
            txtCostoUnitario.Text = "";
            AbilitaMagazzino(true);
            AbilitaBolla(true);
            AbilitaOrdine(true);
            AbilitaFattura(true);
            pbox.Image = null;
            chkListDescription.Checked = false;

        }
        public void MetaData_AfterPost() {
            if (DS.stock.Rows.Count == 0) return;
            StockSendMail SM = new StockSendMail(Conn);
            SM.getItemsFromStock(DS.stock.Rows[0]);
            SM.SendMailToBookers();
        }


        private void AbilitaBolla(bool enable){
            grpBollaIngresso.Enabled = enable;
        }

        private void AbilitaOrdine(bool enable){
            grpOrdine.Enabled = enable;
        }

        private void AbilitaFattura(bool enable){
            grpFattura.Enabled = enable;
        }


        public void MetaData_AfterFill(){
            DataRow Curr = DS.stock.Rows[0];
            int idlist = CfgFn.GetNoNullInt32(Curr["idlist"]);
            if (idlist > 0){
                DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.listview, null, QHS.CmpEq("idlist", idlist), null, true);
                if (DS.listview.Rows.Count != 0){
                    riempiOggetti(DS.listview.Rows[0]);
                }
            }

            if ((Curr["idmankind"] == DBNull.Value) && (Curr["idinvkind"]==DBNull.Value)){
                AbilitaTutto(true);
            }
            else{
                AbilitaTutto(false);
            }

            if (Curr["idinvkind"] == DBNull.Value){
                AbilitaQuantita(true);
            }
            else
            {
                AbilitaQuantita(false);
            }

            CalcolaQuantitaConfezioni();
            CalcolaCostoUnitario();
            int idddt_in = CfgFn.GetNoNullInt32(Curr["idddt_in"]);
            if (idddt_in > 0){
                AbilitaCausale(false);
            }
            else{
                AbilitaCausale(true);
            }
            if ((idddt_in == 0) && (Curr["idmankind"] == DBNull.Value)){
            //In stock default, l'idstore, deve essere abilitato solo se non sta né nella bolla né nel contratto passivo, perchè
            //in fattura viene valorizzato al volo e poi da stock deve essere possibile modificarlo.
                AbilitaMagazzino(true);
            }
            else{
                AbilitaMagazzino(false);
            }
            AbilitaBolla(false);
            AbilitaOrdine(false);
            AbilitaFattura(false);
        }

        void FreshLogo(DataRow listRow)
        {


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

        private void AbilitaCausale(bool Abilita){
            // La causale di carico è modificabile se non c'è la Bolla.
            cmbCausaleCarico.Enabled = Abilita;
        }

        private void AbilitaMagazzino(bool Abilita){
            cmbMagazzino.Enabled = Abilita;
        }
        private void AbilitaQuantita(bool Abilita){
            txtQuantita.Enabled = Abilita;
            txtQuantitaConfezioni.Enabled = Abilita;
        }

        private void AbilitaCostoTotale(bool abilita) {
            txtCostoTotale.Enabled = abilita;
            //txtCostoUnitario.Enabled = abilita;
        }

        private void AbilitaTutto(bool abilita){
            gboxListino.Enabled = abilita;
            txtCostoTotale.Enabled = abilita;
            txtCostoUnitario.Enabled = abilita;
        }

        private void riempiOggetti(DataRow listRow)
        {
            txtListino.Text = (listRow != null) ? listRow["intcode"].ToString() : "";
            txtDescrizioneListino.Text = (listRow != null) ? listRow["description"].ToString() : "";
            txtCoeffConversione.Text = (listRow != null) ? listRow["unitsforpackage"].ToString() : "";

            if (listRow["has_expiry"].ToString() == "N")
            {
                lblScadenza.Visible = false;
                txtValiditystop.Visible = false;
            }
            else
            {
                lblScadenza.Visible = true;
                txtValiditystop.Visible = true;
                //txtValiditystop.Text = HelpForm.StringValue(listRow["validitystop"], txtValiditystop.Tag.ToString());
            }
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.unit, null, QHS.CmpEq("idunit", listRow["idunit"]), null, true);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraCS, listRow["idunit"]);
            DataAccess.RUN_SELECT_INTO_TABLE(Meta.Conn, DS.package, null, QHS.CmpEq("idpackage", listRow["idpackage"]), null, true);
            HelpForm.SetComboBoxValue(cmbUnitaMisuraAcquisto, listRow["idpackage"]);

            if (listRow["idunit"] != DBNull.Value){
                string UnitaCarico = listRow["unit"].ToString();
                lblQuantita.Text = "N. " + UnitaCarico;
            }
            else{
                lblQuantita.Text = "Quantità";
            }
            if (listRow["idpackage"] != DBNull.Value){
                string UnitaAcquisto = listRow["package"].ToString();
                lblQuantitaConfezioni.Text = "N. " + UnitaAcquisto;
            }
            else{
                lblQuantitaConfezioni.Text = "Quantità totale";
            }
            FreshLogo(listRow);

        }
        private void svuotaOggetti(){
            txtDescrizioneListino.Text = "";
            txtCoeffConversione.Text = "";
            lblQuantitaConfezioni.Text = "Quantità totale";
            lblQuantita.Text = "Quantità";

            if (cmbUnitaMisuraCS.SelectedIndex >= 0){
                cmbUnitaMisuraCS.SelectedIndex = -1;
            }
            if (cmbUnitaMisuraAcquisto.SelectedIndex >= 0){
                cmbUnitaMisuraAcquisto.SelectedIndex = -1;
            }

            if ((!MetaData.Empty(this))){
                DS.stock.Rows[0]["idlist"] = DBNull.Value;
            }
        }

        /// <summary>
        /// Calcola Quantità unitaria come q.confezioni* unità per confezione
        /// </summary>
        private void CalcolaQuantitaUnitaria(){
            if (Meta.IsEmpty) return;
            decimal npackage = CfgFn.GetNoNullDecimal(HelpForm.GetObjectFromString(typeof(decimal), txtQuantitaConfezioni.Text, null));
            txtQuantitaConfezioni.Text = HelpForm.StringValue(npackage, "x.y.fixed.2...1");
            decimal quantitaConfezioni = CfgFn.GetNoNullDecimal(txtQuantitaConfezioni.Text);
            if (quantitaConfezioni == 0)
            {
                txtQuantita.Text = HelpForm.StringValue(quantitaConfezioni, "x.y.fixed.2...1");
                return;
            }

            int unitsforpackage = CfgFn.GetNoNullInt32(txtCoeffConversione.Text);
            if (unitsforpackage == 0)
                unitsforpackage = 1;
            decimal number = npackage * unitsforpackage;
            txtQuantita.Text = HelpForm.StringValue(number, "x.y.fixed.2...1");
        }

        /// <summary>
        /// Calcola q. confezioni come q.totale  / unità per confezione
        /// </summary>
        private void CalcolaQuantitaConfezioni(){
            if (Meta.IsEmpty) return;
            decimal quantita = CfgFn.GetNoNullDecimal(txtQuantita.Text);
            if (quantita == 0){
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

        /// <summary>
        /// Calcola costo unitario come costo totale / quantità unitaria
        /// </summary>
        private void CalcolaCostoUnitario(){
            
            decimal quantita = CfgFn.GetNoNullDecimal(txtQuantita.Text);
            if (quantita == 0){
                txtCostoUnitario.Text = HelpForm.StringValue(quantita, "x.y.fixed.2...1");
                return;
            }
            decimal CostoTotale = CfgFn.GetNoNullDecimal(txtCostoTotale.Text);
            decimal CostoUnitario = CfgFn.Round(CostoTotale / CfgFn.GetNoNullDecimal(txtQuantita.Text),5);
            txtCostoUnitario.Text = HelpForm.StringValue(CostoUnitario, "x.y.fixed.5...1");
        }

        /// <summary>
        /// Calcola costo totale come costo unitario * quantità totale
        /// </summary>
        private void CalcolaCostoTotale(){
            decimal quantita = CfgFn.GetNoNullDecimal(txtQuantita.Text);
            if (quantita == 0){
                txtCostoTotale.Text = HelpForm.StringValue(quantita, "x.y.fixed.2...1");
                return;
            }
            decimal CostoUnitario = CfgFn.GetNoNullDecimal(txtCostoUnitario.Text);
            decimal CostoTotale = CfgFn.RoundValuta(CostoUnitario*CfgFn.GetNoNullDecimal(txtQuantita.Text));
            txtCostoTotale.Text = HelpForm.StringValue(CostoTotale, "x.y.fixed.2...1");
        }


        private void txtListino_Leave(object sender, EventArgs e){
            if (txtListino.Text == ""){
                svuotaOggetti();
                return;
            }

            string filter = "";
            if (Meta.InsertMode || Meta.EditMode){
                filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
            }
            string IntCode = txtListino.Text;
            if (!IntCode.EndsWith("%")) IntCode += "%";
            filter = GetData.MergeFilters(filter, QHS.Like("intcode", IntCode));

            MetaData Mlistino = MetaData.GetMetaData(this, "listview");
            Mlistino.FilterLocked = true;
            Mlistino.DS = DS.Clone();

            DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
            if (Choosen == null) return;
            riempiOggetti(Choosen);

            if (DS.stock.Rows.Count == 0) return;
            if (!Meta.DrawStateIsDone) return;
            
            DataRow Curr = DS.stock.Rows[0];
            Curr["idlist"] = Choosen["idlist"];

            

            return;


        }

        private void txtQuantitaConfezioni_Leave(object sender, EventArgs e){
            if (!Meta.DrawStateIsDone) return;
            if (txtQuantitaConfezioni.ReadOnly) return; 
            CalcolaQuantitaUnitaria();
            CalcolaCostoUnitario();
            //CalcolaCostoTotale();
        }

        private void txtQuantita_Leave(object sender, EventArgs e){
            if (!Meta.DrawStateIsDone) return;
            if (txtQuantita.ReadOnly) return;
            CalcolaQuantitaConfezioni();

            CalcolaCostoUnitario();
        }

        private void btnListino_Click(object sender, EventArgs e){
                string filter = QHS.DoPar(QHS.AppOr(QHS.IsNull("validitystop"), QHS.CmpGe("validitystop", Meta.GetSys("datacontabile"))));
                MetaData Mlistino = MetaData.GetMetaData(this, "listview");
                Mlistino.FilterLocked = true;
                Mlistino.DS = DS.Clone();

                if (chkListDescription.Checked) {
                    FrmAskDescr FR = new FrmAskDescr(Meta.Dispatcher);
                    createForm(FR, this);
                    DialogResult D = FR.ShowDialog(this);
                    if (D != DialogResult.OK)
                        return;
                    if (FR.Selected != null) {
                        object idlistclass = FR.Selected["idlistclass"];
                        filter = QHS.AppAnd(filter, QHS.CmpEq("idlistclass", FR.Selected["idlistclass"]));
                    }
                    if (FR.txtDescrizione.Text != "") {
                        string Description = FR.txtDescrizione.Text;
                        if (!Description.EndsWith("%"))
                            Description += "%";
                        if (!Description.StartsWith("%"))
                            Description = "%" + Description;
                        filter = QHS.AppAnd(filter, QHS.Like("description", Description));
                    }
                }

                DataRow Choosen = Mlistino.SelectOne("default", filter, "listview", null);
                if (Choosen == null) return;

                riempiOggetti(Choosen);

                if (Meta.IsEmpty) return;

                DataRow Curr = DS.stock.Rows[0];
                Curr["idlist"] = Choosen["idlist"];
        }

        private void txtCostoTotale_Leave(object sender, EventArgs e){
            if (!Meta.DrawStateIsDone) return;
            CalcolaCostoUnitario();


        }

        private void txtQuantita_TextChanged(object sender, EventArgs e){
            //if (!Meta.DrawStateIsDone) return;
            //CalcolaCostoUnitario();
        }




    }
}
