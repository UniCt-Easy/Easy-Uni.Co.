
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
using stockmail;

namespace ddt_in_default {
    public partial class frmddt_in_default : MetaDataForm {
        MetaData Meta;
        CQueryHelper QHC;
        QueryHelper QHS;
        DataAccess Conn;
        public frmddt_in_default() {
            InitializeComponent();
        }
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn= Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();
            //DataAccess.SetTableForReading(DS.ivakind, "ivakind");
            //DataAccess.SetTableForReading(DS.mandatekind, "mandatekind");
        }


        public void MetaData_AfterPost() {
            if (DS.ddt_in.Rows.Count==0) return;
            StockSendMail SM = new StockSendMail(Conn);
            SM.getItemsFromDDT_IN(DS.ddt_in.Rows[0]);
            SM.SendMailToBookers();
        }
        public void MetaData_AfterClear () {
            cmbMagazzino.Enabled = true;
            txtCredDeb.Enabled = true;
            SetDefaultForIdstoreload_motive();
        }
        void SetDefaultForIdstoreload_motive() {
            if (Meta.IsEmpty) {
                MetaData.SetDefault(DS.stock, "idstoreload_motive", DBNull.Value);
                return;
            }
            object idddt_in_motive = cmbCausale.SelectedValue;
            if (cmbCausale.SelectedIndex<=0 || idddt_in_motive == null || 
                        idddt_in_motive == DBNull.Value) {
                MetaData.SetDefault(DS.stock, "idstoreload_motive", DBNull.Value);
                return;
            }
            DataRow Rddt_in_motive = DS.ddt_in_motive.Select(
                QHC.CmpEq("idddt_in_motive", idddt_in_motive))[0];
            MetaData.SetDefault(DS.stock, "idstoreload_motive", Rddt_in_motive["idstoreload_motive"]);


        }
        public void MetaData_AfterFill(){
            SetDefaultForIdstoreload_motive();
            object curridstore = (cmbMagazzino.SelectedValue != null) ? cmbMagazzino.SelectedValue : DBNull.Value;
            DataRow rStore = null;
            if (curridstore != DBNull.Value && curridstore.ToString() != ""){
                rStore = DS.store.Select(QHC.CmpEq("idstore", curridstore))[0];
            }

            if (!Meta.IsEmpty) {
                if (rStore != null){
                    int idstore = CfgFn.GetNoNullInt32(rStore["idstore"]);
                    MetaData.SetDefault(DS.stock, "idstore", idstore);
                    }
                }

            object currdddt_in_motive = (cmbCausale.SelectedValue != null) ? cmbCausale.SelectedValue : DBNull.Value;
            DataRow Rddt_in_motive = null;
            if (currdddt_in_motive != DBNull.Value && currdddt_in_motive.ToString() != ""){
                Rddt_in_motive = DS.ddt_in_motive.Select(QHC.CmpEq("idddt_in_motive", currdddt_in_motive))[0];
            }

            if (!Meta.IsEmpty){
                if (Rddt_in_motive != null){
                    int idstoreload_motive = CfgFn.GetNoNullInt32(Rddt_in_motive["idstoreload_motive"]);
                    MetaData.SetDefault(DS.stock, "idstoreload_motive", idstoreload_motive);
                    HelpForm.SetComboBoxValue(cmbCausaleCarico, Rddt_in_motive["idstoreload_motive"]);
                }
            }

            if (Meta.EditMode){
                EnableDisableMagazzino();
            }
            if (!Meta.IsEmpty) {
                EnabledDisableStoreRegistry();
            }
        }

        private void EnabledDisableStoreRegistry () {
            if ((Meta.IsEmpty)||(DS.stock.Rows.Count == 0)) {
                cmbMagazzino.Enabled = true;
                txtCredDeb.Enabled = true;
            }
            else {
                cmbMagazzino.Enabled = false;
                if (DS.stock.Select(QHC.AppOr(QHC.IsNotNull("idmankind"), QHC.IsNotNull("idinvkind"))).Length > 0)
                    txtCredDeb.Enabled = false;
                else
                    txtCredDeb.Enabled = true;
            }
        }

        private void EnableDisableMagazzino(){
            if (DS.stock.Select().Length == 0){
                cmbMagazzino.Enabled = true;
                return;
            }

            Meta.GetFormData(true);
            PostData.RemoveFalseUpdates(DS);
            object curridstore = (cmbMagazzino.SelectedValue != null) ? cmbMagazzino.SelectedValue : DBNull.Value;
            if (DS.HasChanges() && (CfgFn.GetNoNullInt32(curridstore) != 0)){
                    cmbMagazzino.Enabled = false;
                    return;
                }

            cmbMagazzino.Enabled = true;
        }

