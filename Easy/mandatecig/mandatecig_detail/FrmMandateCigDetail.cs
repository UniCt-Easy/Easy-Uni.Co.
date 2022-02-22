
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
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;//funzioni_configurazione


namespace mandatecig_detail {
    public partial class FrmMandateCigDetail : MetaDataForm {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;

        public FrmMandateCigDetail() {
            InitializeComponent();
        }
        
		DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            DataRow DR = Meta.SourceRow;
            DataTable MandateKind = Conn.RUN_SELECT("mandatekind", "*", null,
                QHS.CmpEq("idmankind", DR["idmankind"]), null, null, true);

            bool isrequest = false;
            if (MandateKind.Rows.Count > 0) {
                string multiReg = MandateKind.Rows[0]["multireg"].ToString();
                isrequest = MandateKind.Rows[0]["isrequest"].ToString().ToUpper() == "S";
                if (multiReg == "S") {
                    cmbAggiudicatario.Enabled = true;
                }
                else {
                    cmbAggiudicatario.Enabled = false;

                }
            }

            GetData.MarkToAddBlankRow(DS.capogruppo);
            PostData.MarkAsTemporaryTable(DS.capogruppo, true);

            DataTable Partecipanti = Meta.SourceRow.Table.DataSet.Tables["mandateavcp"];
            foreach (DataRow p in Partecipanti.Select(QHC.IsNull("idmain_avcp"))) {
                DataRow rC = DS.capogruppo.NewRow();
                rC["idavcp"] = p["idavcp"];
                rC["title"] = p["title"];
                DS.capogruppo.Rows.Add(rC);
            }
            cmbAggiudicatario.DataSource = DS.capogruppo;
            cmbProceduradiScelta.DataSource = DS.avcpchoice;

            if (isrequest) {
                labAggiudicatario.Visible = false;
                cmbAggiudicatario.Visible = false;
            }
        }

        private void btnOk_Click(object sender, EventArgs e) {

        }
        private decimal RoundDecimal6(decimal valuta) {
            decimal truncated = Decimal.Truncate(valuta * 10000000);
            if (truncated > 0) {
                if ((truncated % 10) >= 5)
                    truncated += 5;
                }
            else {
                if (((-truncated) % 10) >= 5)
                    truncated -= 5;
                }
            truncated = truncated / 10;
            truncated = Decimal.Truncate(truncated);
            return truncated / 1000000;
            //			SqlDecimal SQLV = new SqlDecimal(valuta);
            //			return SqlDecimal.Round(SQLV,NCifreDecimaliPerRisultatiValuta).Value;
            }

        private decimal CalcolaImporto(DataRow rMandate, DataTable tMandatedetail) {
            decimal exchangerate = CfgFn.GetNoNullDecimal(rMandate["exchangerate"]);
            decimal imponibile = 0;
            //decimal imposta = 0;
            decimal totale = 0;
            int prevgroup = -1;
            decimal totimponibile_currgroup = 0;
            decimal lastexpr = 0;

            foreach (DataRow R in tMandatedetail.Select()) {
                if (R["stop"] != DBNull.Value)
                    continue;
                int currgroup = CfgFn.GetNoNullInt32(R["idgroup"]);
                if (currgroup != prevgroup) {
                    imponibile += lastexpr;
                    totimponibile_currgroup = 0;
                    prevgroup = currgroup;
                    }

                decimal R_imponibile = CfgFn.GetNoNullDecimal(R["taxable"]);
                decimal R_quantitaConfezioni = CfgFn.GetNoNullDecimal(R["npackage"]);
                //decimal R_imposta = CfgFn.GetNoNullDecimal(R["tax"]);
                decimal R_sconto = RoundDecimal6(CfgFn.GetNoNullDecimal(R["discount"]));
                //imposta += CfgFn.RoundValuta(R_imposta); //ora consideriamo l'iva già in euro e non in valuta
                totimponibile_currgroup += R_imponibile;
                lastexpr = CfgFn.RoundValuta((totimponibile_currgroup * R_quantitaConfezioni * (1 - R_sconto)) * exchangerate);
                }
            imponibile += lastexpr;
            totale = imponibile; // +imposta;
            decimal totaleEUR = CfgFn.RoundValuta(totale);

            return totaleEUR;
            }
        private void btnAutoInsDati_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);
            DataRow rMandatecig = Meta.SourceRow;
            DataRow rMandate = rMandatecig.GetParentRow("mandate_mandatecig");
            DataRow Curr=DS.mandatecig.Rows[0];
            Curr["cigcode"] = rMandate["cigcode"];
            Curr["description"] = rMandate["description"];
            Curr["start_contract"] = rMandate["adate"];
            DataTable tMandatedetail = rMandatecig.Table.DataSet.Tables["mandatedetail"];
            decimal ImponibileTotale= CalcolaImporto(rMandate, tMandatedetail);
            Curr["contractamount"] = CfgFn.GetNoNullDecimal(ImponibileTotale);
            Meta.FreshForm(false);
            }
    }
}
