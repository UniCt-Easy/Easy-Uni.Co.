/*
    Easy
    Copyright (C) 2019 Università degli Studi di Catania (www.unict.it)

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

ï»¿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using metaeasylibrary;
using metadatalibrary;
using funzioni_configurazione;

namespace profservicecig_detail {
    public partial class Frm_profservicecig_detail :Form {
        CQueryHelper QHC;
        QueryHelper QHS;
        MetaData Meta;
        public Frm_profservicecig_detail() {
            InitializeComponent();
        }

        DataAccess Conn;
        public void MetaData_AfterLink() {
            Meta = MetaData.GetMetaData(this);
            Conn = Meta.Conn;
            QHC = new CQueryHelper();
            QHS = Conn.GetQueryHelper();

            DataRow DR = Meta.SourceRow;
            cmbAggiudicatario.Enabled = false;

            GetData.MarkToAddBlankRow(DS.capogruppo);
            PostData.MarkAsTemporaryTable(DS.capogruppo, true);

            DataTable Partecipanti = Meta.SourceRow.Table.DataSet.Tables["profserviceavcp"];
            foreach (DataRow p in Partecipanti.Select(QHC.IsNull("idmain_avcp"))) {
                DataRow rC = DS.capogruppo.NewRow();
                rC["idavcp"] = p["idavcp"];
                rC["title"] = p["title"];
                DS.capogruppo.Rows.Add(rC);
            }
            cmbAggiudicatario.DataSource = DS.capogruppo;
            cmbProceduradiScelta.DataSource = DS.avcpchoice;

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
        }

        private decimal CalcolaImporto(DataRow rProfservice) {
            decimal costototale = CfgFn.GetNoNullDecimal(rProfservice["!imponibileiva"]);
            return costototale;
        }
        private void btnAutoInsDati_Click(object sender, EventArgs e) {
            Meta.GetFormData(true);
            DataRow rProfservicecig = Meta.SourceRow;
            DataRow rProfservice = rProfservicecig.GetParentRow("profservice_profservicecig");
            DataRow Curr = DS.profservicecig.Rows[0];
            //Curr["cigcode"] = rProfservice["cigcode"];
            Curr["description"] = rProfservice["description"];
            Curr["start_contract"] = rProfservice["start"];
            Curr["stop_contract"] = rProfservice["stop"];
            decimal ImponibileTotale = CalcolaImporto(rProfservice);
            Curr["contractamount"] = CfgFn.GetNoNullDecimal(ImponibileTotale);
            Meta.FreshForm(false);
        }
    }
}
