/*
    Easy
    Copyright (C) 2020 Università degli Studi di Catania (www.unict.it)
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
using ep_functions;

namespace provision_default
{
    public partial class Frm_provision_default : Form
    {
        MetaData Meta;
        DataAccess Conn;
        CQueryHelper QHC;
        QueryHelper QHS;
        public Frm_provision_default(){
            InitializeComponent();
       
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing){
            if (disposing){
                if (components != null){
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        public void MetaData_AfterClear(){
            Meta.CanCancel = true;
            EPM.mostraEtichette();

        }

        public void MetaData_BeforePost() {

            EPM.beforePost();
        }

        public void MetaData_AfterPost() {
            EPM.afterPost();
        }
        public void MetaData_BeforeFill() {
            if (EPM.esistonoScrittureCollegate()) Meta.CanCancel = false;
        }
        public void MetaData_AfterFill() {

            EPM.mostraEtichette();
        }


        private Decimal CK(Object O) {
            if (O == DBNull.Value) return 0;
            return CfgFn.GetNoNullDecimal(O);
        }
       

        private EP_Manager EPM;

        public void MetaData_AfterLink(){
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHS = Meta.Conn.GetQueryHelper();
            QHC = new CQueryHelper();
            DataAccess.SetTableForReading(DS.sorting01, "sorting");
            DataAccess.SetTableForReading(DS.sorting02, "sorting");
            DataAccess.SetTableForReading(DS.sorting03, "sorting");
            DataAccess.SetTableForReading(DS.sorting04, "sorting");
            DataAccess.SetTableForReading(DS.sorting05, "sorting");

            EPM = new EP_Manager(Meta, btnGeneraEpExp, btnVisualizzaEpExp, btnGeneraPreimpegni, btnVisualizzaPreimpegni,
                btnGeneraEP, btnVisualizzaEP,

                labEP, labAltroEsercizio, "provision");

            DataTable tUniConfig = Conn.RUN_SELECT("uniconfig", "*", null, null, null, null, true);
            if ((tUniConfig != null) && (tUniConfig.Rows.Count > 0)){
                DataRow r = tUniConfig.Rows[0];
                object idsorkind1 = r["idsorkind01"];
                object idsorkind2 = r["idsorkind02"];
                object idsorkind3 = r["idsorkind03"];
                object idsorkind4 = r["idsorkind04"];
                object idsorkind5 = r["idsorkind05"];
                CfgFn.SetGBoxClass0(this,1, idsorkind1);
                CfgFn.SetGBoxClass0(this, 2, idsorkind2);
                CfgFn.SetGBoxClass0(this, 3, idsorkind3);
                CfgFn.SetGBoxClass0(this, 4, idsorkind4);
                CfgFn.SetGBoxClass0(this, 5, idsorkind5);
                if (idsorkind1 == DBNull.Value && idsorkind2 == DBNull.Value &&
                    idsorkind3 == DBNull.Value && idsorkind4 == DBNull.Value && idsorkind5 == DBNull.Value)
                {
                    MetaDataDetail.TabPages.Remove(tabAttributi);
                }
            }
            HelpForm.SetDenyNull(DS.provision.Columns["description"],true);
            string filterEpOperationPatrim = QHS.CmpEq("idepoperation", "fondo_accantonamento");
            string filterEpOperationCosto = QHS.CmpEq("idepoperation", "costo_accantonamento");
            string filterEpOperationRicavo = QHS.CmpEq("idepoperation", "ric_accantonamento");

            DS.accmotiveapplied.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationCosto;
            DS.accmotiveapplied_patrim.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationPatrim;
            DS.accmotiveapplied_ricavo.ExtendedProperties[MetaData.ExtraParams] = filterEpOperationRicavo;

            GetData.SetStaticFilter(DS.accmotiveapplied, filterEpOperationCosto);
            GetData.SetStaticFilter(DS.accmotiveapplied_patrim, filterEpOperationPatrim);
            GetData.SetStaticFilter(DS.accmotiveapplied_ricavo, filterEpOperationRicavo);

            DataAccess.SetTableForReading(DS.accmotiveapplied_patrim, "accmotiveapplied");
            DataAccess.SetTableForReading(DS.accmotiveapplied_ricavo, "accmotiveapplied");

            //GetData.SetStaticFilter(DS.provisiondetail,QHS.CmpEq("ydetail",Conn.GetEsercizio()));
        }

       

        
    }
}