        public void MetaData_AfterRowSelect(DataTable T, DataRow R){
            if (T.TableName == "ddt_in_motive"){
                if (!Meta.DrawStateIsDone) return;
                if (Meta.IsEmpty) return;
                if (R == null){
                    if (cmbCausaleCarico.SelectedIndex > 0){
                        cmbCausaleCarico.SelectedIndex = -1;
                    }
                    // Pulisce anche i dettagli
                    //foreach (DataRow Dett in DS.stock.Rows){
                    //   Dett["idstoreload_motive"] = DBNull.Value;
                    //}
                    MetaData.SetDefault(DS.stock, "idstoreload_motive", DBNull.Value);
                    
                    return;
                }
                if (R["idstoreload_motive"] == DBNull.Value){
                    if (cmbCausaleCarico.SelectedIndex > 0){
                        cmbCausaleCarico.SelectedIndex = -1;
                    }
                    MetaData.SetDefault(DS.stock, "idstoreload_motive", DBNull.Value);
                }
                else{
                    HelpForm.SetComboBoxValue(cmbCausaleCarico, R["idstoreload_motive"]);
                    // Ora opera sui dettagli
                    object idstoreload_motive_selected = R["idstoreload_motive"];
                    foreach (DataRow Dett in DS.stock.Rows) {
                        if (!Dett["idstoreload_motive"].Equals(idstoreload_motive_selected))
                            Dett["idstoreload_motive"] = idstoreload_motive_selected;
                    }
                    MetaData.SetDefault(DS.stock, "idstoreload_motive", idstoreload_motive_selected);
                }
            }

            if (T.TableName == "store"){
                if (!Meta.DrawStateIsDone) return;
                if (R == null){
                    if (cmbMagazzino.SelectedIndex > 0){
                        cmbMagazzino.SelectedIndex = -1;
                    }
                    // Pulisce anche i dettagli
                    foreach (DataRow Dett in DS.stock.Rows){
                        Dett["idstore"] = DBNull.Value;
                    }
                    MetaData.SetDefault(DS.stock, "idstore", DBNull.Value);
                    
                    return;
                }
                if ((Meta.InsertMode)|| (Meta.EditMode)){
                    //aggiorno il codice del magazzino dei dettagli
                    object idstore_selected = R["idstore"];
                    DataRow Curr = DS.ddt_in.Rows[0];
                    Curr["idstore"] = idstore_selected;

                    foreach (DataRow Dett in DS.stock.Rows){
                        if (!Dett["idstore"].Equals(idstore_selected))
                            Dett["idstore"] = idstore_selected;
                    }
                    MetaData.SetDefault(DS.stock, "idstore", idstore_selected);
                }
            }


        }

        

        string CalculateFilterForLinking(bool SQL) {
            QueryHelper qh = SQL ? QHS : QHC;
            string MyFilter = "";

            object idreg = DS.ddt_in.Rows[0]["idreg"];
            object idstore = DS.ddt_in.Rows[0]["idstore"];

            //MyFilter = qh.AppAnd(qh.IsNull("idddt_in"), qh.IsNotNull("idlist")) ;
            MyFilter = qh.IsNotNull("idlist");
            if (idreg!=DBNull.Value) MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idreg", idreg));
            if (idstore!=DBNull.Value) MyFilter = qh.AppAnd(MyFilter, qh.CmpEq("idstore", idstore));

            MyFilter = qh.AppAnd(MyFilter, qh.NullOrEq("isrequest", "N"));
            return MyFilter;
        }

        //Copia i valori di ddt_in nelle righe di stock dipendenti
        public void UniformaDettagli() {
            if (Meta.IsEmpty) return;
            DataRow Curr = DS.ddt_in.Rows[0];
            object idstoreload_motive=DBNull.Value;
            if (Curr["idddt_in_motive"] != DBNull.Value) {
                DataRow RSL = DS.ddt_in_motive.Select(QHC.CmpEq("idddt_in_motive", Curr["idddt_in_motive"]))[0];
                idstoreload_motive = RSL["idstoreload_motive"];
            }
            foreach (DataRow R in DS.stock.Select()) {
                R["idstore"] = Curr["idstore"];
                if (idstoreload_motive != DBNull.Value) R["idstoreload_motive"] = idstoreload_motive;
            }
        }

        private void btnAggiungiDaOrdini_Click(object sender, EventArgs e) {
            if (Meta.IsEmpty) return;
            Meta.GetFormData(true);

            DataRow Rddt_in = DS.ddt_in.Rows[0];
            if (CfgFn.GetNoNullInt32(Rddt_in["idreg"]) == 0){
                show("Selezionare prima il fornitore.");
                return;
            }

            if (CfgFn.GetNoNullInt32(Rddt_in["idstore"]) == 0){
                show("Selezionare il magazzino.");
                return;
            }


            string filter = CalculateFilterForLinking(true);
            FrmSelectDetails F = new FrmSelectDetails(Meta, filter,DS);
            createForm(F, this);
            if (F.ShowDialog(this) != DialogResult.OK) return;
            DataRow []Selected = F.GetSelectedRows();
            if (Selected == null) return;
            if (Selected.Length == 0) return;
            MetaData MStock = MetaData.GetMetaData(this, "stock");
            MStock.SetDefaults(DS.stock);
            DataRow Curr= DS.ddt_in.Rows[0];
            foreach (DataRow R in Selected) {
                DataRow RS;
                string fltorder = QHC.AppAnd(QHC.MCmp(R, new string[] { "idmankind", "yman", "nman" }),
                            QHC.CmpEq("man_idgroup", R["idgroup"]));
                if (DS.stock.Select(fltorder).Length > 0) {
                    RS = DS.stock.Select(fltorder)[0];
                    RS["number"] = CfgFn.GetNoNullDecimal(RS["number"])+CfgFn.GetNoNullDecimal( R["ntostock"]);
                }
                else {
                    RS = MStock.Get_New_Row(Curr, DS.stock);
                    string[] fields = new string[] { "idlist", "idmankind", "yman", "nman","flagto_unload" };
                    foreach (string field in fields) {
                        RS[field] = R[field];
                    }
                    RS["man_idgroup"] = R["idgroup"];
                    RS["number"] = R["ntostock"];
                    RS["!codiceinterno"] = R["intcode"];
                    RS["!unitacarico"] = R["unit"];
                    decimal npackage = CfgFn.GetNoNullDecimal(RS["number"]) / CfgFn.GetNoNullDecimal(R["unitsforpackage"]);
                    //RS["amount"] = CostoTotale(R, CfgFn.GetNoNullDecimal(RS["number"]),npackage);
                }
                
            }
            UniformaDettagli();


        }


        //decimal calcolaIvaIndetraibileDaOrdine(DataRow rMandatedetail_tostock){
        //    int esercizio = CfgFn.GetNoNullInt32(Meta.GetSys("esercizio"));
        //    string filtro = QHS.AppAnd(QHS.CmpEq("flagmixed", rMandatedetail_tostock["flagmixed"]), QHC.CmpEq("ayear", esercizio));

        //    object OabatableRate = Meta.Conn.DO_READ_VALUE("invoicekindyearview", filtro, "TOP 1 abatablerate");
        //    double abatableRate = 1;
        //    if ((OabatableRate != null) && (OabatableRate != DBNull.Value)){
        //        abatableRate = CfgFn.GetNoNullDouble(OabatableRate);
        //    }

        //    decimal ivaDetraibile = CfgFn.RoundValuta(CfgFn.RoundValuta((CfgFn.GetNoNullDecimal(rMandatedetail_tostock["tax"])
        //        - CfgFn.GetNoNullDecimal(rMandatedetail_tostock["unabatable"]))) * (decimal)abatableRate);

        //    return CfgFn.GetNoNullDecimal(rMandatedetail_tostock["tax"])-CfgFn.RoundValuta(ivaDetraibile);
        //}

        //public decimal CostoTotale(DataRow rSelected, decimal number,decimal npackage){

        //    decimal imposta = calcolaIvaIndetraibileDaOrdine(rSelected);

        //    decimal imponibile = CfgFn.GetNoNullDecimal(rSelected["taxable"]);
        //    //decimal quantita = CfgFn.GetNoNullDecimal(rSelected["npackage"]);
        //    decimal sconto = CfgFn.GetNoNullDecimal(rSelected["discount"]);
        //    decimal imponibiletot = CfgFn.RoundValuta(imponibile * (1 - sconto)) * npackage;


        //    decimal q_ordine = CfgFn.GetNoNullDecimal(rSelected["number"]);
        //    decimal quota_imposta = CfgFn.RoundValuta((imposta * number) / q_ordine);

        //    decimal costo = quota_imposta + imponibiletot;

        //    return costo;
        //}

        public void MetaData_AfterGetFormData() {
            UniformaDettagli();
        }
    }
}
